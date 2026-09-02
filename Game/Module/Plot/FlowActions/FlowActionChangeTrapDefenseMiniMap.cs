using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005419 RID: 21529
	public class FlowActionChangeTrapDefenseMiniMap : FlowActionBase
	{
		// Token: 0x06036F2E RID: 225070 RVA: 0x00DF2A38 File Offset: 0x00DF0C38
		protected override void OnExecute()
		{
			TrapDefenseChangeMiniMap trapDefenseChangeMiniMap = this.ActionInfo.Params as TrapDefenseChangeMiniMap;
			ControllerBase<TrapDefenseController>.Instance.ChangeMap(trapDefenseChangeMiniMap.MiniMapId);
		}
	}
}
