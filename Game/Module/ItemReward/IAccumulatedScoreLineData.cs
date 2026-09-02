using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B2B RID: 23339
	[NullableContext(1)]
	public interface IAccumulatedScoreLineData
	{
		// Token: 0x17009705 RID: 38661
		// (get) Token: 0x0603B0D5 RID: 241877
		// (set) Token: 0x0603B0D6 RID: 241878
		string DescTextId { get; set; }

		// Token: 0x17009706 RID: 38662
		// (get) Token: 0x0603B0D7 RID: 241879
		// (set) Token: 0x0603B0D8 RID: 241880
		string ScoreText { get; set; }
	}
}
