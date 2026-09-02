using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F9F RID: 28575
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowPlayPlot : LevelFlowActionBase
	{
		// Token: 0x060451F6 RID: 283126 RVA: 0x01208CD0 File Offset: 0x01206ED0
		public LevelFlowPlayPlot Init(string flowListName, int flowId, int stateId, [Nullable(2)] GeneralContext context = null, int? flowIncId = null, bool? isAsync = null, bool? isSkip = null, [Nullable(2)] Vector pos = null)
		{
			this.FlowListName = flowListName;
			this.FlowId = flowId;
			this.StateId = stateId;
			this.Context = context;
			this.FlowIncId = flowIncId.GetValueOrDefault(-1);
			this.IsServerNotify = false;
			this.IsAsync = isAsync.GetValueOrDefault();
			this.IsSkip = isSkip.GetValueOrDefault();
			this.Pos = pos;
			return this;
		}

		// Token: 0x060451F7 RID: 283127 RVA: 0x01208D34 File Offset: 0x01206F34
		protected override void OnExecute()
		{
			ControllerBase<FlowController>.Instance.StartFlow(this.FlowListName, this.FlowId, this.StateId, this.Context, (long)this.FlowIncId, this.IsServerNotify, this.IsAsync, this.IsSkip, this.Pos);
			base.FinishExecute(true);
		}

		// Token: 0x0402690C RID: 157964
		private string FlowListName = string.Empty;

		// Token: 0x0402690D RID: 157965
		private int FlowId;

		// Token: 0x0402690E RID: 157966
		private int StateId;

		// Token: 0x0402690F RID: 157967
		[Nullable(2)]
		private GeneralContext Context;

		// Token: 0x04026910 RID: 157968
		private int FlowIncId;

		// Token: 0x04026911 RID: 157969
		private bool IsServerNotify;

		// Token: 0x04026912 RID: 157970
		private bool IsAsync;

		// Token: 0x04026913 RID: 157971
		private bool IsSkip;

		// Token: 0x04026914 RID: 157972
		[Nullable(2)]
		private Vector Pos;
	}
}
