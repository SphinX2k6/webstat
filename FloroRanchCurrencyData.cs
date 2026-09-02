using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.FloroRanch;

// Token: 0x02001BC0 RID: 7104
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchCurrencyData
{
	// Token: 0x0600CEB8 RID: 52920 RVA: 0x00370FA7 File Offset: 0x0036F1A7
	public FloroRanchCurrencyData(ECurrencyType currencyType)
	{
		this.ConfigData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchCurrencyConfig(currencyType);
	}

	// Token: 0x0600CEB9 RID: 52921 RVA: 0x00370FC0 File Offset: 0x0036F1C0
	public void ChangeAmount(int amount)
	{
		this.Amount += amount;
	}

	// Token: 0x0600CEBA RID: 52922 RVA: 0x00370FD0 File Offset: 0x0036F1D0
	public void SetAmount(int amount)
	{
		this.Amount = amount;
	}

	// Token: 0x0600CEBB RID: 52923 RVA: 0x00370FD9 File Offset: 0x0036F1D9
	public void SetTotal(int amount)
	{
		this.TotalAmount = amount;
	}

	// Token: 0x0600CEBC RID: 52924 RVA: 0x00370FE2 File Offset: 0x0036F1E2
	public int GetAmount()
	{
		return this.Amount;
	}

	// Token: 0x0600CEBD RID: 52925 RVA: 0x00370FEA File Offset: 0x0036F1EA
	public int GetTotalAmount()
	{
		return this.TotalAmount;
	}

	// Token: 0x0600CEBE RID: 52926 RVA: 0x00370FF2 File Offset: 0x0036F1F2
	public string GetIconPath()
	{
		return this.ConfigData.GetSmallIcon();
	}

	// Token: 0x04006288 RID: 25224
	private int Amount;

	// Token: 0x04006289 RID: 25225
	private int TotalAmount;

	// Token: 0x0400628A RID: 25226
	public FloroRanchCurrencyConfigData ConfigData;
}
