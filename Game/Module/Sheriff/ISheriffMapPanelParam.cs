using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB3 RID: 20403
	[NullableContext(2)]
	public interface ISheriffMapPanelParam
	{
		// Token: 0x17008A6A RID: 35434
		// (get) Token: 0x06034A54 RID: 215636
		// (set) Token: 0x06034A55 RID: 215637
		ESheriffMainTabType? TabType { get; set; }

		// Token: 0x17008A6B RID: 35435
		// (get) Token: 0x06034A56 RID: 215638
		// (set) Token: 0x06034A57 RID: 215639
		int? TargetMarkId { get; set; }

		// Token: 0x17008A6C RID: 35436
		// (get) Token: 0x06034A58 RID: 215640
		// (set) Token: 0x06034A59 RID: 215641
		bool? IsError { get; set; }

		// Token: 0x17008A6D RID: 35437
		// (get) Token: 0x06034A5A RID: 215642
		// (set) Token: 0x06034A5B RID: 215643
		Action OnPanelOpened { get; set; }
	}
}
