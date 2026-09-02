using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005432 RID: 21554
	public class FlowActionSetCameraAnim : FlowActionBase
	{
		// Token: 0x06036F8C RID: 225164 RVA: 0x00DF41A6 File Offset: 0x00DF23A6
		protected override void OnExecute()
		{
			ModelBase<PlotModel>.Instance.PlayCameraAnim(this.ActionInfo.Params as SetCameraAnim);
		}
	}
}
