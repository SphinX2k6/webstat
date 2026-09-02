using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.View.Items;

namespace CSharpScript.Game.Module.QuestMultiLine.View
{
	// Token: 0x02005320 RID: 21280
	[NullableContext(1)]
	public interface IAnimationSequencerContext
	{
		// Token: 0x17008D23 RID: 36131
		// (get) Token: 0x060364E2 RID: 222434
		// (set) Token: 0x060364E3 RID: 222435
		QuestMultiLineMapPanel MapPanel { get; set; }

		// Token: 0x17008D24 RID: 36132
		// (get) Token: 0x060364E4 RID: 222436
		// (set) Token: 0x060364E5 RID: 222437
		QuestMultiLineTimeLinePanel TimeLinePanel { get; set; }

		// Token: 0x17008D25 RID: 36133
		// (get) Token: 0x060364E6 RID: 222438
		// (set) Token: 0x060364E7 RID: 222439
		QuestMultiLineView View { get; set; }
	}
}
