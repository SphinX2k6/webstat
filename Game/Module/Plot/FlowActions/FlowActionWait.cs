using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005442 RID: 21570
	public class FlowActionWait : FlowActionBase
	{
		// Token: 0x06036FD5 RID: 225237 RVA: 0x00DF59B0 File Offset: 0x00DF3BB0
		protected override void OnExecute()
		{
			Wait wait = this.ActionInfo.Params as Wait;
			this.TimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float id)
			{
				this.TimerId = null;
				base.FinishExecute(true, true);
			}, wait.Time * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		}

		// Token: 0x06036FD6 RID: 225238 RVA: 0x00DF5A04 File Offset: 0x00DF3C04
		protected override void OnInterruptExecute()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			}
			base.FinishExecute(true, true);
		}

		// Token: 0x0401FA11 RID: 129553
		[Nullable(2)]
		private TimerHandle TimerId;
	}
}
