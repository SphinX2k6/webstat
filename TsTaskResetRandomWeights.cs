using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD0 RID: 3280
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskResetRandomWeights.TsTaskResetRandomWeights_C")]
public class TsTaskResetRandomWeights : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06004014 RID: 16404 RVA: 0x00064BDD File Offset: 0x00062DDD
	// (set) Token: 0x06004015 RID: 16405 RVA: 0x00064BF1 File Offset: 0x00062DF1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string NodeKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskResetRandomWeights.__PropertyOffset_NodeKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskResetRandomWeights.__PropertyOffset_NodeKey)), value);
		}
	}

	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06004016 RID: 16406 RVA: 0x00064C06 File Offset: 0x00062E06
	// (set) Token: 0x06004017 RID: 16407 RVA: 0x00064C16 File Offset: 0x00062E16
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ResetAll
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskResetRandomWeights.__PropertyOffset_ResetAll) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskResetRandomWeights.__PropertyOffset_ResetAll) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x06004018 RID: 16408 RVA: 0x00064C28 File Offset: 0x00062E28
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<int> WeightsOverride
	{
		get
		{
			base.FastCheckIsValid();
			TArray<int> result;
			if ((result = this._WeightsOverride) == null)
			{
				result = (this._WeightsOverride = new TArray<int>(base.NativePtr + (IntPtr)TsTaskResetRandomWeights.__PropertyOffset_WeightsOverride, this));
			}
			return result;
		}
	}

	// Token: 0x06004019 RID: 16409 RVA: 0x00064C64 File Offset: 0x00062E64
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

	// Token: 0x0600401A RID: 16410 RVA: 0x00064D00 File Offset: 0x00062F00
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (((tsAiController != null) ? tsAiController.AiController : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LJF;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		TsAiController tsAiController2 = ownerController as TsAiController;
		CharacterAiComponent characterAiComponent = (tsAiController2 != null) ? tsAiController2.GetAiComp() : null;
		if (characterAiComponent == null)
		{
			base.FinishExecute(false);
			return;
		}
		if (this.ResetAll)
		{
			characterAiComponent.ResetRandomNodes(null, this.WeightsOverride);
		}
		else
		{
			characterAiComponent.ResetRandomNodes(this.NodeKey, this.WeightsOverride);
		}
		base.FinishExecute(true);
	}

	// Token: 0x0600401B RID: 16411 RVA: 0x00064DAB File Offset: 0x00062FAB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskResetRandomWeights._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskResetRandomWeights.TsTaskResetRandomWeights_C");
		}
		return TsTaskResetRandomWeights._ClassPtr;
	}

	// Token: 0x0600401C RID: 16412 RVA: 0x00064DD0 File Offset: 0x00062FD0
	public TsTaskResetRandomWeights() : this(BuiltinUtils.AllocNativeUObject(TsTaskResetRandomWeights.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600401D RID: 16413 RVA: 0x00064DF8 File Offset: 0x00062FF8
	public TsTaskResetRandomWeights(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskResetRandomWeights.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600401E RID: 16414 RVA: 0x00064E2B File Offset: 0x0006302B
	protected TsTaskResetRandomWeights(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600401F RID: 16415 RVA: 0x00064E34 File Offset: 0x00063034
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000EAD RID: 3757
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskResetRandomWeights.TsTaskResetRandomWeights_C";

	// Token: 0x04000EAE RID: 3758
	private static IntPtr _ClassPtr;

	// Token: 0x04000EAF RID: 3759
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000EB0 RID: 3760
	private static int __PropertyOffset_NodeKey;

	// Token: 0x04000EB1 RID: 3761
	private static int __PropertyOffset_ResetAll;

	// Token: 0x04000EB2 RID: 3762
	private static int __PropertyOffset_WeightsOverride;

	// Token: 0x04000EB3 RID: 3763
	[Nullable(2)]
	private TArray<int> _WeightsOverride;
}
