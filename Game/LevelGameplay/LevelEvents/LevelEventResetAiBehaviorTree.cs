using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD5 RID: 27605
	public class LevelEventResetAiBehaviorTree : LevelEventBase
	{
		// Token: 0x0604408E RID: 278670 RVA: 0x011A5A9E File Offset: 0x011A3C9E
		public LevelEventResetAiBehaviorTree(int id) : base(id)
		{
		}

		// Token: 0x0604408F RID: 278671 RVA: 0x011A5AA8 File Offset: 0x011A3CA8
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventResetAiBehaviorTree 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			RestoreAiBehaviorTree restoreAiBehaviorTree = inParams as RestoreAiBehaviorTree;
			AiModel instance = ModelBase<AiModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ResetAiBehaviorTree(restoreAiBehaviorTree.Key);
		}
	}
}
