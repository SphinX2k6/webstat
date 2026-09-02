using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003465 RID: 13413
[NullableContext(1)]
[Nullable(0)]
public class VoxelUtils
{
	// Token: 0x0601C225 RID: 115237 RVA: 0x0086514A File Offset: 0x0086334A
	public static FKuroVoxelInfo GetVoxelInfo(UWorld world, FVectorDouble location, ref int errorCode, float searchStep = -1f)
	{
		return UKuroVoxelSystem.D_GetVoxelInfoAtPos(world, location, ref errorCode, (double)searchStep);
	}

	// Token: 0x0601C226 RID: 115238 RVA: 0x00865156 File Offset: 0x00863356
	public static bool TryGetVoxelInfo(UWorld world, FVectorDouble location, ref FKuroVoxelInfo outVoxelInfo, ref int errorCode, float searchStep = -1f)
	{
		return !UKuroVoxelSystem.D_TryGetVoxelInfoAtPos(world, location, ref outVoxelInfo, ref errorCode, (double)searchStep) && errorCode == 0;
	}
}
