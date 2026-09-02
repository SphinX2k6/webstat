using System;
using System.Runtime.CompilerServices;

// Token: 0x02001AAC RID: 6828
public class BossPillingBattleDamageNumFormatRule : IDamageNumFormatRule
{
	// Token: 0x0600C3A8 RID: 50088 RVA: 0x00339580 File Offset: 0x00337780
	[NullableContext(1)]
	public string FormatNumber(float num)
	{
		if ((double)num >= 100000.0)
		{
			return (Math.Floor((double)num / 100000.0 * 100.0) / 100.0).ToString() + "M";
		}
		return num.ToString();
	}

	// Token: 0x04005DD5 RID: 24021
	private const double DAMAGECHECK = 100000.0;
}
