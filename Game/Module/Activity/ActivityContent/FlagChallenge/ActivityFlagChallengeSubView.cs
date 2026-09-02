using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FlagChallenge;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge
{
	// Token: 0x0200677F RID: 26495
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityFlagChallengeSubView : ActivitySubViewBase
	{
		// Token: 0x060420B9 RID: 270521 RVA: 0x010F21D0 File Offset: 0x010F03D0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIArtText)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText))
			};
		}

		// Token: 0x060420BA RID: 270522 RVA: 0x010F22C8 File Offset: 0x010F04C8
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityFlagChallengeSubView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityFlagChallengeSubView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060420BB RID: 270523 RVA: 0x010F230B File Offset: 0x010F050B
		protected override void OnRefreshView()
		{
			base.GetText(2).ShowTextNew("Morale_32_Activity_DifficultTip");
			this.UpdateGuideQuestState();
			this.UpdateLevelInfo();
			this.UpdateNewLevelTips();
			this.UpdateRemainTime();
			this.UpdateRedDot();
		}

		// Token: 0x060420BC RID: 270524 RVA: 0x010F233C File Offset: 0x010F053C
		protected override void OnTimer(float gap)
		{
			this.UpdateRemainTime();
		}

		// Token: 0x060420BD RID: 270525 RVA: 0x010F2344 File Offset: 0x010F0544
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeLevelNewlyUnlock, new Action<int>(this.OnLevelNewlyUnlock));
		}

		// Token: 0x060420BE RID: 270526 RVA: 0x010F2362 File Offset: 0x010F0562
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeLevelNewlyUnlock, new Action<int>(this.OnLevelNewlyUnlock));
		}

		// Token: 0x060420BF RID: 270527 RVA: 0x010F2380 File Offset: 0x010F0580
		[NullableContext(2)]
		private void OnCommonInfoClick(ActivityBaseData _)
		{
			ControllerBase<ActivityController>.Instance.OpenActivityContentView(this.ActivityBaseData);
		}

		// Token: 0x060420C0 RID: 270528 RVA: 0x010F2394 File Offset: 0x010F0594
		private void UpdateLevelInfo()
		{
			int id = this.ActivityBaseData.Id;
			int fixedLevel = ModelBase<FlagChallengeModel>.Instance.GetFixedLevel(id);
			base.GetArtText(7).SetText(fixedLevel.ToString());
			FlagChallengeLevel levelConfig = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(id).GetLevelData(ModelBase<FlagChallengeModel>.Instance.GetRecommendLevel(id, true).Value).LevelConfig;
			base.GetText(6).ShowTextNew(levelConfig.Name);
		}

		// Token: 0x060420C1 RID: 270529 RVA: 0x010F240C File Offset: 0x010F060C
		private void UpdateGuideQuestState()
		{
			ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
			if (!this.ActivityBaseData.IsUnLock())
			{
				ActivityButtonItem functionButton = functional.FunctionButton;
				if (functionButton != null)
				{
					functionButton.SetUiActive(false);
				}
				functional.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
				return;
			}
			bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
			if (functional != null)
			{
				functional.SetPanelConditionVisible(false);
			}
			if (preGuideQuestFinishState)
			{
				this.CommonInfoPanel.SetBtnText("Morale_32_Activity_EnterButt", Array.Empty<object>());
				return;
			}
			this.CommonInfoPanel.SetBtnText("Morale_title_36", Array.Empty<object>());
			string preShowGuideQuestName = this.ActivityBaseData.GetPreShowGuideQuestName();
			if (functional != null)
			{
				ActivityButtonItem functionButton2 = functional.FunctionButton;
				if (functionButton2 != null)
				{
					functionButton2.SetUiActive(true);
				}
			}
			if (functional != null)
			{
				functional.SetPanelConditionVisible(true);
			}
			if (functional != null)
			{
				functional.SetLockSpriteVisible(false);
			}
			if (functional != null)
			{
				functional.SetLockConditionButtonVisible(false);
			}
			if (functional != null)
			{
				functional.SetLockTextByTextId("Morale_title_35", new string[]
				{
					preShowGuideQuestName
				});
			}
		}

		// Token: 0x060420C2 RID: 270530 RVA: 0x010F24FC File Offset: 0x010F06FC
		private void UpdateNewLevelTips()
		{
			bool active = this.IsShowNewLevelTips();
			this.NewLevelTipsSubPanel.SetActive(active);
		}

		// Token: 0x060420C3 RID: 270531 RVA: 0x010F251C File Offset: 0x010F071C
		private bool IsShowNewLevelTips()
		{
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			return activityBaseData.IsUnLock() && activityBaseData.GetPreGuideQuestFinishState() && ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityBaseData.Id).HasLevelNewlyUnlocked();
		}

		// Token: 0x060420C4 RID: 270532 RVA: 0x010F255C File Offset: 0x010F075C
		private void UpdateRemainTime()
		{
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityBaseData.EndShowTime, this.RemainTimeFormatText);
			UUIText text = base.GetText(9);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x060420C5 RID: 270533 RVA: 0x010F2599 File Offset: 0x010F0799
		private void UpdateRedDot()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			ActivityFunctionalTypeA activityFunctionalTypeA = (commonInfoPanel != null) ? commonInfoPanel.GetFunctional() : null;
			if (activityFunctionalTypeA == null)
			{
				return;
			}
			activityFunctionalTypeA.SetFunctionRedDotVisible(this.IsShowNewLevelTips());
		}

		// Token: 0x060420C6 RID: 270534 RVA: 0x010F25BD File Offset: 0x010F07BD
		private void OnLevelNewlyUnlock(int levelId)
		{
			this.UpdateNewLevelTips();
			this.UpdateRedDot();
		}

		// Token: 0x060420C7 RID: 270535 RVA: 0x010F25CC File Offset: 0x010F07CC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (!(configParams[0] == "Chaqi_ConfirmBtn"))
			{
				return null;
			}
			UUIItem functionalButtonItem = this.CommonInfoPanel.GetFunctionalButtonItem();
			if (functionalButtonItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				functionalButtonItem,
				functionalButtonItem
			};
		}

		// Token: 0x04024D2F RID: 150831
		private ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x04024D30 RID: 150832
		private FlagChallengeActivityRewardEntranceItem RewardEntrance;

		// Token: 0x04024D31 RID: 150833
		private RecommendQuestTipsSubPanel NewLevelTipsSubPanel;

		// Token: 0x04024D32 RID: 150834
		private string RemainTimeFormatText = "";
	}
}
