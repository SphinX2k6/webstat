using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EA7 RID: 24231
	internal class CiacconaGalPlayerPausingState : BaseCiacconaGalPlayerState
	{
		// Token: 0x0603CEA1 RID: 249505 RVA: 0x00F79A72 File Offset: 0x00F77C72
		[NullableContext(1)]
		public CiacconaGalPlayerPausingState(CiacconaGalPlayer owner, ECiacconaGalPlayerState state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CiacconaGalPlayer, ECiacconaGalPlayerState> stateMachine) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x0603CEA2 RID: 249506 RVA: 0x00F79A7D File Offset: 0x00F77C7D
		protected override void OnEnter(ECiacconaGalPlayerState? lastState)
		{
			base.OnEnter(lastState);
		}

		// Token: 0x0603CEA3 RID: 249507 RVA: 0x00F79A88 File Offset: 0x00F77C88
		public override void OnClick(int? id = null)
		{
			CiacconaGalStepData stepDataById = ModelBase<CiacconaGalModel>.Instance.GetStepDataById(this.Owner.CurHandlingStepId);
			if (stepDataById != null && stepDataById.Type == ECiacconaGalStepType.Normal)
			{
				this.Owner.TryContinue(stepDataById.NextStepId);
			}
		}
	}
}
