using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC2 RID: 3522
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDetach.TsAnimNotifyDetach_C")]
public class TsAnimNotifyDetach : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700051E RID: 1310
	// (get) Token: 0x0600500A RID: 20490 RVA: 0x000B8513 File Offset: 0x000B6713
	// (set) Token: 0x0600500B RID: 20491 RVA: 0x000B8523 File Offset: 0x000B6723
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsDetachFollower
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyDetach.__PropertyOffset_IsDetachFollower) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyDetach.__PropertyOffset_IsDetachFollower) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700051F RID: 1311
	// (get) Token: 0x0600500C RID: 20492 RVA: 0x000B8534 File Offset: 0x000B6734
	// (set) Token: 0x0600500D RID: 20493 RVA: 0x000B8544 File Offset: 0x000B6744
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsRecursion
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyDetach.__PropertyOffset_IsRecursion) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyDetach.__PropertyOffset_IsRecursion) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600500E RID: 20494 RVA: 0x000B8558 File Offset: 0x000B6758
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

	// Token: 0x0600500F RID: 20495 RVA: 0x000B85F8 File Offset: 0x000B67F8
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
		CharacterSkillComponent component = characterActorComponent.Entity.GetComponent<CharacterSkillComponent>();
		if (component != null && component.Valid)
		{
			EntityHandle skillTarget = component.SkillTarget;
			if (((skillTarget != null) ? skillTarget.Entity : null) != null)
			{
				Entity entityNoBlueprint = (owner as TsBaseCharacter).GetEntityNoBlueprint();
				CharacterAttachComponent characterAttachComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterAttachComponent>() : null;
				if (characterAttachComponent == null || !characterAttachComponent.Valid)
				{
					return false;
				}
				long? preMessageId = characterActorComponent.Entity.GetComponent<BaseBuffComponent>().CreateAnimNotifyContent(animation.GetName(), base.exportIndex);
				characterAttachComponent.DetachFromHost(this.IsDetachFollower, this.IsRecursion, true, preMessageId);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06005010 RID: 20496 RVA: 0x000B86D0 File Offset: 0x000B68D0
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

	// Token: 0x06005011 RID: 20497 RVA: 0x000B874B File Offset: 0x000B694B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "从目标身上解绑";
	}

	// Token: 0x06005012 RID: 20498 RVA: 0x000B8752 File Offset: 0x000B6952
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyDetach._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDetach.TsAnimNotifyDetach_C");
		}
		return TsAnimNotifyDetach._ClassPtr;
	}

	// Token: 0x06005013 RID: 20499 RVA: 0x000B8778 File Offset: 0x000B6978
	public TsAnimNotifyDetach() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDetach.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005014 RID: 20500 RVA: 0x000B87A0 File Offset: 0x000B69A0
	[NullableContext(1)]
	public TsAnimNotifyDetach(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDetach.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005015 RID: 20501 RVA: 0x000B87D3 File Offset: 0x000B69D3
	protected TsAnimNotifyDetach(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005016 RID: 20502 RVA: 0x000B87DC File Offset: 0x000B69DC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005017 RID: 20503 RVA: 0x000B880F File Offset: 0x000B6A0F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001760 RID: 5984
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDetach.TsAnimNotifyDetach_C";

	// Token: 0x04001761 RID: 5985
	private static IntPtr _ClassPtr;

	// Token: 0x04001762 RID: 5986
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001763 RID: 5987
	private static int __PropertyOffset_IsDetachFollower;

	// Token: 0x04001764 RID: 5988
	private static int __PropertyOffset_IsRecursion;
}
