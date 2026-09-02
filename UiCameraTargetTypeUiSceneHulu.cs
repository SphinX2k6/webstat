using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using UnrealEngine;

// Token: 0x02002C3D RID: 11325
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiSceneHulu : UiCameraTargetTypeBase
{
	// Token: 0x06016B01 RID: 92929 RVA: 0x0064CC3A File Offset: 0x0064AE3A
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		SkeletalObserverHandle huluObserver = Singleton<UiSceneManager>.Instance.GetHuluObserver();
		object obj;
		if (huluObserver == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = huluObserver.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return null;
		}
		return obj2.Actor;
	}

	// Token: 0x06016B02 RID: 92930 RVA: 0x0064CC69 File Offset: 0x0064AE69
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		return null;
	}

	// Token: 0x06016B03 RID: 92931 RVA: 0x0064CC6C File Offset: 0x0064AE6C
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		SkeletalObserverHandle huluObserver = Singleton<UiSceneManager>.Instance.GetHuluObserver();
		object obj;
		if (huluObserver == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = huluObserver.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return null;
		}
		return obj2.MainMeshComponent;
	}
}
