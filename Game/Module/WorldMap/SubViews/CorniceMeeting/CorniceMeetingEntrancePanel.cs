using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CorniceMeeting
{
	// Token: 0x02004BC7 RID: 19399
	[NullableContext(1)]
	[Nullable(0)]
	public class CorniceMeetingEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032A1E RID: 207390 RVA: 0x00CAEFBE File Offset: 0x00CAD1BE
		public override string GetResourceId()
		{
			return "UiView_Huodong_Prefab";
		}

		// Token: 0x06032A1F RID: 207391 RVA: 0x00CAEFC5 File Offset: 0x00CAD1C5
		protected override void OnStart()
		{
			this.ScoreTipsView = new TipsListView();
			this.ScoreTipsView.Initialize(base.GetVerticalLayout(5));
			base.OnStart();
		}

		// Token: 0x06032A20 RID: 207392 RVA: 0x00CAEFEC File Offset: 0x00CAD1EC
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(32);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout == null)
			{
				return;
			}
			verticalLayout.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06032A21 RID: 207393 RVA: 0x00CAF032 File Offset: 0x00CAD232
		protected override void OnBeforeDestroy()
		{
			TipsListView scoreTipsView = this.ScoreTipsView;
			if (scoreTipsView != null)
			{
				scoreTipsView.Clear();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x06032A22 RID: 207394 RVA: 0x00CAF04C File Offset: 0x00CAD24C
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				CorniceMeetingMarkItem corniceMeetingMarkItem = param[0] as CorniceMeetingMarkItem;
				if (corniceMeetingMarkItem != null)
				{
					this.LayoutContext.MarkItem = corniceMeetingMarkItem;
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					this.UpdateButtonState();
					this.RefreshScore();
				}
			}
		}

		// Token: 0x06032A23 RID: 207395 RVA: 0x00CAF0A2 File Offset: 0x00CAD2A2
		protected override void OnCloseWorldMapSecondaryUi()
		{
			TipsListView scoreTipsView = this.ScoreTipsView;
			if (scoreTipsView == null)
			{
				return;
			}
			scoreTipsView.Clear();
		}

		// Token: 0x06032A24 RID: 207396 RVA: 0x00CAF0B4 File Offset: 0x00CAD2B4
		private void RefreshScore()
		{
			ActivityCorniceMeetingData currentActivityData = ControllerBase<ActivityCorniceMeetingController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			CorniceMeetingMarkItem corniceMeetingMarkItem = this.LayoutContext.MarkItem as CorniceMeetingMarkItem;
			ActivityCorniceMeetingConfig instance = ConfigBase<ActivityCorniceMeetingConfig>.Instance;
			CorniceChallenge? corniceChallenge = (instance != null) ? instance.GetCorniceMeetingChallengeByMarkId((corniceMeetingMarkItem != null) ? corniceMeetingMarkItem.MarkId : 0) : null;
			if (corniceChallenge == null)
			{
				return;
			}
			ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(corniceChallenge.Value.Id);
			if (levelEntryData == null)
			{
				return;
			}
			TipsListView scoreTipsView = this.ScoreTipsView;
			InstanceDungeonCostTip instanceDungeonCostTip = (scoreTipsView != null) ? scoreTipsView.AddItemByKey("CurrentDungeon") : null;
			if (instanceDungeonCostTip != null)
			{
				instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("CorniceMeetingMarkPanelCurrent", null) ?? "");
				instanceDungeonCostTip.SetRightText(ConfigMultiTextLang.GetLocalTextNew(corniceChallenge.Value.Title, null) ?? "");
				instanceDungeonCostTip.SetHelpButtonVisible(false);
			}
			TipsListView scoreTipsView2 = this.ScoreTipsView;
			InstanceDungeonCostTip instanceDungeonCostTip2 = (scoreTipsView2 != null) ? scoreTipsView2.AddItemByKey("score") : null;
			if (instanceDungeonCostTip2 != null)
			{
				instanceDungeonCostTip2.SetHelpButtonVisible(false);
				instanceDungeonCostTip2.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("CorniceMeetingMarkPanelScore", null) ?? "");
				if (levelEntryData.MaxScore == 0)
				{
					instanceDungeonCostTip2.SetRightText(ConfigMultiTextLang.GetLocalTextNew("ActivityCorniceMeetingScoreNoRecord", null) ?? "");
					return;
				}
				int maxScore = levelEntryData.MaxScore;
				int maxScoreConfig = levelEntryData.GetMaxScoreConfig();
				int num = (maxScore > maxScoreConfig) ? maxScoreConfig : maxScore;
				string rightText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ItemCost_Text", null) ?? "", new string[]
				{
					num.ToString(),
					maxScoreConfig.ToString()
				});
				instanceDungeonCostTip2.SetRightText(rightText);
			}
		}

		// Token: 0x06032A25 RID: 207397 RVA: 0x00CAF256 File Offset: 0x00CAD456
		private void UpdateButtonState()
		{
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext == null)
			{
				return;
			}
			layoutContext.SetConfirmBtnText("Text_TeleportFastMove_Text", Array.Empty<object>());
		}

		// Token: 0x06032A26 RID: 207398 RVA: 0x00CAF272 File Offset: 0x00CAD472
		protected override void OnConfirmBtnClick(int index)
		{
			base.CloseWithCallBack(delegate
			{
				CorniceMeetingMarkItem corniceMeetingMarkItem = this.LayoutContext.MarkItem as CorniceMeetingMarkItem;
				ActivityCorniceMeetingConfig instance = ConfigBase<ActivityCorniceMeetingConfig>.Instance;
				CorniceChallenge? corniceChallenge = (instance != null) ? instance.GetCorniceMeetingChallengeByMarkId((corniceMeetingMarkItem != null) ? corniceMeetingMarkItem.MarkId : 0) : null;
				if (corniceChallenge != null)
				{
					ControllerBase<ActivityCorniceMeetingController>.Instance.CorniceMeetingChallengeTransRequest(corniceChallenge.Value.Id);
				}
			}, true);
		}

		// Token: 0x0401D7FF RID: 120831
		private const string CURRENT_DUNGEON = "CurrentDungeon";

		// Token: 0x0401D800 RID: 120832
		private const string SCORE_KEY = "score";

		// Token: 0x0401D801 RID: 120833
		[Nullable(2)]
		private TipsListView ScoreTipsView;

		// Token: 0x0200ACAD RID: 44205
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A54 RID: 219732
			public const int CorniceMeetingPanel = 0;
		}
	}
}
