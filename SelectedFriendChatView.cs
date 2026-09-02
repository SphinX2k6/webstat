using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200185B RID: 6235
public class SelectedFriendChatView : UiViewBase
{
	// Token: 0x0600B293 RID: 45715 RVA: 0x002FB50C File Offset: 0x002F970C
	[NullableContext(1)]
	public SelectedFriendChatView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B294 RID: 45716 RVA: 0x002FB518 File Offset: 0x002F9718
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B295 RID: 45717 RVA: 0x002FB5A4 File Offset: 0x002F97A4
	protected override void OnStart()
	{
		AUIBaseActor gridActor = base.GetItem(1).GetOwner() as AUIBaseActor;
		this.FriendLoopScrollView = new LoopScrollView<SelectedFriendItem, int>(base.GetLoopScrollViewComponent(0), gridActor, new Func<SelectedFriendItem>(this.OnGridProxyCreate), true);
		this.Refresh();
	}

	// Token: 0x0600B296 RID: 45718 RVA: 0x002FB5E9 File Offset: 0x002F97E9
	protected override void OnBeforeDestroy()
	{
		this.FriendLoopScrollView = null;
	}

	// Token: 0x0600B297 RID: 45719 RVA: 0x002FB5F4 File Offset: 0x002F97F4
	private void Refresh()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		ChatModel instance2 = ModelBase<ChatModel>.Instance;
		List<int> friendSortedListIds = instance.GetFriendSortedListIds();
		List<int> list = new List<int>();
		foreach (int num in friendSortedListIds)
		{
			if (!instance2.IsInPrivateChatRoom(num) && !instance.HasBlockedPlayer(num))
			{
				list.Add(num);
			}
		}
		this.FriendLoopScrollView.ReloadData(list, false);
		base.GetItem(2).SetUIActive(list.Count <= 0);
	}

	// Token: 0x0600B298 RID: 45720 RVA: 0x002FB694 File Offset: 0x002F9894
	[NullableContext(1)]
	private SelectedFriendItem OnGridProxyCreate()
	{
		SelectedFriendItem selectedFriendItem = new SelectedFriendItem();
		selectedFriendItem.BindOnClicked(new Action<int>(this.OnClickedFriendItem));
		return selectedFriendItem;
	}

	// Token: 0x0600B299 RID: 45721 RVA: 0x002FB6B0 File Offset: 0x002F98B0
	private void OnClickedFriendItem(int playerId)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Chat;
		ELogAuthor author = ELogAuthor.LJQ;
		string message = "选择玩家";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("playerId", playerId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!ModelBase<FriendModel>.Instance.IsMyFriend(playerId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("SelectChatNoFriendText", Array.Empty<object>());
			this.Refresh();
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnSelectChatFriend, playerId);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SelectedFriendChatView, null);
	}

	// Token: 0x0400547F RID: 21631
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<SelectedFriendItem, int> FriendLoopScrollView;

	// Token: 0x02007C01 RID: 31745
	private class EChildType
	{
		// Token: 0x0402A5ED RID: 173549
		public const int FriendLoopScrollView = 0;

		// Token: 0x0402A5EE RID: 173550
		public const int SourceFriendItem = 1;

		// Token: 0x0402A5EF RID: 173551
		public const int NoFriendItem = 2;
	}
}
