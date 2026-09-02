using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C12 RID: 27666
	public class LevelEventSubmitQuestBehavior : LevelEventBase
	{
		// Token: 0x06044180 RID: 278912 RVA: 0x011AE524 File Offset: 0x011AC724
		public LevelEventSubmitQuestBehavior(int id) : base(id)
		{
		}

		// Token: 0x06044181 RID: 278913 RVA: 0x011AE530 File Offset: 0x011AC730
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ActionSubmitQuestBehavior actionSubmitQuestBehavior = inParams as ActionSubmitQuestBehavior;
			if (actionSubmitQuestBehavior == null || actionSubmitQuestBehavior.Callback == null)
			{
				return;
			}
			actionSubmitQuestBehavior.Callback();
		}
	}
}
