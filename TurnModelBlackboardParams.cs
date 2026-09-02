using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D96 RID: 3478
[NullableContext(1)]
[Nullable(0)]
internal class TurnModelBlackboardParams
{
	// Token: 0x0400163F RID: 5695
	public float TotalDuration;

	// Token: 0x04001640 RID: 5696
	public Rotator TurnModel = Rotator.Create();

	// Token: 0x04001641 RID: 5697
	public Quat TurnModelQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04001642 RID: 5698
	public float RunTime;
}
