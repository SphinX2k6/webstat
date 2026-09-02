using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A75 RID: 19061
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class PendingState : StateBase<GuideStepInfo, EGuideStepState>
	{
		// Token: 0x06031C2A RID: 203818 RVA: 0x00C75B4E File Offset: 0x00C73D4E
		public PendingState(GuideStepInfo owner, EGuideStepState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideStepInfo, EGuideStepState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C2B RID: 203819 RVA: 0x00C75B59 File Offset: 0x00C73D59
		private void ClearTimer()
		{
			if (this.CheckTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CheckTimer);
				this.CheckTimer = null;
			}
		}

		// Token: 0x06031C2C RID: 203820 RVA: 0x00C75B7B File Offset: 0x00C73D7B
		protected override void OnEnter(EGuideStepState? lastState)
		{
			this.ClearTimer();
			this.CheckTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				if (!this.Owner.CanEnterExecuting())
				{
					return;
				}
				this.ClearTimer();
				this.Owner.SwitchState(EGuideStepState.Executing);
			}, 1000f, 1f, null, null, true);
		}

		// Token: 0x06031C2D RID: 203821 RVA: 0x00C75BAC File Offset: 0x00C73DAC
		protected override void OnExit(EGuideStepState nextState)
		{
			this.Owner.StopLockInput();
			this.ClearTimer();
		}

		// Token: 0x0401D230 RID: 119344
		[Nullable(2)]
		private TimerHandle CheckTimer;
	}
}
