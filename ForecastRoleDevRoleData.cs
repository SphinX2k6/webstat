using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x0200281C RID: 10268
[NullableContext(1)]
[Nullable(0)]
public class ForecastRoleDevRoleData : RoleDevRoleViewItemDataBase
{
	// Token: 0x06014470 RID: 83056 RVA: 0x005A558D File Offset: 0x005A378D
	protected override void InitByRoleType(int roleId)
	{
		this.InitDetailItemData();
	}

	// Token: 0x06014471 RID: 83057 RVA: 0x005A5595 File Offset: 0x005A3795
	private void InitDetailItemData()
	{
		this.DetailItemDataInternal.InitByRoleId(base.RoleId);
	}

	// Token: 0x06014472 RID: 83058 RVA: 0x005A55A8 File Offset: 0x005A37A8
	protected override int GetRoleLevel()
	{
		return 1;
	}

	// Token: 0x06014473 RID: 83059 RVA: 0x005A55AB File Offset: 0x005A37AB
	protected override int GetRoleBreachLevel()
	{
		return 0;
	}

	// Token: 0x06014474 RID: 83060 RVA: 0x005A55B0 File Offset: 0x005A37B0
	protected override int GetRoleGoalUpgradeLevel()
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(base.RoleId);
		if (roleDevProsProjectConfig == null)
		{
			return 0;
		}
		return roleDevProsProjectConfig.RoleGoalLevel;
	}

	// Token: 0x06014475 RID: 83061 RVA: 0x005A55D9 File Offset: 0x005A37D9
	protected override int GetRoleGoalBreakLevel()
	{
		return 0;
	}

	// Token: 0x06014476 RID: 83062 RVA: 0x005A55DC File Offset: 0x005A37DC
	protected override int GetMaxLevel()
	{
		return 0;
	}

	// Token: 0x06014477 RID: 83063 RVA: 0x005A55DF File Offset: 0x005A37DF
	protected override List<IRoleDevDetailItemData> GetDetailItems()
	{
		return this.DetailItemDataInternal.DetailItems;
	}

	// Token: 0x06014478 RID: 83064 RVA: 0x005A55EC File Offset: 0x005A37EC
	protected override string GetRoleName()
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(base.RoleId);
		if (roleDevProsProjectConfig == null)
		{
			return "";
		}
		return roleDevProsProjectConfig.RoleName;
	}

	// Token: 0x06014479 RID: 83065 RVA: 0x005A5619 File Offset: 0x005A3819
	protected override bool GetIsCanUpgrade()
	{
		return false;
	}

	// Token: 0x0601447A RID: 83066 RVA: 0x005A561C File Offset: 0x005A381C
	protected override bool GetIsCanBreach()
	{
		return false;
	}

	// Token: 0x0601447B RID: 83067 RVA: 0x005A561F File Offset: 0x005A381F
	protected override bool GetIsCall()
	{
		return RoleDevUtils.IsHotRole(base.RoleId) && RoleDevUtils.GetRoleGachaIds(base.RoleId).Length != 0;
	}

	// Token: 0x0601447C RID: 83068 RVA: 0x005A5640 File Offset: 0x005A3840
	protected override int GetGachaId()
	{
		if (!RoleDevUtils.IsHotRole(base.RoleId))
		{
			return 0;
		}
		int[] roleGachaIds = RoleDevUtils.GetRoleGachaIds(base.RoleId);
		if (roleGachaIds.Length == 0)
		{
			return 0;
		}
		return roleGachaIds[0];
	}

	// Token: 0x0601447D RID: 83069 RVA: 0x005A5671 File Offset: 0x005A3871
	protected override bool GetIsForecast()
	{
		return true;
	}

	// Token: 0x17001A2A RID: 6698
	// (get) Token: 0x0601447E RID: 83070 RVA: 0x005A5674 File Offset: 0x005A3874
	public ForecastRoleDevRoleDetailItemData DetailItemData
	{
		get
		{
			return this.DetailItemDataInternal;
		}
	}

	// Token: 0x04009D9E RID: 40350
	private readonly ForecastRoleDevRoleDetailItemData DetailItemDataInternal = new ForecastRoleDevRoleDetailItemData();
}
