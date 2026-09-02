using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.SlidingBlocks;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C18 RID: 27672
	public class LevelEventTetrisThrowBlock : LevelEventBase
	{
		// Token: 0x06044196 RID: 278934 RVA: 0x011AED0C File Offset: 0x011ACF0C
		public LevelEventTetrisThrowBlock(int id) : base(id)
		{
		}

		// Token: 0x06044197 RID: 278935 RVA: 0x011AED18 File Offset: 0x011ACF18
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TetrisThrowBlock tetrisThrowBlock = inParams as TetrisThrowBlock;
			if (tetrisThrowBlock == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "TetrisThrowBlock配置类型不支持", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<SlidingBlocksController>.Instance.SpawnTetrominoOnMainLineMode(tetrisThrowBlock);
		}
	}
}
