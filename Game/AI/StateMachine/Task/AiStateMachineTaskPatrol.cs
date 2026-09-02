using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070DC RID: 28892
	[NullableContext(2)]
	[Nullable(0)]
	public class AiStateMachineTaskPatrol : AiStateMachineTask
	{
		// Token: 0x060460D1 RID: 286929 RVA: 0x01266055 File Offset: 0x01264255
		[NullableContext(1)]
		public AiStateMachineTaskPatrol(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x060460D2 RID: 286930 RVA: 0x0126605F File Offset: 0x0126425F
		[NullableContext(1)]
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Task state)
		{
			this.MoveState = state.TaskPatrol.MoveState;
			this.OpenDebugMode = state.TaskPatrol.OpenDebugMode;
			return true;
		}

		// Token: 0x060460D3 RID: 286931 RVA: 0x01266084 File Offset: 0x01264284
		public override void OnEnter(long? contextId = null)
		{
			this.AiController = this.Node.AiComponent.AiController;
			if (this.AiController == null)
			{
				this.Finish();
				return;
			}
			this.PatrolLogic = this.AiController.AiPatrol;
			AiPatrolController patrolLogic = this.PatrolLogic;
			this.PatrolConfig = ((patrolLogic != null) ? patrolLogic.GetConfig() : null);
			if (this.PatrolConfig == null)
			{
				this.Finish();
				return;
			}
			this.Entity = this.AiController.CharAiDesignComp.Entity;
			this.MoveComp = this.Entity.GetComponent<BaseMoveComponent>();
			this.StateComp = this.Entity.GetComponent<BaseUnifiedStateComponent>();
			this.PatrolComp = this.Entity.GetComponent<CharacterPatrolComponent>();
			this.ActorComp = this.AiController.CharActorComp;
			if (this.PatrolComp == null)
			{
				this.Finish();
				return;
			}
			this.BeginPatrol();
		}

		// Token: 0x060460D4 RID: 286932 RVA: 0x01266160 File Offset: 0x01264360
		public override void OnExit(long? contextId = null)
		{
			if (!this.Node.TaskFinished)
			{
				if (this.PatrolComp != null && this.PatrolConfig != null)
				{
					this.PatrolComp.PausePatrol(this.PatrolConfig.SplineEntityId, "AiStateMachineTaskPatrol");
				}
				this.PatrolFinish();
				this.Finish();
			}
			if (this.MoveComp != null)
			{
				this.MoveComp.StopMoveNew("AiStateMachineTaskPatrol.OnExit");
				this.MoveComp.IsSpecialMove = false;
			}
		}

		// Token: 0x060460D5 RID: 286933 RVA: 0x012661D5 File Offset: 0x012643D5
		private void Finish()
		{
			this.Node.TaskFinished = true;
		}

		// Token: 0x060460D6 RID: 286934 RVA: 0x012661E4 File Offset: 0x012643E4
		private void InitPatrolInfo()
		{
			this.PatrolLogic.GeneratePatrol(true);
			this.PatrolLogic.StartPatrol(true, new Action(this.CallOutside));
			this.PatrolLogic.ResetBaseInfoByMainPoint(this.MoveComp, this.StateComp, this.MoveState);
		}

		// Token: 0x060460D7 RID: 286935 RVA: 0x01266234 File Offset: 0x01264434
		private void CallOutside()
		{
			if (GlobalData.BpEventManager == null)
			{
				return;
			}
			AiPatrolController patrolLogic = this.PatrolLogic;
			PatrolPoint patrolPoint = (patrolLogic != null) ? patrolLogic.PatrolPoint : null;
			if (patrolPoint == null)
			{
				return;
			}
			if (!patrolPoint.IsMain)
			{
				return;
			}
			GlobalData.BpEventManager.AI巡逻达到样条点.Broadcast(this.ActorComp.Actor, this.PatrolLogic.PatrolIndex);
		}

		// Token: 0x060460D8 RID: 286936 RVA: 0x01266290 File Offset: 0x01264490
		private void MoveToPatrolPoint()
		{
			AiStateMachineTaskPatrol.<>c__DisplayClass17_0 CS$<>8__locals1 = new AiStateMachineTaskPatrol.<>c__DisplayClass17_0();
			CS$<>8__locals1.<>4__this = this;
			AiStateMachineTaskPatrol.<>c__DisplayClass17_0 CS$<>8__locals2 = CS$<>8__locals1;
			AiPatrolController patrolLogic = this.PatrolLogic;
			CS$<>8__locals2.curPoint = ((patrolLogic != null) ? patrolLogic.PatrolPoint : null);
			if (CS$<>8__locals1.curPoint == null)
			{
				return;
			}
			if (this.PatrolComp.HasPatrolRecord(null))
			{
				this.PatrolComp.ResumePatrol(this.PatrolConfig.SplineEntityId, "AiStateMachineTaskPatrol");
				return;
			}
			Action<int> onArrivePointHandle = delegate(int _)
			{
				int lastPointRawIndex = CS$<>8__locals1.<>4__this.PatrolComp.GetLastPointRawIndex();
				if (lastPointRawIndex != -1)
				{
					CS$<>8__locals1.<>4__this.PatrolLogic.SetPatrolIndex(lastPointRawIndex);
				}
				if (CS$<>8__locals1.curPoint.IsMain)
				{
					CS$<>8__locals1.<>4__this.CallOutside();
				}
			};
			Action<ELevelEventState> onPatrolEndHandle = delegate(ELevelEventState result)
			{
				if (result == ELevelEventState.Success)
				{
					CS$<>8__locals1.<>4__this.PatrolFinish();
				}
				CS$<>8__locals1.<>4__this.Finish();
			};
			PatrolParamsImpl config = new PatrolParamsImpl
			{
				DebugMode = new bool?(this.OpenDebugMode),
				StartMode = new EPatrolStartMode?(EPatrolStartMode.NearestPoint),
				ReturnFalseWhenNavigationFailed = new bool?(false),
				OnArrivePointHandle = onArrivePointHandle,
				OnPatrolEndHandle = onPatrolEndHandle
			};
			this.PatrolComp.StartPatrol(this.PatrolConfig.SplineEntityId, config);
		}

		// Token: 0x060460D9 RID: 286937 RVA: 0x0126636C File Offset: 0x0126456C
		private void PatrolFinish()
		{
			this.CallOutside();
			AiPatrolController patrolLogic = this.PatrolLogic;
			if (patrolLogic == null)
			{
				return;
			}
			patrolLogic.PatrolFinish();
		}

		// Token: 0x060460DA RID: 286938 RVA: 0x01266384 File Offset: 0x01264584
		private void BeginPatrol()
		{
			if (this.PatrolConfig.ContainZ && this.MoveComp != null)
			{
				CharacterActorComponent actorComp = this.ActorComp;
				if (actorComp != null)
				{
					actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Flying,
						Context = "[AiStateMachineTaskPatrol.BeginPatrol]"
					});
				}
			}
			this.InitPatrolInfo();
			AiPatrolController patrolLogic = this.PatrolLogic;
			if (((patrolLogic != null) ? patrolLogic.PatrolPoint : null) == null)
			{
				this.Finish();
				return;
			}
			this.MoveToPatrolPoint();
			if (this.AiController.AiPatrol.StartWithInversePath != null)
			{
				this.AiController.AiPatrol.StartWithInversePath = null;
			}
		}

		// Token: 0x040274C5 RID: 160965
		private AiPatrolController PatrolLogic;

		// Token: 0x040274C6 RID: 160966
		private AiPatrolConfig PatrolConfig;

		// Token: 0x040274C7 RID: 160967
		private Entity Entity;

		// Token: 0x040274C8 RID: 160968
		private BaseMoveComponent MoveComp;

		// Token: 0x040274C9 RID: 160969
		private BaseUnifiedStateComponent StateComp;

		// Token: 0x040274CA RID: 160970
		private CharacterPatrolComponent PatrolComp;

		// Token: 0x040274CB RID: 160971
		private CharacterActorComponent ActorComp;

		// Token: 0x040274CC RID: 160972
		private AiController AiController;

		// Token: 0x040274CD RID: 160973
		public int MoveState;

		// Token: 0x040274CE RID: 160974
		public bool OpenDebugMode;
	}
}
