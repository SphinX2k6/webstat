using System;
using System.Runtime.CompilerServices;

// Token: 0x020017D9 RID: 6105
[NullableContext(2)]
public interface IRefineAttrSelectViewOpenParam
{
	// Token: 0x17000E0C RID: 3596
	// (get) Token: 0x0600AD4B RID: 44363
	// (set) Token: 0x0600AD4C RID: 44364
	int IncId { get; set; }

	// Token: 0x17000E0D RID: 3597
	// (get) Token: 0x0600AD4D RID: 44365
	// (set) Token: 0x0600AD4E RID: 44366
	bool DataConfirmed { get; set; }

	// Token: 0x17000E0E RID: 3598
	// (get) Token: 0x0600AD4F RID: 44367
	// (set) Token: 0x0600AD50 RID: 44368
	IRefineAttrItemData SelectAttribute { get; set; }

	// Token: 0x17000E0F RID: 3599
	// (get) Token: 0x0600AD51 RID: 44369
	// (set) Token: 0x0600AD52 RID: 44370
	Action<IRefineAttrItemData> Callback { get; set; }

	// Token: 0x17000E10 RID: 3600
	// (get) Token: 0x0600AD53 RID: 44371
	// (set) Token: 0x0600AD54 RID: 44372
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Func<int[]> GetSelectedPropItemIdList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
