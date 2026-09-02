using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;
using UnrealEngine.Extension;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D67 RID: 3431
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePreloadPlot.TsAnimNotifyStatePreloadPlot_C")]
public class TsAnimNotifyStatePreloadPlot : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x060049F7 RID: 18935 RVA: 0x000A079B File Offset: 0x0009E99B
	// (set) Token: 0x060049F8 RID: 18936 RVA: 0x000A07AF File Offset: 0x0009E9AF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string PlotName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_PlotName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_PlotName)), value);
		}
	}

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x060049F9 RID: 18937 RVA: 0x000A07C4 File Offset: 0x0009E9C4
	// (set) Token: 0x060049FA RID: 18938 RVA: 0x000A07D4 File Offset: 0x0009E9D4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 跳过UI等待
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_跳过UI等待) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_跳过UI等待) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x060049FB RID: 18939 RVA: 0x000A07E5 File Offset: 0x0009E9E5
	// (set) Token: 0x060049FC RID: 18940 RVA: 0x000A07F5 File Offset: 0x0009E9F5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 锁定镜头状态
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_锁定镜头状态) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_锁定镜头状态) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x060049FD RID: 18941 RVA: 0x000A0806 File Offset: 0x0009EA06
	// (set) Token: 0x060049FE RID: 18942 RVA: 0x000A0816 File Offset: 0x0009EA16
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 提前隐藏战斗界面
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_提前隐藏战斗界面) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStatePreloadPlot.__PropertyOffset_提前隐藏战斗界面) = (value ? 1 : 0);
		}
	}

	// Token: 0x060049FF RID: 18943 RVA: 0x000A0828 File Offset: 0x0009EA28
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

	// Token: 0x06004A00 RID: 18944 RVA: 0x000A08D0 File Offset: 0x0009EAD0
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (aactor == null)
		{
			return false;
		}
		BP_EWorldType worldType = UKuroRenderingRuntimeBPPluginBPLibrary.GetWorldType(aactor.GetWorld());
		if (worldType == BP_EWorldType.Editor || worldType == BP_EWorldType.EditorPreview)
		{
			return false;
		}
		if (this.PlotName == null || this.PlotName.Length == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Plot, ELogAuthor.HYF, "TsAnimNotifyStatePreloadPlot 剧情引用未填写", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		string[] array = this.PlotName.Split(',', StringSplitOptions.None);
		if (array.Length != 3)
		{
			Singleton<Log>.Instance.Error(ELogModule.Plot, ELogAuthor.HYF, "TsAnimNotifyStatePreloadPlot PlotArray数量不对", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		string text = array[0];
		string text2 = array[1];
		string text3 = array[2];
		int num;
		bool flag = int.TryParse(text2, out num);
		int num2;
		bool flag2 = int.TryParse(text3, out num2);
		if (text.Length == 0 || text2.Length == 0 || text3.Length == 0 || !flag || !flag2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "TsAnimNotifyStatePreloadPlot 不存在的播放信息";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlotName", this.PlotName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PlotId", text2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("StateId", text3);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		this.PlotListName = text;
		this.PlotId = num;
		this.StateId = num2;
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Plot;
		ELogAuthor author2 = ELogAuthor.HYF;
		string message2 = "蒙太奇触发预加载剧情";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlotName", this.PlotName);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.Preload(text, num, num2);
		ModelBase<PlotModel>.Instance.AnsPreloadMark = true;
		if (this.提前隐藏战斗界面)
		{
			EUiViewName mainViewName = Singleton<UiModel>.Instance.MainViewName;
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(mainViewName);
			if (viewByName != null)
			{
				viewByName.HideAsync();
			}
		}
		ControllerBase<PlotController>.Instance.RegisterOnMontageEnd(this.PlotListName, this.PlotId, this.StateId, (meshComp != null) ? meshComp.GetAnimInstance() : null);
		return true;
	}

	// Token: 0x06004A01 RID: 18945 RVA: 0x000A0ADC File Offset: 0x0009ECDC
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

	// Token: 0x06004A02 RID: 18946 RVA: 0x000A0B57 File Offset: 0x0009ED57
	protected override string GetNotifyName_Implementation()
	{
		return "无缝进演出预准备";
	}

	// Token: 0x06004A03 RID: 18947 RVA: 0x000A0B60 File Offset: 0x0009ED60
	private void Preload(string plotListName, int intPlotId, int intStateId)
	{
		PreloadControllerNew instance = ControllerBase<PreloadControllerNew>.Instance;
		if (instance != null)
		{
			instance.PreloadPlot(plotListName, intPlotId, intStateId, 999);
		}
		PreloadControllerNew instance2 = ControllerBase<PreloadControllerNew>.Instance;
		if (instance2 != null)
		{
			instance2.PreloadPlotUi(plotListName, intPlotId, intStateId);
		}
		if (ModelBase<PlotModel>.Instance != null)
		{
			ModelBase<PlotModel>.Instance.SeamlessLockState = this.锁定镜头状态;
		}
	}

	// Token: 0x06004A04 RID: 18948 RVA: 0x000A0BB1 File Offset: 0x0009EDB1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStatePreloadPlot._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePreloadPlot.TsAnimNotifyStatePreloadPlot_C");
		}
		return TsAnimNotifyStatePreloadPlot._ClassPtr;
	}

	// Token: 0x06004A05 RID: 18949 RVA: 0x000A0BD8 File Offset: 0x0009EDD8
	public TsAnimNotifyStatePreloadPlot() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePreloadPlot.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004A06 RID: 18950 RVA: 0x000A0C00 File Offset: 0x0009EE00
	public TsAnimNotifyStatePreloadPlot(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStatePreloadPlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004A07 RID: 18951 RVA: 0x000A0C33 File Offset: 0x0009EE33
	protected TsAnimNotifyStatePreloadPlot(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004A08 RID: 18952 RVA: 0x000A0C3C File Offset: 0x0009EE3C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004A09 RID: 18953 RVA: 0x000A0C75 File Offset: 0x0009EE75
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040014E7 RID: 5351
	[Nullable(2)]
	private string PlotListName;

	// Token: 0x040014E8 RID: 5352
	private int PlotId;

	// Token: 0x040014E9 RID: 5353
	private int StateId;

	// Token: 0x040014EA RID: 5354
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStatePreloadPlot.TsAnimNotifyStatePreloadPlot_C";

	// Token: 0x040014EB RID: 5355
	private static IntPtr _ClassPtr;

	// Token: 0x040014EC RID: 5356
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040014ED RID: 5357
	private static int __PropertyOffset_PlotName;

	// Token: 0x040014EE RID: 5358
	private static int __PropertyOffset_跳过UI等待;

	// Token: 0x040014EF RID: 5359
	private static int __PropertyOffset_锁定镜头状态;

	// Token: 0x040014F0 RID: 5360
	private static int __PropertyOffset_提前隐藏战斗界面;
}
