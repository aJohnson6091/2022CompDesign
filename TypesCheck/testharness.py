#!/usr/bin/env python3

import sys
import configparser
import os.path
import json
import tempfile
import zipfile
import subprocess
from utils import *
 
def main():
    
    if len(sys.argv) > 1:
        numToSkip = int(sys.argv[1])
    else:
        numToSkip=0
    p =  os.path.join(os.path.dirname(__file__),"tests")
    p = os.path.abspath(p)
    
    grammarfile = os.path.join(p,"grammar.txt")
    grammarspec = os.path.join(p,"grammar.spec")
    
    assert os.path.exists(grammarfile)
    assert os.path.exists(grammarspec)
    
    for dirpath,dirs,files in os.walk(p):
        for nn in sorted(files):
            if nn.endswith(".tree"):
                if numToSkip > 0:
                    numToSkip-=1
                    continue
                    
                tmp = nn.split(".")[0]
                treefile = os.path.join(dirpath,nn)
                assert os.path.exists(treefile)
                inputfile=os.path.join(dirpath,tmp+".txt")
                assert os.path.exists(inputfile)
                if not doTest(grammarfile,inputfile,grammarspec,treefile):
                    print("Failed.")
                    return
                else:
                    print("Test OK")
                        
    print("All OK!")
    
def copy(f1,f2):
    with open(f1,"r") as fp:
        data = fp.read()
    with open(f2,"w") as fp:
        fp.write(data)

rex=re.compile(r"(?s)/\*\*\s*(\d).*?\*\*/")

def doTest(grammarfile, inputfile, grammarspec, treefile):
    print("Testing: Input=",inputfile)

    with open(inputfile) as fp:
        data = fp.read()
    
    expected = int(rex.search(data).group(1))
    data = rex.sub("",data)
    with open("inp.txt","w") as fp:
        fp.write(data)
        
    copy(grammarfile,"gram.txt")
    copy(grammarspec,"gram.spec")
    copy(treefile,"inp.tree")
    
    data = run( args=["gram.txt","inp.txt","gram.spec","inp.tree"] )

    try:
        J = json.loads(data)
    except json.JSONDecodeError as e:
        print("Cannot decode JSON")
        print(e)
        print("Output:")
        print(data)
        return False
           
    if "ok" not in J:
        print("Missing required element \"ok\"")
        print("Output:")
        print(data)
        return False
        
    ok = J["ok"]
    
    if expected:
        eok=True
    else:
        eok=False
        
    if ok != eok:
        print("Expected ok=",eok,"but got",ok)
        print("Input:")
        print(readFile(inputfile))
        print("Output:")
        print(data)
        return False
        
    return True
     
 
    
main()
