using System;
using CSharpScript.Game.Ui;

// Token: 0x02001032 RID: 4146
public class FurnitureShopItemProxy : CommonGameplayShopItemProxy
{
	// Token: 0x06006BE6 RID: 27622 RVA: 0x001C462C File Offset: 0x001C282C
	public override void UpdateLeftTime()
	{
		base.LeftTimeItemVisible = false;
	}

	// Token: 0x06006BE7 RID: 27623 RVA: 0x001C4635 File Offset: 0x001C2835
	public override void UpdateBuyLimitCountText()
	{
		base.BuyLimitCountTextVisible = false;
	}

	// Token: 0x06006BE8 RID: 27624 RVA: 0x001C463E File Offset: 0x001C283E
	public override void UpdateRedDot()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		base.RedDotVisible = ModelBase<FurnitureModel>.Instance.CheckFurnitureShopItemRedDotByData(this.GoodsData);
	}

	// Token: 0x06006BE9 RID: 27625 RVA: 0x001C4660 File Offset: 0x001C2860
	public override void OnBuyButtonClick()
	{
		if (this.GoodsData == null)
		{
			return;
		}
		FurnitureShopExchangePopViewProxy furnitureShopExchangePopViewProxy = new FurnitureShopExchangePopViewProxy();
		furnitureShopExchangePopViewProxy.UpdateFromPayShopGoods(this.GoodsData);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GameplayExchangePopView, furnitureShopExchangePopViewProxy, null);
	}
}
