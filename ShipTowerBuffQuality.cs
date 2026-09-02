using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002985 RID: 10629
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerBuffQuality
{
	// Token: 0x060152FA RID: 86778 RVA: 0x005DDBE3 File Offset: 0x005DBDE3
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerBuffQuality()
	{
	}

	// Token: 0x0400A2F8 RID: 41720
	[RequiredMember]
	public int Quality;

	// Token: 0x0400A2F9 RID: 41721
	[RequiredMember]
	public string Title;

	// Token: 0x0400A2FA RID: 41722
	[RequiredMember]
	public List<ShipTowerBuffData> BuffList;
}
