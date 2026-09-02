using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CombatMessage;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004902 RID: 18690
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterLogicStateSyncComponent : EntityComponent
	{
		// Token: 0x06030CF5 RID: 199925 RVA: 0x00C1208C File Offset: 0x00C1028C
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.CheckGetComponent<CharacterActorComponent>();
			this.UnifiedStateComp = base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>();
			this.IsRole = base.Entity.GetComponent<CreatureDataComponent>().IsRole();
			Singleton<EventSystem>.Instance.AddWithTarget<bool>(base.Entity, EEventName.CharSwitchControl, new Action<bool>(this.OnSwitchControl));
			if (this.IsRole)
			{
				Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnRoleGoUp, new Action(this.OnRoleGoUp));
			}
			return true;
		}

		// Token: 0x06030CF6 RID: 199926 RVA: 0x00C1211C File Offset: 0x00C1031C
		protected override void OnActivate()
		{
			ControllerBase<CombatMessageController>.Instance.RegisterAfterTick(this, new Action<float>(this.ForceAfterTickInternal));
			CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
			EntityComponentPb entityComponentPb;
			this.LogicStateComponentPb = (component.ComponentDataMap.TryGetValue("LogicStateComponentPb", out entityComponentPb) ? ((entityComponentPb != null) ? entityComponentPb.LogicStateComponentPb : null) : null);
			if (this.ActorComp.IsAutonomousProxy)
			{
				this.LogicStateInitRequest();
				this.Inited = true;
			}
			else if (this.LogicStateComponentPb != null)
			{
				this.InitWithPb(this.LogicStateComponentPb);
			}
			this.LogicStates = new int[4];
			this.LastLogicStates = new int[4];
			this.LogicStates[0] = (int)this.UnifiedStateComp.PositionState;
			this.LogicStates[1] = (int)this.UnifiedStateComp.MoveState;
			this.LogicStates[2] = (int)this.UnifiedStateComp.DirectionState;
			this.LogicStates[3] = (int)this.UnifiedStateComp.PositionSubState;
			for (int i = 0; i < this.LogicStates.Length; i++)
			{
				this.LastLogicStates[i] = this.LogicStates[i];
			}
		}

		// Token: 0x06030CF7 RID: 199927 RVA: 0x00C1222C File Offset: 0x00C1042C
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(base.Entity, EEventName.CharSwitchControl, new Action<bool>(this.OnSwitchControl));
			if (Singleton<EventSystem>.Instance.HasWithTarget(base.Entity, EEventName.OnRoleGoUp, new Action(this.OnRoleGoUp)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnRoleGoUp, new Action(this.OnRoleGoUp));
			}
			ControllerBase<CombatMessageController>.Instance.UnregisterAfterTick(this);
			return true;
		}

		// Token: 0x06030CF8 RID: 199928 RVA: 0x00C122AC File Offset: 0x00C104AC
		private void LogicStateInitRequest()
		{
			LogicStateInitPush logicStateInitPush = LogicStateInitPush.Create();
			if (this.IsRole)
			{
				logicStateInitPush.ClientEntityId = Singleton<MathUtils>.Instance.NumberToLong(this.GetClientEntityId());
			}
			logicStateInitPush.InitData = LogicStateComponentPb.Create();
			logicStateInitPush.InitData.PositionState = (int)this.UnifiedStateComp.PositionState;
			logicStateInitPush.InitData.MoveState = (int)this.UnifiedStateComp.MoveState;
			logicStateInitPush.InitData.DirectionState = (int)this.UnifiedStateComp.DirectionState;
			logicStateInitPush.InitData.PositionSubState = (int)this.UnifiedStateComp.PositionSubState;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.LogicStateInitPush, base.Entity, logicStateInitPush, null, null, null);
		}

		// Token: 0x06030CF9 RID: 199929 RVA: 0x00C12374 File Offset: 0x00C10574
		private void InitWithPb(LogicStateComponentPb data)
		{
			this.SetLogicState(global::ELogicStateType.CharPositionState, data.PositionState);
			this.SetLogicState(global::ELogicStateType.CharMoveState, data.MoveState);
			this.SetLogicState(global::ELogicStateType.CharDirectionState, data.DirectionState);
			this.SetLogicState(global::ELogicStateType.CharPositionSubState, data.PositionSubState);
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.LogicState;
			Entity entity = base.Entity;
			string message = "初始化逻辑状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("states", new int[]
			{
				data.PositionState,
				data.MoveState,
				data.DirectionState,
				data.PositionSubState
			});
			instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.Inited = true;
		}

		// Token: 0x06030CFA RID: 199930 RVA: 0x00C12410 File Offset: 0x00C10610
		private void SetLogicState(global::ELogicStateType stateType, int value)
		{
			switch (stateType)
			{
			case global::ELogicStateType.CharPositionState:
				this.UnifiedStateComp.SetPositionStateHandle((global::ECharPositionState)value);
				return;
			case global::ELogicStateType.CharMoveState:
				this.UnifiedStateComp.SetMoveStateHandle((global::ECharMoveState)value);
				return;
			case global::ELogicStateType.CharDirectionState:
				this.UnifiedStateComp.SetDirectionStateHandle((ECharDirectionState)value);
				return;
			case global::ELogicStateType.CharPositionSubState:
				this.UnifiedStateComp.SetPositionSubStateHandle((global::ECharPositionSubState)value);
				return;
			default:
				return;
			}
		}

		// Token: 0x06030CFB RID: 199931 RVA: 0x00C12467 File Offset: 0x00C10667
		public void OnSwitchControl(bool control)
		{
			if (control && !this.Inited)
			{
				this.LogicStateInitRequest();
				this.Inited = true;
			}
		}

		// Token: 0x06030CFC RID: 199932 RVA: 0x00C12481 File Offset: 0x00C10681
		private void OnRoleGoUp()
		{
			this.ForcePush = true;
		}

		// Token: 0x06030CFD RID: 199933 RVA: 0x00C1248A File Offset: 0x00C1068A
		[NullableContext(2)]
		[CombatListen(ENotifyMessageId.LogicStateInitNotify, true, false)]
		public static void LogicStateInitNotify(Entity entity, [Nullable(1)] LogicStateInitNotify data, CombatCommon combatCommon = null)
		{
			CharacterLogicStateSyncComponent characterLogicStateSyncComponent = (entity != null) ? entity.GetComponent<CharacterLogicStateSyncComponent>() : null;
			if (characterLogicStateSyncComponent == null)
			{
				return;
			}
			characterLogicStateSyncComponent.InitWithPb(data.InitData);
		}

		// Token: 0x06030CFE RID: 199934 RVA: 0x00C124A8 File Offset: 0x00C106A8
		private void ForceAfterTickInternal(float deltaTime)
		{
			if (!this.ActorComp.IsMoveAutonomousProxy)
			{
				return;
			}
			CharacterUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
			if (unifiedStateComp == null)
			{
				return;
			}
			bool flag = false;
			this.LogicStates[0] = (int)unifiedStateComp.PositionState;
			this.LogicStates[1] = (int)unifiedStateComp.MoveState;
			this.LogicStates[2] = (int)unifiedStateComp.DirectionState;
			this.LogicStates[3] = (int)unifiedStateComp.PositionSubState;
			for (int i = 0; i < this.LogicStates.Length; i++)
			{
				if (this.LogicStates[i] != this.LastLogicStates[i])
				{
					flag = true;
					break;
				}
			}
			if (flag || this.ForcePush)
			{
				this.ForcePush = false;
				SwitchLogicStatePush switchLogicStatePush = SwitchLogicStatePush.Create();
				switchLogicStatePush.States = LogicStateComponentPb.Create();
				if (this.IsRole)
				{
					switchLogicStatePush.ClientEntityId = Singleton<MathUtils>.Instance.NumberToLong(this.GetClientEntityId());
				}
				this.LastLogicStates[0] = (switchLogicStatePush.States.PositionState = (int)unifiedStateComp.PositionState);
				this.LastLogicStates[1] = (switchLogicStatePush.States.MoveState = (int)unifiedStateComp.MoveState);
				this.LastLogicStates[2] = (switchLogicStatePush.States.DirectionState = (int)unifiedStateComp.DirectionState);
				this.LastLogicStates[3] = (switchLogicStatePush.States.PositionSubState = (int)unifiedStateComp.PositionSubState);
				Singleton<CombatNet>.Instance.Send(EPushMessageId.SwitchLogicStatePush, base.Entity, switchLogicStatePush, null, null, null);
			}
		}

		// Token: 0x06030CFF RID: 199935 RVA: 0x00C12624 File Offset: 0x00C10824
		private long GetClientEntityId()
		{
			CharacterActorComponent actorComp = this.ActorComp;
			int? num;
			if (actorComp == null)
			{
				num = null;
			}
			else
			{
				CreatureDataComponent creatureData = actorComp.CreatureData;
				num = ((creatureData != null) ? new int?(creatureData.GetPlayerId()) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(valueOrDefault);
			long? num3;
			if (teamPlayerData == null)
			{
				num3 = null;
			}
			else
			{
				SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
				if (currentGroup == null)
				{
					num3 = null;
				}
				else
				{
					SceneTeamRole currentRole = currentGroup.GetCurrentRole();
					num3 = ((currentRole != null) ? new long?(currentRole.CreatureDataId) : null);
				}
			}
			long? num4 = num3;
			return num4.GetValueOrDefault();
		}

		// Token: 0x06030D00 RID: 199936 RVA: 0x00C126C4 File Offset: 0x00C108C4
		[NullableContext(2)]
		[CombatListen(ENotifyMessageId.SwitchLogicStateNotify, true, false)]
		public static void SwitchLogicStateNotify(Entity entity, [Nullable(1)] SwitchLogicStateNotify data, CombatCommon combatCommon = null)
		{
			CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
			if (characterActorComponent != null && characterActorComponent.IsMoveAutonomousProxy)
			{
				return;
			}
			CharacterLogicStateSyncComponent characterLogicStateSyncComponent = (entity != null) ? entity.GetComponent<CharacterLogicStateSyncComponent>() : null;
			if (characterLogicStateSyncComponent != null && data.States != null)
			{
				CharacterLogicStateSyncComponent.TransferNotifyState(characterLogicStateSyncComponent, 0, data.States.PositionState);
				CharacterLogicStateSyncComponent.TransferNotifyState(characterLogicStateSyncComponent, 1, data.States.MoveState);
				CharacterLogicStateSyncComponent.TransferNotifyState(characterLogicStateSyncComponent, 2, data.States.DirectionState);
				CharacterLogicStateSyncComponent.TransferNotifyState(characterLogicStateSyncComponent, 3, data.States.PositionSubState);
			}
		}

		// Token: 0x06030D01 RID: 199937 RVA: 0x00C1274C File Offset: 0x00C1094C
		private static void TransferNotifyState(CharacterLogicStateSyncComponent logicStateSyncComp, int stateType, int state)
		{
			if (state == 0)
			{
				return;
			}
			logicStateSyncComp.SetLogicState((global::ELogicStateType)stateType, (state == 127) ? 0 : state);
		}

		// Token: 0x06030D02 RID: 199938 RVA: 0x00C12764 File Offset: 0x00C10964
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterLogicStateSyncComponent characterLogicStateSyncComponent = (CharacterLogicStateSyncComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterLogicStateSyncComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UnifiedStateComp"))
			{
				if (characterLogicStateSyncComponent.UnifiedStateComp == null)
				{
					this.UnifiedStateComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComp), "UnifiedStateComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LogicStateComponentPb"))
			{
				if (characterLogicStateSyncComponent.LogicStateComponentPb == null)
				{
					this.LogicStateComponentPb = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LogicStateComponentPb>(this.LogicStateComponentPb), "LogicStateComponentPb"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LogicStates"))
			{
				if (characterLogicStateSyncComponent.LogicStates == null)
				{
					this.LogicStates = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<int[]>(this.LogicStates), "LogicStates"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastLogicStates"))
			{
				if (characterLogicStateSyncComponent.LastLogicStates == null)
				{
					this.LastLogicStates = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<int[]>(this.LastLogicStates), "LastLogicStates"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsRole"))
			{
				this.IsRole = characterLogicStateSyncComponent.IsRole;
			}
			if (base.CanResetComponentProperty("Inited"))
			{
				this.Inited = characterLogicStateSyncComponent.Inited;
			}
			if (base.CanResetComponentProperty("ForcePush"))
			{
				this.ForcePush = characterLogicStateSyncComponent.ForcePush;
			}
			return true;
		}

		// Token: 0x0401C0CE RID: 114894
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C0CF RID: 114895
		[Nullable(2)]
		private CharacterUnifiedStateComponent UnifiedStateComp;

		// Token: 0x0401C0D0 RID: 114896
		[Nullable(2)]
		private LogicStateComponentPb LogicStateComponentPb;

		// Token: 0x0401C0D1 RID: 114897
		private int[] LogicStates = Array.Empty<int>();

		// Token: 0x0401C0D2 RID: 114898
		private int[] LastLogicStates = Array.Empty<int>();

		// Token: 0x0401C0D3 RID: 114899
		private bool IsRole;

		// Token: 0x0401C0D4 RID: 114900
		public bool Inited;

		// Token: 0x0401C0D5 RID: 114901
		private bool ForcePush;
	}
}
