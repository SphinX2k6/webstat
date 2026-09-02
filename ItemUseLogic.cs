using System;
using System.Collections.Generic;
using System.Linq;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Cipher;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02002022 RID: 8226
public class ItemUseLogic
{
	// Token: 0x0600FA09 RID: 64009 RVA: 0x00447588 File Offset: 0x00445788
	public static bool TryUseParameterItem(int itemId, int num = 1)
	{
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
		if (itemConfig == null)
		{
			return false;
		}
		if (itemConfig.Value.Parameters().Count == 0)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Inventory;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "使用道具失败,使用参数为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		ControllerBase<InventoryController>.Instance.RequestItemUse(itemId, num);
		return true;
	}

	// Token: 0x0600FA0A RID: 64010 RVA: 0x00447600 File Offset: 0x00445800
	public static bool TryUseUiPlayItem(int itemId, int num = 1)
	{
		ItemInfo? config = ConfigItemInfoById.GetConfig(itemId, true);
		if (config == null || !config.Value.UiPlayItem)
		{
			return false;
		}
		UiPlayItem? config2 = ConfigUiPlayItemById.GetConfig(itemId, true);
		if (config2 == null)
		{
			return false;
		}
		ESimpleGameplayType esimpleGameplayType = ESimpleGameplayTypeExtensions.FromString(config2.Value.Type);
		if (esimpleGameplayType != ESimpleGameplayType.Cipher)
		{
			if (esimpleGameplayType == ESimpleGameplayType.SignalBreak)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SignalDecodeView, config2.Value.UiPlayKey, null);
			}
		}
		else
		{
			ControllerBase<CipherController>.Instance.OpenCipherView(config2.Value.UiPlayKey);
		}
		return true;
	}

	// Token: 0x0600FA0B RID: 64011 RVA: 0x004476A0 File Offset: 0x004458A0
	public static bool TryUseBattlePassItem(int itemId, int num = 1)
	{
		ItemUseLogic.<>c__DisplayClass2_0 CS$<>8__locals1 = new ItemUseLogic.<>c__DisplayClass2_0();
		CS$<>8__locals1.itemId = itemId;
		if (CS$<>8__locals1.itemId == ModelBase<BattlePassModel>.Instance.PrimaryItemId || CS$<>8__locals1.itemId == ModelBase<BattlePassModel>.Instance.AdvanceItemId)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(ModelBase<BattlePassModel>.Instance.GetBattlePassItemConfirmId(CS$<>8__locals1.itemId));
			confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<TryUseBattlePassItem>g__confirmCallback|0));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return true;
		}
		return false;
	}

	// Token: 0x0600FA0C RID: 64012 RVA: 0x0044771B File Offset: 0x0044591B
	public static bool TryUseBuffItem(int itemId, int num = 1)
	{
		return ItemUseLogic.TryUseBuffItem(itemId, num, false, 0);
	}

	// Token: 0x0600FA0D RID: 64013 RVA: 0x00447728 File Offset: 0x00445928
	public static bool TryUseBuffItem(int itemId, int num = 1, bool isDirect = false, int roleConfigId = 0)
	{
		if (!ConfigBase<BuffItemConfig>.Instance.IsBuffItem(itemId))
		{
			return false;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config != null && config.Value.CanUseItem == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigMultiTextLang.GetLocalTextNew("Dungeon_BanItem", null));
				return true;
			}
		}
		if (ModelBase<BuffItemModel>.Instance.GetBuffItemRemainCdTime(itemId) > 0.0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("UseBuffCdText", Array.Empty<object>());
			return true;
		}
		if (ConfigBase<BuffItemConfig>.Instance.IsTeamBuffItem(itemId))
		{
			ControllerBase<BuffItemControl>.Instance.RequestUseBuffItem(itemId, 1, -1);
			return true;
		}
		ControllerBase<BuffItemControl>.Instance.InitializeAllUseBuffItemRoleFromPlayerFormationInstance(itemId);
		if (ModelBase<BuffItemModel>.Instance.GetAllUseBuffItemRole().Count <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoneRole", Array.Empty<object>());
			return true;
		}
		if (!isDirect)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.UseBuffItemView, itemId, null);
			return true;
		}
		return ItemUseLogic.TryUseSingleBuffItemDirectly(itemId, num, roleConfigId);
	}

	// Token: 0x0600FA0E RID: 64014 RVA: 0x0044783C File Offset: 0x00445A3C
	private static bool TryUseSingleBuffItemDirectly(int itemId, int num = 1, int roleConfigId = 0)
	{
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)roleConfigId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId
		});
		if (teamItem == null)
		{
			return false;
		}
		if (teamItem.GetConfigId > 100000)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NoneRole", Array.Empty<object>());
			return true;
		}
		object obj;
		if (teamItem == null)
		{
			obj = null;
		}
		else
		{
			EntityHandle entityHandle = teamItem.EntityHandle;
			obj = ((entityHandle != null) ? entityHandle.Entity : null);
		}
		object obj2 = obj;
		BaseAttributeComponent baseAttributeComponent = (obj2 != null) ? obj2.GetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent == null)
		{
			return false;
		}
		double num2 = Math.Ceiling((double)baseAttributeComponent.GetCurrentValue(EAttributeType.Life));
		double num3 = Math.Ceiling((double)baseAttributeComponent.GetCurrentValue(EAttributeType.LifeMax));
		if (num2 >= num3)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("HpFull", null);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(localTextNew);
			return true;
		}
		ControllerBase<BuffItemControl>.Instance.RequestUseBuffItem(itemId, num, roleConfigId);
		return true;
	}

	// Token: 0x0600FA0F RID: 64015 RVA: 0x004478FD File Offset: 0x00445AFD
	public static bool TryUsePowerItem(int itemId, int num = 1)
	{
		if (itemId == 10800)
		{
			ControllerBase<PowerController>.Instance.OpenPowerRecoveryExchangeView((EPowerRecoveryItem)itemId);
			return true;
		}
		return false;
	}

	// Token: 0x0600FA10 RID: 64016 RVA: 0x00447918 File Offset: 0x00445B18
	public static bool TryUseMonthCardItem(int itemId, int num = 1)
	{
		ItemUseLogic.<>c__DisplayClass7_0 CS$<>8__locals1 = new ItemUseLogic.<>c__DisplayClass7_0();
		CS$<>8__locals1.itemId = itemId;
		ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(CS$<>8__locals1.itemId);
		int key;
		if (!config.Value.Parameters().TryGetValue(13, out key) && !config.Value.Parameters().TryGetValue(14, out key))
		{
			return false;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MonthCardUseTips);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(config.Value.Name, null);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			localTextNew,
			ConfigBase<MonthCardConfig>.Instance.GetConfig(key).Value.Days.ToString()
		});
		confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<TryUseMonthCardItem>g__confirmFunction|0));
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		return true;
	}

	// Token: 0x0600FA11 RID: 64017 RVA: 0x00447A00 File Offset: 0x00445C00
	public static bool TryUseGiftItem(int itemId, int num = 1)
	{
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(itemId, 0);
		if (commonItemData == null)
		{
			return false;
		}
		if (commonItemData.GetType().GetValueOrDefault() != InventoryDefine.EItemType.Gift)
		{
			return false;
		}
		ItemInfo? config = ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(itemId);
		bool flag = false;
		int id;
		if (!config.Value.Parameters().TryGetValue(2, out id))
		{
			if (!config.Value.Parameters().TryGetValue(4, out id))
			{
				return false;
			}
			flag = true;
		}
		GiftPackage value = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(id).Value;
		if (flag)
		{
			return true;
		}
		if (value.Type == GiftType.ResonantChainOptional)
		{
			return false;
		}
		if (value.Type != GiftType.Fixed && value.Type != GiftType.Random && value.Type != GiftType.RandomPhantom && value.Type != GiftType.CaptureMonster)
		{
			ControllerBase<InventoryGiftController>.Instance.SendGiftPackPreviewRequest(itemId, value, null, 1);
			return true;
		}
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(config.Value.Name, null);
		List<TItem> list = new List<TItem>();
		TItem item = new TItem(new InventoryDefine.GetItemData(config.Value.Id, 0), itemCountByConfigId);
		list.Add(item);
		if (itemCountByConfigId > 1)
		{
			AcquireData acquireData = new AcquireData();
			acquireData.SetAcquireViewType(EAcquireViewType.SelectAmount);
			acquireData.SetAmount(1);
			acquireData.SetMaxAmount(itemCountByConfigId);
			acquireData.SetRemainItemCount(itemCountByConfigId);
			acquireData.SetItemData(list);
			acquireData.SetNameText(localTextNew);
			acquireData.SetConfigId(itemId);
			acquireData.SetRightButtonFunction(delegate
			{
				ItemUseLogic.OnClickedUseMultiGift(itemId, acquireData.GetAmount());
				return default(UniTask);
			});
			ControllerBase<InventoryGiftController>.Instance.ShowAcquireView(acquireData);
			return true;
		}
		ControllerBase<InventoryGiftController>.Instance.SendItemGiftUseRequest(itemId, 1, null);
		return true;
	}

	// Token: 0x0600FA12 RID: 64018 RVA: 0x00447C0C File Offset: 0x00445E0C
	public static bool TryUseGiftItemWithSelectedItem(int giftItemId, int itemId, int num = 1)
	{
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(giftItemId, 0);
		if (commonItemData == null)
		{
			return false;
		}
		if (commonItemData.GetType().GetValueOrDefault() != InventoryDefine.EItemType.Gift)
		{
			return false;
		}
		int id;
		if (!ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(giftItemId).Value.Parameters().TryGetValue(2, out id))
		{
			return false;
		}
		GiftPackage value = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(id).Value;
		if (value.Type != GiftType.Optional)
		{
			return false;
		}
		ControllerBase<InventoryGiftController>.Instance.SendGiftPackPreviewRequest(giftItemId, value, new int?(itemId), num);
		return true;
	}

	// Token: 0x0600FA13 RID: 64019 RVA: 0x00447CA0 File Offset: 0x00445EA0
	public static bool TryUseShipTowerItem(int itemId, int num = 1)
	{
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(itemId, 0);
		if (commonItemData == null)
		{
			return false;
		}
		if (commonItemData.GetType().GetValueOrDefault() != InventoryDefine.EItemType.ShipTowerBuff)
		{
			return false;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OpenActivityViewShipTower);
		return true;
	}

	// Token: 0x0600FA14 RID: 64020 RVA: 0x00447CE7 File Offset: 0x00445EE7
	public static bool TryUseStudentCardItem(int itemId, int num = 1)
	{
		if (itemId != 70290000)
		{
			return false;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AdmissionStudentCardView, null, null);
		return true;
	}

	// Token: 0x0600FA15 RID: 64021 RVA: 0x00447D08 File Offset: 0x00445F08
	public static bool TryUsePayShopCouponItem(int itemId, int num = 1)
	{
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(itemId, 0);
		if (commonItemData == null)
		{
			return false;
		}
		if (commonItemData.GetType().GetValueOrDefault() != InventoryDefine.EItemType.PayShopCoupon)
		{
			return false;
		}
		PayShopViewData payShopViewData = new PayShopViewData();
		payShopViewData.PayShopId = PayShopDefine.EPayShopTabType.SkinShop;
		ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, null);
		return true;
	}

	// Token: 0x0600FA16 RID: 64022 RVA: 0x00447D58 File Offset: 0x00445F58
	private static void OnClickedUseMultiGift(int itemConfigId, int count)
	{
		if (count > 0)
		{
			ControllerBase<InventoryGiftController>.Instance.SendItemGiftUseRequest(itemConfigId, count, null);
			return;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NotEnoughItem", Array.Empty<object>());
	}

	// Token: 0x0600FA17 RID: 64023 RVA: 0x00447D80 File Offset: 0x00445F80
	public static bool TryUseBirthdayItem(int itemId, int num = 1)
	{
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(itemId, 0);
		if (commonItemData == null)
		{
			return false;
		}
		if (commonItemData.GetType().GetValueOrDefault() != InventoryDefine.EItemType.BirthdayItem)
		{
			return false;
		}
		ControllerBase<BirthdayController>.Instance.UseBirthdayItem(itemId);
		return true;
	}

	// Token: 0x0600FA18 RID: 64024 RVA: 0x00447DC4 File Offset: 0x00445FC4
	public static bool TryUseVisionRefineItem(int itemId, int num = 1)
	{
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(itemId, 0);
		if (commonItemData == null)
		{
			return false;
		}
		if (!commonItemData.GetConfig().ShowTypes.Contains(54))
		{
			return false;
		}
		VisionRefineTabViewParam param = new VisionRefineTabViewParam
		{
			ViewState = ERefineViewState.Choose,
			RefineType = new EVisionRefineRefineType?(EVisionRefineRefineType.Main)
		};
		ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.VisionRefineTabView, param);
		return true;
	}

	// Token: 0x0600FA19 RID: 64025 RVA: 0x00447E24 File Offset: 0x00446024
	public static bool TryUseVisionRefineSubItem(int itemId, int num = 1)
	{
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(itemId, 0);
		if (commonItemData == null)
		{
			return false;
		}
		if (!commonItemData.GetConfig().ShowTypes.Contains(58))
		{
			return false;
		}
		VisionRefineTabViewParam param = new VisionRefineTabViewParam
		{
			ViewState = ERefineViewState.Choose,
			RefineType = new EVisionRefineRefineType?(EVisionRefineRefineType.Sub)
		};
		ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.VisionRefineTabView, param);
		return true;
	}

	// Token: 0x0600FA1A RID: 64026 RVA: 0x00447E84 File Offset: 0x00446084
	public static bool TryUseBuffEquipItem(int itemId, int num = 1)
	{
		ItemUseLogic.<>c__DisplayClass17_0 CS$<>8__locals1 = new ItemUseLogic.<>c__DisplayClass17_0();
		CS$<>8__locals1.itemId = itemId;
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(CS$<>8__locals1.itemId);
		if (itemConfig == null)
		{
			return false;
		}
		if (itemConfig.Value.Parameters().Count == 0)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Inventory;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "使用道具失败,使用参数为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemId", CS$<>8__locals1.itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		BuffItemConfig instance2 = ConfigBase<BuffItemConfig>.Instance;
		BuffItemModel instance3 = ModelBase<BuffItemModel>.Instance;
		if (instance2.IsEquipBuffItem(CS$<>8__locals1.itemId) && !instance3.IsEquippedBuffItem(CS$<>8__locals1.itemId))
		{
			int buffEquipItemCategory = instance2.GetBuffEquipItemCategory(CS$<>8__locals1.itemId);
			int? equippedBuffItemId = instance3.GetEquippedBuffItemId((EBuffItemEquipCategory)buffEquipItemCategory);
			if (equippedBuffItemId != null)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ReplaceBuffEquipItemConfirm);
				confirmBoxDataNew.FunctionMap.Add(1, delegate
				{
				});
				confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<TryUseBuffEquipItem>g__confirmCallback|0));
				string name = ConfigBase<InventoryConfig>.Instance.GetItemConfig(equippedBuffItemId.Value).Value.Name;
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					ConfigMultiTextLang.GetLocalTextNew(name, null)
				});
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return true;
			}
		}
		ControllerBase<InventoryController>.Instance.RequestItemUse(CS$<>8__locals1.itemId, 1);
		return true;
	}

	// Token: 0x0600FA1B RID: 64027 RVA: 0x00448008 File Offset: 0x00446208
	public static bool TryUseTotalTopUpRolePickItem(int itemId, int num = 1)
	{
		TotalTopUpRolePackageData totalTopUpRolePackageData = TotalTopUpRolePackageData.TryParsePackageData(itemId);
		if (totalTopUpRolePackageData == null)
		{
			return false;
		}
		TotalTopUpPickRoleViewModel totalTopUpPickRoleViewModel = new TotalTopUpPickRoleViewModel();
		totalTopUpPickRoleViewModel.LoadFromGiftPackageInBag(totalTopUpRolePackageData);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TotalTopUpPickRoleRewardView, totalTopUpPickRoleViewModel, null);
		return true;
	}

	// Token: 0x0600FA1C RID: 64028 RVA: 0x00448040 File Offset: 0x00446240
	public static bool TryUseOrnamentItem(int itemId, int num = 1)
	{
		if (!ModelBase<RoleOrnamentModel>.Instance.IsOwnOrnament(itemId))
		{
			return false;
		}
		ControllerBase<RoleController>.Instance.SkipToRoleOrnamentViewByItemId(itemId, true);
		return true;
	}

	// Token: 0x0600FA1D RID: 64029 RVA: 0x00448060 File Offset: 0x00446260
	public static bool TryUseBrochureItem(int itemId, int num = 1)
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("SpringManorBrochureItemId");
		if (intArrayConfig == null)
		{
			return false;
		}
		if (intArrayConfig[0] != itemId)
		{
			return false;
		}
		int activityId = intArrayConfig[1];
		SpringManorBrochureViewOpenParam param = new SpringManorBrochureViewOpenParam
		{
			IsHideReward = true,
			ActivityId = activityId
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorBrochureView, param, null);
		return true;
	}

	// Token: 0x0600FA1E RID: 64030 RVA: 0x004480B7 File Offset: 0x004462B7
	public static void ParametersItemUse(int configId, int count, int parametersType, int parametersValue)
	{
		if (parametersType == 26)
		{
			ItemUseLogic.ParametersItemUseSkipTask(configId, count, parametersValue);
		}
	}

	// Token: 0x0600FA1F RID: 64031 RVA: 0x004480C6 File Offset: 0x004462C6
	private static void ParametersItemUseSkipTask(int itemId, int count, int parametersValue)
	{
		SkipTaskManager.RunByConfigId(parametersValue, null);
	}

	// Token: 0x0600FA20 RID: 64032 RVA: 0x004480D0 File Offset: 0x004462D0
	public static bool TryUseResonantChainOptionalItem(int itemId, int num = 1)
	{
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemId);
		if (itemConfig == null)
		{
			return false;
		}
		if (itemConfig.Value.Parameters().Count == 0)
		{
			return false;
		}
		int num3;
		int num2 = itemConfig.Value.Parameters().TryGetValue(2, out num3) ? num3 : 0;
		if (num2 == 0)
		{
			return false;
		}
		if (ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(num2).Value.Type != GiftType.ResonantChainOptional)
		{
			return false;
		}
		ItemRewardSelectViewOpenParam itemRewardSelectViewOpenParam = new ItemRewardSelectViewOpenParam();
		itemRewardSelectViewOpenParam.GiftPackageId = num2;
		Action<int, int> onSelectItemCallBack = delegate(int index, int selectItem)
		{
			ControllerBase<InventoryGiftController>.Instance.SendItemGiftUseRequest(itemId, 1, new int[]
			{
				selectItem
			});
		};
		itemRewardSelectViewOpenParam.OnSelectItemCallBack = onSelectItemCallBack;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemRewardSelectView, itemRewardSelectViewOpenParam, null);
		return true;
	}
}
