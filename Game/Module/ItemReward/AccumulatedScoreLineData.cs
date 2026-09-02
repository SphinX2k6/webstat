using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B2C RID: 23340
	[NullableContext(1)]
	[Nullable(0)]
	public class AccumulatedScoreLineData : IAccumulatedScoreLineData
	{
		// Token: 0x17009707 RID: 38663
		// (get) Token: 0x0603B0D9 RID: 241881 RVA: 0x00EF294B File Offset: 0x00EF0B4B
		// (set) Token: 0x0603B0DA RID: 241882 RVA: 0x00EF2953 File Offset: 0x00EF0B53
		public string DescTextId { get; set; }

		// Token: 0x17009708 RID: 38664
		// (get) Token: 0x0603B0DB RID: 241883 RVA: 0x00EF295C File Offset: 0x00EF0B5C
		// (set) Token: 0x0603B0DC RID: 241884 RVA: 0x00EF2964 File Offset: 0x00EF0B64
		public string ScoreText { get; set; }
	}
}
