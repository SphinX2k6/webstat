using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B65 RID: 27493
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventAddBuffToTriggeredEntity : LevelEventAddBuffClientPrePerformance
	{
		// Token: 0x06043E81 RID: 278145 RVA: 0x0118FDDC File Offset: 0x0118DFDC
		public LevelEventAddBuffToTriggeredEntity(int id) : base(id)
		{
		}

		// Token: 0x06043E82 RID: 278146 RVA: 0x0118FDE5 File Offset: 0x0118DFE5
		[return: Nullable(2)]
		protected override EntityHandle GetTargetEntity(TriggerContext context)
		{
			return base.GetOtherEntity(context);
		}

		// Token: 0x06043E83 RID: 278147 RVA: 0x0118FDEE File Offset: 0x0118DFEE
		protected override List<long> GetBuffIds(ActionParams inParams)
		{
			return (inParams as AddBuffToTriggeredEntity).BuffIds;
		}
	}
}
