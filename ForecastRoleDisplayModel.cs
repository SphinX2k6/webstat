using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;

// Token: 0x020027DA RID: 10202
[NullableContext(2)]
[Nullable(0)]
public class ForecastRoleDisplayModel : RoleDisplayModelBase
{
	// Token: 0x0601428A RID: 82570 RVA: 0x005A064C File Offset: 0x0059E84C
	public void InitByRoleId(int roleId)
	{
		this.RoleIdInternal = roleId;
		ERoleTypeTag roleTypeTagByRoleId = RoleDevUtils.GetRoleTypeTagByRoleId(roleId);
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId);
		base.InitBase(new RoleDisplayModelBaseInitParams
		{
			Id = roleId,
			Name = roleDevProsProjectConfig.RoleName,
			SkinId = 0,
			ElementId = roleDevProsProjectConfig.ElementId,
			Level = 1,
			IsInTeam = false,
			IsTrial = false,
			IsNew = false,
			TypeTag = roleTypeTagByRoleId
		});
	}

	// Token: 0x17001998 RID: 6552
	// (get) Token: 0x0601428B RID: 82571 RVA: 0x005A06C7 File Offset: 0x0059E8C7
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001999 RID: 6553
	// (get) Token: 0x0601428C RID: 82572 RVA: 0x005A06CF File Offset: 0x0059E8CF
	public override ERoleDisplaySourceType SourceType
	{
		get
		{
			return ERoleDisplaySourceType.ForecastConfig;
		}
	}

	// Token: 0x1700199A RID: 6554
	// (get) Token: 0x0601428D RID: 82573 RVA: 0x005A06D2 File Offset: 0x0059E8D2
	public override RoleDataBase OriginRoleData
	{
		get
		{
			return null;
		}
	}

	// Token: 0x04009CF6 RID: 40182
	private int RoleIdInternal;
}
