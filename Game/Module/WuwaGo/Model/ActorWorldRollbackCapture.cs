using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004AD0 RID: 19152
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ActorWorldRollbackCapture<[Nullable(0)] TUnit> : IRollbackCapture where TUnit : WuWaGoBaseUnit
	{
		// Token: 0x06031EC5 RID: 204485 RVA: 0x00C7ED00 File Offset: 0x00C7CF00
		protected ActorWorldRollbackCapture(TUnit unit)
		{
			this.Unit = unit;
			this.WorldLocation = Vector.Create();
			this.WorldRotation = Rotator.Create();
			FVectorDouble? worldLocation = this.Unit.GetWorldLocation();
			FRotator? worldRotation = this.Unit.GetWorldRotation();
			if (worldLocation != null && worldRotation != null)
			{
				this.WorldLocation.Set(worldLocation.Value.X, worldLocation.Value.Y, worldLocation.Value.Z);
				this.WorldRotation.Set(worldRotation.Value.Pitch, worldRotation.Value.Yaw, worldRotation.Value.Roll);
				this.HasActorTransform = true;
			}
		}

		// Token: 0x06031EC6 RID: 204486
		public abstract void Restore();

		// Token: 0x06031EC7 RID: 204487 RVA: 0x00C7EDC9 File Offset: 0x00C7CFC9
		protected bool RestoreActorWorldTransform()
		{
			if (!this.HasActorTransform)
			{
				return false;
			}
			this.Unit.SetActorWorldTransform(this.WorldLocation, this.WorldRotation, false);
			return true;
		}

		// Token: 0x0401D37C RID: 119676
		private readonly Vector WorldLocation;

		// Token: 0x0401D37D RID: 119677
		private readonly Rotator WorldRotation;

		// Token: 0x0401D37E RID: 119678
		private readonly bool HasActorTransform;

		// Token: 0x0401D37F RID: 119679
		protected readonly TUnit Unit;
	}
}
