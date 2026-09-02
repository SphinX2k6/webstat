using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B84 RID: 23428
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class InventoryDataProxy
	{
		// Token: 0x0603B3A3 RID: 242595
		public abstract List<ItemMainType> GetOpenIdMainTypeConfig();

		// Token: 0x0603B3A4 RID: 242596
		public abstract HashSet<ItemDataBase> GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId mainType);

		// Token: 0x0603B3A5 RID: 242597
		public abstract int GetInventoryItemGridCountByMainType(InventoryDefine.EItemMainTypeId mainType);

		// Token: 0x0603B3A6 RID: 242598
		public abstract bool SupportShowCurrency();

		// Token: 0x0603B3A7 RID: 242599
		public abstract int GetItemCountByConfigId(int itemConfigId, int uniqueId);

		// Token: 0x0603B3A8 RID: 242600 RVA: 0x00EFD62F File Offset: 0x00EFB82F
		public int GetSelectedTypeIndex()
		{
			return this.SelectedTypeIndex;
		}

		// Token: 0x0603B3A9 RID: 242601 RVA: 0x00EFD637 File Offset: 0x00EFB837
		public void SetSelectedTypeIndex(int index)
		{
			this.SelectedTypeIndex = index;
		}

		// Token: 0x0402162A RID: 136746
		protected int SelectedTypeIndex;
	}
}
