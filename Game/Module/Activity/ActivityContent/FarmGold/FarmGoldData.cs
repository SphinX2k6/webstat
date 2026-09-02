using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FarmGold
{
	// Token: 0x02006853 RID: 26707
	[NullableContext(1)]
	[Nullable(0)]
	public class FarmGoldData : ActivityBaseData
	{
		// Token: 0x06042907 RID: 272647 RVA: 0x01116311 File Offset: 0x01114511
		protected override void PhraseEx(ActivityData data)
		{
			this.CurrentData = data;
			this.FinishPointList = new List<int>(data.FarmGoldInfo.PointsRewardGet);
			this.PhraseLevelData(data.FarmGoldInfo.LevelPlayTasks);
			this.PhraseRewardInfo();
		}

		// Token: 0x06042908 RID: 272648 RVA: 0x01116348 File Offset: 0x01114548
		public void AddFinishPointId(List<int> ids)
		{
			foreach (int item in ids)
			{
				if (!this.FinishPointList.Contains(item))
				{
					ActivityData currentData = this.CurrentData;
					if (currentData != null)
					{
						currentData.FarmGoldInfo.PointsRewardGet.Add(item);
					}
					this.FinishPointList.Add(item);
				}
			}
		}

		// Token: 0x06042909 RID: 272649 RVA: 0x011163C8 File Offset: 0x011145C8
		public void FinishLevelReward(List<int> instIds)
		{
			foreach (int num in instIds)
			{
				FarmGoldLevelData levelInfoByInstId = this.GetLevelInfoByInstId(num);
				if (levelInfoByInstId != null)
				{
					levelInfoByInstId.FinishLevelReward();
				}
				ActivityData currentData = this.CurrentData;
				bool flag;
				if (currentData == null)
				{
					flag = (null != null);
				}
				else
				{
					FarmGoldInfo farmGoldInfo = currentData.FarmGoldInfo;
					flag = (((farmGoldInfo != null) ? farmGoldInfo.LevelPlayTasks : null) != null);
				}
				if (flag)
				{
					foreach (FarmGoldLevelPlayInfo farmGoldLevelPlayInfo in this.CurrentData.FarmGoldInfo.LevelPlayTasks)
					{
						if (farmGoldLevelPlayInfo.InstId == num)
						{
							farmGoldLevelPlayInfo.LevelRewardGet = true;
							break;
						}
					}
				}
			}
		}

		// Token: 0x0604290A RID: 272650 RVA: 0x0111649C File Offset: 0x0111469C
		public List<int> GetAllCanClaimLevelRewardIds()
		{
			List<int> list = new List<int>();
			foreach (FarmGoldLevelData farmGoldLevelData in this.CurrentLevelData)
			{
				if (!farmGoldLevelData.GetHasGetLevelReward() && farmGoldLevelData.GetIfPassLevel())
				{
					list.Add(farmGoldLevelData.GetInstId());
				}
			}
			return list;
		}

		// Token: 0x0604290B RID: 272651 RVA: 0x0111650C File Offset: 0x0111470C
		public List<int> GetAllCanClaimScoreRewardIds()
		{
			List<int> list = new List<int>();
			int currentFullScore = this.GetCurrentFullScore();
			foreach (FarmGoldScore farmGoldScore in ConfigBase<FarmGoldConfig>.Instance.GetScoreConfigByActivityId(base.Id))
			{
				if (!this.FinishPointList.Contains(farmGoldScore.Id) && currentFullScore >= farmGoldScore.Score)
				{
					list.Add(farmGoldScore.Id);
				}
			}
			return list;
		}

		// Token: 0x0604290C RID: 272652 RVA: 0x01116598 File Offset: 0x01114798
		public int GetCurrentFullScore()
		{
			int num = 0;
			foreach (FarmGoldLevelData farmGoldLevelData in this.CurrentLevelData)
			{
				num += farmGoldLevelData.GetPoint();
			}
			return num;
		}

		// Token: 0x0604290D RID: 272653 RVA: 0x011165F0 File Offset: 0x011147F0
		public void PhraseLevelData(RepeatedField<FarmGoldLevelPlayInfo> data)
		{
			this.CurrentLevelData = new List<FarmGoldLevelData>();
			this.CurrentLevelRewardInfo = new List<IActivityRewardData>();
			for (int i = 0; i < data.Count; i++)
			{
				FarmGoldLevelPlayInfo data2 = data[i];
				FarmGoldLevelData farmGoldLevelData = new FarmGoldLevelData();
				farmGoldLevelData.Phrase(base.Id, data2, i);
				this.SetDifficultyFromPreviousLevel(farmGoldLevelData, i);
				this.CurrentLevelData.Add(farmGoldLevelData);
				IActivityRewardData item = this.CreateLevelReward(farmGoldLevelData);
				this.CurrentLevelRewardInfo.Add(item);
			}
		}

		// Token: 0x0604290E RID: 272654 RVA: 0x01116668 File Offset: 0x01114868
		private void SetDifficultyFromPreviousLevel(FarmGoldLevelData levelData, int index)
		{
			if (!levelData.HasSelectDifficult && index > 0)
			{
				FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index - 1);
				if (levelDataByIndex != null)
				{
					levelData.SetDifficult(levelDataByIndex.GetSelectDifficult());
				}
			}
		}

		// Token: 0x0604290F RID: 272655 RVA: 0x0111669C File Offset: 0x0111489C
		public void RestoreDifficultySettings()
		{
			for (int i = 0; i < this.CurrentLevelData.Count; i++)
			{
				FarmGoldLevelData levelData = this.CurrentLevelData[i];
				this.SetDifficultyFromPreviousLevel(levelData, i);
			}
		}

		// Token: 0x06042910 RID: 272656 RVA: 0x011166D4 File Offset: 0x011148D4
		public void RefreshLevelData(FarmGoldLevelPlayInfo data)
		{
			ActivityData currentData = this.CurrentData;
			bool flag;
			if (currentData == null)
			{
				flag = (null != null);
			}
			else
			{
				FarmGoldInfo farmGoldInfo = currentData.FarmGoldInfo;
				flag = (((farmGoldInfo != null) ? farmGoldInfo.LevelPlayTasks : null) != null);
			}
			if (flag)
			{
				foreach (FarmGoldLevelPlayInfo farmGoldLevelPlayInfo in this.CurrentData.FarmGoldInfo.LevelPlayTasks)
				{
					if (farmGoldLevelPlayInfo.InstId == data.InstId)
					{
						farmGoldLevelPlayInfo.Point = data.Point;
						farmGoldLevelPlayInfo.LevelRewardGet = data.LevelRewardGet;
						break;
					}
				}
			}
			FarmGoldLevelData farmGoldLevelData = null;
			int index = -1;
			for (int i = 0; i < this.CurrentLevelData.Count; i++)
			{
				if (this.CurrentLevelData[i].GetInstId() == data.InstId)
				{
					farmGoldLevelData = this.CurrentLevelData[i];
					index = i;
					break;
				}
			}
			if (farmGoldLevelData != null)
			{
				ActivityData currentData2 = this.CurrentData;
				bool flag2;
				if (currentData2 == null)
				{
					flag2 = (null != null);
				}
				else
				{
					FarmGoldInfo farmGoldInfo2 = currentData2.FarmGoldInfo;
					flag2 = (((farmGoldInfo2 != null) ? farmGoldInfo2.LevelPlayTasks : null) != null);
				}
				if (flag2)
				{
					farmGoldLevelData.Phrase(base.Id, data, index);
					this.PhraseLevelData(this.CurrentData.FarmGoldInfo.LevelPlayTasks);
				}
			}
		}

		// Token: 0x06042911 RID: 272657 RVA: 0x01116800 File Offset: 0x01114A00
		public void PhraseRewardInfo()
		{
			this.CurrentScoreRewardInfo = new List<IActivityRewardData>();
			int currentFullScore = this.GetCurrentFullScore();
			foreach (FarmGoldScore farmGoldScore in ConfigBase<FarmGoldConfig>.Instance.GetScoreConfigByActivityId(base.Id))
			{
				IActivityRewardData item = this.CreateScoreReward(farmGoldScore.Id, this.FinishPointList, currentFullScore);
				this.CurrentScoreRewardInfo.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.FarmGoldRefreshRewardRedDot, base.Id);
		}

		// Token: 0x06042912 RID: 272658 RVA: 0x0111689C File Offset: 0x01114A9C
		private IActivityRewardData CreateLevelReward(FarmGoldLevelData levelData)
		{
			FarmGoldActivity config = levelData.GetConfig();
			bool hasGetLevelReward = levelData.GetHasGetLevelReward();
			bool flag = levelData.GetPoint() >= config.PassScore;
			EActivityRewardState eactivityRewardState = hasGetLevelReward ? EActivityRewardState.Claimed : (flag ? EActivityRewardState.Enable : EActivityRewardState.Disabled);
			FarmGoldController controller = ControllerBase<FarmGoldController>.Instance;
			return new ActivityRewardData
			{
				Id = new int?(config.Id),
				NameText = ConfigMultiTextLang.GetLocalTextNew(config.LevelRewardDesc, null),
				RewardState = eactivityRewardState,
				ClickFunction = delegate
				{
					List<int> allCanClaimLevelRewardIds = this.GetAllCanClaimLevelRewardIds();
					if (allCanClaimLevelRewardIds.Count > 0)
					{
						controller.RequestFarmGoldLevelPlay(this.Id, allCanClaimLevelRewardIds);
					}
				},
				RewardList = this.GetRewardItems(config.RewardId).ToArray(),
				RewardButtonText = ConfigMultiTextLang.GetLocalTextNew(this.GetButtonText((int)eactivityRewardState), null)
			};
		}

		// Token: 0x06042913 RID: 272659 RVA: 0x0111695C File Offset: 0x01114B5C
		private IActivityRewardData CreateScoreReward(int scoreId, List<int> finishGetIdList, int currentPoint)
		{
			FarmGoldScore? scoreConfigById = ConfigBase<FarmGoldConfig>.Instance.GetScoreConfigById(scoreId);
			if (scoreConfigById == null)
			{
				return new ActivityRewardData
				{
					NameText = "",
					RewardState = EActivityRewardState.Disabled
				};
			}
			FarmGoldScore value = scoreConfigById.Value;
			string nameText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("FarmGoldFullScoreTips", null), new string[]
			{
				value.Score.ToString()
			});
			EActivityRewardState eactivityRewardState = finishGetIdList.Contains(scoreId) ? EActivityRewardState.Claimed : ((currentPoint >= value.Score) ? EActivityRewardState.Enable : EActivityRewardState.Disabled);
			FarmGoldController controller = ControllerBase<FarmGoldController>.Instance;
			return new ActivityRewardData
			{
				Id = new int?(value.RewardId),
				NameText = nameText,
				RewardState = eactivityRewardState,
				ClickFunction = delegate
				{
					List<int> allCanClaimScoreRewardIds = this.GetAllCanClaimScoreRewardIds();
					if (allCanClaimScoreRewardIds.Count > 0)
					{
						controller.RequestFarmGoldPoint(this.Id, allCanClaimScoreRewardIds);
					}
				},
				RewardList = this.GetRewardItems(value.RewardId).ToArray(),
				RewardButtonText = ConfigMultiTextLang.GetLocalTextNew(this.GetButtonText((int)eactivityRewardState), null)
			};
		}

		// Token: 0x06042914 RID: 272660 RVA: 0x01116A60 File Offset: 0x01114C60
		private string GetButtonText(int state)
		{
			switch (state)
			{
			case 0:
				return "PrefabTextItem_1443074454_Text";
			case 1:
				return "CollectActivity_state_CanRecive";
			case 2:
				return "CollectActivity_state_recived";
			default:
				return "";
			}
		}

		// Token: 0x06042915 RID: 272661 RVA: 0x01116A8D File Offset: 0x01114C8D
		private List<TItem> GetRewardItems(int dropId)
		{
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(dropId);
		}

		// Token: 0x06042916 RID: 272662 RVA: 0x01116A9A File Offset: 0x01114C9A
		public override bool GetExDataRedPointShowState()
		{
			return base.GetPreGuideQuestFinishState() && (this.GetIfCanTakeReward() || this.IfHaveNewLevel());
		}

		// Token: 0x06042917 RID: 272663 RVA: 0x01116AB8 File Offset: 0x01114CB8
		protected override bool GetExDataFinishShowState()
		{
			if (this.CurrentData == null)
			{
				return false;
			}
			using (List<IActivityRewardData>.Enumerator enumerator = this.CurrentScoreRewardInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState != EActivityRewardState.Claimed)
					{
						return false;
					}
				}
			}
			using (List<IActivityRewardData>.Enumerator enumerator = this.CurrentLevelRewardInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState != EActivityRewardState.Claimed)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06042918 RID: 272664 RVA: 0x01116B64 File Offset: 0x01114D64
		private bool IfHaveNewLevel()
		{
			using (List<FarmGoldLevelData>.Enumerator enumerator = this.CurrentLevelData.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetNewOpenState())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06042919 RID: 272665 RVA: 0x01116BC0 File Offset: 0x01114DC0
		private bool GetIfCanTakeReward()
		{
			using (List<IActivityRewardData>.Enumerator enumerator = this.CurrentScoreRewardInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState == EActivityRewardState.Enable)
					{
						return true;
					}
				}
			}
			using (List<IActivityRewardData>.Enumerator enumerator = this.CurrentLevelRewardInfo.GetEnumerator())
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

		// Token: 0x0604291A RID: 272666 RVA: 0x01116C60 File Offset: 0x01114E60
		public bool EntranceRedDot()
		{
			return this.GetExDataRedPointShowState();
		}

		// Token: 0x0604291B RID: 272667 RVA: 0x01116C68 File Offset: 0x01114E68
		private int SortRewardCompare(IActivityRewardData a, IActivityRewardData b)
		{
			int rewardSort = this.GetRewardSort(b);
			int rewardSort2 = this.GetRewardSort(a);
			if (rewardSort == rewardSort2)
			{
				return a.Id.GetValueOrDefault() - b.Id.GetValueOrDefault();
			}
			return rewardSort - rewardSort2;
		}

		// Token: 0x0604291C RID: 272668 RVA: 0x01116CAA File Offset: 0x01114EAA
		public void RebuildData()
		{
			if (this.CurrentData != null)
			{
				this.PhraseEx(this.CurrentData);
			}
		}

		// Token: 0x0604291D RID: 272669 RVA: 0x01116CC0 File Offset: 0x01114EC0
		public IActivityRewardViewData GetRewardPopUpViewData()
		{
			this.RebuildData();
			return this.GetRewardViewData();
		}

		// Token: 0x0604291E RID: 272670 RVA: 0x01116CD0 File Offset: 0x01114ED0
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"ClaimedNum",
			"TotalNum"
		})]
		public ValueTuple<int, int> GetAllRewardClaimedAndTotalNum()
		{
			int num = 0;
			int num2 = 0;
			foreach (IActivityRewardData activityRewardData in this.CurrentLevelRewardInfo)
			{
				num2++;
				if (activityRewardData.RewardState == EActivityRewardState.Claimed)
				{
					num++;
				}
			}
			foreach (IActivityRewardData activityRewardData2 in this.CurrentScoreRewardInfo)
			{
				num2++;
				if (activityRewardData2.RewardState == EActivityRewardState.Claimed)
				{
					num++;
				}
			}
			return new ValueTuple<int, int>(num, num2);
		}

		// Token: 0x0604291F RID: 272671 RVA: 0x01116D80 File Offset: 0x01114F80
		public string GetScoreDesc()
		{
			return this.GetCurrentFullScore().ToString();
		}

		// Token: 0x06042920 RID: 272672 RVA: 0x01116D9C File Offset: 0x01114F9C
		public IActivityRewardViewData GetRewardViewData()
		{
			string tabTips = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("FarmGoldFullPoint", null), new string[]
			{
				this.GetCurrentFullScore().ToString()
			});
			List<IActivityRewardData> list = new List<IActivityRewardData>(this.CurrentLevelRewardInfo);
			FarmGoldData.ManualSort(list, new Comparison<IActivityRewardData>(this.SortLevelRewardCompare));
			ActivityRewardDataPage item = new ActivityRewardDataPage
			{
				DataList = list,
				TabName = ConfigMultiTextLang.GetLocalTextNew("FarmGoldLevelRewardText", null),
				TabTips = " "
			};
			List<IActivityRewardData> list2 = new List<IActivityRewardData>(this.CurrentScoreRewardInfo);
			FarmGoldData.ManualSort(list2, new Comparison<IActivityRewardData>(this.SortRewardCompare));
			ActivityRewardDataPage item2 = new ActivityRewardDataPage
			{
				DataList = list2,
				TabName = ConfigMultiTextLang.GetLocalTextNew("FarmGoldScoreRewardText", null),
				TabTips = tabTips
			};
			return new ActivityRewardViewData
			{
				DataPageList = new List<IActivityRewardDataPage>
				{
					item,
					item2
				},
				Source = EActivityRewardSource.FarmGold
			};
		}

		// Token: 0x06042921 RID: 272673 RVA: 0x01116E88 File Offset: 0x01115088
		private static void ManualSort(List<IActivityRewardData> list, Comparison<IActivityRewardData> comparer)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				for (int j = i + 1; j < list.Count; j++)
				{
					if (comparer(list[i], list[j]) > 0)
					{
						IActivityRewardData value = list[i];
						list[i] = list[j];
						list[j] = value;
					}
				}
			}
		}

		// Token: 0x06042922 RID: 272674 RVA: 0x01116EF0 File Offset: 0x011150F0
		private int SortLevelRewardCompare(IActivityRewardData a, IActivityRewardData b)
		{
			int rewardSort = this.GetRewardSort(a);
			int rewardSort2 = this.GetRewardSort(b);
			if (rewardSort == rewardSort2)
			{
				return a.Id.GetValueOrDefault() - b.Id.GetValueOrDefault();
			}
			return rewardSort2 - rewardSort;
		}

		// Token: 0x06042923 RID: 272675 RVA: 0x01116F34 File Offset: 0x01115134
		private int GetRewardSort(IActivityRewardData data)
		{
			switch (data.RewardState)
			{
			case EActivityRewardState.Disabled:
				return 2;
			case EActivityRewardState.Enable:
				return 3;
			case EActivityRewardState.Claimed:
				return 1;
			default:
				return 4;
			}
		}

		// Token: 0x06042924 RID: 272676 RVA: 0x01116F64 File Offset: 0x01115164
		[NullableContext(2)]
		public FarmGoldLevelData GetLevelInfoByInstId(int instId)
		{
			foreach (FarmGoldLevelData farmGoldLevelData in this.CurrentLevelData)
			{
				if (farmGoldLevelData.GetInstId() == instId)
				{
					return farmGoldLevelData;
				}
			}
			return null;
		}

		// Token: 0x06042925 RID: 272677 RVA: 0x01116FC0 File Offset: 0x011151C0
		public bool HaveRewardCanTake()
		{
			return this.GetIfCanTakeReward();
		}

		// Token: 0x06042926 RID: 272678 RVA: 0x01116FC8 File Offset: 0x011151C8
		public void SaveOpenState(int instId)
		{
			FarmGoldLevelData levelInfoByInstId = this.GetLevelInfoByInstId(instId);
			if (levelInfoByInstId != null)
			{
				levelInfoByInstId.SaveOpenState();
			}
		}

		// Token: 0x06042927 RID: 272679 RVA: 0x01116FE6 File Offset: 0x011151E6
		public bool GetInsOpenState(int instanceId)
		{
			FarmGoldLevelData levelInfoByInstId = this.GetLevelInfoByInstId(instanceId);
			return levelInfoByInstId != null && levelInfoByInstId.GetNewOpenState();
		}

		// Token: 0x06042928 RID: 272680 RVA: 0x01116FFA File Offset: 0x011151FA
		public string GetInsUnlockState(int instanceId)
		{
			FarmGoldLevelData levelInfoByInstId = this.GetLevelInfoByInstId(instanceId);
			return ((levelInfoByInstId != null) ? levelInfoByInstId.GetUnlockTimeText() : null) ?? "";
		}

		// Token: 0x06042929 RID: 272681 RVA: 0x01117018 File Offset: 0x01115218
		public string GetInsUnlockText(int instanceId)
		{
			FarmGoldLevelData levelInfoByInstId = this.GetLevelInfoByInstId(instanceId);
			return ((levelInfoByInstId != null) ? levelInfoByInstId.GetUnlockTimeText() : null) ?? "";
		}

		// Token: 0x0604292A RID: 272682 RVA: 0x01117036 File Offset: 0x01115236
		public List<FarmGoldLevelData> GetAllLevelData()
		{
			return this.CurrentLevelData;
		}

		// Token: 0x0604292B RID: 272683 RVA: 0x0111703E File Offset: 0x0111523E
		[NullableContext(2)]
		public FarmGoldLevelData GetLevelDataByIndex(int index)
		{
			if (index < 0 || index >= this.CurrentLevelData.Count)
			{
				return null;
			}
			return this.CurrentLevelData[index];
		}

		// Token: 0x0604292C RID: 272684 RVA: 0x01117060 File Offset: 0x01115260
		public string GetLevelNameTextByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return ((levelDataByIndex != null) ? levelDataByIndex.GetNameText() : null) ?? "";
		}

		// Token: 0x0604292D RID: 272685 RVA: 0x0111707E File Offset: 0x0111527E
		public string GetLevelDescTextByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return ((levelDataByIndex != null) ? levelDataByIndex.GetDescText() : null) ?? "";
		}

		// Token: 0x0604292E RID: 272686 RVA: 0x0111709C File Offset: 0x0111529C
		public List<int> GetLevelRecommendElementByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return ((levelDataByIndex != null) ? levelDataByIndex.GetRecommendElement() : null) ?? new List<int>();
		}

		// Token: 0x0604292F RID: 272687 RVA: 0x011170BA File Offset: 0x011152BA
		public string GetLevelSubTitleTextByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return ((levelDataByIndex != null) ? levelDataByIndex.GetSubTitleText() : null) ?? "";
		}

		// Token: 0x06042930 RID: 272688 RVA: 0x011170D8 File Offset: 0x011152D8
		public bool GetLevelLockStateByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return levelDataByIndex != null && !levelDataByIndex.GetIsOpen();
		}

		// Token: 0x06042931 RID: 272689 RVA: 0x011170FB File Offset: 0x011152FB
		public int GetLevelInstanceDungeonIdByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			if (levelDataByIndex == null)
			{
				return 0;
			}
			return levelDataByIndex.GetInstId();
		}

		// Token: 0x06042932 RID: 272690 RVA: 0x0111710F File Offset: 0x0111530F
		public string GetLevelUnlockTextByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return ((levelDataByIndex != null) ? levelDataByIndex.GetUnlockTimeText() : null) ?? "";
		}

		// Token: 0x06042933 RID: 272691 RVA: 0x0111712D File Offset: 0x0111532D
		public bool GetLevelFinishStateByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return levelDataByIndex != null && levelDataByIndex.GetFinishState();
		}

		// Token: 0x06042934 RID: 272692 RVA: 0x01117141 File Offset: 0x01115341
		public int GetLevelRecommendLevelByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			if (levelDataByIndex == null)
			{
				return 0;
			}
			return levelDataByIndex.GetRecommendLevel();
		}

		// Token: 0x06042935 RID: 272693 RVA: 0x01117155 File Offset: 0x01115355
		public bool GetLevelRedDotStateByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return levelDataByIndex != null && levelDataByIndex.GetRedDotState();
		}

		// Token: 0x06042936 RID: 272694 RVA: 0x0111716C File Offset: 0x0111536C
		public int GetLevelDifficultIndexByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			if (levelDataByIndex != null)
			{
				return levelDataByIndex.GetSelectDifficultIndex();
			}
			if (index > 0)
			{
				levelDataByIndex = this.GetLevelDataByIndex(index - 1);
				if (levelDataByIndex != null)
				{
					return levelDataByIndex.GetSelectDifficultIndex();
				}
			}
			return 1;
		}

		// Token: 0x06042937 RID: 272695 RVA: 0x011171A4 File Offset: 0x011153A4
		public string GetLevelBgByIndex(int index)
		{
			FarmGoldLevelData levelDataByIndex = this.GetLevelDataByIndex(index);
			return ((levelDataByIndex != null) ? levelDataByIndex.GetInstanceBg() : null) ?? "";
		}

		// Token: 0x06042938 RID: 272696 RVA: 0x011171C4 File Offset: 0x011153C4
		public string GetDifficultTogText(int difficultId)
		{
			FarmGoldDifficulty farmGoldDifficultById = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldDifficultById(difficultId);
			string str = ConfigMultiTextLang.GetLocalTextNew(farmGoldDifficultById.Desc, null) ?? "";
			string str2 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("FarmGoldPointMultiply", null) ?? "", new string[]
			{
				(farmGoldDifficultById.Magnification / 100).ToString()
			});
			return str + "•" + str2;
		}

		// Token: 0x06042939 RID: 272697 RVA: 0x01117238 File Offset: 0x01115438
		public string GetDifficultTitle(int difficultId)
		{
			FarmGoldDifficulty farmGoldDifficultById = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldDifficultById(difficultId);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(farmGoldDifficultById.Desc, null);
			string str = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("FarmGoldPointMultiply", null) ?? "", new string[]
			{
				(farmGoldDifficultById.Magnification / 100).ToString()
			});
			return localTextNew + "•" + str;
		}

		// Token: 0x0604293A RID: 272698 RVA: 0x011172A0 File Offset: 0x011154A0
		public int GetDifficultRecommendLevel(int difficultId)
		{
			return ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldDifficultById(difficultId).RecommendedLevel;
		}

		// Token: 0x0604293B RID: 272699 RVA: 0x011172C0 File Offset: 0x011154C0
		public void SetInsDifficult(int instId, int difficult)
		{
			FarmGoldLevelData levelInfoByInstId = this.GetLevelInfoByInstId(instId);
			if (levelInfoByInstId != null)
			{
				levelInfoByInstId.SetDifficult(difficult);
			}
		}

		// Token: 0x040250EB RID: 151787
		[StaticVariableRuleIgnore]
		public static int CurrentSelectEntranceId;

		// Token: 0x040250EC RID: 151788
		private List<int> FinishPointList = new List<int>();

		// Token: 0x040250ED RID: 151789
		private List<IActivityRewardData> CurrentScoreRewardInfo = new List<IActivityRewardData>();

		// Token: 0x040250EE RID: 151790
		private List<FarmGoldLevelData> CurrentLevelData = new List<FarmGoldLevelData>();

		// Token: 0x040250EF RID: 151791
		private List<IActivityRewardData> CurrentLevelRewardInfo = new List<IActivityRewardData>();

		// Token: 0x040250F0 RID: 151792
		[Nullable(2)]
		private ActivityData CurrentData;
	}
}
