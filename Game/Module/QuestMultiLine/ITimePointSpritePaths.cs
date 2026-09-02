using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuestMultiLine
{
	// Token: 0x0200531B RID: 21275
	[NullableContext(1)]
	public interface ITimePointSpritePaths
	{
		// Token: 0x17008D1B RID: 36123
		// (get) Token: 0x060364B2 RID: 222386
		// (set) Token: 0x060364B3 RID: 222387
		string Idle { get; set; }

		// Token: 0x17008D1C RID: 36124
		// (get) Token: 0x060364B4 RID: 222388
		// (set) Token: 0x060364B5 RID: 222389
		string Hover { get; set; }

		// Token: 0x17008D1D RID: 36125
		// (get) Token: 0x060364B6 RID: 222390
		// (set) Token: 0x060364B7 RID: 222391
		string Pressed { get; set; }

		// Token: 0x17008D1E RID: 36126
		// (get) Token: 0x060364B8 RID: 222392
		// (set) Token: 0x060364B9 RID: 222393
		string Selected { get; set; }
	}
}
