using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001232 RID: 4658
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerPresetTeamData
{
	// Token: 0x06007BFE RID: 31742 RVA: 0x00209269 File Offset: 0x00207469
	public BabelTowerPresetTeamData(int teamId, int teamIndex, List<int> roleIdList)
	{
		this.TeamId = teamId;
		this.TeamIndex = teamIndex;
		this.RoleIdList = roleIdList;
	}

	// Token: 0x06007BFF RID: 31743 RVA: 0x00209291 File Offset: 0x00207491
	public int GetTeamId()
	{
		return this.TeamId;
	}

	// Token: 0x06007C00 RID: 31744 RVA: 0x00209299 File Offset: 0x00207499
	public int GetTeamIndex()
	{
		return this.TeamIndex;
	}

	// Token: 0x06007C01 RID: 31745 RVA: 0x002092A1 File Offset: 0x002074A1
	public List<int> GetRoleIdList()
	{
		return this.RoleIdList;
	}

	// Token: 0x04003B4E RID: 15182
	private readonly int TeamId;

	// Token: 0x04003B4F RID: 15183
	private readonly int TeamIndex;

	// Token: 0x04003B50 RID: 15184
	private readonly List<int> RoleIdList = new List<int>();
}
