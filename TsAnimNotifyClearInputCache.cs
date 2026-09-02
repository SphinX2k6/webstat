using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DBD RID: 3517
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyClearInputCache.TsAnimNotifyClearInputCache_C")]
public class TsAnimNotifyClearInputCache : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000512 RID: 1298
	// (get) Token: 0x06004FC0 RID: 20416 RVA: 0x000B76CF File Offset: 0x000B58CF
	// (set) Token: 0x06004FC1 RID: 20417 RVA: 0x000B76DF File Offset: 0x000B58DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EInputAction InputAction
	{
		get
		{
			return (EInputAction)(*(base.NativePtr + (IntPtr)TsAnimNotifyClearInputCache.__PropertyOffset_InputAction));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyClearInputCache.__PropertyOffset_InputAction) = (byte)value;
		}
	}

	// Token: 0x17000513 RID: 1299
	// (get) Token: 0x06004FC2 RID: 20418 RVA: 0x000B76F0 File Offset: 0x000B58F0
	// (set) Token: 0x06004FC3 RID: 20419 RVA: 0x000B7700 File Offset: 0x000B5900
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EInputState InputState
	{
		get
		{
			return (EInputState)(*(base.NativePtr + (IntPtr)TsAnimNotifyClearInputCache.__PropertyOffset_InputState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyClearInputCache.__PropertyOffset_InputState) = (byte)value;
		}
	}

	// Token: 0x06004FC4 RID: 20420 RVA: 0x000B7714 File Offset: 0x000B5914
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

	// Token: 0x06004FC5 RID: 20421 RVA: 0x000B77B4 File Offset: 0x000B59B4
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterInputComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterInputComponent>();
			if (component != null)
			{
				component.ClearInputCache((int)this.InputAction, this.InputState);
			}
		}
		return true;
	}

	// Token: 0x06004FC6 RID: 20422 RVA: 0x000B77F8 File Offset: 0x000B59F8
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

	// Token: 0x06004FC7 RID: 20423 RVA: 0x000B7873 File Offset: 0x000B5A73
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "清除角色所有输入缓存";
	}

	// Token: 0x06004FC8 RID: 20424 RVA: 0x000B787A File Offset: 0x000B5A7A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyClearInputCache._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyClearInputCache.TsAnimNotifyClearInputCache_C");
		}
		return TsAnimNotifyClearInputCache._ClassPtr;
	}

	// Token: 0x06004FC9 RID: 20425 RVA: 0x000B78A0 File Offset: 0x000B5AA0
	public TsAnimNotifyClearInputCache() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyClearInputCache.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004FCA RID: 20426 RVA: 0x000B78C8 File Offset: 0x000B5AC8
	[NullableContext(1)]
	public TsAnimNotifyClearInputCache(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyClearInputCache.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004FCB RID: 20427 RVA: 0x000B78FB File Offset: 0x000B5AFB
	protected TsAnimNotifyClearInputCache(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004FCC RID: 20428 RVA: 0x000B7904 File Offset: 0x000B5B04
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004FCD RID: 20429 RVA: 0x000B7937 File Offset: 0x000B5B37
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001744 RID: 5956
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyClearInputCache.TsAnimNotifyClearInputCache_C";

	// Token: 0x04001745 RID: 5957
	private static IntPtr _ClassPtr;

	// Token: 0x04001746 RID: 5958
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001747 RID: 5959
	private static int __PropertyOffset_InputAction;

	// Token: 0x04001748 RID: 5960
	private static int __PropertyOffset_InputState;
}
