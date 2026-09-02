using System;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005422 RID: 21538
	public class FlowActionJumpTalk : FlowActionBase
	{
		// Token: 0x06036F4D RID: 225101 RVA: 0x00DF3334 File Offset: 0x00DF1534
		protected override void OnExecute()
		{
			JumpTalk jumpTalk = this.ActionInfo.Params as JumpTalk;
			FlowActionRunner runner = this.Runner;
			base.FinishExecute(true, false);
			runner.JumpTalk(jumpTalk.TalkId);
		}

		// Token: 0x06036F4E RID: 225102 RVA: 0x00DF336B File Offset: 0x00DF156B
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
