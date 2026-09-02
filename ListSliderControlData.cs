using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200206D RID: 8301
[NullableContext(1)]
[Nullable(0)]
public class ListSliderControlData<[Nullable(0)] T> : IListSliderControlData<T> where T : SliderItem
{
	// Token: 0x170012CA RID: 4810
	// (get) Token: 0x0600FD09 RID: 64777 RVA: 0x00456D03 File Offset: 0x00454F03
	// (set) Token: 0x0600FD0A RID: 64778 RVA: 0x00456D0B File Offset: 0x00454F0B
	public UUIItem ParentUi { get; set; }

	// Token: 0x170012CB RID: 4811
	// (get) Token: 0x0600FD0B RID: 64779 RVA: 0x00456D14 File Offset: 0x00454F14
	// (set) Token: 0x0600FD0C RID: 64780 RVA: 0x00456D1C File Offset: 0x00454F1C
	public Func<T> CreateProxyFunction { get; set; }

	// Token: 0x170012CC RID: 4812
	// (get) Token: 0x0600FD0D RID: 64781 RVA: 0x00456D25 File Offset: 0x00454F25
	// (set) Token: 0x0600FD0E RID: 64782 RVA: 0x00456D2D File Offset: 0x00454F2D
	public Func<bool> CheckNext { get; set; }

	// Token: 0x170012CD RID: 4813
	// (get) Token: 0x0600FD0F RID: 64783 RVA: 0x00456D36 File Offset: 0x00454F36
	// (set) Token: 0x0600FD10 RID: 64784 RVA: 0x00456D3E File Offset: 0x00454F3E
	[Nullable(2)]
	public UUIItem ChildTemplate { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170012CE RID: 4814
	// (get) Token: 0x0600FD11 RID: 64785 RVA: 0x00456D47 File Offset: 0x00454F47
	// (set) Token: 0x0600FD12 RID: 64786 RVA: 0x00456D4F File Offset: 0x00454F4F
	[Nullable(2)]
	public string ChildResourceId { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170012CF RID: 4815
	// (get) Token: 0x0600FD13 RID: 64787 RVA: 0x00456D58 File Offset: 0x00454F58
	// (set) Token: 0x0600FD14 RID: 64788 RVA: 0x00456D60 File Offset: 0x00454F60
	public int? MaxShowCount { get; set; }

	// Token: 0x170012D0 RID: 4816
	// (get) Token: 0x0600FD15 RID: 64789 RVA: 0x00456D69 File Offset: 0x00454F69
	// (set) Token: 0x0600FD16 RID: 64790 RVA: 0x00456D71 File Offset: 0x00454F71
	public float? AddItemTime { get; set; }

	// Token: 0x170012D1 RID: 4817
	// (get) Token: 0x0600FD17 RID: 64791 RVA: 0x00456D7A File Offset: 0x00454F7A
	// (set) Token: 0x0600FD18 RID: 64792 RVA: 0x00456D82 File Offset: 0x00454F82
	public float? ItemSliderTime { get; set; }

	// Token: 0x170012D2 RID: 4818
	// (get) Token: 0x0600FD19 RID: 64793 RVA: 0x00456D8B File Offset: 0x00454F8B
	// (set) Token: 0x0600FD1A RID: 64794 RVA: 0x00456D93 File Offset: 0x00454F93
	public float? ItemShowTime { get; set; }

	// Token: 0x170012D3 RID: 4819
	// (get) Token: 0x0600FD1B RID: 64795 RVA: 0x00456D9C File Offset: 0x00454F9C
	// (set) Token: 0x0600FD1C RID: 64796 RVA: 0x00456DA4 File Offset: 0x00454FA4
	public ESliderMode? SliderMode { get; set; }

	// Token: 0x170012D4 RID: 4820
	// (get) Token: 0x0600FD1D RID: 64797 RVA: 0x00456DAD File Offset: 0x00454FAD
	// (set) Token: 0x0600FD1E RID: 64798 RVA: 0x00456DB5 File Offset: 0x00454FB5
	public ETickItemMode? TickMode { get; set; }

	// Token: 0x170012D5 RID: 4821
	// (get) Token: 0x0600FD1F RID: 64799 RVA: 0x00456DBE File Offset: 0x00454FBE
	// (set) Token: 0x0600FD20 RID: 64800 RVA: 0x00456DC6 File Offset: 0x00454FC6
	[Nullable(2)]
	public Action FinishCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x0600FD21 RID: 64801 RVA: 0x00456DCF File Offset: 0x00454FCF
	public ListSliderControlData(UUIItem parentUi, Func<T> createProxyFunction, Func<bool> checkNext)
	{
		this.ParentUi = parentUi;
		this.CreateProxyFunction = createProxyFunction;
		this.CheckNext = checkNext;
	}
}
