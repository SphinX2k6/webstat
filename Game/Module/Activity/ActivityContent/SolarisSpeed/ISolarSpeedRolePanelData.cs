using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200637F RID: 25471
	[NullableContext(2)]
	public interface ISolarSpeedRolePanelData
	{
		// Token: 0x17009D2B RID: 40235
		// (get) Token: 0x0603FF6B RID: 261995
		// (set) Token: 0x0603FF6C RID: 261996
		int Rank { get; set; }

		// Token: 0x17009D2C RID: 40236
		// (get) Token: 0x0603FF6D RID: 261997
		// (set) Token: 0x0603FF6E RID: 261998
		int PlayerId { get; set; }

		// Token: 0x17009D2D RID: 40237
		// (get) Token: 0x0603FF6F RID: 261999
		// (set) Token: 0x0603FF70 RID: 262000
		bool IsAddButtonAvailable { get; set; }

		// Token: 0x17009D2E RID: 40238
		// (get) Token: 0x0603FF71 RID: 262001
		// (set) Token: 0x0603FF72 RID: 262002
		bool IsSelf { get; set; }

		// Token: 0x17009D2F RID: 40239
		// (get) Token: 0x0603FF73 RID: 262003
		// (set) Token: 0x0603FF74 RID: 262004
		[Nullable(1)]
		string BgPath { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D30 RID: 40240
		// (get) Token: 0x0603FF75 RID: 262005
		// (set) Token: 0x0603FF76 RID: 262006
		string MedalTexturePath { get; set; }

		// Token: 0x17009D31 RID: 40241
		// (get) Token: 0x0603FF77 RID: 262007
		// (set) Token: 0x0603FF78 RID: 262008
		[Nullable(1)]
		string MedalColorHex { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D32 RID: 40242
		// (get) Token: 0x0603FF79 RID: 262009
		// (set) Token: 0x0603FF7A RID: 262010
		[Nullable(1)]
		string FxColorHex { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D33 RID: 40243
		// (get) Token: 0x0603FF7B RID: 262011
		// (set) Token: 0x0603FF7C RID: 262012
		string PlayerIndexIconPath { get; set; }

		// Token: 0x17009D34 RID: 40244
		// (get) Token: 0x0603FF7D RID: 262013
		// (set) Token: 0x0603FF7E RID: 262014
		[Nullable(1)]
		string NameText { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D35 RID: 40245
		// (get) Token: 0x0603FF7F RID: 262015
		// (set) Token: 0x0603FF80 RID: 262016
		string DescTextId { get; set; }

		// Token: 0x17009D36 RID: 40246
		// (get) Token: 0x0603FF81 RID: 262017
		// (set) Token: 0x0603FF82 RID: 262018
		string TitleTextId { get; set; }

		// Token: 0x17009D37 RID: 40247
		// (get) Token: 0x0603FF83 RID: 262019
		// (set) Token: 0x0603FF84 RID: 262020
		[Nullable(1)]
		ISolarSpeedRoleIconPanelData IconData { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D38 RID: 40248
		// (get) Token: 0x0603FF85 RID: 262021
		// (set) Token: 0x0603FF86 RID: 262022
		string AvatarTexturePath { get; set; }

		// Token: 0x17009D39 RID: 40249
		// (get) Token: 0x0603FF87 RID: 262023
		// (set) Token: 0x0603FF88 RID: 262024
		string LineTexturePath { get; set; }

		// Token: 0x17009D3A RID: 40250
		// (get) Token: 0x0603FF89 RID: 262025
		// (set) Token: 0x0603FF8A RID: 262026
		string BgTexturePath { get; set; }
	}
}
