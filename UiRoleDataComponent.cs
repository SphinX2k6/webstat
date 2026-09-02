using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002CA8 RID: 11432
public class UiRoleDataComponent : UiModelComponentBase
{
	// Token: 0x17001E32 RID: 7730
	// (get) Token: 0x06016F06 RID: 93958 RVA: 0x0065BC10 File Offset: 0x00659E10
	public int RoleDataId
	{
		get
		{
			return this.RoleDataIdInternal;
		}
	}

	// Token: 0x17001E33 RID: 7731
	// (get) Token: 0x06016F07 RID: 93959 RVA: 0x0065BC18 File Offset: 0x00659E18
	public int RoleConfigId
	{
		get
		{
			return this.RoleConfigIdInternal;
		}
	}

	// Token: 0x17001E34 RID: 7732
	// (get) Token: 0x06016F08 RID: 93960 RVA: 0x0065BC20 File Offset: 0x00659E20
	public int RoleSkinId
	{
		get
		{
			return this.RoleSkinIdInternal;
		}
	}

	// Token: 0x06016F09 RID: 93961 RVA: 0x0065BC28 File Offset: 0x00659E28
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
	}

	// Token: 0x06016F0A RID: 93962 RVA: 0x0065BC3C File Offset: 0x00659E3C
	public void SetRoleConfigId(int roleConfigId, int skinId = -1)
	{
		this.RoleConfigIdInternal = roleConfigId;
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId);
		this.RoleSkinIdInternal = ((skinId == -1) ? roleConfig.Value.SkinId : skinId);
		if (this.RoleSkinIdInternal <= 0)
		{
			this.ModelDataComponent.ModelConfigId = roleConfig.Value.UiMeshId;
		}
		else
		{
			RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(this.RoleSkinIdInternal);
			this.ModelDataComponent.ModelConfigId = roleSkinData.GetUiMeshId();
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Owner, EEventName.OnUiModelRoleConfigIdChange);
	}

	// Token: 0x06016F0B RID: 93963 RVA: 0x0065BCD8 File Offset: 0x00659ED8
	public void SetRoleDataId(int roleDataId, int skinId = -1)
	{
		this.RoleDataIdInternal = roleDataId;
		RoleModel instance = ModelBase<RoleModel>.Instance;
		RoleDataBase roleDataBase = (instance != null) ? instance.GetRoleDataById(roleDataId, true) : null;
		if (roleDataBase == null)
		{
			return;
		}
		this.SetRoleConfigId(roleDataBase.GetRoleId(), skinId);
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Owner, EEventName.OnUiModelRoleDataIdChange);
	}

	// Token: 0x0400B0E9 RID: 45289
	[Nullable(2)]
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B0EA RID: 45290
	private int RoleDataIdInternal;

	// Token: 0x0400B0EB RID: 45291
	private int RoleConfigIdInternal;

	// Token: 0x0400B0EC RID: 45292
	private int RoleSkinIdInternal;
}
