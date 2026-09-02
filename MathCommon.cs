using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C16 RID: 3094
public class MathCommon
{
	// Token: 0x060033FF RID: 13311 RVA: 0x0002C17A File Offset: 0x0002A37A
	private MathCommon()
	{
	}

	// Token: 0x06003400 RID: 13312 RVA: 0x0002C182 File Offset: 0x0002A382
	public static float Clamp(float x, float min, float max)
	{
		if (x < min)
		{
			return min;
		}
		if (x >= max)
		{
			return max;
		}
		return x;
	}

	// Token: 0x06003401 RID: 13313 RVA: 0x0002C191 File Offset: 0x0002A391
	public static int Clamp(int x, int min, int max)
	{
		if (x < min)
		{
			return min;
		}
		if (x <= max)
		{
			return x;
		}
		return max;
	}

	// Token: 0x06003402 RID: 13314 RVA: 0x0002C1A0 File Offset: 0x0002A3A0
	public static double Clamp(double x, double min, double max)
	{
		if (x < min)
		{
			return min;
		}
		if (x <= max)
		{
			return x;
		}
		return max;
	}

	// Token: 0x06003403 RID: 13315 RVA: 0x0002C1B0 File Offset: 0x0002A3B0
	public static float UnwindDegrees(float a)
	{
		float num;
		for (num = a; num > 180f; num -= 360f)
		{
		}
		while (num < -180f)
		{
			num += 360f;
		}
		return num;
	}

	// Token: 0x06003404 RID: 13316 RVA: 0x0002C1E4 File Offset: 0x0002A3E4
	public static double UnwindDegrees(double a)
	{
		double num;
		for (num = a; num > 180.0; num -= 360.0)
		{
		}
		while (num < -180.0)
		{
			num += 360.0;
		}
		return num;
	}

	// Token: 0x06003405 RID: 13317 RVA: 0x0002C228 File Offset: 0x0002A428
	public static float FloatSelect(float compared, float valueGeZero, float valueLtZero)
	{
		if (compared < 0f)
		{
			return valueLtZero;
		}
		return valueGeZero;
	}

	// Token: 0x06003406 RID: 13318 RVA: 0x0002C235 File Offset: 0x0002A435
	public static double DoubleSelect(double compared, double valueGeZero, double valueLtZero)
	{
		if (compared < 0.0)
		{
			return valueLtZero;
		}
		return valueGeZero;
	}

	// Token: 0x06003407 RID: 13319 RVA: 0x0002C246 File Offset: 0x0002A446
	public static float DegreeToRadian(float degVal)
	{
		return 0.017453292f * degVal;
	}

	// Token: 0x06003408 RID: 13320 RVA: 0x0002C24F File Offset: 0x0002A44F
	public static double DegreeToRadian(double degVal)
	{
		return 0.01745329238474369 * degVal;
	}

	// Token: 0x06003409 RID: 13321 RVA: 0x0002C25C File Offset: 0x0002A45C
	public static float RadianToDegree(float radVal)
	{
		return 57.29578f * radVal;
	}

	// Token: 0x0600340A RID: 13322 RVA: 0x0002C265 File Offset: 0x0002A465
	public static float Lerp(float from, float to, float alpha)
	{
		return from * (1f - alpha) + to * alpha;
	}

	// Token: 0x0600340B RID: 13323 RVA: 0x0002C274 File Offset: 0x0002A474
	public static double Lerp(double from, double to, float alpha)
	{
		return from * (double)(1f - alpha) + to * (double)alpha;
	}

	// Token: 0x0600340C RID: 13324 RVA: 0x0002C288 File Offset: 0x0002A488
	public static float LerpSin(float from, float to, float alpha)
	{
		float num = (float)Math.Sin((double)alpha * 3.141592653589793 / 2.0);
		return from * (1f - num) + to * num;
	}

	// Token: 0x0600340D RID: 13325 RVA: 0x0002C2C0 File Offset: 0x0002A4C0
	public static double LerpSin(double from, double to, float alpha)
	{
		double num = Math.Sin((double)alpha * 3.141592653589793 / 2.0);
		return from * (1.0 - num) + to * num;
	}

	// Token: 0x0600340E RID: 13326 RVA: 0x0002C2FC File Offset: 0x0002A4FC
	[NullableContext(1)]
	public static void VectorNormalizeRotator(IRotator rotator)
	{
		float num = rotator.Pitch;
		float num2 = rotator.Yaw;
		float num3 = rotator.Roll;
		num = MathCommon.WrapAngle(num);
		num2 = MathCommon.WrapAngle(num2);
		num3 = MathCommon.WrapAngle(num3);
		rotator.Pitch = num;
		rotator.Yaw = num2;
		rotator.Roll = num3;
	}

	// Token: 0x0600340F RID: 13327 RVA: 0x0002C348 File Offset: 0x0002A548
	public static float WrapAngle(float angle)
	{
		return (angle % 360f + 360f + 180f) % 360f - 180f;
	}

	// Token: 0x06003410 RID: 13328 RVA: 0x0002C369 File Offset: 0x0002A569
	public static double WrapAngle(double angle)
	{
		return (angle % 360.0 + 360.0 + 180.0) % 360.0 - 180.0;
	}

	// Token: 0x06003411 RID: 13329 RVA: 0x0002C3A0 File Offset: 0x0002A5A0
	public static float Warp(float x, float lower, float upper)
	{
		if (upper < lower)
		{
			float num = upper;
			upper = lower;
			lower = num;
		}
		float num2 = upper - lower;
		if (num2 < 1E-08f)
		{
			return lower;
		}
		return (x % num2 + num2 - lower) % num2 + lower;
	}

	// Token: 0x0400060B RID: 1547
	public const float ThreshPointOnPlane = 0.1f;

	// Token: 0x0400060C RID: 1548
	public const float ThreshVectorNormalized = 0.01f;

	// Token: 0x0400060D RID: 1549
	public const float ThreshPointAreSame = 2E-05f;

	// Token: 0x0400060E RID: 1550
	public const float ThreshNormalsAreParallel = 0.999845f;

	// Token: 0x0400060F RID: 1551
	public const float ThreshNormalsAreOrthogonal = 0.017455f;

	// Token: 0x04000610 RID: 1552
	public const float SmallNumber = 1E-08f;

	// Token: 0x04000611 RID: 1553
	public const float KindaSmallNumber = 0.0001f;

	// Token: 0x04000612 RID: 1554
	public const float BigNumber = 3.4E+38f;

	// Token: 0x04000613 RID: 1555
	public const float Delta = 1E-05f;

	// Token: 0x04000614 RID: 1556
	public const int MaxInt16 = 32767;

	// Token: 0x04000615 RID: 1557
	public const int RightAngle = 90;

	// Token: 0x04000616 RID: 1558
	public const int FlatAngle = 180;

	// Token: 0x04000617 RID: 1559
	public const int RoundAngle = 360;

	// Token: 0x04000618 RID: 1560
	public const int ProgressTotalValue = 100;

	// Token: 0x04000619 RID: 1561
	public const float DegToRad = 0.017453292f;

	// Token: 0x0400061A RID: 1562
	public const float RadDividedBy2 = 0.008726646f;

	// Token: 0x0400061B RID: 1563
	public const float RadToDeg = 57.29578f;
}
