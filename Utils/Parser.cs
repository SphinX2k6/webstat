using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046AB RID: 18091
	[NullableContext(1)]
	[Nullable(0)]
	public class Parser
	{
		// Token: 0x0602F13C RID: 192828 RVA: 0x00B27593 File Offset: 0x00B25793
		public Parser(List<IToken> tokens)
		{
			this.Tokens = tokens;
		}

		// Token: 0x0602F13D RID: 192829 RVA: 0x00B275AD File Offset: 0x00B257AD
		public IAstNode Parse(string formula)
		{
			this.Formula = formula;
			IAstNode result = this.ParseExpression();
			if (this.Position != this.Tokens.Count - 1)
			{
				throw new Exception("Unexpected token when parsing expression " + formula);
			}
			return result;
		}

		// Token: 0x0602F13E RID: 192830 RVA: 0x00B275E2 File Offset: 0x00B257E2
		private IAstNode ParseExpression()
		{
			return this.ParseLogicalOr();
		}

		// Token: 0x0602F13F RID: 192831 RVA: 0x00B275EC File Offset: 0x00B257EC
		private IAstNode ParseLogicalOr()
		{
			IAstNode astNode = this.ParseLogicalAnd();
			while (this.MatchOperator(new string[]
			{
				"||"
			}))
			{
				string tokenString = this.PreviousToken().TokenString;
				IAstNode astNode2 = this.ParseLogicalAnd();
				astNode = new BinaryOperatorNode
				{
					NodeType = EAstNodeType.BinaryOperator,
					Operator = tokenString,
					Args = new IAstNode[]
					{
						astNode,
						astNode2
					}
				};
			}
			return astNode;
		}

		// Token: 0x0602F140 RID: 192832 RVA: 0x00B27658 File Offset: 0x00B25858
		private IAstNode ParseLogicalAnd()
		{
			IAstNode astNode = this.ParseEquality();
			while (this.MatchOperator(new string[]
			{
				"&&"
			}))
			{
				string tokenString = this.PreviousToken().TokenString;
				IAstNode astNode2 = this.ParseEquality();
				astNode = new BinaryOperatorNode
				{
					NodeType = EAstNodeType.BinaryOperator,
					Operator = tokenString,
					Args = new IAstNode[]
					{
						astNode,
						astNode2
					}
				};
			}
			return astNode;
		}

		// Token: 0x0602F141 RID: 192833 RVA: 0x00B276C4 File Offset: 0x00B258C4
		private IAstNode ParseEquality()
		{
			IAstNode astNode = this.ParseComparison();
			while (this.MatchOperator(new string[]
			{
				"==",
				"!="
			}))
			{
				string tokenString = this.PreviousToken().TokenString;
				IAstNode astNode2 = this.ParseComparison();
				astNode = new BinaryOperatorNode
				{
					NodeType = EAstNodeType.BinaryOperator,
					Operator = tokenString,
					Args = new IAstNode[]
					{
						astNode,
						astNode2
					}
				};
			}
			return astNode;
		}

		// Token: 0x0602F142 RID: 192834 RVA: 0x00B27738 File Offset: 0x00B25938
		private IAstNode ParseComparison()
		{
			IAstNode astNode = this.ParseAddition();
			while (this.MatchOperator(new string[]
			{
				">",
				">=",
				"<",
				"<="
			}))
			{
				string tokenString = this.PreviousToken().TokenString;
				IAstNode astNode2 = this.ParseAddition();
				astNode = new BinaryOperatorNode
				{
					NodeType = EAstNodeType.BinaryOperator,
					Operator = tokenString,
					Args = new IAstNode[]
					{
						astNode,
						astNode2
					}
				};
			}
			return astNode;
		}

		// Token: 0x0602F143 RID: 192835 RVA: 0x00B277BC File Offset: 0x00B259BC
		private IAstNode ParseAddition()
		{
			IAstNode astNode = this.ParseMultiplication();
			while (this.MatchOperator(new string[]
			{
				"+",
				"-"
			}))
			{
				string tokenString = this.PreviousToken().TokenString;
				IAstNode astNode2 = this.ParseMultiplication();
				astNode = new BinaryOperatorNode
				{
					NodeType = EAstNodeType.BinaryOperator,
					Operator = tokenString,
					Args = new IAstNode[]
					{
						astNode,
						astNode2
					}
				};
			}
			return astNode;
		}

		// Token: 0x0602F144 RID: 192836 RVA: 0x00B27830 File Offset: 0x00B25A30
		private IAstNode ParseMultiplication()
		{
			IAstNode astNode = this.ParseUnary();
			while (this.MatchOperator(new string[]
			{
				"*",
				"/",
				"%"
			}))
			{
				string tokenString = this.PreviousToken().TokenString;
				IAstNode astNode2 = this.ParseUnary();
				astNode = new BinaryOperatorNode
				{
					NodeType = EAstNodeType.BinaryOperator,
					Operator = tokenString,
					Args = new IAstNode[]
					{
						astNode,
						astNode2
					}
				};
			}
			return astNode;
		}

		// Token: 0x0602F145 RID: 192837 RVA: 0x00B278AC File Offset: 0x00B25AAC
		private IAstNode ParseUnary()
		{
			if (this.MatchOperator(new string[]
			{
				"+",
				"-",
				"!"
			}))
			{
				string tokenString = this.PreviousToken().TokenString;
				IAstNode astNode = this.ParseUnary();
				return new UnaryOperatorNode
				{
					NodeType = EAstNodeType.UnaryOperator,
					Operator = tokenString,
					Args = new IAstNode[]
					{
						astNode
					}
				};
			}
			return this.ParsePrimary();
		}

		// Token: 0x0602F146 RID: 192838 RVA: 0x00B27920 File Offset: 0x00B25B20
		private IAstNode ParsePrimary()
		{
			IToken token = this.CurrentToken();
			if (token.TokenType == ETokenType.Number)
			{
				this.Advance();
				return new NumberNode
				{
					NodeType = EAstNodeType.Number,
					Value = TFormulaValue.FromDouble(double.Parse(token.TokenString))
				};
			}
			if (token.TokenType == ETokenType.Boolean)
			{
				this.Advance();
				return new BooleanNode
				{
					NodeType = EAstNodeType.Boolean,
					Value = (token.TokenString == "true")
				};
			}
			if (token.TokenType == ETokenType.String)
			{
				this.Advance();
				return new StringNode
				{
					NodeType = EAstNodeType.String,
					Value = token.TokenString
				};
			}
			if (token.TokenType == ETokenType.Identifier)
			{
				string tokenString = token.TokenString;
				this.Advance();
				if (this.Match(new ETokenType[]
				{
					ETokenType.LParen
				}))
				{
					return this.ParseFunctionCall(tokenString);
				}
				IAstNode astNode = new IdentifierNode
				{
					NodeType = EAstNodeType.Identifier,
					Value = tokenString
				};
				while (this.Match(new ETokenType[]
				{
					ETokenType.LBracket
				}))
				{
					IAstNode index = this.ParseExpression();
					this.Consume(ETokenType.RBracket, "Expected ']' after array when parsing expression " + this.Formula);
					astNode = new IndexNode
					{
						NodeType = EAstNodeType.Index,
						Value = astNode,
						Index = index
					};
				}
				return astNode;
			}
			else
			{
				if (this.Match(new ETokenType[]
				{
					ETokenType.LParen
				}))
				{
					IAstNode value = this.ParseExpression();
					this.Consume(ETokenType.RParen, "Expected ')' after expression when parsing " + this.Formula);
					return new ParenthesizedExpressionNode
					{
						NodeType = EAstNodeType.ParenthesizedExpression,
						Value = value
					};
				}
				if (this.Match(new ETokenType[]
				{
					ETokenType.LBracket
				}))
				{
					return this.ParseArray();
				}
				throw new Exception(token.TokenString + " when parsing expression " + this.Formula);
			}
		}

		// Token: 0x0602F147 RID: 192839 RVA: 0x00B27AD8 File Offset: 0x00B25CD8
		private IAstNode ParseFunctionCall(string name)
		{
			List<IAstNode> list = new List<IAstNode>();
			if (!this.Check(ETokenType.RParen))
			{
				do
				{
					list.Add(this.ParseExpression());
				}
				while (this.Match(new ETokenType[]
				{
					ETokenType.Comma
				}));
			}
			this.Consume(ETokenType.RParen, "Expected ')' after arguments when parsing expression " + this.Formula);
			return new FunctionCallNode
			{
				NodeType = EAstNodeType.FunctionCall,
				Value = name,
				Args = list.ToArray()
			};
		}

		// Token: 0x0602F148 RID: 192840 RVA: 0x00B27B48 File Offset: 0x00B25D48
		private IAstNode ParseArray()
		{
			List<IAstNode> list = new List<IAstNode>();
			if (!this.Check(ETokenType.RBracket))
			{
				do
				{
					list.Add(this.ParseExpression());
				}
				while (this.Match(new ETokenType[]
				{
					ETokenType.Comma
				}));
			}
			this.Consume(ETokenType.RBracket, "Expected ']' after array when parsing expression " + this.Formula);
			IAstNode astNode = new ArrayNode
			{
				NodeType = EAstNodeType.Array,
				Value = list.ToArray()
			};
			while (this.Match(new ETokenType[]
			{
				ETokenType.LBracket
			}))
			{
				IAstNode index = this.ParseExpression();
				this.Consume(ETokenType.RBracket, "Expected ']' after array when parsing expression " + this.Formula);
				astNode = new IndexNode
				{
					NodeType = EAstNodeType.Index,
					Value = astNode,
					Index = index
				};
			}
			return astNode;
		}

		// Token: 0x0602F149 RID: 192841 RVA: 0x00B27C04 File Offset: 0x00B25E04
		private bool Match(params ETokenType[] types)
		{
			foreach (ETokenType type in types)
			{
				if (this.Check(type))
				{
					this.Advance();
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602F14A RID: 192842 RVA: 0x00B27C38 File Offset: 0x00B25E38
		private bool MatchOperator(params string[] operators)
		{
			foreach (string b in operators)
			{
				if (this.Check(ETokenType.Operator) && this.CurrentToken().TokenString == b)
				{
					this.Advance();
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602F14B RID: 192843 RVA: 0x00B27C7F File Offset: 0x00B25E7F
		private void Consume(ETokenType type, string message)
		{
			if (this.Check(type))
			{
				this.Advance();
				return;
			}
			throw new Exception(message);
		}

		// Token: 0x0602F14C RID: 192844 RVA: 0x00B27C98 File Offset: 0x00B25E98
		private bool Check(ETokenType type)
		{
			return !this.IsAtEnd() && this.CurrentToken().TokenType == type;
		}

		// Token: 0x0602F14D RID: 192845 RVA: 0x00B27CB2 File Offset: 0x00B25EB2
		private IToken Advance()
		{
			if (!this.IsAtEnd())
			{
				this.Position++;
			}
			return this.PreviousToken();
		}

		// Token: 0x0602F14E RID: 192846 RVA: 0x00B27CD0 File Offset: 0x00B25ED0
		private bool IsAtEnd()
		{
			return this.CurrentToken().TokenType == ETokenType.EndOfInput;
		}

		// Token: 0x0602F14F RID: 192847 RVA: 0x00B27CE1 File Offset: 0x00B25EE1
		private IToken CurrentToken()
		{
			return this.Tokens[this.Position];
		}

		// Token: 0x0602F150 RID: 192848 RVA: 0x00B27CF4 File Offset: 0x00B25EF4
		private IToken PreviousToken()
		{
			return this.Tokens[this.Position - 1];
		}

		// Token: 0x0401AD12 RID: 109842
		private string Formula = "";

		// Token: 0x0401AD13 RID: 109843
		private int Position;

		// Token: 0x0401AD14 RID: 109844
		private readonly List<IToken> Tokens;
	}
}
