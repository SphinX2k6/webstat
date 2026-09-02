using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005105 RID: 20741
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueGainEntry
	{
		// Token: 0x0603574B RID: 218955 RVA: 0x00D6AEDB File Offset: 0x00D690DB
		public RogueGainEntry()
		{
		}

		// Token: 0x0603574C RID: 218956 RVA: 0x00D6AEE4 File Offset: 0x00D690E4
		public RogueGainEntry(RogueGainEntry rogueGainEntry, int? bindId = null)
		{
			this.BindId = bindId;
			this.RoguelikeGainDataType = new RoguelikeGainDataType?(rogueGainEntry.Type);
			this.ConfigId = rogueGainEntry.ConfigId;
			this.Index = new int?(rogueGainEntry.Index);
			this.IncId = rogueGainEntry.IncId;
			this.IsSell = new bool?(rogueGainEntry.IsSell);
			this.ElementDict = new Dictionary<int, int>();
			this.IsSelect = rogueGainEntry.IsSelect;
			this.IsNew = rogueGainEntry.IsNew;
			this.Cost = rogueGainEntry.Cost;
			this.RestCount = rogueGainEntry.RestCount;
			this.IsValid = rogueGainEntry.IsValid;
			if (rogueGainEntry.ElementDict != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in rogueGainEntry.ElementDict)
				{
					int value = keyValuePair.Value;
					if (value != 0)
					{
						this.ElementDict.Add(keyValuePair.Key, value);
					}
				}
			}
			if (rogueGainEntry.AffixEntryList == null)
			{
				return;
			}
			this.AffixEntryList = new List<AffixEntry>();
			foreach (AffixEntry affixEntry in rogueGainEntry.AffixEntryList)
			{
				this.AffixEntryList.Add(new AffixEntry(affixEntry));
			}
			if (rogueGainEntry.DiscountInfo != null)
			{
				if (rogueGainEntry.DiscountInfo.BuffPrice != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair2 in rogueGainEntry.DiscountInfo.BuffPrice)
					{
						this.ShopItemCoinId = keyValuePair2.Key;
						this.OriginalPrice = keyValuePair2.Value;
					}
				}
				this.CurrentPrice = new int?(this.OriginalPrice - (int)Math.Floor((double)(this.OriginalPrice * rogueGainEntry.DiscountInfo.Discounted) * 0.01));
				this.Discounted = rogueGainEntry.DiscountInfo.Discounted;
			}
		}

		// Token: 0x0603574D RID: 218957 RVA: 0x00D6B100 File Offset: 0x00D69300
		public List<ElementInfo> GetSortElementInfoArrayByCount(bool bIgnoreTotal = false)
		{
			int num = 9;
			List<ElementInfo> list = new List<ElementInfo>();
			if (this.ElementDict != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in this.ElementDict)
				{
					int key = keyValuePair.Key;
					int value = keyValuePair.Value;
					if (!bIgnoreTotal || key != num)
					{
						list.Add(new ElementInfo(key, value, null));
					}
				}
			}
			list.Sort((ElementInfo a, ElementInfo b) => b.Count - a.Count);
			return list;
		}

		// Token: 0x0603574E RID: 218958 RVA: 0x00D6B1B0 File Offset: 0x00D693B0
		public bool IsDiscounted()
		{
			int? currentPrice = this.CurrentPrice;
			int originalPrice = this.OriginalPrice;
			return !(currentPrice.GetValueOrDefault() == originalPrice & currentPrice != null);
		}

		// Token: 0x0401EB51 RID: 125777
		public RoguelikeGainDataType? RoguelikeGainDataType;

		// Token: 0x0401EB52 RID: 125778
		public int ConfigId;

		// Token: 0x0401EB53 RID: 125779
		public int IncId;

		// Token: 0x0401EB54 RID: 125780
		[Nullable(2)]
		public Dictionary<int, int> ElementDict;

		// Token: 0x0401EB55 RID: 125781
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<AffixEntry> AffixEntryList;

		// Token: 0x0401EB56 RID: 125782
		public int OriginalPrice;

		// Token: 0x0401EB57 RID: 125783
		public int? CurrentPrice;

		// Token: 0x0401EB58 RID: 125784
		public int? Index;

		// Token: 0x0401EB59 RID: 125785
		public int ShopItemCoinId;

		// Token: 0x0401EB5A RID: 125786
		public bool? IsSell;

		// Token: 0x0401EB5B RID: 125787
		public bool IsSelect;

		// Token: 0x0401EB5C RID: 125788
		public bool IsNew;

		// Token: 0x0401EB5D RID: 125789
		public int Discounted;

		// Token: 0x0401EB5E RID: 125790
		public int Cost;

		// Token: 0x0401EB5F RID: 125791
		public int? BindId;

		// Token: 0x0401EB60 RID: 125792
		public int RestCount;

		// Token: 0x0401EB61 RID: 125793
		public bool IsValid;
	}
}
