using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE8 RID: 19176
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class PressureTriggerRollbackCapture : GameplayEntityRollbackCapture<WuWaGoPressureTriggerEntity>
	{
		// Token: 0x06031FFF RID: 204799 RVA: 0x00C839BF File Offset: 0x00C81BBF
		public PressureTriggerRollbackCapture(WuWaGoPressureTriggerEntity entity) : base(entity)
		{
		}

		// Token: 0x06032000 RID: 204800 RVA: 0x00C839E0 File Offset: 0x00C81BE0
		public override void Restore()
		{
			base.Restore();
			base.Entity.RestoreOccupantStateForRollback(this.OccupantId, this.IsDirty);
			base.Entity.SyncPresentationForRollback();
		}

		// Token: 0x0401D3F9 RID: 119801
		private readonly int OccupantId = entity.CurrentOccupantId;

		// Token: 0x0401D3FA RID: 119802
		private readonly bool IsDirty = entity.Dirty;
	}
}
