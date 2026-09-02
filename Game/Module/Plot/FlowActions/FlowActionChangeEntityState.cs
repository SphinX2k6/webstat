using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.Flow;

namespace CSharpScript.Game.Module.Plot.FlowActions
{
	// Token: 0x02005415 RID: 21525
	public class FlowActionChangeEntityState : FlowActionBase
	{
		// Token: 0x06036F24 RID: 225060 RVA: 0x00DF27B4 File Offset: 0x00DF09B4
		protected unsafe override void OnExecute()
		{
			FlowActionChangeEntityState.<>c__DisplayClass0_0 CS$<>8__locals1 = new FlowActionChangeEntityState.<>c__DisplayClass0_0();
			CS$<>8__locals1.<>4__this = this;
			ChangeEntityState changeEntityState = this.ActionInfo.Params as ChangeEntityState;
			CS$<>8__locals1.id = null;
			CS$<>8__locals1.entityIds = new List<int>();
			switch (changeEntityState.Type)
			{
			case EChangeEntityState.Directly:
			{
				CS$<>8__locals1.id = new int?(GameplayTagUtils.GetTagIdByName(((IChangeEntityStateDirectly)changeEntityState).State));
				FlowActionChangeEntityState.<>c__DisplayClass0_0 CS$<>8__locals2 = CS$<>8__locals1;
				int num = 1;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount<int>(list, num);
				Span<int> span = CollectionsMarshal.AsSpan<int>(list);
				int index = 0;
				*span[index] = changeEntityState.EntityId;
				CS$<>8__locals2.entityIds = list;
				break;
			}
			case EChangeEntityState.BatchDirectly:
				CS$<>8__locals1.id = new int?(GameplayTagUtils.GetTagIdByName(((IChangeEntityStateBatchDirectly)changeEntityState).State));
				CS$<>8__locals1.entityIds = ((IChangeEntityStateBatchDirectly)changeEntityState).EntityIds;
				break;
			case EChangeEntityState.Loop:
				ControllerBase<FlowController>.Instance.LogError("不支持的切换实体状态", default(ReadOnlySpan<ValueTuple<string, object>>));
				break;
			}
			if (CS$<>8__locals1.id != null)
			{
				WaitEntityTask.CreateWithPbDataId("FlowActionChangeEntityState.OnExecute", CS$<>8__locals1.entityIds, delegate(bool? result)
				{
					foreach (int pbDataId in CS$<>8__locals1.entityIds)
					{
						EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
						if (entityByPbDataId != null && entityByPbDataId.IsInit)
						{
							LevelGeneralCommons.PrechangeStateTag(pbDataId, CS$<>8__locals1.id.Value, "ShowInPlotSequence");
						}
					}
					CS$<>8__locals1.<>4__this.FinishExecute(true, true);
				}, 60000, true, false);
				return;
			}
			base.FinishExecute(true, true);
		}
	}
}
