using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FF2 RID: 24562
	public class FallDownPercentMachine
	{
		// Token: 0x0603DD95 RID: 253333 RVA: 0x00FC489C File Offset: 0x00FC2A9C
		public void SetTargetPercent(float percent)
		{
			if (percent == this.TargetPercent)
			{
				return;
			}
			if (percent > this.TargetPercent && percent < 1f)
			{
				this.TargetPercent = percent;
				this.Speed = (percent - this.CurPercent) / 100f;
				return;
			}
			this.TargetPercent = percent;
			this.CurPercent = percent;
			this.Speed = 0f;
		}

		// Token: 0x0603DD96 RID: 253334 RVA: 0x00FC48FC File Offset: 0x00FC2AFC
		public bool Update(float delta)
		{
			if (this.Speed == 0f)
			{
				return false;
			}
			this.CurPercent += this.Speed * delta;
			if (this.CurPercent >= this.TargetPercent)
			{
				this.CurPercent = this.TargetPercent;
				this.Speed = 0f;
			}
			return true;
		}

		// Token: 0x0603DD97 RID: 253335 RVA: 0x00FC4953 File Offset: 0x00FC2B53
		public float GetCurPercent()
		{
			return this.CurPercent;
		}

		// Token: 0x04022B02 RID: 142082
		private const float DURATION = 100f;

		// Token: 0x04022B03 RID: 142083
		private float TargetPercent;

		// Token: 0x04022B04 RID: 142084
		private float CurPercent;

		// Token: 0x04022B05 RID: 142085
		private float Speed;
	}
}
