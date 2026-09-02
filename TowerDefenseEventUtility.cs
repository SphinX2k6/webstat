using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;

// Token: 0x02002BD6 RID: 11222
public static class TowerDefenseEventUtility
{
	// Token: 0x06016657 RID: 91735 RVA: 0x00637DAD File Offset: 0x00635FAD
	public static GridPbDirection ConvertDegree2Direction(float degree)
	{
		if (degree > 45f && degree < 135f)
		{
			return GridPbDirection.GridRight;
		}
		if (degree > 135f || degree < -135f)
		{
			return GridPbDirection.GridBackward;
		}
		if (degree > -135f && degree < -45f)
		{
			return GridPbDirection.GridLeft;
		}
		return GridPbDirection.GridForward;
	}

	// Token: 0x06016658 RID: 91736 RVA: 0x00637DE8 File Offset: 0x00635FE8
	public static int ConvertDirection2Degree(GridPbDirection? direction)
	{
		if (direction != null)
		{
			switch (direction.GetValueOrDefault())
			{
			case GridPbDirection.GridBackward:
				return 180;
			case GridPbDirection.GridLeft:
				return -90;
			case GridPbDirection.GridRight:
				return 90;
			}
		}
		return 0;
	}

	// Token: 0x06016659 RID: 91737 RVA: 0x00637E2C File Offset: 0x0063602C
	[NullableContext(1)]
	public static bool ValidatePlacementWithGridNormal(ETowerDefenseEventTrapPlacementType placementType, global::Vector gridNormal, float threshold = 0.7f)
	{
		switch (placementType)
		{
		case ETowerDefenseEventTrapPlacementType.Ground:
			return gridNormal.DotProduct(global::Vector.UpVectorProxy) > (double)threshold;
		case ETowerDefenseEventTrapPlacementType.Wall:
			return Math.Abs(gridNormal.DotProduct(global::Vector.UpVectorProxy)) < (double)(1f - threshold);
		case ETowerDefenseEventTrapPlacementType.Roof:
			return gridNormal.DotProduct(global::Vector.DownVectorProxy) > (double)threshold;
		}
		return false;
	}
}
