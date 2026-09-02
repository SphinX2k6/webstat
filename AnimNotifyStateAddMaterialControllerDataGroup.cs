using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033FD RID: 13309
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerDataGroup.AnimNotifyStateAddMaterialControllerDataGroup_C")]
public class AnimNotifyStateAddMaterialControllerDataGroup : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700255E RID: 9566
	// (get) Token: 0x0601BB01 RID: 113409 RVA: 0x008424B3 File Offset: 0x008406B3
	// (set) Token: 0x0601BB02 RID: 113410 RVA: 0x008424C7 File Offset: 0x008406C7
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerDataGroup_C MaterialAssetData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerDataGroup_C>(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_MaterialAssetData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_MaterialAssetData, value);
		}
	}

	// Token: 0x1700255F RID: 9567
	// (get) Token: 0x0601BB03 RID: 113411 RVA: 0x008424DC File Offset: 0x008406DC
	// (set) Token: 0x0601BB04 RID: 113412 RVA: 0x008424EC File Offset: 0x008406EC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedAnyTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_NeedAnyTag) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_NeedAnyTag) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002560 RID: 9568
	// (get) Token: 0x0601BB05 RID: 113413 RVA: 0x00842500 File Offset: 0x00840700
	// (set) Token: 0x0601BB06 RID: 113414 RVA: 0x00842539 File Offset: 0x00840739
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<FGameplayTag, bool> PlayNeedTags
	{
		get
		{
			base.FastCheckIsValid();
			TMap<FGameplayTag, bool> result;
			if ((result = this._PlayNeedTags) == null)
			{
				result = (this._PlayNeedTags = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_PlayNeedTags, this));
			}
			return result;
		}
		set
		{
			this.PlayNeedTags.CopyAssign(value);
		}
	}

	// Token: 0x17002561 RID: 9569
	// (get) Token: 0x0601BB07 RID: 113415 RVA: 0x00842547 File Offset: 0x00840747
	// (set) Token: 0x0601BB08 RID: 113416 RVA: 0x00842557 File Offset: 0x00840757
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool TagCheckWithOwner
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_TagCheckWithOwner) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_TagCheckWithOwner) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002562 RID: 9570
	// (get) Token: 0x0601BB09 RID: 113417 RVA: 0x00842568 File Offset: 0x00840768
	// (set) Token: 0x0601BB0A RID: 113418 RVA: 0x00842578 File Offset: 0x00840778
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OnlyAddOnTsBaseCharacter
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_OnlyAddOnTsBaseCharacter) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_OnlyAddOnTsBaseCharacter) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002563 RID: 9571
	// (get) Token: 0x0601BB0B RID: 113419 RVA: 0x00842589 File Offset: 0x00840789
	// (set) Token: 0x0601BB0C RID: 113420 RVA: 0x00842599 File Offset: 0x00840799
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OnlyAddOnUiActor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_OnlyAddOnUiActor) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerDataGroup.__PropertyOffset_OnlyAddOnUiActor) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601BB0D RID: 113421 RVA: 0x008425AC File Offset: 0x008407AC
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

	// Token: 0x0601BB0E RID: 113422 RVA: 0x00842654 File Offset: 0x00840854
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (!this.IsAllValid(meshComp, animation))
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		if (this.OnlyAddOnTsBaseCharacter && !(owner is TsBaseCharacter))
		{
			return false;
		}
		bool flag = this.OnlyAddOnUiActor;
		if (flag)
		{
			bool flag2 = owner is TsUiSceneRoleActor || owner is TsSkeletalObserver;
			flag = !flag2;
		}
		if (flag)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		CharRenderingComponent charRenderingComponent;
		int num;
		if (tsBaseCharacter != null)
		{
			charRenderingComponent = tsBaseCharacter.CharRenderingComponent;
			if (!charRenderingComponent.CheckInit())
			{
				charRenderingComponent.Init(tsBaseCharacter.RenderType);
			}
			num = (int)charRenderingComponent.AddMaterialControllerDataGroupWithAnimObject(this.MaterialAssetData, meshComp);
		}
		else
		{
			charRenderingComponent = (owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
			if (charRenderingComponent == null)
			{
				charRenderingComponent = (owner.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as CharRenderingComponent);
				charRenderingComponent.Init(ECharacterRenderingType.Effect);
				charRenderingComponent.SetLogicOwner(owner);
			}
			num = (int)charRenderingComponent.AddMaterialControllerDataGroupWithAnimObject(this.MaterialAssetData, meshComp);
		}
		if (num >= 0)
		{
			Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData> dictionary;
			if (!AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerStateHandleMap.TryGetValue(meshComp, out dictionary))
			{
				dictionary = new Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData>();
				AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerStateHandleMap[meshComp] = dictionary;
			}
			AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData value = new AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData
			{
				HandleId = num,
				CharRenderingComponent = charRenderingComponent
			};
			dictionary[this] = value;
			return true;
		}
		return false;
	}

	// Token: 0x0601BB0F RID: 113423 RVA: 0x008427A4 File Offset: 0x008409A4
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

	// Token: 0x0601BB10 RID: 113424 RVA: 0x00842844 File Offset: 0x00840A44
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp == null)
		{
			return true;
		}
		Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData> dictionary;
		if (!AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerStateHandleMap.TryGetValue(meshComp, out dictionary))
		{
			return true;
		}
		AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData materialControllerData;
		if (!dictionary.TryGetValue(this, out materialControllerData))
		{
			return true;
		}
		dictionary.Remove(this);
		if (dictionary.Count == 0)
		{
			AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerStateHandleMap.Remove(meshComp);
		}
		try
		{
			CharRenderingComponent charRenderingComponent = materialControllerData.CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.RemoveMaterialControllerDataGroupWithEnding(materialControllerData.HandleId);
			}
			return true;
		}
		catch
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.LSY;
			string message = "AnimNotifyStateAddMaterialControllerData移除材质控制器特效失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", (meshComp != null) ? meshComp.GetOwner() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("动画", animation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("handleId", materialControllerData.HandleId);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		return false;
	}

	// Token: 0x0601BB11 RID: 113425 RVA: 0x00842948 File Offset: 0x00840B48
	[NullableContext(2)]
	public unsafe bool IsAllValid(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!UKismetSystemLibrary.IsValid(this.MaterialAssetData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.MY;
			string message = "错误：特效DA不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", (meshComp != null) ? meshComp.GetOwner() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("动画", animation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (meshComp == null || !UKismetSystemLibrary.IsValid(meshComp))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderCharacter;
			ELogAuthor author2 = ELogAuthor.MY;
			string message2 = "错误：动画Mesh不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", (meshComp != null) ? meshComp.GetOwner() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("动画", animation);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return false;
		}
		if (!UKismetSystemLibrary.IsValid(meshComp.GetOwner()))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.RenderCharacter;
			ELogAuthor author3 = ELogAuthor.MY;
			string message3 = "错误：动画Owner不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Actor", (meshComp != null) ? meshComp.GetOwner() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("动画", animation);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return false;
		}
		return true;
	}

	// Token: 0x0601BB12 RID: 113426 RVA: 0x00842A9C File Offset: 0x00840C9C
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

	// Token: 0x0601BB13 RID: 113427 RVA: 0x00842B18 File Offset: 0x00840D18
	protected override string GetNotifyName_Implementation()
	{
		PD_CharacterControllerDataGroup_C materialAssetData = this.MaterialAssetData;
		string text = (materialAssetData != null) ? materialAssetData.GetName() : null;
		if (!string.IsNullOrEmpty(text))
		{
			return "材质控制器组:" + UBlueprintPathsLibrary.GetBaseFilename(text, true);
		}
		return "材质控制器组";
	}

	// Token: 0x0601BB14 RID: 113428 RVA: 0x00842B58 File Offset: 0x00840D58
	private bool UiModelTagsCheck(AActor outer)
	{
		List<UiModelTagComponent> selfAndOwnerComponents = Singleton<UiModelUtil>.Instance.GetSelfAndOwnerComponents<UiModelTagComponent>(outer, this.TagCheckWithOwner);
		return selfAndOwnerComponents.Count == 0 || selfAndOwnerComponents.Any((UiModelTagComponent tagComp) => TsAnimNotifyUtils.CheckTags(this.NeedAnyTag, this.PlayNeedTags, new Func<int, bool>(tagComp.ContainsTagById)));
	}

	// Token: 0x0601BB15 RID: 113429 RVA: 0x00842B94 File Offset: 0x00840D94
	private bool GameplayTagsCheck(TsBaseCharacter outer)
	{
		AnimNotifyStateAddMaterialControllerDataGroup.<>c__DisplayClass28_0 CS$<>8__locals1 = new AnimNotifyStateAddMaterialControllerDataGroup.<>c__DisplayClass28_0();
		AnimNotifyStateAddMaterialControllerDataGroup.<>c__DisplayClass28_0 CS$<>8__locals2 = CS$<>8__locals1;
		CharacterActorComponent characterActorComponent = outer.CharacterActorComponent;
		BaseTagComponent tagComp;
		if (characterActorComponent == null)
		{
			tagComp = null;
		}
		else
		{
			Entity entity = characterActorComponent.Entity;
			tagComp = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		CS$<>8__locals2.tagComp = tagComp;
		return !CS$<>8__locals1.tagComp || TsAnimNotifyUtils.CheckTags(this.NeedAnyTag, this.PlayNeedTags, (int tagId) => CS$<>8__locals1.tagComp.HasTag(tagId));
	}

	// Token: 0x0601BB16 RID: 113430 RVA: 0x00842BF7 File Offset: 0x00840DF7
	static AnimNotifyStateAddMaterialControllerDataGroup()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AnimNotifyStateAddMaterialControllerDataGroup.CreateStaticDefaultValue), new Action(AnimNotifyStateAddMaterialControllerDataGroup.ResetStaticDefaultValue));
	}

	// Token: 0x0601BB17 RID: 113431 RVA: 0x00842C16 File Offset: 0x00840E16
	public static void CreateStaticDefaultValue()
	{
		AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerStateHandleMap = new Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData>>();
	}

	// Token: 0x0601BB18 RID: 113432 RVA: 0x00842C22 File Offset: 0x00840E22
	public static void ResetStaticDefaultValue()
	{
		AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerStateHandleMap = null;
	}

	// Token: 0x0601BB19 RID: 113433 RVA: 0x00842C2A File Offset: 0x00840E2A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyStateAddMaterialControllerDataGroup._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerDataGroup.AnimNotifyStateAddMaterialControllerDataGroup_C");
		}
		return AnimNotifyStateAddMaterialControllerDataGroup._ClassPtr;
	}

	// Token: 0x0601BB1A RID: 113434 RVA: 0x00842C50 File Offset: 0x00840E50
	public AnimNotifyStateAddMaterialControllerDataGroup() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateAddMaterialControllerDataGroup.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BB1B RID: 113435 RVA: 0x00842C78 File Offset: 0x00840E78
	public AnimNotifyStateAddMaterialControllerDataGroup(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateAddMaterialControllerDataGroup.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BB1C RID: 113436 RVA: 0x00842CAB File Offset: 0x00840EAB
	protected AnimNotifyStateAddMaterialControllerDataGroup(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BB1D RID: 113437 RVA: 0x00842CB4 File Offset: 0x00840EB4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601BB1E RID: 113438 RVA: 0x00842CF0 File Offset: 0x00840EF0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BB1F RID: 113439 RVA: 0x00842D23 File Offset: 0x00840F23
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400DFE0 RID: 57312
	private static Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerDataGroup.MaterialControllerData>> MaterialControllerStateHandleMap;

	// Token: 0x0400DFE1 RID: 57313
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerDataGroup.AnimNotifyStateAddMaterialControllerDataGroup_C";

	// Token: 0x0400DFE2 RID: 57314
	private static IntPtr _ClassPtr;

	// Token: 0x0400DFE3 RID: 57315
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DFE4 RID: 57316
	private static int __PropertyOffset_MaterialAssetData;

	// Token: 0x0400DFE5 RID: 57317
	private static int __PropertyOffset_NeedAnyTag;

	// Token: 0x0400DFE6 RID: 57318
	private static int __PropertyOffset_PlayNeedTags;

	// Token: 0x0400DFE7 RID: 57319
	[Nullable(2)]
	private TMap<FGameplayTag, bool> _PlayNeedTags;

	// Token: 0x0400DFE8 RID: 57320
	private static int __PropertyOffset_TagCheckWithOwner;

	// Token: 0x0400DFE9 RID: 57321
	private static int __PropertyOffset_OnlyAddOnTsBaseCharacter;

	// Token: 0x0400DFEA RID: 57322
	private static int __PropertyOffset_OnlyAddOnUiActor;

	// Token: 0x0200949C RID: 38044
	[NullableContext(0)]
	private class MaterialControllerData
	{
		// Token: 0x04031450 RID: 201808
		public int HandleId = -1;

		// Token: 0x04031451 RID: 201809
		[Nullable(2)]
		public CharRenderingComponent CharRenderingComponent;
	}
}
