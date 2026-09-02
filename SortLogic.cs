using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200194F RID: 6479
[NullableContext(1)]
[Nullable(0)]
public class SortLogic
{
	// Token: 0x0600B9D8 RID: 47576 RVA: 0x00318398 File Offset: 0x00316598
	public SortLogic()
	{
		this.DataMapInternal = new Dictionary<ESortDataType, CommonSort>
		{
			{
				ESortDataType.Role,
				new RoleSort()
			},
			{
				ESortDataType.Weapon,
				new WeaponSort()
			},
			{
				ESortDataType.ItemData,
				new ItemSort()
			},
			{
				ESortDataType.Phantom,
				new PhantomSort()
			},
			{
				ESortDataType.Cook,
				new CookSort()
			},
			{
				ESortDataType.Reagent,
				new ComposeSort()
			},
			{
				ESortDataType.Structure,
				new ComposeStructureSort()
			},
			{
				ESortDataType.Purification,
				new ComposePurificationSort()
			},
			{
				ESortDataType.Forging,
				new ForgingSort()
			},
			{
				ESortDataType.Calabash,
				new CalabashCollectSort()
			},
			{
				ESortDataType.AssemblyGrid,
				new AssemblyGridSort()
			},
			{
				ESortDataType.VisionFetter,
				new VisionFetterSort()
			},
			{
				ESortDataType.AdventureGuide,
				new AdventureGuideSort()
			},
			{
				ESortDataType.ComposeExchange,
				new ComposeExchangeSort()
			},
			{
				ESortDataType.Attribute,
				new PhantomSort()
			},
			{
				ESortDataType.FishingItem,
				new FishingItemSort()
			},
			{
				ESortDataType.DangoAbyssPlugin,
				new DangoAbyssPluginItemSort()
			},
			{
				ESortDataType.MonsterHandBook,
				new MonsterHandBookSort()
			},
			{
				ESortDataType.WeaponHandBook,
				new WeaponHandBookSort()
			},
			{
				ESortDataType.WeaponSkinHandBook,
				new WeaponSkinHandBookSort()
			},
			{
				ESortDataType.PinballFormation,
				new PinballFormationSort()
			},
			{
				ESortDataType.PinballWeapon,
				new PinballWeaponSort()
			},
			{
				ESortDataType.PinballRoleSelect,
				new PinballRoleSelectSort()
			},
			{
				ESortDataType.PinballWeaponEquip,
				new PinballWeaponEquipSort()
			}
		};
	}

	// Token: 0x0600B9D9 RID: 47577 RVA: 0x003184E8 File Offset: 0x003166E8
	public void SortDataList<[Nullable(2)] T>(List<T> dataList, int configId, SortResultData resultData, params object[] parameters)
	{
		Sort? sortConfig = ConfigBase<SortConfig>.Instance.GetSortConfig(configId);
		HashSet<int> allSelectRuleSet = resultData.GetAllSelectRuleSet();
		bool isAscending = resultData.GetIsAscending();
		ESortDataType dataId = (ESortDataType)sortConfig.Value.DataId;
		this.SortDataByData<T>(dataList, dataId, allSelectRuleSet, isAscending, parameters);
	}

	// Token: 0x0600B9DA RID: 47578 RVA: 0x0031852C File Offset: 0x0031672C
	public void SortDataByData<[Nullable(2)] T>(List<T> dataList, ESortDataType dataType, HashSet<int> ruleIdSet, bool isAscending, params object[] parameters)
	{
		CommonSort sortClass = this.DataMapInternal[dataType];
		sortClass.InitSortMap();
		dataList.Sort(delegate(T aData, T bData)
		{
			foreach (int ruleId in ruleIdSet)
			{
				TSortResult sortFunctionByRuleId = sortClass.GetSortFunctionByRuleId(ruleId);
				if (sortFunctionByRuleId != null)
				{
					int num = sortFunctionByRuleId(aData, bData, isAscending, parameters);
					if (num != 0)
					{
						return num;
					}
				}
			}
			return 0;
		});
	}

	// Token: 0x040057C1 RID: 22465
	private readonly Dictionary<ESortDataType, CommonSort> DataMapInternal;
}
