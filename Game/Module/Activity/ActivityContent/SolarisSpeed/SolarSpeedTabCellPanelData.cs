using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200637A RID: 25466
	[NullableContext(2)]
	[Nullable(0)]
	public class SolarSpeedTabCellPanelData : ISolarSpeedTabCellPanelData
	{
		// Token: 0x17009D0C RID: 40204
		// (get) Token: 0x0603FF2A RID: 261930 RVA: 0x01066845 File Offset: 0x01064A45
		// (set) Token: 0x0603FF2B RID: 261931 RVA: 0x0106684D File Offset: 0x01064A4D
		public int LevelId { get; set; }

		// Token: 0x17009D0D RID: 40205
		// (get) Token: 0x0603FF2C RID: 261932 RVA: 0x01066856 File Offset: 0x01064A56
		// (set) Token: 0x0603FF2D RID: 261933 RVA: 0x0106685E File Offset: 0x01064A5E
		public string RomeNumberPath { get; set; }

		// Token: 0x17009D0E RID: 40206
		// (get) Token: 0x0603FF2E RID: 261934 RVA: 0x01066867 File Offset: 0x01064A67
		// (set) Token: 0x0603FF2F RID: 261935 RVA: 0x0106686F File Offset: 0x01064A6F
		public string TitleTextId { get; set; }

		// Token: 0x17009D0F RID: 40207
		// (get) Token: 0x0603FF30 RID: 261936 RVA: 0x01066878 File Offset: 0x01064A78
		// (set) Token: 0x0603FF31 RID: 261937 RVA: 0x01066880 File Offset: 0x01064A80
		public bool IsChosen { get; set; }

		// Token: 0x17009D10 RID: 40208
		// (get) Token: 0x0603FF32 RID: 261938 RVA: 0x01066889 File Offset: 0x01064A89
		// (set) Token: 0x0603FF33 RID: 261939 RVA: 0x01066891 File Offset: 0x01064A91
		public bool IsRedDot { get; set; }
	}
}
