using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200637D RID: 25469
	[NullableContext(1)]
	public interface ISolarSpeedResultViewData
	{
		// Token: 0x17009D23 RID: 40227
		// (get) Token: 0x0603FF5A RID: 261978
		// (set) Token: 0x0603FF5B RID: 261979
		[Nullable(2)]
		string TitleId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009D24 RID: 40228
		// (get) Token: 0x0603FF5C RID: 261980
		// (set) Token: 0x0603FF5D RID: 261981
		List<ISolarSpeedRolePanelData> RoleDataList { get; set; }

		// Token: 0x17009D25 RID: 40229
		// (get) Token: 0x0603FF5E RID: 261982
		// (set) Token: 0x0603FF5F RID: 261983
		Func<SolarSpeedRolePanelBase> PanelType { get; set; }

		// Token: 0x17009D26 RID: 40230
		// (get) Token: 0x0603FF60 RID: 261984
		// (set) Token: 0x0603FF61 RID: 261985
		Action ConfirmClick { get; set; }
	}
}
