using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.SlidingBlocks;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C17 RID: 27671
	public class LevelEventTetrisGameComplete : LevelEventBase
	{
		// Token: 0x06044194 RID: 278932 RVA: 0x011AECC1 File Offset: 0x011ACEC1
		public LevelEventTetrisGameComplete(int id) : base(id)
		{
		}

		// Token: 0x06044195 RID: 278933 RVA: 0x011AECCC File Offset: 0x011ACECC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TetrisGameComplete tetrisGameComplete = inParams as TetrisGameComplete;
			if (tetrisGameComplete == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "TetrisGameComplete配置类型不支持", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<SlidingBlocksController>.Instance.MainLineModeGameComplete(tetrisGameComplete);
		}
	}
}
