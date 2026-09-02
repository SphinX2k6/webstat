using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02002D35 RID: 11573
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyRogueRoleGridItem : LoopScrollMediumItemGrid<RoleDataBase>
{
	// Token: 0x060175B1 RID: 95665 RVA: 0x00679D40 File Offset: 0x00677F40
	protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
	{
		int dataId = data.GetDataId();
		int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(dataId);
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(dataId);
		CharacterMediumItemGrid characterMediumItemGrid = new CharacterMediumItemGrid();
		characterMediumItemGrid.ItemConfigId = new int?(dataId);
		characterMediumItemGrid.SkinId = data.GetRoleSkinId();
		characterMediumItemGrid.BottomTextId = (data.IsTrialRole() ? "WeRougeFormationMissingRole" : "Text_LevelShow_Text");
		MediumItemGridBase mediumItemGridBase = characterMediumItemGrid;
		object[] bottomTextParameter;
		if (!data.IsTrialRole())
		{
			(bottomTextParameter = new object[1])[0] = data.GetLevelData().GetLevel();
		}
		else
		{
			bottomTextParameter = null;
		}
		mediumItemGridBase.BottomTextParameter = bottomTextParameter;
		characterMediumItemGrid.Index = ((roleIndex > 0) ? new int?(roleIndex) : null);
		characterMediumItemGrid.ElementId = new int?(data.GetRoleConfig().ElementId);
		characterMediumItemGrid.IsDisable = new bool?(data.IsTrialRole());
		characterMediumItemGrid.Data = data;
		characterMediumItemGrid.SkillBranchIndex = ((roleSkillBranchIndexInCurrentGamePlay > -1) ? new int?(roleSkillBranchIndexInCurrentGamePlay) : null);
		CharacterMediumItemGrid parameters = characterMediumItemGrid;
		base.SetUseFixedAsync(true);
		base.Apply<CharacterMediumItemGrid>(parameters);
		bool bSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(dataId);
		this.SetSelected(bSelected, true);
	}

	// Token: 0x060175B2 RID: 95666 RVA: 0x00679E6E File Offset: 0x0067806E
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x060175B3 RID: 95667 RVA: 0x00679E78 File Offset: 0x00678078
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x060175B4 RID: 95668 RVA: 0x00679E82 File Offset: 0x00678082
	public void OnForceSelected(bool bSelected)
	{
		this.SetSelected(bSelected, true);
	}

	// Token: 0x060175B5 RID: 95669 RVA: 0x00679E8C File Offset: 0x0067808C
	public override object GetKey(RoleDataBase data, int gridIndex)
	{
		return data.GetDataId();
	}
}
