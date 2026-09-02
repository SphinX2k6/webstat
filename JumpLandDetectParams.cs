using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D55 RID: 3413
public class JumpLandDetectParams
{
	// Token: 0x04001430 RID: 5168
	public float TotalTime;

	// Token: 0x04001431 RID: 5169
	public float NowTime;

	// Token: 0x04001432 RID: 5170
	[Nullable(2)]
	public Entity Entity;

	// Token: 0x04001433 RID: 5171
	[Nullable(1)]
	public Vector HeightOffset = Vector.Create();

	// Token: 0x04001434 RID: 5172
	public bool SetGoThrough;
}
