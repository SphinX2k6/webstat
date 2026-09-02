using System;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200541F RID: 21535
	public class FlowActionFinishState : FlowActionBase
	{
		// Token: 0x06036F44 RID: 225092 RVA: 0x00DF3290 File Offset: 0x00DF1490
		protected override void OnExecute()
		{
			this.Context.IsBreakdown = true;
			if (this.Context.CurShowTalk != null)
			{
				FlowActionRunner runner = this.Runner;
				base.FinishExecute(true, false);
				runner.FinishTalk();
				return;
			}
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F45 RID: 225093 RVA: 0x00DF32C7 File Offset: 0x00DF14C7
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
