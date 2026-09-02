using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA8 RID: 28584
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowSequenceAction : LevelFlowActionBase
	{
		// Token: 0x0604521E RID: 283166 RVA: 0x012098A2 File Offset: 0x01207AA2
		public LevelFlowSequenceAction Init(List<LevelFlowActionBase> actions)
		{
			this.Actions = actions;
			return this;
		}

		// Token: 0x0604521F RID: 283167 RVA: 0x012098AC File Offset: 0x01207AAC
		protected override void OnExecute()
		{
			if (this.Actions.Count <= 0)
			{
				base.FinishExecute(true);
				return;
			}
			this.CurrentActionIndex = 0;
			LevelFlowActionBase levelFlowActionBase = this.Actions[this.CurrentActionIndex];
			levelFlowActionBase.BindCompleteCallBack(new Action<LevelFlowActionBase, bool>(this.OnActionComplete));
			levelFlowActionBase.Execute();
		}

		// Token: 0x06045220 RID: 283168 RVA: 0x012098FE File Offset: 0x01207AFE
		protected override void OnTick(float deltaTime)
		{
			this.Actions[this.CurrentActionIndex].Tick(deltaTime);
		}

		// Token: 0x06045221 RID: 283169 RVA: 0x01209918 File Offset: 0x01207B18
		private void OnActionComplete(LevelFlowActionBase action, bool isSuccess)
		{
			if (!isSuccess)
			{
				base.FinishExecute(false);
				return;
			}
			this.CurrentActionIndex++;
			if (this.CurrentActionIndex >= this.Actions.Count)
			{
				base.FinishExecute(true);
				return;
			}
			LevelFlowActionBase levelFlowActionBase = this.Actions[this.CurrentActionIndex];
			levelFlowActionBase.BindCompleteCallBack(new Action<LevelFlowActionBase, bool>(this.OnActionComplete));
			levelFlowActionBase.Execute();
		}

		// Token: 0x06045222 RID: 283170 RVA: 0x01209984 File Offset: 0x01207B84
		protected override void OnReset()
		{
			this.CurrentActionIndex = 0;
			foreach (LevelFlowActionBase levelFlowActionBase in this.Actions)
			{
				levelFlowActionBase.Reset();
			}
		}

		// Token: 0x04026927 RID: 157991
		private List<LevelFlowActionBase> Actions = new List<LevelFlowActionBase>();

		// Token: 0x04026928 RID: 157992
		private int CurrentActionIndex;
	}
}
