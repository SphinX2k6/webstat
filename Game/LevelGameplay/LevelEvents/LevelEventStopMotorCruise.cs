using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.AutoPilot;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C0E RID: 27662
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventStopMotorCruise : LevelEventBase
	{
		// Token: 0x06044174 RID: 278900 RVA: 0x011ADE6E File Offset: 0x011AC06E
		public LevelEventStopMotorCruise(int id) : base(id)
		{
		}

		// Token: 0x06044175 RID: 278901 RVA: 0x011ADE77 File Offset: 0x011AC077
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ControllerBase<AutoPilotController>.Instance.ExitAutoPilot("LevelEvent", false);
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06044176 RID: 278902 RVA: 0x011ADE93 File Offset: 0x011AC093
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}
	}
}
