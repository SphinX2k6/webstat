using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.GroupInfo
{
	// Token: 0x02004A7E RID: 19070
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ExecutingState : StateBase<GuideGroupInfo, EGuideGroupState>
	{
		// Token: 0x06031C4E RID: 203854 RVA: 0x00C76856 File Offset: 0x00C74A56
		public ExecutingState(GuideGroupInfo owner, EGuideGroupState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideGroupInfo, EGuideGroupState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C4F RID: 203855 RVA: 0x00C76861 File Offset: 0x00C74A61
		protected override void OnEnter(EGuideGroupState? lastState)
		{
			this.Owner.PumpStep();
		}
	}
}
