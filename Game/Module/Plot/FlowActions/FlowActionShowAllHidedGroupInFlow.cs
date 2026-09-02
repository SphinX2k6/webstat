using System;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200543B RID: 21563
	public class FlowActionShowAllHidedGroupInFlow : FlowActionBase
	{
		// Token: 0x06036FBC RID: 225212 RVA: 0x00DF530C File Offset: 0x00DF350C
		protected override void OnExecute()
		{
			ModelBase<PlotModel>.Instance.PlotCleanRange.Close();
		}

		// Token: 0x06036FBD RID: 225213 RVA: 0x00DF531D File Offset: 0x00DF351D
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
