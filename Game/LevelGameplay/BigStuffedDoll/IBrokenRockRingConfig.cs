using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll
{
	// Token: 0x02006F54 RID: 28500
	[NullableContext(1)]
	public interface IBrokenRockRingConfig
	{
		// Token: 0x1700A47E RID: 42110
		// (get) Token: 0x06044FA2 RID: 282530
		// (set) Token: 0x06044FA3 RID: 282531
		int Id { get; set; }

		// Token: 0x1700A47F RID: 42111
		// (get) Token: 0x06044FA4 RID: 282532
		// (set) Token: 0x06044FA5 RID: 282533
		List<List<int>> InvalidBox { get; set; }

		// Token: 0x1700A480 RID: 42112
		// (get) Token: 0x06044FA6 RID: 282534
		// (set) Token: 0x06044FA7 RID: 282535
		int[] RandomBox { get; set; }

		// Token: 0x1700A481 RID: 42113
		// (get) Token: 0x06044FA8 RID: 282536
		// (set) Token: 0x06044FA9 RID: 282537
		int PerfectBox { get; set; }

		// Token: 0x1700A482 RID: 42114
		// (get) Token: 0x06044FAA RID: 282538
		// (set) Token: 0x06044FAB RID: 282539
		Dictionary<int, int> BonusRate { get; set; }

		// Token: 0x1700A483 RID: 42115
		// (get) Token: 0x06044FAC RID: 282540
		// (set) Token: 0x06044FAD RID: 282541
		int GoodScore { get; set; }

		// Token: 0x1700A484 RID: 42116
		// (get) Token: 0x06044FAE RID: 282542
		// (set) Token: 0x06044FAF RID: 282543
		int PerfectScore { get; set; }

		// Token: 0x1700A485 RID: 42117
		// (get) Token: 0x06044FB0 RID: 282544
		// (set) Token: 0x06044FB1 RID: 282545
		int BonusScore { get; set; }

		// Token: 0x1700A486 RID: 42118
		// (get) Token: 0x06044FB2 RID: 282546
		// (set) Token: 0x06044FB3 RID: 282547
		Dictionary<int, int> Speed { get; set; }

		// Token: 0x1700A487 RID: 42119
		// (get) Token: 0x06044FB4 RID: 282548
		// (set) Token: 0x06044FB5 RID: 282549
		int ColdTime { get; set; }

		// Token: 0x1700A488 RID: 42120
		// (get) Token: 0x06044FB6 RID: 282550
		// (set) Token: 0x06044FB7 RID: 282551
		int MultiBoxGroup { get; set; }

		// Token: 0x1700A489 RID: 42121
		// (get) Token: 0x06044FB8 RID: 282552
		// (set) Token: 0x06044FB9 RID: 282553
		int[] Offset { get; set; }

		// Token: 0x1700A48A RID: 42122
		// (get) Token: 0x06044FBA RID: 282554
		// (set) Token: 0x06044FBB RID: 282555
		bool IsAnticlockwise { get; set; }
	}
}
