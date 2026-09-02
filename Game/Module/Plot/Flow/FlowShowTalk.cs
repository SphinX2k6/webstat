using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.LevelLoading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x02005408 RID: 21512
	[NullableContext(2)]
	[Nullable(0)]
	public class FlowShowTalk
	{
		// Token: 0x06036ED9 RID: 224985 RVA: 0x00DF0E6C File Offset: 0x00DEF06C
		public void FinishShowTalk()
		{
			FlowContext context = this.Context;
			long? ownerId = (context != null) ? new long?(context.FlowIncId) : null;
			this.CheckLastOption();
			this.LastHasOption = false;
			ModelBase<PlotModel>.Instance.CenterTextTransition(false, null);
			ModelBase<PlotModel>.Instance.ClearOptionReadState();
			ModelBase<PlotModel>.Instance.CurShowTalk = null;
			ModelBase<PlotModel>.Instance.OptionEnable = true;
			ModelBase<PlotModel>.Instance.PlotTemplate.OnFinishShowTalk();
			this.Context.CurTalkId = -1;
			this.CurTalkSubtitleEnd = false;
			this.CurOptionShowing = false;
			this.Context.CurOptionId = -1;
			this.Context.CurSubActionId = 0;
			this.Context.CurShowTalk = null;
			this.Context.CurShowTalkActionId = 0;
			this.CurTalkItemIndex = -1;
			this.CurShowTalk = null;
			this.Context = null;
			this.IsShowCompleted = false;
			this.IsShowingSubtitle = false;
			this.IsPlayingStartActions = false;
			ControllerBase<PlotController>.Instance.ClearUi(ownerId);
			ControllerBase<FlowController>.Instance.EnableSkip(false);
			if (this.Level != null && this.CheckPlotLevelInAbc())
			{
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.ExitCameraGuideAtOnce();
			}
			if (TimerSystem.Instance.Has(this.DelayPlayGamepadShakeHandle))
			{
				TimerSystem.Instance.Remove(this.DelayPlayGamepadShakeHandle);
			}
			if (this.StopGamepadShakeParams != null)
			{
				Global.CharacterController.StopKuroForceFeedback(this.StopGamepadShakeParams.GamepadShakeAsset, this.StopGamepadShakeParams.Tag);
				IStopGamepadShake stopGamepadShakeParams = this.StopGamepadShakeParams;
				bool flag;
				if (stopGamepadShakeParams == null)
				{
					flag = false;
				}
				else
				{
					UForceFeedbackComponent feedbackComponent = stopGamepadShakeParams.FeedbackComponent;
					flag = ((feedbackComponent != null) ? new bool?(feedbackComponent.IsValid()) : null).GetValueOrDefault();
				}
				if (flag)
				{
					this.StopGamepadShakeParams.FeedbackComponent.Stop();
				}
			}
			this.Level = null;
			Singleton<EventSystem>.Instance.Emit(EEventName.PlotEndShowTalk);
			ControllerBase<FlowController>.Instance.RunNextAction();
		}

		// Token: 0x06036EDA RID: 224986 RVA: 0x00DF1050 File Offset: 0x00DEF250
		[NullableContext(1)]
		public void Start(ShowTalk inShowTalk, FlowContext context)
		{
			this.CurShowTalk = inShowTalk;
			this.Context = context;
			this.CurTalkItemIndex = -1;
			this.Level = ModelBase<PlotModel>.Instance.PlotConfig.PlotLevel;
			ModelBase<PlotModel>.Instance.ResetOptionReadState(inShowTalk);
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				bool flag;
				if (inShowTalk == null)
				{
					flag = true;
				}
				else
				{
					ITalkItem talkItem = inShowTalk.TalkItems.ElementAtOrDefault(0);
					if (talkItem == null)
					{
						flag = true;
					}
					else
					{
						ITalkBackground backgroundConfig = talkItem.BackgroundConfig;
						if (backgroundConfig == null)
						{
							flag = true;
						}
						else
						{
							ETalkBackgroundType type = backgroundConfig.Type;
							flag = false;
						}
					}
				}
				if (flag)
				{
					bool flag2;
					if (inShowTalk == null)
					{
						flag2 = true;
					}
					else
					{
						ITalkItem talkItem2 = inShowTalk.TalkItems.ElementAtOrDefault(0);
						flag2 = (((talkItem2 != null) ? talkItem2.Type : null).GetValueOrDefault() != ETalkItemType.CenterText);
					}
					if (flag2)
					{
						LevelLoadingController instance = ControllerBase<LevelLoadingController>.Instance;
						ELoadingReason reason = ELoadingReason.Common;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 3);
						defaultInterpolatedStringHandler.AppendLiteral("FlowShowTalk_");
						defaultInterpolatedStringHandler.AppendFormatted(context.FlowListName);
						defaultInterpolatedStringHandler.AppendLiteral("_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(context.FlowId);
						defaultInterpolatedStringHandler.AppendLiteral("_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(context.FlowStateId);
						instance.CloseLoading(reason, defaultInterpolatedStringHandler.ToStringAndClear(), null, new float?(0f));
					}
				}
			}
			ControllerBase<PlotController>.Instance.PlotViewManager.EmitPlotStartShowTalk(this.CurShowTalk);
			ModelBase<PlotModel>.Instance.CurShowTalk = inShowTalk;
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelE || this.Context.IsBackground)
			{
				this.NextShowTalkItem();
				return;
			}
			ControllerBase<PlotController>.Instance.WaitViewCallback(delegate(bool result)
			{
				if (!result)
				{
					return;
				}
				this.NextShowTalkItem();
			});
		}

		// Token: 0x06036EDB RID: 224987 RVA: 0x00DF11D4 File Offset: 0x00DEF3D4
		private void NextShowTalkItem()
		{
			if (this.CurShowTalk == null)
			{
				ControllerBase<FlowController>.Instance.LogError("当前不在ShowTalk节点", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.CurTalkItemIndex++;
			if (this.CurShowTalk.TalkItems == null || this.CurTalkItemIndex >= this.CurShowTalk.TalkItems.Count)
			{
				this.FinishShowTalk();
				return;
			}
			ITalkItem talkItem = this.CurShowTalk.TalkItems[this.CurTalkItemIndex];
			this.HandleShowTalkItem(talkItem).Forget();
		}

		// Token: 0x06036EDC RID: 224988 RVA: 0x00DF1260 File Offset: 0x00DEF460
		public void SwitchTalkItem(int inTalkId)
		{
			int count = this.CurShowTalk.TalkItems.Count;
			for (int i = 0; i < count; i++)
			{
				ITalkItem talkItem = this.CurShowTalk.TalkItems[i];
				if (talkItem.Id == inTalkId)
				{
					this.CurTalkItemIndex = i;
					this.HandleShowTalkItem(talkItem).Forget();
					return;
				}
			}
			this.FinishShowTalk();
		}

		// Token: 0x06036EDD RID: 224989 RVA: 0x00DF12C0 File Offset: 0x00DEF4C0
		[NullableContext(1)]
		private UniTask HandleShowTalkItem(ITalkItem talkItem)
		{
			FlowShowTalk.<HandleShowTalkItem>d__19 <HandleShowTalkItem>d__;
			<HandleShowTalkItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleShowTalkItem>d__.<>4__this = this;
			<HandleShowTalkItem>d__.talkItem = talkItem;
			<HandleShowTalkItem>d__.<>1__state = -1;
			<HandleShowTalkItem>d__.<>t__builder.Start<FlowShowTalk.<HandleShowTalkItem>d__19>(ref <HandleShowTalkItem>d__);
			return <HandleShowTalkItem>d__.<>t__builder.Task;
		}

		// Token: 0x06036EDE RID: 224990 RVA: 0x00DF130C File Offset: 0x00DEF50C
		private void PlayStartActions()
		{
			if (this.IsPlayingStartActions)
			{
				return;
			}
			ITalkItem curTalkItem = this.CurTalkItem;
			List<ActionInfo> list = (curTalkItem != null) ? curTalkItem.IntroActions : null;
			if (list == null || list.Count == 0)
			{
				return;
			}
			this.IsPlayingStartActions = true;
			ControllerBase<FlowController>.Instance.ExecuteSubActions(list, new Action<bool>(this.OnStartActionsCompleted), false);
		}

		// Token: 0x06036EDF RID: 224991 RVA: 0x00DF1360 File Offset: 0x00DEF560
		private void OnStartActionsCompleted(bool result)
		{
			this.IsPlayingStartActions = false;
			this.HandleShowTalkItemEnd(null);
		}

		// Token: 0x06036EE0 RID: 224992 RVA: 0x00DF1370 File Offset: 0x00DEF570
		private void HandleShowTalkItemEnd(ITalkItem config = null)
		{
			if (this.CurShowTalk == null || this.CurTalkSubtitleEnd || this.IsPlayingStartActions || this.IsShowingSubtitle)
			{
				return;
			}
			ITalkItem talkItem = config ?? this.CurTalkItem;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[FlowShowTalk][Subtitle] 字幕完成";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", talkItem.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CurTalkSubtitleEnd = true;
			this.CurTalkItem = null;
			ControllerBase<PlotController>.Instance.PlotViewManager.OnSubmitSubtitle();
			ControllerBase<FlowController>.Instance.ExecuteSubActions(talkItem.Actions, new Action<bool>(this.OnTalkActionCompleted), false);
		}

		// Token: 0x06036EE1 RID: 224993 RVA: 0x00DF1418 File Offset: 0x00DEF618
		private void OnTalkActionCompleted(bool result)
		{
			if (!result)
			{
				return;
			}
			ITalkItem talkItem = this.CurShowTalk.TalkItems[this.CurTalkItemIndex];
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelE)
			{
				this.NextShowTalkItem();
				return;
			}
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelD && talkItem.TimeLimitOptionGroup == null)
			{
				this.NextShowTalkItem();
				return;
			}
			if (talkItem.Type.GetValueOrDefault() == ETalkItemType.SystemOption)
			{
				this.CurOptionShowing = true;
				ControllerBase<PlotController>.Instance.ShowSystemOption(talkItem, new Action<int, List<ActionInfo>>(this.SelectOption));
				return;
			}
			if (talkItem.Options == null || talkItem.Options.Count <= 0)
			{
				this.NextShowTalkItem();
				return;
			}
			this.Context.CurOptionId = -1;
			this.CurOptionShowing = true;
			if (this.Context.IsBackground)
			{
				int recommendedOption = ControllerBase<FlowController>.Instance.GetRecommendedOption(talkItem);
				List<ActionInfo> actions = talkItem.Options[recommendedOption].Actions;
				this.HandleShowTalkItemOption(recommendedOption, actions);
				return;
			}
			ControllerBase<PlotController>.Instance.PlotViewManager.ShowPlotSubtitleOptions();
		}

		// Token: 0x06036EE2 RID: 224994 RVA: 0x00DF1518 File Offset: 0x00DEF718
		[NullableContext(1)]
		public void HandleShowTalkItemOption(int optionId, List<ActionInfo> inActions)
		{
			FlowContext context = this.Context;
			if (((context != null) ? context.CurShowTalk : null) == null)
			{
				return;
			}
			if (this.Context.CurOptionId != -1 || !this.CurOptionShowing)
			{
				return;
			}
			this.LastSelectedOption = true;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[FlowShowTalk][Subtitle] 选择选项";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", optionId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.Context.CurOptionId = optionId;
			this.CurOptionShowing = false;
			ControllerBase<PlotController>.Instance.PlotViewManager.OnSelectedOptions();
			ControllerBase<FlowController>.Instance.SelectOption(this.Context.CurTalkId, optionId);
			ControllerBase<FlowController>.Instance.ExecuteSubActions(inActions, new Action<bool>(this.OnOptionActionCompleted), false);
		}

		// Token: 0x06036EE3 RID: 224995 RVA: 0x00DF15D4 File Offset: 0x00DEF7D4
		public void OnOptionActionCompleted(bool result)
		{
			if (!result)
			{
				return;
			}
			this.NextShowTalkItem();
		}

		// Token: 0x06036EE4 RID: 224996 RVA: 0x00DF15E0 File Offset: 0x00DEF7E0
		public void Skip()
		{
			if (this.CurTalkItemIndex == -1)
			{
				this.NextShowTalkItem();
				return;
			}
			if (this.CurTalkItemIndex < this.CurShowTalk.TalkItems.Count)
			{
				if (this.CurOptionShowing)
				{
					ITalkItem talkItem = this.CurShowTalk.TalkItems[this.CurTalkItemIndex];
					int recommendedOption = ControllerBase<FlowController>.Instance.GetRecommendedOption(talkItem);
					this.HandleShowTalkItemOption(recommendedOption, talkItem.Options[recommendedOption].Actions);
					return;
				}
				if (!this.CurTalkSubtitleEnd && this.IsShowCompleted)
				{
					this.SubmitSubtitleInternal(this.CurShowTalk.TalkItems[this.CurTalkItemIndex]);
					return;
				}
			}
			else
			{
				this.FinishShowTalk();
			}
		}

		// Token: 0x06036EE5 RID: 224997 RVA: 0x00DF168C File Offset: 0x00DEF88C
		private void CheckLastOption()
		{
			if (this.LastHasOption && !this.LastSelectedOption)
			{
				FlowController instance = ControllerBase<FlowController>.Instance;
				string text = "遗漏选项C级";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Miss TalkItem Id", this.LastId);
				instance.LogError(text, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			ShowTalk curShowTalk = this.CurShowTalk;
			if (((curShowTalk != null) ? curShowTalk.TalkItems : null) == null || this.CurTalkItemIndex >= this.CurShowTalk.TalkItems.Count)
			{
				return;
			}
			this.LastHasOption = (this.CurShowTalk.TalkItems[this.CurTalkItemIndex].Options != null && this.CurShowTalk.TalkItems[this.CurTalkItemIndex].Options.Count > 0);
			this.LastId = this.CurShowTalk.TalkItems[this.CurTalkItemIndex].Id;
		}

		// Token: 0x06036EE6 RID: 224998 RVA: 0x00DF176D File Offset: 0x00DEF96D
		private void PlayMontage()
		{
			FlowContext context = this.Context;
			if (context != null && context.IsBackground)
			{
				return;
			}
			ModelBase<PlotModel>.Instance.HandlePlayMontage(this.CurTalkItem.Montage);
		}

		// Token: 0x06036EE7 RID: 224999 RVA: 0x00DF179C File Offset: 0x00DEF99C
		private void PlayGamepadShake(IGamepadShakeInTalk config)
		{
			FlowContext context = this.Context;
			if ((context != null && context.IsBackground) || config == null || this.Level.GetValueOrDefault() != EPlotLevel.LevelC)
			{
				return;
			}
			this.DelayPlayGamepadShakeHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.StopGamepadShakeParams = new StopGamepadShakeImpl();
				ControllerBase<GamepadController>.Instance.TriggerGamepadShakeEvent(config.Options, this.StopGamepadShakeParams).Forget();
			}, (float)((int)(config.DelayTime * 1000f)), null, null, true, 1f);
		}

		// Token: 0x06036EE8 RID: 225000 RVA: 0x00DF1820 File Offset: 0x00DEFA20
		private UniTask SetBackgroundImage()
		{
			FlowShowTalk.<SetBackgroundImage>d__30 <SetBackgroundImage>d__;
			<SetBackgroundImage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetBackgroundImage>d__.<>4__this = this;
			<SetBackgroundImage>d__.<>1__state = -1;
			<SetBackgroundImage>d__.<>t__builder.Start<FlowShowTalk.<SetBackgroundImage>d__30>(ref <SetBackgroundImage>d__);
			return <SetBackgroundImage>d__.<>t__builder.Task;
		}

		// Token: 0x06036EE9 RID: 225001 RVA: 0x00DF1864 File Offset: 0x00DEFA64
		[NullableContext(1)]
		private UniTask SetTemplate(ITalkItem talkItem)
		{
			FlowShowTalk.<SetTemplate>d__31 <SetTemplate>d__;
			<SetTemplate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTemplate>d__.<>4__this = this;
			<SetTemplate>d__.talkItem = talkItem;
			<SetTemplate>d__.<>1__state = -1;
			<SetTemplate>d__.<>t__builder.Start<FlowShowTalk.<SetTemplate>d__31>(ref <SetTemplate>d__);
			return <SetTemplate>d__.<>t__builder.Task;
		}

		// Token: 0x06036EEA RID: 225002 RVA: 0x00DF18B0 File Offset: 0x00DEFAB0
		private UniTask ShowCenterTextView()
		{
			FlowShowTalk.<ShowCenterTextView>d__32 <ShowCenterTextView>d__;
			<ShowCenterTextView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowCenterTextView>d__.<>4__this = this;
			<ShowCenterTextView>d__.<>1__state = -1;
			<ShowCenterTextView>d__.<>t__builder.Start<FlowShowTalk.<ShowCenterTextView>d__32>(ref <ShowCenterTextView>d__);
			return <ShowCenterTextView>d__.<>t__builder.Task;
		}

		// Token: 0x06036EEB RID: 225003 RVA: 0x00DF18F4 File Offset: 0x00DEFAF4
		private void ShowSubtitle()
		{
			if (this.Context.IsBackground)
			{
				return;
			}
			this.IsShowingSubtitle = true;
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelE && ControllerBase<PlotController>.Instance.ShowTipsView(this.CurTalkItem, this.Context.PromptStyle.Value, this.Context.UiParam))
			{
				return;
			}
			if (this.Level.GetValueOrDefault() == EPlotLevel.LevelC)
			{
				ITalkItem curTalkItem = this.CurTalkItem;
				if (curTalkItem != null && curTalkItem.Type.GetValueOrDefault() == ETalkItemType.CenterText)
				{
					ModelBase<PlotModel>.Instance.ShowTalkCenterText((ITalkItemCenterText)this.CurTalkItem, delegate
					{
						this.SubmitSubtitle(null);
					});
					return;
				}
			}
			ControllerBase<PlotController>.Instance.PlotViewManager.UpdatePlotSubtitle(this.CurTalkItem);
		}

		// Token: 0x06036EEC RID: 225004 RVA: 0x00DF19B6 File Offset: 0x00DEFBB6
		private void SubmitSubtitleInternal(ITalkItem config = null)
		{
			this.IsShowingSubtitle = false;
			this.HandleShowTalkItemEnd(config);
		}

		// Token: 0x06036EED RID: 225005 RVA: 0x00DF19C6 File Offset: 0x00DEFBC6
		public void SubmitSubtitle(ITalkItem config)
		{
			if (this.Context == null || this.Context.IsBackground)
			{
				return;
			}
			this.SubmitSubtitleInternal(config);
		}

		// Token: 0x06036EEE RID: 225006 RVA: 0x00DF19E5 File Offset: 0x00DEFBE5
		[NullableContext(1)]
		public void SelectOption(int optionId, List<ActionInfo> inActions)
		{
			if (this.Context == null || this.Context.IsBackground)
			{
				return;
			}
			this.HandleShowTalkItemOption(optionId, inActions);
		}

		// Token: 0x06036EEF RID: 225007 RVA: 0x00DF1A08 File Offset: 0x00DEFC08
		public bool CheckPlotLevelInAbc()
		{
			EPlotLevel? level = this.Level;
			EPlotLevel eplotLevel = EPlotLevel.LevelA;
			return (level.GetValueOrDefault() == eplotLevel & level != null) || this.Level.GetValueOrDefault() == EPlotLevel.LevelB || this.Level.GetValueOrDefault() == EPlotLevel.LevelC;
		}

		// Token: 0x0401F9E9 RID: 129513
		public ShowTalk CurShowTalk;

		// Token: 0x0401F9EA RID: 129514
		public int CurTalkItemIndex;

		// Token: 0x0401F9EB RID: 129515
		public FlowContext Context;

		// Token: 0x0401F9EC RID: 129516
		private EPlotLevel? Level;

		// Token: 0x0401F9ED RID: 129517
		private ITalkItem CurTalkItem;

		// Token: 0x0401F9EE RID: 129518
		private int LastId = -1;

		// Token: 0x0401F9EF RID: 129519
		private bool LastHasOption;

		// Token: 0x0401F9F0 RID: 129520
		private bool LastSelectedOption;

		// Token: 0x0401F9F1 RID: 129521
		private bool IsShowCompleted;

		// Token: 0x0401F9F2 RID: 129522
		private bool CurTalkSubtitleEnd;

		// Token: 0x0401F9F3 RID: 129523
		private bool CurOptionShowing;

		// Token: 0x0401F9F4 RID: 129524
		private bool IsPlayingStartActions;

		// Token: 0x0401F9F5 RID: 129525
		public bool IsShowingSubtitle;

		// Token: 0x0401F9F6 RID: 129526
		private IStopGamepadShake StopGamepadShakeParams;

		// Token: 0x0401F9F7 RID: 129527
		private TimerHandle DelayPlayGamepadShakeHandle;
	}
}
