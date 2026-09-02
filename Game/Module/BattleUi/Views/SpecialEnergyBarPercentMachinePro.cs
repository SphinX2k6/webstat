using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060FD RID: 24829
	public class SpecialEnergyBarPercentMachinePro
	{
		// Token: 0x0603EBB2 RID: 256946 RVA: 0x0100F6D0 File Offset: 0x0100D8D0
		public void SetTargetPercent(float percent)
		{
			if (percent == this.TargetPercent)
			{
				return;
			}
			this.TargetPercent = percent;
			if (this.Duration <= 0f)
			{
				this.CurPercent = this.TargetPercent;
				this.Speed = 0f;
				return;
			}
			this.Speed = (this.TargetPercent - this.CurPercent) / this.Duration;
		}

		// Token: 0x0603EBB3 RID: 256947 RVA: 0x0100F730 File Offset: 0x0100D930
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

		// Token: 0x0603EBB4 RID: 256948 RVA: 0x0100F7BB File Offset: 0x0100D9BB
		public float GetCurPercent()
		{
			return this.CurPercent;
		}

		// Token: 0x040232DE RID: 144094
		public float Duration = 100f;

		// Token: 0x040232DF RID: 144095
		private float TargetPercent;

		// Token: 0x040232E0 RID: 144096
		private float CurPercent;

		// Token: 0x040232E1 RID: 144097
		private float Speed;
	}
}
