using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001C9A RID: 7322
[NullableContext(1)]
[Nullable(0)]
public class FriendData : IPlayerData
{
	// Token: 0x1700112D RID: 4397
	// (get) Token: 0x0600D65D RID: 54877 RVA: 0x00393D74 File Offset: 0x00391F74
	// (set) Token: 0x0600D65E RID: 54878 RVA: 0x00393D7C File Offset: 0x00391F7C
	public string Signature { get; set; } = "";

	// Token: 0x0600D65F RID: 54879 RVA: 0x00393D88 File Offset: 0x00391F88
	public UniTask SetFriendDataAttribute(FriendInfo friendInfo)
	{
		FriendData.<SetFriendDataAttribute>d__30 <SetFriendDataAttribute>d__;
		<SetFriendDataAttribute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetFriendDataAttribute>d__.<>4__this = this;
		<SetFriendDataAttribute>d__.friendInfo = friendInfo;
		<SetFriendDataAttribute>d__.<>1__state = -1;
		<SetFriendDataAttribute>d__.<>t__builder.Start<FriendData.<SetFriendDataAttribute>d__30>(ref <SetFriendDataAttribute>d__);
		return <SetFriendDataAttribute>d__.<>t__builder.Task;
	}

	// Token: 0x0600D660 RID: 54880 RVA: 0x00393DD4 File Offset: 0x00391FD4
	public UniTask SetPlayerBasicInfo(PlayerDetails friendInfo)
	{
		FriendData.<SetPlayerBasicInfo>d__31 <SetPlayerBasicInfo>d__;
		<SetPlayerBasicInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetPlayerBasicInfo>d__.<>4__this = this;
		<SetPlayerBasicInfo>d__.friendInfo = friendInfo;
		<SetPlayerBasicInfo>d__.<>1__state = -1;
		<SetPlayerBasicInfo>d__.<>t__builder.Start<FriendData.<SetPlayerBasicInfo>d__31>(ref <SetPlayerBasicInfo>d__);
		return <SetPlayerBasicInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0600D661 RID: 54881 RVA: 0x00393E20 File Offset: 0x00392020
	public UniTask RefreshSdkBlockState()
	{
		FriendData.<RefreshSdkBlockState>d__32 <RefreshSdkBlockState>d__;
		<RefreshSdkBlockState>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshSdkBlockState>d__.<>4__this = this;
		<RefreshSdkBlockState>d__.<>1__state = -1;
		<RefreshSdkBlockState>d__.<>t__builder.Start<FriendData.<RefreshSdkBlockState>d__32>(ref <RefreshSdkBlockState>d__);
		return <RefreshSdkBlockState>d__.<>t__builder.Task;
	}

	// Token: 0x1700112E RID: 4398
	// (get) Token: 0x0600D662 RID: 54882 RVA: 0x00393E63 File Offset: 0x00392063
	// (set) Token: 0x0600D663 RID: 54883 RVA: 0x00393E6B File Offset: 0x0039206B
	public int PlayerId
	{
		get
		{
			return this.Id;
		}
		set
		{
			this.Id = value;
		}
	}

	// Token: 0x1700112F RID: 4399
	// (get) Token: 0x0600D664 RID: 54884 RVA: 0x00393E74 File Offset: 0x00392074
	// (set) Token: 0x0600D665 RID: 54885 RVA: 0x00393E7C File Offset: 0x0039207C
	public string PlayerName
	{
		get
		{
			return this.Name;
		}
		set
		{
			this.Name = value;
		}
	}

	// Token: 0x17001130 RID: 4400
	// (get) Token: 0x0600D666 RID: 54886 RVA: 0x00393E85 File Offset: 0x00392085
	// (set) Token: 0x0600D667 RID: 54887 RVA: 0x00393E8D File Offset: 0x0039208D
	public int PlayerLevel
	{
		get
		{
			return this.Level;
		}
		set
		{
			this.Level = value;
		}
	}

	// Token: 0x17001131 RID: 4401
	// (get) Token: 0x0600D668 RID: 54888 RVA: 0x00393E96 File Offset: 0x00392096
	public int PlayerHeadPhoto
	{
		get
		{
			return this.HeadPhoto;
		}
	}

	// Token: 0x17001132 RID: 4402
	// (get) Token: 0x0600D669 RID: 54889 RVA: 0x00393E9E File Offset: 0x0039209E
	public int PlayerHeadFrame
	{
		get
		{
			return this.HeadFrame;
		}
	}

	// Token: 0x17001133 RID: 4403
	// (get) Token: 0x0600D66A RID: 54890 RVA: 0x00393EA6 File Offset: 0x003920A6
	public int PlayerTitleId
	{
		get
		{
			return this.TitleId;
		}
	}

	// Token: 0x17001134 RID: 4404
	// (get) Token: 0x0600D66B RID: 54891 RVA: 0x00393EAE File Offset: 0x003920AE
	public int PlayerTitleStarLevel
	{
		get
		{
			return this.TitleStarLevel;
		}
	}

	// Token: 0x17001135 RID: 4405
	// (get) Token: 0x0600D66C RID: 54892 RVA: 0x00393EB6 File Offset: 0x003920B6
	public int PlayerSex
	{
		get
		{
			return this.Sex;
		}
	}

	// Token: 0x17001136 RID: 4406
	// (get) Token: 0x0600D66D RID: 54893 RVA: 0x00393EBE File Offset: 0x003920BE
	// (set) Token: 0x0600D66E RID: 54894 RVA: 0x00393EC6 File Offset: 0x003920C6
	public bool PlayerIsOnline
	{
		get
		{
			return this.IsOnline;
		}
		set
		{
			this.IsOnline = value;
		}
	}

	// Token: 0x17001137 RID: 4407
	// (get) Token: 0x0600D66F RID: 54895 RVA: 0x00393ECF File Offset: 0x003920CF
	// (set) Token: 0x0600D670 RID: 54896 RVA: 0x00393ED7 File Offset: 0x003920D7
	public long PlayerLastOfflineTime
	{
		get
		{
			return this.LastOfflineTime;
		}
		set
		{
			this.LastOfflineTime = value;
		}
	}

	// Token: 0x0600D671 RID: 54897 RVA: 0x00393EE0 File Offset: 0x003920E0
	public int GetOfflineDay()
	{
		long playerLastOfflineTime = this.PlayerLastOfflineTime;
		return Singleton<TimeUtil>.Instance.CalculateDayTimeStampGapBetweenNow((double)playerLastOfflineTime, false);
	}

	// Token: 0x17001138 RID: 4408
	// (get) Token: 0x0600D672 RID: 54898 RVA: 0x00393F01 File Offset: 0x00392101
	// (set) Token: 0x0600D673 RID: 54899 RVA: 0x00393F09 File Offset: 0x00392109
	[Nullable(2)]
	public string FriendRemark
	{
		[NullableContext(2)]
		get
		{
			return this.Remark;
		}
		[NullableContext(2)]
		set
		{
			this.Remark = value;
		}
	}

	// Token: 0x17001139 RID: 4409
	// (get) Token: 0x0600D674 RID: 54900 RVA: 0x00393F12 File Offset: 0x00392112
	public bool IsDeactivation
	{
		get
		{
			return this.Deactivation;
		}
	}

	// Token: 0x0600D675 RID: 54901 RVA: 0x00393F1A File Offset: 0x0039211A
	[NullableContext(2)]
	public string GetSdkOnlineId()
	{
		return this.SdkOnlineId;
	}

	// Token: 0x0600D676 RID: 54902 RVA: 0x00393F22 File Offset: 0x00392122
	public string GetSdkUserId()
	{
		return this.SdkUserId;
	}

	// Token: 0x0600D677 RID: 54903 RVA: 0x00393F2A File Offset: 0x0039212A
	public string GetAvoidId()
	{
		return this.SdkAvoidId;
	}

	// Token: 0x0600D678 RID: 54904 RVA: 0x00393F34 File Offset: 0x00392134
	public bool IfSdkCanShowFriend()
	{
		bool sdkFriendOnlyState = ControllerBase<KuroSdkController>.Instance.GetSdkFriendOnlyState();
		bool flag = ControllerBase<KuroSdkController>.Instance.PlayOnly();
		return (!sdkFriendOnlyState && !flag) || (!sdkFriendOnlyState && !flag) || !(this.SdkUserId == "");
	}

	// Token: 0x0600D679 RID: 54905 RVA: 0x00393F7A File Offset: 0x0039217A
	public bool GetBlockBySdk()
	{
		return this.BlockBySdk;
	}

	// Token: 0x0600D67A RID: 54906 RVA: 0x00393F82 File Offset: 0x00392182
	public bool CanShowInFriendList()
	{
		return !this.GetBlockBySdk() && this.IfSdkCanShowFriend();
	}

	// Token: 0x040065AC RID: 26028
	private int Id;

	// Token: 0x040065AD RID: 26029
	private string Name = "";

	// Token: 0x040065AE RID: 26030
	private int Level;

	// Token: 0x040065AF RID: 26031
	private int HeadPhoto;

	// Token: 0x040065B0 RID: 26032
	private int HeadFrame;

	// Token: 0x040065B1 RID: 26033
	private int TitleId;

	// Token: 0x040065B2 RID: 26034
	private int TitleStarLevel;

	// Token: 0x040065B3 RID: 26035
	private int Sex;

	// Token: 0x040065B4 RID: 26036
	private bool IsOnline;

	// Token: 0x040065B5 RID: 26037
	private long LastOfflineTime;

	// Token: 0x040065B6 RID: 26038
	[Nullable(2)]
	private string Remark;

	// Token: 0x040065B7 RID: 26039
	public bool Debug;

	// Token: 0x040065B8 RID: 26040
	public int WorldLevel;

	// Token: 0x040065B9 RID: 26041
	public int TeamMemberCount;

	// Token: 0x040065BB RID: 26043
	public int CurCard;

	// Token: 0x040065BC RID: 26044
	public List<global::RoleShowEntry> RoleShowList = new List<global::RoleShowEntry>();

	// Token: 0x040065BD RID: 26045
	public List<int> CardShowList = new List<int>();

	// Token: 0x040065BE RID: 26046
	public int Birthday;

	// Token: 0x040065BF RID: 26047
	public bool IsBirthdayDisplay;

	// Token: 0x040065C0 RID: 26048
	public bool Deactivation;

	// Token: 0x040065C1 RID: 26049
	public List<PersonalCardData> CardUnlockList = new List<PersonalCardData>();

	// Token: 0x040065C2 RID: 26050
	private string SdkUserId = "";

	// Token: 0x040065C3 RID: 26051
	[Nullable(2)]
	private string SdkOnlineId = "";

	// Token: 0x040065C4 RID: 26052
	private bool BlockBySdk;

	// Token: 0x040065C5 RID: 26053
	private string SdkAccountId = "";

	// Token: 0x040065C6 RID: 26054
	private string SdkAvoidId = "";
}
