using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001C99 RID: 7321
[NullableContext(1)]
[Nullable(0)]
public class RecentlyTeamData
{
	// Token: 0x0600D65A RID: 54874 RVA: 0x00393CF4 File Offset: 0x00391EF4
	public UniTask InitData(RecentlyTeamInfo data)
	{
		RecentlyTeamData.<InitData>d__2 <InitData>d__;
		<InitData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitData>d__.<>4__this = this;
		<InitData>d__.data = data;
		<InitData>d__.<>1__state = -1;
		<InitData>d__.<>t__builder.Start<RecentlyTeamData.<InitData>d__2>(ref <InitData>d__);
		return <InitData>d__.<>t__builder.Task;
	}

	// Token: 0x0600D65B RID: 54875 RVA: 0x00393D40 File Offset: 0x00391F40
	public int GetOfflineDay()
	{
		long teamTime = this.TeamTime;
		return Singleton<TimeUtil>.Instance.CalculateDayTimeStampGapBetweenNow((double)teamTime, false);
	}

	// Token: 0x040065AA RID: 26026
	public FriendData PlayerData = new FriendData();

	// Token: 0x040065AB RID: 26027
	public long TeamTime;
}
