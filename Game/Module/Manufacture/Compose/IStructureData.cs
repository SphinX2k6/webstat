using System;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059BF RID: 22975
	public class IStructureData : IBaseItemData
	{
		// Token: 0x170094A1 RID: 38049
		// (get) Token: 0x0603A307 RID: 238343 RVA: 0x00EBC1A1 File Offset: 0x00EBA3A1
		// (set) Token: 0x0603A308 RID: 238344 RVA: 0x00EBC1A9 File Offset: 0x00EBA3A9
		public ESubStructureDataType SubType { get; set; }

		// Token: 0x170094A2 RID: 38050
		// (get) Token: 0x0603A309 RID: 238345 RVA: 0x00EBC1B2 File Offset: 0x00EBA3B2
		// (set) Token: 0x0603A30A RID: 238346 RVA: 0x00EBC1BA File Offset: 0x00EBA3BA
		public int StructureCount { get; set; }

		// Token: 0x170094A3 RID: 38051
		// (get) Token: 0x0603A30B RID: 238347 RVA: 0x00EBC1C3 File Offset: 0x00EBA3C3
		// (set) Token: 0x0603A30C RID: 238348 RVA: 0x00EBC1CB File Offset: 0x00EBA3CB
		public int LastRoleId { get; set; }
	}
}
