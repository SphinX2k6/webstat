using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005423 RID: 21539
	public class FlowActionLeisureInteract : FlowActionBase
	{
		// Token: 0x06036F50 RID: 225104 RVA: 0x00DF337C File Offset: 0x00DF157C
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

		// Token: 0x06036F51 RID: 225105 RVA: 0x00DF33F6 File Offset: 0x00DF15F6
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}
	}
}
