using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002A2E RID: 10798
[NullableContext(1)]
[Nullable(0)]
public class SkinBuyDetailViewData
{
	// Token: 0x0601593A RID: 88378 RVA: 0x005FA3D7 File Offset: 0x005F85D7
	public static SkinBuyDetailViewData Create(List<ShopSkinData> goodsData)
	{
		SkinBuyDetailViewData skinBuyDetailViewData = new SkinBuyDetailViewData();
		skinBuyDetailViewData.InitData(goodsData);
		return skinBuyDetailViewData;
	}

	// Token: 0x0601593B RID: 88379 RVA: 0x005FA3E5 File Offset: 0x005F85E5
	public static SkinBuyDetailViewData CreateByRoleSkinData(List<RoleSkinData> skinData)
	{
		SkinBuyDetailViewData skinBuyDetailViewData = new SkinBuyDetailViewData();
		skinBuyDetailViewData.InitDataByRoleSkinData(skinData);
		return skinBuyDetailViewData;
	}

	// Token: 0x0601593C RID: 88380 RVA: 0x005FA3F3 File Offset: 0x005F85F3
	public void SetPreviewTitle(string title)
	{
		this.PreviewTitle = title;
	}

	// Token: 0x0601593D RID: 88381 RVA: 0x005FA3FC File Offset: 0x005F85FC
	public string GetPreviewTitle()
	{
		return this.PreviewTitle;
	}

	// Token: 0x0601593E RID: 88382 RVA: 0x005FA404 File Offset: 0x005F8604
	public void SetIsActivityReward(bool value)
	{
		this.IsActivityReward = value;
	}

	// Token: 0x0601593F RID: 88383 RVA: 0x005FA40D File Offset: 0x005F860D
	public bool GetIsActivityReward()
	{
		return this.IsActivityReward;
	}

	// Token: 0x06015940 RID: 88384 RVA: 0x005FA415 File Offset: 0x005F8615
	public void SetIndex(int index)
	{
		this.CurrentIndex = index;
	}

	// Token: 0x06015941 RID: 88385 RVA: 0x005FA41E File Offset: 0x005F861E
	public int GetIndex()
	{
		return this.CurrentIndex;
	}

	// Token: 0x06015942 RID: 88386 RVA: 0x005FA428 File Offset: 0x005F8628
	public TItem[] GetConnectOtherReward()
	{
		List<TItem> list = new List<TItem>();
		InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(this.GetCurrentSkinData().GetItemId()).Value.HeadId, 0);
		TItem item = new TItem(itemData, 0);
		list.Add(item);
		return list.ToArray();
	}

	// Token: 0x06015943 RID: 88387 RVA: 0x005FA47B File Offset: 0x005F867B
	public void InitDataByRoleSkinData(List<RoleSkinData> skinData)
	{
		this.AllSkinData = skinData;
	}

	// Token: 0x06015944 RID: 88388 RVA: 0x005FA484 File Offset: 0x005F8684
	public void InitData(List<ShopSkinData> goodsData)
	{
		this.AllGoodsData = goodsData;
		this.AllSkinData = new List<RoleSkinData>();
		foreach (ShopSkinData shopSkinData in goodsData)
		{
			RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(shopSkinData.GetItemId());
			this.AllSkinData.Add(roleSkinData);
		}
	}

	// Token: 0x06015945 RID: 88389 RVA: 0x005FA4FC File Offset: 0x005F86FC
	public bool CheckIfHaveMutiGood()
	{
		return this.AllGoodsData.Count > 1;
	}

	// Token: 0x06015946 RID: 88390 RVA: 0x005FA50C File Offset: 0x005F870C
	[NullableContext(2)]
	public ShopSkinData GetCurrentGoodsData()
	{
		if (this.AllGoodsData.Count == 0)
		{
			return null;
		}
		return this.AllGoodsData[this.CurrentIndex];
	}

	// Token: 0x06015947 RID: 88391 RVA: 0x005FA52E File Offset: 0x005F872E
	public void SwitchToNextGoods()
	{
		this.CurrentIndex++;
		if (this.CurrentIndex > this.AllGoodsData.Count - 1)
		{
			this.CurrentIndex = 0;
		}
	}

	// Token: 0x06015948 RID: 88392 RVA: 0x005FA55A File Offset: 0x005F875A
	public void SwitchToPreGoods()
	{
		this.CurrentIndex--;
		if (this.CurrentIndex < 0)
		{
			this.CurrentIndex = this.AllGoodsData.Count - 1;
		}
	}

	// Token: 0x06015949 RID: 88393 RVA: 0x005FA586 File Offset: 0x005F8786
	public RoleSkinData GetCurrentSkinData()
	{
		return this.AllSkinData[this.CurrentIndex];
	}

	// Token: 0x0601594A RID: 88394 RVA: 0x005FA599 File Offset: 0x005F8799
	public void SwitchToNextSkinData()
	{
		if (this.AllSkinData.Count <= 1)
		{
			return;
		}
		this.CurrentIndex = (this.CurrentIndex + 1) % this.AllSkinData.Count;
	}

	// Token: 0x0601594B RID: 88395 RVA: 0x005FA5C4 File Offset: 0x005F87C4
	public bool GetIfNeedShowSwitchItem()
	{
		return this.GetCurrentSkinData().GetSuitWeaponSkinId() > 0;
	}

	// Token: 0x0601594C RID: 88396 RVA: 0x005FA5D4 File Offset: 0x005F87D4
	public string GetDiscountText()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return "";
		}
		return this.GetCurrentGoodsData().GetDiscountText();
	}

	// Token: 0x0601594D RID: 88397 RVA: 0x005FA5EF File Offset: 0x005F87EF
	[NullableContext(2)]
	public object GetDiscountTimeData()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return null;
		}
		return this.GetCurrentGoodsData().GetDiscountTimeData();
	}

	// Token: 0x0601594E RID: 88398 RVA: 0x005FA606 File Offset: 0x005F8806
	public bool GetIfDirect()
	{
		return this.GetCurrentGoodsData() != null && this.GetCurrentGoodsData().GetIfDirect();
	}

	// Token: 0x0601594F RID: 88399 RVA: 0x005FA61D File Offset: 0x005F881D
	[NullableContext(2)]
	public IPriceData GetPriceData()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return null;
		}
		return this.GetCurrentGoodsData().GetPriceData();
	}

	// Token: 0x06015950 RID: 88400 RVA: 0x005FA634 File Offset: 0x005F8834
	public string GetDirectPriceText()
	{
		if (this.GetCurrentGoodsData() == null)
		{
			return "";
		}
		return this.GetCurrentGoodsData().GetDirectPriceText();
	}

	// Token: 0x06015951 RID: 88401 RVA: 0x005FA64F File Offset: 0x005F884F
	public bool GetIfHaveSkinNeedRole()
	{
		return this.GetCurrentSkinData().GetIfHaveRole();
	}

	// Token: 0x0400A5FF RID: 42495
	private List<RoleSkinData> AllSkinData = new List<RoleSkinData>();

	// Token: 0x0400A600 RID: 42496
	private List<ShopSkinData> AllGoodsData = new List<ShopSkinData>();

	// Token: 0x0400A601 RID: 42497
	private int CurrentIndex;

	// Token: 0x0400A602 RID: 42498
	private string PreviewTitle = "";

	// Token: 0x0400A603 RID: 42499
	private bool IsActivityReward;
}
