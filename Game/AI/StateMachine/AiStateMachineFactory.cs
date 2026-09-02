using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.AI.StateMachine.Action;
using CSharpScript.Game.AI.StateMachine.Condition;
using CSharpScript.Game.AI.StateMachine.State;
using CSharpScript.Game.AI.StateMachine.Task;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine
{
	// Token: 0x020070CF RID: 28879
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineFactory
	{
		// Token: 0x0604603B RID: 286779 RVA: 0x01260F4C File Offset: 0x0125F14C
		[return: Nullable(2)]
		public AiStateMachineTask CreateTask(AiStateMachineBase node, CombatStateMachineDefine.Fsm.Task task)
		{
			AiStateMachineTask aiStateMachineTask = null;
			try
			{
				CombatStateMachineDefine.Fsm.ETaskType type = (CombatStateMachineDefine.Fsm.ETaskType)task.Type;
				if (type - CombatStateMachineDefine.Fsm.ETaskType.TaskSkill > 1)
				{
					if (type != CombatStateMachineDefine.Fsm.ETaskType.TaskRandomMontage)
					{
						switch (type)
						{
						case CombatStateMachineDefine.Fsm.ETaskType.TaskLeaveFight:
							aiStateMachineTask = new AiStateMachineTaskLeaveFight(node, task);
							break;
						case CombatStateMachineDefine.Fsm.ETaskType.TaskMontage:
							aiStateMachineTask = new AiStateMachineTaskMontage(node, task);
							break;
						case CombatStateMachineDefine.Fsm.ETaskType.TaskMoveToTarget:
							aiStateMachineTask = new AiStateMachineTaskMoveToTarget(node, task);
							break;
						case CombatStateMachineDefine.Fsm.ETaskType.TaskPatrol:
							aiStateMachineTask = new AiStateMachineTaskPatrol(node, task);
							break;
						case CombatStateMachineDefine.Fsm.ETaskType.TaskBeHitMontage:
							aiStateMachineTask = new AiStateMachineTaskBeHitMontage(node, task);
							break;
						case CombatStateMachineDefine.Fsm.ETaskType.TaskGroupPatrol:
							aiStateMachineTask = new AiStateMachineTaskGroupPatrol(node, task);
							break;
						case CombatStateMachineDefine.Fsm.ETaskType.TaskGroupPerform:
							aiStateMachineTask = new AiStateMachineTaskGroupPerform(node, task);
							break;
						default:
							aiStateMachineTask = new AiStateMachineTask(node, task);
							break;
						}
					}
					else
					{
						aiStateMachineTask = new AiStateMachineTaskRandomMontage(node, task);
					}
				}
				else
				{
					aiStateMachineTask = new AiStateMachineTaskSkill(node, task);
				}
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				AiStateMachineGroup owner = node.Owner;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 3);
				defaultInterpolatedStringHandler.AppendLiteral("初始化主状态失败异常 [");
				defaultInterpolatedStringHandler.AppendFormatted(node.Name);
				defaultInterpolatedStringHandler.AppendLiteral("|");
				defaultInterpolatedStringHandler.AppendFormatted<int>(node.Uuid);
				defaultInterpolatedStringHandler.AppendLiteral("]\nerror:");
				defaultInterpolatedStringHandler.AppendFormatted(message);
				owner.PushErrorMessage(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (aiStateMachineTask != null)
			{
				aiStateMachineTask.Init();
			}
			return aiStateMachineTask;
		}

		// Token: 0x0604603C RID: 286780 RVA: 0x0126107C File Offset: 0x0125F27C
		[return: Nullable(2)]
		public AiStateMachineState CreateState(AiStateMachineBase node, CombatStateMachineDefine.Fsm.State state)
		{
			AiStateMachineState aiStateMachineState = null;
			try
			{
				CombatStateMachineDefine.Fsm.EStateType type = (CombatStateMachineDefine.Fsm.EStateType)state.Type;
				if (type != CombatStateMachineDefine.Fsm.EStateType.BindBuff)
				{
					if (type != CombatStateMachineDefine.Fsm.EStateType.BindTag)
					{
						switch (type)
						{
						case CombatStateMachineDefine.Fsm.EStateType.BindAiHateConfig:
							aiStateMachineState = new AiStateMachineStateAiHateConfig(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindAiSenseEnable:
							aiStateMachineState = new AiStateMachineStateAiSenseEnable(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindCue:
							aiStateMachineState = new AiStateMachineStateCue(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindDisableActor:
							aiStateMachineState = new AiStateMachineStateDisableActor(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindBoneVisible:
							aiStateMachineState = new AiStateMachineStateBoneVisible(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindMeshVisible:
							aiStateMachineState = new AiStateMachineStateMeshVisible(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindBoneCollision:
							aiStateMachineState = new AiStateMachineStateBoneCollision(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindPartPanelVisible:
							aiStateMachineState = new AiStateMachineStatePartPanelVisible(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindDeathMontage:
							aiStateMachineState = new AiStateMachineStateDeathMontage(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindPalsy:
							aiStateMachineState = new AiStateMachineStatePalsy(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindCollisionChannel:
							aiStateMachineState = new AiStateMachineStateCollisionChannel(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindDisableCollision:
							aiStateMachineState = new AiStateMachineStateDisableCollision(node, state);
							goto IL_102;
						case CombatStateMachineDefine.Fsm.EStateType.BindDeathMontageByTag:
							aiStateMachineState = new AiStateMachineStateDeathMontageByTag(node, state);
							goto IL_102;
						}
						aiStateMachineState = new AiStateMachineState(node, state);
					}
					else
					{
						aiStateMachineState = new AiStateMachineStateTag(node, state);
					}
				}
				else
				{
					aiStateMachineState = new AiStateMachineStateBuff(node, state);
				}
				IL_102:;
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				AiStateMachineGroup owner = node.Owner;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 3);
				defaultInterpolatedStringHandler.AppendLiteral("初始化节点绑定状态异常 [");
				defaultInterpolatedStringHandler.AppendFormatted(node.Name);
				defaultInterpolatedStringHandler.AppendLiteral("|");
				defaultInterpolatedStringHandler.AppendFormatted<int>(node.Uuid);
				defaultInterpolatedStringHandler.AppendLiteral("]\nerror:");
				defaultInterpolatedStringHandler.AppendFormatted(message);
				owner.PushErrorMessage(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (aiStateMachineState != null)
			{
				aiStateMachineState.Init();
			}
			return aiStateMachineState;
		}

		// Token: 0x0604603D RID: 286781 RVA: 0x01261220 File Offset: 0x0125F420
		[return: Nullable(2)]
		public AiStateMachineAction CreateAction(AiStateMachineBase node, CombatStateMachineDefine.Fsm.Action action)
		{
			AiStateMachineAction aiStateMachineAction = null;
			try
			{
				CombatStateMachineDefine.Fsm.EActionType type = (CombatStateMachineDefine.Fsm.EActionType)action.Type;
				if (type <= CombatStateMachineDefine.Fsm.EActionType.ActionRemoveBuff)
				{
					if (type == CombatStateMachineDefine.Fsm.EActionType.ActionAddBuff)
					{
						aiStateMachineAction = new AiStateMachineActionAddBuff(node, action);
						goto IL_138;
					}
					if (type == CombatStateMachineDefine.Fsm.EActionType.ActionRemoveBuff)
					{
						aiStateMachineAction = new AiStateMachineActionRemoveBuff(node, action);
						goto IL_138;
					}
				}
				else
				{
					switch (type)
					{
					case CombatStateMachineDefine.Fsm.EActionType.ActionResetStatus:
						aiStateMachineAction = new AiStateMachineActionResetStatus(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionEnterFight:
						aiStateMachineAction = new AiStateMachineActionEnterFight(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionCastSkillByName:
					case CombatStateMachineDefine.Fsm.EActionType.ActionCancelSkillByName:
					case CombatStateMachineDefine.Fsm.EActionType.ActionActivatePart:
					case CombatStateMachineDefine.Fsm.EActionType.ActionDispatchEvent:
					case (CombatStateMachineDefine.Fsm.EActionType)16:
					case (CombatStateMachineDefine.Fsm.EActionType)17:
					case (CombatStateMachineDefine.Fsm.EActionType)18:
						break;
					case CombatStateMachineDefine.Fsm.EActionType.ActionInstChangeStateTag:
						aiStateMachineAction = new AiStateMachineActionChangeInstState(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionResetPart:
						aiStateMachineAction = new AiStateMachineActionResetPart(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionActivateSkillGroup:
						aiStateMachineAction = new AiStateMachineActionActivateSkillGroup(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionSetRageFullAttribute:
						aiStateMachineAction = new AiStateMachineActionSetRageFullAttribute(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionAddTagCount:
						aiStateMachineAction = new AiStateMachineActionAddTagCount(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionRemoveTagCount:
						aiStateMachineAction = new AiStateMachineActionRemoveTagCount(node, action);
						goto IL_138;
					case CombatStateMachineDefine.Fsm.EActionType.ActionDispatchGameEvent:
						aiStateMachineAction = new AiStateMachineActionDispatchGameEvent(node, action);
						goto IL_138;
					default:
						switch (type)
						{
						case CombatStateMachineDefine.Fsm.EActionType.ActionCue:
							aiStateMachineAction = new AiStateMachineActionCue(node, action);
							goto IL_138;
						case CombatStateMachineDefine.Fsm.EActionType.ActionStopMontage:
							aiStateMachineAction = new AiStateMachineActionStopMontage(node, action);
							goto IL_138;
						case CombatStateMachineDefine.Fsm.EActionType.ActionExitHit:
							aiStateMachineAction = new AiStateMachineActionExitHit(node, action);
							goto IL_138;
						case CombatStateMachineDefine.Fsm.EActionType.ActionSendGameplayEvent:
							aiStateMachineAction = new AiStateMachineActionSendGameplayEvent(node, action);
							goto IL_138;
						case CombatStateMachineDefine.Fsm.EActionType.ActionCameraLockOn:
							aiStateMachineAction = new AiStateMachineActionCameraLockOn(node, action);
							goto IL_138;
						}
						break;
					}
				}
				aiStateMachineAction = new AiStateMachineAction(node, action);
				IL_138:;
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				AiStateMachineGroup owner = node.Owner;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 3);
				defaultInterpolatedStringHandler.AppendLiteral("初始化节点Action失败，初始化异常，node[");
				defaultInterpolatedStringHandler.AppendFormatted(node.Name);
				defaultInterpolatedStringHandler.AppendLiteral("|");
				defaultInterpolatedStringHandler.AppendFormatted<int>(node.Uuid);
				defaultInterpolatedStringHandler.AppendLiteral("]\nerror:");
				defaultInterpolatedStringHandler.AppendFormatted(message);
				owner.PushErrorMessage(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (aiStateMachineAction != null)
			{
				aiStateMachineAction.Init();
			}
			return aiStateMachineAction;
		}

		// Token: 0x0604603E RID: 286782 RVA: 0x012613F8 File Offset: 0x0125F5F8
		public AiStateMachineCondition CreateCondition(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index, [Nullable(2)] AiStateMachineCondition parentCondition = null)
		{
			AiStateMachineCondition aiStateMachineCondition = null;
			try
			{
				CombatStateMachineDefine.Fsm.EConditionType type = (CombatStateMachineDefine.Fsm.EConditionType)condition.Type;
				switch (type)
				{
				case CombatStateMachineDefine.Fsm.EConditionType.CondAnd:
					aiStateMachineCondition = new AiStateMachineConditionAnd(transition, condition, index);
					goto IL_1B2;
				case CombatStateMachineDefine.Fsm.EConditionType.CondOr:
					aiStateMachineCondition = new AiStateMachineConditionOr(transition, condition, index);
					goto IL_1B2;
				case (CombatStateMachineDefine.Fsm.EConditionType)3:
					break;
				case CombatStateMachineDefine.Fsm.EConditionType.CondTrue:
					aiStateMachineCondition = new AiStateMachineConditionTrue(transition, condition, index);
					goto IL_1B2;
				default:
					switch (type)
					{
					case CombatStateMachineDefine.Fsm.EConditionType.CondTag:
						aiStateMachineCondition = new AiStateMachineConditionTag(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondBBValueCompare:
					case CombatStateMachineDefine.Fsm.EConditionType.CondAttrCompare:
					case (CombatStateMachineDefine.Fsm.EConditionType)21:
					case CombatStateMachineDefine.Fsm.EConditionType.CondWaitClient:
					case CombatStateMachineDefine.Fsm.EConditionType.CondCheckPartActivated:
					case CombatStateMachineDefine.Fsm.EConditionType.CondListenEvent:
					case (CombatStateMachineDefine.Fsm.EConditionType)30:
						break;
					case CombatStateMachineDefine.Fsm.EConditionType.CondAttribute:
						aiStateMachineCondition = new AiStateMachineConditionAttribute(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondAttributeRate:
						aiStateMachineCondition = new AiStateMachineConditionAttributeRate(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondCheckState:
					case CombatStateMachineDefine.Fsm.EConditionType.CondCheckStateByName:
						aiStateMachineCondition = new AiStateMachineConditionCheckState(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondHate:
						aiStateMachineCondition = new AiStateMachineConditionHate(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondTimer:
						aiStateMachineCondition = new AiStateMachineConditionTimer(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondInstStateChange:
						aiStateMachineCondition = new AiStateMachineConditionCheckInstState(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondBuffStack:
						aiStateMachineCondition = new AiStateMachineConditionBuffStack(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondPartLife:
						aiStateMachineCondition = new AiStateMachineConditionPartLife(transition, condition, index);
						goto IL_1B2;
					case CombatStateMachineDefine.Fsm.EConditionType.CondCheckLastState:
						aiStateMachineCondition = new AiStateMachineConditionCheckLastState(transition, condition, index);
						goto IL_1B2;
					default:
						switch (type)
						{
						case CombatStateMachineDefine.Fsm.EConditionType.CondTaskFinish:
							aiStateMachineCondition = new AiStateMachineConditionTaskFinish(transition, condition, index);
							goto IL_1B2;
						case CombatStateMachineDefine.Fsm.EConditionType.CondMontageTimeRemaining:
							aiStateMachineCondition = new AiStateMachineConditionMontageTimeRemaining(transition, condition, index);
							goto IL_1B2;
						case CombatStateMachineDefine.Fsm.EConditionType.CondListenBeHit:
							aiStateMachineCondition = new AiStateMachineConditionListenBeHit(transition, condition, index);
							goto IL_1B2;
						case CombatStateMachineDefine.Fsm.EConditionType.CondHasMoveInput:
							aiStateMachineCondition = new AiStateMachineConditionHasMoveInput(transition, condition, index);
							goto IL_1B2;
						case CombatStateMachineDefine.Fsm.EConditionType.CondMontageTimeElapsing:
							aiStateMachineCondition = new AiStateMachineConditionMontageTimeElapsing(transition, condition, index);
							goto IL_1B2;
						case CombatStateMachineDefine.Fsm.EConditionType.CondCheckGroupPatrol:
							aiStateMachineCondition = new AiStateMachineConditionCheckGroupPatrol(transition, condition, index);
							goto IL_1B2;
						case CombatStateMachineDefine.Fsm.EConditionType.CondCheckPositionState:
							aiStateMachineCondition = new AiStateMachineConditionCheckPositionState(transition, condition, index);
							goto IL_1B2;
						case CombatStateMachineDefine.Fsm.EConditionType.CondCheckGroupPerform:
							aiStateMachineCondition = new AiStateMachineConditionCheckGroupPerform(transition, condition, index);
							goto IL_1B2;
						}
						break;
					}
					break;
				}
				aiStateMachineCondition = new AiStateMachineCondition(transition, condition, index);
				IL_1B2:;
			}
			catch (Exception ex)
			{
				string message = ex.Message;
				AiStateMachineGroup owner = transition.Node.Owner;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 5);
				defaultInterpolatedStringHandler.AppendLiteral("初始化节点条件失败，初始化异常，node[");
				defaultInterpolatedStringHandler.AppendFormatted(transition.Node.Name);
				defaultInterpolatedStringHandler.AppendLiteral("|");
				defaultInterpolatedStringHandler.AppendFormatted<int>(transition.Node.Uuid);
				defaultInterpolatedStringHandler.AppendLiteral("]，name[");
				defaultInterpolatedStringHandler.AppendFormatted(condition.Name);
				defaultInterpolatedStringHandler.AppendLiteral("]，type[");
				defaultInterpolatedStringHandler.AppendFormatted<int>(condition.Type);
				defaultInterpolatedStringHandler.AppendLiteral("]\nerror:");
				defaultInterpolatedStringHandler.AppendFormatted(message);
				owner.PushErrorMessage(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (aiStateMachineCondition != null)
			{
				aiStateMachineCondition.Init(parentCondition);
			}
			return aiStateMachineCondition;
		}
	}
}
