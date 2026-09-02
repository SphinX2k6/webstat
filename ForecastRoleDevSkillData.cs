using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x02002825 RID: 10277
[NullableContext(1)]
[Nullable(0)]
public class ForecastRoleDevSkillData : RoleDevSkillViewItemDataBase
{
	// Token: 0x06014513 RID: 83219 RVA: 0x005A7384 File Offset: 0x005A5584
	protected override void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel)
	{
		this.RoleDevViewModelInternal = roleDevViewModel;
		this.InitSkillData(roleId);
	}

	// Token: 0x06014514 RID: 83220 RVA: 0x005A7394 File Offset: 0x005A5594
	private void InitSkillData(int roleId)
	{
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId);
		if (roleDevProsProjectConfig == null)
		{
			return;
		}
		List<global::ISkillSlotExtendData> list = new List<global::ISkillSlotExtendData>();
		for (int i = 0; i < 5; i++)
		{
			list.Add(new global::SkillSlotExtendData
			{
				RoleId = roleId,
				SkillNodeId = 0,
				IconId = 0,
				CurrentLevel = 1,
				NormalTargetLevel = 10,
				PerfectTargetLevel = 10,
				SkillType = i + global::ESkillType.Skill1,
				NodeIndex = i
			});
		}
		List<global::IRoleDevDetailItemData> list2 = new List<global::IRoleDevDetailItemData>();
		List<int> skillItemGroup = roleDevProsProjectConfig.SkillItemGroup;
		if (skillItemGroup != null && skillItemGroup.Count > 0)
		{
			foreach (int itemGroupId in skillItemGroup)
			{
				RoleDevProsRoleItem? roleDevProsRoleItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsRoleItemConfig(itemGroupId);
				if (roleDevProsRoleItemConfig != null && roleDevProsRoleItemConfig.Value.ItemGroupLength > 0)
				{
					List<global::IItemMaterial> list3 = new List<global::IItemMaterial>();
					int itemGroupLength = roleDevProsRoleItemConfig.Value.ItemGroupLength;
					for (int j = 0; j < itemGroupLength; j++)
					{
						IntPair? intPair = roleDevProsRoleItemConfig.Value.ItemGroup(j);
						if (intPair != null)
						{
							int item = intPair.Value.Item1;
							int item2 = intPair.Value.Item2;
							list3.Add(new global::ItemMaterial
							{
								ItemId = item,
								RequiredCount = item2
							});
						}
					}
					if (list3.Count > 0)
					{
						List<global::IMaterialGroup> list4 = new List<global::IMaterialGroup>();
						List<global::IItemMaterial> list5 = new List<global::IItemMaterial>();
						foreach (global::IItemMaterial item3 in list3)
						{
							list5.Add(item3);
						}
						list4.Add(new global::MaterialGroup
						{
							Type = roleDevProsRoleItemConfig.Value.ItemTypeId,
							Materials = list5
						});
						List<global::IRoleDevDetailItemData> collection = RoleDevUtils.BuildDetailItemData(roleId, list4, ERoleDevMainPage.Skill);
						list2.AddRange(collection);
					}
				}
			}
		}
		this.SkillSlotsInternal = list;
		this.DetailItemsInternal = list2;
		this.PerfectDetailItemsInternal = list2;
	}

	// Token: 0x06014515 RID: 83221 RVA: 0x005A75F0 File Offset: 0x005A57F0
	protected override bool GetIsRoleOwned()
	{
		return false;
	}

	// Token: 0x06014516 RID: 83222 RVA: 0x005A75F3 File Offset: 0x005A57F3
	protected override bool GetIsPerfectPlan()
	{
		RoleDevViewModel roleDevViewModelInternal = this.RoleDevViewModelInternal;
		return roleDevViewModelInternal == null || roleDevViewModelInternal.GetRoleSkillPlanState(base.RoleId);
	}

	// Token: 0x06014517 RID: 83223 RVA: 0x005A760C File Offset: 0x005A580C
	protected override bool GetIsNormalPlanFinished()
	{
		return false;
	}

	// Token: 0x06014518 RID: 83224 RVA: 0x005A760F File Offset: 0x005A580F
	protected override bool GetIsPerfectPlanFinished()
	{
		return false;
	}

	// Token: 0x06014519 RID: 83225 RVA: 0x005A7612 File Offset: 0x005A5812
	protected override List<global::ISkillSlotExtendData> GetSkillSlots()
	{
		return this.SkillSlotsInternal;
	}

	// Token: 0x0601451A RID: 83226 RVA: 0x005A761A File Offset: 0x005A581A
	protected override List<int> GetSkillGoalUpgradeLevel()
	{
		return new List<int>
		{
			10,
			10,
			10,
			10,
			10
		};
	}

	// Token: 0x0601451B RID: 83227 RVA: 0x005A7649 File Offset: 0x005A5849
	protected override List<global::IRoleDevDetailItemData> GetNormalDetailItems()
	{
		return this.DetailItemsInternal;
	}

	// Token: 0x0601451C RID: 83228 RVA: 0x005A7651 File Offset: 0x005A5851
	protected override bool GetIsNormalAllMaterialEnough()
	{
		return RoleDevUtils.CheckAllItemsUp(this.DetailItemsInternal);
	}

	// Token: 0x0601451D RID: 83229 RVA: 0x005A765E File Offset: 0x005A585E
	protected override bool GetIsUnlockedPerfect()
	{
		return true;
	}

	// Token: 0x0601451E RID: 83230 RVA: 0x005A7661 File Offset: 0x005A5861
	protected override List<int> GetPerfectGoalUpgradeLevel()
	{
		return new List<int>
		{
			10,
			10,
			10,
			10,
			10
		};
	}

	// Token: 0x0601451F RID: 83231 RVA: 0x005A7690 File Offset: 0x005A5890
	protected override List<global::IRoleDevDetailItemData> GetPerfectDetailItems()
	{
		return this.PerfectDetailItemsInternal;
	}

	// Token: 0x06014520 RID: 83232 RVA: 0x005A7698 File Offset: 0x005A5898
	protected override bool GetIsPerfectMaterialEnough()
	{
		return RoleDevUtils.CheckAllItemsUp(this.PerfectDetailItemsInternal);
	}

	// Token: 0x06014521 RID: 83233 RVA: 0x005A76A5 File Offset: 0x005A58A5
	protected override bool GetIsBreakthroughLevelLow()
	{
		return false;
	}

	// Token: 0x06014522 RID: 83234 RVA: 0x005A76A8 File Offset: 0x005A58A8
	protected override bool GetIsHideMaterialList()
	{
		return false;
	}

	// Token: 0x06014523 RID: 83235 RVA: 0x005A76AB File Offset: 0x005A58AB
	protected override bool GetIsForecast()
	{
		return true;
	}

	// Token: 0x06014524 RID: 83236 RVA: 0x005A76AE File Offset: 0x005A58AE
	protected override bool GetShouldForcePerfectPlan()
	{
		return true;
	}

	// Token: 0x06014525 RID: 83237 RVA: 0x005A76B1 File Offset: 0x005A58B1
	public override void SwitchPlan()
	{
	}

	// Token: 0x04009DB0 RID: 40368
	private List<global::ISkillSlotExtendData> SkillSlotsInternal = new List<global::ISkillSlotExtendData>();

	// Token: 0x04009DB1 RID: 40369
	private List<global::IRoleDevDetailItemData> DetailItemsInternal = new List<global::IRoleDevDetailItemData>();

	// Token: 0x04009DB2 RID: 40370
	private List<global::IRoleDevDetailItemData> PerfectDetailItemsInternal = new List<global::IRoleDevDetailItemData>();

	// Token: 0x04009DB3 RID: 40371
	[Nullable(2)]
	private RoleDevViewModel RoleDevViewModelInternal;
}
