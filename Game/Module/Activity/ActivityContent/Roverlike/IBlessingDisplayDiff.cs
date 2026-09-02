using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006409 RID: 25609
	[NullableContext(1)]
	public interface IBlessingDisplayDiff
	{
		// Token: 0x17009DD4 RID: 40404
		// (get) Token: 0x060404B2 RID: 263346
		// (set) Token: 0x060404B3 RID: 263347
		List<IRoverlikeBlessingSlotItemData> DataList { get; set; }

		// Token: 0x17009DD5 RID: 40405
		// (get) Token: 0x060404B4 RID: 263348
		// (set) Token: 0x060404B5 RID: 263349
		List<int> ChangedSlots { get; set; }

		// Token: 0x17009DD6 RID: 40406
		// (get) Token: 0x060404B6 RID: 263350
		// (set) Token: 0x060404B7 RID: 263351
		int Count { get; set; }
	}
}
