using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200508F RID: 20623
	[NullableContext(1)]
	public interface IRoleDevelopSettlementJumpData
	{
		// Token: 0x17008BB5 RID: 35765
		// (get) Token: 0x0603525D RID: 217693
		// (set) Token: 0x0603525E RID: 217694
		bool CanShow { get; set; }

		// Token: 0x17008BB6 RID: 35766
		// (get) Token: 0x0603525F RID: 217695
		// (set) Token: 0x06035260 RID: 217696
		int RoleId { get; set; }

		// Token: 0x17008BB7 RID: 35767
		// (get) Token: 0x06035261 RID: 217697
		// (set) Token: 0x06035262 RID: 217698
		string RoleIconPath { get; set; }

		// Token: 0x17008BB8 RID: 35768
		// (get) Token: 0x06035263 RID: 217699
		// (set) Token: 0x06035264 RID: 217700
		List<int> MatchedItemIds { get; set; }

		// Token: 0x17008BB9 RID: 35769
		// (get) Token: 0x06035265 RID: 217701
		// (set) Token: 0x06035266 RID: 217702
		List<int> NeedCheckItemIds { get; set; }

		// Token: 0x17008BBA RID: 35770
		// (get) Token: 0x06035267 RID: 217703
		// (set) Token: 0x06035268 RID: 217704
		ERoleDevelopSettlementSourceDungeonType SourceDungeonType { get; set; }
	}
}
