using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F9D RID: 28573
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowParallelAction : LevelFlowActionBase
	{
		// Token: 0x060451EC RID: 283116 RVA: 0x012089C3 File Offset: 0x01206BC3
		public LevelFlowParallelAction Init(List<LevelFlowActionBase> actions)
		{
			this.Actions = actions;
			return this;
		}

		// Token: 0x060451ED RID: 283117 RVA: 0x012089D0 File Offset: 0x01206BD0
		protected override void OnExecute()
		{
			if (this.Actions.Count <= 0)
			{
				base.FinishExecute(true);
				return;
			}
			this.FinishActionSet.Clear();
			foreach (LevelFlowActionBase levelFlowActionBase in this.Actions)
			{
				levelFlowActionBase.BindCompleteCallBack(new Action<LevelFlowActionBase, bool>(this.OnActionComplete));
				levelFlowActionBase.Execute();
			}
		}

		// Token: 0x060451EE RID: 283118 RVA: 0x01208A54 File Offset: 0x01206C54
		protected override void OnTick(float deltaTime)
		{
			foreach (LevelFlowActionBase levelFlowActionBase in this.Actions)
			{
				levelFlowActionBase.Tick(deltaTime);
			}
		}

		// Token: 0x060451EF RID: 283119 RVA: 0x01208AA8 File Offset: 0x01206CA8
		private void OnActionComplete(LevelFlowActionBase action, bool isSuccess)
		{
			if (!isSuccess)
			{
				base.FinishExecute(false);
				return;
			}
			this.FinishActionSet.Add(action);
			if (this.FinishActionSet.Count >= this.Actions.Count)
			{
				base.FinishExecute(true);
			}
		}

		// Token: 0x060451F0 RID: 283120 RVA: 0x01208AE4 File Offset: 0x01206CE4
		protected override void OnReset()
		{
			foreach (LevelFlowActionBase levelFlowActionBase in this.Actions)
			{
				levelFlowActionBase.Reset();
			}
			this.FinishActionSet.Clear();
		}

		// Token: 0x04026909 RID: 157961
		private List<LevelFlowActionBase> Actions = new List<LevelFlowActionBase>();

		// Token: 0x0402690A RID: 157962
		private readonly HashSet<LevelFlowActionBase> FinishActionSet = new HashSet<LevelFlowActionBase>();
	}
}
