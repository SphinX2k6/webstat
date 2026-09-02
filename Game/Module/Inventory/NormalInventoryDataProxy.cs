using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B85 RID: 23429
	[NullableContext(1)]
	[Nullable(0)]
	public class NormalInventoryDataProxy : InventoryDataProxy
	{
		// Token: 0x0603B3AB RID: 242603 RVA: 0x00EFD648 File Offset: 0x00EFB848
		public NormalInventoryDataProxy(InventoryModel model)
		{
			this.Model = model;
		}

		// Token: 0x0603B3AC RID: 242604 RVA: 0x00EFD657 File Offset: 0x00EFB857
		public override List<ItemMainType> GetOpenIdMainTypeConfig()
		{
			return this.Model.GetOpenIdMainTypeConfigBase();
		}

		// Token: 0x0603B3AD RID: 242605 RVA: 0x00EFD664 File Offset: 0x00EFB864
		public override HashSet<ItemDataBase> GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId mainType)
		{
			return this.Model.GetItemDataBaseByMainTypeBase(mainType);
		}

		// Token: 0x0603B3AE RID: 242606 RVA: 0x00EFD672 File Offset: 0x00EFB872
		public override int GetInventoryItemGridCountByMainType(InventoryDefine.EItemMainTypeId mainType)
		{
			return this.Model.GetInventoryItemGridCountByMainTypeBase(mainType);
		}

		// Token: 0x0603B3AF RID: 242607 RVA: 0x00EFD680 File Offset: 0x00EFB880
		public override bool SupportShowCurrency()
		{
			return true;
		}

		// Token: 0x0603B3B0 RID: 242608 RVA: 0x00EFD683 File Offset: 0x00EFB883
		public override int GetItemCountByConfigId(int itemConfigId, int uniqueId)
		{
			return this.Model.GetItemCountByConfigIdBase(itemConfigId, uniqueId);
		}

		// Token: 0x0402162B RID: 136747
		private readonly InventoryModel Model;
	}
}
