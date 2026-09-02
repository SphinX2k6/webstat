using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x0200500E RID: 20494
	[NullableContext(1)]
	[Nullable(0)]
	public class GridRedDotInfo
	{
		// Token: 0x17008AC8 RID: 35528
		// (get) Token: 0x06034D37 RID: 216375 RVA: 0x00D431A2 File Offset: 0x00D413A2
		// (set) Token: 0x06034D38 RID: 216376 RVA: 0x00D431AA File Offset: 0x00D413AA
		public ERouletteExploreId Id { get; set; }

		// Token: 0x17008AC9 RID: 35529
		// (get) Token: 0x06034D39 RID: 216377 RVA: 0x00D431B3 File Offset: 0x00D413B3
		// (set) Token: 0x06034D3A RID: 216378 RVA: 0x00D431BB File Offset: 0x00D413BB
		public Func<AssemblyGridData, bool> CheckFunction { get; set; }
	}
}
