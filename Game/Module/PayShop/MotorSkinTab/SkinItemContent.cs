using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.PayShop.MotorSkinTab
{
	// Token: 0x020056BD RID: 22205
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class SkinItemContent : GridProxyAbstract<SkinItemContentData>
	{
		// Token: 0x06038851 RID: 231505 RVA: 0x00E51A7C File Offset: 0x00E4FC7C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUISprite)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUITexture)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIText)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickBuyButton))
			};
		}

		// Token: 0x06038852 RID: 231506 RVA: 0x00E51C4C File Offset: 0x00E4FE4C
		protected override void OnStart()
		{
			this.RewardLayout = new GenericLayout<RewardItemGrid, IRewardItemGridData>(base.GetHorizontalLayout(8), new Func<RewardItemGrid>(this.OnCreateRewardItem), null, false, true);
			this.TotalTopUpTagItem = new TotalTopUpPayAdditiveTagItem();
			this.TotalTopUpTagItem.CreateByResourceIdAsync("UiItem_CumulativeRechargeScoreTag", base.GetItem(17), false).ContinueWith(delegate()
			{
				if (this.CacheTotalTopUpData != null)
				{
					TotalTopUpPayAdditiveTagItem totalTopUpTagItem = this.TotalTopUpTagItem;
					if (totalTopUpTagItem == null)
					{
						return;
					}
					totalTopUpTagItem.RefreshByGoodsId(this.CacheTotalTopUpData.Value);
				}
			});
		}

		// Token: 0x06038853 RID: 231507 RVA: 0x00E51CB0 File Offset: 0x00E4FEB0
		private RewardItemGrid OnCreateRewardItem()
		{
			return new RewardItemGrid();
		}

		// Token: 0x06038854 RID: 231508 RVA: 0x00E51CB8 File Offset: 0x00E4FEB8
		private void OnClickBuyButton()
		{
			if (this.CurrentShopMotorSkinData == null)
			{
				return;
			}
			List<ShopMotorSkinData> list = new List<ShopMotorSkinData>();
			int count = this.CurrentShopMotorSkinData.AllData.Count;
			for (int i = 0; i < count; i++)
			{
				ShopMotorSkinData item = ShopMotorSkinData.Create(this.CurrentShopMotorSkinData.AllData[i]);
				list.Add(item);
			}
			MotorSkinBuyDetailViewData motorSkinBuyDetailViewData = MotorSkinBuyDetailViewData.Create(list);
			motorSkinBuyDetailViewData.SetIndex(this.CurrentIndex);
			motorSkinBuyDetailViewData.SetPreviewTitle("MotorSkinShopTitle_Text");
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorSkinBuyDetailView, motorSkinBuyDetailViewData, null);
		}

		// Token: 0x06038855 RID: 231509 RVA: 0x00E51D40 File Offset: 0x00E4FF40
		public override void Refresh(SkinItemContentData data, bool isSelected, int gridIndex)
		{
			ShopMotorSkinData shopMotorSkinData = data.ShopMotorSkinData;
			this.CurrentShopMotorSkinData = data;
			this.CurrentIndex = gridIndex;
			if (shopMotorSkinData == null)
			{
				return;
			}
			MotorSkinData motorSkinData = shopMotorSkinData.GetMotorSkinData();
			MotorSkinShow? motorSkinShow = (motorSkinData != null) ? motorSkinData.GetMotorSkinShow() : null;
			if (motorSkinShow == null)
			{
				return;
			}
			this.RefreshName(motorSkinShow.Value);
			this.RefreshIcon(motorSkinShow.Value);
			this.RefreshQuality(motorSkinShow.Value);
			this.RefreshPrice(shopMotorSkinData);
			this.RefreshTime(shopMotorSkinData);
			this.RefreshLimit(shopMotorSkinData);
			this.RefreshGotState(shopMotorSkinData);
			this.RefreshRedDotState(shopMotorSkinData);
			PayShopGoods payShopGoods = shopMotorSkinData.GetPayShopGoods();
			this.CacheTotalTopUpData = new int?((payShopGoods != null) ? payShopGoods.GetGoodsId() : 0);
			if (this.TotalTopUpTagItem != null && !this.TotalTopUpTagItem.InAsyncLoading())
			{
				this.TotalTopUpTagItem.RefreshByGoodsId(this.CacheTotalTopUpData.Value);
			}
			List<IRewardItemGridData> list = new List<IRewardItemGridData>();
			foreach (KeyValuePair<string, int> keyValuePair in motorSkinShow.Value.ItemCount())
			{
				list.Add(new RewardItemGridData
				{
					IconPath = keyValuePair.Key,
					Count = keyValuePair.Value
				});
			}
			GenericLayout<RewardItemGrid, IRewardItemGridData> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06038856 RID: 231510 RVA: 0x00E51EA8 File Offset: 0x00E500A8
		private void RefreshName(MotorSkinShow config)
		{
			UUIText text = base.GetText(7);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(config.Name);
		}

		// Token: 0x06038857 RID: 231511 RVA: 0x00E51EC4 File Offset: 0x00E500C4
		private void RefreshIcon(MotorSkinShow config)
		{
			base.SetTextureByPath(config.Icon, base.GetTexture(3), null, null);
		}

		// Token: 0x06038858 RID: 231512 RVA: 0x00E51EF0 File Offset: 0x00E500F0
		private void RefreshQuality(MotorSkinShow config)
		{
			int qualityId = config.QualityId;
			MotorGiftQuality value = ConfigBase<SkinConfig>.Instance.GetMotorSkinGiftQualityConfig(qualityId).Value;
			base.SetTextureByPath(value.BgA, base.GetTexture(1), null, null);
			base.SetTextureByPath(value.BgBar, base.GetTexture(10), null, null);
			base.SetTextureByPath(value.BgType, base.GetTexture(2), null, null);
			base.SetTextureByPath(value.BgC, base.GetTexture(4), null, null);
			UUIItem sprite = base.GetSprite(5);
			bool bUseChangeColor = qualityId != 1;
			FColor? fcolor = null;
			sprite.SetChangeColor(bUseChangeColor, fcolor);
			UUIItem sprite2 = base.GetSprite(6);
			bool bUseChangeColor2 = qualityId != 1;
			fcolor = null;
			sprite2.SetChangeColor(bUseChangeColor2, fcolor);
		}

		// Token: 0x06038859 RID: 231513 RVA: 0x00E51FCC File Offset: 0x00E501CC
		private void RefreshPrice(ShopMotorSkinData data)
		{
			IPriceData priceData = data.GetPriceData();
			if (!data.GetCurrentGoodsData().IsDirect())
			{
				if (priceData != null)
				{
					UUIText text = base.GetText(11);
					if (text == null)
					{
						return;
					}
					text.SetText(priceData.NowPrice.ToString(), true);
				}
				return;
			}
			UUIText text2 = base.GetText(11);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(data.GetDirectPriceText(), true);
		}

		// Token: 0x0603885A RID: 231514 RVA: 0x00E5202C File Offset: 0x00E5022C
		private void RefreshTime(ShopMotorSkinData data)
		{
			if (data == null)
			{
				base.GetItem(13).SetUIActive(false);
				return;
			}
			ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> countDownData = data.GetCurrentGoodsData().GetCountDownData();
			CommonDefine.IPayShowCountDownRemainTime item = countDownData.Item2;
			if (countDownData.Item3 == 0.0)
			{
				base.GetItem(12).SetUIActive(false);
				return;
			}
			base.GetItem(12).SetUIActive(true);
			UUIText text = base.GetText(13);
			CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = item as CommonDefine.PayShowCountDownRemainTime<string>;
			if (payShowCountDownRemainTime != null)
			{
				text.SetText(payShowCountDownRemainTime.Value, true);
				return;
			}
			CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime> payShowCountDownRemainTime2 = item as CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime>;
			if (payShowCountDownRemainTime2 != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, payShowCountDownRemainTime2.Value.TextId, new <>z__ReadOnlySingleElementList<object>(payShowCountDownRemainTime2.Value.TimeValue));
			}
		}

		// Token: 0x0603885B RID: 231515 RVA: 0x00E520E0 File Offset: 0x00E502E0
		private void RefreshLimit(ShopMotorSkinData data)
		{
			UUIText text = base.GetText(14);
			if (data.GetIfCanBuy())
			{
				string shopTipsText = data.GetCurrentGoodsData().GetShopTipsText();
				if (text != null)
				{
					text.SetText(shopTipsText, true);
				}
				if (text != null)
				{
					text.SetUIActive(true);
					return;
				}
			}
			else if (text != null)
			{
				text.SetUIActive(false);
			}
		}

		// Token: 0x0603885C RID: 231516 RVA: 0x00E5212C File Offset: 0x00E5032C
		private void RefreshGotState(ShopMotorSkinData data)
		{
			bool uiactive = !data.GetIfCanBuy();
			UUIItem item = base.GetItem(15);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0603885D RID: 231517 RVA: 0x00E52158 File Offset: 0x00E50358
		private void RefreshRedDotState(ShopMotorSkinData data)
		{
			bool ifNeedRemind = data.GetCurrentGoodsData().GetIfNeedRemind();
			base.GetItem(16).SetUIActive(ifNeedRemind);
		}

		// Token: 0x04020436 RID: 132150
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RewardItemGrid, IRewardItemGridData> RewardLayout;

		// Token: 0x04020437 RID: 132151
		[Nullable(2)]
		private SkinItemContentData CurrentShopMotorSkinData;

		// Token: 0x04020438 RID: 132152
		[Nullable(2)]
		private TotalTopUpPayAdditiveTagItem TotalTopUpTagItem;

		// Token: 0x04020439 RID: 132153
		private int CurrentIndex;

		// Token: 0x0402043A RID: 132154
		private int? CacheTotalTopUpData;

		// Token: 0x0200B72E RID: 46894
		[NullableContext(0)]
		private enum EShopMotorItemComponents
		{
			// Token: 0x04038A81 RID: 232065
			BtnClick,
			// Token: 0x04038A82 RID: 232066
			TexQualityBgA,
			// Token: 0x04038A83 RID: 232067
			TexIconType,
			// Token: 0x04038A84 RID: 232068
			TexIcon,
			// Token: 0x04038A85 RID: 232069
			TexQualityBgB,
			// Token: 0x04038A86 RID: 232070
			SpriteModelCol01,
			// Token: 0x04038A87 RID: 232071
			SpriteModelCol02,
			// Token: 0x04038A88 RID: 232072
			TxtName,
			// Token: 0x04038A89 RID: 232073
			PanelRewardList,
			// Token: 0x04038A8A RID: 232074
			BtnReward01,
			// Token: 0x04038A8B RID: 232075
			TexQualityBar,
			// Token: 0x04038A8C RID: 232076
			TxtPrice,
			// Token: 0x04038A8D RID: 232077
			PanelDiscountTime,
			// Token: 0x04038A8E RID: 232078
			TxtTime,
			// Token: 0x04038A8F RID: 232079
			TxtLimit,
			// Token: 0x04038A90 RID: 232080
			PanelGot,
			// Token: 0x04038A91 RID: 232081
			PanelRedDot,
			// Token: 0x04038A92 RID: 232082
			PanelTag
		}
	}
}
