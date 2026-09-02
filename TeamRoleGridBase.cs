using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Module.InstanceDungeon;

// Token: 0x0200279B RID: 10139
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TeamRoleGridBase : LoopScrollMediumItemGrid<RoleDataBase>
{
	// Token: 0x1700197C RID: 6524
	// (get) Token: 0x06014038 RID: 81976 RVA: 0x00594EFB File Offset: 0x005930FB
	// (set) Token: 0x06014039 RID: 81977 RVA: 0x00594F03 File Offset: 0x00593103
	public virtual Func<int, bool> IsHighlightIndex { get; set; }

	// Token: 0x1700197D RID: 6525
	// (get) Token: 0x0601403A RID: 81978 RVA: 0x00594F0C File Offset: 0x0059310C
	// (set) Token: 0x0601403B RID: 81979 RVA: 0x00594F14 File Offset: 0x00593114
	public virtual Func<int, bool> IsShowGray { get; set; }

	// Token: 0x0601403C RID: 81980 RVA: 0x00594F20 File Offset: 0x00593120
	[NullableContext(1)]
	protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
	{
		RoleLevelData levelData = data.GetLevelData();
		int dataId = data.GetDataId();
		int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId);
		bool value = data.IsTrialRole();
		Func<int, bool> isHighlightIndex = this.IsHighlightIndex;
		bool? highlightIndex = (isHighlightIndex != null) ? new bool?(isHighlightIndex(roleIndex)) : null;
		bool value2 = false;
		bool value3 = false;
		if (ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId != 0)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<InstanceDungeonEntranceModel>.Instance.SelectInstanceId);
			int[] array = config.Value.RecommendRole();
			value2 = (array != null && array.Contains(data.GetRoleId()));
			int[] array2 = config.Value.RecommendRoleBottom();
			value3 = (array2 != null && array2.Contains(data.GetRoleId()));
		}
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(dataId);
		CharacterMediumItemGrid baseParameter = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(dataId),
			SkinId = data.GetRoleSkinId(),
			IsTrialRoleVisible = new bool?(value),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				levelData.GetLevel()
			},
			Index = ((roleIndex > 0) ? new int?(roleIndex) : null),
			HighlightIndex = highlightIndex,
			ElementId = new int?(data.GetRoleConfig().ElementId),
			Data = data,
			IsRecommendVisible = new bool?(value2),
			IsRecommendBottomVisible = new bool?(value3),
			SkillBranchIndex = ((roleSkillBranchIndexInCurrentGamePlay > -1) ? new int?(roleSkillBranchIndexInCurrentGamePlay) : null)
		};
		base.Apply<CharacterMediumItemGrid>(this.GetRoleParameters(baseParameter, data));
		this.ExtraRefreshFunc(data);
		if (data.IsTrialRole())
		{
			base.SetLevelAndLock(null, null, null, null, null, null);
		}
		else
		{
			bool value4 = data == null || !ModelBase<EditBattleTeamModel>.Instance.CanAddRoleToEditTeam(dataId);
			base.SetLevelAndLock(null, new bool?(value4), null, null, null, null);
		}
		bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
		this.SetSelected(bSelected, true);
	}

	// Token: 0x0601403D RID: 81981 RVA: 0x005951A5 File Offset: 0x005933A5
	[NullableContext(1)]
	protected virtual CharacterMediumItemGrid GetRoleParameters(CharacterMediumItemGrid baseParameter, RoleDataBase data)
	{
		return baseParameter;
	}

	// Token: 0x0601403E RID: 81982 RVA: 0x005951A8 File Offset: 0x005933A8
	[NullableContext(1)]
	protected virtual void ExtraRefreshFunc(RoleDataBase data)
	{
	}

	// Token: 0x0601403F RID: 81983 RVA: 0x005951AA File Offset: 0x005933AA
	public virtual void OnForceSelected()
	{
		this.SetSelected(true, true);
	}

	// Token: 0x06014040 RID: 81984 RVA: 0x005951B4 File Offset: 0x005933B4
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06014041 RID: 81985 RVA: 0x005951BE File Offset: 0x005933BE
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}
}
