using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020028A8 RID: 10408
public interface IRoleSkillBranchTeamTabData
{
	// Token: 0x17001B17 RID: 6935
	// (get) Token: 0x06014AA6 RID: 84646
	// (set) Token: 0x06014AA7 RID: 84647
	int TeamIndex { get; set; }

	// Token: 0x17001B18 RID: 6936
	// (get) Token: 0x06014AA8 RID: 84648
	// (set) Token: 0x06014AA9 RID: 84649
	[TupleElementNames(new string[]
	{
		"RoleId",
		"SkillBranchIndex"
	})]
	[Nullable(new byte[]
	{
		1,
		0
	})]
	List<ValueTuple<int, int>> RoleSkillBranchTeamDataList { [return: TupleElementNames(new string[]
	{
		"RoleId",
		"SkillBranchIndex"
	})] [return: Nullable(new byte[]
	{
		1,
		0
	})] get; [param: TupleElementNames(new string[]
	{
		"RoleId",
		"SkillBranchIndex"
	})] [param: Nullable(new byte[]
	{
		1,
		0
	})] set; }
}
