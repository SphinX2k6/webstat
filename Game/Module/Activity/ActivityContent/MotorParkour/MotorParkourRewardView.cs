using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066C0 RID: 26304
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourRewardView : UiTickViewBase
	{
		// Token: 0x06041AD5 RID: 269013 RVA: 0x010D77F2 File Offset: 0x010D59F2
		public MotorParkourRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041AD6 RID: 269014 RVA: 0x010D7808 File Offset: 0x010D5A08
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

		// Token: 0x06041AD7 RID: 269015 RVA: 0x010D78F5 File Offset: 0x010D5AF5
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06041AD8 RID: 269016 RVA: 0x010D7913 File Offset: 0x010D5B13
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06041AD9 RID: 269017 RVA: 0x010D7934 File Offset: 0x010D5B34
		protected override UniTask OnBeforeStartAsync()
		{
			MotorParkourRewardView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorParkourRewardView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041ADA RID: 269018 RVA: 0x010D7978 File Offset: 0x010D5B78
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

		// Token: 0x06041ADB RID: 269019 RVA: 0x010D79BC File Offset: 0x010D5BBC
		private void RefreshTaskLayout()
		{
			List<MotorParkourTaskData> taskList = this.CurLevelData.TaskList;
			this.TaskScrollView.RefreshByData(taskList, false, delegate
			{
				this.TaskScrollView.ScrollToGridIndex(0, true);
			}, true);
		}

		// Token: 0x06041ADC RID: 269020 RVA: 0x010D79EF File Offset: 0x010D5BEF
		private void OnRefreshCommonActivityRedDot(int _)
		{
			this.TabScrollView.RefreshAllGridProxies();
			this.RefreshTaskLayout();
		}

		// Token: 0x06041ADD RID: 269021 RVA: 0x010D7A04 File Offset: 0x010D5C04
		private void OnTabClickCallBack(MotorParkourLevelData tab)
		{
			this.CurLevelData = tab2;
			int gridIndex = this.TabList.FindIndex((MotorParkourLevelData tab) => tab.Id == this.CurLevelData.Id);
			this.TabScrollView.SelectGridProxy(gridIndex, false);
			this.RefreshTaskLayout();
		}

		// Token: 0x06041ADE RID: 269022 RVA: 0x010D7A43 File Offset: 0x010D5C43
		private MotorParkourTaskTabItem CreateTabItem()
		{
			return new MotorParkourTaskTabItem
			{
				OnToggleCallback = new Action<MotorParkourLevelData>(this.OnTabClickCallBack)
			};
		}

		// Token: 0x06041ADF RID: 269023 RVA: 0x010D7A5C File Offset: 0x010D5C5C
		private MotorParkourTaskItem OnCreateTaskItem()
		{
			return new MotorParkourTaskItem();
		}

		// Token: 0x06041AE0 RID: 269024 RVA: 0x010D7A63 File Offset: 0x010D5C63
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024A88 RID: 150152
		private MotorParkourActivityData ActivityData;

		// Token: 0x04024A89 RID: 150153
		private List<MotorParkourLevelData> TabList = new List<MotorParkourLevelData>();

		// Token: 0x04024A8A RID: 150154
		private MotorParkourLevelData CurLevelData;

		// Token: 0x04024A8B RID: 150155
		private LoopScrollView<MotorParkourTaskTabItem, MotorParkourLevelData> TabScrollView;

		// Token: 0x04024A8C RID: 150156
		private LoopScrollView<MotorParkourTaskItem, MotorParkourTaskData> TaskScrollView;

		// Token: 0x0200C6EB RID: 50923
		public interface IMotorParkourRewardViewData
		{
			// Token: 0x1700AA57 RID: 43607
			// (get) Token: 0x0604EE27 RID: 323111
			// (set) Token: 0x0604EE28 RID: 323112
			MotorParkourActivityData ActivityData { get; set; }

			// Token: 0x1700AA58 RID: 43608
			// (get) Token: 0x0604EE29 RID: 323113
			// (set) Token: 0x0604EE2A RID: 323114
			MotorParkourLevelData SelectLevelData { get; set; }
		}

		// Token: 0x0200C6EC RID: 50924
		[Nullable(0)]
		public class MotorParkourRewardViewData : MotorParkourRewardView.IMotorParkourRewardViewData
		{
			// Token: 0x1700AA59 RID: 43609
			// (get) Token: 0x0604EE2B RID: 323115 RVA: 0x015F25F6 File Offset: 0x015F07F6
			// (set) Token: 0x0604EE2C RID: 323116 RVA: 0x015F25FE File Offset: 0x015F07FE
			public MotorParkourActivityData ActivityData { get; set; }

			// Token: 0x1700AA5A RID: 43610
			// (get) Token: 0x0604EE2D RID: 323117 RVA: 0x015F2607 File Offset: 0x015F0807
			// (set) Token: 0x0604EE2E RID: 323118 RVA: 0x015F260F File Offset: 0x015F080F
			public MotorParkourLevelData SelectLevelData { get; set; }
		}

		// Token: 0x0200C6ED RID: 50925
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3EB RID: 250859
			public const int ItemCaption = 0;

			// Token: 0x0403D3EC RID: 250860
			public const int LoopScrollLayoutTab = 1;

			// Token: 0x0403D3ED RID: 250861
			public const int ItemContent = 2;

			// Token: 0x0403D3EE RID: 250862
			public const int ItemTab = 3;

			// Token: 0x0403D3EF RID: 250863
			public const int LoopScrollLayoutTask = 4;

			// Token: 0x0403D3F0 RID: 250864
			public const int ItemContent2 = 5;

			// Token: 0x0403D3F1 RID: 250865
			public const int ItemTask = 6;

			// Token: 0x0403D3F2 RID: 250866
			public const int TextRemainTime = 7;
		}
	}
}
