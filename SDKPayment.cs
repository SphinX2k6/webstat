using System;
using System.Runtime.CompilerServices;

// Token: 0x02000ED9 RID: 3801
[NullableContext(1)]
[Nullable(0)]
public class SDKPayment : ISDKPayment
{
	// Token: 0x170006C1 RID: 1729
	// (get) Token: 0x06005DB8 RID: 23992 RVA: 0x0017825A File Offset: 0x0017645A
	// (set) Token: 0x06005DB9 RID: 23993 RVA: 0x00178262 File Offset: 0x00176462
	public string product_id { get; set; }

	// Token: 0x170006C2 RID: 1730
	// (get) Token: 0x06005DBA RID: 23994 RVA: 0x0017826B File Offset: 0x0017646B
	// (set) Token: 0x06005DBB RID: 23995 RVA: 0x00178273 File Offset: 0x00176473
	public string cpOrderId { get; set; }

	// Token: 0x170006C3 RID: 1731
	// (get) Token: 0x06005DBC RID: 23996 RVA: 0x0017827C File Offset: 0x0017647C
	// (set) Token: 0x06005DBD RID: 23997 RVA: 0x00178284 File Offset: 0x00176484
	public string price { get; set; }

	// Token: 0x170006C4 RID: 1732
	// (get) Token: 0x06005DBE RID: 23998 RVA: 0x0017828D File Offset: 0x0017648D
	// (set) Token: 0x06005DBF RID: 23999 RVA: 0x00178295 File Offset: 0x00176495
	public string goodsName { get; set; }

	// Token: 0x170006C5 RID: 1733
	// (get) Token: 0x06005DC0 RID: 24000 RVA: 0x0017829E File Offset: 0x0017649E
	// (set) Token: 0x06005DC1 RID: 24001 RVA: 0x001782A6 File Offset: 0x001764A6
	public string goodsDesc { get; set; }

	// Token: 0x170006C6 RID: 1734
	// (get) Token: 0x06005DC2 RID: 24002 RVA: 0x001782AF File Offset: 0x001764AF
	// (set) Token: 0x06005DC3 RID: 24003 RVA: 0x001782B7 File Offset: 0x001764B7
	[Nullable(2)]
	public string extraParams { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170006C7 RID: 1735
	// (get) Token: 0x06005DC4 RID: 24004 RVA: 0x001782C0 File Offset: 0x001764C0
	// (set) Token: 0x06005DC5 RID: 24005 RVA: 0x001782C8 File Offset: 0x001764C8
	[Nullable(2)]
	public string callbackUrl { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170006C8 RID: 1736
	// (get) Token: 0x06005DC6 RID: 24006 RVA: 0x001782D1 File Offset: 0x001764D1
	// (set) Token: 0x06005DC7 RID: 24007 RVA: 0x001782D9 File Offset: 0x001764D9
	public string currency { get; set; }
}
