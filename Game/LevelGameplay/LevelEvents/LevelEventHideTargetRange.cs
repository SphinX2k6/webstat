using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BA6 RID: 27558
	public class LevelEventHideTargetRange : LevelEventBase
	{
		// Token: 0x06043FC7 RID: 278471 RVA: 0x0119E21F File Offset: 0x0119C41F
		public LevelEventHideTargetRange(int id) : base(id)
		{
		}

		// Token: 0x06043FC8 RID: 278472 RVA: 0x0119E228 File Offset: 0x0119C428
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
			}
			if ((inParams as HideTargetRange).IsHideSimpleNpc.GetValueOrDefault())
			{
				ControllerBase<SimpleNpcController>.Instance.SetClearOutState(ESimpleNpcClearOutModuleDefine.Quest, true);
			}
			base.FinishExecute(true, false, true);
		}
	}
}
