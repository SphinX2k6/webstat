using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.ActivityPanel
{
	// Token: 0x02004BDF RID: 19423
	[NullableContext(1)]
	[Nullable(0)]
	public class ParkourEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032ADF RID: 207583 RVA: 0x00CB1359 File Offset: 0x00CAF559
		public override string GetResourceId()
		{
			return "UiView_Huodong_Prefab";
		}

		// Token: 0x06032AE0 RID: 207584 RVA: 0x00CB1360 File Offset: 0x00CAF560
		protected override void OnStart()
		{
			this.ScoreTipsView = new TipsListView();
			this.ScoreTipsView.Initialize(base.GetVerticalLayout(5));
			base.OnStart();
		}

		// Token: 0x06032AE1 RID: 207585 RVA: 0x00CB1385 File Offset: 0x00CAF585
		protected override void OnBeforeDestroy()
		{
			TipsListView scoreTipsView = this.ScoreTipsView;
			if (scoreTipsView != null)
			{
				scoreTipsView.Clear();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x06032AE2 RID: 207586 RVA: 0x00CB13A0 File Offset: 0x00CAF5A0
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(14);
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

		// Token: 0x06032AE3 RID: 207587 RVA: 0x00CB13E8 File Offset: 0x00CAF5E8
		protected override void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
			if (parameters.Length != 0)
			{
				ParkourMarkItem parkourMarkItem = parameters[0] as ParkourMarkItem;
				if (parkourMarkItem != null)
				{
					this.SelectedMarkItem = parkourMarkItem;
					this.LayoutContext.MarkItem = parkourMarkItem;
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithTrackStyle(this.LayoutContext);
					this.RefreshScore();
				}
			}
		}

		// Token: 0x06032AE4 RID: 207588 RVA: 0x00CB144A File Offset: 0x00CAF64A
		protected override void OnCloseWorldMapSecondaryUi()
		{
			TipsListView scoreTipsView = this.ScoreTipsView;
			if (scoreTipsView == null)
			{
				return;
			}
			scoreTipsView.Clear();
		}

		// Token: 0x06032AE5 RID: 207589 RVA: 0x00CB145C File Offset: 0x00CAF65C
		private void RefreshScore()
		{
			if (this.SelectedMarkItem == null)
			{
				return;
			}
			ActivityRunData challengeDataByMarkId = ModelBase<ActivityRunModel>.Instance.GetChallengeDataByMarkId(this.SelectedMarkItem.MarkConfigId);
			ParkourChallenge? config = ConfigParkourChallengeByMarkId.GetConfig(this.SelectedMarkItem.MarkId, true);
			if (config == null)
			{
				return;
			}
			InstanceDungeonCostTip instanceDungeonCostTip = this.ScoreTipsView.AddItemByKey("line");
			instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("CurrentLine", null) ?? "");
			string rightText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("LineNumber", null) ?? "", new string[]
			{
				config.Value.Id.ToString()
			});
			instanceDungeonCostTip.SetRightText(rightText);
			instanceDungeonCostTip.SetHelpButtonVisible(false);
			InstanceDungeonCostTip instanceDungeonCostTip2 = this.ScoreTipsView.AddItemByKey("score");
			instanceDungeonCostTip2.SetHelpButtonVisible(false);
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ActiveRunMaxPoint_Text", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip2.SetLeftText(leftText);
			if (challengeDataByMarkId.GetMiniTime() == 0)
			{
				instanceDungeonCostTip2.SetRightText(ConfigMultiTextLang.GetLocalTextNew("Text_ActivityRunNoPoint_Text", null) ?? "");
				return;
			}
			instanceDungeonCostTip2.SetRightText(challengeDataByMarkId.GetMaxScore().ToString());
		}

		// Token: 0x06032AE6 RID: 207590 RVA: 0x00CB159F File Offset: 0x00CAF79F
		protected override void OnConfirmBtnClick(int index)
		{
			this.HandleTrack();
		}

		// Token: 0x0401D82B RID: 120875
		[Nullable(2)]
		private ParkourMarkItem SelectedMarkItem;

		// Token: 0x0401D82C RID: 120876
		[Nullable(2)]
		private TipsListView ScoreTipsView;

		// Token: 0x0200ACC8 RID: 44232
		[Nullable(0)]
		public static class ParkourConstants
		{
			// Token: 0x04035AB3 RID: 219827
			public const string SCORE_KEY = "score";

			// Token: 0x04035AB4 RID: 219828
			public const string LINE_NUMBER_KEY = "line";
		}
	}
}
