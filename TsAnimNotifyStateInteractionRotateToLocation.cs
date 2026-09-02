using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D54 RID: 3412
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateInteractionRotateToLocation.TsAnimNotifyStateInteractionRotateToLocation_C")]
public class TsAnimNotifyStateInteractionRotateToLocation : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600487A RID: 18554 RVA: 0x00099924 File Offset: 0x00097B24
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((MeshComp != null) ? MeshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((Animation != null) ? Animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = TotalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600487B RID: 18555 RVA: 0x000999CC File Offset: 0x00097BCC
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
	{
		AActor owner = MeshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = ((TsBaseCharacter)owner).CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		CharacterActionComponent characterActionComponent = (entity != null) ? entity.GetComponent<CharacterActionComponent>() : null;
		CharacterActorComponent characterActorComponent2 = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		if (characterActionComponent == null || !characterActionComponent.Valid || characterActorComponent2 == null || !characterActorComponent2.Valid)
		{
			return false;
		}
		Vector vector = Vector.Create();
		characterActionComponent.GetInteractionTargetLocation().Subtraction(characterActorComponent2.ActorLocationProxy, vector);
		this.Rotator = (float)vector.HeadingAngle() * 57.29578f;
		float num = characterActorComponent2.ActorRotationProxy.Yaw - this.Rotator;
		if (num > 180f)
		{
			num = 360f - num;
		}
		num = Math.Abs(num);
		this.RotateSpeed = num / TotalDuration;
		return true;
	}

	// Token: 0x0600487C RID: 18556 RVA: 0x00099A9C File Offset: 0x00097C9C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((MeshComp != null) ? MeshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((Animation != null) ? Animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = FrameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600487D RID: 18557 RVA: 0x00099B44 File Offset: 0x00097D44
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = MeshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		CharacterMoveComponent characterMoveComponent;
		if (characterActorComponent == null)
		{
			characterMoveComponent = null;
		}
		else
		{
			Entity entity = characterActorComponent.Entity;
			characterMoveComponent = ((entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null);
		}
		CharacterMoveComponent characterMoveComponent2 = characterMoveComponent;
		if (characterMoveComponent2 == null)
		{
			return false;
		}
		characterMoveComponent2.SmoothCharacterRotationByValue(0f, this.Rotator, 0f, this.RotateSpeed, FrameDeltaTime, "TsAnimNotifyStateInteractionRotateToLocation");
		return true;
	}

	// Token: 0x0600487E RID: 18558 RVA: 0x00099BAC File Offset: 0x00097DAC
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

	// Token: 0x0600487F RID: 18559 RVA: 0x00099C27 File Offset: 0x00097E27
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置交互动作旋转和位置";
	}

	// Token: 0x06004880 RID: 18560 RVA: 0x00099C2E File Offset: 0x00097E2E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateInteractionRotateToLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateInteractionRotateToLocation.TsAnimNotifyStateInteractionRotateToLocation_C");
		}
		return TsAnimNotifyStateInteractionRotateToLocation._ClassPtr;
	}

	// Token: 0x06004881 RID: 18561 RVA: 0x00099C54 File Offset: 0x00097E54
	public TsAnimNotifyStateInteractionRotateToLocation() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateInteractionRotateToLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004882 RID: 18562 RVA: 0x00099C7C File Offset: 0x00097E7C
	[NullableContext(1)]
	public TsAnimNotifyStateInteractionRotateToLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateInteractionRotateToLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004883 RID: 18563 RVA: 0x00099CAF File Offset: 0x00097EAF
	protected TsAnimNotifyStateInteractionRotateToLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004884 RID: 18564 RVA: 0x00099CB8 File Offset: 0x00097EB8
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004885 RID: 18565 RVA: 0x00099CF4 File Offset: 0x00097EF4
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004886 RID: 18566 RVA: 0x00099D2D File Offset: 0x00097F2D
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400142B RID: 5163
	private float RotateSpeed;

	// Token: 0x0400142C RID: 5164
	private float Rotator;

	// Token: 0x0400142D RID: 5165
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateInteractionRotateToLocation.TsAnimNotifyStateInteractionRotateToLocation_C";

	// Token: 0x0400142E RID: 5166
	private static IntPtr _ClassPtr;

	// Token: 0x0400142F RID: 5167
	private static IntPtr _ClassDefaultObjectPtr;
}
