using System;
using System.Runtime.CompilerServices;

// Token: 0x02001AAB RID: 6827
public class PinballBattleDamageNumFormatRule : IDamageNumFormatRule
{
	// Token: 0x0600C3A6 RID: 50086 RVA: 0x003394EC File Offset: 0x003376EC
	[NullableContext(1)]
	public string FormatNumber(float num)
	{
		if (num >= 1000000f)
		{
			double value = Math.Floor((double)(num / 1000000f));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(value);
			defaultInterpolatedStringHandler.AppendLiteral("M");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		if (num >= 1000f)
		{
			double value2 = Math.Floor((double)(num / 1000f));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(value2);
			defaultInterpolatedStringHandler.AppendLiteral("K");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return num.ToString();
	}
}
