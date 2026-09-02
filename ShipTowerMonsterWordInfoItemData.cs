using System;
using System.Runtime.CompilerServices;

// Token: 0x02002994 RID: 10644
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerMonsterWordInfoItemData
{
	// Token: 0x06015306 RID: 86790 RVA: 0x005DDC43 File Offset: 0x005DBE43
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerMonsterWordInfoItemData()
	{
	}

	// Token: 0x0400A337 RID: 41783
	public string Title;

	// Token: 0x0400A338 RID: 41784
	public string TitleColor;

	// Token: 0x0400A339 RID: 41785
	public string IconPath;

	// Token: 0x0400A33A RID: 41786
	[Nullable(1)]
	[RequiredMember]
	public string Desc;
}
