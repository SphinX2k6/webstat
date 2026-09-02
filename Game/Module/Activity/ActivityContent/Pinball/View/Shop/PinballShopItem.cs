using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Shop
{
	// Token: 0x020065B0 RID: 26032
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballShopItem : UiPanelBase
	{
		// Token: 0x060410B3 RID: 266419 RVA: 0x010B051C File Offset: 0x010AE71C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickItemBase));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060410B4 RID: 266420 RVA: 0x010B0754 File Offset: 0x010AE954
		protected override void OnStart()
		{
			this.ItemBase = new PinballItemView();
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				AActor owner = extendToggle.GetOwner();
				if (owner != null)
				{
					this.InitItemBaseAsync(owner).Forget();
				}
				extendToggle.bToggleOnSelect = false;
				extendToggle.bCheckToggleSelected = false;
				extendToggle.OnPointEnterCallBack.Bind(new Action<EToggleState>(this.OnPointerEnterItem));
				extendToggle.OnPointExitCallBack.Bind(new Action<EToggleState>(this.OnPointerExitItem));
			}
		}

		// Token: 0x060410B5 RID: 266421 RVA: 0x010B07CC File Offset: 0x010AE9CC
		private UniTask InitItemBaseAsync(AActor owner)
		{
			PinballShopItem.<InitItemBaseAsync>d__8 <InitItemBaseAsync>d__;
			<InitItemBaseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitItemBaseAsync>d__.<>4__this = this;
			<InitItemBaseAsync>d__.owner = owner;
			<InitItemBaseAsync>d__.<>1__state = -1;
			<InitItemBaseAsync>d__.<>t__builder.Start<PinballShopItem.<InitItemBaseAsync>d__8>(ref <InitItemBaseAsync>d__);
			return <InitItemBaseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060410B6 RID: 266422 RVA: 0x010B0817 File Offset: 0x010AEA17
		protected override void OnBeforeDestroy()
		{
			this.PendingBaseProxy = null;
			this.IsItemBaseReady = false;
		}

		// Token: 0x060410B7 RID: 266423 RVA: 0x010B0828 File Offset: 0x010AEA28
		private void OnPointerEnterItem(EToggleState state)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
		}

		// Token: 0x060410B8 RID: 266424 RVA: 0x010B084C File Offset: 0x010AEA4C
		private void OnPointerExitItem(EToggleState state)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x060410B9 RID: 266425 RVA: 0x010B0870 File Offset: 0x010AEA70
		private void OnClickItemBase(EToggleState state)
		{
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			if (itemProxy == null || !itemProxy.RaycastTarget)
			{
				return;
			}
			PayShopGoods goodsData = this.ItemProxy.GoodsData;
			if (goodsData != null)
			{
				int goodsId = goodsData.GetGoodsId();
				if (goodsId > 0 && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, goodsId))
				{
					ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.PayShopTabItemChecked, goodsId);
					ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.PayShopTabItemChecked);
					PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
					int num = (activityData != null) ? activityData.Id : 0;
					if (num > 0)
					{
						Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, num);
					}
					this.TryRefreshItemBase();
				}
			}
			this.ItemProxy.OnBuyButtonClick();
		}

		// Token: 0x060410BA RID: 266426 RVA: 0x010B0916 File Offset: 0x010AEB16
		public void RefreshByData(PinballExchangeShopItemProxy data)
		{
			this.RefreshByDataInternal(data);
		}

		// Token: 0x060410BB RID: 266427 RVA: 0x010B091F File Offset: 0x010AEB1F
		public void RefreshByData(PinballShopItemProxy data)
		{
			this.RefreshByDataInternal(data);
		}

		// Token: 0x060410BC RID: 266428 RVA: 0x010B0928 File Offset: 0x010AEB28
		private void RefreshByDataInternal(CommonGameplayShopItemProxy data)
		{
			this.ItemProxy = data;
			if (data != null)
			{
				this.PendingBaseProxy = data;
				this.TryRefreshItemBase();
				this.RefreshQualitySprite();
				this.RefreshUtilityColor();
				this.RefreshItemCost();
				this.RefreshItemIcon();
				this.RefreshPriceInfo();
				this.RefreshTips();
				this.RefreshLockState();
				this.RefreshSoldOutState();
				this.RefreshPurchaseLimit();
				this.RefreshDiscount();
			}
		}

		// Token: 0x060410BD RID: 266429 RVA: 0x010B0988 File Offset: 0x010AEB88
		private void TryRefreshItemBase()
		{
			if (!this.IsItemBaseReady || this.ItemBase == null || this.PendingBaseProxy == null)
			{
				return;
			}
			this.ItemBase.RefreshByShopData(this.PendingBaseProxy);
		}

		// Token: 0x060410BE RID: 266430 RVA: 0x010B09B4 File Offset: 0x010AEBB4
		public void RefreshQualitySprite()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(0);
			PayShopGoods goodsData = this.ItemProxy.GoodsData;
			int? num;
			if (goodsData == null)
			{
				num = null;
			}
			else
			{
				CSharpScript.Game.Module.PayShop.IItemData itemData = goodsData.GetItemData();
				num = ((itemData != null) ? new int?(itemData.Quality) : null);
			}
			int? num2 = num;
			if (num2 != null)
			{
				int? num3 = num2;
				int num4 = 0;
				if (!(num3.GetValueOrDefault() == num4 & num3 != null))
				{
					string hexStr;
					if (PinballShopItem.QualityUtilityColorMap.TryGetValue(num2.Value, out hexStr))
					{
						sprite.SetColor(FColor.FromHex(hexStr));
					}
					return;
				}
			}
		}

		// Token: 0x060410BF RID: 266431 RVA: 0x010B0A50 File Offset: 0x010AEC50
		public void RefreshUtilityColor()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(13);
			if (sprite == null)
			{
				return;
			}
			PayShopGoods goodsData = this.ItemProxy.GoodsData;
			int? num;
			if (goodsData == null)
			{
				num = null;
			}
			else
			{
				CSharpScript.Game.Module.PayShop.IItemData itemData = goodsData.GetItemData();
				num = ((itemData != null) ? new int?(itemData.Quality) : null);
			}
			int? num2 = num;
			if (num2 != null)
			{
				int? num3 = num2;
				int num4 = 0;
				if (!(num3.GetValueOrDefault() == num4 & num3 != null))
				{
					string hexStr;
					if (PinballShopItem.QualityUtilityColorMap.TryGetValue(num2.Value, out hexStr))
					{
						sprite.SetColor(FColor.FromHex(hexStr));
					}
					return;
				}
			}
		}

		// Token: 0x060410C0 RID: 266432 RVA: 0x010B0AF1 File Offset: 0x010AECF1
		public void RefreshItemCost()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			base.GetItem(2).SetUIActive(true);
		}

		// Token: 0x060410C1 RID: 266433 RVA: 0x010B0B0C File Offset: 0x010AED0C
		public void HideItemCost()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}

		// Token: 0x060410C2 RID: 266434 RVA: 0x010B0B2C File Offset: 0x010AED2C
		public void SetItemFrameVisible(bool visible)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle != null)
			{
				extendToggle.SetSelfInteractive(visible);
				if (!visible)
				{
					extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
					extendToggle.SetSelectionState(EUISelectableSelectionState.Normal);
				}
			}
		}

		// Token: 0x060410C3 RID: 266435 RVA: 0x010B0B60 File Offset: 0x010AED60
		public void RefreshItemIcon()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(3);
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			if (itemProxy.CurrencyId > 0)
			{
				base.SetItemIcon(texture, itemProxy.CurrencyId, null, null);
			}
		}

		// Token: 0x060410C4 RID: 266436 RVA: 0x010B0BA8 File Offset: 0x010AEDA8
		public void RefreshPriceInfo()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			UUIText text = base.GetText(4);
			GameplayShopUtil.SetText(text, itemProxy.NowPriceTextData);
			PayShopGoods goodsData = itemProxy.GoodsData;
			IPriceData priceData = (goodsData != null) ? goodsData.GetPriceData() : null;
			bool flag = priceData != null && priceData.OwnNumber() < priceData.NowPrice;
			FColor changeColor = text.changeColor;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(changeColor);
			text.SetChangeColor(bUseChangeColor, fcolor);
			UUIText text2 = base.GetText(5);
			if (itemProxy.OriginalPriceTextData != null)
			{
				GameplayShopUtil.SetText(text2, itemProxy.OriginalPriceTextData);
				text2.SetUIActive(itemProxy.OriginalPriceVisible);
			}
		}

		// Token: 0x060410C5 RID: 266437 RVA: 0x010B0C48 File Offset: 0x010AEE48
		public void RefreshSoldOutState()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUIItem item = base.GetItem(6);
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			item.SetUIActive(itemProxy.SoldOutItemVisible);
			if (itemProxy.SoldOutItemVisible && itemProxy.SoldOutTextData != null)
			{
				UUIText soldOutLabelText = this.GetSoldOutLabelText(item);
				if (soldOutLabelText != null)
				{
					GameplayShopUtil.SetText(soldOutLabelText, itemProxy.SoldOutTextData);
				}
			}
		}

		// Token: 0x060410C6 RID: 266438 RVA: 0x010B0CA0 File Offset: 0x010AEEA0
		[return: Nullable(2)]
		private UUIText GetSoldOutLabelText(UUIItem soldOutPanel)
		{
			AActor owner = soldOutPanel.GetOwner();
			if (owner != null)
			{
				UUIText uuitext = owner.GetComponentByClass(UUIText.StaticClass()) as UUIText;
				if (uuitext != null)
				{
					return uuitext;
				}
			}
			return this.FindTextInChildren(soldOutPanel);
		}

		// Token: 0x060410C7 RID: 266439 RVA: 0x010B0CDC File Offset: 0x010AEEDC
		[return: Nullable(2)]
		private UUIText FindTextInChildren(UUIItem ui)
		{
			int num = ui.GetAttachUIChildren().Num();
			for (int i = 0; i < num; i++)
			{
				UUIItem attachUIChild = ui.GetAttachUIChild(i);
				if (attachUIChild != null)
				{
					AActor owner = attachUIChild.GetOwner();
					UUIText uuitext = ((owner != null) ? owner.GetComponentByClass(UUIText.StaticClass()) : null) as UUIText;
					if (uuitext != null)
					{
						return uuitext;
					}
					UUIText uuitext2 = this.FindTextInChildren(attachUIChild);
					if (uuitext2 != null)
					{
						return uuitext2;
					}
				}
			}
			return null;
		}

		// Token: 0x060410C8 RID: 266440 RVA: 0x010B0D44 File Offset: 0x010AEF44
		public void RefreshLockState()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUIItem item = base.GetItem(7);
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			item.SetUIActive(itemProxy.LockItemVisible);
			if (itemProxy.LockItemVisible && itemProxy.LockTextData != null)
			{
				GameplayShopUtil.SetText(base.GetText(8), itemProxy.LockTextData);
			}
		}

		// Token: 0x060410C9 RID: 266441 RVA: 0x010B0D98 File Offset: 0x010AEF98
		public void RefreshTips()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUIText text = base.GetText(8);
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			if (itemProxy.SoldOutItemVisible || itemProxy.LockItemVisible)
			{
				return;
			}
			text.SetUIActive(itemProxy.PriceTipsTextVisible);
			if (itemProxy.PriceTipsTextVisible)
			{
				GameplayShopUtil.SetText(text, itemProxy.PriceTipsTextData);
			}
		}

		// Token: 0x060410CA RID: 266442 RVA: 0x010B0DF0 File Offset: 0x010AEFF0
		public void RefreshPurchaseLimit()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUIItem item = base.GetItem(9);
			UUIText text = base.GetText(10);
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			item.SetUIActive(itemProxy.BuyLimitCountTextVisible);
			text.SetUIActive(itemProxy.BuyLimitCountTextVisible);
			if (itemProxy.BuyLimitCountTextVisible && itemProxy.BuyLimitCountTextData != null)
			{
				GameplayShopUtil.SetText(text, itemProxy.BuyLimitCountTextData);
			}
		}

		// Token: 0x060410CB RID: 266443 RVA: 0x010B0E54 File Offset: 0x010AF054
		public void RefreshDiscount()
		{
			if (this.ItemProxy == null)
			{
				return;
			}
			UUIItem item = base.GetItem(11);
			UUIText text = base.GetText(12);
			CommonGameplayShopItemProxy itemProxy = this.ItemProxy;
			item.SetUIActive(itemProxy.DiscountItemVisible);
			text.SetUIActive(itemProxy.DiscountItemVisible);
			if (itemProxy.DiscountItemVisible && itemProxy.DiscountTextData != null)
			{
				GameplayShopUtil.SetText(text, itemProxy.DiscountTextData);
			}
		}

		// Token: 0x0402475E RID: 149342
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, string> QualityUtilityColorMap = new Dictionary<int, string>
		{
			{
				1,
				"76A291FF"
			},
			{
				2,
				"729FCAFF"
			},
			{
				3,
				"946EBAFF"
			},
			{
				4,
				"D6AD49FF"
			},
			{
				5,
				"CB5877FF"
			}
		};

		// Token: 0x0402475F RID: 149343
		[Nullable(2)]
		protected CommonGameplayShopItemProxy ItemProxy;

		// Token: 0x04024760 RID: 149344
		[Nullable(2)]
		protected PinballItemView ItemBase;

		// Token: 0x04024761 RID: 149345
		[Nullable(2)]
		private CommonGameplayShopItemProxy PendingBaseProxy;

		// Token: 0x04024762 RID: 149346
		private bool IsItemBaseReady;

		// Token: 0x0200C5AC RID: 50604
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403CD72 RID: 249202
			public const int QualitySprite = 0;

			// Token: 0x0403CD73 RID: 249203
			public const int ItemBase = 1;

			// Token: 0x0403CD74 RID: 249204
			public const int ItemCost = 2;

			// Token: 0x0403CD75 RID: 249205
			public const int TexIcon = 3;

			// Token: 0x0403CD76 RID: 249206
			public const int TxtPrice = 4;

			// Token: 0x0403CD77 RID: 249207
			public const int TxtOriginalPrice = 5;

			// Token: 0x0403CD78 RID: 249208
			public const int ItemSoldOut = 6;

			// Token: 0x0403CD79 RID: 249209
			public const int ItemSoldLock = 7;

			// Token: 0x0403CD7A RID: 249210
			public const int TxtTips = 8;

			// Token: 0x0403CD7B RID: 249211
			public const int ItemPurchaseLimit = 9;

			// Token: 0x0403CD7C RID: 249212
			public const int TextNum = 10;

			// Token: 0x0403CD7D RID: 249213
			public const int Discount = 11;

			// Token: 0x0403CD7E RID: 249214
			public const int TextDiscount = 12;

			// Token: 0x0403CD7F RID: 249215
			public const int SpriteUtility = 13;
		}
	}
}
