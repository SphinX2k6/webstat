using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x0200542F RID: 21551
	public class FlowActionPreEnableSubLevel : FlowActionBase
	{
		// Token: 0x06036F81 RID: 225153 RVA: 0x00DF3EBC File Offset: 0x00DF20BC
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
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F82 RID: 225154 RVA: 0x00DF3F36 File Offset: 0x00DF2136
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
