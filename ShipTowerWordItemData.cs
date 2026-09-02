using System;
using System.Runtime.CompilerServices;

// Token: 0x02002995 RID: 10645
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerWordItemData
{
	// Token: 0x06015307 RID: 86791 RVA: 0x005DDC4B File Offset: 0x005DBE4B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerWordItemData()
	{
	}

	// Token: 0x0400A33B RID: 41787
	[RequiredMember]
	public string Title;

	// Token: 0x0400A33C RID: 41788
	[Nullable(2)]
	public string TitleColor;

	// Token: 0x0400A33D RID: 41789
	[RequiredMember]
	public string IconPath;
}
