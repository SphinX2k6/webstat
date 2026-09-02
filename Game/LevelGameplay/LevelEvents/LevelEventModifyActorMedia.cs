using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BB4 RID: 27572
	public class LevelEventModifyActorMedia : LevelEventBase
	{
		// Token: 0x06043FFC RID: 278524 RVA: 0x0119F843 File Offset: 0x0119DA43
		public LevelEventModifyActorMedia(int id) : base(id)
		{
		}

		// Token: 0x06043FFD RID: 278525 RVA: 0x0119F84C File Offset: 0x0119DA4C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ModifyActorMedia modifyActorMedia = inParams as ModifyActorMedia;
			if (modifyActorMedia == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.BB, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.BB, "此LevelEvent只能配置在SceneActorRefComponent中", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
			if (entity == null || !entity.Valid)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.BB;
				string message = "状态控制entity不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityContext.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			SceneItemReferenceComponent component = entity.GetComponent<SceneItemReferenceComponent>();
			if (component != null)
			{
				component.HandleActorMedia(modifyActorMedia);
			}
		}
	}
}
