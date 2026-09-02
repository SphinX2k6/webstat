using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB5 RID: 28597
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowWaitPlotEnd : LevelFlowActionBase
	{
		// Token: 0x06045255 RID: 283221 RVA: 0x0120B1E6 File Offset: 0x012093E6
		public LevelFlowWaitPlotEnd Init(string flowListName, int flowId, int stateId)
		{
			this.FlowListName = flowListName;
			this.FlowId = flowId;
			this.StateId = stateId;
			return this;
		}

		// Token: 0x06045256 RID: 283222 RVA: 0x0120B1FE File Offset: 0x012093FE
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
		}

		// Token: 0x06045257 RID: 283223 RVA: 0x0120B21C File Offset: 0x0120941C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotNetworkEnd));
		}

		// Token: 0x06045258 RID: 283224 RVA: 0x0120B23C File Offset: 0x0120943C
		private void OnPlotNetworkEnd(PlotResultInfo plotResult)
		{
			if (plotResult.FlowListName == this.FlowListName)
			{
				int? num = plotResult.FlowId;
				int num2 = this.FlowId;
				if (num.GetValueOrDefault() == num2 & num != null)
				{
					num = plotResult.StateId;
					num2 = this.StateId;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						base.FinishExecute(true);
					}
				}
			}
		}

		// Token: 0x04026940 RID: 158016
		private string FlowListName = string.Empty;

		// Token: 0x04026941 RID: 158017
		private int FlowId;

		// Token: 0x04026942 RID: 158018
		private int StateId;
	}
}
