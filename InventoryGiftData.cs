using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x02002011 RID: 8209
[NullableContext(1)]
[Nullable(0)]
public class InventoryGiftData : UiPopViewData
{
	// Token: 0x0600F8B1 RID: 63665 RVA: 0x00442FE4 File Offset: 0x004411E4
	public InventoryGiftData(int configId, GiftItemData[] itemList, GiftPackage giftPackage, int? initSelectedId, int? selectedCount)
	{
		this.ConfigId = configId;
		int num = itemList.Length;
		this.ItemList = new GiftItemData[num];
		for (int i = 0; i < num; i++)
		{
			this.ItemList[i] = itemList[i];
		}
		this.GiftPackage = giftPackage;
		this.InitializedSelectedId = initSelectedId;
		this.SelectedCount = selectedCount;
	}

	// Token: 0x040077E4 RID: 30692
	public int ConfigId;

	// Token: 0x040077E5 RID: 30693
	public GiftItemData[] ItemList;

	// Token: 0x040077E6 RID: 30694
	public GiftPackage GiftPackage;

	// Token: 0x040077E7 RID: 30695
	public int? InitializedSelectedId;

	// Token: 0x040077E8 RID: 30696
	public int? SelectedCount;
}
