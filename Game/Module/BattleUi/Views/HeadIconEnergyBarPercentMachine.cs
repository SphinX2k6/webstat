using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006020 RID: 24608
	[NullableContext(2)]
	[Nullable(0)]
	public class HeadIconEnergyBarPercentMachine
	{
		// Token: 0x0603E036 RID: 254006 RVA: 0x00FD31B5 File Offset: 0x00FD13B5
		public void SetWaitTimeWhenGrow(float timeInMs)
		{
			this.WaitTimeWhenGrow = timeInMs;
		}

		// Token: 0x0603E037 RID: 254007 RVA: 0x00FD31BE File Offset: 0x00FD13BE
		public void Init(float percent, float waitTimeWhenGrow, float growTime = 100f, Action<float, float> targetPercentChanged = null)
		{
			this.CurPercent = percent;
			this.TargetPercent = percent;
			this.WaitTimeWhenGrow = waitTimeWhenGrow;
			this.GrowTime = growTime;
			this.TargetPercentChanged = targetPercentChanged;
		}

		// Token: 0x0603E038 RID: 254008 RVA: 0x00FD31E4 File Offset: 0x00FD13E4
		public void SetTargetPercent(float percent)
		{
			if (percent == this.TargetPercent)
			{
				return;
			}
			float targetPercent = this.TargetPercent;
			if (percent > this.TargetPercent)
			{
				if (this.CurPercent >= this.TargetPercent)
				{
					this.CountDown = this.WaitTimeWhenGrow;
				}
				this.TargetPercent = percent;
				this.CurPercent = Math.Min(this.CurPercent, percent);
				this.Speed = (percent - this.CurPercent) / this.GrowTime;
				Action<float, float> targetPercentChanged = this.TargetPercentChanged;
				if (targetPercentChanged == null)
				{
					return;
				}
				targetPercentChanged(this.TargetPercent, targetPercent);
				return;
			}
			else
			{
				this.TargetPercent = percent;
				this.CurPercent = percent;
				this.Speed = 0f;
				Action<float, float> targetPercentChanged2 = this.TargetPercentChanged;
				if (targetPercentChanged2 == null)
				{
					return;
				}
				targetPercentChanged2(this.TargetPercent, targetPercent);
				return;
			}
		}

		// Token: 0x0603E039 RID: 254009 RVA: 0x00FD329C File Offset: 0x00FD149C
		public bool Update(float delta)
		{
			if (this.Speed == 0f)
			{
				return false;
			}
			if (this.CountDown > 0f)
			{
				this.CountDown -= delta;
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

		// Token: 0x0603E03A RID: 254010 RVA: 0x00FD3310 File Offset: 0x00FD1510
		public float GetCurPercent()
		{
			return this.CurPercent;
		}

		// Token: 0x0603E03B RID: 254011 RVA: 0x00FD3318 File Offset: 0x00FD1518
		public float GetTargetPercent()
		{
			return this.TargetPercent;
		}

		// Token: 0x04022C60 RID: 142432
		private float TargetPercent;

		// Token: 0x04022C61 RID: 142433
		private float CurPercent;

		// Token: 0x04022C62 RID: 142434
		private float Speed;

		// Token: 0x04022C63 RID: 142435
		private float WaitTimeWhenGrow;

		// Token: 0x04022C64 RID: 142436
		private float GrowTime;

		// Token: 0x04022C65 RID: 142437
		private float CountDown;

		// Token: 0x04022C66 RID: 142438
		private Action<float, float> TargetPercentChanged;
	}
}
