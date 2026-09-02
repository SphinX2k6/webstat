using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006660 RID: 26208
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiMotorParkourRewardView : UiTickViewBase
	{
		// Token: 0x06041722 RID: 268066 RVA: 0x010CBF3A File Offset: 0x010CA13A
		public MultiMotorParkourRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06041723 RID: 268067 RVA: 0x010CBF50 File Offset: 0x010CA150
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041724 RID: 268068 RVA: 0x010CC03D File Offset: 0x010CA23D
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
			Singleton<EventSystem>.Instance.Add(EEventName.MultiMotorRefresh, new Action(this.OnMultiMotorRefresh));
		}

		// Token: 0x06041725 RID: 268069 RVA: 0x010CC077 File Offset: 0x010CA277
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
			Singleton<EventSystem>.Instance.Remove(EEventName.MultiMotorRefresh, new Action(this.OnMultiMotorRefresh));
		}

		// Token: 0x06041726 RID: 268070 RVA: 0x010CC0B4 File Offset: 0x010CA2B4
		protected override UniTask OnBeforeStartAsync()
		{
			MultiMotorParkourRewardView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultiMotorParkourRewardView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041727 RID: 268071 RVA: 0x010CC0F8 File Offset: 0x010CA2F8
		protected override void OnTick(float delta)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, localTextNew);
			UUIText text = base.GetText(7);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x06041728 RID: 268072 RVA: 0x010CC13C File Offset: 0x010CA33C
		private void RefreshTaskLayout()
		{
			List<MultiMotorTaskData> taskList;
			if (this.CurTabData == 0)
			{
				taskList = this.ActivityData.GetGlobalTaskList();
			}
			else
			{
				MultiMotorLevelData multiMotorLevelData;
				this.ActivityData.LevelDataMap.TryGetValue(this.CurTabData, out multiMotorLevelData);
				taskList = (((multiMotorLevelData != null) ? multiMotorLevelData.TaskList : null) ?? new List<MultiMotorTaskData>());
			}
			this.TaskScrollView.RefreshByData(this.SortTaskList(taskList), false, delegate
			{
				this.TaskScrollView.ScrollToGridIndex(0, true);
			}, true);
		}

		// Token: 0x06041729 RID: 268073 RVA: 0x010CC1B0 File Offset: 0x010CA3B0
		private List<MultiMotorTaskData> SortTaskList(List<MultiMotorTaskData> taskList)
		{
			return taskList.OrderBy(delegate(MultiMotorTaskData task)
			{
				if (task.IsFinished)
				{
					return 0;
				}
				if (task.IsReceived)
				{
					return 2;
				}
				return 1;
			}).ThenBy((MultiMotorTaskData task) => task.TaskId).ToList<MultiMotorTaskData>();
		}

		// Token: 0x0604172A RID: 268074 RVA: 0x010CC20B File Offset: 0x010CA40B
		private void OnRefreshCommonActivityRedDot(int uid)
		{
			this.TabScrollView.RefreshAllGridProxies();
			this.RefreshTaskLayout();
		}

		// Token: 0x0604172B RID: 268075 RVA: 0x010CC21E File Offset: 0x010CA41E
		private void OnMultiMotorRefresh()
		{
			this.TabScrollView.RefreshAllGridProxies();
			this.RefreshTaskLayout();
		}

		// Token: 0x0604172C RID: 268076 RVA: 0x010CC234 File Offset: 0x010CA434
		private void OnTabClickCallBack(int data)
		{
			this.CurTabData = data;
			int gridIndex = this.TabList.IndexOf(data);
			this.TabScrollView.SelectGridProxy(gridIndex, false);
			this.RefreshTaskLayout();
		}

		// Token: 0x0604172D RID: 268077 RVA: 0x010CC268 File Offset: 0x010CA468
		private MultiMotorParkourTaskTabItem CreateTabItem()
		{
			return new MultiMotorParkourTaskTabItem
			{
				ActivityData = this.ActivityData,
				OnToggleCallback = new Action<int>(this.OnTabClickCallBack)
			};
		}

		// Token: 0x0604172E RID: 268078 RVA: 0x010CC28D File Offset: 0x010CA48D
		private MultiMotorParkourTaskItem OnCreateTaskItem()
		{
			return new MultiMotorParkourTaskItem();
		}

		// Token: 0x0604172F RID: 268079 RVA: 0x010CC294 File Offset: 0x010CA494
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024983 RID: 149891
		private MultiMotorData ActivityData;

		// Token: 0x04024984 RID: 149892
		private List<int> TabList = new List<int>();

		// Token: 0x04024985 RID: 149893
		private int CurTabData;

		// Token: 0x04024986 RID: 149894
		private LoopScrollView<MultiMotorParkourTaskTabItem, int> TabScrollView;

		// Token: 0x04024987 RID: 149895
		private LoopScrollView<MultiMotorParkourTaskItem, MultiMotorTaskData> TaskScrollView;

		// Token: 0x0200C682 RID: 50818
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D1F2 RID: 250354
			public const int ItemCaption = 0;

			// Token: 0x0403D1F3 RID: 250355
			public const int LoopScrollLayoutTab = 1;

			// Token: 0x0403D1F4 RID: 250356
			public const int ItemContent = 2;

			// Token: 0x0403D1F5 RID: 250357
			public const int ItemTab = 3;

			// Token: 0x0403D1F6 RID: 250358
			public const int LoopScrollLayoutTask = 4;

			// Token: 0x0403D1F7 RID: 250359
			public const int ItemContent2 = 5;

			// Token: 0x0403D1F8 RID: 250360
			public const int ItemTask = 6;

			// Token: 0x0403D1F9 RID: 250361
			public const int TextRemainTime = 7;
		}
	}
}
