using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02002A26 RID: 10790
[NullableContext(1)]
[Nullable(0)]
public class FlySkinBuyDetailViewData
{
	// Token: 0x0601589A RID: 88218 RVA: 0x005F8E66 File Offset: 0x005F7066
	public static FlySkinBuyDetailViewData Create(List<ShopFlySkinData> goodsData)
	{
		FlySkinBuyDetailViewData flySkinBuyDetailViewData = new FlySkinBuyDetailViewData();
		flySkinBuyDetailViewData.InitData(goodsData);
		return flySkinBuyDetailViewData;
	}

	// Token: 0x0601589B RID: 88219 RVA: 0x005F8E74 File Offset: 0x005F7074
	public void SetPreviewTitle(string title)
	{
		this.PreviewTitle = title;
	}

	// Token: 0x0601589C RID: 88220 RVA: 0x005F8E7D File Offset: 0x005F707D
	public string GetPreviewTitle()
	{
		return this.PreviewTitle;
	}

	// Token: 0x0601589D RID: 88221 RVA: 0x005F8E85 File Offset: 0x005F7085
	public void SetIndex(int index)
	{
		this.CurrentIndex = index;
	}

	// Token: 0x0601589E RID: 88222 RVA: 0x005F8E90 File Offset: 0x005F7090
	public void InitData(List<ShopFlySkinData> goodsData)
	{
		this.AllGoodsData = goodsData;
		this.AllSoarWingSkinData = new List<FlySkinData>();
		this.AllParaglidingSkinData = new List<FlySkinData>();
		foreach (ShopFlySkinData shopFlySkinData in goodsData)
		{
			FlySkinData flySkinData = ModelBase<FlySkinModel>.Instance.GetFlySkinData(shopFlySkinData.GetSoarWingSkinId());
			this.AllSoarWingSkinData.Add(flySkinData);
			flySkinData = ModelBase<FlySkinModel>.Instance.GetFlySkinData(shopFlySkinData.GetParaglidingSkinId());
			this.AllParaglidingSkinData.Add(flySkinData);
		}
	}

	// Token: 0x0601589F RID: 88223 RVA: 0x005F8F30 File Offset: 0x005F7130
	public bool CheckIfHaveMutiGood()
	{
		return this.AllGoodsData.Count > 1;
	}

	// Token: 0x060158A0 RID: 88224 RVA: 0x005F8F40 File Offset: 0x005F7140
	[NullableContext(2)]
	public ShopFlySkinData GetCurrentGoodsData()
	{
		if (this.AllGoodsData.Count == 0)
		{
			return null;
		}
		return this.AllGoodsData[this.CurrentIndex];
	}

	// Token: 0x060158A1 RID: 88225 RVA: 0x005F8F62 File Offset: 0x005F7162
	public void SwitchToNextGoods()
	{
		this.CurrentIndex++;
		if (this.CurrentIndex > this.AllGoodsData.Count - 1)
		{
			this.CurrentIndex = 0;
		}
	}

	// Token: 0x060158A2 RID: 88226 RVA: 0x005F8F8E File Offset: 0x005F718E
	public void SwitchToPreGoods()
	{
		this.CurrentIndex--;
		if (this.CurrentIndex < 0)
		{
			this.CurrentIndex = this.AllGoodsData.Count - 1;
		}
	}

	// Token: 0x060158A3 RID: 88227 RVA: 0x005F8FBA File Offset: 0x005F71BA
	public FlySkinData GetCurrentSkinData(EFlySkinType flySkinType)
	{
		if (flySkinType == EFlySkinType.SoarWing)
		{
			return this.AllSoarWingSkinData[this.CurrentIndex];
		}
		return this.AllParaglidingSkinData[this.CurrentIndex];
	}

	// Token: 0x060158A4 RID: 88228 RVA: 0x005F8FE2 File Offset: 0x005F71E2
	public string GetDiscountText()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return "";
		}
		return this.GetCurrentGoodsData().GetDiscountText();
	}

	// Token: 0x060158A5 RID: 88229 RVA: 0x005F8FFD File Offset: 0x005F71FD
	[NullableContext(2)]
	public object GetDiscountTimeData()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return null;
		}
		return this.GetCurrentGoodsData().GetDiscountTimeData();
	}

	// Token: 0x060158A6 RID: 88230 RVA: 0x005F9014 File Offset: 0x005F7214
	public bool GetIfDirect()
	{
		return this.GetCurrentGoodsData() != null && this.GetCurrentGoodsData().GetIfDirect();
	}

	// Token: 0x060158A7 RID: 88231 RVA: 0x005F902B File Offset: 0x005F722B
	[NullableContext(2)]
	public IPriceData GetPriceData()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return null;
		}
		return this.GetCurrentGoodsData().GetPriceData();
	}

	// Token: 0x060158A8 RID: 88232 RVA: 0x005F9042 File Offset: 0x005F7242
	public string GetDirectPriceText()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return "";
		}
		return this.GetCurrentGoodsData().GetDirectPriceText();
	}

	// Token: 0x0400A5E3 RID: 42467
	private List<FlySkinData> AllSoarWingSkinData = new List<FlySkinData>();

	// Token: 0x0400A5E4 RID: 42468
	private List<FlySkinData> AllParaglidingSkinData = new List<FlySkinData>();

	// Token: 0x0400A5E5 RID: 42469
	private List<ShopFlySkinData> AllGoodsData = new List<ShopFlySkinData>();

	// Token: 0x0400A5E6 RID: 42470
	private int CurrentIndex;

	// Token: 0x0400A5E7 RID: 42471
	private string PreviewTitle = "";
}
