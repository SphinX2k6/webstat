using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.InstanceDungeonEntrancePanel
{
	// Token: 0x02004BAB RID: 19371
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x170086F0 RID: 34544
		// (get) Token: 0x0603291D RID: 207133 RVA: 0x00CA94AC File Offset: 0x00CA76AC
		private InstanceDungeonEntrance? EntranceConfig
		{
			get
			{
				if (this.EntranceId == 0)
				{
					return null;
				}
				InstanceDungeonEntranceConfig instance = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
				if (instance == null)
				{
					return null;
				}
				return instance.GetConfig(this.EntranceId);
			}
		}

		// Token: 0x0603291E RID: 207134 RVA: 0x00CA94E9 File Offset: 0x00CA76E9
		public override string GetResourceId()
		{
			return "UiView_InstanceEntranceTip_Prefab";
		}

		// Token: 0x0603291F RID: 207135 RVA: 0x00CA94F0 File Offset: 0x00CA76F0
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeEntrancePanel.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeEntrancePanel.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032920 RID: 207136 RVA: 0x00CA9534 File Offset: 0x00CA7734
		protected override void OnStart()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(true);
			}
			this.InstanceCostTipView = new GenericLayoutAdd<InstanceDungeonCostTip>(base.GetVerticalLayout(5), new TLayoutRefresh<InstanceDungeonCostTip>(this.OnInstanceRefresh));
			base.OnStart();
		}

		// Token: 0x06032921 RID: 207137 RVA: 0x00CA9585 File Offset: 0x00CA7785
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(32);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06032922 RID: 207138 RVA: 0x00CA95A0 File Offset: 0x00CA77A0
		protected override void OnBeforeDestroy()
		{
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.ClearChildren();
			}
			if (this.TimerId != null)
			{
				TimerSystem.Instance.Remove(this.TimerId);
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x06032923 RID: 207139 RVA: 0x00CA95D4 File Offset: 0x00CA77D4
		private ILayoutItem<InstanceDungeonCostTip> OnInstanceRefresh(object data, UUIItem uiItem, int index, int originalItemIndex)
		{
			InstanceDungeonCostTip instanceDungeonCostTip = new InstanceDungeonCostTip();
			instanceDungeonCostTip.SetRootActor(uiItem.GetOwner(), true);
			return new LayoutItem<InstanceDungeonCostTip>
			{
				Key = data,
				Value = instanceDungeonCostTip
			};
		}

		// Token: 0x06032924 RID: 207140 RVA: 0x00CA9608 File Offset: 0x00CA7808
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TeleportMarkItem teleportMarkItem = param[0] as TeleportMarkItem;
				if (teleportMarkItem != null)
				{
					this.SelectedMarkItem = teleportMarkItem;
					this.LayoutContext.MarkItem = teleportMarkItem;
					int num = (teleportMarkItem != null) ? teleportMarkItem.MarkConfig.Value.RelativeId : 0;
					int markConfigId = teleportMarkItem.MarkConfigId;
					int entranceId;
					if (num == 0)
					{
						InstanceDungeonEntranceConfig instance = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
						entranceId = ((instance != null) ? instance.GetEntranceIdByMarkId(markConfigId) : 0);
					}
					else
					{
						entranceId = num;
					}
					this.EntranceId = entranceId;
					if (this.EntranceId == 0)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.InstanceDungeon;
						ELogAuthor author = ELogAuthor.LYX;
						string message = "副本入口弹窗打开错误，副本入口表中找不到对应的地图标记Id！";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", teleportMarkItem.MarkConfigId);
						instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					this.InitView();
					this.UpdateInstanceList();
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					InstanceDungeonEntrance? instanceDungeonEntrance;
					int num2 = (this.EntranceConfig != null) ? instanceDungeonEntrance.GetValueOrDefault().UnLockCondition : 0;
					if (num2 != 0 && !ModelBase<FunctionModel>.Instance.IsOpen(num2))
					{
						FunctionConfig instance3 = ConfigBase<FunctionConfig>.Instance;
						FunctionCondition? functionCondition = (instance3 != null) ? instance3.GetFunctionCondition(num2) : null;
						ConditionConfig instance4 = ConfigBase<ConditionConfig>.Instance;
						ConditionGroup? conditionGroup = (instance4 != null) ? instance4.GetConditionGroupConfig((functionCondition != null) ? functionCondition.GetValueOrDefault().OpenConditionId : 0) : null;
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), ((conditionGroup != null) ? conditionGroup.GetValueOrDefault().HintText : null) ?? "", Array.Empty<object>());
					}
				}
			}
		}

		// Token: 0x06032925 RID: 207141 RVA: 0x00CA97AC File Offset: 0x00CA79AC
		private void InitView()
		{
			InstanceDungeonEntrance? entranceConfig = this.EntranceConfig;
			if (entranceConfig == null)
			{
				return;
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(entranceConfig.Value.Description);
			}
			WorldMapSecondaryUiLayoutHelper.UpdateIcon(this.LayoutContext);
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.ShowTextNew(entranceConfig.Value.Name);
			}
			WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				TeleportMarkItem selectedMarkItem = this.SelectedMarkItem;
				item.SetUIActive(selectedMarkItem != null && !selectedMarkItem.IsFogUnlock);
			}
			UUIText text3 = base.GetText(10);
			if (text3 != null)
			{
				text3.ShowTextNew("Instance_Dungeon_Rcommand_Text");
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(36), "Instance_RogueInstanceEntrance_Progress", Array.Empty<object>());
			bool flag = base.UpdateQuickGoto();
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext == null)
			{
				return;
			}
			layoutContext.SetConfirmBtnActive(!flag);
		}

		// Token: 0x06032926 RID: 207142 RVA: 0x00CA989C File Offset: 0x00CA7A9C
		private void RefreshReward()
		{
			ActivityRogueController instance = ControllerBase<ActivityRogueController>.Instance;
			List<TItem> list;
			if (instance == null)
			{
				list = null;
			}
			else
			{
				ActivityRogueData currentActivityData = instance.GetCurrentActivityData();
				list = ((currentActivityData != null) ? currentActivityData.GetPreviewReward(null) : null);
			}
			List<TItem> list2 = list;
			if (list2 == null || list2.Count == 0)
			{
				UUIItem item = base.GetItem(8);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				int num = Math.Min(list2.Count, 5);
				TItem[] array = new TItem[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = list2[i];
				}
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Count = 0;
				}
				UUIItem item2 = base.GetItem(8);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				RewardItemBar rewardsView = this.RewardsView;
				if (rewardsView == null)
				{
					return;
				}
				rewardsView.RebuildRewardsByData(array.ToList<TItem>());
				return;
			}
		}

		// Token: 0x06032927 RID: 207143 RVA: 0x00CA996C File Offset: 0x00CA7B6C
		private void UpdateInstanceList()
		{
			InstanceDungeonEntranceConfig instance = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
			int? num = (instance != null) ? new int?(instance.GetInstanceDungeonEntranceFlowId(this.EntranceId)) : null;
			this.RefreshReward();
			if (num.GetValueOrDefault() == 6)
			{
				RoguelikeModel instance2 = ModelBase<RoguelikeModel>.Instance;
				if (instance2 == null || !instance2.CheckRogueIsOpen())
				{
					this.RefreshEmptyItem();
					return;
				}
				this.RefreshTimeItem();
				this.RefreshDifficultyItem();
				this.RefreshAchievementItem();
				this.RefreshShopProgressItem();
				if (this.TimerId != null)
				{
					TimerSystem.Instance.Remove(this.TimerId);
				}
				this.TimerId = TimerSystem.Instance.Forever(delegate(float delta)
				{
					this.RefreshTimeItem();
				}, 1000f, 1f, null, null, true);
			}
		}

		// Token: 0x06032928 RID: 207144 RVA: 0x00CA9A28 File Offset: 0x00CA7C28
		private void RefreshEmptyItem()
		{
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.AddItemToLayout(new object[]
				{
					"rougeScore"
				}, 0);
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView2 = this.InstanceCostTipView;
			InstanceDungeonCostTip instanceDungeonCostTip = ((instanceCostTipView2 != null) ? instanceCostTipView2.GetLayoutItemByKey("rougeScore", 0) : null) as InstanceDungeonCostTip;
			if (instanceDungeonCostTip == null)
			{
				return;
			}
			instanceDungeonCostTip.SetIconVisible(false);
			instanceDungeonCostTip.SetStarVisible(false);
			instanceDungeonCostTip.SetRightText("");
			instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("Rogue_Function_End_Tip", null) ?? "");
			instanceDungeonCostTip.SetHelpButtonVisible(false);
		}

		// Token: 0x06032929 RID: 207145 RVA: 0x00CA9AB4 File Offset: 0x00CA7CB4
		private void RefreshTimeItem()
		{
			ActivityRogueController instance = ControllerBase<ActivityRogueController>.Instance;
			bool flag;
			if (instance == null)
			{
				flag = (null != null);
			}
			else
			{
				ActivityRogueData currentActivityData = instance.GetCurrentActivityData();
				flag = (((currentActivityData != null) ? currentActivityData.SeasonData : null) != null);
			}
			if (!flag)
			{
				return;
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			InstanceDungeonCostTip instanceDungeonCostTip = ((instanceCostTipView != null) ? instanceCostTipView.GetLayoutItemByKey("rogueTime", 0) : null) as InstanceDungeonCostTip;
			if (instanceDungeonCostTip == null)
			{
				GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView2 = this.InstanceCostTipView;
				if (instanceCostTipView2 != null)
				{
					instanceCostTipView2.AddItemToLayout(new object[]
					{
						"rogueTime"
					}, 0);
				}
				GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView3 = this.InstanceCostTipView;
				instanceDungeonCostTip = (((instanceCostTipView3 != null) ? instanceCostTipView3.GetLayoutItemByKey("rogueTime", 0) : null) as InstanceDungeonCostTip);
			}
			if (instanceDungeonCostTip == null)
			{
				return;
			}
			instanceDungeonCostTip.SetIconVisible(false);
			instanceDungeonCostTip.SetStarVisible(false);
			string remainTime = this.GetRemainTime();
			instanceDungeonCostTip.SetRightText(remainTime);
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_Rogue_Time", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip.SetLeftText(leftText);
			instanceDungeonCostTip.SetHelpButtonVisible(false);
		}

		// Token: 0x0603292A RID: 207146 RVA: 0x00CA9B98 File Offset: 0x00CA7D98
		private unsafe void RefreshDifficultyItem()
		{
			ActivityRogueController instance = ControllerBase<ActivityRogueController>.Instance;
			RogueSeasonData rogueSeasonData;
			if (instance == null)
			{
				rogueSeasonData = null;
			}
			else
			{
				ActivityRogueData currentActivityData = instance.GetCurrentActivityData();
				rogueSeasonData = ((currentActivityData != null) ? currentActivityData.SeasonData : null);
			}
			RogueSeasonData rogueSeasonData2 = rogueSeasonData;
			if (rogueSeasonData2 == null)
			{
				return;
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.AddItemToLayout(new object[]
				{
					"rogueDifficultyProgress"
				}, 0);
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView2 = this.InstanceCostTipView;
			InstanceDungeonCostTip instanceDungeonCostTip = ((instanceCostTipView2 != null) ? instanceCostTipView2.GetLayoutItemByKey("rogueDifficultyProgress", 0) : null) as InstanceDungeonCostTip;
			if (instanceDungeonCostTip == null)
			{
				return;
			}
			instanceDungeonCostTip.SetIconVisible(false);
			instanceDungeonCostTip.SetStarVisible(false);
			RoguelikeConfig instance2 = ConfigBase<RoguelikeConfig>.Instance;
			RogueSeason? rogueSeason = (instance2 != null) ? instance2.GetRogueSeasonConfigById(rogueSeasonData2.SeasonId) : null;
			InstanceDungeonEntranceConfig instance3 = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
			InstanceDungeonEntrance? instanceDungeonEntrance = (instance3 != null) ? instance3.GetConfig((rogueSeason != null) ? rogueSeason.GetValueOrDefault().InstanceDungeonEntrance : 0) : null;
			if (instanceDungeonEntrance != null && instanceDungeonEntrance.GetValueOrDefault().InstanceDungeonListLength <= 0)
			{
				return;
			}
			int num = 0;
			Span<int> instanceDungeonListBytes = instanceDungeonEntrance.Value.GetInstanceDungeonListBytes();
			for (int i = 0; i < instanceDungeonListBytes.Length; i++)
			{
				int num2 = *instanceDungeonListBytes[i];
				if (!ModelBase<ExchangeRewardModel>.Instance.IsFinishInstance(num2))
				{
					num = num2;
					break;
				}
			}
			if (num == 0 && instanceDungeonEntrance.Value.InstanceDungeonListLength > 0)
			{
				num = instanceDungeonEntrance.Value.InstanceDungeonList(instanceDungeonEntrance.Value.InstanceDungeonListLength - 1);
			}
			InstanceDungeonConfig instance4 = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon = (instance4 != null) ? instance4.GetConfig(num) : null;
			instanceDungeonCostTip.SetRightText(ConfigMultiTextLang.GetLocalTextNew(((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().DifficultyDesc(0) : null) ?? "", null) ?? "");
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_Rogue_Difficulty_Process", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip.SetLeftText(leftText);
			instanceDungeonCostTip.SetHelpButtonVisible(false);
		}

		// Token: 0x0603292B RID: 207147 RVA: 0x00CA9DAC File Offset: 0x00CA7FAC
		private void RefreshAchievementItem()
		{
			ActivityRogueController instance = ControllerBase<ActivityRogueController>.Instance;
			RogueSeasonData rogueSeasonData;
			if (instance == null)
			{
				rogueSeasonData = null;
			}
			else
			{
				ActivityRogueData currentActivityData = instance.GetCurrentActivityData();
				rogueSeasonData = ((currentActivityData != null) ? currentActivityData.SeasonData : null);
			}
			RogueSeasonData rogueSeasonData2 = rogueSeasonData;
			if (rogueSeasonData2 == null)
			{
				return;
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.AddItemToLayout(new object[]
				{
					"rogueAchievementProgress"
				}, 0);
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView2 = this.InstanceCostTipView;
			InstanceDungeonCostTip instanceDungeonCostTip = ((instanceCostTipView2 != null) ? instanceCostTipView2.GetLayoutItemByKey("rogueAchievementProgress", 0) : null) as InstanceDungeonCostTip;
			if (instanceDungeonCostTip == null)
			{
				return;
			}
			instanceDungeonCostTip.SetIconVisible(false);
			instanceDungeonCostTip.SetStarVisible(false);
			RoguelikeConfig instance2 = ConfigBase<RoguelikeConfig>.Instance;
			RogueSeason? rogueSeason = (instance2 != null) ? instance2.GetRogueSeasonConfigById(rogueSeasonData2.SeasonId) : null;
			if (rogueSeason == null)
			{
				return;
			}
			AchievementModel instance3 = ModelBase<AchievementModel>.Instance;
			List<AchievementGroupData> list = (instance3 != null) ? instance3.GetAchievementCategoryGroups(rogueSeason.Value.Achievement, true) : null;
			int num = 0;
			int num2 = 0;
			if (list != null)
			{
				foreach (AchievementGroupData achievementGroupData in list)
				{
					AchievementModel instance4 = ModelBase<AchievementModel>.Instance;
					AchievementGroupData achievementGroupData2 = (instance4 != null) ? instance4.GetAchievementGroupData(new int?(achievementGroupData.GetId())) : null;
					if (achievementGroupData2 != null)
					{
						num += achievementGroupData2.GetCurrentProgress();
						num2 += achievementGroupData2.GetMaxProgress();
					}
				}
			}
			string rightText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_Rogue_Score", null) ?? "{0}/{1}", new string[]
			{
				num.ToString(),
				num2.ToString()
			});
			instanceDungeonCostTip.SetRightText(rightText);
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_Rogue_Achievement_Count", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip.SetLeftText(leftText);
			instanceDungeonCostTip.SetHelpButtonVisible(false);
		}

		// Token: 0x0603292C RID: 207148 RVA: 0x00CA9F70 File Offset: 0x00CA8170
		private void RefreshShopProgressItem()
		{
			ActivityRogueController instance = ControllerBase<ActivityRogueController>.Instance;
			RogueSeasonData rogueSeasonData;
			if (instance == null)
			{
				rogueSeasonData = null;
			}
			else
			{
				ActivityRogueData currentActivityData = instance.GetCurrentActivityData();
				rogueSeasonData = ((currentActivityData != null) ? currentActivityData.SeasonData : null);
			}
			RogueSeasonData rogueSeasonData2 = rogueSeasonData;
			if (rogueSeasonData2 == null)
			{
				return;
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.AddItemToLayout(new object[]
				{
					"rougeScore"
				}, 0);
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView2 = this.InstanceCostTipView;
			InstanceDungeonCostTip instanceDungeonCostTip = ((instanceCostTipView2 != null) ? instanceCostTipView2.GetLayoutItemByKey("rougeScore", 0) : null) as InstanceDungeonCostTip;
			if (instanceDungeonCostTip == null)
			{
				return;
			}
			instanceDungeonCostTip.SetIconVisible(false);
			instanceDungeonCostTip.SetStarVisible(false);
			RoguelikeModel instance2 = ModelBase<RoguelikeModel>.Instance;
			RogueParam? rogueParam;
			int valueOrDefault = ((instance2 != null) ? ((instance2.GetParamConfigBySeasonId(null) != null) ? new int?(rogueParam.GetValueOrDefault().WeekTokenMaxCount) : null) : null).GetValueOrDefault(1);
			string rightText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_Rogue_Score", null) ?? "{0}/{1}", new string[]
			{
				rogueSeasonData2.TokenItemCount.ToString(),
				valueOrDefault.ToString()
			});
			instanceDungeonCostTip.SetRightText(rightText);
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_Rogue_Week_Score", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip.SetLeftText(leftText);
			instanceDungeonCostTip.SetHelpButtonVisible(false);
		}

		// Token: 0x0603292D RID: 207149 RVA: 0x00CAA0C5 File Offset: 0x00CA82C5
		protected override void OnCloseWorldMapSecondaryUi()
		{
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView == null)
			{
				return;
			}
			instanceCostTipView.ClearChildren();
		}

		// Token: 0x0603292E RID: 207150 RVA: 0x00CAA0D7 File Offset: 0x00CA82D7
		public override UUIItem GetGuideFocusUiItem()
		{
			return base.GetButton(11).GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
		}

		// Token: 0x0603292F RID: 207151 RVA: 0x00CAA0FC File Offset: 0x00CA82FC
		protected string GetRemainTime()
		{
			ActivityRogueController instance = ControllerBase<ActivityRogueController>.Instance;
			ActivityRogueData activityRogueData = (instance != null) ? instance.GetCurrentActivityData() : null;
			if (activityRogueData == null)
			{
				return "";
			}
			bool flag = activityRogueData.CheckIfInShowTime();
			bool flag2 = activityRogueData.CheckIfInOpenTime();
			if (!flag2 && !flag)
			{
				TextConfig instance2 = ConfigBase<TextConfig>.Instance;
				return ((instance2 != null) ? instance2.GetTextContentIdById("ActiveClose") : null) ?? "";
			}
			long endOpenTime = activityRogueData.EndOpenTime;
			long endShowTime = activityRogueData.EndShowTime;
			long num;
			if (activityRogueData.EndOpenTime == 0L)
			{
				num = endShowTime;
			}
			else
			{
				num = (flag2 ? endOpenTime : endShowTime);
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double num2 = Math.Max((double)num - serverTime, 1.0);
			CommonDefine.ETimeType[] timeTypeData = this.GetTimeTypeData(num2);
			return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num2, new CommonDefine.ETimeType?(timeTypeData[0]), new CommonDefine.ETimeType?(timeTypeData[1])).CountDownText ?? "";
		}

		// Token: 0x06032930 RID: 207152 RVA: 0x00CAA1DC File Offset: 0x00CA83DC
		private CommonDefine.ETimeType[] GetTimeTypeData(double remainTime)
		{
			if (remainTime > 86400.0)
			{
				return new CommonDefine.ETimeType[]
				{
					CommonDefine.ETimeType.Day,
					CommonDefine.ETimeType.Hour
				};
			}
			if (remainTime > 3600.0)
			{
				return new CommonDefine.ETimeType[]
				{
					CommonDefine.ETimeType.Hour,
					CommonDefine.ETimeType.Minute
				};
			}
			if (remainTime > 60.0)
			{
				CommonDefine.ETimeType[] array = new CommonDefine.ETimeType[2];
				array[0] = CommonDefine.ETimeType.Minute;
				return array;
			}
			return new CommonDefine.ETimeType[2];
		}

		// Token: 0x0401D7B1 RID: 120753
		private const string ROGUE_SCORE_KEY = "rougeScore";

		// Token: 0x0401D7B2 RID: 120754
		private const string ROGUE_TIME = "rogueTime";

		// Token: 0x0401D7B3 RID: 120755
		private const string ROGUE_ACHIEVEMENT_PROGRESS = "rogueAchievementProgress";

		// Token: 0x0401D7B4 RID: 120756
		private const string ROGUE_DIFFICULTY_PROGRESS = "rogueDifficultyProgress";

		// Token: 0x0401D7B5 RID: 120757
		private int EntranceId;

		// Token: 0x0401D7B6 RID: 120758
		[Nullable(2)]
		private TeleportMarkItem SelectedMarkItem;

		// Token: 0x0401D7B7 RID: 120759
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutAdd<InstanceDungeonCostTip> InstanceCostTipView;

		// Token: 0x0401D7B8 RID: 120760
		[Nullable(2)]
		private TimerHandle TimerId;

		// Token: 0x0401D7B9 RID: 120761
		[Nullable(2)]
		protected RewardItemBar RewardsView;

		// Token: 0x0200AC84 RID: 44164
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x040359F4 RID: 219636
			public const int RoguelikePanel = 0;
		}
	}
}
