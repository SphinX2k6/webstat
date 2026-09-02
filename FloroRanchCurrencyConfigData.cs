using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BBF RID: 7103
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCurrencyConfigData
{
	// Token: 0x0600CEB2 RID: 52914 RVA: 0x00370EFF File Offset: 0x0036F0FF
	public FloroRanchCurrencyConfigData(FloroRanchCurrency config)
	{
		this.Config = config;
	}

	// Token: 0x0600CEB3 RID: 52915 RVA: 0x00370F10 File Offset: 0x0036F110
	public string GetName()
	{
		return this.Config.Name;
	}

	// Token: 0x0600CEB4 RID: 52916 RVA: 0x00370F2C File Offset: 0x0036F12C
	public string GetDesc()
	{
		return this.Config.Desc;
	}

	// Token: 0x0600CEB5 RID: 52917 RVA: 0x00370F48 File Offset: 0x0036F148
	public string GetIcon()
	{
		return this.Config.Icon;
	}

	// Token: 0x0600CEB6 RID: 52918 RVA: 0x00370F64 File Offset: 0x0036F164
	public string GetSmallIcon()
	{
		return this.Config.SmallIcon;
	}

	// Token: 0x0600CEB7 RID: 52919 RVA: 0x00370F80 File Offset: 0x0036F180
	public FloroRanchRarityData GetQualityData()
	{
		int rarityId = this.Config.RarityId;
		return ModelBase<FloroRanchModel>.Instance.GetFloroRanchRarity(rarityId);
	}

	// Token: 0x04006287 RID: 25223
	private readonly FloroRanchCurrency Config;
}
