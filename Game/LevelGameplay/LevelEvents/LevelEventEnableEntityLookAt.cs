using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B8B RID: 27531
	public class LevelEventEnableEntityLookAt : LevelEventBase
	{
		// Token: 0x06043F45 RID: 278341 RVA: 0x0119AA80 File Offset: 0x01198C80
		public LevelEventEnableEntityLookAt(int id) : base(id)
		{
		}

		// Token: 0x06043F46 RID: 278342 RVA: 0x0119AA8C File Offset: 0x01198C8C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventEnableEntityLookAt 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EnableEntityLookAt param = inParams as EnableEntityLookAt;
			AiModel instance = ModelBase<AiModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.EnableEntityLookAt(param);
		}
	}
}
