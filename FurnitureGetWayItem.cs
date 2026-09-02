using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200108F RID: 4239
[NullableContext(2)]
[Nullable(0)]
public class FurnitureGetWayItem : UiPanelBase
{
	// Token: 0x06006E87 RID: 28295 RVA: 0x001CC7EC File Offset: 0x001CA9EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickConfirmButton))
		};
	}

	// Token: 0x06006E88 RID: 28296 RVA: 0x001CC904 File Offset: 0x001CAB04
	protected override UniTask OnBeforeStartAsync()
	{
		FurnitureGetWayItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurnitureGetWayItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006E89 RID: 28297 RVA: 0x001CC947 File Offset: 0x001CAB47
	[NullableContext(1)]
	public void Refresh(IFurnitureGetWayViewData data)
	{
		this.Data = data;
		this.UpdateItemsVisible();
		this.RefreshFurnitureInfo();
		this.RefreshOccupiedItem();
		this.RefreshShopItem();
		this.RefreshGiftItem();
		this.RefreshAtmosphereItem();
	}

	// Token: 0x06006E8A RID: 28298 RVA: 0x001CC974 File Offset: 0x001CAB74
	public void UpdateItemsVisible()
	{
		IFurnitureGetWayViewData data = this.Data;
		bool flag = data != null && data.LockReason == EFurnitureLockReason.Occupied;
		IFurnitureGetWayViewData data2 = this.Data;
		bool flag2 = data2 != null && data2.LockReason == EFurnitureLockReason.Shop;
		IFurnitureGetWayViewData data3 = this.Data;
		bool flag3 = data3 != null && data3.LockReason == EFurnitureLockReason.Gift;
		IFurnitureGetWayViewData data4 = this.Data;
		bool flag4 = ((data4 != null) ? data4.ConfirmFunction : null) != null;
		IFurnitureGetWayViewData data5 = this.Data;
		bool flag5 = ((data5 != null) ? data5.JumpFunction : null) != null;
		IFurnitureGetWayViewData data6 = this.Data;
		string text = (data6 != null) ? data6.LockReasonTextId : null;
		bool flag6 = text != null && !StringUtils.IsEmpty(text);
		FurnitureGetWayButtonItem occupiedItem = this.OccupiedItem;
		if (occupiedItem != null)
		{
			occupiedItem.SetUiActive(flag);
		}
		FurnitureGetWayButtonItem shopItem = this.ShopItem;
		if (shopItem != null)
		{
			shopItem.SetUiActive(flag2 && flag5 && !flag6);
		}
		FurnitureGetWayButtonItem giftItem = this.GiftItem;
		if (giftItem != null)
		{
			giftItem.SetUiActive(flag3 && flag5 && !flag6);
		}
		UUIButtonComponent button = base.GetButton(7);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag && flag4);
		}
		UUIItem item = base.GetItem(8);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(!flag && flag6);
	}

	// Token: 0x06006E8B RID: 28299 RVA: 0x001CCAA4 File Offset: 0x001CACA4
	public void RefreshFurnitureInfo()
	{
		IFurnitureGetWayViewData data = this.Data;
		string path = ((data != null) ? data.FurnitureConfig.IconBig : null) ?? "";
		base.SetTextureShowUntilLoaded(path, base.GetTexture(0), null);
		LguiUtil instance = Singleton<LguiUtil>.Instance;
		UUIText text = base.GetText(2);
		IFurnitureGetWayViewData data2 = this.Data;
		instance.SetLocalTextNew(text, ((data2 != null) ? data2.FurnitureConfig.Name : null) ?? "", Array.Empty<object>());
		LguiUtil instance2 = Singleton<LguiUtil>.Instance;
		UUIText text2 = base.GetText(3);
		IFurnitureGetWayViewData data3 = this.Data;
		instance2.SetLocalTextNew(text2, ((data3 != null) ? data3.FurnitureConfig.AttributesDescription : null) ?? "", Array.Empty<object>());
	}

	// Token: 0x06006E8C RID: 28300 RVA: 0x001CCB58 File Offset: 0x001CAD58
	public void RefreshOccupiedItem()
	{
		IFurnitureGetWayViewData data = this.Data;
		if (data == null || data.LockReason != EFurnitureLockReason.Occupied)
		{
			return;
		}
		FurnitureGetWayButtonItem occupiedItem = this.OccupiedItem;
		if (occupiedItem == null)
		{
			return;
		}
		occupiedItem.Refresh(new FurnitureGetWayButtonItemData
		{
			NameTextId = this.Data.LockReasonTextId,
			NameTextParams = this.Data.LockReasonTextParams,
			JumpFunction = this.Data.JumpFunction
		});
	}

	// Token: 0x06006E8D RID: 28301 RVA: 0x001CCBC8 File Offset: 0x001CADC8
	public void RefreshShopItem()
	{
		IFurnitureGetWayViewData data = this.Data;
		if (data == null || data.LockReason != EFurnitureLockReason.Shop)
		{
			return;
		}
		if (this.Data.JumpFunction == null)
		{
			this.RefreshLockReasonText();
			return;
		}
		FurnitureGetWayButtonItem shopItem = this.ShopItem;
		if (shopItem == null)
		{
			return;
		}
		shopItem.Refresh(new FurnitureGetWayButtonItemData
		{
			JumpFunction = this.Data.JumpFunction
		});
	}

	// Token: 0x06006E8E RID: 28302 RVA: 0x001CCC2C File Offset: 0x001CAE2C
	public void RefreshGiftItem()
	{
		IFurnitureGetWayViewData data = this.Data;
		if (data == null || data.LockReason != EFurnitureLockReason.Gift)
		{
			return;
		}
		if (this.Data.JumpFunction == null)
		{
			this.RefreshLockReasonText();
			return;
		}
		FurnitureGetWayButtonItem giftItem = this.GiftItem;
		if (giftItem == null)
		{
			return;
		}
		giftItem.Refresh(new FurnitureGetWayButtonItemData
		{
			JumpFunction = this.Data.JumpFunction
		});
	}

	// Token: 0x06006E8F RID: 28303 RVA: 0x001CCC8E File Offset: 0x001CAE8E
	public void RefreshAtmosphereItem()
	{
		IFurnitureGetWayViewData data = this.Data;
		if (data == null || data.LockReason != EFurnitureLockReason.Atmosphere)
		{
			return;
		}
		this.RefreshLockReasonText();
	}

	// Token: 0x06006E90 RID: 28304 RVA: 0x001CCCB4 File Offset: 0x001CAEB4
	private void RefreshLockReasonText()
	{
		IFurnitureGetWayViewData data = this.Data;
		if (((data != null) ? data.LockReasonTextId : null) == null)
		{
			return;
		}
		if (this.Data.LockReasonTextParams != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), this.Data.LockReasonTextId, this.Data.LockReasonTextParams);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), this.Data.LockReasonTextId, Array.Empty<object>());
	}

	// Token: 0x06006E91 RID: 28305 RVA: 0x001CCD2E File Offset: 0x001CAF2E
	private void OnClickConfirmButton()
	{
		IFurnitureGetWayViewData data = this.Data;
		if (data == null)
		{
			return;
		}
		Action confirmFunction = data.ConfirmFunction;
		if (confirmFunction == null)
		{
			return;
		}
		confirmFunction();
	}

	// Token: 0x040034BA RID: 13498
	private IFurnitureGetWayViewData Data;

	// Token: 0x040034BB RID: 13499
	private FurnitureGetWayButtonItem OccupiedItem;

	// Token: 0x040034BC RID: 13500
	private FurnitureGetWayButtonItem ShopItem;

	// Token: 0x040034BD RID: 13501
	private FurnitureGetWayButtonItem GiftItem;
}
