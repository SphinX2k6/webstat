using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay
{
	// Token: 0x020068F5 RID: 26869
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchGameplayProxy
	{
		// Token: 0x06042C28 RID: 273448 RVA: 0x01121F47 File Offset: 0x01120147
		[NullableContext(1)]
		public void RegisterView(DropCatchGameplayView view)
		{
			this.GameplayView = view;
		}

		// Token: 0x06042C29 RID: 273449 RVA: 0x01121F50 File Offset: 0x01120150
		public UniTask StartGameplay(int gameplayId)
		{
			DropCatchGameplayProxy.<StartGameplay>d__6 <StartGameplay>d__;
			<StartGameplay>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartGameplay>d__.<>4__this = this;
			<StartGameplay>d__.gameplayId = gameplayId;
			<StartGameplay>d__.<>1__state = -1;
			<StartGameplay>d__.<>t__builder.Start<DropCatchGameplayProxy.<StartGameplay>d__6>(ref <StartGameplay>d__);
			return <StartGameplay>d__.<>t__builder.Task;
		}

		// Token: 0x06042C2A RID: 273450 RVA: 0x01121F9C File Offset: 0x0112019C
		[NullableContext(1)]
		public unsafe void PauseGameplay(string reason)
		{
			this.PauseReason.Add(reason);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DropCatch;
			ELogAuthor author = ELogAuthor.CB;
			string message = "外部调用暂停游戏";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PauseCount", this.PauseReason.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.PauseReason.Count == 1)
			{
				this.PauseGate = new CustomPromise();
				DropCatchGameplayLogic gameplayLogic = this.GameplayLogic;
				if (gameplayLogic != null)
				{
					gameplayLogic.Pause();
				}
				DropCatchGameplayView gameplayView = this.GameplayView;
				if (gameplayView != null)
				{
					gameplayView.Pause();
				}
				Singleton<Log>.Instance.Info(ELogModule.DropCatch, ELogAuthor.CB, "暂停游戏逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06042C2B RID: 273451 RVA: 0x01122078 File Offset: 0x01120278
		[NullableContext(1)]
		public unsafe void ResumeGameplay(string reason)
		{
			this.PauseReason.Remove(reason);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DropCatch;
			ELogAuthor author = ELogAuthor.CB;
			string message = "外部调用恢复游戏";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PauseCount", this.PauseReason.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.PauseReason.Count == 0)
			{
				CustomPromise pauseGate = this.PauseGate;
				if (pauseGate != null)
				{
					pauseGate.SetResult();
				}
				DropCatchGameplayLogic gameplayLogic = this.GameplayLogic;
				if (gameplayLogic != null)
				{
					gameplayLogic.Resume();
				}
				DropCatchGameplayView gameplayView = this.GameplayView;
				if (gameplayView != null)
				{
					gameplayView.Resume();
				}
				Singleton<Log>.Instance.Info(ELogModule.DropCatch, ELogAuthor.CB, "恢复游戏逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06042C2C RID: 273452 RVA: 0x01122158 File Offset: 0x01120358
		public void SettleGameplay(EDropCatchGameplaySettleReason reason)
		{
			DropCatchGameplayLogic gameplayLogic = this.GameplayLogic;
			if (gameplayLogic != null)
			{
				gameplayLogic.End();
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DropCatchGameplayResultView, this, null);
			ControllerBase<DropCatchGameplayController>.Instance.SettleGameplay(new IDropCatchSettleGameplay
			{
				GameplayId = this.GameplayViewModel.GetCurGameplayId(),
				Score = this.GameplayViewModel.GetCurScore()
			}, delegate
			{
				this.LogEndReport(reason);
			});
		}

		// Token: 0x06042C2D RID: 273453 RVA: 0x011221D8 File Offset: 0x011203D8
		public void OnGameplayViewDestroyed()
		{
			this.RemoveEvents();
			DropCatchGameplayLogic gameplayLogic = this.GameplayLogic;
			if (gameplayLogic != null)
			{
				gameplayLogic.Destroy();
			}
			this.GameplayLogic = null;
			this.GameplayViewModel = null;
			this.GameplayView = null;
		}

		// Token: 0x06042C2E RID: 273454 RVA: 0x01122206 File Offset: 0x01120406
		public void EndGameplay()
		{
			if (this.GameplayView != null)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.DropCatchGameplayView, null);
				this.GameplayView = null;
			}
		}

		// Token: 0x06042C2F RID: 273455 RVA: 0x01122227 File Offset: 0x01120427
		public void UseRoleSkill()
		{
			DropCatchGameplayLogic gameplayLogic = this.GameplayLogic;
			if (gameplayLogic != null)
			{
				gameplayLogic.UseRoleSkill();
			}
			DropCatchGameplayViewModel gameplayViewModel = this.GameplayViewModel;
			if (gameplayViewModel == null)
			{
				return;
			}
			gameplayViewModel.AddSkillTimes();
		}

		// Token: 0x06042C30 RID: 273456 RVA: 0x0112224C File Offset: 0x0112044C
		public void AddScore(float score)
		{
			float score2 = score * this.GameplayLogic.GetAddScoreRate();
			DropCatchGameplayViewModel gameplayViewModel = this.GameplayViewModel;
			if (gameplayViewModel != null)
			{
				gameplayViewModel.AddScore(score2);
			}
			DropCatchGameplayView gameplayView = this.GameplayView;
			if (gameplayView == null)
			{
				return;
			}
			gameplayView.UpdateScore();
		}

		// Token: 0x06042C31 RID: 273457 RVA: 0x01122289 File Offset: 0x01120489
		public float GetCurScore()
		{
			DropCatchGameplayViewModel gameplayViewModel = this.GameplayViewModel;
			if (gameplayViewModel == null)
			{
				return 0f;
			}
			return gameplayViewModel.GetCurScore();
		}

		// Token: 0x06042C32 RID: 273458 RVA: 0x011222A0 File Offset: 0x011204A0
		public int GetCurGameplayId()
		{
			DropCatchGameplayViewModel gameplayViewModel = this.GameplayViewModel;
			if (gameplayViewModel == null)
			{
				return 0;
			}
			return gameplayViewModel.GetCurGameplayId();
		}

		// Token: 0x06042C33 RID: 273459 RVA: 0x011222B3 File Offset: 0x011204B3
		public Dictionary<int, int> GetDropItemRecord()
		{
			DropCatchGameplayViewModel gameplayViewModel = this.GameplayViewModel;
			if (gameplayViewModel == null)
			{
				return null;
			}
			return gameplayViewModel.GetDropItemRecord();
		}

		// Token: 0x06042C34 RID: 273460 RVA: 0x011222C6 File Offset: 0x011204C6
		public void AddDropItemRecord(int itemId)
		{
			DropCatchGameplayViewModel gameplayViewModel = this.GameplayViewModel;
			if (gameplayViewModel == null)
			{
				return;
			}
			gameplayViewModel.AddDropItemRecord(itemId);
		}

		// Token: 0x06042C35 RID: 273461 RVA: 0x011222DC File Offset: 0x011204DC
		public DropCatchGameplay? GetGameplayConfig()
		{
			DropCatchGameplayViewModel gameplayViewModel = this.GameplayViewModel;
			int? num = (gameplayViewModel != null) ? new int?(gameplayViewModel.GetCurGameplayId()) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					return ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(num.Value);
				}
			}
			return null;
		}

		// Token: 0x06042C36 RID: 273462 RVA: 0x01122345 File Offset: 0x01120545
		public DropCatchGameplayLogic GetGameplayLogic()
		{
			return this.GameplayLogic;
		}

		// Token: 0x06042C37 RID: 273463 RVA: 0x0112234D File Offset: 0x0112054D
		public DropCatchGameplayViewModel GetGameplayViewModel()
		{
			return this.GameplayViewModel;
		}

		// Token: 0x06042C38 RID: 273464 RVA: 0x01122355 File Offset: 0x01120555
		public DropCatchGameplayView GetGameplayView()
		{
			return this.GameplayView;
		}

		// Token: 0x06042C39 RID: 273465 RVA: 0x0112235D File Offset: 0x0112055D
		public bool GetEnableDebug()
		{
			return ControllerBase<DropCatchGameplayController>.Instance.EnableDebug;
		}

		// Token: 0x06042C3A RID: 273466 RVA: 0x0112236C File Offset: 0x0112056C
		private void LogStartReport()
		{
			if (this.GameplayViewModel == null)
			{
				return;
			}
			int curGameplayId = this.GameplayViewModel.GetCurGameplayId();
			DropCatchGameplay? dropCatchGameplay;
			int? num = (ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(curGameplayId) != null) ? new int?(dropCatchGameplay.GetValueOrDefault().ActivityId) : null;
			if (num == null)
			{
				return;
			}
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(num.Value) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				return;
			}
			DropCatchLevelData levelData = dropCatchActivityData.GetLevelData(curGameplayId);
			if (levelData == null)
			{
				return;
			}
			DropCatchGameplayStartReport dropCatchGameplayStartReport = new DropCatchGameplayStartReport();
			dropCatchGameplayStartReport.i_activity_id = num.Value;
			dropCatchGameplayStartReport.i_inst_id = curGameplayId;
			if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(dropCatchActivityData.Id, 0, curGameplayId, 0, 0) == 0)
			{
				dropCatchGameplayStartReport.i_first_pass = -1;
			}
			else
			{
				int highestScore = levelData.HighestScore;
				int num2 = 0;
				foreach (float num3 in this.GameplayViewModel.GetScoreLevels())
				{
					if ((float)highestScore >= num3)
					{
						num2++;
					}
				}
				dropCatchGameplayStartReport.i_first_pass = num2;
			}
			dropCatchGameplayStartReport.s_trace_id = this.GameplayViewModel.GetGameplayTimeStamp();
			ControllerBase<LogReportController>.Instance.LogReport(dropCatchGameplayStartReport);
		}

		// Token: 0x06042C3B RID: 273467 RVA: 0x011224BC File Offset: 0x011206BC
		private void LogEndReport(EDropCatchGameplaySettleReason reason)
		{
			if (this.GameplayViewModel == null || this.GameplayLogic == null)
			{
				return;
			}
			int curGameplayId = this.GameplayViewModel.GetCurGameplayId();
			DropCatchGameplay? dropCatchGameplay;
			int? num = (ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(curGameplayId) != null) ? new int?(dropCatchGameplay.GetValueOrDefault().ActivityId) : null;
			if (num == null)
			{
				return;
			}
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(num.Value) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				return;
			}
			DropCatchLevelData levelData = dropCatchActivityData.GetLevelData(curGameplayId);
			if (levelData == null)
			{
				return;
			}
			DropCatchGameplayEndReport dropCatchGameplayEndReport = new DropCatchGameplayEndReport();
			dropCatchGameplayEndReport.i_activity_id = num.Value;
			dropCatchGameplayEndReport.i_inst_id = curGameplayId;
			int highestScore = levelData.HighestScore;
			float curScore = this.GameplayViewModel.GetCurScore();
			int num2 = 0;
			int num3 = 0;
			foreach (float num4 in this.GameplayViewModel.GetScoreLevels())
			{
				if ((float)highestScore >= num4)
				{
					num2++;
				}
				if (curScore >= num4)
				{
					num3++;
				}
			}
			dropCatchGameplayEndReport.i_first_pass = ((num3 > num2) ? 1 : 0);
			dropCatchGameplayEndReport.s_trace_id = this.GameplayViewModel.GetGameplayTimeStamp();
			dropCatchGameplayEndReport.i_result = num3;
			dropCatchGameplayEndReport.i_reason = (int)reason;
			dropCatchGameplayEndReport.i_get_score = (int)curScore;
			dropCatchGameplayEndReport.i_skill_times = (int)this.GameplayViewModel.GetSkillTimes();
			dropCatchGameplayEndReport.i_cost_time = (int)((double)this.GameplayLogic.GetGameplayTimeMgr().GetTime() * Singleton<TimeUtil>.Instance.Millisecond);
			dropCatchGameplayEndReport.i_add_time = (int)this.GameplayViewModel.GetAddTime();
			Dictionary<int, int> dropItemRecord = this.GameplayViewModel.GetDropItemRecord();
			dropCatchGameplayEndReport.o_item_report = new List<int>
			{
				0,
				0,
				0,
				0
			};
			foreach (KeyValuePair<int, int> keyValuePair in dropItemRecord)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (key == 1)
				{
					dropCatchGameplayEndReport.o_item_report[0] = value;
				}
				else if (key == 2)
				{
					dropCatchGameplayEndReport.o_item_report[1] = value;
				}
				else
				{
					DropCatchDropItem? dropCatchDropItemById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchDropItemById(key);
					if (dropCatchDropItemById != null && dropCatchDropItemById.GetValueOrDefault().EffectType == 0)
					{
						dropCatchGameplayEndReport.o_item_report[2] = value;
					}
					else
					{
						dropCatchGameplayEndReport.o_item_report[3] = value;
					}
				}
			}
			ControllerBase<LogReportController>.Instance.LogReport(dropCatchGameplayEndReport);
			ModelBase<ActivityModel>.Instance.SaveActivityData(dropCatchActivityData.Id, curGameplayId, 0, 0, 1);
		}

		// Token: 0x06042C3C RID: 273468 RVA: 0x01122788 File Offset: 0x01120988
		private UniTask WaitAllPausePromises()
		{
			DropCatchGameplayProxy.<WaitAllPausePromises>d__25 <WaitAllPausePromises>d__;
			<WaitAllPausePromises>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitAllPausePromises>d__.<>4__this = this;
			<WaitAllPausePromises>d__.<>1__state = -1;
			<WaitAllPausePromises>d__.<>t__builder.Start<DropCatchGameplayProxy.<WaitAllPausePromises>d__25>(ref <WaitAllPausePromises>d__);
			return <WaitAllPausePromises>d__.<>t__builder.Task;
		}

		// Token: 0x06042C3D RID: 273469 RVA: 0x011227CC File Offset: 0x011209CC
		private void AddEvents()
		{
			if (!Singleton<EventSystem>.Instance.Has(EEventName.GuideGroupOpening, new Action<int, bool>(this.OnGuideGroupOpening)))
			{
				Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.GuideGroupOpening, new Action<int, bool>(this.OnGuideGroupOpening));
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideGroupFinished)))
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideGroupFinished));
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.GuideGroupRest, new Action<int>(this.OnGuideGroupRest)))
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.GuideGroupRest, new Action<int>(this.OnGuideGroupRest));
			}
		}

		// Token: 0x06042C3E RID: 273470 RVA: 0x01122884 File Offset: 0x01120A84
		private void OnGuideGroupOpening(int groupId, bool isPreExecute)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Guide_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(groupId);
			this.PauseGameplay(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06042C3F RID: 273471 RVA: 0x011228BC File Offset: 0x01120ABC
		private void OnGuideGroupFinished(int groupId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Guide_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(groupId);
			this.ResumeGameplay(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06042C40 RID: 273472 RVA: 0x011228F4 File Offset: 0x01120AF4
		private void OnGuideGroupRest(int groupId)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GuideTutorialView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GuideTutorialPopView))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "引导组重置,需要等待引导界面关闭";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("groupId", groupId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<EventSystem>.Instance.Once<EUiViewName, int>(EEventName.CloseView, delegate(EUiViewName viewName, int viewId)
				{
					if (viewName == EUiViewName.GuideTutorialView || viewName == EUiViewName.GuideTutorialPopView)
					{
						DropCatchGameplayProxy <>4__this = this;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(6, 1);
						defaultInterpolatedStringHandler2.AppendLiteral("Guide_");
						defaultInterpolatedStringHandler2.AppendFormatted<int>(groupId);
						<>4__this.ResumeGameplay(defaultInterpolatedStringHandler2.ToStringAndClear());
					}
				});
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Guide_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(groupId);
			this.ResumeGameplay(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06042C41 RID: 273473 RVA: 0x011229B4 File Offset: 0x01120BB4
		private void RemoveEvents()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.GuideGroupOpening, new Action<int, bool>(this.OnGuideGroupOpening)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupOpening, new Action<int, bool>(this.OnGuideGroupOpening));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideGroupFinished)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupFinished, new Action<int>(this.OnGuideGroupFinished));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.GuideGroupRest, new Action<int>(this.OnGuideGroupRest)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupRest, new Action<int>(this.OnGuideGroupRest));
			}
		}

		// Token: 0x06042C42 RID: 273474 RVA: 0x01122A6C File Offset: 0x01120C6C
		[NullableContext(1)]
		public void PlayFlow(string[] flowId)
		{
			ChatPopViewData param = new ChatPopViewData
			{
				FlowId = new List<string>(flowId)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DropCatchChatPopView, param, null);
		}

		// Token: 0x04025322 RID: 152354
		private DropCatchGameplayLogic GameplayLogic;

		// Token: 0x04025323 RID: 152355
		private DropCatchGameplayView GameplayView;

		// Token: 0x04025324 RID: 152356
		private DropCatchGameplayViewModel GameplayViewModel;

		// Token: 0x04025325 RID: 152357
		[Nullable(1)]
		private readonly HashSet<string> PauseReason = new HashSet<string>();

		// Token: 0x04025326 RID: 152358
		private CustomPromise PauseGate;
	}
}
