using System;

// Token: 0x0200185D RID: 6237
public class WorldChatRoom : TeamChatRoomBase
{
	// Token: 0x0600B2A7 RID: 45735 RVA: 0x002FBB62 File Offset: 0x002F9D62
	public WorldChatRoom(int configId) : base(EChatRoomType.World, configId)
	{
	}

	// Token: 0x0600B2A8 RID: 45736 RVA: 0x002FBB6C File Offset: 0x002F9D6C
	public override int GetUniqueId()
	{
		return 3;
	}
}
