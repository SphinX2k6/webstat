using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02002988 RID: 10632
[RequiredMember]
public class ShipTowerRoleData : HaveAreaInfo
{
	// Token: 0x060152FD RID: 86781 RVA: 0x005DDBFB File Offset: 0x005DBDFB
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerRoleData()
	{
	}

	// Token: 0x0400A301 RID: 41729
	[RequiredMember]
	public int RoleId;

	// Token: 0x0400A302 RID: 41730
	[RequiredMember]
	public int RoleIdEdit;

	// Token: 0x0400A303 RID: 41731
	[RequiredMember]
	public int TeamIndex;

	// Token: 0x0400A304 RID: 41732
	[RequiredMember]
	public int TeamId;

	// Token: 0x0400A305 RID: 41733
	[RequiredMember]
	public int PositionIndex;

	// Token: 0x0400A306 RID: 41734
	public int SkillBranchId;

	// Token: 0x0400A307 RID: 41735
	public int SkillBranchIdEdit;
}
