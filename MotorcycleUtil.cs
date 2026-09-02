using System;
using System.Runtime.CompilerServices;

// Token: 0x02001D49 RID: 7497
[NullableContext(1)]
[Nullable(0)]
public static class MotorcycleUtil
{
	// Token: 0x0600DCF8 RID: 56568 RVA: 0x003B60D4 File Offset: 0x003B42D4
	public static string CompactNumberFormat(float num)
	{
		num = (float)Math.Floor((double)num);
		if (num >= 100000000f)
		{
			float value = (float)Math.Floor((double)(num / 1000000f));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(value);
			defaultInterpolatedStringHandler.AppendLiteral("M");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		if (num >= 100000f)
		{
			float value2 = (float)Math.Floor((double)(num / 1000f));
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(value2);
			defaultInterpolatedStringHandler.AppendLiteral("K");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return num.ToString();
	}

	// Token: 0x0600DCF9 RID: 56569 RVA: 0x003B616C File Offset: 0x003B436C
	public static string TimeFormat(float milliseconds)
	{
		float num = milliseconds * 0.001f;
		int num2 = (int)Math.Floor((double)(num / 3600f));
		int num3 = (int)Math.Floor((double)(num % 3600f / 60f));
		int num4 = (int)Math.Floor((double)(num % 60f));
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
		defaultInterpolatedStringHandler.AppendFormatted(num2.ToString().PadLeft(2, '0'));
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(num3.ToString().PadLeft(2, '0'));
		defaultInterpolatedStringHandler.AppendLiteral(":");
		defaultInterpolatedStringHandler.AppendFormatted(num4.ToString().PadLeft(2, '0'));
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x040069D1 RID: 27089
	private const int HP_LEVEL1 = 100000;

	// Token: 0x040069D2 RID: 27090
	private const int HP_LEVEL2 = 100000000;

	// Token: 0x040069D3 RID: 27091
	private const int SECOND_PER_MINUTE = 60;

	// Token: 0x040069D4 RID: 27092
	private const int SECOND_PER_HOUR = 3600;
}
