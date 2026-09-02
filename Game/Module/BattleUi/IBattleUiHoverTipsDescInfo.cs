using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F62 RID: 24418
	[NullableContext(1)]
	public interface IBattleUiHoverTipsDescInfo
	{
		// Token: 0x17009A40 RID: 39488
		// (get) Token: 0x0603D510 RID: 251152
		// (set) Token: 0x0603D511 RID: 251153
		string DescKey { get; set; }

		// Token: 0x17009A41 RID: 39489
		// (get) Token: 0x0603D512 RID: 251154
		// (set) Token: 0x0603D513 RID: 251155
		bool? DescUseChangeColor { get; set; }

		// Token: 0x17009A42 RID: 39490
		// (get) Token: 0x0603D514 RID: 251156
		// (set) Token: 0x0603D515 RID: 251157
		[Nullable(2)]
		string StateTitleKey { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009A43 RID: 39491
		// (get) Token: 0x0603D516 RID: 251158
		// (set) Token: 0x0603D517 RID: 251159
		bool? IsUnlock { get; set; }

		// Token: 0x17009A44 RID: 39492
		// (get) Token: 0x0603D518 RID: 251160
		// (set) Token: 0x0603D519 RID: 251161
		bool? IsShowState { get; set; }
	}
}
