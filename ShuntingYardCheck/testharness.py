#!/usr/bin/env python3

import json
import subprocess
import sys
import os
import os.path
import utils
             
    
def main():
    
    tpts=0
    ok = testWithFile("basictests.txt")
    if ok:
        print("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-Basic tests OK-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=")
    else:
        print("oops.")
        return
        
    tpts+=100
    
    pts=[33,33,50,33,15]
    for i in range(1,6):
        ok = testWithFile("bonus{}tests.txt".format(i))
        if ok:
            print("-=-=-=-=-=-=-=-=-=-=-Bonus {} tests OK: +{}% -=-=-=-=-=-=-=-=-=-=-".format(i,pts[i-1]))
            tpts += pts[i-1]
            
    print("Total pointage:",tpts)
            
        
    
def testWithFile(fname):
    with open(os.path.join(os.path.dirname(__file__),"tests",fname)) as fp:
        data = fp.read()
    J = json.loads(data)
    for i in range(0,len(J),3):
        inp,expected,tree = J[i:i+3]
        print("Testing {:40s}".format(inp),end="")
        sys.stdout.flush()
        o = utils.run(stdin=inp)
        try:
            actual = float(o)
        except ValueError as e:
            print("Not a float:",o)
            print("BAD!")
            return False
        
        if not abs(expected-actual) < 0.00001:
            print("BAD!")
            print()
            print("Expected:",expected,"Actual:",actual)
            return False 
        else:
            print("{:15f}  OK!".format(actual))
    return True

main()
