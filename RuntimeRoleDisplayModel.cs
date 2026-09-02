using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020027DD RID: 10205
[NullableContext(2)]
[Nullable(0)]
public class RuntimeRoleDisplayModel : RoleDisplayModelBase
{
	// Token: 0x060142AF RID: 82607 RVA: 0x005A084C File Offset: 0x0059EA4C
	[NullableContext(1)]
	public void InitByRoleData(RoleDataBase data)
	{
		int dataId = data.GetDataId();
		bool isInTeam = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)dataId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId
		}) != null;
		ERoleTypeTag roleTypeTagByRoleId = RoleDevUtils.GetRoleTypeTagByRoleId(dataId);
		RoleInfo roleConfig = data.GetRoleConfig();
		base.InitBase(new RoleDisplayModelBaseInitParams
		{
			Id = dataId,
			Name = ConfigMultiTextLang.GetLocalTextNew(roleConfig.Name, null),
			SkinId = data.GetRoleSkinId(),
			ElementId = roleConfig.ElementId,
			Level = data.GetLevelData().GetLevel(),
			IsInTeam = isInTeam,
			IsTrial = false,
			IsNew = data.GetIsNew(),
			TypeTag = roleTypeTagByRoleId
		});
		this.RoleDataInternal = data;
	}

	// Token: 0x060142B0 RID: 82608 RVA: 0x005A0904 File Offset: 0x0059EB04
	public void InitByRoleId(int roleId)
	{
		bool isInTeam = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)roleId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId
		}) != null;
		ERoleTypeTag roleTypeTagByRoleId = RoleDevUtils.GetRoleTypeTagByRoleId(roleId);
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value;
		base.InitBase(new RoleDisplayModelBaseInitParams
		{
			Id = roleId,
			Name = ConfigMultiTextLang.GetLocalTextNew(value.Name, null),
			SkinId = value.SkinId,
			ElementId = value.ElementId,
			Level = 0,
			IsInTeam = isInTeam,
			IsTrial = false,
			IsNew = false,
			TypeTag = roleTypeTagByRoleId
		});
	}

	// Token: 0x170019AF RID: 6575
	// (get) Token: 0x060142B1 RID: 82609 RVA: 0x005A09AA File Offset: 0x0059EBAA
	public override ERoleDisplaySourceType SourceType
	{
		get
		{
			return ERoleDisplaySourceType.RuntimeData;
		}
	}

	// Token: 0x170019B0 RID: 6576
	// (get) Token: 0x060142B2 RID: 82610 RVA: 0x005A09AD File Offset: 0x0059EBAD
	public override RoleDataBase OriginRoleData
	{
		get
		{
			return this.RoleDataInternal;
		}
	}

	// Token: 0x04009D09 RID: 40201
	private RoleDataBase RoleDataInternal;
}
