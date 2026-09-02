using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005436 RID: 21558
	public class FlowActionSetHeadIconVisible : FlowActionBase
	{
		// Token: 0x06036F9A RID: 225178 RVA: 0x00DF4764 File Offset: 0x00DF2964
		protected override void OnExecute()
		{
			SetHeadIconVisible config = this.ActionInfo.Params as SetHeadIconVisible;
			this.Active = true;
			ControllerBase<PlotController>.Instance.PlotViewManager.UpdatePortraitVisible(config, new Action(this.OnFinishSet));
		}

		// Token: 0x06036F9B RID: 225179 RVA: 0x00DF47A5 File Offset: 0x00DF29A5
		private void OnFinishSet()
		{
			if (this == null || !this.Active)
			{
				return;
			}
			this.Active = false;
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F9C RID: 225180 RVA: 0x00DF47C8 File Offset: 0x00DF29C8
		protected override void OnInterruptExecute()
		{
			this.Active = false;
			base.FinishExecute(true, true);
		}

		// Token: 0x0401FA06 RID: 129542
		private bool Active;
	}
}
