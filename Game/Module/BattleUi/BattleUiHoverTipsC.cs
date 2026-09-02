using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F65 RID: 24421
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiHoverTipsC : IBattleUiHoverTipsC
	{
		// Token: 0x17009A4C RID: 39500
		// (get) Token: 0x0603D529 RID: 251177 RVA: 0x00F98D9B File Offset: 0x00F96F9B
		// (set) Token: 0x0603D52A RID: 251178 RVA: 0x00F98DA3 File Offset: 0x00F96FA3
		public string TitleKey { get; set; }

		// Token: 0x17009A4D RID: 39501
		// (get) Token: 0x0603D52B RID: 251179 RVA: 0x00F98DAC File Offset: 0x00F96FAC
		// (set) Token: 0x0603D52C RID: 251180 RVA: 0x00F98DB4 File Offset: 0x00F96FB4
		public List<IBattleUiHoverTipsDescInfoC> DescInfoList { get; set; }
	}
}
