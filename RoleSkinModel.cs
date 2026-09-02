using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;

// Token: 0x02002A34 RID: 10804
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RoleSkinModel : ModelBase<RoleSkinModel>
{
	// Token: 0x060159B3 RID: 88499 RVA: 0x005FD89C File Offset: 0x005FBA9C
	public void UpdateUnlockRoleSkin(List<int> itemIdList)
	{
		foreach (int itemId in itemIdList)
		{
			RoleSkinData roleSkinData = this.GetRoleSkinData(itemId);
			if (roleSkinData != null)
			{
				roleSkinData.UnlockSkin();
			}
		}
	}

	// Token: 0x060159B4 RID: 88500 RVA: 0x005FD8F4 File Offset: 0x005FBAF4
	public void UpdateUnlockRoleSkinDataFull(List<int> itemIdList)
	{
		foreach (RoleSkinData roleSkinData in this.RoleSkinMap.Values)
		{
			roleSkinData.LockSkin();
		}
		foreach (int itemId in itemIdList)
		{
			RoleSkinData roleSkinData2 = this.GetRoleSkinData(itemId);
			if (roleSkinData2 != null)
			{
				roleSkinData2.UnlockSkin();
			}
		}
	}

	// Token: 0x060159B5 RID: 88501 RVA: 0x005FD990 File Offset: 0x005FBB90
	public void UpdateWeaponSkinFirstWearRecord(List<int> itemIdList)
	{
		foreach (int itemId in itemIdList)
		{
			RoleSkinData roleSkinData = this.GetRoleSkinData(itemId);
			if (roleSkinData != null)
			{
				int suitWeaponSkinId = roleSkinData.GetRoleSkinConfig().SuitWeaponSkinId;
				if (suitWeaponSkinId > 0)
				{
					this.RecordSuitWeaponFirstWear(suitWeaponSkinId, true);
				}
			}
		}
	}

	// Token: 0x060159B6 RID: 88502 RVA: 0x005FDA00 File Offset: 0x005FBC00
	public void AddRoleSkinNewFlag(List<int> itemIdList)
	{
		foreach (int num in itemIdList)
		{
			RoleSkinData roleSkinData = this.GetRoleSkinData(num);
			if (roleSkinData != null && !roleSkinData.IsOriginalSkin())
			{
				ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.RoleSkinRedDot, num);
				ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.RoleSkinRedDot);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSkinRedDotRefresh, roleSkinData.GetRoleId());
				Singleton<EventSystem>.Instance.Emit(EEventName.MainViewRoleButtonRefreshByRoleSkin);
			}
		}
	}

	// Token: 0x060159B7 RID: 88503 RVA: 0x005FDA9C File Offset: 0x005FBC9C
	[NullableContext(2)]
	public unsafe RoleSkinData GetRoleSkinData(int itemId)
	{
		RoleSkinData result;
		if (this.RoleSkinMap.TryGetValue(itemId, out result))
		{
			return result;
		}
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId));
		if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.RoleSkinItem)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleSkin;
			ELogAuthor author = ELogAuthor.BB;
			string message = "无效的皮肤道具id";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("itemId", itemId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("itemType", itemDataTypeByConfigId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		RoleSkinData roleSkinData = new RoleSkinData(itemId);
		this.RoleSkinMap[itemId] = roleSkinData;
		return roleSkinData;
	}

	// Token: 0x060159B8 RID: 88504 RVA: 0x005FDB48 File Offset: 0x005FBD48
	[NullableContext(2)]
	public RoleSkinData GetRoleSkinDataByRoleId(int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById == null)
		{
			return null;
		}
		int roleSkinId = roleDataById.GetRoleSkinId();
		return this.GetRoleSkinData(roleSkinId);
	}

	// Token: 0x060159B9 RID: 88505 RVA: 0x005FDB78 File Offset: 0x005FBD78
	[NullableContext(2)]
	public RoleSkinData GetRoleOriginalSkinData(int roleId, bool ifSelf = true)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, ifSelf);
		if (roleDataById == null)
		{
			return null;
		}
		int skinId = roleDataById.GetRoleConfig().SkinId;
		return this.GetRoleSkinData(skinId);
	}

	// Token: 0x060159BA RID: 88506 RVA: 0x005FDBB0 File Offset: 0x005FBDB0
	public int GetRoleSkinIdByRoleId(int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById == null)
		{
			return -1;
		}
		return roleDataById.GetRoleSkinId();
	}

	// Token: 0x060159BB RID: 88507 RVA: 0x005FDBD8 File Offset: 0x005FBDD8
	public bool CheckHasRoleSkin(int itemId)
	{
		RoleSkinData roleSkinData = this.GetRoleSkinData(itemId);
		return roleSkinData != null && roleSkinData.IsLocked();
	}

	// Token: 0x060159BC RID: 88508 RVA: 0x005FDBF8 File Offset: 0x005FBDF8
	public void UnlockSkin(int itemId)
	{
		RoleSkinData roleSkinData = this.GetRoleSkinData(itemId);
		if (roleSkinData == null)
		{
			return;
		}
		roleSkinData.UnlockSkin();
	}

	// Token: 0x060159BD RID: 88509 RVA: 0x005FDC18 File Offset: 0x005FBE18
	public int GetSkinCountById(int itemId)
	{
		RoleSkinData roleSkinData = this.GetRoleSkinData(itemId);
		if (roleSkinData == null)
		{
			return -1;
		}
		return roleSkinData.GetItemCount();
	}

	// Token: 0x060159BE RID: 88510 RVA: 0x005FDC38 File Offset: 0x005FBE38
	public List<UiDynamicTab> GetSkinTabList(bool isMainRole, int roleId)
	{
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.SkinRootView);
		int count = viewTabList.Count;
		List<UiDynamicTab> list = new List<UiDynamicTab>();
		for (int i = 0; i < count; i++)
		{
			UiDynamicTab item = viewTabList[i];
			if (ModelBase<FunctionModel>.Instance.IsOpen(item.FunctionId) && (!(item.ChildViewName == EUiTabViewName.CalabashSkinTabView) || isMainRole) && (!(item.ChildViewName == EUiTabViewName.RoleOrnamentTabView) || this.CanShowOrnamentTab(roleId)))
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x060159BF RID: 88511 RVA: 0x005FDCD4 File Offset: 0x005FBED4
	private bool CanShowOrnamentTab(int roleId)
	{
		IReadOnlyList<RoleSkin> roleSkinConfigList = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfigList(roleId);
		if (roleSkinConfigList == null)
		{
			return false;
		}
		foreach (RoleSkin roleSkin in roleSkinConfigList)
		{
			if (ModelBase<RoleOrnamentModel>.Instance.GetSkinAllOrnaments(roleSkin.Id, null).Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060159C0 RID: 88512 RVA: 0x005FDD54 File Offset: 0x005FBF54
	public List<RoleSkinData> GetRoleSkinDataList(int roleId)
	{
		IReadOnlyList<RoleSkin> roleSkinConfigList = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfigList(roleId);
		if (roleSkinConfigList == null)
		{
			return new List<RoleSkinData>();
		}
		List<RoleSkinData> list = new List<RoleSkinData>();
		foreach (RoleSkin roleSkin in roleSkinConfigList)
		{
			RoleSkinData roleSkinData = this.GetRoleSkinData(roleSkin.Id);
			if (roleSkinData != null)
			{
				list.Add(roleSkinData);
			}
		}
		list.Sort(delegate(RoleSkinData a, RoleSkinData b)
		{
			int sortIndex = a.GetRoleSkinConfig().SortIndex;
			int sortIndex2 = b.GetRoleSkinConfig().SortIndex;
			return sortIndex - sortIndex2;
		});
		return list;
	}

	// Token: 0x060159C1 RID: 88513 RVA: 0x005FDDF4 File Offset: 0x005FBFF4
	public bool HasRoleSkinRedDotByRoleId(int roleId)
	{
		foreach (RoleSkinData roleSkinData in this.GetRoleSkinDataList(roleId))
		{
			RoleSkinData roleSkinData2 = this.GetRoleSkinData(roleSkinData.GetItemId());
			if (roleSkinData2 != null && !roleSkinData2.IsLocked() && ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoleSkinRedDot, roleSkinData.GetItemId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060159C2 RID: 88514 RVA: 0x005FDE74 File Offset: 0x005FC074
	public bool CheckSuitWeaponFirstWear(int weaponSkinId)
	{
		this.TryLocalOverrideToServerStorage();
		return (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.SuitWeaponFirstWearRecord) as ServerStorageSet).Has(weaponSkinId);
	}

	// Token: 0x060159C3 RID: 88515 RVA: 0x005FDE94 File Offset: 0x005FC094
	private void TryLocalOverrideToServerStorage()
	{
		if (this.HasOverrideServerStorage)
		{
			return;
		}
		this.HasOverrideServerStorage = true;
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.SuitWeaponFirstWearRecord, null);
		if (player == null)
		{
			return;
		}
		ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.SuitWeaponFirstWearRecord) as ServerStorageSet;
		foreach (KeyValuePair<int, bool> keyValuePair in player)
		{
			int num;
			bool flag;
			keyValuePair.Deconstruct(out num, out flag);
			int value = num;
			if (flag)
			{
				serverStorageSet.Add(value);
			}
		}
	}

	// Token: 0x060159C4 RID: 88516 RVA: 0x005FDF24 File Offset: 0x005FC124
	public void RecordSuitWeaponFirstWear(int weaponSkinId, bool isFirstWear)
	{
		this.TryLocalOverrideToServerStorage();
		ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.SuitWeaponFirstWearRecord) as ServerStorageSet;
		if (isFirstWear)
		{
			serverStorageSet.Add(weaponSkinId);
		}
		else
		{
			serverStorageSet.Remove(weaponSkinId);
		}
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.SuitWeaponFirstWearRecord, null) ?? new Dictionary<int, bool>();
		dictionary[weaponSkinId] = isFirstWear;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.SuitWeaponFirstWearRecord, dictionary);
	}

	// Token: 0x0400A626 RID: 42534
	private readonly Dictionary<int, RoleSkinData> RoleSkinMap = new Dictionary<int, RoleSkinData>();

	// Token: 0x0400A627 RID: 42535
	private bool HasOverrideServerStorage;
}
