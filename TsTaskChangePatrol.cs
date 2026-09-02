using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CAA RID: 3242
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangePatrol.TsTaskChangePatrol_C")]
public class TsTaskChangePatrol : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001FE RID: 510
	// (get) Token: 0x06003CE1 RID: 15585 RVA: 0x00054B99 File Offset: 0x00052D99
	// (set) Token: 0x06003CE2 RID: 15586 RVA: 0x00054BA9 File Offset: 0x00052DA9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int PatrolIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskChangePatrol.__PropertyOffset_PatrolIndex);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskChangePatrol.__PropertyOffset_PatrolIndex) = value;
		}
	}

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x06003CE3 RID: 15587 RVA: 0x00054BBA File Offset: 0x00052DBA
	// (set) Token: 0x06003CE4 RID: 15588 RVA: 0x00054BCE File Offset: 0x00052DCE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string PatrolIdBlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskChangePatrol.__PropertyOffset_PatrolIdBlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskChangePatrol.__PropertyOffset_PatrolIdBlackboardKey)), value);
		}
	}

	// Token: 0x06003CE5 RID: 15589 RVA: 0x00054BE3 File Offset: 0x00052DE3
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsPatrolIndex = this.PatrolIndex;
			this.TsPatrolIdBlackboardKey = this.PatrolIdBlackboardKey;
		}
	}

	// Token: 0x06003CE6 RID: 15590 RVA: 0x00054C14 File Offset: 0x00052E14
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

	// Token: 0x06003CE7 RID: 15591 RVA: 0x00054CB0 File Offset: 0x00052EB0
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
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		int id = aiController.CharActorComp.Entity.Id;
		AiPatrolController aiPatrol = aiController.AiPatrol;
		if (this.TsPatrolIdBlackboardKey != "")
		{
			aiPatrol.ResetPatrolById(ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(id, this.TsPatrolIdBlackboardKey).Value);
		}
		else
		{
			aiPatrol.ResetPatrol(this.TsPatrolIndex);
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003CE8 RID: 15592 RVA: 0x00054D74 File Offset: 0x00052F74
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskChangePatrol._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangePatrol.TsTaskChangePatrol_C");
		}
		return TsTaskChangePatrol._ClassPtr;
	}

	// Token: 0x06003CE9 RID: 15593 RVA: 0x00054D98 File Offset: 0x00052F98
	public TsTaskChangePatrol() : this(BuiltinUtils.AllocNativeUObject(TsTaskChangePatrol.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003CEA RID: 15594 RVA: 0x00054DC0 File Offset: 0x00052FC0
	public TsTaskChangePatrol(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskChangePatrol.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003CEB RID: 15595 RVA: 0x00054DF3 File Offset: 0x00052FF3
	protected TsTaskChangePatrol(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003CEC RID: 15596 RVA: 0x00054E08 File Offset: 0x00053008
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000BDC RID: 3036
	private bool IsInitTsVariables;

	// Token: 0x04000BDD RID: 3037
	private int TsPatrolIndex;

	// Token: 0x04000BDE RID: 3038
	private string TsPatrolIdBlackboardKey = "";

	// Token: 0x04000BDF RID: 3039
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangePatrol.TsTaskChangePatrol_C";

	// Token: 0x04000BE0 RID: 3040
	private static IntPtr _ClassPtr;

	// Token: 0x04000BE1 RID: 3041
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BE2 RID: 3042
	private static int __PropertyOffset_PatrolIndex;

	// Token: 0x04000BE3 RID: 3043
	private static int __PropertyOffset_PatrolIdBlackboardKey;
}
