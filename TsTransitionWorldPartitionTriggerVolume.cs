using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.DataLayerSwitch;
using CSharpScript.Game.Module.Teleport;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200325E RID: 12894
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsTransitionWorldPartitionTriggerVolume.TsTransitionWorldPartitionTriggerVolume_C")]
public class TsTransitionWorldPartitionTriggerVolume : AWorldPartitionTriggerVolume, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700248C RID: 9356
	// (get) Token: 0x0601AE2B RID: 110123 RVA: 0x008056F0 File Offset: 0x008038F0
	// (set) Token: 0x0601AE2C RID: 110124 RVA: 0x00805700 File Offset: 0x00803900
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool FunctionEnable
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_FunctionEnable) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_FunctionEnable) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700248D RID: 9357
	// (get) Token: 0x0601AE2D RID: 110125 RVA: 0x00805711 File Offset: 0x00803911
	// (set) Token: 0x0601AE2E RID: 110126 RVA: 0x00805721 File Offset: 0x00803921
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe bool UseTransitionWhenTeleport
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_UseTransitionWhenTeleport) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_UseTransitionWhenTeleport) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700248E RID: 9358
	// (get) Token: 0x0601AE2F RID: 110127 RVA: 0x00805732 File Offset: 0x00803932
	// (set) Token: 0x0601AE30 RID: 110128 RVA: 0x00805746 File Offset: 0x00803946
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe UKuroSceneMatModifyDataAsset MatForActivatingDataLayers
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroSceneMatModifyDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_MatForActivatingDataLayers);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_MatForActivatingDataLayers, value);
		}
	}

	// Token: 0x1700248F RID: 9359
	// (get) Token: 0x0601AE31 RID: 110129 RVA: 0x0080575B File Offset: 0x0080395B
	// (set) Token: 0x0601AE32 RID: 110130 RVA: 0x0080576F File Offset: 0x0080396F
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe UKuroSceneMatModifyDataAsset MatForDeactivatingDataLayers
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroSceneMatModifyDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_MatForDeactivatingDataLayers);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_MatForDeactivatingDataLayers, value);
		}
	}

	// Token: 0x17002490 RID: 9360
	// (get) Token: 0x0601AE33 RID: 110131 RVA: 0x00805784 File Offset: 0x00803984
	// (set) Token: 0x0601AE34 RID: 110132 RVA: 0x00805798 File Offset: 0x00803998
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe ULevelSequence SeqForSourceIn
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqForSourceIn);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqForSourceIn, value);
		}
	}

	// Token: 0x17002491 RID: 9361
	// (get) Token: 0x0601AE35 RID: 110133 RVA: 0x008057AD File Offset: 0x008039AD
	// (set) Token: 0x0601AE36 RID: 110134 RVA: 0x008057C1 File Offset: 0x008039C1
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe string SeqMarkBeforeModifyMatForSourceIn
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqMarkBeforeModifyMatForSourceIn)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqMarkBeforeModifyMatForSourceIn)), value);
		}
	}

	// Token: 0x17002492 RID: 9362
	// (get) Token: 0x0601AE37 RID: 110135 RVA: 0x008057D6 File Offset: 0x008039D6
	// (set) Token: 0x0601AE38 RID: 110136 RVA: 0x008057EA File Offset: 0x008039EA
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe ULevelSequence SeqForSourceOut
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqForSourceOut);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqForSourceOut, value);
		}
	}

	// Token: 0x17002493 RID: 9363
	// (get) Token: 0x0601AE39 RID: 110137 RVA: 0x008057FF File Offset: 0x008039FF
	// (set) Token: 0x0601AE3A RID: 110138 RVA: 0x00805813 File Offset: 0x00803A13
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe string SeqMarkBeforeModifyMatForSourceOut
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqMarkBeforeModifyMatForSourceOut)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_SeqMarkBeforeModifyMatForSourceOut)), value);
		}
	}

	// Token: 0x17002494 RID: 9364
	// (get) Token: 0x0601AE3B RID: 110139 RVA: 0x00805828 File Offset: 0x00803A28
	// (set) Token: 0x0601AE3C RID: 110140 RVA: 0x00805838 File Offset: 0x00803A38
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float WaitDataLayerStreamingRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_WaitDataLayerStreamingRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_WaitDataLayerStreamingRadius) = value;
		}
	}

	// Token: 0x17002495 RID: 9365
	// (get) Token: 0x0601AE3D RID: 110141 RVA: 0x00805849 File Offset: 0x00803A49
	// (set) Token: 0x0601AE3E RID: 110142 RVA: 0x00805859 File Offset: 0x00803A59
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxTimeForWaitDataLayerActivateFinish
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_MaxTimeForWaitDataLayerActivateFinish);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTransitionWorldPartitionTriggerVolume.__PropertyOffset_MaxTimeForWaitDataLayerActivateFinish) = value;
		}
	}

	// Token: 0x0601AE3F RID: 110143 RVA: 0x0080586C File Offset: 0x00803A6C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMatForActivatingDataLayers(UKuroSceneMatModifyDataAsset asset)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMatForActivatingDataLayers"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__SetMatForActivatingDataLayers_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__SetMatForActivatingDataLayers_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__SetMatForActivatingDataLayers_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AE40 RID: 110144 RVA: 0x008058F0 File Offset: 0x00803AF0
	protected void SetMatForActivatingDataLayers_Implementation(UKuroSceneMatModifyDataAsset asset)
	{
		this.MatForActivatingDataLayers = asset;
		this.MatPathForActivatingDataLayers = null;
		if (this.MatForActivatingDataLayersLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MatForActivatingDataLayersLoadingHandle);
			this.MatForActivatingDataLayersLoadingHandle = -1;
		}
	}

	// Token: 0x0601AE41 RID: 110145 RVA: 0x00805920 File Offset: 0x00803B20
	public void SetMatForActivatingDataLayersByPath(string path)
	{
		this.MatForActivatingDataLayers = null;
		this.MatPathForActivatingDataLayers = path;
		if (this.MatForActivatingDataLayersLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MatForActivatingDataLayersLoadingHandle);
			this.MatForActivatingDataLayersLoadingHandle = -1;
		}
		if (!string.IsNullOrEmpty(path))
		{
			bool loadCallbackCalled = false;
			int matForActivatingDataLayersLoadingHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UKuroSceneMatModifyDataAsset>(path, delegate([Nullable(2)] UKuroSceneMatModifyDataAsset asset, string _)
			{
				loadCallbackCalled = true;
				this.MatForActivatingDataLayersLoadingHandle = -1;
				this.SetMatForActivatingDataLayers(asset);
			}, 100, "js_undefined");
			if (!loadCallbackCalled)
			{
				this.MatForActivatingDataLayersLoadingHandle = matForActivatingDataLayersLoadingHandle;
			}
		}
	}

	// Token: 0x0601AE42 RID: 110146 RVA: 0x008059A8 File Offset: 0x00803BA8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasMatForActivatingDataLayersSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasMatForActivatingDataLayersSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__WasMatForActivatingDataLayersSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__WasMatForActivatingDataLayersSet_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__WasMatForActivatingDataLayersSet_FunctionParams) & -16L);
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

	// Token: 0x0601AE43 RID: 110147 RVA: 0x00805A1D File Offset: 0x00803C1D
	protected bool WasMatForActivatingDataLayersSet_Implementation()
	{
		if (this.MatForActivatingDataLayersLoadingHandle != -1)
		{
			string matPathForActivatingDataLayers = this.MatPathForActivatingDataLayers;
			return matPathForActivatingDataLayers != null && matPathForActivatingDataLayers.Length > 0;
		}
		UKuroSceneMatModifyDataAsset matForActivatingDataLayers = this.MatForActivatingDataLayers;
		return matForActivatingDataLayers != null && matForActivatingDataLayers.IsValid();
	}

	// Token: 0x0601AE44 RID: 110148 RVA: 0x00805A50 File Offset: 0x00803C50
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMatForDeactivatingDataLayers(UKuroSceneMatModifyDataAsset asset)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetMatForDeactivatingDataLayers"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__SetMatForDeactivatingDataLayers_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__SetMatForDeactivatingDataLayers_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__SetMatForDeactivatingDataLayers_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AE45 RID: 110149 RVA: 0x00805AD4 File Offset: 0x00803CD4
	protected void SetMatForDeactivatingDataLayers_Implementation(UKuroSceneMatModifyDataAsset asset)
	{
		this.MatForDeactivatingDataLayers = asset;
		this.MatPathForDeactivatingDataLayers = null;
		if (this.MatForDeactivatingDataLayersLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MatForDeactivatingDataLayersLoadingHandle);
			this.MatForDeactivatingDataLayersLoadingHandle = -1;
		}
	}

	// Token: 0x0601AE46 RID: 110150 RVA: 0x00805B04 File Offset: 0x00803D04
	public void SetMatForDeactivatingDataLayersByPath(string path)
	{
		this.MatForDeactivatingDataLayers = null;
		this.MatPathForDeactivatingDataLayers = path;
		if (this.MatForDeactivatingDataLayersLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MatForDeactivatingDataLayersLoadingHandle);
			this.MatForDeactivatingDataLayersLoadingHandle = -1;
		}
		if (!string.IsNullOrEmpty(path))
		{
			bool loadCallbackCalled = false;
			int matForDeactivatingDataLayersLoadingHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UKuroSceneMatModifyDataAsset>(path, delegate([Nullable(2)] UKuroSceneMatModifyDataAsset asset, string _)
			{
				loadCallbackCalled = true;
				this.MatForDeactivatingDataLayersLoadingHandle = -1;
				this.SetMatForDeactivatingDataLayers(asset);
			}, 100, "js_undefined");
			if (!loadCallbackCalled)
			{
				this.MatForDeactivatingDataLayersLoadingHandle = matForDeactivatingDataLayersLoadingHandle;
			}
		}
	}

	// Token: 0x0601AE47 RID: 110151 RVA: 0x00805B8C File Offset: 0x00803D8C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasMatForDeactivatingDataLayersSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasMatForDeactivatingDataLayersSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__WasMatForDeactivatingDataLayersSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__WasMatForDeactivatingDataLayersSet_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__WasMatForDeactivatingDataLayersSet_FunctionParams) & -16L);
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

	// Token: 0x0601AE48 RID: 110152 RVA: 0x00805C01 File Offset: 0x00803E01
	protected bool WasMatForDeactivatingDataLayersSet_Implementation()
	{
		if (this.MatForDeactivatingDataLayersLoadingHandle != -1)
		{
			string matPathForDeactivatingDataLayers = this.MatPathForDeactivatingDataLayers;
			return matPathForDeactivatingDataLayers != null && matPathForDeactivatingDataLayers.Length > 0;
		}
		UKuroSceneMatModifyDataAsset matForDeactivatingDataLayers = this.MatForDeactivatingDataLayers;
		return matForDeactivatingDataLayers != null && matForDeactivatingDataLayers.IsValid();
	}

	// Token: 0x0601AE49 RID: 110153 RVA: 0x00805C34 File Offset: 0x00803E34
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetSeqForSourceIn([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetSeqForSourceIn"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceIn_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceIn_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceIn_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
			FString.CopyFrom((void*)(&ptr2->beforeModifyMatMark), beforeModifyMatMark);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AE4A RID: 110154 RVA: 0x00805CC5 File Offset: 0x00803EC5
	[NullableContext(1)]
	protected void SetSeqForSourceIn_Implementation([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
	{
		this.SeqForSourceIn = asset;
		this.SeqPathForSourceIn = null;
		this.SeqMarkBeforeModifyMatForSourceIn = beforeModifyMatMark;
		if (this.SeqForSourceInLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SeqForSourceInLoadingHandle);
			this.SeqForSourceInLoadingHandle = -1;
		}
	}

	// Token: 0x0601AE4B RID: 110155 RVA: 0x00805CFC File Offset: 0x00803EFC
	[NullableContext(1)]
	public void SetSeqForSourceInByPath([Nullable(2)] string path, string beforeModifyMatMark = "")
	{
		this.SeqForSourceIn = null;
		this.SeqPathForSourceIn = path;
		this.SeqMarkBeforeModifyMatForSourceIn = beforeModifyMatMark;
		if (this.SeqForSourceInLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SeqForSourceInLoadingHandle);
			this.SeqForSourceInLoadingHandle = -1;
		}
		if (!string.IsNullOrEmpty(path))
		{
			bool loadCallbackCalled = false;
			int seqForSourceInLoadingHandle = Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(path, delegate([Nullable(2)] ULevelSequence asset, string _)
			{
				loadCallbackCalled = true;
				this.SeqForSourceInLoadingHandle = -1;
				this.SetSeqForSourceIn(asset, beforeModifyMatMark);
			}, 100, "js_undefined");
			if (!loadCallbackCalled)
			{
				this.SeqForSourceInLoadingHandle = seqForSourceInLoadingHandle;
			}
		}
	}

	// Token: 0x0601AE4C RID: 110156 RVA: 0x00805D94 File Offset: 0x00803F94
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasSeqForSourceInSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasSeqForSourceInSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceInSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceInSet_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceInSet_FunctionParams) & -16L);
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

	// Token: 0x0601AE4D RID: 110157 RVA: 0x00805E09 File Offset: 0x00804009
	protected bool WasSeqForSourceInSet_Implementation()
	{
		if (this.SeqForSourceInLoadingHandle != -1)
		{
			string seqPathForSourceIn = this.SeqPathForSourceIn;
			return seqPathForSourceIn != null && seqPathForSourceIn.Length > 0;
		}
		ULevelSequence seqForSourceIn = this.SeqForSourceIn;
		return seqForSourceIn != null && seqForSourceIn.IsValid();
	}

	// Token: 0x0601AE4E RID: 110158 RVA: 0x00805E3C File Offset: 0x0080403C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetSeqForSourceOut([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetSeqForSourceOut"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceOut_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceOut_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceOut_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->asset) = ((asset != null) ? asset.NativePtr : ((IntPtr)0));
			FString.CopyFrom((void*)(&ptr2->beforeModifyMatMark), beforeModifyMatMark);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601AE4F RID: 110159 RVA: 0x00805ECD File Offset: 0x008040CD
	[NullableContext(1)]
	protected void SetSeqForSourceOut_Implementation([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
	{
		this.SeqForSourceOut = asset;
		this.SeqPathForSourceOut = null;
		this.SeqMarkBeforeModifyMatForSourceOut = beforeModifyMatMark;
		if (this.SeqForSourceOutLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SeqForSourceOutLoadingHandle);
			this.SeqForSourceOutLoadingHandle = -1;
		}
	}

	// Token: 0x0601AE50 RID: 110160 RVA: 0x00805F04 File Offset: 0x00804104
	[NullableContext(1)]
	public void SetSeqForSourceOutByPath([Nullable(2)] string path, string beforeModifyMatMark = "")
	{
		this.SeqForSourceOut = null;
		this.SeqPathForSourceOut = path;
		this.SeqMarkBeforeModifyMatForSourceOut = beforeModifyMatMark;
		if (this.SeqForSourceOutLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SeqForSourceOutLoadingHandle);
			this.SeqForSourceOutLoadingHandle = -1;
		}
		if (!string.IsNullOrEmpty(path))
		{
			bool loadCallbackCalled = false;
			int seqForSourceOutLoadingHandle = Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>(path, delegate([Nullable(2)] ULevelSequence asset, string _)
			{
				loadCallbackCalled = true;
				this.SeqForSourceOutLoadingHandle = -1;
				this.SetSeqForSourceOut(asset, beforeModifyMatMark);
			}, 100, "js_undefined");
			if (!loadCallbackCalled)
			{
				this.SeqForSourceOutLoadingHandle = seqForSourceOutLoadingHandle;
			}
		}
	}

	// Token: 0x0601AE51 RID: 110161 RVA: 0x00805F9C File Offset: 0x0080419C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasSeqForSourceOutSet()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("WasSeqForSourceOutSet"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceOutSet_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceOutSet_FunctionParams*)ptr + 15L / (long)sizeof(TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceOutSet_FunctionParams) & -16L);
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

	// Token: 0x0601AE52 RID: 110162 RVA: 0x00806011 File Offset: 0x00804211
	protected bool WasSeqForSourceOutSet_Implementation()
	{
		if (this.SeqForSourceOutLoadingHandle != -1)
		{
			string seqPathForSourceOut = this.SeqPathForSourceOut;
			return seqPathForSourceOut != null && seqPathForSourceOut.Length > 0;
		}
		ULevelSequence seqForSourceOut = this.SeqForSourceOut;
		return seqForSourceOut != null && seqForSourceOut.IsValid();
	}

	// Token: 0x0601AE53 RID: 110163 RVA: 0x00806044 File Offset: 0x00804244
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnStateChanged()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnStateChanged"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601AE54 RID: 110164 RVA: 0x008060B4 File Offset: 0x008042B4
	protected unsafe override void OnStateChanged_Implementation()
	{
		if (!this.FunctionEnable)
		{
			return;
		}
		HashSet<FName> hashSet = new HashSet<FName>();
		HashSet<FName> hashSet2 = new HashSet<FName>();
		foreach (KeyValuePair<FName, bool> keyValuePair in base.DatalayerStateMap)
		{
			FName fname;
			bool flag;
			keyValuePair.Deconstruct(out fname, out flag);
			FName item = fname;
			bool flag2 = flag;
			if ((base.State == EWorldPartitionTriggerVolumeState.StreamingSourceIn) ? flag2 : (!flag2))
			{
				hashSet.Add(item);
			}
			else
			{
				hashSet2.Add(item);
			}
			string text = item.ToString();
			if (!text.Contains("DLV"))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TriggerVolume;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[TsTransitionWorldPartitionTriggerVolume] 使用TsTransitionWorldPartitionTriggerVolume控制非DLV的Datalayer, 可能存在冲突, 请检查配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("State", base.State);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("DatalayerLabel", text);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}
		if (hashSet.Count > 0 && hashSet2.Count > 0 && this.WasMatForActivatingDataLayersSet() && this.WasMatForDeactivatingDataLayersSet() && ((base.State == EWorldPartitionTriggerVolumeState.StreamingSourceIn) ? this.WasSeqForSourceInSet() : this.WasSeqForSourceOutSet()))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TriggerVolume;
			ELogAuthor author2 = ELogAuthor.ZYL;
			string message2 = "[TsTransitionWorldPartitionTriggerVolume] 暂时不支持同时控制DataLayer显示的过渡和DataLayer隐藏的过渡, 可能存在表现问题, 请检查配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("State", base.State);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
		if (((hashSet.Count > 0 && this.WasMatForActivatingDataLayersSet()) || (hashSet2.Count > 0 && this.WasMatForDeactivatingDataLayersSet())) && !((base.State == EWorldPartitionTriggerVolumeState.StreamingSourceIn) ? this.WasSeqForSourceInSet() : this.WasSeqForSourceOutSet()))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.TriggerVolume;
			ELogAuthor author3 = ELogAuthor.ZYL;
			string message3 = "[TsTransitionWorldPartitionTriggerVolume] 设置了过渡DA和DataLayer, 但是没有设置过渡Seq, 可能存在表现问题, 请检查配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("State", base.State);
			instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
		}
		bool flag3 = true;
		if (ModelBase<TeleportModel>.Instance.IsTeleport || ModelBase<GameModeModel>.Instance.Loading)
		{
			if (this.UseTransitionWhenTeleport)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.TriggerVolume;
				ELogAuthor author4 = ELogAuthor.ZYL;
				string message4 = "[TsTransitionWorldPartitionTriggerVolume] 正在进行传送或加载, 根据配置仍使用过渡效果, 可能存在表现问题, 请检查配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("State", base.State);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
				flag3 = true;
			}
			else
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.TriggerVolume;
				ELogAuthor author5 = ELogAuthor.ZYL;
				string message5 = "[TsTransitionWorldPartitionTriggerVolume] 正在进行传送或加载, 根据配置忽略过渡效果";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("State", base.State);
				instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
				flag3 = false;
			}
		}
		DataLayersTransitionTask dataLayersTransitionTask = new DataLayersTransitionTask();
		dataLayersTransitionTask.ToActivateDataLayerNames = hashSet;
		dataLayersTransitionTask.ToDeactivateDataLayerNames = hashSet2;
		if (flag3)
		{
			dataLayersTransitionTask.MatDataForActivating = this.MatForActivatingDataLayers;
			dataLayersTransitionTask.MatPathForActivating = this.MatPathForActivatingDataLayers;
			dataLayersTransitionTask.MatDataForActivatingLoaded = (this.MatForActivatingDataLayersLoadingHandle == -1);
			dataLayersTransitionTask.MatDataForDeactivating = this.MatForDeactivatingDataLayers;
			dataLayersTransitionTask.MatPathForDeactivating = this.MatPathForDeactivatingDataLayers;
			dataLayersTransitionTask.MatDataForDeactivatingLoaded = (this.MatForDeactivatingDataLayersLoadingHandle == -1);
			if (base.State == EWorldPartitionTriggerVolumeState.StreamingSourceIn)
			{
				dataLayersTransitionTask.SeqData = this.SeqForSourceIn;
				dataLayersTransitionTask.SeqPath = this.SeqPathForSourceIn;
				dataLayersTransitionTask.SeqDataLoaded = (this.SeqForSourceInLoadingHandle == -1);
				dataLayersTransitionTask.SeqMarkBeforeModifyMat = this.SeqMarkBeforeModifyMatForSourceIn;
			}
			else
			{
				dataLayersTransitionTask.SeqData = this.SeqForSourceOut;
				dataLayersTransitionTask.SeqPath = this.SeqPathForSourceOut;
				dataLayersTransitionTask.SeqDataLoaded = (this.SeqForSourceOutLoadingHandle == -1);
				dataLayersTransitionTask.SeqMarkBeforeModifyMat = this.SeqMarkBeforeModifyMatForSourceOut;
			}
		}
		dataLayersTransitionTask.ShouldWaitDataLayersActivateFinish = (this.WaitDataLayerStreamingRadius > 0f);
		dataLayersTransitionTask.WaitDataLayerStreamingRadius = Singleton<MathUtils>.Instance.Clamp(this.WaitDataLayerStreamingRadius, 0f, 7000f);
		dataLayersTransitionTask.MaxTimeForWaitDataLayerActivateFinish = this.MaxTimeForWaitDataLayerActivateFinish;
		dataLayersTransitionTask.ShouldModifyBudgetDuringWaitDataLayerActivateFinish = true;
		dataLayersTransitionTask.TaskFinishCallback = new Action<DataLayersTransitionTask, bool>(this.OnTransitionTaskFinish);
		Log instance6 = Singleton<Log>.Instance;
		ELogModule module6 = ELogModule.TriggerVolume;
		ELogAuthor author6 = ELogAuthor.ZYL;
		string message6 = "[TsTransitionWorldPartitionTriggerVolume] 添加DataLayer过渡切换Task";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("State", base.State);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 2) = new ValueTuple<string, object>("DataLayersToActivate", dataLayersTransitionTask.ToActivateDataLayerNames);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 3) = new ValueTuple<string, object>("DataLayersToDeactivate", dataLayersTransitionTask.ToDeactivateDataLayerNames);
		instance6.Info(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 4));
		this.TransitionTaskQueue.Push(dataLayersTransitionTask);
		this.TryStartNextTask();
	}

	// Token: 0x0601AE55 RID: 110165 RVA: 0x00806604 File Offset: 0x00804804
	private void TryStartNextTask()
	{
		if (this.ExecutingTransitionTasks.Count > 0)
		{
			return;
		}
		DataLayersTransitionTask dataLayersTransitionTask = null;
		while (!this.TransitionTaskQueue.Empty && dataLayersTransitionTask == null)
		{
			dataLayersTransitionTask = this.TransitionTaskQueue.Pop();
		}
		if (dataLayersTransitionTask == null)
		{
			return;
		}
		this.ExecutingTransitionTasks.Add(dataLayersTransitionTask);
		dataLayersTransitionTask.StartTask();
	}

	// Token: 0x0601AE56 RID: 110166 RVA: 0x00806657 File Offset: 0x00804857
	[NullableContext(1)]
	private void OnTransitionTaskFinish(DataLayersTransitionTask task, bool success)
	{
		this.ExecutingTransitionTasks.Remove(task);
		this.TryStartNextTask();
	}

	// Token: 0x0601AE57 RID: 110167 RVA: 0x0080666C File Offset: 0x0080486C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTransitionWorldPartitionTriggerVolume._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsTransitionWorldPartitionTriggerVolume.TsTransitionWorldPartitionTriggerVolume_C");
		}
		return TsTransitionWorldPartitionTriggerVolume._ClassPtr;
	}

	// Token: 0x0601AE58 RID: 110168 RVA: 0x00806690 File Offset: 0x00804890
	public TsTransitionWorldPartitionTriggerVolume() : this(BuiltinUtils.AllocNativeUObject(TsTransitionWorldPartitionTriggerVolume.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601AE59 RID: 110169 RVA: 0x008066B8 File Offset: 0x008048B8
	[NullableContext(1)]
	public TsTransitionWorldPartitionTriggerVolume(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTransitionWorldPartitionTriggerVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601AE5A RID: 110170 RVA: 0x008066EB File Offset: 0x008048EB
	protected TsTransitionWorldPartitionTriggerVolume(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601AE5B RID: 110171 RVA: 0x00806728 File Offset: 0x00804928
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetMatForActivatingDataLayers_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetMatForActivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		this.SetMatForActivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601AE5C RID: 110172 RVA: 0x00806748 File Offset: 0x00804948
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasMatForActivatingDataLayersSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasMatForActivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasMatForActivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601AE5D RID: 110173 RVA: 0x00806758 File Offset: 0x00804958
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetMatForDeactivatingDataLayers_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetMatForDeactivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		this.SetMatForDeactivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601AE5E RID: 110174 RVA: 0x00806778 File Offset: 0x00804978
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasMatForDeactivatingDataLayersSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasMatForDeactivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasMatForDeactivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601AE5F RID: 110175 RVA: 0x00806788 File Offset: 0x00804988
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetSeqForSourceIn_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceIn_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		this.SetSeqForSourceIn_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601AE60 RID: 110176 RVA: 0x008067B6 File Offset: 0x008049B6
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasSeqForSourceInSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceInSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasSeqForSourceInSet_Implementation();
	}

	// Token: 0x0601AE61 RID: 110177 RVA: 0x008067C4 File Offset: 0x008049C4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetSeqForSourceOut_Implementation(TsTransitionWorldPartitionTriggerVolume.__SetSeqForSourceOut_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		this.SetSeqForSourceOut_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601AE62 RID: 110178 RVA: 0x008067F2 File Offset: 0x008049F2
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasSeqForSourceOutSet_Implementation(TsTransitionWorldPartitionTriggerVolume.__WasSeqForSourceOutSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasSeqForSourceOutSet_Implementation();
	}

	// Token: 0x0601AE63 RID: 110179 RVA: 0x00806800 File Offset: 0x00804A00
	protected virtual void __CPPCALL_OnStateChanged_Implementation()
	{
		this.OnStateChanged_Implementation();
	}

	// Token: 0x0400DA48 RID: 55880
	private string MatPathForActivatingDataLayers;

	// Token: 0x0400DA49 RID: 55881
	private int MatForActivatingDataLayersLoadingHandle = -1;

	// Token: 0x0400DA4A RID: 55882
	private string MatPathForDeactivatingDataLayers;

	// Token: 0x0400DA4B RID: 55883
	private int MatForDeactivatingDataLayersLoadingHandle = -1;

	// Token: 0x0400DA4C RID: 55884
	private string SeqPathForSourceIn;

	// Token: 0x0400DA4D RID: 55885
	private int SeqForSourceInLoadingHandle = -1;

	// Token: 0x0400DA4E RID: 55886
	private string SeqPathForSourceOut;

	// Token: 0x0400DA4F RID: 55887
	private int SeqForSourceOutLoadingHandle = -1;

	// Token: 0x0400DA50 RID: 55888
	[Nullable(1)]
	private readonly Queue<DataLayersTransitionTask> TransitionTaskQueue = new Queue<DataLayersTransitionTask>(4);

	// Token: 0x0400DA51 RID: 55889
	[Nullable(1)]
	private readonly HashSet<DataLayersTransitionTask> ExecutingTransitionTasks = new HashSet<DataLayersTransitionTask>();

	// Token: 0x0400DA52 RID: 55890
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsTransitionWorldPartitionTriggerVolume.TsTransitionWorldPartitionTriggerVolume_C";

	// Token: 0x0400DA53 RID: 55891
	private static IntPtr _ClassPtr;

	// Token: 0x0400DA54 RID: 55892
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DA55 RID: 55893
	private static int __PropertyOffset_FunctionEnable;

	// Token: 0x0400DA56 RID: 55894
	private static int __PropertyOffset_UseTransitionWhenTeleport;

	// Token: 0x0400DA57 RID: 55895
	private static int __PropertyOffset_MatForActivatingDataLayers;

	// Token: 0x0400DA58 RID: 55896
	private static int __PropertyOffset_MatForDeactivatingDataLayers;

	// Token: 0x0400DA59 RID: 55897
	private static int __PropertyOffset_SeqForSourceIn;

	// Token: 0x0400DA5A RID: 55898
	private static int __PropertyOffset_SeqMarkBeforeModifyMatForSourceIn;

	// Token: 0x0400DA5B RID: 55899
	private static int __PropertyOffset_SeqForSourceOut;

	// Token: 0x0400DA5C RID: 55900
	private static int __PropertyOffset_SeqMarkBeforeModifyMatForSourceOut;

	// Token: 0x0400DA5D RID: 55901
	private static int __PropertyOffset_WaitDataLayerStreamingRadius;

	// Token: 0x0400DA5E RID: 55902
	private static int __PropertyOffset_MaxTimeForWaitDataLayerActivateFinish;

	// Token: 0x0200943A RID: 37946
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetMatForActivatingDataLayers_FunctionParams
	{
		// Token: 0x0403136D RID: 201581
		[FieldOffset(0)]
		public IntPtr asset;
	}

	// Token: 0x0200943B RID: 37947
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasMatForActivatingDataLayersSet_FunctionParams
	{
		// Token: 0x0403136E RID: 201582
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x0200943C RID: 37948
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetMatForDeactivatingDataLayers_FunctionParams
	{
		// Token: 0x0403136F RID: 201583
		[FieldOffset(0)]
		public IntPtr asset;
	}

	// Token: 0x0200943D RID: 37949
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasMatForDeactivatingDataLayersSet_FunctionParams
	{
		// Token: 0x04031370 RID: 201584
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x0200943E RID: 37950
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSeqForSourceIn_FunctionParams
	{
		// Token: 0x04031371 RID: 201585
		[FieldOffset(0)]
		public IntPtr asset;

		// Token: 0x04031372 RID: 201586
		[FieldOffset(8)]
		public FString beforeModifyMatMark;
	}

	// Token: 0x0200943F RID: 37951
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasSeqForSourceInSet_FunctionParams
	{
		// Token: 0x04031373 RID: 201587
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x02009440 RID: 37952
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSeqForSourceOut_FunctionParams
	{
		// Token: 0x04031374 RID: 201588
		[FieldOffset(0)]
		public IntPtr asset;

		// Token: 0x04031375 RID: 201589
		[FieldOffset(8)]
		public FString beforeModifyMatMark;
	}

	// Token: 0x02009441 RID: 37953
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasSeqForSourceOutSet_FunctionParams
	{
		// Token: 0x04031376 RID: 201590
		[FieldOffset(0)]
		public bool __Result;
	}
}
