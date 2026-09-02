using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x0200491A RID: 18714
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class FloatingBaseState : StateBase<CharacterFloatingComponent, EFloatingMovementType>
	{
		// Token: 0x06030E9A RID: 200346 RVA: 0x00C22355 File Offset: 0x00C20555
		public FloatingBaseState(CharacterFloatingComponent owner, EFloatingMovementType state, [Nullable(new byte[]
		{
			2,
			1
		})] StateMachine<CharacterFloatingComponent, EFloatingMovementType> stateMachine = null) : base(owner, state, stateMachine)
		{
		}

		// Token: 0x06030E9B RID: 200347 RVA: 0x00C22360 File Offset: 0x00C20560
		protected override void OnEnter(EFloatingMovementType? lastState)
		{
			base.OnEnter(lastState);
			this.OnEnterInternal();
		}

		// Token: 0x06030E9C RID: 200348 RVA: 0x00C2236F File Offset: 0x00C2056F
		protected override void OnReEnter()
		{
			base.OnReEnter();
			this.OnEnterInternal();
		}

		// Token: 0x06030E9D RID: 200349 RVA: 0x00C2237D File Offset: 0x00C2057D
		public override bool CanReEnter()
		{
			return true;
		}

		// Token: 0x06030E9E RID: 200350 RVA: 0x00C22380 File Offset: 0x00C20580
		protected virtual bool CanContinueState()
		{
			return !this.Owner.TagComp.HasAnyTag(this.GetBannedStateConfigTagList());
		}

		// Token: 0x06030E9F RID: 200351 RVA: 0x00C2239B File Offset: 0x00C2059B
		public override bool CanChangeFrom(EFloatingMovementType fromState)
		{
			return base.CanChangeFrom(fromState) && this.CanContinueState();
		}

		// Token: 0x06030EA0 RID: 200352 RVA: 0x00C223AE File Offset: 0x00C205AE
		protected virtual void OnEnterInternal()
		{
			this.Owner.FloatingMoveType = this.State;
			this.SetMoveState();
			this.AddTagList();
			bool debug = CharacterFloatingComponent.Debug;
		}

		// Token: 0x06030EA1 RID: 200353 RVA: 0x00C223D3 File Offset: 0x00C205D3
		protected virtual void SetMoveState()
		{
			this.Owner.StateComp.SetMoveState(this.GetMoveState());
		}

		// Token: 0x06030EA2 RID: 200354 RVA: 0x00C223EB File Offset: 0x00C205EB
		protected virtual ECharMoveState GetMoveState()
		{
			return ECharMoveState.Other;
		}

		// Token: 0x06030EA3 RID: 200355 RVA: 0x00C223F0 File Offset: 0x00C205F0
		protected override void OnUpdate(float deltaSeconds)
		{
			base.OnUpdate(deltaSeconds);
			if (this.Owner.AnimComp.GetAnimInstance().HasKuroRootMotionAnim())
			{
				CharacterFloatingComponent owner = this.Owner;
				FVector fvector = this.Owner.ActorComp.ActorVelocity;
				owner.SpeedInternal = fvector.Size();
				this.Owner.FloatingMoveMixInternal = 0f;
				Vector moveDelta = this.Owner.MoveDelta;
				fvector = this.Owner.MoveComp.CharacterMovement.AnimRootMotionVelocity;
				FVectorDouble fvectorDouble = fvector;
				moveDelta.DeepCopy(fvectorDouble);
				this.Owner.MoveDelta.MultiplyEqual((double)deltaSeconds);
				this.Owner.CloseToGround(deltaSeconds);
				if (!this.Owner.MoveDelta.IsNearlyZero(9.999999747378752E-05))
				{
					this.Owner.MoveComp.MoveCharacter(this.Owner.MoveDelta, deltaSeconds, "CharacterFloatingComponent.Move");
				}
				this.UpdateMovementTagList(!this.Owner.MoveDelta.IsNearlyZero(9.999999747378752E-05));
				this.Owner.DetectFloor();
				this.Owner.CheckGround();
				this.Owner.ClearCacheInputDirect();
				return;
			}
			if (this.Owner.TagComp.HasAnyTag(this.Owner.Config.ForbidRotationTagList))
			{
				this.Owner.SpeedInternal = 0f;
				this.Owner.FloatingMoveMixInternal = 0f;
				this.UpdateMovementTagList(false);
				this.Owner.DetectFloor();
				this.Owner.CheckGround();
				this.Owner.ClearCacheInputDirect();
				return;
			}
			this.Owner.UpdateSpeed(deltaSeconds);
			this.UpdateActorRotation(deltaSeconds);
			this.UpdateActorLocation(deltaSeconds);
			this.UpdateMovementTagList(!this.Owner.MoveDelta.IsNearlyZero(9.999999747378752E-05));
			this.Owner.DetectFloor();
			this.Owner.CheckGround();
			this.PostUpdate();
		}

		// Token: 0x06030EA4 RID: 200356 RVA: 0x00C225E6 File Offset: 0x00C207E6
		protected virtual void PostUpdate()
		{
		}

		// Token: 0x06030EA5 RID: 200357 RVA: 0x00C225E8 File Offset: 0x00C207E8
		protected override void OnExit(EFloatingMovementType nextState)
		{
			base.OnExit(nextState);
			this.OnExitInternal();
		}

		// Token: 0x06030EA6 RID: 200358 RVA: 0x00C225F7 File Offset: 0x00C207F7
		protected void OnExitInternal()
		{
			this.RemoveTagList();
			this.RemoveMovementTagList();
		}

		// Token: 0x06030EA7 RID: 200359 RVA: 0x00C22605 File Offset: 0x00C20805
		protected virtual List<int> GetInStateConfigTagList()
		{
			return CharacterFloatingComponent.EmptyArray;
		}

		// Token: 0x06030EA8 RID: 200360 RVA: 0x00C2260C File Offset: 0x00C2080C
		protected virtual List<int> GetBannedStateConfigTagList()
		{
			return CharacterFloatingComponent.EmptyArray;
		}

		// Token: 0x06030EA9 RID: 200361 RVA: 0x00C22613 File Offset: 0x00C20813
		protected virtual List<int> GetMoveConfigTagList()
		{
			return CharacterFloatingComponent.EmptyArray;
		}

		// Token: 0x06030EAA RID: 200362 RVA: 0x00C2261A File Offset: 0x00C2081A
		protected virtual List<int> GetStandConfigTagList()
		{
			return CharacterFloatingComponent.EmptyArray;
		}

		// Token: 0x06030EAB RID: 200363 RVA: 0x00C22621 File Offset: 0x00C20821
		protected void UpdateActorRotation(float deltaSeconds)
		{
		}

		// Token: 0x06030EAC RID: 200364 RVA: 0x00C22624 File Offset: 0x00C20824
		protected virtual void UpdateActorLocation(float deltaSeconds)
		{
			this.Owner.UpdateMove(deltaSeconds, this.Owner.MoveDelta);
			this.Owner.CloseToGround(deltaSeconds);
			if (!this.Owner.MoveDelta.IsNearlyZero(9.999999747378752E-05))
			{
				this.Owner.MoveComp.MoveCharacter(this.Owner.MoveDelta, deltaSeconds * 1000f, "CharacterFloatingComponent.Move");
			}
		}

		// Token: 0x06030EAD RID: 200365 RVA: 0x00C22698 File Offset: 0x00C20898
		protected void AddTagList()
		{
			List<int> inStateConfigTagList = this.GetInStateConfigTagList();
			if (inStateConfigTagList.Count <= 0)
			{
				return;
			}
			foreach (int value in inStateConfigTagList)
			{
				this.Owner.TagComp.AddTag(new int?(value));
			}
		}

		// Token: 0x06030EAE RID: 200366 RVA: 0x00C22708 File Offset: 0x00C20908
		protected void RemoveTagList()
		{
			List<int> inStateConfigTagList = this.GetInStateConfigTagList();
			if (inStateConfigTagList.Count <= 0)
			{
				return;
			}
			foreach (int value in inStateConfigTagList)
			{
				this.Owner.TagComp.RemoveTag(new int?(value));
			}
		}

		// Token: 0x06030EAF RID: 200367 RVA: 0x00C22778 File Offset: 0x00C20978
		private void UpdateMovementTagList(bool isMove)
		{
			if (this.Owner.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中"]))
			{
				this.RemoveMovementTagList();
				return;
			}
			bool? isMoved = this.IsMoved;
			if (isMoved.GetValueOrDefault() == isMove & isMoved != null)
			{
				return;
			}
			this.IsMoved = new bool?(isMove);
			this.UpdateMoveTagList(isMove);
			this.UpdateStandTagList(!isMove);
		}

		// Token: 0x06030EB0 RID: 200368 RVA: 0x00C227E8 File Offset: 0x00C209E8
		private void RemoveMovementTagList()
		{
			this.UpdateMoveTagList(false);
			this.UpdateStandTagList(false);
			this.IsMoved = null;
		}

		// Token: 0x06030EB1 RID: 200369 RVA: 0x00C22804 File Offset: 0x00C20A04
		private void UpdateMoveTagList(bool isAdd)
		{
			List<int> moveConfigTagList = this.GetMoveConfigTagList();
			if (moveConfigTagList.Count <= 0)
			{
				return;
			}
			foreach (int value in moveConfigTagList)
			{
				if (isAdd)
				{
					this.Owner.TagComp.AddTag(new int?(value));
				}
				else
				{
					this.Owner.TagComp.RemoveTag(new int?(value));
				}
			}
		}

		// Token: 0x06030EB2 RID: 200370 RVA: 0x00C22890 File Offset: 0x00C20A90
		private void UpdateStandTagList(bool isAdd)
		{
			List<int> standConfigTagList = this.GetStandConfigTagList();
			if (standConfigTagList.Count <= 0)
			{
				return;
			}
			foreach (int value in standConfigTagList)
			{
				if (isAdd)
				{
					this.Owner.TagComp.AddTag(new int?(value));
				}
				else
				{
					this.Owner.TagComp.RemoveTag(new int?(value));
				}
			}
		}

		// Token: 0x0401C23E RID: 115262
		protected bool? IsMoved;
	}
}
