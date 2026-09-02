using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B8 RID: 25272
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TetrisUtils : Singleton<TetrisUtils>
	{
		// Token: 0x0603F99D RID: 260509 RVA: 0x0104C5F8 File Offset: 0x0104A7F8
		[NullableContext(1)]
		public BlockInstance CreateInstance(IShapeConfig config)
		{
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			int num = config.Matrix.Length;
			if (num > 0)
			{
				int num2 = config.Matrix[0].Length;
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < num2; j++)
					{
						if (config.Matrix[i][j] == 1)
						{
							list.Add(new ValueTuple<int, int>(i, j));
						}
					}
				}
			}
			return new BlockInstance
			{
				ConfigId = config.Id,
				Offsets = list,
				ColorId = 0,
				GemType = EGemType.None,
				GemFill = EGemFillType.None,
				GemOffSet = 0
			};
		}

		// Token: 0x0603F99E RID: 260510 RVA: 0x0104C690 File Offset: 0x0104A890
		[return: TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		public ValueTuple<int, int> FindAnchorOffset([TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})] [Nullable(new byte[]
		{
			1,
			0
		})] List<ValueTuple<int, int>> offsets)
		{
			if (offsets.Count == 0)
			{
				return new ValueTuple<int, int>(0, 0);
			}
			int num = 0;
			int num2 = 0;
			foreach (ValueTuple<int, int> valueTuple in offsets)
			{
				num += valueTuple.Item1;
				num2 += valueTuple.Item2;
			}
			float num3 = (float)num / (float)offsets.Count;
			float num4 = (float)num2 / (float)offsets.Count;
			float num5 = float.MaxValue;
			ValueTuple<int, int> result = offsets[0];
			foreach (ValueTuple<int, int> valueTuple2 in offsets)
			{
				float num6 = (float)(Math.Pow((double)((float)valueTuple2.Item1 - num3), 2.0) + Math.Pow((double)((float)valueTuple2.Item2 - num4), 2.0));
				if (num6 < num5)
				{
					num5 = num6;
					result = valueTuple2;
				}
			}
			return result;
		}

		// Token: 0x0603F99F RID: 260511 RVA: 0x0104C7A8 File Offset: 0x0104A9A8
		[NullableContext(1)]
		public List<int> GetRandomIndices(int length, int count)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < length; i++)
			{
				list.Add(i);
			}
			Random random = new Random();
			for (int j = length - 1; j > 0; j--)
			{
				int index = random.Next(j + 1);
				int value = list[j];
				list[j] = list[index];
				list[index] = value;
			}
			return list.GetRange(0, count);
		}

		// Token: 0x0603F9A0 RID: 260512 RVA: 0x0104C818 File Offset: 0x0104AA18
		public static EGameMode CheckLevelMode(Tetris levelConfig)
		{
			if (levelConfig.Mode == 3)
			{
				return EGameMode.Infinite;
			}
			for (int i = 0; i < levelConfig.TargetResultLength; i++)
			{
				DicIntInt? dicIntInt = levelConfig.TargetResult(i);
				if (dicIntInt != null && dicIntInt.Value.Key == 0 && dicIntInt.Value.Value > 0)
				{
					return EGameMode.Score;
				}
			}
			return EGameMode.GemCollection;
		}

		// Token: 0x0603F9A1 RID: 260513 RVA: 0x0104C87B File Offset: 0x0104AA7B
		public static bool IsEggLevel(Tetris levelConfig)
		{
			return levelConfig.Mode == 2;
		}

		// Token: 0x0603F9A2 RID: 260514 RVA: 0x0104C887 File Offset: 0x0104AA87
		public static bool IsHardLevel(Tetris levelConfig)
		{
			return levelConfig.Mode == 1;
		}

		// Token: 0x0603F9A3 RID: 260515 RVA: 0x0104C893 File Offset: 0x0104AA93
		public static bool IsActivityLevel(Tetris levelConfig)
		{
			return levelConfig.Mode == 1 || levelConfig.Mode == 0 || levelConfig.Mode == 2;
		}

		// Token: 0x0603F9A4 RID: 260516 RVA: 0x0104C8B4 File Offset: 0x0104AAB4
		public static int GenPosKey(int row, int column)
		{
			return row * 100 + column;
		}

		// Token: 0x0603F9A5 RID: 260517 RVA: 0x0104C8BC File Offset: 0x0104AABC
		[return: TupleElementNames(new string[]
		{
			"Row",
			"Column"
		})]
		public static ValueTuple<int, int> ParsePosKey(int key)
		{
			return new ValueTuple<int, int>(key / 100, key % 100);
		}
	}
}
