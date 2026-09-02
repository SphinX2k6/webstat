using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A74 RID: 19060
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class ExecutingState : StateBase<GuideStepInfo, EGuideStepState>
	{
		// Token: 0x06031C20 RID: 203808 RVA: 0x00C75696 File Offset: 0x00C73896
		public ExecutingState(GuideStepInfo owner, EGuideStepState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideStepInfo, EGuideStepState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C21 RID: 203809 RVA: 0x00C756A8 File Offset: 0x00C738A8
		private void OpenGuideView()
		{
			GuideStepInfo stepInfo = this.Owner;
			if (stepInfo.GuideView != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "重复打开引导界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("步骤Id", stepInfo.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (stepInfo.Config.ContentType == 3)
			{
				GuideTutorial? guideTutorial = ConfigBase<GuideConfig>.Instance.GetGuideTutorial(this.Owner.Id);
				bool isPreExecute = this.Owner.OwnerGroup.GetIfPreExecute();
				bool isSilentUnlock = guideTutorial.Value.SilentUnlock;
				ControllerBase<TutorialController>.Instance.TryUnlockAndOpenTutorialTip(guideTutorial.Value.Id, delegate(bool success)
				{
					if (!success)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Guide;
						ELogAuthor author2 = ELogAuthor.TL;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
						defaultInterpolatedStringHandler.AppendLiteral("打开教学引导失败, 教学目录请求解锁协议返回失败, 触发打断, 步骤ID: ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(stepInfo.Id);
						instance2.Warn(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
						this.Owner.SwitchState(EGuideStepState.Break);
						return;
					}
					if (!this.IsValid)
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Guide;
						ELogAuthor author3 = ELogAuthor.TL;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
						defaultInterpolatedStringHandler.AppendLiteral("打开教学引导失败, 当前已退出执行状态, 步骤ID: ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(stepInfo.Id);
						instance3.Warn(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					if (isSilentUnlock)
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.Guide;
						ELogAuthor author4 = ELogAuthor.HYF;
						string message2 = "图文引导静默解锁";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("步骤Id", stepInfo.Id);
						instance4.Info(module4, author4, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						this.Owner.SwitchState(EGuideStepState.Finish);
						return;
					}
					if (!isPreExecute)
					{
						this.OpenTutorialGuide(stepInfo);
					}
				});
				if (isPreExecute && !isSilentUnlock)
				{
					this.OpenTutorialGuide(stepInfo);
					return;
				}
			}
			else
			{
				ModelBase<GuideModel>.Instance.OpenGuideView(stepInfo);
			}
		}

		// Token: 0x06031C22 RID: 203810 RVA: 0x00C757C0 File Offset: 0x00C739C0
		private void OpenTutorialGuide(GuideStepInfo stepInfo)
		{
			TutorialListInfo tutorialListInfo = new TutorialListInfo(stepInfo);
			tutorialListInfo.Init();
			ModelBase<GuideModel>.Instance.AddTutorialInfo(tutorialListInfo);
		}

		// Token: 0x06031C23 RID: 203811 RVA: 0x00C757E5 File Offset: 0x00C739E5
		private void ClearShowDelayTimer()
		{
			if (this.ShowDelayTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ShowDelayTimer);
				this.ShowDelayTimer = null;
			}
		}

		// Token: 0x06031C24 RID: 203812 RVA: 0x00C75807 File Offset: 0x00C73A07
		private void ClearTimeDilationCheckTimer()
		{
			if (this.TimeDilationCheckTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimeDilationCheckTimer);
				this.TimeDilationCheckTimer = null;
			}
		}

		// Token: 0x06031C25 RID: 203813 RVA: 0x00C7582C File Offset: 0x00C73A2C
		private unsafe void StartTimeDilationCheckTimer()
		{
			int duration = this.Owner.Config.Duration;
			if (duration == 0)
			{
				return;
			}
			if (this.TimeDilationCheckTimer == null)
			{
				int realGuaranteedTime = 30000;
				if (duration > 30000)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Guide;
					ELogAuthor author = ELogAuthor.TL;
					string message = "引导保底时间被配置修改";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("步骤Id", this.Owner.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("组Id", this.Owner.OwnerGroup.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("新保底时间", duration);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					realGuaranteedTime = duration + 2000;
				}
				this.TimeDilationCheckTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.TimeDilationCheckTimer = null;
					if (this.Owner.Config.IsTimeUpAsFinish)
					{
						this.Owner.SwitchState(EGuideStepState.Finish);
						return;
					}
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Guide;
					ELogAuthor author2 = ELogAuthor.TL;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 1);
					defaultInterpolatedStringHandler.AppendLiteral("[引导步骤][时停设置超过保底时长(");
					defaultInterpolatedStringHandler.AppendFormatted<int>(realGuaranteedTime);
					defaultInterpolatedStringHandler.AppendLiteral("秒)未清除, 触发保底机制恢复时停, 请检查引导配置触发流程是否合理！]");
					string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("步骤Id", this.Owner.Id);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.Owner.SwitchState(EGuideStepState.Break);
				}, (float)realGuaranteedTime, null, null, true, 1f);
			}
		}

		// Token: 0x06031C26 RID: 203814 RVA: 0x00C7594C File Offset: 0x00C73B4C
		protected override void OnEnter(EGuideStepState? lastState)
		{
			this.IsValid = true;
			GuideStep config = this.Owner.Config;
			float timeScale = config.TimeScale;
			if (config.ContentType == 4)
			{
				ModelBase<GuideModel>.Instance.AddFocusGuideGroupToView(this.Owner.OwnerGroup);
			}
			if (timeScale < 1f && !ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				Singleton<UiTimeDilation>.Instance.SetTimeDilationHighLevel(timeScale, "GuideStep");
				this.StartTimeDilationCheckTimer();
			}
			else if (this.Owner.OwnerGroupPriority > 0)
			{
				this.StartTimeDilationCheckTimer();
			}
			int showDelay = config.ShowDelay;
			if (showDelay > 0)
			{
				this.ClearShowDelayTimer();
				this.ShowDelayTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.ShowDelayTimer = null;
					this.OnOpenGuideView();
				}, (float)showDelay, null, null, true, 1f);
				return;
			}
			this.OnOpenGuideView();
		}

		// Token: 0x06031C27 RID: 203815 RVA: 0x00C75A1C File Offset: 0x00C73C1C
		private void OnOpenGuideView()
		{
			this.OpenGuideView();
			this.Owner.ViewData.IsAttachToBattleView = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattleView);
			this.IsLimitDistribute = this.Owner.SetLimitInputDistribute();
		}

		// Token: 0x06031C28 RID: 203816 RVA: 0x00C75A54 File Offset: 0x00C73C54
		protected override void OnExit(EGuideStepState nextState)
		{
			this.IsValid = false;
			GuideStepInfo owner = this.Owner;
			owner.IsExitingFromExecuting = true;
			if (this.Owner.Config.TimeScale < 1f && !ModelBase<GameModeModel>.Instance.IsMulti)
			{
				this.ClearTimeDilationCheckTimer();
				Singleton<UiTimeDilation>.Instance.ResetTimeDilationHighLevel("GuideStep");
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			}
			else if (this.Owner.OwnerGroupPriority > 0)
			{
				this.ClearTimeDilationCheckTimer();
			}
			this.ClearShowDelayTimer();
			GuideBaseView guideView = owner.GuideView;
			if (guideView != null)
			{
				int viewId = guideView.GetViewId();
				if (!guideView.IsDestroyOrDestroying)
				{
					guideView.IgnoreState = true;
					Singleton<UiManager>.Instance.CloseViewById(viewId, null);
				}
				owner.GuideView = null;
			}
			ModelBase<GuideModel>.Instance.RemoveStepViewSingletonMap(owner);
			owner.ClearGuideFocusBehavior();
			owner.ViewData.Clear();
			if (this.IsLimitDistribute)
			{
				ModelBase<InputDistributeModel>.Instance.ClearLimitInputDistributeActions();
			}
			owner.IsExitingFromExecuting = false;
		}

		// Token: 0x0401D22C RID: 119340
		private bool IsValid = true;

		// Token: 0x0401D22D RID: 119341
		private bool IsLimitDistribute;

		// Token: 0x0401D22E RID: 119342
		[Nullable(2)]
		private TimerHandle TimeDilationCheckTimer;

		// Token: 0x0401D22F RID: 119343
		[Nullable(2)]
		private TimerHandle ShowDelayTimer;
	}
}
