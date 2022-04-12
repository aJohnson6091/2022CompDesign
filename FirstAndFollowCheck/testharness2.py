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
                follow = M.group(1)+"-follow.txt"
                
                gramtxt = os.path.join(dirpath,gramtxt)
                gramjson = os.path.join(dirpath,gramjson)
                nullable = os.path.join(dirpath,nullable)
                first = os.path.join(dirpath,first)
                follow = os.path.join(dirpath,follow)
                    
                if not doTest(gramtxt,gramjson,nullable,first,follow):
                    print("Failed.")
                    return
                else:
                    print("Test OK")
                        
    print("All OK!")


def doTest(gramtxt,gramjson,nullable,first,follow):
    print("Testing: ",gramtxt)
    jdata=run(readFile(gramtxt),readFile(gramjson),readFile(nullable),readFile(first))
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
        
    if "follow" not in J:
        print("Output should have 'follow' key")
        return False
        
    if type(J["follow"]) != dict:
        print("Type of 'follow' should be a dictionary")
        return False

    J2 = json.loads(readFile(follow))

    
    F1 = J["follow"]
    F2 = J2["follow"]
    
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
