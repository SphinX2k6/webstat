using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005E97 RID: 24215
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class CiacconaGalController : ControllerBase<CiacconaGalController>
	{
		// Token: 0x17009981 RID: 39297
		// (get) Token: 0x0603CE4C RID: 249420 RVA: 0x00F7860E File Offset: 0x00F7680E
		protected override bool IsTickEvenPausedInternal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17009982 RID: 39298
		// (get) Token: 0x0603CE4D RID: 249421 RVA: 0x00F78611 File Offset: 0x00F76811
		[Nullable(2)]
		public CiacconaGalPlayer GalPlayer
		{
			[NullableContext(2)]
			get
			{
				return this.InternalGalPlayer;
			}
		}

		// Token: 0x0603CE4E RID: 249422 RVA: 0x00F78619 File Offset: 0x00F76819
		protected override bool OnInit()
		{
			this.InternalGalPlayer = Singleton<CiacconaGalPlayer>.Instance;
			this.AddNetListeners();
			return true;
		}

		// Token: 0x0603CE4F RID: 249423 RVA: 0x00F7862D File Offset: 0x00F7682D
		protected override bool OnClear()
		{
			this.AvgDataUpdateDelegates = new List<Action<int>>();
			this.InternalGalPlayer.Release();
			this.RemoveNetListeners();
			return true;
		}

		// Token: 0x0603CE50 RID: 249424 RVA: 0x00F7864C File Offset: 0x00F7684C
		protected override void OnTick(float delta)
		{
			this.TickAvg(delta);
			this.TickDataUpdate(delta);
		}

		// Token: 0x0603CE51 RID: 249425 RVA: 0x00F7865C File Offset: 0x00F7685C
		private void TickAvg(float delta)
		{
			if (!this.IsViewReady)
			{
				return;
			}
			if (ModelBase<CiacconaGalModel>.Instance.IsCurStepDataListDirty)
			{
				this.NotifyDataUpdate();
			}
			if (this.InternalGalPlayer.StatePendingToSwitch != ECiacconaGalPlayerState.Initializing)
			{
				this.InternalGalPlayer.SwitchState();
			}
		}

		// Token: 0x0603CE52 RID: 249426 RVA: 0x00F78691 File Offset: 0x00F76891
		private void TickDataUpdate(float delta)
		{
			if (ModelBase<CiacconaGalModel>.Instance.DataUpdateMask != 0)
			{
				this.NotifyActivityDataUpdate(ModelBase<CiacconaGalModel>.Instance.DataUpdateMask);
				ModelBase<CiacconaGalModel>.Instance.DataUpdateMask = 0;
			}
		}

		// Token: 0x0603CE53 RID: 249427 RVA: 0x00F786BC File Offset: 0x00F768BC
		private void AddNetListeners()
		{
			Singleton<Net>.Instance.Register<ChapterUpdateNotify>(ENotifyMessageId.ChapterUpdateNotify, new Action<ChapterUpdateNotify, Net.CallbackStatus>(this.OnProtoChapterUpdateNotify));
			Singleton<Net>.Instance.Register<InspirationUpdateNotify>(ENotifyMessageId.InspirationUpdateNotify, new Action<InspirationUpdateNotify, Net.CallbackStatus>(this.OnInspirationDataUpdateNotify));
			Singleton<Net>.Instance.Register<ScheduleRewardUpdateNotify>(ENotifyMessageId.ScheduleRewardUpdateNotify, new Action<ScheduleRewardUpdateNotify, Net.CallbackStatus>(this.OnProgressRewardUpdateNotify));
			Singleton<Net>.Instance.Register<ActivityResultUpdateNotify>(ENotifyMessageId.ActivityResultUpdateNotify, new Action<ActivityResultUpdateNotify, Net.CallbackStatus>(this.OnActivityResultUpdateNotify));
			Singleton<Net>.Instance.Register<CiacconaActivityStateUnlockUpdateNotify>(ENotifyMessageId.CiacconaActivityStateUnlockUpdateNotify, new Action<CiacconaActivityStateUnlockUpdateNotify, Net.CallbackStatus>(this.OnActivityStateUpdateNotify));
		}

		// Token: 0x0603CE54 RID: 249428 RVA: 0x00F78758 File Offset: 0x00F76958
		private void RemoveNetListeners()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ChapterUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InspirationUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ScheduleRewardUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ActivityResultUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CiacconaActivityStateUnlockUpdateNotify);
		}

		// Token: 0x0603CE55 RID: 249429 RVA: 0x00F787B8 File Offset: 0x00F769B8
		private void NotifyActivityDataUpdate(int mask)
		{
			if ((mask & 1) != 0)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaChapterDataUpdate);
			}
			if ((mask & 2) != 0)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaInspirationDataUpdate);
			}
			if ((mask & 4) != 0)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaRewardDataUpdate);
			}
			if ((mask & 8) != 0)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaEndingDataUpdate);
			}
			if ((mask & 16) != 0)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnCiacconaActivityStateUpdate);
			}
			CiacconaGalActivityData activityData = ModelBase<CiacconaGalModel>.Instance.ActivityData;
			if (activityData != null)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
			}
		}

		// Token: 0x0603CE56 RID: 249430 RVA: 0x00F78854 File Offset: 0x00F76A54
		public void OpenGalViewByChapterId(int chapterId, EUiViewName? lastView = null)
		{
			CiacconaGalChapterData chapterDataById = ModelBase<CiacconaGalModel>.Instance.GetChapterDataById(chapterId);
			if (chapterDataById != null)
			{
				int stepId = chapterDataById.StepIds[0];
				this.GalPlayer.CurHandlingChapterId = chapterId;
				this.OpenGalViewByStepId(stepId, new int?(chapterId), lastView);
			}
		}

		// Token: 0x0603CE57 RID: 249431 RVA: 0x00F78894 File Offset: 0x00F76A94
		public void OpenGalViewByStepId(int stepId, int? chapterId = null, EUiViewName? lastView = null)
		{
			bool flag = this.InitGalData(stepId);
			if (chapterId != null)
			{
				this.GalPlayer.CurHandlingChapterId = chapterId.Value;
			}
			if (flag)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CiacconaGalView, null, delegate(bool _, int _)
				{
					if (lastView != null)
					{
						Singleton<UiManager>.Instance.CloseView(lastView.Value, null);
					}
				});
			}
		}

		// Token: 0x0603CE58 RID: 249432 RVA: 0x00F788F0 File Offset: 0x00F76AF0
		public void OpenChapterViewById(int chapterId, EUiViewName? lastView = null)
		{
			CiacconaGalChapterData chapterDataById = ModelBase<CiacconaGalModel>.Instance.GetChapterDataById(chapterId);
			if (chapterDataById != null)
			{
				this.GalPlayer.CurHandlingChapterId = chapterId;
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CiacconaGalChapterView, chapterDataById, delegate(bool _, int _)
				{
					if (lastView != null)
					{
						Singleton<UiManager>.Instance.CloseView(lastView.Value, null);
					}
				});
			}
		}

		// Token: 0x0603CE59 RID: 249433 RVA: 0x00F78944 File Offset: 0x00F76B44
		[NullableContext(0)]
		public UniTask<bool> OpenChapterViewAsync(int chapterId)
		{
			CiacconaGalController.<OpenChapterViewAsync>d__18 <OpenChapterViewAsync>d__;
			<OpenChapterViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenChapterViewAsync>d__.<>4__this = this;
			<OpenChapterViewAsync>d__.chapterId = chapterId;
			<OpenChapterViewAsync>d__.<>1__state = -1;
			<OpenChapterViewAsync>d__.<>t__builder.Start<CiacconaGalController.<OpenChapterViewAsync>d__18>(ref <OpenChapterViewAsync>d__);
			return <OpenChapterViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE5A RID: 249434 RVA: 0x00F7898F File Offset: 0x00F76B8F
		public void OpenEndingView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CiacconaGalEndingView, null, null);
		}

		// Token: 0x0603CE5B RID: 249435 RVA: 0x00F789A4 File Offset: 0x00F76BA4
		[NullableContext(2)]
		public void OpenEndingDetailView(int endingId, string labelTextId = null)
		{
			CiacconaGalEndingData endingDataById = ModelBase<CiacconaGalModel>.Instance.GetEndingDataById(endingId);
			if (endingDataById != null && endingDataById.IsFinished)
			{
				CiacconaEndingViewParam param = new CiacconaEndingViewParam
				{
					EndingData = endingDataById,
					LabelTextId = labelTextId
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CiacconaGalEndingDetailView, param, null);
			}
		}

		// Token: 0x0603CE5C RID: 249436 RVA: 0x00F789F0 File Offset: 0x00F76BF0
		public void OpenChapterEntryView(int activityId, ECiacconaEntryType from = ECiacconaEntryType.None)
		{
			CiacconaGalActivityData activityDataById = ModelBase<CiacconaGalModel>.Instance.GetActivityDataById(activityId);
			if (activityDataById != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CiacconaGalChapterEntryView, activityDataById, null);
				this.ReportEnterChapterEntryView(from);
			}
		}

		// Token: 0x0603CE5D RID: 249437 RVA: 0x00F78A24 File Offset: 0x00F76C24
		[NullableContext(0)]
		public UniTask<bool> OpenChapterEntryViewAsync(int activityId, ECiacconaEntryType from = ECiacconaEntryType.None)
		{
			CiacconaGalController.<OpenChapterEntryViewAsync>d__22 <OpenChapterEntryViewAsync>d__;
			<OpenChapterEntryViewAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenChapterEntryViewAsync>d__.<>4__this = this;
			<OpenChapterEntryViewAsync>d__.activityId = activityId;
			<OpenChapterEntryViewAsync>d__.from = from;
			<OpenChapterEntryViewAsync>d__.<>1__state = -1;
			<OpenChapterEntryViewAsync>d__.<>t__builder.Start<CiacconaGalController.<OpenChapterEntryViewAsync>d__22>(ref <OpenChapterEntryViewAsync>d__);
			return <OpenChapterEntryViewAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE5E RID: 249438 RVA: 0x00F78A78 File Offset: 0x00F76C78
		public void OpenRewardViewByActivityId(int activityId)
		{
			CiacconaGalActivityData activityDataById = ModelBase<CiacconaGalModel>.Instance.GetActivityDataById(activityId);
			if (activityDataById != null && activityDataById.IsInRewardTime)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.CiacconaActivityRewardView, activityDataById, null);
			}
		}

		// Token: 0x0603CE5F RID: 249439 RVA: 0x00F78AB0 File Offset: 0x00F76CB0
		public UniTask ExitAvg()
		{
			CiacconaGalController.<ExitAvg>d__24 <ExitAvg>d__;
			<ExitAvg>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExitAvg>d__.<>4__this = this;
			<ExitAvg>d__.<>1__state = -1;
			<ExitAvg>d__.<>t__builder.Start<CiacconaGalController.<ExitAvg>d__24>(ref <ExitAvg>d__);
			return <ExitAvg>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE60 RID: 249440 RVA: 0x00F78AF3 File Offset: 0x00F76CF3
		public void AddOnStepDataUpdate(Action<int> @delegate)
		{
			this.AvgDataUpdateDelegates.Add(@delegate);
		}

		// Token: 0x0603CE61 RID: 249441 RVA: 0x00F78B04 File Offset: 0x00F76D04
		public void RemoveOnStepDataUpdate(Action<int> @delegate)
		{
			int num = this.AvgDataUpdateDelegates.IndexOf(@delegate);
			if (num != -1)
			{
				this.AvgDataUpdateDelegates.RemoveAt(num);
			}
		}

		// Token: 0x0603CE62 RID: 249442 RVA: 0x00F78B2E File Offset: 0x00F76D2E
		public void SetGalViewReady(bool isReady)
		{
			this.IsViewReady = isReady;
			if (!isReady)
			{
				this.InternalGalPlayer.Reset();
			}
		}

		// Token: 0x0603CE63 RID: 249443 RVA: 0x00F78B48 File Offset: 0x00F76D48
		private void NotifyDataUpdate()
		{
			foreach (Action<int> action in this.AvgDataUpdateDelegates)
			{
				action(this.GalPlayer.CurHandlingStepId);
			}
			ModelBase<CiacconaGalModel>.Instance.IsCurStepDataListDirty = false;
		}

		// Token: 0x0603CE64 RID: 249444 RVA: 0x00F78BB0 File Offset: 0x00F76DB0
		private bool InitGalData(int targetStepId)
		{
			if (ModelBase<CiacconaGalModel>.Instance.GetStepDataById(targetStepId) == null)
			{
				return false;
			}
			ModelBase<CiacconaGalModel>.Instance.ClearCurStepData();
			List<CiacconaGalChapterData> allChapterData = ModelBase<CiacconaGalModel>.Instance.GetAllChapterData();
			if (allChapterData == null)
			{
				return false;
			}
			CiacconaGalChapterData ciacconaGalChapterData = allChapterData.Find((CiacconaGalChapterData data) => data.StepIds.Contains(targetStepId));
			if (ciacconaGalChapterData == null)
			{
				return false;
			}
			foreach (int num in ciacconaGalChapterData.StepIds)
			{
				if (num == targetStepId)
				{
					break;
				}
				CiacconaGalStepData stepDataById = ModelBase<CiacconaGalModel>.Instance.GetStepDataById(num);
				if (stepDataById.Type == ECiacconaGalStepType.Choice)
				{
					stepDataById.ChosenId = stepDataById.ChoiceIds[0];
				}
				ModelBase<CiacconaGalModel>.Instance.PushCurStepData(stepDataById);
			}
			this.InternalGalPlayer.TryContinue(targetStepId);
			return true;
		}

		// Token: 0x0603CE65 RID: 249445 RVA: 0x00F78C80 File Offset: 0x00F76E80
		public UniTask RequestFinishChapterSubEnding(int activityId, int chapterId, int subEndingId)
		{
			CiacconaGalController.<RequestFinishChapterSubEnding>d__30 <RequestFinishChapterSubEnding>d__;
			<RequestFinishChapterSubEnding>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestFinishChapterSubEnding>d__.activityId = activityId;
			<RequestFinishChapterSubEnding>d__.chapterId = chapterId;
			<RequestFinishChapterSubEnding>d__.subEndingId = subEndingId;
			<RequestFinishChapterSubEnding>d__.<>1__state = -1;
			<RequestFinishChapterSubEnding>d__.<>t__builder.Start<CiacconaGalController.<RequestFinishChapterSubEnding>d__30>(ref <RequestFinishChapterSubEnding>d__);
			return <RequestFinishChapterSubEnding>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE66 RID: 249446 RVA: 0x00F78CD4 File Offset: 0x00F76ED4
		public UniTask RequestUnlockChoice(int activityId, int chapterId, int choiceId)
		{
			CiacconaGalController.<RequestUnlockChoice>d__31 <RequestUnlockChoice>d__;
			<RequestUnlockChoice>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestUnlockChoice>d__.activityId = activityId;
			<RequestUnlockChoice>d__.chapterId = chapterId;
			<RequestUnlockChoice>d__.choiceId = choiceId;
			<RequestUnlockChoice>d__.<>1__state = -1;
			<RequestUnlockChoice>d__.<>t__builder.Start<CiacconaGalController.<RequestUnlockChoice>d__31>(ref <RequestUnlockChoice>d__);
			return <RequestUnlockChoice>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE67 RID: 249447 RVA: 0x00F78D28 File Offset: 0x00F76F28
		public UniTask RequestGetSubEndingReward(int activityId, int chapterId, int subEndingId)
		{
			CiacconaGalController.<RequestGetSubEndingReward>d__32 <RequestGetSubEndingReward>d__;
			<RequestGetSubEndingReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestGetSubEndingReward>d__.activityId = activityId;
			<RequestGetSubEndingReward>d__.chapterId = chapterId;
			<RequestGetSubEndingReward>d__.subEndingId = subEndingId;
			<RequestGetSubEndingReward>d__.<>1__state = -1;
			<RequestGetSubEndingReward>d__.<>t__builder.Start<CiacconaGalController.<RequestGetSubEndingReward>d__32>(ref <RequestGetSubEndingReward>d__);
			return <RequestGetSubEndingReward>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE68 RID: 249448 RVA: 0x00F78D7C File Offset: 0x00F76F7C
		public UniTask RequestGetActivityEndingReward(int activityId, int endingId)
		{
			CiacconaGalController.<RequestGetActivityEndingReward>d__33 <RequestGetActivityEndingReward>d__;
			<RequestGetActivityEndingReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestGetActivityEndingReward>d__.activityId = activityId;
			<RequestGetActivityEndingReward>d__.endingId = endingId;
			<RequestGetActivityEndingReward>d__.<>1__state = -1;
			<RequestGetActivityEndingReward>d__.<>t__builder.Start<CiacconaGalController.<RequestGetActivityEndingReward>d__33>(ref <RequestGetActivityEndingReward>d__);
			return <RequestGetActivityEndingReward>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE69 RID: 249449 RVA: 0x00F78DC8 File Offset: 0x00F76FC8
		public UniTask RequestGetActivityProgressReward(int activityId, int rewardId)
		{
			CiacconaGalController.<RequestGetActivityProgressReward>d__34 <RequestGetActivityProgressReward>d__;
			<RequestGetActivityProgressReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestGetActivityProgressReward>d__.activityId = activityId;
			<RequestGetActivityProgressReward>d__.rewardId = rewardId;
			<RequestGetActivityProgressReward>d__.<>1__state = -1;
			<RequestGetActivityProgressReward>d__.<>t__builder.Start<CiacconaGalController.<RequestGetActivityProgressReward>d__34>(ref <RequestGetActivityProgressReward>d__);
			return <RequestGetActivityProgressReward>d__.<>t__builder.Task;
		}

		// Token: 0x0603CE6A RID: 249450 RVA: 0x00F78E13 File Offset: 0x00F77013
		private void OnProtoChapterUpdateNotify(ChapterUpdateNotify msg, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<CiacconaGalModel>.Instance.UpdateAllChapterData(msg.ChapterDatas.ToArray<CiacconaChapterPbData>());
		}

		// Token: 0x0603CE6B RID: 249451 RVA: 0x00F78E2A File Offset: 0x00F7702A
		private void OnInspirationDataUpdateNotify(InspirationUpdateNotify msg, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<CiacconaGalModel>.Instance.UpdateInspirationData(msg.InspirationData);
		}

		// Token: 0x0603CE6C RID: 249452 RVA: 0x00F78E3C File Offset: 0x00F7703C
		private void OnProgressRewardUpdateNotify(ScheduleRewardUpdateNotify msg, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<CiacconaGalModel>.Instance.UpdateProgressRewardData(msg.ScheduleRewardDatas.ToArray<CiacconaScheduleRewardPbData>());
		}

		// Token: 0x0603CE6D RID: 249453 RVA: 0x00F78E53 File Offset: 0x00F77053
		private void OnActivityResultUpdateNotify(ActivityResultUpdateNotify msg, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<CiacconaGalModel>.Instance.UpdateAllEndingData(msg.ActivityResultDatas.ToArray<CiacconaActivityResultPbData>());
		}

		// Token: 0x0603CE6E RID: 249454 RVA: 0x00F78E6A File Offset: 0x00F7706A
		private void OnActivityStateUpdateNotify(CiacconaActivityStateUnlockUpdateNotify msg, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<CiacconaGalModel>.Instance.UpdateActivityState(msg);
		}

		// Token: 0x0603CE6F RID: 249455 RVA: 0x00F78E78 File Offset: 0x00F77078
		public void ReportEnterChapterEntryView(ECiacconaEntryType from)
		{
			if (from != ECiacconaEntryType.None)
			{
				CiacconaEnterMainViewLogEvent logData = new CiacconaEnterMainViewLogEvent((int)from);
				ControllerBase<LogReportController>.Instance.LogReport(logData);
			}
		}

		// Token: 0x040222F9 RID: 140025
		[Nullable(2)]
		private CiacconaGalPlayer InternalGalPlayer;

		// Token: 0x040222FA RID: 140026
		private bool IsViewReady;

		// Token: 0x040222FB RID: 140027
		private List<Action<int>> AvgDataUpdateDelegates = new List<Action<int>>();
	}
}
