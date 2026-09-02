using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EAD RID: 24237
	internal class CiacconaGalPlayerBeforeSubEndingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEB5 RID: 249525 RVA: 0x00F79D22 File Offset: 0x00F77F22
		[NullableContext(1)]
		public CiacconaGalPlayerBeforeSubEndingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEB6 RID: 249526 RVA: 0x00F79D30 File Offset: 0x00F77F30
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
			float interval = CiacconaGalUtils.GetAvgSubEndingDelayTime() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				CiacconaGalPlayer owner = this.Owner;
				if (owner == null)
				{
					return;
				}
				owner.TrySwitchToState(ECiacconaGalPlayerState.SubEnding);
			}, interval, null, null, true, 1f);
		}
	}
}
