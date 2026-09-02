using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EA9 RID: 24233
	internal class CiacconaGalPlayerSkippingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEA7 RID: 249511 RVA: 0x00F79AEA File Offset: 0x00F77CEA
		[NullableContext(1)]
		public CiacconaGalPlayerSkippingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEA8 RID: 249512 RVA: 0x00F79AF5 File Offset: 0x00F77CF5
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
			this.Owner.AnimHandler.Skip();
		}

		// Token: 0x0603CEA9 RID: 249513 RVA: 0x00F79B0E File Offset: 0x00F77D0E
		public override void OnClick(int? id = null)
		{
		}
	}
}
