using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD9 RID: 3545
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyNpcSwitchState.TsAnimNotifyNpcSwitchState_C")]
public class TsAnimNotifyNpcSwitchState : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700053E RID: 1342
	// (get) Token: 0x0600512C RID: 20780 RVA: 0x000BC647 File Offset: 0x000BA847
	// (set) Token: 0x0600512D RID: 20781 RVA: 0x000BC65B File Offset: 0x000BA85B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string StateName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyNpcSwitchState.__PropertyOffset_StateName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyNpcSwitchState.__PropertyOffset_StateName)), value);
		}
	}

	// Token: 0x1700053F RID: 1343
	// (get) Token: 0x0600512E RID: 20782 RVA: 0x000BC670 File Offset: 0x000BA870
	// (set) Token: 0x0600512F RID: 20783 RVA: 0x000BC680 File Offset: 0x000BA880
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedTransition
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyNpcSwitchState.__PropertyOffset_NeedTransition) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyNpcSwitchState.__PropertyOffset_NeedTransition) = (value ? 1 : 0);
		}
	}

	// Token: 0x06005130 RID: 20784 RVA: 0x000BC694 File Offset: 0x000BA894
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

	// Token: 0x06005131 RID: 20785 RVA: 0x000BC734 File Offset: 0x000BA934
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return true;
		}
		if (this.StateName == "" || this.StateName == "None")
		{
			return true;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		NpcPerformComponent npcPerformComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<NpcPerformComponent>() : null;
		if (npcPerformComponent != null)
		{
			npcPerformComponent.SwitchAnimState(new SwitchState
			{
				TargetStateName = this.StateName,
				Context = animation.GetName() + ": AN",
				IsNoTransition = new bool?(!this.NeedTransition)
			});
		}
		return true;
	}

	// Token: 0x06005132 RID: 20786 RVA: 0x000BC7D8 File Offset: 0x000BA9D8
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

	// Token: 0x06005133 RID: 20787 RVA: 0x000BC853 File Offset: 0x000BAA53
	protected override string GetNotifyName_Implementation()
	{
		return "NPC切换ABP状态";
	}

	// Token: 0x06005134 RID: 20788 RVA: 0x000BC85A File Offset: 0x000BAA5A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyNpcSwitchState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyNpcSwitchState.TsAnimNotifyNpcSwitchState_C");
		}
		return TsAnimNotifyNpcSwitchState._ClassPtr;
	}

	// Token: 0x06005135 RID: 20789 RVA: 0x000BC880 File Offset: 0x000BAA80
	public TsAnimNotifyNpcSwitchState() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyNpcSwitchState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005136 RID: 20790 RVA: 0x000BC8A8 File Offset: 0x000BAAA8
	public TsAnimNotifyNpcSwitchState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyNpcSwitchState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005137 RID: 20791 RVA: 0x000BC8DB File Offset: 0x000BAADB
	protected TsAnimNotifyNpcSwitchState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005138 RID: 20792 RVA: 0x000BC8E4 File Offset: 0x000BAAE4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005139 RID: 20793 RVA: 0x000BC917 File Offset: 0x000BAB17
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017CB RID: 6091
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyNpcSwitchState.TsAnimNotifyNpcSwitchState_C";

	// Token: 0x040017CC RID: 6092
	private static IntPtr _ClassPtr;

	// Token: 0x040017CD RID: 6093
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017CE RID: 6094
	private static int __PropertyOffset_StateName;

	// Token: 0x040017CF RID: 6095
	private static int __PropertyOffset_NeedTransition;
}
