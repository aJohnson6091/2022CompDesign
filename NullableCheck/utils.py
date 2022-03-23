#!/usr/bin/env python3

import sys
import configparser
import os.path
import json
import tempfile
import subprocess
import fnmatch
import re
import shlex
import pprint as PP

cfile = os.path.join(os.path.dirname(__file__),"config.ini")
config = configparser.ConfigParser(
    interpolation=configparser.ExtendedInterpolation() )
config.read(cfile)
conf = config["config"]
VERBOSE = conf.getboolean("verbose",fallback=False)
  

class JSONDict:
    def __init__(self,D):
        self._D=D
        
    def __getattr__(self,name):
        return self._D[name]
    def __get__(self,name):
        return self._D[name]
            

def readFile(fname):
    with open(fname) as fp:
        data = fp.read()
    return data
    
def pprint(*args,**kw):
    L=[]
    for a in args:
        if type(a) == str:
            L.append(a)
        elif type(a) == int:
            L.append(str(a))
        else:
            L.append(PP.pformat(a))
            
    print(" ".join(L),**kw)
    
def run(*args,**kw):
    files=[]
    for a in args:
        tf = tempfile.NamedTemporaryFile(delete=False)
        tf.close()
        with open(tf.name,"w") as fp:
            fp.write(a)
        files.append(tf.name)
        if VERBOSE:
            print("Temporary file:",tf.name)

    try:
        if "stdin" in kw:
            stdin = kw["stdin"]
        else:
            stdin=""
            
        stdin=stdin.encode()
        
        
        cmd = []
        
        launcher = conf["launcher"]
        if launcher:
            cmd += shlex.split(launcher)
            
        exe = conf["exe"]
        if exe:
            cmd += shlex.split(exe)
              
        cmd += kw.get("args",[])
        
        cmd += files
        
        if VERBOSE:
            print(cmd)
            
        timeout = conf.getfloat("timeout",fallback=0)
        if timeout == 0:
            timeout=None
            
        P=subprocess.Popen(cmd,stdout=subprocess.PIPE,stdin=subprocess.PIPE)
        s,_ = P.communicate(stdin,timeout=timeout)
        s=s.decode()
        return s
    finally:
        for t in files:
            os.unlink(t)

def readAllTests():
    tests={}
    for dirpath,dirs,files in os.walk(os.path.join(
                os.path.dirname(__file__),"tests")):
        for fname in files:
            if fname.endswith(".txt"):
                with open(os.path.join(dirpath,fname)) as fp:
                    data = fp.read()
                    tests[fname]=data
    return tests

def getAllGrammars(tests):
    rex=re.compile(r"^g[^\-]+\.txt$")
    g=[]
    for k in tests:
        if rex.match(k):
            g.append(k)
    return g
    
def getInputsForGrammars(tests,grammars):
    inp={}
    for g in grammars:
        inp[g]=[]
        i=g.rfind(".")
        rex=re.compile( "^" + g[:i]+"-input\d+\.txt$")
        for k in tests:
            if rex.match(k):
                inp[g].append(k)
    return inp
    
def getExpectedForInputs(tests,inputs):
    e={}
    for g in inputs:
        for inp in inputs[g]:
            i=inp.rfind(".")
            needle = inp[:i]+"-results.txt"
            e[inp] = needle
    return e
    
def toImmutable(x):
    if type(x) in [int,float,str,tuple]:
        return x
    elif type(x) == list:
        return tuple([toImmutable(q) for q in x])
    elif type(x) == dict:
        s=set()
        for key in x:
            value = toImmutable(x[key])
            s.add( (key,value) )
        return frozenset(s)
    elif x == None:
        return None
    else:
        assert 0
   

def rearrangeProductions(productions1,productions2):
    
    for i,p1 in enumerate(productions1):
        if "lhs" not in p1:
            print("Production is missing lhs:",p1)
            return False,None,None
        if "rhs" not in p1:
            print("Production is missing rhs:",p1)
            return False,None,None
        if "label" not in p1:
            print("Production is missing label:",p1)
            return False,None,None
            
            
    if len(productions1) != len(productions2):
        print("Wrong number of productions: Expected",
            len(productions2),"; got",len(productions1))
        print("Expected:")
        L=[]
        for p in productions2:
            L.append(f'    {p["lhs"]} :: {p["rhs"]}')
        L.sort()
        print("\n".join(L))
        print("Got:")
        L=[]
        for p in productions1:
            L.append(f'    {p["lhs"]} :: {p["rhs"]}')
        L.sort()
        print("\n".join(L))
        return False,None,None
        
    #compute production equivalencies
    #productions2[j] <-> productions1[ pmap[j] ]
    pmap={}
    for i,p1 in enumerate(productions1):
        for j,p2 in enumerate(productions2):
            if p1["lhs"] == p2["lhs"] and p1["rhs"] == p2["rhs"] and p1["label"]==p2["label"]:
                pmap[j]=i
                break
        else:
            print("Spurious production",p1)
            return False,None,None
            
    for j in range(len(productions2)):
        if j not in pmap:
            print("Missing production:",productions2[j])
            return False,None,None

    P=[None]*len(productions1)
    for j in range(len(productions2)):
        P[ pmap[j] ] = productions2[j]
    return True,P,pmap
    
def printNFAState(productions,q1):
    pi = q1["item"]["productionIndex"]
    dpos = q1["item"]["dpos"]
    prod = productions[pi]
    rhs=prod["rhs"]
    before = rhs[:dpos]
    after = rhs[dpos:]
    tmp = before + ["\u2022"] + after
    print(q1["item"])
    print(prod["lhs"],"::", " ".join(tmp))
    keys1 = set(q1["transitions"].keys())
    if "" in keys1:
        keys1.remove("")
        keys1.add("\u03bb")
    print("Has outgoing edges:     ", " ".join(keys1))


def printDFAState(productions,nfastates,q1):
    print("DFA State:")
    print("    Label:")
    for ni in q1["label"]:
        nq = nfastates[ni]
        pi = nq["item"]["productionIndex"]
        dpos = nq["item"]["dpos"]
        prod = productions[pi]
        rhs=prod["rhs"]
        before = rhs[:dpos]
        after = rhs[dpos:]
        tmp = before + ["\u2022"] + after
        print("        ",prod["lhs"],"::", " ".join(tmp))
    keys1 = set(q1["transitions"].keys())
    print("Has outgoing edges:     ", " ".join(keys1))
    
def remapProductionsInNFA(nfa2,pmap):
    #renumber the production numbers in states2 to match the ones in states1
    for q in nfa2:
        pi = q["item"]["productionIndex"]
        pi = pmap[pi]
        q["item"]["productionIndex"] = pi
    
def remapNFAStates(productions,nfa1,nfa2):
     
    if len(nfa1) != len(nfa2):
        print("Wrong number of NFA states: Expected",
            len(nfa2),"; got",len(nfa1))
        return False,nfa2,None
    
    #states2[j] <-> states1[ nmap[j] ]
    #states1[i] corresponds to states2[ nmap[i] ]
    nmap={}
    for i,q1 in enumerate(nfa1):
        item1 = q1["item"]
        for j,q2 in enumerate(nfa2):
            item2 = q2["item"]
            if item1 == item2:
                nmap[j]=i
                break
        else:
            print("Spurious NFA state:",q1)
            printNFAState(productions,q1)
            return False,nfa2,None
            
    N=[None]*len(nfa1)
    for j in range(len(nfa2)):
        q = nfa2[j]
        if j not in nmap:
            print("Missing NFA state:",q)
            printNFAState(productions,q)
            return False,nfa2,None
        N[ nmap[j] ] = q
        D={}
        for sym in q["transitions"]:
            D[sym]=[]
            for destindex in q["transitions"][sym]:
                D[sym].append( nmap[destindex] )
        q["transitions"] = D
        
    nfa2 = N
    
    for i in range(len(nfa1)):
        q1 = nfa1[i]
        q2 = nfa2[i]
        if q1["item"] != q2["item"]:
            print("Item mismatch:")
            print(q1["item"])
            printNFAState(productions,q1)
            print("-"*20)
            print(q2["item"])
            printNFAState(productions,q2)
            print("-"*20)
            return False,nfa2,None
        keys1 = set(q1["transitions"].keys())
        keys2 = set(q2["transitions"].keys())
        if keys1 != keys2:
            print()
            print("Transition key mismatch")
            print("State:",i)
            printNFAState(productions,q1)
            if "" in keys2:
                keys2.remove("")
                keys2.add("\u03bb")
            print("Expected outgoing edges:", " ".join(keys2))
            return False,nfa2,None
        for k in keys1:
            t1 = q1["transitions"][k]
            t2 = q2["transitions"][k]
            t1 = set(t1)
            t2 = set(t2)
            if t1 != t2:
                print("Transition mismatch")
                return False,nfa2,None
            
    return True,nfa2,nmap
    
def remapNFAIndicesInDFA(dfa2,nmap):
    for q in dfa2:
        tmp=[]
        for ni in q["label"]:
            tmp.append(nmap[ni])
        q["label"] = tmp
    
    
def remapDFAStates(productions,nfa1,dfa1,dfa2):

    if len(dfa1) != len(dfa2):
        print("Wrong number of DFA states: Expected",
            len(dfa2),"; got",len(dfa1))
        return False,dfa2,None
       
       
    #speedup: Convert the lists to sets so we can do the compare faster
    lsets=[]
    for q2 in dfa2:
        lsets.append( set(q2["label"]) )
    
    dmap={}
    for i,q1 in enumerate(dfa1):
        label1 = set( q1["label"] )
        for j,q2 in enumerate(dfa2):
            label2 = lsets[j]
            if label1 == label2:
                dmap[j]=i
                break
        else:
            print("Spurious DFA state:",i)
            printDFAState(productions,nfa1,dfa1,q1)
            return False,dfa2,None
            
    
    D=[None]*len(dfa1)
    for j in range(len(dfa2)):
        q2 = dfa2[j]
        if j not in dmap:
            print("Missing DFA state:")
            printDFAState(productions,nfa1,dfa2,q2)
            return False,dfa2,None
        D[ dmap[j] ] = q2
        for sym in q2["transitions"]:
            destindex = q2["transitions"][sym]
            q2["transitions"][sym] = dmap[destindex]
        
    dfa2=D
    
    for i in range(len(dfa1)):
        q1 = dfa1[i]
        q2 = dfa2[i]
        if set(q1["label"]) != set(q2["label"]):
            print("Label mismatch: State",i)
            printDFAState(productions,nfa1,dfa1,q1)
            print("and")
            printDFAState(productions,nfa1,dfa2,q2)
            return False,dfa2,None

        if set(q1["transitions"].keys()) != set(q2["transitions"].keys()):
            print("Transition mismatch! State",i)
            print("Got:")
            printDFAState(productions,nfa1,dfa1,q1)
            print("Expected:")
            printDFAState(productions,nfa1,dfa2,q2)
            return False,dfa2,None
            
        for sym in q1["transitions"].keys():
            if q1["transitions"][sym] != q2["transitions"][sym]:
                print("Transition mismatch! State",i)
                print("Got:")
                printDFAState(productions,nfa1,dfa1,q1)
                print("Expected:")
                printDFAState(productions,nfa1,dfa2,q2)
                return False,dfa2,None
    
    return True,dfa2,dmap
    
def dumpNFA(fp,productions,nfa):
    print("digraph d{",file=fp)
    print('node [font="Helvetica",shape="box"];',file=fp)
    for nfaindex in range(len(nfa)):
        L=[f"{nfaindex}"]
        nq = nfa[nfaindex]
        pi = nq["item"]["productionIndex"]
        dpos = nq["item"]["dpos"]
        lhs = productions[pi]["lhs"]
        rhs = productions[pi]["rhs"]
        before = " ".join(rhs[:dpos])
        after = " ".join(rhs[dpos:])
        L.append(f"{lhs} :: {before} • {after}")
        lbl = "\\n".join(L)
        print( f'n{nfaindex} [label="{lbl}"];',file=fp)
        
    for i in range(len(nfa)):
        q=nfa[i]
        for sym in q["transitions"]:
            for di in q["transitions"][sym]:
                if sym == "":
                    lbl = "<&lambda;>"
                else:
                    lbl='"'+sym+'"'
                print( f'n{i} -> n{di} [label={lbl}];',file=fp)
    
    print("}",file=fp)
    
        
def dumpDFA(fp,productions,nfa,dfa):
    print("digraph d{",file=fp)
    print('node [font="Helvetica",shape="box"];',file=fp)
    for dfaindex in range(len(dfa)):
        L=[f"{dfaindex}"]
        q = dfa[dfaindex]
        for nfaindex in sorted(q["label"]):
            nq = nfa[nfaindex]
            pi = nq["item"]["productionIndex"]
            dpos = nq["item"]["dpos"]
            lhs = productions[pi]["lhs"]
            rhs = productions[pi]["rhs"]
            before = " ".join(rhs[:dpos])
            after = " ".join(rhs[dpos:])
            L.append(f"{lhs} :: {before} • {after}")
        lbl = "\\n".join(L)
        print( f'n{dfaindex} [label="{lbl}"];',file=fp)
        
    for i in range(len(dfa)):
        q=dfa[i]
        for sym in q["transitions"]:
            di = q["transitions"][sym]
            if sym == "":
                lbl = "<&lambda;>"
            else:
                lbl='"'+sym+'"'
            print( f'n{i} -> n{di} [label={lbl}];',file=fp)
    
    print("}",file=fp)
    
      
