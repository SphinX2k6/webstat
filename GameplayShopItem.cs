using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023A2 RID: 9122
public class GameplayShopItem : UiPanelBase
{
	// Token: 0x06011934 RID: 71988 RVA: 0x004D1978 File Offset: 0x004CFB78
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
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
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnBuyButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011935 RID: 71989 RVA: 0x004D1C38 File Offset: 0x004CFE38
	protected override void OnStart()
	{
		this.BaseItem = new GameplayShopBaseItem();
		this.BaseItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
	}

	// Token: 0x06011936 RID: 71990 RVA: 0x004D1C5D File Offset: 0x004CFE5D
	[NullableContext(1)]
	public void RefreshByData(IGameplayShopItemProxy data)
	{
		this.ItemProxy = data;
		this.RefreshBaseItem();
		this.RefreshDiscountItem();
		this.RefreshLabelItem();
		this.RefreshLeftTimeItem();
		this.RefreshReSellText();
		this.RefreshSoldOutItem();
		this.RefreshLockItem();
		this.RefreshNewFlagItem();
		this.RefreshRaycastTarget();
	}

	// Token: 0x06011937 RID: 71991 RVA: 0x004D1C9C File Offset: 0x004CFE9C
	public void RefreshBaseItem()
	{
		if (this.ItemProxy == null || this.BaseItem == null)
		{
			return;
		}
		this.BaseItem.RefreshByData(this.ItemProxy);
	}

	// Token: 0x06011938 RID: 71992 RVA: 0x004D1CC0 File Offset: 0x004CFEC0
	public void RefreshDiscountItem()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		base.GetItem(1).SetUIActive(this.ItemProxy.DiscountItemVisible);
		if (this.ItemProxy.DiscountItemVisible)
		{
			GameplayShopUtil.SetText(base.GetText(2), this.ItemProxy.DiscountTextData);
		}
	}

	// Token: 0x06011939 RID: 71993 RVA: 0x004D1D14 File Offset: 0x004CFF14
	public void RefreshLabelItem()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		base.GetItem(4).SetUIActive(this.ItemProxy.LabelVisible);
		if (this.ItemProxy.LabelVisible)
		{
			GameplayShopUtil.SetText(base.GetText(11), this.ItemProxy.LabelTextData);
		}
	}

	// Token: 0x0601193A RID: 71994 RVA: 0x004D1D68 File Offset: 0x004CFF68
	public void RefreshLeftTimeItem()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		base.GetItem(5).SetUIActive(this.ItemProxy.LeftTimeItemVisible);
		if (this.ItemProxy.LeftTimeItemVisible)
		{
			GameplayShopUtil.SetText(base.GetText(6), this.ItemProxy.LeftTimeTextData);
		}
	}

	// Token: 0x0601193B RID: 71995 RVA: 0x004D1DBC File Offset: 0x004CFFBC
	public void RefreshReSellText()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		UUIText text = base.GetText(7);
		text.SetUIActive(this.ItemProxy.ReSellItemVisible);
		if (this.ItemProxy.ReSellItemVisible)
		{
			GameplayShopUtil.SetText(text, this.ItemProxy.ReSellTextData);
		}
	}

	// Token: 0x0601193C RID: 71996 RVA: 0x004D1E0C File Offset: 0x004D000C
	public void RefreshSoldOutItem()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		base.GetItem(13).SetUIActive(this.ItemProxy.SoldOutItemVisible);
		if (this.ItemProxy.SoldOutItemVisible)
		{
			GameplayShopUtil.SetText(base.GetText(14), this.ItemProxy.SoldOutTextData);
		}
	}

	// Token: 0x0601193D RID: 71997 RVA: 0x004D1E60 File Offset: 0x004D0060
	public void RefreshLockItem()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		base.GetItem(15).SetUIActive(this.ItemProxy.LockItemVisible);
		if (this.ItemProxy.LockItemVisible)
		{
			GameplayShopUtil.SetText(base.GetText(16), this.ItemProxy.LockTextData);
		}
	}

	// Token: 0x0601193E RID: 71998 RVA: 0x004D1EB3 File Offset: 0x004D00B3
	public void RefreshNewFlagItem()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		base.GetItem(17).SetUIActive(this.ItemProxy.TagNewItemVisible);
	}

	// Token: 0x0601193F RID: 71999 RVA: 0x004D1ED6 File Offset: 0x004D00D6
	public void RefreshRaycastTarget()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		this.RootItem.SetRaycastTarget(this.ItemProxy.RaycastTarget);
	}

	// Token: 0x06011940 RID: 72000 RVA: 0x004D1EF7 File Offset: 0x004D00F7
	private void OnBuyButtonClick()
	{
		if (this.ItemProxy == null)
		{
			return;
		}
		this.ItemProxy.OnBuyButtonClick();
	}

	// Token: 0x0400898D RID: 35213
	[Nullable(2)]
	protected IGameplayShopItemProxy ItemProxy;

	// Token: 0x0400898E RID: 35214
	[Nullable(2)]
	protected GameplayShopBaseItem BaseItem;

	// Token: 0x020086B6 RID: 34486
	private enum EComponent
	{
		// Token: 0x0402D90A RID: 186634
		BaseItem,
		// Token: 0x0402D90B RID: 186635
		DiscountItem,
		// Token: 0x0402D90C RID: 186636
		DiscountText,
		// Token: 0x0402D90D RID: 186637
		LabelSprite,
		// Token: 0x0402D90E RID: 186638
		LabelItem,
		// Token: 0x0402D90F RID: 186639
		LeftTimeItem,
		// Token: 0x0402D910 RID: 186640
		LeftTimeText,
		// Token: 0x0402D911 RID: 186641
		ReSellText,
		// Token: 0x0402D912 RID: 186642
		BuyButton,
		// Token: 0x0402D913 RID: 186643
		ReUpTimeItem,
		// Token: 0x0402D914 RID: 186644
		ReUpTimeText,
		// Token: 0x0402D915 RID: 186645
		LabelText,
		// Token: 0x0402D916 RID: 186646
		LeftTopItem,
		// Token: 0x0402D917 RID: 186647
		SoldOutItem,
		// Token: 0x0402D918 RID: 186648
		SoldOutText,
		// Token: 0x0402D919 RID: 186649
		LockItem,
		// Token: 0x0402D91A RID: 186650
		LockText,
		// Token: 0x0402D91B RID: 186651
		NewFlagItem
	}
}
