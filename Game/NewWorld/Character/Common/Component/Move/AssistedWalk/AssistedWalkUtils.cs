using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Level.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk
{
	// Token: 0x02004946 RID: 18758
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AssistedWalkUtils : Singleton<AssistedWalkUtils>
	{
		// Token: 0x060310BF RID: 200895 RVA: 0x00C3187C File Offset: 0x00C2FA7C
		public AssistedWalkUtils()
		{
			this.TmpVector = global::Vector.Create();
		}

		// Token: 0x060310C0 RID: 200896 RVA: 0x00C31890 File Offset: 0x00C2FA90
		public bool ArePartnerComponentsAlive(string logTag, [Nullable(2)] CharacterActorComponent actorComp, params bool[] validFlags)
		{
			for (int i = 0; i < validFlags.Length; i++)
			{
				if (!validFlags[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060310C1 RID: 200897 RVA: 0x00C318B8 File Offset: 0x00C2FAB8
		[NullableContext(2)]
		public SightLockMode SaveAndDisableSightLockMode(CharacterActorComponent actorComp)
		{
			object obj;
			if (actorComp == null)
			{
				obj = null;
			}
			else
			{
				TsBaseCharacter actor = actorComp.Actor;
				if (actor == null)
				{
					obj = null;
				}
				else
				{
					USkeletalMeshComponent mesh = actor.Mesh;
					obj = ((mesh != null) ? mesh.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE) : null);
				}
			}
			UKuroAnimInstanceChar ukuroAnimInstanceChar = obj as UKuroAnimInstanceChar;
			if (ukuroAnimInstanceChar != null)
			{
				SightLockMode sightLockMode = ukuroAnimInstanceChar.SightLockMode;
				ukuroAnimInstanceChar.SightLockMode = SightLockMode.None;
				return sightLockMode;
			}
			return SightLockMode.None;
		}

		// Token: 0x060310C2 RID: 200898 RVA: 0x00C31910 File Offset: 0x00C2FB10
		[NullableContext(2)]
		public void RestoreSightLockMode(CharacterActorComponent actorComp, SightLockMode savedMode = SightLockMode.None)
		{
			object obj;
			if (actorComp == null)
			{
				obj = null;
			}
			else
			{
				TsBaseCharacter actor = actorComp.Actor;
				if (actor == null)
				{
					obj = null;
				}
				else
				{
					USkeletalMeshComponent mesh = actor.Mesh;
					obj = ((mesh != null) ? mesh.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE) : null);
				}
			}
			UKuroAnimInstanceChar ukuroAnimInstanceChar = obj as UKuroAnimInstanceChar;
			if (ukuroAnimInstanceChar != null)
			{
				ukuroAnimInstanceChar.SightLockMode = savedMode;
			}
		}

		// Token: 0x060310C3 RID: 200899 RVA: 0x00C3195C File Offset: 0x00C2FB5C
		public unsafe void RequestStartAssistedWalk(string key, CharacterActorComponent leader, BaseActorComponent followerActor, BaseMoveComponent followerMoveComp, string daPath, bool waitAnim, string reason = "", EHandType leaderHandType = EHandType.Right)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[AttachMove][AssistedWalk] RequestStart";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", key);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "Leader";
			Entity entity = leader.Entity;
			ptr = new ValueTuple<string, object>(item, (entity != null) ? new int?(entity.Id) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item2 = "Follower";
			Entity entity2 = followerActor.Entity;
			ptr2 = new ValueTuple<string, object>(item2, (entity2 != null) ? new int?(entity2.Id) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			Entity entity3 = leader.Entity;
			int leaderId = (entity3 != null) ? entity3.Id : 0;
			Entity entity4 = followerActor.Entity;
			int followerId = (entity4 != null) ? entity4.Id : 0;
			Singleton<AttachMoveUtils>.Instance.DeduplicateRelations(key, leaderId, followerId, "[AttachMove][AssistedWalk]");
			this.SendHoldHandRequest(leader, followerActor, leaderHandType, true);
			this.StartAssistedWalkWithPrePosition(leader, followerActor, followerMoveComp, daPath, waitAnim, delegate
			{
				Singleton<AttachMoveUtils>.Instance.DeleteRelation(key, "底层 endCallback 自然结束");
			});
			Singleton<AttachMoveUtils>.Instance.AddRelation(key, leader, followerActor, followerMoveComp, delegate
			{
				BaseMoveComponent moveComp = leader.MoveComp;
				if (moveComp != null)
				{
					MoveToLocationController moveController = moveComp.MoveController;
					if (moveController != null)
					{
						moveController.StopAssistedWalk();
					}
				}
				MoveToLocationController moveController2 = followerMoveComp.MoveController;
				if (moveController2 == null)
				{
					return;
				}
				moveController2.StopAssistedWalk();
			});
		}

		// Token: 0x060310C4 RID: 200900 RVA: 0x00C31AFC File Offset: 0x00C2FCFC
		public void RequestStopAssistedWalk(string key, string reason = "", EHandType leaderHandType = EHandType.Right)
		{
			AttachMoveRelation relation = Singleton<AttachMoveUtils>.Instance.GetRelation(key);
			if (((relation != null) ? relation.Leader : null) != null && relation.FollowerActor != null)
			{
				this.SendHoldHandRequest(relation.Leader, relation.FollowerActor, leaderHandType, false);
			}
			Singleton<AttachMoveUtils>.Instance.RequestStop(key, reason);
		}

		// Token: 0x060310C5 RID: 200901 RVA: 0x00C31B4B File Offset: 0x00C2FD4B
		[return: Nullable(2)]
		public AttachMoveRelation GetRelation(string key)
		{
			return Singleton<AttachMoveUtils>.Instance.GetRelation(key);
		}

		// Token: 0x060310C6 RID: 200902 RVA: 0x00C31B58 File Offset: 0x00C2FD58
		[NullableContext(2)]
		public AttachMoveRelation GetRelationByEntityId(int entityId)
		{
			return Singleton<AttachMoveUtils>.Instance.GetRelationByEntityId(entityId);
		}

		// Token: 0x060310C7 RID: 200903 RVA: 0x00C31B68 File Offset: 0x00C2FD68
		public void SendHoldHandRequest(CharacterActorComponent leader, BaseActorComponent follower, EHandType leaderHandType, bool isHold)
		{
			HoldHandRequest holdHandRequest = HoldHandRequest.Create();
			holdHandRequest.HostPlayerId = ModelBase<CreatureModel>.Instance.GetWorldOwner();
			holdHandRequest.EntityId = leader.CreatureData.GetCreatureDataId();
			holdHandRequest.TargetEntityId = follower.CreatureData.GetCreatureDataId();
			holdHandRequest.HandType = (int)leaderHandType;
			holdHandRequest.IsHold = isHold;
			holdHandRequest.ActionType = 1;
			Singleton<Net>.Instance.Call<HoldHandResponse>(ERequestMessageId.HoldHandRequest, holdHandRequest, delegate(HoldHandResponse _, Net.CallbackStatus _)
			{
			}, 0);
		}

		// Token: 0x060310C8 RID: 200904 RVA: 0x00C31BF4 File Offset: 0x00C2FDF4
		private void StartAssistedWalkWithPrePosition(CharacterActorComponent leader, BaseActorComponent followerActor, BaseMoveComponent followerMoveComp, string daPath, bool waitAnim, [Nullable(2)] Action endCallback = null)
		{
			AssistedWalkUtils.<>c__DisplayClass10_0 CS$<>8__locals1 = new AssistedWalkUtils.<>c__DisplayClass10_0();
			CS$<>8__locals1.followerMoveComp = followerMoveComp;
			CS$<>8__locals1.leader = leader;
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.followerActor = followerActor;
			CS$<>8__locals1.endCallback = endCallback;
			CS$<>8__locals1.waitAnim = waitAnim;
			AssistedWalkUtils.<>c__DisplayClass10_0 CS$<>8__locals2 = CS$<>8__locals1;
			Entity entity = CS$<>8__locals1.leader.Entity;
			CS$<>8__locals2.leaderActComp = ((entity != null) ? entity.GetComponent<CharacterCustomActionComponent>() : null);
			BaseMoveComponent moveComp = CS$<>8__locals1.leader.MoveComp;
			if (((moveComp != null) ? moveComp.MoveController : null) == null || CS$<>8__locals1.leaderActComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[AttachMove][AssistedWalk] 前置编排缺少 Leader Move/Action 组件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DaPath", daPath);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			CS$<>8__locals1.data = Singleton<ResourceSystem>.Instance.Load<BP_AssistedWalkConfig_C>(daPath, "js_undefined");
			BP_AssistedWalkConfig_C data = CS$<>8__locals1.data;
			if (data == null || !data.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Movement;
				ELogAuthor author2 = ELogAuthor.CWZ;
				string message2 = "[AttachMove][AssistedWalk] 获取搀扶配置DA失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("DaPath", daPath);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			CS$<>8__locals1.@params = new AssistedWalkParams(CS$<>8__locals1.data);
			ValueTuple<global::Transform, float>? valueTuple3 = Singleton<AttachMoveUtils>.Instance.PreviewLeaderTransform(CS$<>8__locals1.leader, CS$<>8__locals1.followerActor, CS$<>8__locals1.@params.AttachSocket, CS$<>8__locals1.@params.StartTransform);
			if (valueTuple3 == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Movement;
				ELogAuthor author3 = ELogAuthor.CWZ;
				string message3 = "[AttachMove][AssistedWalk] 反推 Leader 站位失败，跳过预移动直接启动";
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("DaPath", daPath);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
				bool exited = false;
				this.StartAssistedWalkBoth(CS$<>8__locals1.leader, CS$<>8__locals1.followerMoveComp, CS$<>8__locals1.data, CS$<>8__locals1.waitAnim, delegate(bool isLeader)
				{
					if (exited)
					{
						return;
					}
					exited = true;
					if (isLeader)
					{
						MoveToLocationController moveController = CS$<>8__locals1.followerMoveComp.MoveController;
						if (moveController != null)
						{
							moveController.StopAssistedWalk();
						}
					}
					else
					{
						BaseMoveComponent moveComp2 = CS$<>8__locals1.leader.MoveComp;
						if (moveComp2 != null)
						{
							MoveToLocationController moveController2 = moveComp2.MoveController;
							if (moveController2 != null)
							{
								moveController2.StopAssistedWalk();
							}
						}
					}
					CS$<>8__locals1.<>4__this.PushOutLeader(CS$<>8__locals1.leader, CS$<>8__locals1.followerActor);
					Action endCallback2 = CS$<>8__locals1.endCallback;
					if (endCallback2 == null)
					{
						return;
					}
					endCallback2();
				});
				return;
			}
			this.TmpVector.DeepCopy(valueTuple3.Value.Item1.GetLocation());
			this.TmpVector.Z = CS$<>8__locals1.leader.ActorLocationProxy.Z;
			if (CS$<>8__locals1.data.Debug)
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, this.TmpVector.ToUeVector(false), 30f, 10, new FLinearColor?(ColorUtils.LinearRed), 5f, 0f);
			}
			ValueTuple<global::Transform, float> value = valueTuple3.Value;
			CS$<>8__locals1.leaderActComp.AddCustomSetPlayerControl(true, null);
			CS$<>8__locals1.leaderActComp.AddCustomSetCollision(CS$<>8__locals1.followerActor, true, null);
			CS$<>8__locals1.leaderActComp.AddCustomMoveToLocation(this.TmpVector, delegate
			{
				double num = CS$<>8__locals1.<>4__this.CalculateFaceToFollowerTurnAngle(CS$<>8__locals1.@params.StartTransform.GetLocation());
				CharacterCustomActionComponent leaderActComp = CS$<>8__locals1.leaderActComp;
				BaseActorComponent followerActor2 = CS$<>8__locals1.followerActor;
				double angle = num;
				ECustomSetRotationType type = ECustomSetRotationType.FaceToTarget;
				Action callback;
				if ((callback = CS$<>8__locals1.<>9__2) == null)
				{
					callback = (CS$<>8__locals1.<>9__2 = delegate()
					{
						bool exited = false;
						CS$<>8__locals1.<>4__this.StartAssistedWalkBoth(CS$<>8__locals1.leader, CS$<>8__locals1.followerMoveComp, CS$<>8__locals1.data, CS$<>8__locals1.waitAnim, delegate(bool isLeader)
						{
							if (exited)
							{
								return;
							}
							exited = true;
							if (isLeader)
							{
								MoveToLocationController moveController = CS$<>8__locals1.followerMoveComp.MoveController;
								if (moveController != null)
								{
									moveController.StopAssistedWalk();
								}
							}
							else
							{
								BaseMoveComponent moveComp2 = CS$<>8__locals1.leader.MoveComp;
								if (moveComp2 != null)
								{
									MoveToLocationController moveController2 = moveComp2.MoveController;
									if (moveController2 != null)
									{
										moveController2.StopAssistedWalk();
									}
								}
							}
							CS$<>8__locals1.<>4__this.PushOutLeader(CS$<>8__locals1.leader, CS$<>8__locals1.followerActor);
							Entity entity2 = CS$<>8__locals1.leader.Entity;
							CharacterCustomActionComponent characterCustomActionComponent = (entity2 != null) ? entity2.GetComponent<CharacterCustomActionComponent>() : null;
							AActor owner = CS$<>8__locals1.followerActor.Owner;
							if (owner != null && owner.IsValid() && characterCustomActionComponent != null)
							{
								characterCustomActionComponent.AddCustomSetCollision(CS$<>8__locals1.followerActor, false, null);
							}
							Action endCallback2 = CS$<>8__locals1.endCallback;
							if (endCallback2 == null)
							{
								return;
							}
							endCallback2();
						});
					});
				}
				leaderActComp.AddCustomSetTurnToTarget(followerActor2, angle, type, callback, null);
			}, null);
		}

		// Token: 0x060310C9 RID: 200905 RVA: 0x00C31E7C File Offset: 0x00C3007C
		private double CalculateFaceToFollowerTurnAngle(global::Vector localOffset)
		{
			if (localOffset.X == 0.0 && localOffset.Y == 0.0)
			{
				return 0.0;
			}
			return Singleton<MathUtils>.Instance.WrapAngle(Math.Atan2(localOffset.Y, -localOffset.X) * 57.295780181884766);
		}

		// Token: 0x060310CA RID: 200906 RVA: 0x00C31EDC File Offset: 0x00C300DC
		public void StartAssistedWalkBoth(CharacterActorComponent leader, BaseMoveComponent followerMoveComp, BP_AssistedWalkConfig_C data, bool waitAnim, [Nullable(2)] Action<bool> endCallback = null)
		{
			BaseMoveComponent moveComp = leader.MoveComp;
			if (moveComp != null)
			{
				moveComp.MoveController.StartLeaderAssistedWalkWithData(data, (endCallback != null) ? delegate()
				{
					endCallback(true);
				} : null, waitAnim);
			}
			followerMoveComp.MoveController.StartAssistedWalkWithData(leader, data, (endCallback != null) ? delegate()
			{
				endCallback(false);
			} : null, waitAnim);
		}

		// Token: 0x060310CB RID: 200907 RVA: 0x00C31F50 File Offset: 0x00C30150
		public void PushOutLeader(CharacterActorComponent leader, BaseActorComponent followerActor)
		{
			TsBaseCharacter actor = leader.Actor;
			UCapsuleComponent ucapsuleComponent = (actor != null) ? actor.CapsuleComponent : null;
			ACharacter acharacter = followerActor.Owner as ACharacter;
			UCapsuleComponent ucapsuleComponent2 = (acharacter != null) ? acharacter.CapsuleComponent : null;
			if (ucapsuleComponent == null || !ucapsuleComponent.IsValid() || (ucapsuleComponent2 == null || !ucapsuleComponent2.IsValid()))
			{
				return;
			}
			float scaledCapsuleRadius = ucapsuleComponent.GetScaledCapsuleRadius();
			float scaledCapsuleRadius2 = ucapsuleComponent2.GetScaledCapsuleRadius();
			float num = scaledCapsuleRadius + scaledCapsuleRadius2;
			global::Vector actorLocationProxy = leader.ActorLocationProxy;
			global::Vector actorLocationProxy2 = followerActor.ActorLocationProxy;
			double num2 = global::Vector.Dist2D(actorLocationProxy, actorLocationProxy2);
			if (num2 >= (double)num)
			{
				return;
			}
			double inB = (double)num - num2 + 1.0;
			global::Vector tmpVector = this.TmpVector;
			actorLocationProxy.Subtraction(actorLocationProxy2, tmpVector);
			tmpVector.Z = 0.0;
			if (!tmpVector.Normalize(9.99999993922529E-09))
			{
				tmpVector.Set(1.0, 0.0, 0.0);
			}
			tmpVector.MultiplyEqual(inB);
			tmpVector.AdditionEqual(actorLocationProxy);
			leader.SetActorLocation(tmpVector.ToUeVector(false), "AssistedWalk.ExitPushOut", false);
		}

		// Token: 0x0401C3D5 RID: 115669
		private readonly global::Vector TmpVector;
	}
}
