using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x0200697C RID: 27004
	[NullableContext(1)]
	[Nullable(0)]
	public class CyberPunkTaskView : UiViewBase
	{
		// Token: 0x06042FF1 RID: 274417 RVA: 0x0113373D File Offset: 0x0113193D
		public CyberPunkTaskView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042FF2 RID: 274418 RVA: 0x01133754 File Offset: 0x01131954
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickLook));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042FF3 RID: 274419 RVA: 0x011338C0 File Offset: 0x01131AC0
		protected override UniTask OnBeforeStartAsync()
		{
			CyberPunkTaskView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CyberPunkTaskView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042FF4 RID: 274420 RVA: 0x01133904 File Offset: 0x01131B04
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCyberPunkTaskRefresh, new Action(this.OnCyberPunkTaskRefresh));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
			ControllerBase<ActivityController>.Instance.RegisterRefreshTimerDelegate(new Action<float>(this.OnTimerRefresh));
		}

		// Token: 0x06042FF5 RID: 274421 RVA: 0x01133960 File Offset: 0x01131B60
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCyberPunkTaskRefresh, new Action(this.OnCyberPunkTaskRefresh));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
			ControllerBase<ActivityController>.Instance.UnregisterRefreshTimerDelegate(new Action<float>(this.OnTimerRefresh));
		}

		// Token: 0x06042FF6 RID: 274422 RVA: 0x011339BB File Offset: 0x01131BBB
		private void OnTimerRefresh(float delta)
		{
			this.RefreshTimerText();
		}

		// Token: 0x06042FF7 RID: 274423 RVA: 0x011339C3 File Offset: 0x01131BC3
		protected override void OnBeforeShow()
		{
			if (this.TabDataList.Count > 0)
			{
				this.RefreshView();
			}
		}

		// Token: 0x06042FF8 RID: 274424 RVA: 0x011339DC File Offset: 0x01131BDC
		private void OnCyberPunkTaskRefresh()
		{
			if (this.TabDataList.Count == 0)
			{
				this.InitTabData();
				if (this.TabDataList.Count == 0)
				{
					return;
				}
				this.RefreshView();
			}
			else
			{
				this.RefreshTaskList(this.TabDataList[this.SelectedTabIndex], false);
			}
			this.RefreshSliderItem();
		}

		// Token: 0x06042FF9 RID: 274425 RVA: 0x01133A30 File Offset: 0x01131C30
		private void OnRefreshRedDot(int activityId)
		{
			CyberPunkData currentActivityData = ControllerBase<CyberPunkController>.Instance.GetCurrentActivityData();
			if (currentActivityData != null && currentActivityData.Id == activityId)
			{
				this.RefreshSliderItem();
			}
		}

		// Token: 0x06042FFA RID: 274426 RVA: 0x01133A5C File Offset: 0x01131C5C
		private void OnClickTabItem(int tabId, CyberPunkTaskTabItem tabItem)
		{
			CyberPunkTaskTabItem selectTabItem = this.SelectTabItem;
			if (selectTabItem != null)
			{
				selectTabItem.SetSelected(false, false);
			}
			this.SelectTabItem = tabItem;
			this.SelectTabItem.SetSelected(true, false);
			CyberPunkTaskTabData cyberPunkTaskTabData = this.TabDataList.FirstOrDefault((CyberPunkTaskTabData t) => t.TabId == tabId);
			if (cyberPunkTaskTabData == null)
			{
				return;
			}
			int num = this.TabDataList.IndexOf(cyberPunkTaskTabData);
			if (this.SelectedTabIndex == num)
			{
				return;
			}
			this.SelectedTabIndex = num;
			this.RefreshTaskList(cyberPunkTaskTabData, true);
		}

		// Token: 0x06042FFB RID: 274427 RVA: 0x01133ADF File Offset: 0x01131CDF
		private void OnClaimSliderReward(int scoreId)
		{
			ControllerBase<CyberPunkController>.Instance.RequestScoreReward(scoreId, null);
		}

		// Token: 0x06042FFC RID: 274428 RVA: 0x01133AED File Offset: 0x01131CED
		private void OnClickBack()
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.CyberPunkTaskView, null);
		}

		// Token: 0x06042FFD RID: 274429 RVA: 0x01133B00 File Offset: 0x01131D00
		private void OnClickLook()
		{
			if (this.SliderItem == null)
			{
				return;
			}
			int currentItemId = this.SliderItem.GetCurrentItemId();
			if (currentItemId > 0)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(currentItemId, true, null);
			}
		}

		// Token: 0x06042FFE RID: 274430 RVA: 0x01133B34 File Offset: 0x01131D34
		private UniTask InitTopItem()
		{
			CyberPunkTaskView.<InitTopItem>d__22 <InitTopItem>d__;
			<InitTopItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTopItem>d__.<>4__this = this;
			<InitTopItem>d__.<>1__state = -1;
			<InitTopItem>d__.<>t__builder.Start<CyberPunkTaskView.<InitTopItem>d__22>(ref <InitTopItem>d__);
			return <InitTopItem>d__.<>t__builder.Task;
		}

		// Token: 0x06042FFF RID: 274431 RVA: 0x01133B78 File Offset: 0x01131D78
		private void InitTabLayout()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(1);
			this.TabLayout = new GenericLayout<CyberPunkTaskTabItem, CyberPunkTaskTabData>(verticalLayout, new Func<CyberPunkTaskTabItem>(this.OnCreateTabItem), null, false, true);
		}

		// Token: 0x06043000 RID: 274432 RVA: 0x01133BA8 File Offset: 0x01131DA8
		private void InitTaskScroll()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
			this.TaskScroll = new GenericScrollViewNew<CyberPunkTaskScrollItem, CyberPunkTaskData>(scrollViewWithScrollbar, new Func<CyberPunkTaskScrollItem>(this.OnCreateTaskItem), null, false, null);
			AUIBaseActor content = scrollViewWithScrollbar.GetContent();
			this.TaskScrollAnimController = (((content != null) ? content.GetComponentByClass(UUIInturnAnimController.StaticClass()) : null) as UUIInturnAnimController);
		}

		// Token: 0x06043001 RID: 274433 RVA: 0x01133C00 File Offset: 0x01131E00
		private UniTask InitSliderItem()
		{
			CyberPunkTaskView.<InitSliderItem>d__25 <InitSliderItem>d__;
			<InitSliderItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSliderItem>d__.<>4__this = this;
			<InitSliderItem>d__.<>1__state = -1;
			<InitSliderItem>d__.<>t__builder.Start<CyberPunkTaskView.<InitSliderItem>d__25>(ref <InitSliderItem>d__);
			return <InitSliderItem>d__.<>t__builder.Task;
		}

		// Token: 0x06043002 RID: 274434 RVA: 0x01133C43 File Offset: 0x01131E43
		private CyberPunkTaskTabItem OnCreateTabItem()
		{
			return new CyberPunkTaskTabItem
			{
				OnTabClickCallback = new Action<int, CyberPunkTaskTabItem>(this.OnClickTabItem)
			};
		}

		// Token: 0x06043003 RID: 274435 RVA: 0x01133C5C File Offset: 0x01131E5C
		private CyberPunkTaskScrollItem OnCreateTaskItem()
		{
			return new CyberPunkTaskScrollItem();
		}

		// Token: 0x06043004 RID: 274436 RVA: 0x01133C64 File Offset: 0x01131E64
		private void InitTabData()
		{
			CyberPunkData currentActivityData = ControllerBase<CyberPunkController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			this.TabDataList = currentActivityData.GetCyberPunkTaskTabDataList();
		}

		// Token: 0x06043005 RID: 274437 RVA: 0x01133C8C File Offset: 0x01131E8C
		private void RefreshView()
		{
			if (this.TabDataList.Count == 0)
			{
				return;
			}
			GenericLayout<CyberPunkTaskTabItem, CyberPunkTaskTabData> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.RefreshByData(this.TabDataList, delegate
				{
					this.InitializeSelectedTab();
				}, false);
			}
			this.RefreshTimerText();
		}

		// Token: 0x06043006 RID: 274438 RVA: 0x01133CC8 File Offset: 0x01131EC8
		private void InitializeSelectedTab()
		{
			if (this.TabDataList.Count == 0)
			{
				return;
			}
			int num = this.SelectedTabIndex;
			if (num < 0 || num >= this.TabDataList.Count)
			{
				num = 0;
			}
			CyberPunkTaskTabData tabData = this.TabDataList[num];
			GenericLayout<CyberPunkTaskTabItem, CyberPunkTaskTabData> tabLayout = this.TabLayout;
			CyberPunkTaskTabItem cyberPunkTaskTabItem = (tabLayout != null) ? tabLayout.GetLayoutItemByIndex(num) : null;
			if (cyberPunkTaskTabItem == null)
			{
				return;
			}
			for (int i = 0; i < this.TabDataList.Count; i++)
			{
				CyberPunkTaskTabData cyberPunkTaskTabData = this.TabDataList[i];
				GenericLayout<CyberPunkTaskTabItem, CyberPunkTaskTabData> tabLayout2 = this.TabLayout;
				CyberPunkTaskTabItem cyberPunkTaskTabItem2 = (tabLayout2 != null) ? tabLayout2.GetLayoutItemByIndex(i) : null;
				if (cyberPunkTaskTabItem2 != null)
				{
					cyberPunkTaskTabItem2.SetTabIconByTabId(cyberPunkTaskTabData.TabId);
				}
				if (cyberPunkTaskTabItem2 != null)
				{
					cyberPunkTaskTabItem2.SetSelected(i == num, false);
				}
			}
			this.SelectTabItem = cyberPunkTaskTabItem;
			this.SelectTabItem.SetSelected(true, false);
			this.SelectedTabIndex = num;
			this.RefreshTaskList(tabData, false);
		}

		// Token: 0x06043007 RID: 274439 RVA: 0x01133DA0 File Offset: 0x01131FA0
		private void RefreshTaskList(CyberPunkTaskTabData tabData, bool resetScroll = false)
		{
			CyberPunkData currentActivityData = ControllerBase<CyberPunkController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				GenericScrollViewNew<CyberPunkTaskScrollItem, CyberPunkTaskData> taskScroll = this.TaskScroll;
				if (taskScroll == null)
				{
					return;
				}
				taskScroll.RefreshByData(new List<CyberPunkTaskData>(), null, false);
				return;
			}
			else
			{
				List<CyberPunkTaskData> cyberPunkTaskListByTabId = currentActivityData.GetCyberPunkTaskListByTabId(tabData.TabId);
				GenericScrollViewNew<CyberPunkTaskScrollItem, CyberPunkTaskData> taskScroll2 = this.TaskScroll;
				if (taskScroll2 == null)
				{
					return;
				}
				taskScroll2.RefreshByData(cyberPunkTaskListByTabId, delegate
				{
					if (resetScroll)
					{
						this.ResetTaskScrollState();
					}
					this.PlayTaskScrollInturnAnimation();
				}, false);
				return;
			}
		}

		// Token: 0x06043008 RID: 274440 RVA: 0x01133E14 File Offset: 0x01132014
		private void ResetTaskScrollState()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(5);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.SetScrollProgress(0f);
			}
			if (this.TaskScroll != null)
			{
				foreach (CyberPunkTaskScrollItem cyberPunkTaskScrollItem in this.TaskScroll.GetScrollItemList())
				{
					cyberPunkTaskScrollItem.ResetScroll();
				}
			}
		}

		// Token: 0x06043009 RID: 274441 RVA: 0x01133E88 File Offset: 0x01132088
		private void PlayTaskScrollInturnAnimation()
		{
			UUIInturnAnimController taskScrollAnimController = this.TaskScrollAnimController;
			if (taskScrollAnimController == null)
			{
				return;
			}
			taskScrollAnimController.Play("", -1, false);
		}

		// Token: 0x0604300A RID: 274442 RVA: 0x01133EA4 File Offset: 0x011320A4
		private void RefreshSliderItem()
		{
			if (this.SliderItem == null)
			{
				return;
			}
			CyberPunkData currentActivityData = ControllerBase<CyberPunkController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			CyberPunkTaskSliderData cyberPunkTaskSliderData = currentActivityData.GetCyberPunkTaskSliderData();
			CyberPunkTaskData cyberPunkTaskData = new CyberPunkTaskData();
			cyberPunkTaskData.Id = cyberPunkTaskSliderData.Id;
			cyberPunkTaskData.Target = cyberPunkTaskSliderData.Target;
			cyberPunkTaskData.Current = cyberPunkTaskSliderData.Current;
			cyberPunkTaskData.Status = cyberPunkTaskSliderData.Status;
			this.SliderItem.Refresh(cyberPunkTaskData, false, 0);
		}

		// Token: 0x0604300B RID: 274443 RVA: 0x01133F14 File Offset: 0x01132114
		private void RefreshTimerText()
		{
			CyberPunkData currentActivityData = ControllerBase<CyberPunkController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				UUIText text = base.GetText(4);
				if (text == null)
				{
					return;
				}
				text.SetText("", true);
				return;
			}
			else
			{
				ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(currentActivityData, null);
				bool item = timeVisibleAndRemainTime.Item1;
				string item2 = timeVisibleAndRemainTime.Item2;
				if (item)
				{
					UUIText text2 = base.GetText(4);
					if (text2 == null)
					{
						return;
					}
					text2.SetText(item2, true);
					return;
				}
				else
				{
					UUIText text3 = base.GetText(4);
					if (text3 == null)
					{
						return;
					}
					text3.SetText("", true);
					return;
				}
			}
		}

		// Token: 0x0604300C RID: 274444 RVA: 0x01133F90 File Offset: 0x01132190
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "BackToBattleViewBtn"))
			{
				return null;
			}
			UActorComponent componentInChildren = ULGUIBPLibrary.GetComponentInChildren(base.GetRootActor(), TsUiHomeHelper.StaticClass(), false);
			AActor aactor = (componentInChildren != null) ? componentInChildren.GetOwner() : null;
			if (aactor == null)
			{
				return null;
			}
			UUIButtonComponent uuibuttonComponent = ULGUIBPLibrary.GetComponentInChildren(aactor, UUIButtonComponent.StaticClass(), false) as UUIButtonComponent;
			UUIItem uuiitem = (uuibuttonComponent != null) ? uuibuttonComponent.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04025514 RID: 152852
		[Nullable(2)]
		private CyberPunkTaskTopItem TopItem;

		// Token: 0x04025515 RID: 152853
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<CyberPunkTaskTabItem, CyberPunkTaskTabData> TabLayout;

		// Token: 0x04025516 RID: 152854
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<CyberPunkTaskScrollItem, CyberPunkTaskData> TaskScroll;

		// Token: 0x04025517 RID: 152855
		[Nullable(2)]
		private UUIInturnAnimController TaskScrollAnimController;

		// Token: 0x04025518 RID: 152856
		[Nullable(2)]
		private CyberPunkTaskSliderItem SliderItem;

		// Token: 0x04025519 RID: 152857
		private int SelectedTabIndex;

		// Token: 0x0402551A RID: 152858
		[Nullable(2)]
		private CyberPunkTaskTabItem SelectTabItem;

		// Token: 0x0402551B RID: 152859
		private List<CyberPunkTaskTabData> TabDataList = new List<CyberPunkTaskTabData>();

		// Token: 0x0200C922 RID: 51490
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x0403DDE2 RID: 253410
			public const int UiItemCaption = 0;

			// Token: 0x0403DDE3 RID: 253411
			public const int TabLayout = 1;

			// Token: 0x0403DDE4 RID: 253412
			public const int TogTab = 2;

			// Token: 0x0403DDE5 RID: 253413
			public const int BtnLook = 3;

			// Token: 0x0403DDE6 RID: 253414
			public const int TxtRemainTime = 4;

			// Token: 0x0403DDE7 RID: 253415
			public const int ScrollLayout = 5;

			// Token: 0x0403DDE8 RID: 253416
			public const int ScrollItem = 6;

			// Token: 0x0403DDE9 RID: 253417
			public const int DownRewardLayout = 7;
		}
	}
}
