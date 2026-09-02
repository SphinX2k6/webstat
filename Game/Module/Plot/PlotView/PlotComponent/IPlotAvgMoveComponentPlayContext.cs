using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053EB RID: 21483
	[NullableContext(2)]
	public interface IPlotAvgMoveComponentPlayContext
	{
		// Token: 0x17008DF9 RID: 36345
		// (get) Token: 0x06036D6F RID: 224623
		// (set) Token: 0x06036D70 RID: 224624
		IPlotAvgCharacterMove AvgCharacter { get; set; }

		// Token: 0x17008DFA RID: 36346
		// (get) Token: 0x06036D71 RID: 224625
		// (set) Token: 0x06036D72 RID: 224626
		float StartPosition { get; set; }

		// Token: 0x17008DFB RID: 36347
		// (get) Token: 0x06036D73 RID: 224627
		// (set) Token: 0x06036D74 RID: 224628
		float EndPosition { get; set; }

		// Token: 0x17008DFC RID: 36348
		// (get) Token: 0x06036D75 RID: 224629
		// (set) Token: 0x06036D76 RID: 224630
		LTweenEase Ease { get; set; }

		// Token: 0x17008DFD RID: 36349
		// (get) Token: 0x06036D77 RID: 224631
		// (set) Token: 0x06036D78 RID: 224632
		float Duration { get; set; }
	}
}
