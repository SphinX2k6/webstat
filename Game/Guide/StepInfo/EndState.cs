using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A78 RID: 19064
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EndState : StateBase<GuideStepInfo, EGuideStepState>
	{
		// Token: 0x06031C33 RID: 203827 RVA: 0x00C75C88 File Offset: 0x00C73E88
		public EndState(GuideStepInfo owner, EGuideStepState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideStepInfo, EGuideStepState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C34 RID: 203828 RVA: 0x00C75C94 File Offset: 0x00C73E94
		protected override void OnEnter(EGuideStepState? lastState)
		{
			if (this.Owner.Config.ContentType == 4)
			{
				ModelBase<GuideModel>.Instance.RemoveFocusGuideGroupFromView(this.Owner.OwnerGroup);
			}
		}
	}
}
