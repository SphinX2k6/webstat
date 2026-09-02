using System;
using System.Runtime.CompilerServices;

// Token: 0x020017DA RID: 6106
[NullableContext(2)]
[Nullable(0)]
public class RefineAttrSelectViewOpenParam : IRefineAttrSelectViewOpenParam
{
	// Token: 0x17000E11 RID: 3601
	// (get) Token: 0x0600AD55 RID: 44373 RVA: 0x002E3061 File Offset: 0x002E1261
	// (set) Token: 0x0600AD56 RID: 44374 RVA: 0x002E3069 File Offset: 0x002E1269
	public int IncId { get; set; }

	// Token: 0x17000E12 RID: 3602
	// (get) Token: 0x0600AD57 RID: 44375 RVA: 0x002E3072 File Offset: 0x002E1272
	// (set) Token: 0x0600AD58 RID: 44376 RVA: 0x002E307A File Offset: 0x002E127A
	public bool DataConfirmed { get; set; }

	// Token: 0x17000E13 RID: 3603
	// (get) Token: 0x0600AD59 RID: 44377 RVA: 0x002E3083 File Offset: 0x002E1283
	// (set) Token: 0x0600AD5A RID: 44378 RVA: 0x002E308B File Offset: 0x002E128B
	public IRefineAttrItemData SelectAttribute { get; set; }

	// Token: 0x17000E14 RID: 3604
	// (get) Token: 0x0600AD5B RID: 44379 RVA: 0x002E3094 File Offset: 0x002E1294
	// (set) Token: 0x0600AD5C RID: 44380 RVA: 0x002E309C File Offset: 0x002E129C
	public Action<IRefineAttrItemData> Callback { get; set; }

	// Token: 0x17000E15 RID: 3605
	// (get) Token: 0x0600AD5D RID: 44381 RVA: 0x002E30A5 File Offset: 0x002E12A5
	// (set) Token: 0x0600AD5E RID: 44382 RVA: 0x002E30AD File Offset: 0x002E12AD
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<int[]> GetSelectedPropItemIdList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
