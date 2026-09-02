using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001D3C RID: 7484
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowCollectionTypeItemData
{
	// Token: 0x0600DC77 RID: 56439 RVA: 0x003B4154 File Offset: 0x003B2354
	public void AddItemData(MotorcycleArrowCollectionItemData itemData, bool newItem)
	{
		this.TotalCount++;
		int quality = itemData.Config.Quality;
		int num;
		this.ItemQualityToNumMap.TryGetValue(quality, out num);
		this.ItemQualityToNumMap[quality] = num + 1;
		if (newItem)
		{
			this.ItemList.Add(itemData);
			return;
		}
		itemData.Num++;
	}

	// Token: 0x0600DC78 RID: 56440 RVA: 0x003B41B8 File Offset: 0x003B23B8
	public int GetItemNumWithQuality(int quality)
	{
		int result;
		if (!this.ItemQualityToNumMap.TryGetValue(quality, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x0600DC79 RID: 56441 RVA: 0x003B41D8 File Offset: 0x003B23D8
	public MotorcycleArrowCollectionTypeItemData(int type)
	{
		this.Type = type;
	}

	// Token: 0x04006984 RID: 27012
	public int Type;

	// Token: 0x04006985 RID: 27013
	public int TotalCount;

	// Token: 0x04006986 RID: 27014
	public Dictionary<int, int> ItemQualityToNumMap = new Dictionary<int, int>();

	// Token: 0x04006987 RID: 27015
	public List<MotorcycleArrowCollectionItemData> ItemList = new List<MotorcycleArrowCollectionItemData>();
}
