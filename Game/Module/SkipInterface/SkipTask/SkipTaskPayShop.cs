using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F2F RID: 20271
	public class SkipTaskPayShop : SkipTask
	{
		// Token: 0x060345BF RID: 214463 RVA: 0x00D1A950 File Offset: 0x00D18B50
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = (string)data[0];
			string text2 = (string)data[1];
			string goodIdString = (data.Length > 2) ? ((string)data[2]) : null;
			base.Finish();
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PayShopRootView))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("IsInView", Array.Empty<object>());
				return;
			}
			PayShopViewData payShopViewData = new PayShopViewData();
			payShopViewData.PayShopId = PayShopDefine.EPayShopTabType.ExchangeEntry;
			ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, delegate(bool success, int viewId)
			{
				if (success)
				{
					if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PayShopRootView))
					{
						this.Finish();
						return;
					}
					if (StringUtils.IsEmpty(goodIdString) || (goodIdString != null && int.Parse(goodIdString) == 0))
					{
						ItemTipsData currentItemTipsData = ModelBase<ItemTipsModel>.Instance.GetCurrentItemTipsData();
						if (currentItemTipsData == null)
						{
							this.Finish();
							return;
						}
						PayShopGoods goodsInTab = ModelBase<PayShopModel>.Instance.GetGoodsInTab(PayShopDefine.EPayShopTabType.ExchangeEntry, currentItemTipsData.ConfigId);
						if (goodsInTab == null)
						{
							ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(ConfigMultiTextLang.GetLocalTextNew("Shop_UnableBuy_Desc01", null));
							this.Finish();
							return;
						}
						ControllerBase<PayShopController>.Instance.OpenExchangePopView(goodsInTab.GetGoodsId(), null);
						return;
					}
					else
					{
						ControllerBase<PayShopController>.Instance.OpenExchangePopView(int.Parse(goodIdString), null);
					}
				}
			});
		}
	}
}
