using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070E0 RID: 28896
	[NullableContext(2)]
	[Nullable(0)]
	public class AiStateMachineState
	{
		// Token: 0x060460FF RID: 286975 RVA: 0x01267097 File Offset: 0x01265297
		[NullableContext(1)]
		public AiStateMachineState(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state)
		{
			this.Node = stateMachineNode;
			this.StateData = state;
		}

		// Token: 0x06046100 RID: 286976 RVA: 0x012670AD File Offset: 0x012652AD
		public bool Init()
		{
			return this.OnInit(this.StateData);
		}

		// Token: 0x06046101 RID: 286977 RVA: 0x012670BB File Offset: 0x012652BB
		[NullableContext(1)]
		protected virtual bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			return true;
		}

		// Token: 0x06046102 RID: 286978 RVA: 0x012670BE File Offset: 0x012652BE
		public virtual void OnEnter(AiStateMachineBase lastState = null, long? contextId = null)
		{
		}

		// Token: 0x06046103 RID: 286979 RVA: 0x012670C0 File Offset: 0x012652C0
		public virtual void OnExit(AiStateMachineBase nextState = null, long? contextId = null)
		{
		}

		// Token: 0x06046104 RID: 286980 RVA: 0x012670C2 File Offset: 0x012652C2
		public virtual void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
		}

		// Token: 0x06046105 RID: 286981 RVA: 0x012670C4 File Offset: 0x012652C4
		public virtual void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
		}

		// Token: 0x06046106 RID: 286982 RVA: 0x012670C6 File Offset: 0x012652C6
		public virtual void OnExecuted(long? contextId = null)
		{
		}

		// Token: 0x06046107 RID: 286983 RVA: 0x012670C8 File Offset: 0x012652C8
		public virtual void Tick(float deltaSeconds, long? contextId = null)
		{
			this.OnTick(deltaSeconds, contextId);
		}

		// Token: 0x06046108 RID: 286984 RVA: 0x012670D2 File Offset: 0x012652D2
		protected virtual void OnTick(float deltaSeconds, long? contextId = null)
		{
		}

		// Token: 0x06046109 RID: 286985 RVA: 0x012670D4 File Offset: 0x012652D4
		public void Clear()
		{
			this.OnClear();
			this.Node = null;
		}

		// Token: 0x0604610A RID: 286986 RVA: 0x012670E3 File Offset: 0x012652E3
		protected virtual void OnClear()
		{
		}

		// Token: 0x0604610B RID: 286987 RVA: 0x012670E5 File Offset: 0x012652E5
		[NullableContext(1)]
		public virtual void ToString(StringBuilder outBuilder, int depth = 0)
		{
		}

		// Token: 0x040274E4 RID: 160996
		public AiStateMachineBase Node;

		// Token: 0x040274E5 RID: 160997
		public readonly CombatStateMachineDefine.Fsm.State StateData;
	}
}
