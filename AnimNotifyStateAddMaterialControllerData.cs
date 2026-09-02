using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033FC RID: 13308
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerData.AnimNotifyStateAddMaterialControllerData_C")]
public class AnimNotifyStateAddMaterialControllerData : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002558 RID: 9560
	// (get) Token: 0x0601BAE3 RID: 113379 RVA: 0x00841AF0 File Offset: 0x0083FCF0
	// (set) Token: 0x0601BAE4 RID: 113380 RVA: 0x00841B04 File Offset: 0x0083FD04
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C MaterialAssetData
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyStateAddMaterialControllerData.__PropertyOffset_MaterialAssetData);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyStateAddMaterialControllerData.__PropertyOffset_MaterialAssetData, value);
		}
	}

	// Token: 0x17002559 RID: 9561
	// (get) Token: 0x0601BAE5 RID: 113381 RVA: 0x00841B19 File Offset: 0x0083FD19
	// (set) Token: 0x0601BAE6 RID: 113382 RVA: 0x00841B29 File Offset: 0x0083FD29
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NeedAnyTag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_NeedAnyTag) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_NeedAnyTag) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700255A RID: 9562
	// (get) Token: 0x0601BAE7 RID: 113383 RVA: 0x00841B3C File Offset: 0x0083FD3C
	// (set) Token: 0x0601BAE8 RID: 113384 RVA: 0x00841B75 File Offset: 0x0083FD75
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<FGameplayTag, bool> PlayNeedTags
	{
		get
		{
			base.FastCheckIsValid();
			TMap<FGameplayTag, bool> result;
			if ((result = this._PlayNeedTags) == null)
			{
				result = (this._PlayNeedTags = new TMap<FGameplayTag, bool>(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_PlayNeedTags, this));
			}
			return result;
		}
		set
		{
			this.PlayNeedTags.CopyAssign(value);
		}
	}

	// Token: 0x1700255B RID: 9563
	// (get) Token: 0x0601BAE9 RID: 113385 RVA: 0x00841B83 File Offset: 0x0083FD83
	// (set) Token: 0x0601BAEA RID: 113386 RVA: 0x00841B93 File Offset: 0x0083FD93
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool TagCheckWithOwner
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_TagCheckWithOwner) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_TagCheckWithOwner) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700255C RID: 9564
	// (get) Token: 0x0601BAEB RID: 113387 RVA: 0x00841BA4 File Offset: 0x0083FDA4
	// (set) Token: 0x0601BAEC RID: 113388 RVA: 0x00841BB4 File Offset: 0x0083FDB4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OnlyAddOnTsBaseCharacter
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_OnlyAddOnTsBaseCharacter) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_OnlyAddOnTsBaseCharacter) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700255D RID: 9565
	// (get) Token: 0x0601BAED RID: 113389 RVA: 0x00841BC5 File Offset: 0x0083FDC5
	// (set) Token: 0x0601BAEE RID: 113390 RVA: 0x00841BD5 File Offset: 0x0083FDD5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OnlyAddOnUiActor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_OnlyAddOnUiActor) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateAddMaterialControllerData.__PropertyOffset_OnlyAddOnUiActor) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601BAEF RID: 113391 RVA: 0x00841BE8 File Offset: 0x0083FDE8
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

	// Token: 0x0601BAF0 RID: 113392 RVA: 0x00841C90 File Offset: 0x0083FE90
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
		flag = (owner is TsUiSceneRoleActor || owner is TsSkeletalObserver);
		if (flag && !this.UiModelTagsCheck(owner))
		{
			return false;
		}
		CharRenderingComponent charRenderingComponent = null;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		int num;
		if (tsBaseCharacter != null)
		{
			charRenderingComponent = tsBaseCharacter.CharRenderingComponent;
			if (!charRenderingComponent.CheckInit())
			{
				charRenderingComponent.Init(tsBaseCharacter.RenderType);
			}
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			string text = (characterActorComponent != null) ? characterActorComponent.GetReplaceEffect(UKismetSystemLibrary.GetPathName(this.MaterialAssetData)) : null;
			PD_CharacterControllerData_C data = (!string.IsNullOrEmpty(text)) ? Singleton<ResourceSystem>.Instance.Load<PD_CharacterControllerData_C>(text, "js_undefined") : this.MaterialAssetData;
			num = (int)charRenderingComponent.AddMaterialControllerDataWithAnimObject(data, meshComp, null);
		}
		else
		{
			TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				charRenderingComponent = tsBaseVehicle.CharRenderingComponent;
				if (!charRenderingComponent.CheckInit())
				{
					charRenderingComponent.Init(tsBaseVehicle.RenderType);
				}
				Entity entityNoBlueprint = tsBaseVehicle.GetEntityNoBlueprint();
				string text2;
				if (entityNoBlueprint == null)
				{
					text2 = null;
				}
				else
				{
					BaseActorComponent component = entityNoBlueprint.GetComponent<BaseActorComponent>();
					text2 = ((component != null) ? component.GetReplaceEffect(UKismetSystemLibrary.GetPathName(this.MaterialAssetData)) : null);
				}
				string text3 = text2;
				PD_CharacterControllerData_C data2 = (!string.IsNullOrEmpty(text3)) ? Singleton<ResourceSystem>.Instance.Load<PD_CharacterControllerData_C>(text3, "js_undefined") : this.MaterialAssetData;
				num = (int)charRenderingComponent.AddMaterialControllerDataWithAnimObject(data2, meshComp, null);
			}
			else
			{
				TsUiSceneRoleActor tsUiSceneRoleActor = owner as TsUiSceneRoleActor;
				if (tsUiSceneRoleActor != null)
				{
					num = tsUiSceneRoleActor.Model.CheckGetComponent<UiModelRenderingMaterialComponent>().AddRenderingMaterialWithAnimObject(this.MaterialAssetData, meshComp);
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
					num = (int)charRenderingComponent.AddMaterialControllerDataWithAnimObject(this.MaterialAssetData, meshComp, null);
				}
			}
		}
		if (num >= 0)
		{
			Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerData.MaterialControllerData> dictionary;
			if (!AnimNotifyStateAddMaterialControllerData.MaterialControllerStateHandleMap.TryGetValue(meshComp, out dictionary))
			{
				dictionary = new Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerData.MaterialControllerData>();
				AnimNotifyStateAddMaterialControllerData.MaterialControllerStateHandleMap[meshComp] = dictionary;
			}
			AnimNotifyStateAddMaterialControllerData.MaterialControllerData value = new AnimNotifyStateAddMaterialControllerData.MaterialControllerData
			{
				HandleId = num,
				CharRenderingComponent = charRenderingComponent
			};
			dictionary[this] = value;
			return true;
		}
		return false;
	}

	// Token: 0x0601BAF1 RID: 113393 RVA: 0x00841EFC File Offset: 0x008400FC
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

	// Token: 0x0601BAF2 RID: 113394 RVA: 0x00841F9C File Offset: 0x0084019C
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp == null)
		{
			return true;
		}
		Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerData.MaterialControllerData> dictionary;
		if (!AnimNotifyStateAddMaterialControllerData.MaterialControllerStateHandleMap.TryGetValue(meshComp, out dictionary))
		{
			return true;
		}
		AnimNotifyStateAddMaterialControllerData.MaterialControllerData materialControllerData;
		if (!dictionary.TryGetValue(this, out materialControllerData))
		{
			return true;
		}
		dictionary.Remove(this);
		if (dictionary.Count == 0)
		{
			AnimNotifyStateAddMaterialControllerData.MaterialControllerStateHandleMap.Remove(meshComp);
		}
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		try
		{
			TsUiSceneRoleActor tsUiSceneRoleActor = owner as TsUiSceneRoleActor;
			if (tsUiSceneRoleActor != null)
			{
				tsUiSceneRoleActor.Model.CheckGetComponent<UiModelRenderingMaterialComponent>().RemoveRenderingMaterialWithEnding(materialControllerData.HandleId);
				return true;
			}
			CharRenderingComponent charRenderingComponent = materialControllerData.CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.RemoveMaterialControllerDataWithEnding(materialControllerData.HandleId);
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

	// Token: 0x0601BAF3 RID: 113395 RVA: 0x008420D8 File Offset: 0x008402D8
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

	// Token: 0x0601BAF4 RID: 113396 RVA: 0x0084222C File Offset: 0x0084042C
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

	// Token: 0x0601BAF5 RID: 113397 RVA: 0x008422A8 File Offset: 0x008404A8
	protected override string GetNotifyName_Implementation()
	{
		PD_CharacterControllerData_C materialAssetData = this.MaterialAssetData;
		string text = (materialAssetData != null) ? materialAssetData.GetName() : null;
		if (!string.IsNullOrEmpty(text))
		{
			return "材质控制器:" + UBlueprintPathsLibrary.GetBaseFilename(text, true);
		}
		return "材质控制器";
	}

	// Token: 0x0601BAF6 RID: 113398 RVA: 0x008422E8 File Offset: 0x008404E8
	private bool UiModelTagsCheck(AActor outer)
	{
		List<UiModelTagComponent> selfAndOwnerComponents = Singleton<UiModelUtil>.Instance.GetSelfAndOwnerComponents<UiModelTagComponent>(outer, this.TagCheckWithOwner);
		if (selfAndOwnerComponents == null || selfAndOwnerComponents.Count == 0)
		{
			return true;
		}
		foreach (UiModelTagComponent @object in selfAndOwnerComponents)
		{
			if (TsAnimNotifyUtils.CheckTags(this.NeedAnyTag, this.PlayNeedTags, new Func<int, bool>(@object.ContainsTagById)))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601BAF7 RID: 113399 RVA: 0x00842374 File Offset: 0x00840574
	static AnimNotifyStateAddMaterialControllerData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AnimNotifyStateAddMaterialControllerData.CreateStaticDefaultValue), new Action(AnimNotifyStateAddMaterialControllerData.ResetStaticDefaultValue));
	}

	// Token: 0x0601BAF8 RID: 113400 RVA: 0x00842393 File Offset: 0x00840593
	public static void CreateStaticDefaultValue()
	{
		AnimNotifyStateAddMaterialControllerData.MaterialControllerStateHandleMap = new Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerData.MaterialControllerData>>();
	}

	// Token: 0x0601BAF9 RID: 113401 RVA: 0x0084239F File Offset: 0x0084059F
	public static void ResetStaticDefaultValue()
	{
		AnimNotifyStateAddMaterialControllerData.MaterialControllerStateHandleMap = null;
	}

	// Token: 0x0601BAFA RID: 113402 RVA: 0x008423A7 File Offset: 0x008405A7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyStateAddMaterialControllerData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerData.AnimNotifyStateAddMaterialControllerData_C");
		}
		return AnimNotifyStateAddMaterialControllerData._ClassPtr;
	}

	// Token: 0x0601BAFB RID: 113403 RVA: 0x008423CC File Offset: 0x008405CC
	public AnimNotifyStateAddMaterialControllerData() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateAddMaterialControllerData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BAFC RID: 113404 RVA: 0x008423F4 File Offset: 0x008405F4
	public AnimNotifyStateAddMaterialControllerData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateAddMaterialControllerData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BAFD RID: 113405 RVA: 0x00842427 File Offset: 0x00840627
	protected AnimNotifyStateAddMaterialControllerData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BAFE RID: 113406 RVA: 0x00842430 File Offset: 0x00840630
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601BAFF RID: 113407 RVA: 0x0084246C File Offset: 0x0084066C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BB00 RID: 113408 RVA: 0x0084249F File Offset: 0x0084069F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400DFD5 RID: 57301
	private static Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, AnimNotifyStateAddMaterialControllerData.MaterialControllerData>> MaterialControllerStateHandleMap;

	// Token: 0x0400DFD6 RID: 57302
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyStateAddMaterialControllerData.AnimNotifyStateAddMaterialControllerData_C";

	// Token: 0x0400DFD7 RID: 57303
	private static IntPtr _ClassPtr;

	// Token: 0x0400DFD8 RID: 57304
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DFD9 RID: 57305
	private static int __PropertyOffset_MaterialAssetData;

	// Token: 0x0400DFDA RID: 57306
	private static int __PropertyOffset_NeedAnyTag;

	// Token: 0x0400DFDB RID: 57307
	private static int __PropertyOffset_PlayNeedTags;

	// Token: 0x0400DFDC RID: 57308
	[Nullable(2)]
	private TMap<FGameplayTag, bool> _PlayNeedTags;

	// Token: 0x0400DFDD RID: 57309
	private static int __PropertyOffset_TagCheckWithOwner;

	// Token: 0x0400DFDE RID: 57310
	private static int __PropertyOffset_OnlyAddOnTsBaseCharacter;

	// Token: 0x0400DFDF RID: 57311
	private static int __PropertyOffset_OnlyAddOnUiActor;

	// Token: 0x0200949B RID: 38043
	[NullableContext(0)]
	private class MaterialControllerData
	{
		// Token: 0x0403144E RID: 201806
		public int HandleId = -1;

		// Token: 0x0403144F RID: 201807
		[Nullable(2)]
		public CharRenderingComponent CharRenderingComponent;
	}
}
