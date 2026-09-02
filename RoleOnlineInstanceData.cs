using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020027C2 RID: 10178
[NullableContext(2)]
[Nullable(0)]
public class RoleOnlineInstanceData : RoleDataBase
{
	// Token: 0x0601422B RID: 82475 RVA: 0x0059FB6E File Offset: 0x0059DD6E
	public RoleOnlineInstanceData(int id) : base(id)
	{
		this.SetDefaultData();
	}

	// Token: 0x0601422C RID: 82476 RVA: 0x0059FB80 File Offset: 0x0059DD80
	protected void SetDefaultData()
	{
		RoleInfo roleConfig = base.GetRoleConfig();
		this.WeaponTrialData = new WeaponTrialData();
		this.WeaponTrialData.SetTrialId(roleConfig.WeaponType, true);
	}

	// Token: 0x0601422D RID: 82477 RVA: 0x0059FBB2 File Offset: 0x0059DDB2
	public override bool IsTrialRole()
	{
		return false;
	}

	// Token: 0x0601422E RID: 82478 RVA: 0x0059FBB5 File Offset: 0x0059DDB5
	public override int GetRoleId()
	{
		return this.Id;
	}

	// Token: 0x0601422F RID: 82479 RVA: 0x0059FBC0 File Offset: 0x0059DDC0
	[NullableContext(1)]
	public override string GetName(int? playerId = null)
	{
		RoleInfo roleConfig = base.GetRoleConfig();
		return ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Name);
	}

	// Token: 0x06014230 RID: 82480 RVA: 0x0059FBE5 File Offset: 0x0059DDE5
	public override bool CanChangeName()
	{
		return false;
	}

	// Token: 0x06014231 RID: 82481 RVA: 0x0059FBE8 File Offset: 0x0059DDE8
	public override float GetShowAttributeValueById(int id)
	{
		return 0f;
	}

	// Token: 0x06014232 RID: 82482 RVA: 0x0059FBEF File Offset: 0x0059DDEF
	public override bool IsOnlineRole()
	{
		return true;
	}

	// Token: 0x06014233 RID: 82483 RVA: 0x0059FBF2 File Offset: 0x0059DDF2
	public WeaponTrialData GetWeaponData()
	{
		return this.WeaponTrialData;
	}

	// Token: 0x06014234 RID: 82484 RVA: 0x0059FBFA File Offset: 0x0059DDFA
	public override int GetRoleCreateTime()
	{
		return 0;
	}

	// Token: 0x06014235 RID: 82485 RVA: 0x0059FBFD File Offset: 0x0059DDFD
	public override bool GetIsNew()
	{
		return false;
	}

	// Token: 0x04009C8D RID: 40077
	protected WeaponTrialData WeaponTrialData;
}
