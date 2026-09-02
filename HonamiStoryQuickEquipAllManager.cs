using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;
using Cysharp.Threading.Tasks;

// Token: 0x02001EE1 RID: 7905
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryQuickEquipAllManager
{
	// Token: 0x0600EA3C RID: 59964 RVA: 0x003F812C File Offset: 0x003F632C
	public bool Refresh(bool force)
	{
		if (!this.IsDirty && !force)
		{
			return false;
		}
		this.IsDirty = false;
		this.OldPowerLevel = this.CurPowerLevel;
		this.CurPowerLevel = 0;
		this.CurRealPowerLevel = 0;
		this.OccupySet.Clear();
		List<HonamiStoryRoleEquipData> roleEquipDataList = ModelBase<HonamiStoryModel>.Instance.GetPlayerBackpackData().GetRoleEquipDataList(true);
		this.RoleDataMap.Clear();
		for (int i = 0; i < roleEquipDataList.Count; i++)
		{
			HonamiStoryRoleEquipData roleData = roleEquipDataList[i];
			HonamiStoryQuickRoleData honamiStoryQuickRoleData = new HonamiStoryQuickRoleData();
			honamiStoryQuickRoleData.Init(roleData);
			this.RoleDataMap[i] = honamiStoryQuickRoleData;
		}
		Dictionary<int, List<HonamiStoryItemDataBase>> allItem = this.GetAllItem(roleEquipDataList);
		int num = 0;
		List<int> list = new List<int>();
		List<List<int>> sortOrderList = this.SortOrderClass.GetSortOrderList(roleEquipDataList.Count);
		Dictionary<int, List<HonamiStoryItemDataBase>> dictionary = new Dictionary<int, List<HonamiStoryItemDataBase>>();
		for (int j = 0; j < this.RoleDataMap.Count; j++)
		{
			HonamiStoryQuickRoleData honamiStoryQuickRoleData2 = this.RoleDataMap[j];
			if (honamiStoryQuickRoleData2.RoleId == 0)
			{
				dictionary[j] = new List<HonamiStoryItemDataBase>();
			}
			else
			{
				List<HonamiStoryItemDataBase> rolePluginList = this.GetRolePluginList(honamiStoryQuickRoleData2.RoleId, allItem);
				dictionary[j] = rolePluginList;
			}
		}
		foreach (List<int> list2 in sortOrderList)
		{
			HashSet<HonamiStoryItemDataBase> hashSet = new HashSet<HonamiStoryItemDataBase>();
			foreach (KeyValuePair<int, List<HonamiStoryItemDataBase>> keyValuePair in dictionary)
			{
				foreach (HonamiStoryItemDataBase item in keyValuePair.Value)
				{
					hashSet.Add(item);
				}
			}
			List<List<int>> list3 = new List<List<int>>();
			foreach (int num2 in list2)
			{
				foreach (HonamiStoryItemDataBase item2 in dictionary[num2])
				{
					hashSet.Remove(item2);
				}
				int maxPower = this.RoleDataMap[num2].GetMaxPower(allItem, hashSet);
				list3.Add(new List<int>
				{
					num2,
					maxPower
				});
				foreach (HonamiStoryItemDataBase item3 in this.RoleDataMap[num2].BestResult)
				{
					hashSet.Add(item3);
				}
			}
			int num3 = 0;
			foreach (List<int> list4 in list3)
			{
				num3 += list4[1];
			}
			if (num3 > num)
			{
				num = num3;
				list = new List<int>(list2);
			}
		}
		if (num > 0)
		{
			foreach (KeyValuePair<int, List<HonamiStoryItemDataBase>> keyValuePair2 in dictionary)
			{
				foreach (HonamiStoryItemDataBase item4 in keyValuePair2.Value)
				{
					this.OccupySet.Add(item4);
				}
			}
			foreach (int key in list)
			{
				foreach (HonamiStoryItemDataBase item5 in dictionary[key])
				{
					this.OccupySet.Remove(item5);
				}
				this.RoleDataMap[key].GetMaxPower(allItem, this.OccupySet);
				foreach (HonamiStoryItemDataBase item6 in this.RoleDataMap[key].BestResult)
				{
					this.OccupySet.Add(item6);
				}
			}
		}
		foreach (KeyValuePair<int, HonamiStoryQuickRoleData> keyValuePair3 in this.RoleDataMap)
		{
			this.CurPowerLevel += keyValuePair3.Value.BestPower;
			this.CurRealPowerLevel += keyValuePair3.Value.RealBestPower;
		}
		int powerLevel = ModelBase<HonamiStoryModel>.Instance.GetPlayerData().PowerLevel;
		return this.CurPowerLevel > this.OldPowerLevel && this.CurPowerLevel > powerLevel;
	}

	// Token: 0x0600EA3D RID: 59965 RVA: 0x003F874C File Offset: 0x003F694C
	public int GetCurPowerLevel()
	{
		return this.CurPowerLevel;
	}

	// Token: 0x0600EA3E RID: 59966 RVA: 0x003F8754 File Offset: 0x003F6954
	public int GetRealPowerLevel()
	{
		return this.CurRealPowerLevel;
	}

	// Token: 0x0600EA3F RID: 59967 RVA: 0x003F875C File Offset: 0x003F695C
	public void ApplyQuickAll()
	{
		List<HonamiStoryRoleEquipData> roleEquipDataList = ModelBase<HonamiStoryModel>.Instance.GetPlayerBackpackData().GetRoleEquipDataList(true);
		bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		int num = flag ? 2 : 1;
		HashSet<HonamiStoryItemDataBase> hashSet = new HashSet<HonamiStoryItemDataBase>();
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in roleEquipDataList)
		{
			foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in honamiStoryRoleEquipData.GetSlotList())
			{
				HonamiStoryEquipItemData itemData = honamiStoryRoleEquipSlotData.GetItemData();
				if (itemData != null)
				{
					hashSet.Add(itemData);
				}
			}
		}
		List<HonamiStoryBagUpdateContext> list = new List<HonamiStoryBagUpdateContext>();
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = 4;
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext2 = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext2.BackPackConfigId = num;
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext3 = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext3.BackPackConfigId = 3;
		List<int> list2 = new List<int>();
		foreach (KeyValuePair<int, HonamiStoryQuickRoleData> keyValuePair in this.RoleDataMap)
		{
			List<int> collection = keyValuePair.Value.ApplyQuickEquip(hashSet, honamiStoryBagUpdateContext, honamiStoryBagUpdateContext2, honamiStoryBagUpdateContext3);
			list2.AddRange(collection);
		}
		list2.Sort((int a, int b) => a.CompareTo(b));
		HashSet<int> hashSet2 = new HashSet<int>();
		if (hashSet.Count > 0)
		{
			if (!flag && hashSet.Count > list2.Count)
			{
				Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.WHJ, "QuickAll Apply Error", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(num, false);
			foreach (HonamiStoryItemDataBase itemData2 in hashSet)
			{
				int num2 = -1;
				if (list2.Count > 0)
				{
					num2 = list2[0];
					list2.RemoveAt(0);
				}
				if (num2 != -1 && num2 < backPackData.GetCapacity())
				{
					HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(itemData2);
					honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
					HonamiStoryBagUpdateInfo honamiStoryItemAddInfo = HonamiStoryUtil.GetHonamiStoryItemAddInfo(itemData2, num2);
					honamiStoryBagUpdateContext2.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo);
					hashSet2.Add(num2);
				}
				else
				{
					IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindFirstAvailablePosition(backPackData.GetEmptyGridSet(), itemData2, backPackData.GetWidthCount(), hashSet2);
					if (honamiStoryAvailablePosInfo.Position == -1 || honamiStoryAvailablePosInfo.Position >= backPackData.GetCapacity())
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoSpaceForQuickAll", Array.Empty<object>());
						return;
					}
					HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo2 = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(itemData2);
					honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo2);
					HonamiStoryBagUpdateInfo honamiStoryItemAddInfo2 = HonamiStoryUtil.GetHonamiStoryItemAddInfo(itemData2, honamiStoryAvailablePosInfo.Position);
					honamiStoryBagUpdateContext2.HonamiStoryBagUpdateInfo.Add(honamiStoryItemAddInfo2);
					hashSet2.Add(honamiStoryAvailablePosInfo.Position);
				}
			}
		}
		if (honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Count > 0)
		{
			list.Add(honamiStoryBagUpdateContext);
		}
		if (honamiStoryBagUpdateContext2.HonamiStoryBagUpdateInfo.Count > 0)
		{
			list.Add(honamiStoryBagUpdateContext2);
		}
		if (honamiStoryBagUpdateContext3.HonamiStoryBagUpdateInfo.Count > 0)
		{
			list.Add(honamiStoryBagUpdateContext3);
		}
		if (list.Count > 0)
		{
			ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryBagOperateRequest(list).Forget<bool>();
		}
	}

	// Token: 0x0600EA40 RID: 59968 RVA: 0x003F8AEC File Offset: 0x003F6CEC
	private Dictionary<int, List<HonamiStoryItemDataBase>> GetAllItem(List<HonamiStoryRoleEquipData> roleDataList)
	{
		Dictionary<int, List<HonamiStoryItemDataBase>> dictionary = new Dictionary<int, List<HonamiStoryItemDataBase>>();
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in roleDataList)
		{
			foreach (HonamiStoryEquipItemData honamiStoryEquipItemData in honamiStoryRoleEquipData.GetPluginList())
			{
				if (honamiStoryEquipItemData != null)
				{
					int subType = honamiStoryEquipItemData.GetSubType();
					if (!dictionary.ContainsKey(subType))
					{
						dictionary[subType] = new List<HonamiStoryItemDataBase>();
					}
					dictionary[subType].Add(honamiStoryEquipItemData);
				}
			}
		}
		bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		int backpackId = flag ? 2 : 1;
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(backpackId, false);
		if (backPackData == null)
		{
			return dictionary;
		}
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in backPackData.GetItemDataList())
		{
			if (honamiStoryItemDataBase.GetItemType() == EHonamiStoryItemType.Plugin)
			{
				int subType2 = honamiStoryItemDataBase.GetSubType();
				if (!dictionary.ContainsKey(subType2))
				{
					dictionary[subType2] = new List<HonamiStoryItemDataBase>();
				}
				dictionary[subType2].Add(honamiStoryItemDataBase);
			}
		}
		if (flag)
		{
			foreach (HonamiStoryItemDataBase honamiStoryItemDataBase2 in ModelBase<HonamiStoryModel>.Instance.GetBackPackData(3, false).GetItemDataList())
			{
				if (honamiStoryItemDataBase2.GetItemType() == EHonamiStoryItemType.Plugin)
				{
					int subType3 = honamiStoryItemDataBase2.GetSubType();
					if (!dictionary.ContainsKey(subType3))
					{
						dictionary[subType3] = new List<HonamiStoryItemDataBase>();
					}
					dictionary[subType3].Add(honamiStoryItemDataBase2);
				}
			}
		}
		return dictionary;
	}

	// Token: 0x0600EA41 RID: 59969 RVA: 0x003F8CC4 File Offset: 0x003F6EC4
	public void SetDirty()
	{
		this.OccupySet.Clear();
		this.RoleDataMap.Clear();
		this.IsDirty = true;
	}

	// Token: 0x0600EA42 RID: 59970 RVA: 0x003F8CE3 File Offset: 0x003F6EE3
	public bool GetDirty()
	{
		return this.IsDirty;
	}

	// Token: 0x0600EA43 RID: 59971 RVA: 0x003F8CEC File Offset: 0x003F6EEC
	private List<HonamiStoryItemDataBase> GetRolePluginList(int roleId, Dictionary<int, List<HonamiStoryItemDataBase>> itemMap)
	{
		List<HonamiStoryItemDataBase> list = new List<HonamiStoryItemDataBase>();
		if (roleId <= 0)
		{
			return list;
		}
		Dictionary<int, ValueTuple<int, HonamiStoryItemDataBase>> dictionary = new Dictionary<int, ValueTuple<int, HonamiStoryItemDataBase>>();
		foreach (KeyValuePair<int, List<HonamiStoryItemDataBase>> keyValuePair in itemMap)
		{
			foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in keyValuePair.Value)
			{
				HonamiStoryEquipItemData honamiStoryEquipItemData = honamiStoryItemDataBase as HonamiStoryEquipItemData;
				if (HonamiStoryUtil.CheckRolePowerValid(roleId, honamiStoryEquipItemData.GetRoleId()))
				{
					int groupId = honamiStoryEquipItemData.GetGroupId();
					int num = honamiStoryEquipItemData.GetBaseEnhance() + honamiStoryEquipItemData.GetRoleEnhance();
					if (dictionary.ContainsKey(groupId))
					{
						int item = dictionary[groupId].Item1;
						if (num > item)
						{
							dictionary[groupId] = new ValueTuple<int, HonamiStoryItemDataBase>(num, honamiStoryItemDataBase);
						}
					}
					else
					{
						dictionary[groupId] = new ValueTuple<int, HonamiStoryItemDataBase>(num, honamiStoryItemDataBase);
					}
				}
			}
		}
		foreach (KeyValuePair<int, ValueTuple<int, HonamiStoryItemDataBase>> keyValuePair2 in dictionary)
		{
			list.Add(keyValuePair2.Value.Item2);
		}
		return list;
	}

	// Token: 0x040070EB RID: 28907
	public int CurPowerLevel;

	// Token: 0x040070EC RID: 28908
	public int CurRealPowerLevel;

	// Token: 0x040070ED RID: 28909
	private int OldPowerLevel;

	// Token: 0x040070EE RID: 28910
	protected bool IsDirty = true;

	// Token: 0x040070EF RID: 28911
	private readonly HashSet<HonamiStoryItemDataBase> OccupySet = new HashSet<HonamiStoryItemDataBase>();

	// Token: 0x040070F0 RID: 28912
	private readonly Dictionary<int, HonamiStoryQuickRoleData> RoleDataMap = new Dictionary<int, HonamiStoryQuickRoleData>();

	// Token: 0x040070F1 RID: 28913
	private readonly HonamiSortOrderListClass SortOrderClass = new HonamiSortOrderListClass();
}
