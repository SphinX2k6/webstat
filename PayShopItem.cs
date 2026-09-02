using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020023DD RID: 9181
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PayShopItem : GridProxyAbstract<IPayShopUnionData>
{
	// Token: 0x06011C0B RID: 72715 RVA: 0x004E11C8 File Offset: 0x004DF3C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 20;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011C0C RID: 72716 RVA: 0x004E14CC File Offset: 0x004DF6CC
	public void HideExchangePopViewElement()
	{
		this.SetRaycastState(false);
		this.SetDownPriceShowState(false);
		this.SetForceHideReUpTextState(true);
		this.SetResellShowState(true);
		this.SetDisableSelfInteractiveState(true);
		this.SetLeftTimeTextShowState(false);
		this.SetRedDotState(false);
	}

	// Token: 0x06011C0D RID: 72717 RVA: 0x004E14FF File Offset: 0x004DF6FF
	public void HidePackageViewElement()
	{
		this.SetRaycastState(false);
		this.SetForceHideReUpTextState(true);
		this.SetResellShowState(true);
		this.SetDisableSelfInteractiveState(true);
		this.SetLeftTimeTextShowState(false);
		this.PayShopItemBase.SetDownPriceOnlyShow(true);
		this.SetRedDotState(false);
	}

	// Token: 0x06011C0E RID: 72718 RVA: 0x004E1537 File Offset: 0x004DF737
	public void SetRaycastState(bool state)
	{
		this.RootItem.SetRaycastTarget(state);
		this.PayShopItemBase.GetRootItem().SetRaycastTarget(state);
		base.GetButton(8).SetCanClickWhenDisable(state);
	}

	// Token: 0x06011C0F RID: 72719 RVA: 0x004E1563 File Offset: 0x004DF763
	public void SetResellShowState(bool state)
	{
		this.ForceHideResellText = state;
	}

	// Token: 0x06011C10 RID: 72720 RVA: 0x004E156C File Offset: 0x004DF76C
	public void SetDisableSelfInteractiveState(bool state)
	{
		this.ForceDisableSelfInteractive = state;
	}

	// Token: 0x06011C11 RID: 72721 RVA: 0x004E1575 File Offset: 0x004DF775
	public void SetForceHideReUpTextState(bool state)
	{
		this.ForceHideReUpState = state;
	}

	// Token: 0x06011C12 RID: 72722 RVA: 0x004E157E File Offset: 0x004DF77E
	public void SetDownPriceShowState(bool state)
	{
		this.PayShopItemBase.SetDownPriceShowState(state);
	}

	// Token: 0x06011C13 RID: 72723 RVA: 0x004E158C File Offset: 0x004DF78C
	private void OnClickItem()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:ShopItem 点击商品";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Data.GetGoodsData().Id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<PayShopController>.Instance.OpenBuyViewByGoodsId(this.Data, this.ExchangeExtraData);
		Action<PayShopItem, PayShopGoods> buttonExtraFunction = this.ButtonExtraFunction;
		if (buttonExtraFunction == null)
		{
			return;
		}
		buttonExtraFunction(this, this.Data);
	}

	// Token: 0x06011C14 RID: 72724 RVA: 0x004E1604 File Offset: 0x004DF804
	protected override void OnStart()
	{
		base.GetItem(12).SetUIActive(false);
		this.PayShopItemBase = new PayShopItemBase(base.GetItem(0));
		this.PayShopItemBase.Init();
		this.CurrentBuyLimitItemState = base.GetItem(5).bIsUIActive;
		this.CurrentDiscountItemState = base.GetItem(1).bIsUIActive;
		this.DiscountLabelShowState = base.GetItem(4).bIsUIActive;
		this.CurrentResellTextState = base.GetText(7).bIsUIActive;
		this.CurrentBuyButtonSelfInteractiveState = false;
		this.CurrentWarnState = false;
		this.LeftTopState = base.GetItem(12).bIsActive;
		base.GetButton(8).SetCanClickWhenDisable(true);
		this.SetNewFlagState(false);
		this.AddEventListener();
	}

	// Token: 0x06011C15 RID: 72725 RVA: 0x004E16BF File Offset: 0x004DF8BF
	private void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
	}

	// Token: 0x06011C16 RID: 72726 RVA: 0x004E16DD File Offset: 0x004DF8DD
	private void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
	}

	// Token: 0x06011C17 RID: 72727 RVA: 0x004E16FC File Offset: 0x004DF8FC
	private void OnDiscountShopTimerRefresh()
	{
		if (this.Data == null || !base.IsUiActiveInHierarchy())
		{
			return;
		}
		bool flag = false;
		if (this.RefreshDiscount())
		{
			flag = true;
		}
		if (this.RefreshCountDown())
		{
			flag = true;
		}
		this.RefreshDiscountLabel();
		this.RefreshReSellText();
		this.RefreshDiscountLabelShowState();
		this.RefreshButtonState();
		this.RefreshLeftTopItem();
		this.RefreshRecommendTagItem();
		this.RefreshCumulativeShopContent();
		this.RefreshRoleRoundIconItem();
		this.RefreshWarnState();
		this.PayShopItemBase.OnTimerRefresh(this.Data.ConvertToPayShopBaseSt(), false, 0);
		if (flag)
		{
			this.TryEmitRefreshTips();
		}
	}

	// Token: 0x06011C18 RID: 72728 RVA: 0x004E1788 File Offset: 0x004DF988
	[NullableContext(1)]
	public override void Refresh(IPayShopUnionData data, bool isSelected, int gridIndex)
	{
		PayShopGoods payShopGoods = data as PayShopGoods;
		if (payShopGoods == null)
		{
			return;
		}
		this.Data = payShopGoods;
		this.PayShopItemBase.Refresh(this.Data.ConvertToPayShopBaseSt(), isSelected, gridIndex);
		this.ResetView();
		this.RefreshDiscount();
		this.RefreshCountDown();
		this.RefreshDiscountLabel();
		this.RefreshReSellText();
		this.RefreshDiscountLabelShowState();
		this.RefreshButtonState();
		this.RefreshReUpTimeText();
		this.RefreshLeftTopItem();
		this.RefreshRecommendTagItem();
		this.RefreshCumulativeShopContent();
		this.RefreshWarnState();
	}

	// Token: 0x06011C19 RID: 72729 RVA: 0x004E1809 File Offset: 0x004DFA09
	public void SetNeedShowOnceBuyLimit(bool state)
	{
		this.PayShopItemBase.SetLeftTimeTextShowOnceBuy(state);
	}

	// Token: 0x06011C1A RID: 72730 RVA: 0x004E1817 File Offset: 0x004DFA17
	private void ResetView()
	{
		base.GetItem(15).SetUIActive(false);
		this.CurrentWarnState = false;
	}

	// Token: 0x06011C1B RID: 72731 RVA: 0x004E1830 File Offset: 0x004DFA30
	private void RefreshWarnState()
	{
		bool flag = !this.Data.IfCanBuy();
		if (flag && this.ForceDisableSelfInteractive)
		{
			flag = false;
		}
		if (this.CurrentWarnState != flag)
		{
			UUIItem item = base.GetItem(15);
			UUIText text = base.GetText(16);
			this.CurrentWarnState = flag;
			item.SetUIActive(flag);
			if (flag)
			{
				text.SetText(this.Data.GetConditionLimitText(), true);
			}
		}
	}

	// Token: 0x06011C1C RID: 72732 RVA: 0x004E1898 File Offset: 0x004DFA98
	private void RefreshButtonState()
	{
		bool flag = this.Data.IsSoldOut();
		bool flag2 = this.Data.IsLimitGoods() && flag;
		if (flag2 && this.ForceDisableSelfInteractive)
		{
			flag2 = false;
		}
		if (this.CurrentBuyButtonSelfInteractiveState != flag2)
		{
			this.CurrentBuyButtonSelfInteractiveState = flag2;
			UUIItem item = base.GetItem(13);
			if (item != null)
			{
				item.SetUIActive(flag2);
			}
			if (flag)
			{
				UUIText text = base.GetText(14);
				if (text == null)
				{
					return;
				}
				text.SetText(this.Data.GetDownTipsText(), true);
			}
		}
	}

	// Token: 0x06011C1D RID: 72733 RVA: 0x004E1914 File Offset: 0x004DFB14
	private void RefreshDiscountLabelShowState()
	{
		bool flag = this.Data.GetDiscountLabel() > 0 && (this.Data.InLabelShowTime() || (!this.Data.InLabelShowTime() && false));
		if (this.DiscountLabelShowState != flag)
		{
			base.GetItem(4).SetUIActive(flag);
			this.DiscountLabelShowState = flag;
		}
	}

	// Token: 0x06011C1E RID: 72734 RVA: 0x004E1978 File Offset: 0x004DFB78
	private void RefreshLeftTopItem()
	{
		bool ifShowRecommendTag = this.Data.GetIfShowRecommendTag();
		bool flag = this.DiscountLabelShowState || this.CurrentDiscountItemState || ifShowRecommendTag;
		if (this.LeftTopState != flag)
		{
			this.LeftTopState = flag;
			base.GetItem(12).SetUIActive(flag);
		}
	}

	// Token: 0x06011C1F RID: 72735 RVA: 0x004E19C4 File Offset: 0x004DFBC4
	private void RefreshRecommendTagItem()
	{
		this.CurrentRecommendTagItemState = this.Data.GetIfShowRecommendTag();
		if (this.CurrentRecommendTagItemState && this.RecommendTagItem == null)
		{
			this.RecommendTagItem = new UiPanelBase();
			this.RecommendTagItem.CreateThenShowByResourceIdAsync("UiItem_ItemBaseC1Recommend", base.GetItem(18), false).ContinueWith(delegate()
			{
				UiPanelBase recommendTagItem2 = this.RecommendTagItem;
				if (recommendTagItem2 == null)
				{
					return;
				}
				UUIItem rootItem2 = recommendTagItem2.GetRootItem();
				if (rootItem2 == null)
				{
					return;
				}
				rootItem2.SetUIActive(this.CurrentRecommendTagItemState);
			});
		}
		UiPanelBase recommendTagItem = this.RecommendTagItem;
		if (recommendTagItem == null)
		{
			return;
		}
		UUIItem rootItem = recommendTagItem.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(this.CurrentRecommendTagItemState);
	}

	// Token: 0x06011C20 RID: 72736 RVA: 0x004E1A48 File Offset: 0x004DFC48
	private void RefreshCumulativeShopContent()
	{
		if (!PayShopDefine.PayShopCumulativeTabTypeSet.Contains(this.Data.PayShopId))
		{
			return;
		}
		int itemConfigId = this.Data.GetItemData().ItemId;
		AActor owner = base.GetItem(19).GetOwner();
		if (owner == null)
		{
			return;
		}
		if (this.CumulativePayShopContentPanel == null)
		{
			CumulativePayShopContentPanel panel = new CumulativePayShopContentPanel();
			this.CumulativePayShopContentPanel = panel;
			panel.CreateByActorAsync(owner, null, false).ContinueWith(delegate()
			{
				panel.SetUiActive(true);
				panel.RefreshCheckButtonVisibility(itemConfigId);
			});
			return;
		}
		this.CumulativePayShopContentPanel.RefreshCheckButtonVisibility(itemConfigId);
	}

	// Token: 0x06011C21 RID: 72737 RVA: 0x004E1AEC File Offset: 0x004DFCEC
	private void RefreshRoleRoundIconItem()
	{
		int itemId = this.Data.GetItemData().ItemId;
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId));
		bool flag = PayShopDefine.PayShopNeedOrnamentRoleIconShopSet.Contains(this.Data.PayShopId);
		this.CurrentRoleRoundIconState = (flag && itemDataTypeByConfigId == InventoryDefine.EItemDataType.OrnamentItem);
		if (!this.CurrentRoleRoundIconState)
		{
			this.CurrentRoleRoundIconPath = "";
			PayShopRoleRoundIconItem roleRoundIconItem = this.RoleRoundIconItem;
			if (roleRoundIconItem == null)
			{
				return;
			}
			roleRoundIconItem.SetUiActive(false);
			return;
		}
		else
		{
			RoleOrnamentData roleOrnamentData = ModelBase<RoleOrnamentModel>.Instance.GetRoleOrnamentData(itemId);
			int[] array = (roleOrnamentData != null) ? roleOrnamentData.GetRoleSkinIds() : null;
			int num = (array != null && array.Length != 0) ? array[0] : 0;
			if (num == 0)
			{
				this.CurrentRoleRoundIconPath = "";
				PayShopRoleRoundIconItem roleRoundIconItem2 = this.RoleRoundIconItem;
				if (roleRoundIconItem2 == null)
				{
					return;
				}
				roleRoundIconItem2.SetUiActive(false);
				return;
			}
			else
			{
				RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(num);
				int num2 = (roleSkinConfig != null) ? roleSkinConfig.GetValueOrDefault().RoleId : 0;
				RoleInfo? roleInfo = (num2 > 0) ? ConfigBase<RoleConfig>.Instance.GetRoleConfig(num2) : null;
				string text = ((roleInfo != null) ? roleInfo.GetValueOrDefault().RoleHeadIconCircle : null) ?? "";
				if (string.IsNullOrEmpty(text))
				{
					this.CurrentRoleRoundIconPath = "";
					PayShopRoleRoundIconItem roleRoundIconItem3 = this.RoleRoundIconItem;
					if (roleRoundIconItem3 == null)
					{
						return;
					}
					roleRoundIconItem3.SetUiActive(false);
					return;
				}
				else
				{
					if (this.CurrentRoleRoundIconState && this.RoleRoundIconItem == null)
					{
						this.RoleRoundIconItem = new PayShopRoleRoundIconItem();
						this.RoleRoundIconItem.CreateThenShowByResourceIdAsync("UiItem_ItemBaseC1Head", base.GetItem(19), false).ContinueWith(new Action(this.RefreshRoleRoundIconItem));
						return;
					}
					PayShopRoleRoundIconItem roleRoundIconItem4 = this.RoleRoundIconItem;
					if (roleRoundIconItem4 != null)
					{
						roleRoundIconItem4.SetUiActive(this.CurrentRoleRoundIconState);
					}
					if (this.CurrentRoleRoundIconPath != text)
					{
						this.CurrentRoleRoundIconPath = text;
						PayShopRoleRoundIconItem roleRoundIconItem5 = this.RoleRoundIconItem;
						if (roleRoundIconItem5 == null)
						{
							return;
						}
						roleRoundIconItem5.SetIconByPath(text);
					}
					return;
				}
			}
		}
	}

	// Token: 0x06011C22 RID: 72738 RVA: 0x004E1CD0 File Offset: 0x004DFED0
	private void RefreshDiscountLabel()
	{
		int discountLabel = this.Data.GetDiscountLabel();
		if (discountLabel > 0 && this.Data.InLabelShowTime() && this.CurrentLabelId != discountLabel)
		{
			this.CurrentLabelId = discountLabel;
			string tempText = ConfigBase<PayShopConfig>.Instance.GetShopDiscountLabel(discountLabel);
			if (PayShopDefine.payGiftRoutedShopSet.Contains(this.Data.PayShopId))
			{
				base.GetItem(4).SetUIActive(false);
				PayShopTagItem tagItem = new PayShopTagItem();
				string valueOrDefault = PayShopDefine.payShopTagTypeToResourceId.GetValueOrDefault((PayShopDefine.EPayShopTagType)discountLabel);
				tagItem.CreateThenShowByResourceIdAsync(valueOrDefault, base.GetItem(18), false).ContinueWith(delegate()
				{
					tagItem.SetTextByTextId(tempText, 0);
				});
				return;
			}
			base.GetText(11).ShowTextNew(tempText);
		}
	}

	// Token: 0x06011C23 RID: 72739 RVA: 0x004E1DA0 File Offset: 0x004DFFA0
	private bool RefreshCountDown()
	{
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.Data.GetCountDownData();
		bool result = false;
		if (countDownData.Item3 == 0.0)
		{
			if (this.CurrentBuyLimitItemState)
			{
				base.GetItem(5).SetUIActive(false);
				this.CurrentBuyLimitItemState = false;
				result = true;
			}
			return result;
		}
		CommonDefine.IPayShowCountDownRemainTime payShowCountDownRemainTime = countDownData.Item2;
		EPayCountTimeType item = countDownData.Item1;
		if (this.ForceHideResellText)
		{
			payShowCountDownRemainTime = null;
		}
		if (payShowCountDownRemainTime != null && item != EPayCountTimeType.Resell)
		{
			if (!this.CurrentBuyLimitItemState)
			{
				base.GetItem(5).SetUIActive(true);
				this.CurrentBuyLimitItemState = true;
				result = true;
			}
			UUIText text = base.GetText(6);
			CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime2 = payShowCountDownRemainTime as CommonDefine.PayShowCountDownRemainTime<string>;
			if (payShowCountDownRemainTime2 != null)
			{
				text.SetText(payShowCountDownRemainTime2.Value, true);
				return result;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(text, ((CommonDefine.IRemainTime)payShowCountDownRemainTime).TextId, new <>z__ReadOnlySingleElementList<object>(((CommonDefine.IRemainTime)payShowCountDownRemainTime).TimeValue));
		}
		else if (this.CurrentBuyLimitItemState)
		{
			base.GetItem(5).SetUIActive(false);
			this.CurrentBuyLimitItemState = false;
			result = true;
		}
		return result;
	}

	// Token: 0x06011C24 RID: 72740 RVA: 0x004E1E9C File Offset: 0x004E009C
	private void RefreshReSellText()
	{
		string resellText = this.Data.GetResellText();
		bool flag = !StringUtils.IsEmpty(resellText);
		if (this.ForceHideResellText)
		{
			flag = false;
		}
		if (this.CurrentReSellText != resellText)
		{
			this.CurrentReSellText = resellText;
			if (flag)
			{
				string textById = ConfigBase<TextConfig>.Instance.GetTextById(resellText);
				base.GetText(7).SetText(textById, true);
			}
		}
		if (this.CurrentResellTextState != flag)
		{
			this.CurrentResellTextState = flag;
			base.GetText(7).SetUIActive(flag);
		}
	}

	// Token: 0x06011C25 RID: 72741 RVA: 0x004E1F18 File Offset: 0x004E0118
	private bool RefreshDiscount()
	{
		UUIItem item = base.GetItem(1);
		bool flag = this.Data.HasDiscount();
		if (flag && PayShopDefine.payGiftRoutedShopSet.Contains(this.Data.PayShopId))
		{
			if (item != null)
			{
				item.SetUIActive(false);
			}
			bool flag2 = this.Data.GetDiscountLabel() != 0;
			if (!this.PackageDiscountState && !flag2)
			{
				PayShopTagItem discountNewItem = new PayShopTagItem();
				discountNewItem.CreateThenShowByResourceIdAsync("ShopItemDiscountLabel", base.GetItem(12), false).ContinueWith(delegate()
				{
					int discountNew = this.Data.GetDiscountNew();
					discountNewItem.SetText(StringUtils.Format("+{0}%", new string[]
					{
						discountNew.ToString()
					}));
				});
				this.PackageDiscountState = true;
			}
			return false;
		}
		bool result = false;
		if (this.CurrentDiscountItemState != flag)
		{
			item.SetUIActive(flag);
			this.CurrentDiscountItemState = flag;
			result = true;
		}
		if (this.CurrentDiscountItemState)
		{
			int discount = this.Data.GetDiscount();
			if (discount != this.CurrentDiscountValue)
			{
				this.CurrentDiscountValue = discount;
				base.GetText(2).SetText(StringUtils.Format("-{0}%", new string[]
				{
					discount.ToString()
				}), true);
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06011C26 RID: 72742 RVA: 0x004E2034 File Offset: 0x004E0234
	private void RefreshReUpTimeText()
	{
		if (this.ForceHideReUpState)
		{
			base.GetItem(5).SetUIActive(false);
			return;
		}
		if (this.CurrentBuyLimitItemState)
		{
			return;
		}
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = this.Data.GetCountDownData();
		if (countDownData.Item1 != EPayCountTimeType.Resell)
		{
			base.GetItem(5).SetUIActive(false);
			this.PayShopItemBase.SetLeftTimeTextShowState(true);
			return;
		}
		CommonDefine.IPayShowCountDownRemainTime item = countDownData.Item2;
		base.GetItem(5).SetUIActive(true);
		this.PayShopItemBase.SetLeftTimeTextShowState(false);
		UUIText text = base.GetText(6);
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = item as CommonDefine.PayShowCountDownRemainTime<string>;
		if (payShowCountDownRemainTime != null)
		{
			text.SetText(payShowCountDownRemainTime.Value, true);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(text, ((CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime>)item).Value.TextId, new <>z__ReadOnlySingleElementList<object>(((CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime>)item).Value.TimeValue));
	}

	// Token: 0x06011C27 RID: 72743 RVA: 0x004E2104 File Offset: 0x004E0304
	public void SetLeftTimeTextShowState(bool state)
	{
		this.PayShopItemBase.SetLeftTimeTextShowState(state);
	}

	// Token: 0x06011C28 RID: 72744 RVA: 0x004E2112 File Offset: 0x004E0312
	public void SetNameTextShowState(bool state)
	{
		this.PayShopItemBase.SetNameTextShowState(state);
	}

	// Token: 0x06011C29 RID: 72745 RVA: 0x004E2120 File Offset: 0x004E0320
	public void SetRedDotState(bool state)
	{
		this.PayShopItemBase.RefreshRedDotState = state;
		this.PayShopItemBase.SetRedDotVisible(state);
	}

	// Token: 0x06011C2A RID: 72746 RVA: 0x004E213A File Offset: 0x004E033A
	public void SetNewFlagState(bool state)
	{
		base.GetItem(17).SetUIActive(state);
	}

	// Token: 0x06011C2B RID: 72747 RVA: 0x004E214A File Offset: 0x004E034A
	[NullableContext(1)]
	public void SetExchangeExtraData(PayShopExchangeExtraData extraData)
	{
		this.ExchangeExtraData = extraData;
	}

	// Token: 0x06011C2C RID: 72748 RVA: 0x004E2153 File Offset: 0x004E0353
	[NullableContext(1)]
	public void SetExtraFunction(Action<PayShopItem, PayShopGoods> buttonExtraFunction)
	{
		this.ButtonExtraFunction = buttonExtraFunction;
	}

	// Token: 0x06011C2D RID: 72749 RVA: 0x004E215C File Offset: 0x004E035C
	protected void TryEmitRefreshTips()
	{
		ControllerBase<PayShopController>.Instance.ClosePayShopGoodDetailPopView();
		if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.RefreshPayShop, (int)this.Data.PayShopId, true);
	}

	// Token: 0x06011C2E RID: 72750 RVA: 0x004E2191 File Offset: 0x004E0391
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x04008AEE RID: 35566
	private bool CurrentBuyLimitItemState;

	// Token: 0x04008AEF RID: 35567
	private bool CurrentDiscountItemState;

	// Token: 0x04008AF0 RID: 35568
	private PayShopGoods Data;

	// Token: 0x04008AF1 RID: 35569
	private PayShopItemBase PayShopItemBase;

	// Token: 0x04008AF2 RID: 35570
	private bool DiscountLabelShowState;

	// Token: 0x04008AF3 RID: 35571
	private int CurrentLabelId;

	// Token: 0x04008AF4 RID: 35572
	private bool CurrentResellTextState;

	// Token: 0x04008AF5 RID: 35573
	[Nullable(1)]
	private string CurrentReSellText = "";

	// Token: 0x04008AF6 RID: 35574
	private int CurrentDiscountValue;

	// Token: 0x04008AF7 RID: 35575
	private bool CurrentBuyButtonSelfInteractiveState;

	// Token: 0x04008AF8 RID: 35576
	private bool CurrentWarnState;

	// Token: 0x04008AF9 RID: 35577
	private bool CurrentRecommendTagItemState;

	// Token: 0x04008AFA RID: 35578
	private PayShopRoleRoundIconItem RoleRoundIconItem;

	// Token: 0x04008AFB RID: 35579
	private bool CurrentRoleRoundIconState;

	// Token: 0x04008AFC RID: 35580
	[Nullable(1)]
	private string CurrentRoleRoundIconPath = "";

	// Token: 0x04008AFD RID: 35581
	private bool ForceHideResellText;

	// Token: 0x04008AFE RID: 35582
	private bool ForceDisableSelfInteractive;

	// Token: 0x04008AFF RID: 35583
	private bool ForceHideReUpState;

	// Token: 0x04008B00 RID: 35584
	private bool LeftTopState = true;

	// Token: 0x04008B01 RID: 35585
	private bool PackageDiscountState;

	// Token: 0x04008B02 RID: 35586
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<PayShopItem, PayShopGoods> ButtonExtraFunction;

	// Token: 0x04008B03 RID: 35587
	private PayShopExchangeExtraData ExchangeExtraData;

	// Token: 0x04008B04 RID: 35588
	private UiPanelBase RecommendTagItem;

	// Token: 0x04008B05 RID: 35589
	private CumulativePayShopContentPanel CumulativePayShopContentPanel;

	// Token: 0x02008713 RID: 34579
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402DB00 RID: 187136
		BaseItem,
		// Token: 0x0402DB01 RID: 187137
		DiscountItem,
		// Token: 0x0402DB02 RID: 187138
		DiscountText,
		// Token: 0x0402DB03 RID: 187139
		DiscountLabelSprite,
		// Token: 0x0402DB04 RID: 187140
		DiscountLabelItem,
		// Token: 0x0402DB05 RID: 187141
		BuyLimitTimeItem,
		// Token: 0x0402DB06 RID: 187142
		BuyLimitTimeText,
		// Token: 0x0402DB07 RID: 187143
		ReSellText,
		// Token: 0x0402DB08 RID: 187144
		BuyButton,
		// Token: 0x0402DB09 RID: 187145
		ReUpTimeItem,
		// Token: 0x0402DB0A RID: 187146
		ReUpTimeText,
		// Token: 0x0402DB0B RID: 187147
		LabelText,
		// Token: 0x0402DB0C RID: 187148
		LeftTopItem,
		// Token: 0x0402DB0D RID: 187149
		SoldOutItem,
		// Token: 0x0402DB0E RID: 187150
		SoldOutText,
		// Token: 0x0402DB0F RID: 187151
		WarnItem,
		// Token: 0x0402DB10 RID: 187152
		WarnText,
		// Token: 0x0402DB11 RID: 187153
		NewFlagItem,
		// Token: 0x0402DB12 RID: 187154
		ItemTagPanel,
		// Token: 0x0402DB13 RID: 187155
		ItemTagPanelTopRight
	}
}
