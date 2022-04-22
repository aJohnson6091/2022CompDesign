import sys
import json
import os.path
import re
import io

#infilename = name of grammar file
#outfilename = name of file which will contain the C# classes
#namespace = namespace for generated file. If empty, no namespace is created.
def main(infilename,outfilename,namespace):
    
    validLabel = re.compile(r"^\w+$")
    
    #don't create file if nothing has changed
    t1 = os.path.getmtime(infilename)
    
    if outfilename == "-":
        existingContent=""
    elif not os.path.exists(outfilename):
        existingContent=""
    else:
        with open(outfilename) as fp:
            existingContent=fp.read()
        
    
    with open(infilename) as fp:
        grammardata = fp.read()
    G = MiniGrammar(grammardata)
    
    terminals=G.terminals
    
    #collect up the labels
    allLabels=set()
    nonterminals=set()
    duplicates=set()
    for i,p in enumerate(G.productions):
        for label in p.labels:
            if label and validLabel.match(label):
                if label in allLabels:
                    duplicates.add(label)
                allLabels.add(label)
        if validLabel.match(p.lhs):
            nonterminals.add(p.lhs)
    
    allLabels = list(sorted(allLabels))
    nonterminals = list(sorted(set(nonterminals)))
    
  
        
    ofp = io.StringIO()
        
    enterNTCases=[]
    leaveNTCases=[]
    for sym in nonterminals:
        enterNTCases.append(f'                case "{sym}": enterNonterminal_{sym}(n); break;')
        leaveNTCases.append(f'                case "{sym}": leaveNonterminal_{sym}(n); break;')
    enterNTCases = "\n".join(enterNTCases)
    leaveNTCases = "\n".join(leaveNTCases)
    
    enterCases=[]
    leaveCases=[]
    walkCases=[]
    for lbl in allLabels:
        if validLabel.match(lbl):
            enterCases.append(f'                case "{lbl}": enter_{lbl}(n); break;')
            leaveCases.append(f'                case "{lbl}": leave_{lbl}(n); break;')
            walkCases.append( f'                case "{lbl}": walk_{lbl}(n);  break;')
            
    enterCases = "\n".join(enterCases)
    leaveCases = "\n".join(leaveCases)
    walkCases =  "\n".join(walkCases)

    print("// this file is auto-generated. Do not edit.",           file=ofp)
    print("",                                                       file=ofp)
    print("using System.Collections.Generic;",                      file=ofp)
    if namespace:
        print("namespace",namespace,"{",                            file=ofp)
        print("",                                                   file=ofp)

    print("public class TreeWalker{",                               file=ofp)
    
    print("    public void walkEnter(TreeNode n){",                 file=ofp)
    print("        enter(n);",                                      file=ofp)
    print("        switch(n.sym){",                                 file=ofp)
    print(enterNTCases,                                             file=ofp)
    print("        }",                                              file=ofp)
    print("        foreach(var sym in n.labels){",                  file=ofp)
    print("            switch(sym){",                               file=ofp)
    print(enterCases,                                               file=ofp)
    print("            }",                                          file=ofp)
    print("        }",                                              file=ofp)
    print("    }",                                                  file=ofp)
    print("    public void walkLeave(TreeNode n){",                 file=ofp)
    print("        foreach(var sym in n.labels){",                  file=ofp)
    print("            switch(sym){",                               file=ofp)
    print(leaveCases,                                               file=ofp)
    print("            }",                                          file=ofp)
    print("        }",                                              file=ofp)
    print("        switch(n.sym){",                                 file=ofp)
    print(leaveNTCases,                                             file=ofp)
    print("        }",                                              file=ofp)
    print("        leave(n);",                                      file=ofp)
    print("    }",                                                  file=ofp)
    print("    public void walk(TreeNode n){",                      file=ofp)
    print("        if( n.labels.Length == 0 ){",                    file=ofp)
    print("            walkGeneric(n);",                            file=ofp)
    print("            return;",                                    file=ofp)
    print("        }",                                              file=ofp)
    print("        switch(n.labels[0]){",                           file=ofp)
    print(walkCases,                                                file=ofp)
    print("            default:",                                   file=ofp)
    print("                walkGeneric(n); break;",                 file=ofp)
    print("        }",                                              file=ofp)
    print("    }",                                                  file=ofp)
    print("    public void walkGeneric(TreeNode n){",               file=ofp)
    print("        walkEnter(n);",                                  file=ofp)
    print("        foreach(var c in n.children ){",                 file=ofp)
    print("            walk(c);",                                   file=ofp)
    print("        }",                                              file=ofp)
    print("        walkLeave(n);",                                  file=ofp)
    print("    }",                                                  file=ofp)
    print("    public void rwalk(TreeNode n){",                     file=ofp)
    print("        walkEnter(n);",                                  file=ofp)
    print("        for(int i=n.children.Count-1;i>=0;i--){",        file=ofp)
    print("            rwalk(n.children[i]);",                      file=ofp)
    print("        }",                                              file=ofp)
    print("        walkLeave(n);",                                  file=ofp)
    print("    }",                                                  file=ofp)
    for sym in nonterminals:
        if validLabel.match(sym):
            print(f"    public virtual void enterNonterminal_{sym}(TreeNode n) {{ }}",              file=ofp)
            print(f"    public virtual void leaveNonterminal_{sym}(TreeNode n) {{ }}",              file=ofp)

    for lbl in allLabels:
        print(f"    public virtual void enter_{lbl}(TreeNode n){{}}",file=ofp)
        print(f"    public virtual void walk_{lbl}(TreeNode n) {{ walkGeneric(n); }}",          file=ofp)
        print(f"    public virtual void leave_{lbl}(TreeNode n){{}}",file=ofp)

    print("    public virtual void enter(TreeNode n){}",            file=ofp)
    print("    public virtual void leave(TreeNode n){}",            file=ofp)
    
    print("} //end TreeWalker",                                     file=ofp)
        
    if namespace:
        print("} //end namespace",file=ofp)
    
    output = ofp.getvalue()
    
    if output == existingContent:
        print("Output file has not changed; not rewriting",file=sys.stderr)
    else:
        if outfilename == "-":
            print(output)
        else:
            with open(outfilename,"w") as fp:
                fp.write(output)
            print("Generated",outfilename,file=sys.stderr)
    
        if len(duplicates):
            print(f"Note: Duplicate label{'' if len(duplicates) == 1 else 's'}",file=sys.stderr)
            print("    "+"\n    ".join(duplicates),file=sys.stderr)
        
    
class MiniGrammar:
    class Production:
        def __init__(self,lhs,labels):
            self.lhs=lhs
            self.labels=labels
            
    def __init__(self,data): 
        self.terminals=set()
        self.productions=[]
             
        lines = data.split("\n")
        L=[]
        for line in lines:
            if len(line) == 0:
                continue
                
            if line[0] in " \t":
                L[-1] += " " + line.strip()
            else:
                L.append(line.strip())

        for line in L:
            if line.startswith("#"):
                continue
            if len(line) == 0:
                continue
            assert line.find("::") != -1
            lhs,rhs = line.split("::",1)
            lhs=lhs.strip()
            rhs=rhs.strip()
            if lhs != "S" and lhs.upper() == lhs:
                self.terminals.add(lhs)
            else:
                for prod in rhs.split("|"):
                    atindex = prod.find("@")
                    if atindex == -1:
                        labels=[]
                    else:
                        labels=prod[atindex+1:].strip().split(",")
                        if " " in labels:
                            print("Warning: Space character in label:",labels,file=sys.stderr)
                        labels = [q.strip() for q in labels]
                        
                    self.productions.append( MiniGrammar.Production(lhs,labels) )
    
if __name__=="__main__":
    infilename = sys.argv[1]
    outfilename = sys.argv[2]
    if len(sys.argv) <= 3:
        namespace=""
    else:
        namespace = sys.argv[3]
    main(infilename,outfilename,namespace)
