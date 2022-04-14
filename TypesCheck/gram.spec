{
  "terminals": [
    "SEMI",
    "LBR",
    "RBR",
    "LB",
    "RB",
    "COMMA",
    "EQUALS",
    "WHILE",
    "LP",
    "RP",
    "IF",
    "ELSE",
    "PLUS",
    "STAR",
    "BITOP",
    "OROR",
    "ANDAND",
    "RELOP",
    "NOT",
    "BITNOT",
    "NUM",
    "FNUM",
    "STR",
    "CHAR",
    "INT",
    "DOUBLE",
    "STRING",
    "STRUCT",
    "DOT",
    "RETURN",
    "VOID",
    "VEC2",
    "WHITESPACE",
    "COMMENT",
    "ID"
  ],
  "nonterminals": {
    "S": [
      {
        "lhs": "S",
        "rhs": [
          "decl",
          "S"
        ],
        "labels": []
      },
      {
        "lhs": "S",
        "rhs": [
          "decl"
        ],
        "labels": []
      }
    ],
    "addexp": [
      {
        "lhs": "addexp",
        "rhs": [
          "addexp",
          "PLUS",
          "mulexp"
        ],
        "labels": [
          "sum"
        ]
      },
      {
        "lhs": "addexp",
        "rhs": [
          "mulexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "andexp": [
      {
        "lhs": "andexp",
        "rhs": [
          "andexp",
          "ANDAND",
          "notexp"
        ],
        "labels": [
          "andexp"
        ]
      },
      {
        "lhs": "andexp",
        "rhs": [
          "notexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "assign": [
      {
        "lhs": "assign",
        "rhs": [
          "ID",
          "itemsel",
          "EQUALS",
          "expr"
        ],
        "labels": [
          "assign"
        ]
      }
    ],
    "bitexp": [
      {
        "lhs": "bitexp",
        "rhs": [
          "bitexp",
          "BITOP",
          "unaryexp"
        ],
        "labels": [
          "bitexp"
        ]
      },
      {
        "lhs": "bitexp",
        "rhs": [
          "unaryexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "braceBlock": [
      {
        "lhs": "braceBlock",
        "rhs": [
          "LBR",
          "vardecls",
          "stmts",
          "RBR"
        ],
        "labels": [
          "bblock"
        ]
      }
    ],
    "calllist": [
      {
        "lhs": "calllist",
        "rhs": [],
        "labels": []
      },
      {
        "lhs": "calllist",
        "rhs": [
          "expr"
        ],
        "labels": []
      },
      {
        "lhs": "calllist",
        "rhs": [
          "expr",
          "COMMA",
          "calllist2"
        ],
        "labels": []
      }
    ],
    "calllist2": [
      {
        "lhs": "calllist2",
        "rhs": [
          "expr"
        ],
        "labels": []
      },
      {
        "lhs": "calllist2",
        "rhs": [
          "expr",
          "COMMA",
          "calllist2"
        ],
        "labels": []
      }
    ],
    "cast": [
      {
        "lhs": "cast",
        "rhs": [
          "INT",
          "LP",
          "expr",
          "RP"
        ],
        "labels": [
          "castint"
        ]
      },
      {
        "lhs": "cast",
        "rhs": [
          "DOUBLE",
          "LP",
          "expr",
          "RP"
        ],
        "labels": [
          "castdouble"
        ]
      },
      {
        "lhs": "cast",
        "rhs": [
          "VEC2",
          "LP",
          "expr",
          "COMMA",
          "expr",
          "RP"
        ],
        "labels": [
          "castvec2"
        ]
      }
    ],
    "cond": [
      {
        "lhs": "cond",
        "rhs": [
          "IF",
          "LP",
          "expr",
          "RP",
          "braceBlock"
        ],
        "labels": [
          "if"
        ]
      },
      {
        "lhs": "cond",
        "rhs": [
          "IF",
          "LP",
          "expr",
          "RP",
          "braceBlock",
          "ELSE",
          "braceBlock"
        ],
        "labels": [
          "ifelse"
        ]
      }
    ],
    "decl": [
      {
        "lhs": "decl",
        "rhs": [
          "structdecl"
        ],
        "labels": []
      },
      {
        "lhs": "decl",
        "rhs": [
          "vardecl"
        ],
        "labels": []
      },
      {
        "lhs": "decl",
        "rhs": [
          "funcdecl"
        ],
        "labels": []
      }
    ],
    "expr": [
      {
        "lhs": "expr",
        "rhs": [
          "orexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "factor": [
      {
        "lhs": "factor",
        "rhs": [
          "NUM"
        ],
        "labels": [
          "num"
        ]
      },
      {
        "lhs": "factor",
        "rhs": [
          "FNUM"
        ],
        "labels": [
          "fnum"
        ]
      },
      {
        "lhs": "factor",
        "rhs": [
          "LP",
          "expr",
          "RP"
        ],
        "labels": [
          "expr"
        ]
      },
      {
        "lhs": "factor",
        "rhs": [
          "ID",
          "postfix"
        ],
        "labels": [
          "id"
        ]
      },
      {
        "lhs": "factor",
        "rhs": [
          "STR"
        ],
        "labels": [
          "str"
        ]
      },
      {
        "lhs": "factor",
        "rhs": [
          "cast"
        ],
        "labels": [
          "copyType"
        ]
      },
      {
        "lhs": "factor",
        "rhs": [
          "CHAR"
        ],
        "labels": [
          "char"
        ]
      }
    ],
    "funccall": [
      {
        "lhs": "funccall",
        "rhs": [
          "ID",
          "LP",
          "calllist",
          "RP"
        ],
        "labels": [
          "funccall"
        ]
      }
    ],
    "funcdecl": [
      {
        "lhs": "funcdecl",
        "rhs": [
          "type",
          "ID",
          "LP",
          "paramlist",
          "RP",
          "braceBlock"
        ],
        "labels": [
          "funcdecl"
        ]
      },
      {
        "lhs": "funcdecl",
        "rhs": [
          "VOID",
          "ID",
          "LP",
          "paramlist",
          "RP",
          "braceBlock"
        ],
        "labels": [
          "funcdecl"
        ]
      }
    ],
    "itemsel": [
      {
        "lhs": "itemsel",
        "rhs": [
          "LB",
          "expr",
          "RB",
          "itemsel"
        ],
        "labels": [
          "arraysel"
        ]
      },
      {
        "lhs": "itemsel",
        "rhs": [
          "LP",
          "calllist",
          "RP",
          "itemsel"
        ],
        "labels": [
          "fcallsel"
        ]
      },
      {
        "lhs": "itemsel",
        "rhs": [
          "DOT",
          "ID",
          "itemsel"
        ],
        "labels": [
          "membersel"
        ]
      },
      {
        "lhs": "itemsel",
        "rhs": [],
        "labels": []
      }
    ],
    "mulexp": [
      {
        "lhs": "mulexp",
        "rhs": [
          "mulexp",
          "STAR",
          "bitexp"
        ],
        "labels": [
          "product"
        ]
      },
      {
        "lhs": "mulexp",
        "rhs": [
          "bitexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "notexp": [
      {
        "lhs": "notexp",
        "rhs": [
          "NOT",
          "notexp"
        ],
        "labels": [
          "notexp"
        ]
      },
      {
        "lhs": "notexp",
        "rhs": [
          "relexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "optsize": [
      {
        "lhs": "optsize",
        "rhs": [
          "LB",
          "NUM",
          "RB"
        ],
        "labels": [
          "optsize"
        ]
      },
      {
        "lhs": "optsize",
        "rhs": [],
        "labels": []
      }
    ],
    "orexp": [
      {
        "lhs": "orexp",
        "rhs": [
          "orexp",
          "OROR",
          "andexp"
        ],
        "labels": [
          "orexp"
        ]
      },
      {
        "lhs": "orexp",
        "rhs": [
          "andexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "param": [
      {
        "lhs": "param",
        "rhs": [
          "type",
          "ID",
          "optsize"
        ],
        "labels": [
          "param"
        ]
      }
    ],
    "paramlist": [
      {
        "lhs": "paramlist",
        "rhs": [],
        "labels": [
          "noparams"
        ]
      },
      {
        "lhs": "paramlist",
        "rhs": [
          "param"
        ],
        "labels": [
          "oneparam"
        ]
      },
      {
        "lhs": "paramlist",
        "rhs": [
          "param",
          "COMMA",
          "paramlist2"
        ],
        "labels": [
          "manyparams"
        ]
      }
    ],
    "paramlist2": [
      {
        "lhs": "paramlist2",
        "rhs": [
          "param"
        ],
        "labels": [
          "paramlist2a"
        ]
      },
      {
        "lhs": "paramlist2",
        "rhs": [
          "param",
          "COMMA",
          "paramlist2"
        ],
        "labels": [
          "paramlist2b"
        ]
      }
    ],
    "postfix": [
      {
        "lhs": "postfix",
        "rhs": [
          "LB",
          "expr",
          "RB",
          "postfix"
        ],
        "labels": [
          "array"
        ]
      },
      {
        "lhs": "postfix",
        "rhs": [
          "LP",
          "calllist",
          "RP",
          "postfix"
        ],
        "labels": [
          "fcall"
        ]
      },
      {
        "lhs": "postfix",
        "rhs": [
          "DOT",
          "ID",
          "postfix"
        ],
        "labels": [
          "member"
        ]
      },
      {
        "lhs": "postfix",
        "rhs": [],
        "labels": []
      }
    ],
    "relexp": [
      {
        "lhs": "relexp",
        "rhs": [
          "addexp",
          "RELOP",
          "addexp"
        ],
        "labels": [
          "relexp"
        ]
      },
      {
        "lhs": "relexp",
        "rhs": [
          "addexp"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "return": [
      {
        "lhs": "return",
        "rhs": [
          "RETURN"
        ],
        "labels": [
          "returnvoid"
        ]
      },
      {
        "lhs": "return",
        "rhs": [
          "RETURN",
          "expr"
        ],
        "labels": [
          "returnexpr"
        ]
      }
    ],
    "stmt": [
      {
        "lhs": "stmt",
        "rhs": [
          "assign",
          "SEMI"
        ],
        "labels": []
      },
      {
        "lhs": "stmt",
        "rhs": [
          "cond"
        ],
        "labels": []
      },
      {
        "lhs": "stmt",
        "rhs": [
          "whileExpr"
        ],
        "labels": []
      },
      {
        "lhs": "stmt",
        "rhs": [
          "funccall",
          "SEMI"
        ],
        "labels": []
      },
      {
        "lhs": "stmt",
        "rhs": [
          "return",
          "SEMI"
        ],
        "labels": []
      },
      {
        "lhs": "stmt",
        "rhs": [
          "braceBlock"
        ],
        "labels": []
      }
    ],
    "stmts": [
      {
        "lhs": "stmts",
        "rhs": [
          "stmt",
          "stmts"
        ],
        "labels": []
      },
      {
        "lhs": "stmts",
        "rhs": [],
        "labels": []
      }
    ],
    "structdecl": [
      {
        "lhs": "structdecl",
        "rhs": [
          "STRUCT",
          "ID",
          "LBR",
          "vardecls",
          "RBR"
        ],
        "labels": [
          "structdecl"
        ]
      }
    ],
    "type": [
      {
        "lhs": "type",
        "rhs": [
          "INT"
        ],
        "labels": []
      },
      {
        "lhs": "type",
        "rhs": [
          "DOUBLE"
        ],
        "labels": []
      },
      {
        "lhs": "type",
        "rhs": [
          "STRING",
          "LB",
          "NUM",
          "RB"
        ],
        "labels": []
      },
      {
        "lhs": "type",
        "rhs": [
          "STRUCT",
          "ID"
        ],
        "labels": []
      },
      {
        "lhs": "type",
        "rhs": [
          "VEC2"
        ],
        "labels": []
      }
    ],
    "unaryexp": [
      {
        "lhs": "unaryexp",
        "rhs": [
          "PLUS",
          "unaryexp"
        ],
        "labels": [
          "plus"
        ]
      },
      {
        "lhs": "unaryexp",
        "rhs": [
          "BITNOT",
          "unaryexp"
        ],
        "labels": [
          "bitnot"
        ]
      },
      {
        "lhs": "unaryexp",
        "rhs": [
          "factor"
        ],
        "labels": [
          "copyType"
        ]
      }
    ],
    "vardecl": [
      {
        "lhs": "vardecl",
        "rhs": [
          "type",
          "ID",
          "optsize",
          "SEMI"
        ],
        "labels": [
          "vardecl"
        ]
      }
    ],
    "vardecls": [
      {
        "lhs": "vardecls",
        "rhs": [
          "vardecl",
          "vardecls"
        ],
        "labels": []
      },
      {
        "lhs": "vardecls",
        "rhs": [],
        "labels": []
      }
    ],
    "whileExpr": [
      {
        "lhs": "whileExpr",
        "rhs": [
          "WHILE",
          "LP",
          "expr",
          "RP",
          "braceBlock"
        ],
        "labels": [
          "while"
        ]
      }
    ]
  },
  "specification": "SEMI :: ;\nLBR :: \\{\nRBR :: \\}\nLB :: \\[\nRB :: \\]\nCOMMA :: ,\nEQUALS :: =\nWHILE :: \\bwhile\\b\nLP :: \\(\nRP :: \\)\nIF :: \\bif\\b\nELSE :: \\belse\\b\nPLUS :: [-+]\nSTAR :: [*/%]\nBITOP :: [&|^]|<<|>>\nOROR :: \\|\\||\\bor\\b\nANDAND :: &&|\\band\\b\nRELOP :: >=|<=|!=|==|>|<\nNOT :: !|\\bnot\\b\nBITNOT :: ~\nNUM :: \\d+\nFNUM :: (\\d+\\.\\d+|\\d+\\.|\\.\\d+)([eE][-+]?\\d+)?\nSTR :: \"(\\\\\"|[^\"])*\"\nCHAR :: '(\\\\.|.)'\nINT :: \\bint\\b\nDOUBLE :: \\bdouble\\b\nSTRING :: \\bstring\\b\nSTRUCT :: \\bstruct\\b\nDOT :: \\.\nRETURN :: \\breturn\\b\nVOID :: \\bvoid\\b\nVEC2 :: \\bvec2\\b\nWHITESPACE :: \\s+\nCOMMENT :: /\\*(\\n|.)*?\\*/|//[^\\n]*\nID :: [A-Za-z_]\\w*\n\n#program = at least one declaration\nS           ::  decl S | decl\n\n#declaration: Struct type declaration, global variable declaration, or\n#function declaration\ndecl        ::  structdecl | vardecl | funcdecl\n\n#struct declaration: Similar to C, but without the irritating\n#trailing semicolon\nstructdecl  ::  STRUCT ID LBR vardecls RBR                  @structdecl\n\n#variable: Three built-in types or a struct. Optional array size.\nvardecl     ::  type ID optsize SEMI                        @vardecl\noptsize     ::  LB NUM RB                                   @optsize \n            |   lambda                          \n            \n            \nfuncdecl    ::  type ID LP paramlist RP braceBlock          @funcdecl\n            |   VOID ID LP paramlist RP braceBlock          @funcdecl\ntype        ::  INT | DOUBLE | STRING LB NUM RB | STRUCT ID | VEC2\nparamlist   ::  lambda                                      @noparams\n            |   param                                       @oneparam\n            |   param COMMA paramlist2                      @manyparams\nparamlist2  ::  param                                       @paramlist2a\n            |   param COMMA paramlist2                      @paramlist2b\nparam       ::  type ID optsize                             @param\n\n\nbraceBlock  ::  LBR vardecls stmts RBR                      @bblock\n\n#variable declarations only. For use inside brace blocks.\nvardecls    ::  vardecl vardecls\n            |   lambda\n            \n#sequence of statements            \nstmts       ::  stmt stmts \n            |   lambda \nstmt        ::  assign SEMI \n            |   cond \n            |   whileExpr \n            |   funccall SEMI \n            |   return SEMI\n            |   braceBlock\n\nassign      ::  ID itemsel EQUALS expr                      @assign\n\n\nitemsel  ::     LB expr RB itemsel                          @arraysel\n            |   LP calllist RP itemsel                      @fcallsel\n            |   DOT ID itemsel                              @membersel\n            |   lambda \n\ncond        ::  IF LP expr RP braceBlock                    @if\n            |   IF LP expr RP braceBlock ELSE braceBlock    @ifelse\n\nwhileExpr   ::  WHILE LP expr RP braceBlock                 @while\n\n\nfunccall    ::  ID LP calllist RP                           @funccall\ncalllist    ::  lambda \n            |   expr \n            |   expr COMMA calllist2 \ncalllist2   ::  expr | expr COMMA calllist2 \n\nexpr        ::  orexp                                       @copyType\norexp       ::  orexp OROR andexp                           @orexp\n            |   andexp                                      @copyType\nandexp      ::  andexp ANDAND notexp                        @andexp\n            |   notexp                                      @copyType\nnotexp      ::  NOT notexp                                  @notexp\n            |   relexp                                      @copyType\nrelexp      ::  addexp RELOP addexp                         @relexp\n            |   addexp                                      @copyType\naddexp      ::  addexp PLUS mulexp                          @sum\n            |   mulexp                                      @copyType\nmulexp      ::  mulexp STAR bitexp                          @product\n            |   bitexp                                      @copyType\nbitexp      ::  bitexp BITOP unaryexp                       @bitexp\n            |   unaryexp                                    @copyType\nunaryexp    ::  PLUS unaryexp                               @plus\n            |   BITNOT unaryexp                             @bitnot\n            |   factor                                      @copyType\nfactor      ::  NUM                                         @num\n            |   FNUM                                        @fnum\n            |   LP expr RP                                  @expr\n            |   ID postfix                                  @id\n            |   STR                                         @str\n            |   cast                                        @copyType\n            |   CHAR                                        @char\npostfix     ::  LB expr RB postfix                          @array\n            |   LP calllist RP postfix                      @fcall\n            |   DOT ID postfix                              @member\n            |   lambda \ncast        ::  INT LP expr RP                              @castint\n            |   DOUBLE LP expr RP                           @castdouble\n            |   VEC2 LP expr COMMA expr RP                  @castvec2\nreturn      ::  RETURN                                      @returnvoid\n            |   RETURN expr                                 @returnexpr\n\n",
  "productions": [
    {
      "lhs": "S'",
      "rhs": [
        "S"
      ],
      "labels": []
    },
    {
      "lhs": "S",
      "rhs": [
        "decl",
        "S"
      ],
      "labels": []
    },
    {
      "lhs": "S",
      "rhs": [
        "decl"
      ],
      "labels": []
    },
    {
      "lhs": "addexp",
      "rhs": [
        "addexp",
        "PLUS",
        "mulexp"
      ],
      "labels": [
        "sum"
      ]
    },
    {
      "lhs": "addexp",
      "rhs": [
        "mulexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "andexp",
      "rhs": [
        "andexp",
        "ANDAND",
        "notexp"
      ],
      "labels": [
        "andexp"
      ]
    },
    {
      "lhs": "andexp",
      "rhs": [
        "notexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "assign",
      "rhs": [
        "ID",
        "itemsel",
        "EQUALS",
        "expr"
      ],
      "labels": [
        "assign"
      ]
    },
    {
      "lhs": "bitexp",
      "rhs": [
        "bitexp",
        "BITOP",
        "unaryexp"
      ],
      "labels": [
        "bitexp"
      ]
    },
    {
      "lhs": "bitexp",
      "rhs": [
        "unaryexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "braceBlock",
      "rhs": [
        "LBR",
        "vardecls",
        "stmts",
        "RBR"
      ],
      "labels": [
        "bblock"
      ]
    },
    {
      "lhs": "calllist",
      "rhs": [],
      "labels": []
    },
    {
      "lhs": "calllist",
      "rhs": [
        "expr"
      ],
      "labels": []
    },
    {
      "lhs": "calllist",
      "rhs": [
        "expr",
        "COMMA",
        "calllist2"
      ],
      "labels": []
    },
    {
      "lhs": "calllist2",
      "rhs": [
        "expr"
      ],
      "labels": []
    },
    {
      "lhs": "calllist2",
      "rhs": [
        "expr",
        "COMMA",
        "calllist2"
      ],
      "labels": []
    },
    {
      "lhs": "cast",
      "rhs": [
        "INT",
        "LP",
        "expr",
        "RP"
      ],
      "labels": [
        "castint"
      ]
    },
    {
      "lhs": "cast",
      "rhs": [
        "DOUBLE",
        "LP",
        "expr",
        "RP"
      ],
      "labels": [
        "castdouble"
      ]
    },
    {
      "lhs": "cast",
      "rhs": [
        "VEC2",
        "LP",
        "expr",
        "COMMA",
        "expr",
        "RP"
      ],
      "labels": [
        "castvec2"
      ]
    },
    {
      "lhs": "cond",
      "rhs": [
        "IF",
        "LP",
        "expr",
        "RP",
        "braceBlock"
      ],
      "labels": [
        "if"
      ]
    },
    {
      "lhs": "cond",
      "rhs": [
        "IF",
        "LP",
        "expr",
        "RP",
        "braceBlock",
        "ELSE",
        "braceBlock"
      ],
      "labels": [
        "ifelse"
      ]
    },
    {
      "lhs": "decl",
      "rhs": [
        "structdecl"
      ],
      "labels": []
    },
    {
      "lhs": "decl",
      "rhs": [
        "vardecl"
      ],
      "labels": []
    },
    {
      "lhs": "decl",
      "rhs": [
        "funcdecl"
      ],
      "labels": []
    },
    {
      "lhs": "expr",
      "rhs": [
        "orexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "factor",
      "rhs": [
        "NUM"
      ],
      "labels": [
        "num"
      ]
    },
    {
      "lhs": "factor",
      "rhs": [
        "FNUM"
      ],
      "labels": [
        "fnum"
      ]
    },
    {
      "lhs": "factor",
      "rhs": [
        "LP",
        "expr",
        "RP"
      ],
      "labels": [
        "expr"
      ]
    },
    {
      "lhs": "factor",
      "rhs": [
        "ID",
        "postfix"
      ],
      "labels": [
        "id"
      ]
    },
    {
      "lhs": "factor",
      "rhs": [
        "STR"
      ],
      "labels": [
        "str"
      ]
    },
    {
      "lhs": "factor",
      "rhs": [
        "cast"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "factor",
      "rhs": [
        "CHAR"
      ],
      "labels": [
        "char"
      ]
    },
    {
      "lhs": "funccall",
      "rhs": [
        "ID",
        "LP",
        "calllist",
        "RP"
      ],
      "labels": [
        "funccall"
      ]
    },
    {
      "lhs": "funcdecl",
      "rhs": [
        "type",
        "ID",
        "LP",
        "paramlist",
        "RP",
        "braceBlock"
      ],
      "labels": [
        "funcdecl"
      ]
    },
    {
      "lhs": "funcdecl",
      "rhs": [
        "VOID",
        "ID",
        "LP",
        "paramlist",
        "RP",
        "braceBlock"
      ],
      "labels": [
        "funcdecl"
      ]
    },
    {
      "lhs": "itemsel",
      "rhs": [
        "LB",
        "expr",
        "RB",
        "itemsel"
      ],
      "labels": [
        "arraysel"
      ]
    },
    {
      "lhs": "itemsel",
      "rhs": [
        "LP",
        "calllist",
        "RP",
        "itemsel"
      ],
      "labels": [
        "fcallsel"
      ]
    },
    {
      "lhs": "itemsel",
      "rhs": [
        "DOT",
        "ID",
        "itemsel"
      ],
      "labels": [
        "membersel"
      ]
    },
    {
      "lhs": "itemsel",
      "rhs": [],
      "labels": []
    },
    {
      "lhs": "mulexp",
      "rhs": [
        "mulexp",
        "STAR",
        "bitexp"
      ],
      "labels": [
        "product"
      ]
    },
    {
      "lhs": "mulexp",
      "rhs": [
        "bitexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "notexp",
      "rhs": [
        "NOT",
        "notexp"
      ],
      "labels": [
        "notexp"
      ]
    },
    {
      "lhs": "notexp",
      "rhs": [
        "relexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "optsize",
      "rhs": [
        "LB",
        "NUM",
        "RB"
      ],
      "labels": [
        "optsize"
      ]
    },
    {
      "lhs": "optsize",
      "rhs": [],
      "labels": []
    },
    {
      "lhs": "orexp",
      "rhs": [
        "orexp",
        "OROR",
        "andexp"
      ],
      "labels": [
        "orexp"
      ]
    },
    {
      "lhs": "orexp",
      "rhs": [
        "andexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "param",
      "rhs": [
        "type",
        "ID",
        "optsize"
      ],
      "labels": [
        "param"
      ]
    },
    {
      "lhs": "paramlist",
      "rhs": [],
      "labels": [
        "noparams"
      ]
    },
    {
      "lhs": "paramlist",
      "rhs": [
        "param"
      ],
      "labels": [
        "oneparam"
      ]
    },
    {
      "lhs": "paramlist",
      "rhs": [
        "param",
        "COMMA",
        "paramlist2"
      ],
      "labels": [
        "manyparams"
      ]
    },
    {
      "lhs": "paramlist2",
      "rhs": [
        "param"
      ],
      "labels": [
        "paramlist2a"
      ]
    },
    {
      "lhs": "paramlist2",
      "rhs": [
        "param",
        "COMMA",
        "paramlist2"
      ],
      "labels": [
        "paramlist2b"
      ]
    },
    {
      "lhs": "postfix",
      "rhs": [
        "LB",
        "expr",
        "RB",
        "postfix"
      ],
      "labels": [
        "array"
      ]
    },
    {
      "lhs": "postfix",
      "rhs": [
        "LP",
        "calllist",
        "RP",
        "postfix"
      ],
      "labels": [
        "fcall"
      ]
    },
    {
      "lhs": "postfix",
      "rhs": [
        "DOT",
        "ID",
        "postfix"
      ],
      "labels": [
        "member"
      ]
    },
    {
      "lhs": "postfix",
      "rhs": [],
      "labels": []
    },
    {
      "lhs": "relexp",
      "rhs": [
        "addexp",
        "RELOP",
        "addexp"
      ],
      "labels": [
        "relexp"
      ]
    },
    {
      "lhs": "relexp",
      "rhs": [
        "addexp"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "return",
      "rhs": [
        "RETURN"
      ],
      "labels": [
        "returnvoid"
      ]
    },
    {
      "lhs": "return",
      "rhs": [
        "RETURN",
        "expr"
      ],
      "labels": [
        "returnexpr"
      ]
    },
    {
      "lhs": "stmt",
      "rhs": [
        "assign",
        "SEMI"
      ],
      "labels": []
    },
    {
      "lhs": "stmt",
      "rhs": [
        "cond"
      ],
      "labels": []
    },
    {
      "lhs": "stmt",
      "rhs": [
        "whileExpr"
      ],
      "labels": []
    },
    {
      "lhs": "stmt",
      "rhs": [
        "funccall",
        "SEMI"
      ],
      "labels": []
    },
    {
      "lhs": "stmt",
      "rhs": [
        "return",
        "SEMI"
      ],
      "labels": []
    },
    {
      "lhs": "stmt",
      "rhs": [
        "braceBlock"
      ],
      "labels": []
    },
    {
      "lhs": "stmts",
      "rhs": [
        "stmt",
        "stmts"
      ],
      "labels": []
    },
    {
      "lhs": "stmts",
      "rhs": [],
      "labels": []
    },
    {
      "lhs": "structdecl",
      "rhs": [
        "STRUCT",
        "ID",
        "LBR",
        "vardecls",
        "RBR"
      ],
      "labels": [
        "structdecl"
      ]
    },
    {
      "lhs": "type",
      "rhs": [
        "INT"
      ],
      "labels": []
    },
    {
      "lhs": "type",
      "rhs": [
        "DOUBLE"
      ],
      "labels": []
    },
    {
      "lhs": "type",
      "rhs": [
        "STRING",
        "LB",
        "NUM",
        "RB"
      ],
      "labels": []
    },
    {
      "lhs": "type",
      "rhs": [
        "STRUCT",
        "ID"
      ],
      "labels": []
    },
    {
      "lhs": "type",
      "rhs": [
        "VEC2"
      ],
      "labels": []
    },
    {
      "lhs": "unaryexp",
      "rhs": [
        "PLUS",
        "unaryexp"
      ],
      "labels": [
        "plus"
      ]
    },
    {
      "lhs": "unaryexp",
      "rhs": [
        "BITNOT",
        "unaryexp"
      ],
      "labels": [
        "bitnot"
      ]
    },
    {
      "lhs": "unaryexp",
      "rhs": [
        "factor"
      ],
      "labels": [
        "copyType"
      ]
    },
    {
      "lhs": "vardecl",
      "rhs": [
        "type",
        "ID",
        "optsize",
        "SEMI"
      ],
      "labels": [
        "vardecl"
      ]
    },
    {
      "lhs": "vardecls",
      "rhs": [
        "vardecl",
        "vardecls"
      ],
      "labels": []
    },
    {
      "lhs": "vardecls",
      "rhs": [],
      "labels": []
    },
    {
      "lhs": "whileExpr",
      "rhs": [
        "WHILE",
        "LP",
        "expr",
        "RP",
        "braceBlock"
      ],
      "labels": [
        "while"
      ]
    }
  ]
}
