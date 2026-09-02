using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity
{
	// Token: 0x02006477 RID: 25719
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewRogue : ActivitySubViewBase
	{
		// Token: 0x06040816 RID: 264214 RVA: 0x01087C10 File Offset: 0x01085E10
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(4, new Action(this.OnBtnAchievement)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnBtnShop))
			};
		}

		// Token: 0x06040817 RID: 264215 RVA: 0x01087D58 File Offset: 0x01085F58
		protected void OnBtnAchievement()
		{
			if (ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData().GetRogueActivityState() == ERogueActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			ActivityRogueData activityRogueData = this.ActivityBaseData as ActivityRogueData;
			RogueSeasonData rogueSeasonData = (activityRogueData != null) ? activityRogueData.SeasonData : null;
			if (rogueSeasonData == null)
			{
				return;
			}
			if (ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId).Value.Achievement == 0)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeAchievementView, null, null);
		}

		// Token: 0x06040818 RID: 264216 RVA: 0x01087DDC File Offset: 0x01085FDC
		protected void OnBtnShop()
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
			if (currentActivityData.GetRogueActivityState() == ERogueActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
			if (rogueSeasonData == null)
			{
				return;
			}
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId);
			if (rogueSeasonConfigById.Value.ShopId == 0)
			{
				return;
			}
			PayShopViewData payShopViewData = new PayShopViewData();
			payShopViewData.ShowShopIdList = new List<int>
			{
				rogueSeasonConfigById.Value.ShopId
			};
			payShopViewData.PayShopId = (PayShopDefine.EPayShopTabType)rogueSeasonConfigById.Value.ShopId;
			ModelBase<RoguelikeModel>.Instance.RecordRoguelikeShopRedDot();
			ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, null);
		}

		// Token: 0x06040819 RID: 264217 RVA: 0x01087E9A File Offset: 0x0108609A
		protected override void OnSetData()
		{
		}

		// Token: 0x0604081A RID: 264218 RVA: 0x01087E9C File Offset: 0x0108609C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewRogue.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewRogue.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604081B RID: 264219 RVA: 0x01087EE0 File Offset: 0x010860E0
		protected override void OnStart()
		{
			Activity? localConfig = (this.ActivityBaseData as ActivityRogueData).LocalConfig;
			RogueActivity? extraConfig = (this.ActivityBaseData as ActivityRogueData).GetExtraConfig();
			if (localConfig == null || extraConfig == null)
			{
				return;
			}
			string descTheme = localConfig.Value.DescTheme;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.TitleComponent.SetSubTitleVisible(flag);
			if (flag)
			{
				this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			}
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData as ActivityRogueData);
			this.TitleComponent.SetTitleByText((this.ActivityBaseData as ActivityRogueData).GetTitle());
			string desc = localConfig.Value.Desc;
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
			List<TItem> previewReward = (this.ActivityBaseData as ActivityRogueData).GetPreviewReward(null);
			this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
			this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.FunctionExecute));
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("CollectActivity_Button_ahead", null);
			this.FunctionalComponent.FunctionButton.SetText(localTextNew);
			this.OnRefreshView();
		}

		// Token: 0x0604081C RID: 264220 RVA: 0x0108804C File Offset: 0x0108624C
		protected override UniTask OnBeforeHideSelfAsync()
		{
			ActivitySubViewRogue.<OnBeforeHideSelfAsync>d__11 <OnBeforeHideSelfAsync>d__;
			<OnBeforeHideSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideSelfAsync>d__.<>1__state = -1;
			<OnBeforeHideSelfAsync>d__.<>t__builder.Start<ActivitySubViewRogue.<OnBeforeHideSelfAsync>d__11>(ref <OnBeforeHideSelfAsync>d__);
			return <OnBeforeHideSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604081D RID: 264221 RVA: 0x01088088 File Offset: 0x01086288
		protected override void OnRefreshView()
		{
			this.RefreshCondition();
			this.RefreshTimerText();
			this.RefreshRedDot();
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoguelikeAchievement, base.GetItem(6), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoguelikeShop, base.GetItem(7), delegate(bool newState, int _)
			{
				UUIItem item = base.GetItem(7);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(newState);
			}, 0);
			bool preGuideQuestFinishState = (this.ActivityBaseData as ActivityRogueData).GetPreGuideQuestFinishState();
			base.GetItem(8).SetUIActive(preGuideQuestFinishState);
			base.GetItem(9).SetUIActive(preGuideQuestFinishState);
		}

		// Token: 0x0604081E RID: 264222 RVA: 0x01088108 File Offset: 0x01086308
		protected override void OnTimer(float gap)
		{
			this.RefreshCondition();
			this.RefreshTimerText();
			this.RefreshRedDot();
		}

		// Token: 0x0604081F RID: 264223 RVA: 0x0108811C File Offset: 0x0108631C
		private void RefreshRedDot()
		{
			ActivityFunctionalTypeA functionalComponent = this.FunctionalComponent;
			if (functionalComponent == null)
			{
				return;
			}
			functionalComponent.SetFunctionRedDotVisible((this.ActivityBaseData as ActivityRogueData).RedPointShowState);
		}

		// Token: 0x06040820 RID: 264224 RVA: 0x01088140 File Offset: 0x01086340
		private void RefreshTimerText()
		{
			string item = this.GetTimeVisibleAndRemainTime().Item2;
			this.TitleComponent.SetTimeTextByText(item);
		}

		// Token: 0x06040821 RID: 264225 RVA: 0x01088168 File Offset: 0x01086368
		private void FunctionExecute()
		{
			bool preGuideQuestFinishState = (this.ActivityBaseData as ActivityRogueData).GetPreGuideQuestFinishState();
			ERogueActivityState rogueActivityState = (this.ActivityBaseData as ActivityRogueData).GetRogueActivityState();
			if (!preGuideQuestFinishState && rogueActivityState == ERogueActivityState.Open)
			{
				int unFinishPreGuideQuestId = (this.ActivityBaseData as ActivityRogueData).GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			}
			else
			{
				ControllerBase<ActivityRogueController>.Instance.ActivityFunctionExecute((this.ActivityBaseData as ActivityRogueData).Id);
			}
			(this.ActivityBaseData as ActivityRogueData).FunctionBtnRedDot = false;
		}

		// Token: 0x06040822 RID: 264226 RVA: 0x010881F0 File Offset: 0x010863F0
		private void RefreshCondition()
		{
			RogueActivity? extraConfig = (this.ActivityBaseData as ActivityRogueData).GetExtraConfig();
			if (extraConfig == null)
			{
				return;
			}
			bool flag = (this.ActivityBaseData as ActivityRogueData).IsUnLock();
			bool flag2 = extraConfig.Value.FunctionType == 0;
			if (!flag)
			{
				ActivityButtonItem functionButton = this.FunctionalComponent.FunctionButton;
				if (functionButton != null)
				{
					functionButton.SetUiActive(false);
				}
				this.FunctionalComponent.SetPerformanceConditionLock((this.ActivityBaseData as ActivityRogueData).ConditionGroupId, (this.ActivityBaseData as ActivityRogueData).Id);
				return;
			}
			if (flag2)
			{
				ActivityButtonItem functionButton2 = this.FunctionalComponent.FunctionButton;
				if (functionButton2 != null)
				{
					functionButton2.SetUiActive(false);
				}
				this.FunctionalComponent.SetPanelConditionVisible(false);
				return;
			}
			ERogueActivityState rogueActivityState = (this.ActivityBaseData as ActivityRogueData).GetRogueActivityState();
			ActivityButtonItem functionButton3 = this.FunctionalComponent.FunctionButton;
			if (functionButton3 != null)
			{
				functionButton3.SetUiActive(rogueActivityState != ERogueActivityState.Close);
			}
			this.FunctionalComponent.SetPanelConditionVisible(rogueActivityState == ERogueActivityState.Close);
			this.FunctionalComponent.SetLockTextByTextId("Rogue_Function_End_Tip", Array.Empty<string>());
		}

		// Token: 0x040241B4 RID: 147892
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x040241B5 RID: 147893
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x040241B6 RID: 147894
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x040241B7 RID: 147895
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x040241B8 RID: 147896
		private RoguelikeBlackFlowerItem BlackFlowerComponent;
	}
}
