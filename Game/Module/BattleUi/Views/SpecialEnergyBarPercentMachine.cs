using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060FC RID: 24828
	public class SpecialEnergyBarPercentMachine
	{
		// Token: 0x0603EBAC RID: 256940 RVA: 0x0100F5E7 File Offset: 0x0100D7E7
		public void Init(float percent)
		{
			this.CurPercent = percent;
			this.TargetPercent = percent;
		}

		// Token: 0x0603EBAD RID: 256941 RVA: 0x0100F5F8 File Offset: 0x0100D7F8
		public void SetTargetPercent(float percent)
		{
			if (percent == this.TargetPercent)
			{
				return;
			}
			if (percent > this.TargetPercent)
			{
				this.TargetPercent = percent;
				this.CurPercent = Math.Min(this.CurPercent, percent);
				this.Speed = (percent - this.CurPercent) / 100f;
				return;
			}
			this.TargetPercent = percent;
			this.CurPercent = percent;
			this.Speed = 0f;
		}

		// Token: 0x0603EBAE RID: 256942 RVA: 0x0100F660 File Offset: 0x0100D860
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

		// Token: 0x0603EBAF RID: 256943 RVA: 0x0100F6B7 File Offset: 0x0100D8B7
		public float GetCurPercent()
		{
			return this.CurPercent;
		}

		// Token: 0x0603EBB0 RID: 256944 RVA: 0x0100F6BF File Offset: 0x0100D8BF
		public float GetTargetPercent()
		{
			return this.TargetPercent;
		}

		// Token: 0x040232DA RID: 144090
		private const int DURATION = 100;

		// Token: 0x040232DB RID: 144091
		private float TargetPercent;

		// Token: 0x040232DC RID: 144092
		private float CurPercent;

		// Token: 0x040232DD RID: 144093
		private float Speed;
	}
}
