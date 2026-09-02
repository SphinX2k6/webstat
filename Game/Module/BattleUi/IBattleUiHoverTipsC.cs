using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F64 RID: 24420
	[NullableContext(1)]
	public interface IBattleUiHoverTipsC
	{
		// Token: 0x17009A4A RID: 39498
		// (get) Token: 0x0603D525 RID: 251173
		// (set) Token: 0x0603D526 RID: 251174
		string TitleKey { get; set; }

		// Token: 0x17009A4B RID: 39499
		// (get) Token: 0x0603D527 RID: 251175
		// (set) Token: 0x0603D528 RID: 251176
		List<IBattleUiHoverTipsDescInfoC> DescInfoList { get; set; }
	}
}
