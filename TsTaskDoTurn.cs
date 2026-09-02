using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CAE RID: 3246
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskDoTurn.TsTaskDoTurn_C")]
public class TsTaskDoTurn : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06003D22 RID: 15650 RVA: 0x00055E75 File Offset: 0x00054075
	// (set) Token: 0x06003D23 RID: 15651 RVA: 0x00055E85 File Offset: 0x00054085
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool TurnToPlayer
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TurnToPlayer) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TurnToPlayer) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06003D24 RID: 15652 RVA: 0x00055E96 File Offset: 0x00054096
	// (set) Token: 0x06003D25 RID: 15653 RVA: 0x00055EA6 File Offset: 0x000540A6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TargetConfigId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TargetConfigId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TargetConfigId) = value;
		}
	}

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x06003D26 RID: 15654 RVA: 0x00055EB7 File Offset: 0x000540B7
	// (set) Token: 0x06003D27 RID: 15655 RVA: 0x00055ECB File Offset: 0x000540CB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetEntityKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskDoTurn.__PropertyOffset_TargetEntityKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskDoTurn.__PropertyOffset_TargetEntityKey)), value);
		}
	}

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x06003D28 RID: 15656 RVA: 0x00055EE0 File Offset: 0x000540E0
	// (set) Token: 0x06003D29 RID: 15657 RVA: 0x00055EF4 File Offset: 0x000540F4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetDirectKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskDoTurn.__PropertyOffset_TargetDirectKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskDoTurn.__PropertyOffset_TargetDirectKey)), value);
		}
	}

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x06003D2A RID: 15658 RVA: 0x00055F09 File Offset: 0x00054109
	// (set) Token: 0x06003D2B RID: 15659 RVA: 0x00055F19 File Offset: 0x00054119
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnAngleAxis
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TurnAngleAxis);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TurnAngleAxis) = value;
		}
	}

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x06003D2C RID: 15660 RVA: 0x00055F2A File Offset: 0x0005412A
	// (set) Token: 0x06003D2D RID: 15661 RVA: 0x00055F3A File Offset: 0x0005413A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x06003D2E RID: 15662 RVA: 0x00055F4B File Offset: 0x0005414B
	// (set) Token: 0x06003D2F RID: 15663 RVA: 0x00055F5B File Offset: 0x0005415B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinAngle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_MinAngle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_MinAngle) = value;
		}
	}

	// Token: 0x17000212 RID: 530
	// (get) Token: 0x06003D30 RID: 15664 RVA: 0x00055F6C File Offset: 0x0005416C
	// (set) Token: 0x06003D31 RID: 15665 RVA: 0x00055F7C File Offset: 0x0005417C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LoopTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_LoopTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskDoTurn.__PropertyOffset_LoopTime) = value;
		}
	}

	// Token: 0x06003D32 RID: 15666 RVA: 0x00055F90 File Offset: 0x00054190
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTurnToPlayer = this.TurnToPlayer;
			this.TsTargetConfigId = this.TargetConfigId;
			this.TsTargetEntityKey = this.TargetEntityKey;
			this.TsTargetDirectKey = this.TargetDirectKey;
			this.TsTurnAngleAxis = this.TurnAngleAxis;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsMinAngle = this.MinAngle;
			this.TsLoopTime = this.LoopTime;
		}
	}

	// Token: 0x06003D33 RID: 15667 RVA: 0x00056014 File Offset: 0x00054214
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

	// Token: 0x06003D34 RID: 15668 RVA: 0x000560B0 File Offset: 0x000542B0
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		this.InitTurnForward(charActorComp);
		this.EndTime = (double)this.TsLoopTime + Singleton<Time>.Instance.WorldTime;
	}

	// Token: 0x06003D35 RID: 15669 RVA: 0x00056100 File Offset: 0x00054300
	private void InitTurnForward(CharacterActorComponent actorComp)
	{
		if (this.EndForward == null)
		{
			this.EndForward = global::Vector.Create();
		}
		if (this.TsTurnToPlayer)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null)
			{
				baseCharacter.CharacterActorComponent.ActorLocationProxy.Subtraction(actorComp.ActorLocationProxy, this.EndForward);
			}
		}
		else if (this.TsTargetConfigId > 0)
		{
			List<ScenePlayerData> allScenePlayers = ModelBase<CreatureModel>.Instance.GetAllScenePlayers();
			int i = 0;
			int count = allScenePlayers.Count;
			while (i < count)
			{
				ScenePlayerData scenePlayerData = allScenePlayers[i];
				foreach (SceneTeamItem sceneTeamItem in ModelBase<SceneTeamModel>.Instance.GetTeamItemsByPlayer(scenePlayerData.GetPlayerId()))
				{
					EntityHandle entityHandle = sceneTeamItem.EntityHandle;
					if (entityHandle != null)
					{
						CreatureDataComponent component = entityHandle.Entity.GetComponent<CreatureDataComponent>();
						if (component != null && component.GetVisible() && component.GetPbDataId() == this.TsTargetConfigId)
						{
							scenePlayerData.GetLocation().Subtraction(actorComp.ActorLocationProxy, this.EndForward);
						}
					}
				}
				i++;
			}
		}
		else if (this.TsTargetEntityKey != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(actorComp.Entity.Id, this.TsTargetEntityKey);
			Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value).GetComponent<CharacterActorComponent>().ActorLocationProxy.Subtraction(actorComp.ActorLocationProxy, this.EndForward);
		}
		else if (this.TsTargetDirectKey != "")
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(actorComp.Entity.Id, this.TsTargetDirectKey);
			if (vectorValueByEntity != null)
			{
				this.EndForward.FromUeVector(vectorValueByEntity);
			}
		}
		else
		{
			global::Vector vector = global::Vector.Create(actorComp.ActorForward);
			vector.Normalize(1E-08);
			vector.RotateAngleAxis((double)this.TsTurnAngleAxis, global::Vector.UpVectorProxy, this.EndForward);
		}
		this.EndForward.Z = 0.0;
		this.EndForward.Normalize(1E-08);
	}

	// Token: 0x06003D36 RID: 15670 RVA: 0x0005632C File Offset: 0x0005452C
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

	// Token: 0x06003D37 RID: 15671 RVA: 0x000563CC File Offset: 0x000545CC
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
		FVectorDouble actorForward = aiController.CharActorComp.ActorForward;
		if (Singleton<MathUtils>.Instance.GetAngleByVectorDot(actorForward, this.EndForward) <= (double)this.TsMinAngle)
		{
			base.Finish(true);
			return;
		}
		AiControllerLibrary.TurnToDirect(aiController.CharActorComp, this.EndForward, this.TsTurnSpeed, false, 0f);
		if (this.EndTime < Singleton<Time>.Instance.WorldTime)
		{
			base.Finish(true);
		}
	}

	// Token: 0x06003D38 RID: 15672 RVA: 0x00056493 File Offset: 0x00054693
	protected override void OnClear()
	{
		this.EndForward.Reset();
		this.EndTime = 0.0;
	}

	// Token: 0x06003D39 RID: 15673 RVA: 0x000564AF File Offset: 0x000546AF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskDoTurn._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskDoTurn.TsTaskDoTurn_C");
		}
		return TsTaskDoTurn._ClassPtr;
	}

	// Token: 0x06003D3A RID: 15674 RVA: 0x000564D4 File Offset: 0x000546D4
	public TsTaskDoTurn() : this(BuiltinUtils.AllocNativeUObject(TsTaskDoTurn.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D3B RID: 15675 RVA: 0x000564FC File Offset: 0x000546FC
	public TsTaskDoTurn(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskDoTurn.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D3C RID: 15676 RVA: 0x0005652F File Offset: 0x0005472F
	protected TsTaskDoTurn(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D3D RID: 15677 RVA: 0x00056550 File Offset: 0x00054750
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003D3E RID: 15678 RVA: 0x00056580 File Offset: 0x00054780
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000C0E RID: 3086
	private bool IsInitTsVariables;

	// Token: 0x04000C0F RID: 3087
	private bool TsTurnToPlayer;

	// Token: 0x04000C10 RID: 3088
	private int TsTargetConfigId;

	// Token: 0x04000C11 RID: 3089
	private string TsTargetEntityKey = "";

	// Token: 0x04000C12 RID: 3090
	private string TsTargetDirectKey = "";

	// Token: 0x04000C13 RID: 3091
	private float TsTurnAngleAxis;

	// Token: 0x04000C14 RID: 3092
	private float TsTurnSpeed;

	// Token: 0x04000C15 RID: 3093
	private float TsMinAngle;

	// Token: 0x04000C16 RID: 3094
	private float TsLoopTime;

	// Token: 0x04000C17 RID: 3095
	[Nullable(2)]
	private global::Vector EndForward;

	// Token: 0x04000C18 RID: 3096
	private double EndTime;

	// Token: 0x04000C19 RID: 3097
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskDoTurn.TsTaskDoTurn_C";

	// Token: 0x04000C1A RID: 3098
	private static IntPtr _ClassPtr;

	// Token: 0x04000C1B RID: 3099
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000C1C RID: 3100
	private static int __PropertyOffset_TurnToPlayer;

	// Token: 0x04000C1D RID: 3101
	private static int __PropertyOffset_TargetConfigId;

	// Token: 0x04000C1E RID: 3102
	private static int __PropertyOffset_TargetEntityKey;

	// Token: 0x04000C1F RID: 3103
	private static int __PropertyOffset_TargetDirectKey;

	// Token: 0x04000C20 RID: 3104
	private static int __PropertyOffset_TurnAngleAxis;

	// Token: 0x04000C21 RID: 3105
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000C22 RID: 3106
	private static int __PropertyOffset_MinAngle;

	// Token: 0x04000C23 RID: 3107
	private static int __PropertyOffset_LoopTime;
}
