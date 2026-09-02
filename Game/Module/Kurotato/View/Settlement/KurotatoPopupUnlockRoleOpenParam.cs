using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A76 RID: 23158
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoPopupUnlockRoleOpenParam : IKurotatoPopupUnlockRoleOpenParam
	{
		// Token: 0x1700958D RID: 38285
		// (get) Token: 0x0603A9AA RID: 240042 RVA: 0x00ED7FA8 File Offset: 0x00ED61A8
		// (set) Token: 0x0603A9AB RID: 240043 RVA: 0x00ED7FB0 File Offset: 0x00ED61B0
		public List<int> RoleIds { get; set; } = new List<int>();

		// Token: 0x1700958E RID: 38286
		// (get) Token: 0x0603A9AC RID: 240044 RVA: 0x00ED7FB9 File Offset: 0x00ED61B9
		// (set) Token: 0x0603A9AD RID: 240045 RVA: 0x00ED7FC1 File Offset: 0x00ED61C1
		public int Index { get; set; }
	}
}
