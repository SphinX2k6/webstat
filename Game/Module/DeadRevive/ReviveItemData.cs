using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DCA RID: 24010
	[NullableContext(1)]
	[Nullable(0)]
	public class ReviveItemData
	{
		// Token: 0x0603C71B RID: 247579 RVA: 0x00F594A4 File Offset: 0x00F576A4
		public ReviveItemData(int playerId, IReadOnlyList<int> itemIdMap, int choseId)
		{
			this.PlayerId = playerId;
			this.ItemIdList = itemIdMap;
			this.ChoseId = choseId;
		}

		// Token: 0x04021FB9 RID: 139193
		public int PlayerId;

		// Token: 0x04021FBA RID: 139194
		public int ChoseId;

		// Token: 0x04021FBB RID: 139195
		public IReadOnlyList<int> ItemIdList;
	}
}
