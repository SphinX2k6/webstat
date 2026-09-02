using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Module.MonsterGroup
{
	// Token: 0x02005727 RID: 22311
	[NullableContext(1)]
	[Nullable(0)]
	public class MonsterGroupEcologyInfo
	{
		// Token: 0x06038C6B RID: 232555 RVA: 0x00E602C0 File Offset: 0x00E5E4C0
		public MonsterGroupEcologyInfo(int groupId)
		{
			this.GroupId = groupId;
		}

		// Token: 0x17009125 RID: 37157
		// (get) Token: 0x06038C6C RID: 232556 RVA: 0x00E60321 File Offset: 0x00E5E521
		public int GroupMemberCount
		{
			get
			{
				return this.GroupInfo.Count;
			}
		}

		// Token: 0x17009126 RID: 37158
		// (get) Token: 0x06038C6D RID: 232557 RVA: 0x00E60330 File Offset: 0x00E5E530
		[Nullable(2)]
		public MonsterEcologyInfo CaptainInfo
		{
			[NullableContext(2)]
			get
			{
				MonsterEcologyInfo result;
				this.GroupInfo.TryGetValue(this.CaptainId, out result);
				return result;
			}
		}

		// Token: 0x06038C6E RID: 232558 RVA: 0x00E60354 File Offset: 0x00E5E554
		public bool Init(GroupAiComponent groupComp, IReadOnlyList<int> initialPbDataIds)
		{
			if (groupComp.Option.Type != EGroupAiMode.MonsterEcology)
			{
				return true;
			}
			this.LeaderPbDataId = (groupComp.Option as IGroupAiMonsterEcology).Leader;
			foreach (int pbDataId in initialPbDataIds)
			{
				this.TryAddMember(pbDataId);
			}
			return this.GroupInfo.Count > 0;
		}

		// Token: 0x06038C6F RID: 232559 RVA: 0x00E603D4 File Offset: 0x00E5E5D4
		public bool TryAddMember(int pbDataId)
		{
			CharacterActorComponent characterActorComponent = MonsterGroupEcologyInfo.TryResolveActorComp(pbDataId);
			if (characterActorComponent == null)
			{
				return false;
			}
			int id = characterActorComponent.Entity.Id;
			if (this.GroupInfo.ContainsKey(id))
			{
				return false;
			}
			bool flag = pbDataId == this.LeaderPbDataId;
			MonsterEcologyInfo value = new MonsterEcologyInfo(pbDataId, characterActorComponent, this, flag);
			this.GroupInfo[id] = value;
			if (flag)
			{
				this.CaptainId = id;
			}
			return true;
		}

		// Token: 0x06038C70 RID: 232560 RVA: 0x00E60438 File Offset: 0x00E5E638
		public bool HasMemberByPbDataId(int pbDataId)
		{
			foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
			{
				if (keyValuePair.Value.PbDataId == pbDataId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06038C71 RID: 232561 RVA: 0x00E6049C File Offset: 0x00E5E69C
		public bool RemoveMemberByEntityId(int entityId)
		{
			MonsterEcologyInfo monsterEcologyInfo;
			if (!this.GroupInfo.TryGetValue(entityId, out monsterEcologyInfo))
			{
				return false;
			}
			bool flag = monsterEcologyInfo.IsCaptain || this.CaptainId == entityId;
			this.GroupInfo.Remove(entityId);
			if (flag)
			{
				this.CaptainId = -1;
			}
			return true;
		}

		// Token: 0x06038C72 RID: 232562 RVA: 0x00E604E8 File Offset: 0x00E5E6E8
		public void CheckMembersValid()
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
			{
				MonsterEcologyInfo value = keyValuePair.Value;
				if (value.ActorComp == null || !value.ActorComp.Valid || value.MoveComp == null || !value.MoveComp.Valid)
				{
					list.Add(value.EntityId);
				}
			}
			foreach (int entityId in list)
			{
				this.RemoveMemberByEntityId(entityId);
			}
		}

		// Token: 0x06038C73 RID: 232563 RVA: 0x00E605BC File Offset: 0x00E5E7BC
		public bool HasAnyInState(EGroupEcologyState state)
		{
			foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
			{
				if (keyValuePair.Value.GroupEcologyState == state)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06038C74 RID: 232564 RVA: 0x00E60620 File Offset: 0x00E5E820
		public bool IsAllInState(EGroupEcologyState state)
		{
			if (this.GroupInfo.Count == 0)
			{
				return false;
			}
			foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
			{
				if (keyValuePair.Value.GroupEcologyState != state)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06038C75 RID: 232565 RVA: 0x00E60694 File Offset: 0x00E5E894
		public void Tick()
		{
			if (this.InGroupEcologyPerform && !this.IsAllInState(EGroupEcologyState.Ecology))
			{
				this.InGroupEcologyPerform = false;
				foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
				{
					MonsterEcologyInfo value = keyValuePair.Value;
					if (value.GroupEcologyState == EGroupEcologyState.Ecology)
					{
						value.GroupEcologyState = EGroupEcologyState.Ready;
					}
				}
			}
			if (this.HasAnyInState(EGroupEcologyState.Ready))
			{
				this.MoveAllReadyMembersToTarget();
			}
			if (!this.InGroupEcologyPerform && this.IsAllInState(EGroupEcologyState.Ecology))
			{
				this.InGroupEcologyPerform = true;
				this.OnGroupEcologyPerform();
			}
		}

		// Token: 0x06038C76 RID: 232566 RVA: 0x00E60740 File Offset: 0x00E5E940
		protected virtual void OnGroupEcologyPerform()
		{
			foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
			{
				BaseGroupAiComponent groupAiComp = keyValuePair.Value.GroupAiComp;
				if (groupAiComp != null)
				{
					groupAiComp.RunEcologyAction();
				}
			}
		}

		// Token: 0x06038C77 RID: 232567 RVA: 0x00E607A4 File Offset: 0x00E5E9A4
		[return: Nullable(2)]
		protected virtual Vector GetMemberTargetLocation(MonsterEcologyInfo info)
		{
			MonsterEcologyInfo captainInfo = this.CaptainInfo;
			CharacterActorComponent characterActorComponent = (captainInfo != null) ? captainInfo.ActorComp : null;
			if (characterActorComponent == null)
			{
				return null;
			}
			BaseGroupAiComponent groupAiComp = info.GroupAiComp;
			Transform transform = (groupAiComp != null) ? groupAiComp.GetEcologyRelativeTransform() : null;
			if (transform == null)
			{
				return null;
			}
			this.TmpCaptainQuat.FromUeQuat(characterActorComponent.ActorRotationProxy.Quaternion(null));
			this.TmpCaptainQuat.RotateVector(transform.GetLocation(), this.TmpMemberTargetLocation);
			this.TmpMemberTargetLocation.AdditionEqual(characterActorComponent.ActorLocationProxy);
			return this.TmpMemberTargetLocation;
		}

		// Token: 0x06038C78 RID: 232568 RVA: 0x00E60828 File Offset: 0x00E5EA28
		[return: Nullable(2)]
		protected virtual Rotator GetMemberTargetRotation(MonsterEcologyInfo info)
		{
			BaseGroupAiComponent groupAiComp = info.GroupAiComp;
			Transform transform = (groupAiComp != null) ? groupAiComp.GetEcologyRelativeTransform() : null;
			MonsterEcologyInfo captainInfo = this.CaptainInfo;
			CharacterActorComponent characterActorComponent = (captainInfo != null) ? captainInfo.ActorComp : null;
			if (transform == null || characterActorComponent == null)
			{
				return null;
			}
			this.TmpCaptainQuat.FromUeQuat(characterActorComponent.ActorRotationProxy.Quaternion(null));
			this.TmpCaptainQuat.Multiply(transform.GetRotation(), this.TmpCaptainQuat);
			this.TmpCaptainQuat.Rotator(this.TmpMemberTargetRotation);
			return this.TmpMemberTargetRotation;
		}

		// Token: 0x06038C79 RID: 232569 RVA: 0x00E608AC File Offset: 0x00E5EAAC
		private void MoveAllReadyMembersToTarget()
		{
			foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
			{
				MonsterEcologyInfo value = keyValuePair.Value;
				if (value.GroupEcologyState == EGroupEcologyState.Ready && (value.MoveComp == null || !value.MoveComp.MoveController.IsMoving()))
				{
					this.MoveMemberToTarget(value);
				}
			}
		}

		// Token: 0x06038C7A RID: 232570 RVA: 0x00E6092C File Offset: 0x00E5EB2C
		private void MoveMemberToTarget(MonsterEcologyInfo info)
		{
			BaseMoveComponent moveComp = info.MoveComp;
			if (moveComp == null || !moveComp.Active)
			{
				return;
			}
			Vector memberTargetLocation = this.GetMemberTargetLocation(info);
			if (memberTargetLocation == null)
			{
				return;
			}
			info.TargetLocation.DeepCopy(memberTargetLocation);
			float num = Math.Max(30f, info.ActorComp.Radius);
			MoveToPointConfigImpl moveConfig = new MoveToPointConfigImpl
			{
				Position = info.TargetLocation,
				CallbackList = new List<Action<ELevelEventState>>
				{
					delegate(ELevelEventState result)
					{
						this.OnMoveToTargetCallback(result, info);
					}
				},
				Distance = new double?((double)(30f + num)),
				MoveState = new ECharMoveState?(ECharMoveState.Walk),
				ReturnTimeoutFailed = new float?(3f)
			};
			moveComp.MoveController.NavigateMoveToLocation(moveConfig, new bool?(false), true, "MonsterGroupEcologyInfo.MoveMemberToTarget");
		}

		// Token: 0x06038C7B RID: 232571 RVA: 0x00E60A20 File Offset: 0x00E5EC20
		private unsafe void OnMoveToTargetCallback(ELevelEventState result, MonsterEcologyInfo info)
		{
			if (info.ActorComp == null || !this.GroupInfo.ContainsKey(info.EntityId))
			{
				return;
			}
			Rotator memberTargetRotation = this.GetMemberTargetRotation(info);
			if (memberTargetRotation != null)
			{
				info.TargetRotator.DeepCopy(memberTargetRotation);
			}
			else
			{
				info.TargetRotator.DeepCopy(info.ActorComp.ActorRotationProxy);
			}
			if (result != ELevelEventState.Success)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[GroupAi.Ecology] MoveMemberToTarget 移动失败，强行设置坐标进入生态";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", info.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", info.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Result", result);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				CharacterAnimationComponent component = info.ActorComp.Entity.GetComponent<CharacterAnimationComponent>();
				FTransformDouble? ftransformDouble = (component != null) ? new FTransformDouble?(component.GetMeshTransform()) : null;
				CharacterActorComponent actorComp = info.ActorComp;
				if (actorComp != null)
				{
					actorComp.SetActorLocationAndRotation(info.TargetLocation.ToUeVector(false), info.TargetRotator.ToUeRotator(), "MoveToInitLocationCallback", false, null);
				}
				if (ftransformDouble != null && component != null)
				{
					component.SetModelBuffer(ftransformDouble.Value, 200f);
				}
			}
			else
			{
				CharacterAnimationComponent component2 = info.ActorComp.Entity.GetComponent<CharacterAnimationComponent>();
				FTransformDouble? ftransformDouble2 = (component2 != null) ? new FTransformDouble?(component2.GetMeshTransform()) : null;
				CharacterActorComponent actorComp2 = info.ActorComp;
				if (actorComp2 != null)
				{
					actorComp2.SetActorRotation(info.TargetRotator.ToUeRotator(), "MoveToInitLocationCallback", false);
				}
				if (ftransformDouble2 != null && component2 != null)
				{
					component2.SetModelBuffer(ftransformDouble2.Value, 200f);
				}
			}
			if (MoveToLocationController.DebugDraw)
			{
				UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, info.TargetLocation.ToUeVector(false), 30f, 10, new FLinearColor?(ColorUtils.LinearCyan), 5f, 0f);
			}
			info.GroupEcologyState = EGroupEcologyState.Ecology;
		}

		// Token: 0x06038C7C RID: 232572 RVA: 0x00E60C40 File Offset: 0x00E5EE40
		public bool ShouldRemove()
		{
			return this.GroupInfo.Count == 0;
		}

		// Token: 0x06038C7D RID: 232573 RVA: 0x00E60C50 File Offset: 0x00E5EE50
		public void Clear()
		{
			foreach (KeyValuePair<int, MonsterEcologyInfo> keyValuePair in this.GroupInfo)
			{
				MonsterEcologyInfo value = keyValuePair.Value;
				if (value.GroupEcologyState == EGroupEcologyState.Ecology)
				{
					value.GroupEcologyState = EGroupEcologyState.None;
				}
			}
			this.GroupInfo.Clear();
			this.InGroupEcologyPerform = false;
		}

		// Token: 0x06038C7E RID: 232574 RVA: 0x00E60CC8 File Offset: 0x00E5EEC8
		[NullableContext(2)]
		private static CharacterActorComponent TryResolveActorComp(int pbDataId)
		{
			List<EntityHandle> list = new List<EntityHandle>();
			ModelBase<CreatureModel>.Instance.GetEntitiesWithPbDataId(pbDataId, ref list);
			if (list.Count == 0)
			{
				return null;
			}
			WorldEntity entity = list[0].Entity;
			if (entity == null)
			{
				return null;
			}
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			BaseMoveComponent component2 = entity.GetComponent<BaseMoveComponent>();
			if (component == null || !component.Active || component2 == null || !component2.Active)
			{
				return null;
			}
			return component;
		}

		// Token: 0x04020587 RID: 132487
		private const float TARGET_END_DISTANCE = 30f;

		// Token: 0x04020588 RID: 132488
		private const float TARGET_RETURN_TIMEOUT_FAILED = 3f;

		// Token: 0x04020589 RID: 132489
		private const float SET_ACTOR_ROTATION = 200f;

		// Token: 0x0402058A RID: 132490
		public readonly int GroupId;

		// Token: 0x0402058B RID: 132491
		public Dictionary<int, MonsterEcologyInfo> GroupInfo = new Dictionary<int, MonsterEcologyInfo>();

		// Token: 0x0402058C RID: 132492
		private int CaptainId = -1;

		// Token: 0x0402058D RID: 132493
		private int LeaderPbDataId;

		// Token: 0x0402058E RID: 132494
		private bool InGroupEcologyPerform;

		// Token: 0x0402058F RID: 132495
		private readonly Vector TmpMemberTargetLocation = Vector.Create();

		// Token: 0x04020590 RID: 132496
		private readonly Rotator TmpMemberTargetRotation = Rotator.Create();

		// Token: 0x04020591 RID: 132497
		private readonly Quat TmpCaptainQuat = Quat.Create(0f, 0f, 0f, 1f);
	}
}
