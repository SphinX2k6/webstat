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

// Token: 0x02001853 RID: 6227
public class ChatOption : UiViewBase
{
	// Token: 0x0600B217 RID: 45591 RVA: 0x002F82F7 File Offset: 0x002F64F7
	[NullableContext(1)]
	public ChatOption(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B218 RID: 45592 RVA: 0x002F8300 File Offset: 0x002F6500
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickJoinBlackListButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickReportButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickPlayerInformationButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B219 RID: 45593 RVA: 0x002F8450 File Offset: 0x002F6650
	protected override void OnStart()
	{
		this.MutePlayerButton = new ChatOptionButton(base.GetItem(2));
		this.MutePlayerButton.SetClickCallBack(new Action(this.OnClickMutePlayerButton));
		this.PlayerId = (this.OpenParam as int?);
		this.FriendData = ModelBase<FriendModel>.Instance.GetFriendById(this.PlayerId.Value);
		if (this.FriendData == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "OptionTitle", new <>z__ReadOnlySingleElementList<object>(this.FriendData.PlayerName));
		this.RefreshMuteText();
	}

	// Token: 0x0600B21A RID: 45594 RVA: 0x002F84EE File Offset: 0x002F66EE
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAddMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
	}

	// Token: 0x0600B21B RID: 45595 RVA: 0x002F8528 File Offset: 0x002F6728
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveMutePlayer, new Action<int>(this.OnRefreshMutePlayer));
	}

	// Token: 0x0600B21C RID: 45596 RVA: 0x002F8564 File Offset: 0x002F6764
	private void OnRefreshMutePlayer(int playerId)
	{
		int? playerId2 = this.PlayerId;
		if (!(playerId == playerId2.GetValueOrDefault() & playerId2 != null))
		{
			return;
		}
		this.RefreshMuteText();
	}

	// Token: 0x0600B21D RID: 45597 RVA: 0x002F8593 File Offset: 0x002F6793
	protected override void OnBeforeDestroy()
	{
		this.PlayerId = null;
		this.FriendData = null;
	}

	// Token: 0x0600B21E RID: 45598 RVA: 0x002F85A8 File Offset: 0x002F67A8
	private void RefreshMuteText()
	{
		if (ModelBase<ChatModel>.Instance.IsInMute(this.PlayerId.Value))
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("CancelMuteText"), null);
			this.MutePlayerButton.RefreshButtonText(localTextNew);
			return;
		}
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("MuteText"), null);
		this.MutePlayerButton.RefreshButtonText(localTextNew2);
	}

	// Token: 0x0600B21F RID: 45599 RVA: 0x002F8614 File Offset: 0x002F6814
	private void OnClickMutePlayerButton()
	{
		if (ModelBase<ChatModel>.Instance.IsInMute(this.PlayerId.Value))
		{
			ControllerBase<ChatController>.Instance.ChatMutePlayerRequest(this.PlayerId.Value, false);
		}
		else
		{
			ControllerBase<ChatController>.Instance.ChatMutePlayerRequest(this.PlayerId.Value, true);
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatOption, null);
	}

	// Token: 0x0600B220 RID: 45600 RVA: 0x002F8678 File Offset: 0x002F6878
	private void OnClickJoinBlackListButton()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BlockFriend);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			this.FriendData.PlayerName
		});
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<FriendController>.Instance.RequestBlockPlayer(this.PlayerId.Value);
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatOption, null);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600B221 RID: 45601 RVA: 0x002F86CC File Offset: 0x002F68CC
	private void OnClickReportButton()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ChatOption, null);
		FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(this.PlayerId.Value);
		ControllerBase<ReportController>.Instance.OpenReportView(friendById, EReportSourceType.PrivateRoom);
	}

	// Token: 0x0600B222 RID: 45602 RVA: 0x002F870B File Offset: 0x002F690B
	private void OnClickPlayerInformationButton()
	{
		this.CheckOpenPersonalRootView().Forget();
	}

	// Token: 0x0600B223 RID: 45603 RVA: 0x002F8718 File Offset: 0x002F6918
	private UniTask CheckOpenPersonalRootView()
	{
		ChatOption.<CheckOpenPersonalRootView>d__16 <CheckOpenPersonalRootView>d__;
		<CheckOpenPersonalRootView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckOpenPersonalRootView>d__.<>4__this = this;
		<CheckOpenPersonalRootView>d__.<>1__state = -1;
		<CheckOpenPersonalRootView>d__.<>t__builder.Start<ChatOption.<CheckOpenPersonalRootView>d__16>(ref <CheckOpenPersonalRootView>d__);
		return <CheckOpenPersonalRootView>d__.<>t__builder.Task;
	}

	// Token: 0x04005464 RID: 21604
	private int? PlayerId;

	// Token: 0x04005465 RID: 21605
	[Nullable(2)]
	private FriendData FriendData;

	// Token: 0x04005466 RID: 21606
	[Nullable(2)]
	private ChatOptionButton MutePlayerButton;

	// Token: 0x02007BF2 RID: 31730
	private class EChildType
	{
		// Token: 0x0402A59A RID: 173466
		public const int TitleText = 0;

		// Token: 0x0402A59B RID: 173467
		public const int PlayerInformationButton = 1;

		// Token: 0x0402A59C RID: 173468
		public const int MutePlayerButton = 2;

		// Token: 0x0402A59D RID: 173469
		public const int JoinBlackListButton = 3;

		// Token: 0x0402A59E RID: 173470
		public const int ReportButton = 4;
	}
}
