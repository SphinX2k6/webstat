using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200637C RID: 25468
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedRewardCellPanelData : ISolarSpeedRewardCellPanelData
	{
		// Token: 0x17009D1A RID: 40218
		// (get) Token: 0x0603FF47 RID: 261959 RVA: 0x010668A2 File Offset: 0x01064AA2
		// (set) Token: 0x0603FF48 RID: 261960 RVA: 0x010668AA File Offset: 0x01064AAA
		public int RewardId { get; set; }

		// Token: 0x17009D1B RID: 40219
		// (get) Token: 0x0603FF49 RID: 261961 RVA: 0x010668B3 File Offset: 0x01064AB3
		// (set) Token: 0x0603FF4A RID: 261962 RVA: 0x010668BB File Offset: 0x01064ABB
		public string TitleTextId { get; set; }

		// Token: 0x17009D1C RID: 40220
		// (get) Token: 0x0603FF4B RID: 261963 RVA: 0x010668C4 File Offset: 0x01064AC4
		// (set) Token: 0x0603FF4C RID: 261964 RVA: 0x010668CC File Offset: 0x01064ACC
		public string ProgressTextId { get; set; }

		// Token: 0x17009D1D RID: 40221
		// (get) Token: 0x0603FF4D RID: 261965 RVA: 0x010668D5 File Offset: 0x01064AD5
		// (set) Token: 0x0603FF4E RID: 261966 RVA: 0x010668DD File Offset: 0x01064ADD
		public string[] ProgressTextArgs { get; set; }

		// Token: 0x17009D1E RID: 40222
		// (get) Token: 0x0603FF4F RID: 261967 RVA: 0x010668E6 File Offset: 0x01064AE6
		// (set) Token: 0x0603FF50 RID: 261968 RVA: 0x010668EE File Offset: 0x01064AEE
		public TItem[] ItemsData { get; set; }

		// Token: 0x17009D1F RID: 40223
		// (get) Token: 0x0603FF51 RID: 261969 RVA: 0x010668F7 File Offset: 0x01064AF7
		// (set) Token: 0x0603FF52 RID: 261970 RVA: 0x010668FF File Offset: 0x01064AFF
		public string ButtonTextId { get; set; }

		// Token: 0x17009D20 RID: 40224
		// (get) Token: 0x0603FF53 RID: 261971 RVA: 0x01066908 File Offset: 0x01064B08
		// (set) Token: 0x0603FF54 RID: 261972 RVA: 0x01066910 File Offset: 0x01064B10
		public bool ButtonActive { get; set; }

		// Token: 0x17009D21 RID: 40225
		// (get) Token: 0x0603FF55 RID: 261973 RVA: 0x01066919 File Offset: 0x01064B19
		// (set) Token: 0x0603FF56 RID: 261974 RVA: 0x01066921 File Offset: 0x01064B21
		public bool RightActive { get; set; }

		// Token: 0x17009D22 RID: 40226
		// (get) Token: 0x0603FF57 RID: 261975 RVA: 0x0106692A File Offset: 0x01064B2A
		// (set) Token: 0x0603FF58 RID: 261976 RVA: 0x01066932 File Offset: 0x01064B32
		public bool DoneSpriteActive { get; set; }
	}
}
