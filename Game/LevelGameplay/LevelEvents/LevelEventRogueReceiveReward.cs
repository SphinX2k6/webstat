using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BDA RID: 27610
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventRogueReceiveReward : LevelEventBase
	{
		// Token: 0x0604409D RID: 278685 RVA: 0x011A5FF3 File Offset: 0x011A41F3
		public LevelEventRogueReceiveReward(int id) : base(id)
		{
		}

		// Token: 0x0604409E RID: 278686 RVA: 0x011A5FFC File Offset: 0x011A41FC
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604409F RID: 278687 RVA: 0x011A6007 File Offset: 0x011A4207
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
		}
	}
}
