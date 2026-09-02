using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x020029D4 RID: 10708
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerRoleGrid : LoopScrollMediumItemGrid<RoleDataBase>
{
	// Token: 0x06015590 RID: 87440 RVA: 0x005EA6E0 File Offset: 0x005E88E0
	protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
	{
		RoleLevelData levelData = data.GetLevelData();
		int dataId = data.GetDataId();
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(dataId);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(dataId),
			SkinId = data.GetRoleSkinId(),
			IsTrialRoleVisible = new bool?(data.IsTrialRole()),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				levelData.GetLevel()
			},
			ElementId = new int?(data.GetRoleConfig().ElementId),
			Data = data,
			IsRecommendVisible = new bool?(false),
			HalfAreaInfo = ModelBase<ShipTowerModel>.Instance.GetAllTeamRoleData(dataId),
			SkillBranchIndex = ((roleSkillBranchIndexInCurrentGamePlay >= 0) ? new int?(roleSkillBranchIndexInCurrentGamePlay) : null)
		};
		base.Apply<CharacterMediumItemGrid>(parameters);
		if (data.IsTrialRole())
		{
			base.SetLevelAndLock(null, null, null, null, null, null);
		}
		else
		{
			bool value = data == null || !ModelBase<EditBattleTeamModel>.Instance.CanAddRoleToEditTeam(dataId);
			base.SetLevelAndLock(null, new bool?(value), null, null, null, null);
		}
		bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
		this.SetSelected(bSelected, true);
	}

	// Token: 0x06015591 RID: 87441 RVA: 0x005EA886 File Offset: 0x005E8A86
	public void OnForceSelected()
	{
		this.SetSelected(true, true);
	}

	// Token: 0x06015592 RID: 87442 RVA: 0x005EA890 File Offset: 0x005E8A90
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06015593 RID: 87443 RVA: 0x005EA89A File Offset: 0x005E8A9A
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x0400A471 RID: 42097
	[Nullable(2)]
	public Func<int, bool> IsHighlightIndex;
}
