using System;
using System.Runtime.CompilerServices;

// Token: 0x020019C5 RID: 6597
[NullableContext(2)]
public interface IMediumItemPrice
{
	// Token: 0x17000F71 RID: 3953
	// (get) Token: 0x0600BD5D RID: 48477
	// (set) Token: 0x0600BD5E RID: 48478
	int CurPrice { get; set; }

	// Token: 0x17000F72 RID: 3954
	// (get) Token: 0x0600BD5F RID: 48479
	// (set) Token: 0x0600BD60 RID: 48480
	int? OriginalPrice { get; set; }

	// Token: 0x17000F73 RID: 3955
	// (get) Token: 0x0600BD61 RID: 48481
	// (set) Token: 0x0600BD62 RID: 48482
	string TexPath { get; set; }

	// Token: 0x17000F74 RID: 3956
	// (get) Token: 0x0600BD63 RID: 48483
	// (set) Token: 0x0600BD64 RID: 48484
	bool? CurrencyNotEnough { get; set; }
}
