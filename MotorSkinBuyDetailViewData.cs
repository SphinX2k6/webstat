using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02002A28 RID: 10792
[NullableContext(1)]
[Nullable(0)]
public class MotorSkinBuyDetailViewData
{
	// Token: 0x060158C0 RID: 88256 RVA: 0x005F928F File Offset: 0x005F748F
	public static MotorSkinBuyDetailViewData Create(List<ShopMotorSkinData> goodsData)
	{
		MotorSkinBuyDetailViewData motorSkinBuyDetailViewData = new MotorSkinBuyDetailViewData();
		motorSkinBuyDetailViewData.InitData(goodsData);
		return motorSkinBuyDetailViewData;
	}

	// Token: 0x060158C1 RID: 88257 RVA: 0x005F929D File Offset: 0x005F749D
	public void SetPreviewTitle(string title)
	{
		this.PreviewTitle = title;
	}

	// Token: 0x060158C2 RID: 88258 RVA: 0x005F92A6 File Offset: 0x005F74A6
	public string GetPreviewTitle()
	{
		return this.PreviewTitle;
	}

	// Token: 0x060158C3 RID: 88259 RVA: 0x005F92AE File Offset: 0x005F74AE
	public void SetIndex(int index)
	{
		this.CurrentIndex = index;
	}

	// Token: 0x060158C4 RID: 88260 RVA: 0x005F92B7 File Offset: 0x005F74B7
	public void InitData(List<ShopMotorSkinData> goodsData)
	{
		this.AllGoodsData = goodsData;
		this.AllSkinData = new List<MotorSkinData>();
	}

	// Token: 0x060158C5 RID: 88261 RVA: 0x005F92CB File Offset: 0x005F74CB
	public bool CheckIfHaveMutiGood()
	{
		return this.AllGoodsData.Count > 1;
	}

	// Token: 0x060158C6 RID: 88262 RVA: 0x005F92DB File Offset: 0x005F74DB
	[NullableContext(2)]
	public ShopMotorSkinData GetCurrentGoodsData()
	{
		if (this.AllGoodsData.Count == 0)
		{
			return null;
		}
		return this.AllGoodsData[this.CurrentIndex];
	}

	// Token: 0x060158C7 RID: 88263 RVA: 0x005F92FD File Offset: 0x005F74FD
	public void SwitchToNextGoods()
	{
		this.CurrentIndex++;
		if (this.CurrentIndex > this.AllGoodsData.Count - 1)
		{
			this.CurrentIndex = 0;
		}
	}

	// Token: 0x060158C8 RID: 88264 RVA: 0x005F9329 File Offset: 0x005F7529
	public void SwitchToPreGoods()
	{
		this.CurrentIndex--;
		if (this.CurrentIndex < 0)
		{
			this.CurrentIndex = this.AllGoodsData.Count - 1;
		}
	}

	// Token: 0x060158C9 RID: 88265 RVA: 0x005F9355 File Offset: 0x005F7555
	public MotorSkinData GetCurrentSkinData()
	{
		return this.AllSkinData[this.CurrentIndex];
	}

	// Token: 0x060158CA RID: 88266 RVA: 0x005F9368 File Offset: 0x005F7568
	public string GetDiscountText()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return "";
		}
		return this.GetCurrentGoodsData().GetDiscountText();
	}

	// Token: 0x060158CB RID: 88267 RVA: 0x005F9383 File Offset: 0x005F7583
	[NullableContext(2)]
	public object GetDiscountTimeData()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return null;
		}
		return this.GetCurrentGoodsData().GetDiscountTimeData();
	}

	// Token: 0x060158CC RID: 88268 RVA: 0x005F939A File Offset: 0x005F759A
	public bool GetIfDirect()
	{
		return this.GetCurrentGoodsData() != null && this.GetCurrentGoodsData().GetIfDirect();
	}

	// Token: 0x060158CD RID: 88269 RVA: 0x005F93B1 File Offset: 0x005F75B1
	[NullableContext(2)]
	public IPriceData GetPriceData()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return null;
		}
		return this.GetCurrentGoodsData().GetPriceData();
	}

	// Token: 0x060158CE RID: 88270 RVA: 0x005F93C8 File Offset: 0x005F75C8
	public string GetDirectPriceText()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return "";
		}
		return this.GetCurrentGoodsData().GetDirectPriceText();
	}

	// Token: 0x0400A5EB RID: 42475
	private List<MotorSkinData> AllSkinData = new List<MotorSkinData>();

	// Token: 0x0400A5EC RID: 42476
	private List<ShopMotorSkinData> AllGoodsData = new List<ShopMotorSkinData>();

	// Token: 0x0400A5ED RID: 42477
	private int CurrentIndex;

	// Token: 0x0400A5EE RID: 42478
	private string PreviewTitle = "";
}
