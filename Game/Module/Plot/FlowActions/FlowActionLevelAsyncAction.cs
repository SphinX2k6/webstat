using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005424 RID: 21540
	public class FlowActionLevelAsyncAction : FlowActionBase
	{
		// Token: 0x06036F53 RID: 225107 RVA: 0x00DF3408 File Offset: 0x00DF1608
		protected unsafe override void OnExecute()
		{
			this.IncId++;
			int id = this.IncId;
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
			instance.ExecuteActionsNew(list, context2, delegate(ELevelEventState result)
			{
				if (this.ActionInfo == null || this.Runner == null || id != this.IncId)
				{
					return;
				}
				this.OnActionFinish(result == ELevelEventState.Success);
			});
		}

		// Token: 0x06036F54 RID: 225108 RVA: 0x00DF34AD File Offset: 0x00DF16AD
		protected override void OnBackgroundExecute()
		{
			this.OnExecute();
		}

		// Token: 0x06036F55 RID: 225109 RVA: 0x00DF34B5 File Offset: 0x00DF16B5
		protected override void OnInterruptExecute()
		{
			this.IncId++;
			base.FinishExecute(true, true);
		}

		// Token: 0x06036F56 RID: 225110 RVA: 0x00DF34CD File Offset: 0x00DF16CD
		protected virtual void OnActionFinish(bool result)
		{
			base.FinishExecute(result, true);
		}

		// Token: 0x0401FA02 RID: 129538
		private int IncId;
	}
}
