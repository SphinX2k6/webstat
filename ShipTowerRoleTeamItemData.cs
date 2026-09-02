using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200298D RID: 10637
[RequiredMember]
public class ShipTowerRoleTeamItemData
{
	// Token: 0x060152FF RID: 86783 RVA: 0x005DDC0B File Offset: 0x005DBE0B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerRoleTeamItemData()
	{
	}

	// Token: 0x0400A315 RID: 41749
	[Nullable(1)]
	[RequiredMember]
	public List<int> RoleIdList;

	// Token: 0x0400A316 RID: 41750
	[RequiredMember]
	public int Position;
}
