using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB1 RID: 3249
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindInteractionStandPoint.TsTaskFindInteractionStandPoint_C")]
public class TsTaskFindInteractionStandPoint : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000216 RID: 534
	// (get) Token: 0x06003D55 RID: 15701 RVA: 0x00056AC1 File Offset: 0x00054CC1
	// (set) Token: 0x06003D56 RID: 15702 RVA: 0x00056AD1 File Offset: 0x00054CD1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CheckObstacle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_CheckObstacle) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_CheckObstacle) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x06003D57 RID: 15703 RVA: 0x00056AE2 File Offset: 0x00054CE2
	// (set) Token: 0x06003D58 RID: 15704 RVA: 0x00056AF2 File Offset: 0x00054CF2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxHeightDiff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_MaxHeightDiff);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_MaxHeightDiff) = value;
		}
	}

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06003D59 RID: 15705 RVA: 0x00056B03 File Offset: 0x00054D03
	// (set) Token: 0x06003D5A RID: 15706 RVA: 0x00056B13 File Offset: 0x00054D13
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ObstacleHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_ObstacleHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_ObstacleHeight) = value;
		}
	}

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06003D5B RID: 15707 RVA: 0x00056B24 File Offset: 0x00054D24
	// (set) Token: 0x06003D5C RID: 15708 RVA: 0x00056B34 File Offset: 0x00054D34
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float FloorDetectRange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_FloorDetectRange);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_FloorDetectRange) = value;
		}
	}

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x06003D5D RID: 15709 RVA: 0x00056B45 File Offset: 0x00054D45
	// (set) Token: 0x06003D5E RID: 15710 RVA: 0x00056B55 File Offset: 0x00054D55
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CheckHeightDiff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_CheckHeightDiff) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_CheckHeightDiff) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x06003D5F RID: 15711 RVA: 0x00056B66 File Offset: 0x00054D66
	// (set) Token: 0x06003D60 RID: 15712 RVA: 0x00056B76 File Offset: 0x00054D76
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CapsuleRadiusScaleRate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_CapsuleRadiusScaleRate);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_CapsuleRadiusScaleRate) = value;
		}
	}

	// Token: 0x1700021C RID: 540
	// (get) Token: 0x06003D61 RID: 15713 RVA: 0x00056B87 File Offset: 0x00054D87
	// (set) Token: 0x06003D62 RID: 15714 RVA: 0x00056B9B File Offset: 0x00054D9B
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string StandPointKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_StandPointKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_StandPointKey)), value);
		}
	}

	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06003D63 RID: 15715 RVA: 0x00056BB0 File Offset: 0x00054DB0
	// (set) Token: 0x06003D64 RID: 15716 RVA: 0x00056BC4 File Offset: 0x00054DC4
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string InteractionEntityKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_InteractionEntityKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_InteractionEntityKey)), value);
		}
	}

	// Token: 0x1700021E RID: 542
	// (get) Token: 0x06003D65 RID: 15717 RVA: 0x00056BD9 File Offset: 0x00054DD9
	// (set) Token: 0x06003D66 RID: 15718 RVA: 0x00056BE9 File Offset: 0x00054DE9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_DebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFindInteractionStandPoint.__PropertyOffset_DebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003D67 RID: 15719 RVA: 0x00056BFC File Offset: 0x00054DFC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsCheckObstacle = this.CheckObstacle;
			this.TsMaxHeightDiff = this.MaxHeightDiff;
			this.TsObstacleHeight = this.ObstacleHeight;
			this.TsFloorDetectRange = this.FloorDetectRange;
			this.TsCheckHeightDiff = this.CheckHeightDiff;
			this.TsCapsuleRadiusScaleRate = this.CapsuleRadiusScaleRate;
			this.TsDebugDraw = this.DebugDraw;
			this.TsStandPointKey = this.StandPointKey;
			this.TsInteractionEntityKey = this.InteractionEntityKey;
			this.PlayerPos = Vector.Create();
			this.NpcPos = Vector.Create();
			this.SelfPos = Vector.Create();
			this.BaseVec = Vector.Create();
			this.MidPoint = Vector.Create();
			this.Perp = Vector.Create();
			this.ScaledPerp = Vector.Create();
			this.CandidateA = Vector.Create();
			this.CandidateB = Vector.Create();
			this.TargetPos = Vector.Create();
			this.FloorHit = Vector.Create();
			this.TmpStart = Vector.Create();
			this.TmpEnd = Vector.Create();
			this.Element = new UTraceSphereElement();
		}
	}

	// Token: 0x06003D68 RID: 15720 RVA: 0x00056D28 File Offset: 0x00054F28
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

	// Token: 0x06003D69 RID: 15721 RVA: 0x00056DC4 File Offset: 0x00054FC4
	protected void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		int id = aiController.CharAiDesignComp.Entity.Id;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Vector vector;
		if (baseCharacter == null)
		{
			vector = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			vector = ((characterActorComponent != null) ? characterActorComponent.FloorLocation : null);
		}
		Vector vector2 = vector;
		if (vector2 == null)
		{
			base.Finish(false);
			return;
		}
		this.PlayerPos.DeepCopy(vector2);
		if (!this.ResolveNpcAndWriteBlackboard(id))
		{
			base.Finish(false);
			return;
		}
		this.SelfPos.DeepCopy(charActorComp.ActorLocationProxy);
		if (!this.ComputeStandPoint())
		{
			base.Finish(false);
			return;
		}
		if (this.TsCheckObstacle && !this.PickStandPointWithObstacle(charActorComp))
		{
			base.Finish(false);
			return;
		}
		if (this.TsDebugDraw)
		{
			this.DrawDebugPoints(charActorComp);
		}
		this.WriteStandPoint(id, this.TargetPos);
		base.Finish(true);
	}

	// Token: 0x06003D6A RID: 15722 RVA: 0x00056EB3 File Offset: 0x000550B3
	[NullableContext(1)]
	private void WriteStandPoint(int ownerEntityId, Vector pos)
	{
		if (this.TsStandPointKey == "")
		{
			return;
		}
		ControllerBase<BlackboardController>.Instance.SetVectorValueByEntity(ownerEntityId, this.TsStandPointKey, (double)((float)pos.X), (double)((float)pos.Y), (double)((float)pos.Z));
	}

	// Token: 0x06003D6B RID: 15723 RVA: 0x00056EF4 File Offset: 0x000550F4
	[NullableContext(1)]
	private void DrawDebugPoints(CharacterActorComponent character)
	{
		UWorld world = GlobalData.World;
		float num = 30f;
		int segments = 12;
		float duration = 12f;
		UKismetSystemLibrary.D_DrawDebugSphere(world, this.PlayerPos.ToUeVector(false), num, segments, new FLinearColor?(ColorUtils.LinearYellow), duration, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(world, this.NpcPos.ToUeVector(false), num, segments, new FLinearColor?(ColorUtils.LinearYellow), duration, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(world, this.CandidateA.ToUeVector(false), num, segments, new FLinearColor?(ColorUtils.LinearGreen), duration, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(world, this.CandidateB.ToUeVector(false), num, segments, new FLinearColor?(ColorUtils.LinearBlue), duration, 0f);
		UKismetSystemLibrary.D_DrawDebugSphere(world, this.TargetPos.ToUeVector(false), num * 1.2f, segments, new FLinearColor?(ColorUtils.LinearWhite), duration, 0f);
	}

	// Token: 0x06003D6C RID: 15724 RVA: 0x00056FD0 File Offset: 0x000551D0
	private bool ResolveNpcAndWriteBlackboard(int ownerEntityId)
	{
		int? currentInteractEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
		Entity entity = (currentInteractEntityId != null) ? Singleton<EntitySystem>.Instance.Get(currentInteractEntityId.Value) : null;
		if (entity != null && entity.Valid)
		{
			this.NpcPos.DeepCopy(AiControllerLibrary.GetLocationFromEntity(entity));
			if (this.TsInteractionEntityKey != "")
			{
				ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(ownerEntityId, this.TsInteractionEntityKey, currentInteractEntityId.Value);
			}
			return true;
		}
		Vector interactPoint = ControllerBase<FlowController>.Instance.GetInteractPoint();
		if (interactPoint == null)
		{
			return false;
		}
		this.NpcPos.DeepCopy(interactPoint);
		if (this.TsInteractionEntityKey != "")
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num;
			if (baseCharacter == null)
			{
				num = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				if (characterActorComponent == null)
				{
					num = null;
				}
				else
				{
					Entity entity2 = characterActorComponent.Entity;
					num = ((entity2 != null) ? new int?(entity2.Id) : null);
				}
			}
			int? num2 = num;
			if (num2 != null)
			{
				ControllerBase<BlackboardController>.Instance.SetEntityIdByEntity(ownerEntityId, this.TsInteractionEntityKey, num2.Value);
			}
		}
		return true;
	}

	// Token: 0x06003D6D RID: 15725 RVA: 0x000570E8 File Offset: 0x000552E8
	private bool ComputeStandPoint()
	{
		this.NpcPos.Subtraction(this.PlayerPos, this.BaseVec);
		this.BaseVec.Z = 0.0;
		double num = this.BaseVec.Size2D();
		if (num < 1.0)
		{
			this.TargetPos.DeepCopy(this.PlayerPos);
			return true;
		}
		this.PlayerPos.Addition(this.NpcPos, this.MidPoint);
		this.MidPoint.DivisionEqual(2.0);
		this.Perp.Set(this.BaseVec.Y, -this.BaseVec.X, 0.0);
		this.Perp.Normalize(9.99999993922529E-09);
		double inB = 0.8660254 * num;
		this.Perp.Multiply(inB, this.ScaledPerp);
		this.MidPoint.Addition(this.ScaledPerp, this.CandidateA);
		this.MidPoint.Subtraction(this.ScaledPerp, this.CandidateB);
		this.CandidateA.Z = this.PlayerPos.Z;
		this.CandidateB.Z = this.PlayerPos.Z;
		double num2 = Vector.DistXY(this.SelfPos, this.CandidateA);
		double num3 = Vector.DistXY(this.SelfPos, this.CandidateB);
		this.TargetPos.DeepCopy((num2 <= num3) ? this.CandidateA : this.CandidateB);
		return true;
	}

	// Token: 0x06003D6E RID: 15726 RVA: 0x00057278 File Offset: 0x00055478
	[NullableContext(1)]
	private bool PickStandPointWithObstacle(CharacterActorComponent character)
	{
		UTraceSphereElement element = this.Element;
		element.WorldContextObject = character.Actor;
		element.Radius = character.ScaledRadius * this.TsCapsuleRadiusScaleRate;
		element.bIsSingle = true;
		element.bIgnoreSelf = true;
		element.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		element.ActorsToIgnore.Empty(true);
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		TsBaseCharacter tsBaseCharacter;
		if (baseCharacter == null)
		{
			tsBaseCharacter = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			tsBaseCharacter = ((characterActorComponent != null) ? characterActorComponent.Actor : null);
		}
		TsBaseCharacter tsBaseCharacter2 = tsBaseCharacter;
		if (tsBaseCharacter2 != null)
		{
			element.ActorsToIgnore.Add(tsBaseCharacter2);
		}
		foreach (AActor value in ModelBase<WorldModel>.Instance.ActorsToIgnoreSet)
		{
			element.ActorsToIgnore.Add(value);
		}
		element.SetDrawDebugTrace(this.TsDebugDraw ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
		TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
		Vector vector;
		if (baseCharacter2 == null)
		{
			vector = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent2 = baseCharacter2.CharacterActorComponent;
			vector = ((characterActorComponent2 != null) ? characterActorComponent2.FloorLocation : null);
		}
		Vector vector2 = vector;
		this.PlayerFloorZ = ((vector2 != null) ? vector2.Z : this.PlayerPos.Z);
		double num = Vector.DistXY(this.SelfPos, this.CandidateA);
		double num2 = Vector.DistXY(this.SelfPos, this.CandidateB);
		Vector vector3 = (num <= num2) ? this.CandidateA : this.CandidateB;
		Vector candidate = (vector3 == this.CandidateA) ? this.CandidateB : this.CandidateA;
		return this.TryValidatePoint(character, element, vector3, this.TargetPos) || this.TryValidatePoint(character, element, candidate, this.TargetPos);
	}

	// Token: 0x06003D6F RID: 15727 RVA: 0x00057410 File Offset: 0x00055610
	[NullableContext(1)]
	private bool TryValidatePoint(CharacterActorComponent character, UTraceSphereElement element, Vector candidate, Vector outCenter)
	{
		UCapsuleComponent capsuleComponent = character.Actor.CapsuleComponent;
		this.TmpStart.DeepCopy(candidate);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpStart, (double)(this.TsFloorDetectRange + element.Radius - 2f));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(element, this.TmpStart);
		this.TmpEnd.DeepCopy(candidate);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpEnd, (double)(-(double)this.TsFloorDetectRange + element.Radius - 2f));
		Singleton<TraceElementCommon>.Instance.SetEndLocation(element, this.TmpEnd);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(element, TsTaskFindInteractionStandPoint.TRACE_COLOR_FLOOR);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(element, TsTaskFindInteractionStandPoint.TRACE_COLOR_HIT);
		bool flag = Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, element, "TsTaskFindInteractionStandPoint", "TsTaskFindInteractionStandPoint");
		UKuroHitResult hitResult = element.HitResult;
		bool? flag2 = (hitResult != null) ? new bool?(hitResult.bStartPenetrating) : null;
		if (!flag || flag2.GetValueOrDefault())
		{
			return false;
		}
		Singleton<TraceElementCommon>.Instance.GetHitLocation(element.HitResult, 0, this.FloorHit);
		double num = Math.Abs(this.FloorHit.Z - this.PlayerFloorZ);
		if (this.TsDebugDraw)
		{
			this.TmpStart.DeepCopy(this.FloorHit);
			this.TmpEnd.DeepCopy(this.FloorHit);
			Singleton<GravityUtils>.Instance.SetZnInGravityForActor(character, this.TmpEnd, this.PlayerFloorZ);
			UKismetSystemLibrary.D_DrawDebugLine(GlobalData.World, this.TmpStart.ToUeVector(false), this.TmpEnd.ToUeVector(false), TsTaskFindInteractionStandPoint.TRACE_COLOR_HEIGHT, 12f, 3f);
		}
		if (this.TsCheckHeightDiff && num > (double)this.TsMaxHeightDiff)
		{
			return false;
		}
		this.TmpStart.DeepCopy(this.FloorHit);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpStart, (double)(this.TsObstacleHeight + 2f));
		Singleton<TraceElementCommon>.Instance.SetStartLocation(element, this.TmpStart);
		this.TmpEnd.DeepCopy(this.FloorHit);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, this.TmpEnd, 2.0);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(element, this.TmpEnd);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(element, TsTaskFindInteractionStandPoint.TRACE_COLOR_STAND);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(element, TsTaskFindInteractionStandPoint.TRACE_COLOR_HIT);
		if (Singleton<TraceElementCommon>.Instance.ShapeTrace(capsuleComponent, element, "TsTaskFindInteractionStandPoint", "TsTaskFindInteractionStandPoint"))
		{
			return false;
		}
		outCenter.Set(candidate.X, candidate.Y, this.FloorHit.Z);
		Singleton<GravityUtils>.Instance.AddZnInGravityForActor(character, outCenter, (double)(-(double)character.ScaledHalfHeight));
		return true;
	}

	// Token: 0x06003D70 RID: 15728 RVA: 0x000576B0 File Offset: 0x000558B0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFindInteractionStandPoint._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindInteractionStandPoint.TsTaskFindInteractionStandPoint_C");
		}
		return TsTaskFindInteractionStandPoint._ClassPtr;
	}

	// Token: 0x06003D71 RID: 15729 RVA: 0x000576D4 File Offset: 0x000558D4
	public TsTaskFindInteractionStandPoint() : this(BuiltinUtils.AllocNativeUObject(TsTaskFindInteractionStandPoint.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D72 RID: 15730 RVA: 0x000576FC File Offset: 0x000558FC
	[NullableContext(1)]
	public TsTaskFindInteractionStandPoint(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindInteractionStandPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D73 RID: 15731 RVA: 0x0005772F File Offset: 0x0005592F
	protected TsTaskFindInteractionStandPoint(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D74 RID: 15732 RVA: 0x00057750 File Offset: 0x00055950
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000C30 RID: 3120
	private const double HALF_SQRT3 = 0.8660254;

	// Token: 0x04000C31 RID: 3121
	private const double DEGENERATE_SIDE = 1.0;

	// Token: 0x04000C32 RID: 3122
	private const int DETECT_HEIGHT = 2;

	// Token: 0x04000C33 RID: 3123
	[Nullable(1)]
	private const string PROFILE_KEY = "TsTaskFindInteractionStandPoint";

	// Token: 0x04000C34 RID: 3124
	private static readonly FLinearColor TRACE_COLOR_FLOOR = new FLinearColor(0f, 1f, 1f, 0f);

	// Token: 0x04000C35 RID: 3125
	private static readonly FLinearColor TRACE_COLOR_HEIGHT = new FLinearColor(1f, 0f, 1f, 0f);

	// Token: 0x04000C36 RID: 3126
	private static readonly FLinearColor TRACE_COLOR_STAND = new FLinearColor(1f, 0.5f, 0f, 0f);

	// Token: 0x04000C37 RID: 3127
	private static readonly FLinearColor TRACE_COLOR_HIT = new FLinearColor(1f, 0.33f, 0.5f, 1f);

	// Token: 0x04000C38 RID: 3128
	private bool IsInitTsVariables;

	// Token: 0x04000C39 RID: 3129
	private bool TsCheckObstacle;

	// Token: 0x04000C3A RID: 3130
	private float TsMaxHeightDiff;

	// Token: 0x04000C3B RID: 3131
	private float TsObstacleHeight;

	// Token: 0x04000C3C RID: 3132
	private float TsFloorDetectRange;

	// Token: 0x04000C3D RID: 3133
	private bool TsCheckHeightDiff;

	// Token: 0x04000C3E RID: 3134
	private float TsCapsuleRadiusScaleRate;

	// Token: 0x04000C3F RID: 3135
	private bool TsDebugDraw;

	// Token: 0x04000C40 RID: 3136
	[Nullable(1)]
	private string TsStandPointKey = "";

	// Token: 0x04000C41 RID: 3137
	[Nullable(1)]
	private string TsInteractionEntityKey = "";

	// Token: 0x04000C42 RID: 3138
	private Vector PlayerPos;

	// Token: 0x04000C43 RID: 3139
	private Vector NpcPos;

	// Token: 0x04000C44 RID: 3140
	private Vector SelfPos;

	// Token: 0x04000C45 RID: 3141
	private Vector BaseVec;

	// Token: 0x04000C46 RID: 3142
	private Vector MidPoint;

	// Token: 0x04000C47 RID: 3143
	private Vector Perp;

	// Token: 0x04000C48 RID: 3144
	private Vector ScaledPerp;

	// Token: 0x04000C49 RID: 3145
	private Vector CandidateA;

	// Token: 0x04000C4A RID: 3146
	private Vector CandidateB;

	// Token: 0x04000C4B RID: 3147
	private Vector TargetPos;

	// Token: 0x04000C4C RID: 3148
	private double PlayerFloorZ;

	// Token: 0x04000C4D RID: 3149
	private Vector FloorHit;

	// Token: 0x04000C4E RID: 3150
	private Vector TmpStart;

	// Token: 0x04000C4F RID: 3151
	private Vector TmpEnd;

	// Token: 0x04000C50 RID: 3152
	private UTraceSphereElement Element;

	// Token: 0x04000C51 RID: 3153
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFindInteractionStandPoint.TsTaskFindInteractionStandPoint_C";

	// Token: 0x04000C52 RID: 3154
	private static IntPtr _ClassPtr;

	// Token: 0x04000C53 RID: 3155
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000C54 RID: 3156
	private static int __PropertyOffset_CheckObstacle;

	// Token: 0x04000C55 RID: 3157
	private static int __PropertyOffset_MaxHeightDiff;

	// Token: 0x04000C56 RID: 3158
	private static int __PropertyOffset_ObstacleHeight;

	// Token: 0x04000C57 RID: 3159
	private static int __PropertyOffset_FloorDetectRange;

	// Token: 0x04000C58 RID: 3160
	private static int __PropertyOffset_CheckHeightDiff;

	// Token: 0x04000C59 RID: 3161
	private static int __PropertyOffset_CapsuleRadiusScaleRate;

	// Token: 0x04000C5A RID: 3162
	private static int __PropertyOffset_StandPointKey;

	// Token: 0x04000C5B RID: 3163
	private static int __PropertyOffset_InteractionEntityKey;

	// Token: 0x04000C5C RID: 3164
	private static int __PropertyOffset_DebugDraw;
}
