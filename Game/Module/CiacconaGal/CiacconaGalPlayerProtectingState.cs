using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EAA RID: 24234
	internal class CiacconaGalPlayerProtectingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEAA RID: 249514 RVA: 0x00F79B10 File Offset: 0x00F77D10
		[NullableContext(1)]
		public CiacconaGalPlayerProtectingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEAB RID: 249515 RVA: 0x00F79B1C File Offset: 0x00F77D1C
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
			float interval = CiacconaGalUtils.GetAvgCoolDownTime() * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				CiacconaGalPlayer owner = this.Owner;
				if (owner == null)
				{
					return;
				}
				owner.TrySwitchToState(ECiacconaGalPlayerState.Pausing);
			}, interval, null, null, true, 1f);
		}

		// Token: 0x0603CEAC RID: 249516 RVA: 0x00F79B62 File Offset: 0x00F77D62
		public override void OnClick(int? id = null)
		{
		}
	}
}
