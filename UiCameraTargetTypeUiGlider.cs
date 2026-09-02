using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using UnrealEngine;

// Token: 0x02002C3A RID: 11322
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiGlider : UiCameraTargetTypeBase
{
	// Token: 0x06016AF5 RID: 92917 RVA: 0x0064CAB1 File Offset: 0x0064ACB1
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		SkeletalObserverHandle gliderSkeletalHandle = Singleton<UiSceneManager>.Instance.GetGliderSkeletalHandle();
		object obj;
		if (gliderSkeletalHandle == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = gliderSkeletalHandle.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return null;
		}
		return obj2.Actor;
	}

	// Token: 0x06016AF6 RID: 92918 RVA: 0x0064CAE0 File Offset: 0x0064ACE0
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		return null;
	}

	// Token: 0x06016AF7 RID: 92919 RVA: 0x0064CAE3 File Offset: 0x0064ACE3
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		SkeletalObserverHandle gliderSkeletalHandle = Singleton<UiSceneManager>.Instance.GetGliderSkeletalHandle();
		object obj;
		if (gliderSkeletalHandle == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = gliderSkeletalHandle.Model;
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
