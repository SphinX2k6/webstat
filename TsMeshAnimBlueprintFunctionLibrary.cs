using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Audio;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E36 RID: 11830
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMeshAnimBlueprintFunctionLibrary.TsMeshAnimBlueprintFunctionLibrary_C")]
public class TsMeshAnimBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x060182A9 RID: 98985 RVA: 0x006C17CD File Offset: 0x006BF9CD
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static UAnimInstance MainAnimInstance(int entityId)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.MainAnimInstance;
	}

	// Token: 0x060182AA RID: 98986 RVA: 0x006C17E5 File Offset: 0x006BF9E5
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static UAnimInstance MainAnimInstanceForVehicle(int entityId)
	{
		VehicleAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<VehicleAnimationComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.MainAnimInstance;
	}

	// Token: 0x060182AB RID: 98987 RVA: 0x006C1800 File Offset: 0x006BFA00
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVector GetSightDirect(int entityId)
	{
		BaseAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAnimationComponent>(entityId);
		if (component == null)
		{
			return FVector.ZeroVector;
		}
		return component.GetSightDirect();
	}

	// Token: 0x060182AC RID: 98988 RVA: 0x006C1828 File Offset: 0x006BFA28
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetHeadBaseYawBuffer(int entityId)
	{
		BaseAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAnimationComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.GetHeadBaseYawBuffer();
	}

	// Token: 0x060182AD RID: 98989 RVA: 0x006C1844 File Offset: 0x006BFA44
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static UMeshComponent GetHulu(int entityId)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component == null)
		{
			return null;
		}
		return component.Hulu;
	}

	// Token: 0x060182AE RID: 98990 RVA: 0x006C185C File Offset: 0x006BFA5C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetBattleIdleTime(int entityId)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		return (float)((component != null) ? component.BattleIdleEndTime : 0);
	}

	// Token: 0x060182AF RID: 98991 RVA: 0x006C1876 File Offset: 0x006BFA76
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetDisableBlink(int entityId)
	{
		BaseAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAnimationComponent>(entityId);
		return component != null && component.DisableBlink;
	}

	// Token: 0x060182B0 RID: 98992 RVA: 0x006C188E File Offset: 0x006BFA8E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetIgnoreMontageBlinkCurve(int entityId)
	{
		BaseAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAnimationComponent>(entityId);
		return component != null && component.IgnoreMontageBlinkCurve;
	}

	// Token: 0x060182B1 RID: 98993 RVA: 0x006C18A8 File Offset: 0x006BFAA8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnterBattleIdle(int entityId)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.EnterBattleIdle(null);
	}

	// Token: 0x060182B2 RID: 98994 RVA: 0x006C18D4 File Offset: 0x006BFAD4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetTransformWithModelBuffer(int entityId, FTransformDouble transform, float timeLength)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component != null)
		{
			component.SetTransformWithModelBuffer(transform, timeLength, null, true);
			return;
		}
		VehicleAnimationComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<VehicleAnimationComponent>(entityId);
		if (component2 != null)
		{
			component2.SetTransformWithModelBuffer(transform, timeLength, null);
		}
	}

	// Token: 0x060182B3 RID: 98995 RVA: 0x006C1924 File Offset: 0x006BFB24
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSightDirectEnable(int entityId, bool v)
	{
		BaseAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAnimationComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.EnableSightDirect = v;
	}

	// Token: 0x060182B4 RID: 98996 RVA: 0x006C1948 File Offset: 0x006BFB48
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void HideWeaponsWhenHideBones(int entityId, bool hide, FName socketName)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.HideWeaponsWhenHideBones(hide, socketName);
	}

	// Token: 0x060182B5 RID: 98997 RVA: 0x006C1961 File Offset: 0x006BFB61
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ChangeWeaponHangState(int entityId, int weaponState, float lerpTime, ref TArray<FName> sockets, ref TArray<FTransform> transforms)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ChangeWeaponHangState(weaponState, sockets, transforms, lerpTime, "TsMeshAnimBlueprintFunctionLibrary");
	}

	// Token: 0x060182B6 RID: 98998 RVA: 0x006C1985 File Offset: 0x006BFB85
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static int GetCurrentWeaponHangState(int entityId)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component == null)
		{
			return 0;
		}
		return component.CurrentHangState;
	}

	// Token: 0x060182B7 RID: 98999 RVA: 0x006C199D File Offset: 0x006BFB9D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetIsCurrentWeaponHideEffectPlaying(int entityId)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		return component != null && component.IsCurrentWeaponHideEffectPlaying();
	}

	// Token: 0x060182B8 RID: 99000 RVA: 0x006C19B5 File Offset: 0x006BFBB5
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ChangeWeapon(int entityId, SWeaponSocketItem weaponSocket)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ChangeWeaponByWeaponSocketItem(weaponSocket);
	}

	// Token: 0x060182B9 RID: 99001 RVA: 0x006C19D0 File Offset: 0x006BFBD0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetRandomStandActionIndex(int entityId)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return (float)component.GetRandomStandActionIndex();
	}

	// Token: 0x060182BA RID: 99002 RVA: 0x006C19F9 File Offset: 0x006BFBF9
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void HideWeapon(int entityId, bool hide, int index, bool hideEffect = true, bool useHighPriority = false)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.HideWeapon(index, hide, hideEffect, false, useHighPriority ? EWeaponExtraVisibleType.HighCustom : EWeaponExtraVisibleType.LowCustom, "Unknown");
	}

	// Token: 0x060182BB RID: 99003 RVA: 0x006C1A21 File Offset: 0x006BFC21
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void HideHulu(int entityId, bool bHidden)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetHuluHidden(bHidden, true, false);
	}

	// Token: 0x060182BC RID: 99004 RVA: 0x006C1A3B File Offset: 0x006BFC3B
	[NullableContext(1)]
	protected static void ChangeMeshAnim(int entityId, USkeletalMesh meshClass, [Nullable(new byte[]
	{
		0,
		1
	})] TSubclassOf<UAnimInstance> animBlueprintClass)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ChangeMeshAnim(meshClass, animBlueprintClass);
	}

	// Token: 0x060182BD RID: 99005 RVA: 0x006C1A54 File Offset: 0x006BFC54
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetDegMovementSlope(int entityId)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.DegMovementSlope;
	}

	// Token: 0x060182BE RID: 99006 RVA: 0x006C1A70 File Offset: 0x006BFC70
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetRoleFootStepState(int entityId)
	{
		CreatureDataComponent component = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		if (component.GetEntityType() == EEntityType.Player)
		{
			int playerId = component.GetPlayerId();
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int num = playerId;
			bool isSelf = id.GetValueOrDefault() == num & id != null;
			int roleId = component.GetRoleId();
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, isSelf);
			if (roleDataById != null)
			{
				RoleInfo? roleInfo = new RoleInfo?(roleDataById.GetRoleConfig());
				if (roleInfo != null)
				{
					return roleInfo.Value.FootStepState;
				}
			}
		}
		return "";
	}

	// Token: 0x060182BF RID: 99007 RVA: 0x006C1B08 File Offset: 0x006BFD08
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetIkMeshOffset(int entityId, float offset)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.IkMeshOffset = offset;
	}

	// Token: 0x060182C0 RID: 99008 RVA: 0x006C1B2C File Offset: 0x006BFD2C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetWeaponBreachLevel(int entityId)
	{
		CharacterWeaponComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterWeaponComponent>(entityId);
		if (component != null)
		{
			return (float)component.GetWeaponBreachLevel();
		}
		return -1f;
	}

	// Token: 0x060182C1 RID: 99009 RVA: 0x006C1B58 File Offset: 0x006BFD58
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoMeshAnim(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		float num = (float)component.BattleIdleEndTime;
		if (animLogicParamsSetter.BattleIdleTime != num)
		{
			animLogicParamsSetter.BattleIdleTime = num;
			animLogicParams.BattleIdleTimeRef = num;
		}
		float degMovementSlope = component.DegMovementSlope;
		if (animLogicParamsSetter.DegMovementSlope != degMovementSlope)
		{
			animLogicParamsSetter.DegMovementSlope = degMovementSlope;
			animLogicParams.DegMovementSlopeRef = degMovementSlope;
		}
		global::Vector tsSightDirect = component.GetTsSightDirect();
		if (!animLogicParamsSetter.SightDirect.Equals(tsSightDirect, 9.999999747378752E-05))
		{
			animLogicParamsSetter.SightDirect.DeepCopy(tsSightDirect);
			animLogicParams.SightDirectRef = tsSightDirect.ToUeVectorOld();
		}
		bool disableBlink = component.DisableBlink;
		if (animLogicParamsSetter.DisableBlink != disableBlink)
		{
			animLogicParamsSetter.DisableBlink = disableBlink;
			animLogicParams.DisableBlinkRef = disableBlink;
		}
		bool ragRollQuitState = Singleton<EntitySystem>.Instance.GetComponent<CharacterPhysicsAssetComponent>(entityId).GetRagRollQuitState();
		if (animLogicParamsSetter.RagQuitState != ragRollQuitState)
		{
			animLogicParamsSetter.RagQuitState = ragRollQuitState;
			animLogicParams.RagQuitStateRef = ragRollQuitState;
		}
	}

	// Token: 0x060182C2 RID: 99010 RVA: 0x006C1C50 File Offset: 0x006BFE50
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoMeshAnimRoleNpc(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		float degMovementSlope = component.DegMovementSlope;
		if (animLogicParamsSetter.DegMovementSlope != degMovementSlope)
		{
			animLogicParamsSetter.DegMovementSlope = degMovementSlope;
			animLogicParams.DegMovementSlopeRef = degMovementSlope;
		}
		global::Vector tsSightDirect = component.GetTsSightDirect();
		if (!animLogicParamsSetter.SightDirect.Equals(tsSightDirect, 9.999999747378752E-05))
		{
			animLogicParamsSetter.SightDirect.DeepCopy(tsSightDirect);
			animLogicParams.SightDirectRef = tsSightDirect.ToUeVectorOld();
		}
		bool disableBlink = component.DisableBlink;
		if (animLogicParamsSetter.DisableBlink != disableBlink)
		{
			animLogicParamsSetter.DisableBlink = disableBlink;
			animLogicParams.DisableBlinkRef = disableBlink;
		}
		Vector2D tsLookAt = component.GetTsLookAt();
		if (!animLogicParamsSetter.LookAt.Equals(tsLookAt, 9.999999747378752E-05))
		{
			animLogicParamsSetter.LookAt.DeepCopy(tsLookAt);
			animLogicParams.LookAtRef = tsLookAt.ToUeVector2D(false);
		}
		bool ignoreMontageBlinkCurve = component.IgnoreMontageBlinkCurve;
		if (animLogicParamsSetter.IgnoreMontageBlinkCurve != ignoreMontageBlinkCurve)
		{
			animLogicParamsSetter.IgnoreMontageBlinkCurve = ignoreMontageBlinkCurve;
			animLogicParams.IgnoreMontageBlinkCurve = ignoreMontageBlinkCurve;
		}
		if (animLogicParamsSetter.EnableBlendSpaceLookAt != component.EnableBlendSpaceLookAt)
		{
			animLogicParamsSetter.EnableBlendSpaceLookAt = component.EnableBlendSpaceLookAt;
			animLogicParams.EnableBlendSpaceLookAtRef = component.EnableBlendSpaceLookAt;
		}
		if (animLogicParamsSetter.EnableLowerBlend != component.EnableLowerBlend)
		{
			animLogicParamsSetter.EnableLowerBlend = component.EnableLowerBlend;
			animLogicParams.StateLowerBlend = component.EnableLowerBlend;
		}
		if (animLogicParamsSetter.EnableLeftArmBlend != component.EnableLeftArmBlend)
		{
			animLogicParamsSetter.EnableLeftArmBlend = component.EnableLeftArmBlend;
			animLogicParams.StateLeftArmBlend = component.EnableLeftArmBlend;
		}
		if (animLogicParamsSetter.EnableRightArmBlend != component.EnableRightArmBlend)
		{
			animLogicParamsSetter.EnableRightArmBlend = component.EnableRightArmBlend;
			animLogicParams.StateRightArmBlend = component.EnableRightArmBlend;
		}
		if (animLogicParamsSetter.DisableHumanIk != component.DisableHumanIk)
		{
			animLogicParamsSetter.DisableHumanIk = component.DisableHumanIk;
			animLogicParams.DisableHumanIkRef = component.DisableHumanIk;
		}
	}

	// Token: 0x060182C3 RID: 99011 RVA: 0x006C1E14 File Offset: 0x006C0014
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoHoldingHandsRoleNpc(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		CharacterHoldingHandsComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterHoldingHandsComponent>(entityId);
		if (component2 == null)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		IkTarget handIkTarget = component2.GetHandIkTarget(EHandType.Left);
		if (handIkTarget != null && !animLogicParamsSetter.LeftHandIkTarget.Equals(handIkTarget))
		{
			animLogicParamsSetter.LeftHandIkTarget.DeepCopy(handIkTarget);
			FIKTarget handIkTargetUe = component2.GetHandIkTargetUe(EHandType.Left);
			if (handIkTargetUe != null)
			{
				animLogicParams.LeftHandIKTargetCS = handIkTargetUe;
			}
		}
		IkTarget handIkTarget2 = component2.GetHandIkTarget(EHandType.Right);
		if (handIkTarget2 != null && !animLogicParamsSetter.RightHandIkTarget.Equals(handIkTarget2))
		{
			animLogicParamsSetter.RightHandIkTarget.DeepCopy(handIkTarget2);
			FIKTarget handIkTargetUe2 = component2.GetHandIkTargetUe(EHandType.Right);
			if (handIkTargetUe2 != null)
			{
				animLogicParams.RightHandIKTargetCS = handIkTargetUe2;
			}
		}
		bool isHoldingHands = component2.GetIsHoldingHands();
		if (isHoldingHands != animLogicParamsSetter.IsHoldingHands)
		{
			animLogicParamsSetter.IsHoldingHands = isHoldingHands;
			animLogicParams.IsHoldingHands = isHoldingHands;
		}
		bool isBeHoldingHands = component2.GetIsBeHoldingHands();
		if (isBeHoldingHands != animLogicParamsSetter.IsBeHoldingHands)
		{
			animLogicParamsSetter.IsBeHoldingHands = isBeHoldingHands;
			animLogicParams.IsBeHoldingHands = isBeHoldingHands;
		}
		bool flag = component2.GetHandReachable(EHandType.Left) || component2.GetHandReachable(EHandType.Right);
		if (flag != animLogicParamsSetter.IsHoldingHandsReachable)
		{
			animLogicParamsSetter.IsHoldingHandsReachable = flag;
			animLogicParams.IsHoldingHandsReachable = flag;
		}
		bool isAcceptingInvitation = component2.GetIsAcceptingInvitation();
		if (isAcceptingInvitation != animLogicParamsSetter.IsAcceptingInvitation)
		{
			animLogicParamsSetter.IsAcceptingInvitation = isAcceptingInvitation;
			animLogicParams.IsAcceptingInvitation = isAcceptingInvitation;
		}
	}

	// Token: 0x060182C4 RID: 99012 RVA: 0x006C1F70 File Offset: 0x006C0170
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateFootstepAudioEvent(int entityId, int roleEntityId, SFootstepAudioEventParam parameters)
	{
		FHitResult 碰撞信息 = parameters.碰撞信息;
		if (!parameters.状态_地面_Sprint && !碰撞信息.bBlockingHit)
		{
			return;
		}
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		AActor owner = component.Owner;
		if (!(owner is TsBaseCharacter))
		{
			return;
		}
		TsBaseCharacter tsBaseCharacter = (TsBaseCharacter)owner;
		Singleton<EventSystem>.Instance.EmitWithTarget<bool>(component.Entity, EEventName.OnCharFootOnTheGround, false);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnCharFootOnTheGround, false);
		CharacterAkComponent component2 = component.Entity.GetComponent<CharacterAkComponent>();
		if (component2 == null || !component2.Valid)
		{
			return;
		}
		UAkComponent akComponentBySocketName = component2.GetAkComponentBySocketName(FNameUtil.GetDynamicFName("hitcase").Value);
		if (akComponentBySocketName == null || !akComponentBySocketName.IsValid())
		{
			return;
		}
		FVector fvector;
		if (!tsBaseCharacter.CharRenderingComponent.GetInWater(2f))
		{
			FVector_NetQuantize location = 碰撞信息.Location;
			fvector = location;
		}
		else
		{
			fvector = parameters.缓存角色位置;
		}
		FVector inVec = fvector;
		UWorld world = GlobalData.World;
		string text;
		if (tsBaseCharacter.CharRenderingComponent.GetInWater(2f))
		{
			UAkGameplayStatics.SetRTPCValue(null, (float)component2.WaterDepth, 0, null, FNameUtil.NONE);
			text = "WaterSurface";
		}
		else
		{
			if (world == null || !world.IsValid())
			{
				return;
			}
			FVectorDouble location2 = UKismetMathLibrary.Conv_VectorToVectorDouble(inVec);
			FoliageAudioInfo foliageAudioInfo = Singleton<AudioUtils>.Instance.QueryFoliageAudioPhysicalMaterial(location2, null);
			UPhysicalMaterial uphysicalMaterial = 碰撞信息.PhysMaterial.IsValid(false, false) ? 碰撞信息.PhysMaterial.Get() : null;
			if (foliageAudioInfo != null && foliageAudioInfo.IsHitFoliage && foliageAudioInfo.PhysicalMaterial != null)
			{
				uphysicalMaterial = foliageAudioInfo.PhysicalMaterial;
			}
			TEnumAsByte<EPhysicalSurface>? tenumAsByte = (uphysicalMaterial != null) ? new TEnumAsByte<EPhysicalSurface>?(uphysicalMaterial.SurfaceType) : null;
			FName a = (tenumAsByte != null) ? UKuroAudioMaterialSettings.GetFootstepTextureName(tenumAsByte.Value) : FNameUtil.NONE;
			text = ((a == FNameUtil.NONE) ? a.ToString() : "");
			text = ((text.Length > 0) ? text : CharacterFootEffectComponent.EFootstepTexture.DirtSurface.ToEnumString());
		}
		akComponentBySocketName.SetSwitch(null, "FootStep_Ground_Texture", text);
		component2.FootSwitch = text;
		akComponentBySocketName.SetSwitch(null, "FootStep_Shoes", TsMeshAnimBlueprintFunctionLibrary.GetRoleFootStepState(roleEntityId));
		FOnAkPostEventCallback fonAkPostEventCallback;
		if (parameters.状态_地面_Walk || parameters.状态_跑停_WalkStop)
		{
			UAkGameObject uakGameObject = akComponentBySocketName;
			UAkAudioEvent walkAkAudioEvent = parameters.WalkAkAudioEvent;
			int callbackMask = 0;
			fonAkPostEventCallback = null;
			uakGameObject.PostAkEvent(walkAkAudioEvent, callbackMask, fonAkPostEventCallback, "");
			return;
		}
		if (parameters.状态_地面_Run || parameters.状态_跑停_RunStop)
		{
			UAkGameObject uakGameObject2 = akComponentBySocketName;
			UAkAudioEvent runAkAudioEvent = parameters.RunAkAudioEvent;
			int callbackMask2 = 0;
			fonAkPostEventCallback = null;
			uakGameObject2.PostAkEvent(runAkAudioEvent, callbackMask2, fonAkPostEventCallback, "");
			return;
		}
		if (parameters.状态_地面_Sprint || parameters.状态_跑停_SprintStop)
		{
			UAkGameObject uakGameObject3 = akComponentBySocketName;
			UAkAudioEvent sprintAkAudioEvent = parameters.SprintAkAudioEvent;
			int callbackMask3 = 0;
			fonAkPostEventCallback = null;
			uakGameObject3.PostAkEvent(sprintAkAudioEvent, callbackMask3, fonAkPostEventCallback, "");
			return;
		}
		UAkGameObject uakGameObject4 = akComponentBySocketName;
		UAkAudioEvent fallbackAkAudioEvent = parameters.FallbackAkAudioEvent;
		int callbackMask4 = 0;
		fonAkPostEventCallback = null;
		uakGameObject4.PostAkEvent(fallbackAkAudioEvent, callbackMask4, fonAkPostEventCallback, "");
	}

	// Token: 0x060182C5 RID: 99013 RVA: 0x006C224E File Offset: 0x006C044E
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ChangeTickOverlap(int entityId, bool overlap)
	{
		Singleton<EntitySystem>.Instance.GetComponent<UeSkeletalTickManageComponent>(entityId).SetTakeOverTick(overlap);
	}

	// Token: 0x060182C6 RID: 99014 RVA: 0x006C2264 File Offset: 0x006C0464
	[UFunction(EFunctionFlags.FUNC_None)]
	protected unsafe static void AnimTurnLog(int entityId)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "AnimTurn 1058338";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CurrentFacing", component.ActorRotationProxy);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("InputFace", component.InputRotatorProxy);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x060182C7 RID: 99015 RVA: 0x006C22FC File Offset: 0x006C04FC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsNpcTurning(int entityId)
	{
		NpcMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<NpcMoveComponent>(entityId);
		return component != null && component.IsTurning;
	}

	// Token: 0x060182C8 RID: 99016 RVA: 0x006C2320 File Offset: 0x006C0520
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSightSpeedAndRatio(int entityId, float speed, float ratio)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetSightSpeedAndRatio(speed, ratio);
	}

	// Token: 0x060182C9 RID: 99017 RVA: 0x006C233C File Offset: 0x006C053C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAndGetRotateBonesMap(int entityId, float deltaSeconds, ref TMap<string, float> outMap, ref FVector outOffset)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || component.RotateBonesToTargetMgr == null)
		{
			return;
		}
		component.RotateBonesToTargetMgr.Update(deltaSeconds);
		component.RotateBonesToTargetMgr.GetActivateBones(outMap);
		component.RotateBonesToTargetMgr.GetTargetOffset(ref outOffset);
	}

	// Token: 0x060182CA RID: 99018 RVA: 0x006C2388 File Offset: 0x006C0588
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSightDirectLimitAngles(int entityId, float horizontalAngle = 180f, float verticalDownAngle = -90f, float verticalUpAngle = 90f)
	{
		BaseAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAnimationComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetSightLimit(new float[]
		{
			-horizontalAngle,
			horizontalAngle
		}, new float[]
		{
			verticalDownAngle,
			verticalUpAngle
		}, true);
	}

	// Token: 0x060182CB RID: 99019 RVA: 0x006C23CC File Offset: 0x006C05CC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetRotateBonesToTagertDefault(int entityId, FVector defaultTargetOffset, float lerpSpeed = 1000f, float targetUpdateThreshold = 100f)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || component.RotateBonesToTargetMgr == null)
		{
			return;
		}
		component.RotateBonesToTargetMgr.SetDefaultTarget(defaultTargetOffset, lerpSpeed, targetUpdateThreshold);
	}

	// Token: 0x060182CC RID: 99020 RVA: 0x006C2400 File Offset: 0x006C0600
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetRotateBonesToTagertWithTime(int entityId, ref TArray<string> boneNames, float timeLength)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || component.RotateBonesToTargetMgr == null)
		{
			return;
		}
		component.RotateBonesToTargetMgr.SetBoneToTarget(boneNames, timeLength);
	}

	// Token: 0x060182CD RID: 99021 RVA: 0x006C2434 File Offset: 0x006C0634
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsMeshAnimBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMeshAnimBlueprintFunctionLibrary.TsMeshAnimBlueprintFunctionLibrary_C");
		}
		return TsMeshAnimBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060182CE RID: 99022 RVA: 0x006C2458 File Offset: 0x006C0658
	public TsMeshAnimBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsMeshAnimBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060182CF RID: 99023 RVA: 0x006C2480 File Offset: 0x006C0680
	[NullableContext(1)]
	public TsMeshAnimBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMeshAnimBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060182D0 RID: 99024 RVA: 0x006C24B3 File Offset: 0x006C06B3
	protected TsMeshAnimBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060182D1 RID: 99025 RVA: 0x006C24BC File Offset: 0x006C06BC
	protected unsafe static void __CPPCALL_MainAnimInstance_Implementation(TsMeshAnimBlueprintFunctionLibrary.__MainAnimInstance_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UAnimInstance uanimInstance = TsMeshAnimBlueprintFunctionLibrary.MainAnimInstance(__Params->entityId);
		ptr = ((uanimInstance != null) ? uanimInstance.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060182D2 RID: 99026 RVA: 0x006C24DE File Offset: 0x006C06DE
	protected unsafe static void __CPPCALL_MainAnimInstanceForVehicle_Implementation(TsMeshAnimBlueprintFunctionLibrary.__MainAnimInstanceForVehicle_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UAnimInstance uanimInstance = TsMeshAnimBlueprintFunctionLibrary.MainAnimInstanceForVehicle(__Params->entityId);
		ptr = ((uanimInstance != null) ? uanimInstance.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060182D3 RID: 99027 RVA: 0x006C2500 File Offset: 0x006C0700
	protected unsafe static void __CPPCALL_GetSightDirect_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetSightDirect_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetSightDirect(__Params->entityId);
	}

	// Token: 0x060182D4 RID: 99028 RVA: 0x006C2513 File Offset: 0x006C0713
	protected unsafe static void __CPPCALL_GetHeadBaseYawBuffer_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetHeadBaseYawBuffer_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetHeadBaseYawBuffer(__Params->entityId);
	}

	// Token: 0x060182D5 RID: 99029 RVA: 0x006C2526 File Offset: 0x006C0726
	protected unsafe static void __CPPCALL_GetHulu_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetHulu_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UMeshComponent hulu = TsMeshAnimBlueprintFunctionLibrary.GetHulu(__Params->entityId);
		ptr = ((hulu != null) ? hulu.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060182D6 RID: 99030 RVA: 0x006C2548 File Offset: 0x006C0748
	protected unsafe static void __CPPCALL_GetBattleIdleTime_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetBattleIdleTime_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetBattleIdleTime(__Params->entityId);
	}

	// Token: 0x060182D7 RID: 99031 RVA: 0x006C255B File Offset: 0x006C075B
	protected unsafe static void __CPPCALL_GetDisableBlink_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetDisableBlink_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetDisableBlink(__Params->entityId);
	}

	// Token: 0x060182D8 RID: 99032 RVA: 0x006C256E File Offset: 0x006C076E
	protected unsafe static void __CPPCALL_GetIgnoreMontageBlinkCurve_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetIgnoreMontageBlinkCurve_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetIgnoreMontageBlinkCurve(__Params->entityId);
	}

	// Token: 0x060182D9 RID: 99033 RVA: 0x006C2581 File Offset: 0x006C0781
	protected unsafe static void __CPPCALL_EnterBattleIdle_Implementation(TsMeshAnimBlueprintFunctionLibrary.__EnterBattleIdle_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.EnterBattleIdle(__Params->entityId);
	}

	// Token: 0x060182DA RID: 99034 RVA: 0x006C258E File Offset: 0x006C078E
	protected unsafe static void __CPPCALL_SetTransformWithModelBuffer_Implementation(TsMeshAnimBlueprintFunctionLibrary.__SetTransformWithModelBuffer_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.SetTransformWithModelBuffer(__Params->entityId, __Params->transform, __Params->timeLength);
	}

	// Token: 0x060182DB RID: 99035 RVA: 0x006C25A7 File Offset: 0x006C07A7
	protected unsafe static void __CPPCALL_SetSightDirectEnable_Implementation(TsMeshAnimBlueprintFunctionLibrary.__SetSightDirectEnable_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.SetSightDirectEnable(__Params->entityId, __Params->v);
	}

	// Token: 0x060182DC RID: 99036 RVA: 0x006C25BA File Offset: 0x006C07BA
	protected unsafe static void __CPPCALL_HideWeaponsWhenHideBones_Implementation(TsMeshAnimBlueprintFunctionLibrary.__HideWeaponsWhenHideBones_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.HideWeaponsWhenHideBones(__Params->entityId, __Params->hide, __Params->socketName);
	}

	// Token: 0x060182DD RID: 99037 RVA: 0x006C25D4 File Offset: 0x006C07D4
	protected unsafe static void __CPPCALL_ChangeWeaponHangState_Implementation(TsMeshAnimBlueprintFunctionLibrary.__ChangeWeaponHangState_FunctionParams* __Params)
	{
		TArray<FName> tarray = new TArray<FName>(&__Params->sockets, true, true);
		TArray<FTransform> tarray2 = new TArray<FTransform>(&__Params->transforms, true, true);
		TsMeshAnimBlueprintFunctionLibrary.ChangeWeaponHangState(__Params->entityId, __Params->weaponState, __Params->lerpTime, ref tarray, ref tarray2);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->sockets, default(UScriptStructStackOnlyPtr));
		}
		if (tarray2 != null)
		{
			tarray2.CopyTo(&__Params->transforms, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060182DE RID: 99038 RVA: 0x006C264C File Offset: 0x006C084C
	protected unsafe static void __CPPCALL_GetCurrentWeaponHangState_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetCurrentWeaponHangState_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetCurrentWeaponHangState(__Params->entityId);
	}

	// Token: 0x060182DF RID: 99039 RVA: 0x006C265F File Offset: 0x006C085F
	protected unsafe static void __CPPCALL_GetIsCurrentWeaponHideEffectPlaying_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetIsCurrentWeaponHideEffectPlaying_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetIsCurrentWeaponHideEffectPlaying(__Params->entityId);
	}

	// Token: 0x060182E0 RID: 99040 RVA: 0x006C2674 File Offset: 0x006C0874
	protected unsafe static void __CPPCALL_ChangeWeapon_Implementation(TsMeshAnimBlueprintFunctionLibrary.__ChangeWeapon_FunctionParams* __Params)
	{
		SWeaponSocketItem weaponSocket = new SWeaponSocketItem(&__Params->weaponSocket, true, true);
		TsMeshAnimBlueprintFunctionLibrary.ChangeWeapon(__Params->entityId, weaponSocket);
	}

	// Token: 0x060182E1 RID: 99041 RVA: 0x006C269C File Offset: 0x006C089C
	protected unsafe static void __CPPCALL_GetRandomStandActionIndex_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetRandomStandActionIndex_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetRandomStandActionIndex(__Params->entityId);
	}

	// Token: 0x060182E2 RID: 99042 RVA: 0x006C26AF File Offset: 0x006C08AF
	protected unsafe static void __CPPCALL_HideWeapon_Implementation(TsMeshAnimBlueprintFunctionLibrary.__HideWeapon_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.HideWeapon(__Params->entityId, __Params->hide, __Params->index, __Params->hideEffect, __Params->useHighPriority);
	}

	// Token: 0x060182E3 RID: 99043 RVA: 0x006C26D4 File Offset: 0x006C08D4
	protected unsafe static void __CPPCALL_HideHulu_Implementation(TsMeshAnimBlueprintFunctionLibrary.__HideHulu_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.HideHulu(__Params->entityId, __Params->bHidden);
	}

	// Token: 0x060182E4 RID: 99044 RVA: 0x006C26E7 File Offset: 0x006C08E7
	protected unsafe static void __CPPCALL_GetDegMovementSlope_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetDegMovementSlope_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetDegMovementSlope(__Params->entityId);
	}

	// Token: 0x060182E5 RID: 99045 RVA: 0x006C26FA File Offset: 0x006C08FA
	protected unsafe static void __CPPCALL_GetRoleFootStepState_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetRoleFootStepState_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsMeshAnimBlueprintFunctionLibrary.GetRoleFootStepState(__Params->entityId));
	}

	// Token: 0x060182E6 RID: 99046 RVA: 0x006C2713 File Offset: 0x006C0913
	protected unsafe static void __CPPCALL_SetIkMeshOffset_Implementation(TsMeshAnimBlueprintFunctionLibrary.__SetIkMeshOffset_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.SetIkMeshOffset(__Params->entityId, __Params->offset);
	}

	// Token: 0x060182E7 RID: 99047 RVA: 0x006C2726 File Offset: 0x006C0926
	protected unsafe static void __CPPCALL_GetWeaponBreachLevel_Implementation(TsMeshAnimBlueprintFunctionLibrary.__GetWeaponBreachLevel_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.GetWeaponBreachLevel(__Params->entityId);
	}

	// Token: 0x060182E8 RID: 99048 RVA: 0x006C273C File Offset: 0x006C093C
	protected unsafe static void __CPPCALL_UpdateAnimInfoMeshAnim_Implementation(TsMeshAnimBlueprintFunctionLibrary.__UpdateAnimInfoMeshAnim_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsMeshAnimBlueprintFunctionLibrary.UpdateAnimInfoMeshAnim(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060182E9 RID: 99049 RVA: 0x006C2764 File Offset: 0x006C0964
	protected unsafe static void __CPPCALL_UpdateAnimInfoMeshAnimRoleNpc_Implementation(TsMeshAnimBlueprintFunctionLibrary.__UpdateAnimInfoMeshAnimRoleNpc_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsMeshAnimBlueprintFunctionLibrary.UpdateAnimInfoMeshAnimRoleNpc(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060182EA RID: 99050 RVA: 0x006C278C File Offset: 0x006C098C
	protected unsafe static void __CPPCALL_UpdateAnimInfoHoldingHandsRoleNpc_Implementation(TsMeshAnimBlueprintFunctionLibrary.__UpdateAnimInfoHoldingHandsRoleNpc_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsMeshAnimBlueprintFunctionLibrary.UpdateAnimInfoHoldingHandsRoleNpc(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060182EB RID: 99051 RVA: 0x006C27B4 File Offset: 0x006C09B4
	protected unsafe static void __CPPCALL_UpdateFootstepAudioEvent_Implementation(TsMeshAnimBlueprintFunctionLibrary.__UpdateFootstepAudioEvent_FunctionParams* __Params)
	{
		SFootstepAudioEventParam parameters = new SFootstepAudioEventParam(&__Params->parameters, true, true);
		TsMeshAnimBlueprintFunctionLibrary.UpdateFootstepAudioEvent(__Params->entityId, __Params->roleEntityId, parameters);
	}

	// Token: 0x060182EC RID: 99052 RVA: 0x006C27E2 File Offset: 0x006C09E2
	protected unsafe static void __CPPCALL_ChangeTickOverlap_Implementation(TsMeshAnimBlueprintFunctionLibrary.__ChangeTickOverlap_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.ChangeTickOverlap(__Params->entityId, __Params->overlap);
	}

	// Token: 0x060182ED RID: 99053 RVA: 0x006C27F5 File Offset: 0x006C09F5
	protected unsafe static void __CPPCALL_AnimTurnLog_Implementation(TsMeshAnimBlueprintFunctionLibrary.__AnimTurnLog_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.AnimTurnLog(__Params->entityId);
	}

	// Token: 0x060182EE RID: 99054 RVA: 0x006C2802 File Offset: 0x006C0A02
	protected unsafe static void __CPPCALL_IsNpcTurning_Implementation(TsMeshAnimBlueprintFunctionLibrary.__IsNpcTurning_FunctionParams* __Params)
	{
		__Params->__Result = TsMeshAnimBlueprintFunctionLibrary.IsNpcTurning(__Params->entityId);
	}

	// Token: 0x060182EF RID: 99055 RVA: 0x006C2815 File Offset: 0x006C0A15
	protected unsafe static void __CPPCALL_SetSightSpeedAndRatio_Implementation(TsMeshAnimBlueprintFunctionLibrary.__SetSightSpeedAndRatio_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.SetSightSpeedAndRatio(__Params->entityId, __Params->speed, __Params->ratio);
	}

	// Token: 0x060182F0 RID: 99056 RVA: 0x006C2830 File Offset: 0x006C0A30
	protected unsafe static void __CPPCALL_UpdateAndGetRotateBonesMap_Implementation(TsMeshAnimBlueprintFunctionLibrary.__UpdateAndGetRotateBonesMap_FunctionParams_Hotfix* __Params)
	{
		TMap<string, float> tmap = new TMap<string, float>(&__Params->outMap, true, true);
		TsMeshAnimBlueprintFunctionLibrary.UpdateAndGetRotateBonesMap(__Params->entityId, __Params->deltaSeconds, ref tmap, ref __Params->outOffset);
		if (tmap != null)
		{
			tmap.CopyTo(&__Params->outMap, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060182F1 RID: 99057 RVA: 0x006C287E File Offset: 0x006C0A7E
	protected unsafe static void __CPPCALL_SetSightDirectLimitAngles_Implementation(TsMeshAnimBlueprintFunctionLibrary.__SetSightDirectLimitAngles_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.SetSightDirectLimitAngles(__Params->entityId, __Params->horizontalAngle, __Params->verticalDownAngle, __Params->verticalUpAngle);
	}

	// Token: 0x060182F2 RID: 99058 RVA: 0x006C289D File Offset: 0x006C0A9D
	protected unsafe static void __CPPCALL_SetRotateBonesToTagertDefault_Implementation(TsMeshAnimBlueprintFunctionLibrary.__SetRotateBonesToTagertDefault_FunctionParams* __Params)
	{
		TsMeshAnimBlueprintFunctionLibrary.SetRotateBonesToTagertDefault(__Params->entityId, __Params->defaultTargetOffset, __Params->lerpSpeed, __Params->targetUpdateThreshold);
	}

	// Token: 0x060182F3 RID: 99059 RVA: 0x006C28BC File Offset: 0x006C0ABC
	protected unsafe static void __CPPCALL_SetRotateBonesToTagertWithTime_Implementation(TsMeshAnimBlueprintFunctionLibrary.__SetRotateBonesToTagertWithTime_FunctionParams* __Params)
	{
		TArray<string> tarray = new TArray<string>(&__Params->boneNames, true, true);
		TsMeshAnimBlueprintFunctionLibrary.SetRotateBonesToTagertWithTime(__Params->entityId, ref tarray, __Params->timeLength);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->boneNames, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x0400BA24 RID: 47652
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMeshAnimBlueprintFunctionLibrary.TsMeshAnimBlueprintFunctionLibrary_C";

	// Token: 0x0400BA25 RID: 47653
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA26 RID: 47654
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200923C RID: 37436
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __MainAnimInstance_FunctionParams
	{
		// Token: 0x04030CA1 RID: 199841
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CA2 RID: 199842
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CA3 RID: 199843
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x0200923D RID: 37437
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __MainAnimInstanceForVehicle_FunctionParams
	{
		// Token: 0x04030CA4 RID: 199844
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CA5 RID: 199845
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CA6 RID: 199846
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x0200923E RID: 37438
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetSightDirect_FunctionParams
	{
		// Token: 0x04030CA7 RID: 199847
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CA8 RID: 199848
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CA9 RID: 199849
		[FieldOffset(16)]
		public FVector __Result;
	}

	// Token: 0x0200923F RID: 37439
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHeadBaseYawBuffer_FunctionParams
	{
		// Token: 0x04030CAA RID: 199850
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CAB RID: 199851
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CAC RID: 199852
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009240 RID: 37440
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHulu_FunctionParams
	{
		// Token: 0x04030CAD RID: 199853
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CAE RID: 199854
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CAF RID: 199855
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009241 RID: 37441
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBattleIdleTime_FunctionParams
	{
		// Token: 0x04030CB0 RID: 199856
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CB1 RID: 199857
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CB2 RID: 199858
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009242 RID: 37442
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDisableBlink_FunctionParams
	{
		// Token: 0x04030CB3 RID: 199859
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CB4 RID: 199860
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CB5 RID: 199861
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009243 RID: 37443
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetIgnoreMontageBlinkCurve_FunctionParams
	{
		// Token: 0x04030CB6 RID: 199862
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CB7 RID: 199863
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CB8 RID: 199864
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009244 RID: 37444
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnterBattleIdle_FunctionParams
	{
		// Token: 0x04030CB9 RID: 199865
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CBA RID: 199866
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009245 RID: 37445
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __SetTransformWithModelBuffer_FunctionParams
	{
		// Token: 0x04030CBB RID: 199867
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CBC RID: 199868
		[FieldOffset(16)]
		public FTransformDouble transform;

		// Token: 0x04030CBD RID: 199869
		[FieldOffset(80)]
		public float timeLength;

		// Token: 0x04030CBE RID: 199870
		[FieldOffset(88)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009246 RID: 37446
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetSightDirectEnable_FunctionParams
	{
		// Token: 0x04030CBF RID: 199871
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CC0 RID: 199872
		[FieldOffset(4)]
		public bool v;

		// Token: 0x04030CC1 RID: 199873
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009247 RID: 37447
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __HideWeaponsWhenHideBones_FunctionParams
	{
		// Token: 0x04030CC2 RID: 199874
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CC3 RID: 199875
		[FieldOffset(4)]
		public bool hide;

		// Token: 0x04030CC4 RID: 199876
		[FieldOffset(8)]
		public FName socketName;

		// Token: 0x04030CC5 RID: 199877
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009248 RID: 37448
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __ChangeWeaponHangState_FunctionParams
	{
		// Token: 0x04030CC6 RID: 199878
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CC7 RID: 199879
		[FieldOffset(4)]
		public int weaponState;

		// Token: 0x04030CC8 RID: 199880
		[FieldOffset(8)]
		public float lerpTime;

		// Token: 0x04030CC9 RID: 199881
		[FieldOffset(16)]
		public byte sockets;

		// Token: 0x04030CCA RID: 199882
		[FieldOffset(32)]
		public byte transforms;

		// Token: 0x04030CCB RID: 199883
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009249 RID: 37449
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCurrentWeaponHangState_FunctionParams
	{
		// Token: 0x04030CCC RID: 199884
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CCD RID: 199885
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CCE RID: 199886
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x0200924A RID: 37450
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetIsCurrentWeaponHideEffectPlaying_FunctionParams
	{
		// Token: 0x04030CCF RID: 199887
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CD0 RID: 199888
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CD1 RID: 199889
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200924B RID: 37451
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 104)]
	protected ref struct __ChangeWeapon_FunctionParams
	{
		// Token: 0x04030CD2 RID: 199890
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CD3 RID: 199891
		[FieldOffset(8)]
		public byte weaponSocket;

		// Token: 0x04030CD4 RID: 199892
		[FieldOffset(96)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200924C RID: 37452
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetRandomStandActionIndex_FunctionParams
	{
		// Token: 0x04030CD5 RID: 199893
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CD6 RID: 199894
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CD7 RID: 199895
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200924D RID: 37453
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __HideWeapon_FunctionParams
	{
		// Token: 0x04030CD8 RID: 199896
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CD9 RID: 199897
		[FieldOffset(4)]
		public bool hide;

		// Token: 0x04030CDA RID: 199898
		[FieldOffset(8)]
		public int index;

		// Token: 0x04030CDB RID: 199899
		[FieldOffset(12)]
		public bool hideEffect;

		// Token: 0x04030CDC RID: 199900
		[FieldOffset(13)]
		public bool useHighPriority;

		// Token: 0x04030CDD RID: 199901
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200924E RID: 37454
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __HideHulu_FunctionParams
	{
		// Token: 0x04030CDE RID: 199902
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CDF RID: 199903
		[FieldOffset(4)]
		public bool bHidden;

		// Token: 0x04030CE0 RID: 199904
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200924F RID: 37455
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDegMovementSlope_FunctionParams
	{
		// Token: 0x04030CE1 RID: 199905
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CE2 RID: 199906
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CE3 RID: 199907
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009250 RID: 37456
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetRoleFootStepState_FunctionParams
	{
		// Token: 0x04030CE4 RID: 199908
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CE5 RID: 199909
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CE6 RID: 199910
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009251 RID: 37457
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetIkMeshOffset_FunctionParams
	{
		// Token: 0x04030CE7 RID: 199911
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CE8 RID: 199912
		[FieldOffset(4)]
		public float offset;

		// Token: 0x04030CE9 RID: 199913
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009252 RID: 37458
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetWeaponBreachLevel_FunctionParams
	{
		// Token: 0x04030CEA RID: 199914
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CEB RID: 199915
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030CEC RID: 199916
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009253 RID: 37459
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoMeshAnim_FunctionParams
	{
		// Token: 0x04030CED RID: 199917
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CEE RID: 199918
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030CEF RID: 199919
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009254 RID: 37460
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoMeshAnimRoleNpc_FunctionParams
	{
		// Token: 0x04030CF0 RID: 199920
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CF1 RID: 199921
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030CF2 RID: 199922
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009255 RID: 37461
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoHoldingHandsRoleNpc_FunctionParams
	{
		// Token: 0x04030CF3 RID: 199923
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CF4 RID: 199924
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030CF5 RID: 199925
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009256 RID: 37462
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 216)]
	protected ref struct __UpdateFootstepAudioEvent_FunctionParams
	{
		// Token: 0x04030CF6 RID: 199926
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CF7 RID: 199927
		[FieldOffset(4)]
		public int roleEntityId;

		// Token: 0x04030CF8 RID: 199928
		[FieldOffset(8)]
		public byte parameters;

		// Token: 0x04030CF9 RID: 199929
		[FieldOffset(208)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009257 RID: 37463
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ChangeTickOverlap_FunctionParams
	{
		// Token: 0x04030CFA RID: 199930
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CFB RID: 199931
		[FieldOffset(4)]
		public bool overlap;

		// Token: 0x04030CFC RID: 199932
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009258 RID: 37464
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __AnimTurnLog_FunctionParams
	{
		// Token: 0x04030CFD RID: 199933
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030CFE RID: 199934
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009259 RID: 37465
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsNpcTurning_FunctionParams
	{
		// Token: 0x04030CFF RID: 199935
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D00 RID: 199936
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D01 RID: 199937
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200925A RID: 37466
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSightSpeedAndRatio_FunctionParams
	{
		// Token: 0x04030D02 RID: 199938
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D03 RID: 199939
		[FieldOffset(4)]
		public float speed;

		// Token: 0x04030D04 RID: 199940
		[FieldOffset(8)]
		public float ratio;

		// Token: 0x04030D05 RID: 199941
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200925B RID: 37467
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 112)]
	protected ref struct __UpdateAndGetRotateBonesMap_FunctionParams_Hotfix
	{
		// Token: 0x04030D06 RID: 199942
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D07 RID: 199943
		[FieldOffset(4)]
		public float deltaSeconds;

		// Token: 0x04030D08 RID: 199944
		[FieldOffset(8)]
		public byte outMap;

		// Token: 0x04030D09 RID: 199945
		[FieldOffset(88)]
		public FVector outOffset;

		// Token: 0x04030D0A RID: 199946
		[FieldOffset(104)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200925C RID: 37468
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSightDirectLimitAngles_FunctionParams
	{
		// Token: 0x04030D0B RID: 199947
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D0C RID: 199948
		[FieldOffset(4)]
		public float horizontalAngle;

		// Token: 0x04030D0D RID: 199949
		[FieldOffset(8)]
		public float verticalDownAngle;

		// Token: 0x04030D0E RID: 199950
		[FieldOffset(12)]
		public float verticalUpAngle;

		// Token: 0x04030D0F RID: 199951
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200925D RID: 37469
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetRotateBonesToTagertDefault_FunctionParams
	{
		// Token: 0x04030D10 RID: 199952
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D11 RID: 199953
		[FieldOffset(4)]
		public FVector defaultTargetOffset;

		// Token: 0x04030D12 RID: 199954
		[FieldOffset(16)]
		public float lerpSpeed;

		// Token: 0x04030D13 RID: 199955
		[FieldOffset(20)]
		public float targetUpdateThreshold;

		// Token: 0x04030D14 RID: 199956
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200925E RID: 37470
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetRotateBonesToTagertWithTime_FunctionParams
	{
		// Token: 0x04030D15 RID: 199957
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D16 RID: 199958
		[FieldOffset(8)]
		public byte boneNames;

		// Token: 0x04030D17 RID: 199959
		[FieldOffset(24)]
		public float timeLength;

		// Token: 0x04030D18 RID: 199960
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}
}
