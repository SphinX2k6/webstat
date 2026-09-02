using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.HonamiStory.Data;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02001EF0 RID: 7920
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class HonamiStoryModel : ModelBase<HonamiStoryModel>
{
	// Token: 0x0600EAE9 RID: 60137 RVA: 0x003FB877 File Offset: 0x003F9A77
	protected override bool OnInit()
	{
		this.ActivityData = null;
		this.ItemDataMap.Clear();
		this.AddOpenViewCheck();
		return true;
	}

	// Token: 0x0600EAEA RID: 60138 RVA: 0x003FB892 File Offset: 0x003F9A92
	protected override bool OnClear()
	{
		this.RemoveOpenViewCheck();
		return true;
	}

	// Token: 0x0600EAEB RID: 60139 RVA: 0x003FB89C File Offset: 0x003F9A9C
	private void AddOpenViewCheck()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.HonamiStoryBackpackView, new Func<EUiViewName, object, bool>(ControllerBase<HonamiStoryController>.Instance.CanOpenBackpack), "HonamiStoryController.CanOpenView");
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.HonamiStoryPickUpBackpackView, new Func<EUiViewName, object, bool>(ControllerBase<HonamiStoryController>.Instance.CanOpenBackpack), "HonamiStoryController.CanOpenView");
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.HonamiStoryPickUpMobileView, new Func<EUiViewName, object, bool>(ControllerBase<HonamiStoryController>.Instance.CanOpenBackpack), "HonamiStoryController.CanOpenView");
	}

	// Token: 0x0600EAEC RID: 60140 RVA: 0x003FB918 File Offset: 0x003F9B18
	private void RemoveOpenViewCheck()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.HonamiStoryBackpackView, new Func<EUiViewName, object, bool>(ControllerBase<HonamiStoryController>.Instance.CanOpenBackpack));
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.HonamiStoryPickUpBackpackView, new Func<EUiViewName, object, bool>(ControllerBase<HonamiStoryController>.Instance.CanOpenBackpack));
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.HonamiStoryPickUpMobileView, new Func<EUiViewName, object, bool>(ControllerBase<HonamiStoryController>.Instance.CanOpenBackpack));
	}

	// Token: 0x0600EAED RID: 60141 RVA: 0x003FB984 File Offset: 0x003F9B84
	protected override bool OnLeaveLevel()
	{
		this.CurTrackTaskData = null;
		this.CanSafeLeave = false;
		this.CacheShowSafeLeaveUpdate = false;
		this.PollutionLevel = 0;
		this.PollutionMaxLevel = 0;
		this.PollutionStarTime = 0f;
		Dictionary<int, IHonamiStoryPollution> pollutionLevelMap = this.PollutionLevelMap;
		if (pollutionLevelMap != null)
		{
			pollutionLevelMap.Clear();
		}
		this.PollutionWarningLevel = 0;
		this.PollutionDangerLevel = 0;
		this.PollutionLevelMap = null;
		this.MonsterBaseEnhanceLevel = 0;
		this.DangerLevel = 0;
		ModelBase<MapModel>.Instance.ClearHonamiScanMarkInfo();
		return true;
	}

	// Token: 0x0600EAEE RID: 60142 RVA: 0x003FB9FE File Offset: 0x003F9BFE
	public void SetActivityData(HonamiStoryActivityData activityData)
	{
		this.ActivityData = activityData;
	}

	// Token: 0x0600EAEF RID: 60143 RVA: 0x003FBA08 File Offset: 0x003F9C08
	[NullableContext(2)]
	public HonamiStoryActivityData GetActivityData(bool needErrorLog = true)
	{
		if (this.ActivityData == null)
		{
			if (needErrorLog)
			{
				Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "HonamiStoryActivityData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return null;
		}
		return this.ActivityData;
	}

	// Token: 0x0600EAF0 RID: 60144 RVA: 0x003FBA47 File Offset: 0x003F9C47
	public HonamiStoryPlayerData GetPlayerData()
	{
		return this.PlayerData;
	}

	// Token: 0x0600EAF1 RID: 60145 RVA: 0x003FBA50 File Offset: 0x003F9C50
	public void InitActivityInfo(int activityId, HonamiStoryActivityInfo activityInfo)
	{
		this.ActivityId = activityId;
		this.InitPlayerInfo(activityId, activityInfo.HonamiStoryPlayerBagInfo);
		this.InitBackPackInfo(activityInfo.HonamiStoryPlayerBagInfo.Warehouse);
		this.InitTechNodeData();
		this.RefreshTalentInfos(activityInfo.HonamiStoryTalentInfos);
		this.UpdateLiefSupport(activityInfo.LifeSupportLevel);
	}

	// Token: 0x0600EAF2 RID: 60146 RVA: 0x003FBAA0 File Offset: 0x003F9CA0
	public void UpdateActivityInfo(int activityId, HonamiStoryActivityInfo activityInfo)
	{
		this.UpdatePlayerInfo(activityId, activityInfo.HonamiStoryPlayerBagInfo);
		this.UpdateBackPackInfo(activityInfo.HonamiStoryPlayerBagInfo.Warehouse);
		this.RefreshTalentInfos(activityInfo.HonamiStoryTalentInfos);
		this.UpdateLiefSupport(activityInfo.LifeSupportLevel);
	}

	// Token: 0x0600EAF3 RID: 60147 RVA: 0x003FBAD8 File Offset: 0x003F9CD8
	private void UpdateLiefSupport(int curLevel)
	{
		this.PlayerData.SetLifeSupportLevel(curLevel);
	}

	// Token: 0x0600EAF4 RID: 60148 RVA: 0x003FBAE8 File Offset: 0x003F9CE8
	[NullableContext(2)]
	private void InitPlayerInfo(int activityId, HonamiStoryPlayerBagInfo playerInfo)
	{
		if (playerInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "InitPlayerBagInfo 无效playerInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PlayerBackpackData = new HonamiStoryPlayerBackpackData();
		this.PlayerBackpackData.Init(playerInfo);
		foreach (HonamiStoryWeapon honamiStoryWeapon in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryWeaponConfigList(activityId))
		{
			HonamiStoryWeaponData value = new HonamiStoryWeaponData(honamiStoryWeapon.Id);
			this.WeaponDataMap[honamiStoryWeapon.Id] = value;
		}
		this.UpdateWeaponDataList(playerInfo.UnlockWeapon.ToList<int>());
	}

	// Token: 0x0600EAF5 RID: 60149 RVA: 0x003FBBA0 File Offset: 0x003F9DA0
	[NullableContext(2)]
	private void UpdatePlayerInfo(int activityId, HonamiStoryPlayerBagInfo playerInfo)
	{
		if (playerInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "InitPlayerBagInfo 无效playerInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.PlayerBackpackData.RefreshEquipInfo(playerInfo.HonamiStoryRackInfos.ToList<HonamiStoryRackInfo>());
		if (playerInfo.EquipRack != null)
		{
			this.PlayerBackpackData.RefreshGridItemInfo(playerInfo.EquipRack.HonamiStoryBagItemInfos.ToList<HonamiStoryBagItemInfo>());
		}
		foreach (HonamiStoryWeapon honamiStoryWeapon in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryWeaponConfigList(activityId))
		{
			HonamiStoryWeaponData value = new HonamiStoryWeaponData(honamiStoryWeapon.Id);
			this.WeaponDataMap[honamiStoryWeapon.Id] = value;
		}
		this.UpdateWeaponDataList(playerInfo.UnlockWeapon.ToList<int>());
	}

	// Token: 0x0600EAF6 RID: 60150 RVA: 0x003FBC78 File Offset: 0x003F9E78
	public void UpdateRoleList(List<int> roleList)
	{
		this.PlayerBackpackData.RefreshRoleInfo(roleList);
	}

	// Token: 0x0600EAF7 RID: 60151 RVA: 0x003FBC86 File Offset: 0x003F9E86
	public void UpdateRoleByPosition(int roleId, int position)
	{
		this.PlayerBackpackData.RefreshRoleInfoByPosition(roleId, position);
	}

	// Token: 0x0600EAF8 RID: 60152 RVA: 0x003FBC95 File Offset: 0x003F9E95
	public void UpdateWeaponByPosition(int weaponId, int position)
	{
		this.PlayerBackpackData.RefreshWeaponInfoByPosition(weaponId, position);
	}

	// Token: 0x0600EAF9 RID: 60153 RVA: 0x003FBCA4 File Offset: 0x003F9EA4
	public void UpdatePlayerBackPack(HonamiStoryBagUpdateContext updateContext)
	{
		this.PlayerBackpackData.UpdateByContext(updateContext.HonamiStoryBagUpdateInfo.ToList<HonamiStoryBagUpdateInfo>());
	}

	// Token: 0x0600EAFA RID: 60154 RVA: 0x003FBCBC File Offset: 0x003F9EBC
	public HonamiStoryPlayerBackpackData GetPlayerBackpackData()
	{
		return this.PlayerBackpackData;
	}

	// Token: 0x0600EAFB RID: 60155 RVA: 0x003FBCC4 File Offset: 0x003F9EC4
	public int[] GetAllRoleIdList()
	{
		List<int> list = new List<int>();
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.PlayerBackpackData.GetRoleEquipDataList(true))
		{
			list.Add(honamiStoryRoleEquipData.GetRoleId());
		}
		return list.ToArray();
	}

	// Token: 0x0600EAFC RID: 60156 RVA: 0x003FBD30 File Offset: 0x003F9F30
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetRoleItemDataByPosition(int position)
	{
		return this.PlayerBackpackData.GetRoleItemDataByPosition(position);
	}

	// Token: 0x0600EAFD RID: 60157 RVA: 0x003FBD3E File Offset: 0x003F9F3E
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetRoleEquipDataByPosition(int position)
	{
		return this.PlayerBackpackData.GetRoleEquipDataByPosition(position);
	}

	// Token: 0x0600EAFE RID: 60158 RVA: 0x003FBD4C File Offset: 0x003F9F4C
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetRoleEquipDataByRoleId(int roleId)
	{
		return this.PlayerBackpackData.GetRoleEquipDataByRoleId(roleId);
	}

	// Token: 0x0600EAFF RID: 60159 RVA: 0x003FBD5C File Offset: 0x003F9F5C
	[NullableContext(2)]
	public HonamiStoryItemDataBase GetEquipItemDataByIncId(int incId)
	{
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.PlayerBackpackData.GetRoleEquipDataList(true))
		{
			foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in honamiStoryRoleEquipData.GetSlotList())
			{
				HonamiStoryEquipItemData itemData = honamiStoryRoleEquipSlotData.GetItemData();
				if (itemData != null && itemData.GetIncId() == incId)
				{
					return itemData;
				}
			}
		}
		return null;
	}

	// Token: 0x0600EB00 RID: 60160 RVA: 0x003FBE00 File Offset: 0x003FA000
	public EHonamiStoryWeaponType[] GetWeaponTypeList()
	{
		HashSet<EHonamiStoryWeaponType> hashSet = new HashSet<EHonamiStoryWeaponType>();
		bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		foreach (HonamiStoryWeaponData honamiStoryWeaponData in this.WeaponDataMap.Values)
		{
			if (flag)
			{
				if (this.GetWeaponEquipState(honamiStoryWeaponData.WeaponId) != null)
				{
					hashSet.Add(honamiStoryWeaponData.WeaponType);
				}
			}
			else
			{
				hashSet.Add(honamiStoryWeaponData.WeaponType);
			}
		}
		List<EHonamiStoryWeaponType> list = new List<EHonamiStoryWeaponType>();
		foreach (EHonamiStoryWeaponType item in hashSet)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600EB01 RID: 60161 RVA: 0x003FBEDC File Offset: 0x003FA0DC
	public List<HonamiStoryWeaponData> GetWeaponDataListByType(EHonamiStoryWeaponType type)
	{
		List<HonamiStoryWeaponData> list = new List<HonamiStoryWeaponData>();
		foreach (HonamiStoryWeaponData honamiStoryWeaponData in this.WeaponDataMap.Values)
		{
			if (honamiStoryWeaponData.WeaponType == type)
			{
				list.Add(honamiStoryWeaponData);
			}
		}
		return list;
	}

	// Token: 0x0600EB02 RID: 60162 RVA: 0x003FBF44 File Offset: 0x003FA144
	public void UpdateWeaponDataList(List<int> weaponIdList)
	{
		foreach (int weaponId in weaponIdList)
		{
			HonamiStoryWeaponData weaponData = this.GetWeaponData(weaponId);
			if (weaponData != null)
			{
				weaponData.SetUnlock(true);
			}
		}
	}

	// Token: 0x0600EB03 RID: 60163 RVA: 0x003FBFA0 File Offset: 0x003FA1A0
	[NullableContext(2)]
	public HonamiStoryWeaponData GetWeaponData(int weaponId)
	{
		HonamiStoryWeaponData result;
		if (this.WeaponDataMap.TryGetValue(weaponId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600EB04 RID: 60164 RVA: 0x003FBFC0 File Offset: 0x003FA1C0
	public EHonamiStoryWeaponState CheckSelectWeaponState(int weaponId, HonamiStoryRoleEquipData equipData)
	{
		int weaponId2 = equipData.GetWeaponId();
		if (weaponId2 == 0)
		{
			return EHonamiStoryWeaponState.Equip;
		}
		if (weaponId == weaponId2)
		{
			return EHonamiStoryWeaponState.Remove;
		}
		return EHonamiStoryWeaponState.Change;
	}

	// Token: 0x0600EB05 RID: 60165 RVA: 0x003FBFE0 File Offset: 0x003FA1E0
	[NullableContext(2)]
	public HonamiStoryRoleEquipData GetWeaponEquipState(int weaponId)
	{
		if (weaponId == 0)
		{
			return null;
		}
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in this.PlayerBackpackData.GetRoleEquipDataList(true))
		{
			if (honamiStoryRoleEquipData.GetWeaponId() == weaponId)
			{
				return honamiStoryRoleEquipData;
			}
		}
		return null;
	}

	// Token: 0x0600EB06 RID: 60166 RVA: 0x003FC048 File Offset: 0x003FA248
	public void SetTotalRevenueInternal(int value)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "SetTotalRevenueInternal";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.TotalRevenueInternal = value;
	}

	// Token: 0x1700121C RID: 4636
	// (get) Token: 0x0600EB07 RID: 60167 RVA: 0x003FC08B File Offset: 0x003FA28B
	public int TotalRevenue
	{
		get
		{
			if (this.TotalRevenueInternal >= 99999999)
			{
				return 99999999;
			}
			return this.TotalRevenueInternal;
		}
	}

	// Token: 0x0600EB08 RID: 60168 RVA: 0x003FC0A6 File Offset: 0x003FA2A6
	[NullableContext(2)]
	public HonamiStoryBackpackData GetInventory()
	{
		return this.WareHouseBackpackData;
	}

	// Token: 0x0600EB09 RID: 60169 RVA: 0x003FC0AE File Offset: 0x003FA2AE
	public void SetInventory(HonamiStoryBackpackData newData)
	{
		this.WareHouseBackpackData = newData;
	}

	// Token: 0x0600EB0A RID: 60170 RVA: 0x003FC0B7 File Offset: 0x003FA2B7
	public bool CheckIsNewInInventory()
	{
		return this.WareHouseBackpackData != null && (this.WareHouseBackpackData.CheckIsNewInBackpack() || (LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, null) ?? new HashSet<int>()).Count > 0);
	}

	// Token: 0x0600EB0B RID: 60171 RVA: 0x003FC0F0 File Offset: 0x003FA2F0
	private void InitTechNodeData()
	{
		this.TechNodeDataMap.Clear();
		this.TechAreaDataMap.Clear();
		foreach (HonamiStoryTalent config in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryTalentConfigList(this.ActivityId))
		{
			HonamiStoryTechNodeData value = new HonamiStoryTechNodeData(config);
			this.TechNodeDataMap[config.Id] = value;
			HonamiStoryTechAreaData honamiStoryTechAreaData;
			if (!this.TechAreaDataMap.TryGetValue(config.Area, out honamiStoryTechAreaData))
			{
				honamiStoryTechAreaData = new HonamiStoryTechAreaData();
				honamiStoryTechAreaData.AreaId = config.Area;
				honamiStoryTechAreaData.NodeIds = new List<int>();
			}
			honamiStoryTechAreaData.NodeIds.Add(config.Id);
			this.TechAreaDataMap[honamiStoryTechAreaData.AreaId] = honamiStoryTechAreaData;
		}
	}

	// Token: 0x0600EB0C RID: 60172 RVA: 0x003FC1CC File Offset: 0x003FA3CC
	public bool CheckNodeCanActiveAndIsEnough(HonamiStoryTechNodeData data)
	{
		if (data == null)
		{
			return false;
		}
		if (data.GetNodeStatus != ENodeStatus.CanActive)
		{
			return false;
		}
		Dictionary<int, int> dictionary = data.GetConfig.ConsumeItems();
		if (dictionary == null)
		{
			return true;
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0) < keyValuePair.Value)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600EB0D RID: 60173 RVA: 0x003FC25C File Offset: 0x003FA45C
	public void RefreshTalentInfos(IReadOnlyList<HonamiStoryTalentInfo> techNodeList)
	{
		if (techNodeList == null)
		{
			return;
		}
		foreach (HonamiStoryTalentInfo honamiStoryTalentInfo in techNodeList)
		{
			int talentId = honamiStoryTalentInfo.TalentId;
			int status = honamiStoryTalentInfo.Status;
			HonamiStoryTechNodeData honamiStoryTechNodeData;
			if (this.TechNodeDataMap.TryGetValue(talentId, out honamiStoryTechNodeData))
			{
				honamiStoryTechNodeData.SetNodeStatus(status);
			}
		}
	}

	// Token: 0x0600EB0E RID: 60174 RVA: 0x003FC2C4 File Offset: 0x003FA4C4
	[NullableContext(2)]
	public HonamiStoryTechNodeData GetTechNodeData(int id)
	{
		HonamiStoryTechNodeData result;
		if (!this.TechNodeDataMap.TryGetValue(id, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryTechNodeData 无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x0600EB0F RID: 60175 RVA: 0x003FC314 File Offset: 0x003FA514
	[NullableContext(2)]
	public HonamiStoryTechAreaData GetTechAreaData(int id)
	{
		HonamiStoryTechAreaData result;
		if (!this.TechAreaDataMap.TryGetValue(id, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "HonamiStoryTechAreaData 无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x1700121D RID: 4637
	// (get) Token: 0x0600EB10 RID: 60176 RVA: 0x003FC364 File Offset: 0x003FA564
	public HonamiStoryTechAreaData[] GetTechAreaDataList
	{
		get
		{
			List<HonamiStoryTechAreaData> list = new List<HonamiStoryTechAreaData>();
			foreach (KeyValuePair<int, HonamiStoryTechAreaData> keyValuePair in this.TechAreaDataMap)
			{
				if (keyValuePair.Key != 0)
				{
					list.Add(keyValuePair.Value);
				}
			}
			return list.ToArray();
		}
	}

	// Token: 0x0600EB11 RID: 60177 RVA: 0x003FC3D4 File Offset: 0x003FA5D4
	public void CheckCurrentTalentTreeNode()
	{
		HonamiStoryTechNodeData honamiStoryTechNodeData = null;
		HonamiStoryTechNodeData honamiStoryTechNodeData2 = null;
		List<HonamiStoryTechNodeData> list = new List<HonamiStoryTechNodeData>();
		foreach (HonamiStoryTechNodeData item in this.TechNodeDataMap.Values)
		{
			list.Add(item);
		}
		list.Sort((HonamiStoryTechNodeData a, HonamiStoryTechNodeData b) => a.GetConfig.IndexSortId - b.GetConfig.IndexSortId);
		foreach (HonamiStoryTechNodeData honamiStoryTechNodeData3 in list)
		{
			if (honamiStoryTechNodeData3.GetNodeStatus != ENodeStatus.IsActive)
			{
				if (honamiStoryTechNodeData3.GetNodeStatus == ENodeStatus.CanActive)
				{
					if (this.CheckNodeCanActiveAndIsEnough(honamiStoryTechNodeData3))
					{
						this.CurrentSelectNode = honamiStoryTechNodeData3;
						return;
					}
					if (honamiStoryTechNodeData == null)
					{
						honamiStoryTechNodeData = honamiStoryTechNodeData3;
					}
				}
				else if (honamiStoryTechNodeData2 == null)
				{
					honamiStoryTechNodeData2 = honamiStoryTechNodeData3;
				}
			}
		}
		this.CurrentSelectNode = (honamiStoryTechNodeData ?? honamiStoryTechNodeData2);
		if (this.CurrentSelectNode == null)
		{
			this.CurrentSelectNode = ((list.Count > 0) ? list[0] : null);
		}
	}

	// Token: 0x0600EB12 RID: 60178 RVA: 0x003FC4F8 File Offset: 0x003FA6F8
	[NullableContext(2)]
	public HonamiStoryTechNodeData GetFirstTechnologyNode()
	{
		HonamiStoryTechNodeData result = null;
		foreach (KeyValuePair<int, HonamiStoryTechNodeData> keyValuePair in this.TechNodeDataMap)
		{
			if (keyValuePair.Value.GetConfig.Area == 0)
			{
				result = keyValuePair.Value;
			}
		}
		return result;
	}

	// Token: 0x0600EB13 RID: 60179 RVA: 0x003FC568 File Offset: 0x003FA768
	public bool IsTechHasRedDot()
	{
		foreach (HonamiStoryTechNodeData data in this.TechNodeDataMap.Values)
		{
			if (this.CheckNodeCanActiveAndIsEnough(data))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600EB14 RID: 60180 RVA: 0x003FC5CC File Offset: 0x003FA7CC
	public HonamiStoryTechNodeData[] GetAllTechNodeDataList()
	{
		List<HonamiStoryTechNodeData> list = new List<HonamiStoryTechNodeData>();
		foreach (HonamiStoryTechNodeData item in this.TechNodeDataMap.Values)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600EB15 RID: 60181 RVA: 0x003FC630 File Offset: 0x003FA830
	public HonamiStoryTechAreaData[] GetAllTechAreaDataList()
	{
		List<HonamiStoryTechAreaData> list = new List<HonamiStoryTechAreaData>();
		foreach (HonamiStoryTechAreaData item in this.TechAreaDataMap.Values)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600EB16 RID: 60182 RVA: 0x003FC694 File Offset: 0x003FA894
	public HonamiStoryTechNodeData[] GetAllActiveTechNodeDataList()
	{
		List<HonamiStoryTechNodeData> list = new List<HonamiStoryTechNodeData>();
		foreach (HonamiStoryTechNodeData honamiStoryTechNodeData in this.TechNodeDataMap.Values)
		{
			if (honamiStoryTechNodeData.GetNodeStatus == ENodeStatus.IsActive)
			{
				list.Add(honamiStoryTechNodeData);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600EB17 RID: 60183 RVA: 0x003FC704 File Offset: 0x003FA904
	public int GetSubTaskBonusDataList()
	{
		HonamiStoryTechNodeData[] allActiveTechNodeDataList = this.GetAllActiveTechNodeDataList();
		int num = 1;
		HonamiStoryTechNodeData[] array = allActiveTechNodeDataList;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (int id in array[i].GetConfig.EffectIds())
			{
				HonamiStoryEffect? effectConfig = ConfigBase<HonamiStoryConfig>.Instance.GetEffectConfig(id);
				if (effectConfig != null && effectConfig.Value.EffectType == 5)
				{
					int num2 = int.Parse(effectConfig.Value.Param()[0]);
					num += num2 / 10000;
				}
			}
		}
		return num;
	}

	// Token: 0x0600EB18 RID: 60184 RVA: 0x003FC7A4 File Offset: 0x003FA9A4
	public bool IsShopHasRedDot()
	{
		if (this.ActivityData == null)
		{
			return false;
		}
		int shopId = this.ActivityData.ShopId;
		return ModelBase<PayShopModel>.Instance.CheckShopItemCheckFlag((PayShopDefine.EPayShopTabType)shopId, 1);
	}

	// Token: 0x0600EB19 RID: 60185 RVA: 0x003FC7D4 File Offset: 0x003FA9D4
	public HonamiStoryOutDialog? GetRandomDialogData(int dialogType)
	{
		IEnumerable<HonamiStoryOutDialog> honamiStoryOutDialogList = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryOutDialogList(this.ActivityId);
		List<HonamiStoryOutDialog> list = new List<HonamiStoryOutDialog>();
		foreach (HonamiStoryOutDialog item in honamiStoryOutDialogList)
		{
			if (item.Type == dialogType)
			{
				list.Add(item);
			}
		}
		int count = list.Count;
		if (count == 0)
		{
			return null;
		}
		if (count == 1)
		{
			return new HonamiStoryOutDialog?(list[0]);
		}
		int index = (int)Math.Floor(new Random().NextDouble() * (double)count);
		return new HonamiStoryOutDialog?(list[index]);
	}

	// Token: 0x0600EB1A RID: 60186 RVA: 0x003FC884 File Offset: 0x003FAA84
	public CSharpScript.Game.Module.HonamiStory.Data.HonamiStoryWeaponSuitData GetWeaponSuitData(int suitId)
	{
		CSharpScript.Game.Module.HonamiStory.Data.HonamiStoryWeaponSuitData result;
		if (!this.WeaponSuitMap.TryGetValue(suitId, out result))
		{
			result = (this.WeaponSuitMap[suitId] = new CSharpScript.Game.Module.HonamiStory.Data.HonamiStoryWeaponSuitData(suitId));
		}
		return result;
	}

	// Token: 0x0600EB1B RID: 60187 RVA: 0x003FC8B8 File Offset: 0x003FAAB8
	public int GetParentRoleId(int id)
	{
		int baseRoleId;
		if (!this.RoleParentMap.TryGetValue(id, out baseRoleId))
		{
			baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
			this.RoleParentMap[id] = baseRoleId;
		}
		return this.RoleParentMap[id];
	}

	// Token: 0x0600EB1C RID: 60188 RVA: 0x003FC8FC File Offset: 0x003FAAFC
	public bool CheckItemPlayerAlreadyPick(int incId)
	{
		HonamiStoryBackpackData backPackData = this.GetBackPackData(2, false);
		HonamiStoryPlayerBackpackData playerBackpackData = this.GetPlayerBackpackData();
		return backPackData.GetItemDataByInstanceId(incId, false) != null || playerBackpackData.CheckItemByIncId(incId);
	}

	// Token: 0x0600EB1D RID: 60189 RVA: 0x003FC92C File Offset: 0x003FAB2C
	public HonamiStoryItemDataBase CreateHonamiStoryItemData(HonamiStoryItemInfo itemInfo, [Nullable(2)] HonamiStoryPosInfo posInfo = null)
	{
		HonamiStoryItemDataBase honamiStoryItemDataBase;
		if (!this.ItemDataMap.TryGetValue(itemInfo.IncrId, out honamiStoryItemDataBase))
		{
			honamiStoryItemDataBase = this.CreateItemData(itemInfo.HonamiStoryItemId);
		}
		honamiStoryItemDataBase.Init(itemInfo);
		honamiStoryItemDataBase.UpdatePositionInfo(posInfo);
		this.ItemDataMap[honamiStoryItemDataBase.GetIncId()] = honamiStoryItemDataBase;
		return honamiStoryItemDataBase;
	}

	// Token: 0x0600EB1E RID: 60190 RVA: 0x003FC97C File Offset: 0x003FAB7C
	private HonamiStoryItemDataBase CreateItemData(int itemId)
	{
		if (ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(itemId).Value.ItemType == 1)
		{
			return new HonamiStoryEquipItemData();
		}
		return new HonamiStoryItemDataBase();
	}

	// Token: 0x0600EB1F RID: 60191 RVA: 0x003FC9B4 File Offset: 0x003FABB4
	[NullableContext(2)]
	public HonamiStoryItemDataBase GetItemData(int instanceId)
	{
		HonamiStoryItemDataBase result;
		if (!this.ItemDataMap.TryGetValue(instanceId, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ItemDataMap not found instanceId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(instanceId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return result;
	}

	// Token: 0x0600EB20 RID: 60192 RVA: 0x003FCA14 File Offset: 0x003FAC14
	public void RemoveItemData(int instanceId)
	{
		if (this.GetItemData(instanceId) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ItemDataMap not found instanceId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(instanceId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0600EB21 RID: 60193 RVA: 0x003FCA6C File Offset: 0x003FAC6C
	public List<HonamiStoryQuestDataBase> GetQuestDataListByQuestType(EHonamiStoryQuestType taskType)
	{
		if (this.ActivityData == null)
		{
			return new List<HonamiStoryQuestDataBase>();
		}
		List<HonamiStoryQuestDataBase> result;
		if (this.QuestDataMapCache.TryGetValue(taskType, out result))
		{
			return result;
		}
		if (taskType == EHonamiStoryQuestType.Main)
		{
			List<HonamiStoryQuestDataBase> list = new List<HonamiStoryQuestDataBase>();
			list.Add(new HonamiStoryMainQuestData());
			this.QuestDataMapCache[taskType] = list;
		}
		else if (taskType == EHonamiStoryQuestType.Sub)
		{
			List<HonamiStorySubQuestData> subQuestTaskDataList = this.ActivityData.GetSubQuestTaskDataList();
			this.QuestDataMapCache[taskType] = subQuestTaskDataList.Cast<HonamiStoryQuestDataBase>().ToList<HonamiStoryQuestDataBase>();
		}
		return this.QuestDataMapCache[taskType];
	}

	// Token: 0x0600EB22 RID: 60194 RVA: 0x003FCAF0 File Offset: 0x003FACF0
	public void SetSubQuestTrack(HonamiStoryQuestDataBase taskData)
	{
		if (taskData.TaskType != EHonamiStoryQuestType.Sub)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.LRC;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SetSubQuestTrack 任务类型错误: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Id);
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (taskData.IsFinished())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.HonamiStory;
			ELogAuthor author2 = ELogAuthor.LRC;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SetSubQuestTrack 任务已结束: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Id);
			instance2.Warn(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		HonamiStoryQuestDataBase curTrackTaskData = this.CurTrackTaskData;
		int? num = (curTrackTaskData != null) ? new int?(curTrackTaskData.Id) : null;
		int id = taskData.Id;
		bool flag = num.GetValueOrDefault() == id & num != null;
		HonamiStoryQuestDataBase curTrackTaskData2 = this.CurTrackTaskData;
		bool flag2 = curTrackTaskData2 != null && curTrackTaskData2.DoMapTrack(false);
		if (this.CurTrackTaskData != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.HonamiStory, ELogAuthor.LRC, "SetSubQuestTrack 取消追踪任务" + (flag2 ? "成功" : "失败") + ": " + ConfigMultiTextLang.GetLocalTextNew(this.CurTrackTaskData.GetNameKey(), null), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (flag2)
		{
			this.CurTrackTaskData = null;
		}
		if (!flag)
		{
			bool flag3 = taskData.DoMapTrack(true);
			Singleton<Log>.Instance.Info(ELogModule.HonamiStory, ELogAuthor.LRC, "SetSubQuestTrack 设置追踪任务" + (flag3 ? "成功" : "失败") + ": " + ConfigMultiTextLang.GetLocalTextNew(taskData.GetNameKey(), null), default(ReadOnlySpan<ValueTuple<string, object>>));
			if (flag3)
			{
				this.CurTrackTaskData = taskData;
			}
		}
	}

	// Token: 0x0600EB23 RID: 60195 RVA: 0x003FCCA0 File Offset: 0x003FAEA0
	public void InitSubQuestTrack()
	{
		if (this.CurTrackTaskData != null && !this.CurTrackTaskData.IsFinished())
		{
			return;
		}
		List<HonamiStoryQuestDataBase> questDataListByQuestType = this.GetQuestDataListByQuestType(EHonamiStoryQuestType.Sub);
		if (questDataListByQuestType == null || questDataListByQuestType.Count <= 0)
		{
			return;
		}
		foreach (HonamiStoryQuestDataBase honamiStoryQuestDataBase in questDataListByQuestType)
		{
			if (!honamiStoryQuestDataBase.IsFinished())
			{
				this.SetSubQuestTrack(honamiStoryQuestDataBase);
				break;
			}
		}
	}

	// Token: 0x0600EB24 RID: 60196 RVA: 0x003FCD24 File Offset: 0x003FAF24
	public void InitBackPackInfoList(List<HonamiStoryBagInfo> backpackInfoList)
	{
		foreach (HonamiStoryBagInfo bagInfo in backpackInfoList)
		{
			this.InitBackPackInfo(bagInfo);
		}
	}

	// Token: 0x0600EB25 RID: 60197 RVA: 0x003FCD74 File Offset: 0x003FAF74
	[NullableContext(2)]
	public void InitBackPackInfo(HonamiStoryBagInfo bagInfo)
	{
		if (bagInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "InitBackPackInfo 无效bagInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (bagInfo.BagConfigId == 1)
		{
			HonamiStoryBackpackData honamiStoryBackpackData = new HonamiStoryBackpackData();
			this.SetInventory(honamiStoryBackpackData);
			honamiStoryBackpackData.Init(bagInfo);
			return;
		}
		HonamiStoryBackpackData honamiStoryBackpackData2 = this.GetBackPackData(bagInfo.BagConfigId, true);
		if (honamiStoryBackpackData2 == null)
		{
			if (bagInfo.BagConfigId != 3)
			{
				honamiStoryBackpackData2 = new HonamiStoryBackpackData();
			}
			else
			{
				honamiStoryBackpackData2 = new HonamiStoryPickupBoxData();
			}
			this.BackpackDataMap[bagInfo.BagConfigId] = honamiStoryBackpackData2;
		}
		else
		{
			honamiStoryBackpackData2.ClearBackpack();
		}
		honamiStoryBackpackData2.Init(bagInfo);
	}

	// Token: 0x0600EB26 RID: 60198 RVA: 0x003FCE0C File Offset: 0x003FB00C
	[NullableContext(2)]
	public void UpdateBackPackInfo(HonamiStoryBagInfo bagInfo)
	{
		if (bagInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "InitBackPackInfo 无效bagInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (bagInfo.BagConfigId != 1)
		{
			HonamiStoryBackpackData honamiStoryBackpackData = this.GetBackPackData(bagInfo.BagConfigId, true);
			if (honamiStoryBackpackData == null)
			{
				if (bagInfo.BagConfigId != 3)
				{
					honamiStoryBackpackData = new HonamiStoryBackpackData();
				}
				else
				{
					honamiStoryBackpackData = new HonamiStoryPickupBoxData();
				}
				this.BackpackDataMap[bagInfo.BagConfigId] = honamiStoryBackpackData;
			}
			else
			{
				honamiStoryBackpackData.ClearBackpack();
			}
			honamiStoryBackpackData.Init(bagInfo);
			return;
		}
		if (this.WareHouseBackpackData == null)
		{
			HonamiStoryBackpackData honamiStoryBackpackData2 = new HonamiStoryBackpackData();
			this.SetInventory(honamiStoryBackpackData2);
			honamiStoryBackpackData2.Init(bagInfo);
			return;
		}
		this.WareHouseBackpackData.Init(bagInfo);
	}

	// Token: 0x0600EB27 RID: 60199 RVA: 0x003FCEB8 File Offset: 0x003FB0B8
	public bool GetSkillDescMode()
	{
		return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySkillDescMode, false);
	}

	// Token: 0x0600EB28 RID: 60200 RVA: 0x003FCEC5 File Offset: 0x003FB0C5
	public void SetSkillDescMode(bool isSimple)
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySkillDescMode, isSimple);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnHonamiStorySkillDescModeChange, isSimple);
	}

	// Token: 0x0600EB29 RID: 60201 RVA: 0x003FCEE4 File Offset: 0x003FB0E4
	public void RemoveBackPack(int backpackId)
	{
		HonamiStoryBackpackData backPackData = this.GetBackPackData(backpackId, false);
		if (backPackData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 1);
			defaultInterpolatedStringHandler.AppendLiteral("RemoveBackPack 无效backpackId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(backpackId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		backPackData.ClearBackpack();
		this.BackpackDataMap.Remove(backpackId);
	}

	// Token: 0x0600EB2A RID: 60202 RVA: 0x003FCF50 File Offset: 0x003FB150
	public void UpdateBackpackInfo(HonamiStoryBagInfoUpdateNotify updateInfo)
	{
		foreach (HonamiStoryBagInfo honamiStoryBagInfo in updateInfo.HonamiStoryBagInfos)
		{
			HonamiStoryBackpackData backPackData = this.GetBackPackData(honamiStoryBagInfo.BagConfigId, false);
			backPackData.SetCapacity(honamiStoryBagInfo.BagSize);
			backPackData.Update(honamiStoryBagInfo.HonamiStoryBagItemInfos.ToList<HonamiStoryBagItemInfo>());
		}
	}

	// Token: 0x0600EB2B RID: 60203 RVA: 0x003FCFC0 File Offset: 0x003FB1C0
	public void UpdateBackpackSize(Dictionary<int, int> updateInfo)
	{
		foreach (KeyValuePair<int, int> keyValuePair in updateInfo)
		{
			int key = keyValuePair.Key;
			HonamiStoryBackpackData backPackData = this.GetBackPackData(key, false);
			if (backPackData != null)
			{
				backPackData.SetCapacity(keyValuePair.Value);
			}
		}
	}

	// Token: 0x0600EB2C RID: 60204 RVA: 0x003FD02C File Offset: 0x003FB22C
	public void UpdateBackPackContext(IReadOnlyList<HonamiStoryBagUpdateContext> updateContext)
	{
		foreach (HonamiStoryBagUpdateContext honamiStoryBagUpdateContext in updateContext)
		{
			int backPackConfigId = honamiStoryBagUpdateContext.BackPackConfigId;
			if (backPackConfigId == 4)
			{
				this.UpdatePlayerBackPack(honamiStoryBagUpdateContext);
			}
			else
			{
				RepeatedField<HonamiStoryBagUpdateInfo> honamiStoryBagUpdateInfo = honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo;
				if (backPackConfigId == 1)
				{
					HonamiStoryBackpackData inventory = this.GetInventory();
					if (inventory != null)
					{
						inventory.UpdateByContext(honamiStoryBagUpdateInfo.ToList<HonamiStoryBagUpdateInfo>());
					}
				}
				else
				{
					this.GetBackPackData(backPackConfigId, false).UpdateByContext(honamiStoryBagUpdateInfo.ToList<HonamiStoryBagUpdateInfo>());
				}
			}
		}
	}

	// Token: 0x0600EB2D RID: 60205 RVA: 0x003FD0B8 File Offset: 0x003FB2B8
	[NullableContext(2)]
	public HonamiStoryBackpackData GetBackPackData(int backpackId, bool notLog = false)
	{
		if (backpackId == 1)
		{
			HonamiStoryBackpackData inventory = this.GetInventory();
			if (!notLog && inventory == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.HonamiStory;
				ELogAuthor author = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("GetBackPackData 无效backpackId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(backpackId);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return inventory;
		}
		HonamiStoryBackpackData result;
		if (!this.BackpackDataMap.TryGetValue(backpackId, out result))
		{
			if (!notLog)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.HonamiStory;
				ELogAuthor author2 = ELogAuthor.BB;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler.AppendLiteral("GetBackPackData 无效backpackId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(backpackId);
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return null;
		}
		return result;
	}

	// Token: 0x0600EB2E RID: 60206 RVA: 0x003FD16C File Offset: 0x003FB36C
	public bool IsPickUpViewOpened()
	{
		return Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpBackpackView) != null || Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryPickUpMobileView) != null;
	}

	// Token: 0x0600EB2F RID: 60207 RVA: 0x003FD194 File Offset: 0x003FB394
	public void TryPickUp(HonamiStoryItemDataBase itemDataBase, Entity entity)
	{
		HonamiStoryBackpackData backPackData = this.GetBackPackData(2, false);
		itemDataBase.SetBackpackWidth(backPackData.GetWidthCount());
		if (this.IsPickUpViewOpened())
		{
			this.IsPickingUp = false;
			PawnInteractNewComponent pawnInteractNewComponent = entity.CheckGetComponent<PawnInteractNewComponent>();
			if (pawnInteractNewComponent != null)
			{
				pawnInteractNewComponent.SetInteractionState(true, "HonamiStoryPickUp");
			}
			this.ClearPickUpQueue();
			this.PickedEntityId.Clear();
			return;
		}
		if (this.IsPickingUp)
		{
			using (List<IPickUpItemInfo>.Enumerator enumerator = this.PickUpItemDataQueue.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.ItemData.GetIncId() == itemDataBase.GetIncId())
					{
						return;
					}
				}
			}
			this.PickUpItemDataQueue.Add(new PickUpItemInfo
			{
				ItemData = itemDataBase,
				EntitySelf = entity
			});
			return;
		}
		this.PickedEntityId.Clear();
		this.IsPickingUp = true;
		this.PickUpItemDataQueue.Add(new PickUpItemInfo
		{
			ItemData = itemDataBase,
			EntitySelf = entity
		});
		this.OnPickUpEnd();
	}

	// Token: 0x0600EB30 RID: 60208 RVA: 0x003FD29C File Offset: 0x003FB49C
	public void OnPickUpEnd()
	{
		if (this.PickUpItemDataQueue.Count == 0)
		{
			this.IsPickingUp = false;
			this.ClearPickUpQueue();
			return;
		}
		IPickUpItemInfo itemData = this.PickUpItemDataQueue[0];
		this.PickUpItemDataQueue.RemoveAt(0);
		if (itemData == null)
		{
			this.IsPickingUp = false;
			this.ClearPickUpQueue();
			return;
		}
		double now = Singleton<Time>.Instance.Now;
		if (now - this.PickUpTime < 200.0)
		{
			double num = Math.Max(200.0 - (now - this.PickUpTime), 20.0);
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.ExecutePickUp(itemData).Forget();
			}, (float)num, null, null, true, 1f);
			return;
		}
		this.ExecutePickUp(itemData).Forget();
	}

	// Token: 0x0600EB31 RID: 60209 RVA: 0x003FD378 File Offset: 0x003FB578
	private UniTask ExecutePickUp(IPickUpItemInfo info)
	{
		HonamiStoryModel.<ExecutePickUp>d__121 <ExecutePickUp>d__;
		<ExecutePickUp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecutePickUp>d__.<>4__this = this;
		<ExecutePickUp>d__.info = info;
		<ExecutePickUp>d__.<>1__state = -1;
		<ExecutePickUp>d__.<>t__builder.Start<HonamiStoryModel.<ExecutePickUp>d__121>(ref <ExecutePickUp>d__);
		return <ExecutePickUp>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB32 RID: 60210 RVA: 0x003FD3C4 File Offset: 0x003FB5C4
	[NullableContext(0)]
	protected UniTask<bool> DoPickUpLogic([Nullable(1)] IPickUpItemInfo info)
	{
		HonamiStoryModel.<DoPickUpLogic>d__122 <DoPickUpLogic>d__;
		<DoPickUpLogic>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<DoPickUpLogic>d__.<>4__this = this;
		<DoPickUpLogic>d__.info = info;
		<DoPickUpLogic>d__.<>1__state = -1;
		<DoPickUpLogic>d__.<>t__builder.Start<HonamiStoryModel.<DoPickUpLogic>d__122>(ref <DoPickUpLogic>d__);
		return <DoPickUpLogic>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB33 RID: 60211 RVA: 0x003FD410 File Offset: 0x003FB610
	private void ClearPickUpQueue()
	{
		foreach (IPickUpItemInfo pickUpItemInfo in this.PickUpItemDataQueue)
		{
			PawnInteractNewComponent pawnInteractNewComponent = pickUpItemInfo.EntitySelf.CheckGetComponent<PawnInteractNewComponent>();
			if (pawnInteractNewComponent != null)
			{
				pawnInteractNewComponent.SetInteractionState(true, "HonamiStoryPickUp");
			}
		}
		this.PickUpItemDataQueue.Clear();
	}

	// Token: 0x0600EB34 RID: 60212 RVA: 0x003FD480 File Offset: 0x003FB680
	private void AddHonamiStoryItemNewGetTipsList(HonamiStoryItemDataBase itemData)
	{
		int itemId = itemData.GetItemId();
		HonamiStoryItem? honamiStoryItem = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(itemId);
		if (honamiStoryItem == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
			defaultInterpolatedStringHandler.AppendLiteral("AddHonamiStoryItemNewGetTipsList 无效itemId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(itemId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int num;
		if (HonamiStoryUtil.CheckInHonamiStoryMainDungeon())
		{
			num = HonamiStoryUtil.GetDropQualityInMainQuest();
		}
		else
		{
			num = ConfigBase<HonamiStoryConfig>.Instance.GetDangerLevelConfig(this.DangerLevel).Value.HightQuality;
		}
		if (honamiStoryItem.Value.QualityId >= num)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryNewTipsView, itemData, null);
			return;
		}
		ModelBase<ItemHintModel>.Instance.AddItemToPriorInterfaceData(itemId, 1, honamiStoryItem.Value.QualityId);
	}

	// Token: 0x0600EB35 RID: 60213 RVA: 0x003FD55F File Offset: 0x003FB75F
	[NullableContext(2)]
	public HonamiStoryBackpackLogicController GetBackpackLogic()
	{
		return this.CurBackpackLogicController;
	}

	// Token: 0x0600EB36 RID: 60214 RVA: 0x003FD567 File Offset: 0x003FB767
	[NullableContext(2)]
	public void SetBackpackLogic(HonamiStoryBackpackLogicController value)
	{
		if (this.CurBackpackLogicController != null)
		{
			this.CurBackpackLogicController.Destroy();
		}
		this.CurBackpackLogicController = value;
	}

	// Token: 0x0600EB37 RID: 60215 RVA: 0x003FD583 File Offset: 0x003FB783
	public EHonamiStoryBackpackLogicState GetBackpackLogicState()
	{
		return this.CurBackpackLogicController.GetLogicState();
	}

	// Token: 0x0600EB38 RID: 60216 RVA: 0x003FD590 File Offset: 0x003FB790
	public void SetBackpackLogicState(EHonamiStoryBackpackLogicState state)
	{
		this.CurBackpackLogicController.SetLogicState(state, null, null);
	}

	// Token: 0x0600EB39 RID: 60217 RVA: 0x003FD5B4 File Offset: 0x003FB7B4
	public void ShowDiscardTips(HonamiStoryItemDataBase item)
	{
		string name = item.GetName();
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(name, name);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_DiscardItemTips", new object[]
		{
			multiTextByKey
		});
	}

	// Token: 0x0600EB3A RID: 60218 RVA: 0x003FD5EE File Offset: 0x003FB7EE
	public HonamiStoryInteractController GetInteractController()
	{
		return this.CurBackpackLogicController.GetInteractController();
	}

	// Token: 0x0600EB3B RID: 60219 RVA: 0x003FD5FC File Offset: 0x003FB7FC
	public int GetCurrencyCount()
	{
		int outCoinItemId = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryActivityConfig(this.ActivityData.Id).Value.OutCoinItemId;
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(outCoinItemId, 0);
	}

	// Token: 0x0600EB3C RID: 60220 RVA: 0x003FD63C File Offset: 0x003FB83C
	public void QuickPickUpFromPickUpBox(HonamiStoryItemDataBase itemData, int curPos)
	{
		HonamiStoryBackpackData backPackData = this.GetBackPackData(2, false);
		if (backPackData == null)
		{
			return;
		}
		int num = this.CheckCanEquipOnEmpty(itemData);
		if (num != -1)
		{
			ControllerBase<HonamiStoryController>.Instance.RequestSwitchItem(itemData, null, curPos, num, EHonamiStoryBackpack.PickUpBox, EHonamiStoryBackpack.Player).Forget<bool>();
			return;
		}
		IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindFirstAvailablePosition(backPackData.GetEmptyGridSet(), itemData, backPackData.GetWidthCount(), null);
		ValueTuple<int, HonamiStoryItemDataBase> valueTuple = this.CheckCanEquipInstead(itemData);
		int item = valueTuple.Item1;
		HonamiStoryItemDataBase item2 = valueTuple.Item2;
		if (honamiStoryAvailablePosInfo.Position >= 0)
		{
			itemData.SetIsDragCross(honamiStoryAvailablePosInfo.IsCross);
			if (item == -1)
			{
				ControllerBase<HonamiStoryController>.Instance.RequestSwitchItem(itemData, null, curPos, honamiStoryAvailablePosInfo.Position, EHonamiStoryBackpack.PickUpBox, EHonamiStoryBackpack.Backpack).Forget<bool>();
				return;
			}
			ControllerBase<HonamiStoryController>.Instance.RequestEquipFromPickUpBox(itemData, item2, item, honamiStoryAvailablePosInfo.Position).Forget<bool>();
			return;
		}
		else
		{
			if (itemData.GetItemType() == EHonamiStoryItemType.Normal)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoEnoughSpace", Array.Empty<object>());
				return;
			}
			string textId = (item >= 0) ? "HonamiStory_NoEnoughForQuickInstead" : "HonamiStory_NoEnoughSpace";
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(textId, Array.Empty<object>());
			return;
		}
	}

	// Token: 0x0600EB3D RID: 60221 RVA: 0x003FD730 File Offset: 0x003FB930
	public bool QuickEquipFromBackpack(HonamiStoryItemDataBase itemData, int curPos)
	{
		if (itemData.GetItemType() == EHonamiStoryItemType.Normal)
		{
			return false;
		}
		int num = this.CheckCanEquipOnEmpty(itemData);
		EHonamiStoryBackpack sourceBag = HonamiStoryUtil.CheckInHonamiStoryDungeon() ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		if (num != -1)
		{
			ControllerBase<HonamiStoryController>.Instance.RequestSwitchItem(itemData, null, curPos, num, sourceBag, EHonamiStoryBackpack.Player).Forget<bool>();
			return true;
		}
		ValueTuple<int, HonamiStoryItemDataBase> valueTuple = this.CheckCanEquipInstead(itemData);
		int item = valueTuple.Item1;
		HonamiStoryItemDataBase item2 = valueTuple.Item2;
		if (item != -1)
		{
			ControllerBase<HonamiStoryController>.Instance.RequestSwitchItem(itemData, item2, curPos, item, sourceBag, EHonamiStoryBackpack.Player).Forget<bool>();
			return true;
		}
		return false;
	}

	// Token: 0x0600EB3E RID: 60222 RVA: 0x003FD7A8 File Offset: 0x003FB9A8
	[NullableContext(0)]
	public UniTask<bool> PickUpFromWorld([Nullable(1)] HonamiStoryItemDataBase itemData, int position)
	{
		HonamiStoryModel.<PickUpFromWorld>d__134 <PickUpFromWorld>d__;
		<PickUpFromWorld>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<PickUpFromWorld>d__.<>4__this = this;
		<PickUpFromWorld>d__.itemData = itemData;
		<PickUpFromWorld>d__.position = position;
		<PickUpFromWorld>d__.<>1__state = -1;
		<PickUpFromWorld>d__.<>t__builder.Start<HonamiStoryModel.<PickUpFromWorld>d__134>(ref <PickUpFromWorld>d__);
		return <PickUpFromWorld>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB3F RID: 60223 RVA: 0x003FD7FC File Offset: 0x003FB9FC
	public int CheckCanEquipOnEmpty(HonamiStoryItemDataBase itemDataBase)
	{
		if (itemDataBase.GetItemType() == EHonamiStoryItemType.Normal)
		{
			return -1;
		}
		HonamiStoryEquipItemData honamiStoryEquipItemData = itemDataBase as HonamiStoryEquipItemData;
		if (honamiStoryEquipItemData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.WHJ, "获取道具类型出现错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return -1;
		}
		List<HonamiStoryRoleEquipData> roleEquipDataList = this.GetPlayerBackpackData().GetRoleEquipDataList(true);
		HonamiStoryRoleEquipData honamiStoryRoleEquipData = null;
		int num = 0;
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData2 in roleEquipDataList)
		{
			int num2 = honamiStoryRoleEquipData2.CheckEquipOnEmpty(honamiStoryEquipItemData);
			if (num2 > num)
			{
				num = num2;
				honamiStoryRoleEquipData = honamiStoryRoleEquipData2;
			}
		}
		if (honamiStoryRoleEquipData == null)
		{
			return -1;
		}
		return honamiStoryRoleEquipData.GetNextEmptySlot();
	}

	// Token: 0x0600EB40 RID: 60224 RVA: 0x003FD8AC File Offset: 0x003FBAAC
	[NullableContext(0)]
	public UniTask<bool> TryQuickEquipOnEmpty([Nullable(1)] HonamiStoryItemDataBase itemDataBase)
	{
		HonamiStoryModel.<TryQuickEquipOnEmpty>d__136 <TryQuickEquipOnEmpty>d__;
		<TryQuickEquipOnEmpty>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<TryQuickEquipOnEmpty>d__.<>4__this = this;
		<TryQuickEquipOnEmpty>d__.itemDataBase = itemDataBase;
		<TryQuickEquipOnEmpty>d__.<>1__state = -1;
		<TryQuickEquipOnEmpty>d__.<>t__builder.Start<HonamiStoryModel.<TryQuickEquipOnEmpty>d__136>(ref <TryQuickEquipOnEmpty>d__);
		return <TryQuickEquipOnEmpty>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB41 RID: 60225 RVA: 0x003FD8F8 File Offset: 0x003FBAF8
	[return: TupleElementNames(new string[]
	{
		"equipPosition",
		"equippedItemData"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public ValueTuple<int, HonamiStoryItemDataBase> CheckCanEquipInstead(HonamiStoryItemDataBase itemDataBase)
	{
		if (itemDataBase.GetItemType() == EHonamiStoryItemType.Normal)
		{
			return new ValueTuple<int, HonamiStoryItemDataBase>(-1, null);
		}
		HonamiStoryEquipItemData honamiStoryEquipItemData = itemDataBase as HonamiStoryEquipItemData;
		if (honamiStoryEquipItemData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.WHJ, "获取道具类型出现错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new ValueTuple<int, HonamiStoryItemDataBase>(-1, null);
		}
		List<HonamiStoryRoleEquipData> roleEquipDataList = this.GetPlayerBackpackData().GetRoleEquipDataList(true);
		int num = 0;
		int item = -1;
		HonamiStoryItemDataBase item2 = null;
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in roleEquipDataList)
		{
			ValueTuple<int, int, HonamiStoryEquipItemData> valueTuple = honamiStoryRoleEquipData.CheckEquipInstead(honamiStoryEquipItemData);
			int item3 = valueTuple.Item1;
			int item4 = valueTuple.Item2;
			HonamiStoryEquipItemData item5 = valueTuple.Item3;
			if (item4 > num)
			{
				num = item4;
				item = item3;
				item2 = item5;
			}
		}
		return new ValueTuple<int, HonamiStoryItemDataBase>(item, item2);
	}

	// Token: 0x0600EB42 RID: 60226 RVA: 0x003FD9C8 File Offset: 0x003FBBC8
	[NullableContext(0)]
	public UniTask<bool> TryQuickEquipInstead([Nullable(1)] HonamiStoryItemDataBase itemDataBase, int position)
	{
		HonamiStoryModel.<TryQuickEquipInstead>d__138 <TryQuickEquipInstead>d__;
		<TryQuickEquipInstead>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<TryQuickEquipInstead>d__.<>4__this = this;
		<TryQuickEquipInstead>d__.itemDataBase = itemDataBase;
		<TryQuickEquipInstead>d__.position = position;
		<TryQuickEquipInstead>d__.<>1__state = -1;
		<TryQuickEquipInstead>d__.<>t__builder.Start<HonamiStoryModel.<TryQuickEquipInstead>d__138>(ref <TryQuickEquipInstead>d__);
		return <TryQuickEquipInstead>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB43 RID: 60227 RVA: 0x003FDA1C File Offset: 0x003FBC1C
	public bool SetItemIntoBag(HonamiStoryItemDataBase itemData, EHonamiStoryBackpack curBackpack, EHonamiStoryBackpack toBackpack)
	{
		HonamiStoryBackpackData backPackData = this.GetBackPackData((int)toBackpack, false);
		if (backPackData == null)
		{
			return false;
		}
		IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindFirstAvailablePosition(backPackData.GetEmptyGridSet(), itemData, backPackData.GetWidthCount(), null);
		if (honamiStoryAvailablePosInfo.Position == -1)
		{
			return false;
		}
		using (List<int>.Enumerator enumerator = itemData.GetGridFillPositionByPosition(honamiStoryAvailablePosInfo.Position, honamiStoryAvailablePosInfo.IsCross).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current >= backPackData.GetCapacity())
				{
					return false;
				}
			}
		}
		itemData.SetIsDragCross(honamiStoryAvailablePosInfo.IsCross);
		ControllerBase<HonamiStoryController>.Instance.RequestSwitchItem(itemData, null, -1, honamiStoryAvailablePosInfo.Position, curBackpack, toBackpack).ContinueWith(delegate(bool _)
		{
			if (toBackpack == EHonamiStoryBackpack.PickUpBox)
			{
				this.ShowDiscardTips(itemData);
			}
		}).Forget();
		return true;
	}

	// Token: 0x0600EB44 RID: 60228 RVA: 0x003FDB24 File Offset: 0x003FBD24
	[NullableContext(0)]
	public UniTask<bool> SellSingleItem([Nullable(1)] HonamiStoryItemDataBase itemData, EHonamiStoryBackpack backpack)
	{
		HonamiStoryModel.<SellSingleItem>d__140 <SellSingleItem>d__;
		<SellSingleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SellSingleItem>d__.itemData = itemData;
		<SellSingleItem>d__.backpack = backpack;
		<SellSingleItem>d__.<>1__state = -1;
		<SellSingleItem>d__.<>t__builder.Start<HonamiStoryModel.<SellSingleItem>d__140>(ref <SellSingleItem>d__);
		return <SellSingleItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB45 RID: 60229 RVA: 0x003FDB6F File Offset: 0x003FBD6F
	public void SetIsLastPickUpViewDirty(bool value)
	{
		this.IsLastPickUpViewDirty = value;
	}

	// Token: 0x0600EB46 RID: 60230 RVA: 0x003FDB78 File Offset: 0x003FBD78
	public bool GetIsLastPickUpViewDirty()
	{
		return HonamiStoryUtil.CheckInHonamiStoryDungeon() && this.IsLastPickUpViewDirty;
	}

	// Token: 0x0600EB47 RID: 60231 RVA: 0x003FDB89 File Offset: 0x003FBD89
	public void SetQuickAllDirty(bool needRefresh = true)
	{
		this.QuickAllManager.SetDirty();
		if (needRefresh && this.GetBackpackLogic() != null)
		{
			this.QuickAllRefresh(false);
			this.GetBackpackLogic().RefreshNeedQuickAll();
		}
	}

	// Token: 0x0600EB48 RID: 60232 RVA: 0x003FDBB4 File Offset: 0x003FBDB4
	public bool QuickAllRefresh(bool force = false)
	{
		return this.QuickAllManager.Refresh(force);
	}

	// Token: 0x0600EB49 RID: 60233 RVA: 0x003FDBC4 File Offset: 0x003FBDC4
	public bool QuickAllCheck(bool needVirtual = true)
	{
		if (this.QuickAllManager.GetDirty())
		{
			this.QuickAllRefresh(false);
		}
		int powerLevel = this.GetPlayerBackpackData().GetPowerLevel(!needVirtual);
		return (needVirtual ? this.QuickAllManager.GetCurPowerLevel() : this.QuickAllManager.GetRealPowerLevel()) > powerLevel;
	}

	// Token: 0x0600EB4A RID: 60234 RVA: 0x003FDC14 File Offset: 0x003FBE14
	public void ApplyQuickAll()
	{
		if (!this.QuickAllCheck(true))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_QuickEquip_BestAlready", Array.Empty<object>());
			return;
		}
		if (this.QuickAllManager.GetDirty())
		{
			this.QuickAllRefresh(false);
		}
		this.QuickAllManager.ApplyQuickAll();
	}

	// Token: 0x0600EB4B RID: 60235 RVA: 0x003FDC54 File Offset: 0x003FBE54
	public void QuickUnloadAllSlot()
	{
		List<HonamiStoryRoleEquipData> roleEquipDataList = this.GetPlayerBackpackData().GetRoleEquipDataList(true);
		List<HonamiStoryItemDataBase> list = new List<HonamiStoryItemDataBase>();
		foreach (HonamiStoryRoleEquipData honamiStoryRoleEquipData in roleEquipDataList)
		{
			foreach (HonamiStoryRoleEquipSlotData honamiStoryRoleEquipSlotData in honamiStoryRoleEquipData.GetSlotList())
			{
				HonamiStoryEquipItemData itemData = honamiStoryRoleEquipSlotData.GetItemData();
				if (itemData != null)
				{
					list.Add(itemData);
				}
			}
		}
		bool flag = HonamiStoryUtil.CheckInHonamiStoryDungeon();
		EHonamiStoryBackpack ehonamiStoryBackpack = flag ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		HonamiStoryBackpackData backPackData = this.GetBackPackData((int)ehonamiStoryBackpack, false);
		if (backPackData == null)
		{
			return;
		}
		HashSet<int> hashSet = new HashSet<int>();
		int capacity = backPackData.GetCapacity();
		foreach (HonamiStoryItemDataBase itemData2 in list)
		{
			IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindFirstAvailablePosition(backPackData.GetEmptyGridSet(), itemData2, backPackData.GetWidthCount(), hashSet);
			if (!flag && honamiStoryAvailablePosInfo.Position >= capacity)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoEnoughSpace", Array.Empty<object>());
				return;
			}
			if (honamiStoryAvailablePosInfo.Position == -1)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoEnoughSpace", Array.Empty<object>());
				return;
			}
			hashSet.Add(honamiStoryAvailablePosInfo.Position);
		}
		if (hashSet.Count != list.Count)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoEnoughSpace", Array.Empty<object>());
			return;
		}
		ControllerBase<HonamiStoryController>.Instance.RequestHonamiStoryQuickUnloadAll(list, hashSet, ehonamiStoryBackpack).Forget<bool>();
	}

	// Token: 0x0600EB4C RID: 60236 RVA: 0x003FDDFC File Offset: 0x003FBFFC
	[return: Nullable(2)]
	protected HonamiStoryBagUpdateContext GetSortContext(EHonamiStoryBackpack backpack, Dictionary<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo> sortMap)
	{
		HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
		honamiStoryBagUpdateContext.BackPackConfigId = (int)backpack;
		foreach (KeyValuePair<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo> keyValuePair in sortMap)
		{
			HonamiStoryItemDataBase key = keyValuePair.Key;
			IHonamiStoryAvailablePosInfo value = keyValuePair.Value;
			if (key.GetPosition() != value.Position || value.IsCross != key.GetIsCross())
			{
				key.SetIsDragCross(value.IsCross);
				HonamiStoryBagUpdateInfo honamiStoryItemSwapInfo = HonamiStoryUtil.GetHonamiStoryItemSwapInfo(key, value.Position);
				honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemSwapInfo);
			}
		}
		if (honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Count == 0)
		{
			return null;
		}
		return honamiStoryBagUpdateContext;
	}

	// Token: 0x0600EB4D RID: 60237 RVA: 0x003FDEB8 File Offset: 0x003FC0B8
	public void SortBackpack()
	{
		EHonamiStoryBackpack backpack = HonamiStoryUtil.CheckInHonamiStoryDungeon() ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		ValueTuple<bool, HonamiStoryBagUpdateContext> valueTuple = this.TrySort(backpack, true);
		bool item = valueTuple.Item1;
		HonamiStoryBagUpdateContext item2 = valueTuple.Item2;
		List<HonamiStoryBagUpdateContext> list = new List<HonamiStoryBagUpdateContext>();
		if (item2 != null)
		{
			list.Add(item2);
		}
		if (HonamiStoryUtil.CheckInHonamiStoryDungeon())
		{
			HonamiStoryBagUpdateContext item3 = this.TrySort(EHonamiStoryBackpack.PickUpBox, false).Item2;
			if (item3 != null)
			{
				list.Add(item3);
			}
		}
		if (list.Count > 0)
		{
			ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryBagOperateRequest(list).ContinueWith(delegate(bool task)
			{
				if (task)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_SortSuccess", Array.Empty<object>());
					Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStorySortSuccess);
				}
			}).Forget();
			return;
		}
		if (!item)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_SortSuccess", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStorySortSuccess);
		}
	}

	// Token: 0x0600EB4E RID: 60238 RVA: 0x003FDF80 File Offset: 0x003FC180
	[return: TupleElementNames(new string[]
	{
		"sortFailTips",
		"context"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public ValueTuple<bool, HonamiStoryBagUpdateContext> TrySort(EHonamiStoryBackpack backpack, bool needTips)
	{
		HonamiStoryBackpackData backPackData = this.GetBackPackData((int)backpack, false);
		int widthCount = backPackData.GetWidthCount();
		int capacity = backPackData.GetCapacity();
		List<HonamiStoryItemDataBase> itemDataList = backPackData.GetItemDataList();
		List<HonamiStoryItemDataBase> list = new List<HonamiStoryItemDataBase>();
		List<HonamiStoryItemDataBase> list2 = new List<HonamiStoryItemDataBase>();
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in itemDataList)
		{
			if (honamiStoryItemDataBase.GetItemType() == EHonamiStoryItemType.Normal)
			{
				list2.Add(honamiStoryItemDataBase);
			}
			else
			{
				list.Add(honamiStoryItemDataBase);
			}
		}
		list.Sort(this.PluginSort);
		list2.Sort(this.NormalSort);
		ValueTuple<bool, HonamiStoryBagUpdateContext> valueTuple = this.FirstSortBackpack(backpack, list, list2, capacity, widthCount);
		bool item = valueTuple.Item1;
		HonamiStoryBagUpdateContext item2 = valueTuple.Item2;
		if (item)
		{
			return new ValueTuple<bool, HonamiStoryBagUpdateContext>(false, item2);
		}
		ValueTuple<HonamiStoryBagUpdateContext, int> valueTuple2 = this.SecondSortBackpack(backpack, list, list2, capacity, widthCount);
		HonamiStoryBagUpdateContext item3 = valueTuple2.Item1;
		int item4 = valueTuple2.Item2;
		if (item3 == null && item4 > 0)
		{
			if (needTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_CantSortBackpack", new object[]
				{
					item4
				});
			}
			return new ValueTuple<bool, HonamiStoryBagUpdateContext>(true, null);
		}
		return new ValueTuple<bool, HonamiStoryBagUpdateContext>(false, item3);
	}

	// Token: 0x0600EB4F RID: 60239 RVA: 0x003FE0A0 File Offset: 0x003FC2A0
	[return: TupleElementNames(new string[]
	{
		"valid",
		"context"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	protected ValueTuple<bool, HonamiStoryBagUpdateContext> FirstSortBackpack(EHonamiStoryBackpack backpackId, List<HonamiStoryItemDataBase> pluginList, List<HonamiStoryItemDataBase> normalList, int capacity, int width)
	{
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < capacity; i++)
		{
			hashSet.Add(i);
		}
		Dictionary<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo> dictionary = new Dictionary<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo>();
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in pluginList)
		{
			IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindFirstAvailablePosition(hashSet, honamiStoryItemDataBase, width, null);
			if (honamiStoryAvailablePosInfo.Position == -1)
			{
				return new ValueTuple<bool, HonamiStoryBagUpdateContext>(false, null);
			}
			hashSet.Remove(honamiStoryAvailablePosInfo.Position);
			dictionary[honamiStoryItemDataBase] = honamiStoryAvailablePosInfo;
		}
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase2 in normalList)
		{
			IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo2 = HonamiStoryUtil.FindFirstAvailablePosition(hashSet, honamiStoryItemDataBase2, width, null);
			if (honamiStoryAvailablePosInfo2.Position == -1)
			{
				return new ValueTuple<bool, HonamiStoryBagUpdateContext>(false, null);
			}
			foreach (int item in honamiStoryItemDataBase2.GetGridFillPositionByPosition(honamiStoryAvailablePosInfo2.Position, honamiStoryAvailablePosInfo2.IsCross))
			{
				hashSet.Remove(item);
			}
			dictionary[honamiStoryItemDataBase2] = honamiStoryAvailablePosInfo2;
		}
		return new ValueTuple<bool, HonamiStoryBagUpdateContext>(true, this.GetSortContext(backpackId, dictionary));
	}

	// Token: 0x0600EB50 RID: 60240 RVA: 0x003FE214 File Offset: 0x003FC414
	[return: TupleElementNames(new string[]
	{
		"context",
		"count"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	protected ValueTuple<HonamiStoryBagUpdateContext, int> SecondSortBackpack(EHonamiStoryBackpack backpackId, List<HonamiStoryItemDataBase> pluginList, List<HonamiStoryItemDataBase> normalList, int capacity, int width)
	{
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < capacity; i++)
		{
			hashSet.Add(i);
		}
		Dictionary<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo> dictionary = new Dictionary<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo>();
		int num = -1;
		bool flag = false;
		int num2 = 0;
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in normalList)
		{
			if (flag)
			{
				num2 += honamiStoryItemDataBase.GetGridHeight() * honamiStoryItemDataBase.GetGridWidth();
			}
			else
			{
				IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo = HonamiStoryUtil.FindFirstAvailablePosition(hashSet, honamiStoryItemDataBase, width, null);
				if (honamiStoryAvailablePosInfo.Position == -1)
				{
					flag = true;
					num2 += honamiStoryItemDataBase.GetGridHeight() * honamiStoryItemDataBase.GetGridWidth();
				}
				else
				{
					foreach (int num3 in honamiStoryItemDataBase.GetGridFillPositionByPosition(honamiStoryAvailablePosInfo.Position, honamiStoryAvailablePosInfo.IsCross))
					{
						num = Math.Max(num, num3);
						hashSet.Remove(num3);
					}
					dictionary[honamiStoryItemDataBase] = honamiStoryAvailablePosInfo;
				}
			}
		}
		HashSet<int> hashSet2 = new HashSet<int>();
		if (!flag)
		{
			int num4 = (int)(Math.Floor((double)(num + 1) / (double)width) * (double)width + (double)(((num + 1) % width == 0) ? 0 : width));
			int num5 = capacity - num4;
			for (int j = 0; j < capacity; j++)
			{
				if (j < num5 || hashSet.Contains(j - num5))
				{
					hashSet2.Add(j);
				}
			}
			foreach (KeyValuePair<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo> keyValuePair in dictionary)
			{
				keyValuePair.Value.Position += num5;
			}
		}
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase2 in pluginList)
		{
			if (flag)
			{
				num2 += honamiStoryItemDataBase2.GetGridHeight() * honamiStoryItemDataBase2.GetGridWidth();
			}
			else
			{
				IHonamiStoryAvailablePosInfo honamiStoryAvailablePosInfo2 = HonamiStoryUtil.FindFirstAvailablePosition(hashSet2, honamiStoryItemDataBase2, width, null);
				if (honamiStoryAvailablePosInfo2.Position == -1)
				{
					flag = true;
					num2 += honamiStoryItemDataBase2.GetGridHeight() * honamiStoryItemDataBase2.GetGridWidth();
				}
				else
				{
					hashSet2.Remove(honamiStoryAvailablePosInfo2.Position);
					dictionary[honamiStoryItemDataBase2] = honamiStoryAvailablePosInfo2;
				}
			}
		}
		if (flag)
		{
			return new ValueTuple<HonamiStoryBagUpdateContext, int>(null, num2);
		}
		HashSet<int> hashSet3 = new HashSet<int>();
		foreach (KeyValuePair<HonamiStoryItemDataBase, IHonamiStoryAvailablePosInfo> keyValuePair2 in dictionary)
		{
			if (!hashSet3.Contains(keyValuePair2.Value.Position))
			{
				hashSet3.Add(keyValuePair2.Value.Position);
			}
		}
		return new ValueTuple<HonamiStoryBagUpdateContext, int>(this.GetSortContext(backpackId, dictionary), 0);
	}

	// Token: 0x0600EB51 RID: 60241 RVA: 0x003FE514 File Offset: 0x003FC714
	[NullableContext(2)]
	public HonamiStoryGamepadLogicController GetGamepadLogic()
	{
		if (this.CurGamepadLogicController == null)
		{
			this.CurGamepadLogicController = new HonamiStoryGamepadLogicController();
		}
		return this.CurGamepadLogicController;
	}

	// Token: 0x0600EB52 RID: 60242 RVA: 0x003FE52F File Offset: 0x003FC72F
	[NullableContext(2)]
	public void SetGamepadLogic(HonamiStoryGamepadLogicController value)
	{
		this.CurGamepadLogicController = value;
	}

	// Token: 0x0600EB53 RID: 60243 RVA: 0x003FE538 File Offset: 0x003FC738
	public void SetMainTaskLoadingData(IHonamiStoryLoadingData data)
	{
		this.MainTaskParam = data;
	}

	// Token: 0x0600EB54 RID: 60244 RVA: 0x003FE541 File Offset: 0x003FC741
	public void SetGamePlayLoadingData(IHonamiStoryLoadingData data)
	{
		this.GamePlayParam = data;
	}

	// Token: 0x0600EB55 RID: 60245 RVA: 0x003FE54A File Offset: 0x003FC74A
	public void ClearCurLoadingData()
	{
		this.MainTaskParam = null;
		this.GamePlayParam = null;
	}

	// Token: 0x0600EB56 RID: 60246 RVA: 0x003FE55A File Offset: 0x003FC75A
	[NullableContext(2)]
	public IHonamiStoryLoadingData GetCurLoadingData()
	{
		return this.MainTaskParam ?? this.GamePlayParam;
	}

	// Token: 0x0600EB57 RID: 60247 RVA: 0x003FE56C File Offset: 0x003FC76C
	public EUiViewName? GetCurLoadViewName()
	{
		IHonamiStoryLoadingData curLoadingData = this.GetCurLoadingData();
		if (curLoadingData == null)
		{
			return null;
		}
		HonamiStoryLoadingPerform? honamiStoryLoadingPerform = null;
		bool flag = curLoadingData.LoadingId > 0;
		bool flag2 = curLoadingData.BtId > 0;
		bool flag3 = curLoadingData.Timing > 0;
		if (flag)
		{
			honamiStoryLoadingPerform = ConfigBase<HonamiStoryConfig>.Instance.GetLoadingPerformConfigById(curLoadingData.LoadingId.Value);
		}
		else if (flag3)
		{
			if (flag2)
			{
				honamiStoryLoadingPerform = ConfigBase<HonamiStoryConfig>.Instance.GetLoadingPerformConfigByBtAndTime(curLoadingData.BtId.Value, curLoadingData.Timing.Value);
			}
			else
			{
				IReadOnlyList<HonamiStoryLoadingPerform> loadingPerformConfigListByTiming = ConfigBase<HonamiStoryConfig>.Instance.GetLoadingPerformConfigListByTiming(curLoadingData.Timing.Value);
				if (loadingPerformConfigListByTiming.Count > 0)
				{
					honamiStoryLoadingPerform = new HonamiStoryLoadingPerform?(loadingPerformConfigListByTiming[0]);
				}
			}
		}
		if (honamiStoryLoadingPerform == null)
		{
			return null;
		}
		if (honamiStoryLoadingPerform.Value.PerformType == 5)
		{
			return new EUiViewName?(EUiViewName.HonamiStoryMainLoadingView);
		}
		return new EUiViewName?(EUiViewName.HonamiStoryLoadingView);
	}

	// Token: 0x04007120 RID: 28960
	public int ActivityId;

	// Token: 0x04007121 RID: 28961
	public HonamiStoryQuickEquipAllManager QuickAllManager = new HonamiStoryQuickEquipAllManager();

	// Token: 0x04007122 RID: 28962
	[Nullable(2)]
	protected HonamiStoryBackpackLogicController CurBackpackLogicController;

	// Token: 0x04007123 RID: 28963
	[Nullable(2)]
	private HonamiStoryGamepadLogicController CurGamepadLogicController;

	// Token: 0x04007124 RID: 28964
	protected List<IPickUpItemInfo> PickUpItemDataQueue = new List<IPickUpItemInfo>();

	// Token: 0x04007125 RID: 28965
	protected double PickUpTime;

	// Token: 0x04007126 RID: 28966
	protected bool IsPickingUp;

	// Token: 0x04007127 RID: 28967
	public HashSet<int> PickedEntityId = new HashSet<int>();

	// Token: 0x04007128 RID: 28968
	public readonly FRotator NormalRotation = global::Rotator.Create(0f, 0f, 0f).ToUeRotator();

	// Token: 0x04007129 RID: 28969
	public readonly FRotator TransRotation = global::Rotator.Create(0f, 90f, 0f).ToUeRotator();

	// Token: 0x0400712A RID: 28970
	protected bool IsLastPickUpViewDirty;

	// Token: 0x0400712B RID: 28971
	public bool CanSafeLeave;

	// Token: 0x0400712C RID: 28972
	public bool CacheShowSafeLeaveUpdate;

	// Token: 0x0400712D RID: 28973
	public int PollutionLevel;

	// Token: 0x0400712E RID: 28974
	public int PollutionMaxLevel;

	// Token: 0x0400712F RID: 28975
	public float PollutionStarTime;

	// Token: 0x04007130 RID: 28976
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, IHonamiStoryPollution> PollutionLevelMap;

	// Token: 0x04007131 RID: 28977
	public int PollutionWarningLevel;

	// Token: 0x04007132 RID: 28978
	public int PollutionDangerLevel;

	// Token: 0x04007133 RID: 28979
	public int MonsterBaseEnhanceLevel;

	// Token: 0x04007134 RID: 28980
	public int DangerLevel;

	// Token: 0x04007135 RID: 28981
	public int MonsterLevelSafeOffset;

	// Token: 0x04007136 RID: 28982
	public int MonsterLevelDangerOffset;

	// Token: 0x04007137 RID: 28983
	public int? ScanMarkId;

	// Token: 0x04007138 RID: 28984
	public HashSet<int> ScanMarkItemIds = new HashSet<int>();

	// Token: 0x04007139 RID: 28985
	public int CurrentUnlockFogId;

	// Token: 0x0400713A RID: 28986
	public int CurAreaId;

	// Token: 0x0400713B RID: 28987
	[Nullable(2)]
	private IHonamiStoryLoadingData MainTaskParam;

	// Token: 0x0400713C RID: 28988
	[Nullable(2)]
	private IHonamiStoryLoadingData GamePlayParam;

	// Token: 0x0400713D RID: 28989
	[Nullable(2)]
	private HonamiStoryActivityData ActivityData;

	// Token: 0x0400713E RID: 28990
	public HonamiStoryPlayerData PlayerData = HonamiStoryPlayerData.Create();

	// Token: 0x0400713F RID: 28991
	private HonamiStoryPlayerBackpackData PlayerBackpackData;

	// Token: 0x04007140 RID: 28992
	private readonly Dictionary<int, HonamiStoryWeaponData> WeaponDataMap = new Dictionary<int, HonamiStoryWeaponData>();

	// Token: 0x04007141 RID: 28993
	public int LastRecordRevenue;

	// Token: 0x04007142 RID: 28994
	private int TotalRevenueInternal;

	// Token: 0x04007143 RID: 28995
	[Nullable(2)]
	private HonamiStoryBackpackData WareHouseBackpackData;

	// Token: 0x04007144 RID: 28996
	private readonly Dictionary<int, HonamiStoryTechNodeData> TechNodeDataMap = new Dictionary<int, HonamiStoryTechNodeData>();

	// Token: 0x04007145 RID: 28997
	private readonly Dictionary<int, HonamiStoryTechAreaData> TechAreaDataMap = new Dictionary<int, HonamiStoryTechAreaData>();

	// Token: 0x04007146 RID: 28998
	[Nullable(2)]
	public HonamiStoryTechNodeData CurrentSelectNode;

	// Token: 0x04007147 RID: 28999
	[Nullable(2)]
	public HonamiStoryTechnologyNodeItem CurrentSelectNodeItem;

	// Token: 0x04007148 RID: 29000
	public Dictionary<int, int> RoleParentMap = new Dictionary<int, int>();

	// Token: 0x04007149 RID: 29001
	public Dictionary<int, HonamiStoryItemDataBase> ItemDataMap = new Dictionary<int, HonamiStoryItemDataBase>();

	// Token: 0x0400714A RID: 29002
	public Dictionary<int, CSharpScript.Game.Module.HonamiStory.Data.HonamiStoryWeaponSuitData> WeaponSuitMap = new Dictionary<int, CSharpScript.Game.Module.HonamiStory.Data.HonamiStoryWeaponSuitData>();

	// Token: 0x0400714B RID: 29003
	public int[] AddLevel = new int[]
	{
		-1,
		-1
	};

	// Token: 0x0400714C RID: 29004
	[Nullable(2)]
	public HonamiStoryQuestDataBase CurTrackTaskData;

	// Token: 0x0400714D RID: 29005
	private readonly Dictionary<EHonamiStoryQuestType, List<HonamiStoryQuestDataBase>> QuestDataMapCache = new Dictionary<EHonamiStoryQuestType, List<HonamiStoryQuestDataBase>>();

	// Token: 0x0400714E RID: 29006
	private readonly Dictionary<int, HonamiStoryBackpackData> BackpackDataMap = new Dictionary<int, HonamiStoryBackpackData>();

	// Token: 0x0400714F RID: 29007
	private readonly Comparison<HonamiStoryItemDataBase> NormalSort = delegate(HonamiStoryItemDataBase a, HonamiStoryItemDataBase b)
	{
		if (a.IsLock() != b.IsLock())
		{
			if (!a.IsLock())
			{
				return 1;
			}
			return -1;
		}
		else
		{
			int num = a.GetGridHeight() * a.GetGridWidth();
			int num2 = b.GetGridHeight() * b.GetGridWidth();
			if (num != num2)
			{
				return num2 - num;
			}
			if (a.GetSubType() != b.GetSubType())
			{
				return b.GetSubType() - a.GetSubType();
			}
			if (a.GetQuality() != b.GetQuality())
			{
				return b.GetQuality() - a.GetQuality();
			}
			if (a.GetItemId() != b.GetItemId())
			{
				return a.GetItemId() - b.GetItemId();
			}
			return a.GetIncId() - b.GetIncId();
		}
	};

	// Token: 0x04007150 RID: 29008
	private readonly Comparison<HonamiStoryItemDataBase> PluginSort = delegate(HonamiStoryItemDataBase a, HonamiStoryItemDataBase b)
	{
		if (a.IsLock() != b.IsLock())
		{
			if (!a.IsLock())
			{
				return 1;
			}
			return -1;
		}
		else
		{
			if (a.GetSubType() != b.GetSubType())
			{
				return b.GetSubType() - a.GetSubType();
			}
			if (a.GetQuality() != b.GetQuality())
			{
				return b.GetQuality() - a.GetQuality();
			}
			if (a.GetItemId() != b.GetItemId())
			{
				return a.GetItemId() - b.GetItemId();
			}
			return a.GetIncId() - b.GetIncId();
		}
	};
}
