using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk
{
	// Token: 0x02004944 RID: 18756
	[NullableContext(1)]
	[Nullable(0)]
	public class AssistedWalkLeaderLogic : AttachMoveLogic
	{
		// Token: 0x170083A8 RID: 33704
		// (get) Token: 0x0603108B RID: 200843 RVA: 0x00C3025F File Offset: 0x00C2E45F
		// (set) Token: 0x0603108C RID: 200844 RVA: 0x00C3026C File Offset: 0x00C2E46C
		[Nullable(2)]
		protected new AssistedWalkParams Params
		{
			[NullableContext(2)]
			get
			{
				return this.Params as AssistedWalkParams;
			}
			[NullableContext(2)]
			set
			{
				this.Params = value;
			}
		}

		// Token: 0x0603108D RID: 200845 RVA: 0x00C30278 File Offset: 0x00C2E478
		public override void StopMove()
		{
			Action exitCallback = this.ExitCallback;
			this.ExitCallback = null;
			if (!this.InState)
			{
				this.ClearLeaderAssistedWalkTag();
				this.ClearLeaderComponents();
				if (exitCallback != null)
				{
					exitCallback();
				}
				return;
			}
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.ClearInput(false, true);
			}
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				TsBaseCharacter actor = actorComp2.Actor;
				if (actor != null)
				{
					actor.SetAnimRootMotionTranslationScale(1f);
				}
			}
			if (this.ArePartnerComponentsAlive())
			{
				this.ResetLeaderState();
				this.WriteAnimLogicParams(false, true);
			}
			this.AnimInstance = null;
			Singleton<AssistedWalkUtils>.Instance.RestoreSightLockMode(this.ActorComp, this.LastSightLockMode);
			this.ClearLeaderAssistedWalkTag();
			BaseTagComponent tagComp = this.TagComp;
			AssistedWalkParams @params = this.Params;
			base.RemoveTags(tagComp, (@params != null) ? @params.LeaderGameplayTagList : null);
			this.DetachFollowerFromLeader();
			this.RestoreLeaderCapsule();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[AttachMove][AssistedWalk][Leader] StopMove";
			string item = "PbDataId";
			CharacterActorComponent actorComp3 = this.ActorComp;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp3 != null) ? new int?(actorComp3.CreatureData.GetPbDataId()) : null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.StopMove();
			this.ClearLeaderComponents();
			if (exitCallback != null)
			{
				exitCallback();
			}
		}

		// Token: 0x0603108E RID: 200846 RVA: 0x00C303AC File Offset: 0x00C2E5AC
		public void StartLeaderAssistedWalkWithData(Entity entity, BP_AssistedWalkConfig_C data, [Nullable(2)] Action endCallback = null, bool waitAnim = true)
		{
			if (this.InState)
			{
				this.StopMove();
			}
			this.InitComponents(entity);
			if (this.MoveComp == null || this.AnimComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AttachMove][AssistedWalk][Leader] Start 组件无效";
				string item = "PbDataId";
				CharacterActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			base.PrepareAttachMove(entity, data, endCallback);
			this.Params = new AssistedWalkParams(data);
			CharacterActorComponent actorComp2 = this.ActorComp;
			if (actorComp2 != null)
			{
				actorComp2.ClearInput(false, true);
			}
			this.AnimInstance = (this.AnimComp.MainAnimInstance as UKuroAnimInstanceChar);
			this.WriteAnimLogicParams(true, waitAnim);
			this.AssistedWalkTagId = GameplayTagDefine.EGameplayTagId["角色.Common.地区运动状态.搀扶行走"];
			base.SetOnlyTag(this.TagComp, this.AssistedWalkTagId, true, "[AttachMove][AssistedWalk][Leader] Start");
			base.AddTags(this.TagComp, this.Params.LeaderGameplayTagList);
			this.MoveComp.SetMaxSpeed(this.Params.BaseMoveSpeed);
			this.LastMoveSpeed2D = 0f;
			this.HasLastInput = false;
			this.AnimInAssistedWalking = false;
			this.ClearLeaderDrivenFollowerState();
			this.LastSightLockMode = Singleton<AssistedWalkUtils>.Instance.SaveAndDisableSightLockMode(this.ActorComp);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "[AttachMove][AssistedWalk][Leader] StartMove";
			string item2 = "PbDataId";
			CharacterActorComponent actorComp3 = this.ActorComp;
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item2, (actorComp3 != null) ? new int?(actorComp3.CreatureData.GetPbDataId()) : null);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x0603108F RID: 200847 RVA: 0x00C30554 File Offset: 0x00C2E754
		public override void UpdateMove(float deltaSeconds)
		{
			if (!this.InState)
			{
				return;
			}
			if (this.MoveComp == null || this.AnimComp == null || this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AttachMove][AssistedWalk][Leader] UpdateMove 组件无效";
				string item = "PbDataId";
				CharacterActorComponent actorComp = this.ActorComp;
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (actorComp != null) ? new int?(actorComp.CreatureData.GetPbDataId()) : null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.UpdateLeaderMove(deltaSeconds);
			this.UpdateLeaderPositionCorrection(deltaSeconds);
			this.WriteAnimLogicParamsPerFrame();
		}

		// Token: 0x06031090 RID: 200848 RVA: 0x00C305E6 File Offset: 0x00C2E7E6
		public override bool IsMoving()
		{
			return this.InState;
		}

		// Token: 0x06031091 RID: 200849 RVA: 0x00C305EE File Offset: 0x00C2E7EE
		public override void Dispose()
		{
			this.StopMove();
		}

		// Token: 0x06031092 RID: 200850 RVA: 0x00C305F6 File Offset: 0x00C2E7F6
		public override void StartAssistedWalk()
		{
			this.StartLeaderPositionCorrectionByNotify();
			this.ActorComp.Actor.SetAnimRootMotionTranslationScale(0f);
		}

		// Token: 0x06031093 RID: 200851 RVA: 0x00C30613 File Offset: 0x00C2E813
		public override void EnterAssistedWalkIdle()
		{
			this.ExecuteFollowerAttachByNotify();
			this.ActorComp.Actor.SetAnimRootMotionTranslationScale(1f);
		}

		// Token: 0x06031094 RID: 200852 RVA: 0x00C30630 File Offset: 0x00C2E830
		public override void EnterAssistedWalking()
		{
			if (!this.InState)
			{
				return;
			}
			this.AnimInAssistedWalking = true;
		}

		// Token: 0x06031095 RID: 200853 RVA: 0x00C30642 File Offset: 0x00C2E842
		public override void LeftAssistedWalking()
		{
			if (!this.InState)
			{
				return;
			}
			this.AnimInAssistedWalking = false;
			this.HasLastInput = false;
		}

		// Token: 0x06031096 RID: 200854 RVA: 0x00C3065C File Offset: 0x00C2E85C
		private void UpdateLeaderMove(float deltaSeconds)
		{
			float maxDeltaSeconds = Math.Min(deltaSeconds * 1000f * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation, 166f) * 0.001f;
			this.ActorComp.SetOverrideTurnSpeed(new float?(this.AssistedWalkParams.LeaderTurnSpeed));
			this.LastMoveSpeed2D = 0f;
			Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
			UAnimInstance shellAnimInstance = this.AnimComp.ShellAnimInstance;
			if (shellAnimInstance != null && shellAnimInstance.HasKuroRootMotionAnim())
			{
				return;
			}
			if (this.ActorComp.InputDirectProxy.SizeSquared2D() > 1E-08)
			{
				this.HasLastInput = true;
				this.MoveForwardOnce(actorForwardProxy, maxDeltaSeconds, "[AttachMove][AssistedWalk][Leader] Move");
				return;
			}
			if (this.AnimInAssistedWalking && this.HasLastInput)
			{
				this.MoveForwardOnce(actorForwardProxy, maxDeltaSeconds, "[AttachMove][AssistedWalk][Leader] HoldLastInput Move");
			}
		}

		// Token: 0x06031097 RID: 200855 RVA: 0x00C30728 File Offset: 0x00C2E928
		private void MoveForwardOnce(Vector forward, float maxDeltaSeconds, string reason)
		{
			float baseMoveSpeed = this.AssistedWalkParams.BaseMoveSpeed;
			this.TempVector.DeepCopy(forward);
			this.TempVector.MultiplyEqual((double)(maxDeltaSeconds * baseMoveSpeed));
			Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
			double x = actorLocationProxy.X;
			double y = actorLocationProxy.Y;
			this.MoveComp.MoveCharacter(this.TempVector, maxDeltaSeconds, reason);
			double num = actorLocationProxy.X - x;
			double num2 = actorLocationProxy.Y - y;
			this.LastMoveSpeed2D = (float)Math.Sqrt(num * num + num2 * num2) / maxDeltaSeconds;
		}

		// Token: 0x06031098 RID: 200856 RVA: 0x00C307B4 File Offset: 0x00C2E9B4
		private void ResetLeaderState()
		{
			if (this.MoveComp != null)
			{
				this.MoveComp.ResetMaxSpeed(null);
				this.MoveComp.ResetTurnRate();
			}
		}

		// Token: 0x06031099 RID: 200857 RVA: 0x00C307E8 File Offset: 0x00C2E9E8
		private void StartLeaderPositionCorrectionByNotify()
		{
			if (!this.EnsureFollowerContext("StartAssistedWalk"))
			{
				return;
			}
			this.IsCorrectingLeaderPos = true;
			this.CorrectionElapsed = 0f;
			this.HasLoggedCorrectionDone = false;
			this.CorrectionStartPos.DeepCopy(this.ActorComp.ActorLocationProxy);
			this.FollowerCorrectionStartZ = this.FollowerActorComp.ActorLocationProxy.Z;
			this.FollowerCorrectionSocketName = new FName?(new FName(this.AssistedWalkParams.AttachSocket));
		}

		// Token: 0x0603109A RID: 200858 RVA: 0x00C30864 File Offset: 0x00C2EA64
		private void ExecuteFollowerAttachByNotify()
		{
			this.IsCorrectingLeaderPos = false;
			if (!this.EnsureFollowerContext("EnterAssistedWalkIdle"))
			{
				return;
			}
			Entity followerEntity = this.FollowerEntity;
			CharacterActorComponent followerActorComp = this.FollowerActorComp;
			CharacterActorComponent actorComp = this.ActorComp;
			this.FollowerAttachHelper = new FollowerAttachHelper();
			this.FollowerAttachHelper.Init(followerEntity);
			if (!this.FollowerAttachHelper.AttachToLeader(actorComp, this.AssistedWalkParams.AttachSocket, this.AssistedWalkParams.AttachTransform))
			{
				Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.CWZ, "[AttachMove][AssistedWalk][Leader] EnterAssistedWalkIdle: Attach 失败，终止搀扶", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.FollowerAttachHelper = null;
				this.ReleaseLeaderInputControl();
				this.StopRelationAfterAttachFailed();
				return;
			}
			this.ApplyLeaderCapsuleExpansion(actorComp, followerEntity);
			this.ReleaseLeaderInputControl();
		}

		// Token: 0x0603109B RID: 200859 RVA: 0x00C30914 File Offset: 0x00C2EB14
		private void UpdateLeaderPositionCorrection(float deltaSeconds)
		{
			if (!this.IsCorrectingLeaderPos)
			{
				return;
			}
			if (this.ActorComp == null || this.FollowerActorComp == null)
			{
				this.IsCorrectingLeaderPos = false;
				return;
			}
			ValueTuple<Transform, float>? valueTuple = Singleton<AttachMoveUtils>.Instance.PreviewLeaderTransform(this.ActorComp, this.FollowerActorComp, this.AssistedWalkParams.AttachSocket, this.AssistedWalkParams.AttachTransform);
			if (valueTuple == null)
			{
				return;
			}
			Vector location = valueTuple.Value.Item1.GetLocation();
			this.CorrectionElapsed += deltaSeconds;
			float num = 1f;
			float num2 = Math.Min(this.CorrectionElapsed / num, 1f);
			Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
			this.CorrectionTmpVec.DeepCopy(location);
			this.CorrectionTmpVec.SubtractionEqual(this.CorrectionStartPos);
			this.CorrectionTmpVec.MultiplyEqual((double)num2);
			this.CorrectionTmpVec.AdditionEqual(this.CorrectionStartPos);
			this.CorrectionTmpVec.Z = actorLocationProxy.Z;
			this.CorrectionTmpVec.SubtractionEqual(actorLocationProxy);
			if (!this.CorrectionTmpVec.IsNearlyZero(9.999999747378752E-05))
			{
				this.TempVector.DeepCopy(this.CorrectionTmpVec);
				this.MoveComp.MoveCharacter(this.TempVector, deltaSeconds, "[AttachMove][AssistedWalk][Leader] PosCorrection");
			}
			this.UpdateFollowerPreAttachZ(num2);
			if (num2 >= 1f && !this.HasLoggedCorrectionDone)
			{
				this.HasLoggedCorrectionDone = true;
			}
		}

		// Token: 0x0603109C RID: 200860 RVA: 0x00C30A7C File Offset: 0x00C2EC7C
		private void UpdateFollowerPreAttachZ(float alpha)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			bool flag;
			if (actorComp == null)
			{
				flag = true;
			}
			else
			{
				TsBaseCharacter actor = actorComp.Actor;
				bool? flag2;
				if (actor == null)
				{
					flag2 = null;
				}
				else
				{
					USkeletalMeshComponent mesh = actor.Mesh;
					flag2 = ((mesh != null) ? new bool?(mesh.IsValid()) : null);
				}
				bool? flag3 = flag2;
				flag = !flag3.GetValueOrDefault();
			}
			if (flag || this.FollowerActorComp == null)
			{
				return;
			}
			FName? followerCorrectionSocketName = this.FollowerCorrectionSocketName;
			if (followerCorrectionSocketName == null)
			{
				return;
			}
			Transform followerSocketTransformInActor = this.FollowerSocketTransformInActor;
			FTransformDouble ftransformDouble = this.ActorComp.Actor.Mesh.D_GetSocketTransform(followerCorrectionSocketName.Value, ERelativeTransformSpace.RTS_Actor);
			followerSocketTransformInActor.FromUeTransform(ftransformDouble);
			Transform followerLeaderWorldTransform = this.FollowerLeaderWorldTransform;
			ftransformDouble = this.ActorComp.ActorTransform;
			followerLeaderWorldTransform.FromUeTransform(ftransformDouble);
			this.FollowerSocketTransformInActor.ComposeTransforms(this.FollowerLeaderWorldTransform, this.FollowerSocketWorldTransform);
			this.AssistedWalkParams.AttachTransform.ComposeTransforms(this.FollowerSocketWorldTransform, this.FollowerTargetWorldTransform);
			double z = this.FollowerTargetWorldTransform.GetLocation().Z;
			Vector actorLocationProxy = this.FollowerActorComp.ActorLocationProxy;
			double num = Singleton<MathUtils>.Instance.Lerp(this.FollowerCorrectionStartZ, z, (double)alpha);
			if (Math.Abs(actorLocationProxy.Z - num) <= 1E-08)
			{
				return;
			}
			this.FollowerPreAttachTmpVec.DeepCopy(actorLocationProxy);
			this.FollowerPreAttachTmpVec.Z = num;
			this.FollowerActorComp.SetActorLocation(this.FollowerPreAttachTmpVec.ToUeVector(false), "[AttachMove][AssistedWalk][Follower] PreAttachZCorrection", false);
		}

		// Token: 0x0603109D RID: 200861 RVA: 0x00C30BEC File Offset: 0x00C2EDEC
		private unsafe bool EnsureFollowerContext(string context)
		{
			bool flag = this.FollowerEntity != null && this.FollowerActorComp != null;
			if (!this.ResolveFollowerContext())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AttachMove][AssistedWalk][Leader] 获取 Follower 上下文失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Context", context);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "LeaderEntityId";
				BaseTagComponent tagComp = this.TagComp;
				ptr = new ValueTuple<string, object>(item, (tagComp != null) ? tagComp.Entity.Id : 0);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			return true;
		}

		// Token: 0x0603109E RID: 200862 RVA: 0x00C30C8C File Offset: 0x00C2EE8C
		private void CacheFollowerAnimInstance()
		{
			if (this.FollowerAnimInstance != null || this.FollowerEntity == null)
			{
				return;
			}
			CharacterAnimationComponent component = this.FollowerEntity.GetComponent<CharacterAnimationComponent>();
			this.FollowerAnimInstance = (((component != null) ? component.MainAnimInstance : null) as UKuroAnimInstanceChar);
		}

		// Token: 0x0603109F RID: 200863 RVA: 0x00C30CD0 File Offset: 0x00C2EED0
		private bool ResolveFollowerContext()
		{
			if (this.FollowerEntity != null && this.FollowerActorComp != null)
			{
				this.CacheFollowerAnimInstance();
				return true;
			}
			BaseTagComponent tagComp = this.TagComp;
			int entityId = (tagComp != null) ? tagComp.Entity.Id : 0;
			AttachMoveRelation relationByEntityId = Singleton<AttachMoveUtils>.Instance.GetRelationByEntityId(entityId);
			Entity entity;
			if (relationByEntityId == null)
			{
				entity = null;
			}
			else
			{
				BaseActorComponent followerActor = relationByEntityId.FollowerActor;
				entity = ((followerActor != null) ? followerActor.Entity : null);
			}
			Entity entity2 = entity;
			CharacterActorComponent characterActorComponent = (entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null;
			if (entity2 == null || characterActorComponent == null)
			{
				return false;
			}
			this.FollowerEntity = entity2;
			this.FollowerActorComp = characterActorComponent;
			this.CacheFollowerAnimInstance();
			return true;
		}

		// Token: 0x060310A0 RID: 200864 RVA: 0x00C30D5B File Offset: 0x00C2EF5B
		private void TryCacheFollowerContextSilently()
		{
			this.ResolveFollowerContext();
		}

		// Token: 0x060310A1 RID: 200865 RVA: 0x00C30D64 File Offset: 0x00C2EF64
		private void StopRelationAfterAttachFailed()
		{
			BaseTagComponent tagComp = this.TagComp;
			int entityId = (tagComp != null) ? tagComp.Entity.Id : 0;
			AttachMoveRelation relationByEntityId = Singleton<AttachMoveUtils>.Instance.GetRelationByEntityId(entityId);
			if (relationByEntityId == null)
			{
				return;
			}
			Action stopFn = relationByEntityId.StopFn;
			if (stopFn == null)
			{
				return;
			}
			stopFn();
		}

		// Token: 0x060310A2 RID: 200866 RVA: 0x00C30DA8 File Offset: 0x00C2EFA8
		private void ReleaseLeaderInputControl()
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			Entity entity = actorComp.Entity;
			if (entity == null)
			{
				return;
			}
			CharacterCustomActionComponent component = entity.GetComponent<CharacterCustomActionComponent>();
			if (component == null)
			{
				return;
			}
			component.AddCustomSetPlayerControl(false, null);
		}

		// Token: 0x060310A3 RID: 200867 RVA: 0x00C30DD0 File Offset: 0x00C2EFD0
		private void DetachFollowerFromLeader()
		{
			FollowerAttachHelper followerAttachHelper = this.FollowerAttachHelper;
			if (followerAttachHelper != null)
			{
				followerAttachHelper.DetachFromLeader();
			}
			this.FollowerAttachHelper = null;
		}

		// Token: 0x060310A4 RID: 200868 RVA: 0x00C30DEC File Offset: 0x00C2EFEC
		private void ClearLeaderDrivenFollowerState()
		{
			this.FollowerAttachHelper = null;
			this.FollowerEntity = null;
			this.FollowerActorComp = null;
			this.FollowerAnimInstance = null;
			this.IsCorrectingLeaderPos = false;
			this.CorrectionElapsed = 0f;
			this.HasLoggedCorrectionDone = false;
			this.FollowerCorrectionStartZ = 0.0;
			this.FollowerCorrectionSocketName = null;
			this.CapsuleModifiedLeader = null;
			this.OriginalLeaderRadius = 0f;
			this.CapsuleLocalOffset.Reset();
		}

		// Token: 0x060310A5 RID: 200869 RVA: 0x00C30E68 File Offset: 0x00C2F068
		private void ApplyLeaderCapsuleExpansion(CharacterActorComponent leader, Entity followerEntity)
		{
			CharacterActorComponent component = followerEntity.GetComponent<CharacterActorComponent>();
			if (component != null)
			{
				TsBaseCharacter actor = leader.Actor;
				bool flag;
				if (actor == null)
				{
					flag = true;
				}
				else
				{
					UCapsuleComponent capsuleComponent = actor.CapsuleComponent;
					flag = !((capsuleComponent != null) ? new bool?(capsuleComponent.IsValid()) : null).GetValueOrDefault();
				}
				if (!flag)
				{
					float scaledRadius = leader.ScaledRadius;
					float scaledRadius2 = component.ScaledRadius;
					Vector actorLocationProxy = leader.ActorLocationProxy;
					Vector actorLocationProxy2 = component.ActorLocationProxy;
					Vector correctionTmpVec = this.CorrectionTmpVec;
					correctionTmpVec.DeepCopy(actorLocationProxy2);
					correctionTmpVec.SubtractionEqual(actorLocationProxy);
					correctionTmpVec.Z = 0.0;
					double num = correctionTmpVec.Size2D();
					if (num < 1E-08)
					{
						return;
					}
					correctionTmpVec.MultiplyEqual((double)scaledRadius / num);
					leader.ActorQuatProxy.UnRotateVector(correctionTmpVec, this.CapsuleLocalOffset);
					correctionTmpVec.AdditionEqual(actorLocationProxy);
					leader.SetActorLocationAndRotationExceptMesh(correctionTmpVec.ToUeVector(false), leader.ActorRotation, "AssistedWalk.CapsuleExpand", true, null);
					this.OriginalLeaderRadius = scaledRadius;
					this.CapsuleModifiedLeader = leader;
					leader.SetRadiusAndHalfHeight(scaledRadius + scaledRadius2, leader.ScaledHalfHeight, false, false);
					return;
				}
			}
		}

		// Token: 0x060310A6 RID: 200870 RVA: 0x00C30F88 File Offset: 0x00C2F188
		private void RestoreLeaderCapsule()
		{
			CharacterActorComponent capsuleModifiedLeader = this.CapsuleModifiedLeader;
			bool flag;
			if (capsuleModifiedLeader == null)
			{
				flag = true;
			}
			else
			{
				TsBaseCharacter actor = capsuleModifiedLeader.Actor;
				flag = !((actor != null) ? new bool?(actor.IsValid()) : null).GetValueOrDefault();
			}
			if (flag)
			{
				this.CapsuleModifiedLeader = null;
				return;
			}
			Vector correctionTmpVec = this.CorrectionTmpVec;
			capsuleModifiedLeader.ActorQuatProxy.RotateVector(this.CapsuleLocalOffset, correctionTmpVec);
			correctionTmpVec.MultiplyEqual(-1.0);
			correctionTmpVec.AdditionEqual(capsuleModifiedLeader.ActorLocationProxy);
			capsuleModifiedLeader.SetActorLocationAndRotationExceptMesh(correctionTmpVec.ToUeVector(false), capsuleModifiedLeader.ActorRotation, "AssistedWalk.CapsuleRestore", false, null);
			capsuleModifiedLeader.SetRadiusAndHalfHeight(this.OriginalLeaderRadius, capsuleModifiedLeader.HalfHeight, false, false);
			this.CapsuleModifiedLeader = null;
		}

		// Token: 0x060310A7 RID: 200871 RVA: 0x00C3104C File Offset: 0x00C2F24C
		private void WriteAnimLogicParams(bool entering, bool waitAnim = true)
		{
			UKuroAnimInstanceChar animInstance = this.AnimInstance;
			UAbpLogicParams uabpLogicParams = (animInstance != null) ? animInstance.LogicParams : null;
			if (uabpLogicParams == null)
			{
				return;
			}
			uabpLogicParams.bHelpedAssistedWalk = false;
			uabpLogicParams.bSkipEnterAssistedWalkAnim = (entering && !waitAnim);
			uabpLogicParams.AssistedWalkAnimRate = (entering ? this.GetAnimRate() : ((float)this.AssistedWalkParams.AnimSpeedRateRange.X));
			uabpLogicParams.bInAssistedWalking = false;
		}

		// Token: 0x060310A8 RID: 200872 RVA: 0x00C310B0 File Offset: 0x00C2F2B0
		private void WriteAnimLogicParamsPerFrame()
		{
			float animRate = this.GetAnimRate();
			bool bInAssistedWalking = this.IsActivelyAssistedWalking();
			UKuroAnimInstanceChar animInstance = this.AnimInstance;
			UAbpLogicParams uabpLogicParams = (animInstance != null) ? animInstance.LogicParams : null;
			if (uabpLogicParams != null)
			{
				uabpLogicParams.AssistedWalkAnimRate = animRate;
				uabpLogicParams.bInAssistedWalking = bInAssistedWalking;
			}
			this.TryCacheFollowerContextSilently();
			UKuroAnimInstanceChar followerAnimInstance = this.FollowerAnimInstance;
			UAbpLogicParams uabpLogicParams2 = (followerAnimInstance != null) ? followerAnimInstance.LogicParams : null;
			if (uabpLogicParams2 != null)
			{
				uabpLogicParams2.AssistedWalkAnimRate = animRate;
				uabpLogicParams2.bInAssistedWalking = bInAssistedWalking;
			}
		}

		// Token: 0x060310A9 RID: 200873 RVA: 0x00C3111C File Offset: 0x00C2F31C
		private float GetAnimRate()
		{
			AssistedWalkParams assistedWalkParams = this.AssistedWalkParams;
			Vector2D animSpeedRateRange = assistedWalkParams.AnimSpeedRateRange;
			if (!this.InState || (double)assistedWalkParams.BaseMoveSpeed <= 1E-08)
			{
				return (float)animSpeedRateRange.X;
			}
			float currentValue = this.LastMoveSpeed2D / assistedWalkParams.BaseMoveSpeed;
			return Singleton<MathUtils>.Instance.Clamp(currentValue, (float)animSpeedRateRange.X, (float)animSpeedRateRange.Y);
		}

		// Token: 0x060310AA RID: 200874 RVA: 0x00C31180 File Offset: 0x00C2F380
		private bool IsActivelyAssistedWalking()
		{
			return this.InState && this.ActorComp != null && this.ActorComp.InputDirectProxy.SizeSquared2D() > 1E-08;
		}

		// Token: 0x170083A9 RID: 33705
		// (get) Token: 0x060310AB RID: 200875 RVA: 0x00C311AF File Offset: 0x00C2F3AF
		private AssistedWalkParams AssistedWalkParams
		{
			get
			{
				return this.Params ?? AssistedWalkParams.Default;
			}
		}

		// Token: 0x060310AC RID: 200876 RVA: 0x00C311C0 File Offset: 0x00C2F3C0
		private void InitComponents(Entity entity)
		{
			this.ActorComp = entity.GetComponent<CharacterActorComponent>();
			this.MoveComp = entity.GetComponent<BaseMoveComponent>();
			this.AnimComp = entity.GetComponent<CharacterAnimationComponent>();
			this.TagComp = entity.GetComponent<BaseTagComponent>();
			this.UeMovementComp = entity.GetComponent<UeMovementTickManageComponent>();
		}

		// Token: 0x060310AD RID: 200877 RVA: 0x00C311FE File Offset: 0x00C2F3FE
		private void ClearLeaderAssistedWalkTag()
		{
			if (this.AssistedWalkTagId == 0)
			{
				return;
			}
			base.SetOnlyTag(this.TagComp, this.AssistedWalkTagId, false, "[AttachMove][AssistedWalk][Leader] StopMove");
			this.AssistedWalkTagId = 0;
		}

		// Token: 0x060310AE RID: 200878 RVA: 0x00C31228 File Offset: 0x00C2F428
		private void ClearLeaderComponents()
		{
			this.ActorComp = null;
			this.MoveComp = null;
			this.AnimComp = null;
			this.UeMovementComp = null;
			this.AnimInstance = null;
			this.AnimInAssistedWalking = false;
			this.LastMoveSpeed2D = 0f;
			this.HasLastInput = false;
			this.ClearLeaderDrivenFollowerState();
		}

		// Token: 0x060310AF RID: 200879 RVA: 0x00C31278 File Offset: 0x00C2F478
		private bool ArePartnerComponentsAlive()
		{
			AssistedWalkUtils instance = Singleton<AssistedWalkUtils>.Instance;
			string logTag = "[AttachMove][AssistedWalk][Leader] 兄弟组件已销毁，跳过状态恢复";
			CharacterActorComponent actorComp = this.ActorComp;
			bool[] array = new bool[4];
			int num = 0;
			UeMovementTickManageComponent ueMovementComp = this.UeMovementComp;
			array[num] = (ueMovementComp == null || ueMovementComp.Valid);
			int num2 = 1;
			BaseMoveComponent moveComp = this.MoveComp;
			array[num2] = (moveComp == null || moveComp.Valid);
			int num3 = 2;
			CharacterAnimationComponent animComp = this.AnimComp;
			array[num3] = (animComp == null || animComp.Valid);
			int num4 = 3;
			BaseTagComponent tagComp = this.TagComp;
			array[num4] = (tagComp == null || tagComp.Valid);
			return instance.ArePartnerComponentsAlive(logTag, actorComp, array);
		}

		// Token: 0x0401C3AE RID: 115630
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C3AF RID: 115631
		[Nullable(2)]
		private BaseMoveComponent MoveComp;

		// Token: 0x0401C3B0 RID: 115632
		[Nullable(2)]
		private CharacterAnimationComponent AnimComp;

		// Token: 0x0401C3B1 RID: 115633
		[Nullable(2)]
		private UeMovementTickManageComponent UeMovementComp;

		// Token: 0x0401C3B2 RID: 115634
		[Nullable(2)]
		private UKuroAnimInstanceChar AnimInstance;

		// Token: 0x0401C3B3 RID: 115635
		private int AssistedWalkTagId;

		// Token: 0x0401C3B4 RID: 115636
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x0401C3B5 RID: 115637
		private float LastMoveSpeed2D;

		// Token: 0x0401C3B6 RID: 115638
		private bool HasLastInput;

		// Token: 0x0401C3B7 RID: 115639
		private bool AnimInAssistedWalking;

		// Token: 0x0401C3B8 RID: 115640
		[Nullable(2)]
		private FollowerAttachHelper FollowerAttachHelper;

		// Token: 0x0401C3B9 RID: 115641
		[Nullable(2)]
		private Entity FollowerEntity;

		// Token: 0x0401C3BA RID: 115642
		[Nullable(2)]
		private CharacterActorComponent FollowerActorComp;

		// Token: 0x0401C3BB RID: 115643
		[Nullable(2)]
		private UKuroAnimInstanceChar FollowerAnimInstance;

		// Token: 0x0401C3BC RID: 115644
		private bool IsCorrectingLeaderPos;

		// Token: 0x0401C3BD RID: 115645
		private float CorrectionElapsed;

		// Token: 0x0401C3BE RID: 115646
		private readonly Vector CorrectionStartPos = Vector.Create();

		// Token: 0x0401C3BF RID: 115647
		private bool HasLoggedCorrectionDone;

		// Token: 0x0401C3C0 RID: 115648
		private readonly Vector CorrectionTmpVec = Vector.Create();

		// Token: 0x0401C3C1 RID: 115649
		private double FollowerCorrectionStartZ;

		// Token: 0x0401C3C2 RID: 115650
		private FName? FollowerCorrectionSocketName;

		// Token: 0x0401C3C3 RID: 115651
		private readonly Vector FollowerPreAttachTmpVec = Vector.Create();

		// Token: 0x0401C3C4 RID: 115652
		private readonly Transform FollowerSocketTransformInActor = Transform.Create();

		// Token: 0x0401C3C5 RID: 115653
		private readonly Transform FollowerLeaderWorldTransform = Transform.Create();

		// Token: 0x0401C3C6 RID: 115654
		private readonly Transform FollowerSocketWorldTransform = Transform.Create();

		// Token: 0x0401C3C7 RID: 115655
		private readonly Transform FollowerTargetWorldTransform = Transform.Create();

		// Token: 0x0401C3C8 RID: 115656
		[Nullable(2)]
		private CharacterActorComponent CapsuleModifiedLeader;

		// Token: 0x0401C3C9 RID: 115657
		private float OriginalLeaderRadius;

		// Token: 0x0401C3CA RID: 115658
		private readonly Vector CapsuleLocalOffset = Vector.Create();

		// Token: 0x0401C3CB RID: 115659
		private SightLockMode LastSightLockMode;
	}
}
