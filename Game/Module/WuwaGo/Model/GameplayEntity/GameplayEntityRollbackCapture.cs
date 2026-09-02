using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE2 RID: 19170
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GameplayEntityRollbackCapture<[Nullable(0)] TEntity> : ActorWorldRollbackCapture<TEntity> where TEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x06031FAE RID: 204718 RVA: 0x00C82DE4 File Offset: 0x00C80FE4
		public GameplayEntityRollbackCapture(TEntity entity) : base(entity)
		{
		}

		// Token: 0x1700854C RID: 34124
		// (get) Token: 0x06031FAF RID: 204719 RVA: 0x00C82E0F File Offset: 0x00C8100F
		protected TEntity Entity
		{
			get
			{
				return this.Unit;
			}
		}

		// Token: 0x06031FB0 RID: 204720 RVA: 0x00C82E17 File Offset: 0x00C81017
		public override void Restore()
		{
			this.Entity.SetStateSilently(this.State);
			this.Entity.SetStandGridId(this.StandGridId);
			base.RestoreActorWorldTransform();
		}

		// Token: 0x0401D3DD RID: 119773
		private readonly EGameplayEntityState State = entity.State;

		// Token: 0x0401D3DE RID: 119774
		private readonly int StandGridId = entity.StandGridId;
	}
}
