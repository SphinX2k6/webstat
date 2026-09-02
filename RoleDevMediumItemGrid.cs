using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;

// Token: 0x02002802 RID: 10242
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevMediumItemGrid : LoopScrollMediumItemGrid<RoleDataBase>
{
	// Token: 0x06014381 RID: 82817 RVA: 0x005A1948 File Offset: 0x0059FB48
	protected override void OnRefresh(RoleDataBase data, bool isSelected, int gridIndex)
	{
		int dataId = data.GetDataId();
		this.RoleId = dataId;
		bool value = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)dataId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId,
			OnlyMyRole = new bool?(true)
		}) != null;
		bool value2 = ModelBase<RoleDevModel>.Instance.DevTargetRoleId == dataId;
		CharacterMediumItemGrid parameters;
		if (ModelBase<RoleModel>.Instance.IsRoleOwned(dataId))
		{
			parameters = new CharacterMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.GetRoleId()),
				SkinId = data.GetRoleSkinId(),
				BottomTextId = "Text_LevelShow_Text",
				BottomTextParameter = new object[]
				{
					data.GetLevelData().GetLevel()
				},
				IsInTeam = new bool?(value),
				IsRoleDevelopTagMark = new bool?(value2),
				ElementId = new int?(data.GetRoleConfig().ElementId),
				IsTrialRoleVisible = new bool?(false)
			};
		}
		else
		{
			RoleInfo roleConfig = data.GetRoleConfig();
			parameters = new CharacterMediumItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.GetRoleId()),
				SkinId = data.GetRoleSkinId(),
				BottomText = ConfigMultiTextLang.GetLocalTextNew(roleConfig.Name, null),
				IsInTeam = new bool?(value),
				ElementId = new int?(data.GetRoleConfig().ElementId),
				IsTrialRoleVisible = new bool?(false),
				IsShowLock = new bool?(true),
				IsDisable = new bool?(true)
			};
		}
		base.Apply<CharacterMediumItemGrid>(parameters);
		this.SetSelected(isSelected, false);
	}

	// Token: 0x06014382 RID: 82818 RVA: 0x005A1AEB File Offset: 0x0059FCEB
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
	}

	// Token: 0x06014383 RID: 82819 RVA: 0x005A1AF5 File Offset: 0x0059FCF5
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, true);
	}

	// Token: 0x06014384 RID: 82820 RVA: 0x005A1AFF File Offset: 0x0059FCFF
	public object GetKey()
	{
		return this.RoleId;
	}

	// Token: 0x04009D65 RID: 40293
	private int RoleId;
}
