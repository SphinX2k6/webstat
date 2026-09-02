using System;
using System.Runtime.CompilerServices;

// Token: 0x02001293 RID: 4755
[NullableContext(1)]
public interface IStackableChessAgent : IChessAgent
{
	// Token: 0x06007F4D RID: 32589
	[NullableContext(2)]
	Vector GetStackableLocation();

	// Token: 0x06007F4E RID: 32590
	[NullableContext(2)]
	Rotator GetStackableRotator(bool isSameDirection);

	// Token: 0x06007F4F RID: 32591
	void AttachToTarget(IStackableChessAgent target);

	// Token: 0x06007F50 RID: 32592
	void DetachFromTarget(IStackableChessAgent target);

	// Token: 0x06007F51 RID: 32593
	void OnPreviousMoveStateChange(IStackableChessAgent movingAgent, bool IsMoving, bool previousIsForward, bool isSameDirection);

	// Token: 0x06007F52 RID: 32594
	bool IsPerformRecursion(int type);

	// Token: 0x06007F53 RID: 32595
	void OnPreviousPerformStateChange(IStackableChessAgent agent, int type, bool isPerforming);
}
