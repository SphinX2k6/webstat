using System;

// Token: 0x02000BE2 RID: 3042
public class RandomSystem
{
	// Token: 0x06003204 RID: 12804 RVA: 0x00020561 File Offset: 0x0001E761
	private static float GetRandom()
	{
		return (float)(new Random().NextDouble() * (double)RandomSystem.RAND_MAX);
	}

	// Token: 0x06003205 RID: 12805 RVA: 0x00020575 File Offset: 0x0001E775
	public static float GetRandomInteger()
	{
		return RandomSystem.GetRandom();
	}

	// Token: 0x06003206 RID: 12806 RVA: 0x0002057C File Offset: 0x0001E77C
	public static float GetRandomPercent()
	{
		return (float)(new Random().NextDouble() * (double)RandomSystem.RAND_PERCENT);
	}

	// Token: 0x06003207 RID: 12807 RVA: 0x00020590 File Offset: 0x0001E790
	private static int NextXorShift32(int x)
	{
		int num = x ^ x << 13;
		int num2 = num ^ num >> 17;
		return num2 ^ num2 << 5;
	}

	// Token: 0x06003208 RID: 12808 RVA: 0x000205A1 File Offset: 0x0001E7A1
	public static int GetNextRandomSeed(int seed, ERandomReason reason)
	{
		return RandomSystem.NextXorShift32(seed);
	}

	// Token: 0x06003209 RID: 12809 RVA: 0x000205A9 File Offset: 0x0001E7A9
	public static int IterateRandomSeed(int seed, ERandomReason reason)
	{
		return RandomSystem.NextXorShift32(seed);
	}

	// Token: 0x040004EF RID: 1263
	public static readonly int RAND_MAX = int.MaxValue;

	// Token: 0x040004F0 RID: 1264
	public static readonly int RAND_PERCENT = 10000;
}
