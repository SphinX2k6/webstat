using System;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E86 RID: 28294
	public class FishingQteDefine
	{
		// Token: 0x060449D4 RID: 281044 RVA: 0x011D6BDA File Offset: 0x011D4DDA
		public static int calculateCellSize(int startIndex, int endIndex)
		{
			if (endIndex >= startIndex)
			{
				return endIndex - startIndex + 1;
			}
			return 36 - startIndex + endIndex + 1;
		}

		// Token: 0x060449D5 RID: 281045 RVA: 0x011D6BF0 File Offset: 0x011D4DF0
		public static int fixedCellIndex(int index)
		{
			if (index > 36)
			{
				int num = index % 36;
				if (num != 0)
				{
					return num;
				}
				return 36;
			}
			else
			{
				if (index <= 0)
				{
					return index + 36;
				}
				return index;
			}
		}

		// Token: 0x04026322 RID: 156450
		public const int FISHINGQTE_RINGCELLCOUNT = 36;

		// Token: 0x04026323 RID: 156451
		public const int FISHINGQTE_RING_ANGLE = 360;

		// Token: 0x04026324 RID: 156452
		public const int FISHINGQTE_SINGLECELL_ANGLE = 10;
	}
}
