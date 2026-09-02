using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.ViewComponent;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.ActivityListPanel
{
	// Token: 0x02004BE3 RID: 19427
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityListPanel : WorldMapSecondaryUi
	{
		// Token: 0x06032AF8 RID: 207608 RVA: 0x00CB1A1D File Offset: 0x00CAFC1D
		public override string GetResourceId()
		{
			return "UiView_CyclesActivitiesAssistant";
		}

		// Token: 0x06032AF9 RID: 207609 RVA: 0x00CB1A24 File Offset: 0x00CAFC24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032AFA RID: 207610 RVA: 0x00CB1AB0 File Offset: 0x00CAFCB0
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityListPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityListPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032AFB RID: 207611 RVA: 0x00CB1AF3 File Offset: 0x00CAFCF3
		protected override void OnStart()
		{
			this.PopupCaption.SetCloseCallBack(new Action(base.Close));
			this.PopupCaption.SetHelpBtnActive(false);
		}

		// Token: 0x06032AFC RID: 207612 RVA: 0x00CB1B18 File Offset: 0x00CAFD18
		protected override void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
			if (this.TimerId == null)
			{
				this.TimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.UpdateTimeInterval), 1000f, 1f, null, null, true);
			}
			this.RefreshActivityList();
		}

		// Token: 0x06032AFD RID: 207613 RVA: 0x00CB1B51 File Offset: 0x00CAFD51
		protected override void OnBeforeHide()
		{
			if (this.TimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
				this.TimerId = null;
			}
		}

		// Token: 0x06032AFE RID: 207614 RVA: 0x00CB1B73 File Offset: 0x00CAFD73
		private List<ActivityListPanelItemData> GetActivityDataList()
		{
			return (from data in ModelBase<WorldMapModel>.Instance.ActivityListData
			select new ActivityListPanelItemData
			{
				Data = data,
				OnClickCb = new Action(this.RefreshActivityList)
			}).ToList<ActivityListPanelItemData>();
		}

		// Token: 0x06032AFF RID: 207615 RVA: 0x00CB1B95 File Offset: 0x00CAFD95
		private void RefreshActivityList()
		{
			ModelBase<WorldMapModel>.Instance.UpdateActivityListItemData(false);
			if (this.ScrollView != null)
			{
				this.ScrollView.RefreshByDataAsync(this.GetActivityDataList(), false).Forget();
			}
		}

		// Token: 0x06032B00 RID: 207616 RVA: 0x00CB1BC4 File Offset: 0x00CAFDC4
		private void UpdateTimeInterval(float delta)
		{
			foreach (IActivityListItemData activityListItemData in ModelBase<WorldMapModel>.Instance.ActivityListData)
			{
				Action<IActivityListItemData> onLeftTimeRefreshCb = activityListItemData.OnLeftTimeRefreshCb;
				if (onLeftTimeRefreshCb != null)
				{
					onLeftTimeRefreshCb(activityListItemData);
				}
			}
			if (ModelBase<WorldMapModel>.Instance.ActivityListData.Any((IActivityListItemData data) => data.LeftTime <= 0.0))
			{
				ModelBase<WorldMapModel>.Instance.UpdateActivityListItemData(true);
				if (this.ScrollView != null)
				{
					this.ScrollView.RefreshByDataAsync(this.GetActivityDataList(), false).Forget();
					return;
				}
			}
			else
			{
				GenericScrollViewNew<ActivityListItem, ActivityListPanelItemData> scrollView = this.ScrollView;
				if (scrollView == null)
				{
					return;
				}
				scrollView.GetScrollItemList().ForEach(delegate(ActivityListItem item)
				{
					item.RefreshInfo();
				});
			}
		}

		// Token: 0x0401D831 RID: 120881
		private readonly PopupCaptionItem PopupCaption = new PopupCaptionItem(null);

		// Token: 0x0401D832 RID: 120882
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ActivityListItem, ActivityListPanelItemData> ScrollView;

		// Token: 0x0401D833 RID: 120883
		[Nullable(2)]
		private TimerHandle TimerId;

		// Token: 0x0200ACCA RID: 44234
		[NullableContext(0)]
		public static class EChildType
		{
			// Token: 0x04035AC0 RID: 219840
			public const int Caption = 0;

			// Token: 0x04035AC1 RID: 219841
			public const int ActivityScroller = 1;

			// Token: 0x04035AC2 RID: 219842
			public const int ActivityItem = 2;
		}
	}
}
