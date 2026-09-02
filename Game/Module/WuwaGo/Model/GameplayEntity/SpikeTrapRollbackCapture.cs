using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AEE RID: 19182
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SpikeTrapRollbackCapture : GameplayEntityRollbackCapture<WuWaGoSpikeTrapEntity>
	{
		// Token: 0x0603202A RID: 204842 RVA: 0x00C83CFF File Offset: 0x00C81EFF
		public SpikeTrapRollbackCapture(WuWaGoSpikeTrapEntity entity) : base(entity)
		{
		}

		// Token: 0x0603202B RID: 204843 RVA: 0x00C83D38 File Offset: 0x00C81F38
		public override void Restore()
		{
			base.Restore();
			base.Entity.RestoreOccupantTrackingForRollback(this.StepCount, this.OccupantId, this.PrevOccupantId, this.IsDirty);
		}

		// Token: 0x0401D403 RID: 119811
		private readonly int StepCount = entity.CurrentStepCount;

		// Token: 0x0401D404 RID: 119812
		private readonly int OccupantId = entity.PeekOccupantId();

		// Token: 0x0401D405 RID: 119813
		private readonly int PrevOccupantId = entity.PeekPrevOccupantId();

		// Token: 0x0401D406 RID: 119814
		private readonly bool IsDirty = entity.PeekIsDirty();
	}
}
