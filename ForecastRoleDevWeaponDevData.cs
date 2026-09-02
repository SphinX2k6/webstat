using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x02002830 RID: 10288
[NullableContext(1)]
[Nullable(0)]
public class ForecastRoleDevWeaponDevData : RoleDevWeaponDevItemDataBase
{
	// Token: 0x06014614 RID: 83476 RVA: 0x005AB0D0 File Offset: 0x005A92D0
	protected override void InitByRoleType(int roleId)
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId);
		if (roleDevProsProjectConfig == null)
		{
			return;
		}
		this.WeaponTypeInternal = roleDevProsProjectConfig.WeaponType;
		this.InitDetailItemData();
	}

	// Token: 0x06014615 RID: 83477 RVA: 0x005AB0FF File Offset: 0x005A92FF
	private void InitDetailItemData()
	{
		this.DetailItemDataInternal.InitByWeaponType(base.RoleId, this.WeaponTypeInternal);
	}

	// Token: 0x06014616 RID: 83478 RVA: 0x005AB118 File Offset: 0x005A9318
	protected override int GetWeaponLevel()
	{
		return 1;
	}

	// Token: 0x06014617 RID: 83479 RVA: 0x005AB11B File Offset: 0x005A931B
	protected override int GetWeaponBreachLevel()
	{
		return 0;
	}

	// Token: 0x06014618 RID: 83480 RVA: 0x005AB11E File Offset: 0x005A931E
	protected override int GetWeaponGoalUpgradeLevel()
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(base.RoleId);
		if (roleDevProsProjectConfig == null)
		{
			return 0;
		}
		return roleDevProsProjectConfig.WeaponGoalLevel;
	}

	// Token: 0x06014619 RID: 83481 RVA: 0x005AB13B File Offset: 0x005A933B
	protected override int GetWeaponGoalBreakLevel()
	{
		return 0;
	}

	// Token: 0x0601461A RID: 83482 RVA: 0x005AB13E File Offset: 0x005A933E
	protected override int GetMaxLevel()
	{
		return 0;
	}

	// Token: 0x0601461B RID: 83483 RVA: 0x005AB141 File Offset: 0x005A9341
	protected override List<IRoleDevDetailItemData> GetDetailItems()
	{
		return this.DetailItemDataInternal.DetailItems;
	}

	// Token: 0x0601461C RID: 83484 RVA: 0x005AB150 File Offset: 0x005A9350
	protected override string GetWeaponName()
	{
		RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(this.WeaponTypeInternal);
		if (roleDevWeaponItemConfig == null)
		{
			return "";
		}
		return roleDevWeaponItemConfig.Value.WeaponTypeDescribe;
	}

	// Token: 0x0601461D RID: 83485 RVA: 0x005AB18C File Offset: 0x005A938C
	protected override bool GetIsCanUpgrade()
	{
		return base.IsCanShowUpgradeItem;
	}

	// Token: 0x0601461E RID: 83486 RVA: 0x005AB194 File Offset: 0x005A9394
	protected override bool GetIsCanBreach()
	{
		return false;
	}

	// Token: 0x0601461F RID: 83487 RVA: 0x005AB197 File Offset: 0x005A9397
	protected override bool GetIsCall()
	{
		return false;
	}

	// Token: 0x06014620 RID: 83488 RVA: 0x005AB19A File Offset: 0x005A939A
	protected override int GetGachaId()
	{
		return 0;
	}

	// Token: 0x06014621 RID: 83489 RVA: 0x005AB19D File Offset: 0x005A939D
	protected override int GetWeaponConfigId()
	{
		return 0;
	}

	// Token: 0x06014622 RID: 83490 RVA: 0x005AB1A0 File Offset: 0x005A93A0
	protected override bool GetIsHighQuality()
	{
		return false;
	}

	// Token: 0x04009DF5 RID: 40437
	private int WeaponTypeInternal;

	// Token: 0x04009DF6 RID: 40438
	private readonly ForecastRoleDevWeaponDetailItemData DetailItemDataInternal = new ForecastRoleDevWeaponDetailItemData();
}
