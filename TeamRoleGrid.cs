using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Module.InstanceDungeon;

// Token: 0x0200279A RID: 10138
[NullableContext(2)]
[Nullable(0)]
public class TeamRoleGrid : TeamRoleGridBase
{
	// Token: 0x1700197A RID: 6522
	// (get) Token: 0x0601402E RID: 81966 RVA: 0x00594A06 File Offset: 0x00592C06
	// (set) Token: 0x0601402F RID: 81967 RVA: 0x00594A0E File Offset: 0x00592C0E
	public override Func<int, bool> IsHighlightIndex { get; set; }

	// Token: 0x1700197B RID: 6523
	// (get) Token: 0x06014030 RID: 81968 RVA: 0x00594A17 File Offset: 0x00592C17
	// (set) Token: 0x06014031 RID: 81969 RVA: 0x00594A1F File Offset: 0x00592C1F
	public override Func<int, bool> IsShowGray { get; set; }

	// Token: 0x06014032 RID: 81970 RVA: 0x00594A28 File Offset: 0x00592C28
	[NullableContext(1)]
	protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
	{
		RoleLevelData levelData = data.GetLevelData();
		int dataId = data.GetDataId();
		EditFormationModel instance = ModelBase<EditFormationModel>.Instance;
		int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId);
		bool flag = false;
		bool flag2 = data.IsTrialRole();
		if (!flag2 && !ModelBase<TowerModel>.Instance.IsOpenFloorFormation() && !ControllerBase<LordGymController>.Instance.IsInLordGymDungeon() && !ModelBase<MowingTowerModel>.Instance.IsOpenMowingTowerFormation() && !ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance())
		{
			flag = instance.IsRoleDead(dataId);
		}
		Func<int, bool> isHighlightIndex = this.IsHighlightIndex;
		bool? highlightIndex = (isHighlightIndex != null) ? new bool?(isHighlightIndex(roleIndex)) : null;
		bool value = false;
		bool value2 = false;
		if (ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId > 0)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId);
			if (config != null)
			{
				int[] array = config.Value.RecommendRole();
				value = (array != null && array.Contains(data.GetRoleId()));
				int[] array2 = config.Value.RecommendRoleBottom();
				value2 = (array2 != null && array2.Contains(data.GetRoleId()));
			}
		}
		List<int> otherHalfAreaRoleList = ModelBase<MowingTowerModel>.Instance.OtherHalfAreaRoleList;
		object obj;
		if (otherHalfAreaRoleList == null || !otherHalfAreaRoleList.Contains(dataId))
		{
			obj = null;
		}
		else
		{
			(obj = new HaveAreaInfo()).BelongTo = ETeamBelong.LowPart - ModelBase<MowingTowerModel>.Instance.CurrentOptionArea;
		}
		HaveAreaInfo halfAreaInfo = obj;
		Func<int, bool> isShowGray = this.IsShowGray;
		bool flag3 = isShowGray != null && isShowGray(data.GetDataId()) && flag;
		MediumItemGridCostComponentData showCostData = null;
		if (ModelBase<TowerModel>.Instance.IsOpenFloorFormation() && !flag3)
		{
			int roleRemainCost = ModelBase<TowerModel>.Instance.GetRoleRemainCost(dataId, ModelBase<TowerModel>.Instance.CurrentSelectDifficulties);
			showCostData = new MediumItemGridCostComponentData
			{
				Cost = roleRemainCost,
				Color = ((roleRemainCost >= 4) ? TowerData.highColor.Value : TowerData.lowColor.Value)
			};
		}
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(dataId);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(dataId),
			SkinId = data.GetRoleSkinId(),
			IsTrialRoleVisible = new bool?(flag2),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				levelData.GetLevel()
			},
			Index = ((roleIndex > 0) ? new int?(roleIndex) : null),
			HighlightIndex = highlightIndex,
			ElementId = new int?(data.GetRoleConfig().ElementId),
			ShowCostData = showCostData,
			Data = data,
			IsDisable = new bool?(flag),
			IsRecommendVisible = new bool?(value),
			HalfAreaInfo = halfAreaInfo,
			IsShowWeeklyRogueTag = new bool?(ModelBase<WeeklyRogueModel>.Instance.IsWeeklyRogueOpen() && ModelBase<WeeklyRogueModel>.Instance.CheckIsRecommendRole(dataId)),
			IsRecommendBottomVisible = new bool?(value2),
			SkillBranchIndex = ((roleSkillBranchIndexInCurrentGamePlay > -1) ? new int?(roleSkillBranchIndexInCurrentGamePlay) : null)
		};
		base.Apply<CharacterMediumItemGrid>(parameters);
		if (data.IsTrialRole())
		{
			base.SetLevelAndLock(null, null, null, null, null, null);
		}
		else
		{
			bool value3 = data == null || !ModelBase<EditBattleTeamModel>.Instance.CanAddRoleToEditTeam(dataId);
			base.SetLevelAndLock(null, new bool?(value3), null, null, null, null);
		}
		int[] addLevel = ModelBase<MowingTowerModel>.Instance.AddLevel;
		if (addLevel != null && addLevel.Length != 0)
		{
			bool flag4 = data.GetLevelData().GetLevel() < addLevel[0];
			if (addLevel[0] != -1 && flag4)
			{
				this.SetAddLevelComponent(addLevel[0], flag4);
			}
		}
		int[] addLevel2 = ModelBase<HonamiStoryModel>.Instance.AddLevel;
		if (addLevel2 != null && addLevel2.Length != 0)
		{
			bool flag5 = data.GetLevelData().GetLevel() < addLevel2[0];
			if (addLevel2[0] != -1 && flag5)
			{
				this.SetAddLevelComponent(addLevel2[0], flag5);
			}
		}
		base.SetIsDisable(new bool?(flag3));
		bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
		this.SetSelected(bSelected, true);
	}

	// Token: 0x06014033 RID: 81971 RVA: 0x00594E76 File Offset: 0x00593076
	public override void OnForceSelected()
	{
		this.SetSelected(true, true);
	}

	// Token: 0x06014034 RID: 81972 RVA: 0x00594E80 File Offset: 0x00593080
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06014035 RID: 81973 RVA: 0x00594E8A File Offset: 0x0059308A
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x06014036 RID: 81974 RVA: 0x00594E94 File Offset: 0x00593094
	public void SetAddLevelComponent(int addLevel, bool isShow)
	{
		RoleDataBase roleDataBase = this.Data as RoleDataBase;
		if (roleDataBase == null)
		{
			return;
		}
		int num = Math.Max(roleDataBase.GetLevelData().GetLevel(), addLevel);
		ItemGridComponent component = base.RefreshComponent(typeof(RogueAddLevelComponent), new bool?(true), num);
		base.SetComponentVisible(component, isShow);
		if (num > 0)
		{
			base.SetBottomTextVisible(false);
		}
	}
}
