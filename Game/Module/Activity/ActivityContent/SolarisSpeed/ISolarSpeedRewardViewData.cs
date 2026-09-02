using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006375 RID: 25461
	[NullableContext(1)]
	public interface ISolarSpeedRewardViewData
	{
		// Token: 0x17009CFB RID: 40187
		// (get) Token: 0x0603FF06 RID: 261894
		// (set) Token: 0x0603FF07 RID: 261895
		string TitleTextId { get; set; }

		// Token: 0x17009CFC RID: 40188
		// (get) Token: 0x0603FF08 RID: 261896
		// (set) Token: 0x0603FF09 RID: 261897
		string TitleIconPath { get; set; }

		// Token: 0x17009CFD RID: 40189
		// (get) Token: 0x0603FF0A RID: 261898
		// (set) Token: 0x0603FF0B RID: 261899
		string Score { get; set; }

		// Token: 0x17009CFE RID: 40190
		// (get) Token: 0x0603FF0C RID: 261900
		// (set) Token: 0x0603FF0D RID: 261901
		ISolarSpeedRewardPanelData RewardPanelData { get; set; }
	}
}
