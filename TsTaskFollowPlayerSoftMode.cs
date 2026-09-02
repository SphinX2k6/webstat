using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB9 RID: 3257
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowPlayerSoftMode.TsTaskFollowPlayerSoftMode_C")]
public class TsTaskFollowPlayerSoftMode : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000245 RID: 581
	// (get) Token: 0x06003E0A RID: 15882 RVA: 0x0005ACB0 File Offset: 0x00058EB0
	// (set) Token: 0x06003E0B RID: 15883 RVA: 0x0005ACE9 File Offset: 0x00058EE9
	[UProperty(EPropertyFlags.CPF_None)]
	public SFollowMoveInfo MoveInfo
	{
		get
		{
			base.FastCheckIsValid();
			SFollowMoveInfo result;
			if ((result = this._MoveInfo) == null)
			{
				result = (this._MoveInfo = new SFollowMoveInfo(base.NativePtr + (IntPtr)TsTaskFollowPlayerSoftMode.__PropertyOffset_MoveInfo, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SFollowMoveInfo.StaticStruct(), base.NativePtr + (IntPtr)TsTaskFollowPlayerSoftMode.__PropertyOffset_MoveInfo, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17000246 RID: 582
	// (get) Token: 0x06003E0C RID: 15884 RVA: 0x0005AD14 File Offset: 0x00058F14
	// (set) Token: 0x06003E0D RID: 15885 RVA: 0x0005AD4D File Offset: 0x00058F4D
	[UProperty(EPropertyFlags.CPF_None)]
	public SFollowRotateInfo RotateInfo
	{
		get
		{
			base.FastCheckIsValid();
			SFollowRotateInfo result;
			if ((result = this._RotateInfo) == null)
			{
				result = (this._RotateInfo = new SFollowRotateInfo(base.NativePtr + (IntPtr)TsTaskFollowPlayerSoftMode.__PropertyOffset_RotateInfo, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(SFollowRotateInfo.StaticStruct(), base.NativePtr + (IntPtr)TsTaskFollowPlayerSoftMode.__PropertyOffset_RotateInfo, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06003E0E RID: 15886 RVA: 0x0005AD78 File Offset: 0x00058F78
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsOffset = Vector.Create();
			this.TempCameraForward = Vector.Create();
			this.TempTarget = Vector.Create();
			this.TempDirect = Vector.Create();
			this.TempVector = Vector.Create();
			this.TempDirection = Vector.Create();
			this.TempRotator = Rotator.Create();
			this.TempQuat = Quat.Create(0f, 0f, 0f, 1f);
			this.TempInvertRotator1 = Rotator.Create();
			this.TempInvertRotator2 = Rotator.Create();
			if (this.MoveInfo != null)
			{
				this.TsFollowTargetType = this.MoveInfo.FollowTargetType;
				this.TsMoveEntityIdBlackboardKey = this.MoveInfo.EntityIdBlackboardKey;
				this.TsKeepDistanceMin = this.MoveInfo.KeepDistanceMin;
				this.TsDistanceMin = (float)this.MoveInfo.DistanceMin;
				this.TsDistanceMaxSpeed = (float)this.MoveInfo.DistanceMaxSpeed;
				this.TsDistanceSweepMove = (float)this.MoveInfo.DistanceMax;
				this.TsDistanceForceMove = (float)this.MoveInfo.DistanceForceMove;
				this.TsMaxMoveSpeed = (float)this.MoveInfo.MaxMoveSpeed;
				Vector tsOffset = this.TsOffset;
				FVector offset = this.MoveInfo.Offset;
				tsOffset.FromUeVector(offset);
				if (this.TsDistanceMaxSpeed <= this.TsDistanceMin)
				{
					this.TsDistanceMaxSpeed = this.TsDistanceSweepMove;
				}
			}
			else
			{
				this.TsFollowTargetType = EFollowTargetType.玩家当前控制角色;
				this.TsMoveEntityIdBlackboardKey = "";
				this.TsKeepDistanceMin = true;
				this.TsDistanceMin = 100f;
				this.TsDistanceMaxSpeed = 200f;
				this.TsDistanceSweepMove = 200f;
				this.TsDistanceForceMove = 300f;
				this.TsMaxMoveSpeed = 200f;
				this.TsOffset.Set(0.0, 0.0, 0.0);
			}
			this.TsMinSquared = this.TsDistanceMin * this.TsDistanceMin;
			this.TsSweepMoveSquared = this.TsDistanceSweepMove * this.TsDistanceSweepMove;
			if (this.RotateInfo != null)
			{
				this.TsRotateSpeed = (float)this.RotateInfo.RotateSpeed;
				this.TsRotateType = this.RotateInfo.RotateType;
				this.TsCameraDistance = (float)this.RotateInfo.CameraDistance;
				this.TsRotateEntityIdBlackboardKey = this.RotateInfo.EntityIdBlackboardKey;
				TArray<TEnumAsByte<ECommonAxis>> notSyncAxisList = this.RotateInfo.NotSyncAxisList;
				this.TsNotSyncAxisList = new List<ECommonAxis>();
				for (int i = 0; i < notSyncAxisList.Num(); i++)
				{
					this.TsNotSyncAxisList.Add(notSyncAxisList.Get(i));
				}
				return;
			}
			this.TsRotateSpeed = 2000f;
			this.TsRotateType = EFollowRotateType.朝向镜头前一定距离;
			this.TsCameraDistance = 1500f;
			this.TsRotateEntityIdBlackboardKey = "";
		}
	}

	// Token: 0x06003E0F RID: 15887 RVA: 0x0005B05C File Offset: 0x0005925C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003E10 RID: 15888 RVA: 0x0005B0F8 File Offset: 0x000592F8
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables();
		CharacterActorComponent charActorComp2 = aiController.CharActorComp;
		BaseMoveComponent moveComp;
		if (charActorComp2 == null)
		{
			moveComp = null;
		}
		else
		{
			Entity entity = charActorComp2.Entity;
			moveComp = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
		}
		this.MoveComp = moveComp;
		CharacterActorComponent charActorComp3 = aiController.CharActorComp;
		if (charActorComp3 != null)
		{
			charActorComp3.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Flying,
				Context = "[TsTaskFollowPlayerSoftMode.ReceiveExecuteAI]"
			});
		}
		if (this.TraceElement == null)
		{
			this.TraceElement = new UTraceCapsuleElement();
			this.TraceElement.bIsSingle = true;
			this.TraceElement.bIgnoreSelf = true;
			this.TraceElement.WorldContextObject = charActorComp.Owner;
			this.TraceElement.HalfHeight = charActorComp.DefaultHalfHeight;
			this.TraceElement.Radius = charActorComp.DefaultRadius;
			this.TraceElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
			this.TraceElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
		}
	}

	// Token: 0x06003E11 RID: 15889 RVA: 0x0005B24C File Offset: 0x0005944C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003E12 RID: 15890 RVA: 0x0005B2EC File Offset: 0x000594EC
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		if (this.MoveComp != null && this.MoveComp.CharacterMovement.MovementMode != EMovementMode.MOVE_Flying)
		{
			charActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Flying,
				Context = "[TsTaskFollowPlayerSoftMode.ReceiveTickAI]"
			});
		}
		BaseActorComponent baseActorComponent = null;
		switch (this.TsFollowTargetType)
		{
		case EFollowTargetType.玩家当前控制角色:
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			baseActorComponent = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			break;
		}
		case EFollowTargetType.伴生物召唤者:
		{
			CreatureDataComponent component = charActorComp.Entity.GetComponent<CreatureDataComponent>();
			long? num = (component != null) ? new long?(component.GetSummonerId()) : null;
			if (num != null)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num.Value);
				BaseActorComponent baseActorComponent2;
				if (entity == null)
				{
					baseActorComponent2 = null;
				}
				else
				{
					WorldEntity entity2 = entity.Entity;
					baseActorComponent2 = ((entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null);
				}
				baseActorComponent = baseActorComponent2;
			}
			break;
		}
		case EFollowTargetType.指定实体:
			if (this.TsMoveEntityIdBlackboardKey != "")
			{
				int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(charActorComp.Entity.Id, this.TsRotateEntityIdBlackboardKey);
				if (entityIdByEntity != null)
				{
					Entity entity3 = Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value);
					baseActorComponent = ((entity3 != null) ? entity3.GetComponent<BaseActorComponent>() : null);
				}
			}
			break;
		case EFollowTargetType.玩家当前载具:
		{
			TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
			CharacterDriveVehicleComponent characterDriveVehicleComponent;
			if (baseCharacter2 == null)
			{
				characterDriveVehicleComponent = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter2.CharacterActorComponent;
				characterDriveVehicleComponent = ((characterActorComponent != null) ? characterActorComponent.Entity.CheckGetComponent<CharacterDriveVehicleComponent>() : null);
			}
			CharacterDriveVehicleComponent characterDriveVehicleComponent2 = characterDriveVehicleComponent;
			if (characterDriveVehicleComponent2 != null)
			{
				Entity vehicleEntity = characterDriveVehicleComponent2.VehicleEntity;
				if (vehicleEntity != null && vehicleEntity.Valid)
				{
					Entity vehicleEntity2 = characterDriveVehicleComponent2.VehicleEntity;
					baseActorComponent = ((vehicleEntity2 != null) ? vehicleEntity2.GetComponent<BaseActorComponent>() : null);
				}
			}
			break;
		}
		}
		if (baseActorComponent == null || !baseActorComponent.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		float num2 = deltaSeconds * charActorComp.Actor.CustomTimeDilation;
		this.UpdateRotate(charActorComp, num2);
		Vector actorLocationProxy = baseActorComponent.ActorLocationProxy;
		Vector actorLocationProxy2 = charActorComp.ActorLocationProxy;
		this.TempTarget.DeepCopy(actorLocationProxy);
		FTransformDouble actorTransform = baseActorComponent.ActorTransform;
		FVectorDouble fvectorDouble = this.TsOffset.ToUeVector(false);
		FVectorDouble fvectorDouble2 = actorTransform.TransformVector(fvectorDouble);
		this.TempVector.FromUeVector(fvectorDouble2);
		this.TempTarget.AdditionEqual(this.TempVector);
		this.TempTarget.Subtraction(actorLocationProxy2, this.TempVector);
		double num3 = this.TempVector.SizeSquared();
		if (!this.TsKeepDistanceMin && num3 < (double)this.TsMinSquared)
		{
			double num4 = this.TempTarget.Z - actorLocationProxy2.Z;
			if (Math.Abs(num4) >= 10.0)
			{
				this.TempVector.Set(0.0, 0.0, num4);
				this.LerpMove(this.TempVector, num2);
			}
			return;
		}
		actorLocationProxy2.Subtraction(this.TempTarget, this.TempVector);
		Vector.VectorPlaneProject(this.TempVector, baseActorComponent.ActorUpProxy, this.TempDirection);
		this.TempDirection.Normalize(9.99999993922529E-09);
		this.TempDirection.MultiplyEqual((double)this.TsDistanceMin);
		this.TempTarget.AdditionEqual(this.TempDirection);
		if (num3 < (double)this.TsSweepMoveSquared)
		{
			this.TempTarget.Subtraction(actorLocationProxy2, this.TempVector);
			this.LerpMove(this.TempVector, num2);
			return;
		}
		if (num3 < (double)(this.TsDistanceForceMove * this.TsDistanceForceMove))
		{
			charActorComp.SetActorLocation(this.TempTarget.ToUeVector(false), "FollowPlayerSoftMode", true);
			return;
		}
		if (!this.CheckObstacle(this.TempTarget, this.TempTarget))
		{
			charActorComp.SetActorLocation(this.TempTarget.ToUeVector(false), "FollowPlayerSoftMode", false);
			return;
		}
		float num5 = charActorComp.DefaultRadius * 2f;
		this.TempTarget.Subtraction(actorLocationProxy2, this.TempVector);
		double num6 = this.TempVector.Size();
		num6 -= (double)num5;
		if (num6 <= 0.0)
		{
			return;
		}
		this.TempVector.Normalize(9.99999993922529E-09);
		this.TempVector.MultiplyEqual(num6);
		actorLocationProxy2.Addition(this.TempVector, this.TempTarget);
		if (!this.CheckObstacle(this.TempTarget, this.TempTarget))
		{
			charActorComp.SetActorLocation(this.TempTarget.ToUeVector(false), "FollowPlayerSoftMode", false);
		}
	}

	// Token: 0x06003E13 RID: 15891 RVA: 0x0005B7AC File Offset: 0x000599AC
	private bool CheckObstacle(Vector startLocation, Vector endLocation)
	{
		if (this.TraceElement == null)
		{
			return false;
		}
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, startLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, endLocation);
		if (Singleton<TraceElementCommon>.Instance.CapsuleTrace(this.TraceElement, "FollowPlayerHardMode"))
		{
			UKuroHitResult hitResult = this.TraceElement.HitResult;
			return hitResult != null && hitResult.bBlockingHit;
		}
		return false;
	}

	// Token: 0x06003E14 RID: 15892 RVA: 0x0005B814 File Offset: 0x00059A14
	private void LerpMove(Vector moveVector, float scaledDeltaSeconds)
	{
		float num = this.TsDistanceMaxSpeed - this.TsDistanceMin;
		if (num < 0f)
		{
			return;
		}
		double num2 = moveVector.Size();
		double alpha = num2 / (double)num;
		double num3 = Singleton<MathUtils>.Instance.Lerp(0.0, (double)this.TsMaxMoveSpeed, alpha) * (double)scaledDeltaSeconds;
		if (num3 < num2)
		{
			moveVector.Normalize(9.99999993922529E-09);
			moveVector.MultiplyEqual(num3);
		}
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		moveComp.MoveCharacter(moveVector, 1f, "FollowPlayerSoftMode");
	}

	// Token: 0x06003E15 RID: 15893 RVA: 0x0005B89C File Offset: 0x00059A9C
	private void UpdateRotate(CharacterActorComponent selfActorComp, float deltaSeconds)
	{
		if (this.MoveComp == null)
		{
			return;
		}
		Entity entity = selfActorComp.Entity;
		Entity entity2 = null;
		switch (this.TsRotateType)
		{
		case EFollowRotateType.朝向指定实体:
		case EFollowRotateType.同步指定实体:
			if (this.TsRotateEntityIdBlackboardKey != "")
			{
				int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(entity.Id, this.TsRotateEntityIdBlackboardKey);
				if (entityIdByEntity != null)
				{
					entity2 = Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value);
				}
			}
			break;
		case EFollowRotateType.朝向自身技能目标:
		{
			CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
			Entity entity3;
			if (component == null)
			{
				entity3 = null;
			}
			else
			{
				EntityHandle skillTarget = component.SkillTarget;
				entity3 = ((skillTarget != null) ? skillTarget.Entity : null);
			}
			entity2 = entity3;
			break;
		}
		}
		BaseActorComponent baseActorComponent = null;
		if (entity2 != null && entity2.Valid)
		{
			baseActorComponent = entity2.GetComponent<BaseActorComponent>();
		}
		if (baseActorComponent != null && this.TsRotateType == EFollowRotateType.同步指定实体)
		{
			this.TempRotator.DeepCopy(baseActorComponent.ActorRotationProxy);
		}
		else
		{
			if (baseActorComponent != null)
			{
				this.TempTarget.DeepCopy(baseActorComponent.ActorLocationProxy);
			}
			else
			{
				Vector tempTarget = this.TempTarget;
				FVectorDouble fvectorDouble = Global.CharacterCameraManager.D_GetCameraLocation();
				tempTarget.FromUeVector(fvectorDouble);
				Vector tempCameraForward = this.TempCameraForward;
				FVector actorForwardVector = Global.CharacterCameraManager.GetActorForwardVector();
				tempCameraForward.FromUeVector(actorForwardVector);
				this.TempTarget.AdditionEqual(this.TempCameraForward.MultiplyEqual((double)this.TsCameraDistance));
			}
			this.TempDirect.DeepCopy(this.TempTarget);
			this.TempDirect.Subtraction(selfActorComp.ActorLocationProxy, this.TempDirect);
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempDirect, this.MoveComp.GravityUp, this.TempRotator);
		}
		if (this.TsNotSyncAxisList.Count <= 0)
		{
			this.MoveComp.SmoothCharacterRotation(this.TempRotator, this.TsRotateSpeed, deltaSeconds, false, "FollowPlayerSoftMode", true);
			return;
		}
		bool isStandardGravity = this.MoveComp.IsStandardGravity;
		if (isStandardGravity)
		{
			this.TempInvertRotator1.DeepCopy(this.TempRotator);
			this.TempInvertRotator2.DeepCopy(selfActorComp.ActorRotationProxy);
		}
		else
		{
			Quat.FindBetween(Vector.UpVectorProxy, this.MoveComp.GravityUp, this.TempQuat);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TempRotator, this.TempQuat, this.TempInvertRotator1);
			Singleton<GravityUtils>.Instance.GetRotatorInNormal(selfActorComp.ActorRotationProxy, this.TempQuat, this.TempInvertRotator2);
		}
		foreach (ECommonAxis ecommonAxis in this.TsNotSyncAxisList)
		{
			if (ecommonAxis == ECommonAxis.X)
			{
				this.TempInvertRotator1.Roll = this.TempInvertRotator2.Roll;
			}
			else if (ecommonAxis == ECommonAxis.Y)
			{
				this.TempInvertRotator1.Pitch = this.TempInvertRotator2.Pitch;
			}
			else if (ecommonAxis == ECommonAxis.Z)
			{
				this.TempInvertRotator1.Yaw = this.TempInvertRotator2.Yaw;
			}
		}
		if (isStandardGravity)
		{
			this.TempRotator.DeepCopy(this.TempInvertRotator1);
		}
		else
		{
			this.TempQuat.Inverse(this.TempQuat);
			Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TempInvertRotator1, this.TempQuat, this.TempRotator);
		}
		this.MoveComp.SmoothCharacterRotation(this.TempRotator, this.TsRotateSpeed, deltaSeconds, false, "FollowPlayerSoftMode", true);
	}

	// Token: 0x06003E16 RID: 15894 RVA: 0x0005BBD8 File Offset: 0x00059DD8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFollowPlayerSoftMode._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowPlayerSoftMode.TsTaskFollowPlayerSoftMode_C");
		}
		return TsTaskFollowPlayerSoftMode._ClassPtr;
	}

	// Token: 0x06003E17 RID: 15895 RVA: 0x0005BBFC File Offset: 0x00059DFC
	public TsTaskFollowPlayerSoftMode() : this(BuiltinUtils.AllocNativeUObject(TsTaskFollowPlayerSoftMode.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003E18 RID: 15896 RVA: 0x0005BC24 File Offset: 0x00059E24
	public TsTaskFollowPlayerSoftMode(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFollowPlayerSoftMode.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003E19 RID: 15897 RVA: 0x0005BC58 File Offset: 0x00059E58
	protected TsTaskFollowPlayerSoftMode(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003E1A RID: 15898 RVA: 0x0005BD18 File Offset: 0x00059F18
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003E1B RID: 15899 RVA: 0x0005BD48 File Offset: 0x00059F48
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000CF4 RID: 3316
	private const float START_MOVE_HEIGHT_LIMIT = 10f;

	// Token: 0x04000CF5 RID: 3317
	private EFollowTargetType TsFollowTargetType;

	// Token: 0x04000CF6 RID: 3318
	private string TsMoveEntityIdBlackboardKey = "";

	// Token: 0x04000CF7 RID: 3319
	private bool TsKeepDistanceMin = true;

	// Token: 0x04000CF8 RID: 3320
	private float TsDistanceMin;

	// Token: 0x04000CF9 RID: 3321
	private float TsMinSquared;

	// Token: 0x04000CFA RID: 3322
	private float TsDistanceMaxSpeed;

	// Token: 0x04000CFB RID: 3323
	private float TsDistanceSweepMove;

	// Token: 0x04000CFC RID: 3324
	private float TsSweepMoveSquared;

	// Token: 0x04000CFD RID: 3325
	private float TsDistanceForceMove;

	// Token: 0x04000CFE RID: 3326
	private float TsMaxMoveSpeed;

	// Token: 0x04000CFF RID: 3327
	private Vector TsOffset = Vector.Create();

	// Token: 0x04000D00 RID: 3328
	private float TsRotateSpeed;

	// Token: 0x04000D01 RID: 3329
	private EFollowRotateType TsRotateType;

	// Token: 0x04000D02 RID: 3330
	private string TsRotateEntityIdBlackboardKey = "";

	// Token: 0x04000D03 RID: 3331
	private float TsCameraDistance;

	// Token: 0x04000D04 RID: 3332
	private List<ECommonAxis> TsNotSyncAxisList = new List<ECommonAxis>();

	// Token: 0x04000D05 RID: 3333
	private bool IsInitTsVariables;

	// Token: 0x04000D06 RID: 3334
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x04000D07 RID: 3335
	[Nullable(2)]
	private UTraceCapsuleElement TraceElement;

	// Token: 0x04000D08 RID: 3336
	private Vector TempCameraForward = Vector.Create();

	// Token: 0x04000D09 RID: 3337
	private Vector TempTarget = Vector.Create();

	// Token: 0x04000D0A RID: 3338
	private Vector TempDirect = Vector.Create();

	// Token: 0x04000D0B RID: 3339
	private Vector TempVector = Vector.Create();

	// Token: 0x04000D0C RID: 3340
	private Vector TempDirection = Vector.Create();

	// Token: 0x04000D0D RID: 3341
	private Rotator TempRotator = Rotator.Create();

	// Token: 0x04000D0E RID: 3342
	private Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000D0F RID: 3343
	private Rotator TempInvertRotator1 = Rotator.Create();

	// Token: 0x04000D10 RID: 3344
	private Rotator TempInvertRotator2 = Rotator.Create();

	// Token: 0x04000D11 RID: 3345
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowPlayerSoftMode.TsTaskFollowPlayerSoftMode_C";

	// Token: 0x04000D12 RID: 3346
	private static IntPtr _ClassPtr;

	// Token: 0x04000D13 RID: 3347
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000D14 RID: 3348
	private static int __PropertyOffset_MoveInfo;

	// Token: 0x04000D15 RID: 3349
	[Nullable(2)]
	private SFollowMoveInfo _MoveInfo;

	// Token: 0x04000D16 RID: 3350
	private static int __PropertyOffset_RotateInfo;

	// Token: 0x04000D17 RID: 3351
	[Nullable(2)]
	private SFollowRotateInfo _RotateInfo;
}
