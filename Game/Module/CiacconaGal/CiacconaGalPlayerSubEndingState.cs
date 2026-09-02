using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EAE RID: 24238
	internal class CiacconaGalPlayerSubEndingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEB8 RID: 249528 RVA: 0x00F79D89 File Offset: 0x00F77F89
		[NullableContext(1)]
		public CiacconaGalPlayerSubEndingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEB9 RID: 249529 RVA: 0x00F79D94 File Offset: 0x00F77F94
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
			ModelBase<CiacconaGalModel>.Instance.IsCurStepDataListDirty = true;
		}
	}
}
