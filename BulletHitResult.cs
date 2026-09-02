using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E01 RID: 11777
[NullableContext(1)]
[Nullable(0)]
public class BulletHitResult
{
	// Token: 0x06017C82 RID: 97410 RVA: 0x006A0EB4 File Offset: 0x0069F0B4
	public void AppendHitResult(UKuroHitResult hitResult, int index)
	{
		this.HitCount++;
		this.BoneNameArray.Add(hitResult.BoneNameArray.Get(index));
		this.ImpactPointX.Add((double)hitResult.ImpactPointX_Array.Get(index));
		this.ImpactPointY.Add((double)hitResult.ImpactPointY_Array.Get(index));
		this.ImpactPointZ.Add((double)hitResult.ImpactPointZ_Array.Get(index));
	}

	// Token: 0x06017C83 RID: 97411 RVA: 0x006A0F30 File Offset: 0x0069F130
	public void AppendHitTempResult(BulletHitTempResult hitTempResult, string boneName)
	{
		this.HitCount++;
		this.BoneNameArray.Add(boneName);
		this.ImpactPointX.Add(hitTempResult.ImpactPoint.X);
		this.ImpactPointY.Add(hitTempResult.ImpactPoint.Y);
		this.ImpactPointZ.Add(hitTempResult.ImpactPoint.Z);
	}

	// Token: 0x0400B7FF RID: 47103
	public int HitCount;

	// Token: 0x0400B800 RID: 47104
	public List<string> BoneNameArray = new List<string>();

	// Token: 0x0400B801 RID: 47105
	public List<double> ImpactPointX = new List<double>();

	// Token: 0x0400B802 RID: 47106
	public List<double> ImpactPointY = new List<double>();

	// Token: 0x0400B803 RID: 47107
	public List<double> ImpactPointZ = new List<double>();
}
