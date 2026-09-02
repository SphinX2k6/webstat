using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Interaction;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BE9 RID: 27625
	public class LevelEventSetInteractionLockState : LevelEventBase
	{
		// Token: 0x060440DF RID: 278751 RVA: 0x011A9DD9 File Offset: 0x011A7FD9
		public LevelEventSetInteractionLockState(int id) : base(id)
		{
		}

		// Token: 0x060440E0 RID: 278752 RVA: 0x011A9DE4 File Offset: 0x011A7FE4
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.WLJ, "参数为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			SetInteractionLockState setInteractionLockState = inParams as SetInteractionLockState;
			if (setInteractionLockState == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.WLJ, "参数类型错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EntityContext entityContext = context as EntityContext;
			if (entityContext == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.WLJ, "此LevelEvent只能接受以EntityContext为上下文", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int? interactingEntity = ModelBase<InteractionModel>.Instance.InteractingEntity;
			int? entityId = entityContext.EntityId;
			if (!(interactingEntity.GetValueOrDefault() == entityId.GetValueOrDefault() & interactingEntity != null == (entityId != null)))
			{
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.WLJ, "当前申请交互锁定的实体与记录的正在交互的实体不一致，可能是因为服务器重发，交互锁定行为不响应服务器重发", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "设置交互锁定状态";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IsLock", setInteractionLockState.IsLock);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (setInteractionLockState.IsLock)
			{
				ModelBase<InteractionModel>.Instance.LockInteract(entityContext.EntityId);
				return;
			}
			ModelBase<InteractionModel>.Instance.RecoverInteractFromLock();
		}
	}
}
