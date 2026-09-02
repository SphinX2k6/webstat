using System;

// Token: 0x02001B41 RID: 6977
public class EditFormationRoleData
{
	// Token: 0x0600C9BA RID: 51642 RVA: 0x0035996A File Offset: 0x00357B6A
	public EditFormationRoleData(int position, int configId, int roleSkinId, int level, int playerId, int multiSkillBranchIndex)
	{
		this.Position = position;
		this.ConfigId = configId;
		this.RoleSkinId = roleSkinId;
		this.PlayerId = playerId;
		this.Level = level;
		this.MultiSkillBranchIndex = multiSkillBranchIndex;
	}

	// Token: 0x0400607F RID: 24703
	public readonly int Position;

	// Token: 0x04006080 RID: 24704
	public readonly int ConfigId;

	// Token: 0x04006081 RID: 24705
	public readonly int RoleSkinId;

	// Token: 0x04006082 RID: 24706
	public readonly int PlayerId;

	// Token: 0x04006083 RID: 24707
	public readonly int Level;

	// Token: 0x04006084 RID: 24708
	public readonly int MultiSkillBranchIndex;
}
