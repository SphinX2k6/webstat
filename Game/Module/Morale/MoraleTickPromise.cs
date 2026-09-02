using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005721 RID: 22305
	[NullableContext(2)]
	[Nullable(0)]
	public class MoraleTickPromise
	{
		// Token: 0x06038C4C RID: 232524 RVA: 0x00E5FCCA File Offset: 0x00E5DECA
		private MoraleTickPromise()
		{
		}

		// Token: 0x06038C4D RID: 232525 RVA: 0x00E5FCD2 File Offset: 0x00E5DED2
		[NullableContext(1)]
		public static MoraleTickPromise Create(MoraleTickPromiseParams params_)
		{
			return new MoraleTickPromise
			{
				PlayStartCallback = params_.StartCallback,
				PlayTickCallback = params_.TickCallback,
				PlayEndCallback = params_.EndCallback
			};
		}

		// Token: 0x06038C4E RID: 232526 RVA: 0x00E5FD00 File Offset: 0x00E5DF00
		public UniTask PlayStart(float totalTime)
		{
			MoraleTickPromise.<PlayStart>d__9 <PlayStart>d__;
			<PlayStart>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStart>d__.<>4__this = this;
			<PlayStart>d__.totalTime = totalTime;
			<PlayStart>d__.<>1__state = -1;
			<PlayStart>d__.<>t__builder.Start<MoraleTickPromise.<PlayStart>d__9>(ref <PlayStart>d__);
			return <PlayStart>d__.<>t__builder.Task;
		}

		// Token: 0x06038C4F RID: 232527 RVA: 0x00E5FD4C File Offset: 0x00E5DF4C
		public void Tick(float deltaTime)
		{
			if (!this.IsPlaying)
			{
				return;
			}
			this.AddDeltaTime += deltaTime;
			bool flag = this.AddDeltaTime >= this.TotalTime;
			Action<float> playTickCallback = this.PlayTickCallback;
			if (playTickCallback != null)
			{
				playTickCallback(flag ? this.TotalTime : this.AddDeltaTime);
			}
			if (flag)
			{
				this.Finish();
			}
		}

		// Token: 0x06038C50 RID: 232528 RVA: 0x00E5FDAD File Offset: 0x00E5DFAD
		private void Finish()
		{
			this.IsPlaying = false;
			this.AddDeltaTime = this.TotalTime;
			CustomPromise promise = this.Promise;
			if (promise != null)
			{
				promise.SetResult();
			}
			Action playEndCallback = this.PlayEndCallback;
			if (playEndCallback == null)
			{
				return;
			}
			playEndCallback();
		}

		// Token: 0x06038C51 RID: 232529 RVA: 0x00E5FDE3 File Offset: 0x00E5DFE3
		public void Stop()
		{
			if (this.IsPlaying)
			{
				this.Finish();
			}
		}

		// Token: 0x06038C52 RID: 232530 RVA: 0x00E5FDF3 File Offset: 0x00E5DFF3
		public void Destroy()
		{
			this.PlayStartCallback = null;
			this.PlayTickCallback = null;
			this.PlayEndCallback = null;
			this.Stop();
		}

		// Token: 0x04020562 RID: 132450
		public CustomPromise Promise;

		// Token: 0x04020563 RID: 132451
		public bool IsPlaying;

		// Token: 0x04020564 RID: 132452
		public float AddDeltaTime;

		// Token: 0x04020565 RID: 132453
		public float TotalTime;

		// Token: 0x04020566 RID: 132454
		public Action PlayStartCallback;

		// Token: 0x04020567 RID: 132455
		public Action<float> PlayTickCallback;

		// Token: 0x04020568 RID: 132456
		public Action PlayEndCallback;
	}
}
