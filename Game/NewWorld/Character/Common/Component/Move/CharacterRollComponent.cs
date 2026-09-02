using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004937 RID: 18743
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterRollComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x170083A5 RID: 33701
		// (get) Token: 0x06031039 RID: 200761 RVA: 0x00C2D380 File Offset: 0x00C2B580
		public static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(CharacterMoveComponent)
				};
			}
		}

		// Token: 0x0603103A RID: 200762 RVA: 0x00C2D398 File Offset: 0x00C2B598
		private void OnMoveRoll(float deltaSeconds)
		{
			UKuroMovementBPLibrary.KuroRoll(deltaSeconds, this.MoveComp.CharacterMovement, this.TargetSpeed, this.Friction, this.AccelOnGround, ref this.RefFloorNormal, this.Gravity, this.StepUpHeight, this.MaxSpeed);
		}

		// Token: 0x0603103B RID: 200763 RVA: 0x00C2D3E1 File Offset: 0x00C2B5E1
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603103C RID: 200764 RVA: 0x00C2D3E4 File Offset: 0x00C2B5E4
		protected override bool OnStart()
		{
			this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
			Singleton<EventSystem>.Instance.AddWithTarget<float>(base.Entity, EEventName.CustomMoveRoll, new Action<float>(this.OnMoveRoll));
			return true;
		}

		// Token: 0x0603103D RID: 200765 RVA: 0x00C2D417 File Offset: 0x00C2B617
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<float>(base.Entity, EEventName.CustomMoveRoll, new Action<float>(this.OnMoveRoll));
			return true;
		}

		// Token: 0x0603103E RID: 200766 RVA: 0x00C2D43C File Offset: 0x00C2B63C
		public void EnterRoll(float targetSpeed, float friction, float accelOnGround, float gravity, float stepUpHeight, float maxSpeed)
		{
			this.TargetSpeed = targetSpeed;
			this.Friction = friction;
			this.AccelOnGround = accelOnGround;
			this.Gravity = gravity;
			this.StepUpHeight = stepUpHeight;
			this.MaxSpeed = maxSpeed;
			CharacterMoveComponent moveComp = this.MoveComp;
			if (moveComp == null)
			{
				return;
			}
			CharacterActorComponent actorComp = moveComp.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Custom,
				CustomMode = 9,
				Context = "[CharacterRollComponent.EnterRoll]"
			});
		}

		// Token: 0x0603103F RID: 200767 RVA: 0x00C2D4B4 File Offset: 0x00C2B6B4
		public void LeaveRoll()
		{
			CharacterMoveComponent moveComp = this.MoveComp;
			if (moveComp == null)
			{
				return;
			}
			CharacterActorComponent actorComp = moveComp.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[CharacterRollComponent.LeaveRoll]"
			});
		}

		// Token: 0x06031040 RID: 200768 RVA: 0x00C2D4EC File Offset: 0x00C2B6EC
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterRollComponent characterRollComponent = (CharacterRollComponent)componentTemplate;
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (characterRollComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RefFloorNormal"))
			{
				this.RefFloorNormal = characterRollComponent.RefFloorNormal;
			}
			if (base.CanResetComponentProperty("TargetSpeed"))
			{
				this.TargetSpeed = characterRollComponent.TargetSpeed;
			}
			if (base.CanResetComponentProperty("Friction"))
			{
				this.Friction = characterRollComponent.Friction;
			}
			if (base.CanResetComponentProperty("AccelOnGround"))
			{
				this.AccelOnGround = characterRollComponent.AccelOnGround;
			}
			if (base.CanResetComponentProperty("Gravity"))
			{
				this.Gravity = characterRollComponent.Gravity;
			}
			if (base.CanResetComponentProperty("StepUpHeight"))
			{
				this.StepUpHeight = characterRollComponent.StepUpHeight;
			}
			if (base.CanResetComponentProperty("MaxSpeed"))
			{
				this.MaxSpeed = characterRollComponent.MaxSpeed;
			}
			return true;
		}

		// Token: 0x0401C355 RID: 115541
		[Nullable(2)]
		private CharacterMoveComponent MoveComp;

		// Token: 0x0401C356 RID: 115542
		private FVector RefFloorNormal = new FVector();

		// Token: 0x0401C357 RID: 115543
		private float TargetSpeed = 1200f;

		// Token: 0x0401C358 RID: 115544
		private float Friction = 0.1f;

		// Token: 0x0401C359 RID: 115545
		private float AccelOnGround = 1000f;

		// Token: 0x0401C35A RID: 115546
		private float Gravity = 1960f;

		// Token: 0x0401C35B RID: 115547
		private float StepUpHeight = 100f;

		// Token: 0x0401C35C RID: 115548
		private float MaxSpeed = 4000f;
	}
}
