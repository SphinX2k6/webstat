using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState;
using UnrealEngine;

// Token: 0x02000F99 RID: 3993
[NullableContext(2)]
[Nullable(0)]
public class DgmClawStateController
{
	// Token: 0x170007EC RID: 2028
	// (get) Token: 0x060065D4 RID: 26068 RVA: 0x00199A80 File Offset: 0x00197C80
	public AKuroLevelSequenceActor ClawAnimSeqActor
	{
		get
		{
			return this.ClawAnimSeqActorInternal;
		}
	}

	// Token: 0x060065D5 RID: 26069 RVA: 0x00199A88 File Offset: 0x00197C88
	[NullableContext(1)]
	public DgmClawStateController(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootCtrlActor, AActor clawChainActor, FTransformDouble clawTransform)
	{
		this.Owner = owner;
		this.ClawActorInternal = clawActor;
		this.IdleState = new DgmClawIdleState(this.Owner, clawActor, clawRootCtrlActor, clawTransform);
		this.MovingDownState = new DgmClawMovingDownState(this.Owner, clawActor, clawRootCtrlActor, clawChainActor, clawTransform);
		this.MovingUpState = new DgmClawMovingUpState(this.Owner, clawActor, clawRootCtrlActor, clawChainActor, clawTransform);
		this.GrabState = new DgmClawGrabState(this.Owner, clawActor, clawRootCtrlActor, clawTransform);
		this.ReleaseState = new DgmClawReleaseState(this.Owner, clawActor, clawRootCtrlActor, clawTransform);
		this.ResetState = new DgmClawResetState(this.Owner, clawActor, clawRootCtrlActor, clawTransform);
		Singleton<EventSystem>.Instance.AddWithTarget(this.Owner.Entity, EEventName.OnDollGrabMachineClawStateEnd, new Action(this.OnStateExit));
	}

	// Token: 0x060065D6 RID: 26070 RVA: 0x00199B74 File Offset: 0x00197D74
	public void Init()
	{
		foreach (FName key in this.ClawActorInternal.Tags)
		{
			if (key.ToString().StartsWith("Claw_"))
			{
				this.ClawPartMap.Add(key, this.ClawActorInternal);
				this.ClawPartActorList.Add(this.ClawActorInternal);
				break;
			}
		}
		this.CollectClawPart(this.ClawActorInternal);
		AKuroLevelSequenceActor akuroLevelSequenceActor = Singleton<ActorSystem>.Instance.Get<AKuroLevelSequenceActor>(AKuroLevelSequenceActor.StaticClass(), this.Owner.ActorTransform, null, false);
		if (akuroLevelSequenceActor != null)
		{
			akuroLevelSequenceActor.SetSequence(ModelBase<DollGrabModel>.Instance.DollGrabClawSequence);
			foreach (FName fname in this.ClawPartMap.Keys)
			{
				ALevelSequenceActor alevelSequenceActor = akuroLevelSequenceActor;
				FName bindingTag = fname;
				TArray<AActor> tarray = new TArray<AActor>
				{
					this.ClawPartMap[fname]
				};
				alevelSequenceActor.SetBindingByTag(bindingTag, tarray, false, false);
			}
			this.ClawAnimSeqActorInternal = akuroLevelSequenceActor;
		}
	}

	// Token: 0x060065D7 RID: 26071 RVA: 0x00199CA8 File Offset: 0x00197EA8
	public void Dispose()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(this.Owner.Entity, EEventName.OnDollGrabMachineClawStateEnd, new Action(this.OnStateExit));
		if (this.ClawAnimSeqActorInternal != null && this.ClawAnimSeqActorInternal.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("DgmClawStateController.Dispose", this.ClawAnimSeqActorInternal, null);
		}
		this.ClawAnimSeqActorInternal = null;
		this.ClawPartMap.Clear();
		this.ClawPartActorList.Clear();
	}

	// Token: 0x060065D8 RID: 26072 RVA: 0x00199D28 File Offset: 0x00197F28
	public void SetTargetState(EDollGrabMachineClawState targetState)
	{
		DgmClawBaseMoveState currentStateInternal = this.CurrentStateInternal;
		EDollGrabMachineClawState? edollGrabMachineClawState = (currentStateInternal != null) ? new EDollGrabMachineClawState?(currentStateInternal.ClawState) : null;
		if (targetState == edollGrabMachineClawState.GetValueOrDefault() & edollGrabMachineClawState != null)
		{
			return;
		}
		this.TargetStateList.Add(targetState);
		if (this.TargetStateList.Count != 1)
		{
			DgmClawBaseMoveState currentStateInternal2 = this.CurrentStateInternal;
			if (currentStateInternal2 == null || currentStateInternal2.ClawState != EDollGrabMachineClawState.Idle)
			{
				return;
			}
		}
		this.ChangeState();
	}

	// Token: 0x060065D9 RID: 26073 RVA: 0x00199DA4 File Offset: 0x00197FA4
	public void ChangeState()
	{
		if (this.TargetStateList.Count == 0)
		{
			return;
		}
		EDollGrabMachineClawState? edollGrabMachineClawState = null;
		if (this.CurrentStateInternal == null)
		{
			edollGrabMachineClawState = new EDollGrabMachineClawState?(this.TargetStateList[0]);
		}
		else
		{
			DgmClawBaseMoveState currentStateInternal = this.CurrentStateInternal;
			edollGrabMachineClawState = ((currentStateInternal != null) ? currentStateInternal.TargetState : null);
		}
		if (edollGrabMachineClawState != null)
		{
			if (this.CurrentStateInternal != null)
			{
				this.CurrentStateInternal.Exit();
				this.LastStateInternal = new EDollGrabMachineClawState?(this.CurrentStateInternal.ClawState);
			}
			if (edollGrabMachineClawState != null)
			{
				switch (edollGrabMachineClawState.GetValueOrDefault())
				{
				case EDollGrabMachineClawState.Idle:
					this.CurrentStateInternal = this.IdleState;
					break;
				case EDollGrabMachineClawState.MovingDown:
					this.CurrentStateInternal = this.MovingDownState;
					break;
				case EDollGrabMachineClawState.MovingUp:
					this.CurrentStateInternal = this.MovingUpState;
					break;
				case EDollGrabMachineClawState.Grabbing:
					this.CurrentStateInternal = this.GrabState;
					break;
				case EDollGrabMachineClawState.Release:
					this.CurrentStateInternal = this.ReleaseState;
					break;
				case EDollGrabMachineClawState.Reset:
					this.CurrentStateInternal = this.ResetState;
					break;
				default:
					goto IL_108;
				}
				if (this.CurrentStateInternal != null)
				{
					this.CurrentStateInternal.Enter();
					Singleton<EventSystem>.Instance.Emit<EDollGrabMachineClawState>(EEventName.OnDollGrabMachineClawStateStart, this.CurrentStateInternal.ClawState);
				}
				DgmClawBaseMoveState currentStateInternal2 = this.CurrentStateInternal;
				EDollGrabMachineClawState? edollGrabMachineClawState2 = (currentStateInternal2 != null) ? new EDollGrabMachineClawState?(currentStateInternal2.ClawState) : null;
				EDollGrabMachineClawState edollGrabMachineClawState3 = this.TargetStateList[0];
				if (edollGrabMachineClawState2.GetValueOrDefault() == edollGrabMachineClawState3 & edollGrabMachineClawState2 != null)
				{
					this.TargetStateList.Shift<EDollGrabMachineClawState>();
					return;
				}
				return;
			}
			IL_108:
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DollGrabMachine;
			ELogAuthor author = ELogAuthor.FJH;
			string message = "[DgmClawStateController] 无效的钩爪状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("nextState", edollGrabMachineClawState);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
	}

	// Token: 0x060065DA RID: 26074 RVA: 0x00199F65 File Offset: 0x00198165
	private void OnStateExit()
	{
		this.ChangeState();
	}

	// Token: 0x170007ED RID: 2029
	// (get) Token: 0x060065DB RID: 26075 RVA: 0x00199F6D File Offset: 0x0019816D
	public EDollGrabMachineClawState? LastState
	{
		get
		{
			return this.LastStateInternal;
		}
	}

	// Token: 0x170007EE RID: 2030
	// (get) Token: 0x060065DC RID: 26076 RVA: 0x00199F75 File Offset: 0x00198175
	public DgmClawBaseMoveState CurrentState
	{
		get
		{
			return this.CurrentStateInternal;
		}
	}

	// Token: 0x060065DD RID: 26077 RVA: 0x00199F80 File Offset: 0x00198180
	[NullableContext(1)]
	private void CollectClawPart(AActor actor)
	{
		TArray<AActor> tarray = new TArray<AActor>();
		actor.GetAttachedActors(ref tarray, true);
		foreach (AActor aactor in tarray)
		{
			foreach (FName key in aactor.Tags)
			{
				if (key.ToString().StartsWith("Claw_"))
				{
					this.ClawPartMap.Add(key, aactor);
					this.ClawPartActorList.Add(aactor);
					break;
				}
			}
			this.CollectClawPart(aactor);
		}
	}

	// Token: 0x060065DE RID: 26078 RVA: 0x0019A044 File Offset: 0x00198244
	[NullableContext(1)]
	public bool CheckActorInClawPart(AActor actor)
	{
		return this.ClawPartActorList.Contains(actor);
	}

	// Token: 0x0400306E RID: 12398
	private SceneItemDollGrabMachineComponent Owner;

	// Token: 0x0400306F RID: 12399
	private DgmClawBaseMoveState CurrentStateInternal;

	// Token: 0x04003070 RID: 12400
	private EDollGrabMachineClawState? LastStateInternal;

	// Token: 0x04003071 RID: 12401
	[Nullable(1)]
	private readonly List<EDollGrabMachineClawState> TargetStateList = new List<EDollGrabMachineClawState>();

	// Token: 0x04003072 RID: 12402
	private DgmClawIdleState IdleState;

	// Token: 0x04003073 RID: 12403
	private DgmClawMovingDownState MovingDownState;

	// Token: 0x04003074 RID: 12404
	private DgmClawMovingUpState MovingUpState;

	// Token: 0x04003075 RID: 12405
	private DgmClawGrabState GrabState;

	// Token: 0x04003076 RID: 12406
	private DgmClawReleaseState ReleaseState;

	// Token: 0x04003077 RID: 12407
	private DgmClawResetState ResetState;

	// Token: 0x04003078 RID: 12408
	private AActor ClawActorInternal;

	// Token: 0x04003079 RID: 12409
	[Nullable(1)]
	private Dictionary<FName, AActor> ClawPartMap = new Dictionary<FName, AActor>();

	// Token: 0x0400307A RID: 12410
	[Nullable(1)]
	private readonly List<AActor> ClawPartActorList = new List<AActor>();

	// Token: 0x0400307B RID: 12411
	private AKuroLevelSequenceActor ClawAnimSeqActorInternal;
}
