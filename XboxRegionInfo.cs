using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EE6 RID: 3814
[NullableContext(1)]
[Nullable(0)]
public class XboxRegionInfo
{
	// Token: 0x170006EA RID: 1770
	// (get) Token: 0x06005E0E RID: 24078 RVA: 0x00178439 File Offset: 0x00176639
	// (set) Token: 0x06005E0F RID: 24079 RVA: 0x00178441 File Offset: 0x00176641
	public int Code { get; set; }

	// Token: 0x170006EB RID: 1771
	// (get) Token: 0x06005E10 RID: 24080 RVA: 0x0017844A File Offset: 0x0017664A
	// (set) Token: 0x06005E11 RID: 24081 RVA: 0x00178452 File Offset: 0x00176652
	public int SdkLoginCode { get; set; }

	// Token: 0x170006EC RID: 1772
	// (get) Token: 0x06005E12 RID: 24082 RVA: 0x0017845B File Offset: 0x0017665B
	// (set) Token: 0x06005E13 RID: 24083 RVA: 0x00178463 File Offset: 0x00176663
	public string Region { get; set; } = "";
}
