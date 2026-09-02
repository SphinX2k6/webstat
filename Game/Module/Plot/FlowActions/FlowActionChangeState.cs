using System;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005418 RID: 21528
	public class FlowActionChangeState : FlowActionBase
	{
		// Token: 0x06036F2B RID: 225067 RVA: 0x00DF29EE File Offset: 0x00DF0BEE
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

		// Token: 0x06036F2C RID: 225068 RVA: 0x00DF2A25 File Offset: 0x00DF0C25
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
