using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002826 RID: 10278
[NullableContext(1)]
[Nullable(0)]
public class NotObtainedRoleDevSkillData : RoleDevSkillViewItemDataBase
{
	// Token: 0x06014527 RID: 83239 RVA: 0x005A76DC File Offset: 0x005A58DC
	protected override void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel)
	{
		this.RoleDevViewModelInternal = roleDevViewModel;
		this.InitSkillData(roleId);
	}

	// Token: 0x06014528 RID: 83240 RVA: 0x005A76EC File Offset: 0x005A58EC
	private void InitSkillData(int roleId)
	{
		RoleDevCultivateProject? cultivateProject = RoleDevUtils.GetCultivateProject(roleId);
		if (cultivateProject == null)
		{
			return;
		}
		int[] normalSkillLevelArray = cultivateProject.Value.GetNormalSkillLevelArray();
		List<int> list = ((normalSkillLevelArray != null) ? normalSkillLevelArray.ToList<int>() : null) ?? new List<int>();
		int[] prefectSkillLevelArray = cultivateProject.Value.GetPrefectSkillLevelArray();
		List<int> list2 = ((prefectSkillLevelArray != null) ? prefectSkillLevelArray.ToList<int>() : null) ?? new List<int>();
		int[] canLevelUpSkillNodeIndexList = ConfigBase<RoleDevConfig>.Instance.GetCanLevelUpSkillNodeIndexList();
		if (canLevelUpSkillNodeIndexList.Length != list.Count || canLevelUpSkillNodeIndexList.Length != list2.Count)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.LZK, "LevelUpSkillNodeIndexList长度与NormalSkillLevel或PrefectSkillLevel长度不一致", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		List<int> list3 = new List<int>();
		List<int> list4 = new List<int>();
		List<int> list5 = new List<int>();
		List<int> list6 = new List<int>();
		List<int> list7 = new List<int>();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		for (int i = 0; i < canLevelUpSkillNodeIndexList.Length; i++)
		{
			int nodeIndex = canLevelUpSkillNodeIndexList[i];
			SkillTree? skillTreeNodeByGroupIdAndIndex = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndIndex(roleConfig.Value.SkillTreeGroupId, nodeIndex);
			if (skillTreeNodeByGroupIdAndIndex != null)
			{
				int id = skillTreeNodeByGroupIdAndIndex.Value.Id;
				list7.Add(id);
				list6.Add(id);
				list3.Add(1);
				list4.Add(list[i]);
				list5.Add(list2[i]);
			}
		}
		int[] skillTreeConfigArrayArray = cultivateProject.Value.GetSkillTreeConfigArrayArray();
		List<int> list8 = (skillTreeConfigArrayArray != null) ? skillTreeConfigArrayArray.ToList<int>() : null;
		if (list8 != null && list8.Count > 0)
		{
			foreach (int nodeIndex2 in list8)
			{
				SkillTree? skillTreeNodeByGroupIdAndIndex2 = ConfigBase<RoleSkillConfig>.Instance.GetSkillTreeNodeByGroupIdAndIndex(roleConfig.Value.SkillTreeGroupId, nodeIndex2);
				if (skillTreeNodeByGroupIdAndIndex2 != null)
				{
					int id2 = skillTreeNodeByGroupIdAndIndex2.Value.Id;
					list6.Add(id2);
					list3.Add(0);
					list4.Add(1);
					list5.Add(1);
				}
			}
		}
		List<ISkillSlotExtendData> list9 = new List<ISkillSlotExtendData>();
		for (int j = 0; j < list7.Count; j++)
		{
			SkillSlotExtendData item = new SkillSlotExtendData
			{
				RoleId = roleId,
				SkillNodeId = list7[j],
				IconId = list7[j],
				CurrentLevel = list3[j],
				NormalTargetLevel = list4[j],
				PerfectTargetLevel = list5[j],
				SkillType = j + ESkillType.Skill1,
				NodeIndex = j
			};
			list9.Add(item);
		}
		List<IRoleDevDetailItemData> detailItemsInternal = this.CreateSkillDetailItemsData(list6.ToArray(), list3.ToArray(), list4.ToArray(), roleId);
		List<IRoleDevDetailItemData> perfectDetailItemsInternal = this.CreateSkillDetailItemsData(list6.ToArray(), list3.ToArray(), list5.ToArray(), roleId);
		this.SkillSlotsInternal = list9;
		this.SkillGoalUpgradeLevelInternal = list4;
		this.PerfectGoalUpgradeLevelInternal = list5;
		this.DetailItemsInternal = detailItemsInternal;
		this.PerfectDetailItemsInternal = perfectDetailItemsInternal;
	}

	// Token: 0x06014529 RID: 83241 RVA: 0x005A7A14 File Offset: 0x005A5C14
	protected override bool GetIsRoleOwned()
	{
		return false;
	}

	// Token: 0x0601452A RID: 83242 RVA: 0x005A7A17 File Offset: 0x005A5C17
	protected override bool GetIsPerfectPlan()
	{
		RoleDevViewModel roleDevViewModelInternal = this.RoleDevViewModelInternal;
		return roleDevViewModelInternal != null && roleDevViewModelInternal.GetRoleSkillPlanState(base.RoleId);
	}

	// Token: 0x0601452B RID: 83243 RVA: 0x005A7A30 File Offset: 0x005A5C30
	protected override bool GetIsNormalPlanFinished()
	{
		return false;
	}

	// Token: 0x0601452C RID: 83244 RVA: 0x005A7A33 File Offset: 0x005A5C33
	protected override bool GetIsPerfectPlanFinished()
	{
		return false;
	}

	// Token: 0x0601452D RID: 83245 RVA: 0x005A7A36 File Offset: 0x005A5C36
	protected override List<ISkillSlotExtendData> GetSkillSlots()
	{
		return this.SkillSlotsInternal;
	}

	// Token: 0x0601452E RID: 83246 RVA: 0x005A7A3E File Offset: 0x005A5C3E
	protected override List<int> GetSkillGoalUpgradeLevel()
	{
		return this.SkillGoalUpgradeLevelInternal;
	}

	// Token: 0x0601452F RID: 83247 RVA: 0x005A7A46 File Offset: 0x005A5C46
	protected override List<IRoleDevDetailItemData> GetNormalDetailItems()
	{
		return this.DetailItemsInternal;
	}

	// Token: 0x06014530 RID: 83248 RVA: 0x005A7A4E File Offset: 0x005A5C4E
	protected override bool GetIsNormalAllMaterialEnough()
	{
		return RoleDevUtils.CheckAllItemsUp(this.DetailItemsInternal);
	}

	// Token: 0x06014531 RID: 83249 RVA: 0x005A7A5B File Offset: 0x005A5C5B
	protected override bool GetIsUnlockedPerfect()
	{
		return this.PerfectGoalUpgradeLevelInternal.Count > 0;
	}

	// Token: 0x06014532 RID: 83250 RVA: 0x005A7A6B File Offset: 0x005A5C6B
	protected override List<int> GetPerfectGoalUpgradeLevel()
	{
		return this.PerfectGoalUpgradeLevelInternal;
	}

	// Token: 0x06014533 RID: 83251 RVA: 0x005A7A73 File Offset: 0x005A5C73
	protected override List<IRoleDevDetailItemData> GetPerfectDetailItems()
	{
		return this.PerfectDetailItemsInternal;
	}

	// Token: 0x06014534 RID: 83252 RVA: 0x005A7A7B File Offset: 0x005A5C7B
	protected override bool GetIsPerfectMaterialEnough()
	{
		return RoleDevUtils.CheckAllItemsUp(this.PerfectDetailItemsInternal);
	}

	// Token: 0x06014535 RID: 83253 RVA: 0x005A7A88 File Offset: 0x005A5C88
	protected override bool GetIsBreakthroughLevelLow()
	{
		return false;
	}

	// Token: 0x06014536 RID: 83254 RVA: 0x005A7A8B File Offset: 0x005A5C8B
	protected override bool GetIsHideMaterialList()
	{
		return false;
	}

	// Token: 0x06014537 RID: 83255 RVA: 0x005A7A8E File Offset: 0x005A5C8E
	protected override bool GetIsForecast()
	{
		return false;
	}

	// Token: 0x06014538 RID: 83256 RVA: 0x005A7A91 File Offset: 0x005A5C91
	protected override bool GetShouldForcePerfectPlan()
	{
		return false;
	}

	// Token: 0x06014539 RID: 83257 RVA: 0x005A7A94 File Offset: 0x005A5C94
	public override void SwitchPlan()
	{
		bool isPerfectPlan = !this.GetIsPerfectPlan();
		RoleDevViewModel roleDevViewModelInternal = this.RoleDevViewModelInternal;
		if (roleDevViewModelInternal != null)
		{
			roleDevViewModelInternal.SetRoleSkillPlanState(base.RoleId, isPerfectPlan);
		}
		this.UpdateSkillSlots();
	}

	// Token: 0x0601453A RID: 83258 RVA: 0x005A7ACC File Offset: 0x005A5CCC
	private void UpdateSkillSlots()
	{
		foreach (ISkillSlotExtendData skillSlotExtendData in this.SkillSlotsInternal)
		{
			int normalTargetLevel = this.SkillGoalUpgradeLevelInternal[skillSlotExtendData.NodeIndex];
			int perfectTargetLevel = this.PerfectGoalUpgradeLevelInternal[skillSlotExtendData.NodeIndex];
			skillSlotExtendData.NormalTargetLevel = normalTargetLevel;
			skillSlotExtendData.PerfectTargetLevel = perfectTargetLevel;
		}
	}

	// Token: 0x0601453B RID: 83259 RVA: 0x005A7B4C File Offset: 0x005A5D4C
	private List<IRoleDevDetailItemData> CreateSkillDetailItemsData(int[] skillNodeIdList, int[] currentLevels, int[] targetLevels, int roleId)
	{
		return RoleDevUtils.CreateSkillDetailItemsData(skillNodeIdList, currentLevels, targetLevels, roleId);
	}

	// Token: 0x04009DB4 RID: 40372
	private List<ISkillSlotExtendData> SkillSlotsInternal = new List<ISkillSlotExtendData>();

	// Token: 0x04009DB5 RID: 40373
	private List<int> SkillGoalUpgradeLevelInternal = new List<int>();

	// Token: 0x04009DB6 RID: 40374
	private List<IRoleDevDetailItemData> DetailItemsInternal = new List<IRoleDevDetailItemData>();

	// Token: 0x04009DB7 RID: 40375
	private List<int> PerfectGoalUpgradeLevelInternal = new List<int>();

	// Token: 0x04009DB8 RID: 40376
	private List<IRoleDevDetailItemData> PerfectDetailItemsInternal = new List<IRoleDevDetailItemData>();

	// Token: 0x04009DB9 RID: 40377
	[Nullable(2)]
	private RoleDevViewModel RoleDevViewModelInternal;
}
