using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200507F RID: 20607
	public class RoleDevProsSpecialGachaConfig : IRoleDevProsSpecialGachaConfig
	{
		// Token: 0x06035230 RID: 217648 RVA: 0x00D52DE0 File Offset: 0x00D50FE0
		public RoleDevProsSpecialGachaConfig(int TypeId, int GachaId)
		{
		}

		// Token: 0x17008BA1 RID: 35745
		// (get) Token: 0x06035231 RID: 217649 RVA: 0x00D52DF6 File Offset: 0x00D50FF6
		// (set) Token: 0x06035232 RID: 217650 RVA: 0x00D52DFE File Offset: 0x00D50FFE
		public int TypeId { get; set; } = TypeId;

		// Token: 0x17008BA2 RID: 35746
		// (get) Token: 0x06035233 RID: 217651 RVA: 0x00D52E07 File Offset: 0x00D51007
		// (set) Token: 0x06035234 RID: 217652 RVA: 0x00D52E0F File Offset: 0x00D5100F
		public int GachaId { get; set; } = GachaId;
	}
}
