using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x020061A3 RID: 24995
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelPlayNightMareConfigData : ILevelPlayNightMareConfigData
	{
		// Token: 0x17009B34 RID: 39732
		// (get) Token: 0x0603F1DE RID: 258526 RVA: 0x0102F691 File Offset: 0x0102D891
		// (set) Token: 0x0603F1DF RID: 258527 RVA: 0x0102F699 File Offset: 0x0102D899
		public int LevelPlayId { get; set; }

		// Token: 0x17009B35 RID: 39733
		// (get) Token: 0x0603F1E0 RID: 258528 RVA: 0x0102F6A2 File Offset: 0x0102D8A2
		// (set) Token: 0x0603F1E1 RID: 258529 RVA: 0x0102F6AA File Offset: 0x0102D8AA
		public string[] Vars { get; set; }

		// Token: 0x17009B36 RID: 39734
		// (get) Token: 0x0603F1E2 RID: 258530 RVA: 0x0102F6B3 File Offset: 0x0102D8B3
		// (set) Token: 0x0603F1E3 RID: 258531 RVA: 0x0102F6BB File Offset: 0x0102D8BB
		public int[] DefaultValues { get; set; }
	}
}
