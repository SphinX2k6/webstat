using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053ED RID: 21485
	[NullableContext(1)]
	public interface IPlotAutoPlayComponentContext
	{
		// Token: 0x17008E03 RID: 36355
		// (get) Token: 0x06036D84 RID: 224644
		// (set) Token: 0x06036D85 RID: 224645
		UUIExtendToggle Toggle { get; set; }

		// Token: 0x17008E04 RID: 36356
		// (get) Token: 0x06036D86 RID: 224646
		// (set) Token: 0x06036D87 RID: 224647
		float WaitTime { get; set; }

		// Token: 0x17008E05 RID: 36357
		// (get) Token: 0x06036D88 RID: 224648
		// (set) Token: 0x06036D89 RID: 224649
		Func<bool> CheckTalkFinishedDelegate { get; set; }

		// Token: 0x17008E06 RID: 36358
		// (get) Token: 0x06036D8A RID: 224650
		// (set) Token: 0x06036D8B RID: 224651
		Action ContinueToNextTalkDelegate { get; set; }
	}
}
