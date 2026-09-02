using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Launcher.Platform.PlatformSdk;
using UnrealEngine;

// Token: 0x0200233F RID: 9023
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class OnlineModel : ModelBase<OnlineModel>
{
	// Token: 0x0601133A RID: 70458 RVA: 0x004B8F00 File Offset: 0x004B7100
	protected override bool OnInit()
	{
		this.StrangerWorldList = new List<OnlineHallData>();
		this.FriendWorldList = new List<OnlineHallData>();
		this.SearchResultList = new List<OnlineHallData>();
		this.ApplyMap = new Dictionary<int, OnlineApplyData>();
		this.OnlineTeamMap = new Dictionary<int, OnlineTeamData>();
		this.Apply = -1;
		this.TeamOwnerId = -1;
		this.ApplyCdTime = ConfigCommonParamById.GetIntConfig("apply_valid_time").Value;
		this.WorldEnterDiff = ConfigCommonParamById.GetIntConfig("world_level_enter_diff").Value;
		this.DisableOnlineSource = new Dictionary<DisableOnlineSource, EDisableOnlineType>();
		return true;
	}

	// Token: 0x0601133B RID: 70459 RVA: 0x004B8F90 File Offset: 0x004B7190
	protected override bool OnClear()
	{
		if (this.StrangerWorldList != null)
		{
			this.StrangerWorldList.Clear();
			this.StrangerWorldList = null;
		}
		if (this.FriendWorldList != null)
		{
			this.FriendWorldList.Clear();
			this.FriendWorldList = null;
		}
		if (this.SearchResultList != null)
		{
			this.SearchResultList.Clear();
			this.SearchResultList = null;
		}
		if (this.ApplyMap != null)
		{
			this.ApplyMap.Clear();
			this.ApplyMap = null;
		}
		if (this.OnlineTeamMap != null)
		{
			this.OnlineTeamMap.Clear();
			this.OnlineTeamMap = null;
		}
		this.Apply = 0;
		this.ApplyCdTime = 0;
		this.WorldEnterDiff = 0;
		Dictionary<DisableOnlineSource, EDisableOnlineType> disableOnlineSource = this.DisableOnlineSource;
		if (disableOnlineSource != null)
		{
			disableOnlineSource.Clear();
		}
		this.DisableOnlineSource = null;
		this.ContinuingChallengeConfirmState.Clear();
		this.PlayerTeleportState.Clear();
		this.InitiateChallengeApplyPlayerId = -1;
		this.NextAllowInitiateTime = -1.0;
		this.CanInitiate = true;
		return true;
	}

	// Token: 0x0601133C RID: 70460 RVA: 0x004B9080 File Offset: 0x004B7280
	protected override bool OnLeaveLevel()
	{
		this.ContinuingChallengeConfirmState.Clear();
		this.InitiateChallengeApplyPlayerId = -1;
		this.NextAllowInitiateTime = -1.0;
		this.CanInitiate = true;
		this.PlayerEntityDisableHandleMap.Clear();
		return true;
	}

	// Token: 0x0601133D RID: 70461 RVA: 0x004B90B6 File Offset: 0x004B72B6
	protected override bool OnChangeMode()
	{
		this.PlayerEntityDisableHandleMap.Clear();
		return true;
	}

	// Token: 0x0601133E RID: 70462 RVA: 0x004B90C4 File Offset: 0x004B72C4
	public void ClearOnlineTeamMap()
	{
		if (this.OnlineTeamMap != null)
		{
			this.OnlineTeamMap.Clear();
		}
	}

	// Token: 0x1700157D RID: 5501
	// (get) Token: 0x0601133F RID: 70463 RVA: 0x004B90D9 File Offset: 0x004B72D9
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<OnlineHallData> StrangerWorld
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.StrangerWorldList;
		}
	}

	// Token: 0x1700157E RID: 5502
	// (get) Token: 0x06011340 RID: 70464 RVA: 0x004B90E1 File Offset: 0x004B72E1
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<OnlineHallData> FriendWorld
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.FriendWorldList;
		}
	}

	// Token: 0x1700157F RID: 5503
	// (get) Token: 0x06011341 RID: 70465 RVA: 0x004B90E9 File Offset: 0x004B72E9
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<OnlineHallData> SearchResult
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.SearchResultList;
		}
	}

	// Token: 0x17001580 RID: 5504
	// (get) Token: 0x06011342 RID: 70466 RVA: 0x004B90F1 File Offset: 0x004B72F1
	public WorldEnterPermission CurrentPermissionsSetting
	{
		get
		{
			return this.PermissionsSetting;
		}
	}

	// Token: 0x17001581 RID: 5505
	// (get) Token: 0x06011343 RID: 70467 RVA: 0x004B90F9 File Offset: 0x004B72F9
	[Nullable(2)]
	public OnlineApplyData CurrentApply
	{
		[NullableContext(2)]
		get
		{
			if (!this.ApplyMap.ContainsKey(this.Apply))
			{
				return null;
			}
			return this.ApplyMap[this.Apply];
		}
	}

	// Token: 0x17001582 RID: 5506
	// (get) Token: 0x06011344 RID: 70468 RVA: 0x004B9121 File Offset: 0x004B7321
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, OnlineApplyData> CurrentApplyList
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.ApplyMap;
		}
	}

	// Token: 0x17001583 RID: 5507
	// (get) Token: 0x06011345 RID: 70469 RVA: 0x004B9129 File Offset: 0x004B7329
	public int ApplyCd
	{
		get
		{
			return this.ApplyCdTime;
		}
	}

	// Token: 0x17001584 RID: 5508
	// (get) Token: 0x06011346 RID: 70470 RVA: 0x004B9131 File Offset: 0x004B7331
	public int EnterDiff
	{
		get
		{
			return this.WorldEnterDiff;
		}
	}

	// Token: 0x17001585 RID: 5509
	// (get) Token: 0x06011347 RID: 70471 RVA: 0x004B9139 File Offset: 0x004B7339
	public int OwnerId
	{
		get
		{
			return this.TeamOwnerId;
		}
	}

	// Token: 0x17001586 RID: 5510
	// (get) Token: 0x06011348 RID: 70472 RVA: 0x004B9141 File Offset: 0x004B7341
	public int TeamMaxSize
	{
		get
		{
			return this.OnlineTeamMaxSize;
		}
	}

	// Token: 0x17001587 RID: 5511
	// (get) Token: 0x06011349 RID: 70473 RVA: 0x004B9149 File Offset: 0x004B7349
	public bool ShowCanJoin
	{
		get
		{
			return this.HallShowCanJoin;
		}
	}

	// Token: 0x17001588 RID: 5512
	// (get) Token: 0x0601134A RID: 70474 RVA: 0x004B9151 File Offset: 0x004B7351
	public bool ShowFriend
	{
		get
		{
			return this.HallShowFriend;
		}
	}

	// Token: 0x17001589 RID: 5513
	// (get) Token: 0x0601134B RID: 70475 RVA: 0x004B9159 File Offset: 0x004B7359
	public int ChallengeApplyPlayerId
	{
		get
		{
			return this.InitiateChallengeApplyPlayerId;
		}
	}

	// Token: 0x1700158A RID: 5514
	// (get) Token: 0x0601134C RID: 70476 RVA: 0x004B9161 File Offset: 0x004B7361
	public double NextInitiateTime
	{
		get
		{
			return this.NextAllowInitiateTime;
		}
	}

	// Token: 0x1700158B RID: 5515
	// (get) Token: 0x0601134D RID: 70477 RVA: 0x004B9169 File Offset: 0x004B7369
	public double NextInitiateLeftTime
	{
		get
		{
			return this.NextAllowInitiateTime - Singleton<TimeUtil>.Instance.GetServerTime();
		}
	}

	// Token: 0x1700158C RID: 5516
	// (get) Token: 0x0601134E RID: 70478 RVA: 0x004B917C File Offset: 0x004B737C
	public bool AllowInitiate
	{
		get
		{
			return this.CanInitiate;
		}
	}

	// Token: 0x0601134F RID: 70479 RVA: 0x004B9184 File Offset: 0x004B7384
	public void SetHallShowCanJoin(bool isShow)
	{
		this.HallShowCanJoin = isShow;
	}

	// Token: 0x06011350 RID: 70480 RVA: 0x004B918D File Offset: 0x004B738D
	public void SetHallShowFriend(bool isShow)
	{
		this.HallShowFriend = isShow;
	}

	// Token: 0x06011351 RID: 70481 RVA: 0x004B9196 File Offset: 0x004B7396
	public void SetTeamOwnerId(int teamOwnerId)
	{
		this.TeamOwnerId = teamOwnerId;
	}

	// Token: 0x06011352 RID: 70482 RVA: 0x004B91A0 File Offset: 0x004B73A0
	public void SetPermissionsSetting(WorldEnterPermission type)
	{
		this.PermissionsSetting = type;
		if (ModelBase<GameModeModel>.Instance.IsMulti && this.GetIsMyTeam())
		{
			EPlayStationJoinAble gameJoinTypeToPlayStationJoinType = this.GetGameJoinTypeToPlayStationJoinType();
			PlatformSdkNew platformSdk = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk();
			if (platformSdk == null)
			{
				return;
			}
			platformSdk.SetPlayerSessionJoinAbleUserType((int)gameJoinTypeToPlayStationJoinType);
		}
	}

	// Token: 0x06011353 RID: 70483 RVA: 0x004B91E4 File Offset: 0x004B73E4
	public void CleanSearchResultList()
	{
		List<OnlineHallData> searchResultList = this.SearchResultList;
		if (searchResultList == null)
		{
			return;
		}
		searchResultList.Clear();
	}

	// Token: 0x06011354 RID: 70484 RVA: 0x004B91F6 File Offset: 0x004B73F6
	public void CleanFriendWorldList()
	{
		List<OnlineHallData> friendWorldList = this.FriendWorldList;
		if (friendWorldList == null)
		{
			return;
		}
		friendWorldList.Clear();
	}

	// Token: 0x06011355 RID: 70485 RVA: 0x004B9208 File Offset: 0x004B7408
	public void CleanStrangerWorldList()
	{
		List<OnlineHallData> strangerWorldList = this.StrangerWorldList;
		if (strangerWorldList == null)
		{
			return;
		}
		strangerWorldList.Clear();
	}

	// Token: 0x06011356 RID: 70486 RVA: 0x004B921A File Offset: 0x004B741A
	public void CleanCurrentApply()
	{
		this.ApplyMap.Remove(this.Apply);
		this.Apply = -1;
	}

	// Token: 0x06011357 RID: 70487 RVA: 0x004B9235 File Offset: 0x004B7435
	public void PushSearchResultList(OnlineHallData data)
	{
		this.SearchResultList.Add(data);
	}

	// Token: 0x06011358 RID: 70488 RVA: 0x004B9243 File Offset: 0x004B7443
	public void PushFriendWorldList(OnlineHallData data)
	{
		this.FriendWorldList.Add(data);
	}

	// Token: 0x06011359 RID: 70489 RVA: 0x004B9251 File Offset: 0x004B7451
	public void PushStrangerWorldList(OnlineHallData data)
	{
		this.StrangerWorldList.Add(data);
	}

	// Token: 0x0601135A RID: 70490 RVA: 0x004B925F File Offset: 0x004B745F
	public void SortWorldList(bool isFriend)
	{
		if (isFriend)
		{
			List<OnlineHallData> friendWorldList = this.FriendWorldList;
			if (friendWorldList == null)
			{
				return;
			}
			friendWorldList.Sort(new Comparison<OnlineHallData>(this.WorldListSortFunction));
			return;
		}
		else
		{
			List<OnlineHallData> strangerWorldList = this.StrangerWorldList;
			if (strangerWorldList == null)
			{
				return;
			}
			strangerWorldList.Sort(new Comparison<OnlineHallData>(this.WorldListSortFunction));
			return;
		}
	}

	// Token: 0x0601135B RID: 70491 RVA: 0x004B92A0 File Offset: 0x004B74A0
	private int WorldListSortFunction(OnlineHallData a, OnlineHallData b)
	{
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		if ((a.PlayerOriginWorldLevel > originWorldLevel && b.PlayerOriginWorldLevel > originWorldLevel) || (a.PlayerOriginWorldLevel <= originWorldLevel && b.PlayerOriginWorldLevel <= originWorldLevel))
		{
			return b.PlayerLastOfflineTime.CompareTo(a.PlayerLastOfflineTime);
		}
		return a.PlayerOriginWorldLevel - b.PlayerOriginWorldLevel;
	}

	// Token: 0x0601135C RID: 70492 RVA: 0x004B92FE File Offset: 0x004B74FE
	public void PushCurrentApplyList(OnlineApplyData data)
	{
		this.ApplyMap[data.PlayerId] = data;
		if (this.Apply == -1)
		{
			this.Apply = data.PlayerId;
		}
	}

	// Token: 0x0601135D RID: 70493 RVA: 0x004B9327 File Offset: 0x004B7527
	public void PushCurrentTeamList(OnlineTeamData data)
	{
		this.OnlineTeamMap[data.PlayerId] = data;
		ModelBase<KuroSdkModel>.Instance.RefreshPlayerChatPermissionByPlayerDetails(data.PlayerDetails);
	}

	// Token: 0x0601135E RID: 70494 RVA: 0x004B934C File Offset: 0x004B754C
	public void DeleteCurrentApplyListById(int id)
	{
		this.ApplyMap.Remove(id);
		if (this.ApplyMap.Count < 1)
		{
			this.Apply = -1;
			return;
		}
		double num = (double)this.ApplyCdTime;
		foreach (KeyValuePair<int, OnlineApplyData> keyValuePair in this.ApplyMap)
		{
			OnlineApplyData value = keyValuePair.Value;
			if (value.ApplyTimeLeftTime <= num)
			{
				num = value.ApplyTimeLeftTime;
				this.Apply = keyValuePair.Key;
			}
		}
	}

	// Token: 0x0601135F RID: 70495 RVA: 0x004B93E8 File Offset: 0x004B75E8
	public void DeleteCurrentTeamListById(int id)
	{
		this.OnlineTeamMap.Remove(id);
	}

	// Token: 0x06011360 RID: 70496 RVA: 0x004B93F8 File Offset: 0x004B75F8
	public void ResetTeamDataPlayer(int deletePlayerNumber)
	{
		foreach (KeyValuePair<int, OnlineTeamData> keyValuePair in this.OnlineTeamMap)
		{
			OnlineTeamData value = keyValuePair.Value;
			if (value.PlayerNumber > deletePlayerNumber)
			{
				OnlineTeamData onlineTeamData = value;
				int playerNumber = onlineTeamData.PlayerNumber;
				onlineTeamData.PlayerNumber = playerNumber - 1;
			}
		}
	}

	// Token: 0x06011361 RID: 70497 RVA: 0x004B9468 File Offset: 0x004B7668
	[NullableContext(2)]
	public OnlineApplyData GetCurrentApplyListById(int id)
	{
		if (!this.ApplyMap.ContainsKey(id))
		{
			return null;
		}
		return this.ApplyMap[id];
	}

	// Token: 0x06011362 RID: 70498 RVA: 0x004B9486 File Offset: 0x004B7686
	[NullableContext(2)]
	public OnlineTeamData GetCurrentTeamListById(int id)
	{
		if (!this.OnlineTeamMap.ContainsKey(id))
		{
			return null;
		}
		return this.OnlineTeamMap[id];
	}

	// Token: 0x06011363 RID: 70499 RVA: 0x004B94A4 File Offset: 0x004B76A4
	public OnlineApplyData[] GetCurrentApplyList()
	{
		List<OnlineApplyData> list = new List<OnlineApplyData>();
		foreach (KeyValuePair<int, OnlineApplyData> keyValuePair in this.ApplyMap)
		{
			if (keyValuePair.Key > 0)
			{
				list.Add(keyValuePair.Value);
			}
		}
		list.Sort((OnlineApplyData a, OnlineApplyData b) => a.ApplyTimeLeftTime.CompareTo(b.ApplyTimeLeftTime));
		return list.ToArray();
	}

	// Token: 0x06011364 RID: 70500 RVA: 0x004B9538 File Offset: 0x004B7738
	public int GetCurrentApplySize()
	{
		return this.ApplyMap.Count;
	}

	// Token: 0x06011365 RID: 70501 RVA: 0x004B9545 File Offset: 0x004B7745
	public int GetCurrentTeamSize()
	{
		return this.OnlineTeamMap.Count;
	}

	// Token: 0x06011366 RID: 70502 RVA: 0x004B9552 File Offset: 0x004B7752
	public bool GetIsTeamModel()
	{
		return this.TeamOwnerId != -1;
	}

	// Token: 0x06011367 RID: 70503 RVA: 0x004B9560 File Offset: 0x004B7760
	public bool GetIsMyTeam()
	{
		int ownerId = this.OwnerId;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		return ownerId == id.GetValueOrDefault() & id != null;
	}

	// Token: 0x06011368 RID: 70504 RVA: 0x004B958F File Offset: 0x004B778F
	public bool GetExistOnlineTeam()
	{
		return this.OwnerId != -1;
	}

	// Token: 0x06011369 RID: 70505 RVA: 0x004B95A0 File Offset: 0x004B77A0
	public List<OnlineHallData> GetCanJoinFormStranger()
	{
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		List<OnlineHallData> list = new List<OnlineHallData>();
		foreach (OnlineHallData onlineHallData in this.StrangerWorldList)
		{
			if (onlineHallData.WorldLevel <= curWorldLevel + this.EnterDiff)
			{
				list.Add(onlineHallData);
			}
		}
		return list;
	}

	// Token: 0x0601136A RID: 70506 RVA: 0x004B9618 File Offset: 0x004B7818
	public List<OnlineHallData> GetCanJoinFormFriend()
	{
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		List<OnlineHallData> list = new List<OnlineHallData>();
		foreach (OnlineHallData onlineHallData in this.FriendWorldList)
		{
			if (this.CanJoinOtherWorld(curWorldLevel, onlineHallData.WorldLevel))
			{
				list.Add(onlineHallData);
			}
		}
		return list;
	}

	// Token: 0x0601136B RID: 70507 RVA: 0x004B968C File Offset: 0x004B788C
	public bool CanJoinOtherWorld(int myWorldLevel, int otherWorldLevel)
	{
		return myWorldLevel + this.EnterDiff >= otherWorldLevel;
	}

	// Token: 0x0601136C RID: 70508 RVA: 0x004B969C File Offset: 0x004B789C
	public List<OnlineTeamData> GetTeamList()
	{
		List<OnlineTeamData> list = new List<OnlineTeamData>();
		foreach (KeyValuePair<int, OnlineTeamData> keyValuePair in this.OnlineTeamMap)
		{
			list.Add(keyValuePair.Value);
		}
		list.Sort((OnlineTeamData a, OnlineTeamData b) => a.PlayerNumber - b.PlayerNumber);
		return list;
	}

	// Token: 0x0601136D RID: 70509 RVA: 0x004B9724 File Offset: 0x004B7924
	public void DisableOnline(EDisableOnlineType type, bool enable, int treeId = 0, int nodeId = 0)
	{
		if (enable)
		{
			bool flag = false;
			foreach (KeyValuePair<DisableOnlineSource, EDisableOnlineType> keyValuePair in this.DisableOnlineSource)
			{
				DisableOnlineSource key = keyValuePair.Key;
				if (key.TreeId == treeId && key.NodeId == nodeId && key.Type == type)
				{
					this.DisableOnlineSource[key] = type;
					flag = true;
				}
			}
			if (!flag)
			{
				DisableOnlineSource key2 = new DisableOnlineSource
				{
					Type = type,
					TreeId = treeId,
					NodeId = nodeId
				};
				this.DisableOnlineSource[key2] = type;
			}
		}
		else
		{
			List<DisableOnlineSource> list = new List<DisableOnlineSource>();
			foreach (KeyValuePair<DisableOnlineSource, EDisableOnlineType> keyValuePair2 in this.DisableOnlineSource)
			{
				DisableOnlineSource key3 = keyValuePair2.Key;
				if (key3.TreeId == treeId && key3.NodeId == nodeId && key3.Type == type)
				{
					list.Add(key3);
				}
			}
			foreach (DisableOnlineSource key4 in list)
			{
				this.DisableOnlineSource.Remove(key4);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnlineDisableStateChange);
	}

	// Token: 0x0601136E RID: 70510 RVA: 0x004B98AC File Offset: 0x004B7AAC
	public bool IsOnlineDisabled()
	{
		return this.DisableOnlineSource != null && this.DisableOnlineSource.Count > 0;
	}

	// Token: 0x0601136F RID: 70511 RVA: 0x004B98C6 File Offset: 0x004B7AC6
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyDictionary<DisableOnlineSource, EDisableOnlineType> GetOnlineDisabledSource()
	{
		return this.DisableOnlineSource;
	}

	// Token: 0x06011370 RID: 70512 RVA: 0x004B98CE File Offset: 0x004B7ACE
	public void ClearWorldTeamPlayerFightInfo()
	{
		this.WorldTeamPlayerFightInfo.Clear();
	}

	// Token: 0x06011371 RID: 70513 RVA: 0x004B98DC File Offset: 0x004B7ADC
	public void DeleteWorldTeamPlayerFightInfo(int playerId)
	{
		for (int i = this.WorldTeamPlayerFightInfo.Count - 1; i >= 0; i--)
		{
			if (this.WorldTeamPlayerFightInfo[i].PlayerId == playerId)
			{
				this.WorldTeamPlayerFightInfo.RemoveAt(i);
			}
		}
	}

	// Token: 0x06011372 RID: 70514 RVA: 0x004B9921 File Offset: 0x004B7B21
	public void PushWorldTeamPlayerFightInfo(global::WorldTeamPlayerFightInfo playerInfo)
	{
		this.WorldTeamPlayerFightInfo.Add(playerInfo);
	}

	// Token: 0x06011373 RID: 70515 RVA: 0x004B9930 File Offset: 0x004B7B30
	[NullableContext(2)]
	public global::WorldTeamPlayerFightInfo GetWorldTeamPlayerFightInfo(int playerId)
	{
		foreach (global::WorldTeamPlayerFightInfo worldTeamPlayerFightInfo in this.WorldTeamPlayerFightInfo)
		{
			if (worldTeamPlayerFightInfo.PlayerId == playerId)
			{
				return worldTeamPlayerFightInfo;
			}
		}
		return null;
	}

	// Token: 0x06011374 RID: 70516 RVA: 0x004B998C File Offset: 0x004B7B8C
	public int[] GetAllWorldTeamPlayer()
	{
		int[] array = new int[this.WorldTeamPlayerFightInfo.Count];
		for (int i = 0; i < this.WorldTeamPlayerFightInfo.Count; i++)
		{
			array[i] = this.WorldTeamPlayerFightInfo[i].PlayerId;
		}
		return array;
	}

	// Token: 0x06011375 RID: 70517 RVA: 0x004B99D5 File Offset: 0x004B7BD5
	public int GetAllWorldTeamPlayerLength()
	{
		return this.WorldTeamPlayerFightInfo.Count;
	}

	// Token: 0x06011376 RID: 70518 RVA: 0x004B99E4 File Offset: 0x004B7BE4
	public void RefreshWorldTeamRoleInfo(IList<PlayerFightFormations> playersFormations)
	{
		foreach (PlayerFightFormations playerFightFormations in playersFormations)
		{
			global::WorldTeamPlayerFightInfo worldTeamPlayerFightInfo = this.GetWorldTeamPlayerFightInfo(playerFightFormations.PlayerId);
			if (worldTeamPlayerFightInfo != null)
			{
				foreach (FightFormationNotifyInfo fightFormationNotifyInfo in playerFightFormations.Formations)
				{
					if (fightFormationNotifyInfo.FormationId == -1)
					{
						List<global::WorldTeamRoleInfo> list = new List<global::WorldTeamRoleInfo>();
						foreach (Aki.Protocol.FormationRoleInfo formationRoleInfo in fightFormationNotifyInfo.RoleInfos)
						{
							list.Add(new global::WorldTeamRoleInfo(formationRoleInfo.RoleId, formationRoleInfo.RoleSkinId, formationRoleInfo.Level));
						}
						worldTeamPlayerFightInfo.RoleInfos = list;
					}
				}
			}
		}
	}

	// Token: 0x06011377 RID: 70519 RVA: 0x004B9AEC File Offset: 0x004B7CEC
	public void ResetContinuingChallengeConfirmState()
	{
		this.ContinuingChallengeConfirmState.Clear();
		foreach (ScenePlayerData scenePlayerData in ModelBase<CreatureModel>.Instance.GetAllScenePlayers())
		{
			int playerId = scenePlayerData.GetPlayerId();
			this.ContinuingChallengeConfirmState[playerId] = EContinuingChallenge.Pending;
		}
	}

	// Token: 0x06011378 RID: 70520 RVA: 0x004B9B5C File Offset: 0x004B7D5C
	public void SetContinuingChallengeConfirmState(int playerId, EContinuingChallenge bConfirm)
	{
		this.ContinuingChallengeConfirmState[playerId] = bConfirm;
	}

	// Token: 0x06011379 RID: 70521 RVA: 0x004B9B6C File Offset: 0x004B7D6C
	public EContinuingChallenge? GetContinuingChallengeConfirmState(int playerId)
	{
		if (!this.ContinuingChallengeConfirmState.ContainsKey(playerId))
		{
			return null;
		}
		return new EContinuingChallenge?(this.ContinuingChallengeConfirmState[playerId]);
	}

	// Token: 0x0601137A RID: 70522 RVA: 0x004B9BA2 File Offset: 0x004B7DA2
	public void SetChallengeApplyPlayerId(int playerId)
	{
		this.InitiateChallengeApplyPlayerId = playerId;
	}

	// Token: 0x0601137B RID: 70523 RVA: 0x004B9BAB File Offset: 0x004B7DAB
	public void RefreshInitiateTime()
	{
		this.NextAllowInitiateTime = Singleton<TimeUtil>.Instance.GetServerTime() + (double)this.ApplyCd;
	}

	// Token: 0x0601137C RID: 70524 RVA: 0x004B9BC5 File Offset: 0x004B7DC5
	public void SetAllowInitiate(bool allow)
	{
		this.CanInitiate = allow;
	}

	// Token: 0x0601137D RID: 70525 RVA: 0x004B9BCE File Offset: 0x004B7DCE
	public void SetPlayerTeleportState(int playerId, EPlayerTeleportState state)
	{
		this.PlayerTeleportState[playerId] = state;
	}

	// Token: 0x0601137E RID: 70526 RVA: 0x004B9BE0 File Offset: 0x004B7DE0
	public EPlayerTeleportState? GetPlayerTeleportState(int playerId)
	{
		if (!this.PlayerTeleportState.ContainsKey(playerId))
		{
			return null;
		}
		return new EPlayerTeleportState?(this.PlayerTeleportState[playerId]);
	}

	// Token: 0x0601137F RID: 70527 RVA: 0x004B9C16 File Offset: 0x004B7E16
	public void DeletePlayerTeleportState(int playerId)
	{
		this.PlayerTeleportState.Remove(playerId);
	}

	// Token: 0x06011380 RID: 70528 RVA: 0x004B9C25 File Offset: 0x004B7E25
	public void ClearPlayerTeleportState()
	{
		this.PlayerTeleportState.Clear();
	}

	// Token: 0x06011381 RID: 70529 RVA: 0x004B9C34 File Offset: 0x004B7E34
	public void SetRoleActivated(int playerId, bool bActivated)
	{
		HashSet<int> hashSet = this.PlayerEntityDisableHandleMap.ContainsKey(playerId) ? this.PlayerEntityDisableHandleMap[playerId] : null;
		if (bActivated)
		{
			if (hashSet != null)
			{
				foreach (int entityId in hashSet)
				{
					EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
					WorldEntity worldEntity = (entityById != null) ? entityById.Entity : null;
					if (worldEntity != null && worldEntity.Valid)
					{
						worldEntity.EnableByKey(EEntityDisableKey.Teleport, true);
					}
				}
				this.PlayerEntityDisableHandleMap.Remove(playerId);
			}
			return;
		}
		Entity entity = null;
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)playerId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.PlayerId,
			IsControl = new bool?(true)
		});
		if (teamItem != null)
		{
			EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(teamItem.GetCreatureDataId());
			entity = ((entity2 != null) ? entity2.Entity : null);
		}
		if (entity == null || !entity.Valid)
		{
			return;
		}
		if (hashSet == null)
		{
			hashSet = new HashSet<int>();
			this.PlayerEntityDisableHandleMap[playerId] = hashSet;
		}
		if (hashSet.Contains(entity.Id))
		{
			return;
		}
		entity.DisableByKey(EEntityDisableKey.Teleport, true);
		hashSet.Add(entity.Id);
	}

	// Token: 0x06011382 RID: 70530 RVA: 0x004B9D74 File Offset: 0x004B7F74
	public void RemovePlayerDisableHandles(int playerId)
	{
		this.PlayerEntityDisableHandleMap.Remove(playerId);
	}

	// Token: 0x06011383 RID: 70531 RVA: 0x004B9D84 File Offset: 0x004B7F84
	public EPlayStationJoinAble GetGameJoinTypeToPlayStationJoinType()
	{
		EPlayStationJoinAble result;
		switch (ModelBase<OnlineModel>.Instance.CurrentPermissionsSetting)
		{
		case WorldEnterPermission.ConfirmJoin:
		case WorldEnterPermission.DirectJoin:
			result = EPlayStationJoinAble.Anyone;
			break;
		case WorldEnterPermission.ForbidJoin:
			result = EPlayStationJoinAble.NoOne;
			break;
		case WorldEnterPermission.OnlyFriendJoin:
			result = EPlayStationJoinAble.Friends;
			break;
		default:
			result = EPlayStationJoinAble.NotSet;
			break;
		}
		return result;
	}

	// Token: 0x06011384 RID: 70532 RVA: 0x004B9DC5 File Offset: 0x004B7FC5
	public void ClearOtherScenePlayerDataList()
	{
		this.OtherScenePlayerDataList.Clear();
	}

	// Token: 0x06011385 RID: 70533 RVA: 0x004B9DD4 File Offset: 0x004B7FD4
	public void DeleteOtherScenePlayerDataList(int playerId)
	{
		List<OtherScenePlayerData> list = new List<OtherScenePlayerData>();
		foreach (OtherScenePlayerData otherScenePlayerData in this.OtherScenePlayerDataList)
		{
			if (otherScenePlayerData.PlayerId != playerId)
			{
				list.Add(otherScenePlayerData);
			}
		}
		this.OtherScenePlayerDataList = list;
	}

	// Token: 0x06011386 RID: 70534 RVA: 0x004B9E40 File Offset: 0x004B8040
	public void PushOtherScenePlayerDataList(OtherScenePlayerData playerInfo)
	{
		this.OtherScenePlayerDataList.Add(playerInfo);
		Singleton<EventSystem>.Instance.Emit(EEventName.ScenePlayerChanged);
	}

	// Token: 0x06011387 RID: 70535 RVA: 0x004B9E60 File Offset: 0x004B8060
	[NullableContext(2)]
	public OtherScenePlayerData GetOtherScenePlayerDataByPlayerId(int playerId)
	{
		foreach (OtherScenePlayerData otherScenePlayerData in this.OtherScenePlayerDataList)
		{
			if (otherScenePlayerData.PlayerId == playerId)
			{
				return otherScenePlayerData;
			}
		}
		return null;
	}

	// Token: 0x06011388 RID: 70536 RVA: 0x004B9EBC File Offset: 0x004B80BC
	[NullableContext(2)]
	public void SetPlayerGravityIsNormal(IVector gravity)
	{
		if (gravity == null)
		{
			this.IsNormalGravity = true;
		}
		else if (gravity.X != 0.0 || gravity.Y != 0.0 || gravity.Z != -1.0)
		{
			this.IsNormalGravity = false;
		}
		else
		{
			this.IsNormalGravity = true;
		}
		this.DisableOnline(EDisableOnlineType.Gravity, !this.IsNormalGravity, 0, 0);
	}

	// Token: 0x06011389 RID: 70537 RVA: 0x004B9F2C File Offset: 0x004B812C
	public string GetMultiInstanceRecommendLevelText(int instanceDungeonId)
	{
		string result = "";
		int ownerId = this.OwnerId;
		int worldLevel = this.GetCurrentTeamListById(ownerId).WorldLevel;
		int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instanceDungeonId, worldLevel);
		if (recommendLevel > 0)
		{
			result = "-" + StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RecommendLevel", null) ?? "", new string[]
			{
				recommendLevel.ToString()
			});
		}
		return result;
	}

	// Token: 0x0400874A RID: 34634
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<OnlineHallData> StrangerWorldList;

	// Token: 0x0400874B RID: 34635
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<OnlineHallData> FriendWorldList;

	// Token: 0x0400874C RID: 34636
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<OnlineHallData> SearchResultList;

	// Token: 0x0400874D RID: 34637
	public List<global::WorldTeamPlayerFightInfo> WorldTeamPlayerFightInfo = new List<global::WorldTeamPlayerFightInfo>();

	// Token: 0x0400874E RID: 34638
	private WorldEnterPermission PermissionsSetting;

	// Token: 0x0400874F RID: 34639
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, OnlineApplyData> ApplyMap;

	// Token: 0x04008750 RID: 34640
	private int Apply;

	// Token: 0x04008751 RID: 34641
	private int ApplyCdTime;

	// Token: 0x04008752 RID: 34642
	private int WorldEnterDiff;

	// Token: 0x04008753 RID: 34643
	private int TeamOwnerId;

	// Token: 0x04008754 RID: 34644
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, OnlineTeamData> OnlineTeamMap;

	// Token: 0x04008755 RID: 34645
	private readonly int OnlineTeamMaxSize = 3;

	// Token: 0x04008756 RID: 34646
	private bool HallShowFriend;

	// Token: 0x04008757 RID: 34647
	private bool HallShowCanJoin;

	// Token: 0x04008758 RID: 34648
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<DisableOnlineSource, EDisableOnlineType> DisableOnlineSource;

	// Token: 0x04008759 RID: 34649
	private readonly Dictionary<int, EContinuingChallenge> ContinuingChallengeConfirmState = new Dictionary<int, EContinuingChallenge>();

	// Token: 0x0400875A RID: 34650
	private int InitiateChallengeApplyPlayerId = -1;

	// Token: 0x0400875B RID: 34651
	private double NextAllowInitiateTime = -1.0;

	// Token: 0x0400875C RID: 34652
	private bool CanInitiate = true;

	// Token: 0x0400875D RID: 34653
	private readonly Dictionary<int, EPlayerTeleportState> PlayerTeleportState = new Dictionary<int, EPlayerTeleportState>();

	// Token: 0x0400875E RID: 34654
	[Nullable(2)]
	public IOnlinePlayerData CachePlayerData;

	// Token: 0x0400875F RID: 34655
	public bool SingleTipsOpen;

	// Token: 0x04008760 RID: 34656
	private readonly Dictionary<int, HashSet<int>> PlayerEntityDisableHandleMap = new Dictionary<int, HashSet<int>>();

	// Token: 0x04008761 RID: 34657
	public List<OtherScenePlayerData> OtherScenePlayerDataList = new List<OtherScenePlayerData>();

	// Token: 0x04008762 RID: 34658
	private bool IsNormalGravity = true;

	// Token: 0x04008763 RID: 34659
	public bool HallViewIsShowSearching;
}
