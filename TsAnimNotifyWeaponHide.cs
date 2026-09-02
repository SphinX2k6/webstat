using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DFA RID: 3578
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyWeaponHide.TsAnimNotifyWeaponHide_C")]
public class TsAnimNotifyWeaponHide : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700059B RID: 1435
	// (get) Token: 0x06005329 RID: 21289 RVA: 0x000C32CF File Offset: 0x000C14CF
	// (set) Token: 0x0600532A RID: 21290 RVA: 0x000C32DF File Offset: 0x000C14DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Hide
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_Hide) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_Hide) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700059C RID: 1436
	// (get) Token: 0x0600532B RID: 21291 RVA: 0x000C32F0 File Offset: 0x000C14F0
	// (set) Token: 0x0600532C RID: 21292 RVA: 0x000C3300 File Offset: 0x000C1500
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int WeaponIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_WeaponIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_WeaponIndex) = value;
		}
	}

	// Token: 0x1700059D RID: 1437
	// (get) Token: 0x0600532D RID: 21293 RVA: 0x000C3311 File Offset: 0x000C1511
	// (set) Token: 0x0600532E RID: 21294 RVA: 0x000C3321 File Offset: 0x000C1521
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_HideEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_HideEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700059E RID: 1438
	// (get) Token: 0x0600532F RID: 21295 RVA: 0x000C3332 File Offset: 0x000C1532
	// (set) Token: 0x06005330 RID: 21296 RVA: 0x000C3342 File Offset: 0x000C1542
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseHighPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_UseHighPriority) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_UseHighPriority) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700059F RID: 1439
	// (get) Token: 0x06005331 RID: 21297 RVA: 0x000C3353 File Offset: 0x000C1553
	// (set) Token: 0x06005332 RID: 21298 RVA: 0x000C3367 File Offset: 0x000C1567
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag ActivateTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_ActivateTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyWeaponHide.__PropertyOffset_ActivateTag) = value;
		}
	}

	// Token: 0x06005333 RID: 21299 RVA: 0x000C337C File Offset: 0x000C157C
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

	// Token: 0x06005334 RID: 21300 RVA: 0x000C341C File Offset: 0x000C161C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity == null || !entity.Valid)
			{
				return false;
			}
			if (this.ActivateTag.TagName != FName.NAME_None)
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				if (component != null && !component.HasTag(this.ActivateTag.TagId()))
				{
					return false;
				}
			}
			CharacterWeaponComponent component2 = entity.GetComponent<CharacterWeaponComponent>();
			if (component2 != null)
			{
				component2.HideWeapon(this.WeaponIndex, this.Hide, this.HideEffect, false, this.UseHighPriority ? EWeaponExtraVisibleType.HighCustom : EWeaponExtraVisibleType.LowCustom, "TsAnimNotifyWeaponHide");
			}
		}
		return true;
	}

	// Token: 0x06005335 RID: 21301 RVA: 0x000C34D0 File Offset: 0x000C16D0
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

	// Token: 0x06005336 RID: 21302 RVA: 0x000C354B File Offset: 0x000C174B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "武器隐藏";
	}

	// Token: 0x06005337 RID: 21303 RVA: 0x000C3552 File Offset: 0x000C1752
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyWeaponHide._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyWeaponHide.TsAnimNotifyWeaponHide_C");
		}
		return TsAnimNotifyWeaponHide._ClassPtr;
	}

	// Token: 0x06005338 RID: 21304 RVA: 0x000C3578 File Offset: 0x000C1778
	public TsAnimNotifyWeaponHide() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyWeaponHide.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005339 RID: 21305 RVA: 0x000C35A0 File Offset: 0x000C17A0
	[NullableContext(1)]
	public TsAnimNotifyWeaponHide(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyWeaponHide.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600533A RID: 21306 RVA: 0x000C35D3 File Offset: 0x000C17D3
	protected TsAnimNotifyWeaponHide(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600533B RID: 21307 RVA: 0x000C35DC File Offset: 0x000C17DC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600533C RID: 21308 RVA: 0x000C360F File Offset: 0x000C180F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040018A0 RID: 6304
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyWeaponHide.TsAnimNotifyWeaponHide_C";

	// Token: 0x040018A1 RID: 6305
	private static IntPtr _ClassPtr;

	// Token: 0x040018A2 RID: 6306
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040018A3 RID: 6307
	private static int __PropertyOffset_Hide;

	// Token: 0x040018A4 RID: 6308
	private static int __PropertyOffset_WeaponIndex;

	// Token: 0x040018A5 RID: 6309
	private static int __PropertyOffset_HideEffect;

	// Token: 0x040018A6 RID: 6310
	private static int __PropertyOffset_UseHighPriority;

	// Token: 0x040018A7 RID: 6311
	private static int __PropertyOffset_ActivateTag;
}
