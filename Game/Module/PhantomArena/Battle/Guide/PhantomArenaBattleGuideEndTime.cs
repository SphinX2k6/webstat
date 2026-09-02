using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x0200560E RID: 22030
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaBattleGuideEndTime : PhantomArenaBattleGuideDataBase<IBvbEndTurn>
	{
		// Token: 0x0603829A RID: 230042 RVA: 0x00E38DA4 File Offset: 0x00E36FA4
		public PhantomArenaBattleGuideEndTime(EBvbPlayerOperationType type, BvbPlayerOperationConstraint param) : base(type, param)
		{
		}

		// Token: 0x0603829B RID: 230043 RVA: 0x00E38DAE File Offset: 0x00E36FAE
		public override bool CheckCanExecute(params object[] params_)
		{
			return true;
		}
	}
}
