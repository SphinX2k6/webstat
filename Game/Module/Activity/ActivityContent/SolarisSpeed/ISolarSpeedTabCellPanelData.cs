using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006379 RID: 25465
	[NullableContext(2)]
	public interface ISolarSpeedTabCellPanelData
	{
		// Token: 0x17009D07 RID: 40199
		// (get) Token: 0x0603FF20 RID: 261920
		// (set) Token: 0x0603FF21 RID: 261921
		int LevelId { get; set; }

		// Token: 0x17009D08 RID: 40200
		// (get) Token: 0x0603FF22 RID: 261922
		// (set) Token: 0x0603FF23 RID: 261923
		string RomeNumberPath { get; set; }

		// Token: 0x17009D09 RID: 40201
		// (get) Token: 0x0603FF24 RID: 261924
		// (set) Token: 0x0603FF25 RID: 261925
		string TitleTextId { get; set; }

		// Token: 0x17009D0A RID: 40202
		// (get) Token: 0x0603FF26 RID: 261926
		// (set) Token: 0x0603FF27 RID: 261927
		bool IsChosen { get; set; }

		// Token: 0x17009D0B RID: 40203
		// (get) Token: 0x0603FF28 RID: 261928
		// (set) Token: 0x0603FF29 RID: 261929
		bool IsRedDot { get; set; }
	}
}
