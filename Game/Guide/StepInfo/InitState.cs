using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A73 RID: 19059
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class InitState : StateBase<GuideStepInfo, EGuideStepState>
	{
		// Token: 0x06031C1F RID: 203807 RVA: 0x00C7568B File Offset: 0x00C7388B
		public InitState(GuideStepInfo owner, EGuideStepState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideStepInfo, EGuideStepState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}
	}
}
