using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.SlidingBlocks;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C19 RID: 27673
	public class LevelEventTetrisTriggerDelayFall : LevelEventBase
	{
		// Token: 0x06044198 RID: 278936 RVA: 0x011AED58 File Offset: 0x011ACF58
		public LevelEventTetrisTriggerDelayFall(int id) : base(id)
		{
		}

		// Token: 0x06044199 RID: 278937 RVA: 0x011AED64 File Offset: 0x011ACF64
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TetrisTriggerDelayFall tetrisTriggerDelayFall = inParams as TetrisTriggerDelayFall;
			if (tetrisTriggerDelayFall == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "LevelEventTetrisTriggerDelayFall配置类型不支持", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<SlidingBlocksController>.Instance.MainLineModeTriggerDelayFall(tetrisTriggerDelayFall);
		}
	}
}
