using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200592B RID: 22827
	[NullableContext(1)]
	[Nullable(0)]
	public class SeedRandomUtil
	{
		// Token: 0x06039ECA RID: 237258 RVA: 0x00EA9CDB File Offset: 0x00EA7EDB
		public void SetSeed(long seed)
		{
			this.Seed = seed;
		}

		// Token: 0x06039ECB RID: 237259 RVA: 0x00EA9CE4 File Offset: 0x00EA7EE4
		public double GetFraction()
		{
			this.Seed = (this.A * this.Seed + this.C) % this.M;
			return (double)this.Seed / (double)this.M;
		}

		// Token: 0x06039ECC RID: 237260 RVA: 0x00EA9D18 File Offset: 0x00EA7F18
		public int SeedRandomRangeInt(int min, int max)
		{
			double fraction = this.GetFraction();
			return Math.Min(max, (int)Math.Floor((double)min + fraction * (double)(max - min + 1)));
		}

		// Token: 0x06039ECD RID: 237261 RVA: 0x00EA9D44 File Offset: 0x00EA7F44
		public List<int> GenerateRandomSequence(int size)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < size; i++)
			{
				list.Add(i + 1);
			}
			for (int j = size - 1; j > 0; j--)
			{
				int index = this.SeedRandomRangeInt(0, j);
				int value = list[j];
				list[j] = list[index];
				list[index] = value;
			}
			return list;
		}

		// Token: 0x06039ECE RID: 237262 RVA: 0x00EA9DA4 File Offset: 0x00EA7FA4
		public int WeightedRandom(List<int> weights)
		{
			if (weights.Count == 1)
			{
				return 0;
			}
			List<int> list = new List<int>();
			int num = 0;
			foreach (int num2 in weights)
			{
				num += num2;
				list.Add(num);
			}
			int num3 = this.SeedRandomRangeInt(0, num);
			for (int i = 0; i < list.Count; i++)
			{
				if (num3 < list[i])
				{
					return i;
				}
			}
			return weights.Count - 1;
		}

		// Token: 0x04020D0C RID: 134412
		private readonly long A = 1664525L;

		// Token: 0x04020D0D RID: 134413
		private readonly long C = 1013904223L;

		// Token: 0x04020D0E RID: 134414
		private readonly long M = (long)Math.Pow(2.0, 32.0);

		// Token: 0x04020D0F RID: 134415
		private long Seed;
	}
}
