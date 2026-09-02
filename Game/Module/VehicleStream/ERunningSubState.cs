using System;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C3D RID: 19517
	public enum ERunningSubState
	{
		// Token: 0x0401D9B4 RID: 121268
		None,
		// Token: 0x0401D9B5 RID: 121269
		Normal,
		// Token: 0x0401D9B6 RID: 121270
		BrakingByObstruction,
		// Token: 0x0401D9B7 RID: 121271
		BrakingByIntersection,
		// Token: 0x0401D9B8 RID: 121272
		WaitingModelBuffer,
		// Token: 0x0401D9B9 RID: 121273
		SlowDownByTurn,
		// Token: 0x0401D9BA RID: 121274
		SlowDownByUphillSlope,
		// Token: 0x0401D9BB RID: 121275
		SlowDownByDownhillSlope
	}
}
