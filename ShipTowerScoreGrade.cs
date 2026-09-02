using System;
using System.Runtime.CompilerServices;

// Token: 0x02002990 RID: 10640
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerScoreGrade
{
	// Token: 0x06015302 RID: 86786 RVA: 0x005DDC23 File Offset: 0x005DBE23
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerScoreGrade()
	{
	}

	// Token: 0x0400A329 RID: 41769
	[RequiredMember]
	public string ResId;

	// Token: 0x0400A32A RID: 41770
	[RequiredMember]
	public string BigResId;

	// Token: 0x0400A32B RID: 41771
	[RequiredMember]
	public int Index;
}
