using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B73 RID: 27507
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelEventChangeEntityState : LevelEventBase
	{
		// Token: 0x06043EDD RID: 278237 RVA: 0x01197121 File Offset: 0x01195321
		public LevelEventChangeEntityState(int id) : base(id)
		{
		}

		// Token: 0x06043EDE RID: 278238 RVA: 0x0119712C File Offset: 0x0119532C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if ((context.Type.GetValueOrDefault() != EGeneralContextType.Entity || !(context as EntityContext).ClientExecuteActions) && (context.Type.GetValueOrDefault() != EGeneralContextType.Trigger || !(context as TriggerContext).IsClientTrigger))
			{
				base.FinishExecute(true, false, true);
				return;
			}
			this.Config = (inParams as ChangeEntityState);
			int? num = null;
			switch (this.Config.Type)
			{
			case EChangeEntityState.Directly:
				num = new int?(GameplayTagUtils.GetTagIdByName((this.Config as IChangeEntityStateDirectly).State));
				this.EntityIds = new List<int>
				{
					this.Config.EntityId
				};
				break;
			case EChangeEntityState.BatchDirectly:
			{
				IChangeEntityStateBatchDirectly changeEntityStateBatchDirectly = this.Config as IChangeEntityStateBatchDirectly;
				num = new int?(GameplayTagUtils.GetTagIdByName(changeEntityStateBatchDirectly.State));
				this.EntityIds = changeEntityStateBatchDirectly.EntityIds;
				break;
			}
			case EChangeEntityState.Loop:
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.FZX, "不支持的切换实体状态", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, false, true);
				return;
			}
			if (num == null)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			this.StateId = num.Value;
			base.CreateWaitEntityTask(this.EntityIds);
		}

		// Token: 0x06043EDF RID: 278239 RVA: 0x01197268 File Offset: 0x01195468
		protected override void ExecuteWhenEntitiesReady()
		{
			foreach (int pbDataId in this.EntityIds)
			{
				LevelGeneralCommons.PrechangeStateTag(pbDataId, this.StateId, "ShowInRefSequence");
			}
			base.FinishExecute(true, false, true);
		}

		// Token: 0x06043EE0 RID: 278240 RVA: 0x011972CC File Offset: 0x011954CC
		protected override void OnReset()
		{
			this.Config = null;
			this.StateId = 0;
			this.EntityIds = null;
		}

		// Token: 0x04025FD8 RID: 155608
		private ChangeEntityState Config;

		// Token: 0x04025FD9 RID: 155609
		private int StateId;

		// Token: 0x04025FDA RID: 155610
		private List<int> EntityIds;
	}
}
