using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001855 RID: 6229
public class ChatTeamTipsContent : UiPanelBase
{
	// Token: 0x0600B22B RID: 45611 RVA: 0x002F8874 File Offset: 0x002F6A74
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B22C RID: 45612 RVA: 0x002F8940 File Offset: 0x002F6B40
	[NullableContext(1)]
	public void Refresh(ChatContentData data)
	{
		this.ChatContentData = data;
		ChatChannelNoticeType noticeType = this.ChatContentData.NoticeType;
		if (noticeType != ChatChannelNoticeType.EnterTeam)
		{
			if (noticeType == ChatChannelNoticeType.ExitTeam)
			{
				UUIItem item = base.GetItem(1);
				UUIItem item2 = base.GetItem(3);
				UUIText text = base.GetText(2);
				string senderPlayerName = this.ChatContentData.SenderPlayerName;
				item.SetUIActive(true);
				item2.SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalText(text, "PlayerLeaveTeam", new <>z__ReadOnlySingleElementList<object>(senderPlayerName));
			}
		}
		else
		{
			UUIItem item3 = base.GetItem(1);
			UUIItem item4 = base.GetItem(3);
			UUIText text2 = base.GetText(4);
			string senderPlayerName2 = this.ChatContentData.SenderPlayerName;
			item3.SetUIActive(false);
			item4.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text2, "PlayerEnterTeam", new <>z__ReadOnlySingleElementList<object>(senderPlayerName2));
		}
		this.RefreshTimeText();
	}

	// Token: 0x0600B22D RID: 45613 RVA: 0x002F8A08 File Offset: 0x002F6C08
	private void RefreshTimeText()
	{
		UUIText text = base.GetText(0);
		double timeStamp = this.ChatContentData.TimeStamp;
		double lastTimeStamp = this.ChatContentData.LastTimeStamp;
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (timeStamp - lastTimeStamp < ModelBase<ChatModel>.Instance.ShowTimeDifferent && lastTimeStamp != 0.0)
		{
			text.SetUIActive(false);
			return;
		}
		DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp(timeStamp);
		DateTime dataFromTimeStamp2 = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp(serverTime);
		if (dataFromTimeStamp.Day == dataFromTimeStamp2.Day)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "HourText", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Hour,
				dataFromTimeStamp.Minute
			}));
			text.SetUIActive(true);
			return;
		}
		if (dataFromTimeStamp.Day != dataFromTimeStamp2.Day && dataFromTimeStamp.Year == dataFromTimeStamp2.Year)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "DayText", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Month,
				dataFromTimeStamp.Day,
				dataFromTimeStamp.Hour,
				dataFromTimeStamp.Minute
			}));
			text.SetUIActive(true);
			return;
		}
		if (dataFromTimeStamp.Year != dataFromTimeStamp2.Year)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "YearText", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Year,
				dataFromTimeStamp.Month,
				dataFromTimeStamp.Day,
				dataFromTimeStamp.Hour,
				dataFromTimeStamp.Minute
			}));
			text.SetUIActive(true);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x04005468 RID: 21608
	[Nullable(2)]
	private ChatContentData ChatContentData;

	// Token: 0x02007BF5 RID: 31733
	private class EChildType
	{
		// Token: 0x0402A5A5 RID: 173477
		public const int TimeText = 0;

		// Token: 0x0402A5A6 RID: 173478
		public const int LeaveItem = 1;

		// Token: 0x0402A5A7 RID: 173479
		public const int LeaveText = 2;

		// Token: 0x0402A5A8 RID: 173480
		public const int EnterItem = 3;

		// Token: 0x0402A5A9 RID: 173481
		public const int EnterText = 4;
	}
}
