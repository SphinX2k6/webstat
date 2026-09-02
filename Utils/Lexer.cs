using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CSharpScript.Utils
{
	// Token: 0x0200469E RID: 18078
	[NullableContext(1)]
	[Nullable(0)]
	public class Lexer
	{
		// Token: 0x0602F106 RID: 192774 RVA: 0x00B26F6B File Offset: 0x00B2516B
		public Lexer(string inputString)
		{
			this.InputString = inputString;
		}

		// Token: 0x0602F107 RID: 192775 RVA: 0x00B26F7C File Offset: 0x00B2517C
		public List<IToken> Tokenize()
		{
			List<IToken> list = new List<IToken>();
			while (this.Position < this.InputString.Length)
			{
				char c = this.InputString[this.Position];
				if (Regex.IsMatch(c.ToString(), "\\d"))
				{
					list.Add(this.ReadNumber());
				}
				else if (Regex.IsMatch(c.ToString(), "[a-zA-Z]"))
				{
					list.Add(this.ReadIdentifier());
				}
				else if (Regex.IsMatch(c.ToString(), "['`\"]"))
				{
					list.Add(this.ReadString());
				}
				else if (Regex.IsMatch(c.ToString(), "[\\+\\-\\*\\/\\%\\>\\<\\=\\!\\&\\|]"))
				{
					list.Add(this.ReadOperator());
				}
				else if (c == ',')
				{
					list.Add(new Token
					{
						TokenType = ETokenType.Comma,
						TokenString = ","
					});
					this.Position++;
				}
				else if (c == '(')
				{
					list.Add(new Token
					{
						TokenType = ETokenType.LParen,
						TokenString = "("
					});
					this.Position++;
				}
				else if (c == ')')
				{
					list.Add(new Token
					{
						TokenType = ETokenType.RParen,
						TokenString = ")"
					});
					this.Position++;
				}
				else if (c == '[')
				{
					list.Add(new Token
					{
						TokenType = ETokenType.LBracket,
						TokenString = "["
					});
					this.Position++;
				}
				else if (c == ']')
				{
					list.Add(new Token
					{
						TokenType = ETokenType.RBracket,
						TokenString = "]"
					});
					this.Position++;
				}
				else
				{
					if (!Regex.IsMatch(c.ToString(), "\\s"))
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Invalid character: ");
						defaultInterpolatedStringHandler.AppendFormatted<char>(c);
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					this.Position++;
				}
			}
			list.Add(new Token
			{
				TokenType = ETokenType.EndOfInput,
				TokenString = ""
			});
			return list;
		}

		// Token: 0x0602F108 RID: 192776 RVA: 0x00B271C0 File Offset: 0x00B253C0
		private IToken ReadNumber()
		{
			string text = "";
			while (this.Position < this.InputString.Length)
			{
				char c = this.InputString[this.Position];
				if (!Regex.IsMatch(c.ToString(), "\\d"))
				{
					break;
				}
				ReadOnlySpan<char> str = text;
				c = this.InputString[this.Position];
				text = str + new ReadOnlySpan<char>(ref c);
				this.Position++;
			}
			if (this.Position < this.InputString.Length && this.InputString[this.Position] == '.')
			{
				text += ".";
				this.Position++;
				while (this.Position < this.InputString.Length)
				{
					char c = this.InputString[this.Position];
					if (!Regex.IsMatch(c.ToString(), "\\d"))
					{
						break;
					}
					ReadOnlySpan<char> str2 = text;
					c = this.InputString[this.Position];
					text = str2 + new ReadOnlySpan<char>(ref c);
					this.Position++;
				}
			}
			return new Token
			{
				TokenType = ETokenType.Number,
				TokenString = text
			};
		}

		// Token: 0x0602F109 RID: 192777 RVA: 0x00B27308 File Offset: 0x00B25508
		private IToken ReadIdentifier()
		{
			string text = "";
			while (this.Position < this.InputString.Length)
			{
				char c = this.InputString[this.Position];
				if (!Regex.IsMatch(c.ToString(), "[a-zA-Z0-9]"))
				{
					break;
				}
				ReadOnlySpan<char> str = text;
				string inputString = this.InputString;
				int position = this.Position;
				this.Position = position + 1;
				c = inputString[position];
				text = str + new ReadOnlySpan<char>(ref c);
			}
			if (text == "TRUE" || text == "FALSE")
			{
				return new Token
				{
					TokenType = ETokenType.Boolean,
					TokenString = text.ToLower()
				};
			}
			if (text == "AND")
			{
				return new Token
				{
					TokenType = ETokenType.Operator,
					TokenString = "&&"
				};
			}
			if (text == "OR")
			{
				return new Token
				{
					TokenType = ETokenType.Operator,
					TokenString = "||"
				};
			}
			if (text == "XOR")
			{
				return new Token
				{
					TokenType = ETokenType.Operator,
					TokenString = "!="
				};
			}
			if (text == "NOT")
			{
				return new Token
				{
					TokenType = ETokenType.Operator,
					TokenString = "!"
				};
			}
			return new Token
			{
				TokenType = ETokenType.Identifier,
				TokenString = text
			};
		}

		// Token: 0x0602F10A RID: 192778 RVA: 0x00B27460 File Offset: 0x00B25660
		private IToken ReadString()
		{
			string inputString = this.InputString;
			int position = this.Position;
			this.Position = position + 1;
			char c = inputString[position];
			string text = "";
			while (this.Position < this.InputString.Length)
			{
				string inputString2 = this.InputString;
				position = this.Position;
				this.Position = position + 1;
				char c2 = inputString2[position];
				if (c2 == c)
				{
					return new Token
					{
						TokenType = ETokenType.String,
						TokenString = text
					};
				}
				ReadOnlySpan<char> str = text;
				char c3 = c2;
				text = str + new ReadOnlySpan<char>(ref c3);
			}
			throw new Exception("Invalid string: " + text);
		}

		// Token: 0x0602F10B RID: 192779 RVA: 0x00B27500 File Offset: 0x00B25700
		private IToken ReadOperator()
		{
			string text = "";
			while (this.Position < this.InputString.Length)
			{
				char c = this.InputString[this.Position];
				if (!Regex.IsMatch(c.ToString(), "[\\+\\-\\*\\/\\%\\>\\<\\=\\!\\&\\|]"))
				{
					break;
				}
				ReadOnlySpan<char> str = text;
				c = this.InputString[this.Position];
				text = str + new ReadOnlySpan<char>(ref c);
				this.Position++;
			}
			return new Token
			{
				TokenType = ETokenType.Operator,
				TokenString = text
			};
		}

		// Token: 0x0401AD05 RID: 109829
		private int Position;

		// Token: 0x0401AD06 RID: 109830
		private readonly string InputString;
	}
}
