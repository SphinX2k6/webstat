using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Guide.GroupInfo
{
	// Token: 0x02004A7F RID: 19071
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PendingState : StateBase<GuideGroupInfo, EGuideGroupState>
	{
		// Token: 0x06031C50 RID: 203856 RVA: 0x00C7686E File Offset: 0x00C74A6E
		public PendingState(GuideGroupInfo owner, EGuideGroupState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideGroupInfo, EGuideGroupState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C51 RID: 203857 RVA: 0x00C76879 File Offset: 0x00C74A79
		private void ClearTimer()
		{
			if (this.CheckTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CheckTimer);
				this.CheckTimer = null;
			}
		}

		// Token: 0x06031C52 RID: 203858 RVA: 0x00C7689B File Offset: 0x00C74A9B
		protected override void OnEnter(EGuideGroupState? lastState)
		{
			this.ClearTimer();
			this.CheckTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				if (!this.Owner.CanEnterExecuting())
				{
					return;
				}
				this.ClearTimer();
				this.Owner.StateMachine.Switch(EGuideGroupState.Executing);
			}, 1000f, 1f, null, null, true);
		}

		// Token: 0x06031C53 RID: 203859 RVA: 0x00C768CC File Offset: 0x00C74ACC
		protected override void OnExit(EGuideGroupState nextState)
		{
			this.ClearTimer();
		}

		// Token: 0x0401D244 RID: 119364
		[Nullable(2)]
		private TimerHandle CheckTimer;
	}
}
