using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Season;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BEF RID: 27631
	public class LevelEventSetSeasonState : LevelEventBase
	{
		// Token: 0x060440F8 RID: 278776 RVA: 0x011AAFDB File Offset: 0x011A91DB
		public LevelEventSetSeasonState(int id) : base(id)
		{
		}

		// Token: 0x060440F9 RID: 278777 RVA: 0x011AAFE4 File Offset: 0x011A91E4
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ClientSetSeasonState clientSetSeasonState = inParams as ClientSetSeasonState;
			if (clientSetSeasonState == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			ControllerBase<SeasonController>.Instance.ApplyConfig(clientSetSeasonState.VolumeId, clientSetSeasonState.Config, delegate(bool success)
			{
				base.FinishExecute(success, false, true);
			});
		}
	}
}
