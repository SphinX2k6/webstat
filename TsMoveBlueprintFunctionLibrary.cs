using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using AkiClient.Game.Aki.AI.AIFunctionCommon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.ControlMonster;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002E37 RID: 11831
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMoveBlueprintFunctionLibrary.TsMoveBlueprintFunctionLibrary_C")]
public class TsMoveBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060182F4 RID: 99060 RVA: 0x006C2904 File Offset: 0x006C0B04
	static TsMoveBlueprintFunctionLibrary()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsMoveBlueprintFunctionLibrary.CreateStaticDefaultValue), new Action(TsMoveBlueprintFunctionLibrary.ResetStaticDefaultValue));
	}

	// Token: 0x060182F5 RID: 99061 RVA: 0x006C2978 File Offset: 0x006C0B78
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool SetActorRotationWithPriority(int entityId, FRotator value, bool sweep = false, string context = "unknown")
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		return component != null && component.SetActorRotationWithPriority(value, "BlueprintAPI." + context, ESetRotationPriority.Movement, true, sweep);
	}

	// Token: 0x060182F6 RID: 99062 RVA: 0x006C29AC File Offset: 0x006C0BAC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool SetActorLocationWithContext(int entityId, FVectorDouble location, bool sweep = false, string context = "unknown")
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		return component != null && component.SetActorLocation(location, "BlueprintAPI." + context, sweep);
	}

	// Token: 0x060182F7 RID: 99063 RVA: 0x006C29E0 File Offset: 0x006C0BE0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetActorLocationAndRotationWithContext(int entityId, FVectorDouble location, FRotator rotation, bool sweep = false, string context = "unknown")
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetActorLocationAndRotation(location, rotation, "BlueprintAPI." + context, sweep, null);
	}

	// Token: 0x060182F8 RID: 99064 RVA: 0x006C2A1C File Offset: 0x006C0C1C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool SetActorRotationWithContext(int entityId, FRotator rotation, bool sweep, string context)
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		return component != null && component.SetActorRotation(rotation, "BlueprintAPI." + context, sweep);
	}

	// Token: 0x060182F9 RID: 99065 RVA: 0x006C2A50 File Offset: 0x006C0C50
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddActorWorldOffsetWithContext(int entityId, FVectorDouble offset, bool sweep = true, string context = "unknown")
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.AddActorWorldOffset(offset, "BlueprintAPI." + context, sweep);
	}

	// Token: 0x060182FA RID: 99066 RVA: 0x006C2A80 File Offset: 0x006C0C80
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddActorWorldOffsetWithContextAndReset(int entityId, FVectorDouble offset, bool sweep = true, string context = "unknown")
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.AddActorWorldOffsetWithReset(offset, "BlueprintAPI." + context, sweep);
	}

	// Token: 0x060182FB RID: 99067 RVA: 0x006C2AB0 File Offset: 0x006C0CB0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddActorLocalOffsetWithContext(int entityId, FVectorDouble offset, bool sweep = true, string context = "unknown")
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.AddActorLocalOffset(offset, "BlueprintAPI." + context, sweep);
	}

	// Token: 0x060182FC RID: 99068 RVA: 0x006C2AE0 File Offset: 0x006C0CE0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddActorWorldRotationWithContext(int entityId, FRotator rotation, bool sweep = false, string context = "unknown")
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.AddActorWorldRotation(rotation, "BlueprintAPI." + context, sweep);
	}

	// Token: 0x060182FD RID: 99069 RVA: 0x006C2B10 File Offset: 0x006C0D10
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void AddActorLocalRotationWithContext(int entityId, FRotator rotation, bool sweep = false, string context = "unknown")
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.AddActorLocalRotation(rotation, "BlueprintAPI." + context, sweep);
	}

	// Token: 0x060182FE RID: 99070 RVA: 0x006C2B40 File Offset: 0x006C0D40
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ActorTeleportToWithContext(int entityId, FVectorDouble location, FRotator rotation, string context = "unknown")
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.TeleportTo(location, rotation, "BlueprintAPI." + context);
	}

	// Token: 0x060182FF RID: 99071 RVA: 0x006C2B74 File Offset: 0x006C0D74
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool SetActorLookAtWithContext(int entityId, FVectorDouble targetPoint, string context)
	{
		BaseActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseActorComponent>(entityId);
		if (component == null)
		{
			return false;
		}
		TsMoveBlueprintFunctionLibrary.tmpVector.FromUeVector(targetPoint);
		TsMoveBlueprintFunctionLibrary.tmpVector.SubtractionEqual(component.ActorLocationProxy);
		MathUtils instance = Singleton<MathUtils>.Instance;
		global::Vector forward = TsMoveBlueprintFunctionLibrary.tmpVector;
		BaseMoveComponent moveComp = component.MoveComp;
		instance.LookRotationUpFirst(forward, ((moveComp != null) ? moveComp.GravityUp : null) ?? global::Vector.UpVectorProxy, TsMoveBlueprintFunctionLibrary.tmpQuat);
		TsMoveBlueprintFunctionLibrary.tmpQuat.Rotator(TsMoveBlueprintFunctionLibrary.tmpRotator);
		return component.SetActorRotation(TsMoveBlueprintFunctionLibrary.tmpRotator.ToUeRotator(), "BlueprintAPI." + context + ".LookAt", false);
	}

	// Token: 0x06018300 RID: 99072 RVA: 0x006C2C10 File Offset: 0x006C0E10
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ActorKuroMoveAlongFloorWithContext(int entityId, FVector velocity, float deltaSeconds, string context = "unknown")
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.KuroMoveAlongFloor(velocity, deltaSeconds, "BlueprintAPI." + context);
	}

	// Token: 0x06018301 RID: 99073 RVA: 0x006C2C40 File Offset: 0x006C0E40
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetInputDirect(int entityId)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return global::Vector.ZeroVectorDouble;
		}
		return component.InputDirect;
	}

	// Token: 0x06018302 RID: 99074 RVA: 0x006C2C5C File Offset: 0x006C0E5C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetInputDirect(int entityId, FVectorDouble direct)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetInputDirect(global::Vector.Create(direct), false);
	}

	// Token: 0x06018303 RID: 99075 RVA: 0x006C2C84 File Offset: 0x006C0E84
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FRotator GetInputRotator(int entityId)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return global::Rotator.ZeroRotator;
		}
		return component.InputRotatorProxy.ToUeRotator();
	}

	// Token: 0x06018304 RID: 99076 RVA: 0x006C2CA5 File Offset: 0x006C0EA5
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetInputRotator(int entityId, FRotator rotator)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetInputRotator(rotator);
	}

	// Token: 0x06018305 RID: 99077 RVA: 0x006C2CC4 File Offset: 0x006C0EC4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetCharacterHidden(int entityId, bool isHidden, UObject callObject, string reason)
	{
		if (callObject == null || !callObject.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.LFJW, "调用SetCharacterHidden失败，因为callObject为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		string reason2 = "[蓝图:" + callObject.GetName() + "] " + reason;
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null && entity.Valid)
		{
			ControllerBase<CreatureController>.Instance.SetActorVisible(entity, !isHidden, !isHidden, !isHidden, reason2, true);
		}
	}

	// Token: 0x06018306 RID: 99078 RVA: 0x006C2D3F File Offset: 0x006C0F3F
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetHiddenMovementMode(int entityId, bool isHidden)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetHiddenMovementMode(isHidden);
	}

	// Token: 0x06018307 RID: 99079 RVA: 0x006C2D57 File Offset: 0x006C0F57
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool CanResponseInput(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.CanResponseInput();
	}

	// Token: 0x06018308 RID: 99080 RVA: 0x006C2D6F File Offset: 0x006C0F6F
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool CanJumpPress(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.CanJumpPress();
	}

	// Token: 0x06018309 RID: 99081 RVA: 0x006C2D87 File Offset: 0x006C0F87
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool CanWalkPress(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.CanWalkPress();
	}

	// Token: 0x0601830A RID: 99082 RVA: 0x006C2DA0 File Offset: 0x006C0FA0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetHeightAboveGround(int entityId, float detectedHeight = 500f)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component != null)
		{
			return component.GetHeightAboveGround(Math.Max(500f, detectedHeight));
		}
		VehicleMoveComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<VehicleMoveComponent>(entityId);
		if (component2 == null)
		{
			return detectedHeight;
		}
		return component2.GetHeightAboveGround(Math.Max(500f, detectedHeight));
	}

	// Token: 0x0601830B RID: 99083 RVA: 0x006C2DEF File Offset: 0x006C0FEF
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVector GetAcceleration(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return new FVector();
		}
		return component.Acceleration.ToUeVectorOld();
	}

	// Token: 0x0601830C RID: 99084 RVA: 0x006C2E10 File Offset: 0x006C1010
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetAimYawRate(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.AimYawRate;
	}

	// Token: 0x0601830D RID: 99085 RVA: 0x006C2E2C File Offset: 0x006C102C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static SMovementSetting_State GetMovementData(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return ((component != null) ? component.MovementData : null) ?? new SMovementSetting_State();
	}

	// Token: 0x0601830E RID: 99086 RVA: 0x006C2E4E File Offset: 0x006C104E
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SmoothCharacterRotation(int entityId, FRotator target, float speed, string context)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SmoothCharacterRotation(target, speed, Singleton<Time>.Instance.DeltaTimeSeconds, false, context, true);
	}

	// Token: 0x0601830F RID: 99087 RVA: 0x006C2E79 File Offset: 0x006C1079
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool HasMoveInput(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.HasMoveInput;
	}

	// Token: 0x06018310 RID: 99088 RVA: 0x006C2E94 File Offset: 0x006C1094
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool HasMoveInputOrTickIntervalAndModelBuffer(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component != null && component.HasMoveInput)
		{
			return true;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null || entity.GetTickInterval() <= 1)
		{
			return false;
		}
		CharacterAnimationComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		return component2 != null && component2.HasLocationModelBuffer();
	}

	// Token: 0x06018311 RID: 99089 RVA: 0x006C2EEC File Offset: 0x006C10EC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool HasRotatorInput(int entityId)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		return Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(component) > 10f;
	}

	// Token: 0x06018312 RID: 99090 RVA: 0x006C2F17 File Offset: 0x006C1117
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsMoving(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.IsMoving;
	}

	// Token: 0x06018313 RID: 99091 RVA: 0x006C2F2F File Offset: 0x006C112F
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsJump(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.IsJump;
	}

	// Token: 0x06018314 RID: 99092 RVA: 0x006C2F47 File Offset: 0x006C1147
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetSpeed(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.Speed;
	}

	// Token: 0x06018315 RID: 99093 RVA: 0x006C2F63 File Offset: 0x006C1163
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetGroundedTime(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.GroundedTimeUe;
	}

	// Token: 0x06018316 RID: 99094 RVA: 0x006C2F7F File Offset: 0x006C117F
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool IsFallingIntoWater(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.IsFallingIntoWater;
	}

	// Token: 0x06018317 RID: 99095 RVA: 0x006C2F98 File Offset: 0x006C1198
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetForceSpeed(int entityId, FVectorDouble speed)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component != null)
		{
			component.SetForceSpeed(speed);
			return;
		}
		VehicleMoveComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<VehicleMoveComponent>(entityId);
		if (component2 == null)
		{
			return;
		}
		component2.SetForceSpeed(speed);
	}

	// Token: 0x06018318 RID: 99096 RVA: 0x006C2FDC File Offset: 0x006C11DC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetAddMove(int entityId, UMeshComponent mesh, FVectorDouble speed, float timeLength, UCurveFloat curve)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetAddMoveWithMesh(mesh, speed, timeLength, curve);
	}

	// Token: 0x06018319 RID: 99097 RVA: 0x006C2FF8 File Offset: 0x006C11F8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void StopAddMove(int entityId, UMeshComponent mesh)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.StopAddMoveWithMesh(mesh);
	}

	// Token: 0x0601831A RID: 99098 RVA: 0x006C3014 File Offset: 0x006C1214
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FHitResult FixActorLocation(int entityId, FVectorDouble target, float offset)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		FHitResult fhitResult = new FHitResult();
		if (component != null && component.Valid)
		{
			global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			commonTempVector.FromUeVector(target);
			ValueTuple<bool, global::Vector> valueTuple = component.FixActorLocation(offset, true, commonTempVector, "TsMoveBlueprintFunctionLibrary.FixActorLocation", true, false);
			if (valueTuple.Item1)
			{
				fhitResult.bBlockingHit = true;
				fhitResult.Location = new FVector_NetQuantize((float)valueTuple.Item2.X, (float)valueTuple.Item2.Y, (float)valueTuple.Item2.Z);
				return fhitResult;
			}
		}
		fhitResult.bBlockingHit = false;
		return fhitResult;
	}

	// Token: 0x0601831B RID: 99099 RVA: 0x006C30AA File Offset: 0x006C12AA
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void StopAllAddMove(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.StopAllAddMove();
	}

	// Token: 0x0601831C RID: 99100 RVA: 0x006C30C1 File Offset: 0x006C12C1
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetAddMoveWorld(int entityId, UMeshComponent mesh, FVectorDouble speed, float timeLength, UCurveFloat curve)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetAddMoveWorldWithMesh(mesh, speed, timeLength, curve);
	}

	// Token: 0x0601831D RID: 99101 RVA: 0x006C30DD File Offset: 0x006C12DD
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetAddMoveWorldSpeed(int entityId, UMeshComponent mesh, FVectorDouble speed)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetAddMoveWorldSpeedWithMesh(mesh, speed);
	}

	// Token: 0x0601831E RID: 99102 RVA: 0x006C30F6 File Offset: 0x006C12F6
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetAddMoveOffset(int entityId, FVectorDouble offset)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetAddMoveOffset(new FVectorDouble?(offset));
	}

	// Token: 0x0601831F RID: 99103 RVA: 0x006C3113 File Offset: 0x006C1313
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetAddMoveRotation(int entityId, FRotator rotation)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetAddMoveRotation(rotation);
	}

	// Token: 0x06018320 RID: 99104 RVA: 0x006C312B File Offset: 0x006C132B
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetEnterWaterState(int entityId, bool isEnter)
	{
		CharacterSwimComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwimComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetEnterWaterState(isEnter);
	}

	// Token: 0x06018321 RID: 99105 RVA: 0x006C3144 File Offset: 0x006C1344
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AkiClient.Game.Aki.Character.BaseCharacter.SClimbState GetClimbState(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return default(AkiClient.Game.Aki.Character.BaseCharacter.SClimbState);
		}
		return component.GetClimbState();
	}

	// Token: 0x06018322 RID: 99106 RVA: 0x006C316F File Offset: 0x006C136F
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetClimbRadius(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.GetClimbRadius();
	}

	// Token: 0x06018323 RID: 99107 RVA: 0x006C318C File Offset: 0x006C138C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static AkiClient.Game.Aki.Character.BaseCharacter.SClimbInfo GetClimbInfo(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return default(AkiClient.Game.Aki.Character.BaseCharacter.SClimbInfo);
		}
		return component.GetClimbInfo();
	}

	// Token: 0x06018324 RID: 99108 RVA: 0x006C31B7 File Offset: 0x006C13B7
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void KickExitCheck(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.KickExitCheck();
	}

	// Token: 0x06018325 RID: 99109 RVA: 0x006C31CE File Offset: 0x006C13CE
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool CanClimbPress(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		return component != null && component.CanClimbPress();
	}

	// Token: 0x06018326 RID: 99110 RVA: 0x006C31E6 File Offset: 0x006C13E6
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void OnEnterClimb(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.OnEnterClimb();
	}

	// Token: 0x06018327 RID: 99111 RVA: 0x006C31FD File Offset: 0x006C13FD
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void OnExitClimb(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.OnExitClimb();
	}

	// Token: 0x06018328 RID: 99112 RVA: 0x006C3214 File Offset: 0x006C1414
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DealClimbUpStart(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.DealClimbUpStart();
	}

	// Token: 0x06018329 RID: 99113 RVA: 0x006C322B File Offset: 0x006C142B
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void FinishClimbDown(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.FinishClimbDown();
	}

	// Token: 0x0601832A RID: 99114 RVA: 0x006C3242 File Offset: 0x006C1442
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DealClimbUpFinish(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.DealClimbUpFinish();
	}

	// Token: 0x0601832B RID: 99115 RVA: 0x006C3259 File Offset: 0x006C1459
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetClimbState(int entityId, EClimbState climbState)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetClimbState(climbState);
	}

	// Token: 0x0601832C RID: 99116 RVA: 0x006C3271 File Offset: 0x006C1471
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetEnterClimbType(int entityId, EEnterClimb enterType)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetEnterClimbType(enterType);
	}

	// Token: 0x0601832D RID: 99117 RVA: 0x006C3289 File Offset: 0x006C1489
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetExitClimbType(int entityId, EExitClimb exitType)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetExitClimbType(exitType);
	}

	// Token: 0x0601832E RID: 99118 RVA: 0x006C32A1 File Offset: 0x006C14A1
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetSwimLocation(int entityId)
	{
		CharacterSwimComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwimComponent>(entityId);
		if (component == null)
		{
			return new FVectorDouble();
		}
		return component.GetSwimLocation();
	}

	// Token: 0x0601832F RID: 99119 RVA: 0x006C32BD File Offset: 0x006C14BD
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetWaterLocation(int entityId)
	{
		CharacterSwimComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwimComponent>(entityId);
		if (component == null)
		{
			return new FVectorDouble();
		}
		return component.GetWaterLocation();
	}

	// Token: 0x06018330 RID: 99120 RVA: 0x006C32D9 File Offset: 0x006C14D9
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetWaterVolume(int entityId)
	{
		CharacterSwimComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwimComponent>(entityId);
		return component != null && component.GetWaterVolume();
	}

	// Token: 0x06018331 RID: 99121 RVA: 0x006C32F1 File Offset: 0x006C14F1
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetClimbOnWallAngle(int entityId)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return 0f;
		}
		return component.GetOnWallAngle();
	}

	// Token: 0x06018332 RID: 99122 RVA: 0x006C330D File Offset: 0x006C150D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetUseDebugMovementSetting(int entityId, bool newSelect)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetUseDebugMovementSetting(newSelect);
	}

	// Token: 0x06018333 RID: 99123 RVA: 0x006C3325 File Offset: 0x006C1525
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDebugMovementSetting(int entityId, SMovementSetting newSetting)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetDebugMovementSetting(newSetting);
	}

	// Token: 0x06018334 RID: 99124 RVA: 0x006C333D File Offset: 0x006C153D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetLockedRotation(int entityId, bool lockedRotation)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetLockedRotation(lockedRotation);
	}

	// Token: 0x06018335 RID: 99125 RVA: 0x006C3355 File Offset: 0x006C1555
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetLockedRotation(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		return component != null && component.LockedRotation;
	}

	// Token: 0x06018336 RID: 99126 RVA: 0x006C336D File Offset: 0x006C156D
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetFallingHorizontalMaxSpeed(int entityId, float speed)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.SetFallingHorizontalMaxSpeed(speed);
	}

	// Token: 0x06018337 RID: 99127 RVA: 0x006C3385 File Offset: 0x006C1585
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ClearFallingHorizontalMaxSpeed(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ClearFallingHorizontalMaxSpeed();
	}

	// Token: 0x06018338 RID: 99128 RVA: 0x006C339C File Offset: 0x006C159C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool DetectClimbWithDirect(int entityId, bool bSprintEnter, FVectorDouble direct)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		return component != null && component.DetectClimbWithDirect(bSprintEnter, direct, false);
	}

	// Token: 0x06018339 RID: 99129 RVA: 0x006C33B8 File Offset: 0x006C15B8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void TurnToTarget(int entityId, AActor target, float speed)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return;
		}
		if (target is TsBaseCharacter)
		{
			CharacterAnimationComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
			if (component2 != null)
			{
				component2.MontageManager.StopMontage(new IStopMontageParam
				{
					Method = new EStopMethod?(EStopMethod.BlendOut),
					BlendOutTime = new float?(0f)
				});
			}
			global::Vector actorLocationProxy = component.ActorLocationProxy;
			global::Vector actorLocationProxy2 = ((TsBaseCharacter)target).CharacterActorComponent.ActorLocationProxy;
			global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			actorLocationProxy2.Subtraction(actorLocationProxy, commonTempVector);
			global::Rotator commonTempRotator = Singleton<MathUtils>.Instance.CommonTempRotator;
			BaseMoveComponent component3 = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
			commonTempVector.ToOrientationRotator(commonTempRotator);
			if (component3 == null)
			{
				return;
			}
			component3.SmoothCharacterRotation(commonTempRotator, speed, Singleton<Time>.Instance.DeltaTimeSeconds, false, "Movement.SmoothCharacterRotation", true);
		}
	}

	// Token: 0x0601833A RID: 99130 RVA: 0x006C3484 File Offset: 0x006C1684
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static EMovementDirection GetMonsterMoveDirection(int entityId)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return EMovementDirection.停;
		}
		if (component.InputDirectProxy.IsNearlyZero(9.999999747378752E-05))
		{
			return EMovementDirection.停;
		}
		component.ActorQuatProxy.Inverse(TsMoveBlueprintFunctionLibrary.tmpQuat);
		TsMoveBlueprintFunctionLibrary.tmpQuat.RotateVector(component.InputDirectProxy, TsMoveBlueprintFunctionLibrary.tmpVector);
		if (Math.Abs(TsMoveBlueprintFunctionLibrary.tmpVector.X) > Math.Abs(TsMoveBlueprintFunctionLibrary.tmpVector.Y))
		{
			if (TsMoveBlueprintFunctionLibrary.tmpVector.X <= 0.0)
			{
				return EMovementDirection.后;
			}
			return EMovementDirection.前;
		}
		else
		{
			if (TsMoveBlueprintFunctionLibrary.tmpVector.Y <= 0.0)
			{
				return EMovementDirection.左;
			}
			return EMovementDirection.右;
		}
	}

	// Token: 0x0601833B RID: 99131 RVA: 0x006C3530 File Offset: 0x006C1730
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static string GetRoleBody(int entityId)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null)
		{
			return "";
		}
		CreatureDataComponent creatureData = component.CreatureData;
		if (creatureData != null && creatureData.GetEntityType() == EEntityType.Player)
		{
			return component.CreatureData.GetRoleConfig().Value.RoleBody;
		}
		return "";
	}

	// Token: 0x0601833C RID: 99132 RVA: 0x006C358C File Offset: 0x006C178C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetRacingRightSpeed(int entityId)
	{
		CharacterSplineMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSplineMoveComponent>(entityId);
		return (component != null) ? component.LastRightSpeed : 0f;
	}

	// Token: 0x0601833D RID: 99133 RVA: 0x006C35B8 File Offset: 0x006C17B8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetPendulumData(int entityId, float addVelocityX, float addVelocityY, float addVelocityZ, float forwardLossPercentage, float lossPercentage, float gravity, float friction, float deceleration, float accelerator, float maxSpeed, float maxFallingSpeed)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.SetPendulumData((double)addVelocityX, (double)addVelocityY, (double)addVelocityZ, (double)forwardLossPercentage, (double)lossPercentage, (double)gravity, (double)friction, (double)deceleration, (double)accelerator, (double)maxSpeed, (double)maxFallingSpeed);
	}

	// Token: 0x0601833E RID: 99134 RVA: 0x006C3608 File Offset: 0x006C1808
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void Reset(int entityId)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.Reset();
	}

	// Token: 0x0601833F RID: 99135 RVA: 0x006C363C File Offset: 0x006C183C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetGrabPoint(int entityId, FVectorDouble point)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.GrabPoint = point;
	}

	// Token: 0x06018340 RID: 99136 RVA: 0x006C3670 File Offset: 0x006C1870
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble GetGrabPoint(int entityId)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return new FVectorDouble();
		}
		return component.GrabPoint;
	}

	// Token: 0x06018341 RID: 99137 RVA: 0x006C36A8 File Offset: 0x006C18A8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetHooked(int entityId, bool isHooked)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.Hooked = isHooked;
	}

	// Token: 0x06018342 RID: 99138 RVA: 0x006C36DC File Offset: 0x006C18DC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool GetHooked(int entityId)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		return component != null && component.Valid && component.Hooked;
	}

	// Token: 0x06018343 RID: 99139 RVA: 0x006C3710 File Offset: 0x006C1910
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetSocketName(int entityId, string socketName)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.SocketName = socketName;
	}

	// Token: 0x06018344 RID: 99140 RVA: 0x006C3744 File Offset: 0x006C1944
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetRopeForce(int entityId, float ropeForce)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.RopeForce = (double)ropeForce;
	}

	// Token: 0x06018345 RID: 99141 RVA: 0x006C3778 File Offset: 0x006C1978
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetRopeForce(int entityId)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return 0f;
		}
		return (float)component.RopeForce;
	}

	// Token: 0x06018346 RID: 99142 RVA: 0x006C37B0 File Offset: 0x006C19B0
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetDistanceRopeToActor(int entityId, float ropeForce)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.DistanceRopeToActor = (double)ropeForce;
	}

	// Token: 0x06018347 RID: 99143 RVA: 0x006C37E4 File Offset: 0x006C19E4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetDistanceRopeToActor(int entityId)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return 0f;
		}
		return (float)component.DistanceRopeToActor;
	}

	// Token: 0x06018348 RID: 99144 RVA: 0x006C381C File Offset: 0x006C1A1C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetAirControl(int entityId, float airControl)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.AirControl = airControl;
	}

	// Token: 0x06018349 RID: 99145 RVA: 0x006C3850 File Offset: 0x006C1A50
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static float GetAirControl(int entityId)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return 0f;
		}
		return component.AirControl;
	}

	// Token: 0x0601834A RID: 99146 RVA: 0x006C3888 File Offset: 0x006C1A88
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetUpLength(int entityId, float length)
	{
		CharacterPendulumComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterPendulumComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.UpLength = (double)length;
	}

	// Token: 0x0601834B RID: 99147 RVA: 0x006C38BC File Offset: 0x006C1ABC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void SetCanMoveFromInput(int entityId, bool canMove)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		component.CanMoveFromInput = canMove;
	}

	// Token: 0x0601834C RID: 99148 RVA: 0x006C38F0 File Offset: 0x006C1AF0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoMove(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		CharacterActorComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component2 != null && component2.Valid)
		{
			global::Vector inputDirectProxy = component2.InputDirectProxy;
			if (!animLogicParamsSetter.InputDirect.Equals(inputDirectProxy, 9.999999747378752E-05))
			{
				animLogicParamsSetter.InputDirect.DeepCopy(inputDirectProxy);
				animLogicParams.InputDirectRef = inputDirectProxy.ToUeVectorOld();
			}
			global::Rotator inputRotatorProxy = component2.InputRotatorProxy;
			if (!animLogicParamsSetter.InputRotator.Equals(inputRotatorProxy, 0.0001f))
			{
				animLogicParamsSetter.InputRotator.DeepCopy(inputRotatorProxy);
				animLogicParams.InputRotatorRef = inputRotatorProxy.ToUeRotator();
			}
		}
		BaseMoveComponent component3 = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component3 != null && component3.Valid)
		{
			global::Vector acceleration = component3.Acceleration;
			if (!animLogicParamsSetter.Acceleration.Equals(acceleration, 9.999999747378752E-05))
			{
				animLogicParamsSetter.Acceleration.DeepCopy(acceleration);
				animLogicParams.AccelerationRef = acceleration.ToUeVectorOld();
			}
			bool isMoving = component3.IsMoving;
			if (animLogicParamsSetter.IsMoving != isMoving)
			{
				animLogicParamsSetter.IsMoving = isMoving;
				animLogicParams.IsMovingRef = isMoving;
			}
			bool hasMoveInput = component3.HasMoveInput;
			if (animLogicParamsSetter.HasMoveInput != hasMoveInput)
			{
				animLogicParamsSetter.HasMoveInput = hasMoveInput;
				animLogicParams.HasMoveInputRef = hasMoveInput;
			}
			float speed = component3.Speed;
			if (animLogicParamsSetter.Speed != speed)
			{
				animLogicParamsSetter.Speed = speed;
				animLogicParams.SpeedRef = speed;
			}
			bool isJump = component3.IsJump;
			if (animLogicParamsSetter.IsJump != isJump)
			{
				animLogicParamsSetter.IsJump = isJump;
				animLogicParams.IsJumpRef = isJump;
			}
			float groundedTimeUe = component3.GroundedTimeUe;
			if (animLogicParamsSetter.GroundedTime != groundedTimeUe)
			{
				animLogicParamsSetter.GroundedTime = groundedTimeUe;
				animLogicParams.GroundedTimeRef = groundedTimeUe;
			}
			bool isFallingIntoWater = component3.IsFallingIntoWater;
			if (animLogicParamsSetter.IsFallingIntoWater != isFallingIntoWater)
			{
				animLogicParamsSetter.IsFallingIntoWater = isFallingIntoWater;
				animLogicParams.IsFallingIntoWaterRef = isFallingIntoWater;
			}
			float jumpUpRate = component3.JumpUpRate;
			if (animLogicParamsSetter.JumpUpRate != jumpUpRate)
			{
				animLogicParamsSetter.JumpUpRate = jumpUpRate;
				animLogicParams.JumpUpRateRef = jumpUpRate;
			}
		}
		CharacterClimbComponent component4 = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component4 != null && component4.Valid)
		{
			CSharpScript.Game.NewWorld.Character.Common.Component.Move.SClimbInfo tsClimbInfo = component4.GetTsClimbInfo();
			if (!animLogicParamsSetter.ClimbInfo.Equals(tsClimbInfo))
			{
				animLogicParamsSetter.ClimbInfo.DeepCopy(tsClimbInfo);
				animLogicParams.ClimbInfoRef = component4.GetClimbInfo();
			}
			CSharpScript.Game.NewWorld.Character.Common.Component.Move.SClimbState tsClimbState = component4.GetTsClimbState();
			if (!animLogicParamsSetter.ClimbState.Equals(tsClimbState))
			{
				animLogicParamsSetter.ClimbState.DeepCopy(tsClimbState);
				animLogicParams.ClimbStateRef = component4.GetClimbState();
			}
			float climbRadius = component4.GetClimbRadius();
			if (animLogicParamsSetter.ClimbRadius != climbRadius)
			{
				animLogicParamsSetter.ClimbRadius = climbRadius;
				animLogicParams.ClimbRadiusRef = climbRadius;
			}
			float onWallAngle = component4.GetOnWallAngle();
			if (animLogicParamsSetter.ClimbOnWallAngle != onWallAngle)
			{
				animLogicParamsSetter.ClimbOnWallAngle = onWallAngle;
				animLogicParams.ClimbOnWallAngleRef = onWallAngle;
			}
		}
		CharacterSwimComponent component5 = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwimComponent>(entityId);
		if (component5 != null && component5.Valid)
		{
			float sprintSwimOffset = component5.SprintSwimOffset;
			if (animLogicParamsSetter.SprintSwimOffset != sprintSwimOffset)
			{
				animLogicParamsSetter.SprintSwimOffset = sprintSwimOffset;
				animLogicParams.SprintSwimOffsetRef = sprintSwimOffset;
			}
			float sprintSwimOffsetLerpSpeed = component5.SprintSwimOffsetLerpSpeed;
			if (animLogicParamsSetter.SprintSwimOffsetLerpSpeed != sprintSwimOffsetLerpSpeed)
			{
				animLogicParamsSetter.SprintSwimOffsetLerpSpeed = sprintSwimOffsetLerpSpeed;
				animLogicParams.SprintSwimOffsetLerpSpeedRef = sprintSwimOffsetLerpSpeed;
			}
		}
		CharacterSlideComponent component6 = Singleton<EntitySystem>.Instance.GetComponent<CharacterSlideComponent>(entityId);
		if (component6 != null && component6.Valid)
		{
			global::Vector slideForward = component6.SlideForward;
			if (!animLogicParamsSetter.SlideForward.Equals(slideForward, 9.999999747378752E-05))
			{
				animLogicParamsSetter.SlideForward.DeepCopy(slideForward);
				animLogicParams.SlideForwardRef = slideForward.ToUeVectorOld();
			}
			bool slideSwitchThisFrame = component6.SlideSwitchThisFrame;
			if (animLogicParamsSetter.SlideSwitchThisFrame != slideSwitchThisFrame)
			{
				animLogicParamsSetter.SlideSwitchThisFrame = slideSwitchThisFrame;
				animLogicParams.SlideSwitchThisFrameRef = slideSwitchThisFrame;
			}
			bool standMode = component6.StandMode;
			if (animLogicParamsSetter.SlideStandMode != standMode)
			{
				animLogicParamsSetter.SlideStandMode = standMode;
				animLogicParams.SlideStandModeRef = standMode;
			}
		}
	}

	// Token: 0x0601834D RID: 99149 RVA: 0x006C3CC8 File Offset: 0x006C1EC8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoMoveMonster(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		CharacterActorComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component2 != null && component2.Valid)
		{
			global::Vector inputDirectProxy = component2.InputDirectProxy;
			if (!animLogicParamsSetter.InputDirect.Equals(inputDirectProxy, 9.999999747378752E-05))
			{
				animLogicParamsSetter.InputDirect.DeepCopy(inputDirectProxy);
				animLogicParams.InputDirectRef = inputDirectProxy.ToUeVectorOld();
			}
		}
		BaseMoveComponent component3 = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component3 != null && component3.Valid)
		{
			bool isMoving = component3.IsMoving;
			if (animLogicParamsSetter.IsMoving != isMoving)
			{
				animLogicParamsSetter.IsMoving = isMoving;
				animLogicParams.IsMovingRef = isMoving;
			}
			bool hasMoveInput = component3.HasMoveInput;
			if (animLogicParamsSetter.HasMoveInput != hasMoveInput)
			{
				animLogicParamsSetter.HasMoveInput = hasMoveInput;
				animLogicParams.HasMoveInputRef = hasMoveInput;
			}
		}
	}

	// Token: 0x0601834E RID: 99150 RVA: 0x006C3DB0 File Offset: 0x006C1FB0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void UpdateAnimInfoMoveRoleNpc(int entityId, BP_ABPLogicParams_C animLogicParams)
	{
		CharacterAnimationComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAnimationComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return;
		}
		AnimLogicParamsSetter animLogicParamsSetter = component.AnimLogicParamsSetter;
		CharacterActorComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component2 != null && component2.Valid)
		{
			global::Vector inputDirectProxy = component2.InputDirectProxy;
			if (!animLogicParamsSetter.InputDirect.Equals(inputDirectProxy, 9.999999747378752E-05))
			{
				animLogicParamsSetter.InputDirect.DeepCopy(inputDirectProxy);
				animLogicParams.InputDirectRef = inputDirectProxy.ToUeVectorOld();
			}
		}
		BaseMoveComponent component3 = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component3 != null && component3.Valid)
		{
			global::Vector acceleration = component3.Acceleration;
			if (!animLogicParamsSetter.Acceleration.Equals(acceleration, 9.999999747378752E-05))
			{
				animLogicParamsSetter.Acceleration.DeepCopy(acceleration);
				animLogicParams.AccelerationRef = acceleration.ToUeVectorOld();
			}
			bool isMoving = component3.IsMoving;
			if (animLogicParamsSetter.IsMoving != isMoving)
			{
				animLogicParamsSetter.IsMoving = isMoving;
				animLogicParams.IsMovingRef = isMoving;
			}
			bool hasMoveInput = component3.HasMoveInput;
			if (animLogicParamsSetter.HasMoveInput != hasMoveInput)
			{
				animLogicParamsSetter.HasMoveInput = hasMoveInput;
				animLogicParams.HasMoveInputRef = hasMoveInput;
			}
			float speed = component3.Speed;
			if (animLogicParamsSetter.Speed != speed)
			{
				animLogicParamsSetter.Speed = speed;
				animLogicParams.SpeedRef = speed;
			}
			bool isRegionMoveMode = component3.IsRegionMoveMode;
			if (animLogicParamsSetter.IsRegionMoveMode != isRegionMoveMode)
			{
				animLogicParamsSetter.IsRegionMoveMode = isRegionMoveMode;
				animLogicParams.IsRegionMoveModeRef = isRegionMoveMode;
			}
		}
		CharacterDriveVehicleComponent component4 = Singleton<EntitySystem>.Instance.GetComponent<CharacterDriveVehicleComponent>(entityId);
		if (component4 != null && component4.Valid)
		{
			bool isDriver = component4.IsDriver;
			if (animLogicParamsSetter.IsDriver != isDriver)
			{
				animLogicParamsSetter.IsDriver = isDriver;
				animLogicParams.IsDriver = isDriver;
			}
			bool isOnVehicle = component4.IsOnVehicle;
			if (animLogicParamsSetter.IsOnVehicle != isOnVehicle)
			{
				animLogicParamsSetter.IsOnVehicle = isOnVehicle;
				animLogicParams.IsOnVehicle = isOnVehicle;
			}
			bool isOnVehicleWithOther = component4.IsOnVehicleWithOther;
			if (animLogicParamsSetter.IsOnVehicleWithOther != isOnVehicleWithOther)
			{
				animLogicParamsSetter.IsOnVehicleWithOther = isOnVehicleWithOther;
				animLogicParams.IsOnVehicleWithOther = isOnVehicleWithOther;
			}
			int vehicleTypeInt = (int)component4.VehicleTypeInt;
			if (animLogicParamsSetter.VehicleType != vehicleTypeInt)
			{
				animLogicParamsSetter.VehicleType = vehicleTypeInt;
				animLogicParams.VehicleType = vehicleTypeInt;
			}
		}
	}

	// Token: 0x0601834F RID: 99151 RVA: 0x006C3FC8 File Offset: 0x006C21C8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void TurnOnAutomaticFlightMode(int entityId, ICM_AutomaticFlight_DataBase_C dataAsset)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.TurnOnAutomaticFlightMode(dataAsset);
		}
	}

	// Token: 0x06018350 RID: 99152 RVA: 0x006C3FF4 File Offset: 0x006C21F4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void TurnOffAutomaticFlightMode(int entityId)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.TurnOffAutomaticFlightMode();
		}
	}

	// Token: 0x06018351 RID: 99153 RVA: 0x006C4020 File Offset: 0x006C2220
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void TurnOnCameraDrivenAutoFlightMode(int entityId, BP_CameraDrivenAutoFlightData_C dataAsset)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.TurnOnCameraDrivenAutoFlightMode(dataAsset);
		}
	}

	// Token: 0x06018352 RID: 99154 RVA: 0x006C404C File Offset: 0x006C224C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void TurnOffCameraDrivenAutoFlightMode(int entityId)
	{
		CharacterInputComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterInputComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.TurnOffCameraDrivenAutoFlightMode();
		}
	}

	// Token: 0x17002072 RID: 8306
	// (get) Token: 0x06018353 RID: 99155 RVA: 0x006C4078 File Offset: 0x006C2278
	[Nullable(1)]
	private static UTraceLineElement WaterTrace
	{
		[NullableContext(1)]
		get
		{
			if (TsMoveBlueprintFunctionLibrary.WaterTraceInternal == null)
			{
				UTraceLineElement utraceLineElement = new UTraceLineElement();
				utraceLineElement.bIsSingle = true;
				utraceLineElement.bIgnoreSelf = true;
				utraceLineElement.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
				Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceLineElement, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceLineElement, ColorUtils.LinearRed);
				TsMoveBlueprintFunctionLibrary.WaterTraceInternal = utraceLineElement;
			}
			return TsMoveBlueprintFunctionLibrary.WaterTraceInternal;
		}
	}

	// Token: 0x17002073 RID: 8307
	// (get) Token: 0x06018354 RID: 99156 RVA: 0x006C40D8 File Offset: 0x006C22D8
	[Nullable(1)]
	private static UTraceLineElement GroundTrace
	{
		[NullableContext(1)]
		get
		{
			if (TsMoveBlueprintFunctionLibrary.GroundTraceInternal == null)
			{
				UTraceLineElement utraceLineElement = new UTraceLineElement();
				utraceLineElement.bIsSingle = true;
				utraceLineElement.bIgnoreSelf = true;
				utraceLineElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
				Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceLineElement, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceLineElement, ColorUtils.LinearRed);
				TsMoveBlueprintFunctionLibrary.GroundTraceInternal = utraceLineElement;
			}
			return TsMoveBlueprintFunctionLibrary.GroundTraceInternal;
		}
	}

	// Token: 0x06018355 RID: 99157 RVA: 0x006C4138 File Offset: 0x006C2338
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVectorDouble SimpleSwim(int entityId, float deltaSeconds, float detectedHeight, FVectorDouble currentSpeed)
	{
		CharacterActorComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityId);
		if (component == null || !component.Valid)
		{
			return global::Vector.ZeroVectorDouble;
		}
		float num = Singleton<MathUtils>.Instance.Clamp(deltaSeconds, 0f, 0.15f);
		UTraceLineElement waterTrace = TsMoveBlueprintFunctionLibrary.WaterTrace;
		waterTrace.WorldContextObject = component.Actor;
		component.ActorUpProxy.Multiply((double)detectedHeight, TsMoveBlueprintFunctionLibrary.tmpVector);
		TsMoveBlueprintFunctionLibrary.tmpVector.AdditionEqual(component.ActorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(waterTrace, TsMoveBlueprintFunctionLibrary.tmpVector);
		component.ActorUpProxy.Multiply((double)(-(double)component.ScaledHalfHeight), TsMoveBlueprintFunctionLibrary.tmpVector);
		TsMoveBlueprintFunctionLibrary.tmpVector.AdditionEqual(component.ActorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(waterTrace, TsMoveBlueprintFunctionLibrary.tmpVector);
		float num2 = 0f;
		if (Singleton<TraceElementCommon>.Instance.LineTrace(waterTrace, "SimpleSwim"))
		{
			UTraceLineElement groundTrace = TsMoveBlueprintFunctionLibrary.GroundTrace;
			groundTrace.WorldContextObject = component.Actor;
			Singleton<TraceElementCommon>.Instance.GetHitLocation(waterTrace.HitResult, 0, TsMoveBlueprintFunctionLibrary.tmpVector);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(groundTrace, TsMoveBlueprintFunctionLibrary.tmpVector);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(groundTrace, component.ActorLocationProxy);
			if (!Singleton<TraceElementCommon>.Instance.LineTrace(groundTrace, "SimpleSwim_Ground"))
			{
				TsMoveBlueprintFunctionLibrary.tmpVector.SubtractionEqual(component.ActorLocationProxy);
				num2 = (float)Singleton<MathUtils>.Instance.Clamp(TsMoveBlueprintFunctionLibrary.tmpVector.DotProduct(component.ActorUpProxy) / (double)component.ScaledHalfHeight * 0.5 + 0.5, 0.0, 1.0);
			}
		}
		else
		{
			UTraceLineElement groundTrace2 = TsMoveBlueprintFunctionLibrary.GroundTrace;
			groundTrace2.WorldContextObject = component.Actor;
			component.ActorUpProxy.Multiply((double)(-(double)component.ScaledHalfHeight - 2f), TsMoveBlueprintFunctionLibrary.tmpVector);
			TsMoveBlueprintFunctionLibrary.tmpVector.AdditionEqual(component.ActorLocationProxy);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(groundTrace2, component.ActorLocationProxy);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(groundTrace2, TsMoveBlueprintFunctionLibrary.tmpVector);
			if (Singleton<TraceElementCommon>.Instance.LineTrace(groundTrace2, "SimpleSwim_Ground"))
			{
				return global::Vector.ZeroVectorDouble;
			}
		}
		BaseMoveComponent component2 = component.Entity.GetComponent<BaseMoveComponent>();
		TsMoveBlueprintFunctionLibrary.tmpVector.FromUeVector(currentSpeed);
		double num4;
		double num3 = num4 = Singleton<GravityUtils>.Instance.GetZnInGravityForActor(component, TsMoveBlueprintFunctionLibrary.tmpVector);
		if (component2 != null && component2.Valid)
		{
			num4 += (double)(component2.CharacterMovement.GetGravityZ() * num) * (1.0 - (double)num2 * 1.4);
		}
		else
		{
			num4 += (double)(1960f * num) * (1.0 - (double)num2 * 1.4);
		}
		num4 *= (double)((float)Math.Pow(0.05999999865889549, (double)num));
		double num5 = (num3 + num4) / 2.0 * (double)num;
		num5 = Singleton<MathUtils>.Instance.Clamp(num5, (double)((num2 - 1f) * 2f * component.ScaledHalfHeight), (double)(num2 * 2f * component.ScaledHalfHeight));
		TsMoveBlueprintFunctionLibrary.tmpVector.Reset();
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(component, TsMoveBlueprintFunctionLibrary.tmpVector, num5);
		if (component2 != null && component2.Valid)
		{
			component2.MoveCharacter(TsMoveBlueprintFunctionLibrary.tmpVector, num, "SimpleSwim");
		}
		else
		{
			component.AddActorWorldOffset(TsMoveBlueprintFunctionLibrary.tmpVector.ToUeVector(false), "SimpleSwim", true);
		}
		TsMoveBlueprintFunctionLibrary.tmpVector2.Reset();
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(component, TsMoveBlueprintFunctionLibrary.tmpVector2, num4);
		return TsMoveBlueprintFunctionLibrary.tmpVector2.ToUeVector(false);
	}

	// Token: 0x06018356 RID: 99158 RVA: 0x006C44BC File Offset: 0x006C26BC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnterRoll(int entityId, float targetSpeed, float friction, float accelOnGround, float gravity, float stepUpHeight, float maxSpeed)
	{
		CharacterRollComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterRollComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.EnterRoll(targetSpeed, friction, accelOnGround, gravity, stepUpHeight, maxSpeed);
	}

	// Token: 0x06018357 RID: 99159 RVA: 0x006C44DC File Offset: 0x006C26DC
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LeaveRoll(int entityId)
	{
		CharacterRollComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterRollComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.LeaveRoll();
	}

	// Token: 0x06018358 RID: 99160 RVA: 0x006C44F4 File Offset: 0x006C26F4
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool EnterKite(int entityId)
	{
		CharacterKiteComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterKiteComponent>(entityId);
		BaseSceneInteractComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseSceneInteractComponent>(entityId);
		return component != null && component.Valid && component2 != null && component2.Valid && component.EnterKite(component2.GetCurrentTarget());
	}

	// Token: 0x06018359 RID: 99161 RVA: 0x006C4540 File Offset: 0x006C2740
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static FVeloctiyBlend LerpVelocityBlend(FVeloctiyBlend outVeloctiyBlend, FVeloctiyBlend to, float alpha)
	{
		outVeloctiyBlend.Forward = Singleton<MathUtils>.Instance.Lerp(outVeloctiyBlend.Forward, to.Forward, alpha);
		outVeloctiyBlend.Backward = Singleton<MathUtils>.Instance.Lerp(outVeloctiyBlend.Backward, to.Backward, alpha);
		outVeloctiyBlend.Left = Singleton<MathUtils>.Instance.Lerp(outVeloctiyBlend.Left, to.Left, alpha);
		outVeloctiyBlend.Right = Singleton<MathUtils>.Instance.Lerp(outVeloctiyBlend.Right, to.Right, alpha);
		float num = 1f / (outVeloctiyBlend.Forward + outVeloctiyBlend.Backward + outVeloctiyBlend.Left + outVeloctiyBlend.Right);
		if (num < 1f)
		{
			outVeloctiyBlend.Forward *= num;
			outVeloctiyBlend.Backward *= num;
			outVeloctiyBlend.Left *= num;
			outVeloctiyBlend.Right *= num;
		}
		return outVeloctiyBlend;
	}

	// Token: 0x0601835A RID: 99162 RVA: 0x006C462C File Offset: 0x006C282C
	[NullableContext(1)]
	private static void MoveCharacterDetectFloor(CharacterActorComponent actor, global::Vector loc)
	{
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = actor.Owner;
		actorTrace.Radius = actor.ScaledRadius;
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			actorTrace.ActorsToIgnore.Add(value);
		}
		TsMoveBlueprintFunctionLibrary.tmpVector.DeepCopy(loc);
		TsMoveBlueprintFunctionLibrary.tmpVector.AdditionEqual(actor.ActorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, TsMoveBlueprintFunctionLibrary.tmpVector);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actor, TsMoveBlueprintFunctionLibrary.tmpVector, (double)(-(double)actor.ScaledHalfHeight));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, TsMoveBlueprintFunctionLibrary.tmpVector);
		string text = "MoveCharacterDetectFloor";
		if (Singleton<TraceElementCommon>.Instance.ShapeTrace(actor.Actor.CapsuleComponent, actorTrace, text, text))
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(actorTrace.HitResult, 0, loc);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actor, loc, (double)actor.ScaledHalfHeight);
			loc.SubtractionEqual(actor.ActorLocationProxy);
		}
	}

	// Token: 0x0601835B RID: 99163 RVA: 0x006C4754 File Offset: 0x006C2954
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static bool MoveCharacter(int entityId, FVectorDouble targetLocation, float speed, int arriveDist)
	{
		CharacterMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterMoveComponent>(entityId);
		if (((component != null) ? component.ActorComp : null) == null)
		{
			return true;
		}
		Singleton<MathUtils>.Instance.CommonTempVector.DeepCopy(targetLocation);
		Singleton<MathUtils>.Instance.CommonTempVector.SubtractionEqual(component.ActorComp.ActorLocationProxy);
		float num = speed * Singleton<Time>.Instance.DeltaTimeSeconds;
		double num2 = Math.Max(0.0, Singleton<MathUtils>.Instance.CommonTempVector.Size() - (double)arriveDist);
		Singleton<MathUtils>.Instance.CommonTempVector.Normalize(9.99999993922529E-09);
		if (num2 > (double)num)
		{
			Singleton<MathUtils>.Instance.CommonTempVector.MultiplyEqual((double)num);
			TsMoveBlueprintFunctionLibrary.MoveCharacterDetectFloor(component.ActorComp, Singleton<MathUtils>.Instance.CommonTempVector);
			if (component != null)
			{
				component.MoveCharacter(Singleton<MathUtils>.Instance.CommonTempVector, Singleton<Time>.Instance.DeltaTimeSeconds, "TsMoveBlueprintFunctionLibrary.MoveCharacter");
			}
			return false;
		}
		if (num2 > 0.0)
		{
			Singleton<MathUtils>.Instance.CommonTempVector.MultiplyEqual(num2);
			TsMoveBlueprintFunctionLibrary.MoveCharacterDetectFloor(component.ActorComp, Singleton<MathUtils>.Instance.CommonTempVector);
			if (component != null)
			{
				component.MoveCharacter(Singleton<MathUtils>.Instance.CommonTempVector, Singleton<Time>.Instance.DeltaTimeSeconds, "TsMoveBlueprintFunctionLibrary.MoveCharacter");
			}
		}
		return true;
	}

	// Token: 0x0601835C RID: 99164 RVA: 0x006C4895 File Offset: 0x006C2A95
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void StartAssistedWalk(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.MoveController.StartAssistedWalk();
	}

	// Token: 0x0601835D RID: 99165 RVA: 0x006C48B1 File Offset: 0x006C2AB1
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnterAssistedWalkIdle(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.MoveController.EnterAssistedWalkIdle();
	}

	// Token: 0x0601835E RID: 99166 RVA: 0x006C48CD File Offset: 0x006C2ACD
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnterAssistedWalking(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.MoveController.EnterAssistedWalking();
	}

	// Token: 0x0601835F RID: 99167 RVA: 0x006C48E9 File Offset: 0x006C2AE9
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LeftAssistedWalking(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.MoveController.LeftAssistedWalking();
	}

	// Token: 0x06018360 RID: 99168 RVA: 0x006C4905 File Offset: 0x006C2B05
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LeftStartSwing(int entityId)
	{
		CharacterSwingComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwingComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.LeftStartSwing();
	}

	// Token: 0x06018361 RID: 99169 RVA: 0x006C491C File Offset: 0x006C2B1C
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LeftLoopSwing(int entityId)
	{
		CharacterSwingComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwingComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.LeftLoopSwing();
	}

	// Token: 0x06018362 RID: 99170 RVA: 0x006C4933 File Offset: 0x006C2B33
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void LeftEndSwing(int entityId)
	{
		CharacterSwingComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSwingComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.LeftEndSwing();
	}

	// Token: 0x06018363 RID: 99171 RVA: 0x006C494A File Offset: 0x006C2B4A
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void ResetClimbConfig(int entityId, string key)
	{
		CharacterClimbComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterClimbComponent>(entityId);
		if (component == null)
		{
			return;
		}
		component.ResetClimbObjectConfig(key);
	}

	// Token: 0x06018364 RID: 99172 RVA: 0x006C4962 File Offset: 0x006C2B62
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06018365 RID: 99173 RVA: 0x006C4964 File Offset: 0x006C2B64
	public static void ResetStaticDefaultValue()
	{
		TsMoveBlueprintFunctionLibrary.WaterTraceInternal = null;
		TsMoveBlueprintFunctionLibrary.GroundTraceInternal = null;
	}

	// Token: 0x06018366 RID: 99174 RVA: 0x006C4974 File Offset: 0x006C2B74
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void EnableGoThrough(int entityId, int goThroughPriority)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null || component.CharacterMovement == null)
		{
			return;
		}
		component.CharacterMovement.GoThroughLower = true;
		if (goThroughPriority >= 0)
		{
			component.CharacterMovement.GoThroughPriority = goThroughPriority;
		}
	}

	// Token: 0x06018367 RID: 99175 RVA: 0x006C49B8 File Offset: 0x006C2BB8
	[UFunction(EFunctionFlags.FUNC_None)]
	protected static void DisableGoThrough(int entityId)
	{
		BaseMoveComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseMoveComponent>(entityId);
		if (component == null || component.CharacterMovement == null)
		{
			return;
		}
		component.CharacterMovement.GoThroughLower = false;
		component.ResetHitPriorityAndGoThrough();
	}

	// Token: 0x06018368 RID: 99176 RVA: 0x006C49EF File Offset: 0x006C2BEF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsMoveBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMoveBlueprintFunctionLibrary.TsMoveBlueprintFunctionLibrary_C");
		}
		return TsMoveBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06018369 RID: 99177 RVA: 0x006C4A14 File Offset: 0x006C2C14
	public TsMoveBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(TsMoveBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601836A RID: 99178 RVA: 0x006C4A3C File Offset: 0x006C2C3C
	[NullableContext(1)]
	public TsMoveBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMoveBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601836B RID: 99179 RVA: 0x006C4A6F File Offset: 0x006C2C6F
	protected TsMoveBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601836C RID: 99180 RVA: 0x006C4A78 File Offset: 0x006C2C78
	protected unsafe static void __CPPCALL_SetActorRotationWithPriority_Implementation(TsMoveBlueprintFunctionLibrary.__SetActorRotationWithPriority_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		__Params->__Result = TsMoveBlueprintFunctionLibrary.SetActorRotationWithPriority(__Params->entityId, __Params->value, __Params->sweep, context);
	}

	// Token: 0x0601836D RID: 99181 RVA: 0x006C4AB0 File Offset: 0x006C2CB0
	protected unsafe static void __CPPCALL_SetActorLocationWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__SetActorLocationWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		__Params->__Result = TsMoveBlueprintFunctionLibrary.SetActorLocationWithContext(__Params->entityId, __Params->location, __Params->sweep, context);
	}

	// Token: 0x0601836E RID: 99182 RVA: 0x006C4AE8 File Offset: 0x006C2CE8
	protected unsafe static void __CPPCALL_SetActorLocationAndRotationWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__SetActorLocationAndRotationWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.SetActorLocationAndRotationWithContext(__Params->entityId, __Params->location, __Params->rotation, __Params->sweep, context);
	}

	// Token: 0x0601836F RID: 99183 RVA: 0x006C4B20 File Offset: 0x006C2D20
	protected unsafe static void __CPPCALL_SetActorRotationWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__SetActorRotationWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		__Params->__Result = TsMoveBlueprintFunctionLibrary.SetActorRotationWithContext(__Params->entityId, __Params->rotation, __Params->sweep, context);
	}

	// Token: 0x06018370 RID: 99184 RVA: 0x006C4B58 File Offset: 0x006C2D58
	protected unsafe static void __CPPCALL_AddActorWorldOffsetWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__AddActorWorldOffsetWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.AddActorWorldOffsetWithContext(__Params->entityId, __Params->offset, __Params->sweep, context);
	}

	// Token: 0x06018371 RID: 99185 RVA: 0x006C4B8C File Offset: 0x006C2D8C
	protected unsafe static void __CPPCALL_AddActorWorldOffsetWithContextAndReset_Implementation(TsMoveBlueprintFunctionLibrary.__AddActorWorldOffsetWithContextAndReset_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.AddActorWorldOffsetWithContextAndReset(__Params->entityId, __Params->offset, __Params->sweep, context);
	}

	// Token: 0x06018372 RID: 99186 RVA: 0x006C4BC0 File Offset: 0x006C2DC0
	protected unsafe static void __CPPCALL_AddActorLocalOffsetWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__AddActorLocalOffsetWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.AddActorLocalOffsetWithContext(__Params->entityId, __Params->offset, __Params->sweep, context);
	}

	// Token: 0x06018373 RID: 99187 RVA: 0x006C4BF4 File Offset: 0x006C2DF4
	protected unsafe static void __CPPCALL_AddActorWorldRotationWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__AddActorWorldRotationWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.AddActorWorldRotationWithContext(__Params->entityId, __Params->rotation, __Params->sweep, context);
	}

	// Token: 0x06018374 RID: 99188 RVA: 0x006C4C28 File Offset: 0x006C2E28
	protected unsafe static void __CPPCALL_AddActorLocalRotationWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__AddActorLocalRotationWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.AddActorLocalRotationWithContext(__Params->entityId, __Params->rotation, __Params->sweep, context);
	}

	// Token: 0x06018375 RID: 99189 RVA: 0x006C4C5C File Offset: 0x006C2E5C
	protected unsafe static void __CPPCALL_ActorTeleportToWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__ActorTeleportToWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.ActorTeleportToWithContext(__Params->entityId, __Params->location, __Params->rotation, context);
	}

	// Token: 0x06018376 RID: 99190 RVA: 0x006C4C90 File Offset: 0x006C2E90
	protected unsafe static void __CPPCALL_SetActorLookAtWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__SetActorLookAtWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		__Params->__Result = TsMoveBlueprintFunctionLibrary.SetActorLookAtWithContext(__Params->entityId, __Params->targetPoint, context);
	}

	// Token: 0x06018377 RID: 99191 RVA: 0x006C4CC4 File Offset: 0x006C2EC4
	protected unsafe static void __CPPCALL_ActorKuroMoveAlongFloorWithContext_Implementation(TsMoveBlueprintFunctionLibrary.__ActorKuroMoveAlongFloorWithContext_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.ActorKuroMoveAlongFloorWithContext(__Params->entityId, __Params->velocity, __Params->deltaSeconds, context);
	}

	// Token: 0x06018378 RID: 99192 RVA: 0x006C4CF6 File Offset: 0x006C2EF6
	protected unsafe static void __CPPCALL_GetInputDirect_Implementation(TsMoveBlueprintFunctionLibrary.__GetInputDirect_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetInputDirect(__Params->entityId);
	}

	// Token: 0x06018379 RID: 99193 RVA: 0x006C4D09 File Offset: 0x006C2F09
	protected unsafe static void __CPPCALL_SetInputDirect_Implementation(TsMoveBlueprintFunctionLibrary.__SetInputDirect_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetInputDirect(__Params->entityId, __Params->direct);
	}

	// Token: 0x0601837A RID: 99194 RVA: 0x006C4D1C File Offset: 0x006C2F1C
	protected unsafe static void __CPPCALL_GetInputRotator_Implementation(TsMoveBlueprintFunctionLibrary.__GetInputRotator_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetInputRotator(__Params->entityId);
	}

	// Token: 0x0601837B RID: 99195 RVA: 0x006C4D2F File Offset: 0x006C2F2F
	protected unsafe static void __CPPCALL_SetInputRotator_Implementation(TsMoveBlueprintFunctionLibrary.__SetInputRotator_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetInputRotator(__Params->entityId, __Params->rotator);
	}

	// Token: 0x0601837C RID: 99196 RVA: 0x006C4D44 File Offset: 0x006C2F44
	protected unsafe static void __CPPCALL_SetCharacterHidden_Implementation(TsMoveBlueprintFunctionLibrary.__SetCharacterHidden_FunctionParams* __Params)
	{
		UObject orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UObject>(__Params->callObject);
		string reason = FString.ToString((void*)(&__Params->reason));
		TsMoveBlueprintFunctionLibrary.SetCharacterHidden(__Params->entityId, __Params->isHidden, orCreateUObjectByNativePointer, reason);
	}

	// Token: 0x0601837D RID: 99197 RVA: 0x006C4D7D File Offset: 0x006C2F7D
	protected unsafe static void __CPPCALL_SetHiddenMovementMode_Implementation(TsMoveBlueprintFunctionLibrary.__SetHiddenMovementMode_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetHiddenMovementMode(__Params->entityId, __Params->isHidden);
	}

	// Token: 0x0601837E RID: 99198 RVA: 0x006C4D90 File Offset: 0x006C2F90
	protected unsafe static void __CPPCALL_CanResponseInput_Implementation(TsMoveBlueprintFunctionLibrary.__CanResponseInput_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.CanResponseInput(__Params->entityId);
	}

	// Token: 0x0601837F RID: 99199 RVA: 0x006C4DA3 File Offset: 0x006C2FA3
	protected unsafe static void __CPPCALL_CanJumpPress_Implementation(TsMoveBlueprintFunctionLibrary.__CanJumpPress_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.CanJumpPress(__Params->entityId);
	}

	// Token: 0x06018380 RID: 99200 RVA: 0x006C4DB6 File Offset: 0x006C2FB6
	protected unsafe static void __CPPCALL_CanWalkPress_Implementation(TsMoveBlueprintFunctionLibrary.__CanWalkPress_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.CanWalkPress(__Params->entityId);
	}

	// Token: 0x06018381 RID: 99201 RVA: 0x006C4DC9 File Offset: 0x006C2FC9
	protected unsafe static void __CPPCALL_GetHeightAboveGround_Implementation(TsMoveBlueprintFunctionLibrary.__GetHeightAboveGround_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetHeightAboveGround(__Params->entityId, __Params->detectedHeight);
	}

	// Token: 0x06018382 RID: 99202 RVA: 0x006C4DE2 File Offset: 0x006C2FE2
	protected unsafe static void __CPPCALL_GetAcceleration_Implementation(TsMoveBlueprintFunctionLibrary.__GetAcceleration_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetAcceleration(__Params->entityId);
	}

	// Token: 0x06018383 RID: 99203 RVA: 0x006C4DF5 File Offset: 0x006C2FF5
	protected unsafe static void __CPPCALL_GetAimYawRate_Implementation(TsMoveBlueprintFunctionLibrary.__GetAimYawRate_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetAimYawRate(__Params->entityId);
	}

	// Token: 0x06018384 RID: 99204 RVA: 0x006C4E08 File Offset: 0x006C3008
	protected unsafe static void __CPPCALL_GetMovementData_Implementation(TsMoveBlueprintFunctionLibrary.__GetMovementData_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = SMovementSetting_State.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SMovementSetting_State movementData = TsMoveBlueprintFunctionLibrary.GetMovementData(__Params->entityId);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (movementData != null) ? movementData.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06018385 RID: 99205 RVA: 0x006C4E38 File Offset: 0x006C3038
	protected unsafe static void __CPPCALL_SmoothCharacterRotation_Implementation(TsMoveBlueprintFunctionLibrary.__SmoothCharacterRotation_FunctionParams* __Params)
	{
		string context = FString.ToString((void*)(&__Params->context));
		TsMoveBlueprintFunctionLibrary.SmoothCharacterRotation(__Params->entityId, __Params->target, __Params->speed, context);
	}

	// Token: 0x06018386 RID: 99206 RVA: 0x006C4E6A File Offset: 0x006C306A
	protected unsafe static void __CPPCALL_HasMoveInput_Implementation(TsMoveBlueprintFunctionLibrary.__HasMoveInput_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.HasMoveInput(__Params->entityId);
	}

	// Token: 0x06018387 RID: 99207 RVA: 0x006C4E7D File Offset: 0x006C307D
	protected unsafe static void __CPPCALL_HasMoveInputOrTickIntervalAndModelBuffer_Implementation(TsMoveBlueprintFunctionLibrary.__HasMoveInputOrTickIntervalAndModelBuffer_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.HasMoveInputOrTickIntervalAndModelBuffer(__Params->entityId);
	}

	// Token: 0x06018388 RID: 99208 RVA: 0x006C4E90 File Offset: 0x006C3090
	protected unsafe static void __CPPCALL_HasRotatorInput_Implementation(TsMoveBlueprintFunctionLibrary.__HasRotatorInput_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.HasRotatorInput(__Params->entityId);
	}

	// Token: 0x06018389 RID: 99209 RVA: 0x006C4EA3 File Offset: 0x006C30A3
	protected unsafe static void __CPPCALL_IsMoving_Implementation(TsMoveBlueprintFunctionLibrary.__IsMoving_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.IsMoving(__Params->entityId);
	}

	// Token: 0x0601838A RID: 99210 RVA: 0x006C4EB6 File Offset: 0x006C30B6
	protected unsafe static void __CPPCALL_IsJump_Implementation(TsMoveBlueprintFunctionLibrary.__IsJump_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.IsJump(__Params->entityId);
	}

	// Token: 0x0601838B RID: 99211 RVA: 0x006C4EC9 File Offset: 0x006C30C9
	protected unsafe static void __CPPCALL_GetSpeed_Implementation(TsMoveBlueprintFunctionLibrary.__GetSpeed_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetSpeed(__Params->entityId);
	}

	// Token: 0x0601838C RID: 99212 RVA: 0x006C4EDC File Offset: 0x006C30DC
	protected unsafe static void __CPPCALL_GetGroundedTime_Implementation(TsMoveBlueprintFunctionLibrary.__GetGroundedTime_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetGroundedTime(__Params->entityId);
	}

	// Token: 0x0601838D RID: 99213 RVA: 0x006C4EEF File Offset: 0x006C30EF
	protected unsafe static void __CPPCALL_IsFallingIntoWater_Implementation(TsMoveBlueprintFunctionLibrary.__IsFallingIntoWater_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.IsFallingIntoWater(__Params->entityId);
	}

	// Token: 0x0601838E RID: 99214 RVA: 0x006C4F02 File Offset: 0x006C3102
	protected unsafe static void __CPPCALL_SetForceSpeed_Implementation(TsMoveBlueprintFunctionLibrary.__SetForceSpeed_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetForceSpeed(__Params->entityId, __Params->speed);
	}

	// Token: 0x0601838F RID: 99215 RVA: 0x006C4F18 File Offset: 0x006C3118
	protected unsafe static void __CPPCALL_SetAddMove_Implementation(TsMoveBlueprintFunctionLibrary.__SetAddMove_FunctionParams* __Params)
	{
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->mesh);
		UCurveFloat orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UCurveFloat>(__Params->curve);
		TsMoveBlueprintFunctionLibrary.SetAddMove(__Params->entityId, orCreateUObjectByNativePointer, __Params->speed, __Params->timeLength, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06018390 RID: 99216 RVA: 0x006C4F58 File Offset: 0x006C3158
	protected unsafe static void __CPPCALL_StopAddMove_Implementation(TsMoveBlueprintFunctionLibrary.__StopAddMove_FunctionParams* __Params)
	{
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->mesh);
		TsMoveBlueprintFunctionLibrary.StopAddMove(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x06018391 RID: 99217 RVA: 0x006C4F7D File Offset: 0x006C317D
	protected unsafe static void __CPPCALL_FixActorLocation_Implementation(TsMoveBlueprintFunctionLibrary.__FixActorLocation_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = FHitResult.StaticStruct();
		IntPtr dest = &__Params->__Result;
		FHitResult fhitResult = TsMoveBlueprintFunctionLibrary.FixActorLocation(__Params->entityId, __Params->target, __Params->offset);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (fhitResult != null) ? fhitResult.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06018392 RID: 99218 RVA: 0x006C4FB6 File Offset: 0x006C31B6
	protected unsafe static void __CPPCALL_StopAllAddMove_Implementation(TsMoveBlueprintFunctionLibrary.__StopAllAddMove_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.StopAllAddMove(__Params->entityId);
	}

	// Token: 0x06018393 RID: 99219 RVA: 0x006C4FC4 File Offset: 0x006C31C4
	protected unsafe static void __CPPCALL_SetAddMoveWorld_Implementation(TsMoveBlueprintFunctionLibrary.__SetAddMoveWorld_FunctionParams* __Params)
	{
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->mesh);
		UCurveFloat orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UCurveFloat>(__Params->curve);
		TsMoveBlueprintFunctionLibrary.SetAddMoveWorld(__Params->entityId, orCreateUObjectByNativePointer, __Params->speed, __Params->timeLength, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06018394 RID: 99220 RVA: 0x006C5004 File Offset: 0x006C3204
	protected unsafe static void __CPPCALL_SetAddMoveWorldSpeed_Implementation(TsMoveBlueprintFunctionLibrary.__SetAddMoveWorldSpeed_FunctionParams* __Params)
	{
		UMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UMeshComponent>(__Params->mesh);
		TsMoveBlueprintFunctionLibrary.SetAddMoveWorldSpeed(__Params->entityId, orCreateUObjectByNativePointer, __Params->speed);
	}

	// Token: 0x06018395 RID: 99221 RVA: 0x006C502F File Offset: 0x006C322F
	protected unsafe static void __CPPCALL_SetAddMoveOffset_Implementation(TsMoveBlueprintFunctionLibrary.__SetAddMoveOffset_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetAddMoveOffset(__Params->entityId, __Params->offset);
	}

	// Token: 0x06018396 RID: 99222 RVA: 0x006C5042 File Offset: 0x006C3242
	protected unsafe static void __CPPCALL_SetAddMoveRotation_Implementation(TsMoveBlueprintFunctionLibrary.__SetAddMoveRotation_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetAddMoveRotation(__Params->entityId, __Params->rotation);
	}

	// Token: 0x06018397 RID: 99223 RVA: 0x006C5055 File Offset: 0x006C3255
	protected unsafe static void __CPPCALL_SetEnterWaterState_Implementation(TsMoveBlueprintFunctionLibrary.__SetEnterWaterState_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetEnterWaterState(__Params->entityId, __Params->isEnter);
	}

	// Token: 0x06018398 RID: 99224 RVA: 0x006C5068 File Offset: 0x006C3268
	protected unsafe static void __CPPCALL_GetClimbState_Implementation(TsMoveBlueprintFunctionLibrary.__GetClimbState_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetClimbState(__Params->entityId);
	}

	// Token: 0x06018399 RID: 99225 RVA: 0x006C507B File Offset: 0x006C327B
	protected unsafe static void __CPPCALL_GetClimbRadius_Implementation(TsMoveBlueprintFunctionLibrary.__GetClimbRadius_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetClimbRadius(__Params->entityId);
	}

	// Token: 0x0601839A RID: 99226 RVA: 0x006C508E File Offset: 0x006C328E
	protected unsafe static void __CPPCALL_GetClimbInfo_Implementation(TsMoveBlueprintFunctionLibrary.__GetClimbInfo_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetClimbInfo(__Params->entityId);
	}

	// Token: 0x0601839B RID: 99227 RVA: 0x006C50A1 File Offset: 0x006C32A1
	protected unsafe static void __CPPCALL_KickExitCheck_Implementation(TsMoveBlueprintFunctionLibrary.__KickExitCheck_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.KickExitCheck(__Params->entityId);
	}

	// Token: 0x0601839C RID: 99228 RVA: 0x006C50AE File Offset: 0x006C32AE
	protected unsafe static void __CPPCALL_CanClimbPress_Implementation(TsMoveBlueprintFunctionLibrary.__CanClimbPress_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.CanClimbPress(__Params->entityId);
	}

	// Token: 0x0601839D RID: 99229 RVA: 0x006C50C1 File Offset: 0x006C32C1
	protected unsafe static void __CPPCALL_OnEnterClimb_Implementation(TsMoveBlueprintFunctionLibrary.__OnEnterClimb_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.OnEnterClimb(__Params->entityId);
	}

	// Token: 0x0601839E RID: 99230 RVA: 0x006C50CE File Offset: 0x006C32CE
	protected unsafe static void __CPPCALL_OnExitClimb_Implementation(TsMoveBlueprintFunctionLibrary.__OnExitClimb_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.OnExitClimb(__Params->entityId);
	}

	// Token: 0x0601839F RID: 99231 RVA: 0x006C50DB File Offset: 0x006C32DB
	protected unsafe static void __CPPCALL_DealClimbUpStart_Implementation(TsMoveBlueprintFunctionLibrary.__DealClimbUpStart_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.DealClimbUpStart(__Params->entityId);
	}

	// Token: 0x060183A0 RID: 99232 RVA: 0x006C50E8 File Offset: 0x006C32E8
	protected unsafe static void __CPPCALL_FinishClimbDown_Implementation(TsMoveBlueprintFunctionLibrary.__FinishClimbDown_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.FinishClimbDown(__Params->entityId);
	}

	// Token: 0x060183A1 RID: 99233 RVA: 0x006C50F5 File Offset: 0x006C32F5
	protected unsafe static void __CPPCALL_DealClimbUpFinish_Implementation(TsMoveBlueprintFunctionLibrary.__DealClimbUpFinish_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.DealClimbUpFinish(__Params->entityId);
	}

	// Token: 0x060183A2 RID: 99234 RVA: 0x006C5104 File Offset: 0x006C3304
	protected unsafe static void __CPPCALL_SetClimbState_Implementation(TsMoveBlueprintFunctionLibrary.__SetClimbState_FunctionParams* __Params)
	{
		EClimbState climbState = (EClimbState)__Params->climbState;
		TsMoveBlueprintFunctionLibrary.SetClimbState(__Params->entityId, climbState);
	}

	// Token: 0x060183A3 RID: 99235 RVA: 0x006C5124 File Offset: 0x006C3324
	protected unsafe static void __CPPCALL_SetEnterClimbType_Implementation(TsMoveBlueprintFunctionLibrary.__SetEnterClimbType_FunctionParams* __Params)
	{
		EEnterClimb enterType = (EEnterClimb)__Params->enterType;
		TsMoveBlueprintFunctionLibrary.SetEnterClimbType(__Params->entityId, enterType);
	}

	// Token: 0x060183A4 RID: 99236 RVA: 0x006C5144 File Offset: 0x006C3344
	protected unsafe static void __CPPCALL_SetExitClimbType_Implementation(TsMoveBlueprintFunctionLibrary.__SetExitClimbType_FunctionParams* __Params)
	{
		EExitClimb exitType = (EExitClimb)__Params->exitType;
		TsMoveBlueprintFunctionLibrary.SetExitClimbType(__Params->entityId, exitType);
	}

	// Token: 0x060183A5 RID: 99237 RVA: 0x006C5164 File Offset: 0x006C3364
	protected unsafe static void __CPPCALL_GetSwimLocation_Implementation(TsMoveBlueprintFunctionLibrary.__GetSwimLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetSwimLocation(__Params->entityId);
	}

	// Token: 0x060183A6 RID: 99238 RVA: 0x006C5177 File Offset: 0x006C3377
	protected unsafe static void __CPPCALL_GetWaterLocation_Implementation(TsMoveBlueprintFunctionLibrary.__GetWaterLocation_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetWaterLocation(__Params->entityId);
	}

	// Token: 0x060183A7 RID: 99239 RVA: 0x006C518A File Offset: 0x006C338A
	protected unsafe static void __CPPCALL_GetWaterVolume_Implementation(TsMoveBlueprintFunctionLibrary.__GetWaterVolume_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetWaterVolume(__Params->entityId);
	}

	// Token: 0x060183A8 RID: 99240 RVA: 0x006C519D File Offset: 0x006C339D
	protected unsafe static void __CPPCALL_GetClimbOnWallAngle_Implementation(TsMoveBlueprintFunctionLibrary.__GetClimbOnWallAngle_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetClimbOnWallAngle(__Params->entityId);
	}

	// Token: 0x060183A9 RID: 99241 RVA: 0x006C51B0 File Offset: 0x006C33B0
	protected unsafe static void __CPPCALL_SetUseDebugMovementSetting_Implementation(TsMoveBlueprintFunctionLibrary.__SetUseDebugMovementSetting_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetUseDebugMovementSetting(__Params->entityId, __Params->newSelect);
	}

	// Token: 0x060183AA RID: 99242 RVA: 0x006C51C4 File Offset: 0x006C33C4
	protected unsafe static void __CPPCALL_SetDebugMovementSetting_Implementation(TsMoveBlueprintFunctionLibrary.__SetDebugMovementSetting_FunctionParams* __Params)
	{
		SMovementSetting newSetting = new SMovementSetting(&__Params->newSetting, true, true);
		TsMoveBlueprintFunctionLibrary.SetDebugMovementSetting(__Params->entityId, newSetting);
	}

	// Token: 0x060183AB RID: 99243 RVA: 0x006C51EC File Offset: 0x006C33EC
	protected unsafe static void __CPPCALL_SetLockedRotation_Implementation(TsMoveBlueprintFunctionLibrary.__SetLockedRotation_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetLockedRotation(__Params->entityId, __Params->lockedRotation);
	}

	// Token: 0x060183AC RID: 99244 RVA: 0x006C51FF File Offset: 0x006C33FF
	protected unsafe static void __CPPCALL_GetLockedRotation_Implementation(TsMoveBlueprintFunctionLibrary.__GetLockedRotation_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetLockedRotation(__Params->entityId);
	}

	// Token: 0x060183AD RID: 99245 RVA: 0x006C5212 File Offset: 0x006C3412
	protected unsafe static void __CPPCALL_SetFallingHorizontalMaxSpeed_Implementation(TsMoveBlueprintFunctionLibrary.__SetFallingHorizontalMaxSpeed_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetFallingHorizontalMaxSpeed(__Params->entityId, __Params->speed);
	}

	// Token: 0x060183AE RID: 99246 RVA: 0x006C5225 File Offset: 0x006C3425
	protected unsafe static void __CPPCALL_ClearFallingHorizontalMaxSpeed_Implementation(TsMoveBlueprintFunctionLibrary.__ClearFallingHorizontalMaxSpeed_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.ClearFallingHorizontalMaxSpeed(__Params->entityId);
	}

	// Token: 0x060183AF RID: 99247 RVA: 0x006C5232 File Offset: 0x006C3432
	protected unsafe static void __CPPCALL_DetectClimbWithDirect_Implementation(TsMoveBlueprintFunctionLibrary.__DetectClimbWithDirect_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.DetectClimbWithDirect(__Params->entityId, __Params->bSprintEnter, __Params->direct);
	}

	// Token: 0x060183B0 RID: 99248 RVA: 0x006C5254 File Offset: 0x006C3454
	protected unsafe static void __CPPCALL_TurnToTarget_Implementation(TsMoveBlueprintFunctionLibrary.__TurnToTarget_FunctionParams* __Params)
	{
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->target);
		TsMoveBlueprintFunctionLibrary.TurnToTarget(__Params->entityId, orCreateUObjectByNativePointer, __Params->speed);
	}

	// Token: 0x060183B1 RID: 99249 RVA: 0x006C527F File Offset: 0x006C347F
	protected unsafe static void __CPPCALL_GetMonsterMoveDirection_Implementation(TsMoveBlueprintFunctionLibrary.__GetMonsterMoveDirection_FunctionParams* __Params)
	{
		*(&__Params->__Result) = (byte)TsMoveBlueprintFunctionLibrary.GetMonsterMoveDirection(__Params->entityId);
	}

	// Token: 0x060183B2 RID: 99250 RVA: 0x006C5294 File Offset: 0x006C3494
	protected unsafe static void __CPPCALL_GetRoleBody_Implementation(TsMoveBlueprintFunctionLibrary.__GetRoleBody_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), TsMoveBlueprintFunctionLibrary.GetRoleBody(__Params->entityId));
	}

	// Token: 0x060183B3 RID: 99251 RVA: 0x006C52AD File Offset: 0x006C34AD
	protected unsafe static void __CPPCALL_GetRacingRightSpeed_Implementation(TsMoveBlueprintFunctionLibrary.__GetRacingRightSpeed_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetRacingRightSpeed(__Params->entityId);
	}

	// Token: 0x060183B4 RID: 99252 RVA: 0x006C52C0 File Offset: 0x006C34C0
	protected unsafe static void __CPPCALL_SetPendulumData_Implementation(TsMoveBlueprintFunctionLibrary.__SetPendulumData_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetPendulumData(__Params->entityId, __Params->addVelocityX, __Params->addVelocityY, __Params->addVelocityZ, __Params->forwardLossPercentage, __Params->lossPercentage, __Params->gravity, __Params->friction, __Params->deceleration, __Params->accelerator, __Params->maxSpeed, __Params->maxFallingSpeed);
	}

	// Token: 0x060183B5 RID: 99253 RVA: 0x006C531A File Offset: 0x006C351A
	protected unsafe static void __CPPCALL_Reset_Implementation(TsMoveBlueprintFunctionLibrary.__Reset_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.Reset(__Params->entityId);
	}

	// Token: 0x060183B6 RID: 99254 RVA: 0x006C5327 File Offset: 0x006C3527
	protected unsafe static void __CPPCALL_SetGrabPoint_Implementation(TsMoveBlueprintFunctionLibrary.__SetGrabPoint_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetGrabPoint(__Params->entityId, __Params->point);
	}

	// Token: 0x060183B7 RID: 99255 RVA: 0x006C533A File Offset: 0x006C353A
	protected unsafe static void __CPPCALL_GetGrabPoint_Implementation(TsMoveBlueprintFunctionLibrary.__GetGrabPoint_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetGrabPoint(__Params->entityId);
	}

	// Token: 0x060183B8 RID: 99256 RVA: 0x006C534D File Offset: 0x006C354D
	protected unsafe static void __CPPCALL_SetHooked_Implementation(TsMoveBlueprintFunctionLibrary.__SetHooked_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetHooked(__Params->entityId, __Params->isHooked);
	}

	// Token: 0x060183B9 RID: 99257 RVA: 0x006C5360 File Offset: 0x006C3560
	protected unsafe static void __CPPCALL_GetHooked_Implementation(TsMoveBlueprintFunctionLibrary.__GetHooked_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetHooked(__Params->entityId);
	}

	// Token: 0x060183BA RID: 99258 RVA: 0x006C5374 File Offset: 0x006C3574
	protected unsafe static void __CPPCALL_SetSocketName_Implementation(TsMoveBlueprintFunctionLibrary.__SetSocketName_FunctionParams* __Params)
	{
		string socketName = FString.ToString((void*)(&__Params->socketName));
		TsMoveBlueprintFunctionLibrary.SetSocketName(__Params->entityId, socketName);
	}

	// Token: 0x060183BB RID: 99259 RVA: 0x006C539A File Offset: 0x006C359A
	protected unsafe static void __CPPCALL_SetRopeForce_Implementation(TsMoveBlueprintFunctionLibrary.__SetRopeForce_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetRopeForce(__Params->entityId, __Params->ropeForce);
	}

	// Token: 0x060183BC RID: 99260 RVA: 0x006C53AD File Offset: 0x006C35AD
	protected unsafe static void __CPPCALL_GetRopeForce_Implementation(TsMoveBlueprintFunctionLibrary.__GetRopeForce_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetRopeForce(__Params->entityId);
	}

	// Token: 0x060183BD RID: 99261 RVA: 0x006C53C0 File Offset: 0x006C35C0
	protected unsafe static void __CPPCALL_SetDistanceRopeToActor_Implementation(TsMoveBlueprintFunctionLibrary.__SetDistanceRopeToActor_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetDistanceRopeToActor(__Params->entityId, __Params->ropeForce);
	}

	// Token: 0x060183BE RID: 99262 RVA: 0x006C53D3 File Offset: 0x006C35D3
	protected unsafe static void __CPPCALL_GetDistanceRopeToActor_Implementation(TsMoveBlueprintFunctionLibrary.__GetDistanceRopeToActor_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetDistanceRopeToActor(__Params->entityId);
	}

	// Token: 0x060183BF RID: 99263 RVA: 0x006C53E6 File Offset: 0x006C35E6
	protected unsafe static void __CPPCALL_SetAirControl_Implementation(TsMoveBlueprintFunctionLibrary.__SetAirControl_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetAirControl(__Params->entityId, __Params->airControl);
	}

	// Token: 0x060183C0 RID: 99264 RVA: 0x006C53F9 File Offset: 0x006C35F9
	protected unsafe static void __CPPCALL_GetAirControl_Implementation(TsMoveBlueprintFunctionLibrary.__GetAirControl_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.GetAirControl(__Params->entityId);
	}

	// Token: 0x060183C1 RID: 99265 RVA: 0x006C540C File Offset: 0x006C360C
	protected unsafe static void __CPPCALL_SetUpLength_Implementation(TsMoveBlueprintFunctionLibrary.__SetUpLength_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetUpLength(__Params->entityId, __Params->length);
	}

	// Token: 0x060183C2 RID: 99266 RVA: 0x006C541F File Offset: 0x006C361F
	protected unsafe static void __CPPCALL_SetCanMoveFromInput_Implementation(TsMoveBlueprintFunctionLibrary.__SetCanMoveFromInput_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.SetCanMoveFromInput(__Params->entityId, __Params->canMove);
	}

	// Token: 0x060183C3 RID: 99267 RVA: 0x006C5434 File Offset: 0x006C3634
	protected unsafe static void __CPPCALL_UpdateAnimInfoMove_Implementation(TsMoveBlueprintFunctionLibrary.__UpdateAnimInfoMove_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsMoveBlueprintFunctionLibrary.UpdateAnimInfoMove(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060183C4 RID: 99268 RVA: 0x006C545C File Offset: 0x006C365C
	protected unsafe static void __CPPCALL_UpdateAnimInfoMoveMonster_Implementation(TsMoveBlueprintFunctionLibrary.__UpdateAnimInfoMoveMonster_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsMoveBlueprintFunctionLibrary.UpdateAnimInfoMoveMonster(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060183C5 RID: 99269 RVA: 0x006C5484 File Offset: 0x006C3684
	protected unsafe static void __CPPCALL_UpdateAnimInfoMoveRoleNpc_Implementation(TsMoveBlueprintFunctionLibrary.__UpdateAnimInfoMoveRoleNpc_FunctionParams* __Params)
	{
		BP_ABPLogicParams_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_ABPLogicParams_C>(__Params->animLogicParams);
		TsMoveBlueprintFunctionLibrary.UpdateAnimInfoMoveRoleNpc(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060183C6 RID: 99270 RVA: 0x006C54AC File Offset: 0x006C36AC
	protected unsafe static void __CPPCALL_TurnOnAutomaticFlightMode_Implementation(TsMoveBlueprintFunctionLibrary.__TurnOnAutomaticFlightMode_FunctionParams* __Params)
	{
		ICM_AutomaticFlight_DataBase_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ICM_AutomaticFlight_DataBase_C>(__Params->dataAsset);
		TsMoveBlueprintFunctionLibrary.TurnOnAutomaticFlightMode(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060183C7 RID: 99271 RVA: 0x006C54D1 File Offset: 0x006C36D1
	protected unsafe static void __CPPCALL_TurnOffAutomaticFlightMode_Implementation(TsMoveBlueprintFunctionLibrary.__TurnOffAutomaticFlightMode_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.TurnOffAutomaticFlightMode(__Params->entityId);
	}

	// Token: 0x060183C8 RID: 99272 RVA: 0x006C54E0 File Offset: 0x006C36E0
	protected unsafe static void __CPPCALL_TurnOnCameraDrivenAutoFlightMode_Implementation(TsMoveBlueprintFunctionLibrary.__TurnOnCameraDrivenAutoFlightMode_FunctionParams* __Params)
	{
		BP_CameraDrivenAutoFlightData_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_CameraDrivenAutoFlightData_C>(__Params->dataAsset);
		TsMoveBlueprintFunctionLibrary.TurnOnCameraDrivenAutoFlightMode(__Params->entityId, orCreateUObjectByNativePointer);
	}

	// Token: 0x060183C9 RID: 99273 RVA: 0x006C5505 File Offset: 0x006C3705
	protected unsafe static void __CPPCALL_TurnOffCameraDrivenAutoFlightMode_Implementation(TsMoveBlueprintFunctionLibrary.__TurnOffCameraDrivenAutoFlightMode_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.TurnOffCameraDrivenAutoFlightMode(__Params->entityId);
	}

	// Token: 0x060183CA RID: 99274 RVA: 0x006C5512 File Offset: 0x006C3712
	protected unsafe static void __CPPCALL_SimpleSwim_Implementation(TsMoveBlueprintFunctionLibrary.__SimpleSwim_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.SimpleSwim(__Params->entityId, __Params->deltaSeconds, __Params->detectedHeight, __Params->currentSpeed);
	}

	// Token: 0x060183CB RID: 99275 RVA: 0x006C5537 File Offset: 0x006C3737
	protected unsafe static void __CPPCALL_EnterRoll_Implementation(TsMoveBlueprintFunctionLibrary.__EnterRoll_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.EnterRoll(__Params->entityId, __Params->targetSpeed, __Params->friction, __Params->accelOnGround, __Params->gravity, __Params->stepUpHeight, __Params->maxSpeed);
	}

	// Token: 0x060183CC RID: 99276 RVA: 0x006C5568 File Offset: 0x006C3768
	protected unsafe static void __CPPCALL_LeaveRoll_Implementation(TsMoveBlueprintFunctionLibrary.__LeaveRoll_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.LeaveRoll(__Params->entityId);
	}

	// Token: 0x060183CD RID: 99277 RVA: 0x006C5575 File Offset: 0x006C3775
	protected unsafe static void __CPPCALL_EnterKite_Implementation(TsMoveBlueprintFunctionLibrary.__EnterKite_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.EnterKite(__Params->entityId);
	}

	// Token: 0x060183CE RID: 99278 RVA: 0x006C5588 File Offset: 0x006C3788
	protected unsafe static void __CPPCALL_LerpVelocityBlend_Implementation(TsMoveBlueprintFunctionLibrary.__LerpVelocityBlend_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.LerpVelocityBlend(__Params->outVeloctiyBlend, __Params->to, __Params->alpha);
	}

	// Token: 0x060183CF RID: 99279 RVA: 0x006C55A7 File Offset: 0x006C37A7
	protected unsafe static void __CPPCALL_MoveCharacter_Implementation(TsMoveBlueprintFunctionLibrary.__MoveCharacter_FunctionParams* __Params)
	{
		__Params->__Result = TsMoveBlueprintFunctionLibrary.MoveCharacter(__Params->entityId, __Params->targetLocation, __Params->speed, __Params->arriveDist);
	}

	// Token: 0x060183D0 RID: 99280 RVA: 0x006C55CC File Offset: 0x006C37CC
	protected unsafe static void __CPPCALL_StartAssistedWalk_Implementation(TsMoveBlueprintFunctionLibrary.__StartAssistedWalk_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.StartAssistedWalk(__Params->entityId);
	}

	// Token: 0x060183D1 RID: 99281 RVA: 0x006C55D9 File Offset: 0x006C37D9
	protected unsafe static void __CPPCALL_EnterAssistedWalkIdle_Implementation(TsMoveBlueprintFunctionLibrary.__EnterAssistedWalkIdle_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.EnterAssistedWalkIdle(__Params->entityId);
	}

	// Token: 0x060183D2 RID: 99282 RVA: 0x006C55E6 File Offset: 0x006C37E6
	protected unsafe static void __CPPCALL_EnterAssistedWalking_Implementation(TsMoveBlueprintFunctionLibrary.__EnterAssistedWalking_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.EnterAssistedWalking(__Params->entityId);
	}

	// Token: 0x060183D3 RID: 99283 RVA: 0x006C55F3 File Offset: 0x006C37F3
	protected unsafe static void __CPPCALL_LeftAssistedWalking_Implementation(TsMoveBlueprintFunctionLibrary.__LeftAssistedWalking_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.LeftAssistedWalking(__Params->entityId);
	}

	// Token: 0x060183D4 RID: 99284 RVA: 0x006C5600 File Offset: 0x006C3800
	protected unsafe static void __CPPCALL_LeftStartSwing_Implementation(TsMoveBlueprintFunctionLibrary.__LeftStartSwing_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.LeftStartSwing(__Params->entityId);
	}

	// Token: 0x060183D5 RID: 99285 RVA: 0x006C560D File Offset: 0x006C380D
	protected unsafe static void __CPPCALL_LeftLoopSwing_Implementation(TsMoveBlueprintFunctionLibrary.__LeftLoopSwing_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.LeftLoopSwing(__Params->entityId);
	}

	// Token: 0x060183D6 RID: 99286 RVA: 0x006C561A File Offset: 0x006C381A
	protected unsafe static void __CPPCALL_LeftEndSwing_Implementation(TsMoveBlueprintFunctionLibrary.__LeftEndSwing_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.LeftEndSwing(__Params->entityId);
	}

	// Token: 0x060183D7 RID: 99287 RVA: 0x006C5628 File Offset: 0x006C3828
	protected unsafe static void __CPPCALL_ResetClimbConfig_Implementation(TsMoveBlueprintFunctionLibrary.__ResetClimbConfig_FunctionParams* __Params)
	{
		string key = FString.ToString((void*)(&__Params->key));
		TsMoveBlueprintFunctionLibrary.ResetClimbConfig(__Params->entityId, key);
	}

	// Token: 0x060183D8 RID: 99288 RVA: 0x006C564E File Offset: 0x006C384E
	protected unsafe static void __CPPCALL_EnableGoThrough_Implementation(TsMoveBlueprintFunctionLibrary.__EnableGoThrough_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.EnableGoThrough(__Params->entityId, __Params->goThroughPriority);
	}

	// Token: 0x060183D9 RID: 99289 RVA: 0x006C5661 File Offset: 0x006C3861
	protected unsafe static void __CPPCALL_DisableGoThrough_Implementation(TsMoveBlueprintFunctionLibrary.__DisableGoThrough_FunctionParams* __Params)
	{
		TsMoveBlueprintFunctionLibrary.DisableGoThrough(__Params->entityId);
	}

	// Token: 0x0400BA27 RID: 47655
	private const int MIN_ROTATOR_ANGLE = 10;

	// Token: 0x0400BA28 RID: 47656
	private const float MAX_SIMPLE_SWIM_DELTA = 0.15f;

	// Token: 0x0400BA29 RID: 47657
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static global::Vector tmpVector = global::Vector.Create();

	// Token: 0x0400BA2A RID: 47658
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static global::Vector tmpVector2 = global::Vector.Create();

	// Token: 0x0400BA2B RID: 47659
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static Quat tmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400BA2C RID: 47660
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static global::Rotator tmpRotator = global::Rotator.Create();

	// Token: 0x0400BA2D RID: 47661
	[Nullable(2)]
	private static UTraceLineElement WaterTraceInternal = null;

	// Token: 0x0400BA2E RID: 47662
	[Nullable(2)]
	private static UTraceLineElement GroundTraceInternal = null;

	// Token: 0x0400BA2F RID: 47663
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/Common/Blueprint/Utils/TsMoveBlueprintFunctionLibrary.TsMoveBlueprintFunctionLibrary_C";

	// Token: 0x0400BA30 RID: 47664
	private static IntPtr _ClassPtr;

	// Token: 0x0400BA31 RID: 47665
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0200925F RID: 37471
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __SetActorRotationWithPriority_FunctionParams
	{
		// Token: 0x04030D19 RID: 199961
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D1A RID: 199962
		[FieldOffset(4)]
		public FRotator value;

		// Token: 0x04030D1B RID: 199963
		[FieldOffset(16)]
		public bool sweep;

		// Token: 0x04030D1C RID: 199964
		[FieldOffset(24)]
		public FString context;

		// Token: 0x04030D1D RID: 199965
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04030D1E RID: 199966
		[FieldOffset(48)]
		public bool __Result;
	}

	// Token: 0x02009260 RID: 37472
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __SetActorLocationWithContext_FunctionParams
	{
		// Token: 0x04030D1F RID: 199967
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D20 RID: 199968
		[FieldOffset(8)]
		public FVectorDouble location;

		// Token: 0x04030D21 RID: 199969
		[FieldOffset(32)]
		public bool sweep;

		// Token: 0x04030D22 RID: 199970
		[FieldOffset(40)]
		public FString context;

		// Token: 0x04030D23 RID: 199971
		[FieldOffset(56)]
		public IntPtr __WorldContext;

		// Token: 0x04030D24 RID: 199972
		[FieldOffset(64)]
		public bool __Result;
	}

	// Token: 0x02009261 RID: 37473
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __SetActorLocationAndRotationWithContext_FunctionParams
	{
		// Token: 0x04030D25 RID: 199973
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D26 RID: 199974
		[FieldOffset(8)]
		public FVectorDouble location;

		// Token: 0x04030D27 RID: 199975
		[FieldOffset(32)]
		public FRotator rotation;

		// Token: 0x04030D28 RID: 199976
		[FieldOffset(44)]
		public bool sweep;

		// Token: 0x04030D29 RID: 199977
		[FieldOffset(48)]
		public FString context;

		// Token: 0x04030D2A RID: 199978
		[FieldOffset(64)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009262 RID: 37474
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __SetActorRotationWithContext_FunctionParams
	{
		// Token: 0x04030D2B RID: 199979
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D2C RID: 199980
		[FieldOffset(4)]
		public FRotator rotation;

		// Token: 0x04030D2D RID: 199981
		[FieldOffset(16)]
		public bool sweep;

		// Token: 0x04030D2E RID: 199982
		[FieldOffset(24)]
		public FString context;

		// Token: 0x04030D2F RID: 199983
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04030D30 RID: 199984
		[FieldOffset(48)]
		public bool __Result;
	}

	// Token: 0x02009263 RID: 37475
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __AddActorWorldOffsetWithContext_FunctionParams
	{
		// Token: 0x04030D31 RID: 199985
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D32 RID: 199986
		[FieldOffset(8)]
		public FVectorDouble offset;

		// Token: 0x04030D33 RID: 199987
		[FieldOffset(32)]
		public bool sweep;

		// Token: 0x04030D34 RID: 199988
		[FieldOffset(40)]
		public FString context;

		// Token: 0x04030D35 RID: 199989
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009264 RID: 37476
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __AddActorWorldOffsetWithContextAndReset_FunctionParams
	{
		// Token: 0x04030D36 RID: 199990
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D37 RID: 199991
		[FieldOffset(8)]
		public FVectorDouble offset;

		// Token: 0x04030D38 RID: 199992
		[FieldOffset(32)]
		public bool sweep;

		// Token: 0x04030D39 RID: 199993
		[FieldOffset(40)]
		public FString context;

		// Token: 0x04030D3A RID: 199994
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009265 RID: 37477
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __AddActorLocalOffsetWithContext_FunctionParams
	{
		// Token: 0x04030D3B RID: 199995
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D3C RID: 199996
		[FieldOffset(8)]
		public FVectorDouble offset;

		// Token: 0x04030D3D RID: 199997
		[FieldOffset(32)]
		public bool sweep;

		// Token: 0x04030D3E RID: 199998
		[FieldOffset(40)]
		public FString context;

		// Token: 0x04030D3F RID: 199999
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009266 RID: 37478
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __AddActorWorldRotationWithContext_FunctionParams
	{
		// Token: 0x04030D40 RID: 200000
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D41 RID: 200001
		[FieldOffset(4)]
		public FRotator rotation;

		// Token: 0x04030D42 RID: 200002
		[FieldOffset(16)]
		public bool sweep;

		// Token: 0x04030D43 RID: 200003
		[FieldOffset(24)]
		public FString context;

		// Token: 0x04030D44 RID: 200004
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009267 RID: 37479
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __AddActorLocalRotationWithContext_FunctionParams
	{
		// Token: 0x04030D45 RID: 200005
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D46 RID: 200006
		[FieldOffset(4)]
		public FRotator rotation;

		// Token: 0x04030D47 RID: 200007
		[FieldOffset(16)]
		public bool sweep;

		// Token: 0x04030D48 RID: 200008
		[FieldOffset(24)]
		public FString context;

		// Token: 0x04030D49 RID: 200009
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009268 RID: 37480
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __ActorTeleportToWithContext_FunctionParams
	{
		// Token: 0x04030D4A RID: 200010
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D4B RID: 200011
		[FieldOffset(8)]
		public FVectorDouble location;

		// Token: 0x04030D4C RID: 200012
		[FieldOffset(32)]
		public FRotator rotation;

		// Token: 0x04030D4D RID: 200013
		[FieldOffset(48)]
		public FString context;

		// Token: 0x04030D4E RID: 200014
		[FieldOffset(64)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009269 RID: 37481
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __SetActorLookAtWithContext_FunctionParams
	{
		// Token: 0x04030D4F RID: 200015
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D50 RID: 200016
		[FieldOffset(8)]
		public FVectorDouble targetPoint;

		// Token: 0x04030D51 RID: 200017
		[FieldOffset(32)]
		public FString context;

		// Token: 0x04030D52 RID: 200018
		[FieldOffset(48)]
		public IntPtr __WorldContext;

		// Token: 0x04030D53 RID: 200019
		[FieldOffset(56)]
		public bool __Result;
	}

	// Token: 0x0200926A RID: 37482
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __ActorKuroMoveAlongFloorWithContext_FunctionParams
	{
		// Token: 0x04030D54 RID: 200020
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D55 RID: 200021
		[FieldOffset(4)]
		public FVector velocity;

		// Token: 0x04030D56 RID: 200022
		[FieldOffset(16)]
		public float deltaSeconds;

		// Token: 0x04030D57 RID: 200023
		[FieldOffset(24)]
		public FString context;

		// Token: 0x04030D58 RID: 200024
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200926B RID: 37483
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetInputDirect_FunctionParams
	{
		// Token: 0x04030D59 RID: 200025
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D5A RID: 200026
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D5B RID: 200027
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x0200926C RID: 37484
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetInputDirect_FunctionParams
	{
		// Token: 0x04030D5C RID: 200028
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D5D RID: 200029
		[FieldOffset(8)]
		public FVectorDouble direct;

		// Token: 0x04030D5E RID: 200030
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200926D RID: 37485
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetInputRotator_FunctionParams
	{
		// Token: 0x04030D5F RID: 200031
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D60 RID: 200032
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D61 RID: 200033
		[FieldOffset(16)]
		public FRotator __Result;
	}

	// Token: 0x0200926E RID: 37486
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetInputRotator_FunctionParams
	{
		// Token: 0x04030D62 RID: 200034
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D63 RID: 200035
		[FieldOffset(4)]
		public FRotator rotator;

		// Token: 0x04030D64 RID: 200036
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200926F RID: 37487
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetCharacterHidden_FunctionParams
	{
		// Token: 0x04030D65 RID: 200037
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D66 RID: 200038
		[FieldOffset(4)]
		public bool isHidden;

		// Token: 0x04030D67 RID: 200039
		[FieldOffset(8)]
		public IntPtr callObject;

		// Token: 0x04030D68 RID: 200040
		[FieldOffset(16)]
		public FString reason;

		// Token: 0x04030D69 RID: 200041
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009270 RID: 37488
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetHiddenMovementMode_FunctionParams
	{
		// Token: 0x04030D6A RID: 200042
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D6B RID: 200043
		[FieldOffset(4)]
		public bool isHidden;

		// Token: 0x04030D6C RID: 200044
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009271 RID: 37489
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CanResponseInput_FunctionParams
	{
		// Token: 0x04030D6D RID: 200045
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D6E RID: 200046
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D6F RID: 200047
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009272 RID: 37490
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CanJumpPress_FunctionParams
	{
		// Token: 0x04030D70 RID: 200048
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D71 RID: 200049
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D72 RID: 200050
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009273 RID: 37491
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CanWalkPress_FunctionParams
	{
		// Token: 0x04030D73 RID: 200051
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D74 RID: 200052
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D75 RID: 200053
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009274 RID: 37492
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHeightAboveGround_FunctionParams
	{
		// Token: 0x04030D76 RID: 200054
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D77 RID: 200055
		[FieldOffset(4)]
		public float detectedHeight;

		// Token: 0x04030D78 RID: 200056
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D79 RID: 200057
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009275 RID: 37493
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetAcceleration_FunctionParams
	{
		// Token: 0x04030D7A RID: 200058
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D7B RID: 200059
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D7C RID: 200060
		[FieldOffset(16)]
		public FVector __Result;
	}

	// Token: 0x02009276 RID: 37494
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAimYawRate_FunctionParams
	{
		// Token: 0x04030D7D RID: 200061
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D7E RID: 200062
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D7F RID: 200063
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009277 RID: 37495
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1768)]
	protected ref struct __GetMovementData_FunctionParams
	{
		// Token: 0x04030D80 RID: 200064
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D81 RID: 200065
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D82 RID: 200066
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x02009278 RID: 37496
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __SmoothCharacterRotation_FunctionParams
	{
		// Token: 0x04030D83 RID: 200067
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D84 RID: 200068
		[FieldOffset(4)]
		public FRotator target;

		// Token: 0x04030D85 RID: 200069
		[FieldOffset(16)]
		public float speed;

		// Token: 0x04030D86 RID: 200070
		[FieldOffset(24)]
		public FString context;

		// Token: 0x04030D87 RID: 200071
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009279 RID: 37497
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __HasMoveInput_FunctionParams
	{
		// Token: 0x04030D88 RID: 200072
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D89 RID: 200073
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D8A RID: 200074
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200927A RID: 37498
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __HasMoveInputOrTickIntervalAndModelBuffer_FunctionParams
	{
		// Token: 0x04030D8B RID: 200075
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D8C RID: 200076
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D8D RID: 200077
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200927B RID: 37499
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __HasRotatorInput_FunctionParams
	{
		// Token: 0x04030D8E RID: 200078
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D8F RID: 200079
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D90 RID: 200080
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200927C RID: 37500
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsMoving_FunctionParams
	{
		// Token: 0x04030D91 RID: 200081
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D92 RID: 200082
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D93 RID: 200083
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200927D RID: 37501
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsJump_FunctionParams
	{
		// Token: 0x04030D94 RID: 200084
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D95 RID: 200085
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D96 RID: 200086
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200927E RID: 37502
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetSpeed_FunctionParams
	{
		// Token: 0x04030D97 RID: 200087
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D98 RID: 200088
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D99 RID: 200089
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200927F RID: 37503
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetGroundedTime_FunctionParams
	{
		// Token: 0x04030D9A RID: 200090
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D9B RID: 200091
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D9C RID: 200092
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x02009280 RID: 37504
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsFallingIntoWater_FunctionParams
	{
		// Token: 0x04030D9D RID: 200093
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030D9E RID: 200094
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030D9F RID: 200095
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009281 RID: 37505
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetForceSpeed_FunctionParams
	{
		// Token: 0x04030DA0 RID: 200096
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DA1 RID: 200097
		[FieldOffset(8)]
		public FVectorDouble speed;

		// Token: 0x04030DA2 RID: 200098
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009282 RID: 37506
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __SetAddMove_FunctionParams
	{
		// Token: 0x04030DA3 RID: 200099
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DA4 RID: 200100
		[FieldOffset(8)]
		public IntPtr mesh;

		// Token: 0x04030DA5 RID: 200101
		[FieldOffset(16)]
		public FVectorDouble speed;

		// Token: 0x04030DA6 RID: 200102
		[FieldOffset(40)]
		public float timeLength;

		// Token: 0x04030DA7 RID: 200103
		[FieldOffset(48)]
		public IntPtr curve;

		// Token: 0x04030DA8 RID: 200104
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009283 RID: 37507
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __StopAddMove_FunctionParams
	{
		// Token: 0x04030DA9 RID: 200105
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DAA RID: 200106
		[FieldOffset(8)]
		public IntPtr mesh;

		// Token: 0x04030DAB RID: 200107
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009284 RID: 37508
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 200)]
	protected ref struct __FixActorLocation_FunctionParams
	{
		// Token: 0x04030DAC RID: 200108
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DAD RID: 200109
		[FieldOffset(8)]
		public FVectorDouble target;

		// Token: 0x04030DAE RID: 200110
		[FieldOffset(32)]
		public float offset;

		// Token: 0x04030DAF RID: 200111
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04030DB0 RID: 200112
		[FieldOffset(48)]
		public byte __Result;
	}

	// Token: 0x02009285 RID: 37509
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StopAllAddMove_FunctionParams
	{
		// Token: 0x04030DB1 RID: 200113
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DB2 RID: 200114
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009286 RID: 37510
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __SetAddMoveWorld_FunctionParams
	{
		// Token: 0x04030DB3 RID: 200115
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DB4 RID: 200116
		[FieldOffset(8)]
		public IntPtr mesh;

		// Token: 0x04030DB5 RID: 200117
		[FieldOffset(16)]
		public FVectorDouble speed;

		// Token: 0x04030DB6 RID: 200118
		[FieldOffset(40)]
		public float timeLength;

		// Token: 0x04030DB7 RID: 200119
		[FieldOffset(48)]
		public IntPtr curve;

		// Token: 0x04030DB8 RID: 200120
		[FieldOffset(56)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009287 RID: 37511
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __SetAddMoveWorldSpeed_FunctionParams
	{
		// Token: 0x04030DB9 RID: 200121
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DBA RID: 200122
		[FieldOffset(8)]
		public IntPtr mesh;

		// Token: 0x04030DBB RID: 200123
		[FieldOffset(16)]
		public FVectorDouble speed;

		// Token: 0x04030DBC RID: 200124
		[FieldOffset(40)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009288 RID: 37512
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetAddMoveOffset_FunctionParams
	{
		// Token: 0x04030DBD RID: 200125
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DBE RID: 200126
		[FieldOffset(8)]
		public FVectorDouble offset;

		// Token: 0x04030DBF RID: 200127
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009289 RID: 37513
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetAddMoveRotation_FunctionParams
	{
		// Token: 0x04030DC0 RID: 200128
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DC1 RID: 200129
		[FieldOffset(4)]
		public FRotator rotation;

		// Token: 0x04030DC2 RID: 200130
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200928A RID: 37514
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEnterWaterState_FunctionParams
	{
		// Token: 0x04030DC3 RID: 200131
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DC4 RID: 200132
		[FieldOffset(4)]
		public bool isEnter;

		// Token: 0x04030DC5 RID: 200133
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200928B RID: 37515
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetClimbState_FunctionParams
	{
		// Token: 0x04030DC6 RID: 200134
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DC7 RID: 200135
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DC8 RID: 200136
		[FieldOffset(16)]
		public AkiClient.Game.Aki.Character.BaseCharacter.SClimbState __Result;
	}

	// Token: 0x0200928C RID: 37516
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetClimbRadius_FunctionParams
	{
		// Token: 0x04030DC9 RID: 200137
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DCA RID: 200138
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DCB RID: 200139
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200928D RID: 37517
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __GetClimbInfo_FunctionParams
	{
		// Token: 0x04030DCC RID: 200140
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DCD RID: 200141
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DCE RID: 200142
		[FieldOffset(16)]
		public AkiClient.Game.Aki.Character.BaseCharacter.SClimbInfo __Result;
	}

	// Token: 0x0200928E RID: 37518
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __KickExitCheck_FunctionParams
	{
		// Token: 0x04030DCF RID: 200143
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DD0 RID: 200144
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200928F RID: 37519
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CanClimbPress_FunctionParams
	{
		// Token: 0x04030DD1 RID: 200145
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DD2 RID: 200146
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DD3 RID: 200147
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009290 RID: 37520
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OnEnterClimb_FunctionParams
	{
		// Token: 0x04030DD4 RID: 200148
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DD5 RID: 200149
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009291 RID: 37521
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __OnExitClimb_FunctionParams
	{
		// Token: 0x04030DD6 RID: 200150
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DD7 RID: 200151
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009292 RID: 37522
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DealClimbUpStart_FunctionParams
	{
		// Token: 0x04030DD8 RID: 200152
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DD9 RID: 200153
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009293 RID: 37523
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __FinishClimbDown_FunctionParams
	{
		// Token: 0x04030DDA RID: 200154
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DDB RID: 200155
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009294 RID: 37524
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DealClimbUpFinish_FunctionParams
	{
		// Token: 0x04030DDC RID: 200156
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DDD RID: 200157
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009295 RID: 37525
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetClimbState_FunctionParams
	{
		// Token: 0x04030DDE RID: 200158
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DDF RID: 200159
		[FieldOffset(4)]
		public byte climbState;

		// Token: 0x04030DE0 RID: 200160
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009296 RID: 37526
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetEnterClimbType_FunctionParams
	{
		// Token: 0x04030DE1 RID: 200161
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DE2 RID: 200162
		[FieldOffset(4)]
		public byte enterType;

		// Token: 0x04030DE3 RID: 200163
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009297 RID: 37527
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetExitClimbType_FunctionParams
	{
		// Token: 0x04030DE4 RID: 200164
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DE5 RID: 200165
		[FieldOffset(4)]
		public byte exitType;

		// Token: 0x04030DE6 RID: 200166
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009298 RID: 37528
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetSwimLocation_FunctionParams
	{
		// Token: 0x04030DE7 RID: 200167
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DE8 RID: 200168
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DE9 RID: 200169
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x02009299 RID: 37529
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetWaterLocation_FunctionParams
	{
		// Token: 0x04030DEA RID: 200170
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DEB RID: 200171
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DEC RID: 200172
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x0200929A RID: 37530
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetWaterVolume_FunctionParams
	{
		// Token: 0x04030DED RID: 200173
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DEE RID: 200174
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DEF RID: 200175
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200929B RID: 37531
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetClimbOnWallAngle_FunctionParams
	{
		// Token: 0x04030DF0 RID: 200176
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DF1 RID: 200177
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DF2 RID: 200178
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x0200929C RID: 37532
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetUseDebugMovementSetting_FunctionParams
	{
		// Token: 0x04030DF3 RID: 200179
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DF4 RID: 200180
		[FieldOffset(4)]
		public bool newSelect;

		// Token: 0x04030DF5 RID: 200181
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200929D RID: 37533
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 112)]
	protected ref struct __SetDebugMovementSetting_FunctionParams
	{
		// Token: 0x04030DF6 RID: 200182
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DF7 RID: 200183
		[FieldOffset(8)]
		public byte newSetting;

		// Token: 0x04030DF8 RID: 200184
		[FieldOffset(104)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200929E RID: 37534
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetLockedRotation_FunctionParams
	{
		// Token: 0x04030DF9 RID: 200185
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DFA RID: 200186
		[FieldOffset(4)]
		public bool lockedRotation;

		// Token: 0x04030DFB RID: 200187
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200929F RID: 37535
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetLockedRotation_FunctionParams
	{
		// Token: 0x04030DFC RID: 200188
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030DFD RID: 200189
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030DFE RID: 200190
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020092A0 RID: 37536
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetFallingHorizontalMaxSpeed_FunctionParams
	{
		// Token: 0x04030DFF RID: 200191
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E00 RID: 200192
		[FieldOffset(4)]
		public float speed;

		// Token: 0x04030E01 RID: 200193
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092A1 RID: 37537
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __ClearFallingHorizontalMaxSpeed_FunctionParams
	{
		// Token: 0x04030E02 RID: 200194
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E03 RID: 200195
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092A2 RID: 37538
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 48)]
	protected ref struct __DetectClimbWithDirect_FunctionParams
	{
		// Token: 0x04030E04 RID: 200196
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E05 RID: 200197
		[FieldOffset(4)]
		public bool bSprintEnter;

		// Token: 0x04030E06 RID: 200198
		[FieldOffset(8)]
		public FVectorDouble direct;

		// Token: 0x04030E07 RID: 200199
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04030E08 RID: 200200
		[FieldOffset(40)]
		public bool __Result;
	}

	// Token: 0x020092A3 RID: 37539
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __TurnToTarget_FunctionParams
	{
		// Token: 0x04030E09 RID: 200201
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E0A RID: 200202
		[FieldOffset(8)]
		public IntPtr target;

		// Token: 0x04030E0B RID: 200203
		[FieldOffset(16)]
		public float speed;

		// Token: 0x04030E0C RID: 200204
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092A4 RID: 37540
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetMonsterMoveDirection_FunctionParams
	{
		// Token: 0x04030E0D RID: 200205
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E0E RID: 200206
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E0F RID: 200207
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020092A5 RID: 37541
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetRoleBody_FunctionParams
	{
		// Token: 0x04030E10 RID: 200208
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E11 RID: 200209
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E12 RID: 200210
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x020092A6 RID: 37542
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetRacingRightSpeed_FunctionParams
	{
		// Token: 0x04030E13 RID: 200211
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E14 RID: 200212
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E15 RID: 200213
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020092A7 RID: 37543
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __SetPendulumData_FunctionParams
	{
		// Token: 0x04030E16 RID: 200214
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E17 RID: 200215
		[FieldOffset(4)]
		public float addVelocityX;

		// Token: 0x04030E18 RID: 200216
		[FieldOffset(8)]
		public float addVelocityY;

		// Token: 0x04030E19 RID: 200217
		[FieldOffset(12)]
		public float addVelocityZ;

		// Token: 0x04030E1A RID: 200218
		[FieldOffset(16)]
		public float forwardLossPercentage;

		// Token: 0x04030E1B RID: 200219
		[FieldOffset(20)]
		public float lossPercentage;

		// Token: 0x04030E1C RID: 200220
		[FieldOffset(24)]
		public float gravity;

		// Token: 0x04030E1D RID: 200221
		[FieldOffset(28)]
		public float friction;

		// Token: 0x04030E1E RID: 200222
		[FieldOffset(32)]
		public float deceleration;

		// Token: 0x04030E1F RID: 200223
		[FieldOffset(36)]
		public float accelerator;

		// Token: 0x04030E20 RID: 200224
		[FieldOffset(40)]
		public float maxSpeed;

		// Token: 0x04030E21 RID: 200225
		[FieldOffset(44)]
		public float maxFallingSpeed;

		// Token: 0x04030E22 RID: 200226
		[FieldOffset(48)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092A8 RID: 37544
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __Reset_FunctionParams
	{
		// Token: 0x04030E23 RID: 200227
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E24 RID: 200228
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092A9 RID: 37545
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetGrabPoint_FunctionParams
	{
		// Token: 0x04030E25 RID: 200229
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E26 RID: 200230
		[FieldOffset(8)]
		public FVectorDouble point;

		// Token: 0x04030E27 RID: 200231
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092AA RID: 37546
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetGrabPoint_FunctionParams
	{
		// Token: 0x04030E28 RID: 200232
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E29 RID: 200233
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E2A RID: 200234
		[FieldOffset(16)]
		public FVectorDouble __Result;
	}

	// Token: 0x020092AB RID: 37547
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetHooked_FunctionParams
	{
		// Token: 0x04030E2B RID: 200235
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E2C RID: 200236
		[FieldOffset(4)]
		public bool isHooked;

		// Token: 0x04030E2D RID: 200237
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092AC RID: 37548
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetHooked_FunctionParams
	{
		// Token: 0x04030E2E RID: 200238
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E2F RID: 200239
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E30 RID: 200240
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020092AD RID: 37549
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __SetSocketName_FunctionParams
	{
		// Token: 0x04030E31 RID: 200241
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E32 RID: 200242
		[FieldOffset(8)]
		public FString socketName;

		// Token: 0x04030E33 RID: 200243
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092AE RID: 37550
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetRopeForce_FunctionParams
	{
		// Token: 0x04030E34 RID: 200244
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E35 RID: 200245
		[FieldOffset(4)]
		public float ropeForce;

		// Token: 0x04030E36 RID: 200246
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092AF RID: 37551
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetRopeForce_FunctionParams
	{
		// Token: 0x04030E37 RID: 200247
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E38 RID: 200248
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E39 RID: 200249
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020092B0 RID: 37552
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetDistanceRopeToActor_FunctionParams
	{
		// Token: 0x04030E3A RID: 200250
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E3B RID: 200251
		[FieldOffset(4)]
		public float ropeForce;

		// Token: 0x04030E3C RID: 200252
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092B1 RID: 37553
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetDistanceRopeToActor_FunctionParams
	{
		// Token: 0x04030E3D RID: 200253
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E3E RID: 200254
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E3F RID: 200255
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020092B2 RID: 37554
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetAirControl_FunctionParams
	{
		// Token: 0x04030E40 RID: 200256
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E41 RID: 200257
		[FieldOffset(4)]
		public float airControl;

		// Token: 0x04030E42 RID: 200258
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092B3 RID: 37555
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAirControl_FunctionParams
	{
		// Token: 0x04030E43 RID: 200259
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E44 RID: 200260
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E45 RID: 200261
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020092B4 RID: 37556
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetUpLength_FunctionParams
	{
		// Token: 0x04030E46 RID: 200262
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E47 RID: 200263
		[FieldOffset(4)]
		public float length;

		// Token: 0x04030E48 RID: 200264
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092B5 RID: 37557
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetCanMoveFromInput_FunctionParams
	{
		// Token: 0x04030E49 RID: 200265
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E4A RID: 200266
		[FieldOffset(4)]
		public bool canMove;

		// Token: 0x04030E4B RID: 200267
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092B6 RID: 37558
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoMove_FunctionParams
	{
		// Token: 0x04030E4C RID: 200268
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E4D RID: 200269
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030E4E RID: 200270
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092B7 RID: 37559
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoMoveMonster_FunctionParams
	{
		// Token: 0x04030E4F RID: 200271
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E50 RID: 200272
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030E51 RID: 200273
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092B8 RID: 37560
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __UpdateAnimInfoMoveRoleNpc_FunctionParams
	{
		// Token: 0x04030E52 RID: 200274
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E53 RID: 200275
		[FieldOffset(8)]
		public IntPtr animLogicParams;

		// Token: 0x04030E54 RID: 200276
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092B9 RID: 37561
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __TurnOnAutomaticFlightMode_FunctionParams
	{
		// Token: 0x04030E55 RID: 200277
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E56 RID: 200278
		[FieldOffset(8)]
		public IntPtr dataAsset;

		// Token: 0x04030E57 RID: 200279
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092BA RID: 37562
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __TurnOffAutomaticFlightMode_FunctionParams
	{
		// Token: 0x04030E58 RID: 200280
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E59 RID: 200281
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092BB RID: 37563
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __TurnOnCameraDrivenAutoFlightMode_FunctionParams
	{
		// Token: 0x04030E5A RID: 200282
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E5B RID: 200283
		[FieldOffset(8)]
		public IntPtr dataAsset;

		// Token: 0x04030E5C RID: 200284
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092BC RID: 37564
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __TurnOffCameraDrivenAutoFlightMode_FunctionParams
	{
		// Token: 0x04030E5D RID: 200285
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E5E RID: 200286
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092BD RID: 37565
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 72)]
	protected ref struct __SimpleSwim_FunctionParams
	{
		// Token: 0x04030E5F RID: 200287
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E60 RID: 200288
		[FieldOffset(4)]
		public float deltaSeconds;

		// Token: 0x04030E61 RID: 200289
		[FieldOffset(8)]
		public float detectedHeight;

		// Token: 0x04030E62 RID: 200290
		[FieldOffset(16)]
		public FVectorDouble currentSpeed;

		// Token: 0x04030E63 RID: 200291
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04030E64 RID: 200292
		[FieldOffset(48)]
		public FVectorDouble __Result;
	}

	// Token: 0x020092BE RID: 37566
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __EnterRoll_FunctionParams
	{
		// Token: 0x04030E65 RID: 200293
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E66 RID: 200294
		[FieldOffset(4)]
		public float targetSpeed;

		// Token: 0x04030E67 RID: 200295
		[FieldOffset(8)]
		public float friction;

		// Token: 0x04030E68 RID: 200296
		[FieldOffset(12)]
		public float accelOnGround;

		// Token: 0x04030E69 RID: 200297
		[FieldOffset(16)]
		public float gravity;

		// Token: 0x04030E6A RID: 200298
		[FieldOffset(20)]
		public float stepUpHeight;

		// Token: 0x04030E6B RID: 200299
		[FieldOffset(24)]
		public float maxSpeed;

		// Token: 0x04030E6C RID: 200300
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092BF RID: 37567
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LeaveRoll_FunctionParams
	{
		// Token: 0x04030E6D RID: 200301
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E6E RID: 200302
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092C0 RID: 37568
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __EnterKite_FunctionParams
	{
		// Token: 0x04030E6F RID: 200303
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E70 RID: 200304
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030E71 RID: 200305
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020092C1 RID: 37569
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __LerpVelocityBlend_FunctionParams
	{
		// Token: 0x04030E72 RID: 200306
		[FieldOffset(0)]
		public FVeloctiyBlend outVeloctiyBlend;

		// Token: 0x04030E73 RID: 200307
		[FieldOffset(16)]
		public FVeloctiyBlend to;

		// Token: 0x04030E74 RID: 200308
		[FieldOffset(32)]
		public float alpha;

		// Token: 0x04030E75 RID: 200309
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04030E76 RID: 200310
		[FieldOffset(48)]
		public FVeloctiyBlend __Result;
	}

	// Token: 0x020092C2 RID: 37570
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __MoveCharacter_FunctionParams
	{
		// Token: 0x04030E77 RID: 200311
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E78 RID: 200312
		[FieldOffset(8)]
		public FVectorDouble targetLocation;

		// Token: 0x04030E79 RID: 200313
		[FieldOffset(32)]
		public float speed;

		// Token: 0x04030E7A RID: 200314
		[FieldOffset(36)]
		public int arriveDist;

		// Token: 0x04030E7B RID: 200315
		[FieldOffset(40)]
		public IntPtr __WorldContext;

		// Token: 0x04030E7C RID: 200316
		[FieldOffset(48)]
		public bool __Result;
	}

	// Token: 0x020092C3 RID: 37571
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __StartAssistedWalk_FunctionParams
	{
		// Token: 0x04030E7D RID: 200317
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E7E RID: 200318
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092C4 RID: 37572
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnterAssistedWalkIdle_FunctionParams
	{
		// Token: 0x04030E7F RID: 200319
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E80 RID: 200320
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092C5 RID: 37573
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnterAssistedWalking_FunctionParams
	{
		// Token: 0x04030E81 RID: 200321
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E82 RID: 200322
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092C6 RID: 37574
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LeftAssistedWalking_FunctionParams
	{
		// Token: 0x04030E83 RID: 200323
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E84 RID: 200324
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092C7 RID: 37575
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LeftStartSwing_FunctionParams
	{
		// Token: 0x04030E85 RID: 200325
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E86 RID: 200326
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092C8 RID: 37576
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LeftLoopSwing_FunctionParams
	{
		// Token: 0x04030E87 RID: 200327
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E88 RID: 200328
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092C9 RID: 37577
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __LeftEndSwing_FunctionParams
	{
		// Token: 0x04030E89 RID: 200329
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E8A RID: 200330
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092CA RID: 37578
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __ResetClimbConfig_FunctionParams
	{
		// Token: 0x04030E8B RID: 200331
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E8C RID: 200332
		[FieldOffset(8)]
		public FString key;

		// Token: 0x04030E8D RID: 200333
		[FieldOffset(24)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092CB RID: 37579
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __EnableGoThrough_FunctionParams
	{
		// Token: 0x04030E8E RID: 200334
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E8F RID: 200335
		[FieldOffset(4)]
		public int goThroughPriority;

		// Token: 0x04030E90 RID: 200336
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020092CC RID: 37580
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DisableGoThrough_FunctionParams
	{
		// Token: 0x04030E91 RID: 200337
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04030E92 RID: 200338
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}
}
