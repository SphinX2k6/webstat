using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.QuestPanel
{
	// Token: 0x02004B8E RID: 19342
	[NullableContext(2)]
	[Nullable(0)]
	public class QuestPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032845 RID: 206917 RVA: 0x00CA4F16 File Offset: 0x00CA3116
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiView_Task_Prefab";
		}

		// Token: 0x06032846 RID: 206918 RVA: 0x00CA4F20 File Offset: 0x00CA3120
		protected override UniTask OnBeforeStartAsync()
		{
			QuestPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuestPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032847 RID: 206919 RVA: 0x00CA4F64 File Offset: 0x00CA3164
		protected override void OnStart()
		{
			this.QuestRewardList = new List<TItem>();
			this.RewardItemList = Array.Empty<CommonItemSmallItemGrid>();
			this.ConditionTipsView = new TipsListView();
			TipsListView conditionTipsView = this.ConditionTipsView;
			if (conditionTipsView != null)
			{
				conditionTipsView.Initialize(base.GetVerticalLayout(5));
			}
			base.OnStart();
		}

		// Token: 0x06032848 RID: 206920 RVA: 0x00CA4FB0 File Offset: 0x00CA31B0
		protected override void OnBeforeDestroy()
		{
			if (this.RewardItemList != null)
			{
				foreach (CommonItemSmallItemGrid child in this.RewardItemList)
				{
					base.AddChild(child);
				}
				this.RewardItemList = Array.Empty<CommonItemSmallItemGrid>();
			}
			RewardItemBar rewardItemsView = this.RewardItemsView;
			if (rewardItemsView != null)
			{
				rewardItemsView.Destroy(null);
			}
			TipsListView conditionTipsView = this.ConditionTipsView;
			if (conditionTipsView != null)
			{
				conditionTipsView.Clear();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x06032849 RID: 206921 RVA: 0x00CA5019 File Offset: 0x00CA3219
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x0603284A RID: 206922 RVA: 0x00CA5048 File Offset: 0x00CA3248
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TaskMarkItem taskMarkItem = param[0] as TaskMarkItem;
				if (taskMarkItem != null)
				{
					this.QuestId = ((taskMarkItem.BtType.GetValueOrDefault() == BtType.Quest) ? taskMarkItem.TreeConfigId : 0);
					this.QuestBehaviorId = taskMarkItem.NodeId;
					this.SelectedMarkItem = taskMarkItem;
					this.LayoutContext.MarkItem = taskMarkItem;
					this.UpdateQuestInfo();
					this.UpdateTrackButton();
					WorldMapSecondaryUiLayoutHelper.UpdateIcon(this.LayoutContext);
					base.UpdateRightDownIconActive();
					bool flag = base.UpdateQuickGoto();
					WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
					if (layoutContext == null)
					{
						return;
					}
					layoutContext.SetConfirmBtnActive(!flag);
				}
			}
		}

		// Token: 0x0603284B RID: 206923 RVA: 0x00CA50DC File Offset: 0x00CA32DC
		protected override void OnCloseWorldMapSecondaryUi()
		{
			TipsListView conditionTipsView = this.ConditionTipsView;
			if (conditionTipsView == null)
			{
				return;
			}
			conditionTipsView.Clear();
		}

		// Token: 0x0603284C RID: 206924 RVA: 0x00CA50EE File Offset: 0x00CA32EE
		public override UUIItem GetGuideFocusUiItem()
		{
			UUIButtonComponent button = base.GetButton(29);
			if (button == null)
			{
				return null;
			}
			return button.GetRootComponent();
		}

		// Token: 0x0603284D RID: 206925 RVA: 0x00CA5104 File Offset: 0x00CA3304
		private void UpdateQuestInfo()
		{
			QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
			bool quest = instance.GetQuest(this.QuestId) != null;
			string questName = instance.GetQuestName(this.QuestId);
			TaskMarkItem selectedMarkItem = this.SelectedMarkItem;
			int valueOrDefault = ((selectedMarkItem != null) ? selectedMarkItem.InstanceDungeonId : null).GetValueOrDefault();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(valueOrDefault);
			int num = (config != null) ? config.GetValueOrDefault().RelatedQuestId : 0;
			IQuest quest2 = (num != 0) ? instance.GetQuestConfig(num) : null;
			if (quest && !string.IsNullOrEmpty(questName))
			{
				base.GetText(1).SetText(questName, true);
				base.GetText(4).SetText(instance.GetQuestDetails(this.QuestId), true);
			}
			else if (quest2 != null)
			{
				base.GetText(1).ShowTextNew(quest2.TidName);
				base.GetText(4).ShowTextNew(quest2.TidDesc);
			}
			else
			{
				base.GetText(1).SetText(instance.GetQuestNameFromConfig(this.QuestId), true);
				base.GetText(4).SetText(instance.GetQuestDetailsFromConfig(this.QuestId), true);
			}
			if (this.QuestBehaviorId == 0)
			{
				this.RewardItemsView.SetUiActive(false);
				return;
			}
			RewardItemBar rewardItemsView = this.RewardItemsView;
			if (rewardItemsView != null)
			{
				rewardItemsView.SetUiActive(true);
			}
			this.UpdateDetailsBehavior(this.QuestId, this.QuestBehaviorId);
			this.UpdateDetailsRewards();
		}

		// Token: 0x0603284E RID: 206926 RVA: 0x00CA5260 File Offset: 0x00CA3460
		protected override void OnTrackBtnClick(int index)
		{
			base.CheckAndShowCrossMapTips(this.SelectedMarkItem);
			InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
			TaskMarkItem selectedMarkItem = this.SelectedMarkItem;
			InstanceDungeon? config = instance.GetConfig(((selectedMarkItem != null) ? selectedMarkItem.InstanceDungeonId : null).GetValueOrDefault());
			if (this.QuestBehaviorId == 0)
			{
				MapController instance2 = ControllerBase<MapController>.Instance;
				if (instance2 != null)
				{
					TrackMapMarkParams trackMapMarkParams = new TrackMapMarkParams();
					trackMapMarkParams.MarkType = EMarkType.Quest;
					TaskMarkItem selectedMarkItem2 = this.SelectedMarkItem;
					trackMapMarkParams.MarkId = ((selectedMarkItem2 != null) ? selectedMarkItem2.MarkId : 0);
					trackMapMarkParams.Track = !this.IsQuestTracked;
					instance2.RequestTrackMapMark(trackMapMarkParams, null);
				}
				this.IsQuestTracked = !this.IsQuestTracked;
				base.Close();
				return;
			}
			int questId = this.QuestId;
			int num = (config != null) ? config.GetValueOrDefault().RelatedQuestId : 0;
			if (num != 0)
			{
				questId = num;
			}
			QuestNewController instance3 = ControllerBase<QuestNewController>.Instance;
			if (instance3 == null)
			{
				return;
			}
			instance3.RequestTrackQuest(questId, !this.IsQuestTracked, ERequestTrackOperate.Manual, ESetTrackReason.None, delegate
			{
				this.UpdateTrackButton();
				base.Close();
			});
		}

		// Token: 0x0603284F RID: 206927 RVA: 0x00CA535C File Offset: 0x00CA355C
		private void UpdateDetailsBehavior(int questId, int nodeId)
		{
			QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
			global::Quest quest = (instance != null) ? instance.GetQuest(questId) : null;
			if (quest == null)
			{
				return;
			}
			GeneralLogicTreeController instance2 = ControllerBase<GeneralLogicTreeController>.Instance;
			string rightText = ((instance2 != null) ? instance2.GetNodeTrackText(quest.TreeId.GetValueOrDefault(), nodeId) : null) ?? "";
			TipsListView conditionTipsView = this.ConditionTipsView;
			InstanceDungeonCostTip instanceDungeonCostTip = (conditionTipsView != null) ? conditionTipsView.AddItemByKey("questCondition") : null;
			if (instanceDungeonCostTip != null)
			{
				instanceDungeonCostTip.SetHelpButtonVisible(false);
			}
			if (instanceDungeonCostTip != null)
			{
				instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("TowerProcess", null) ?? "");
			}
			if (instanceDungeonCostTip == null)
			{
				return;
			}
			instanceDungeonCostTip.SetRightText(rightText);
		}

		// Token: 0x06032850 RID: 206928 RVA: 0x00CA53FC File Offset: 0x00CA35FC
		private void UpdateDetailsRewards()
		{
			this.QuestRewardList = new List<TItem>();
			QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
			List<TItem> list = instance.GetDisplayRewardCommonInfo(this.QuestId) ?? instance.GetDisplayRewardCommonInfoFromQuestConfig(this.QuestId);
			if (list != null)
			{
				this.QuestRewardList = list;
				UUIItem uuiitem = base.GetVerticalLayout(7).RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(true);
				}
				this.RewardItemsView.RebuildRewardsByData(this.QuestRewardList);
				return;
			}
			UUIItem uuiitem2 = base.GetVerticalLayout(7).RootUIComp.Get();
			if (uuiitem2 == null)
			{
				return;
			}
			uuiitem2.SetUIActive(false);
		}

		// Token: 0x06032851 RID: 206929 RVA: 0x00CA5494 File Offset: 0x00CA3694
		private void UpdateTrackButton()
		{
			if (this.QuestBehaviorId != 0)
			{
				InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
				InstanceDungeon? instanceDungeon;
				if (instance == null)
				{
					instanceDungeon = null;
				}
				else
				{
					TaskMarkItem selectedMarkItem = this.SelectedMarkItem;
					instanceDungeon = instance.GetConfig(((selectedMarkItem != null) ? selectedMarkItem.InstanceDungeonId : null).GetValueOrDefault());
				}
				InstanceDungeon? instanceDungeon2 = instanceDungeon;
				int num = (instanceDungeon2 != null) ? instanceDungeon2.GetValueOrDefault().RelatedQuestId : 0;
				if (num != 0)
				{
					QuestNewModel instance2 = ModelBase<QuestNewModel>.Instance;
					this.IsQuestTracked = (instance2 != null && instance2.IsTrackingQuest(num));
				}
				else
				{
					QuestNewModel instance3 = ModelBase<QuestNewModel>.Instance;
					this.IsQuestTracked = (instance3 != null && instance3.IsTrackingQuest(this.QuestId));
				}
			}
			else
			{
				TaskMarkItem selectedMarkItem2 = this.SelectedMarkItem;
				int num2 = (selectedMarkItem2 != null) ? selectedMarkItem2.MarkId : 0;
				MapModel instance4 = ModelBase<MapModel>.Instance;
				TrackMapMarkParams trackMapMarkParams = (instance4 != null) ? instance4.GetCurTrackMark() : null;
				if (trackMapMarkParams == null)
				{
					this.IsQuestTracked = false;
				}
				else
				{
					this.IsQuestTracked = (trackMapMarkParams.MarkId == num2);
				}
			}
			TextConfig instance5 = ConfigBase<TextConfig>.Instance;
			string textId = (instance5 != null) ? instance5.GetTextContentIdById(this.IsQuestTracked ? "InstanceDungeonEntranceCancelTrack" : "InstanceDungeonEntranceTrack") : null;
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null)
			{
				layoutContext.SetConfirmBtnText(textId, Array.Empty<object>());
			}
			ButtonItem trackBtn = this.TrackBtn;
			if (trackBtn == null)
			{
				return;
			}
			trackBtn.SetLocalText(this.IsQuestTracked ? "InstanceDungeonEntranceCancelTrack" : "InstanceDungeonEntranceTrack", Array.Empty<object>());
		}

		// Token: 0x06032852 RID: 206930 RVA: 0x00CA55EE File Offset: 0x00CA37EE
		protected override void OnRefreshPanel()
		{
			this.UpdateTrackButton();
		}

		// Token: 0x06032853 RID: 206931 RVA: 0x00CA55F8 File Offset: 0x00CA37F8
		protected override void HandleQuickGoto()
		{
			if (this.QuestId != 0)
			{
				global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.QuestId);
				BaseBehaviorTree baseBehaviorTree = (quest != null) ? quest.Tree : null;
				FastReturnResolved fastReturnResolved = FastReturnUtil.Resolve(baseBehaviorTree);
				if (baseBehaviorTree != null && fastReturnResolved != null)
				{
					FastReturnUtil.Trigger(baseBehaviorTree, fastReturnResolved, true, null);
					return;
				}
			}
			base.HandleQuickGoto();
		}

		// Token: 0x06032854 RID: 206932 RVA: 0x00CA5647 File Offset: 0x00CA3847
		protected override bool IsFastReturnAvailable()
		{
			if (this.QuestId == 0)
			{
				return false;
			}
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(this.QuestId);
			return FastReturnUtil.Resolve((quest != null) ? quest.Tree : null) != null;
		}

		// Token: 0x0401D75D RID: 120669
		[Nullable(1)]
		private const string QUEST_CONDITION_KEY = "questCondition";

		// Token: 0x0401D75E RID: 120670
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private CommonItemSmallItemGrid[] RewardItemList;

		// Token: 0x0401D75F RID: 120671
		private List<TItem> QuestRewardList;

		// Token: 0x0401D760 RID: 120672
		private bool IsQuestTracked;

		// Token: 0x0401D761 RID: 120673
		private int QuestId;

		// Token: 0x0401D762 RID: 120674
		private int QuestBehaviorId;

		// Token: 0x0401D763 RID: 120675
		private TaskMarkItem SelectedMarkItem;

		// Token: 0x0401D764 RID: 120676
		private RewardItemBar RewardItemsView;

		// Token: 0x0401D765 RID: 120677
		private TipsListView ConditionTipsView;

		// Token: 0x0200AC63 RID: 44131
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x0403598F RID: 219535
			public const int QuestPanel = 0;
		}
	}
}
