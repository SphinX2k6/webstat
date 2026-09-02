using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;

// Token: 0x02002010 RID: 8208
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class InventoryGiftController : UiControllerBase<InventoryGiftController>
{
	// Token: 0x0600F8A7 RID: 63655 RVA: 0x00442CF8 File Offset: 0x00440EF8
	[NullableContext(2)]
	public void SendItemGiftUseRequest(int configId, int count, int[] selectedId)
	{
		ItemGiftUseRequest itemGiftUseRequest = ItemGiftUseRequest.Create();
		itemGiftUseRequest.ItemId = configId;
		itemGiftUseRequest.Count = count;
		if (selectedId != null)
		{
			itemGiftUseRequest.SelectedId.Add(selectedId);
		}
		CommonItemData commonItemData = ModelBase<InventoryModel>.Instance.GetCommonItemData(configId, 0);
		TItemConfig config = commonItemData.GetConfig();
		int num;
		if (!config.Parameters.TryGetValue(2, out num))
		{
			int num2;
			config.Parameters.TryGetValue(4, out num2);
		}
		int count2 = commonItemData.GetCount();
		int remainCount = count2 - count;
		Singleton<Net>.Instance.Call<ItemGiftUseResponse>(ERequestMessageId.ItemGiftUseRequest, itemGiftUseRequest, delegate(ItemGiftUseResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25735, null, true, true);
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InventoryGiftView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.InventoryGiftView, null);
			}
			AcquireData acquireData = ModelBase<InventoryModel>.Instance.GetAcquireData();
			if (acquireData != null)
			{
				TItem item = new TItem(new InventoryDefine.GetItemData(configId, 0), remainCount);
				acquireData.SetRemainItemCount(remainCount);
				acquireData.SetMaxAmount(remainCount);
				acquireData.SetItemData(new List<TItem>
				{
					item
				});
				this.ShowAcquireView(acquireData);
			}
		}, 0);
	}

	// Token: 0x0600F8A8 RID: 63656 RVA: 0x00442DA8 File Offset: 0x00440FA8
	public void SendGiftPackPreviewRequest(int itemId, GiftPackage giftConfig, int? selectedId, int selectedCount = 1)
	{
		GiftPackPreviewRequest giftPackPreviewRequest = GiftPackPreviewRequest.Create();
		giftPackPreviewRequest.GiftPackId = giftConfig.Id;
		Singleton<Net>.Instance.Call<GiftPackPreviewResponse>(ERequestMessageId.GiftPackPreviewRequest, giftPackPreviewRequest, delegate(GiftPackPreviewResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			List<GiftItemData> list = new List<GiftItemData>();
			foreach (KeyValuePair<int, int> keyValuePair in giftConfig.Content())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				GiftItemData giftItemData = new GiftItemData(key, value, 0);
				Aki.Protocol.PhantomItem phantomItemData;
				if (response.PhantomPreview.TryGetValue(key, out phantomItemData))
				{
					giftItemData.SetPhantomItemData(phantomItemData);
				}
				list.Add(giftItemData);
			}
			InventoryGiftData param = new InventoryGiftData(itemId, list.ToArray(), giftConfig, selectedId, new int?(selectedCount));
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryGiftView, param, null);
		}, 0);
	}

	// Token: 0x0600F8A9 RID: 63657 RVA: 0x00442E0C File Offset: 0x0044100C
	public void ShowAcquireView(AcquireData acquireData)
	{
		ModelBase<InventoryModel>.Instance.SetAcquireData(acquireData);
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.AcquireView))
		{
			Singleton<EventSystem>.Instance.Emit<AcquireData>(EEventName.RefreshAcquireView, acquireData);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.AcquireView, acquireData, null);
	}

	// Token: 0x0600F8AA RID: 63658 RVA: 0x00442E58 File Offset: 0x00441058
	public void ShowRewardViewWithCountAndId(int rewardId, int rewardCount)
	{
		AcquireData acquireData = new AcquireData();
		acquireData.SetAcquireViewType(EAcquireViewType.ShowReward);
		List<TItem> list = new List<TItem>();
		TItem item = new TItem(new InventoryDefine.GetItemData(rewardId, 0), rewardCount);
		list.Add(item);
		acquireData.SetItemData(list);
		this.ShowAcquireView(acquireData);
	}

	// Token: 0x0600F8AB RID: 63659 RVA: 0x00442E9C File Offset: 0x0044109C
	public void ShowRewardViewWithList(List<TItem> rewardList)
	{
		AcquireData acquireData = new AcquireData();
		acquireData.SetAcquireViewType(EAcquireViewType.ShowReward);
		acquireData.SetItemData(rewardList);
		this.ShowAcquireView(acquireData);
	}

	// Token: 0x0600F8AC RID: 63660 RVA: 0x00442EC4 File Offset: 0x004410C4
	public void CloseAcquireView()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.AcquireView))
		{
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.AcquireView, null);
	}

	// Token: 0x0600F8AD RID: 63661 RVA: 0x00442EE8 File Offset: 0x004410E8
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ItemGiftUseNotify>(ENotifyMessageId.ItemGiftUseNotify, new Action<ItemGiftUseNotify, Net.CallbackStatus>(this.ItemGiftUseNotify));
	}

	// Token: 0x0600F8AE RID: 63662 RVA: 0x00442F06 File Offset: 0x00441106
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ItemGiftUseNotify);
	}

	// Token: 0x0600F8AF RID: 63663 RVA: 0x00442F18 File Offset: 0x00441118
	public void ItemGiftUseNotify(ItemGiftUseNotify itemGiftUseNotify, [Nullable(2)] Net.CallbackStatus status)
	{
		int id = itemGiftUseNotify.Id;
		GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(id);
		if (giftPackageConfig == null || giftPackageConfig.Value.ShowType == 1)
		{
			return;
		}
		if (giftPackageConfig.Value.ShowType == 0)
		{
			int count = itemGiftUseNotify.Infos.Count;
			List<TItem> list = new List<TItem>();
			for (int i = 0; i < count; i++)
			{
				AddCountItemInfo addCountItemInfo = itemGiftUseNotify.Infos[i];
				int id2 = addCountItemInfo.Id;
				int count2 = addCountItemInfo.Count;
				list.Add(new TItem(new InventoryDefine.GetItemData(id2, 0), count2));
			}
			AcquireData acquireData = new AcquireData();
			acquireData.SetAcquireViewType(EAcquireViewType.ShowReward);
			acquireData.SetItemData(list);
			this.ShowAcquireView(acquireData);
		}
	}
}
