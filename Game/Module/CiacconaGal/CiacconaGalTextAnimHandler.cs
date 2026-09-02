using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC7 RID: 24263
	[NullableContext(1)]
	[Nullable(0)]
	internal class CiacconaGalTextAnimHandler : ICiacconaGalTextAnimHandler, IStaticVariableResetter
	{
		// Token: 0x0603CFA6 RID: 249766 RVA: 0x00F7C523 File Offset: 0x00F7A723
		static CiacconaGalTextAnimHandler()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CiacconaGalTextAnimHandler.CreateStaticDefaultValue), new Action(CiacconaGalTextAnimHandler.ResetStaticDefaultValue));
		}

		// Token: 0x0603CFA7 RID: 249767 RVA: 0x00F7C542 File Offset: 0x00F7A742
		public static void CreateStaticDefaultValue()
		{
			CiacconaGalTextAnimHandler.AudioEventHandle = 0;
		}

		// Token: 0x0603CFA8 RID: 249768 RVA: 0x00F7C54A File Offset: 0x00F7A74A
		public static void ResetStaticDefaultValue()
		{
			CiacconaGalTextAnimHandler.AudioEventHandle = 0;
		}

		// Token: 0x0603CFA9 RID: 249769 RVA: 0x00F7C552 File Offset: 0x00F7A752
		public CiacconaGalTextAnimHandler(ULGUIPlayTweenComponent animCompInternal)
		{
			this.AnimCompInternal = animCompInternal;
		}

		// Token: 0x170099E6 RID: 39398
		// (get) Token: 0x0603CFAA RID: 249770 RVA: 0x00F7C561 File Offset: 0x00F7A761
		private ULGUIPlayTweenComponent AnimComp
		{
			get
			{
				if (this.AnimCompInternal == null || !this.AnimCompInternal.IsValid())
				{
					return null;
				}
				return this.AnimCompInternal;
			}
		}

		// Token: 0x0603CFAB RID: 249771 RVA: 0x00F7C580 File Offset: 0x00F7A780
		public void SetData(CiacconaGalStepData data)
		{
			this.Data = data;
		}

		// Token: 0x0603CFAC RID: 249772 RVA: 0x00F7C58C File Offset: 0x00F7A78C
		public void Play()
		{
			this.StopAudio();
			PlotAudio? config = ConfigPlotAudioById.GetConfig(this.Data.TalkTid, true);
			if (config == null)
			{
				this.PlayDefault();
				return;
			}
			string externalSourcesMediaName = ModelBase<PlotAudioModel>.Instance.GetExternalSourcesMediaName(config.Value);
			string @event = "play_vo_caccona_gal";
			FTransformDouble? target = null;
			CiacconaGalTextAnimHandler.AudioEventHandle = Singleton<AudioSystem>.Instance.PostEvent(@event, target, new PostEventArgs?(new PostEventArgs
			{
				ExternalSourceName = "external_caccona_gal_voice",
				ExternalSourceMediaName = externalSourcesMediaName,
				CallbackMask = new ECallbackMask?(ECallbackMask.Duration),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					if (callbackType == EAkCallbackType.Duration)
					{
						float duration = ((UAkDurationCallbackInfo)callbackInfo).Duration;
						this.Duration = duration;
						ULGUIPlayTween_Float ulguiplayTween_Float = (ULGUIPlayTween_Float)this.AnimComp.GetPlayTween();
						float avgTextAnimShortenTime = CiacconaGalUtils.GetAvgTextAnimShortenTime();
						ulguiplayTween_Float.duration = Math.Max(duration / 1000f - avgTextAnimShortenTime, 1f);
						ulguiplayTween_Float.from = 0.9f;
						ulguiplayTween_Float.to = 0.05f;
						this.AnimComp.Play();
						this.StartTime = (float)Singleton<Time>.Instance.NowSeconds;
					}
				}
			}));
		}

		// Token: 0x0603CFAD RID: 249773 RVA: 0x00F7C638 File Offset: 0x00F7A838
		private void PlayDefault()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CiacconaGal;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "剧情步骤没有语音配置，使用默认速率播放";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("StepId", this.Data.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			int textAnimDefaultDuration = this.Data.TextAnimDefaultDuration;
			this.Duration = (float)textAnimDefaultDuration;
			this.AnimComp.GetPlayTween().duration = (float)textAnimDefaultDuration;
			this.AnimComp.Play();
			this.StartTime = (float)Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x0603CFAE RID: 249774 RVA: 0x00F7C6C0 File Offset: 0x00F7A8C0
		public void Stop()
		{
			this.StopAudio();
			ULGUIPlayTweenComponent animComp = this.AnimComp;
			if (animComp == null)
			{
				return;
			}
			ULGUIPlayTween playTween = animComp.GetPlayTween();
			if (playTween == null)
			{
				return;
			}
			ULTweener tweener = playTween.GetTweener();
			if (tweener == null)
			{
				return;
			}
			tweener.Kill(false);
		}

		// Token: 0x0603CFAF RID: 249775 RVA: 0x00F7C6F0 File Offset: 0x00F7A8F0
		public void Skip()
		{
			ULTweener tweener = this.AnimComp.GetPlayTween().GetTweener();
			if (tweener != null)
			{
				double num = Singleton<Time>.Instance.NowSeconds - (double)this.StartTime;
				double num2 = (double)this.Duration * Singleton<TimeUtil>.Instance.Millisecond - num;
				float avgSkippingTime = CiacconaGalUtils.GetAvgSkippingTime();
				float speed = tweener.GetSpeed();
				double num3 = Math.Max(num2 / (double)avgSkippingTime, 1.0);
				tweener.SetSpeed((float)((double)speed * num3));
			}
		}

		// Token: 0x0603CFB0 RID: 249776 RVA: 0x00F7C76C File Offset: 0x00F7A96C
		private void StopAudio()
		{
			if (CiacconaGalTextAnimHandler.AudioEventHandle != 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(CiacconaGalTextAnimHandler.AudioEventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
				{
					TransitionDuration = new int?(500)
				}));
				CiacconaGalTextAnimHandler.AudioEventHandle = 0;
			}
		}

		// Token: 0x04022393 RID: 140179
		private CiacconaGalStepData Data;

		// Token: 0x04022394 RID: 140180
		private static int AudioEventHandle;

		// Token: 0x04022395 RID: 140181
		private float Duration;

		// Token: 0x04022396 RID: 140182
		private float StartTime;

		// Token: 0x04022397 RID: 140183
		private ULGUIPlayTweenComponent AnimCompInternal;
	}
}
