using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x0200160B RID: 5643
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class VersionPreheatModel : ModelBase<VersionPreheatModel>
{
	// Token: 0x06009F87 RID: 40839 RVA: 0x0029AD1C File Offset: 0x00298F1C
	protected override bool OnInit()
	{
		this.ActivityContext = new VersionPreheatActivityContext();
		this.ConfigContext = new VersionPreheatConfigContext();
		return true;
	}

	// Token: 0x06009F88 RID: 40840 RVA: 0x0029AD35 File Offset: 0x00298F35
	protected override bool OnClear()
	{
		this.ActivityContext.Dispose();
		return true;
	}

	// Token: 0x17000D79 RID: 3449
	// (get) Token: 0x06009F89 RID: 40841 RVA: 0x0029AD43 File Offset: 0x00298F43
	public VersionPreheatActivityContext ActivityData
	{
		get
		{
			return this.ActivityContext;
		}
	}

	// Token: 0x17000D7A RID: 3450
	// (get) Token: 0x06009F8A RID: 40842 RVA: 0x0029AD4C File Offset: 0x00298F4C
	public bool IsBonusAvailable
	{
		get
		{
			if (this.ActivityContext.QuestCache.Count == 0)
			{
				return false;
			}
			foreach (VersionPreheatQuestInfoCache versionPreheatQuestInfoCache in this.ActivityContext.QuestCache.Values)
			{
				if (this.GetQuestStateById(versionPreheatQuestInfoCache.Id) != EVersionPreheatQuestState.QuestCompleted)
				{
					return false;
				}
			}
			return true;
		}
	}

	// Token: 0x17000D7B RID: 3451
	// (get) Token: 0x06009F8B RID: 40843 RVA: 0x0029ADCC File Offset: 0x00298FCC
	public bool HasNewQuest
	{
		get
		{
			if (this.IsBonusAvailable && !this.IsBonusClicked())
			{
				return true;
			}
			foreach (PreheatSignRe preheatSignRe in this.ConfigContext.AllQuestCfg)
			{
				VersionPreheatQuestInfoCache versionPreheatQuestInfoCache;
				if (this.ActivityContext.QuestCache.TryGetValue(preheatSignRe.Id, out versionPreheatQuestInfoCache) && this.GetQuestStateById(preheatSignRe.Id) != EVersionPreheatQuestState.Lock && !this.IsQuestClickedById(preheatSignRe.Id))
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x06009F8C RID: 40844 RVA: 0x0029AE6C File Offset: 0x0029906C
	public void SyncPreheatSignSurveyInfo(int id, PreheatSignSurveyInfo info)
	{
		this.ActivityContext.SyncPreheatSignSurveyInfo(id, info);
	}

	// Token: 0x06009F8D RID: 40845 RVA: 0x0029AE7B File Offset: 0x0029907B
	public void SyncPreheatRewardedState(int id)
	{
		this.ActivityContext.SyncPreheatRewardedState(id);
	}

	// Token: 0x06009F8E RID: 40846 RVA: 0x0029AE89 File Offset: 0x00299089
	public int GetQuestIdById(int id)
	{
		return this.ConfigContext.GetQuestIdById(id);
	}

	// Token: 0x06009F8F RID: 40847 RVA: 0x0029AE98 File Offset: 0x00299098
	public EVersionPreheatQuestState GetQuestStateById(int id)
	{
		VersionPreheatQuestInfoCache cache;
		if (this.ActivityContext.QuestCache.TryGetValue(id, out cache))
		{
			return this.GetQuestStateByQuestInfo(cache);
		}
		return EVersionPreheatQuestState.Lock;
	}

	// Token: 0x06009F90 RID: 40848 RVA: 0x0029AEC4 File Offset: 0x002990C4
	public List<VersionPreheatQuestData> BuildQuestDataList()
	{
		List<VersionPreheatQuestData> list = new List<VersionPreheatQuestData>();
		foreach (KeyValuePair<int, VersionPreheatQuestInfoCache> keyValuePair in this.ActivityContext.QuestCache)
		{
			int key = keyValuePair.Key;
			VersionPreheatQuestInfoCache value = keyValuePair.Value;
			VersionPreheatQuestData item = new VersionPreheatQuestData
			{
				Id = key,
				State = this.GetQuestStateByQuestInfo(value),
				NumberTextId = "Preheating_Serial_Number",
				NumberTextArg = key.ToString().PadLeft(2, '0'),
				TitleTextId = this.ConfigContext.GetQuestTitleTextIdById(key),
				UnlockTimestamp = value.UnlockTimestamp
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06009F91 RID: 40849 RVA: 0x0029AF94 File Offset: 0x00299194
	public VersionPreheatActivityInfoData BuildActivityInfoData()
	{
		Activity? localConfig = this.ActivityContext.LocalConfig;
		VersionPreheatActivityInfoData versionPreheatActivityInfoData = new VersionPreheatActivityInfoData();
		versionPreheatActivityInfoData.TitleData = new VersionPreheatActivityTitleData
		{
			TitleTextId = (((localConfig != null) ? localConfig.GetValueOrDefault().Title : null) ?? ""),
			SubTitleTextId = (((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null) ?? "")
		};
		VersionPreheatActivityDescriptionData versionPreheatActivityDescriptionData = new VersionPreheatActivityDescriptionData();
		VersionPreheatActivityContext activityContext = this.ActivityContext;
		versionPreheatActivityDescriptionData.ContentTextId = (((activityContext.LocalConfig != null) ? activityContext.LocalConfig.GetValueOrDefault().Desc : null) ?? "");
		versionPreheatActivityInfoData.DescriptionData = versionPreheatActivityDescriptionData;
		versionPreheatActivityInfoData.RewardData = new VersionPreheatActivityRewardData
		{
			TitleId = "CollectActivity_reward",
			RewardList = this.ActivityContext.GetPreviewReward(null)
		};
		versionPreheatActivityInfoData.BottomData = new VersionPreheatActivityBottomData
		{
			Test = true
		};
		return versionPreheatActivityInfoData;
	}

	// Token: 0x06009F92 RID: 40850 RVA: 0x0029B091 File Offset: 0x00299291
	public VersionPreheatBonusData BuildBonusQuestData()
	{
		return new VersionPreheatBonusData
		{
			NumberTextId = "Preheating_Serial_Number",
			NumberTextArg = "7",
			ContentTextId = this.ConfigContext.BonusQuestContentTextId
		};
	}

	// Token: 0x06009F93 RID: 40851 RVA: 0x0029B0C0 File Offset: 0x002992C0
	public VersionPreheatQuestDetailData BuildQuestDetailDataById(int id)
	{
		EVersionPreheatQuestState questStateById = this.GetQuestStateById(id);
		VersionPreheatQuestDetailVoteData voteData = null;
		if (questStateById >= EVersionPreheatQuestState.AfterVote)
		{
			voteData = this.BuildQuestDetailVoteDataById(id);
		}
		VersionPreheatQuestDetailChatData chatData = null;
		if (questStateById == EVersionPreheatQuestState.QuestCompleted)
		{
			chatData = this.BuildQuestDetailChatDataById(id, questStateById);
		}
		VersionPreheatQuestDetailRewardData rewardData = null;
		if (questStateById > EVersionPreheatQuestState.Lock && questStateById <= EVersionPreheatQuestState.AfterVote)
		{
			rewardData = this.BuildQuestDetailRewardDataById(id, questStateById);
		}
		return new VersionPreheatQuestDetailData
		{
			PersistentData = this.BuildQuestDetailPersistentDataById(id),
			VoteData = voteData,
			ChatData = chatData,
			RewardData = rewardData
		};
	}

	// Token: 0x06009F94 RID: 40852 RVA: 0x0029B12C File Offset: 0x0029932C
	public VersionPreheatQuestDetailData BuildBonusDetailData()
	{
		return new VersionPreheatQuestDetailData
		{
			PersistentData = new VersionPreheatQuestDetailPersistentData
			{
				Index = 6,
				QuestPhotoPath = this.ConfigContext.BonusPhotoPath,
				QuestTitleTextId = this.ConfigContext.BonusQuestTitleTextId,
				QuestContentTextId = this.ConfigContext.BonusQuestContentTextId,
				QuestCrestIndex = this.ConfigContext.BonusCrestIndex,
				QuestSharePhotoPath = this.ConfigContext.BonusSharePhotoPath,
				CanShare = false
			},
			ChatData = this.BuildBonusDetailChatData(),
			BonusTextId = this.ConfigContext.BonusTextId
		};
	}

	// Token: 0x06009F95 RID: 40853 RVA: 0x0029B1CC File Offset: 0x002993CC
	public VersionPreheatVoteData BuildVoteDataById(int id)
	{
		return new VersionPreheatVoteData
		{
			TitleTextId = this.ConfigContext.GetVoteTitleTextIdById(id),
			ContentTextId = this.ConfigContext.GetVoteContentTextIdById(id),
			CrestIndex = this.ConfigContext.GetQuestCrestIndexById(id),
			LeftToggleData = new VersionPreheatVoteToggleData
			{
				Id = id,
				ContentTextId = this.ConfigContext.GetVoteLeftTipsTextIdById(id),
				ClickFunc = new TVersionPreheatVoteClickFunc(ControllerBase<ActivityVersionPreheatController>.Instance.HandleVoteClickAsync),
				ClickPassData = true
			},
			RightToggleData = new VersionPreheatVoteToggleData
			{
				Id = id,
				ContentTextId = this.ConfigContext.GetVoteRightTipsTextIdById(id),
				ClickFunc = new TVersionPreheatVoteClickFunc(ControllerBase<ActivityVersionPreheatController>.Instance.HandleVoteClickAsync),
				ClickPassData = false
			},
			ItemListData = this.ConfigContext.GetQuestRewardItemListById(id),
			IsLeftChosen = this.ActivityContext.IsLeftChosen(id)
		};
	}

	// Token: 0x06009F96 RID: 40854 RVA: 0x0029B2BC File Offset: 0x002994BC
	private EVersionPreheatQuestState GetQuestStateByQuestInfo(VersionPreheatQuestInfoCache cache)
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() < (double)cache.UnlockTimestamp)
		{
			return EVersionPreheatQuestState.Lock;
		}
		int preIdById = this.ConfigContext.GetPreIdById(cache.Id);
		if (preIdById > 0)
		{
			VersionPreheatQuestInfoCache versionPreheatQuestInfoCache;
			if (!this.ActivityContext.QuestCache.TryGetValue(preIdById, out versionPreheatQuestInfoCache))
			{
				return EVersionPreheatQuestState.Lock;
			}
			if (!ControllerBase<ActivityVersionPreheatController>.Instance.IsQuestFinishedById(preIdById))
			{
				return EVersionPreheatQuestState.Lock;
			}
		}
		if (ControllerBase<ActivityVersionPreheatController>.Instance.IsQuestFinishedById(cache.Id))
		{
			return EVersionPreheatQuestState.QuestCompleted;
		}
		if (cache.Rewarded)
		{
			return EVersionPreheatQuestState.AfterVote;
		}
		return EVersionPreheatQuestState.BeforeVote;
	}

	// Token: 0x06009F97 RID: 40855 RVA: 0x0029B339 File Offset: 0x00299539
	public bool IsQuestClickedById(int id)
	{
		if (this.QuestClickedCache == null)
		{
			this.QuestClickedCache = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.VersionPreheatToQuestClicked, null);
		}
		Dictionary<int, bool> questClickedCache = this.QuestClickedCache;
		return questClickedCache != null && questClickedCache.GetValueOrDefault(id);
	}

	// Token: 0x06009F98 RID: 40856 RVA: 0x0029B364 File Offset: 0x00299564
	public void SetQuestClickedById(int id)
	{
		if (this.QuestClickedCache == null)
		{
			this.QuestClickedCache = new Dictionary<int, bool>();
		}
		this.QuestClickedCache[id] = true;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.VersionPreheatToQuestClicked, this.QuestClickedCache);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityContext.Id);
	}

	// Token: 0x06009F99 RID: 40857 RVA: 0x0029B3BA File Offset: 0x002995BA
	public bool IsQuestPlayedById(int id)
	{
		if (this.QuestPlayedCache == null)
		{
			this.QuestPlayedCache = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.VersionPreheatToQuestPlayed, null);
		}
		Dictionary<int, bool> questPlayedCache = this.QuestPlayedCache;
		return questPlayedCache != null && questPlayedCache.GetValueOrDefault(id);
	}

	// Token: 0x06009F9A RID: 40858 RVA: 0x0029B3E4 File Offset: 0x002995E4
	public void SetQuestPlayedById(int id)
	{
		if (this.QuestPlayedCache == null)
		{
			this.QuestPlayedCache = new Dictionary<int, bool>();
		}
		this.QuestPlayedCache[id] = true;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.VersionPreheatToQuestPlayed, this.QuestPlayedCache);
	}

	// Token: 0x06009F9B RID: 40859 RVA: 0x0029B414 File Offset: 0x00299614
	public bool IsBonusClicked()
	{
		if (this.BonusClickedCache == null)
		{
			this.BonusClickedCache = new bool?(LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.VersionPreheatBonusClicked, false));
		}
		return this.BonusClickedCache.GetValueOrDefault();
	}

	// Token: 0x06009F9C RID: 40860 RVA: 0x0029B444 File Offset: 0x00299644
	public void SetBonusClicked()
	{
		if (this.BonusClickedCache == null)
		{
			this.BonusClickedCache = new bool?(true);
		}
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.VersionPreheatBonusClicked, this.BonusClickedCache.Value);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityContext.Id);
	}

	// Token: 0x06009F9D RID: 40861 RVA: 0x0029B498 File Offset: 0x00299698
	public bool IsBonusPlayed()
	{
		if (this.BonusPlayedCache == null)
		{
			this.BonusPlayedCache = new bool?(LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.VersionPreheatBonusPlayed, false));
		}
		return this.BonusPlayedCache.GetValueOrDefault();
	}

	// Token: 0x06009F9E RID: 40862 RVA: 0x0029B4C5 File Offset: 0x002996C5
	public void SetBonusPlayed()
	{
		if (this.BonusPlayedCache == null)
		{
			this.BonusPlayedCache = new bool?(true);
		}
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.VersionPreheatBonusPlayed, this.BonusPlayedCache.Value);
	}

	// Token: 0x06009F9F RID: 40863 RVA: 0x0029B4F4 File Offset: 0x002996F4
	private VersionPreheatQuestDetailPersistentData BuildQuestDetailPersistentDataById(int id)
	{
		VersionPreheatConfigContext configContext = this.ConfigContext;
		bool flag = this.ActivityContext.IsRewardedById(id);
		return new VersionPreheatQuestDetailPersistentData
		{
			Index = id - 1,
			QuestPhotoPath = configContext.GetQuestPhotoPathById(id),
			QuestTitleTextId = configContext.GetQuestTitleTextIdById(id),
			QuestContentTextId = (flag ? configContext.GetQuestAfterThemeTextIdById(id) : configContext.GetQuestBeforeThemeTextIdById(id)),
			QuestCrestIndex = configContext.GetQuestCrestIndexById(id),
			QuestSharePhotoPath = configContext.GetQuestSharePhotoPathById(id),
			CanShare = (this.GetQuestStateById(id) == EVersionPreheatQuestState.QuestCompleted)
		};
	}

	// Token: 0x06009FA0 RID: 40864 RVA: 0x0029B580 File Offset: 0x00299780
	private VersionPreheatQuestDetailVoteData BuildQuestDetailVoteDataById(int id)
	{
		long voteLeftCountById = this.ActivityContext.GetVoteLeftCountById(id);
		long voteRightCountById = this.ActivityContext.GetVoteRightCountById(id);
		float num;
		float rightNormalized;
		if (voteLeftCountById == voteRightCountById)
		{
			num = 0.5f;
			rightNormalized = 0.5f;
		}
		else
		{
			num = (float)voteLeftCountById / (float)(voteLeftCountById + voteRightCountById);
			rightNormalized = (float)voteRightCountById / (float)(voteLeftCountById + voteRightCountById);
		}
		int num2 = (int)Math.Round((double)(num * 100f));
		int num3 = 100 - num2;
		return new VersionPreheatQuestDetailVoteData
		{
			LeftNormalized = num,
			RightNormalized = rightNormalized,
			LeftPercentageText = num2.ToString() + "%",
			RightPercentageText = num3.ToString() + "%",
			LeftThemeTextId = this.ConfigContext.GetVoteLeftThemeTextIdById(id),
			RightThemeTextId = this.ConfigContext.GetVoteRightThemeTextIdById(id),
			IsLeftChosen = this.ActivityContext.IsLeftChosen(id).GetValueOrDefault()
		};
	}

	// Token: 0x06009FA1 RID: 40865 RVA: 0x0029B66C File Offset: 0x0029986C
	private VersionPreheatQuestDetailChatData BuildQuestDetailChatDataById(int id, EVersionPreheatQuestState state)
	{
		VersionPreheatQuestDetailChatData selfChatData = this.BuildQuestDetailSelfChatDataById(id, state);
		return new VersionPreheatQuestDetailChatData
		{
			NpcContentTextId = this.ConfigContext.GetNpcContentTextIdById(id),
			NpcIconPath = this.ConfigContext.GetNpcIconPathById(id),
			SelfChatData = selfChatData
		};
	}

	// Token: 0x06009FA2 RID: 40866 RVA: 0x0029B6B2 File Offset: 0x002998B2
	private VersionPreheatQuestDetailChatData BuildBonusDetailChatData()
	{
		return new VersionPreheatQuestDetailChatData
		{
			NpcContentTextId = this.ConfigContext.BonusNpcContentTextId,
			NpcIconPath = this.ConfigContext.BonusNpcIconPath
		};
	}

	// Token: 0x06009FA3 RID: 40867 RVA: 0x0029B6DC File Offset: 0x002998DC
	[NullableContext(2)]
	private VersionPreheatQuestDetailChatData BuildQuestDetailSelfChatDataById(int id, EVersionPreheatQuestState state)
	{
		if (state < EVersionPreheatQuestState.AfterVote)
		{
			return null;
		}
		int id2 = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? 1501 : 1502;
		RoleInfo? roleInfo;
		return new VersionPreheatQuestDetailChatData
		{
			NpcIconPath = (((ConfigBase<RoleConfig>.Instance.GetRoleConfig(id2) != null) ? roleInfo.GetValueOrDefault().RoleHeadIconCircle : null) ?? ""),
			NpcContentTextId = this.ConfigContext.GetSelfChatContentTextIdById(id)
		};
	}

	// Token: 0x06009FA4 RID: 40868 RVA: 0x0029B758 File Offset: 0x00299958
	private VersionPreheatQuestDetailRewardData BuildQuestDetailRewardDataById(int id, EVersionPreheatQuestState state)
	{
		return new VersionPreheatQuestDetailRewardData
		{
			QuestContentTextId = this.ConfigContext.GetQuestContentTextIdById(id),
			ItemListData = this.ConfigContext.GetQuestRewardItemListById(id),
			IsReceived = (state == EVersionPreheatQuestState.AfterVote),
			ClickFunc = new TVersionPreheatQuestDetailClickFunc(ControllerBase<ActivityVersionPreheatController>.Instance.HandleQuestDetailClickInReward),
			ClickPassData = this.ConfigContext.GetQuestIdById(id)
		};
	}

	// Token: 0x0400490A RID: 18698
	public int? CurrentUsingVersionPreheatId;

	// Token: 0x0400490B RID: 18699
	[Nullable(2)]
	private Dictionary<int, bool> QuestClickedCache;

	// Token: 0x0400490C RID: 18700
	private bool? BonusClickedCache;

	// Token: 0x0400490D RID: 18701
	[Nullable(2)]
	private Dictionary<int, bool> QuestPlayedCache;

	// Token: 0x0400490E RID: 18702
	private bool? BonusPlayedCache;

	// Token: 0x0400490F RID: 18703
	private VersionPreheatActivityContext ActivityContext;

	// Token: 0x04004910 RID: 18704
	private VersionPreheatConfigContext ConfigContext;
}
