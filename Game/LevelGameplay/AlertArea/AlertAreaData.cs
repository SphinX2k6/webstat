using System;

namespace CSharpScript.Game.LevelGamePlay.AlertArea
{
	// Token: 0x02006F6E RID: 28526
	public class AlertAreaData
	{
		// Token: 0x060450A5 RID: 282789 RVA: 0x011FAAC1 File Offset: 0x011F8CC1
		public AlertAreaData(float MinAlertValue, float MaxAlertValue)
		{
			this.MinAlertValue = MinAlertValue;
			this.MaxAlertValue = MaxAlertValue;
		}

		// Token: 0x0402683F RID: 157759
		public float MinAlertValue;

		// Token: 0x04026840 RID: 157760
		public float MaxAlertValue;

		// Token: 0x04026841 RID: 157761
		public float AlertValue;

		// Token: 0x04026842 RID: 157762
		public bool AlertUiEnabled;

		// Token: 0x04026843 RID: 157763
		public bool AlertUiVisible;
	}
}
