using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D95 RID: 3477
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateTurnAdd.TsAnimNotifyStateTurnAdd_C")]
public class TsAnimNotifyStateTurnAdd : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004D33 RID: 19763 RVA: 0x000AD886 File Offset: 0x000ABA86
	static TsAnimNotifyStateTurnAdd()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateTurnAdd.CreateStaticDefaultValue), new Action(TsAnimNotifyStateTurnAdd.ResetStaticDefaultValue));
	}

	// Token: 0x06004D34 RID: 19764 RVA: 0x000AD8A5 File Offset: 0x000ABAA5
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateTurnAdd.IsInit = false;
		TsAnimNotifyStateTurnAdd.CachedMap = new Dictionary<AActor, TurningParams>();
	}

	// Token: 0x06004D35 RID: 19765 RVA: 0x000AD8B7 File Offset: 0x000ABAB7
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateTurnAdd.IsInit = false;
		TsAnimNotifyStateTurnAdd.CachedMap = null;
	}

	// Token: 0x170004AA RID: 1194
	// (get) Token: 0x06004D36 RID: 19766 RVA: 0x000AD8C5 File Offset: 0x000ABAC5
	// (set) Token: 0x06004D37 RID: 19767 RVA: 0x000AD8D5 File Offset: 0x000ABAD5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int AffectType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateTurnAdd.__PropertyOffset_AffectType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateTurnAdd.__PropertyOffset_AffectType) = value;
		}
	}

	// Token: 0x06004D38 RID: 19768 RVA: 0x000AD8E8 File Offset: 0x000ABAE8
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

	// Token: 0x06004D39 RID: 19769 RVA: 0x000AD990 File Offset: 0x000ABB90
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		if (characterActorComponent.GetSequenceBinding())
		{
			return false;
		}
		if (!characterActorComponent.IsMoveAutonomousProxy)
		{
			return false;
		}
		TsAnimNotifyStateTurnAdd.Initialize();
		TurningParams turningParams = new TurningParams(totalDuration);
		turningParams.IsRootMotionValid = characterActorComponent.NeedFixBornLocation;
		TsAnimNotifyStateTurnAdd.CachedMap.Add(owner, turningParams);
		NpcMoveComponent component = characterActorComponent.Entity.GetComponent<NpcMoveComponent>();
		if (component != null)
		{
			component.IsTurning = true;
		}
		return true;
	}

	// Token: 0x06004D3A RID: 19770 RVA: 0x000ADA1C File Offset: 0x000ABC1C
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

	// Token: 0x06004D3B RID: 19771 RVA: 0x000ADAC4 File Offset: 0x000ABCC4
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		if (characterActorComponent.GetSequenceBinding())
		{
			return false;
		}
		if (!characterActorComponent.IsMoveAutonomousProxy)
		{
			return false;
		}
		CharacterAnimationComponent component = characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		TurningParams turningParams;
		if (!TsAnimNotifyStateTurnAdd.CachedMap.TryGetValue(tsBaseCharacter, out turningParams))
		{
			return false;
		}
		if (!turningParams.IsInit)
		{
			turningParams.CalcTurningRate(characterActorComponent, base.CurrentTimeLength, frameDeltaTime);
			return turningParams.NeedTurn;
		}
		if (!turningParams.NeedTurn)
		{
			return false;
		}
		float addRate = turningParams.AddRate;
		float mainAnimsCurveValueWithDelta = component.MainAnimInstance.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_LOOK, 0f, false, false);
		float preFrameAngle = turningParams.PreFrameAngle;
		CharacterDriveVehicleComponent component2 = characterActorComponent.Entity.GetComponent<CharacterDriveVehicleComponent>();
		bool flag = component2 != null && component2.IsOnVehicle;
		if (flag)
		{
			characterActorComponent.SetForbidSettingLocAndRot(false, EForbidSettingLocAndRotReason.RideVehicle);
		}
		TsAnimNotifyStateTurnAdd.TmpRotator.Yaw = addRate * (mainAnimsCurveValueWithDelta - preFrameAngle);
		characterActorComponent.AddActorLocalRotation(TsAnimNotifyStateTurnAdd.TmpRotator, "TsAnimNotifyStateTurnAdd", false);
		turningParams.PreFrameAngle = mainAnimsCurveValueWithDelta;
		if (flag)
		{
			characterActorComponent.SetForbidSettingLocAndRot(true, EForbidSettingLocAndRotReason.RideVehicle);
		}
		return true;
	}

	// Token: 0x06004D3C RID: 19772 RVA: 0x000ADBF0 File Offset: 0x000ABDF0
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

	// Token: 0x06004D3D RID: 19773 RVA: 0x000ADC90 File Offset: 0x000ABE90
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		if (characterActorComponent.GetSequenceBinding())
		{
			return false;
		}
		if (!characterActorComponent.IsMoveAutonomousProxy)
		{
			return false;
		}
		Dictionary<AActor, TurningParams> cachedMap = TsAnimNotifyStateTurnAdd.CachedMap;
		if (cachedMap != null)
		{
			cachedMap.Remove(owner);
		}
		NpcMoveComponent component = characterActorComponent.Entity.GetComponent<NpcMoveComponent>();
		if (component != null)
		{
			component.IsTurning = false;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "TurnAdd End";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", characterActorComponent.Entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Current", characterActorComponent.ActorRotationProxy);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Input", characterActorComponent.InputRotatorProxy);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		return true;
	}

	// Token: 0x06004D3E RID: 19774 RVA: 0x000ADD90 File Offset: 0x000ABF90
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

	// Token: 0x06004D3F RID: 19775 RVA: 0x000ADE0B File Offset: 0x000AC00B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "根据RootLook曲线控制角色转向";
	}

	// Token: 0x06004D40 RID: 19776 RVA: 0x000ADE12 File Offset: 0x000AC012
	private static void Initialize()
	{
		if (TsAnimNotifyStateTurnAdd.IsInit)
		{
			return;
		}
		TsAnimNotifyStateTurnAdd.CachedMap = new Dictionary<AActor, TurningParams>();
		TsAnimNotifyStateTurnAdd.TmpRotator = new FRotator(0f, 0f, 0f);
		TsAnimNotifyStateTurnAdd.IsInit = true;
	}

	// Token: 0x06004D41 RID: 19777 RVA: 0x000ADE45 File Offset: 0x000AC045
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateTurnAdd._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateTurnAdd.TsAnimNotifyStateTurnAdd_C");
		}
		return TsAnimNotifyStateTurnAdd._ClassPtr;
	}

	// Token: 0x06004D42 RID: 19778 RVA: 0x000ADE6C File Offset: 0x000AC06C
	public TsAnimNotifyStateTurnAdd() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateTurnAdd.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004D43 RID: 19779 RVA: 0x000ADE94 File Offset: 0x000AC094
	[NullableContext(1)]
	public TsAnimNotifyStateTurnAdd(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateTurnAdd.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004D44 RID: 19780 RVA: 0x000ADEC7 File Offset: 0x000AC0C7
	protected TsAnimNotifyStateTurnAdd(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004D45 RID: 19781 RVA: 0x000ADED0 File Offset: 0x000AC0D0
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004D46 RID: 19782 RVA: 0x000ADF0C File Offset: 0x000AC10C
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004D47 RID: 19783 RVA: 0x000ADF48 File Offset: 0x000AC148
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004D48 RID: 19784 RVA: 0x000ADF7B File Offset: 0x000AC17B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001638 RID: 5688
	private static bool IsInit;

	// Token: 0x04001639 RID: 5689
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<AActor, TurningParams> CachedMap;

	// Token: 0x0400163A RID: 5690
	[StaticVariableRuleIgnore]
	private static FRotator TmpRotator;

	// Token: 0x0400163B RID: 5691
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateTurnAdd.TsAnimNotifyStateTurnAdd_C";

	// Token: 0x0400163C RID: 5692
	private static IntPtr _ClassPtr;

	// Token: 0x0400163D RID: 5693
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400163E RID: 5694
	private static int __PropertyOffset_AffectType;
}
