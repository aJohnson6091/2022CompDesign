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
                
                gramtxt = os.path.join(dirpath,gramtxt)
                gramjson = os.path.join(dirpath,gramjson)
                nullable = os.path.join(dirpath,nullable)
                    
                if not doTest(gramtxt,gramjson,nullable):
                    print("Failed.")
                    return
                else:
                    print("Test OK")
                        
    print("All OK!")

def doTest(gramtxt,gramjson,nullable):
    print("Testing:",gramtxt)
    gtxtdata = readFile(gramtxt)
    gjdata = readFile(gramjson)
    
    jdata=run(gtxtdata,gjdata)
    
    try:
        J = json.loads(jdata)
    except json.JSONDecodeError as e:
        print("Cannot decode JSON data:",e)
        print(jdata)
        return False
    
    if type(J) != dict:
        print("Output should be a JSON dictionary")
        print("Got:")
        print(jdata)
        return False
        
    if "nullable" not in J:
        print("Missing key: nullable")
        return False
        
    ndata = readFile(nullable)
    J2 = json.loads(ndata)
    
    if set(J["nullable"]) != set(J2["nullable"]):
        print("Mismatch")
        pprint("Got:",       list(sorted(J)))
        pprint("Expected:",  list(sorted(J2)))
        return False
    
    return True
    
main()
