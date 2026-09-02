using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B8A RID: 27530
	public class LevelEventEnableAi : LevelEventBase
	{
		// Token: 0x06043F43 RID: 278339 RVA: 0x0119A941 File Offset: 0x01198B41
		public LevelEventEnableAi(int id) : base(id)
		{
		}

		// Token: 0x06043F44 RID: 278340 RVA: 0x0119A94C File Offset: 0x01198B4C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EnableAI enableAI = inParams as EnableAI;
			if (enableAI == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			if (enableAI.EntityIds == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "LevelEventEnableAi行为执行失败：配置的实体Id列表为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false, false, true);
				return;
			}
			foreach (int num in enableAI.EntityIds)
			{
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(num);
				if (entityByPbDataId == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "LevelEventEnableAi行为执行时找不到实体";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("实体Id", num);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					BaseMoveComponent component = entityByPbDataId.Entity.GetComponent<BaseMoveComponent>();
					if (component == null || !component.Valid)
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.LevelEvent;
						ELogAuthor author2 = ELogAuthor.YSQ;
						string message2 = "LevelEventEnableAi行为执行时,实体不存在CharacterMoveComponent";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("实体Id", num);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
					else
					{
						component.StopMove(!enableAI.IsEnable, "LevelEventEnableAi.ExecuteNew");
					}
				}
			}
		}
	}
}
