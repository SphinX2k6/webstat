using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BCA RID: 7114
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchShopItemCardGroupData : FloroRanchShopItemDataBase
{
	// Token: 0x0600CF00 RID: 52992 RVA: 0x00371657 File Offset: 0x0036F857
	public FloroRanchShopItemCardGroupData(FloroRanchShopItem data) : base(data)
	{
		this.ConfigData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCardGroup(this.Id);
	}

	// Token: 0x0600CF01 RID: 52993 RVA: 0x00371676 File Offset: 0x0036F876
	public override string GetName()
	{
		return this.ConfigData.GetName();
	}

	// Token: 0x170010BB RID: 4283
	// (get) Token: 0x0600CF02 RID: 52994 RVA: 0x00371683 File Offset: 0x0036F883
	public override string Desc
	{
		get
		{
			return this.ConfigData.Desc;
		}
	}

	// Token: 0x0600CF03 RID: 52995 RVA: 0x00371690 File Offset: 0x0036F890
	public override string GetIcon()
	{
		return this.ConfigData.GetIcon();
	}

	// Token: 0x0600CF04 RID: 52996 RVA: 0x0037169D File Offset: 0x0036F89D
	public override FloroRanchRarityData GetQualityData()
	{
		return this.ConfigData.GetQualityData();
	}

	// Token: 0x0600CF05 RID: 52997 RVA: 0x003716AA File Offset: 0x0036F8AA
	public override int GetRace()
	{
		return this.ConfigData.GetRaceId();
	}

	// Token: 0x0600CF06 RID: 52998 RVA: 0x003716B7 File Offset: 0x0036F8B7
	public override int GetEarnCount()
	{
		return 0;
	}

	// Token: 0x040062A3 RID: 25251
	public FloroRanchCardGroupData ConfigData;
}
