using System;

// Token: 0x020011B3 RID: 4531
public static class ArtemisQteDefine
{
	// Token: 0x0600775C RID: 30556 RVA: 0x001F3B8E File Offset: 0x001F1D8E
	public static int CalculateCellSize(int startIndex, int endIndex)
	{
		if (endIndex >= startIndex)
		{
			return endIndex - startIndex + 1;
		}
		return 36 - startIndex + endIndex + 1;
	}

	// Token: 0x0600775D RID: 30557 RVA: 0x001F3BA4 File Offset: 0x001F1DA4
	public static int FixedCellIndex(int index)
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

	// Token: 0x040039A0 RID: 14752
	public const int QTE_RINGCELLCOUNT = 36;

	// Token: 0x040039A1 RID: 14753
	public const int QTE_RING_ANGLE = 360;

	// Token: 0x040039A2 RID: 14754
	public const int QTE_SINGLECELL_ANGLE = 10;
}
