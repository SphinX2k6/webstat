using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x02002351 RID: 9041
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RoleOrnamentModel : ModelBase<RoleOrnamentModel>
{
	// Token: 0x06011460 RID: 70752 RVA: 0x004BFD78 File Offset: 0x004BDF78
	protected override bool OnInit()
	{
		foreach (Ornament ornament in ConfigBase<RoleConfig>.Instance.GetAllOrnamentConfig())
		{
			foreach (int num in ornament.RoleSkinIdsIter())
			{
				List<int> list;
				if (!this.Skin2OrnamentMap.TryGetValue(num, out list))
				{
					list = new List<int>();
					this.Skin2OrnamentMap[num] = list;
				}
				list.Add(ornament.Id);
				int roleId = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(num).Value.RoleId;
				HashSet<int> hashSet;
				if (!this.Role2OrnamentMap.TryGetValue(roleId, out hashSet))
				{
					hashSet = new HashSet<int>();
					this.Role2OrnamentMap[roleId] = hashSet;
				}
				hashSet.Add(ornament.Id);
				if (ornament.DefaultOrnament)
				{
					HashSet<int> hashSet2;
					if (!this.Skin2DefaultOrnamentMap.TryGetValue(num, out hashSet2))
					{
						hashSet2 = new HashSet<int>();
						this.Skin2DefaultOrnamentMap[num] = hashSet2;
					}
					hashSet2.Add(ornament.Id);
					this.DefaultOrnamentSet.Add(ornament.Id);
				}
			}
		}
		return true;
	}

	// Token: 0x06011461 RID: 70753 RVA: 0x004BFEF8 File Offset: 0x004BE0F8
	protected override bool OnClear()
	{
		this.IsCommonItemFinished = false;
		this.PendingOrnamentIdsForInit = null;
		this.PendingOrnamentUnlockBatches.Clear();
		return true;
	}

	// Token: 0x06011462 RID: 70754 RVA: 0x004BFF14 File Offset: 0x004BE114
	public bool GetIsCommonItemFinished()
	{
		return this.IsCommonItemFinished;
	}

	// Token: 0x06011463 RID: 70755 RVA: 0x004BFF1C File Offset: 0x004BE11C
	public void SetCommonItemFinished()
	{
		this.IsCommonItemFinished = true;
	}

	// Token: 0x06011464 RID: 70756 RVA: 0x004BFF25 File Offset: 0x004BE125
	public void SetPendingOrnamentIdsForInit(int[] ornamentIds)
	{
		this.PendingOrnamentIdsForInit = ornamentIds;
	}

	// Token: 0x06011465 RID: 70757 RVA: 0x004BFF2E File Offset: 0x004BE12E
	[NullableContext(2)]
	public int[] TakePendingOrnamentIdsForInit()
	{
		int[] pendingOrnamentIdsForInit = this.PendingOrnamentIdsForInit;
		this.PendingOrnamentIdsForInit = null;
		return pendingOrnamentIdsForInit;
	}

	// Token: 0x06011466 RID: 70758 RVA: 0x004BFF3D File Offset: 0x004BE13D
	public void AddPendingOrnamentUnlockBatch(int[] ornamentIds)
	{
		this.PendingOrnamentUnlockBatches.Add(ornamentIds);
	}

	// Token: 0x06011467 RID: 70759 RVA: 0x004BFF4B File Offset: 0x004BE14B
	public List<int[]> TakeAllPendingOrnamentUnlockBatches()
	{
		List<int[]> result = new List<int[]>(this.PendingOrnamentUnlockBatches);
		this.PendingOrnamentUnlockBatches.Clear();
		return result;
	}

	// Token: 0x06011468 RID: 70760 RVA: 0x004BFF64 File Offset: 0x004BE164
	public void UpdateOwnOrnament(int[] ornamentIds)
	{
		foreach (int item in ornamentIds)
		{
			this.OwnOrnamentSet.Add(item);
		}
	}

	// Token: 0x06011469 RID: 70761 RVA: 0x004BFF94 File Offset: 0x004BE194
	public void UpdateWearOrnament(IEnumerable<OrnamentDressInfo> dressInfo)
	{
		foreach (OrnamentDressInfo ornamentDressInfo in dressInfo)
		{
			int roleSkinId = ornamentDressInfo.RoleSkinId;
			List<int> value = new List<int>(ornamentDressInfo.DressOrnamentIds);
			this.Skin2WearOrnamentMap[roleSkinId] = value;
		}
	}

	// Token: 0x0601146A RID: 70762 RVA: 0x004BFFF4 File Offset: 0x004BE1F4
	public void UpdateNewlyAddedOrnament(int[] ornamentIds)
	{
		foreach (int item in ornamentIds)
		{
			this.NewlyAddedOrnamentSet.Add(item);
		}
	}

	// Token: 0x0601146B RID: 70763 RVA: 0x004C0024 File Offset: 0x004BE224
	public int GetNormalizedOrnamentSkinId(int skinId)
	{
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(skinId);
		int num = roleSkinData.GetRoleId();
		if (!ModelBase<RoleModel>.Instance.IsMainRole(num))
		{
			return skinId;
		}
		int groupId = roleSkinData.GetRoleSkinConfig().GroupId;
		int id;
		if (this.MainRoleNormalizedSkinIdMap.TryGetValue(groupId, out id))
		{
			return id;
		}
		MainRoleConfig value = ConfigBase<RoleConfig>.Instance.GetMainRoleById(num).Value;
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("LightMainRoleIdList");
		num = ((value.Gender == 1) ? intArrayConfig[0] : intArrayConfig[1]);
		id = ConfigBase<SkinConfig>.Instance.GetSkinConfigByRoleIdAndGroupId(num, groupId).Value.Id;
		this.MainRoleNormalizedSkinIdMap[groupId] = id;
		return id;
	}

	// Token: 0x0601146C RID: 70764 RVA: 0x004C00E4 File Offset: 0x004BE2E4
	[NullableContext(2)]
	public RoleOrnamentData GetRoleOrnamentData(int id)
	{
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(id)) != InventoryDefine.EItemDataType.OrnamentItem)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleOrnament;
			ELogAuthor author = ELogAuthor.LJS;
			string message = "无效的饰品道具id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		RoleOrnamentData roleOrnamentData;
		if (!this.RoleOrnamentMap.TryGetValue(id, out roleOrnamentData))
		{
			roleOrnamentData = new RoleOrnamentData(id);
			this.RoleOrnamentMap[id] = roleOrnamentData;
		}
		return roleOrnamentData;
	}

	// Token: 0x0601146D RID: 70765 RVA: 0x004C015C File Offset: 0x004BE35C
	public List<int> GetSkinAllOrnaments(int id, bool? ownedFirst = null)
	{
		List<int> list;
		if (!this.Skin2OrnamentMap.TryGetValue(id, out list))
		{
			list = new List<int>();
		}
		List<int> list2 = new List<int>();
		foreach (int item in list)
		{
			if (!this.DefaultOrnamentSet.Contains(item))
			{
				list2.Add(item);
			}
		}
		if (ownedFirst.GetValueOrDefault())
		{
			list2.Sort(new Comparison<int>(this.SortOwnedFirst));
		}
		else
		{
			list2.Sort(new Comparison<int>(this.SortBySortIndex));
		}
		return list2;
	}

	// Token: 0x0601146E RID: 70766 RVA: 0x004C0204 File Offset: 0x004BE404
	public List<int> GetSkinAllWearingOrnaments(int id, bool includeDefault = true)
	{
		int normalizedOrnamentSkinId = this.GetNormalizedOrnamentSkinId(id);
		List<int> list;
		if (!this.Skin2WearOrnamentMap.TryGetValue(normalizedOrnamentSkinId, out list))
		{
			list = new List<int>();
		}
		if (!includeDefault)
		{
			return list;
		}
		return this.MergeDefaultOrnaments(list, id);
	}

	// Token: 0x0601146F RID: 70767 RVA: 0x004C023C File Offset: 0x004BE43C
	public List<int> MergeDefaultOrnaments(List<int> serverWearList, int skinId)
	{
		HashSet<int> hashSet;
		if (!this.Skin2DefaultOrnamentMap.TryGetValue(skinId, out hashSet) || hashSet.Count == 0)
		{
			return serverWearList;
		}
		HashSet<int> hashSet2 = new HashSet<int>();
		foreach (int id in serverWearList)
		{
			Ornament? ornamentConfig = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(id);
			bool flag;
			if (ornamentConfig == null)
			{
				flag = false;
			}
			else
			{
				int orGroupId = ornamentConfig.GetValueOrDefault().OrGroupId;
				flag = true;
			}
			if (flag)
			{
				hashSet2.Add(ornamentConfig.Value.OrGroupId);
			}
		}
		List<int> list = new List<int>(serverWearList);
		foreach (int num in hashSet)
		{
			Ornament? ornamentConfig2 = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(num);
			bool flag2;
			if (ornamentConfig2 == null)
			{
				flag2 = true;
			}
			else
			{
				int orGroupId2 = ornamentConfig2.GetValueOrDefault().OrGroupId;
				flag2 = false;
			}
			if (flag2 || !hashSet2.Contains(ornamentConfig2.Value.OrGroupId))
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x06011470 RID: 70768 RVA: 0x004C0378 File Offset: 0x004BE578
	public List<int> GetRoleSkinAllWearingOrnaments(int roleId, int skinId)
	{
		if (!RoleUtils.IsTrialRole(roleId))
		{
			return this.GetSkinAllWearingOrnaments(skinId, true);
		}
		HashSet<int> collection;
		if (this.Skin2DefaultOrnamentMap.TryGetValue(skinId, out collection))
		{
			return new List<int>(collection);
		}
		return new List<int>();
	}

	// Token: 0x06011471 RID: 70769 RVA: 0x004C03B2 File Offset: 0x004BE5B2
	public int GetOrnamentCountById(int ornamentId)
	{
		return (this.IsOwnOrnament(ornamentId) > false) ? 1 : 0;
	}

	// Token: 0x06011472 RID: 70770 RVA: 0x004C03BE File Offset: 0x004BE5BE
	public bool IsOwnOrnament(int ornamentId)
	{
		return this.OwnOrnamentSet.Contains(ornamentId) || this.DefaultOrnamentSet.Contains(ornamentId);
	}

	// Token: 0x06011473 RID: 70771 RVA: 0x004C03DC File Offset: 0x004BE5DC
	public bool IsDefaultOrnament(int ornamentId)
	{
		return this.DefaultOrnamentSet.Contains(ornamentId);
	}

	// Token: 0x06011474 RID: 70772 RVA: 0x004C03EC File Offset: 0x004BE5EC
	public bool IsOrnamentConflictOnSkin(int ornamentId, int skinId, bool includeDefault = true)
	{
		RoleOrnamentData roleOrnamentData = this.GetRoleOrnamentData(ornamentId);
		if (roleOrnamentData == null)
		{
			return false;
		}
		int groupId = roleOrnamentData.GetGroupId();
		if (groupId == 0)
		{
			return false;
		}
		foreach (int id in this.GetSkinAllWearingOrnaments(skinId, includeDefault))
		{
			RoleOrnamentData roleOrnamentData2 = this.GetRoleOrnamentData(id);
			if (roleOrnamentData2 != null && roleOrnamentData2.GetGroupId() == groupId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011475 RID: 70773 RVA: 0x004C0474 File Offset: 0x004BE674
	public List<int> GetConflictOrnamentsOnSkin(int ornamentId, int skinId, bool includeDefault = true)
	{
		RoleOrnamentData roleOrnamentData = this.GetRoleOrnamentData(ornamentId);
		if (roleOrnamentData == null)
		{
			return new List<int>();
		}
		int groupId = roleOrnamentData.GetGroupId();
		if (groupId == 0)
		{
			return new List<int>();
		}
		List<int> skinAllWearingOrnaments = this.GetSkinAllWearingOrnaments(skinId, includeDefault);
		List<int> list = new List<int>();
		foreach (int num in skinAllWearingOrnaments)
		{
			RoleOrnamentData roleOrnamentData2 = this.GetRoleOrnamentData(num);
			if (roleOrnamentData2 != null && roleOrnamentData2.GetGroupId() == groupId)
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x06011476 RID: 70774 RVA: 0x004C050C File Offset: 0x004BE70C
	public bool IsSkinWearingOrnament(int ornamentId, int skinId, bool includeDefault = true)
	{
		return this.GetSkinAllWearingOrnaments(skinId, includeDefault).Contains(ornamentId);
	}

	// Token: 0x06011477 RID: 70775 RVA: 0x004C051C File Offset: 0x004BE71C
	private int SortBySortIndex(int a, int b)
	{
		Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(a).Value;
		Ornament value2 = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(b).Value;
		return value.SortIndex - value2.SortIndex;
	}

	// Token: 0x06011478 RID: 70776 RVA: 0x004C0560 File Offset: 0x004BE760
	private int SortOwnedFirst(int a, int b)
	{
		bool flag = this.IsOwnOrnament(a);
		bool flag2 = this.IsOwnOrnament(b);
		if (flag == flag2)
		{
			Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(a).Value;
			Ornament value2 = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(b).Value;
			return value.SortIndex - value2.SortIndex;
		}
		if (!flag)
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x06011479 RID: 70777 RVA: 0x004C05C4 File Offset: 0x004BE7C4
	public List<int> GetWearPreviewOrnamentResult(int ornamentId, int skinId)
	{
		List<int> skinAllWearingOrnaments = this.GetSkinAllWearingOrnaments(skinId, true);
		if (this.IsSkinWearingOrnament(ornamentId, skinId, true))
		{
			return skinAllWearingOrnaments;
		}
		HashSet<int> hashSet = new HashSet<int>(this.GetConflictOrnamentsOnSkin(ornamentId, skinId, true));
		List<int> list = new List<int>();
		foreach (int item in skinAllWearingOrnaments)
		{
			if (!hashSet.Contains(item))
			{
				list.Add(item);
			}
		}
		list.Add(ornamentId);
		return list;
	}

	// Token: 0x0601147A RID: 70778 RVA: 0x004C0654 File Offset: 0x004BE854
	private ServerStorageSet GetNewlyViewedOrnamentStorageData()
	{
		return ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.Ornament) as ServerStorageSet;
	}

	// Token: 0x0601147B RID: 70779 RVA: 0x004C0667 File Offset: 0x004BE867
	public bool IsOrnamentNewlyAdded(int ornamentId)
	{
		return this.NewlyAddedOrnamentSet.Contains(ornamentId) && !this.GetNewlyViewedOrnamentStorageData().Has(ornamentId);
	}

	// Token: 0x0601147C RID: 70780 RVA: 0x004C0688 File Offset: 0x004BE888
	public bool CheckNewlyAddedOrnamentHasRedDotByRoleId(int roleId)
	{
		if (!ModelBase<RoleModel>.Instance.IsRoleOwned(roleId))
		{
			return false;
		}
		HashSet<int> hashSet;
		if (!this.Role2OrnamentMap.TryGetValue(roleId, out hashSet) || hashSet.Count == 0)
		{
			return false;
		}
		foreach (int ornamentId in hashSet)
		{
			if (this.IsOrnamentNewlyAdded(ornamentId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601147D RID: 70781 RVA: 0x004C0708 File Offset: 0x004BE908
	public void SetOrnamentNewlyViewed(int ornamentId)
	{
		ServerStorageSet newlyViewedOrnamentStorageData = this.GetNewlyViewedOrnamentStorageData();
		HashSet<int> hashSet = new HashSet<int>(newlyViewedOrnamentStorageData.GetContainer());
		hashSet.Add(ornamentId);
		List<int> list = new List<int>();
		foreach (int item in hashSet)
		{
			if (!this.NewlyAddedOrnamentSet.Contains(item))
			{
				list.Add(item);
			}
		}
		foreach (int item2 in list)
		{
			hashSet.Remove(item2);
		}
		HashSet<int> container = newlyViewedOrnamentStorageData.GetContainer();
		container.Clear();
		foreach (int item3 in hashSet)
		{
			container.Add(item3);
		}
		newlyViewedOrnamentStorageData.MarkDirty();
		this.NotifyRoleOrnamentRedDotRefresh(ornamentId);
	}

	// Token: 0x0601147E RID: 70782 RVA: 0x004C0828 File Offset: 0x004BEA28
	private ServerStorageSet GetNewlyAcquiredOrnamentStorageData()
	{
		return ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.GetOrnament) as ServerStorageSet;
	}

	// Token: 0x0601147F RID: 70783 RVA: 0x004C083B File Offset: 0x004BEA3B
	public bool IsOrnamentNewlyAcquired(int ornamentId)
	{
		return this.GetNewlyAcquiredOrnamentStorageData().Has(ornamentId);
	}

	// Token: 0x06011480 RID: 70784 RVA: 0x004C084C File Offset: 0x004BEA4C
	public void SetOrnamentNewlyAcquired(int ornamentId, bool value)
	{
		ServerStorageSet newlyAcquiredOrnamentStorageData = this.GetNewlyAcquiredOrnamentStorageData();
		if (value)
		{
			newlyAcquiredOrnamentStorageData.Add(ornamentId);
		}
		else
		{
			newlyAcquiredOrnamentStorageData.Remove(ornamentId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.MainViewRoleButtonRefreshByRoleOrnament);
		this.NotifyRoleOrnamentRedDotRefresh(ornamentId);
	}

	// Token: 0x06011481 RID: 70785 RVA: 0x004C088C File Offset: 0x004BEA8C
	public bool CheckNewlyAcquiredOrnamentHasRedDotByRoleId(int roleId)
	{
		if (!ModelBase<RoleModel>.Instance.IsRoleOwned(roleId))
		{
			return false;
		}
		HashSet<int> hashSet;
		if (!this.Role2OrnamentMap.TryGetValue(roleId, out hashSet) || hashSet.Count == 0)
		{
			return false;
		}
		foreach (int ornamentId in hashSet)
		{
			if (this.IsOrnamentNewlyAcquired(ornamentId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011482 RID: 70786 RVA: 0x004C090C File Offset: 0x004BEB0C
	public bool CheckNewlyAcquiredOrnamentInMainView()
	{
		ServerStorageSet newlyAcquiredOrnamentStorageData = this.GetNewlyAcquiredOrnamentStorageData();
		if (newlyAcquiredOrnamentStorageData.Size() == 0)
		{
			return false;
		}
		foreach (int id in newlyAcquiredOrnamentStorageData.GetContainer())
		{
			Ornament? ornamentConfig = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(id);
			if (ornamentConfig != null)
			{
				foreach (int itemId in ornamentConfig.Value.RoleSkinIdsIter())
				{
					RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(itemId);
					if (roleSkinConfig != null && ModelBase<RoleModel>.Instance.IsRoleOwned(roleSkinConfig.Value.RoleId))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06011483 RID: 70787 RVA: 0x004C0A08 File Offset: 0x004BEC08
	private void NotifyRoleOrnamentRedDotRefresh(int ornamentId)
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OrnamentRedDotRefresh, ornamentId);
		HashSet<int> hashSet = new HashSet<int>();
		foreach (int itemId in ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(ornamentId).Value.RoleSkinIdsIter())
		{
			hashSet.Add(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(itemId).Value.RoleId);
		}
		foreach (int p in hashSet)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleOrnamentRedDotRefresh, p);
		}
	}

	// Token: 0x040087A3 RID: 34723
	private readonly Dictionary<int, RoleOrnamentData> RoleOrnamentMap = new Dictionary<int, RoleOrnamentData>();

	// Token: 0x040087A4 RID: 34724
	private readonly Dictionary<int, List<int>> Skin2WearOrnamentMap = new Dictionary<int, List<int>>();

	// Token: 0x040087A5 RID: 34725
	private readonly Dictionary<int, List<int>> Skin2OrnamentMap = new Dictionary<int, List<int>>();

	// Token: 0x040087A6 RID: 34726
	private readonly HashSet<int> OwnOrnamentSet = new HashSet<int>();

	// Token: 0x040087A7 RID: 34727
	private readonly Dictionary<int, int> MainRoleNormalizedSkinIdMap = new Dictionary<int, int>();

	// Token: 0x040087A8 RID: 34728
	private readonly Dictionary<int, HashSet<int>> Role2OrnamentMap = new Dictionary<int, HashSet<int>>();

	// Token: 0x040087A9 RID: 34729
	private readonly Dictionary<int, HashSet<int>> Skin2DefaultOrnamentMap = new Dictionary<int, HashSet<int>>();

	// Token: 0x040087AA RID: 34730
	private readonly HashSet<int> DefaultOrnamentSet = new HashSet<int>();

	// Token: 0x040087AB RID: 34731
	private readonly HashSet<int> NewlyAddedOrnamentSet = new HashSet<int>();

	// Token: 0x040087AC RID: 34732
	private bool IsCommonItemFinished;

	// Token: 0x040087AD RID: 34733
	[Nullable(2)]
	private int[] PendingOrnamentIdsForInit;

	// Token: 0x040087AE RID: 34734
	private readonly List<int[]> PendingOrnamentUnlockBatches = new List<int[]>();
}
