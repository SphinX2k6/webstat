using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.PlotView.PlotComponent;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Letter.View
{
	// Token: 0x02005A21 RID: 23073
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LetterContentItem : GridProxyAbstract<ITalkItem>
	{
		// Token: 0x0603A695 RID: 239253 RVA: 0x00ECF4FC File Offset: 0x00ECD6FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603A696 RID: 239254 RVA: 0x00ECF544 File Offset: 0x00ECD744
		[NullableContext(1)]
		public override void Refresh(ITalkItem data, bool isSelected, int gridIndex)
		{
			if (this.BoundTalkId == data.Id)
			{
				return;
			}
			this.BoundTalkId = data.Id;
			this.IsPlaying = false;
			this.HasFiredFinished = false;
			this.OnFinishedCallback = null;
			this.ClearRuntime();
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(data.TidTalk))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TidTalk, Array.Empty<object>());
			}
			else
			{
				text.SetText("", true);
			}
			UUIItem uuiitem = text;
			ITalkItemDialog talkItemDialog = data as ITalkItemDialog;
			bool flag;
			if (talkItemDialog == null)
			{
				flag = false;
			}
			else
			{
				ITalkItemStyle style = talkItemDialog.Style;
				ETalkItemStyle? etalkItemStyle = (style != null) ? new ETalkItemStyle?(style.Type) : null;
				ETalkItemStyle etalkItemStyle2 = ETalkItemStyle.InnerVoice;
				flag = (etalkItemStyle.GetValueOrDefault() == etalkItemStyle2 & etalkItemStyle != null);
			}
			uuiitem.SetAlpha(flag ? 0.67f : 1f);
			AActor owner = text.GetOwner();
			UUIEffectTextAnimation uuieffectTextAnimation = ((owner != null) ? owner.GetComponentByClass(UUIEffectTextAnimation.StaticClass()) : null) as UUIEffectTextAnimation;
			ULGUIPlayTweenComponent ulguiplayTweenComponent = ((owner != null) ? owner.GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) : null) as ULGUIPlayTweenComponent;
			if (uuieffectTextAnimation == null || ulguiplayTweenComponent == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[LetterContentItem] 文本打字机组件缺失";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TalkId", data.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.WriterComp = new PlotTextWriterComponent();
			this.WriterComp.Init(new PlotTextWriterComponentContext
			{
				TextComponent = text,
				TextAnimComp = uuieffectTextAnimation,
				TweenComp = ulguiplayTweenComponent
			});
			this.TypingDurationSec = PlotComponentUtils.GetTextWriterAnimDuration(data, text, PlotComponentUtils.GetTextWriterAnimSpeed(false));
			this.WriterComp.SetPlayDuration(this.TypingDurationSec);
			this.AudioComp = new PlotTextAudioComponent();
			this.AudioComp.Init(new PlotTextAudioComponentContext
			{
				OnAudioStartDelegate = new Action(this.OnAudioStart)
			});
			this.AudioComp.TryPlayTalkAudioByTalkItem(data);
			this.ProtectEndMs = DateTimeOffset.Now.ToUnixTimeMilliseconds() + (long)PlotComponentUtils.GetTalkWaitTime(data);
			this.IsPlaying = true;
			this.WriterComp.Play();
			this.ScheduleEndTimer(this.TypingDurationSec);
		}

		// Token: 0x0603A697 RID: 239255 RVA: 0x00ECF75C File Offset: 0x00ECD95C
		public void ForceComplete()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			PlotTextWriterComponent writerComp = this.WriterComp;
			if (writerComp != null)
			{
				writerComp.JumpToEnd();
			}
			PlotTextAudioComponent audioComp = this.AudioComp;
			if (audioComp != null)
			{
				audioComp.StopAudio();
			}
			this.ClearEndTimer();
			this.ProtectEndMs = 0L;
			this.IsPlaying = false;
			this.FireFinished();
		}

		// Token: 0x0603A698 RID: 239256 RVA: 0x00ECF7B0 File Offset: 0x00ECD9B0
		public bool IsInProtectTime()
		{
			return DateTimeOffset.Now.ToUnixTimeMilliseconds() < this.ProtectEndMs;
		}

		// Token: 0x0603A699 RID: 239257 RVA: 0x00ECF7D4 File Offset: 0x00ECD9D4
		public long GetProtectRemainingMs()
		{
			return Math.Max(0L, this.ProtectEndMs - DateTimeOffset.Now.ToUnixTimeMilliseconds());
		}

		// Token: 0x0603A69A RID: 239258 RVA: 0x00ECF7FC File Offset: 0x00ECD9FC
		public bool IsFinished()
		{
			return this.HasFiredFinished;
		}

		// Token: 0x0603A69B RID: 239259 RVA: 0x00ECF804 File Offset: 0x00ECDA04
		[NullableContext(1)]
		public unsafe void SetOnFinished(Action callback)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Plot;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[WL-Finish] ContentItem.SetOnFinished";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TalkId", this.BoundTalkId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HasFiredFinished", this.HasFiredFinished);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.HasFiredFinished)
			{
				callback();
				return;
			}
			this.OnFinishedCallback = callback;
		}

		// Token: 0x0603A69C RID: 239260 RVA: 0x00ECF88D File Offset: 0x00ECDA8D
		[NullableContext(1)]
		public override object GetKey(ITalkItem data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x0603A69D RID: 239261 RVA: 0x00ECF89A File Offset: 0x00ECDA9A
		protected override void OnBeforeDestroy()
		{
			this.ClearRuntime();
		}

		// Token: 0x0603A69E RID: 239262 RVA: 0x00ECF8A4 File Offset: 0x00ECDAA4
		private void OnAudioStart()
		{
			PlotTextAudioComponent audioComp = this.AudioComp;
			float val = ((audioComp != null) ? audioComp.GetAudioDuration() : 0f) / 1000f;
			this.ScheduleEndTimer(Math.Max(this.TypingDurationSec, val));
		}

		// Token: 0x0603A69F RID: 239263 RVA: 0x00ECF8E0 File Offset: 0x00ECDAE0
		private void ScheduleEndTimer(float durationSeconds)
		{
			this.ClearEndTimer();
			int num = Math.Max(0, (int)Math.Floor((double)(durationSeconds * 1000f)));
			if (num <= 0)
			{
				this.IsPlaying = false;
				this.FireFinished();
				return;
			}
			this.EndTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.EndTimer = null;
				this.IsPlaying = false;
				this.FireFinished();
			}, (float)num, null, null, true, 1f);
		}

		// Token: 0x0603A6A0 RID: 239264 RVA: 0x00ECF940 File Offset: 0x00ECDB40
		private void FireFinished()
		{
			if (this.HasFiredFinished)
			{
				return;
			}
			this.HasFiredFinished = true;
			Action onFinishedCallback = this.OnFinishedCallback;
			this.OnFinishedCallback = null;
			if (onFinishedCallback == null)
			{
				return;
			}
			onFinishedCallback();
		}

		// Token: 0x0603A6A1 RID: 239265 RVA: 0x00ECF969 File Offset: 0x00ECDB69
		private void ClearEndTimer()
		{
			if (this.EndTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.EndTimer);
				this.EndTimer = null;
			}
		}

		// Token: 0x0603A6A2 RID: 239266 RVA: 0x00ECF98B File Offset: 0x00ECDB8B
		private void ClearRuntime()
		{
			this.ClearEndTimer();
			PlotTextWriterComponent writerComp = this.WriterComp;
			if (writerComp != null)
			{
				writerComp.Clear();
			}
			this.WriterComp = null;
			PlotTextAudioComponent audioComp = this.AudioComp;
			if (audioComp != null)
			{
				audioComp.StopAudio();
			}
			this.AudioComp = null;
		}

		// Token: 0x04021151 RID: 135505
		private PlotTextWriterComponent WriterComp;

		// Token: 0x04021152 RID: 135506
		private PlotTextAudioComponent AudioComp;

		// Token: 0x04021153 RID: 135507
		private TimerHandle EndTimer;

		// Token: 0x04021154 RID: 135508
		private long ProtectEndMs;

		// Token: 0x04021155 RID: 135509
		private float TypingDurationSec;

		// Token: 0x04021156 RID: 135510
		private int BoundTalkId = -1;

		// Token: 0x04021157 RID: 135511
		private bool IsPlaying;

		// Token: 0x04021158 RID: 135512
		private bool HasFiredFinished;

		// Token: 0x04021159 RID: 135513
		private Action OnFinishedCallback;

		// Token: 0x0200BA05 RID: 47621
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039776 RID: 235382
			public const int TxtLetterContent = 0;
		}
	}
}
