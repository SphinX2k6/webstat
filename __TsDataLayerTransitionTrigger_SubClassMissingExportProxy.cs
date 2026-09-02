using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038EE RID: 14574
[NullableContext(1)]
[Nullable(0)]
public class __TsDataLayerTransitionTrigger_SubClassMissingExportProxy : __TsDataLayerTransitionTrigger_InheritProxy
{
	// Token: 0x0601D724 RID: 120612 RVA: 0x008CCB58 File Offset: 0x008CAD58
	protected __TsDataLayerTransitionTrigger_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDataLayerTransitionTrigger.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D725 RID: 120613 RVA: 0x008CCB8B File Offset: 0x008CAD8B
	protected __TsDataLayerTransitionTrigger_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D726 RID: 120614 RVA: 0x008CCB94 File Offset: 0x008CAD94
	[NullableContext(2)]
	public unsafe override void SetMatForActivatingDataLayers(UKuroSceneMatModifyDataAsset asset)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMatForActivatingDataLayers"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__SetMatForActivatingDataLayers_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__SetMatForActivatingDataLayers_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__SetMatForActivatingDataLayers_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D727 RID: 120615 RVA: 0x008CCC1C File Offset: 0x008CAE1C
	public unsafe override bool WasMatForActivatingDataLayersSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasMatForActivatingDataLayersSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__WasMatForActivatingDataLayersSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__WasMatForActivatingDataLayersSet_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__WasMatForActivatingDataLayersSet_FunctionParams) & -16L);
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

	// Token: 0x0601D728 RID: 120616 RVA: 0x008CCC94 File Offset: 0x008CAE94
	[NullableContext(2)]
	public unsafe override void SetMatForDeactivatingDataLayers(UKuroSceneMatModifyDataAsset asset)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMatForDeactivatingDataLayers"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__SetMatForDeactivatingDataLayers_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__SetMatForDeactivatingDataLayers_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__SetMatForDeactivatingDataLayers_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D729 RID: 120617 RVA: 0x008CCD1C File Offset: 0x008CAF1C
	public unsafe override bool WasMatForDeactivatingDataLayersSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasMatForDeactivatingDataLayersSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__WasMatForDeactivatingDataLayersSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__WasMatForDeactivatingDataLayersSet_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__WasMatForDeactivatingDataLayersSet_FunctionParams) & -16L);
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

	// Token: 0x0601D72A RID: 120618 RVA: 0x008CCD94 File Offset: 0x008CAF94
	public unsafe override void SetSeqForSourceIn([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetSeqForSourceIn"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__SetSeqForSourceIn_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__SetSeqForSourceIn_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__SetSeqForSourceIn_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
			FString.CopyFrom((void*)(&ptr2->beforeModifyMatMark), beforeModifyMatMark);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D72B RID: 120619 RVA: 0x008CCE28 File Offset: 0x008CB028
	public unsafe override bool WasSeqForSourceInSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasSeqForSourceInSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__WasSeqForSourceInSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__WasSeqForSourceInSet_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__WasSeqForSourceInSet_FunctionParams) & -16L);
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

	// Token: 0x0601D72C RID: 120620 RVA: 0x008CCEA0 File Offset: 0x008CB0A0
	public unsafe override void SetSeqForSourceOut([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetSeqForSourceOut"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__SetSeqForSourceOut_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__SetSeqForSourceOut_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__SetSeqForSourceOut_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
			FString.CopyFrom((void*)(&ptr2->beforeModifyMatMark), beforeModifyMatMark);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D72D RID: 120621 RVA: 0x008CCF34 File Offset: 0x008CB134
	public unsafe override bool WasSeqForSourceOutSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasSeqForSourceOutSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsDataLayerTransitionTrigger.__WasSeqForSourceOutSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsDataLayerTransitionTrigger.__WasSeqForSourceOutSet_FunctionParams*)ptr + 15L / (long)sizeof(TsDataLayerTransitionTrigger.__WasSeqForSourceOutSet_FunctionParams) & -16L);
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
}
