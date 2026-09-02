using System;
using System.Runtime.CompilerServices;

// Token: 0x020031CD RID: 12749
public class NpcPerformAiControlState : NpcPerformBaseState
{
	// Token: 0x0601A6C4 RID: 108228 RVA: 0x007CB4D6 File Offset: 0x007C96D6
	[NullableContext(1)]
	public NpcPerformAiControlState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}
}
