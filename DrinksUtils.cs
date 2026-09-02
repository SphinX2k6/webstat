using System;

// Token: 0x02001007 RID: 4103
public class DrinksUtils
{
	// Token: 0x06006A96 RID: 27286 RVA: 0x001BD7D8 File Offset: 0x001BB9D8
	public static EDrinksRequireType GetStepType(int step)
	{
		if (step < 2)
		{
			return EDrinksRequireType.DrinksBase;
		}
		if (step < 4)
		{
			return EDrinksRequireType.Batching;
		}
		return EDrinksRequireType.Ornament;
	}
}
