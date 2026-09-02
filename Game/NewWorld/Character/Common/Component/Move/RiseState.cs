using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200491D RID: 18717
	[NullableContext(1)]
	[Nullable(0)]
	internal class RiseState : FloatingBaseState
	{
		// Token: 0x06030EC4 RID: 200388 RVA: 0x00C22AAE File Offset: 0x00C20CAE
		public RiseState(CharacterFloatingComponent owner, EFloatingMovementType state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CharacterFloatingComponent, EFloatingMovementType> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06030EC5 RID: 200389 RVA: 0x00C22AB9 File Offset: 0x00C20CB9
		protected override void OnEnterInternal()
		{
			base.OnEnterInternal();
			this.Owner.CheckGround();
		}

		// Token: 0x06030EC6 RID: 200390 RVA: 0x00C22ACC File Offset: 0x00C20CCC
		protected override ECharMoveState GetMoveState()
		{
			return ECharMoveState.Rise;
		}

		// Token: 0x06030EC7 RID: 200391 RVA: 0x00C22AD0 File Offset: 0x00C20CD0
		protected override List<int> GetInStateConfigTagList()
		{
			return this.Owner.Config.RiseMoveModeConfig.MovementTagList;
		}

		// Token: 0x06030EC8 RID: 200392 RVA: 0x00C22AE7 File Offset: 0x00C20CE7
		protected override List<int> GetBannedStateConfigTagList()
		{
			return this.Owner.Config.RiseMoveModeConfig.BannedMovementTagList;
		}

		// Token: 0x06030EC9 RID: 200393 RVA: 0x00C22AFE File Offset: 0x00C20CFE
		protected override List<int> GetMoveConfigTagList()
		{
			return this.Owner.Config.RiseMoveModeConfig.MoveTagList;
		}

		// Token: 0x06030ECA RID: 200394 RVA: 0x00C22B15 File Offset: 0x00C20D15
		protected override List<int> GetStandConfigTagList()
		{
			return this.Owner.Config.RiseMoveModeConfig.StandTagList;
		}

		// Token: 0x06030ECB RID: 200395 RVA: 0x00C22B2C File Offset: 0x00C20D2C
		protected override void OnUpdate(float deltaSeconds)
		{
			if (!this.CanContinueState())
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.StateMachine.Switch(EFloatingMovementType.Drop);
				return;
			}
			base.OnUpdate(deltaSeconds);
		}

		// Token: 0x06030ECC RID: 200396 RVA: 0x00C22B54 File Offset: 0x00C20D54
		protected override void UpdateActorLocation(float deltaSeconds)
		{
			this.Owner.UpdateMove(deltaSeconds, this.Owner.MoveDelta);
			this.Owner.TempVector2.DeepCopy(this.Owner.MoveComp.GravityUp);
			this.Owner.TempVector2.MultiplyEqual((double)(this.Owner.Config.RiseSpeed * deltaSeconds));
			this.Owner.MoveDelta.AdditionEqual(this.Owner.TempVector2);
			if (!this.Owner.MoveDelta.IsNearlyZero(9.999999747378752E-05))
			{
				this.Owner.MoveComp.MoveCharacter(this.Owner.MoveDelta, deltaSeconds * 1000f, "CharacterFloatingComponent.Move");
			}
		}

		// Token: 0x06030ECD RID: 200397 RVA: 0x00C22C1A File Offset: 0x00C20E1A
		protected override void PostUpdate()
		{
			if (this.Owner.DetectCeiling() != null)
			{
				bool debug = CharacterFloatingComponent.Debug;
				if (this.StateMachine.Switch(EFloatingMovementType.Floating))
				{
					bool debug2 = CharacterFloatingComponent.Debug;
					this.StateMachine.Switch(EFloatingMovementType.Drop);
				}
			}
		}
	}
}
