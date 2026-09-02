using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006938 RID: 26936
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayHelper
	{
		// Token: 0x06042D90 RID: 273808 RVA: 0x01128BBC File Offset: 0x01126DBC
		public static IAliasTable BuildAliasTable(Dictionary<int, int> itemWeightMap)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int num = 0;
			foreach (KeyValuePair<int, int> keyValuePair in itemWeightMap)
			{
				list.Add(keyValuePair.Key);
				list2.Add(keyValuePair.Value);
				num += keyValuePair.Value;
			}
			if (num < 100)
			{
				list.Add(-1);
				list2.Add(100 - num);
				num = 100;
			}
			int count = list.Count;
			float[] array = new float[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = (float)(list2[i] * count) / (float)num;
			}
			int[] array2 = new int[count];
			int[] array3 = new int[count];
			int j = -1;
			int k = count;
			for (int l = 0; l < count; l++)
			{
				if (array[l] < 1f)
				{
					array3[++j] = l;
				}
				else
				{
					array3[--k] = l;
				}
			}
			while (j >= 0)
			{
				if (k >= count)
				{
					break;
				}
				int num2 = array3[j--];
				int num3 = array3[k++];
				array2[num2] = num3;
				array[num3] = array[num3] + array[num2] - 1f;
				if (array[num3] < 1f)
				{
					array3[++j] = num3;
				}
				else
				{
					array3[--k] = num3;
				}
			}
			while (k < count)
			{
				array[array3[k++]] = 1f;
			}
			while (j >= 0)
			{
				array[array3[j--]] = 1f;
			}
			return new IAliasTable
			{
				Prob = array,
				Alias = array2,
				Items = list.ToArray(),
				ItemWeights = list2.ToArray()
			};
		}

		// Token: 0x06042D91 RID: 273809 RVA: 0x01128D94 File Offset: 0x01126F94
		public static int SampleFromAliasTable(IAliasTable table)
		{
			int num = table.Items.Length;
			int num2 = (int)Math.Floor(new Random().NextDouble() * (double)num);
			if ((float)new Random().NextDouble() >= table.Prob[num2])
			{
				return table.Items[table.Alias[num2]];
			}
			return table.Items[num2];
		}

		// Token: 0x06042D92 RID: 273810 RVA: 0x01128DEC File Offset: 0x01126FEC
		public static void CalculateBounds(Vector2D pos, Vector2D size, IDropCatchBounds outBounds)
		{
			outBounds.Left = pos.X - size.X / 2.0;
			outBounds.Right = pos.X + size.X / 2.0;
			outBounds.Top = pos.Y + size.Y / 2.0;
			outBounds.Bottom = pos.Y - size.Y / 2.0;
		}
	}
}
