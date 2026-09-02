using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006086 RID: 24710
	public class MotorcycleShieldPercentMachine
	{
		// Token: 0x0603E55B RID: 255323 RVA: 0x00FEB3C0 File Offset: 0x00FE95C0
		public void Init(float percent)
		{
			this.CurPercent = percent;
			this.TargetPercent = percent;
			this.Speed = 0f;
		}

		// Token: 0x0603E55C RID: 255324 RVA: 0x00FEB3DB File Offset: 0x00FE95DB
		public void SetTargetPercent(float percent)
		{
			if (percent == this.TargetPercent)
			{
				return;
			}
			this.TargetPercent = percent;
			this.Speed = (percent - this.CurPercent) / (float)this.Duration;
		}

		// Token: 0x0603E55D RID: 255325 RVA: 0x00FEB404 File Offset: 0x00FE9604
		public bool Update(float delta)
		{
			if (this.Speed == 0f)
			{
				return false;
			}
			if (this.Speed > 0f)
			{
				this.CurPercent += this.Speed * delta;
				if (this.CurPercent >= this.TargetPercent)
				{
					this.CurPercent = this.TargetPercent;
					this.Speed = 0f;
				}
			}
			else
			{
				this.CurPercent += this.Speed * delta;
				if (this.CurPercent <= this.TargetPercent)
				{
					this.CurPercent = this.TargetPercent;
					this.Speed = 0f;
				}
			}
			return true;
		}

		// Token: 0x0603E55E RID: 255326 RVA: 0x00FEB4A4 File Offset: 0x00FE96A4
		public float GetCurPercent()
		{
			return this.CurPercent;
		}

		// Token: 0x0603E55F RID: 255327 RVA: 0x00FEB4AC File Offset: 0x00FE96AC
		public float GetTargetPercent()
		{
			return this.TargetPercent;
		}

		// Token: 0x0603E560 RID: 255328 RVA: 0x00FEB4B4 File Offset: 0x00FE96B4
		public bool IsDecreasing()
		{
			return this.Speed < 0f;
		}

		// Token: 0x04022F0C RID: 143116
		private const int DURATION = 100;

		// Token: 0x04022F0D RID: 143117
		private float TargetPercent;

		// Token: 0x04022F0E RID: 143118
		private float CurPercent;

		// Token: 0x04022F0F RID: 143119
		private float Speed;

		// Token: 0x04022F10 RID: 143120
		public int Duration = 100;
	}
}
