using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using FilterDefine;

// Token: 0x02002013 RID: 8211
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class InventoryModel : ModelBase<InventoryModel>
{
	// Token: 0x1700128F RID: 4751
	// (get) Token: 0x0600F8B4 RID: 63668 RVA: 0x00443064 File Offset: 0x00441264
	private NormalInventoryDataProxy DefaultProxy
	{
		get
		{
			NormalInventoryDataProxy result;
			if ((result = this._DefaultProxy) == null)
			{
				result = (this._DefaultProxy = new NormalInventoryDataProxy(this));
			}
			return result;
		}
	}

	// Token: 0x17001290 RID: 4752
	// (get) Token: 0x0600F8B5 RID: 63669 RVA: 0x0044308A File Offset: 0x0044128A
	// (set) Token: 0x0600F8B6 RID: 63670 RVA: 0x0044309C File Offset: 0x0044129C
	private InventoryDataProxy CurrentProxy
	{
		get
		{
			return this._CurrentProxy ?? this.DefaultProxy;
		}
		set
		{
			this._CurrentProxy = value;
		}
	}

	// Token: 0x0600F8B7 RID: 63671 RVA: 0x004430A5 File Offset: 0x004412A5
	public void SetItemNeedCount(int? itemNeedCount)
	{
		this.ItemNeedCount = itemNeedCount;
	}

	// Token: 0x0600F8B8 RID: 63672 RVA: 0x004430AE File Offset: 0x004412AE
	public int? GetItemNeedCount()
	{
		return this.ItemNeedCount;
	}

	// Token: 0x0600F8B9 RID: 63673 RVA: 0x004430B6 File Offset: 0x004412B6
	protected override bool OnInit()
	{
		if (ConfigBase<InventoryConfig>.Instance.GetAllMainTypeConfig().Count <= 0)
		{
			return false;
		}
		this.SetSelectedTypeIndex(0);
		return true;
	}

	// Token: 0x0600F8BA RID: 63674 RVA: 0x004430D4 File Offset: 0x004412D4
	protected override bool OnClear()
	{
		this.ClearAllItemData();
		foreach (TimerHandle handle in this.CdTimeStampHandleMap.Values)
		{
			TimerSystem.RealTimeInstance.Remove(handle);
		}
		this.CdTimeStampHandleMap.Clear();
		return true;
	}

	// Token: 0x0600F8BB RID: 63675 RVA: 0x00443144 File Offset: 0x00441344
	public void RefreshItemRedDotSet()
	{
		NewFlagModel instance = ModelBase<NewFlagModel>.Instance;
		HashSet<int> newFlagSet = instance.GetNewFlagSet(ELocalStoragePlayerKey.InventoryCommonItemRedDot);
		if (newFlagSet != null && newFlagSet.Count > 0)
		{
			bool flag = false;
			foreach (int num in newFlagSet)
			{
				bool flag2 = false;
				if (this.GetCommonItemCount(num, 0) <= 0)
				{
					flag2 = true;
				}
				else
				{
					CommonItemData commonItemData = this.GetCommonItemData(num, 0);
					if (commonItemData != null)
					{
						InventoryDefine.ERedDotDisableRule redDotDisableRule = commonItemData.GetRedDotDisableRule();
						if (redDotDisableRule == InventoryDefine.ERedDotDisableRule.ServerFirstSelect || redDotDisableRule == InventoryDefine.ERedDotDisableRule.None)
						{
							flag2 = true;
						}
					}
				}
				if (flag2)
				{
					instance.RemoveNewFlag(ELocalStoragePlayerKey.InventoryCommonItemRedDot, num);
					flag = true;
				}
			}
			if (flag)
			{
				this.SaveRedDotCommonItemConfigIdList();
			}
		}
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ItemBackpackFirstCheck) as ServerStorageMap;
		if (serverStorageMap != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in serverStorageMap.GetContainer())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				bool flag3 = false;
				CommonItemData commonItemData2 = this.GetCommonItemData(key, 0);
				if (value == 1 && this.GetCommonItemCount(key, 0) <= 0)
				{
					flag3 = true;
				}
				if (commonItemData2 != null && commonItemData2.GetRedDotDisableRule() != InventoryDefine.ERedDotDisableRule.ServerFirstSelect)
				{
					flag3 = true;
				}
				if (flag3)
				{
					serverStorageMap.Delete(key);
				}
			}
		}
		HashSet<int> newFlagSet2 = instance.GetNewFlagSet(ELocalStoragePlayerKey.InventoryAttributeItemRedDot);
		if (newFlagSet2 != null)
		{
			bool flag4 = false;
			foreach (int num2 in newFlagSet2)
			{
				AttributeItemData attributeItemData = this.GetAttributeItemData(num2);
				if (attributeItemData == null)
				{
					instance.RemoveNewFlag(ELocalStoragePlayerKey.InventoryAttributeItemRedDot, num2);
					flag4 = true;
				}
				else if (attributeItemData != null && attributeItemData.GetCount() <= 0)
				{
					instance.RemoveNewFlag(ELocalStoragePlayerKey.InventoryAttributeItemRedDot, num2);
					flag4 = true;
				}
			}
			if (flag4)
			{
				this.SaveRedDotAttributeItemUniqueIdList();
			}
		}
	}

	// Token: 0x0600F8BC RID: 63676 RVA: 0x0044332C File Offset: 0x0044152C
	public void SetInventoryTabOpenIdList(List<int> idList)
	{
		this.InventoryTabOpenIdList = idList;
	}

	// Token: 0x0600F8BD RID: 63677 RVA: 0x00443335 File Offset: 0x00441535
	public List<ItemMainType> GetOpenIdMainTypeConfig()
	{
		return this.CurrentProxy.GetOpenIdMainTypeConfig();
	}

	// Token: 0x0600F8BE RID: 63678 RVA: 0x00443344 File Offset: 0x00441544
	public List<ItemMainType> GetOpenIdMainTypeConfigBase()
	{
		List<ItemMainType> list = new List<ItemMainType>();
		foreach (int itemTypeId in this.InventoryTabOpenIdList)
		{
			ItemMainType? itemMainTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemMainTypeConfig(itemTypeId);
			if (itemMainTypeConfig != null && itemMainTypeConfig.Value.BShowInInventoryView)
			{
				list.Add(itemMainTypeConfig.Value);
			}
		}
		list.Sort((ItemMainType a, ItemMainType b) => a.SequenceId - b.SequenceId);
		return list;
	}

	// Token: 0x0600F8BF RID: 63679 RVA: 0x004433F0 File Offset: 0x004415F0
	public InventoryDefine.EItemMainTypeId? GetCurrentMainTypeId()
	{
		List<ItemMainType> openIdMainTypeConfig = this.GetOpenIdMainTypeConfig();
		if (openIdMainTypeConfig.Count <= 0)
		{
			return null;
		}
		int selectedTypeIndex = this.GetSelectedTypeIndex();
		if (selectedTypeIndex < 0 || selectedTypeIndex >= openIdMainTypeConfig.Count)
		{
			return null;
		}
		return new InventoryDefine.EItemMainTypeId?((InventoryDefine.EItemMainTypeId)openIdMainTypeConfig[selectedTypeIndex].Id);
	}

	// Token: 0x0600F8C0 RID: 63680 RVA: 0x0044344C File Offset: 0x0044164C
	public bool IsResourceOrMaterialTab()
	{
		InventoryDefine.EItemMainTypeId? currentMainTypeId = this.GetCurrentMainTypeId();
		return currentMainTypeId.GetValueOrDefault() == InventoryDefine.EItemMainTypeId.Material || currentMainTypeId.GetValueOrDefault() == InventoryDefine.EItemMainTypeId.Collection;
	}

	// Token: 0x0600F8C1 RID: 63681 RVA: 0x00443478 File Offset: 0x00441678
	private void AddToItemTypeMap(ItemDataBase itemDataBase)
	{
		InventoryDefine.EItemType? type = itemDataBase.GetType();
		HashSet<ItemDataBase> hashSet;
		if (!this.ItemTypeMap.TryGetValue(type.Value, out hashSet))
		{
			hashSet = new HashSet<ItemDataBase>();
			this.ItemTypeMap.Add(type.Value, hashSet);
		}
		hashSet.Add(itemDataBase);
	}

	// Token: 0x0600F8C2 RID: 63682 RVA: 0x004434C4 File Offset: 0x004416C4
	private void RemoveFromItemTypeMap(ItemDataBase itemDataBase)
	{
		InventoryDefine.EItemType? type = itemDataBase.GetType();
		HashSet<ItemDataBase> hashSet;
		if (this.ItemTypeMap.TryGetValue(type.Value, out hashSet))
		{
			hashSet.Remove(itemDataBase);
		}
	}

	// Token: 0x0600F8C3 RID: 63683 RVA: 0x004434F6 File Offset: 0x004416F6
	private void ClearFromItemTypeMap(InventoryDefine.EItemType itemType)
	{
		this.ItemTypeMap.Remove(itemType);
	}

	// Token: 0x0600F8C4 RID: 63684 RVA: 0x00443508 File Offset: 0x00441708
	private void AddToItemMainTypeMap(ItemDataBase itemDataBase)
	{
		InventoryDefine.EItemMainTypeId? mainType = itemDataBase.GetMainType();
		global::ItemMainTypeMapping itemMainTypeMapping;
		if (!this.ItemMainTypeMap.TryGetValue(mainType.Value, out itemMainTypeMapping))
		{
			itemMainTypeMapping = new global::ItemMainTypeMapping(mainType.Value);
			this.ItemMainTypeMap.Add(mainType.Value, itemMainTypeMapping);
		}
		itemMainTypeMapping.Add(itemDataBase);
	}

	// Token: 0x0600F8C5 RID: 63685 RVA: 0x0044355C File Offset: 0x0044175C
	private void RemoveFromItemMainTypeMap(ItemDataBase itemDataBase)
	{
		InventoryDefine.EItemMainTypeId? mainType = itemDataBase.GetMainType();
		global::ItemMainTypeMapping itemMainTypeMapping;
		if (this.ItemMainTypeMap.TryGetValue(mainType.Value, out itemMainTypeMapping))
		{
			itemMainTypeMapping.Remove(itemDataBase);
		}
	}

	// Token: 0x0600F8C6 RID: 63686 RVA: 0x0044358D File Offset: 0x0044178D
	private void ClearFromItemMainTypeMap(InventoryDefine.EItemMainTypeId itemMainType)
	{
		this.ItemMainTypeMap.Remove(itemMainType);
	}

	// Token: 0x0600F8C7 RID: 63687 RVA: 0x0044359C File Offset: 0x0044179C
	private void AddToCommonItemByItemTypeMap(CommonItemData commonItemData)
	{
		InventoryDefine.EItemType? type = commonItemData.GetType();
		HashSet<CommonItemData> hashSet;
		if (!this.CommonItemByItemTypeMap.TryGetValue(type.Value, out hashSet))
		{
			hashSet = new HashSet<CommonItemData>();
			this.CommonItemByItemTypeMap[type.Value] = hashSet;
		}
		hashSet.Add(commonItemData);
	}

	// Token: 0x0600F8C8 RID: 63688 RVA: 0x004435E8 File Offset: 0x004417E8
	private void RemoveFromCommonItemByItemTypeMap(CommonItemData commonItemData)
	{
		InventoryDefine.EItemType? type = commonItemData.GetType();
		HashSet<CommonItemData> hashSet;
		if (!this.CommonItemByItemTypeMap.TryGetValue(type.Value, out hashSet))
		{
			return;
		}
		hashSet.Remove(commonItemData);
	}

	// Token: 0x0600F8C9 RID: 63689 RVA: 0x0044361B File Offset: 0x0044181B
	private void ClearFromCommonItemByItemTypeMap(InventoryDefine.EItemType itemType)
	{
		this.CommonItemByItemTypeMap.Remove(itemType);
	}

	// Token: 0x0600F8CA RID: 63690 RVA: 0x0044362C File Offset: 0x0044182C
	public void NewCommonItemData(int configId, int count, int uniqueId = 0, long? endTime = null)
	{
		CommonItemData commonItemData = new CommonItemData(configId, uniqueId, count, InventoryDefine.EItemDataType.CommonItem, endTime);
		Dictionary<int, CommonItemData> dictionary;
		if (!this.CommonItemMap.TryGetValue(configId, out dictionary))
		{
			dictionary = new Dictionary<int, CommonItemData>();
		}
		CommonItemData commonItemData2;
		if (dictionary.TryGetValue(uniqueId, out commonItemData2))
		{
			return;
		}
		dictionary.TryAdd(uniqueId, commonItemData);
		this.CommonItemMap.TryAdd(configId, dictionary);
		this.AddToCommonItemByItemTypeMap(commonItemData);
		this.AddToItemTypeMap(commonItemData);
		this.AddToItemMainTypeMap(commonItemData);
		this.TryAddItemCoolDownTimer(commonItemData);
	}

	// Token: 0x0600F8CB RID: 63691 RVA: 0x0044369C File Offset: 0x0044189C
	public void RemoveCommonItemData(int configId, int uniqueId = 0)
	{
		Dictionary<int, CommonItemData> dictionary;
		if (!this.CommonItemMap.TryGetValue(configId, out dictionary))
		{
			return;
		}
		CommonItemData commonItemData;
		if (!dictionary.TryGetValue(uniqueId, out commonItemData))
		{
			return;
		}
		dictionary.Remove(uniqueId);
		if (dictionary.Count == 0)
		{
			this.CommonItemMap.Remove(configId);
		}
		this.RemoveFromItemTypeMap(commonItemData);
		this.RemoveFromItemMainTypeMap(commonItemData);
		this.RemoveFromCommonItemByItemTypeMap(commonItemData);
	}

	// Token: 0x0600F8CC RID: 63692 RVA: 0x004436F8 File Offset: 0x004418F8
	public void RemoveCommonItemDataAndSaveNewList(List<InventoryDefine.IGetItemData> commonItemList)
	{
		foreach (InventoryDefine.IGetItemData getItemData in commonItemList)
		{
			this.RemoveCommonItemData(getItemData.ItemId, getItemData.IncId);
			this.RemoveNewCommonItem(getItemData.ItemId, getItemData.IncId);
			this.RemoveRedDotCommonItem(getItemData.ItemId, getItemData.IncId);
		}
		this.SaveNewCommonItemConfigIdList();
		this.SaveNewAttributeItemUniqueIdList();
		this.SaveRedDotCommonItemConfigIdList();
		this.SaveRedDotAttributeItemUniqueIdList();
	}

	// Token: 0x0600F8CD RID: 63693 RVA: 0x00443794 File Offset: 0x00441994
	private void TryAddItemCoolDownTimer(CommonItemData itemData)
	{
		if (itemData.GetEndTime() > 0L)
		{
			if (itemData.IsOverTime())
			{
				ControllerBase<InventoryController>.Instance.InvalidItemRemoveRequest();
				return;
			}
			long endTime = itemData.GetEndTime() + 20L;
			if (this.CdTimeStampSet.Contains(endTime))
			{
				return;
			}
			string reason = StringUtils.Format(this.CD_TIME_REASON, new string[]
			{
				itemData.GetConfigId().ToString(),
				itemData.GetUniqueId().ToString()
			});
			TimerHandle timerHandle = TimerSystem.RealTimeInstance.EmitOnTime(delegate(float time)
			{
				this.CdTimeStampCheck(endTime);
			}, (double)endTime, null, reason, true, 1f);
			if (timerHandle == null)
			{
				return;
			}
			this.CdTimeStampSet.Add(endTime);
			this.CdTimeStampHandleMap[endTime] = timerHandle;
		}
	}

	// Token: 0x0600F8CE RID: 63694 RVA: 0x00443874 File Offset: 0x00441A74
	private void CdTimeStampCheck(long endTime)
	{
		ControllerBase<InventoryController>.Instance.InvalidItemRemoveRequest();
		TimerHandle handle;
		if (this.CdTimeStampHandleMap.TryGetValue(endTime, out handle))
		{
			TimerSystem.RealTimeInstance.Remove(handle);
			this.CdTimeStampHandleMap.Remove(endTime);
		}
		this.CdTimeStampSet.Remove(endTime);
	}

	// Token: 0x0600F8CF RID: 63695 RVA: 0x004438C4 File Offset: 0x00441AC4
	[NullableContext(2)]
	public CommonItemData GetCommonItemData(int configId, int uniqueId = 0)
	{
		Dictionary<int, CommonItemData> dictionary;
		if (!this.CommonItemMap.TryGetValue(configId, out dictionary))
		{
			return null;
		}
		CommonItemData commonItemData;
		if (!dictionary.TryGetValue(uniqueId, out commonItemData))
		{
			return null;
		}
		if (!commonItemData.IsValid())
		{
			return null;
		}
		return commonItemData;
	}

	// Token: 0x0600F8D0 RID: 63696 RVA: 0x004438FC File Offset: 0x00441AFC
	public List<CommonItemData> GetAllCommonItemDataByConfigId(int configId)
	{
		List<CommonItemData> list = new List<CommonItemData>();
		Dictionary<int, CommonItemData> dictionary;
		if (!this.CommonItemMap.TryGetValue(configId, out dictionary))
		{
			return list;
		}
		foreach (CommonItemData commonItemData in new List<CommonItemData>(dictionary.Values))
		{
			if (commonItemData.IsValid())
			{
				list.Add(commonItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8D1 RID: 63697 RVA: 0x00443978 File Offset: 0x00441B78
	public List<ItemDataBase> GetItemDataBaseByConfigId(int configId)
	{
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(configId));
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponItem)
		{
			return this.GetAllWeaponItemDataByConfigId(configId).Cast<ItemDataBase>().ToList<ItemDataBase>();
		}
		if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.PhantomItem)
		{
			return this.GetAllCommonItemDataByConfigId(configId).Cast<ItemDataBase>().ToList<ItemDataBase>();
		}
		return this.GetAllPhantomItemDataByConfigId(configId).Cast<ItemDataBase>().ToList<ItemDataBase>();
	}

	// Token: 0x0600F8D2 RID: 63698 RVA: 0x004439D8 File Offset: 0x00441BD8
	public List<PhantomItemData> GetAllPhantomItemDataByConfigId(int configId)
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (PhantomItemData phantomItemData in this.GetAllPhantomItemDataIterator())
		{
			if (phantomItemData.GetConfigId() == configId)
			{
				list.Add(phantomItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8D3 RID: 63699 RVA: 0x00443A3C File Offset: 0x00441C3C
	public List<WeaponItemData> GetAllWeaponItemDataByConfigId(int configId)
	{
		List<WeaponItemData> list = new List<WeaponItemData>();
		foreach (WeaponItemData weaponItemData in this.GetWeaponItemDataList())
		{
			if (weaponItemData.GetConfigId() == configId)
			{
				list.Add(weaponItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8D4 RID: 63700 RVA: 0x00443AA0 File Offset: 0x00441CA0
	public List<WeaponItemData> GetAllWeaponItemDataByQualityAndType(int quality, int weaponType)
	{
		List<WeaponItemData> list = new List<WeaponItemData>();
		foreach (WeaponItemData weaponItemData in this.GetWeaponItemDataList())
		{
			if ((quality == 0 || weaponItemData.GetQuality() == quality) && (weaponType == 0 || weaponItemData.WeaponConfig.WeaponType == weaponType))
			{
				list.Add(weaponItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8D5 RID: 63701 RVA: 0x00443B1C File Offset: 0x00441D1C
	public int GetCommonItemCount(int configId, int uniqueId = 0)
	{
		CommonItemData commonItemData = this.GetCommonItemData(configId, uniqueId);
		if (commonItemData == null)
		{
			return 0;
		}
		return commonItemData.GetCount();
	}

	// Token: 0x0600F8D6 RID: 63702 RVA: 0x00443B40 File Offset: 0x00441D40
	public void NewWeaponItemData(int configId, int uniqueId, int functionValue)
	{
		if (this.WeaponItemMap.ContainsKey(uniqueId))
		{
			return;
		}
		WeaponItemData weaponItemData = new WeaponItemData(configId, uniqueId, functionValue, InventoryDefine.EItemDataType.WeaponItem);
		this.WeaponItemMap.TryAdd(uniqueId, weaponItemData);
		this.AddToItemTypeMap(weaponItemData);
		this.AddToItemMainTypeMap(weaponItemData);
	}

	// Token: 0x0600F8D7 RID: 63703 RVA: 0x00443B84 File Offset: 0x00441D84
	public void RemoveWeaponItemData(int uniqueId)
	{
		WeaponItemData itemDataBase;
		if (!this.WeaponItemMap.TryGetValue(uniqueId, out itemDataBase))
		{
			return;
		}
		this.WeaponItemMap.Remove(uniqueId);
		this.RemoveFromItemTypeMap(itemDataBase);
		this.RemoveFromItemMainTypeMap(itemDataBase);
	}

	// Token: 0x0600F8D8 RID: 63704 RVA: 0x00443BC0 File Offset: 0x00441DC0
	public void RemoveWeaponItemDataAndSaveNewList(IReadOnlyList<int> weaponUniqueIdList)
	{
		foreach (int uniqueId in weaponUniqueIdList)
		{
			this.RemoveWeaponItemData(uniqueId);
			this.RemoveNewAttributeItem(uniqueId);
			this.RemoveRedDotAttributeItem(uniqueId);
		}
		this.SaveNewAttributeItemUniqueIdList();
		this.SaveRedDotAttributeItemUniqueIdList();
	}

	// Token: 0x0600F8D9 RID: 63705 RVA: 0x00443C28 File Offset: 0x00441E28
	[NullableContext(2)]
	public WeaponItemData GetWeaponItemData(int uniqueId)
	{
		WeaponItemData result;
		this.WeaponItemMap.TryGetValue(uniqueId, out result);
		return result;
	}

	// Token: 0x0600F8DA RID: 63706 RVA: 0x00443C48 File Offset: 0x00441E48
	public void NewPhantomItemData(int configId, int uniqueId, int functionValue)
	{
		if (this.PhantomItemMap.ContainsKey(uniqueId))
		{
			return;
		}
		PhantomItemData phantomItemData = new PhantomItemData(configId, uniqueId, functionValue, InventoryDefine.EItemDataType.PhantomItem);
		this.PhantomItemMap[uniqueId] = phantomItemData;
		this.AddToItemTypeMap(phantomItemData);
		this.AddToItemMainTypeMap(phantomItemData);
	}

	// Token: 0x0600F8DB RID: 63707 RVA: 0x00443C8C File Offset: 0x00441E8C
	public void UpdatePhantomItemData(Aki.Protocol.PhantomItem phantomItemInfo)
	{
		int id = phantomItemInfo.Id;
		int incrId = phantomItemInfo.IncrId;
		int funcValue = phantomItemInfo.FuncValue;
		this.RemovePhantomItemData(incrId);
		this.NewPhantomItemData(id, incrId, funcValue);
	}

	// Token: 0x0600F8DC RID: 63708 RVA: 0x00443CC0 File Offset: 0x00441EC0
	public void RemovePhantomItemData(int uniqueId)
	{
		PhantomItemData itemDataBase;
		if (!this.PhantomItemMap.TryGetValue(uniqueId, out itemDataBase))
		{
			return;
		}
		this.PhantomItemMap.Remove(uniqueId);
		this.RemoveFromItemTypeMap(itemDataBase);
		this.RemoveFromItemMainTypeMap(itemDataBase);
	}

	// Token: 0x0600F8DD RID: 63709 RVA: 0x00443CFC File Offset: 0x00441EFC
	public void RemovePhantomItemDataAndSaveNewList(IReadOnlyList<int> phantomUniqueIdList)
	{
		foreach (int uniqueId in phantomUniqueIdList)
		{
			this.RemovePhantomItemData(uniqueId);
			this.RemoveNewAttributeItem(uniqueId);
			this.RemoveRedDotAttributeItem(uniqueId);
		}
		this.SaveNewAttributeItemUniqueIdList();
		this.SaveRedDotAttributeItemUniqueIdList();
	}

	// Token: 0x0600F8DE RID: 63710 RVA: 0x00443D64 File Offset: 0x00441F64
	[NullableContext(2)]
	public PhantomItemData GetPhantomItemData(int uniqueId)
	{
		PhantomItemData result;
		this.PhantomItemMap.TryGetValue(uniqueId, out result);
		return result;
	}

	// Token: 0x0600F8DF RID: 63711 RVA: 0x00443D84 File Offset: 0x00441F84
	public void NewCalabashSkinItemData(int configId)
	{
		if (this.CalabashSkinItemMap.ContainsKey(configId))
		{
			return;
		}
		CalabashSkinItemData calabashSkinItemData = new CalabashSkinItemData(configId, 1, InventoryDefine.EItemDataType.CalabashSkinItem);
		this.CalabashSkinItemMap[configId] = calabashSkinItemData;
		this.AddToItemTypeMap(calabashSkinItemData);
		this.AddToItemMainTypeMap(calabashSkinItemData);
	}

	// Token: 0x0600F8E0 RID: 63712 RVA: 0x00443DC8 File Offset: 0x00441FC8
	public void NewOrnamentItemData(int configId)
	{
		if (this.OrnamentItemMap.ContainsKey(configId))
		{
			return;
		}
		OrnamentItemData ornamentItemData = new OrnamentItemData(configId, 1, InventoryDefine.EItemDataType.OrnamentItem);
		this.OrnamentItemMap[configId] = ornamentItemData;
		this.AddToItemTypeMap(ornamentItemData);
		this.AddToItemMainTypeMap(ornamentItemData);
	}

	// Token: 0x0600F8E1 RID: 63713 RVA: 0x00443E0C File Offset: 0x0044200C
	public void ClearCommonItemData()
	{
		foreach (Dictionary<int, CommonItemData> dictionary in this.CommonItemMap.Values)
		{
			foreach (CommonItemData commonItemData in dictionary.Values)
			{
				InventoryDefine.EItemMainTypeId? mainType = commonItemData.GetMainType();
				InventoryDefine.EItemType? type = commonItemData.GetType();
				this.ClearFromItemMainTypeMap(mainType.Value);
				this.ClearFromItemTypeMap(type.Value);
				this.ClearFromCommonItemByItemTypeMap(type.Value);
			}
		}
		this.CommonItemMap.Clear();
	}

	// Token: 0x0600F8E2 RID: 63714 RVA: 0x00443ED4 File Offset: 0x004420D4
	public void ClearWeaponItemData()
	{
		foreach (WeaponItemData weaponItemData in this.WeaponItemMap.Values)
		{
			InventoryDefine.EItemMainTypeId? mainType = weaponItemData.GetMainType();
			InventoryDefine.EItemType? type = weaponItemData.GetType();
			this.ClearFromItemMainTypeMap(mainType.Value);
			this.ClearFromItemTypeMap(type.Value);
		}
		this.WeaponItemMap.Clear();
	}

	// Token: 0x0600F8E3 RID: 63715 RVA: 0x00443F58 File Offset: 0x00442158
	public void ClearPhantomItemData()
	{
		foreach (PhantomItemData phantomItemData in this.PhantomItemMap.Values)
		{
			InventoryDefine.EItemMainTypeId? mainType = phantomItemData.GetMainType();
			InventoryDefine.EItemType? type = phantomItemData.GetType();
			this.ClearFromItemMainTypeMap(mainType.Value);
			this.ClearFromItemTypeMap(type.Value);
		}
		this.PhantomItemMap.Clear();
	}

	// Token: 0x0600F8E4 RID: 63716 RVA: 0x00443FDC File Offset: 0x004421DC
	public void ClearCalabashSkinItemData()
	{
		foreach (CalabashSkinItemData calabashSkinItemData in this.CalabashSkinItemMap.Values)
		{
			InventoryDefine.EItemMainTypeId? mainType = calabashSkinItemData.GetMainType();
			InventoryDefine.EItemType? type = calabashSkinItemData.GetType();
			this.ClearFromItemMainTypeMap(mainType.Value);
			this.ClearFromItemTypeMap(type.Value);
		}
		this.CalabashSkinItemMap.Clear();
	}

	// Token: 0x0600F8E5 RID: 63717 RVA: 0x00444060 File Offset: 0x00442260
	public void ClearOrnamentItemData()
	{
		foreach (OrnamentItemData ornamentItemData in this.OrnamentItemMap.Values)
		{
			InventoryDefine.EItemMainTypeId? mainType = ornamentItemData.GetMainType();
			InventoryDefine.EItemType? type = ornamentItemData.GetType();
			this.ClearFromItemMainTypeMap(mainType.Value);
			this.ClearFromItemTypeMap(type.Value);
		}
		this.OrnamentItemMap.Clear();
	}

	// Token: 0x0600F8E6 RID: 63718 RVA: 0x004440E4 File Offset: 0x004422E4
	public void ClearAllItemData()
	{
		this.ClearCommonItemData();
		this.ClearWeaponItemData();
		this.ClearPhantomItemData();
		this.ClearCalabashSkinItemData();
		this.ClearOrnamentItemData();
		this.ItemTypeMap.Clear();
		this.ItemMainTypeMap.Clear();
		this.CommonItemByItemTypeMap.Clear();
	}

	// Token: 0x0600F8E7 RID: 63719 RVA: 0x00444130 File Offset: 0x00442330
	[NullableContext(2)]
	public AttributeItemData GetAttributeItemData(int uniqueId)
	{
		AttributeItemData attributeItemData = this.GetWeaponItemData(uniqueId);
		if (attributeItemData == null)
		{
			attributeItemData = this.GetPhantomItemData(uniqueId);
		}
		if (attributeItemData == null)
		{
			attributeItemData = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(uniqueId);
		}
		return attributeItemData;
	}

	// Token: 0x0600F8E8 RID: 63720 RVA: 0x00444160 File Offset: 0x00442360
	public List<WeaponItemData> GetWeaponItemDataList()
	{
		List<WeaponItemData> list = new List<WeaponItemData>();
		foreach (WeaponItemData weaponItemData in this.GetAllWeaponItemDataIterator())
		{
			if (!ModelBase<WeaponModel>.Instance.IsWeaponUsedByUncommonRole(weaponItemData.GetUniqueId()))
			{
				list.Add(weaponItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8E9 RID: 63721 RVA: 0x004441CC File Offset: 0x004423CC
	public List<PhantomItemData> GetPhantomItemDataList()
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (PhantomItemData item in this.PhantomItemMap.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600F8EA RID: 63722 RVA: 0x0044422C File Offset: 0x0044242C
	public List<PhantomItemData> GetUnEquipPhantomItemDataList()
	{
		List<PhantomItemData> phantomItemDataList = this.GetPhantomItemDataList();
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (PhantomItemData phantomItemData in phantomItemDataList)
		{
			if (!ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(phantomItemData.GetUniqueId()))
			{
				list.Add(phantomItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8EB RID: 63723 RVA: 0x00444298 File Offset: 0x00442498
	public List<PhantomItemData> GetPhantomItemDataListByPhantomItemId(int itemId)
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (PhantomItemData phantomItemData in this.PhantomItemMap.Values)
		{
			if (phantomItemData.GetConfigId() == itemId)
			{
				list.Add(phantomItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8EC RID: 63724 RVA: 0x00444300 File Offset: 0x00442500
	public List<PhantomItemData> GetPhantomItemDataListByPhantomItem(List<Aki.Protocol.PhantomItem> phantomItemList)
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (Aki.Protocol.PhantomItem data in phantomItemList)
		{
			PhantomItemData phantomItemDataByPhantomItem = this.GetPhantomItemDataByPhantomItem(data);
			list.Add(phantomItemDataByPhantomItem);
		}
		return list;
	}

	// Token: 0x0600F8ED RID: 63725 RVA: 0x00444360 File Offset: 0x00442560
	public PhantomItemData GetPhantomItemDataByPhantomItem(Aki.Protocol.PhantomItem data)
	{
		PhantomItemData phantomItemData = new PhantomItemData(data.Id, data.IncrId, data.FuncValue, InventoryDefine.EItemDataType.PhantomItem);
		phantomItemData.SetFetterGroupId(data.FetterGroupId);
		return phantomItemData;
	}

	// Token: 0x0600F8EE RID: 63726 RVA: 0x00444388 File Offset: 0x00442588
	public List<PhantomItemData> GetPhantomItemDataListByAddCountItemInfo(List<AddCountItemInfo> items)
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (AddCountItemInfo addCountItemInfo in items)
		{
			PhantomItemData item = new PhantomItemData(addCountItemInfo.Id, addCountItemInfo.IncrId, 0, InventoryDefine.EItemDataType.PhantomItem);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600F8EF RID: 63727 RVA: 0x004443F4 File Offset: 0x004425F4
	public List<CommonItemData> GetCommonItemDataList()
	{
		List<CommonItemData> list = new List<CommonItemData>();
		foreach (Dictionary<int, CommonItemData> dictionary in this.CommonItemMap.Values)
		{
			foreach (CommonItemData commonItemData in dictionary.Values)
			{
				if (commonItemData.IsValid())
				{
					list.Add(commonItemData);
				}
			}
		}
		return list;
	}

	// Token: 0x0600F8F0 RID: 63728 RVA: 0x00444494 File Offset: 0x00442694
	public List<CommonItemData> GetCommonItemByItemType(InventoryDefine.EItemType itemType)
	{
		HashSet<CommonItemData> source;
		if (!this.CommonItemByItemTypeMap.TryGetValue(itemType, out source))
		{
			return new List<CommonItemData>();
		}
		return (from commonItemData in source
		where commonItemData.IsValid()
		select commonItemData).ToList<CommonItemData>();
	}

	// Token: 0x0600F8F1 RID: 63729 RVA: 0x004444E4 File Offset: 0x004426E4
	public List<CommonItemData> GetCommonItemByShowType(InventoryDefine.EShowType showType)
	{
		List<CommonItemData> list = new List<CommonItemData>();
		foreach (Dictionary<int, CommonItemData> dictionary in this.CommonItemMap.Values)
		{
			foreach (CommonItemData commonItemData in dictionary.Values)
			{
				if (commonItemData.GetShowTypeList().Contains((int)showType) && commonItemData.IsValid())
				{
					list.Add(commonItemData);
				}
			}
		}
		return list;
	}

	// Token: 0x0600F8F2 RID: 63730 RVA: 0x00444594 File Offset: 0x00442794
	public List<WeaponItemData> GetWeaponItemByItemType(InventoryDefine.EItemType itemType)
	{
		List<WeaponItemData> list = new List<WeaponItemData>();
		foreach (WeaponItemData weaponItemData in this.GetWeaponItemDataList())
		{
			InventoryDefine.EItemType? type = weaponItemData.GetType();
			if (type.GetValueOrDefault() == itemType & type != null)
			{
				list.Add(weaponItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8F3 RID: 63731 RVA: 0x00444610 File Offset: 0x00442810
	public List<PhantomItemData> GetPhantomItemByItemType(InventoryDefine.EItemType itemType)
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (PhantomItemData phantomItemData in this.PhantomItemMap.Values)
		{
			InventoryDefine.EItemType? type = phantomItemData.GetType();
			if (type.GetValueOrDefault() == itemType & type != null)
			{
				list.Add(phantomItemData);
			}
		}
		return list;
	}

	// Token: 0x0600F8F4 RID: 63732 RVA: 0x00444690 File Offset: 0x00442890
	public List<ItemDataBase> GetItemDataBase(InventoryDefine.IGetItemData getItemData)
	{
		int incId = getItemData.IncId;
		if (incId > 0)
		{
			return new List<ItemDataBase>
			{
				this.GetAttributeItemData(incId)
			};
		}
		return this.GetItemDataBaseByConfigId(getItemData.ItemId);
	}

	// Token: 0x0600F8F5 RID: 63733 RVA: 0x004446C8 File Offset: 0x004428C8
	[NullableContext(2)]
	public global::ItemMainTypeMapping GetItemMainTypeMapping(InventoryDefine.EItemMainTypeId mainType)
	{
		global::ItemMainTypeMapping result;
		this.ItemMainTypeMap.TryGetValue(mainType, out result);
		return result;
	}

	// Token: 0x0600F8F6 RID: 63734 RVA: 0x004446E5 File Offset: 0x004428E5
	public HashSet<ItemDataBase> GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId mainType)
	{
		return this.CurrentProxy.GetItemDataBaseByMainType(mainType);
	}

	// Token: 0x0600F8F7 RID: 63735 RVA: 0x004446F4 File Offset: 0x004428F4
	public HashSet<ItemDataBase> GetItemDataBaseByMainTypeBase(InventoryDefine.EItemMainTypeId mainType)
	{
		HashSet<ItemDataBase> hashSet = new HashSet<ItemDataBase>();
		global::ItemMainTypeMapping itemMainTypeMapping;
		if (!this.ItemMainTypeMap.TryGetValue(mainType, out itemMainTypeMapping))
		{
			return hashSet;
		}
		foreach (ItemDataBase itemDataBase in itemMainTypeMapping.GetSet())
		{
			if (itemDataBase.IsValid())
			{
				hashSet.Add(itemDataBase);
			}
		}
		return hashSet;
	}

	// Token: 0x0600F8F8 RID: 63736 RVA: 0x0044476C File Offset: 0x0044296C
	public int GetInventoryItemGridCountByMainType(InventoryDefine.EItemMainTypeId mainType)
	{
		return this.CurrentProxy.GetInventoryItemGridCountByMainType(mainType);
	}

	// Token: 0x0600F8F9 RID: 63737 RVA: 0x0044477C File Offset: 0x0044297C
	public int GetInventoryItemGridCountByMainTypeBase(InventoryDefine.EItemMainTypeId mainType)
	{
		HashSet<ItemDataBase> itemDataBaseByMainTypeBase = this.GetItemDataBaseByMainTypeBase(mainType);
		int num = 0;
		foreach (ItemDataBase itemDataBase in itemDataBaseByMainTypeBase)
		{
			InventoryDefine.EItemType? type = itemDataBase.GetType();
			InventoryDefine.EItemType eitemType = InventoryDefine.EItemType.Virtual;
			if (!(type.GetValueOrDefault() == eitemType & type != null))
			{
				if (itemDataBase is CommonItemData)
				{
					int maxStackCount = itemDataBase.GetMaxStackCount();
					if (maxStackCount > 0)
					{
						num += (int)Math.Ceiling((double)((float)itemDataBase.GetCount() / (float)maxStackCount));
					}
				}
				else
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600F8FA RID: 63738 RVA: 0x0044481C File Offset: 0x00442A1C
	public HashSet<ItemDataBase> GetItemDataBaseByItemType(InventoryDefine.EItemType itemType)
	{
		HashSet<ItemDataBase> hashSet = new HashSet<ItemDataBase>();
		HashSet<ItemDataBase> hashSet2;
		if (!this.ItemTypeMap.TryGetValue(itemType, out hashSet2))
		{
			return hashSet;
		}
		foreach (ItemDataBase itemDataBase in hashSet2)
		{
			if (itemDataBase.IsValid())
			{
				hashSet.Add(itemDataBase);
			}
		}
		return hashSet;
	}

	// Token: 0x0600F8FB RID: 63739 RVA: 0x0044488C File Offset: 0x00442A8C
	private Dictionary<int, WeaponItemData>.ValueCollection GetAllWeaponItemDataIterator()
	{
		return this.WeaponItemMap.Values;
	}

	// Token: 0x0600F8FC RID: 63740 RVA: 0x00444899 File Offset: 0x00442A99
	public Dictionary<int, PhantomItemData>.ValueCollection GetAllPhantomItemDataIterator()
	{
		return this.PhantomItemMap.Values;
	}

	// Token: 0x0600F8FD RID: 63741 RVA: 0x004448A6 File Offset: 0x00442AA6
	[NullableContext(2)]
	public void SetSelectedItemViewData(global::ItemViewData itemViewData)
	{
		this.SelectedItemViewData = itemViewData;
	}

	// Token: 0x0600F8FE RID: 63742 RVA: 0x004448AF File Offset: 0x00442AAF
	public void SetCurrentLockItemUniqueId(int uniqueId)
	{
		this.CurrentLockItemUniqueId = uniqueId;
	}

	// Token: 0x0600F8FF RID: 63743 RVA: 0x004448B8 File Offset: 0x00442AB8
	[NullableContext(2)]
	public global::ItemViewData GetSelectedItemData()
	{
		return this.SelectedItemViewData;
	}

	// Token: 0x17001291 RID: 4753
	// (get) Token: 0x0600F900 RID: 63744 RVA: 0x004448C0 File Offset: 0x00442AC0
	public int GetCurrentLockItemUniqueId
	{
		get
		{
			return this.CurrentLockItemUniqueId;
		}
	}

	// Token: 0x0600F901 RID: 63745 RVA: 0x004448C8 File Offset: 0x00442AC8
	public void SetSelectedTypeIndex(int index)
	{
		this.CurrentProxy.SetSelectedTypeIndex(index);
	}

	// Token: 0x0600F902 RID: 63746 RVA: 0x004448D6 File Offset: 0x00442AD6
	public int GetSelectedTypeIndex()
	{
		return this.CurrentProxy.GetSelectedTypeIndex();
	}

	// Token: 0x0600F903 RID: 63747 RVA: 0x004448E3 File Offset: 0x00442AE3
	public void SetOutsideUniqueId(int uniqueId)
	{
		this.OutsideUniqueId = new int?(uniqueId);
	}

	// Token: 0x0600F904 RID: 63748 RVA: 0x004448F1 File Offset: 0x00442AF1
	public int? GetOutsideUniqueId()
	{
		return this.OutsideUniqueId;
	}

	// Token: 0x0600F905 RID: 63749 RVA: 0x004448F9 File Offset: 0x00442AF9
	public void ClearOutsideUniqueId()
	{
		this.OutsideUniqueId = null;
	}

	// Token: 0x0600F906 RID: 63750 RVA: 0x00444907 File Offset: 0x00442B07
	public int GetItemCountByConfigId(int itemConfigId, int uniqueId = 0)
	{
		return this.CurrentProxy.GetItemCountByConfigId(itemConfigId, uniqueId);
	}

	// Token: 0x0600F907 RID: 63751 RVA: 0x00444918 File Offset: 0x00442B18
	public int GetItemCountByConfigIdBase(int itemConfigId, int uniqueId = 0)
	{
		if (Enum.IsDefined(typeof(EItemId), itemConfigId))
		{
			return ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(itemConfigId);
		}
		switch (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemConfigId)))
		{
		case InventoryDefine.EItemDataType.WeaponItem:
			return this.GetWeaponItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.PhantomItem:
			return this.GetPhantomItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.CardItem:
			return this.GetCardItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.RogueCurrency:
			return this.GetRogueCurrencyItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.RogueResCurrency:
			return this.GetRogueResCurrencyItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.WeaponSkinItem:
			return this.GetWeaponSkinCount(itemConfigId);
		case InventoryDefine.EItemDataType.RoleSkinItem:
			return this.GetRoleSkinCount(itemConfigId);
		case InventoryDefine.EItemDataType.PlayerHeadItem:
			return this.GetPlayerHeadItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.FlySkinItem:
			return this.GetFlySkinCount(itemConfigId);
		case InventoryDefine.EItemDataType.PhantomArenaCard:
			return this.GetPhantomArenaCardCount(itemConfigId);
		case InventoryDefine.EItemDataType.CalabashSkinItem:
			return this.GetCalabashSkinCount(itemConfigId);
		case InventoryDefine.EItemDataType.MotorStickerItem:
			return this.GetMotorSkinCount(itemConfigId);
		case InventoryDefine.EItemDataType.FurnitureItem:
			return this.GetFurnitureItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.MotorSkinItem:
			return this.GetOwnedMotorSkinCount(itemConfigId);
		case InventoryDefine.EItemDataType.OrnamentItem:
			return this.GetOrnamentItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.PinballRoleItem:
			return this.GetPinballRoleItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.PinballWeaponItem:
			return this.GetPinballWeaponItemCount(itemConfigId);
		case InventoryDefine.EItemDataType.RoverRogueCurrency:
			return this.GetRoverRogueCurrencyItemCount(itemConfigId);
		}
		return this.GetCommonItemCount(itemConfigId, uniqueId);
	}

	// Token: 0x0600F908 RID: 63752 RVA: 0x00444A78 File Offset: 0x00442C78
	public List<IGetWayItemData> GetGetWayDataList(int itemId)
	{
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (itemConfigData.ItemAccess == null || itemConfigData.ItemAccess.Length == 0)
		{
			return new List<IGetWayItemData>();
		}
		List<IGetWayItemData> list = new List<IGetWayItemData>();
		int[] itemAccess = itemConfigData.ItemAccess;
		for (int i = 0; i < itemAccess.Length; i++)
		{
			int getWayId = itemAccess[i];
			AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(getWayId);
			if (configById != null)
			{
				GetWayItemData item = new GetWayItemData(getWayId, (EGetWayItemType)configById.Value.Type, configById.Value.Description, configById.Value.SortIndex, delegate()
				{
					SkipTaskManager.RunByConfigId(getWayId, itemId);
				});
				list.Add(item);
			}
		}
		list.Sort(delegate(IGetWayItemData aGetWayData, IGetWayItemData bGetWayData)
		{
			int sortIndex = aGetWayData.SortIndex;
			int sortIndex2 = bGetWayData.SortIndex;
			if (sortIndex == sortIndex2)
			{
				return bGetWayData.Id - aGetWayData.Id;
			}
			return sortIndex2 - sortIndex;
		});
		return list;
	}

	// Token: 0x0600F909 RID: 63753 RVA: 0x00444B90 File Offset: 0x00442D90
	private int GetWeaponItemCount(int configId)
	{
		int num = 0;
		using (List<WeaponItemData>.Enumerator enumerator = this.GetWeaponItemDataList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetConfigId() == configId)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600F90A RID: 63754 RVA: 0x00444BEC File Offset: 0x00442DEC
	private int GetRogueCurrencyItemCount(int configId)
	{
		return ModelBase<RoguelikeModel>.Instance.GetRoguelikeInventoryCurrency(configId);
	}

	// Token: 0x0600F90B RID: 63755 RVA: 0x00444BF9 File Offset: 0x00442DF9
	private int GetRogueResCurrencyItemCount(int configId)
	{
		return ModelBase<ActivityPermanentRogueModel>.Instance.GetCurrency(configId);
	}

	// Token: 0x0600F90C RID: 63756 RVA: 0x00444C06 File Offset: 0x00442E06
	private int GetRoverRogueCurrencyItemCount(int configId)
	{
		return ModelBase<RoverlikeModel>.Instance.GetCurrency(configId);
	}

	// Token: 0x0600F90D RID: 63757 RVA: 0x00444C13 File Offset: 0x00442E13
	private int GetWeaponSkinCount(int configId)
	{
		return ModelBase<WeaponSkinModel>.Instance.GetSkinCountById(configId);
	}

	// Token: 0x0600F90E RID: 63758 RVA: 0x00444C20 File Offset: 0x00442E20
	private int GetRoleSkinCount(int configId)
	{
		return ModelBase<RoleSkinModel>.Instance.GetSkinCountById(configId);
	}

	// Token: 0x0600F90F RID: 63759 RVA: 0x00444C2D File Offset: 0x00442E2D
	private int GetFlySkinCount(int configId)
	{
		return ModelBase<FlySkinModel>.Instance.GetFlySkinItemCount(configId);
	}

	// Token: 0x0600F910 RID: 63760 RVA: 0x00444C3C File Offset: 0x00442E3C
	private int GetMotorSkinCount(int configId)
	{
		EOutLookState stickerState = ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(configId);
		if (stickerState == EOutLookState.IsEquipped || stickerState == EOutLookState.CanEquipped)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0600F911 RID: 63761 RVA: 0x00444C60 File Offset: 0x00442E60
	private int GetOwnedMotorSkinCount(int configId)
	{
		return (ModelBase<MotorcycleDiyModel>.Instance.HasSkin(configId) > false) ? 1 : 0;
	}

	// Token: 0x0600F912 RID: 63762 RVA: 0x00444C70 File Offset: 0x00442E70
	private int GetPhantomArenaCardCount(int configId)
	{
		if (!ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(configId))
		{
			return 0;
		}
		return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(configId).CardGroupNum;
	}

	// Token: 0x0600F913 RID: 63763 RVA: 0x00444C9F File Offset: 0x00442E9F
	private int GetCalabashSkinCount(int configId)
	{
		return ModelBase<CalabashSkinModel>.Instance.GetSkinCountById(configId);
	}

	// Token: 0x0600F914 RID: 63764 RVA: 0x00444CAC File Offset: 0x00442EAC
	private int GetFurnitureItemCount(int configId)
	{
		return (ModelBase<FurnitureModel>.Instance.GetIsFurnitureUnlockById(configId) > false) ? 1 : 0;
	}

	// Token: 0x0600F915 RID: 63765 RVA: 0x00444CBC File Offset: 0x00442EBC
	private int GetOrnamentItemCount(int configId)
	{
		return ModelBase<RoleOrnamentModel>.Instance.GetOrnamentCountById(configId);
	}

	// Token: 0x0600F916 RID: 63766 RVA: 0x00444CC9 File Offset: 0x00442EC9
	private int GetPinballRoleItemCount(int configId)
	{
		return 0;
	}

	// Token: 0x0600F917 RID: 63767 RVA: 0x00444CCC File Offset: 0x00442ECC
	private int GetPinballWeaponItemCount(int configId)
	{
		return 0;
	}

	// Token: 0x0600F918 RID: 63768 RVA: 0x00444CD0 File Offset: 0x00442ED0
	private int GetPhantomItemCount(int configId)
	{
		int num = 0;
		using (Dictionary<int, PhantomItemData>.ValueCollection.Enumerator enumerator = this.GetAllPhantomItemDataIterator().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetConfigId() == configId)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600F919 RID: 63769 RVA: 0x00444D2C File Offset: 0x00442F2C
	private int GetPlayerHeadItemCount(int configId)
	{
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(configId, true);
		if (playerHeadData != null && !playerHeadData.Lock)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0600F91A RID: 63770 RVA: 0x00444D54 File Offset: 0x00442F54
	private int GetCardItemCount(int configId)
	{
		List<PersonalCardData> cardDataList = ModelBase<PersonalModel>.Instance.GetCardDataList();
		int count = cardDataList.Count;
		for (int i = 0; i < count; i++)
		{
			PersonalCardData personalCardData = cardDataList[i];
			if (personalCardData.CardId == configId && personalCardData.IsUnLock)
			{
				return 1;
			}
		}
		return 0;
	}

	// Token: 0x0600F91B RID: 63771 RVA: 0x00444D9B File Offset: 0x00442F9B
	public bool TryAddNewCommonItem(int configId, int uniqueId = 0)
	{
		if (uniqueId != 0)
		{
			return this.TryAddNewAttributeItem(uniqueId);
		}
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryCommonItem, configId))
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.InventoryCommonItem, configId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGetNewItem, configId);
		return true;
	}

	// Token: 0x0600F91C RID: 63772 RVA: 0x00444DD7 File Offset: 0x00442FD7
	public bool TryAddNewAttributeItem(int uniqueId)
	{
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryAttributeItem, uniqueId))
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.InventoryAttributeItem, uniqueId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGetNewItem, uniqueId);
		return true;
	}

	// Token: 0x0600F91D RID: 63773 RVA: 0x00444E08 File Offset: 0x00443008
	public bool RemoveNewCommonItem(int configId, int uniqueId = 0)
	{
		if (uniqueId != 0)
		{
			return this.RemoveNewAttributeItem(uniqueId);
		}
		return ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.InventoryCommonItem, configId);
	}

	// Token: 0x0600F91E RID: 63774 RVA: 0x00444E21 File Offset: 0x00443021
	public bool RemoveNewAttributeItem(int uniqueId)
	{
		return ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.InventoryAttributeItem, uniqueId);
	}

	// Token: 0x0600F91F RID: 63775 RVA: 0x00444E2F File Offset: 0x0044302F
	public bool SaveNewCommonItemConfigIdList()
	{
		return ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.InventoryCommonItem);
	}

	// Token: 0x0600F920 RID: 63776 RVA: 0x00444E3C File Offset: 0x0044303C
	public bool SaveNewAttributeItemUniqueIdList()
	{
		return ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.InventoryAttributeItem);
	}

	// Token: 0x0600F921 RID: 63777 RVA: 0x00444E49 File Offset: 0x00443049
	public bool IsNewCommonItem(int configId, int uniqueId = 0)
	{
		if (uniqueId != 0)
		{
			return this.IsNewAttributeItem(uniqueId);
		}
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryCommonItem, configId);
	}

	// Token: 0x0600F922 RID: 63778 RVA: 0x00444E62 File Offset: 0x00443062
	public bool IsNewAttributeItem(int uniqueId)
	{
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryAttributeItem, uniqueId);
	}

	// Token: 0x0600F923 RID: 63779 RVA: 0x00444E70 File Offset: 0x00443070
	[NullableContext(2)]
	public HashSet<int> GetNewAttributeItemUniqueIdList()
	{
		return ModelBase<NewFlagModel>.Instance.GetNewFlagSet(ELocalStoragePlayerKey.InventoryAttributeItem);
	}

	// Token: 0x0600F924 RID: 63780 RVA: 0x00444E80 File Offset: 0x00443080
	public bool TryAddRedDotCommonItem(int configId, int uniqueId = 0)
	{
		CommonItemData commonItemData = this.GetCommonItemData(configId, uniqueId);
		if (commonItemData == null)
		{
			return false;
		}
		InventoryDefine.ERedDotDisableRule redDotDisableRule = commonItemData.GetRedDotDisableRule();
		if (redDotDisableRule == InventoryDefine.ERedDotDisableRule.None)
		{
			return false;
		}
		if (uniqueId != 0)
		{
			ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.InventoryAttributeItemRedDot, uniqueId);
			return true;
		}
		if (redDotDisableRule == InventoryDefine.ERedDotDisableRule.ServerFirstSelect)
		{
			this.TryAddCommonItemServerFirstSelectRedDot(configId);
		}
		else
		{
			ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.InventoryCommonItemRedDot, configId);
		}
		return true;
	}

	// Token: 0x0600F925 RID: 63781 RVA: 0x00444ED4 File Offset: 0x004430D4
	private void TryAddCommonItemServerFirstSelectRedDot(int itemId)
	{
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ItemBackpackFirstCheck) as ServerStorageMap;
		if (serverStorageMap.Has(itemId))
		{
			return;
		}
		serverStorageMap.Set(itemId, 1);
	}

	// Token: 0x0600F926 RID: 63782 RVA: 0x00444F08 File Offset: 0x00443108
	private bool TryClearCommonItemServerFirstSelectRedDot(int itemId)
	{
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ItemBackpackFirstCheck) as ServerStorageMap;
		if (serverStorageMap.Get(itemId).GetValueOrDefault() == 1)
		{
			serverStorageMap.Set(itemId, 0);
			return true;
		}
		return false;
	}

	// Token: 0x0600F927 RID: 63783 RVA: 0x00444F44 File Offset: 0x00443144
	public bool HasCommonItemServerFirstSelectRedDot(int itemId)
	{
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ItemBackpackFirstCheck) as ServerStorageMap;
		return serverStorageMap != null && serverStorageMap.Get(itemId).GetValueOrDefault() == 1;
	}

	// Token: 0x0600F928 RID: 63784 RVA: 0x00444F7C File Offset: 0x0044317C
	public bool HasAnyCommonItemServerFirstSelectRedDot()
	{
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ItemBackpackFirstCheck) as ServerStorageMap;
		if (serverStorageMap == null)
		{
			return false;
		}
		return serverStorageMap.GetContainer().Values.Any((int value) => value == 1);
	}

	// Token: 0x0600F929 RID: 63785 RVA: 0x00444FD0 File Offset: 0x004431D0
	public bool TryAddRedDotAttributeItem(int uniqueId)
	{
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryAttributeItemRedDot, uniqueId))
		{
			return false;
		}
		AttributeItemData attributeItemData = this.GetAttributeItemData(uniqueId);
		if (attributeItemData == null)
		{
			return false;
		}
		if (attributeItemData.GetRedDotDisableRule() == InventoryDefine.ERedDotDisableRule.None)
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.InventoryAttributeItemRedDot, uniqueId);
		return true;
	}

	// Token: 0x0600F92A RID: 63786 RVA: 0x00445014 File Offset: 0x00443214
	public bool HasRedDot()
	{
		NewFlagModel instance = ModelBase<NewFlagModel>.Instance;
		HashSet<int> newFlagSet = instance.GetNewFlagSet(ELocalStoragePlayerKey.InventoryCommonItemRedDot);
		int num = 0;
		if (newFlagSet != null)
		{
			num = newFlagSet.Count;
		}
		int num2 = 0;
		HashSet<int> newFlagSet2 = instance.GetNewFlagSet(ELocalStoragePlayerKey.InventoryAttributeItemRedDot);
		if (newFlagSet2 != null)
		{
			num2 = newFlagSet2.Count;
		}
		return num > 0 || num2 > 0 || this.HasAnyCommonItemServerFirstSelectRedDot();
	}

	// Token: 0x0600F92B RID: 63787 RVA: 0x0044505D File Offset: 0x0044325D
	public bool IsMainTypeHasRedDot(InventoryDefine.EItemMainTypeId itemMainType)
	{
		global::ItemMainTypeMapping itemMainTypeMapping = this.GetItemMainTypeMapping(itemMainType);
		return itemMainTypeMapping != null && itemMainTypeMapping.HasRedDot();
	}

	// Token: 0x0600F92C RID: 63788 RVA: 0x00445071 File Offset: 0x00443271
	public bool IsCommonItemHasRedDot(int configId, int uniqueId = 0)
	{
		if (uniqueId != 0)
		{
			return this.IsAttributeItemHasRedDot(uniqueId);
		}
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryCommonItemRedDot, configId) || this.HasCommonItemServerFirstSelectRedDot(configId);
	}

	// Token: 0x0600F92D RID: 63789 RVA: 0x00445095 File Offset: 0x00443295
	public bool IsAttributeItemHasRedDot(int uniqueId)
	{
		return ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.InventoryAttributeItemRedDot, uniqueId);
	}

	// Token: 0x0600F92E RID: 63790 RVA: 0x004450A4 File Offset: 0x004432A4
	public bool RemoveRedDotCommonItem(int configId, int uniqueId = 0)
	{
		if (uniqueId != 0)
		{
			return this.RemoveRedDotAttributeItem(uniqueId);
		}
		bool flag = ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.InventoryCommonItemRedDot, configId);
		bool flag2 = this.TryClearCommonItemServerFirstSelectRedDot(configId);
		if (flag || flag2)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRemoveItemRedDot);
			return true;
		}
		return false;
	}

	// Token: 0x0600F92F RID: 63791 RVA: 0x004450E7 File Offset: 0x004432E7
	public bool RemoveRedDotAttributeItem(int uniqueId)
	{
		if (!ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.InventoryAttributeItemRedDot, uniqueId))
		{
			return false;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRemoveItemRedDot);
		return true;
	}

	// Token: 0x0600F930 RID: 63792 RVA: 0x0044510A File Offset: 0x0044330A
	public bool SaveRedDotCommonItemConfigIdList()
	{
		return ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.InventoryCommonItemRedDot);
	}

	// Token: 0x0600F931 RID: 63793 RVA: 0x00445117 File Offset: 0x00443317
	public bool SaveRedDotAttributeItemUniqueIdList()
	{
		return ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.InventoryAttributeItemRedDot);
	}

	// Token: 0x0600F932 RID: 63794 RVA: 0x00445124 File Offset: 0x00443324
	[NullableContext(2)]
	public void SetAcquireData(AcquireData acquireData)
	{
		this.CurrentAcquireData = acquireData;
	}

	// Token: 0x0600F933 RID: 63795 RVA: 0x0044512D File Offset: 0x0044332D
	[NullableContext(2)]
	public AcquireData GetAcquireData()
	{
		return this.CurrentAcquireData;
	}

	// Token: 0x0600F934 RID: 63796 RVA: 0x00445138 File Offset: 0x00443338
	public bool CheckIsCoinEnough(int coinItemId, IList<OneItemConfig> matList)
	{
		foreach (OneItemConfig oneItemConfig in matList)
		{
			if (oneItemConfig.ItemId == coinItemId)
			{
				return this.GetItemCountByConfigId(coinItemId, 0) >= oneItemConfig.Count;
			}
		}
		return true;
	}

	// Token: 0x0600F935 RID: 63797 RVA: 0x004451A0 File Offset: 0x004433A0
	public bool GetPhantomManageConfigClear()
	{
		return this.PhantomManageConfig.Count == 0;
	}

	// Token: 0x0600F936 RID: 63798 RVA: 0x004451B0 File Offset: 0x004433B0
	public List<PhantomManageConfigData> GetPhantomManageConfigByType(PhantomSettingType type)
	{
		if (this.PhantomManageConfig.Count == 0 || !this.PhantomManageConfig.ContainsKey(type))
		{
			Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.WDX, "批量管理方案未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<PhantomManageConfigData>();
		}
		return this.PhantomManageConfig[type];
	}

	// Token: 0x0600F937 RID: 63799 RVA: 0x00445208 File Offset: 0x00443408
	[NullableContext(2)]
	public PhantomManageConfigData GetPhantomManageConfigByTypeAndIndex(PhantomSettingType type, int index)
	{
		foreach (PhantomManageConfigData phantomManageConfigData in this.GetPhantomManageConfigByType(type))
		{
			if (phantomManageConfigData.GetIndex() == index)
			{
				return phantomManageConfigData;
			}
		}
		Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.WDX, "批量管理方案未初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x0600F938 RID: 63800 RVA: 0x00445284 File Offset: 0x00443484
	public void UpdatePhantomManageConfig(PhantomSettingType type, PhantomSettingUpdateResponse response)
	{
		OnePhantomSetting setting = response.Setting;
		List<PhantomManageConfigData> list;
		if (!this.PhantomManageConfig.TryGetValue(type, out list))
		{
			Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.WDX, "批量管理方案更新失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int index = setting.Index;
		foreach (PhantomManageConfigData phantomManageConfigData in list)
		{
			int index2 = phantomManageConfigData.GetIndex();
			if (index == index2)
			{
				phantomManageConfigData.Parse(setting);
				break;
			}
		}
	}

	// Token: 0x0600F939 RID: 63801 RVA: 0x00445320 File Offset: 0x00443520
	public void CoverAllPhantomManageConfig(List<PhantomSettingInfo> settingInfoList)
	{
		this.PhantomManageConfig.Clear();
		foreach (PhantomSettingInfo phantomSettingInfo in settingInfoList)
		{
			PhantomSettingType settingType = phantomSettingInfo.SettingType;
			List<PhantomManageConfigData> list;
			if (!this.PhantomManageConfig.TryGetValue(settingType, out list))
			{
				list = new List<PhantomManageConfigData>();
				this.PhantomManageConfig[settingType] = list;
			}
			OnePhantomSetting setting = phantomSettingInfo.Setting;
			if (setting == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.LZK, "批量管理方案设置数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				PhantomManageConfigData phantomManageConfigData = new PhantomManageConfigData(setting.Index);
				phantomManageConfigData.SetType(settingType);
				phantomManageConfigData.Parse(setting);
				list.Add(phantomManageConfigData);
				this.PhantomManageConfig[settingType] = list;
			}
		}
		foreach (KeyValuePair<PhantomSettingType, List<PhantomManageConfigData>> keyValuePair in this.PhantomManageConfig)
		{
			PhantomSettingType key = keyValuePair.Key;
			List<PhantomManageConfigData> value = keyValuePair.Value;
			while (value.Count < this.GetConfigMaxCountConst())
			{
				PhantomManageConfigData phantomManageConfigData2 = new PhantomManageConfigData(value.Count);
				phantomManageConfigData2.SetType(key);
				value.Add(phantomManageConfigData2);
			}
		}
	}

	// Token: 0x0600F93A RID: 63802 RVA: 0x0044547C File Offset: 0x0044367C
	public void InitPhantomManageConfig(PhantomSettingResponse response)
	{
		this.PhantomManageConfig.Clear();
		this.InitSettingsByType(PhantomSettingType.AutoLock, response.AutoLockSettings.ToList<OnePhantomSetting>());
		this.InitSettingsByType(PhantomSettingType.AutoDisuse, response.AutoDisuseSettings.ToList<OnePhantomSetting>());
	}

	// Token: 0x0600F93B RID: 63803 RVA: 0x004454B0 File Offset: 0x004436B0
	[return: Nullable(2)]
	private OnePhantomSetting GetSettingByIndex(int index, List<OnePhantomSetting> settingList)
	{
		foreach (OnePhantomSetting onePhantomSetting in settingList)
		{
			if (onePhantomSetting.Index == index)
			{
				return onePhantomSetting;
			}
		}
		return null;
	}

	// Token: 0x0600F93C RID: 63804 RVA: 0x00445508 File Offset: 0x00443708
	private void InitSettingsByType(PhantomSettingType type, List<OnePhantomSetting> settings)
	{
		List<PhantomManageConfigData> list = new List<PhantomManageConfigData>();
		int configMaxCountConst = this.GetConfigMaxCountConst();
		for (int i = 0; i < configMaxCountConst; i++)
		{
			PhantomManageConfigData phantomManageConfigData = new PhantomManageConfigData(i);
			phantomManageConfigData.SetType(type);
			OnePhantomSetting settingByIndex = this.GetSettingByIndex(i, settings);
			if (settingByIndex != null)
			{
				phantomManageConfigData.Parse(settingByIndex);
			}
			list.Add(phantomManageConfigData);
		}
		this.PhantomManageConfig[type] = list;
	}

	// Token: 0x0600F93D RID: 63805 RVA: 0x00445568 File Offset: 0x00443768
	public unsafe List<InventoryDefine.IManageConfigTitleItemData> GetSettingTitleItemDataList()
	{
		int filterIdConst = this.GetFilterIdConst();
		Span<int> ruleListBytes = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterIdConst).Value.GetRuleListBytes();
		List<InventoryDefine.IManageConfigTitleItemData> list = new List<InventoryDefine.IManageConfigTitleItemData>();
		Span<int> span = ruleListBytes;
		for (int i = 0; i < span.Length; i++)
		{
			int filterRuleId = *span[i];
			list.Add(new InventoryDefine.ManageConfigTitleItemData
			{
				FilterId = filterIdConst,
				FilterRuleId = filterRuleId
			});
		}
		return list;
	}

	// Token: 0x0600F93E RID: 63806 RVA: 0x004455E4 File Offset: 0x004437E4
	public int GetFilterIdConst()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomAutoLockFilterId").GetValueOrDefault();
	}

	// Token: 0x0600F93F RID: 63807 RVA: 0x00445604 File Offset: 0x00443804
	public int GetConfigMaxCountConst()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomSettingFilterMaxCount").GetValueOrDefault(10);
	}

	// Token: 0x0600F940 RID: 63808 RVA: 0x00445628 File Offset: 0x00443828
	public InventoryDefine.ESettingGridType GetGridTypeByFilterRuleId(int filterRuleId)
	{
		InventoryDefine.ESettingGridType result = InventoryDefine.ESettingGridType.Small;
		InventoryDefine.recFilterRuleToGirdType.TryGetValue((FilterDefine.EFilterType)filterRuleId, out result);
		return result;
	}

	// Token: 0x0600F941 RID: 63809 RVA: 0x00445648 File Offset: 0x00443848
	[NullableContext(2)]
	public void SetPhantomManageSelectSet(HashSet<int> selectSet)
	{
		this.PhantomManageSelectSet = selectSet;
	}

	// Token: 0x0600F942 RID: 63810 RVA: 0x00445651 File Offset: 0x00443851
	[NullableContext(2)]
	public HashSet<int> GetPhantomManageSelectSet()
	{
		return this.PhantomManageSelectSet;
	}

	// Token: 0x0600F943 RID: 63811 RVA: 0x00445659 File Offset: 0x00443859
	public void SetInventoryDataProxy(InventoryDataProxy proxy)
	{
		this.CurrentProxy = proxy;
	}

	// Token: 0x0600F944 RID: 63812 RVA: 0x00445662 File Offset: 0x00443862
	public void ResetInventoryDataProxy()
	{
		this._CurrentProxy = null;
	}

	// Token: 0x0600F945 RID: 63813 RVA: 0x0044566B File Offset: 0x0044386B
	public bool SupportInventoryViewShowCurrency()
	{
		return this.CurrentProxy.SupportShowCurrency();
	}

	// Token: 0x0600F946 RID: 63814 RVA: 0x00445678 File Offset: 0x00443878
	public bool GetInteractiveItemsFunctionEnable()
	{
		return this.InteractiveItemsFunctionEnable;
	}

	// Token: 0x0600F947 RID: 63815 RVA: 0x00445680 File Offset: 0x00443880
	public void SetInteractiveItemsFunctionEnable(bool enable)
	{
		bool flag = this.InteractiveItemsFunctionEnable != enable;
		this.InteractiveItemsFunctionEnable = enable;
		if (flag)
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnInteractiveItemsFunctionEnableChanged, enable);
		}
	}

	// Token: 0x040077ED RID: 30701
	private string CD_TIME_REASON = "限时物品主动添加倒计时 [ConfigId:{0}, UniqueId:{1}]";

	// Token: 0x040077EE RID: 30702
	private int? OutsideUniqueId;

	// Token: 0x040077EF RID: 30703
	private int CurrentLockItemUniqueId;

	// Token: 0x040077F0 RID: 30704
	[Nullable(2)]
	private global::ItemViewData SelectedItemViewData;

	// Token: 0x040077F1 RID: 30705
	[Nullable(2)]
	private List<int> InventoryTabOpenIdList;

	// Token: 0x040077F2 RID: 30706
	[Nullable(2)]
	private NormalInventoryDataProxy _DefaultProxy;

	// Token: 0x040077F3 RID: 30707
	[Nullable(2)]
	private InventoryDataProxy _CurrentProxy;

	// Token: 0x040077F4 RID: 30708
	private readonly Dictionary<int, Dictionary<int, CommonItemData>> CommonItemMap = new Dictionary<int, Dictionary<int, CommonItemData>>();

	// Token: 0x040077F5 RID: 30709
	private readonly Dictionary<int, WeaponItemData> WeaponItemMap = new Dictionary<int, WeaponItemData>();

	// Token: 0x040077F6 RID: 30710
	private readonly Dictionary<int, PhantomItemData> PhantomItemMap = new Dictionary<int, PhantomItemData>();

	// Token: 0x040077F7 RID: 30711
	private readonly Dictionary<int, CalabashSkinItemData> CalabashSkinItemMap = new Dictionary<int, CalabashSkinItemData>();

	// Token: 0x040077F8 RID: 30712
	private readonly Dictionary<int, OrnamentItemData> OrnamentItemMap = new Dictionary<int, OrnamentItemData>();

	// Token: 0x040077F9 RID: 30713
	private readonly Dictionary<InventoryDefine.EItemType, HashSet<CommonItemData>> CommonItemByItemTypeMap = new Dictionary<InventoryDefine.EItemType, HashSet<CommonItemData>>();

	// Token: 0x040077FA RID: 30714
	private readonly Dictionary<InventoryDefine.EItemType, HashSet<ItemDataBase>> ItemTypeMap = new Dictionary<InventoryDefine.EItemType, HashSet<ItemDataBase>>();

	// Token: 0x040077FB RID: 30715
	private readonly Dictionary<InventoryDefine.EItemMainTypeId, global::ItemMainTypeMapping> ItemMainTypeMap = new Dictionary<InventoryDefine.EItemMainTypeId, global::ItemMainTypeMapping>();

	// Token: 0x040077FC RID: 30716
	[Nullable(2)]
	private AcquireData CurrentAcquireData;

	// Token: 0x040077FD RID: 30717
	private readonly HashSet<long> CdTimeStampSet = new HashSet<long>();

	// Token: 0x040077FE RID: 30718
	private readonly Dictionary<long, TimerHandle> CdTimeStampHandleMap = new Dictionary<long, TimerHandle>();

	// Token: 0x040077FF RID: 30719
	public bool IsConfirmDestruction;

	// Token: 0x04007800 RID: 30720
	private int? ItemNeedCount;

	// Token: 0x04007801 RID: 30721
	private readonly Dictionary<PhantomSettingType, List<PhantomManageConfigData>> PhantomManageConfig = new Dictionary<PhantomSettingType, List<PhantomManageConfigData>>();

	// Token: 0x04007802 RID: 30722
	[Nullable(2)]
	private HashSet<int> PhantomManageSelectSet;

	// Token: 0x04007803 RID: 30723
	private bool InteractiveItemsFunctionEnable = true;
}
