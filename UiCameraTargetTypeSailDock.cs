using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using UnrealEngine;

// Token: 0x02002C39 RID: 11321
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeSailDock : UiCameraTargetTypeBase
{
	// Token: 0x06016AF1 RID: 92913 RVA: 0x0064CA33 File Offset: 0x0064AC33
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		return null;
	}

	// Token: 0x06016AF2 RID: 92914 RVA: 0x0064CA38 File Offset: 0x0064AC38
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		int sailingPoint = ConfigBase<FishingConfig>.Instance.GetFishingPortConfig(ModelBase<FishingModel>.Instance.DockId).SailingPoint;
		if (sailingPoint == 0)
		{
			return null;
		}
		string result;
		switch (sailingPoint)
		{
		case 1:
			result = "FishingShipOne";
			break;
		case 2:
			result = "FishingShipTwo";
			break;
		case 3:
			result = "FishingShipThree";
			break;
		case 4:
			result = "FishingShipFour";
			break;
		default:
			result = null;
			break;
		}
		return result;
	}

	// Token: 0x06016AF3 RID: 92915 RVA: 0x0064CAA6 File Offset: 0x0064ACA6
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		return null;
	}
}
