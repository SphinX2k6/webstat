using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB8 RID: 3256
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowPlayerHardMode.TsTaskFollowPlayerHardMode_C")]
public class TsTaskFollowPlayerHardMode : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700023E RID: 574
	// (get) Token: 0x06003DEF RID: 15855 RVA: 0x0005A113 File Offset: 0x00058313
	// (set) Token: 0x06003DF0 RID: 15856 RVA: 0x0005A123 File Offset: 0x00058323
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MoveSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_MoveSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_MoveSpeed) = value;
		}
	}

	// Token: 0x1700023F RID: 575
	// (get) Token: 0x06003DF1 RID: 15857 RVA: 0x0005A134 File Offset: 0x00058334
	// (set) Token: 0x06003DF2 RID: 15858 RVA: 0x0005A144 File Offset: 0x00058344
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float RotateSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_RotateSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_RotateSpeed) = value;
		}
	}

	// Token: 0x17000240 RID: 576
	// (get) Token: 0x06003DF3 RID: 15859 RVA: 0x0005A155 File Offset: 0x00058355
	// (set) Token: 0x06003DF4 RID: 15860 RVA: 0x0005A169 File Offset: 0x00058369
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector LocationOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_LocationOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_LocationOffset) = value;
		}
	}

	// Token: 0x17000241 RID: 577
	// (get) Token: 0x06003DF5 RID: 15861 RVA: 0x0005A17E File Offset: 0x0005837E
	// (set) Token: 0x06003DF6 RID: 15862 RVA: 0x0005A18E File Offset: 0x0005838E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ForceMoveDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_ForceMoveDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_ForceMoveDistance) = value;
		}
	}

	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06003DF7 RID: 15863 RVA: 0x0005A19F File Offset: 0x0005839F
	// (set) Token: 0x06003DF8 RID: 15864 RVA: 0x0005A1AF File Offset: 0x000583AF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool LookAtTarget
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_LookAtTarget) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_LookAtTarget) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000243 RID: 579
	// (get) Token: 0x06003DF9 RID: 15865 RVA: 0x0005A1C0 File Offset: 0x000583C0
	// (set) Token: 0x06003DFA RID: 15866 RVA: 0x0005A1D0 File Offset: 0x000583D0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DetectTargetDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_DetectTargetDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_DetectTargetDistance) = value;
		}
	}

	// Token: 0x17000244 RID: 580
	// (get) Token: 0x06003DFB RID: 15867 RVA: 0x0005A1E4 File Offset: 0x000583E4
	// (set) Token: 0x06003DFC RID: 15868 RVA: 0x0005A21D File Offset: 0x0005841D
	[Nullable(new byte[]
	{
		1,
		0
	})]
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<TEnumAsByte<EObjectTypeQuery>> DetectTargetTypes
	{
		[return: Nullable(new byte[]
		{
			1,
			0
		})]
		get
		{
			base.FastCheckIsValid();
			TArray<TEnumAsByte<EObjectTypeQuery>> result;
			if ((result = this._DetectTargetTypes) == null)
			{
				result = (this._DetectTargetTypes = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)TsTaskFollowPlayerHardMode.__PropertyOffset_DetectTargetTypes, this));
			}
			return result;
		}
		[param: Nullable(new byte[]
		{
			1,
			0
		})]
		set
		{
			this.DetectTargetTypes.CopyAssign(value);
		}
	}

	// Token: 0x06003DFD RID: 15869 RVA: 0x0005A22C File Offset: 0x0005842C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveSpeed = this.MoveSpeed;
			this.TsRotateSpeed = this.RotateSpeed;
			this.TsForceMoveDistance = this.ForceMoveDistance;
			this.TsLookAtTarget = this.LookAtTarget;
			this.TsDetectTargetDistance = this.DetectTargetDistance;
			this.RotateOffset = Rotator.Create();
			this.TempRotator = Rotator.Create();
			this.TsLocationOffset = Vector.Create();
			this.TempTargetLocation = Vector.Create();
			this.TempTargetForward = Vector.Create();
			this.TempMoveVector = Vector.Create();
			this.TempVector = Vector.Create();
			FVector locationOffset = this.LocationOffset;
			Vector tsLocationOffset = this.TsLocationOffset;
			FVector locationOffset2 = this.LocationOffset;
			tsLocationOffset.FromUeVector(locationOffset2);
		}
	}

	// Token: 0x06003DFE RID: 15870 RVA: 0x0005A2F8 File Offset: 0x000584F8
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

	// Token: 0x06003DFF RID: 15871 RVA: 0x0005A394 File Offset: 0x00058594
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
		Entity entity = charActorComp.Entity;
		this.MoveComp = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
		CharacterActorComponent charActorComp2 = aiController.CharActorComp;
		if (charActorComp2 != null)
		{
			charActorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Flying,
				Context = "[TsTaskFollowPlayerHardMode.ReceiveExecuteAI]"
			});
		}
		this.UpdateRotateOffsetTime = 0f;
		this.RotateOffset.Reset();
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
		if (this.TsLookAtTarget && this.LineElement == null && this.DetectTargetTypes != null && this.DetectTargetTypes.Num() > 0)
		{
			this.LineElement = new UTraceLineElement();
			this.LineElement.bIsSingle = true;
			this.LineElement.bIgnoreSelf = true;
			this.LineElement.WorldContextObject = charActorComp.Owner;
			for (int i = 0; i < this.DetectTargetTypes.Num(); i++)
			{
				this.LineElement.AddObjectTypeQuery(this.DetectTargetTypes.Get(i));
			}
		}
	}

	// Token: 0x06003E00 RID: 15872 RVA: 0x0005A58C File Offset: 0x0005878C
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

	// Token: 0x06003E01 RID: 15873 RVA: 0x0005A62C File Offset: 0x0005882C
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
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null || !characterActorComponent.Valid || (charActorComp == null || !charActorComp.Valid))
		{
			base.FinishExecute(false);
			return;
		}
		if (this.MoveComp != null && this.MoveComp.CharacterMovement.MovementMode != EMovementMode.MOVE_Flying)
		{
			charActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Flying,
				Context = "[TsTaskFollowPlayerHardMode.ReceiveTickAI]"
			});
		}
		float num = deltaSeconds * charActorComp.Actor.CustomTimeDilation;
		Vector actorLocationProxy = characterActorComponent.ActorLocationProxy;
		Vector actorLocationProxy2 = charActorComp.ActorLocationProxy;
		Vector actorUpProxy = characterActorComponent.ActorUpProxy;
		Rotator tempRotator = this.TempRotator;
		FRotator cameraRotation = Global.CharacterCameraManager.GetCameraRotation();
		tempRotator.FromUeRotator(cameraRotation);
		if (this.TsLookAtTarget)
		{
			this.UpdateRotateOffset(num, actorLocationProxy2);
		}
		this.TempRotator.AdditionEqual(this.RotateOffset);
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp != null)
		{
			moveComp.SmoothCharacterRotation(this.TempRotator.ToUeRotator(), this.TsRotateSpeed, num, false, "FollowPlayerHardMode", true);
		}
		this.TempTargetLocation.DeepCopy(actorLocationProxy);
		Vector tempTargetForward = this.TempTargetForward;
		FVector actorForwardVector = Global.CharacterCameraManager.GetActorForwardVector();
		tempTargetForward.FromUeVector(actorForwardVector);
		Vector.VectorPlaneProject(this.TempTargetForward, actorUpProxy, this.TempVector);
		this.TempTargetForward.DeepCopy(this.TempVector);
		this.TempTargetForward.Normalize(9.99999993922529E-09);
		this.TempTargetForward.Multiply(this.TsLocationOffset.X, this.TempVector);
		this.TempTargetLocation.AdditionEqual(this.TempVector);
		this.TempTargetForward.RotateAngleAxis(90.0, actorUpProxy, this.TempTargetForward);
		this.TempTargetForward.Multiply(this.TsLocationOffset.Y, this.TempVector);
		this.TempTargetLocation.AdditionEqual(this.TempVector);
		actorUpProxy.Multiply(this.TsLocationOffset.Z, this.TempVector);
		this.TempTargetLocation.AdditionEqual(this.TempVector);
		actorLocationProxy2.Subtraction(actorLocationProxy, this.TempVector);
		if (this.TempVector.SizeSquared() > (double)(this.TsForceMoveDistance * this.TsForceMoveDistance))
		{
			if (this.CheckObstacle(actorLocationProxy, this.TempTargetLocation))
			{
				charActorComp.SetActorLocation(actorLocationProxy.ToUeVector(false), "FollowPlayerHardMode", false);
				return;
			}
			charActorComp.SetActorLocation(this.TempTargetLocation.ToUeVector(false), "FollowPlayerHardMode", false);
			return;
		}
		else
		{
			this.TempTargetLocation.Subtraction(actorLocationProxy2, this.TempMoveVector);
			double num2 = this.TempMoveVector.SizeSquared();
			float num3 = this.TsMoveSpeed * num;
			if (num2 > (double)(num3 * num3))
			{
				this.TempMoveVector.Normalize(9.99999993922529E-09);
				this.TempMoveVector.MultiplyEqual((double)num3);
			}
			BaseMoveComponent moveComp2 = this.MoveComp;
			if (moveComp2 == null)
			{
				return;
			}
			moveComp2.MoveCharacter(this.TempMoveVector, 1f, "FollowPlayerHardMode");
			return;
		}
	}

	// Token: 0x06003E02 RID: 15874 RVA: 0x0005A98C File Offset: 0x00058B8C
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

	// Token: 0x06003E03 RID: 15875 RVA: 0x0005A9F4 File Offset: 0x00058BF4
	private void UpdateRotateOffset(float deltaSeconds, Vector selfLocation)
	{
		if (this.LineElement == null)
		{
			return;
		}
		this.UpdateRotateOffsetTime += deltaSeconds * 1000f;
		if (this.UpdateRotateOffsetTime < 200f)
		{
			return;
		}
		this.UpdateRotateOffsetTime = 0f;
		Vector tempVector = this.TempVector;
		FVectorDouble fvectorDouble = Global.CharacterCameraManager.D_GetCameraLocation();
		tempVector.FromUeVector(fvectorDouble);
		Vector tempMoveVector = this.TempMoveVector;
		FVector actorForwardVector = Global.CharacterCameraManager.GetActorForwardVector();
		tempMoveVector.FromUeVector(actorForwardVector);
		this.TempMoveVector.MultiplyEqual((double)this.TsDetectTargetDistance);
		this.TempMoveVector.AdditionEqual(this.TempVector);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineElement, this.TempVector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineElement, this.TempMoveVector);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(this.LineElement, "FollowPlayerHardMode DetectTarget");
		UKuroHitResult hitResult = this.LineElement.HitResult;
		if (flag && hitResult != null && hitResult.bBlockingHit)
		{
			Singleton<TraceElementCommon>.Instance.GetHitLocation(hitResult, 0, this.TempVector);
			Rotator rotateOffset = this.RotateOffset;
			fvectorDouble = selfLocation.ToUeVector(false);
			FVectorDouble fvectorDouble2 = this.TempVector.ToUeVector(false);
			FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, fvectorDouble2);
			rotateOffset.FromUeRotator(frotator);
		}
		else
		{
			Rotator rotateOffset2 = this.RotateOffset;
			fvectorDouble = selfLocation.ToUeVector(false);
			FVectorDouble fvectorDouble2 = this.TempMoveVector.ToUeVector(false);
			FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, fvectorDouble2);
			rotateOffset2.FromUeRotator(frotator);
		}
		this.RotateOffset.SubtractionEqual(this.TempRotator);
	}

	// Token: 0x06003E04 RID: 15876 RVA: 0x0005AB66 File Offset: 0x00058D66
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFollowPlayerHardMode._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowPlayerHardMode.TsTaskFollowPlayerHardMode_C");
		}
		return TsTaskFollowPlayerHardMode._ClassPtr;
	}

	// Token: 0x06003E05 RID: 15877 RVA: 0x0005AB8C File Offset: 0x00058D8C
	public TsTaskFollowPlayerHardMode() : this(BuiltinUtils.AllocNativeUObject(TsTaskFollowPlayerHardMode.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003E06 RID: 15878 RVA: 0x0005ABB4 File Offset: 0x00058DB4
	public TsTaskFollowPlayerHardMode(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFollowPlayerHardMode.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003E07 RID: 15879 RVA: 0x0005ABE8 File Offset: 0x00058DE8
	protected TsTaskFollowPlayerHardMode(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003E08 RID: 15880 RVA: 0x0005AC4C File Offset: 0x00058E4C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003E09 RID: 15881 RVA: 0x0005AC7C File Offset: 0x00058E7C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000CD7 RID: 3287
	private const float UPDATE_ROTATE_OFFSET_INTERVAL = 200f;

	// Token: 0x04000CD8 RID: 3288
	private float TsMoveSpeed;

	// Token: 0x04000CD9 RID: 3289
	private float TsRotateSpeed;

	// Token: 0x04000CDA RID: 3290
	private Vector TsLocationOffset = Vector.Create();

	// Token: 0x04000CDB RID: 3291
	private float TsForceMoveDistance;

	// Token: 0x04000CDC RID: 3292
	private bool TsLookAtTarget;

	// Token: 0x04000CDD RID: 3293
	private float TsDetectTargetDistance;

	// Token: 0x04000CDE RID: 3294
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x04000CDF RID: 3295
	[Nullable(2)]
	private UTraceCapsuleElement TraceElement;

	// Token: 0x04000CE0 RID: 3296
	[Nullable(2)]
	private UTraceLineElement LineElement;

	// Token: 0x04000CE1 RID: 3297
	private Rotator RotateOffset = Rotator.Create();

	// Token: 0x04000CE2 RID: 3298
	private float UpdateRotateOffsetTime;

	// Token: 0x04000CE3 RID: 3299
	private Rotator TempRotator = Rotator.Create();

	// Token: 0x04000CE4 RID: 3300
	private Vector TempTargetLocation = Vector.Create();

	// Token: 0x04000CE5 RID: 3301
	private Vector TempTargetForward = Vector.Create();

	// Token: 0x04000CE6 RID: 3302
	private Vector TempMoveVector = Vector.Create();

	// Token: 0x04000CE7 RID: 3303
	private Vector TempVector = Vector.Create();

	// Token: 0x04000CE8 RID: 3304
	private bool IsInitTsVariables;

	// Token: 0x04000CE9 RID: 3305
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFollowPlayerHardMode.TsTaskFollowPlayerHardMode_C";

	// Token: 0x04000CEA RID: 3306
	private static IntPtr _ClassPtr;

	// Token: 0x04000CEB RID: 3307
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000CEC RID: 3308
	private static int __PropertyOffset_MoveSpeed;

	// Token: 0x04000CED RID: 3309
	private static int __PropertyOffset_RotateSpeed;

	// Token: 0x04000CEE RID: 3310
	private static int __PropertyOffset_LocationOffset;

	// Token: 0x04000CEF RID: 3311
	private static int __PropertyOffset_ForceMoveDistance;

	// Token: 0x04000CF0 RID: 3312
	private static int __PropertyOffset_LookAtTarget;

	// Token: 0x04000CF1 RID: 3313
	private static int __PropertyOffset_DetectTargetDistance;

	// Token: 0x04000CF2 RID: 3314
	private static int __PropertyOffset_DetectTargetTypes;

	// Token: 0x04000CF3 RID: 3315
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private TArray<TEnumAsByte<EObjectTypeQuery>> _DetectTargetTypes;
}
