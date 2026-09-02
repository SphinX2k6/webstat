using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053CD RID: 21453
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTransitionView : UiViewBase
	{
		// Token: 0x06036B79 RID: 224121 RVA: 0x00DDE6FF File Offset: 0x00DDC8FF
		[NullableContext(1)]
		public PlotTransitionView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06036B7A RID: 224122 RVA: 0x00DDE734 File Offset: 0x00DDC934
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnSkipClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06036B7B RID: 224123 RVA: 0x00DDE860 File Offset: 0x00DDCA60
		protected override void OnStart()
		{
			string text = this.OpenParam as string;
			this.TextPlayTweenComp = (base.GetText(0).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			this.TexturePlayTweenComp = (base.GetTexture(1).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			this.TextAnimDataComp = (base.GetText(0).GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
			this.TextPlayTweenEndCb = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.OnMultiLineTextPlayTweenEnd));
			this.TextPlayTweenEndCbWrapper = this.TextPlayTweenComp.GetPlayTween().RegisterOnComplete(this.TextPlayTweenEndCb);
			base.GetTexture(2).SetUIActive(false);
			if (ModelBase<GameModeModel>.Instance.UseShowCenterText)
			{
				base.GetItem(5).SetUIActive(true);
				this.SetNextPageButtonActive(false);
			}
			else if (ModelBase<TeleportModel>.Instance.IsTeleport || ModelBase<GameModeModel>.Instance.PlayTravelMp4)
			{
				base.GetItem(5).SetUIActive(true);
				this.SetNextPageButtonActive(false);
				base.GetText(0).SetUIActive(false);
			}
			else
			{
				base.GetItem(5).SetUIActive(false);
			}
			if (!string.IsNullOrEmpty(text))
			{
				string newText = ConfigMultiTextLang.GetLocalTextNew(text, null) ?? text;
				UUIText text2 = base.GetText(0);
				text2.SetText(newText, true);
				text2.SetAnchorVAlign(UIAnchorVerticalAlign.Middle);
				text2.SetPivot(Vector2D.Create(0.5, 0.5).ToUeVector2D(false));
				text2.SetParagraphHorizontalAlignment(UITextParagraphHorizontalAlign.Center);
				text2.SetAnchorOffsetX(0f);
				text2.SetAnchorOffsetY(0f);
				float centerTextFontSizeMiddle = ModelBase<PlotModel>.Instance.PlotGlobalConfig.CenterTextFontSizeMiddle;
				if (centerTextFontSizeMiddle > 0f)
				{
					text2.SetFontSize(centerTextFontSizeMiddle);
				}
				this.TextAnimDataComp.SetSelectorOffset(0f);
				text2.SetUIActive(true);
				this.SetNextPageButtonActive(false);
			}
		}

		// Token: 0x06036B7C RID: 224124 RVA: 0x00DDEA44 File Offset: 0x00DDCC44
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			PlotTransitionView.<OnPlayingStartSequenceAsync>d__31 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<PlotTransitionView.<OnPlayingStartSequenceAsync>d__31>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036B7D RID: 224125 RVA: 0x00DDEA88 File Offset: 0x00DDCC88
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			PlotTransitionView.<OnPlayingCloseSequenceAsync>d__32 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<PlotTransitionView.<OnPlayingCloseSequenceAsync>d__32>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036B7E RID: 224126 RVA: 0x00DDEACB File Offset: 0x00DDCCCB
		public void ExecuteCallBack()
		{
			if (this.Callback != null)
			{
				Action callback = this.Callback;
				this.Callback = null;
				callback();
			}
		}

		// Token: 0x06036B7F RID: 224127 RVA: 0x00DDEAE8 File Offset: 0x00DDCCE8
		private void OnTextPlayTweenEnd()
		{
			if (this.AnimMode == PlotTransitionView.ETextAnimMode.MultiLineFade || this.AnimMode == PlotTransitionView.ETextAnimMode.MultiLineTypeWriter)
			{
				return;
			}
			float? textTime = this.TextTime;
			float num = 0f;
			float textTimer = (!(textTime.GetValueOrDefault() == num & textTime != null) && this.TextTime != null) ? this.TextTime.Value : ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeCenterText;
			this.SetTextTimer(textTimer);
		}

		// Token: 0x06036B80 RID: 224128 RVA: 0x00DDEB5C File Offset: 0x00DDCD5C
		private void OnMultiLineTextPlayTweenEnd()
		{
			if (this.AnimMode != PlotTransitionView.ETextAnimMode.MultiLineFade && this.AnimMode != PlotTransitionView.ETextAnimMode.MultiLineTypeWriter)
			{
				return;
			}
			float endWaitTimeCenterText = ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeCenterText;
			this.SetTextTimer(endWaitTimeCenterText);
		}

		// Token: 0x06036B81 RID: 224129 RVA: 0x00DDEB94 File Offset: 0x00DDCD94
		private void SetTextTimer(float delayTime)
		{
			if (this.TextShowDelayId != null)
			{
				TimerSystem.Instance.Remove(this.TextShowDelayId);
			}
			this.TextShowDelayId = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.TextShowDelayId = null;
				this.ClearAudio();
				base.GetText(0).SetUIActive(false);
				base.GetTexture(2).SetUIActive(false);
				this.ExecuteCallBack();
			}, (float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)delayTime), null, null, true, 1f);
		}

		// Token: 0x06036B82 RID: 224130 RVA: 0x00DDEBEB File Offset: 0x00DDCDEB
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPlotTransitionRemoveCallback, new Action(this.RemoveCallback));
			Singleton<EventSystem>.Instance.Add(EEventName.UpdatePlotCenterText, new Action(this.OnUpdatePlotCenterText));
		}

		// Token: 0x06036B83 RID: 224131 RVA: 0x00DDEC25 File Offset: 0x00DDCE25
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPlotTransitionRemoveCallback, new Action(this.RemoveCallback));
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdatePlotCenterText, new Action(this.OnUpdatePlotCenterText));
		}

		// Token: 0x06036B84 RID: 224132 RVA: 0x00DDEC5F File Offset: 0x00DDCE5F
		protected override void OnBeforeHide()
		{
			this.SetNextPageButtonActive(false);
		}

		// Token: 0x06036B85 RID: 224133 RVA: 0x00DDEC68 File Offset: 0x00DDCE68
		private void RemoveCallback()
		{
			this.Callback = null;
		}

		// Token: 0x06036B86 RID: 224134 RVA: 0x00DDEC74 File Offset: 0x00DDCE74
		private void OnUpdatePlotCenterText()
		{
			PlotCenterText centerText = ModelBase<PlotModel>.Instance.CenterText;
			this.CenterText = centerText;
			if (!string.IsNullOrEmpty(centerText.Text))
			{
				string text = ModelBase<PlotModel>.Instance.PlotTextReplacer.Replace(centerText.Text, false);
				UUIText text2 = base.GetText(0);
				text2.SetText(text, true);
				text2.SetUIActive(true);
				this.SetTextOverflowType();
				this.SetTextAlign();
				this.SetTextFontSize();
				this.SetTextAnimMode(text.Length);
			}
			else
			{
				UUIText text3 = base.GetText(0);
				if (text3 != null)
				{
					text3.SetUIActive(false);
				}
			}
			string text4 = "";
			float num = 0f;
			bool? isManualNext = new bool?(false);
			if (centerText.Config != null)
			{
				if (centerText.Config.Value.IsT1)
				{
					text4 = centerText.Config.Value.AsT1.BgImageId;
					num = centerText.Config.Value.AsT1.TotalTime.GetValueOrDefault();
					isManualNext = centerText.Config.Value.AsT1.IsManualNext;
				}
				else if (centerText.Config.Value.IsT2)
				{
					text4 = centerText.Config.Value.AsT2.BgImageId;
					num = centerText.Config.Value.AsT2.TotalTime.GetValueOrDefault();
					isManualNext = centerText.Config.Value.AsT2.IsManualNext;
				}
			}
			if (!string.IsNullOrEmpty(text4))
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text4);
				Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(resourcePath, delegate([Nullable(2)] UTexture loadObject, string _)
				{
					if (loadObject == null || !loadObject.IsValid())
					{
						return;
					}
					base.GetTexture(2).SetTexture(loadObject);
					base.GetTexture(2).SetUIActive(true);
				}, 100, "js_undefined");
			}
			if (ModelBase<GameModeModel>.Instance.UseShowCenterText)
			{
				this.TextTime = new float?(999f);
				this.PlayAudio();
				base.GetTexture(2).SetUIActive(true);
				this.Callback = centerText.Callback;
				if (centerText.Config != null && num > 0f)
				{
					this.TextTime = new float?(num);
					this.OnTextPlayTweenEnd();
				}
				else
				{
					this.ExecuteCallBack();
				}
				ModelBase<PlotModel>.Instance.CenterText.Clear();
				return;
			}
			this.SetNextPageButtonActive(isManualNext.GetValueOrDefault());
			this.ExecuteCallBack();
			this.Callback = centerText.Callback;
			if (centerText.AutoClose)
			{
				if (this.TextTime == null)
				{
					this.TextTime = new float?(num);
				}
				this.OnTextPlayTweenEnd();
			}
			if (!string.IsNullOrEmpty(this.CenterText.AudioId))
			{
				this.PlayAudio();
			}
			else
			{
				this.PlayTone();
			}
			this.PlayAkEvent(this.CenterText.TalkAkEvent);
			this.TalkEndAkEvent = this.CenterText.TalkEndAkEvent;
			ModelBase<PlotModel>.Instance.CenterText.Clear();
		}

		// Token: 0x06036B87 RID: 224135 RVA: 0x00DDEF48 File Offset: 0x00DDD148
		private unsafe void PlayTone()
		{
			PlotCenterText centerText = this.CenterText;
			if (((centerText != null) ? centerText.UniversalTone : null) != null)
			{
				int valueOrDefault = this.CenterText.UniversalTone.TimberId.GetValueOrDefault();
				int universalToneId = this.CenterText.UniversalTone.UniversalToneId;
				if (valueOrDefault > 0 && universalToneId > 0)
				{
					Interjection? config = ConfigInterjectionByTimberIdAndUniversalToneId.GetConfig(valueOrDefault, universalToneId, true);
					if (config != null)
					{
						this.PlayTalkInterjection(config.Value);
						return;
					}
				}
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "通用语气配置无法获取，策划检查配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("timberId", valueOrDefault);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("universalToneId", universalToneId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x06036B88 RID: 224136 RVA: 0x00DDF01C File Offset: 0x00DDD21C
		private void PlayTalkInterjection(Interjection config)
		{
			Singleton<AudioController>.Instance.PostEventByUi(config.AkEvent, this.PlotPlayEventResult, new int?(8), null);
		}

		// Token: 0x06036B89 RID: 224137 RVA: 0x00DDF03C File Offset: 0x00DDD23C
		private void PlayAkEvent(IPostAkEventType config)
		{
			if (config == null)
			{
				return;
			}
			string text = "";
			switch (config.Type)
			{
			case EPostAkEvent.Global:
				text = ((IPostAkEventGlobal)config).AkEvent;
				break;
			case EPostAkEvent.Target:
				text = ((IPostAkEventTargeted)config).AkEvent;
				break;
			case EPostAkEvent.Map:
				text = ((IPostAkEventMap)config).AkEvent;
				break;
			case EPostAkEvent.MusicSubtitle:
				text = ((IPostAkEventMusicSubtitle)config).AkEvent;
				break;
			}
			text = Singleton<AudioSystem>.Instance.parseAudioEventPath(text);
			if (config.Type == EPostAkEvent.Global)
			{
				Singleton<AudioSystem>.Instance.PostEvent(text);
				return;
			}
			if (config.Type == EPostAkEvent.Target)
			{
				int entityId = (config as IPostAkEventTargeted).EntityId;
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(entityId);
				if (entityByPbDataId == null)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.FZX;
					string message = "实体不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", entityId);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
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
		}

		// Token: 0x06036B8A RID: 224138 RVA: 0x00DDF18C File Offset: 0x00DDD38C
		protected override void OnBeforeDestroy()
		{
			this.SetNextPageButtonActive(false);
			this.TextPlayTweenComp.GetPlayTween().UnregisterOnComplete(this.TextPlayTweenEndCbWrapper);
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnMultiLineTextPlayTweenEnd));
			this.TextPlayTweenEndCb = null;
			if (this.TextShowDelayId != null)
			{
				TimerSystem.Instance.Remove(this.TextShowDelayId);
				this.TextShowDelayId = null;
			}
			if (this.TextAnimDelayId != null)
			{
				TimerSystem.Instance.Remove(this.TextAnimDelayId);
				this.TextAnimDelayId = null;
			}
			if (this.WaitingSkipTimerId != null)
			{
				TimerSystem.Instance.Remove(this.WaitingSkipTimerId);
				this.WaitingSkipTimerId = null;
			}
			this.ExecuteCallBack();
			this.CenterText = null;
			this.LineNumArray = null;
			this.TalkEndAkEvent = null;
		}

		// Token: 0x06036B8B RID: 224139 RVA: 0x00DDF24C File Offset: 0x00DDD44C
		private void SetTweenAndPlay(bool isReverse, float time)
		{
			ULGUIPlayTween_Float ulguiplayTween_Float = this.TextPlayTweenComp.GetPlayTween() as ULGUIPlayTween_Float;
			ulguiplayTween_Float.from = (isReverse ? 1f : 0f);
			ulguiplayTween_Float.to = (isReverse ? 0f : 1f);
			ulguiplayTween_Float.duration = time;
			this.TextPlayTweenComp.Play();
		}

		// Token: 0x06036B8C RID: 224140 RVA: 0x00DDF2A4 File Offset: 0x00DDD4A4
		private void SetTweenPauseOrResume(bool isPause)
		{
			ULGUIPlayTween_Float ulguiplayTween_Float = this.TextPlayTweenComp.GetPlayTween() as ULGUIPlayTween_Float;
			ULTweener ultweener = (ulguiplayTween_Float != null) ? ulguiplayTween_Float.GetTweener() : null;
			if (ultweener == null)
			{
				return;
			}
			if (isPause)
			{
				ultweener.Pause();
				this.PauseOrResumeAudio(true);
				return;
			}
			ultweener.Resume();
			this.PauseOrResumeAudio(false);
		}

		// Token: 0x06036B8D RID: 224141 RVA: 0x00DDF2F0 File Offset: 0x00DDD4F0
		private void Fade(bool isReverse, float fadeTime)
		{
			ULGUIPlayTween_Float ulguiplayTween_Float = this.TexturePlayTweenComp.GetPlayTween() as ULGUIPlayTween_Float;
			ulguiplayTween_Float.from = (isReverse ? base.GetTexture(1).GetAlpha() : 0f);
			ulguiplayTween_Float.to = (isReverse ? 0f : 1f);
			ulguiplayTween_Float.duration = fadeTime;
			this.TexturePlayTweenComp.Play();
		}

		// Token: 0x06036B8E RID: 224142 RVA: 0x00DDF350 File Offset: 0x00DDD550
		private void PlayAudio()
		{
			PlotAudio? plotAudio = string.IsNullOrEmpty(this.CenterText.AudioId) ? null : ConfigPlotAudioById.GetConfig(this.CenterText.AudioId, true);
			if (plotAudio == null)
			{
				return;
			}
			this.PlayAudioInner(plotAudio.Value);
		}

		// Token: 0x06036B8F RID: 224143 RVA: 0x00DDF3A4 File Offset: 0x00DDD5A4
		private void PlayAudioInner(PlotAudio config)
		{
			ExternalSourceSetting? config2 = ConfigExternalSourceSettingById.GetConfig(config.ExternalSourceSetting, true);
			string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config);
			Singleton<AudioController>.Instance.PostEventByExternalSourcesByUi(config2.Value.SubtitleEvent, externalSourcesMediaName, config2.Value.SubtitleSrc, this.PlotPlayEventResult, null, new int?(8), null);
		}

		// Token: 0x06036B90 RID: 224144 RVA: 0x00DDF404 File Offset: 0x00DDD604
		private void PauseOrResumeAudio(bool isPause)
		{
			if (this.PlotPlayEventResult == null)
			{
				return;
			}
			if (isPause)
			{
				using (List<int>.Enumerator enumerator = this.PlotPlayEventResult.PlayingIds.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int playId = enumerator.Current;
						Singleton<AudioController>.Instance.PauseAudioByPlayId(playId);
					}
					return;
				}
			}
			foreach (int playId2 in this.PlotPlayEventResult.PlayingIds)
			{
				Singleton<AudioController>.Instance.ResumeAudioByPlayId(playId2);
			}
		}

		// Token: 0x06036B91 RID: 224145 RVA: 0x00DDF4B8 File Offset: 0x00DDD6B8
		private void ClearAudio()
		{
			this.PlayAkEvent(this.TalkEndAkEvent);
			this.TalkEndAkEvent = null;
			Singleton<AudioController>.Instance.StopEvent(this.PlotPlayEventResult, true, null);
		}

		// Token: 0x06036B92 RID: 224146 RVA: 0x00DDF4F4 File Offset: 0x00DDD6F4
		private void SetTextAlign()
		{
			PlotCenterText centerText = this.CenterText;
			UUIText text = base.GetText(0);
			ETextAlign? etextAlign = null;
			ETextHorizontal? etextHorizontal = null;
			PlotCenterText plotCenterText = centerText;
			if (plotCenterText.Config != null && plotCenterText.Config.GetValueOrDefault().IsT1)
			{
				ITextStyle textStyle = centerText.Config.Value.AsT1.TextStyle;
				etextAlign = ((textStyle != null) ? textStyle.TextAlign : null);
				ITextStyle textStyle2 = centerText.Config.Value.AsT1.TextStyle;
				etextHorizontal = ((textStyle2 != null) ? textStyle2.TextHorizontal : null);
			}
			else
			{
				PlotCenterText plotCenterText2 = centerText;
				if (plotCenterText2.Config != null && plotCenterText2.Config.GetValueOrDefault().IsT2)
				{
					ITextStyle textStyle3 = centerText.Config.Value.AsT2.TextStyle;
					etextAlign = ((textStyle3 != null) ? textStyle3.TextAlign : null);
					ITextStyle textStyle4 = centerText.Config.Value.AsT2.TextStyle;
					etextHorizontal = ((textStyle4 != null) ? textStyle4.TextHorizontal : null);
				}
			}
			if (etextAlign.GetValueOrDefault() == ETextAlign.Bottom)
			{
				text.SetAnchorVAlign(UIAnchorVerticalAlign.Bottom);
				text.SetPivot(Vector2D.Create(0.5, -1.0).ToUeVector2D(false));
			}
			else
			{
				ETextAlign? etextAlign2 = etextAlign;
				ETextAlign etextAlign3 = ETextAlign.Top;
				if (etextAlign2.GetValueOrDefault() == etextAlign3 & etextAlign2 != null)
				{
					text.SetAnchorVAlign(UIAnchorVerticalAlign.Top);
					text.SetPivot(Vector2D.Create(0.5, 2.0).ToUeVector2D(false));
				}
				else
				{
					text.SetAnchorVAlign(UIAnchorVerticalAlign.Middle);
					text.SetPivot(Vector2D.Create(0.5, 0.5).ToUeVector2D(false));
				}
			}
			ETextHorizontal? etextHorizontal2 = etextHorizontal;
			ETextHorizontal etextHorizontal3 = ETextHorizontal.Left;
			if (etextHorizontal2.GetValueOrDefault() == etextHorizontal3 & etextHorizontal2 != null)
			{
				text.SetParagraphHorizontalAlignment(UITextParagraphHorizontalAlign.Left);
			}
			else if (etextHorizontal.GetValueOrDefault() == ETextHorizontal.Right)
			{
				text.SetParagraphHorizontalAlignment(UITextParagraphHorizontalAlign.Right);
			}
			else
			{
				text.SetParagraphHorizontalAlignment(UITextParagraphHorizontalAlign.Center);
			}
			text.SetAnchorOffsetX(0f);
			text.SetAnchorOffsetY(0f);
		}

		// Token: 0x06036B93 RID: 224147 RVA: 0x00DDF720 File Offset: 0x00DDD920
		private void SetTextFontSize()
		{
			PlotCenterText centerText = this.CenterText;
			EFontSize? efontSize = null;
			PlotCenterText plotCenterText = centerText;
			if (plotCenterText.Config != null && plotCenterText.Config.GetValueOrDefault().IsT1)
			{
				ITextStyle textStyle = centerText.Config.Value.AsT1.TextStyle;
				efontSize = ((textStyle != null) ? textStyle.FontSize : null);
			}
			else
			{
				PlotCenterText plotCenterText2 = centerText;
				if (plotCenterText2.Config != null && plotCenterText2.Config.GetValueOrDefault().IsT2)
				{
					ITextStyle textStyle2 = centerText.Config.Value.AsT2.TextStyle;
					efontSize = ((textStyle2 != null) ? textStyle2.FontSize : null);
				}
			}
			if (efontSize == null)
			{
				return;
			}
			UUIText text = base.GetText(0);
			float num = -1f;
			if (efontSize.GetValueOrDefault() == EFontSize.Big)
			{
				num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.CenterTextFontSizeBig;
			}
			else if (efontSize.GetValueOrDefault() == EFontSize.Middle)
			{
				num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.CenterTextFontSizeMiddle;
			}
			else
			{
				EFontSize? efontSize2 = efontSize;
				EFontSize efontSize3 = EFontSize.Small;
				if (efontSize2.GetValueOrDefault() == efontSize3 & efontSize2 != null)
				{
					num = ModelBase<PlotModel>.Instance.PlotGlobalConfig.CenterTextFontSizeSmall;
				}
			}
			if (num > 0f)
			{
				text.SetFontSize(num);
			}
		}

		// Token: 0x06036B94 RID: 224148 RVA: 0x00DDF86C File Offset: 0x00DDDA6C
		private void SetTextAnimMode(int textLength)
		{
			if (this.TextAnimDelayId != null)
			{
				TimerSystem.Instance.Remove(this.TextAnimDelayId);
			}
			PlotCenterText centerText = this.CenterText;
			ICenterTextShowType centerTextShowType = null;
			bool flag = false;
			PlotCenterText plotCenterText = centerText;
			if (plotCenterText.Config != null && plotCenterText.Config.GetValueOrDefault().IsT1)
			{
				ITextStyle textStyle = centerText.Config.Value.AsT1.TextStyle;
				centerTextShowType = ((textStyle != null) ? textStyle.ShowAnim : null);
				flag = centerText.Config.Value.AsT1.IsMulLine.GetValueOrDefault();
			}
			else
			{
				PlotCenterText plotCenterText2 = centerText;
				if (plotCenterText2.Config != null && plotCenterText2.Config.GetValueOrDefault().IsT2)
				{
					ITextStyle textStyle2 = centerText.Config.Value.AsT2.TextStyle;
					centerTextShowType = ((textStyle2 != null) ? textStyle2.ShowAnim : null);
					flag = centerText.Config.Value.AsT2.IsMulLine.GetValueOrDefault();
				}
			}
			if (centerTextShowType == null)
			{
				this.TextAnimDataComp.SetSelectorOffset(0f);
				return;
			}
			this.TextTime = null;
			this.TextAnimDataComp.SetSelectorOffset(1f);
			UUIEffectTextAnimation_RangeSelector uuieffectTextAnimation_RangeSelector = this.TextAnimDataComp.GetSelector() as UUIEffectTextAnimation_RangeSelector;
			uuieffectTextAnimation_RangeSelector.lineByLine = (flag && centerTextShowType.Type == ECenterTextShowAnim.FadeOut);
			uuieffectTextAnimation_RangeSelector.flipDirection = !uuieffectTextAnimation_RangeSelector.lineByLine;
			uuieffectTextAnimation_RangeSelector.SetRange((centerTextShowType.Type == ECenterTextShowAnim.FadeOut) ? 9999f : 0.01f);
			if (flag && centerTextShowType.Type == ECenterTextShowAnim.TypeWriter)
			{
				this.AnimMode = PlotTransitionView.ETextAnimMode.MultiLineTypeWriter;
				IICenterTextTypeWriter iicenterTextTypeWriter = centerTextShowType as IICenterTextTypeWriter;
				float num = (iicenterTextTypeWriter.TextCountPerSecond > 0) ? ((float)iicenterTextTypeWriter.TextCountPerSecond) : ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedSeq;
				float time = (float)textLength / num;
				this.SetTweenAndPlay(true, time);
				int lineNum = this.GetLineNum();
				this.Speed = num;
				if (lineNum > 1)
				{
					this.CurLine = 1;
					this.OneLineTime = (float)this.LineNumArray[this.CurLine - 1] / this.Speed;
					this.LineCount = lineNum;
					this.SetMultiLineTextAnimTimer();
					return;
				}
			}
			else if (flag && centerTextShowType.Type == ECenterTextShowAnim.FadeOut)
			{
				this.TextAnimDataComp.SetSelectorOffset(0f);
				this.AnimMode = PlotTransitionView.ETextAnimMode.MultiLineFade;
				IICenterTextFadeOut iicenterTextFadeOut = centerTextShowType as IICenterTextFadeOut;
				float fadeInTime = iicenterTextFadeOut.FadeInTime;
				int lineNum2 = this.GetLineNum();
				this.SetTweenAndPlay(false, fadeInTime * (float)lineNum2);
				if (lineNum2 > 1)
				{
					this.CurLine = 1;
					this.OneLineTime = fadeInTime;
					this.FadeOutTime = iicenterTextFadeOut.FadeOutTime;
					this.LineCount = lineNum2;
					this.SetMultiLineTextAnimTimer();
					return;
				}
			}
			else
			{
				if (centerTextShowType.Type == ECenterTextShowAnim.TypeWriter)
				{
					this.AnimMode = PlotTransitionView.ETextAnimMode.TypeWriter;
					IICenterTextTypeWriter iicenterTextTypeWriter2 = centerTextShowType as IICenterTextTypeWriter;
					float num2 = (iicenterTextTypeWriter2.TextCountPerSecond > 0) ? ((float)iicenterTextTypeWriter2.TextCountPerSecond) : ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedSeq;
					float num3 = (float)textLength / num2;
					this.SetTweenAndPlay(true, num3);
					float num4 = 0f;
					if (centerText != null)
					{
						PlotCenterText plotCenterText3 = centerText;
						if (((plotCenterText3.Config != null) ? new bool?(plotCenterText3.Config.GetValueOrDefault().IsT1) : null).GetValueOrDefault())
						{
							num4 = centerText.Config.Value.AsT1.TotalTime.GetValueOrDefault();
							goto IL_3C1;
						}
					}
					if (centerText != null)
					{
						PlotCenterText plotCenterText4 = centerText;
						if (((plotCenterText4.Config != null) ? new bool?(plotCenterText4.Config.GetValueOrDefault().IsT2) : null).GetValueOrDefault())
						{
							num4 = centerText.Config.Value.AsT2.TotalTime.GetValueOrDefault();
						}
					}
					IL_3C1:
					this.TextTime = new float?(num4 + num3);
					return;
				}
				if (centerTextShowType.Type == ECenterTextShowAnim.FadeOut)
				{
					this.AnimMode = PlotTransitionView.ETextAnimMode.Fade;
					IICenterTextFadeOut iicenterTextFadeOut2 = centerTextShowType as IICenterTextFadeOut;
					float fadeInTime2 = iicenterTextFadeOut2.FadeInTime;
					float fadeOutTime = iicenterTextFadeOut2.FadeOutTime;
					this.SetTweenAndPlay(true, fadeInTime2);
					float num5 = 0f;
					bool? flag2;
					if (centerText == null)
					{
						flag2 = null;
					}
					else
					{
						PlotCenterText plotCenterText5 = centerText;
						flag2 = ((plotCenterText5.Config != null) ? new bool?(plotCenterText5.Config.GetValueOrDefault().IsT1) : null);
					}
					bool? flag3 = flag2;
					if (flag3.GetValueOrDefault())
					{
						num5 = centerText.Config.Value.AsT1.TotalTime.GetValueOrDefault();
					}
					else
					{
						bool? flag4;
						if (centerText == null)
						{
							flag4 = null;
						}
						else
						{
							PlotCenterText plotCenterText6 = centerText;
							flag4 = ((plotCenterText6.Config != null) ? new bool?(plotCenterText6.Config.GetValueOrDefault().IsT2) : null);
						}
						flag3 = flag4;
						if (flag3.GetValueOrDefault())
						{
							num5 = centerText.Config.Value.AsT2.TotalTime.GetValueOrDefault();
						}
					}
					this.TextAnimDelayId = TimerSystem.Instance.Delay(delegate(float _)
					{
						this.SetTweenAndPlay(false, fadeOutTime);
						this.TextAnimDelayId = null;
					}, (float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)(fadeInTime2 + num5)), null, null, true, 1f);
					this.TextTime = new float?(fadeInTime2 + num5 + fadeOutTime);
					return;
				}
				this.TextAnimDataComp.SetSelectorOffset(0f);
			}
		}

		// Token: 0x06036B95 RID: 224149 RVA: 0x00DDFDC4 File Offset: 0x00DDDFC4
		private void SetTextOverflowType()
		{
			PlotCenterText centerText = this.CenterText;
			bool flag = false;
			bool? flag2;
			if (centerText == null)
			{
				flag2 = null;
			}
			else
			{
				PlotCenterText plotCenterText = centerText;
				flag2 = ((plotCenterText.Config != null) ? new bool?(plotCenterText.Config.GetValueOrDefault().IsT1) : null);
			}
			bool? flag3 = flag2;
			if (flag3.GetValueOrDefault())
			{
				flag = centerText.Config.Value.AsT1.IsCancelAutoLine.GetValueOrDefault();
			}
			else
			{
				bool? flag4;
				if (centerText == null)
				{
					flag4 = null;
				}
				else
				{
					PlotCenterText plotCenterText2 = centerText;
					flag4 = ((plotCenterText2.Config != null) ? new bool?(plotCenterText2.Config.GetValueOrDefault().IsT2) : null);
				}
				flag3 = flag4;
				if (flag3.GetValueOrDefault())
				{
					flag = centerText.Config.Value.AsT2.IsCancelAutoLine.GetValueOrDefault();
				}
			}
			UITextOverflowType overflowType = flag ? UITextOverflowType.HorizontalOverflow : UITextOverflowType.VerticalOverflow;
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetOverflowType(overflowType);
			}
		}

		// Token: 0x06036B96 RID: 224150 RVA: 0x00DDFECC File Offset: 0x00DDE0CC
		private void OnBtnSkipClick()
		{
			if (this.FadeDelayId != null)
			{
				return;
			}
			if (this.WaitingSkipTimerId != null)
			{
				this.WaitingSkipTimerId = null;
				this.ResumeNextLine();
			}
			if (this.TextShowDelayId == null)
			{
				return;
			}
			if (this.AnimMode == PlotTransitionView.ETextAnimMode.TypeWriter || this.AnimMode == PlotTransitionView.ETextAnimMode.Fade)
			{
				if (this.TextShowDelayId != null)
				{
					TimerSystem.Instance.Remove(this.TextShowDelayId);
				}
				this.TextShowDelayId = null;
				this.ClearAudio();
				base.GetText(0).SetUIActive(false);
				base.GetTexture(2).SetUIActive(false);
				this.ExecuteCallBack();
			}
		}

		// Token: 0x06036B97 RID: 224151 RVA: 0x00DDFF58 File Offset: 0x00DDE158
		private void SetNextPageButtonActive(bool isActive)
		{
			base.GetButton(3).GetRootComponent().SetUIActive(isActive);
			this.HandleFullClickContinueBinding(isActive);
		}

		// Token: 0x06036B98 RID: 224152 RVA: 0x00DDFF74 File Offset: 0x00DDE174
		private void HandleFullClickContinueBinding(bool bind)
		{
			if (bind)
			{
				if (this.HasBindFullClickContinue)
				{
					return;
				}
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("全量点击继续", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputFullClickContinue));
				this.HasBindFullClickContinue = true;
				return;
			}
			else
			{
				if (!this.HasBindFullClickContinue)
				{
					return;
				}
				ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("全量点击继续", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputFullClickContinue));
				this.HasBindFullClickContinue = false;
				return;
			}
		}

		// Token: 0x06036B99 RID: 224153 RVA: 0x00DDFFDB File Offset: 0x00DDE1DB
		[NullableContext(1)]
		private void OnInputFullClickContinue(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			this.OnBtnSkipClick();
		}

		// Token: 0x06036B9A RID: 224154 RVA: 0x00DDFFE4 File Offset: 0x00DDE1E4
		private void SetMultiLineTextAnimTimer()
		{
			if (this.CurLine >= this.LineCount)
			{
				return;
			}
			this.TextAnimDelayId = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.SetTweenPauseOrResume(true);
				this.TextAnimDelayId = null;
				this.SetMultiLineWaitingSkipTimer();
			}, (float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)this.OneLineTime), null, null, true, 1f);
		}

		// Token: 0x06036B9B RID: 224155 RVA: 0x00DE0038 File Offset: 0x00DDE238
		private void SetMultiLineWaitingSkipTimer()
		{
			this.WaitingSkipTimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.WaitingSkipTimerId = null;
				this.ResumeNextLine();
			}, (float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)ModelBase<PlotModel>.Instance.PlotGlobalConfig.EndWaitTimeCenterText), null, null, true, 1f);
		}

		// Token: 0x06036B9C RID: 224156 RVA: 0x00DE0084 File Offset: 0x00DDE284
		private void ResumeNextLine()
		{
			this.SetTweenPauseOrResume(false);
			this.CurLine++;
			if (this.AnimMode == PlotTransitionView.ETextAnimMode.MultiLineTypeWriter)
			{
				this.OneLineTime = (float)this.LineNumArray[this.CurLine - 1] / this.Speed;
			}
			this.SetMultiLineTextAnimTimer();
		}

		// Token: 0x06036B9D RID: 224157 RVA: 0x00DE00D8 File Offset: 0x00DDE2D8
		private int GetLineNum()
		{
			if (this.LineNumArray != null)
			{
				return this.LineNumArray.Count;
			}
			UUIText text = base.GetText(0);
			TArray<int> tarray = new TArray<int>();
			text.GetTextLineNumArray(ref tarray);
			this.LineNumArray = new List<int>();
			for (int i = 0; i < tarray.Num(); i++)
			{
				int item = tarray.Get(i);
				this.LineNumArray.Add(item);
			}
			return this.LineNumArray.Count;
		}

		// Token: 0x06036B9E RID: 224158 RVA: 0x00DE0148 File Offset: 0x00DDE348
		[NullableContext(1)]
		public void FadeInScreen([Nullable(2)] FadeInScreen inParam, Action callback)
		{
			this.SetNextPageButtonActive(false);
			float num;
			if (inParam != null)
			{
				IEaseData ease = inParam.Ease;
				bool flag;
				if (ease == null)
				{
					flag = false;
				}
				else
				{
					float duration = ease.Duration;
					flag = true;
				}
				if (flag)
				{
					num = Singleton<MathUtils>.Instance.Clamp(inParam.Ease.Duration, 0f, 30f);
					goto IL_46;
				}
			}
			num = 1f;
			IL_46:
			float num2 = num;
			EFadeInScreenShowType? efadeInScreenShowType = (inParam != null) ? inParam.ScreenType : null;
			EFadeInScreenShowType efadeInScreenShowType2 = EFadeInScreenShowType.White;
			if (efadeInScreenShowType.GetValueOrDefault() == efadeInScreenShowType2 & efadeInScreenShowType != null)
			{
				base.GetTexture(1).SetColor(ColorUtils.ColorWhile);
			}
			this.Fade(false, num2);
			this.ExecuteCallBack();
			this.Callback = callback;
			if (this.FadeDelayId != null)
			{
				TimerSystem.Instance.Remove(this.FadeDelayId);
			}
			this.FadeDelayId = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ExecuteCallBack();
				this.FadeDelayId = null;
			}, (float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)num2), null, null, true, 1f);
		}

		// Token: 0x06036B9F RID: 224159 RVA: 0x00DE0238 File Offset: 0x00DDE438
		[NullableContext(1)]
		public void FadeOutScreen([Nullable(2)] FadeOutScreen inParam, Action callback)
		{
			this.SetNextPageButtonActive(false);
			float num;
			if (inParam != null)
			{
				IEaseData ease = inParam.Ease;
				bool flag;
				if (ease == null)
				{
					flag = false;
				}
				else
				{
					float duration = ease.Duration;
					flag = true;
				}
				if (flag)
				{
					num = Singleton<MathUtils>.Instance.Clamp(inParam.Ease.Duration, 0f, 30f);
					goto IL_46;
				}
			}
			num = 1f;
			IL_46:
			float num2 = num;
			this.Fade(true, num2);
			this.ExecuteCallBack();
			this.Callback = callback;
			if (this.FadeDelayId != null)
			{
				TimerSystem.Instance.Remove(this.FadeDelayId);
			}
			this.FadeDelayId = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ExecuteCallBack();
				this.FadeDelayId = null;
			}, (float)Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)num2), null, null, true, 1f);
		}

		// Token: 0x0401F860 RID: 129120
		private const float TYPEWRITERRANGE = 0.01f;

		// Token: 0x0401F861 RID: 129121
		private const float FADEOUTRANGE = 9999f;

		// Token: 0x0401F862 RID: 129122
		private const float FADEMAXTIME = 30f;

		// Token: 0x0401F863 RID: 129123
		private const int PLAY_FLAG = 8;

		// Token: 0x0401F864 RID: 129124
		private UUIEffectTextAnimation TextAnimDataComp;

		// Token: 0x0401F865 RID: 129125
		private ULGUIPlayTweenComponent TextPlayTweenComp;

		// Token: 0x0401F866 RID: 129126
		private ULGUIPlayTweenComponent TexturePlayTweenComp;

		// Token: 0x0401F867 RID: 129127
		private TimerHandle TextShowDelayId;

		// Token: 0x0401F868 RID: 129128
		private TimerHandle TextAnimDelayId;

		// Token: 0x0401F869 RID: 129129
		private TimerHandle FadeDelayId;

		// Token: 0x0401F86A RID: 129130
		private float? TextTime = new float?(0f);

		// Token: 0x0401F86B RID: 129131
		private PlotCenterText CenterText;

		// Token: 0x0401F86C RID: 129132
		private Action Callback;

		// Token: 0x0401F86D RID: 129133
		[Nullable(1)]
		private readonly PlayResult PlotPlayEventResult = new PlayResult();

		// Token: 0x0401F86E RID: 129134
		private PlotTransitionView.ETextAnimMode AnimMode;

		// Token: 0x0401F86F RID: 129135
		private float OneLineTime;

		// Token: 0x0401F870 RID: 129136
		private float FadeOutTime;

		// Token: 0x0401F871 RID: 129137
		private int CurLine = 1;

		// Token: 0x0401F872 RID: 129138
		private int LineCount = 1;

		// Token: 0x0401F873 RID: 129139
		private float Speed;

		// Token: 0x0401F874 RID: 129140
		private List<int> LineNumArray;

		// Token: 0x0401F875 RID: 129141
		private TimerHandle WaitingSkipTimerId;

		// Token: 0x0401F876 RID: 129142
		private FLGUIPlayTweenCompleteDynamicDelegate TextPlayTweenEndCb;

		// Token: 0x0401F877 RID: 129143
		private FLGUIDelegateHandleWrapper TextPlayTweenEndCbWrapper;

		// Token: 0x0401F878 RID: 129144
		private IPostAkEventType TalkEndAkEvent;

		// Token: 0x0401F879 RID: 129145
		private bool HasBindFullClickContinue;

		// Token: 0x0200B346 RID: 45894
		[NullableContext(0)]
		private enum ETextAnimMode
		{
			// Token: 0x04037883 RID: 227459
			None,
			// Token: 0x04037884 RID: 227460
			TypeWriter,
			// Token: 0x04037885 RID: 227461
			Fade,
			// Token: 0x04037886 RID: 227462
			MultiLineTypeWriter,
			// Token: 0x04037887 RID: 227463
			MultiLineFade
		}

		// Token: 0x0200B347 RID: 45895
		[NullableContext(0)]
		private class EPlotTransitionView
		{
			// Token: 0x04037888 RID: 227464
			public const int Text = 0;

			// Token: 0x04037889 RID: 227465
			public const int TexBg = 1;

			// Token: 0x0403788A RID: 227466
			public const int TexContent = 2;

			// Token: 0x0403788B RID: 227467
			public const int BtnNextPage = 3;

			// Token: 0x0403788C RID: 227468
			public const int PnlFull = 4;

			// Token: 0x0403788D RID: 227469
			public const int PnlState = 5;
		}
	}
}
