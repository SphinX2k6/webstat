using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006378 RID: 25464
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedRewardPanelData : ISolarSpeedRewardPanelData
	{
		// Token: 0x17009D05 RID: 40197
		// (get) Token: 0x0603FF1B RID: 261915 RVA: 0x0106681B File Offset: 0x01064A1B
		// (set) Token: 0x0603FF1C RID: 261916 RVA: 0x01066823 File Offset: 0x01064A23
		public List<ISolarSpeedTabCellPanelData> TabDataList { get; set; }

		// Token: 0x17009D06 RID: 40198
		// (get) Token: 0x0603FF1D RID: 261917 RVA: 0x0106682C File Offset: 0x01064A2C
		// (set) Token: 0x0603FF1E RID: 261918 RVA: 0x01066834 File Offset: 0x01064A34
		public List<ISolarSpeedRewardCellPanelData> RewardDataList { get; set; }
	}
}
