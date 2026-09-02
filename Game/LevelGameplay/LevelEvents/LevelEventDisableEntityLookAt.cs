using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B87 RID: 27527
	public class LevelEventDisableEntityLookAt : LevelEventBase
	{
		// Token: 0x06043F30 RID: 278320 RVA: 0x0119A07A File Offset: 0x0119827A
		public LevelEventDisableEntityLookAt(int id) : base(id)
		{
		}

		// Token: 0x06043F31 RID: 278321 RVA: 0x0119A084 File Offset: 0x01198284
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventDisableEntityLookAt 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			DisableEntityLookAt disableEntityLookAt = inParams as DisableEntityLookAt;
			AiModel instance = ModelBase<AiModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.DisableEntityLookAt(disableEntityLookAt.Key);
		}
	}
}
