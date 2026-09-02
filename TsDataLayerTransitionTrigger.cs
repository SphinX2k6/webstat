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

// Token: 0x0200325C RID: 12892
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsDataLayerTransitionTrigger.TsDataLayerTransitionTrigger_C")]
public class TsDataLayerTransitionTrigger : AActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002478 RID: 9336
	// (get) Token: 0x0601ADD8 RID: 110040 RVA: 0x008043D5 File Offset: 0x008025D5
	// (set) Token: 0x0601ADD9 RID: 110041 RVA: 0x008043E5 File Offset: 0x008025E5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool FunctionEnable
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_FunctionEnable) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_FunctionEnable) = (value ? 1 : 0);
		}
	}

	// Token: 0x17002479 RID: 9337
	// (get) Token: 0x0601ADDA RID: 110042 RVA: 0x008043F6 File Offset: 0x008025F6
	// (set) Token: 0x0601ADDB RID: 110043 RVA: 0x00804406 File Offset: 0x00802606
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe bool TriggerState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_TriggerState) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_TriggerState) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700247A RID: 9338
	// (get) Token: 0x0601ADDC RID: 110044 RVA: 0x00804417 File Offset: 0x00802617
	// (set) Token: 0x0601ADDD RID: 110045 RVA: 0x00804427 File Offset: 0x00802627
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe bool UseTransitionWhenTeleport
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_UseTransitionWhenTeleport) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_UseTransitionWhenTeleport) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700247B RID: 9339
	// (get) Token: 0x0601ADDE RID: 110046 RVA: 0x00804438 File Offset: 0x00802638
	// (set) Token: 0x0601ADDF RID: 110047 RVA: 0x0080444C File Offset: 0x0080264C
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe AVolume Volume
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<AVolume>(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_Volume);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_Volume, value);
		}
	}

	// Token: 0x1700247C RID: 9340
	// (get) Token: 0x0601ADE0 RID: 110048 RVA: 0x00804464 File Offset: 0x00802664
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	protected TMap<FName, bool> DatalayerStateMap
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TMap<FName, bool> result;
			if ((result = this._DatalayerStateMap) == null)
			{
				result = (this._DatalayerStateMap = new TMap<FName, bool>(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_DatalayerStateMap, this));
			}
			return result;
		}
	}

	// Token: 0x1700247D RID: 9341
	// (get) Token: 0x0601ADE1 RID: 110049 RVA: 0x0080449D File Offset: 0x0080269D
	// (set) Token: 0x0601ADE2 RID: 110050 RVA: 0x008044B1 File Offset: 0x008026B1
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe UKuroSceneMatModifyDataAsset MatForActivatingDataLayers
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroSceneMatModifyDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_MatForActivatingDataLayers);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_MatForActivatingDataLayers, value);
		}
	}

	// Token: 0x1700247E RID: 9342
	// (get) Token: 0x0601ADE3 RID: 110051 RVA: 0x008044C6 File Offset: 0x008026C6
	// (set) Token: 0x0601ADE4 RID: 110052 RVA: 0x008044DA File Offset: 0x008026DA
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe UKuroSceneMatModifyDataAsset MatForDeactivatingDataLayers
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroSceneMatModifyDataAsset>(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_MatForDeactivatingDataLayers);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_MatForDeactivatingDataLayers, value);
		}
	}

	// Token: 0x1700247F RID: 9343
	// (get) Token: 0x0601ADE5 RID: 110053 RVA: 0x008044EF File Offset: 0x008026EF
	// (set) Token: 0x0601ADE6 RID: 110054 RVA: 0x00804503 File Offset: 0x00802703
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe ULevelSequence SeqForSourceIn
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_SeqForSourceIn);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_SeqForSourceIn, value);
		}
	}

	// Token: 0x17002480 RID: 9344
	// (get) Token: 0x0601ADE7 RID: 110055 RVA: 0x00804518 File Offset: 0x00802718
	// (set) Token: 0x0601ADE8 RID: 110056 RVA: 0x0080452C File Offset: 0x0080272C
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe string SeqMarkBeforeModifyMatForSourceIn
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_SeqMarkBeforeModifyMatForSourceIn)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_SeqMarkBeforeModifyMatForSourceIn)), value);
		}
	}

	// Token: 0x17002481 RID: 9345
	// (get) Token: 0x0601ADE9 RID: 110057 RVA: 0x00804541 File Offset: 0x00802741
	// (set) Token: 0x0601ADEA RID: 110058 RVA: 0x00804555 File Offset: 0x00802755
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe ULevelSequence SeqForSourceOut
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ULevelSequence>(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_SeqForSourceOut);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_SeqForSourceOut, value);
		}
	}

	// Token: 0x17002482 RID: 9346
	// (get) Token: 0x0601ADEB RID: 110059 RVA: 0x0080456A File Offset: 0x0080276A
	// (set) Token: 0x0601ADEC RID: 110060 RVA: 0x0080457E File Offset: 0x0080277E
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	protected unsafe string SeqMarkBeforeModifyMatForSourceOut
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_SeqMarkBeforeModifyMatForSourceOut)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_SeqMarkBeforeModifyMatForSourceOut)), value);
		}
	}

	// Token: 0x0601ADED RID: 110061 RVA: 0x00804594 File Offset: 0x00802794
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMatForActivatingDataLayers(UKuroSceneMatModifyDataAsset asset)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601ADEE RID: 110062 RVA: 0x00804618 File Offset: 0x00802818
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

	// Token: 0x0601ADEF RID: 110063 RVA: 0x00804648 File Offset: 0x00802848
	public void SetMatForActivatingDataLayersByPath(string path)
	{
		this.MatForActivatingDataLayers = null;
		this.MatPathForActivatingDataLayers = path;
		if (this.MatForActivatingDataLayersLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MatForActivatingDataLayersLoadingHandle);
			this.MatForActivatingDataLayersLoadingHandle = -1;
		}
		if (path != null)
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

	// Token: 0x0601ADF0 RID: 110064 RVA: 0x008046C8 File Offset: 0x008028C8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasMatForActivatingDataLayersSet()
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601ADF1 RID: 110065 RVA: 0x0080473D File Offset: 0x0080293D
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

	// Token: 0x0601ADF2 RID: 110066 RVA: 0x00804770 File Offset: 0x00802970
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetMatForDeactivatingDataLayers(UKuroSceneMatModifyDataAsset asset)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601ADF3 RID: 110067 RVA: 0x008047F4 File Offset: 0x008029F4
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

	// Token: 0x0601ADF4 RID: 110068 RVA: 0x00804824 File Offset: 0x00802A24
	public void SetMatForDeactivatingDataLayersByPath(string path)
	{
		this.MatForDeactivatingDataLayers = null;
		this.MatPathForDeactivatingDataLayers = path;
		if (this.MatForDeactivatingDataLayersLoadingHandle != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.MatForDeactivatingDataLayersLoadingHandle);
			this.MatForDeactivatingDataLayersLoadingHandle = -1;
		}
		if (path != null)
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

	// Token: 0x0601ADF5 RID: 110069 RVA: 0x008048A4 File Offset: 0x00802AA4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasMatForDeactivatingDataLayersSet()
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601ADF6 RID: 110070 RVA: 0x00804919 File Offset: 0x00802B19
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

	// Token: 0x0601ADF7 RID: 110071 RVA: 0x0080494C File Offset: 0x00802B4C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetSeqForSourceIn([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601ADF8 RID: 110072 RVA: 0x008049DD File Offset: 0x00802BDD
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

	// Token: 0x0601ADF9 RID: 110073 RVA: 0x00804A14 File Offset: 0x00802C14
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
		if (path != null)
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

	// Token: 0x0601ADFA RID: 110074 RVA: 0x00804AA8 File Offset: 0x00802CA8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasSeqForSourceInSet()
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601ADFB RID: 110075 RVA: 0x00804B1D File Offset: 0x00802D1D
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

	// Token: 0x0601ADFC RID: 110076 RVA: 0x00804B50 File Offset: 0x00802D50
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetSeqForSourceOut([Nullable(2)] ULevelSequence asset, string beforeModifyMatMark)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601ADFD RID: 110077 RVA: 0x00804BE1 File Offset: 0x00802DE1
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

	// Token: 0x0601ADFE RID: 110078 RVA: 0x00804C18 File Offset: 0x00802E18
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
		if (path != null)
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

	// Token: 0x0601ADFF RID: 110079 RVA: 0x00804CAC File Offset: 0x00802EAC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool WasSeqForSourceOutSet()
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601AE00 RID: 110080 RVA: 0x00804D21 File Offset: 0x00802F21
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

	// Token: 0x0601AE01 RID: 110081 RVA: 0x00804D54 File Offset: 0x00802F54
	public override void ReceiveBeginPlay()
	{
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(this);
		if (worldType != BP_EWorldType.Game && worldType != BP_EWorldType.PIE)
		{
			return;
		}
		this.InitVolume();
	}

	// Token: 0x0601AE02 RID: 110082 RVA: 0x00804D78 File Offset: 0x00802F78
	private void InitVolume()
	{
		if (this.Volume == null)
		{
			return;
		}
		AVolume volume = this.Volume;
		if (volume != null)
		{
			volume.OnActorBeginOverlap.Add(new Action<AActor, AActor>(this.OnVolumeActorBeginOverlapHandle));
		}
		AVolume volume2 = this.Volume;
		if (volume2 != null)
		{
			volume2.OnActorEndOverlap.Add(new Action<AActor, AActor>(this.OnVolumeActorEndOverlapHandle));
		}
		AVolume volume3 = this.Volume;
		if (volume3 != null)
		{
			volume3.OnEndPlay.Add(new Action<AActor, TEnumAsByte<EEndPlayReason>>(this.OnVolumeEndPlayHandle));
		}
		AVolume volume4 = this.Volume;
		if (volume4 != null && volume4.IsOverlappingActor(ControllerBase<RoleTriggerController>.Instance.GetMyRoleTriggerOrUndefined()))
		{
			this.TriggerState = true;
			this.OnTriggerStateChanged();
		}
	}

	// Token: 0x0601AE03 RID: 110083 RVA: 0x00804E20 File Offset: 0x00803020
	[NullableContext(0)]
	private void OnVolumeEndPlayHandle([Nullable(2)] AActor actor, TEnumAsByte<EEndPlayReason> endPlayReason)
	{
		AVolume volume = this.Volume;
		if (volume != null)
		{
			volume.OnActorBeginOverlap.Remove(new Action<AActor, AActor>(this.OnVolumeActorBeginOverlapHandle));
		}
		AVolume volume2 = this.Volume;
		if (volume2 == null)
		{
			return;
		}
		volume2.OnActorEndOverlap.Remove(new Action<AActor, AActor>(this.OnVolumeActorEndOverlapHandle));
	}

	// Token: 0x0601AE04 RID: 110084 RVA: 0x00804E70 File Offset: 0x00803070
	private void OnVolumeActorBeginOverlapHandle(AActor overlappedActor, AActor otherActor)
	{
		if (otherActor != ControllerBase<RoleTriggerController>.Instance.GetMyRoleTriggerOrUndefined())
		{
			return;
		}
		this.TriggerState = true;
		this.OnTriggerStateChanged();
	}

	// Token: 0x0601AE05 RID: 110085 RVA: 0x00804E8D File Offset: 0x0080308D
	private void OnVolumeActorEndOverlapHandle(AActor overlappedActor, AActor otherActor)
	{
		if (otherActor != ControllerBase<RoleTriggerController>.Instance.GetMyRoleTriggerOrUndefined())
		{
			return;
		}
		this.TriggerState = false;
		this.OnTriggerStateChanged();
	}

	// Token: 0x0601AE06 RID: 110086 RVA: 0x00804EAC File Offset: 0x008030AC
	public unsafe void OnTriggerStateChanged()
	{
		if (!this.FunctionEnable)
		{
			return;
		}
		HashSet<FName> hashSet = new HashSet<FName>();
		HashSet<FName> hashSet2 = new HashSet<FName>();
		foreach (KeyValuePair<FName, bool> keyValuePair in this.DatalayerStateMap)
		{
			FName fname;
			bool flag;
			keyValuePair.Deconstruct(out fname, out flag);
			FName item = fname;
			bool flag2 = flag;
			if (this.TriggerState ? flag2 : (!flag2))
			{
				hashSet.Add(item);
			}
			else
			{
				hashSet2.Add(item);
			}
		}
		if (hashSet.Count > 0 && hashSet2.Count > 0 && this.WasMatForActivatingDataLayersSet() && this.WasMatForDeactivatingDataLayersSet() && (this.TriggerState ? this.WasSeqForSourceInSet() : this.WasSeqForSourceOutSet()))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TriggerVolume;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[TsDataLayerTransitionTrigger] 暂时不支持同时控制DataLayer显示的过渡和DataLayer隐藏的过渡, 可能存在表现问题, 请检查配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this.Volume));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TriggerState", this.TriggerState);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (((hashSet.Count > 0 && this.WasMatForActivatingDataLayersSet()) || (hashSet2.Count > 0 && this.WasMatForDeactivatingDataLayersSet())) && !(this.TriggerState ? this.WasSeqForSourceInSet() : this.WasSeqForSourceOutSet()))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TriggerVolume;
			ELogAuthor author2 = ELogAuthor.ZYL;
			string message2 = "[TsDataLayerTransitionTrigger] 设置了过渡DA和DataLayer, 但是没有设置过渡Seq, 可能存在表现问题, 请检查配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this.Volume));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("TriggerState", this.TriggerState);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
		DataLayersTransitionTask dataLayersTransitionTask = new DataLayersTransitionTask();
		dataLayersTransitionTask.ToActivateDataLayerNames = hashSet;
		dataLayersTransitionTask.ToDeactivateDataLayerNames = hashSet2;
		if (this.UseTransitionWhenTeleport || (!ModelBase<TeleportModel>.Instance.IsTeleport && !ModelBase<GameModeModel>.Instance.Loading))
		{
			dataLayersTransitionTask.MatDataForActivating = this.MatForActivatingDataLayers;
			dataLayersTransitionTask.MatPathForActivating = this.MatPathForActivatingDataLayers;
			dataLayersTransitionTask.MatDataForActivatingLoaded = (this.MatForActivatingDataLayersLoadingHandle == -1);
			dataLayersTransitionTask.MatDataForDeactivating = this.MatForDeactivatingDataLayers;
			dataLayersTransitionTask.MatPathForDeactivating = this.MatPathForDeactivatingDataLayers;
			dataLayersTransitionTask.MatDataForDeactivatingLoaded = (this.MatForDeactivatingDataLayersLoadingHandle == -1);
			if (this.TriggerState)
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
		dataLayersTransitionTask.ShouldWaitDataLayersActivateFinish = true;
		dataLayersTransitionTask.TaskFinishCallback = new Action<DataLayersTransitionTask, bool>(this.OnTransitionTaskFinish);
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.TriggerVolume;
		ELogAuthor author3 = ELogAuthor.ZYL;
		string message3 = "[TsDataLayerTransitionTrigger] 添加DataLayer过渡切换Task";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Volume", UKismetSystemLibrary.GetPathName(this.Volume));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("TriggerState", this.TriggerState);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("DataLayersToActivate", dataLayersTransitionTask.ToActivateDataLayerNames);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("DataLayersToDeactivate", dataLayersTransitionTask.ToDeactivateDataLayerNames);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
		this.TransitionTaskQueue.Push(dataLayersTransitionTask);
		this.TryStartNextTask();
	}

	// Token: 0x0601AE07 RID: 110087 RVA: 0x0080525C File Offset: 0x0080345C
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

	// Token: 0x0601AE08 RID: 110088 RVA: 0x008052AF File Offset: 0x008034AF
	[NullableContext(1)]
	private void OnTransitionTaskFinish(DataLayersTransitionTask task, bool success)
	{
		this.ExecutingTransitionTasks.Remove(task);
		this.TryStartNextTask();
	}

	// Token: 0x0601AE09 RID: 110089 RVA: 0x008052C4 File Offset: 0x008034C4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDataLayerTransitionTrigger._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsDataLayerTransitionTrigger.TsDataLayerTransitionTrigger_C");
		}
		return TsDataLayerTransitionTrigger._ClassPtr;
	}

	// Token: 0x0601AE0A RID: 110090 RVA: 0x008052E8 File Offset: 0x008034E8
	public TsDataLayerTransitionTrigger() : this(BuiltinUtils.AllocNativeUObject(TsDataLayerTransitionTrigger.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601AE0B RID: 110091 RVA: 0x00805310 File Offset: 0x00803510
	[NullableContext(1)]
	public TsDataLayerTransitionTrigger(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDataLayerTransitionTrigger.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601AE0C RID: 110092 RVA: 0x00805343 File Offset: 0x00803543
	protected TsDataLayerTransitionTrigger(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x17002483 RID: 9347
	// (get) Token: 0x0601AE0D RID: 110093 RVA: 0x0080537F File Offset: 0x0080357F
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)TsDataLayerTransitionTrigger.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x17002484 RID: 9348
	// (get) Token: 0x0601AE0E RID: 110094 RVA: 0x0080538F File Offset: 0x0080358F
	public unsafe USceneComponent DefaultSceneRoot
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsDataLayerTransitionTrigger.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x0601AE0F RID: 110095 RVA: 0x008053A4 File Offset: 0x008035A4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetMatForActivatingDataLayers_Implementation(TsDataLayerTransitionTrigger.__SetMatForActivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		this.SetMatForActivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601AE10 RID: 110096 RVA: 0x008053C4 File Offset: 0x008035C4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasMatForActivatingDataLayersSet_Implementation(TsDataLayerTransitionTrigger.__WasMatForActivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasMatForActivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601AE11 RID: 110097 RVA: 0x008053D4 File Offset: 0x008035D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetMatForDeactivatingDataLayers_Implementation(TsDataLayerTransitionTrigger.__SetMatForDeactivatingDataLayers_FunctionParams* __Params)
	{
		UKuroSceneMatModifyDataAsset orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UKuroSceneMatModifyDataAsset>(__Params->asset);
		this.SetMatForDeactivatingDataLayers_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601AE12 RID: 110098 RVA: 0x008053F4 File Offset: 0x008035F4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasMatForDeactivatingDataLayersSet_Implementation(TsDataLayerTransitionTrigger.__WasMatForDeactivatingDataLayersSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasMatForDeactivatingDataLayersSet_Implementation();
	}

	// Token: 0x0601AE13 RID: 110099 RVA: 0x00805404 File Offset: 0x00803604
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetSeqForSourceIn_Implementation(TsDataLayerTransitionTrigger.__SetSeqForSourceIn_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		this.SetSeqForSourceIn_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601AE14 RID: 110100 RVA: 0x00805432 File Offset: 0x00803632
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasSeqForSourceInSet_Implementation(TsDataLayerTransitionTrigger.__WasSeqForSourceInSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasSeqForSourceInSet_Implementation();
	}

	// Token: 0x0601AE15 RID: 110101 RVA: 0x00805440 File Offset: 0x00803640
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_SetSeqForSourceOut_Implementation(TsDataLayerTransitionTrigger.__SetSeqForSourceOut_FunctionParams* __Params)
	{
		ULevelSequence orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULevelSequence>(__Params->asset);
		string beforeModifyMatMark = FString.ToString((void*)(&__Params->beforeModifyMatMark));
		this.SetSeqForSourceOut_Implementation(orCreateUObjectByNativePointer, beforeModifyMatMark);
	}

	// Token: 0x0601AE16 RID: 110102 RVA: 0x0080546E File Offset: 0x0080366E
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_WasSeqForSourceOutSet_Implementation(TsDataLayerTransitionTrigger.__WasSeqForSourceOutSet_FunctionParams* __Params)
	{
		__Params->__Result = this.WasSeqForSourceOutSet_Implementation();
	}

	// Token: 0x0400DA23 RID: 55843
	private string MatPathForActivatingDataLayers;

	// Token: 0x0400DA24 RID: 55844
	private int MatForActivatingDataLayersLoadingHandle = -1;

	// Token: 0x0400DA25 RID: 55845
	private string MatPathForDeactivatingDataLayers;

	// Token: 0x0400DA26 RID: 55846
	private int MatForDeactivatingDataLayersLoadingHandle = -1;

	// Token: 0x0400DA27 RID: 55847
	private string SeqPathForSourceIn;

	// Token: 0x0400DA28 RID: 55848
	private int SeqForSourceInLoadingHandle = -1;

	// Token: 0x0400DA29 RID: 55849
	private string SeqPathForSourceOut;

	// Token: 0x0400DA2A RID: 55850
	private int SeqForSourceOutLoadingHandle = -1;

	// Token: 0x0400DA2B RID: 55851
	[Nullable(1)]
	private readonly Queue<DataLayersTransitionTask> TransitionTaskQueue = new Queue<DataLayersTransitionTask>(4);

	// Token: 0x0400DA2C RID: 55852
	[Nullable(1)]
	private readonly HashSet<DataLayersTransitionTask> ExecutingTransitionTasks = new HashSet<DataLayersTransitionTask>();

	// Token: 0x0400DA2D RID: 55853
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/TriggerItems/TsDataLayerTransitionTrigger.TsDataLayerTransitionTrigger_C";

	// Token: 0x0400DA2E RID: 55854
	private static IntPtr _ClassPtr;

	// Token: 0x0400DA2F RID: 55855
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400DA30 RID: 55856
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x0400DA31 RID: 55857
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x0400DA32 RID: 55858
	private static int __PropertyOffset_FunctionEnable;

	// Token: 0x0400DA33 RID: 55859
	private static int __PropertyOffset_TriggerState;

	// Token: 0x0400DA34 RID: 55860
	private static int __PropertyOffset_UseTransitionWhenTeleport;

	// Token: 0x0400DA35 RID: 55861
	private static int __PropertyOffset_Volume;

	// Token: 0x0400DA36 RID: 55862
	private static int __PropertyOffset_DatalayerStateMap;

	// Token: 0x0400DA37 RID: 55863
	private TMap<FName, bool> _DatalayerStateMap;

	// Token: 0x0400DA38 RID: 55864
	private static int __PropertyOffset_MatForActivatingDataLayers;

	// Token: 0x0400DA39 RID: 55865
	private static int __PropertyOffset_MatForDeactivatingDataLayers;

	// Token: 0x0400DA3A RID: 55866
	private static int __PropertyOffset_SeqForSourceIn;

	// Token: 0x0400DA3B RID: 55867
	private static int __PropertyOffset_SeqMarkBeforeModifyMatForSourceIn;

	// Token: 0x0400DA3C RID: 55868
	private static int __PropertyOffset_SeqForSourceOut;

	// Token: 0x0400DA3D RID: 55869
	private static int __PropertyOffset_SeqMarkBeforeModifyMatForSourceOut;

	// Token: 0x0200942E RID: 37934
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetMatForActivatingDataLayers_FunctionParams
	{
		// Token: 0x04031359 RID: 201561
		[FieldOffset(0)]
		public IntPtr asset;
	}

	// Token: 0x0200942F RID: 37935
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasMatForActivatingDataLayersSet_FunctionParams
	{
		// Token: 0x0403135A RID: 201562
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x02009430 RID: 37936
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __SetMatForDeactivatingDataLayers_FunctionParams
	{
		// Token: 0x0403135B RID: 201563
		[FieldOffset(0)]
		public IntPtr asset;
	}

	// Token: 0x02009431 RID: 37937
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasMatForDeactivatingDataLayersSet_FunctionParams
	{
		// Token: 0x0403135C RID: 201564
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x02009432 RID: 37938
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSeqForSourceIn_FunctionParams
	{
		// Token: 0x0403135D RID: 201565
		[FieldOffset(0)]
		public IntPtr asset;

		// Token: 0x0403135E RID: 201566
		[FieldOffset(8)]
		public FString beforeModifyMatMark;
	}

	// Token: 0x02009433 RID: 37939
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasSeqForSourceInSet_FunctionParams
	{
		// Token: 0x0403135F RID: 201567
		[FieldOffset(0)]
		public bool __Result;
	}

	// Token: 0x02009434 RID: 37940
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetSeqForSourceOut_FunctionParams
	{
		// Token: 0x04031360 RID: 201568
		[FieldOffset(0)]
		public IntPtr asset;

		// Token: 0x04031361 RID: 201569
		[FieldOffset(8)]
		public FString beforeModifyMatMark;
	}

	// Token: 0x02009435 RID: 37941
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __WasSeqForSourceOutSet_FunctionParams
	{
		// Token: 0x04031362 RID: 201570
		[FieldOffset(0)]
		public bool __Result;
	}
}
