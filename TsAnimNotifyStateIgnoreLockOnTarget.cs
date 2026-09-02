using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D53 RID: 3411
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateIgnoreLockOnTarget.TsAnimNotifyStateIgnoreLockOnTarget_C")]
public class TsAnimNotifyStateIgnoreLockOnTarget : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003E7 RID: 999
	// (get) Token: 0x0600486A RID: 18538 RVA: 0x00099563 File Offset: 0x00097763
	// (set) Token: 0x0600486B RID: 18539 RVA: 0x00099577 File Offset: 0x00097777
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string IgnoreSocket
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateIgnoreLockOnTarget.__PropertyOffset_IgnoreSocket)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateIgnoreLockOnTarget.__PropertyOffset_IgnoreSocket)), value);
		}
	}

	// Token: 0x0600486C RID: 18540 RVA: 0x0009958C File Offset: 0x0009778C
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

	// Token: 0x0600486D RID: 18541 RVA: 0x00099634 File Offset: 0x00097834
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		return aactor is TsBaseCharacter && this.ForceIgnore((TsBaseCharacter)aactor, true);
	}

	// Token: 0x0600486E RID: 18542 RVA: 0x00099668 File Offset: 0x00097868
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

	// Token: 0x0600486F RID: 18543 RVA: 0x00099708 File Offset: 0x00097908
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		return aactor is TsBaseCharacter && this.ForceIgnore((TsBaseCharacter)aactor, false);
	}

	// Token: 0x06004870 RID: 18544 RVA: 0x0009973C File Offset: 0x0009793C
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

	// Token: 0x06004871 RID: 18545 RVA: 0x000997B7 File Offset: 0x000979B7
	protected override string GetNotifyName_Implementation()
	{
		return "强制忽略目标";
	}

	// Token: 0x06004872 RID: 18546 RVA: 0x000997C0 File Offset: 0x000979C0
	private bool ForceIgnore(TsBaseCharacter owner, bool enable)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null)
		{
			return false;
		}
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(owner, true);
		CharacterLockOnComponent characterLockOnComponent;
		if (getCurrentEntity == null)
		{
			characterLockOnComponent = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			characterLockOnComponent = ((entity != null) ? entity.GetComponent<CharacterLockOnComponent>() : null);
		}
		CharacterLockOnComponent characterLockOnComponent2 = characterLockOnComponent;
		if (characterLockOnComponent2 != null)
		{
			characterLockOnComponent2.ForceIgnore(new LockOnInfo(entityByActor, this.IgnoreSocket), enable);
			return true;
		}
		return false;
	}

	// Token: 0x06004873 RID: 18547 RVA: 0x00099817 File Offset: 0x00097A17
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateIgnoreLockOnTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateIgnoreLockOnTarget.TsAnimNotifyStateIgnoreLockOnTarget_C");
		}
		return TsAnimNotifyStateIgnoreLockOnTarget._ClassPtr;
	}

	// Token: 0x06004874 RID: 18548 RVA: 0x0009983C File Offset: 0x00097A3C
	public TsAnimNotifyStateIgnoreLockOnTarget() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateIgnoreLockOnTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004875 RID: 18549 RVA: 0x00099864 File Offset: 0x00097A64
	public TsAnimNotifyStateIgnoreLockOnTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateIgnoreLockOnTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004876 RID: 18550 RVA: 0x00099897 File Offset: 0x00097A97
	protected TsAnimNotifyStateIgnoreLockOnTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004877 RID: 18551 RVA: 0x000998A0 File Offset: 0x00097AA0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004878 RID: 18552 RVA: 0x000998DC File Offset: 0x00097ADC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004879 RID: 18553 RVA: 0x0009990F File Offset: 0x00097B0F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001427 RID: 5159
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateIgnoreLockOnTarget.TsAnimNotifyStateIgnoreLockOnTarget_C";

	// Token: 0x04001428 RID: 5160
	private static IntPtr _ClassPtr;

	// Token: 0x04001429 RID: 5161
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400142A RID: 5162
	private static int __PropertyOffset_IgnoreSocket;
}
