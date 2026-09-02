using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001C97 RID: 7319
[NullableContext(2)]
[Nullable(0)]
public class FriendBlackListData
{
	// Token: 0x0600D64E RID: 54862 RVA: 0x00393BEC File Offset: 0x00391DEC
	[NullableContext(1)]
	public UniTask InitializeFriendBlackListData(PlayerDetails blockedPlayer)
	{
		FriendBlackListData.<InitializeFriendBlackListData>d__1 <InitializeFriendBlackListData>d__;
		<InitializeFriendBlackListData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeFriendBlackListData>d__.<>4__this = this;
		<InitializeFriendBlackListData>d__.blockedPlayer = blockedPlayer;
		<InitializeFriendBlackListData>d__.<>1__state = -1;
		<InitializeFriendBlackListData>d__.<>t__builder.Start<FriendBlackListData.<InitializeFriendBlackListData>d__1>(ref <InitializeFriendBlackListData>d__);
		return <InitializeFriendBlackListData>d__.<>t__builder.Task;
	}

	// Token: 0x17001129 RID: 4393
	// (get) Token: 0x0600D64F RID: 54863 RVA: 0x00393C37 File Offset: 0x00391E37
	// (set) Token: 0x0600D650 RID: 54864 RVA: 0x00393C3F File Offset: 0x00391E3F
	public FriendData GetBlockedPlayerData
	{
		get
		{
			return this.PlayerData;
		}
		set
		{
			this.PlayerData = value;
		}
	}

	// Token: 0x040065A5 RID: 26021
	private FriendData PlayerData;
}
