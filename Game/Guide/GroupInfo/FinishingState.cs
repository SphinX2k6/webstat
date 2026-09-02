using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.GroupInfo
{
	// Token: 0x02004A80 RID: 19072
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FinishingState : StateBase<GuideGroupInfo, EGuideGroupState>
	{
		// Token: 0x06031C55 RID: 203861 RVA: 0x00C768FC File Offset: 0x00C74AFC
		public FinishingState(GuideGroupInfo owner, EGuideGroupState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideGroupInfo, EGuideGroupState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C56 RID: 203862 RVA: 0x00C76908 File Offset: 0x00C74B08
		protected override void OnEnter(EGuideGroupState? lastState)
		{
			bool isFake = this.Owner.IsFake;
			ControllerBase<GuideController>.Instance.FinishGuide(this.Owner.Id, isFake);
			if (this.Owner.FinishPromise != null)
			{
				this.Owner.FinishPromise.SetResult();
				this.Owner.FinishPromise = null;
			}
		}
	}
}
