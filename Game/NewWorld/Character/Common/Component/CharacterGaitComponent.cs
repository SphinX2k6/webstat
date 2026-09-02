using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004900 RID: 18688
	[NullableContext(2)]
	[Nullable(0)]
	public class CharacterGaitComponent : EntityComponent
	{
		// Token: 0x06030CE9 RID: 199913 RVA: 0x00C11BDC File Offset: 0x00C0FDDC
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
			this.UnifiedStateComponent = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
			return this.ActorComp != null && this.MoveComp != null && this.UnifiedStateComponent != null;
		}

		// Token: 0x06030CEA RID: 199914 RVA: 0x00C11C38 File Offset: 0x00C0FE38
		protected override void OnTick(float delta)
		{
			if (!this.ActorComp.IsAutonomousProxy)
			{
				return;
			}
			ECharMoveState moveState = this.UnifiedStateComponent.MoveState;
			ECharPositionState positionState = this.UnifiedStateComponent.PositionState;
			if (!this.MoveComp.HasMoveInput)
			{
				this.UpdateMoveReleasing(positionState, moveState);
			}
		}

		// Token: 0x06030CEB RID: 199915 RVA: 0x00C11C80 File Offset: 0x00C0FE80
		protected void UpdateMoveReleasing(ECharPositionState positionState, ECharMoveState moveState)
		{
			if (positionState == ECharPositionState.Ground)
			{
				switch (moveState)
				{
				case ECharMoveState.WalkStop:
				case ECharMoveState.RunStop:
				case ECharMoveState.SprintStop:
					if (this.MoveComp.Speed < 5f)
					{
						this.UnifiedStateComponent.SetMoveState(ECharMoveState.Other);
						return;
					}
					return;
				}
				if (this.MoveComp.Speed > 5f)
				{
					this.SetRunStop();
				}
			}
		}

		// Token: 0x06030CEC RID: 199916 RVA: 0x00C11CE8 File Offset: 0x00C0FEE8
		protected void SetRunStop()
		{
			switch (this.UnifiedStateComponent.MoveState)
			{
			case ECharMoveState.Walk:
				this.UnifiedStateComponent.SetMoveState(ECharMoveState.WalkStop);
				return;
			case ECharMoveState.WalkStop:
			case ECharMoveState.RunStop:
			case ECharMoveState.SprintStop:
				break;
			case ECharMoveState.Run:
			case ECharMoveState.Sprint:
			case ECharMoveState.Dodge:
			case ECharMoveState.LandRoll:
				if (this.MoveComp.Speed < this.MoveComp.MovementData.FaceDirection.Standing.SprintSpeed - 150f)
				{
					this.UnifiedStateComponent.SetMoveState(ECharMoveState.RunStop);
					return;
				}
				this.UnifiedStateComponent.SetMoveState(ECharMoveState.SprintStop);
				break;
			default:
				return;
			}
		}

		// Token: 0x06030CED RID: 199917 RVA: 0x00C11D80 File Offset: 0x00C0FF80
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterGaitComponent characterGaitComponent = (CharacterGaitComponent)componentTemplate;
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterGaitComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (characterGaitComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("UnifiedStateComponent"))
			{
				if (characterGaitComponent.UnifiedStateComponent == null)
				{
					this.UnifiedStateComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401C0C7 RID: 114887
		private const int STOP_SPEED = 5;

		// Token: 0x0401C0C8 RID: 114888
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C0C9 RID: 114889
		private CharacterMoveComponent MoveComp;

		// Token: 0x0401C0CA RID: 114890
		private CharacterUnifiedStateComponent UnifiedStateComponent;
	}
}
