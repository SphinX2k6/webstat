using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AD9 RID: 6873
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssCommonRewardView : UiViewBase
{
	// Token: 0x0600C5C2 RID: 50626 RVA: 0x00343A68 File Offset: 0x00341C68
	public DangoAbyssCommonRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C5C3 RID: 50627 RVA: 0x00343A84 File Offset: 0x00341C84
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600C5C4 RID: 50628 RVA: 0x00343BAE File Offset: 0x00341DAE
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C5C5 RID: 50629 RVA: 0x00343BBD File Offset: 0x00341DBD
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRewardStateUpdate, new Action(this.OnAbyssRewardStateUpdate));
	}

	// Token: 0x0600C5C6 RID: 50630 RVA: 0x00343BDB File Offset: 0x00341DDB
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRewardStateUpdate, new Action(this.OnAbyssRewardStateUpdate));
	}

	// Token: 0x0600C5C7 RID: 50631 RVA: 0x00343BF9 File Offset: 0x00341DF9
	private void OnCloseBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C5C8 RID: 50632 RVA: 0x00343C04 File Offset: 0x00341E04
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssCommonRewardView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssCommonRewardView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C5C9 RID: 50633 RVA: 0x00343C48 File Offset: 0x00341E48
	protected override void OnStart()
	{
		this.CurrentData = (this.OpenParam as DangoAbyssRewardViewData);
		int[] rewardTypeTabList = this.CurrentData.Data.GetRewardTypeTabList(2);
		if (rewardTypeTabList.Length != 0)
		{
			this.CurrentTabId = rewardTypeTabList[0];
		}
		for (int i = 0; i < rewardTypeTabList.Length; i++)
		{
			this.TabItemList[i].SetActive(true);
		}
		this.LoopScrollView = new LoopScrollView<DangoAbyssRewardItem, IActivityRewardData>(base.GetLoopScrollViewComponent(3), base.GetItem(5).GetOwner() as AUIBaseActor, new Func<DangoAbyssRewardItem>(this.CreateLoopItem), false);
	}

	// Token: 0x0600C5CA RID: 50634 RVA: 0x00343CD5 File Offset: 0x00341ED5
	private void OnAbyssRewardStateUpdate()
	{
		this.RefreshRewardLayout();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.CurrentData.Data.Id);
	}

	// Token: 0x0600C5CB RID: 50635 RVA: 0x00343D00 File Offset: 0x00341F00
	private void RefreshRewardLayout()
	{
		foreach (TabItem tabItem in this.TabItemList)
		{
			tabItem.RefreshRedDot();
		}
		IActivityRewardData[] taskActivityRewardDataList = this.CurrentData.Data.GetTaskActivityRewardDataList(2, this.CurrentTabId);
		this.LoopScrollView.RefreshByData(taskActivityRewardDataList.ToList<IActivityRewardData>(), false, null, true);
	}

	// Token: 0x0600C5CC RID: 50636 RVA: 0x00343D7C File Offset: 0x00341F7C
	private void RefreshTabLayout()
	{
		int[] rewardTypeTabList = this.CurrentData.Data.GetRewardTypeTabList(2);
		List<TabData> list = new List<TabData>();
		int num = rewardTypeTabList.Length;
		foreach (int tabId in rewardTypeTabList)
		{
			list.Add(new TabData
			{
				TabId = tabId,
				CurrentSelectTabId = this.CurrentTabId,
				ClickCallBack = new Action<int>(this.OnClickTab),
				ActivityData = this.CurrentData.Data
			});
		}
		for (int j = 0; j < num; j++)
		{
			this.TabItemList[j].Refresh(list[j], false, j);
		}
	}

	// Token: 0x0600C5CD RID: 50637 RVA: 0x00343E2F File Offset: 0x0034202F
	private void OnClickTab(int tabId)
	{
		this.CurrentTabId = tabId;
		this.RefreshRewardLayout();
		this.RefreshTabLayout();
	}

	// Token: 0x0600C5CE RID: 50638 RVA: 0x00343E44 File Offset: 0x00342044
	private DangoAbyssRewardItem CreateLoopItem()
	{
		return new DangoAbyssRewardItem();
	}

	// Token: 0x0600C5CF RID: 50639 RVA: 0x00343E4B File Offset: 0x0034204B
	protected override void OnBeforeShow()
	{
		this.CurrentTabId = ((this.CurrentData.Data.GetRewardTypeTabList(2).Length != 0) ? this.CurrentData.Data.GetRewardTypeTabList(2)[0] : 1);
		this.RefreshRewardLayout();
		this.RefreshTabLayout();
	}

	// Token: 0x04005EC7 RID: 24263
	private int CurrentTabId = 1;

	// Token: 0x04005EC8 RID: 24264
	[Nullable(2)]
	private DangoAbyssRewardViewData CurrentData;

	// Token: 0x04005EC9 RID: 24265
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<DangoAbyssRewardItem, IActivityRewardData> LoopScrollView;

	// Token: 0x04005ECA RID: 24266
	[Nullable(2)]
	private TabItem TabItem1;

	// Token: 0x04005ECB RID: 24267
	[Nullable(2)]
	private TabItem TabItem2;

	// Token: 0x04005ECC RID: 24268
	private readonly List<TabItem> TabItemList = new List<TabItem>();

	// Token: 0x02007DAD RID: 32173
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402ACD5 RID: 175317
		public const int BtnClose = 0;

		// Token: 0x0402ACD6 RID: 175318
		public const int TabItem1 = 1;

		// Token: 0x0402ACD7 RID: 175319
		public const int TabItem2 = 2;

		// Token: 0x0402ACD8 RID: 175320
		public const int LoopScroller = 3;

		// Token: 0x0402ACD9 RID: 175321
		public const int TabLayout = 4;

		// Token: 0x0402ACDA RID: 175322
		public const int ScrollerItem = 5;
	}
}
