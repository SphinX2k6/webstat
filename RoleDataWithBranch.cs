using System;

// Token: 0x020027D9 RID: 10201
public class RoleDataWithBranch
{
	// Token: 0x06014289 RID: 82569 RVA: 0x005A05F4 File Offset: 0x0059E7F4
	public RoleDataWithBranch(int roleId, int skillBranchId)
	{
		this.RoleId = roleId;
		this.SkillBranchId = skillBranchId;
		if (this.RoleId <= 0 || this.SkillBranchId <= 0)
		{
			this.SkillBranchIndex = -1;
			return;
		}
		this.SkillBranchIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(this.RoleId, this.SkillBranchId);
	}

	// Token: 0x04009CF3 RID: 40179
	public int RoleId;

	// Token: 0x04009CF4 RID: 40180
	public int SkillBranchId;

	// Token: 0x04009CF5 RID: 40181
	public int SkillBranchIndex;
}
