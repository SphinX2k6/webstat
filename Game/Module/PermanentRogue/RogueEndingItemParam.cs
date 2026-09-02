using System;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200565C RID: 22108
	public class RogueEndingItemParam : IRogueEndingItemParam
	{
		// Token: 0x17009096 RID: 37014
		// (get) Token: 0x060385E0 RID: 230880 RVA: 0x00E45B13 File Offset: 0x00E43D13
		// (set) Token: 0x060385E1 RID: 230881 RVA: 0x00E45B1B File Offset: 0x00E43D1B
		public int ConfigId { get; set; }

		// Token: 0x17009097 RID: 37015
		// (get) Token: 0x060385E2 RID: 230882 RVA: 0x00E45B24 File Offset: 0x00E43D24
		// (set) Token: 0x060385E3 RID: 230883 RVA: 0x00E45B2C File Offset: 0x00E43D2C
		public int Index { get; set; }

		// Token: 0x17009098 RID: 37016
		// (get) Token: 0x060385E4 RID: 230884 RVA: 0x00E45B35 File Offset: 0x00E43D35
		// (set) Token: 0x060385E5 RID: 230885 RVA: 0x00E45B3D File Offset: 0x00E43D3D
		public float? Rotation { get; set; }

		// Token: 0x17009099 RID: 37017
		// (get) Token: 0x060385E6 RID: 230886 RVA: 0x00E45B46 File Offset: 0x00E43D46
		// (set) Token: 0x060385E7 RID: 230887 RVA: 0x00E45B4E File Offset: 0x00E43D4E
		public bool IsSubView { get; set; }

		// Token: 0x1700909A RID: 37018
		// (get) Token: 0x060385E8 RID: 230888 RVA: 0x00E45B57 File Offset: 0x00E43D57
		// (set) Token: 0x060385E9 RID: 230889 RVA: 0x00E45B5F File Offset: 0x00E43D5F
		public bool IsUnlock { get; set; }
	}
}
