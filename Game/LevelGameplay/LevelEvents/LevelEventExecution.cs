using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B9B RID: 27547
	public class LevelEventExecution : LevelEventBase
	{
		// Token: 0x06043F99 RID: 278425 RVA: 0x0119D392 File Offset: 0x0119B592
		public LevelEventExecution(int id) : base(id)
		{
		}

		// Token: 0x06043F9A RID: 278426 RVA: 0x0119D39C File Offset: 0x0119B59C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (context.Type.GetValueOrDefault() != EGeneralContextType.Entity)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			EntityContext entityContext = context as EntityContext;
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
			if (entity == null || !entity.Valid)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.EntityId = entityContext.EntityId.Value;
			this.HandleExecutionSuccess();
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043F9B RID: 278427 RVA: 0x0119D418 File Offset: 0x0119B618
		private void HandleExecutionSuccess()
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(this.EntityId);
			if (entity == null)
			{
				return;
			}
			ExecutionComponent component = entity.GetComponent<ExecutionComponent>();
			if (component == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Battle, ELogAuthor.YZ, "Can not find ExecutionComponent", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			component.StartExecution();
		}

		// Token: 0x06043F9C RID: 278428 RVA: 0x0119D466 File Offset: 0x0119B666
		protected override void OnReset()
		{
			this.EntityId = 0;
		}

		// Token: 0x0402601D RID: 155677
		private int EntityId;
	}
}
