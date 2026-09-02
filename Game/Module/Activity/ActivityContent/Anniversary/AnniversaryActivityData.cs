using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069D2 RID: 27090
	[NullableContext(1)]
	[Nullable(0)]
	public class AnniversaryActivityData : ActivityBaseData
	{
		// Token: 0x0604328C RID: 275084 RVA: 0x01140CB4 File Offset: 0x0113EEB4
		protected override void PhraseEx(ActivityData data)
		{
			if (data != null && data.ThemeCelebration != null)
			{
				this.PersonalRewardIds = new List<int>();
				foreach (int item in data.ThemeCelebration.PersonalRewardIds)
				{
					this.PersonalRewardIds.Add(item);
				}
				this.WorldRewardIds = new List<int>();
				foreach (int item2 in data.ThemeCelebration.WorldRewardIds)
				{
					this.WorldRewardIds.Add(item2);
				}
			}
			this.InitSubActivityData();
			RepeatedField<SubActivityBeginTime> repeatedField;
			if (data == null)
			{
				repeatedField = null;
			}
			else
			{
				ThemeCelebration themeCelebration = data.ThemeCelebration;
				repeatedField = ((themeCelebration != null) ? themeCelebration.SubActivityTimes : null);
			}
			RepeatedField<SubActivityBeginTime> repeatedField2 = repeatedField;
			List<SubActivityBeginTime> list = new List<SubActivityBeginTime>();
			if (repeatedField2 != null)
			{
				foreach (SubActivityBeginTime item3 in repeatedField2)
				{
					list.Add(item3);
				}
			}
			this.InitSubActivityUnlockTimeMap(list);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			}, 20f, null, null, true, 1f);
		}

		// Token: 0x0604328D RID: 275085 RVA: 0x01140E0C File Offset: 0x0113F00C
		private void InitSubActivityUnlockTimeMap(IReadOnlyList<SubActivityBeginTime> times)
		{
			if (times == null || times.Count == 0)
			{
				return;
			}
			foreach (SubActivityBeginTime subActivityBeginTime in times)
			{
				EAnniversarySubId id = (EAnniversarySubId)subActivityBeginTime.Id;
				AnniversarySubActivityDataBase targetSubActivityData = this.GetTargetSubActivityData(id);
				if (targetSubActivityData != null)
				{
					long unlockTime = Singleton<MathUtils>.Instance.LongToBigInt(subActivityBeginTime.BeginTime);
					targetSubActivityData.SetUnlockTime(unlockTime);
				}
			}
		}

		// Token: 0x0604328E RID: 275086 RVA: 0x01140E88 File Offset: 0x0113F088
		private void InitSubActivityData()
		{
			this.SubActivityDataMap.Clear();
			IReadOnlyList<AnniversaryEntrance> anniversaryEntranceAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetAnniversaryEntranceAll();
			if (anniversaryEntranceAll == null)
			{
				return;
			}
			foreach (AnniversaryEntrance anniversaryEntrance in anniversaryEntranceAll)
			{
				EAnniversarySubId id = (EAnniversarySubId)anniversaryEntrance.Id;
				AnniversarySubActivityDataBase anniversarySubActivityDataBase = null;
				switch (id)
				{
				case EAnniversarySubId.AnniversaryGift:
					anniversarySubActivityDataBase = new AnniversarySubActivityAnniversaryGift((int)id);
					break;
				case EAnniversarySubId.Pinball:
					anniversarySubActivityDataBase = new AnniversarySubActivityPinball((int)id);
					break;
				case EAnniversarySubId.WuWuPack:
					anniversarySubActivityDataBase = new AnniversarySubActivityWuWuPack((int)id);
					break;
				case EAnniversarySubId.DangoRun:
					anniversarySubActivityDataBase = new AnniversarySubActivityDangoRun((int)id);
					break;
				}
				if (anniversarySubActivityDataBase != null)
				{
					this.SubActivityDataMap[id] = anniversarySubActivityDataBase;
				}
			}
			this.RebuildRelativeActivityIds();
		}

		// Token: 0x0604328F RID: 275087 RVA: 0x01140F48 File Offset: 0x0113F148
		[NullableContext(2)]
		public AnniversarySubActivityDataBase GetTargetSubActivityData(EAnniversarySubId id)
		{
			AnniversarySubActivityDataBase result;
			if (this.SubActivityDataMap.TryGetValue(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06043290 RID: 275088 RVA: 0x01140F68 File Offset: 0x0113F168
		private void RebuildRelativeActivityIds()
		{
			this.RelativeActivityIds.Clear();
			foreach (AnniversarySubActivityDataBase anniversarySubActivityDataBase in this.SubActivityDataMap.Values)
			{
				int activityId = anniversarySubActivityDataBase.GetActivityId();
				if (activityId > 0)
				{
					this.RelativeActivityIds.Add(activityId);
				}
			}
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("AnniversaryRedDotRelativeActivityList");
			if (intArrayConfig != null)
			{
				foreach (int num in intArrayConfig)
				{
					if (num > 0)
					{
						this.RelativeActivityIds.Add(num);
					}
				}
			}
		}

		// Token: 0x06043291 RID: 275089 RVA: 0x0114102C File Offset: 0x0113F22C
		public bool IsRelativeActivityId(int activityId)
		{
			return this.RelativeActivityIds.Contains(activityId);
		}

		// Token: 0x06043292 RID: 275090 RVA: 0x0114103C File Offset: 0x0113F23C
		public void UpdatePersonalRewardIds(List<int> rewardIds)
		{
			foreach (int item in rewardIds)
			{
				if (!this.PersonalRewardIds.Contains(item))
				{
					this.PersonalRewardIds.Add(item);
				}
			}
		}

		// Token: 0x06043293 RID: 275091 RVA: 0x011410A0 File Offset: 0x0113F2A0
		public void UpdateWorldRewardIds(List<int> rewardIds)
		{
			foreach (int item in rewardIds)
			{
				if (!this.WorldRewardIds.Contains(item))
				{
					this.WorldRewardIds.Add(item);
				}
			}
		}

		// Token: 0x06043294 RID: 275092 RVA: 0x01141104 File Offset: 0x0113F304
		public List<int> GetWorldRewardIds()
		{
			return this.WorldRewardIds;
		}

		// Token: 0x06043295 RID: 275093 RVA: 0x0114110C File Offset: 0x0113F30C
		public List<int> GetPersonalRewardIds()
		{
			return this.PersonalRewardIds;
		}

		// Token: 0x06043296 RID: 275094 RVA: 0x01141114 File Offset: 0x0113F314
		public int GetPersonalCurProgress()
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(74, 0);
		}

		// Token: 0x06043297 RID: 275095 RVA: 0x01141124 File Offset: 0x0113F324
		public bool NeedPlayWorldProgressNumberTweenToday()
		{
			int num = (int)(Singleton<TimeUtil>.Instance.GetCurrentCrossDayStamp() / (double)Singleton<TimeUtil>.Instance.InverseMillisecond);
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 10, 0, 0) != num;
		}

		// Token: 0x06043298 RID: 275096 RVA: 0x01141164 File Offset: 0x0113F364
		public void MarkWorldProgressNumberTweenPlayedToday()
		{
			int value = (int)(Singleton<TimeUtil>.Instance.GetCurrentCrossDayStamp() / (double)Singleton<TimeUtil>.Instance.InverseMillisecond);
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 10, 0, 0, value);
		}

		// Token: 0x06043299 RID: 275097 RVA: 0x011411A0 File Offset: 0x0113F3A0
		public int GetWorldCurProgressIdForActivityDay(int realValidDay)
		{
			IReadOnlyList<WorldProgressCurve> worldProgressCurveAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveAll();
			if (worldProgressCurveAll == null || worldProgressCurveAll.Count == 0)
			{
				return 0;
			}
			int personalCurProgress = this.GetPersonalCurProgress();
			int result = 0;
			for (int i = worldProgressCurveAll.Count - 1; i >= 0; i--)
			{
				WorldProgressCurve worldProgressCurve = worldProgressCurveAll[i];
				if (worldProgressCurve.OpenDay <= realValidDay && personalCurProgress >= worldProgressCurve.PersonalScore)
				{
					result = worldProgressCurve.Id;
					break;
				}
			}
			return result;
		}

		// Token: 0x0604329A RID: 275098 RVA: 0x0114120C File Offset: 0x0113F40C
		public int GetWorldCurProgressId()
		{
			long beginOpenTime = base.BeginOpenTime;
			if (beginOpenTime <= 0L)
			{
				return 0;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime <= (double)beginOpenTime)
			{
				return 0;
			}
			int realValidDay = (int)Math.Floor((serverTime - (double)beginOpenTime) / (double)Singleton<TimeUtil>.Instance.OneDaySeconds);
			return this.GetWorldCurProgressIdForActivityDay(realValidDay);
		}

		// Token: 0x0604329B RID: 275099 RVA: 0x01141258 File Offset: 0x0113F458
		public bool IsPreviousProgressFull()
		{
			long beginOpenTime = base.BeginOpenTime;
			if (beginOpenTime <= 0L)
			{
				return false;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime <= (double)beginOpenTime)
			{
				return false;
			}
			IReadOnlyList<WorldProgressCurve> worldProgressCurveAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveAll();
			if (worldProgressCurveAll == null || worldProgressCurveAll.Count == 0)
			{
				return false;
			}
			int num = 0;
			foreach (WorldProgressCurve worldProgressCurve in worldProgressCurveAll)
			{
				if (worldProgressCurve.Percent > num)
				{
					num = worldProgressCurve.Percent;
				}
			}
			int num2 = (int)Math.Floor((serverTime - (double)beginOpenTime) / (double)Singleton<TimeUtil>.Instance.OneDaySeconds) - 1;
			if (num2 < 0)
			{
				return false;
			}
			int worldCurProgressIdForActivityDay = this.GetWorldCurProgressIdForActivityDay(num2);
			WorldProgressCurve? worldProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveById(worldCurProgressIdForActivityDay);
			return ((worldProgressCurveById != null) ? worldProgressCurveById.Value.Percent : 0) >= num;
		}

		// Token: 0x0604329C RID: 275100 RVA: 0x01141348 File Offset: 0x0113F548
		public bool IsCurrentProgressFull()
		{
			IReadOnlyList<WorldProgressCurve> worldProgressCurveAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveAll();
			if (worldProgressCurveAll == null || worldProgressCurveAll.Count == 0)
			{
				return false;
			}
			int num = 0;
			foreach (WorldProgressCurve worldProgressCurve in worldProgressCurveAll)
			{
				if (worldProgressCurve.Percent > num)
				{
					num = worldProgressCurve.Percent;
				}
			}
			int worldCurProgressId = this.GetWorldCurProgressId();
			WorldProgressCurve? worldProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveById(worldCurProgressId);
			return ((worldProgressCurveById != null) ? worldProgressCurveById.Value.Percent : 0) >= num;
		}

		// Token: 0x0604329D RID: 275101 RVA: 0x011413F0 File Offset: 0x0113F5F0
		[NullableContext(2)]
		public List<int> GetWorldCanReceiveRewardIds()
		{
			IReadOnlyList<WorldProgressCurve> worldProgressCurveHadReward = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveHadReward();
			List<int> list = new List<int>();
			int worldCurProgressId = this.GetWorldCurProgressId();
			if (worldProgressCurveHadReward != null)
			{
				foreach (WorldProgressCurve worldProgressCurve in worldProgressCurveHadReward)
				{
					if (worldCurProgressId >= worldProgressCurve.Id && !this.WorldRewardIds.Contains(worldProgressCurve.Id))
					{
						list.Add(worldProgressCurve.Id);
					}
				}
			}
			return list;
		}

		// Token: 0x0604329E RID: 275102 RVA: 0x0114147C File Offset: 0x0113F67C
		[NullableContext(2)]
		public List<int> GetPersonalCanReceiveRewardIds()
		{
			IReadOnlyList<PersonProgressCurve> personProgressCurveAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetPersonProgressCurveAll();
			List<int> list = new List<int>();
			if (personProgressCurveAll != null)
			{
				foreach (PersonProgressCurve personProgressCurve in personProgressCurveAll)
				{
					if (this.TargetPersonalCanReceive(personProgressCurve.Id))
					{
						list.Add(personProgressCurve.Id);
					}
				}
			}
			return list;
		}

		// Token: 0x0604329F RID: 275103 RVA: 0x011414F0 File Offset: 0x0113F6F0
		public bool TargetPersonalCanReceive(int cfgId)
		{
			PersonProgressCurve? personProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetPersonProgressCurveById(cfgId);
			if (personProgressCurveById == null)
			{
				return false;
			}
			int personalCurProgress = this.GetPersonalCurProgress();
			return personProgressCurveById.Value.DropId > 0 && personalCurProgress >= personProgressCurveById.Value.Progress && !this.PersonalRewardIds.Contains(personProgressCurveById.Value.Id);
		}

		// Token: 0x060432A0 RID: 275104 RVA: 0x01141560 File Offset: 0x0113F760
		public override bool GetExDataRedPointShowState()
		{
			IReadOnlyList<WorldProgressCurve> worldProgressCurveHadReward = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveHadReward();
			int worldCurProgressId = this.GetWorldCurProgressId();
			if (worldProgressCurveHadReward != null)
			{
				foreach (WorldProgressCurve worldProgressCurve in worldProgressCurveHadReward)
				{
					if (worldCurProgressId >= worldProgressCurve.Id && !this.WorldRewardIds.Contains(worldProgressCurve.Id))
					{
						return true;
					}
				}
			}
			IReadOnlyList<PersonProgressCurve> personProgressCurveAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetPersonProgressCurveAll();
			if (personProgressCurveAll != null)
			{
				foreach (PersonProgressCurve personProgressCurve in personProgressCurveAll)
				{
					if (this.TargetPersonalCanReceive(personProgressCurve.Id))
					{
						return true;
					}
				}
			}
			foreach (int id in this.RelativeActivityIds)
			{
				ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(id);
				if (activityById != null && activityById.RedPointShowState)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060432A1 RID: 275105 RVA: 0x0114169C File Offset: 0x0113F89C
		protected override bool GetExDataFinishShowState()
		{
			if (this.SubActivityDataMap.Count == 0)
			{
				return false;
			}
			using (Dictionary<EAnniversarySubId, AnniversarySubActivityDataBase>.ValueCollection.Enumerator enumerator = this.SubActivityDataMap.Values.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ActivityBaseData activityData = enumerator.Current.GetActivityData();
					if (activityData != null && !activityData.FinishSinkState)
					{
						return false;
					}
					return true;
				}
			}
			return true;
		}

		// Token: 0x040256AE RID: 153262
		private readonly Dictionary<EAnniversarySubId, AnniversarySubActivityDataBase> SubActivityDataMap = new Dictionary<EAnniversarySubId, AnniversarySubActivityDataBase>();

		// Token: 0x040256AF RID: 153263
		private List<int> PersonalRewardIds = new List<int>();

		// Token: 0x040256B0 RID: 153264
		private List<int> WorldRewardIds = new List<int>();

		// Token: 0x040256B1 RID: 153265
		private readonly HashSet<int> RelativeActivityIds = new HashSet<int>();
	}
}
