using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005410 RID: 21520
	public class FlowActionBeginFlowTemplate : FlowActionBase
	{
		// Token: 0x06036F16 RID: 225046 RVA: 0x00DF22FC File Offset: 0x00DF04FC
		protected override void OnExecute()
		{
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() != EPlotLevel.LevelC)
			{
				base.FinishExecute(true, true);
				return;
			}
			if (ModelBase<PlotModel>.Instance.IsInTemplate())
			{
				base.FinishExecute(true, true);
				return;
			}
			ModelBase<PlotModel>.Instance.StartPlotTemplate(this.ActionInfo.Params as BeginFlowTemplate, this.Context, delegate
			{
				base.FinishExecute(true, true);
			});
		}

		// Token: 0x06036F17 RID: 225047 RVA: 0x00DF236A File Offset: 0x00DF056A
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
