using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053F1 RID: 21489
	[NullableContext(1)]
	[Nullable(0)]
	public class PlotTextAudioComponent
	{
		// Token: 0x06036D9A RID: 224666 RVA: 0x00DE813F File Offset: 0x00DE633F
		public void Init(PlotTextAudioComponentContext context)
		{
			this.OnAudioStartDelegate = context.OnAudioStartDelegate;
			this.OnAudioEndDelegate = context.OnAudioEndDelegate;
			this.OnAudioLoadTimeoutDelegate = context.OnAudioLoadTimeoutDelegate;
		}

		// Token: 0x06036D9B RID: 224667 RVA: 0x00DE8168 File Offset: 0x00DE6368
		public bool PlayTalkAudio(PlotTextAudioComponentPlayTalkContext context)
		{
			if (this.IsPlaying || this.IsLoading)
			{
				return false;
			}
			this.IsLoading = true;
			PlotAudio plotAudioConfig = context.PlotAudioConfig;
			ExternalSourceSetting? config = ConfigExternalSourceSettingById.GetConfig(plotAudioConfig.ExternalSourceSetting, true);
			string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(plotAudioConfig);
			string eventName = Singleton<AudioSystem>.Instance.parseAudioEventPath(config.Value.SubtitleEvent);
			this.PlayType = EPlotTextAudioComponentPlayType.Talk;
			this.PlayTalkContext = context;
			int id = this.UniqueId;
			AActor target = null;
			this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent(eventName, target, new PostEventArgs?(new PostEventArgs
			{
				ExternalSourceName = config.Value.SubtitleSrc,
				ExternalSourceMediaName = externalSourcesMediaName,
				CallbackMask = new ECallbackMask?(ECallbackMask.Duration),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					this.OnAudioPlayCallback(id, eventName, callbackType, callbackInfo);
				}
			}));
			this.AddAudioLoadTimeoutTimer();
			return true;
		}

		// Token: 0x06036D9C RID: 224668 RVA: 0x00DE8268 File Offset: 0x00DE6468
		public bool TryPlayTalkAudioByTalkItem(ITalkItem talkItem)
		{
			PlotAudio? plotAudio = (talkItem.PlayVoice != null && talkItem.PlayVoice.Value) ? ConfigPlotAudioById.GetConfig(talkItem.TidTalk, true) : null;
			if (plotAudio == null)
			{
				return false;
			}
			PlotTextAudioComponentPlayTalkContext context = new PlotTextAudioComponentPlayTalkContext
			{
				PlotAudioConfig = plotAudio.Value
			};
			return this.PlayTalkAudio(context);
		}

		// Token: 0x06036D9D RID: 224669 RVA: 0x00DE82D4 File Offset: 0x00DE64D4
		public bool PlayTone(PlotTextAudioComponentPlayToneContext context)
		{
			if (this.IsPlaying || this.IsLoading)
			{
				return false;
			}
			this.IsLoading = true;
			Interjection? config = ConfigInterjectionByTimberIdAndUniversalToneId.GetConfig(context.TimberId, context.UniversalToneId, true);
			if (config == null)
			{
				return false;
			}
			string eventName = Singleton<AudioSystem>.Instance.parseAudioEventPath(config.Value.AkEvent);
			int id = this.UniqueId;
			this.EventName = eventName;
			this.PlayType = EPlotTextAudioComponentPlayType.Tone;
			this.PlayToneContext = context;
			AActor target = null;
			this.PlotPlayEventResult = Singleton<AudioSystem>.Instance.PostEvent(eventName, target, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.Duration),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					this.OnAudioPlayCallback(id, eventName, callbackType, callbackInfo);
				}
			}));
			this.AddAudioLoadTimeoutTimer();
			return true;
		}

		// Token: 0x06036D9E RID: 224670 RVA: 0x00DE83BC File Offset: 0x00DE65BC
		public bool TryPlayToneByTalkItem(ITalkItem talkItem)
		{
			if (this.IsPlaying || this.IsLoading)
			{
				return false;
			}
			IUniversalTone universalTone = talkItem.UniversalTone;
			if (universalTone != null && universalTone.TimberId != null)
			{
				bool flag;
				if (universalTone == null)
				{
					flag = true;
				}
				else
				{
					int universalToneId = universalTone.UniversalToneId;
					flag = false;
				}
				if (!flag)
				{
					PlotTextAudioComponentPlayToneContext context = new PlotTextAudioComponentPlayToneContext
					{
						TimberId = universalTone.TimberId.Value,
						UniversalToneId = universalTone.UniversalToneId
					};
					return this.PlayTone(context);
				}
			}
			return false;
		}

		// Token: 0x06036D9F RID: 224671 RVA: 0x00DE8434 File Offset: 0x00DE6634
		[NullableContext(2)]
		public void PlayAkEvent(IPostAkEventType config)
		{
			if (config == null)
			{
				return;
			}
			string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(((IPostAkEventGlobal)config).AkEvent);
			if (text == null)
			{
				return;
			}
			if (config.Type == EPostAkEvent.Global)
			{
				Singleton<AudioSystem>.Instance.PostEvent(text);
				return;
			}
			if (config.Type == EPostAkEvent.Target)
			{
				int entityId = ((IPostAkEventTargeted)config).EntityId;
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
				if (entityByPbDataId == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.LZK;
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
					ELogAuthor author2 = ELogAuthor.LZK;
					string message2 = "未能获取到该实体对应的有效Actor";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entityId);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				Singleton<AudioSystem>.Instance.PostEvent(text, aactor, null);
			}
		}

		// Token: 0x06036DA0 RID: 224672 RVA: 0x00DE8536 File Offset: 0x00DE6736
		public void PlayTalkItemStartEvent(ITalkItem talkItem)
		{
			this.PlayAkEvent(talkItem.TalkAkEvent);
		}

		// Token: 0x06036DA1 RID: 224673 RVA: 0x00DE8544 File Offset: 0x00DE6744
		public void PlayTalkItemEndEvent(ITalkItem talkItem)
		{
			this.PlayAkEvent(talkItem.TalkEndAkEvent);
		}

		// Token: 0x06036DA2 RID: 224674 RVA: 0x00DE8554 File Offset: 0x00DE6754
		public void PauseAudio()
		{
			if (this.IsPaused)
			{
				return;
			}
			if (this.IsLoading)
			{
				TimerHandle audioLoadTimeoutTimer = this.AudioLoadTimeoutTimer;
				if (audioLoadTimeoutTimer == null)
				{
					return;
				}
				audioLoadTimeoutTimer.Pause();
				return;
			}
			else
			{
				if (this.PlotPlayEventResult == 0)
				{
					return;
				}
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Pause, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(1000)
				}));
				this.IsPaused = true;
				return;
			}
		}

		// Token: 0x06036DA3 RID: 224675 RVA: 0x00DE85C4 File Offset: 0x00DE67C4
		public void ResumeAudio()
		{
			if (!this.IsPaused)
			{
				return;
			}
			if (this.IsLoading)
			{
				TimerHandle audioLoadTimeoutTimer = this.AudioLoadTimeoutTimer;
				if (audioLoadTimeoutTimer == null)
				{
					return;
				}
				audioLoadTimeoutTimer.Resume();
				return;
			}
			else
			{
				if (this.PlotPlayEventResult == 0)
				{
					return;
				}
				if (this.CurLang != Singleton<LanguageSystem>.Instance.PackageAudio)
				{
					this.CurLang = Singleton<LanguageSystem>.Instance.PackageAudio;
					this.StopAudio();
					this.Replay();
					return;
				}
				Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Resume, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(1000)
				}));
				this.IsPaused = false;
				return;
			}
		}

		// Token: 0x06036DA4 RID: 224676 RVA: 0x00DE8668 File Offset: 0x00DE6868
		public void StopAudio()
		{
			this.RemoveAudioLoadTimeoutTimer();
			this.UniqueId++;
			Singleton<AudioSystem>.Instance.ExecuteAction(this.PlotPlayEventResult, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?(0)
			}));
			this.PlotPlayEventResult = 0;
			this.EventName = "";
			this.IsPlaying = false;
			this.IsLoading = false;
			this.IsPaused = false;
		}

		// Token: 0x06036DA5 RID: 224677 RVA: 0x00DE86DC File Offset: 0x00DE68DC
		public void Replay()
		{
			EPlotTextAudioComponentPlayType playType = this.PlayType;
			if (playType != EPlotTextAudioComponentPlayType.Talk)
			{
				if (playType != EPlotTextAudioComponentPlayType.Tone)
				{
					return;
				}
				if (this.PlayToneContext == null)
				{
					return;
				}
				this.PlayTone(this.PlayToneContext);
				return;
			}
			else
			{
				if (this.PlayTalkContext == null)
				{
					return;
				}
				this.PlayTalkAudio(this.PlayTalkContext);
				return;
			}
		}

		// Token: 0x06036DA6 RID: 224678 RVA: 0x00DE8728 File Offset: 0x00DE6928
		protected unsafe void OnAudioPlayCallback(int id, string eventName, EAkCallbackType callbackType, [Nullable(2)] UAkCallbackInfo callbackInfo)
		{
			if (id != this.UniqueId)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "[PlotViewHud] 废弃的音频回调";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("eventName", eventName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("type", callbackType);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			if (callbackType == EAkCallbackType.EndOfEvent)
			{
				this.OnAudioEnd();
				return;
			}
			if (callbackType == EAkCallbackType.Duration)
			{
				this.AudioDuration = ((UAkDurationCallbackInfo)callbackInfo).Duration;
				this.OnAudioStart();
			}
		}

		// Token: 0x06036DA7 RID: 224679 RVA: 0x00DE87DC File Offset: 0x00DE69DC
		protected void AddAudioLoadTimeoutTimer()
		{
			if (this.AudioLoadTimeoutTimer != null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LZK, "[PlotAudioComponent] 音频加载超时定时器已存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.IsLoading)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LZK, "[PlotAudioComponent] 正在加载音频，无法添加音频加载超时定时器", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.IsPlaying)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LZK, "[PlotAudioComponent] 正在播放音频，无法添加音频加载超时定时器", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.AudioLoadTimeoutTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.OnAudioLoadTimeout), 3000f, null, null, true, 1f);
		}

		// Token: 0x06036DA8 RID: 224680 RVA: 0x00DE8881 File Offset: 0x00DE6A81
		protected void RemoveAudioLoadTimeoutTimer()
		{
			if (this.AudioLoadTimeoutTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AudioLoadTimeoutTimer);
				this.AudioLoadTimeoutTimer = null;
			}
		}

		// Token: 0x06036DA9 RID: 224681 RVA: 0x00DE88A3 File Offset: 0x00DE6AA3
		protected void OnAudioStart()
		{
			this.IsLoading = false;
			this.IsPlaying = true;
			this.RemoveAudioLoadTimeoutTimer();
			Action onAudioStartDelegate = this.OnAudioStartDelegate;
			if (onAudioStartDelegate == null)
			{
				return;
			}
			onAudioStartDelegate();
		}

		// Token: 0x06036DAA RID: 224682 RVA: 0x00DE88C9 File Offset: 0x00DE6AC9
		protected void OnAudioEnd()
		{
			this.IsPlaying = false;
			this.PlotPlayEventResult = 0;
			this.UniqueId++;
			Action onAudioEndDelegate = this.OnAudioEndDelegate;
			if (onAudioEndDelegate == null)
			{
				return;
			}
			onAudioEndDelegate();
		}

		// Token: 0x06036DAB RID: 224683 RVA: 0x00DE88F8 File Offset: 0x00DE6AF8
		protected void OnAudioLoadTimeout(float _)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.LZK, "[PlotAudioComponent] 音频加载超时", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.StopAudio();
			Action onAudioLoadTimeoutDelegate = this.OnAudioLoadTimeoutDelegate;
			if (onAudioLoadTimeoutDelegate == null)
			{
				return;
			}
			onAudioLoadTimeoutDelegate();
		}

		// Token: 0x06036DAC RID: 224684 RVA: 0x00DE8937 File Offset: 0x00DE6B37
		public float GetAudioDuration()
		{
			return this.AudioDuration;
		}

		// Token: 0x06036DAD RID: 224685 RVA: 0x00DE893F File Offset: 0x00DE6B3F
		public bool GetIsPlaying()
		{
			return this.IsPlaying;
		}

		// Token: 0x06036DAE RID: 224686 RVA: 0x00DE8947 File Offset: 0x00DE6B47
		public bool GetIsLoading()
		{
			return this.IsLoading;
		}

		// Token: 0x06036DAF RID: 224687 RVA: 0x00DE894F File Offset: 0x00DE6B4F
		public bool GetIsPaused()
		{
			return this.IsPaused;
		}

		// Token: 0x06036DB0 RID: 224688 RVA: 0x00DE8957 File Offset: 0x00DE6B57
		public EPlotTextAudioComponentPlayType GetPlayType()
		{
			return this.PlayType;
		}

		// Token: 0x06036DB1 RID: 224689 RVA: 0x00DE895F File Offset: 0x00DE6B5F
		public string GetEventName()
		{
			return this.EventName;
		}

		// Token: 0x0401F93F RID: 129343
		private int UniqueId;

		// Token: 0x0401F940 RID: 129344
		private string EventName = "";

		// Token: 0x0401F941 RID: 129345
		private float AudioDuration;

		// Token: 0x0401F942 RID: 129346
		private EPlotTextAudioComponentPlayType PlayType;

		// Token: 0x0401F943 RID: 129347
		[Nullable(2)]
		private PlotTextAudioComponentPlayTalkContext PlayTalkContext;

		// Token: 0x0401F944 RID: 129348
		[Nullable(2)]
		private PlotTextAudioComponentPlayToneContext PlayToneContext;

		// Token: 0x0401F945 RID: 129349
		private int PlotPlayEventResult;

		// Token: 0x0401F946 RID: 129350
		private bool IsPlaying;

		// Token: 0x0401F947 RID: 129351
		private bool IsLoading;

		// Token: 0x0401F948 RID: 129352
		private bool IsPaused;

		// Token: 0x0401F949 RID: 129353
		[Nullable(2)]
		private TimerHandle AudioLoadTimeoutTimer;

		// Token: 0x0401F94A RID: 129354
		private string CurLang = Singleton<LanguageSystem>.Instance.PackageAudio;

		// Token: 0x0401F94B RID: 129355
		[Nullable(2)]
		private Action OnAudioStartDelegate;

		// Token: 0x0401F94C RID: 129356
		[Nullable(2)]
		private Action OnAudioEndDelegate;

		// Token: 0x0401F94D RID: 129357
		[Nullable(2)]
		private Action OnAudioLoadTimeoutDelegate;
	}
}
