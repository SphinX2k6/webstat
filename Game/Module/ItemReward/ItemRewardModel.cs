using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B3B RID: 23355
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ItemRewardModel : ModelBase<ItemRewardModel>
	{
		// Token: 0x0603B12B RID: 241963 RVA: 0x00EF2B58 File Offset: 0x00EF0D58
		[NullableContext(0)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private RewardData<T> CurrentRewardData<T>() where T : IRewardInfo
		{
			RewardData<T> rewardData = this.CurrentRewardDataInternal as RewardData<T>;
			if (rewardData != null)
			{
				return rewardData;
			}
			return null;
		}

		// Token: 0x0603B12C RID: 241964 RVA: 0x00EF2B77 File Offset: 0x00EF0D77
		[NullableContext(2)]
		private IRewardDataInterface CurrentRewardData()
		{
			return this.CurrentRewardDataInternal;
		}

		// Token: 0x0603B12D RID: 241965 RVA: 0x00EF2B7F File Offset: 0x00EF0D7F
		protected override bool OnClear()
		{
			this.CurrentRewardDataInternal = null;
			this.CurrentReasonId = null;
			return true;
		}

		// Token: 0x0603B12E RID: 241966 RVA: 0x00EF2B98 File Offset: 0x00EF0D98
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<IRewardInfo> RefreshRewardData(EUiViewName viewName, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null)
		{
			RewardInfo rewardInfo = new RewardInfo
			{
				Type = ERewardInfoType.Default,
				ViewName = viewName
			};
			this.NewRewardData<IRewardInfo>(true);
			this.CurrentRewardData<IRewardInfo>().SetRewardInfo(rewardInfo);
			this.CurrentRewardData<IRewardInfo>().SetItemList(rewardItemDataList);
			return this.CurrentRewardData<IRewardInfo>();
		}

		// Token: 0x0603B12F RID: 241967 RVA: 0x00EF2BE0 File Offset: 0x00EF0DE0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<IExploreLevelRewardInfo> RefreshExploreLevelRewardData(EUiViewName viewName, int currentExploreLevel, int targetExploreLevel, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null)
		{
			ExploreLevelRewardInfo rewardInfo = new ExploreLevelRewardInfo
			{
				Type = ERewardInfoType.Default,
				ViewName = viewName,
				CurrentExploreLevel = currentExploreLevel,
				TargetExploreLevel = targetExploreLevel
			};
			this.NewRewardData<IExploreLevelRewardInfo>(true);
			this.CurrentRewardData<IExploreLevelRewardInfo>().SetRewardInfo(rewardInfo);
			this.CurrentRewardData<IExploreLevelRewardInfo>().SetItemList(rewardItemDataList);
			return this.CurrentRewardData<IExploreLevelRewardInfo>();
		}

		// Token: 0x0603B130 RID: 241968 RVA: 0x00EF2C38 File Offset: 0x00EF0E38
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<IExploreLevelRewardInfo> GetExploreLevelRewardData(EUiViewName viewName, int currentExploreLevel, int targetExploreLevel, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null)
		{
			ExploreLevelRewardInfo rewardInfo = new ExploreLevelRewardInfo
			{
				Type = ERewardInfoType.Default,
				ViewName = viewName,
				CurrentExploreLevel = currentExploreLevel,
				TargetExploreLevel = targetExploreLevel
			};
			RewardData<IExploreLevelRewardInfo> rewardData = new RewardData<IExploreLevelRewardInfo>(null, null);
			rewardData.SetRewardInfo(rewardInfo);
			rewardData.SetItemList(rewardItemDataList);
			return rewardData;
		}

		// Token: 0x0603B131 RID: 241969 RVA: 0x00EF2C80 File Offset: 0x00EF0E80
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<ICommonRewardInfo> RefreshCommonRewardDataFromConfig(int configId, EUiViewName viewName, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, Action onCloseCallback = null, string leftBtnTextId = null, string rightBtnTextId = null, Action leftAction = null, Action rightAction = null, bool tipsCanSkip = true, bool disableMaskClose = false)
		{
			CommonRewardViewDisplay? commonRewardViewDisplayConfig = ConfigBase<ItemRewardConfig>.Instance.GetCommonRewardViewDisplayConfig(configId);
			if (commonRewardViewDisplayConfig == null)
			{
				return null;
			}
			CommonRewardViewDisplay value = commonRewardViewDisplayConfig.Value;
			CommonRewardInfo rewardInfo = new CommonRewardInfo
			{
				Type = ERewardInfoType.Common,
				ViewName = viewName,
				AudioId = value.AudioId,
				Title = value.Title,
				ContinueText = value.ContinueText,
				IsItemVisible = value.IsItemVisible,
				OnCloseCallback = onCloseCallback,
				LeftBtnTextId = leftBtnTextId,
				RightBtnTextId = rightBtnTextId,
				LeftAction = leftAction,
				RightAction = rightAction,
				DisableMaskClose = new bool?(disableMaskClose),
				TipsCanSkip = new bool?(tipsCanSkip)
			};
			this.NewRewardData<ICommonRewardInfo>(true);
			this.CurrentRewardData<ICommonRewardInfo>().SetRewardInfo(rewardInfo);
			this.CurrentRewardData<ICommonRewardInfo>().SetItemList(rewardItemDataList);
			return this.CurrentRewardData<ICommonRewardInfo>();
		}

		// Token: 0x0603B132 RID: 241970 RVA: 0x00EF2D5C File Offset: 0x00EF0F5C
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<ICommonRewardInfo> CreateCommonRewardDataFromConfig(int configId, EUiViewName viewName, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, Action onCloseCallback = null, string leftBtnTextId = null, string rightBtnTextId = null, Action leftAction = null, Action rightAction = null, bool tipsCanSkip = true, bool disableMaskClose = false)
		{
			CommonRewardViewDisplay? commonRewardViewDisplayConfig = ConfigBase<ItemRewardConfig>.Instance.GetCommonRewardViewDisplayConfig(configId);
			if (commonRewardViewDisplayConfig == null)
			{
				return null;
			}
			CommonRewardViewDisplay value = commonRewardViewDisplayConfig.Value;
			CommonRewardInfo rewardInfo = new CommonRewardInfo
			{
				Type = ERewardInfoType.Common,
				ViewName = viewName,
				AudioId = value.AudioId,
				Title = value.Title,
				ContinueText = value.ContinueText,
				IsItemVisible = value.IsItemVisible,
				OnCloseCallback = onCloseCallback,
				LeftBtnTextId = leftBtnTextId,
				RightBtnTextId = rightBtnTextId,
				LeftAction = leftAction,
				RightAction = rightAction,
				DisableMaskClose = new bool?(disableMaskClose),
				TipsCanSkip = new bool?(tipsCanSkip)
			};
			RewardData<ICommonRewardInfo> rewardData = new RewardData<ICommonRewardInfo>(null, null);
			rewardData.SetRewardInfo(rewardInfo);
			rewardData.SetItemList(rewardItemDataList);
			return rewardData;
		}

		// Token: 0x0603B133 RID: 241971 RVA: 0x00EF2E28 File Offset: 0x00EF1028
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<ICompositeRewardInfo> RefreshCompositeRewardDataFromConfig(int configId, bool isSuccess = true, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardProgress> progressQueue = null)
		{
			CompositeRewardDisplay? compositeRewardViewDisplayConfig = ConfigBase<ItemRewardConfig>.Instance.GetCompositeRewardViewDisplayConfig(configId);
			if (compositeRewardViewDisplayConfig == null)
			{
				return null;
			}
			CompositeRewardDisplay value = compositeRewardViewDisplayConfig.Value;
			CompositeRewardInfo rewardInfo = new CompositeRewardInfo
			{
				Type = ERewardInfoType.Composite,
				ViewName = EUiViewName.CompositeRewardView,
				Id = value.Id,
				AudioId = value.AudioId,
				IsSuccess = isSuccess,
				Title = value.Title,
				ContinueText = value.ContinueText,
				TitleIconPath = value.TitleIconPath,
				IsProgressVisible = value.IsProgressVisible,
				ProgressBarTitle = value.ProgressBarTitle,
				ProgressBarAnimationTime = value.ProgressBarAnimationTime,
				IsItemVisible = value.IsItemVisible
			};
			this.NewRewardData<ICompositeRewardInfo>(true);
			this.CurrentRewardData<ICompositeRewardInfo>().SetRewardInfo(rewardInfo);
			this.CurrentRewardData<ICompositeRewardInfo>().SetItemList(rewardItemDataList);
			if (progressQueue != null)
			{
				this.CurrentRewardData<ICompositeRewardInfo>().SetProgressQueue(progressQueue);
			}
			return this.CurrentRewardData<ICompositeRewardInfo>();
		}

		// Token: 0x0603B134 RID: 241972 RVA: 0x00EF2F20 File Offset: 0x00EF1120
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<IExploreRewardInfo> RefreshExploreRewardDataFromConfig(int configId, bool isSuccess = true, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, IRewardExploreRecord exploreRecordInfo = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreBar> exploreBarDataList = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreConfirmButton> buttonInfoList = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreTargetReached> targetReached = null, IRewardExploreToggle stateToggle = null, Action onCloseCallback = null, string tip = null, bool? isShowOnlineChallengePlayer = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreFriendData> exploreFriendDataList = null, ReachTargetData scoreReachedData = null, bool? isRewardMultiLine = null, AccumulatedScoreData accumulatedScoreData = null, string titleTextId = null)
		{
			ExploreRewardDisplay? exploreRewardDisplayConfig = ConfigBase<ItemRewardConfig>.Instance.GetExploreRewardDisplayConfig(configId);
			if (exploreRewardDisplayConfig == null)
			{
				return null;
			}
			ExploreRewardDisplay value = exploreRewardDisplayConfig.Value;
			ExploreRewardInfo rewardInfo = new ExploreRewardInfo
			{
				Type = ERewardInfoType.Explore,
				ViewName = EUiViewName.ExploreRewardView,
				AudioId = value.AudioId,
				IsSuccess = isSuccess,
				Title = (titleTextId ?? value.Title),
				TitleHexColor = value.TitleHexColor,
				TitleIconPath = value.TitleIconPath,
				TitleIconHexColor = value.TitleIconHexColor,
				IsRecordVisible = value.IsRecordVisible,
				IsItemVisible = value.IsItemVisible,
				IsExploreProgressVisible = value.IsExploreProgressVisible,
				ExploreBarTipsTextId = value.ExploreBarTipsTextId,
				IsDescription = value.IsDescription,
				Description = value.Description,
				OnCloseCallback = onCloseCallback,
				Tip = tip,
				IsShowOnlineChallengePlayer = isShowOnlineChallengePlayer,
				IsRewardMultiLine = isRewardMultiLine
			};
			this.NewRewardData<IExploreRewardInfo>(true);
			this.CurrentRewardData<IExploreRewardInfo>().SetRewardInfo(rewardInfo);
			if (rewardItemDataList != null)
			{
				ItemRewardRoleDevelopStateTagUtil.FillRewardRoleDevelopStateTagType(rewardItemDataList);
			}
			this.CurrentRewardData<IExploreRewardInfo>().SetItemList(rewardItemDataList);
			if (exploreRecordInfo != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetExploreRecordInfo(exploreRecordInfo);
			}
			if (exploreBarDataList != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetExploreBarDataList(exploreBarDataList);
			}
			if (buttonInfoList != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetButtonInfoList(buttonInfoList);
			}
			if (targetReached != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetTargetReached(targetReached);
			}
			if (stateToggle != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetStateToggle(stateToggle);
			}
			if (exploreFriendDataList != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetExploreFriendDataList(exploreFriendDataList);
			}
			if (scoreReachedData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetScoreReached(scoreReachedData);
			}
			if (accumulatedScoreData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetAccumulatedScoreData(accumulatedScoreData);
			}
			return this.CurrentRewardData<IExploreRewardInfo>();
		}

		// Token: 0x0603B135 RID: 241973 RVA: 0x00EF30D8 File Offset: 0x00EF12D8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<IExploreRewardInfo> RefreshExploreRewardDataFromConfigNew(IExploreRewardViewData data)
		{
			ExploreRewardDisplay? exploreRewardDisplayConfig = ConfigBase<ItemRewardConfig>.Instance.GetExploreRewardDisplayConfig(data.ConfigId);
			if (exploreRewardDisplayConfig == null)
			{
				return null;
			}
			ExploreRewardDisplay value = exploreRewardDisplayConfig.Value;
			ExploreRewardInfo rewardInfo = new ExploreRewardInfo
			{
				Type = ERewardInfoType.Explore,
				ViewName = EUiViewName.ExploreRewardView,
				AudioId = value.AudioId,
				IsSuccess = data.IsSuccess,
				Title = (data.TitleTextId ?? value.Title),
				TitleHexColor = value.TitleHexColor,
				TitleIconPath = value.TitleIconPath,
				TitleIconHexColor = value.TitleIconHexColor,
				IsRecordVisible = value.IsRecordVisible,
				IsItemVisible = value.IsItemVisible,
				IsExploreProgressVisible = value.IsExploreProgressVisible,
				ExploreBarTipsTextId = value.ExploreBarTipsTextId,
				IsDescription = value.IsDescription,
				Description = value.Description,
				OnCloseCallback = data.OnCloseCallback,
				Tip = data.Tip,
				IsShowOnlineChallengePlayer = data.IsShowOnlineChallengePlayer,
				IsRewardMultiLine = data.IsRewardMultiLine,
				IsBagFull = data.IsBagFull
			};
			this.NewRewardData<IExploreRewardInfo>(true);
			this.CurrentRewardData<IExploreRewardInfo>().SetRewardInfo(rewardInfo);
			if (data.RewardItemDataList != null)
			{
				ItemRewardRoleDevelopStateTagUtil.FillRewardRoleDevelopStateTagType(data.RewardItemDataList);
			}
			this.CurrentRewardData<IExploreRewardInfo>().SetItemList(data.RewardItemDataList);
			if (data.ExploreRecordInfo != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetExploreRecordInfo(data.ExploreRecordInfo);
			}
			if (data.ExploreBarDataList != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetExploreBarDataList(data.ExploreBarDataList);
			}
			if (data.ButtonInfoList != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetButtonInfoList(data.ButtonInfoList);
			}
			if (data.TargetReached != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetTargetReached(data.TargetReached);
			}
			if (data.StateToggle != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetStateToggle(data.StateToggle);
			}
			if (data.ExploreFriendDataList != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetExploreFriendDataList(data.ExploreFriendDataList);
			}
			if (data.ScoreReachedData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetScoreReached(data.ScoreReachedData);
			}
			if (data.AccumulatedScoreData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetAccumulatedScoreData(data.AccumulatedScoreData);
			}
			if (data.BabelTowerSuccessData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetBabelTowerSuccessData(data.BabelTowerSuccessData);
			}
			if (data.DangoAbyssSuccessData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetDangoAbyssSuccessData(data.DangoAbyssSuccessData);
			}
			if (data.HonamiTowerSuccessData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetHonamiTowerSuccessData(data.HonamiTowerSuccessData);
			}
			if (data.RoguelikeBossChallengeData != null)
			{
				this.CurrentRewardData<IExploreRewardInfo>().SetRoguelikeBossChallengeData(data.RoguelikeBossChallengeData);
			}
			return this.CurrentRewardData<IExploreRewardInfo>();
		}

		// Token: 0x0603B136 RID: 241974 RVA: 0x00EF336C File Offset: 0x00EF156C
		public void SetItemList(List<RewardItemData> rewardItemList)
		{
			if (this.CurrentRewardData() == null)
			{
				this.NewRewardData<IRewardInfo>(false);
			}
			if (rewardItemList == null || rewardItemList.Count < 1)
			{
				return;
			}
			this.CurrentRewardData().SetItemList(rewardItemList);
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<RewardItemData>>(EEventName.OnRefreshRewardViewItemList, rewardItemList);
		}

		// Token: 0x0603B137 RID: 241975 RVA: 0x00EF33A8 File Offset: 0x00EF15A8
		public void AddItemList(List<RewardItemData> rewardItemList)
		{
			if (this.CurrentRewardData() == null)
			{
				this.NewRewardData<IRewardInfo>(false);
			}
			if (rewardItemList == null || rewardItemList.Count < 1)
			{
				return;
			}
			this.CurrentRewardData().AddItemList(rewardItemList);
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<RewardItemData>>(EEventName.OnRefreshRewardViewItemList, rewardItemList);
		}

		// Token: 0x0603B138 RID: 241976 RVA: 0x00EF33E4 File Offset: 0x00EF15E4
		public void SetProgressQueue(List<IRewardProgress> progressQueue)
		{
			if (this.CurrentRewardData() == null)
			{
				this.NewRewardData<IRewardInfo>(false);
			}
			this.CurrentRewardData().SetProgressQueue(progressQueue);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshRewardProgressBar);
		}

		// Token: 0x0603B139 RID: 241977 RVA: 0x00EF3412 File Offset: 0x00EF1612
		public void SetExploreBarDataList(List<IRewardExploreBar> exploreBarDataList)
		{
			if (this.CurrentRewardData() == null)
			{
				this.NewRewardData<IRewardInfo>(false);
			}
			this.CurrentRewardData().SetExploreBarDataList(exploreBarDataList);
		}

		// Token: 0x0603B13A RID: 241978 RVA: 0x00EF3430 File Offset: 0x00EF1630
		public void SetExploreRecordInfo(IRewardExploreRecord exploreRecordInfo)
		{
			if (this.CurrentRewardData() == null)
			{
				this.NewRewardData<IRewardInfo>(false);
			}
			this.CurrentRewardData().SetExploreRecordInfo(exploreRecordInfo);
		}

		// Token: 0x0603B13B RID: 241979 RVA: 0x00EF344E File Offset: 0x00EF164E
		public void SetExploreFriendDataList(List<IRewardExploreFriendData> exploreFriendDataList)
		{
			if (this.CurrentRewardData() == null)
			{
				this.NewRewardData<IRewardInfo>(false);
			}
			this.CurrentRewardData().SetExploreFriendDataList(exploreFriendDataList);
		}

		// Token: 0x0603B13C RID: 241980 RVA: 0x00EF346C File Offset: 0x00EF166C
		public void SetButtonList(List<IRewardExploreConfirmButton> rewardButtonList)
		{
			if (this.CurrentRewardData() == null)
			{
				this.NewRewardData<IRewardInfo>(false);
			}
			if (rewardButtonList == null || rewardButtonList.Count < 1)
			{
				return;
			}
			this.CurrentRewardData().SetButtonInfoList(rewardButtonList);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshRewardButton);
		}

		// Token: 0x0603B13D RID: 241981 RVA: 0x00EF34A8 File Offset: 0x00EF16A8
		public RewardData<T> NewRewardData<[Nullable(0)] T>(bool inheritData = false) where T : IRewardInfo
		{
			if (this.CurrentRewardDataInternal != null)
			{
				RewardData<T> rewardData = this.CurrentRewardDataInternal as RewardData<T>;
				if (rewardData != null)
				{
					return rewardData;
				}
			}
			RewardData<T> rewardData2 = new RewardData<T>(default(T), null);
			if (inheritData)
			{
				rewardData2.InheritData(this.CurrentRewardDataInternal);
			}
			this.CurrentRewardDataInternal = rewardData2;
			return rewardData2;
		}

		// Token: 0x0603B13E RID: 241982 RVA: 0x00EF34F6 File Offset: 0x00EF16F6
		public void ClearCurrentRewardData()
		{
			this.CurrentRewardDataInternal = null;
		}

		// Token: 0x0603B13F RID: 241983 RVA: 0x00EF34FF File Offset: 0x00EF16FF
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public RewardData<IRewardInfo> GetCurrentRewardData()
		{
			return this.CurrentRewardData<IRewardInfo>();
		}

		// Token: 0x04021532 RID: 136498
		[Nullable(2)]
		private IRewardDataInterface CurrentRewardDataInternal;

		// Token: 0x04021533 RID: 136499
		public int? CurrentReasonId;

		// Token: 0x04021534 RID: 136500
		public List<RewardData<ICommonRewardInfo>> CacheCommonRewardDataList = new List<RewardData<ICommonRewardInfo>>();
	}
}
