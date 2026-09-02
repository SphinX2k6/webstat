using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge
{
	// Token: 0x0200677C RID: 26492
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityFlagChallengeController : ActivityControllerBase<ActivityFlagChallengeController>
	{
		// Token: 0x060420A9 RID: 270505 RVA: 0x010F1ECC File Offset: 0x010F00CC
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x060420AA RID: 270506 RVA: 0x010F1EEA File Offset: 0x010F00EA
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x060420AB RID: 270507 RVA: 0x010F1F08 File Offset: 0x010F0108
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			ActivityFlagChallengeController.<OnOpenSubView>d__3 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<ActivityFlagChallengeController.<OnOpenSubView>d__3>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x060420AC RID: 270508 RVA: 0x010F1F54 File Offset: 0x010F0154
		protected override void OnOpenView(ActivityBaseData data)
		{
			if (!data.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = data.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeMainView(data.Id, null);
		}

		// Token: 0x060420AD RID: 270509 RVA: 0x010F1FA0 File Offset: 0x010F01A0
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_FlagChallengeMain";
		}

		// Token: 0x060420AE RID: 270510 RVA: 0x010F1FA7 File Offset: 0x010F01A7
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityFlagChallengeSubView();
		}

		// Token: 0x060420AF RID: 270511 RVA: 0x010F1FAE File Offset: 0x010F01AE
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.Data = new ActivityFlagChallengeData();
			return this.Data;
		}

		// Token: 0x060420B0 RID: 270512 RVA: 0x010F1FC4 File Offset: 0x010F01C4
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			foreach (EUiViewName viewName in new List<EUiViewName>
			{
				EUiViewName.FlagChallengeMainView,
				EUiViewName.FlagChallengeAreaDetailView
			})
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060420B1 RID: 270513 RVA: 0x010F203C File Offset: 0x010F023C
		private void OnWorldDone()
		{
			if (!ModelBase<FlagChallengeBattleModel>.Instance.IsNeedShowMainView)
			{
				return;
			}
			ModelBase<FlagChallengeBattleModel>.Instance.IsNeedShowMainView = false;
			if (this.Data == null || this.Data.CheckIfClose())
			{
				return;
			}
			this.AddMainViewSplashTask();
		}

		// Token: 0x060420B2 RID: 270514 RVA: 0x010F2074 File Offset: 0x010F0274
		private void AddMainViewSplashTask()
		{
			if (this.Data == null)
			{
				return;
			}
			SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
			{
				ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeMainView(this.Data.Id, null);
			});
			ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
		}

		// Token: 0x04024D23 RID: 150819
		[Nullable(2)]
		public ActivityFlagChallengeData Data;
	}
}
