using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002828 RID: 10280
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleDevSkillViewItemDataBase
{
	// Token: 0x06014556 RID: 83286 RVA: 0x005A8263 File Offset: 0x005A6463
	public void InitByRoleId(int roleId, ERoleDevDataType roleType, RoleDevViewModel roleDevViewModel)
	{
		this.RoleIdInternal = roleId;
		this.RoleTypeInternal = roleType;
		this.InitByRoleType(roleId, roleDevViewModel);
	}

	// Token: 0x06014557 RID: 83287
	protected abstract void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel);

	// Token: 0x17001A43 RID: 6723
	// (get) Token: 0x06014558 RID: 83288 RVA: 0x005A827B File Offset: 0x005A647B
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A44 RID: 6724
	// (get) Token: 0x06014559 RID: 83289 RVA: 0x005A8283 File Offset: 0x005A6483
	public ERoleDevDataType RoleType
	{
		get
		{
			return this.RoleTypeInternal;
		}
	}

	// Token: 0x0601455A RID: 83290
	protected abstract bool GetIsRoleOwned();

	// Token: 0x0601455B RID: 83291
	protected abstract bool GetIsPerfectPlan();

	// Token: 0x0601455C RID: 83292
	protected abstract bool GetIsNormalPlanFinished();

	// Token: 0x0601455D RID: 83293
	protected abstract bool GetIsPerfectPlanFinished();

	// Token: 0x0601455E RID: 83294
	protected abstract List<global::ISkillSlotExtendData> GetSkillSlots();

	// Token: 0x0601455F RID: 83295
	protected abstract List<int> GetSkillGoalUpgradeLevel();

	// Token: 0x06014560 RID: 83296
	protected abstract List<global::IRoleDevDetailItemData> GetNormalDetailItems();

	// Token: 0x06014561 RID: 83297
	protected abstract bool GetIsNormalAllMaterialEnough();

	// Token: 0x06014562 RID: 83298
	protected abstract bool GetIsUnlockedPerfect();

	// Token: 0x06014563 RID: 83299
	protected abstract List<int> GetPerfectGoalUpgradeLevel();

	// Token: 0x06014564 RID: 83300
	protected abstract List<global::IRoleDevDetailItemData> GetPerfectDetailItems();

	// Token: 0x06014565 RID: 83301
	protected abstract bool GetIsPerfectMaterialEnough();

	// Token: 0x06014566 RID: 83302
	protected abstract bool GetIsBreakthroughLevelLow();

	// Token: 0x06014567 RID: 83303
	protected abstract bool GetIsHideMaterialList();

	// Token: 0x06014568 RID: 83304
	protected abstract bool GetIsForecast();

	// Token: 0x06014569 RID: 83305
	protected abstract bool GetShouldForcePerfectPlan();

	// Token: 0x17001A45 RID: 6725
	// (get) Token: 0x0601456A RID: 83306 RVA: 0x005A828B File Offset: 0x005A648B
	public bool IsRoleOwned
	{
		get
		{
			return this.GetIsRoleOwned();
		}
	}

	// Token: 0x17001A46 RID: 6726
	// (get) Token: 0x0601456B RID: 83307 RVA: 0x005A8293 File Offset: 0x005A6493
	public bool IsPerfectPlan
	{
		get
		{
			return this.GetIsPerfectPlan();
		}
	}

	// Token: 0x17001A47 RID: 6727
	// (get) Token: 0x0601456C RID: 83308 RVA: 0x005A829B File Offset: 0x005A649B
	public bool IsNormalPlanFinished
	{
		get
		{
			return this.GetIsNormalPlanFinished();
		}
	}

	// Token: 0x17001A48 RID: 6728
	// (get) Token: 0x0601456D RID: 83309 RVA: 0x005A82A3 File Offset: 0x005A64A3
	public bool IsPerfectPlanFinished
	{
		get
		{
			return this.GetIsPerfectPlanFinished();
		}
	}

	// Token: 0x17001A49 RID: 6729
	// (get) Token: 0x0601456E RID: 83310 RVA: 0x005A82AB File Offset: 0x005A64AB
	public List<global::ISkillSlotExtendData> SkillSlots
	{
		get
		{
			return this.GetSkillSlots();
		}
	}

	// Token: 0x17001A4A RID: 6730
	// (get) Token: 0x0601456F RID: 83311 RVA: 0x005A82B3 File Offset: 0x005A64B3
	public List<int> SkillGoalUpgradeLevel
	{
		get
		{
			return this.GetSkillGoalUpgradeLevel();
		}
	}

	// Token: 0x17001A4B RID: 6731
	// (get) Token: 0x06014570 RID: 83312 RVA: 0x005A82BB File Offset: 0x005A64BB
	public List<global::IRoleDevDetailItemData> NormalDetailItems
	{
		get
		{
			return this.GetNormalDetailItems();
		}
	}

	// Token: 0x17001A4C RID: 6732
	// (get) Token: 0x06014571 RID: 83313 RVA: 0x005A82C3 File Offset: 0x005A64C3
	public bool IsNormalAllMaterialEnough
	{
		get
		{
			return this.GetIsNormalAllMaterialEnough();
		}
	}

	// Token: 0x17001A4D RID: 6733
	// (get) Token: 0x06014572 RID: 83314 RVA: 0x005A82CB File Offset: 0x005A64CB
	public bool IsCurrentPlanAllMaterialEnough
	{
		get
		{
			return this.GetIsCurrentPlanAllMaterialEnough();
		}
	}

	// Token: 0x17001A4E RID: 6734
	// (get) Token: 0x06014573 RID: 83315 RVA: 0x005A82D3 File Offset: 0x005A64D3
	public bool IsUnlockedPerfect
	{
		get
		{
			return this.GetIsUnlockedPerfect();
		}
	}

	// Token: 0x17001A4F RID: 6735
	// (get) Token: 0x06014574 RID: 83316 RVA: 0x005A82DB File Offset: 0x005A64DB
	public List<int> PerfectGoalUpgradeLevel
	{
		get
		{
			return this.GetPerfectGoalUpgradeLevel();
		}
	}

	// Token: 0x17001A50 RID: 6736
	// (get) Token: 0x06014575 RID: 83317 RVA: 0x005A82E3 File Offset: 0x005A64E3
	public List<global::IRoleDevDetailItemData> PerfectDetailItems
	{
		get
		{
			return this.GetPerfectDetailItems();
		}
	}

	// Token: 0x17001A51 RID: 6737
	// (get) Token: 0x06014576 RID: 83318 RVA: 0x005A82EB File Offset: 0x005A64EB
	public bool IsPerfectMaterialEnough
	{
		get
		{
			return this.GetIsPerfectMaterialEnough();
		}
	}

	// Token: 0x17001A52 RID: 6738
	// (get) Token: 0x06014577 RID: 83319 RVA: 0x005A82F3 File Offset: 0x005A64F3
	public bool IsBreakthroughLevelLow
	{
		get
		{
			return this.GetIsBreakthroughLevelLow();
		}
	}

	// Token: 0x17001A53 RID: 6739
	// (get) Token: 0x06014578 RID: 83320 RVA: 0x005A82FB File Offset: 0x005A64FB
	public bool IsHideMaterialList
	{
		get
		{
			return this.GetIsHideMaterialList();
		}
	}

	// Token: 0x17001A54 RID: 6740
	// (get) Token: 0x06014579 RID: 83321 RVA: 0x005A8303 File Offset: 0x005A6503
	public bool IsForecast
	{
		get
		{
			return this.GetIsForecast();
		}
	}

	// Token: 0x17001A55 RID: 6741
	// (get) Token: 0x0601457A RID: 83322 RVA: 0x005A830B File Offset: 0x005A650B
	public bool ShouldForcePerfectPlan
	{
		get
		{
			return this.GetShouldForcePerfectPlan();
		}
	}

	// Token: 0x17001A56 RID: 6742
	// (get) Token: 0x0601457B RID: 83323 RVA: 0x005A8313 File Offset: 0x005A6513
	public bool CurrentPlanMaterialEnough
	{
		get
		{
			if (!this.IsPerfectPlan)
			{
				return this.IsNormalAllMaterialEnough;
			}
			return this.IsPerfectMaterialEnough;
		}
	}

	// Token: 0x17001A57 RID: 6743
	// (get) Token: 0x0601457C RID: 83324 RVA: 0x005A832A File Offset: 0x005A652A
	public bool CurrentPlanFinished
	{
		get
		{
			if (!this.IsPerfectPlan)
			{
				return this.IsNormalPlanFinished;
			}
			return this.IsPerfectPlanFinished;
		}
	}

	// Token: 0x17001A58 RID: 6744
	// (get) Token: 0x0601457D RID: 83325 RVA: 0x005A8341 File Offset: 0x005A6541
	public bool IsRoleObtained
	{
		get
		{
			return this.RoleType == ERoleDevDataType.Obtained;
		}
	}

	// Token: 0x0601457E RID: 83326 RVA: 0x005A834C File Offset: 0x005A654C
	public global::EJumpTarget GetJumpTarget()
	{
		if (!this.IsRoleOwned)
		{
			return global::EJumpTarget.IllustrationPage;
		}
		return global::EJumpTarget.SkillPage;
	}

	// Token: 0x0601457F RID: 83327 RVA: 0x005A835C File Offset: 0x005A655C
	public global::IButtonState GetButtonState()
	{
		return new global::ButtonState
		{
			Text = (this.IsRoleOwned ? "RoleProject_Button01" : "RoleProject_Button02"),
			IsHighlight = (this.IsRoleOwned && (this.IsPerfectPlan ? this.IsPerfectMaterialEnough : this.IsNormalAllMaterialEnough))
		};
	}

	// Token: 0x06014580 RID: 83328 RVA: 0x005A83B0 File Offset: 0x005A65B0
	public global::IPlanSwitchButtonState GetPlanSwitchButtonState()
	{
		return new global::PlanSwitchButtonState
		{
			IsShow = (this.PerfectGoalUpgradeLevel.Count > 0),
			Text = (this.IsPerfectPlan ? "RoleProject_Button_SkillUpgradeBasic" : "RoleProject_Button_SkillUpgradePrefect"),
			IsHighlight = (!this.IsPerfectPlan && this.IsNormalPlanFinished && !this.IsPerfectPlanFinished)
		};
	}

	// Token: 0x06014581 RID: 83329 RVA: 0x005A8412 File Offset: 0x005A6612
	public virtual void SwitchPlan()
	{
		throw new Exception("SwitchPlan must be implemented by subclass");
	}

	// Token: 0x06014582 RID: 83330 RVA: 0x005A841E File Offset: 0x005A661E
	protected bool GetIsCurrentPlanAllMaterialEnough()
	{
		if (!this.IsPerfectPlan)
		{
			return this.IsNormalAllMaterialEnough;
		}
		return this.IsPerfectMaterialEnough;
	}

	// Token: 0x04009DC1 RID: 40385
	protected int RoleIdInternal;

	// Token: 0x04009DC2 RID: 40386
	protected ERoleDevDataType RoleTypeInternal;
}
