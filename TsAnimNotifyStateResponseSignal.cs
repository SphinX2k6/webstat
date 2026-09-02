using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D6C RID: 3436
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateResponseSignal.TsAnimNotifyStateResponseSignal_C")]
public class TsAnimNotifyStateResponseSignal : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x06004A48 RID: 19016 RVA: 0x000A1C2B File Offset: 0x0009FE2B
	// (set) Token: 0x06004A49 RID: 19017 RVA: 0x000A1C3B File Offset: 0x0009FE3B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Signal
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateResponseSignal.__PropertyOffset_Signal);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateResponseSignal.__PropertyOffset_Signal) = value;
		}
	}

	// Token: 0x06004A4A RID: 19018 RVA: 0x000A1C4C File Offset: 0x0009FE4C
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

	// Token: 0x06004A4B RID: 19019 RVA: 0x000A1CF4 File Offset: 0x0009FEF4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((aactor as TsBaseCharacter).EntityId);
		CharacterInteractivePerformComponent characterInteractivePerformComponent;
		if (entityById == null)
		{
			characterInteractivePerformComponent = null;
		}
		else
		{
			WorldEntity entity = entityById.Entity;
			characterInteractivePerformComponent = ((entity != null) ? entity.GetComponent<CharacterInteractivePerformComponent>() : null);
		}
		CharacterInteractivePerformComponent characterInteractivePerformComponent2 = characterInteractivePerformComponent;
		CharacterHoldingHandsComponent characterHoldingHandsComponent;
		if (entityById == null)
		{
			characterHoldingHandsComponent = null;
		}
		else
		{
			WorldEntity entity2 = entityById.Entity;
			characterHoldingHandsComponent = ((entity2 != null) ? entity2.GetComponent<CharacterHoldingHandsComponent>() : null);
		}
		CharacterHoldingHandsComponent characterHoldingHandsComponent2 = characterHoldingHandsComponent;
		if (characterInteractivePerformComponent2 == null || characterHoldingHandsComponent2 == null)
		{
			return false;
		}
		characterInteractivePerformComponent2.AddResponseSignal(this.Signal, "");
		return true;
	}

	// Token: 0x06004A4C RID: 19020 RVA: 0x000A1D7C File Offset: 0x0009FF7C
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

	// Token: 0x06004A4D RID: 19021 RVA: 0x000A1E1C File Offset: 0x000A001C
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((aactor as TsBaseCharacter).EntityId);
		CharacterInteractivePerformComponent characterInteractivePerformComponent;
		if (entityById == null)
		{
			characterInteractivePerformComponent = null;
		}
		else
		{
			WorldEntity entity = entityById.Entity;
			characterInteractivePerformComponent = ((entity != null) ? entity.GetComponent<CharacterInteractivePerformComponent>() : null);
		}
		CharacterInteractivePerformComponent characterInteractivePerformComponent2 = characterInteractivePerformComponent;
		CharacterHoldingHandsComponent characterHoldingHandsComponent;
		if (entityById == null)
		{
			characterHoldingHandsComponent = null;
		}
		else
		{
			WorldEntity entity2 = entityById.Entity;
			characterHoldingHandsComponent = ((entity2 != null) ? entity2.GetComponent<CharacterHoldingHandsComponent>() : null);
		}
		CharacterHoldingHandsComponent characterHoldingHandsComponent2 = characterHoldingHandsComponent;
		if (characterInteractivePerformComponent2 == null || characterHoldingHandsComponent2 == null)
		{
			return false;
		}
		characterInteractivePerformComponent2.RemoveResponseSignal(this.Signal);
		return true;
	}

	// Token: 0x06004A4E RID: 19022 RVA: 0x000A1EA0 File Offset: 0x000A00A0
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

	// Token: 0x06004A4F RID: 19023 RVA: 0x000A1F1B File Offset: 0x000A011B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "响应交互动作";
	}

	// Token: 0x06004A50 RID: 19024 RVA: 0x000A1F22 File Offset: 0x000A0122
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateResponseSignal._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateResponseSignal.TsAnimNotifyStateResponseSignal_C");
		}
		return TsAnimNotifyStateResponseSignal._ClassPtr;
	}

	// Token: 0x06004A51 RID: 19025 RVA: 0x000A1F48 File Offset: 0x000A0148
	public TsAnimNotifyStateResponseSignal() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateResponseSignal.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004A52 RID: 19026 RVA: 0x000A1F70 File Offset: 0x000A0170
	[NullableContext(1)]
	public TsAnimNotifyStateResponseSignal(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateResponseSignal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004A53 RID: 19027 RVA: 0x000A1FA3 File Offset: 0x000A01A3
	protected TsAnimNotifyStateResponseSignal(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004A54 RID: 19028 RVA: 0x000A1FAC File Offset: 0x000A01AC
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004A55 RID: 19029 RVA: 0x000A1FE8 File Offset: 0x000A01E8
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004A56 RID: 19030 RVA: 0x000A201B File Offset: 0x000A021B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001506 RID: 5382
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateResponseSignal.TsAnimNotifyStateResponseSignal_C";

	// Token: 0x04001507 RID: 5383
	private static IntPtr _ClassPtr;

	// Token: 0x04001508 RID: 5384
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001509 RID: 5385
	private static int __PropertyOffset_Signal;
}
