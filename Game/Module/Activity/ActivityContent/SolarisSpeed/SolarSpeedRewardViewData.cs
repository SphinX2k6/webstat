using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006376 RID: 25462
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedRewardViewData : ISolarSpeedRewardViewData
	{
		// Token: 0x17009CFF RID: 40191
		// (get) Token: 0x0603FF0E RID: 261902 RVA: 0x010667CF File Offset: 0x010649CF
		// (set) Token: 0x0603FF0F RID: 261903 RVA: 0x010667D7 File Offset: 0x010649D7
		public string TitleTextId { get; set; }

		// Token: 0x17009D00 RID: 40192
		// (get) Token: 0x0603FF10 RID: 261904 RVA: 0x010667E0 File Offset: 0x010649E0
		// (set) Token: 0x0603FF11 RID: 261905 RVA: 0x010667E8 File Offset: 0x010649E8
		public string TitleIconPath { get; set; }

		// Token: 0x17009D01 RID: 40193
		// (get) Token: 0x0603FF12 RID: 261906 RVA: 0x010667F1 File Offset: 0x010649F1
		// (set) Token: 0x0603FF13 RID: 261907 RVA: 0x010667F9 File Offset: 0x010649F9
		public string Score { get; set; }

		// Token: 0x17009D02 RID: 40194
		// (get) Token: 0x0603FF14 RID: 261908 RVA: 0x01066802 File Offset: 0x01064A02
		// (set) Token: 0x0603FF15 RID: 261909 RVA: 0x0106680A File Offset: 0x01064A0A
		public ISolarSpeedRewardPanelData RewardPanelData { get; set; }
	}
}
