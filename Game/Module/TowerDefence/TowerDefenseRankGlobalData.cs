using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004E97 RID: 20119
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRankGlobalData
	{
		// Token: 0x1700892E RID: 35118
		// (get) Token: 0x06033FCF RID: 212943 RVA: 0x00D011FC File Offset: 0x00CFF3FC
		public bool IsOpenAnonymousName
		{
			get
			{
				return this.IsOpenAnonymousNameInternal;
			}
		}

		// Token: 0x06033FD0 RID: 212944 RVA: 0x00D01204 File Offset: 0x00CFF404
		public void SetIsOpenAnonymousName(bool isOpen)
		{
			this.IsOpenAnonymousNameInternal = isOpen;
		}

		// Token: 0x06033FD1 RID: 212945 RVA: 0x00D0120D File Offset: 0x00CFF40D
		private int SortNormalPassData(TowerDefenseRankItemData aData, TowerDefenseRankItemData bData)
		{
			return bData.PassScore - aData.PassScore;
		}

		// Token: 0x06033FD2 RID: 212946 RVA: 0x00D0121C File Offset: 0x00CFF41C
		private int SortDifficultPassData(TowerDefenseRankItemData aData, TowerDefenseRankItemData bData)
		{
			return aData.PassScore - bData.PassScore;
		}

		// Token: 0x06033FD3 RID: 212947 RVA: 0x00D0122C File Offset: 0x00CFF42C
		private void RefreshPassDataRank(int instanceId, List<TowerDefenseRankItemData> allDataList, List<TowerDefenseRankItemData> refDataList)
		{
			TowerDefenceInstance? towerDefenseInstanceByInstance = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId);
			Comparison<TowerDefenseRankItemData> comparison = towerDefenseInstanceByInstance.Value.IsDifficult ? new Comparison<TowerDefenseRankItemData>(this.SortDifficultPassData) : new Comparison<TowerDefenseRankItemData>(this.SortNormalPassData);
			refDataList.Clear();
			int towerDefenseRankListSize = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseRankListSize();
			allDataList.Sort(comparison);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (num3 < allDataList.Count && num3 < towerDefenseRankListSize)
			{
				TowerDefenseRankItemData towerDefenseRankItemData = allDataList[num3];
				if (!towerDefenseRankItemData.IsEmpty)
				{
					if (num3 == 0)
					{
						num++;
						num2 = towerDefenseRankItemData.PassScore;
					}
					else if (towerDefenseInstanceByInstance.Value.IsDifficult ? (towerDefenseRankItemData.PassScore > num2) : (towerDefenseRankItemData.PassScore < num2))
					{
						num++;
						num2 = towerDefenseRankItemData.PassScore;
					}
					towerDefenseRankItemData.Rank = num;
					refDataList.Add(towerDefenseRankItemData);
				}
				num3++;
			}
		}

		// Token: 0x06033FD4 RID: 212948 RVA: 0x00D01320 File Offset: 0x00CFF520
		private TowerDefenseRankItemData CreateOwnSinglePassData(int instanceId)
		{
			TowerDefenseRankItemData towerDefenseRankItemData = new TowerDefenseRankItemData(false, ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId).Value.IsDifficult, TowerDefencePassInfo.Create());
			this.SetSelfSinglePassData(towerDefenseRankItemData, instanceId);
			return towerDefenseRankItemData;
		}

		// Token: 0x06033FD5 RID: 212949 RVA: 0x00D01360 File Offset: 0x00CFF560
		private TowerDefenseRankItemData CreateOwnMultiPassData(int instanceId)
		{
			TowerDefenseRankItemData towerDefenseRankItemData = new TowerDefenseRankItemData(true, ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId).Value.IsDifficult, TowerDefencePassInfo.Create());
			this.SetSelfMultiPassData(towerDefenseRankItemData, instanceId);
			return towerDefenseRankItemData;
		}

		// Token: 0x06033FD6 RID: 212950 RVA: 0x00D013A0 File Offset: 0x00CFF5A0
		private void RefreshOwnPassData(int instanceId)
		{
			TowerDefenseRankItemData towerDefenseRankItemData;
			if (!this.AllOwnSinglePassDataMap.TryGetValue(instanceId, out towerDefenseRankItemData))
			{
				towerDefenseRankItemData = this.CreateOwnSinglePassData(instanceId);
			}
			this.OwnSinglePassData = towerDefenseRankItemData;
			this.OwnSinglePassData.IsInRank = this.SinglePassDataList.Contains(towerDefenseRankItemData);
			TowerDefenseRankItemData towerDefenseRankItemData2;
			if (!this.AllOwnMultiPassData.TryGetValue(instanceId, out towerDefenseRankItemData2))
			{
				towerDefenseRankItemData2 = this.CreateOwnMultiPassData(instanceId);
			}
			this.OwnMultiPassData = towerDefenseRankItemData2;
			this.OwnMultiPassData.IsInRank = this.MultiPassDataList.Contains(towerDefenseRankItemData2);
		}

		// Token: 0x06033FD7 RID: 212951 RVA: 0x00D0141C File Offset: 0x00CFF61C
		private List<TowerDefenseRankItemData> GetOrAddSinglePassData(int instanceId)
		{
			List<TowerDefenseRankItemData> list;
			if (!this.AllSinglePassDataMap.TryGetValue(instanceId, out list))
			{
				list = new List<TowerDefenseRankItemData>();
				this.AllSinglePassDataMap.Add(instanceId, list);
			}
			return list;
		}

		// Token: 0x06033FD8 RID: 212952 RVA: 0x00D01450 File Offset: 0x00CFF650
		private List<TowerDefenseRankItemData> GetOrAddMultiPassData(int instanceId)
		{
			List<TowerDefenseRankItemData> list;
			if (!this.AllMultiPassDataMap.TryGetValue(instanceId, out list))
			{
				list = new List<TowerDefenseRankItemData>();
				this.AllMultiPassDataMap.Add(instanceId, list);
			}
			return list;
		}

		// Token: 0x06033FD9 RID: 212953 RVA: 0x00D01481 File Offset: 0x00CFF681
		public void RefreshAllPassDataRank(int instanceId)
		{
			this.RefreshPassDataRank(instanceId, this.GetOrAddSinglePassData(instanceId), this.SinglePassDataList);
			this.RefreshPassDataRank(instanceId, this.GetOrAddMultiPassData(instanceId), this.MultiPassDataList);
			this.RefreshOwnPassData(instanceId);
			this.RefreshSelfRankItemDataName(instanceId);
		}

		// Token: 0x06033FDA RID: 212954 RVA: 0x00D014BC File Offset: 0x00CFF6BC
		public void SetFriendServerData(List<OneTowerDefencePassInfo> friendPassDataList)
		{
			this.AllSinglePassDataMap.Clear();
			this.AllMultiPassDataMap.Clear();
			if (friendPassDataList.Count > 0)
			{
				foreach (OneTowerDefencePassInfo oneTowerDefencePassInfo in friendPassDataList)
				{
					TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(oneTowerDefencePassInfo.ChallengeId);
					TowerDefenseRankItemData towerDefenseRankItemData = new TowerDefenseRankItemData(!oneTowerDefencePassInfo.IsSingle, towerDefenseConfigById.Value.IsDifficult, oneTowerDefencePassInfo.PassInfo);
					if (!towerDefenseRankItemData.IsSelfInData)
					{
						if (towerDefenseRankItemData.IsOnline)
						{
							this.GetOrAddMultiPassData(towerDefenseConfigById.Value.InstanceId).Add(towerDefenseRankItemData);
						}
						else
						{
							this.GetOrAddSinglePassData(towerDefenseConfigById.Value.InstanceId).Add(towerDefenseRankItemData);
						}
					}
				}
			}
		}

		// Token: 0x06033FDB RID: 212955 RVA: 0x00D015AC File Offset: 0x00CFF7AC
		private void RemoveAllSelfPassData(Dictionary<int, List<TowerDefenseRankItemData>> dataMap)
		{
			foreach (KeyValuePair<int, List<TowerDefenseRankItemData>> keyValuePair in dataMap)
			{
				List<TowerDefenseRankItemData> value = keyValuePair.Value;
				for (int i = value.Count - 1; i >= 0; i--)
				{
					if (value[i].IsSelfInData)
					{
						value.RemoveAt(i);
					}
				}
			}
		}

		// Token: 0x06033FDC RID: 212956 RVA: 0x00D01624 File Offset: 0x00CFF824
		private void SetSelfSinglePassData(TowerDefenseRankItemData itemData, int instanceId)
		{
			itemData.IsSelf = true;
			this.AllOwnSinglePassDataMap[instanceId] = itemData;
		}

		// Token: 0x06033FDD RID: 212957 RVA: 0x00D0163A File Offset: 0x00CFF83A
		private void SetSelfMultiPassData(TowerDefenseRankItemData itemData, int instanceId)
		{
			itemData.IsSelf = true;
			this.AllOwnMultiPassData[instanceId] = itemData;
		}

		// Token: 0x06033FDE RID: 212958 RVA: 0x00D01650 File Offset: 0x00CFF850
		public void SetSelfServerData(List<OneTowerDefencePassInfo> selfPassDataList)
		{
			this.RemoveAllSelfPassData(this.AllSinglePassDataMap);
			this.RemoveAllSelfPassData(this.AllMultiPassDataMap);
			if (selfPassDataList.Count > 0)
			{
				foreach (OneTowerDefencePassInfo oneTowerDefencePassInfo in selfPassDataList)
				{
					TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(oneTowerDefencePassInfo.ChallengeId);
					TowerDefenseRankItemData towerDefenseRankItemData = new TowerDefenseRankItemData(!oneTowerDefencePassInfo.IsSingle, towerDefenseConfigById.Value.IsDifficult, oneTowerDefencePassInfo.PassInfo);
					if (towerDefenseRankItemData.IsOnline)
					{
						this.SetSelfMultiPassData(towerDefenseRankItemData, towerDefenseConfigById.Value.InstanceId);
						List<TowerDefenseRankItemData> orAddMultiPassData = this.GetOrAddMultiPassData(towerDefenseConfigById.Value.InstanceId);
						if (orAddMultiPassData != null)
						{
							orAddMultiPassData.Add(towerDefenseRankItemData);
						}
					}
					else
					{
						this.SetSelfSinglePassData(towerDefenseRankItemData, towerDefenseConfigById.Value.InstanceId);
						List<TowerDefenseRankItemData> orAddSinglePassData = this.GetOrAddSinglePassData(towerDefenseConfigById.Value.InstanceId);
						if (orAddSinglePassData != null)
						{
							orAddSinglePassData.Add(towerDefenseRankItemData);
						}
					}
				}
			}
		}

		// Token: 0x06033FDF RID: 212959 RVA: 0x00D01774 File Offset: 0x00CFF974
		public void RefreshSelfRankItemDataName(int instanceId)
		{
			List<TowerDefenseRankItemData> list;
			if (this.AllSinglePassDataMap.TryGetValue(instanceId, out list))
			{
				foreach (TowerDefenseRankItemData towerDefenseRankItemData in list)
				{
					if (towerDefenseRankItemData.IsSelfInData)
					{
						towerDefenseRankItemData.RefreshPlayerName(this.IsOpenAnonymousName);
					}
				}
			}
			List<TowerDefenseRankItemData> list2;
			if (this.AllMultiPassDataMap.TryGetValue(instanceId, out list2))
			{
				foreach (TowerDefenseRankItemData towerDefenseRankItemData2 in list2)
				{
					if (towerDefenseRankItemData2.IsSelfInData)
					{
						towerDefenseRankItemData2.RefreshPlayerName(this.IsOpenAnonymousName);
					}
				}
			}
		}

		// Token: 0x06033FE0 RID: 212960 RVA: 0x00D0183C File Offset: 0x00CFFA3C
		public List<TowerDefenseRankItemData> GetRankDataListByTabType(TowerDefenceDefine.ETabType tabType)
		{
			if (tabType == TowerDefenceDefine.ETabType.Single)
			{
				return this.SinglePassDataList;
			}
			return this.MultiPassDataList;
		}

		// Token: 0x06033FE1 RID: 212961 RVA: 0x00D0184E File Offset: 0x00CFFA4E
		public TowerDefenseRankItemData GetSelfRankDataByTabType(TowerDefenceDefine.ETabType tabType)
		{
			if (tabType == TowerDefenceDefine.ETabType.Single)
			{
				return this.OwnSinglePassData;
			}
			return this.OwnMultiPassData;
		}

		// Token: 0x06033FE2 RID: 212962 RVA: 0x00D01860 File Offset: 0x00CFFA60
		public string GetBestRecordText(int instanceId)
		{
			this.RefreshOwnPassData(instanceId);
			bool isEmpty = this.OwnSinglePassData.IsEmpty;
			bool isEmpty2 = this.OwnMultiPassData.IsEmpty;
			int passTime = this.OwnSinglePassData.PassTime;
			int passTime2 = this.OwnMultiPassData.PassTime;
			int num = 0;
			if (!isEmpty && !isEmpty2)
			{
				num = Math.Min(passTime, passTime2);
			}
			else if (!isEmpty)
			{
				num = passTime;
			}
			else if (!isEmpty2)
			{
				num = passTime2;
			}
			return Singleton<TimeUtil>.Instance.GetTimeDataFormat((double)num);
		}

		// Token: 0x06033FE3 RID: 212963 RVA: 0x00D018D3 File Offset: 0x00CFFAD3
		public bool HasOwnRecord(int instanceId)
		{
			this.RefreshOwnPassData(instanceId);
			return !this.OwnSinglePassData.IsEmpty || !this.OwnMultiPassData.IsEmpty;
		}

		// Token: 0x06033FE4 RID: 212964 RVA: 0x00D018FC File Offset: 0x00CFFAFC
		public bool IsOwnSingleBestScore(int instanceId)
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
			int passScore = this.OwnSinglePassData.PassScore;
			int passScore2 = this.OwnMultiPassData.PassScore;
			if (!ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(instanceId).Value.IsDifficult)
			{
				return passScore >= passScore2;
			}
			return passScore <= passScore2;
		}

		// Token: 0x06033FE5 RID: 212965 RVA: 0x00D01978 File Offset: 0x00CFFB78
		public bool IsOwnSingleBestRecord(int instanceId)
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
			int passTime = this.OwnSinglePassData.PassTime;
			int passTime2 = this.OwnMultiPassData.PassTime;
			return passTime <= passTime2;
		}

		// Token: 0x0401E0C7 RID: 123079
		private bool IsOpenAnonymousNameInternal;

		// Token: 0x0401E0C8 RID: 123080
		private Dictionary<int, List<TowerDefenseRankItemData>> AllSinglePassDataMap = new Dictionary<int, List<TowerDefenseRankItemData>>();

		// Token: 0x0401E0C9 RID: 123081
		private List<TowerDefenseRankItemData> SinglePassDataList = new List<TowerDefenseRankItemData>();

		// Token: 0x0401E0CA RID: 123082
		private Dictionary<int, List<TowerDefenseRankItemData>> AllMultiPassDataMap = new Dictionary<int, List<TowerDefenseRankItemData>>();

		// Token: 0x0401E0CB RID: 123083
		private List<TowerDefenseRankItemData> MultiPassDataList = new List<TowerDefenseRankItemData>();

		// Token: 0x0401E0CC RID: 123084
		private Dictionary<int, TowerDefenseRankItemData> AllOwnSinglePassDataMap = new Dictionary<int, TowerDefenseRankItemData>();

		// Token: 0x0401E0CD RID: 123085
		private Dictionary<int, TowerDefenseRankItemData> AllOwnMultiPassData = new Dictionary<int, TowerDefenseRankItemData>();

		// Token: 0x0401E0CE RID: 123086
		private TowerDefenseRankItemData OwnSinglePassData;

		// Token: 0x0401E0CF RID: 123087
		private TowerDefenseRankItemData OwnMultiPassData;
	}
}
