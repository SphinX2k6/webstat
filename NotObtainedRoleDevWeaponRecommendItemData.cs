using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002835 RID: 10293
public class NotObtainedRoleDevWeaponRecommendItemData : RoleDevWeaponRecommendItemDataBase
{
	// Token: 0x0601465B RID: 83547 RVA: 0x005AB967 File Offset: 0x005A9B67
	protected override void InitByRoleType(int roleId)
	{
		base.InitSubRecommendItems(roleId);
	}

	// Token: 0x0601465C RID: 83548 RVA: 0x005AB970 File Offset: 0x005A9B70
	protected override int GetWeaponConfigId()
	{
		return 0;
	}

	// Token: 0x0601465D RID: 83549 RVA: 0x005AB974 File Offset: 0x005A9B74
	[NullableContext(1)]
	protected override string GetWeaponName()
	{
		RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(base.RoleId);
		if (roleDevProjectConfig == null)
		{
			return "";
		}
		RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(roleDevProjectConfig.Value.WeaponType);
		if (roleDevWeaponItemConfig == null)
		{
			return "";
		}
		return roleDevWeaponItemConfig.Value.WeaponTypeDescribe;
	}

	// Token: 0x0601465E RID: 83550 RVA: 0x005AB9D9 File Offset: 0x005A9BD9
	protected override int GetWeaponLevel()
	{
		return 1;
	}

	// Token: 0x0601465F RID: 83551 RVA: 0x005AB9DC File Offset: 0x005A9BDC
	protected override int GetWeaponGoalUpgradeLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.WeaponLevel;
	}

	// Token: 0x06014660 RID: 83552 RVA: 0x005ABA0F File Offset: 0x005A9C0F
	protected override bool GetIsCall()
	{
		return false;
	}

	// Token: 0x06014661 RID: 83553 RVA: 0x005ABA12 File Offset: 0x005A9C12
	protected override int GetGachaId()
	{
		return 0;
	}

	// Token: 0x06014662 RID: 83554 RVA: 0x005ABA15 File Offset: 0x005A9C15
	protected override bool GetIsWeaponHighQuality()
	{
		return true;
	}

	// Token: 0x06014663 RID: 83555 RVA: 0x005ABA18 File Offset: 0x005A9C18
	protected override bool GetIsObtained()
	{
		return false;
	}

	// Token: 0x06014664 RID: 83556 RVA: 0x005ABA1B File Offset: 0x005A9C1B
	protected override bool GetIsForecast()
	{
		return false;
	}
}
