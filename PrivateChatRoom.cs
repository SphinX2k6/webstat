using System;
using System.Runtime.CompilerServices;

// Token: 0x02001848 RID: 6216
[NullableContext(1)]
[Nullable(0)]
public class PrivateChatRoom : ChatRoom
{
	// Token: 0x0600B1CF RID: 45519 RVA: 0x002F693A File Offset: 0x002F4B3A
	public PrivateChatRoom(int targetPlayerId, int configId) : base(EChatRoomType.Private, configId)
	{
		this.TargetPlayerId = targetPlayerId;
	}

	// Token: 0x0600B1D0 RID: 45520 RVA: 0x002F694B File Offset: 0x002F4B4B
	public FriendData GetFriendData()
	{
		return ModelBase<FriendModel>.Instance.GetFriendById(this.TargetPlayerId);
	}

	// Token: 0x0600B1D1 RID: 45521 RVA: 0x002F695D File Offset: 0x002F4B5D
	public int GetTargetPlayerId()
	{
		return this.TargetPlayerId;
	}

	// Token: 0x0600B1D2 RID: 45522 RVA: 0x002F6965 File Offset: 0x002F4B65
	public override int GetUniqueId()
	{
		return this.TargetPlayerId;
	}

	// Token: 0x0600B1D3 RID: 45523 RVA: 0x002F696D File Offset: 0x002F4B6D
	public string GetPlayerName()
	{
		FriendData friendData = this.GetFriendData();
		return ((friendData != null) ? friendData.PlayerName : null) ?? "";
	}

	// Token: 0x0600B1D4 RID: 45524 RVA: 0x002F698A File Offset: 0x002F4B8A
	public string GetPlayerRemarks()
	{
		FriendData friendData = this.GetFriendData();
		return ((friendData != null) ? friendData.FriendRemark : null) ?? "";
	}

	// Token: 0x0600B1D5 RID: 45525 RVA: 0x002F69A7 File Offset: 0x002F4BA7
	public bool IsOnline()
	{
		FriendData friendData = this.GetFriendData();
		return friendData != null && friendData.PlayerIsOnline;
	}

	// Token: 0x0600B1D6 RID: 45526 RVA: 0x002F69BA File Offset: 0x002F4BBA
	public string GetThirdPartyUserId()
	{
		FriendData friendData = this.GetFriendData();
		return ((friendData != null) ? friendData.GetSdkUserId() : null) ?? "";
	}

	// Token: 0x0600B1D7 RID: 45527 RVA: 0x002F69D7 File Offset: 0x002F4BD7
	[NullableContext(2)]
	public string GetThirdPartyOnlineId()
	{
		FriendData friendData = this.GetFriendData();
		if (friendData == null)
		{
			return null;
		}
		return friendData.GetSdkOnlineId();
	}

	// Token: 0x0600B1D8 RID: 45528 RVA: 0x002F69EC File Offset: 0x002F4BEC
	public bool CanChat()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		return !instance.HasBlockedPlayer(this.TargetPlayerId) && instance.HasFriend(this.TargetPlayerId);
	}

	// Token: 0x04005448 RID: 21576
	private readonly int TargetPlayerId;
}
