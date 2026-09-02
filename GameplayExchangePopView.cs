using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002398 RID: 9112
[NullableContext(2)]
[Nullable(0)]
public class GameplayExchangePopView : UiViewBase
{
	// Token: 0x060117D8 RID: 71640 RVA: 0x004D031F File Offset: 0x004CE51F
	[NullableContext(1)]
	public GameplayExchangePopView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060117D9 RID: 71641 RVA: 0x004D0328 File Offset: 0x004CE528
	protected unsafe override void OnRegisterComponent()
	{
		int num = 17;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnCancelClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnConfirmClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060117DA RID: 71642 RVA: 0x004D05EC File Offset: 0x004CE7EC
	protected override UniTask OnBeforeStartAsync()
	{
		GameplayExchangePopView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GameplayExchangePopView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060117DB RID: 71643 RVA: 0x004D0630 File Offset: 0x004CE830
	protected override void OnStart()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		this.NumberSelect = new NumberSelectComponent(base.GetItem(9));
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = this.ViewProxy.MaxBuyCount,
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
		this.RefreshNumberSelectComponentButtonState();
		base.GetItem(13).SetUIActive(true);
	}

	// Token: 0x060117DC RID: 71644 RVA: 0x004D06B4 File Offset: 0x004CE8B4
	protected override void OnBeforeShow()
	{
		this.RefreshView();
	}

	// Token: 0x060117DD RID: 71645 RVA: 0x004D06BC File Offset: 0x004CE8BC
	protected override void OnBeforeDestroy()
	{
		this.NumberSelect.Destroy(null);
		this.ShopItem.Destroy(null);
		this.RemoveResellTimer();
	}

	// Token: 0x060117DE RID: 71646 RVA: 0x004D06DC File Offset: 0x004CE8DC
	public void RefreshView()
	{
		this.RefreshShopItem();
		this.RefreshDescribeText();
		this.RefreshConfirmButtonState();
		this.RefreshPriceInfo();
		this.RefreshCurrency();
		this.RefreshLockText();
		this.RefreshNumberSelectComponentButtonState();
		this.RefreshTipTitleItem();
	}

	// Token: 0x060117DF RID: 71647 RVA: 0x004D070E File Offset: 0x004CE90E
	public void RefreshShopItem()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		this.ViewProxy.ShopItemRefresh();
	}

	// Token: 0x060117E0 RID: 71648 RVA: 0x004D0724 File Offset: 0x004CE924
	public void RefreshDescribeText()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		GameplayShopUtil.SetText(base.GetText(5), this.ViewProxy.DescribeTextData);
	}

	// Token: 0x060117E1 RID: 71649 RVA: 0x004D0748 File Offset: 0x004CE948
	public void RefreshConfirmButtonState()
	{
		bool selfInteractive = this.ViewProxy.CheckConfirmButtonCanInteract();
		base.GetButton(7).SetSelfInteractive(selfInteractive);
	}

	// Token: 0x060117E2 RID: 71650 RVA: 0x004D0770 File Offset: 0x004CE970
	public void RefreshPriceInfo()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		base.SetItemIcon(base.GetTexture(3), this.ViewProxy.CurrencyId, null, null);
		UUIText text = base.GetText(4);
		int num = this.ViewProxy.BuyCount * this.ViewProxy.Price;
		bool flag = this.ViewProxy.CheckMoneyEnough();
		text.SetText(num.ToString(), true);
		UUIItem uuiitem = text;
		bool bUseChangeColor = !flag;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x060117E3 RID: 71651 RVA: 0x004D07FC File Offset: 0x004CE9FC
	public void RefreshLimitText()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		UUIText text = base.GetText(16);
		bool limitTextItemVisible = this.ViewProxy.LimitTextItemVisible;
		text.SetUIActive(limitTextItemVisible);
		if (limitTextItemVisible)
		{
			GameplayShopUtil.SetText(text, this.ViewProxy.LimitTextData);
			text.SetColor(FColor.FromHex("FED12E"));
		}
	}

	// Token: 0x060117E4 RID: 71652 RVA: 0x004D0854 File Offset: 0x004CEA54
	public void RefreshCurrency()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		UiAsyncTask task = new UiAsyncTask("RefreshCurrency", delegate()
		{
			GameplayExchangePopView.<<RefreshCurrency>b__19_0>d <<RefreshCurrency>b__19_0>d;
			<<RefreshCurrency>b__19_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<RefreshCurrency>b__19_0>d.<>4__this = this;
			<<RefreshCurrency>b__19_0>d.<>1__state = -1;
			<<RefreshCurrency>b__19_0>d.<>t__builder.Start<GameplayExchangePopView.<<RefreshCurrency>b__19_0>d>(ref <<RefreshCurrency>b__19_0>d);
			return <<RefreshCurrency>b__19_0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
	}

	// Token: 0x060117E5 RID: 71653 RVA: 0x004D088C File Offset: 0x004CEA8C
	private UniTask RefreshCurrencyAsync()
	{
		GameplayExchangePopView.<RefreshCurrencyAsync>d__20 <RefreshCurrencyAsync>d__;
		<RefreshCurrencyAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCurrencyAsync>d__.<>4__this = this;
		<RefreshCurrencyAsync>d__.<>1__state = -1;
		<RefreshCurrencyAsync>d__.<>t__builder.Start<GameplayExchangePopView.<RefreshCurrencyAsync>d__20>(ref <RefreshCurrencyAsync>d__);
		return <RefreshCurrencyAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060117E6 RID: 71654 RVA: 0x004D08D0 File Offset: 0x004CEAD0
	public void RefreshLockText()
	{
		this.RemoveResellTimer();
		if (this.ViewProxy == null)
		{
			return;
		}
		bool lockItemVisible = this.ViewProxy.LockItemVisible;
		base.GetItem(11).SetUIActive(lockItemVisible);
		if (lockItemVisible)
		{
			GameplayShopUtil.SetText(base.GetText(12), this.ViewProxy.LockTextData);
		}
		if (this.ViewProxy.ReSellTime > 0)
		{
			this.ResellTimerId = TimerSystem.RealTimeInstance.Delay(new TTimerAction(this.RefreshReSellText), (float)(this.ViewProxy.ReSellTime * 1000), null, null, true, 1f);
		}
	}

	// Token: 0x060117E7 RID: 71655 RVA: 0x004D0965 File Offset: 0x004CEB65
	public void RefreshReSellText(float _)
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		this.ViewProxy.OnResellTimeRefresh();
		this.RefreshLockText();
	}

	// Token: 0x060117E8 RID: 71656 RVA: 0x004D0981 File Offset: 0x004CEB81
	public void RemoveResellTimer()
	{
		if (this.ResellTimerId != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.ResellTimerId);
			this.ResellTimerId = null;
		}
	}

	// Token: 0x060117E9 RID: 71657 RVA: 0x004D09A4 File Offset: 0x004CEBA4
	public void RefreshLeftTimeText()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		base.GetItem(15).SetUIActive(this.ViewProxy.LeftTimeItemVisible);
		if (this.ViewProxy.LeftTimeItemVisible)
		{
			GameplayShopUtil.SetText(base.GetText(14), this.ViewProxy.LeftTimeDescTextData);
			bool leftTimeTextVisible = this.ViewProxy.LeftTimeTextVisible;
			UUIText text = base.GetText(16);
			text.SetUIActive(leftTimeTextVisible);
			if (leftTimeTextVisible)
			{
				GameplayShopUtil.SetText(text, this.ViewProxy.LeftTimeTextData);
			}
		}
	}

	// Token: 0x060117EA RID: 71658 RVA: 0x004D0A27 File Offset: 0x004CEC27
	public void RefreshTipTitleItem()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		base.GetItem(8).SetUIActive(this.ViewProxy.TipTitleItemVisible);
		if (this.ViewProxy.TipTitleItemVisible)
		{
			this.RefreshLimitText();
			this.RefreshLeftTimeText();
		}
	}

	// Token: 0x060117EB RID: 71659 RVA: 0x004D0A62 File Offset: 0x004CEC62
	public void RefreshNumberSelectComponentButtonState()
	{
		if (this.NumberSelect.GetIfLimit())
		{
			this.NumberSelect.SetAddReduceButtonActive(true);
			this.NumberSelect.SetAddReduceButtonInteractive(false);
		}
	}

	// Token: 0x060117EC RID: 71660 RVA: 0x004D0A89 File Offset: 0x004CEC89
	private void BeforeEnterPayShop()
	{
		base.CloseMe(null);
	}

	// Token: 0x060117ED RID: 71661 RVA: 0x004D0A94 File Offset: 0x004CEC94
	[NullableContext(1)]
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		IGameplayShopExchangePopViewProxy viewProxy = this.ViewProxy;
		string text = (viewProxy != null) ? viewProxy.ExchangeTableTextId : null;
		return new TableTextArgNew((!string.IsNullOrEmpty(text) && !StringUtils.IsEmpty(text)) ? text : "Text_BugCount_Text", new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x060117EE RID: 71662 RVA: 0x004D0AE2 File Offset: 0x004CECE2
	private void ValueChangeFunction(int selectValue)
	{
		this.ViewProxy.BuyCount = selectValue;
		this.RefreshPriceInfo();
	}

	// Token: 0x060117EF RID: 71663 RVA: 0x004D0AF6 File Offset: 0x004CECF6
	private void OnCancelClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060117F0 RID: 71664 RVA: 0x004D0AFF File Offset: 0x004CECFF
	private void OnConfirmClick()
	{
		if (this.ViewProxy == null)
		{
			return;
		}
		this.ViewProxy.OnConfirmButtonClick(base.GetViewId());
	}

	// Token: 0x04008934 RID: 35124
	[Nullable(1)]
	private const string COLOR = "FED12E";

	// Token: 0x04008935 RID: 35125
	protected IGameplayShopExchangePopViewProxy ViewProxy;

	// Token: 0x04008936 RID: 35126
	protected TimerHandle ResellTimerId;

	// Token: 0x04008937 RID: 35127
	protected UiPanelBase ShopItem;

	// Token: 0x04008938 RID: 35128
	private NumberSelectComponent NumberSelect;

	// Token: 0x04008939 RID: 35129
	private CommonCurrencyItemListComponent CustomCurrencyItemList;

	// Token: 0x020086B0 RID: 34480
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402D8DA RID: 186586
		EndTimeIcon,
		// Token: 0x0402D8DB RID: 186587
		EndTimeText,
		// Token: 0x0402D8DC RID: 186588
		ItemAttach,
		// Token: 0x0402D8DD RID: 186589
		CurrencyIcon,
		// Token: 0x0402D8DE RID: 186590
		CurrencyCount,
		// Token: 0x0402D8DF RID: 186591
		DescribeText,
		// Token: 0x0402D8E0 RID: 186592
		CancelButton,
		// Token: 0x0402D8E1 RID: 186593
		ConfirmButton,
		// Token: 0x0402D8E2 RID: 186594
		TipTitleItem,
		// Token: 0x0402D8E3 RID: 186595
		NumberSelect,
		// Token: 0x0402D8E4 RID: 186596
		LimitText,
		// Token: 0x0402D8E5 RID: 186597
		LockItem,
		// Token: 0x0402D8E6 RID: 186598
		LockText,
		// Token: 0x0402D8E7 RID: 186599
		ItemPanel,
		// Token: 0x0402D8E8 RID: 186600
		LeftTimeDescText,
		// Token: 0x0402D8E9 RID: 186601
		LeftTimeItem,
		// Token: 0x0402D8EA RID: 186602
		LeftTimeText
	}
}
