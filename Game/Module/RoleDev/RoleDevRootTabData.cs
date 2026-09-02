using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005032 RID: 20530
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevRootTabData : IRoleDevRootTabData
	{
		// Token: 0x17008ADD RID: 35549
		// (get) Token: 0x06034DF7 RID: 216567 RVA: 0x00D46615 File Offset: 0x00D44815
		// (set) Token: 0x06034DF8 RID: 216568 RVA: 0x00D4661D File Offset: 0x00D4481D
		public ERoleDevTabType TabIndex { get; set; }

		// Token: 0x17008ADE RID: 35550
		// (get) Token: 0x06034DF9 RID: 216569 RVA: 0x00D46626 File Offset: 0x00D44826
		// (set) Token: 0x06034DFA RID: 216570 RVA: 0x00D4662E File Offset: 0x00D4482E
		public string TabName { get; set; }

		// Token: 0x17008ADF RID: 35551
		// (get) Token: 0x06034DFB RID: 216571 RVA: 0x00D46637 File Offset: 0x00D44837
		// (set) Token: 0x06034DFC RID: 216572 RVA: 0x00D4663F File Offset: 0x00D4483F
		public bool TabIsUpgrade { get; set; }

		// Token: 0x17008AE0 RID: 35552
		// (get) Token: 0x06034DFD RID: 216573 RVA: 0x00D46648 File Offset: 0x00D44848
		// (set) Token: 0x06034DFE RID: 216574 RVA: 0x00D46650 File Offset: 0x00D44850
		public bool TabIsFinish { get; set; }
	}
}
