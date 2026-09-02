using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001E6F RID: 7791
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class HandBookModel : ModelBase<HandBookModel>
{
	// Token: 0x0600E65C RID: 58972 RVA: 0x003E2962 File Offset: 0x003E0B62
	public HandBookModel()
	{
		this.HandBookActiveStateMap = new Dictionary<EHandBookTabType, List<HandBookEntry>>();
		this.HandBookRedDotList = new List<EHandBookTabType>();
		this.AnimalConfigMap = new Dictionary<int, AnimalHandBook>();
		this.RoleOpenTimeLockMap = new Dictionary<int, bool>();
		this.WeaponOpenTimeLockMap = new Dictionary<int, bool>();
	}

	// Token: 0x0600E65D RID: 58973 RVA: 0x003E29A4 File Offset: 0x003E0BA4
	public void UpdateHandBookActiveStateMap(IllustratedType type, IllustratedEntry entry)
	{
		EHandBookTabType clientHandBookType = this.GetClientHandBookType(type, new PhotographSubType?(entry.PhotographSubType));
		int id = entry.Id;
		DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)((ulong)entry.CreateTime * (ulong)((long)Singleton<TimeUtil>.Instance.InverseMillisecond))).LocalDateTime;
		string createTime = Singleton<TimeUtil>.Instance.DateFormat4(localDateTime);
		bool isRead = entry.IsRead;
		int num = entry.Num;
		HandBookEntry handBookEntry = new HandBookEntry(id, createTime, num, isRead, entry.CreateTime);
		List<HandBookEntry> list;
		if (!this.HandBookActiveStateMap.TryGetValue(clientHandBookType, out list))
		{
			List<HandBookEntry> list2 = new List<HandBookEntry>();
			list2.Add(handBookEntry);
			this.HandBookActiveStateMap[clientHandBookType] = list2;
		}
		else
		{
			int count = list.Count;
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				HandBookEntry handBookEntry2 = list[i];
				if (handBookEntry2.Id == handBookEntry.Id)
				{
					handBookEntry2.CreateTime = handBookEntry.CreateTime;
					handBookEntry2.CreateTimeStampSecond = handBookEntry.CreateTimeStampSecond;
					handBookEntry2.IsRead = handBookEntry.IsRead;
					handBookEntry2.Num = handBookEntry.Num;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(handBookEntry);
			}
		}
		Singleton<EventSystem>.Instance.Emit<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, clientHandBookType, entry.Id);
	}

	// Token: 0x0600E65E RID: 58974 RVA: 0x003E2AE4 File Offset: 0x003E0CE4
	public void ClearHandBookActiveStateMap()
	{
		this.HandBookActiveStateMap.Clear();
	}

	// Token: 0x0600E65F RID: 58975 RVA: 0x003E2AF4 File Offset: 0x003E0CF4
	public void InitHandBookActiveStateMap(IllustratedType type, IllustratedEntry[] entryList)
	{
		List<HandBookEntry> clientHandBookEntryList = this.GetClientHandBookEntryList(entryList);
		List<HandBookEntry> list = new List<HandBookEntry>();
		int count = clientHandBookEntryList.Count;
		if (type != IllustratedType.Photograph)
		{
			EHandBookTabType clientHandBookType = this.GetClientHandBookType(type, null);
			for (int i = 0; i < count; i++)
			{
				HandBookEntry item = clientHandBookEntryList[i];
				list.Add(item);
			}
			this.HandBookActiveStateMap[clientHandBookType] = list;
		}
		else
		{
			this.InitHandBookActiveStateMapQuestType();
			for (int j = 0; j < count; j++)
			{
				HandBookEntry item2 = clientHandBookEntryList[j];
				EHandBookTabType clientHandBookType2 = this.GetClientHandBookType(type, new PhotographSubType?(entryList[j].PhotographSubType));
				this.HandBookActiveStateMap[clientHandBookType2].Add(item2);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnHandBookDataInit);
	}

	// Token: 0x0600E660 RID: 58976 RVA: 0x003E2BB8 File Offset: 0x003E0DB8
	private void InitHandBookActiveStateMapQuestType()
	{
		this.HandBookActiveStateMap[EHandBookTabType.MainQuest] = new List<HandBookEntry>();
		this.HandBookActiveStateMap[EHandBookTabType.RoleQuest] = new List<HandBookEntry>();
		this.HandBookActiveStateMap[EHandBookTabType.Quest] = new List<HandBookEntry>();
	}

	// Token: 0x0600E661 RID: 58977 RVA: 0x003E2BF0 File Offset: 0x003E0DF0
	public void InitHandBookRedDotList(List<IllustratedType> typeList)
	{
		this.HandBookRedDotList = new List<EHandBookTabType>();
		int count = typeList.Count;
		for (int i = 0; i < count; i++)
		{
			EHandBookTabType clientHandBookType = this.GetClientHandBookType(typeList[i], null);
			if (clientHandBookType == EHandBookTabType.Item)
			{
				IReadOnlyList<ItemHandBookType> itemHandBookTypeConfigList = ConfigBase<HandBookConfig>.Instance.GetItemHandBookTypeConfigList();
				int count2 = itemHandBookTypeConfigList.Count;
				for (int j = 0; j < count2; j++)
				{
					ItemHandBookType itemHandBookType = itemHandBookTypeConfigList[j];
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnItemReadRedDotUpdate, itemHandBookType.Id);
				}
			}
			this.HandBookRedDotList.Add(clientHandBookType);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnHandBookRedDotUpdate);
	}

	// Token: 0x0600E662 RID: 58978 RVA: 0x003E2C9C File Offset: 0x003E0E9C
	public void UpdateRedDot(EHandBookTabType type, int id)
	{
		List<HandBookEntry> list;
		if (!this.HandBookActiveStateMap.TryGetValue(type, out list))
		{
			return;
		}
		int count = list.Count;
		int i = 0;
		while (i < count)
		{
			HandBookEntry handBookEntry = list[i];
			if (handBookEntry.Id == id)
			{
				handBookEntry.IsRead = true;
				Singleton<EventSystem>.Instance.Emit<EHandBookTabType, int>(EEventName.OnHandBookRead, type, handBookEntry.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPhantomReadRedDotUpdate);
				if (type == EHandBookTabType.Item)
				{
					ItemHandBook? itemHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetItemHandBookConfigById(id);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnItemReadRedDotUpdate, itemHandBookConfigById.Value.Type);
					return;
				}
				break;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600E663 RID: 58979 RVA: 0x003E2D40 File Offset: 0x003E0F40
	public bool IsShowRedDot(EHandBookTabType type)
	{
		int count = this.HandBookRedDotList.Count;
		for (int i = 0; i < count; i++)
		{
			if (type == this.HandBookRedDotList[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600E664 RID: 58980 RVA: 0x003E2D78 File Offset: 0x003E0F78
	public int GetCollectCount(EHandBookTabType type)
	{
		List<HandBookEntry> list;
		if (!this.HandBookActiveStateMap.TryGetValue(type, out list))
		{
			return 0;
		}
		return list.Count;
	}

	// Token: 0x0600E665 RID: 58981 RVA: 0x003E2DA0 File Offset: 0x003E0FA0
	public List<HandBookEntry> GetClientHandBookEntryList(IllustratedEntry[] entryList)
	{
		List<HandBookEntry> list = new List<HandBookEntry>();
		int num = entryList.Length;
		for (int i = 0; i < num; i++)
		{
			IllustratedEntry illustratedEntry = entryList[i];
			int id = illustratedEntry.Id;
			DateTime localDateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)((ulong)illustratedEntry.CreateTime * (ulong)((long)Singleton<TimeUtil>.Instance.InverseMillisecond))).LocalDateTime;
			string createTime = Singleton<TimeUtil>.Instance.DateFormat4(localDateTime);
			bool isRead = illustratedEntry.IsRead;
			int num2 = illustratedEntry.Num;
			HandBookEntry item = new HandBookEntry(id, createTime, num2, isRead, illustratedEntry.CreateTime);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600E666 RID: 58982 RVA: 0x003E2E2C File Offset: 0x003E102C
	[NullableContext(2)]
	public HandBookEntry GetHandBookInfo(EHandBookTabType type, int id)
	{
		List<HandBookEntry> list;
		if (!this.HandBookActiveStateMap.TryGetValue(type, out list))
		{
			return null;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			HandBookEntry handBookEntry = list[i];
			if (handBookEntry.Id == id)
			{
				return handBookEntry;
			}
		}
		return null;
	}

	// Token: 0x0600E667 RID: 58983 RVA: 0x003E2E74 File Offset: 0x003E1074
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<HandBookEntry> GetHandBookInfoList(EHandBookTabType type)
	{
		List<HandBookEntry> result;
		if (!this.HandBookActiveStateMap.TryGetValue(type, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600E668 RID: 58984 RVA: 0x003E2E94 File Offset: 0x003E1094
	public EHandBookTabType GetClientHandBookType(IllustratedType type, PhotographSubType? subType = null)
	{
		EHandBookTabType result;
		switch (type)
		{
		case IllustratedType.Monster:
			result = EHandBookTabType.Monster;
			break;
		case IllustratedType.VocalCorpse:
			result = EHandBookTabType.Phantom;
			break;
		case IllustratedType.ViewPoint:
			result = EHandBookTabType.Geography;
			break;
		case IllustratedType.Weapon:
			result = EHandBookTabType.Weapon;
			break;
		case IllustratedType.Animal:
			result = EHandBookTabType.Animal;
			break;
		case IllustratedType.Item:
			result = EHandBookTabType.Item;
			break;
		case IllustratedType.Chip:
			result = EHandBookTabType.Chip;
			break;
		case IllustratedType.Photograph:
			if (subType == null)
			{
				result = EHandBookTabType.Quest;
			}
			else
			{
				switch (subType.Value)
				{
				case PhotographSubType.PhotographSub:
					result = EHandBookTabType.Quest;
					break;
				case PhotographSubType.Role:
					result = EHandBookTabType.RoleQuest;
					break;
				case PhotographSubType.Quest:
					result = EHandBookTabType.MainQuest;
					break;
				default:
					result = EHandBookTabType.Quest;
					break;
				}
			}
			break;
		case IllustratedType.Noun:
			result = EHandBookTabType.Noun;
			break;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HandBook;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "GetClientHandBookType 错误，不在目标类型内";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			result = EHandBookTabType.Monster;
			break;
		}
		}
		return result;
	}

	// Token: 0x0600E669 RID: 58985 RVA: 0x003E2F64 File Offset: 0x003E1164
	public IllustratedType GetServerHandBookType(EHandBookTabType type)
	{
		switch (type)
		{
		case EHandBookTabType.Monster:
			return IllustratedType.Monster;
		case EHandBookTabType.Phantom:
			return IllustratedType.VocalCorpse;
		case EHandBookTabType.Geography:
			return IllustratedType.ViewPoint;
		case EHandBookTabType.Weapon:
			return IllustratedType.Weapon;
		case EHandBookTabType.Animal:
			return IllustratedType.Animal;
		case EHandBookTabType.Item:
			return IllustratedType.Item;
		case EHandBookTabType.Chip:
			return IllustratedType.Chip;
		case EHandBookTabType.Quest:
			return IllustratedType.Photograph;
		case EHandBookTabType.RoleQuest:
			return IllustratedType.Photograph;
		case EHandBookTabType.MainQuest:
			return IllustratedType.Photograph;
		case EHandBookTabType.Noun:
			return IllustratedType.Noun;
		}
		return IllustratedType.Photograph;
	}

	// Token: 0x0600E66A RID: 58986 RVA: 0x003E2FD8 File Offset: 0x003E11D8
	public IllustratedType[] GetServerHandBookTypeList(List<EHandBookTabType> typeList)
	{
		int count = typeList.Count;
		IllustratedType[] array = new IllustratedType[count];
		for (int i = 0; i < count; i++)
		{
			IllustratedType serverHandBookType = this.GetServerHandBookType(typeList[i]);
			array[i] = serverHandBookType;
		}
		return array;
	}

	// Token: 0x0600E66B RID: 58987 RVA: 0x003E3014 File Offset: 0x003E1214
	public AnimalHandBook? GetAnimalConfigByMeshId(int meshId)
	{
		if (this.AnimalConfigMap.Count == 0)
		{
			IReadOnlyList<AnimalHandBook> animalHandBookConfigList = ConfigBase<HandBookConfig>.Instance.GetAnimalHandBookConfigList();
			int count = animalHandBookConfigList.Count;
			for (int i = 0; i < count; i++)
			{
				AnimalHandBook value = animalHandBookConfigList[i];
				this.AnimalConfigMap[value.MeshId] = value;
			}
		}
		AnimalHandBook value2;
		if (this.AnimalConfigMap.TryGetValue(meshId, out value2))
		{
			return new AnimalHandBook?(value2);
		}
		return null;
	}

	// Token: 0x0600E66C RID: 58988 RVA: 0x003E308C File Offset: 0x003E128C
	public int[] GetRoleHandBookCount()
	{
		int num = 0;
		IEnumerable<RoleInfo> roleList = ConfigBase<RoleConfig>.Instance.GetRoleList();
		List<RoleInfo> list = new List<RoleInfo>();
		foreach (RoleInfo item in roleList)
		{
			if (item.RoleType == 1 && !ModelBase<RoleModel>.Instance.IsMainRole(item.Id) && this.GetRoleCanShowInHandBook(item.Id))
			{
				list.Add(item);
			}
		}
		foreach (RoleInfo roleInfo in list)
		{
			if (ModelBase<RoleModel>.Instance.GetRoleDataById(roleInfo.Id, true) != null)
			{
				num++;
			}
		}
		return new int[]
		{
			num + 1,
			list.Count + 1
		};
	}

	// Token: 0x0600E66D RID: 58989 RVA: 0x003E3178 File Offset: 0x003E1378
	public int[] GetQuestCount()
	{
		int num = 0;
		IReadOnlyList<PhotographHandBook> allPlotHandBookConfig = ConfigBase<HandBookConfig>.Instance.GetAllPlotHandBookConfig();
		foreach (PhotographHandBook photographHandBook in allPlotHandBookConfig)
		{
			int type = ConfigBase<HandBookConfig>.Instance.GetPlotTypeConfig(photographHandBook.Type).Value.Type;
			if (ModelBase<HandBookModel>.Instance.GetHandBookInfo((EHandBookTabType)type, photographHandBook.Id) != null)
			{
				num++;
			}
		}
		return new int[]
		{
			num,
			allPlotHandBookConfig.Count
		};
	}

	// Token: 0x0600E66E RID: 58990 RVA: 0x003E3218 File Offset: 0x003E1418
	public int[] GetMonsterCount()
	{
		int num = 0;
		int num2 = 0;
		foreach (MonsterHandBook monsterHandBook in ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigList())
		{
			if (!monsterHandBook.IsSkin && monsterHandBook.OriginalFormInfoId <= 0)
			{
				if (monsterHandBook.DefaultUnlock)
				{
					num++;
					num2++;
				}
				else
				{
					if (this.GetHandBookInfo(EHandBookTabType.Monster, monsterHandBook.Id) != null)
					{
						num++;
					}
					num2++;
				}
			}
		}
		return new int[]
		{
			num,
			num2
		};
	}

	// Token: 0x0600E66F RID: 58991 RVA: 0x003E32B4 File Offset: 0x003E14B4
	public int[] GetAllHandBookMonsterIdList()
	{
		List<int> list = new List<int>();
		foreach (MonsterHandBook monsterHandBook in ConfigBase<HandBookConfig>.Instance.GetMonsterHandBookConfigList())
		{
			if (!monsterHandBook.IsSkin)
			{
				list.Add(monsterHandBook.Id);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600E670 RID: 58992 RVA: 0x003E3320 File Offset: 0x003E1520
	public int[] GetAllHandBookWeaponIdList()
	{
		List<int> list = new List<int>();
		foreach (WeaponConf weaponConf in ConfigBase<WeaponConfig>.Instance.GetWeaponForHandBook())
		{
			bool flag;
			if (!this.WeaponOpenTimeLockMap.TryGetValue(weaponConf.ItemId, out flag) || !flag)
			{
				list.Add(weaponConf.ItemId);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600E671 RID: 58993 RVA: 0x003E33A4 File Offset: 0x003E15A4
	public int[] GetAllHandBookWeaponSkinIdList()
	{
		List<int> list = new List<int>();
		foreach (WeaponSkin weaponSkin in ConfigBase<WeaponConfig>.Instance.GetWeaponSkinForHandBook())
		{
			bool flag;
			if (!this.WeaponOpenTimeLockMap.TryGetValue(weaponSkin.Id, out flag) || !flag)
			{
				list.Add(weaponSkin.Id);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600E672 RID: 58994 RVA: 0x003E3428 File Offset: 0x003E1628
	public void RefreshRoleHandBookOpenTime(RoleIllustratedInfo[] dataList)
	{
		foreach (RoleIllustratedInfo roleIllustratedInfo in dataList)
		{
			this.RoleOpenTimeLockMap[roleIllustratedInfo.RoleId] = ((double)Singleton<MathUtils>.Instance.LongToNumber(roleIllustratedInfo.UnlockTime) > Singleton<TimeUtil>.Instance.GetServerTime());
		}
	}

	// Token: 0x0600E673 RID: 58995 RVA: 0x003E3478 File Offset: 0x003E1678
	public bool GetRoleCanShowInHandBook(int roleId)
	{
		bool flag;
		return !this.RoleOpenTimeLockMap.TryGetValue(roleId, out flag) || !flag;
	}

	// Token: 0x0600E674 RID: 58996 RVA: 0x003E349C File Offset: 0x003E169C
	public void RefreshWeaponHandBookOpenTime(WeaponIllustratedInfo[] dataList)
	{
		foreach (WeaponIllustratedInfo weaponIllustratedInfo in dataList)
		{
			this.WeaponOpenTimeLockMap[weaponIllustratedInfo.WeaponId] = ((double)Singleton<MathUtils>.Instance.LongToNumber(weaponIllustratedInfo.UnlockTime) > Singleton<TimeUtil>.Instance.GetServerTime());
		}
	}

	// Token: 0x04006F18 RID: 28440
	private readonly Dictionary<EHandBookTabType, List<HandBookEntry>> HandBookActiveStateMap;

	// Token: 0x04006F19 RID: 28441
	private List<EHandBookTabType> HandBookRedDotList;

	// Token: 0x04006F1A RID: 28442
	private readonly Dictionary<int, AnimalHandBook> AnimalConfigMap;

	// Token: 0x04006F1B RID: 28443
	public int CurrentSelectMonsterHandBookId;

	// Token: 0x04006F1C RID: 28444
	public int CurrentSelectWeaponHandBookId;

	// Token: 0x04006F1D RID: 28445
	public Dictionary<int, bool> RoleOpenTimeLockMap;

	// Token: 0x04006F1E RID: 28446
	public Dictionary<int, bool> WeaponOpenTimeLockMap;
}
