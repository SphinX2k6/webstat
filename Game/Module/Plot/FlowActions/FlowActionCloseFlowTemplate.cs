using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200541A RID: 21530
	public class FlowActionCloseFlowTemplate : FlowActionBase
	{
		// Token: 0x06036F30 RID: 225072 RVA: 0x00DF2A70 File Offset: 0x00DF0C70
		protected override void OnExecute()
		{
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() != EPlotLevel.LevelC)
			{
				base.FinishExecute(true, true);
				return;
			}
			ModelBase<PlotModel>.Instance.EndPlotTemplate(this.ActionInfo.Params as CloseFlowTemplate, delegate
			{
				base.FinishExecute(true, true);
			});
		}

		// Token: 0x06036F31 RID: 225073 RVA: 0x00DF2AC3 File Offset: 0x00DF0CC3
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
