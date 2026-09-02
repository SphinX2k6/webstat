using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D1F RID: 3359
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddMoveByInputDirect.TsAnimNotifyStateAddMoveByInputDirect_C")]
public class TsAnimNotifyStateAddMoveByInputDirect : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004473 RID: 17523 RVA: 0x00085AAE File Offset: 0x00083CAE
	static TsAnimNotifyStateAddMoveByInputDirect()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateAddMoveByInputDirect.CreateStaticDefaultValue), new Action(TsAnimNotifyStateAddMoveByInputDirect.ResetStaticDefaultValue));
	}

	// Token: 0x06004474 RID: 17524 RVA: 0x00085ACD File Offset: 0x00083CCD
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateAddMoveByInputDirect.paramMap = new Dictionary<int, AddMoveParams>();
	}

	// Token: 0x06004475 RID: 17525 RVA: 0x00085AD9 File Offset: 0x00083CD9
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateAddMoveByInputDirect.paramMap = null;
	}

	// Token: 0x17000336 RID: 822
	// (get) Token: 0x06004476 RID: 17526 RVA: 0x00085AE1 File Offset: 0x00083CE1
	// (set) Token: 0x06004477 RID: 17527 RVA: 0x00085AF1 File Offset: 0x00083CF1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_MaxSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_MaxSpeed) = value;
		}
	}

	// Token: 0x17000337 RID: 823
	// (get) Token: 0x06004478 RID: 17528 RVA: 0x00085B02 File Offset: 0x00083D02
	// (set) Token: 0x06004479 RID: 17529 RVA: 0x00085B12 File Offset: 0x00083D12
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AccelerationTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_AccelerationTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_AccelerationTime) = value;
		}
	}

	// Token: 0x17000338 RID: 824
	// (get) Token: 0x0600447A RID: 17530 RVA: 0x00085B23 File Offset: 0x00083D23
	// (set) Token: 0x0600447B RID: 17531 RVA: 0x00085B33 File Offset: 0x00083D33
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DecelerationTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_DecelerationTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_DecelerationTime) = value;
		}
	}

	// Token: 0x17000339 RID: 825
	// (get) Token: 0x0600447C RID: 17532 RVA: 0x00085B44 File Offset: 0x00083D44
	// (set) Token: 0x0600447D RID: 17533 RVA: 0x00085B58 File Offset: 0x00083D58
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat SpeedCurve
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_SpeedCurve);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_SpeedCurve, value);
		}
	}

	// Token: 0x1700033A RID: 826
	// (get) Token: 0x0600447E RID: 17534 RVA: 0x00085B6D File Offset: 0x00083D6D
	// (set) Token: 0x0600447F RID: 17535 RVA: 0x00085B7D File Offset: 0x00083D7D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Distance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_Distance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAddMoveByInputDirect.__PropertyOffset_Distance) = value;
		}
	}

	// Token: 0x06004480 RID: 17536 RVA: 0x00085B90 File Offset: 0x00083D90
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

	// Token: 0x06004481 RID: 17537 RVA: 0x00085C38 File Offset: 0x00083E38
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		if (this.TmpVector == null)
		{
			this.TmpVector = Vector.Create();
		}
		AddMoveParams addMoveParams = new AddMoveParams();
		Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
		addMoveParams.CharSkillComp = entity.GetComponent<CharacterSkillComponent>();
		addMoveParams.MoveComp = entity.GetComponent<BaseMoveComponent>();
		addMoveParams.CharActorComp = (owner as TsBaseCharacter).CharacterActorComponent;
		TsAnimNotifyStateAddMoveByInputDirect.paramMap.Add((owner as TsBaseCharacter).EntityId, addMoveParams);
		this.TotalTime = totalDuration;
		if (this.AccelerationTime + this.DecelerationTime > totalDuration)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity2 = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
			string message = "加速时间+减速时间大于帧事件总时长";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("加速时间", this.AccelerationTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("减速时间", this.DecelerationTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("总时长", this.TotalTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("动画", animation);
			instance.Error(flag, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return false;
		}
		if (this.AccelerationTime > 0f)
		{
			this.Acceleration = this.MaxSpeed / this.AccelerationTime;
		}
		if (this.DecelerationTime > 0f)
		{
			this.Deceleration = this.MaxSpeed / this.DecelerationTime;
		}
		return true;
	}

	// Token: 0x06004482 RID: 17538 RVA: 0x00085DCC File Offset: 0x00083FCC
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

	// Token: 0x06004483 RID: 17539 RVA: 0x00085E74 File Offset: 0x00084074
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		AddMoveParams addMoveParams;
		if (!TsAnimNotifyStateAddMoveByInputDirect.paramMap.TryGetValue(tsBaseCharacter.EntityId, out addMoveParams))
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
			string message = "没有找到对应的AddMoveParams";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", tsBaseCharacter.EntityId);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		Vector inputDirectProxy = tsBaseCharacter.CharacterActorComponent.InputDirectProxy;
		if (!inputDirectProxy.IsNearlyZero(9.999999747378752E-05))
		{
			addMoveParams.InputDirectCache.DeepCopy(inputDirectProxy);
		}
		Vector offset = this.GetOffset(inputDirectProxy, frameDeltaTime, addMoveParams);
		BaseMoveComponent moveComp = addMoveParams.MoveComp;
		if (moveComp != null)
		{
			moveComp.MoveCharacter(offset, frameDeltaTime, "TsAnimNotifyStateAddMoveByInputDirect");
		}
		addMoveParams.NowTime += frameDeltaTime;
		return true;
	}

	// Token: 0x06004484 RID: 17540 RVA: 0x00085F3C File Offset: 0x0008413C
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

	// Token: 0x06004485 RID: 17541 RVA: 0x00085FDC File Offset: 0x000841DC
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		TsAnimNotifyStateAddMoveByInputDirect.paramMap.Remove((owner as TsBaseCharacter).EntityId);
		return true;
	}

	// Token: 0x06004486 RID: 17542 RVA: 0x00086014 File Offset: 0x00084214
	[NullableContext(1)]
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

	// Token: 0x06004487 RID: 17543 RVA: 0x0008608F File Offset: 0x0008428F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "输入向量叠加位移";
	}

	// Token: 0x06004488 RID: 17544 RVA: 0x00086098 File Offset: 0x00084298
	[NullableContext(1)]
	private Vector GetOffset(Vector inputDirect, float frameDeltaTime, AddMoveParams param)
	{
		if (this.SpeedCurve != null)
		{
			if (this.IsDecelerating(inputDirect, param))
			{
				if (this.DecelerationTime <= 0f)
				{
					this.SetCurrentSpeedFromCurve(param, 0f);
				}
				else if (this.AccelerationTime <= 0f)
				{
					param.AccumulativeSpeedUpTime -= frameDeltaTime;
					param.AccumulativeSpeedUpTime = Math.Max(param.AccumulativeSpeedUpTime, 0f);
					float floatValue = this.SpeedCurve.GetFloatValue(param.AccumulativeSpeedUpTime / this.DecelerationTime);
					this.SetCurrentSpeedFromCurve(param, floatValue);
				}
				else
				{
					param.AccumulativeSpeedUpTime -= frameDeltaTime * (this.AccelerationTime / this.DecelerationTime);
					param.AccumulativeSpeedUpTime = Math.Max(param.AccumulativeSpeedUpTime, 0f);
					float floatValue2 = this.SpeedCurve.GetFloatValue(param.AccumulativeSpeedUpTime / this.AccelerationTime);
					this.SetCurrentSpeedFromCurve(param, floatValue2);
				}
			}
			else if (this.AccelerationTime <= 0f)
			{
				this.SetCurrentSpeedFromCurve(param, 1f);
				param.AccumulativeSpeedUpTime = this.DecelerationTime;
			}
			else
			{
				param.AccumulativeSpeedUpTime += frameDeltaTime;
				param.AccumulativeSpeedUpTime = Math.Min(param.AccumulativeSpeedUpTime, this.AccelerationTime);
				float floatValue3 = this.SpeedCurve.GetFloatValue(param.AccumulativeSpeedUpTime / this.AccelerationTime);
				this.SetCurrentSpeedFromCurve(param, floatValue3);
			}
		}
		else if (this.IsDecelerating(inputDirect, param))
		{
			if (this.Deceleration != 0f)
			{
				param.CurrentSpeed -= this.Deceleration * frameDeltaTime;
				param.CurrentSpeed = Math.Max(param.CurrentSpeed, 0f);
			}
			else
			{
				param.CurrentSpeed = 0f;
			}
		}
		else if (this.Acceleration != 0f)
		{
			param.CurrentSpeed += this.Acceleration * frameDeltaTime;
			param.CurrentSpeed = Math.Min(param.CurrentSpeed, this.MaxSpeed);
		}
		else
		{
			param.CurrentSpeed = this.MaxSpeed;
		}
		this.TmpVector.DeepCopy(param.InputDirectCache);
		this.TmpVector.Normalize(9.99999993922529E-09);
		this.TmpVector.MultiplyEqual((double)(param.CurrentSpeed * frameDeltaTime));
		return this.TmpVector;
	}

	// Token: 0x06004489 RID: 17545 RVA: 0x000862D8 File Offset: 0x000844D8
	[NullableContext(1)]
	private bool IsDecelerating(Vector inputDirect, AddMoveParams param)
	{
		CharacterSkillComponent charSkillComp = param.CharSkillComp;
		EntityHandle entityHandle = (charSkillComp != null) ? charSkillComp.GetSkillTargetForAns() : null;
		if (this.Distance > 0f && entityHandle != null)
		{
			Vector actorLocationProxy = param.CharActorComp.ActorLocationProxy;
			Vector targetPosition = this.GetTargetPosition(param, entityHandle);
			if (Vector.Dist2D(actorLocationProxy, targetPosition) < (double)this.Distance)
			{
				return true;
			}
		}
		return inputDirect.IsNearlyZero(9.999999747378752E-05) || param.NowTime > this.TotalTime - this.DecelerationTime;
	}

	// Token: 0x0600448A RID: 17546 RVA: 0x00086358 File Offset: 0x00084558
	[NullableContext(1)]
	private void SetCurrentSpeedFromCurve(AddMoveParams param, float nextSpeedRate)
	{
		float num = this.MaxSpeed * nextSpeedRate;
		if (num <= 0f)
		{
			param.CurrentSpeed = 0f;
			return;
		}
		param.CurrentSpeed = num;
	}

	// Token: 0x0600448B RID: 17547 RVA: 0x0008638C File Offset: 0x0008458C
	[NullableContext(1)]
	private Vector GetTargetPosition(AddMoveParams param, EntityHandle target)
	{
		string skillTargetSocket = param.CharSkillComp.SkillTargetSocket;
		CharacterActorComponent component = target.Entity.GetComponent<CharacterActorComponent>();
		if (!string.IsNullOrEmpty(skillTargetSocket) && component != null)
		{
			FVectorDouble fvectorDouble = component.Actor.Mesh.D_GetSocketLocation(FNameUtil.GetDynamicFName(skillTargetSocket).Value);
			this.TmpVector.DeepCopy(fvectorDouble);
		}
		else
		{
			BaseActorComponent component2 = target.Entity.GetComponent<BaseActorComponent>();
			this.TmpVector.DeepCopy(component2.ActorLocationProxy);
		}
		return this.TmpVector;
	}

	// Token: 0x0600448C RID: 17548 RVA: 0x0008640F File Offset: 0x0008460F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAddMoveByInputDirect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddMoveByInputDirect.TsAnimNotifyStateAddMoveByInputDirect_C");
		}
		return TsAnimNotifyStateAddMoveByInputDirect._ClassPtr;
	}

	// Token: 0x0600448D RID: 17549 RVA: 0x00086434 File Offset: 0x00084634
	public TsAnimNotifyStateAddMoveByInputDirect() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddMoveByInputDirect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600448E RID: 17550 RVA: 0x0008645C File Offset: 0x0008465C
	[NullableContext(1)]
	public TsAnimNotifyStateAddMoveByInputDirect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAddMoveByInputDirect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600448F RID: 17551 RVA: 0x0008648F File Offset: 0x0008468F
	protected TsAnimNotifyStateAddMoveByInputDirect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004490 RID: 17552 RVA: 0x00086498 File Offset: 0x00084698
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004491 RID: 17553 RVA: 0x000864D4 File Offset: 0x000846D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004492 RID: 17554 RVA: 0x00086510 File Offset: 0x00084710
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004493 RID: 17555 RVA: 0x00086543 File Offset: 0x00084743
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001221 RID: 4641
	[Nullable(1)]
	private static Dictionary<int, AddMoveParams> paramMap;

	// Token: 0x04001222 RID: 4642
	private float Acceleration;

	// Token: 0x04001223 RID: 4643
	private float Deceleration;

	// Token: 0x04001224 RID: 4644
	private float TotalTime;

	// Token: 0x04001225 RID: 4645
	private Vector TmpVector;

	// Token: 0x04001226 RID: 4646
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAddMoveByInputDirect.TsAnimNotifyStateAddMoveByInputDirect_C";

	// Token: 0x04001227 RID: 4647
	private static IntPtr _ClassPtr;

	// Token: 0x04001228 RID: 4648
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001229 RID: 4649
	private static int __PropertyOffset_MaxSpeed;

	// Token: 0x0400122A RID: 4650
	private static int __PropertyOffset_AccelerationTime;

	// Token: 0x0400122B RID: 4651
	private static int __PropertyOffset_DecelerationTime;

	// Token: 0x0400122C RID: 4652
	private static int __PropertyOffset_SpeedCurve;

	// Token: 0x0400122D RID: 4653
	private static int __PropertyOffset_Distance;
}
