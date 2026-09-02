using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DA1 RID: 3489
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHide.TsAnimNotifyStateWeaponHide_C")]
public class TsAnimNotifyStateWeaponHide : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004CE RID: 1230
	// (get) Token: 0x06004E21 RID: 20001 RVA: 0x000B19A3 File Offset: 0x000AFBA3
	// (set) Token: 0x06004E22 RID: 20002 RVA: 0x000B19B3 File Offset: 0x000AFBB3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Hide
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_Hide) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_Hide) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004CF RID: 1231
	// (get) Token: 0x06004E23 RID: 20003 RVA: 0x000B19C4 File Offset: 0x000AFBC4
	// (set) Token: 0x06004E24 RID: 20004 RVA: 0x000B19D4 File Offset: 0x000AFBD4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int WeaponIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_WeaponIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_WeaponIndex) = value;
		}
	}

	// Token: 0x170004D0 RID: 1232
	// (get) Token: 0x06004E25 RID: 20005 RVA: 0x000B19E5 File Offset: 0x000AFBE5
	// (set) Token: 0x06004E26 RID: 20006 RVA: 0x000B19F5 File Offset: 0x000AFBF5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideEffect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_HideEffect) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_HideEffect) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004D1 RID: 1233
	// (get) Token: 0x06004E27 RID: 20007 RVA: 0x000B1A06 File Offset: 0x000AFC06
	// (set) Token: 0x06004E28 RID: 20008 RVA: 0x000B1A16 File Offset: 0x000AFC16
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseHighPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_UseHighPriority) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_UseHighPriority) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004D2 RID: 1234
	// (get) Token: 0x06004E29 RID: 20009 RVA: 0x000B1A27 File Offset: 0x000AFC27
	// (set) Token: 0x06004E2A RID: 20010 RVA: 0x000B1A3B File Offset: 0x000AFC3B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag ActivateTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_ActivateTag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateWeaponHide.__PropertyOffset_ActivateTag) = value;
		}
	}

	// Token: 0x06004E2B RID: 20011 RVA: 0x000B1A50 File Offset: 0x000AFC50
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004E2C RID: 20012 RVA: 0x000B1AF8 File Offset: 0x000AFCF8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
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
				component2.HideWeapon(this.WeaponIndex, this.Hide, this.HideEffect, false, this.UseHighPriority ? EWeaponExtraVisibleType.HighCustom : EWeaponExtraVisibleType.LowCustom, "TsAnimNotifyStateWeaponHide");
			}
		}
		return true;
	}

	// Token: 0x06004E2D RID: 20013 RVA: 0x000B1BAC File Offset: 0x000AFDAC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004E2E RID: 20014 RVA: 0x000B1C27 File Offset: 0x000AFE27
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "武器隐藏";
	}

	// Token: 0x06004E2F RID: 20015 RVA: 0x000B1C2E File Offset: 0x000AFE2E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateWeaponHide._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHide.TsAnimNotifyStateWeaponHide_C");
		}
		return TsAnimNotifyStateWeaponHide._ClassPtr;
	}

	// Token: 0x06004E30 RID: 20016 RVA: 0x000B1C54 File Offset: 0x000AFE54
	public TsAnimNotifyStateWeaponHide() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWeaponHide.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004E31 RID: 20017 RVA: 0x000B1C7C File Offset: 0x000AFE7C
	[NullableContext(1)]
	public TsAnimNotifyStateWeaponHide(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateWeaponHide.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004E32 RID: 20018 RVA: 0x000B1CAF File Offset: 0x000AFEAF
	protected TsAnimNotifyStateWeaponHide(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004E33 RID: 20019 RVA: 0x000B1CB8 File Offset: 0x000AFEB8
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004E34 RID: 20020 RVA: 0x000B1CF1 File Offset: 0x000AFEF1
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001699 RID: 5785
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateWeaponHide.TsAnimNotifyStateWeaponHide_C";

	// Token: 0x0400169A RID: 5786
	private static IntPtr _ClassPtr;

	// Token: 0x0400169B RID: 5787
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400169C RID: 5788
	private static int __PropertyOffset_Hide;

	// Token: 0x0400169D RID: 5789
	private static int __PropertyOffset_WeaponIndex;

	// Token: 0x0400169E RID: 5790
	private static int __PropertyOffset_HideEffect;

	// Token: 0x0400169F RID: 5791
	private static int __PropertyOffset_UseHighPriority;

	// Token: 0x040016A0 RID: 5792
	private static int __PropertyOffset_ActivateTag;
}
