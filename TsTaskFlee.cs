using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CB7 RID: 3255
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFlee.TsTaskFlee_C")]
public class TsTaskFlee : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000238 RID: 568
	// (get) Token: 0x06003DD7 RID: 15831 RVA: 0x0005967D File Offset: 0x0005787D
	// (set) Token: 0x06003DD8 RID: 15832 RVA: 0x00059691 File Offset: 0x00057891
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFlee.__PropertyOffset_TargetKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskFlee.__PropertyOffset_TargetKey)), value);
		}
	}

	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06003DD9 RID: 15833 RVA: 0x000596A6 File Offset: 0x000578A6
	// (set) Token: 0x06003DDA RID: 15834 RVA: 0x000596B6 File Offset: 0x000578B6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OverrideTurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_OverrideTurnSpeed) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_OverrideTurnSpeed) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700023A RID: 570
	// (get) Token: 0x06003DDB RID: 15835 RVA: 0x000596C7 File Offset: 0x000578C7
	// (set) Token: 0x06003DDC RID: 15836 RVA: 0x000596D7 File Offset: 0x000578D7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06003DDD RID: 15837 RVA: 0x000596E8 File Offset: 0x000578E8
	// (set) Token: 0x06003DDE RID: 15838 RVA: 0x000596F8 File Offset: 0x000578F8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ForceNavigation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_ForceNavigation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_ForceNavigation) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06003DDF RID: 15839 RVA: 0x00059709 File Offset: 0x00057909
	// (set) Token: 0x06003DE0 RID: 15840 RVA: 0x00059719 File Offset: 0x00057919
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool LeapMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_LeapMode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_LeapMode) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700023D RID: 573
	// (get) Token: 0x06003DE1 RID: 15841 RVA: 0x0005972A File Offset: 0x0005792A
	// (set) Token: 0x06003DE2 RID: 15842 RVA: 0x0005973A File Offset: 0x0005793A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LeapDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_LeapDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskFlee.__PropertyOffset_LeapDistance) = value;
		}
	}

	// Token: 0x06003DE3 RID: 15843 RVA: 0x0005974C File Offset: 0x0005794C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTargetKey = this.TargetKey;
			this.TsOverrideTurnSpeed = this.OverrideTurnSpeed;
			this.TsTurnSpeed = (float)this.TurnSpeed;
			this.TsForceNavigation = this.ForceNavigation;
			this.TsLeapMode = this.LeapMode;
			this.TsLeapDistance = this.LeapDistance;
		}
	}

	// Token: 0x06003DE4 RID: 15844 RVA: 0x000597B8 File Offset: 0x000579B8
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

	// Token: 0x06003DE5 RID: 15845 RVA: 0x00059854 File Offset: 0x00057A54
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
			return;
		}
		if (aiController.AiFlee == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "没有配置逃跑";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		CharacterActorComponent characterActorComponent = null;
		if (!string.IsNullOrEmpty(this.TsTargetKey))
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(aiController.CharActorComp.Entity.Id, this.TsTargetKey);
			if (entityIdByEntity != null)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value);
				if (entity != null)
				{
					characterActorComponent = entity.GetComponent<CharacterActorComponent>();
				}
			}
		}
		else
		{
			AiHateList aiHateList = aiController.AiHateList;
			EntityHandle entityHandle = (aiHateList != null) ? aiHateList.GetCurrentTarget() : null;
			CharacterActorComponent characterActorComponent2;
			if (entityHandle == null)
			{
				characterActorComponent2 = null;
			}
			else
			{
				WorldEntity entity2 = entityHandle.Entity;
				characterActorComponent2 = ((entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null);
			}
			characterActorComponent = characterActorComponent2;
		}
		if (characterActorComponent == null)
		{
			this.FoundPath = false;
			base.Finish(true);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.CJH;
			string message3 = "CharacterActorComponent Invalid";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		Entity entity3 = charActorComp.Entity;
		if (entity3 == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.BehaviorTree;
			ELogAuthor author4 = ELogAuthor.CJH;
			string message4 = "Entity Invalid";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			return;
		}
		this.MoveComp = entity3.GetComponent<CharacterMoveComponent>();
		if (this.MoveComp == null)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.BehaviorTree;
			ELogAuthor author5 = ELogAuthor.CJH;
			string message5 = "CharacterMoveComponent Invalid";
			ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
			return;
		}
		if (this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Flying)
		{
			this.IsFlying = true;
		}
		global::Vector actorLocationProxy = charActorComp.ActorLocationProxy;
		global::Vector vector = global::Vector.Create();
		actorLocationProxy.Subtraction(characterActorComponent.ActorLocationProxy, vector);
		vector.Z = 0.0;
		vector.Normalize(9.999999974752427E-07);
		global::Vector vector2 = global::Vector.Create(-vector.Y, vector.X, 0.0);
		AiFlee value = aiController.AiFlee.Value;
		double num = Singleton<MathUtils>.Instance.GetRandomRange((double)value.FleeAngle.Value.Min, (double)value.FleeAngle.Value.Max) * 0.01745329238474369;
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		double randomRange = Singleton<MathUtils>.Instance.GetRandomRange((double)value.FleeDistance.Value.Min, (double)value.FleeDistance.Value.Max);
		double num4 = 0.0;
		if (this.IsFlying)
		{
			num4 = (double)value.FleeHeight;
		}
		FVectorDouble fvectorDouble = new FVectorDouble(actorLocationProxy.X + (vector.X * num2 + vector2.X * num3) * randomRange, actorLocationProxy.Y + (vector.Y * num2 + vector2.Y * num3) * randomRange, actorLocationProxy.Z + num4);
		if (this.NavigationPath == null)
		{
			this.NavigationPath = new List<global::Vector>();
		}
		if (!this.IsFlying)
		{
			this.FoundPath = AiControllerLibrary.NavigationFindPath(ownerController, actorLocationProxy.ToUeVector(false), fvectorDouble, this.NavigationPath, null, null);
		}
		else
		{
			global::Vector item = global::Vector.Create(actorLocationProxy);
			this.FoundPath = true;
			this.NavigationPath.Clear();
			this.NavigationPath.Add(item);
			this.NavigationPath.Add(global::Vector.Create(fvectorDouble));
		}
		if (!this.TsForceNavigation && !this.FoundPath)
		{
			global::Vector item2 = global::Vector.Create(actorLocationProxy);
			this.FoundPath = true;
			this.NavigationPath.Clear();
			this.NavigationPath.Add(item2);
			this.NavigationPath.Add(global::Vector.Create(fvectorDouble));
		}
		if (!this.FoundPath)
		{
			FVectorDouble to = default(FVectorDouble);
			if (UNavigationSystemV1.D_K2_ProjectPointToNavigation(GlobalData.World, fvectorDouble, ref to, null, default(TSubclassOf<UNavigationQueryFilter>), new FVectorDouble(randomRange, randomRange, 100.0), -1.0))
			{
				this.FoundPath = AiControllerLibrary.NavigationFindPath(ownerController, actorLocationProxy.ToUeVector(false), to, this.NavigationPath, null, null);
			}
		}
		if (!this.FoundPath)
		{
			base.Finish(true);
			return;
		}
		this.CurrentNavigationIndex = 1;
		this.NavigationEndTime = Singleton<Time>.Instance.WorldTime + (double)value.TimeMilliseconds;
		BaseUnifiedStateComponent component = aiController.CharAiDesignComp.Entity.GetComponent<BaseUnifiedStateComponent>();
		if (component != null && component.Valid)
		{
			component.SetMoveState(ECharMoveState.Run);
		}
	}

	// Token: 0x06003DE6 RID: 15846 RVA: 0x00059DA0 File Offset: 0x00057FA0
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

	// Token: 0x06003DE7 RID: 15847 RVA: 0x00059E40 File Offset: 0x00058040
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			base.FinishExecute(false);
			return;
		}
		if (Singleton<Time>.Instance.WorldTime > this.NavigationEndTime)
		{
			base.Finish(true);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (this.MoveComp.CharacterMovement.MovementMode == EMovementMode.MOVE_Flying)
		{
			this.IsFlying = true;
		}
		else
		{
			this.IsFlying = false;
		}
		global::Vector vector = global::Vector.Create(this.NavigationPath[this.CurrentNavigationIndex]);
		vector.Subtraction(charActorComp.ActorLocationProxy, vector);
		if (!this.IsFlying)
		{
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(charActorComp, vector);
		}
		double num = vector.Size();
		this.CompleteDistance = (this.TsLeapMode ? this.TsLeapDistance : 50f);
		if (num < (double)this.CompleteDistance)
		{
			this.CurrentNavigationIndex++;
			if (this.CurrentNavigationIndex == this.NavigationPath.Count)
			{
				base.Finish(true);
				return;
			}
		}
		vector.Z /= num;
		vector.X /= num;
		vector.Y /= num;
		charActorComp.SetInputDirect(vector, false);
		if (this.TsOverrideTurnSpeed)
		{
			AiControllerLibrary.TurnToDirect(charActorComp, vector, this.TsTurnSpeed, false, 0f);
			return;
		}
		CharacterActorComponent actorComp = charActorComp;
		global::Vector direct = vector;
		AiWanderInfos aiWanderInfos = aiController.AiWanderInfos;
		AiControllerLibrary.TurnToDirect(actorComp, direct, (aiWanderInfos != null && aiWanderInfos.AiWander != null) ? aiController.AiWanderInfos.AiWander.Value.TurnSpeed : 360f, false, 0f);
	}

	// Token: 0x06003DE8 RID: 15848 RVA: 0x00059FE4 File Offset: 0x000581E4
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			AiControllerLibrary.ClearInput(tsAiController);
		}
		this.MoveComp = null;
		this.NavigationPath = null;
		this.FoundPath = false;
	}

	// Token: 0x06003DE9 RID: 15849 RVA: 0x0005A01B File Offset: 0x0005821B
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskFlee._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFlee.TsTaskFlee_C");
		}
		return TsTaskFlee._ClassPtr;
	}

	// Token: 0x06003DEA RID: 15850 RVA: 0x0005A040 File Offset: 0x00058240
	public TsTaskFlee() : this(BuiltinUtils.AllocNativeUObject(TsTaskFlee.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003DEB RID: 15851 RVA: 0x0005A068 File Offset: 0x00058268
	public TsTaskFlee(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFlee.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003DEC RID: 15852 RVA: 0x0005A09B File Offset: 0x0005829B
	protected TsTaskFlee(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003DED RID: 15853 RVA: 0x0005A0B0 File Offset: 0x000582B0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003DEE RID: 15854 RVA: 0x0005A0E0 File Offset: 0x000582E0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000CBD RID: 3261
	private const float NEAR_ZERO = 1E-06f;

	// Token: 0x04000CBE RID: 3262
	private const float NAVIGATION_COMPLETE_DISTANCE = 50f;

	// Token: 0x04000CBF RID: 3263
	private const double EDGE_Z = 100.0;

	// Token: 0x04000CC0 RID: 3264
	private bool IsInitTsVariables;

	// Token: 0x04000CC1 RID: 3265
	private string TsTargetKey = "";

	// Token: 0x04000CC2 RID: 3266
	private bool TsOverrideTurnSpeed;

	// Token: 0x04000CC3 RID: 3267
	private float TsTurnSpeed;

	// Token: 0x04000CC4 RID: 3268
	private bool TsForceNavigation;

	// Token: 0x04000CC5 RID: 3269
	private bool TsLeapMode;

	// Token: 0x04000CC6 RID: 3270
	private float TsLeapDistance;

	// Token: 0x04000CC7 RID: 3271
	private bool FoundPath;

	// Token: 0x04000CC8 RID: 3272
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> NavigationPath;

	// Token: 0x04000CC9 RID: 3273
	private int CurrentNavigationIndex;

	// Token: 0x04000CCA RID: 3274
	private double NavigationEndTime;

	// Token: 0x04000CCB RID: 3275
	private bool IsFlying;

	// Token: 0x04000CCC RID: 3276
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x04000CCD RID: 3277
	private float CompleteDistance;

	// Token: 0x04000CCE RID: 3278
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskFlee.TsTaskFlee_C";

	// Token: 0x04000CCF RID: 3279
	private static IntPtr _ClassPtr;

	// Token: 0x04000CD0 RID: 3280
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000CD1 RID: 3281
	private static int __PropertyOffset_TargetKey;

	// Token: 0x04000CD2 RID: 3282
	private static int __PropertyOffset_OverrideTurnSpeed;

	// Token: 0x04000CD3 RID: 3283
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000CD4 RID: 3284
	private static int __PropertyOffset_ForceNavigation;

	// Token: 0x04000CD5 RID: 3285
	private static int __PropertyOffset_LeapMode;

	// Token: 0x04000CD6 RID: 3286
	private static int __PropertyOffset_LeapDistance;
}
