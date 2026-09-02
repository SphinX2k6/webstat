using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005421 RID: 21537
	public class FlowActionHideByRangeInFlow : FlowActionBase
	{
		// Token: 0x06036F4A RID: 225098 RVA: 0x00DF32FC File Offset: 0x00DF14FC
		protected override void OnExecute()
		{
			HideByRangeInFlow param = this.ActionInfo.Params as HideByRangeInFlow;
			ModelBase<PlotModel>.Instance.PlotCleanRange.Open(param);
		}

		// Token: 0x06036F4B RID: 225099 RVA: 0x00DF332A File Offset: 0x00DF152A
		protected override void OnBackgroundExecute()
		{
		}
	}
}
