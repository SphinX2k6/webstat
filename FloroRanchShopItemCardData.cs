using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BC9 RID: 7113
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchShopItemCardData : FloroRanchShopItemDataBase
{
	// Token: 0x0600CEF8 RID: 52984 RVA: 0x003715DD File Offset: 0x0036F7DD
	public FloroRanchShopItemCardData(FloroRanchShopItem data) : base(data)
	{
		this.ConfigData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCardData(this.Id);
	}

	// Token: 0x0600CEF9 RID: 52985 RVA: 0x003715FC File Offset: 0x0036F7FC
	public override string GetName()
	{
		return this.ConfigData.GetName();
	}

	// Token: 0x170010BA RID: 4282
	// (get) Token: 0x0600CEFA RID: 52986 RVA: 0x00371609 File Offset: 0x0036F809
	public override string Desc
	{
		get
		{
			return this.ConfigData.Desc;
		}
	}

	// Token: 0x0600CEFB RID: 52987 RVA: 0x00371616 File Offset: 0x0036F816
	public override string GetIcon()
	{
		return this.ConfigData.GetIcon();
	}

	// Token: 0x0600CEFC RID: 52988 RVA: 0x00371623 File Offset: 0x0036F823
	public override FloroRanchRarityData GetQualityData()
	{
		return this.ConfigData.GetCardQualityData();
	}

	// Token: 0x0600CEFD RID: 52989 RVA: 0x00371630 File Offset: 0x0036F830
	public override int GetRace()
	{
		return this.ConfigData.GetRace();
	}

	// Token: 0x0600CEFE RID: 52990 RVA: 0x0037163D File Offset: 0x0036F83D
	public override int GetEarnCount()
	{
		return this.ConfigData.GetCardSalary();
	}

	// Token: 0x0600CEFF RID: 52991 RVA: 0x0037164A File Offset: 0x0036F84A
	public override bool GetIsSpecialPhantom()
	{
		return this.ConfigData.IsSpecialPhantom;
	}

	// Token: 0x040062A2 RID: 25250
	public FloroRanchCardData ConfigData;
}
