using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D56 RID: 3414
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateJumpLandDetect.TsAnimNotifyStateJumpLandDetect_C")]
public class TsAnimNotifyStateJumpLandDetect : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003E8 RID: 1000
	// (get) Token: 0x06004888 RID: 18568 RVA: 0x00099D54 File Offset: 0x00097F54
	// (set) Token: 0x06004889 RID: 18569 RVA: 0x00099D64 File Offset: 0x00097F64
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxHeightOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_MaxHeightOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_MaxHeightOffset) = value;
		}
	}

	// Token: 0x170003E9 RID: 1001
	// (get) Token: 0x0600488A RID: 18570 RVA: 0x00099D75 File Offset: 0x00097F75
	// (set) Token: 0x0600488B RID: 18571 RVA: 0x00099D85 File Offset: 0x00097F85
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OnlyDown
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_OnlyDown) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_OnlyDown) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003EA RID: 1002
	// (get) Token: 0x0600488C RID: 18572 RVA: 0x00099D96 File Offset: 0x00097F96
	// (set) Token: 0x0600488D RID: 18573 RVA: 0x00099DAA File Offset: 0x00097FAA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName IgnoreActorTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_IgnoreActorTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_IgnoreActorTag) = value;
		}
	}

	// Token: 0x170003EB RID: 1003
	// (get) Token: 0x0600488E RID: 18574 RVA: 0x00099DBF File Offset: 0x00097FBF
	// (set) Token: 0x0600488F RID: 18575 RVA: 0x00099DCF File Offset: 0x00097FCF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_DebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_DebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003EC RID: 1004
	// (get) Token: 0x06004890 RID: 18576 RVA: 0x00099DE0 File Offset: 0x00097FE0
	// (set) Token: 0x06004891 RID: 18577 RVA: 0x00099DF0 File Offset: 0x00097FF0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndPointHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_EndPointHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_EndPointHeight) = value;
		}
	}

	// Token: 0x170003ED RID: 1005
	// (get) Token: 0x06004892 RID: 18578 RVA: 0x00099E01 File Offset: 0x00098001
	// (set) Token: 0x06004893 RID: 18579 RVA: 0x00099E11 File Offset: 0x00098011
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableGoThrough
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_EnableGoThrough) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateJumpLandDetect.__PropertyOffset_EnableGoThrough) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004894 RID: 18580 RVA: 0x00099E24 File Offset: 0x00098024
	private void Init()
	{
		if (this.TsInited && this.ParamsMap != null)
		{
			return;
		}
		this.TsInited = true;
		this.TmpVector = Vector.Create();
		this.TmpVector2 = Vector.Create();
		this.TmpRotator = Rotator.Create();
		this.OwnerTransform = Transform.Create();
		this.ParamsMap = new Dictionary<int, JumpLandDetectParams>();
	}

	// Token: 0x06004895 RID: 18581 RVA: 0x00099E80 File Offset: 0x00098080
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004896 RID: 18582 RVA: 0x00099F28 File Offset: 0x00098128
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		this.Init();
		int entityIdNoBlueprint = tsBaseCharacter.GetEntityIdNoBlueprint();
		JumpLandDetectParams jumpLandDetectParams;
		if (!this.ParamsMap.TryGetValue(entityIdNoBlueprint, out jumpLandDetectParams))
		{
			jumpLandDetectParams = new JumpLandDetectParams();
			this.ParamsMap[entityIdNoBlueprint] = jumpLandDetectParams;
		}
		Entity entity = jumpLandDetectParams.Entity;
		CharacterMoveComponent characterMoveComponent = (entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null;
		if (this.EnableGoThrough && characterMoveComponent != null && characterMoveComponent.IsKuroPlanarPhysWalkingEnable)
		{
			characterMoveComponent.CharacterMovement.GoThroughLower = true;
			characterMoveComponent.CharacterMovement.GoThroughPriority = 0;
			jumpLandDetectParams.SetGoThrough = true;
		}
		else
		{
			jumpLandDetectParams.SetGoThrough = false;
		}
		jumpLandDetectParams.Entity = tsBaseCharacter.GetEntityNoBlueprint();
		Vector vector = Vector.Create();
		Vector vector2 = Vector.Create();
		Vector vector3 = Vector.Create();
		Vector vector4 = Vector.Create();
		UAnimInstance animInstance = meshComp.GetAnimInstance();
		Transform ownerTransform = this.OwnerTransform;
		FTransformDouble ftransformDouble = tsBaseCharacter.D_GetTransform();
		ownerTransform.FromUeTransform(ftransformDouble);
		this.GetCurveLocation(animInstance, 0f, this.TmpVector);
		this.GetCurveRotator(animInstance, 0f, this.TmpRotator);
		this.GetCurveLocation(animInstance, totalDuration, this.TmpVector2);
		Singleton<MathUtils>.Instance.InverseTransformPositionNoScale(this.TmpVector, this.TmpRotator, this.TmpVector2, this.TmpVector2);
		this.TmpVector2.Z -= (double)this.EndPointHeight;
		this.OwnerTransform.TransformPosition(this.TmpVector2, this.TmpVector2);
		Vector vector5 = Vector.Create();
		this.OwnerTransform.GetRotation().RotateVector(Vector.UpVectorProxy, vector5);
		vector5.Multiply((double)this.MaxHeightOffset, vector2);
		float scaledCapsuleRadius = tsBaseCharacter.CapsuleComponent.GetScaledCapsuleRadius();
		vector5.MultiplyEqual((double)(tsBaseCharacter.CapsuleComponent.GetScaledCapsuleHalfHeight() - scaledCapsuleRadius));
		this.TmpVector2.Subtraction(vector5, vector);
		if (this.OnlyDown)
		{
			vector3.DeepCopy(vector);
		}
		else
		{
			vector.Addition(vector2, vector3);
		}
		vector.Subtraction(vector2, vector4);
		TArray<FHitResult> tarray = new TArray<FHitResult>();
		TArray<AActor> tarray2 = new TArray<AActor>();
		UKismetSystemLibrary.D_SphereTraceMulti(tsBaseCharacter, vector3.ToUeVector(false), vector4.ToUeVector(false), scaledCapsuleRadius, KuroTraceTypeQuery.IkGround, false, tarray2, this.DebugDraw ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None, ref tarray, true, new FLinearColor?(this.TraceColorRed), new FLinearColor?(this.TraceColorGreen), 5f);
		int num = tarray.Num();
		jumpLandDetectParams.TotalTime = 0f;
		jumpLandDetectParams.NowTime = 0f;
		int i = 0;
		while (i < num)
		{
			FHitResult fhitResult = tarray.Get(i);
			if (fhitResult.bBlockingHit)
			{
				AActor inActor = fhitResult.Actor;
				FName ignoreActorTag = this.IgnoreActorTag;
				if (!UKuroCollisionLibrary.ActorHasTag(inActor, ignoreActorTag, fhitResult.Item) && tsBaseCharacter.CharacterMovement.IsWalkable(fhitResult))
				{
					Vector.Create(fhitResult.Location).Subtraction(vector, jumpLandDetectParams.HeightOffset);
					jumpLandDetectParams.TotalTime = totalDuration;
					return true;
				}
				return false;
			}
			else
			{
				i++;
			}
		}
		return true;
	}

	// Token: 0x06004897 RID: 18583 RVA: 0x0009A21C File Offset: 0x0009841C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004898 RID: 18584 RVA: 0x0009A2BC File Offset: 0x000984BC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		int entityIdNoBlueprint = tsBaseCharacter.GetEntityIdNoBlueprint();
		JumpLandDetectParams jumpLandDetectParams;
		if (!this.ParamsMap.TryGetValue(entityIdNoBlueprint, out jumpLandDetectParams))
		{
			return false;
		}
		Entity entity = jumpLandDetectParams.Entity;
		CharacterUnifiedStateComponent characterUnifiedStateComponent = (entity != null) ? entity.GetComponent<CharacterUnifiedStateComponent>() : null;
		if (characterUnifiedStateComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "JumpLandDetect No Unified";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", tsBaseCharacter);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (jumpLandDetectParams.SetGoThrough)
		{
			tsBaseCharacter.CharacterMovement.GoThroughLower = false;
			Entity entity2 = jumpLandDetectParams.Entity;
			if (entity2 != null)
			{
				BaseMoveComponent component = entity2.GetComponent<BaseMoveComponent>();
				if (component != null)
				{
					component.ResetHitPriorityAndGoThrough();
				}
			}
		}
		if (jumpLandDetectParams.NowTime <= jumpLandDetectParams.TotalTime && characterUnifiedStateComponent.PositionState == ECharPositionState.Air && jumpLandDetectParams.TotalTime > 0f)
		{
			float offsetRate = (jumpLandDetectParams.TotalTime - jumpLandDetectParams.NowTime) / jumpLandDetectParams.TotalTime;
			this.Move(animation, jumpLandDetectParams, offsetRate);
		}
		if ((double)base.CurrentTimeLength >= (double)jumpLandDetectParams.TotalTime - 0.0001 && this.EndPointHeight <= 0f)
		{
			this.TrySetMovementMode(tsBaseCharacter);
		}
		return true;
	}

	// Token: 0x06004899 RID: 18585 RVA: 0x0009A3D4 File Offset: 0x000985D4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600489A RID: 18586 RVA: 0x0009A47C File Offset: 0x0009867C
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		int entityIdNoBlueprint = tsBaseCharacter.GetEntityIdNoBlueprint();
		JumpLandDetectParams jumpLandDetectParams;
		if (!this.ParamsMap.TryGetValue(entityIdNoBlueprint, out jumpLandDetectParams))
		{
			return false;
		}
		if (jumpLandDetectParams.Entity.GetComponent<CharacterUnifiedStateComponent>().PositionState == ECharPositionState.Ground)
		{
			jumpLandDetectParams.TotalTime -= frameDeltaTime;
		}
		else if (jumpLandDetectParams.NowTime <= jumpLandDetectParams.TotalTime && jumpLandDetectParams.TotalTime > 0f)
		{
			float offsetRate = Math.Min(jumpLandDetectParams.TotalTime - jumpLandDetectParams.NowTime, frameDeltaTime) / jumpLandDetectParams.TotalTime;
			this.Move(animation, jumpLandDetectParams, offsetRate);
			jumpLandDetectParams.NowTime += frameDeltaTime;
		}
		return true;
	}

	// Token: 0x0600489B RID: 18587 RVA: 0x0009A524 File Offset: 0x00098724
	private unsafe void Move(UAnimSequenceBase animation, JumpLandDetectParams @params, float offsetRate)
	{
		BaseSkillComponent component = @params.Entity.GetComponent<BaseSkillComponent>();
		if (component != null && component.IsSkillMontageInvalid(animation.GetName()))
		{
			return;
		}
		BaseActorComponent component2 = @params.Entity.GetComponent<CharacterActorComponent>();
		@params.HeightOffset.Multiply((double)offsetRate, this.TmpVector);
		if (this.TmpVector.ContainsNaN())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Move NaN";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("HeightOffset", @params.HeightOffset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("offsetRate", offsetRate);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		component2.AddActorWorldOffset(this.TmpVector.ToUeVector(false), "TsAnimNotifyStateJumpLandDetect", true);
	}

	// Token: 0x0600489C RID: 18588 RVA: 0x0009A5F0 File Offset: 0x000987F0
	private void GetCurveLocation(UAnimInstance mainAnim, float deltaSeconds, Vector @out)
	{
		@out.X = (double)mainAnim.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_Y, deltaSeconds, false, false);
		@out.Y = (double)(-(double)mainAnim.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_X, deltaSeconds, false, false));
		@out.Z = (double)mainAnim.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_Z, deltaSeconds, false, false);
	}

	// Token: 0x0600489D RID: 18589 RVA: 0x0009A64C File Offset: 0x0009884C
	private void GetCurveRotator(UAnimInstance mainAnim, float deltaSeconds, Rotator @out)
	{
		@out.Pitch = 0f;
		@out.Yaw = mainAnim.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_LOOK, deltaSeconds, false, false);
		@out.Roll = 0f;
	}

	// Token: 0x0600489E RID: 18590 RVA: 0x0009A680 File Offset: 0x00098880
	private void TrySetMovementMode(TsBaseCharacter owner)
	{
		CharacterActorComponent characterActorComponent = owner.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null;
		if (characterDriveVehicleComponent != null && characterDriveVehicleComponent.IsOnVehicle)
		{
			return;
		}
		owner.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = EMovementMode.MOVE_Walking,
			CustomMode = 0,
			Context = "[TsAnimNotifyStateJumpLandDetect.K2_NotifyEnd]"
		});
	}

	// Token: 0x0600489F RID: 18591 RVA: 0x0009A6E0 File Offset: 0x000988E0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x060048A0 RID: 18592 RVA: 0x0009A75B File Offset: 0x0009895B
	protected override string GetNotifyName_Implementation()
	{
		return "跳跃检测着陆";
	}

	// Token: 0x060048A1 RID: 18593 RVA: 0x0009A762 File Offset: 0x00098962
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateJumpLandDetect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateJumpLandDetect.TsAnimNotifyStateJumpLandDetect_C");
		}
		return TsAnimNotifyStateJumpLandDetect._ClassPtr;
	}

	// Token: 0x060048A2 RID: 18594 RVA: 0x0009A788 File Offset: 0x00098988
	public TsAnimNotifyStateJumpLandDetect() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateJumpLandDetect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060048A3 RID: 18595 RVA: 0x0009A7B0 File Offset: 0x000989B0
	public TsAnimNotifyStateJumpLandDetect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateJumpLandDetect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060048A4 RID: 18596 RVA: 0x0009A7E4 File Offset: 0x000989E4
	protected TsAnimNotifyStateJumpLandDetect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060048A5 RID: 18597 RVA: 0x0009A870 File Offset: 0x00098A70
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060048A6 RID: 18598 RVA: 0x0009A8AC File Offset: 0x00098AAC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060048A7 RID: 18599 RVA: 0x0009A8E0 File Offset: 0x00098AE0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060048A8 RID: 18600 RVA: 0x0009A919 File Offset: 0x00098B19
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001435 RID: 5173
	private bool TsInited;

	// Token: 0x04001436 RID: 5174
	private Vector TmpVector = Vector.Create();

	// Token: 0x04001437 RID: 5175
	private Vector TmpVector2 = Vector.Create();

	// Token: 0x04001438 RID: 5176
	private Rotator TmpRotator = Rotator.Create();

	// Token: 0x04001439 RID: 5177
	private Transform OwnerTransform = Transform.Create();

	// Token: 0x0400143A RID: 5178
	private Dictionary<int, JumpLandDetectParams> ParamsMap = new Dictionary<int, JumpLandDetectParams>();

	// Token: 0x0400143B RID: 5179
	private readonly FLinearColor TraceColorRed = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x0400143C RID: 5180
	private readonly FLinearColor TraceColorGreen = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x0400143D RID: 5181
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateJumpLandDetect.TsAnimNotifyStateJumpLandDetect_C";

	// Token: 0x0400143E RID: 5182
	private static IntPtr _ClassPtr;

	// Token: 0x0400143F RID: 5183
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001440 RID: 5184
	private static int __PropertyOffset_MaxHeightOffset;

	// Token: 0x04001441 RID: 5185
	private static int __PropertyOffset_OnlyDown;

	// Token: 0x04001442 RID: 5186
	private static int __PropertyOffset_IgnoreActorTag;

	// Token: 0x04001443 RID: 5187
	private static int __PropertyOffset_DebugDraw;

	// Token: 0x04001444 RID: 5188
	private static int __PropertyOffset_EndPointHeight;

	// Token: 0x04001445 RID: 5189
	private static int __PropertyOffset_EnableGoThrough;
}
