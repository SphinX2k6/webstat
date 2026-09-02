using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020018F8 RID: 6392
[NullableContext(1)]
[Nullable(0)]
public class VisionDestroyFilterLogic
{
	// Token: 0x0600B77E RID: 46974 RVA: 0x0030D1AC File Offset: 0x0030B3AC
	private static int GetDataConfigId(object data)
	{
		PhantomItemData phantomItemData = data as PhantomItemData;
		if (phantomItemData != null)
		{
			return phantomItemData.GetConfigId();
		}
		ItemViewData itemViewData = data as ItemViewData;
		if (itemViewData != null)
		{
			return itemViewData.GetConfigId();
		}
		return 0;
	}

	// Token: 0x0600B77F RID: 46975 RVA: 0x0030D1DC File Offset: 0x0030B3DC
	private static int GetDataUniqueId(object data)
	{
		PhantomItemData phantomItemData = data as PhantomItemData;
		if (phantomItemData != null)
		{
			return phantomItemData.GetUniqueId();
		}
		ItemViewData itemViewData = data as ItemViewData;
		if (itemViewData != null)
		{
			return itemViewData.GetUniqueId();
		}
		return 0;
	}

	// Token: 0x0600B780 RID: 46976 RVA: 0x0030D20C File Offset: 0x0030B40C
	public static object GetPhantomRarity(object data, Dictionary<int, string> currentSelectMap)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(VisionDestroyFilterLogic.GetDataConfigId(data)).PhantomItem.GetValueOrDefault().Rarity;
	}

	// Token: 0x0600B781 RID: 46977 RVA: 0x0030D244 File Offset: 0x0030B444
	public static object GetPhantomCost(object data, Dictionary<int, string> currentSelectMap)
	{
		int cost = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(VisionDestroyFilterLogic.GetDataUniqueId(data)).GetCost();
		return PhantomBattleConfigDefine.COSTLIST.IndexOf(cost);
	}

	// Token: 0x0600B782 RID: 46978 RVA: 0x0030D278 File Offset: 0x0030B478
	public static object GetPhantomQuality(object data, Dictionary<int, string> currentSelectMap)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetPhantomInstanceByItemId(VisionDestroyFilterLogic.GetDataConfigId(data)).PhantomItem.GetValueOrDefault().QualityId;
	}

	// Token: 0x0600B783 RID: 46979 RVA: 0x0030D2AF File Offset: 0x0030B4AF
	public static object GetVisionDestroyFetterGroup(object data, Dictionary<int, string> currentSelectMap)
	{
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(VisionDestroyFilterLogic.GetDataUniqueId(data));
		return (phantomDataBase != null) ? phantomDataBase.GetFetterGroupId() : 0;
	}

	// Token: 0x0600B784 RID: 46980 RVA: 0x0030D2D4 File Offset: 0x0030B4D4
	public static object GetVisionDestroyAttribute(object data, Dictionary<int, string> currentSelectMap)
	{
		List<int> list = new List<int>(currentSelectMap.Keys);
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(VisionDestroyFilterLogic.GetDataUniqueId(data)) as PhantomBattleData;
		bool flag = false;
		foreach (int num in list)
		{
			int visionAttribute;
			if (num >= 1000)
			{
				List<PhantomSortStruct> propData = (phantomBattleData != null) ? phantomBattleData.GetMainPropArray() : null;
				bool ifPercentage = ConfigBase<PhantomBattleConfig>.Instance.GetVisionMainPercentageAttributeSortArray().Contains(num);
				int mainAttributeKey = ModelBase<PhantomBattleModel>.Instance.GetMainAttributeKey(num);
				int mainAttributeCost = ModelBase<PhantomBattleModel>.Instance.GetMainAttributeCost(num);
				if (phantomBattleData.GetCost() != mainAttributeCost)
				{
					continue;
				}
				visionAttribute = VisionDestroyFilterLogic.GetVisionAttribute(propData, mainAttributeKey, ifPercentage);
			}
			else if (num >= 23)
			{
				List<PhantomSortStruct> propData2 = (phantomBattleData != null) ? phantomBattleData.GetSubPropArray() : null;
				bool ifPercentage2 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionSubPercentageAttributeSortArray().Contains(num);
				int subAttributeKey = ModelBase<PhantomBattleModel>.Instance.GetSubAttributeKey(num);
				visionAttribute = VisionDestroyFilterLogic.GetVisionAttribute(propData2, subAttributeKey, ifPercentage2);
			}
			else
			{
				List<PhantomSortStruct> propData3 = (phantomBattleData != null) ? phantomBattleData.GetMainPropArray() : null;
				bool ifPercentage3 = ConfigBase<PhantomBattleConfig>.Instance.GetVisionMainPercentageAttributeSortArray().Contains(num);
				int mainAttributeKey2 = ModelBase<PhantomBattleModel>.Instance.GetMainAttributeKey(num);
				visionAttribute = VisionDestroyFilterLogic.GetVisionAttribute(propData3, mainAttributeKey2, ifPercentage3);
			}
			if (visionAttribute > 0)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return list.ToArray();
		}
		return new int[1];
	}

	// Token: 0x0600B785 RID: 46981 RVA: 0x0030D43C File Offset: 0x0030B63C
	private static int GetVisionAttribute([Nullable(new byte[]
	{
		2,
		1
	})] List<PhantomSortStruct> propData, int propKey, bool ifPercentage = false)
	{
		if (propData == null)
		{
			return 0;
		}
		int count = propData.Count;
		for (int i = 0; i < count; i++)
		{
			if (propData[i].PhantomPropId == propKey)
			{
				if (ifPercentage && propData[i].IfPercentage)
				{
					return propData[i].Value;
				}
				if (!ifPercentage && !propData[i].IfPercentage)
				{
					return propData[i].Value;
				}
			}
		}
		return 0;
	}

	// Token: 0x0600B786 RID: 46982 RVA: 0x0030D4B0 File Offset: 0x0030B6B0
	public static object GetPhantomDeprecate(object data, Dictionary<int, string> currentSelectMap)
	{
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(VisionDestroyFilterLogic.GetDataUniqueId(data));
		if (phantomDataBase != null && phantomDataBase.GetIsLock())
		{
			return 2;
		}
		return ((phantomDataBase != null && phantomDataBase.GetIsDeprecated()) > false) ? 1 : 0;
	}

	// Token: 0x0400568C RID: 22156
	private const int SUBATTRIBUTEID = 23;

	// Token: 0x0400568D RID: 22157
	private const int COSTATTRIBUTEID = 1000;
}
