using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061F8 RID: 25080
	public interface IBossInfo
	{
		// Token: 0x17009B59 RID: 39769
		// (get) Token: 0x0603F4A6 RID: 259238
		// (set) Token: 0x0603F4A7 RID: 259239
		int WaveConfigId { get; set; }

		// Token: 0x17009B5A RID: 39770
		// (get) Token: 0x0603F4A8 RID: 259240
		// (set) Token: 0x0603F4A9 RID: 259241
		int Round { get; set; }

		// Token: 0x17009B5B RID: 39771
		// (get) Token: 0x0603F4AA RID: 259242
		// (set) Token: 0x0603F4AB RID: 259243
		double HpPercentage { get; set; }

		// Token: 0x17009B5C RID: 39772
		// (get) Token: 0x0603F4AC RID: 259244
		// (set) Token: 0x0603F4AD RID: 259245
		double? LoseHpPercentage { get; set; }
	}
}
