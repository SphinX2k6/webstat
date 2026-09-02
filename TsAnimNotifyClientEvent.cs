using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DBE RID: 3518
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyClientEvent.TsAnimNotifyClientEvent_C")]
public class TsAnimNotifyClientEvent : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000514 RID: 1300
	// (get) Token: 0x06004FCE RID: 20430 RVA: 0x000B794B File Offset: 0x000B5B4B
	// (set) Token: 0x06004FCF RID: 20431 RVA: 0x000B795F File Offset: 0x000B5B5F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag GameplayTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyClientEvent.__PropertyOffset_GameplayTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyClientEvent.__PropertyOffset_GameplayTag) = value;
		}
	}

	// Token: 0x06004FD0 RID: 20432 RVA: 0x000B7974 File Offset: 0x000B5B74
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

	// Token: 0x06004FD1 RID: 20433 RVA: 0x000B7A14 File Offset: 0x000B5C14
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		FGameplayTag gameplayTag = this.GameplayTag;
		Singleton<EventSystem>.Instance.Emit<FGameplayTag>(EEventName.CheckClientEvent, this.GameplayTag);
		return true;
	}

	// Token: 0x06004FD2 RID: 20434 RVA: 0x000B7A40 File Offset: 0x000B5C40
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

	// Token: 0x06004FD3 RID: 20435 RVA: 0x000B7ABB File Offset: 0x000B5CBB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "客户端全局自定义事件";
	}

	// Token: 0x06004FD4 RID: 20436 RVA: 0x000B7AC2 File Offset: 0x000B5CC2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyClientEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyClientEvent.TsAnimNotifyClientEvent_C");
		}
		return TsAnimNotifyClientEvent._ClassPtr;
	}

	// Token: 0x06004FD5 RID: 20437 RVA: 0x000B7AE8 File Offset: 0x000B5CE8
	public TsAnimNotifyClientEvent() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyClientEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004FD6 RID: 20438 RVA: 0x000B7B10 File Offset: 0x000B5D10
	[NullableContext(1)]
	public TsAnimNotifyClientEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyClientEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004FD7 RID: 20439 RVA: 0x000B7B43 File Offset: 0x000B5D43
	protected TsAnimNotifyClientEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004FD8 RID: 20440 RVA: 0x000B7B4C File Offset: 0x000B5D4C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004FD9 RID: 20441 RVA: 0x000B7B7F File Offset: 0x000B5D7F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001749 RID: 5961
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyClientEvent.TsAnimNotifyClientEvent_C";

	// Token: 0x0400174A RID: 5962
	private static IntPtr _ClassPtr;

	// Token: 0x0400174B RID: 5963
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400174C RID: 5964
	private static int __PropertyOffset_GameplayTag;
}
