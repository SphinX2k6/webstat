using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Module.Infrastructure;
using UnrealEngine;

// Token: 0x02002C3E RID: 11326
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeUiSceneInfr : UiCameraTargetTypeBase
{
	// Token: 0x06016B05 RID: 92933 RVA: 0x0064CCA3 File Offset: 0x0064AEA3
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		return null;
	}

	// Token: 0x06016B06 RID: 92934 RVA: 0x0064CCA8 File Offset: 0x0064AEA8
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		if (ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigById(ModelBase<InfrastructureModel>.Instance.InteractingRoadId) == null)
		{
			return null;
		}
		InfrRoadBuild? infrRoadBuild;
		return infrRoadBuild.GetValueOrDefault().BodyCameraSettingsName;
	}

	// Token: 0x06016B07 RID: 92935 RVA: 0x0064CCE4 File Offset: 0x0064AEE4
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		return null;
	}
}
