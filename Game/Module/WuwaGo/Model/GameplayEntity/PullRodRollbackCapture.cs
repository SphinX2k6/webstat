using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AEA RID: 19178
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class PullRodRollbackCapture : GameplayEntityRollbackCapture<WuWaGoPullRodEntity>
	{
		// Token: 0x06032012 RID: 204818 RVA: 0x00C83B2A File Offset: 0x00C81D2A
		public PullRodRollbackCapture(WuWaGoPullRodEntity entity) : base(entity)
		{
		}

		// Token: 0x06032013 RID: 204819 RVA: 0x00C83B33 File Offset: 0x00C81D33
		public override void Restore()
		{
			base.Restore();
			base.Entity.SyncPresentationForRollback();
		}
	}
}
