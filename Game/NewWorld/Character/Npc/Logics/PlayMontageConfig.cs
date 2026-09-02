using System;

namespace CSharpScript.Game.NewWorld.Character.Npc.Logics
{
	// Token: 0x020048D1 RID: 18641
	public class PlayMontageConfig
	{
		// Token: 0x06030A58 RID: 199256 RVA: 0x00BFC930 File Offset: 0x00BFAB30
		public PlayMontageConfig(int times = 0, double duration = 0.0, bool playLoop = false, bool infinite = false)
		{
			this.RepeatTimes = times;
			this.LoopDuration = duration;
			this.IsPlayLoop = (playLoop || this.LoopDuration != 0.0);
			this.IsInfiniteLoop = (infinite || this.LoopDuration < 0.0 || this.RepeatTimes < 0);
		}

		// Token: 0x06030A59 RID: 199257 RVA: 0x00BFC998 File Offset: 0x00BFAB98
		public void CalculatePlayTime(double onceTime)
		{
			this.OncePlayTime = onceTime;
			this.PlayMontageTime = ((this.LoopDuration != 0.0 && this.LoopDuration > 0.0) ? (this.LoopDuration * 1000.0) : ((this.RepeatTimes != 0 && this.RepeatTimes > 0) ? ((double)this.RepeatTimes * onceTime) : onceTime));
			if (!this.IsInfiniteLoop)
			{
				if (this.PlayMontageTime < 20.0)
				{
					this.PlayMontageTime = Math.Max(onceTime, 20.0);
				}
				if (this.PlayMontageTime > 180000.0)
				{
					this.IsInfiniteLoop = true;
				}
			}
		}

		// Token: 0x0401BF55 RID: 114517
		private const int SECOND_TO_MILLISECOND = 1000;

		// Token: 0x0401BF56 RID: 114518
		public double PlayMontageTime;

		// Token: 0x0401BF57 RID: 114519
		public double OncePlayTime;

		// Token: 0x0401BF58 RID: 114520
		public bool IsInfiniteLoop;

		// Token: 0x0401BF59 RID: 114521
		public bool IsPlayLoop;

		// Token: 0x0401BF5A RID: 114522
		private readonly double LoopDuration;

		// Token: 0x0401BF5B RID: 114523
		private readonly int RepeatTimes;
	}
}
