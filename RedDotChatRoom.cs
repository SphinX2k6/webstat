using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003313 RID: 13075
public class RedDotChatRoom : RedDotBase
{
	// Token: 0x0601B5D5 RID: 112085 RVA: 0x0083548C File Offset: 0x0083368C
	protected override bool OnCheck(int uId = 0)
	{
		ChatRoom chatRoom;
		if (uId == 2)
		{
			chatRoom = ModelBase<ChatModel>.Instance.GetTeamChatRoom();
		}
		else if (uId == 3)
		{
			chatRoom = ModelBase<ChatModel>.Instance.GetWorldChatRoom();
		}
		else
		{
			chatRoom = ModelBase<ChatModel>.Instance.GetPrivateChatRoom(uId);
		}
		return chatRoom != null && chatRoom.GetIsShowRedDot();
	}

	// Token: 0x0601B5D6 RID: 112086 RVA: 0x008354D4 File Offset: 0x008336D4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRefreshChatRoomRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveFriend, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5D7 RID: 112087 RVA: 0x0083550E File Offset: 0x0083370E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRefreshChatRoomRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnRemoveFriend, new Action<int>(base.EventCheckWithUid));
	}
}
