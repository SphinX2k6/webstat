using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200636F RID: 25455
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedProtocolContext : ActivityBaseData
	{
		// Token: 0x0603FED3 RID: 261843 RVA: 0x010660E7 File Offset: 0x010642E7
		public SolarSpeedProtocolContext(SolarSpeedModel model)
		{
			this.AttachedModel = model;
		}

		// Token: 0x0603FED4 RID: 261844 RVA: 0x01066117 File Offset: 0x01064317
		public void Dispose()
		{
			this.LevelMsgCache.Clear();
			this.TaskMsgCache.Clear();
		}

		// Token: 0x0603FED5 RID: 261845 RVA: 0x01066130 File Offset: 0x01064330
		protected override void PhraseEx(ActivityData data)
		{
			TeamParkourLevelActivityInfo teamParkourLevelActivityInfo = data.TeamParkourLevelActivityInfo;
			if (teamParkourLevelActivityInfo != null)
			{
				this.ParseActivityInfo(teamParkourLevelActivityInfo);
			}
		}

		// Token: 0x0603FED6 RID: 261846 RVA: 0x0106614E File Offset: 0x0106434E
		public override bool GetExDataRedPointShowState()
		{
			return this.AttachedModel.HasRewardRedDot || this.AttachedModel.HasLevelRedDot;
		}

		// Token: 0x0603FED7 RID: 261847 RVA: 0x0106616C File Offset: 0x0106436C
		private void ParseActivityInfo(TeamParkourLevelActivityInfo data)
		{
			this.LevelMsgCache.Clear();
			this.TaskMsgCache.Clear();
			foreach (TeamParkourLevelPlayInfo teamParkourLevelPlayInfo in data.TeamParkourLevelPlayInfos)
			{
				this.LevelMsgCache[teamParkourLevelPlayInfo.LevelId] = teamParkourLevelPlayInfo;
			}
			if (data.ActivityTaskDatas != null)
			{
				foreach (ActivityTask activityTask in data.ActivityTaskDatas.ActivityTasks)
				{
					this.TaskMsgCache[activityTask.Id] = activityTask;
				}
			}
		}

		// Token: 0x0603FED8 RID: 261848 RVA: 0x01066230 File Offset: 0x01064430
		public void ParseTeamParkourTaskNotify(TeamParkourTaskNotify msg)
		{
			ActivityTask activityTask = msg.ActivityTask;
			if (activityTask == null)
			{
				return;
			}
			this.TaskMsgCache[activityTask.Id] = activityTask;
		}

		// Token: 0x0603FED9 RID: 261849 RVA: 0x0106625C File Offset: 0x0106445C
		public void ParseTeamParkourSettleNotify(TeamParkourSettleNotify msg)
		{
			this.ResetTeamParkourSettleCache();
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			foreach (PlayerSettleInfo playerSettleInfo in msg.PlayerSettleInfos)
			{
				this.PlayerSettleMsgCache[playerSettleInfo.PlayerId] = playerSettleInfo;
				int? num = id;
				int playerId = playerSettleInfo.PlayerId;
				if (num.GetValueOrDefault() == playerId & num != null)
				{
					this.CurrentRankPointsCache = playerSettleInfo.RankPoints;
					this.CurrentDistancePointsCache = playerSettleInfo.DistancePoints;
					TeamParkourLevelPlayInfo teamParkourLevelPlayInfo;
					if (this.LevelMsgCache.TryGetValue(msg.LevelId, out teamParkourLevelPlayInfo))
					{
						if (teamParkourLevelPlayInfo.Ranking == 0 || playerSettleInfo.Ranking < teamParkourLevelPlayInfo.Ranking)
						{
							teamParkourLevelPlayInfo.Ranking = playerSettleInfo.Ranking;
						}
						int num2 = playerSettleInfo.RankPoints + playerSettleInfo.DistancePoints;
						if (num2 > teamParkourLevelPlayInfo.Score)
						{
							teamParkourLevelPlayInfo.Score = num2;
						}
						if (teamParkourLevelPlayInfo.TimeCost == 0)
						{
							teamParkourLevelPlayInfo.TimeCost = playerSettleInfo.ConsumeTime;
						}
						else if (playerSettleInfo.ConsumeTime != 0 && playerSettleInfo.ConsumeTime < teamParkourLevelPlayInfo.TimeCost)
						{
							teamParkourLevelPlayInfo.TimeCost = playerSettleInfo.ConsumeTime;
						}
					}
				}
			}
		}

		// Token: 0x0603FEDA RID: 261850 RVA: 0x010663B0 File Offset: 0x010645B0
		public void ResetTeamParkourSettleCache()
		{
			this.CurrentRankPointsCache = 0;
			this.CurrentDistancePointsCache = 0;
			this.PlayerSettleMsgCache.Clear();
		}

		// Token: 0x0603FEDB RID: 261851 RVA: 0x010663CC File Offset: 0x010645CC
		public int GetScoreById(int id)
		{
			TeamParkourLevelPlayInfo teamParkourLevelPlayInfo;
			if (!this.LevelMsgCache.TryGetValue(id, out teamParkourLevelPlayInfo))
			{
				return 0;
			}
			return teamParkourLevelPlayInfo.Score;
		}

		// Token: 0x0603FEDC RID: 261852 RVA: 0x010663F4 File Offset: 0x010645F4
		public int GetRankingById(int id)
		{
			TeamParkourLevelPlayInfo teamParkourLevelPlayInfo;
			if (!this.LevelMsgCache.TryGetValue(id, out teamParkourLevelPlayInfo))
			{
				return 0;
			}
			return teamParkourLevelPlayInfo.Ranking;
		}

		// Token: 0x0603FEDD RID: 261853 RVA: 0x0106641C File Offset: 0x0106461C
		public int GetStartTime(int id)
		{
			TeamParkourLevelPlayInfo teamParkourLevelPlayInfo;
			if (!this.LevelMsgCache.TryGetValue(id, out teamParkourLevelPlayInfo))
			{
				return 0;
			}
			return teamParkourLevelPlayInfo.StartTime;
		}

		// Token: 0x0603FEDE RID: 261854 RVA: 0x01066444 File Offset: 0x01064644
		public int GetLapRecord(int id)
		{
			TeamParkourLevelPlayInfo teamParkourLevelPlayInfo;
			if (!this.LevelMsgCache.TryGetValue(id, out teamParkourLevelPlayInfo))
			{
				return 0;
			}
			return teamParkourLevelPlayInfo.TimeCost;
		}

		// Token: 0x0603FEDF RID: 261855 RVA: 0x0106646C File Offset: 0x0106466C
		public int GetCurrentProgressById(int id)
		{
			ActivityTask activityTask;
			if (!this.TaskMsgCache.TryGetValue(id, out activityTask))
			{
				return 0;
			}
			return activityTask.Current;
		}

		// Token: 0x0603FEE0 RID: 261856 RVA: 0x01066494 File Offset: 0x01064694
		public int GetCurrentProgressTargetById(int id)
		{
			ActivityTask activityTask;
			if (!this.TaskMsgCache.TryGetValue(id, out activityTask))
			{
				return 0;
			}
			return activityTask.Target;
		}

		// Token: 0x0603FEE1 RID: 261857 RVA: 0x010664BC File Offset: 0x010646BC
		public ActivityTaskState? GetTaskStateById(int id)
		{
			ActivityTask activityTask;
			if (!this.TaskMsgCache.TryGetValue(id, out activityTask))
			{
				return null;
			}
			return new ActivityTaskState?(activityTask.Status);
		}

		// Token: 0x0603FEE2 RID: 261858 RVA: 0x010664F0 File Offset: 0x010646F0
		public void SetTaskStateRewardedById(int id)
		{
			ActivityTask activityTask;
			if (this.TaskMsgCache.TryGetValue(id, out activityTask))
			{
				activityTask.Status = ActivityTaskState.ActivityTaskTaken;
			}
		}

		// Token: 0x04023E89 RID: 147081
		private readonly SolarSpeedModel AttachedModel;

		// Token: 0x04023E8A RID: 147082
		private readonly Dictionary<int, TeamParkourLevelPlayInfo> LevelMsgCache = new Dictionary<int, TeamParkourLevelPlayInfo>();

		// Token: 0x04023E8B RID: 147083
		private readonly Dictionary<int, ActivityTask> TaskMsgCache = new Dictionary<int, ActivityTask>();

		// Token: 0x04023E8C RID: 147084
		public int CurrentRankPointsCache;

		// Token: 0x04023E8D RID: 147085
		public int CurrentDistancePointsCache;

		// Token: 0x04023E8E RID: 147086
		public readonly Dictionary<int, PlayerSettleInfo> PlayerSettleMsgCache = new Dictionary<int, PlayerSettleInfo>();
	}
}
