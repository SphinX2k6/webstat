using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle
{
	// Token: 0x02004BA2 RID: 19362
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMarkProgressItemData : IMapMarkProgressItemData
	{
		// Token: 0x170086E4 RID: 34532
		// (get) Token: 0x060328DD RID: 207069 RVA: 0x00CA79AA File Offset: 0x00CA5BAA
		// (set) Token: 0x060328DE RID: 207070 RVA: 0x00CA79B2 File Offset: 0x00CA5BB2
		public string NameId { get; set; } = "";

		// Token: 0x170086E5 RID: 34533
		// (get) Token: 0x060328DF RID: 207071 RVA: 0x00CA79BB File Offset: 0x00CA5BBB
		// (set) Token: 0x060328E0 RID: 207072 RVA: 0x00CA79C3 File Offset: 0x00CA5BC3
		public float Progress { get; set; }

		// Token: 0x170086E6 RID: 34534
		// (get) Token: 0x060328E1 RID: 207073 RVA: 0x00CA79CC File Offset: 0x00CA5BCC
		// (set) Token: 0x060328E2 RID: 207074 RVA: 0x00CA79D4 File Offset: 0x00CA5BD4
		public float ProgressMax { get; set; }

		// Token: 0x170086E7 RID: 34535
		// (get) Token: 0x060328E3 RID: 207075 RVA: 0x00CA79DD File Offset: 0x00CA5BDD
		// (set) Token: 0x060328E4 RID: 207076 RVA: 0x00CA79E5 File Offset: 0x00CA5BE5
		public float ProgressMin { get; set; }

		// Token: 0x170086E8 RID: 34536
		// (get) Token: 0x060328E5 RID: 207077 RVA: 0x00CA79EE File Offset: 0x00CA5BEE
		// (set) Token: 0x060328E6 RID: 207078 RVA: 0x00CA79F6 File Offset: 0x00CA5BF6
		[Nullable(2)]
		public Action<float> SetProgressCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
