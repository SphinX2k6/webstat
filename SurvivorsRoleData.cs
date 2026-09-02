using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002B62 RID: 11106
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRoleData : RoleDataBase
{
	// Token: 0x06016232 RID: 90674 RVA: 0x00624E1C File Offset: 0x0062301C
	public SurvivorsRoleData(int surRoleId, int trialRoleId, bool isUnLock) : base(trialRoleId)
	{
		this.SurRoleId = surRoleId;
		this.TrialRoleId = trialRoleId;
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.TrialRoleId).Value;
		this.Id = value.Id;
		this.IconPath = value.RoleHeadIconBig;
		this.QualityId = value.QualityId;
		this.IsUnLock = isUnLock;
		this.DefaultEvolveTxtID = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRoleDefaultEvolve(this.SurRoleId).Value.Describe;
		SurvivorsRole value2 = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(this.SurRoleId).Value;
		this.UnlockConditionId = value2.UnlockConditionId;
		this.InitWeaponID = value2.InitWeapon;
		this.PropId = value2.PropId;
	}

	// Token: 0x06016233 RID: 90675 RVA: 0x00624EED File Offset: 0x006230ED
	public override bool IsTrialRole()
	{
		return true;
	}

	// Token: 0x06016234 RID: 90676 RVA: 0x00624EF0 File Offset: 0x006230F0
	public override int GetRoleId()
	{
		return this.Id;
	}

	// Token: 0x06016235 RID: 90677 RVA: 0x00624EF8 File Offset: 0x006230F8
	public override string GetName(int? playerId = null)
	{
		RoleInfo roleConfig = base.GetRoleConfig();
		return ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Name);
	}

	// Token: 0x06016236 RID: 90678 RVA: 0x00624F1D File Offset: 0x0062311D
	public override bool CanChangeName()
	{
		return false;
	}

	// Token: 0x06016237 RID: 90679 RVA: 0x00624F20 File Offset: 0x00623120
	public override bool IsOnlineRole()
	{
		return false;
	}

	// Token: 0x06016238 RID: 90680 RVA: 0x00624F23 File Offset: 0x00623123
	public override int GetRoleCreateTime()
	{
		return 0;
	}

	// Token: 0x06016239 RID: 90681 RVA: 0x00624F26 File Offset: 0x00623126
	public override bool GetIsNew()
	{
		return false;
	}

	// Token: 0x0601623A RID: 90682 RVA: 0x00624F29 File Offset: 0x00623129
	public SurvivorsRole? GetSurRoleConfig()
	{
		return ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(this.SurRoleId);
	}

	// Token: 0x0400AB02 RID: 43778
	public int SurRoleId;

	// Token: 0x0400AB03 RID: 43779
	public bool IsUnLock;

	// Token: 0x0400AB04 RID: 43780
	public int TrialRoleId;

	// Token: 0x0400AB05 RID: 43781
	public string IconPath;

	// Token: 0x0400AB06 RID: 43782
	public int QualityId;

	// Token: 0x0400AB07 RID: 43783
	public int InitWeaponID;

	// Token: 0x0400AB08 RID: 43784
	public string DefaultEvolveTxtID;

	// Token: 0x0400AB09 RID: 43785
	public int UnlockConditionId;

	// Token: 0x0400AB0A RID: 43786
	public int PropId;

	// Token: 0x0400AB0B RID: 43787
	public bool IsSurvivorsTrial;
}
