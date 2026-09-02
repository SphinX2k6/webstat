using System;
using System.Runtime.CompilerServices;

// Token: 0x02000ED8 RID: 3800
[NullableContext(1)]
public interface ISDKPayment
{
	// Token: 0x170006B9 RID: 1721
	// (get) Token: 0x06005DA8 RID: 23976
	// (set) Token: 0x06005DA9 RID: 23977
	string product_id { get; set; }

	// Token: 0x170006BA RID: 1722
	// (get) Token: 0x06005DAA RID: 23978
	// (set) Token: 0x06005DAB RID: 23979
	string cpOrderId { get; set; }

	// Token: 0x170006BB RID: 1723
	// (get) Token: 0x06005DAC RID: 23980
	// (set) Token: 0x06005DAD RID: 23981
	string price { get; set; }

	// Token: 0x170006BC RID: 1724
	// (get) Token: 0x06005DAE RID: 23982
	// (set) Token: 0x06005DAF RID: 23983
	string goodsName { get; set; }

	// Token: 0x170006BD RID: 1725
	// (get) Token: 0x06005DB0 RID: 23984
	// (set) Token: 0x06005DB1 RID: 23985
	string goodsDesc { get; set; }

	// Token: 0x170006BE RID: 1726
	// (get) Token: 0x06005DB2 RID: 23986
	// (set) Token: 0x06005DB3 RID: 23987
	[Nullable(2)]
	string extraParams { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170006BF RID: 1727
	// (get) Token: 0x06005DB4 RID: 23988
	// (set) Token: 0x06005DB5 RID: 23989
	[Nullable(2)]
	string callbackUrl { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170006C0 RID: 1728
	// (get) Token: 0x06005DB6 RID: 23990
	// (set) Token: 0x06005DB7 RID: 23991
	string currency { get; set; }
}
