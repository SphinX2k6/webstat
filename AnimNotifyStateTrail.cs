using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003405 RID: 13317
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateTrail.AnimNotifyStateTrail_C")]
public class AnimNotifyStateTrail : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025A3 RID: 9635
	// (get) Token: 0x0601BCE5 RID: 113893 RVA: 0x0084B510 File Offset: 0x00849710
	// (set) Token: 0x0601BCE6 RID: 113894 RVA: 0x0084B549 File Offset: 0x00849749
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<EffectModelTrail> TrailingConfigData
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<EffectModelTrail> result;
			if ((result = this._TrailingConfigData) == null)
			{
				result = (this._TrailingConfigData = new TSoftObjectPtr<EffectModelTrail>(base.NativePtr + (IntPtr)AnimNotifyStateTrail.__PropertyOffset_TrailingConfigData, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)AnimNotifyStateTrail.__PropertyOffset_TrailingConfigData, 1);
		}
	}

	// Token: 0x170025A4 RID: 9636
	// (get) Token: 0x0601BCE7 RID: 113895 RVA: 0x0084B56E File Offset: 0x0084976E
	// (set) Token: 0x0601BCE8 RID: 113896 RVA: 0x0084B57E File Offset: 0x0084977E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseWeapon
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateTrail.__PropertyOffset_UseWeapon) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateTrail.__PropertyOffset_UseWeapon) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025A5 RID: 9637
	// (get) Token: 0x0601BCE9 RID: 113897 RVA: 0x0084B58F File Offset: 0x0084978F
	// (set) Token: 0x0601BCEA RID: 113898 RVA: 0x0084B59F File Offset: 0x0084979F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int WeaponCaseIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateTrail.__PropertyOffset_WeaponCaseIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateTrail.__PropertyOffset_WeaponCaseIndex) = value;
		}
	}

	// Token: 0x0601BCEB RID: 113899 RVA: 0x0084B5B0 File Offset: 0x008497B0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_ValidateAssets()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_ValidateAssets"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BCEC RID: 113900 RVA: 0x0084B625 File Offset: 0x00849825
	protected virtual bool K2_ValidateAssets_Implementation()
	{
		return true;
	}

	// Token: 0x0601BCED RID: 113901 RVA: 0x0084B628 File Offset: 0x00849828
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

	// Token: 0x0601BCEE RID: 113902 RVA: 0x0084B6D0 File Offset: 0x008498D0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Handle = 0;
		if (meshComp == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderEffect;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "拖尾特效传入空参数";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("动画", animation);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (this.TrailingConfigData == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderEffect;
			ELogAuthor author2 = ELogAuthor.LSY;
			string message2 = "拖尾特效缺失配置";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("动画", animation);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		USkeletalMeshComponent uskeletalMeshComponent = meshComp;
		if (this.UseWeapon)
		{
			string b = "WeaponCase" + this.WeaponCaseIndex.ToString();
			TArray<UActorComponent> tarray = meshComp.GetOwner().K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			bool flag = false;
			for (int i = 0; i < tarray.Num(); i++)
			{
				if (tarray.Get(i).GetName() == b)
				{
					uskeletalMeshComponent = (tarray.Get(i) as USkeletalMeshComponent);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "AnimNotifyStateTrail未找到武器", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		AActor owner = uskeletalMeshComponent.GetOwner();
		SkeletalMeshEffectContext skeletalMeshEffectContext = new SkeletalMeshEffectContext(null, null, false);
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			if (((characterActorComponent != null) ? characterActorComponent.Entity : null) != null)
			{
				EffectContext effectContext = skeletalMeshEffectContext;
				CharacterActorComponent characterActorComponent2 = tsBaseCharacter.CharacterActorComponent;
				effectContext.EntityId = ((characterActorComponent2 != null) ? new int?(characterActorComponent2.Entity.Id) : null);
			}
		}
		skeletalMeshEffectContext.SourceObject = uskeletalMeshComponent.GetOwner();
		skeletalMeshEffectContext.SkeletalMeshComp = uskeletalMeshComponent;
		EffectSystem instance3 = Singleton<EffectSystem>.Instance;
		UObject worldContext = owner;
		FTransformDouble? ftransformDouble = new FTransformDouble?(meshComp.D_K2_GetComponentToWorld());
		this.Handle = instance3.SpawnEffect(worldContext, ftransformDouble, this.TrailingConfigData.ToAssetPathName(), "[AnimNotifyStateTrail.K2_NotifyBegin]", skeletalMeshEffectContext, EEffectType.Scene, null, null, null, false, false);
		if (!Singleton<EffectSystem>.Instance.IsValid(this.Handle))
		{
			return false;
		}
		Singleton<EffectSystem>.Instance.SetEffectNotRecord(this.Handle, true);
		return true;
	}

	// Token: 0x0601BCEF RID: 113903 RVA: 0x0084B8C0 File Offset: 0x00849AC0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
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

	// Token: 0x0601BCF0 RID: 113904 RVA: 0x0084B960 File Offset: 0x00849B60
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(this.Handle))
		{
			return false;
		}
		Singleton<EffectSystem>.Instance.StopEffectById(this.Handle, "AnimNotifyTrail: K2_NotifyEnd", false, null);
		this.Handle = 0;
		return true;
	}

	// Token: 0x0601BCF1 RID: 113905 RVA: 0x0084B9A9 File Offset: 0x00849BA9
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyStateTrail._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateTrail.AnimNotifyStateTrail_C");
		}
		return AnimNotifyStateTrail._ClassPtr;
	}

	// Token: 0x0601BCF2 RID: 113906 RVA: 0x0084B9D0 File Offset: 0x00849BD0
	public AnimNotifyStateTrail() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateTrail.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BCF3 RID: 113907 RVA: 0x0084B9F8 File Offset: 0x00849BF8
	[NullableContext(1)]
	public AnimNotifyStateTrail(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateTrail.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BCF4 RID: 113908 RVA: 0x0084BA2B File Offset: 0x00849C2B
	protected AnimNotifyStateTrail(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BCF5 RID: 113909 RVA: 0x0084BA34 File Offset: 0x00849C34
	protected unsafe virtual void __CPPCALL_K2_ValidateAssets_Implementation(UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams* __Params)
	{
		__Params->__Result = this.K2_ValidateAssets_Implementation();
	}

	// Token: 0x0601BCF6 RID: 113910 RVA: 0x0084BA44 File Offset: 0x00849C44
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601BCF7 RID: 113911 RVA: 0x0084BA80 File Offset: 0x00849C80
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400E080 RID: 57472
	public int Handle;

	// Token: 0x0400E081 RID: 57473
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateTrail.AnimNotifyStateTrail_C";

	// Token: 0x0400E082 RID: 57474
	private static IntPtr _ClassPtr;

	// Token: 0x0400E083 RID: 57475
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E084 RID: 57476
	private static int __PropertyOffset_TrailingConfigData;

	// Token: 0x0400E085 RID: 57477
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<EffectModelTrail> _TrailingConfigData;

	// Token: 0x0400E086 RID: 57478
	private static int __PropertyOffset_UseWeapon;

	// Token: 0x0400E087 RID: 57479
	private static int __PropertyOffset_WeaponCaseIndex;
}
