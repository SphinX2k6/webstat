using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004AD1 RID: 19153
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class WuWaGoBaseUnit : IStaticVariableResetter
	{
		// Token: 0x06031EC8 RID: 204488 RVA: 0x00C7EDF3 File Offset: 0x00C7CFF3
		static WuWaGoBaseUnit()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(WuWaGoBaseUnit.CreateStaticDefaultValue), new Action(WuWaGoBaseUnit.ResetStaticDefaultValue));
		}

		// Token: 0x06031EC9 RID: 204489 RVA: 0x00C7EE12 File Offset: 0x00C7D012
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x06031ECA RID: 204490 RVA: 0x00C7EE14 File Offset: 0x00C7D014
		public static void ResetStaticDefaultValue()
		{
			WuWaGoBaseUnit._unitIndex = 0;
		}

		// Token: 0x17008521 RID: 34081
		// (get) Token: 0x06031ECB RID: 204491
		public abstract bool Actionable { get; }

		// Token: 0x17008522 RID: 34082
		// (get) Token: 0x06031ECC RID: 204492
		public abstract bool MoveAbility { get; }

		// Token: 0x06031ECD RID: 204493 RVA: 0x00C7EE1C File Offset: 0x00C7D01C
		protected WuWaGoBaseUnit(Vector coordinateInner, Rotator rotatorInner)
		{
			this.Coordinate = coordinateInner;
			this.Rotator = rotatorInner;
			this.Id = ++WuWaGoBaseUnit._unitIndex;
		}

		// Token: 0x17008523 RID: 34083
		// (get) Token: 0x06031ECE RID: 204494 RVA: 0x00C7EE45 File Offset: 0x00C7D045
		public Vector Coordinate { get; }

		// Token: 0x17008524 RID: 34084
		// (get) Token: 0x06031ECF RID: 204495 RVA: 0x00C7EE4D File Offset: 0x00C7D04D
		public Rotator Rotator { get; }

		// Token: 0x06031ED0 RID: 204496 RVA: 0x00C7EE55 File Offset: 0x00C7D055
		public void SetCoordinate(Vector target)
		{
			this.MarkRollbackDirty();
			this.Coordinate.DeepCopy(target);
		}

		// Token: 0x06031ED1 RID: 204497 RVA: 0x00C7EE69 File Offset: 0x00C7D069
		public void SetRotator(Rotator target)
		{
			this.MarkRollbackDirty();
			this.Rotator.DeepCopy(target);
		}

		// Token: 0x06031ED2 RID: 204498 RVA: 0x00C7EE7D File Offset: 0x00C7D07D
		protected void MarkRollbackDirty()
		{
			WuWaGoRollbackPreStates.MarkDirty(this);
		}

		// Token: 0x06031ED3 RID: 204499 RVA: 0x00C7EE85 File Offset: 0x00C7D085
		[NullableContext(2)]
		public virtual IRollbackCapture CaptureRollback()
		{
			return null;
		}

		// Token: 0x06031ED4 RID: 204500
		[NullableContext(2)]
		protected abstract AActor GetActorRaw();

		// Token: 0x06031ED5 RID: 204501 RVA: 0x00C7EE88 File Offset: 0x00C7D088
		public bool IsActorValid()
		{
			AActor actorRaw = this.GetActorRaw();
			return actorRaw != null && actorRaw.IsValid();
		}

		// Token: 0x06031ED6 RID: 204502 RVA: 0x00C7EE9B File Offset: 0x00C7D09B
		public string GetActorName()
		{
			AActor actorRaw = this.GetActorRaw();
			return ((actorRaw != null) ? actorRaw.GetName() : null) ?? "";
		}

		// Token: 0x06031ED7 RID: 204503 RVA: 0x00C7EEB8 File Offset: 0x00C7D0B8
		public FVectorDouble? GetWorldLocation()
		{
			AActor actorRaw = this.GetActorRaw();
			if (actorRaw == null || !actorRaw.IsValid())
			{
				return null;
			}
			return new FVectorDouble?(actorRaw.D_K2_GetActorLocation());
		}

		// Token: 0x06031ED8 RID: 204504 RVA: 0x00C7EEEC File Offset: 0x00C7D0EC
		public FRotator? GetWorldRotation()
		{
			AActor actorRaw = this.GetActorRaw();
			if (actorRaw == null || !actorRaw.IsValid())
			{
				return null;
			}
			return new FRotator?(actorRaw.K2_GetActorRotation());
		}

		// Token: 0x06031ED9 RID: 204505 RVA: 0x00C7EF20 File Offset: 0x00C7D120
		[NullableContext(2)]
		public UObject GetActorAsObject()
		{
			return this.GetActorRaw();
		}

		// Token: 0x06031EDA RID: 204506 RVA: 0x00C7EF28 File Offset: 0x00C7D128
		public void SetHiddenInGame(bool hidden)
		{
			AActor actorRaw = this.GetActorRaw();
			if (actorRaw == null || !actorRaw.IsValid())
			{
				return;
			}
			actorRaw.SetActorHiddenInGame(hidden);
		}

		// Token: 0x06031EDB RID: 204507 RVA: 0x00C7EF55 File Offset: 0x00C7D155
		public void MarkActorWorldTransformDirty()
		{
			if (!this.IsActorValid())
			{
				return;
			}
			this.MarkRollbackDirty();
		}

		// Token: 0x06031EDC RID: 204508 RVA: 0x00C7EF68 File Offset: 0x00C7D168
		public void SetActorWorldLocation(Vector worldLocation, bool sweep = false)
		{
			AActor actorRaw = this.GetActorRaw();
			if (actorRaw == null || !actorRaw.IsValid())
			{
				return;
			}
			this.MarkRollbackDirty();
			actorRaw.D_K2_SetActorLocation(worldLocation.ToUeVector(false), sweep, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x06031EDD RID: 204509 RVA: 0x00C7EFAC File Offset: 0x00C7D1AC
		public void SetActorWorldRotation(Rotator worldRotation)
		{
			AActor actorRaw = this.GetActorRaw();
			if (actorRaw == null || !actorRaw.IsValid())
			{
				return;
			}
			this.MarkRollbackDirty();
			actorRaw.K2_SetActorRotation(worldRotation.ToUeRotator(), false);
		}

		// Token: 0x06031EDE RID: 204510 RVA: 0x00C7EFE8 File Offset: 0x00C7D1E8
		public void SetActorWorldTransform(Vector worldLocation, Rotator worldRotation, bool teleport = false)
		{
			AActor actorRaw = this.GetActorRaw();
			if (actorRaw == null || !actorRaw.IsValid())
			{
				return;
			}
			this.MarkRollbackDirty();
			actorRaw.D_K2_SetActorLocationAndRotation(worldLocation.ToUeVector(false), worldRotation.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, teleport);
		}

		// Token: 0x0401D380 RID: 119680
		private static int _unitIndex;

		// Token: 0x0401D381 RID: 119681
		public readonly int Id;
	}
}
