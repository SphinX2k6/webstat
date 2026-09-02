using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020017DE RID: 6110
public class VisionRefineTabViewParam : IVisionRefineTabViewParam
{
	// Token: 0x17000E1F RID: 3615
	// (get) Token: 0x0600AD72 RID: 44402 RVA: 0x002E30BE File Offset: 0x002E12BE
	// (set) Token: 0x0600AD73 RID: 44403 RVA: 0x002E30C6 File Offset: 0x002E12C6
	public ERefineViewState ViewState { get; set; }

	// Token: 0x17000E20 RID: 3616
	// (get) Token: 0x0600AD74 RID: 44404 RVA: 0x002E30CF File Offset: 0x002E12CF
	// (set) Token: 0x0600AD75 RID: 44405 RVA: 0x002E30D7 File Offset: 0x002E12D7
	public EVisionRefineRefineType? RefineType { get; set; }

	// Token: 0x17000E21 RID: 3617
	// (get) Token: 0x0600AD76 RID: 44406 RVA: 0x002E30E0 File Offset: 0x002E12E0
	// (set) Token: 0x0600AD77 RID: 44407 RVA: 0x002E30E8 File Offset: 0x002E12E8
	public int? UniqueId { get; set; }

	// Token: 0x17000E22 RID: 3618
	// (get) Token: 0x0600AD78 RID: 44408 RVA: 0x002E30F1 File Offset: 0x002E12F1
	// (set) Token: 0x0600AD79 RID: 44409 RVA: 0x002E30F9 File Offset: 0x002E12F9
	public bool? ActiveCaptionItem { get; set; }

	// Token: 0x17000E23 RID: 3619
	// (get) Token: 0x0600AD7A RID: 44410 RVA: 0x002E3102 File Offset: 0x002E1302
	// (set) Token: 0x0600AD7B RID: 44411 RVA: 0x002E310A File Offset: 0x002E130A
	public bool? SlotInteractive { get; set; }

	// Token: 0x17000E24 RID: 3620
	// (get) Token: 0x0600AD7C RID: 44412 RVA: 0x002E3113 File Offset: 0x002E1313
	// (set) Token: 0x0600AD7D RID: 44413 RVA: 0x002E311B File Offset: 0x002E131B
	public bool? ResultShowTips { get; set; }

	// Token: 0x17000E25 RID: 3621
	// (get) Token: 0x0600AD7E RID: 44414 RVA: 0x002E3124 File Offset: 0x002E1324
	// (set) Token: 0x0600AD7F RID: 44415 RVA: 0x002E312C File Offset: 0x002E132C
	public bool? IsSingleMode { get; set; }

	// Token: 0x17000E26 RID: 3622
	// (get) Token: 0x0600AD80 RID: 44416 RVA: 0x002E3135 File Offset: 0x002E1335
	// (set) Token: 0x0600AD81 RID: 44417 RVA: 0x002E313D File Offset: 0x002E133D
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int[]> CurrencyChangeCallback { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000E27 RID: 3623
	// (get) Token: 0x0600AD82 RID: 44418 RVA: 0x002E3146 File Offset: 0x002E1346
	// (set) Token: 0x0600AD83 RID: 44419 RVA: 0x002E314E File Offset: 0x002E134E
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<AttrRecommendInfo> RecommendRefineSubList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
