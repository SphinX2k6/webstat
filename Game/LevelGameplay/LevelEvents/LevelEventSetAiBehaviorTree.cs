using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BE3 RID: 27619
	public class LevelEventSetAiBehaviorTree : LevelEventBase
	{
		// Token: 0x060440CB RID: 278731 RVA: 0x011A8D2C File Offset: 0x011A6F2C
		public LevelEventSetAiBehaviorTree(int id) : base(id)
		{
		}

		// Token: 0x060440CC RID: 278732 RVA: 0x011A8D38 File Offset: 0x011A6F38
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventSetAiBehaviorTree 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			OverrideAiBehaviorTree aiBehaviorTree = inParams as OverrideAiBehaviorTree;
			AiModel instance = ModelBase<AiModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SetAiBehaviorTree(aiBehaviorTree);
		}
	}
}
