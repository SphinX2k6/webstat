using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Kpose.Blueprint;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using UnrealEngine;

// Token: 0x02002C41 RID: 11329
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiVisionHandBook : UiCameraTargetTypeBase
{
	// Token: 0x06016B11 RID: 92945 RVA: 0x0064CE40 File Offset: 0x0064B040
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		if (!GlobalData.IsUiSceneOpen)
		{
			return null;
		}
		return Singleton<UiSceneManager>.Instance.GetHandBookCaseActor();
	}

	// Token: 0x06016B12 RID: 92946 RVA: 0x0064CE55 File Offset: 0x0064B055
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		return null;
	}

	// Token: 0x06016B13 RID: 92947 RVA: 0x0064CE58 File Offset: 0x0064B058
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		BP_KposeBase_C handBookVision = Singleton<UiSceneManager>.Instance.GetHandBookVision();
		if (handBookVision != null)
		{
			return handBookVision.GetComponentByClass(USkeletalMeshComponent.StaticClass()) as USkeletalMeshComponent;
		}
		return null;
	}
}
