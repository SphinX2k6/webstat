using System;
using System.Runtime.CompilerServices;

// Token: 0x020031D6 RID: 12758
public class NpcPerformLevelAiControlState : NpcPerformBaseState
{
	// Token: 0x0601A726 RID: 108326 RVA: 0x007CDB8A File Offset: 0x007CBD8A
	[NullableContext(1)]
	public NpcPerformLevelAiControlState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}
}
