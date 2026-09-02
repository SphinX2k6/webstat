using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Components;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003918 RID: 14616
[NullableContext(1)]
[Nullable(0)]
public class __CharRenderingComponent_SubClassMissingExportProxy : __CharRenderingComponent_InheritProxy
{
	// Token: 0x0601D852 RID: 120914 RVA: 0x008D01E0 File Offset: 0x008CE3E0
	protected __CharRenderingComponent_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CharRenderingComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D853 RID: 120915 RVA: 0x008D0213 File Offset: 0x008CE413
	protected __CharRenderingComponent_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D854 RID: 120916 RVA: 0x008D021C File Offset: 0x008CE41C
	public unsafe override float QuickInitAndAddData(UObject data, [Nullable(2)] ASkeletalMeshActor meshActor)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddData_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddData_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddData_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshActor) = ((meshActor != null) ? meshActor.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D855 RID: 120917 RVA: 0x008D02BC File Offset: 0x008CE4BC
	public unsafe override float QuickInitAndAddDataWithMeshComponent(UObject data, [Nullable(2)] UMeshComponent meshComponent)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddDataWithMeshComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddDataWithMeshComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshComponent) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D856 RID: 120918 RVA: 0x008D035C File Offset: 0x008CE55C
	public unsafe override float QuickInitAndAddDataGroup(UObject data, [Nullable(2)] ASkeletalMeshActor meshActor)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddDataGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddDataGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshActor) = ((meshActor != null) ? meshActor.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D857 RID: 120919 RVA: 0x008D03FC File Offset: 0x008CE5FC
	public unsafe override float QuickInitAndAddDataGroupWithMeshComponent(UObject data, [Nullable(2)] UMeshComponent meshComponent)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("QuickInitAndAddDataGroupWithMeshComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__QuickInitAndAddDataGroupWithMeshComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->meshComponent) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D858 RID: 120920 RVA: 0x008D049C File Offset: 0x008CE69C
	public unsafe override void Init(ECharacterRenderingType renderType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Init"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__Init_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__Init_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__Init_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->renderType) = (byte)renderType;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D859 RID: 120921 RVA: 0x008D0518 File Offset: 0x008CE718
	[NullableContext(2)]
	public unsafe override void SetLogicOwner(AActor owner)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetLogicOwner"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetLogicOwner_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetLogicOwner_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetLogicOwner_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->owner) = ((owner != null) ? owner.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D85A RID: 120922 RVA: 0x008D05A0 File Offset: 0x008CE7A0
	public unsafe override void AddComponent(string skelName, UMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D85B RID: 120923 RVA: 0x008D0634 File Offset: 0x008CE834
	public unsafe override void AddComponentWithEmptyMaterial(string skelName, UMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponentWithEmptyMaterial"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponentWithEmptyMaterial_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D85C RID: 120924 RVA: 0x008D06C8 File Offset: 0x008CE8C8
	public unsafe override void RemoveComponent(string skelName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D85D RID: 120925 RVA: 0x008D0748 File Offset: 0x008CE948
	[NullableContext(2)]
	public unsafe override void AddComponentByCase(ECharacterControllerCaseType caseType, UMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponentByCase"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponentByCase_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponentByCase_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponentByCase_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->caseType) = (byte)caseType;
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D85E RID: 120926 RVA: 0x008D07D8 File Offset: 0x008CE9D8
	public unsafe override void RemoveComponentByCase(ECharacterControllerCaseType caseType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveComponentByCase"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveComponentByCase_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveComponentByCase_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveComponentByCase_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->caseType) = (byte)caseType;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D85F RID: 120927 RVA: 0x008D0854 File Offset: 0x008CEA54
	public unsafe override void AddComponentInnerV2(string skelName, UMeshComponent skeletalComp, bool useEmptyMaterial)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddComponentInnerV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddComponentInnerV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddComponentInnerV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddComponentInnerV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
			ptr2->useEmptyMaterial = useEmptyMaterial;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D860 RID: 120928 RVA: 0x008D08F0 File Offset: 0x008CEAF0
	public unsafe override void RemoveComponentInnerV2(string skelName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveComponentInnerV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveComponentInnerV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D861 RID: 120929 RVA: 0x008D0970 File Offset: 0x008CEB70
	[return: Nullable(2)]
	public unsafe override USkeletalMeshComponent GetSkeletalMeshComponent(string skelName)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetSkeletalMeshComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetSkeletalMeshComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			FString.CopyFrom((void*)(&ptr2->skelName), skelName);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601D862 RID: 120930 RVA: 0x008D09F8 File Offset: 0x008CEBF8
	public unsafe override FName GetSkeletalMeshComponentBodyName(USkeletalMeshComponent skeletalComp)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetSkeletalMeshComponentBodyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetSkeletalMeshComponentBodyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->skeletalComp) = ((skeletalComp != null) ? skeletalComp.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		FName _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D863 RID: 120931 RVA: 0x008D0A84 File Offset: 0x008CEC84
	public unsafe override bool CheckInit()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("CheckInit"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__CheckInit_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__CheckInit_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__CheckInit_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D864 RID: 120932 RVA: 0x008D0AFC File Offset: 0x008CECFC
	public unsafe override void SetDebug(bool value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDebug"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDebug_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDebug_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDebug_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D865 RID: 120933 RVA: 0x008D0B74 File Offset: 0x008CED74
	[NullableContext(2)]
	public unsafe override PD_MaterialDebug_C GetDebugInfo()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetDebugInfo"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetDebugInfo_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetDebugInfo_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetDebugInfo_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		PD_MaterialDebug_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<PD_MaterialDebug_C>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601D866 RID: 120934 RVA: 0x008D0BF0 File Offset: 0x008CEDF0
	public unsafe override bool GetInWater(float depthThreshold)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetInWater"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetInWater_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetInWater_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetInWater_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->depthThreshold = depthThreshold;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D867 RID: 120935 RVA: 0x008D0C70 File Offset: 0x008CEE70
	public unsafe override bool GetInAudioShr()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetInAudioShr"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetInAudioShr_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetInAudioShr_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetInAudioShr_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D868 RID: 120936 RVA: 0x008D0CE8 File Offset: 0x008CEEE8
	public unsafe override void ResetAllRenderingState()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ResetAllRenderingState"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D869 RID: 120937 RVA: 0x008D0D58 File Offset: 0x008CEF58
	[NullableContext(2)]
	public unsafe override int AddMaterialControllerDataGroup(UObject data)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerDataGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerDataGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D86A RID: 120938 RVA: 0x008D0DE4 File Offset: 0x008CEFE4
	[NullableContext(2)]
	public unsafe override float AddMaterialControllerDataGroupWithAnimObject(UObject data, USkeletalMeshComponent animObject)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerDataGroupWithAnimObject"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerDataGroupWithAnimObject_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->animObject) = ((animObject != null) ? animObject.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D86B RID: 120939 RVA: 0x008D0E84 File Offset: 0x008CF084
	public unsafe override void RemoveMaterialControllerDataGroup(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerDataGroup"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerDataGroup_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D86C RID: 120940 RVA: 0x008D0EFC File Offset: 0x008CF0FC
	public unsafe override void RemoveMaterialControllerDataGroupWithEnding(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerDataGroupWithEnding"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerDataGroupWithEnding_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D86D RID: 120941 RVA: 0x008D0F74 File Offset: 0x008CF174
	[NullableContext(2)]
	public unsafe override float AddMaterialControllerDataWithAnimObject(UObject data, USkeletalMeshComponent animObject, UObject userData)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerDataWithAnimObject"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerDataWithAnimObject_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
			*(&ptr2->animObject) = ((animObject != null) ? animObject.NativePtr : ((IntPtr)0));
			*(&ptr2->userData) = ((userData != null) ? userData.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D86E RID: 120942 RVA: 0x008D102C File Offset: 0x008CF22C
	[NullableContext(2)]
	public unsafe override int AddMaterialControllerData(UObject data)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddMaterialControllerData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddMaterialControllerData_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddMaterialControllerData_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddMaterialControllerData_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->data) = ((data != null) ? data.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		int _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D86F RID: 120943 RVA: 0x008D10B8 File Offset: 0x008CF2B8
	public unsafe override void RemoveMaterialControllerData(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerData_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D870 RID: 120944 RVA: 0x008D1130 File Offset: 0x008CF330
	public unsafe override void SetEffectPause(int handle, bool paused)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEffectPause"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetEffectPause_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetEffectPause_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetEffectPause_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
			ptr2->paused = paused;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D871 RID: 120945 RVA: 0x008D11B0 File Offset: 0x008CF3B0
	public unsafe override void RemoveMaterialControllerDataWithEnding(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveMaterialControllerDataWithEnding"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveMaterialControllerDataWithEnding_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D872 RID: 120946 RVA: 0x008D1228 File Offset: 0x008CF428
	public unsafe override void SetDitherEffect(float ditherRate, ECharacterDitherType ditherType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDitherEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDitherEffect_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDitherEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->ditherRate = ditherRate;
			*(&ptr2->ditherType) = (byte)ditherType;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D873 RID: 120947 RVA: 0x008D12A8 File Offset: 0x008CF4A8
	public unsafe override void SetDisableFightDither(bool disable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDisableFightDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDisableFightDither_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDisableFightDither_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDisableFightDither_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->disable = disable;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D874 RID: 120948 RVA: 0x008D1320 File Offset: 0x008CF520
	public unsafe override void SetDitherApplyAll()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherApplyAll"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D875 RID: 120949 RVA: 0x008D1390 File Offset: 0x008CF590
	public unsafe override void SetDitherApplyHeadsOnly()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherApplyHeadsOnly"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D876 RID: 120950 RVA: 0x008D1400 File Offset: 0x008CF600
	public unsafe override void SetDitherUseHeadMaskHideEffect(bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDitherUseHeadMaskHideEffect"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDitherUseHeadMaskHideEffect_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D877 RID: 120951 RVA: 0x008D1478 File Offset: 0x008CF678
	public unsafe override void TempRemoveDither()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TempRemoveDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D878 RID: 120952 RVA: 0x008D14E8 File Offset: 0x008CF6E8
	public unsafe override void TempRecoverDither()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("TempRecoverDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D879 RID: 120953 RVA: 0x008D1558 File Offset: 0x008CF758
	public unsafe override float GetOpacityConsiderVisibility()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetOpacityConsiderVisibility"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__GetOpacityConsiderVisibility_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		float _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D87A RID: 120954 RVA: 0x008D15D0 File Offset: 0x008CF7D0
	public unsafe override void SetMaterialPropertyFloat(ECharacterBodySpecifiedType bodyType, float sectionIndex, ECharacterSlotSpecifiedType slotType, string propertyName, float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyFloat"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyFloat_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->bodyType) = (byte)bodyType;
			ptr2->sectionIndex = sectionIndex;
			*(&ptr2->slotType) = (byte)slotType;
			FString.CopyFrom((void*)(&ptr2->propertyName), propertyName);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D87B RID: 120955 RVA: 0x008D1670 File Offset: 0x008CF870
	public unsafe override void SetMaterialPropertyColor(ECharacterBodySpecifiedType bodyType, float sectionIndex, ECharacterSlotSpecifiedType slotType, string propertyName, FLinearColor value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyColor"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyColor_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->bodyType) = (byte)bodyType;
			ptr2->sectionIndex = sectionIndex;
			*(&ptr2->slotType) = (byte)slotType;
			FString.CopyFrom((void*)(&ptr2->propertyName), propertyName);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D87C RID: 120956 RVA: 0x008D1710 File Offset: 0x008CF910
	public unsafe override void SetMaterialPropertyFloatV2(FName name, float value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyFloatV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyFloatV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->name = name;
			ptr2->value = value;
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D87D RID: 120957 RVA: 0x008D17AC File Offset: 0x008CF9AC
	public unsafe override void AddFloatUpdateParamPermanentByIndexV2(FName name, float value, FName bodyName, float materialIndex)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AddFloatUpdateParamPermanentByIndexV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__AddFloatUpdateParamPermanentByIndexV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->name = name;
			ptr2->value = value;
			ptr2->bodyName = bodyName;
			ptr2->materialIndex = materialIndex;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D87E RID: 120958 RVA: 0x008D183C File Offset: 0x008CFA3C
	public unsafe override void SetMaterialPropertyColorV2(FName name, FLinearColor value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialPropertyColorV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialPropertyColorV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->name = name;
			ptr2->value = value;
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D87F RID: 120959 RVA: 0x008D18D8 File Offset: 0x008CFAD8
	public unsafe override void SetMaterialReplaceV2(UMaterialInterface material, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMaterialReplaceV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetMaterialReplaceV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->material) = ((material != null) ? material.NativePtr : ((IntPtr)0));
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D880 RID: 120960 RVA: 0x008D197C File Offset: 0x008CFB7C
	public unsafe override void RemoveExternalMaterialReplaceV2(EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart meshPart)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveExternalMaterialReplaceV2"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__RemoveExternalMaterialReplaceV2_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->bodyType) = (byte)bodyType;
			*(&ptr2->slotType) = (byte)slotType;
			*(&ptr2->meshPart) = (byte)meshPart;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D881 RID: 120961 RVA: 0x008D1A08 File Offset: 0x008CFC08
	public unsafe override void SetStarScarEnergy(float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetStarScarEnergy"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetStarScarEnergy_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetStarScarEnergy_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetStarScarEnergy_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D882 RID: 120962 RVA: 0x008D1A80 File Offset: 0x008CFC80
	public unsafe override void SetCapsuleDither(float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetCapsuleDither"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetCapsuleDither_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetCapsuleDither_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetCapsuleDither_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D883 RID: 120963 RVA: 0x008D1AF8 File Offset: 0x008CFCF8
	public unsafe override void SetDecalShadowEnabled(bool enable)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetDecalShadowEnabled"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetDecalShadowEnabled_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->enable = enable;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D884 RID: 120964 RVA: 0x008D1B70 File Offset: 0x008CFD70
	public unsafe override void DisableAllShadowByDecalShadowComponent()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DisableAllShadowByDecalShadowComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D885 RID: 120965 RVA: 0x008D1BE0 File Offset: 0x008CFDE0
	public unsafe override void SetShouldCastShadow(bool castShadow)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetShouldCastShadow"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetShouldCastShadow_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetShouldCastShadow_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetShouldCastShadow_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->castShadow = castShadow;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D886 RID: 120966 RVA: 0x008D1C58 File Offset: 0x008CFE58
	public unsafe override void SetEffectProgress(float progress, int handleId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEffectProgress"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetEffectProgress_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetEffectProgress_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetEffectProgress_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->progress = progress;
			ptr2->handleId = handleId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D887 RID: 120967 RVA: 0x008D1CD8 File Offset: 0x008CFED8
	public unsafe override void SetEffectGroupProgress(float progress, int groupHandleId)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetEffectGroupProgress"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__SetEffectGroupProgress_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__SetEffectGroupProgress_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__SetEffectGroupProgress_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->progress = progress;
			ptr2->groupHandleId = groupHandleId;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D888 RID: 120968 RVA: 0x008D1D58 File Offset: 0x008CFF58
	public unsafe override void RefreshMaterialController()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RefreshMaterialController"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D889 RID: 120969 RVA: 0x008D1DC8 File Offset: 0x008CFFC8
	public unsafe override void Destroy()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Destroy"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D88A RID: 120970 RVA: 0x008D1E38 File Offset: 0x008D0038
	public unsafe override void OnFinalizedLevelSequence()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnFinalizedLevelSequence"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* ptr2 = null;
		if (num != 0)
		{
			ptr2 = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D88B RID: 120971 RVA: 0x008D1EA8 File Offset: 0x008D00A8
	public unsafe override bool ShouldTickAfterGoDown()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ShouldTickAfterGoDown"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__ShouldTickAfterGoDown_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D88C RID: 120972 RVA: 0x008D1F20 File Offset: 0x008D0120
	public unsafe override void ReceiveSeqTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveSeqTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		CharRenderingComponent.__ReceiveSeqTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((CharRenderingComponent.__ReceiveSeqTick_FunctionParams*)ptr + 15L / (long)sizeof(CharRenderingComponent.__ReceiveSeqTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->deltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
