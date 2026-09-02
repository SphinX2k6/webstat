using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D97 RID: 3479
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateTurnModelBlackboard.TsAnimNotifyStateTurnModelBlackboard_C")]
public class TsAnimNotifyStateTurnModelBlackboard : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004AB RID: 1195
	// (get) Token: 0x06004D4A RID: 19786 RVA: 0x000ADFC1 File Offset: 0x000AC1C1
	// (set) Token: 0x06004D4B RID: 19787 RVA: 0x000ADFD5 File Offset: 0x000AC1D5
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TurnModelKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_TurnModelKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_TurnModelKey)), value);
		}
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06004D4C RID: 19788 RVA: 0x000ADFEA File Offset: 0x000AC1EA
	// (set) Token: 0x06004D4D RID: 19789 RVA: 0x000ADFFE File Offset: 0x000AC1FE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat Curve
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_Curve);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_Curve, value);
		}
	}

	// Token: 0x170004AD RID: 1197
	// (get) Token: 0x06004D4E RID: 19790 RVA: 0x000AE013 File Offset: 0x000AC213
	// (set) Token: 0x06004D4F RID: 19791 RVA: 0x000AE023 File Offset: 0x000AC223
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool TurnActorOnEnd
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_TurnActorOnEnd) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_TurnActorOnEnd) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06004D50 RID: 19792 RVA: 0x000AE034 File Offset: 0x000AC234
	// (set) Token: 0x06004D51 RID: 19793 RVA: 0x000AE044 File Offset: 0x000AC244
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Absolute
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_Absolute) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateTurnModelBlackboard.__PropertyOffset_Absolute) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004D52 RID: 19794 RVA: 0x000AE055 File Offset: 0x000AC255
	private void Init()
	{
		if (this.ParamsMap != null)
		{
			return;
		}
		this.ParamsMap = new Dictionary<AActor, TurnModelBlackboardParams>();
	}

	// Token: 0x06004D53 RID: 19795 RVA: 0x000AE06C File Offset: 0x000AC26C
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

	// Token: 0x06004D54 RID: 19796 RVA: 0x000AE114 File Offset: 0x000AC314
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Init();
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
		CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		int id = entity.Id;
		if (string.IsNullOrEmpty(this.TurnModelKey))
		{
			return false;
		}
		Aki.Protocol.Rotator rotatorValueByEntity = ControllerBase<BlackboardController>.Instance.GetRotatorValueByEntity(id, this.TurnModelKey);
		if (rotatorValueByEntity == null)
		{
			return false;
		}
		if (this.Absolute)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			global::Rotator rotator = (characterActorComponent != null) ? characterActorComponent.ActorRotationProxy : null;
			if (rotator != null)
			{
				rotatorValueByEntity.Pitch -= rotator.Pitch;
				rotatorValueByEntity.Yaw -= rotator.Yaw;
				rotatorValueByEntity.Roll -= rotator.Roll;
			}
		}
		TurnModelBlackboardParams turnModelBlackboardParams = new TurnModelBlackboardParams();
		turnModelBlackboardParams.TotalDuration = totalDuration;
		turnModelBlackboardParams.TurnModel.FromUeRotator(rotatorValueByEntity);
		turnModelBlackboardParams.TurnModel.Quaternion(turnModelBlackboardParams.TurnModelQuat);
		turnModelBlackboardParams.RunTime = 0f;
		this.ParamsMap[owner] = turnModelBlackboardParams;
		return true;
	}

	// Token: 0x06004D55 RID: 19797 RVA: 0x000AE23C File Offset: 0x000AC43C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float deltaTime)
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
			ptr2->FrameDeltaTime = deltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004D56 RID: 19798 RVA: 0x000AE2E4 File Offset: 0x000AC4E4
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float deltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterAnimationComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterAnimationComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		TurnModelBlackboardParams turnModelBlackboardParams;
		if (!this.ParamsMap.TryGetValue(tsBaseCharacter, out turnModelBlackboardParams))
		{
			return false;
		}
		float totalDuration = turnModelBlackboardParams.TotalDuration;
		Quat turnModelQuat = turnModelBlackboardParams.TurnModelQuat;
		float runTime = turnModelBlackboardParams.RunTime;
		float num = runTime + deltaTime;
		float slerp;
		if (this.Curve != null)
		{
			slerp = this.Curve.GetFloatValue(num / totalDuration) - this.Curve.GetFloatValue(runTime / totalDuration);
		}
		else
		{
			slerp = deltaTime / totalDuration;
		}
		Quat quat = Quat.Create(0f, 0f, 0f, 1f);
		Quat.Slerp(Quat.IdentityProxy, turnModelQuat, slerp, quat);
		component.AddModelQuat(quat, true);
		turnModelBlackboardParams.RunTime = num;
		return true;
	}

	// Token: 0x06004D57 RID: 19799 RVA: 0x000AE3CC File Offset: 0x000AC5CC
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

	// Token: 0x06004D58 RID: 19800 RVA: 0x000AE46C File Offset: 0x000AC66C
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = (owner as TsBaseCharacter).CharacterActorComponent.Entity;
		TurnModelBlackboardParams turnModelBlackboardParams;
		if (!this.ParamsMap.TryGetValue(owner, out turnModelBlackboardParams))
		{
			return false;
		}
		this.ParamsMap.Remove(owner);
		if (this.TurnActorOnEnd)
		{
			characterActorComponent.AddActorLocalRotation(turnModelBlackboardParams.TurnModel.ToUeRotator(), "TsAnimNotifyStateTurnModelBlackboard", false);
		}
		CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
		if (component == null)
		{
			return false;
		}
		component.ResetModelQuat();
		return true;
	}

	// Token: 0x06004D59 RID: 19801 RVA: 0x000AE4FC File Offset: 0x000AC6FC
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

	// Token: 0x06004D5A RID: 19802 RVA: 0x000AE577 File Offset: 0x000AC777
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "黑板旋转角色";
	}

	// Token: 0x06004D5B RID: 19803 RVA: 0x000AE57E File Offset: 0x000AC77E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateTurnModelBlackboard._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateTurnModelBlackboard.TsAnimNotifyStateTurnModelBlackboard_C");
		}
		return TsAnimNotifyStateTurnModelBlackboard._ClassPtr;
	}

	// Token: 0x06004D5C RID: 19804 RVA: 0x000AE5A4 File Offset: 0x000AC7A4
	public TsAnimNotifyStateTurnModelBlackboard() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateTurnModelBlackboard.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004D5D RID: 19805 RVA: 0x000AE5CC File Offset: 0x000AC7CC
	[NullableContext(1)]
	public TsAnimNotifyStateTurnModelBlackboard(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateTurnModelBlackboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004D5E RID: 19806 RVA: 0x000AE5FF File Offset: 0x000AC7FF
	protected TsAnimNotifyStateTurnModelBlackboard(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004D5F RID: 19807 RVA: 0x000AE614 File Offset: 0x000AC814
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004D60 RID: 19808 RVA: 0x000AE650 File Offset: 0x000AC850
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004D61 RID: 19809 RVA: 0x000AE68C File Offset: 0x000AC88C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004D62 RID: 19810 RVA: 0x000AE6BF File Offset: 0x000AC8BF
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001643 RID: 5699
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<AActor, TurnModelBlackboardParams> ParamsMap = new Dictionary<AActor, TurnModelBlackboardParams>();

	// Token: 0x04001644 RID: 5700
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateTurnModelBlackboard.TsAnimNotifyStateTurnModelBlackboard_C";

	// Token: 0x04001645 RID: 5701
	private static IntPtr _ClassPtr;

	// Token: 0x04001646 RID: 5702
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001647 RID: 5703
	private static int __PropertyOffset_TurnModelKey;

	// Token: 0x04001648 RID: 5704
	private static int __PropertyOffset_Curve;

	// Token: 0x04001649 RID: 5705
	private static int __PropertyOffset_TurnActorOnEnd;

	// Token: 0x0400164A RID: 5706
	private static int __PropertyOffset_Absolute;
}
