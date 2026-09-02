using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020029FE RID: 10750
public class ShopItem : UiPanelBase
{
	// Token: 0x06015728 RID: 87848 RVA: 0x005F1294 File Offset: 0x005EF494
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick))
		};
	}

	// Token: 0x06015729 RID: 87849 RVA: 0x005F1438 File Offset: 0x005EF638
	[NullableContext(1)]
	public void UpdateItem(ShopItemFullInfo data)
	{
		if (data == null)
		{
			return;
		}
		this.RootItem.SetAsLastHierarchy();
		this.ItemInfo = data;
		base.SetItemIcon(base.GetTexture(2), this.ItemInfo.ItemId, null, null);
		base.SetItemQualityIcon(base.GetSprite(3), this.ItemInfo.ItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		base.SetItemQualityIcon(base.GetSprite(4), this.ItemInfo.ItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(5), "ShowCount", new <>z__ReadOnlySingleElementList<object>(data.StackSize));
		ItemConfig itemInfo = this.ItemInfo.ItemInfo;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), itemInfo.Name, Array.Empty<object>());
		base.SetItemIcon(base.GetTexture(6), data.GetMoneyId(), null, null);
		if (!data.IsAffordable(1))
		{
			base.GetText(7).SetColor(this.coinNotEnoughColor);
		}
		base.GetText(7).SetText(data.GetDefaultPrice().ToString(), true);
		UUIText text = base.GetText(8);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("<s>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ItemInfo.GetOriginalPrice());
		defaultInterpolatedStringHandler.AppendLiteral("</s>");
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetText(8).SetUIActive(this.ItemInfo.GetOriginalPrice() != -1);
		this.UpdateLockState();
		this.UpdateLimitTime();
	}

	// Token: 0x0601572A RID: 87850 RVA: 0x005F15D4 File Offset: 0x005EF7D4
	protected void UpdateLockState()
	{
		bool flag = this.ItemInfo.IsInteractive();
		base.GetItem(12).SetUIActive(!flag);
		base.GetItem(11).SetAlpha((!flag) ? 0.5f : 1f);
		base.GetItem(13).SetUIActive(!this.ItemInfo.IsUnlocked());
		base.GetText(9).SetUIActive(this.ItemInfo.BuyLimit != -1);
		if (this.ItemInfo.BuyLimit != -1)
		{
			base.GetText(9).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "ShopItemLimitCount", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.ItemInfo.BuyLimit - this.ItemInfo.BoughtCount,
				this.ItemInfo.BuyLimit
			}));
		}
		if (!this.ItemInfo.IsUnlocked())
		{
			base.GetText(15).SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), this.ItemInfo.LockInfo, Array.Empty<object>());
			return;
		}
		if (this.ItemInfo.IsSoldOut())
		{
			base.GetText(15).SetColor(this.soldOutColor);
			base.GetText(15).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(15), "ShopItemSoldOut", Array.Empty<object>());
			return;
		}
		if (this.ItemInfo.IsOutOfDate())
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(15), "ShopItemTimeout", Array.Empty<object>());
			base.GetText(15).SetColor(this.red);
			base.GetText(15).SetUIActive(true);
		}
	}

	// Token: 0x0601572B RID: 87851 RVA: 0x005F1798 File Offset: 0x005EF998
	protected void UpdateLimitTime()
	{
		if (this.ItemInfo.EndTime != 0U)
		{
			double num = this.ItemInfo.EndTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			int num2 = (int)(num / 86400.0);
			if (num2 > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "ShopItemLimitTime1", new <>z__ReadOnlySingleElementList<object>(num2));
			}
			else if (num2 == 0)
			{
				int num3 = (int)(num / 3600.0);
				int num4 = (int)(num / 60.0) % 60;
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "ShopItemLimitTime2", new <>z__ReadOnlyArray<object>(new object[]
				{
					num3,
					num4
				}));
			}
		}
		base.GetText(10).SetUIActive(this.ItemInfo.InSaleTime());
	}

	// Token: 0x0601572C RID: 87852 RVA: 0x005F186F File Offset: 0x005EFA6F
	public void Tick()
	{
		this.UpdateLockState();
		this.UpdateLimitTime();
	}

	// Token: 0x0601572D RID: 87853 RVA: 0x005F187D File Offset: 0x005EFA7D
	private void ButtonClick()
	{
		ModelBase<ShopModel>.Instance.OpenItemInfo = this.ItemInfo;
		Singleton<EventSystem>.Instance.Emit(EEventName.OpenItemInfo);
	}

	// Token: 0x0400A502 RID: 42242
	private const int SECONDS_PER_DAY = 86400;

	// Token: 0x0400A503 RID: 42243
	private readonly FColor red = new FColor(byte.MaxValue, 0, 0, byte.MaxValue);

	// Token: 0x0400A504 RID: 42244
	private readonly FColor soldOutColor = FColor.FromHex("FFFFFFFF");

	// Token: 0x0400A505 RID: 42245
	private readonly FColor coinNotEnoughColor = FColor.FromHex("9D2437FF");

	// Token: 0x0400A506 RID: 42246
	[Nullable(2)]
	public ShopItemFullInfo ItemInfo;

	// Token: 0x02008D7B RID: 36219
	private enum EShopItemDefine
	{
		// Token: 0x0402F913 RID: 194835
		Button,
		// Token: 0x0402F914 RID: 194836
		Name,
		// Token: 0x0402F915 RID: 194837
		Icon,
		// Token: 0x0402F916 RID: 194838
		Quality,
		// Token: 0x0402F917 RID: 194839
		Quality2,
		// Token: 0x0402F918 RID: 194840
		Count,
		// Token: 0x0402F919 RID: 194841
		CurrencyIcon,
		// Token: 0x0402F91A RID: 194842
		PriceText,
		// Token: 0x0402F91B RID: 194843
		OriginalPriceText,
		// Token: 0x0402F91C RID: 194844
		PurchaseLimitText,
		// Token: 0x0402F91D RID: 194845
		LimitTimeText,
		// Token: 0x0402F91E RID: 194846
		UnLockItem,
		// Token: 0x0402F91F RID: 194847
		LockItem,
		// Token: 0x0402F920 RID: 194848
		LockConditionItem,
		// Token: 0x0402F921 RID: 194849
		LockConditionText,
		// Token: 0x0402F922 RID: 194850
		LockLimitText
	}
}
