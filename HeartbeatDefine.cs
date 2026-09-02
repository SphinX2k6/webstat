using System;

// Token: 0x020020EB RID: 8427
public class HeartbeatDefine
{
	// Token: 0x02008461 RID: 33889
	public enum EBeginHeartbeat
	{
		// Token: 0x0402CDAC RID: 183724
		GetLoginResponse,
		// Token: 0x0402CDAD RID: 183725
		ReConnectSuccess
	}

	// Token: 0x02008462 RID: 33890
	public enum EStopHeartbeat
	{
		// Token: 0x0402CDAF RID: 183727
		LogoutNotify,
		// Token: 0x0402CDB0 RID: 183728
		BeforeGetToken,
		// Token: 0x0402CDB1 RID: 183729
		LoginStatusInit,
		// Token: 0x0402CDB2 RID: 183730
		BackLoginView,
		// Token: 0x0402CDB3 RID: 183731
		ReconnectStart,
		// Token: 0x0402CDB4 RID: 183732
		BackLoginAndEnterGame
	}

	// Token: 0x02008463 RID: 33891
	public enum EHeartBeatType
	{
		// Token: 0x0402CDB6 RID: 183734
		NormalHeartBeat,
		// Token: 0x0402CDB7 RID: 183735
		BattleHeartBeat
	}

	// Token: 0x02008464 RID: 33892
	public class EHeartbeatConfig
	{
		// Token: 0x0402CDB8 RID: 183736
		public const int NormalHeartbeatTimeoutMaxCount = 3;

		// Token: 0x0402CDB9 RID: 183737
		public const int NormalHeartbeatInterval = 7000;

		// Token: 0x0402CDBA RID: 183738
		public const int NormalHeartbeatTimeout = 3000;

		// Token: 0x0402CDBB RID: 183739
		public const int BattleHeartbeatTimeoutMaxCount = 3;

		// Token: 0x0402CDBC RID: 183740
		public const int BattleHeartbeatInterval = 1000;

		// Token: 0x0402CDBD RID: 183741
		public const int BattleHeartbeatTimeout = 900;
	}
}
