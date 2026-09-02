using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006790 RID: 26512
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingTimeLimitView : UiTickViewBase
	{
		// Token: 0x06042163 RID: 270691 RVA: 0x010F4AEA File Offset: 0x010F2CEA
		public FishingTimeLimitView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042164 RID: 270692 RVA: 0x010F4B1C File Offset: 0x010F2D1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042165 RID: 270693 RVA: 0x010F4BE8 File Offset: 0x010F2DE8
		protected override UniTask OnBeforeStartAsync()
		{
			FishingTimeLimitView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingTimeLimitView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042166 RID: 270694 RVA: 0x010F4C2C File Offset: 0x010F2E2C
		private UniTask InitCaption()
		{
			FishingTimeLimitView.<InitCaption>d__12 <InitCaption>d__;
			<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaption>d__.<>4__this = this;
			<InitCaption>d__.<>1__state = -1;
			<InitCaption>d__.<>t__builder.Start<FishingTimeLimitView.<InitCaption>d__12>(ref <InitCaption>d__);
			return <InitCaption>d__.<>t__builder.Task;
		}

		// Token: 0x06042167 RID: 270695 RVA: 0x010F4C70 File Offset: 0x010F2E70
		private UniTask InitTabComponent()
		{
			FishingTimeLimitView.<InitTabComponent>d__13 <InitTabComponent>d__;
			<InitTabComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTabComponent>d__.<>4__this = this;
			<InitTabComponent>d__.<>1__state = -1;
			<InitTabComponent>d__.<>t__builder.Start<FishingTimeLimitView.<InitTabComponent>d__13>(ref <InitTabComponent>d__);
			return <InitTabComponent>d__.<>t__builder.Task;
		}

		// Token: 0x06042168 RID: 270696 RVA: 0x010F4CB3 File Offset: 0x010F2EB3
		private void InitTabViewComponent()
		{
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
		}

		// Token: 0x06042169 RID: 270697 RVA: 0x010F4CC8 File Offset: 0x010F2EC8
		protected override void OnStart()
		{
			this.RemainTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			this.RefreshTime();
		}

		// Token: 0x0604216A RID: 270698 RVA: 0x010F4CE1 File Offset: 0x010F2EE1
		protected override void OnBeforeShow()
		{
			this.RefreshTabItem();
		}

		// Token: 0x0604216B RID: 270699 RVA: 0x010F4CEC File Offset: 0x010F2EEC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingTimeLimitRewardListRefresh, new Action(this.RefreshTabItem));
			Singleton<EventSystem>.Instance.Add(EEventName.FishingTimeLimitRewardProgressRefresh, new Action(this.RefreshTabItem));
			Singleton<EventSystem>.Instance.Add(EEventName.FishingTimeLimitShopRefresh, new Action(this.RefreshTabItem));
		}

		// Token: 0x0604216C RID: 270700 RVA: 0x010F4D50 File Offset: 0x010F2F50
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingTimeLimitRewardListRefresh, new Action(this.RefreshTabItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingTimeLimitRewardProgressRefresh, new Action(this.RefreshTabItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingTimeLimitShopRefresh, new Action(this.RefreshTabItem));
		}

		// Token: 0x0604216D RID: 270701 RVA: 0x010F4DB1 File Offset: 0x010F2FB1
		private void InitTabList()
		{
			this.TabDataList = this.ActivityDataBase.GetRewardTabList();
			this.SetTabState(0, true, true);
		}

		// Token: 0x0604216E RID: 270702 RVA: 0x010F4DD0 File Offset: 0x010F2FD0
		private void RefreshTabItem()
		{
			bool timeLimitRewardRedDotState = this.ActivityDataBase.GetTimeLimitRewardRedDotState();
			bool limitTimeShopRedDotState = this.ActivityDataBase.GetLimitTimeShopRedDotState();
			this.TabItemList[0].SetRedDotVisible(timeLimitRewardRedDotState);
			this.TabItemList[1].SetRedDotVisible(limitTimeShopRedDotState);
		}

		// Token: 0x0604216F RID: 270703 RVA: 0x010F4E11 File Offset: 0x010F3011
		private void SetTabState(int index, bool state, bool bFireEvent)
		{
			this.TabItemList[index].SetToggleState(state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent);
		}

		// Token: 0x06042170 RID: 270704 RVA: 0x010F4E28 File Offset: 0x010F3028
		private void ToggleCallBack(int index)
		{
			if (index != this.CurrentTabIndex)
			{
				this.SetTabState(this.CurrentTabIndex, false, true);
			}
			this.CurrentTabIndex = index;
			UiDynamicTab data = this.TabDataList[index];
			this.SwitchTabView(data, index);
		}

		// Token: 0x06042171 RID: 270705 RVA: 0x010F4E68 File Offset: 0x010F3068
		private void SwitchTabView(UiDynamicTab data, int index)
		{
			EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
			this.TabViewComponent.ToggleCallBack(data, viewName, this.TabItemList[index], this.ActivityDataBase, null);
			string icon = data.Icon;
			if (icon != null)
			{
				this.CaptionItem.SetTitleIcon(icon);
			}
			string tabName = data.TabName;
			if (tabName != null)
			{
				this.CaptionItem.SetTitleByTextIdAndArgNew(tabName, Array.Empty<object>());
			}
		}

		// Token: 0x06042172 RID: 270706 RVA: 0x010F4ED9 File Offset: 0x010F30D9
		protected override void OnTick(float delta)
		{
			if (this.LimitTimeRewardOn)
			{
				this.RefreshTime();
			}
		}

		// Token: 0x06042173 RID: 270707 RVA: 0x010F4EEC File Offset: 0x010F30EC
		private void RefreshTime()
		{
			long limitTimeEndTime = this.ActivityDataBase.GetLimitTimeEndTime();
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if ((double)limitTimeEndTime - serverTime < 0.0)
			{
				this.LimitTimeRewardOn = false;
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(limitTimeEndTime, this.RemainTimeText);
			base.GetText(4).SetText(remainTimeText, true);
		}

		// Token: 0x04024D6B RID: 150891
		protected PopupCaptionItem CaptionItem;

		// Token: 0x04024D6C RID: 150892
		protected FishingRewardMainTabItem[] TabItemList = Array.Empty<FishingRewardMainTabItem>();

		// Token: 0x04024D6D RID: 150893
		[Nullable(2)]
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x04024D6E RID: 150894
		protected ActivityFishingData ActivityDataBase;

		// Token: 0x04024D6F RID: 150895
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x04024D70 RID: 150896
		private bool LimitTimeRewardOn = true;

		// Token: 0x04024D71 RID: 150897
		private string RemainTimeText = "";

		// Token: 0x04024D72 RID: 150898
		private int CurrentTabIndex;

		// Token: 0x0200C7B1 RID: 51121
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D79B RID: 251803
			public const int CaptionItem = 0;

			// Token: 0x0403D79C RID: 251804
			public const int ContentItem = 1;

			// Token: 0x0403D79D RID: 251805
			public const int ToggleReward = 2;

			// Token: 0x0403D79E RID: 251806
			public const int ToggleShop = 3;

			// Token: 0x0403D79F RID: 251807
			public const int TxtTime = 4;
		}
	}
}
