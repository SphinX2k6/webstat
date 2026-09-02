using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002831 RID: 10289
public class ForecastRoleDevWeaponRecommendItemData : RoleDevWeaponRecommendItemDataBase
{
	// Token: 0x06014624 RID: 83492 RVA: 0x005AB1B6 File Offset: 0x005A93B6
	protected override void InitByRoleType(int roleId)
	{
		this.SubRecommendItemsInternal.Clear();
	}

	// Token: 0x06014625 RID: 83493 RVA: 0x005AB1C3 File Offset: 0x005A93C3
	protected override int GetWeaponConfigId()
	{
		return 0;
	}

	// Token: 0x06014626 RID: 83494 RVA: 0x005AB1C6 File Offset: 0x005A93C6
	[NullableContext(1)]
	protected override string GetWeaponName()
	{
		return "";
	}

	// Token: 0x06014627 RID: 83495 RVA: 0x005AB1CD File Offset: 0x005A93CD
	protected override int GetWeaponLevel()
	{
		return 1;
	}

	// Token: 0x06014628 RID: 83496 RVA: 0x005AB1D0 File Offset: 0x005A93D0
	protected override int GetWeaponGoalUpgradeLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.WeaponLevel;
	}

	// Token: 0x06014629 RID: 83497 RVA: 0x005AB203 File Offset: 0x005A9403
	protected override bool GetIsCall()
	{
		return false;
	}

	// Token: 0x0601462A RID: 83498 RVA: 0x005AB206 File Offset: 0x005A9406
	protected override int GetGachaId()
	{
		return 0;
	}

	// Token: 0x0601462B RID: 83499 RVA: 0x005AB209 File Offset: 0x005A9409
	protected override bool GetIsWeaponHighQuality()
	{
		return false;
	}

	// Token: 0x0601462C RID: 83500 RVA: 0x005AB20C File Offset: 0x005A940C
	protected override bool GetIsObtained()
	{
		return false;
	}

	// Token: 0x0601462D RID: 83501 RVA: 0x005AB20F File Offset: 0x005A940F
	protected override bool GetIsForecast()
	{
		return true;
	}
}
