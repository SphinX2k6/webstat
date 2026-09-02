using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BC8 RID: 7112
[NullableContext(1)]
[Nullable(0)]
public abstract class FloroRanchShopItemDataBase
{
	// Token: 0x0600CEEF RID: 52975 RVA: 0x00371588 File Offset: 0x0036F788
	public FloroRanchShopItemDataBase(FloroRanchShopItem data)
	{
		this.IncId = data.IncId;
		this.Id = data.Id;
		this.Price = data.Price;
		this.Type = data.Type;
		this.IsSold = data.Sold;
	}

	// Token: 0x0600CEF0 RID: 52976
	public abstract string GetName();

	// Token: 0x170010B9 RID: 4281
	// (get) Token: 0x0600CEF1 RID: 52977
	public abstract string Desc { get; }

	// Token: 0x0600CEF2 RID: 52978
	public abstract string GetIcon();

	// Token: 0x0600CEF3 RID: 52979
	public abstract FloroRanchRarityData GetQualityData();

	// Token: 0x0600CEF4 RID: 52980
	public abstract int GetRace();

	// Token: 0x0600CEF5 RID: 52981
	public abstract int GetEarnCount();

	// Token: 0x0600CEF6 RID: 52982 RVA: 0x003715D7 File Offset: 0x0036F7D7
	public virtual bool GetIsSpecialPhantom()
	{
		return false;
	}

	// Token: 0x0600CEF7 RID: 52983 RVA: 0x003715DA File Offset: 0x0036F7DA
	[NullableContext(2)]
	public virtual FloroRanchRaceData GetToyRaceData()
	{
		return null;
	}

	// Token: 0x0400629D RID: 25245
	public int IncId;

	// Token: 0x0400629E RID: 25246
	public int Id;

	// Token: 0x0400629F RID: 25247
	public int Price;

	// Token: 0x040062A0 RID: 25248
	public FloroRanchShopItemType Type;

	// Token: 0x040062A1 RID: 25249
	public bool IsSold;
}
