using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200507D RID: 20605
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevProsConfig : IRoleDevProsConfig
	{
		// Token: 0x17008B98 RID: 35736
		// (get) Token: 0x0603521D RID: 217629 RVA: 0x00D52D56 File Offset: 0x00D50F56
		// (set) Token: 0x0603521E RID: 217630 RVA: 0x00D52D5E File Offset: 0x00D50F5E
		public int Id { get; set; }

		// Token: 0x17008B99 RID: 35737
		// (get) Token: 0x0603521F RID: 217631 RVA: 0x00D52D67 File Offset: 0x00D50F67
		// (set) Token: 0x06035220 RID: 217632 RVA: 0x00D52D6F File Offset: 0x00D50F6F
		public long ProspectBeginTime { get; set; }

		// Token: 0x17008B9A RID: 35738
		// (get) Token: 0x06035221 RID: 217633 RVA: 0x00D52D78 File Offset: 0x00D50F78
		// (set) Token: 0x06035222 RID: 217634 RVA: 0x00D52D80 File Offset: 0x00D50F80
		public long ProspectEndTime { get; set; }

		// Token: 0x17008B9B RID: 35739
		// (get) Token: 0x06035223 RID: 217635 RVA: 0x00D52D89 File Offset: 0x00D50F89
		// (set) Token: 0x06035224 RID: 217636 RVA: 0x00D52D91 File Offset: 0x00D50F91
		public int TypeId { get; set; }

		// Token: 0x17008B9C RID: 35740
		// (get) Token: 0x06035225 RID: 217637 RVA: 0x00D52D9A File Offset: 0x00D50F9A
		// (set) Token: 0x06035226 RID: 217638 RVA: 0x00D52DA2 File Offset: 0x00D50FA2
		public int GachaId { get; set; }

		// Token: 0x17008B9D RID: 35741
		// (get) Token: 0x06035227 RID: 217639 RVA: 0x00D52DAB File Offset: 0x00D50FAB
		// (set) Token: 0x06035228 RID: 217640 RVA: 0x00D52DB3 File Offset: 0x00D50FB3
		public List<IRoleDevProsSpecialGachaConfig> SpecialGachaId { get; set; } = new List<IRoleDevProsSpecialGachaConfig>();

		// Token: 0x17008B9E RID: 35742
		// (get) Token: 0x06035229 RID: 217641 RVA: 0x00D52DBC File Offset: 0x00D50FBC
		// (set) Token: 0x0603522A RID: 217642 RVA: 0x00D52DC4 File Offset: 0x00D50FC4
		public int SortId { get; set; }
	}
}
