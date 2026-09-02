using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053F3 RID: 21491
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotTextScrollComponent
	{
		// Token: 0x06036DB4 RID: 224692 RVA: 0x00DE8992 File Offset: 0x00DE6B92
		[NullableContext(1)]
		public void Init(PlotTextScrollComponentContext context)
		{
			this.TextComponent = context.TextComponent;
			this.TextScrollView = context.TextScrollView;
		}

		// Token: 0x06036DB5 RID: 224693 RVA: 0x00DE89AC File Offset: 0x00DE6BAC
		public void SetCharReadSpeed(float readSpeed)
		{
			this.CharReadSpeed = readSpeed;
		}

		// Token: 0x06036DB6 RID: 224694 RVA: 0x00DE89B5 File Offset: 0x00DE6BB5
		public void SetDelayCharNum(float delayCharNum)
		{
			this.DelayCharNum = delayCharNum;
		}

		// Token: 0x06036DB7 RID: 224695 RVA: 0x00DE89BE File Offset: 0x00DE6BBE
		public void PlayNextFrame()
		{
			if (this.IsWaitingNextFrame)
			{
				return;
			}
			this.IsWaitingNextFrame = true;
			this.NextFrameTimer = TimerSystem.GameplayTimeInstance.Next(new TTimerAction(this.OnNextFramePlay), null, null);
		}

		// Token: 0x06036DB8 RID: 224696 RVA: 0x00DE89EE File Offset: 0x00DE6BEE
		private void OnNextFramePlay(float handle)
		{
			this.IsWaitingNextFrame = false;
			this.RemoveNextFrameTimer();
			this.Play();
		}

		// Token: 0x06036DB9 RID: 224697 RVA: 0x00DE8A04 File Offset: 0x00DE6C04
		public void Play()
		{
			if (this.TextComponent == null || this.TextScrollView == null)
			{
				return;
			}
			if (this.IsPlaying || this.IsPaused)
			{
				return;
			}
			float y = this.TextComponent.GetTextRenderSize().Y;
			float height = this.TextScrollView.GetRootComponent().GetHeight();
			if (y <= height)
			{
				return;
			}
			float num = this.DelayCharNum;
			int displayCharLength = this.TextComponent.GetDisplayCharLength();
			if ((float)displayCharLength <= this.DelayCharNum)
			{
				num = (float)this.TextComponent.GetRenderLineCharNum(0);
			}
			float interval = num / this.CharReadSpeed * 1000f;
			float num2 = (float)displayCharLength - num;
			int renderLineNum = this.TextComponent.GetRenderLineNum();
			float num3 = num2;
			if (renderLineNum > 1)
			{
				num3 = num2 - (float)this.TextComponent.GetRenderLineCharNum(0);
			}
			this.ScrollDuration = num3 / this.CharReadSpeed * 1000f;
			this.DelayTextScrollAnimTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.StartAutoScrollAnim), interval, null, null, true, 1f);
			this.IsPlaying = true;
		}

		// Token: 0x06036DBA RID: 224698 RVA: 0x00DE8AF8 File Offset: 0x00DE6CF8
		public void Stop()
		{
			if (this.IsWaitingNextFrame)
			{
				this.IsWaitingNextFrame = false;
				this.RemoveNextFrameTimer();
				return;
			}
			if (!this.IsPlaying)
			{
				return;
			}
			this.Reset();
		}

		// Token: 0x06036DBB RID: 224699 RVA: 0x00DE8B20 File Offset: 0x00DE6D20
		public void Pause()
		{
			if (!this.IsPlaying)
			{
				return;
			}
			if (this.IsScrolling && this.ScrollTextAnimTimer != null && TimerSystem.GameplayTimeInstance.Has(this.ScrollTextAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Pause(this.ScrollTextAnimTimer, null);
			}
			else if (this.DelayTextScrollAnimTimer != null && TimerSystem.GameplayTimeInstance.Has(this.DelayTextScrollAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Pause(this.DelayTextScrollAnimTimer, null);
			}
			this.IsPaused = true;
		}

		// Token: 0x06036DBC RID: 224700 RVA: 0x00DE8BA0 File Offset: 0x00DE6DA0
		public void Resume()
		{
			if (!this.IsPlaying || !this.IsPaused)
			{
				return;
			}
			if (this.IsScrolling && this.ScrollTextAnimTimer != null && TimerSystem.GameplayTimeInstance.Has(this.ScrollTextAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Resume(this.ScrollTextAnimTimer);
			}
			else if (this.DelayTextScrollAnimTimer != null && TimerSystem.GameplayTimeInstance.Has(this.DelayTextScrollAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Resume(this.DelayTextScrollAnimTimer);
			}
			this.IsPaused = false;
		}

		// Token: 0x06036DBD RID: 224701 RVA: 0x00DE8C25 File Offset: 0x00DE6E25
		public void JumpToEnd()
		{
			this.Stop();
			UUIScrollViewComponent textScrollView = this.TextScrollView;
			if (textScrollView == null)
			{
				return;
			}
			textScrollView.SetScrollProgress(1f);
		}

		// Token: 0x06036DBE RID: 224702 RVA: 0x00DE8C42 File Offset: 0x00DE6E42
		public void Clear()
		{
			this.Reset();
		}

		// Token: 0x06036DBF RID: 224703 RVA: 0x00DE8C4C File Offset: 0x00DE6E4C
		private void StartAutoScrollAnim(float handle)
		{
			if (this.TextComponent == null || this.TextScrollView == null)
			{
				return;
			}
			this.ScrollElapsedTime = 0f;
			this.ScrollTextAnimTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnScrollAnimUpdate), 100f, 1f, null, null, true);
			this.IsScrolling = true;
		}

		// Token: 0x06036DC0 RID: 224704 RVA: 0x00DE8CA8 File Offset: 0x00DE6EA8
		private void OnScrollAnimUpdate(float delta)
		{
			float num = this.ScrollElapsedTime / this.ScrollDuration;
			UUIScrollViewComponent textScrollView = this.TextScrollView;
			if (textScrollView != null)
			{
				textScrollView.SetScrollProgress(num);
			}
			if (num >= 1f)
			{
				this.OnScrollComplete();
				return;
			}
			this.ScrollElapsedTime += delta;
		}

		// Token: 0x06036DC1 RID: 224705 RVA: 0x00DE8CF2 File Offset: 0x00DE6EF2
		private void OnScrollComplete()
		{
			if (!this.IsScrolling)
			{
				return;
			}
			this.Reset();
			Action onScrollCompleteDelegate = this.OnScrollCompleteDelegate;
			if (onScrollCompleteDelegate == null)
			{
				return;
			}
			onScrollCompleteDelegate();
		}

		// Token: 0x06036DC2 RID: 224706 RVA: 0x00DE8D13 File Offset: 0x00DE6F13
		private void Reset()
		{
			this.IsWaitingNextFrame = false;
			this.IsScrolling = false;
			this.IsPlaying = false;
			this.IsPaused = false;
			this.ScrollElapsedTime = 0f;
			this.RemoveScrollAnimTimer();
			this.RemoveDelayScrollAnimTimer();
			this.RemoveNextFrameTimer();
		}

		// Token: 0x06036DC3 RID: 224707 RVA: 0x00DE8D4E File Offset: 0x00DE6F4E
		private void RemoveNextFrameTimer()
		{
			if (this.NextFrameTimer != null && TimerSystem.GameplayTimeInstance.Has(this.NextFrameTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.NextFrameTimer);
			}
			this.NextFrameTimer = null;
		}

		// Token: 0x06036DC4 RID: 224708 RVA: 0x00DE8D82 File Offset: 0x00DE6F82
		private void RemoveScrollAnimTimer()
		{
			if (this.ScrollTextAnimTimer != null && TimerSystem.GameplayTimeInstance.Has(this.ScrollTextAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.ScrollTextAnimTimer);
			}
			this.ScrollTextAnimTimer = null;
		}

		// Token: 0x06036DC5 RID: 224709 RVA: 0x00DE8DB6 File Offset: 0x00DE6FB6
		private void RemoveDelayScrollAnimTimer()
		{
			if (this.DelayTextScrollAnimTimer != null && TimerSystem.GameplayTimeInstance.Has(this.DelayTextScrollAnimTimer))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTextScrollAnimTimer);
			}
			this.DelayTextScrollAnimTimer = null;
		}

		// Token: 0x06036DC6 RID: 224710 RVA: 0x00DE8DEA File Offset: 0x00DE6FEA
		public float GetTextWriterAnimDuration()
		{
			return this.ScrollDuration;
		}

		// Token: 0x06036DC7 RID: 224711 RVA: 0x00DE8DF2 File Offset: 0x00DE6FF2
		public UUIText GetTextComponent()
		{
			return this.TextComponent;
		}

		// Token: 0x06036DC8 RID: 224712 RVA: 0x00DE8DFA File Offset: 0x00DE6FFA
		public UUIScrollViewComponent GetTextScrollView()
		{
			return this.TextScrollView;
		}

		// Token: 0x06036DC9 RID: 224713 RVA: 0x00DE8E02 File Offset: 0x00DE7002
		public bool GetIsPlaying()
		{
			return this.IsPlaying;
		}

		// Token: 0x06036DCA RID: 224714 RVA: 0x00DE8E0A File Offset: 0x00DE700A
		public bool GetIsPaused()
		{
			return this.IsPaused;
		}

		// Token: 0x0401F94F RID: 129359
		private UUIText TextComponent;

		// Token: 0x0401F950 RID: 129360
		private UUIScrollViewComponent TextScrollView;

		// Token: 0x0401F951 RID: 129361
		private float DelayCharNum;

		// Token: 0x0401F952 RID: 129362
		private float CharReadSpeed;

		// Token: 0x0401F953 RID: 129363
		private float ScrollDuration;

		// Token: 0x0401F954 RID: 129364
		private float ScrollElapsedTime;

		// Token: 0x0401F955 RID: 129365
		private bool IsPlaying;

		// Token: 0x0401F956 RID: 129366
		private bool IsPaused;

		// Token: 0x0401F957 RID: 129367
		private bool IsScrolling;

		// Token: 0x0401F958 RID: 129368
		private bool IsWaitingNextFrame;

		// Token: 0x0401F959 RID: 129369
		private TimerHandle NextFrameTimer;

		// Token: 0x0401F95A RID: 129370
		private TimerHandle DelayTextScrollAnimTimer;

		// Token: 0x0401F95B RID: 129371
		private TimerHandle ScrollTextAnimTimer;

		// Token: 0x0401F95C RID: 129372
		private readonly Action OnScrollCompleteDelegate;
	}
}
