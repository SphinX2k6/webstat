using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068CB RID: 26827
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchSubView : ActivitySubViewBase
	{
		// Token: 0x06042B6D RID: 273261 RVA: 0x0111FA14 File Offset: 0x0111DC14
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06042B6E RID: 273262 RVA: 0x0111FA70 File Offset: 0x0111DC70
		protected override UniTask OnBeforeStartAsync()
		{
			DropCatchSubView.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DropCatchSubView.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042B6F RID: 273263 RVA: 0x0111FAB3 File Offset: 0x0111DCB3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.DropCatchActivityRewardUpdate, new Action(this.RefreshProgress));
		}

		// Token: 0x06042B70 RID: 273264 RVA: 0x0111FAD1 File Offset: 0x0111DCD1
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.DropCatchActivityRewardUpdate, new Action(this.RefreshProgress));
		}

		// Token: 0x06042B71 RID: 273265 RVA: 0x0111FAEF File Offset: 0x0111DCEF
		protected override void OnRefreshView()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.OnRefreshView();
			}
			this.RefreshProgress();
			this.RefreshCondition();
			this.RefreshRecommendQuestTips();
		}

		// Token: 0x06042B72 RID: 273266 RVA: 0x0111FB14 File Offset: 0x0111DD14
		private void ClickCommonInfo()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("CoinCatch_MultiBan_Text", Array.Empty<object>());
				return;
			}
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			if (((activityBaseData != null) ? new bool?(activityBaseData.GetPreGuideQuestFinishState()) : null).GetValueOrDefault())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DropCatchLevelSelectView, null, null);
			}
			else
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityBaseData.Id);
		}

		// Token: 0x06042B73 RID: 273267 RVA: 0x0111FBBC File Offset: 0x0111DDBC
		private void OnRecommendBtnClick()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("DropCatchPreQuestId");
			if (ModelBase<QuestNewModel>.Instance.GetQuest(intConfig.Value) == null)
			{
				string stringConfig = ConfigCommonParamById.GetStringConfig("DropCatchPreQuestTips");
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(stringConfig, Array.Empty<object>());
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, intConfig, null);
		}

		// Token: 0x06042B74 RID: 273268 RVA: 0x0111FC1C File Offset: 0x0111DE1C
		private void RefreshRecommendQuestTips()
		{
			bool flag = this.IsShowPreOpenTips();
			this.RecommendQuestTipsSubPanel.SetUiActive(flag);
			if (flag)
			{
				string stringConfig = ConfigCommonParamById.GetStringConfig("DropCatchPreQuestTips");
				this.RecommendQuestTipsSubPanel.SetTipsTxtByTextId(stringConfig, Array.Empty<string>());
			}
		}

		// Token: 0x06042B75 RID: 273269 RVA: 0x0111FC5C File Offset: 0x0111DE5C
		private bool IsShowPreOpenTips()
		{
			int num = this.ActivityBaseData.IsUnLock() ? 1 : 0;
			bool flag = this.ActivityBaseData.CanPreOpen();
			return num == 0 && flag;
		}

		// Token: 0x06042B76 RID: 273270 RVA: 0x0111FC88 File Offset: 0x0111DE88
		private void RefreshCondition()
		{
			ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
			ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "LongShanStage_Join01",
				UnlockBtnFunction = new Action(this.ClickCommonInfo)
			};
			functional.RefreshGeneralPerformance(parameters);
		}

		// Token: 0x06042B77 RID: 273271 RVA: 0x0111FCCC File Offset: 0x0111DECC
		private void RefreshProgress()
		{
			DropCatchActivityData dropCatchActivityData = this.ActivityBaseData as DropCatchActivityData;
			if (dropCatchActivityData != null)
			{
				int finishLevelCount = dropCatchActivityData.GetFinishLevelCount();
				IReadOnlyList<DropCatchGameplay> dropCatchGameplayByActivityId = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayByActivityId(dropCatchActivityData.Id);
				int value = (dropCatchGameplayByActivityId != null) ? dropCatchGameplayByActivityId.Count : 0;
				UUIText text = base.GetText(1);
				if (text != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#81e869>");
					defaultInterpolatedStringHandler.AppendFormatted<int>(finishLevelCount);
					defaultInterpolatedStringHandler.AppendLiteral("</color>/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(value);
					text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
				bool canReceive = dropCatchActivityData.GetCanReceive();
				ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
				if (commonInfoPanel == null)
				{
					return;
				}
				ActivityFunctionalTypeA functional = commonInfoPanel.GetFunctional();
				if (functional == null)
				{
					return;
				}
				ActivityButtonItem functionButton = functional.FunctionButton;
				if (functionButton == null)
				{
					return;
				}
				functionButton.SetRedDotVisible(canReceive);
			}
		}

		// Token: 0x040252D4 RID: 152276
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x040252D5 RID: 152277
		private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanel;
	}
}
