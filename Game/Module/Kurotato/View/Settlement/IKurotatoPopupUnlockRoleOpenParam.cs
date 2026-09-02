using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A75 RID: 23157
	[NullableContext(1)]
	public interface IKurotatoPopupUnlockRoleOpenParam
	{
		// Token: 0x1700958B RID: 38283
		// (get) Token: 0x0603A9A6 RID: 240038
		// (set) Token: 0x0603A9A7 RID: 240039
		List<int> RoleIds { get; set; }

		// Token: 0x1700958C RID: 38284
		// (get) Token: 0x0603A9A8 RID: 240040
		// (set) Token: 0x0603A9A9 RID: 240041
		int Index { get; set; }
	}
}
