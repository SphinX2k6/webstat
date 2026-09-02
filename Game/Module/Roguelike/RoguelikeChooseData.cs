using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005106 RID: 20742
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeChooseData
	{
		// Token: 0x0603574F RID: 218959 RVA: 0x00D6B1E0 File Offset: 0x00D693E0
		public RoguelikeChooseData(RoguelikeChooseData roguelikeChooseData)
		{
			this.Index = roguelikeChooseData.Index;
			this.RoguelikeGainDataType = new RoguelikeGainDataType?(roguelikeChooseData.Type);
			this.MaxTime = new int?(roguelikeChooseData.MaxTime);
			this.UseTime = new int?(roguelikeChooseData.UseTime);
			this.EventId = new int?(roguelikeChooseData.EventId);
			this.Layer = new int?(roguelikeChooseData.Layer);
			this.IsSelect = new bool?(roguelikeChooseData.IsSelect);
			this.RogueGainEntryList = new List<RogueGainEntry>();
			if (roguelikeChooseData.RogueGainEntryList != null)
			{
				foreach (RogueGainEntry rogueGainEntry in roguelikeChooseData.RogueGainEntryList)
				{
					this.RogueGainEntryList.Add(new RogueGainEntry(rogueGainEntry, new int?(this.Index)));
				}
			}
			this.CostCurrency = roguelikeChooseData.NumItems;
		}

		// Token: 0x0401EB62 RID: 125794
		public int Index;

		// Token: 0x0401EB63 RID: 125795
		public RoguelikeGainDataType? RoguelikeGainDataType;

		// Token: 0x0401EB64 RID: 125796
		public int? MaxTime;

		// Token: 0x0401EB65 RID: 125797
		public int? UseTime;

		// Token: 0x0401EB66 RID: 125798
		public int? EventId;

		// Token: 0x0401EB67 RID: 125799
		public int? Layer;

		// Token: 0x0401EB68 RID: 125800
		public bool? IsSelect;

		// Token: 0x0401EB69 RID: 125801
		public List<RogueGainEntry> RogueGainEntryList;

		// Token: 0x0401EB6A RID: 125802
		public IReadOnlyList<NumItem> CostCurrency;

		// Token: 0x0401EB6B RID: 125803
		[Nullable(2)]
		public Action CallBack;
	}
}
