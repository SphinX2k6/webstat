using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.Ui;

// Token: 0x0200207D RID: 8317
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class SpecialItemController : UiControllerBase<SpecialItemController>
{
	// Token: 0x0600FD61 RID: 64865 RVA: 0x00457BC4 File Offset: 0x00455DC4
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSpecialItemUse, new Action<int, int>(this.OnSpecialItemUse));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemNotify, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddSpecialItem));
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.OnSpecialItemUpdate, new Action<int?>(this.OnSpecialItemUpdate));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.EquipAndSwitchSpecialItem, new Action<int, bool>(this.EquipAndSwitchSpecialItem));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.UnEquipSpecialItem, new Action<int>(this.OnUnEquipSpecialItem));
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, this.OnChangeModeFinish);
	}

	// Token: 0x0600FD62 RID: 64866 RVA: 0x00457CAC File Offset: 0x00455EAC
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new Action<int, int>(this.OnItemUse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSpecialItemUse, new Action<int, int>(this.OnSpecialItemUse));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemNotify, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddSpecialItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSpecialItemUpdate, new Action<int?>(this.OnSpecialItemUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.EquipAndSwitchSpecialItem, new Action<int, bool>(this.EquipAndSwitchSpecialItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.UnEquipSpecialItem, new Action<int>(this.OnUnEquipSpecialItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, this.OnChangeModeFinish);
	}

	// Token: 0x0600FD63 RID: 64867 RVA: 0x00457D93 File Offset: 0x00455F93
	protected override bool OnInit()
	{
		base.PauseTick();
		return true;
	}

	// Token: 0x0600FD64 RID: 64868 RVA: 0x00457D9C File Offset: 0x00455F9C
	protected override void OnTick(float delta)
	{
		base.PauseTick();
		this.RefreshSpecialItemAllowReqUse();
	}

	// Token: 0x0600FD65 RID: 64869 RVA: 0x00457DAC File Offset: 0x00455FAC
	[NullableContext(2)]
	private void RecordToRefreshSpecialItemAllowReqUse(int configId, EntityHandle entityHandle)
	{
		foreach (ValueTuple<int, EntityHandle> valueTuple in this.RecordListForRefreshSpecialItemAllowReqUse)
		{
			if (valueTuple.Item1 == configId && object.Equals(valueTuple.Item2, entityHandle))
			{
				return;
			}
		}
		this.RecordListForRefreshSpecialItemAllowReqUse.Add(new ValueTuple<int, EntityHandle>(configId, entityHandle));
		base.ResumeTick();
	}

	// Token: 0x0600FD66 RID: 64870 RVA: 0x00457E2C File Offset: 0x0045602C
	private unsafe void RefreshSpecialItemAllowReqUse()
	{
		if (this.RecordListForRefreshSpecialItemAllowReqUse.Count == 0)
		{
			return;
		}
		if (this.RecordListForRefreshSpecialItemAllowReqUse.Count > 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Item;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "RefreshSpecialItemAllowReqUse单Tick派发次数过多，可能存在性能问题";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Count", this.RecordListForRefreshSpecialItemAllowReqUse.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("List", this.RecordListForRefreshSpecialItemAllowReqUse);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		List<ValueTuple<int, EntityHandle>> recordListForRefreshSpecialItemAllowReqUse = this.RecordListForRefreshSpecialItemAllowReqUse;
		this.RecordListForRefreshSpecialItemAllowReqUse = new List<ValueTuple<int, EntityHandle>>();
		foreach (ValueTuple<int, EntityHandle> valueTuple in recordListForRefreshSpecialItemAllowReqUse)
		{
			int item = valueTuple.Item1;
			EntityHandle item2 = valueTuple.Item2;
			Singleton<EventSystem>.Instance.Emit<int, EntityHandle>(EEventName.OnRefreshSpecialItemAllowReqUse, item, item2);
		}
	}

	// Token: 0x0600FD67 RID: 64871 RVA: 0x00457F24 File Offset: 0x00456124
	private void OnSpecialItemUpdate(int? configId)
	{
		if (configId == null)
		{
			this.StopListenSpecialItemRelatedTags();
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		this.ListenSpecialItemRelatedTags(configId.Value, getCurrentEntity);
	}

	// Token: 0x0600FD68 RID: 64872 RVA: 0x00457F5C File Offset: 0x0045615C
	public bool IsSpecialItem(int configId)
	{
		if (configId == 0)
		{
			return false;
		}
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(configId);
		return itemConfig != null && itemConfig.GetValueOrDefault().SpecialItem;
	}

	// Token: 0x0600FD69 RID: 64873 RVA: 0x00457F9C File Offset: 0x0045619C
	public bool AllowReqUseSpecialItem(int configId)
	{
		SpecialItem? config = ConfigBase<SpecialItemConfig>.Instance.GetConfig(configId);
		if (config == null)
		{
			return false;
		}
		if (!config.Value.UseInstance && ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return false;
		}
		if (!config.Value.UseInMultiMode && ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return false;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		BaseTagComponent baseTagComponent;
		if (getCurrentEntity == null)
		{
			baseTagComponent = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null)
		{
			return config.Value.AllowTags().Length == 0;
		}
		string[] array = config.Value.AllowTags();
		for (int i = 0; i < array.Length; i++)
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(array[i]);
			if (!baseTagComponent2.HasTag(tagIdByName))
			{
				return false;
			}
		}
		array = config.Value.BanTags();
		for (int i = 0; i < array.Length; i++)
		{
			int tagIdByName2 = GameplayTagUtils.GetTagIdByName(array[i]);
			if (baseTagComponent2.HasTag(tagIdByName2))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600FD6A RID: 64874 RVA: 0x004580AC File Offset: 0x004562AC
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		int? tagWatchedItemId = ModelBase<SpecialItemModel>.Instance.TagWatchedItemId;
		if (tagWatchedItemId != null)
		{
			int? num = tagWatchedItemId;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				this.StopListenSpecialItemRelatedTags();
				this.ListenSpecialItemRelatedTags(tagWatchedItemId.Value, newEntity);
				this.RecordToRefreshSpecialItemAllowReqUse(tagWatchedItemId.Value, newEntity);
				return;
			}
		}
	}

	// Token: 0x0600FD6B RID: 64875 RVA: 0x00458108 File Offset: 0x00456308
	[NullableContext(2)]
	public void ListenSpecialItemRelatedTags(int configId, EntityHandle entityHandle)
	{
		if (!this.IsSpecialItem(configId))
		{
			return;
		}
		SpecialItem? config = ConfigBase<SpecialItemConfig>.Instance.GetConfig(configId);
		if (config == null)
		{
			return;
		}
		BaseTagComponent baseTagComponent;
		if (entityHandle == null)
		{
			baseTagComponent = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		this.StopListenSpecialItemRelatedTags();
		string[] array = config.Value.AllowTags();
		for (int i = 0; i < array.Length; i++)
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(array[i]);
			if (baseTagComponent2 != null)
			{
				baseTagComponent2.AddTagAddOrRemoveListener(tagIdByName, new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialItemRelatedTagAddOrRemove), null);
			}
			ModelBase<SpecialItemModel>.Instance.WatchedAllowTagIds.Add(tagIdByName);
		}
		array = config.Value.BanTags();
		for (int i = 0; i < array.Length; i++)
		{
			int tagIdByName2 = GameplayTagUtils.GetTagIdByName(array[i]);
			if (baseTagComponent2 != null)
			{
				baseTagComponent2.AddTagAddOrRemoveListener(tagIdByName2, new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialItemRelatedTagAddOrRemove), null);
			}
			ModelBase<SpecialItemModel>.Instance.WatchedBanTagIds.Add(tagIdByName2);
		}
		ModelBase<SpecialItemModel>.Instance.TagWatchedItemId = new int?(configId);
		ModelBase<SpecialItemModel>.Instance.TagWatchedEntityHandle = entityHandle;
	}

	// Token: 0x0600FD6C RID: 64876 RVA: 0x00458218 File Offset: 0x00456418
	public void StopListenSpecialItemRelatedTags()
	{
		SpecialItemModel instance = ModelBase<SpecialItemModel>.Instance;
		BaseTagComponent baseTagComponent;
		if (instance == null)
		{
			baseTagComponent = null;
		}
		else
		{
			EntityHandle tagWatchedEntityHandle = instance.TagWatchedEntityHandle;
			if (tagWatchedEntityHandle == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity = tagWatchedEntityHandle.Entity;
				baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
			}
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 != null)
		{
			foreach (int tagId in ModelBase<SpecialItemModel>.Instance.WatchedAllowTagIds)
			{
				baseTagComponent2.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialItemRelatedTagAddOrRemove));
			}
		}
		ModelBase<SpecialItemModel>.Instance.WatchedAllowTagIds.Clear();
		if (baseTagComponent2 != null)
		{
			foreach (int tagId2 in ModelBase<SpecialItemModel>.Instance.WatchedBanTagIds)
			{
				baseTagComponent2.RemoveTagAddOrRemoveListener(tagId2, new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialItemRelatedTagAddOrRemove));
			}
		}
		ModelBase<SpecialItemModel>.Instance.WatchedBanTagIds.Clear();
		ModelBase<SpecialItemModel>.Instance.TagWatchedItemId = new int?(0);
		ModelBase<SpecialItemModel>.Instance.TagWatchedEntityHandle = null;
	}

	// Token: 0x0600FD6D RID: 64877 RVA: 0x00458338 File Offset: 0x00456538
	private void OnSpecialItemRelatedTagAddOrRemove(int tagId, bool tagExist)
	{
		int? tagWatchedItemId = ModelBase<SpecialItemModel>.Instance.TagWatchedItemId;
		EntityHandle tagWatchedEntityHandle = ModelBase<SpecialItemModel>.Instance.TagWatchedEntityHandle;
		if (tagWatchedItemId != null)
		{
			int? num = tagWatchedItemId;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				this.RecordToRefreshSpecialItemAllowReqUse(tagWatchedItemId.Value, tagWatchedEntityHandle);
			}
		}
	}

	// Token: 0x0600FD6E RID: 64878 RVA: 0x0045838C File Offset: 0x0045658C
	private void OnAddSpecialItem(IReadOnlyList<IProto_NormalItem> itemList)
	{
		foreach (IProto_NormalItem proto_NormalItem in itemList)
		{
			if (this.IsSpecialItem(proto_NormalItem.Id))
			{
				this.EquipSpecialItem(proto_NormalItem.Id, true, true, EExploreSkillLayer.Roulette);
			}
		}
	}

	// Token: 0x0600FD6F RID: 64879 RVA: 0x004583EC File Offset: 0x004565EC
	private void OnSpecialItemUse(int configId, int useCount)
	{
		if (!this.IsSpecialItem(configId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Item;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "特殊道具不存在,请检查是否配置t.特殊道具";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (!SpecialItemDefine.SpecialItemIdSet.Contains((SpecialItemDefine.ESpecialItemType)configId))
		{
			return;
		}
		SpecialItemLogicBase specialItemLogic = ModelBase<SpecialItemModel>.Instance.GetSpecialItemLogic((SpecialItemDefine.ESpecialItemType)configId);
		if (specialItemLogic.CheckUseCondition())
		{
			specialItemLogic.OnUse();
		}
	}

	// Token: 0x0600FD70 RID: 64880 RVA: 0x00458459 File Offset: 0x00456659
	private void EquipAndSwitchSpecialItem(int configId, bool needSwitch)
	{
		this.EquipSpecialItem(configId, needSwitch, true, EExploreSkillLayer.Roulette);
	}

	// Token: 0x0600FD71 RID: 64881 RVA: 0x00458466 File Offset: 0x00456666
	private void OnUnEquipSpecialItem(int configId)
	{
		this.UnEquipSpecialItem(configId);
	}

	// Token: 0x0600FD72 RID: 64882 RVA: 0x00458470 File Offset: 0x00456670
	public unsafe bool EquipSpecialItem(int configId, bool needSwitch = true, bool needTips = true, EExploreSkillLayer layer = EExploreSkillLayer.Roulette)
	{
		if (!ModelBase<RouletteModel>.Instance.IsExploreRouletteOpen(false))
		{
			return false;
		}
		if (ModelBase<RecallQuestModel>.Instance.IsInRecallInstance() && ControllerBase<RouletteController>.Instance.TrySetExtraItemIdForReplace(configId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Item;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "[EquipSpecialItem] 替换模式下仅修改本地替换Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", configId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			RouletteController.RefreshExploreSkillButton();
			return true;
		}
		SpecialItem? config = ConfigBase<SpecialItemConfig>.Instance.GetConfig(configId);
		if (config == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Item;
			ELogAuthor author2 = ELogAuthor.YYZ;
			string message2 = "特殊道具不存在,请检查是否配置t.特殊道具";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", configId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		if (config.Value.SpecialItemType != 0)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Item;
			ELogAuthor author3 = ELogAuthor.YYZ;
			string message3 = "特殊道具配置类型无法装备";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", configId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SpecialItemType", config.Value.SpecialItemType);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(configId, 0) <= 0)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Item;
			ELogAuthor author4 = ELogAuthor.YYZ;
			string message4 = "背包中没有对应特殊道具,无法切换";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Id", configId);
			instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		int? equipSpecialItemId = ModelBase<SpecialItemModel>.Instance.GetEquipSpecialItemId();
		int configId2 = configId;
		if (!(equipSpecialItemId.GetValueOrDefault() == configId2 & equipSpecialItemId != null))
		{
			ControllerBase<RouletteController>.Instance.SaveExploreRouletteExtraItemId(configId, delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				if (needSwitch)
				{
					ControllerBase<RouletteController>.Instance.EquipItemSetRequest(configId, null, layer);
				}
				if (needTips)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ItemEquiped", Array.Empty<object>());
				}
			});
			return true;
		}
		if (needSwitch)
		{
			ControllerBase<RouletteController>.Instance.EquipItemSetRequest(configId, null, layer);
		}
		return true;
	}

	// Token: 0x0600FD73 RID: 64883 RVA: 0x00458688 File Offset: 0x00456888
	public void UnEquipSpecialItem(int configId)
	{
		int? equipSpecialItemId = ModelBase<SpecialItemModel>.Instance.GetEquipSpecialItemId();
		if (equipSpecialItemId.GetValueOrDefault() == configId & equipSpecialItemId != null)
		{
			ControllerBase<RouletteController>.Instance.SaveExploreRouletteExtraItemId(0, null);
		}
	}

	// Token: 0x0600FD74 RID: 64884 RVA: 0x004586C4 File Offset: 0x004568C4
	public bool AutoEquipOrUnEquipSpecialItem(int configId)
	{
		int? equipSpecialItemId = ModelBase<SpecialItemModel>.Instance.GetEquipSpecialItemId();
		int? num = equipSpecialItemId;
		bool flag = configId == num.GetValueOrDefault() & num != null;
		if (flag)
		{
			this.UnEquipSpecialItem(configId);
		}
		else
		{
			this.EquipSpecialItem(configId, true, true, EExploreSkillLayer.Roulette);
		}
		return !flag;
	}

	// Token: 0x0600FD75 RID: 64885 RVA: 0x0045870C File Offset: 0x0045690C
	private void OnItemUse(int configId, int useCount)
	{
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(configId);
		if (itemConfig.Value.Parameters().Count == 0)
		{
			return;
		}
		if (!this.IsSpecialItem(configId))
		{
			return;
		}
		int exploreSkillId;
		if (itemConfig.Value.Parameters().TryGetValue(21, out exploreSkillId))
		{
			this.HandleItemUseExploreSkill(configId, useCount, exploreSkillId);
		}
	}

	// Token: 0x0600FD76 RID: 64886 RVA: 0x0045876C File Offset: 0x0045696C
	private void HandleItemUseExploreSkill(int configId, int useCount, int exploreSkillId)
	{
		WorldEntity entity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
		if (entity == null || !entity.Valid)
		{
			return;
		}
		CharacterSkillComponent component = entity.GetComponent<CharacterSkillComponent>();
		if (!component.Valid)
		{
			return;
		}
		component.BeginSkillAsync(exploreSkillId, new SkillParam
		{
			Reason = "Explore skill item: UseSkill"
		});
	}

	// Token: 0x0400799D RID: 31133
	[TupleElementNames(new string[]
	{
		"ConfigId",
		"EntityHandle"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		2
	})]
	private List<ValueTuple<int, EntityHandle>> RecordListForRefreshSpecialItemAllowReqUse = new List<ValueTuple<int, EntityHandle>>();

	// Token: 0x0400799E RID: 31134
	private readonly Action OnChangeModeFinish = delegate()
	{
		int? tagWatchedItemId = ModelBase<SpecialItemModel>.Instance.TagWatchedItemId;
		EntityHandle tagWatchedEntityHandle = ModelBase<SpecialItemModel>.Instance.TagWatchedEntityHandle;
		if (tagWatchedItemId != null)
		{
			int? num = tagWatchedItemId;
			int num2 = 0;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				ControllerBase<SpecialItemController>.Instance.RecordToRefreshSpecialItemAllowReqUse(tagWatchedItemId.Value, tagWatchedEntityHandle);
			}
		}
	};
}
