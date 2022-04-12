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
    
    p =  os.path.join(os.path.dirname(__file__),"tests")
    p = os.path.abspath(p)
    
    rex = re.compile(r"^(g\d+)\.txt$")

    for dirpath,dirs,files in os.walk(p):
        for fn in sorted(files):
            M = rex.match(fn)
            if M:
                gramtxt = fn
                gramjson = M.group(1)+"-grammar.txt"
                nullable = M.group(1)+"-nullable.txt"
                first = M.group(1)+"-first.txt"
                
                gramtxt = os.path.join(dirpath,gramtxt)
                gramjson = os.path.join(dirpath,gramjson)
                nullable = os.path.join(dirpath,nullable)
                first = os.path.join(dirpath,first)
                    
                if not doTest(gramtxt,gramjson,nullable,first):
                    print("Failed.")
                    return
                else:
                    print("Test OK")
                        
    print("All OK!")


def doTest(gramtxt,gramjson,nullable,first):
    print("Testing: ",gramtxt)
    jdata=run(readFile(gramtxt),readFile(gramjson),readFile(nullable))
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
        
    if "first" not in J:
        print("Output should have 'first' key")
        return False
        
    if type(J["first"]) != dict:
        print("Type of 'first' should be a dictionary")
        return False

    J2 = json.loads(readFile(first))

    
    F1 = J["first"]
    F2 = J2["first"]
    
    if set( F1.keys() ) != set(F2.keys()):
        print("Different list of symbols!")
        print("Got:     ",sorted(list(F1.keys())))
        print("Expected:",sorted(list(F2.keys())))
        return False
        
    for k in F1.keys():
        f1 = set(F1[k])
        f2 = set(F2[k])
        if f1 != f2:
            print("Mismatch for",k)
            pprint("Got:",       list(sorted(f1)))
            pprint("Expected:",  list(sorted(f2)))
            return False
    
    return True
    
main()
