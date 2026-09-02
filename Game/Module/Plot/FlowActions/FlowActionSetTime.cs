using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200543A RID: 21562
	public class FlowActionSetTime : FlowActionBase
	{
		// Token: 0x06036FB9 RID: 225209 RVA: 0x00DF52AC File Offset: 0x00DF34AC
		protected override void OnExecute()
		{
			AdjustTodTime adjustTodTime = this.ActionInfo.Params as AdjustTodTime;
			double num = TodDayTime.ConvertFromHourMinute((double)adjustTodTime.Hour, (double)adjustTodTime.Min);
			if (num < 0.0)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.PlotTimeOfDay.SetTime((int)num);
		}

		// Token: 0x06036FBA RID: 225210 RVA: 0x00DF52FC File Offset: 0x00DF34FC
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
