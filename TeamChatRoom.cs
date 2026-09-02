using System;

// Token: 0x02001849 RID: 6217
public class TeamChatRoom : TeamChatRoomBase
{
	// Token: 0x0600B1D9 RID: 45529 RVA: 0x002F6A20 File Offset: 0x002F4C20
	public TeamChatRoom(int configId) : base(EChatRoomType.Team, configId)
	{
	}

	// Token: 0x0600B1DA RID: 45530 RVA: 0x002F6A2A File Offset: 0x002F4C2A
	public override int GetUniqueId()
	{
		return 2;
	}
}
