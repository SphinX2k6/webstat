using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005435 RID: 21557
	public class FlowActionSetFlowTemplate : FlowActionBase
	{
		// Token: 0x06036F96 RID: 225174 RVA: 0x00DF46F4 File Offset: 0x00DF28F4
		protected override void OnExecute()
		{
			if (ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel.GetValueOrDefault() != EPlotLevel.LevelC)
			{
				base.FinishExecute(true, true);
				return;
			}
			ModelBase<PlotModel>.Instance.SetPlotTemplate(this.ActionInfo.Params as SetFlowTemplate, delegate
			{
				base.FinishExecute(true, true);
			});
		}

		// Token: 0x06036F97 RID: 225175 RVA: 0x00DF4747 File Offset: 0x00DF2947
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
