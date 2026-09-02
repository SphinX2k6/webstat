using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020014F3 RID: 5363
[NullableContext(1)]
[Nullable(0)]
internal class ActivityRegressRecommendItem : GridProxyAbstract<int>
{
	// Token: 0x06009605 RID: 38405 RVA: 0x00272660 File Offset: 0x00270860
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUISprite)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickJumpBtn)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickPreOpenBtnBtn))
		};
	}

	// Token: 0x06009606 RID: 38406 RVA: 0x00272805 File Offset: 0x00270A05
	protected override void OnStart()
	{
		this.RemainTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(9), new Func<CommonItemSmallItemGrid>(this.InitRewardItem), null, false, true);
	}

	// Token: 0x06009607 RID: 38407 RVA: 0x0027283A File Offset: 0x00270A3A
	private CommonItemSmallItemGrid InitRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06009608 RID: 38408 RVA: 0x00272844 File Offset: 0x00270A44
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		RegressRecommend? regressRecommend = ConfigBase<ActivityRegressConfig>.Instance.GetRegressRecommend(data);
		if (regressRecommend == null)
		{
			return;
		}
		this.RegressRecommendId = data;
		this.RecommendType = (ERegressRecommendType)regressRecommend.Value.Type;
		this.JumpParam = regressRecommend.Value.JumpParam;
		switch (this.RecommendType)
		{
		case ERegressRecommendType.MainQuest:
			this.RefreshItemByQuest();
			return;
		case ERegressRecommendType.TimeLimitActivity:
			this.RefreshItemByTimeLimitActivity();
			return;
		case ERegressRecommendType.NormalActivity:
			this.RefreshItemByNormalActivity();
			return;
		case ERegressRecommendType.Area:
			this.RefreshItemByArea();
			return;
		default:
			return;
		}
	}

	// Token: 0x06009609 RID: 38409 RVA: 0x002728D4 File Offset: 0x00270AD4
	private void RefreshItemByQuest()
	{
		RegressRecommend? regressRecommend = ConfigBase<ActivityRegressConfig>.Instance.GetRegressRecommend(this.RegressRecommendId);
		if (regressRecommend == null)
		{
			return;
		}
		base.GetTexture(2).SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Regress_MainQuest");
		this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, delegate(bool _)
		{
			base.GetSprite(1).SetUIActive(true);
		});
		int currentMainLineQuest = ModelBase<ActivityRegressModel>.Instance.GetCurrentMainLineQuest();
		this.MainQuestId = currentMainLineQuest;
		if (currentMainLineQuest == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Recall_Main_Task_Finish", Array.Empty<object>());
			base.GetText(4).SetUIActive(false);
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout != null)
			{
				UUIItem rootUiItem = rewardLayout.GetRootUiItem();
				if (rootUiItem != null)
				{
					rootUiItem.SetUIActive(false);
				}
			}
			UUIItem uuiitem = base.GetButton(11).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(false);
			}
			UUIItem uuiitem2 = base.GetButton(12).RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(false);
			}
			base.GetItem(13).SetUIActive(false);
			base.GetItem(14).SetUIActive(false);
			return;
		}
		base.GetItem(14).SetUIActive(true);
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(currentMainLineQuest);
		List<TItem> dropPreviewRewardItemListForPreview = ModelBase<ActivityRegressModel>.Instance.GetDropPreviewRewardItemListForPreview(quest.RewardId.Value);
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout2 = this.RewardLayout;
		if (rewardLayout2 != null)
		{
			rewardLayout2.RefreshByData(dropPreviewRewardItemListForPreview, null, false);
		}
		QuestChapter? chapterConfig = ConfigBase<QuestNewConfig>.Instance.GetChapterConfig(quest.ChapterId.Value);
		string newText = ConfigMultiTextLang.GetLocalTextNew(chapterConfig.Value.ChapterName, null) ?? "";
		base.GetText(3).SetText(newText, true);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(chapterConfig.Value.ChapterNum, null);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(chapterConfig.Value.SectionNum, null);
		base.GetText(4).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "QuestChapterText", new <>z__ReadOnlyArray<object>(new object[]
		{
			localTextNew,
			localTextNew2
		}));
		bool flag = this.RecommendType == ERegressRecommendType.MainQuest && regressRecommend.Value.JumpParam != 0 && ModelBase<ActivityModel>.Instance.IsActivityOpen(regressRecommend.Value.JumpParam);
		if (ModelBase<ActivityRegressModel>.Instance.GetCurrentMainLineBranch() < (ERegressBranchNumber)ModelBase<ActivityRegressModel>.Instance.LatestBranch && flag)
		{
			UUIItem uuiitem3 = base.GetButton(11).RootUIComp.Get();
			if (uuiitem3 != null)
			{
				uuiitem3.SetUIActive(false);
			}
			UUIItem uuiitem4 = base.GetButton(12).RootUIComp.Get();
			if (uuiitem4 == null)
			{
				return;
			}
			uuiitem4.SetUIActive(true);
			return;
		}
		else
		{
			UUIItem uuiitem5 = base.GetButton(11).RootUIComp.Get();
			if (uuiitem5 != null)
			{
				uuiitem5.SetUIActive(true);
			}
			UUIItem uuiitem6 = base.GetButton(12).RootUIComp.Get();
			if (uuiitem6 == null)
			{
				return;
			}
			uuiitem6.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600960A RID: 38410 RVA: 0x00272BE8 File Offset: 0x00270DE8
	private void RefreshItemByTimeLimitActivity()
	{
		RegressRecommend? regressRecommend = ConfigBase<ActivityRegressConfig>.Instance.GetRegressRecommend(this.RegressRecommendId);
		if (regressRecommend == null)
		{
			return;
		}
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(this.JumpParam);
		base.GetSprite(1).SetUIActive(false);
		this.RefreshActivityIcon(activityById);
		base.GetItem(5).SetUIActive(true);
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(activityById.EndShowTime, this.RemainTimeText);
		base.GetText(8).SetColor(ActivityRegressColors.RegressYellowColor.Value);
		base.GetText(8).SetText(remainTimeText, true);
		this.SetTagIconByActivityConfig(activityById);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_OverViewBgA");
		this.SetSpriteByPath(resourcePath, base.GetSprite(6), false, null, null);
		base.GetItem(13).SetUIActive(false);
		UUIItem uuiitem = base.GetButton(12).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(false);
		}
		UUIItem uuiitem2 = base.GetButton(11).RootUIComp.Get();
		if (uuiitem2 != null)
		{
			uuiitem2.SetUIActive(true);
		}
		this.SetTitleByActivityConfig(activityById);
		base.GetText(4).SetUIActive(false);
		List<TItem> dropPreviewRewardItemListForPreview = ModelBase<ActivityRegressModel>.Instance.GetDropPreviewRewardItemListForPreview(regressRecommend.Value.ShowReward);
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(dropPreviewRewardItemListForPreview, null, false);
	}

	// Token: 0x0600960B RID: 38411 RVA: 0x00272D44 File Offset: 0x00270F44
	private void RefreshActivityIcon(ActivityBaseData activityData)
	{
		string[] array = activityData.LocalConfig.Value.TabTexture();
		UUITexture texture = base.GetTexture(2);
		texture.SetUIActive(false);
		if (array == null || array.Length == 0)
		{
			return;
		}
		int num = 0;
		if (array.Length >= 2)
		{
			num = ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() > EPlayerGender.Female) ? 1 : 0);
		}
		base.SetTextureByPath(array[num], texture, null, delegate(bool _)
		{
			texture.SetUIActive(true);
		});
	}

	// Token: 0x0600960C RID: 38412 RVA: 0x00272DC8 File Offset: 0x00270FC8
	private void SetTagIconByActivityConfig(ActivityBaseData activityData)
	{
		Activity? localConfig = activityData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		UUISprite sprite = base.GetSprite(7);
		if (localConfig.Value.GetShowActTypeIdsArray().Length < 1)
		{
			sprite.SetUIActive(false);
			return;
		}
		sprite.SetUIActive(true);
		ActivityTitleTags? activityTitleTags = ConfigBase<ActivityConfig>.Instance.GetActivityTitleTags(localConfig.Value.GetShowActTypeIdsArray()[0]);
		if (activityTitleTags == null)
		{
			return;
		}
		string togIcon = activityTitleTags.Value.TogIcon;
		this.SetSpriteByPath(togIcon, sprite, false, null, null);
		sprite.SetColor(ActivityRegressColors.RegressYellowColor.Value);
	}

	// Token: 0x0600960D RID: 38413 RVA: 0x00272E74 File Offset: 0x00271074
	private void SetTitleByActivityConfig(ActivityBaseData activityData)
	{
		Activity? localConfig = activityData.LocalConfig;
		if (localConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), localConfig.Value.Title, Array.Empty<object>());
	}

	// Token: 0x0600960E RID: 38414 RVA: 0x00272EB8 File Offset: 0x002710B8
	private void RefreshItemByNormalActivity()
	{
		RegressRecommend? regressRecommend = ConfigBase<ActivityRegressConfig>.Instance.GetRegressRecommend(this.RegressRecommendId);
		if (regressRecommend == null)
		{
			return;
		}
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(this.JumpParam);
		base.GetSprite(1).SetUIActive(false);
		this.RefreshActivityIcon(activityById);
		base.GetItem(5).SetUIActive(true);
		this.SetTagIconByActivityConfig(activityById);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_OverViewBgA");
		this.SetSpriteByPath(resourcePath, base.GetSprite(6), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Regress_Recommend_Tag_NormalActivity", Array.Empty<object>());
		UUIItem uuiitem = base.GetButton(12).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(false);
		}
		ActivityBaseData activityById2 = ModelBase<ActivityModel>.Instance.GetActivityById(this.JumpParam);
		bool flag = activityById2 != null && activityById2.FinishShowState;
		base.GetItem(13).SetUIActive(flag);
		UUIItem uuiitem2 = base.GetButton(11).RootUIComp.Get();
		if (uuiitem2 != null)
		{
			uuiitem2.SetUIActive(!flag);
		}
		this.SetTitleByActivityConfig(activityById);
		base.GetText(4).SetUIActive(false);
		List<TItem> dropPreviewRewardItemListForPreview = ModelBase<ActivityRegressModel>.Instance.GetDropPreviewRewardItemListForPreview(regressRecommend.Value.ShowReward);
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(dropPreviewRewardItemListForPreview, null, false);
	}

	// Token: 0x0600960F RID: 38415 RVA: 0x00273014 File Offset: 0x00271214
	private void RefreshItemByArea()
	{
		RegressRecommend? regressRecommend = ConfigBase<ActivityRegressConfig>.Instance.GetRegressRecommend(this.RegressRecommendId);
		if (regressRecommend == null)
		{
			return;
		}
		ExploreAreaData firstUnlockArea = ControllerBase<ActivityRegressController>.Instance.GetFirstUnlockArea();
		if (firstUnlockArea == null)
		{
			return;
		}
		base.GetTexture(2).SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Regress_Area");
		this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, delegate(bool _)
		{
			base.GetSprite(1).SetUIActive(true);
		});
		base.GetItem(5).SetUIActive(true);
		string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Regress_Tag_Area");
		UUISprite sprite = base.GetSprite(7);
		this.SetSpriteByPath(resourcePath2, sprite, false, null, null);
		sprite.SetColor(ActivityRegressColors.RegressBlueColor.Value);
		string resourcePath3 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_OverViewBgB");
		this.SetSpriteByPath(resourcePath3, base.GetSprite(6), false, null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Regress_Recommend_Tag_Area", new <>z__ReadOnlySingleElementList<object>(firstUnlockArea.GetProgress().ToString() + "%"));
		base.GetText(8).SetColor(ActivityRegressColors.RegressBlueColor.Value);
		UUIItem uuiitem = base.GetButton(12).RootUIComp.Get();
		if (uuiitem != null)
		{
			uuiitem.SetUIActive(false);
		}
		bool isReachMaxProgress = firstUnlockArea.IsReachMaxProgress;
		base.GetItem(13).SetUIActive(isReachMaxProgress);
		UUIItem uuiitem2 = base.GetButton(11).RootUIComp.Get();
		if (uuiitem2 != null)
		{
			uuiitem2.SetUIActive(!isReachMaxProgress);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), firstUnlockArea.GetNameId(), Array.Empty<object>());
		base.GetText(4).SetUIActive(false);
		List<TItem> dropPreviewRewardItemListForPreview = ModelBase<ActivityRegressModel>.Instance.GetDropPreviewRewardItemListForPreview(regressRecommend.Value.ShowReward);
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(dropPreviewRewardItemListForPreview, delegate
		{
			List<CommonItemSmallItemGrid> layoutItemList = this.RewardLayout.GetLayoutItemList();
			if (layoutItemList != null)
			{
				for (int i = 0; i < layoutItemList.Count; i++)
				{
					layoutItemList[i].SetBottomTextVisible(false);
				}
			}
		}, false);
	}

	// Token: 0x06009610 RID: 38416 RVA: 0x00273220 File Offset: 0x00271420
	private void OnClickJumpBtn()
	{
		switch (this.RecommendType)
		{
		case ERegressRecommendType.MainQuest:
			ActivityRegressHelper.ReportRecallLog1024New(EReportLogEventNewType.Recommend, this.MainQuestId, 0);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.MainQuestId, null);
			return;
		case ERegressRecommendType.TimeLimitActivity:
		case ERegressRecommendType.NormalActivity:
			ActivityRegressHelper.ReportRecallLog1024New(EReportLogEventNewType.Recommend, this.JumpParam, 0);
			this.OpenActivity();
			return;
		case ERegressRecommendType.Area:
		{
			ExploreAreaData firstUnlockArea = ControllerBase<ActivityRegressController>.Instance.GetFirstUnlockArea();
			ActivityRegressHelper.ReportRecallLog1024New(EReportLogEventNewType.Recommend, (firstUnlockArea != null) ? firstUnlockArea.AreaId : 0, 0);
			ControllerBase<ActivityRegressController>.Instance.ExploreJump();
			return;
		}
		default:
			return;
		}
	}

	// Token: 0x06009611 RID: 38417 RVA: 0x002732B3 File Offset: 0x002714B3
	private void OnClickPreOpenBtnBtn()
	{
		this.OpenActivity();
	}

	// Token: 0x06009612 RID: 38418 RVA: 0x002732BB File Offset: 0x002714BB
	private void OpenActivity()
	{
		ActivityRegressController.RegressStartJumpToActivity(delegate
		{
			ControllerBase<ActivityController>.Instance.OpenActivityById(this.JumpParam, EActivityViewOpenType.Other, null, null);
		});
	}

	// Token: 0x04004583 RID: 17795
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04004584 RID: 17796
	private int RegressRecommendId;

	// Token: 0x04004585 RID: 17797
	private int JumpParam;

	// Token: 0x04004586 RID: 17798
	private int MainQuestId;

	// Token: 0x04004587 RID: 17799
	private ERegressRecommendType RecommendType = ERegressRecommendType.Area;

	// Token: 0x04004588 RID: 17800
	private string RemainTimeText = "";
}
