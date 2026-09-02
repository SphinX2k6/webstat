using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046C1 RID: 18113
	[NullableContext(1)]
	[Nullable(0)]
	public class ExpressionTree : IStaticVariableResetter
	{
		// Token: 0x0602F1CF RID: 192975 RVA: 0x00B29536 File Offset: 0x00B27736
		static ExpressionTree()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ExpressionTree.CreateStaticDefaultValue), new Action(ExpressionTree.ResetStaticDefaultValue));
		}

		// Token: 0x0602F1D0 RID: 192976 RVA: 0x00B29558 File Offset: 0x00B27758
		public static void CreateStaticDefaultValue()
		{
			Dictionary<string, ENodeType> dictionary = new Dictionary<string, ENodeType>();
			dictionary["OR"] = ENodeType.OR;
			dictionary["AND"] = ENodeType.AND;
			dictionary["NOT"] = ENodeType.NOT;
			dictionary["SequenceTrue"] = ENodeType.SequenceTrue;
			ExpressionTree.OperatorMap = dictionary;
			Dictionary<string, ENodeType> dictionary2 = new Dictionary<string, ENodeType>();
			dictionary2["=="] = ENodeType.Equal;
			dictionary2["!="] = ENodeType.NotEqual;
			dictionary2["<="] = ENodeType.LessEqual;
			dictionary2["<"] = ENodeType.Less;
			dictionary2[">="] = ENodeType.GreaterEqual;
			dictionary2[">"] = ENodeType.Greater;
			ExpressionTree.RelationOperatorMap = dictionary2;
		}

		// Token: 0x0602F1D1 RID: 192977 RVA: 0x00B295F2 File Offset: 0x00B277F2
		public static void ResetStaticDefaultValue()
		{
			ExpressionTree.OperatorMap = null;
			ExpressionTree.RelationOperatorMap = null;
		}

		// Token: 0x0602F1D2 RID: 192978 RVA: 0x00B29600 File Offset: 0x00B27800
		public void ResetData()
		{
			this.Formula = string.Empty;
			this.CustomVariable = null;
			this.Position = 0;
			this.Reason = string.Empty;
			this.LogInfo.Clear();
			this.Context = null;
			this.RootNode = null;
			this.IsRunning = false;
		}

		// Token: 0x0602F1D3 RID: 192979 RVA: 0x00B29654 File Offset: 0x00B27854
		public unsafe bool Parse(string reason, string formula, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> customVariableStr)
		{
			this.ResetData();
			this.Formula = formula;
			this.Reason = reason;
			if (customVariableStr != null)
			{
				this.CustomVariable = CustomVariable.Create(customVariableStr, reason);
			}
			bool result = true;
			try
			{
				this.RootNode = this.ParseStatement();
				this.PassEmpty();
				if (!this.IsEnd)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
					defaultInterpolatedStringHandler.AppendLiteral("有未解析的字符,position");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.Position);
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			catch (Exception ex)
			{
				result = false;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "解析表达式异常";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("formula", this.Formula);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return result;
		}

		// Token: 0x0602F1D4 RID: 192980 RVA: 0x00B29748 File Offset: 0x00B27948
		[NullableContext(2)]
		private INode ParseStatement()
		{
			this.PassEmpty();
			if (this.IsEnd)
			{
				return null;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (this.Formula[this.Position] != '(')
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
				defaultInterpolatedStringHandler.AppendLiteral("解析表达式格式错误:位置");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Position);
				defaultInterpolatedStringHandler.AppendLiteral("期望一个(");
				this.ThrowError(defaultInterpolatedStringHandler.ToStringAndClear());
				return null;
			}
			this.Position++;
			INode result = this.ParseArguments();
			this.PassEmpty();
			if (!this.IsEnd && this.Formula[this.Position] == ')')
			{
				this.Position++;
				return result;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("解析表达式格式错误:位置");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Position);
			defaultInterpolatedStringHandler.AppendLiteral("期望一个)");
			this.ThrowError(defaultInterpolatedStringHandler.ToStringAndClear());
			return null;
		}

		// Token: 0x0602F1D5 RID: 192981 RVA: 0x00B29844 File Offset: 0x00B27A44
		[NullableContext(2)]
		private INode ParseArguments()
		{
			List<INode> list = new List<INode>();
			INode node = null;
			while (!this.IsEnd)
			{
				this.PassEmpty();
				if (this.IsEnd)
				{
					break;
				}
				char c = this.Formula[this.Position];
				bool flag = false;
				INode node2;
				if (char.IsDigit(c))
				{
					node2 = this.ParseNumber();
				}
				else if (char.IsLetter(c))
				{
					node2 = this.ParseIdentifier();
				}
				else if (this.IsRelationOperatorStart(c))
				{
					node2 = this.ParseRelationOperator();
				}
				else
				{
					if (c != '(')
					{
						break;
					}
					node2 = this.ParseStatement();
					flag = true;
				}
				if (node2 == null)
				{
					break;
				}
				if (!flag && node2.NodeType <= ENodeType.FunctionCall)
				{
					if (node != null)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
						defaultInterpolatedStringHandler.AppendLiteral("解析表达式格式错误:括号内有多个操作符 ");
						defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(node.Value);
						defaultInterpolatedStringHandler.AppendLiteral(" 和 ");
						defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(node2.Value);
						this.ThrowError(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					node = node2;
				}
				else
				{
					list.Add(node2);
				}
			}
			if (node == null)
			{
				this.ThrowError("解析表达式格式错误:括号内没有操作符");
				return null;
			}
			node.Children = list;
			return node;
		}

		// Token: 0x0602F1D6 RID: 192982 RVA: 0x00B29954 File Offset: 0x00B27B54
		private INode ParseNumber()
		{
			int position = this.Position;
			while (this.Position < this.Formula.Length && char.IsDigit(this.Formula[this.Position]))
			{
				this.Position++;
			}
			if (this.Position < this.Formula.Length && this.Formula[this.Position] == '.')
			{
				this.Position++;
				while (this.Position < this.Formula.Length && char.IsDigit(this.Formula[this.Position]))
				{
					this.Position++;
				}
			}
			double value = double.Parse(this.Formula.Substring(position, this.Position - position));
			return new Node
			{
				NodeType = ENodeType.Number,
				Value = TFormulaValue.FromDouble(value)
			};
		}

		// Token: 0x0602F1D7 RID: 192983 RVA: 0x00B29A48 File Offset: 0x00B27C48
		private INode ParseRelationOperator()
		{
			int length = Math.Min(2, this.Formula.Length - this.Position);
			string text = this.Formula.Substring(this.Position, length);
			string text2 = (ExpressionTree.RelationOperatorMap != null && ExpressionTree.RelationOperatorMap.ContainsKey(text)) ? text : this.Formula[this.Position].ToString();
			ENodeType nodeType;
			if (ExpressionTree.RelationOperatorMap == null || !ExpressionTree.RelationOperatorMap.TryGetValue(text2, out nodeType))
			{
				this.ThrowError("解析表达式格式错误:关系操作符不合法" + text2);
				nodeType = ENodeType.Equal;
			}
			this.Position += text2.Length;
			return new Node
			{
				NodeType = nodeType,
				Value = text2
			};
		}

		// Token: 0x0602F1D8 RID: 192984 RVA: 0x00B29B08 File Offset: 0x00B27D08
		private INode ParseIdentifier()
		{
			int position = this.Position;
			while (this.Position < this.Formula.Length && char.IsLetterOrDigit(this.Formula[this.Position]))
			{
				this.Position++;
			}
			string text = this.Formula.Substring(position, this.Position - position);
			ENodeType nodeType;
			INode node;
			if (ExpressionTree.OperatorMap != null && ExpressionTree.OperatorMap.TryGetValue(text, out nodeType))
			{
				node = new Node
				{
					NodeType = nodeType,
					Name = text
				};
			}
			else if (ModelBase<ExpressionTreeModel>.Instance.GetBuiltinFunc(text) != null)
			{
				node = new Node
				{
					NodeType = ENodeType.FunctionCall,
					Name = text
				};
			}
			else
			{
				node = new Node
				{
					NodeType = ENodeType.Variable,
					Name = text
				};
			}
			if (this.Position < this.Formula.Length && this.Formula[this.Position] == '.')
			{
				this.Position++;
				List<INode> children = new List<INode>
				{
					node
				};
				node = this.ParseIdentifier();
				if (node.NodeType != ENodeType.FunctionCall)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
					defaultInterpolatedStringHandler.AppendLiteral("解析表达式格式错误:.号操作符后接符号不合法");
					defaultInterpolatedStringHandler.AppendFormatted(node.Name);
					defaultInterpolatedStringHandler.AppendLiteral("节点类型");
					defaultInterpolatedStringHandler.AppendFormatted<ENodeType>(node.NodeType);
					this.ThrowError(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				node.NodeType = ENodeType.MemberAccess;
				node.Children = children;
			}
			return node;
		}

		// Token: 0x0602F1D9 RID: 192985 RVA: 0x00B29C86 File Offset: 0x00B27E86
		private bool IsRelationOperatorStart(char ch)
		{
			return ch == '=' || ch == '!' || ch == '<' || ch == '>';
		}

		// Token: 0x17008101 RID: 33025
		// (get) Token: 0x0602F1DA RID: 192986 RVA: 0x00B29C9E File Offset: 0x00B27E9E
		private bool IsEnd
		{
			get
			{
				return this.Position >= this.Formula.Length;
			}
		}

		// Token: 0x0602F1DB RID: 192987 RVA: 0x00B29CB8 File Offset: 0x00B27EB8
		private void PassEmpty()
		{
			while (this.Position < this.Formula.Length)
			{
				char c = this.Formula[this.Position];
				if (!char.IsWhiteSpace(c) && c != ',')
				{
					break;
				}
				this.Position++;
			}
		}

		// Token: 0x0602F1DC RID: 192988 RVA: 0x00B29D07 File Offset: 0x00B27F07
		private void ThrowError(string errorInfo)
		{
			throw new Exception(errorInfo);
		}

		// Token: 0x0602F1DD RID: 192989 RVA: 0x00B29D10 File Offset: 0x00B27F10
		private TFormulaValue EvaluateNode(INode node)
		{
			TFormulaValue tformulaValue2;
			switch (node.NodeType)
			{
			case ENodeType.OR:
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (node.Children != null)
				{
					foreach (INode node2 in node.Children)
					{
						if (ExpressionTree.ToBool(this.EvaluateNode(node2)))
						{
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
							defaultInterpolatedStringHandler.AppendLiteral("OR执行结果");
							defaultInterpolatedStringHandler.AppendFormatted<bool>(true);
							this.AddRunTimeLogInfo(defaultInterpolatedStringHandler.ToStringAndClear());
							return TFormulaValue.FromBool(true);
						}
					}
				}
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
				defaultInterpolatedStringHandler.AppendLiteral("OR执行结果");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(false);
				this.AddRunTimeLogInfo(defaultInterpolatedStringHandler.ToStringAndClear());
				return TFormulaValue.FromBool(false);
			}
			case ENodeType.AND:
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (node.Children != null)
				{
					foreach (INode node3 in node.Children)
					{
						if (!ExpressionTree.ToBool(this.EvaluateNode(node3)))
						{
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
							defaultInterpolatedStringHandler.AppendLiteral("AND执行结果");
							defaultInterpolatedStringHandler.AppendFormatted<bool>(false);
							this.AddRunTimeLogInfo(defaultInterpolatedStringHandler.ToStringAndClear());
							return TFormulaValue.FromBool(false);
						}
					}
				}
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
				defaultInterpolatedStringHandler.AppendLiteral("AND执行结果");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(true);
				this.AddRunTimeLogInfo(defaultInterpolatedStringHandler.ToStringAndClear());
				return TFormulaValue.FromBool(true);
			}
			case ENodeType.NOT:
				if (node.Children == null || node.Children.Count == 0)
				{
					return TFormulaValue.FromBool(false);
				}
				return TFormulaValue.FromBool(!ExpressionTree.ToBool(this.EvaluateNode(node.Children[0])));
			case ENodeType.SequenceTrue:
				if (node.Children != null)
				{
					foreach (INode node4 in node.Children)
					{
						this.EvaluateNode(node4);
					}
				}
				return TFormulaValue.FromBool(true);
			case ENodeType.Equal:
			case ENodeType.NotEqual:
			case ENodeType.LessEqual:
			case ENodeType.Less:
			case ENodeType.GreaterEqual:
			case ENodeType.Greater:
				return this.EvaluateRelationNode(node);
			case ENodeType.FunctionCall:
			case ENodeType.MemberAccess:
			{
				List<TFormulaValue> list = new List<TFormulaValue>();
				if (node.Children != null)
				{
					foreach (INode node5 in node.Children)
					{
						list.Add(this.EvaluateNode(node5));
					}
				}
				string name = node.Name;
				Func<IExpressionContext, TFormulaValue[], TFormulaValue> builtinFunc = ModelBase<ExpressionTreeModel>.Instance.GetBuiltinFunc(name);
				TFormulaValue tformulaValue = default(TFormulaValue);
				if (builtinFunc != null)
				{
					tformulaValue = builtinFunc(this.Context, list.ToArray());
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
				defaultInterpolatedStringHandler.AppendLiteral("函数");
				defaultInterpolatedStringHandler.AppendFormatted(name);
				defaultInterpolatedStringHandler.AppendLiteral("执行结果");
				defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(tformulaValue);
				this.AddRunTimeLogInfo(defaultInterpolatedStringHandler.ToStringAndClear());
				return tformulaValue;
			}
			case ENodeType.Variable:
			{
				string name2 = node.Name;
				CustomVariable customVariable = this.CustomVariable;
				TFormulaValue tformulaValue3;
				if (customVariable == null)
				{
					tformulaValue2 = default(TFormulaValue);
					tformulaValue3 = tformulaValue2;
				}
				else
				{
					tformulaValue3 = customVariable.GetVariable(name2);
				}
				TFormulaValue tformulaValue4 = tformulaValue3;
				if (tformulaValue4.IsNull && this.ExtraParams != null)
				{
					this.ExtraParams.TryGetValue(name2, out tformulaValue4);
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
				defaultInterpolatedStringHandler.AppendLiteral("变量");
				defaultInterpolatedStringHandler.AppendFormatted(name2);
				defaultInterpolatedStringHandler.AppendLiteral("执行结果");
				defaultInterpolatedStringHandler.AppendFormatted<TFormulaValue>(tformulaValue4);
				this.AddRunTimeLogInfo(defaultInterpolatedStringHandler.ToStringAndClear());
				return tformulaValue4;
			}
			case ENodeType.Bool:
			case ENodeType.String:
			case ENodeType.Number:
				return node.Value;
			default:
				return default(TFormulaValue);
			}
			return tformulaValue2;
		}

		// Token: 0x0602F1DE RID: 192990 RVA: 0x00B2A0F0 File Offset: 0x00B282F0
		private TFormulaValue EvaluateRelationNode(INode node)
		{
			TFormulaValue left = this.EvaluateNode(node.Children[0]);
			TFormulaValue right = this.EvaluateNode(node.Children[1]);
			switch (node.NodeType)
			{
			case ENodeType.Equal:
				return TFormulaValue.FromBool(left == right);
			case ENodeType.NotEqual:
				return TFormulaValue.FromBool(left != right);
			case ENodeType.LessEqual:
				return TFormulaValue.FromBool(left <= right);
			case ENodeType.Less:
				return TFormulaValue.FromBool(left < right);
			case ENodeType.GreaterEqual:
				return TFormulaValue.FromBool(left >= right);
			case ENodeType.Greater:
				return TFormulaValue.FromBool(left > right);
			default:
				return TFormulaValue.FromBool(false);
			}
		}

		// Token: 0x0602F1DF RID: 192991 RVA: 0x00B2A1A0 File Offset: 0x00B283A0
		public unsafe TFormulaValue Evaluate(IExpressionContext context, [Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<string, TFormulaValue> args = null)
		{
			TFormulaValue result = default(TFormulaValue);
			if (this.RootNode == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "解析表达式节点为空";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("formula", this.Formula);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", this.Reason);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return result;
			}
			if (this.IsRunning)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.TZQ;
				string message2 = "解析表达式重复进入";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("formula", this.Formula);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("reason", this.Reason);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return result;
			}
			this.Context = context;
			this.ExtraParams = args;
			this.IsRunning = true;
			try
			{
				result = this.EvaluateNode(this.RootNode);
			}
			catch (Exception ex)
			{
				result = default(TFormulaValue);
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Event;
				ELogAuthor author3 = ELogAuthor.TZQ;
				string message3 = "解析表达式异常";
				Exception error = ex;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("formula", this.Formula);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("reason", this.Reason);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("error", ex.Message);
				instance3.ErrorWithStack(module3, author3, message3, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			}
			finally
			{
				this.PrintRunTimeLogInfo();
				this.Context = null;
				this.ExtraParams = null;
				this.IsRunning = false;
			}
			return result;
		}

		// Token: 0x0602F1E0 RID: 192992 RVA: 0x00B2A36C File Offset: 0x00B2856C
		private void PrintRunTimeLogInfo()
		{
			if (!ExpressionTree.IsDebug)
			{
				return;
			}
			this.LogInfo.Clear();
		}

		// Token: 0x0602F1E1 RID: 192993 RVA: 0x00B2A381 File Offset: 0x00B28581
		private void AddRunTimeLogInfo(string info)
		{
			if (!ExpressionTree.IsDebug)
			{
				return;
			}
			this.LogInfo.Add(info);
		}

		// Token: 0x0602F1E2 RID: 192994 RVA: 0x00B2A398 File Offset: 0x00B28598
		private static bool ToBool(TFormulaValue value)
		{
			bool result;
			if (value.TryGetBool(out result))
			{
				return result;
			}
			double value2;
			if (value.TryGetDouble(out value2))
			{
				return Math.Abs(value2) > double.Epsilon;
			}
			string value3;
			if (value.TryGetString(out value3))
			{
				return !string.IsNullOrEmpty(value3);
			}
			Entity entity;
			if (value.TryGetEntity(out entity))
			{
				return entity != null;
			}
			TagContainer tagContainer;
			if (value.TryGetTagContainer(out tagContainer))
			{
				return tagContainer != null;
			}
			return !value.IsNull;
		}

		// Token: 0x0401AD5C RID: 109916
		private const int RELATION_OPERATOR_MAX_LENGTH = 2;

		// Token: 0x0401AD5D RID: 109917
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<string, ENodeType> OperatorMap;

		// Token: 0x0401AD5E RID: 109918
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<string, ENodeType> RelationOperatorMap;

		// Token: 0x0401AD5F RID: 109919
		private static readonly bool IsDebug;

		// Token: 0x0401AD60 RID: 109920
		private string Formula = string.Empty;

		// Token: 0x0401AD61 RID: 109921
		[Nullable(2)]
		private CustomVariable CustomVariable;

		// Token: 0x0401AD62 RID: 109922
		private readonly List<string> LogInfo = new List<string>();

		// Token: 0x0401AD63 RID: 109923
		private int Position;

		// Token: 0x0401AD64 RID: 109924
		[Nullable(2)]
		private INode RootNode;

		// Token: 0x0401AD65 RID: 109925
		[Nullable(2)]
		private IExpressionContext Context;

		// Token: 0x0401AD66 RID: 109926
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<string, TFormulaValue> ExtraParams;

		// Token: 0x0401AD67 RID: 109927
		private bool IsRunning;

		// Token: 0x0401AD68 RID: 109928
		private string Reason = string.Empty;
	}
}
