using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200491C RID: 18716
	[NullableContext(1)]
	[Nullable(0)]
	internal class FloatingState : FloatingBaseState
	{
		// Token: 0x06030EBC RID: 200380 RVA: 0x00C229FF File Offset: 0x00C20BFF
		public FloatingState(CharacterFloatingComponent owner, EFloatingMovementType state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CharacterFloatingComponent, EFloatingMovementType> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06030EBD RID: 200381 RVA: 0x00C22A0A File Offset: 0x00C20C0A
		protected override void OnEnterInternal()
		{
			base.OnEnterInternal();
			this.Owner.DetectFloor();
			this.Owner.CheckGround();
		}

		// Token: 0x06030EBE RID: 200382 RVA: 0x00C22A29 File Offset: 0x00C20C29
		protected override ECharMoveState GetMoveState()
		{
			return ECharMoveState.Floating;
		}

		// Token: 0x06030EBF RID: 200383 RVA: 0x00C22A2D File Offset: 0x00C20C2D
		protected override List<int> GetInStateConfigTagList()
		{
			return this.Owner.Config.FloatingMoveModeConfig.MovementTagList;
		}

		// Token: 0x06030EC0 RID: 200384 RVA: 0x00C22A44 File Offset: 0x00C20C44
		protected override List<int> GetBannedStateConfigTagList()
		{
			return this.Owner.Config.FloatingMoveModeConfig.BannedMovementTagList;
		}

		// Token: 0x06030EC1 RID: 200385 RVA: 0x00C22A5B File Offset: 0x00C20C5B
		protected override List<int> GetMoveConfigTagList()
		{
			return this.Owner.Config.FloatingMoveModeConfig.MoveTagList;
		}

		// Token: 0x06030EC2 RID: 200386 RVA: 0x00C22A72 File Offset: 0x00C20C72
		protected override List<int> GetStandConfigTagList()
		{
			return this.Owner.Config.FloatingMoveModeConfig.StandTagList;
		}

		// Token: 0x06030EC3 RID: 200387 RVA: 0x00C22A89 File Offset: 0x00C20C89
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
	}
}
