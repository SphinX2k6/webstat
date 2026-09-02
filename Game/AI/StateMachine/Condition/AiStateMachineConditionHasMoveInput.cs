using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070FB RID: 28923
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionHasMoveInput : AiStateMachineCondition
	{
		// Token: 0x060461A3 RID: 287139 RVA: 0x01269AB1 File Offset: 0x01267CB1
		public AiStateMachineConditionHasMoveInput(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461A4 RID: 287140 RVA: 0x01269ABC File Offset: 0x01267CBC
		protected override bool RegisterEvents()
		{
			if (base.RegisterEvents() && this.Node != null && this.Node.Entity != null)
			{
				bool result = false;
				if (!Singleton<EventSystem>.Instance.HasWithTarget(this.Node.Entity, EEventName.OnInputMoveChanged, new Action<bool, bool>(this.OnInputMoveChanged)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget(this.Node.Entity, EEventName.OnInputMoveChanged, new Action<bool, bool>(this.OnInputMoveChanged));
					result = true;
				}
				if (!Singleton<EventSystem>.Instance.HasWithTarget(this.Node.Entity, EEventName.OnFloatingMoveInputChanged, new Action<bool, bool>(this.OnFloatingMoveInputChanged)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget(this.Node.Entity, EEventName.OnFloatingMoveInputChanged, new Action<bool, bool>(this.OnFloatingMoveInputChanged));
					result = true;
				}
				return result;
			}
			return false;
		}

		// Token: 0x060461A5 RID: 287141 RVA: 0x01269B98 File Offset: 0x01267D98
		protected override bool UnregisterEvents()
		{
			if (base.UnregisterEvents() && this.Node != null && this.Node.Entity != null)
			{
				bool result = false;
				if (Singleton<EventSystem>.Instance.HasWithTarget(this.Node.Entity, EEventName.OnInputMoveChanged, new Action<bool, bool>(this.OnInputMoveChanged)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(this.Node.Entity, EEventName.OnInputMoveChanged, new Action<bool, bool>(this.OnInputMoveChanged));
					result = true;
				}
				if (Singleton<EventSystem>.Instance.HasWithTarget(this.Node.Entity, EEventName.OnFloatingMoveInputChanged, new Action<bool, bool>(this.OnFloatingMoveInputChanged)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(this.Node.Entity, EEventName.OnFloatingMoveInputChanged, new Action<bool, bool>(this.OnFloatingMoveInputChanged));
					result = true;
				}
				return result;
			}
			return false;
		}

		// Token: 0x060461A6 RID: 287142 RVA: 0x01269C72 File Offset: 0x01267E72
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.RegisterEvents();
			return true;
		}

		// Token: 0x060461A7 RID: 287143 RVA: 0x01269C7C File Offset: 0x01267E7C
		protected override void OnClear()
		{
			this.UnregisterEvents();
		}

		// Token: 0x060461A8 RID: 287144 RVA: 0x01269C85 File Offset: 0x01267E85
		protected override void OnTick()
		{
			bool resultSelf;
			if (!this.Node.MoveComponent.HasMoveInput)
			{
				CharacterFloatingComponent floatingComponent = this.Node.FloatingComponent;
				resultSelf = (floatingComponent != null && floatingComponent.HasFloatingMoveInput);
			}
			else
			{
				resultSelf = true;
			}
			this.ResultSelf = resultSelf;
		}

		// Token: 0x060461A9 RID: 287145 RVA: 0x01269CBC File Offset: 0x01267EBC
		private void OnInputMoveChanged(bool hadInputMove, bool hasInputMove)
		{
			bool resultSelf;
			if (!this.Node.MoveComponent.HasMoveInput)
			{
				CharacterFloatingComponent floatingComponent = this.Node.FloatingComponent;
				resultSelf = (floatingComponent != null && floatingComponent.HasFloatingMoveInput);
			}
			else
			{
				resultSelf = true;
			}
			this.ResultSelf = resultSelf;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionHasMoveInput", this.Node.Name);
			}
		}

		// Token: 0x060461AA RID: 287146 RVA: 0x01269D38 File Offset: 0x01267F38
		private void OnFloatingMoveInputChanged(bool hadFloatingMoveInput, bool hasFloatingMoveInput)
		{
			bool resultSelf;
			if (!this.Node.MoveComponent.HasMoveInput)
			{
				CharacterFloatingComponent floatingComponent = this.Node.FloatingComponent;
				resultSelf = (floatingComponent != null && floatingComponent.HasFloatingMoveInput);
			}
			else
			{
				resultSelf = true;
			}
			this.ResultSelf = resultSelf;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionHasFloatingMoveInput", this.Node.Name);
			}
		}

		// Token: 0x060461AB RID: 287147 RVA: 0x01269DB1 File Offset: 0x01267FB1
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			outBuilder.Append("有移动输入\n");
		}
	}
}
