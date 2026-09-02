using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C9F RID: 7327
[NullableContext(1)]
[Nullable(0)]
public class FriendBlackListView : UiViewBase
{
	// Token: 0x0600D6C5 RID: 54981 RVA: 0x0039567D File Offset: 0x0039387D
	public FriendBlackListView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D6C6 RID: 54982 RVA: 0x00395694 File Offset: 0x00393894
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D6C7 RID: 54983 RVA: 0x0039573F File Offset: 0x0039393F
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBlackListShow, new Action(this.CallBackRefreshBlackListShow));
	}

	// Token: 0x0600D6C8 RID: 54984 RVA: 0x0039575D File Offset: 0x0039395D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateBlackListShow, new Action(this.CallBackRefreshBlackListShow));
	}

	// Token: 0x0600D6C9 RID: 54985 RVA: 0x0039577B File Offset: 0x0039397B
	protected override void OnStart()
	{
		this.ShowBlackListCount();
		this.BlackListLayout = new GenericScrollViewNew<FriendItem, FriendItemSt>(base.GetScrollViewWithScrollbar(2), new Func<FriendItem>(this.InitItem), null, false, null);
		ControllerBase<FriendController>.Instance.RequestBlackList();
	}

	// Token: 0x0600D6CA RID: 54986 RVA: 0x003957AE File Offset: 0x003939AE
	private FriendItem InitItem()
	{
		FriendItem friendItem = new FriendItem(this.ViewInfo.Name, null);
		friendItem.SetIsInBlackList(true);
		return friendItem;
	}

	// Token: 0x0600D6CB RID: 54987 RVA: 0x003957C8 File Offset: 0x003939C8
	private void RefreshShow()
	{
		this.BlackList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(ModelBase<FriendModel>.Instance.GetBlackListIds(), EFriendItemOperation.Default);
		this.BlackListLayout.RefreshByData(this.BlackList, null, false);
		this.ShowBlackListCount();
	}

	// Token: 0x0600D6CC RID: 54988 RVA: 0x00395800 File Offset: 0x00393A00
	private void ShowBlackListCount()
	{
		UUIText text = base.GetText(0);
		int? intConfig = ConfigCommonParamById.GetIntConfig("blocklist_limit");
		int count = this.BlackList.Count;
		Singleton<LguiUtil>.Instance.SetLocalText(text, "FriendBlackListCount", new <>z__ReadOnlyArray<object>(new object[]
		{
			count,
			intConfig
		}));
		base.GetItem(3).SetUIActive(this.BlackList.Count <= 0);
	}

	// Token: 0x0600D6CD RID: 54989 RVA: 0x00395876 File Offset: 0x00393A76
	private void CallBackRefreshBlackListShow()
	{
		this.RefreshShow();
	}

	// Token: 0x0600D6CE RID: 54990 RVA: 0x0039587E File Offset: 0x00393A7E
	protected override void OnBeforeDestroy()
	{
		this.BlackList.Clear();
		ModelBase<FriendModel>.Instance.ResetShowingView();
	}

	// Token: 0x040065DD RID: 26077
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<FriendItem, FriendItemSt> BlackListLayout;

	// Token: 0x040065DE RID: 26078
	private List<FriendItemSt> BlackList = new List<FriendItemSt>();

	// Token: 0x02007FF5 RID: 32757
	[NullableContext(0)]
	private class EFriendBlackListViewComponents
	{
		// Token: 0x0402B8A0 RID: 178336
		public const int BlackListVolume = 0;

		// Token: 0x0402B8A1 RID: 178337
		public const int BlackListItemModel = 1;

		// Token: 0x0402B8A2 RID: 178338
		public const int BlackListScrollView = 2;

		// Token: 0x0402B8A3 RID: 178339
		public const int BlackListEmptyItem = 3;
	}
}
