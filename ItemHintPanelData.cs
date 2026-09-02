using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200205F RID: 8287
[NullableContext(2)]
[Nullable(0)]
public class ItemHintPanelData<[Nullable(0)] T, TData> : IItemHintPanelData<T, TData> where T : ItemHintItemBase<TData>
{
	// Token: 0x170012AF RID: 4783
	// (get) Token: 0x0600FC9D RID: 64669 RVA: 0x00455A7B File Offset: 0x00453C7B
	// (set) Token: 0x0600FC9E RID: 64670 RVA: 0x00455A83 File Offset: 0x00453C83
	[Nullable(1)]
	public Func<TData> ShiftItem { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170012B0 RID: 4784
	// (get) Token: 0x0600FC9F RID: 64671 RVA: 0x00455A8C File Offset: 0x00453C8C
	// (set) Token: 0x0600FCA0 RID: 64672 RVA: 0x00455A94 File Offset: 0x00453C94
	[Nullable(1)]
	public Func<bool> CheckNext { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170012B1 RID: 4785
	// (get) Token: 0x0600FCA1 RID: 64673 RVA: 0x00455A9D File Offset: 0x00453C9D
	// (set) Token: 0x0600FCA2 RID: 64674 RVA: 0x00455AA5 File Offset: 0x00453CA5
	[Nullable(1)]
	public Func<T> CreateProxyFunction { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170012B2 RID: 4786
	// (get) Token: 0x0600FCA3 RID: 64675 RVA: 0x00455AAE File Offset: 0x00453CAE
	// (set) Token: 0x0600FCA4 RID: 64676 RVA: 0x00455AB6 File Offset: 0x00453CB6
	public UUIItem ChildTemplate { get; set; }

	// Token: 0x170012B3 RID: 4787
	// (get) Token: 0x0600FCA5 RID: 64677 RVA: 0x00455ABF File Offset: 0x00453CBF
	// (set) Token: 0x0600FCA6 RID: 64678 RVA: 0x00455AC7 File Offset: 0x00453CC7
	public string ChildResourceId { get; set; }

	// Token: 0x170012B4 RID: 4788
	// (get) Token: 0x0600FCA7 RID: 64679 RVA: 0x00455AD0 File Offset: 0x00453CD0
	// (set) Token: 0x0600FCA8 RID: 64680 RVA: 0x00455AD8 File Offset: 0x00453CD8
	public string TitleTextId { get; set; }

	// Token: 0x170012B5 RID: 4789
	// (get) Token: 0x0600FCA9 RID: 64681 RVA: 0x00455AE1 File Offset: 0x00453CE1
	// (set) Token: 0x0600FCAA RID: 64682 RVA: 0x00455AE9 File Offset: 0x00453CE9
	public int? MaxShowCount { get; set; }

	// Token: 0x170012B6 RID: 4790
	// (get) Token: 0x0600FCAB RID: 64683 RVA: 0x00455AF2 File Offset: 0x00453CF2
	// (set) Token: 0x0600FCAC RID: 64684 RVA: 0x00455AFA File Offset: 0x00453CFA
	public int? AddItemTime { get; set; }

	// Token: 0x170012B7 RID: 4791
	// (get) Token: 0x0600FCAD RID: 64685 RVA: 0x00455B03 File Offset: 0x00453D03
	// (set) Token: 0x0600FCAE RID: 64686 RVA: 0x00455B0B File Offset: 0x00453D0B
	public int? ItemSliderTime { get; set; }

	// Token: 0x170012B8 RID: 4792
	// (get) Token: 0x0600FCAF RID: 64687 RVA: 0x00455B14 File Offset: 0x00453D14
	// (set) Token: 0x0600FCB0 RID: 64688 RVA: 0x00455B1C File Offset: 0x00453D1C
	public int? ItemShowTime { get; set; }

	// Token: 0x170012B9 RID: 4793
	// (get) Token: 0x0600FCB1 RID: 64689 RVA: 0x00455B25 File Offset: 0x00453D25
	// (set) Token: 0x0600FCB2 RID: 64690 RVA: 0x00455B2D File Offset: 0x00453D2D
	public ESliderMode? SliderMode { get; set; }

	// Token: 0x170012BA RID: 4794
	// (get) Token: 0x0600FCB3 RID: 64691 RVA: 0x00455B36 File Offset: 0x00453D36
	// (set) Token: 0x0600FCB4 RID: 64692 RVA: 0x00455B3E File Offset: 0x00453D3E
	public ETickItemMode? TickMode { get; set; }

	// Token: 0x170012BB RID: 4795
	// (get) Token: 0x0600FCB5 RID: 64693 RVA: 0x00455B47 File Offset: 0x00453D47
	// (set) Token: 0x0600FCB6 RID: 64694 RVA: 0x00455B4F File Offset: 0x00453D4F
	public Action FinishCallback { get; set; }
}
