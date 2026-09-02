using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BCB RID: 7115
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchShopItemToyData : FloroRanchShopItemDataBase
{
	// Token: 0x0600CF07 RID: 52999 RVA: 0x003716BA File Offset: 0x0036F8BA
	public FloroRanchShopItemToyData(FloroRanchShopItem data) : base(data)
	{
		this.ConfigData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchToyData(this.Id);
	}

	// Token: 0x0600CF08 RID: 53000 RVA: 0x003716D9 File Offset: 0x0036F8D9
	public override string GetName()
	{
		return this.ConfigData.GetName();
	}

	// Token: 0x170010BC RID: 4284
	// (get) Token: 0x0600CF09 RID: 53001 RVA: 0x003716E6 File Offset: 0x0036F8E6
	public override string Desc
	{
		get
		{
			return this.ConfigData.Desc;
		}
	}

	// Token: 0x0600CF0A RID: 53002 RVA: 0x003716F3 File Offset: 0x0036F8F3
	public override string GetIcon()
	{
		return this.ConfigData.GetIcon();
	}

	// Token: 0x0600CF0B RID: 53003 RVA: 0x00371700 File Offset: 0x0036F900
	public override FloroRanchRarityData GetQualityData()
	{
		return this.ConfigData.GetToyQualityData();
	}

	// Token: 0x0600CF0C RID: 53004 RVA: 0x0037170D File Offset: 0x0036F90D
	public override int GetRace()
	{
		return 0;
	}

	// Token: 0x0600CF0D RID: 53005 RVA: 0x00371710 File Offset: 0x0036F910
	public override int GetEarnCount()
	{
		return 0;
	}

	// Token: 0x0600CF0E RID: 53006 RVA: 0x00371713 File Offset: 0x0036F913
	[NullableContext(2)]
	public override FloroRanchRaceData GetToyRaceData()
	{
		return this.ConfigData.GetToyRaceData();
	}

	// Token: 0x040062A4 RID: 25252
	public FloroRanchToyData ConfigData;
}
