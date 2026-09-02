using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200491F RID: 18719
	[NullableContext(1)]
	[Nullable(0)]
	internal class WalkState : FloatingBaseState
	{
		// Token: 0x06030ED9 RID: 200409 RVA: 0x00C22E4E File Offset: 0x00C2104E
		public WalkState(CharacterFloatingComponent owner, EFloatingMovementType state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CharacterFloatingComponent, EFloatingMovementType> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06030EDA RID: 200410 RVA: 0x00C22E59 File Offset: 0x00C21059
		protected override void OnEnterInternal()
		{
			base.OnEnterInternal();
			this.Owner.DetectFloor();
			this.Owner.CheckGround();
		}

		// Token: 0x06030EDB RID: 200411 RVA: 0x00C22E78 File Offset: 0x00C21078
		protected override ECharMoveState GetMoveState()
		{
			return ECharMoveState.FloatingGround;
		}

		// Token: 0x06030EDC RID: 200412 RVA: 0x00C22E7C File Offset: 0x00C2107C
		protected override List<int> GetInStateConfigTagList()
		{
			return this.Owner.Config.WalkMoveModeConfig.MovementTagList;
		}

		// Token: 0x06030EDD RID: 200413 RVA: 0x00C22E93 File Offset: 0x00C21093
		protected override List<int> GetBannedStateConfigTagList()
		{
			return this.Owner.Config.WalkMoveModeConfig.BannedMovementTagList;
		}

		// Token: 0x06030EDE RID: 200414 RVA: 0x00C22EAA File Offset: 0x00C210AA
		protected override List<int> GetMoveConfigTagList()
		{
			return this.Owner.Config.WalkMoveModeConfig.MoveTagList;
		}

		// Token: 0x06030EDF RID: 200415 RVA: 0x00C22EC1 File Offset: 0x00C210C1
		protected override List<int> GetStandConfigTagList()
		{
			return this.Owner.Config.WalkMoveModeConfig.StandTagList;
		}

		// Token: 0x06030EE0 RID: 200416 RVA: 0x00C22ED8 File Offset: 0x00C210D8
		protected override void OnUpdate(float deltaSeconds)
		{
			if (!this.CanContinueState())
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.StateMachine.Switch(EFloatingMovementType.Floating);
				return;
			}
			base.OnUpdate(deltaSeconds);
		}

		// Token: 0x06030EE1 RID: 200417 RVA: 0x00C22F00 File Offset: 0x00C21100
		protected override void PostUpdate()
		{
			CharacterFloatingComponent owner = this.Owner;
			if (owner != null && !owner.IsOnGround && !owner.IsOnWater)
			{
				bool debug = CharacterFloatingComponent.Debug;
				this.StateMachine.Switch(EFloatingMovementType.Drop);
			}
		}
	}
}
