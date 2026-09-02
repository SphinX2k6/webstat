using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Track
{
	// Token: 0x02004E7A RID: 20090
	[NullableContext(1)]
	[Nullable(0)]
	public static class TrackHelper
	{
		// Token: 0x06033E81 RID: 212609 RVA: 0x00CFD830 File Offset: 0x00CFBA30
		public static void SetMarkItemTrack(MarkItem markItem, [Nullable(2)] Action finishCallback = null)
		{
			TaskMarkItem taskMarkItem = markItem as TaskMarkItem;
			if (taskMarkItem != null)
			{
				TrackHelper.HandleTaskMarkItemTracking(taskMarkItem, finishCallback);
				return;
			}
			TrackHelper.HandleNormalMarkItemTracking(markItem, finishCallback);
		}

		// Token: 0x06033E82 RID: 212610 RVA: 0x00CFD858 File Offset: 0x00CFBA58
		private static void HandleTaskMarkItemTracking(TaskMarkItem taskMarkItem, [Nullable(2)] Action finishCallback)
		{
			if (taskMarkItem.NodeId != 0)
			{
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(taskMarkItem.InstanceDungeonId.GetValueOrDefault());
				int num = (config != null) ? config.GetValueOrDefault().RelatedQuestId : 0;
				int treeConfigId = taskMarkItem.TreeConfigId;
				QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
				if (!((num != 0) ? instance.IsTrackingQuest(num) : instance.IsTrackingQuest(treeConfigId)))
				{
					ControllerBase<QuestNewController>.Instance.RequestTrackQuest((num != 0) ? num : taskMarkItem.TreeConfigId, true, ERequestTrackOperate.Manual, ESetTrackReason.None, finishCallback);
					return;
				}
				if (finishCallback != null)
				{
					finishCallback();
					return;
				}
			}
			else
			{
				TrackHelper.HandleTaskMarkWithoutBehaviorId(taskMarkItem, finishCallback);
			}
		}

		// Token: 0x06033E83 RID: 212611 RVA: 0x00CFD8F4 File Offset: 0x00CFBAF4
		private static void HandleTaskMarkWithoutBehaviorId(TaskMarkItem taskMarkItem, [Nullable(2)] Action finishCallback)
		{
			TrackMapMarkParams curTrackMark = ModelBase<MapModel>.Instance.GetCurTrackMark();
			if (curTrackMark == null || curTrackMark.MarkId != taskMarkItem.MarkId)
			{
				ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
				{
					MarkType = EMarkType.Quest,
					MarkId = taskMarkItem.MarkId,
					Track = true
				}, delegate(ETrackMapMarkResultType result, bool track)
				{
					Action finishCallback3 = finishCallback;
					if (finishCallback3 == null)
					{
						return;
					}
					finishCallback3();
				});
				return;
			}
			Action finishCallback2 = finishCallback;
			if (finishCallback2 == null)
			{
				return;
			}
			finishCallback2();
		}

		// Token: 0x06033E84 RID: 212612 RVA: 0x00CFD97C File Offset: 0x00CFBB7C
		private static void HandleNormalMarkItemTracking(MarkItem markItem, [Nullable(2)] Action finishCallback)
		{
			if (!markItem.IsTracked)
			{
				ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
				{
					MarkType = markItem.MarkType,
					MarkId = markItem.MarkId,
					Track = true
				}, delegate(ETrackMapMarkResultType result, bool track)
				{
					Action finishCallback3 = finishCallback;
					if (finishCallback3 == null)
					{
						return;
					}
					finishCallback3();
				});
				return;
			}
			Action finishCallback2 = finishCallback;
			if (finishCallback2 == null)
			{
				return;
			}
			finishCallback2();
		}
	}
}
