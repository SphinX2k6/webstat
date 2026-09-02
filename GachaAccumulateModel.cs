using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using Google.Protobuf.Collections;

// Token: 0x02001CC0 RID: 7360
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class GachaAccumulateModel : ModelBase<GachaAccumulateModel>
{
	// Token: 0x0600D7F0 RID: 55280 RVA: 0x0039BFCA File Offset: 0x0039A1CA
	protected override bool OnInit()
	{
		this.AccumulateDataMap.Clear();
		this.GroupIdDataMap.Clear();
		return true;
	}

	// Token: 0x0600D7F1 RID: 55281 RVA: 0x0039BFE3 File Offset: 0x0039A1E3
	protected override bool OnClear()
	{
		this.AccumulateDataMap.Clear();
		this.GroupIdDataMap.Clear();
		return true;
	}

	// Token: 0x0600D7F2 RID: 55282 RVA: 0x0039BFFC File Offset: 0x0039A1FC
	public bool CheckAccumulateIfNeedRequest(int accumulateId)
	{
		return !this.AccumulateDataMap.ContainsKey(accumulateId);
	}

	// Token: 0x0600D7F3 RID: 55283 RVA: 0x0039C010 File Offset: 0x0039A210
	[NullableContext(2)]
	public GachaAccumulateData GetAccumulateData(int accumulateId)
	{
		GachaAccumulateData result;
		if (!this.AccumulateDataMap.TryGetValue(accumulateId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600D7F4 RID: 55284 RVA: 0x0039C030 File Offset: 0x0039A230
	public GachaAccumulateData[] GetAccumulateDataByGroupId(int groupId)
	{
		List<GachaAccumulateData> list;
		if (!this.GroupIdDataMap.TryGetValue(groupId, out list))
		{
			return Array.Empty<GachaAccumulateData>();
		}
		return list.ToArray();
	}

	// Token: 0x0600D7F5 RID: 55285 RVA: 0x0039C059 File Offset: 0x0039A259
	public GachaAccumulateData[] GetAllAccumulateData()
	{
		return this.AccumulateDataMap.Values.ToArray<GachaAccumulateData>();
	}

	// Token: 0x0600D7F6 RID: 55286 RVA: 0x0039C06C File Offset: 0x0039A26C
	public bool HasAnyClaimable()
	{
		using (Dictionary<int, GachaAccumulateData>.ValueCollection.Enumerator enumerator = this.AccumulateDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.HasClaimable)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600D7F7 RID: 55287 RVA: 0x0039C0CC File Offset: 0x0039A2CC
	public void NotifyDataUpdate(int accumulateId)
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.GachaAccumulateDataUpdate, accumulateId);
	}

	// Token: 0x0600D7F8 RID: 55288 RVA: 0x0039C0E0 File Offset: 0x0039A2E0
	public void UpdateAccumulateInfo(GachaAccumulateInfo protoInfo)
	{
		int gachaAccumulateId = protoInfo.GachaAccumulateId;
		if (gachaAccumulateId == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.YZY, "[GachaAccumulateModel] AccumulateId 为 0，数据异常", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		GachaAccumulateData gachaAccumulateData = new GachaAccumulateData
		{
			AccumulateId = gachaAccumulateId
		};
		GachaAccumulateGroupInfo gachaAccumulateGroupInfo = protoInfo.GachaAccumulateGroupInfo;
		if (gachaAccumulateGroupInfo != null)
		{
			gachaAccumulateData.GroupData = this.ConvertGroupInfo(gachaAccumulateGroupInfo);
		}
		this.AccumulateDataMap[gachaAccumulateId] = gachaAccumulateData;
		this.RemoveFromGroupIdMap(gachaAccumulateId);
		GachaAccumulateGroupData groupData = gachaAccumulateData.GroupData;
		int num = (groupData != null) ? groupData.GroupId : 0;
		if (num != 0)
		{
			List<GachaAccumulateData> list;
			if (!this.GroupIdDataMap.TryGetValue(num, out list))
			{
				list = new List<GachaAccumulateData>();
				this.GroupIdDataMap[num] = list;
			}
			list.Add(gachaAccumulateData);
		}
	}

	// Token: 0x0600D7F9 RID: 55289 RVA: 0x0039C194 File Offset: 0x0039A394
	private void RemoveFromGroupIdMap(int accumulateId)
	{
		GachaAccumulateData gachaAccumulateData;
		if (!this.AccumulateDataMap.TryGetValue(accumulateId, out gachaAccumulateData) || gachaAccumulateData.GroupData == null)
		{
			return;
		}
		int groupId = gachaAccumulateData.GroupData.GroupId;
		List<GachaAccumulateData> list;
		if (!this.GroupIdDataMap.TryGetValue(groupId, out list))
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].AccumulateId == accumulateId)
			{
				list.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x0600D7FA RID: 55290 RVA: 0x0039C200 File Offset: 0x0039A400
	private GachaAccumulateGroupData ConvertGroupInfo(GachaAccumulateGroupInfo protoGroup)
	{
		GachaAccumulateGroupData gachaAccumulateGroupData = new GachaAccumulateGroupData
		{
			GroupId = protoGroup.GroupId,
			CurGachaNum = protoGroup.CurGachaNum
		};
		foreach (GachaAccumulateRewardInfo protoReward in protoGroup.GachaAccumulateRewardInfos)
		{
			gachaAccumulateGroupData.RewardInfos.Add(this.ConvertRewardInfo(protoReward));
		}
		gachaAccumulateGroupData.RewardInfos.Sort((GachaAccumulateRewardData a, GachaAccumulateRewardData b) => a.GachaNum.CompareTo(b.GachaNum));
		return gachaAccumulateGroupData;
	}

	// Token: 0x0600D7FB RID: 55291 RVA: 0x0039C2A4 File Offset: 0x0039A4A4
	private GachaAccumulateRewardData ConvertRewardInfo(GachaAccumulateRewardInfo protoReward)
	{
		GachaAccumulateRewardData gachaAccumulateRewardData = new GachaAccumulateRewardData
		{
			Id = protoReward.Id,
			GroupId = protoReward.GroupId,
			GachaNum = protoReward.GachaNum,
			Status = (EGachaAccumulateRewardStatus)protoReward.Status,
			IsBigReward = protoReward.IsBigReward,
			CycleCount = protoReward.CycleCount,
			CycleRewardedTimes = protoReward.CycleRewardedTimes,
			IsPreView = protoReward.IsPreView
		};
		MapField<int, int> rewardContent = protoReward.RewardContent;
		if (rewardContent != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in rewardContent)
			{
				gachaAccumulateRewardData.RewardContent[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		return gachaAccumulateRewardData;
	}

	// Token: 0x0600D7FC RID: 55292 RVA: 0x0039C370 File Offset: 0x0039A570
	public bool IfGachaAccumulateNeedAutoOpenTips(int accumulateId)
	{
		if (accumulateId == 0)
		{
			return false;
		}
		ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.GachaAccumulateFirstOpen) as ServerStorageSet;
		foreach (ProtoGachaInfo protoGachaInfo in ModelBase<GachaModel>.Instance.GachaInfoArray)
		{
			if (protoGachaInfo.GachaAccumulateId == accumulateId && !serverStorageSet.Has(protoGachaInfo.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600D7FD RID: 55293 RVA: 0x0039C3CC File Offset: 0x0039A5CC
	public void SaveGachaAccumulateAutoOpenTips(int accumulateId)
	{
		ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.GachaAccumulateFirstOpen) as ServerStorageSet;
		foreach (ProtoGachaInfo protoGachaInfo in ModelBase<GachaModel>.Instance.GachaInfoArray)
		{
			if (protoGachaInfo.GachaAccumulateId == accumulateId && !serverStorageSet.Has(protoGachaInfo.Id))
			{
				serverStorageSet.Add(protoGachaInfo.Id);
			}
		}
	}

	// Token: 0x040066D3 RID: 26323
	private readonly Dictionary<int, GachaAccumulateData> AccumulateDataMap = new Dictionary<int, GachaAccumulateData>();

	// Token: 0x040066D4 RID: 26324
	private readonly Dictionary<int, List<GachaAccumulateData>> GroupIdDataMap = new Dictionary<int, List<GachaAccumulateData>>();
}
