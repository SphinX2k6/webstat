using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.LevelAi.BehaviorTree;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C87 RID: 3207
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPatrolStateReset.TsTaskPatrolStateReset_C")]
public class TsTaskPatrolStateReset : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x06003A7C RID: 14972 RVA: 0x00047DE3 File Offset: 0x00045FE3
	// (set) Token: 0x06003A7D RID: 14973 RVA: 0x00047DF3 File Offset: 0x00045FF3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SplineId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolStateReset.__PropertyOffset_SplineId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolStateReset.__PropertyOffset_SplineId) = value;
		}
	}

	// Token: 0x06003A7E RID: 14974 RVA: 0x00047E04 File Offset: 0x00046004
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

	// Token: 0x06003A7F RID: 14975 RVA: 0x00047EA0 File Offset: 0x000460A0
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
			base.FinishExecute(true);
			return;
		}
		string stringValueByEntity = ControllerBase<BlackboardController>.Instance.GetStringValueByEntity(aiController.CharAiDesignComp.Entity.Id, "PATROL_STATE");
		if (stringValueByEntity == null || !stringValueByEntity.EndsWith(this.SplineId.ToString()) || stringValueByEntity == "PATROL_COMPLETE")
		{
			string patrolStateName = BehaviorTreeDefines.GetPatrolStateName(this.SplineId);
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(aiController.CharAiDesignComp.Entity.Id, "PATROL_STATE", patrolStateName);
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003A80 RID: 14976 RVA: 0x00047F80 File Offset: 0x00046180
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPatrolStateReset._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPatrolStateReset.TsTaskPatrolStateReset_C");
		}
		return TsTaskPatrolStateReset._ClassPtr;
	}

	// Token: 0x06003A81 RID: 14977 RVA: 0x00047FA4 File Offset: 0x000461A4
	public TsTaskPatrolStateReset() : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolStateReset.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A82 RID: 14978 RVA: 0x00047FCC File Offset: 0x000461CC
	[NullableContext(1)]
	public TsTaskPatrolStateReset(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolStateReset.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A83 RID: 14979 RVA: 0x00047FFF File Offset: 0x000461FF
	protected TsTaskPatrolStateReset(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A84 RID: 14980 RVA: 0x00048008 File Offset: 0x00046208
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000A09 RID: 2569
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPatrolStateReset.TsTaskPatrolStateReset_C";

	// Token: 0x04000A0A RID: 2570
	private static IntPtr _ClassPtr;

	// Token: 0x04000A0B RID: 2571
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A0C RID: 2572
	private static int __PropertyOffset_SplineId;
}
