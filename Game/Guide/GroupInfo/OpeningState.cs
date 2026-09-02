using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Guide.GroupInfo
{
	// Token: 0x02004A7D RID: 19069
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class OpeningState : StateBase<GuideGroupInfo, EGuideGroupState>
	{
		// Token: 0x06031C4B RID: 203851 RVA: 0x00C767B2 File Offset: 0x00C749B2
		public OpeningState(GuideGroupInfo owner, EGuideGroupState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<GuideGroupInfo, EGuideGroupState> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06031C4C RID: 203852 RVA: 0x00C767C0 File Offset: 0x00C749C0
		protected override void OnEnter(EGuideGroupState? lastState)
		{
			if (this.Entered)
			{
				return;
			}
			this.Entered = true;
			if (this.Owner.FinishPromise != null)
			{
				this.Owner.FinishPromise.SetResult();
				this.Owner.FinishPromise = null;
			}
			this.Owner.FinishPromise = new CustomPromise();
			bool ifPreExecute = this.Owner.GetIfPreExecute();
			if (ifPreExecute)
			{
				this.Owner.SwitchState(EGuideGroupState.Executing);
			}
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.GuideGroupOpening, this.Owner.Id, ifPreExecute);
		}

		// Token: 0x06031C4D RID: 203853 RVA: 0x00C7684D File Offset: 0x00C74A4D
		protected override void OnExit(EGuideGroupState nextState)
		{
			this.Entered = false;
		}

		// Token: 0x0401D243 RID: 119363
		private bool Entered;
	}
}
