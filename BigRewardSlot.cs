using System;
using System.Runtime.CompilerServices;

// Token: 0x02001CD0 RID: 7376
[NullableContext(1)]
[Nullable(0)]
internal class BigRewardSlot
{
	// Token: 0x0600D83F RID: 55359 RVA: 0x0039D57A File Offset: 0x0039B77A
	public static BigRewardSlot MakeBig(GachaAccumulateRewardData reward)
	{
		return new BigRewardSlot
		{
			Kind = EBigRewardSlotKind.Big,
			Reward = reward
		};
	}

	// Token: 0x0600D840 RID: 55360 RVA: 0x0039D58F File Offset: 0x0039B78F
	public static BigRewardSlot MakeCyclic()
	{
		return new BigRewardSlot
		{
			Kind = EBigRewardSlotKind.Cyclic
		};
	}

	// Token: 0x0600D841 RID: 55361 RVA: 0x0039D59D File Offset: 0x0039B79D
	public static BigRewardSlot MakeNone()
	{
		return new BigRewardSlot();
	}

	// Token: 0x04006716 RID: 26390
	public EBigRewardSlotKind Kind = EBigRewardSlotKind.None;

	// Token: 0x04006717 RID: 26391
	[Nullable(2)]
	public GachaAccumulateRewardData Reward;
}
