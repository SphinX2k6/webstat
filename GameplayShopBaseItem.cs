using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023A0 RID: 9120
public class GameplayShopBaseItem : UiPanelBase
{
	// Token: 0x06011918 RID: 71960 RVA: 0x004D12F0 File Offset: 0x004CF4F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnTipsButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011919 RID: 71961 RVA: 0x004D1528 File Offset: 0x004CF728
	[NullableContext(1)]
	public void RefreshByData(IGameplayShopItemBaseProxy data)
	{
		this.BaseItemProxy = data;
		this.RefreshQualitySprite();
		this.RefreshBottomBgSprite();
		this.RefreshItemTexture();
		this.RefreshTipsButton();
		this.RefreshBuyLimitCountTextText();
		this.RefreshNameText();
		this.RefreshPriceItem();
		this.RefreshPriceTipsText();
		this.RefreshRedDot();
		this.RefreshBigItemIconTexture();
		this.RefreshNormalItemBg();
		this.RefreshRaycastTarget();
	}

	// Token: 0x0601191A RID: 71962 RVA: 0x004D1584 File Offset: 0x004CF784
	public void RefreshQualitySprite()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		this.SetSpriteByPath(this.BaseItemProxy.QualitySpritePath, base.GetSprite(0), false, null, null);
	}

	// Token: 0x0601191B RID: 71963 RVA: 0x004D15BD File Offset: 0x004CF7BD
	public void RefreshBottomBgSprite()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		base.GetSprite(1).SetUIActive(this.BaseItemProxy.BottomBgVisible);
	}

	// Token: 0x0601191C RID: 71964 RVA: 0x004D15E0 File Offset: 0x004CF7E0
	public void RefreshItemTexture()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		UUITexture texture = base.GetTexture(2);
		texture.SetUIActive(this.BaseItemProxy.ItemTextureVisible);
		if (this.BaseItemProxy.ItemTextureVisible)
		{
			if (this.BaseItemProxy.ItemId > 0)
			{
				base.SetItemIcon(texture, this.BaseItemProxy.ItemId, null, null);
				return;
			}
			base.SetTextureByPath(this.BaseItemProxy.ItemTexturePath, texture, null, null);
		}
	}

	// Token: 0x0601191D RID: 71965 RVA: 0x004D1664 File Offset: 0x004CF864
	public void RefreshTipsButton()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		base.GetButton(3).RootUIComp.Get().SetUIActive(this.BaseItemProxy.TipsButtonVisible);
	}

	// Token: 0x0601191E RID: 71966 RVA: 0x004D16A0 File Offset: 0x004CF8A0
	public void RefreshBuyLimitCountTextText()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		UUIText text = base.GetText(4);
		text.SetUIActive(this.BaseItemProxy.BuyLimitCountTextVisible);
		if (this.BaseItemProxy.BuyLimitCountTextVisible)
		{
			GameplayShopUtil.SetText(text, this.BaseItemProxy.BuyLimitCountTextData);
		}
	}

	// Token: 0x0601191F RID: 71967 RVA: 0x004D16ED File Offset: 0x004CF8ED
	public void RefreshNameText()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		GameplayShopUtil.SetText(base.GetText(5), this.BaseItemProxy.ItemNameTextData);
	}

	// Token: 0x06011920 RID: 71968 RVA: 0x004D1710 File Offset: 0x004CF910
	public void RefreshPriceItem()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		base.GetItem(6).SetUIActive(this.BaseItemProxy.PriceItemVisible);
		if (this.BaseItemProxy.PriceItemVisible)
		{
			UUITexture texture = base.GetTexture(7);
			texture.SetUIActive(this.BaseItemProxy.CurrencyIconVisible);
			if (this.BaseItemProxy.CurrencyIconVisible)
			{
				base.SetItemIcon(texture, this.BaseItemProxy.CurrencyId, null, null);
			}
			UUIText text = base.GetText(8);
			GameplayShopUtil.SetText(text, this.BaseItemProxy.NowPriceTextData);
			text.SetColor(FColor.FromHex(this.BaseItemProxy.NowPriceTextColor));
			UUIText text2 = base.GetText(9);
			text2.SetUIActive(this.BaseItemProxy.OriginalPriceVisible);
			if (this.BaseItemProxy.OriginalPriceVisible)
			{
				GameplayShopUtil.SetText(text2, this.BaseItemProxy.OriginalPriceTextData);
			}
		}
	}

	// Token: 0x06011921 RID: 71969 RVA: 0x004D17F4 File Offset: 0x004CF9F4
	public void RefreshPriceTipsText()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		UUIText text = base.GetText(10);
		text.SetUIActive(this.BaseItemProxy.PriceTipsTextVisible);
		if (this.BaseItemProxy.PriceTipsTextVisible)
		{
			GameplayShopUtil.SetText(text, this.BaseItemProxy.PriceTipsTextData);
		}
	}

	// Token: 0x06011922 RID: 71970 RVA: 0x004D1842 File Offset: 0x004CFA42
	public void RefreshRedDot()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		base.GetItem(11).SetUIActive(this.BaseItemProxy.RedDotVisible);
	}

	// Token: 0x06011923 RID: 71971 RVA: 0x004D1868 File Offset: 0x004CFA68
	public void RefreshBigItemIconTexture()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		UUITexture texture = base.GetTexture(12);
		texture.SetUIActive(this.BaseItemProxy.BigItemIconVisible);
		if (this.BaseItemProxy.BigItemIconVisible)
		{
			base.SetTextureByPath(this.BaseItemProxy.BigItemIconTexturePath, texture, null, null);
		}
	}

	// Token: 0x06011924 RID: 71972 RVA: 0x004D18C1 File Offset: 0x004CFAC1
	public void RefreshNormalItemBg()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		base.GetItem(13).SetUIActive(this.BaseItemProxy.ItemBgItemVisible);
	}

	// Token: 0x06011925 RID: 71973 RVA: 0x004D18E4 File Offset: 0x004CFAE4
	public void RefreshRaycastTarget()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		this.RootItem.SetRaycastTarget(this.BaseItemProxy.RaycastTarget);
	}

	// Token: 0x06011926 RID: 71974 RVA: 0x004D1905 File Offset: 0x004CFB05
	private void OnTipsButtonClick()
	{
		if (this.BaseItemProxy == null)
		{
			return;
		}
		this.BaseItemProxy.OnTipsButtonClick();
	}

	// Token: 0x04008989 RID: 35209
	[Nullable(2)]
	protected IGameplayShopItemBaseProxy BaseItemProxy;

	// Token: 0x020086B5 RID: 34485
	private enum EComponent
	{
		// Token: 0x0402D8FB RID: 186619
		QualitySprite,
		// Token: 0x0402D8FC RID: 186620
		BottomBgSprite,
		// Token: 0x0402D8FD RID: 186621
		ItemTexture,
		// Token: 0x0402D8FE RID: 186622
		TipsButton,
		// Token: 0x0402D8FF RID: 186623
		BuyLimitCountText,
		// Token: 0x0402D900 RID: 186624
		NameText,
		// Token: 0x0402D901 RID: 186625
		PriceItem,
		// Token: 0x0402D902 RID: 186626
		CurrencyIcon,
		// Token: 0x0402D903 RID: 186627
		NowPriceText,
		// Token: 0x0402D904 RID: 186628
		OriginalPriceText,
		// Token: 0x0402D905 RID: 186629
		PriceTipsText,
		// Token: 0x0402D906 RID: 186630
		RedDot,
		// Token: 0x0402D907 RID: 186631
		BigItemIconTexture,
		// Token: 0x0402D908 RID: 186632
		NormalItemBg
	}
}
