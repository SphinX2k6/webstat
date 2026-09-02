using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001AC0 RID: 6848
[NullableContext(1)]
[Nullable(0)]
public class AbyssRankChallengeInfo
{
	// Token: 0x0600C4A1 RID: 50337 RVA: 0x0033E224 File Offset: 0x0033C424
	public void SetIsOpenAnonymousName(int challengeId, bool isOpen)
	{
		this.ChallengeAnonymousMap[challengeId] = isOpen;
		List<global::AbyssChallengeInfo> list;
		if (this.AllMultiPassDataMap.TryGetValue(challengeId, out list))
		{
			foreach (global::AbyssChallengeInfo abyssChallengeInfo in list)
			{
				abyssChallengeInfo.SetNameMode(isOpen);
			}
		}
		List<global::AbyssChallengeInfo> list2;
		if (this.AllSinglePassDataMap.TryGetValue(challengeId, out list2))
		{
			foreach (global::AbyssChallengeInfo abyssChallengeInfo2 in list2)
			{
				abyssChallengeInfo2.SetNameMode(isOpen);
			}
		}
	}

	// Token: 0x0600C4A2 RID: 50338 RVA: 0x0033E2D8 File Offset: 0x0033C4D8
	public void OnSelfRankInfoUpdate(AbyssSelfPassResponse data)
	{
		this.RemoveAllSelfPassData(this.AllSinglePassDataMap);
		this.RemoveAllSelfPassData(this.AllMultiPassDataMap);
		if (data.SelfPassData.Count == 0)
		{
			return;
		}
		this.SelfRankInfo = Array.Empty<global::AbyssChallengeInfo>();
		List<global::AbyssChallengeInfo> list = new List<global::AbyssChallengeInfo>();
		int count = data.SelfPassData.Count;
		for (int i = 0; i < count; i++)
		{
			global::AbyssChallengeInfo abyssChallengeInfo = new global::AbyssChallengeInfo();
			abyssChallengeInfo.Phrase(data.SelfPassData[i]);
			list.Add(abyssChallengeInfo);
			if (abyssChallengeInfo.GetIsSingle())
			{
				this.GetOrAddSinglePassData(abyssChallengeInfo.GetChallengeId()).Add(abyssChallengeInfo);
				this.SetSelfSinglePassData(abyssChallengeInfo, abyssChallengeInfo.GetChallengeId());
			}
			else
			{
				this.GetOrAddMultiPassData(abyssChallengeInfo.GetChallengeId()).Add(abyssChallengeInfo);
				this.SetSelfMultiPassData(abyssChallengeInfo, abyssChallengeInfo.GetChallengeId());
			}
		}
		this.SelfRankInfo = list.ToArray();
		foreach (global::AbyssChallengeInfo abyssChallengeInfo2 in this.SelfRankInfo)
		{
			int challengeId = abyssChallengeInfo2.GetChallengeId();
			bool showName = abyssChallengeInfo2.GetShowName();
			this.ChallengeAnonymousMap[challengeId] = showName;
		}
	}

	// Token: 0x0600C4A3 RID: 50339 RVA: 0x0033E3E8 File Offset: 0x0033C5E8
	public bool GetAnonymousNameMode(int challengeId)
	{
		bool flag;
		return !this.ChallengeAnonymousMap.TryGetValue(challengeId, out flag) || flag;
	}

	// Token: 0x0600C4A4 RID: 50340 RVA: 0x0033E408 File Offset: 0x0033C608
	private void RemoveAllSelfPassData(Dictionary<int, List<global::AbyssChallengeInfo>> dataMap)
	{
		foreach (KeyValuePair<int, List<global::AbyssChallengeInfo>> keyValuePair in dataMap)
		{
			List<global::AbyssChallengeInfo> value = keyValuePair.Value;
			for (int i = value.Count - 1; i >= 0; i--)
			{
				if (value[i].IsSelf)
				{
					value.RemoveAt(i);
					break;
				}
			}
		}
	}

	// Token: 0x0600C4A5 RID: 50341 RVA: 0x0033E484 File Offset: 0x0033C684
	public void OnChallengeRankInfoUpdate(AbyssRankListResponse data)
	{
		this.AllSinglePassDataMap.Clear();
		this.AllMultiPassDataMap.Clear();
		this.FriendRankList = Array.Empty<global::AbyssChallengeInfo>();
		List<global::AbyssChallengeInfo> list = new List<global::AbyssChallengeInfo>();
		int count = data.FriendPassData.Count;
		for (int i = 0; i < count; i++)
		{
			global::AbyssChallengeInfo abyssChallengeInfo = new global::AbyssChallengeInfo();
			abyssChallengeInfo.Phrase(data.FriendPassData[i]);
			list.Add(abyssChallengeInfo);
			if (abyssChallengeInfo.GetIsSingle())
			{
				this.GetOrAddSinglePassData(abyssChallengeInfo.GetChallengeId()).Add(abyssChallengeInfo);
			}
			else
			{
				this.GetOrAddMultiPassData(abyssChallengeInfo.GetChallengeId()).Add(abyssChallengeInfo);
			}
		}
		this.FriendRankList = list.ToArray();
		this.SelfRankInfo = Array.Empty<global::AbyssChallengeInfo>();
		List<global::AbyssChallengeInfo> list2 = new List<global::AbyssChallengeInfo>();
		int count2 = data.SelfPassData.Count;
		for (int j = 0; j < count2; j++)
		{
			global::AbyssChallengeInfo abyssChallengeInfo2 = new global::AbyssChallengeInfo();
			abyssChallengeInfo2.Phrase(data.SelfPassData[j]);
			list2.Add(abyssChallengeInfo2);
			if (abyssChallengeInfo2.GetIsSingle())
			{
				this.GetOrAddSinglePassData(abyssChallengeInfo2.GetChallengeId()).Add(abyssChallengeInfo2);
				this.SetSelfSinglePassData(abyssChallengeInfo2, abyssChallengeInfo2.GetChallengeId());
			}
			else
			{
				this.GetOrAddMultiPassData(abyssChallengeInfo2.GetChallengeId()).Add(abyssChallengeInfo2);
				this.SetSelfMultiPassData(abyssChallengeInfo2, abyssChallengeInfo2.GetChallengeId());
			}
		}
		this.SelfRankInfo = list2.ToArray();
	}

	// Token: 0x0600C4A6 RID: 50342 RVA: 0x0033E5E4 File Offset: 0x0033C7E4
	public void RefreshAllPassDataRank(int challengeId)
	{
		List<global::AbyssChallengeInfo> orAddSinglePassData = this.GetOrAddSinglePassData(challengeId);
		this.RefreshPassDataRank(challengeId, orAddSinglePassData, this.SinglePassDataList);
		List<global::AbyssChallengeInfo> orAddMultiPassData = this.GetOrAddMultiPassData(challengeId);
		this.RefreshPassDataRank(challengeId, orAddMultiPassData, this.MultiPassDataList);
		this.RefreshOwnPassData(challengeId);
		this.RefreshSelfRankItemDataName(challengeId);
	}

	// Token: 0x0600C4A7 RID: 50343 RVA: 0x0033E62C File Offset: 0x0033C82C
	private void RefreshOwnPassData(int challengeId)
	{
		global::AbyssChallengeInfo abyssChallengeInfo;
		if (!this.AllOwnSinglePassDataMap.TryGetValue(challengeId, out abyssChallengeInfo))
		{
			abyssChallengeInfo = this.CreateOwnSinglePassData(challengeId);
		}
		this.OwnSinglePassData = abyssChallengeInfo;
		this.OwnSinglePassData.IsInRank = this.SinglePassDataList.Contains(abyssChallengeInfo);
		global::AbyssChallengeInfo abyssChallengeInfo2;
		if (!this.AllOwnMultiPassData.TryGetValue(challengeId, out abyssChallengeInfo2))
		{
			abyssChallengeInfo2 = this.CreateOwnMultiPassData(challengeId);
		}
		this.OwnMultiPassData = abyssChallengeInfo2;
		this.OwnMultiPassData.IsInRank = this.MultiPassDataList.Contains(abyssChallengeInfo2);
	}

	// Token: 0x0600C4A8 RID: 50344 RVA: 0x0033E6A8 File Offset: 0x0033C8A8
	private global::AbyssChallengeInfo CreateOwnSinglePassData(int challengeId)
	{
		global::AbyssChallengeInfo abyssChallengeInfo = new global::AbyssChallengeInfo();
		this.SetSelfSinglePassData(abyssChallengeInfo, challengeId);
		return abyssChallengeInfo;
	}

	// Token: 0x0600C4A9 RID: 50345 RVA: 0x0033E6C4 File Offset: 0x0033C8C4
	private global::AbyssChallengeInfo CreateOwnMultiPassData(int challengeId)
	{
		global::AbyssChallengeInfo abyssChallengeInfo = new global::AbyssChallengeInfo();
		this.SetSelfMultiPassData(abyssChallengeInfo, challengeId);
		return abyssChallengeInfo;
	}

	// Token: 0x0600C4AA RID: 50346 RVA: 0x0033E6E0 File Offset: 0x0033C8E0
	private int SortNormalPassData(global::AbyssChallengeInfo aData, global::AbyssChallengeInfo bData)
	{
		if (aData.GetProgress() == bData.GetProgress())
		{
			return aData.GetPassTime() - bData.GetPassTime();
		}
		return bData.GetProgress() - aData.GetProgress();
	}

	// Token: 0x0600C4AB RID: 50347 RVA: 0x0033E70C File Offset: 0x0033C90C
	private void RefreshPassDataRank(int challengeId, List<global::AbyssChallengeInfo> allDataList, List<global::AbyssChallengeInfo> refDataList)
	{
		refDataList.Clear();
		allDataList.Sort(new Comparison<global::AbyssChallengeInfo>(this.SortNormalPassData));
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < allDataList.Count; i++)
		{
			global::AbyssChallengeInfo abyssChallengeInfo = allDataList[i];
			if (i == 0)
			{
				num++;
				num2 = abyssChallengeInfo.GetPassTime();
				num3 = abyssChallengeInfo.GetProgress();
			}
			else
			{
				bool flag = abyssChallengeInfo.GetPassTime() != num2;
				bool flag2 = abyssChallengeInfo.GetProgress() != num3;
				if (flag || flag2)
				{
					num++;
					num2 = abyssChallengeInfo.GetPassTime();
					num3 = abyssChallengeInfo.GetProgress();
				}
			}
			abyssChallengeInfo.Rank = num;
			refDataList.Add(abyssChallengeInfo);
		}
	}

	// Token: 0x0600C4AC RID: 50348 RVA: 0x0033E7B0 File Offset: 0x0033C9B0
	public void RefreshSelfRankItemDataName(int challengeId)
	{
		List<global::AbyssChallengeInfo> list;
		if (this.AllSinglePassDataMap.TryGetValue(challengeId, out list))
		{
			foreach (global::AbyssChallengeInfo abyssChallengeInfo in list)
			{
				if (abyssChallengeInfo.IsSelfInData)
				{
					bool anonymousNameMode = this.GetAnonymousNameMode(challengeId);
					abyssChallengeInfo.RefreshPlayerName(anonymousNameMode);
				}
			}
		}
		List<global::AbyssChallengeInfo> list2;
		if (this.AllMultiPassDataMap.TryGetValue(challengeId, out list2))
		{
			foreach (global::AbyssChallengeInfo abyssChallengeInfo2 in list2)
			{
				if (abyssChallengeInfo2.IsSelfInData)
				{
					bool anonymousNameMode2 = this.GetAnonymousNameMode(challengeId);
					abyssChallengeInfo2.RefreshPlayerName(anonymousNameMode2);
				}
			}
		}
	}

	// Token: 0x0600C4AD RID: 50349 RVA: 0x0033E884 File Offset: 0x0033CA84
	public global::AbyssChallengeInfo[] GetRankDataListByOnlineType(bool onlineState)
	{
		if (!onlineState)
		{
			return this.SinglePassDataList.ToArray();
		}
		return this.MultiPassDataList.ToArray();
	}

	// Token: 0x0600C4AE RID: 50350 RVA: 0x0033E8A0 File Offset: 0x0033CAA0
	public global::AbyssChallengeInfo GetSelfRankDataByTabType(bool onlineState)
	{
		if (!onlineState)
		{
			return this.OwnSinglePassData;
		}
		return this.OwnMultiPassData;
	}

	// Token: 0x0600C4AF RID: 50351 RVA: 0x0033E8B4 File Offset: 0x0033CAB4
	private List<global::AbyssChallengeInfo> GetOrAddSinglePassData(int challengeId)
	{
		List<global::AbyssChallengeInfo> list;
		if (!this.AllSinglePassDataMap.TryGetValue(challengeId, out list))
		{
			list = new List<global::AbyssChallengeInfo>();
			this.AllSinglePassDataMap[challengeId] = list;
		}
		return list;
	}

	// Token: 0x0600C4B0 RID: 50352 RVA: 0x0033E8E5 File Offset: 0x0033CAE5
	private void SetSelfSinglePassData(global::AbyssChallengeInfo itemData, int challengeId)
	{
		itemData.IsSelf = true;
		this.AllOwnSinglePassDataMap[challengeId] = itemData;
	}

	// Token: 0x0600C4B1 RID: 50353 RVA: 0x0033E8FC File Offset: 0x0033CAFC
	private List<global::AbyssChallengeInfo> GetOrAddMultiPassData(int challengeId)
	{
		List<global::AbyssChallengeInfo> list;
		if (!this.AllMultiPassDataMap.TryGetValue(challengeId, out list))
		{
			list = new List<global::AbyssChallengeInfo>();
			this.AllMultiPassDataMap[challengeId] = list;
		}
		return list;
	}

	// Token: 0x0600C4B2 RID: 50354 RVA: 0x0033E92D File Offset: 0x0033CB2D
	private void SetSelfMultiPassData(global::AbyssChallengeInfo itemData, int challengeId)
	{
		itemData.IsSelf = true;
		this.AllOwnMultiPassData[challengeId] = itemData;
	}

	// Token: 0x0600C4B3 RID: 50355 RVA: 0x0033E944 File Offset: 0x0033CB44
	public bool IsOwnSingleBestScore(int challengeId)
	{
		bool isEmpty = this.OwnSinglePassData.IsEmpty;
		bool isEmpty2 = this.OwnMultiPassData.IsEmpty;
		if (isEmpty == isEmpty2 && isEmpty)
		{
			return true;
		}
		if (isEmpty != isEmpty2)
		{
			return isEmpty2;
		}
		int passTime = this.OwnSinglePassData.GetPassTime();
		int passTime2 = this.OwnMultiPassData.GetPassTime();
		return passTime <= passTime2;
	}

	// Token: 0x04005E4F RID: 24143
	private readonly Dictionary<int, bool> ChallengeAnonymousMap = new Dictionary<int, bool>();

	// Token: 0x04005E50 RID: 24144
	private readonly Dictionary<int, List<global::AbyssChallengeInfo>> AllMultiPassDataMap = new Dictionary<int, List<global::AbyssChallengeInfo>>();

	// Token: 0x04005E51 RID: 24145
	private readonly Dictionary<int, global::AbyssChallengeInfo> AllOwnSinglePassDataMap = new Dictionary<int, global::AbyssChallengeInfo>();

	// Token: 0x04005E52 RID: 24146
	private readonly Dictionary<int, List<global::AbyssChallengeInfo>> AllSinglePassDataMap = new Dictionary<int, List<global::AbyssChallengeInfo>>();

	// Token: 0x04005E53 RID: 24147
	private readonly Dictionary<int, global::AbyssChallengeInfo> AllOwnMultiPassData = new Dictionary<int, global::AbyssChallengeInfo>();

	// Token: 0x04005E54 RID: 24148
	private readonly List<global::AbyssChallengeInfo> SinglePassDataList = new List<global::AbyssChallengeInfo>();

	// Token: 0x04005E55 RID: 24149
	private readonly List<global::AbyssChallengeInfo> MultiPassDataList = new List<global::AbyssChallengeInfo>();

	// Token: 0x04005E56 RID: 24150
	private global::AbyssChallengeInfo[] FriendRankList = Array.Empty<global::AbyssChallengeInfo>();

	// Token: 0x04005E57 RID: 24151
	private global::AbyssChallengeInfo[] SelfRankInfo = Array.Empty<global::AbyssChallengeInfo>();

	// Token: 0x04005E58 RID: 24152
	private global::AbyssChallengeInfo OwnSinglePassData;

	// Token: 0x04005E59 RID: 24153
	private global::AbyssChallengeInfo OwnMultiPassData;
}
