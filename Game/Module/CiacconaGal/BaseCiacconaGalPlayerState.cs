using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EA5 RID: 24229
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BaseCiacconaGalPlayerState : StateBase<CiacconaGalPlayer, ECiacconaGalPlayerState>
	{
		// Token: 0x0603CE9C RID: 249500 RVA: 0x00F79A1D File Offset: 0x00F77C1D
		public BaseCiacconaGalPlayerState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CE9D RID: 249501 RVA: 0x00F79A28 File Offset: 0x00F77C28
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			this.Owner.ClearStatePendingToSwitchByState(this);
			this.Owner.NotifyStateChange(this.State);
		}

		// Token: 0x0603CE9E RID: 249502 RVA: 0x00F79A47 File Offset: 0x00F77C47
		public virtual void OnClick(int? id = null)
		{
		}
	}
}
