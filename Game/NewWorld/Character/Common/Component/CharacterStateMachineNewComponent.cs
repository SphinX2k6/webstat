using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004910 RID: 18704
	[NullableContext(2)]
	[Nullable(0)]
	public class CharacterStateMachineNewComponent : EntityComponent, IStaticVariableResetter
	{
		// Token: 0x06030E1B RID: 200219 RVA: 0x00C1CE5C File Offset: 0x00C1B05C
		static CharacterStateMachineNewComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CharacterStateMachineNewComponent.CreateStaticDefaultValue), new Action(CharacterStateMachineNewComponent.ResetStaticDefaultValue));
		}

		// Token: 0x06030E1C RID: 200220 RVA: 0x00C1CE7B File Offset: 0x00C1B07B
		protected override void OnTick(float delta)
		{
			this.StateMachineGroup.OnTick(delta);
		}

		// Token: 0x06030E1D RID: 200221 RVA: 0x00C1CE89 File Offset: 0x00C1B089
		protected override bool OnInit()
		{
			this.StateMachineGroup = new AiStateMachineGroup(this);
			return true;
		}

		// Token: 0x06030E1E RID: 200222 RVA: 0x00C1CE98 File Offset: 0x00C1B098
		protected override void OnActivate()
		{
			this.StateMachineGroup.OnActivate();
		}

		// Token: 0x06030E1F RID: 200223 RVA: 0x00C1CEA5 File Offset: 0x00C1B0A5
		protected override bool OnEnd()
		{
			AiStateMachineGroup stateMachineGroup = this.StateMachineGroup;
			if (stateMachineGroup != null)
			{
				stateMachineGroup.Clear();
			}
			this.StateMachineGroup = null;
			return true;
		}

		// Token: 0x06030E20 RID: 200224 RVA: 0x00C1CEC0 File Offset: 0x00C1B0C0
		public void OnControl()
		{
			this.StateMachineGroup.OnControl();
		}

		// Token: 0x06030E21 RID: 200225 RVA: 0x00C1CED0 File Offset: 0x00C1B0D0
		[CombatListen(ENotifyMessageId.ChangeStateNotify, true, false)]
		public static void ChangeStateNotify(Entity entity, [Nullable(1)] ChangeStateNotify data, CombatCommon combatCommon = null)
		{
			long messageId = combatCommon.MessageId;
			CharacterStateMachineNewComponent characterStateMachineNewComponent = (entity != null) ? entity.GetComponent<CharacterStateMachineNewComponent>() : null;
			if (characterStateMachineNewComponent == null)
			{
				return;
			}
			characterStateMachineNewComponent.StateMachineGroup.HandleSwitch(data.FsmId, data.FromState, data.ToState, messageId);
		}

		// Token: 0x06030E22 RID: 200226 RVA: 0x00C1CF12 File Offset: 0x00C1B112
		[CombatListen(ENotifyMessageId.ChangeStateConfirmNotify, true, false)]
		public static void ChangeStateConfirmNotify(Entity entity, [Nullable(1)] ChangeStateConfirmNotify data, CombatCommon combatCommon = null)
		{
			CharacterStateMachineNewComponent characterStateMachineNewComponent = (entity != null) ? entity.GetComponent<CharacterStateMachineNewComponent>() : null;
			if (characterStateMachineNewComponent == null)
			{
				return;
			}
			characterStateMachineNewComponent.StateMachineGroup.HandleChangeStateConfirm(data.FsmId, data.State);
		}

		// Token: 0x06030E23 RID: 200227 RVA: 0x00C1CF3C File Offset: 0x00C1B13C
		[CombatListen(ENotifyMessageId.FsmResetNotify, true, false)]
		public static void FsmResetNotify(Entity entity, [Nullable(1)] FsmResetNotify data, CombatCommon combatCommon = null)
		{
			long messageId = combatCommon.MessageId;
			CharacterStateMachineNewComponent characterStateMachineNewComponent = (entity != null) ? entity.GetComponent<CharacterStateMachineNewComponent>() : null;
			if (characterStateMachineNewComponent == null)
			{
				return;
			}
			characterStateMachineNewComponent.StateMachineGroup.ResetStateMachine(data.EntityFsmComponentPb, messageId);
		}

		// Token: 0x06030E24 RID: 200228 RVA: 0x00C1CF72 File Offset: 0x00C1B172
		[CombatListen(ENotifyMessageId.FsmBlackboardNotify, true, false)]
		public static void FsmBlackboardNotify(Entity entity, [Nullable(1)] FsmBlackboardNotify data, CombatCommon combatCommon = null)
		{
			CharacterStateMachineNewComponent characterStateMachineNewComponent = (entity != null) ? entity.GetComponent<CharacterStateMachineNewComponent>() : null;
			if (characterStateMachineNewComponent == null)
			{
				return;
			}
			characterStateMachineNewComponent.StateMachineGroup.HandleBlackboard(data);
		}

		// Token: 0x06030E25 RID: 200229 RVA: 0x00C1CF90 File Offset: 0x00C1B190
		[CombatListen(ENotifyMessageId.FsmCustomBlackboardNotify, true, false)]
		public static void FsmCustomBlackboardNotify(Entity entity, [Nullable(1)] FsmCustomBlackboardNotify data, CombatCommon combatCommon = null)
		{
			CharacterStateMachineNewComponent characterStateMachineNewComponent = (entity != null) ? entity.GetComponent<CharacterStateMachineNewComponent>() : null;
			if (characterStateMachineNewComponent == null)
			{
				return;
			}
			characterStateMachineNewComponent.StateMachineGroup.HandleCustomBlackboard(data);
		}

		// Token: 0x06030E26 RID: 200230 RVA: 0x00C1CFAE File Offset: 0x00C1B1AE
		[CombatListen(ENotifyMessageId.FsmMontageDurationNotify, true, false)]
		public static void FsmMontageDurationNotify(Entity entity, [Nullable(1)] FsmMontageDurationNotify data, CombatCommon combatCommon = null)
		{
			CharacterStateMachineNewComponent characterStateMachineNewComponent = (entity != null) ? entity.GetComponent<CharacterStateMachineNewComponent>() : null;
			if (characterStateMachineNewComponent == null)
			{
				return;
			}
			characterStateMachineNewComponent.StateMachineGroup.SetMontagePredictEndParams(data.MontageHashCode, (float)data.DurationTime);
		}

		// Token: 0x06030E27 RID: 200231 RVA: 0x00C1CFD8 File Offset: 0x00C1B1D8
		public static void CreateStaticDefaultValue()
		{
			CharacterStateMachineNewComponent.EventDrivenOn = true;
		}

		// Token: 0x06030E28 RID: 200232 RVA: 0x00C1CFE0 File Offset: 0x00C1B1E0
		public static void ResetStaticDefaultValue()
		{
			CharacterStateMachineNewComponent.EventDrivenOn = false;
		}

		// Token: 0x06030E29 RID: 200233 RVA: 0x00C1CFE8 File Offset: 0x00C1B1E8
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterStateMachineNewComponent characterStateMachineNewComponent = (CharacterStateMachineNewComponent)componentTemplate;
			if (base.CanResetComponentProperty("StateMachineName"))
			{
				this.StateMachineName = characterStateMachineNewComponent.StateMachineName;
			}
			if (base.CanResetComponentProperty("StateMachineJsonObject"))
			{
				if (characterStateMachineNewComponent.StateMachineJsonObject == null)
				{
					this.StateMachineJsonObject = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CombatStateMachineDefine.Fsm.StateMachineGroup>(this.StateMachineJsonObject), "StateMachineJsonObject"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("StateMachineGroup"))
			{
				if (characterStateMachineNewComponent.StateMachineGroup == null)
				{
					this.StateMachineGroup = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AiStateMachineGroup>(this.StateMachineGroup), "StateMachineGroup"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C19A RID: 115098
		[Nullable(1)]
		public string StateMachineName = "";

		// Token: 0x0401C19B RID: 115099
		public CombatStateMachineDefine.Fsm.StateMachineGroup StateMachineJsonObject;

		// Token: 0x0401C19C RID: 115100
		public AiStateMachineGroup StateMachineGroup;

		// Token: 0x0401C19D RID: 115101
		public static bool EventDrivenOn;
	}
}
