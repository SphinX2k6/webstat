using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02002C3C RID: 11324
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiSceneFormationRole : UiCameraTargetTypeBase
{
	// Token: 0x06016AFD RID: 92925 RVA: 0x0064CB64 File Offset: 0x0064AD64
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		return Singleton<UiSceneManager>.Instance.GetCurrentSelectFormationRoleActor();
	}

	// Token: 0x06016AFE RID: 92926 RVA: 0x0064CB70 File Offset: 0x0064AD70
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		TsUiSceneRoleActor currentSelectFormationRoleActor = Singleton<UiSceneManager>.Instance.GetCurrentSelectFormationRoleActor();
		if (currentSelectFormationRoleActor == null)
		{
			return null;
		}
		UiModelBase model = currentSelectFormationRoleActor.Model;
		UiRoleDataComponent uiRoleDataComponent = (model != null) ? model.CheckGetComponent<UiRoleDataComponent>() : null;
		if (uiRoleDataComponent == null)
		{
			return null;
		}
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
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleSkinId);
		if (roleSkinData == null)
		{
			return null;
		}
		return roleSkinData.GetRoleBody();
	}

	// Token: 0x06016AFF RID: 92927 RVA: 0x0064CBF8 File Offset: 0x0064ADF8
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		TsUiSceneRoleActor currentSelectFormationRoleActor = Singleton<UiSceneManager>.Instance.GetCurrentSelectFormationRoleActor();
		if (currentSelectFormationRoleActor == null)
		{
			return null;
		}
		UiModelBase model = currentSelectFormationRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent == null)
		{
			return null;
		}
		return uiModelActorComponent.MainMeshComponent;
	}
}
