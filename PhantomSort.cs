using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200193B RID: 6459
[NullableContext(1)]
[Nullable(0)]
public class PhantomSort : CommonSort<EPhantomSortWayType>
{
	// Token: 0x0600B95D RID: 47453 RVA: 0x00314D70 File Offset: 0x00312F70
	private int SortLevel(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomBattleData phantomBattleData = instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = instance.GetPhantomBattleData(uniqueId2);
			if (phantomBattleData.GetPhantomLevel() != phantomBattleData2.GetPhantomLevel())
			{
				return (phantomBattleData2.GetPhantomLevel() - phantomBattleData.GetPhantomLevel()) * (isAscending ? -1 : 1);
			}
			return 0;
		}
		else
		{
			IPhantomItemData phantomItemData = a as IPhantomItemData;
			IPhantomItemData phantomItemData2 = b as IPhantomItemData;
			if (phantomItemData == phantomItemData2)
			{
				return 0;
			}
			if (phantomItemData == null)
			{
				return 1;
			}
			if (phantomItemData2 == null)
			{
				return -1;
			}
			if (phantomItemData.Level != phantomItemData2.Level)
			{
				return (phantomItemData2.Level - phantomItemData.Level) * (isAscending ? -1 : 1);
			}
			return 0;
		}
	}

	// Token: 0x0600B95E RID: 47454 RVA: 0x00314E68 File Offset: 0x00313068
	private int SortExp(object a, object b, bool isAscending, object[] param)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase.GetUniqueId());
		PhantomDataBase phantomDataBase2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase2.GetUniqueId());
		int num = 0;
		int num2 = 0;
		if (phantomDataBase != null)
		{
			num = phantomDataBase.GetExp();
		}
		else
		{
			IReadOnlyList<PhantomExpItem> phantomExpItemList = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemList();
			int count = phantomExpItemList.Count;
			for (int i = 0; i < count; i++)
			{
				if (phantomExpItemList[i].ItemId == itemDataBase.GetConfigId())
				{
					num = phantomExpItemList[i].Exp;
					break;
				}
			}
		}
		if (phantomDataBase2 != null)
		{
			num2 = phantomDataBase2.GetExp();
		}
		else
		{
			IReadOnlyList<PhantomExpItem> phantomExpItemList2 = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemList();
			int count2 = phantomExpItemList2.Count;
			for (int j = 0; j < count2; j++)
			{
				if (phantomExpItemList2[j].ItemId == itemDataBase2.GetConfigId())
				{
					num2 = phantomExpItemList2[j].Exp;
					break;
				}
			}
		}
		if (num != num2)
		{
			return (num2 - num) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B95F RID: 47455 RVA: 0x00314F88 File Offset: 0x00313188
	private int SortExpFirst(object a, object b, bool isAscending, object[] param)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		IReadOnlyList<PhantomExpItem> phantomExpItemList = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemList();
		int count = phantomExpItemList.Count;
		bool flag = false;
		for (int i = 0; i < count; i++)
		{
			if (phantomExpItemList[i].ItemId == itemDataBase.GetConfigId())
			{
				flag = true;
				break;
			}
		}
		bool flag2 = false;
		for (int j = 0; j < count; j++)
		{
			if (phantomExpItemList[j].ItemId == itemDataBase2.GetConfigId())
			{
				flag2 = true;
				break;
			}
		}
		if (flag != flag2)
		{
			int num = (flag > false) ? 1 : 0;
			return ((flag2 > false) ? 1 : 0) - num;
		}
		return 0;
	}

	// Token: 0x0600B960 RID: 47456 RVA: 0x00315030 File Offset: 0x00313230
	private int SortBreach(object a, object b, bool isAscending, object[] param)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomBattleData phantomBattleData = instance.GetPhantomBattleData(uniqueId);
			PhantomDataBase phantomBattleData2 = instance.GetPhantomBattleData(uniqueId2);
			List<Aki.Protocol.PhantomPropInfo> phantomSubProp = phantomBattleData.GetPhantomSubProp();
			List<Aki.Protocol.PhantomPropInfo> phantomSubProp2 = phantomBattleData2.GetPhantomSubProp();
			int num = ((phantomSubProp != null && phantomSubProp.Count > 0) > false) ? 1 : 0;
			int num2 = ((phantomSubProp2 != null && phantomSubProp2.Count > 0) > false) ? 1 : 0;
			if (num != num2)
			{
				return (num2 - num) * (isAscending ? -1 : 1);
			}
			return 0;
		}
		else
		{
			IPhantomItemData phantomItemData = a as IPhantomItemData;
			IPhantomItemData phantomItemData2 = b as IPhantomItemData;
			if (phantomItemData == phantomItemData2)
			{
				return 0;
			}
			if (phantomItemData == null)
			{
				return 1;
			}
			if (phantomItemData2 == null)
			{
				return -1;
			}
			int num3 = (phantomItemData.IsBreach > false) ? 1 : 0;
			int num4 = (phantomItemData2.IsBreach > false) ? 1 : 0;
			if (num3 != num4)
			{
				return (num4 - num3) * (isAscending ? -1 : 1);
			}
			return 0;
		}
	}

	// Token: 0x0600B961 RID: 47457 RVA: 0x00315150 File Offset: 0x00313350
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		if (a is CommonItemData && b is CommonItemData)
		{
			return (((CommonItemData)b).GetQuality() - ((CommonItemData)a).GetQuality()) * (isAscending ? -1 : 1);
		}
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomBattleData phantomBattleData = instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = instance.GetPhantomBattleData(uniqueId2);
			if (phantomBattleData.GetQuality() != phantomBattleData2.GetQuality())
			{
				return (phantomBattleData2.GetQuality() - phantomBattleData.GetQuality()) * (isAscending ? -1 : 1);
			}
			return 0;
		}
		else
		{
			IPhantomItemData phantomItemData = a as IPhantomItemData;
			IPhantomItemData phantomItemData2 = b as IPhantomItemData;
			if (phantomItemData == phantomItemData2)
			{
				return 0;
			}
			if (phantomItemData == null)
			{
				return 1;
			}
			if (phantomItemData2 == null)
			{
				return -1;
			}
			if (phantomItemData.Quality != phantomItemData2.Quality)
			{
				return (phantomItemData2.Quality - phantomItemData.Quality) * (isAscending ? -1 : 1);
			}
			return 0;
		}
	}

	// Token: 0x0600B962 RID: 47458 RVA: 0x00315278 File Offset: 0x00313478
	private int SortMonsterId(object a, object b, bool isAscending, object[] param)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomBattleData phantomBattleData = instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = instance.GetPhantomBattleData(uniqueId2);
			if (phantomBattleData.GetConfigId(false) != phantomBattleData2.GetConfigId(false))
			{
				return (phantomBattleData2.GetConfigId(false) - phantomBattleData.GetConfigId(false)) * (isAscending ? -1 : 1);
			}
			return 0;
		}
		else
		{
			IPhantomItemData phantomItemData = a as IPhantomItemData;
			IPhantomItemData phantomItemData2 = b as IPhantomItemData;
			if (phantomItemData == phantomItemData2)
			{
				return 0;
			}
			if (phantomItemData == null)
			{
				return 1;
			}
			if (phantomItemData2 == null)
			{
				return -1;
			}
			if (phantomItemData.MonsterId != phantomItemData2.MonsterId)
			{
				return (phantomItemData2.MonsterId - phantomItemData.MonsterId) * (isAscending ? -1 : 1);
			}
			return 0;
		}
	}

	// Token: 0x0600B963 RID: 47459 RVA: 0x00315374 File Offset: 0x00313574
	private int SortUniqueId(object a, object b, bool isAscending, object[] param)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			PhantomBattleModel instance = ModelBase<PhantomBattleModel>.Instance;
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomBattleData phantomBattleData = instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = instance.GetPhantomBattleData(uniqueId2);
			if (phantomBattleData.GetUniqueId() != phantomBattleData2.GetUniqueId())
			{
				return (phantomBattleData2.GetUniqueId() - phantomBattleData.GetUniqueId()) * (isAscending ? -1 : 1);
			}
			return 0;
		}
		else
		{
			IPhantomItemData phantomItemData = a as IPhantomItemData;
			IPhantomItemData phantomItemData2 = b as IPhantomItemData;
			if (phantomItemData == phantomItemData2)
			{
				return 0;
			}
			if (phantomItemData == null)
			{
				return 1;
			}
			if (phantomItemData2 == null)
			{
				return -1;
			}
			if (phantomItemData.Id != phantomItemData2.Id)
			{
				return (phantomItemData2.Id - phantomItemData.Id) * (isAscending ? -1 : 1);
			}
			return 0;
		}
	}

	// Token: 0x0600B964 RID: 47460 RVA: 0x0031546C File Offset: 0x0031366C
	private int GetPropValue(List<PhantomSortStruct> propData, int propKey, bool ifPercentage = false)
	{
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

	// Token: 0x0600B965 RID: 47461 RVA: 0x003154D8 File Offset: 0x003136D8
	private int SortMainLife(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 10002, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 10002, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B966 RID: 47462 RVA: 0x0031552C File Offset: 0x0031372C
	private int SortMainLifePercentage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 10002, true);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 10002, true);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B967 RID: 47463 RVA: 0x00315580 File Offset: 0x00313780
	private int SortMainAttack(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 10007, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 10007, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B968 RID: 47464 RVA: 0x003155D4 File Offset: 0x003137D4
	private int SortMainAttackPercentage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 10007, true);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 10007, true);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B969 RID: 47465 RVA: 0x00315628 File Offset: 0x00313828
	private int SortMainDefense(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 10010, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 10010, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B96A RID: 47466 RVA: 0x0031567C File Offset: 0x0031387C
	private int SortMainDefensePercentage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 10010, true);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 10010, true);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B96B RID: 47467 RVA: 0x003156D0 File Offset: 0x003138D0
	private int SortMainCrit(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 8, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 8, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B96C RID: 47468 RVA: 0x0031571C File Offset: 0x0031391C
	private int SortMainCritDamage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 9, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 9, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B96D RID: 47469 RVA: 0x00315768 File Offset: 0x00313968
	private int SortMainTreat(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 35, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 35, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B96E RID: 47470 RVA: 0x003157B4 File Offset: 0x003139B4
	private int SortMainPhysicsDamage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 21, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 21, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B96F RID: 47471 RVA: 0x00315800 File Offset: 0x00313A00
	private int SortMainIceAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 22, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 22, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B970 RID: 47472 RVA: 0x0031584C File Offset: 0x00313A4C
	private int SortMainFireAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 23, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 23, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B971 RID: 47473 RVA: 0x00315898 File Offset: 0x00313A98
	private int SortMainThunderAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 24, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 24, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B972 RID: 47474 RVA: 0x003158E4 File Offset: 0x00313AE4
	private int SortMainWindAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 25, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 25, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B973 RID: 47475 RVA: 0x00315930 File Offset: 0x00313B30
	private int SortMainLightAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 26, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 26, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B974 RID: 47476 RVA: 0x0031597C File Offset: 0x00313B7C
	private int SortMainDarkAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 27, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 27, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B975 RID: 47477 RVA: 0x003159C8 File Offset: 0x00313BC8
	private int SortMainEnergy(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.MainPropMap, 11, false);
		int propValue2 = this.GetPropValue(phantomItemData2.MainPropMap, 11, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B976 RID: 47478 RVA: 0x00315A14 File Offset: 0x00313C14
	private int SortSubLife(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 1, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 1, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B977 RID: 47479 RVA: 0x00315A60 File Offset: 0x00313C60
	private int SortSubLifePercentage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 4, true);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 4, true);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B978 RID: 47480 RVA: 0x00315AAC File Offset: 0x00313CAC
	private int SortSubAttack(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 2, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 2, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B979 RID: 47481 RVA: 0x00315AF8 File Offset: 0x00313CF8
	private int SortSubAttackPercentage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 5, true);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 5, true);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B97A RID: 47482 RVA: 0x00315B44 File Offset: 0x00313D44
	private int SortSubDefense(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 3, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 3, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B97B RID: 47483 RVA: 0x00315B90 File Offset: 0x00313D90
	private int SortSubDefensePercentage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 6, true);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 6, true);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B97C RID: 47484 RVA: 0x00315BDC File Offset: 0x00313DDC
	private int SortSubCrit(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 14, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 14, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B97D RID: 47485 RVA: 0x00315C28 File Offset: 0x00313E28
	private int SortSubCritDamage(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 15, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 15, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B97E RID: 47486 RVA: 0x00315C74 File Offset: 0x00313E74
	private int SortSubTreat(object a, object b, bool isAscending, object[] param)
	{
		return 0;
	}

	// Token: 0x0600B97F RID: 47487 RVA: 0x00315C78 File Offset: 0x00313E78
	private int SortSubWindAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 11, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 11, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B980 RID: 47488 RVA: 0x00315CC4 File Offset: 0x00313EC4
	private int SortSubLightAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 12, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 12, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B981 RID: 47489 RVA: 0x00315D10 File Offset: 0x00313F10
	private int SortSubDarkAttr(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 13, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 13, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B982 RID: 47490 RVA: 0x00315D5C File Offset: 0x00313F5C
	private int SortSubEnergy(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 13, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 13, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B983 RID: 47491 RVA: 0x00315DA8 File Offset: 0x00313FA8
	private int SortByEquipState(object a, object b, bool isAscending, object[] param)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomDataBase phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId2);
			int num = (phantomBattleData.GetEquipRoleId() > 0) ? 1 : 0;
			int num2 = (phantomBattleData2.GetEquipRoleId() > 0) ? 1 : 0;
			if (num != num2)
			{
				return (num - num2) * (isAscending ? -1 : 1);
			}
		}
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		if (phantomItemData == phantomItemData2)
		{
			return 0;
		}
		if (phantomItemData == null)
		{
			return 1;
		}
		if (phantomItemData2 == null)
		{
			return -1;
		}
		int num3 = (phantomItemData.Role > 0) ? 1 : 0;
		int num4 = (phantomItemData2.Role > 0) ? 1 : 0;
		if (num3 != num4)
		{
			return (num3 - num4) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B984 RID: 47492 RVA: 0x00315EA8 File Offset: 0x003140A8
	private int SortByCurrentRole(object a, object b, bool isAscending, object[] param)
	{
		if (param.Length == 0)
		{
			return 0;
		}
		int num = (int)param[0];
		if (num <= 0)
		{
			return 0;
		}
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomDataBase phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId2);
			int num2 = (phantomBattleData.GetEquipRoleId() == num) ? 1 : 0;
			int num3 = (phantomBattleData2.GetEquipRoleId() == num) ? 1 : 0;
			if ((num2 == 1 || num3 == 1) && num2 != num3)
			{
				int num4 = num2 - num3;
				return -1 * num4;
			}
		}
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		if (phantomItemData == phantomItemData2)
		{
			return 0;
		}
		if (phantomItemData == null)
		{
			return 1;
		}
		if (phantomItemData2 == null)
		{
			return -1;
		}
		int num5 = (phantomItemData.Role == num) ? 1 : 0;
		int num6 = (phantomItemData2.Role == num) ? 1 : 0;
		if ((num5 == 1 || num6 == 1) && num5 != num6)
		{
			int num7 = num5 - num6;
			return -1 * num7;
		}
		return 0;
	}

	// Token: 0x0600B985 RID: 47493 RVA: 0x00315FD0 File Offset: 0x003141D0
	private int SortLock(object a, object b, bool isAscending, object[] param)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomDataBase phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId2);
			int num = (phantomBattleData.GetIsLock() > false) ? 1 : 0;
			int num2 = (phantomBattleData2.GetIsLock() > false) ? 1 : 0;
			if (num != num2)
			{
				return num - num2;
			}
		}
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		if (phantomItemData == phantomItemData2)
		{
			return 0;
		}
		if (phantomItemData == null)
		{
			return 1;
		}
		if (phantomItemData2 == null)
		{
			return -1;
		}
		int num3 = (phantomItemData.IsLock > false) ? 1 : 0;
		int num4 = (phantomItemData2.IsLock > false) ? 1 : 0;
		if (num3 != num4)
		{
			return -1 * (num3 - num4);
		}
		return 0;
	}

	// Token: 0x0600B986 RID: 47494 RVA: 0x003160C0 File Offset: 0x003142C0
	private int SortDeprecateFirst(object a, object b, bool isAscending, object[] param)
	{
		return this.SortDeprecate(a, b, isAscending, null);
	}

	// Token: 0x0600B987 RID: 47495 RVA: 0x003160CC File Offset: 0x003142CC
	private int SortDeprecateLast(object a, object b, bool isAscending, object[] param)
	{
		return this.SortDeprecate(a, b, isAscending, null) * -1;
	}

	// Token: 0x0600B988 RID: 47496 RVA: 0x003160DC File Offset: 0x003142DC
	private int SortDeprecate(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomDataBase phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			PhantomBattleData phantomBattleData2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId2);
			int num = 1;
			int num2 = 0;
			int num3 = phantomBattleData.GetIsDeprecated() ? num : num2;
			int num4 = phantomBattleData2.GetIsDeprecated() ? num : num2;
			if (num3 != num4)
			{
				return (num4 - num3) * (isAscending ? 1 : -1);
			}
		}
		return 0;
	}

	// Token: 0x0600B989 RID: 47497 RVA: 0x003161A0 File Offset: 0x003143A0
	private int SortRarity(object a, object b, bool isAscending, object[] param)
	{
		if ((a is ItemViewData && b is ItemViewData) || (a is PhantomItemData && b is PhantomItemData))
		{
			int uniqueId = (a is ItemViewData) ? ((ItemViewData)a).GetUniqueId() : ((PhantomItemData)a).GetUniqueId();
			int uniqueId2 = (b is ItemViewData) ? ((ItemViewData)b).GetUniqueId() : ((PhantomItemData)b).GetUniqueId();
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			PhantomDataBase phantomBattleData2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId2);
			int rarity = phantomBattleData.GetConfig().Rarity;
			int rarity2 = phantomBattleData2.GetConfig().Rarity;
			if (rarity != rarity2)
			{
				return (rarity - rarity2) * (isAscending ? 1 : -1);
			}
		}
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		if (phantomItemData == phantomItemData2)
		{
			return 0;
		}
		if (phantomItemData == null)
		{
			return 1;
		}
		if (phantomItemData2 == null)
		{
			return -1;
		}
		int rarity3 = phantomItemData.Rarity;
		int rarity4 = phantomItemData2.Rarity;
		if (rarity3 != rarity4)
		{
			return (rarity3 - rarity4) * (isAscending ? 1 : -1);
		}
		return 0;
	}

	// Token: 0x0600B98A RID: 47498 RVA: 0x003162A4 File Offset: 0x003144A4
	private int SortSkin(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int[] monsterSkinListByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(phantomItemData.MonsterId);
		int num = (monsterSkinListByMonsterId != null) ? monsterSkinListByMonsterId.Length : 0;
		int[] monsterSkinListByMonsterId2 = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(phantomItemData2.MonsterId);
		int num2 = (monsterSkinListByMonsterId2 != null) ? monsterSkinListByMonsterId2.Length : 0;
		if (num != num2)
		{
			return (num2 - num) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B98B RID: 47499 RVA: 0x00316304 File Offset: 0x00314504
	private int SortSubComboHurt(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 7, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 7, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B98C RID: 47500 RVA: 0x00316350 File Offset: 0x00314550
	private int SortNormalHurt(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 8, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 8, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B98D RID: 47501 RVA: 0x0031639C File Offset: 0x0031459C
	private int SortChargeHurt(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 9, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 9, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B98E RID: 47502 RVA: 0x003163E8 File Offset: 0x003145E8
	private int SortComboReleaseHurt(object a, object b, bool isAscending, object[] param)
	{
		IPhantomItemData phantomItemData = a as IPhantomItemData;
		IPhantomItemData phantomItemData2 = b as IPhantomItemData;
		int propValue = this.GetPropValue(phantomItemData.SubPropMap, 10, false);
		int propValue2 = this.GetPropValue(phantomItemData2.SubPropMap, 10, false);
		if (propValue != propValue2)
		{
			return (propValue2 - propValue) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B98F RID: 47503 RVA: 0x00316434 File Offset: 0x00314634
	private int SortQualityDescend(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		return this.SortQuality(a, b, false, null);
	}

	// Token: 0x0600B990 RID: 47504 RVA: 0x00316440 File Offset: 0x00314640
	private int SortLevelAscend(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		int num = this.SortLevel(a, b, true, null);
		if (num != 0)
		{
			return num;
		}
		return this.SortGetExp(a, b, true, null);
	}

	// Token: 0x0600B991 RID: 47505 RVA: 0x00316468 File Offset: 0x00314668
	private int SortGetExp(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase.GetUniqueId());
		PhantomDataBase phantomDataBase2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase2.GetUniqueId());
		int num = 0;
		int num2 = 0;
		if (phantomDataBase != null)
		{
			num = phantomDataBase.GetEatFullExp();
		}
		else
		{
			IReadOnlyList<PhantomExpItem> phantomExpItemList = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemList();
			int count = phantomExpItemList.Count;
			for (int i = 0; i < count; i++)
			{
				if (phantomExpItemList[i].ItemId == itemDataBase.GetConfigId())
				{
					num = phantomExpItemList[i].Exp;
					break;
				}
			}
		}
		if (phantomDataBase2 != null)
		{
			num2 = phantomDataBase2.GetEatFullExp();
		}
		else
		{
			IReadOnlyList<PhantomExpItem> phantomExpItemList2 = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemList();
			int count2 = phantomExpItemList2.Count;
			for (int j = 0; j < count2; j++)
			{
				if (phantomExpItemList2[j].ItemId == itemDataBase2.GetConfigId())
				{
					num2 = phantomExpItemList2[j].Exp;
					break;
				}
			}
		}
		if (num != num2)
		{
			return (num2 - num) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B992 RID: 47506 RVA: 0x00316588 File Offset: 0x00314788
	private int SortIdentifyNum(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase.GetUniqueId());
		PhantomDataBase phantomDataBase2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase2.GetUniqueId());
		int num = phantomDataBase.GetCurrentIdentifyNum() - phantomDataBase2.GetCurrentIdentifyNum();
		if (!isAscending)
		{
			return -num;
		}
		return num;
	}

	// Token: 0x0600B993 RID: 47507 RVA: 0x003165D8 File Offset: 0x003147D8
	private int SortIdentifyNumDescend(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		return this.SortIdentifyNum(a, b, false, null);
	}

	// Token: 0x0600B994 RID: 47508 RVA: 0x003165E4 File Offset: 0x003147E4
	private int SortNonEquipFirst(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ItemDataBase itemDataBase = a as ItemDataBase;
		ItemDataBase itemDataBase2 = b as ItemDataBase;
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase.GetUniqueId());
		PhantomDataBase phantomDataBase2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(itemDataBase2.GetUniqueId());
		int equipRoleId = phantomDataBase.GetEquipRoleId();
		int equipRoleId2 = phantomDataBase2.GetEquipRoleId();
		if ((equipRoleId == 0 && equipRoleId2 == 0) || (equipRoleId != 0 && equipRoleId2 != 0))
		{
			return 0;
		}
		if (equipRoleId == 0)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x0600B995 RID: 47509 RVA: 0x00316644 File Offset: 0x00314844
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EPhantomSortWayType.Level, new TSortResult(this.SortLevel));
		this.SortMap.Add(EPhantomSortWayType.Breach, new TSortResult(this.SortBreach));
		this.SortMap.Add(EPhantomSortWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(EPhantomSortWayType.MonsterId, new TSortResult(this.SortMonsterId));
		this.SortMap.Add(EPhantomSortWayType.UniqueId, new TSortResult(this.SortUniqueId));
		this.SortMap.Add(EPhantomSortWayType.MainAttack, new TSortResult(this.SortMainAttack));
		this.SortMap.Add(EPhantomSortWayType.MainAttackPercentage, new TSortResult(this.SortMainAttackPercentage));
		this.SortMap.Add(EPhantomSortWayType.MainLife, new TSortResult(this.SortMainLife));
		this.SortMap.Add(EPhantomSortWayType.MainLifePercentage, new TSortResult(this.SortMainLifePercentage));
		this.SortMap.Add(EPhantomSortWayType.MainDefense, new TSortResult(this.SortMainDefense));
		this.SortMap.Add(EPhantomSortWayType.MainDefensePercentage, new TSortResult(this.SortMainDefensePercentage));
		this.SortMap.Add(EPhantomSortWayType.MainCrit, new TSortResult(this.SortMainCrit));
		this.SortMap.Add(EPhantomSortWayType.MainCritHurt, new TSortResult(this.SortMainCritDamage));
		this.SortMap.Add(EPhantomSortWayType.MainTreat, new TSortResult(this.SortMainTreat));
		this.SortMap.Add(EPhantomSortWayType.MainPhysicsHurt, new TSortResult(this.SortMainPhysicsDamage));
		this.SortMap.Add(EPhantomSortWayType.MainIceHurt, new TSortResult(this.SortMainIceAttr));
		this.SortMap.Add(EPhantomSortWayType.MainFireHurt, new TSortResult(this.SortMainFireAttr));
		this.SortMap.Add(EPhantomSortWayType.MainThunderHurt, new TSortResult(this.SortMainThunderAttr));
		this.SortMap.Add(EPhantomSortWayType.MainWindHurt, new TSortResult(this.SortMainWindAttr));
		this.SortMap.Add(EPhantomSortWayType.MainLightHurt, new TSortResult(this.SortMainLightAttr));
		this.SortMap.Add(EPhantomSortWayType.MainDarkHurt, new TSortResult(this.SortMainDarkAttr));
		this.SortMap.Add(EPhantomSortWayType.MainEnergy, new TSortResult(this.SortMainEnergy));
		this.SortMap.Add(EPhantomSortWayType.SubAttack, new TSortResult(this.SortSubAttack));
		this.SortMap.Add(EPhantomSortWayType.SubAttackPercentage, new TSortResult(this.SortSubAttackPercentage));
		this.SortMap.Add(EPhantomSortWayType.SubLife, new TSortResult(this.SortSubLife));
		this.SortMap.Add(EPhantomSortWayType.SubLifePercentage, new TSortResult(this.SortSubLifePercentage));
		this.SortMap.Add(EPhantomSortWayType.SubDefense, new TSortResult(this.SortSubDefense));
		this.SortMap.Add(EPhantomSortWayType.SubDefensePercentage, new TSortResult(this.SortSubDefensePercentage));
		this.SortMap.Add(EPhantomSortWayType.SubCrit, new TSortResult(this.SortSubCrit));
		this.SortMap.Add(EPhantomSortWayType.SubCritHurt, new TSortResult(this.SortSubCritDamage));
		this.SortMap.Add(EPhantomSortWayType.SubTreat, new TSortResult(this.SortSubTreat));
		this.SortMap.Add(EPhantomSortWayType.SubWindHurt, new TSortResult(this.SortSubWindAttr));
		this.SortMap.Add(EPhantomSortWayType.SubLightHurt, new TSortResult(this.SortSubLightAttr));
		this.SortMap.Add(EPhantomSortWayType.SubDarkHurt, new TSortResult(this.SortSubDarkAttr));
		this.SortMap.Add(EPhantomSortWayType.SubEnergy, new TSortResult(this.SortSubEnergy));
		this.SortMap.Add(EPhantomSortWayType.Exp, new TSortResult(this.SortExp));
		this.SortMap.Add(EPhantomSortWayType.ExpItem, new TSortResult(this.SortExpFirst));
		this.SortMap.Add(EPhantomSortWayType.EquipState, new TSortResult(this.SortByEquipState));
		this.SortMap.Add(EPhantomSortWayType.CurrentRoleEquip, new TSortResult(this.SortByCurrentRole));
		this.SortMap.Add(EPhantomSortWayType.Lock, new TSortResult(this.SortLock));
		this.SortMap.Add(EPhantomSortWayType.Rarity, new TSortResult(this.SortRarity));
		this.SortMap.Add(EPhantomSortWayType.Skin, new TSortResult(this.SortSkin));
		this.SortMap.Add(EPhantomSortWayType.SubComboHurt, new TSortResult(this.SortSubComboHurt));
		this.SortMap.Add(EPhantomSortWayType.SubNormalHurt, new TSortResult(this.SortNormalHurt));
		this.SortMap.Add(EPhantomSortWayType.SubChargeHurt, new TSortResult(this.SortChargeHurt));
		this.SortMap.Add(EPhantomSortWayType.SubComboReleaseHurt, new TSortResult(this.SortComboReleaseHurt));
		this.SortMap.Add(EPhantomSortWayType.DeprecateFirst, new TSortResult(this.SortDeprecateFirst));
		this.SortMap.Add(EPhantomSortWayType.DeprecateLast, new TSortResult(this.SortDeprecateLast));
		this.SortMap.Add(EPhantomSortWayType.QualityFiveFirst, new TSortResult(this.SortQualityDescend));
		this.SortMap.Add(EPhantomSortWayType.LevelOneFirst, new TSortResult(this.SortLevelAscend));
		this.SortMap.Add(EPhantomSortWayType.SortGetExp, new TSortResult(this.SortGetExp));
		this.SortMap.Add(EPhantomSortWayType.IdentifyNumHighFirst, new TSortResult(this.SortIdentifyNumDescend));
		this.SortMap.Add(EPhantomSortWayType.NonEquipFirst, new TSortResult(this.SortNonEquipFirst));
	}
}
