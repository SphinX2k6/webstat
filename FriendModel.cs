using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001C9C RID: 7324
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class FriendModel : ModelBase<FriendModel>
{
	// Token: 0x0600D67D RID: 54909 RVA: 0x00394014 File Offset: 0x00392214
	protected override bool OnInit()
	{
		this.ApplyCdTime = ConfigCommonParamById.GetIntConfig("apply_valid_time").Value;
		return base.OnInit();
	}

	// Token: 0x0600D67E RID: 54910 RVA: 0x00394040 File Offset: 0x00392240
	protected override bool OnClear()
	{
		this.CurrentSelectedPlayerId = null;
		this.FriendFilterState = null;
		this.CurrentlyShowingView = null;
		this.FriendSearchResults.Clear();
		this.CurrentApplyFriendList.Clear();
		this.CurrentApproveFriendList.Clear();
		this.CurrentRefuseFriendList.Clear();
		this.SaveLocalFriendApplication();
		return true;
	}

	// Token: 0x0600D67F RID: 54911 RVA: 0x003940A4 File Offset: 0x003922A4
	public void LoadLocalFriendApplication()
	{
		Dictionary<int, LocalFriendApplication> dictionary = LocalStorage.GetPlayer<Dictionary<int, LocalFriendApplication>>(ELocalStoragePlayerKey.LocalFriendApplication, null) ?? new Dictionary<int, LocalFriendApplication>();
		foreach (FriendApplyData friendApplyData in this.MyFriendApplyList.Values)
		{
			LocalFriendApplication localFriendApplication;
			if (dictionary.TryGetValue(friendApplyData.ApplyPlayerData.PlayerId, out localFriendApplication) && localFriendApplication.CreatedTime == friendApplyData.ApplyCreatedTime)
			{
				friendApplyData.Fresh = localFriendApplication.Fresh;
				if (!friendApplyData.Fresh)
				{
					this.FreshFriendApplicationIds.Remove(friendApplyData.ApplyPlayerData.PlayerId);
				}
			}
		}
	}

	// Token: 0x0600D680 RID: 54912 RVA: 0x00394158 File Offset: 0x00392358
	private void SaveLocalFriendApplication()
	{
		Dictionary<int, LocalFriendApplication> dictionary = new Dictionary<int, LocalFriendApplication>();
		foreach (int key in this.MyFriendApplyList.Keys)
		{
			dictionary[key] = new LocalFriendApplication
			{
				Fresh = this.MyFriendApplyList[key].Fresh,
				CreatedTime = this.MyFriendApplyList[key].ApplyCreatedTime
			};
		}
		LocalStorage.SetPlayer<Dictionary<int, LocalFriendApplication>>(ELocalStoragePlayerKey.LocalFriendApplication, dictionary);
	}

	// Token: 0x0600D681 RID: 54913 RVA: 0x003941F4 File Offset: 0x003923F4
	public int GetFriendListCount()
	{
		return this.MyFriends.Count;
	}

	// Token: 0x0600D682 RID: 54914 RVA: 0x00394204 File Offset: 0x00392404
	public List<int> GetFriendSortedListIds()
	{
		List<int> list = new List<int>();
		foreach (FriendData friendData in this.MyFriends.Values)
		{
			if (friendData.CanShowInFriendList())
			{
				list.Add(friendData.PlayerId);
			}
		}
		return ControllerBase<FriendController>.Instance.GetSortedFriendListByRules(list, new Func<int, int, int>(ControllerBase<FriendController>.Instance.FriendListSortHook));
	}

	// Token: 0x0600D683 RID: 54915 RVA: 0x0039428C File Offset: 0x0039248C
	public List<int> GetFriendApplyListIds()
	{
		List<int> list = new List<int>();
		foreach (FriendApplyData friendApplyData in this.MyFriendApplyList.Values)
		{
			if (friendApplyData.ApplyPlayerData != null && friendApplyData.ApplyPlayerData.CanShowInFriendList())
			{
				list.Add(friendApplyData.ApplyPlayerData.PlayerId);
			}
		}
		return ControllerBase<FriendController>.Instance.GetSortedBlackOrApplyList(list);
	}

	// Token: 0x0600D684 RID: 54916 RVA: 0x00394314 File Offset: 0x00392514
	public List<int> GetRecentlyTeamIds()
	{
		List<int> list = new List<int>();
		foreach (RecentlyTeamData recentlyTeamData in this.RecentlyTeamList.Values)
		{
			if (recentlyTeamData.PlayerData != null && recentlyTeamData.PlayerData.CanShowInFriendList())
			{
				list.Add(recentlyTeamData.PlayerData.PlayerId);
			}
		}
		list.Sort(delegate(int a, int b)
		{
			RecentlyTeamData recentlyTeamData2 = this.GetRecentlyTeamData(a);
			RecentlyTeamData recentlyTeamData3 = this.GetRecentlyTeamData(b);
			if (recentlyTeamData2.TeamTime > recentlyTeamData3.TeamTime)
			{
				return 1;
			}
			return -1;
		});
		return list;
	}

	// Token: 0x0600D685 RID: 54917 RVA: 0x003943A4 File Offset: 0x003925A4
	public bool HasNewFriendApplication()
	{
		return this.FreshFriendApplicationIds.Count > 0;
	}

	// Token: 0x0600D686 RID: 54918 RVA: 0x003943B4 File Offset: 0x003925B4
	public List<int> GetFriendSearchResultListIds()
	{
		List<int> list = new List<int>();
		foreach (FriendData friendData in this.FriendSearchResults.Values)
		{
			list.Add(friendData.PlayerId);
		}
		list.Sort(delegate(int a, int b)
		{
			FriendData friendById = this.GetFriendById(a);
			FriendData friendById2 = this.GetFriendById(b);
			return friendById.PlayerId - friendById2.PlayerId;
		});
		return list;
	}

	// Token: 0x0600D687 RID: 54919 RVA: 0x0039442C File Offset: 0x0039262C
	public List<int> GetBlackListIds()
	{
		List<int> list = new List<int>();
		foreach (int item in this.MyBlackList.Keys)
		{
			list.Add(item);
		}
		return ControllerBase<FriendController>.Instance.GetSortedBlackOrApplyList(list);
	}

	// Token: 0x0600D688 RID: 54920 RVA: 0x00394498 File Offset: 0x00392698
	[NullableContext(2)]
	public FriendData GetFriendById(int friendId)
	{
		if (friendId == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Friend, ELogAuthor.YZY, "获取选中玩家时id不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (!this.MyFriends.ContainsKey(friendId))
		{
			return null;
		}
		return this.MyFriends[friendId];
	}

	// Token: 0x0600D689 RID: 54921 RVA: 0x003944E5 File Offset: 0x003926E5
	[NullableContext(2)]
	public FriendData GetFriendDataInApplicationById(int playerId)
	{
		if (this.MyFriendApplyList.ContainsKey(playerId))
		{
			return this.MyFriendApplyList[playerId].ApplyPlayerData;
		}
		return null;
	}

	// Token: 0x0600D68A RID: 54922 RVA: 0x00394508 File Offset: 0x00392708
	[NullableContext(2)]
	public FriendBlackListData GetBlockedPlayerById(int playerId)
	{
		if (!this.MyBlackList.ContainsKey(playerId))
		{
			return null;
		}
		return this.MyBlackList[playerId];
	}

	// Token: 0x0600D68B RID: 54923 RVA: 0x00394526 File Offset: 0x00392726
	[NullableContext(2)]
	public FriendData GetFriendSearchResultById(int playerId)
	{
		if (!this.FriendSearchResults.ContainsKey(playerId))
		{
			return null;
		}
		return this.FriendSearchResults[playerId];
	}

	// Token: 0x0600D68C RID: 54924 RVA: 0x00394544 File Offset: 0x00392744
	public void AddFriend(FriendData friend)
	{
		this.MyFriends.TryAdd(friend.PlayerId, friend);
	}

	// Token: 0x0600D68D RID: 54925 RVA: 0x00394559 File Offset: 0x00392759
	public bool HasFriend(int id)
	{
		return this.MyFriends.ContainsKey(id);
	}

	// Token: 0x0600D68E RID: 54926 RVA: 0x00394567 File Offset: 0x00392767
	public void DeleteFriend(int id)
	{
		if (this.MyFriends.ContainsKey(id))
		{
			this.MyFriends.Remove(id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRemoveFriend, id);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFriendViewShow);
	}

	// Token: 0x0600D68F RID: 54927 RVA: 0x003945A5 File Offset: 0x003927A5
	public bool IsMyFriend(int id)
	{
		return this.MyFriends.ContainsKey(id);
	}

	// Token: 0x0600D690 RID: 54928 RVA: 0x003945B3 File Offset: 0x003927B3
	public void AddFriendApplication(FriendApplyData friendApply)
	{
		this.MyFriendApplyList[friendApply.ApplyPlayerData.PlayerId] = friendApply;
		if (friendApply.ApplyPlayerData.CanShowInFriendList())
		{
			this.FreshFriendApplicationIds.Add(friendApply.ApplyPlayerData.PlayerId);
		}
	}

	// Token: 0x0600D691 RID: 54929 RVA: 0x003945F0 File Offset: 0x003927F0
	public bool HasFriendApplication(int id)
	{
		return this.MyFriendApplyList.ContainsKey(id);
	}

	// Token: 0x0600D692 RID: 54930 RVA: 0x00394600 File Offset: 0x00392800
	public void DeleteFriendApplication(int id)
	{
		if (this.MyFriendApplyList.ContainsKey(id))
		{
			this.MyFriendApplyList.Remove(id);
			if (this.FreshFriendApplicationIds.Contains(id))
			{
				this.FreshFriendApplicationIds.Remove(id);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFriendViewShow);
	}

	// Token: 0x0600D693 RID: 54931 RVA: 0x00394654 File Offset: 0x00392854
	public void MarkDirtyNewApplications()
	{
		foreach (FriendApplyData friendApplyData in this.MyFriendApplyList.Values)
		{
			friendApplyData.Fresh = false;
			this.FreshFriendApplicationIds.Remove(friendApplyData.ApplyPlayerData.PlayerId);
		}
	}

	// Token: 0x0600D694 RID: 54932 RVA: 0x003946C4 File Offset: 0x003928C4
	public void AddFriendSearchResults(FriendData playerResult)
	{
		this.FriendSearchResults[playerResult.PlayerId] = playerResult;
	}

	// Token: 0x0600D695 RID: 54933 RVA: 0x003946D8 File Offset: 0x003928D8
	public void ClearFriendSearchResults()
	{
		this.FriendSearchResults.Clear();
	}

	// Token: 0x0600D696 RID: 54934 RVA: 0x003946E5 File Offset: 0x003928E5
	public void AddToBlackList(FriendBlackListData playerInfo)
	{
		this.MyBlackList[playerInfo.GetBlockedPlayerData.PlayerId] = playerInfo;
	}

	// Token: 0x0600D697 RID: 54935 RVA: 0x003946FE File Offset: 0x003928FE
	public bool HasBlockedPlayer(int id)
	{
		return this.MyBlackList.ContainsKey(id);
	}

	// Token: 0x0600D698 RID: 54936 RVA: 0x0039470C File Offset: 0x0039290C
	public void DeleteBlockedPlayer(int playerId)
	{
		this.MyBlackList.Remove(playerId);
	}

	// Token: 0x0600D699 RID: 54937 RVA: 0x0039471C File Offset: 0x0039291C
	[NullableContext(2)]
	public FriendData GetSelectedPlayerOrItemInstance(int? id = null, EUiViewName? sourceView = null)
	{
		int? num = id;
		int? num2 = (num != null) ? num : this.CurrentSelectedPlayerId;
		EUiViewName? euiViewName = sourceView;
		EUiViewName? euiViewName2 = (euiViewName != null) ? euiViewName : this.ShowingView;
		if (euiViewName2 == null)
		{
			return null;
		}
		if (euiViewName2 == EUiViewName.FriendView)
		{
			if (this.FilterState.GetValueOrDefault() == EFriendFilter.FriendList)
			{
				return this.GetFriendById(num2.Value);
			}
			if (this.FilterState.GetValueOrDefault() == EFriendFilter.FriendRequest)
			{
				return this.GetFriendDataInApplicationById(num2.Value);
			}
			if (this.FilterState.GetValueOrDefault() == EFriendFilter.RecentMultiple)
			{
				return this.GetRecentlyTeamData(num2.Value).PlayerData;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Friend;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "所属页签错误！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("页签filter", this.FilterState);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		else if (euiViewName2 == EUiViewName.FriendSearchView)
		{
			if (this.IsMyFriend(num2.Value))
			{
				return this.GetFriendById(num2.Value);
			}
			return this.GetFriendSearchResultById(num2.Value);
		}
		else
		{
			if (euiViewName2 == EUiViewName.FriendBlackListView)
			{
				return this.GetBlockedPlayerById(num2.Value).GetBlockedPlayerData;
			}
			if (euiViewName2 == EUiViewName.OnlineWorldHallView)
			{
				return this.GetFriendById(num2.Value);
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Friend;
			ELogAuthor author2 = ELogAuthor.YZY;
			string message2 = "当前展示View错误！";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("view名", euiViewName2);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
	}

	// Token: 0x0600D69A RID: 54938 RVA: 0x00394914 File Offset: 0x00392B14
	public void ResetShowingView()
	{
		this.ShowingView = new EUiViewName?(EUiViewName.FriendView);
	}

	// Token: 0x0600D69B RID: 54939 RVA: 0x00394928 File Offset: 0x00392B28
	public void ClearTestFriendData()
	{
		if (!this.TestDataLoaded)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (int num in this.MyFriends.Keys)
		{
			if (this.MyFriends[num].Debug)
			{
				list.Add(num);
			}
		}
		foreach (int key in list)
		{
			this.MyFriends.Remove(key);
		}
		list.Clear();
		foreach (int num2 in this.MyFriendApplyList.Keys)
		{
			if (this.MyFriendApplyList[num2].ApplyPlayerData.Debug)
			{
				list.Add(num2);
			}
		}
		foreach (int num3 in list)
		{
			this.MyFriendApplyList.Remove(num3);
			if (this.FreshFriendApplicationIds.Contains(num3))
			{
				this.FreshFriendApplicationIds.Remove(num3);
			}
		}
		list.Clear();
		foreach (int num4 in this.MyBlackList.Keys)
		{
			if (this.MyBlackList[num4].GetBlockedPlayerData.Debug)
			{
				list.Add(num4);
			}
		}
		foreach (int key2 in list)
		{
			this.MyBlackList.Remove(key2);
		}
		list.Clear();
		foreach (int num5 in this.FriendSearchResults.Keys)
		{
			if (this.FriendSearchResults[num5].Debug)
			{
				list.Add(num5);
			}
		}
		foreach (int key3 in list)
		{
			this.FriendSearchResults.Remove(key3);
		}
		this.TestDataLoaded = false;
	}

	// Token: 0x0600D69C RID: 54940 RVA: 0x00394C10 File Offset: 0x00392E10
	public bool CurrentApplyFriendListHasPlayer(int playerId)
	{
		return this.CurrentApplyFriendList.Contains(playerId);
	}

	// Token: 0x0600D69D RID: 54941 RVA: 0x00394C1E File Offset: 0x00392E1E
	public void AddPlayerToApplyFriendList(int playerId)
	{
		if (!this.CurrentApplyFriendList.Contains(playerId))
		{
			this.CurrentApplyFriendList.Add(playerId);
		}
	}

	// Token: 0x0600D69E RID: 54942 RVA: 0x00394C3B File Offset: 0x00392E3B
	public void ClearApplyFriendList()
	{
		this.CurrentApplyFriendList.Clear();
	}

	// Token: 0x0600D69F RID: 54943 RVA: 0x00394C48 File Offset: 0x00392E48
	public bool CurrentApproveFriendListHasPlayer(int playerId)
	{
		return this.CurrentApproveFriendList.Contains(playerId);
	}

	// Token: 0x0600D6A0 RID: 54944 RVA: 0x00394C56 File Offset: 0x00392E56
	public void AddPlayerToApproveFriendList(int playerId)
	{
		if (!this.CurrentApproveFriendList.Contains(playerId))
		{
			this.CurrentApproveFriendList.Add(playerId);
		}
	}

	// Token: 0x0600D6A1 RID: 54945 RVA: 0x00394C73 File Offset: 0x00392E73
	public void ClearApproveFriendList()
	{
		this.CurrentApproveFriendList.Clear();
	}

	// Token: 0x0600D6A2 RID: 54946 RVA: 0x00394C80 File Offset: 0x00392E80
	public bool CurrentRefuseFriendListHasPlayer(int playerId)
	{
		return this.CurrentRefuseFriendList.Contains(playerId);
	}

	// Token: 0x0600D6A3 RID: 54947 RVA: 0x00394C8E File Offset: 0x00392E8E
	public void AddPlayerToRefuseFriendList(int playerId)
	{
		if (!this.CurrentRefuseFriendList.Contains(playerId))
		{
			this.CurrentRefuseFriendList.Add(playerId);
		}
	}

	// Token: 0x0600D6A4 RID: 54948 RVA: 0x00394CAC File Offset: 0x00392EAC
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public static ValueTuple<string, int> GetOfflineStrAndGap(long offlineTimeStamp)
	{
		int num = Singleton<TimeUtil>.Instance.CalculateDayTimeStampGapBetweenNow((double)offlineTimeStamp, false);
		string item = "FriendOfflineToday";
		if (num <= 1)
		{
			item = "FriendOfflineToday";
		}
		else if (num > 1 && num <= 30)
		{
			item = "FriendOfflineSomeDay";
		}
		else if (num > 30)
		{
			item = "FriendOfflineOverMonth";
		}
		return new ValueTuple<string, int>(item, num);
	}

	// Token: 0x0600D6A5 RID: 54949 RVA: 0x00394CFC File Offset: 0x00392EFC
	public UniTask InitRecentlyTeamDataByResponse(RecentlyTeamInfo[] responseInfo)
	{
		FriendModel.<InitRecentlyTeamDataByResponse>d__56 <InitRecentlyTeamDataByResponse>d__;
		<InitRecentlyTeamDataByResponse>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRecentlyTeamDataByResponse>d__.<>4__this = this;
		<InitRecentlyTeamDataByResponse>d__.responseInfo = responseInfo;
		<InitRecentlyTeamDataByResponse>d__.<>1__state = -1;
		<InitRecentlyTeamDataByResponse>d__.<>t__builder.Start<FriendModel.<InitRecentlyTeamDataByResponse>d__56>(ref <InitRecentlyTeamDataByResponse>d__);
		return <InitRecentlyTeamDataByResponse>d__.<>t__builder.Task;
	}

	// Token: 0x0600D6A6 RID: 54950 RVA: 0x00394D47 File Offset: 0x00392F47
	[NullableContext(2)]
	public RecentlyTeamData GetRecentlyTeamData(int playerId)
	{
		if (!this.RecentlyTeamList.ContainsKey(playerId))
		{
			return null;
		}
		return this.RecentlyTeamList[playerId];
	}

	// Token: 0x0600D6A7 RID: 54951 RVA: 0x00394D65 File Offset: 0x00392F65
	public void ClearRefuseFriendList()
	{
		this.CurrentRefuseFriendList.Clear();
	}

	// Token: 0x0600D6A8 RID: 54952 RVA: 0x00394D74 File Offset: 0x00392F74
	public List<FriendApplyData> GetApplyViewDataList([Nullable(2)] List<int> playerIdFilterList = null)
	{
		List<FriendApplyData> list = new List<FriendApplyData>();
		if (playerIdFilterList != null)
		{
			using (List<int>.Enumerator enumerator = playerIdFilterList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int key = enumerator.Current;
					if (this.MyFriendApplyList.ContainsKey(key))
					{
						list.Add(this.MyFriendApplyList[key]);
					}
				}
				return list;
			}
		}
		foreach (FriendApplyData item in this.MyFriendApplyList.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x1700113A RID: 4410
	// (get) Token: 0x0600D6A9 RID: 54953 RVA: 0x00394E30 File Offset: 0x00393030
	// (set) Token: 0x0600D6AA RID: 54954 RVA: 0x00394E38 File Offset: 0x00393038
	public int? SelectedPlayerId
	{
		get
		{
			return this.CurrentSelectedPlayerId;
		}
		set
		{
			this.CurrentSelectedPlayerId = value;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.CsSyncSelectedPlayerId, value.GetValueOrDefault());
		}
	}

	// Token: 0x1700113B RID: 4411
	// (get) Token: 0x0600D6AB RID: 54955 RVA: 0x00394E58 File Offset: 0x00393058
	// (set) Token: 0x0600D6AC RID: 54956 RVA: 0x00394E60 File Offset: 0x00393060
	public EFriendFilter? FilterState
	{
		get
		{
			return this.FriendFilterState;
		}
		set
		{
			this.FriendFilterState = value;
		}
	}

	// Token: 0x1700113C RID: 4412
	// (get) Token: 0x0600D6AD RID: 54957 RVA: 0x00394E69 File Offset: 0x00393069
	// (set) Token: 0x0600D6AE RID: 54958 RVA: 0x00394E71 File Offset: 0x00393071
	public EUiViewName? ShowingView
	{
		get
		{
			return this.CurrentlyShowingView;
		}
		set
		{
			this.CurrentlyShowingView = value;
		}
	}

	// Token: 0x0600D6AF RID: 54959 RVA: 0x00394E7A File Offset: 0x0039307A
	public void SetCurrentOperationPlayerId(int playerId)
	{
		this.CurrentOperationPlayerId = new int?(playerId);
	}

	// Token: 0x0600D6B0 RID: 54960 RVA: 0x00394E88 File Offset: 0x00393088
	public int? GetCurrentOperationPlayerId()
	{
		return this.CurrentOperationPlayerId;
	}

	// Token: 0x040065C9 RID: 26057
	private readonly Dictionary<int, FriendData> MyFriends = new Dictionary<int, FriendData>();

	// Token: 0x040065CA RID: 26058
	private readonly Dictionary<int, FriendApplyData> MyFriendApplyList = new Dictionary<int, FriendApplyData>();

	// Token: 0x040065CB RID: 26059
	private readonly Dictionary<int, FriendData> FriendSearchResults = new Dictionary<int, FriendData>();

	// Token: 0x040065CC RID: 26060
	private readonly Dictionary<int, FriendBlackListData> MyBlackList = new Dictionary<int, FriendBlackListData>();

	// Token: 0x040065CD RID: 26061
	public readonly HashSet<int> FreshFriendApplicationIds = new HashSet<int>();

	// Token: 0x040065CE RID: 26062
	public Dictionary<int, RecentlyTeamData> RecentlyTeamList = new Dictionary<int, RecentlyTeamData>();

	// Token: 0x040065CF RID: 26063
	private int? CurrentSelectedPlayerId;

	// Token: 0x040065D0 RID: 26064
	private int? CurrentOperationPlayerId;

	// Token: 0x040065D1 RID: 26065
	private EFriendFilter? FriendFilterState;

	// Token: 0x040065D2 RID: 26066
	private EUiViewName? CurrentlyShowingView;

	// Token: 0x040065D3 RID: 26067
	public bool TestDataLoaded;

	// Token: 0x040065D4 RID: 26068
	[Nullable(2)]
	public FriendData CachePlayerData;

	// Token: 0x040065D5 RID: 26069
	private readonly HashSet<int> CurrentApplyFriendList = new HashSet<int>();

	// Token: 0x040065D6 RID: 26070
	private readonly HashSet<int> CurrentApproveFriendList = new HashSet<int>();

	// Token: 0x040065D7 RID: 26071
	private readonly HashSet<int> CurrentRefuseFriendList = new HashSet<int>();

	// Token: 0x040065D8 RID: 26072
	public int ApplyCdTime;
}
