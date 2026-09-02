using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.TipsTalk
{
	// Token: 0x02005383 RID: 21379
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTipsViewBase : UiPanelBase
	{
		// Token: 0x06036848 RID: 223304 RVA: 0x00DC7374 File Offset: 0x00DC5574
		[NullableContext(0)]
		public UniTask<bool> OpenAsync([Nullable(1)] UiParam param)
		{
			PlotTipsViewBase.<OpenAsync>d__18 <OpenAsync>d__;
			<OpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenAsync>d__.<>4__this = this;
			<OpenAsync>d__.param = param;
			<OpenAsync>d__.<>1__state = -1;
			<OpenAsync>d__.<>t__builder.Start<PlotTipsViewBase.<OpenAsync>d__18>(ref <OpenAsync>d__);
			return <OpenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036849 RID: 223305 RVA: 0x00DC73BF File Offset: 0x00DC55BF
		protected virtual UUIItem GetParentItem()
		{
			return Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.HUD);
		}

		// Token: 0x0603684A RID: 223306 RVA: 0x00DC73CC File Offset: 0x00DC55CC
		public UniTask CloseAsync()
		{
			PlotTipsViewBase.<CloseAsync>d__20 <CloseAsync>d__;
			<CloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseAsync>d__.<>4__this = this;
			<CloseAsync>d__.<>1__state = -1;
			<CloseAsync>d__.<>t__builder.Start<PlotTipsViewBase.<CloseAsync>d__20>(ref <CloseAsync>d__);
			return <CloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603684B RID: 223307 RVA: 0x00DC740F File Offset: 0x00DC560F
		[NullableContext(1)]
		public void RefreshSubtitle(ITalkItem talkItem)
		{
			this.UpdatePlotSubtitle(talkItem);
		}

		// Token: 0x0603684C RID: 223308 RVA: 0x00DC7418 File Offset: 0x00DC5618
		protected virtual void OnInit()
		{
		}

		// Token: 0x0603684D RID: 223309 RVA: 0x00DC741C File Offset: 0x00DC561C
		private void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.UpdatePlotSubtitle));
			Singleton<EventSystem>.Instance.Add(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.HangPlotViewHud, new Action<bool>(this.OnHangPlotViewHud));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
		}

		// Token: 0x0603684E RID: 223310 RVA: 0x00DC749C File Offset: 0x00DC569C
		private void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdatePlotSubtitle, new Action<ITalkItem>(this.UpdatePlotSubtitle));
			Singleton<EventSystem>.Instance.Remove(EEventName.HidePlotUi, new Action<bool>(this.HideAll));
			Singleton<EventSystem>.Instance.Remove(EEventName.HangPlotViewHud, new Action<bool>(this.OnHangPlotViewHud));
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearPlotSubtitle, new Action(this.ClearPlotSubtitle));
		}

		// Token: 0x0603684F RID: 223311 RVA: 0x00DC751C File Offset: 0x00DC571C
		protected override UniTask OnCreateAsync()
		{
			PlotTipsViewBase.<OnCreateAsync>d__25 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<PlotTipsViewBase.<OnCreateAsync>d__25>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036850 RID: 223312 RVA: 0x00DC7560 File Offset: 0x00DC5760
		protected override void OnStart()
		{
			this.OnInit();
			if (ModelBase<PlotModel>.Instance.CurTalkItem != null)
			{
				this.UpdatePlotSubtitle(ModelBase<PlotModel>.Instance.CurTalkItem);
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.GetOriginalItem());
			this.CurLang = Singleton<LanguageSystem>.Instance.PackageAudio;
		}

		// Token: 0x06036851 RID: 223313 RVA: 0x00DC75B0 File Offset: 0x00DC57B0
		protected override void OnAfterShow()
		{
			this.OnAddEventListener();
			this.OnHang(ModelBase<PlotModel>.Instance.HangViewHud, false);
		}

		// Token: 0x06036852 RID: 223314 RVA: 0x00DC75C9 File Offset: 0x00DC57C9
		protected override void OnBeforeHide()
		{
			this.OnRemoveEventListener();
			if (!this.LastHide)
			{
				this.OnHang(true, false);
			}
		}

		// Token: 0x06036853 RID: 223315 RVA: 0x00DC75E1 File Offset: 0x00DC57E1
		protected override void OnBeforeDestroy()
		{
			this.TextureCache.Clear();
			this.ClearPlotSubtitle();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			ControllerBase<FlowController>.Instance.CountDownSkip(false);
		}

		// Token: 0x06036854 RID: 223316 RVA: 0x00DC7610 File Offset: 0x00DC5810
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PlotTipsViewBase.<OnShowAsyncImplementImplement>d__30 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PlotTipsViewBase.<OnShowAsyncImplementImplement>d__30>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06036855 RID: 223317 RVA: 0x00DC7654 File Offset: 0x00DC5854
		protected override UniTask OnHideAsyncImplementImplement()
		{
			PlotTipsViewBase.<OnHideAsyncImplementImplement>d__31 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<PlotTipsViewBase.<OnHideAsyncImplementImplement>d__31>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06036856 RID: 223318 RVA: 0x00DC7698 File Offset: 0x00DC5898
		[NullableContext(1)]
		protected UniTask PlaySequenceAsync(string sequenceName, bool blockClick = false, bool playReverse = false, float? playRate = null)
		{
			PlotTipsViewBase.<PlaySequenceAsync>d__32 <PlaySequenceAsync>d__;
			<PlaySequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlaySequenceAsync>d__.<>4__this = this;
			<PlaySequenceAsync>d__.sequenceName = sequenceName;
			<PlaySequenceAsync>d__.blockClick = blockClick;
			<PlaySequenceAsync>d__.playReverse = playReverse;
			<PlaySequenceAsync>d__.playRate = playRate;
			<PlaySequenceAsync>d__.<>1__state = -1;
			<PlaySequenceAsync>d__.<>t__builder.Start<PlotTipsViewBase.<PlaySequenceAsync>d__32>(ref <PlaySequenceAsync>d__);
			return <PlaySequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036857 RID: 223319 RVA: 0x00DC76FC File Offset: 0x00DC58FC
		[NullableContext(1)]
		private void UpdatePlotSubtitle(ITalkItem inPlotSubtitleInfo)
		{
			if (this.SubmitTimer != null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[PlotTips] 语音完成或没有语音，恢复提交字幕定时", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.SubmitTimer.Resume();
				return;
			}
			if (this.CurrentConfig != inPlotSubtitleInfo)
			{
				this.CurrentConfig = inPlotSubtitleInfo;
				this.PlayAkEvent();
				string flowConfigLocalText = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(this.CurrentConfig.TidTalk ?? string.Empty);
				string text = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(flowConfigLocalText, true) ?? string.Empty;
				UUIText subtitleItem = this.SubtitleItem;
				if (subtitleItem != null)
				{
					subtitleItem.SetText(text, true);
				}
				UTexture utexture = null;
				UTexture utexture2;
				if (this.CurrentConfig.WhoId != null && this.TextureCache.TryGetValue(this.CurrentConfig.WhoId.Value, out utexture2))
				{
					utexture = utexture2;
				}
				if (utexture != null)
				{
					UUITexture iconItem = this.IconItem;
					if (iconItem != null)
					{
						iconItem.SetTexture(utexture);
					}
				}
				else
				{
					ControllerBase<FlowController>.Instance.LogError("[PlotTips] 没有头像", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				string configTextByTable = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, inPlotSubtitleInfo.WhoId);
				if (!StringUtils.IsEmpty(configTextByTable))
				{
					UUIText nameItem = this.NameItem;
					if (nameItem != null)
					{
						nameItem.SetText(configTextByTable, true);
					}
				}
				else
				{
					ControllerBase<FlowController>.Instance.LogError("[PlotTips] 没有对话人", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotTips] 字幕:";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Text", text);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (this.CurLang != Singleton<LanguageSystem>.Instance.PackageAudio)
			{
				if (this.PlotPlayEventResult != 0)
				{
					this.CallbackEnableId++;
					Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
					{
						TransitionDuration = new int?(0)
					}));
					this.PlotPlayEventResult = 0;
				}
				this.CurLang = Singleton<LanguageSystem>.Instance.PackageAudio;
			}
			if (this.PlayTalkAudio() || this.PlayTone())
			{
				return;
			}
			ICaptionParam captionParams = this.CurrentConfig.CaptionParams;
			this.SubmitSubtitle(((captionParams != null) ? captionParams.TotalTime : null) ?? ModelBase<PlotModel>.Instance.PlotGlobalConfig.DefaultDurationPrompt, false);
		}

		// Token: 0x06036858 RID: 223320 RVA: 0x00DC7950 File Offset: 0x00DC5B50
		private unsafe void SubmitSubtitle(float delay, bool needPause = false)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[PlotTips] 开始延迟完成字幕";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("delay", delay);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isPause", needPause);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.SubmitTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				ITalkItem currentConfig = this.CurrentConfig;
				this.ClearPlotSubtitle();
				ControllerBase<FlowController>.Instance.FlowShowTalk.SubmitSubtitle(currentConfig);
			}, (float)((long)(delay * 1000f)), null, null, true, 1f);
			if (needPause)
			{
				this.SubmitTimer.Pause();
			}
		}

		// Token: 0x06036859 RID: 223321 RVA: 0x00DC79F8 File Offset: 0x00DC5BF8
		private void PauseSubtitle()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[PlotTips] 暂停字幕", default(ReadOnlySpan<ValueTuple<string, object>>));
			TimerHandle submitTimer = this.SubmitTimer;
			if (submitTimer != null)
			{
				submitTimer.Pause();
			}
			if (this.PlotPlayEventResult != 0)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[PlotTips] 暂停音频播放", default(ReadOnlySpan<ValueTuple<string, object>>));
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(1000)
				}));
			}
		}

		// Token: 0x0603685A RID: 223322 RVA: 0x00DC7A87 File Offset: 0x00DC5C87
		private void HideAll(bool isHidden)
		{
			base.SetUiActive(!isHidden);
		}

		// Token: 0x0603685B RID: 223323 RVA: 0x00DC7A93 File Offset: 0x00DC5C93
		private void OnHangPlotViewHud(bool isHang)
		{
			this.OnHang(isHang, true);
		}

		// Token: 0x0603685C RID: 223324 RVA: 0x00DC7AA0 File Offset: 0x00DC5CA0
		private void OnHang(bool isHang = false, bool bSetActive = true)
		{
			if (this.IsHangInternal == isHang)
			{
				return;
			}
			if (!isHang && base.IsHideOrHiding)
			{
				return;
			}
			this.IsHangInternal = isHang;
			if (isHang)
			{
				if (bSetActive)
				{
					base.SetUiActive(false);
				}
				this.PauseSubtitle();
				ControllerBase<FlowController>.Instance.CountDownSkip(true);
				return;
			}
			if (bSetActive)
			{
				base.SetUiActive(true);
			}
			if (ModelBase<PlotModel>.Instance.CurTalkItem != null)
			{
				this.UpdatePlotSubtitle(ModelBase<PlotModel>.Instance.CurTalkItem);
			}
			ControllerBase<FlowController>.Instance.CountDownSkip(false);
		}

		// Token: 0x0603685D RID: 223325 RVA: 0x00DC7B1C File Offset: 0x00DC5D1C
		private void ClearPlotSubtitle()
		{
			TimerHandle submitTimer = this.SubmitTimer;
			if (submitTimer != null)
			{
				submitTimer.Remove();
			}
			this.SubmitTimer = null;
			this.CurrentConfig = null;
			if (this.PlotPlayEventResult != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, null);
			}
			this.PlotPlayEventResult = 0;
			this.CallbackEnableId++;
		}

		// Token: 0x0603685E RID: 223326 RVA: 0x00DC7B80 File Offset: 0x00DC5D80
		private unsafe bool PlayTalkAudio()
		{
			ITalkItem currentConfig = this.CurrentConfig;
			PlotAudio? plotAudio = ((currentConfig != null) ? currentConfig.PlayVoice : null).GetValueOrDefault() ? ConfigPlotAudioById.GetConfig(this.CurrentConfig.TidTalk, true) : null;
			if (plotAudio == null)
			{
				return false;
			}
			ExternalSourceSetting? config = ConfigExternalSourceSettingById.GetConfig(plotAudio.Value.ExternalSourceSetting, true);
			string mediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(plotAudio.Value);
			string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(config.Value.SubtitleEvent);
			if (this.PlotPlayEventResult == 0)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotTips] 语音播放";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mediaName", mediaName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.CallbackEnableId++;
				int id = this.CallbackEnableId;
				AudioSystem instance2 = Singleton<AudioSystem>.Instance;
				string @event = this.OverrideAudioEventName ?? text;
				UiParam uiParam = this.UiParam;
				this.PlotPlayEventResult = instance2.PostEvent(@event, (uiParam != null) ? uiParam.AudioAttachActor : null, new PostEventArgs?(new PostEventArgs
				{
					ExternalSourceName = (this.OverrideAudioSrcName ?? config.Value.SubtitleSrc),
					ExternalSourceMediaName = mediaName,
					CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
					CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
					{
						global::Log instance4 = Singleton<global::Log>.Instance;
						ELogModule module3 = ELogModule.Plot;
						ELogAuthor author3 = ELogAuthor.FZX;
						string message3 = "[PlotTips] 语音播放完成回调";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("mediaName", mediaName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("callbackType", callbackType);
						instance4.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						if (callbackType != EAkCallbackType.EndOfEvent || id != this.CallbackEnableId)
						{
							return;
						}
						this.PlotPlayEventResult = 0;
						PlotTipsViewBase <>4__this = this;
						ICaptionParam captionParams = this.CurrentConfig.CaptionParams;
						<>4__this.SubmitSubtitle(((captionParams != null) ? captionParams.IntervalTime : null) ?? ModelBase<PlotModel>.Instance.PlotGlobalConfig.AudioEndWaitTimePrompt, this.IsHangInternal);
					}
				}));
			}
			else
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Resume, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(1000)
				}));
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Plot;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "[PlotTips] 恢复音频播放";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("mediaName", mediaName);
				instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return true;
		}

		// Token: 0x0603685F RID: 223327 RVA: 0x00DC7D70 File Offset: 0x00DC5F70
		private unsafe bool PlayTone()
		{
			ITalkItem currentConfig = this.CurrentConfig;
			if (((currentConfig != null) ? currentConfig.UniversalTone : null) == null)
			{
				return false;
			}
			int? timberId = this.CurrentConfig.UniversalTone.TimberId;
			Speaker? speaker;
			int? num = (timberId != null) ? timberId : ((ConfigSpeakerById.GetConfig(this.CurrentConfig.WhoId.Value, true) != null) ? new int?(speaker.GetValueOrDefault().TimberId) : null);
			int universalToneId = this.CurrentConfig.UniversalTone.UniversalToneId;
			if (num == null || universalToneId == 0)
			{
				ControllerBase<FlowController>.Instance.LogError("语气配置无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			Interjection? config = ConfigInterjectionByTimberIdAndUniversalToneId.GetConfig(num.Value, universalToneId, true);
			if (config == null)
			{
				FlowController instance = ControllerBase<FlowController>.Instance;
				string text = "无法获取语气配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timberId", num.Value);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tone", universalToneId);
				instance.LogError(text, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			string eventName = Singleton<AudioSystem>.Instance.parseAudioEventPath(config.Value.AkEvent);
			if (this.PlotPlayEventResult == 0)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[PlotTips] 语气播放";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("event", eventName);
				instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.CallbackEnableId++;
				int id = this.CallbackEnableId;
				this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent(eventName, null, new PostEventArgs?(new PostEventArgs
				{
					CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
					CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
					{
						global::Log instance3 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Plot;
						ELogAuthor author2 = ELogAuthor.FZX;
						string message2 = "[PlotTips] 语气播放完成回调";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("event", eventName);
						instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						if (callbackType != EAkCallbackType.EndOfEvent || id != this.CallbackEnableId)
						{
							return;
						}
						this.PlotPlayEventResult = 0;
						PlotTipsViewBase <>4__this = this;
						ICaptionParam captionParams = this.CurrentConfig.CaptionParams;
						<>4__this.SubmitSubtitle(((captionParams != null) ? captionParams.IntervalTime : null) ?? ModelBase<PlotModel>.Instance.PlotGlobalConfig.AudioEndWaitTimePrompt, this.IsHangInternal);
					}
				}));
			}
			else
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Resume, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(1000)
				}));
			}
			return true;
		}

		// Token: 0x06036860 RID: 223328 RVA: 0x00DC7FA4 File Offset: 0x00DC61A4
		private void PlayAkEvent()
		{
			IPostAkEventType talkAkEvent = this.CurrentConfig.TalkAkEvent;
			if (talkAkEvent == null)
			{
				return;
			}
			if (talkAkEvent.Type != EPostAkEvent.Global)
			{
				if (talkAkEvent.Type == EPostAkEvent.Target)
				{
					IPostAkEventTargeted postAkEventTargeted = talkAkEvent as IPostAkEventTargeted;
					string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(postAkEventTargeted.AkEvent);
					if (string.IsNullOrEmpty(text))
					{
						return;
					}
					int entityId = postAkEventTargeted.EntityId;
					EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
					if (entityByPbDataId == null)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.Event;
						ELogAuthor author = ELogAuthor.FZX;
						string message = "实体不存在";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					BaseActorComponent component = entityByPbDataId.Entity.GetComponent<BaseActorComponent>();
					AActor aactor = (component != null) ? component.Owner : null;
					if (aactor == null || !aactor.IsValid())
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.FZX;
						string message2 = "未能获取到该实体对应的有效Actor";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entityId);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return;
					}
					Singleton<AudioSystem>.Instance.PostEvent(text, aactor, null);
				}
				return;
			}
			IPostAkEventGlobal postAkEventGlobal = talkAkEvent as IPostAkEventGlobal;
			string text2 = Singleton<AudioSystem>.Instance.parseAudioEventPath(postAkEventGlobal.AkEvent);
			if (string.IsNullOrEmpty(text2))
			{
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent(text2);
		}

		// Token: 0x17008D8A RID: 36234
		// (get) Token: 0x06036861 RID: 223329 RVA: 0x00DC80E2 File Offset: 0x00DC62E2
		protected bool IsHang
		{
			get
			{
				return this.IsHangInternal;
			}
		}

		// Token: 0x06036862 RID: 223330 RVA: 0x00DC80EC File Offset: 0x00DC62EC
		protected EUiViewName? GetViewName()
		{
			UiParam uiParam = this.UiParam;
			if (uiParam == null)
			{
				return null;
			}
			return uiParam.ViewName;
		}

		// Token: 0x0401F63C RID: 128572
		private const int BREAK_TIME = 1000;

		// Token: 0x0401F63D RID: 128573
		private UiParam UiParam;

		// Token: 0x0401F63E RID: 128574
		private ITalkItem CurrentConfig;

		// Token: 0x0401F63F RID: 128575
		private TimerHandle SubmitTimer;

		// Token: 0x0401F640 RID: 128576
		private bool IsHangInternal;

		// Token: 0x0401F641 RID: 128577
		private int PlotPlayEventResult;

		// Token: 0x0401F642 RID: 128578
		private int CallbackEnableId;

		// Token: 0x0401F643 RID: 128579
		[Nullable(1)]
		private readonly Dictionary<int, UTexture> TextureCache = new Dictionary<int, UTexture>();

		// Token: 0x0401F644 RID: 128580
		[Nullable(1)]
		private string CurLang = string.Empty;

		// Token: 0x0401F645 RID: 128581
		[Nullable(1)]
		protected string ResourceId = string.Empty;

		// Token: 0x0401F646 RID: 128582
		protected UUITexture IconItem;

		// Token: 0x0401F647 RID: 128583
		protected UUIText SubtitleItem;

		// Token: 0x0401F648 RID: 128584
		protected UUIText NameItem;

		// Token: 0x0401F649 RID: 128585
		protected string OverrideAudioEventName;

		// Token: 0x0401F64A RID: 128586
		protected string OverrideAudioSrcName;

		// Token: 0x0401F64B RID: 128587
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401F64C RID: 128588
		public bool FirstShow;

		// Token: 0x0401F64D RID: 128589
		public bool LastHide;
	}
}
