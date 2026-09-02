using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001938 RID: 6456
[NullableContext(1)]
[Nullable(0)]
public class ItemSort : CommonSort<EItemSortWayType>
{
	// Token: 0x0600B94E RID: 47438 RVA: 0x00314904 File Offset: 0x00312B04
	private int SortConfigIdAscending(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		int configId = itemViewData.GetConfigId();
		int configId2 = itemViewData2.GetConfigId();
		return configId - configId2;
	}

	// Token: 0x0600B94F RID: 47439 RVA: 0x0031492C File Offset: 0x00312B2C
	private int SortConfigId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		int configId = itemViewData.GetConfigId();
		return (itemViewData2.GetConfigId() - configId) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B950 RID: 47440 RVA: 0x0031495C File Offset: 0x00312B5C
	private int SortLevel(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		int attributeLevel = itemViewData.GetAttributeLevel();
		return (itemViewData2.GetAttributeLevel() - attributeLevel) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B951 RID: 47441 RVA: 0x0031498C File Offset: 0x00312B8C
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		int quality = itemViewData.GetQuality();
		return (itemViewData2.GetQuality() - quality) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B952 RID: 47442 RVA: 0x003149BC File Offset: 0x00312BBC
	private int SortCount(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		int count = itemViewData.GetCount();
		int count2 = itemViewData2.GetCount();
		return (count - count2) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B953 RID: 47443 RVA: 0x003149F0 File Offset: 0x00312BF0
	private int SortSortIndex(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		int sortIndex = itemViewData.GetSortIndex();
		int sortIndex2 = itemViewData2.GetSortIndex();
		return (sortIndex - sortIndex2) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B954 RID: 47444 RVA: 0x00314A24 File Offset: 0x00312C24
	private int SortUniqueId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		int uniqueId = itemViewData.GetUniqueId();
		int uniqueId2 = itemViewData2.GetUniqueId();
		return (uniqueId - uniqueId2) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B955 RID: 47445 RVA: 0x00314A58 File Offset: 0x00312C58
	private int SortTimeLimit(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemViewData = a as global::ItemViewData;
		global::ItemViewData itemViewData2 = b as global::ItemViewData;
		ItemDataBase itemDataBase = itemViewData.GetItemDataBase();
		ItemDataBase itemDataBase2 = itemViewData2.GetItemDataBase();
		int num = 0;
		int num2 = 0;
		CommonItemData commonItemData = itemDataBase as CommonItemData;
		if (commonItemData != null)
		{
			num = ((commonItemData.IsLimitTimeItem() > false) ? 1 : 0);
		}
		CommonItemData commonItemData2 = itemDataBase2 as CommonItemData;
		if (commonItemData2 != null)
		{
			num2 = ((commonItemData2.IsLimitTimeItem() > false) ? 1 : 0);
		}
		return num2 - num;
	}

	// Token: 0x0600B956 RID: 47446 RVA: 0x00314AB4 File Offset: 0x00312CB4
	private int GetItemShowTypeSortValue(global::ItemViewData itemData)
	{
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemData.GetConfigId());
		if (((itemConfigData != null) ? itemConfigData.ShowTypes : null) == null || itemConfigData.ShowTypes.Length == 0)
		{
			return 0;
		}
		int showItemType = itemConfigData.ShowTypes[0];
		ItemShowType? itemShowTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemShowTypeConfig(showItemType);
		if (itemShowTypeConfig == null)
		{
			return 0;
		}
		return itemShowTypeConfig.Value.ItemSort;
	}

	// Token: 0x0600B957 RID: 47447 RVA: 0x00314B1C File Offset: 0x00312D1C
	private int SortItemShowType(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		global::ItemViewData itemData = a as global::ItemViewData;
		global::ItemViewData itemData2 = b as global::ItemViewData;
		int itemShowTypeSortValue = this.GetItemShowTypeSortValue(itemData);
		return this.GetItemShowTypeSortValue(itemData2) - itemShowTypeSortValue;
	}

	// Token: 0x0600B958 RID: 47448 RVA: 0x00314B48 File Offset: 0x00312D48
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EItemSortWayType.ConfigId, new TSortResult(this.SortConfigId));
		this.SortMap.Add(EItemSortWayType.Count, new TSortResult(this.SortCount));
		this.SortMap.Add(EItemSortWayType.Level, new TSortResult(this.SortLevel));
		this.SortMap.Add(EItemSortWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(EItemSortWayType.SortIndex, new TSortResult(this.SortSortIndex));
		this.SortMap.Add(EItemSortWayType.UniqueId, new TSortResult(this.SortUniqueId));
		this.SortMap.Add(EItemSortWayType.ConfigIdAscending, new TSortResult(this.SortConfigIdAscending));
		this.SortMap.Add(EItemSortWayType.IsTimeLimit, new TSortResult(this.SortTimeLimit));
		this.SortMap.Add(EItemSortWayType.ItemShowTypeSort, new TSortResult(this.SortItemShowType));
	}
}
