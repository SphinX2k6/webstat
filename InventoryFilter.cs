using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using FilterDefine;

// Token: 0x020018EA RID: 6378
[NullableContext(1)]
[Nullable(0)]
public class InventoryFilter : CommonFilter
{
	// Token: 0x0600B743 RID: 46915 RVA: 0x0030C401 File Offset: 0x0030A601
	private object GetItemQualityId(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((global::ItemViewData)data).GetQuality();
	}

	// Token: 0x0600B744 RID: 46916 RVA: 0x0030C414 File Offset: 0x0030A614
	private object GetWeaponTypeId(object data, Dictionary<int, string> currentSelectMap)
	{
		global::ItemViewData itemViewData = (global::ItemViewData)data;
		int configId = itemViewData.GetConfigId();
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(configId)) != InventoryDefine.EItemDataType.WeaponItem)
		{
			return null;
		}
		int uniqueId = itemViewData.GetUniqueId();
		WeaponItemData weaponItemData = ModelBase<InventoryModel>.Instance.GetWeaponItemData(uniqueId);
		if (weaponItemData == null)
		{
			return null;
		}
		return weaponItemData.GetConfig().As<WeaponConf>().Value.WeaponType;
	}

	// Token: 0x0600B745 RID: 46917 RVA: 0x0030C480 File Offset: 0x0030A680
	private object GetPhantomItemId(object data, Dictionary<int, string> currentSelectMap)
	{
		global::ItemViewData itemViewData = (global::ItemViewData)data;
		int configId = itemViewData.GetConfigId();
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(configId)) != InventoryDefine.EItemDataType.PhantomItem)
		{
			return null;
		}
		int uniqueId = itemViewData.GetUniqueId();
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
		if (phantomBattleData == null)
		{
			return null;
		}
		return phantomBattleData.GetMonsterId(false);
	}

	// Token: 0x0600B746 RID: 46918 RVA: 0x0030C4D4 File Offset: 0x0030A6D4
	private bool GetSelectOnState(object data)
	{
		global::ItemViewData itemViewData = (global::ItemViewData)data;
		bool selectOn = itemViewData.GetSelectOn();
		bool flag = itemViewData.GetItemOperationType() == ItemViewDefine.EItemOperationMode.Destruction;
		return selectOn && flag;
	}

	// Token: 0x0600B747 RID: 46919 RVA: 0x0030C4FC File Offset: 0x0030A6FC
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.ItemQuality, new TFilterConfig(this.GetItemQualityId));
		this.FilterMap.Add(FilterDefine.EFilterType.Weapon, new TFilterConfig(this.GetWeaponTypeId));
		this.FilterMap.Add(FilterDefine.EFilterType.Phantom, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity1, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity2, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity3, new TFilterConfig(this.GetPhantomItemId));
		this.FilterMap.Add(FilterDefine.EFilterType.VisionRarity4, new TFilterConfig(this.GetPhantomItemId));
		Dictionary<FilterDefine.EFilterType, TFilterConfig> filterMap = this.FilterMap;
		FilterDefine.EFilterType key = FilterDefine.EFilterType.PhantomRarity;
		TFilterConfig value;
		if ((value = InventoryFilter.<>O.<0>__GetPhantomRarity) == null)
		{
			value = (InventoryFilter.<>O.<0>__GetPhantomRarity = new TFilterConfig(VisionDestroyFilterLogic.GetPhantomRarity));
		}
		filterMap.Add(key, value);
		Dictionary<FilterDefine.EFilterType, TFilterConfig> filterMap2 = this.FilterMap;
		FilterDefine.EFilterType key2 = FilterDefine.EFilterType.VisionDestroyCost;
		TFilterConfig value2;
		if ((value2 = InventoryFilter.<>O.<1>__GetPhantomCost) == null)
		{
			value2 = (InventoryFilter.<>O.<1>__GetPhantomCost = new TFilterConfig(VisionDestroyFilterLogic.GetPhantomCost));
		}
		filterMap2.Add(key2, value2);
		Dictionary<FilterDefine.EFilterType, TFilterConfig> filterMap3 = this.FilterMap;
		FilterDefine.EFilterType key3 = FilterDefine.EFilterType.VisionDestroyQuality;
		TFilterConfig value3;
		if ((value3 = InventoryFilter.<>O.<2>__GetPhantomQuality) == null)
		{
			value3 = (InventoryFilter.<>O.<2>__GetPhantomQuality = new TFilterConfig(VisionDestroyFilterLogic.GetPhantomQuality));
		}
		filterMap3.Add(key3, value3);
		Dictionary<FilterDefine.EFilterType, TFilterConfig> filterMap4 = this.FilterMap;
		FilterDefine.EFilterType key4 = FilterDefine.EFilterType.VisionDestroyFetterGroup;
		TFilterConfig value4;
		if ((value4 = InventoryFilter.<>O.<3>__GetVisionDestroyFetterGroup) == null)
		{
			value4 = (InventoryFilter.<>O.<3>__GetVisionDestroyFetterGroup = new TFilterConfig(VisionDestroyFilterLogic.GetVisionDestroyFetterGroup));
		}
		filterMap4.Add(key4, value4);
		Dictionary<FilterDefine.EFilterType, TFilterConfig> filterMap5 = this.FilterMap;
		FilterDefine.EFilterType key5 = FilterDefine.EFilterType.VisionDestroyAttribute;
		TFilterConfig value5;
		if ((value5 = InventoryFilter.<>O.<4>__GetVisionDestroyAttribute) == null)
		{
			value5 = (InventoryFilter.<>O.<4>__GetVisionDestroyAttribute = new TFilterConfig(VisionDestroyFilterLogic.GetVisionDestroyAttribute));
		}
		filterMap5.Add(key5, value5);
		Dictionary<FilterDefine.EFilterType, TFilterConfig> filterMap6 = this.FilterMap;
		FilterDefine.EFilterType key6 = FilterDefine.EFilterType.PhantomDeprecate;
		TFilterConfig value6;
		if ((value6 = InventoryFilter.<>O.<5>__GetPhantomDeprecate) == null)
		{
			value6 = (InventoryFilter.<>O.<5>__GetPhantomDeprecate = new TFilterConfig(VisionDestroyFilterLogic.GetPhantomDeprecate));
		}
		filterMap6.Add(key6, value6);
	}

	// Token: 0x0600B748 RID: 46920 RVA: 0x0030C6A6 File Offset: 0x0030A8A6
	public override TDefaultFilter[] DefaultFilterList()
	{
		return new TDefaultFilter[]
		{
			new TDefaultFilter(this.GetSelectOnState)
		};
	}

	// Token: 0x02007C51 RID: 31825
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402A76B RID: 173931
		[Nullable(0)]
		public static TFilterConfig <0>__GetPhantomRarity;

		// Token: 0x0402A76C RID: 173932
		[Nullable(0)]
		public static TFilterConfig <1>__GetPhantomCost;

		// Token: 0x0402A76D RID: 173933
		[Nullable(0)]
		public static TFilterConfig <2>__GetPhantomQuality;

		// Token: 0x0402A76E RID: 173934
		[Nullable(0)]
		public static TFilterConfig <3>__GetVisionDestroyFetterGroup;

		// Token: 0x0402A76F RID: 173935
		[Nullable(0)]
		public static TFilterConfig <4>__GetVisionDestroyAttribute;

		// Token: 0x0402A770 RID: 173936
		[Nullable(0)]
		public static TFilterConfig <5>__GetPhantomDeprecate;
	}
}
