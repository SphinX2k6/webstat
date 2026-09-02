using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip
{
	// Token: 0x020064C8 RID: 25800
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipData : ActivityBaseData
	{
		// Token: 0x06040A5B RID: 264795 RVA: 0x0109221C File Offset: 0x0109041C
		protected override void PhraseEx(ActivityData data)
		{
			RhythmActivityPb rhythmActivityPb = data.RhythmActivityPb;
			this.CurrentRole = ((rhythmActivityPb != null) ? rhythmActivityPb.RhythmRoleId : 0);
			RhythmActivityPb rhythmActivityPb2 = data.RhythmActivityPb;
			RepeatedField<RhythmShipPlanetPb> repeatedField = (rhythmActivityPb2 != null) ? rhythmActivityPb2.RhythmShipPlanetPb : null;
			if (repeatedField != null)
			{
				foreach (RhythmShipPlanetPb planetInfo in repeatedField)
				{
					this.InitPlanetInfo(planetInfo);
				}
			}
			IEnumerable<int> rhythmShipPlanetIdListByType = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetIdListByType(1, base.Id);
			List<int> rhythmShipPlanetIdListByType2 = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetIdListByType(3, base.Id);
			List<int> list = new List<int>(rhythmShipPlanetIdListByType);
			list.AddRange(rhythmShipPlanetIdListByType2);
			foreach (int planet in list)
			{
				foreach (int num in ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelIdListByPlanet(planet))
				{
					List<int> value = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelIdByLevelId(num) ?? new List<int>();
					ModelBase<RhythmShipModel>.Instance.LevelSubLevelInfoMap[num] = value;
				}
			}
			RhythmActivityPb rhythmActivityPb3 = data.RhythmActivityPb;
			RepeatedField<RhythmTaskPb> repeatedField2 = (rhythmActivityPb3 != null) ? rhythmActivityPb3.RhythmTask : null;
			if (repeatedField2 != null)
			{
				foreach (RhythmTaskPb rhythmTaskPb in repeatedField2)
				{
					if (rhythmTaskPb.TaskType == RhythmTaskTypePb.Resident)
					{
						foreach (ConditionTask conditionTask in rhythmTaskPb.Task)
						{
							this.TaskInfoMap[conditionTask.Id] = conditionTask;
						}
					}
					if (rhythmTaskPb.TaskType == RhythmTaskTypePb.Limit)
					{
						foreach (ConditionTask conditionTask2 in rhythmTaskPb.Task)
						{
							this.LimitTaskInfoMap[conditionTask2.Id] = conditionTask2;
						}
					}
				}
			}
			RhythmActivityPb rhythmActivityPb4 = data.RhythmActivityPb;
			this.RoleUnlockList = new List<int>(((rhythmActivityPb4 != null) ? rhythmActivityPb4.UnlockedRole : null) ?? new RepeatedField<int>());
			RhythmActivityPb rhythmActivityPb5 = data.RhythmActivityPb;
			this.RedDotInfo = (((rhythmActivityPb5 != null) ? rhythmActivityPb5.RedDot : null) ?? RhythmRedDotPb.Create());
			this.InitTaskTabList();
		}

		// Token: 0x06040A5C RID: 264796 RVA: 0x010924C4 File Offset: 0x010906C4
		private void InitPlanetInfo(RhythmShipPlanetPb planetInfo)
		{
			foreach (RhythmShipLevelPb rhythmShipLevelPb in planetInfo.RhythmShipLevelPb)
			{
				foreach (RhythmSubLevelPb rhythmSubLevelPb in rhythmShipLevelPb.RhythmSubLevelPb)
				{
					this.SubLevelInfoMap[rhythmSubLevelPb.SubLevelId] = rhythmSubLevelPb;
				}
			}
			this.PlanetOpenTime[planetInfo.PlanetId] = planetInfo.OpenTime;
		}

		// Token: 0x06040A5D RID: 264797 RVA: 0x01092568 File Offset: 0x01090768
		private void InitTaskTabList()
		{
			this.TaskTabList = new List<int>();
			foreach (int id in ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskIdByTypeAndActivityId(0, ModelBase<RhythmShipModel>.Instance.ActivityId))
			{
				RhythmTask? rhythmTask;
				int? num = (ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskById(id) != null) ? new int?(rhythmTask.GetValueOrDefault().TaskTab) : null;
				if (num != null && !this.TaskTabList.Contains(num.Value))
				{
					this.TaskTabList.Add(num.Value);
				}
			}
		}

		// Token: 0x06040A5E RID: 264798 RVA: 0x01092634 File Offset: 0x01090834
		public bool GetCanTaskGetReward(int type)
		{
			foreach (KeyValuePair<int, ConditionTask> keyValuePair in ((type == 0) ? this.TaskInfoMap : this.LimitTaskInfoMap))
			{
				if (keyValuePair.Value.Status == ConditionTaskState.ConditionTaskFinish)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06040A5F RID: 264799 RVA: 0x010926A4 File Offset: 0x010908A4
		public bool GetGotoRhythmShipBtnRedDotActive()
		{
			if (!base.IsUnLock())
			{
				return false;
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair in ModelBase<RhythmShipModel>.Instance.LevelSubLevelInfoMap)
			{
				int key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(key);
				if (ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(rhythmShipLevelById.Value.Planet).Value.Type != 2)
				{
					foreach (int subLevelId in value)
					{
						if (ModelBase<RhythmShipModel>.Instance.GetSubLevelRedDotActive(subLevelId))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06040A60 RID: 264800 RVA: 0x010927A0 File Offset: 0x010909A0
		public override bool GetExDataRedPointShowState()
		{
			return this.GetGotoRhythmShipBtnRedDotActive() || this.GetCanTaskGetReward(0) || this.GetCanTaskGetReward(1);
		}

		// Token: 0x06040A61 RID: 264801 RVA: 0x010927BC File Offset: 0x010909BC
		public int GetRecommendQuestId()
		{
			RhythmActivity? rhythmActivity;
			int? num = (ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipActivity(base.Id) != null) ? new int?(rhythmActivity.GetValueOrDefault().RecommendQuestId) : null;
			if (num == null || num.Value == 0)
			{
				return 0;
			}
			return num.Value;
		}

		// Token: 0x06040A62 RID: 264802 RVA: 0x01092820 File Offset: 0x01090A20
		public bool IsRecommendQuestFinish()
		{
			int recommendQuestId = this.GetRecommendQuestId();
			return recommendQuestId == 0 || ModelBase<QuestNewModel>.Instance.CheckQuestFinished(recommendQuestId);
		}

		// Token: 0x06040A63 RID: 264803 RVA: 0x01092844 File Offset: 0x01090A44
		public string GetRecommendQuestIdTips()
		{
			RhythmActivity? rhythmActivity;
			return ((ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipActivity(base.Id) != null) ? rhythmActivity.GetValueOrDefault().RecommendQuestTips : null) ?? "";
		}

		// Token: 0x06040A64 RID: 264804 RVA: 0x01092888 File Offset: 0x01090A88
		protected override bool GetExDataFinishShowState()
		{
			if (base.CheckIfInLimitTime())
			{
				foreach (KeyValuePair<int, ConditionTask> keyValuePair in this.LimitTaskInfoMap)
				{
					if (keyValuePair.Value.Status != ConditionTaskState.ConditionTaskTaken)
					{
						return false;
					}
				}
			}
			foreach (KeyValuePair<int, ConditionTask> keyValuePair2 in this.TaskInfoMap)
			{
				if (keyValuePair2.Value.Status != ConditionTaskState.ConditionTaskTaken)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0402432F RID: 148271
		public int CurrentRole;

		// Token: 0x04024330 RID: 148272
		public List<int> RoleUnlockList = new List<int>();

		// Token: 0x04024331 RID: 148273
		public Dictionary<int, ConditionTask> TaskInfoMap = new Dictionary<int, ConditionTask>();

		// Token: 0x04024332 RID: 148274
		public Dictionary<int, ConditionTask> LimitTaskInfoMap = new Dictionary<int, ConditionTask>();

		// Token: 0x04024333 RID: 148275
		public Dictionary<int, RhythmSubLevelPb> SubLevelInfoMap = new Dictionary<int, RhythmSubLevelPb>();

		// Token: 0x04024334 RID: 148276
		public Dictionary<int, long> PlanetOpenTime = new Dictionary<int, long>();

		// Token: 0x04024335 RID: 148277
		[Nullable(2)]
		public RhythmRedDotPb RedDotInfo;

		// Token: 0x04024336 RID: 148278
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RhythmPlayerRankingInfo> FriendLevelRatingInfoList;

		// Token: 0x04024337 RID: 148279
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RhythmPlayerRankingSubLevelInfo> SelfLevelRatingInfoList;

		// Token: 0x04024338 RID: 148280
		public List<int> TaskTabList = new List<int>();
	}
}
