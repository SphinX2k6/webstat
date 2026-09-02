using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200281E RID: 10270
[NullableContext(1)]
[Nullable(0)]
public class NotObtainedRoleDevRoleData : RoleDevRoleViewItemDataBase
{
	// Token: 0x06014492 RID: 83090 RVA: 0x005A5BD5 File Offset: 0x005A3DD5
	protected override void InitByRoleType(int roleId)
	{
		this.InitDetailItemData();
	}

	// Token: 0x06014493 RID: 83091 RVA: 0x005A5BDD File Offset: 0x005A3DDD
	private void InitDetailItemData()
	{
		this.DetailItemDataInternal.InitByRoleId(base.RoleId);
	}

	// Token: 0x06014494 RID: 83092 RVA: 0x005A5BF0 File Offset: 0x005A3DF0
	protected override int GetRoleLevel()
	{
		return 1;
	}

	// Token: 0x06014495 RID: 83093 RVA: 0x005A5BF3 File Offset: 0x005A3DF3
	protected override int GetRoleBreachLevel()
	{
		return 0;
	}

	// Token: 0x06014496 RID: 83094 RVA: 0x005A5BF8 File Offset: 0x005A3DF8
	protected override int GetRoleGoalUpgradeLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.RoleLevel;
	}

	// Token: 0x06014497 RID: 83095 RVA: 0x005A5C2C File Offset: 0x005A3E2C
	protected override int GetRoleGoalBreakLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.RoleBreachLevel;
	}

	// Token: 0x06014498 RID: 83096 RVA: 0x005A5C5F File Offset: 0x005A3E5F
	protected override int GetMaxLevel()
	{
		return 0;
	}

	// Token: 0x06014499 RID: 83097 RVA: 0x005A5C62 File Offset: 0x005A3E62
	protected override List<IRoleDevDetailItemData> GetDetailItems()
	{
		return this.DetailItemDataInternal.DetailItems;
	}

	// Token: 0x0601449A RID: 83098 RVA: 0x005A5C70 File Offset: 0x005A3E70
	protected override string GetRoleName()
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(base.RoleId);
		if (roleConfig == null)
		{
			return "";
		}
		return ConfigMultiTextLang.GetLocalTextNew(roleConfig.Value.Name, null) ?? "";
	}

	// Token: 0x0601449B RID: 83099 RVA: 0x005A5CBB File Offset: 0x005A3EBB
	protected override bool GetIsCanUpgrade()
	{
		return true;
	}

	// Token: 0x0601449C RID: 83100 RVA: 0x005A5CBE File Offset: 0x005A3EBE
	protected override bool GetIsCanBreach()
	{
		return true;
	}

	// Token: 0x0601449D RID: 83101 RVA: 0x005A5CC1 File Offset: 0x005A3EC1
	protected override bool GetIsCall()
	{
		return RoleDevUtils.IsHotRole(base.RoleId) && RoleDevUtils.GetRoleGachaIds(base.RoleId).Length != 0;
	}

	// Token: 0x0601449E RID: 83102 RVA: 0x005A5CE4 File Offset: 0x005A3EE4
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

	// Token: 0x0601449F RID: 83103 RVA: 0x005A5D15 File Offset: 0x005A3F15
	protected override bool GetIsForecast()
	{
		return false;
	}

	// Token: 0x17001A2C RID: 6700
	// (get) Token: 0x060144A0 RID: 83104 RVA: 0x005A5D18 File Offset: 0x005A3F18
	public NotObtainedRoleDevRoleDetailItemData DetailItemData
	{
		get
		{
			return this.DetailItemDataInternal;
		}
	}

	// Token: 0x04009DA0 RID: 40352
	private readonly NotObtainedRoleDevRoleDetailItemData DetailItemDataInternal = new NotObtainedRoleDevRoleDetailItemData();
}
