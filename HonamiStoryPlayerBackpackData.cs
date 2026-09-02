using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.HonamiStory.Data;

// Token: 0x02001ED9 RID: 7897
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryPlayerBackpackData
{
	// Token: 0x0600E9E7 RID: 59879 RVA: 0x003F6684 File Offset: 0x003F4884
	public void Init(HonamiStoryPlayerBagInfo bagInfo)
	{
		if (bagInfo.EquipRack == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "Proto_EquipRack is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.Config = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBackPack(bagInfo.EquipRack.BagConfigId);
		this.InitRoleEquipDataList();
		this.RefreshEquipInfo(bagInfo.HonamiStoryRackInfos.ToList<HonamiStoryRackInfo>());
		this.RefreshGridItemInfo(bagInfo.EquipRack.HonamiStoryBagItemInfos.ToList<HonamiStoryBagItemInfo>());
	}

	// Token: 0x0600E9E8 RID: 59880 RVA: 0x003F6704 File Offset: 0x003F4904
	private void InitRoleEquipDataList()
	{
		this.RoleEquipDataList.Clear();
		for (int i = 0; i < 3; i++)
		{
			this.RoleEquipDataList.Add(new HonamiStoryRoleEquipData(i));
		}
	}

	// Token: 0x0600E9E9 RID: 59881 RVA: 0x003F673C File Offset: 0x003F493C
	public void RefreshEquipInfo(List<HonamiStoryRackInfo> roleInfo)
	{
		for (int i = 0; i < roleInfo.Count; i++)
		{
			this.RoleEquipDataList[i].SetEquipData(roleInfo[i]);
		}
		if (roleInfo.Count < this.RoleEquipDataList.Count)
		{
			for (int j = roleInfo.Count; j < this.RoleEquipDataList.Count; j++)
			{
				this.RoleEquipDataList[j].SetEquipData(null);
			}
		}
		this.UpdateAllRoleSlots();
	}

	// Token: 0x0600E9EA RID: 59882 RVA: 0x003F67B8 File Offset: 0x003F49B8
	public void RefreshRoleInfo(List<int> roleInfo)
	{
		for (int i = 0; i < roleInfo.Count; i++)
		{
			this.RefreshRoleInfoByPosition(roleInfo[i], i);
		}
		if (roleInfo.Count < this.RoleEquipDataList.Count)
		{
			for (int j = roleInfo.Count; j < this.RoleEquipDataList.Count; j++)
			{
				this.RefreshRoleInfoByPosition(0, j);
			}
		}
		this.UpdateAllRoleSlots();
	}

	// Token: 0x0600E9EB RID: 59883 RVA: 0x003F6820 File Offset: 0x003F4A20
	public void RefreshRoleInfoByPosition(int roleId, int position)
	{
		if (position < 0 || position >= this.RoleEquipDataList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "RefreshRoleInfoByPosition 无效position";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("position", position);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.RoleEquipDataList[position].SetRoleInfo(roleId);
		this.UpdateAllRoleSlots();
	}

	// Token: 0x0600E9EC RID: 59884 RVA: 0x003F6888 File Offset: 0x003F4A88
	public void RefreshWeaponInfoByPosition(int weaponId, int position)
	{
		HonamiStoryRoleEquipData roleEquipDataByPosition = this.GetRoleEquipDataByPosition(position);
		if (roleEquipDataByPosition == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "RefreshWeaponInfoByPosition 无效position";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("position", position);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		roleEquipDataByPosition.SetWeaponInfo(weaponId);
		this.UpdateAllRoleSlots();
	}

	// Token: 0x0600E9ED RID: 59885 RVA: 0x003F68E0 File Offset: 0x003F4AE0
	public unsafe void RefreshGridItemInfo(List<HonamiStoryBagItemInfo> itemInfoList)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (HonamiStoryBagItemInfo honamiStoryBagItemInfo in itemInfoList)
		{
			HonamiStoryEquipItemData honamiStoryEquipItemData = ModelBase<HonamiStoryModel>.Instance.CreateHonamiStoryItemData(honamiStoryBagItemInfo.HonamiStoryItemInfo, honamiStoryBagItemInfo.HonamiStoryPosInfo) as HonamiStoryEquipItemData;
			if (honamiStoryEquipItemData == null || honamiStoryEquipItemData.GetItemType() == EHonamiStoryItemType.Normal)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.HonamiStory;
				ELogAuthor author = ELogAuthor.BB;
				string message = "Invalid EquipItemType";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("itemId", (honamiStoryEquipItemData != null) ? honamiStoryEquipItemData.GetItemId() : 0);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("itemType", (honamiStoryEquipItemData != null) ? honamiStoryEquipItemData.GetItemType() : EHonamiStoryItemType.Normal);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				hashSet.Add(honamiStoryEquipItemData.GetPosition());
				HonamiStoryEquipItemData honamiStoryEquipItemData2;
				if (!this.GridItemMap.TryGetValue(honamiStoryEquipItemData.GetPosition(), out honamiStoryEquipItemData2) || honamiStoryEquipItemData2 == null || honamiStoryEquipItemData2.GetIncId() != honamiStoryEquipItemData.GetIncId())
				{
					this.SetRoleItemData(honamiStoryEquipItemData);
					this.GridItemMap[honamiStoryEquipItemData.GetPosition()] = honamiStoryEquipItemData;
				}
			}
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, HonamiStoryEquipItemData> keyValuePair in this.GridItemMap)
		{
			if (!hashSet.Contains(keyValuePair.Key))
			{
				list.Add(keyValuePair.Key);
			}
		}
		foreach (int num in list)
		{
			this.GridItemMap.Remove(num);
			this.RemoveRoleItemData(num);
		}
		this.UpdateAllRoleSlots();
	}

	// Token: 0x0600E9EE RID: 59886 RVA: 0x003F6B08 File Offset: 0x003F4D08
	public void UpdateByContext(List<HonamiStoryBagUpdateInfo> updateInfoList)
	{
		foreach (HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo in updateInfoList)
		{
			if (honamiStoryBagUpdateInfo.Type != 0)
			{
				this.RemoveItemData(honamiStoryBagUpdateInfo);
			}
		}
		foreach (HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo2 in updateInfoList)
		{
			if (honamiStoryBagUpdateInfo2.Type != 2)
			{
				this.AddItemData(honamiStoryBagUpdateInfo2);
			}
		}
		this.UpdateAllRoleSlots();
	}

	// Token: 0x0600E9EF RID: 59887 RVA: 0x003F6BAC File Offset: 0x003F4DAC
	private void AddItemData(HonamiStoryBagUpdateInfo updateInfo)
	{
		HonamiStoryEquipItemData honamiStoryEquipItemData = ModelBase<HonamiStoryModel>.Instance.GetItemData(updateInfo.ItemIncrId) as HonamiStoryEquipItemData;
		honamiStoryEquipItemData.UpdatePositionInfo(updateInfo.HonamiStoryPosInfo);
		this.GridItemMap[honamiStoryEquipItemData.GetPosition()] = honamiStoryEquipItemData;
		this.SetRoleItemData(honamiStoryEquipItemData);
	}

	// Token: 0x0600E9F0 RID: 59888 RVA: 0x003F6BF4 File Offset: 0x003F4DF4
	private void RemoveItemData(HonamiStoryBagUpdateInfo updateInfo)
	{
		int position = updateInfo.OriHonamiStoryPosInfo.Position;
		this.GridItemMap.Remove(position);
		this.RemoveRoleItemData(position);
	}

	// Token: 0x0600E9F1 RID: 59889 RVA: 0x003F6C24 File Offset: 0x003F4E24
	public void SetRoleItemData(HonamiStoryEquipItemData itemData)
	{
		int position = itemData.GetPosition();
		this.GetRoleItemDataByPosition(position).SetItemData(position, itemData);
	}

	// Token: 0x0600E9F2 RID: 59890 RVA: 0x003F6C46 File Offset: 0x003F4E46
	public void RemoveRoleItemData(int position)
	{
		this.GetRoleItemDataByPosition(position).RemoveItemData(position);
	}

	// Token: 0x17001207 RID: 4615
	// (get) Token: 0x0600E9F3 RID: 59891 RVA: 0x003F6C58 File Offset: 0x003F4E58
	public int BackpackId
	{
		get
		{
			return this.Config.Value.Id;
		}
	}

	// Token: 0x0600E9F4 RID: 59892 RVA: 0x003F6C78 File Offset: 0x003F4E78
	public EHonamiStoryBackpackType GetBackpackType()
	{
		return (EHonamiStoryBackpackType)this.Config.Value.Type;
	}

	// Token: 0x0600E9F5 RID: 59893 RVA: 0x003F6C98 File Offset: 0x003F4E98
	public List<HonamiStoryRoleEquipData> GetRoleEquipDataList(bool needUnlock = true)
	{
		List<HonamiStoryRoleEquipData> list = new List<HonamiStoryRoleEquipData>();
		int activityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
		HonamiStoryActivity? honamiStoryActivityConfig = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryActivityConfig(activityId);
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(honamiStoryActivityConfig.Value.EquipRoleFuncId);
		if (!needUnlock || flag)
		{
			return this.RoleEquipDataList;
		}
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.RoleEquipDataList)
		{
			if (honamiStoryRoleEquipData.GetRoleId() != 0)
			{
				list.Add(honamiStoryRoleEquipData);
			}
		}
		return list;
	}

	// Token: 0x0600E9F6 RID: 59894 RVA: 0x003F6D40 File Offset: 0x003F4F40
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetRoleItemDataByPosition(int position)
	{
		int num = (int)Math.Floor((double)position / 100.0) - 1;
		if (num < 0 || num >= this.RoleEquipDataList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HonamiStoryPlayerBackpackData Invalid position";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("position", position);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return this.RoleEquipDataList[num];
	}

	// Token: 0x0600E9F7 RID: 59895 RVA: 0x003F6DB4 File Offset: 0x003F4FB4
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetRoleEquipDataByPosition(int position)
	{
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.RoleEquipDataList)
		{
			if (honamiStoryRoleEquipData.GetPosition() == position)
			{
				return honamiStoryRoleEquipData;
			}
		}
		return null;
	}

	// Token: 0x0600E9F8 RID: 59896 RVA: 0x003F6E10 File Offset: 0x003F5010
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetRoleEquipDataByRoleId(int roleId)
	{
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.RoleEquipDataList)
		{
			if (honamiStoryRoleEquipData.GetRoleId() == roleId)
			{
				return honamiStoryRoleEquipData;
			}
		}
		return null;
	}

	// Token: 0x0600E9F9 RID: 59897 RVA: 0x003F6E6C File Offset: 0x003F506C
	public int GetPowerLevel(bool isForShow)
	{
		int num = 0;
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.RoleEquipDataList)
		{
			num += honamiStoryRoleEquipData.GetCurPowerLevel(isForShow);
		}
		return num;
	}

	// Token: 0x0600E9FA RID: 59898 RVA: 0x003F6EC8 File Offset: 0x003F50C8
	public void UpdateAllRoleSlots()
	{
		HonamiStoryPlayerData playerData = ModelBase<HonamiStoryModel>.Instance.GetPlayerData();
		int powerLevel = playerData.PowerLevel;
		playerData.UpdatePowerLevel();
		if (powerLevel != playerData.PowerLevel)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnHonamiStoryPowerLevelUpdate, powerLevel, playerData.PowerLevel);
		}
	}

	// Token: 0x0600E9FB RID: 59899 RVA: 0x003F6F0D File Offset: 0x003F510D
	public int GetCellWidth()
	{
		if (HonamiStoryUtil.IsMobileView())
		{
			return 134;
		}
		return 86;
	}

	// Token: 0x0600E9FC RID: 59900 RVA: 0x003F6F1E File Offset: 0x003F511E
	public int GetCellHeight()
	{
		if (HonamiStoryUtil.IsMobileView())
		{
			return 134;
		}
		return 86;
	}

	// Token: 0x0600E9FD RID: 59901 RVA: 0x003F6F2F File Offset: 0x003F512F
	public int GetCellHorizontalInterval()
	{
		return 2;
	}

	// Token: 0x0600E9FE RID: 59902 RVA: 0x003F6F32 File Offset: 0x003F5132
	public int GetCellVerticalInterval()
	{
		return 2;
	}

	// Token: 0x0600E9FF RID: 59903 RVA: 0x003F6F38 File Offset: 0x003F5138
	public bool CheckItemByIncId(int incId)
	{
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.RoleEquipDataList)
		{
			foreach (HonamiStoryEquipItemData honamiStoryEquipItemData in honamiStoryRoleEquipData.GetEquipItemDataList())
			{
				if (incId == honamiStoryEquipItemData.GetIncId())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x040070CE RID: 28878
	private readonly List<HonamiStoryRoleEquipData> RoleEquipDataList = new List<HonamiStoryRoleEquipData>();

	// Token: 0x040070CF RID: 28879
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<int, HonamiStoryEquipItemData> GridItemMap = new Dictionary<int, HonamiStoryEquipItemData>();

	// Token: 0x040070D0 RID: 28880
	protected HonamiStoryBackPack? Config;
}
