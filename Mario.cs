
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_MINUSMINUS           =  4, // '--'
        SYMBOL_EXCLAMEQ             =  5, // '!='
        SYMBOL_PERCENT              =  6, // '%'
        SYMBOL_LPAREN               =  7, // '('
        SYMBOL_RPAREN               =  8, // ')'
        SYMBOL_TIMES                =  9, // '*'
        SYMBOL_TIMESTIMES           = 10, // '**'
        SYMBOL_TIMESTIMESTIMES      = 11, // '***'
        SYMBOL_TIMESTIMESTIMESTIMES = 12, // '****'
        SYMBOL_DIV                  = 13, // '/'
        SYMBOL_DIVDIV               = 14, // '//'
        SYMBOL_COLON                = 15, // ':'
        SYMBOL_SEMI                 = 16, // ';'
        SYMBOL_PLUS                 = 17, // '+'
        SYMBOL_PLUSPLUS             = 18, // '++'
        SYMBOL_LT                   = 19, // '<'
        SYMBOL_LTEQ                 = 20, // '<='
        SYMBOL_EQ                   = 21, // '='
        SYMBOL_EQEQ                 = 22, // '=='
        SYMBOL_GT                   = 23, // '>'
        SYMBOL_GTEQ                 = 24, // '>='
        SYMBOL_AND                  = 25, // and
        SYMBOL_CASE                 = 26, // case
        SYMBOL_DEFAULT              = 27, // default
        SYMBOL_DIGIT                = 28, // digit
        SYMBOL_DO                   = 29, // do
        SYMBOL_DOUBLE               = 30, // double
        SYMBOL_ELSE                 = 31, // else
        SYMBOL_FLOAT                = 32, // float
        SYMBOL_FOR                  = 33, // for
        SYMBOL_ID                   = 34, // id
        SYMBOL_IF                   = 35, // if
        SYMBOL_INT                  = 36, // int
        SYMBOL_NOT                  = 37, // not
        SYMBOL_OR                   = 38, // or
        SYMBOL_STRING               = 39, // string
        SYMBOL_SWITCH               = 40, // switch
        SYMBOL_WHILE                = 41, // while
        SYMBOL_ASSIGN               = 42, // <assign>
        SYMBOL_CONCEPT              = 43, // <concept>
        SYMBOL_COND                 = 44, // <cond>
        SYMBOL_COND_LIST            = 45, // <cond_list>
        SYMBOL_DATA                 = 46, // <data>
        SYMBOL_DIGIT2               = 47, // <digit>
        SYMBOL_DO_WHILE_STAT        = 48, // <do_while_stat>
        SYMBOL_EXP                  = 49, // <exp>
        SYMBOL_EXPR                 = 50, // <expr>
        SYMBOL_F                    = 51, // <f>
        SYMBOL_FOR_STAT             = 52, // <for_stat>
        SYMBOL_FOR_STEP             = 53, // <for_step>
        SYMBOL_ID2                  = 54, // <id>
        SYMBOL_IF_STAT              = 55, // <if_stat>
        SYMBOL_LOGICAL_OP           = 56, // <logical_op>
        SYMBOL_OP                   = 57, // <op>
        SYMBOL_PROGRAM              = 58, // <program>
        SYMBOL_STAT_LIST            = 59, // <stat_list>
        SYMBOL_STEP_OP              = 60, // <step_op>
        SYMBOL_SWITCH_CASE          = 61, // <switch_case>
        SYMBOL_SWITCH_STAT          = 62, // <switch_stat>
        SYMBOL_TERM                 = 63, // <term>
        SYMBOL_WHILE_STAT           = 64  // <while_stat>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_TIMESTIMESTIMESTIMES_TIMESTIMESTIMESTIMES                                                         =  0, // <program> ::= '****' <stat_list> '****'
        RULE_STAT_LIST                                                                                                 =  1, // <stat_list> ::= <concept>
        RULE_STAT_LIST2                                                                                                =  2, // <stat_list> ::= <concept> <stat_list>
        RULE_CONCEPT                                                                                                   =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                                                                                  =  4, // <concept> ::= <if_stat>
        RULE_CONCEPT3                                                                                                  =  5, // <concept> ::= <for_stat>
        RULE_CONCEPT4                                                                                                  =  6, // <concept> ::= <while_stat>
        RULE_CONCEPT5                                                                                                  =  7, // <concept> ::= <switch_stat>
        RULE_ASSIGN_EQ_SEMI                                                                                            =  8, // <assign> ::= <data> <id> '=' <expr> ';'
        RULE_DATA_INT                                                                                                  =  9, // <data> ::= int
        RULE_DATA_FLOAT                                                                                                = 10, // <data> ::= float
        RULE_DATA_DOUBLE                                                                                               = 11, // <data> ::= double
        RULE_DATA_STRING                                                                                               = 12, // <data> ::= string
        RULE_ID_ID                                                                                                     = 13, // <id> ::= id
        RULE_EXPR_PLUS                                                                                                 = 14, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                                                                                = 15, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                                                                      = 16, // <expr> ::= <term>
        RULE_TERM_TIMES                                                                                                = 17, // <term> ::= <term> '*' <f>
        RULE_TERM_DIV                                                                                                  = 18, // <term> ::= <term> '/' <f>
        RULE_TERM_PERCENT                                                                                              = 19, // <term> ::= <term> '%' <f>
        RULE_TERM_DIVDIV                                                                                               = 20, // <term> ::= <term> '//' <f>
        RULE_TERM                                                                                                      = 21, // <term> ::= <f>
        RULE_F_TIMESTIMES                                                                                              = 22, // <f> ::= <f> '**' <exp>
        RULE_F                                                                                                         = 23, // <f> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                                                                         = 24, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                                                                       = 25, // <exp> ::= <id>
        RULE_EXP2                                                                                                      = 26, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                                                                               = 27, // <digit> ::= digit
        RULE_IF_STAT_IF_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES                                            = 28, // <if_stat> ::= if '(' <cond_list> ')' ':' '***' <stat_list> '***'
        RULE_IF_STAT_IF_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES_ELSE_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES = 29, // <if_stat> ::= if '(' <cond_list> ')' ':' '***' <stat_list> '***' else ':' '***' <stat_list> '***'
        RULE_COND_LIST                                                                                                 = 30, // <cond_list> ::= <cond>
        RULE_COND_LIST2                                                                                                = 31, // <cond_list> ::= <cond> <logical_op> <cond_list>
        RULE_COND                                                                                                      = 32, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                                                                                     = 33, // <op> ::= '<'
        RULE_OP_GT                                                                                                     = 34, // <op> ::= '>'
        RULE_OP_LTEQ                                                                                                   = 35, // <op> ::= '<='
        RULE_OP_GTEQ                                                                                                   = 36, // <op> ::= '>='
        RULE_OP_EQEQ                                                                                                   = 37, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                                                                               = 38, // <op> ::= '!='
        RULE_LOGICAL_OP_AND                                                                                            = 39, // <logical_op> ::= and
        RULE_LOGICAL_OP_OR                                                                                             = 40, // <logical_op> ::= or
        RULE_LOGICAL_OP_NOT                                                                                            = 41, // <logical_op> ::= not
        RULE_FOR_STAT_FOR_LPAREN_SEMI_SEMI_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES                                = 42, // <for_stat> ::= for '(' <assign> ';' <cond> ';' <for_step> ')' ':' '***' <stat_list> '***'
        RULE_FOR_STEP                                                                                                  = 43, // <for_step> ::= <id> <step_op> <expr>
        RULE_STEP_OP_PLUSPLUS                                                                                          = 44, // <step_op> ::= '++'
        RULE_STEP_OP_MINUSMINUS                                                                                        = 45, // <step_op> ::= '--'
        RULE_WHILE_STAT_WHILE_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES                                      = 46, // <while_stat> ::= while '(' <cond> ')' ':' '***' <stat_list> '***'
        RULE_DO_WHILE_STAT_DO_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES_WHILE_LPAREN_RPAREN_SEMI                           = 47, // <do_while_stat> ::= do ':' '***' <stat_list> '***' while '(' <cond> ')' ';'
        RULE_SWITCH_STAT_SWITCH_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_DEFAULT_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES      = 48, // <switch_stat> ::= switch '(' <expr> ')' ':' '***' <switch_case> default ':' '***' <stat_list> '***'
        RULE_SWITCH_CASE_CASE_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES                                                    = 49  // <switch_case> ::= case <expr> ':' '***' <stat_list> '***'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMESTIMES :
                //'***'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMESTIMESTIMES :
                //'****'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVDIV :
                //'//'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //and
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //not
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND_LIST :
                //<cond_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE_STAT :
                //<do_while_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_F :
                //<f>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STAT :
                //<for_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STEP :
                //<for_step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STAT :
                //<if_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICAL_OP :
                //<logical_op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STAT_LIST :
                //<stat_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP_OP :
                //<step_op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_CASE :
                //<switch_case>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STAT :
                //<switch_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STAT :
                //<while_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_TIMESTIMESTIMESTIMES_TIMESTIMESTIMESTIMES :
                //<program> ::= '****' <stat_list> '****'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST :
                //<stat_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST2 :
                //<stat_list> ::= <concept> <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <while_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <switch_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI :
                //<assign> ::= <data> <id> '=' <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <f>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <f>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <f>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIVDIV :
                //<term> ::= <term> '//' <f>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <f>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_F_TIMESTIMES :
                //<f> ::= <f> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_F :
                //<f> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STAT_IF_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES :
                //<if_stat> ::= if '(' <cond_list> ')' ':' '***' <stat_list> '***'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STAT_IF_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES_ELSE_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES :
                //<if_stat> ::= if '(' <cond_list> ')' ':' '***' <stat_list> '***' else ':' '***' <stat_list> '***'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_LIST :
                //<cond_list> ::= <cond>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_LIST2 :
                //<cond_list> ::= <cond> <logical_op> <cond_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_OP_AND :
                //<logical_op> ::= and
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_OP_OR :
                //<logical_op> ::= or
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_OP_NOT :
                //<logical_op> ::= not
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STAT_FOR_LPAREN_SEMI_SEMI_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES :
                //<for_stat> ::= for '(' <assign> ';' <cond> ';' <for_step> ')' ':' '***' <stat_list> '***'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STEP :
                //<for_step> ::= <id> <step_op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_OP_PLUSPLUS :
                //<step_op> ::= '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_OP_MINUSMINUS :
                //<step_op> ::= '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STAT_WHILE_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES :
                //<while_stat> ::= while '(' <cond> ')' ':' '***' <stat_list> '***'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_STAT_DO_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES_WHILE_LPAREN_RPAREN_SEMI :
                //<do_while_stat> ::= do ':' '***' <stat_list> '***' while '(' <cond> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STAT_SWITCH_LPAREN_RPAREN_COLON_TIMESTIMESTIMES_DEFAULT_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES :
                //<switch_stat> ::= switch '(' <expr> ')' ':' '***' <switch_case> default ':' '***' <stat_list> '***'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_CASE_CASE_COLON_TIMESTIMESTIMES_TIMESTIMESTIMES :
                //<switch_case> ::= case <expr> ':' '***' <stat_list> '***'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
