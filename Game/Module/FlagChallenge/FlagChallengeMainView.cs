using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D6B RID: 23915
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeMainView : UiViewBase
	{
		// Token: 0x0603C3F6 RID: 246774 RVA: 0x00F488B5 File Offset: 0x00F46AB5
		public FlagChallengeMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C3F7 RID: 246775 RVA: 0x00F488D4 File Offset: 0x00F46AD4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(18, typeof(UUIText)),
				new ValueTuple<int, Type>(19, typeof(UUITexture)),
				new ValueTuple<int, Type>(20, typeof(UUIArtText)),
				new ValueTuple<int, Type>(21, typeof(UUIText)),
				new ValueTuple<int, Type>(22, typeof(UUISprite)),
				new ValueTuple<int, Type>(23, typeof(UUIArtText)),
				new ValueTuple<int, Type>(24, typeof(UUISprite)),
				new ValueTuple<int, Type>(25, typeof(UUIArtText)),
				new ValueTuple<int, Type>(26, typeof(UUIText)),
				new ValueTuple<int, Type>(27, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(28, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(29, typeof(UUIItem)),
				new ValueTuple<int, Type>(30, typeof(UUIText)),
				new ValueTuple<int, Type>(31, typeof(UUIItem)),
				new ValueTuple<int, Type>(32, typeof(UUIItem)),
				new ValueTuple<int, Type>(33, typeof(UUIItem)),
				new ValueTuple<int, Type>(34, typeof(UUIItem)),
				new ValueTuple<int, Type>(35, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(36, typeof(UUIItem)),
				new ValueTuple<int, Type>(37, typeof(UUIText)),
				new ValueTuple<int, Type>(38, typeof(UUISprite)),
				new ValueTuple<int, Type>(39, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(13, new Action(this.OnBuffButtonClick)),
				new ValueTuple<int, Delegate>(17, new Action(this.OnTaskButtonClick)),
				new ValueTuple<int, Delegate>(27, new Action(this.OnDetailButtonClick)),
				new ValueTuple<int, Delegate>(28, new Action(this.OnChallengeButtonClick))
			};
		}

		// Token: 0x0603C3F8 RID: 246776 RVA: 0x00F48CEC File Offset: 0x00F46EEC
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeMainView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeMainView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C3F9 RID: 246777 RVA: 0x00F48D30 File Offset: 0x00F46F30
		protected override void OnStart()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotFlagChallengeActivityReward, base.GetItem(36), null, this.ActivityId);
			UUIItem item = base.GetItem(14);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotFlagChallengeActivityBuffNewlyUnlocked, item, null, this.ActivityId);
			item.SetUIActive(this.Data.HasBuffNewlyUnlocked());
			this.LevelScrollView.GetGenericLayout().SelectGridProxyByKey(this.SelectedLevelId, true);
			UUIItem itemByKey = this.LevelScrollView.GetItemByKey(this.SelectedLevelId);
			if (itemByKey != null)
			{
				this.LevelScrollView.LateScrollTo(itemByKey, null, false);
			}
			this.LevelInfoItem.RefreshView();
			this.RefreshTaskView();
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnTaskUpdate));
		}

		// Token: 0x0603C3FA RID: 246778 RVA: 0x00F48E00 File Offset: 0x00F47000
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotFlagChallengeActivityReward, base.GetItem(36), this.ActivityId);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotFlagChallengeActivityBuffNewlyUnlocked, base.GetItem(14), this.ActivityId);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnTaskUpdate));
		}

		// Token: 0x0603C3FB RID: 246779 RVA: 0x00F48E64 File Offset: 0x00F47064
		private void InitViewData()
		{
			ActivityFlagChallengeData activityFlagChallengeData = (ActivityFlagChallengeData)this.OpenParam;
			this.ActivityId = activityFlagChallengeData.Id;
			this.Data = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId);
			this.SelectedLevelId = (this.Data.GetMainViewSelectLevelId() ?? ModelBase<FlagChallengeModel>.Instance.GetRecommendLevel(this.ActivityId, true).Value);
			this.Data.SetMainViewSelectLevelId(null);
			this.UpdateViewData();
		}

		// Token: 0x0603C3FC RID: 246780 RVA: 0x00F48EF8 File Offset: 0x00F470F8
		private void UpdateViewData()
		{
			int levelRecommendStrongholdId = ModelBase<FlagChallengeModel>.Instance.GetLevelRecommendStrongholdId(this.ActivityId, this.SelectedLevelId, null);
			this.EnterStrongholdId = levelRecommendStrongholdId;
		}

		// Token: 0x0603C3FD RID: 246781 RVA: 0x00F48F24 File Offset: 0x00F47124
		private UniTask CreateAreaItemAsync(UUIItem uiItem, int index)
		{
			FlagChallengeMainView.<CreateAreaItemAsync>d__19 <CreateAreaItemAsync>d__;
			<CreateAreaItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAreaItemAsync>d__.<>4__this = this;
			<CreateAreaItemAsync>d__.uiItem = uiItem;
			<CreateAreaItemAsync>d__.index = index;
			<CreateAreaItemAsync>d__.<>1__state = -1;
			<CreateAreaItemAsync>d__.<>t__builder.Start<FlagChallengeMainView.<CreateAreaItemAsync>d__19>(ref <CreateAreaItemAsync>d__);
			return <CreateAreaItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C3FE RID: 246782 RVA: 0x00F48F77 File Offset: 0x00F47177
		private void RefreshTaskView()
		{
			base.GetText(18).SetText(this.Data.GetTaskProgressText(), true);
		}

		// Token: 0x0603C3FF RID: 246783 RVA: 0x00F48F94 File Offset: 0x00F47194
		private void RefreshLevelView()
		{
			EFlagChallengeUiStyleType uiStyle = this.Data.GetLevelData(this.SelectedLevelId).GetUiStyle();
			Dictionary<string, string> dictionary;
			if (!Singleton<FlagChallengeDefine>.Instance.flagChallengeStyleRes.TryGetValue(uiStyle, out dictionary))
			{
				return;
			}
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			base.SetTextureByPath(instance.GetResourcePath(dictionary["LevelMapBg"]), base.GetTexture(1), null, null);
			base.SetTextureByPath(instance.GetResourcePath(dictionary["LevelMapTopBg"]), base.GetTexture(2), null, null);
			base.SetTextureByPath(instance.GetResourcePath(dictionary["LevelListLight"]), base.GetTexture(3), null, null);
			base.SetTextureByPath(instance.GetResourcePath(dictionary["LevelFrame"]), base.GetTexture(5), null, null);
			base.SetTextureByPath(instance.GetResourcePath(dictionary["LevelSetOffLight"]), base.GetTexture(6), null, null);
			base.SetTextureByPath(instance.GetResourcePath(dictionary["LevelTitleBg"]), base.GetTexture(19), null, null);
			base.SetTextureByPath(instance.GetResourcePath(dictionary["MaskBg"]), base.GetTexture(4), null, null);
			base.GetItem(32).SetUIActive(uiStyle == EFlagChallengeUiStyleType.Green);
			base.GetItem(33).SetUIActive(uiStyle == EFlagChallengeUiStyleType.Yellow);
			base.GetItem(34).SetUIActive(uiStyle == EFlagChallengeUiStyleType.Red || uiStyle == EFlagChallengeUiStyleType.Hidden);
		}

		// Token: 0x0603C400 RID: 246784 RVA: 0x00F49128 File Offset: 0x00F47328
		private void RefreshLevelDetailView()
		{
			FlagChallengeLevelData levelData = this.Data.GetLevelData(this.SelectedLevelId);
			base.GetArtText(20).SetText(levelData.Index.ToString().PadLeft(2, '0'));
			base.GetText(21).ShowTextNew(levelData.LevelConfig.Name);
			base.GetText(26).ShowTextNew(levelData.LevelConfig.Desc);
			int[] recommendLevel = levelData.GetRecommendLevel();
			base.GetArtText(23).SetText(recommendLevel[0].ToString());
			base.GetArtText(25).SetText(recommendLevel[1].ToString());
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			this.SetSpriteByPath(instance.GetResourcePath(this.GetLevelDiffBgRes(recommendLevel[0])), base.GetSprite(22), false, null, null);
			this.SetSpriteByPath(instance.GetResourcePath(this.GetLevelDiffBgRes(recommendLevel[1])), base.GetSprite(24), false, null, null);
			int totalLevel = ModelBase<FlagChallengeModel>.Instance.GetTotalLevel(this.ActivityId);
			FlagChallengeStrongholdData strongholdData = this.Data.GetStrongholdData(this.EnterStrongholdId);
			base.GetItem(31).SetUIActive(!strongholdData.IsPass && totalLevel < strongholdData.StrongholdConfig.RecommendLevel);
			UUIText text = base.GetText(37);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Morale_32_Region_NickName_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(strongholdData.GetIndex());
			text.ShowTextNew(defaultInterpolatedStringHandler.ToStringAndClear());
			FlagChallengeAreaData areaData = this.Data.GetAreaData(strongholdData.StrongholdConfig.AreaId);
			UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SP_MoraleRome");
			defaultInterpolatedStringHandler.AppendFormatted<int>(areaData.Config.UiPos);
			this.SetSpriteByPath(instance2.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear()), base.GetSprite(38), false, null, null);
			bool flag = levelData.IsCompleted();
			base.GetItem(29).SetUIActive(!flag);
			base.GetButton(27).RootUIComp.Get().SetUIActive(!flag);
			base.GetButton(28).RootUIComp.Get().SetUIActive(!flag);
			base.GetItem(39).SetUIActive(flag);
		}

		// Token: 0x0603C401 RID: 246785 RVA: 0x00F49388 File Offset: 0x00F47588
		private string GetLevelDiffBgRes(int targetLevel)
		{
			switch (ModelBase<FlagChallengeModel>.Instance.GetLevelDiffType(this.ActivityId, targetLevel, null))
			{
			case EFlagChallengeLevelDiffType.Easy:
				return "SP_MoralePowerGreen";
			case EFlagChallengeLevelDiffType.Normal:
				return "SP_MoralePowerYellow";
			case EFlagChallengeLevelDiffType.Hard:
				return "SP_MoralePowerRed";
			default:
				return "SP_MoralePowerGreen";
			}
		}

		// Token: 0x0603C402 RID: 246786 RVA: 0x00F493DC File Offset: 0x00F475DC
		private void RefreshAreaView(bool isClear = true)
		{
			if (isClear)
			{
				this.AreaItemMap.Clear();
				List<FlagChallengeAreaData> levelAreaDataList = this.Data.GetLevelAreaDataList(this.SelectedLevelId);
				foreach (FlagChallengeLevelAreaItem flagChallengeLevelAreaItem in this.AreaItemList)
				{
					flagChallengeLevelAreaItem.SetUiActive(false);
				}
				for (int i = 0; i < levelAreaDataList.Count; i++)
				{
					FlagChallengeAreaData flagChallengeAreaData = levelAreaDataList[i];
					int areaItemPos = flagChallengeAreaData.GetAreaItemPos();
					if (areaItemPos - 1 < this.AreaItemList.Count)
					{
						FlagChallengeLevelAreaItem flagChallengeLevelAreaItem2 = this.AreaItemList[areaItemPos - 1];
						if (flagChallengeLevelAreaItem2 != null)
						{
							flagChallengeLevelAreaItem2.Refresh(flagChallengeAreaData, i + 1);
							flagChallengeLevelAreaItem2.SetUiActive(true);
							this.AreaItemMap.Add(flagChallengeAreaData.Id, flagChallengeLevelAreaItem2);
						}
					}
				}
				return;
			}
			foreach (KeyValuePair<int, FlagChallengeLevelAreaItem> keyValuePair in this.AreaItemMap)
			{
				keyValuePair.Value.RefreshView();
			}
		}

		// Token: 0x0603C403 RID: 246787 RVA: 0x00F49508 File Offset: 0x00F47708
		private void OnBuffButtonClick()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeBuffView(this.ActivityId, null);
		}

		// Token: 0x0603C404 RID: 246788 RVA: 0x00F4952E File Offset: 0x00F4772E
		private void OnTaskButtonClick()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeTaskView(this.ActivityId);
		}

		// Token: 0x0603C405 RID: 246789 RVA: 0x00F49540 File Offset: 0x00F47740
		private void OnDetailButtonClick()
		{
			int levelRecommendStrongholdId = ModelBase<FlagChallengeModel>.Instance.GetLevelRecommendStrongholdId(this.ActivityId, this.SelectedLevelId, null);
			FlagChallengeStrongholdData strongholdData = this.Data.GetStrongholdData(levelRecommendStrongholdId);
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeAreaDetailView(this.ActivityId, this.SelectedLevelId, strongholdData.StrongholdConfig.AreaId, new int?(strongholdData.Id));
		}

		// Token: 0x0603C406 RID: 246790 RVA: 0x00F495A0 File Offset: 0x00F477A0
		private void OnHelpClick()
		{
			int mainViewHelpId = ConfigBase<FlagChallengeConfig>.Instance.GetMainViewHelpId();
			ControllerBase<HelpController>.Instance.OpenHelpById(mainViewHelpId);
		}

		// Token: 0x0603C407 RID: 246791 RVA: 0x00F495C3 File Offset: 0x00F477C3
		private void OnChallengeButtonClick()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeSelectRoleView(this.ActivityId, this.SelectedLevelId, this.EnterStrongholdId);
		}

		// Token: 0x0603C408 RID: 246792 RVA: 0x00F495E1 File Offset: 0x00F477E1
		private FlagChallengeLevelTabItem CreateLevelItem()
		{
			FlagChallengeLevelTabItem flagChallengeLevelTabItem = new FlagChallengeLevelTabItem();
			flagChallengeLevelTabItem.SetToggleCallback(new Action<int>(this.OnLevelTabItemSelect));
			return flagChallengeLevelTabItem;
		}

		// Token: 0x0603C409 RID: 246793 RVA: 0x00F495FA File Offset: 0x00F477FA
		private void OnCloseButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603C40A RID: 246794 RVA: 0x00F49603 File Offset: 0x00F47803
		private void OnTaskUpdate(int activityId)
		{
			if (activityId != this.ActivityId)
			{
				return;
			}
			this.RefreshTaskView();
		}

		// Token: 0x0603C40B RID: 246795 RVA: 0x00F49618 File Offset: 0x00F47818
		private void OnLevelTabItemSelect(int levelId)
		{
			GenericLayout<FlagChallengeLevelTabItem, FlagChallengeLevelData> genericLayout = this.LevelScrollView.GetGenericLayout();
			genericLayout.DeselectCurrentGridProxy();
			this.SelectedLevelId = levelId;
			genericLayout.SelectGridProxyByKey(levelId, false);
			this.UpdateViewData();
			this.RefreshAreaView(true);
			this.RefreshLevelView();
			this.RefreshLevelDetailView();
			this.SequencePlayer.StopCurrentSequenceByName("Switch", false, true);
			this.SequencePlayer.PlayOrReplaySequenceByName("Switch", true, null);
		}

		// Token: 0x0603C40C RID: 246796 RVA: 0x00F49690 File Offset: 0x00F47890
		private void OnLevelAreaItemClick(int areaId)
		{
			this.SelectedAreaId = new int?(areaId);
			int areaRecommendStrongholdId = ModelBase<FlagChallengeModel>.Instance.GetAreaRecommendStrongholdId(this.ActivityId, areaId);
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeAreaDetailView(this.ActivityId, this.SelectedLevelId, this.SelectedAreaId.Value, new int?(areaRecommendStrongholdId));
		}

		// Token: 0x04021DDB RID: 138715
		private int ActivityId;

		// Token: 0x04021DDC RID: 138716
		private FlagChallengeData Data;

		// Token: 0x04021DDD RID: 138717
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<FlagChallengeLevelTabItem, FlagChallengeLevelData> LevelScrollView;

		// Token: 0x04021DDE RID: 138718
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04021DDF RID: 138719
		private FlagChallengeLevelInfoItem LevelInfoItem;

		// Token: 0x04021DE0 RID: 138720
		private FlagChallengeCompleteItem CompleteItem;

		// Token: 0x04021DE1 RID: 138721
		private readonly List<FlagChallengeLevelAreaItem> AreaItemList = new List<FlagChallengeLevelAreaItem>();

		// Token: 0x04021DE2 RID: 138722
		private readonly Dictionary<int, FlagChallengeLevelAreaItem> AreaItemMap = new Dictionary<int, FlagChallengeLevelAreaItem>();

		// Token: 0x04021DE3 RID: 138723
		private int SelectedLevelId;

		// Token: 0x04021DE4 RID: 138724
		private int? SelectedAreaId;

		// Token: 0x04021DE5 RID: 138725
		private int EnterStrongholdId;

		// Token: 0x04021DE6 RID: 138726
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;
	}
}
