using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070D4 RID: 28884
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineTask
	{
		// Token: 0x1700A5E4 RID: 42468
		// (get) Token: 0x0604607A RID: 286842 RVA: 0x01263C0B File Offset: 0x01261E0B
		// (set) Token: 0x0604607B RID: 286843 RVA: 0x01263C13 File Offset: 0x01261E13
		public virtual bool IsAsyncTask { get; set; }

		// Token: 0x0604607C RID: 286844 RVA: 0x01263C1C File Offset: 0x01261E1C
		public AiStateMachineTask(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state)
		{
			this.Node = stateMachineNode;
			this.StateData = state;
			this.CanBeInterrupt = state.CanBeInterrupt;
		}

		// Token: 0x1700A5E5 RID: 42469
		// (get) Token: 0x0604607D RID: 286845 RVA: 0x01263C3E File Offset: 0x01261E3E
		public CombatStateMachineDefine.Fsm.ETaskType Type
		{
			get
			{
				return (CombatStateMachineDefine.Fsm.ETaskType)this.StateData.Type;
			}
		}

		// Token: 0x0604607E RID: 286846 RVA: 0x01263C4B File Offset: 0x01261E4B
		public bool Init()
		{
			return this.OnInit(this.StateData);
		}

		// Token: 0x0604607F RID: 286847 RVA: 0x01263C59 File Offset: 0x01261E59
		protected virtual bool OnInit(CombatStateMachineDefine.Fsm.Task task)
		{
			return true;
		}

		// Token: 0x06046080 RID: 286848 RVA: 0x01263C5C File Offset: 0x01261E5C
		public virtual void OnEnter(long? contextId = null)
		{
		}

		// Token: 0x06046081 RID: 286849 RVA: 0x01263C5E File Offset: 0x01261E5E
		public virtual void OnExit(long? contextId = null)
		{
		}

		// Token: 0x06046082 RID: 286850 RVA: 0x01263C60 File Offset: 0x01261E60
		public virtual void OnActivate(long? contextId = null)
		{
		}

		// Token: 0x06046083 RID: 286851 RVA: 0x01263C62 File Offset: 0x01261E62
		public virtual void OnDeactivate(long? contextId = null)
		{
		}

		// Token: 0x06046084 RID: 286852 RVA: 0x01263C64 File Offset: 0x01261E64
		public virtual void OnExecuted(long? contextId = null)
		{
		}

		// Token: 0x06046085 RID: 286853 RVA: 0x01263C66 File Offset: 0x01261E66
		public virtual void Tick(float deltaSeconds, long? contextId = null)
		{
			this.OnTick(deltaSeconds, contextId);
		}

		// Token: 0x06046086 RID: 286854 RVA: 0x01263C70 File Offset: 0x01261E70
		protected virtual void OnTick(float deltaSeconds, long? contextId = null)
		{
		}

		// Token: 0x06046087 RID: 286855 RVA: 0x01263C72 File Offset: 0x01261E72
		public void Clear()
		{
			this.OnClear();
			this.Node = null;
			this.StateData = null;
		}

		// Token: 0x06046088 RID: 286856 RVA: 0x01263C88 File Offset: 0x01261E88
		protected virtual void OnClear()
		{
		}

		// Token: 0x06046089 RID: 286857 RVA: 0x01263C8A File Offset: 0x01261E8A
		public virtual void ToString(StringBuilder outBuilder, int depth = 0)
		{
		}

		// Token: 0x0402748D RID: 160909
		[Nullable(2)]
		public AiStateMachineBase Node;

		// Token: 0x0402748E RID: 160910
		[Nullable(2)]
		private CombatStateMachineDefine.Fsm.Task StateData;

		// Token: 0x0402748F RID: 160911
		public bool CanBeInterrupt;
	}
}
