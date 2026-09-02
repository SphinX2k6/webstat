using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001092 RID: 4242
[NullableContext(2)]
[Nullable(0)]
public class FurnitureGetWayViewData : IFurnitureGetWayViewData
{
	// Token: 0x170008F6 RID: 2294
	// (get) Token: 0x06006E9F RID: 28319 RVA: 0x001CCD52 File Offset: 0x001CAF52
	// (set) Token: 0x06006EA0 RID: 28320 RVA: 0x001CCD5A File Offset: 0x001CAF5A
	public Furniture FurnitureConfig { get; set; }

	// Token: 0x170008F7 RID: 2295
	// (get) Token: 0x06006EA1 RID: 28321 RVA: 0x001CCD63 File Offset: 0x001CAF63
	// (set) Token: 0x06006EA2 RID: 28322 RVA: 0x001CCD6B File Offset: 0x001CAF6B
	public EFurnitureLockReason LockReason { get; set; }

	// Token: 0x170008F8 RID: 2296
	// (get) Token: 0x06006EA3 RID: 28323 RVA: 0x001CCD74 File Offset: 0x001CAF74
	// (set) Token: 0x06006EA4 RID: 28324 RVA: 0x001CCD7C File Offset: 0x001CAF7C
	[Nullable(1)]
	public string LockReasonTextId { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170008F9 RID: 2297
	// (get) Token: 0x06006EA5 RID: 28325 RVA: 0x001CCD85 File Offset: 0x001CAF85
	// (set) Token: 0x06006EA6 RID: 28326 RVA: 0x001CCD8D File Offset: 0x001CAF8D
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] LockReasonTextParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170008FA RID: 2298
	// (get) Token: 0x06006EA7 RID: 28327 RVA: 0x001CCD96 File Offset: 0x001CAF96
	// (set) Token: 0x06006EA8 RID: 28328 RVA: 0x001CCD9E File Offset: 0x001CAF9E
	public Action JumpFunction { get; set; }

	// Token: 0x170008FB RID: 2299
	// (get) Token: 0x06006EA9 RID: 28329 RVA: 0x001CCDA7 File Offset: 0x001CAFA7
	// (set) Token: 0x06006EAA RID: 28330 RVA: 0x001CCDAF File Offset: 0x001CAFAF
	public Action ConfirmFunction { get; set; }
}
