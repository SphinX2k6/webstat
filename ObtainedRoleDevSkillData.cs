using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002827 RID: 10279
[NullableContext(1)]
[Nullable(0)]
public class ObtainedRoleDevSkillData : RoleDevSkillViewItemDataBase
{
	// Token: 0x0601453D RID: 83261 RVA: 0x005A7B97 File Offset: 0x005A5D97
	protected override void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel)
	{
		this.RoleDevViewModelInternal = roleDevViewModel;
		this.InitSkillData(roleId);
	}

	// Token: 0x0601453E RID: 83262 RVA: 0x005A7BA8 File Offset: 0x005A5DA8
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
				list3.Add(ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(roleId, id));
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
					list3.Add(ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(roleId, id2));
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
		this.NormalTargetSkillLevelInternal = list4;
		this.PerfectTargetSkillLevelInternal = list5;
		this.DetailItemsInternal = detailItemsInternal;
		this.PerfectDetailItemsInternal = perfectDetailItemsInternal;
		this.AllSkillNodeIdListInternal = list6;
		if (this.RoleDevViewModelInternal != null && !this.RoleDevViewModelInternal.CheckRoleIdIsCreated(roleId))
		{
			RoleDevViewModel roleDevViewModelInternal = this.RoleDevViewModelInternal;
			if (roleDevViewModelInternal == null)
			{
				return;
			}
			roleDevViewModelInternal.SetRoleSkillPlanState(roleId, base.IsNormalPlanFinished);
		}
	}

	// Token: 0x0601453F RID: 83263 RVA: 0x005A7F20 File Offset: 0x005A6120
	protected override bool GetIsRoleOwned()
	{
		return true;
	}

	// Token: 0x06014540 RID: 83264 RVA: 0x005A7F23 File Offset: 0x005A6123
	protected override bool GetIsPerfectPlan()
	{
		RoleDevViewModel roleDevViewModelInternal = this.RoleDevViewModelInternal;
		return roleDevViewModelInternal != null && roleDevViewModelInternal.GetRoleSkillPlanState(base.RoleId);
	}

	// Token: 0x06014541 RID: 83265 RVA: 0x005A7F3C File Offset: 0x005A613C
	protected override bool GetIsNormalPlanFinished()
	{
		return this.CheckPlanFinished((from skillNodeId in this.AllSkillNodeIdListInternal
		select ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(base.RoleId, skillNodeId)).ToList<int>(), this.NormalTargetSkillLevelInternal);
	}

	// Token: 0x06014542 RID: 83266 RVA: 0x005A7F66 File Offset: 0x005A6166
	protected override bool GetIsPerfectPlanFinished()
	{
		return this.CheckPlanFinished((from skillNodeId in this.AllSkillNodeIdListInternal
		select ModelBase<RoleModel>.Instance.GetRoleSkillTreeNodeLevel(base.RoleId, skillNodeId)).ToList<int>(), this.PerfectTargetSkillLevelInternal);
	}

	// Token: 0x06014543 RID: 83267 RVA: 0x005A7F90 File Offset: 0x005A6190
	protected override List<ISkillSlotExtendData> GetSkillSlots()
	{
		return this.SkillSlotsInternal;
	}

	// Token: 0x06014544 RID: 83268 RVA: 0x005A7F98 File Offset: 0x005A6198
	protected override List<int> GetSkillGoalUpgradeLevel()
	{
		return this.NormalTargetSkillLevelInternal;
	}

	// Token: 0x06014545 RID: 83269 RVA: 0x005A7FA0 File Offset: 0x005A61A0
	protected override List<IRoleDevDetailItemData> GetNormalDetailItems()
	{
		return this.DetailItemsInternal;
	}

	// Token: 0x06014546 RID: 83270 RVA: 0x005A7FA8 File Offset: 0x005A61A8
	protected override bool GetIsNormalAllMaterialEnough()
	{
		return RoleDevUtils.CheckAllItemsUp(this.DetailItemsInternal);
	}

	// Token: 0x06014547 RID: 83271 RVA: 0x005A7FB8 File Offset: 0x005A61B8
	protected override bool GetIsUnlockedPerfect()
	{
		int? playerLevel = ModelBase<FunctionModel>.Instance.GetPlayerLevel();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(base.RoleId);
		int? num = (roleConfig != null) ? new int?(roleConfig.GetValueOrDefault().MaxLevel) : null;
		return this.PerfectTargetSkillLevelInternal.Count > 0 && playerLevel != null && num != null && playerLevel.Value >= num.Value;
	}

	// Token: 0x06014548 RID: 83272 RVA: 0x005A8040 File Offset: 0x005A6240
	protected override List<int> GetPerfectGoalUpgradeLevel()
	{
		return this.PerfectTargetSkillLevelInternal;
	}

	// Token: 0x06014549 RID: 83273 RVA: 0x005A8048 File Offset: 0x005A6248
	protected override List<IRoleDevDetailItemData> GetPerfectDetailItems()
	{
		return this.PerfectDetailItemsInternal;
	}

	// Token: 0x0601454A RID: 83274 RVA: 0x005A8050 File Offset: 0x005A6250
	protected override bool GetIsPerfectMaterialEnough()
	{
		return RoleDevUtils.CheckAllItemsUp(this.PerfectDetailItemsInternal);
	}

	// Token: 0x0601454B RID: 83275 RVA: 0x005A8060 File Offset: 0x005A6260
	protected override bool GetIsBreakthroughLevelLow()
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(base.RoleId, true);
		if (roleDataById == null)
		{
			return false;
		}
		int breachLevel = roleDataById.GetLevelData().GetBreachLevel();
		for (int i = 0; i < this.SkillSlotsInternal.Count; i++)
		{
			if (this.SkillSlotsInternal[i].CurrentLevel >= this.NormalTargetSkillLevelInternal[i] && breachLevel < 6)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601454C RID: 83276 RVA: 0x005A80CC File Offset: 0x005A62CC
	protected override bool GetIsHideMaterialList()
	{
		return false;
	}

	// Token: 0x0601454D RID: 83277 RVA: 0x005A80CF File Offset: 0x005A62CF
	protected override bool GetIsForecast()
	{
		return false;
	}

	// Token: 0x0601454E RID: 83278 RVA: 0x005A80D2 File Offset: 0x005A62D2
	protected override bool GetShouldForcePerfectPlan()
	{
		return false;
	}

	// Token: 0x0601454F RID: 83279 RVA: 0x005A80D8 File Offset: 0x005A62D8
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

	// Token: 0x06014550 RID: 83280 RVA: 0x005A8110 File Offset: 0x005A6310
	private void UpdateSkillSlots()
	{
		foreach (ISkillSlotExtendData skillSlotExtendData in this.SkillSlotsInternal)
		{
			int normalTargetLevel = this.NormalTargetSkillLevelInternal[skillSlotExtendData.NodeIndex];
			int perfectTargetLevel = this.PerfectTargetSkillLevelInternal[skillSlotExtendData.NodeIndex];
			skillSlotExtendData.NormalTargetLevel = normalTargetLevel;
			skillSlotExtendData.PerfectTargetLevel = perfectTargetLevel;
		}
	}

	// Token: 0x06014551 RID: 83281 RVA: 0x005A8190 File Offset: 0x005A6390
	private bool CheckPlanFinished(List<int> currentLevels, List<int> targetLevels)
	{
		if (targetLevels.Count == 0 || currentLevels.Count != targetLevels.Count)
		{
			return false;
		}
		for (int i = 0; i < currentLevels.Count; i++)
		{
			if (currentLevels[i] < targetLevels[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06014552 RID: 83282 RVA: 0x005A81D9 File Offset: 0x005A63D9
	private List<IRoleDevDetailItemData> CreateSkillDetailItemsData(int[] skillNodeIdList, int[] currentLevels, int[] targetLevels, int roleId)
	{
		return RoleDevUtils.CreateSkillDetailItemsData(skillNodeIdList, currentLevels, targetLevels, roleId);
	}

	// Token: 0x04009DBA RID: 40378
	private List<ISkillSlotExtendData> SkillSlotsInternal = new List<ISkillSlotExtendData>();

	// Token: 0x04009DBB RID: 40379
	private List<int> AllSkillNodeIdListInternal = new List<int>();

	// Token: 0x04009DBC RID: 40380
	private List<int> NormalTargetSkillLevelInternal = new List<int>();

	// Token: 0x04009DBD RID: 40381
	private List<IRoleDevDetailItemData> DetailItemsInternal = new List<IRoleDevDetailItemData>();

	// Token: 0x04009DBE RID: 40382
	private List<int> PerfectTargetSkillLevelInternal = new List<int>();

	// Token: 0x04009DBF RID: 40383
	private List<IRoleDevDetailItemData> PerfectDetailItemsInternal = new List<IRoleDevDetailItemData>();

	// Token: 0x04009DC0 RID: 40384
	[Nullable(2)]
	private RoleDevViewModel RoleDevViewModelInternal;
}
