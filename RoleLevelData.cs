using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020027BB RID: 10171
public class RoleLevelData : RoleModuleDataBase
{
	// Token: 0x060141C5 RID: 82373 RVA: 0x0059E1BD File Offset: 0x0059C3BD
	public RoleLevelData(int roleId) : base(roleId)
	{
	}

	// Token: 0x060141C6 RID: 82374 RVA: 0x0059E1C6 File Offset: 0x0059C3C6
	public void SetLevel(int level)
	{
		this.Level = level;
	}

	// Token: 0x060141C7 RID: 82375 RVA: 0x0059E1CF File Offset: 0x0059C3CF
	public int GetLevel()
	{
		return this.Level;
	}

	// Token: 0x060141C8 RID: 82376 RVA: 0x0059E1D7 File Offset: 0x0059C3D7
	public void SetExp(int exp)
	{
		this.Exp = exp;
	}

	// Token: 0x060141C9 RID: 82377 RVA: 0x0059E1E0 File Offset: 0x0059C3E0
	public int GetExp()
	{
		return this.Exp;
	}

	// Token: 0x060141CA RID: 82378 RVA: 0x0059E1E8 File Offset: 0x0059C3E8
	public void SetBreachLevel(int level)
	{
		this.BreachLevel = level;
	}

	// Token: 0x060141CB RID: 82379 RVA: 0x0059E1F1 File Offset: 0x0059C3F1
	public int GetBreachLevel()
	{
		return this.BreachLevel;
	}

	// Token: 0x060141CC RID: 82380 RVA: 0x0059E1FC File Offset: 0x0059C3FC
	public int GetRoleMaxLevel()
	{
		return base.GetRoleConfig().MaxLevel;
	}

	// Token: 0x060141CD RID: 82381 RVA: 0x0059E217 File Offset: 0x0059C417
	public bool GetRoleIsMaxLevel()
	{
		return this.Level >= this.GetRoleMaxLevel();
	}

	// Token: 0x060141CE RID: 82382 RVA: 0x0059E22A File Offset: 0x0059C42A
	public int GetCurrentMaxExp()
	{
		return this.GetLevelUpExp(this.Level + 1);
	}

	// Token: 0x060141CF RID: 82383 RVA: 0x0059E23C File Offset: 0x0059C43C
	public int GetLevelUpNeedExp()
	{
		int levelUpExp = this.GetLevelUpExp(this.Level + 1);
		return Math.Max(0, levelUpExp - this.Exp);
	}

	// Token: 0x060141D0 RID: 82384 RVA: 0x0059E268 File Offset: 0x0059C468
	private int GetLevelUpExp(int level)
	{
		RoleLevelConsume? roleLevelConsume = ConfigBase<RoleConfig>.Instance.GetRoleLevelConsume(base.GetRoleConfig().LevelConsumeId, level);
		if (roleLevelConsume != null)
		{
			return roleLevelConsume.Value.ExpCount;
		}
		return 1;
	}

	// Token: 0x060141D1 RID: 82385 RVA: 0x0059E2AC File Offset: 0x0059C4AC
	public int GetMaxBreachLevel()
	{
		IReadOnlyList<RoleBreach> roleBreachList = ConfigBase<RoleConfig>.Instance.GetRoleBreachList(base.GetRoleConfig().BreachId);
		int count = roleBreachList.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			RoleBreach roleBreach = roleBreachList[i];
			if (roleBreach.BreachLevel > num)
			{
				num = roleBreach.BreachLevel;
			}
		}
		return num;
	}

	// Token: 0x060141D2 RID: 82386 RVA: 0x0059E308 File Offset: 0x0059C508
	public int GetCurrentMaxLevel()
	{
		RoleBreach? breachConfig = this.GetBreachConfig(this.BreachLevel);
		if (breachConfig == null)
		{
			return 0;
		}
		return breachConfig.Value.MaxLevel;
	}

	// Token: 0x060141D3 RID: 82387 RVA: 0x0059E33C File Offset: 0x0059C53C
	public RoleBreach? GetBreachConfig(int level)
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleBreachConfig(base.GetRoleConfig().BreachId, level);
	}

	// Token: 0x060141D4 RID: 82388 RVA: 0x0059E362 File Offset: 0x0059C562
	public bool GetRoleNeedBreakUp()
	{
		return this.Level >= this.GetCurrentMaxLevel() && this.Level < this.GetRoleMaxLevel();
	}

	// Token: 0x060141D5 RID: 82389 RVA: 0x0059E384 File Offset: 0x0059C584
	public double GetExpPercentage()
	{
		if (this.GetRoleIsMaxLevel())
		{
			return 1.0;
		}
		RoleLevelConsume? roleLevelConsume = ConfigBase<RoleConfig>.Instance.GetRoleLevelConsume(base.GetRoleConfig().LevelConsumeId, this.Level + 1);
		if (roleLevelConsume != null)
		{
			return (double)this.Exp / (double)roleLevelConsume.Value.ExpCount;
		}
		return 0.0;
	}

	// Token: 0x060141D6 RID: 82390 RVA: 0x0059E3F0 File Offset: 0x0059C5F0
	public bool IsEnoughBreachConsume()
	{
		RoleBreach? roleBreachConfig = ConfigBase<RoleConfig>.Instance.GetRoleBreachConfig(base.GetRoleConfig().BreachId, this.BreachLevel + 1);
		if (roleBreachConfig == null)
		{
			return false;
		}
		if (!ControllerBase<LevelGeneralController>.Instance.CheckCondition(roleBreachConfig.Value.ConditionId.ToString(), null, false, Array.Empty<object>()))
		{
			return false;
		}
		foreach (DicIntInt dicIntInt in roleBreachConfig.Value.BreachConsumeIter())
		{
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(dicIntInt.Key, 0) < dicIntInt.Value)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x04009C71 RID: 40049
	protected int Level;

	// Token: 0x04009C72 RID: 40050
	protected int BreachLevel;

	// Token: 0x04009C73 RID: 40051
	protected int Exp;
}
