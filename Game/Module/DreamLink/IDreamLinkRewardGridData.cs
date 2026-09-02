using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA0 RID: 23968
	[NullableContext(1)]
	public interface IDreamLinkRewardGridData
	{
		// Token: 0x170098B0 RID: 39088
		// (get) Token: 0x0603C58F RID: 247183
		// (set) Token: 0x0603C590 RID: 247184
		int RewardId { get; set; }

		// Token: 0x170098B1 RID: 39089
		// (get) Token: 0x0603C591 RID: 247185
		// (set) Token: 0x0603C592 RID: 247186
		TItem Item { get; set; }

		// Token: 0x170098B2 RID: 39090
		// (get) Token: 0x0603C593 RID: 247187
		// (set) Token: 0x0603C594 RID: 247188
		EActivityTaskState Status { get; set; }

		// Token: 0x170098B3 RID: 39091
		// (get) Token: 0x0603C595 RID: 247189
		// (set) Token: 0x0603C596 RID: 247190
		Action ReceiveDelegate { get; set; }
	}
}
