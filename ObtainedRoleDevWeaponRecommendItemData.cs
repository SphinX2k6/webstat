using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002839 RID: 10297
public class ObtainedRoleDevWeaponRecommendItemData : RoleDevWeaponRecommendItemDataBase
{
	// Token: 0x06014691 RID: 83601 RVA: 0x005AC2E8 File Offset: 0x005AA4E8
	protected override void InitByRoleType(int roleId)
	{
		base.InitSubRecommendItems(roleId);
	}

	// Token: 0x06014692 RID: 83602 RVA: 0x005AC2F4 File Offset: 0x005AA4F4
	protected override int GetWeaponConfigId()
	{
		return ModelBase<WeaponModel>.Instance.GetWeaponIdByRoleDataId(base.RoleId).GetValueOrDefault();
	}

	// Token: 0x06014693 RID: 83603 RVA: 0x005AC31C File Offset: 0x005AA51C
	[NullableContext(1)]
	protected override string GetWeaponName()
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(base.RoleId);
		if (weaponInstanceByRoleId == null)
		{
			return "";
		}
		WeaponConf? weaponConfig = weaponInstanceByRoleId.GetWeaponConfig();
		if (weaponConfig == null)
		{
			return "";
		}
		return weaponConfig.Value.WeaponName;
	}

	// Token: 0x06014694 RID: 83604 RVA: 0x005AC368 File Offset: 0x005AA568
	protected override int GetWeaponLevel()
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(base.RoleId);
		if (weaponInstanceByRoleId == null)
		{
			return 0;
		}
		return weaponInstanceByRoleId.GetLevel();
	}

	// Token: 0x06014695 RID: 83605 RVA: 0x005AC388 File Offset: 0x005AA588
	protected override int GetWeaponGoalUpgradeLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.WeaponLevel;
	}

	// Token: 0x06014696 RID: 83606 RVA: 0x005AC3BB File Offset: 0x005AA5BB
	protected override bool GetIsCall()
	{
		return RoleDevUtils.GetRoleGachaIds(base.WeaponConfigId).Length != 0;
	}

	// Token: 0x06014697 RID: 83607 RVA: 0x005AC3CC File Offset: 0x005AA5CC
	protected override int GetGachaId()
	{
		int[] roleGachaIds = RoleDevUtils.GetRoleGachaIds(base.WeaponConfigId);
		if (roleGachaIds.Length != 0)
		{
			return roleGachaIds[0];
		}
		return 0;
	}

	// Token: 0x06014698 RID: 83608 RVA: 0x005AC3F0 File Offset: 0x005AA5F0
	protected override bool GetIsWeaponHighQuality()
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(base.RoleId);
		return weaponInstanceByRoleId == null || ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstanceByRoleId);
	}

	// Token: 0x06014699 RID: 83609 RVA: 0x005AC41E File Offset: 0x005AA61E
	protected override bool GetIsObtained()
	{
		return this.GetWeaponConfigId() > 0;
	}

	// Token: 0x0601469A RID: 83610 RVA: 0x005AC429 File Offset: 0x005AA629
	protected override bool GetIsForecast()
	{
		return false;
	}
}
