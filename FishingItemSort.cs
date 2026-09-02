using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;

// Token: 0x02001934 RID: 6452
[NullableContext(1)]
[Nullable(0)]
public class FishingItemSort : CommonSort<EFishingItemSortWayType>
{
	// Token: 0x0600B945 RID: 47429 RVA: 0x00314630 File Offset: 0x00312830
	private int SortGetState(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IFishingHandBookItemData fishingHandBookItemData = a as IFishingHandBookItemData;
		if (fishingHandBookItemData == null)
		{
			return 0;
		}
		IFishingHandBookItemData fishingHandBookItemData2 = b as IFishingHandBookItemData;
		if (fishingHandBookItemData2 == null)
		{
			return 0;
		}
		int num = (ModelBase<FishingModel>.Instance.FishingItemHandBookDataMap.ContainsKey(fishingHandBookItemData.Id) > false) ? 1 : 0;
		int num2 = (ModelBase<FishingModel>.Instance.FishingItemHandBookDataMap.ContainsKey(fishingHandBookItemData2.Id) > false) ? 1 : 0;
		if (num != num2)
		{
			int num3 = num - num2;
			if (!isAscending)
			{
				return -num3;
			}
			return num3;
		}
		else
		{
			int num4 = fishingHandBookItemData2.HandBookId - fishingHandBookItemData.HandBookId;
			if (!isAscending)
			{
				return -num4;
			}
			return num4;
		}
	}

	// Token: 0x0600B946 RID: 47430 RVA: 0x003146B4 File Offset: 0x003128B4
	private int SortHandBookId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IFishingHandBookItemData fishingHandBookItemData = a as IFishingHandBookItemData;
		if (fishingHandBookItemData == null)
		{
			return 0;
		}
		IFishingHandBookItemData fishingHandBookItemData2 = b as IFishingHandBookItemData;
		if (fishingHandBookItemData2 == null)
		{
			return 0;
		}
		int num = fishingHandBookItemData2.HandBookId - fishingHandBookItemData.HandBookId;
		if (!isAscending)
		{
			return -num;
		}
		return num;
	}

	// Token: 0x0600B947 RID: 47431 RVA: 0x003146EE File Offset: 0x003128EE
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EFishingItemSortWayType.GetState, new TSortResult(this.SortGetState));
		this.SortMap.Add(EFishingItemSortWayType.HandBookId, new TSortResult(this.SortHandBookId));
	}
}
