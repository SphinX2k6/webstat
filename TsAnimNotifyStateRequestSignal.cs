using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D6B RID: 3435
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRequestSignal.TsAnimNotifyStateRequestSignal_C")]
public class TsAnimNotifyStateRequestSignal : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06004A39 RID: 19001 RVA: 0x000A17CF File Offset: 0x0009F9CF
	// (set) Token: 0x06004A3A RID: 19002 RVA: 0x000A17DF File Offset: 0x0009F9DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Signal
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRequestSignal.__PropertyOffset_Signal);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRequestSignal.__PropertyOffset_Signal) = value;
		}
	}

	// Token: 0x06004A3B RID: 19003 RVA: 0x000A17F0 File Offset: 0x0009F9F0
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

	// Token: 0x06004A3C RID: 19004 RVA: 0x000A1898 File Offset: 0x0009FA98
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((aactor as TsBaseCharacter).EntityId);
		bool flag;
		if (entityById == null)
		{
			flag = (null != null);
		}
		else
		{
			WorldEntity entity = entityById.Entity;
			flag = (((entity != null) ? entity.GetComponent<CharacterInteractivePerformComponent>() : null) != null);
		}
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
		if (!flag || characterHoldingHandsComponent2 == null)
		{
			return false;
		}
		Entity holdingHandsOtherEntity = characterHoldingHandsComponent2.GetHoldingHandsOtherEntity();
		CreatureDataComponent creatureDataComponent = (holdingHandsOtherEntity != null) ? holdingHandsOtherEntity.GetComponent<CreatureDataComponent>() : null;
		CharacterInteractivePerformComponent characterInteractivePerformComponent = (holdingHandsOtherEntity != null) ? holdingHandsOtherEntity.GetComponent<CharacterInteractivePerformComponent>() : null;
		if (characterInteractivePerformComponent == null || creatureDataComponent == null)
		{
			return false;
		}
		RequestPerformParams request = new RequestPerformParams
		{
			Signal = this.Signal,
			Source = entityById.Entity
		};
		characterInteractivePerformComponent.AddRequestSignal(request);
		return true;
	}

	// Token: 0x06004A3D RID: 19005 RVA: 0x000A1960 File Offset: 0x0009FB60
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

	// Token: 0x06004A3E RID: 19006 RVA: 0x000A1A00 File Offset: 0x0009FC00
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
		Entity holdingHandsOtherEntity = characterHoldingHandsComponent2.GetHoldingHandsOtherEntity();
		CharacterInteractivePerformComponent characterInteractivePerformComponent3 = (holdingHandsOtherEntity != null) ? holdingHandsOtherEntity.GetComponent<CharacterInteractivePerformComponent>() : null;
		if (characterInteractivePerformComponent3 == null)
		{
			return false;
		}
		characterInteractivePerformComponent3.RemoveRequestSignal(this.Signal);
		return true;
	}

	// Token: 0x06004A3F RID: 19007 RVA: 0x000A1A9C File Offset: 0x0009FC9C
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

	// Token: 0x06004A40 RID: 19008 RVA: 0x000A1B17 File Offset: 0x0009FD17
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "请求交互动作";
	}

	// Token: 0x06004A41 RID: 19009 RVA: 0x000A1B1E File Offset: 0x0009FD1E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRequestSignal._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRequestSignal.TsAnimNotifyStateRequestSignal_C");
		}
		return TsAnimNotifyStateRequestSignal._ClassPtr;
	}

	// Token: 0x06004A42 RID: 19010 RVA: 0x000A1B44 File Offset: 0x0009FD44
	public TsAnimNotifyStateRequestSignal() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRequestSignal.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004A43 RID: 19011 RVA: 0x000A1B6C File Offset: 0x0009FD6C
	[NullableContext(1)]
	public TsAnimNotifyStateRequestSignal(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRequestSignal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004A44 RID: 19012 RVA: 0x000A1B9F File Offset: 0x0009FD9F
	protected TsAnimNotifyStateRequestSignal(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004A45 RID: 19013 RVA: 0x000A1BA8 File Offset: 0x0009FDA8
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004A46 RID: 19014 RVA: 0x000A1BE4 File Offset: 0x0009FDE4
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004A47 RID: 19015 RVA: 0x000A1C17 File Offset: 0x0009FE17
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001502 RID: 5378
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRequestSignal.TsAnimNotifyStateRequestSignal_C";

	// Token: 0x04001503 RID: 5379
	private static IntPtr _ClassPtr;

	// Token: 0x04001504 RID: 5380
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001505 RID: 5381
	private static int __PropertyOffset_Signal;
}
