using System;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F92 RID: 24466
	public class AlertAreaUpdateMachine
	{
		// Token: 0x0603D6C7 RID: 251591 RVA: 0x00FA0ADE File Offset: 0x00F9ECDE
		public void Init(float percent)
		{
			this.BarCurPercent = percent;
			this.BarTargetPercent = percent;
		}

		// Token: 0x0603D6C8 RID: 251592 RVA: 0x00FA0AEE File Offset: 0x00F9ECEE
		public bool Update(float delta)
		{
			return this.UpdateBarData(delta);
		}

		// Token: 0x0603D6C9 RID: 251593 RVA: 0x00FA0AF8 File Offset: 0x00F9ECF8
		public void ChangeTargetPercent(float newTargetPercent)
		{
			if (newTargetPercent == this.BarTargetPercent)
			{
				return;
			}
			if (newTargetPercent > this.BarTargetPercent)
			{
				this.BarCurPercent = Math.Min(this.BarCurPercent, this.BarTargetPercent);
			}
			else
			{
				this.BarCurPercent = Math.Max(this.BarCurPercent, this.BarTargetPercent);
			}
			this.BarTargetPercent = newTargetPercent;
			this.BarProgressSpeed = (newTargetPercent - this.BarCurPercent) / 500f;
			this.ProgressDir = Math.Sign(this.BarProgressSpeed);
		}

		// Token: 0x0603D6CA RID: 251594 RVA: 0x00FA0B74 File Offset: 0x00F9ED74
		private bool UpdateBarData(float delta)
		{
			if (this.BarProgressSpeed == 0f)
			{
				return false;
			}
			this.BarCurPercent += this.BarProgressSpeed * delta;
			if ((this.BarProgressSpeed > 0f && this.BarCurPercent >= this.BarTargetPercent) || (this.BarProgressSpeed < 0f && this.BarCurPercent <= this.BarTargetPercent))
			{
				this.BarCurPercent = this.BarTargetPercent;
				this.BarProgressSpeed = 0f;
			}
			return true;
		}

		// Token: 0x0603D6CB RID: 251595 RVA: 0x00FA0BF3 File Offset: 0x00F9EDF3
		public float GetBarCurPercent()
		{
			return this.BarCurPercent;
		}

		// Token: 0x0603D6CC RID: 251596 RVA: 0x00FA0BFB File Offset: 0x00F9EDFB
		public float GetBarTargetPercent()
		{
			return this.BarTargetPercent;
		}

		// Token: 0x0603D6CD RID: 251597 RVA: 0x00FA0C03 File Offset: 0x00F9EE03
		public int GetProgressDir()
		{
			return this.ProgressDir;
		}

		// Token: 0x04022842 RID: 141378
		private const int BAR_ANI_DURATION = 500;

		// Token: 0x04022843 RID: 141379
		private float BarTargetPercent;

		// Token: 0x04022844 RID: 141380
		private float BarCurPercent;

		// Token: 0x04022845 RID: 141381
		private float BarProgressSpeed;

		// Token: 0x04022846 RID: 141382
		private int ProgressDir;
	}
}
