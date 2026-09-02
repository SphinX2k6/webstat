using System;

// Token: 0x02002338 RID: 9016
public class WorldTeamRoleInfo
{
	// Token: 0x06011332 RID: 70450 RVA: 0x004B8DB9 File Offset: 0x004B6FB9
	public WorldTeamRoleInfo(int roleId, int roleSkinId, int roleLevel)
	{
		this.RoleIdInternal = roleId;
		this.RoleSkinIdInternal = roleSkinId;
		this.RoleLevelInternal = roleLevel;
	}

	// Token: 0x1700157A RID: 5498
	// (get) Token: 0x06011333 RID: 70451 RVA: 0x004B8DD6 File Offset: 0x004B6FD6
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x1700157B RID: 5499
	// (get) Token: 0x06011334 RID: 70452 RVA: 0x004B8DDE File Offset: 0x004B6FDE
	public int RoleSkinId
	{
		get
		{
			return this.RoleSkinIdInternal;
		}
	}

	// Token: 0x1700157C RID: 5500
	// (get) Token: 0x06011335 RID: 70453 RVA: 0x004B8DE6 File Offset: 0x004B6FE6
	public int RoleLevel
	{
		get
		{
			return this.RoleLevelInternal;
		}
	}

	// Token: 0x0400872D RID: 34605
	private readonly int RoleIdInternal;

	// Token: 0x0400872E RID: 34606
	private readonly int RoleSkinIdInternal;

	// Token: 0x0400872F RID: 34607
	private readonly int RoleLevelInternal;
}
