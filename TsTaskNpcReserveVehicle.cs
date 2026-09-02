using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C95 RID: 3221
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcReserveVehicle.TsTaskNpcReserveVehicle_C")]
public class TsTaskNpcReserveVehicle : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06003B8F RID: 15247 RVA: 0x0004DEC0 File Offset: 0x0004C0C0
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

	// Token: 0x06003B90 RID: 15248 RVA: 0x0004DF5C File Offset: 0x0004C15C
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		Singleton<Log>.Instance.Info(ELogModule.BehaviorTree, ELogAuthor.ZJL, "尝试绑定", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (!(ownerController is TsAiController))
		{
			base.FinishExecute(false);
			return;
		}
		AiController aiController = ((TsAiController)ownerController).AiController;
		CharacterActorComponent characterActorComponent = (aiController != null) ? aiController.CharActorComp : null;
		if (characterActorComponent == null)
		{
			base.FinishExecute(false);
			return;
		}
		int id = characterActorComponent.Entity.Id;
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(id, "SearchedRideableVehicleEntityId");
		if (intValueByEntity != null)
		{
			int? num = intValueByEntity;
			int num2 = 0;
			if (!(num.GetValueOrDefault() <= num2 & num != null))
			{
				if (!ControllerBase<NpcVehicleRiderController>.Instance.TryReserveVehicle(id, intValueByEntity.Value))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.BehaviorTree;
					ELogAuthor author = ELogAuthor.ZJL;
					string message = "预占载具失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("npcEntityId", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("vehicleEntityId", intValueByEntity);
					instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					base.FinishExecute(false);
					return;
				}
				if (!ControllerBase<NpcVehicleRiderController>.Instance.SetNpcVehicleRideState(id, ENpcVehicleRideState.MoveToVehicle))
				{
					ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(id);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.ZJL;
					string message2 = "置前往状态失败，回滚预占";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("npcEntityId", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("vehicleEntityId", intValueByEntity);
					instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					base.FinishExecute(false);
					return;
				}
				base.FinishExecute(true);
				return;
			}
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.BehaviorTree;
		ELogAuthor author3 = ELogAuthor.ZJL;
		string message3 = "黑板中没有可用载具";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("vehicleEntityId", intValueByEntity);
		instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		base.FinishExecute(false);
	}

	// Token: 0x06003B91 RID: 15249 RVA: 0x0004E130 File Offset: 0x0004C330
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcReserveVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcReserveVehicle.TsTaskNpcReserveVehicle_C");
		}
		return TsTaskNpcReserveVehicle._ClassPtr;
	}

	// Token: 0x06003B92 RID: 15250 RVA: 0x0004E154 File Offset: 0x0004C354
	public TsTaskNpcReserveVehicle() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcReserveVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B93 RID: 15251 RVA: 0x0004E17C File Offset: 0x0004C37C
	[NullableContext(1)]
	public TsTaskNpcReserveVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcReserveVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B94 RID: 15252 RVA: 0x0004E1AF File Offset: 0x0004C3AF
	protected TsTaskNpcReserveVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B95 RID: 15253 RVA: 0x0004E1B8 File Offset: 0x0004C3B8
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000AE5 RID: 2789
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcReserveVehicle.TsTaskNpcReserveVehicle_C";

	// Token: 0x04000AE6 RID: 2790
	private static IntPtr _ClassPtr;

	// Token: 0x04000AE7 RID: 2791
	private static IntPtr _ClassDefaultObjectPtr;
}
