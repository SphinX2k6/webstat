using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020028A9 RID: 10409
public class RoleSkillBranchTeamTabData : IRoleSkillBranchTeamTabData
{
	// Token: 0x17001B19 RID: 6937
	// (get) Token: 0x06014AAA RID: 84650 RVA: 0x005B9680 File Offset: 0x005B7880
	// (set) Token: 0x06014AAB RID: 84651 RVA: 0x005B9688 File Offset: 0x005B7888
	public int TeamIndex { get; set; }

	// Token: 0x17001B1A RID: 6938
	// (get) Token: 0x06014AAC RID: 84652 RVA: 0x005B9691 File Offset: 0x005B7891
	// (set) Token: 0x06014AAD RID: 84653 RVA: 0x005B9699 File Offset: 0x005B7899
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
	public List<ValueTuple<int, int>> RoleSkillBranchTeamDataList { [return: TupleElementNames(new string[]
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
	})] set; } = new List<ValueTuple<int, int>>();
}
