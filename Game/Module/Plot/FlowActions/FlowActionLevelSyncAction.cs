using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005425 RID: 21541
	public class FlowActionLevelSyncAction : FlowActionBase
	{
		// Token: 0x06036F58 RID: 225112 RVA: 0x00DF34E0 File Offset: 0x00DF16E0
		protected unsafe override void OnExecute()
		{
			long flowIncId = this.Context.FlowIncId;
			GeneralContext context = this.Context.Context;
			PlotContext context2 = PlotContext.Create(flowIncId, (context != null) ? context.SubType : null);
			LevelGeneralController instance = ControllerBase<LevelGeneralController>.Instance;
			int num = 1;
			List<ActionInfo> list = new List<ActionInfo>(num);
			CollectionsMarshal.SetCount<ActionInfo>(list, num);
			Span<ActionInfo> span = CollectionsMarshal.AsSpan<ActionInfo>(list);
			int index = 0;
			*span[index] = this.ActionInfo;
			instance.ExecuteActionsNew(list, context2, null);
		}

		// Token: 0x06036F59 RID: 225113 RVA: 0x00DF3552 File Offset: 0x00DF1752
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
