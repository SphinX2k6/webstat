using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007006 RID: 28678
	[NullableContext(1)]
	[Nullable(0)]
	public class InputCombinationActionMapping
	{
		// Token: 0x060456BE RID: 284350 RVA: 0x01226784 File Offset: 0x01224984
		public void Clear()
		{
			foreach (InputCombinationActionBinding inputCombinationActionBinding in this.CombinationActionBindingMap.Values)
			{
				inputCombinationActionBinding.Clear();
			}
			this.CombinationActionBindingMap.Clear();
			this.CombinationActionBindingKeyMap.Clear();
			this.MainKeySet.Clear();
		}

		// Token: 0x060456BF RID: 284351 RVA: 0x012267FC File Offset: 0x012249FC
		public InputCombinationActionBinding NewCombinationActionBinding(string actionName, int secondaryKeyValidTime, bool isOriginalCombinationAction)
		{
			InputCombinationActionBinding inputCombinationActionBinding = new InputCombinationActionBinding();
			inputCombinationActionBinding.Initialize(actionName, secondaryKeyValidTime, isOriginalCombinationAction);
			this.CombinationActionBindingMap[actionName] = inputCombinationActionBinding;
			return inputCombinationActionBinding;
		}

		// Token: 0x060456C0 RID: 284352 RVA: 0x01226828 File Offset: 0x01224A28
		public void AddKey(InputCombinationActionBinding combinationActionBinding, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			combinationActionBinding.AddKey(mainKeyName, secondaryKeyName, bindingType);
			Dictionary<string, Dictionary<string, InputCombinationActionBinding>> dictionary;
			if (!this.CombinationActionBindingKeyMap.TryGetValue(mainKeyName, out dictionary))
			{
				dictionary = new Dictionary<string, Dictionary<string, InputCombinationActionBinding>>();
				this.CombinationActionBindingKeyMap[mainKeyName] = dictionary;
			}
			Dictionary<string, InputCombinationActionBinding> dictionary2;
			if (!dictionary.TryGetValue(secondaryKeyName, out dictionary2))
			{
				dictionary2 = new Dictionary<string, InputCombinationActionBinding>();
				dictionary[secondaryKeyName] = dictionary2;
			}
			dictionary2[combinationActionBinding.GetActionName()] = combinationActionBinding;
			this.MainKeySet.Add(mainKeyName);
		}

		// Token: 0x060456C1 RID: 284353 RVA: 0x01226898 File Offset: 0x01224A98
		public void RemoveKey(InputCombinationActionBinding combinationActionBinding, string mainKeyName, string secondaryKeyName, EInputBindingType bindingType)
		{
			combinationActionBinding.RemoveKey(mainKeyName, bindingType);
			string actionName = combinationActionBinding.GetActionName();
			Dictionary<string, Dictionary<string, InputCombinationActionBinding>> dictionary;
			if (this.CombinationActionBindingKeyMap.TryGetValue(mainKeyName, out dictionary))
			{
				Dictionary<string, InputCombinationActionBinding> dictionary2;
				if (dictionary.TryGetValue(secondaryKeyName, out dictionary2))
				{
					if (!combinationActionBinding.HasKeyByAll(mainKeyName, secondaryKeyName))
					{
						dictionary2.Remove(actionName);
					}
					if (dictionary2.Count <= 0)
					{
						dictionary.Remove(secondaryKeyName);
					}
					if (dictionary.Count <= 0)
					{
						this.CombinationActionBindingKeyMap.Remove(mainKeyName);
						this.MainKeySet.Remove(mainKeyName);
					}
				}
			}
			else
			{
				this.MainKeySet.Remove(mainKeyName);
			}
			if (!combinationActionBinding.HasAnyKey())
			{
				this.CombinationActionBindingMap.Remove(actionName);
			}
		}

		// Token: 0x060456C2 RID: 284354 RVA: 0x0122693C File Offset: 0x01224B3C
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, InputCombinationActionBinding> GetCombinationActionBindingByKeyName(string mainKeyName, string secondaryKeyName)
		{
			Dictionary<string, Dictionary<string, InputCombinationActionBinding>> dictionary;
			if (!this.CombinationActionBindingKeyMap.TryGetValue(mainKeyName, out dictionary))
			{
				return null;
			}
			Dictionary<string, InputCombinationActionBinding> result;
			if (dictionary.TryGetValue(secondaryKeyName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456C3 RID: 284355 RVA: 0x0122696C File Offset: 0x01224B6C
		[return: Nullable(2)]
		public InputCombinationActionBinding GetCombinationActionBindingByActionName(string actionName)
		{
			InputCombinationActionBinding result;
			if (this.CombinationActionBindingMap.TryGetValue(actionName, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060456C4 RID: 284356 RVA: 0x0122698C File Offset: 0x01224B8C
		public IReadOnlyDictionary<string, InputCombinationActionBinding> GetCombinationActionBindingMap()
		{
			return this.CombinationActionBindingMap;
		}

		// Token: 0x060456C5 RID: 284357 RVA: 0x01226994 File Offset: 0x01224B94
		public bool IsMainKey(string keyName)
		{
			return this.MainKeySet.Contains(keyName);
		}

		// Token: 0x060456C6 RID: 284358 RVA: 0x012269A4 File Offset: 0x01224BA4
		public void SwitchKeysByBindingType(EInputBindingType bindingType)
		{
			foreach (InputCombinationActionBinding inputCombinationActionBinding in this.CombinationActionBindingMap.Values)
			{
				inputCombinationActionBinding.SwitchKeysByBindingType(bindingType);
			}
		}

		// Token: 0x04026CD6 RID: 158934
		private readonly Dictionary<string, InputCombinationActionBinding> CombinationActionBindingMap = new Dictionary<string, InputCombinationActionBinding>();

		// Token: 0x04026CD7 RID: 158935
		private readonly Dictionary<string, Dictionary<string, Dictionary<string, InputCombinationActionBinding>>> CombinationActionBindingKeyMap = new Dictionary<string, Dictionary<string, Dictionary<string, InputCombinationActionBinding>>>();

		// Token: 0x04026CD8 RID: 158936
		private readonly HashSet<string> MainKeySet = new HashSet<string>();
	}
}
