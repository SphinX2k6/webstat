using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BC5 RID: 27589
	public class LevelEventPlayLevelSequence : LevelEventBase
	{
		// Token: 0x0604405A RID: 278618 RVA: 0x011A34F5 File Offset: 0x011A16F5
		public LevelEventPlayLevelSequence(int id) : base(id)
		{
		}

		// Token: 0x0604405B RID: 278619 RVA: 0x011A3500 File Offset: 0x011A1700
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PlayLevelSequence playLevelSequence = inParams as PlayLevelSequence;
			if (playLevelSequence == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YZH, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (string.IsNullOrEmpty(playLevelSequence.LevelSequencePath))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "LevelSequence路径为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Context", context);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YZH, "此LevelEvent只能配置在SceneActorRefComponent中", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
			if (entity == null || !entity.Valid)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.ZS;
				string message2 = "状态控制entity不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", entityContext.EntityId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			SceneItemActorComponent component = entity.GetComponent<SceneItemActorComponent>();
			if (((component != null) ? component.Owner : null) == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.ZS, "状态控制actor不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			SceneItemReferenceComponent component2 = entity.GetComponent<SceneItemReferenceComponent>();
			if (component2 != null)
			{
				component2.HandleSequence(playLevelSequence);
			}
		}
	}
}
