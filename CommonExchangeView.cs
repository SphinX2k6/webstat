using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200204F RID: 8271
[NullableContext(1)]
[Nullable(0)]
public class CommonExchangeView : UiTickViewBase
{
	// Token: 0x0600FBEA RID: 64490 RVA: 0x00452CD1 File Offset: 0x00450ED1
	private CommonExchangeData GetExChangeData()
	{
		return ((CommonExchangeViewData)this.OpenParam).ExchangeData;
	}

	// Token: 0x0600FBEB RID: 64491 RVA: 0x00452CE3 File Offset: 0x00450EE3
	private int GetExChangeItemId()
	{
		return this.GetExChangeData().GetDestItemId();
	}

	// Token: 0x0600FBEC RID: 64492 RVA: 0x00452CF0 File Offset: 0x00450EF0
	public CommonExchangeView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FBED RID: 64493 RVA: 0x00452CFC File Offset: 0x00450EFC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIInteractionGroup));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIInteractionGroup));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.CancelBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.ConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FBEE RID: 64494 RVA: 0x00452F79 File Offset: 0x00451179
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ExChangeCount"), new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x0600FBEF RID: 64495 RVA: 0x00452F9A File Offset: 0x0045119A
	private void ValueChangeFunction(int selectValue)
	{
		this.Refresh(selectValue);
	}

	// Token: 0x0600FBF0 RID: 64496 RVA: 0x00452FA4 File Offset: 0x004511A4
	protected override UniTask OnBeforeStartAsync()
	{
		CommonExchangeView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonExchangeView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FBF1 RID: 64497 RVA: 0x00452FE8 File Offset: 0x004511E8
	protected override void OnStart()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView != null)
		{
			childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.CancelBtn));
		}
		CommonExchangeData exChangeData = this.GetExChangeData();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "ExChangeTitle", new <>z__ReadOnlySingleElementList<object>(exChangeData.GetDestName()));
		base.SetItemIcon(base.GetTexture(1), exChangeData.GetSrcItemId(), null, null);
		base.SetItemIcon(base.GetTexture(2), exChangeData.GetDestItemId(), null, null);
		base.SetItemIcon(base.GetTexture(5), exChangeData.GetSrcItemId(), null, null);
		this.InitNumberSelect();
		if (this.CurrentExchangeViewData.StartSliderValue > 0)
		{
			NumberSelectComponent numberSelect = this.NumberSelect;
			if (numberSelect != null)
			{
				numberSelect.ChangeValue(this.CurrentExchangeViewData.StartSliderValue, false);
			}
		}
		this.InitConfirmState();
	}

	// Token: 0x0600FBF2 RID: 64498 RVA: 0x004530D0 File Offset: 0x004512D0
	protected override void OnBeforeShow()
	{
		if (this.GetExChangeData().ShowPayGold)
		{
			CommonCurrencyItem currencyItem = this.CurrencyItem;
			if (currencyItem != null)
			{
				UUIItem originalItem = currencyItem.GetOriginalItem();
				if (originalItem != null)
				{
					IUiPopFrameInterface childPopView = this.ChildPopView;
					UUIItem inParent;
					if (childPopView == null)
					{
						inParent = null;
					}
					else
					{
						CommonPopViewBase popItem = childPopView.PopItem;
						inParent = ((popItem != null) ? popItem.GetCostParent() : null);
					}
					originalItem.SetUIParent(inParent, false);
				}
			}
			int playerMoney = ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(4);
			this.CurrencyItem.RefreshTemp(4, playerMoney.ToString());
			this.CurrencyItem.RefreshAddButtonActive();
			this.CurrencyItem.SetBeforeButtonFunction(new Action(this.BeforeEnterPayShop));
			this.CurrencyItem.SetToPayShopFunction();
		}
		IUiPopFrameInterface childPopView2 = this.ChildPopView;
		if (childPopView2 == null)
		{
			return;
		}
		childPopView2.PopItem.SetCurrencyItemList(this.CurrentExchangeViewData.ShowCurrencyList.ToArray());
	}

	// Token: 0x0600FBF3 RID: 64499 RVA: 0x0045319A File Offset: 0x0045139A
	private void BeforeEnterPayShop()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600FBF4 RID: 64500 RVA: 0x004531A4 File Offset: 0x004513A4
	private void InitNumberSelect()
	{
		this.NumberSelect = new NumberSelectComponent(base.GetItem(13));
		this.NumberSelect.SetLimitMaxValueForce(99999);
		int maxExchangeTime = this.CurrentExchangeViewData.MaxExchangeTime;
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = maxExchangeTime,
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
		this.NumberSelect.SetMaxBtnShowState(true);
		this.NumberSelect.SetAddReduceButtonActive(true);
		this.NumberSelect.SetAddReduceButtonInteractive(maxExchangeTime > 1);
	}

	// Token: 0x0600FBF5 RID: 64501 RVA: 0x00453244 File Offset: 0x00451444
	protected void SetMaxValue()
	{
		this.NumberSelect.SelectMax();
	}

	// Token: 0x0600FBF6 RID: 64502 RVA: 0x00453254 File Offset: 0x00451454
	private void InitConfirmState()
	{
		int maxExchangeTime = this.CurrentExchangeViewData.MaxExchangeTime;
		base.GetInteractionGroup(10).SetInteractable(maxExchangeTime > 0);
	}

	// Token: 0x0600FBF7 RID: 64503 RVA: 0x00453280 File Offset: 0x00451480
	private void Refresh(int exchangeTime)
	{
		CommonExchangeData exChangeData = this.GetExChangeData();
		int exChangeItemId = this.GetExChangeItemId();
		int num = this.CurrentExchangeViewData.GetConsumeCount(exChangeItemId, exchangeTime);
		base.GetText(3).SetText(exChangeData.GetSrcName(), true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "ExChangeCountDescribe2", new <>z__ReadOnlySingleElementList<object>(num));
		int num2 = this.CurrentExchangeViewData.GetGainCount(exChangeItemId, exchangeTime);
		base.GetText(4).SetText(exChangeData.GetDestName(), true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(12), "ExChangeCountDescribe2", new <>z__ReadOnlySingleElementList<object>(num2));
		UUIText text = base.GetText(6);
		int num3 = this.CurrentExchangeViewData.GetConsumeTotalCount(num, exchangeTime);
		text.SetText(num3.ToString(), true);
		int ownSrcItemNum = this.CurrentExchangeViewData.OwnSrcItemNum;
		UUIItem uuiitem = text;
		bool bUseChangeColor = ownSrcItemNum < num3;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		base.GetItem(14).SetUIActive(ownSrcItemNum < num3);
	}

	// Token: 0x0600FBF8 RID: 64504 RVA: 0x00453394 File Offset: 0x00451594
	private void ConfirmBtn()
	{
		CommonExchangeData exChangeData = this.GetExChangeData();
		if (exChangeData != null && exChangeData.ConfirmCallBack != null)
		{
			int selectNumber = this.NumberSelect.GetSelectNumber();
			exChangeData.ConfirmCallBack(exChangeData.GetDestItemId(), selectNumber);
		}
		if (!exChangeData.ConfirmNoClose)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0600FBF9 RID: 64505 RVA: 0x004533E0 File Offset: 0x004515E0
	protected override void OnBeforeDestroy()
	{
		CommonCurrencyItem currencyItem = this.CurrencyItem;
		if (currencyItem == null)
		{
			return;
		}
		currencyItem.Destroy(null);
	}

	// Token: 0x0600FBFA RID: 64506 RVA: 0x004533F4 File Offset: 0x004515F4
	private void CancelBtn()
	{
		CommonExchangeData exChangeData = this.GetExChangeData();
		Action action = (exChangeData != null) ? exChangeData.CancelCallBack : null;
		if (action != null)
		{
			action();
		}
		base.CloseMe(null);
	}

	// Token: 0x040078F5 RID: 30965
	[Nullable(2)]
	private NumberSelectComponent NumberSelect;

	// Token: 0x040078F6 RID: 30966
	[Nullable(2)]
	private CommonCurrencyItem CurrencyItem;

	// Token: 0x040078F7 RID: 30967
	[Nullable(2)]
	private CommonExchangeViewData CurrentExchangeViewData;

	// Token: 0x020083F3 RID: 33779
	[NullableContext(0)]
	private class ECommonExchangeCom
	{
		// Token: 0x0402CBA5 RID: 183205
		public const int TitleText = 0;

		// Token: 0x0402CBA6 RID: 183206
		public const int SrcTexture = 1;

		// Token: 0x0402CBA7 RID: 183207
		public const int DestTexture = 2;

		// Token: 0x0402CBA8 RID: 183208
		public const int SrcNameText = 3;

		// Token: 0x0402CBA9 RID: 183209
		public const int DestNameText = 4;

		// Token: 0x0402CBAA RID: 183210
		public const int ConsumeTexture = 5;

		// Token: 0x0402CBAB RID: 183211
		public const int ConsumeCountText = 6;

		// Token: 0x0402CBAC RID: 183212
		public const int CancelBtn = 7;

		// Token: 0x0402CBAD RID: 183213
		public const int ConfirmBtn = 8;

		// Token: 0x0402CBAE RID: 183214
		public const int CancelInteractionGroup = 9;

		// Token: 0x0402CBAF RID: 183215
		public const int ConfirmInteractionGroup = 10;

		// Token: 0x0402CBB0 RID: 183216
		public const int SrcNameCountText = 11;

		// Token: 0x0402CBB1 RID: 183217
		public const int DestNameCountText = 12;

		// Token: 0x0402CBB2 RID: 183218
		public const int NumberSelect = 13;

		// Token: 0x0402CBB3 RID: 183219
		public const int NoEnoughItem = 14;
	}
}
