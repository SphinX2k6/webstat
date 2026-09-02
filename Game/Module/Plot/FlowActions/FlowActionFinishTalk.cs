using System;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005420 RID: 21536
	public class FlowActionFinishTalk : FlowActionBase
	{
		// Token: 0x06036F47 RID: 225095 RVA: 0x00DF32D7 File Offset: 0x00DF14D7
		protected override void OnExecute()
		{
			FlowActionRunner runner = this.Runner;
			base.FinishExecute(true, false);
			runner.FinishTalk();
		}

		// Token: 0x06036F48 RID: 225096 RVA: 0x00DF32EC File Offset: 0x00DF14EC
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
