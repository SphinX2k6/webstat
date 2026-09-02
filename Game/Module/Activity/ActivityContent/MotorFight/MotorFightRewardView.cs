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

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066F2 RID: 26354
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightRewardView : UiTickViewBase
	{
		// Token: 0x06041C86 RID: 269446 RVA: 0x010E0023 File Offset: 0x010DE223
		public MotorFightRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C87 RID: 269447 RVA: 0x010E002C File Offset: 0x010DE22C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C88 RID: 269448 RVA: 0x010E011C File Offset: 0x010DE31C
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightRewardView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightRewardView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C89 RID: 269449 RVA: 0x010E015F File Offset: 0x010DE35F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06041C8A RID: 269450 RVA: 0x010E017D File Offset: 0x010DE37D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06041C8B RID: 269451 RVA: 0x010E019C File Offset: 0x010DE39C
		protected override void OnTick(float delta)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, localTextNew);
			UUIText text = base.GetText(5);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x06041C8C RID: 269452 RVA: 0x010E01DF File Offset: 0x010DE3DF
		private void OnRefreshCommonActivityRedDot(int activityId)
		{
			if (activityId == this.ActivityData.Id)
			{
				this.TabLayout.RefreshByData(this.ActivityData.GetMotorFightTaskTabList(), delegate
				{
					this.OnTabClickCallBack(this.CurrentTabId);
				}, false);
			}
		}

		// Token: 0x06041C8D RID: 269453 RVA: 0x010E0212 File Offset: 0x010DE412
		private void RefreshTaskLayout(bool isPlayAnim = false)
		{
			this.TaskLayout.RefreshByData(this.ActivityData.GetTaskDataList(this.CurrentTabId), delegate
			{
				UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
				if (scrollViewWithScrollbar == null)
				{
					return;
				}
				scrollViewWithScrollbar.SetScrollProgress(0f);
			}, isPlayAnim);
		}

		// Token: 0x06041C8E RID: 269454 RVA: 0x010E023D File Offset: 0x010DE43D
		private MotorFightTaskTabItem CreateTabItem()
		{
			return new MotorFightTaskTabItem
			{
				ActivityData = this.ActivityData,
				OnToggleClickCallBack = new Action<int>(this.OnTabClickCallBack)
			};
		}

		// Token: 0x06041C8F RID: 269455 RVA: 0x010E0262 File Offset: 0x010DE462
		private void OnTabClickCallBack(int tabId)
		{
			this.CurrentTabId = tabId;
			this.TabLayout.SelectGridProxy(this.TabLayout.GetScrollItemByKey(tabId).GridIndex, false);
			this.RefreshTaskLayout(true);
		}

		// Token: 0x06041C90 RID: 269456 RVA: 0x010E0294 File Offset: 0x010DE494
		private MotorFightTaskItem CreateTaskItem()
		{
			return new MotorFightTaskItem
			{
				OnRewardBtnClick = new Action(this.OnRewardBtnClick)
			};
		}

		// Token: 0x06041C91 RID: 269457 RVA: 0x010E02AD File Offset: 0x010DE4AD
		private void OnRewardBtnClick()
		{
			this.ActivityData.RequestTaskReward(this.CurrentTabId);
		}

		// Token: 0x06041C92 RID: 269458 RVA: 0x010E02C0 File Offset: 0x010DE4C0
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024B2E RID: 150318
		[Nullable(2)]
		private MotorFightActivityData ActivityData;

		// Token: 0x04024B2F RID: 150319
		private int CurrentTabId;

		// Token: 0x04024B30 RID: 150320
		private GenericScrollViewNew<MotorFightTaskTabItem, MotorFightTaskTab> TabLayout;

		// Token: 0x04024B31 RID: 150321
		private GenericScrollViewNew<MotorFightTaskItem, MotorFightTaskData> TaskLayout;

		// Token: 0x0200C73A RID: 51002
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D55C RID: 251228
			public const int ItemCaption = 0;

			// Token: 0x0403D55D RID: 251229
			public const int ScrollLayoutTab = 1;

			// Token: 0x0403D55E RID: 251230
			public const int ItemTab = 2;

			// Token: 0x0403D55F RID: 251231
			public const int ScrollReward = 3;

			// Token: 0x0403D560 RID: 251232
			public const int ItemReward = 4;

			// Token: 0x0403D561 RID: 251233
			public const int TextRemainTime = 5;
		}
	}
}
