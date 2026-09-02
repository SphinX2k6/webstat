using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004913 RID: 18707
	[NullableContext(1)]
	[Nullable(0)]
	public class StackableChessComponent : EntityComponent, IStackableChessAgent, IChessAgent
	{
		// Token: 0x06030E30 RID: 200240 RVA: 0x00C1D179 File Offset: 0x00C1B379
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.CheckGetComponent<BaseActorComponent>();
			return true;
		}

		// Token: 0x06030E31 RID: 200241 RVA: 0x00C1D18D File Offset: 0x00C1B38D
		[NullableContext(2)]
		public virtual Vector GetStackableLocation()
		{
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return null;
			}
			return actorComp.ActorLocationProxy;
		}

		// Token: 0x06030E32 RID: 200242 RVA: 0x00C1D1A0 File Offset: 0x00C1B3A0
		[NullableContext(2)]
		public virtual Rotator GetStackableRotator(bool isSameDirection)
		{
			if (this.ActorComp == null)
			{
				return null;
			}
			if (isSameDirection)
			{
				return this.ActorComp.ActorRotationProxy;
			}
			if (this.TargetVector == null)
			{
				this.TargetVector = Vector.Create();
			}
			if (this.TargetRotator == null)
			{
				this.TargetRotator = Rotator.Create();
			}
			Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
			Vector actorUpProxy = this.ActorComp.ActorUpProxy;
			actorForwardProxy.RotateAngleAxis(180.0, actorUpProxy, this.TargetVector);
			this.TargetVector.Rotation(this.TargetRotator);
			return this.TargetRotator;
		}

		// Token: 0x06030E33 RID: 200243 RVA: 0x00C1D230 File Offset: 0x00C1B430
		public void AttachToTarget(IStackableChessAgent target)
		{
			BaseActorComponent actorComp = ((StackableChessComponent)target).ActorComp;
			BaseActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 == null || !actorComp2.Valid || (actorComp == null || !actorComp.Valid))
			{
				return;
			}
			FName? attachSocketName = this.GetAttachSocketName();
			if (attachSocketName == null)
			{
				return;
			}
			AActor owner = this.ActorComp.Owner;
			if (owner == null)
			{
				return;
			}
			owner.K2_AttachToComponent(actorComp.SkeletalMesh, attachSocketName.Value, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true);
		}

		// Token: 0x06030E34 RID: 200244 RVA: 0x00C1D2AA File Offset: 0x00C1B4AA
		public void DetachFromTarget(IStackableChessAgent target)
		{
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.Valid)
			{
				return;
			}
			AActor owner = this.ActorComp.Owner;
			if (owner == null)
			{
				return;
			}
			owner.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
		}

		// Token: 0x06030E35 RID: 200245 RVA: 0x00C1D2DC File Offset: 0x00C1B4DC
		public virtual void Move(Vector location, Rotator rotator, bool performIsForward, Action finishCallback)
		{
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.SetActorLocationAndRotation(location.ToUeVector(false), rotator.ToUeRotator(), "ChessMove", false, null);
			}
			finishCallback();
		}

		// Token: 0x06030E36 RID: 200246 RVA: 0x00C1D320 File Offset: 0x00C1B520
		public virtual void Teleport(Vector location, Rotator rotator)
		{
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.SetActorLocationAndRotation(location.ToUeVector(false), rotator.ToUeRotator(), "ChessTeleport", false, null);
		}

		// Token: 0x06030E37 RID: 200247 RVA: 0x00C1D35A File Offset: 0x00C1B55A
		public virtual void OnPreviousMoveStateChange(IStackableChessAgent agent, bool isMoving, bool previousIsForward, bool isSameDirection)
		{
		}

		// Token: 0x06030E38 RID: 200248 RVA: 0x00C1D35C File Offset: 0x00C1B55C
		public virtual bool IsPerformRecursion(int type)
		{
			return false;
		}

		// Token: 0x06030E39 RID: 200249 RVA: 0x00C1D35F File Offset: 0x00C1B55F
		public virtual void Perform(int type, [Nullable(2)] Vector pointLocation, Action finishCallback)
		{
			finishCallback();
		}

		// Token: 0x06030E3A RID: 200250 RVA: 0x00C1D367 File Offset: 0x00C1B567
		public virtual void OnPreviousPerformStateChange(IStackableChessAgent agent, int type, bool isPerforming)
		{
		}

		// Token: 0x06030E3B RID: 200251 RVA: 0x00C1D369 File Offset: 0x00C1B569
		[NullableContext(2)]
		public Vector GetLocation()
		{
			BaseActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return null;
			}
			return actorComp.ActorLocationProxy;
		}

		// Token: 0x06030E3C RID: 200252 RVA: 0x00C1D37C File Offset: 0x00C1B57C
		protected virtual FName? GetAttachSocketName()
		{
			return null;
		}

		// Token: 0x06030E3D RID: 200253 RVA: 0x00C1D394 File Offset: 0x00C1B594
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			StackableChessComponent stackableChessComponent = (StackableChessComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (stackableChessComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetVector"))
			{
				if (stackableChessComponent.TargetVector == null)
				{
					this.TargetVector = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TargetVector), "TargetVector"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetRotator"))
			{
				if (stackableChessComponent.TargetRotator == null)
				{
					this.TargetRotator = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TargetRotator), "TargetRotator"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C1A5 RID: 115109
		[Nullable(2)]
		protected BaseActorComponent ActorComp;

		// Token: 0x0401C1A6 RID: 115110
		[Nullable(2)]
		private Vector TargetVector;

		// Token: 0x0401C1A7 RID: 115111
		[Nullable(2)]
		private Rotator TargetRotator;
	}
}
