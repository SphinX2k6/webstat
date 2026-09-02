using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC9 RID: 3273
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayPlot.TsTaskPlayPlot_C")]
public class TsTaskPlayPlot : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700029E RID: 670
	// (get) Token: 0x06003F94 RID: 16276 RVA: 0x00062D45 File Offset: 0x00060F45
	// (set) Token: 0x06003F95 RID: 16277 RVA: 0x00062D59 File Offset: 0x00060F59
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string SeqNetworkId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayPlot.__PropertyOffset_SeqNetworkId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayPlot.__PropertyOffset_SeqNetworkId)), value);
		}
	}

	// Token: 0x1700029F RID: 671
	// (get) Token: 0x06003F96 RID: 16278 RVA: 0x00062D6E File Offset: 0x00060F6E
	// (set) Token: 0x06003F97 RID: 16279 RVA: 0x00062D82 File Offset: 0x00060F82
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string SeqNetworkRes
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayPlot.__PropertyOffset_SeqNetworkRes)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayPlot.__PropertyOffset_SeqNetworkRes)), value);
		}
	}

	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x06003F98 RID: 16280 RVA: 0x00062D97 File Offset: 0x00060F97
	// (set) Token: 0x06003F99 RID: 16281 RVA: 0x00062DAB File Offset: 0x00060FAB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string PlotConfigRes
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayPlot.__PropertyOffset_PlotConfigRes)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayPlot.__PropertyOffset_PlotConfigRes)), value);
		}
	}

	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x06003F9A RID: 16282 RVA: 0x00062DC0 File Offset: 0x00060FC0
	// (set) Token: 0x06003F9B RID: 16283 RVA: 0x00062DD0 File Offset: 0x00060FD0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float WaitTickCount
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayPlot.__PropertyOffset_WaitTickCount);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayPlot.__PropertyOffset_WaitTickCount) = value;
		}
	}

	// Token: 0x06003F9C RID: 16284 RVA: 0x00062DE4 File Offset: 0x00060FE4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsSeqNetworkId = this.SeqNetworkId;
			this.TsSeqNetworkRes = this.SeqNetworkRes;
			this.TsPlotConfigRes = this.PlotConfigRes;
			this.TsWaitTickCount = (int)this.WaitTickCount;
		}
	}

	// Token: 0x06003F9D RID: 16285 RVA: 0x00062E38 File Offset: 0x00061038
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003F9E RID: 16286 RVA: 0x00062ED4 File Offset: 0x000610D4
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		if (((tsAiController != null) ? tsAiController.AiController : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		this.IsPlotStart = false;
		this.TickRemain = ((this.TsWaitTickCount != 0) ? this.TsWaitTickCount : 5);
		if (!string.IsNullOrEmpty(this.TsPlotConfigRes))
		{
			ControllerBase<FlowController>.Instance.StartFlowByRes(this.TsPlotConfigRes);
			return;
		}
		if (string.IsNullOrEmpty(this.TsSeqNetworkId) || string.IsNullOrEmpty(this.TsSeqNetworkRes))
		{
			this.IsPlotStart = true;
			base.FinishExecute(true);
		}
	}

	// Token: 0x06003F9F RID: 16287 RVA: 0x00062F9C File Offset: 0x0006119C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003FA0 RID: 16288 RVA: 0x0006303C File Offset: 0x0006123C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!this.IsPlotStart)
		{
			this.TickRemain--;
			if (!string.IsNullOrEmpty(this.TsPlotConfigRes) && ModelBase<PlotModel>.Instance.IsInPlot)
			{
				this.IsPlotStart = true;
			}
			if (!this.IsPlotStart && this.TickRemain < 1)
			{
				base.FinishExecute(true);
				return;
			}
		}
		else if (!string.IsNullOrEmpty(this.TsPlotConfigRes) && !ModelBase<PlotModel>.Instance.IsInPlot)
		{
			base.FinishExecute(true);
		}
	}

	// Token: 0x06003FA1 RID: 16289 RVA: 0x000630B8 File Offset: 0x000612B8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPlayPlot._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayPlot.TsTaskPlayPlot_C");
		}
		return TsTaskPlayPlot._ClassPtr;
	}

	// Token: 0x06003FA2 RID: 16290 RVA: 0x000630DC File Offset: 0x000612DC
	public TsTaskPlayPlot() : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayPlot.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003FA3 RID: 16291 RVA: 0x00063104 File Offset: 0x00061304
	public TsTaskPlayPlot(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayPlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003FA4 RID: 16292 RVA: 0x00063137 File Offset: 0x00061337
	protected TsTaskPlayPlot(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003FA5 RID: 16293 RVA: 0x00063164 File Offset: 0x00061364
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003FA6 RID: 16294 RVA: 0x00063194 File Offset: 0x00061394
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000E45 RID: 3653
	private const int DEFAULT_WAIT_TICK = 5;

	// Token: 0x04000E46 RID: 3654
	private bool IsInitTsVariables;

	// Token: 0x04000E47 RID: 3655
	private string TsSeqNetworkId = "";

	// Token: 0x04000E48 RID: 3656
	private string TsSeqNetworkRes = "";

	// Token: 0x04000E49 RID: 3657
	private string TsPlotConfigRes = "";

	// Token: 0x04000E4A RID: 3658
	private int TsWaitTickCount;

	// Token: 0x04000E4B RID: 3659
	private bool IsPlotStart;

	// Token: 0x04000E4C RID: 3660
	private int TickRemain;

	// Token: 0x04000E4D RID: 3661
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayPlot.TsTaskPlayPlot_C";

	// Token: 0x04000E4E RID: 3662
	private static IntPtr _ClassPtr;

	// Token: 0x04000E4F RID: 3663
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E50 RID: 3664
	private static int __PropertyOffset_SeqNetworkId;

	// Token: 0x04000E51 RID: 3665
	private static int __PropertyOffset_SeqNetworkRes;

	// Token: 0x04000E52 RID: 3666
	private static int __PropertyOffset_PlotConfigRes;

	// Token: 0x04000E53 RID: 3667
	private static int __PropertyOffset_WaitTickCount;
}
