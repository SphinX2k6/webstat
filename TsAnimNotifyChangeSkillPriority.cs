using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB9 RID: 3513
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeSkillPriority.TsAnimNotifyChangeSkillPriority_C")]
public class TsAnimNotifyChangeSkillPriority : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700050D RID: 1293
	// (get) Token: 0x06004F90 RID: 20368 RVA: 0x000B6D93 File Offset: 0x000B4F93
	// (set) Token: 0x06004F91 RID: 20369 RVA: 0x000B6DA3 File Offset: 0x000B4FA3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Priority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyChangeSkillPriority.__PropertyOffset_Priority);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeSkillPriority.__PropertyOffset_Priority) = value;
		}
	}

	// Token: 0x06004F92 RID: 20370 RVA: 0x000B6DB4 File Offset: 0x000B4FB4
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

	// Token: 0x06004F93 RID: 20371 RVA: 0x000B6E54 File Offset: 0x000B5054
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			CharacterSkillComponent characterSkillComponent = (entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null;
			if (characterSkillComponent != null && !characterSkillComponent.IsSkillMontageInvalid(animation.GetName()))
			{
				characterSkillComponent.SetSkillPriority(characterSkillComponent.GetSkillIdWithGroupId(1), (int)this.Priority);
			}
		}
		return true;
	}

	// Token: 0x06004F94 RID: 20372 RVA: 0x000B6EB8 File Offset: 0x000B50B8
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

	// Token: 0x06004F95 RID: 20373 RVA: 0x000B6F33 File Offset: 0x000B5133
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "修改技能优先级";
	}

	// Token: 0x06004F96 RID: 20374 RVA: 0x000B6F3A File Offset: 0x000B513A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyChangeSkillPriority._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeSkillPriority.TsAnimNotifyChangeSkillPriority_C");
		}
		return TsAnimNotifyChangeSkillPriority._ClassPtr;
	}

	// Token: 0x06004F97 RID: 20375 RVA: 0x000B6F60 File Offset: 0x000B5160
	public TsAnimNotifyChangeSkillPriority() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeSkillPriority.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F98 RID: 20376 RVA: 0x000B6F88 File Offset: 0x000B5188
	[NullableContext(1)]
	public TsAnimNotifyChangeSkillPriority(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeSkillPriority.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F99 RID: 20377 RVA: 0x000B6FBB File Offset: 0x000B51BB
	protected TsAnimNotifyChangeSkillPriority(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F9A RID: 20378 RVA: 0x000B6FC4 File Offset: 0x000B51C4
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F9B RID: 20379 RVA: 0x000B6FF7 File Offset: 0x000B51F7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001733 RID: 5939
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeSkillPriority.TsAnimNotifyChangeSkillPriority_C";

	// Token: 0x04001734 RID: 5940
	private static IntPtr _ClassPtr;

	// Token: 0x04001735 RID: 5941
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001736 RID: 5942
	private static int __PropertyOffset_Priority;
}
