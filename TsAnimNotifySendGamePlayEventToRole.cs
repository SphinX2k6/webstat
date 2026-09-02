using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE9 RID: 3561
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySendGamePlayEventToRole.TsAnimNotifySendGamePlayEventToRole_C")]
public class TsAnimNotifySendGamePlayEventToRole : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000567 RID: 1383
	// (get) Token: 0x0600521A RID: 21018 RVA: 0x000BF9CB File Offset: 0x000BDBCB
	// (set) Token: 0x0600521B RID: 21019 RVA: 0x000BF9DF File Offset: 0x000BDBDF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 事件Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySendGamePlayEventToRole.__PropertyOffset_事件Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySendGamePlayEventToRole.__PropertyOffset_事件Tag) = value;
		}
	}

	// Token: 0x0600521C RID: 21020 RVA: 0x000BF9F4 File Offset: 0x000BDBF4
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

	// Token: 0x0600521D RID: 21021 RVA: 0x000BFA94 File Offset: 0x000BDC94
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		WorldEntity worldEntity;
		if (instance == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle getCurrentEntity = instance.GetCurrentEntity;
			worldEntity = ((getCurrentEntity != null) ? getCurrentEntity.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 == null)
		{
			return false;
		}
		BaseAbilityComponent component = worldEntity2.GetComponent<BaseAbilityComponent>();
		if (component == null || !component.Valid)
		{
			return false;
		}
		component.SendGameplayEventToActor(this.事件Tag, null);
		return true;
	}

	// Token: 0x0600521E RID: 21022 RVA: 0x000BFAEC File Offset: 0x000BDCEC
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

	// Token: 0x0600521F RID: 21023 RVA: 0x000BFB67 File Offset: 0x000BDD67
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "发送动画通知广播给主控角色";
	}

	// Token: 0x06005220 RID: 21024 RVA: 0x000BFB6E File Offset: 0x000BDD6E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySendGamePlayEventToRole._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySendGamePlayEventToRole.TsAnimNotifySendGamePlayEventToRole_C");
		}
		return TsAnimNotifySendGamePlayEventToRole._ClassPtr;
	}

	// Token: 0x06005221 RID: 21025 RVA: 0x000BFB94 File Offset: 0x000BDD94
	public TsAnimNotifySendGamePlayEventToRole() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySendGamePlayEventToRole.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005222 RID: 21026 RVA: 0x000BFBBC File Offset: 0x000BDDBC
	[NullableContext(1)]
	public TsAnimNotifySendGamePlayEventToRole(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySendGamePlayEventToRole.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005223 RID: 21027 RVA: 0x000BFBEF File Offset: 0x000BDDEF
	protected TsAnimNotifySendGamePlayEventToRole(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005224 RID: 21028 RVA: 0x000BFBF8 File Offset: 0x000BDDF8
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005225 RID: 21029 RVA: 0x000BFC2B File Offset: 0x000BDE2B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400182A RID: 6186
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySendGamePlayEventToRole.TsAnimNotifySendGamePlayEventToRole_C";

	// Token: 0x0400182B RID: 6187
	private static IntPtr _ClassPtr;

	// Token: 0x0400182C RID: 6188
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400182D RID: 6189
	private static int __PropertyOffset_事件Tag;
}
