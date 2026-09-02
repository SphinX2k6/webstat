using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.RacingBets.Data
{
	// Token: 0x020052A2 RID: 21154
	[NullableContext(1)]
	[Nullable(0)]
	public class RacingBetsSeasonData : ActivityBaseData
	{
		// Token: 0x0603617C RID: 221564 RVA: 0x00D9ECAC File Offset: 0x00D9CEAC
		protected override void PhraseEx(ActivityData data)
		{
			RacingBetsActivityData racingBetsData = data.RacingBetsData;
			if (racingBetsData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.LRC, "RacingBetsSeasonData初始化 无效activityInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.IsInit)
			{
				this.Refresh(racingBetsData);
				return;
			}
			this.SeasonConfig = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsSeasonConfig(base.Id).Value;
			this.InitMatchData(new List<RacingBetsGroupMatchesInfo>(racingBetsData.MatchInfos));
			this.RefreshPlayerData(racingBetsData.PlayerInfo);
			this.InitRewardData(new List<ConditionTaskData>(racingBetsData.TaskDatas));
			this.InitRankUpdateTime(racingBetsData.RankListUpdateTime);
			this.InitCloseSettleLegMatchIdList(new List<int>(racingBetsData.CloseSettleMenuLegMatchList));
			ModelBase<RacingBetsModel>.Instance.CheckMatchRedDot();
			ModelBase<RacingBetsModel>.Instance.CheckRankRedDot();
			this.IsInit = true;
			Singleton<EventSystem>.Instance.Emit<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, this);
		}

		// Token: 0x0603617D RID: 221565 RVA: 0x00D9ED88 File Offset: 0x00D9CF88
		private void Refresh(RacingBetsActivityData activityInfo)
		{
			this.RefreshMatchData(new List<RacingBetsGroupMatchesInfo>(activityInfo.MatchInfos));
			this.RefreshPlayerData(activityInfo.PlayerInfo);
			this.RefreshRewardData(new List<ConditionTaskData>(activityInfo.TaskDatas));
			this.InitRankUpdateTime(activityInfo.RankListUpdateTime);
			ModelBase<RacingBetsModel>.Instance.CheckMatchRedDot();
			ModelBase<RacingBetsModel>.Instance.CheckRankRedDot();
			Singleton<EventSystem>.Instance.Emit<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, this);
		}

		// Token: 0x0603617E RID: 221566 RVA: 0x00D9EDF4 File Offset: 0x00D9CFF4
		public void RefreshMatchInfo(RacingBetsMatchInfoResponse message)
		{
			this.RefreshMatchData(new List<RacingBetsGroupMatchesInfo>(message.MatchInfos));
		}

		// Token: 0x0603617F RID: 221567 RVA: 0x00D9EE07 File Offset: 0x00D9D007
		protected override void OnActivityClose()
		{
			ControllerBase<RacingBetsController>.Instance.TryLeaveRacingBetsDungeon();
		}

		// Token: 0x06036180 RID: 221568 RVA: 0x00D9EE14 File Offset: 0x00D9D014
		public override bool GetExDataRedPointShowState()
		{
			using (Dictionary<int, RacingBetsRewardData>.ValueCollection.Enumerator enumerator = this.RewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.CanReceiveReward())
					{
						return true;
					}
				}
			}
			RacingBetsLegMatchData curLegMatchData = this.GetCurLegMatchData();
			if (curLegMatchData == null)
			{
				return false;
			}
			ERacingBetsLegMatchState legMatchState = curLegMatchData.GetLegMatchState();
			if (legMatchState == ERacingBetsLegMatchState.BettingPeriod && curLegMatchData.BetDangoId == 0)
			{
				return true;
			}
			int player = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RacingBetsWatchGameRecord, 0);
			if (legMatchState == ERacingBetsLegMatchState.MatchPeriod && curLegMatchData.Id > player)
			{
				return true;
			}
			int player2 = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RacingBetsReplayGameRecord, 0);
			return legMatchState == ERacingBetsLegMatchState.EndOfMatch && curLegMatchData.Id > player2;
		}

		// Token: 0x06036181 RID: 221569 RVA: 0x00D9EECC File Offset: 0x00D9D0CC
		private void InitMatchData(List<RacingBetsGroupMatchesInfo> matchInfos)
		{
			if (matchInfos == null || matchInfos.Count <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.LRC, "RacingBetsSeasonData初始化 无效matchInfos", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.GroupMatchMap.Clear();
			this.LegMatchMap.Clear();
			this.LegMatchList = new List<RacingBetsLegMatchData>();
			foreach (RacingBetsGroupMatchesInfo matchInfo in matchInfos)
			{
				RacingBetsGroupMatchData racingBetsGroupMatchData = new RacingBetsGroupMatchData();
				racingBetsGroupMatchData.Init(matchInfo);
				List<RacingBetsLegMatchData> legMatchList = racingBetsGroupMatchData.GetLegMatchList();
				this.GroupMatchMap.Add(racingBetsGroupMatchData.Id, racingBetsGroupMatchData);
				if (legMatchList == null || legMatchList.Count <= 0)
				{
					Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.LRC, "RacingBetsSeasonData初始化 无效legMatchList", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					foreach (RacingBetsLegMatchData racingBetsLegMatchData in legMatchList)
					{
						this.LegMatchMap.Add(racingBetsLegMatchData.Id, racingBetsLegMatchData);
						this.LegMatchList.Add(racingBetsLegMatchData);
					}
				}
			}
			this.UpdateGroupMatchDangoSource();
			this.LegMatchList.Sort(delegate(RacingBetsLegMatchData a, RacingBetsLegMatchData b)
			{
				if (a.BetsStartTime >= b.BetsStartTime)
				{
					return (a.BetsStartTime > b.BetsStartTime) ? 1 : 0;
				}
				return -1;
			});
		}

		// Token: 0x06036182 RID: 221570 RVA: 0x00D9F048 File Offset: 0x00D9D248
		private void UpdateGroupMatchDangoSource()
		{
			foreach (RacingBetsGroupMatchData racingBetsGroupMatchData in this.GroupMatchMap.Values)
			{
				int advancedNextGroupMatchId = racingBetsGroupMatchData.AdvancedNextGroupMatchId;
				if (advancedNextGroupMatchId != 0)
				{
					RacingBetsGroupMatchData groupMatchData = this.GetGroupMatchData(advancedNextGroupMatchId);
					if (groupMatchData != null)
					{
						groupMatchData.PushSourceAdvancedGroupMatchId(racingBetsGroupMatchData.Id);
					}
				}
				int loserNextGroupMatchId = racingBetsGroupMatchData.LoserNextGroupMatchId;
				if (loserNextGroupMatchId != 0)
				{
					RacingBetsGroupMatchData groupMatchData2 = this.GetGroupMatchData(loserNextGroupMatchId);
					if (groupMatchData2 != null)
					{
						groupMatchData2.PushSourceLossGroupMatchId(racingBetsGroupMatchData.Id);
					}
				}
			}
		}

		// Token: 0x06036183 RID: 221571 RVA: 0x00D9F0E0 File Offset: 0x00D9D2E0
		private void RefreshMatchData(List<RacingBetsGroupMatchesInfo> matchInfos)
		{
			if (matchInfos == null || matchInfos.Count <= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.RacingBets, ELogAuthor.LRC, "RacingBetsSeasonData刷新 无效matchInfos", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (RacingBetsGroupMatchesInfo racingBetsGroupMatchesInfo in matchInfos)
			{
				this.GetGroupMatchData(racingBetsGroupMatchesInfo.GroupMatchId).Refresh(racingBetsGroupMatchesInfo);
				foreach (RacingBetsLegMatchesInfo racingBetsLegMatchesInfo in racingBetsGroupMatchesInfo.LegMatchesInfo)
				{
					this.GetLegMatchData(racingBetsLegMatchesInfo.Id).Refresh(racingBetsLegMatchesInfo);
				}
			}
		}

		// Token: 0x06036184 RID: 221572 RVA: 0x00D9F1B0 File Offset: 0x00D9D3B0
		public unsafe void RefreshPlayerData(RacingBetPlayerInfo playerInfo)
		{
			this.BetItemData = new TItem(new InventoryDefine.GetItemData(this.SeasonConfig.Id, 0), playerInfo.CurCash);
			this.AccumulateBetsCashCount = playerInfo.TotalCash;
			this.HitNum = playerInfo.HitNum;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsSeasonData刷新玩家数据";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AccumulateBetsCashCount", this.AccumulateBetsCashCount);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HitNum", this.HitNum);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.RefreshBetsInfo(new List<RacingBetsGearInfo>(playerInfo.GearInfo));
		}

		// Token: 0x06036185 RID: 221573 RVA: 0x00D9F274 File Offset: 0x00D9D474
		private void RefreshBetsInfo(List<RacingBetsGearInfo> betsInfo)
		{
			foreach (RacingBetsGearInfo racingBetsGearInfo in betsInfo)
			{
				this.GetLegMatchData(racingBetsGearInfo.LegMatchesId).RefreshBetInfo(racingBetsGearInfo);
			}
		}

		// Token: 0x06036186 RID: 221574 RVA: 0x00D9F2D0 File Offset: 0x00D9D4D0
		private void InitRewardData(List<ConditionTaskData> taskDataList)
		{
			this.RewardDataMap.Clear();
			this.RewardGroupDataMap.Clear();
			foreach (ConditionTaskData conditionTaskData in taskDataList)
			{
				RacingBetsRewardData racingBetsRewardData = new RacingBetsRewardData(conditionTaskData.Id);
				racingBetsRewardData.Refresh(conditionTaskData);
				this.RewardDataMap.Add(conditionTaskData.Id, racingBetsRewardData);
				this.GetGroupRewardData(racingBetsRewardData.GetRewardType()).AddRewardData(racingBetsRewardData);
			}
		}

		// Token: 0x06036187 RID: 221575 RVA: 0x00D9F364 File Offset: 0x00D9D564
		public void RefreshRewardData(List<ConditionTaskData> taskDataList)
		{
			foreach (ConditionTaskData conditionTaskData in taskDataList)
			{
				this.GetRewardData(conditionTaskData.Id).Refresh(conditionTaskData);
			}
		}

		// Token: 0x06036188 RID: 221576 RVA: 0x00D9F3C0 File Offset: 0x00D9D5C0
		private void InitRankUpdateTime(RepeatedField<long> rankTimeList)
		{
			int count = rankTimeList.Count;
			this.RankListUpdateTime = new List<int>(count);
			for (int i = 0; i < count; i++)
			{
				this.RankListUpdateTime.Add((int)Singleton<MathUtils>.Instance.LongToNumber(rankTimeList[i]));
			}
		}

		// Token: 0x06036189 RID: 221577 RVA: 0x00D9F409 File Offset: 0x00D9D609
		private void InitCloseSettleLegMatchIdList(List<int> closeSettleLegMatchIdList)
		{
			this.CloseSettleLegMatchIdList = closeSettleLegMatchIdList;
		}

		// Token: 0x0603618A RID: 221578 RVA: 0x00D9F412 File Offset: 0x00D9D612
		public void AddCloseSettleLegMatchId(int legMatchId)
		{
			if (this.CloseSettleLegMatchIdList.Contains(legMatchId))
			{
				return;
			}
			this.CloseSettleLegMatchIdList.Add(legMatchId);
		}

		// Token: 0x0603618B RID: 221579 RVA: 0x00D9F42F File Offset: 0x00D9D62F
		public TItem GetBetItemData()
		{
			return this.BetItemData;
		}

		// Token: 0x0603618C RID: 221580 RVA: 0x00D9F437 File Offset: 0x00D9D637
		public RacingBetsSeason GetSeasonConfig()
		{
			return this.SeasonConfig;
		}

		// Token: 0x0603618D RID: 221581 RVA: 0x00D9F43F File Offset: 0x00D9D63F
		public int GetTotalBetCount()
		{
			return this.AccumulateBetsCashCount;
		}

		// Token: 0x0603618E RID: 221582 RVA: 0x00D9F448 File Offset: 0x00D9D648
		[NullableContext(2)]
		public RacingBetsGroupMatchData GetGroupMatchData(int matchId)
		{
			RacingBetsGroupMatchData result;
			if (!this.GroupMatchMap.TryGetValue(matchId, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RacingBets;
				ELogAuthor author = ELogAuthor.BB;
				string message = "RacingBetsSeasonData 无效matchId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("matchId", matchId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return result;
		}

		// Token: 0x0603618F RID: 221583 RVA: 0x00D9F498 File Offset: 0x00D9D698
		[NullableContext(2)]
		public RacingBetsLegMatchData GetLegMatchData(int legMatchId)
		{
			RacingBetsLegMatchData result;
			if (!this.LegMatchMap.TryGetValue(legMatchId, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RacingBets;
				ELogAuthor author = ELogAuthor.BB;
				string message = "RacingBetsSeasonData 无效legMatchId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("legMatchId", legMatchId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return result;
		}

		// Token: 0x06036190 RID: 221584 RVA: 0x00D9F4E8 File Offset: 0x00D9D6E8
		[NullableContext(2)]
		public RacingBetsLegMatchData GetCurLegMatchData()
		{
			int curLegMatchDataIndex = this.GetCurLegMatchDataIndex();
			return this.GetLegMatchDataByIndex(curLegMatchDataIndex);
		}

		// Token: 0x06036191 RID: 221585 RVA: 0x00D9F504 File Offset: 0x00D9D704
		public int GetCurLegMatchDataIndex()
		{
			for (int i = this.LegMatchList.Count - 1; i >= 0; i--)
			{
				ERacingBetsLegMatchState legMatchState = this.LegMatchList[i].GetLegMatchState();
				if (legMatchState != ERacingBetsLegMatchState.NotOpen && legMatchState != ERacingBetsLegMatchState.EndOfMatch && legMatchState != ERacingBetsLegMatchState.End)
				{
					return i;
				}
			}
			return this.LegMatchList.Count - 1;
		}

		// Token: 0x06036192 RID: 221586 RVA: 0x00D9F555 File Offset: 0x00D9D755
		[NullableContext(2)]
		public RacingBetsLegMatchData GetLegMatchDataByIndex(int index)
		{
			if (index < 0 || index > this.LegMatchList.Count)
			{
				return null;
			}
			return this.LegMatchList[index];
		}

		// Token: 0x06036193 RID: 221587 RVA: 0x00D9F578 File Offset: 0x00D9D778
		[NullableContext(0)]
		public ValueTuple<int, int> GetCurLegMatchRankOpenTime()
		{
			int curLegMatchDataIndex = this.GetCurLegMatchDataIndex();
			if (curLegMatchDataIndex >= this.RankListUpdateTime.Count)
			{
				return new ValueTuple<int, int>(0, 0);
			}
			int item = this.RankListUpdateTime[curLegMatchDataIndex];
			int item2 = (curLegMatchDataIndex + 1 < this.RankListUpdateTime.Count) ? this.RankListUpdateTime[curLegMatchDataIndex + 1] : 0;
			return new ValueTuple<int, int>(item, item2);
		}

		// Token: 0x06036194 RID: 221588 RVA: 0x00D9F5D8 File Offset: 0x00D9D7D8
		public int GetNextRankUpdateTime()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			foreach (int num in this.RankListUpdateTime)
			{
				if (serverTime < (double)num)
				{
					return num;
				}
			}
			return -1;
		}

		// Token: 0x06036195 RID: 221589 RVA: 0x00D9F63C File Offset: 0x00D9D83C
		public bool CheckRankOpen()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (this.RankListUpdateTime.Count <= 0)
			{
				return false;
			}
			int num = this.RankListUpdateTime[0];
			return serverTime >= (double)num;
		}

		// Token: 0x06036196 RID: 221590 RVA: 0x00D9F67C File Offset: 0x00D9D87C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RacingBetsLegMatchData> GetReverseLegMatchList()
		{
			if (this.LegMatchList == null || this.LegMatchList.Count <= 0)
			{
				return null;
			}
			List<RacingBetsLegMatchData> list = new List<RacingBetsLegMatchData>();
			for (int i = this.LegMatchList.Count - 1; i >= 0; i--)
			{
				list.Add(this.LegMatchList[i]);
			}
			return list;
		}

		// Token: 0x06036197 RID: 221591 RVA: 0x00D9F6D4 File Offset: 0x00D9D8D4
		public bool IsFinalLegMatch(int legMatchId)
		{
			RacingBetsLegMatchData legMatchData = this.GetLegMatchData(legMatchId);
			if (legMatchData == null)
			{
				return false;
			}
			int count = this.LegMatchList.Count;
			for (int i = 0; i < count; i++)
			{
				if (legMatchData == this.LegMatchList[i])
				{
					return i == count - 1;
				}
			}
			return false;
		}

		// Token: 0x06036198 RID: 221592 RVA: 0x00D9F720 File Offset: 0x00D9D920
		public int GetNextLegMatchIndex(int legMatchId)
		{
			for (int i = 0; i < this.LegMatchList.Count; i++)
			{
				if (this.LegMatchList[i].Id == legMatchId)
				{
					return i + 1;
				}
			}
			return -1;
		}

		// Token: 0x06036199 RID: 221593 RVA: 0x00D9F75C File Offset: 0x00D9D95C
		[NullableContext(2)]
		public RacingBetsLegMatchData GetNextLegMatchData(int legMatchId)
		{
			int nextLegMatchIndex = this.GetNextLegMatchIndex(legMatchId);
			return this.GetLegMatchDataByIndex(nextLegMatchIndex);
		}

		// Token: 0x0603619A RID: 221594 RVA: 0x00D9F778 File Offset: 0x00D9D978
		[NullableContext(2)]
		public RacingBetsLegMatchData GetEndOfMatchLegMatchData()
		{
			foreach (RacingBetsLegMatchData racingBetsLegMatchData in this.LegMatchList)
			{
				if (racingBetsLegMatchData.GetLegMatchState() == ERacingBetsLegMatchState.EndOfMatch)
				{
					return racingBetsLegMatchData;
				}
			}
			return null;
		}

		// Token: 0x0603619B RID: 221595 RVA: 0x00D9F7D4 File Offset: 0x00D9D9D4
		[NullableContext(2)]
		public RacingBetsRewardData GetRewardData(int rewardId)
		{
			RacingBetsRewardData result;
			if (!this.RewardDataMap.TryGetValue(rewardId, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RacingBets;
				ELogAuthor author = ELogAuthor.BB;
				string message = "RacingBetsSeasonData 无效rewardId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rewardId", rewardId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return result;
		}

		// Token: 0x0603619C RID: 221596 RVA: 0x00D9F824 File Offset: 0x00D9DA24
		public RacingBetsGroupRewardData GetGroupRewardData(ERacingBetsRewardType rewardType)
		{
			RacingBetsGroupRewardData racingBetsGroupRewardData;
			if (!this.RewardGroupDataMap.TryGetValue(rewardType, out racingBetsGroupRewardData))
			{
				racingBetsGroupRewardData = new RacingBetsGroupRewardData((int)rewardType);
				this.RewardGroupDataMap.Add(rewardType, racingBetsGroupRewardData);
				return racingBetsGroupRewardData;
			}
			return racingBetsGroupRewardData;
		}

		// Token: 0x0603619D RID: 221597 RVA: 0x00D9F858 File Offset: 0x00D9DA58
		public int GetHitNum()
		{
			return this.HitNum;
		}

		// Token: 0x0603619E RID: 221598 RVA: 0x00D9F860 File Offset: 0x00D9DA60
		public int GetCurrencyItemId()
		{
			return this.SeasonConfig.MoneyId;
		}

		// Token: 0x0603619F RID: 221599 RVA: 0x00D9F86D File Offset: 0x00D9DA6D
		public int GetCurrencyCount()
		{
			return ModelBase<InventoryModel>.Instance.GetCommonItemCount(this.SeasonConfig.MoneyId, 0);
		}

		// Token: 0x060361A0 RID: 221600 RVA: 0x00D9F885 File Offset: 0x00D9DA85
		public int GetBetCostCount(RacingBettingGear gearConfig)
		{
			return (int)Math.Ceiling((double)(this.GetCurrencyCount() * gearConfig.Odds) / 100.0);
		}

		// Token: 0x060361A1 RID: 221601 RVA: 0x00D9F8A6 File Offset: 0x00D9DAA6
		public bool GetActivityTipNeedShowState()
		{
			return this.CheckIfInOpenTime() && this.CheckIfInShowTime() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, 0, 0) == 0;
		}

		// Token: 0x060361A2 RID: 221602 RVA: 0x00D9F8D1 File Offset: 0x00D9DAD1
		public bool CheckLegMatchIsCloseSettle(int legMatchId)
		{
			return this.CloseSettleLegMatchIdList.Contains(legMatchId);
		}

		// Token: 0x060361A3 RID: 221603 RVA: 0x00D9F8E0 File Offset: 0x00D9DAE0
		[NullableContext(2)]
		public RacingBetsLegMatchData GetLegMatchDataForMatchStateText()
		{
			RacingBetsLegMatchData curLegMatchData = this.GetCurLegMatchData();
			if (curLegMatchData == null)
			{
				return null;
			}
			ERacingBetsLegMatchState legMatchState = curLegMatchData.GetLegMatchState();
			if (this.IsFinalLegMatch(curLegMatchData.Id) && legMatchState == ERacingBetsLegMatchState.EndOfMatch)
			{
				return curLegMatchData;
			}
			RacingBetsLegMatchData endOfMatchLegMatchData = this.GetEndOfMatchLegMatchData();
			RacingBetsLegMatchData racingBetsLegMatchData = (legMatchState == ERacingBetsLegMatchState.BettingPeriod) ? curLegMatchData : null;
			if (endOfMatchLegMatchData == null || racingBetsLegMatchData == null || endOfMatchLegMatchData.Id == racingBetsLegMatchData.Id)
			{
				return curLegMatchData;
			}
			if (this.CheckLegMatchIsCloseSettle(endOfMatchLegMatchData.Id))
			{
				return racingBetsLegMatchData;
			}
			return endOfMatchLegMatchData;
		}

		// Token: 0x060361A4 RID: 221604 RVA: 0x00D9F94C File Offset: 0x00D9DB4C
		public string GetMatchStateDisplayText()
		{
			RacingBetsLegMatchData legMatchDataForMatchStateText = this.GetLegMatchDataForMatchStateText();
			if (legMatchDataForMatchStateText == null)
			{
				return "";
			}
			return this.GetMatchStateDisplayTextForLeg(legMatchDataForMatchStateText);
		}

		// Token: 0x060361A5 RID: 221605 RVA: 0x00D9F970 File Offset: 0x00D9DB70
		public static string GetMatchStateDisplayTextForEntranceActivityId(int activityId)
		{
			RacingBetsSeasonData racingBetsSeasonData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as RacingBetsSeasonData;
			if (racingBetsSeasonData != null)
			{
				return racingBetsSeasonData.GetMatchStateDisplayText();
			}
			RacingBetsSeasonData racingBetsSeasonData2 = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
			return ((racingBetsSeasonData2 != null) ? racingBetsSeasonData2.GetMatchStateDisplayText() : null) ?? "";
		}

		// Token: 0x060361A6 RID: 221606 RVA: 0x00D9F9B8 File Offset: 0x00D9DBB8
		public string GetMatchStateDisplayTextForLeg(RacingBetsLegMatchData legMatchData)
		{
			ERacingBetsLegMatchState legMatchState = legMatchData.GetLegMatchState();
			bool isFinalMatch = this.IsFinalLegMatch(legMatchData.Id);
			string matchStateTimeTextKey = RacingBetsSeasonData.GetMatchStateTimeTextKey(legMatchState, isFinalMatch);
			if (string.IsNullOrEmpty(matchStateTimeTextKey))
			{
				return "";
			}
			double legRemindTime = legMatchData.GetLegRemindTime();
			if ((legMatchState != ERacingBetsLegMatchState.BettingPeriod && legMatchState != ERacingBetsLegMatchState.EndOfBetting) || legRemindTime <= 0.0)
			{
				return ConfigBase<TextConfig>.Instance.GetMultiTextByKey(matchStateTimeTextKey) ?? "";
			}
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(matchStateTimeTextKey);
			if (multiTextByKey == null)
			{
				return "";
			}
			string text = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(legRemindTime).CountDownText ?? "";
			return StringUtils.Format(multiTextByKey, new string[]
			{
				text
			});
		}

		// Token: 0x060361A7 RID: 221607 RVA: 0x00D9FA68 File Offset: 0x00D9DC68
		private static string GetMatchStateTimeTextKey(ERacingBetsLegMatchState state, bool isFinalMatch)
		{
			if (state == ERacingBetsLegMatchState.BettingPeriod)
			{
				return "Dango_ActivityPage_StatusTime_Bet";
			}
			if (state == ERacingBetsLegMatchState.EndOfBetting)
			{
				return "Dango_ActivityPage_StatusTime_Wait";
			}
			if (state == ERacingBetsLegMatchState.MatchPeriod)
			{
				return "Dango_ActivityPage_StatusTime_Race";
			}
			if (state != ERacingBetsLegMatchState.EndOfMatch)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RacingBets;
				ELogAuthor author = ELogAuthor.LRC;
				string message = "当前比赛处于notOpen|end状态";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return "";
			}
			if (!isFinalMatch)
			{
				return "Dango_ActivityPage_StatusTime_RaceEnd";
			}
			return "Dango_ActivityPage_StatusTime_FinalRaceEnd";
		}

		// Token: 0x0401F13B RID: 127291
		private const int OPEN_TIP_KEY = 1;

		// Token: 0x0401F13C RID: 127292
		private int AccumulateBetsCashCount;

		// Token: 0x0401F13D RID: 127293
		private TItem BetItemData;

		// Token: 0x0401F13E RID: 127294
		private RacingBetsSeason SeasonConfig;

		// Token: 0x0401F13F RID: 127295
		private int HitNum;

		// Token: 0x0401F140 RID: 127296
		private readonly Dictionary<int, RacingBetsGroupMatchData> GroupMatchMap = new Dictionary<int, RacingBetsGroupMatchData>();

		// Token: 0x0401F141 RID: 127297
		private readonly Dictionary<int, RacingBetsLegMatchData> LegMatchMap = new Dictionary<int, RacingBetsLegMatchData>();

		// Token: 0x0401F142 RID: 127298
		private List<RacingBetsLegMatchData> LegMatchList = new List<RacingBetsLegMatchData>();

		// Token: 0x0401F143 RID: 127299
		private readonly Dictionary<ERacingBetsRewardType, RacingBetsGroupRewardData> RewardGroupDataMap = new Dictionary<ERacingBetsRewardType, RacingBetsGroupRewardData>();

		// Token: 0x0401F144 RID: 127300
		private readonly Dictionary<int, RacingBetsRewardData> RewardDataMap = new Dictionary<int, RacingBetsRewardData>();

		// Token: 0x0401F145 RID: 127301
		private List<int> RankListUpdateTime = new List<int>();

		// Token: 0x0401F146 RID: 127302
		private List<int> CloseSettleLegMatchIdList = new List<int>();

		// Token: 0x0401F147 RID: 127303
		private bool IsInit;
	}
}
