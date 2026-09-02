using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE3 RID: 3299
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToTargetContinuously.TsTaskTurnToTargetContinuously_C")]
public class TsTaskTurnToTargetContinuously : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002FC RID: 764
	// (get) Token: 0x06004147 RID: 16711 RVA: 0x0006AF7F File Offset: 0x0006917F
	// (set) Token: 0x06004148 RID: 16712 RVA: 0x0006AF93 File Offset: 0x00069193
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyActor
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToTargetContinuously.__PropertyOffset_BlackboardKeyActor)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTurnToTargetContinuously.__PropertyOffset_BlackboardKeyActor)), value);
		}
	}

	// Token: 0x170002FD RID: 765
	// (get) Token: 0x06004149 RID: 16713 RVA: 0x0006AFA8 File Offset: 0x000691A8
	// (set) Token: 0x0600414A RID: 16714 RVA: 0x0006AFB8 File Offset: 0x000691B8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToTargetContinuously.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToTargetContinuously.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x0600414B RID: 16715 RVA: 0x0006AFC9 File Offset: 0x000691C9
	// (set) Token: 0x0600414C RID: 16716 RVA: 0x0006AFD9 File Offset: 0x000691D9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EndAfterTurnToTarget
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToTargetContinuously.__PropertyOffset_EndAfterTurnToTarget) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToTargetContinuously.__PropertyOffset_EndAfterTurnToTarget) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600414D RID: 16717 RVA: 0x0006AFEA File Offset: 0x000691EA
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKeyActor = this.BlackboardKeyActor;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsEndAfterTurnToTarget = this.EndAfterTurnToTarget;
		}
	}

	// Token: 0x0600414E RID: 16718 RVA: 0x0006B028 File Offset: 0x00069228
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

	// Token: 0x0600414F RID: 16719 RVA: 0x0006B0C8 File Offset: 0x000692C8
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
			characterActorComponent2 = characterActorComponent3;
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
		if (this.TsEndAfterTurnToTarget && Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(charActorComp) < 5f)
		{
			base.FinishExecute(true);
		}
	}

	// Token: 0x06004150 RID: 16720 RVA: 0x0006B229 File Offset: 0x00069429
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTurnToTargetContinuously._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToTargetContinuously.TsTaskTurnToTargetContinuously_C");
		}
		return TsTaskTurnToTargetContinuously._ClassPtr;
	}

	// Token: 0x06004151 RID: 16721 RVA: 0x0006B250 File Offset: 0x00069450
	public TsTaskTurnToTargetContinuously() : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToTargetContinuously.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004152 RID: 16722 RVA: 0x0006B278 File Offset: 0x00069478
	public TsTaskTurnToTargetContinuously(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToTargetContinuously.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004153 RID: 16723 RVA: 0x0006B2AB File Offset: 0x000694AB
	protected TsTaskTurnToTargetContinuously(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004154 RID: 16724 RVA: 0x0006B2C0 File Offset: 0x000694C0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000FBD RID: 4029
	private const float TOLERANCE_ANGLE = 5f;

	// Token: 0x04000FBE RID: 4030
	private const string CURRENT_PLAYER = "_currentPlayer";

	// Token: 0x04000FBF RID: 4031
	private bool IsInitTsVariables;

	// Token: 0x04000FC0 RID: 4032
	private string TsBlackboardKeyActor = "";

	// Token: 0x04000FC1 RID: 4033
	private float TsTurnSpeed;

	// Token: 0x04000FC2 RID: 4034
	private bool TsEndAfterTurnToTarget;

	// Token: 0x04000FC3 RID: 4035
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTurnToTargetContinuously.TsTaskTurnToTargetContinuously_C";

	// Token: 0x04000FC4 RID: 4036
	private static IntPtr _ClassPtr;

	// Token: 0x04000FC5 RID: 4037
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000FC6 RID: 4038
	private static int __PropertyOffset_BlackboardKeyActor;

	// Token: 0x04000FC7 RID: 4039
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000FC8 RID: 4040
	private static int __PropertyOffset_EndAfterTurnToTarget;
}
