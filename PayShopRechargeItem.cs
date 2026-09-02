using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020023E2 RID: 9186
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PayShopRechargeItem : GridProxyAbstract<IPayShopUnionData>
{
	// Token: 0x06011C54 RID: 72788 RVA: 0x004E32A0 File Offset: 0x004E14A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickItem));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011C55 RID: 72789 RVA: 0x004E33CA File Offset: 0x004E15CA
	public void SetRaycastState(bool state)
	{
		this.RootItem.SetRaycastTarget(state);
		this.PayShopItemBase.GetRootItem().SetRaycastTarget(state);
	}

	// Token: 0x06011C56 RID: 72790 RVA: 0x004E33E9 File Offset: 0x004E15E9
	public void SetDownPriceShowState(bool state)
	{
		this.PayShopItemBase.SetDownPriceShowState(state);
	}

	// Token: 0x06011C57 RID: 72791 RVA: 0x004E33F8 File Offset: 0x004E15F8
	private void OnClickItem()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:ShopItem 点击充值";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Data.PayItemId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ControllerBase<PayItemController>.Instance.SdkPay(this.Data.PayItemId);
	}

	// Token: 0x06011C58 RID: 72792 RVA: 0x004E3450 File Offset: 0x004E1650
	protected override void OnStart()
	{
		this.PayShopItemBase = new PayShopItemBase(base.GetItem(0));
		this.PayShopItemBase.Init();
		this.CurrentGiveItemShowState = base.GetItem(1).bIsUIActive;
		this.CurrentDoubleItemShowState = base.GetItem(3).bIsUIActive;
		this.AddEventListener();
	}

	// Token: 0x06011C59 RID: 72793 RVA: 0x004E34A4 File Offset: 0x004E16A4
	private void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011C5A RID: 72794 RVA: 0x004E34DE File Offset: 0x004E16DE
	private void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DiscountShopTimerRefresh, new Action(this.OnDiscountShopTimerRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06011C5B RID: 72795 RVA: 0x004E3518 File Offset: 0x004E1718
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
	}

	// Token: 0x06011C5C RID: 72796 RVA: 0x004E3520 File Offset: 0x004E1720
	private unsafe void OnPayItemSuccess(PayItemSuccess notify)
	{
		if (notify.PayItemId != this.Data.PayItemId)
		{
			return;
		}
		this.Data.CanSpecialBonus = false;
		this.Refresh(this.Data, false, 0);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Shop;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "PayShop:ShopItem 充值成功,道具到账";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("订单号", notify.OrderId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("道具id", notify.ItemId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("道具数量", notify.ItemCount);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06011C5D RID: 72797 RVA: 0x004E35DF File Offset: 0x004E17DF
	private void OnDiscountShopTimerRefresh()
	{
		if (this.Data == null)
		{
			return;
		}
		this.RefreshBonus();
		this.RefreshSpecialBonus();
	}

	// Token: 0x06011C5E RID: 72798 RVA: 0x004E35F8 File Offset: 0x004E17F8
	public override void Refresh(IPayShopUnionData data, bool isSelected, int gridIndex)
	{
		PayItemData payItemData = data as PayItemData;
		if (payItemData == null)
		{
			return;
		}
		this.Data = payItemData;
		this.PayShopItemBase.Refresh(ModelBase<PayItemModel>.Instance.ConvertPayItemDataToPayShopItemBaseSt(this.Data), isSelected, gridIndex);
		this.RefreshBonus();
		this.RefreshSpecialBonus();
	}

	// Token: 0x06011C5F RID: 72799 RVA: 0x004E3640 File Offset: 0x004E1840
	private void RefreshBonus()
	{
		bool flag = false;
		int num = 0;
		if (this.Data.BonusItemCount > 0 && !this.Data.CanSpecialBonus)
		{
			flag = true;
			num = this.Data.BonusItemCount;
		}
		if (this.CurrentGiveItemShowState != flag)
		{
			this.CurrentGiveItemShowState = flag;
			base.GetItem(1).SetUIActive(flag);
		}
		if (this.CurrentShowGiveCount != num)
		{
			this.CurrentShowGiveCount = num;
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "DefaultBonus", new <>z__ReadOnlySingleElementList<object>(this.Data.BonusItemCount));
		}
	}

	// Token: 0x06011C60 RID: 72800 RVA: 0x004E36D4 File Offset: 0x004E18D4
	private void RefreshSpecialBonus()
	{
		bool flag = false;
		int num = 0;
		if (this.Data.CanSpecialBonus)
		{
			flag = true;
			num = this.Data.SpecialBonusItemCount;
		}
		if (this.CurrentDoubleItemShowState != flag)
		{
			this.CurrentDoubleItemShowState = flag;
			base.GetItem(3).SetUIActive(flag);
		}
		if (this.CurrentSpecialBonusCount != num)
		{
			this.CurrentSpecialBonusCount = num;
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "FirstBonus2", new <>z__ReadOnlySingleElementList<object>(this.Data.SpecialBonusItemCount));
		}
	}

	// Token: 0x04008B28 RID: 35624
	[Nullable(2)]
	private PayItemData Data;

	// Token: 0x04008B29 RID: 35625
	[Nullable(2)]
	private PayShopItemBase PayShopItemBase;

	// Token: 0x04008B2A RID: 35626
	private bool CurrentGiveItemShowState;

	// Token: 0x04008B2B RID: 35627
	private int CurrentShowGiveCount;

	// Token: 0x04008B2C RID: 35628
	private bool CurrentDoubleItemShowState;

	// Token: 0x04008B2D RID: 35629
	private int CurrentSpecialBonusCount;

	// Token: 0x0200871B RID: 34587
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402DB34 RID: 187188
		public const int BaseItem = 0;

		// Token: 0x0402DB35 RID: 187189
		public const int GiveItem = 1;

		// Token: 0x0402DB36 RID: 187190
		public const int GiveText = 2;

		// Token: 0x0402DB37 RID: 187191
		public const int DoubleItem = 3;

		// Token: 0x0402DB38 RID: 187192
		public const int DoubleText = 4;

		// Token: 0x0402DB39 RID: 187193
		public const int BuyButton = 5;
	}
}
