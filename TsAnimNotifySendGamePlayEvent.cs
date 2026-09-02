using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE8 RID: 3560
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySendGamePlayEvent.TsAnimNotifySendGamePlayEvent_C")]
public class TsAnimNotifySendGamePlayEvent : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000566 RID: 1382
	// (get) Token: 0x0600520E RID: 21006 RVA: 0x000BF75F File Offset: 0x000BD95F
	// (set) Token: 0x0600520F RID: 21007 RVA: 0x000BF773 File Offset: 0x000BD973
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag 事件Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifySendGamePlayEvent.__PropertyOffset_事件Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySendGamePlayEvent.__PropertyOffset_事件Tag) = value;
		}
	}

	// Token: 0x06005210 RID: 21008 RVA: 0x000BF788 File Offset: 0x000BD988
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

	// Token: 0x06005211 RID: 21009 RVA: 0x000BF828 File Offset: 0x000BDA28
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			BaseAbilityComponent component = tsBaseCharacter.CharacterActorComponent.Entity.GetComponent<BaseAbilityComponent>();
			if (component == null || !component.Valid)
			{
				return false;
			}
			component.SendGameplayEventToActor(this.事件Tag, null);
		}
		return false;
	}

	// Token: 0x06005212 RID: 21010 RVA: 0x000BF878 File Offset: 0x000BDA78
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

	// Token: 0x06005213 RID: 21011 RVA: 0x000BF8F3 File Offset: 0x000BDAF3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "发送动画通知广播";
	}

	// Token: 0x06005214 RID: 21012 RVA: 0x000BF8FA File Offset: 0x000BDAFA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySendGamePlayEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySendGamePlayEvent.TsAnimNotifySendGamePlayEvent_C");
		}
		return TsAnimNotifySendGamePlayEvent._ClassPtr;
	}

	// Token: 0x06005215 RID: 21013 RVA: 0x000BF920 File Offset: 0x000BDB20
	public TsAnimNotifySendGamePlayEvent() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySendGamePlayEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005216 RID: 21014 RVA: 0x000BF948 File Offset: 0x000BDB48
	[NullableContext(1)]
	public TsAnimNotifySendGamePlayEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySendGamePlayEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005217 RID: 21015 RVA: 0x000BF97B File Offset: 0x000BDB7B
	protected TsAnimNotifySendGamePlayEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005218 RID: 21016 RVA: 0x000BF984 File Offset: 0x000BDB84
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005219 RID: 21017 RVA: 0x000BF9B7 File Offset: 0x000BDBB7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001826 RID: 6182
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySendGamePlayEvent.TsAnimNotifySendGamePlayEvent_C";

	// Token: 0x04001827 RID: 6183
	private static IntPtr _ClassPtr;

	// Token: 0x04001828 RID: 6184
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001829 RID: 6185
	private static int __PropertyOffset_事件Tag;
}
