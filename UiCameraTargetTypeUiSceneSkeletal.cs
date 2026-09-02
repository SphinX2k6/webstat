using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using UnrealEngine;

// Token: 0x02002C40 RID: 11328
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiSceneSkeletal : UiCameraTargetTypeBase
{
	// Token: 0x06016B0D RID: 92941 RVA: 0x0064CDE1 File Offset: 0x0064AFE1
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		SkeletalObserverHandle lastSkeletalObserver = SkeletalObserverManager.GetLastSkeletalObserver();
		object obj;
		if (lastSkeletalObserver == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = lastSkeletalObserver.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return null;
		}
		return obj2.Actor;
	}

	// Token: 0x06016B0E RID: 92942 RVA: 0x0064CE0B File Offset: 0x0064B00B
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		return null;
	}

	// Token: 0x06016B0F RID: 92943 RVA: 0x0064CE0E File Offset: 0x0064B00E
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		SkeletalObserverHandle lastSkeletalObserver = SkeletalObserverManager.GetLastSkeletalObserver();
		object obj;
		if (lastSkeletalObserver == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = lastSkeletalObserver.Model;
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
