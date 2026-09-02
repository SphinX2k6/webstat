using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.PhantomBattle;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002479 RID: 9337
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PhantomBattleModel : ModelBase<PhantomBattleModel>
{
	// Token: 0x06012151 RID: 74065 RVA: 0x004F8108 File Offset: 0x004F6308
	public PhantomBattleModel()
	{
		this.RobotDataMap = new Dictionary<int, PhantomBattleData>();
		this.BattleDataMap = new Dictionary<int, PhantomRoleEquipmentData>();
		this.PhantomEquipmentRoleMap = new Dictionary<int, int>();
		this.PhantomInstanceMap = new Dictionary<int, PhantomBattleInstance>();
		this.PhantomBattleDataMap = new Dictionary<int, PhantomBattleData>();
		this.UnEquipVisionArray = new List<PhantomBattleData>();
		this.PhantomMeshZoom = new FVector();
		this.PhantomMeshLocation = new FVector();
		this.PhantomMeshRotator = new FRotator();
		this.LevelUpItemData = new Dictionary<int, int>();
		this.TempSaveItemList = new TItem[0];
		this.CurrentDraggingIndex = 999;
		this.MonsterSkinMap = new Dictionary<int, int[]>();
		this.MonsterSkinMonsterIdMap = new Dictionary<int, int>();
		this.VisionLevelUpMaterialPutInMode = EVisionLevelUpMaterialPutInMode.AllIn;
		this.VisionLevelUpMaterialUseType = EVisionLevelUpMaterialUseType.OnlyLevelUpMaterial;
		this.VisionLevelUpIdentify = EVisionLevelUpIdentify.DisableIdentify;
		this.QualityUnlockTips = new List<VisionUnlockQualityData>();
	}

	// Token: 0x06012152 RID: 74066 RVA: 0x004F81E1 File Offset: 0x004F63E1
	public void SetCurrentDragIndex(int index)
	{
		this.CurrentDraggingIndex = index;
	}

	// Token: 0x06012153 RID: 74067 RVA: 0x004F81EA File Offset: 0x004F63EA
	public void ClearCurrentDragIndex()
	{
		this.CurrentDraggingIndex = 999;
	}

	// Token: 0x06012154 RID: 74068 RVA: 0x004F81F7 File Offset: 0x004F63F7
	public bool CheckIfCurrentDragIndex(int index)
	{
		return this.CurrentDraggingIndex == index;
	}

	// Token: 0x06012155 RID: 74069 RVA: 0x004F8202 File Offset: 0x004F6402
	public bool CheckIfCanDrag()
	{
		return this.CurrentDraggingIndex == 999;
	}

	// Token: 0x06012156 RID: 74070 RVA: 0x004F8214 File Offset: 0x004F6414
	protected override bool OnInit()
	{
		foreach (Aki.Config.PhantomItem phantomItem in ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemList())
		{
			int key = (phantomItem.ParentMonsterId != 0) ? phantomItem.ParentMonsterId : phantomItem.MonsterId;
			int[] collection;
			if (!this.MonsterSkinMap.TryGetValue(key, out collection))
			{
				collection = new int[0];
			}
			if (phantomItem.ParentMonsterId != 0)
			{
				List<int> list = new List<int>(collection);
				list.Add(phantomItem.ItemId);
				this.MonsterSkinMap[key] = list.ToArray();
			}
			else if (phantomItem.PhantomType == 1 && phantomItem.QualityId == 2)
			{
				List<int> list2 = new List<int>();
				list2.Add(phantomItem.ItemId);
				list2.AddRange(collection);
				this.MonsterSkinMap[key] = list2.ToArray();
			}
			if (phantomItem.ParentMonsterId != 0)
			{
				this.MonsterSkinMonsterIdMap[phantomItem.MonsterId] = phantomItem.ParentMonsterId;
			}
		}
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		return true;
	}

	// Token: 0x06012157 RID: 74071 RVA: 0x004F834C File Offset: 0x004F654C
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		return true;
	}

	// Token: 0x06012158 RID: 74072 RVA: 0x004F836C File Offset: 0x004F656C
	private void OnWorldDone()
	{
		this.VisionLevelUpMaterialPutInMode = LocalStorage.GetPlayer<EVisionLevelUpMaterialPutInMode?>(ELocalStoragePlayerKey.VisionLevelUpMaterialPutInMode, null).GetValueOrDefault();
		this.VisionLevelUpMaterialUseType = LocalStorage.GetPlayer<EVisionLevelUpMaterialUseType?>(ELocalStoragePlayerKey.VisionLevelUpMaterialUseType, null).GetValueOrDefault();
		this.VisionLevelUpIdentify = LocalStorage.GetPlayer<EVisionLevelUpIdentify?>(ELocalStoragePlayerKey.VisionLevelUpIdentify, null).GetValueOrDefault();
	}

	// Token: 0x06012159 RID: 74073 RVA: 0x004F83D8 File Offset: 0x004F65D8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<UCurveFloat> GetDragCurve()
	{
		PhantomBattleModel.<GetDragCurve>d__43 <GetDragCurve>d__;
		<GetDragCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder<UCurveFloat>.Create();
		<GetDragCurve>d__.<>4__this = this;
		<GetDragCurve>d__.<>1__state = -1;
		<GetDragCurve>d__.<>t__builder.Start<PhantomBattleModel.<GetDragCurve>d__43>(ref <GetDragCurve>d__);
		return <GetDragCurve>d__.<>t__builder.Task;
	}

	// Token: 0x0601215A RID: 74074 RVA: 0x004F841C File Offset: 0x004F661C
	public void SetDefaultSkin(int monsterId, int skinId)
	{
		foreach (KeyValuePair<int, PhantomBattleData> keyValuePair in this.PhantomBattleDataMap)
		{
			PhantomBattleData value = keyValuePair.Value;
			if (monsterId == value.GetConfig().MonsterId)
			{
				value.SetSkinId(skinId);
			}
		}
	}

	// Token: 0x0601215B RID: 74075 RVA: 0x004F8488 File Offset: 0x004F6688
	public void SetUnlockSkinList(int[] skins)
	{
		this.UnlockSkin = skins;
	}

	// Token: 0x0601215C RID: 74076 RVA: 0x004F8494 File Offset: 0x004F6694
	public void ConcatUnlockSkinList(List<int> skins)
	{
		List<int> list = new List<int>(this.UnlockSkin);
		list.AddRange(skins);
		this.UnlockSkin = list.ToArray();
	}

	// Token: 0x0601215D RID: 74077 RVA: 0x004F84C0 File Offset: 0x004F66C0
	public bool GetSkinIsUnlock(int skinId)
	{
		return Array.IndexOf<int>(this.UnlockSkin, skinId) >= 0;
	}

	// Token: 0x0601215E RID: 74078 RVA: 0x004F84D4 File Offset: 0x004F66D4
	[NullableContext(2)]
	public int[] GetMonsterSkinListByMonsterId(int monsterId)
	{
		int[] result;
		if (this.MonsterSkinMap.TryGetValue(monsterId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0601215F RID: 74079 RVA: 0x004F84F4 File Offset: 0x004F66F4
	public bool GetMonsterSkinListHasNew(int itemId)
	{
		Aki.Config.PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(itemId);
		if (phantomItemById == null)
		{
			return false;
		}
		int key = (phantomItemById.Value.ParentMonsterId != 0) ? phantomItemById.Value.ParentMonsterId : phantomItemById.Value.MonsterId;
		int[] array;
		if (!this.MonsterSkinMap.TryGetValue(key, out array))
		{
			return false;
		}
		foreach (int value in array)
		{
			if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.VisionSkin, value))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012160 RID: 74080 RVA: 0x004F858C File Offset: 0x004F678C
	public int? GetMonsterSkinMonsterIdMapByMonsterId(int monsterId)
	{
		int value;
		if (this.MonsterSkinMonsterIdMap.TryGetValue(monsterId, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x06012161 RID: 74081 RVA: 0x004F85B9 File Offset: 0x004F67B9
	public void SetMaxCost(int cost)
	{
		this.CurrentMaxCost = cost;
	}

	// Token: 0x06012162 RID: 74082 RVA: 0x004F85C2 File Offset: 0x004F67C2
	public int GetMaxCost()
	{
		return this.CurrentMaxCost;
	}

	// Token: 0x06012163 RID: 74083 RVA: 0x004F85CA File Offset: 0x004F67CA
	public void SetRobotPhantomData(int incrId, PhantomTrialBattleData data)
	{
		this.RobotDataMap[incrId] = data;
	}

	// Token: 0x06012164 RID: 74084 RVA: 0x004F85DC File Offset: 0x004F67DC
	public PhantomBattleData NewPhantomBattleData(Aki.Protocol.PhantomItem phantomItemInfo)
	{
		PhantomBattleData phantomBattleData = new PhantomBattleData();
		phantomBattleData.SetData(phantomItemInfo);
		this.PhantomBattleDataMap[phantomItemInfo.IncrId] = phantomBattleData;
		this.UnEquipVisionArrayRefreshTag = true;
		return phantomBattleData;
	}

	// Token: 0x06012165 RID: 74085 RVA: 0x004F8610 File Offset: 0x004F6810
	public PhantomBattleData UpdatePhantomBattleData(Aki.Protocol.PhantomItem phantomItemInfo)
	{
		this.RemovePhantomBattleData(phantomItemInfo.IncrId);
		PhantomBattleData phantomBattleData = new PhantomBattleData();
		phantomBattleData.SetData(phantomItemInfo);
		this.PhantomBattleDataMap[phantomItemInfo.IncrId] = phantomBattleData;
		this.UnEquipVisionArrayRefreshTag = true;
		return phantomBattleData;
	}

	// Token: 0x06012166 RID: 74086 RVA: 0x004F8650 File Offset: 0x004F6850
	public void RemovePhantomBattleData(int uniqueId)
	{
		this.PhantomBattleDataMap.Remove(uniqueId);
		this.UnEquipVisionArrayRefreshTag = true;
	}

	// Token: 0x06012167 RID: 74087 RVA: 0x004F8666 File Offset: 0x004F6866
	[NullableContext(2)]
	public PhantomDataBase GetPhantomDataBase(int uniqueId)
	{
		return this.GetPhantomBattleData(uniqueId);
	}

	// Token: 0x06012168 RID: 74088 RVA: 0x004F8670 File Offset: 0x004F6870
	[NullableContext(2)]
	public PhantomBattleData GetPhantomBattleData(int uniqueId)
	{
		if (uniqueId < 0)
		{
			PhantomBattleData result;
			if (this.RobotDataMap.TryGetValue(uniqueId, out result))
			{
				return result;
			}
			return null;
		}
		else
		{
			PhantomBattleData result2;
			if (this.PhantomBattleDataMap.TryGetValue(uniqueId, out result2))
			{
				return result2;
			}
			return null;
		}
	}

	// Token: 0x06012169 RID: 74089 RVA: 0x004F86A8 File Offset: 0x004F68A8
	public PhantomBattleInstance GetPhantomInstanceByItemId(int itemId)
	{
		PhantomBattleInstance phantomBattleInstance;
		if (!this.PhantomInstanceMap.TryGetValue(itemId, out phantomBattleInstance))
		{
			phantomBattleInstance = new PhantomBattleInstance(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(itemId).Value);
			this.PhantomInstanceMap[itemId] = phantomBattleInstance;
		}
		return phantomBattleInstance;
	}

	// Token: 0x0601216A RID: 74090 RVA: 0x004F86EC File Offset: 0x004F68EC
	public LevelUpPastVisionData CreatePhantomLevelCacheData(int incId)
	{
		return new LevelUpPastVisionData
		{
			Level = this.GetPhantomBattleData(incId).GetPhantomLevel(),
			AttrListScrollData = this.GetPhantomBattleData(incId).GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false),
			SlotData = this.GetPhantomBattleData(incId).GetCurrentSlotData(),
			UniqueId = incId,
			SubProp = this.GetPhantomBattleData(incId).GetPhantomSubProp()
		};
	}

	// Token: 0x0601216B RID: 74091 RVA: 0x004F874F File Offset: 0x004F694F
	public void CachePhantomLevelUpData(LevelUpPastVisionData data)
	{
		this.PastVisionLevelUpData = data;
	}

	// Token: 0x0601216C RID: 74092 RVA: 0x004F8758 File Offset: 0x004F6958
	[NullableContext(2)]
	public LevelUpPastVisionData GetCachePhantomLevelUpData()
	{
		return this.PastVisionLevelUpData;
	}

	// Token: 0x0601216D RID: 74093 RVA: 0x004F8760 File Offset: 0x004F6960
	public ILevelUpSuccessAttributeData GetLevelUpSuccessData(int uniqueId)
	{
		ILevelInfo levelInfo = null;
		LevelUpPastVisionData cachePhantomLevelUpData = ModelBase<PhantomBattleModel>.Instance.GetCachePhantomLevelUpData();
		List<IAttributeInfo> list = new List<IAttributeInfo>();
		bool value = ModelBase<PhantomBattleModel>.Instance.CheckPhantomIfLevelMax(uniqueId);
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(uniqueId);
		if (cachePhantomLevelUpData.Level != phantomItemDataByUniqueId.GetPhantomLevel())
		{
			foreach (AttrListScrollData attrData in this.GetLevelUpSuccessAttributeData(cachePhantomLevelUpData, phantomItemDataByUniqueId))
			{
				list.Add(RoleLevelUpSuccessController.ConvertsAttrListScrollDataToAttributeInfo(attrData));
			}
			levelInfo = new LevelInfo
			{
				PreUpgradeLv = cachePhantomLevelUpData.Level,
				UpgradeLv = phantomItemDataByUniqueId.GetPhantomLevel(),
				FormatStringId = "VisionLevel",
				IsMaxLevel = new bool?(value)
			};
		}
		string title = null;
		int count = cachePhantomLevelUpData.SubProp.Count;
		int count2 = phantomItemDataByUniqueId.GetPhantomSubProp().Count;
		List<AttrListScrollData> subPropShowAttributeList = phantomItemDataByUniqueId.GetSubPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType);
		List<AttrListScrollData> list2 = new List<AttrListScrollData>();
		for (int j = count; j < count2; j++)
		{
			subPropShowAttributeList[j].AddValue = subPropShowAttributeList[j].BaseValue;
			subPropShowAttributeList[j].BaseValue = 0.0;
			list2.Add(subPropShowAttributeList[j]);
		}
		int levelUnlockSubPropSlotCount = phantomItemDataByUniqueId.GetLevelUnlockSubPropSlotCount(cachePhantomLevelUpData.Level);
		int num = phantomItemDataByUniqueId.GetLevelUnlockSubPropSlotCount(phantomItemDataByUniqueId.GetPhantomLevel()) - levelUnlockSubPropSlotCount - list2.Count;
		if (list2.Count > 0 || num > 0)
		{
			list.Add(new AttributeInfo
			{
				IsLine = new bool?(true)
			});
		}
		foreach (AttrListScrollData attrData2 in list2)
		{
			IAttributeInfo attributeInfo = RoleLevelUpSuccessController.ConvertsAttrListScrollDataToAttributeInfo(attrData2);
			attributeInfo.ShowArrow = new bool?(false);
			attributeInfo.PreText = null;
			list.Add(attributeInfo);
		}
		if (list2.Count > 0)
		{
			title = "IdentifySuccess";
		}
		if (num > 0)
		{
			for (int k = 0; k < num; k++)
			{
				list.Add(new AttributeInfo
				{
					Name = "UnlockSlot",
					ShowArrow = new bool?(false),
					PreText = "",
					CurText = ConfigMultiTextLang.GetLocalTextNew("Text_PhantomUnlock_Text", null),
					IconPath = ConfigBase<PhantomBattleConfig>.Instance.GetVisionLevelUpTexture()
				});
			}
		}
		return new LevelUpSuccessAttributeData
		{
			Title = title,
			LevelInfo = levelInfo,
			WiderScrollView = new bool?(false),
			AttributeInfo = list
		};
	}

	// Token: 0x0601216E RID: 74094 RVA: 0x004F89E4 File Offset: 0x004F6BE4
	private AttrListScrollData[] GetLevelUpSuccessAttributeData(LevelUpPastVisionData data, PhantomBattleData visionData)
	{
		List<AttrListScrollData> attrListScrollData = data.AttrListScrollData;
		List<AttrListScrollData> mainPropShowAttributeList = visionData.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false);
		int count = mainPropShowAttributeList.Count;
		int count2 = attrListScrollData.Count;
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		for (int i = 0; i < count; i++)
		{
			AttrListScrollData attrListScrollData2 = mainPropShowAttributeList[i];
			AttrListScrollData attrListScrollData3 = null;
			for (int j = 0; j < count2; j++)
			{
				if (attrListScrollData[j].Id == attrListScrollData2.Id && i == j)
				{
					attrListScrollData3 = attrListScrollData[j];
					break;
				}
			}
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attrListScrollData2.Id);
			list.Add(new AttrListScrollData(attrListScrollData2.Id, attrListScrollData3.BaseValue, attrListScrollData2.BaseValue, propertyIndexInfo.Value.Priority, attrListScrollData3.IsRatio, CommonComponentDefine.EAttributeType.VisionLevelUp));
		}
		return list.ToArray();
	}

	// Token: 0x0601216F RID: 74095 RVA: 0x004F8AC4 File Offset: 0x004F6CC4
	public void PhantomLevelUpReceiveItem(Dictionary<int, int> itemMap)
	{
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in itemMap)
		{
			int key = keyValuePair.Key;
			TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), keyValuePair.Value);
			list.Add(item);
		}
		this.TempSaveItemList = list.ToArray();
		Array.Sort<TItem>(this.TempSaveItemList, delegate(TItem a, TItem b)
		{
			CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.ItemData.ItemId);
			return ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.ItemData.ItemId).QualityId - itemConfigData.QualityId;
		});
		this.VisionLevelUpTag = true;
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<TItem>>(EEventName.PhantomLevelUpReceiveItem, list);
	}

	// Token: 0x06012170 RID: 74096 RVA: 0x004F8B84 File Offset: 0x004F6D84
	public bool GetVisionLevelUpTag()
	{
		return this.VisionLevelUpTag;
	}

	// Token: 0x06012171 RID: 74097 RVA: 0x004F8B8C File Offset: 0x004F6D8C
	public void ClearVisionLevelUp()
	{
		this.VisionLevelUpTag = false;
	}

	// Token: 0x06012172 RID: 74098 RVA: 0x004F8B95 File Offset: 0x004F6D95
	public TItem[] GetTempSaveItemList()
	{
		return this.TempSaveItemList;
	}

	// Token: 0x06012173 RID: 74099 RVA: 0x004F8BA0 File Offset: 0x004F6DA0
	public TItem? ShiftTempSaveItemList()
	{
		if (this.TempSaveItemList.Length == 0)
		{
			return null;
		}
		TItem value = this.TempSaveItemList[0];
		List<TItem> list = new List<TItem>(this.TempSaveItemList);
		list.RemoveAt(0);
		this.TempSaveItemList = list.ToArray();
		return new TItem?(value);
	}

	// Token: 0x06012174 RID: 74100 RVA: 0x004F8BF0 File Offset: 0x004F6DF0
	public void ClearTempSaveItemList()
	{
		this.TempSaveItemList = new TItem[0];
	}

	// Token: 0x06012175 RID: 74101 RVA: 0x004F8C00 File Offset: 0x004F6E00
	public IPhantomItemData[] GetVisionSortUseDataList(int filterFetterGroupId = 0, int cost = 0)
	{
		List<IPhantomItemData> list = new List<IPhantomItemData>();
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (PhantomBattleData phantomBattleData in ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleDataMap().Values)
		{
			int uniqueId = phantomBattleData.GetUniqueId();
			if ((filterFetterGroupId <= 0 || phantomBattleData.GetFetterGroupId() == filterFetterGroupId) && (cost <= 0 || phantomBattleData.GetCost() == cost) && phantomBattleData.CheckIfHaveSelectRecommendSubAttr() && phantomBattleData.CheckIfHaveSelectRecommendMainAttr() && phantomBattleData.CheckIfHaveSelectMainPhantomType())
			{
				global::PhantomItemData phantomItemData = instance.GetPhantomItemData(uniqueId);
				Aki.Config.PhantomItem config = phantomBattleData.GetConfig();
				CSharpScript.Game.PhantomBattle.PhantomItemData item = new CSharpScript.Game.PhantomBattle.PhantomItemData
				{
					IsPhantomData = true,
					Id = phantomBattleData.GetUniqueId(),
					Quality = config.QualityId,
					IsEquip = ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(uniqueId),
					Role = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId).GetValueOrDefault(),
					Level = phantomBattleData.GetPhantomLevel(),
					IsBreach = phantomBattleData.IsBreach(),
					MonsterId = config.MonsterId,
					MainPropMap = phantomBattleData.GetMainPropArray(),
					SubPropMap = phantomBattleData.GetSubPropArray(),
					IsLock = phantomItemData.GetIsLock(),
					IsDeprecate = phantomItemData.GetIsDeprecated(),
					ConfigId = phantomItemData.GetConfigId(),
					Rarity = config.Rarity
				};
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06012176 RID: 74102 RVA: 0x004F8DA4 File Offset: 0x004F6FA4
	public IPhantomItemData[] GetVisionSortUseDataListByMultiGroup(IReadOnlySet<int> filterFetterGroupIds, int cost = 0)
	{
		List<IPhantomItemData> list = new List<IPhantomItemData>();
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (PhantomBattleData phantomBattleData in ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleDataMap().Values)
		{
			int uniqueId = phantomBattleData.GetUniqueId();
			if ((filterFetterGroupIds.Count <= 0 || filterFetterGroupIds.Contains(phantomBattleData.GetFetterGroupId())) && (cost <= 0 || phantomBattleData.GetCost() == cost) && phantomBattleData.CheckIfHaveSelectRecommendSubAttr() && phantomBattleData.CheckIfHaveSelectRecommendMainAttr() && phantomBattleData.CheckIfHaveSelectMainPhantomType())
			{
				global::PhantomItemData phantomItemData = instance.GetPhantomItemData(uniqueId);
				Aki.Config.PhantomItem config = phantomBattleData.GetConfig();
				CSharpScript.Game.PhantomBattle.PhantomItemData item = new CSharpScript.Game.PhantomBattle.PhantomItemData
				{
					IsPhantomData = true,
					Id = phantomBattleData.GetUniqueId(),
					Quality = config.QualityId,
					IsEquip = ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(uniqueId),
					Role = ControllerBase<PhantomBattleController>.Instance.GetEquipRole(uniqueId).GetValueOrDefault(),
					Level = phantomBattleData.GetPhantomLevel(),
					IsBreach = phantomBattleData.IsBreach(),
					MonsterId = config.MonsterId,
					MainPropMap = phantomBattleData.GetMainPropArray(),
					SubPropMap = phantomBattleData.GetSubPropArray(),
					IsLock = phantomItemData.GetIsLock(),
					IsDeprecate = phantomItemData.GetIsDeprecated(),
					ConfigId = phantomItemData.GetConfigId(),
					Rarity = config.Rarity
				};
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06012177 RID: 74103 RVA: 0x004F8F50 File Offset: 0x004F7150
	public Dictionary<int, PhantomBattleData> GetPhantomBattleDataMap()
	{
		return this.PhantomBattleDataMap;
	}

	// Token: 0x06012178 RID: 74104 RVA: 0x004F8F58 File Offset: 0x004F7158
	public PhantomBattleData[] GetUnEquipVisionArray()
	{
		if (this.UnEquipVisionArrayRefreshTag)
		{
			this.UnEquipVisionArray = new List<PhantomBattleData>();
			this.UnEquipVisionArrayRefreshTag = false;
			foreach (KeyValuePair<int, PhantomBattleData> keyValuePair in this.GetPhantomBattleDataMap())
			{
				if (!this.CheckPhantomIsEquip(keyValuePair.Key))
				{
					this.UnEquipVisionArray.Add(keyValuePair.Value);
				}
			}
		}
		return this.UnEquipVisionArray.ToArray();
	}

	// Token: 0x06012179 RID: 74105 RVA: 0x004F8FEC File Offset: 0x004F71EC
	public void UpdateRoleEquipmentData(RolePhantomEquipInfo data)
	{
		PhantomRoleEquipmentData battleDataById = this.GetBattleDataById(data.RoleId);
		foreach (int key in battleDataById.GetIncrIdList())
		{
			this.PhantomEquipmentRoleMap.Remove(key);
		}
		foreach (int num in data.PhantomItemIncrId)
		{
			int? phantomEquipOnRoleId = this.GetPhantomEquipOnRoleId(num);
			int? num2 = phantomEquipOnRoleId;
			int num3 = 0;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				this.GetBattleDataById(phantomEquipOnRoleId.Value).RemoveIncrIdLocal(num);
			}
			this.PhantomEquipmentRoleMap[num] = data.RoleId;
		}
		this.UnEquipVisionArrayRefreshTag = true;
		battleDataById.Phrase(data);
	}

	// Token: 0x0601217A RID: 74106 RVA: 0x004F90E4 File Offset: 0x004F72E4
	public void UpdateRoleEquipmentPropData(RolePhantomPropInfo data)
	{
		this.GetBattleDataById(data.RoleId).Phrase(data);
	}

	// Token: 0x0601217B RID: 74107 RVA: 0x004F90F8 File Offset: 0x004F72F8
	public void DeleteBattleData(int roleId)
	{
		PhantomRoleEquipmentData phantomRoleEquipmentData;
		if (!this.BattleDataMap.TryGetValue(roleId, out phantomRoleEquipmentData))
		{
			return;
		}
		foreach (int key in phantomRoleEquipmentData.GetIncrIdList())
		{
			this.PhantomEquipmentRoleMap.Remove(key);
		}
		this.UnEquipVisionArrayRefreshTag = true;
		this.BattleDataMap.Remove(roleId);
	}

	// Token: 0x0601217C RID: 74108 RVA: 0x004F9178 File Offset: 0x004F7378
	public PhantomRoleEquipmentData GetBattleDataById(int roleId)
	{
		PhantomRoleEquipmentData phantomRoleEquipmentData;
		if (!this.BattleDataMap.TryGetValue(roleId, out phantomRoleEquipmentData))
		{
			phantomRoleEquipmentData = new PhantomRoleEquipmentData();
		}
		this.BattleDataMap[roleId] = phantomRoleEquipmentData;
		return phantomRoleEquipmentData;
	}

	// Token: 0x0601217D RID: 74109 RVA: 0x004F91A9 File Offset: 0x004F73A9
	public bool CheckPhantomIsEquip(int uniqueId)
	{
		return uniqueId < 0 || (uniqueId != 0 && this.PhantomEquipmentRoleMap.ContainsKey(uniqueId));
	}

	// Token: 0x0601217E RID: 74110 RVA: 0x004F91C4 File Offset: 0x004F73C4
	public bool CheckPhantomIsMain(int uniqueId)
	{
		if (uniqueId < 0)
		{
			return (this.GetPhantomDataBase(uniqueId) as PhantomTrialBattleData).GetIfMain();
		}
		if (!this.CheckPhantomIsEquip(uniqueId))
		{
			return false;
		}
		int roleId = this.PhantomEquipmentRoleMap[uniqueId];
		return this.GetBattleDataById(roleId).CheckPhantomIsMain(uniqueId);
	}

	// Token: 0x0601217F RID: 74111 RVA: 0x004F920C File Offset: 0x004F740C
	public bool CheckPhantomIsSub(int uniqueId)
	{
		if (!this.CheckPhantomIsEquip(uniqueId))
		{
			return false;
		}
		int roleId = this.PhantomEquipmentRoleMap[uniqueId];
		return this.GetBattleDataById(roleId).CheckPhantomIsSub(uniqueId);
	}

	// Token: 0x06012180 RID: 74112 RVA: 0x004F9240 File Offset: 0x004F7440
	public int? GetPhantomEquipOnRoleId(int uniqueId)
	{
		if (!this.CheckPhantomIsEquip(uniqueId))
		{
			return null;
		}
		return new int?(this.PhantomEquipmentRoleMap[uniqueId]);
	}

	// Token: 0x06012181 RID: 74113 RVA: 0x004F9271 File Offset: 0x004F7471
	public bool CheckPhantomIndexIsEquipOnRole(int roleId, int index)
	{
		return this.GetBattleDataById(roleId).GetIndexPhantomId(index) != -1;
	}

	// Token: 0x06012182 RID: 74114 RVA: 0x004F9286 File Offset: 0x004F7486
	public int GetPhantomSumLevelByRoleId(int roleId)
	{
		return this.GetBattleDataById(roleId).GetSumEquipLevel();
	}

	// Token: 0x06012183 RID: 74115 RVA: 0x004F9294 File Offset: 0x004F7494
	public bool GetPhantomIsUnlock(int monsterId)
	{
		foreach (KeyValuePair<int, List<ICalabashDevelopConditionState>> keyValuePair in ModelBase<CalabashModel>.Instance.GetUnlockCalabashDevelopRewards())
		{
			if (monsterId == keyValuePair.Key)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012184 RID: 74116 RVA: 0x004F92F8 File Offset: 0x004F74F8
	public bool CheckPhantomIfLevelMax(int uniqueId)
	{
		PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(uniqueId);
		return phantomItemDataByUniqueId.GetPhantomLevel() == ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityByItemQuality(phantomItemDataByUniqueId.GetQuality()).Value.LevelLimit;
	}

	// Token: 0x06012185 RID: 74117 RVA: 0x004F9339 File Offset: 0x004F7539
	public bool CheckMonsterIsEquipOnRole(int roleId, int monsterId)
	{
		return this.GetBattleDataById(roleId).CheckMonsterIsEquip(monsterId);
	}

	// Token: 0x06012186 RID: 74118 RVA: 0x004F9348 File Offset: 0x004F7548
	public int GetVisionIndexOnRole(int uniqueId, int roleId)
	{
		return this.GetBattleDataById(roleId).GetIndexPhantomId(uniqueId);
	}

	// Token: 0x06012187 RID: 74119 RVA: 0x004F9358 File Offset: 0x004F7558
	public bool GetRoleIfEquipVision(int roleId)
	{
		List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIncrIdList();
		int count = incrIdList.Count;
		for (int i = 0; i < count; i++)
		{
			if (incrIdList[i] != 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012188 RID: 74120 RVA: 0x004F9395 File Offset: 0x004F7595
	public int GetRoleIndexPhantomId(int roleId, int index)
	{
		return this.GetBattleDataById(roleId).GetIndexPhantomId(index);
	}

	// Token: 0x06012189 RID: 74121 RVA: 0x004F93A4 File Offset: 0x004F75A4
	public int GetPhantomIndexOfRole(int roleId, int phantomId)
	{
		List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIncrIdList();
		int count = incrIdList.Count;
		for (int i = 0; i < count; i++)
		{
			if (incrIdList[i] == phantomId)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x0601218A RID: 74122 RVA: 0x004F93E2 File Offset: 0x004F75E2
	public EEquipType GetRolePhantomEquipState(int roleId, int index, int uniqueId)
	{
		if (!this.CheckPhantomIsEquip(uniqueId))
		{
			return EEquipType.Equip;
		}
		return this.GetBattleDataById(roleId).GetPhantomOperationState(index, uniqueId);
	}

	// Token: 0x0601218B RID: 74123 RVA: 0x004F9400 File Offset: 0x004F7600
	public int GetPhantomMaxLevel(int uniqueId)
	{
		PhantomBattleData phantomBattleData = this.GetPhantomBattleData(uniqueId);
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomQualityByItemQuality(phantomBattleData.GetQuality()).Value.LevelLimit;
	}

	// Token: 0x0601218C RID: 74124 RVA: 0x004F9438 File Offset: 0x004F7638
	public FTransform GetMeshTransform(int itemId)
	{
		FRotator meshRotator = this.GetMeshRotator(itemId);
		FVector meshLocation = this.GetMeshLocation(itemId);
		FVector meshZoom = this.GetMeshZoom(itemId);
		return new FTransform(ref meshRotator, ref meshLocation, ref meshZoom);
	}

	// Token: 0x0601218D RID: 74125 RVA: 0x004F9468 File Offset: 0x004F7668
	private FVector GetMeshZoom(int itemId)
	{
		float[] modelZoom = this.GetPhantomInstanceByItemId(itemId).GetModelZoom();
		if (modelZoom.Length != 0)
		{
			this.PhantomMeshZoom.Set(modelZoom[0], modelZoom[1], modelZoom[2]);
			return this.PhantomMeshZoom;
		}
		return new FVector();
	}

	// Token: 0x0601218E RID: 74126 RVA: 0x004F94A8 File Offset: 0x004F76A8
	private FVector GetMeshLocation(int itemId)
	{
		float[] modelLocation = this.GetPhantomInstanceByItemId(itemId).GetModelLocation();
		if (modelLocation.Length != 0)
		{
			this.PhantomMeshLocation.Set(modelLocation[0], modelLocation[1], modelLocation[2]);
			return this.PhantomMeshLocation;
		}
		return new FVector();
	}

	// Token: 0x0601218F RID: 74127 RVA: 0x004F94E8 File Offset: 0x004F76E8
	private FRotator GetMeshRotator(int itemId)
	{
		float[] modelRotator = this.GetPhantomInstanceByItemId(itemId).GetModelRotator();
		if (modelRotator.Length != 0)
		{
			this.PhantomMeshRotator.Roll = modelRotator[0];
			this.PhantomMeshRotator.Pitch = modelRotator[1];
			this.PhantomMeshRotator.Yaw = modelRotator[2];
			return this.PhantomMeshRotator;
		}
		return new FRotator();
	}

	// Token: 0x06012190 RID: 74128 RVA: 0x004F953C File Offset: 0x004F773C
	public string GetStandAnim(int itemId)
	{
		return this.GetPhantomInstanceByItemId(itemId).GetStandAnim();
	}

	// Token: 0x06012191 RID: 74129 RVA: 0x004F954A File Offset: 0x004F774A
	public EVisionLevelUpMaterialPutInMode GetVisionLevelUpMaterialPutInMode()
	{
		return this.VisionLevelUpMaterialPutInMode;
	}

	// Token: 0x06012192 RID: 74130 RVA: 0x004F9552 File Offset: 0x004F7752
	public void SetVisionLevelUpMaterialPutInMode(EVisionLevelUpMaterialPutInMode mode)
	{
		if (this.VisionLevelUpMaterialPutInMode == mode)
		{
			return;
		}
		this.VisionLevelUpMaterialPutInMode = mode;
		LocalStorage.SetPlayer<EVisionLevelUpMaterialPutInMode>(ELocalStoragePlayerKey.VisionLevelUpMaterialPutInMode, mode);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionLevelUpMaterialPutInModeChange);
	}

	// Token: 0x06012193 RID: 74131 RVA: 0x004F957E File Offset: 0x004F777E
	public EVisionLevelUpMaterialUseType GetVisionLevelUpMaterialUseType()
	{
		return this.VisionLevelUpMaterialUseType;
	}

	// Token: 0x06012194 RID: 74132 RVA: 0x004F9586 File Offset: 0x004F7786
	public void SetVisionLevelUpMaterialUseType(EVisionLevelUpMaterialUseType type)
	{
		if (this.VisionLevelUpMaterialUseType == type)
		{
			return;
		}
		this.VisionLevelUpMaterialUseType = type;
		LocalStorage.SetPlayer<EVisionLevelUpMaterialUseType>(ELocalStoragePlayerKey.VisionLevelUpMaterialUseType, type);
	}

	// Token: 0x06012195 RID: 74133 RVA: 0x004F95A2 File Offset: 0x004F77A2
	public EVisionLevelUpIdentify GetVisionLevelUpIdentify()
	{
		return this.VisionLevelUpIdentify;
	}

	// Token: 0x06012196 RID: 74134 RVA: 0x004F95AA File Offset: 0x004F77AA
	public void SetVisionLevelUpIdentify(EVisionLevelUpIdentify type)
	{
		if (this.VisionLevelUpIdentify == type)
		{
			return;
		}
		this.VisionLevelUpIdentify = type;
		LocalStorage.SetPlayer<EVisionLevelUpIdentify>(ELocalStoragePlayerKey.VisionLevelUpIdentify, type);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionLevelUpIdentifyChange);
	}

	// Token: 0x06012197 RID: 74135 RVA: 0x004F95D9 File Offset: 0x004F77D9
	public PhantomBattleData GetPhantomBattleDataByPhantomItem(Aki.Protocol.PhantomItem data)
	{
		PhantomBattleData phantomBattleData = new PhantomBattleData();
		phantomBattleData.SetData(data);
		return phantomBattleData;
	}

	// Token: 0x06012198 RID: 74136 RVA: 0x004F95E7 File Offset: 0x004F77E7
	public void AddNeedCameraFocusMethodDisableViewCount()
	{
		this.NeedCameraFocusMethodDisableViewCount++;
		this.UpdateCameraFocusMethod();
	}

	// Token: 0x06012199 RID: 74137 RVA: 0x004F95FD File Offset: 0x004F77FD
	public void ReduceNeedCameraFocusMethodDisableViewCount()
	{
		this.NeedCameraFocusMethodDisableViewCount--;
		this.UpdateCameraFocusMethod();
	}

	// Token: 0x0601219A RID: 74138 RVA: 0x004F9614 File Offset: 0x004F7814
	public void UpdateCameraFocusMethod()
	{
		ECameraFocusMethod cameraFocusMethod = (this.NeedCameraFocusMethodDisableViewCount > 0) ? ECameraFocusMethod.Disable : ECameraFocusMethod.Manual;
		UiCameraManager.Get().GetUiCameraComponent<UiCameraPostEffectComponent>().SetCameraFocusMethod(cameraFocusMethod);
	}

	// Token: 0x0601219B RID: 74139 RVA: 0x004F9640 File Offset: 0x004F7840
	public PhantomFetter[] GetFetterListByRoleId(int roleId)
	{
		List<int> targetRoleFetterList = this.GetTargetRoleFetterList(roleId);
		if (targetRoleFetterList.Count == 0)
		{
			return new PhantomFetter[0];
		}
		List<PhantomFetter> list = new List<PhantomFetter>();
		foreach (int id in targetRoleFetterList)
		{
			list.Add(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(id));
		}
		return list.ToArray();
	}

	// Token: 0x0601219C RID: 74140 RVA: 0x004F96BC File Offset: 0x004F78BC
	public void UpdateFetterList(int roleId)
	{
		RolePhantomData phantomData = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true).GetPhantomData();
		Dictionary<int, PhantomDataBase> dataMap = phantomData.GetDataMap();
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in dataMap)
		{
			PhantomDataBase value = keyValuePair.Value;
			if (value != null)
			{
				list.Add(value.GetIncrId());
			}
		}
		phantomData.ClearPhantomFettersList();
		this.DoFettersList(list.ToArray(), phantomData.GetPhantomFettersList());
	}

	// Token: 0x0601219D RID: 74141 RVA: 0x004F9754 File Offset: 0x004F7954
	private void DoFettersList(int[] incIdArray, List<int> outList)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int uniqueId in incIdArray)
		{
			PhantomDataBase phantomDataBase = this.GetPhantomDataBase(uniqueId);
			if (phantomDataBase != null)
			{
				int num;
				if (!dictionary.TryGetValue(phantomDataBase.GetFetterGroupId(), out num))
				{
					num = 0;
				}
				int value = num + 1;
				dictionary[phantomDataBase.GetFetterGroupId()] = value;
			}
		}
		foreach (int item in ConfigBase<PhantomBattleConfig>.Instance.GetFetterResultBySuitMap(dictionary))
		{
			outList.Add(item);
		}
	}

	// Token: 0x0601219E RID: 74142 RVA: 0x004F9800 File Offset: 0x004F7A00
	public int[] GetPreviewFetterAdd(PhantomDataBase phantomData, int index, int roleId)
	{
		List<int> incrIdList = this.GetBattleDataById(roleId).GetIncrIdList();
		List<int> list = new List<int>();
		int count = incrIdList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.GetPhantomBattleData(incrIdList[i]) != null && i != index)
			{
				list.Add(incrIdList[i]);
			}
		}
		List<int> list2 = new List<int>();
		List<int> targetRoleFetterList = this.GetTargetRoleFetterList(roleId);
		List<int> list3 = new List<int>();
		list.Add(phantomData.GetIncrId());
		this.DoFettersList(list.ToArray(), list2);
		foreach (int item in list2)
		{
			if (targetRoleFetterList.IndexOf(item) < 0)
			{
				list3.Add(item);
			}
		}
		return list3.ToArray();
	}

	// Token: 0x0601219F RID: 74143 RVA: 0x004F98E4 File Offset: 0x004F7AE4
	public int[] GetPreviewFettersDel(PhantomDataBase phantomData, int index, int roleId)
	{
		List<int> incrIdList = this.GetBattleDataById(roleId).GetIncrIdList();
		List<int> list = new List<int>();
		int count = incrIdList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.GetPhantomBattleData(incrIdList[i]) != null && i != index)
			{
				list.Add(incrIdList[i]);
			}
		}
		List<int> list2 = new List<int>();
		List<int> targetRoleFetterList = this.GetTargetRoleFetterList(roleId);
		List<int> list3 = new List<int>();
		list.Add(phantomData.GetIncrId());
		this.DoFettersList(list.ToArray(), list2);
		foreach (int num in targetRoleFetterList)
		{
			bool flag = false;
			using (List<int>.Enumerator enumerator2 = list2.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current == num)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				list3.Add(num);
			}
		}
		return list3.ToArray();
	}

	// Token: 0x060121A0 RID: 74144 RVA: 0x004F99FC File Offset: 0x004F7BFC
	public bool CheckFetterActiveState(int roleId, int fetterId)
	{
		PhantomFetter[] fetterListByRoleId = this.GetFetterListByRoleId(roleId);
		if (fetterListByRoleId == null || fetterListByRoleId.Length == 0)
		{
			return false;
		}
		foreach (PhantomFetter phantomFetter in fetterListByRoleId)
		{
			if (phantomFetter.Id == fetterId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060121A1 RID: 74145 RVA: 0x004F9A40 File Offset: 0x004F7C40
	public int[] GetTargetCanActiveFettersList(int incId)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		PhantomDataBase phantomDataBase = this.GetPhantomDataBase(incId);
		List<int> list = new List<int>();
		if (phantomDataBase != null)
		{
			dictionary[phantomDataBase.GetFetterGroupId()] = 999;
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			foreach (KeyValuePair<int, int> keyValuePair2 in ConfigPhantomFetterGroupById.GetConfig(keyValuePair.Key, true).Value.FetterMap())
			{
				int key = keyValuePair2.Key;
				int value = keyValuePair2.Value;
				if (keyValuePair.Value >= key)
				{
					int item = value;
					list.Add(item);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060121A2 RID: 74146 RVA: 0x004F9B3C File Offset: 0x004F7D3C
	public VisionFetterData[] GetRoleFetterData(int roleId)
	{
		List<VisionFetterData> list = new List<VisionFetterData>();
		List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleId).GetIncrIdList();
		int count = incrIdList.Count;
		List<PhantomDataBase> list2 = new List<PhantomDataBase>();
		for (int i = 0; i < count; i++)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incrIdList[i]);
			if (phantomBattleData != null)
			{
				list2.Add(phantomBattleData);
			}
		}
		Dictionary<int, int> dictionary = PhantomDataBase.CalculateFetterByPhantomBattleData(list2);
		for (int j = 0; j < count; j++)
		{
			PhantomBattleData phantomBattleData2 = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incrIdList[j]);
			if (phantomBattleData2 != null)
			{
				PhantomFetterGroup? config = ConfigPhantomFetterGroupById.GetConfig(phantomBattleData2.GetFetterGroupId(), true);
				int fetterMapLength = config.Value.FetterMapLength;
				for (int k = 0; k < fetterMapLength; k++)
				{
					DicIntInt? dicIntInt = config.Value.FetterMap(k);
					int num;
					int num2;
					list.Add(new VisionFetterData
					{
						FetterId = dicIntInt.Value.Value,
						FetterGroupId = phantomBattleData2.GetFetterGroupId(),
						ActiveFetterGroupNum = (dictionary.TryGetValue(phantomBattleData2.GetFetterGroupId(), out num) ? num : 0),
						ActiveState = (dictionary.TryGetValue(phantomBattleData2.GetFetterGroupId(), out num2) && num2 >= dicIntInt.Value.Key)
					});
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060121A3 RID: 74147 RVA: 0x004F9CAD File Offset: 0x004F7EAD
	public List<int> GetTargetRoleFetterList(int roleId)
	{
		return ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true).GetPhantomData().GetPhantomFettersList();
	}

	// Token: 0x060121A4 RID: 74148 RVA: 0x004F9CC8 File Offset: 0x004F7EC8
	public ItemInfo[] GetPhantomLevelUpItemSortList(int uniqueId)
	{
		List<ItemInfo> list = new List<ItemInfo>();
		IReadOnlyList<PhantomExpItem> phantomExpItemList = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemList();
		if (phantomExpItemList != null)
		{
			foreach (PhantomExpItem phantomExpItem in phantomExpItemList)
			{
				ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(phantomExpItem.ItemId);
				if (config != null)
				{
					list.Add(config.Value);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060121A5 RID: 74149 RVA: 0x004F9D4C File Offset: 0x004F7F4C
	public bool GetIfHasMonsterInInventory(int monsterId)
	{
		int[] phantomItemIdArrayByMonsterId = this.GetPhantomItemIdArrayByMonsterId(monsterId);
		if (phantomItemIdArrayByMonsterId == null || phantomItemIdArrayByMonsterId.Length == 0)
		{
			return false;
		}
		bool result = false;
		foreach (int itemConfigId in phantomItemIdArrayByMonsterId)
		{
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemConfigId, 0) > 0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x060121A6 RID: 74150 RVA: 0x004F9D98 File Offset: 0x004F7F98
	public bool CheckPhantomIfNewQuality(int uniqueId)
	{
		PhantomDataBase phantomDataBase = this.GetPhantomDataBase(uniqueId);
		bool flag = false;
		foreach (KeyValuePair<int, PhantomBattleData> keyValuePair in this.PhantomBattleDataMap)
		{
			int monsterId = keyValuePair.Value.GetMonsterId(false);
			int? num = (phantomDataBase != null) ? new int?(phantomDataBase.GetMonsterId(false)) : null;
			if ((monsterId == num.GetValueOrDefault() & num != null) && keyValuePair.Key != uniqueId && keyValuePair.Value.GetQuality() == phantomDataBase.GetQuality())
			{
				flag = true;
				break;
			}
		}
		return !flag;
	}

	// Token: 0x060121A7 RID: 74151 RVA: 0x004F9E54 File Offset: 0x004F8054
	public string GetEquipRoleName(int uniqueId)
	{
		int? phantomEquipOnRoleId = ModelBase<PhantomBattleModel>.Instance.GetPhantomEquipOnRoleId(uniqueId);
		int? num = phantomEquipOnRoleId;
		int num2 = 0;
		if (num.GetValueOrDefault() > num2 & num != null)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(phantomEquipOnRoleId.Value);
			return ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
		}
		return "";
	}

	// Token: 0x060121A8 RID: 74152 RVA: 0x004F9EB8 File Offset: 0x004F80B8
	public int GetRoleCurrentPhantomCost(int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		int num = 0;
		if (roleDataById != null && roleDataById.IsTrialRole())
		{
			Dictionary<int, PhantomDataBase> dataMap = roleDataById.GetPhantomData().GetDataMap();
			for (int i = 0; i < 5; i++)
			{
				PhantomDataBase phantomDataBase;
				if (dataMap.TryGetValue(i, out phantomDataBase) && phantomDataBase != null)
				{
					num += phantomDataBase.GetCost();
				}
			}
		}
		else
		{
			foreach (int uniqueId in this.GetBattleDataById(roleId).GetIncrIdList())
			{
				PhantomBattleData phantomBattleData = this.GetPhantomBattleData(uniqueId);
				if (phantomBattleData != null)
				{
					num += phantomBattleData.GetCost();
				}
			}
		}
		return num;
	}

	// Token: 0x060121A9 RID: 74153 RVA: 0x004F9F74 File Offset: 0x004F8174
	public int GetLevelUpNeedCost(int exp)
	{
		return (int)Math.Floor((double)((float)exp * ConfigBase<PhantomBattleConfig>.Instance.GetPhantomLevelUpCostRatio()));
	}

	// Token: 0x060121AA RID: 74154 RVA: 0x004F9F8A File Offset: 0x004F818A
	public void ResetLevelUpItemData()
	{
		this.LevelUpItemData.Clear();
	}

	// Token: 0x060121AB RID: 74155 RVA: 0x004F9F98 File Offset: 0x004F8198
	public int[] GetPhantomItemIdArrayByMonsterId(int monsterId)
	{
		IEnumerable<Aki.Config.PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId);
		List<int> list = new List<int>();
		foreach (Aki.Config.PhantomItem phantomItem in phantomItemByMonsterId)
		{
			list.Add(phantomItem.ItemId);
		}
		return list.ToArray();
	}

	// Token: 0x060121AC RID: 74156 RVA: 0x004F9FFC File Offset: 0x004F81FC
	public int GetMonsterRarity(int monsterId)
	{
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId)[0].Rarity;
	}

	// Token: 0x060121AD RID: 74157 RVA: 0x004FA022 File Offset: 0x004F8222
	public AttrListScrollData[] GetShowAttrList(int roleId)
	{
		List<AttrListScrollData> propShowAttributeList = this.GetBattleDataById(roleId).GetPropShowAttributeList();
		propShowAttributeList.Sort(new Comparison<AttrListScrollData>(this.SortAttrList));
		return propShowAttributeList.ToArray();
	}

	// Token: 0x060121AE RID: 74158 RVA: 0x004FA047 File Offset: 0x004F8247
	public List<AttrListScrollData> GetExtraAttrList(int roleId)
	{
		List<AttrListScrollData> propDetailAttributeList = this.GetBattleDataById(roleId).GetPropDetailAttributeList();
		propDetailAttributeList.Sort(new Comparison<AttrListScrollData>(this.SortAttrList));
		return propDetailAttributeList;
	}

	// Token: 0x060121AF RID: 74159 RVA: 0x004FA068 File Offset: 0x004F8268
	public int[] GetFetterGroupMonsterIdArray(int fetterGroupId)
	{
		int[] result;
		if (this.GetFetterGroupMonsterMap().TryGetValue(fetterGroupId, out result))
		{
			return result;
		}
		return new int[0];
	}

	// Token: 0x060121B0 RID: 74160 RVA: 0x004FA090 File Offset: 0x004F8290
	public int GetMonsterFindCountByMonsterIdArray(int[] monsterIdList)
	{
		int num = 0;
		foreach (int id in monsterIdList)
		{
			if (ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, id) != null)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060121B1 RID: 74161 RVA: 0x004FA0C8 File Offset: 0x004F82C8
	public int GetMonsterFindCountByMonsterIdArrayWithoutCost4(int[] monsterIdList)
	{
		int num = 0;
		foreach (int num2 in monsterIdList)
		{
			if (ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, num2) != null)
			{
				IReadOnlyList<Aki.Config.PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(num2);
				if (phantomItemByMonsterId != null && phantomItemByMonsterId.Count != 0)
				{
					int rarity = phantomItemByMonsterId[0].Rarity;
					if (ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost != 4)
					{
						num++;
					}
				}
			}
		}
		return num;
	}

	// Token: 0x060121B2 RID: 74162 RVA: 0x004FA14C File Offset: 0x004F834C
	public Dictionary<int, int[]> GetFetterGroupMonsterMap()
	{
		if (this.FetterGroupMonsterMap != null)
		{
			return this.FetterGroupMonsterMap;
		}
		this.FetterGroupMonsterMap = new Dictionary<int, int[]>();
		foreach (PhantomFetterGroup phantomFetterGroup in ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupArray())
		{
			int[] fetterGroupSourceMonster = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupSourceMonster(phantomFetterGroup.Id);
			List<int> list = new List<int>();
			foreach (int item in fetterGroupSourceMonster)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
			this.FetterGroupMonsterMap[phantomFetterGroup.Id] = list.ToArray();
		}
		return this.FetterGroupMonsterMap;
	}

	// Token: 0x060121B3 RID: 74163 RVA: 0x004FA210 File Offset: 0x004F8410
	public AttrListScrollData[] GetTrialRoleDetailAttrList(int roleDataId)
	{
		IEnumerable<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("VisionMainViewExtraAttribute");
		AttrListScrollData[] trialRoleAttrList = this.GetTrialRoleAttrList(roleDataId);
		int num = trialRoleAttrList.Length;
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		foreach (int num2 in intArrayConfig)
		{
			PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(num2);
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				if (trialRoleAttrList[i].Id == num2)
				{
					list.Add(trialRoleAttrList[i]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(new AttrListScrollData(num2, 0.0, 0.0, propertyIndexInfo.Value.Priority, false, CommonComponentDefine.EAttributeType.PhantomType));
			}
		}
		return list.ToArray();
	}

	// Token: 0x060121B4 RID: 74164 RVA: 0x004FA2EC File Offset: 0x004F84EC
	public AttrListScrollData[] GetTrialRoleAttrList(int roleDataId)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		RoleDataBase roleRobotData = ModelBase<RoleModel>.Instance.GetRoleRobotData(roleDataId);
		IReadOnlyList<PropertyIndex> propertyIndexList = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexList();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		List<AttributeValueData> list2 = new List<AttributeValueData>();
		foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in roleRobotData.GetPhantomData().GetDataMap())
		{
			PhantomTrialBattleData phantomTrialBattleData = keyValuePair.Value as PhantomTrialBattleData;
			foreach (AttributeValueData item in phantomTrialBattleData.GetMainTrailProp().Values)
			{
				list2.Add(item);
			}
			foreach (AttributeValueData item2 in phantomTrialBattleData.GetSubTrailPropMap().Values)
			{
				list2.Add(item2);
			}
		}
		this.CalculateAttribute(list2.ToArray(), dictionary, roleDataId);
		foreach (PropertyIndex propertyIndex in propertyIndexList)
		{
			if (propertyIndex.IsShow)
			{
				PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(propertyIndex.Id);
				int num;
				if (!dictionary.TryGetValue(propertyIndex.Id, out num))
				{
					num = 0;
				}
				int num2 = num;
				list.Add(new AttrListScrollData(propertyIndex.Id, 0.0, (double)num2, propertyIndexInfo.Value.Priority, false, CommonComponentDefine.EAttributeType.PhantomType));
			}
		}
		list.Sort(new Comparison<AttrListScrollData>(this.SortAttrList));
		return list.ToArray();
	}

	// Token: 0x060121B5 RID: 74165 RVA: 0x004FA4D0 File Offset: 0x004F86D0
	private void CalculateAttribute(AttributeValueData[] attributeDataList, Dictionary<int, int> outMap, int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		foreach (AttributeValueData attributeValueData in attributeDataList)
		{
			int num = attributeValueData.AttributeId;
			if (attributeValueData.AttributeId > 10000)
			{
				num -= 10000;
			}
			int num2;
			if (attributeValueData.IsRatio)
			{
				num2 = (int)((double)roleDataById.GetBaseAttributeValueById(num) * (attributeValueData.AttributeValue / 10000.0));
			}
			else
			{
				num2 = (int)attributeValueData.AttributeValue;
			}
			if (!outMap.ContainsKey(num))
			{
				outMap[num] = num2;
			}
			else
			{
				int num3 = outMap[num];
				outMap[num] = num3 + num2;
			}
		}
	}

	// Token: 0x060121B6 RID: 74166 RVA: 0x004FA584 File Offset: 0x004F8784
	protected int SortAttrList(AttrListScrollData dataA, AttrListScrollData dataB)
	{
		bool flag = dataA.Priority != 0;
		bool flag2 = dataB.Priority != 0;
		if (flag && flag2)
		{
			return dataA.Priority - dataB.Priority;
		}
		if (flag)
		{
			return -1;
		}
		if (flag2)
		{
			return 1;
		}
		return dataA.Id - dataB.Id;
	}

	// Token: 0x170016D0 RID: 5840
	// (get) Token: 0x060121B7 RID: 74167 RVA: 0x004FA5CF File Offset: 0x004F87CF
	// (set) Token: 0x060121B8 RID: 74168 RVA: 0x004FA5D7 File Offset: 0x004F87D7
	public PhantomFetter? CurrentSelectedFetter
	{
		get
		{
			return this.Fetter;
		}
		set
		{
			this.Fetter = value;
		}
	}

	// Token: 0x060121B9 RID: 74169 RVA: 0x004FA5E0 File Offset: 0x004F87E0
	public IFettersObtainData[] GetFettersObtainDataList(int[] fetterId)
	{
		List<IFettersObtainData> list = new List<IFettersObtainData>();
		foreach (int num in fetterId)
		{
			int[] phantomItemIdArrayByMonsterId = this.GetPhantomItemIdArrayByMonsterId(num);
			if (phantomItemIdArrayByMonsterId == null || phantomItemIdArrayByMonsterId.Length == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Phantom;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "该怪物没有对应道具，请检查幻象道具表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("monsterId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				int num2 = 0;
				foreach (int itemConfigId in phantomItemIdArrayByMonsterId)
				{
					num2 = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemConfigId, 0);
					if (num2 > 0)
					{
						break;
					}
				}
				PhantomBattleInstance phantomInstanceByItemId = this.GetPhantomInstanceByItemId(phantomItemIdArrayByMonsterId[0]);
				CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(num);
				string monsterIcon = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterIcon(calabashDevelopRewardByMonsterId.Value.MonsterInfoId);
				FettersObtainData item = new FettersObtainData
				{
					Id = num,
					Name = phantomInstanceByItemId.PhantomItem.Value.MonsterName,
					Icon = monsterIcon,
					IsGet = (num2 != 0)
				};
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060121BA RID: 74170 RVA: 0x004FA710 File Offset: 0x004F8910
	[NullableContext(2)]
	public void SetPhantomRecommendData(PhantomRecommendResponse data)
	{
		this.RecommendData = new RecommendData();
		this.RecommendData.RoleId = data.RoleId;
		this.RecommendData.MonsterIdList = data.MonsterIdList.ToList<int>();
		this.RecommendData.MainPropId = data.MainPropId;
		this.RecommendData.FetterGroupId = data.FetterGroupId;
	}

	// Token: 0x170016D1 RID: 5841
	// (get) Token: 0x060121BB RID: 74171 RVA: 0x004FA771 File Offset: 0x004F8971
	[Nullable(2)]
	public RecommendData PhantomRecommendData
	{
		[NullableContext(2)]
		get
		{
			return this.RecommendData;
		}
	}

	// Token: 0x060121BC RID: 74172 RVA: 0x004FA77C File Offset: 0x004F897C
	public bool CheckIfHasPhantomSatisfiedLevelCondition(int itemId, int level)
	{
		List<global::PhantomItemData> list;
		if (itemId != 0)
		{
			list = ModelBase<InventoryModel>.Instance.GetPhantomItemDataListByPhantomItemId(itemId);
		}
		else
		{
			list = ModelBase<InventoryModel>.Instance.GetPhantomItemDataList();
		}
		if (list.Count == 0)
		{
			return false;
		}
		foreach (global::PhantomItemData phantomItemData in list)
		{
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(phantomItemData.GetUniqueId());
			if (phantomItemDataByUniqueId != null && phantomItemDataByUniqueId.GetPhantomLevel() >= level)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060121BD RID: 74173 RVA: 0x004FA810 File Offset: 0x004F8A10
	public bool CheckIfHasPhantomLevelMax()
	{
		foreach (PhantomBattleData phantomBattleData in this.GetPhantomBattleDataMap().Values)
		{
			if (this.GetPhantomMaxLevel(phantomBattleData.GetUniqueId()) == phantomBattleData.GetPhantomLevel())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060121BE RID: 74174 RVA: 0x004FA87C File Offset: 0x004F8A7C
	public bool CheckIfExistPhantomCanEquipInItemList(int[] itemIdList)
	{
		foreach (int itemId in itemIdList)
		{
			List<global::PhantomItemData> phantomItemDataListByPhantomItemId = ModelBase<InventoryModel>.Instance.GetPhantomItemDataListByPhantomItemId(itemId);
			if (phantomItemDataListByPhantomItemId.Count == 0)
			{
				return false;
			}
			foreach (global::PhantomItemData phantomItemData in phantomItemDataListByPhantomItemId)
			{
				if (!this.CheckPhantomIsEquip(phantomItemData.GetUniqueId()))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060121BF RID: 74175 RVA: 0x004FA908 File Offset: 0x004F8B08
	public int GetPhantomItemNumByItemId(int itemId)
	{
		List<global::PhantomItemData> phantomItemDataList = ModelBase<InventoryModel>.Instance.GetPhantomItemDataList();
		if (phantomItemDataList.Count == 0)
		{
			return 0;
		}
		int num = 0;
		using (List<global::PhantomItemData>.Enumerator enumerator = phantomItemDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetConfigId() == itemId)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x060121C0 RID: 74176 RVA: 0x004FA974 File Offset: 0x004F8B74
	public static AttrListScrollData[] FilterShowAttribute(AttrListScrollData[] input)
	{
		List<AttrListScrollData> list = new List<AttrListScrollData>();
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("VisionMainViewShowAttribute");
		foreach (AttrListScrollData attrListScrollData in input)
		{
			if (intArrayConfig.IndexOf(attrListScrollData.Id) >= 0)
			{
				list.Add(attrListScrollData);
			}
		}
		return list.ToArray();
	}

	// Token: 0x060121C1 RID: 74177 RVA: 0x004FA9C8 File Offset: 0x004F8BC8
	public List<PhantomDataBase> GetCurrentViewShowPhantomList(RoleDataBase roleData)
	{
		bool flag = roleData.IsTrialRole();
		List<PhantomDataBase> list = new List<PhantomDataBase>();
		if (flag)
		{
			Dictionary<int, PhantomDataBase> dataMap = roleData.GetPhantomData().GetDataMap();
			for (int i = 0; i < 5; i++)
			{
				PhantomDataBase item;
				if (dataMap.TryGetValue(i, out item))
				{
					list.Add(item);
				}
			}
			return list;
		}
		List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(roleData.GetRoleId()).GetIncrIdList();
		int count = incrIdList.Count;
		for (int j = 0; j < count; j++)
		{
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incrIdList[j]);
			list.Add(phantomBattleData);
		}
		return list;
	}

	// Token: 0x060121C2 RID: 74178 RVA: 0x004FAA5F File Offset: 0x004F8C5F
	public ItemDataBase[] GetSortedExpMaterialList(int uniqueId, int qualityId, bool withoutPhantom)
	{
		List<ItemDataBase> list = new List<ItemDataBase>(this.GetExpMaterialList(uniqueId, qualityId, true, withoutPhantom));
		list.Sort(new Comparison<ItemDataBase>(this.MaterialSort));
		return list.ToArray();
	}

	// Token: 0x060121C3 RID: 74179 RVA: 0x004FAA88 File Offset: 0x004F8C88
	private int MaterialSort(ItemDataBase a, ItemDataBase b)
	{
		InventoryDefine.EItemType? type = a.GetType();
		InventoryDefine.EItemType? type2 = b.GetType();
		if (!(type.GetValueOrDefault() == type2.GetValueOrDefault() & type != null == (type2 != null)))
		{
			return a.GetType().Value - b.GetType().Value;
		}
		if (a.GetQuality() != b.GetQuality())
		{
			return a.GetQuality() - b.GetQuality();
		}
		PhantomBattleData phantomBattleData = this.GetPhantomBattleData(a.GetUniqueId());
		PhantomBattleData phantomBattleData2 = this.GetPhantomBattleData(a.GetUniqueId());
		if (phantomBattleData != null && phantomBattleData2 != null && phantomBattleData.GetPhantomLevel() != phantomBattleData2.GetPhantomLevel())
		{
			return phantomBattleData.GetPhantomLevel() - phantomBattleData2.GetPhantomLevel();
		}
		return b.GetUniqueId() - a.GetUniqueId();
	}

	// Token: 0x060121C4 RID: 74180 RVA: 0x004FAB4C File Offset: 0x004F8D4C
	public ItemDataBase[] GetExpMaterialList(int uniqueId, int quality = 0, bool checkLock = false, bool withoutPhantom = false)
	{
		List<ItemInfo> levelUpItemList = ControllerBase<PhantomBattleController>.Instance.GetLevelUpItemList(uniqueId);
		List<ItemDataBase> list = new List<ItemDataBase>();
		foreach (ItemInfo itemInfo in levelUpItemList)
		{
			List<ItemDataBase> itemDataBaseByConfigId = ModelBase<InventoryModel>.Instance.GetItemDataBaseByConfigId(itemInfo.Id);
			int count = itemDataBaseByConfigId.Count;
			for (int i = 0; i < count; i++)
			{
				ItemDataBase itemDataBase = itemDataBaseByConfigId[i];
				if (quality <= 0 || itemDataBase.GetQuality() <= quality)
				{
					list.Add(itemDataBase);
				}
			}
		}
		if (withoutPhantom)
		{
			return list.ToArray();
		}
		foreach (ItemDataBase itemDataBase2 in ModelBase<InventoryModel>.Instance.GetItemDataBaseByMainType(InventoryDefine.EItemMainTypeId.Phantom))
		{
			if (itemDataBase2.GetType().GetValueOrDefault() == InventoryDefine.EItemType.Phantom)
			{
				if (itemDataBase2.GetUniqueId() == uniqueId || (checkLock && itemDataBase2.GetIsLock()) || (quality > 0 && itemDataBase2.GetQuality() > quality))
				{
					continue;
				}
				PhantomBattleData phantomBattleData = this.GetPhantomBattleData(itemDataBase2.GetUniqueId());
				int num;
				if ((phantomBattleData.GetPhantomLevel() == 0 && phantomBattleData.GetExp() == 0) || (this.PhantomEquipmentRoleMap.ContainsKey(itemDataBase2.GetUniqueId()) && this.PhantomEquipmentRoleMap.TryGetValue(itemDataBase2.GetUniqueId(), out num) && num != 0))
				{
					continue;
				}
			}
			list.Add(itemDataBase2);
		}
		return list.ToArray();
	}

	// Token: 0x060121C5 RID: 74181 RVA: 0x004FACD8 File Offset: 0x004F8ED8
	public bool GetIfSimpleState(int key)
	{
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.IsSimpleDetail, null);
		bool flag;
		return player != null && player.TryGetValue(key, out flag) && flag;
	}

	// Token: 0x060121C6 RID: 74182 RVA: 0x004FAD04 File Offset: 0x004F8F04
	public void SaveIfSimpleState(int key, bool state)
	{
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.IsSimpleDetail, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, bool>();
		}
		dictionary[key] = state;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.IsSimpleDetail, dictionary);
		Singleton<EventSystem>.Instance.Emit(EEventName.ChangeVisionSimplyState);
	}

	// Token: 0x060121C7 RID: 74183 RVA: 0x004FAD44 File Offset: 0x004F8F44
	public void SaveVisionSkillState(int key, bool state)
	{
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.VisionSpecialSkillShowMap, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, bool>();
		}
		dictionary[key] = state;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.VisionSpecialSkillShowMap, dictionary);
	}

	// Token: 0x060121C8 RID: 74184 RVA: 0x004FAD74 File Offset: 0x004F8F74
	public bool GetIfVisionSkillState(int key)
	{
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.VisionSpecialSkillShowMap, null);
		bool flag;
		return player != null && player.TryGetValue(key, out flag) && flag;
	}

	// Token: 0x060121C9 RID: 74185 RVA: 0x004FADA0 File Offset: 0x004F8FA0
	public Dictionary<int, int> CalculateExpBackItem(int exp)
	{
		IReadOnlyList<PhantomExpItem> phantomExpItemList = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomExpItemList();
		int count = phantomExpItemList.Count;
		int num = exp;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		for (int i = count - 1; i >= 0; i--)
		{
			int num2 = (int)Math.Floor((double)((float)num / (float)phantomExpItemList[i].Exp));
			num %= phantomExpItemList[i].Exp;
			if (num2 > 0)
			{
				dictionary[phantomExpItemList[i].ItemId] = num2;
			}
		}
		return dictionary;
	}

	// Token: 0x060121CA RID: 74186 RVA: 0x004FAE24 File Offset: 0x004F9024
	public bool CheckVisionIdentifyRedDot(int uniqueId)
	{
		PhantomDataBase phantomDataBase = this.GetPhantomDataBase(uniqueId);
		if (phantomDataBase != null)
		{
			bool ifHaveUnIdentifySubProp = phantomDataBase.GetIfHaveUnIdentifySubProp();
			bool ifHaveEnoughIdentifyConsumeItem = phantomDataBase.GetIfHaveEnoughIdentifyConsumeItem(1);
			return ifHaveUnIdentifySubProp && ifHaveEnoughIdentifyConsumeItem;
		}
		return false;
	}

	// Token: 0x060121CB RID: 74187 RVA: 0x004FAE50 File Offset: 0x004F9050
	public bool CheckVisionLevelUpSettingRedDot()
	{
		return !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.VisionLevelUpSettingRedDot, false) || !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.VisionLevelUpIdentifyRedDot, false);
	}

	// Token: 0x060121CC RID: 74188 RVA: 0x004FAE6C File Offset: 0x004F906C
	public bool IsVisionHighQuality(PhantomBattleData data)
	{
		int visionLevelUpQualityLimit = ConfigBase<PhantomBattleConfig>.Instance.GetVisionLevelUpQualityLimit();
		return data.GetConfig().QualityId > visionLevelUpQualityLimit;
	}

	// Token: 0x060121CD RID: 74189 RVA: 0x004FAE98 File Offset: 0x004F9098
	public bool IsVisionHighLevel(PhantomBattleData data)
	{
		int visionLevelUpLevelLimit = ConfigBase<PhantomBattleConfig>.Instance.GetVisionLevelUpLevelLimit();
		return data.GetPhantomLevel() > visionLevelUpLevelLimit;
	}

	// Token: 0x060121CE RID: 74190 RVA: 0x004FAEBC File Offset: 0x004F90BC
	public bool IsVisionHighRare(PhantomBattleData data)
	{
		int visionLevelUpRareLimit = ConfigBase<PhantomBattleConfig>.Instance.GetVisionLevelUpRareLimit();
		return data.GetRareConfig().Value.Rare > visionLevelUpRareLimit;
	}

	// Token: 0x170016D2 RID: 5842
	// (get) Token: 0x060121CF RID: 74191 RVA: 0x004FAEED File Offset: 0x004F90ED
	public List<VisionUnlockQualityData> QualityUnlockTipsList
	{
		get
		{
			return this.QualityUnlockTips;
		}
	}

	// Token: 0x060121D0 RID: 74192 RVA: 0x004FAEF8 File Offset: 0x004F90F8
	public void CacheNewSkinData(int skinId)
	{
		VisionUnlockQualityData visionUnlockQualityData = new VisionUnlockQualityData();
		visionUnlockQualityData.SkinId = skinId;
		visionUnlockQualityData.MonsterItemId = skinId;
		visionUnlockQualityData.IsUnlockMonster = false;
		int qualityId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(skinId).Value.QualityId;
		visionUnlockQualityData.UnlockQuality = qualityId;
		ModelBase<PhantomBattleModel>.Instance.QualityUnlockTipsList.Add(visionUnlockQualityData);
	}

	// Token: 0x060121D1 RID: 74193 RVA: 0x004FAF54 File Offset: 0x004F9154
	public void CacheNewQualityData(PhantomUnlockNotify notify)
	{
		foreach (int num in notify.UnlockQualityItemList)
		{
			VisionUnlockQualityData visionUnlockQualityData = new VisionUnlockQualityData();
			int qualityId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(num).Value.QualityId;
			visionUnlockQualityData.MonsterItemId = num;
			visionUnlockQualityData.UnlockQuality = qualityId;
			visionUnlockQualityData.IsUnlockMonster = false;
			ModelBase<PhantomBattleModel>.Instance.QualityUnlockTipsList.Add(visionUnlockQualityData);
		}
	}

	// Token: 0x060121D2 RID: 74194 RVA: 0x004FAFE4 File Offset: 0x004F91E4
	public int GetMainAttributeKey(int key)
	{
		int result;
		if (this.GetSortMainAttributeMap().TryGetValue(key, out result))
		{
			return result;
		}
		int result2;
		if (this.GetSortMainPercentageAttributeMap().TryGetValue(key, out result2))
		{
			return result2;
		}
		return 0;
	}

	// Token: 0x060121D3 RID: 74195 RVA: 0x004FB018 File Offset: 0x004F9218
	public int GetMainAttributeCost(int key)
	{
		int result;
		if (!this.GetSortMainAttributeCostMap().TryGetValue(key, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x060121D4 RID: 74196 RVA: 0x004FB038 File Offset: 0x004F9238
	public Dictionary<int, int> GetSortMainAttributeCostMap()
	{
		if (this.MainAttributeCostMap == null)
		{
			this.MainAttributeCostMap = new Dictionary<int, int>();
			this.MainAttributeCostMap[1001] = 4;
			this.MainAttributeCostMap[1002] = 3;
			this.MainAttributeCostMap[1003] = 1;
			this.MainAttributeCostMap[1004] = 4;
			this.MainAttributeCostMap[1005] = 3;
			this.MainAttributeCostMap[1006] = 1;
			this.MainAttributeCostMap[1007] = 4;
			this.MainAttributeCostMap[1008] = 3;
			this.MainAttributeCostMap[1009] = 1;
		}
		return this.MainAttributeCostMap;
	}

	// Token: 0x060121D5 RID: 74197 RVA: 0x004FB0FC File Offset: 0x004F92FC
	public int GetSortRuleIdByPropIndex(int propIndex, int addType)
	{
		foreach (KeyValuePair<int, int> keyValuePair in ((addType == 2) ? this.GetSortMainPercentageAttributeMap() : this.GetSortMainAttributeMap()))
		{
			if (propIndex == keyValuePair.Value)
			{
				return keyValuePair.Key;
			}
		}
		return 0;
	}

	// Token: 0x060121D6 RID: 74198 RVA: 0x004FB16C File Offset: 0x004F936C
	public Dictionary<int, int> GetSortMainAttributeMap()
	{
		if (this.MainAttributeMap == null)
		{
			this.MainAttributeMap = new Dictionary<int, int>();
			this.MainAttributeMap[8] = 10007;
			this.MainAttributeMap[6] = 10002;
			this.MainAttributeMap[10] = 10010;
			this.MainAttributeMap[12] = 8;
			this.MainAttributeMap[13] = 9;
			this.MainAttributeMap[14] = 35;
			this.MainAttributeMap[15] = 21;
			this.MainAttributeMap[16] = 22;
			this.MainAttributeMap[17] = 23;
			this.MainAttributeMap[18] = 24;
			this.MainAttributeMap[19] = 25;
			this.MainAttributeMap[20] = 26;
			this.MainAttributeMap[21] = 27;
			this.MainAttributeMap[22] = 11;
		}
		return this.MainAttributeMap;
	}

	// Token: 0x060121D7 RID: 74199 RVA: 0x004FB270 File Offset: 0x004F9470
	public Dictionary<int, int> GetSortMainPercentageAttributeMap()
	{
		if (this.MainPercentageAttributeMap == null)
		{
			this.MainPercentageAttributeMap = new Dictionary<int, int>();
			this.MainPercentageAttributeMap[9] = 10007;
			this.MainPercentageAttributeMap[7] = 10002;
			this.MainPercentageAttributeMap[11] = 10010;
			this.MainPercentageAttributeMap[1001] = 10002;
			this.MainPercentageAttributeMap[1002] = 10002;
			this.MainPercentageAttributeMap[1003] = 10002;
			this.MainPercentageAttributeMap[1004] = 10007;
			this.MainPercentageAttributeMap[1005] = 10007;
			this.MainPercentageAttributeMap[1006] = 10007;
			this.MainPercentageAttributeMap[1007] = 10010;
			this.MainPercentageAttributeMap[1008] = 10010;
			this.MainPercentageAttributeMap[1009] = 10010;
		}
		return this.MainPercentageAttributeMap;
	}

	// Token: 0x060121D8 RID: 74200 RVA: 0x004FB38C File Offset: 0x004F958C
	public int GetSubAttributeKey(int key)
	{
		int result;
		if (this.GetSortSubAttributeMap().TryGetValue(key, out result))
		{
			return result;
		}
		int result2;
		if (this.GetSortSubPercentageAttributeMap().TryGetValue(key, out result2))
		{
			return result2;
		}
		return 0;
	}

	// Token: 0x060121D9 RID: 74201 RVA: 0x004FB3C0 File Offset: 0x004F95C0
	public Dictionary<int, int> GetSortSubAttributeMap()
	{
		if (this.SubAttributeMap == null)
		{
			this.SubAttributeMap = new Dictionary<int, int>();
			this.SubAttributeMap[25] = 2;
			this.SubAttributeMap[23] = 1;
			this.SubAttributeMap[27] = 3;
			this.SubAttributeMap[29] = 11;
			this.SubAttributeMap[30] = 12;
			this.SubAttributeMap[36] = 11;
			this.SubAttributeMap[37] = 12;
			this.SubAttributeMap[38] = 13;
			this.SubAttributeMap[39] = 13;
			this.SubAttributeMap[47] = 7;
			this.SubAttributeMap[48] = 8;
			this.SubAttributeMap[49] = 9;
			this.SubAttributeMap[50] = 10;
		}
		return this.SubAttributeMap;
	}

	// Token: 0x060121DA RID: 74202 RVA: 0x004FB4A8 File Offset: 0x004F96A8
	public Dictionary<int, int> GetSortSubPercentageAttributeMap()
	{
		if (this.SubPercentageAttributeMap == null)
		{
			this.SubPercentageAttributeMap = new Dictionary<int, int>();
			this.SubPercentageAttributeMap[26] = 5;
			this.SubPercentageAttributeMap[24] = 4;
			this.SubPercentageAttributeMap[28] = 6;
		}
		return this.SubPercentageAttributeMap;
	}

	// Token: 0x060121DB RID: 74203 RVA: 0x004FB4F8 File Offset: 0x004F96F8
	public void GmClearData()
	{
		this.QualityUnlockTips.Clear();
	}

	// Token: 0x060121DC RID: 74204 RVA: 0x004FB505 File Offset: 0x004F9705
	public void RecordVisionRecoveryRedDot(bool value)
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.VisionRecoveryBatchTip) as ServerStorageBoolean;
		if (serverStorageBoolean != null)
		{
			serverStorageBoolean.Set(new bool?(value));
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionRecoveryStorage);
	}

	// Token: 0x060121DD RID: 74205 RVA: 0x004FB53C File Offset: 0x004F973C
	public bool GetVisionRecoveryBatchRedDot()
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.VisionRecoveryBatchTip) as ServerStorageBoolean;
		bool valueOrDefault = ((serverStorageBoolean != null) ? serverStorageBoolean.Get() : null).GetValueOrDefault(true);
		return ModelBase<FunctionModel>.Instance.IsOpen(10024001) && valueOrDefault;
	}

	// Token: 0x060121DE RID: 74206 RVA: 0x004FB589 File Offset: 0x004F9789
	public void RecordVisionRecoveryAimRedDot(bool value)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.VisionAim))
		{
			return;
		}
		(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.VisionRecoveryBatchAimTip) as ServerStorageBoolean).Set(new bool?(value));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionRecoveryStorage);
	}

	// Token: 0x060121DF RID: 74207 RVA: 0x004FB5CC File Offset: 0x004F97CC
	public bool GetVisionRecoveryBatchAimRedDot()
	{
		bool valueOrDefault = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.VisionRecoveryBatchAimTip) as ServerStorageBoolean).Get().GetValueOrDefault(true);
		return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.VisionAim) && valueOrDefault;
	}

	// Token: 0x060121E0 RID: 74208 RVA: 0x004FB60C File Offset: 0x004F980C
	public List<global::PhantomItemData> GetVisionRecoverySortPhantomItemList(List<AddCountItemInfo> itemInfos)
	{
		List<global::PhantomItemData> phantomItemDataListByAddCountItemInfo = ModelBase<InventoryModel>.Instance.GetPhantomItemDataListByAddCountItemInfo(itemInfos);
		HashSet<int> hashSet = new HashSet<int>();
		hashSet.Add(3);
		hashSet.Add(4);
		ModelBase<SortModel>.Instance.SortDataByData<global::PhantomItemData>(phantomItemDataListByAddCountItemInfo, ESortDataType.Phantom, hashSet, false);
		return phantomItemDataListByAddCountItemInfo;
	}

	// Token: 0x060121E1 RID: 74209 RVA: 0x004FB64A File Offset: 0x004F984A
	public void RecordVisionRefineRedDot(bool value)
	{
		(ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.VisionRefineTip) as ServerStorageBoolean).Set(new bool?(value));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionRefineStorage);
	}

	// Token: 0x060121E2 RID: 74210 RVA: 0x004FB678 File Offset: 0x004F9878
	public bool GetVisionRefineRedDot()
	{
		bool valueOrDefault = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.VisionRefineTip) as ServerStorageBoolean).Get().GetValueOrDefault(true);
		return ModelBase<FunctionModel>.Instance.IsOpen(10083) && valueOrDefault;
	}

	// Token: 0x060121E3 RID: 74211 RVA: 0x004FB6B8 File Offset: 0x004F98B8
	[NullableContext(2)]
	public Dictionary<int, int> GetVisionRefineMaterialCost(int uniqueId)
	{
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId);
		if (phantomDataBase != null)
		{
			return phantomDataBase.GetRareConfig().Value.PolishCost();
		}
		return null;
	}

	// Token: 0x060121E4 RID: 74212 RVA: 0x004FB6EC File Offset: 0x004F98EC
	[return: Nullable(2)]
	public Dictionary<int, int> GetVisionListRefineMainMaterialCost(List<int> uniqueIdList)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int uniqueId in uniqueIdList)
		{
			Dictionary<int, int> visionRefineMaterialCost = this.GetVisionRefineMaterialCost(uniqueId);
			if (visionRefineMaterialCost != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in visionRefineMaterialCost)
				{
					int num;
					if (dictionary.TryGetValue(keyValuePair.Key, out num))
					{
						dictionary[keyValuePair.Key] = num + keyValuePair.Value;
					}
					else
					{
						dictionary[keyValuePair.Key] = keyValuePair.Value;
					}
				}
			}
		}
		if (dictionary.Count == 0)
		{
			return null;
		}
		return dictionary;
	}

	// Token: 0x060121E5 RID: 74213 RVA: 0x004FB7C8 File Offset: 0x004F99C8
	[NullableContext(2)]
	public Dictionary<int, int> GetVisionRefineSubMaterialCost(int lockCount)
	{
		PhantomVicePolishConfig? phantomVicePolishCostByLockCount = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomVicePolishCostByLockCount(lockCount);
		if (phantomVicePolishCostByLockCount == null)
		{
			return null;
		}
		return phantomVicePolishCostByLockCount.Value.Cost();
	}

	// Token: 0x060121E6 RID: 74214 RVA: 0x004FB7FC File Offset: 0x004F99FC
	[NullableContext(2)]
	public Dictionary<int, int> GetVisionRefineMaterialDefaultCost()
	{
		IReadOnlyList<PhantomRarity> phantomRareConfigAll = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfigAll();
		if (phantomRareConfigAll.Count > 0)
		{
			return phantomRareConfigAll[0].PolishCost();
		}
		return null;
	}

	// Token: 0x060121E7 RID: 74215 RVA: 0x004FB830 File Offset: 0x004F9A30
	[NullableContext(2)]
	public Dictionary<int, int> GetVisionRefineSubMaterialDefaultCost()
	{
		IReadOnlyList<PhantomVicePolishConfig> phantomVicePolishConfigAll = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomVicePolishConfigAll();
		if (phantomVicePolishConfigAll != null && phantomVicePolishConfigAll.Count > 0)
		{
			Dictionary<int, int> dictionary = phantomVicePolishConfigAll[0].Cost();
			if (dictionary.Count > 0)
			{
				int key = 0;
				using (Dictionary<int, int>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<int, int> keyValuePair = enumerator.Current;
						key = keyValuePair.Key;
					}
				}
				return new Dictionary<int, int>
				{
					{
						key,
						0
					}
				};
			}
		}
		return null;
	}

	// Token: 0x060121E8 RID: 74216 RVA: 0x004FB8C4 File Offset: 0x004F9AC4
	public bool IsVisionRefineMaterialEnough(int uniqueId)
	{
		Dictionary<int, int> visionRefineMaterialCost = this.GetVisionRefineMaterialCost(uniqueId);
		if (visionRefineMaterialCost == null)
		{
			return false;
		}
		foreach (KeyValuePair<int, int> keyValuePair in visionRefineMaterialCost)
		{
			int value = keyValuePair.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0) < value)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060121E9 RID: 74217 RVA: 0x004FB940 File Offset: 0x004F9B40
	public bool IsVisionListRefineMainMaterialEnough(List<int> uniqueIdList)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int uniqueId in uniqueIdList)
		{
			Dictionary<int, int> visionRefineMaterialCost = this.GetVisionRefineMaterialCost(uniqueId);
			if (visionRefineMaterialCost != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in visionRefineMaterialCost)
				{
					int num;
					if (dictionary.TryGetValue(keyValuePair.Key, out num))
					{
						dictionary[keyValuePair.Key] = num + keyValuePair.Value;
					}
					else
					{
						dictionary[keyValuePair.Key] = keyValuePair.Value;
					}
				}
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in dictionary)
		{
			int value = keyValuePair2.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair2.Key, 0) < value)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060121EA RID: 74218 RVA: 0x004FBA74 File Offset: 0x004F9C74
	public bool IsVisionRefineSubMaterialEnough(int count)
	{
		Dictionary<int, int> visionRefineSubMaterialCost = this.GetVisionRefineSubMaterialCost(count);
		if (visionRefineSubMaterialCost == null)
		{
			return false;
		}
		using (Dictionary<int, int>.Enumerator enumerator = visionRefineSubMaterialCost.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, int> keyValuePair = enumerator.Current;
				return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0) >= keyValuePair.Value;
			}
		}
		return false;
	}

	// Token: 0x060121EB RID: 74219 RVA: 0x004FBAEC File Offset: 0x004F9CEC
	public int GetPhantomMainRandGroupId(int itemId)
	{
		int randGroupId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(itemId).Value.MainProp.Value.RandGroupId;
		if (randGroupId == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "获取幻象主属性组配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return -1;
		}
		return randGroupId;
	}

	// Token: 0x060121EC RID: 74220 RVA: 0x004FBB5C File Offset: 0x004F9D5C
	public int[] GetPhantomMainPropItemRefineAvailableIdList(int itemId)
	{
		int phantomMainRandGroupId = this.GetPhantomMainRandGroupId(itemId);
		IReadOnlyList<PhantomMainProperty> phantomMainPropertyByRandGroupId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyByRandGroupId(phantomMainRandGroupId);
		if (phantomMainPropertyByRandGroupId == null || phantomMainPropertyByRandGroupId.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "获取幻象主属性池失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new int[0];
		}
		List<int> list = new List<int>();
		foreach (PhantomMainProperty phantomMainProperty in phantomMainPropertyByRandGroupId)
		{
			int[] array = phantomMainProperty.PropGroup();
			list.Add(array[0]);
		}
		return list.ToArray();
	}

	// Token: 0x060121ED RID: 74221 RVA: 0x004FBC14 File Offset: 0x004F9E14
	public void SetSelfPhantomConfigCode(string value)
	{
		this.PhantomConfigData.SelfPhantomConfigCode = value;
	}

	// Token: 0x060121EE RID: 74222 RVA: 0x004FBC22 File Offset: 0x004F9E22
	public PhantomManagerConfigData GetPhantomConfigData()
	{
		return this.PhantomConfigData;
	}

	// Token: 0x060121EF RID: 74223 RVA: 0x004FBC2A File Offset: 0x004F9E2A
	public string GetSelfPhantomConfigCode()
	{
		return this.PhantomConfigData.SelfPhantomConfigCode;
	}

	// Token: 0x060121F0 RID: 74224 RVA: 0x004FBC37 File Offset: 0x004F9E37
	public void UpdatePhantomConfigData(PhBaOneAllSuitPlan allPlan)
	{
		this.PhantomConfigData.UpdateFetterMap(allPlan.SuitPlanList.ToList<PhBaOneSuitPlan>());
	}

	// Token: 0x060121F1 RID: 74225 RVA: 0x004FBC4F File Offset: 0x004F9E4F
	public void CacheShareConfigData(PhBaOneAllSuitPlan allPlan)
	{
		this.PhantomConfigData.CacheShareFetterMap(allPlan.SuitPlanList.ToList<PhBaOneSuitPlan>());
	}

	// Token: 0x04008D4D RID: 36173
	private readonly Dictionary<int, PhantomBattleData> RobotDataMap;

	// Token: 0x04008D4E RID: 36174
	private readonly Dictionary<int, PhantomRoleEquipmentData> BattleDataMap;

	// Token: 0x04008D4F RID: 36175
	private readonly Dictionary<int, int> PhantomEquipmentRoleMap;

	// Token: 0x04008D50 RID: 36176
	private readonly Dictionary<int, PhantomBattleInstance> PhantomInstanceMap;

	// Token: 0x04008D51 RID: 36177
	private readonly Dictionary<int, PhantomBattleData> PhantomBattleDataMap;

	// Token: 0x04008D52 RID: 36178
	private List<PhantomBattleData> UnEquipVisionArray;

	// Token: 0x04008D53 RID: 36179
	private bool UnEquipVisionArrayRefreshTag;

	// Token: 0x04008D54 RID: 36180
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, int[]> FetterGroupMonsterMap;

	// Token: 0x04008D55 RID: 36181
	[Nullable(2)]
	public PhantomBattleData CurrentSelectData;

	// Token: 0x04008D56 RID: 36182
	public int CurrentEquipmentSelectIndex;

	// Token: 0x04008D57 RID: 36183
	public int CurrentSelectUniqueId;

	// Token: 0x04008D58 RID: 36184
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CustomPromise<UCurveFloat> LoadingCurvePromise;

	// Token: 0x04008D59 RID: 36185
	public bool LevelUpConfirmTipsNotShow;

	// Token: 0x04008D5A RID: 36186
	private FVector PhantomMeshZoom;

	// Token: 0x04008D5B RID: 36187
	private FVector PhantomMeshLocation;

	// Token: 0x04008D5C RID: 36188
	private FRotator PhantomMeshRotator;

	// Token: 0x04008D5D RID: 36189
	private readonly Dictionary<int, int> LevelUpItemData;

	// Token: 0x04008D5E RID: 36190
	private TItem[] TempSaveItemList;

	// Token: 0x04008D5F RID: 36191
	[Nullable(2)]
	private LevelUpPastVisionData PastVisionLevelUpData;

	// Token: 0x04008D60 RID: 36192
	private bool VisionLevelUpTag;

	// Token: 0x04008D61 RID: 36193
	private int CurrentDraggingIndex;

	// Token: 0x04008D62 RID: 36194
	private int CurrentMaxCost;

	// Token: 0x04008D63 RID: 36195
	[Nullable(2)]
	private int[] UnlockSkin;

	// Token: 0x04008D64 RID: 36196
	private readonly Dictionary<int, int[]> MonsterSkinMap;

	// Token: 0x04008D65 RID: 36197
	private readonly Dictionary<int, int> MonsterSkinMonsterIdMap;

	// Token: 0x04008D66 RID: 36198
	[Nullable(2)]
	private Dictionary<int, int> MainAttributeMap;

	// Token: 0x04008D67 RID: 36199
	[Nullable(2)]
	private Dictionary<int, int> MainPercentageAttributeMap;

	// Token: 0x04008D68 RID: 36200
	[Nullable(2)]
	private Dictionary<int, int> SubAttributeMap;

	// Token: 0x04008D69 RID: 36201
	[Nullable(2)]
	private Dictionary<int, int> SubPercentageAttributeMap;

	// Token: 0x04008D6A RID: 36202
	[Nullable(2)]
	private Dictionary<int, int> MainAttributeCostMap;

	// Token: 0x04008D6B RID: 36203
	private EVisionLevelUpMaterialPutInMode VisionLevelUpMaterialPutInMode;

	// Token: 0x04008D6C RID: 36204
	private EVisionLevelUpMaterialUseType VisionLevelUpMaterialUseType;

	// Token: 0x04008D6D RID: 36205
	private EVisionLevelUpIdentify VisionLevelUpIdentify;

	// Token: 0x04008D6E RID: 36206
	public bool PhantomRefineAcceptIgnore;

	// Token: 0x04008D6F RID: 36207
	public bool PhantomRefineRejectIgnore;

	// Token: 0x04008D70 RID: 36208
	private int NeedCameraFocusMethodDisableViewCount;

	// Token: 0x04008D71 RID: 36209
	private PhantomFetter? Fetter;

	// Token: 0x04008D72 RID: 36210
	public int CurrentSelectFetterGroupId;

	// Token: 0x04008D73 RID: 36211
	[Nullable(2)]
	private RecommendData RecommendData;

	// Token: 0x04008D74 RID: 36212
	private readonly List<VisionUnlockQualityData> QualityUnlockTips;

	// Token: 0x04008D75 RID: 36213
	protected PhantomManagerConfigData PhantomConfigData = new PhantomManagerConfigData();
}
