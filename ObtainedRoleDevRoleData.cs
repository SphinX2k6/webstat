using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002820 RID: 10272
[NullableContext(1)]
[Nullable(0)]
public class ObtainedRoleDevRoleData : RoleDevRoleViewItemDataBase
{
	// Token: 0x060144B4 RID: 83124 RVA: 0x005A6234 File Offset: 0x005A4434
	protected override void InitByRoleType(int roleId)
	{
		this.RoleDataInternal = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		RoleDataBase roleDataInternal = this.RoleDataInternal;
		this.LevelDataInternal = ((roleDataInternal != null) ? roleDataInternal.GetLevelData() : null);
		this.InitDetailItemData();
	}

	// Token: 0x060144B5 RID: 83125 RVA: 0x005A6266 File Offset: 0x005A4466
	private void InitDetailItemData()
	{
		this.DetailItemDataInternal.InitByRoleId(base.RoleId);
	}

	// Token: 0x060144B6 RID: 83126 RVA: 0x005A6279 File Offset: 0x005A4479
	protected override int GetRoleLevel()
	{
		RoleLevelData levelDataInternal = this.LevelDataInternal;
		if (levelDataInternal == null)
		{
			return 1;
		}
		return levelDataInternal.GetLevel();
	}

	// Token: 0x060144B7 RID: 83127 RVA: 0x005A628C File Offset: 0x005A448C
	protected override int GetRoleBreachLevel()
	{
		RoleLevelData levelDataInternal = this.LevelDataInternal;
		if (levelDataInternal == null)
		{
			return 0;
		}
		return levelDataInternal.GetBreachLevel();
	}

	// Token: 0x060144B8 RID: 83128 RVA: 0x005A62A0 File Offset: 0x005A44A0
	protected override int GetRoleGoalUpgradeLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.RoleLevel;
	}

	// Token: 0x060144B9 RID: 83129 RVA: 0x005A62D4 File Offset: 0x005A44D4
	protected override int GetRoleGoalBreakLevel()
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(base.RoleId);
		if (cultivateProject == null)
		{
			return 0;
		}
		return cultivateProject.Value.RoleBreachLevel;
	}

	// Token: 0x060144BA RID: 83130 RVA: 0x005A6307 File Offset: 0x005A4507
	protected override int GetMaxLevel()
	{
		RoleLevelData levelDataInternal = this.LevelDataInternal;
		if (levelDataInternal == null)
		{
			return 90;
		}
		return levelDataInternal.GetRoleMaxLevel();
	}

	// Token: 0x060144BB RID: 83131 RVA: 0x005A631B File Offset: 0x005A451B
	protected override List<IRoleDevDetailItemData> GetDetailItems()
	{
		return this.DetailItemDataInternal.DetailItems;
	}

	// Token: 0x060144BC RID: 83132 RVA: 0x005A6328 File Offset: 0x005A4528
	protected override string GetRoleName()
	{
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(base.RoleId);
		if (roleConfig == null)
		{
			return "";
		}
		return ConfigMultiTextLang.GetLocalTextNew(roleConfig.Value.Name, null) ?? "";
	}

	// Token: 0x060144BD RID: 83133 RVA: 0x005A6373 File Offset: 0x005A4573
	protected override bool GetIsCanUpgrade()
	{
		RoleLevelData levelDataInternal = this.LevelDataInternal;
		return levelDataInternal == null || !levelDataInternal.GetRoleNeedBreakUp();
	}

	// Token: 0x060144BE RID: 83134 RVA: 0x005A6389 File Offset: 0x005A4589
	protected override bool GetIsCanBreach()
	{
		if (!base.RoleLevelIsMax)
		{
			RoleLevelData levelDataInternal = this.LevelDataInternal;
			return levelDataInternal != null && levelDataInternal.GetRoleNeedBreakUp();
		}
		return false;
	}

	// Token: 0x060144BF RID: 83135 RVA: 0x005A63A6 File Offset: 0x005A45A6
	protected override bool GetIsCall()
	{
		return RoleDevUtils.IsHotRole(base.RoleId) && RoleDevUtils.GetRoleGachaIds(base.RoleId).Length != 0;
	}

	// Token: 0x060144C0 RID: 83136 RVA: 0x005A63C8 File Offset: 0x005A45C8
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

	// Token: 0x060144C1 RID: 83137 RVA: 0x005A63F9 File Offset: 0x005A45F9
	protected override bool GetIsForecast()
	{
		return false;
	}

	// Token: 0x17001A2E RID: 6702
	// (get) Token: 0x060144C2 RID: 83138 RVA: 0x005A63FC File Offset: 0x005A45FC
	public ObtainedRoleDevRoleDetailItemData DetailItemData
	{
		get
		{
			return this.DetailItemDataInternal;
		}
	}

	// Token: 0x04009DA2 RID: 40354
	[Nullable(2)]
	private RoleDataBase RoleDataInternal;

	// Token: 0x04009DA3 RID: 40355
	[Nullable(2)]
	private RoleLevelData LevelDataInternal;

	// Token: 0x04009DA4 RID: 40356
	private readonly ObtainedRoleDevRoleDetailItemData DetailItemDataInternal = new ObtainedRoleDevRoleDetailItemData();
}
