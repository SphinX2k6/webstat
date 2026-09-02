using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007007 RID: 28679
	[NullableContext(1)]
	[Nullable(0)]
	public class InputCombinationAxisMapping
	{
		// Token: 0x060456C8 RID: 284360 RVA: 0x01226A28 File Offset: 0x01224C28
		public void Clear()
		{
			foreach (InputCombinationAxisBinding inputCombinationAxisBinding in this.CombinationAxisBindingMap.Values)
			{
				inputCombinationAxisBinding.Clear();
			}
			this.CombinationAxisBindingMap.Clear();
			this.CombinationAxisBindingKeyMap.Clear();
		}

		// Token: 0x060456C9 RID: 284361 RVA: 0x01226A94 File Offset: 0x01224C94
		public void NewCombinationAxisBinding(CombinationAxis config)
		{
			string axisName = config.AxisName;
			InputCombinationAxisBinding inputCombinationAxisBinding = new InputCombinationAxisBinding();
			inputCombinationAxisBinding.Initialize(config);
			this.CombinationAxisBindingMap[axisName] = inputCombinationAxisBinding;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			inputCombinationAxisBinding.GetPcKeyNameMap(dictionary, (EInputBindingType)config.ExclusiveType);
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			inputCombinationAxisBinding.GetGamepadKeyNameMap(dictionary2, (EInputBindingType)config.ExclusiveType);
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				this.AddKeyMap(inputCombinationAxisBinding, key, value, (EInputBindingType)config.ExclusiveType);
			}
			foreach (KeyValuePair<string, string> keyValuePair2 in dictionary2)
			{
				string key2 = keyValuePair2.Key;
				string value2 = keyValuePair2.Value;
				this.AddKeyMap(inputCombinationAxisBinding, key2, value2, (EInputBindingType)config.ExclusiveType);
			}
		}

		// Token: 0x060456CA RID: 284362 RVA: 0x01226BA8 File Offset: 0x01224DA8
		public unsafe void AddKeyMap(InputCombinationAxisBinding combinationAxisBinding, string secondaryKeyName, string mainKeyName, EInputBindingType bindingType)
		{
			Dictionary<string, List<InputCombinationAxisBinding>> dictionary;
			if (!this.CombinationAxisBindingKeyMap.TryGetValue(mainKeyName, out dictionary))
			{
				dictionary = new Dictionary<string, List<InputCombinationAxisBinding>>();
				this.CombinationAxisBindingKeyMap[mainKeyName] = dictionary;
			}
			List<InputCombinationAxisBinding> list;
			if (!dictionary.TryGetValue(secondaryKeyName, out list))
			{
				list = new List<InputCombinationAxisBinding>();
				dictionary[secondaryKeyName] = list;
			}
			list.Add(combinationAxisBinding);
			combinationAxisBinding.AddKey(secondaryKeyName, mainKeyName, bindingType);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputSettings;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[AddKeyMap]";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("mainKeyName", mainKeyName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("secondaryKeyName", secondaryKeyName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MainKeySet", this.MainKeySet);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.MainKeySet.Add(mainKeyName);
		}

		// Token: 0x060456CB RID: 284363 RVA: 0x01226C80 File Offset: 0x01224E80
		public void RemoveKeyMap(InputCombinationAxisBinding combinationAxisBinding, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			combinationAxisBinding.RemoveKey(secondaryKeyName, bindingType);
			string axisName = combinationAxisBinding.GetAxisName();
			Dictionary<string, List<InputCombinationAxisBinding>> dictionary;
			if (this.CombinationAxisBindingKeyMap.TryGetValue(mainKeyName, out dictionary))
			{
				List<InputCombinationAxisBinding> list;
				if (dictionary.TryGetValue(secondaryKeyName, out list))
				{
					int num = list.IndexOf(combinationAxisBinding);
					if (num >= 0)
					{
						list.RemoveAt(num);
					}
					if (list.Count <= 0)
					{
						dictionary.Remove(secondaryKeyName);
					}
					if (dictionary.Count <= 0)
					{
						this.CombinationAxisBindingKeyMap.Remove(mainKeyName);
						this.MainKeySet.Remove(mainKeyName);
					}
				}
			}
			else
			{
				this.MainKeySet.Remove(mainKeyName);
			}
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			combinationAxisBinding.GetKeyMap(dictionary2, bindingType);
			if (dictionary2.Count <= 0)
			{
				this.CombinationAxisBindingMap.Remove(axisName);
			}
		}

		// Token: 0x060456CC RID: 284364 RVA: 0x01226D38 File Offset: 0x01224F38
		[return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public Dictionary<string, List<InputCombinationAxisBinding>> GetCombinationAxisBindingMapByMainKeyName(string mainKeyName)
		{
			Dictionary<string, List<InputCombinationAxisBinding>> result;
			if (this.CombinationAxisBindingKeyMap.TryGetValue(mainKeyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456CD RID: 284365 RVA: 0x01226D58 File Offset: 0x01224F58
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<InputCombinationAxisBinding> GetCombinationAxisBindingByKeyName(string mainKeyName, string secondaryKeyName)
		{
			Dictionary<string, List<InputCombinationAxisBinding>> dictionary;
			if (!this.CombinationAxisBindingKeyMap.TryGetValue(mainKeyName, out dictionary))
			{
				return null;
			}
			List<InputCombinationAxisBinding> result;
			if (dictionary.TryGetValue(secondaryKeyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456CE RID: 284366 RVA: 0x01226D88 File Offset: 0x01224F88
		[return: Nullable(2)]
		public InputCombinationAxisBinding GetCombinationAxisBindingByAxisName(string actionName)
		{
			InputCombinationAxisBinding result;
			if (this.CombinationAxisBindingMap.TryGetValue(actionName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456CF RID: 284367 RVA: 0x01226DA8 File Offset: 0x01224FA8
		public Dictionary<string, InputCombinationAxisBinding> GetCombinationAxisBindingMap()
		{
			return this.CombinationAxisBindingMap;
		}

		// Token: 0x060456D0 RID: 284368 RVA: 0x01226DB0 File Offset: 0x01224FB0
		public bool IsMainKey(string keyName)
		{
			return this.MainKeySet.Contains(keyName);
		}

		// Token: 0x060456D1 RID: 284369 RVA: 0x01226DC0 File Offset: 0x01224FC0
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			foreach (InputCombinationAxisBinding inputCombinationAxisBinding in this.CombinationAxisBindingMap.Values)
			{
				inputCombinationAxisBinding.SwitchKeysByBindingType(bindingType);
			}
		}

		// Token: 0x04026CD9 RID: 158937
		private readonly Dictionary<string, InputCombinationAxisBinding> CombinationAxisBindingMap = new Dictionary<string, InputCombinationAxisBinding>();

		// Token: 0x04026CDA RID: 158938
		private readonly Dictionary<string, Dictionary<string, List<InputCombinationAxisBinding>>> CombinationAxisBindingKeyMap = new Dictionary<string, Dictionary<string, List<InputCombinationAxisBinding>>>();

		// Token: 0x04026CDB RID: 158939
		private readonly HashSet<string> MainKeySet = new HashSet<string>();
	}
}
