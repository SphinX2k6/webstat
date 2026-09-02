using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053F4 RID: 21492
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTextWriterComponent
	{
		// Token: 0x06036DCC RID: 224716 RVA: 0x00DE8E1C File Offset: 0x00DE701C
		[NullableContext(1)]
		public void Init(PlotTextWriterComponentContext context)
		{
			this.TextAnimComp = context.TextAnimComp;
			this.TweenComp = context.TweenComp;
			this.TextComponent = context.TextComponent;
			this.OnAnimCompleteDelegate = context.OnAnimCompleteDelegate;
			this.OnStopDelegate = context.OnStopDelegate;
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			if (tweenComp == null)
			{
				return;
			}
			ULGUIPlayTween playTween = tweenComp.GetPlayTween();
			if (playTween == null)
			{
				return;
			}
			ULTweener tweener = playTween.GetTweener();
			if (tweener == null)
			{
				return;
			}
			tweener.OnCompleteCallBack.Bind(new Action(this.OnTweenComplete));
		}

		// Token: 0x06036DCD RID: 224717 RVA: 0x00DE8E9C File Offset: 0x00DE709C
		public void SetPlayDuration(float duration)
		{
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			ULGUIPlayTween ulguiplayTween = (tweenComp != null) ? tweenComp.GetPlayTween() : null;
			if (ulguiplayTween == null)
			{
				return;
			}
			ulguiplayTween.duration = duration;
		}

		// Token: 0x06036DCE RID: 224718 RVA: 0x00DE8EC7 File Offset: 0x00DE70C7
		public void Play()
		{
			UUIEffectTextAnimation textAnimComp = this.TextAnimComp;
			if (textAnimComp != null)
			{
				textAnimComp.SetSelectorOffset(1f);
			}
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			if (tweenComp != null)
			{
				tweenComp.Play();
			}
			this.BindOnTweenComplete();
			this.IsPlaying = true;
		}

		// Token: 0x06036DCF RID: 224719 RVA: 0x00DE8EFD File Offset: 0x00DE70FD
		public void Stop()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			this.UnbindOnTweenComplete();
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			if (tweenComp != null)
			{
				tweenComp.Stop();
			}
			this.IsPlaying = false;
			this.IsPaused = false;
			Action onStopDelegate = this.OnStopDelegate;
			if (onStopDelegate == null)
			{
				return;
			}
			onStopDelegate();
		}

		// Token: 0x06036DD0 RID: 224720 RVA: 0x00DE8F3D File Offset: 0x00DE713D
		public void Pause()
		{
			if (this.IsPaused)
			{
				return;
			}
			if (!this.IsPlaying)
			{
				return;
			}
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			if (tweenComp != null)
			{
				tweenComp.Pause();
			}
			this.IsPaused = true;
		}

		// Token: 0x06036DD1 RID: 224721 RVA: 0x00DE8F69 File Offset: 0x00DE7169
		public void Resume()
		{
			if (!this.IsPaused)
			{
				return;
			}
			this.IsPaused = false;
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			if (tweenComp == null)
			{
				return;
			}
			tweenComp.Resume();
		}

		// Token: 0x06036DD2 RID: 224722 RVA: 0x00DE8F8B File Offset: 0x00DE718B
		public void JumpToEnd()
		{
			this.Stop();
			UUIEffectTextAnimation textAnimComp = this.TextAnimComp;
			if (textAnimComp == null)
			{
				return;
			}
			textAnimComp.SetSelectorOffset(0f);
		}

		// Token: 0x06036DD3 RID: 224723 RVA: 0x00DE8FA8 File Offset: 0x00DE71A8
		public void Clear()
		{
			this.UnbindOnTweenComplete();
			this.TextAnimComp = null;
			this.TweenComp = null;
		}

		// Token: 0x06036DD4 RID: 224724 RVA: 0x00DE8FBE File Offset: 0x00DE71BE
		private void BindOnTweenComplete()
		{
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			if (tweenComp == null)
			{
				return;
			}
			ULGUIPlayTween playTween = tweenComp.GetPlayTween();
			if (playTween == null)
			{
				return;
			}
			ULTweener tweener = playTween.GetTweener();
			if (tweener == null)
			{
				return;
			}
			tweener.OnCompleteCallBack.Bind(new Action(this.OnTweenComplete));
		}

		// Token: 0x06036DD5 RID: 224725 RVA: 0x00DE8FF5 File Offset: 0x00DE71F5
		private void UnbindOnTweenComplete()
		{
			ULGUIPlayTweenComponent tweenComp = this.TweenComp;
			if (tweenComp == null)
			{
				return;
			}
			ULGUIPlayTween playTween = tweenComp.GetPlayTween();
			if (playTween == null)
			{
				return;
			}
			ULTweener tweener = playTween.GetTweener();
			if (tweener == null)
			{
				return;
			}
			tweener.OnCompleteCallBack.Unbind();
		}

		// Token: 0x06036DD6 RID: 224726 RVA: 0x00DE9020 File Offset: 0x00DE7220
		protected void OnTextWriterAnimComplete()
		{
			this.IsPlaying = false;
			this.IsPaused = false;
			this.UnbindOnTweenComplete();
			Action onAnimCompleteDelegate = this.OnAnimCompleteDelegate;
			if (onAnimCompleteDelegate == null)
			{
				return;
			}
			onAnimCompleteDelegate();
		}

		// Token: 0x06036DD7 RID: 224727 RVA: 0x00DE9046 File Offset: 0x00DE7246
		protected void OnTweenComplete()
		{
			this.OnTextWriterAnimComplete();
		}

		// Token: 0x06036DD8 RID: 224728 RVA: 0x00DE904E File Offset: 0x00DE724E
		public ULGUIPlayTweenComponent GetTweenComponent()
		{
			return this.TweenComp;
		}

		// Token: 0x06036DD9 RID: 224729 RVA: 0x00DE9056 File Offset: 0x00DE7256
		public UUIText GetTextComponent()
		{
			return this.TextComponent;
		}

		// Token: 0x06036DDA RID: 224730 RVA: 0x00DE905E File Offset: 0x00DE725E
		public UUIEffectTextAnimation GetTextAnimComponent()
		{
			return this.TextAnimComp;
		}

		// Token: 0x06036DDB RID: 224731 RVA: 0x00DE9066 File Offset: 0x00DE7266
		public bool GetIsPlaying()
		{
			return this.IsPlaying;
		}

		// Token: 0x06036DDC RID: 224732 RVA: 0x00DE906E File Offset: 0x00DE726E
		public bool GetIsPaused()
		{
			return this.IsPaused;
		}

		// Token: 0x0401F95D RID: 129373
		private UUIText TextComponent;

		// Token: 0x0401F95E RID: 129374
		private UUIEffectTextAnimation TextAnimComp;

		// Token: 0x0401F95F RID: 129375
		private ULGUIPlayTweenComponent TweenComp;

		// Token: 0x0401F960 RID: 129376
		private bool IsPlaying;

		// Token: 0x0401F961 RID: 129377
		private bool IsPaused;

		// Token: 0x0401F962 RID: 129378
		private Action OnAnimCompleteDelegate;

		// Token: 0x0401F963 RID: 129379
		private Action OnStopDelegate;
	}
}
