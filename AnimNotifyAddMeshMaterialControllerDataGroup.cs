using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033F9 RID: 13305
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMeshMaterialControllerDataGroup.AnimNotifyAddMeshMaterialControllerDataGroup_C")]
public class AnimNotifyAddMeshMaterialControllerDataGroup : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002556 RID: 9558
	// (get) Token: 0x0601BAC0 RID: 113344 RVA: 0x00841133 File Offset: 0x0083F333
	// (set) Token: 0x0601BAC1 RID: 113345 RVA: 0x00841147 File Offset: 0x0083F347
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerDataGroup_C MaterialAssetData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerDataGroup_C>(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyAddMeshMaterialControllerDataGroup.__PropertyOffset_MaterialAssetData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyAddMeshMaterialControllerDataGroup.__PropertyOffset_MaterialAssetData, value);
		}
	}

	// Token: 0x17002557 RID: 9559
	// (get) Token: 0x0601BAC2 RID: 113346 RVA: 0x0084115C File Offset: 0x0083F35C
	// (set) Token: 0x0601BAC3 RID: 113347 RVA: 0x0084116C File Offset: 0x0083F36C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideMeshAfterPlay
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyAddMeshMaterialControllerDataGroup.__PropertyOffset_HideMeshAfterPlay) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyAddMeshMaterialControllerDataGroup.__PropertyOffset_HideMeshAfterPlay) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601BAC4 RID: 113348 RVA: 0x00841180 File Offset: 0x0083F380
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

	// Token: 0x0601BAC5 RID: 113349 RVA: 0x00841228 File Offset: 0x0083F428
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (GlobalData.World == null)
		{
			return false;
		}
		if (!UKismetSystemLibrary.IsValid(meshComp))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.MY;
			string message = "错误：动画Mesh不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", (meshComp != null) ? meshComp.GetOwner() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("动画", animation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		meshComp.SetHiddenInGame(false, false);
		if (!this.IsAllValid(meshComp, animation))
		{
			return false;
		}
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.RenderCharacter;
			ELogAuthor author2 = ELogAuthor.LSY;
			string message2 = "材质控制器不应该在角色蓝图上使用此动画通知，请检查动画";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", (meshComp != null) ? meshComp.GetOwner() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("动画", animation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("材质控制器组", this.MaterialAssetData);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData materialControllerData = new AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData();
		if (owner is AEffectSystemActor)
		{
			materialControllerData.CharRenderingComponent = (owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
			if (materialControllerData.CharRenderingComponent == null)
			{
				materialControllerData.CharRenderingComponent = (owner.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as CharRenderingComponent);
				CharRenderingComponent charRenderingComponent = materialControllerData.CharRenderingComponent;
				if (charRenderingComponent != null)
				{
					charRenderingComponent.Init(ECharacterRenderingType.Effect);
				}
			}
		}
		if (materialControllerData.CharRenderingComponent == null)
		{
			AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData materialControllerData2 = materialControllerData;
			TSubclassOf<AActor> actorClass = BP_MaterialControllerRenderActor_C.StaticClass();
			FTransformDouble ftransformDouble = owner.D_GetTransform();
			materialControllerData2.RenderActor = (UKuroRenderingRuntimeBPPluginBPLibrary.D_SpawnActorFromClass(meshComp, actorClass, ftransformDouble, ESpawnActorCollisionHandlingMethod.Undefined, null, null, true) as BP_MaterialControllerRenderActor_C);
			if (materialControllerData.RenderActor != null)
			{
				materialControllerData.RenderActor.RefActor = owner;
				materialControllerData.CharRenderingComponent = materialControllerData.RenderActor.CharRenderingComponent;
				materialControllerData.CharRenderingComponent.Init(ECharacterRenderingType.Default);
				materialControllerData.CharRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, meshComp);
			}
		}
		if (materialControllerData.CharRenderingComponent == null)
		{
			return false;
		}
		materialControllerData.CharRenderingComponent.SetLogicOwner(owner);
		materialControllerData.HandleId = materialControllerData.CharRenderingComponent.AddMaterialControllerDataGroup(this.MaterialAssetData);
		Dictionary<UAnimNotifyState, AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData> dictionary;
		if (!AnimNotifyAddMeshMaterialControllerDataGroup.materialControllerStateHandleMap.TryGetValue(meshComp, out dictionary))
		{
			dictionary = new Dictionary<UAnimNotifyState, AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData>();
			AnimNotifyAddMeshMaterialControllerDataGroup.materialControllerStateHandleMap[meshComp] = dictionary;
		}
		dictionary[this] = materialControllerData;
		return true;
	}

	// Token: 0x0601BAC6 RID: 113350 RVA: 0x00841484 File Offset: 0x0083F684
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
		return true;
	}

	// Token: 0x0601BAC7 RID: 113351 RVA: 0x0084156C File Offset: 0x0083F76C
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

	// Token: 0x0601BAC8 RID: 113352 RVA: 0x0084160C File Offset: 0x0083F80C
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (GlobalData.World == null)
		{
			return false;
		}
		if (meshComp == null)
		{
			return true;
		}
		Dictionary<UAnimNotifyState, AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData> dictionary;
		if (!AnimNotifyAddMeshMaterialControllerDataGroup.materialControllerStateHandleMap.TryGetValue(meshComp, out dictionary))
		{
			return true;
		}
		AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData materialControllerData;
		if (!dictionary.TryGetValue(this, out materialControllerData))
		{
			return true;
		}
		dictionary.Remove(this);
		if (dictionary.Count == 0)
		{
			AnimNotifyAddMeshMaterialControllerDataGroup.materialControllerStateHandleMap.Remove(meshComp);
		}
		if (materialControllerData.CharRenderingComponent != null && materialControllerData.HandleId >= 0)
		{
			materialControllerData.CharRenderingComponent.RemoveMaterialControllerDataGroup(materialControllerData.HandleId);
		}
		if (materialControllerData.RenderActor != null)
		{
			materialControllerData.CharRenderingComponent.Destroy();
			materialControllerData.RenderActor.K2_DestroyActor();
		}
		if (this.HideMeshAfterPlay)
		{
			meshComp.SetHiddenInGame(true, false);
		}
		return true;
	}

	// Token: 0x0601BAC9 RID: 113353 RVA: 0x008416B4 File Offset: 0x0083F8B4
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

	// Token: 0x0601BACA RID: 113354 RVA: 0x00841730 File Offset: 0x0083F930
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		PD_CharacterControllerDataGroup_C materialAssetData = this.MaterialAssetData;
		string text = (materialAssetData != null) ? materialAssetData.GetName() : null;
		if (!string.IsNullOrEmpty(text))
		{
			return "召唤物/NPC材质控制器组:" + UBlueprintPathsLibrary.GetBaseFilename(text, true);
		}
		return "召唤物/NPC材质控制器组";
	}

	// Token: 0x0601BACB RID: 113355 RVA: 0x0084176F File Offset: 0x0083F96F
	static AnimNotifyAddMeshMaterialControllerDataGroup()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AnimNotifyAddMeshMaterialControllerDataGroup.CreateStaticDefaultValue), new Action(AnimNotifyAddMeshMaterialControllerDataGroup.ResetStaticDefaultValue));
	}

	// Token: 0x0601BACC RID: 113356 RVA: 0x0084178E File Offset: 0x0083F98E
	public static void CreateStaticDefaultValue()
	{
		AnimNotifyAddMeshMaterialControllerDataGroup.materialControllerStateHandleMap = new Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData>>();
	}

	// Token: 0x0601BACD RID: 113357 RVA: 0x0084179A File Offset: 0x0083F99A
	public static void ResetStaticDefaultValue()
	{
		AnimNotifyAddMeshMaterialControllerDataGroup.materialControllerStateHandleMap = null;
	}

	// Token: 0x0601BACE RID: 113358 RVA: 0x008417A2 File Offset: 0x0083F9A2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyAddMeshMaterialControllerDataGroup._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMeshMaterialControllerDataGroup.AnimNotifyAddMeshMaterialControllerDataGroup_C");
		}
		return AnimNotifyAddMeshMaterialControllerDataGroup._ClassPtr;
	}

	// Token: 0x0601BACF RID: 113359 RVA: 0x008417C8 File Offset: 0x0083F9C8
	public AnimNotifyAddMeshMaterialControllerDataGroup() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddMeshMaterialControllerDataGroup.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BAD0 RID: 113360 RVA: 0x008417F0 File Offset: 0x0083F9F0
	[NullableContext(1)]
	public AnimNotifyAddMeshMaterialControllerDataGroup(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddMeshMaterialControllerDataGroup.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BAD1 RID: 113361 RVA: 0x00841823 File Offset: 0x0083FA23
	protected AnimNotifyAddMeshMaterialControllerDataGroup(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BAD2 RID: 113362 RVA: 0x0084182C File Offset: 0x0083FA2C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601BAD3 RID: 113363 RVA: 0x00841868 File Offset: 0x0083FA68
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BAD4 RID: 113364 RVA: 0x0084189B File Offset: 0x0083FA9B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400DFC9 RID: 57289
	[Nullable(1)]
	private static Dictionary<USkeletalMeshComponent, Dictionary<UAnimNotifyState, AnimNotifyAddMeshMaterialControllerDataGroup.MaterialControllerData>> materialControllerStateHandleMap;

	// Token: 0x0400DFCA RID: 57290
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMeshMaterialControllerDataGroup.AnimNotifyAddMeshMaterialControllerDataGroup_C";

	// Token: 0x0400DFCB RID: 57291
	private static IntPtr _ClassPtr;

	// Token: 0x0400DFCC RID: 57292
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DFCD RID: 57293
	private static int __PropertyOffset_MaterialAssetData;

	// Token: 0x0400DFCE RID: 57294
	private static int __PropertyOffset_HideMeshAfterPlay;

	// Token: 0x0200949A RID: 38042
	[Nullable(0)]
	private class MaterialControllerData
	{
		// Token: 0x0403144B RID: 201803
		public int HandleId = -1;

		// Token: 0x0403144C RID: 201804
		public BP_MaterialControllerRenderActor_C RenderActor;

		// Token: 0x0403144D RID: 201805
		public CharRenderingComponent CharRenderingComponent;
	}
}
