using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x02002329 RID: 9001
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class NewFlagModel : ModelBase<NewFlagModel>
{
	// Token: 0x060111F1 RID: 70129 RVA: 0x004B428D File Offset: 0x004B248D
	protected override bool OnInit()
	{
		this.OnAddEvents();
		return true;
	}

	// Token: 0x060111F2 RID: 70130 RVA: 0x004B4296 File Offset: 0x004B2496
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		return true;
	}

	// Token: 0x060111F3 RID: 70131 RVA: 0x004B429F File Offset: 0x004B249F
	protected void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGetPlayerBasicInfo, new Action(this.LoadNewFlagConfig));
		Singleton<EventSystem>.Instance.Add(EEventName.LogOut, new Action(this.ClearNewFlag));
	}

	// Token: 0x060111F4 RID: 70132 RVA: 0x004B42D9 File Offset: 0x004B24D9
	protected void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGetPlayerBasicInfo, new Action(this.LoadNewFlagConfig));
		Singleton<EventSystem>.Instance.Remove(EEventName.LogOut, new Action(this.ClearNewFlag));
	}

	// Token: 0x060111F5 RID: 70133 RVA: 0x004B4314 File Offset: 0x004B2514
	public void LoadNewFlagConfig()
	{
		foreach (ELocalStoragePlayerKey key in this.NewFlagLocalStoragePlayerKeyList)
		{
			List<int> player = LocalStorage.GetPlayer<List<int>>(key, null);
			HashSet<int> value = (player != null) ? new HashSet<int>(player) : new HashSet<int>();
			this.NewFlagMap[key] = value;
			this.FlagDirtyMap[key] = false;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnLoadedNewFlagConfig);
	}

	// Token: 0x060111F6 RID: 70134 RVA: 0x004B43A4 File Offset: 0x004B25A4
	public void ClearNewFlag()
	{
		this.NewFlagMap.Clear();
		this.TempArray.Clear();
		this.FlagDirtyMap.Clear();
	}

	// Token: 0x060111F7 RID: 70135 RVA: 0x004B43C8 File Offset: 0x004B25C8
	public bool SaveNewFlagConfig(ELocalStoragePlayerKey key)
	{
		HashSet<int> collection;
		if (!this.NewFlagMap.TryGetValue(key, out collection))
		{
			return false;
		}
		EClientStorageSystemIdType eclientStorageSystemIdType;
		if (this.localToServerStorageKey.TryGetValue(key, out eclientStorageSystemIdType))
		{
			return true;
		}
		bool flag;
		if (!this.FlagDirtyMap.TryGetValue(key, out flag) || !flag)
		{
			return false;
		}
		this.TempArray.Clear();
		this.TempArray.AddRange(collection);
		this.FlagDirtyMap[key] = false;
		return LocalStorage.SetPlayer<List<int>>(key, this.TempArray);
	}

	// Token: 0x060111F8 RID: 70136 RVA: 0x004B4440 File Offset: 0x004B2640
	public bool AddNewFlag(ELocalStoragePlayerKey key, int value)
	{
		HashSet<int> hashSet;
		if (!this.NewFlagMap.TryGetValue(key, out hashSet))
		{
			return false;
		}
		EClientStorageSystemIdType key2;
		if (this.localToServerStorageKey.TryGetValue(key, out key2))
		{
			(ModelBase<ServerStorageModel>.Instance.Get(key2) as ServerStorageSet).Add(value);
		}
		else
		{
			hashSet.Add(value);
			this.FlagDirtyMap[key] = true;
		}
		return true;
	}

	// Token: 0x060111F9 RID: 70137 RVA: 0x004B44A0 File Offset: 0x004B26A0
	public bool RemoveNewFlag(ELocalStoragePlayerKey key, int value)
	{
		HashSet<int> hashSet;
		if (!this.NewFlagMap.TryGetValue(key, out hashSet))
		{
			return false;
		}
		EClientStorageSystemIdType key2;
		if (this.localToServerStorageKey.TryGetValue(key, out key2))
		{
			(ModelBase<ServerStorageModel>.Instance.Get(key2) as ServerStorageSet).Remove(value);
			return true;
		}
		bool flag = hashSet.Remove(value);
		bool flag2 = this.FlagDirtyMap[key];
		this.FlagDirtyMap[key] = (flag || flag2);
		return flag;
	}

	// Token: 0x060111FA RID: 70138 RVA: 0x004B4510 File Offset: 0x004B2710
	public bool HasNewFlag(ELocalStoragePlayerKey key, int value)
	{
		EClientStorageSystemIdType key2;
		if (this.localToServerStorageKey.TryGetValue(key, out key2))
		{
			return (ModelBase<ServerStorageModel>.Instance.Get(key2) as ServerStorageSet).Has(value);
		}
		HashSet<int> hashSet;
		return this.NewFlagMap.TryGetValue(key, out hashSet) && hashSet.Contains(value);
	}

	// Token: 0x060111FB RID: 70139 RVA: 0x004B4560 File Offset: 0x004B2760
	[NullableContext(2)]
	[Obsolete("该接口仅为条件检测使用，之后条件检测修改获取数据方式后，该接口废除，不让外部获取")]
	public HashSet<int> GetNewFlagSet(ELocalStoragePlayerKey key)
	{
		HashSet<int> result;
		this.NewFlagMap.TryGetValue(key, out result);
		return result;
	}

	// Token: 0x0400869B RID: 34459
	private readonly Dictionary<ELocalStoragePlayerKey, HashSet<int>> NewFlagMap = new Dictionary<ELocalStoragePlayerKey, HashSet<int>>();

	// Token: 0x0400869C RID: 34460
	private readonly List<int> TempArray = new List<int>();

	// Token: 0x0400869D RID: 34461
	private readonly Dictionary<ELocalStoragePlayerKey, bool> FlagDirtyMap = new Dictionary<ELocalStoragePlayerKey, bool>();

	// Token: 0x0400869E RID: 34462
	private List<ELocalStoragePlayerKey> NewFlagLocalStoragePlayerKeyList = new List<ELocalStoragePlayerKey>
	{
		ELocalStoragePlayerKey.ComposeLevelKey,
		ELocalStoragePlayerKey.CookerLevelKey,
		ELocalStoragePlayerKey.ForgingLevelKey,
		ELocalStoragePlayerKey.FlySkinRedDot,
		ELocalStoragePlayerKey.InventoryAttributeItem,
		ELocalStoragePlayerKey.InventoryCommonItem,
		ELocalStoragePlayerKey.InventoryAttributeItemRedDot,
		ELocalStoragePlayerKey.InventoryCommonItemRedDot,
		ELocalStoragePlayerKey.MoonChasingShopItemUnlock,
		ELocalStoragePlayerKey.MoonChasingShopItemChecked,
		ELocalStoragePlayerKey.MoonChasingRoleUnlock,
		ELocalStoragePlayerKey.MoonChasingQuestUnlock,
		ELocalStoragePlayerKey.PersonalDataItem,
		ELocalStoragePlayerKey.RoleDataItem,
		ELocalStoragePlayerKey.RouletteAssemblyItemRedDot,
		ELocalStoragePlayerKey.VisionSkin,
		ELocalStoragePlayerKey.WeaponSkinRedDot,
		ELocalStoragePlayerKey.RoleSkinRedDot,
		ELocalStoragePlayerKey.DockyardListItemRead,
		ELocalStoragePlayerKey.PayShopTabItemChecked,
		ELocalStoragePlayerKey.RoguelikeShopItemChecked,
		ELocalStoragePlayerKey.FishingHandBookItemRecord,
		ELocalStoragePlayerKey.FishingShipSkinRecord,
		ELocalStoragePlayerKey.CalabashSkinRedDot
	};

	// Token: 0x0400869F RID: 34463
	private readonly Dictionary<ELocalStoragePlayerKey, EClientStorageSystemIdType> localToServerStorageKey = new Dictionary<ELocalStoragePlayerKey, EClientStorageSystemIdType>
	{
		{
			ELocalStoragePlayerKey.CalabashSkinRedDot,
			EClientStorageSystemIdType.CalabashSkinRedDot
		},
		{
			ELocalStoragePlayerKey.FlySkinRedDot,
			EClientStorageSystemIdType.FlySkinRedDot
		},
		{
			ELocalStoragePlayerKey.VisionSkin,
			EClientStorageSystemIdType.VisionSkin
		},
		{
			ELocalStoragePlayerKey.RoleSkinRedDot,
			EClientStorageSystemIdType.RoleSkinRedDot
		},
		{
			ELocalStoragePlayerKey.WeaponSkinRedDot,
			EClientStorageSystemIdType.WeaponSkinRedDot
		}
	};
}
