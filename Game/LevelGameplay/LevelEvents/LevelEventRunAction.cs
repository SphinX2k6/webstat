using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BDB RID: 27611
	public class LevelEventRunAction : LevelEventBase
	{
		// Token: 0x060440A0 RID: 278688 RVA: 0x011A6009 File Offset: 0x011A4209
		public LevelEventRunAction(int id) : base(id)
		{
		}

		// Token: 0x060440A1 RID: 278689 RVA: 0x011A6014 File Offset: 0x011A4214
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			RunActions runActions = inParams as RunActions;
			if (runActions == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			LevelGeneralController instance = ControllerBase<LevelGeneralController>.Instance;
			IList<ActionInfo> actionList = runActions.ActionList;
			GeneralContext context2 = GeneralContext.Copy(context);
			Action<ELevelEventState> finishCallback;
			if (!this.IsAsync)
			{
				finishCallback = delegate(ELevelEventState result)
				{
					base.FinishExecute(result == ELevelEventState.Success, false, true);
				};
			}
			else
			{
				finishCallback = delegate(ELevelEventState _)
				{
				};
			}
			instance.ExecuteActionsNew(actionList, context2, finishCallback);
			if (this.IsAsync)
			{
				base.FinishExecute(true, false, true);
			}
		}
	}
}
