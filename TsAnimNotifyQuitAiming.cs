using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DDD RID: 3549
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyQuitAiming.TsAnimNotifyQuitAiming_C")]
public class TsAnimNotifyQuitAiming : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000549 RID: 1353
	// (get) Token: 0x0600516A RID: 20842 RVA: 0x000BD29B File Offset: 0x000BB49B
	// (set) Token: 0x0600516B RID: 20843 RVA: 0x000BD2AF File Offset: 0x000BB4AF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyQuitAiming.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyQuitAiming.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x0600516C RID: 20844 RVA: 0x000BD2C4 File Offset: 0x000BB4C4
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

	// Token: 0x0600516D RID: 20845 RVA: 0x000BD364 File Offset: 0x000BB564
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
			if (!tsBaseCharacter.CharacterActorComponent.IsWorldOwner())
			{
				return false;
			}
			if (this.Tag.TagName == "None" || entity.GetComponent<BaseTagComponent>().HasTag(this.Tag.TagId()))
			{
				entity.GetComponent<CharacterUnifiedStateComponent>().ExitAimStatus();
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600516E RID: 20846 RVA: 0x000BD3E0 File Offset: 0x000BB5E0
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

	// Token: 0x0600516F RID: 20847 RVA: 0x000BD45B File Offset: 0x000BB65B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "退出瞄准模式";
	}

	// Token: 0x06005170 RID: 20848 RVA: 0x000BD462 File Offset: 0x000BB662
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyQuitAiming._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyQuitAiming.TsAnimNotifyQuitAiming_C");
		}
		return TsAnimNotifyQuitAiming._ClassPtr;
	}

	// Token: 0x06005171 RID: 20849 RVA: 0x000BD488 File Offset: 0x000BB688
	public TsAnimNotifyQuitAiming() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyQuitAiming.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005172 RID: 20850 RVA: 0x000BD4B0 File Offset: 0x000BB6B0
	[NullableContext(1)]
	public TsAnimNotifyQuitAiming(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyQuitAiming.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005173 RID: 20851 RVA: 0x000BD4E3 File Offset: 0x000BB6E3
	protected TsAnimNotifyQuitAiming(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005174 RID: 20852 RVA: 0x000BD4EC File Offset: 0x000BB6EC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005175 RID: 20853 RVA: 0x000BD51F File Offset: 0x000BB71F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017E2 RID: 6114
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyQuitAiming.TsAnimNotifyQuitAiming_C";

	// Token: 0x040017E3 RID: 6115
	private static IntPtr _ClassPtr;

	// Token: 0x040017E4 RID: 6116
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017E5 RID: 6117
	private static int __PropertyOffset_Tag;
}
