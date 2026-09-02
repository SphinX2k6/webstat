using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay
{
	// Token: 0x02004BD8 RID: 19416
	[NullableContext(2)]
	[Nullable(0)]
	public class MapMoraleLvItemData : IMapMoraleLvItemData
	{
		// Token: 0x1700870B RID: 34571
		// (get) Token: 0x06032AB1 RID: 207537 RVA: 0x00CB0B2F File Offset: 0x00CAED2F
		// (set) Token: 0x06032AB2 RID: 207538 RVA: 0x00CB0B37 File Offset: 0x00CAED37
		[Nullable(1)]
		public string TitleId { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700870C RID: 34572
		// (get) Token: 0x06032AB3 RID: 207539 RVA: 0x00CB0B40 File Offset: 0x00CAED40
		// (set) Token: 0x06032AB4 RID: 207540 RVA: 0x00CB0B48 File Offset: 0x00CAED48
		public int Lv { get; set; }

		// Token: 0x1700870D RID: 34573
		// (get) Token: 0x06032AB5 RID: 207541 RVA: 0x00CB0B51 File Offset: 0x00CAED51
		// (set) Token: 0x06032AB6 RID: 207542 RVA: 0x00CB0B59 File Offset: 0x00CAED59
		public string LvColor { get; set; }

		// Token: 0x1700870E RID: 34574
		// (get) Token: 0x06032AB7 RID: 207543 RVA: 0x00CB0B62 File Offset: 0x00CAED62
		// (set) Token: 0x06032AB8 RID: 207544 RVA: 0x00CB0B6A File Offset: 0x00CAED6A
		public string BgColor { get; set; }
	}
}
