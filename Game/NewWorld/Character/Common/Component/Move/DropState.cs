using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200491E RID: 18718
	[NullableContext(1)]
	[Nullable(0)]
	internal class DropState : FloatingBaseState
	{
		// Token: 0x06030ECE RID: 200398 RVA: 0x00C22C50 File Offset: 0x00C20E50
		public DropState(CharacterFloatingComponent owner, EFloatingMovementType state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CharacterFloatingComponent, EFloatingMovementType> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06030ECF RID: 200399 RVA: 0x00C22C5B File Offset: 0x00C20E5B
		protected override void OnEnterInternal()
		{
			base.OnEnterInternal();
			this.Owner.DetectFloor();
			this.Owner.CheckGround();
		}

		// Token: 0x06030ED0 RID: 200400 RVA: 0x00C22C7A File Offset: 0x00C20E7A
		protected override ECharMoveState GetMoveState()
		{
			return ECharMoveState.Drop;
		}

		// Token: 0x06030ED1 RID: 200401 RVA: 0x00C22C80 File Offset: 0x00C20E80
		protected override bool CanContinueState()
		{
			if (!base.CanContinueState())
			{
				return false;
			}
			CharacterFloatingComponent owner = this.Owner;
			return owner != null && !owner.IsOnGround && !owner.IsOnWater;
		}

		// Token: 0x06030ED2 RID: 200402 RVA: 0x00C22CB4 File Offset: 0x00C20EB4
		protected override List<int> GetInStateConfigTagList()
		{
			return this.Owner.Config.DropMoveModeConfig.MovementTagList;
		}

		// Token: 0x06030ED3 RID: 200403 RVA: 0x00C22CCB File Offset: 0x00C20ECB
		protected override List<int> GetBannedStateConfigTagList()
		{
			return this.Owner.Config.DropMoveModeConfig.BannedMovementTagList;
		}

		// Token: 0x06030ED4 RID: 200404 RVA: 0x00C22CE2 File Offset: 0x00C20EE2
		protected override List<int> GetMoveConfigTagList()
		{
			return this.Owner.Config.DropMoveModeConfig.MoveTagList;
		}

		// Token: 0x06030ED5 RID: 200405 RVA: 0x00C22CF9 File Offset: 0x00C20EF9
		protected override List<int> GetStandConfigTagList()
		{
			return this.Owner.Config.DropMoveModeConfig.StandTagList;
		}

		// Token: 0x06030ED6 RID: 200406 RVA: 0x00C22D10 File Offset: 0x00C20F10
		protected override void OnUpdate(float deltaSeconds)
		{
			if (!this.CanContinueState())
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.StateMachine.Switch(EFloatingMovementType.Walk);
				return;
			}
			base.OnUpdate(deltaSeconds);
		}

		// Token: 0x06030ED7 RID: 200407 RVA: 0x00C22D38 File Offset: 0x00C20F38
		protected override void UpdateActorLocation(float deltaSeconds)
		{
			this.Owner.UpdateMove(deltaSeconds, this.Owner.MoveDelta);
			this.Owner.TempVector2.DeepCopy(this.Owner.MoveComp.GravityDirect);
			this.Owner.TempVector2.MultiplyEqual((double)(this.Owner.Config.DropSpeed * deltaSeconds));
			this.Owner.MoveDelta.AdditionEqual(this.Owner.TempVector2);
			if (!this.Owner.MoveDelta.IsNearlyZero(9.999999747378752E-05))
			{
				this.Owner.MoveComp.MoveCharacter(this.Owner.MoveDelta, deltaSeconds * 1000f, "CharacterFloatingComponent.Move");
			}
		}

		// Token: 0x06030ED8 RID: 200408 RVA: 0x00C22E00 File Offset: 0x00C21000
		protected override void PostUpdate()
		{
			if (this.Owner.IsOnGround || this.Owner.IsOnWater)
			{
				bool debug = CharacterFloatingComponent.Debug;
				if (!this.StateMachine.Switch(EFloatingMovementType.Floating))
				{
					bool debug2 = CharacterFloatingComponent.Debug;
					this.StateMachine.Switch(EFloatingMovementType.Walk);
				}
			}
		}
	}
}
