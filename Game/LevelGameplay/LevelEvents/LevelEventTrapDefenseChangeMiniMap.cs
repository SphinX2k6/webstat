using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C1D RID: 27677
	public class LevelEventTrapDefenseChangeMiniMap : LevelEventBase
	{
		// Token: 0x060441A4 RID: 278948 RVA: 0x011AF1E0 File Offset: 0x011AD3E0
		public LevelEventTrapDefenseChangeMiniMap(int id) : base(id)
		{
		}

		// Token: 0x060441A5 RID: 278949 RVA: 0x011AF1EC File Offset: 0x011AD3EC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TrapDefenseChangeMiniMap trapDefenseChangeMiniMap = inParams as TrapDefenseChangeMiniMap;
			ControllerBase<TrapDefenseController>.Instance.ChangeMap(trapDefenseChangeMiniMap.MiniMapId);
			base.FinishExecute(true, false, true);
		}
	}
}
