using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD4 RID: 3284
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetNowTime.TsTaskSetNowTime_C")]
public class TsTaskSetNowTime : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06004059 RID: 16473 RVA: 0x00065E2D File Offset: 0x0006402D
	// (set) Token: 0x0600405A RID: 16474 RVA: 0x00065E41 File Offset: 0x00064041
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetNowTime.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskSetNowTime.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x0600405B RID: 16475 RVA: 0x00065E56 File Offset: 0x00064056
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
		}
	}

	// Token: 0x0600405C RID: 16476 RVA: 0x00065E7C File Offset: 0x0006407C
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

	// Token: 0x0600405D RID: 16477 RVA: 0x00065F1C File Offset: 0x0006411C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
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
		this.InitTsVariables();
		if (this.TsBlackboardKey != "")
		{
			int id = aiController.CharActorComp.Entity.Id;
			int value = (int)Singleton<Time>.Instance.WorldTime;
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(id, this.TsBlackboardKey, value);
		}
		base.FinishExecute(true);
	}

	// Token: 0x0600405E RID: 16478 RVA: 0x00065FCA File Offset: 0x000641CA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSetNowTime._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetNowTime.TsTaskSetNowTime_C");
		}
		return TsTaskSetNowTime._ClassPtr;
	}

	// Token: 0x0600405F RID: 16479 RVA: 0x00065FF0 File Offset: 0x000641F0
	public TsTaskSetNowTime() : this(BuiltinUtils.AllocNativeUObject(TsTaskSetNowTime.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004060 RID: 16480 RVA: 0x00066018 File Offset: 0x00064218
	public TsTaskSetNowTime(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetNowTime.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004061 RID: 16481 RVA: 0x0006604B File Offset: 0x0006424B
	protected TsTaskSetNowTime(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004062 RID: 16482 RVA: 0x00066060 File Offset: 0x00064260
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000EEC RID: 3820
	private bool IsInitTsVariables;

	// Token: 0x04000EED RID: 3821
	private string TsBlackboardKey = "";

	// Token: 0x04000EEE RID: 3822
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetNowTime.TsTaskSetNowTime_C";

	// Token: 0x04000EEF RID: 3823
	private static IntPtr _ClassPtr;

	// Token: 0x04000EF0 RID: 3824
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000EF1 RID: 3825
	private static int __PropertyOffset_BlackboardKey;
}
