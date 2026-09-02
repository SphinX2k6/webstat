using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D4E RID: 3406
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideActor.TsAnimNotifyStateHideActor_C")]
public class TsAnimNotifyStateHideActor : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600481C RID: 18460 RVA: 0x00097EC3 File Offset: 0x000960C3
	static TsAnimNotifyStateHideActor()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateHideActor.CreateStaticDefaultValue), new Action(TsAnimNotifyStateHideActor.ResetStaticDefaultValue));
	}

	// Token: 0x0600481D RID: 18461 RVA: 0x00097EE2 File Offset: 0x000960E2
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateHideActor.disableActorHandleMap = new Dictionary<int, int>();
	}

	// Token: 0x0600481E RID: 18462 RVA: 0x00097EEE File Offset: 0x000960EE
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateHideActor.disableActorHandleMap = null;
	}

	// Token: 0x0600481F RID: 18463 RVA: 0x00097EF8 File Offset: 0x000960F8
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

	// Token: 0x06004820 RID: 18464 RVA: 0x00097FA0 File Offset: 0x000961A0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		if (owner is TsBaseCharacter)
		{
			if ((owner as TsBaseCharacter).CharacterActorComponent != null)
			{
				int value = (owner as TsBaseCharacter).CharacterActorComponent.DisableActor("TsAnimNotifyStateHideActor");
				TsAnimNotifyStateHideActor.disableActorHandleMap[(owner as TsBaseCharacter).CharacterActorComponent.Entity.Id] = value;
			}
			return true;
		}
		owner.SetActorHiddenInGame(true);
		return true;
	}

	// Token: 0x06004821 RID: 18465 RVA: 0x00098010 File Offset: 0x00096210
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

	// Token: 0x06004822 RID: 18466 RVA: 0x000980B0 File Offset: 0x000962B0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		if (owner is TsBaseCharacter)
		{
			if ((owner as TsBaseCharacter).CharacterActorComponent != null)
			{
				int id = (owner as TsBaseCharacter).CharacterActorComponent.Entity.Id;
				int handle;
				if (TsAnimNotifyStateHideActor.disableActorHandleMap.TryGetValue(id, out handle))
				{
					(owner as TsBaseCharacter).CharacterActorComponent.EnableActor(handle);
					TsAnimNotifyStateHideActor.disableActorHandleMap.Remove(id);
				}
			}
			return true;
		}
		owner.SetActorHiddenInGame(false);
		return true;
	}

	// Token: 0x06004823 RID: 18467 RVA: 0x0009812C File Offset: 0x0009632C
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

	// Token: 0x06004824 RID: 18468 RVA: 0x000981A7 File Offset: 0x000963A7
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "隐藏Actor";
	}

	// Token: 0x06004825 RID: 18469 RVA: 0x000981AE File Offset: 0x000963AE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateHideActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideActor.TsAnimNotifyStateHideActor_C");
		}
		return TsAnimNotifyStateHideActor._ClassPtr;
	}

	// Token: 0x06004826 RID: 18470 RVA: 0x000981D4 File Offset: 0x000963D4
	public TsAnimNotifyStateHideActor() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004827 RID: 18471 RVA: 0x000981FC File Offset: 0x000963FC
	[NullableContext(1)]
	public TsAnimNotifyStateHideActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004828 RID: 18472 RVA: 0x0009822F File Offset: 0x0009642F
	protected TsAnimNotifyStateHideActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004829 RID: 18473 RVA: 0x00098238 File Offset: 0x00096438
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600482A RID: 18474 RVA: 0x00098274 File Offset: 0x00096474
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600482B RID: 18475 RVA: 0x000982A7 File Offset: 0x000964A7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400140B RID: 5131
	[Nullable(1)]
	private static Dictionary<int, int> disableActorHandleMap;

	// Token: 0x0400140C RID: 5132
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideActor.TsAnimNotifyStateHideActor_C";

	// Token: 0x0400140D RID: 5133
	private static IntPtr _ClassPtr;

	// Token: 0x0400140E RID: 5134
	private static IntPtr _ClassDefaultObjectPtr;
}
