using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046BD RID: 18109
	[NullableContext(1)]
	[Nullable(0)]
	public class CustomVariable
	{
		// Token: 0x0602F1B8 RID: 192952 RVA: 0x00B290EC File Offset: 0x00B272EC
		private CustomVariable(Dictionary<string, string> customVariableStr)
		{
			foreach (KeyValuePair<string, string> keyValuePair in customVariableStr)
			{
				this._customVariableStr[keyValuePair.Key] = keyValuePair.Value;
			}
			this._logInfo.Clear();
			this.VariableMap.Clear();
		}

		// Token: 0x0602F1B9 RID: 192953 RVA: 0x00B2918C File Offset: 0x00B2738C
		public unsafe static CustomVariable Create(Dictionary<string, string> customVariable, string reason)
		{
			CustomVariable customVariable2 = new CustomVariable(customVariable);
			foreach (KeyValuePair<string, string> keyValuePair in customVariable)
			{
				customVariable2.ParseCustomVariables(keyValuePair.Key, keyValuePair.Value);
			}
			if (customVariable2._logInfo.Count > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.TZQ;
				string message = "解析表达式自定义变量异常";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ErrorInfo", customVariable2._logInfo);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("CustomVariableStr", customVariable2._customVariableStr);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				customVariable2._logInfo.Clear();
			}
			return customVariable2;
		}

		// Token: 0x0602F1BA RID: 192954 RVA: 0x00B29280 File Offset: 0x00B27480
		private void ParseCustomVariables(string variableName, string variableStr)
		{
			string[] array = variableStr.Replace(" ", string.Empty).Split('#', StringSplitOptions.None);
			if (array.Length < 2)
			{
				this.AddDebugInfo(variableStr + "解析自定义变量格式错误:字符串数量小于2");
				return;
			}
			string a = array[0];
			if (!(a == "Long"))
			{
				if (a == "LongArray")
				{
					List<double> list = new List<double>();
					for (int i = 1; i < array.Length; i++)
					{
						double item;
						if (!double.TryParse(array[i], out item))
						{
							this.AddDebugInfo(variableStr + "解析自定义变量格式错误: 数组不合法");
							return;
						}
						list.Add(item);
					}
					this.VariableMap[variableName] = new Variable
					{
						Type = EVariableType.NumberArray,
						Value = list.ToArray()
					};
					return;
				}
				if (!(a == "Tag"))
				{
					if (a == "TagContainer")
					{
						TagContainer tagContainer = new TagContainer();
						for (int j = 1; j < array.Length; j++)
						{
							int tagIdByName = GameplayTagUtils.GetTagIdByName(array[j]);
							if (tagIdByName == 0)
							{
								this.AddDebugInfo(variableStr + "解析自定义变量格式错误: Tag不合法, 异常tagName" + array[j]);
								return;
							}
							tagContainer.AddExactTag(ETagChannel.Common, tagIdByName);
						}
						this.VariableMap[variableName] = new Variable
						{
							Type = EVariableType.TagContainer,
							Value = tagContainer
						};
						return;
					}
					if (!(a == "String"))
					{
						return;
					}
					this.VariableMap[variableName] = new Variable
					{
						Type = EVariableType.String,
						Value = array[1]
					};
					return;
				}
				else
				{
					int tagIdByName2 = GameplayTagUtils.GetTagIdByName(array[1]);
					if (tagIdByName2 == 0)
					{
						this.AddDebugInfo(variableStr + "解析自定义变量格式错误: Tag不合法");
						return;
					}
					this.VariableMap[variableName] = new Variable
					{
						Type = EVariableType.Tag,
						Value = tagIdByName2
					};
					return;
				}
			}
			else
			{
				double value;
				if (!double.TryParse(array[1], out value))
				{
					this.AddDebugInfo(variableStr + "解析自定义变量格式错误: 数字不合法");
					return;
				}
				this.VariableMap[variableName] = new Variable
				{
					Type = EVariableType.Number,
					Value = value
				};
				return;
			}
		}

		// Token: 0x0602F1BB RID: 192955 RVA: 0x00B29493 File Offset: 0x00B27693
		public bool HasVariable(string variableName)
		{
			return this.VariableMap.ContainsKey(variableName);
		}

		// Token: 0x0602F1BC RID: 192956 RVA: 0x00B294A4 File Offset: 0x00B276A4
		public TFormulaValue GetVariable(string variableName)
		{
			IVariable variable;
			if (this.VariableMap.TryGetValue(variableName, out variable))
			{
				return variable.Value;
			}
			return default(TFormulaValue);
		}

		// Token: 0x0602F1BD RID: 192957 RVA: 0x00B294D1 File Offset: 0x00B276D1
		private void AddDebugInfo(string debugStr)
		{
			this._logInfo.Add(debugStr);
		}

		// Token: 0x0401AD44 RID: 109892
		private readonly Dictionary<string, string> _customVariableStr = new Dictionary<string, string>();

		// Token: 0x0401AD45 RID: 109893
		public readonly Dictionary<string, IVariable> VariableMap = new Dictionary<string, IVariable>();

		// Token: 0x0401AD46 RID: 109894
		private readonly List<string> _logInfo = new List<string>();
	}
}
