using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006522 RID: 25890
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipTaskView : UiViewBase
	{
		// Token: 0x06040BF9 RID: 265209 RVA: 0x0109A7CC File Offset: 0x010989CC
		public RhythmShipTaskView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040BFA RID: 265210 RVA: 0x0109A7E0 File Offset: 0x010989E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06040BFB RID: 265211 RVA: 0x0109A866 File Offset: 0x01098A66
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipTaskRefresh, new Action(this.OnRhythmShipTaskRefresh));
		}

		// Token: 0x06040BFC RID: 265212 RVA: 0x0109A884 File Offset: 0x01098A84
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipTaskRefresh, new Action(this.OnRhythmShipTaskRefresh));
		}

		// Token: 0x06040BFD RID: 265213 RVA: 0x0109A8A4 File Offset: 0x01098AA4
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipTaskView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipTaskView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040BFE RID: 265214 RVA: 0x0109A8E8 File Offset: 0x01098AE8
		protected override void OnStart()
		{
			List<int> rhythmShipTaskIdByTypeAndActivityId = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskIdByTypeAndActivityId(0, ModelBase<RhythmShipModel>.Instance.ActivityId);
			int num = 0;
			foreach (int num2 in rhythmShipTaskIdByTypeAndActivityId)
			{
				RhythmTask? rhythmTask;
				int? num3 = (ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskById(num2) != null) ? new int?(rhythmTask.GetValueOrDefault().TaskTab) : null;
				if (num3 != null && num3.Value != 0)
				{
					if (num == 0)
					{
						num = num3.Value;
					}
					List<int> list;
					if (!this.TaskTabMap.TryGetValue(num3.Value, out list))
					{
						list = new List<int>();
					}
					list.Add(num2);
					this.TaskTabMap[num3.Value] = list;
				}
			}
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			LoopScrollView<RhythmShipTaskTabItem, int> taskTabScrollView = this.TaskTabScrollView;
			if (taskTabScrollView == null)
			{
				return;
			}
			taskTabScrollView.RefreshByData(activityData.TaskTabList, true, delegate
			{
				this.TaskTabScrollView.SelectGridProxy(0, false);
			}, true);
		}

		// Token: 0x06040BFF RID: 265215 RVA: 0x0109AA10 File Offset: 0x01098C10
		private void OnClickTaskTab(int tabId, UUIExtendToggle toggle)
		{
			if (this.CurrentTabId == tabId)
			{
				return;
			}
			this.CurrentTabId = tabId;
			UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
			if (currentSelectToggle != null)
			{
				currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentSelectToggle = toggle;
			this.RefreshTaskScrollView();
		}

		// Token: 0x06040C00 RID: 265216 RVA: 0x0109AA48 File Offset: 0x01098C48
		private void RefreshTaskScrollView()
		{
			List<int> list;
			this.TaskTabMap.TryGetValue(this.CurrentTabId, out list);
			list = (list ?? new List<int>());
			List<int> data = ModelBase<RhythmShipModel>.Instance.SortTaskItem(list, false);
			GenericScrollViewNew<RhythmShipTaskItem, int> taskScrollView = this.TaskScrollView;
			if (taskScrollView == null)
			{
				return;
			}
			taskScrollView.RefreshByData(data, null, true);
		}

		// Token: 0x06040C01 RID: 265217 RVA: 0x0109AA94 File Offset: 0x01098C94
		private void OnRhythmShipTaskRefresh()
		{
			this.RefreshTaskScrollView();
		}

		// Token: 0x040244F7 RID: 148727
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040244F8 RID: 148728
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<RhythmShipTaskItem, int> TaskScrollView;

		// Token: 0x040244F9 RID: 148729
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<RhythmShipTaskTabItem, int> TaskTabScrollView;

		// Token: 0x040244FA RID: 148730
		private readonly Dictionary<int, List<int>> TaskTabMap = new Dictionary<int, List<int>>();

		// Token: 0x040244FB RID: 148731
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x040244FC RID: 148732
		private int CurrentTabId;
	}
}
