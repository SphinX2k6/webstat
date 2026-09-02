using System;
using System.Runtime.CompilerServices;

// Token: 0x02001ECB RID: 7883
[NullableContext(1)]
[Nullable(0)]
public class Binding : HoldingHandsRelation
{
	// Token: 0x04007046 RID: 28742
	[Nullable(2)]
	public HandRuntime LeaderRuntime;

	// Token: 0x04007047 RID: 28743
	[Nullable(2)]
	public HandRuntime FollowerRuntime;

	// Token: 0x04007048 RID: 28744
	public EBindingState State;

	// Token: 0x04007049 RID: 28745
	public double BindDirDamping = 100.0;

	// Token: 0x0400704A RID: 28746
	public bool Updated;

	// Token: 0x0400704B RID: 28747
	public bool Reachable;

	// Token: 0x0400704C RID: 28748
	public bool LastReachable;

	// Token: 0x0400704D RID: 28749
	public double ReachableTime;

	// Token: 0x0400704E RID: 28750
	public double UnReachableTime;

	// Token: 0x0400704F RID: 28751
	public double ToReachableDistance;

	// Token: 0x04007050 RID: 28752
	public bool NoLerpNextUpdate;

	// Token: 0x04007051 RID: 28753
	public Vector Down = Vector.Create();

	// Token: 0x04007052 RID: 28754
	public Vector ShoulderDelta = Vector.Create();

	// Token: 0x04007053 RID: 28755
	public Vector ShoulderDeltaUnit = Vector.Create();

	// Token: 0x04007054 RID: 28756
	public Vector FoShoulderToLeAnimBindPos = Vector.Create();

	// Token: 0x04007055 RID: 28757
	public Vector BindPosDelta = Vector.Create();
}
