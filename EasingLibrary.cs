using System;

// Token: 0x02000C15 RID: 3093
public class EasingLibrary
{
	// Token: 0x060033E0 RID: 13280 RVA: 0x0002B97C File Offset: 0x00029B7C
	public static double EaseInSine(float x)
	{
		return 1.0 - Math.Cos((double)x * 3.141592653589793 / 2.0);
	}

	// Token: 0x060033E1 RID: 13281 RVA: 0x0002B9A3 File Offset: 0x00029BA3
	public static double EaseOutSine(float x)
	{
		return Math.Sin((double)x * 3.141592653589793 / 2.0);
	}

	// Token: 0x060033E2 RID: 13282 RVA: 0x0002B9C0 File Offset: 0x00029BC0
	public static double EaseInOutSine(float x)
	{
		return -(Math.Cos(3.141592653589793 * (double)x) - 1.0) / 2.0;
	}

	// Token: 0x060033E3 RID: 13283 RVA: 0x0002B9E8 File Offset: 0x00029BE8
	public static float EaseInQuad(float x)
	{
		return x * x;
	}

	// Token: 0x060033E4 RID: 13284 RVA: 0x0002B9ED File Offset: 0x00029BED
	public static float EaseOutQuad(float x)
	{
		return 1f - (1f - x) * (1f - x);
	}

	// Token: 0x060033E5 RID: 13285 RVA: 0x0002BA04 File Offset: 0x00029C04
	public static double EaseInOutQuad(float x)
	{
		if (x >= 0.5f)
		{
			return 1.0 - Math.Pow((double)(-2f * x + 2f), 2.0) / 2.0;
		}
		return (double)(2f * x * x);
	}

	// Token: 0x060033E6 RID: 13286 RVA: 0x0002BA54 File Offset: 0x00029C54
	public static float EaseInCubic(float x)
	{
		return x * x * x;
	}

	// Token: 0x060033E7 RID: 13287 RVA: 0x0002BA5B File Offset: 0x00029C5B
	public static double EaseOutCubic(float x)
	{
		return 1.0 - Math.Pow((double)(1f - x), 3.0);
	}

	// Token: 0x060033E8 RID: 13288 RVA: 0x0002BA80 File Offset: 0x00029C80
	public static double EaseInOutCubic(float x)
	{
		if (x >= 0.5f)
		{
			return 1.0 - Math.Pow((double)(-2f * x + 2f), 3.0) / 2.0;
		}
		return (double)(4f * x * x * x);
	}

	// Token: 0x060033E9 RID: 13289 RVA: 0x0002BAD2 File Offset: 0x00029CD2
	public static float EaseInQuart(float x)
	{
		return x * x * x * x;
	}

	// Token: 0x060033EA RID: 13290 RVA: 0x0002BADB File Offset: 0x00029CDB
	public static double EaseOutQuart(float x)
	{
		return 1.0 - Math.Pow((double)(1f - x), 4.0);
	}

	// Token: 0x060033EB RID: 13291 RVA: 0x0002BB00 File Offset: 0x00029D00
	public static double EaseInOutQuart(float x)
	{
		if (x >= 0.5f)
		{
			return 1.0 - Math.Pow((double)(-2f * x + 2f), 4.0) / 2.0;
		}
		return (double)(8f * x * x * x * x);
	}

	// Token: 0x060033EC RID: 13292 RVA: 0x0002BB54 File Offset: 0x00029D54
	public static float EaseInQuint(float x)
	{
		return x * x * x * x * x;
	}

	// Token: 0x060033ED RID: 13293 RVA: 0x0002BB5F File Offset: 0x00029D5F
	public static double EaseOutQuint(float x)
	{
		return 1.0 - Math.Pow((double)(1f - x), 5.0);
	}

	// Token: 0x060033EE RID: 13294 RVA: 0x0002BB84 File Offset: 0x00029D84
	public static double EaseInOutQuint(float x)
	{
		if (x >= 0.5f)
		{
			return 1.0 - Math.Pow((double)(-2f * x + 2f), 5.0) / 2.0;
		}
		return (double)(16f * x * x * x * x * x);
	}

	// Token: 0x060033EF RID: 13295 RVA: 0x0002BBDA File Offset: 0x00029DDA
	public static double EaseInExpo(float x)
	{
		if (x != 0f)
		{
			return Math.Pow(2.0, (double)(10f * x - 10f));
		}
		return 0.0;
	}

	// Token: 0x060033F0 RID: 13296 RVA: 0x0002BC0A File Offset: 0x00029E0A
	public static double EaseOutExpo(float x)
	{
		if (x != 1f)
		{
			return 1.0 - Math.Pow(2.0, (double)(-10f * x));
		}
		return 1.0;
	}

	// Token: 0x060033F1 RID: 13297 RVA: 0x0002BC40 File Offset: 0x00029E40
	public static double EaseInOutExpo(float x)
	{
		if (x == 0f)
		{
			return 0.0;
		}
		if (x == 1f)
		{
			return 1.0;
		}
		if (x >= 0.5f)
		{
			return (2.0 - Math.Pow(2.0, (double)(-20f * x + 10f))) / 2.0;
		}
		return Math.Pow(2.0, (double)(20f * x - 10f)) / 2.0;
	}

	// Token: 0x060033F2 RID: 13298 RVA: 0x0002BCD0 File Offset: 0x00029ED0
	public static double EaseInCirc(float x)
	{
		return 1.0 - Math.Sqrt(1.0 - Math.Pow((double)x, 2.0));
	}

	// Token: 0x060033F3 RID: 13299 RVA: 0x0002BCFB File Offset: 0x00029EFB
	public static double EaseOutCirc(float x)
	{
		return Math.Sqrt(1.0 - Math.Pow((double)(x - 1f), 2.0));
	}

	// Token: 0x060033F4 RID: 13300 RVA: 0x0002BD24 File Offset: 0x00029F24
	public static double EaseInOutCirc(float x)
	{
		if (x >= 0.5f)
		{
			return (Math.Sqrt(1.0 - Math.Pow((double)(-2f * x + 2f), 2.0)) + 1.0) / 2.0;
		}
		return (1.0 - Math.Sqrt(1.0 - Math.Pow((double)(2f * x), 2.0))) / 2.0;
	}

	// Token: 0x060033F5 RID: 13301 RVA: 0x0002BDB4 File Offset: 0x00029FB4
	public static float EaseInBack(float x)
	{
		float num = 1.70158f;
		return (num + 1f) * x * x * x - num * x * x;
	}

	// Token: 0x060033F6 RID: 13302 RVA: 0x0002BDDC File Offset: 0x00029FDC
	public static double EaseOutBack(float x)
	{
		float num = 1.70158f;
		float num2 = num + 1f;
		return 1.0 + (double)num2 * Math.Pow((double)(x - 1f), 3.0) + (double)num * Math.Pow((double)(x - 1f), 2.0);
	}

	// Token: 0x060033F7 RID: 13303 RVA: 0x0002BE34 File Offset: 0x0002A034
	public static double EaseInOutBack(float x)
	{
		float num = 1.70158f * 1.525f;
		if (x >= 0.5f)
		{
			return (Math.Pow((double)(2f * x - 2f), 2.0) * (double)((num + 1f) * (x * 2f - 2f) + num) + 2.0) / 2.0;
		}
		return Math.Pow((double)(2f * x), 2.0) * (double)((num + 1f) * 2f * x - num) / 2.0;
	}

	// Token: 0x060033F8 RID: 13304 RVA: 0x0002BED4 File Offset: 0x0002A0D4
	public static double EaseInElastic(float x)
	{
		double num = 2.0943951023931953;
		if (x == 0f)
		{
			return 0.0;
		}
		if (x != 1f)
		{
			return -Math.Pow(2.0, (double)(10f * x - 10f)) * Math.Sin((double)(x * 10f - 10.75f) * num);
		}
		return 1.0;
	}

	// Token: 0x060033F9 RID: 13305 RVA: 0x0002BF44 File Offset: 0x0002A144
	public static double EaseOutElastic(float x)
	{
		double num = 2.0943951023931953;
		if (x == 0f)
		{
			return 0.0;
		}
		if (x != 1f)
		{
			return Math.Pow(2.0, (double)(-10f * x)) * Math.Sin((double)(x * 10f - 0.75f) * num) + 1.0;
		}
		return 1.0;
	}

	// Token: 0x060033FA RID: 13306 RVA: 0x0002BFB8 File Offset: 0x0002A1B8
	public static double EaseInOutElastic(float x)
	{
		double num = 1.3962634015954636;
		if (x == 0f)
		{
			return 0.0;
		}
		if (x == 1f)
		{
			return 1.0;
		}
		if (x >= 0.5f)
		{
			return Math.Pow(2.0, (double)(-20f * x + 10f)) * Math.Sin((double)(20f * x - 11.125f) * num) / 2.0 + 1.0;
		}
		return -(Math.Pow(2.0, (double)(20f * x - 10f)) * Math.Sin((double)(20f * x - 11.125f) * num)) / 2.0;
	}

	// Token: 0x060033FB RID: 13307 RVA: 0x0002C085 File Offset: 0x0002A285
	public static float EaseInBounce(float x)
	{
		return 1f - EasingLibrary.EaseOutBounce(1f - x);
	}

	// Token: 0x060033FC RID: 13308 RVA: 0x0002C09C File Offset: 0x0002A29C
	public static float EaseOutBounce(float x)
	{
		float num = 7.5625f;
		float num2 = 2.75f;
		if (x < 1f / num2)
		{
			return num * x * x;
		}
		if (x < 2f / num2)
		{
			float num3 = x - 1.5f / num2;
			return num * num3 * num3 + 0.75f;
		}
		if (x < 2.5f / num2)
		{
			float num4 = x - 2.25f / num2;
			return num * num4 * num4 + 0.9375f;
		}
		float num5 = x - 2.625f / num2;
		return num * num5 * num5 + 0.984375f;
	}

	// Token: 0x060033FD RID: 13309 RVA: 0x0002C120 File Offset: 0x0002A320
	public static float EaseInOutBounce(float x)
	{
		if (x >= 0.5f)
		{
			return (1f + EasingLibrary.EaseOutBounce(2f * x - 1f)) / 2f;
		}
		return (1f - EasingLibrary.EaseOutBounce(1f - 2f * x)) / 2f;
	}
}
