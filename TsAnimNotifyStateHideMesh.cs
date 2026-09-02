using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D52 RID: 3410
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideMesh.TsAnimNotifyStateHideMesh_C")]
public class TsAnimNotifyStateHideMesh : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004850 RID: 18512 RVA: 0x00098D05 File Offset: 0x00096F05
	static TsAnimNotifyStateHideMesh()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateHideMesh.CreateStaticDefaultValue), new Action(TsAnimNotifyStateHideMesh.ResetStaticDefaultValue));
	}

	// Token: 0x06004851 RID: 18513 RVA: 0x00098D24 File Offset: 0x00096F24
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateHideMesh._actorAnsMap = new Dictionary<AActor, Dictionary<TsAnimNotifyStateHideMesh, HideMeshParams>>();
	}

	// Token: 0x06004852 RID: 18514 RVA: 0x00098D30 File Offset: 0x00096F30
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateHideMesh._actorAnsMap = null;
	}

	// Token: 0x170003E2 RID: 994
	// (get) Token: 0x06004853 RID: 18515 RVA: 0x00098D38 File Offset: 0x00096F38
	// (set) Token: 0x06004854 RID: 18516 RVA: 0x00098D4C File Offset: 0x00096F4C
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ChildMeshName
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_ChildMeshName)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_ChildMeshName)), value);
		}
	}

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x06004855 RID: 18517 RVA: 0x00098D61 File Offset: 0x00096F61
	// (set) Token: 0x06004856 RID: 18518 RVA: 0x00098D71 File Offset: 0x00096F71
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideChildren
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_HideChildren) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_HideChildren) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x06004857 RID: 18519 RVA: 0x00098D82 File Offset: 0x00096F82
	// (set) Token: 0x06004858 RID: 18520 RVA: 0x00098D92 File Offset: 0x00096F92
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HideChildrenActors
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_HideChildrenActors) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_HideChildrenActors) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003E5 RID: 997
	// (get) Token: 0x06004859 RID: 18521 RVA: 0x00098DA3 File Offset: 0x00096FA3
	// (set) Token: 0x0600485A RID: 18522 RVA: 0x00098DB7 File Offset: 0x00096FB7
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe PD_CharacterControllerData_C EndEffect
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerData_C>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateHideMesh.__PropertyOffset_EndEffect);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateHideMesh.__PropertyOffset_EndEffect, value);
		}
	}

	// Token: 0x170003E6 RID: 998
	// (get) Token: 0x0600485B RID: 18523 RVA: 0x00098DCC File Offset: 0x00096FCC
	// (set) Token: 0x0600485C RID: 18524 RVA: 0x00098DDC File Offset: 0x00096FDC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Hide
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_Hide) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateHideMesh.__PropertyOffset_Hide) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600485D RID: 18525 RVA: 0x00098DF0 File Offset: 0x00096FF0
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

	// Token: 0x0600485E RID: 18526 RVA: 0x00098E98 File Offset: 0x00097098
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		UMeshComponent umeshComponent = null;
		if (string.IsNullOrEmpty(this.ChildMeshName))
		{
			umeshComponent = meshComp;
		}
		else
		{
			TArray<UActorComponent> tarray = owner.K2_GetComponentsByClass(UMeshComponent.StaticClass());
			for (int i = tarray.Num() - 1; i >= 0; i--)
			{
				UMeshComponent umeshComponent2 = tarray.Get(i) as UMeshComponent;
				if (((umeshComponent2 != null) ? umeshComponent2.GetName() : null) == this.ChildMeshName)
				{
					umeshComponent = umeshComponent2;
					break;
				}
			}
		}
		if (umeshComponent == null)
		{
			return false;
		}
		if (TsAnimNotifyStateHideMesh._actorAnsMap == null)
		{
			return false;
		}
		Dictionary<TsAnimNotifyStateHideMesh, HideMeshParams> dictionary;
		if (!TsAnimNotifyStateHideMesh._actorAnsMap.TryGetValue(owner, out dictionary))
		{
			dictionary = new Dictionary<TsAnimNotifyStateHideMesh, HideMeshParams>();
			TsAnimNotifyStateHideMesh._actorAnsMap[owner] = dictionary;
		}
		HideMeshParams hideMeshParams;
		if (dictionary.TryGetValue(this, out hideMeshParams))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "TsAnimNotifyStateHideMesh Error.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Mesh", meshComp);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Anim", animation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		HideMeshParams hideMeshParams2 = new HideMeshParams(umeshComponent);
		dictionary[this] = hideMeshParams2;
		Entity entity = null;
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			entity = tsBaseCharacter.GetEntityNoBlueprint();
		}
		else
		{
			TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				entity = tsBaseVehicle.GetEntityNoBlueprint();
			}
		}
		if (owner is TsBaseCharacter || owner is TsBaseVehicle)
		{
			BaseAnimationComponent baseAnimationComponent = (entity != null) ? entity.GetComponent<BaseAnimationComponent>() : null;
			if (baseAnimationComponent != null)
			{
				baseAnimationComponent.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.HideMesh, false);
			}
			else
			{
				VehicleAnimationComponent vehicleAnimationComponent = (entity != null) ? entity.GetComponent<VehicleAnimationComponent>() : null;
				if (vehicleAnimationComponent != null)
				{
					vehicleAnimationComponent.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.HideMesh, false);
				}
			}
			SubMeshComponent subMeshComponent = (entity != null) ? entity.GetComponent<SubMeshComponent>() : null;
			if (subMeshComponent != null)
			{
				hideMeshParams2.HideKey = subMeshComponent.SetHideMesh(hideMeshParams2.MeshComp, !this.Hide, this.HideChildren, this.HideChildrenActors, 0);
				return true;
			}
		}
		umeshComponent.SetVisibility(!this.Hide, this.HideChildren);
		if (this.HideChildrenActors)
		{
			if (string.IsNullOrEmpty(this.ChildMeshName))
			{
				TArray<AActor> tarray2 = new TArray<AActor>();
				owner.GetAllChildActors(ref tarray2, true);
				for (int j = tarray2.Num() - 1; j >= 0; j--)
				{
					AActor aactor = tarray2.Get(j);
					if (!aactor.bHidden)
					{
						hideMeshParams2.Children.Add(aactor);
					}
				}
			}
			else
			{
				TArray<USceneComponent> attachChildren = umeshComponent.AttachChildren;
				for (int k = attachChildren.Num() - 1; k >= 0; k--)
				{
					AActor owner2 = attachChildren.Get(k).GetOwner();
					if ((owner2 == null || !owner2.bHidden) && owner2 != null)
					{
						hideMeshParams2.Children.Add(owner2);
					}
				}
			}
			foreach (AActor aactor2 in hideMeshParams2.Children)
			{
				aactor2.SetActorHiddenInGame(this.Hide);
			}
		}
		return true;
	}

	// Token: 0x0600485F RID: 18527 RVA: 0x00099188 File Offset: 0x00097388
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

	// Token: 0x06004860 RID: 18528 RVA: 0x00099228 File Offset: 0x00097428
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner == null)
		{
			return false;
		}
		Dictionary<TsAnimNotifyStateHideMesh, HideMeshParams> dictionary;
		if (TsAnimNotifyStateHideMesh._actorAnsMap == null || !TsAnimNotifyStateHideMesh._actorAnsMap.TryGetValue(owner, out dictionary))
		{
			return false;
		}
		HideMeshParams hideMeshParams;
		if (!dictionary.TryGetValue(this, out hideMeshParams))
		{
			return false;
		}
		dictionary.Remove(this);
		if (dictionary.Count == 0)
		{
			TsAnimNotifyStateHideMesh._actorAnsMap.Remove(owner);
		}
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
		if (tsBaseCharacter != null || tsBaseVehicle != null)
		{
			Entity entity = ((tsBaseCharacter != null) ? tsBaseCharacter.GetEntityNoBlueprint() : null) ?? ((tsBaseVehicle != null) ? tsBaseVehicle.GetEntityNoBlueprint() : null);
			BaseAnimationComponent baseAnimationComponent = (entity != null) ? entity.GetComponent<BaseAnimationComponent>() : null;
			if (baseAnimationComponent != null)
			{
				baseAnimationComponent.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.HideMesh);
			}
			else
			{
				VehicleAnimationComponent vehicleAnimationComponent = (entity != null) ? entity.GetComponent<VehicleAnimationComponent>() : null;
				if (vehicleAnimationComponent != null)
				{
					vehicleAnimationComponent.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.HideMesh);
				}
			}
			if (hideMeshParams.HideKey != 0)
			{
				SubMeshComponent subMeshComponent = (entity != null) ? entity.GetComponent<SubMeshComponent>() : null;
				if (subMeshComponent != null)
				{
					subMeshComponent.SetHideMesh(hideMeshParams.MeshComp, this.Hide, this.HideChildren, this.HideChildrenActors, hideMeshParams.HideKey);
					return true;
				}
			}
		}
		hideMeshParams.MeshComp.SetVisibility(this.Hide, this.HideChildren);
		if (this.HideChildrenActors)
		{
			foreach (AActor aactor in hideMeshParams.Children)
			{
				aactor.SetActorHiddenInGame(!this.Hide);
			}
		}
		if (this.EndEffect != null)
		{
			CharRenderingComponent charRenderingComponent = owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.AddMaterialControllerData(this.EndEffect);
			}
		}
		return true;
	}

	// Token: 0x06004861 RID: 18529 RVA: 0x000993D4 File Offset: 0x000975D4
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

	// Token: 0x06004862 RID: 18530 RVA: 0x0009944F File Offset: 0x0009764F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "隐藏网格体";
	}

	// Token: 0x06004863 RID: 18531 RVA: 0x00099456 File Offset: 0x00097656
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateHideMesh._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideMesh.TsAnimNotifyStateHideMesh_C");
		}
		return TsAnimNotifyStateHideMesh._ClassPtr;
	}

	// Token: 0x06004864 RID: 18532 RVA: 0x0009947C File Offset: 0x0009767C
	public TsAnimNotifyStateHideMesh() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideMesh.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004865 RID: 18533 RVA: 0x000994A4 File Offset: 0x000976A4
	[NullableContext(1)]
	public TsAnimNotifyStateHideMesh(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideMesh.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004866 RID: 18534 RVA: 0x000994D7 File Offset: 0x000976D7
	protected TsAnimNotifyStateHideMesh(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004867 RID: 18535 RVA: 0x000994E0 File Offset: 0x000976E0
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004868 RID: 18536 RVA: 0x0009951C File Offset: 0x0009771C
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004869 RID: 18537 RVA: 0x0009954F File Offset: 0x0009774F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400141E RID: 5150
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1,
		1
	})]
	private static Dictionary<AActor, Dictionary<TsAnimNotifyStateHideMesh, HideMeshParams>> _actorAnsMap;

	// Token: 0x0400141F RID: 5151
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideMesh.TsAnimNotifyStateHideMesh_C";

	// Token: 0x04001420 RID: 5152
	private static IntPtr _ClassPtr;

	// Token: 0x04001421 RID: 5153
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001422 RID: 5154
	private static int __PropertyOffset_ChildMeshName;

	// Token: 0x04001423 RID: 5155
	private static int __PropertyOffset_HideChildren;

	// Token: 0x04001424 RID: 5156
	private static int __PropertyOffset_HideChildrenActors;

	// Token: 0x04001425 RID: 5157
	private static int __PropertyOffset_EndEffect;

	// Token: 0x04001426 RID: 5158
	private static int __PropertyOffset_Hide;
}
