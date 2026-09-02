using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CSharpScript.Utils
{
	// Token: 0x020046B9 RID: 18105
	[NullableContext(1)]
	[Nullable(0)]
	public class Formula
	{
		// Token: 0x170080F4 RID: 33012
		// (get) Token: 0x0602F19A RID: 192922 RVA: 0x00B28190 File Offset: 0x00B26390
		public string FormulaStr
		{
			get
			{
				return this.FormulaRaw;
			}
		}

		// Token: 0x0602F19B RID: 192923 RVA: 0x00B28198 File Offset: 0x00B26398
		public Formula(string formula)
		{
			this.FormulaRaw = formula;
			this.Ast = FormulaCacheManager.Acquire(formula);
			this.Params = null;
			this.ParamsCacheKey = null;
		}

		// Token: 0x0602F19C RID: 192924 RVA: 0x00B28203 File Offset: 0x00B26403
		public void Dispose()
		{
			if (!this.IsDisposed)
			{
				FormulaCacheManager.Release(this.FormulaRaw);
				if (!string.IsNullOrEmpty(this.ParamsCacheKey))
				{
					FormulaParamsCacheManager.Release(this.ParamsCacheKey);
					this.ParamsCacheKey = null;
				}
				this.IsDisposed = true;
			}
		}

		// Token: 0x0602F19D RID: 192925 RVA: 0x00B28240 File Offset: 0x00B26440
		public Formula SetBuiltinFunctions(Dictionary<string, Func<TFormulaValue[], TFormulaValue>> functions)
		{
			this.BuiltinFuncs.Clear();
			foreach (KeyValuePair<string, Func<TFormulaValue[], TFormulaValue>> keyValuePair in functions)
			{
				this.BuiltinFuncs[keyValuePair.Key] = keyValuePair.Value;
			}
			return this;
		}

		// Token: 0x0602F19E RID: 192926 RVA: 0x00B282AC File Offset: 0x00B264AC
		public Formula SetContextBuiltinFunctions(Dictionary<string, Func<TFormulaValue[], TFormulaValue>> functions)
		{
			foreach (KeyValuePair<string, Func<TFormulaValue[], TFormulaValue>> keyValuePair in functions)
			{
				this.BuiltinFuncs[keyValuePair.Key] = keyValuePair.Value;
				this.contextDependentFunction.Add(keyValuePair.Key);
			}
			return this;
		}

		// Token: 0x0602F19F RID: 192927 RVA: 0x00B28320 File Offset: 0x00B26520
		public Formula AddBuiltinFunction(string name, Func<TFormulaValue[], TFormulaValue> func)
		{
			this.BuiltinFuncs[name] = func;
			return this;
		}

		// Token: 0x0602F1A0 RID: 192928 RVA: 0x00B28330 File Offset: 0x00B26530
		public Formula SetDefaultParams(Dictionary<string, TFormulaValue> @params)
		{
			this.Params = new Dictionary<string, TFormulaValue>(@params);
			return this;
		}

		// Token: 0x0602F1A1 RID: 192929 RVA: 0x00B28340 File Offset: 0x00B26540
		public Formula SetDefaultParams([Nullable(2)] string @params)
		{
			if (this.Params != null || this.ParamsCacheKey != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "Formula重复设置默认参数";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("formula", this.FormulaRaw);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return this;
			}
			if (string.IsNullOrEmpty(@params))
			{
				this.Params = new Dictionary<string, TFormulaValue>();
				return this;
			}
			this.ParamsCacheKey = @params;
			this.Params = new Dictionary<string, TFormulaValue>(FormulaParamsCacheManager.Acquire(@params));
			return this;
		}

		// Token: 0x0602F1A2 RID: 192930 RVA: 0x00B283B9 File Offset: 0x00B265B9
		public Formula SetDefaultParam(string key, TFormulaValue value)
		{
			if (this.Params == null)
			{
				this.Params = new Dictionary<string, TFormulaValue>();
			}
			this.Params[key] = value;
			return this;
		}

		// Token: 0x0602F1A3 RID: 192931 RVA: 0x00B283DC File Offset: 0x00B265DC
		internal static TFormulaValue FromJsonElement(JsonElement json)
		{
			switch (json.ValueKind)
			{
			case JsonValueKind.Array:
			{
				List<TFormulaValue> list = new List<TFormulaValue>();
				foreach (JsonElement json2 in json.EnumerateArray())
				{
					list.Add(Formula.FromJsonElement(json2));
				}
				double[] array = new double[list.Count];
				bool flag = true;
				for (int i = 0; i < list.Count; i++)
				{
					double num;
					if (!list[i].TryGetDouble(out num))
					{
						flag = false;
						break;
					}
					array[i] = num;
				}
				if (flag)
				{
					return TFormulaValue.FromDoubleArray(array);
				}
				string[] array2 = new string[list.Count];
				for (int j = 0; j < list.Count; j++)
				{
					string text;
					if (!list[j].TryGetString(out text) || text == null)
					{
						return default(TFormulaValue);
					}
					array2[j] = text;
				}
				return TFormulaValue.FromStringArray(array2);
			}
			case JsonValueKind.String:
				return TFormulaValue.FromString(json.GetString() ?? string.Empty);
			case JsonValueKind.Number:
			{
				int value;
				if (json.TryGetInt32(out value))
				{
					return TFormulaValue.FromInt(value);
				}
				long value2;
				if (json.TryGetInt64(out value2))
				{
					return TFormulaValue.FromLong(value2);
				}
				double value3;
				if (json.TryGetDouble(out value3))
				{
					return TFormulaValue.FromDouble(value3);
				}
				break;
			}
			case JsonValueKind.True:
			case JsonValueKind.False:
				return TFormulaValue.FromBool(json.GetBoolean());
			}
			return default(TFormulaValue);
		}

		// Token: 0x0602F1A4 RID: 192932 RVA: 0x00B28580 File Offset: 0x00B26780
		private TFormulaValue EvaluateNode(IAstNode node)
		{
			NumberNode numberNode = node as NumberNode;
			if (numberNode != null)
			{
				return numberNode.Value;
			}
			BooleanNode booleanNode = node as BooleanNode;
			if (booleanNode != null)
			{
				return TFormulaValue.FromBool(booleanNode.Value);
			}
			StringNode stringNode = node as StringNode;
			if (stringNode != null)
			{
				return TFormulaValue.FromString(stringNode.Value);
			}
			ArrayNode arrayNode = node as ArrayNode;
			if (arrayNode != null)
			{
				TFormulaValue[] array = new TFormulaValue[arrayNode.Value.Length];
				for (int i = 0; i < arrayNode.Value.Length; i++)
				{
					array[i] = this.EvaluateNode(arrayNode.Value[i]);
				}
				return TFormulaValue.FromArrayLiteral(array);
			}
			IdentifierNode identifierNode = node as IdentifierNode;
			if (identifierNode != null)
			{
				TFormulaValue tformulaValue;
				TFormulaValue tformulaValue2;
				if (this.Params != null && this.Params.TryGetValue(identifierNode.Value, out tformulaValue))
				{
					tformulaValue2 = tformulaValue;
				}
				else
				{
					TFormulaValue tformulaValue3;
					if (this.ExtraParams == null || !this.ExtraParams.TryGetValue(identifierNode.Value, out tformulaValue3))
					{
						throw new Exception("Undefined variable: " + identifierNode.Value);
					}
					tformulaValue2 = tformulaValue3;
				}
				if (this.IsIdentifierNotRecorded(identifierNode.Value))
				{
					this.RecordIdentifier(identifierNode.Value);
					this.AddDebugString(this.GetFormulaString(node), tformulaValue2);
				}
				return tformulaValue2;
			}
			IndexNode indexNode = node as IndexNode;
			if (indexNode == null)
			{
				UnaryOperatorNode unaryOperatorNode = node as UnaryOperatorNode;
				string @operator;
				if (unaryOperatorNode == null)
				{
					BinaryOperatorNode binaryOperatorNode = node as BinaryOperatorNode;
					FunctionCallNode functionCallNode;
					if (binaryOperatorNode == null)
					{
						functionCallNode = (node as FunctionCallNode);
						if (functionCallNode == null)
						{
							ParenthesizedExpressionNode parenthesizedExpressionNode = node as ParenthesizedExpressionNode;
							if (parenthesizedExpressionNode == null)
							{
								DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
								defaultInterpolatedStringHandler.AppendLiteral("Invalid node type: ");
								defaultInterpolatedStringHandler.AppendFormatted<Type>(node.GetType());
								throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
							}
							return this.EvaluateNode(parenthesizedExpressionNode.Value);
						}
					}
					else
					{
						TFormulaValue tformulaValue4 = this.EvaluateNode(binaryOperatorNode.Args[0]);
						TFormulaValue tformulaValue5 = this.EvaluateNode(binaryOperatorNode.Args[1]);
						try
						{
							@operator = binaryOperatorNode.Operator;
							if (@operator != null)
							{
								int length = @operator.Length;
								if (length != 1)
								{
									if (length == 2)
									{
										char c = @operator[0];
										if (c <= '&')
										{
											if (c != '!')
											{
												if (c == '&')
												{
													if (@operator == "&&")
													{
														return tformulaValue4 & tformulaValue5;
													}
												}
											}
											else if (@operator == "!=")
											{
												return TFormulaValue.FromBool(tformulaValue4 != tformulaValue5);
											}
										}
										else
										{
											switch (c)
											{
											case '<':
												if (@operator == "<=")
												{
													return TFormulaValue.FromBool(tformulaValue4 <= tformulaValue5);
												}
												break;
											case '=':
												if (@operator == "==")
												{
													return TFormulaValue.FromBool(tformulaValue4 == tformulaValue5);
												}
												break;
											case '>':
												if (@operator == ">=")
												{
													return TFormulaValue.FromBool(tformulaValue4 >= tformulaValue5);
												}
												break;
											default:
												if (c == '|')
												{
													if (@operator == "||")
													{
														return tformulaValue4 | tformulaValue5;
													}
												}
												break;
											}
										}
									}
								}
								else
								{
									char c = @operator[0];
									if (c <= '/')
									{
										if (c == '%')
										{
											return tformulaValue4 % tformulaValue5;
										}
										switch (c)
										{
										case '*':
											return tformulaValue4 * tformulaValue5;
										case '+':
											return tformulaValue4 + tformulaValue5;
										case '-':
											return tformulaValue4 - tformulaValue5;
										case '/':
											return tformulaValue4 / tformulaValue5;
										}
									}
									else
									{
										if (c == '<')
										{
											return TFormulaValue.FromBool(tformulaValue4 < tformulaValue5);
										}
										if (c == '>')
										{
											return TFormulaValue.FromBool(tformulaValue4 > tformulaValue5);
										}
									}
								}
							}
							throw new Exception("Invalid binary operator: " + binaryOperatorNode.Operator);
						}
						catch (Exception)
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 3);
							defaultInterpolatedStringHandler.AppendLiteral("Invalid operation: ");
							defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(tformulaValue4);
							defaultInterpolatedStringHandler.AppendLiteral(" ");
							defaultInterpolatedStringHandler.AppendFormatted(binaryOperatorNode.Operator);
							defaultInterpolatedStringHandler.AppendLiteral(" ");
							defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(tformulaValue5);
							throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
						}
					}
					bool flag = this.contextDependentFunction.Contains(functionCallNode.Value);
					TFormulaValue[] array2 = new TFormulaValue[functionCallNode.Args.Length + ((flag > false) ? 1 : 0)];
					int num = 0;
					if (flag)
					{
						array2[0] = TFormulaValue.FromContext(this.context);
						num = 1;
					}
					for (int j = 0; j < functionCallNode.Args.Length; j++)
					{
						array2[num + j] = this.EvaluateNode(functionCallNode.Args[j]);
					}
					Func<TFormulaValue[], TFormulaValue> valueOrDefault = this.BuiltinFuncs.GetValueOrDefault(functionCallNode.Value);
					TFormulaValue tformulaValue6 = (valueOrDefault == null) ? default(TFormulaValue) : valueOrDefault(array2);
					this.AddDebugString(this.GetFormulaString(node), tformulaValue6);
					return tformulaValue6;
				}
				TFormulaValue operand = this.EvaluateNode(unaryOperatorNode.Args[0]);
				@operator = unaryOperatorNode.Operator;
				if (@operator == "+")
				{
					return +operand;
				}
				if (@operator == "-")
				{
					return -operand;
				}
				if (!(@operator == "!"))
				{
					throw new Exception("Invalid unary operator: " + unaryOperatorNode.Operator);
				}
				return !operand;
			}
			else
			{
				TFormulaValue tformulaValue7 = this.EvaluateNode(indexNode.Value);
				TFormulaValue value = this.EvaluateNode(indexNode.Index);
				int num2;
				if (!value.TryGetIndex(out num2) || num2 < 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Invalid array index: ");
					defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(value);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				TFormulaValue tformulaValue8;
				if (tformulaValue7.TryGetArrayElement(num2, out tformulaValue8))
				{
					this.AddDebugString(this.GetFormulaString(node), tformulaValue8);
					return tformulaValue8;
				}
				if (tformulaValue7.Type == EFormulaValueType.DoubleArray || tformulaValue7.Type == EFormulaValueType.StringArray)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Invalid array index: ");
					defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(value);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				throw new Exception("Variable is not a valid array");
			}
		}

		// Token: 0x0602F1A5 RID: 192933 RVA: 0x00B28C20 File Offset: 0x00B26E20
		[NullableContext(2)]
		public unsafe TFormulaValue Evaluate([Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<string, TFormulaValue> args = null, ContextParam context = null)
		{
			this.ResetDebugString();
			this.ResetDebugIdentifierMap();
			this.ExtraParams = args;
			this.context = context;
			TFormulaValue result = default(TFormulaValue);
			try
			{
				result = this.EvaluateNode(this.Ast);
			}
			catch (Exception ex)
			{
				result = default(TFormulaValue);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "Trigger条件解析异常";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("formula", this.FormulaRaw);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.ResetDebugString();
				this.AddDebugString("执行错误", TFormulaValue.FromString(ex.Message));
			}
			finally
			{
				this.ExtraParams = null;
				this.context = null;
			}
			return result;
		}

		// Token: 0x0602F1A6 RID: 192934 RVA: 0x00B28D14 File Offset: 0x00B26F14
		public void ResetDebugString()
		{
			this.DebugValueMap.Clear();
		}

		// Token: 0x0602F1A7 RID: 192935 RVA: 0x00B28D24 File Offset: 0x00B26F24
		public void AddDebugString(string key, TFormulaValue value)
		{
			try
			{
				this.DebugValueMap[key] = value.ToString();
			}
			catch (Exception)
			{
				this.DebugValueMap[key] = "(无法转换为字符串)";
			}
		}

		// Token: 0x0602F1A8 RID: 192936 RVA: 0x00B28D70 File Offset: 0x00B26F70
		public bool IsIdentifierNotRecorded(string str)
		{
			return !this.DebugRecordedIdentifiers.Contains(str);
		}

		// Token: 0x0602F1A9 RID: 192937 RVA: 0x00B28D81 File Offset: 0x00B26F81
		public void ResetDebugIdentifierMap()
		{
			this.DebugRecordedIdentifiers.Clear();
		}

		// Token: 0x0602F1AA RID: 192938 RVA: 0x00B28D8E File Offset: 0x00B26F8E
		public void RecordIdentifier(string str)
		{
			this.DebugRecordedIdentifiers.Add(str);
		}

		// Token: 0x0602F1AB RID: 192939 RVA: 0x00B28DA0 File Offset: 0x00B26FA0
		public string GetFormulaString(IAstNode node)
		{
			if (node is NumberNode || node is BooleanNode || node is StringNode)
			{
				NumberNode numberNode = node as NumberNode;
				string result;
				if (numberNode == null)
				{
					BooleanNode booleanNode = node as BooleanNode;
					if (booleanNode == null)
					{
						StringNode stringNode = node as StringNode;
						if (stringNode == null)
						{
							result = "";
						}
						else
						{
							result = stringNode.Value;
						}
					}
					else
					{
						result = booleanNode.Value.ToString();
					}
				}
				else
				{
					result = numberNode.Value.ToString();
				}
				return result;
			}
			ArrayNode arrayNode = node as ArrayNode;
			if (arrayNode != null)
			{
				string[] array = new string[arrayNode.Value.Length];
				for (int i = 0; i < arrayNode.Value.Length; i++)
				{
					array[i] = this.GetFormulaString(arrayNode.Value[i]);
				}
				return "[" + string.Join(",", array) + "]";
			}
			IdentifierNode identifierNode = node as IdentifierNode;
			if (identifierNode != null)
			{
				return identifierNode.Value;
			}
			IndexNode indexNode = node as IndexNode;
			if (indexNode != null)
			{
				return this.GetFormulaString(indexNode.Value) + "[" + this.GetFormulaString(indexNode.Index) + "]";
			}
			UnaryOperatorNode unaryOperatorNode = node as UnaryOperatorNode;
			if (unaryOperatorNode != null)
			{
				return unaryOperatorNode.Operator + "(" + this.GetFormulaString(unaryOperatorNode.Args[0]) + ")";
			}
			BinaryOperatorNode binaryOperatorNode = node as BinaryOperatorNode;
			if (binaryOperatorNode != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
				defaultInterpolatedStringHandler.AppendFormatted(this.GetFormulaString(binaryOperatorNode.Args[0]));
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(binaryOperatorNode.Operator);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(this.GetFormulaString(binaryOperatorNode.Args[1]));
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			FunctionCallNode functionCallNode = node as FunctionCallNode;
			if (functionCallNode != null)
			{
				string[] array2 = new string[functionCallNode.Args.Length];
				for (int j = 0; j < functionCallNode.Args.Length; j++)
				{
					array2[j] = this.GetFormulaString(functionCallNode.Args[j]);
				}
				return functionCallNode.Value + "(" + string.Join(",", array2) + ")";
			}
			ParenthesizedExpressionNode parenthesizedExpressionNode = node as ParenthesizedExpressionNode;
			if (parenthesizedExpressionNode == null)
			{
				return "";
			}
			return "(" + this.GetFormulaString(parenthesizedExpressionNode.Value) + ")";
		}

		// Token: 0x0602F1AC RID: 192940 RVA: 0x00B29024 File Offset: 0x00B27224
		public string GetLastResult()
		{
			string text = "";
			foreach (KeyValuePair<string, string> keyValuePair in this.DebugValueMap)
			{
				text = string.Concat(new string[]
				{
					text,
					keyValuePair.Key,
					": ",
					keyValuePair.Value,
					"\n"
				});
			}
			return text;
		}

		// Token: 0x0602F1AD RID: 192941 RVA: 0x00B290AC File Offset: 0x00B272AC
		public IReadOnlyDictionary<string, string> GetLastResultMap()
		{
			return this.DebugValueMap;
		}

		// Token: 0x0602F1AE RID: 192942 RVA: 0x00B290B4 File Offset: 0x00B272B4
		public string GetTotalFormulaString()
		{
			return this.GetFormulaString(this.Ast);
		}

		// Token: 0x0401AD31 RID: 109873
		private readonly IAstNode Ast;

		// Token: 0x0401AD32 RID: 109874
		private readonly string FormulaRaw = "";

		// Token: 0x0401AD33 RID: 109875
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<string, TFormulaValue> Params;

		// Token: 0x0401AD34 RID: 109876
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<string, TFormulaValue> ExtraParams;

		// Token: 0x0401AD35 RID: 109877
		private readonly Dictionary<string, Func<TFormulaValue[], TFormulaValue>> BuiltinFuncs = new Dictionary<string, Func<TFormulaValue[], TFormulaValue>>();

		// Token: 0x0401AD36 RID: 109878
		private readonly HashSet<string> contextDependentFunction = new HashSet<string>();

		// Token: 0x0401AD37 RID: 109879
		[Nullable(2)]
		public ContextParam context;

		// Token: 0x0401AD38 RID: 109880
		[Nullable(2)]
		private string ParamsCacheKey;

		// Token: 0x0401AD39 RID: 109881
		private bool IsDisposed;

		// Token: 0x0401AD3A RID: 109882
		private readonly Dictionary<string, string> DebugValueMap = new Dictionary<string, string>();

		// Token: 0x0401AD3B RID: 109883
		private readonly HashSet<string> DebugRecordedIdentifiers = new HashSet<string>();
	}
}
