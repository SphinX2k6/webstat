using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemDeliver;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002045 RID: 8261
[NullableContext(1)]
[Nullable(0)]
public class ItemDeliverView : UiViewBase
{
	// Token: 0x0600FBAA RID: 64426 RVA: 0x00451759 File Offset: 0x0044F959
	public ItemDeliverView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600FBAB RID: 64427 RVA: 0x00451764 File Offset: 0x0044F964
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickConfirmButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FBAC RID: 64428 RVA: 0x004518B0 File Offset: 0x0044FAB0
	private void OnClickConfirmButton()
	{
		if (this.IsDelivering)
		{
			return;
		}
		if (!this.IsEnoughSubmit())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("DeliverNoMaterial", Array.Empty<object>());
			return;
		}
		GeneralContext context = this.DeliverData.Context;
		if (context == null)
		{
			return;
		}
		this.IsDelivering = true;
		List<DeliverSlotData> slotDataList = this.DeliverData.GetSlotDataList();
		if (context.Type.GetValueOrDefault() == EGeneralContextType.GeneralLogicTree)
		{
			List<PbHandInItem> list = new List<PbHandInItem>();
			foreach (DeliverSlotData deliverSlotData in slotDataList)
			{
				if (deliverSlotData.HasItem())
				{
					PbHandInItemInfo pbHandInItemInfo = PbHandInItemInfo.Create();
					pbHandInItemInfo.IncId = 0;
					pbHandInItemInfo.ItemId = deliverSlotData.GetCurrentItemConfigId();
					pbHandInItemInfo.Num = deliverSlotData.GetCurrentCount();
					List<PbHandInItemInfo> values = new List<PbHandInItemInfo>
					{
						pbHandInItemInfo
					};
					PbHandInItem pbHandInItem = PbHandInItem.Create();
					pbHandInItem.HandItemInfo.AddRange(values);
					pbHandInItem.Count = deliverSlotData.GetNeedCount();
					pbHandInItem.PbHandInItemType = PbHandInItemType.ItemIds;
					EHandInItemType handInType = deliverSlotData.HandInType;
					if (handInType != EHandInItemType.ItemIds)
					{
						if (handInType == EHandInItemType.ItemType)
						{
							pbHandInItem.PbHandInItemType = PbHandInItemType.ItemType;
						}
					}
					else
					{
						pbHandInItem.PbHandInItemType = PbHandInItemType.ItemIds;
					}
					list.Add(pbHandInItem);
				}
			}
			ControllerBase<ItemDeliverController>.Instance.HandInItemRequest(context, list, new Action<bool>(this.OnDeliverResponse));
			return;
		}
		if (context.Type.GetValueOrDefault() == EGeneralContextType.Entity)
		{
			DeliverSlotData deliverSlotData2 = slotDataList[0];
			if (deliverSlotData2.HasItem())
			{
				ControllerBase<ItemDeliverController>.Instance.ItemUseRequest(context, deliverSlotData2.GetCurrentItemConfigId(), deliverSlotData2.GetCurrentCount(), new Action<bool>(this.OnDeliverResponse));
			}
		}
	}

	// Token: 0x0600FBAD RID: 64429 RVA: 0x00451A5C File Offset: 0x0044FC5C
	private void OnDeliverResponse(bool bSuccess)
	{
		this.IsDelivering = false;
		if (bSuccess)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0600FBAE RID: 64430 RVA: 0x00451A70 File Offset: 0x0044FC70
	private bool IsEnoughSubmit()
	{
		foreach (DeliverSlotData deliverSlotData in this.DeliverData.GetSlotDataList())
		{
			if (deliverSlotData.GetCurrentCount() < deliverSlotData.GetNeedCount())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600FBAF RID: 64431 RVA: 0x00451AD8 File Offset: 0x0044FCD8
	protected override UniTask OnBeforeStartAsync()
	{
		ItemDeliverView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemDeliverView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FBB0 RID: 64432 RVA: 0x00451B1C File Offset: 0x0044FD1C
	protected override void OnStart()
	{
		this.DeliverData = (this.OpenParam as DeliverData);
		if (this.DeliverData == null)
		{
			return;
		}
		this.PopupCaptionItem.SetCloseBtnActive(true);
		this.PopupCaptionItem.SetHelpBtnActive(false);
		this.RefreshTitleText();
		this.RefreshDescriptionText();
		this.RefreshAllDeliverSlot(delegate
		{
			DeliverSlotData deliverSlotData = this.DeliverData.GetSlotDataList()[0];
			if (deliverSlotData != null)
			{
				this.RefreshItemInteractionPanel(deliverSlotData, deliverSlotData.GetNeedCount());
				bool flag = deliverSlotData.GetItemRangeList().Count <= 1;
				this.PopupCaptionItem.SetTitleIconVisible(flag);
				this.PopupCaptionItem.SetTitleTextActive(flag);
				if (flag)
				{
					string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_IconDeliver");
					this.PopupCaptionItem.SetTitleIcon(resourcePath);
				}
			}
		});
	}

	// Token: 0x0600FBB1 RID: 64433 RVA: 0x00451B79 File Offset: 0x0044FD79
	protected override void OnBeforeDestroy()
	{
		DeliverData deliverData = this.DeliverData;
		if (deliverData != null)
		{
			deliverData.Clear();
		}
		this.DeliverData = null;
		this.DeliverScrollView = null;
		this.ItemInteractionPanel = null;
	}

	// Token: 0x0600FBB2 RID: 64434 RVA: 0x00451BA4 File Offset: 0x0044FDA4
	private void OnItemExtendToggleStateChanged(ItemInteractionPanelItemData data)
	{
		if (!data.IsEnable())
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(data.ItemConfigId, true, null);
			this.ItemInteractionPanel.SetItemGridSelected(false, data);
			return;
		}
		if (!this.SetDeliverSlotItemByItemConfigId(data.ItemConfigId, 1))
		{
			this.ItemInteractionPanel.SetItemGridSelected(false, data);
			return;
		}
		this.RefreshAllDeliverSlot(null);
		int currentCount = Math.Min(data.GetCurrentCount() + 1, data.GetItemCount());
		data.SetCurrentCount(currentCount);
		this.ItemInteractionPanel.RefreshItemGrid(data);
	}

	// Token: 0x0600FBB3 RID: 64435 RVA: 0x00451C24 File Offset: 0x0044FE24
	private bool OnCanExecuteChange(ItemInteractionPanelItemData data)
	{
		return this.DeliverData != null && this.DeliverData.HasEmptySlot();
	}

	// Token: 0x0600FBB4 RID: 64436 RVA: 0x00451C3C File Offset: 0x0044FE3C
	private void OnItemReduceButtonTrigger(ItemInteractionPanelItemData data)
	{
		int num = Math.Max(data.GetCurrentCount() - 1, 0);
		data.SetCurrentCount(num);
		this.ItemInteractionPanel.RefreshItemGrid(data);
		this.SetDeliverSlotItemByItemConfigId(data.ItemConfigId, -1);
		this.RefreshAllDeliverSlot(null);
		if (num <= 0)
		{
			this.ItemInteractionPanel.SetItemGridSelected(false, data);
		}
	}

	// Token: 0x0600FBB5 RID: 64437 RVA: 0x00451C91 File Offset: 0x0044FE91
	private void OnClickedCloseButton()
	{
		ModelBase<ItemDeliverModel>.Instance.SetItemDeliverData(null);
		base.CloseMe(null);
	}

	// Token: 0x0600FBB6 RID: 64438 RVA: 0x00451CA5 File Offset: 0x0044FEA5
	private DeliverMediumItemGrid OnCreateDeliverMediumItemGrid()
	{
		DeliverMediumItemGrid deliverMediumItemGrid = new DeliverMediumItemGrid();
		deliverMediumItemGrid.BindReduceButtonCallback(new Action<MediumItemGridButtonCallback>(this.OnDeliverSlotReduceTrigger), null);
		return deliverMediumItemGrid;
	}

	// Token: 0x0600FBB7 RID: 64439 RVA: 0x00451CC0 File Offset: 0x0044FEC0
	private void OnDeliverSlotReduceTrigger(MediumItemGridButtonCallback callbackParameter)
	{
		DeliverSlotData deliverSlotData = callbackParameter.Data as DeliverSlotData;
		int num = deliverSlotData.GetCurrentCount() - 1;
		deliverSlotData.SetCurrentCount(Math.Max(num, 0));
		ItemInteractionPanelItemData itemData = this.ItemInteractionPanel.GetItemData(deliverSlotData.GetCurrentItemConfigId());
		if (itemData != null)
		{
			itemData.SetCurrentCount(itemData.GetCurrentCount() - 1);
			this.ItemInteractionPanel.RefreshItemGrid(itemData);
			if (num <= 0)
			{
				this.ItemInteractionPanel.SetItemGridSelected(false, itemData);
			}
		}
		if (num <= 0)
		{
			deliverSlotData.ClearItem();
		}
		this.RefreshAllDeliverSlot(null);
	}

	// Token: 0x0600FBB8 RID: 64440 RVA: 0x00451D40 File Offset: 0x0044FF40
	private void RefreshTitleText()
	{
		string titleTextId = this.DeliverData.TitleTextId;
		if (!string.IsNullOrEmpty(titleTextId))
		{
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(titleTextId);
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			text.SetText(configTextByKey, true);
		}
	}

	// Token: 0x0600FBB9 RID: 64441 RVA: 0x00451D80 File Offset: 0x0044FF80
	private void RefreshDescriptionText()
	{
		string descriptionTextId = this.DeliverData.DescriptionTextId;
		string newText = string.IsNullOrEmpty(descriptionTextId) ? "" : Singleton<PublicUtil>.Instance.GetConfigTextByKey(descriptionTextId);
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetText(newText, true);
	}

	// Token: 0x0600FBBA RID: 64442 RVA: 0x00451DC8 File Offset: 0x0044FFC8
	private bool SetDeliverSlotItemByItemConfigId(int itemConfigId, int changeCount)
	{
		List<DeliverSlotData> slotDataList = this.DeliverData.GetSlotDataList();
		if (changeCount > 0)
		{
			DeliverData deliverData = this.DeliverData;
			if (deliverData != null && deliverData.IsSlotEnough(itemConfigId))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("RepeatedDeliveryItem", Array.Empty<object>());
				return false;
			}
			using (List<DeliverSlotData>.Enumerator enumerator = slotDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DeliverSlotData deliverSlotData = enumerator.Current;
					int currentValue = deliverSlotData.GetCurrentCount() + changeCount;
					int num = Singleton<MathUtils>.Instance.Clamp(currentValue, 0, deliverSlotData.GetNeedCount());
					if (!deliverSlotData.IsEnough())
					{
						if (num <= 0)
						{
							deliverSlotData.ClearItem();
							return true;
						}
						if (deliverSlotData.SetItem(itemConfigId, num))
						{
							return true;
						}
					}
				}
				return false;
			}
		}
		for (int i = slotDataList.Count - 1; i >= 0; i--)
		{
			DeliverSlotData deliverSlotData2 = slotDataList[i];
			if (deliverSlotData2.GetCurrentItemConfigId() == itemConfigId)
			{
				int currentValue2 = deliverSlotData2.GetCurrentCount() + changeCount;
				int num2 = Singleton<MathUtils>.Instance.Clamp(currentValue2, 0, deliverSlotData2.GetNeedCount());
				if (deliverSlotData2.HasItem())
				{
					if (num2 <= 0)
					{
						deliverSlotData2.ClearItem();
						return true;
					}
					if (deliverSlotData2.SetItem(itemConfigId, num2))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0600FBBB RID: 64443 RVA: 0x00451F10 File Offset: 0x00450110
	[NullableContext(2)]
	private void RefreshAllDeliverSlot(Action callBack = null)
	{
		List<DeliverSlotData> slotDataList = this.DeliverData.GetSlotDataList();
		GenericLayout<DeliverMediumItemGrid, DeliverSlotData> deliverScrollView = this.DeliverScrollView;
		if (deliverScrollView == null)
		{
			return;
		}
		deliverScrollView.RefreshByData(slotDataList, callBack, false);
	}

	// Token: 0x0600FBBC RID: 64444 RVA: 0x00451F3C File Offset: 0x0045013C
	private void RefreshItemInteractionPanel(DeliverSlotData deliverSlotData, int needCount)
	{
		List<ItemInteractionPanelItemInfo> list = new List<ItemInteractionPanelItemInfo>();
		IReadOnlyList<int> itemRangeList = deliverSlotData.GetItemRangeList();
		if (itemRangeList.Count <= 1)
		{
			this.ItemInteractionPanel.SetActive(false);
			return;
		}
		foreach (int itemConfigId in itemRangeList)
		{
			ItemInteractionPanelItemInfo item = new ItemInteractionPanelItemInfo
			{
				ItemConfigId = itemConfigId,
				CurrentCount = 0,
				NeedCount = new int?(needCount)
			};
			list.Add(item);
		}
		ItemInteractionPanelData itemInteractionPanelInfo = new ItemInteractionPanelData
		{
			ItemInfoList = new List<IItemInteractionPanelItemInfo>(list)
		};
		this.ItemInteractionPanel.Refresh(itemInteractionPanelInfo).ContinueWith(delegate()
		{
			IEnumerable<KeyValuePair<int, List<ItemInteractionPanelItemData>>> itemDataMainTypeMap = this.ItemInteractionPanel.GetItemDataMainTypeMap();
			int needCount2 = this.DeliverData.GetSlotDataList()[0].GetNeedCount();
			int num = this.ItemInteractionPanel.GetMainTypeIdList()[0];
			foreach (KeyValuePair<int, List<ItemInteractionPanelItemData>> keyValuePair in itemDataMainTypeMap)
			{
				int num2;
				List<ItemInteractionPanelItemData> list2;
				keyValuePair.Deconstruct(out num2, out list2);
				int num3 = num2;
				using (List<ItemInteractionPanelItemData>.Enumerator enumerator3 = list2.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						if (enumerator3.Current.GetItemCount() >= needCount2 && num3 != num)
						{
							ItemInteractionPanel itemInteractionPanel = this.ItemInteractionPanel;
							if (itemInteractionPanel == null)
							{
								break;
							}
							itemInteractionPanel.SetMainTypeRedDotVisible(num3, true);
							break;
						}
					}
				}
			}
		});
		this.ItemInteractionPanel.SetActive(true);
	}

	// Token: 0x040078D1 RID: 30929
	[Nullable(2)]
	private DeliverData DeliverData;

	// Token: 0x040078D2 RID: 30930
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DeliverMediumItemGrid, DeliverSlotData> DeliverScrollView;

	// Token: 0x040078D3 RID: 30931
	[Nullable(2)]
	private ItemInteractionPanel ItemInteractionPanel;

	// Token: 0x040078D4 RID: 30932
	[Nullable(2)]
	private PopupCaptionItem PopupCaptionItem;

	// Token: 0x040078D5 RID: 30933
	private bool IsDelivering;

	// Token: 0x020083ED RID: 33773
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402CB8B RID: 183179
		public const int TitleItem = 0;

		// Token: 0x0402CB8C RID: 183180
		public const int ItemPanelItem = 1;

		// Token: 0x0402CB8D RID: 183181
		public const int ConfirmButton = 2;

		// Token: 0x0402CB8E RID: 183182
		public const int DescriptionText = 3;

		// Token: 0x0402CB8F RID: 183183
		public const int DeliverScrollView = 4;

		// Token: 0x0402CB90 RID: 183184
		public const int ContentHorizontalLayout = 5;

		// Token: 0x0402CB91 RID: 183185
		public const int TitleText = 6;
	}
}
