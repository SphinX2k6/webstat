using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200185A RID: 6234
[NullableContext(1)]
[Nullable(0)]
public class QuickChatView : UiViewBase
{
	// Token: 0x0600B28A RID: 45706 RVA: 0x002FB09B File Offset: 0x002F929B
	public QuickChatView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B28B RID: 45707 RVA: 0x002FB0B0 File Offset: 0x002F92B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickCloseQuickChatButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B28C RID: 45708 RVA: 0x002FB198 File Offset: 0x002F9398
	protected override void OnStart()
	{
		this.ChatInputMaxNum = ConfigCommonParamById.GetIntConfig("chat_character").Value;
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(true);
		}
		this.CreateAllQuackChatText();
	}

	// Token: 0x0600B28D RID: 45709 RVA: 0x002FB1E4 File Offset: 0x002F93E4
	private void CreateAllQuackChatText()
	{
		IReadOnlyList<QuickChat> allQuickChatConfigList = ConfigBase<ChatConfig>.Instance.GetAllQuickChatConfigList();
		if (allQuickChatConfigList == null)
		{
			return;
		}
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(2);
		AActor owner = item.GetOwner();
		foreach (QuickChat quickChat in allQuickChatConfigList)
		{
			QuickChatText quickChatText = new QuickChatText(Singleton<LguiUtil>.Instance.DuplicateActor(owner, item2));
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(quickChat.QuickChatContent, null);
			quickChatText.Refresh(localTextNew);
			quickChatText.BindOnClicked(new Action<string>(this.OnQuickChatTextClicked));
			quickChatText.SetActive(true);
			this.QuickChatTextList.Add(quickChatText);
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600B28E RID: 45710 RVA: 0x002FB2AC File Offset: 0x002F94AC
	private void OnQuickChatTextClicked(string quickChatString)
	{
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Chat, ELogAuthor.LJQ, "当前没有加入任何一个聊天室", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		PrivateChatRoom privateChatRoom = joinedChatRoom as PrivateChatRoom;
		if (privateChatRoom != null)
		{
			int targetPlayerId = privateChatRoom.GetTargetPlayerId();
			if (targetPlayerId == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Chat;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "私聊对象玩家Id不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetPlayerId", targetPlayerId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
		}
		this.PrivateChatRequest(quickChatString, ChatContentType.Text);
		base.CloseMe(null);
	}

	// Token: 0x0600B28F RID: 45711 RVA: 0x002FB33C File Offset: 0x002F953C
	private void PrivateChatRequest(string text, ChatContentType chatContentType)
	{
		if (StringUtils.IsEmpty(text))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("InputChatContent", Array.Empty<object>());
			return;
		}
		if (text.Length > this.ChatInputMaxNum)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ReachInputMaxNum", new object[]
			{
				this.ChatInputMaxNum
			});
			return;
		}
		ChatRoom joinedChatRoom = ModelBase<ChatModel>.Instance.GetJoinedChatRoom();
		if (joinedChatRoom == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Chat, ELogAuthor.LJQ, "当前没有加入任何一个聊天室", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		double lastTimeStamp = joinedChatRoom.GetLastTimeStamp();
		if (Singleton<TimeUtil>.Instance.GetServerTime() - lastTimeStamp < (double)(joinedChatRoom.ChatCd / Singleton<TimeUtil>.Instance.InverseMillisecond))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ChatCdText", Array.Empty<object>());
			return;
		}
		PrivateChatRoom privateChatRoom = joinedChatRoom as PrivateChatRoom;
		if (privateChatRoom != null)
		{
			int targetPlayerId = privateChatRoom.GetTargetPlayerId();
			if (targetPlayerId == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Chat;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "私聊对象玩家Id不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetPlayerId", targetPlayerId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (ModelBase<FriendModel>.Instance.HasBlockedPlayer(targetPlayerId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ChatRefuseText", Array.Empty<object>());
				return;
			}
			ControllerBase<ChatController>.Instance.PrivateChatRequest(chatContentType, text, targetPlayerId);
			return;
		}
		else
		{
			if (joinedChatRoom is TeamChatRoom)
			{
				ControllerBase<ChatController>.Instance.ChannelChatRequest(chatContentType, text, SubChatChannelType.MatchTeam);
				return;
			}
			if (joinedChatRoom is WorldChatRoom)
			{
				ControllerBase<ChatController>.Instance.ChannelChatRequest(chatContentType, text, SubChatChannelType.WorldTeam);
			}
			return;
		}
	}

	// Token: 0x0600B290 RID: 45712 RVA: 0x002FB4A5 File Offset: 0x002F96A5
	private void OnClickCloseQuickChatButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600B291 RID: 45713 RVA: 0x002FB4AE File Offset: 0x002F96AE
	protected override void OnBeforeDestroy()
	{
		this.DestroyAllQuackChatText();
	}

	// Token: 0x0600B292 RID: 45714 RVA: 0x002FB4B8 File Offset: 0x002F96B8
	private void DestroyAllQuackChatText()
	{
		foreach (QuickChatText quickChatText in this.QuickChatTextList)
		{
			quickChatText.Destroy(null);
		}
	}

	// Token: 0x0400547D RID: 21629
	public int ChatInputMaxNum;

	// Token: 0x0400547E RID: 21630
	private readonly List<QuickChatText> QuickChatTextList = new List<QuickChatText>();

	// Token: 0x02007C00 RID: 31744
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A5E9 RID: 173545
		public const int QuickChatPanelItem = 0;

		// Token: 0x0402A5EA RID: 173546
		public const int CloseQuickChatButton = 1;

		// Token: 0x0402A5EB RID: 173547
		public const int QuickChatContentItem = 2;

		// Token: 0x0402A5EC RID: 173548
		public const int SourceQuickChatItem = 3;
	}
}
