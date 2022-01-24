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
    inputs = getInputsForGrammars(tests,grammars)
    expected = getExpectedForInputs(tests,inputs)
    
    for gname in sorted(grammars):
        for iname in sorted(inputs[gname]):
            ename = expected[iname]
            if not doTest(gname,tests[gname],iname,tests[iname],ename,tests[ename]):
                print("Failed.")
                return
            else:
                print("Test OK")
                        
    print("All OK!")

def doTest(gname,gdata,iname,idata,ename,edata):
    print("Testing: Grammar=",gname,"input=",iname,"expected=",ename)
    jdata=run(gdata,idata)
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
        
    if "error" not in J:
        print("Required field 'error' missing from output")
        print(J)
        return False
        
    J2 = json.loads(edata)
    
    if J2["error"] == -1 :
        if J["error"] != -1:
            print("Tokenizer gave no error on bad input")
            return False
        else:
            if "tokens" not in J:
                print("Field 'tokens' missing from output")
                print(J)
                return False
                
            #both are -1.
            if J["tokens"] != J2["tokens"]:
                print("Mismatch!")
                print("Got:")
                print(J)
                print("="*40)
                print("Expected:")
                print(J2)
                return False
            else:
                return True
    else:
        if J2["error"] != J["error"]:
            print("Should have reported error on line",J2["error"],
                "but reported error on line",J["error"])
            return False
        else:
            return True
        
    assert 0
    
main()
