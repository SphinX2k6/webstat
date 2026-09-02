using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001C98 RID: 7320
[NullableContext(2)]
[Nullable(0)]
public class FriendApplyData
{
	// Token: 0x0600D652 RID: 54866 RVA: 0x00393C50 File Offset: 0x00391E50
	[NullableContext(1)]
	public UniTask InitializeFriendApply(FriendApply friendApply)
	{
		FriendApplyData.<InitializeFriendApply>d__4 <InitializeFriendApply>d__;
		<InitializeFriendApply>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeFriendApply>d__.<>4__this = this;
		<InitializeFriendApply>d__.friendApply = friendApply;
		<InitializeFriendApply>d__.<>1__state = -1;
		<InitializeFriendApply>d__.<>t__builder.Start<FriendApplyData.<InitializeFriendApply>d__4>(ref <InitializeFriendApply>d__);
		return <InitializeFriendApply>d__.<>t__builder.Task;
	}

	// Token: 0x1700112A RID: 4394
	// (get) Token: 0x0600D653 RID: 54867 RVA: 0x00393C9B File Offset: 0x00391E9B
	// (set) Token: 0x0600D654 RID: 54868 RVA: 0x00393CA3 File Offset: 0x00391EA3
	public long ApplyCreatedTime
	{
		get
		{
			return this.CreatedTime;
		}
		set
		{
			this.CreatedTime = value;
		}
	}

	// Token: 0x1700112B RID: 4395
	// (get) Token: 0x0600D655 RID: 54869 RVA: 0x00393CAC File Offset: 0x00391EAC
	// (set) Token: 0x0600D656 RID: 54870 RVA: 0x00393CB4 File Offset: 0x00391EB4
	public FriendData ApplyPlayerData
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

	// Token: 0x1700112C RID: 4396
	// (get) Token: 0x0600D657 RID: 54871 RVA: 0x00393CBD File Offset: 0x00391EBD
	// (set) Token: 0x0600D658 RID: 54872 RVA: 0x00393CD0 File Offset: 0x00391ED0
	public double ApplyTimeLeftTime
	{
		get
		{
			return this.ApplyTimeUpTime - Singleton<TimeUtil>.Instance.GetServerTime();
		}
		set
		{
			this.ApplyTimeUpTime = value + (double)ModelBase<FriendModel>.Instance.ApplyCdTime;
		}
	}

	// Token: 0x040065A6 RID: 26022
	private FriendData PlayerData;

	// Token: 0x040065A7 RID: 26023
	private long CreatedTime;

	// Token: 0x040065A8 RID: 26024
	public bool Fresh = true;

	// Token: 0x040065A9 RID: 26025
	private double ApplyTimeUpTime;
}
