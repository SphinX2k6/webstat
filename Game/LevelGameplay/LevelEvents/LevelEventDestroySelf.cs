using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B86 RID: 27526
	public class LevelEventDestroySelf : LevelEventBase
	{
		// Token: 0x06043F2E RID: 278318 RVA: 0x0119A012 File Offset: 0x01198212
		public LevelEventDestroySelf(int id) : base(id)
		{
		}

		// Token: 0x06043F2F RID: 278319 RVA: 0x0119A01C File Offset: 0x0119821C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			TriggerContext triggerContext = context as TriggerContext;
			if (triggerContext == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.JLY, "此LevelEvent只能配置在Trigger中", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(triggerContext.TriggerEntityId.Value);
			if (entityById == null)
			{
				return;
			}
			LevelGeneralCommons.ChangeToDestroyState(ModelBase<CreatureModel>.Instance.GetPbDataIdByEntity(entityById));
		}
	}
}
