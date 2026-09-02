using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006377 RID: 25463
	[NullableContext(1)]
	public interface ISolarSpeedRewardPanelData
	{
		// Token: 0x17009D03 RID: 40195
		// (get) Token: 0x0603FF17 RID: 261911
		// (set) Token: 0x0603FF18 RID: 261912
		List<ISolarSpeedTabCellPanelData> TabDataList { get; set; }

		// Token: 0x17009D04 RID: 40196
		// (get) Token: 0x0603FF19 RID: 261913
		// (set) Token: 0x0603FF1A RID: 261914
		List<ISolarSpeedRewardCellPanelData> RewardDataList { get; set; }
	}
}
