using System;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059BE RID: 22974
	public class IReagentProductionData : IBaseItemData
	{
		// Token: 0x1700949C RID: 38044
		// (get) Token: 0x0603A2FC RID: 238332 RVA: 0x00EBC144 File Offset: 0x00EBA344
		// (set) Token: 0x0603A2FD RID: 238333 RVA: 0x00EBC14C File Offset: 0x00EBA34C
		public ESubComposeDataType SubType { get; set; }

		// Token: 0x1700949D RID: 38045
		// (get) Token: 0x0603A2FE RID: 238334 RVA: 0x00EBC155 File Offset: 0x00EBA355
		// (set) Token: 0x0603A2FF RID: 238335 RVA: 0x00EBC15D File Offset: 0x00EBA35D
		public int UniqueId { get; set; }

		// Token: 0x1700949E RID: 38046
		// (get) Token: 0x0603A300 RID: 238336 RVA: 0x00EBC166 File Offset: 0x00EBA366
		// (set) Token: 0x0603A301 RID: 238337 RVA: 0x00EBC16E File Offset: 0x00EBA36E
		public int ComposeCount { get; set; }

		// Token: 0x1700949F RID: 38047
		// (get) Token: 0x0603A302 RID: 238338 RVA: 0x00EBC177 File Offset: 0x00EBA377
		// (set) Token: 0x0603A303 RID: 238339 RVA: 0x00EBC17F File Offset: 0x00EBA37F
		public int LastRoleId { get; set; }

		// Token: 0x170094A0 RID: 38048
		// (get) Token: 0x0603A304 RID: 238340 RVA: 0x00EBC188 File Offset: 0x00EBA388
		// (set) Token: 0x0603A305 RID: 238341 RVA: 0x00EBC190 File Offset: 0x00EBA390
		public int EffectType { get; set; }
	}
}
