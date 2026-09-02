using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007107 RID: 28935
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineAction
	{
		// Token: 0x060461F7 RID: 287223 RVA: 0x0126B27C File Offset: 0x0126947C
		public AiStateMachineAction(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action)
		{
			this.Node = stateMachineNode;
			this.ActionData = action;
		}

		// Token: 0x060461F8 RID: 287224 RVA: 0x0126B292 File Offset: 0x01269492
		public virtual void DoAction(long? contextId = null)
		{
		}

		// Token: 0x060461F9 RID: 287225 RVA: 0x0126B294 File Offset: 0x01269494
		public bool Init()
		{
			return this.OnInit(this.ActionData);
		}

		// Token: 0x060461FA RID: 287226 RVA: 0x0126B2A2 File Offset: 0x012694A2
		protected virtual bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			return true;
		}

		// Token: 0x060461FB RID: 287227 RVA: 0x0126B2A5 File Offset: 0x012694A5
		public void Clear()
		{
			this.OnClear();
			this.Node = null;
		}

		// Token: 0x060461FC RID: 287228 RVA: 0x0126B2B4 File Offset: 0x012694B4
		protected virtual void OnClear()
		{
		}

		// Token: 0x060461FD RID: 287229 RVA: 0x0126B2B6 File Offset: 0x012694B6
		public virtual void ToString(StringBuilder outBuilder, int depth = 0)
		{
		}

		// Token: 0x04027545 RID: 161093
		[Nullable(2)]
		public AiStateMachineBase Node;

		// Token: 0x04027546 RID: 161094
		[Nullable(2)]
		private readonly CombatStateMachineDefine.Fsm.Action ActionData;
	}
}
