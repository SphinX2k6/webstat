using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Item;

// Token: 0x0200204C RID: 8268
public class ExchangeUnitData
{
	// Token: 0x0600FBDC RID: 64476 RVA: 0x00452A24 File Offset: 0x00450C24
	public void SetDataByItemId(int itemId, int? totalCount = null)
	{
		if (ConfigBase<ItemConfig>.Instance.GetConfig(itemId) != null)
		{
			this.ItemId = itemId;
			this.Name = ConfigBase<ItemConfig>.Instance.GetItemName(itemId);
			int? num = totalCount;
			int num2 = 0;
			this.TotalCount = ((num.GetValueOrDefault() > num2 & num != null) ? totalCount.Value : ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0));
		}
	}

	// Token: 0x040078E3 RID: 30947
	public int ItemId;

	// Token: 0x040078E4 RID: 30948
	[Nullable(1)]
	public string Name = "";

	// Token: 0x040078E5 RID: 30949
	public int TotalCount = 999999999;
}
