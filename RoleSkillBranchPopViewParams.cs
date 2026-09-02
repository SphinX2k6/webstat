using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020028AA RID: 10410
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillBranchPopViewParams
{
	// Token: 0x17001B1B RID: 6939
	// (get) Token: 0x06014AAF RID: 84655 RVA: 0x005B96B5 File Offset: 0x005B78B5
	// (set) Token: 0x06014AB0 RID: 84656 RVA: 0x005B96BD File Offset: 0x005B78BD
	public List<RoleSkillBranchTeamTabData> RoleSkillBranchTeamTabDataList { get; set; } = new List<RoleSkillBranchTeamTabData>();

	// Token: 0x17001B1C RID: 6940
	// (get) Token: 0x06014AB1 RID: 84657 RVA: 0x005B96C6 File Offset: 0x005B78C6
	// (set) Token: 0x06014AB2 RID: 84658 RVA: 0x005B96CE File Offset: 0x005B78CE
	public int? PreferredTabIndex { get; set; }

	// Token: 0x06014AB3 RID: 84659 RVA: 0x005B96D8 File Offset: 0x005B78D8
	public void Load(int[][] roleIdTab)
	{
		this.RoleSkillBranchTeamTabDataList.Clear();
		for (int i = 0; i < roleIdTab.Length; i++)
		{
			int[] array = roleIdTab[i];
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			foreach (int num in array)
			{
				if (num > 0)
				{
					int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(num);
					list.Add(new ValueTuple<int, int>(num, roleSkillBranchIndexInCurrentGamePlay));
				}
			}
			this.RoleSkillBranchTeamTabDataList.Add(new RoleSkillBranchTeamTabData
			{
				TeamIndex = i,
				RoleSkillBranchTeamDataList = list
			});
		}
	}
}
