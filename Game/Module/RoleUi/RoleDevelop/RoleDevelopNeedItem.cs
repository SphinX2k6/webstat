using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005089 RID: 20617
	public class RoleDevelopNeedItem : IRoleDevelopNeedItem
	{
		// Token: 0x17008BAA RID: 35754
		// (get) Token: 0x06035244 RID: 217668 RVA: 0x00D52E42 File Offset: 0x00D51042
		// (set) Token: 0x06035245 RID: 217669 RVA: 0x00D52E4A File Offset: 0x00D5104A
		public int ItemId { get; set; }

		// Token: 0x17008BAB RID: 35755
		// (get) Token: 0x06035246 RID: 217670 RVA: 0x00D52E53 File Offset: 0x00D51053
		// (set) Token: 0x06035247 RID: 217671 RVA: 0x00D52E5B File Offset: 0x00D5105B
		public int Count { get; set; }

		// Token: 0x17008BAC RID: 35756
		// (get) Token: 0x06035248 RID: 217672 RVA: 0x00D52E64 File Offset: 0x00D51064
		// (set) Token: 0x06035249 RID: 217673 RVA: 0x00D52E6C File Offset: 0x00D5106C
		public EItemMaterialType? Type { get; set; }
	}
}
