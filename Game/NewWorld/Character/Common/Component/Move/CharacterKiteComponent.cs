using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Fight.AssestStruct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.NewWorld.Character.Role.Component;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move
{
	// Token: 0x02004921 RID: 18721
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterKiteComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x17008357 RID: 33623
		// (get) Token: 0x06030F24 RID: 200484 RVA: 0x00C25263 File Offset: 0x00C23463
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

		// Token: 0x06030F25 RID: 200485 RVA: 0x00C25278 File Offset: 0x00C23478
		protected void OnMoveStateChanged(global::ECharMoveState oldMoveState, global::ECharMoveState newMoveState)
		{
			if (oldMoveState == global::ECharMoveState.Kite)
			{
				if (this.InMonsterKiteMove)
				{
					this.ExitKiteOnlyMonster(this.CurrentTarget);
				}
				this.CurrentTarget = null;
			}
		}

		// Token: 0x06030F26 RID: 200486 RVA: 0x00C2529C File Offset: 0x00C2349C
		public void KiteMove(float deltaSeconds)
		{
			if (ModelBase<SeamlessTravelModel>.Instance.GetIsKeepingCurrentMovementMode() || ModelBase<TeleportModel>.Instance.GetIsKeepingCurrentMovementMode())
			{
				this.PrevLocation.DeepCopy(this.MoveComp.ActorComp.ActorLocationProxy);
				this.PrevLocationTime = 0f;
				this.PrevLocationBlockCount = 0;
				return;
			}
			GrapplingHookPointComponent currentTarget = this.CurrentTarget;
			if (currentTarget != null && currentTarget.Valid)
			{
				Entity entity = this.CurrentTarget.Entity;
				bool? flag;
				if (entity == null)
				{
					flag = null;
				}
				else
				{
					LevelTagComponent component = entity.GetComponent<LevelTagComponent>();
					flag = ((component != null) ? new bool?(component.HasTag(CharacterKiteComponent.hookKeepAttachedTag)) : null);
				}
				bool? flag2 = flag;
				if (!flag2.GetValueOrDefault())
				{
					GrapplingHookPointComponent currentTarget2 = this.CurrentTarget;
					if (currentTarget2 == null || !currentTarget2.Valid || this.LastTargetEndCount != this.CurrentTarget.SplineMoveEndCount)
					{
						int lastTargetMoveBrokenCount = this.LastTargetMoveBrokenCount;
						GrapplingHookPointComponent currentTarget3 = this.CurrentTarget;
						int? num = (currentTarget3 != null) ? new int?(currentTarget3.SplineMoveBrokenCount) : null;
						if (!(lastTargetMoveBrokenCount == num.GetValueOrDefault() & num != null))
						{
							RoleSceneInteractComponent component2 = base.Entity.GetComponent<RoleSceneInteractComponent>();
							if (component2 != null)
							{
								component2.SetIsHookEndByInterrupt(true);
							}
						}
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
							Context = "[CharacterKiteComponent.KiteMove.End]"
						});
						return;
					}
					else
					{
						CharacterMoveComponent moveComp2 = this.MoveComp;
						bool flag3;
						if (moveComp2 == null)
						{
							flag3 = (null != null);
						}
						else
						{
							UCharacterMovementComponent characterMovement = moveComp2.CharacterMovement;
							flag3 = (((characterMovement != null) ? characterMovement.Kuro_GetBlockActorWhenMove() : null) != null);
						}
						if (flag3 && global::Vector.DistSquared(this.PrevLocation, this.MoveComp.ActorComp.ActorLocationProxy) < 40000.0)
						{
							if (this.PrevLocationTime > 1f)
							{
								int num2 = this.PrevLocationBlockCount + 1;
								this.PrevLocationBlockCount = num2;
								if (num2 >= 3)
								{
									RoleSceneInteractComponent component3 = base.Entity.GetComponent<RoleSceneInteractComponent>();
									if (component3 != null)
									{
										component3.SetIsHookEndByInterrupt(true);
									}
									CharacterMoveComponent moveComp3 = this.MoveComp;
									if (moveComp3 != null)
									{
										CharacterActorComponent actorComp2 = moveComp3.ActorComp;
										if (actorComp2 != null)
										{
											actorComp2.Actor.KuroSetMovementMode(new SetMovementModeInfo
											{
												Mode = EMovementMode.MOVE_Falling,
												Context = "[CharacterKiteComponent.KiteMove.Block]"
											});
										}
									}
								}
							}
							this.PrevLocationTime += deltaSeconds;
						}
						else
						{
							this.PrevLocation.DeepCopy(this.MoveComp.ActorComp.ActorLocationProxy);
							this.PrevLocationTime = 0f;
							this.PrevLocationBlockCount = 0;
						}
					}
				}
				if (this.UseNewKiteMode)
				{
					this.KiteMoveNew(deltaSeconds);
				}
				else
				{
					this.KiteMoveOld(deltaSeconds);
				}
				this.TargetPrevPos.DeepCopy(this.CurrentTarget.HookLocation);
				return;
			}
			CharacterMoveComponent moveComp4 = this.MoveComp;
			if (moveComp4 == null)
			{
				return;
			}
			CharacterActorComponent actorComp3 = moveComp4.ActorComp;
			if (actorComp3 == null)
			{
				return;
			}
			actorComp3.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[CharacterKiteComponent.KiteMove.End]"
			});
		}

		// Token: 0x06030F27 RID: 200487 RVA: 0x00C25564 File Offset: 0x00C23764
		private void KiteMoveOld(float deltaSeconds)
		{
			FVector targetPrevPos = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, this.TargetPrevPos.ToUeVector(false));
			FVector targetNextPos = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, this.CurrentTarget.HookLocation.ToUeVector(false));
			UKuroMovementBPLibrary.KuroKite(deltaSeconds, this.MoveComp.CharacterMovement, targetPrevPos, targetNextPos, 300f, 900f, 1200f, 18000f, 0.98f, ref this.RefTargetForward, 240f, 0.9f);
		}

		// Token: 0x06030F28 RID: 200488 RVA: 0x00C255E4 File Offset: 0x00C237E4
		private void KiteMoveNew(float deltaSeconds)
		{
			UCharacterMovementComponent characterMovement = this.MoveComp.CharacterMovement;
			CharacterActorComponent actorComp = this.MoveComp.ActorComp;
			global::Vector tmpTargetPos = CharacterKiteComponent.TmpTargetPos;
			tmpTargetPos.DeepCopy(this.CurrentTarget.HookLocation);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, tmpTargetPos, (double)(-(double)actorComp.ScaledHalfHeight));
			this.MoveComp.GravityDirect.Multiply((double)(this.KiteConfigData.Gravity * deltaSeconds), CharacterKiteComponent.TmpGravityDelta);
			double inB = Math.Pow((double)this.KiteConfigData.InertiaDecay, (double)deltaSeconds);
			this.KiteVelocity.MultiplyEqual(inB);
			this.KiteVelocity.AdditionEqual(CharacterKiteComponent.TmpGravityDelta);
			CharacterKiteComponent.TmpTentativePos.DeepCopy(actorComp.ActorLocationProxy);
			this.KiteVelocity.Multiply((double)deltaSeconds, CharacterKiteComponent.TmpMoveDelta);
			CharacterKiteComponent.TmpTentativePos.AdditionEqual(CharacterKiteComponent.TmpMoveDelta);
			tmpTargetPos.Subtraction(CharacterKiteComponent.TmpTentativePos, CharacterKiteComponent.TmpToTarget);
			double num = CharacterKiteComponent.TmpToTarget.Size();
			double num2 = this.KiteDistToTarget - (double)(this.KiteConfigData.ShrinkSpeed * deltaSeconds);
			if (num2 < (double)this.KiteConfigData.MinDist)
			{
				num2 = (double)this.KiteConfigData.MinDist;
			}
			if (num > num2)
			{
				CharacterKiteComponent.TmpToTarget.MultiplyEqual(num2 / num);
				tmpTargetPos.Subtraction(CharacterKiteComponent.TmpToTarget, CharacterKiteComponent.TmpTentativePos);
				CharacterKiteComponent.TmpTentativePos.Subtraction(actorComp.ActorLocationProxy, CharacterKiteComponent.TmpMoveDelta);
			}
			this.UpdateFacing(deltaSeconds, tmpTargetPos, actorComp);
			UKuroMovementBPLibrary.KuroMoveByOffset(deltaSeconds, characterMovement, CharacterKiteComponent.TmpMoveDelta.ToUeVectorOld(), EMoveSlideType.Free, default(FVector));
			actorComp.ResetLocationCachedTime();
			tmpTargetPos.Subtraction(actorComp.ActorLocationProxy, CharacterKiteComponent.TmpToTarget);
			Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp, CharacterKiteComponent.TmpToTarget, (double)(-(double)actorComp.ScaledHalfHeight));
			this.KiteDistToTarget = global::Vector.Dist(tmpTargetPos, actorComp.ActorLocationProxy);
		}

		// Token: 0x06030F29 RID: 200489 RVA: 0x00C257B4 File Offset: 0x00C239B4
		private void UpdateFacing(float deltaSeconds, global::Vector targetPos, BaseActorComponent actorComp)
		{
			CharacterKiteComponent.TmpActorForward.DeepCopy(actorComp.ActorForwardProxy);
			if (!this.TargetForwardInited)
			{
				this.TargetForward.DeepCopy(CharacterKiteComponent.TmpActorForward);
				this.TargetForwardInited = true;
			}
			global::Vector actorLocationProxy = this.MoveComp.ActorComp.ActorLocationProxy;
			CharacterKiteComponent.TmpNewTargetForward.DeepCopy(targetPos);
			CharacterKiteComponent.TmpNewTargetForward.SubtractionEqual(actorLocationProxy);
			Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.MoveComp.ActorComp, CharacterKiteComponent.TmpNewTargetForward);
			double num = CharacterKiteComponent.TmpNewTargetForward.Size();
			if (num > 1E-08)
			{
				CharacterKiteComponent.TmpNewTargetForward.MultiplyEqual(1.0 / num);
				double num2 = Math.Abs(Math.Acos(Math.Min(Math.Max(global::Vector.DotProduct(CharacterKiteComponent.TmpNewTargetForward, this.TargetForward), -1.0), 1.0)));
				if (num2 > 1E-08)
				{
					float num3 = 4.1887903f * deltaSeconds;
					if ((double)num3 >= num2)
					{
						this.TargetForward.DeepCopy(CharacterKiteComponent.TmpNewTargetForward);
					}
					else
					{
						double num4 = (double)num3 / num2;
						Quat.FindBetween(this.TargetForward, CharacterKiteComponent.TmpNewTargetForward, CharacterKiteComponent.TmpQuat);
						Quat.Slerp(Quat.IdentityProxy, CharacterKiteComponent.TmpQuat, (float)num4, CharacterKiteComponent.TmpQuat);
						CharacterKiteComponent.TmpQuat.RotateVector(this.TargetForward, this.TargetForward);
					}
				}
			}
			if (global::Vector.DotProduct(CharacterKiteComponent.TmpActorForward, this.TargetForward) < 0.9999)
			{
				Quat.FindBetween(CharacterKiteComponent.TmpActorForward, this.TargetForward, CharacterKiteComponent.TmpQuat2);
				double num5 = 1.0 - Math.Pow(0.10000002384185791, (double)deltaSeconds);
				Quat.Slerp(Quat.IdentityProxy, CharacterKiteComponent.TmpQuat2, (float)num5, CharacterKiteComponent.TmpQuat2);
				CharacterKiteComponent.TmpQuat2.RotateVector(CharacterKiteComponent.TmpActorForward, CharacterKiteComponent.TmpActorForward);
			}
			global::Vector gravityUp = this.MoveComp.GravityUp;
			Singleton<MathUtils>.Instance.LookRotationUpFirst(CharacterKiteComponent.TmpActorForward, gravityUp, CharacterKiteComponent.TmpRotator);
			actorComp.SetActorRotation(CharacterKiteComponent.TmpRotator.ToUeRotator(), "KiteMoveNew.Facing", false);
		}

		// Token: 0x06030F2A RID: 200490 RVA: 0x00C259BF File Offset: 0x00C23BBF
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06030F2B RID: 200491 RVA: 0x00C259C2 File Offset: 0x00C23BC2
		protected override bool OnStart()
		{
			this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
			Singleton<EventSystem>.Instance.AddWithTarget<global::ECharMoveState, global::ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChanged));
			return true;
		}

		// Token: 0x06030F2C RID: 200492 RVA: 0x00C259F8 File Offset: 0x00C23BF8
		protected override bool OnEnd()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<global::ECharMoveState, global::ECharMoveState>(base.Entity, EEventName.CharOnUnifiedMoveStateChanged, new Action<global::ECharMoveState, global::ECharMoveState>(this.OnMoveStateChanged));
			this.RemoveKiteCue();
			return true;
		}

		// Token: 0x06030F2D RID: 200493 RVA: 0x00C25A24 File Offset: 0x00C23C24
		[NullableContext(2)]
		public unsafe bool EnterKite(GrapplingHookPointComponent target)
		{
			if (target != null)
			{
				CharacterMoveComponent moveComp = this.MoveComp;
				if (((moveComp != null) ? moveComp.CharacterMovement : null) != null)
				{
					this.CurrentTarget = target;
					IKiteHook kiteHook = target.GetHookInteractConfig() as IKiteHook;
					string text = (kiteHook != null) ? kiteHook.HookDataAssetOverride : null;
					if (!string.IsNullOrEmpty(text))
					{
						BP_KiteConfig_C bp_KiteConfig_C = Singleton<ResourceSystem>.Instance.Load<BP_KiteConfig_C>(text, "js_undefined");
						if (bp_KiteConfig_C != null)
						{
							this.KiteConfigData = new CharacterKiteComponent.KiteConfig
							{
								Gravity = bp_KiteConfig_C.重力强度,
								InertiaDecay = bp_KiteConfig_C.速度衰减系数_每秒保留比例_,
								MinDist = bp_KiteConfig_C.最短收缩距离,
								ShrinkSpeed = bp_KiteConfig_C.收缩速度
							};
						}
						else
						{
							this.KiteConfigData = null;
						}
					}
					else
					{
						this.KiteConfigData = null;
					}
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Movement;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "[CharacterKiteComponent.EnterKite]";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("KiteConfig", this.KiteConfigData != null);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.LastTargetEndCount = target.SplineMoveEndCount;
					this.LastTargetMoveBrokenCount = target.SplineMoveBrokenCount;
					CharacterMoveComponent moveComp2 = this.MoveComp;
					if (moveComp2 != null)
					{
						CharacterActorComponent actorComp = moveComp2.ActorComp;
						if (actorComp != null)
						{
							actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
							{
								Mode = EMovementMode.MOVE_Custom,
								CustomMode = 10,
								Context = "[CharacterKiteComponent.EnterKite]"
							});
						}
					}
					this.TargetPrevPos.DeepCopy(this.CurrentTarget.HookLocation);
					this.PrevLocationTime = 0f;
					this.PrevLocation.DeepCopy(this.MoveComp.ActorComp.ActorLocationProxy);
					this.UseNewKiteMode = (this.KiteConfigData != null);
					if (this.UseNewKiteMode)
					{
						this.KiteVelocity.Set(0.0, 0.0, 0.0);
						global::Vector tmpTargetPos = CharacterKiteComponent.TmpTargetPos;
						tmpTargetPos.DeepCopy(this.CurrentTarget.HookLocation);
						CharacterActorComponent actorComp2 = this.MoveComp.ActorComp;
						Singleton<GravityUtils>.Instance.AddZnInGravityForActor(actorComp2, tmpTargetPos, (double)(-(double)actorComp2.ScaledHalfHeight));
						global::Vector actorLocationProxy = this.MoveComp.ActorComp.ActorLocationProxy;
						this.KiteDistToTarget = global::Vector.Dist(tmpTargetPos, actorLocationProxy);
						this.TargetForwardInited = false;
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06030F2E RID: 200494 RVA: 0x00C25C78 File Offset: 0x00C23E78
		[NullableContext(2)]
		public unsafe void EnterKiteOnlyMonster(GrapplingHookPointComponent hookComp, Action onSuccess = null, Action onFailure = null)
		{
			if (hookComp == null)
			{
				Action onFailure2 = onFailure;
				if (onFailure2 != null)
				{
					onFailure2();
				}
				Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[CharacterKiteComponent.EnterKiteOnlyMonster] 执行失败，没有HookPoint组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			Entity entity = base.Entity;
			BaseExploreComponent baseExploreComponent = (entity != null) ? entity.GetComponent<BaseExploreComponent>() : null;
			if (baseExploreComponent != null)
			{
				baseExploreComponent.InteractingTarget = hookComp;
			}
			Entity entity2 = base.Entity;
			CharacterGameplayCueComponent characterGameplayCueComponent = (entity2 != null) ? entity2.GetComponent<CharacterGameplayCueComponent>() : null;
			if (this.KiteHookCueHandle != 0 && characterGameplayCueComponent != null)
			{
				characterGameplayCueComponent.RemoveCueByHandle((long)this.KiteHookCueHandle);
			}
			this.KiteHookCueHandle = ((characterGameplayCueComponent != null) ? characterGameplayCueComponent.AddCue(7000000100L, null) : 0);
			long? num;
			if (hookComp == null)
			{
				num = null;
			}
			else
			{
				Entity entity3 = hookComp.Entity;
				if (entity3 == null)
				{
					num = null;
				}
				else
				{
					CreatureDataComponent component = entity3.GetComponent<CreatureDataComponent>();
					num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
				}
			}
			long? num2 = num;
			if (num2 != null)
			{
				long? num3 = num2;
				long num4 = 0L;
				if (!(num3.GetValueOrDefault() == num4 & num3 != null))
				{
					HookLockPointRequest hookLockPointRequest = HookLockPointRequest.Create();
					hookLockPointRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(num2.GetValueOrDefault());
					this.EnterKite(hookComp);
					this.InMonsterKiteMove = true;
					FixHookClientLevelEventExecutor.ExecuteHookActions(FixHookClientLevelEventExecutor.EHookPointStage.ClientHook, hookComp);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "[CharacterKiteComponent.EnterKiteOnlyMonster]";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HookEntityId", hookComp.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HookCreatureDataId", num2);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("CueHandle", this.KiteHookCueHandle);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					Singleton<Net>.Instance.Call<HookLockPointResponse>(ERequestMessageId.HookLockPointRequest, hookLockPointRequest, delegate(HookLockPointResponse response, Net.CallbackStatus _)
					{
						if (response == null || response.ErrorCode > ErrorCode.Success)
						{
							Action onFailure4 = onFailure;
							if (onFailure4 != null)
							{
								onFailure4();
							}
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.Character;
							ELogAuthor author2 = ELogAuthor.CWZ;
							string message2 = "[CharacterKiteComponent.EnterKiteOnlyMonster] 执行失败";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ErrorCode", (response != null) ? new ErrorCode?(response.ErrorCode) : null);
							instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							return;
						}
						Action onSuccess2 = onSuccess;
						if (onSuccess2 == null)
						{
							return;
						}
						onSuccess2();
					}, 0);
					return;
				}
			}
			Action onFailure3 = onFailure;
			if (onFailure3 != null)
			{
				onFailure3();
			}
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.CWZ, "[CharacterKiteComponent.EnterKiteOnlyMonster] 执行失败，没有creatureDataId", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06030F2F RID: 200495 RVA: 0x00C25ED4 File Offset: 0x00C240D4
		private void RemoveKiteCue()
		{
			if (this.KiteHookCueHandle != 0)
			{
				Entity entity = base.Entity;
				CharacterGameplayCueComponent characterGameplayCueComponent = (entity != null) ? entity.GetComponent<CharacterGameplayCueComponent>() : null;
				if (characterGameplayCueComponent != null)
				{
					characterGameplayCueComponent.RemoveCueByHandle((long)this.KiteHookCueHandle);
				}
				this.KiteHookCueHandle = 0;
			}
		}

		// Token: 0x06030F30 RID: 200496 RVA: 0x00C25F0C File Offset: 0x00C2410C
		[NullableContext(2)]
		private unsafe void ExitKiteOnlyMonster(GrapplingHookPointComponent target)
		{
			if (target != null && target.Valid)
			{
				Entity entity = base.Entity;
				bool flag;
				if (entity == null)
				{
					flag = true;
				}
				else
				{
					BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
					flag = !((component != null) ? new bool?(component.IsAutonomousProxy) : null).GetValueOrDefault();
				}
				if (!flag)
				{
					this.InMonsterKiteMove = false;
					long creatureDataId = target.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
					HookLockPointExitRequest hookLockPointExitRequest = HookLockPointExitRequest.Create();
					hookLockPointExitRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(creatureDataId);
					hookLockPointExitRequest.HookLockPointExitWay = HookLockPointExitWay.Endpoint;
					FixHookClientLevelEventExecutor.ExecuteHookActions(FixHookClientLevelEventExecutor.EHookPointStage.ClientEndpoint, target);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.CWZ;
					string message = "[CharacterKiteComponent.ExitKiteOnlyMonster]";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HookEntityId", target.Entity.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HookCreatureDataId", creatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("CueHandle", this.KiteHookCueHandle);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
					this.RemoveKiteCue();
					Singleton<Net>.Instance.Call<HookLockPointExitResponse>(ERequestMessageId.HookLockPointExitRequest, hookLockPointExitRequest, delegate(HookLockPointExitResponse response, Net.CallbackStatus _)
					{
					}, 0);
					if (target.WillBeDestroyedAfterHook)
					{
						HookLockPointFinishRequest hookLockPointFinishRequest = HookLockPointFinishRequest.Create();
						hookLockPointFinishRequest.EntityId = creatureDataId;
						Singleton<Net>.Instance.Call<HookLockPointFinishResponse>(ERequestMessageId.HookLockPointFinishRequest, hookLockPointFinishRequest, delegate(HookLockPointFinishResponse response, Net.CallbackStatus _)
						{
						}, 0);
						return;
					}
					if (target.WillBeHideAfterHook)
					{
						ControllerBase<CreatureController>.Instance.SetEntityEnable(target.Entity, false, "ExitKiteOnlyMonster.SendHookEndRequest", true);
					}
					return;
				}
			}
		}

		// Token: 0x06030F31 RID: 200497 RVA: 0x00C260F0 File Offset: 0x00C242F0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterKiteComponent characterKiteComponent = (CharacterKiteComponent)componentTemplate;
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (characterKiteComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TargetPrevPos") && characterKiteComponent.TargetPrevPos != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TargetPrevPos), "TargetPrevPos"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CurrentTarget"))
			{
				if (characterKiteComponent.CurrentTarget == null)
				{
					this.CurrentTarget = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GrapplingHookPointComponent>(this.CurrentTarget), "CurrentTarget"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("LastTargetEndCount"))
			{
				this.LastTargetEndCount = characterKiteComponent.LastTargetEndCount;
			}
			if (base.CanResetComponentProperty("LastTargetMoveBrokenCount"))
			{
				this.LastTargetMoveBrokenCount = characterKiteComponent.LastTargetMoveBrokenCount;
			}
			if (base.CanResetComponentProperty("PrevLocation") && characterKiteComponent.PrevLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.PrevLocation), "PrevLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("PrevLocationTime"))
			{
				this.PrevLocationTime = characterKiteComponent.PrevLocationTime;
			}
			if (base.CanResetComponentProperty("PrevLocationBlockCount"))
			{
				this.PrevLocationBlockCount = characterKiteComponent.PrevLocationBlockCount;
			}
			if (base.CanResetComponentProperty("RefTargetForward"))
			{
				this.RefTargetForward = characterKiteComponent.RefTargetForward;
			}
			if (base.CanResetComponentProperty("UseNewKiteMode"))
			{
				this.UseNewKiteMode = characterKiteComponent.UseNewKiteMode;
			}
			if (base.CanResetComponentProperty("KiteVelocity") && characterKiteComponent.KiteVelocity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.KiteVelocity), "KiteVelocity"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("KiteDistToTarget"))
			{
				this.KiteDistToTarget = characterKiteComponent.KiteDistToTarget;
			}
			if (base.CanResetComponentProperty("TargetForward") && characterKiteComponent.TargetForward != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TargetForward), "TargetForward"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TargetForwardInited"))
			{
				this.TargetForwardInited = characterKiteComponent.TargetForwardInited;
			}
			if (base.CanResetComponentProperty("KiteConfigData"))
			{
				if (characterKiteComponent.KiteConfigData == null)
				{
					this.KiteConfigData = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterKiteComponent.KiteConfig>(this.KiteConfigData), "KiteConfigData"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("InMonsterKiteMove"))
			{
				this.InMonsterKiteMove = characterKiteComponent.InMonsterKiteMove;
			}
			if (base.CanResetComponentProperty("KiteHookCueHandle"))
			{
				this.KiteHookCueHandle = characterKiteComponent.KiteHookCueHandle;
			}
			return true;
		}

		// Token: 0x0401C276 RID: 115318
		private const float KITE_MIN_ACCEL_DIST = 300f;

		// Token: 0x0401C277 RID: 115319
		private const float KITE_MAX_ACCEL_DIST = 900f;

		// Token: 0x0401C278 RID: 115320
		private const float KITE_MIN_ACCEL = 1200f;

		// Token: 0x0401C279 RID: 115321
		private const float KITE_MAX_ACCEL = 18000f;

		// Token: 0x0401C27A RID: 115322
		private const float KITE_FRICTION = 0.98f;

		// Token: 0x0401C27B RID: 115323
		private const float KITE_FACING_LERP_SPEED = 240f;

		// Token: 0x0401C27C RID: 115324
		private const float KITE_FACING_LERP_RATE = 0.9f;

		// Token: 0x0401C27D RID: 115325
		private const float KITE_MAX_BLOCK = 1f;

		// Token: 0x0401C27E RID: 115326
		private const float BLOCK_DIST_THRESHOLD_SQUARED = 40000f;

		// Token: 0x0401C27F RID: 115327
		private const int KITE_BLOCK_COUNT = 3;

		// Token: 0x0401C280 RID: 115328
		private static readonly int hookKeepAttachedTag = GameplayTagDefine.EGameplayTagId["关卡.Common.表现.钩锁不自动脱离"];

		// Token: 0x0401C281 RID: 115329
		private const long HOOK_BUFF_EFFECT_CUE = 7000000100L;

		// Token: 0x0401C282 RID: 115330
		[Nullable(2)]
		private CharacterMoveComponent MoveComp;

		// Token: 0x0401C283 RID: 115331
		private readonly global::Vector TargetPrevPos = global::Vector.Create();

		// Token: 0x0401C284 RID: 115332
		[Nullable(2)]
		private GrapplingHookPointComponent CurrentTarget;

		// Token: 0x0401C285 RID: 115333
		private int LastTargetEndCount;

		// Token: 0x0401C286 RID: 115334
		private int LastTargetMoveBrokenCount;

		// Token: 0x0401C287 RID: 115335
		private readonly global::Vector PrevLocation = global::Vector.Create();

		// Token: 0x0401C288 RID: 115336
		private float PrevLocationTime;

		// Token: 0x0401C289 RID: 115337
		private int PrevLocationBlockCount;

		// Token: 0x0401C28A RID: 115338
		private FVector RefTargetForward;

		// Token: 0x0401C28B RID: 115339
		private bool UseNewKiteMode = true;

		// Token: 0x0401C28C RID: 115340
		private readonly global::Vector KiteVelocity = global::Vector.Create();

		// Token: 0x0401C28D RID: 115341
		private double KiteDistToTarget;

		// Token: 0x0401C28E RID: 115342
		private readonly global::Vector TargetForward = global::Vector.Create();

		// Token: 0x0401C28F RID: 115343
		private bool TargetForwardInited;

		// Token: 0x0401C290 RID: 115344
		[Nullable(2)]
		private CharacterKiteComponent.KiteConfig KiteConfigData;

		// Token: 0x0401C291 RID: 115345
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TmpTargetPos = global::Vector.Create();

		// Token: 0x0401C292 RID: 115346
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TmpGravityDelta = global::Vector.Create();

		// Token: 0x0401C293 RID: 115347
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TmpTentativePos = global::Vector.Create();

		// Token: 0x0401C294 RID: 115348
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TmpMoveDelta = global::Vector.Create();

		// Token: 0x0401C295 RID: 115349
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TmpToTarget = global::Vector.Create();

		// Token: 0x0401C296 RID: 115350
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TmpNewTargetForward = global::Vector.Create();

		// Token: 0x0401C297 RID: 115351
		[StaticVariableRuleIgnore]
		private static readonly global::Vector TmpActorForward = global::Vector.Create();

		// Token: 0x0401C298 RID: 115352
		[StaticVariableRuleIgnore]
		private static readonly Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401C299 RID: 115353
		[StaticVariableRuleIgnore]
		private static readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401C29A RID: 115354
		[StaticVariableRuleIgnore]
		private static readonly global::Rotator TmpRotator = global::Rotator.Create();

		// Token: 0x0401C29B RID: 115355
		private bool InMonsterKiteMove;

		// Token: 0x0401C29C RID: 115356
		private int KiteHookCueHandle;

		// Token: 0x0200A9C3 RID: 43459
		[NullableContext(0)]
		private class KiteConfig
		{
			// Token: 0x040348BE RID: 215230
			public float Gravity;

			// Token: 0x040348BF RID: 215231
			public float InertiaDecay;

			// Token: 0x040348C0 RID: 215232
			public float MinDist;

			// Token: 0x040348C1 RID: 215233
			public float ShrinkSpeed;
		}
	}
}
