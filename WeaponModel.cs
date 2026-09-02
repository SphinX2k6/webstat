using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using Google.Protobuf.Collections;

// Token: 0x02002D15 RID: 11541
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WeaponModel : ModelBase<WeaponModel>
{
	// Token: 0x0601749C RID: 95388 RVA: 0x00674394 File Offset: 0x00672594
	public unsafe void AddWeaponData(WeaponItem weaponItem)
	{
		WeaponInstance weaponInstance = this.CreateWeaponInstance(weaponItem);
		int? incId = weaponInstance.GetIncId();
		this.WeaponDataMap[incId.Value] = weaponInstance;
		if (weaponInstance.HasRole())
		{
			int roleId = weaponInstance.GetRoleId();
			this.RoleWeaponDataMap[roleId] = incId.Value;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "武器设置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("roleId", roleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("incId", incId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x0601749D RID: 95389 RVA: 0x00674444 File Offset: 0x00672644
	public void RemoveWeaponData(int incId)
	{
		WeaponInstance weaponInstance;
		if (!this.WeaponDataMap.TryGetValue(incId, out weaponInstance))
		{
			return;
		}
		if (weaponInstance.HasRole())
		{
			int roleId = weaponInstance.GetRoleId();
			this.RoleWeaponDataMap.Remove(roleId);
		}
		this.WeaponDataMap.Remove(incId);
	}

	// Token: 0x0601749E RID: 95390 RVA: 0x0067448B File Offset: 0x0067268B
	protected WeaponInstance CreateWeaponInstance(WeaponItem weaponItem)
	{
		WeaponInstance weaponInstance = new WeaponInstance();
		weaponInstance.SetWeaponItem(weaponItem);
		return weaponInstance;
	}

	// Token: 0x0601749F RID: 95391 RVA: 0x0067449C File Offset: 0x0067269C
	public void SetWeaponLevelData(int incId, int exp, int level)
	{
		WeaponInstance weaponInstance;
		if (this.WeaponDataMap.TryGetValue(incId, out weaponInstance))
		{
			weaponInstance.SetExp(exp);
			weaponInstance.SetLevel(level);
		}
	}

	// Token: 0x060174A0 RID: 95392 RVA: 0x006744C8 File Offset: 0x006726C8
	public void SetWeaponBreachData(int incId, int breach)
	{
		WeaponInstance weaponInstance;
		if (this.WeaponDataMap.TryGetValue(incId, out weaponInstance))
		{
			weaponInstance.SetBreachLevel(breach);
		}
	}

	// Token: 0x060174A1 RID: 95393 RVA: 0x006744EC File Offset: 0x006726EC
	public void SetWeaponResonanceData(int incId, int resonanceLevel)
	{
		WeaponInstance weaponInstance;
		if (this.WeaponDataMap.TryGetValue(incId, out weaponInstance))
		{
			weaponInstance.SetResonanceLevel(resonanceLevel);
		}
	}

	// Token: 0x060174A2 RID: 95394 RVA: 0x00674510 File Offset: 0x00672710
	public int GetWeaponLevelById(int incId)
	{
		WeaponInstance weaponInstance;
		if (this.WeaponDataMap.TryGetValue(incId, out weaponInstance))
		{
			return weaponInstance.GetLevel();
		}
		return 0;
	}

	// Token: 0x060174A3 RID: 95395 RVA: 0x00674538 File Offset: 0x00672738
	public WeaponDataBase GetWeaponDataByRoleDataId(int roleDataId, bool isSelf = true)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleDataId, isSelf);
		if (roleDataById.IsTrialRole())
		{
			return (roleDataById as RoleRobotData).GetWeaponData();
		}
		if (roleDataById.IsOnlineRole())
		{
			return (roleDataById as RoleOnlineInstanceData).GetWeaponData();
		}
		WeaponInstance weaponInstanceByRoleId = this.GetWeaponInstanceByRoleId(roleDataId);
		if (weaponInstanceByRoleId != null)
		{
			return weaponInstanceByRoleId;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Role;
		ELogAuthor author = ELogAuthor.BB;
		string message = "获取不到武器数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleDataId", roleDataId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x060174A4 RID: 95396 RVA: 0x006745B4 File Offset: 0x006727B4
	public int? GetWeaponIdByRoleDataId(int roleDataId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleDataId, true);
		if (roleDataById == null)
		{
			return new int?(ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleDataId).Value.InitWeaponItemId);
		}
		if (roleDataById.IsTrialRole())
		{
			return new int?((roleDataById as RoleRobotData).GetWeaponData().GetItemId());
		}
		WeaponInstance weaponInstanceByRoleId = this.GetWeaponInstanceByRoleId(roleDataId);
		if (weaponInstanceByRoleId != null)
		{
			return new int?(weaponInstanceByRoleId.GetItemId());
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Role;
		ELogAuthor author = ELogAuthor.BB;
		string message = "获取不到武器数据";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleDataId", roleDataId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x060174A5 RID: 95397 RVA: 0x00674660 File Offset: 0x00672860
	public WeaponInstance GetWeaponInstanceByRoleId(int roleId)
	{
		int key;
		WeaponInstance result;
		if (this.RoleWeaponDataMap.TryGetValue(roleId, out key) && this.WeaponDataMap.TryGetValue(key, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060174A6 RID: 95398 RVA: 0x00674690 File Offset: 0x00672890
	public WeaponInstance GetWeaponDataByIncId(int incId)
	{
		WeaponInstance result;
		if (this.WeaponDataMap.TryGetValue(incId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060174A7 RID: 95399 RVA: 0x006746B0 File Offset: 0x006728B0
	public void WeaponRoleLoadEquip(RepeatedField<RoleLoadEquipData> weaponEquipDataList)
	{
		if (weaponEquipDataList == null)
		{
			return;
		}
		foreach (RoleLoadEquipData roleLoadEquipData in weaponEquipDataList)
		{
			int roleID = roleLoadEquipData.RoleID;
			int equipIncID = roleLoadEquipData.EquipIncID;
			this.ChangeWeaponEquip(equipIncID, roleID);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.EquipWeapon);
		foreach (RoleLoadEquipData roleLoadEquipData2 in weaponEquipDataList)
		{
			if (roleLoadEquipData2.RoleID > 0)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.WeaponRoleEquipChanged, roleLoadEquipData2.RoleID);
			}
		}
	}

	// Token: 0x060174A8 RID: 95400 RVA: 0x00674768 File Offset: 0x00672968
	public void WeaponLevelUpResponse(WeaponLevelUpResponse response)
	{
		this.SetWeaponLevelData(response.IncId, response.WeaponExp, response.WeaponLevel);
		Singleton<EventSystem>.Instance.Emit(EEventName.WeaponLevelUp);
		WeaponInstance weaponInstance;
		if (this.WeaponDataMap.TryGetValue(response.IncId, out weaponInstance) && weaponInstance.HasRole())
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.WeaponRoleLevelUp, weaponInstance.GetRoleId());
		}
		this.WeaponLevelUpReceiveItem(response.ItemMap);
	}

	// Token: 0x060174A9 RID: 95401 RVA: 0x006747DC File Offset: 0x006729DC
	private void WeaponLevelUpReceiveItem(MapField<int, int> itemMap)
	{
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in itemMap)
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
			list.Add(item);
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<TItem>>(EEventName.WeaponLevelUpReceiveItem, list);
	}

	// Token: 0x060174AA RID: 95402 RVA: 0x00674858 File Offset: 0x00672A58
	public unsafe void ChangeWeaponEquip(int incId, int roleId)
	{
		WeaponInstance weaponInstance;
		if (!this.WeaponDataMap.TryGetValue(incId, out weaponInstance))
		{
			return;
		}
		int roleId2 = weaponInstance.GetRoleId();
		if (roleId2 > 0)
		{
			this.RoleWeaponDataMap[roleId2] = 0;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "武器设置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("lastRoleId", roleId2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("incId", 0);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		weaponInstance.SetRoleId(roleId);
		if (roleId > 0)
		{
			this.RoleWeaponDataMap[roleId] = incId;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Role;
			ELogAuthor author2 = ELogAuthor.LZK;
			string message2 = "武器设置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("roleId", roleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("incId", incId);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
	}

	// Token: 0x060174AB RID: 95403 RVA: 0x00674960 File Offset: 0x00672B60
	public float GetCurveValue(int curveId, float baseValue, int level, int breach)
	{
		WeaponPropertyGrowth? weaponPropertyGrowthConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponPropertyGrowthConfig(curveId, level, breach);
		return baseValue * ((float)((weaponPropertyGrowthConfig != null) ? weaponPropertyGrowthConfig.GetValueOrDefault().CurveValue : 0) / 10000f);
	}

	// Token: 0x060174AC RID: 95404 RVA: 0x006749A0 File Offset: 0x00672BA0
	public List<WeaponItemData> GetWeaponListFromReplace(int weaponType)
	{
		List<WeaponItemData> list = new List<WeaponItemData>();
		foreach (WeaponItemData weaponItemData in ModelBase<InventoryModel>.Instance.GetWeaponItemDataList())
		{
			if (this.GetWeaponDataByIncId(weaponItemData.GetUniqueId()).GetWeaponConfig().Value.WeaponType == weaponType)
			{
				list.Add(weaponItemData);
			}
		}
		return list;
	}

	// Token: 0x060174AD RID: 95405 RVA: 0x00674A24 File Offset: 0x00672C24
	public List<ItemDataBase> GetResonanceMaterialList(int incId)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		WeaponInstance weaponDataByIncId = this.GetWeaponDataByIncId(incId);
		int itemId = weaponDataByIncId.GetItemId();
		HashSet<ItemDataBase> itemDataBaseByMainType = instance.GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId.Weapon);
		List<ItemDataBase> list = new List<ItemDataBase>();
		foreach (ItemDataBase itemDataBase in itemDataBaseByMainType)
		{
			if (itemDataBase.GetConfigId() == itemId && itemDataBase.GetUniqueId() != incId && !this.GetWeaponDataByIncId(itemDataBase.GetUniqueId()).HasRole())
			{
				list.Add(itemDataBase);
			}
		}
		int[] array = weaponDataByIncId.GetResonanceConfig().Value.AlternativeConsume();
		if (array != null && array.Length != 0)
		{
			foreach (int configId in array)
			{
				foreach (ItemDataBase item in instance.GetItemDataBaseByConfigId(configId))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x060174AE RID: 95406 RVA: 0x00674B48 File Offset: 0x00672D48
	public List<ItemInfo> GetWeaponExpMaterialList()
	{
		List<ItemInfo> list = new List<ItemInfo>();
		foreach (ItemDataBase itemDataBase in ModelBase<InventoryModel>.Instance.GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId.Weapon))
		{
			if (itemDataBase.GetType().GetValueOrDefault() == InventoryDefine.EItemType.WeaponMaterial)
			{
				ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(itemDataBase.GetConfigId());
				if (config != null)
				{
					list.Add(config.Value);
				}
			}
		}
		list.Sort((ItemInfo a, ItemInfo b) => b.QualityId - a.QualityId);
		return list;
	}

	// Token: 0x060174AF RID: 95407 RVA: 0x00674C00 File Offset: 0x00672E00
	public Dictionary<int, int> GetCanChangeMaterialList(int overExp)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		List<ItemInfo> list = ConfigCommon.ToList<ItemInfo>(ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfigListByItemType(4));
		list.Sort(new Comparison<ItemInfo>(this.ExpItemDataListSort));
		int num = overExp;
		foreach (ItemInfo itemInfo in list)
		{
			WeaponExpItem? weaponExpItemConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(itemInfo.Id);
			if (num >= weaponExpItemConfig.Value.BasicExp)
			{
				double num2 = Math.Floor((double)((float)num / (float)weaponExpItemConfig.Value.BasicExp));
				dictionary[itemInfo.Id] = (int)num2;
				num %= weaponExpItemConfig.Value.BasicExp;
			}
		}
		return dictionary;
	}

	// Token: 0x060174B0 RID: 95408 RVA: 0x00674CD8 File Offset: 0x00672ED8
	private int ExpItemDataListSort(ItemInfo a, ItemInfo b)
	{
		return b.QualityId - a.QualityId;
	}

	// Token: 0x060174B1 RID: 95409 RVA: 0x00674CEC File Offset: 0x00672EEC
	public int GetResonanceNeedMoney(int resonanceId, int startLevel, int endLevel)
	{
		int num = 0;
		for (int i = startLevel; i < endLevel; i++)
		{
			num += ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(resonanceId, i).Value.GoldConsume;
		}
		return num;
	}

	// Token: 0x060174B2 RID: 95410 RVA: 0x00674D28 File Offset: 0x00672F28
	public int GetWeaponBreachMaxLevel(int breachId)
	{
		IReadOnlyList<WeaponBreach> weaponBreachList = ConfigBase<WeaponConfig>.Instance.GetWeaponBreachList(breachId);
		int count = weaponBreachList.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			WeaponBreach weaponBreach = weaponBreachList[i];
			if (weaponBreach.Level > num)
			{
				num = weaponBreach.Level;
			}
		}
		return num;
	}

	// Token: 0x060174B3 RID: 95411 RVA: 0x00674D74 File Offset: 0x00672F74
	public int GetWeaponItemBaseExp(ItemDataBase itemData)
	{
		if (itemData.GetType().GetValueOrDefault() == InventoryDefine.EItemType.WeaponMaterial)
		{
			return ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(itemData.GetConfigId()).Value.BasicExp;
		}
		return ConfigBase<WeaponConfig>.Instance.GetWeaponQualityInfo(itemData.GetQuality()).Value.BasicExp;
	}

	// Token: 0x060174B4 RID: 95412 RVA: 0x00674DD4 File Offset: 0x00672FD4
	public string[] GetWeaponConfigDescParams(WeaponConf weaponConfig, int resonanceLevel)
	{
		List<string> list = new List<string>();
		foreach (StringArray stringArray in weaponConfig.DescParams())
		{
			if (stringArray.ToString() != "")
			{
				int num = (resonanceLevel >= stringArray.ArrayStringLength) ? stringArray.ArrayStringLength : resonanceLevel;
				string item = stringArray.ArrayString(num - 1);
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060174B5 RID: 95413 RVA: 0x00674E4F File Offset: 0x0067304F
	public EWeaponViewName GetCurSelectViewName()
	{
		return this.CurSelectViewName;
	}

	// Token: 0x060174B6 RID: 95414 RVA: 0x00674E57 File Offset: 0x00673057
	public void SetCurSelectViewName(EWeaponViewName name)
	{
		this.CurSelectViewName = name;
	}

	// Token: 0x060174B7 RID: 95415 RVA: 0x00674E60 File Offset: 0x00673060
	public bool IsWeaponUsedByUncommonRole(int incId)
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		if (weaponDataByIncId != null)
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(weaponDataByIncId.GetRoleId());
			if (roleInstanceById != null && roleInstanceById.GetRoleConfig().RoleType != 1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060174B8 RID: 95416 RVA: 0x00674EA4 File Offset: 0x006730A4
	public bool CanItemUseAsExpItem(ItemDataBase itemData)
	{
		if (itemData.GetType().GetValueOrDefault() == InventoryDefine.EItemType.Weapon && itemData.GetUniqueId() > 0)
		{
			WeaponInstance weaponDataByIncId = this.GetWeaponDataByIncId(itemData.GetUniqueId());
			if (weaponDataByIncId.HasRole() || weaponDataByIncId.GetItemConfig().QualityId >= 5)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060174B9 RID: 95417 RVA: 0x00674EF4 File Offset: 0x006730F4
	public bool IsWeaponHighQuality(WeaponInstance weaponInstance)
	{
		int weaponQualityCheck = ConfigBase<WeaponConfig>.Instance.GetWeaponQualityCheck();
		return weaponInstance.GetItemConfig().QualityId > weaponQualityCheck;
	}

	// Token: 0x060174BA RID: 95418 RVA: 0x00674F20 File Offset: 0x00673120
	public bool IsWeaponHighLevel(WeaponInstance weaponInstance)
	{
		int weaponLevelCheck = ConfigBase<WeaponConfig>.Instance.GetWeaponLevelCheck();
		return weaponInstance.GetLevel() > weaponLevelCheck;
	}

	// Token: 0x060174BB RID: 95419 RVA: 0x00674F44 File Offset: 0x00673144
	public bool IsWeaponHighResonanceLevel(WeaponInstance weaponInstance)
	{
		int weaponResonanceCheck = ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceCheck();
		return weaponInstance.GetResonanceLevel() > weaponResonanceCheck;
	}

	// Token: 0x060174BC RID: 95420 RVA: 0x00674F65 File Offset: 0x00673165
	public bool HasWeaponResonance(WeaponInstance weaponInstance)
	{
		return weaponInstance.GetResonanceLevel() > 1;
	}

	// Token: 0x060174BD RID: 95421 RVA: 0x00674F70 File Offset: 0x00673170
	public int GetWeaponItemExp(int incId, int configId)
	{
		if (incId > 0)
		{
			WeaponInstance weaponDataByIncId = this.GetWeaponDataByIncId(incId);
			if (weaponDataByIncId != null)
			{
				return weaponDataByIncId.GetMaterialExp();
			}
		}
		return ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(configId).Value.BasicExp;
	}

	// Token: 0x060174BE RID: 95422 RVA: 0x00674FB0 File Offset: 0x006731B0
	public int GetWeaponItemExpCost(int incId, int configId)
	{
		if (incId > 0)
		{
			WeaponInstance weaponDataByIncId = this.GetWeaponDataByIncId(incId);
			if (weaponDataByIncId != null)
			{
				return weaponDataByIncId.GetMaterialCost();
			}
		}
		return ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemConfig(configId).Value.Cost;
	}

	// Token: 0x060174BF RID: 95423 RVA: 0x00674FF0 File Offset: 0x006731F0
	public int GetWeaponExpItemListCost(TCommonMultipleConsumeData[] itemList)
	{
		int num = 0;
		foreach (TCommonMultipleConsumeData tcommonMultipleConsumeData in itemList)
		{
			if (tcommonMultipleConsumeData.ItemData.ItemId == 0)
			{
				break;
			}
			int weaponItemExpCost = this.GetWeaponItemExpCost(tcommonMultipleConsumeData.ItemData.IncId, tcommonMultipleConsumeData.ItemData.ItemId);
			num += weaponItemExpCost * tcommonMultipleConsumeData.Count;
		}
		return num;
	}

	// Token: 0x060174C0 RID: 95424 RVA: 0x00675054 File Offset: 0x00673254
	public List<ItemDataBase> GetWeaponExpItemList(int? incId)
	{
		List<ItemDataBase> list = new List<ItemDataBase>();
		foreach (ItemDataBase itemDataBase in ModelBase<InventoryModel>.Instance.GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId.Weapon))
		{
			if (this.CanItemUseAsExpItem(itemDataBase))
			{
				int? num = incId;
				int uniqueId = itemDataBase.GetUniqueId();
				if (!(num.GetValueOrDefault() == uniqueId & num != null))
				{
					list.Add(itemDataBase);
				}
			}
		}
		return list;
	}

	// Token: 0x060174C1 RID: 95425 RVA: 0x006750DC File Offset: 0x006732DC
	public List<ItemDataBase> GetWeaponExpItemListUseToAuto(int? incId)
	{
		List<ItemDataBase> list = new List<ItemDataBase>();
		foreach (ItemDataBase itemDataBase in this.GetWeaponExpItemList(incId))
		{
			if (!itemDataBase.GetIsLock())
			{
				if (itemDataBase.GetType().GetValueOrDefault() == InventoryDefine.EItemType.Weapon)
				{
					WeaponInstance weaponDataByIncId = this.GetWeaponDataByIncId(itemDataBase.GetUniqueId());
					if (this.IsWeaponHighResonanceLevel(weaponDataByIncId) || this.IsWeaponHighLevel(weaponDataByIncId))
					{
						continue;
					}
				}
				list.Add(itemDataBase);
			}
		}
		this.GetWeaponExpItemListWithSort(list);
		return list;
	}

	// Token: 0x060174C2 RID: 95426 RVA: 0x0067517C File Offset: 0x0067337C
	public List<ItemDataBase> GetWeaponExpItemListWithSort(List<ItemDataBase> dataList)
	{
		HashSet<int> hashSet = new HashSet<int>();
		hashSet.Add(2);
		hashSet.Add(10);
		hashSet.Add(8);
		ModelBase<SortModel>.Instance.SortDataByData<ItemDataBase>(dataList, ESortDataType.Weapon, hashSet, true);
		return dataList;
	}

	// Token: 0x060174C3 RID: 95427 RVA: 0x006751B8 File Offset: 0x006733B8
	public List<ISelectedData> AutoAddExpItem(int needExp, int maxCount, ISelectedData[] sourceList, Func<ISelectedData, int> getExp)
	{
		int num = needExp;
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (ISelectedData selectedData in sourceList)
		{
			if (list.Count >= maxCount || num <= 0)
			{
				break;
			}
			int num2 = getExp(selectedData);
			int val = (int)Math.Ceiling((double)((float)num / (float)num2));
			int val2 = selectedData.Count - selectedData.SelectedCount;
			int num3 = selectedData.SelectedCount + Math.Min(val, val2);
			if (num3 > 0)
			{
				SelectedData item = new SelectedData
				{
					IncId = selectedData.IncId,
					ItemId = selectedData.ItemId,
					Count = selectedData.Count,
					SelectedCount = num3
				};
				list.Add(item);
				num -= num3 * num2;
			}
		}
		return list;
	}

	// Token: 0x060174C4 RID: 95428 RVA: 0x00675288 File Offset: 0x00673488
	public bool CheckSatisfyExp(int needExp, int maxCount, ISelectedData[] sourceList, Func<ISelectedData, int> getExp)
	{
		int num = needExp;
		int num2 = 0;
		foreach (ISelectedData selectedData in sourceList)
		{
			if (num2 >= maxCount || num <= 0)
			{
				break;
			}
			int num3 = getExp(selectedData);
			int val = (int)Math.Ceiling((double)((float)num / (float)num3));
			int val2 = selectedData.Count - selectedData.SelectedCount;
			int num4 = selectedData.SelectedCount + Math.Min(val, val2);
			if (num4 > 0)
			{
				num2++;
				num -= num4 * num3;
			}
		}
		return num <= 0;
	}

	// Token: 0x060174C5 RID: 95429 RVA: 0x0067530C File Offset: 0x0067350C
	public void AutoAddExpItemEx(int needExp, ISelectedData[] sourceList, Func<ISelectedData, int> getExp)
	{
		int num = needExp;
		foreach (ISelectedData selectedData in sourceList)
		{
			if (num <= 0)
			{
				break;
			}
			int num2 = getExp(selectedData);
			int val = (int)Math.Ceiling((double)((float)num / (float)num2));
			int val2 = selectedData.Count - selectedData.SelectedCount;
			int num3 = selectedData.SelectedCount + Math.Min(val, val2);
			selectedData.SelectedCount = num3;
			num -= num3 * num2;
		}
	}

	// Token: 0x060174C6 RID: 95430 RVA: 0x0067537C File Offset: 0x0067357C
	public IWeaponAttributeParam[] GetWeaponAttributeParamList(WeaponConf weaponConfig)
	{
		return new IWeaponAttributeParam[]
		{
			new WeaponAttributeParam
			{
				PropId = weaponConfig.FirstPropId.Value,
				CurveId = weaponConfig.FirstCurve
			},
			new WeaponAttributeParam
			{
				PropId = weaponConfig.SecondPropId.Value,
				CurveId = weaponConfig.SecondCurve
			}
		};
	}

	// Token: 0x060174C7 RID: 95431 RVA: 0x006753E4 File Offset: 0x006735E4
	public EWeaponBreachState GetWeaponBreachState(int incId)
	{
		WeaponInstance weaponDataByIncId = this.GetWeaponDataByIncId(incId);
		WeaponBreach? breachConfig = weaponDataByIncId.GetBreachConfig();
		if (!ControllerBase<LevelGeneralController>.Instance.CheckCondition(breachConfig.Value.ConditionId.ToString(), null, true, Array.Empty<object>()))
		{
			return EWeaponBreachState.NoEnoughCondition;
		}
		WeaponBreach? breachConsume = weaponDataByIncId.GetBreachConsume();
		for (int i = 0; i < breachConsume.Value.ConsumeLength; i++)
		{
			DicIntInt? dicIntInt = breachConsume.Value.Consume(i);
			int key = dicIntInt.Value.Key;
			int value = dicIntInt.Value.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) < value)
			{
				return EWeaponBreachState.NoEnoughMaterial;
			}
		}
		int goldConsume = breachConfig.Value.GoldConsume;
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0) < goldConsume)
		{
			return EWeaponBreachState.NoEnoughMoney;
		}
		return EWeaponBreachState.CanBreach;
	}

	// Token: 0x060174C8 RID: 95432 RVA: 0x006754C4 File Offset: 0x006736C4
	public bool RedDotWeaponBreachCondition(int roleId)
	{
		WeaponInstance weaponInstanceByRoleId = this.GetWeaponInstanceByRoleId(roleId);
		return weaponInstanceByRoleId != null && weaponInstanceByRoleId.CanGoBreach() && this.GetWeaponBreachState(weaponInstanceByRoleId.GetIncId().Value) == EWeaponBreachState.CanBreach;
	}

	// Token: 0x060174C9 RID: 95433 RVA: 0x00675500 File Offset: 0x00673700
	public bool RedDotWeaponResonanceCondition(int weaponIncId)
	{
		WeaponInstance weaponDataByIncId = this.GetWeaponDataByIncId(weaponIncId);
		if (weaponDataByIncId == null)
		{
			return false;
		}
		int resonanceLevel = weaponDataByIncId.GetResonanceLevel();
		int resonLevelLimit = weaponDataByIncId.GetWeaponConfig().Value.ResonLevelLimit;
		if (resonanceLevel >= resonLevelLimit)
		{
			return false;
		}
		WeaponReson? resonanceConfig = weaponDataByIncId.GetResonanceConfig();
		return resonanceConfig != null && resonanceConfig.Value.MaterialPlaceType == 1 && resonanceConfig.Value.AlternativeConsume().Length != 0 && ModelBase<InventoryModel>.Instance.GetCommonItemCount(resonanceConfig.Value.AlternativeConsume()[0], 0) > 0 && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0) >= resonanceConfig.Value.GoldConsume;
	}

	// Token: 0x060174CA RID: 95434 RVA: 0x006755C0 File Offset: 0x006737C0
	public bool RedDotWeaponResonanceConditionByRole(int roleId)
	{
		WeaponInstance weaponInstanceByRoleId = this.GetWeaponInstanceByRoleId(roleId);
		int? num = (weaponInstanceByRoleId != null) ? weaponInstanceByRoleId.GetIncId() : null;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				return this.RedDotWeaponResonanceCondition(num.Value);
			}
		}
		return false;
	}

	// Token: 0x060174CB RID: 95435 RVA: 0x0067561C File Offset: 0x0067381C
	public List<ISelectedData> GetExpItemInInventory()
	{
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (ItemInfo itemInfo in this.GetWeaponExpItemConfigList())
		{
			SelectedData item = new SelectedData
			{
				IncId = 0,
				ItemId = itemInfo.Id,
				Count = ModelBase<InventoryModel>.Instance.GetCommonItemCount(itemInfo.Id, 0),
				SelectedCount = 0
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x060174CC RID: 95436 RVA: 0x006756B0 File Offset: 0x006738B0
	public List<ItemInfo> GetWeaponExpItemConfigList()
	{
		List<ItemInfo> list = new List<ItemInfo>();
		List<WeaponExpItem> weaponExpItemList = ConfigBase<WeaponConfig>.Instance.GetWeaponExpItemList();
		if (weaponExpItemList != null)
		{
			foreach (WeaponExpItem weaponExpItem in weaponExpItemList)
			{
				ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(weaponExpItem.Id);
				if (config != null)
				{
					list.Add(config.Value);
				}
			}
		}
		return list;
	}

	// Token: 0x0400B2E8 RID: 45800
	private readonly Dictionary<int, WeaponInstance> WeaponDataMap = new Dictionary<int, WeaponInstance>();

	// Token: 0x0400B2E9 RID: 45801
	private readonly Dictionary<int, int> RoleWeaponDataMap = new Dictionary<int, int>();

	// Token: 0x0400B2EA RID: 45802
	private EWeaponViewName CurSelectViewName;

	// Token: 0x0400B2EB RID: 45803
	public int BlueprintWeaponBreachLevel;

	// Token: 0x0400B2EC RID: 45804
	public int BlueprintWeaponEquippedRoleId;

	// Token: 0x0400B2ED RID: 45805
	public bool LevelUpConfirmTipsNotShow;
}
