using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Enum;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Module.Interaction;
using UnrealEngine;

// Token: 0x02002C37 RID: 11319
[NullableContext(1)]
[Nullable(0)]
public class UiCameraTargetTypeNpc : UiCameraTargetTypeBase
{
	// Token: 0x06016AE8 RID: 92904 RVA: 0x0064C7CB File Offset: 0x0064A9CB
	[return: Nullable(2)]
	public override AActor GetTargetActor(SUiCameraAnimationSettings config)
	{
		return ModelBase<InteractionModel>.Instance.CurrentInteractUeActor;
	}

	// Token: 0x06016AE9 RID: 92905 RVA: 0x0064C7D8 File Offset: 0x0064A9D8
	[NullableContext(2)]
	public override string GetTargetBodyKey()
	{
		int? currentInteractEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
		if (currentInteractEntityId == null)
		{
			return null;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(currentInteractEntityId.Value);
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return null;
		}
		string result;
		switch (component.GetModelConfig().体型类型)
		{
		case EBodyType.None:
			result = null;
			break;
		case EBodyType.MaleS:
			result = "MaleS";
			break;
		case EBodyType.MaleM:
			result = "MaleM";
			break;
		case EBodyType.MaleXL:
			result = "MaleXL";
			break;
		case EBodyType.FemaleS:
			result = "FemaleS";
			break;
		case EBodyType.FemaleMS:
			result = "FemaleMS";
			break;
		case EBodyType.FemaleM:
			result = "FemaleM";
			break;
		case EBodyType.FemaleXL:
			result = "FemaleXL";
			break;
		case EBodyType.ShopHand:
			result = "ShopHand";
			break;
		case EBodyType.ShopStore:
			result = "ShopStore";
			break;
		case EBodyType.ShopDoll:
			result = "ShopDoll";
			break;
		case EBodyType.ShopPhonograph:
			result = "ShopPhonograph";
			break;
		case EBodyType.ShopPicture:
			result = "ShopPicture";
			break;
		default:
			result = null;
			break;
		}
		return result;
	}

	// Token: 0x06016AEA RID: 92906 RVA: 0x0064C8EC File Offset: 0x0064AAEC
	[return: Nullable(2)]
	public override USkeletalMeshComponent GetTargetSkeletalMesh(SUiCameraAnimationSettings config)
	{
		AActor currentInteractUeActor = ModelBase<InteractionModel>.Instance.CurrentInteractUeActor;
		if (currentInteractUeActor == null || !currentInteractUeActor.IsValid())
		{
			return null;
		}
		return currentInteractUeActor.GetComponentByClass(USkeletalMeshComponent.StaticClass()) as USkeletalMeshComponent;
	}
}
