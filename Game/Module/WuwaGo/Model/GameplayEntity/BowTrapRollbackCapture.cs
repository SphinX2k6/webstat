using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE0 RID: 19168
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BowTrapRollbackCapture : GameplayEntityRollbackCapture<WuWaGoBowTrapEntity>
	{
		// Token: 0x06031FA1 RID: 204705 RVA: 0x00C82CC5 File Offset: 0x00C80EC5
		public BowTrapRollbackCapture(WuWaGoBowTrapEntity entity) : base(entity)
		{
		}

		// Token: 0x06031FA2 RID: 204706 RVA: 0x00C82CDA File Offset: 0x00C80EDA
		public override void Restore()
		{
			base.Restore();
			base.Entity.MarkShotInRound(this.LastShootRound);
		}

		// Token: 0x0401D3D9 RID: 119769
		private readonly int LastShootRound = entity.PeekLastShootRound();
	}
}
