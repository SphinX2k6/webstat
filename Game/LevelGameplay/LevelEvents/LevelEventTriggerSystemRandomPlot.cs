using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C23 RID: 27683
	public class LevelEventTriggerSystemRandomPlot : LevelEventBase
	{
		// Token: 0x060441B2 RID: 278962 RVA: 0x011AF620 File Offset: 0x011AD820
		public LevelEventTriggerSystemRandomPlot(int id) : base(id)
		{
		}

		// Token: 0x060441B3 RID: 278963 RVA: 0x011AF62C File Offset: 0x011AD82C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TriggerSystemRandomPlot triggerSystemRandomPlot = inParams as TriggerSystemRandomPlot;
			ControllerBase<RandomPlotController>.Instance.PlayRandomPlot(triggerSystemRandomPlot.Id);
		}
	}
}
