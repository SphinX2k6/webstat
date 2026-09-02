using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005175 RID: 20853
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueInfoViewModel
	{
		// Token: 0x06035A96 RID: 219798 RVA: 0x00D7ACBD File Offset: 0x00D78EBD
		public RogueInfoViewModel(RoguelikeInfo rogueInfoInternal)
		{
			this.RogueInfoInternal = rogueInfoInternal;
		}

		// Token: 0x17008C84 RID: 35972
		// (get) Token: 0x06035A97 RID: 219799 RVA: 0x00D7ACD3 File Offset: 0x00D78ED3
		public RoguelikeInfo RogueInfo
		{
			get
			{
				return this.RogueInfoInternal;
			}
		}

		// Token: 0x17008C85 RID: 35973
		// (get) Token: 0x06035A98 RID: 219800 RVA: 0x00D7ACDB File Offset: 0x00D78EDB
		public RogueGainEntry RoleEntry
		{
			get
			{
				return this.RogueInfoInternal.RoleEntry;
			}
		}

		// Token: 0x17008C86 RID: 35974
		// (get) Token: 0x06035A99 RID: 219801 RVA: 0x00D7ACE8 File Offset: 0x00D78EE8
		[Nullable(2)]
		public RogueGainEntry PhantomEntry
		{
			[NullableContext(2)]
			get
			{
				return this.RogueInfoInternal.PhantomEntry;
			}
		}

		// Token: 0x17008C87 RID: 35975
		// (get) Token: 0x06035A9A RID: 219802 RVA: 0x00D7ACF5 File Offset: 0x00D78EF5
		public List<RogueGainEntry> BuffEntryList
		{
			get
			{
				return this.RogueInfoInternal.BuffEntryList;
			}
		}

		// Token: 0x17008C88 RID: 35976
		// (get) Token: 0x06035A9B RID: 219803 RVA: 0x00D7AD02 File Offset: 0x00D78F02
		public List<RogueGainEntry> SpecialEntryList
		{
			get
			{
				return this.RogueInfoInternal.SpecialEntryList;
			}
		}

		// Token: 0x06035A9C RID: 219804 RVA: 0x00D7AD10 File Offset: 0x00D78F10
		public List<ElementInfo> GetElementInfoList()
		{
			List<ElementInfo> list = new List<ElementInfo>();
			foreach (int num in ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null).Value.ElementList())
			{
				int count = this.RogueInfoInternal.ElementDict.ContainsKey(num) ? this.RogueInfoInternal.ElementDict[num] : 0;
				list.Add(new ElementInfo(num, count, null));
			}
			return list;
		}

		// Token: 0x06035A9D RID: 219805 RVA: 0x00D7AD9E File Offset: 0x00D78F9E
		public bool IsBuffEntryEmpty()
		{
			return this.BuffEntryList.Count <= 0;
		}

		// Token: 0x06035A9E RID: 219806 RVA: 0x00D7ADB1 File Offset: 0x00D78FB1
		public bool IsSpecialEntryEmpty()
		{
			return this.SpecialEntryList.Count <= 0;
		}

		// Token: 0x06035A9F RID: 219807 RVA: 0x00D7ADC4 File Offset: 0x00D78FC4
		public List<AttrListScrollData> GetAttrList()
		{
			return this.RogueInfoInternal.GetShowAttrList();
		}

		// Token: 0x0401ECEC RID: 126188
		public bool ShowCurrency = true;

		// Token: 0x0401ECED RID: 126189
		public ERogueInfoViewPage DefaultPage;

		// Token: 0x0401ECEE RID: 126190
		private RoguelikeInfo RogueInfoInternal;
	}
}
