using System;
using System.Runtime.CompilerServices;

// Token: 0x02002934 RID: 10548
public static class RouletteGridGenerator
{
	// Token: 0x06014F18 RID: 85784 RVA: 0x005CBB98 File Offset: 0x005C9D98
	[NullableContext(1)]
	public static RouletteGridBase GetGenerator(ERouletteGridType gridType)
	{
		switch (gridType)
		{
		case ERouletteGridType.Explore:
			return new RouletteGridExplore();
		case ERouletteGridType.Function:
			return new RouletteGridFunction();
		case ERouletteGridType.EquipItem:
			return new RouletteGridEquipItem();
		default:
			return new RouletteGridExplore();
		}
	}
}
