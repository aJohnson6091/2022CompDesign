#!/usr/bin/env python3

import sys
import os.path
import json
import tempfile
import subprocess
import fnmatch
import re
from utils import *
 
def main():
 
    tests = readAllTests()
    grammars=getAllGrammars(tests)
    for gname in sorted(grammars):
        i=gname.rfind(".")
        ename = gname[:i]+"-results.txt"
        if not doTest(gname,tests[gname],ename,tests[ename]):
            print("Failed.")
            return
        else:
            print("Test OK")
                        
    print("All OK!")

def doTest(gname,gdata,ename,edata):
    print("Testing: Grammar=",gname,"expected=",ename)
    jdata=run(gdata)
    try:
        J = json.loads(jdata)
    except json.JSONDecodeError as e:
        print("Cannot decode JSON")
        print(e)
        print(jdata)
        return False
    
    if type(J) != dict:
        print("JSON should be a dictionary")
        print(J)
        return False
        
    for k in ["terminals","nonterminals"]:
        if k not in J:
            print("Required field",k,"missing from output")
            return False
    
    J2 = json.loads(edata)
    
    if set(J["terminals"]) != set(J2["terminals"]):
        print("Terminals mismatch")
        pprint("Got:",       list(sorted(J["terminals"])))
        pprint("Expected:",  list(sorted(J2["terminals"])))
        return False
    
    s1 = set(J["nonterminals"].keys()) 
    s2 = set(J2["nonterminals"].keys())
    
    if s1 != s2:
        print("Nonterminals don't match")
        pprint("Got:",      list(sorted(J["nonterminals"].keys())))
        pprint("Expected:", list(sorted(J2["nonterminals"].keys())))
        return False
        
    for n in s1:
        i1 = set(toImmutable(J["nonterminals"][n]))
        i2 = set(toImmutable(J2["nonterminals"][n]))
        if set(i1) != set(i2    ):
            print("Mismatch for nonterminal",n)
            pprint("Got:",J["nonterminals"][n])
            pprint("Expected:",J2["nonterminals"][n])
            return False
        
    return True
    
main()
