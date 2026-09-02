using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD3 RID: 3283
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetCoolDown.TsTaskSetCoolDown_C")]
public class TsTaskSetCoolDown : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002CE RID: 718
	// (get) Token: 0x0600404D RID: 16461 RVA: 0x00065BA1 File Offset: 0x00063DA1
	// (set) Token: 0x0600404E RID: 16462 RVA: 0x00065BB1 File Offset: 0x00063DB1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Id
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSetCoolDown.__PropertyOffset_Id);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSetCoolDown.__PropertyOffset_Id) = value;
		}
	}

	// Token: 0x170002CF RID: 719
	// (get) Token: 0x0600404F RID: 16463 RVA: 0x00065BC2 File Offset: 0x00063DC2
	// (set) Token: 0x06004050 RID: 16464 RVA: 0x00065BD2 File Offset: 0x00063DD2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CoolDownTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSetCoolDown.__PropertyOffset_CoolDownTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSetCoolDown.__PropertyOffset_CoolDownTime) = value;
		}
	}

	// Token: 0x06004051 RID: 16465 RVA: 0x00065BE3 File Offset: 0x00063DE3
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsId = this.Id;
			this.TsCoolDownTime = this.CoolDownTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
	}

	// Token: 0x06004052 RID: 16466 RVA: 0x00065C20 File Offset: 0x00063E20
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

	// Token: 0x06004053 RID: 16467 RVA: 0x00065CBC File Offset: 0x00063EBC
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ((ownerController != null) ? ownerController.GetClass().GetName() : null) ?? "undefined");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		double num = ModelBase<GameModeModel>.Instance.IsMulti ? Singleton<TimeUtil>.Instance.GetServerTimeStamp() : Singleton<Time>.Instance.WorldTime;
		aiController.SetCoolDownTime(this.TsId, num + (double)this.TsCoolDownTime, true, "行为树Task");
		base.FinishExecute(true);
	}

	// Token: 0x06004054 RID: 16468 RVA: 0x00065D75 File Offset: 0x00063F75
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSetCoolDown._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetCoolDown.TsTaskSetCoolDown_C");
		}
		return TsTaskSetCoolDown._ClassPtr;
	}

	// Token: 0x06004055 RID: 16469 RVA: 0x00065D9C File Offset: 0x00063F9C
	public TsTaskSetCoolDown() : this(BuiltinUtils.AllocNativeUObject(TsTaskSetCoolDown.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004056 RID: 16470 RVA: 0x00065DC4 File Offset: 0x00063FC4
	[NullableContext(1)]
	public TsTaskSetCoolDown(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetCoolDown.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004057 RID: 16471 RVA: 0x00065DF7 File Offset: 0x00063FF7
	protected TsTaskSetCoolDown(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004058 RID: 16472 RVA: 0x00065E00 File Offset: 0x00064000
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000EE4 RID: 3812
	private bool IsInitTsVariables;

	// Token: 0x04000EE5 RID: 3813
	private int TsId;

	// Token: 0x04000EE6 RID: 3814
	private float TsCoolDownTime;

	// Token: 0x04000EE7 RID: 3815
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSetCoolDown.TsTaskSetCoolDown_C";

	// Token: 0x04000EE8 RID: 3816
	private static IntPtr _ClassPtr;

	// Token: 0x04000EE9 RID: 3817
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000EEA RID: 3818
	private static int __PropertyOffset_Id;

	// Token: 0x04000EEB RID: 3819
	private static int __PropertyOffset_CoolDownTime;
}
