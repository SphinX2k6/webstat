using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common
{
	// Token: 0x02005E44 RID: 24132
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonFlowTextLogic<T> where T : class
	{
		// Token: 0x0603CBA2 RID: 248738 RVA: 0x00F6BEB0 File Offset: 0x00F6A0B0
		private void RemoveAnimTimer()
		{
			if (this.AnimTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AnimTimer);
				this.AnimTimer = null;
			}
		}

		// Token: 0x0603CBA3 RID: 248739 RVA: 0x00F6BED2 File Offset: 0x00F6A0D2
		private void HandleSubtitleAnimFinished(float _)
		{
			this.AnimTimer = null;
			ICommonFlowTextLogicData<T> data = this.Data;
			if (data == null)
			{
				return;
			}
			Action<ITalkItem, T> textAnimFinishDelegate = data.TextAnimFinishDelegate;
			if (textAnimFinishDelegate == null)
			{
				return;
			}
			textAnimFinishDelegate(this.TalkData, this.ExtraData);
		}

		// Token: 0x0603CBA4 RID: 248740 RVA: 0x00F6BF04 File Offset: 0x00F6A104
		private void SetFlowText(UUIText text)
		{
			if (Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.TalkData.TidTalk, Array.Empty<object>());
				return;
			}
			string text2 = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(this.TalkData.TidTalk);
			if (StringUtils.IsEmpty(text2))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "字幕为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", this.TalkData.TidTalk);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				text2 = this.TalkData.TidTalk;
			}
			text.SetGameRichText(true);
			text.SetText(text2, true);
		}

		// Token: 0x0603CBA5 RID: 248741 RVA: 0x00F6BFA4 File Offset: 0x00F6A1A4
		private void PlayTextAnim(UUIText text, float? totalTime = null)
		{
			this.RemoveAnimTimer();
			ICommonFlowTextLogicData<T> data = this.Data;
			if (data != null)
			{
				Action<ITalkItem, T> textAnimStartDelegate = data.TextAnimStartDelegate;
				if (textAnimStartDelegate != null)
				{
					textAnimStartDelegate(this.TalkData, this.ExtraData);
				}
			}
			int displayCharLength = text.GetDisplayCharLength();
			float num;
			if (totalTime != null)
			{
				num = totalTime.Value;
			}
			else
			{
				num = (float)displayCharLength / ModelBase<PlotModel>.Instance.PlotGlobalConfig.TextAnimSpeedLevelD;
			}
			float interval = Math.Max(num * 1000f, 20f);
			UUIEffectTextAnimation uuieffectTextAnimation = text.GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation;
			if (uuieffectTextAnimation != null)
			{
				uuieffectTextAnimation.SetSelectorOffset(1f);
			}
			this.TextAnimComp = (text.GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			if (this.TextAnimComp != null)
			{
				this.TextAnimComp.GetPlayTween().duration = num;
				this.TextAnimComp.Play();
			}
			this.AnimTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.HandleSubtitleAnimFinished), interval, null, null, true, 1f);
		}

		// Token: 0x0603CBA6 RID: 248742 RVA: 0x00F6C0B7 File Offset: 0x00F6A2B7
		public void InitData(ICommonFlowTextLogicData<T> data)
		{
			this.Data = data;
		}

		// Token: 0x0603CBA7 RID: 248743 RVA: 0x00F6C0C0 File Offset: 0x00F6A2C0
		public void PlayFlowText(ITalkItem talkData, [Nullable(2)] T param)
		{
			this.TalkData = talkData;
			this.ExtraData = param;
			ICommonFlowTextLogicData<T> data = this.Data;
			UUIText uuitext;
			if (data == null)
			{
				uuitext = null;
			}
			else
			{
				Func<ITalkItem, UUIText> getTextComp = data.GetTextComp;
				uuitext = ((getTextComp != null) ? getTextComp(talkData) : null);
			}
			UUIText uuitext2 = uuitext;
			if (uuitext2 == null)
			{
				return;
			}
			this.PlayAkEvent();
			this.SetFlowText(uuitext2);
			ICaptionParam captionParams = this.TalkData.CaptionParams;
			this.PlayTextAnim(uuitext2, (captionParams != null) ? captionParams.TotalTime : null);
		}

		// Token: 0x0603CBA8 RID: 248744 RVA: 0x00F6C134 File Offset: 0x00F6A334
		public void Clear()
		{
			ULGUIPlayTweenComponent textAnimComp = this.TextAnimComp;
			if (textAnimComp != null)
			{
				textAnimComp.Stop();
			}
			this.RemoveAnimTimer();
			ICommonFlowTextLogicData<T> data = this.Data;
			if (data != null)
			{
				Action clearDelegate = data.ClearDelegate;
				if (clearDelegate != null)
				{
					clearDelegate();
				}
			}
			this.TalkData = null;
			this.ExtraData = default(T);
		}

		// Token: 0x0603CBA9 RID: 248745 RVA: 0x00F6C188 File Offset: 0x00F6A388
		private void PlayAkEvent()
		{
			IPostAkEventType talkAkEvent = this.TalkData.TalkAkEvent;
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
					if (text == null)
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
					WorldEntity entity = entityByPbDataId.Entity;
					AActor aactor;
					if (entity == null)
					{
						aactor = null;
					}
					else
					{
						BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
						aactor = ((component != null) ? component.Owner : null);
					}
					AActor aactor2 = aactor;
					if (aactor2 == null || !aactor2.IsValid())
					{
						global::Log instance2 = Singleton<global::Log>.Instance;
						ELogModule module2 = ELogModule.Event;
						ELogAuthor author2 = ELogAuthor.FZX;
						string message2 = "未能获取到该实体对应的有效Actor";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", entityId);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return;
					}
					Singleton<AudioSystem>.Instance.PostEvent(text, aactor2, null);
				}
				return;
			}
			IPostAkEventGlobal postAkEventGlobal = talkAkEvent as IPostAkEventGlobal;
			string text2 = Singleton<AudioSystem>.Instance.parseAudioEventPath(postAkEventGlobal.AkEvent);
			if (text2 == null)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent(text2);
		}

		// Token: 0x04022189 RID: 139657
		private ULGUIPlayTweenComponent TextAnimComp;

		// Token: 0x0402218A RID: 139658
		private ITalkItem TalkData;

		// Token: 0x0402218B RID: 139659
		[Nullable(2)]
		private T ExtraData;

		// Token: 0x0402218C RID: 139660
		private ICommonFlowTextLogicData<T> Data;

		// Token: 0x0402218D RID: 139661
		private TimerHandle AnimTimer;
	}
}
