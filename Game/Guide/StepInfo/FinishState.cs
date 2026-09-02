using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A77 RID: 19063
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class FinishState : StateBase<GuideStepInfo, EGuideStepState>
	{
		// Token: 0x06031C31 RID: 203825 RVA: 0x00C75C34 File Offset: 0x00C73E34
		public FinishState(GuideStepInfo owner, EGuideStepState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideStepInfo, EGuideStepState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C32 RID: 203826 RVA: 0x00C75C40 File Offset: 0x00C73E40
		protected override void OnEnter(EGuideStepState? lastState)
		{
			if (this.Owner.Config.ContentType == 4)
			{
				ModelBase<GuideModel>.Instance.RemoveFocusGuideGroupFromView(this.Owner.OwnerGroup);
			}
			this.Owner.OwnerGroup.PumpStep();
		}
	}
}
