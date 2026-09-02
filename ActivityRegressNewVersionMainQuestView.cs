using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020014F4 RID: 5364
public class ActivityRegressNewVersionMainQuestView : ActivityRegressMainSubViewBase
{
	// Token: 0x06009618 RID: 38424 RVA: 0x00273358 File Offset: 0x00271558
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickJumpToQuestBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickJumpToActivityBtn))
		};
	}

	// Token: 0x06009619 RID: 38425 RVA: 0x00273488 File Offset: 0x00271688
	protected override void OnStart()
	{
		base.OnStart();
		RegressBase? latestRegressBase = ModelBase<ActivityRegressModel>.Instance.GetLatestRegressBase();
		if (latestRegressBase == null)
		{
			return;
		}
		RegressBase value = latestRegressBase.Value;
		int currentMainLineQuest = ModelBase<ActivityRegressModel>.Instance.GetCurrentMainLineQuest();
		this.IsFinishRecommendQuest = (currentMainLineQuest == 0);
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(3), new Func<CommonItemSmallItemGrid>(this.OnInitItem), null, false, null);
		List<TItem> dropPreviewRewardItemListForPreview = ModelBase<ActivityRegressModel>.Instance.GetDropPreviewRewardItemListForPreview(value.RewardPreview);
		this.RewardScrollView.RefreshByData(dropPreviewRewardItemListForPreview, null, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Description, Array.Empty<object>());
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		base.SetTextureByPath((playerGender == EPlayerGender.Male) ? value.BgPath : value.BgPathF, base.GetTexture(9), null, null);
		if (this.IsFinishRecommendQuest)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Recall_Main_Task_Finish", Array.Empty<object>());
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
			base.GetItem(8).SetUIActive(true);
			return;
		}
		this.TargetActivityId = value.TargetActivityId;
		bool flag = this.TargetActivityId != 0 && ModelBase<ActivityModel>.Instance.IsActivityOpen(value.TargetActivityId);
		if (ModelBase<ActivityRegressModel>.Instance.GetCurrentMainLineBranch() < (ERegressBranchNumber)ModelBase<ActivityRegressModel>.Instance.LatestBranch && flag)
		{
			base.GetButton(5).RootUIComp.Get().SetUIActive(false);
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), value.JumpBtnDes, Array.Empty<object>());
		}
		else
		{
			base.GetButton(5).RootUIComp.Get().SetUIActive(true);
			base.GetButton(6).RootUIComp.Get().SetUIActive(false);
		}
		this.TargetQuestId = currentMainLineQuest;
		base.GetItem(8).SetUIActive(false);
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(currentMainLineQuest);
		if (quest == null)
		{
			return;
		}
		QuestChapter? chapterConfig = ConfigBase<QuestNewConfig>.Instance.GetChapterConfig(quest.ChapterId.Value);
		if (chapterConfig == null)
		{
			return;
		}
		QuestChapter value2 = chapterConfig.Value;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(value2.ChapterNum, null);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(value2.SectionNum, null);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "QuestChapterText", new <>z__ReadOnlyArray<object>(new object[]
		{
			localTextNew,
			localTextNew2
		}));
	}

	// Token: 0x0600961A RID: 38426 RVA: 0x00273775 File Offset: 0x00271975
	[NullableContext(1)]
	private CommonItemSmallItemGrid OnInitItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600961B RID: 38427 RVA: 0x0027377C File Offset: 0x0027197C
	private void OnClickJumpToQuestBtn()
	{
		if (this.TargetQuestId == 0)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.TargetQuestId, null);
	}

	// Token: 0x0600961C RID: 38428 RVA: 0x002737A2 File Offset: 0x002719A2
	private void OnClickJumpToActivityBtn()
	{
		if (this.TargetActivityId == 0)
		{
			return;
		}
		ActivityRegressController.RegressStartJumpToActivity(delegate
		{
			ControllerBase<ActivityController>.Instance.OpenActivityById(this.TargetActivityId, EActivityViewOpenType.Other, null, null);
		});
	}

	// Token: 0x04004589 RID: 17801
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x0400458A RID: 17802
	private bool IsFinishRecommendQuest;

	// Token: 0x0400458B RID: 17803
	private int TargetQuestId;

	// Token: 0x0400458C RID: 17804
	private int TargetActivityId;

	// Token: 0x020078AE RID: 30894
	private class EComponents
	{
		// Token: 0x040297BF RID: 169919
		public const int QuestTitleText = 0;

		// Token: 0x040297C0 RID: 169920
		public const int QuestSubTitleText = 1;

		// Token: 0x040297C1 RID: 169921
		public const int QuestDesText = 2;

		// Token: 0x040297C2 RID: 169922
		public const int RewardScrollView = 3;

		// Token: 0x040297C3 RID: 169923
		public const int CurrentQuestSubTitleText = 4;

		// Token: 0x040297C4 RID: 169924
		public const int JumpToQuestViewBtn = 5;

		// Token: 0x040297C5 RID: 169925
		public const int JumpToActivityBtn = 6;

		// Token: 0x040297C6 RID: 169926
		public const int JumpToQuestViewBtnText = 7;

		// Token: 0x040297C7 RID: 169927
		public const int DownItem = 8;

		// Token: 0x040297C8 RID: 169928
		public const int BgTexture = 9;
	}
}
