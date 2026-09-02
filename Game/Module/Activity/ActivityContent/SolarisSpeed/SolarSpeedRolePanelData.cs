using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006380 RID: 25472
	[NullableContext(2)]
	[Nullable(0)]
	public class SolarSpeedRolePanelData : ISolarSpeedRolePanelData
	{
		// Token: 0x17009D3B RID: 40251
		// (get) Token: 0x0603FF8B RID: 262027 RVA: 0x0106698F File Offset: 0x01064B8F
		// (set) Token: 0x0603FF8C RID: 262028 RVA: 0x01066997 File Offset: 0x01064B97
		public int Rank { get; set; }

		// Token: 0x17009D3C RID: 40252
		// (get) Token: 0x0603FF8D RID: 262029 RVA: 0x010669A0 File Offset: 0x01064BA0
		// (set) Token: 0x0603FF8E RID: 262030 RVA: 0x010669A8 File Offset: 0x01064BA8
		public int PlayerId { get; set; }

		// Token: 0x17009D3D RID: 40253
		// (get) Token: 0x0603FF8F RID: 262031 RVA: 0x010669B1 File Offset: 0x01064BB1
		// (set) Token: 0x0603FF90 RID: 262032 RVA: 0x010669B9 File Offset: 0x01064BB9
		public bool IsAddButtonAvailable { get; set; }

		// Token: 0x17009D3E RID: 40254
		// (get) Token: 0x0603FF91 RID: 262033 RVA: 0x010669C2 File Offset: 0x01064BC2
		// (set) Token: 0x0603FF92 RID: 262034 RVA: 0x010669CA File Offset: 0x01064BCA
		public bool IsSelf { get; set; }

		// Token: 0x17009D3F RID: 40255
		// (get) Token: 0x0603FF93 RID: 262035 RVA: 0x010669D3 File Offset: 0x01064BD3
		// (set) Token: 0x0603FF94 RID: 262036 RVA: 0x010669DB File Offset: 0x01064BDB
		[Nullable(1)]
		public string BgPath { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D40 RID: 40256
		// (get) Token: 0x0603FF95 RID: 262037 RVA: 0x010669E4 File Offset: 0x01064BE4
		// (set) Token: 0x0603FF96 RID: 262038 RVA: 0x010669EC File Offset: 0x01064BEC
		public string MedalTexturePath { get; set; }

		// Token: 0x17009D41 RID: 40257
		// (get) Token: 0x0603FF97 RID: 262039 RVA: 0x010669F5 File Offset: 0x01064BF5
		// (set) Token: 0x0603FF98 RID: 262040 RVA: 0x010669FD File Offset: 0x01064BFD
		[Nullable(1)]
		public string MedalColorHex { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D42 RID: 40258
		// (get) Token: 0x0603FF99 RID: 262041 RVA: 0x01066A06 File Offset: 0x01064C06
		// (set) Token: 0x0603FF9A RID: 262042 RVA: 0x01066A0E File Offset: 0x01064C0E
		[Nullable(1)]
		public string FxColorHex { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D43 RID: 40259
		// (get) Token: 0x0603FF9B RID: 262043 RVA: 0x01066A17 File Offset: 0x01064C17
		// (set) Token: 0x0603FF9C RID: 262044 RVA: 0x01066A1F File Offset: 0x01064C1F
		public string PlayerIndexIconPath { get; set; }

		// Token: 0x17009D44 RID: 40260
		// (get) Token: 0x0603FF9D RID: 262045 RVA: 0x01066A28 File Offset: 0x01064C28
		// (set) Token: 0x0603FF9E RID: 262046 RVA: 0x01066A30 File Offset: 0x01064C30
		[Nullable(1)]
		public string NameText { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D45 RID: 40261
		// (get) Token: 0x0603FF9F RID: 262047 RVA: 0x01066A39 File Offset: 0x01064C39
		// (set) Token: 0x0603FFA0 RID: 262048 RVA: 0x01066A41 File Offset: 0x01064C41
		public string DescTextId { get; set; }

		// Token: 0x17009D46 RID: 40262
		// (get) Token: 0x0603FFA1 RID: 262049 RVA: 0x01066A4A File Offset: 0x01064C4A
		// (set) Token: 0x0603FFA2 RID: 262050 RVA: 0x01066A52 File Offset: 0x01064C52
		public string TitleTextId { get; set; }

		// Token: 0x17009D47 RID: 40263
		// (get) Token: 0x0603FFA3 RID: 262051 RVA: 0x01066A5B File Offset: 0x01064C5B
		// (set) Token: 0x0603FFA4 RID: 262052 RVA: 0x01066A63 File Offset: 0x01064C63
		[Nullable(1)]
		public ISolarSpeedRoleIconPanelData IconData { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009D48 RID: 40264
		// (get) Token: 0x0603FFA5 RID: 262053 RVA: 0x01066A6C File Offset: 0x01064C6C
		// (set) Token: 0x0603FFA6 RID: 262054 RVA: 0x01066A74 File Offset: 0x01064C74
		public string AvatarTexturePath { get; set; }

		// Token: 0x17009D49 RID: 40265
		// (get) Token: 0x0603FFA7 RID: 262055 RVA: 0x01066A7D File Offset: 0x01064C7D
		// (set) Token: 0x0603FFA8 RID: 262056 RVA: 0x01066A85 File Offset: 0x01064C85
		public string LineTexturePath { get; set; }

		// Token: 0x17009D4A RID: 40266
		// (get) Token: 0x0603FFA9 RID: 262057 RVA: 0x01066A8E File Offset: 0x01064C8E
		// (set) Token: 0x0603FFAA RID: 262058 RVA: 0x01066A96 File Offset: 0x01064C96
		public string BgTexturePath { get; set; }
	}
}
