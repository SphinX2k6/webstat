using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005412 RID: 21522
	public class FlowActionChangeActorTalker : FlowActionBase
	{
		// Token: 0x06036F1D RID: 225053 RVA: 0x00DF243C File Offset: 0x00DF063C
		protected override void OnExecute()
		{
			ChangeActorTalker changeActorTalker = this.ActionInfo.Params as ChangeActorTalker;
			if (changeActorTalker == null)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.SetActorName(changeActorTalker);
		}
	}
}
