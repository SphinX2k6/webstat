using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BC6 RID: 7110
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchRarityData
{
	// Token: 0x0600CEE3 RID: 52963 RVA: 0x0037144F File Offset: 0x0036F64F
	public FloroRanchRarityData(FloroRanchRarity config)
	{
		this.Config = config;
	}

	// Token: 0x170010B8 RID: 4280
	// (get) Token: 0x0600CEE4 RID: 52964 RVA: 0x00371460 File Offset: 0x0036F660
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x0600CEE5 RID: 52965 RVA: 0x0037147C File Offset: 0x0036F67C
	public string GetRarityName()
	{
		return this.Config.Name;
	}

	// Token: 0x0600CEE6 RID: 52966 RVA: 0x00371498 File Offset: 0x0036F698
	public string GetRarityColor()
	{
		return this.Config.Color;
	}

	// Token: 0x0600CEE7 RID: 52967 RVA: 0x003714B4 File Offset: 0x0036F6B4
	public string GetRarityDetailCardBigBg()
	{
		return this.Config.DetailCardBigBg;
	}

	// Token: 0x0600CEE8 RID: 52968 RVA: 0x003714D0 File Offset: 0x0036F6D0
	public string GetRarityDetailCardSmallBg()
	{
		return this.Config.DetailCardSmallBg;
	}

	// Token: 0x0600CEE9 RID: 52969 RVA: 0x003714EC File Offset: 0x0036F6EC
	public string GetRaritySmallBg()
	{
		return this.Config.SmallCardBg;
	}

	// Token: 0x0600CEEA RID: 52970 RVA: 0x00371508 File Offset: 0x0036F708
	public string GetRarityShopItemBg()
	{
		return this.Config.ShopCardBg;
	}

	// Token: 0x0600CEEB RID: 52971 RVA: 0x00371524 File Offset: 0x0036F724
	public string GetSelectTexture()
	{
		return this.Config.SelectTexture;
	}

	// Token: 0x0600CEEC RID: 52972 RVA: 0x00371540 File Offset: 0x0036F740
	public bool IsGoldRarity()
	{
		return this.Config.Id == 4;
	}

	// Token: 0x0600CEED RID: 52973 RVA: 0x00371560 File Offset: 0x0036F760
	public bool IsSpecialRarity()
	{
		return this.Config.Id == 5;
	}

	// Token: 0x0400629A RID: 25242
	private const int GOLD_RARITY_ID = 4;

	// Token: 0x0400629B RID: 25243
	private const int SPECIAL_RARITY_ID = 5;

	// Token: 0x0400629C RID: 25244
	private readonly FloroRanchRarity Config;
}
