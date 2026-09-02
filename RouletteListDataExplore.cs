using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;

// Token: 0x02002922 RID: 10530
[NullableContext(1)]
[Nullable(0)]
public class RouletteListDataExplore : RouletteListDataBase
{
	// Token: 0x17001B74 RID: 7028
	// (get) Token: 0x06014E29 RID: 85545 RVA: 0x005C7BB2 File Offset: 0x005C5DB2
	public override ERouletteType RouletteType
	{
		get
		{
			return ERouletteType.Explore;
		}
	}

	// Token: 0x17001B75 RID: 7029
	// (get) Token: 0x06014E2A RID: 85546 RVA: 0x005C7BB5 File Offset: 0x005C5DB5
	public override ERoulettePriority Priority
	{
		get
		{
			return ERoulettePriority.Explore;
		}
	}

	// Token: 0x06014E2B RID: 85547 RVA: 0x005C7BBC File Offset: 0x005C5DBC
	public RouletteListDataExplore()
	{
		this.DefaultExtraItemIdProxy = new NormalExtraItemIdProxy(this);
		this.ActiveExtraItemIdProxy = this.DefaultExtraItemIdProxy;
	}

	// Token: 0x06014E2C RID: 85548 RVA: 0x005C7CE9 File Offset: 0x005C5EE9
	[NullableContext(2)]
	public void SetExtraItemIdProxy(IExtraItemIdProxy proxy)
	{
		this.ActiveExtraItemIdProxy = (proxy ?? this.DefaultExtraItemIdProxy);
	}

	// Token: 0x06014E2D RID: 85549 RVA: 0x005C7CFC File Offset: 0x005C5EFC
	public IExtraItemIdProxy GetExtraItemIdProxy()
	{
		return this.ActiveExtraItemIdProxy;
	}

	// Token: 0x06014E2E RID: 85550 RVA: 0x005C7D04 File Offset: 0x005C5F04
	public override List<int> GetRouletteIdList()
	{
		if (this.IsRouletteReplace())
		{
			return this.RouletteIdListReplace;
		}
		return this.RouletteIdListServer;
	}

	// Token: 0x06014E2F RID: 85551 RVA: 0x005C7D1B File Offset: 0x005C5F1B
	public override int GetExtraItemId()
	{
		if (this.IsRouletteReplace())
		{
			return this.ExtraItemIdReplace;
		}
		return this.ActiveExtraItemIdProxy.GetExtraItemId();
	}

	// Token: 0x06014E30 RID: 85552 RVA: 0x005C7D37 File Offset: 0x005C5F37
	public override int GetEquipExploreSkillId()
	{
		return this.EquipExploreSkillIdServer;
	}

	// Token: 0x06014E31 RID: 85553 RVA: 0x005C7D3F File Offset: 0x005C5F3F
	public override void Init()
	{
		this.InitExploreRouletteReplaceConfig();
		this.OnAddEvents();
	}

	// Token: 0x06014E32 RID: 85554 RVA: 0x005C7D4D File Offset: 0x005C5F4D
	public override void Clear()
	{
		this.OnRemoveEvents();
	}

	// Token: 0x06014E33 RID: 85555 RVA: 0x005C7D58 File Offset: 0x005C5F58
	public override void UpdateData(ExploreSkillRoulette exploreList)
	{
		this.RouletteIdListServer = exploreList.SkillIds.ToList<int>();
		bool flag = this.CheckIsSpecialItem();
		this.ExtraItemIdServer = exploreList.ExtraItemId;
		this.DefaultExtraItemIdProxy.ApplyServerSnapshot(this.ExtraItemIdServer);
		if (this.CheckIsSpecialItem())
		{
			Singleton<EventSystem>.Instance.Emit<int?>(EEventName.OnSpecialItemUpdate, new int?(this.GetExtraItemId()));
		}
		else if (flag)
		{
			Singleton<EventSystem>.Instance.Emit<int?>(EEventName.OnSpecialItemUpdate, null);
		}
		this.EquipExploreSkillIdServer = exploreList.ExploreSkill;
		if (this.ExtraItemIdServer == 0 && this.EquipExploreSkillIdServer == 3001)
		{
			IRouletteListSaveData rouletteListSaveData = base.GetRouletteListSaveData();
			rouletteListSaveData.EquipExploreSkillId = 3002;
			ControllerBase<RouletteController>.Instance.SaveRouletteDataRequest(rouletteListSaveData, null);
			return;
		}
		if (this.ExtraItemIdServer != 0 && this.EquipExploreSkillIdServer == 3002)
		{
			IRouletteListSaveData rouletteListSaveData2 = base.GetRouletteListSaveData();
			rouletteListSaveData2.EquipExploreSkillId = 3001;
			ControllerBase<RouletteController>.Instance.SaveRouletteDataRequest(rouletteListSaveData2, null);
		}
	}

	// Token: 0x06014E34 RID: 85556 RVA: 0x005C7E4E File Offset: 0x005C604E
	public override bool IsActivate()
	{
		return true;
	}

	// Token: 0x06014E35 RID: 85557 RVA: 0x005C7E51 File Offset: 0x005C6051
	private void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x06014E36 RID: 85558 RVA: 0x005C7E6F File Offset: 0x005C606F
	private void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x06014E37 RID: 85559 RVA: 0x005C7E8D File Offset: 0x005C608D
	public override bool IsRouletteReplace()
	{
		return this.ReplaceId != null;
	}

	// Token: 0x06014E38 RID: 85560 RVA: 0x005C7E9F File Offset: 0x005C609F
	public bool SetExtraItemIdReplace(int itemId)
	{
		if (!this.IsRouletteReplace())
		{
			return false;
		}
		this.ExtraItemIdReplace = itemId;
		return true;
	}

	// Token: 0x06014E39 RID: 85561 RVA: 0x005C7EB3 File Offset: 0x005C60B3
	public override bool IsRouletteOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10026);
	}

	// Token: 0x06014E3A RID: 85562 RVA: 0x005C7EC4 File Offset: 0x005C60C4
	public override bool IsMainRouletteCanOpenView(bool checkTips)
	{
		return ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(checkTips);
	}

	// Token: 0x06014E3B RID: 85563 RVA: 0x005C7ED1 File Offset: 0x005C60D1
	public override Dictionary<ERouletteGridType, List<AssemblyGridData>> CreateAssemblyGridData()
	{
		return new Dictionary<ERouletteGridType, List<AssemblyGridData>>
		{
			{
				ERouletteGridType.Explore,
				this.CreateAllAssemblyDataExplore()
			},
			{
				ERouletteGridType.EquipItem,
				this.CreateAllAssemblyDataEquipItem()
			}
		};
	}

	// Token: 0x06014E3C RID: 85564 RVA: 0x005C7EF4 File Offset: 0x005C60F4
	public override int? GetRouletteGridId(int index, ERouletteGridType type, bool useDisplay)
	{
		if (type != ERouletteGridType.Explore)
		{
			if (type != ERouletteGridType.EquipItem)
			{
				return null;
			}
			if (useDisplay)
			{
				return new int?(this.GetExtraItemId());
			}
			return new int?(this.ExtraItemIdServer);
		}
		else if (useDisplay)
		{
			List<int> rouletteIdList = this.GetRouletteIdList();
			if (index >= 0 && index < rouletteIdList.Count)
			{
				return new int?(rouletteIdList[index]);
			}
			return null;
		}
		else
		{
			if (index >= 0 && index < this.RouletteIdListServer.Count)
			{
				return new int?(this.RouletteIdListServer[index]);
			}
			return null;
		}
	}

	// Token: 0x06014E3D RID: 85565 RVA: 0x005C7F8A File Offset: 0x005C618A
	public override RouletteMainViewProxyBase GetRouletteMainViewProxy()
	{
		return new RouletteMainViewProxy();
	}

	// Token: 0x06014E3E RID: 85566 RVA: 0x005C7F91 File Offset: 0x005C6191
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteDataMap()
	{
		return this.ExploreRouletteMap;
	}

	// Token: 0x06014E3F RID: 85567 RVA: 0x005C7F9C File Offset: 0x005C619C
	private unsafe void InitExploreRouletteReplaceConfig()
	{
		this.ReplaceTagId2ReplaceId.Clear();
		this.RelatedTagIdPriorityList.Clear();
		this.RelatedTagIdExistPriorityList.Clear();
		IEnumerable<ExploreRouletteReplace> allReplaceConfig = ConfigBase<RouletteConfig>.Instance.GetAllReplaceConfig();
		List<IRouletteReplaceParam> list = new List<IRouletteReplaceParam>();
		foreach (ExploreRouletteReplace exploreRouletteReplace in allReplaceConfig)
		{
			for (int i = 0; i < exploreRouletteReplace.TagsInForceLength; i++)
			{
				string text = exploreRouletteReplace.TagsInForce(i);
				int tagIdByName = GameplayTagUtils.GetTagIdByName(text);
				if (tagIdByName == 0)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Phantom;
					ELogAuthor author = ELogAuthor.YYZ;
					string message = "[ExploreRoulette] 探索工具轮盘替换配置Tag不存在,请检查配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ReplaceId", exploreRouletteReplace.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tagName", text);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				else
				{
					RouletteReplaceParam item = new RouletteReplaceParam
					{
						TagId = tagIdByName,
						SortId = exploreRouletteReplace.Priority,
						ReplaceId = exploreRouletteReplace.Id
					};
					list.Add(item);
					this.ReplaceTagId2ReplaceId.Add(tagIdByName, exploreRouletteReplace.Id);
				}
			}
		}
		list.Sort((IRouletteReplaceParam a, IRouletteReplaceParam b) => a.SortId - b.SortId);
		foreach (IRouletteReplaceParam rouletteReplaceParam in list)
		{
			this.RelatedTagIdPriorityList.Add(rouletteReplaceParam.TagId);
			this.RelatedTagIdExistPriorityList.Add(false);
		}
	}

	// Token: 0x06014E40 RID: 85568 RVA: 0x005C8168 File Offset: 0x005C6368
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		this.StopListenRelatedTags();
		this.ListenRelatedTags(newEntity);
	}

	// Token: 0x06014E41 RID: 85569 RVA: 0x005C8178 File Offset: 0x005C6378
	[NullableContext(2)]
	private void ListenRelatedTags(EntityHandle entityHandle)
	{
		RoleTagComponent roleTagComponent;
		if (entityHandle == null)
		{
			roleTagComponent = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			roleTagComponent = ((entity != null) ? entity.GetComponent<RoleTagComponent>() : null);
		}
		RoleTagComponent roleTagComponent2 = roleTagComponent;
		this.StopListenRelatedTags();
		List<int> relatedTagIdPriorityList = this.RelatedTagIdPriorityList;
		List<bool> relatedTagIdExistPriorityList = this.RelatedTagIdExistPriorityList;
		for (int i = 0; i < relatedTagIdPriorityList.Count; i++)
		{
			int tagId = relatedTagIdPriorityList[i];
			if (roleTagComponent2 != null)
			{
				roleTagComponent2.AddTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnRelatedTagAddOrRemove), null);
			}
			relatedTagIdExistPriorityList[i] = (roleTagComponent2 != null && roleTagComponent2.HasTag(tagId));
		}
		this.RelatedTagEntityHandle = entityHandle;
		this.RefreshReplaceConfig(relatedTagIdPriorityList, relatedTagIdExistPriorityList);
	}

	// Token: 0x06014E42 RID: 85570 RVA: 0x005C8208 File Offset: 0x005C6408
	protected void StopListenRelatedTags()
	{
		EntityHandle relatedTagEntityHandle = this.RelatedTagEntityHandle;
		if (relatedTagEntityHandle == null)
		{
			return;
		}
		WorldEntity entity = relatedTagEntityHandle.Entity;
		RoleTagComponent roleTagComponent = (entity != null) ? entity.GetComponent<RoleTagComponent>() : null;
		if (roleTagComponent != null)
		{
			foreach (int tagId in this.RelatedTagIdPriorityList)
			{
				roleTagComponent.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnRelatedTagAddOrRemove));
			}
		}
		this.RelatedTagEntityHandle = null;
	}

	// Token: 0x06014E43 RID: 85571 RVA: 0x005C8290 File Offset: 0x005C6490
	private void OnRelatedTagAddOrRemove(int tagId, bool tagExist)
	{
		EntityHandle relatedTagEntityHandle = this.RelatedTagEntityHandle;
		bool flag;
		if (relatedTagEntityHandle == null)
		{
			flag = (null != null);
		}
		else
		{
			WorldEntity entity = relatedTagEntityHandle.Entity;
			flag = (((entity != null) ? entity.GetComponent<RoleTagComponent>() : null) != null);
		}
		if (!flag)
		{
			return;
		}
		List<int> relatedTagIdPriorityList = this.RelatedTagIdPriorityList;
		List<bool> relatedTagIdExistPriorityList = this.RelatedTagIdExistPriorityList;
		int num = relatedTagIdPriorityList.IndexOf(tagId);
		if (num >= 0)
		{
			relatedTagIdExistPriorityList[num] = tagExist;
		}
		this.RefreshReplaceConfig(relatedTagIdPriorityList, relatedTagIdExistPriorityList);
	}

	// Token: 0x06014E44 RID: 85572 RVA: 0x005C82E8 File Offset: 0x005C64E8
	private void RefreshReplaceConfig(List<int> tagIdList, List<bool> existList)
	{
		for (int i = 0; i < existList.Count; i++)
		{
			if (existList[i])
			{
				int tagId = tagIdList[i];
				this.ActiveReplaceConfig(tagId);
				return;
			}
		}
		this.DisActiveReplaceConfig();
	}

	// Token: 0x06014E45 RID: 85573 RVA: 0x005C8328 File Offset: 0x005C6528
	private unsafe void ActiveReplaceConfig(int tagId)
	{
		int num;
		if (!this.ReplaceTagId2ReplaceId.TryGetValue(tagId, out num))
		{
			return;
		}
		int? replaceId = this.ReplaceId;
		int num2 = num;
		if (replaceId.GetValueOrDefault() == num2 & replaceId != null)
		{
			return;
		}
		this.ReplaceId = new int?(num);
		ExploreRouletteReplace? replaceConfigById = ConfigBase<RouletteConfig>.Instance.GetReplaceConfigById(num);
		if (replaceConfigById == null)
		{
			return;
		}
		this.RouletteIdListReplace.Clear();
		List<int> collection = replaceConfigById.Value.GetRouletteSkillIdListArray().Take(8).ToList<int>();
		this.RouletteIdListReplace.AddRange(collection);
		int count = this.RouletteIdListReplace.Count;
		for (int i = 0; i < 8 - count; i++)
		{
			this.RouletteIdListReplace.Add(0);
		}
		int? num3 = new int?(replaceConfigById.Value.RouletteItemId);
		if (num3 != null && num3.Value != 0 && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num3.Value, 0) <= 0)
		{
			num3 = new int?(0);
		}
		this.ExtraItemIdReplace = num3.GetValueOrDefault();
		this.RecordEquipExploreSkillId = this.EquipExploreSkillIdServer;
		int? num4 = new int?(replaceConfigById.Value.ReplaceSkillId);
		if (num4 != null && num4.Value != 0 && base.IsFirstExplorePriority())
		{
			ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(num4.Value, EExploreSkillLayer.Roulette, "ActiveReplaceConfig");
			ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(num4.Value, null, true);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[ExploreRoulette] 进入替换模式";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ReplaceId", this.ReplaceId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ReplaceSkillId", num4);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ReplaceItemId", num3);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("RestoreSkillId", this.RecordEquipExploreSkillId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
	}

	// Token: 0x06014E46 RID: 85574 RVA: 0x005C8548 File Offset: 0x005C6748
	private void DisActiveReplaceConfig()
	{
		if (this.ReplaceId == null)
		{
			return;
		}
		this.ReplaceId = null;
		int recordEquipExploreSkillId = this.RecordEquipExploreSkillId;
		if (recordEquipExploreSkillId != 0 && base.IsFirstExplorePriority())
		{
			ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(recordEquipExploreSkillId, EExploreSkillLayer.Roulette, "DisActiveReplaceConfig");
			ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(recordEquipExploreSkillId, null, true);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[ExploreRoulette] 退出替换模式";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RestoreSkillId", recordEquipExploreSkillId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.RecordEquipExploreSkillId = 0;
	}

	// Token: 0x06014E47 RID: 85575 RVA: 0x005C85D2 File Offset: 0x005C67D2
	private bool CheckIsSpecialItem()
	{
		return this.GetExtraItemId() != 0 && ControllerBase<SpecialItemController>.Instance.IsSpecialItem(this.GetExtraItemId());
	}

	// Token: 0x06014E48 RID: 85576 RVA: 0x005C85F0 File Offset: 0x005C67F0
	private List<AssemblyGridData> CreateAllAssemblyDataExplore()
	{
		List<AssemblyExploreGridData> list = new List<AssemblyExploreGridData>();
		foreach (KeyValuePair<int, ExploreTools> keyValuePair in ModelBase<RouletteModel>.Instance.UnlockExploreSkillDataMap)
		{
			int key = keyValuePair.Key;
			ExploreTools value = keyValuePair.Value;
			if (value.GetRouletteTypeArray().Contains((int)this.RouletteType) && value.CanAssemblyShow)
			{
				AssemblyExploreGridData assemblyExploreGridData = new AssemblyExploreGridData();
				assemblyExploreGridData.GridType = ERouletteGridType.Explore;
				assemblyExploreGridData.IconPath = value.BackGround;
				assemblyExploreGridData.Name = value.Name;
				assemblyExploreGridData.Id = key;
				int? sort = value.GetSort((int)this.RouletteType);
				if (sort != null && sort.Value > 0)
				{
					assemblyExploreGridData.SortId = sort.Value;
				}
				else
				{
					assemblyExploreGridData.SortId = 0;
				}
				list.Add(assemblyExploreGridData);
			}
		}
		list.Sort((AssemblyExploreGridData a, AssemblyExploreGridData b) => a.SortId - b.SortId);
		return list.Cast<AssemblyGridData>().ToList<AssemblyGridData>();
	}

	// Token: 0x06014E49 RID: 85577 RVA: 0x005C8720 File Offset: 0x005C6920
	private List<AssemblyGridData> CreateAllAssemblyDataEquipItem()
	{
		List<AssemblyEquipItemGridData> list = new List<AssemblyEquipItemGridData>();
		foreach (CommonItemData commonItemData in ModelBase<InventoryModel>.Instance.GetCommonItemByItemType(InventoryDefine.EItemType.SpecialItem))
		{
			SpecialItem? config = ConfigBase<SpecialItemConfig>.Instance.GetConfig(commonItemData.GetConfigId());
			if (config != null && config.Value.SpecialItemType == 0)
			{
				list.Add(new AssemblyEquipItemGridData
				{
					Id = commonItemData.GetConfigId(),
					GridType = ERouletteGridType.EquipItem,
					Name = commonItemData.GetConfig().As<ItemInfo>().Value.Name,
					ItemNum = commonItemData.GetCount(),
					ItemType = InventoryDefine.EItemType.SpecialItem,
					SortId = commonItemData.GetSortIndex(),
					QualityId = commonItemData.GetQuality()
				});
			}
		}
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("Roulette_EquipItem_ShowTypeList");
		if (intArrayConfig == null)
		{
			return list.Cast<AssemblyGridData>().ToList<AssemblyGridData>();
		}
		IReadOnlyList<int> source = intArrayConfig;
		foreach (CommonItemData commonItemData2 in ModelBase<InventoryModel>.Instance.GetCommonItemByItemType(InventoryDefine.EItemType.Common))
		{
			int itemBuffType = commonItemData2.GetConfig().As<ItemInfo>().Value.ItemBuffType;
			if (source.Contains(itemBuffType))
			{
				list.Add(new AssemblyEquipItemGridData
				{
					Id = commonItemData2.GetConfigId(),
					GridType = ERouletteGridType.EquipItem,
					Name = commonItemData2.GetConfig().As<ItemInfo>().Value.Name,
					ItemNum = commonItemData2.GetCount(),
					ItemType = InventoryDefine.EItemType.Common,
					SortId = commonItemData2.GetSortIndex(),
					QualityId = commonItemData2.GetQuality()
				});
			}
		}
		return list.Cast<AssemblyGridData>().ToList<AssemblyGridData>();
	}

	// Token: 0x0400A107 RID: 41223
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	private readonly List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> ExploreRouletteMap = new List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>>
	{
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			1
		}, ERouletteComponentNode.RouletteItem1, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			2
		}, ERouletteComponentNode.RouletteItem2, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			3
		}, ERouletteComponentNode.RouletteItem3, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			4
		}, ERouletteComponentNode.RouletteItem4, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			5
		}, ERouletteComponentNode.RouletteItem5, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			6
		}, ERouletteComponentNode.RouletteItem6, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			7
		}, ERouletteComponentNode.RouletteItem7, ERouletteGridType.Explore),
		new ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>(new List<int>
		{
			8
		}, ERouletteComponentNode.RouletteItem8, ERouletteGridType.EquipItem)
	};

	// Token: 0x0400A108 RID: 41224
	[Nullable(2)]
	private EntityHandle RelatedTagEntityHandle;

	// Token: 0x0400A109 RID: 41225
	private readonly List<int> RelatedTagIdPriorityList = new List<int>();

	// Token: 0x0400A10A RID: 41226
	private readonly List<bool> RelatedTagIdExistPriorityList = new List<bool>();

	// Token: 0x0400A10B RID: 41227
	private readonly Dictionary<int, int> ReplaceTagId2ReplaceId = new Dictionary<int, int>();

	// Token: 0x0400A10C RID: 41228
	private int? ReplaceId;

	// Token: 0x0400A10D RID: 41229
	private readonly List<int> RouletteIdListReplace = new List<int>();

	// Token: 0x0400A10E RID: 41230
	private int ExtraItemIdReplace;

	// Token: 0x0400A10F RID: 41231
	private int RecordEquipExploreSkillId;

	// Token: 0x0400A110 RID: 41232
	private readonly NormalExtraItemIdProxy DefaultExtraItemIdProxy;

	// Token: 0x0400A111 RID: 41233
	private IExtraItemIdProxy ActiveExtraItemIdProxy;
}
