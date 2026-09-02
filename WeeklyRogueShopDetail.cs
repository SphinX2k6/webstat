using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D3C RID: 11580
public class WeeklyRogueShopDetail : UiPanelBase
{
	// Token: 0x060175CD RID: 95693 RVA: 0x0067A3CC File Offset: 0x006785CC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(13, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnBtnConfirm))
		};
	}

	// Token: 0x060175CE RID: 95694 RVA: 0x0067A540 File Offset: 0x00678740
	protected override void OnStart()
	{
		this.TagLayout = new GenericLayout<WeeklyRogueTagItem, int>(base.GetHorizontalLayout(12), new Func<WeeklyRogueTagItem>(this.OnCreateTagItem), null, false, true);
	}

	// Token: 0x060175CF RID: 95695 RVA: 0x0067A564 File Offset: 0x00678764
	[NullableContext(1)]
	public void Refresh(RogueWeeklyEntry data)
	{
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(data.ConfigId);
		if (rogueWeeklyBuffPool == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), rogueWeeklyBuffPool.Value.BuffName, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueWeeklyBuffPool.Value.BuffDesc, rogueWeeklyBuffPool.Value.BuffDescParam());
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText text = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
		defaultInterpolatedStringHandler.AppendLiteral("WeeklyRoguelikeShopItemType");
		defaultInterpolatedStringHandler.AppendFormatted<int>((int)data.Type);
		instance.SetLocalTextNew(text, defaultInterpolatedStringHandler.ToStringAndClear(), Array.Empty<object>());
		RogueWeeklyGoods rogueWeeklyGoods = data.RogueWeeklyGoods;
		bool flag = rogueWeeklyGoods.CurPrice != rogueWeeklyGoods.SourcePrice;
		int num = flag ? rogueWeeklyGoods.CurPrice : rogueWeeklyGoods.SourcePrice;
		RogueCurrency? rogueCurrencyConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCurrencyConfig(80100000);
		int currency = ModelBase<WeeklyRogueModel>.Instance.GetCurrency(80100000);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "RogueShopOriginPriceDiscount", new <>z__ReadOnlySingleElementList<object>(rogueWeeklyGoods.SourcePrice.ToString()));
		}
		else
		{
			UUIText text2 = base.GetText(10);
			if (text2 != null)
			{
				text2.SetText("", true);
			}
		}
		UUIText text3 = base.GetText(9);
		if (text3 != null)
		{
			text3.SetText(num.ToString(), true);
			text3.useChangeColor = (currency < num);
		}
		base.SetTextureByPath(((rogueCurrencyConfig != null) ? rogueCurrencyConfig.GetValueOrDefault().IconSmall : null) ?? string.Empty, base.GetTexture(8), null, null);
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(!rogueWeeklyGoods.IsSell);
		}
		UUIButtonComponent button = base.GetButton(7);
		if (button != null)
		{
			button.SetSelfInteractive(true);
		}
		UUIButtonComponent button2 = base.GetButton(7);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(!rogueWeeklyGoods.IsSell);
		}
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(11);
		if (horizontalLayout != null)
		{
			horizontalLayout.RootUIComp.Get().SetUIActive(false);
		}
		List<int> rogueWeeklyBuffTagIdList = ModelBase<WeeklyRogueModel>.Instance.GetRogueWeeklyBuffTagIdList(data.ConfigId);
		this.TagLayout.SetActive(rogueWeeklyBuffTagIdList.Count > 0);
		if (rogueWeeklyBuffTagIdList.Count > 0)
		{
			this.TagLayout.RefreshByData(rogueWeeklyBuffTagIdList, null, false);
		}
	}

	// Token: 0x060175D0 RID: 95696 RVA: 0x0067A7D7 File Offset: 0x006789D7
	private void OnBtnConfirm()
	{
		UUIButtonComponent button = base.GetButton(7);
		if (button != null)
		{
			button.SetSelfInteractive(false);
		}
		ControllerBase<WeeklyRogueController>.Instance.SelectOptionRequest(delegate(bool success)
		{
			UUIButtonComponent button2 = base.GetButton(7);
			if (button2 != null)
			{
				button2.SetSelfInteractive(true);
			}
			if (success)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("WeRogueStorePurchaseSuccessText", Array.Empty<object>());
			}
		});
	}

	// Token: 0x060175D1 RID: 95697 RVA: 0x0067A802 File Offset: 0x00678A02
	[NullableContext(1)]
	private WeeklyRogueTagItem OnCreateTagItem()
	{
		return new WeeklyRogueTagItem();
	}

	// Token: 0x0400B369 RID: 45929
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<WeeklyRogueTagItem, int> TagLayout;

	// Token: 0x02008FFF RID: 36863
	private enum EWeeklyRogueShopDetailDefine
	{
		// Token: 0x040304FE RID: 197886
		TxtName,
		// Token: 0x040304FF RID: 197887
		TxtHave,
		// Token: 0x04030500 RID: 197888
		TxtType,
		// Token: 0x04030501 RID: 197889
		TxtDesc,
		// Token: 0x04030502 RID: 197890
		PanelAttr,
		// Token: 0x04030503 RID: 197891
		AttrItem,
		// Token: 0x04030504 RID: 197892
		PanelCost,
		// Token: 0x04030505 RID: 197893
		BtnConfirm,
		// Token: 0x04030506 RID: 197894
		TextureCurrencyIcon,
		// Token: 0x04030507 RID: 197895
		TxtCurrencyCurPrice,
		// Token: 0x04030508 RID: 197896
		TxtCurrencyOriginPrice,
		// Token: 0x04030509 RID: 197897
		ElementLayout,
		// Token: 0x0403050A RID: 197898
		TagLayout,
		// Token: 0x0403050B RID: 197899
		TagItem
	}
}
