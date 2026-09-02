using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053B4 RID: 21428
	[NullableContext(1)]
	[Nullable(0)]
	public class MusicSubtitleView : UiTickViewBase
	{
		// Token: 0x06036A53 RID: 223827 RVA: 0x00DD7808 File Offset: 0x00DD5A08
		public MusicSubtitleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06036A54 RID: 223828 RVA: 0x00DD7828 File Offset: 0x00DD5A28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036A55 RID: 223829 RVA: 0x00DD7894 File Offset: 0x00DD5A94
		protected unsafe override void OnStart()
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
			IPostAkEventMusicSubtitle postAkEventMusicSubtitle = this.OpenParam as IPostAkEventMusicSubtitle;
			string musicSubtitleGroupTag = postAkEventMusicSubtitle.MusicSubtitleGroupTag;
			this.AkEvent = Singleton<AudioSystem>.Instance.parseAudioEventPath(postAkEventMusicSubtitle.AkEvent);
			if (string.IsNullOrEmpty(musicSubtitleGroupTag) || string.IsNullOrEmpty(this.AkEvent))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[MusicSubtitle] 音乐字幕配置错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", musicSubtitleGroupTag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("akEvent", this.AkEvent);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.CloseMe(null);
				return;
			}
			IReadOnlyList<MusicSubTitle> musicSubtitle = ConfigBase<MusicSubtitleConfig>.Instance.GetMusicSubtitle(musicSubtitleGroupTag);
			if (musicSubtitle == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Plot;
				ELogAuthor author2 = ELogAuthor.FZX;
				string message2 = "[MusicSubtitle] 找不到音乐字幕配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", musicSubtitleGroupTag);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.CloseMe(null);
				return;
			}
			foreach (MusicSubTitle musicSubTitle in musicSubtitle)
			{
				SubtitleConfigProxy subtitleConfigProxy = new SubtitleConfigProxy();
				subtitleConfigProxy.StartTime = musicSubTitle.AppearTime * 1000f;
				subtitleConfigProxy.EndTime = musicSubTitle.EndTime * 1000f;
				subtitleConfigProxy.OriginSubtitleId = Singleton<PublicUtil>.Instance.GetConfigIdByTable(ETableText.OriginSubtitle, new int?(musicSubTitle.Id));
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(subtitleConfigProxy.OriginSubtitleId);
				subtitleConfigProxy.HideTranslationSubtitle = configTextByKey.Contains("{KeepOrigin}");
				if (subtitleConfigProxy.HideTranslationSubtitle)
				{
					subtitleConfigProxy.OriginSubtitleId = Singleton<PublicUtil>.Instance.GetConfigIdByTable(ETableText.TranslationSubtitle, new int?(musicSubTitle.Id));
				}
				else
				{
					subtitleConfigProxy.TranslationSubtitleId = Singleton<PublicUtil>.Instance.GetConfigIdByTable(ETableText.TranslationSubtitle, new int?(musicSubTitle.Id));
				}
				this.SubtitleConfigList.Add(subtitleConfigProxy);
			}
			this.SubtitleConfigList.Sort((SubtitleConfigProxy a, SubtitleConfigProxy b) => a.StartTime.CompareTo(b.StartTime));
		}

		// Token: 0x06036A56 RID: 223830 RVA: 0x00DD7AD4 File Offset: 0x00DD5CD4
		protected unsafe override void OnAfterShow()
		{
			this.OnVideoViewShow();
			Singleton<EventSystem>.Instance.Add(EEventName.VideoViewShow, new Action(this.OnVideoViewShow));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.VideoViewHide, new Action<bool>(this.OnVideoViewHide));
			Singleton<EventSystem>.Instance.Add(EEventName.PlotSequenceStarted, new Action(this.ResetAudioStartTime));
			Singleton<EventSystem>.Instance.Add(EEventName.PlotSequenceEnd, new Action(this.SeekAudio));
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.OnApplicationHasReactivated));
			Singleton<Application>.Instance.AddApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillDeactivateDelegate, new Action(this.OnApplicationWillDeactivate));
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[MusicSubtitle] TestTestTest", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.AudioHandle != 0)
			{
				this.IsPlaying = true;
				return;
			}
			AActor target = null;
			this.AudioHandle = Singleton<AudioSystem>.Instance.PostEvent(this.AkEvent, target, new PostEventArgs?(new PostEventArgs
			{
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType != EAkCallbackType.EndOfEvent)
					{
						if (callbackType == EAkCallbackType.Duration)
						{
							this.IsPlaying = true;
							this.ResetAudioStartTime();
							global::Log instance3 = Singleton<global::Log>.Instance;
							ELogModule module3 = ELogModule.Plot;
							ELogAuthor author3 = ELogAuthor.FZX;
							string message3 = "[MusicSubtitle] 音乐字幕播放开始";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("akEvent", this.AkEvent);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StartTime", this.AudioStartTime);
							instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						}
						return;
					}
					if (this.AudioHandle == 0)
					{
						return;
					}
					this.AudioHandle = 0;
					global::Log instance4 = Singleton<global::Log>.Instance;
					ELogModule module4 = ELogModule.Plot;
					ELogAuthor author4 = ELogAuthor.FZX;
					string message4 = "[MusicSubtitle] 音乐字幕播放结束";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("akEvent", this.AkEvent);
					instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					base.CloseMe(null);
				},
				CallbackMask = new ECallbackMask?((ECallbackMask)9)
			}));
			if (this.AudioHandle != 0)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.MSY;
				string message = "[MusicSubtitle][Game.Action] PostEvent";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Event", this.AkEvent);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Plot;
			ELogAuthor author2 = ELogAuthor.FZX;
			string message2 = "[MusicSubtitle] 音乐字幕播放失败";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("akEvent", this.AkEvent);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.CloseMe(null);
		}

		// Token: 0x06036A57 RID: 223831 RVA: 0x00DD7C64 File Offset: 0x00DD5E64
		protected override void OnAfterHide()
		{
			if (this.InVideo)
			{
				this.GetOriginalItem().SetUIParent(Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Float), false);
				this.InVideo = false;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.VideoViewShow, new Action(this.OnVideoViewShow));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.VideoViewHide, new Action<bool>(this.OnVideoViewHide));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotSequenceStarted, new Action(this.ResetAudioStartTime));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotSequenceEnd, new Action(this.SeekAudio));
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationHasReactivatedDelegate, new Action(this.OnApplicationHasReactivated));
			Singleton<Application>.Instance.RemoveApplicationHandler(EApplicationLifetimeDelegate.ApplicationWillDeactivateDelegate, new Action(this.OnApplicationWillDeactivate));
			this.IsPlaying = false;
		}

		// Token: 0x06036A58 RID: 223832 RVA: 0x00DD7D40 File Offset: 0x00DD5F40
		protected override void OnBeforeDestroy()
		{
			this.AudioHandle = 0;
		}

		// Token: 0x06036A59 RID: 223833 RVA: 0x00DD7D4C File Offset: 0x00DD5F4C
		private void OnVideoViewShow()
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.VideoView);
			if (!this.InVideo && viewByName != null)
			{
				UUIItem rootItem = viewByName.GetRootItem();
				this.GetOriginalItem().SetUIParent(rootItem, false);
				this.InVideo = true;
			}
		}

		// Token: 0x06036A5A RID: 223834 RVA: 0x00DD7D90 File Offset: 0x00DD5F90
		private void OnVideoViewHide(bool isPlayToEnd)
		{
			if (this.InVideo)
			{
				this.GetOriginalItem().SetUIParent(Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Float), false);
				this.InVideo = false;
			}
			if (!isPlayToEnd)
			{
				if (this.AudioHandle != 0)
				{
					Singleton<AudioSystem>.Instance.ExecuteAction(this.AudioHandle, EAudioActionType.Stop, null);
					this.AudioHandle = 0;
				}
				base.CloseMe(null);
			}
		}

		// Token: 0x06036A5B RID: 223835 RVA: 0x00DD7DFA File Offset: 0x00DD5FFA
		private void OnApplicationHasReactivated()
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[MusicSubtitle] 应用重新激活", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (!this.InVideo)
				{
					this.SeekAudio();
				}
			}, null, null);
		}

		// Token: 0x06036A5C RID: 223836 RVA: 0x00DD7E18 File Offset: 0x00DD6018
		private void OnApplicationWillDeactivate()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.FZX, "[MusicSubtitle] 应用将暂停", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (!this.InVideo)
			{
				this.ResetAudioStartTime();
			}
		}

		// Token: 0x06036A5D RID: 223837 RVA: 0x00DD7E50 File Offset: 0x00DD6050
		protected override void OnTick(float deltaTime)
		{
			if (!this.IsPlaying)
			{
				return;
			}
			this.CurrentTime += deltaTime;
			this.TimeSinceLastCorrection += deltaTime;
			if (this.TimeSinceLastCorrection > 1000f || deltaTime > 100f)
			{
				this.TimeSinceLastCorrection = 0f;
				this.SyncAudioTimeToSubtitle();
			}
			UUIText text = base.GetText(0);
			UUIText text2 = base.GetText(1);
			SubtitleConfigProxy subtitleInRange = this.GetSubtitleInRange(this.CurrentTime);
			if (this.CurrentSubtitleProxy != subtitleInRange && subtitleInRange != null)
			{
				this.CurrentSubtitleProxy = subtitleInRange;
				text.SetUIActive(true);
				text.ShowTextNew(subtitleInRange.OriginSubtitleId);
				if (!subtitleInRange.HideTranslationSubtitle)
				{
					text2.SetUIActive(true);
					text2.ShowTextNew(subtitleInRange.TranslationSubtitleId);
				}
				else
				{
					text2.SetUIActive(false);
				}
			}
			if (subtitleInRange == null && this.CurrentSubtitleProxy != null)
			{
				text.SetUIActive(false);
				text2.SetUIActive(false);
				this.CurrentSubtitleProxy = null;
			}
		}

		// Token: 0x06036A5E RID: 223838 RVA: 0x00DD7F30 File Offset: 0x00DD6130
		[NullableContext(2)]
		private SubtitleConfigProxy GetSubtitleInRange(float time)
		{
			foreach (SubtitleConfigProxy subtitleConfigProxy in this.SubtitleConfigList)
			{
				if (time >= subtitleConfigProxy.StartTime && time < subtitleConfigProxy.EndTime)
				{
					return subtitleConfigProxy;
				}
			}
			return null;
		}

		// Token: 0x06036A5F RID: 223839 RVA: 0x00DD7F98 File Offset: 0x00DD6198
		private void SyncAudioTimeToSubtitle()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			int? sourcePlayPosition = Singleton<AudioSystem>.Instance.GetSourcePlayPosition(this.AudioHandle, false);
			if (sourcePlayPosition != null)
			{
				this.CurrentTime = (float)sourcePlayPosition.Value;
			}
		}

		// Token: 0x06036A60 RID: 223840 RVA: 0x00DD7FD8 File Offset: 0x00DD61D8
		public unsafe void SeekAudio()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			float num = ModelBase<SequenceModel>.Instance.GetCurrentPlayPosition() * 1000f - this.AudioStartTime;
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num, (double)this.CurrentTime, new double?((double)40)))
			{
				return;
			}
			this.CurrentTime = num;
			Singleton<AudioSystem>.Instance.SeekOnEvent(this.AkEvent, (int)this.CurrentTime, null);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[MusicSubtitleSync] 同步音频时间";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CurrentTime", this.CurrentTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AudioStartTime", this.AudioStartTime);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06036A61 RID: 223841 RVA: 0x00DD80B4 File Offset: 0x00DD62B4
		public void ResetAudioStartTime()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			this.SyncAudioTimeToSubtitle();
			this.AudioStartTime = ModelBase<SequenceModel>.Instance.GetCurrentPlayPosition() * 1000f - this.CurrentTime;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.FZX;
			string message = "[MusicSubtitleSync] 重置音频开始时间";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AudioStartTime", this.AudioStartTime);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0401F79E RID: 128926
		private const string HIDE_TRANSLATION_LABEL = "{KeepOrigin}";

		// Token: 0x0401F79F RID: 128927
		private const int AUDIO_SYNC_TIME = 1000;

		// Token: 0x0401F7A0 RID: 128928
		private const int LAG_TIME = 100;

		// Token: 0x0401F7A1 RID: 128929
		private readonly List<SubtitleConfigProxy> SubtitleConfigList = new List<SubtitleConfigProxy>();

		// Token: 0x0401F7A2 RID: 128930
		private int AudioHandle;

		// Token: 0x0401F7A3 RID: 128931
		private float CurrentTime;

		// Token: 0x0401F7A4 RID: 128932
		[Nullable(2)]
		private SubtitleConfigProxy CurrentSubtitleProxy;

		// Token: 0x0401F7A5 RID: 128933
		private float TimeSinceLastCorrection;

		// Token: 0x0401F7A6 RID: 128934
		private bool IsPlaying;

		// Token: 0x0401F7A7 RID: 128935
		[Nullable(2)]
		private string AkEvent;

		// Token: 0x0401F7A8 RID: 128936
		private float AudioStartTime = -1f;

		// Token: 0x0401F7A9 RID: 128937
		private bool InVideo;

		// Token: 0x0200B31C RID: 45852
		[NullableContext(0)]
		private enum EChildComp
		{
			// Token: 0x040377D3 RID: 227283
			OriginSubtitleTxt,
			// Token: 0x040377D4 RID: 227284
			TranslationSubtitleTxt
		}
	}
}
