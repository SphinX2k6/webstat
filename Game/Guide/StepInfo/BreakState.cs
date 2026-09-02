using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A76 RID: 19062
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BreakState : StateBase<GuideStepInfo, EGuideStepState>
	{
		// Token: 0x06031C2F RID: 203823 RVA: 0x00C75BE1 File Offset: 0x00C73DE1
		public BreakState(GuideStepInfo owner, EGuideStepState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideStepInfo, EGuideStepState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C30 RID: 203824 RVA: 0x00C75BEC File Offset: 0x00C73DEC
		protected override void OnEnter(EGuideStepState? lastState)
		{
			if (this.Owner.Config.ContentType == 4)
			{
				ModelBase<GuideModel>.Instance.RemoveFocusGuideGroupFromView(this.Owner.OwnerGroup);
			}
			this.Owner.OwnerGroup.Break();
		}
	}
}
