using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200651F RID: 25887
	public class RhythmShipTaskItem : GridProxyAbstract<int>
	{
		// Token: 0x06040BF4 RID: 265204 RVA: 0x0109A510 File Offset: 0x01098710
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnClickGetBtn))
			};
		}

		// Token: 0x06040BF5 RID: 265205 RVA: 0x0109A614 File Offset: 0x01098814
		protected override void OnStart()
		{
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(3), () => new CommonItemSmallItemGrid(), null, false, null);
		}

		// Token: 0x06040BF6 RID: 265206 RVA: 0x0109A670 File Offset: 0x01098870
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			RhythmTask? rhythmShipTaskById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskById(data);
			if (rhythmShipTaskById == null)
			{
				return;
			}
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rhythmShipTaskById.Value.TaskName, Array.Empty<object>());
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rhythmShipTaskById.Value.DropId);
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView != null)
			{
				rewardScrollView.RefreshByData(dropPackagePreviewItemList, null, false);
			}
			ConditionTask conditionTask;
			if (rhythmShipTaskById.Value.TaskType == 0)
			{
				activityData.TaskInfoMap.TryGetValue(data, out conditionTask);
			}
			else
			{
				activityData.LimitTaskInfoMap.TryGetValue(data, out conditionTask);
			}
			if (conditionTask == null)
			{
				return;
			}
			this.TaskId = data;
			UUIText text = base.GetText(2);
			int num = conditionTask.Current;
			text.SetText(num.ToString() + "/" + conditionTask.Target.ToString(), true);
			ConditionTaskState status = conditionTask.Status;
			base.GetButton(6).RootUIComp.Get().SetUIActive(status == ConditionTaskState.ConditionTaskFinish);
			base.GetItem(7).SetUIActive(status == ConditionTaskState.ConditionTaskRunning);
			base.GetItem(8).SetUIActive(status == ConditionTaskState.ConditionTaskTaken);
		}

		// Token: 0x06040BF7 RID: 265207 RVA: 0x0109A7B2 File Offset: 0x010989B2
		private void OnClickGetBtn()
		{
			ControllerBase<RhythmShipController>.Instance.RhythmTaskOneKeyRewardRequest(this.TaskId);
		}

		// Token: 0x040244EB RID: 148715
		private int TaskId;

		// Token: 0x040244EC RID: 148716
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;
	}
}
