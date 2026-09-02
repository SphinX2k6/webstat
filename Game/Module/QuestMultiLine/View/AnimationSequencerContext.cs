using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.View.Items;

namespace CSharpScript.Game.Module.QuestMultiLine.View
{
	// Token: 0x02005321 RID: 21281
	[NullableContext(1)]
	[Nullable(0)]
	public class AnimationSequencerContext : IAnimationSequencerContext
	{
		// Token: 0x17008D26 RID: 36134
		// (get) Token: 0x060364E8 RID: 222440 RVA: 0x00DB0092 File Offset: 0x00DAE292
		// (set) Token: 0x060364E9 RID: 222441 RVA: 0x00DB009A File Offset: 0x00DAE29A
		public QuestMultiLineMapPanel MapPanel { get; set; }

		// Token: 0x17008D27 RID: 36135
		// (get) Token: 0x060364EA RID: 222442 RVA: 0x00DB00A3 File Offset: 0x00DAE2A3
		// (set) Token: 0x060364EB RID: 222443 RVA: 0x00DB00AB File Offset: 0x00DAE2AB
		public QuestMultiLineTimeLinePanel TimeLinePanel { get; set; }

		// Token: 0x17008D28 RID: 36136
		// (get) Token: 0x060364EC RID: 222444 RVA: 0x00DB00B4 File Offset: 0x00DAE2B4
		// (set) Token: 0x060364ED RID: 222445 RVA: 0x00DB00BC File Offset: 0x00DAE2BC
		public QuestMultiLineView View { get; set; }
	}
}
