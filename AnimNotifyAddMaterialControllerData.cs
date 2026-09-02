using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020033F6 RID: 13302
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMaterialControllerData.AnimNotifyAddMaterialControllerData_C")]
public class AnimNotifyAddMaterialControllerData : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002551 RID: 9553
	// (get) Token: 0x0601BA8F RID: 113295 RVA: 0x0083FEDC File Offset: 0x0083E0DC
	// (set) Token: 0x0601BA90 RID: 113296 RVA: 0x0083FEF0 File Offset: 0x0083E0F0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C MaterialAssetData
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyAddMaterialControllerData.__PropertyOffset_MaterialAssetData);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + AnimNotifyAddMaterialControllerData.__PropertyOffset_MaterialAssetData, value);
		}
	}

	// Token: 0x17002552 RID: 9554
	// (get) Token: 0x0601BA91 RID: 113297 RVA: 0x0083FF05 File Offset: 0x0083E105
	// (set) Token: 0x0601BA92 RID: 113298 RVA: 0x0083FF15 File Offset: 0x0083E115
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool RemoveWhenRevive
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyAddMaterialControllerData.__PropertyOffset_RemoveWhenRevive) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyAddMaterialControllerData.__PropertyOffset_RemoveWhenRevive) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601BA93 RID: 113299 RVA: 0x0083FF28 File Offset: 0x0083E128
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
		if (this.MaterialAssetData.DataType != ECharacterControllerType.Timeline)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.RenderCharacter;
			ELogAuthor author4 = ELogAuthor.MY;
			string message4 = "错误：特效DA不能是Runtime类型,Runtime类型请使用AnimNotifyStateAddMaterialControllerData";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Actor", (meshComp != null) ? meshComp.GetOwner() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("动画", animation);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("DA", this.MaterialAssetData);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
			return false;
		}
		return true;
	}

	// Token: 0x0601BA94 RID: 113300 RVA: 0x00840110 File Offset: 0x0083E310
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

	// Token: 0x0601BA95 RID: 113301 RVA: 0x008401B0 File Offset: 0x0083E3B0
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
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
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			if (!tsBaseCharacter.CharRenderingComponent.CheckInit())
			{
				tsBaseCharacter.CharRenderingComponent.Init(tsBaseCharacter.RenderType);
			}
			float num = tsBaseCharacter.CharRenderingComponent.AddMaterialControllerDataWithAnimObject(this.MaterialAssetData, meshComp, null);
			bool flag = num >= 0f;
			if (flag && this.RemoveWhenRevive)
			{
				RoleDeathComponent component = Singleton<EntitySystem>.Instance.GetComponent<RoleDeathComponent>(tsBaseCharacter.EntityId);
				if (component != null)
				{
					component.AddMaterialHandle((int)num);
				}
			}
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<AActor, int>(EEventName.OnAnimNotifyMaterialControllerHandleAdded, owner, (int)num);
			}
			return flag;
		}
		TsUiSceneRoleActor tsUiSceneRoleActor = owner as TsUiSceneRoleActor;
		if (tsUiSceneRoleActor != null)
		{
			return tsUiSceneRoleActor.Model.CheckGetComponent<UiModelRenderingMaterialComponent>().AddRenderingMaterialByData(this.MaterialAssetData) >= 0;
		}
		CharRenderingComponent charRenderingComponent = owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			charRenderingComponent = (owner.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as CharRenderingComponent);
			charRenderingComponent.Init(ECharacterRenderingType.Effect);
			charRenderingComponent.SetLogicOwner(owner);
		}
		charRenderingComponent.AddMaterialControllerDataWithAnimObject(this.MaterialAssetData, meshComp, null);
		return false;
	}

	// Token: 0x0601BA96 RID: 113302 RVA: 0x008402EC File Offset: 0x0083E4EC
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

	// Token: 0x0601BA97 RID: 113303 RVA: 0x00840368 File Offset: 0x0083E568
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		string name = this.MaterialAssetData.GetName();
		if (!string.IsNullOrEmpty(name))
		{
			return "材质控制器:" + UBlueprintPathsLibrary.GetBaseFilename(name, true);
		}
		return "材质控制器";
	}

	// Token: 0x0601BA98 RID: 113304 RVA: 0x008403A0 File Offset: 0x0083E5A0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyAddMaterialControllerData._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMaterialControllerData.AnimNotifyAddMaterialControllerData_C");
		}
		return AnimNotifyAddMaterialControllerData._ClassPtr;
	}

	// Token: 0x0601BA99 RID: 113305 RVA: 0x008403C4 File Offset: 0x0083E5C4
	public AnimNotifyAddMaterialControllerData() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddMaterialControllerData.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BA9A RID: 113306 RVA: 0x008403EC File Offset: 0x0083E5EC
	[NullableContext(1)]
	public AnimNotifyAddMaterialControllerData(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddMaterialControllerData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BA9B RID: 113307 RVA: 0x0084041F File Offset: 0x0083E61F
	protected AnimNotifyAddMaterialControllerData(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BA9C RID: 113308 RVA: 0x00840428 File Offset: 0x0083E628
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601BA9D RID: 113309 RVA: 0x0084045B File Offset: 0x0083E65B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400DFBA RID: 57274
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Character/AnimNotify/AnimNotifyAddMaterialControllerData.AnimNotifyAddMaterialControllerData_C";

	// Token: 0x0400DFBB RID: 57275
	private static IntPtr _ClassPtr;

	// Token: 0x0400DFBC RID: 57276
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DFBD RID: 57277
	private static int __PropertyOffset_MaterialAssetData;

	// Token: 0x0400DFBE RID: 57278
	private static int __PropertyOffset_RemoveWhenRevive;
}
