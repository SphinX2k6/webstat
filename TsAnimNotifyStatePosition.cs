using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D63 RID: 3427
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePosition.TsAnimNotifyStatePosition_C")]
public class TsAnimNotifyStatePosition : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x06004983 RID: 18819 RVA: 0x0009E467 File Offset: 0x0009C667
	// (set) Token: 0x06004984 RID: 18820 RVA: 0x0009E47B File Offset: 0x0009C67B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector 移动速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePosition.__PropertyOffset_移动速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePosition.__PropertyOffset_移动速度) = value;
		}
	}

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x06004985 RID: 18821 RVA: 0x0009E490 File Offset: 0x0009C690
	// (set) Token: 0x06004986 RID: 18822 RVA: 0x0009E4A4 File Offset: 0x0009C6A4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat 速度曲线
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStatePosition.__PropertyOffset_速度曲线);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStatePosition.__PropertyOffset_速度曲线, value);
		}
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x06004987 RID: 18823 RVA: 0x0009E4B9 File Offset: 0x0009C6B9
	// (set) Token: 0x06004988 RID: 18824 RVA: 0x0009E4C9 File Offset: 0x0009C6C9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否持续朝向目标
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePosition.__PropertyOffset_是否持续朝向目标) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePosition.__PropertyOffset_是否持续朝向目标) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004989 RID: 18825 RVA: 0x0009E4DC File Offset: 0x0009C6DC
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

	// Token: 0x0600498A RID: 18826 RVA: 0x0009E584 File Offset: 0x0009C784
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			object obj;
			if (characterActorComponent == null)
			{
				obj = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				obj = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				FVector 移动速度 = this.移动速度;
				obj2.SetAddMoveWithMesh(meshComp, new FVectorDouble(ref 移动速度), totalDuration, this.速度曲线);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600498B RID: 18827 RVA: 0x0009E5E4 File Offset: 0x0009C7E4
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

	// Token: 0x0600498C RID: 18828 RVA: 0x0009E68C File Offset: 0x0009C88C
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if (!this.是否持续朝向目标)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			object obj;
			if (characterActorComponent == null)
			{
				obj = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				obj = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				FTransformDouble ftransformDouble = tsBaseCharacter.D_GetTransform();
				FVector 移动速度 = this.移动速度;
				obj2.SetAddMoveWorldSpeedWithMesh(meshComp, UKismetMathLibrary.D_TransformDirection(ftransformDouble, new FVectorDouble(ref 移动速度)));
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600498D RID: 18829 RVA: 0x0009E6FC File Offset: 0x0009C8FC
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

	// Token: 0x0600498E RID: 18830 RVA: 0x0009E79C File Offset: 0x0009C99C
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			object obj;
			if (characterActorComponent == null)
			{
				obj = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				obj = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.StopAddMoveWithMesh(meshComp);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600498F RID: 18831 RVA: 0x0009E7E8 File Offset: 0x0009C9E8
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

	// Token: 0x06004990 RID: 18832 RVA: 0x0009E863 File Offset: 0x0009CA63
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "位移到坐标点";
	}

	// Token: 0x06004991 RID: 18833 RVA: 0x0009E86A File Offset: 0x0009CA6A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStatePosition._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePosition.TsAnimNotifyStatePosition_C");
		}
		return TsAnimNotifyStatePosition._ClassPtr;
	}

	// Token: 0x06004992 RID: 18834 RVA: 0x0009E890 File Offset: 0x0009CA90
	public TsAnimNotifyStatePosition() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePosition.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004993 RID: 18835 RVA: 0x0009E8B8 File Offset: 0x0009CAB8
	[NullableContext(1)]
	public TsAnimNotifyStatePosition(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePosition.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004994 RID: 18836 RVA: 0x0009E8EB File Offset: 0x0009CAEB
	protected TsAnimNotifyStatePosition(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004995 RID: 18837 RVA: 0x0009E8F4 File Offset: 0x0009CAF4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004996 RID: 18838 RVA: 0x0009E930 File Offset: 0x0009CB30
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004997 RID: 18839 RVA: 0x0009E96C File Offset: 0x0009CB6C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004998 RID: 18840 RVA: 0x0009E99F File Offset: 0x0009CB9F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001499 RID: 5273
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePosition.TsAnimNotifyStatePosition_C";

	// Token: 0x0400149A RID: 5274
	private static IntPtr _ClassPtr;

	// Token: 0x0400149B RID: 5275
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400149C RID: 5276
	private static int __PropertyOffset_移动速度;

	// Token: 0x0400149D RID: 5277
	private static int __PropertyOffset_速度曲线;

	// Token: 0x0400149E RID: 5278
	private static int __PropertyOffset_是否持续朝向目标;
}
