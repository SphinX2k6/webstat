using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001454 RID: 5204
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewNewcomerJourney : ActivitySubViewBase
{
	// Token: 0x06009111 RID: 37137 RVA: 0x00262AF0 File Offset: 0x00260CF0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 25;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ClickGetCharacterBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.ClickGetBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.ClickPreviewBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009112 RID: 37138 RVA: 0x00262EE6 File Offset: 0x002610E6
	private void ClickGetCharacterBtn()
	{
		if (this.ActivityDataBase == null)
		{
			return;
		}
		if (!this.ActivityDataBase.GetCanGetCharacter())
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.NewcomerJourneyChoseRoleView, null, delegate(bool success, int viewId)
		{
			base.AddChild(Singleton<UiManager>.Instance.GetView(viewId));
		});
	}

	// Token: 0x06009113 RID: 37139 RVA: 0x00262F1C File Offset: 0x0026111C
	private void ClickGetBtn()
	{
		if (this.ActivityDataBase == null || this.SelectChapterConfig == null)
		{
			return;
		}
		if (!this.ActivityDataBase.GetChapterCanGetReward(this.SelectChapterConfig.Value.Id))
		{
			return;
		}
		ControllerBase<ActivityNewcomerJourneyController>.Instance.GetChapterReward(this.ActivityDataBase.Id, this.SelectChapterConfig.Value.Id);
		this.IsSendGetReward = true;
	}

	// Token: 0x06009114 RID: 37140 RVA: 0x00262F90 File Offset: 0x00261190
	private void ClickPreviewBtn()
	{
		if (this.ActivityDataBase == null)
		{
			return;
		}
		List<int> previewCharacterList = this.ActivityDataBase.GetPreviewCharacterList();
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, previewCharacterList, null, null);
	}

	// Token: 0x06009115 RID: 37141 RVA: 0x00262FC9 File Offset: 0x002611C9
	protected override void OnSetData()
	{
		this.ActivityDataBase = (this.ActivityBaseData as ActivityNewcomerJourneyData);
	}

	// Token: 0x06009116 RID: 37142 RVA: 0x00262FDC File Offset: 0x002611DC
	private NewcomerJourneyTabItem CreateTabItem()
	{
		NewcomerJourneyTabItem newcomerJourneyTabItem = new NewcomerJourneyTabItem();
		newcomerJourneyTabItem.SetActivityData(this.ActivityDataBase);
		newcomerJourneyTabItem.SetBtnClickCallback(new Action<AdventureTaskChapterV2, int>(this.OnClickTab));
		return newcomerJourneyTabItem;
	}

	// Token: 0x06009117 RID: 37143 RVA: 0x00263001 File Offset: 0x00261201
	private void OnClickTab(AdventureTaskChapterV2 chapterConfig, int gridIndex)
	{
		this.SelectChapterConfig = new AdventureTaskChapterV2?(chapterConfig);
		GenericScrollViewNew<NewcomerJourneyTabItem, AdventureTaskChapterV2> tabLayout = this.TabLayout;
		if (tabLayout != null)
		{
			GenericLayout<NewcomerJourneyTabItem, AdventureTaskChapterV2> genericLayout = tabLayout.GetGenericLayout();
			if (genericLayout != null)
			{
				genericLayout.SelectGridProxy(gridIndex, false);
			}
		}
		this.RefreshSelectChapterView(true);
	}

	// Token: 0x06009118 RID: 37144 RVA: 0x00263034 File Offset: 0x00261234
	private NewcomerJourneyTaskItem CreateTaskItem()
	{
		NewcomerJourneyTaskItem newcomerJourneyTaskItem = new NewcomerJourneyTaskItem();
		newcomerJourneyTaskItem.SetActivityData(this.ActivityDataBase);
		return newcomerJourneyTaskItem;
	}

	// Token: 0x06009119 RID: 37145 RVA: 0x00263047 File Offset: 0x00261247
	private CommonItemSmallItemGrid CreateRewardItem()
	{
		return new CommonItemSmallItemGrid
		{
			ShowReceivedCallBack = delegate(TItem data)
			{
				if (this.ActivityDataBase == null || this.SelectChapterConfig == null)
				{
					return false;
				}
				int id = this.SelectChapterConfig.Value.Id;
				return this.ActivityDataBase.GetChapterRewardHasGet(id);
			}
		};
	}

	// Token: 0x0600911A RID: 37146 RVA: 0x00263060 File Offset: 0x00261260
	private void RefreshGetCharacterView()
	{
		bool characterHasGet = this.ActivityDataBase.GetCharacterHasGet();
		bool canGetCharacter = this.ActivityDataBase.GetCanGetCharacter();
		base.GetItem(24).SetUIActive(canGetCharacter);
		base.GetItem(13).SetUIActive(canGetCharacter);
		UUIButtonComponent button = base.GetButton(0);
		if (button != null)
		{
			button.SetSelfInteractive(canGetCharacter);
		}
		base.GetItem(23).SetUIActive(!characterHasGet && !canGetCharacter);
		base.GetItem(20).SetUIActive(characterHasGet);
		this.SetRewardBgTexture();
	}

	// Token: 0x0600911B RID: 37147 RVA: 0x002630E0 File Offset: 0x002612E0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewNewcomerJourney.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewNewcomerJourney.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600911C RID: 37148 RVA: 0x00263124 File Offset: 0x00261324
	protected override void OnBeforeShow()
	{
		Activity? activityConfig = ConfigBase<ActivityConfig>.Instance.GetActivityConfig(this.ActivityDataBase.Id);
		if (activityConfig != null)
		{
			base.GetText(17).ShowTextNew(activityConfig.Value.Name);
		}
		this.SetLogoTexture();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "NewPlayer_Adventure_001", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "NewPlayer_Adventure_002", Array.Empty<object>());
		this.RefreshGetCharacterView();
	}

	// Token: 0x0600911D RID: 37149 RVA: 0x002631B0 File Offset: 0x002613B0
	private void SetLogoTexture()
	{
		UUITexture texture = base.GetTexture(19);
		if (texture != null)
		{
			PlayerInfoModel instance = ModelBase<PlayerInfoModel>.Instance;
			string resourceId = (((instance != null) ? instance.GetPlayerGender() : EPlayerGender.None) == EPlayerGender.Male) ? "T_NewcomerLogoMale" : "T_NewcomerLogoFemale";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				base.SetTextureByPath(resourcePath, texture, null, null);
			}
		}
	}

	// Token: 0x0600911E RID: 37150 RVA: 0x00263210 File Offset: 0x00261410
	private void SetRewardBgTexture()
	{
		UUITexture texture = base.GetTexture(21);
		if (texture != null)
		{
			string resourceId = this.ActivityDataBase.GetCanGetCharacter() ? "T_RewardTipBgReward" : "T_RewardTipBgNor";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				base.SetTextureByPath(resourcePath, texture, null, null);
			}
		}
	}

	// Token: 0x0600911F RID: 37151 RVA: 0x0026326C File Offset: 0x0026146C
	private int GetInitSelectIndex()
	{
		List<AdventureTaskChapterV2> chapterList = this.ActivityDataBase.GetChapterList();
		int num = -1;
		int num2 = 0;
		while (num2 < chapterList.Count && !this.ActivityDataBase.GetChapterIsLock(chapterList[num2].Id))
		{
			if (this.ActivityDataBase.GetChapterHasReward(chapterList[num2].Id))
			{
				num = num2;
				break;
			}
			num2++;
		}
		if (num == -1)
		{
			num = 0;
			AdventureTaskChapterV2 adventureTaskChapterV = chapterList[chapterList.Count - 1];
			bool chapterTaskAllComplete = this.ActivityDataBase.GetChapterTaskAllComplete(adventureTaskChapterV.Id);
			for (int i = 0; i < chapterList.Count; i++)
			{
				if (chapterTaskAllComplete && !this.ActivityDataBase.GetChapterTaskAllComplete(chapterList[i].Id))
				{
					num = i;
					break;
				}
				if (!chapterTaskAllComplete && !this.ActivityDataBase.GetChapterIsLock(chapterList[i].Id))
				{
					num = i;
				}
			}
		}
		return num;
	}

	// Token: 0x06009120 RID: 37152 RVA: 0x00263364 File Offset: 0x00261564
	private void RefreshSelectChapterView(bool isPlayTurnAnimation)
	{
		if (this.SelectChapterConfig == null)
		{
			return;
		}
		int id = this.SelectChapterConfig.Value.Id;
		List<TItem> chapterRewardList = this.ActivityDataBase.GetChapterRewardList(id);
		this.RewardLayout.RefreshByData(chapterRewardList, null, false);
		bool chapterIsLock = this.ActivityDataBase.GetChapterIsLock(id);
		base.GetScrollViewWithScrollbar(3).RootUIComp.Get().SetUIActive(!chapterIsLock);
		base.GetItem(15).SetUIActive(chapterIsLock);
		base.GetText(6).SetUIActive(!chapterIsLock);
		if (chapterIsLock)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), this.SelectChapterConfig.Value.LockedDesc, Array.Empty<object>());
			base.GetItem(9).SetUIActive(true);
			base.GetItem(22).SetUIActive(false);
			base.SetButtonUiActive(10, false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "NewPlayer_Adventure_004", Array.Empty<object>());
			return;
		}
		List<NewcomerJourneyTaskData> chapterTaskList = this.ActivityDataBase.GetChapterTaskList(id);
		this.TaskLayout.RefreshByData(chapterTaskList, isPlayTurnAnimation ? delegate()
		{
			GenericScrollViewNew<NewcomerJourneyTaskItem, NewcomerJourneyTaskData> taskLayout = this.TaskLayout;
			if (taskLayout == null)
			{
				return;
			}
			taskLayout.PlayTurnAnimation();
		} : null, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), this.SelectChapterConfig.Value.ChapterTitle, Array.Empty<object>());
		int chapterCompleteNum = this.ActivityDataBase.GetChapterCompleteNum(id);
		int rewardUnlockCount = this.SelectChapterConfig.Value.RewardUnlockCount;
		UUIText text = base.GetText(6);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(chapterCompleteNum);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(rewardUnlockCount);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetItem(9).SetUIActive(chapterCompleteNum < rewardUnlockCount);
		bool chapterCanGetReward = this.ActivityDataBase.GetChapterCanGetReward(id);
		base.SetButtonUiActive(10, chapterCanGetReward);
		bool chapterRewardHasGet = this.ActivityDataBase.GetChapterRewardHasGet(id);
		base.GetItem(22).SetUIActive(chapterRewardHasGet);
	}

	// Token: 0x06009121 RID: 37153 RVA: 0x00263564 File Offset: 0x00261764
	protected override void OnSequenceStart(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			GenericScrollViewNew<NewcomerJourneyTaskItem, NewcomerJourneyTaskData> taskLayout = this.TaskLayout;
			if (taskLayout == null)
			{
				return;
			}
			taskLayout.PlayTurnAnimation();
		}
	}

	// Token: 0x06009122 RID: 37154 RVA: 0x00263584 File Offset: 0x00261784
	protected override void OnRefreshView()
	{
		List<AdventureTaskChapterV2> chapterList = this.ActivityDataBase.GetChapterList();
		this.TabLayout.RefreshByData(chapterList, delegate
		{
			int num = (this.SelectChapterConfig != null) ? (this.SelectChapterConfig.Value.Sort - 1) : -1;
			if (num < 0)
			{
				num = this.GetInitSelectIndex();
			}
			if (this.IsSendGetReward)
			{
				num = this.ActivityDataBase.GetLastUnLockChapterIndex() - 1;
				num = ((num < 0) ? 0 : num);
				this.IsSendGetReward = false;
			}
			this.SelectChapterConfig = new AdventureTaskChapterV2?(chapterList[num]);
			this.TabLayout.LateScrollToLeft(num);
			this.TabLayout.SelectGridProxy(num, false);
			this.RefreshSelectChapterView(false);
			this.RefreshGetCharacterView();
		}, false);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityBaseData.Id);
	}

	// Token: 0x06009123 RID: 37155 RVA: 0x002635E8 File Offset: 0x002617E8
	protected override void OnTimer(float gap)
	{
		if (this.ActivityBaseData == null)
		{
			return;
		}
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityBaseData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		UUIText text = base.GetText(18);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(item);
		text.SetText(item2, true);
	}

	// Token: 0x0400433B RID: 17211
	private const string NEWCOMER_LOGO_MALE_RESOURCE_ID = "T_NewcomerLogoMale";

	// Token: 0x0400433C RID: 17212
	private const string NEWCOMER_LOGO_FEMALE_RESOURCE_ID = "T_NewcomerLogoFemale";

	// Token: 0x0400433D RID: 17213
	private const string NEWCOMER_TIP_NORMAL_RESOURCE_ID = "T_RewardTipBgNor";

	// Token: 0x0400433E RID: 17214
	private const string NEWCOMER_TIP_REWARD_RESOURCE_ID = "T_RewardTipBgReward";

	// Token: 0x0400433F RID: 17215
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollViewNew<NewcomerJourneyTabItem, AdventureTaskChapterV2> TabLayout;

	// Token: 0x04004340 RID: 17216
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericScrollViewNew<NewcomerJourneyTaskItem, NewcomerJourneyTaskData> TaskLayout;

	// Token: 0x04004341 RID: 17217
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04004342 RID: 17218
	[Nullable(2)]
	private ActivityNewcomerJourneyData ActivityDataBase;

	// Token: 0x04004343 RID: 17219
	private AdventureTaskChapterV2? SelectChapterConfig;

	// Token: 0x04004344 RID: 17220
	private bool IsSendGetReward;

	// Token: 0x02007852 RID: 30802
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029606 RID: 169478
		public const int GetCharacterBtn = 0;

		// Token: 0x04029607 RID: 169479
		public const int TabLayout = 1;

		// Token: 0x04029608 RID: 169480
		public const int TabItem = 2;

		// Token: 0x04029609 RID: 169481
		public const int TaskLayout = 3;

		// Token: 0x0402960A RID: 169482
		public const int TaskItem = 4;

		// Token: 0x0402960B RID: 169483
		public const int TipsTitleText = 5;

		// Token: 0x0402960C RID: 169484
		public const int TipsNumText = 6;

		// Token: 0x0402960D RID: 169485
		public const int RewardLayout = 7;

		// Token: 0x0402960E RID: 169486
		public const int RewardItem = 8;

		// Token: 0x0402960F RID: 169487
		public const int CantGetItem = 9;

		// Token: 0x04029610 RID: 169488
		public const int GetBtn = 10;

		// Token: 0x04029611 RID: 169489
		public const int GetCharacterTitle = 11;

		// Token: 0x04029612 RID: 169490
		public const int GetCharacterDesc = 12;

		// Token: 0x04029613 RID: 169491
		public const int GetCharacterIcon = 13;

		// Token: 0x04029614 RID: 169492
		public const int PreviewBtn = 14;

		// Token: 0x04029615 RID: 169493
		public const int LockItem = 15;

		// Token: 0x04029616 RID: 169494
		public const int LockText = 16;

		// Token: 0x04029617 RID: 169495
		public const int TitleText = 17;

		// Token: 0x04029618 RID: 169496
		public const int TitleSubText = 18;

		// Token: 0x04029619 RID: 169497
		public const int TitleLogo = 19;

		// Token: 0x0402961A RID: 169498
		public const int FinishItem = 20;

		// Token: 0x0402961B RID: 169499
		public const int RewardBg = 21;

		// Token: 0x0402961C RID: 169500
		public const int ChapterTakenItem = 22;

		// Token: 0x0402961D RID: 169501
		public const int CharacterNormalItem = 23;

		// Token: 0x0402961E RID: 169502
		public const int ChapterRedDot = 24;
	}
}
