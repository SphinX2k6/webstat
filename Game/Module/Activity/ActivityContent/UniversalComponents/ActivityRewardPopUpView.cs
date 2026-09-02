using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalComponents
{
	// Token: 0x02006250 RID: 25168
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityRewardPopUpView : UiViewBase
	{
		// Token: 0x0603F6FD RID: 259837 RVA: 0x0104340F File Offset: 0x0104160F
		public ActivityRewardPopUpView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F6FE RID: 259838 RVA: 0x01043424 File Offset: 0x01041624
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText))
			};
		}

		// Token: 0x0603F6FF RID: 259839 RVA: 0x010434D6 File Offset: 0x010416D6
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.RefreshByData));
		}

		// Token: 0x0603F700 RID: 259840 RVA: 0x010434F4 File Offset: 0x010416F4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.RefreshByData));
		}

		// Token: 0x0603F701 RID: 259841 RVA: 0x01043514 File Offset: 0x01041714
		protected override void OnStart()
		{
			this.Data = (this.OpenParam as IActivityRewardViewData);
			if (this.Data == null)
			{
				return;
			}
			this.ContentLayout = new GenericLayout<ActivityRewardPopUpContent, IActivityRewardData>(base.GetVerticalLayout(1), new Func<ActivityRewardPopUpContent>(this.InitContentItem), null, false, true);
			this.TabLayout = new GenericLayout<TabItem, IActivityTab>(base.GetHorizontalLayout(4), new Func<TabItem>(this.InitTabItem), null, false, true);
			base.GetText(6).SetUIActive(false);
			this.Refresh();
		}

		// Token: 0x0603F702 RID: 259842 RVA: 0x01043590 File Offset: 0x01041790
		protected ActivityRewardPopUpContent InitContentItem()
		{
			return new ActivityRewardPopUpContent
			{
				CloseViewFunction = delegate()
				{
					base.CloseMe(null);
				}
			};
		}

		// Token: 0x0603F703 RID: 259843 RVA: 0x010435A9 File Offset: 0x010417A9
		protected TabItem InitTabItem()
		{
			return new TabItem();
		}

		// Token: 0x0603F704 RID: 259844 RVA: 0x010435B0 File Offset: 0x010417B0
		protected void Refresh()
		{
			this.RefreshTab();
			this.RefreshTitle();
		}

		// Token: 0x0603F705 RID: 259845 RVA: 0x010435BE File Offset: 0x010417BE
		private void RefreshByData(IActivityRewardViewData data)
		{
			if (this.Data != null && data.Source != this.Data.Source)
			{
				return;
			}
			this.Data = data;
			this.Refresh();
		}

		// Token: 0x0603F706 RID: 259846 RVA: 0x010435F0 File Offset: 0x010417F0
		private void RefreshTab()
		{
			if (this.Data.DataPageList.Count == 0)
			{
				return;
			}
			List<IActivityTab> list = new List<IActivityTab>();
			bool flag = false;
			foreach (IActivityRewardDataPage activityRewardDataPage in this.Data.DataPageList)
			{
				if (!flag && activityRewardDataPage.TabName != null && !StringUtils.IsEmpty(activityRewardDataPage.TabName))
				{
					flag = true;
				}
				ActivityTab item = new ActivityTab
				{
					TabData = activityRewardDataPage,
					TabFunction = new Action<int>(this.TabFunction),
					TabCanExecuteFunction = new Func<bool, int, bool>(this.TabCanExecuteFunction)
				};
				list.Add(item);
			}
			GenericLayout<TabItem, IActivityTab> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.RefreshByData(list, delegate
				{
					TabItem layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex(this.SelectOnTabIndex);
					if (layoutItemByIndex == null)
					{
						return;
					}
					layoutItemByIndex.SetTabToggleState(true, new bool?(true));
				}, false);
			}
			base.GetItem(3).SetUIActive(flag);
		}

		// Token: 0x0603F707 RID: 259847 RVA: 0x010436DC File Offset: 0x010418DC
		private void RefreshList(List<IActivityRewardData> dataList)
		{
			this.DataList = dataList;
			GenericLayout<ActivityRewardPopUpContent, IActivityRewardData> contentLayout = this.ContentLayout;
			if (contentLayout == null)
			{
				return;
			}
			contentLayout.RefreshByData(this.DataList, null, false);
		}

		// Token: 0x0603F708 RID: 259848 RVA: 0x010436FD File Offset: 0x010418FD
		[NullableContext(2)]
		private void RefreshTips(bool show, string text = null)
		{
			if (!string.IsNullOrEmpty(text))
			{
				base.GetText(6).SetText(text, true);
			}
			base.GetText(6).SetUIActive(show);
		}

		// Token: 0x0603F709 RID: 259849 RVA: 0x01043722 File Offset: 0x01041922
		private void RefreshTitle()
		{
			if (!string.IsNullOrEmpty(this.Data.TitleTextId))
			{
				base.GetText(0).ShowTextNew(this.Data.TitleTextId);
				return;
			}
			base.GetText(0).ShowTextNew("PrefabTextItem_2743475244_Text");
		}

		// Token: 0x0603F70A RID: 259850 RVA: 0x01043760 File Offset: 0x01041960
		private void TabFunction(int tabId)
		{
			IActivityRewardDataPage activityRewardDataPage = this.Data.DataPageList[tabId];
			int selectOnTabIndex = this.SelectOnTabIndex;
			this.SelectOnTabIndex = tabId;
			if (selectOnTabIndex >= 0 && selectOnTabIndex != this.SelectOnTabIndex)
			{
				TabItem layoutItemByIndex = this.TabLayout.GetLayoutItemByIndex(selectOnTabIndex);
				if (layoutItemByIndex != null)
				{
					layoutItemByIndex.SetTabToggleState(false, new bool?(false));
				}
			}
			this.RefreshList(activityRewardDataPage.DataList);
			this.RefreshTips(activityRewardDataPage.TabTips != null, activityRewardDataPage.TabTips);
		}

		// Token: 0x0603F70B RID: 259851 RVA: 0x010437D9 File Offset: 0x010419D9
		private bool TabCanExecuteFunction(bool isSelected, int tabId)
		{
			return true;
		}

		// Token: 0x040239B8 RID: 145848
		[Nullable(2)]
		protected IActivityRewardViewData Data;

		// Token: 0x040239B9 RID: 145849
		protected List<IActivityRewardData> DataList = new List<IActivityRewardData>();

		// Token: 0x040239BA RID: 145850
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<ActivityRewardPopUpContent, IActivityRewardData> ContentLayout;

		// Token: 0x040239BB RID: 145851
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<TabItem, IActivityTab> TabLayout;

		// Token: 0x040239BC RID: 145852
		private int SelectOnTabIndex;
	}
}
