using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200638A RID: 25482
	[NullableContext(1)]
	[Nullable(0)]
	public class AbyssRolePanelData : SolarSpeedRolePanelData, IAbyssRolePanelData, ISolarSpeedRolePanelData
	{
		// Token: 0x17009D5F RID: 40287
		// (get) Token: 0x0603FFD8 RID: 262104 RVA: 0x01066B3E File Offset: 0x01064D3E
		// (set) Token: 0x0603FFD9 RID: 262105 RVA: 0x01066B46 File Offset: 0x01064D46
		public List<IAbyssDescData> MainDescData { get; set; }

		// Token: 0x17009D60 RID: 40288
		// (get) Token: 0x0603FFDA RID: 262106 RVA: 0x01066B4F File Offset: 0x01064D4F
		// (set) Token: 0x0603FFDB RID: 262107 RVA: 0x01066B57 File Offset: 0x01064D57
		public List<IAbyssDescData> SubDescData { get; set; }

		// Token: 0x17009D61 RID: 40289
		// (get) Token: 0x0603FFDC RID: 262108 RVA: 0x01066B60 File Offset: 0x01064D60
		// (set) Token: 0x0603FFDD RID: 262109 RVA: 0x01066B68 File Offset: 0x01064D68
		public int LikeCount { get; set; }

		// Token: 0x17009D62 RID: 40290
		// (get) Token: 0x0603FFDE RID: 262110 RVA: 0x01066B71 File Offset: 0x01064D71
		// (set) Token: 0x0603FFDF RID: 262111 RVA: 0x01066B79 File Offset: 0x01064D79
		public int? PlayerTitle { get; set; }

		// Token: 0x17009D63 RID: 40291
		// (get) Token: 0x0603FFE0 RID: 262112 RVA: 0x01066B82 File Offset: 0x01064D82
		// (set) Token: 0x0603FFE1 RID: 262113 RVA: 0x01066B8A File Offset: 0x01064D8A
		public int? PlayerTitleStarLevel { get; set; }

		// Token: 0x17009D64 RID: 40292
		// (get) Token: 0x0603FFE2 RID: 262114 RVA: 0x01066B93 File Offset: 0x01064D93
		// (set) Token: 0x0603FFE3 RID: 262115 RVA: 0x01066B9B File Offset: 0x01064D9B
		public int Sex { get; set; }
	}
}
