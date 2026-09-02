using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005440 RID: 21568
	public class FlowActionTakePlotPhoto : FlowActionBase
	{
		// Token: 0x06036FD0 RID: 225232 RVA: 0x00DF5834 File Offset: 0x00DF3A34
		protected override void OnExecute()
		{
			if (!(this.ActionInfo.Params is TakePlotPhoto))
			{
				base.FinishExecute(true, true);
				return;
			}
			if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PlotPhotoView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PlotPhotoView, new Action(this.OnViewClose), null);
			}
		}

		// Token: 0x06036FD1 RID: 225233 RVA: 0x00DF5889 File Offset: 0x00DF3A89
		private void OnViewClose()
		{
			base.FinishExecute(true, true);
		}
	}
}
