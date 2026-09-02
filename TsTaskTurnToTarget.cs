using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE2 RID: 3298
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToTarget.TsTaskTurnToTarget_C")]
public class TsTaskTurnToTarget : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002FA RID: 762
	// (get) Token: 0x0600413B RID: 16699 RVA: 0x0006AC2F File Offset: 0x00068E2F
	// (set) Token: 0x0600413C RID: 16700 RVA: 0x0006AC43 File Offset: 0x00068E43
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyActor
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToTarget.__PropertyOffset_BlackboardKeyActor)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToTarget.__PropertyOffset_BlackboardKeyActor)), value);
		}
	}

	// Token: 0x170002FB RID: 763
	// (get) Token: 0x0600413D RID: 16701 RVA: 0x0006AC58 File Offset: 0x00068E58
	// (set) Token: 0x0600413E RID: 16702 RVA: 0x0006AC68 File Offset: 0x00068E68
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToTarget.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToTarget.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x0600413F RID: 16703 RVA: 0x0006AC79 File Offset: 0x00068E79
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKeyActor = this.BlackboardKeyActor;
			this.TsTurnSpeed = this.TurnSpeed;
		}
	}

	// Token: 0x06004140 RID: 16704 RVA: 0x0006ACAC File Offset: 0x00068EAC
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

	// Token: 0x06004141 RID: 16705 RVA: 0x0006AD4C File Offset: 0x00068F4C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		CharacterActorComponent characterActorComponent;
		if (currentTarget == null)
		{
			characterActorComponent = null;
		}
		else
		{
			WorldEntity entity = currentTarget.Entity;
			characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent2 = characterActorComponent;
		if (this.TsBlackboardKeyActor == "_currentPlayer")
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent3;
			if (baseCharacter == null)
			{
				characterActorComponent3 = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent4 = baseCharacter.CharacterActorComponent;
				if (characterActorComponent4 == null)
				{
					characterActorComponent3 = null;
				}
				else
				{
					Entity entity2 = characterActorComponent4.Entity;
					characterActorComponent3 = ((entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null);
				}
			}
			CharacterActorComponent characterActorComponent5 = characterActorComponent3;
			if (characterActorComponent5 == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.BehaviorTree, ELogAuthor.LCZ, "不存在玩家", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			characterActorComponent2 = characterActorComponent5;
		}
		else if (this.TsBlackboardKeyActor != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyActor);
			if (entityIdByEntity != null)
			{
				characterActorComponent2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterActorComponent>(entityIdByEntity.Value);
			}
		}
		if (characterActorComponent2 == null)
		{
			base.FinishExecute(false);
			return;
		}
		AiControllerLibrary.TurnToTarget(charActorComp, characterActorComponent2.ActorLocationProxy, this.TsTurnSpeed, false, 0f);
		base.FinishExecute(true);
	}

	// Token: 0x06004142 RID: 16706 RVA: 0x0006AEB8 File Offset: 0x000690B8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTurnToTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToTarget.TsTaskTurnToTarget_C");
		}
		return TsTaskTurnToTarget._ClassPtr;
	}

	// Token: 0x06004143 RID: 16707 RVA: 0x0006AEDC File Offset: 0x000690DC
	public TsTaskTurnToTarget() : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004144 RID: 16708 RVA: 0x0006AF04 File Offset: 0x00069104
	public TsTaskTurnToTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004145 RID: 16709 RVA: 0x0006AF37 File Offset: 0x00069137
	protected TsTaskTurnToTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004146 RID: 16710 RVA: 0x0006AF4C File Offset: 0x0006914C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000FB4 RID: 4020
	private const string CURRENT_PLAYER = "_currentPlayer";

	// Token: 0x04000FB5 RID: 4021
	private bool IsInitTsVariables;

	// Token: 0x04000FB6 RID: 4022
	private string TsBlackboardKeyActor = "";

	// Token: 0x04000FB7 RID: 4023
	private float TsTurnSpeed;

	// Token: 0x04000FB8 RID: 4024
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToTarget.TsTaskTurnToTarget_C";

	// Token: 0x04000FB9 RID: 4025
	private static IntPtr _ClassPtr;

	// Token: 0x04000FBA RID: 4026
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000FBB RID: 4027
	private static int __PropertyOffset_BlackboardKeyActor;

	// Token: 0x04000FBC RID: 4028
	private static int __PropertyOffset_TurnSpeed;
}
