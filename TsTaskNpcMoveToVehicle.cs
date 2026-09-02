using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C92 RID: 3218
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcMoveToVehicle.TsTaskNpcMoveToVehicle_C")]
public class TsTaskNpcMoveToVehicle : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06003B32 RID: 15154 RVA: 0x0004B6E5 File Offset: 0x000498E5
	// (set) Token: 0x06003B33 RID: 15155 RVA: 0x0004B6F5 File Offset: 0x000498F5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x06003B34 RID: 15156 RVA: 0x0004B706 File Offset: 0x00049906
	// (set) Token: 0x06003B35 RID: 15157 RVA: 0x0004B716 File Offset: 0x00049916
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MoveSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_MoveSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_MoveSpeed) = value;
		}
	}

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x06003B36 RID: 15158 RVA: 0x0004B727 File Offset: 0x00049927
	// (set) Token: 0x06003B37 RID: 15159 RVA: 0x0004B737 File Offset: 0x00049937
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_EndDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_EndDistance) = value;
		}
	}

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x06003B38 RID: 15160 RVA: 0x0004B748 File Offset: 0x00049948
	// (set) Token: 0x06003B39 RID: 15161 RVA: 0x0004B758 File Offset: 0x00049958
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableDebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_EnableDebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcMoveToVehicle.__PropertyOffset_EnableDebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003B3A RID: 15162 RVA: 0x0004B769 File Offset: 0x00049969
	private void OnMoveEnd(ELevelEventState result)
	{
		if (result == ELevelEventState.Success)
		{
			base.Finish(true);
			return;
		}
		this.LogMoveFailed(result);
		base.Finish(false);
	}

	// Token: 0x06003B3B RID: 15163 RVA: 0x0004B788 File Offset: 0x00049988
	private unsafe void LogMoveFailed(ELevelEventState result)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Vehicle;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "[TsTaskNpcMoveToVehicle] 失败:移动到载具上车点失败(路径中断/不可达)";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Result", result);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06003B3C RID: 15164 RVA: 0x0004B81C File Offset: 0x00049A1C
	private void DrawDebugWaypoints(Vector start)
	{
		UKismetSystemLibrary.D_DrawDebugSphere(this, start.ToUeVector(false), 40f, 12, new FLinearColor?(TsTaskNpcMoveToVehicle.StartColor), 15f, 3f);
		foreach (Vector vector in this.TargetPath)
		{
			UKismetSystemLibrary.D_DrawDebugSphere(this, vector.ToUeVector(false), 40f, 12, new FLinearColor?(TsTaskNpcMoveToVehicle.WaypointColor), 15f, 3f);
		}
	}

	// Token: 0x06003B3D RID: 15165 RVA: 0x0004B8B8 File Offset: 0x00049AB8
	private void DrawDebugEnterBoxes()
	{
		VehicleEnterBoxDebugGeometry debugBoxGeometry = this.DebugBoxGeometry;
		if (!ControllerBase<NpcVehicleRiderController>.Instance.GetVehicleEnterBoxDebugGeometry(this.NpcEntityId, this.VehicleEntityId, debugBoxGeometry))
		{
			return;
		}
		FVectorDouble center = debugBoxGeometry.Center.ToUeVector(false);
		FRotator rotation = debugBoxGeometry.Rotation.ToUeRotator();
		UKismetSystemLibrary.D_DrawDebugBox(this, center, new FVectorDouble((double)debugBoxGeometry.ObstacleHalfLength, (double)debugBoxGeometry.ObstacleHalfWidth, 100.0), TsTaskNpcMoveToVehicle.ObstacleBoxColor, rotation, 15f, 3f);
		UKismetSystemLibrary.D_DrawDebugBox(this, center, new FVectorDouble((double)debugBoxGeometry.WaypointHalfLength, debugBoxGeometry.WaypointHalfWidth, 100.0), TsTaskNpcMoveToVehicle.WaypointBoxColor, rotation, 15f, 3f);
	}

	// Token: 0x06003B3E RID: 15166 RVA: 0x0004B964 File Offset: 0x00049B64
	private void DrawDebugPath(Vector start)
	{
		if (this.TargetPath.Count == 0)
		{
			return;
		}
		Vector vector = start;
		foreach (Vector vector2 in this.TargetPath)
		{
			UKismetSystemLibrary.D_DrawDebugArrow(this, vector.ToUeVector(false), vector2.ToUeVector(false), 80f, TsTaskNpcMoveToVehicle.PathArrowColor, 15f, 3f);
			vector = vector2;
		}
	}

	// Token: 0x06003B3F RID: 15167 RVA: 0x0004B9EC File Offset: 0x00049BEC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveState = this.MoveState;
			this.TsMoveSpeed = this.MoveSpeed;
			this.TsEndDistance = this.EndDistance;
			this.TargetPath.Clear();
		}
	}

	// Token: 0x06003B40 RID: 15168 RVA: 0x0004BA40 File Offset: 0x00049C40
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

	// Token: 0x06003B41 RID: 15169 RVA: 0x0004BADC File Offset: 0x00049CDC
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			base.Finish(false);
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
			base.Finish(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			base.Finish(false);
			return;
		}
		Entity entity = charActorComp.Entity;
		this.NpcEntityId = entity.Id;
		int? ridingVehicle = ControllerBase<NpcVehicleRiderController>.Instance.GetRidingVehicle(this.NpcEntityId);
		if (ridingVehicle == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[TsTaskNpcMoveToVehicle] 失败:NPC未绑定任何载具";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.Finish(false);
			return;
		}
		this.VehicleEntityId = ridingVehicle.Value;
		Entity entity2 = Singleton<EntitySystem>.Instance.Get(ridingVehicle.Value);
		if (entity2 == null || !entity2.Active)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Vehicle;
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "[TsTaskNpcMoveToVehicle] 失败:载具实体失效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", ridingVehicle);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<NpcVehicleRiderController>.Instance.NotifyRideEntityInvalid(this.VehicleEntityId);
			base.Finish(false);
			return;
		}
		if (!ControllerBase<NpcVehicleRiderController>.Instance.GetVehicleEnterPath(this.NpcEntityId, ridingVehicle.Value, this.TargetPath))
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Vehicle;
			ELogAuthor author4 = ELogAuthor.ZJL;
			string message4 = "[TsTaskNpcMoveToVehicle] 失败:载具上车点不可达";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("VehicleEntityId", ridingVehicle);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.NpcEntityId);
			base.Finish(false);
			return;
		}
		this.MoveComp = entity.GetComponent<BaseMoveComponent>();
		if (this.MoveComp == null)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.BehaviorTree;
			ELogAuthor author5 = ELogAuthor.ZJL;
			string message5 = "NPC缺少移动组件";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.NpcEntityId);
			base.Finish(false);
			return;
		}
		List<MoveCharacterPoint> list = new List<MoveCharacterPoint>();
		for (int i = 0; i < this.TargetPath.Count; i++)
		{
			list.Add(new MoveCharacterPoint
			{
				Index = i,
				Position = this.TargetPath[i],
				MoveState = new EPatrolMoveState?((EPatrolMoveState)this.TsMoveState),
				MoveSpeed = new float?(this.TsMoveSpeed)
			});
		}
		if (this.EnableDebugDraw)
		{
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			Vector vector = (component != null) ? component.ActorLocationProxy : null;
			if (vector != null)
			{
				this.DrawDebugEnterBoxes();
				this.DrawDebugWaypoints(vector);
				this.DrawDebugPath(vector);
			}
		}
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = list,
			Navigation = true,
			IsFly = false,
			DebugMode = false,
			Loop = false,
			Callback = new Action<ELevelEventState>(this.OnMoveEnd),
			ReturnFalseWhenNavigationFailed = true,
			Distance = new float?(this.TsEndDistance),
			EnablePlayerAccurateMoveToTarget = new bool?(true)
		};
		this.MoveHandleId = this.MoveComp.MoveAlongPath(config, "TsTaskNpcMoveToVehicle.ReceiveExecuteAI");
		Log instance6 = Singleton<Log>.Instance;
		ELogModule module6 = ELogModule.Vehicle;
		ELogAuthor author6 = ELogAuthor.ZJL;
		string message6 = "[TsTaskNpcMoveToVehicle] 开始移动到载具上车点";
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("VehicleEntityId", ridingVehicle);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("PathPointCount", list.Count);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("MoveState", this.TsMoveState);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("EndDistance", this.TsEndDistance);
		instance6.Info(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
	}

	// Token: 0x06003B42 RID: 15170 RVA: 0x0004BF58 File Offset: 0x0004A158
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

	// Token: 0x06003B43 RID: 15171 RVA: 0x0004BFF8 File Offset: 0x0004A1F8
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
			string message = "[TsTaskNpcMoveToVehicle] 失败:NPC实体失效";
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
			string message2 = "[TsTaskNpcMoveToVehicle] 失败:载具实体失效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NpcEntityId", this.NpcEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<NpcVehicleRiderController>.Instance.NotifyRideEntityInvalid(this.VehicleEntityId);
			base.Finish(false);
		}
	}

	// Token: 0x06003B44 RID: 15172 RVA: 0x0004C128 File Offset: 0x0004A328
	protected override void OnClear()
	{
		if (this.MoveComp != null)
		{
			this.MoveComp.StopMoveByHandleId(this.MoveHandleId, "TsTaskNpcMoveToVehicle.OnClear");
			this.MoveComp = null;
		}
	}

	// Token: 0x06003B45 RID: 15173 RVA: 0x0004C14F File Offset: 0x0004A34F
	protected override void OnAbort()
	{
		if (this.MoveComp != null)
		{
			this.MoveComp.StopMoveByHandleId(this.MoveHandleId, "TsTaskNpcMoveToVehicle.OnAbort");
			this.MoveComp = null;
		}
		ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.NpcEntityId);
	}

	// Token: 0x06003B46 RID: 15174 RVA: 0x0004C187 File Offset: 0x0004A387
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcMoveToVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcMoveToVehicle.TsTaskNpcMoveToVehicle_C");
		}
		return TsTaskNpcMoveToVehicle._ClassPtr;
	}

	// Token: 0x06003B47 RID: 15175 RVA: 0x0004C1AC File Offset: 0x0004A3AC
	public TsTaskNpcMoveToVehicle() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcMoveToVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B48 RID: 15176 RVA: 0x0004C1D4 File Offset: 0x0004A3D4
	public TsTaskNpcMoveToVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcMoveToVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B49 RID: 15177 RVA: 0x0004C207 File Offset: 0x0004A407
	protected TsTaskNpcMoveToVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B4A RID: 15178 RVA: 0x0004C228 File Offset: 0x0004A428
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003B4B RID: 15179 RVA: 0x0004C258 File Offset: 0x0004A458
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000A89 RID: 2697
	private const float DEBUG_BOX_HALF_HEIGHT = 100f;

	// Token: 0x04000A8A RID: 2698
	private const float DEBUG_DRAW_DURATION = 15f;

	// Token: 0x04000A8B RID: 2699
	private const float DEBUG_DRAW_THICKNESS = 3f;

	// Token: 0x04000A8C RID: 2700
	private const float DEBUG_PATH_ARROW_SIZE = 80f;

	// Token: 0x04000A8D RID: 2701
	private const float DEBUG_WAYPOINT_RADIUS = 40f;

	// Token: 0x04000A8E RID: 2702
	private const int DEBUG_WAYPOINT_SEGMENTS = 12;

	// Token: 0x04000A8F RID: 2703
	private static readonly FLinearColor ObstacleBoxColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x04000A90 RID: 2704
	private static readonly FLinearColor WaypointBoxColor = new FLinearColor(1f, 1f, 0f, 1f);

	// Token: 0x04000A91 RID: 2705
	private static readonly FLinearColor WaypointColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x04000A92 RID: 2706
	private static readonly FLinearColor StartColor = new FLinearColor(1f, 0f, 1f, 1f);

	// Token: 0x04000A93 RID: 2707
	private static readonly FLinearColor PathArrowColor = new FLinearColor(0f, 1f, 1f, 1f);

	// Token: 0x04000A94 RID: 2708
	private bool IsInitTsVariables;

	// Token: 0x04000A95 RID: 2709
	private int TsMoveState;

	// Token: 0x04000A96 RID: 2710
	private float TsMoveSpeed;

	// Token: 0x04000A97 RID: 2711
	private float TsEndDistance;

	// Token: 0x04000A98 RID: 2712
	private readonly List<Vector> TargetPath = new List<Vector>();

	// Token: 0x04000A99 RID: 2713
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x04000A9A RID: 2714
	private int MoveHandleId;

	// Token: 0x04000A9B RID: 2715
	private int NpcEntityId;

	// Token: 0x04000A9C RID: 2716
	private int VehicleEntityId;

	// Token: 0x04000A9D RID: 2717
	private readonly VehicleEnterBoxDebugGeometry DebugBoxGeometry = new VehicleEnterBoxDebugGeometry();

	// Token: 0x04000A9E RID: 2718
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcMoveToVehicle.TsTaskNpcMoveToVehicle_C";

	// Token: 0x04000A9F RID: 2719
	private static IntPtr _ClassPtr;

	// Token: 0x04000AA0 RID: 2720
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000AA1 RID: 2721
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000AA2 RID: 2722
	private static int __PropertyOffset_MoveSpeed;

	// Token: 0x04000AA3 RID: 2723
	private static int __PropertyOffset_EndDistance;

	// Token: 0x04000AA4 RID: 2724
	private static int __PropertyOffset_EnableDebugDraw;
}
