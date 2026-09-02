using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;

// Token: 0x02002940 RID: 10560
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RouletteModel : ModelBase<RouletteModel>
{
	// Token: 0x06014F51 RID: 85841 RVA: 0x005CCBE8 File Offset: 0x005CADE8
	public bool IsExploreRouletteOpen(bool checkTips = false)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		object obj;
		if (getCurrentEntity == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			obj = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null && obj2.HasAnyTag(this.GetExploreRouletteBanTagIds()))
		{
			if (checkTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ExploreToolCantOpen", Array.Empty<object>());
			}
			return false;
		}
		if (!ModelBase<LevelFuncFlagModel>.Instance.GetFuncFlagEnable(ELevelFuncFlagId.ExploreSkillRoulette))
		{
			if (checkTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ExploreToolCantOpen", Array.Empty<object>());
			}
			return false;
		}
		return ModelBase<FunctionModel>.Instance.IsOpen(10026);
	}

	// Token: 0x06014F52 RID: 85842 RVA: 0x005CCC79 File Offset: 0x005CAE79
	public bool IsFunctionRouletteOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10056);
	}

	// Token: 0x06014F53 RID: 85843 RVA: 0x005CCC8A File Offset: 0x005CAE8A
	protected override bool OnInit()
	{
		this.InitAllRouletteListData();
		this.InitFunctionData();
		this.AddEvents();
		this.OnSettingExploreSkillIdList.Clear();
		return true;
	}

	// Token: 0x06014F54 RID: 85844 RVA: 0x005CCCAA File Offset: 0x005CAEAA
	protected override bool OnClear()
	{
		this.ClearAllRouletteListData();
		this.RemoveEvents();
		return true;
	}

	// Token: 0x06014F55 RID: 85845 RVA: 0x005CCCBC File Offset: 0x005CAEBC
	public List<int> GetExploreRouletteBanTagIds()
	{
		IReadOnlyList<ExploreRoulette> exploreRouletteConfig = ConfigBase<RouletteConfig>.Instance.GetExploreRouletteConfig();
		List<int> list = new List<int>();
		if (exploreRouletteConfig.Count == 0)
		{
			return list;
		}
		for (int i = 0; i < exploreRouletteConfig[0].BanTagsLength; i++)
		{
			string text = exploreRouletteConfig[0].BanTags(i);
			int? num = new int?(GameplayTagUtils.GetTagIdByName(text));
			if (num == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Phantom;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "探索工具轮盘禁用Tag不存在,请检查配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagName", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				list.Add(num.Value);
			}
		}
		return list;
	}

	// Token: 0x06014F56 RID: 85846 RVA: 0x005CCD61 File Offset: 0x005CAF61
	protected void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, this.UnlockFunction1);
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, this.UnlockFunction2);
	}

	// Token: 0x06014F57 RID: 85847 RVA: 0x005CCD8F File Offset: 0x005CAF8F
	protected void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenSet, this.UnlockFunction1);
		Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, this.UnlockFunction2);
	}

	// Token: 0x06014F58 RID: 85848 RVA: 0x005CCDC0 File Offset: 0x005CAFC0
	public List<RouletteListDataBase> GetActivatedRouletteList()
	{
		List<RouletteListDataBase> list = new List<RouletteListDataBase>();
		foreach (RouletteListDataBase rouletteListDataBase in this.RouletteListDataMap.Values)
		{
			if (rouletteListDataBase.IsActivate())
			{
				list.Add(rouletteListDataBase);
			}
		}
		list.Sort((RouletteListDataBase a, RouletteListDataBase b) => a.Priority - b.Priority);
		return list;
	}

	// Token: 0x06014F59 RID: 85849 RVA: 0x005CCE4C File Offset: 0x005CB04C
	public RouletteListDataBase GetCurrentExploreRouletteListData()
	{
		return this.GetActivatedRouletteList()[0];
	}

	// Token: 0x06014F5A RID: 85850 RVA: 0x005CCE5A File Offset: 0x005CB05A
	public RouletteListDataBase GetCurrentFunctionRouletteListData()
	{
		return this.RouletteListDataMap[ERouletteType.Function];
	}

	// Token: 0x06014F5B RID: 85851 RVA: 0x005CCE68 File Offset: 0x005CB068
	private void InitAllRouletteListData()
	{
		this.RouletteListDataMap.Clear();
		RouletteListDataExplore value = new RouletteListDataExplore();
		this.RouletteListDataMap[ERouletteType.Explore] = value;
		RouletteListDataFunc value2 = new RouletteListDataFunc();
		this.RouletteListDataMap[ERouletteType.Function] = value2;
		RouletteListDataMotor value3 = new RouletteListDataMotor();
		this.RouletteListDataMap[ERouletteType.Motor] = value3;
		foreach (RouletteListDataBase rouletteListDataBase in this.RouletteListDataMap.Values)
		{
			rouletteListDataBase.Init();
		}
	}

	// Token: 0x06014F5C RID: 85852 RVA: 0x005CCF04 File Offset: 0x005CB104
	private void ClearAllRouletteListData()
	{
		foreach (RouletteListDataBase rouletteListDataBase in this.RouletteListDataMap.Values)
		{
			rouletteListDataBase.Clear();
		}
		this.RouletteListDataMap.Clear();
	}

	// Token: 0x17001B7A RID: 7034
	// (get) Token: 0x06014F5D RID: 85853 RVA: 0x005CCF64 File Offset: 0x005CB164
	// (set) Token: 0x06014F5E RID: 85854 RVA: 0x005CCF6C File Offset: 0x005CB16C
	public int CurrentExploreSkillId
	{
		get
		{
			return this.EquipExploreSkillId;
		}
		set
		{
			if (this.EquipExploreSkillId == value)
			{
				return;
			}
			this.EquipExploreSkillId = value;
			this.SendExploreToolSwitchLogData(this.EquipExploreSkillId);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "设置新探索技能Id成功";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.EquipExploreSkillId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeSelectedExploreId);
		}
	}

	// Token: 0x17001B7B RID: 7035
	// (get) Token: 0x06014F5F RID: 85855 RVA: 0x005CCFD8 File Offset: 0x005CB1D8
	[Nullable(2)]
	public string CurrentExploreSkillIcon
	{
		[NullableContext(2)]
		get
		{
			if (this.EquipExploreSkillId == 0)
			{
				return null;
			}
			if (this.IsEquipItemSelectOn)
			{
				if (this.CurrentEquipItemId == 0)
				{
					return null;
				}
				ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(this.CurrentEquipItemId);
				if (itemConfig == null)
				{
					return null;
				}
				return itemConfig.GetValueOrDefault().Icon;
			}
			else
			{
				ExploreTools exploreTools;
				if (this.UnlockExploreSkillDataMap.TryGetValue(this.EquipExploreSkillId, out exploreTools))
				{
					return exploreTools.BattleViewIcon;
				}
				ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(this.EquipExploreSkillId);
				if (exploreConfigById == null)
				{
					return null;
				}
				return exploreConfigById.GetValueOrDefault().BattleViewIcon;
			}
		}
	}

	// Token: 0x06014F60 RID: 85856 RVA: 0x005CD078 File Offset: 0x005CB278
	public unsafe void RecoverEquipExploreSkillId()
	{
		foreach (RouletteListDataBase rouletteListDataBase in this.GetActivatedRouletteList())
		{
			int equipExploreSkillId = rouletteListDataBase.GetEquipExploreSkillId();
			if (equipExploreSkillId != 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Phantom;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "还原当前状态装备探索技能Id";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("启用轮盘类型", rouletteListDataBase.RouletteType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkillId", equipExploreSkillId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(equipExploreSkillId, EExploreSkillLayer.Roulette, "RecoverEquipExploreSkillId");
				ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(equipExploreSkillId, null, false);
				break;
			}
		}
	}

	// Token: 0x06014F61 RID: 85857 RVA: 0x005CD15C File Offset: 0x005CB35C
	public ExploreTools? GetExploreDataBySkillId(int skillId)
	{
		ExploreTools value;
		if (this.UnlockExploreSkillDataMap.TryGetValue(skillId, out value))
		{
			return new ExploreTools?(value);
		}
		return null;
	}

	// Token: 0x06014F62 RID: 85858 RVA: 0x005CD18C File Offset: 0x005CB38C
	public void UnlockExploreSkill(int id, bool isNew = true)
	{
		ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(id);
		if (exploreConfigById != null)
		{
			this.UnlockExploreSkillDataMap[id] = exploreConfigById.Value;
		}
		if (isNew)
		{
			this.TryAddNewItem(id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.AddExploreVisionSkill, id);
		}
	}

	// Token: 0x06014F63 RID: 85859 RVA: 0x005CD1E0 File Offset: 0x005CB3E0
	public void CreateAllUnlockExploreSkill(List<int> idList)
	{
		this.UnlockExploreSkillDataMap.Clear();
		foreach (int id in idList)
		{
			this.UnlockExploreSkill(id, false);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "设置当前解锁的探索技能";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("技能列表", idList);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06014F64 RID: 85860 RVA: 0x005CD264 File Offset: 0x005CB464
	public FuncMenuWheel? GetFuncDataByFuncId(int id)
	{
		FuncMenuWheel value;
		if (this.UnlockFunctionDataMap.TryGetValue(id, out value))
		{
			return new FuncMenuWheel?(value);
		}
		return null;
	}

	// Token: 0x06014F65 RID: 85861 RVA: 0x005CD294 File Offset: 0x005CB494
	private void InitFunctionData()
	{
		IReadOnlyList<FuncMenuWheel> allFuncConfig = ConfigBase<RouletteConfig>.Instance.GetAllFuncConfig();
		if (allFuncConfig != null)
		{
			foreach (FuncMenuWheel value in allFuncConfig)
			{
				if (value.UnlockCondition > 0)
				{
					this.FuncOpenIdMap[value.UnlockCondition] = value.FuncId;
				}
				else
				{
					this.UnlockFunctionDataMap[value.FuncId] = value;
				}
			}
		}
	}

	// Token: 0x06014F66 RID: 85862 RVA: 0x005CD31C File Offset: 0x005CB51C
	private void OpenFunction(int funcId)
	{
		FuncMenuWheel? funcConfigById = ConfigBase<RouletteConfig>.Instance.GetFuncConfigById(funcId);
		if (funcConfigById == null)
		{
			return;
		}
		if (!this.UnlockFunctionDataMap.ContainsKey(funcId))
		{
			this.UnlockFunctionDataMap[funcId] = funcConfigById.Value;
		}
	}

	// Token: 0x06014F67 RID: 85863 RVA: 0x005CD360 File Offset: 0x005CB560
	private void CloseFunction(int funcId)
	{
		this.UnlockFunctionDataMap.Remove(funcId);
	}

	// Token: 0x17001B7C RID: 7036
	// (get) Token: 0x06014F68 RID: 85864 RVA: 0x005CD36F File Offset: 0x005CB56F
	public int CurrentEquipItemId
	{
		get
		{
			return this.RouletteListDataMap[ERouletteType.Explore].GetExtraItemId();
		}
	}

	// Token: 0x17001B7D RID: 7037
	// (get) Token: 0x06014F69 RID: 85865 RVA: 0x005CD382 File Offset: 0x005CB582
	public bool IsEquipItemSelectOn
	{
		get
		{
			return this.CurrentExploreSkillId == 3001;
		}
	}

	// Token: 0x17001B7E RID: 7038
	// (get) Token: 0x06014F6A RID: 85866 RVA: 0x005CD394 File Offset: 0x005CB594
	public InventoryDefine.EItemType? EquipItemType
	{
		get
		{
			if (this.CurrentEquipItemId == 0)
			{
				return null;
			}
			if (ConfigBase<SpecialItemConfig>.Instance.GetConfig(this.CurrentEquipItemId) != null)
			{
				return new InventoryDefine.EItemType?(InventoryDefine.EItemType.SpecialItem);
			}
			return new InventoryDefine.EItemType?(InventoryDefine.EItemType.Common);
		}
	}

	// Token: 0x06014F6B RID: 85867 RVA: 0x005CD3DC File Offset: 0x005CB5DC
	public bool IsExploreSkillHasNumBySkillData(ExploreTools skillData)
	{
		if (skillData.SkillType != 5)
		{
			Dictionary<int, int> dictionary = skillData.Cost();
			return dictionary != null && dictionary.Count > 0;
		}
		TrapDefenseItem? trapDefenseItemByExploreToolId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseItemByExploreToolId(skillData.PhantomSkillId);
		if (trapDefenseItemByExploreToolId == null)
		{
			return false;
		}
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		return ((instance != null) ? instance.BattleInventoryData.GetItemData(trapDefenseItemByExploreToolId.Value.Id) : null) != null;
	}

	// Token: 0x06014F6C RID: 85868 RVA: 0x005CD454 File Offset: 0x005CB654
	public int GetExploreSkillShowNumBySkillData(ExploreTools skillData)
	{
		if (skillData.SkillType != 5)
		{
			Dictionary<int, int> dictionary = skillData.Cost();
			if (dictionary != null && dictionary.Count > 0 && dictionary.Count > 0)
			{
				int itemConfigId = 0;
				using (Dictionary<int, int>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						itemConfigId = enumerator.Current;
					}
				}
				return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemConfigId, 0);
			}
			return 0;
		}
		else
		{
			TrapDefenseItem? trapDefenseItemByExploreToolId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseItemByExploreToolId(skillData.PhantomSkillId);
			if (trapDefenseItemByExploreToolId == null)
			{
				return 0;
			}
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			TrapDefenseBattleItemData trapDefenseBattleItemData = (instance != null) ? instance.BattleInventoryData.GetItemData(trapDefenseItemByExploreToolId.Value.Id) : null;
			if (trapDefenseBattleItemData == null)
			{
				return 0;
			}
			return trapDefenseBattleItemData.InventoryCount;
		}
	}

	// Token: 0x06014F6D RID: 85869 RVA: 0x005CD52C File Offset: 0x005CB72C
	public bool IsExploreSkillHasNum()
	{
		if (!this.IsEquipItemSelectOn)
		{
			ExploreTools skillData;
			return this.UnlockExploreSkillDataMap.TryGetValue(this.CurrentExploreSkillId, out skillData) && this.GetExploreSkillShowNumBySkillData(skillData) > 0;
		}
		if (this.CurrentEquipItemId == 0)
		{
			return false;
		}
		if (this.EquipItemType.GetValueOrDefault() == InventoryDefine.EItemType.Common)
		{
			return true;
		}
		SpecialItem? config = ConfigBase<SpecialItemConfig>.Instance.GetConfig(this.CurrentEquipItemId);
		return config != null && config.GetValueOrDefault().NeedShowNum;
	}

	// Token: 0x06014F6E RID: 85870 RVA: 0x005CD5B0 File Offset: 0x005CB7B0
	public int GetExploreSkillShowNum()
	{
		if (this.IsEquipItemSelectOn)
		{
			return ModelBase<InventoryModel>.Instance.GetCommonItemCount(this.CurrentEquipItemId, 0);
		}
		ExploreTools skillData;
		if (!this.UnlockExploreSkillDataMap.TryGetValue(this.CurrentExploreSkillId, out skillData))
		{
			return 0;
		}
		return this.GetExploreSkillShowNumBySkillData(skillData);
	}

	// Token: 0x06014F6F RID: 85871 RVA: 0x005CD5F5 File Offset: 0x005CB7F5
	public bool IsExploreSkillHasSetNum(int exploreSkillId)
	{
		return exploreSkillId - 1010 <= 2 || exploreSkillId == 1018;
	}

	// Token: 0x06014F70 RID: 85872 RVA: 0x005CD60C File Offset: 0x005CB80C
	[NullableContext(0)]
	public ValueTuple<int, int> GetExploreSkillShowSetNumById(ERouletteExploreId exploreSkillId)
	{
		switch (exploreSkillId)
		{
		case ERouletteExploreId.临时传送:
		{
			int? toolPlaceLimit = ModelBase<MapExploreToolModel>.Instance.GetToolPlaceLimit(exploreSkillId);
			return new ValueTuple<int, int>(ModelBase<MapExploreToolModel>.Instance.GetToolPlaceNum(exploreSkillId).GetValueOrDefault(), toolPlaceLimit.GetValueOrDefault());
		}
		case ERouletteExploreId.声匣探测:
		{
			int? toolPlaceLimit2 = ModelBase<MapExploreToolModel>.Instance.GetToolPlaceLimit(exploreSkillId);
			return new ValueTuple<int, int>(ModelBase<MapExploreToolModel>.Instance.GetToolPlaceNum(exploreSkillId).GetValueOrDefault(), toolPlaceLimit2.GetValueOrDefault());
		}
		case ERouletteExploreId.物资探测:
		{
			int? toolPlaceLimit3 = ModelBase<MapExploreToolModel>.Instance.GetToolPlaceLimit(exploreSkillId);
			return new ValueTuple<int, int>(ModelBase<MapExploreToolModel>.Instance.GetToolPlaceNum(exploreSkillId).GetValueOrDefault(), toolPlaceLimit3.GetValueOrDefault());
		}
		default:
		{
			if (exploreSkillId != ERouletteExploreId.捕鱼诱饵)
			{
				return new ValueTuple<int, int>(0, 0);
			}
			int? num = new int?(ModelBase<FishingModel>.Instance.GetTempFishingPointLimit());
			int? num2 = new int?(ModelBase<FishingModel>.Instance.GetTempFishingPointNum());
			return new ValueTuple<int, int>(num2.GetValueOrDefault(), num.GetValueOrDefault());
		}
		}
	}

	// Token: 0x06014F71 RID: 85873 RVA: 0x005CD704 File Offset: 0x005CB904
	public bool IsEquipItemInBuffCd()
	{
		return this.IsEquipItemSelectOn && this.CurrentEquipItemId != 0 && ConfigBase<BuffItemConfig>.Instance.IsBuffItem(this.CurrentEquipItemId) && ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(this.CurrentEquipItemId) - Singleton<TimeUtil>.Instance.TimeDeviation > 0.0;
	}

	// Token: 0x06014F72 RID: 85874 RVA: 0x005CD75F File Offset: 0x005CB95F
	public bool IsEquippedItemBanReqUse()
	{
		return this.IsEquipItemSelectOn && ControllerBase<SpecialItemController>.Instance.IsSpecialItem(this.CurrentEquipItemId) && !ControllerBase<SpecialItemController>.Instance.AllowReqUseSpecialItem(this.CurrentEquipItemId);
	}

	// Token: 0x06014F73 RID: 85875 RVA: 0x005CD792 File Offset: 0x005CB992
	public void SaveNewItemList()
	{
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.RouletteAssemblyItemRedDot);
		Singleton<EventSystem>.Instance.Emit(EEventName.RouletteRefreshNew);
	}

	// Token: 0x06014F74 RID: 85876 RVA: 0x005CD7B0 File Offset: 0x005CB9B0
	public bool TryAddNewItem(int id)
	{
		if (id == 0)
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.RouletteAssemblyItemRedDot, id);
		Singleton<EventSystem>.Instance.Emit(EEventName.RouletteRefreshNew);
		return true;
	}

	// Token: 0x06014F75 RID: 85877 RVA: 0x005CD7D5 File Offset: 0x005CB9D5
	public bool TryRemoveNewItem(int id)
	{
		return id != 0 && ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.RouletteAssemblyItemRedDot, id);
	}

	// Token: 0x06014F76 RID: 85878 RVA: 0x005CD7E8 File Offset: 0x005CB9E8
	public bool CheckHasAnyNewItem()
	{
		foreach (KeyValuePair<int, ExploreTools> keyValuePair in this.UnlockExploreSkillDataMap)
		{
			int key = keyValuePair.Key;
			ExploreTools value = keyValuePair.Value;
			if (value.CanAssemblyShow)
			{
				bool flag = false;
				foreach (int key2 in value.GetRouletteTypeArray())
				{
					RouletteListDataBase rouletteListDataBase;
					if (this.RouletteListDataMap.TryGetValue((ERouletteType)key2, out rouletteListDataBase) && rouletteListDataBase.IsRouletteOpen())
					{
						flag = true;
						break;
					}
				}
				if (flag && ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RouletteAssemblyItemRedDot, key))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06014F77 RID: 85879 RVA: 0x005CD8B0 File Offset: 0x005CBAB0
	public unsafe void UpdateRouletteData(List<ExploreSkillRoulette> exploreList)
	{
		if (exploreList.Count == 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YYZ, "当前不存在保存的轮盘数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		for (int i = 0; i < exploreList.Count; i++)
		{
			RouletteListDataBase rouletteListDataBase;
			if (this.RouletteListDataMap.TryGetValue((ERouletteType)i, out rouletteListDataBase))
			{
				rouletteListDataBase.UpdateData(exploreList[i]);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Phantom;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "轮盘列表数据";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", i);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("List", rouletteListDataBase.RouletteIdListServer);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ItemId", rouletteListDataBase.ExtraItemIdServer);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("EquipId", rouletteListDataBase.EquipExploreSkillIdServer);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRouletteSaveDataChange);
		this.TryEquipActivateRouletteExploreSkillId();
	}

	// Token: 0x06014F78 RID: 85880 RVA: 0x005CD9D0 File Offset: 0x005CBBD0
	public unsafe void UpdateRouletteDataByType(int type, ExploreSkillRoulette rouletteDataList)
	{
		RouletteListDataBase rouletteListDataBase;
		if (this.RouletteListDataMap.TryGetValue((ERouletteType)type, out rouletteListDataBase))
		{
			rouletteListDataBase.UpdateData(rouletteDataList);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "轮盘列表数据";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("List", rouletteListDataBase.RouletteIdListServer);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ItemId", rouletteListDataBase.ExtraItemIdServer);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("EquipId", rouletteListDataBase.EquipExploreSkillIdServer);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			if (this.GetCurrentExploreRouletteListData().RouletteType == (ERouletteType)type)
			{
				RouletteController.RefreshExploreSkillButton();
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRouletteSaveDataChange);
		this.TryEquipActivateRouletteExploreSkillId();
	}

	// Token: 0x06014F79 RID: 85881 RVA: 0x005CDAC4 File Offset: 0x005CBCC4
	private unsafe void TryEquipActivateRouletteExploreSkillId()
	{
		RouletteListDataBase currentExploreRouletteListData = this.GetCurrentExploreRouletteListData();
		int equipExploreSkillId = currentExploreRouletteListData.GetEquipExploreSkillId();
		if (equipExploreSkillId == 0)
		{
			return;
		}
		if (equipExploreSkillId == this.CurrentExploreSkillId)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "TryEquipActivateRoulette";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", currentExploreRouletteListData.RouletteType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EquipId", equipExploreSkillId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(equipExploreSkillId, EExploreSkillLayer.Roulette, "TryEquipActivateRouletteExploreSkillId");
		ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(equipExploreSkillId, null, true);
	}

	// Token: 0x06014F7A RID: 85882 RVA: 0x005CDB70 File Offset: 0x005CBD70
	public string GetRouletteKeyRichText(string actionName)
	{
		string result = "";
		this.InputKeyDisplayDataRef.Reset();
		if (!Singleton<InputSettingsManager>.Instance.GetActionKeyDisplayData(this.InputKeyDisplayDataRef, actionName))
		{
			return result;
		}
		string[] displayKeyIconPathList = this.InputKeyDisplayDataRef.GetDisplayKeyIconPathList(0);
		if (displayKeyIconPathList == null || displayKeyIconPathList.Length == 0)
		{
			return result;
		}
		return "<texture=" + displayKeyIconPathList[0] + ">";
	}

	// Token: 0x06014F7B RID: 85883 RVA: 0x005CDBCD File Offset: 0x005CBDCD
	public string GetRouletteMainAction(string actionName)
	{
		if (!Singleton<InputSettingsManager>.Instance.GetActionKeyDisplayData(this.InputKeyDisplayDataRef, actionName))
		{
			return actionName;
		}
		if (this.InputKeyDisplayDataRef.IsCombination)
		{
			return "组合主键";
		}
		return actionName;
	}

	// Token: 0x06014F7C RID: 85884 RVA: 0x005CDBF8 File Offset: 0x005CBDF8
	public int GetRouletteSelectConfig()
	{
		int? num = new int?(LocalStorage.GetGlobal<int>(ELocalStorageGlobalKey.GamepadRouletteSelectConfig, 0));
		return num.GetValueOrDefault(1);
	}

	// Token: 0x06014F7D RID: 85885 RVA: 0x005CDC1C File Offset: 0x005CBE1C
	public void SaveRouletteSelectConfig(int config)
	{
		LocalStorage.SetGlobal<int>(ELocalStorageGlobalKey.GamepadRouletteSelectConfig, config);
	}

	// Token: 0x06014F7E RID: 85886 RVA: 0x005CDC28 File Offset: 0x005CBE28
	public ERouletteType GetRouletteActionOpenConfig(ERouletteActionType actionType)
	{
		ERouletteType erouletteType = (actionType == ERouletteActionType.Action1) ? ERouletteType.Explore : ERouletteType.Function;
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return erouletteType;
		}
		return LocalStorage.GetPlayer<ERouletteType?>((actionType == ERouletteActionType.Action1) ? ELocalStoragePlayerKey.RouletteAction01OpenConfig : ELocalStoragePlayerKey.RouletteAction02OpenConfig, null).GetValueOrDefault(erouletteType);
	}

	// Token: 0x06014F7F RID: 85887 RVA: 0x005CDC6D File Offset: 0x005CBE6D
	public void SaveRouletteActionOpenConfig(ERouletteActionType actionType, ERouletteType type)
	{
		LocalStorage.SetPlayer<ERouletteType>((actionType == ERouletteActionType.Action1) ? ELocalStoragePlayerKey.RouletteAction01OpenConfig : ELocalStoragePlayerKey.RouletteAction02OpenConfig, type);
	}

	// Token: 0x06014F80 RID: 85888 RVA: 0x005CDC80 File Offset: 0x005CBE80
	private void SendExploreToolSwitchLogData(int id)
	{
		ExploreToolSwitchLogData exploreToolSwitchLogData = new ExploreToolSwitchLogData();
		ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(id);
		if (exploreConfigById == null)
		{
			return;
		}
		List<ExploreToolAuthorizationLogData> list = new List<ExploreToolAuthorizationLogData>();
		foreach (KeyValuePair<int, int> keyValuePair in exploreConfigById.Value.Authorization())
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(value, 0) > 0)
			{
				ExploreToolAuthorizationLogData item = new ExploreToolAuthorizationLogData(key, value);
				list.Add(item);
			}
		}
		exploreToolSwitchLogData.o_new_authorization = list;
		exploreToolSwitchLogData.i_explore_tool_id = id;
		ControllerBase<LogReportController>.Instance.LogReport(exploreToolSwitchLogData);
	}

	// Token: 0x06014F81 RID: 85889 RVA: 0x005CDD48 File Offset: 0x005CBF48
	public void SendExploreToolEquipLogData(int id, int operationType, int rouletteType, int? itemId = null)
	{
		ExploreToolEquipLogData exploreToolEquipLogData = new ExploreToolEquipLogData();
		ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(id);
		if (exploreConfigById == null)
		{
			return;
		}
		List<ExploreToolAuthorizationLogData> list = new List<ExploreToolAuthorizationLogData>();
		foreach (KeyValuePair<int, int> keyValuePair in exploreConfigById.Value.Authorization())
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(value, 0) > 0)
			{
				ExploreToolAuthorizationLogData item = new ExploreToolAuthorizationLogData(key, value);
				list.Add(item);
			}
		}
		exploreToolEquipLogData.o_new_authorization = list;
		exploreToolEquipLogData.i_explore_tool_id = id;
		exploreToolEquipLogData.i_operation = operationType;
		exploreToolEquipLogData.i_roulette_id = rouletteType;
		if (itemId != null)
		{
			exploreToolEquipLogData.i_item_id = itemId.Value;
		}
		ControllerBase<LogReportController>.Instance.LogReport(exploreToolEquipLogData);
	}

	// Token: 0x06014F82 RID: 85890 RVA: 0x005CDE34 File Offset: 0x005CC034
	public void SendExploreToolItemUseLogData(int id)
	{
		ExploreToolItemUseLogData exploreToolItemUseLogData = new ExploreToolItemUseLogData();
		global::Vector actorLocationProxy = Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy;
		exploreToolItemUseLogData.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId;
		exploreToolItemUseLogData.i_father_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.Father;
		exploreToolItemUseLogData.f_pos_x = (float)actorLocationProxy.X;
		exploreToolItemUseLogData.f_pos_y = (float)actorLocationProxy.Y;
		exploreToolItemUseLogData.f_pos_z = (float)actorLocationProxy.Z;
		exploreToolItemUseLogData.i_item_id = id;
		ControllerBase<LogReportController>.Instance.LogReport(exploreToolItemUseLogData);
	}

	// Token: 0x06014F83 RID: 85891 RVA: 0x005CDED0 File Offset: 0x005CC0D0
	public void TrySendExploreToolGeneralUseLogData(int exploreSkillId, int skillId = 0, int entityConfigId = 0)
	{
		ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(exploreSkillId);
		if (exploreConfigById == null || !exploreConfigById.Value.InputLogReport)
		{
			return;
		}
		string text = "1026_" + exploreSkillId.ToString();
		ExploreToolGeneralUseLogData exploreToolGeneralUseLogData = new ExploreToolGeneralUseLogData();
		global::Vector actorLocationProxy = Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy;
		exploreToolGeneralUseLogData.event_id = text;
		exploreToolGeneralUseLogData.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId;
		exploreToolGeneralUseLogData.i_father_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.Father;
		exploreToolGeneralUseLogData.f_pos_x = (float)actorLocationProxy.X;
		exploreToolGeneralUseLogData.f_pos_y = (float)actorLocationProxy.Y;
		exploreToolGeneralUseLogData.f_pos_z = (float)actorLocationProxy.Z;
		exploreToolGeneralUseLogData.i_skill_id = skillId;
		exploreToolGeneralUseLogData.i_entity_configId = entityConfigId;
		if (ModelBase<LogReportModel>.Instance.GetTimerAssemblyLogData(text) == null)
		{
			ModelBase<LogReportModel>.Instance.SetTimerAssemblyLogData(text, new ExploreToolAssemblyLogData(exploreSkillId.ToString()));
		}
		ControllerBase<LogReportController>.Instance.UnitLogReport(exploreToolGeneralUseLogData);
	}

	// Token: 0x0400A18D RID: 41357
	public Dictionary<ERouletteType, RouletteListDataBase> RouletteListDataMap = new Dictionary<ERouletteType, RouletteListDataBase>();

	// Token: 0x0400A18E RID: 41358
	private int EquipExploreSkillId;

	// Token: 0x0400A18F RID: 41359
	public List<int> OnSettingExploreSkillIdList = new List<int>();

	// Token: 0x0400A190 RID: 41360
	public Dictionary<int, ExploreTools> UnlockExploreSkillDataMap = new Dictionary<int, ExploreTools>();

	// Token: 0x0400A191 RID: 41361
	private readonly Dictionary<int, int> FuncOpenIdMap = new Dictionary<int, int>();

	// Token: 0x0400A192 RID: 41362
	public Dictionary<int, FuncMenuWheel> UnlockFunctionDataMap = new Dictionary<int, FuncMenuWheel>();

	// Token: 0x0400A193 RID: 41363
	private readonly Action<EFunctionType, bool> UnlockFunction1 = delegate(EFunctionType funcOpenId, bool isOpen)
	{
		int funcId;
		if (ModelBase<RouletteModel>.Instance.FuncOpenIdMap.TryGetValue((int)funcOpenId, out funcId))
		{
			if (isOpen)
			{
				ModelBase<RouletteModel>.Instance.OpenFunction(funcId);
				return;
			}
			ModelBase<RouletteModel>.Instance.CloseFunction(funcId);
		}
	};

	// Token: 0x0400A194 RID: 41364
	private readonly Action<EFunctionType, bool> UnlockFunction2 = delegate(EFunctionType funcOpenId, bool isOpen)
	{
		int funcId;
		if (ModelBase<RouletteModel>.Instance.FuncOpenIdMap.TryGetValue((int)funcOpenId, out funcId))
		{
			if (isOpen)
			{
				ModelBase<RouletteModel>.Instance.OpenFunction(funcId);
				return;
			}
			ModelBase<RouletteModel>.Instance.CloseFunction(funcId);
		}
	};

	// Token: 0x0400A195 RID: 41365
	private readonly InputKeyDisplayData InputKeyDisplayDataRef = new InputKeyDisplayData();

	// Token: 0x0400A196 RID: 41366
	public readonly Dictionary<ERouletteActionType, string> GetRouletteActionName = new Dictionary<ERouletteActionType, string>
	{
		{
			ERouletteActionType.Action1,
			"幻象探索选择界面"
		},
		{
			ERouletteActionType.Action2,
			"轮盘2"
		}
	};
}
