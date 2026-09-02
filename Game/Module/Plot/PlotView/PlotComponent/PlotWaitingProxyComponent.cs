using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053F5 RID: 21493
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotWaitingProxyComponent
	{
		// Token: 0x06036DDE RID: 224734 RVA: 0x00DE907E File Offset: 0x00DE727E
		[NullableContext(1)]
		public void Init(PlotWaitingProxyComponentContext context)
		{
			this.OnWaitingCompleteDelegate = context.OnWaitingCompleteDelegate;
			this.OnWaitingCancelDelegate = context.OnWaitingCancelDelegate;
			this.OnWaitingStartDelegate = context.OnWaitingStartDelegate;
		}

		// Token: 0x06036DDF RID: 224735 RVA: 0x00DE90A4 File Offset: 0x00DE72A4
		public void Wait(float duration)
		{
			if (this.IsWaiting)
			{
				return;
			}
			this.WaitDuration = duration;
			this.ElapsedTime = 0f;
			this.IsWaiting = true;
			this.IsPaused = false;
			Action onWaitingStartDelegate = this.OnWaitingStartDelegate;
			if (onWaitingStartDelegate == null)
			{
				return;
			}
			onWaitingStartDelegate();
		}

		// Token: 0x06036DE0 RID: 224736 RVA: 0x00DE90DF File Offset: 0x00DE72DF
		public void Cancel()
		{
			if (!this.IsWaiting)
			{
				return;
			}
			Action onWaitingCancelDelegate = this.OnWaitingCancelDelegate;
			if (onWaitingCancelDelegate != null)
			{
				onWaitingCancelDelegate();
			}
			this.IsWaiting = false;
			this.IsPaused = false;
			this.ElapsedTime = 0f;
		}

		// Token: 0x06036DE1 RID: 224737 RVA: 0x00DE9114 File Offset: 0x00DE7314
		public void Pause()
		{
			if (!this.IsWaiting)
			{
				return;
			}
			this.IsPaused = true;
		}

		// Token: 0x06036DE2 RID: 224738 RVA: 0x00DE9126 File Offset: 0x00DE7326
		public void Resume()
		{
			if (!this.IsWaiting)
			{
				return;
			}
			this.IsPaused = false;
		}

		// Token: 0x06036DE3 RID: 224739 RVA: 0x00DE9138 File Offset: 0x00DE7338
		public void OnTick(float delta)
		{
			if (!this.IsWaiting || this.IsPaused)
			{
				return;
			}
			this.ElapsedTime += delta;
			if (this.ElapsedTime >= this.WaitDuration)
			{
				this.OnWaitingComplete();
			}
		}

		// Token: 0x06036DE4 RID: 224740 RVA: 0x00DE916D File Offset: 0x00DE736D
		private void OnWaitingComplete()
		{
			this.IsWaiting = false;
			this.IsPaused = false;
			this.ElapsedTime = 0f;
			Action onWaitingCompleteDelegate = this.OnWaitingCompleteDelegate;
			if (onWaitingCompleteDelegate == null)
			{
				return;
			}
			onWaitingCompleteDelegate();
		}

		// Token: 0x06036DE5 RID: 224741 RVA: 0x00DE9198 File Offset: 0x00DE7398
		public void Clear()
		{
			this.IsWaiting = false;
			this.IsPaused = false;
			this.ElapsedTime = 0f;
		}

		// Token: 0x06036DE6 RID: 224742 RVA: 0x00DE91B3 File Offset: 0x00DE73B3
		public bool GetIsWaiting()
		{
			return this.IsWaiting;
		}

		// Token: 0x06036DE7 RID: 224743 RVA: 0x00DE91BB File Offset: 0x00DE73BB
		public float GetWaitDuration()
		{
			return this.WaitDuration;
		}

		// Token: 0x06036DE8 RID: 224744 RVA: 0x00DE91C3 File Offset: 0x00DE73C3
		public bool GetIsPaused()
		{
			return this.IsPaused;
		}

		// Token: 0x0401F964 RID: 129380
		private bool IsWaiting;

		// Token: 0x0401F965 RID: 129381
		private float WaitDuration;

		// Token: 0x0401F966 RID: 129382
		private float ElapsedTime;

		// Token: 0x0401F967 RID: 129383
		private bool IsPaused;

		// Token: 0x0401F968 RID: 129384
		private Action OnWaitingStartDelegate;

		// Token: 0x0401F969 RID: 129385
		private Action OnWaitingCompleteDelegate;

		// Token: 0x0401F96A RID: 129386
		private Action OnWaitingCancelDelegate;
	}
}
