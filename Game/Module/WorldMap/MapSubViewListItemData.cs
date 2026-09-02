using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B3D RID: 19261
	[NullableContext(2)]
	[Nullable(0)]
	public class MapSubViewListItemData : IMapSubViewListItemData
	{
		// Token: 0x1700862B RID: 34347
		// (get) Token: 0x060323EB RID: 205803 RVA: 0x00C8FC11 File Offset: 0x00C8DE11
		// (set) Token: 0x060323EC RID: 205804 RVA: 0x00C8FC19 File Offset: 0x00C8DE19
		[Nullable(1)]
		public string LeftTextId { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x1700862C RID: 34348
		// (get) Token: 0x060323ED RID: 205805 RVA: 0x00C8FC22 File Offset: 0x00C8DE22
		// (set) Token: 0x060323EE RID: 205806 RVA: 0x00C8FC2A File Offset: 0x00C8DE2A
		public string LeftText { get; set; }

		// Token: 0x1700862D RID: 34349
		// (get) Token: 0x060323EF RID: 205807 RVA: 0x00C8FC33 File Offset: 0x00C8DE33
		// (set) Token: 0x060323F0 RID: 205808 RVA: 0x00C8FC3B File Offset: 0x00C8DE3B
		public string RightTextId { get; set; }

		// Token: 0x1700862E RID: 34350
		// (get) Token: 0x060323F1 RID: 205809 RVA: 0x00C8FC44 File Offset: 0x00C8DE44
		// (set) Token: 0x060323F2 RID: 205810 RVA: 0x00C8FC4C File Offset: 0x00C8DE4C
		public string RightText { get; set; }

		// Token: 0x1700862F RID: 34351
		// (get) Token: 0x060323F3 RID: 205811 RVA: 0x00C8FC55 File Offset: 0x00C8DE55
		// (set) Token: 0x060323F4 RID: 205812 RVA: 0x00C8FC5D File Offset: 0x00C8DE5D
		public bool ShowBtnHelp { get; set; }

		// Token: 0x17008630 RID: 34352
		// (get) Token: 0x060323F5 RID: 205813 RVA: 0x00C8FC66 File Offset: 0x00C8DE66
		// (set) Token: 0x060323F6 RID: 205814 RVA: 0x00C8FC6E File Offset: 0x00C8DE6E
		public Action OnBtnClickCb { get; set; }

		// Token: 0x17008631 RID: 34353
		// (get) Token: 0x060323F7 RID: 205815 RVA: 0x00C8FC77 File Offset: 0x00C8DE77
		// (set) Token: 0x060323F8 RID: 205816 RVA: 0x00C8FC7F File Offset: 0x00C8DE7F
		public bool ShowIcon { get; set; }

		// Token: 0x17008632 RID: 34354
		// (get) Token: 0x060323F9 RID: 205817 RVA: 0x00C8FC88 File Offset: 0x00C8DE88
		// (set) Token: 0x060323FA RID: 205818 RVA: 0x00C8FC90 File Offset: 0x00C8DE90
		public bool ShowSprite { get; set; }

		// Token: 0x17008633 RID: 34355
		// (get) Token: 0x060323FB RID: 205819 RVA: 0x00C8FC99 File Offset: 0x00C8DE99
		// (set) Token: 0x060323FC RID: 205820 RVA: 0x00C8FCA1 File Offset: 0x00C8DEA1
		public bool ShowScaleIcon { get; set; }

		// Token: 0x17008634 RID: 34356
		// (get) Token: 0x060323FD RID: 205821 RVA: 0x00C8FCAA File Offset: 0x00C8DEAA
		// (set) Token: 0x060323FE RID: 205822 RVA: 0x00C8FCB2 File Offset: 0x00C8DEB2
		public string ScaleIconPath { get; set; }
	}
}
