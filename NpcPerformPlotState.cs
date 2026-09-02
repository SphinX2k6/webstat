using System;
using System.Runtime.CompilerServices;

// Token: 0x020031D8 RID: 12760
public class NpcPerformPlotState : NpcPerformBaseState
{
	// Token: 0x0601A72E RID: 108334 RVA: 0x007CDD42 File Offset: 0x007CBF42
	[NullableContext(1)]
	public NpcPerformPlotState(EntityHandle owner, ENpcPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<EntityHandle, ENpcPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}
}
