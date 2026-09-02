using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF8 RID: 27640
	public class LevelEventShowTargetRange : LevelEventBase
	{
		// Token: 0x06044111 RID: 278801 RVA: 0x011AB9EE File Offset: 0x011A9BEE
		public LevelEventShowTargetRange(int id) : base(id)
		{
		}

		// Token: 0x06044112 RID: 278802 RVA: 0x011AB9F7 File Offset: 0x011A9BF7
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			ControllerBase<SimpleNpcController>.Instance.SetClearOutState(ESimpleNpcClearOutModuleDefine.Quest, false);
			base.FinishExecute(true, false, true);
		}
	}
}
