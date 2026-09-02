using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A01 RID: 6657
[NullableContext(1)]
[Nullable(0)]
public class PlayerTitleInfoTip : UiViewBase
{
	// Token: 0x0600BE81 RID: 48769 RVA: 0x0032706F File Offset: 0x0032526F
	public PlayerTitleInfoTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600BE82 RID: 48770 RVA: 0x00327084 File Offset: 0x00325284
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600BE83 RID: 48771 RVA: 0x00327190 File Offset: 0x00325390
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateNavigationListener, new Action(this.CloseTitleInfo));
		Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, new Action(this.CloseTitleInfo));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResetToBattleView, new Action(this.CloseTitleInfo));
		Singleton<EventSystem>.Instance.Add<ChatRoom, ChatContentData>(EEventName.OnAddChatContent, new Action<ChatRoom, ChatContentData>(this.OnAddChatContent));
	}

	// Token: 0x0600BE84 RID: 48772 RVA: 0x00327210 File Offset: 0x00325410
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateNavigationListener, new Action(this.CloseTitleInfo));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, new Action(this.CloseTitleInfo));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResetToBattleView, new Action(this.CloseTitleInfo));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddChatContent, new Action<ChatRoom, ChatContentData>(this.OnAddChatContent));
	}

	// Token: 0x0600BE85 RID: 48773 RVA: 0x0032728D File Offset: 0x0032548D
	private void OnAddChatContent(ChatRoom chatRoom, ChatContentData chatContent)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ChatView))
		{
			this.CloseTitleInfo();
		}
	}

	// Token: 0x0600BE86 RID: 48774 RVA: 0x003272A6 File Offset: 0x003254A6
	private void CloseTitleInfo()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600BE87 RID: 48775 RVA: 0x003272B0 File Offset: 0x003254B0
	protected override void OnBeforeShow()
	{
		PlayerTitleInfoTipParams playerTitleInfoTipParams = this.OpenParam as PlayerTitleInfoTipParams;
		this.ItemForLocation = playerTitleInfoTipParams.ItemForLocation;
		this.PlayerTitleInfoString = playerTitleInfoTipParams.PlayerTitleInfoString;
		USceneComponent item = base.GetItem(1);
		FHitResult fhitResult = new FHitResult();
		item.D_K2_SetWorldLocation(this.ItemForLocation.D_K2_GetComponentLocation(), false, ref fhitResult, true);
		this.UpdateText();
		UUITexture texture = base.GetTexture(4);
		if (!string.IsNullOrEmpty(playerTitleInfoTipParams.PlayerTitleInfoIcon))
		{
			texture.SetUIActive(true);
			base.SetTextureByPath(playerTitleInfoTipParams.PlayerTitleInfoIcon, texture, null, null);
			return;
		}
		texture.SetUIActive(false);
	}

	// Token: 0x0600BE88 RID: 48776 RVA: 0x00327343 File Offset: 0x00325543
	protected override void OnBeforeDestroy()
	{
		if (this.CloseCallback != null)
		{
			this.CloseCallback();
		}
	}

	// Token: 0x0600BE89 RID: 48777 RVA: 0x00327358 File Offset: 0x00325558
	private void OnBtnClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600BE8A RID: 48778 RVA: 0x00327361 File Offset: 0x00325561
	public void UpdateText()
	{
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(this.PlayerTitleInfoString, true);
	}

	// Token: 0x0600BE8B RID: 48779 RVA: 0x0032737B File Offset: 0x0032557B
	public void BindCloseCallback(Action closeCallback)
	{
		this.CloseCallback = closeCallback;
	}

	// Token: 0x04005996 RID: 22934
	[Nullable(2)]
	private UUIItem ItemForLocation;

	// Token: 0x04005997 RID: 22935
	private string PlayerTitleInfoString = "";

	// Token: 0x04005998 RID: 22936
	[Nullable(2)]
	private Action CloseCallback;

	// Token: 0x02007CEB RID: 31979
	[NullableContext(0)]
	private class EPlayerTitleInfoTipDefine
	{
		// Token: 0x0402A9D3 RID: 174547
		public const int ItemRoot = 0;

		// Token: 0x0402A9D4 RID: 174548
		public const int PanelInfoTip = 1;

		// Token: 0x0402A9D5 RID: 174549
		public const int TxtInfoTip = 2;

		// Token: 0x0402A9D6 RID: 174550
		public const int BtnMask = 3;

		// Token: 0x0402A9D7 RID: 174551
		public const int TextureIcon = 4;
	}
}
