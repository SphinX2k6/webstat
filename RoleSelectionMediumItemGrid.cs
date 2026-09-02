using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x020028FD RID: 10493
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleSelectionMediumItemGrid : LoopScrollMediumItemGrid<RoleDataBase>
{
	// Token: 0x06014D80 RID: 85376 RVA: 0x005C63BC File Offset: 0x005C45BC
	public void SetNeedShowTrial(bool state)
	{
		this.NeedShowTrial = state;
	}

	// Token: 0x06014D81 RID: 85377 RVA: 0x005C63C8 File Offset: 0x005C45C8
	protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
	{
		int dataId = data.GetDataId();
		bool value = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)dataId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId
		}) != null;
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			Data = data,
			ItemConfigId = new int?(data.GetDataId()),
			SkinId = data.GetRoleSkinId(),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				data.GetLevelData().GetLevel()
			},
			IsInTeam = new bool?(value),
			ElementId = new int?(data.GetRoleConfig().ElementId),
			IsTrialRoleVisible = new bool?(data.IsTrialRole() && this.NeedShowTrial),
			IsNewVisible = new bool?(data.GetIsNew())
		};
		base.SetUseFixedAsync(true);
		base.Apply<CharacterMediumItemGrid>(parameters);
		this.SetSelected(isSelected, false);
	}

	// Token: 0x06014D82 RID: 85378 RVA: 0x005C64B8 File Offset: 0x005C46B8
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
		base.SetNewVisible(new bool?(false));
		RoleDataBase roleDataBase = this.Data as RoleDataBase;
		if (roleDataBase != null)
		{
			roleDataBase.TryRemoveNewFlag();
		}
	}

	// Token: 0x06014D83 RID: 85379 RVA: 0x005C64EF File Offset: 0x005C46EF
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x0400A062 RID: 41058
	private bool NeedShowTrial;
}
