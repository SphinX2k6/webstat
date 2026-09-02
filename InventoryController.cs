using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf;
using Google.Protobuf.Collections;

// Token: 0x0200200F RID: 8207
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class InventoryController : UiControllerBase<InventoryController>
{
	// Token: 0x0600F868 RID: 63592 RVA: 0x00440A9A File Offset: 0x0043EC9A
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EOperationType, EOperationType>(EEventName.ShowTypeChange, new Action<EOperationType, EOperationType>(this.ShowTypeChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x0600F869 RID: 63593 RVA: 0x00440AD4 File Offset: 0x0043ECD4
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ShowTypeChange, new Action<EOperationType, EOperationType>(this.ShowTypeChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
	}

	// Token: 0x0600F86A RID: 63594 RVA: 0x00440B10 File Offset: 0x0043ED10
	protected override void OnRegisterNetEvent()
	{
		Net instance = Singleton<Net>.Instance;
		ENotifyMessageId id = ENotifyMessageId.NormalItemUpdateNotify;
		Action<NormalItemUpdateNotify, Net.CallbackStatus> callback;
		if ((callback = InventoryController.<>O.<0>__NormalItemUpdateNotify) == null)
		{
			callback = (InventoryController.<>O.<0>__NormalItemUpdateNotify = new Action<NormalItemUpdateNotify, Net.CallbackStatus>(InventoryController.NormalItemUpdateNotify));
		}
		instance.Register<NormalItemUpdateNotify>(id, callback);
		Net instance2 = Singleton<Net>.Instance;
		ENotifyMessageId id2 = ENotifyMessageId.NormalItemRemoveNotify;
		Action<NormalItemRemoveNotify, Net.CallbackStatus> callback2;
		if ((callback2 = InventoryController.<>O.<1>__NormalItemRemoveNotify) == null)
		{
			callback2 = (InventoryController.<>O.<1>__NormalItemRemoveNotify = new Action<NormalItemRemoveNotify, Net.CallbackStatus>(InventoryController.NormalItemRemoveNotify));
		}
		instance2.Register<NormalItemRemoveNotify>(id2, callback2);
		Net instance3 = Singleton<Net>.Instance;
		ENotifyMessageId id3 = ENotifyMessageId.NormalItemAddNotify;
		Action<NormalItemAddNotify, Net.CallbackStatus> callback3;
		if ((callback3 = InventoryController.<>O.<2>__NormalItemAddNotify) == null)
		{
			callback3 = (InventoryController.<>O.<2>__NormalItemAddNotify = new Action<NormalItemAddNotify, Net.CallbackStatus>(InventoryController.NormalItemAddNotify));
		}
		instance3.Register<NormalItemAddNotify>(id3, callback3);
		Net instance4 = Singleton<Net>.Instance;
		ENotifyMessageId id4 = ENotifyMessageId.ValidTimeItemUpdateNotify;
		Action<ValidTimeItemUpdateNotify, Net.CallbackStatus> callback4;
		if ((callback4 = InventoryController.<>O.<3>__ValidTimeItemUpdateNotify) == null)
		{
			callback4 = (InventoryController.<>O.<3>__ValidTimeItemUpdateNotify = new Action<ValidTimeItemUpdateNotify, Net.CallbackStatus>(InventoryController.ValidTimeItemUpdateNotify));
		}
		instance4.Register<ValidTimeItemUpdateNotify>(id4, callback4);
		Net instance5 = Singleton<Net>.Instance;
		ENotifyMessageId id5 = ENotifyMessageId.ValidTimeItemRemoveNotify;
		Action<ValidTimeItemRemoveNotify, Net.CallbackStatus> callback5;
		if ((callback5 = InventoryController.<>O.<4>__ValidTimeItemRemoveNotify) == null)
		{
			callback5 = (InventoryController.<>O.<4>__ValidTimeItemRemoveNotify = new Action<ValidTimeItemRemoveNotify, Net.CallbackStatus>(InventoryController.ValidTimeItemRemoveNotify));
		}
		instance5.Register<ValidTimeItemRemoveNotify>(id5, callback5);
		Net instance6 = Singleton<Net>.Instance;
		ENotifyMessageId id6 = ENotifyMessageId.ValidTimeItemAddNotify;
		Action<ValidTimeItemAddNotify, Net.CallbackStatus> callback6;
		if ((callback6 = InventoryController.<>O.<5>__ValidTimeItemAddNotify) == null)
		{
			callback6 = (InventoryController.<>O.<5>__ValidTimeItemAddNotify = new Action<ValidTimeItemAddNotify, Net.CallbackStatus>(InventoryController.ValidTimeItemAddNotify));
		}
		instance6.Register<ValidTimeItemAddNotify>(id6, callback6);
		Net instance7 = Singleton<Net>.Instance;
		ENotifyMessageId id7 = ENotifyMessageId.WeaponItemAddNotify;
		Action<WeaponItemAddNotify, Net.CallbackStatus> callback7;
		if ((callback7 = InventoryController.<>O.<6>__WeaponItemAddNotify) == null)
		{
			callback7 = (InventoryController.<>O.<6>__WeaponItemAddNotify = new Action<WeaponItemAddNotify, Net.CallbackStatus>(InventoryController.WeaponItemAddNotify));
		}
		instance7.Register<WeaponItemAddNotify>(id7, callback7);
		Net instance8 = Singleton<Net>.Instance;
		ENotifyMessageId id8 = ENotifyMessageId.WeaponItemRemoveNotify;
		Action<WeaponItemRemoveNotify, Net.CallbackStatus> callback8;
		if ((callback8 = InventoryController.<>O.<7>__WeaponItemRemoveNotify) == null)
		{
			callback8 = (InventoryController.<>O.<7>__WeaponItemRemoveNotify = new Action<WeaponItemRemoveNotify, Net.CallbackStatus>(InventoryController.WeaponItemRemoveNotify));
		}
		instance8.Register<WeaponItemRemoveNotify>(id8, callback8);
		Net instance9 = Singleton<Net>.Instance;
		ENotifyMessageId id9 = ENotifyMessageId.PhantomItemAddNotify;
		Action<PhantomItemAddNotify, Net.CallbackStatus> callback9;
		if ((callback9 = InventoryController.<>O.<8>__PhantomItemAddNotify) == null)
		{
			callback9 = (InventoryController.<>O.<8>__PhantomItemAddNotify = new Action<PhantomItemAddNotify, Net.CallbackStatus>(InventoryController.PhantomItemAddNotify));
		}
		instance9.Register<PhantomItemAddNotify>(id9, callback9);
		Net instance10 = Singleton<Net>.Instance;
		ENotifyMessageId id10 = ENotifyMessageId.PhantomItemRemoveNotify;
		Action<PhantomItemRemoveNotify, Net.CallbackStatus> callback10;
		if ((callback10 = InventoryController.<>O.<9>__PhantomItemRemoveNotify) == null)
		{
			callback10 = (InventoryController.<>O.<9>__PhantomItemRemoveNotify = new Action<PhantomItemRemoveNotify, Net.CallbackStatus>(InventoryController.PhantomItemRemoveNotify));
		}
		instance10.Register<PhantomItemRemoveNotify>(id10, callback10);
		Net instance11 = Singleton<Net>.Instance;
		ENotifyMessageId id11 = ENotifyMessageId.ItemFuncValueUpdateNotify;
		Action<ItemFuncValueUpdateNotify, Net.CallbackStatus> callback11;
		if ((callback11 = InventoryController.<>O.<10>__ItemFuncValueUpdateNotify) == null)
		{
			callback11 = (InventoryController.<>O.<10>__ItemFuncValueUpdateNotify = new Action<ItemFuncValueUpdateNotify, Net.CallbackStatus>(InventoryController.ItemFuncValueUpdateNotify));
		}
		instance11.Register<ItemFuncValueUpdateNotify>(id11, callback11);
		Net instance12 = Singleton<Net>.Instance;
		ENotifyMessageId id12 = ENotifyMessageId.ItemPkgOpenNotify;
		Action<ItemPkgOpenNotify, Net.CallbackStatus> callback12;
		if ((callback12 = InventoryController.<>O.<11>__InventoryTabOpenNotify) == null)
		{
			callback12 = (InventoryController.<>O.<11>__InventoryTabOpenNotify = new Action<ItemPkgOpenNotify, Net.CallbackStatus>(InventoryController.InventoryTabOpenNotify));
		}
		instance12.Register<ItemPkgOpenNotify>(id12, callback12);
		Net instance13 = Singleton<Net>.Instance;
		ENotifyMessageId id13 = ENotifyMessageId.ItemPkgFullNotify;
		Action<ItemPkgFullNotify, Net.CallbackStatus> callback13;
		if ((callback13 = InventoryController.<>O.<12>__InventoryFullNotify) == null)
		{
			callback13 = (InventoryController.<>O.<12>__InventoryFullNotify = new Action<ItemPkgFullNotify, Net.CallbackStatus>(InventoryController.InventoryFullNotify));
		}
		instance13.Register<ItemPkgFullNotify>(id13, callback13);
	}

	// Token: 0x0600F86B RID: 63595 RVA: 0x00440D4C File Offset: 0x0043EF4C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NormalItemUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NormalItemRemoveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NormalItemAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ValidTimeItemUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ValidTimeItemRemoveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ValidTimeItemAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeaponItemAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WeaponItemRemoveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomItemAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomItemRemoveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ItemFuncValueUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ItemPkgOpenNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ItemPkgFullNotify);
	}

	// Token: 0x0600F86C RID: 63596 RVA: 0x00440E29 File Offset: 0x0043F029
	protected override void OnAddOpenViewCheckFunction()
	{
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName inventoryView = EUiViewName.InventoryView;
		Func<EUiViewName, object, bool> func;
		if ((func = InventoryController.<>O.<13>__CanOpenView) == null)
		{
			func = (InventoryController.<>O.<13>__CanOpenView = new Func<EUiViewName, object, bool>(InventoryController.CanOpenView));
		}
		instance.AddOpenViewCheckFunction(inventoryView, func, "InventoryController.CanOpenView");
	}

	// Token: 0x0600F86D RID: 63597 RVA: 0x00440E5A File Offset: 0x0043F05A
	protected override void OnRemoveOpenViewCheckFunction()
	{
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName inventoryView = EUiViewName.InventoryView;
		Func<EUiViewName, object, bool> func;
		if ((func = InventoryController.<>O.<13>__CanOpenView) == null)
		{
			func = (InventoryController.<>O.<13>__CanOpenView = new Func<EUiViewName, object, bool>(InventoryController.CanOpenView));
		}
		instance.RemoveOpenViewCheckFunction(inventoryView, func);
	}

	// Token: 0x0600F86E RID: 63598 RVA: 0x00440E86 File Offset: 0x0043F086
	private void OnDataDone()
	{
		this.NormalItemRequest();
		this.WeaponItemRequest();
		this.PhantomItemRequest();
		this.ValidTimeItemRequest();
	}

	// Token: 0x0600F86F RID: 63599 RVA: 0x00440EA0 File Offset: 0x0043F0A0
	private void ShowTypeChange(EOperationType last, EOperationType now)
	{
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InventoryView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.InventoryView, null);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryView, null, null);
		}
	}

	// Token: 0x0600F870 RID: 63600 RVA: 0x00440ED4 File Offset: 0x0043F0D4
	public void ItemLockRequest(int uniqueId, bool bLock)
	{
		if (uniqueId <= 0)
		{
			return;
		}
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(uniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		if (!attributeItemData.CanLock())
		{
			return;
		}
		ItemLockRequest itemLockRequest = Aki.Protocol.ItemLockRequest.Create();
		itemLockRequest.IncrId = attributeItemData.GetUniqueId();
		itemLockRequest.Oper = (bLock ? 1 : 2);
		ModelBase<InventoryModel>.Instance.SetCurrentLockItemUniqueId(uniqueId);
		bool isDeprecate = attributeItemData.GetIsDeprecated();
		Singleton<Net>.Instance.Call<ItemLockResponse>(ERequestMessageId.ItemLockRequest, itemLockRequest, delegate(ItemLockResponse massage, [Nullable(2)] Net.CallbackStatus _)
		{
			if (massage.ErrCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(massage.ErrCode, 24035, null, true, true);
				return;
			}
			if (!bLock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ItemUnlockSuccess", Array.Empty<object>());
			}
			else if (isDeprecate)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EchoAbandonToLock", Array.Empty<object>());
			}
			else
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ItemLockSuccess", Array.Empty<object>());
			}
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnItemLock, uniqueId, bLock);
		}, 0);
	}

	// Token: 0x0600F871 RID: 63601 RVA: 0x00440F7C File Offset: 0x0043F17C
	public void ItemDeprecateRequest(int uniqueId, bool isDeprecate)
	{
		if (uniqueId <= 0)
		{
			return;
		}
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(uniqueId);
		if (attributeItemData == null)
		{
			return;
		}
		if (!attributeItemData.CanDeprecate())
		{
			return;
		}
		ItemDisuseRequest itemDisuseRequest = ItemDisuseRequest.Create();
		itemDisuseRequest.IncrId = uniqueId;
		itemDisuseRequest.Oper = (isDeprecate ? 1 : 2);
		bool isLock = attributeItemData.GetIsLock();
		Singleton<Net>.Instance.Call<ItemDisuseResponse>(ERequestMessageId.ItemDisuseRequest, itemDisuseRequest, delegate(ItemDisuseResponse massage, [Nullable(2)] Net.CallbackStatus _)
		{
			if (massage.ErrCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(massage.ErrCode, 25490, null, true, true);
				return;
			}
			if (!isDeprecate)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EchoAbandonRelease", Array.Empty<object>());
				return;
			}
			if (isLock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EchoLockToAbandon", Array.Empty<object>());
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EchoAbandonSuccess", Array.Empty<object>());
		}, 0);
	}

	// Token: 0x0600F872 RID: 63602 RVA: 0x00440FFC File Offset: 0x0043F1FC
	public void RequestItemUse(int configId, int count)
	{
		InventoryController.<>c__DisplayClass17_0 CS$<>8__locals1 = new InventoryController.<>c__DisplayClass17_0();
		CS$<>8__locals1.configId = configId;
		CS$<>8__locals1.count = count;
		CS$<>8__locals1.itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(CS$<>8__locals1.configId).Value;
		int restrictConditionGroupId = CS$<>8__locals1.itemConfig.RestrictConditionGroupId;
		if (restrictConditionGroupId > 0 && ControllerBase<LevelGeneralController>.Instance.CheckCondition(restrictConditionGroupId.ToString(), null, false, Array.Empty<object>()))
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(restrictConditionGroupId);
			if (conditionGroupHintText != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(conditionGroupHintText, Array.Empty<object>());
			}
			return;
		}
		int skillId;
		if (CS$<>8__locals1.itemConfig.SpecialItem && CS$<>8__locals1.itemConfig.Parameters().TryGetValue(21, out skillId))
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			CharacterSkillComponent characterSkillComponent = (getCurrentEntity != null) ? getCurrentEntity.Entity.GetComponent<CharacterSkillComponent>() : null;
			if (characterSkillComponent != null && characterSkillComponent.IsSkillInCd(skillId))
			{
				return;
			}
		}
		if (CS$<>8__locals1.itemConfig.SpecialItem && !ControllerBase<SpecialItemController>.Instance.AllowReqUseSpecialItem(CS$<>8__locals1.configId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Inventory;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "试图请求使用的特殊道具被禁用";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configId", CS$<>8__locals1.configId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSpecialItemNotAllow);
			return;
		}
		ItemUseRequest itemUseRequest = ItemUseRequest.Create();
		itemUseRequest.ItemId = CS$<>8__locals1.configId;
		itemUseRequest.Count = CS$<>8__locals1.count;
		Singleton<Net>.Instance.Call<ItemUseResponse>(ERequestMessageId.ItemUseRequest, itemUseRequest, new Action<ItemUseResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestItemUse>g__responseItemUse|0), 0);
	}

	// Token: 0x0600F873 RID: 63603 RVA: 0x00441170 File Offset: 0x0043F370
	public void NormalItemRequest()
	{
		NormalItemRequest normalItemRequest = Aki.Protocol.NormalItemRequest.Create();
		Net instance = Singleton<Net>.Instance;
		ERequestMessageId requestMessageId = ERequestMessageId.NormalItemRequest;
		IMessage message = normalItemRequest;
		Action<NormalItemResponse, Net.CallbackStatus> handle;
		if ((handle = InventoryController.<>O.<14>__NormalItemResponse) == null)
		{
			handle = (InventoryController.<>O.<14>__NormalItemResponse = new Action<NormalItemResponse, Net.CallbackStatus>(InventoryController.NormalItemResponse));
		}
		instance.Call<NormalItemResponse>(requestMessageId, message, handle, 0);
	}

	// Token: 0x0600F874 RID: 63604 RVA: 0x004411B0 File Offset: 0x0043F3B0
	private static void NormalItemResponse(NormalItemResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		instance.ClearCommonItemData();
		RepeatedField<NormalItem> normalItemList = response.NormalItemList;
		if (normalItemList == null || normalItemList.Count == 0)
		{
			return;
		}
		foreach (NormalItem normalItem in normalItemList)
		{
			int id = normalItem.Id;
			int count = normalItem.Count;
			long expireTime = normalItem.ExpireTime;
			instance.NewCommonItemData(id, count, 0, new long?(expireTime));
			Singleton<EventSystem>.Instance.Emit<IProto_NormalItem>(EEventName.OnResponseCommonItem, normalItem);
		}
		instance.RefreshItemRedDotSet();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnResponseCommonItemFinished);
	}

	// Token: 0x0600F875 RID: 63605 RVA: 0x00441264 File Offset: 0x0043F464
	private static void NormalItemUpdateNotify(NormalItemUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<NormalItem> normalItemList = notify.NormalItemList;
		if (normalItemList == null || normalItemList.Count == 0)
		{
			return;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		bool flag = !notify.NoTips;
		foreach (NormalItem normalItem in normalItemList)
		{
			int id = normalItem.Id;
			int count = normalItem.Count;
			CommonItemData commonItemData = instance.GetCommonItemData(id, 0);
			if (commonItemData != null)
			{
				int count2 = commonItemData.GetCount();
				commonItemData.SetCount(count);
				if (count > count2 && flag)
				{
					instance.TryAddRedDotCommonItem(id, 0);
				}
				else
				{
					instance.RemoveRedDotCommonItem(id, 0);
				}
				Singleton<EventSystem>.Instance.Emit<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, normalItem, count, count2);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, id, count);
				if (instance.IsNewCommonItem(id, 0))
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGetNewItem, id);
				}
			}
		}
		if (flag)
		{
			ControllerBase<ItemHintController>.Instance.AddCommonItemList(normalItemList);
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, normalItemList);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F876 RID: 63606 RVA: 0x00441398 File Offset: 0x0043F598
	private static void NormalItemRemoveNotify(NormalItemRemoveNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<int> normalItemIdList = notify.NormalItemIdList;
		if (normalItemIdList == null || normalItemIdList.Count == 0)
		{
			return;
		}
		List<InventoryDefine.IGetItemData> list = new List<InventoryDefine.IGetItemData>();
		foreach (int itemId in normalItemIdList)
		{
			InventoryDefine.GetItemData item = new InventoryDefine.GetItemData(itemId, 0);
			list.Add(item);
		}
		ModelBase<InventoryModel>.Instance.RemoveCommonItemDataAndSaveNewList(list);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, normalItemIdList);
		foreach (int p in normalItemIdList)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, p, 0);
		}
	}

	// Token: 0x0600F877 RID: 63607 RVA: 0x00441460 File Offset: 0x0043F660
	private static void NormalItemAddNotify(NormalItemAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<NormalItem> normalItemList = notify.NormalItemList;
		if (normalItemList == null || normalItemList.Count == 0)
		{
			return;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		bool flag = !notify.NoTips;
		bool flag2 = notify.Reason != 14000;
		foreach (NormalItem normalItem in normalItemList)
		{
			int id = normalItem.Id;
			int count = normalItem.Count;
			long expireTime = normalItem.ExpireTime;
			instance.NewCommonItemData(id, count, 0, new long?(expireTime));
			if (flag)
			{
				instance.TryAddNewCommonItem(id, 0);
				instance.TryAddRedDotCommonItem(id, 0);
			}
			else
			{
				instance.RemoveRedDotCommonItem(id, 0);
			}
			Singleton<EventSystem>.Instance.Emit<IProto_NormalItem, bool>(EEventName.OnAddCommonItem, normalItem, flag2);
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, id, count);
		}
		if (flag && flag2)
		{
			ControllerBase<ItemHintController>.Instance.AddCommonItemList(normalItemList);
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, normalItemList);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemNotify, normalItemList);
		instance.SaveNewCommonItemConfigIdList();
		instance.SaveRedDotCommonItemConfigIdList();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F878 RID: 63608 RVA: 0x004415A8 File Offset: 0x0043F7A8
	public void ValidTimeItemRequest()
	{
		ValidTimeItemRequest validTimeItemRequest = Aki.Protocol.ValidTimeItemRequest.Create();
		Net instance = Singleton<Net>.Instance;
		ERequestMessageId requestMessageId = ERequestMessageId.ValidTimeItemRequest;
		IMessage message = validTimeItemRequest;
		Action<ValidTimeItemResponse, Net.CallbackStatus> handle;
		if ((handle = InventoryController.<>O.<15>__ValidTimeItemResponse) == null)
		{
			handle = (InventoryController.<>O.<15>__ValidTimeItemResponse = new Action<ValidTimeItemResponse, Net.CallbackStatus>(InventoryController.ValidTimeItemResponse));
		}
		instance.Call<ValidTimeItemResponse>(requestMessageId, message, handle, 0);
	}

	// Token: 0x0600F879 RID: 63609 RVA: 0x004415E8 File Offset: 0x0043F7E8
	private static void ValidTimeItemResponse(ValidTimeItemResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		RepeatedField<ValidTimeItem> itemList = response.ItemList;
		if (itemList == null || itemList.Count == 0)
		{
			return;
		}
		foreach (ValidTimeItem validTimeItem in itemList)
		{
			int id = validTimeItem.Id;
			int count = validTimeItem.Count;
			int incrId = validTimeItem.IncrId;
			long value = Singleton<MathUtils>.Instance.LongToBigInt(validTimeItem.ExpireTime);
			ModelBase<InventoryModel>.Instance.NewCommonItemData(id, count, incrId, new long?(value));
			Singleton<EventSystem>.Instance.Emit<IProto_NormalItem>(EEventName.OnResponseCommonItem, validTimeItem);
		}
	}

	// Token: 0x0600F87A RID: 63610 RVA: 0x00441690 File Offset: 0x0043F890
	private static void ValidTimeItemUpdateNotify(ValidTimeItemUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<ValidTimeItem> itemList = notify.ItemList;
		if (itemList == null || itemList.Count == 0)
		{
			return;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (ValidTimeItem validTimeItem in itemList)
		{
			int id = validTimeItem.Id;
			int count = validTimeItem.Count;
			int incrId = validTimeItem.IncrId;
			long endTime = Singleton<MathUtils>.Instance.LongToBigInt(validTimeItem.ExpireTime);
			CommonItemData commonItemData = instance.GetCommonItemData(id, incrId);
			if (commonItemData != null)
			{
				commonItemData.SetCount(count);
				commonItemData.SetEndTime(endTime);
				Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, id, count);
				if (ModelBase<InventoryModel>.Instance.IsNewCommonItem(id, 0))
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGetNewItem, id);
				}
			}
		}
		ControllerBase<ItemHintController>.Instance.AddCommonItemList(itemList);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, itemList);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F87B RID: 63611 RVA: 0x004417A0 File Offset: 0x0043F9A0
	private static void ValidTimeItemRemoveNotify(ValidTimeItemRemoveNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<RemoveValidTimeItem> itemList = notify.ItemList;
		if (itemList == null || itemList.Count == 0)
		{
			return;
		}
		List<InventoryDefine.IGetItemData> list = new List<InventoryDefine.IGetItemData>();
		List<int> list2 = new List<int>();
		foreach (RemoveValidTimeItem removeValidTimeItem in itemList)
		{
			InventoryDefine.GetItemData item = new InventoryDefine.GetItemData(removeValidTimeItem.ItemId, removeValidTimeItem.IncrId);
			list.Add(item);
			list2.Add(removeValidTimeItem.ItemId);
		}
		ModelBase<InventoryModel>.Instance.RemoveCommonItemDataAndSaveNewList(list);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, list2);
		foreach (RemoveValidTimeItem removeValidTimeItem2 in itemList)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, removeValidTimeItem2.ItemId, 0);
		}
	}

	// Token: 0x0600F87C RID: 63612 RVA: 0x00441890 File Offset: 0x0043FA90
	private static void ValidTimeItemAddNotify(ValidTimeItemAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<ValidTimeItem> itemList = notify.ItemList;
		if (itemList == null || itemList.Count == 0)
		{
			return;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (ValidTimeItem validTimeItem in itemList)
		{
			int id = validTimeItem.Id;
			int count = validTimeItem.Count;
			int incrId = validTimeItem.IncrId;
			long value = Singleton<MathUtils>.Instance.LongToBigInt(validTimeItem.ExpireTime);
			instance.NewCommonItemData(id, count, incrId, new long?(value));
			instance.TryAddNewCommonItem(id, 0);
			instance.TryAddRedDotCommonItem(id, 0);
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, id, count);
		}
		ControllerBase<ItemHintController>.Instance.AddCommonItemList(itemList);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, itemList);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemNotify, itemList);
		instance.SaveNewCommonItemConfigIdList();
		instance.SaveRedDotCommonItemConfigIdList();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F87D RID: 63613 RVA: 0x0044199C File Offset: 0x0043FB9C
	public void WeaponItemRequest()
	{
		WeaponItemRequest weaponItemRequest = Aki.Protocol.WeaponItemRequest.Create();
		Net instance = Singleton<Net>.Instance;
		ERequestMessageId requestMessageId = ERequestMessageId.WeaponItemRequest;
		IMessage message = weaponItemRequest;
		Action<WeaponItemResponse, Net.CallbackStatus> handle;
		if ((handle = InventoryController.<>O.<16>__WeaponItemResponse) == null)
		{
			handle = (InventoryController.<>O.<16>__WeaponItemResponse = new Action<WeaponItemResponse, Net.CallbackStatus>(InventoryController.WeaponItemResponse));
		}
		instance.Call<WeaponItemResponse>(requestMessageId, message, handle, 0);
	}

	// Token: 0x0600F87E RID: 63614 RVA: 0x004419DC File Offset: 0x0043FBDC
	private static void WeaponItemResponse(WeaponItemResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		instance.ClearWeaponItemData();
		RepeatedField<WeaponItem> weaponItemList = response.WeaponItemList;
		if (weaponItemList == null || weaponItemList.Count == 0)
		{
			return;
		}
		foreach (WeaponItem weaponItem in weaponItemList)
		{
			int id = weaponItem.Id;
			int incrId = weaponItem.IncrId;
			int funcValue = weaponItem.FuncValue;
			instance.NewWeaponItemData(id, incrId, funcValue);
			Singleton<EventSystem>.Instance.Emit<WeaponItem>(EEventName.OnResponseWeaponItem, weaponItem);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnResponseWeaponAll);
	}

	// Token: 0x0600F87F RID: 63615 RVA: 0x00441A84 File Offset: 0x0043FC84
	private static void WeaponItemAddNotify(WeaponItemAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		RepeatedField<WeaponItem> weaponItemList = notify.WeaponItemList;
		if (weaponItemList == null || weaponItemList.Count == 0)
		{
			return;
		}
		bool p = notify.Reason != 14000;
		foreach (WeaponItem weaponItem in weaponItemList)
		{
			int id = weaponItem.Id;
			int incrId = weaponItem.IncrId;
			int funcValue = weaponItem.FuncValue;
			instance.NewWeaponItemData(id, incrId, funcValue);
			instance.TryAddNewAttributeItem(incrId);
			instance.TryAddRedDotAttributeItem(incrId);
			Singleton<EventSystem>.Instance.Emit<WeaponItem, bool, bool>(EEventName.OnAddWeaponItem, weaponItem, notify.AddFromRole, p);
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<WeaponItem>, bool, bool>(EEventName.OnAddWeaponItemList, weaponItemList, notify.AddFromRole, p);
		instance.SaveNewAttributeItemUniqueIdList();
		instance.SaveRedDotAttributeItemUniqueIdList();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F880 RID: 63616 RVA: 0x00441B78 File Offset: 0x0043FD78
	private static void WeaponItemRemoveNotify(WeaponItemRemoveNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<int> weaponItemIncrIdList = notify.WeaponItemIncrIdList;
		if (weaponItemIncrIdList == null || weaponItemIncrIdList.Count == 0)
		{
			return;
		}
		ModelBase<InventoryModel>.Instance.RemoveWeaponItemDataAndSaveNewList(weaponItemIncrIdList);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnRemoveWeaponItem, weaponItemIncrIdList);
	}

	// Token: 0x0600F881 RID: 63617 RVA: 0x00441BB4 File Offset: 0x0043FDB4
	public void PhantomItemRequest()
	{
		PhantomItemRequest phantomItemRequest = Aki.Protocol.PhantomItemRequest.Create();
		Net instance = Singleton<Net>.Instance;
		ERequestMessageId requestMessageId = ERequestMessageId.PhantomItemRequest;
		IMessage message = phantomItemRequest;
		Action<PhantomItemResponse, Net.CallbackStatus> handle;
		if ((handle = InventoryController.<>O.<17>__PhantomItemResponse) == null)
		{
			handle = (InventoryController.<>O.<17>__PhantomItemResponse = new Action<PhantomItemResponse, Net.CallbackStatus>(InventoryController.PhantomItemResponse));
		}
		instance.Call<PhantomItemResponse>(requestMessageId, message, handle, 0);
	}

	// Token: 0x0600F882 RID: 63618 RVA: 0x00441BF4 File Offset: 0x0043FDF4
	private static void PhantomItemResponse(PhantomItemResponse response, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<CalabashModel>.Instance.DirectionalFusionTime = response.DirectRefineWeekTimes;
		ModelBase<PhantomBattleModel>.Instance.SetMaxCost(response.TotalCost);
		RepeatedField<int> repeatedField = (response != null) ? response.UnlockSkins : null;
		if (repeatedField != null)
		{
			ModelBase<PhantomBattleModel>.Instance.SetUnlockSkinList(repeatedField.ToArray<int>());
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		instance.ClearPhantomItemData();
		RepeatedField<PhantomItem> phantomItemList = response.PhantomItemList;
		if (phantomItemList == null || phantomItemList.Count == 0)
		{
			return;
		}
		foreach (PhantomItem phantomItem in phantomItemList)
		{
			int id = phantomItem.Id;
			int incrId = phantomItem.IncrId;
			int funcValue = phantomItem.FuncValue;
			instance.NewPhantomItemData(id, incrId, funcValue);
			Singleton<EventSystem>.Instance.Emit<PhantomItem>(EEventName.OnResponsePhantomItem, phantomItem);
		}
		Singleton<EventSystem>.Instance.Emit<PhantomItemResponse>(EEventName.OnEquipPhantomItem, response);
	}

	// Token: 0x0600F883 RID: 63619 RVA: 0x00441CE0 File Offset: 0x0043FEE0
	private static void PhantomItemAddNotify(PhantomItemAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<PhantomItem> phantomItemList = notify.PhantomItemList;
		if (phantomItemList == null || phantomItemList.Count == 0)
		{
			return;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (PhantomItem phantomItem in phantomItemList)
		{
			int id = phantomItem.Id;
			int incrId = phantomItem.IncrId;
			int funcValue = phantomItem.FuncValue;
			instance.NewPhantomItemData(id, incrId, funcValue);
			instance.TryAddNewAttributeItem(incrId);
			instance.TryAddRedDotAttributeItem(incrId);
			Singleton<EventSystem>.Instance.Emit<PhantomItem>(EEventName.OnAddPhantomItem, phantomItem);
		}
		if (notify.Reason == 19000)
		{
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomItem>, bool>(EEventName.OnAddPhantomItemList, phantomItemList, true);
			}, (float)ConfigBase<CalabashConfig>.Instance.DelayTime, null, null, true, 1f);
		}
		else
		{
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<PhantomItem>, bool>(EEventName.OnAddPhantomItemList, phantomItemList, false);
		}
		instance.SaveNewAttributeItemUniqueIdList();
		instance.SaveRedDotAttributeItemUniqueIdList();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F884 RID: 63620 RVA: 0x00441E0C File Offset: 0x0044000C
	private static void PhantomItemRemoveNotify(PhantomItemRemoveNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<int> phantomItemIncrIdList = notify.PhantomItemIncrIdList;
		if (phantomItemIncrIdList == null || phantomItemIncrIdList.Count == 0)
		{
			return;
		}
		ModelBase<InventoryModel>.Instance.RemovePhantomItemDataAndSaveNewList(phantomItemIncrIdList);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.OnRemovePhantomItem, phantomItemIncrIdList);
	}

	// Token: 0x0600F885 RID: 63621 RVA: 0x00441E48 File Offset: 0x00440048
	public void InitCalabashSkinItemData(int[] skinIdList)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (int configId in skinIdList)
		{
			instance.NewCalabashSkinItemData(configId);
		}
		instance.RefreshItemRedDotSet();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnResponseCommonItemFinished);
	}

	// Token: 0x0600F886 RID: 63622 RVA: 0x00441E8C File Offset: 0x0044008C
	public void AddCalabashSkinItemData(int[] skinIdList)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (int num in skinIdList)
		{
			instance.NewCalabashSkinItemData(num);
			instance.TryAddNewCommonItem(num, 0);
			instance.TryAddRedDotCommonItem(num, 0);
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, num, 1);
		}
		instance.SaveNewCommonItemConfigIdList();
		instance.SaveRedDotCommonItemConfigIdList();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F887 RID: 63623 RVA: 0x00441EFC File Offset: 0x004400FC
	public void InitOrnamentItemData(int[] ornamentIdList)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (int configId in ornamentIdList)
		{
			instance.NewOrnamentItemData(configId);
		}
		instance.RefreshItemRedDotSet();
	}

	// Token: 0x0600F888 RID: 63624 RVA: 0x00441F30 File Offset: 0x00440130
	public void AddOrnamentItemData(int[] ornamentIdList)
	{
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (int num in ornamentIdList)
		{
			instance.NewOrnamentItemData(num);
			instance.TryAddNewCommonItem(num, 0);
			instance.TryAddRedDotCommonItem(num, 0);
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnCommonItemCountAnyChange, num, 1);
		}
		instance.SaveNewCommonItemConfigIdList();
		instance.SaveRedDotCommonItemConfigIdList();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshItemData);
	}

	// Token: 0x0600F889 RID: 63625 RVA: 0x00441FA0 File Offset: 0x004401A0
	private static void ItemFuncValueUpdateNotify(ItemFuncValueUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		int incrId = notify.IncrId;
		AttributeItemData attributeItemData = ModelBase<InventoryModel>.Instance.GetAttributeItemData(incrId);
		if (attributeItemData == null)
		{
			return;
		}
		int funcValue = notify.FuncValue;
		attributeItemData.SetFunctionValue(funcValue);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnItemFuncValueChange, incrId);
	}

	// Token: 0x0600F88A RID: 63626 RVA: 0x00441FE3 File Offset: 0x004401E3
	private static void InventoryTabOpenNotify(ItemPkgOpenNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<InventoryModel>.Instance.SetInventoryTabOpenIdList(notify.OpenPkg.ToList<int>());
	}

	// Token: 0x0600F88B RID: 63627 RVA: 0x00441FFA File Offset: 0x004401FA
	private static void InventoryFullNotify(ItemPkgFullNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
	}

	// Token: 0x0600F88C RID: 63628 RVA: 0x00441FFC File Offset: 0x004401FC
	private static bool CanOpenView(EUiViewName viewName, object param)
	{
		if (ModelBase<SceneTeamModel>.Instance.IsPhantomTeam || ModelBase<SceneTeamModel>.Instance.HasPhantomRole())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("PhantomFormationEnterInventoryTip", Array.Empty<object>());
			return false;
		}
		return ModelBase<FunctionModel>.Instance.IsOpen(10002);
	}

	// Token: 0x0600F88D RID: 63629 RVA: 0x0044203C File Offset: 0x0044023C
	[NullableContext(2)]
	public void TryOpenPhantomFullConfirmBox(Action cancelFunc = null)
	{
		if (this.IsPhantomFullViewShow)
		{
			return;
		}
		this.IsPhantomFullViewShow = true;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomCapacityMax);
		confirmBoxDataNew.FunctionMap.Add(1, cancelFunc);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.VisionRecoveryTabView, null);
		});
		confirmBoxDataNew.SetCloseFunction(delegate
		{
			this.IsPhantomFullViewShow = false;
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600F88E RID: 63630 RVA: 0x004420BC File Offset: 0x004402BC
	public void ItemDestructPreviewRequest(DecomposeItemInfo[] itemList)
	{
		ItemDecomposePreviewRequest itemDecomposePreviewRequest = ItemDecomposePreviewRequest.Create();
		itemDecomposePreviewRequest.ItemList.AddRange(itemList);
		Singleton<Net>.Instance.Call<ItemDecomposePreviewResponse>(ERequestMessageId.ItemDecomposePreviewRequest, itemDecomposePreviewRequest, delegate(ItemDecomposePreviewResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19921, null, true, true);
				return;
			}
			List<TItem> list = new List<TItem>();
			foreach (DecomposeItemInfo decomposeItemInfo in itemList)
			{
				TItem item = new TItem(new InventoryDefine.GetItemData(decomposeItemInfo.ItemId, decomposeItemInfo.IncrId), decomposeItemInfo.Count);
				list.Add(item);
			}
			List<TItem> list2 = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair in response.ItemMap)
			{
				TItem item2 = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
				list2.Add(item2);
			}
			list2.Sort((TItem a, TItem b) => a.ItemData.ItemId - b.ItemData.ItemId);
			ItemViewDefine.DestroyPreviewData param = new ItemViewDefine.DestroyPreviewData
			{
				OriginList = list,
				ResultList = list2
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DestroyPreviewView, param, null);
		}, 0);
	}

	// Token: 0x0600F88F RID: 63631 RVA: 0x0044210C File Offset: 0x0044030C
	public void ItemDestructRequest(DecomposeItemInfo[] itemList)
	{
		ItemDecomposeRequest itemDecomposeRequest = ItemDecomposeRequest.Create();
		itemDecomposeRequest.ItemList.AddRange(itemList);
		Singleton<Net>.Instance.Call<ItemDecomposeResponse>(ERequestMessageId.ItemDecomposeRequest, itemDecomposeRequest, delegate(ItemDecomposeResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 22824, null, true, true);
				return;
			}
		}, 0);
	}

	// Token: 0x0600F890 RID: 63632 RVA: 0x0044215C File Offset: 0x0044035C
	public void InvalidItemRemoveRequest()
	{
		if (this.InvalidItemRemoveRequestLock)
		{
			return;
		}
		this.InvalidItemRemoveRequestLock = true;
		InvalidItemRequest message = InvalidItemRequest.Create();
		Singleton<Net>.Instance.Call<InvalidItemResponse>(ERequestMessageId.InvalidItemRequest, message, delegate(InvalidItemResponse response, Net.CallbackStatus _)
		{
			this.InvalidItemRemoveRequestLock = false;
			if (response == null)
			{
				return;
			}
			if (!response.HasInvalidItem && !response.HasExpireConvertItem)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InventoryView))
			{
				this.InvalidItemCheckRequest();
			}
		}, 0);
	}

	// Token: 0x0600F891 RID: 63633 RVA: 0x0044219C File Offset: 0x0044039C
	public void InvalidItemCheckRequest()
	{
		ShowInvalidItemRequest message = ShowInvalidItemRequest.Create();
		Singleton<Net>.Instance.Call<ShowInvalidItemResponse>(ERequestMessageId.ShowInvalidItemRequest, message, delegate(ShowInvalidItemResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			this.PhraseInvalidItem(response);
			this.PhraseExpireConvertItem(response);
		}, 0);
	}

	// Token: 0x0600F892 RID: 63634 RVA: 0x004421CC File Offset: 0x004403CC
	private void PhraseExpireConvertItem(ShowInvalidItemResponse response)
	{
		if (response.ExpireConvertItemInfoList == null || response.ExpireConvertItemInfoList.Count == 0)
		{
			return;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		foreach (ExpireConvertItemInfo expireConvertItemInfo in response.ExpireConvertItemInfoList)
		{
			int num;
			if (!dictionary.TryGetValue(expireConvertItemInfo.ItemId, out num))
			{
				num = 0;
			}
			dictionary[expireConvertItemInfo.ItemId] = num + expireConvertItemInfo.ItemCount;
			if (expireConvertItemInfo.ExpireConvertTargetItemInfos != null)
			{
				foreach (ExpireConvertTargetItemInfo expireConvertTargetItemInfo in expireConvertItemInfo.ExpireConvertTargetItemInfos)
				{
					int num2;
					if (!dictionary2.TryGetValue(expireConvertTargetItemInfo.ItemId, out num2))
					{
						num2 = 0;
					}
					dictionary2[expireConvertTargetItemInfo.ItemId] = num2 + expireConvertTargetItemInfo.ItemCount;
				}
			}
		}
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
			list.Add(item);
		}
		List<TItem> list2 = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair2 in dictionary2)
		{
			TItem item2 = new TItem(new InventoryDefine.GetItemData(keyValuePair2.Key, 0), keyValuePair2.Value);
			list2.Add(item2);
		}
		list.Sort((TItem a, TItem b) => a.ItemData.ItemId - b.ItemData.ItemId);
		list2.Sort((TItem a, TItem b) => a.ItemData.ItemId - b.ItemData.ItemId);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<TItem>, IReadOnlyList<TItem>>(EEventName.NotifyExpireConvertItem, list, list2);
	}

	// Token: 0x0600F893 RID: 63635 RVA: 0x004423FC File Offset: 0x004405FC
	private void PhraseInvalidItem(ShowInvalidItemResponse response)
	{
		if (response.InvalidItemList == null || response.InvalidItemList.Count == 0)
		{
			return;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (InvalidItem invalidItem in response.InvalidItemList)
		{
			int num;
			if (dictionary.TryGetValue(invalidItem.ItemId, out num))
			{
				dictionary[invalidItem.ItemId] = num + invalidItem.Count;
			}
			else
			{
				dictionary.Add(invalidItem.ItemId, invalidItem.Count);
			}
		}
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
			list.Add(item);
		}
		list.Sort((TItem a, TItem b) => a.ItemData.ItemId - b.ItemData.ItemId);
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		foreach (TItem titem in list)
		{
			dictionary2[titem.ItemData.ItemId] = titem.Count;
		}
		Singleton<EventSystem>.Instance.Emit<Dictionary<int, int>>(EEventName.NotifyInvalidItem, dictionary2);
	}

	// Token: 0x0600F894 RID: 63636 RVA: 0x0044258C File Offset: 0x0044078C
	public bool TryUseItem(int itemId, int num = 1)
	{
		Func<int, int, bool>[] useItemLogicList = this.UseItemLogicList;
		for (int i = 0; i < useItemLogicList.Length; i++)
		{
			if (useItemLogicList[i](itemId, num))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600F895 RID: 63637 RVA: 0x004425BD File Offset: 0x004407BD
	public bool TryUseGiftItemWithSelectedItem(int giftItemId, int itemId, int num = 1)
	{
		return ItemUseLogic.TryUseGiftItemWithSelectedItem(giftItemId, itemId, num);
	}

	// Token: 0x0600F896 RID: 63638 RVA: 0x004425C8 File Offset: 0x004407C8
	[NullableContext(0)]
	public UniTask<bool> PhantomFuncValueBatchRequest([Nullable(1)] int[] uniqueIdList, PhantomBatchOper operate)
	{
		InventoryController.<PhantomFuncValueBatchRequest>d__53 <PhantomFuncValueBatchRequest>d__;
		<PhantomFuncValueBatchRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<PhantomFuncValueBatchRequest>d__.uniqueIdList = uniqueIdList;
		<PhantomFuncValueBatchRequest>d__.operate = operate;
		<PhantomFuncValueBatchRequest>d__.<>1__state = -1;
		<PhantomFuncValueBatchRequest>d__.<>t__builder.Start<InventoryController.<PhantomFuncValueBatchRequest>d__53>(ref <PhantomFuncValueBatchRequest>d__);
		return <PhantomFuncValueBatchRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600F897 RID: 63639 RVA: 0x00442614 File Offset: 0x00440814
	[NullableContext(2)]
	public void PhantomManageConfigRequest(Action callback = null)
	{
		PhantomSettingRequest message = PhantomSettingRequest.Create();
		Singleton<Net>.Instance.Call<PhantomSettingResponse>(ERequestMessageId.PhantomSettingRequest, message, delegate(PhantomSettingResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			ModelBase<InventoryModel>.Instance.InitPhantomManageConfig(response);
			if (callback != null)
			{
				callback();
			}
		}, 0);
	}

	// Token: 0x0600F898 RID: 63640 RVA: 0x00442654 File Offset: 0x00440854
	public UniTask PhantomManageConfigRequestAsync()
	{
		InventoryController.<PhantomManageConfigRequestAsync>d__55 <PhantomManageConfigRequestAsync>d__;
		<PhantomManageConfigRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PhantomManageConfigRequestAsync>d__.<>1__state = -1;
		<PhantomManageConfigRequestAsync>d__.<>t__builder.Start<InventoryController.<PhantomManageConfigRequestAsync>d__55>(ref <PhantomManageConfigRequestAsync>d__);
		return <PhantomManageConfigRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F899 RID: 63641 RVA: 0x00442690 File Offset: 0x00440890
	[NullableContext(0)]
	public UniTask<ErrorCode> PhantomManageConfigUpdateRequest(PhantomSettingType type, [Nullable(2)] OnePhantomSetting setting)
	{
		InventoryController.<PhantomManageConfigUpdateRequest>d__56 <PhantomManageConfigUpdateRequest>d__;
		<PhantomManageConfigUpdateRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<ErrorCode>.Create();
		<PhantomManageConfigUpdateRequest>d__.type = type;
		<PhantomManageConfigUpdateRequest>d__.setting = setting;
		<PhantomManageConfigUpdateRequest>d__.<>1__state = -1;
		<PhantomManageConfigUpdateRequest>d__.<>t__builder.Start<InventoryController.<PhantomManageConfigUpdateRequest>d__56>(ref <PhantomManageConfigUpdateRequest>d__);
		return <PhantomManageConfigUpdateRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600F89A RID: 63642 RVA: 0x004426DC File Offset: 0x004408DC
	[NullableContext(0)]
	public UniTask<bool> PhantomSettingBatchUpdateRequestAsync([Nullable(1)] PhantomSettingInfo[] settings)
	{
		InventoryController.<PhantomSettingBatchUpdateRequestAsync>d__57 <PhantomSettingBatchUpdateRequestAsync>d__;
		<PhantomSettingBatchUpdateRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<PhantomSettingBatchUpdateRequestAsync>d__.settings = settings;
		<PhantomSettingBatchUpdateRequestAsync>d__.<>1__state = -1;
		<PhantomSettingBatchUpdateRequestAsync>d__.<>t__builder.Start<InventoryController.<PhantomSettingBatchUpdateRequestAsync>d__57>(ref <PhantomSettingBatchUpdateRequestAsync>d__);
		return <PhantomSettingBatchUpdateRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F89B RID: 63643 RVA: 0x00442720 File Offset: 0x00440920
	public void OpenManageConfigView()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10096))
		{
			return;
		}
		CalabashRootViewData param = new CalabashRootViewData
		{
			TabViewName = EUiTabViewName.PhantomManageConfigView,
			Param = null
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashRootView, param, null);
	}

	// Token: 0x0600F89C RID: 63644 RVA: 0x00442768 File Offset: 0x00440968
	public void OpenManageConfigNewView()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10096))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GenericPrompt_FunctionDisable_TipsText", Array.Empty<object>());
			return;
		}
		CalabashRootViewData param = new CalabashRootViewData
		{
			TabViewName = EUiTabViewName.PhantomManageConfigNewView,
			Param = null
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashRootView, param, null);
	}

	// Token: 0x0600F89D RID: 63645 RVA: 0x004427C4 File Offset: 0x004409C4
	private int GetDeprecatedPhantomCount()
	{
		List<PhantomItemData> phantomItemDataList = ModelBase<InventoryModel>.Instance.GetPhantomItemDataList();
		int num = 0;
		using (List<PhantomItemData>.Enumerator enumerator = phantomItemDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIsDeprecated())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600F89E RID: 63646 RVA: 0x00442824 File Offset: 0x00440A24
	private int GetTotalPhantomCount()
	{
		return ModelBase<InventoryModel>.Instance.GetPhantomItemDataList().Count;
	}

	// Token: 0x0600F89F RID: 63647 RVA: 0x00442838 File Offset: 0x00440A38
	public bool CheckAndShowPhantomTips()
	{
		if (this.IsPhantomFullViewLoginNotShow)
		{
			return false;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomSmartDiscardPopupView))
		{
			return false;
		}
		if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
		{
			return false;
		}
		int deprecatedPhantomCount = this.GetDeprecatedPhantomCount();
		int totalPhantomCount = this.GetTotalPhantomCount();
		if (deprecatedPhantomCount >= ConfigBase<InventoryConfig>.Instance.GetPhantomFusionThreshold())
		{
			this.ShowPhantomFusionTip(deprecatedPhantomCount);
			return true;
		}
		if (totalPhantomCount >= ConfigBase<InventoryConfig>.Instance.GetPhantomDiscardThreshold())
		{
			this.ShowPhantomDiscardTip(totalPhantomCount);
			return true;
		}
		return false;
	}

	// Token: 0x0600F8A0 RID: 63648 RVA: 0x004428AC File Offset: 0x00440AAC
	private void ShowPhantomFusionTip(int deprecatedCount)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomFullFusionConfirm);
		PhantomDiscardPlanRecycleReport logData = new PhantomDiscardPlanRecycleReport
		{
			i_type = 0
		};
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			logData.i_operation = 0;
			ControllerBase<LogReportController>.Instance.LogReport(logData);
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			logData.i_operation = 1;
			ControllerBase<LogReportController>.Instance.LogReport(logData);
			ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.VisionRecoveryTabView, null);
		});
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			deprecatedCount.ToString()
		});
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleTextKey = "ConfirmBox_363_Desc";
		confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
		{
			this.IsPhantomFullViewLoginNotShow = isSelectOn;
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600F8A1 RID: 63649 RVA: 0x0044295C File Offset: 0x00440B5C
	private void ShowPhantomDiscardTip(int totalCount)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomFullDiscardConfirm);
		PhantomDiscardPlanRecycleReport logData = new PhantomDiscardPlanRecycleReport
		{
			i_type = 1
		};
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			logData.i_operation = 0;
			ControllerBase<LogReportController>.Instance.LogReport(logData);
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			logData.i_operation = 1;
			ControllerBase<LogReportController>.Instance.LogReport(logData);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomSmartDiscardPopupView, null, delegate(bool success, int viewId)
			{
				UiViewBase uiViewBase = null;
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomManageView))
				{
					uiViewBase = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PhantomManageView);
				}
				else if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InventoryView))
				{
					uiViewBase = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.InventoryView);
				}
				if (uiViewBase != null)
				{
					uiViewBase.AddChildViewById(viewId);
				}
			});
		});
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			totalCount.ToString()
		});
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleTextKey = "ConfirmBox_363_Desc";
		confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
		{
			this.IsPhantomFullViewLoginNotShow = isSelectOn;
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600F8A2 RID: 63650 RVA: 0x00442A0C File Offset: 0x00440C0C
	[NullableContext(0)]
	public UniTask<bool> ShowPhantomDiscardFusionTip([Nullable(1)] int[] discardList)
	{
		InventoryController.<ShowPhantomDiscardFusionTip>d__65 <ShowPhantomDiscardFusionTip>d__;
		<ShowPhantomDiscardFusionTip>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ShowPhantomDiscardFusionTip>d__.<>4__this = this;
		<ShowPhantomDiscardFusionTip>d__.discardList = discardList;
		<ShowPhantomDiscardFusionTip>d__.<>1__state = -1;
		<ShowPhantomDiscardFusionTip>d__.<>t__builder.Start<InventoryController.<ShowPhantomDiscardFusionTip>d__65>(ref <ShowPhantomDiscardFusionTip>d__);
		return <ShowPhantomDiscardFusionTip>d__.<>t__builder.Task;
	}

	// Token: 0x0600F8A3 RID: 63651 RVA: 0x00442A58 File Offset: 0x00440C58
	public InventoryController()
	{
		Func<int, int, bool>[] array = new Func<int, int, bool>[18];
		int num = 0;
		Func<int, int, bool> func;
		if ((func = InventoryController.<>O.<18>__TryUseOrnamentItem) == null)
		{
			func = (InventoryController.<>O.<18>__TryUseOrnamentItem = new Func<int, int, bool>(ItemUseLogic.TryUseOrnamentItem));
		}
		array[num] = func;
		int num2 = 1;
		Func<int, int, bool> func2;
		if ((func2 = InventoryController.<>O.<19>__TryUseVisionRefineItem) == null)
		{
			func2 = (InventoryController.<>O.<19>__TryUseVisionRefineItem = new Func<int, int, bool>(ItemUseLogic.TryUseVisionRefineItem));
		}
		array[num2] = func2;
		int num3 = 2;
		Func<int, int, bool> func3;
		if ((func3 = InventoryController.<>O.<20>__TryUseVisionRefineSubItem) == null)
		{
			func3 = (InventoryController.<>O.<20>__TryUseVisionRefineSubItem = new Func<int, int, bool>(ItemUseLogic.TryUseVisionRefineSubItem));
		}
		array[num3] = func3;
		int num4 = 3;
		Func<int, int, bool> func4;
		if ((func4 = InventoryController.<>O.<21>__TryUseUiPlayItem) == null)
		{
			func4 = (InventoryController.<>O.<21>__TryUseUiPlayItem = new Func<int, int, bool>(ItemUseLogic.TryUseUiPlayItem));
		}
		array[num4] = func4;
		int num5 = 4;
		Func<int, int, bool> func5;
		if ((func5 = InventoryController.<>O.<22>__TryUseBuffItem) == null)
		{
			func5 = (InventoryController.<>O.<22>__TryUseBuffItem = new Func<int, int, bool>(ItemUseLogic.TryUseBuffItem));
		}
		array[num5] = func5;
		int num6 = 5;
		Func<int, int, bool> func6;
		if ((func6 = InventoryController.<>O.<23>__TryUsePowerItem) == null)
		{
			func6 = (InventoryController.<>O.<23>__TryUsePowerItem = new Func<int, int, bool>(ItemUseLogic.TryUsePowerItem));
		}
		array[num6] = func6;
		int num7 = 6;
		Func<int, int, bool> func7;
		if ((func7 = InventoryController.<>O.<24>__TryUseTotalTopUpRolePickItem) == null)
		{
			func7 = (InventoryController.<>O.<24>__TryUseTotalTopUpRolePickItem = new Func<int, int, bool>(ItemUseLogic.TryUseTotalTopUpRolePickItem));
		}
		array[num7] = func7;
		int num8 = 7;
		Func<int, int, bool> func8;
		if ((func8 = InventoryController.<>O.<25>__TryUseGiftItem) == null)
		{
			func8 = (InventoryController.<>O.<25>__TryUseGiftItem = new Func<int, int, bool>(ItemUseLogic.TryUseGiftItem));
		}
		array[num8] = func8;
		int num9 = 8;
		Func<int, int, bool> func9;
		if ((func9 = InventoryController.<>O.<26>__TryUseResonantChainOptionalItem) == null)
		{
			func9 = (InventoryController.<>O.<26>__TryUseResonantChainOptionalItem = new Func<int, int, bool>(ItemUseLogic.TryUseResonantChainOptionalItem));
		}
		array[num9] = func9;
		int num10 = 9;
		Func<int, int, bool> func10;
		if ((func10 = InventoryController.<>O.<27>__TryUseMonthCardItem) == null)
		{
			func10 = (InventoryController.<>O.<27>__TryUseMonthCardItem = new Func<int, int, bool>(ItemUseLogic.TryUseMonthCardItem));
		}
		array[num10] = func10;
		int num11 = 10;
		Func<int, int, bool> func11;
		if ((func11 = InventoryController.<>O.<28>__TryUseBattlePassItem) == null)
		{
			func11 = (InventoryController.<>O.<28>__TryUseBattlePassItem = new Func<int, int, bool>(ItemUseLogic.TryUseBattlePassItem));
		}
		array[num11] = func11;
		int num12 = 11;
		Func<int, int, bool> func12;
		if ((func12 = InventoryController.<>O.<29>__TryUseBirthdayItem) == null)
		{
			func12 = (InventoryController.<>O.<29>__TryUseBirthdayItem = new Func<int, int, bool>(ItemUseLogic.TryUseBirthdayItem));
		}
		array[num12] = func12;
		int num13 = 12;
		Func<int, int, bool> func13;
		if ((func13 = InventoryController.<>O.<30>__TryUseBrochureItem) == null)
		{
			func13 = (InventoryController.<>O.<30>__TryUseBrochureItem = new Func<int, int, bool>(ItemUseLogic.TryUseBrochureItem));
		}
		array[num13] = func13;
		int num14 = 13;
		Func<int, int, bool> func14;
		if ((func14 = InventoryController.<>O.<31>__TryUseBuffEquipItem) == null)
		{
			func14 = (InventoryController.<>O.<31>__TryUseBuffEquipItem = new Func<int, int, bool>(ItemUseLogic.TryUseBuffEquipItem));
		}
		array[num14] = func14;
		int num15 = 14;
		Func<int, int, bool> func15;
		if ((func15 = InventoryController.<>O.<32>__TryUsePayShopCouponItem) == null)
		{
			func15 = (InventoryController.<>O.<32>__TryUsePayShopCouponItem = new Func<int, int, bool>(ItemUseLogic.TryUsePayShopCouponItem));
		}
		array[num15] = func15;
		int num16 = 15;
		Func<int, int, bool> func16;
		if ((func16 = InventoryController.<>O.<33>__TryUseStudentCardItem) == null)
		{
			func16 = (InventoryController.<>O.<33>__TryUseStudentCardItem = new Func<int, int, bool>(ItemUseLogic.TryUseStudentCardItem));
		}
		array[num16] = func16;
		int num17 = 16;
		Func<int, int, bool> func17;
		if ((func17 = InventoryController.<>O.<34>__TryUseParameterItem) == null)
		{
			func17 = (InventoryController.<>O.<34>__TryUseParameterItem = new Func<int, int, bool>(ItemUseLogic.TryUseParameterItem));
		}
		array[num17] = func17;
		int num18 = 17;
		Func<int, int, bool> func18;
		if ((func18 = InventoryController.<>O.<35>__TryUseShipTowerItem) == null)
		{
			func18 = (InventoryController.<>O.<35>__TryUseShipTowerItem = new Func<int, int, bool>(ItemUseLogic.TryUseShipTowerItem));
		}
		array[num18] = func18;
		this.UseItemLogicList = array;
		base..ctor();
	}

	// Token: 0x040077DD RID: 30685
	private const int VISION_CATCH_REASON = 19000;

	// Token: 0x040077DE RID: 30686
	private const int GACHA_REASON = 14000;

	// Token: 0x040077DF RID: 30687
	private bool IsPhantomFullViewShow = true;

	// Token: 0x040077E0 RID: 30688
	private bool IsPhantomFullViewLoginNotShow;

	// Token: 0x040077E1 RID: 30689
	private bool IsPhantomDiscardFuseLoginNotShow;

	// Token: 0x040077E2 RID: 30690
	private bool InvalidItemRemoveRequestLock;

	// Token: 0x040077E3 RID: 30691
	private readonly Func<int, int, bool>[] UseItemLogicList;

	// Token: 0x020083A1 RID: 33697
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402CA31 RID: 182833
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<NormalItemUpdateNotify, Net.CallbackStatus> <0>__NormalItemUpdateNotify;

		// Token: 0x0402CA32 RID: 182834
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<NormalItemRemoveNotify, Net.CallbackStatus> <1>__NormalItemRemoveNotify;

		// Token: 0x0402CA33 RID: 182835
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<NormalItemAddNotify, Net.CallbackStatus> <2>__NormalItemAddNotify;

		// Token: 0x0402CA34 RID: 182836
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<ValidTimeItemUpdateNotify, Net.CallbackStatus> <3>__ValidTimeItemUpdateNotify;

		// Token: 0x0402CA35 RID: 182837
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<ValidTimeItemRemoveNotify, Net.CallbackStatus> <4>__ValidTimeItemRemoveNotify;

		// Token: 0x0402CA36 RID: 182838
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<ValidTimeItemAddNotify, Net.CallbackStatus> <5>__ValidTimeItemAddNotify;

		// Token: 0x0402CA37 RID: 182839
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<WeaponItemAddNotify, Net.CallbackStatus> <6>__WeaponItemAddNotify;

		// Token: 0x0402CA38 RID: 182840
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<WeaponItemRemoveNotify, Net.CallbackStatus> <7>__WeaponItemRemoveNotify;

		// Token: 0x0402CA39 RID: 182841
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<PhantomItemAddNotify, Net.CallbackStatus> <8>__PhantomItemAddNotify;

		// Token: 0x0402CA3A RID: 182842
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<PhantomItemRemoveNotify, Net.CallbackStatus> <9>__PhantomItemRemoveNotify;

		// Token: 0x0402CA3B RID: 182843
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<ItemFuncValueUpdateNotify, Net.CallbackStatus> <10>__ItemFuncValueUpdateNotify;

		// Token: 0x0402CA3C RID: 182844
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<ItemPkgOpenNotify, Net.CallbackStatus> <11>__InventoryTabOpenNotify;

		// Token: 0x0402CA3D RID: 182845
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<ItemPkgFullNotify, Net.CallbackStatus> <12>__InventoryFullNotify;

		// Token: 0x0402CA3E RID: 182846
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<EUiViewName, object, bool> <13>__CanOpenView;

		// Token: 0x0402CA3F RID: 182847
		[Nullable(new byte[]
		{
			0,
			2,
			2
		})]
		public static Action<NormalItemResponse, Net.CallbackStatus> <14>__NormalItemResponse;

		// Token: 0x0402CA40 RID: 182848
		[Nullable(new byte[]
		{
			0,
			2,
			2
		})]
		public static Action<ValidTimeItemResponse, Net.CallbackStatus> <15>__ValidTimeItemResponse;

		// Token: 0x0402CA41 RID: 182849
		[Nullable(new byte[]
		{
			0,
			2,
			2
		})]
		public static Action<WeaponItemResponse, Net.CallbackStatus> <16>__WeaponItemResponse;

		// Token: 0x0402CA42 RID: 182850
		[Nullable(new byte[]
		{
			0,
			2,
			2
		})]
		public static Action<PhantomItemResponse, Net.CallbackStatus> <17>__PhantomItemResponse;

		// Token: 0x0402CA43 RID: 182851
		[Nullable(0)]
		public static Func<int, int, bool> <18>__TryUseOrnamentItem;

		// Token: 0x0402CA44 RID: 182852
		[Nullable(0)]
		public static Func<int, int, bool> <19>__TryUseVisionRefineItem;

		// Token: 0x0402CA45 RID: 182853
		[Nullable(0)]
		public static Func<int, int, bool> <20>__TryUseVisionRefineSubItem;

		// Token: 0x0402CA46 RID: 182854
		[Nullable(0)]
		public static Func<int, int, bool> <21>__TryUseUiPlayItem;

		// Token: 0x0402CA47 RID: 182855
		[Nullable(0)]
		public static Func<int, int, bool> <22>__TryUseBuffItem;

		// Token: 0x0402CA48 RID: 182856
		[Nullable(0)]
		public static Func<int, int, bool> <23>__TryUsePowerItem;

		// Token: 0x0402CA49 RID: 182857
		[Nullable(0)]
		public static Func<int, int, bool> <24>__TryUseTotalTopUpRolePickItem;

		// Token: 0x0402CA4A RID: 182858
		[Nullable(0)]
		public static Func<int, int, bool> <25>__TryUseGiftItem;

		// Token: 0x0402CA4B RID: 182859
		[Nullable(0)]
		public static Func<int, int, bool> <26>__TryUseResonantChainOptionalItem;

		// Token: 0x0402CA4C RID: 182860
		[Nullable(0)]
		public static Func<int, int, bool> <27>__TryUseMonthCardItem;

		// Token: 0x0402CA4D RID: 182861
		[Nullable(0)]
		public static Func<int, int, bool> <28>__TryUseBattlePassItem;

		// Token: 0x0402CA4E RID: 182862
		[Nullable(0)]
		public static Func<int, int, bool> <29>__TryUseBirthdayItem;

		// Token: 0x0402CA4F RID: 182863
		[Nullable(0)]
		public static Func<int, int, bool> <30>__TryUseBrochureItem;

		// Token: 0x0402CA50 RID: 182864
		[Nullable(0)]
		public static Func<int, int, bool> <31>__TryUseBuffEquipItem;

		// Token: 0x0402CA51 RID: 182865
		[Nullable(0)]
		public static Func<int, int, bool> <32>__TryUsePayShopCouponItem;

		// Token: 0x0402CA52 RID: 182866
		[Nullable(0)]
		public static Func<int, int, bool> <33>__TryUseStudentCardItem;

		// Token: 0x0402CA53 RID: 182867
		[Nullable(0)]
		public static Func<int, int, bool> <34>__TryUseParameterItem;

		// Token: 0x0402CA54 RID: 182868
		[Nullable(0)]
		public static Func<int, int, bool> <35>__TryUseShipTowerItem;
	}
}
