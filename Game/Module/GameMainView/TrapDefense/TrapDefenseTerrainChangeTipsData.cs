using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.GameMainView.TrapDefense
{
	// Token: 0x02005D0C RID: 23820
	[NullableContext(2)]
	[Nullable(0)]
	public class TrapDefenseTerrainChangeTipsData : ITrapDefenseTerrainChangeTipsData
	{
		// Token: 0x1700985B RID: 39003
		// (get) Token: 0x0603C0B6 RID: 245942 RVA: 0x00F3B613 File Offset: 0x00F39813
		// (set) Token: 0x0603C0B7 RID: 245943 RVA: 0x00F3B61B File Offset: 0x00F3981B
		public Action Callback { get; set; }
	}
}
