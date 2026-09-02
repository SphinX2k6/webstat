using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A37 RID: 27191
	[NullableContext(1)]
	[Nullable(0)]
	public class ScanCompositeResult : IScanCompositeResult
	{
		// Token: 0x1700A240 RID: 41536
		// (get) Token: 0x060434B6 RID: 275638 RVA: 0x0114C65B File Offset: 0x0114A85B
		// (set) Token: 0x060434B7 RID: 275639 RVA: 0x0114C663 File Offset: 0x0114A863
		public List<GamePlayScan> ScanInfos { get; set; } = new List<GamePlayScan>();

		// Token: 0x1700A241 RID: 41537
		// (get) Token: 0x060434B8 RID: 275640 RVA: 0x0114C66C File Offset: 0x0114A86C
		// (set) Token: 0x060434B9 RID: 275641 RVA: 0x0114C674 File Offset: 0x0114A874
		public float Interval { get; set; }

		// Token: 0x1700A242 RID: 41538
		// (get) Token: 0x060434BA RID: 275642 RVA: 0x0114C67D File Offset: 0x0114A87D
		// (set) Token: 0x060434BB RID: 275643 RVA: 0x0114C685 File Offset: 0x0114A885
		public GamePlayScanComposite ScanCompositeConfig { get; set; }
	}
}
