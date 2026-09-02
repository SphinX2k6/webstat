using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C1E RID: 27678
	public class LevelEventTrapDefensePlayerOperationConstraint : LevelEventBase
	{
		// Token: 0x060441A6 RID: 278950 RVA: 0x011AF219 File Offset: 0x011AD419
		public LevelEventTrapDefensePlayerOperationConstraint(int id) : base(id)
		{
		}

		// Token: 0x060441A7 RID: 278951 RVA: 0x011AF224 File Offset: 0x011AD424
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TrapDefensePlayerOperationConstraint trapDefensePlayerOperationConstraint = inParams as TrapDefensePlayerOperationConstraint;
			if (trapDefensePlayerOperationConstraint == null)
			{
				return;
			}
			TrapDefenseBattleGuideManager.RegisterBehaviorTreeGuideData(trapDefensePlayerOperationConstraint);
			base.FinishExecute(true, false, true);
		}
	}
}
