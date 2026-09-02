using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200637E RID: 25470
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedResultViewData : ISolarSpeedResultViewData
	{
		// Token: 0x17009D27 RID: 40231
		// (get) Token: 0x0603FF62 RID: 261986 RVA: 0x01066943 File Offset: 0x01064B43
		// (set) Token: 0x0603FF63 RID: 261987 RVA: 0x0106694B File Offset: 0x01064B4B
		[Nullable(2)]
		public string TitleId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009D28 RID: 40232
		// (get) Token: 0x0603FF64 RID: 261988 RVA: 0x01066954 File Offset: 0x01064B54
		// (set) Token: 0x0603FF65 RID: 261989 RVA: 0x0106695C File Offset: 0x01064B5C
		public List<ISolarSpeedRolePanelData> RoleDataList { get; set; }

		// Token: 0x17009D29 RID: 40233
		// (get) Token: 0x0603FF66 RID: 261990 RVA: 0x01066965 File Offset: 0x01064B65
		// (set) Token: 0x0603FF67 RID: 261991 RVA: 0x0106696D File Offset: 0x01064B6D
		public Func<SolarSpeedRolePanelBase> PanelType { get; set; }

		// Token: 0x17009D2A RID: 40234
		// (get) Token: 0x0603FF68 RID: 261992 RVA: 0x01066976 File Offset: 0x01064B76
		// (set) Token: 0x0603FF69 RID: 261993 RVA: 0x0106697E File Offset: 0x01064B7E
		public Action ConfirmClick { get; set; }
	}
}
