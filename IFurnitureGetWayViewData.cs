using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001091 RID: 4241
[NullableContext(2)]
public interface IFurnitureGetWayViewData
{
	// Token: 0x170008F0 RID: 2288
	// (get) Token: 0x06006E93 RID: 28307
	// (set) Token: 0x06006E94 RID: 28308
	Furniture FurnitureConfig { get; set; }

	// Token: 0x170008F1 RID: 2289
	// (get) Token: 0x06006E95 RID: 28309
	// (set) Token: 0x06006E96 RID: 28310
	EFurnitureLockReason LockReason { get; set; }

	// Token: 0x170008F2 RID: 2290
	// (get) Token: 0x06006E97 RID: 28311
	// (set) Token: 0x06006E98 RID: 28312
	[Nullable(1)]
	string LockReasonTextId { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170008F3 RID: 2291
	// (get) Token: 0x06006E99 RID: 28313
	// (set) Token: 0x06006E9A RID: 28314
	[Nullable(new byte[]
	{
		2,
		1
	})]
	string[] LockReasonTextParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170008F4 RID: 2292
	// (get) Token: 0x06006E9B RID: 28315
	// (set) Token: 0x06006E9C RID: 28316
	Action JumpFunction { get; set; }

	// Token: 0x170008F5 RID: 2293
	// (get) Token: 0x06006E9D RID: 28317
	// (set) Token: 0x06006E9E RID: 28318
	Action ConfirmFunction { get; set; }
}
