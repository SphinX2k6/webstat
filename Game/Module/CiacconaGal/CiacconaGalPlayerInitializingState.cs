using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EA6 RID: 24230
	internal class CiacconaGalPlayerInitializingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CE9F RID: 249503 RVA: 0x00F79A49 File Offset: 0x00F77C49
		[NullableContext(1)]
		public CiacconaGalPlayerInitializingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEA0 RID: 249504 RVA: 0x00F79A54 File Offset: 0x00F77C54
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
			ICiacconaGalTextAnimHandler animHandler = this.Owner.AnimHandler;
			if (animHandler == null)
			{
				return;
			}
			animHandler.Stop();
		}
	}
}
