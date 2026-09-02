using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState
{
	// Token: 0x02006F16 RID: 28438
	[NullableContext(1)]
	[Nullable(0)]
	public class DgmClawBaseMoveState
	{
		// Token: 0x06044E15 RID: 282133 RVA: 0x011ECE14 File Offset: 0x011EB014
		public DgmClawBaseMoveState(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootActor, FTransformDouble ownerActorTransform)
		{
			this.Owner = owner;
			this.ClawActor = clawActor;
			this.ClawRootActor = clawRootActor;
			Vector ownerLocation = this.OwnerLocation;
			FVectorDouble location = ownerActorTransform.GetLocation();
			ownerLocation.FromUeVector(location);
			Vector ownerScale = this.OwnerScale;
			FVector scale3D = ownerActorTransform.GetScale3D();
			ownerScale.FromUeVector(scale3D);
			Rotator ownerRotation = this.OwnerRotation;
			FRotator frotator = ownerActorTransform.GetRotation().Rotator();
			ownerRotation.FromUeRotator(frotator);
		}

		// Token: 0x06044E16 RID: 282134 RVA: 0x011ECEAF File Offset: 0x011EB0AF
		public virtual void Enter()
		{
		}

		// Token: 0x06044E17 RID: 282135 RVA: 0x011ECEB1 File Offset: 0x011EB0B1
		protected virtual void End()
		{
			Singleton<EventSystem>.Instance.EmitWithTarget(this.Owner.Entity, EEventName.OnDollGrabMachineClawStateEnd);
		}

		// Token: 0x06044E18 RID: 282136 RVA: 0x011ECECE File Offset: 0x011EB0CE
		public virtual void Exit()
		{
		}

		// Token: 0x06044E19 RID: 282137 RVA: 0x011ECED0 File Offset: 0x011EB0D0
		public virtual void Update(float delta)
		{
		}

		// Token: 0x06044E1A RID: 282138 RVA: 0x011ECED2 File Offset: 0x011EB0D2
		public virtual void Pause()
		{
		}

		// Token: 0x06044E1B RID: 282139 RVA: 0x011ECED4 File Offset: 0x011EB0D4
		public virtual void Resume()
		{
		}

		// Token: 0x1700A445 RID: 42053
		// (get) Token: 0x06044E1C RID: 282140 RVA: 0x011ECED6 File Offset: 0x011EB0D6
		public EDollGrabMachineClawState ClawState
		{
			get
			{
				return this.StateInternal;
			}
		}

		// Token: 0x1700A446 RID: 42054
		// (get) Token: 0x06044E1D RID: 282141 RVA: 0x011ECEE0 File Offset: 0x011EB0E0
		public EDollGrabMachineClawState? TargetState
		{
			get
			{
				foreach (KeyValuePair<EDollGrabMachineClawState, Func<bool>> keyValuePair in this.NextStateMap)
				{
					if (keyValuePair.Value == null)
					{
						return new EDollGrabMachineClawState?(keyValuePair.Key);
					}
					if (keyValuePair.Value())
					{
						return new EDollGrabMachineClawState?(keyValuePair.Key);
					}
				}
				return null;
			}
		}

		// Token: 0x0402663B RID: 157243
		protected bool IsFirstEnter;

		// Token: 0x0402663C RID: 157244
		[Nullable(2)]
		protected SceneItemDollGrabMachineComponent Owner;

		// Token: 0x0402663D RID: 157245
		protected Vector OwnerLocation = Vector.Create();

		// Token: 0x0402663E RID: 157246
		protected Vector OwnerScale = Vector.Create();

		// Token: 0x0402663F RID: 157247
		protected Rotator OwnerRotation = Rotator.Create();

		// Token: 0x04026640 RID: 157248
		[Nullable(2)]
		protected AActor ClawActor;

		// Token: 0x04026641 RID: 157249
		[Nullable(2)]
		protected AActor ClawRootActor;

		// Token: 0x04026642 RID: 157250
		protected EDollGrabMachineClawState StateInternal;

		// Token: 0x04026643 RID: 157251
		[Nullable(new byte[]
		{
			1,
			2
		})]
		protected Dictionary<EDollGrabMachineClawState, Func<bool>> NextStateMap = new Dictionary<EDollGrabMachineClawState, Func<bool>>();
	}
}
