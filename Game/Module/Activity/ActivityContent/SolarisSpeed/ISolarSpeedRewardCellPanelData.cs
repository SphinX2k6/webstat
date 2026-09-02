using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200637B RID: 25467
	[NullableContext(1)]
	public interface ISolarSpeedRewardCellPanelData
	{
		// Token: 0x17009D11 RID: 40209
		// (get) Token: 0x0603FF35 RID: 261941
		// (set) Token: 0x0603FF36 RID: 261942
		int RewardId { get; set; }

		// Token: 0x17009D12 RID: 40210
		// (get) Token: 0x0603FF37 RID: 261943
		// (set) Token: 0x0603FF38 RID: 261944
		string TitleTextId { get; set; }

		// Token: 0x17009D13 RID: 40211
		// (get) Token: 0x0603FF39 RID: 261945
		// (set) Token: 0x0603FF3A RID: 261946
		string ProgressTextId { get; set; }

		// Token: 0x17009D14 RID: 40212
		// (get) Token: 0x0603FF3B RID: 261947
		// (set) Token: 0x0603FF3C RID: 261948
		string[] ProgressTextArgs { get; set; }

		// Token: 0x17009D15 RID: 40213
		// (get) Token: 0x0603FF3D RID: 261949
		// (set) Token: 0x0603FF3E RID: 261950
		TItem[] ItemsData { get; set; }

		// Token: 0x17009D16 RID: 40214
		// (get) Token: 0x0603FF3F RID: 261951
		// (set) Token: 0x0603FF40 RID: 261952
		string ButtonTextId { get; set; }

		// Token: 0x17009D17 RID: 40215
		// (get) Token: 0x0603FF41 RID: 261953
		// (set) Token: 0x0603FF42 RID: 261954
		bool ButtonActive { get; set; }

		// Token: 0x17009D18 RID: 40216
		// (get) Token: 0x0603FF43 RID: 261955
		// (set) Token: 0x0603FF44 RID: 261956
		bool RightActive { get; set; }

		// Token: 0x17009D19 RID: 40217
		// (get) Token: 0x0603FF45 RID: 261957
		// (set) Token: 0x0603FF46 RID: 261958
		bool DoneSpriteActive { get; set; }
	}
}
