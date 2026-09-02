using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FED RID: 28653
	[NullableContext(1)]
	[Nullable(0)]
	public class InputKeyDisplayData
	{
		// Token: 0x06045565 RID: 284005 RVA: 0x0121CF7D File Offset: 0x0121B17D
		public void RefreshInput(string actionOrAxisName, IReadOnlyList<string> keyNameList)
		{
			this.ActionOrAxisName = actionOrAxisName;
			this.KeyNameList.Clear();
			this.KeyNameList.AddRange(keyNameList);
			this.IsCombination = false;
		}

		// Token: 0x06045566 RID: 284006 RVA: 0x0121CFA4 File Offset: 0x0121B1A4
		public void RefreshCombinationInput(string actionOrAxisName, IReadOnlyDictionary<string, string> keyNameMap)
		{
			this.ActionOrAxisName = actionOrAxisName;
			this.KeyNameMap.Clear();
			foreach (KeyValuePair<string, string> keyValuePair in keyNameMap)
			{
				this.KeyNameMap.Add(keyValuePair.Key, keyValuePair.Value);
			}
			this.IsCombination = true;
		}

		// Token: 0x06045567 RID: 284007 RVA: 0x0121D018 File Offset: 0x0121B218
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetDisplayKeyNameList(int index = 0)
		{
			if (this.KeyNameMap.Count > 0)
			{
				using (Dictionary<string, string>.Enumerator enumerator = this.KeyNameMap.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, string> keyValuePair = enumerator.Current;
						return new string[]
						{
							keyValuePair.Key,
							keyValuePair.Value
						};
					}
				}
			}
			if (this.KeyNameList.Count > 0)
			{
				return new string[]
				{
					this.KeyNameList[index]
				};
			}
			return null;
		}

		// Token: 0x06045568 RID: 284008 RVA: 0x0121D0B8 File Offset: 0x0121B2B8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] GetDisplayKeyIconPathList(int index = 0)
		{
			string[] displayKeyNameList = this.GetDisplayKeyNameList(index);
			if (displayKeyNameList == null)
			{
				return null;
			}
			string[] array = new string[displayKeyNameList.Length];
			for (int i = 0; i < displayKeyNameList.Length; i++)
			{
				string key = displayKeyNameList[i];
				InputKey key2 = Singleton<InputSettings>.Instance.GetKey(key);
				array[i] = (((key2 != null) ? key2.GetKeyIconPath() : null) ?? "");
			}
			return array;
		}

		// Token: 0x06045569 RID: 284009 RVA: 0x0121D115 File Offset: 0x0121B315
		public bool IsValid()
		{
			return !string.IsNullOrEmpty(this.ActionOrAxisName);
		}

		// Token: 0x0604556A RID: 284010 RVA: 0x0121D125 File Offset: 0x0121B325
		public void Reset()
		{
			this.ActionOrAxisName = null;
			this.KeyNameList.Clear();
			this.KeyNameMap.Clear();
		}

		// Token: 0x04026AD7 RID: 158423
		[Nullable(2)]
		public string ActionOrAxisName;

		// Token: 0x04026AD8 RID: 158424
		public List<string> KeyNameList = new List<string>();

		// Token: 0x04026AD9 RID: 158425
		public Dictionary<string, string> KeyNameMap = new Dictionary<string, string>();

		// Token: 0x04026ADA RID: 158426
		public bool IsCombination;
	}
}
