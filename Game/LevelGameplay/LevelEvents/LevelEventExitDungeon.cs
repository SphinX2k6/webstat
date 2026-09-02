using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.InstanceDungeon;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B9C RID: 27548
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventExitDungeon : LevelEventBase
	{
		// Token: 0x06043F9D RID: 278429 RVA: 0x0119D46F File Offset: 0x0119B66F
		public LevelEventExitDungeon(int id) : base(id)
		{
		}

		// Token: 0x06043F9E RID: 278430 RVA: 0x0119D478 File Offset: 0x0119B678
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F9F RID: 278431 RVA: 0x0119D484 File Offset: 0x0119B684
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SundryModel instance = ModelBase<SundryModel>.Instance;
			if (instance != null && instance.IsBlockTpDungeon())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText("ExitDungeon被GM屏蔽，跳过执行");
				base.FinishExecute(true, false, true);
				return;
			}
			base.FinishExecute(true, false, true);
			ExitDungeon exitDungeon = inParams as ExitDungeon;
			if (exitDungeon == null || !exitDungeon.IsNeedSecondaryConfirmation.GetValueOrDefault())
			{
				return;
			}
			ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(null, null, false);
		}
	}
}
