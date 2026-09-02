using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006084 RID: 24708
	public class MotorcyclePercentMachine
	{
		// Token: 0x0603E546 RID: 255302 RVA: 0x00FEAF49 File Offset: 0x00FE9149
		public void Init(float percent, float? duration = null)
		{
			this.CurPercent = percent;
			this.TargetPercent = percent;
			if (duration != null)
			{
				this.Duration = duration.Value;
				this.Speed = 0f;
			}
		}

		// Token: 0x0603E547 RID: 255303 RVA: 0x00FEAF7A File Offset: 0x00FE917A
		public void SetTargetPercent(float percent)
		{
			if (percent == this.TargetPercent)
			{
				return;
			}
			this.TargetPercent = percent;
			this.Speed = (percent - this.CurPercent) / this.Duration;
		}

		// Token: 0x0603E548 RID: 255304 RVA: 0x00FEAFA4 File Offset: 0x00FE91A4
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

		// Token: 0x0603E549 RID: 255305 RVA: 0x00FEB044 File Offset: 0x00FE9244
		public float GetCurPercent()
		{
			return this.CurPercent;
		}

		// Token: 0x0603E54A RID: 255306 RVA: 0x00FEB04C File Offset: 0x00FE924C
		public float GetTargetPercent()
		{
			return this.TargetPercent;
		}

		// Token: 0x04022EFF RID: 143103
		private const int DURATION = 100;

		// Token: 0x04022F00 RID: 143104
		private float TargetPercent;

		// Token: 0x04022F01 RID: 143105
		private float CurPercent;

		// Token: 0x04022F02 RID: 143106
		private float Speed;

		// Token: 0x04022F03 RID: 143107
		public float Duration = 100f;
	}
}
