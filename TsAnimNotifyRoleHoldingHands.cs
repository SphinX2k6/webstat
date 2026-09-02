using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE6 RID: 3558
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleHoldingHands.TsAnimNotifyRoleHoldingHands_C")]
public class TsAnimNotifyRoleHoldingHands : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000564 RID: 1380
	// (get) Token: 0x060051F6 RID: 20982 RVA: 0x000BF25B File Offset: 0x000BD45B
	// (set) Token: 0x060051F7 RID: 20983 RVA: 0x000BF26B File Offset: 0x000BD46B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool InvitationAccept
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRoleHoldingHands.__PropertyOffset_InvitationAccept) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRoleHoldingHands.__PropertyOffset_InvitationAccept) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000565 RID: 1381
	// (get) Token: 0x060051F8 RID: 20984 RVA: 0x000BF27C File Offset: 0x000BD47C
	// (set) Token: 0x060051F9 RID: 20985 RVA: 0x000BF28C File Offset: 0x000BD48C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool StartBinding
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyRoleHoldingHands.__PropertyOffset_StartBinding) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyRoleHoldingHands.__PropertyOffset_StartBinding) = (value ? 1 : 0);
		}
	}

	// Token: 0x060051FA RID: 20986 RVA: 0x000BF2A0 File Offset: 0x000BD4A0
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

	// Token: 0x060051FB RID: 20987 RVA: 0x000BF340 File Offset: 0x000BD540
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Entity entity;
			if (tsBaseCharacter == null)
			{
				entity = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
				entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
			}
			Entity entity2 = entity;
			if (entity2 == null || !entity2.Valid)
			{
				return false;
			}
			CharacterHoldingHandsComponent component = entity2.GetComponent<CharacterHoldingHandsComponent>();
			if (this.InvitationAccept && component != null)
			{
				component.FollowerAccept();
			}
			if (this.StartBinding && component != null)
			{
				component.InvitationToBinding();
			}
		}
		return true;
	}

	// Token: 0x060051FC RID: 20988 RVA: 0x000BF3B4 File Offset: 0x000BD5B4
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

	// Token: 0x060051FD RID: 20989 RVA: 0x000BF42F File Offset: 0x000BD62F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "牵手";
	}

	// Token: 0x060051FE RID: 20990 RVA: 0x000BF436 File Offset: 0x000BD636
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyRoleHoldingHands._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleHoldingHands.TsAnimNotifyRoleHoldingHands_C");
		}
		return TsAnimNotifyRoleHoldingHands._ClassPtr;
	}

	// Token: 0x060051FF RID: 20991 RVA: 0x000BF45C File Offset: 0x000BD65C
	public TsAnimNotifyRoleHoldingHands() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRoleHoldingHands.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005200 RID: 20992 RVA: 0x000BF484 File Offset: 0x000BD684
	[NullableContext(1)]
	public TsAnimNotifyRoleHoldingHands(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyRoleHoldingHands.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005201 RID: 20993 RVA: 0x000BF4B7 File Offset: 0x000BD6B7
	protected TsAnimNotifyRoleHoldingHands(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005202 RID: 20994 RVA: 0x000BF4C0 File Offset: 0x000BD6C0
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005203 RID: 20995 RVA: 0x000BF4F3 File Offset: 0x000BD6F3
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400181E RID: 6174
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyRoleHoldingHands.TsAnimNotifyRoleHoldingHands_C";

	// Token: 0x0400181F RID: 6175
	private static IntPtr _ClassPtr;

	// Token: 0x04001820 RID: 6176
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001821 RID: 6177
	private static int __PropertyOffset_InvitationAccept;

	// Token: 0x04001822 RID: 6178
	private static int __PropertyOffset_StartBinding;
}
