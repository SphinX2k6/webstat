using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DFD RID: 3581
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyPlayPlot.TsSeqAnimNotifyPlayPlot_C")]
public class TsSeqAnimNotifyPlayPlot : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170005A7 RID: 1447
	// (get) Token: 0x06005360 RID: 21344 RVA: 0x000C42FF File Offset: 0x000C24FF
	// (set) Token: 0x06005361 RID: 21345 RVA: 0x000C4313 File Offset: 0x000C2513
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string PlotName
	{
		[NullableContext(2)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsSeqAnimNotifyPlayPlot.__PropertyOffset_PlotName)));
		}
		[NullableContext(2)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsSeqAnimNotifyPlayPlot.__PropertyOffset_PlotName)), value);
		}
	}

	// Token: 0x06005362 RID: 21346 RVA: 0x000C4328 File Offset: 0x000C2528
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

	// Token: 0x06005363 RID: 21347 RVA: 0x000C43A3 File Offset: 0x000C25A3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "播客户端剧情";
	}

	// Token: 0x06005364 RID: 21348 RVA: 0x000C43AC File Offset: 0x000C25AC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComponent != null) ? meshComponent.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animSequence != null) ? animSequence.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06005365 RID: 21349 RVA: 0x000C444C File Offset: 0x000C264C
	[NullableContext(2)]
	protected unsafe virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComponent, UAnimSequenceBase animSequence)
	{
		AActor aactor = (meshComponent != null) ? meshComponent.GetOwner() : null;
		if (aactor == null)
		{
			return false;
		}
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(aactor.GetWorld());
		bool flag = worldType == BP_EWorldType.Editor || worldType == BP_EWorldType.EditorPreview;
		if (flag)
		{
			return false;
		}
		if (this.PlotName == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Plot, ELogAuthor.JYS, "TsSeqAnimNotifyPlayPlot 不存在的PlotName播放信息", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		string[] array = this.PlotName.Split(',', StringSplitOptions.None);
		if (array == null || array.Length != 3)
		{
			Singleton<Log>.Instance.Error(ELogModule.Plot, ELogAuthor.JYS, "TsSeqAnimNotifyPlayPlot PlotArray数量不对", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		string text = array[0];
		string text2 = array[1];
		string text3 = array[2];
		if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "TsSeqAnimNotifyPlayPlot 不存在的播放信息";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.PlotName", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.PlotId", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("this.StateId", text3);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		ControllerBase<FlowController>.Instance.StartFlowForView(text, int.Parse(text2), int.Parse(text3), new UiParam
		{
			AudioAttachActor = meshComponent.GetOwner()
		}, false);
		return true;
	}

	// Token: 0x06005366 RID: 21350 RVA: 0x000C45AF File Offset: 0x000C27AF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsSeqAnimNotifyPlayPlot._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyPlayPlot.TsSeqAnimNotifyPlayPlot_C");
		}
		return TsSeqAnimNotifyPlayPlot._ClassPtr;
	}

	// Token: 0x06005367 RID: 21351 RVA: 0x000C45D4 File Offset: 0x000C27D4
	public TsSeqAnimNotifyPlayPlot() : this(BuiltinUtils.AllocNativeUObject(TsSeqAnimNotifyPlayPlot.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005368 RID: 21352 RVA: 0x000C45FC File Offset: 0x000C27FC
	[NullableContext(1)]
	public TsSeqAnimNotifyPlayPlot(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSeqAnimNotifyPlayPlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005369 RID: 21353 RVA: 0x000C462F File Offset: 0x000C282F
	protected TsSeqAnimNotifyPlayPlot(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600536A RID: 21354 RVA: 0x000C4638 File Offset: 0x000C2838
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0600536B RID: 21355 RVA: 0x000C464C File Offset: 0x000C284C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040018BA RID: 6330
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsSeqAnimNotifyPlayPlot.TsSeqAnimNotifyPlayPlot_C";

	// Token: 0x040018BB RID: 6331
	private static IntPtr _ClassPtr;

	// Token: 0x040018BC RID: 6332
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040018BD RID: 6333
	private static int __PropertyOffset_PlotName;
}
