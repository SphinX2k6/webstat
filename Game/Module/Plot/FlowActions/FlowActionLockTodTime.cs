using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005426 RID: 21542
	public class FlowActionLockTodTime : FlowActionBase
	{
		// Token: 0x06036F5B RID: 225115 RVA: 0x00DF3564 File Offset: 0x00DF1764
		protected override void OnExecute()
		{
			SetTimeLockState setTimeLockState = this.ActionInfo.Params as SetTimeLockState;
			if (setTimeLockState == null)
			{
				base.FinishExecute(false, true);
				return;
			}
			ELockState lockState = setTimeLockState.LockState;
			if (lockState == ELockState.Lock)
			{
				ModelBase<PlotModel>.Instance.PlotTimeOfDay.PauseTime();
				return;
			}
			if (lockState != ELockState.Unlock)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.PlotTimeOfDay.ResumeTime();
		}

		// Token: 0x06036F5C RID: 225116 RVA: 0x00DF35BC File Offset: 0x00DF17BC
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
			base.FinishExecute(true, true);
		}
	}
}
