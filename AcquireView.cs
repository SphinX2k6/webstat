using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02000FF4 RID: 4084
[NullableContext(2)]
[Nullable(0)]
public class AcquireView : UiViewBase
{
	// Token: 0x06006990 RID: 27024 RVA: 0x001B7B88 File Offset: 0x001B5D88
	[NullableContext(1)]
	public AcquireView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006991 RID: 27025 RVA: 0x001B7B94 File Offset: 0x001B5D94
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRightButton)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeftButton)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickMidButton)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickLeftButton))
		};
	}

	// Token: 0x06006992 RID: 27026 RVA: 0x001B7D0C File Offset: 0x001B5F0C
	[NullableContext(1)]
	private TableTextArgNew GetExchangeTableText(int selectValue)
	{
		return new TableTextArgNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("UseCount"), new <>z__ReadOnlySingleElementList<object>(selectValue));
	}

	// Token: 0x06006993 RID: 27027 RVA: 0x001B7D2D File Offset: 0x001B5F2D
	private void ValueChangeFunction(int selectValue)
	{
		if (this.AcquireData.GetRemainItemCount() > 0)
		{
			this.AcquireData.SetAmount(selectValue);
			return;
		}
		this.AcquireData.SetAmount(0);
	}

	// Token: 0x06006994 RID: 27028 RVA: 0x001B7D58 File Offset: 0x001B5F58
	private void InitNumberSelect()
	{
		this.NumberSelect = new NumberSelectComponent(base.GetItem(10));
		int maxAmount = this.AcquireData.GetMaxAmount();
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = maxAmount,
			GetExchangeTableText = new Func<int, TableTextArgNew>(this.GetExchangeTableText),
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		if (this.CheckIfGiftItem())
		{
			this.NumberSelect.SetLimitMaxValue(ConfigBase<CommonConfig>.Instance.GetGiftMaxNineNineNine());
		}
		this.NumberSelect.Init(data);
	}

	// Token: 0x06006995 RID: 27029 RVA: 0x001B7DE0 File Offset: 0x001B5FE0
	private bool CheckIfGiftItem()
	{
		int configId = this.AcquireData.GetConfigId();
		if (configId == 0)
		{
			return false;
		}
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(configId);
		if (itemConfigData == null)
		{
			return false;
		}
		InventoryDefine.EItemType? itemType = itemConfigData.ItemType;
		return itemType.GetValueOrDefault() == InventoryDefine.EItemType.Gift;
	}

	// Token: 0x06006996 RID: 27030 RVA: 0x001B7E24 File Offset: 0x001B6024
	protected override void OnStart()
	{
		this.AcquireData = (this.OpenParam as AcquireData);
		this.ItemNameText = base.GetText(5);
		this.RightButtonText = base.GetText(7);
		this.TitleText = base.GetText(2);
		this.InitNumberSelect();
		this.GenericScrollView = new GenericScrollView<CommonItemSmallItemGrid>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<CommonItemSmallItemGrid>(this.CreatePropItem), base.GetItem(1));
		List<TItem> itemData = this.AcquireData.GetItemData();
		this.GenericScrollView.RefreshByData<TItem>(itemData, null);
		this.RefreshButtonState();
		this.RefreshByAcquireData();
	}

	// Token: 0x06006997 RID: 27031 RVA: 0x001B7EC4 File Offset: 0x001B60C4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<AcquireData>(EEventName.RefreshAcquireView, new Action<AcquireData>(this.Refresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnShowRewardView, new Action(this.OnShowRewardView));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x06006998 RID: 27032 RVA: 0x001B7F24 File Offset: 0x001B6124
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshAcquireView, new Action<AcquireData>(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnShowRewardView, new Action(this.OnShowRewardView));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x06006999 RID: 27033 RVA: 0x001B7F82 File Offset: 0x001B6182
	private void OnShowRewardView()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView == null)
		{
			return;
		}
		childPopView.HidePopView();
	}

	// Token: 0x0600699A RID: 27034 RVA: 0x001B7F94 File Offset: 0x001B6194
	private void OnCloseView(EUiViewName viewName, int i)
	{
		if (viewName == EUiViewName.CommonRewardView || viewName == EUiViewName.CompositeRewardView || viewName == EUiViewName.ExploreRewardView)
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			childPopView.ShowPopView();
		}
	}

	// Token: 0x0600699B RID: 27035 RVA: 0x001B7FD0 File Offset: 0x001B61D0
	[NullableContext(1)]
	private void Refresh(AcquireData acquireData)
	{
		if (acquireData.GetRemainItemCount() <= 0)
		{
			base.CloseMe(null);
			return;
		}
		this.AcquireData = acquireData;
		List<TItem> itemData = this.AcquireData.GetItemData();
		this.GenericScrollView.RefreshByData<TItem>(itemData, null);
		this.RefreshButtonState();
		this.RefreshByAcquireData();
		this.NumberSelect.Refresh(this.AcquireData.GetRemainItemCount());
	}

	// Token: 0x0600699C RID: 27036 RVA: 0x001B8038 File Offset: 0x001B6238
	protected void RefreshButtonState()
	{
		bool leftButtonFunction = this.AcquireData.GetLeftButtonFunction() != null;
		Func<UniTask> rightButtonFunction = this.AcquireData.GetRightButtonFunction();
		UUIButtonComponent button = base.GetButton(3);
		UUIButtonComponent button2 = base.GetButton(4);
		UUIButtonComponent button3 = base.GetButton(8);
		UUIButtonComponent button4 = base.GetButton(9);
		if (!leftButtonFunction && rightButtonFunction == null)
		{
			button.RootUIComp.Get().SetUIActive(false);
			button2.RootUIComp.Get().SetUIActive(false);
			button4.RootUIComp.Get().SetUIActive(false);
			button3.RootUIComp.Get().SetUIActive(true);
			return;
		}
		int acquireViewType = (int)this.AcquireData.GetAcquireViewType();
		button2.RootUIComp.Get().SetUIActive(true);
		button3.RootUIComp.Get().SetUIActive(false);
		if (acquireViewType == 2)
		{
			button4.RootUIComp.Get().SetUIActive(true);
			button.RootUIComp.Get().SetUIActive(false);
			button2.RootUIComp.Get().SetUIActive(true);
			button3.RootUIComp.Get().SetUIActive(false);
			return;
		}
		button4.RootUIComp.Get().SetUIActive(false);
		button.RootUIComp.Get().SetUIActive(true);
		button2.RootUIComp.Get().SetUIActive(true);
		button3.RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600699D RID: 27037 RVA: 0x001B81BC File Offset: 0x001B63BC
	[NullableContext(1)]
	private ILayoutItem<CommonItemSmallItemGrid> CreatePropItem(object data, UUIItem uiItem, int index)
	{
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.Initialize(uiItem.GetOwner());
		commonItemSmallItemGrid.Refresh((TItem)data);
		return new LayoutItem<CommonItemSmallItemGrid>
		{
			Key = index,
			Value = commonItemSmallItemGrid
		};
	}

	// Token: 0x0600699E RID: 27038 RVA: 0x001B8200 File Offset: 0x001B6400
	private void RefreshAmount()
	{
		bool flag = this.AcquireData.GetAcquireViewType() == EAcquireViewType.SelectAmount;
		this.ItemNameText.SetUIActive(flag);
		if (flag)
		{
			this.ItemNameText.SetText(this.AcquireData.GetNameText(), true);
			Singleton<LguiUtil>.Instance.SetLocalText(this.TitleText, "AcquireOpenCount", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(this.TitleText, "AcquireGetReward", Array.Empty<object>());
	}

	// Token: 0x0600699F RID: 27039 RVA: 0x001B8278 File Offset: 0x001B6478
	private void RefreshButton()
	{
		string leftButtonTextTableId = this.AcquireData.GetLeftButtonTextTableId();
		Singleton<LguiUtil>.Instance.SetLocalText(this.LeftButtonText, leftButtonTextTableId ?? "AcquireCancel", Array.Empty<object>());
		string rightButtonTextTableId = this.AcquireData.GetRightButtonTextTableId();
		Singleton<LguiUtil>.Instance.SetLocalText(this.RightButtonText, rightButtonTextTableId ?? "AcquireConfirm", Array.Empty<object>());
	}

	// Token: 0x060069A0 RID: 27040 RVA: 0x001B82DB File Offset: 0x001B64DB
	private void RefreshByAcquireData()
	{
		this.RefreshAmount();
		this.RefreshButton();
	}

	// Token: 0x060069A1 RID: 27041 RVA: 0x001B82EC File Offset: 0x001B64EC
	protected override void OnBeforeDestroy()
	{
		Func<UniTask> midButtonFunction = this.AcquireData.GetMidButtonFunction();
		if (midButtonFunction != null)
		{
			midButtonFunction().Forget();
		}
		ModelBase<InventoryModel>.Instance.SetAcquireData(null);
		this.ItemNameText = null;
		this.GenericScrollView.ClearChildren();
		this.GenericScrollView = null;
		this.LeftButtonText = null;
		this.RightButtonText = null;
		this.TitleText = null;
		this.AcquireData = null;
	}

	// Token: 0x060069A2 RID: 27042 RVA: 0x001B8353 File Offset: 0x001B6553
	private void ClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x060069A3 RID: 27043 RVA: 0x001B835C File Offset: 0x001B655C
	private void OnClickLeftButton()
	{
		Func<UniTask> leftButtonFunction = this.AcquireData.GetLeftButtonFunction();
		if (leftButtonFunction != null)
		{
			leftButtonFunction().Forget();
			return;
		}
		this.ClickClose();
	}

	// Token: 0x060069A4 RID: 27044 RVA: 0x001B838C File Offset: 0x001B658C
	private void OnClickRightButton()
	{
		Func<UniTask> rightButtonFunction = this.AcquireData.GetRightButtonFunction();
		if (rightButtonFunction != null)
		{
			rightButtonFunction().Forget();
			return;
		}
		this.ClickClose();
	}

	// Token: 0x060069A5 RID: 27045 RVA: 0x001B83BA File Offset: 0x001B65BA
	private void OnClickMidButton()
	{
		this.ClickClose();
	}

	// Token: 0x04003227 RID: 12839
	private UUIText ItemNameText;

	// Token: 0x04003228 RID: 12840
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<CommonItemSmallItemGrid> GenericScrollView;

	// Token: 0x04003229 RID: 12841
	private UUIText LeftButtonText;

	// Token: 0x0400322A RID: 12842
	private UUIText RightButtonText;

	// Token: 0x0400322B RID: 12843
	private UUIText TitleText;

	// Token: 0x0400322C RID: 12844
	private AcquireData AcquireData;

	// Token: 0x0400322D RID: 12845
	private NumberSelectComponent NumberSelect;

	// Token: 0x020073D5 RID: 29653
	[NullableContext(0)]
	public enum EAcquireViewDefine
	{
		// Token: 0x0402812E RID: 164142
		GenericScrollView,
		// Token: 0x0402812F RID: 164143
		LoopScrollItem,
		// Token: 0x04028130 RID: 164144
		TitleText,
		// Token: 0x04028131 RID: 164145
		LeftButton,
		// Token: 0x04028132 RID: 164146
		RightButton,
		// Token: 0x04028133 RID: 164147
		ItemNameText,
		// Token: 0x04028134 RID: 164148
		LeftButtonText,
		// Token: 0x04028135 RID: 164149
		RightButtonText,
		// Token: 0x04028136 RID: 164150
		MidButton,
		// Token: 0x04028137 RID: 164151
		OpenNextButton,
		// Token: 0x04028138 RID: 164152
		NumberSelect
	}
}
