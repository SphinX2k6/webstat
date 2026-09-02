using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC4 RID: 3524
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableAllRoleWithoutControl.TsAnimNotifyDisableAllRoleWithoutControl_C")]
public class TsAnimNotifyDisableAllRoleWithoutControl : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000520 RID: 1312
	// (get) Token: 0x06005022 RID: 20514 RVA: 0x000B8B3B File Offset: 0x000B6D3B
	// (set) Token: 0x06005023 RID: 20515 RVA: 0x000B8B4B File Offset: 0x000B6D4B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 是否播放特效
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyDisableAllRoleWithoutControl.__PropertyOffset_是否播放特效) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyDisableAllRoleWithoutControl.__PropertyOffset_是否播放特效) = (value ? 1 : 0);
		}
	}

	// Token: 0x06005024 RID: 20516 RVA: 0x000B8B5C File Offset: 0x000B6D5C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x06005025 RID: 20517 RVA: 0x000B8BFC File Offset: 0x000B6DFC
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		ControllerBase<SceneTeamController>.Instance.DisableAllRoleWithoutControl(null, null, this.是否播放特效);
		return true;
	}

	// Token: 0x06005026 RID: 20518 RVA: 0x000B8C5C File Offset: 0x000B6E5C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06005027 RID: 20519 RVA: 0x000B8CD7 File Offset: 0x000B6ED7
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "下场所有前台不受控角色（开启特效时有延迟）";
	}

	// Token: 0x06005028 RID: 20520 RVA: 0x000B8CDE File Offset: 0x000B6EDE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyDisableAllRoleWithoutControl._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableAllRoleWithoutControl.TsAnimNotifyDisableAllRoleWithoutControl_C");
		}
		return TsAnimNotifyDisableAllRoleWithoutControl._ClassPtr;
	}

	// Token: 0x06005029 RID: 20521 RVA: 0x000B8D04 File Offset: 0x000B6F04
	public TsAnimNotifyDisableAllRoleWithoutControl() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableAllRoleWithoutControl.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600502A RID: 20522 RVA: 0x000B8D2C File Offset: 0x000B6F2C
	[NullableContext(1)]
	public TsAnimNotifyDisableAllRoleWithoutControl(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableAllRoleWithoutControl.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600502B RID: 20523 RVA: 0x000B8D5F File Offset: 0x000B6F5F
	protected TsAnimNotifyDisableAllRoleWithoutControl(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600502C RID: 20524 RVA: 0x000B8D68 File Offset: 0x000B6F68
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600502D RID: 20525 RVA: 0x000B8D9B File Offset: 0x000B6F9B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001768 RID: 5992
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableAllRoleWithoutControl.TsAnimNotifyDisableAllRoleWithoutControl_C";

	// Token: 0x04001769 RID: 5993
	private static IntPtr _ClassPtr;

	// Token: 0x0400176A RID: 5994
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400176B RID: 5995
	private static int __PropertyOffset_是否播放特效;
}
