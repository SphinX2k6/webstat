using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EAB RID: 24235
	internal class CiacconaGalPlayerChoiceProtectingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEAE RID: 249518 RVA: 0x00F79B77 File Offset: 0x00F77D77
		[NullableContext(1)]
		public CiacconaGalPlayerChoiceProtectingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEAF RID: 249519 RVA: 0x00F79B84 File Offset: 0x00F77D84
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
			float interval = CiacconaGalUtils.GetAvgChoiceProtectingTime() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				CiacconaGalPlayer owner = this.Owner;
				if (owner == null)
				{
					return;
				}
				owner.TrySwitchToState(ECiacconaGalPlayerState.Choosing);
			}, interval, null, null, true, 1f);
		}

		// Token: 0x0603CEB0 RID: 249520 RVA: 0x00F79BCA File Offset: 0x00F77DCA
		public override void OnClick(int? id = null)
		{
		}
	}
}
