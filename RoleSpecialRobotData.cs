using System;

// Token: 0x020027C4 RID: 10180
public class RoleSpecialRobotData : RoleRobotData
{
	// Token: 0x0601424C RID: 82508 RVA: 0x005A02E8 File Offset: 0x0059E4E8
	public RoleSpecialRobotData(int id) : base(id)
	{
		base.SetDefaultData();
	}

	// Token: 0x0601424D RID: 82509 RVA: 0x005A02F7 File Offset: 0x0059E4F7
	public bool IsUnlock()
	{
		return this.IsUnlockInternal;
	}

	// Token: 0x0601424E RID: 82510 RVA: 0x005A02FF File Offset: 0x0059E4FF
	public void SetIsUnlock(bool value)
	{
		this.IsUnlockInternal = value;
	}

	// Token: 0x0601424F RID: 82511 RVA: 0x005A0308 File Offset: 0x0059E508
	public override bool CanEditInFormation()
	{
		return true;
	}

	// Token: 0x06014250 RID: 82512 RVA: 0x005A030B File Offset: 0x0059E50B
	public override bool IsVisibleInFormation()
	{
		return this.IsVisibleInFormationInternal;
	}

	// Token: 0x06014251 RID: 82513 RVA: 0x005A0313 File Offset: 0x0059E513
	public void SetIsVisibleInFormation(bool value)
	{
		this.IsVisibleInFormationInternal = value;
	}

	// Token: 0x06014252 RID: 82514 RVA: 0x005A031C File Offset: 0x0059E51C
	public bool IsVisibleInRoleSystem()
	{
		return this.IsVisibleInRoleSystemInternal;
	}

	// Token: 0x06014253 RID: 82515 RVA: 0x005A0324 File Offset: 0x0059E524
	public void SetIsVisibleInRoleSystem(bool value)
	{
		this.IsVisibleInRoleSystemInternal = value;
	}

	// Token: 0x04009C8F RID: 40079
	protected bool IsUnlockInternal;

	// Token: 0x04009C90 RID: 40080
	protected bool IsVisibleInFormationInternal;

	// Token: 0x04009C91 RID: 40081
	protected bool IsVisibleInRoleSystemInternal;
}
