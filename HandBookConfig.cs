using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001E51 RID: 7761
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class HandBookConfig : ConfigBase<HandBookConfig>
{
	// Token: 0x0600E5D1 RID: 58833 RVA: 0x003E13BA File Offset: 0x003DF5BA
	public IReadOnlyList<PhantomHandBook> GetPhantomHandBookConfig()
	{
		return ConfigPhantomHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5D2 RID: 58834 RVA: 0x003E13C2 File Offset: 0x003DF5C2
	public IReadOnlyList<PhantomFetterHandBook> GetPhantomFetterHandBookConfig()
	{
		return ConfigPhantomFetterHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5D3 RID: 58835 RVA: 0x003E13CA File Offset: 0x003DF5CA
	public PhantomHandBook? GetPhantomHandBookConfigById(int id)
	{
		return ConfigPhantomHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5D4 RID: 58836 RVA: 0x003E13D3 File Offset: 0x003DF5D3
	public IReadOnlyList<PhantomHandBookPage> GetPhantomHandBookPageConfig()
	{
		return ConfigPhantomHandBookPageAll.GetConfigList(true);
	}

	// Token: 0x0600E5D5 RID: 58837 RVA: 0x003E13DB File Offset: 0x003DF5DB
	public HandBookEntrance? GetHandBookEntranceConfig(EHandBookTabType type)
	{
		return ConfigHandBookEntranceById.GetConfig((int)type, true);
	}

	// Token: 0x0600E5D6 RID: 58838 RVA: 0x003E13E4 File Offset: 0x003DF5E4
	public IReadOnlyList<HandBookEntrance> GetHandBookEntranceConfigList()
	{
		return ConfigHandBookEntranceAll.GetConfigList(true);
	}

	// Token: 0x0600E5D7 RID: 58839 RVA: 0x003E13EC File Offset: 0x003DF5EC
	public WeaponHandBook? GetWeaponHandBookConfig(int id)
	{
		return ConfigWeaponHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5D8 RID: 58840 RVA: 0x003E13F5 File Offset: 0x003DF5F5
	public IReadOnlyList<WeaponHandBook> GetWeaponHandBookConfigList()
	{
		return ConfigWeaponHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5D9 RID: 58841 RVA: 0x003E13FD File Offset: 0x003DF5FD
	public MonsterHandBook? GetMonsterHandBookConfigById(int id)
	{
		return ConfigMonsterHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5DA RID: 58842 RVA: 0x003E1406 File Offset: 0x003DF606
	public MonsterHandBook? GetMonsterHandBookConfigByMonsterId(int monsterId)
	{
		return ConfigMonsterHandBookByMonsterId.GetConfig(monsterId, true);
	}

	// Token: 0x0600E5DB RID: 58843 RVA: 0x003E140F File Offset: 0x003DF60F
	public IReadOnlyList<MonsterHandBook> GetMonsterHandBookConfigByType(int type)
	{
		return ConfigMonsterHandBookByType.GetConfigList(type, true);
	}

	// Token: 0x0600E5DC RID: 58844 RVA: 0x003E1418 File Offset: 0x003DF618
	public IReadOnlyList<MonsterHandBookType> GetMonsterHandBookTypeConfig()
	{
		return ConfigMonsterHandBookTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E5DD RID: 58845 RVA: 0x003E1420 File Offset: 0x003DF620
	public MonsterHandBookType? GetMonsterHandBookTypeConfigById(int id)
	{
		return ConfigMonsterHandBookTypeById.GetConfig(id, true);
	}

	// Token: 0x0600E5DE RID: 58846 RVA: 0x003E1429 File Offset: 0x003DF629
	public IReadOnlyList<MonsterHandBook> GetMonsterHandBookConfigList()
	{
		return ConfigMonsterHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5DF RID: 58847 RVA: 0x003E1431 File Offset: 0x003DF631
	public ItemHandBook? GetItemHandBookConfigById(int id)
	{
		return ConfigItemHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5E0 RID: 58848 RVA: 0x003E143A File Offset: 0x003DF63A
	public IReadOnlyList<ItemHandBook> GetItemHandBookConfigList()
	{
		return ConfigItemHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5E1 RID: 58849 RVA: 0x003E1442 File Offset: 0x003DF642
	public IReadOnlyList<ItemHandBook> GetItemHandBookConfigByType(int type)
	{
		return ConfigItemHandBookByType.GetConfigList(type, true);
	}

	// Token: 0x0600E5E2 RID: 58850 RVA: 0x003E144B File Offset: 0x003DF64B
	public IReadOnlyList<ItemHandBookType> GetItemHandBookTypeConfigList()
	{
		return ConfigItemHandBookTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E5E3 RID: 58851 RVA: 0x003E1453 File Offset: 0x003DF653
	public ItemHandBookType? GetItemHandBookTypeConfig(int type)
	{
		return ConfigItemHandBookTypeById.GetConfig(type, true);
	}

	// Token: 0x0600E5E4 RID: 58852 RVA: 0x003E145C File Offset: 0x003DF65C
	public IReadOnlyList<AnimalHandBook> GetAnimalHandBookConfigList()
	{
		return ConfigAnimalHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5E5 RID: 58853 RVA: 0x003E1464 File Offset: 0x003DF664
	public AnimalHandBook? GetAnimalHandBookConfigById(int id)
	{
		return ConfigAnimalHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5E6 RID: 58854 RVA: 0x003E1470 File Offset: 0x003DF670
	public AnimalHandBook? GetAnimalHandBookConfigByMeshId(int meshId)
	{
		if (this.AnimalMeshIdMap == null)
		{
			this.AnimalMeshIdMap = new Dictionary<int, int>();
			foreach (AnimalHandBook animalHandBook in ConfigAnimalHandBookAll.GetConfigList(true))
			{
				this.AnimalMeshIdMap[animalHandBook.MeshId] = animalHandBook.Id;
			}
		}
		int num;
		if (this.AnimalMeshIdMap.TryGetValue(meshId, out num) && num != 0)
		{
			return ConfigAnimalHandBookByMeshId.GetConfig(meshId, true);
		}
		return null;
	}

	// Token: 0x0600E5E7 RID: 58855 RVA: 0x003E1508 File Offset: 0x003DF708
	public IReadOnlyList<ChipHandBook> GetAllChipHandBookConfig()
	{
		return ConfigChipHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5E8 RID: 58856 RVA: 0x003E1510 File Offset: 0x003DF710
	public IReadOnlyList<ChipHandBook> GetChipHandBookConfigList(int type)
	{
		return ConfigChipHandBookByType.GetConfigList(type, true);
	}

	// Token: 0x0600E5E9 RID: 58857 RVA: 0x003E1519 File Offset: 0x003DF719
	public ChipHandBook? GetChipHandBookConfig(int id)
	{
		return ConfigChipHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5EA RID: 58858 RVA: 0x003E1522 File Offset: 0x003DF722
	public IReadOnlyList<ChipType> GetChipTypeConfigList()
	{
		return ConfigChipTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E5EB RID: 58859 RVA: 0x003E152A File Offset: 0x003DF72A
	public ChipType? GetChipTypeConfig(int id)
	{
		return ConfigChipTypeById.GetConfig(id, true);
	}

	// Token: 0x0600E5EC RID: 58860 RVA: 0x003E1533 File Offset: 0x003DF733
	public NounHandBook? GetNounHandBookConfig(int id)
	{
		return ConfigNounHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5ED RID: 58861 RVA: 0x003E153C File Offset: 0x003DF73C
	public IReadOnlyList<NounHandBook> GetNounHandBookConfigList(int type)
	{
		return ConfigNounHandBookByType.GetConfigList(type, true);
	}

	// Token: 0x0600E5EE RID: 58862 RVA: 0x003E1545 File Offset: 0x003DF745
	public IReadOnlyList<NounType> GetNounTypeConfigList()
	{
		return ConfigNounTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E5EF RID: 58863 RVA: 0x003E154D File Offset: 0x003DF74D
	public NounType? GetNounTypeConfig(int id)
	{
		return ConfigNounTypeById.GetConfig(id, true);
	}

	// Token: 0x0600E5F0 RID: 58864 RVA: 0x003E1556 File Offset: 0x003DF756
	public IReadOnlyList<NounHandBook> GetNounTypeConfigAll()
	{
		return ConfigNounHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5F1 RID: 58865 RVA: 0x003E155E File Offset: 0x003DF75E
	public GeographyHandBook? GetGeographyHandBookConfig(int id)
	{
		return ConfigGeographyHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5F2 RID: 58866 RVA: 0x003E1567 File Offset: 0x003DF767
	public IReadOnlyList<GeographyHandBook> GetAllGeographyHandBookConfig()
	{
		return ConfigGeographyHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5F3 RID: 58867 RVA: 0x003E156F File Offset: 0x003DF76F
	public IReadOnlyList<GeographyHandBook> GetGeographyHandBookConfigByType(int type)
	{
		return ConfigGeographyHandBookByType.GetConfigList(type, true);
	}

	// Token: 0x0600E5F4 RID: 58868 RVA: 0x003E1578 File Offset: 0x003DF778
	public IReadOnlyList<GeographyHandBook> GetGeographyHandBookConfigByTabType(int tabType)
	{
		return ConfigGeographyHandBookByTabType.GetConfigList(tabType, true);
	}

	// Token: 0x0600E5F5 RID: 58869 RVA: 0x003E1581 File Offset: 0x003DF781
	public IReadOnlyList<GeographyHandBook> GetGeographyHandBookConfigByTabTypeAndType(int tabType, int type)
	{
		return ConfigGeographyHandBookByTabTypeAndType.GetConfigList(tabType, type, true);
	}

	// Token: 0x0600E5F6 RID: 58870 RVA: 0x003E158B File Offset: 0x003DF78B
	public GeographyType? GetGeographyTypeConfig(int id)
	{
		return ConfigGeographyTypeById.GetConfig(id, true);
	}

	// Token: 0x0600E5F7 RID: 58871 RVA: 0x003E1594 File Offset: 0x003DF794
	public IReadOnlyList<GeographyType> GetGeographyTypeConfigList()
	{
		return ConfigGeographyTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E5F8 RID: 58872 RVA: 0x003E159C File Offset: 0x003DF79C
	public IReadOnlyList<GeographyTabType> GetGeographyTabList()
	{
		return ConfigGeographyTabTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E5F9 RID: 58873 RVA: 0x003E15A4 File Offset: 0x003DF7A4
	public GeographyTabType? GetGeographyTabTypeById(int id)
	{
		return ConfigGeographyTabTypeById.GetConfig(id, true);
	}

	// Token: 0x0600E5FA RID: 58874 RVA: 0x003E15AD File Offset: 0x003DF7AD
	public IReadOnlyList<PhotographHandBook> GetAllPlotHandBookConfig()
	{
		return ConfigPhotographHandBookAll.GetConfigList(true);
	}

	// Token: 0x0600E5FB RID: 58875 RVA: 0x003E15B5 File Offset: 0x003DF7B5
	public PhotographHandBook? GetPlotHandBookConfig(int id)
	{
		return ConfigPhotographHandBookById.GetConfig(id, true);
	}

	// Token: 0x0600E5FC RID: 58876 RVA: 0x003E15BE File Offset: 0x003DF7BE
	public IReadOnlyList<PhotographHandBook> GetPlotHandBookConfigByType(int type)
	{
		return ConfigPhotographHandBookByType.GetConfigList(type, true);
	}

	// Token: 0x0600E5FD RID: 58877 RVA: 0x003E15C7 File Offset: 0x003DF7C7
	public PlotType? GetPlotTypeConfig(int id)
	{
		return ConfigPlotTypeById.GetConfig(id, true);
	}

	// Token: 0x0600E5FE RID: 58878 RVA: 0x003E15D0 File Offset: 0x003DF7D0
	public IReadOnlyList<PlotType> GetPlotTypeConfigList()
	{
		return ConfigPlotTypeAll.GetConfigList(true);
	}

	// Token: 0x0600E5FF RID: 58879 RVA: 0x003E15D8 File Offset: 0x003DF7D8
	public IReadOnlyList<HandBookQuestTab> GetQuestTabList()
	{
		return ConfigHandBookQuestTabAll.GetConfigList(true);
	}

	// Token: 0x0600E600 RID: 58880 RVA: 0x003E15E0 File Offset: 0x003DF7E0
	public HandBookQuestTab? GetQuestTab(int type)
	{
		foreach (HandBookQuestTab value in ConfigHandBookQuestTabAll.GetConfigList(true))
		{
			if (value.Type == type)
			{
				return new HandBookQuestTab?(value);
			}
		}
		return null;
	}

	// Token: 0x0600E601 RID: 58881 RVA: 0x003E1644 File Offset: 0x003DF844
	public PlotHandBookConfig? GetQuestPlotConfig(int questId)
	{
		return ConfigPlotHandBookConfigByQuestId.GetConfig(questId, true);
	}

	// Token: 0x04006EB0 RID: 28336
	[Nullable(2)]
	private Dictionary<int, int> AnimalMeshIdMap;
}
