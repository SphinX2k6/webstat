using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EA8 RID: 24232
	internal class CiacconaGalPlayerPlayingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEA4 RID: 249508 RVA: 0x00F79AC8 File Offset: 0x00F77CC8
		[NullableContext(1)]
		public CiacconaGalPlayerPlayingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEA5 RID: 249509 RVA: 0x00F79AD3 File Offset: 0x00F77CD3
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
		}

		// Token: 0x0603CEA6 RID: 249510 RVA: 0x00F79ADC File Offset: 0x00F77CDC
		public override void OnClick(int? id = null)
		{
			this.Owner.TrySwitchToState(ECiacconaGalPlayerState.Skipping);
		}
	}
}
