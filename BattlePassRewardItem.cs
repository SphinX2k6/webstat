using System;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002383 RID: 9091
public class BattlePassRewardItem
{
	// Token: 0x060116C4 RID: 71364 RVA: 0x004CD650 File Offset: 0x004CB850
	public BattlePassRewardItem(int itemId, int itemCount, EBattlePassItemType itemType = EBattlePassItemType.Locked)
	{
		this.Item = new TItem?(new TItem(new InventoryDefine.GetItemData(itemId, 0), itemCount));
		this.ItemType = new EBattlePassItemType?(itemType);
	}

	// Token: 0x040088C4 RID: 35012
	public TItem? Item;

	// Token: 0x040088C5 RID: 35013
	public EBattlePassItemType? ItemType;
}
