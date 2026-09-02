using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200302E RID: 12334
[NullableContext(2)]
[Nullable(0)]
public class CharacterAttachComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x06019355 RID: 103253 RVA: 0x00734C10 File Offset: 0x00732E10
	protected override bool OnStart()
	{
		this.FollowerList = new List<EntityHandle>();
		this.AttachTag = null;
		this.AttachTargetHandle = null;
		this.AttachState = EAttachState.Detach;
		this.MoveCompDisableHandle = null;
		this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		this.Initial = true;
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnEntityDead));
		return true;
	}

	// Token: 0x06019356 RID: 103254 RVA: 0x00734CBC File Offset: 0x00732EBC
	protected override void OnActivate()
	{
		this.InitAttachToTarget();
		this.InitAttachToThis();
	}

	// Token: 0x06019357 RID: 103255 RVA: 0x00734CCC File Offset: 0x00732ECC
	private void InitAttachToTarget()
	{
		CreatureDataComponent creatureDataComp = this.CreatureDataComp;
		if (creatureDataComp == null || !creatureDataComp.Valid || this.CreatureDataComp.PbCombineTargetServerId == null)
		{
			return;
		}
		long value = this.CreatureDataComp.PbCombineTargetServerId.Value;
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(value);
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null || !entity.Valid)
		{
			return;
		}
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity);
		CharacterAttachComponent component = entity.GetComponent<CharacterAttachComponent>();
		if (component == null || !component.Valid || component.HasFollower(ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity)))
		{
			return;
		}
		CombinePartInfo followerAttachInfo = component.GetFollowerAttachInfo(value);
		if (followerAttachInfo == null)
		{
			return;
		}
		CharacterPartComponent component2 = handleByEntity.Entity.GetComponent<CharacterPartComponent>();
		if (component2 == null || !component2.Valid)
		{
			return;
		}
		CharacterPart partByIndex = component2.GetPartByIndex(followerAttachInfo.PartId);
		if (partByIndex == null || FNameUtil.IsNothing(partByIndex.CombinePartSocketName))
		{
			return;
		}
		Aki.Protocol.Vector offsetPos = followerAttachInfo.OffsetPos;
		float inX = (offsetPos != null) ? offsetPos.X : 0f;
		Aki.Protocol.Vector offsetPos2 = followerAttachInfo.OffsetPos;
		float inY = (offsetPos2 != null) ? offsetPos2.Y : 0f;
		Aki.Protocol.Vector offsetPos3 = followerAttachInfo.OffsetPos;
		FVector socketOffset = new FVector(inX, inY, (offsetPos3 != null) ? offsetPos3.Z : 0f);
		this.StartAttachToTarget(handleByEntity, partByIndex.CombinePartSocketName.Value, socketOffset, followerAttachInfo.PartId, null);
		this.AttachToTarget(handleByEntity, null, false);
	}

	// Token: 0x06019358 RID: 103256 RVA: 0x00734E58 File Offset: 0x00733058
	private void InitAttachToThis()
	{
		CreatureDataComponent creatureDataComp = this.CreatureDataComp;
		if (creatureDataComp == null || !creatureDataComp.Valid || this.CreatureDataComp.PbCombinePartInfoList == null)
		{
			return;
		}
		List<CombinePartInfo> pbCombinePartInfoList = this.CreatureDataComp.PbCombinePartInfoList;
		if (pbCombinePartInfoList == null)
		{
			return;
		}
		int i = 0;
		int count = pbCombinePartInfoList.Count;
		while (i < count)
		{
			CombinePartInfo combinePartInfo = pbCombinePartInfoList[i];
			int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(combinePartInfo.CombinerEntityId);
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity != null && entity.Valid)
			{
				EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity);
				CharacterAttachComponent component = entity.GetComponent<CharacterAttachComponent>();
				if (component != null && component.Valid && !this.HasFollower(ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity)))
				{
					CharacterPartComponent component2 = entity.GetComponent<CharacterPartComponent>();
					if (component2 == null || !component2.Valid)
					{
						return;
					}
					CharacterPart partByIndex = component2.GetPartByIndex(combinePartInfo.PartId);
					if (partByIndex == null || FNameUtil.IsNothing(partByIndex.CombinePartSocketName))
					{
						return;
					}
					Aki.Protocol.Vector offsetPos = combinePartInfo.OffsetPos;
					float inX = (offsetPos != null) ? offsetPos.X : 0f;
					Aki.Protocol.Vector offsetPos2 = combinePartInfo.OffsetPos;
					float inY = (offsetPos2 != null) ? offsetPos2.Y : 0f;
					Aki.Protocol.Vector offsetPos3 = combinePartInfo.OffsetPos;
					FVector socketOffset = new FVector(inX, inY, (offsetPos3 != null) ? offsetPos3.Z : 0f);
					component.StartAttachToTarget(handleByEntity, partByIndex.CombinePartSocketName.Value, socketOffset, combinePartInfo.PartId, null);
					component.AttachToTarget(handleByEntity, null, false);
				}
			}
			i++;
		}
	}

	// Token: 0x06019359 RID: 103257 RVA: 0x00734FFC File Offset: 0x007331FC
	[NullableContext(1)]
	public void StartAttachToTarget(EntityHandle targetHandle, FName socketName, FVector socketOffset, int partInfoIndex, FGameplayTag? tag)
	{
		bool isShowDebugLog = CharacterAttachComponent.IsShowDebugLog;
		if (!this.CheckValid())
		{
			return;
		}
		this.DetachFromHost(false, false, true, null);
		WorldEntity entity = targetHandle.Entity;
		CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return;
		}
		this.AttachTargetHandle = targetHandle;
		this.AttachTag = tag;
		this.AttachPartInfoIndex = partInfoIndex;
		this.AttachSocketName = socketName;
		global::Vector attachSocketOffset = this.AttachSocketOffset;
		FVectorDouble fvectorDouble = socketOffset;
		attachSocketOffset.DeepCopy(fvectorDouble);
		this.AttachState = EAttachState.Attaching;
		CharacterMoveComponent moveComp = this.MoveComp;
		this.MoveCompDisableHandle = ((moveComp != null) ? new int?(moveComp.Disable("CharacterAttachComponent Disable")) : null);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.Valid)
		{
			this.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_None,
				Context = "[CharacterAttachComponent.StartAttachToTarget]"
			});
			this.ActorComp.Actor.CapsuleComponent.IgnoreActorWhenMoving(characterActorComponent.Actor, true);
			characterActorComponent.Actor.CapsuleComponent.IgnoreActorWhenMoving(this.ActorComp.Actor, true);
		}
		bool isShowDebugLog2 = CharacterAttachComponent.IsShowDebugLog;
	}

	// Token: 0x0601935A RID: 103258 RVA: 0x0073512C File Offset: 0x0073332C
	[NullableContext(1)]
	public void AttachToTarget(EntityHandle targetHandle, long? preMessageId, bool isSendToServer)
	{
		bool isShowDebugLog = CharacterAttachComponent.IsShowDebugLog;
		if (!this.CheckValid())
		{
			return;
		}
		WorldEntity entity = targetHandle.Entity;
		CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		if (characterActorComponent == null || !characterActorComponent.Valid || characterActorComponent.SkeletalMesh == null)
		{
			return;
		}
		if (this.AttachState != EAttachState.Attaching || this.AttachTargetHandle != targetHandle)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.LJM, "Attach到目标失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.Valid)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null && tagComp.Valid)
			{
				this.ActorComp.Owner.K2_AttachToComponent(characterActorComponent.SkeletalMesh, this.AttachSocketName, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, false, true);
				if (this.AttachTag != null)
				{
					this.TagComp.AddTag(new int?(this.AttachTag.Value.TagId()));
				}
				this.AttachState = EAttachState.Attach;
				this.AttachToHost();
				if (isSendToServer)
				{
					this.ExecuteCombineEntitiesRequest(preMessageId.Value);
				}
				bool isShowDebugLog2 = CharacterAttachComponent.IsShowDebugLog;
				return;
			}
		}
	}

	// Token: 0x0601935B RID: 103259 RVA: 0x00735244 File Offset: 0x00733444
	public void DetachFromHost(bool isDetachFollower, bool isRecursion, bool isNotifyServer, long? preMessageId = null)
	{
		if (!this.CheckValid())
		{
			return;
		}
		if (this.AttachState == EAttachState.Attach)
		{
			bool isShowDebugLog = CharacterAttachComponent.IsShowDebugLog;
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.Owner.K2_DetachFromActor(EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
			}
			EntityHandle attachTargetHandle = this.AttachTargetHandle;
			CharacterActorComponent characterActorComponent;
			if (attachTargetHandle == null)
			{
				characterActorComponent = null;
			}
			else
			{
				WorldEntity entity = attachTargetHandle.Entity;
				characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
			}
			CharacterActorComponent characterActorComponent2 = characterActorComponent;
			if (characterActorComponent2 != null && characterActorComponent2.Valid)
			{
				CharacterActorComponent actorComp2 = this.ActorComp;
				if (actorComp2 != null)
				{
					AActor owner = actorComp2.Owner;
					if (owner != null)
					{
						owner.K2_SetActorRotation(characterActorComponent2.ActorRotation, true);
					}
				}
			}
			else
			{
				CharacterActorComponent actorComp3 = this.ActorComp;
				if (actorComp3 != null)
				{
					AActor owner2 = actorComp3.Owner;
					if (owner2 != null)
					{
						FRotator newRotation = new FRotator();
						CharacterActorComponent actorComp4 = this.ActorComp;
						newRotation.Yaw = ((actorComp4 != null) ? actorComp4.ActorRotationProxy.Yaw : 0f);
						owner2.K2_SetActorRotation(newRotation, true);
					}
				}
			}
			if (isNotifyServer)
			{
				this.ExecuteDissolveCombineRelationRequest(preMessageId);
			}
			bool isShowDebugLog2 = CharacterAttachComponent.IsShowDebugLog;
		}
		if (isDetachFollower)
		{
			this.DetachFollower(isRecursion, isNotifyServer, null);
		}
		this.ClearAttachState();
		this.RemoveFromHost();
	}

	// Token: 0x0601935C RID: 103260 RVA: 0x00735350 File Offset: 0x00733550
	private void DetachFollower(bool isRecursion, bool isNotifyServer, long? preMessageId = null)
	{
		for (int i = this.FollowerList.Count - 1; i >= 0; i--)
		{
			EntityHandle entityHandle = this.FollowerList[i];
			WorldEntity entity = entityHandle.Entity;
			if (entity != null && entity.Valid)
			{
				CharacterAttachComponent component = entityHandle.Entity.GetComponent<CharacterAttachComponent>();
				if (component != null && component.Valid)
				{
					component.DetachFromHost(isRecursion, isRecursion, isNotifyServer, preMessageId);
				}
			}
		}
		this.FollowerList.Clear();
	}

	// Token: 0x0601935D RID: 103261 RVA: 0x007353CC File Offset: 0x007335CC
	private void AttachToHost()
	{
		EntityHandle attachTargetHandle = this.AttachTargetHandle;
		if (attachTargetHandle == null || !attachTargetHandle.Valid)
		{
			return;
		}
		CharacterAttachComponent component = this.AttachTargetHandle.Entity.GetComponent<CharacterAttachComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		component.AddFollower(ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity));
	}

	// Token: 0x0601935E RID: 103262 RVA: 0x0073542C File Offset: 0x0073362C
	private void RemoveFromHost()
	{
		EntityHandle attachTargetHandle = this.AttachTargetHandle;
		if (attachTargetHandle == null || !attachTargetHandle.Valid)
		{
			return;
		}
		CharacterAttachComponent component = this.AttachTargetHandle.Entity.GetComponent<CharacterAttachComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		component.RemoveFollower(ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity));
	}

	// Token: 0x0601935F RID: 103263 RVA: 0x0073548A File Offset: 0x0073368A
	private void AddFollower(EntityHandle follower)
	{
		if (follower == null || !follower.Valid || this.FollowerList.Contains(follower))
		{
			return;
		}
		this.FollowerList.Add(follower);
	}

	// Token: 0x06019360 RID: 103264 RVA: 0x007354B8 File Offset: 0x007336B8
	private void RemoveFollower(EntityHandle follower)
	{
		if (follower == null || !follower.Valid)
		{
			return;
		}
		int num = this.FollowerList.IndexOf(follower);
		if (num < 0)
		{
			return;
		}
		this.FollowerList.RemoveAt(num);
	}

	// Token: 0x06019361 RID: 103265 RVA: 0x007354F5 File Offset: 0x007336F5
	public bool HasFollower(EntityHandle follower)
	{
		return this.CheckValid() && (follower != null && follower.Valid) && this.FollowerList.Contains(follower);
	}

	// Token: 0x06019362 RID: 103266 RVA: 0x00735520 File Offset: 0x00733720
	public CombinePartInfo GetFollowerAttachInfo(long followerServerId)
	{
		if (!this.CheckValid())
		{
			return null;
		}
		CreatureDataComponent creatureDataComp = this.CreatureDataComp;
		if (creatureDataComp == null || !creatureDataComp.Valid || this.CreatureDataComp.PbCombinePartInfoList == null)
		{
			return null;
		}
		List<CombinePartInfo> pbCombinePartInfoList = this.CreatureDataComp.PbCombinePartInfoList;
		if (pbCombinePartInfoList == null || pbCombinePartInfoList.Count <= 0)
		{
			return null;
		}
		int i = 0;
		int count = pbCombinePartInfoList.Count;
		while (i < count)
		{
			CombinePartInfo combinePartInfo = pbCombinePartInfoList[i];
			if (combinePartInfo.CombinerEntityId != followerServerId)
			{
				return combinePartInfo;
			}
			i++;
		}
		return null;
	}

	// Token: 0x06019363 RID: 103267 RVA: 0x0073559E File Offset: 0x0073379E
	private bool CheckValid()
	{
		return this.Initial;
	}

	// Token: 0x06019364 RID: 103268 RVA: 0x007355A8 File Offset: 0x007337A8
	private unsafe void ExecuteCombineEntitiesRequest(long preMessageId)
	{
		bool isShowDebugLog = CharacterAttachComponent.IsShowDebugLog;
		CombineEntitiesRequest combineEntitiesRequest = new CombineEntitiesRequest();
		combineEntitiesRequest.CombinePartInfo = new CombinePartInfo
		{
			CombinerEntityId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(base.Entity.Id),
			OffsetPos = new Aki.Protocol.Vector
			{
				X = (float)this.AttachSocketOffset.X,
				Y = (float)this.AttachSocketOffset.Y,
				Z = (float)this.AttachSocketOffset.Z
			},
			OffsetRotate = new Aki.Protocol.Rotator
			{
				Pitch = 0f,
				Yaw = 0f,
				Roll = 0f
			},
			PartId = this.AttachPartInfoIndex
		};
		combineEntitiesRequest.TargetEntity = ModelBase<CreatureModel>.Instance.GetCreatureDataId(this.AttachTargetHandle.Id);
		Singleton<CombatNet>.Instance.Call<CombineEntitiesResponse>(ERequestMessageId.CombineEntitiesRequest, base.Entity, combineEntitiesRequest, delegate(CombineEntitiesResponse response)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				if (CharacterAttachComponent.IsShowDebugLog)
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Request;
					Entity entity = base.Entity;
					string message = "执行合体失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ErrorCode", response.ErrorCode);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
					ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
					string item = "TargetEntityId";
					EntityHandle attachTargetHandle = this.AttachTargetHandle;
					ptr = new ValueTuple<string, object>(item, (attachTargetHandle != null) ? new int?(attachTargetHandle.Id) : null);
					instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				this.DetachFromHost(false, false, false, null);
				return;
			}
			bool isShowDebugLog2 = CharacterAttachComponent.IsShowDebugLog;
		}, new long?(preMessageId), null, null, null);
	}

	// Token: 0x06019365 RID: 103269 RVA: 0x007356C4 File Offset: 0x007338C4
	[CombatListen(ENotifyMessageId.AddCombineEntitiesRelationNotify, true, false)]
	public static void AddCombineEntitiesRelationNotify(Entity entity, [Nullable(1)] AddCombineEntitiesRelationNotify data, CombatCommon combatCommon = null)
	{
		bool isShowDebugLog = CharacterAttachComponent.IsShowDebugLog;
		if (entity == null)
		{
			return;
		}
		CharacterAttachComponent component = entity.GetComponent<CharacterAttachComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		CombinePartInfo combinePartInfo = data.CombinePartInfo;
		if (combinePartInfo == null)
		{
			return;
		}
		int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(data.TargetEntity);
		Entity entity2 = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity2 == null || !entity2.Valid)
		{
			Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.LJM, "同步合体失败，因为合体目标非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(entity2);
		CharacterPartComponent component2 = handleByEntity.Entity.GetComponent<CharacterPartComponent>();
		if (component2 == null || !component2.Valid)
		{
			return;
		}
		CharacterPart partByIndex = component2.GetPartByIndex(combinePartInfo.PartId);
		if (partByIndex == null || FNameUtil.IsNothing(partByIndex.CombinePartSocketName))
		{
			return;
		}
		Aki.Protocol.Vector offsetPos = combinePartInfo.OffsetPos;
		float inX = (offsetPos != null) ? offsetPos.X : 0f;
		Aki.Protocol.Vector offsetPos2 = combinePartInfo.OffsetPos;
		float inY = (offsetPos2 != null) ? offsetPos2.Y : 0f;
		Aki.Protocol.Vector offsetPos3 = combinePartInfo.OffsetPos;
		FVector socketOffset = new FVector(inX, inY, (offsetPos3 != null) ? offsetPos3.Z : 0f);
		component.StartAttachToTarget(handleByEntity, partByIndex.CombinePartSocketName.GetValueOrDefault(), socketOffset, combinePartInfo.PartId, null);
		component.AttachToTarget(handleByEntity, null, false);
		bool isShowDebugLog2 = CharacterAttachComponent.IsShowDebugLog;
	}

	// Token: 0x06019366 RID: 103270 RVA: 0x00735824 File Offset: 0x00733A24
	private unsafe void ExecuteDissolveCombineRelationRequest(long? preMessageId)
	{
		bool isShowDebugLog = CharacterAttachComponent.IsShowDebugLog;
		DissolveCombineRelationRequest dissolveCombineRelationRequest = new DissolveCombineRelationRequest();
		dissolveCombineRelationRequest.EntityA = ModelBase<CreatureModel>.Instance.GetCreatureDataId(base.Entity.Id);
		dissolveCombineRelationRequest.EntityB = ModelBase<CreatureModel>.Instance.GetCreatureDataId(this.AttachTargetHandle.Id);
		Singleton<CombatNet>.Instance.Call<DissolveCombineRelationResponse>(ERequestMessageId.DissolveCombineRelationRequest, base.Entity, dissolveCombineRelationRequest, delegate(DissolveCombineRelationResponse response)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				bool isShowDebugLog2 = CharacterAttachComponent.IsShowDebugLog;
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Request;
				Entity entity = base.Entity;
				string message = "执行解体失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ErrorCode", response.ErrorCode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item = "TargetEntityId";
				EntityHandle attachTargetHandle = this.AttachTargetHandle;
				ptr = new ValueTuple<string, object>(item, (attachTargetHandle != null) ? new int?(attachTargetHandle.Id) : null);
				instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			if (CharacterAttachComponent.IsShowDebugLog)
			{
				bool isShowDebugLog3 = CharacterAttachComponent.IsShowDebugLog;
			}
		}, preMessageId, null, null, null);
	}

	// Token: 0x06019367 RID: 103271 RVA: 0x007358B4 File Offset: 0x00733AB4
	[CombatListen(ENotifyMessageId.RemoveCombineRelationNotify, true, false)]
	public static void RemoveCombineRelationNotify(Entity entity, [Nullable(1)] RemoveCombineRelationNotify data, CombatCommon combatCommon = null)
	{
		bool isShowDebugLog = CharacterAttachComponent.IsShowDebugLog;
		if (entity == null)
		{
			return;
		}
		CharacterAttachComponent component = entity.GetComponent<CharacterAttachComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		component.DetachFromHost(false, false, false, null);
		bool isShowDebugLog2 = CharacterAttachComponent.IsShowDebugLog;
	}

	// Token: 0x06019368 RID: 103272 RVA: 0x007358FC File Offset: 0x00733AFC
	public void SetEnableDebugLog(bool isShowDebugLog)
	{
		CharacterAttachComponent.IsShowDebugLog = isShowDebugLog;
	}

	// Token: 0x06019369 RID: 103273 RVA: 0x00735904 File Offset: 0x00733B04
	private void ClearAttachState()
	{
		if (this.AttachTag != null)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.RemoveTag(new int?(this.AttachTag.Value.TagId()));
			}
			this.AttachTag = null;
		}
		if (this.MoveCompDisableHandle != null)
		{
			CharacterMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.Enable(new int?(this.MoveCompDisableHandle.Value), "CharacterAttachComponent Enable");
			}
			this.MoveCompDisableHandle = null;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.Valid)
		{
			this.ActorComp.Actor.CharacterMovement.SetDefaultMovementMode();
			EntityHandle attachTargetHandle = this.AttachTargetHandle;
			CharacterActorComponent characterActorComponent;
			if (attachTargetHandle == null)
			{
				characterActorComponent = null;
			}
			else
			{
				WorldEntity entity = attachTargetHandle.Entity;
				characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
			}
			CharacterActorComponent characterActorComponent2 = characterActorComponent;
			if (characterActorComponent2 != null && characterActorComponent2.Valid)
			{
				this.ActorComp.Actor.CapsuleComponent.IgnoreActorWhenMoving(characterActorComponent2.Actor, false);
				characterActorComponent2.Actor.CapsuleComponent.IgnoreActorWhenMoving(this.ActorComp.Actor, false);
			}
		}
		this.AttachTargetHandle = null;
		this.AttachSocketName = null;
		this.AttachState = EAttachState.Detach;
	}

	// Token: 0x0601936A RID: 103274 RVA: 0x00735A38 File Offset: 0x00733C38
	private void OnEntityDead()
	{
		this.DetachFromHost(true, false, false, null);
	}

	// Token: 0x0601936B RID: 103275 RVA: 0x00735A58 File Offset: 0x00733C58
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnEntityDead));
		this.DetachFromHost(true, false, false, null);
		this.ActorComp = null;
		this.MoveComp = null;
		this.TagComp = null;
		this.Initial = false;
		return true;
	}

	// Token: 0x0601936C RID: 103276 RVA: 0x00735AB6 File Offset: 0x00733CB6
	static CharacterAttachComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterAttachComponent.CreateStaticDefaultValue), new Action(CharacterAttachComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601936D RID: 103277 RVA: 0x00735AD5 File Offset: 0x00733CD5
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0601936E RID: 103278 RVA: 0x00735AD7 File Offset: 0x00733CD7
	public static void ResetStaticDefaultValue()
	{
		CharacterAttachComponent.IsShowDebugLog = false;
	}

	// Token: 0x0601936F RID: 103279 RVA: 0x00735AE0 File Offset: 0x00733CE0
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterAttachComponent characterAttachComponent = (CharacterAttachComponent)componentTemplate;
		if (base.CanResetComponentProperty("AttachTargetHandle"))
		{
			if (characterAttachComponent.AttachTargetHandle == null)
			{
				this.AttachTargetHandle = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.AttachTargetHandle), "AttachTargetHandle"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttachTag"))
		{
			this.AttachTag = characterAttachComponent.AttachTag;
		}
		if (base.CanResetComponentProperty("AttachPartInfoIndex"))
		{
			this.AttachPartInfoIndex = characterAttachComponent.AttachPartInfoIndex;
		}
		if (base.CanResetComponentProperty("AttachSocketName"))
		{
			this.AttachSocketName = characterAttachComponent.AttachSocketName;
		}
		if (base.CanResetComponentProperty("AttachSocketOffset") && characterAttachComponent.AttachSocketOffset != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.AttachSocketOffset), "AttachSocketOffset"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AttachState"))
		{
			this.AttachState = characterAttachComponent.AttachState;
		}
		if (base.CanResetComponentProperty("CreatureDataComp"))
		{
			if (characterAttachComponent.CreatureDataComp == null)
			{
				this.CreatureDataComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterAttachComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterAttachComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterAttachComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveCompDisableHandle"))
		{
			this.MoveCompDisableHandle = characterAttachComponent.MoveCompDisableHandle;
		}
		if (base.CanResetComponentProperty("FollowerList"))
		{
			if (characterAttachComponent.FollowerList == null)
			{
				this.FollowerList = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<EntityHandle>>(this.FollowerList), "FollowerList"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("Initial"))
		{
			this.Initial = characterAttachComponent.Initial;
		}
		return true;
	}

	// Token: 0x0400C641 RID: 50753
	private static bool IsShowDebugLog;

	// Token: 0x0400C642 RID: 50754
	private EntityHandle AttachTargetHandle;

	// Token: 0x0400C643 RID: 50755
	private FGameplayTag? AttachTag;

	// Token: 0x0400C644 RID: 50756
	private int AttachPartInfoIndex;

	// Token: 0x0400C645 RID: 50757
	private FName AttachSocketName = FName.NAME_None;

	// Token: 0x0400C646 RID: 50758
	[Nullable(1)]
	private readonly global::Vector AttachSocketOffset = global::Vector.Create();

	// Token: 0x0400C647 RID: 50759
	private EAttachState AttachState = EAttachState.Detach;

	// Token: 0x0400C648 RID: 50760
	private CreatureDataComponent CreatureDataComp;

	// Token: 0x0400C649 RID: 50761
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C64A RID: 50762
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400C64B RID: 50763
	private BaseTagComponent TagComp;

	// Token: 0x0400C64C RID: 50764
	private int? MoveCompDisableHandle;

	// Token: 0x0400C64D RID: 50765
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<EntityHandle> FollowerList;

	// Token: 0x0400C64E RID: 50766
	private bool Initial;
}
