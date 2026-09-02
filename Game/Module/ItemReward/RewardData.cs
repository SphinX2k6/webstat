using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B40 RID: 23360
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardData<[Nullable(0)] T> : IRewardDataInterface where T : IRewardInfo
	{
		// Token: 0x17009731 RID: 38705
		// (get) Token: 0x0603B159 RID: 242009 RVA: 0x00EF3730 File Offset: 0x00EF1930
		// (set) Token: 0x0603B15A RID: 242010 RVA: 0x00EF3738 File Offset: 0x00EF1938
		[Nullable(2)]
		public IExtendRewardInfo ExtendRewardInfo { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009732 RID: 38706
		// (get) Token: 0x0603B15B RID: 242011 RVA: 0x00EF3741 File Offset: 0x00EF1941
		// (set) Token: 0x0603B15C RID: 242012 RVA: 0x00EF3749 File Offset: 0x00EF1949
		public Dictionary<int, RewardItemData> ItemConfigIdMap { get; set; } = new Dictionary<int, RewardItemData>();

		// Token: 0x17009733 RID: 38707
		// (get) Token: 0x0603B15D RID: 242013 RVA: 0x00EF3752 File Offset: 0x00EF1952
		// (set) Token: 0x0603B15E RID: 242014 RVA: 0x00EF375A File Offset: 0x00EF195A
		public Dictionary<int, RewardItemData> ItemUniqueIdMap { get; set; } = new Dictionary<int, RewardItemData>();

		// Token: 0x0603B15F RID: 242015 RVA: 0x00EF3764 File Offset: 0x00EF1964
		[NullableContext(2)]
		public RewardData(T rewardInfo = default(T), IExtendRewardInfo extendRewardInfo = null)
		{
			if (rewardInfo != null)
			{
				this.RewardInfo = rewardInfo;
			}
			if (extendRewardInfo != null)
			{
				this.ExtendRewardInfo = extendRewardInfo;
				return;
			}
			this.ExtendRewardInfo = new ExtendRewardInfo
			{
				ItemList = new List<RewardItemData>()
			};
		}

		// Token: 0x0603B160 RID: 242016 RVA: 0x00EF37BD File Offset: 0x00EF19BD
		public RewardData<T> InheritData([Nullable(2)] IRewardDataInterface copyRewardData)
		{
			if (copyRewardData == null)
			{
				return this;
			}
			this.ExtendRewardInfo = copyRewardData.ExtendRewardInfo;
			this.ItemConfigIdMap = copyRewardData.ItemConfigIdMap;
			this.ItemUniqueIdMap = copyRewardData.ItemUniqueIdMap;
			return this;
		}

		// Token: 0x0603B161 RID: 242017 RVA: 0x00EF37EC File Offset: 0x00EF19EC
		public void SetItemList([Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemList)
		{
			if (rewardItemList == null)
			{
				return;
			}
			this.ExtendRewardInfo.ItemList = rewardItemList;
			foreach (RewardItemData rewardItemData in rewardItemList)
			{
				int uniqueId = rewardItemData.UniqueId;
				if (uniqueId > 0)
				{
					this.ItemUniqueIdMap[uniqueId] = rewardItemData;
				}
				else
				{
					int configId = rewardItemData.ConfigId;
					if (configId > 0)
					{
						RewardItemData rewardItemData2;
						if (!this.ItemConfigIdMap.TryGetValue(configId, out rewardItemData2))
						{
							this.ItemConfigIdMap[configId] = rewardItemData;
							break;
						}
						rewardItemData2.Count += rewardItemData.Count;
					}
				}
			}
		}

		// Token: 0x0603B162 RID: 242018 RVA: 0x00EF389C File Offset: 0x00EF1A9C
		public void AddItem(RewardItemData rewardItemData)
		{
			List<RewardItemData> list = this.GetItemList();
			if (list == null)
			{
				list = new List<RewardItemData>();
			}
			int uniqueId = rewardItemData.UniqueId;
			if (uniqueId > 0)
			{
				list.Add(rewardItemData);
				this.ItemUniqueIdMap[uniqueId] = rewardItemData;
				return;
			}
			int configId = rewardItemData.ConfigId;
			if (configId > 0)
			{
				RewardItemData rewardItemData2;
				if (!this.ItemConfigIdMap.TryGetValue(configId, out rewardItemData2))
				{
					list.Add(rewardItemData);
					this.ItemConfigIdMap[configId] = rewardItemData;
					return;
				}
				rewardItemData2.Count += rewardItemData.Count;
			}
		}

		// Token: 0x0603B163 RID: 242019 RVA: 0x00EF391C File Offset: 0x00EF1B1C
		public void AddItemList(IReadOnlyList<RewardItemData> itemList)
		{
			if (itemList == null)
			{
				return;
			}
			foreach (RewardItemData rewardItemData in itemList)
			{
				this.AddItem(rewardItemData);
			}
		}

		// Token: 0x0603B164 RID: 242020 RVA: 0x00EF3968 File Offset: 0x00EF1B68
		public void SetProgressQueue([Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardProgress> progressQueue = null)
		{
			this.ExtendRewardInfo.ProgressQueue = progressQueue;
		}

		// Token: 0x0603B165 RID: 242021 RVA: 0x00EF3976 File Offset: 0x00EF1B76
		public void SetExploreRecordInfo(IRewardExploreRecord exploreRecordInfo)
		{
			this.ExtendRewardInfo.ExploreRecordInfo = exploreRecordInfo;
		}

		// Token: 0x0603B166 RID: 242022 RVA: 0x00EF3984 File Offset: 0x00EF1B84
		public void SetExploreBarDataList(List<IRewardExploreBar> exploreBarDataList)
		{
			this.ExtendRewardInfo.ExploreBarDataList = exploreBarDataList;
		}

		// Token: 0x0603B167 RID: 242023 RVA: 0x00EF3992 File Offset: 0x00EF1B92
		public void SetButtonInfoList(List<IRewardExploreConfirmButton> buttonInfoList)
		{
			this.ExtendRewardInfo.ButtonInfoList = buttonInfoList;
		}

		// Token: 0x0603B168 RID: 242024 RVA: 0x00EF39A0 File Offset: 0x00EF1BA0
		public void SetExploreFriendDataList(List<IRewardExploreFriendData> friendDataList)
		{
			this.ExtendRewardInfo.ExploreFriendDataList = friendDataList;
		}

		// Token: 0x0603B169 RID: 242025 RVA: 0x00EF39AE File Offset: 0x00EF1BAE
		public void SetTargetReached(List<IRewardExploreTargetReached> targetReached)
		{
			this.ExtendRewardInfo.TargetReached = targetReached;
		}

		// Token: 0x0603B16A RID: 242026 RVA: 0x00EF39BC File Offset: 0x00EF1BBC
		public void SetHalfAreaData(IRewardExploreScoreBelongHalfArea halfAreaData)
		{
			this.ExtendRewardInfo.ScoreHalfArea = halfAreaData;
		}

		// Token: 0x0603B16B RID: 242027 RVA: 0x00EF39CA File Offset: 0x00EF1BCA
		public void SetStateToggle(IRewardExploreToggle stateToggle)
		{
			this.ExtendRewardInfo.StateToggle = stateToggle;
		}

		// Token: 0x0603B16C RID: 242028 RVA: 0x00EF39D8 File Offset: 0x00EF1BD8
		public void SetAccumulatedScoreData(AccumulatedScoreData scoreData)
		{
			this.ExtendRewardInfo.AccumulatedScoreData = scoreData;
		}

		// Token: 0x0603B16D RID: 242029 RVA: 0x00EF39E6 File Offset: 0x00EF1BE6
		public void SetBabelTowerSuccessData(IBabelTowerSuccessData data)
		{
			this.ExtendRewardInfo.BabelTowerSuccessData = data;
		}

		// Token: 0x0603B16E RID: 242030 RVA: 0x00EF39F4 File Offset: 0x00EF1BF4
		public void SetDangoAbyssSuccessData(IDangoAbyssSuccessData data)
		{
			this.ExtendRewardInfo.DangoAbyssSuccessData = data;
		}

		// Token: 0x0603B16F RID: 242031 RVA: 0x00EF3A02 File Offset: 0x00EF1C02
		public void SetHonamiTowerSuccessData(IHonamiTowerSuccessData data)
		{
			this.ExtendRewardInfo.HonamiTowerSuccessData = data;
		}

		// Token: 0x0603B170 RID: 242032 RVA: 0x00EF3A10 File Offset: 0x00EF1C10
		public void SetRoguelikeBossChallengeData(IRoguelikeBossChallengeData data)
		{
			this.ExtendRewardInfo.RoguelikeBossChallengeData = data;
		}

		// Token: 0x0603B171 RID: 242033 RVA: 0x00EF3A1E File Offset: 0x00EF1C1E
		public void SetScoreReached(ReachTargetData scoreReached)
		{
			this.ExtendRewardInfo.ScoreReached = scoreReached;
		}

		// Token: 0x0603B172 RID: 242034 RVA: 0x00EF3A2C File Offset: 0x00EF1C2C
		public void SetRewardInfo(T rewardInfo)
		{
			this.RewardInfo = rewardInfo;
		}

		// Token: 0x0603B173 RID: 242035 RVA: 0x00EF3A35 File Offset: 0x00EF1C35
		public T GetRewardInfo()
		{
			return this.RewardInfo;
		}

		// Token: 0x0603B174 RID: 242036 RVA: 0x00EF3A3D File Offset: 0x00EF1C3D
		[NullableContext(2)]
		public IExtendRewardInfo GetExtendRewardInfo()
		{
			return this.ExtendRewardInfo;
		}

		// Token: 0x0603B175 RID: 242037 RVA: 0x00EF3A45 File Offset: 0x00EF1C45
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RewardItemData> GetItemList()
		{
			return this.ExtendRewardInfo.ItemList;
		}

		// Token: 0x0603B176 RID: 242038 RVA: 0x00EF3A54 File Offset: 0x00EF1C54
		[NullableContext(2)]
		public RewardItemData GetItemByConfigId(int configId)
		{
			RewardItemData result;
			this.ItemConfigIdMap.TryGetValue(configId, out result);
			return result;
		}

		// Token: 0x0603B177 RID: 242039 RVA: 0x00EF3A74 File Offset: 0x00EF1C74
		[NullableContext(2)]
		public RewardItemData GetItemByUniqueId(int uniqueId)
		{
			RewardItemData result;
			this.ItemUniqueIdMap.TryGetValue(uniqueId, out result);
			return result;
		}

		// Token: 0x04021536 RID: 136502
		[Nullable(2)]
		private T RewardInfo;
	}
}
