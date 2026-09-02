using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F8C RID: 28556
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelFlowChangeEntityState : LevelFlowActionBase
	{
		// Token: 0x06045188 RID: 283016 RVA: 0x01205FB7 File Offset: 0x012041B7
		[NullableContext(1)]
		public LevelFlowChangeEntityState Init(ChangeEntityState param)
		{
			this.Params = param;
			return this;
		}

		// Token: 0x06045189 RID: 283017 RVA: 0x01205FC4 File Offset: 0x012041C4
		protected unsafe override void OnExecute()
		{
			ChangeEntityState @params = this.Params;
			EChangeEntityState? echangeEntityState = (@params != null) ? new EChangeEntityState?(@params.Type) : null;
			if (echangeEntityState != null)
			{
				switch (echangeEntityState.GetValueOrDefault())
				{
				case EChangeEntityState.Directly:
				{
					this.StateId = GameplayTagUtils.GetTagIdByName((@params as IChangeEntityStateDirectly).State);
					int num = 1;
					List<int> list = new List<int>(num);
					CollectionsMarshal.SetCount<int>(list, num);
					Span<int> span = CollectionsMarshal.AsSpan<int>(list);
					int index = 0;
					*span[index] = @params.EntityId;
					this.EntityIds = list;
					break;
				}
				case EChangeEntityState.BatchDirectly:
				{
					this.StateId = GameplayTagUtils.GetTagIdByName((@params as IChangeEntityStateBatchDirectly).State);
					IChangeEntityStateBatchDirectly changeEntityStateBatchDirectly = @params as IChangeEntityStateBatchDirectly;
					this.EntityIds = ((changeEntityStateBatchDirectly != null) ? changeEntityStateBatchDirectly.EntityIds : null);
					break;
				}
				case EChangeEntityState.Loop:
					Singleton<global::Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "不支持的切换实体状态", default(ReadOnlySpan<ValueTuple<string, object>>));
					break;
				}
			}
			if (this.EntityIds != null)
			{
				base.CreateWaitEntityTask(this.EntityIds);
				return;
			}
			base.FinishExecute(true);
		}

		// Token: 0x0604518A RID: 283018 RVA: 0x012060DC File Offset: 0x012042DC
		protected override void ExecuteWhenEntitiesReady()
		{
			foreach (int pbDataId in this.EntityIds)
			{
				LevelGeneralCommons.PrechangeStateTag(pbDataId, this.StateId, "ShowInRefSequence");
			}
			base.FinishExecute(true);
		}

		// Token: 0x040268E9 RID: 157929
		private ChangeEntityState Params;

		// Token: 0x040268EA RID: 157930
		private int StateId;

		// Token: 0x040268EB RID: 157931
		private List<int> EntityIds;
	}
}
