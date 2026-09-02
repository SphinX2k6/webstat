using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200189F RID: 6303
[NullableContext(1)]
[Nullable(0)]
public class CommonCurrencyItem : UiPanelBase
{
	// Token: 0x17000EF3 RID: 3827
	// (set) Token: 0x0600B4F2 RID: 46322 RVA: 0x0030317D File Offset: 0x0030137D
	public Action<int> ButtonFunction
	{
		set
		{
			value != this.ButtonFunctionInternal;
			this.ButtonFunctionInternal = value;
		}
	}

	// Token: 0x0600B4F3 RID: 46323 RVA: 0x00303194 File Offset: 0x00301394
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITextureTransitionComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.ButtonClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.TextureClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B4F4 RID: 46324 RVA: 0x00303345 File Offset: 0x00301545
	private void ButtonClick()
	{
		Action beforeButtonFunction = this.BeforeButtonFunction;
		if (beforeButtonFunction != null)
		{
			beforeButtonFunction();
		}
		Action<int> buttonFunctionInternal = this.ButtonFunctionInternal;
		if (buttonFunctionInternal == null)
		{
			return;
		}
		buttonFunctionInternal(this.ItemId);
	}

	// Token: 0x0600B4F5 RID: 46325 RVA: 0x0030336E File Offset: 0x0030156E
	private void TextureClick()
	{
		if (this.TextureClickCheckFunction != null && !this.TextureClickCheckFunction(this.ItemId))
		{
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
	}

	// Token: 0x0600B4F6 RID: 46326 RVA: 0x0030339E File Offset: 0x0030159E
	protected override void OnStart()
	{
		if (!this.SkipAutoAddEvent)
		{
			this.AddEventListener();
		}
	}

	// Token: 0x0600B4F7 RID: 46327 RVA: 0x003033AE File Offset: 0x003015AE
	protected override void OnBeforeDestroy()
	{
		if (!this.SkipAutoAddEvent)
		{
			this.RemoveEventListener();
		}
	}

	// Token: 0x0600B4F8 RID: 46328 RVA: 0x003033C0 File Offset: 0x003015C0
	public virtual void AddEventListener()
	{
		if (this.EventListenerAdded)
		{
			return;
		}
		this.EventListenerAdded = true;
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(this.OnPayShopGoodsBuy));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.RefreshCurrency));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnRemoveCommonItem));
		Singleton<EventSystem>.Instance.Add<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
	}

	// Token: 0x0600B4F9 RID: 46329 RVA: 0x0030346C File Offset: 0x0030166C
	public virtual void RemoveEventListener()
	{
		if (!this.EventListenerAdded)
		{
			return;
		}
		this.EventListenerAdded = false;
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(this.OnPayShopGoodsBuy));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.RefreshCurrency));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<int>>(EEventName.OnRemoveCommonItem, new Action<IReadOnlyList<int>>(this.OnRemoveCommonItem));
		Singleton<EventSystem>.Instance.Remove<IProto_NormalItem, int, int>(EEventName.OnCommonItemCountRefresh, new Action<IProto_NormalItem, int, int>(this.OnCommonItemCountRefresh));
	}

	// Token: 0x0600B4FA RID: 46330 RVA: 0x00303515 File Offset: 0x00301715
	private void RefreshCurrency(int itemId = 0)
	{
		this.RefreshCountText(null);
	}

	// Token: 0x0600B4FB RID: 46331 RVA: 0x0030351E File Offset: 0x0030171E
	private void OnPayShopGoodsBuy()
	{
		this.RefreshCurrency(0);
	}

	// Token: 0x0600B4FC RID: 46332 RVA: 0x00303528 File Offset: 0x00301728
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList)
	{
		foreach (IProto_NormalItem proto_NormalItem in normalItemList)
		{
			if (this.ItemId == proto_NormalItem.Id)
			{
				this.RefreshCountText(null);
				break;
			}
		}
	}

	// Token: 0x0600B4FD RID: 46333 RVA: 0x00303580 File Offset: 0x00301780
	private void OnRemoveCommonItem(IReadOnlyList<int> configId)
	{
		if (!configId.Contains(this.ItemId))
		{
			return;
		}
		this.RefreshCountText(null);
	}

	// Token: 0x0600B4FE RID: 46334 RVA: 0x00303598 File Offset: 0x00301798
	private void OnCommonItemCountRefresh(IProto_NormalItem normalItem, int count, int lastCount)
	{
		if (this.ItemId != normalItem.Id)
		{
			return;
		}
		this.RefreshCountText(null);
	}

	// Token: 0x0600B4FF RID: 46335 RVA: 0x003035B0 File Offset: 0x003017B0
	private void SetTexture()
	{
		UUITexture texture = base.GetTexture(0);
		texture.SetUIActive(false);
		base.SetItemIcon(base.GetTexture(0), this.ItemId, null, delegate(bool _)
		{
			this.SetTextureAllTransition();
			texture.SetUIActive(true);
		});
	}

	// Token: 0x0600B500 RID: 46336 RVA: 0x0030360C File Offset: 0x0030180C
	private void SetTextureAllTransition()
	{
		UUITextureTransitionComponent uiTextureTransitionComponent = base.GetUiTextureTransitionComponent(4);
		if (uiTextureTransitionComponent != null)
		{
			uiTextureTransitionComponent.SetAllStateTexture(base.GetTexture(0).GetTexture());
		}
	}

	// Token: 0x0600B501 RID: 46337 RVA: 0x00303638 File Offset: 0x00301838
	private void PayCurrencyClick(int itemId)
	{
		int? num = ConfigBase<GachaConfig>.Instance.PrimaryCurrency();
		int? num2 = num;
		if (itemId == num2.GetValueOrDefault() & num2 != null)
		{
			ControllerBase<PayShopController>.Instance.OpenPayShopViewToRecharge();
			return;
		}
		int? num3 = ConfigBase<GachaConfig>.Instance.SecondCurrency();
		num2 = num3;
		if (itemId == num2.GetValueOrDefault() & num2 != null)
		{
			ControllerBase<ItemExchangeController>.Instance.OpenExchangeViewByItemId(itemId, null, false);
		}
	}

	// Token: 0x0600B502 RID: 46338 RVA: 0x0030369F File Offset: 0x0030189F
	public virtual void RefreshTemp(int itemId, string countText = null)
	{
		this.ShowWithoutText(itemId);
		this.RefreshCountText(countText);
	}

	// Token: 0x0600B503 RID: 46339 RVA: 0x003036AF File Offset: 0x003018AF
	public virtual void ShowWithoutText(int itemId)
	{
		this.ItemId = itemId;
		this.SetTexture();
	}

	// Token: 0x0600B504 RID: 46340 RVA: 0x003036C0 File Offset: 0x003018C0
	[NullableContext(2)]
	public void RefreshCountText(string text = null)
	{
		UUIText text2 = base.GetText(1);
		string text3 = text ?? ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0).ToString();
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text3.ToString(), true);
	}

	// Token: 0x0600B505 RID: 46341 RVA: 0x00303704 File Offset: 0x00301904
	public void SetCountText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, args);
	}

	// Token: 0x0600B506 RID: 46342 RVA: 0x00303719 File Offset: 0x00301919
	public void SetCountTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x0600B507 RID: 46343 RVA: 0x0030372E File Offset: 0x0030192E
	public void SetCount(int count)
	{
		base.GetText(1).SetText(count.ToString(), true);
	}

	// Token: 0x0600B508 RID: 46344 RVA: 0x00303744 File Offset: 0x00301944
	public void SetButtonFunction(Action<int> callback)
	{
		this.ButtonFunction = callback;
	}

	// Token: 0x0600B509 RID: 46345 RVA: 0x0030374D File Offset: 0x0030194D
	public void SetBeforeButtonFunction(Action callback)
	{
		this.BeforeButtonFunction = callback;
	}

	// Token: 0x0600B50A RID: 46346 RVA: 0x00303756 File Offset: 0x00301956
	public void SetTextureClickCheckFunction(Func<int, bool> callback)
	{
		this.TextureClickCheckFunction = callback;
	}

	// Token: 0x0600B50B RID: 46347 RVA: 0x00303760 File Offset: 0x00301960
	public void SetButtonActive(bool bActive)
	{
		UUIItem uuiitem = base.GetButton(2).RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(bActive);
	}

	// Token: 0x0600B50C RID: 46348 RVA: 0x0030378C File Offset: 0x0030198C
	public void RefreshMaxItem(bool bActive)
	{
		base.GetItem(8).SetUIActive(bActive);
	}

	// Token: 0x0600B50D RID: 46349 RVA: 0x0030379B File Offset: 0x0030199B
	public void SetToPayShopFunction()
	{
		this.ButtonFunction = new Action<int>(this.PayCurrencyClick);
	}

	// Token: 0x0600B50E RID: 46350 RVA: 0x003037B0 File Offset: 0x003019B0
	public virtual void RefreshAddButtonActive()
	{
		int? num = ConfigBase<GachaConfig>.Instance.PrimaryCurrency();
		int? num2 = ConfigBase<GachaConfig>.Instance.SecondCurrency();
		UUIButtonComponent button = base.GetButton(2);
		int itemId = this.ItemId;
		int? num3 = num;
		if (!(itemId == num3.GetValueOrDefault() & num3 != null))
		{
			int itemId2 = this.ItemId;
			num3 = num2;
			if (!(itemId2 == num3.GetValueOrDefault() & num3 != null))
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem == null)
				{
					return;
				}
				uuiitem.SetUIActive(false);
				return;
			}
		}
		UUIItem uuiitem2 = button.RootUIComp.Get();
		if (uuiitem2 == null)
		{
			return;
		}
		uuiitem2.SetUIActive(true);
	}

	// Token: 0x0400557D RID: 21885
	public int ItemId;

	// Token: 0x0400557E RID: 21886
	public bool SkipAutoAddEvent;

	// Token: 0x0400557F RID: 21887
	private bool EventListenerAdded;

	// Token: 0x04005580 RID: 21888
	private Action<int> ButtonFunctionInternal;

	// Token: 0x04005581 RID: 21889
	private Action BeforeButtonFunction;

	// Token: 0x04005582 RID: 21890
	[Nullable(2)]
	private Func<int, bool> TextureClickCheckFunction;

	// Token: 0x02007C21 RID: 31777
	[NullableContext(0)]
	private class ECommonCurrencyItem
	{
		// Token: 0x0402A660 RID: 173664
		public const int Texture = 0;

		// Token: 0x0402A661 RID: 173665
		public const int CountText = 1;

		// Token: 0x0402A662 RID: 173666
		public const int Button = 2;

		// Token: 0x0402A663 RID: 173667
		public const int TextureButton = 3;

		// Token: 0x0402A664 RID: 173668
		public const int TextureTransition = 4;

		// Token: 0x0402A665 RID: 173669
		public const int SliderItem = 5;

		// Token: 0x0402A666 RID: 173670
		public const int SliderSprite = 6;

		// Token: 0x0402A667 RID: 173671
		public const int SpriteIcon = 7;

		// Token: 0x0402A668 RID: 173672
		public const int MaxItem = 8;
	}
}
