using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C9E RID: 11422
[NullableContext(2)]
[Nullable(0)]
public class UiMotorLoadComponent : UiModelLoadComponent
{
	// Token: 0x06016ECD RID: 93901 RVA: 0x0065ACAC File Offset: 0x00658EAC
	protected override void OnInit()
	{
		base.OnInit();
		this.UiMotorDataComponent = base.Owner.CheckGetComponent<UiMotorDataComponent>();
	}

	// Token: 0x06016ECE RID: 93902 RVA: 0x0065ACC5 File Offset: 0x00658EC5
	protected override void OnEnd()
	{
		base.OnEnd();
		this.UiMotorDataComponent = null;
	}

	// Token: 0x06016ECF RID: 93903 RVA: 0x0065ACD4 File Offset: 0x00658ED4
	public void LoadModelBySkinId(int skinId, bool waitMeshStreaming, Action loadFinishCallBack = null, int? roleId = null, int? roleSkinId = null)
	{
		this.UiMotorDataComponent.SetSkinId(skinId);
		this.UiModelDataComponent.ModelConfigId = skinId;
		this.LoadFinishCallBack = loadFinishCallBack;
		if (roleId != null && roleSkinId != null)
		{
			this.UiMotorDataComponent.SetRoleData(roleId.Value, roleSkinId.Value, null);
		}
		base.LoadModel(waitMeshStreaming, null, 1);
	}

	// Token: 0x0400B0CB RID: 45259
	private UiMotorDataComponent UiMotorDataComponent;
}
