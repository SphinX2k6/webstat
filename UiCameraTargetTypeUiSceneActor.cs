using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using UnrealEngine;

// Token: 0x02002C3B RID: 11323
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiSceneActor : UiCameraTargetTypeBase
{
	// Token: 0x06016AF9 RID: 92921 RVA: 0x0064CB1C File Offset: 0x0064AD1C
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		if (UKuroUiSceneSystem.GetKuroUiSceneSystem(GlobalData.World).GetAllUiSceneLoadingState() != EKuroUiSceneLoadingState.LoadedAndVisible)
		{
			return null;
		}
		return UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(config.TargetActorTag).Value, ECollectActorType.UI);
	}

	// Token: 0x06016AFA RID: 92922 RVA: 0x0064CB56 File Offset: 0x0064AD56
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		return null;
	}

	// Token: 0x06016AFB RID: 92923 RVA: 0x0064CB59 File Offset: 0x0064AD59
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		return null;
	}
}
