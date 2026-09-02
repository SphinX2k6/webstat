using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D1E RID: 3358
[NullableContext(2)]
[Nullable(0)]
internal class AddMoveParams
{
	// Token: 0x0400121A RID: 4634
	public float NowTime;

	// Token: 0x0400121B RID: 4635
	public float CurrentSpeed;

	// Token: 0x0400121C RID: 4636
	[Nullable(1)]
	public readonly Vector InputDirectCache = Vector.Create();

	// Token: 0x0400121D RID: 4637
	public float AccumulativeSpeedUpTime;

	// Token: 0x0400121E RID: 4638
	public CharacterSkillComponent CharSkillComp;

	// Token: 0x0400121F RID: 4639
	public BaseMoveComponent MoveComp;

	// Token: 0x04001220 RID: 4640
	public CharacterActorComponent CharActorComp;
}
