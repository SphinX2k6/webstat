using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006809 RID: 26633
	[NullableContext(1)]
	public interface IFishingHandBookItemData
	{
		// Token: 0x1700A16F RID: 41327
		// (get) Token: 0x0604262D RID: 271917
		// (set) Token: 0x0604262E RID: 271918
		int Id { get; set; }

		// Token: 0x1700A170 RID: 41328
		// (get) Token: 0x0604262F RID: 271919
		// (set) Token: 0x06042630 RID: 271920
		int Type { get; set; }

		// Token: 0x1700A171 RID: 41329
		// (get) Token: 0x06042631 RID: 271921
		// (set) Token: 0x06042632 RID: 271922
		int Time { get; set; }

		// Token: 0x1700A172 RID: 41330
		// (get) Token: 0x06042633 RID: 271923
		// (set) Token: 0x06042634 RID: 271924
		List<int> Tech { get; set; }

		// Token: 0x1700A173 RID: 41331
		// (get) Token: 0x06042635 RID: 271925
		// (set) Token: 0x06042636 RID: 271926
		List<int> Area { get; set; }

		// Token: 0x1700A174 RID: 41332
		// (get) Token: 0x06042637 RID: 271927
		// (set) Token: 0x06042638 RID: 271928
		int HandBookId { get; set; }
	}
}
