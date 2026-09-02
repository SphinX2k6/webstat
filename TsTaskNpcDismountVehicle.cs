using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C90 RID: 3216
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcDismountVehicle.TsTaskNpcDismountVehicle_C")]
public class TsTaskNpcDismountVehicle : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001BB RID: 443
	// (get) Token: 0x06003B13 RID: 15123 RVA: 0x0004A9F7 File Offset: 0x00048BF7
	// (set) Token: 0x06003B14 RID: 15124 RVA: 0x0004AA07 File Offset: 0x00048C07
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MaxExecuteTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcDismountVehicle.__PropertyOffset_MaxExecuteTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcDismountVehicle.__PropertyOffset_MaxExecuteTime) = value;
		}
	}

	// Token: 0x06003B15 RID: 15125 RVA: 0x0004AA18 File Offset: 0x00048C18
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMaxExecuteTime = this.MaxExecuteTime;
		}
	}

	// Token: 0x06003B16 RID: 15126 RVA: 0x0004AA3C File Offset: 0x00048C3C
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

	// Token: 0x06003B17 RID: 15127 RVA: 0x0004AAD8 File Offset: 0x00048CD8
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			base.FinishExecute(false);
			return;
		}
		AiController aiController = ((TsAiController)ownerController).AiController;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			base.FinishExecute(false);
			return;
		}
		this.NpcEntityId = charActorComp.Entity.Id;
		int? ridingVehicle = ControllerBase<NpcVehicleRiderController>.Instance.GetRidingVehicle(this.NpcEntityId);
		if (ridingVehicle == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[TsTaskNpcDismountVehicle] 失败:NPC未绑定任何载具";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		this.VehicleEntityId = ridingVehicle.Value;
		Entity entity = Singleton<EntitySystem>.Instance.Get(ridingVehicle.Value);
		if (entity == null || !entity.Active)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Vehicle;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "[TsTaskNpcDismountVehicle] 失败:载具实体失效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", ridingVehicle);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.FinishExecute(false);
			return;
		}
		this.IsDismounting = false;
		this.ExecuteTimeStamp = Singleton<Time>.Instance.WorldTime;
	}

	// Token: 0x06003B18 RID: 15128 RVA: 0x0004AC74 File Offset: 0x00048E74
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

	// Token: 0x06003B19 RID: 15129 RVA: 0x0004AD14 File Offset: 0x00048F14
	[NullableContext(2)]
	protected unsafe virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!(ownerController is TsAiController))
		{
			base.Finish(false);
			return;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.NpcEntityId);
		if (entity == null || !entity.Active)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[TsTaskNpcDismountVehicle] 失败:NPC实体失效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.NpcEntityId);
			base.Finish(false);
			return;
		}
		Entity entity2 = Singleton<EntitySystem>.Instance.Get(this.VehicleEntityId);
		if (entity2 == null || !entity2.Active)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[TsTaskNpcDismountVehicle] 失败:载具实体失效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<NpcVehicleRiderController>.Instance.NotifyRideEntityInvalid(this.VehicleEntityId);
			base.Finish(false);
			return;
		}
		if (Singleton<Time>.Instance.WorldTime > this.ExecuteTimeStamp + (double)this.TsMaxExecuteTime)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Vehicle;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "[TsTaskNpcDismountVehicle] 失败:下车超时";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			base.Finish(false);
			return;
		}
		if (this.IsDismounting)
		{
			return;
		}
		LeaveVehicleDirectionAndMontage randomLeaveVehicleDirectionAndMontage = ControllerBase<NpcVehicleRiderController>.Instance.GetRandomLeaveVehicleDirectionAndMontage(this.NpcEntityId);
		string montagePath = ((randomLeaveVehicleDirectionAndMontage != null) ? randomLeaveVehicleDirectionAndMontage.Montage : null) ?? "";
		CommonNpcPerformComponent.EEnterVehicleDirection direction = (randomLeaveVehicleDirectionAndMontage != null) ? randomLeaveVehicleDirectionAndMontage.Direction : CommonNpcPerformComponent.EEnterVehicleDirection.Left;
		this.IsDismounting = true;
		ControllerBase<NpcVehicleRiderController>.Instance.DismountVehicle(this.NpcEntityId, this.VehicleEntityId, montagePath, direction, delegate(bool success, UAnimMontage montage)
		{
			if (!success)
			{
				base.Finish(false);
				return;
			}
			if (!ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.NpcEntityId))
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Vehicle;
				ELogAuthor author4 = ELogAuthor.ZJL;
				string message4 = "[TsTaskNpcDismountVehicle] 失败:解绑NPC与载具失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
				instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				base.Finish(false);
				return;
			}
			base.Finish(true);
		});
	}

	// Token: 0x06003B1A RID: 15130 RVA: 0x0004AF39 File Offset: 0x00049139
	protected override void OnClear()
	{
		this.IsDismounting = false;
	}

	// Token: 0x06003B1B RID: 15131 RVA: 0x0004AF42 File Offset: 0x00049142
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcDismountVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcDismountVehicle.TsTaskNpcDismountVehicle_C");
		}
		return TsTaskNpcDismountVehicle._ClassPtr;
	}

	// Token: 0x06003B1C RID: 15132 RVA: 0x0004AF68 File Offset: 0x00049168
	public TsTaskNpcDismountVehicle() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcDismountVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B1D RID: 15133 RVA: 0x0004AF90 File Offset: 0x00049190
	[NullableContext(1)]
	public TsTaskNpcDismountVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcDismountVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B1E RID: 15134 RVA: 0x0004AFC3 File Offset: 0x000491C3
	protected TsTaskNpcDismountVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B1F RID: 15135 RVA: 0x0004AFCC File Offset: 0x000491CC
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003B20 RID: 15136 RVA: 0x0004AFFC File Offset: 0x000491FC
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000A72 RID: 2674
	private bool IsInitTsVariables;

	// Token: 0x04000A73 RID: 2675
	private int TsMaxExecuteTime;

	// Token: 0x04000A74 RID: 2676
	private int NpcEntityId;

	// Token: 0x04000A75 RID: 2677
	private int VehicleEntityId;

	// Token: 0x04000A76 RID: 2678
	private bool IsDismounting;

	// Token: 0x04000A77 RID: 2679
	private double ExecuteTimeStamp;

	// Token: 0x04000A78 RID: 2680
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcDismountVehicle.TsTaskNpcDismountVehicle_C";

	// Token: 0x04000A79 RID: 2681
	private static IntPtr _ClassPtr;

	// Token: 0x04000A7A RID: 2682
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A7B RID: 2683
	private static int __PropertyOffset_MaxExecuteTime;
}
