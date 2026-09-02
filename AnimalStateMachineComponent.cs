using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal;
using UnrealEngine;

// Token: 0x02002E16 RID: 11798
[NullableContext(2)]
[Nullable(0)]
public class AnimalStateMachineComponent : EntityComponent
{
	// Token: 0x06017DEC RID: 97772 RVA: 0x006AF9C6 File Offset: 0x006ADBC6
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.StateMachine = new StateMachine<Entity, EAnimalPerformState>(base.Entity, new Action<EAnimalPerformState, EAnimalPerformState>(this.OnSwitchState));
		return true;
	}

	// Token: 0x06017DED RID: 97773 RVA: 0x006AF9E8 File Offset: 0x006ADBE8
	protected override bool OnStart()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		this.ConfigId = component.GetPbDataId();
		this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
		CharacterAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		IBPI_AnimalEcological_C ibpi_AnimalEcological_C = uanimInstance as IBPI_AnimalEcological_C;
		if (ibpi_AnimalEcological_C == null)
		{
			return true;
		}
		this.EcologicalInterface = ibpi_AnimalEcological_C;
		if (!UKuroStaticLibrary.IsObjectClassByName(uanimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASEANIMAL) && !UKuroStaticLibrary.IsObjectClassByName(uanimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASERUNANIMAL))
		{
			return true;
		}
		EntityArgs<IBPI_AnimalEcological_C> entityArgs = new EntityArgs<IBPI_AnimalEcological_C>(this.EcologicalInterface);
		this.StateMachine.AddState<AnimalPerformBornState>(EAnimalPerformState.Born, entityArgs);
		this.StateMachine.AddState<AnimalPerformStandState>(EAnimalPerformState.Stand, entityArgs);
		this.StateMachine.AddState<AnimalPerformIdleState>(EAnimalPerformState.Idle, entityArgs);
		this.StateMachine.AddState<AnimalPerformInteractState>(EAnimalPerformState.Interact, entityArgs);
		this.StateMachine.AddState<AnimalPerformUnderAttackState>(EAnimalPerformState.UnderAttack, entityArgs);
		this.StateMachine.AddState<AnimalPerformAlertState>(EAnimalPerformState.Alert, entityArgs);
		this.StateMachine.AddState<AnimalPerformTakeOffState>(EAnimalPerformState.TakeOff, entityArgs);
		this.StateMachine.AddState<AnimalPerformSystemUiState>(EAnimalPerformState.SystemUi, entityArgs);
		return true;
	}

	// Token: 0x06017DEE RID: 97774 RVA: 0x006AFB08 File Offset: 0x006ADD08
	protected override void OnActivate()
	{
		this.StartStateMachine();
	}

	// Token: 0x06017DEF RID: 97775 RVA: 0x006AFB10 File Offset: 0x006ADD10
	protected override void OnTick(float delta)
	{
		if (!this.Initialize)
		{
			return;
		}
		this.StateMachine.Update(delta);
	}

	// Token: 0x06017DF0 RID: 97776 RVA: 0x006AFB27 File Offset: 0x006ADD27
	protected override bool OnEnd()
	{
		this.Initialize = false;
		this.StateMachine.Destroy();
		return true;
	}

	// Token: 0x06017DF1 RID: 97777 RVA: 0x006AFB3C File Offset: 0x006ADD3C
	private void OnSwitchState(EAnimalPerformState oldState, EAnimalPerformState newState)
	{
	}

	// Token: 0x06017DF2 RID: 97778 RVA: 0x006AFB3E File Offset: 0x006ADD3E
	public void StartStateMachine()
	{
		this.StateMachine.Start(this.StartState);
		this.Initialize = true;
	}

	// Token: 0x06017DF3 RID: 97779 RVA: 0x006AFB5C File Offset: 0x006ADD5C
	public EAnimalEcologicalState CurrentState()
	{
		return AnimalStateMachineComponent.GetUeState(this.StateMachine.CurrentState.Value);
	}

	// Token: 0x06017DF4 RID: 97780 RVA: 0x006AFB81 File Offset: 0x006ADD81
	public void SwitchState(EAnimalPerformState state)
	{
		if (!this.Initialize)
		{
			return;
		}
		this.StateMachine.Switch(state);
	}

	// Token: 0x06017DF5 RID: 97781 RVA: 0x006AFB9C File Offset: 0x006ADD9C
	public float GetWaitTime()
	{
		AnimalPerformStateBase animalPerformStateBase = this.StateMachine.GetState(this.StateMachine.CurrentState.Value) as AnimalPerformStateBase;
		if (animalPerformStateBase == null)
		{
			return 0f;
		}
		return animalPerformStateBase.GetActionTime();
	}

	// Token: 0x06017DF6 RID: 97782 RVA: 0x006AFBDB File Offset: 0x006ADDDB
	public AnimalPerformStateBase GetState(EAnimalPerformState state)
	{
		if (!this.Initialize)
		{
			return null;
		}
		return this.StateMachine.GetState(state) as AnimalPerformStateBase;
	}

	// Token: 0x06017DF7 RID: 97783 RVA: 0x006AFBF8 File Offset: 0x006ADDF8
	public AnimalPerformStateBase GetCurrentState()
	{
		if (!this.Initialize)
		{
			return null;
		}
		return this.GetState(this.StateMachine.CurrentState.Value);
	}

	// Token: 0x06017DF8 RID: 97784 RVA: 0x006AFC28 File Offset: 0x006ADE28
	[NullableContext(1)]
	public static string GetStateName(EAnimalPerformState state)
	{
		switch (state)
		{
		case EAnimalPerformState.Born:
			return "None";
		case EAnimalPerformState.Stand:
			return "None";
		case EAnimalPerformState.Idle:
			return "空闲";
		case EAnimalPerformState.Interact:
			return "交互";
		case EAnimalPerformState.UnderAttack:
			return "受击";
		case EAnimalPerformState.TakeOff:
			return "起飞";
		case EAnimalPerformState.Alert:
			return "警觉";
		case EAnimalPerformState.SystemUi:
			return "系统UI";
		default:
			return "None";
		}
	}

	// Token: 0x06017DF9 RID: 97785 RVA: 0x006AFC92 File Offset: 0x006ADE92
	public static EAnimalEcologicalState GetUeState(EAnimalPerformState state)
	{
		switch (state)
		{
		case EAnimalPerformState.Born:
			return EAnimalEcologicalState.None;
		case EAnimalPerformState.Stand:
			return EAnimalEcologicalState.None;
		case EAnimalPerformState.Idle:
			return EAnimalEcologicalState.空闲;
		case EAnimalPerformState.Interact:
			return EAnimalEcologicalState.交互;
		case EAnimalPerformState.UnderAttack:
			return EAnimalEcologicalState.受击;
		case EAnimalPerformState.TakeOff:
			return EAnimalEcologicalState.起飞;
		case EAnimalPerformState.Alert:
			return EAnimalEcologicalState.警觉;
		case EAnimalPerformState.SystemUi:
			return EAnimalEcologicalState.系统UI;
		default:
			return EAnimalEcologicalState.None;
		}
	}

	// Token: 0x06017DFA RID: 97786 RVA: 0x006AFCCD File Offset: 0x006ADECD
	public static EAnimalPerformState GetTsState(EAnimalEcologicalState state)
	{
		switch (state)
		{
		case EAnimalEcologicalState.None:
			return EAnimalPerformState.Stand;
		case EAnimalEcologicalState.空闲:
			return EAnimalPerformState.Idle;
		case EAnimalEcologicalState.警觉:
			return EAnimalPerformState.Alert;
		case EAnimalEcologicalState.受击:
			return EAnimalPerformState.UnderAttack;
		case EAnimalEcologicalState.起飞:
			return EAnimalPerformState.TakeOff;
		case EAnimalEcologicalState.交互:
			return EAnimalPerformState.Interact;
		case EAnimalEcologicalState.系统UI:
			return EAnimalPerformState.SystemUi;
		default:
			return EAnimalPerformState.Stand;
		}
	}

	// Token: 0x06017DFB RID: 97787 RVA: 0x006AFD04 File Offset: 0x006ADF04
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		AnimalStateMachineComponent animalStateMachineComponent = (AnimalStateMachineComponent)componentTemplate;
		if (base.CanResetComponentProperty("ConfigId"))
		{
			this.ConfigId = animalStateMachineComponent.ConfigId;
		}
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (animalStateMachineComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EcologicalInterface"))
		{
			if (animalStateMachineComponent.EcologicalInterface == null)
			{
				this.EcologicalInterface = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<IBPI_AnimalEcological_C>(this.EcologicalInterface), "EcologicalInterface"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StateMachine"))
		{
			if (animalStateMachineComponent.StateMachine == null)
			{
				this.StateMachine = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<StateMachine<Entity, EAnimalPerformState>>(this.StateMachine), "StateMachine"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Initialize"))
		{
			this.Initialize = animalStateMachineComponent.Initialize;
		}
		return true;
	}

	// Token: 0x0400B929 RID: 47401
	private int ConfigId;

	// Token: 0x0400B92A RID: 47402
	private CharacterAnimationComponent AnimComp;

	// Token: 0x0400B92B RID: 47403
	private IBPI_AnimalEcological_C EcologicalInterface;

	// Token: 0x0400B92C RID: 47404
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private StateMachine<Entity, EAnimalPerformState> StateMachine;

	// Token: 0x0400B92D RID: 47405
	private readonly EAnimalPerformState StartState;

	// Token: 0x0400B92E RID: 47406
	private bool Initialize;
}
