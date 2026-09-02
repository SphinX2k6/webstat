using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002987 RID: 10631
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerScoreInfoData
{
	// Token: 0x060152FC RID: 86780 RVA: 0x005DDBF3 File Offset: 0x005DBDF3
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerScoreInfoData()
	{
	}

	// Token: 0x0400A2FF RID: 41727
	[RequiredMember]
	public string Title;

	// Token: 0x0400A300 RID: 41728
	[RequiredMember]
	public List<ShipTowerScoreTargetData> TargetList;
}
