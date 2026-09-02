using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005102 RID: 20738
	[NullableContext(1)]
	[Nullable(0)]
	public class AffixEntry
	{
		// Token: 0x06035744 RID: 218948 RVA: 0x00D6ABD4 File Offset: 0x00D68DD4
		public AffixEntry(AffixEntry affixEntry)
		{
			this.Id = new int?(affixEntry.Id);
			this.IsUnlock = new bool?(affixEntry.IsUnlock);
			this.ElementDict = new Dictionary<int, int>();
			if (affixEntry.ElementDict != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in affixEntry.ElementDict)
				{
					int value = keyValuePair.Value;
					if (value != 0)
					{
						this.ElementDict.Add(keyValuePair.Key, value);
					}
				}
			}
		}

		// Token: 0x06035745 RID: 218949 RVA: 0x00D6AC74 File Offset: 0x00D68E74
		public List<ElementInfo> GetSortElementInfoArrayByCount(bool bIgnoreTotal = false)
		{
			int num = 9;
			List<ElementInfo> list = new List<ElementInfo>();
			foreach (KeyValuePair<int, int> keyValuePair in this.ElementDict)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (!bIgnoreTotal || key != num)
				{
					list.Add(new ElementInfo(key, value, null));
				}
			}
			list.Sort((ElementInfo a, ElementInfo b) => b.Count - a.Count);
			return list;
		}

		// Token: 0x06035746 RID: 218950 RVA: 0x00D6AD1C File Offset: 0x00D68F1C
		public string GetAffixDesc()
		{
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueAffix? rogueAffix = (instance != null) ? instance.GetRogueAffixConfig(this.Id.Value) : null;
			RoguelikeModel instance2 = ModelBase<RoguelikeModel>.Instance;
			string result;
			if (instance2 == null || instance2.GetDescModel() != EDescModel.SIMPLE)
			{
				if ((result = ((rogueAffix != null) ? rogueAffix.GetValueOrDefault().AffixDesc : null)) == null)
				{
					return "";
				}
			}
			else
			{
				result = (((rogueAffix != null) ? rogueAffix.GetValueOrDefault().AffixDescSimple : null) ?? "");
			}
			return result;
		}

		// Token: 0x0401EB45 RID: 125765
		public int? Id;

		// Token: 0x0401EB46 RID: 125766
		public bool? IsUnlock;

		// Token: 0x0401EB47 RID: 125767
		public readonly Dictionary<int, int> ElementDict;
	}
}
