using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200579F RID: 22431
	[NullableContext(1)]
	public interface ISetItemData
	{
		// Token: 0x1700919C RID: 37276
		// (get) Token: 0x0603909D RID: 233629
		// (set) Token: 0x0603909E RID: 233630
		int Index { get; set; }

		// Token: 0x1700919D RID: 37277
		// (get) Token: 0x0603909F RID: 233631
		// (set) Token: 0x060390A0 RID: 233632
		int Value { get; set; }

		// Token: 0x1700919E RID: 37278
		// (get) Token: 0x060390A1 RID: 233633
		// (set) Token: 0x060390A2 RID: 233634
		string Name { get; set; }
	}
}
