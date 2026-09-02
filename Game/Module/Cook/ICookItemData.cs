using System;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DFF RID: 24063
	public interface ICookItemData
	{
		// Token: 0x170098DD RID: 39133
		// (get) Token: 0x0603C8D1 RID: 248017
		// (set) Token: 0x0603C8D2 RID: 248018
		ECookListType MainType { get; set; }

		// Token: 0x170098DE RID: 39134
		// (get) Token: 0x0603C8D3 RID: 248019
		// (set) Token: 0x0603C8D4 RID: 248020
		int ItemId { get; set; }

		// Token: 0x170098DF RID: 39135
		// (get) Token: 0x0603C8D5 RID: 248021
		// (set) Token: 0x0603C8D6 RID: 248022
		bool IsNew { get; set; }

		// Token: 0x170098E0 RID: 39136
		// (get) Token: 0x0603C8D7 RID: 248023
		// (set) Token: 0x0603C8D8 RID: 248024
		int Quality { get; set; }

		// Token: 0x170098E1 RID: 39137
		// (get) Token: 0x0603C8D9 RID: 248025
		// (set) Token: 0x0603C8DA RID: 248026
		bool IsUnLock { get; set; }
	}
}
