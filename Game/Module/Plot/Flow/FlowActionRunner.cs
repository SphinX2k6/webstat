using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Module.Plot.FlowActions;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x020053F8 RID: 21496
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowActionRunner : ControllerAssistantBase
	{
		// Token: 0x06036DF6 RID: 224758 RVA: 0x00DE9D58 File Offset: 0x00DE7F58
		protected override void OnDestroy()
		{
			this.Context = null;
			this.CurAction = null;
			this.CurActionInstance = null;
			this.CurSubAction = null;
			this.CurSubActionInstance = null;
		}

		// Token: 0x06036DF7 RID: 224759 RVA: 0x00DE9D7D File Offset: 0x00DE7F7D
		public void EnableSkip(bool enable)
		{
			if (this.Context == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.EnableSkipPlot, enable);
			this.Context.CanSkip = enable;
		}

		// Token: 0x06036DF8 RID: 224760 RVA: 0x00DE9DA5 File Offset: 0x00DE7FA5
		public bool IsSkipEnabled()
		{
			FlowContext context = this.Context;
			return context != null && context.CanSkip;
		}

		// Token: 0x06036DF9 RID: 224761 RVA: 0x00DE9DB8 File Offset: 0x00DE7FB8
		[NullableContext(2)]
		public global::Vector GetInteractPoint()
		{
			Entity entity = null;
			FlowContext context = this.Context;
			if (((context != null) ? context.Context : null) != null && this.Context.Context.Type.GetValueOrDefault() == EGeneralContextType.Entity)
			{
				entity = Singleton<EntitySystem>.Instance.Get(((EntityContext)this.Context.Context).EntityId.Value);
			}
			if (entity == null)
			{
				return null;
			}
			PawnInteractNewComponent component = entity.GetComponent<PawnInteractNewComponent>();
			if (component == null)
			{
				return null;
			}
			PawnInteractController interactController = component.GetInteractController();
			if (interactController == null)
			{
				return null;
			}
			return interactController.GetInteractPoint();
		}

		// Token: 0x06036DFA RID: 224762 RVA: 0x00DE9E3C File Offset: 0x00DE803C
		[NullableContext(2)]
		public IInteractCameraOffsetConfig GetCameraOffsetConfig()
		{
			Entity entity = null;
			FlowContext context = this.Context;
			if (((context != null) ? context.Context : null) != null && this.Context.Context.Type.GetValueOrDefault() == EGeneralContextType.Entity)
			{
				entity = Singleton<EntitySystem>.Instance.Get(((EntityContext)this.Context.Context).EntityId.Value);
			}
			if (entity == null)
			{
				return null;
			}
			PawnInteractNewComponent component = entity.GetComponent<PawnInteractNewComponent>();
			if (component == null)
			{
				return null;
			}
			PawnInteractController interactController = component.GetInteractController();
			if (interactController == null)
			{
				return null;
			}
			return interactController.GetCameraOffsetConfig();
		}

		// Token: 0x06036DFB RID: 224763 RVA: 0x00DE9EBE File Offset: 0x00DE80BE
		public bool IsInShowTalk()
		{
			return this.Context != null && this.Context.CurShowTalk != null;
		}

		// Token: 0x06036DFC RID: 224764 RVA: 0x00DE9ED8 File Offset: 0x00DE80D8
		public EAction? GetCurActionName()
		{
			ActionInfo curAction = this.CurAction;
			if (curAction != null)
			{
				return new EAction?(curAction.Name);
			}
			ActionInfo curSubAction = this.CurSubAction;
			if (curSubAction == null)
			{
				return null;
			}
			return new EAction?(curSubAction.Name);
		}

		// Token: 0x06036DFD RID: 224765 RVA: 0x00DE9F18 File Offset: 0x00DE8118
		public void ExecuteActions([Nullable(new byte[]
		{
			2,
			1
		})] List<ActionInfo> actions, FlowContext context, Action callback)
		{
			if (actions == null || actions.Count <= 0)
			{
				this.FinishActions();
				return;
			}
			this.Context = context;
			this.ActionInfoList.Clear();
			this.ActionInfoList.AddRange(actions);
			this.ActionInfoList.Reverse();
			List<ActionInfo> actionInfoList = this.ActionInfoList;
			if (actionInfoList[actionInfoList.Count - 1].Name != EAction.SetPlotMode)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.ZWY, "第一个行为不是SetPlotMode，自动添加。", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ActionInfoList.Add(this.DefaultSetPlotModeAction);
			}
			this.Context.HasAdjustCamera = this.CheckAdjustCameraAction();
			this.ActionsCallBack = callback;
			bool disableFlow = ModelBase<PlotModel>.Instance.PlotGlobalConfig.DisableFlow;
			this.Context.IsBackground = disableFlow;
			this.NextAction();
		}

		// Token: 0x06036DFE RID: 224766 RVA: 0x00DE9FF0 File Offset: 0x00DE81F0
		private void NextAction()
		{
			if (this.Context == null || this.Context.IsBreakdown || this.ActionInfoList.Count <= 0)
			{
				this.FinishActions();
				return;
			}
			List<ActionInfo> actionInfoList = this.ActionInfoList;
			ActionInfo actionInfo = actionInfoList[actionInfoList.Count - 1];
			this.ActionInfoList.RemoveAt(this.ActionInfoList.Count - 1);
			if (actionInfo.Disabled.GetValueOrDefault() || actionInfo.EdLocalDisabled.GetValueOrDefault())
			{
				this.NextAction();
				return;
			}
			if (this.ShouldResumeAtSetPlotMode(actionInfo))
			{
				this.ResumeFromSegmentSkip(actionInfo);
			}
			this.ExecuteAction(actionInfo);
		}

		// Token: 0x06036DFF RID: 224767 RVA: 0x00DEA094 File Offset: 0x00DE8294
		private void ExecuteAction(ActionInfo actionInfo)
		{
			FlowAction flowAction = ControllerBase<FlowController>.Instance.GetFlowAction(actionInfo.Name);
			if (flowAction == null)
			{
				this.NextAction();
				return;
			}
			this.CurAction = actionInfo;
			this.Context.CurActionId = actionInfo.ActionId.GetValueOrDefault();
			FlowActionBase action = flowAction.GetAction();
			this.CurActionInstance = action;
			action.Runner = this;
			action.Callback = new Action<bool, bool>(this.OnActionFinished);
			action.Execute(actionInfo, this.Context, flowAction.IsAutoFinish);
		}

		// Token: 0x06036E00 RID: 224768 RVA: 0x00DEA118 File Offset: 0x00DE8318
		private bool ShouldResumeAtSetPlotMode(ActionInfo actionInfo)
		{
			if (this.Context == null || !this.Context.IsSegmentSkipping || actionInfo.Name != EAction.SetPlotMode)
			{
				return false;
			}
			SetPlotMode setPlotMode = actionInfo.Params as SetPlotMode;
			return setPlotMode != null && setPlotMode.NoSkip.GetValueOrDefault();
		}

		// Token: 0x06036E01 RID: 224769 RVA: 0x00DEA168 File Offset: 0x00DE8368
		private unsafe void ResumeFromSegmentSkip(ActionInfo actionInfo)
		{
			if (this.Context == null)
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "跳过剧情: 遇到不可跳过SetPlotMode，恢复正常播放";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Context.FormatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionId", actionInfo.ActionId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			bool isFadeSkip = this.Context.IsFadeSkip;
			TimerHandle skipTimer = this.SkipTimer;
			if (skipTimer != null)
			{
				skipTimer.Remove();
			}
			this.SkipTimer = null;
			this.Context.IsBackground = false;
			this.Context.IsSegmentSkipping = false;
			this.Context.IsFadeSkip = false;
			ControllerBase<PlotController>.Instance.HideUi(false, new long?(this.Context.FlowIncId));
			if (isFadeSkip)
			{
				ModelBase<PlotModel>.Instance.IsFadeIn = false;
				ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.Common, "SkipPlot_" + this.Context.FormatId, null, new float?(0.25f));
			}
		}

		// Token: 0x06036E02 RID: 224770 RVA: 0x00DEA280 File Offset: 0x00DE8480
		private void OnActionFinished(bool isSuccess, bool isContinue)
		{
			if (this.CurActionInstance != null)
			{
				this.CurActionInstance.Recycle();
			}
			this.CurAction = null;
			this.Context.CurActionId = 0;
			this.CurActionInstance = null;
			if (isContinue)
			{
				this.NextAction();
			}
		}

		// Token: 0x06036E03 RID: 224771 RVA: 0x00DEA2B8 File Offset: 0x00DE84B8
		public unsafe void FinishFlow(string reason, long? flowIncId = null, bool isServerEnd = false)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "FinishFlow";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("incId", flowIncId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (flowIncId != null && ModelBase<PlotModel>.Instance.SetPendingPlotState(flowIncId.Value, true, true, isServerEnd))
			{
				return;
			}
			if (this.Context != null)
			{
				if (flowIncId != null)
				{
					long flowIncId2 = this.Context.FlowIncId;
					long? num = flowIncId;
					if (!(flowIncId2 == num.GetValueOrDefault() & num != null))
					{
						return;
					}
				}
				this.Context.IsBreakdown = true;
				this.Rollback(this.Context.RollbackRecord);
				this.BackgroundActions(reason, false, isServerEnd, false);
			}
		}

		// Token: 0x06036E04 RID: 224772 RVA: 0x00DEA395 File Offset: 0x00DE8595
		public void ForceFinishActionsByGm()
		{
			if (this.Context == null)
			{
				return;
			}
			if (this.Context.IsServerNotify)
			{
				FlowNetworks.RequestGmFinish();
			}
			this.Context.IsBreakdown = true;
			this.BackgroundActions("GM强制中断剧情", false, true, false);
		}

		// Token: 0x06036E05 RID: 224773 RVA: 0x00DEA3CC File Offset: 0x00DE85CC
		private void FinishActions()
		{
			FlowActionBase curActionInstance = this.CurActionInstance;
			if (curActionInstance != null)
			{
				curActionInstance.Recycle();
			}
			this.CurActionInstance = null;
			FlowActionBase curSubActionInstance = this.CurSubActionInstance;
			if (curSubActionInstance != null)
			{
				curSubActionInstance.Recycle();
			}
			this.CurSubActionInstance = null;
			TimerHandle skipTimer = this.SkipTimer;
			if (skipTimer != null)
			{
				skipTimer.Remove();
			}
			this.SkipTimer = null;
			this.FlowSequence.Stop(true);
			this.ActionInfoList.Clear();
			this.CurAction = null;
			this.CurSubAction = null;
			PlotController instance = ControllerBase<PlotController>.Instance;
			FlowContext context = this.Context;
			instance.CloseAllUi((context != null) ? new long?(context.FlowIncId) : null);
			ControllerBase<PlotController>.Instance.EnsureFormationMemoryMaskBeforePlotEnd();
			this.CloseLoading(delegate
			{
				this.SubmitFlow();
				this.RunDeferredSeamlessFinalizeOnPlotEnd();
				this.Context = null;
				Action actionsCallBack = this.ActionsCallBack;
				this.ActionsCallBack = null;
				if (actionsCallBack == null)
				{
					return;
				}
				actionsCallBack();
			});
		}

		// Token: 0x06036E06 RID: 224774 RVA: 0x00DEA48C File Offset: 0x00DE868C
		private void CloseLoading(Action callback)
		{
			if ((this.Context.IsFadeSkip && !ModelBase<PlotModel>.Instance.IsFadeIn) || !ModelBase<PlotModel>.Instance.PlotConfig.SkipHiddenBlackScreenAtEnd)
			{
				ModelBase<PlotModel>.Instance.IsFadeIn = false;
				LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
				ELoadingReason reason = ELoadingReason.Common;
				string str = "SkipPlot_";
				FlowContext context = this.Context;
				instance.CloseLoading(reason, str + ((context != null) ? context.FormatId : null), callback, new float?(0.25f));
				return;
			}
			callback();
		}

		// Token: 0x06036E07 RID: 224775 RVA: 0x00DEA508 File Offset: 0x00DE8708
		private void SubmitFlow()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.ZWY;
			string message = "剧情选项";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("选项", this.Context.OptionsCollection);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<KuroSdkReport>.Instance.OnPlotFinish(this.Context);
			if (!this.Context.IsServerEnd && this.Context.IsServerNotify && !this.Context.IsAsync)
			{
				this.CacheFlowIncId[this.Context.FlowIncId] = new List<ActionRecord>(this.Context.RollbackRecord);
				FlowNetworks.RequestFlowEnd(this.Context.FlowIncId, this.Context.IsBackground || this.Context.HasSkipped, this.Context.OptionsCollection, new Action<long, ErrorCode?>(this.OnEndResponse));
			}
		}

		// Token: 0x06036E08 RID: 224776 RVA: 0x00DEA5E8 File Offset: 0x00DE87E8
		private void OnEndResponse(long flowIncId, ErrorCode? errorCode)
		{
			if (!this.CacheFlowIncId.Remove(flowIncId))
			{
				this.LogError("ContextCache undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ErrorCode? errorCode2 = errorCode;
			ErrorCode errorCode3 = ErrorCode.Success;
			if ((errorCode2.GetValueOrDefault() == errorCode3 & errorCode2 != null) || errorCode == null)
			{
				return;
			}
			if (errorCode.GetValueOrDefault() == ErrorCode.ErrFlowNotExist)
			{
				string text = "ErrFlowNotExist";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("response flowIncId", flowIncId);
				this.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.Rollback(this.CacheFlowIncId.GetValueOrDefault(flowIncId));
			FlowNetworks.RequestFlowRestart(flowIncId);
		}

		// Token: 0x06036E09 RID: 224777 RVA: 0x00DEA685 File Offset: 0x00DE8885
		public void AddActionNext(ActionInfo actionInfo)
		{
			if (this.Context == null)
			{
				return;
			}
			this.ActionInfoList.Add(actionInfo);
		}

		// Token: 0x06036E0A RID: 224778 RVA: 0x00DEA69C File Offset: 0x00DE889C
		public void ExecuteNextAction()
		{
			if (this.Context == null)
			{
				return;
			}
			this.NextAction();
		}

		// Token: 0x06036E0B RID: 224779 RVA: 0x00DEA6AD File Offset: 0x00DE88AD
		[NullableContext(2)]
		public void ExecuteSubActions([Nullable(new byte[]
		{
			2,
			1
		})] List<ActionInfo> actions, Action<bool> callback = null, bool append = false)
		{
			this.SetupSubActions(actions, callback, append);
			if (this.CurSubActionInstance == null)
			{
				this.NextSubAction();
			}
		}

		// Token: 0x06036E0C RID: 224780 RVA: 0x00DEA6C8 File Offset: 0x00DE88C8
		[NullableContext(2)]
		private void SetupSubActions([Nullable(new byte[]
		{
			2,
			1
		})] List<ActionInfo> actions, Action<bool> callback = null, bool append = false)
		{
			if (!append)
			{
				this.SubActionInfoList.Clear();
				this.SubActionsCallBack.Clear();
			}
			if (callback != null)
			{
				this.SubActionsCallBack.Add(callback);
			}
			if (actions != null)
			{
				foreach (ActionInfo element in actions)
				{
					this.SubActionInfoList.Push(element);
				}
			}
		}

		// Token: 0x06036E0D RID: 224781 RVA: 0x00DEA748 File Offset: 0x00DE8948
		private void NextSubAction()
		{
			if (this.SubActionInfoList.Size <= 0)
			{
				this.FinishSubActions(true);
				return;
			}
			ActionInfo actionInfo = this.SubActionInfoList.Pop();
			FlowAction flowAction = ControllerBase<FlowController>.Instance.GetFlowAction(actionInfo.Name);
			if (flowAction == null)
			{
				this.NextSubAction();
				return;
			}
			this.CurSubAction = actionInfo;
			if (this.Context != null)
			{
				this.Context.CurSubActionId = actionInfo.ActionId.GetValueOrDefault();
			}
			FlowActionBase action = flowAction.GetAction();
			this.CurSubActionInstance = action;
			action.Runner = this;
			action.Callback = new Action<bool, bool>(this.OnSubActionFinished);
			action.Execute(actionInfo, this.Context, flowAction.IsAutoFinish);
		}

		// Token: 0x06036E0E RID: 224782 RVA: 0x00DEA7F4 File Offset: 0x00DE89F4
		private void OnSubActionFinished(bool isSuccess, bool isContinue)
		{
			if (this.CurSubActionInstance != null)
			{
				this.CurSubActionInstance.Recycle();
			}
			this.CurSubAction = null;
			if (this.Context != null)
			{
				this.Context.CurSubActionId = 0;
			}
			this.CurSubActionInstance = null;
			if (isContinue)
			{
				this.NextSubAction();
				return;
			}
			this.FinishSubActions(false);
		}

		// Token: 0x06036E0F RID: 224783 RVA: 0x00DEA848 File Offset: 0x00DE8A48
		private void FinishSubActions(bool result = true)
		{
			if (this.SubActionsCallBack.Count == 0)
			{
				return;
			}
			List<Action<bool>> list = new List<Action<bool>>(this.SubActionsCallBack);
			this.SubActionsCallBack.Clear();
			foreach (Action<bool> action in list)
			{
				action(result);
			}
		}

		// Token: 0x06036E10 RID: 224784 RVA: 0x00DEA8B8 File Offset: 0x00DE8AB8
		private void Rollback(List<ActionRecord> actionRecords)
		{
			FlowContext context = this.Context;
			if (((context != null) ? context.RollbackRecord : null) == null || this.Context.RollbackRecord.Count == 0)
			{
				return;
			}
			foreach (ActionRecord actionRecord in actionRecords)
			{
				FlowAction flowAction = ControllerBase<FlowController>.Instance.GetFlowAction(actionRecord.ActionInfo.Name);
				if (flowAction != null)
				{
					flowAction.GetAction().Rollback(actionRecord, this.Context);
				}
			}
		}

		// Token: 0x06036E11 RID: 224785 RVA: 0x00DEA954 File Offset: 0x00DE8B54
		public void FinishShowCenterTextAction(Action callback)
		{
			bool flag = true;
			if (this.CurAction != null)
			{
				if (this.ActionInfoList.Count > 0)
				{
					List<ActionInfo> actionInfoList = this.ActionInfoList;
					ActionInfo actionInfo = actionInfoList[actionInfoList.Count - 1];
					if (actionInfo == null)
					{
						this.LogError("FinishShowCenterTextAction:nextAction丢失", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					if (actionInfo.Name == EAction.ShowCenterText)
					{
						flag = false;
					}
				}
			}
			else if (this.CurSubAction != null && this.SubActionInfoList.Size > 0)
			{
				ActionInfo front = this.SubActionInfoList.Front;
				if (front == null)
				{
					this.LogError("FinishShowCenterTextAction:nextAction丢失", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				if (front.Name == EAction.ShowCenterText)
				{
					flag = false;
				}
			}
			if (flag && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PlotTransitionView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PlotTransitionView, delegate(bool _)
				{
					callback();
				});
				return;
			}
			callback();
		}

		// Token: 0x06036E12 RID: 224786 RVA: 0x00DEAA3C File Offset: 0x00DE8C3C
		public unsafe void BackgroundActions(string reason, bool useFade = true, bool isServerEnd = false, bool stopAtNoSkipSetPlotMode = false)
		{
			if (this.Context == null)
			{
				return;
			}
			this.Context.IsServerEnd = isServerEnd;
			if (this.Context.IsBackground)
			{
				return;
			}
			if (!this.Context.CanSkip && ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "当前状态不可跳过", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "跳过剧情";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原因", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", this.Context.FormatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ServerNotify", this.Context.IsServerNotify);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ServerEnd", this.Context.IsServerEnd);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			TimerHandle skipTimer = this.SkipTimer;
			if (skipTimer != null)
			{
				skipTimer.Remove();
			}
			this.SkipTimer = null;
			this.Context.IsBackground = true;
			this.Context.IsSegmentSkipping = stopAtNoSkipSetPlotMode;
			this.Context.HasSkipped = true;
			this.Context.IsServerEnd = isServerEnd;
			this.Context.IsFadeSkip = useFade;
			if (useFade)
			{
				ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.Common, ELoadingPerform.CameraFade, "SkipPlot_" + this.Context.FormatId, null, new object[]
				{
					0.25f
				});
				this.SkipTimer = TimerSystem.Instance.Delay(new TTimerAction(this.SkipPlot), 250f, null, null, true, 1f);
				return;
			}
			this.SkipPlot(0f);
		}

		// Token: 0x06036E13 RID: 224787 RVA: 0x00DEAC10 File Offset: 0x00DE8E10
		private void SkipPlot(float _)
		{
			TimerHandle skipTimer = this.SkipTimer;
			if (skipTimer != null)
			{
				skipTimer.Remove();
			}
			this.SkipTimer = null;
			if (this.Context == null)
			{
				return;
			}
			ControllerBase<PlotController>.Instance.ClearUi(new long?(this.Context.FlowIncId));
			ControllerBase<PlotController>.Instance.HideUi(true, new long?(this.Context.FlowIncId));
			if (this.Context.CurShowTalk == null)
			{
				if (this.CurAction != null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Plot;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "跳过剧情: 行为";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActionId", this.CurAction.ActionId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					FlowActionBase curActionInstance = this.CurActionInstance;
					if (curActionInstance == null)
					{
						return;
					}
					curActionInstance.InterruptExecute();
				}
				return;
			}
			if (this.FlowSequence.IsInit)
			{
				this.SkipSequenceTalk();
			}
			else
			{
				this.SkipNormalTalk();
			}
			FlowActionBase curSubActionInstance = this.CurSubActionInstance;
			if (curSubActionInstance == null)
			{
				return;
			}
			curSubActionInstance.InterruptExecute();
		}

		// Token: 0x06036E14 RID: 224788 RVA: 0x00DEACFC File Offset: 0x00DE8EFC
		private void SkipSequenceTalk()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "跳过剧情: 演出对话", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.FlowSequence.Skip();
		}

		// Token: 0x06036E15 RID: 224789 RVA: 0x00DEAD30 File Offset: 0x00DE8F30
		private void SkipNormalTalk()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "跳过剧情: 普通对话", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.FlowShowTalk.Skip();
		}

		// Token: 0x06036E16 RID: 224790 RVA: 0x00DEAD64 File Offset: 0x00DE8F64
		public void HandleInputBeforePlay(EPlotLevel? level)
		{
			EPlotLevel value = level.GetValueOrDefault();
			if (level == null)
			{
				value = EPlotLevel.LevelC;
				level = new EPlotLevel?(value);
			}
			if (level.GetValueOrDefault() != EPlotLevel.LevelD && level.GetValueOrDefault() != EPlotLevel.LevelE && level.GetValueOrDefault() != EPlotLevel.ControlEntity)
			{
				ModelBase<PlotModel>.Instance.PlotConfig.DisableInput = true;
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.ForceReleaseInput, "Start Plot");
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				FlowContext context = this.Context;
				if (context != null && context.SeamlessPlot)
				{
					Singleton<PlotSequenceInertiaKeeper>.Instance.Start("FlowActionRunner.HandleInputBeforePlay");
					return;
				}
			}
			else
			{
				ModelBase<PlotModel>.Instance.PlotConfig.DisableInput = false;
			}
		}

		// Token: 0x06036E17 RID: 224791 RVA: 0x00DEAE10 File Offset: 0x00DE9010
		private bool CheckAdjustCameraAction()
		{
			if (this.ActionInfoList.Count == 0)
			{
				return false;
			}
			using (List<ActionInfo>.Enumerator enumerator = this.ActionInfoList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Name == EAction.AdjustPlayerCamera)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06036E18 RID: 224792 RVA: 0x00DEAE80 File Offset: 0x00DE9080
		[NullableContext(2)]
		public int GetOptionToSelect(ITalkItem inTalkItem = null)
		{
			int curShowTalkActionId = this.Context.CurShowTalkActionId;
			ITalkItem talkItem = inTalkItem;
			if (talkItem == null)
			{
				foreach (ITalkItem talkItem2 in this.Context.CurShowTalk.TalkItems)
				{
					if (talkItem2.Id == this.Context.CurTalkId)
					{
						talkItem = talkItem2;
						break;
					}
				}
			}
			if (((talkItem != null) ? talkItem.Options : null) == null)
			{
				return 0;
			}
			Dictionary<int, int> dictionary;
			int num;
			if (!this.Context.OptionsHistory.TryGetValue(curShowTalkActionId, out dictionary) || !dictionary.TryGetValue(talkItem.Id, out num))
			{
				return 0;
			}
			int num2 = num + 1;
			if (num2 >= talkItem.Options.Count)
			{
				return 0;
			}
			return num2;
		}

		// Token: 0x06036E19 RID: 224793 RVA: 0x00DEAF54 File Offset: 0x00DE9154
		public int GetHistoryOptionSelect(int talkId)
		{
			FlowContext context = this.Context;
			if (((context != null) ? context.CurShowTalk : null) == null)
			{
				return -1;
			}
			return this.Context.OptionsHistory[this.Context.CurShowTalkActionId].GetValueOrDefault(talkId, -1);
		}

		// Token: 0x06036E1A RID: 224794 RVA: 0x00DEAF90 File Offset: 0x00DE9190
		public void RecordOption(int talkId, int optionIndex)
		{
			FlowContext context = this.Context;
			if (((context != null) ? context.CurShowTalk : null) == null)
			{
				return;
			}
			this.Context.OptionsHistory[this.Context.CurShowTalkActionId][talkId] = optionIndex;
			List<ValueTuple<int, List<ValueTuple<int, int>>>> optionsCollection = this.Context.OptionsCollection;
			optionsCollection[optionsCollection.Count - 1].Item2.Add(new ValueTuple<int, int>(talkId, optionIndex));
			ITalkItem talkItem = null;
			foreach (ITalkItem talkItem2 in this.Context.CurShowTalk.TalkItems)
			{
				if (talkItem2.Id == talkId)
				{
					talkItem = talkItem2;
					break;
				}
			}
			if (talkItem != null)
			{
				TalkRecord item = new TalkRecord
				{
					TalkItem = talkItem,
					IsOption = true,
					OptionIndex = new int?(optionIndex)
				};
				FlowContext context2 = this.Context;
				if (context2 == null)
				{
					return;
				}
				context2.TalkHistory.Add(item);
			}
		}

		// Token: 0x06036E1B RID: 224795 RVA: 0x00DEB090 File Offset: 0x00DE9290
		public void RecordTalkItem(ITalkItem talkItem)
		{
			ETalkItemType? type = talkItem.Type;
			if (type != null)
			{
				ETalkItemType? etalkItemType = type;
				ETalkItemType etalkItemType2 = ETalkItemType.Talk;
				if (!(etalkItemType.GetValueOrDefault() == etalkItemType2 & etalkItemType != null))
				{
					return;
				}
			}
			string tidTalk = talkItem.TidTalk;
			if (tidTalk == null)
			{
				return;
			}
			string flowConfigLocalText = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(tidTalk);
			if (flowConfigLocalText == null || StringUtils.IsBlank(flowConfigLocalText))
			{
				return;
			}
			TalkRecord item = new TalkRecord
			{
				TalkItem = talkItem,
				IsOption = false
			};
			FlowContext context = this.Context;
			if (context == null)
			{
				return;
			}
			context.TalkHistory.Add(item);
		}

		// Token: 0x06036E1C RID: 224796 RVA: 0x00DEB116 File Offset: 0x00DE9316
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<TalkRecord> GetTalkHistory()
		{
			FlowContext context = this.Context;
			if (context == null)
			{
				return null;
			}
			return context.TalkHistory;
		}

		// Token: 0x06036E1D RID: 224797 RVA: 0x00DEB12C File Offset: 0x00DE932C
		public bool CheckCanSkipTmp()
		{
			if (this.ActionInfoList == null)
			{
				return false;
			}
			using (List<ActionInfo>.Enumerator enumerator = this.ActionInfoList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Name == EAction.PlaySequenceData)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06036E1E RID: 224798 RVA: 0x00DEB194 File Offset: 0x00DE9394
		public void JumpTalk(int talkId)
		{
			if (this.Context.CurShowTalk == null)
			{
				return;
			}
			if (this.FlowSequence.IsInit)
			{
				this.FlowSequence.OnJumpTalk(talkId);
				return;
			}
			this.FlowShowTalk.SwitchTalkItem(talkId);
		}

		// Token: 0x06036E1F RID: 224799 RVA: 0x00DEB1CA File Offset: 0x00DE93CA
		public void FinishTalk()
		{
			if (this.Context.CurShowTalk == null)
			{
				return;
			}
			if (this.FlowSequence.IsInit)
			{
				this.FlowSequence.OnFinishTalk();
				return;
			}
			this.FlowShowTalk.FinishShowTalk();
		}

		// Token: 0x06036E20 RID: 224800 RVA: 0x00DEB200 File Offset: 0x00DE9400
		public void TriggerCountDownSkip(bool enable)
		{
			if (enable)
			{
				TimerHandle countDowner = this.CountDowner;
				if (countDowner != null)
				{
					countDowner.Remove();
				}
				this.CountDowner = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.BackgroundActions("D级剧情被别的界面打断", false, false, false);
					this.CountDowner = null;
				}, 20000f, null, null, true, 1f);
				return;
			}
			TimerHandle countDowner2 = this.CountDowner;
			if (countDowner2 != null)
			{
				countDowner2.Remove();
			}
			this.CountDowner = null;
		}

		// Token: 0x06036E21 RID: 224801 RVA: 0x00DEB268 File Offset: 0x00DE9468
		public bool HasFlow(string flowListName, int flowId, int flowStateId)
		{
			if (this.Context != null && this.Context.FlowListName == flowListName && this.Context.FlowId == flowId && this.Context.FlowStateId == flowStateId)
			{
				return true;
			}
			foreach (PlotInfo plotInfo in ModelBase<PlotModel>.Instance.PlotPendingList)
			{
				if (plotInfo.FlowListName == flowListName && plotInfo.FlowId == flowId)
				{
					int? stateId = plotInfo.StateId;
					if (stateId.GetValueOrDefault() == flowStateId & stateId != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06036E22 RID: 224802 RVA: 0x00DEB330 File Offset: 0x00DE9530
		[NullableContext(2)]
		public ActionInfo GetNextAction(bool checkSubAction)
		{
			if (this.Context == null)
			{
				return null;
			}
			if (checkSubAction && this.SubActionInfoList.Size > 0)
			{
				return this.SubActionInfoList.Front;
			}
			if (this.ActionInfoList.Count <= 0)
			{
				return null;
			}
			List<ActionInfo> actionInfoList = this.ActionInfoList;
			return actionInfoList[actionInfoList.Count - 1];
		}

		// Token: 0x06036E23 RID: 224803 RVA: 0x00DEB387 File Offset: 0x00DE9587
		public void LogError(string text, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			if (this.Context == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Plot, ELogAuthor.FZX, text, pairs);
				return;
			}
			FlowContext context = this.Context;
			if (context == null)
			{
				return;
			}
			context.LogError(text, pairs);
		}

		// Token: 0x06036E24 RID: 224804 RVA: 0x00DEB3B4 File Offset: 0x00DE95B4
		public long GetFlowIncId()
		{
			return this.Context.FlowIncId;
		}

		// Token: 0x06036E25 RID: 224805 RVA: 0x00DEB3C1 File Offset: 0x00DE95C1
		public void RequestPosition(IVector location, IRotator rotation)
		{
			FlowNetworks.RequestSeqEndPosition(this.Context, location, rotation);
		}

		// Token: 0x06036E26 RID: 224806 RVA: 0x00DEB3D0 File Offset: 0x00DE95D0
		public bool CheckViewControlBeginForC()
		{
			for (int i = this.ActionInfoList.Count - 1; i > 0; i--)
			{
				ActionInfo actionInfo = this.ActionInfoList[i];
				if (actionInfo.Name == EAction.ShowTalk)
				{
					return true;
				}
				if (actionInfo.Name == EAction.BeginFlowTemplate)
				{
					return ((BeginFlowTemplate)actionInfo.Params).UseFreeCamera.GetValueOrDefault();
				}
			}
			return true;
		}

		// Token: 0x06036E27 RID: 224807 RVA: 0x00DEB438 File Offset: 0x00DE9638
		public List<ActionParams> GetNameAction(EAction actionName)
		{
			List<ActionParams> list = new List<ActionParams>();
			foreach (ActionInfo actionInfo in this.ActionInfoList)
			{
				if (actionInfo.Name == actionName)
				{
					list.Add(actionInfo.Params);
				}
			}
			FlowContext context = this.Context;
			if (((context != null) ? context.CurShowTalk : null) != null)
			{
				list.Add(this.Context.CurShowTalk);
			}
			return list;
		}

		// Token: 0x06036E28 RID: 224808 RVA: 0x00DEB4C8 File Offset: 0x00DE96C8
		public string GetFlowName()
		{
			FlowContext context = this.Context;
			return ((context != null) ? context.FormatId : null) ?? "";
		}

		// Token: 0x06036E29 RID: 224809 RVA: 0x00DEB4E8 File Offset: 0x00DE96E8
		public bool HasPendingShowTalkOrSequenceDataAction()
		{
			for (int i = this.ActionInfoList.Count - 1; i >= 0; i--)
			{
				ActionInfo actionInfo = this.ActionInfoList[i];
				if (actionInfo.Name == EAction.ShowTalk || actionInfo.Name == EAction.PlaySequenceData)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06036E2A RID: 224810 RVA: 0x00DEB531 File Offset: 0x00DE9731
		public bool CollectSeamlessFinalize(ESeamlessFinalizeFlag flag)
		{
			if (this.Context == null || !this.Context.SeamlessPlot)
			{
				return false;
			}
			if (this.Context.IsBackground)
			{
				return false;
			}
			if (!this.HasPendingShowTalkOrSequenceDataAction())
			{
				return false;
			}
			this.Context.AddDeferredFinalizeFlag(flag);
			return true;
		}

		// Token: 0x06036E2B RID: 224811 RVA: 0x00DEB570 File Offset: 0x00DE9770
		public void RunDeferredSeamlessFinalizeOnPlotEnd()
		{
			if (this.Context == null)
			{
				return;
			}
			ESeamlessFinalizeFlag eseamlessFinalizeFlag = this.Context.ConsumeDeferredFinalizeFlags();
			if (eseamlessFinalizeFlag == ESeamlessFinalizeFlag.None)
			{
				return;
			}
			if (eseamlessFinalizeFlag.HasFlag(ESeamlessFinalizeFlag.ExitSequenceCamera))
			{
				ControllerBase<CameraController>.Instance.ExitCameraMode(ECustomCameraMode.Sequence, 0f, UnrealEngine.EViewTargetBlendFunction.VTBlend_Linear, 0f, null, "MainCamera", null);
			}
			if (eseamlessFinalizeFlag.HasFlag(ESeamlessFinalizeFlag.ExitMovieMode))
			{
				ControllerBase<MovieModeController>.Instance.ExitMovieMode(new ExitMovieModeParams
				{
					BlendTime = 0f
				}, null);
				ModelBase<SequenceModel>.Instance.EnablingUiBlend = false;
			}
			if (eseamlessFinalizeFlag.HasFlag(ESeamlessFinalizeFlag.UiRemoveAspectView))
			{
				ControllerBase<PlotController>.Instance.RemoveAspectTransformView();
			}
			if (eseamlessFinalizeFlag.HasFlag(ESeamlessFinalizeFlag.TemplateResetCamera))
			{
				ModelBase<PlotModel>.Instance.SwitchCameraMode(EPlotCameraMode.Main);
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ResetArmLengthAndRotation(ModelBase<PlotModel>.Instance.PlotGlobalConfig.PlotTemplateCameraExitRotation.ToUeRotator());
			}
		}

		// Token: 0x0401F970 RID: 129392
		public const int OPTION_SKIPPING_SELECTED = 0;

		// Token: 0x0401F971 RID: 129393
		public const float SKIP_FADE_TIME = 0.25f;

		// Token: 0x0401F972 RID: 129394
		public const int HANG_COUNT_DOWN = 20000;

		// Token: 0x0401F973 RID: 129395
		[Nullable(2)]
		private FlowContext Context;

		// Token: 0x0401F974 RID: 129396
		private readonly Dictionary<long, List<ActionRecord>> CacheFlowIncId = new Dictionary<long, List<ActionRecord>>();

		// Token: 0x0401F975 RID: 129397
		private readonly List<ActionInfo> ActionInfoList = new List<ActionInfo>();

		// Token: 0x0401F976 RID: 129398
		private readonly Queue<ActionInfo> SubActionInfoList = new Queue<ActionInfo>(4);

		// Token: 0x0401F977 RID: 129399
		[Nullable(2)]
		private ActionInfo CurAction;

		// Token: 0x0401F978 RID: 129400
		[Nullable(2)]
		private FlowActionBase CurActionInstance;

		// Token: 0x0401F979 RID: 129401
		[Nullable(2)]
		private ActionInfo CurSubAction;

		// Token: 0x0401F97A RID: 129402
		[Nullable(2)]
		private FlowActionBase CurSubActionInstance;

		// Token: 0x0401F97B RID: 129403
		public readonly FlowSequence FlowSequence = new FlowSequence();

		// Token: 0x0401F97C RID: 129404
		public readonly FlowShowTalk FlowShowTalk = new FlowShowTalk();

		// Token: 0x0401F97D RID: 129405
		[Nullable(2)]
		private Action ActionsCallBack;

		// Token: 0x0401F97E RID: 129406
		private readonly List<Action<bool>> SubActionsCallBack = new List<Action<bool>>();

		// Token: 0x0401F97F RID: 129407
		[Nullable(2)]
		private TimerHandle SkipTimer;

		// Token: 0x0401F980 RID: 129408
		[Nullable(2)]
		private TimerHandle CountDowner;

		// Token: 0x0401F981 RID: 129409
		private readonly ActionInfo DefaultSetPlotModeAction = new ActionInfo
		{
			Name = EAction.SetPlotMode,
			Params = new SetPlotMode
			{
				Mode = EPlotLevel.LevelC.ToEnumString(),
				IsSwitchMainRole = new bool?(false),
				UseFlowCamera = new bool?(true)
			},
			ActionGuid = ""
		};
	}
}
