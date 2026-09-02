using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FEF RID: 24559
	internal class ProgressPercentMachine
	{
		// Token: 0x0603DD2D RID: 253229 RVA: 0x00FC1D9E File Offset: 0x00FBFF9E
		public void SetDuration(float duration)
		{
			this.Duration = MathF.Max(duration, 1E-08f);
		}

		// Token: 0x0603DD2E RID: 253230 RVA: 0x00FC1DB1 File Offset: 0x00FBFFB1
		public void SetCurrentPercent(float percent)
		{
			this.CurPercent = percent;
		}

		// Token: 0x0603DD2F RID: 253231 RVA: 0x00FC1DBC File Offset: 0x00FBFFBC
		public void SetTargetPercent(float percent)
		{
			if (percent == this.TargetPercent)
			{
				return;
			}
			if (percent > this.TargetPercent && percent < 1f)
			{
				this.TargetPercent = percent;
				this.Speed = (percent - this.CurPercent) / this.Duration;
				return;
			}
			this.TargetPercent = percent;
			this.CurPercent = percent;
			this.Speed = 0f;
		}

		// Token: 0x0603DD30 RID: 253232 RVA: 0x00FC1E1A File Offset: 0x00FC001A
		public void UpdateSpeed(bool check = false)
		{
			this.Speed = (this.TargetPercent - this.CurPercent) / this.Duration;
			if (check && this.Speed == 0f)
			{
				this.Speed = this.Duration * 0.1f;
			}
		}

		// Token: 0x0603DD31 RID: 253233 RVA: 0x00FC1E58 File Offset: 0x00FC0058
		public bool Update(float delta)
		{
			if (this.Speed == 0f)
			{
				return false;
			}
			this.CurPercent += this.Speed * delta;
			if (this.Speed > 0f)
			{
				if (this.CurPercent >= this.TargetPercent)
				{
					this.CurPercent = this.TargetPercent;
					this.Speed = 0f;
				}
			}
			else if (this.CurPercent <= this.TargetPercent)
			{
				this.CurPercent = this.TargetPercent;
				this.Speed = 0f;
			}
			return true;
		}

		// Token: 0x0603DD32 RID: 253234 RVA: 0x00FC1EE3 File Offset: 0x00FC00E3
		public float GetCurPercent()
		{
			return this.CurPercent;
		}

		// Token: 0x04022ABC RID: 142012
		private float TargetPercent;

		// Token: 0x04022ABD RID: 142013
		private float CurPercent;

		// Token: 0x04022ABE RID: 142014
		private float Speed;

		// Token: 0x04022ABF RID: 142015
		private float Duration = 1f;
	}
}
