using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003136 RID: 12598
[NullableContext(1)]
[Nullable(0)]
public class Parser
{
	// Token: 0x0601A15D RID: 106845 RVA: 0x007A6C5C File Offset: 0x007A4E5C
	public Parser(string expression)
	{
		this.Expression = expression;
		this.Tokenize();
	}

	// Token: 0x0601A15E RID: 106846 RVA: 0x007A6C7C File Offset: 0x007A4E7C
	public void Tokenize()
	{
		string text = "";
		for (int i = 0; i < this.Expression.Length; i++)
		{
			char c = this.Expression[i];
			if (c != ' ')
			{
				if ("|&!".Contains(c))
				{
					if (text != "")
					{
						this.Tokens.Add(new IToken
						{
							Type = "number",
							Value = text
						});
						text = "";
					}
					if (i + 1 < this.Expression.Length && this.Expression[i + 1] == c)
					{
						List<IToken> tokens = this.Tokens;
						IToken token = new IToken();
						token.Type = "operator";
						char c2 = c;
						ReadOnlySpan<char> str = new ReadOnlySpan<char>(ref c2);
						char c3 = c;
						token.Value = str + new ReadOnlySpan<char>(ref c3);
						tokens.Add(token);
						i++;
					}
					else
					{
						this.Tokens.Add(new IToken
						{
							Type = "operator",
							Value = c.ToString()
						});
					}
				}
				else if ("()".Contains(c))
				{
					if (text != "")
					{
						this.Tokens.Add(new IToken
						{
							Type = "number",
							Value = text
						});
						text = "";
					}
					this.Tokens.Add(new IToken
					{
						Type = "parenthesis",
						Value = c.ToString()
					});
				}
				else
				{
					ReadOnlySpan<char> str2 = text;
					char c3 = c;
					text = str2 + new ReadOnlySpan<char>(ref c3);
				}
			}
		}
		if (text != "")
		{
			this.Tokens.Add(new IToken
			{
				Type = "number",
				Value = text
			});
		}
	}

	// Token: 0x0601A15F RID: 106847 RVA: 0x007A6E46 File Offset: 0x007A5046
	public ILogicalStructure Parse()
	{
		if (this.Tokens.Count == 0)
		{
			throw new Exception("No tokens to parse");
		}
		ILogicalStructure result = this.ParseExpression();
		if (this.Index != this.Tokens.Count)
		{
			throw new Exception("Unexpected tokens after parsing");
		}
		return result;
	}

	// Token: 0x0601A160 RID: 106848 RVA: 0x007A6E84 File Offset: 0x007A5084
	private ILogicalStructure ParseExpression()
	{
		return this.ParseOr();
	}

	// Token: 0x0601A161 RID: 106849 RVA: 0x007A6E8C File Offset: 0x007A508C
	private ILogicalStructure ParseOr()
	{
		ILogicalStructure logicalStructure = this.ParseAnd();
		while (this.Index < this.Tokens.Count && this.Tokens[this.Index].Value == "||")
		{
			this.Index++;
			logicalStructure = new ILogicalStructure
			{
				Or = new ILogicalStructure[]
				{
					logicalStructure,
					this.ParseAnd()
				}
			};
		}
		return logicalStructure;
	}

	// Token: 0x0601A162 RID: 106850 RVA: 0x007A6F08 File Offset: 0x007A5108
	private ILogicalStructure ParseAnd()
	{
		ILogicalStructure logicalStructure = this.ParseNot();
		while (this.Index < this.Tokens.Count && this.Tokens[this.Index].Value == "&&")
		{
			this.Index++;
			logicalStructure = new ILogicalStructure
			{
				And = new ILogicalStructure[]
				{
					logicalStructure,
					this.ParseNot()
				}
			};
		}
		return logicalStructure;
	}

	// Token: 0x0601A163 RID: 106851 RVA: 0x007A6F84 File Offset: 0x007A5184
	private ILogicalStructure ParseNot()
	{
		if (this.Index < this.Tokens.Count && this.Tokens[this.Index].Value == "!")
		{
			this.Index++;
			return new ILogicalStructure
			{
				Not = this.ParseNot()
			};
		}
		return this.ParseFactor();
	}

	// Token: 0x0601A164 RID: 106852 RVA: 0x007A6FEC File Offset: 0x007A51EC
	private ILogicalStructure ParseFactor()
	{
		if (this.Index >= this.Tokens.Count)
		{
			throw new Exception("Unexpected end of input");
		}
		if (this.Tokens[this.Index].Value == "(")
		{
			this.Index++;
			ILogicalStructure result = this.ParseExpression();
			if (this.Index >= this.Tokens.Count || this.Tokens[this.Index].Value != ")")
			{
				throw new Exception("Missing closing parenthesis");
			}
			this.Index++;
			return result;
		}
		else
		{
			IToken token = this.Tokens[this.Index];
			if (token.Type == "number")
			{
				this.Index++;
				return new ILogicalStructure
				{
					Index = new int?(int.Parse(token.Value))
				};
			}
			throw new Exception("Unexpected token type");
		}
	}

	// Token: 0x0400D150 RID: 53584
	private readonly List<IToken> Tokens = new List<IToken>();

	// Token: 0x0400D151 RID: 53585
	private int Index;

	// Token: 0x0400D152 RID: 53586
	private readonly string Expression;
}
