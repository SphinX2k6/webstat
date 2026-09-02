using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory.Data;

// Token: 0x02001EE2 RID: 7906
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryRoleEquipData
{
	// Token: 0x0600EA45 RID: 59973 RVA: 0x003F8E7C File Offset: 0x003F707C
	public HonamiStoryRoleEquipData(int rolePosition)
	{
		this.RolePosition = rolePosition;
	}

	// Token: 0x0600EA46 RID: 59974 RVA: 0x003F8EA8 File Offset: 0x003F70A8
	public List<HonamiStoryEquipItemData> GetEquipItemDataList()
	{
		List<HonamiStoryEquipItemData> list = new List<HonamiStoryEquipItemData>();
		foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in this.SlotData)
		{
			HonamiStoryEquipItemData itemData = honamiStoryRoleEquipSlotData.GetItemData();
			if (itemData != null)
			{
				list.Add(itemData);
			}
		}
		return list;
	}

	// Token: 0x0600EA47 RID: 59975 RVA: 0x003F8F0C File Offset: 0x003F710C
	public int GetCurPowerLevel(bool isForShow = true)
	{
		List<HonamiStoryEquipItemData> equipItemDataList = this.GetEquipItemDataList();
		return this.GetPowerLevelByItemList(equipItemDataList, isForShow);
	}

	// Token: 0x0600EA48 RID: 59976 RVA: 0x003F8F28 File Offset: 0x003F7128
	public int GetPowerLevelByItemList(List<HonamiStoryEquipItemData> itemList, bool isForShow)
	{
		if (this.RoleId <= 0)
		{
			return 0;
		}
		int num = 0;
		HonamiStoryWeaponData weaponData = ModelBase<HonamiStoryModel>.Instance.GetWeaponData(this.WeaponId);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int num2 = isForShow ? 0 : 100;
		foreach (HonamiStoryEquipItemData honamiStoryEquipItemData in itemList)
		{
			num += honamiStoryEquipItemData.GetBaseEnhance();
			int groupId = honamiStoryEquipItemData.GetGroupId();
			if (HonamiStoryUtil.CheckRolePowerValid(honamiStoryEquipItemData.GetRoleId(), this.GetParentRoleId()))
			{
				if (groupId == 0)
				{
					num += honamiStoryEquipItemData.GetRoleEnhance() + num2;
				}
				else
				{
					int val;
					if (!dictionary.TryGetValue(groupId, out val))
					{
						val = 0;
					}
					dictionary[groupId] = Math.Max(val, honamiStoryEquipItemData.GetRoleEnhance() + num2);
				}
			}
			if (weaponData != null && weaponData.PluginTags.Contains(honamiStoryEquipItemData.GetWeaponTag()))
			{
				if (groupId == 0)
				{
					num += honamiStoryEquipItemData.GetWeaponEnhance();
				}
				else
				{
					int val2;
					if (!dictionary.TryGetValue(groupId, out val2))
					{
						val2 = 0;
					}
					dictionary[groupId] = Math.Max(val2, honamiStoryEquipItemData.GetWeaponEnhance());
				}
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			num += keyValuePair.Value;
		}
		if (weaponData == null)
		{
			return num;
		}
		int num3 = 0;
		foreach (int suitId in weaponData.SuitId)
		{
			if (this.IsSuitActivate(suitId, itemList).IsActive)
			{
				HonamiStoryWeaponSuitData weaponSuitData = ModelBase<HonamiStoryModel>.Instance.GetWeaponSuitData(suitId);
				num += weaponSuitData.Enhance;
				num3++;
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in weaponData.ExtraSuitAddEnhanceLevel)
		{
			if (keyValuePair2.Key <= num3)
			{
				num += keyValuePair2.Value;
			}
		}
		return num;
	}

	// Token: 0x0600EA49 RID: 59977 RVA: 0x003F9158 File Offset: 0x003F7358
	public int GetParentRoleId()
	{
		return ModelBase<HonamiStoryModel>.Instance.GetParentRoleId(this.RoleId);
	}

	// Token: 0x0600EA4A RID: 59978 RVA: 0x003F916C File Offset: 0x003F736C
	public bool CheckItemBuffIsActive(HonamiStoryEquipItemData itemData)
	{
		if (itemData.GetRoleId() != 0)
		{
			return this.CheckRoleItemBuffIsActive(itemData);
		}
		if (itemData.GetGroupId() == 0)
		{
			return true;
		}
		bool result = false;
		List<HonamiStoryEquipItemData> equipItemDataList = this.GetEquipItemDataList();
		Dictionary<int, HonamiStoryEquipItemData> dictionary = new Dictionary<int, HonamiStoryEquipItemData>();
		foreach (HonamiStoryEquipItemData honamiStoryEquipItemData in equipItemDataList)
		{
			int groupId = honamiStoryEquipItemData.GetGroupId();
			if (groupId != 0)
			{
				HonamiStoryEquipItemData honamiStoryEquipItemData2;
				if (dictionary.TryGetValue(groupId, out honamiStoryEquipItemData2))
				{
					int quality = honamiStoryEquipItemData2.GetQuality();
					int quality2 = honamiStoryEquipItemData.GetQuality();
					if (quality >= quality2)
					{
						continue;
					}
				}
				dictionary[groupId] = honamiStoryEquipItemData;
			}
		}
		int groupId2 = itemData.GetGroupId();
		HonamiStoryEquipItemData honamiStoryEquipItemData3;
		if (dictionary.TryGetValue(groupId2, out honamiStoryEquipItemData3) && honamiStoryEquipItemData3.GetIncId() == itemData.GetIncId())
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600EA4B RID: 59979 RVA: 0x003F9238 File Offset: 0x003F7438
	public bool CheckRoleItemBuffIsActive(HonamiStoryEquipItemData itemData)
	{
		bool groupId = itemData.GetGroupId() != 0;
		int roleId = itemData.GetRoleId();
		if (!groupId && HonamiStoryUtil.CheckRolePowerValid(roleId, this.GetParentRoleId()))
		{
			return true;
		}
		bool result = false;
		List<HonamiStoryEquipItemData> equipItemDataList = this.GetEquipItemDataList();
		Dictionary<int, HonamiStoryEquipItemData> dictionary = new Dictionary<int, HonamiStoryEquipItemData>();
		foreach (HonamiStoryEquipItemData honamiStoryEquipItemData in equipItemDataList)
		{
			int groupId2 = honamiStoryEquipItemData.GetGroupId();
			if (groupId2 != 0 && HonamiStoryUtil.CheckRolePowerValid(honamiStoryEquipItemData.GetRoleId(), this.GetParentRoleId()))
			{
				HonamiStoryEquipItemData honamiStoryEquipItemData2;
				if (dictionary.TryGetValue(groupId2, out honamiStoryEquipItemData2))
				{
					int quality = honamiStoryEquipItemData2.GetQuality();
					int quality2 = honamiStoryEquipItemData.GetQuality();
					if (quality >= quality2)
					{
						continue;
					}
				}
				dictionary[groupId2] = honamiStoryEquipItemData;
			}
		}
		int groupId3 = itemData.GetGroupId();
		HonamiStoryEquipItemData honamiStoryEquipItemData3;
		if (dictionary.TryGetValue(groupId3, out honamiStoryEquipItemData3) && honamiStoryEquipItemData3.GetIncId() == itemData.GetIncId())
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600EA4C RID: 59980 RVA: 0x003F931C File Offset: 0x003F751C
	[NullableContext(2)]
	public void SetItemData(int position, HonamiStoryEquipItemData itemData)
	{
		this.ItemDataMap[position] = itemData;
		int honamiStoryPluginIndex = this.GetHonamiStoryPluginIndex(position);
		this.SlotData[honamiStoryPluginIndex].SetItemData(itemData);
	}

	// Token: 0x0600EA4D RID: 59981 RVA: 0x003F9350 File Offset: 0x003F7550
	[NullableContext(2)]
	public HonamiStoryEquipItemData GetItemDataByPosition(int position)
	{
		HonamiStoryEquipItemData result;
		if (this.ItemDataMap.TryGetValue(position, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600EA4E RID: 59982 RVA: 0x003F9370 File Offset: 0x003F7570
	public void RemoveItemData(int position)
	{
		this.ItemDataMap.Remove(position);
		int honamiStoryPluginIndex = this.GetHonamiStoryPluginIndex(position);
		this.SlotData[honamiStoryPluginIndex].SetItemData(null);
	}

	// Token: 0x0600EA4F RID: 59983 RVA: 0x003F93A4 File Offset: 0x003F75A4
	[NullableContext(2)]
	public void SetEquipData(HonamiStoryRackInfo info)
	{
		if (info == null)
		{
			return;
		}
		this.RoleId = info.RoleId;
		this.WeaponId = info.DressWeapon;
		List<HonamiStorySlotInfo> list = new List<HonamiStorySlotInfo>(info.HonamiStorySlotInfos);
		list.Sort((HonamiStorySlotInfo a, HonamiStorySlotInfo b) => a.SlotId.CompareTo(b.SlotId));
		foreach (HonamiStorySlotInfo honamiStorySlotInfo in list)
		{
			int num = honamiStorySlotInfo.SlotId - 1;
			if (num >= this.SlotData.Count)
			{
				HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData = new HonamiStoryRoleEquipSlotData(honamiStorySlotInfo.SlotId);
				honamiStoryRoleEquipSlotData.SetIsUnlock(honamiStorySlotInfo.IsUnlock);
				this.SlotData.Add(honamiStoryRoleEquipSlotData);
			}
			else
			{
				this.SlotData[num].SetIsUnlock(honamiStorySlotInfo.IsUnlock);
			}
		}
	}

	// Token: 0x0600EA50 RID: 59984 RVA: 0x003F948C File Offset: 0x003F768C
	public void SetRoleInfo(int roleId)
	{
		this.RoleId = roleId;
	}

	// Token: 0x0600EA51 RID: 59985 RVA: 0x003F9495 File Offset: 0x003F7695
	public void SetWeaponInfo(int weaponId)
	{
		this.WeaponId = weaponId;
	}

	// Token: 0x0600EA52 RID: 59986 RVA: 0x003F949E File Offset: 0x003F769E
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x0600EA53 RID: 59987 RVA: 0x003F94A6 File Offset: 0x003F76A6
	public int GetPosition()
	{
		return this.RolePosition;
	}

	// Token: 0x0600EA54 RID: 59988 RVA: 0x003F94AE File Offset: 0x003F76AE
	public int GetHonamiStoryPluginPosition(int pluginIndex)
	{
		return (this.RolePosition + 1) * 100 + pluginIndex + 1;
	}

	// Token: 0x0600EA55 RID: 59989 RVA: 0x003F94BF File Offset: 0x003F76BF
	public int GetHonamiStoryPluginIndex(int pluginPosition)
	{
		return pluginPosition - (this.RolePosition + 1) * 100 - 1;
	}

	// Token: 0x0600EA56 RID: 59990 RVA: 0x003F94D0 File Offset: 0x003F76D0
	[return: Nullable(new byte[]
	{
		1,
		2
	})]
	public List<HonamiStoryEquipItemData> GetPluginList()
	{
		List<HonamiStoryEquipItemData> list = new List<HonamiStoryEquipItemData>();
		foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in this.SlotData)
		{
			list.Add(honamiStoryRoleEquipSlotData.GetItemData());
		}
		return list;
	}

	// Token: 0x0600EA57 RID: 59991 RVA: 0x003F9530 File Offset: 0x003F7730
	public int GetWeaponId()
	{
		return this.WeaponId;
	}

	// Token: 0x0600EA58 RID: 59992 RVA: 0x003F9538 File Offset: 0x003F7738
	public int GetUnlockCounts()
	{
		int num = 0;
		foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in this.SlotData)
		{
			num += ((honamiStoryRoleEquipSlotData.GetIsUnlock() > false) ? 1 : 0);
		}
		return num;
	}

	// Token: 0x0600EA59 RID: 59993 RVA: 0x003F9594 File Offset: 0x003F7794
	public List<HonamiStoryRoleEquipSlotData> GetSlotList()
	{
		return this.SlotData;
	}

	// Token: 0x0600EA5A RID: 59994 RVA: 0x003F959C File Offset: 0x003F779C
	public List<HonamiStoryEquipItemData> GetEquipRoleItemList()
	{
		List<HonamiStoryEquipItemData> list = new List<HonamiStoryEquipItemData>();
		foreach (KeyValuePair<int, HonamiStoryEquipItemData> keyValuePair in this.ItemDataMap)
		{
			if (keyValuePair.Value != null && keyValuePair.Value.GetRoleId() != 0)
			{
				list.Add(keyValuePair.Value);
			}
		}
		return list;
	}

	// Token: 0x0600EA5B RID: 59995 RVA: 0x003F9614 File Offset: 0x003F7814
	public HonamiStoryWeaponSuitActiveData IsSuitActivate(int suitId, [Nullable(new byte[]
	{
		2,
		1
	})] List<HonamiStoryEquipItemData> itemList = null)
	{
		HonamiStoryWeaponSuitData weaponSuitData = ModelBase<HonamiStoryModel>.Instance.GetWeaponSuitData(suitId);
		if (weaponSuitData == null)
		{
			return new HonamiStoryWeaponSuitActiveData
			{
				IsActive = false,
				CurCount = 0,
				NeedCount = 0
			};
		}
		int weaponPluginType = weaponSuitData.WeaponPluginType;
		int needNum = weaponSuitData.NeedNum;
		int num = 0;
		if (itemList != null)
		{
			using (List<HonamiStoryEquipItemData>.Enumerator enumerator = itemList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetSubType() == weaponPluginType)
					{
						num++;
					}
				}
				goto IL_BF;
			}
		}
		foreach (KeyValuePair<int, HonamiStoryEquipItemData> keyValuePair in this.ItemDataMap)
		{
			HonamiStoryEquipItemData value = keyValuePair.Value;
			if (value != null && value.GetSubType() == weaponPluginType)
			{
				num++;
			}
		}
		IL_BF:
		return new HonamiStoryWeaponSuitActiveData
		{
			IsActive = (num >= needNum),
			CurCount = num,
			NeedCount = needNum
		};
	}

	// Token: 0x0600EA5C RID: 59996 RVA: 0x003F971C File Offset: 0x003F791C
	public int CheckEquipOnEmpty(HonamiStoryEquipItemData itemData)
	{
		List<HonamiStoryEquipItemData> list = new List<HonamiStoryEquipItemData>();
		int num = 0;
		foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in this.SlotData)
		{
			HonamiStoryEquipItemData itemData2 = honamiStoryRoleEquipSlotData.GetItemData();
			if (itemData2 != null)
			{
				list.Add(itemData2);
			}
			if (!honamiStoryRoleEquipSlotData.GetIsUnlock())
			{
				break;
			}
			num++;
		}
		if (list.Count >= num)
		{
			return 0;
		}
		list.Add(itemData);
		return this.GetPowerLevelByItemList(list, false) - this.GetCurPowerLevel(false);
	}

	// Token: 0x0600EA5D RID: 59997 RVA: 0x003F97B0 File Offset: 0x003F79B0
	public int GetNextEmptySlot()
	{
		foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in this.SlotData)
		{
			if (honamiStoryRoleEquipSlotData.GetIsUnlock() && honamiStoryRoleEquipSlotData.GetItemData() == null)
			{
				return this.GetHonamiStoryPluginPosition(honamiStoryRoleEquipSlotData.GetSlotId() - 1);
			}
		}
		return -1;
	}

	// Token: 0x0600EA5E RID: 59998 RVA: 0x003F9820 File Offset: 0x003F7A20
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public ValueTuple<int, int, HonamiStoryEquipItemData> CheckEquipInstead(HonamiStoryEquipItemData itemData)
	{
		int num = -1;
		int num2 = this.GetCurPowerLevel(true);
		HonamiStoryEquipItemData item = null;
		List<HonamiStoryEquipItemData> list = new List<HonamiStoryEquipItemData>();
		foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in this.SlotData)
		{
			HonamiStoryEquipItemData itemData2 = honamiStoryRoleEquipSlotData.GetItemData();
			if (itemData2 != null)
			{
				list.Add(itemData2);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			List<HonamiStoryEquipItemData> list2 = new List<HonamiStoryEquipItemData>();
			for (int j = 0; j < list.Count; j++)
			{
				if (i == j)
				{
					list2.Add(itemData);
				}
				else
				{
					list2.Add(list[j]);
				}
			}
			int powerLevelByItemList = this.GetPowerLevelByItemList(list2, false);
			if (powerLevelByItemList > num2)
			{
				num = i;
				num2 = powerLevelByItemList;
				item = list[i];
			}
		}
		int item2 = (num != -1) ? this.GetHonamiStoryPluginPosition(num) : -1;
		int item3 = Math.Max(0, num2 - this.GetCurPowerLevel(false));
		return new ValueTuple<int, int, HonamiStoryEquipItemData>(item2, item3, item);
	}

	// Token: 0x040070F2 RID: 28914
	private int RoleId;

	// Token: 0x040070F3 RID: 28915
	private int WeaponId = -1;

	// Token: 0x040070F4 RID: 28916
	private readonly List<HonamiStoryRoleEquipSlotData> SlotData = new List<HonamiStoryRoleEquipSlotData>();

	// Token: 0x040070F5 RID: 28917
	private readonly int RolePosition;

	// Token: 0x040070F6 RID: 28918
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<int, HonamiStoryEquipItemData> ItemDataMap = new Dictionary<int, HonamiStoryEquipItemData>();
}
