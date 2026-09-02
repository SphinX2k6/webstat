using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B74 RID: 27508
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventChangeNpcPerformState : LevelEventBase
	{
		// Token: 0x06043EE1 RID: 278241 RVA: 0x011972E3 File Offset: 0x011954E3
		public LevelEventChangeNpcPerformState(int id) : base(id)
		{
		}

		// Token: 0x06043EE2 RID: 278242 RVA: 0x011972F8 File Offset: 0x011954F8
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			ChangeNpcPerformState changeNpcPerformState = inParams as ChangeNpcPerformState;
			if (changeNpcPerformState == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventChangeNpcPerformState失败，参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.State = changeNpcPerformState.State;
			this.EntityId = changeNpcPerformState.EntityId;
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(changeNpcPerformState.EntityId);
			bool flag;
			if (entityByPbDataId == null)
			{
				flag = false;
			}
			else
			{
				WorldEntity entity = entityByPbDataId.Entity;
				flag = ((entity != null) ? new bool?(entity.IsInit) : null).GetValueOrDefault();
			}
			if (flag)
			{
				this.ExecuteWhenEntitiesReady();
				return;
			}
			base.CreateWaitEntityTask(changeNpcPerformState.EntityId);
		}

		// Token: 0x06043EE3 RID: 278243 RVA: 0x01197398 File Offset: 0x01195598
		protected override void ExecuteWhenEntitiesReady()
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.EntityId);
			bool flag;
			if (entityByPbDataId == null)
			{
				flag = true;
			}
			else
			{
				WorldEntity entity = entityByPbDataId.Entity;
				flag = !((entity != null) ? new bool?(entity.IsInit) : null).GetValueOrDefault();
			}
			if (flag)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YSQ, "执行行为LevelEventChangeNpcPerformState失败，实体没有Activate", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			entityByPbDataId.Entity.GetComponent<CommonNpcPerformComponent>().PerformGroupController.SwitchPerformState(this.State);
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043EE4 RID: 278244 RVA: 0x01197429 File Offset: 0x01195629
		protected override void OnReset()
		{
			this.State = "";
			this.EntityId = 0;
		}

		// Token: 0x04025FDB RID: 155611
		private string State = "";

		// Token: 0x04025FDC RID: 155612
		private int EntityId;
	}
}
