using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Mowing
{
	// Token: 0x02006668 RID: 26216
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityMowingData : ActivityBaseData
	{
		// Token: 0x0604178D RID: 268173 RVA: 0x010CE1A8 File Offset: 0x010CC3A8
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private ValueTuple<string, int> GetButtonTextByRewardTextAndSort(int state)
		{
			string text = "";
			int item = 0;
			switch (state)
			{
			case 0:
				text = "PrefabTextItem_1443074454_Text";
				item = 2;
				break;
			case 1:
				text = "CollectActivity_state_CanRecive";
				item = 1;
				break;
			case 2:
				text = "CollectActivity_state_recived";
				item = 3;
				break;
			}
			string item2 = "";
			if (text != "")
			{
				item2 = (ConfigMultiTextLang.GetLocalTextNew(text, null) ?? "");
			}
			return new ValueTuple<string, int>(item2, item);
		}

		// Token: 0x0604178E RID: 268174 RVA: 0x010CE218 File Offset: 0x010CC418
		protected override void PhraseEx(ActivityData data)
		{
			if (data.HarvestActivity == null)
			{
				this.MowingPointRewards = new List<IActivityRewardData>();
				this.MowingLevelRewards = new List<IActivityRewardData>();
				return;
			}
			this.MowingPointRewards = new List<IActivityRewardData>();
			this.MowingLevelRewards = new List<IActivityRewardData>();
			this.MowingLevelRewardDict = new Dictionary<int, IActivityRewardData>();
			this.MowingPointRewardDict = new Dictionary<int, IActivityRewardData>();
			this.MowingLevelInfoDict = new Dictionary<int, HarvestLevelReward>();
			foreach (HarvestLevelReward harvestLevelReward in data.HarvestActivity.HarvestLevelRewards)
			{
				KillMonstersScores? config = ConfigKillMonstersScoresByInstanceID.GetConfig(harvestLevelReward.Id, true);
				if (config != null)
				{
					this.MowingLevelInfoDict[harvestLevelReward.Id] = harvestLevelReward;
					IActivityRewardData activityRewardData = this.CreateActivityRewardDataByLevel(harvestLevelReward, config.Value);
					this.MowingLevelRewardDict[harvestLevelReward.Id] = activityRewardData;
					this.MowingLevelRewards.Add(activityRewardData);
				}
			}
			foreach (HarvestPointReward harvestPointReward in data.HarvestActivity.HarvestPointRewards)
			{
				ScoreReward? config2 = ConfigScoreRewardById.GetConfig(harvestPointReward.Id, true);
				if (config2 != null)
				{
					IActivityRewardData activityRewardData2 = this.CreateActivityRewardDataByPoint(harvestPointReward, config2.Value);
					this.MowingPointRewards.Add(activityRewardData2);
					this.MowingPointRewardDict[harvestPointReward.Id] = activityRewardData2;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, base.Id);
		}

		// Token: 0x0604178F RID: 268175 RVA: 0x010CE3B0 File Offset: 0x010CC5B0
		private IActivityRewardData CreateActivityRewardDataByPoint(HarvestPointReward pointReward, ScoreReward pointConf)
		{
			ActivityMowingController controller = (ActivityMowingController)ActivityManager.GetActivityController(base.Type);
			string item = this.GetButtonTextByRewardTextAndSort((int)pointReward.State).Item1;
			return new ActivityRewardData
			{
				Id = new int?(pointReward.Id),
				NameText = ConfigMultiTextLang.GetLocalTextNew(pointConf.Desc, null),
				RewardList = this.GetRewardItems(pointConf.Reward).ToArray(),
				RewardButtonText = item,
				RewardState = (EActivityRewardState)pointReward.State,
				ClickFunction = delegate
				{
					controller.RequestGetPointReward(this.Id, pointReward.Id);
				}
			};
		}

		// Token: 0x06041790 RID: 268176 RVA: 0x010CE470 File Offset: 0x010CC670
		private IActivityRewardData CreateActivityRewardDataByLevel(HarvestLevelReward levelReward, KillMonstersScores levelConf)
		{
			ActivityMowingController controller = (ActivityMowingController)ActivityManager.GetActivityController(base.Type);
			string item = this.GetButtonTextByRewardTextAndSort((int)levelReward.State).Item1;
			return new ActivityRewardData
			{
				Id = new int?(levelReward.Id),
				NameText = ConfigMultiTextLang.GetLocalTextNew(levelConf.Desc, null),
				RewardList = this.GetRewardItems(levelConf.Reward).ToArray(),
				RewardState = (EActivityRewardState)levelReward.State,
				RewardButtonText = item,
				ClickFunction = delegate
				{
					controller.RequestGetLevelReward(this.Id, levelConf.InstanceID, levelReward.Id);
				}
			};
		}

		// Token: 0x06041791 RID: 268177 RVA: 0x010CE540 File Offset: 0x010CC740
		private void RefreshText(IActivityRewardData data, string descId)
		{
			string item = this.GetButtonTextByRewardTextAndSort((int)data.RewardState).Item1;
			data.NameText = ConfigMultiTextLang.GetLocalTextNew(descId, null);
			data.RewardButtonText = item;
		}

		// Token: 0x06041792 RID: 268178 RVA: 0x010CE573 File Offset: 0x010CC773
		public override bool GetExDataRedPointShowState()
		{
			return this.IsHaveRewardToGet() || this.IsNewInstanceOpen();
		}

		// Token: 0x06041793 RID: 268179 RVA: 0x010CE588 File Offset: 0x010CC788
		public bool IsHaveRewardToGet()
		{
			using (List<IActivityRewardData>.Enumerator enumerator = this.MowingPointRewards.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState == EActivityRewardState.Enable)
					{
						return true;
					}
				}
			}
			using (List<IActivityRewardData>.Enumerator enumerator = this.MowingLevelRewards.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState == EActivityRewardState.Enable)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041794 RID: 268180 RVA: 0x010CE628 File Offset: 0x010CC828
		public bool IsNewInstanceOpen()
		{
			if (!base.IsUnLock())
			{
				return false;
			}
			if (!base.GetPreGuideQuestFinishState())
			{
				return false;
			}
			foreach (KeyValuePair<int, HarvestLevelReward> keyValuePair in this.MowingLevelInfoDict)
			{
				HarvestLevelReward value = keyValuePair.Value;
				bool flag = (double)value.StartTime <= Singleton<TimeUtil>.Instance.GetServerTime();
				if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, value.Id, 0, 0) == 0 && flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041795 RID: 268181 RVA: 0x010CE6D0 File Offset: 0x010CC8D0
		public void ReadNewInstance()
		{
			foreach (KeyValuePair<int, HarvestLevelReward> keyValuePair in this.MowingLevelInfoDict)
			{
				HarvestLevelReward value = keyValuePair.Value;
				if ((double)value.StartTime <= Singleton<TimeUtil>.Instance.GetServerTime())
				{
					ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, value.Id, 0, 0, 1);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041796 RID: 268182 RVA: 0x010CE76C File Offset: 0x010CC96C
		private List<TItem> GetRewardItems(int dropId)
		{
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
		}

		// Token: 0x06041797 RID: 268183 RVA: 0x010CE77C File Offset: 0x010CC97C
		public string GetDesc()
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.LocalConfig.Value.Desc, null);
		}

		// Token: 0x06041798 RID: 268184 RVA: 0x010CE7A4 File Offset: 0x010CC9A4
		public List<IActivityRewardData> GetPointRewards()
		{
			foreach (IActivityRewardData activityRewardData in this.MowingPointRewards)
			{
				ScoreReward? config = ConfigScoreRewardById.GetConfig(activityRewardData.Id.GetValueOrDefault(), true);
				if (config != null)
				{
					this.RefreshText(activityRewardData, config.Value.Desc);
				}
			}
			this.MowingPointRewards.Sort(new Comparison<IActivityRewardData>(this.SortReward));
			return this.MowingPointRewards;
		}

		// Token: 0x06041799 RID: 268185 RVA: 0x010CE844 File Offset: 0x010CCA44
		public List<IActivityRewardData> GetLevelRewards()
		{
			foreach (IActivityRewardData activityRewardData in this.MowingLevelRewards)
			{
				KillMonstersScores? config = ConfigKillMonstersScoresByInstanceID.GetConfig(activityRewardData.Id.GetValueOrDefault(), true);
				if (config != null)
				{
					this.RefreshText(activityRewardData, config.Value.Desc);
				}
			}
			this.MowingLevelRewards.Sort(new Comparison<IActivityRewardData>(this.SortReward));
			return this.MowingLevelRewards;
		}

		// Token: 0x0604179A RID: 268186 RVA: 0x010CE8E4 File Offset: 0x010CCAE4
		private int SortReward(IActivityRewardData a, IActivityRewardData b)
		{
			int item = this.GetButtonTextByRewardTextAndSort((int)a.RewardState).Item2;
			int item2 = this.GetButtonTextByRewardTextAndSort((int)b.RewardState).Item2;
			if (item == item2)
			{
				return a.Id.GetValueOrDefault() - b.Id.GetValueOrDefault();
			}
			return item - item2;
		}

		// Token: 0x0604179B RID: 268187 RVA: 0x010CE93C File Offset: 0x010CCB3C
		public IActivityRewardViewData GetRewardViewData()
		{
			string tabTips = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("MowingTotalPoint", null), new string[]
			{
				this.GetTotalPoint().ToString()
			});
			ActivityRewardDataPage item = new ActivityRewardDataPage
			{
				DataList = this.GetLevelRewards(),
				TabName = ConfigMultiTextLang.GetLocalTextNew("MowingLevelRewards", null),
				TabTips = tabTips
			};
			ActivityRewardDataPage item2 = new ActivityRewardDataPage
			{
				DataList = this.GetPointRewards(),
				TabName = ConfigMultiTextLang.GetLocalTextNew("MowingPointRewards", null),
				TabTips = tabTips
			};
			return new ActivityRewardViewData
			{
				DataPageList = new List<IActivityRewardDataPage>
				{
					item,
					item2
				},
				Source = EActivityRewardSource.Mowing
			};
		}

		// Token: 0x0604179C RID: 268188 RVA: 0x010CE9F0 File Offset: 0x010CCBF0
		public void SetLevelRewardStateToGot(int instanceId)
		{
			IActivityRewardData activityRewardData;
			if (this.MowingLevelRewardDict.TryGetValue(instanceId, out activityRewardData))
			{
				activityRewardData.RewardState = EActivityRewardState.Claimed;
				string item = this.GetButtonTextByRewardTextAndSort(2).Item1;
				activityRewardData.RewardState = EActivityRewardState.Claimed;
				activityRewardData.RewardButtonText = item;
			}
		}

		// Token: 0x0604179D RID: 268189 RVA: 0x010CEA30 File Offset: 0x010CCC30
		public void SetPointRewardState(int id)
		{
			IActivityRewardData activityRewardData;
			if (this.MowingPointRewardDict.TryGetValue(id, out activityRewardData))
			{
				string item = this.GetButtonTextByRewardTextAndSort(2).Item1;
				activityRewardData.RewardState = EActivityRewardState.Claimed;
				activityRewardData.RewardButtonText = item;
			}
		}

		// Token: 0x0604179E RID: 268190 RVA: 0x010CEA68 File Offset: 0x010CCC68
		public int GetInstanceCurrentPoint(int instanceId)
		{
			HarvestLevelReward harvestLevelReward;
			if (this.MowingLevelInfoDict.TryGetValue(instanceId, out harvestLevelReward))
			{
				return harvestLevelReward.Point;
			}
			return 0;
		}

		// Token: 0x0604179F RID: 268191 RVA: 0x010CEA90 File Offset: 0x010CCC90
		public void SetInstanceCurrentSelectedDiff(int instanceId, int diff)
		{
			HarvestLevelReward harvestLevelReward;
			if (this.MowingLevelInfoDict.TryGetValue(instanceId, out harvestLevelReward))
			{
				harvestLevelReward.Diff = diff;
			}
		}

		// Token: 0x060417A0 RID: 268192 RVA: 0x010CEAB4 File Offset: 0x010CCCB4
		public void UpdatePointRewards(HarvestActivityPointNotify notify)
		{
			foreach (HarvestPointReward harvestPointReward in notify.HarvestPointReward)
			{
				ScoreReward? config = ConfigScoreRewardById.GetConfig(harvestPointReward.Id, true);
				if (config != null)
				{
					IActivityRewardData activityRewardData = this.CreateActivityRewardDataByPoint(harvestPointReward, config.Value);
					IActivityRewardData activityRewardData2;
					if (this.MowingPointRewardDict.TryGetValue(harvestPointReward.Id, out activityRewardData2))
					{
						activityRewardData2.RewardButtonText = activityRewardData.RewardButtonText;
						activityRewardData2.RewardState = activityRewardData.RewardState;
					}
				}
			}
		}

		// Token: 0x060417A1 RID: 268193 RVA: 0x010CEB50 File Offset: 0x010CCD50
		public void UpdateLevelRewards(HarvestActivityLevelNotify notify)
		{
			foreach (HarvestLevelReward harvestLevelReward in notify.HarvestLevelRewards)
			{
				HarvestLevelReward harvestLevelReward2;
				if (this.MowingLevelInfoDict.TryGetValue(harvestLevelReward.Id, out harvestLevelReward2))
				{
					this.MowingLevelInfoDict[harvestLevelReward.Id] = harvestLevelReward;
					IActivityRewardData activityRewardData = this.CreateActivityRewardDataByLevel(harvestLevelReward, ConfigKillMonstersScoresByInstanceID.GetConfig(harvestLevelReward.Id, true).Value);
					IActivityRewardData activityRewardData2;
					if (this.MowingLevelRewardDict.TryGetValue(harvestLevelReward.Id, out activityRewardData2))
					{
						activityRewardData2.RewardState = activityRewardData.RewardState;
						activityRewardData2.RewardButtonText = activityRewardData.RewardButtonText;
					}
				}
			}
		}

		// Token: 0x060417A2 RID: 268194 RVA: 0x010CEC10 File Offset: 0x010CCE10
		public int GetLevelDiffIndex(int instanceId)
		{
			HarvestLevelReward harvestLevelReward;
			if (!this.MowingLevelInfoDict.TryGetValue(instanceId, out harvestLevelReward))
			{
				Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.LK, "当前[击杀积分|KillMonstersScores]没有割草活动副本数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return 0;
			}
			int num = Array.IndexOf<int>(ConfigKillMonstersScoresByInstanceID.GetConfig(instanceId, true).Value.GetDifficultyOptionsArray() ?? Array.Empty<int>(), harvestLevelReward.Diff);
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x060417A3 RID: 268195 RVA: 0x010CEC84 File Offset: 0x010CCE84
		public int GetLevelDiffRecommendLevel(int instanceId)
		{
			HarvestLevelReward harvestLevelReward;
			if (!this.MowingLevelInfoDict.TryGetValue(instanceId, out harvestLevelReward))
			{
				return 0;
			}
			TakeWeedsDifficulty? config = ConfigTakeWeedsDifficultyById.GetConfig(harvestLevelReward.Diff, true);
			if (config == null)
			{
				return 0;
			}
			return config.GetValueOrDefault().RecommendedLevel;
		}

		// Token: 0x060417A4 RID: 268196 RVA: 0x010CECCC File Offset: 0x010CCECC
		public int GetTotalPoint()
		{
			int num = 0;
			foreach (KeyValuePair<int, HarvestLevelReward> keyValuePair in this.MowingLevelInfoDict)
			{
				num += keyValuePair.Value.Point;
			}
			return num;
		}

		// Token: 0x060417A5 RID: 268197 RVA: 0x010CED2C File Offset: 0x010CCF2C
		public int GetLevelMaxPoint(int instanceId)
		{
			HarvestLevelReward harvestLevelReward;
			if (!this.MowingLevelInfoDict.TryGetValue(instanceId, out harvestLevelReward))
			{
				return 0;
			}
			return harvestLevelReward.Point;
		}

		// Token: 0x060417A6 RID: 268198 RVA: 0x010CED54 File Offset: 0x010CCF54
		public bool GetActivityLevelUnlockState(int levelId)
		{
			HarvestLevelReward harvestLevelReward;
			return this.MowingLevelInfoDict.TryGetValue(levelId, out harvestLevelReward) && (double)harvestLevelReward.StartTime <= Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x060417A7 RID: 268199 RVA: 0x010CED8C File Offset: 0x010CCF8C
		public string GetActivityLevelCountdownText(int levelId)
		{
			HarvestLevelReward harvestLevelReward;
			if (!this.MowingLevelInfoDict.TryGetValue(levelId, out harvestLevelReward))
			{
				return "";
			}
			double num = (double)harvestLevelReward.StartTime - Singleton<TimeUtil>.Instance.GetServerTime();
			if (num <= 0.0)
			{
				return "";
			}
			return this.GetRemainTime(num);
		}

		// Token: 0x060417A8 RID: 268200 RVA: 0x010CEDDC File Offset: 0x010CCFDC
		private string GetRemainTime(double cdTime)
		{
			double num = Math.Max(cdTime, Singleton<TimeUtil>.Instance.Minute);
			ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> questLockTimeTypeData = this.GetQuestLockTimeTypeData(num);
			string text = Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(questLockTimeTypeData.Item1), new CommonDefine.ETimeType?(questLockTimeTypeData.Item2)).CountDownText ?? "";
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("ActivityMowing_UnlockCondition", null), new string[]
			{
				text
			});
		}

		// Token: 0x060417A9 RID: 268201 RVA: 0x010CEE4C File Offset: 0x010CD04C
		[NullableContext(0)]
		private ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> GetQuestLockTimeTypeData(double remainTime)
		{
			if (remainTime > 86400.0)
			{
				return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Day);
			}
			if (remainTime > 3600.0)
			{
				return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Hour);
			}
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Minute);
		}

		// Token: 0x0402499D RID: 149917
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IActivityRewardData> MowingPointRewards;

		// Token: 0x0402499E RID: 149918
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IActivityRewardData> MowingLevelRewards;

		// Token: 0x0402499F RID: 149919
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, IActivityRewardData> MowingPointRewardDict;

		// Token: 0x040249A0 RID: 149920
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, IActivityRewardData> MowingLevelRewardDict;

		// Token: 0x040249A1 RID: 149921
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, HarvestLevelReward> MowingLevelInfoDict;
	}
}
