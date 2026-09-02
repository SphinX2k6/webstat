using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Common.NumberSelect;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A01 RID: 10753
[NullableContext(2)]
[Nullable(0)]
public class ShopItemInfoDetailPanel : UiPanelBase
{
	// Token: 0x17001BFB RID: 7163
	// (get) Token: 0x0601573F RID: 87871 RVA: 0x005F1E23 File Offset: 0x005F0023
	// (set) Token: 0x06015740 RID: 87872 RVA: 0x005F1E2C File Offset: 0x005F002C
	private int BuyCount
	{
		get
		{
			return this.Count;
		}
		set
		{
			this.Count = Math.Max(1, Math.Min(value, this.BuyCountMax));
			bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ShopPanelData.CurrencyId, 0) >= this.ShopPanelData.SingleBuyPrice * this.Count;
			UUIText text = base.GetText(6);
			text.SetColor(flag ? this.PurchaseTextOriginColor.Value : this.coinNotEnoughColor);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ShopPanelData.SingleBuyPrice * this.Count);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			ShopItemFullInfo openItemInfo = ModelBase<ShopModel>.Instance.OpenItemInfo;
			UUIText text2 = base.GetText(23);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("<s>");
			defaultInterpolatedStringHandler.AppendFormatted<int>(openItemInfo.GetOriginalPrice() * this.Count);
			defaultInterpolatedStringHandler.AppendLiteral("</s>");
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(27), "Text_ItemSelectShopQuantityTip_text", new <>z__ReadOnlySingleElementList<object>(this.Count));
		}
	}

	// Token: 0x06015741 RID: 87873 RVA: 0x005F1F50 File Offset: 0x005F0150
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(21, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIText)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIText)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUIText)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.BuyClick)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnCurrencyNodeButtonClick))
		};
	}

	// Token: 0x06015742 RID: 87874 RVA: 0x005F2250 File Offset: 0x005F0450
	protected override UniTask OnBeforeStartAsync()
	{
		ShopItemInfoDetailPanel.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShopItemInfoDetailPanel.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015743 RID: 87875 RVA: 0x005F2294 File Offset: 0x005F0494
	protected override void OnStart()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.SequenceEvent));
		}
		this.PurchaseTextOriginColor = new FColor?(base.GetText(6).GetColor());
		this.AttributeVertical = new GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData>(base.GetVerticalLayout(20), new Func<AttributeItem>(this.InitDetail), null, false, true);
		UUIButtonComponent button = base.GetButton(15);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
			}
		}
		UUIItem item = base.GetItem(10);
		this.NumberSelect = new NumberSelectComponent(item);
		this.NumberSelect.SetNumberSelectTipsVisible(false);
		UUIButtonComponent button2 = base.GetButton(7);
		if (button2 != null)
		{
			this.BuyButtonInteractGroup = (button2.GetOwner().GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup);
		}
		base.GetItem(28).SetUIActive(false);
		base.GetItem(29).SetUIActive(false);
	}

	// Token: 0x06015744 RID: 87876 RVA: 0x005F238A File Offset: 0x005F058A
	private void ValueChangeFunction(int selectValue)
	{
		this.BuyCount = selectValue;
	}

	// Token: 0x06015745 RID: 87877 RVA: 0x005F2393 File Offset: 0x005F0593
	[NullableContext(1)]
	private AttributeItem InitDetail()
	{
		return new AttributeItem();
	}

	// Token: 0x06015746 RID: 87878 RVA: 0x005F239A File Offset: 0x005F059A
	private void UpdateAttribute()
	{
		this.AttributeVertical.RefreshByData(this.CommonTipsData.AttributeList, null, false);
	}

	// Token: 0x06015747 RID: 87879 RVA: 0x005F23B4 File Offset: 0x005F05B4
	[NullableContext(1)]
	private void SequenceEvent(string sequenceName, string eventName)
	{
		if (eventName == "CloseEvent")
		{
			this.SetActive(false);
			return;
		}
		if (eventName == "SleEvent")
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.CloseItemInfo);
		}
	}

	// Token: 0x06015748 RID: 87880 RVA: 0x005F23E8 File Offset: 0x005F05E8
	protected override void OnBeforeDestroy()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Unbind();
		}
		if (this.TipsWeaponItem != null)
		{
			this.TipsWeaponItem.Destroy(null);
			this.TipsWeaponItem = null;
		}
	}

	// Token: 0x06015749 RID: 87881 RVA: 0x005F2428 File Offset: 0x005F0628
	public void UpdatePanel(ShopPanelData panelData = null)
	{
		this.ShopPanelData = ((panelData != null) ? panelData : this.ShopPanelData);
		this.CommonTipsData = (CommonTipsComponentUtil.GetTipsDataByItemId(panelData.ItemId) as CommonTipsData);
		this.BuyCountMax = this.GetMaxCanBuyCount();
		this.BuyCount = 1;
		INumberSelectData data = new INumberSelectData
		{
			MaxNumber = this.BuyCountMax,
			ValueChangeFunction = new Action<int>(this.ValueChangeFunction)
		};
		this.NumberSelect.Init(data);
		this.NumberSelect.SetAddReduceButtonActive(true);
		this.NumberSelect.SetAddReduceButtonInteractive(this.BuyCountMax >= this.BuyCount);
		this.NumberSelect.SetReduceButtonInteractive(this.BuyCount > 1);
		ShopItemFullInfo openItemInfo = ModelBase<ShopModel>.Instance.OpenItemInfo;
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(panelData.ItemId);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "GoodsName", new <>z__ReadOnlyArray<object>(new object[]
		{
			new TableTextArgNew(itemConfigData.Name, Array.Empty<object>()),
			openItemInfo.StackSize
		}));
		Regex regex = new Regex("<.*?>");
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.AttributesDescription, null);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.TypeDescription, null);
		string newText = regex.Replace(localTextNew, "");
		CommonTipsData commonTipsData = this.CommonTipsData;
		string newText2 = ((commonTipsData != null) ? commonTipsData.Type : null) ?? localTextNew2;
		base.GetText(1).SetText(newText2, true);
		base.GetText(2).SetText(newText, true);
		base.SetItemIcon(base.GetTexture(5), panelData.CurrencyId, null, null);
		bool flag = itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.CookMenu || itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.ForgingFormula || itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.ComposeFormula;
		base.GetText(16).SetUIActive(!flag);
		if (!flag)
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(panelData.ItemId, 0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "Text_Have_Text", new <>z__ReadOnlySingleElementList<object>(itemCountByConfigId));
		}
		UUIText text = base.GetText(23);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("<s>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(openItemInfo.GetOriginalPrice() * this.BuyCount);
		defaultInterpolatedStringHandler.AppendLiteral("</s>");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetText(23).SetUIActive(openItemInfo.GetOriginalPrice() != -1);
		base.GetItem(24).SetUIActive(openItemInfo.EndTime > 0U);
		if (openItemInfo.EndTime != 0U)
		{
			double num = openItemInfo.EndTime - Singleton<TimeUtil>.Instance.GetServerTime();
			int num2 = (int)(num / 86400.0);
			if (num2 > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(25), "ShopItemLimitTime1", new <>z__ReadOnlySingleElementList<object>(num2));
			}
			else if (num2 == 0)
			{
				int num3 = (int)(num / 3600.0);
				int num4 = (int)(num / 60.0) % 60;
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(25), "ShopItemLimitTime2", new <>z__ReadOnlyArray<object>(new object[]
				{
					num3,
					num4
				}));
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(25), "ShopItemLimitTimeOut", Array.Empty<object>());
			}
		}
		this.UpdateLockState(panelData);
		this.BuyButtonInteractGroup.SetInteractable(true);
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(panelData.ItemId));
		this.UpdateItemTips(itemDataTypeByConfigId);
	}

	// Token: 0x0601574A RID: 87882 RVA: 0x005F27C8 File Offset: 0x005F09C8
	protected int GetMaxCanBuyCount()
	{
		int num = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ShopPanelData.CurrencyId, 0) / this.ShopPanelData.SingleBuyPrice;
		if (this.ShopPanelData.BuyLimit > 0)
		{
			return Math.Min(Math.Max(0, this.ShopPanelData.BuyLimit - this.ShopPanelData.BoughtCount), num);
		}
		return num;
	}

	// Token: 0x0601574B RID: 87883 RVA: 0x005F282C File Offset: 0x005F0A2C
	protected void UpdateItemTips(InventoryDefine.EItemDataType itemType)
	{
		this.CloseUiItem();
		if (itemType == InventoryDefine.EItemDataType.WeaponItem)
		{
			this.SetWeaponTips();
			this.UpdateAttribute();
		}
		else
		{
			base.GetItem(22).SetUIActive(true);
		}
		UUIText text = base.GetText(18);
		CommonTipsData commonTipsData = this.CommonTipsData;
		if (((commonTipsData != null) ? commonTipsData.LevelText : null) != null)
		{
			text.SetUIActive(true);
			if (itemType != InventoryDefine.EItemDataType.WeaponItem)
			{
				text.SetText(this.CommonTipsData.LevelText, true);
				return;
			}
		}
		else
		{
			text.SetUIActive(false);
		}
	}

	// Token: 0x0601574C RID: 87884 RVA: 0x005F28A4 File Offset: 0x005F0AA4
	protected void CloseUiItem()
	{
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(20);
		if (verticalLayout != null)
		{
			verticalLayout.GetRootComponent().SetUIActive(false);
		}
		base.GetItem(17).SetUIActive(false);
	}

	// Token: 0x0601574D RID: 87885 RVA: 0x005F28D8 File Offset: 0x005F0AD8
	[NullableContext(1)]
	protected void UpdateLockState(ShopPanelData panelData)
	{
		bool uiactive = panelData.IsInteractive();
		base.GetItem(9).SetUIActive(uiactive);
		base.GetItem(10).SetUIActive(uiactive);
		base.GetItem(11).SetUIActive(panelData.IsLock || panelData.IsSoldOut());
		base.GetItem(12).SetUIActive(panelData.IsLock);
		base.GetItem(8).SetUIActive(false);
		if (panelData.IsLock)
		{
			if (panelData.LockText is int)
			{
				int num = (int)panelData.LockText;
				if (num > 0)
				{
					Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(13), "ShopFixed", new <>z__ReadOnlySingleElementList<object>(num));
					return;
				}
			}
			else if (panelData.LockText is string)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), (string)panelData.LockText, Array.Empty<object>());
			}
			return;
		}
		if (panelData.IsSoldOut())
		{
			base.GetItem(11).SetColor(this.soldOutColor);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(13), "ShopItemSoldOut", Array.Empty<object>());
			base.GetItem(14).SetUIActive(true);
			base.GetItem(26).SetUIActive(false);
			return;
		}
		base.GetItem(26).SetUIActive(true);
		if (panelData.BuyLimit > 0)
		{
			int num2 = Math.Max(0, panelData.BuyLimit - panelData.BoughtCount);
			base.GetItem(8).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(4), "ShopItemLimitCount", new <>z__ReadOnlyArray<object>(new object[]
			{
				num2,
				panelData.BuyLimit
			}));
		}
	}

	// Token: 0x0601574E RID: 87886 RVA: 0x005F2A84 File Offset: 0x005F0C84
	protected void SetWeaponTips()
	{
		base.GetItem(17).SetUIActive(true);
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(20);
		if (verticalLayout != null)
		{
			verticalLayout.GetRootComponent().SetUIActive(true);
		}
		WeaponTipsData weaponTipsData = this.CommonTipsData as WeaponTipsData;
		int configId = weaponTipsData.ConfigId;
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(configId);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(weaponTipsData.BgDescription, null);
		this.TipsWeaponItem.UpdateItem(weaponConfigByItemId.Value, weaponTipsData.ResonanceLevel, localTextNew);
	}

	// Token: 0x0601574F RID: 87887 RVA: 0x005F2B00 File Offset: 0x005F0D00
	private void BuyClick()
	{
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ShopPanelData.CurrencyId, 0) >= this.ShopPanelData.SingleBuyPrice * this.Count)
		{
			this.ShopPanelData.BuySuccessFunction(this.ShopPanelData.ItemId, this.BuyCount, this.ShopPanelData.CurrencyId, this.ShopPanelData.ParamData);
			return;
		}
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("ShopResourceNotEnough");
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ShopPanelData.CurrencyId);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSubmitItemFail);
		if (itemConfigData == null)
		{
			return;
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null);
		string text = StringUtils.Format(textById, new string[]
		{
			localTextNew
		});
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(text);
	}

	// Token: 0x06015750 RID: 87888 RVA: 0x005F2BD2 File Offset: 0x005F0DD2
	private void OnCurrencyNodeButtonClick()
	{
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ShopPanelData.CurrencyId, true, null);
	}

	// Token: 0x06015751 RID: 87889 RVA: 0x005F2BEB File Offset: 0x005F0DEB
	public object GetParams()
	{
		ShopPanelData shopPanelData = this.ShopPanelData;
		if (shopPanelData == null)
		{
			return null;
		}
		return shopPanelData.ParamData;
	}

	// Token: 0x0400A51B RID: 42267
	private readonly FColor soldOutColor = FColor.FromHex("FFFFFFFF");

	// Token: 0x0400A51C RID: 42268
	private readonly FColor coinNotEnoughColor = FColor.FromHex("9D2437FF");

	// Token: 0x0400A51D RID: 42269
	private const int SECONDS_PER_DAY = 86400;

	// Token: 0x0400A51E RID: 42270
	private ShopPanelData ShopPanelData;

	// Token: 0x0400A51F RID: 42271
	protected CommonTipsData CommonTipsData;

	// Token: 0x0400A520 RID: 42272
	private int Count;

	// Token: 0x0400A521 RID: 42273
	private TipsWeaponItem TipsWeaponItem;

	// Token: 0x0400A522 RID: 42274
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeVertical;

	// Token: 0x0400A523 RID: 42275
	private UUIInteractionGroup BuyButtonInteractGroup;

	// Token: 0x0400A524 RID: 42276
	private FColor? PurchaseTextOriginColor;

	// Token: 0x0400A525 RID: 42277
	private NumberSelectComponent NumberSelect;

	// Token: 0x0400A526 RID: 42278
	private int BuyCountMax;

	// Token: 0x02008D7C RID: 36220
	[NullableContext(0)]
	private enum EShopItemInfoDetailViewDefine
	{
		// Token: 0x0402F924 RID: 194852
		Name,
		// Token: 0x0402F925 RID: 194853
		Type,
		// Token: 0x0402F926 RID: 194854
		EffectDescribe,
		// Token: 0x0402F927 RID: 194855
		Describe,
		// Token: 0x0402F928 RID: 194856
		LimitCountText,
		// Token: 0x0402F929 RID: 194857
		CurrencyIcon,
		// Token: 0x0402F92A RID: 194858
		PurchaseText,
		// Token: 0x0402F92B RID: 194859
		BuyButton,
		// Token: 0x0402F92C RID: 194860
		BuyLimitItem,
		// Token: 0x0402F92D RID: 194861
		CalculatorItem,
		// Token: 0x0402F92E RID: 194862
		NumberSelectItem,
		// Token: 0x0402F92F RID: 194863
		LockItem,
		// Token: 0x0402F930 RID: 194864
		LockCondition,
		// Token: 0x0402F931 RID: 194865
		LockConditionText,
		// Token: 0x0402F932 RID: 194866
		LockLimitItem,
		// Token: 0x0402F933 RID: 194867
		CurrencyNodeButton,
		// Token: 0x0402F934 RID: 194868
		HaveText,
		// Token: 0x0402F935 RID: 194869
		WeaponItem,
		// Token: 0x0402F936 RID: 194870
		LevelText,
		// Token: 0x0402F937 RID: 194871
		StarRootItem,
		// Token: 0x0402F938 RID: 194872
		DetailVerticalLayout,
		// Token: 0x0402F939 RID: 194873
		VerticalScroll,
		// Token: 0x0402F93A RID: 194874
		DetailItem,
		// Token: 0x0402F93B RID: 194875
		OriginPriceText,
		// Token: 0x0402F93C RID: 194876
		LimitTimePanel,
		// Token: 0x0402F93D RID: 194877
		LimitTimeText,
		// Token: 0x0402F93E RID: 194878
		PanelCost,
		// Token: 0x0402F93F RID: 194879
		TextCost,
		// Token: 0x0402F940 RID: 194880
		PnlLimitedTime,
		// Token: 0x0402F941 RID: 194881
		PnlAactived
	}
}
