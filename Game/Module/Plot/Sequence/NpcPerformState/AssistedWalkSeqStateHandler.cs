using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Data.Level.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AssistedWalk;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move.AttachMove;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.NpcPerformState
{
	// Token: 0x0200539A RID: 21402
	[NullableContext(1)]
	[Nullable(0)]
	public class AssistedWalkSeqStateHandler : SeqNpcPerformStateHandler
	{
		// Token: 0x17008DA8 RID: 36264
		// (get) Token: 0x06036943 RID: 223555 RVA: 0x00DCC3D4 File Offset: 0x00DCA5D4
		public override ENpcGroupPerformType PerformType
		{
			get
			{
				return ENpcGroupPerformType.SupportedWalking;
			}
		}

		// Token: 0x17008DA9 RID: 36265
		// (get) Token: 0x06036944 RID: 223556 RVA: 0x00DCC3D7 File Offset: 0x00DCA5D7
		public override ENpcRelationType RelationType
		{
			get
			{
				return ENpcRelationType.AssistedWalk;
			}
		}

		// Token: 0x06036945 RID: 223557 RVA: 0x00DCC3DC File Offset: 0x00DCA5DC
		[return: Nullable(2)]
		public override NpcRelation Capture(string key)
		{
			AttachMoveRelation relation = Singleton<AttachMoveUtils>.Instance.GetRelation(key);
			if (relation == null)
			{
				return null;
			}
			return new AssistedWalkSeqRelation
			{
				Key = key,
				LeaderEntityId = relation.LeaderEntityId,
				FollowerEntityId = relation.FollowerEntityId
			};
		}

		// Token: 0x06036946 RID: 223558 RVA: 0x00DCC420 File Offset: 0x00DCA620
		public unsafe override void Restore(NpcRelation relation, string reason)
		{
			AssistedWalkSeqRelation assistedWalkSeqRelation = relation as AssistedWalkSeqRelation;
			Entity entity = Singleton<EntitySystem>.Instance.Get(assistedWalkSeqRelation.LeaderEntityId);
			Entity entity2 = Singleton<EntitySystem>.Instance.Get(assistedWalkSeqRelation.FollowerEntityId);
			CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
			BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
			BaseMoveComponent baseMoveComponent = (entity2 != null) ? entity2.GetComponent<BaseMoveComponent>() : null;
			if (characterActorComponent == null || !characterActorComponent.Valid || (baseActorComponent == null || !baseActorComponent.Valid) || baseMoveComponent == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[SeqNpcPerformState] 搀扶恢复失败：Leader / Follower 组件无效";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Key", assistedWalkSeqRelation.Key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LeaderEntityId", assistedWalkSeqRelation.LeaderEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FollowerEntityId", assistedWalkSeqRelation.FollowerEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("LeaderValid", (characterActorComponent != null) ? new bool?(characterActorComponent.Valid) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("FollowerValid", (baseActorComponent != null) ? new bool?(baseActorComponent.Valid) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("FollowerMoveComp", baseMoveComponent != null);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
				return;
			}
			this.StartAssistedWalkImmediate(assistedWalkSeqRelation.Key, characterActorComponent, baseActorComponent, baseMoveComponent, reason);
		}

		// Token: 0x06036947 RID: 223559 RVA: 0x00DCC5CC File Offset: 0x00DCA7CC
		private unsafe void StartAssistedWalkImmediate(string key, CharacterActorComponent leader, BaseActorComponent followerActor, BaseMoveComponent followerMoveComp, string reason)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[AttachMove][AssistedWalk] RequestStartImmediate";
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
			Singleton<AttachMoveUtils>.Instance.DeduplicateRelations(key, leaderId, followerId, "[AttachMove][AssistedWalk][Immediate]");
			BP_AssistedWalkConfig_C bp_AssistedWalkConfig_C = Singleton<ResourceSystem>.Instance.Load<BP_AssistedWalkConfig_C>("/Game/Aki/Data/Level/AssistedWalk/DA_DefaultAssistedWalkConfig.DA_DefaultAssistedWalkConfig", "js_undefined");
			if (bp_AssistedWalkConfig_C == null || !bp_AssistedWalkConfig_C.IsValid())
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Movement;
				ELogAuthor author2 = ELogAuthor.HYF;
				string message2 = "[AttachMove][AssistedWalk][Immediate] 获取搀扶配置DA失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DaPath", "/Game/Aki/Data/Level/AssistedWalk/DA_DefaultAssistedWalkConfig.DA_DefaultAssistedWalkConfig");
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			AssistedWalkParams assistedWalkParams = new AssistedWalkParams(bp_AssistedWalkConfig_C);
			Singleton<AssistedWalkUtils>.Instance.SendHoldHandRequest(leader, followerActor, global::EHandType.Right, true);
			this.TeleportFollowerToAttachPose(leader, followerActor, assistedWalkParams.AttachSocket, assistedWalkParams.StartTransform);
			bool exited = false;
			Singleton<AssistedWalkUtils>.Instance.StartAssistedWalkBoth(leader, followerMoveComp, bp_AssistedWalkConfig_C, false, delegate(bool isLeader)
			{
				if (exited)
				{
					return;
				}
				exited = true;
				if (isLeader)
				{
					MoveToLocationController moveController = followerMoveComp.MoveController;
					if (moveController != null)
					{
						moveController.StopAssistedWalk();
					}
				}
				else
				{
					BaseMoveComponent moveComp = leader.MoveComp;
					if (moveComp != null)
					{
						MoveToLocationController moveController2 = moveComp.MoveController;
						if (moveController2 != null)
						{
							moveController2.StopAssistedWalk();
						}
					}
				}
				Singleton<AssistedWalkUtils>.Instance.PushOutLeader(leader, followerActor);
				Singleton<AttachMoveUtils>.Instance.DeleteRelation(key, "底层 endCallback 自然结束(Immediate)");
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

		// Token: 0x06036948 RID: 223560 RVA: 0x00DCC80C File Offset: 0x00DCAA0C
		private unsafe void TeleportFollowerToAttachPose(CharacterActorComponent leader, BaseActorComponent followerActor, string socket, global::Transform attachTransform)
		{
			TsBaseCharacter actor = leader.Actor;
			USkeletalMeshComponent uskeletalMeshComponent = (actor != null) ? actor.Mesh : null;
			if (uskeletalMeshComponent == null || !uskeletalMeshComponent.IsValid() || socket.Length < 1)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "[AttachMove][AssistedWalk][Immediate] 瞬移 Follower 失败：Leader Mesh / Socket 无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Socket", socket);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LeaderPbId", leader.CreatureData.GetPbDataId());
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			FName inSocketName = new FName(socket);
			FTransformDouble ftransformDouble = uskeletalMeshComponent.D_GetSocketTransform(inSocketName, ERelativeTransformSpace.RTS_Actor);
			FTransformDouble ftransformDouble2 = attachTransform.ToUeTransform();
			FTransformDouble ftransformDouble3 = UKismetMathLibrary.D_ComposeTransforms(ftransformDouble2, ftransformDouble);
			global::Transform transform = global::Transform.Create(leader.ActorTransform);
			ftransformDouble2 = transform.ToUeTransform();
			FTransformDouble ftransformDouble4 = UKismetMathLibrary.D_ComposeTransforms(ftransformDouble3, ftransformDouble2);
			FQuat rotation = ftransformDouble4.GetRotation();
			FRotator rotation2 = UKismetMathLibrary.Quat_Rotator(rotation);
			followerActor.SetActorLocationAndRotation(ftransformDouble4.GetTranslation(), rotation2, "AssistedWalk.ImmediateTeleport", false, null);
			this.SyncNpcLocationToServer(followerActor);
		}

		// Token: 0x06036949 RID: 223561 RVA: 0x00DCC92C File Offset: 0x00DCAB2C
		private unsafe void SyncNpcLocationToServer(BaseActorComponent followerActor)
		{
			Entity entity = followerActor.Entity;
			int? num = (entity != null) ? new int?(entity.Id) : null;
			if (num == null)
			{
				return;
			}
			if (WorldFunctionLibrary.GetEntityTypeByEntity(num.Value) != 1)
			{
				return;
			}
			EntitySimplyMoveInfoPackagePush entitySimplyMoveInfoPackagePush = EntitySimplyMoveInfoPackagePush.Create();
			EntitySimplyMoveInfo entitySimplyMoveInfo = EntitySimplyMoveInfo.Create();
			entitySimplyMoveInfo.EntityId = Singleton<MathUtils>.Instance.NumberToLong(followerActor.CreatureData.GetCreatureDataId());
			entitySimplyMoveInfo.Location = followerActor.ActorLocationProxy.ToProtocolVector();
			entitySimplyMoveInfo.Rotation = followerActor.ActorRotationProxy.ToProtocolRotator();
			entitySimplyMoveInfoPackagePush.MoveInfos.Add(entitySimplyMoveInfo);
			Singleton<Net>.Instance.Send(EPushMessageId.EntitySimplyMoveInfoPackagePush, entitySimplyMoveInfoPackagePush);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "[AttachMove][AssistedWalk][Immediate] 向服务器同步NPC位置";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("实体ID", entitySimplyMoveInfo.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("X", entitySimplyMoveInfo.Location.X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Y", entitySimplyMoveInfo.Location.Y);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Z", entitySimplyMoveInfo.Location.Z);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
	}
}
