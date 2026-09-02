using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200491B RID: 18715
	[NullableContext(1)]
	[Nullable(0)]
	internal class DefaultState : FloatingBaseState
	{
		// Token: 0x06030EB3 RID: 200371 RVA: 0x00C2291C File Offset: 0x00C20B1C
		public DefaultState(CharacterFloatingComponent owner, EFloatingMovementType state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CharacterFloatingComponent, EFloatingMovementType> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06030EB4 RID: 200372 RVA: 0x00C22927 File Offset: 0x00C20B27
		protected override void OnEnterInternal()
		{
			base.OnEnterInternal();
			this.Owner.DetectFloor();
			this.Owner.CheckGround();
		}

		// Token: 0x06030EB5 RID: 200373 RVA: 0x00C22946 File Offset: 0x00C20B46
		protected override void SetMoveState()
		{
			if (CharacterFloatingComponent.BeHitMoveStateList.Contains(this.Owner.StateComp.MoveState))
			{
				return;
			}
			this.Owner.StateComp.SetMoveState(this.GetMoveState());
		}

		// Token: 0x06030EB6 RID: 200374 RVA: 0x00C2297B File Offset: 0x00C20B7B
		protected override ECharMoveState GetMoveState()
		{
			return ECharMoveState.Other;
		}

		// Token: 0x06030EB7 RID: 200375 RVA: 0x00C2297E File Offset: 0x00C20B7E
		protected override List<int> GetInStateConfigTagList()
		{
			return this.Owner.Config.DefaultMoveModeConfig.MovementTagList;
		}

		// Token: 0x06030EB8 RID: 200376 RVA: 0x00C22995 File Offset: 0x00C20B95
		protected override List<int> GetBannedStateConfigTagList()
		{
			return this.Owner.Config.DefaultMoveModeConfig.BannedMovementTagList;
		}

		// Token: 0x06030EB9 RID: 200377 RVA: 0x00C229AC File Offset: 0x00C20BAC
		protected override List<int> GetMoveConfigTagList()
		{
			return this.Owner.Config.DefaultMoveModeConfig.MoveTagList;
		}

		// Token: 0x06030EBA RID: 200378 RVA: 0x00C229C3 File Offset: 0x00C20BC3
		protected override List<int> GetStandConfigTagList()
		{
			return this.Owner.Config.DefaultMoveModeConfig.StandTagList;
		}

		// Token: 0x06030EBB RID: 200379 RVA: 0x00C229DA File Offset: 0x00C20BDA
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
