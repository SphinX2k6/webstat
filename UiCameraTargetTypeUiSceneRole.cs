using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02002C3F RID: 11327
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiSceneRole : UiCameraTargetTypeBase
{
	// Token: 0x06016B09 RID: 92937 RVA: 0x0064CCEF File Offset: 0x0064AEEF
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		return Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
	}

	// Token: 0x06016B0A RID: 92938 RVA: 0x0064CCFC File Offset: 0x0064AEFC
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		if (roleSystemRoleActor == null)
		{
			return null;
		}
		UiModelBase model = roleSystemRoleActor.Model;
		UiRoleMorphComponent uiRoleMorphComponent = (model != null) ? model.GetComponent<UiRoleMorphComponent>() : null;
		IUiMorphData uiMorphData = (uiRoleMorphComponent != null) ? uiRoleMorphComponent.GetCurrentMorphData() : null;
		if (uiMorphData != null)
		{
			return uiMorphData.RoleBody;
		}
		UiModelBase model2 = roleSystemRoleActor.Model;
		UiRoleDataComponent uiRoleDataComponent = (model2 != null) ? model2.CheckGetComponent<UiRoleDataComponent>() : null;
		int roleConfigId = uiRoleDataComponent.RoleConfigId;
		int roleSkinId = uiRoleDataComponent.RoleSkinId;
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId);
		if (roleConfig == null)
		{
			return null;
		}
		if (roleSkinId <= 0)
		{
			return roleConfig.Value.RoleBody;
		}
		return ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleSkinId).GetRoleBody();
	}

	// Token: 0x06016B0B RID: 92939 RVA: 0x0064CDA0 File Offset: 0x0064AFA0
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		if (roleSystemRoleActor == null)
		{
			return null;
		}
		UiModelBase model = roleSystemRoleActor.Model;
		if (model == null)
		{
			return null;
		}
		UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
		if (uiModelActorComponent == null)
		{
			return null;
		}
		return uiModelActorComponent.MainMeshComponent;
	}
}
