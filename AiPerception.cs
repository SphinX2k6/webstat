using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02000D0C RID: 3340
[NullableContext(1)]
[Nullable(0)]
public class AiPerception : IAiPerception
{
	// Token: 0x060042E8 RID: 17128 RVA: 0x00079EC8 File Offset: 0x000780C8
	public AiPerception(AiController aiController, AiSenseGroup aiSenseGroup, AiSense[] aiSenses)
	{
		this.AiController = aiController;
		this.AiSenseGroup = new AiSenseGroup?(aiSenseGroup);
		this.EntityId = this.AiController.CharActorComp.Entity.Id;
		this.Camp = this.AiController.CharActorComp.Actor.Camp;
		this.EntitiesInSense[this.EntityId] = ESenseTargetType.Character;
		this.ActivateAiSenseObjects[ESenseTargetType.Character] = new HashSet<AiSenseObject>();
		this.ActivateAiSenseObjects[ESenseTargetType.SceneItem] = new HashSet<AiSenseObject>();
		this.TmpVector = global::Vector.Create();
		int num = -1;
		foreach (AiSense aiSense in aiSenses)
		{
			AiSenseObject aiSenseObject = new AiSenseObject(aiSense);
			this.AiSenseObjects.Add(aiSenseObject);
			num++;
			if (num <= 0)
			{
				if (aiSenseObject.WithAngleHorizontal)
				{
					this.WithAngleHorizontalCount++;
				}
				if (aiSenseObject.WithAngleVertical)
				{
					this.WithAngleVerticalCount++;
				}
				if (aiSense.SenseDistanceRange.Value.Max > this.MaxSenseRange)
				{
					this.MaxSenseRange = aiSense.SenseDistanceRange.Value.Max;
				}
				this.ActivateAiSenseObjects[(ESenseTargetType)aiSenseObject.AiSense.SenseTarget].Add(aiSenseObject);
			}
		}
		this.SquaredShareDist = aiSenseGroup.ShareDis * aiSenseGroup.ShareDis;
		this.InitTraceInfo();
	}

	// Token: 0x060042E9 RID: 17129 RVA: 0x0007A185 File Offset: 0x00078385
	private void InitTraceInfo()
	{
		this.LineTrace = new UTraceLineElement();
		this.LineTrace.WorldContextObject = this.AiController.CharActorComp.Actor;
		this.LineTrace.bIsSingle = true;
		this.LineTrace.bIgnoreSelf = true;
	}

	// Token: 0x060042EA RID: 17130 RVA: 0x0007A1C8 File Offset: 0x000783C8
	public override string GetEnableAiSenseDebug()
	{
		string text = "感知配置激活情况: ";
		for (int i = 0; i < this.AiSenseObjects.Count; i++)
		{
			AiSenseObject aiSenseObject = this.AiSenseObjects[i];
			int id = this.AiSenseObjects[i].AiSense.Id;
			bool flag = this.ActivateAiSenseObjects[(ESenseTargetType)aiSenseObject.AiSense.SenseTarget].Contains(aiSenseObject);
			string str = id.ToString() + ":" + flag.ToString() + "; ";
			text += str;
		}
		return text;
	}

	// Token: 0x060042EB RID: 17131 RVA: 0x0007A268 File Offset: 0x00078468
	private unsafe void EnableAiSenseInternal(AiSenseObject aiSenseObject, bool enable)
	{
		HashSet<AiSenseObject> hashSet = this.ActivateAiSenseObjects[(ESenseTargetType)aiSenseObject.AiSense.SenseTarget];
		if (hashSet.Contains(aiSenseObject) == enable)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.AI;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "EnableAiSense";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.AiController.CharActorComp.Actor.GetName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AiSenseObject", aiSenseObject.AiSense.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("enable", enable);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		if (enable)
		{
			if (aiSenseObject.WithAngleHorizontal)
			{
				this.WithAngleHorizontalCount++;
			}
			if (aiSenseObject.WithAngleVertical)
			{
				this.WithAngleVerticalCount++;
			}
			hashSet.Add(aiSenseObject);
			return;
		}
		if (aiSenseObject.WithAngleHorizontal)
		{
			this.WithAngleHorizontalCount--;
		}
		if (aiSenseObject.WithAngleVertical)
		{
			this.WithAngleVerticalCount--;
		}
		hashSet.Remove(aiSenseObject);
	}

	// Token: 0x060042EC RID: 17132 RVA: 0x0007A39B File Offset: 0x0007859B
	public override void SetAiSenseEnable(int index, bool enable)
	{
		if (index < 0 || this.AiSenseObjects.Count <= index)
		{
			return;
		}
		this.EnableAiSenseInternal(this.AiSenseObjects[index], enable);
	}

	// Token: 0x060042ED RID: 17133 RVA: 0x0007A3C4 File Offset: 0x000785C4
	public override void SetAiSenseEnableWithoutForbidAllSense(bool enable)
	{
		if (this.AiSenseObjects.Count <= 0)
		{
			return;
		}
		foreach (AiSenseObject aiSenseObject in this.AiSenseObjects)
		{
			this.EnableAiSenseInternal(aiSenseObject, enable);
		}
	}

	// Token: 0x060042EE RID: 17134 RVA: 0x0007A428 File Offset: 0x00078628
	public override void SetAllAiSenseEnable(bool enable)
	{
		if (!enable)
		{
			foreach (KeyValuePair<int, ESenseTargetType> keyValuePair in this.EntitiesInSense)
			{
				if (keyValuePair.Key != this.EntityId)
				{
					Entity entity = Singleton<EntitySystem>.Instance.Get(keyValuePair.Key);
					if (entity != null)
					{
						this.SenseActor(entity, false);
					}
				}
			}
			this.Allies.Clear();
			this.Enemies.Clear();
			this.Neutrals.Clear();
			this.AllEnemies.Clear();
			this.EntitiesInSense.Clear();
			this.EntitiesInSense[this.EntityId] = ESenseTargetType.Character;
		}
		this.ForbidAllSense = !enable;
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Ai;
		CharacterActorComponent charActorComp = this.AiController.CharActorComp;
		Entity entity2 = (charActorComp != null) ? charActorComp.Entity : null;
		string message = "禁用全部感知";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("forbid", this.ForbidAllSense);
		instance.Info(flag, entity2, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x060042EF RID: 17135 RVA: 0x0007A540 File Offset: 0x00078740
	public override void AddOrRemoveAiSense(int aiSenseId, bool add)
	{
		if (add && !this.ExtraAiSenseObjects.ContainsKey(aiSenseId))
		{
			AiSense? aiSense = ConfigBase<AiConfig>.Instance.LoadAiSense(aiSenseId.ToString());
			if (aiSense != null)
			{
				this.ExtraAiSenseObjects[aiSenseId] = new AiSenseObject(aiSense.Value);
			}
		}
		AiSenseObject aiSenseObject;
		if (!this.ExtraAiSenseObjects.TryGetValue(aiSenseId, out aiSenseObject))
		{
			return;
		}
		this.EnableAiSenseInternal(aiSenseObject, add);
	}

	// Token: 0x060042F0 RID: 17136 RVA: 0x0007A5AC File Offset: 0x000787AC
	public override void EnableAiSenseByType(int type, bool enable)
	{
		foreach (AiSenseObject aiSenseObject in this.AiSenseObjects)
		{
			if (aiSenseObject.AiSense.SenseType == type)
			{
				this.EnableAiSenseInternal(aiSenseObject, enable);
			}
		}
		foreach (KeyValuePair<int, AiSenseObject> keyValuePair in this.ExtraAiSenseObjects)
		{
			if (keyValuePair.Value.AiSense.SenseType == type)
			{
				this.EnableAiSenseInternal(keyValuePair.Value, enable);
			}
		}
	}

	// Token: 0x060042F1 RID: 17137 RVA: 0x0007A674 File Offset: 0x00078874
	public override void Clear(bool allClear = true, bool collectEvent = false)
	{
		if (collectEvent)
		{
			foreach (int id in this.Allies)
			{
				this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(false, id, ERelation.Friend);
			}
			foreach (int id2 in this.Enemies)
			{
				this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(false, id2, ERelation.Enemy);
			}
			foreach (int id3 in this.Neutrals)
			{
				this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(false, id3, ERelation.None);
			}
		}
		this.Allies.Clear();
		this.Enemies.Clear();
		this.Neutrals.Clear();
		this.SceneItems.Clear();
		this.AllEnemies.Clear();
		this.Pending.Clear();
		this.EntitiesInSense.Clear();
		this.EntitiesInSense[this.EntityId] = ESenseTargetType.Character;
		this.EntitiesToAdd.Clear();
		this.EntitiesToRemove.Clear();
		this.EntitiesRemoveTime.Clear();
		if (allClear)
		{
			this.TmpHandles.Clear();
		}
	}

	// Token: 0x060042F2 RID: 17138 RVA: 0x0007A804 File Offset: 0x00078A04
	public override void Tick()
	{
		CharacterActorComponent charActorComp = this.AiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			return;
		}
		if (this.AiSenseGroup == null)
		{
			this.RefreshAllEnemies();
			return;
		}
		if (this.ForbidAllSense)
		{
			return;
		}
		this.FindNewInSenseActor();
		this.FindOutSenseActor();
		foreach (KeyValuePair<int, ESenseTargetType> keyValuePair in this.EntitiesToAdd)
		{
			this.EntitiesInSense[keyValuePair.Key] = keyValuePair.Value;
			Entity entity = Singleton<EntitySystem>.Instance.Get(keyValuePair.Key);
			this.SenseActor(entity, true);
		}
		this.EntitiesToAdd.Clear();
		this.FindShareAlly();
		this.RefreshAllEnemies();
	}

	// Token: 0x060042F3 RID: 17139 RVA: 0x0007A8E0 File Offset: 0x00078AE0
	private unsafe bool IsActorInSense(Entity entity, bool inSenseBefore, ESenseTargetType senseTargetType, bool debugLog = false)
	{
		global::Vector actorLocationProxy = this.AiController.CharActorComp.ActorLocationProxy;
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		bool flag = debugLog && component.CreatureData.IsRole();
		component.ActorLocationProxy.Subtraction(actorLocationProxy, this.TmpVector);
		double num = this.TmpVector.SizeSquared();
		float angleHorizontal = 0f;
		float angleVertical = 0f;
		if (this.WithAngleHorizontalCount > 0 || this.WithAngleVerticalCount > 0)
		{
			global::Vector tmpVector = this.TmpVector;
			FRotator actorRotation = this.AiController.CharActorComp.ActorRotation;
			FVectorDouble fvectorDouble = this.TmpVector.ToUeVector(false);
			FVector fvector = fvectorDouble;
			FVector fvector2 = actorRotation.UnrotateVector(fvector);
			tmpVector.FromUeVector(fvector2);
			if (this.WithAngleHorizontalCount > 0)
			{
				angleHorizontal = (float)(57.295780181884766 * Math.Atan2(this.TmpVector.Y, this.TmpVector.X));
			}
			if (this.WithAngleVerticalCount > 0)
			{
				angleVertical = (float)(57.295780181884766 * Math.Asin(this.TmpVector.Z / Math.Sqrt(num)));
			}
		}
		BaseUnifiedStateComponent component2 = entity.GetComponent<BaseUnifiedStateComponent>();
		ECharPositionState positionState = (component2 != null && component2.Valid) ? component2.PositionState : ECharPositionState.Ground;
		ECharMoveState moveState = (component2 != null && component2.Valid) ? component2.MoveState : ECharMoveState.Other;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineTrace, actorLocationProxy);
		this.TmpCheckedTraceType.Clear();
		foreach (AiSenseObject aiSenseObject in this.ActivateAiSenseObjects[senseTargetType])
		{
			if (aiSenseObject.InArea(num, angleHorizontal, angleVertical, positionState, moveState, inSenseBefore))
			{
				if (flag)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.AI;
					ELogAuthor author = ELogAuthor.LCZ;
					string message = "Mingzhongzhigui Ai InArea";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("actor", component.Owner);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("CantBeBlock", aiSenseObject.AiSense.CantBeBlock);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				if (!aiSenseObject.AiSense.CantBeBlock)
				{
					if (this.TmpCheckedTraceType.Contains(aiSenseObject.AiSense.BlockType))
					{
						continue;
					}
					this.LineTrace.SetTraceTypeQuery((ETraceTypeQuery)aiSenseObject.AiSense.BlockType);
					Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineTrace, component.ActorLocationProxy);
					if (Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "AiPerception_IsActorInSense"))
					{
						UKuroHitResult hitResult = this.LineTrace.HitResult;
						if (hitResult.bBlockingHit && hitResult.Actors.Get(0).Get() != component.Owner)
						{
							if (flag)
							{
								Log instance2 = Singleton<Log>.Instance;
								ELogModule module2 = ELogModule.AI;
								ELogAuthor author2 = ELogAuthor.LCZ;
								string message2 = "Mingzhongzhigui Ai Hit";
								<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("actor", hitResult.Actors.Get(0).Get());
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Comp", hitResult.Components.Get(0).Get());
								instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
							}
							this.TmpCheckedTraceType.Add(aiSenseObject.AiSense.BlockType);
							continue;
						}
					}
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060042F4 RID: 17140 RVA: 0x0007AC8C File Offset: 0x00078E8C
	private void FindNewInSenseActor()
	{
		global::Vector actorLocationProxy = this.AiController.CharActorComp.ActorLocationProxy;
		this.EntitiesToAdd.Clear();
		foreach (KeyValuePair<ESenseTargetType, HashSet<AiSenseObject>> keyValuePair in this.ActivateAiSenseObjects)
		{
			ESenseTargetType key = keyValuePair.Key;
			HashSet<AiSenseObject> value = keyValuePair.Value;
			if (value.Count != 0)
			{
				float num = 0f;
				foreach (AiSenseObject aiSenseObject in value)
				{
					num = MathF.Max(num, aiSenseObject.AiSense.SenseDistanceRange.Value.Min);
				}
				ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(actorLocationProxy, num, (key == ESenseTargetType.Character) ? EEntityTypeQuery.Character : EEntityTypeQuery.SceneItem, this.TmpHandles, true);
				foreach (EntityHandle entityHandle in this.TmpHandles)
				{
					WorldEntity entity = entityHandle.Entity;
					if (entity != null && entity.Valid && entityHandle.Entity.Active && !this.EntitiesInSense.ContainsKey(entityHandle.Entity.Id) && this.IsActorInSense(entityHandle.Entity, false, key, false))
					{
						this.EntitiesToAdd[entityHandle.Entity.Id] = key;
					}
				}
			}
		}
	}

	// Token: 0x060042F5 RID: 17141 RVA: 0x0007AE6C File Offset: 0x0007906C
	private void FindOutSenseActor()
	{
		this.EntitiesToRemove.Clear();
		foreach (KeyValuePair<int, ESenseTargetType> keyValuePair in new List<KeyValuePair<int, ESenseTargetType>>(this.EntitiesInSense))
		{
			int key = keyValuePair.Key;
			ESenseTargetType value = keyValuePair.Value;
			if (key != this.EntityId)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(key);
				if (entity == null || !entity.Valid || !entity.Active)
				{
					this.EntitiesInSense.Remove(key);
					this.EntitiesRemoveTime.Remove(key);
					if (this.Allies.Remove(key))
					{
						this.AiController.AiPerceptionEvents.CollectAiRemovePerceptionEventByEntityId(false, key, ERelation.Friend);
					}
					if (this.Enemies.Remove(key))
					{
						this.AiController.AiPerceptionEvents.CollectAiRemovePerceptionEventByEntityId(false, key, ERelation.Enemy);
					}
					if (this.Neutrals.Remove(key))
					{
						this.AiController.AiPerceptionEvents.CollectAiRemovePerceptionEventByEntityId(false, key, ERelation.None);
					}
					this.SceneItems.Remove(key);
				}
				else if (this.IsActorInSense(entity, true, value, false))
				{
					this.EntitiesRemoveTime.Remove(key);
				}
				else
				{
					this.EntitiesToRemove.Add(key);
				}
			}
		}
		double now = Singleton<Time>.Instance.Now;
		foreach (KeyValuePair<int, float> keyValuePair2 in new List<KeyValuePair<int, float>>(this.EntitiesRemoveTime))
		{
			if (now > (double)keyValuePair2.Value)
			{
				this.EntitiesInSense.Remove(keyValuePair2.Key);
				Entity entity2 = Singleton<EntitySystem>.Instance.Get<Entity>(keyValuePair2.Key);
				if (entity2 == null || !entity2.Valid)
				{
					this.EntitiesRemoveTime.Remove(keyValuePair2.Key);
				}
				else
				{
					this.SenseActor(entity2, false);
					this.EntitiesRemoveTime.Remove(keyValuePair2.Key);
				}
			}
		}
		foreach (int key2 in this.EntitiesToRemove)
		{
			if (!this.EntitiesRemoveTime.ContainsKey(key2))
			{
				this.EntitiesRemoveTime[key2] = (float)(now + Singleton<MathUtils>.Instance.GetRandomRange((double)this.AiSenseGroup.Value.LoseDelay.Value.Min, (double)this.AiSenseGroup.Value.LoseDelay.Value.Max));
			}
		}
	}

	// Token: 0x060042F6 RID: 17142 RVA: 0x0007B170 File Offset: 0x00079370
	private void SenseActor(Entity entity, bool inSense)
	{
		int id = entity.Id;
		CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
		if (component != null && component.Valid)
		{
			ERelation campRelationship = CampUtils.GetCampRelationship(this.Camp, component.Actor.Camp);
			HashSet<int> hashSet;
			if (campRelationship != ERelation.Friend)
			{
				if (campRelationship != ERelation.Enemy)
				{
					hashSet = this.Neutrals;
				}
				else
				{
					hashSet = this.Enemies;
				}
			}
			else
			{
				hashSet = this.Allies;
			}
			if (inSense)
			{
				if (hashSet.Add(id))
				{
					this.AiController.AiPerceptionEvents.CollectAiPerceptionEventByActorComp(true, component, campRelationship);
					Singleton<EventSystem>.Instance.Emit<int, Entity>(EEventName.OnAiSenseEntityEnter, this.EntityId, component.Entity);
					return;
				}
			}
			else if (hashSet.Remove(id))
			{
				this.AiController.AiPerceptionEvents.CollectAiPerceptionEventByActorComp(false, component, campRelationship);
				Singleton<EventSystem>.Instance.Emit<int, Entity>(EEventName.OnAiSenseEntityLeave, this.EntityId, component.Entity);
				return;
			}
		}
		else if (inSense)
		{
			if (this.SceneItems.Add(id))
			{
				this.AiController.AiPerceptionEvents.OnSenseSceneItem(component);
				return;
			}
		}
		else
		{
			this.SceneItems.Remove(id);
		}
	}

	// Token: 0x060042F7 RID: 17143 RVA: 0x0007B280 File Offset: 0x00079480
	private void FindShareAlly()
	{
		if (this.AiSenseGroup.Value.ShareDis <= 0f)
		{
			return;
		}
		global::Vector actorLocationProxy = this.AiController.CharActorComp.ActorLocationProxy;
		ModelBase<CreatureModel>.Instance.GetEntitiesInRangeWithLocation(actorLocationProxy, this.AiSenseGroup.Value.ShareDis, EEntityTypeQuery.Character, this.TmpHandles, true);
		this.NewShareAllyLink.Clear();
		this.NewShareAllyLink.Add(this.EntityId);
		ECamp camp = this.AiController.CharActorComp.Actor.Camp;
		foreach (EntityHandle entityHandle in this.TmpHandles)
		{
			WorldEntity entity = entityHandle.Entity;
			if (entity != null && entity.Active && !this.NewShareAllyLink.Contains(entityHandle.Entity.Id))
			{
				CharacterActorComponent component = entityHandle.Entity.GetComponent<CharacterActorComponent>();
				if (component != null && component.Valid && camp == component.Actor.Camp && global::Vector.DistSquared(actorLocationProxy, component.ActorLocationProxy) <= (double)this.SquaredShareDist)
				{
					this.NewShareAllyLink.Add(entityHandle.Entity.Id);
					if (!this.ShareAllyLink.Contains(entityHandle.Entity.Id))
					{
						CharacterAiComponent component2 = entityHandle.Entity.GetComponent<CharacterAiComponent>();
						if (component2 != null && component2.Valid)
						{
							AiPerception aiPerception = component2.AiController.AiPerception as AiPerception;
							if (aiPerception != null)
							{
								aiPerception.BeShared.Add(this.EntityId);
							}
						}
					}
				}
			}
		}
		foreach (int num in this.ShareAllyLink)
		{
			if (!this.NewShareAllyLink.Contains(num))
			{
				Entity entity2 = Singleton<EntitySystem>.Instance.Get<Entity>(num);
				if (entity2 != null && entity2.Valid)
				{
					CharacterAiComponent component3 = entity2.GetComponent<CharacterAiComponent>();
					if (component3 != null && component3.Valid)
					{
						AiPerception aiPerception2 = component3.AiController.AiPerception as AiPerception;
						if (aiPerception2 != null)
						{
							aiPerception2.BeShared.Remove(this.EntityId);
						}
					}
				}
			}
		}
		HashSet<int> newShareAllyLink = this.NewShareAllyLink;
		this.NewShareAllyLink = this.ShareAllyLink;
		this.ShareAllyLink = newShareAllyLink;
	}

	// Token: 0x060042F8 RID: 17144 RVA: 0x0007B534 File Offset: 0x00079734
	private void RefreshAllEnemies()
	{
		this.AllEnemies.Clear();
		foreach (int item in this.Enemies)
		{
			this.AllEnemies.Add(item);
		}
		this.AddedBeShared.Clear();
		this.Pending.Clear();
		this.AddedBeShared.Add(this.EntityId);
		using (HashSet<int>.Enumerator enumerator = this.BeShared.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				int item2 = enumerator.Current;
				this.Pending.Add(item2);
				this.AddedBeShared.Add(item2);
			}
			goto IL_1DE;
		}
		IL_BA:
		List<int> pending = this.Pending;
		int id = pending[pending.Count - 1];
		this.Pending.RemoveAt(this.Pending.Count - 1);
		Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(id);
		if (entity != null && entity.Valid)
		{
			CharacterAiComponent component = entity.GetComponent<CharacterAiComponent>();
			if (component != null && component.Valid && component.AiController.AiPerception != null)
			{
				foreach (int item3 in component.AiController.AiPerception.Enemies)
				{
					this.AllEnemies.Add(item3);
				}
				foreach (int item4 in (component.AiController.AiPerception as AiPerception).BeShared)
				{
					if (this.AddedBeShared.Add(item4))
					{
						this.Pending.Add(item4);
					}
				}
			}
		}
		IL_1DE:
		if (this.Pending.Count <= 0)
		{
			return;
		}
		goto IL_BA;
	}

	// Token: 0x060042F9 RID: 17145 RVA: 0x0007B764 File Offset: 0x00079964
	public override void OnEntityCampModified(Entity entity, ECamp oldCamp, ECamp newCamp)
	{
		int id = entity.Id;
		CharacterAiComponent charAiDesignComp = this.AiController.CharAiDesignComp;
		int? num = (charAiDesignComp != null) ? new int?(charAiDesignComp.Entity.Id) : null;
		if (id == num.GetValueOrDefault() & num != null)
		{
			this.Camp = this.AiController.CharActorComp.Actor.Camp;
			this.Clear(false, true);
			return;
		}
		ESenseTargetType esenseTargetType;
		if (!this.EntitiesInSense.TryGetValue(entity.Id, out esenseTargetType) || esenseTargetType != ESenseTargetType.Character)
		{
			return;
		}
		ERelation campRelationship = CampUtils.GetCampRelationship(this.Camp, oldCamp);
		ERelation campRelationship2 = CampUtils.GetCampRelationship(this.Camp, newCamp);
		if (campRelationship == campRelationship2)
		{
			return;
		}
		bool flag;
		if (campRelationship != ERelation.Friend)
		{
			if (campRelationship == ERelation.Enemy)
			{
				flag = this.Enemies.Remove(entity.Id);
				this.AllEnemies.Remove(entity.Id);
			}
			else
			{
				flag = this.Neutrals.Remove(entity.Id);
			}
		}
		else
		{
			flag = this.Allies.Remove(entity.Id);
		}
		if (flag)
		{
			this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(false, entity.Id, campRelationship);
			if (campRelationship2 != ERelation.Friend)
			{
				if (campRelationship2 == ERelation.Enemy)
				{
					this.Enemies.Add(entity.Id);
					this.AllEnemies.Add(entity.Id);
				}
				else
				{
					this.Neutrals.Add(entity.Id);
				}
			}
			else
			{
				this.Allies.Add(entity.Id);
			}
			this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(true, entity.Id, campRelationship2);
		}
	}

	// Token: 0x04001133 RID: 4403
	private const string PROFILE_KEY = "AiPerception_IsActorInSense";

	// Token: 0x04001134 RID: 4404
	public readonly HashSet<int> SceneItems = new HashSet<int>();

	// Token: 0x04001135 RID: 4405
	private HashSet<int> NewShareAllyLink = new HashSet<int>();

	// Token: 0x04001136 RID: 4406
	private readonly HashSet<int> BeShared = new HashSet<int>();

	// Token: 0x04001137 RID: 4407
	private readonly HashSet<int> AddedBeShared = new HashSet<int>();

	// Token: 0x04001138 RID: 4408
	private readonly List<int> Pending = new List<int>();

	// Token: 0x04001139 RID: 4409
	public Dictionary<int, ESenseTargetType> EntitiesInSense = new Dictionary<int, ESenseTargetType>();

	// Token: 0x0400113A RID: 4410
	protected Dictionary<int, ESenseTargetType> EntitiesToAdd = new Dictionary<int, ESenseTargetType>();

	// Token: 0x0400113B RID: 4411
	private readonly List<int> EntitiesToRemove = new List<int>();

	// Token: 0x0400113C RID: 4412
	private readonly Dictionary<int, float> EntitiesRemoveTime = new Dictionary<int, float>();

	// Token: 0x0400113D RID: 4413
	private readonly List<EntityHandle> TmpHandles = new List<EntityHandle>();

	// Token: 0x0400113E RID: 4414
	private readonly global::Vector TmpVector;

	// Token: 0x0400113F RID: 4415
	private readonly HashSet<int> TmpCheckedTraceType = new HashSet<int>();

	// Token: 0x04001140 RID: 4416
	private ECamp Camp;

	// Token: 0x04001141 RID: 4417
	private readonly int EntityId;

	// Token: 0x04001142 RID: 4418
	private readonly List<AiSenseObject> AiSenseObjects = new List<AiSenseObject>();

	// Token: 0x04001143 RID: 4419
	private readonly Dictionary<int, AiSenseObject> ExtraAiSenseObjects = new Dictionary<int, AiSenseObject>();

	// Token: 0x04001144 RID: 4420
	private readonly float SquaredShareDist;

	// Token: 0x04001145 RID: 4421
	private readonly Dictionary<ESenseTargetType, HashSet<AiSenseObject>> ActivateAiSenseObjects = new Dictionary<ESenseTargetType, HashSet<AiSenseObject>>();

	// Token: 0x04001146 RID: 4422
	private int WithAngleHorizontalCount;

	// Token: 0x04001147 RID: 4423
	private int WithAngleVerticalCount;

	// Token: 0x04001148 RID: 4424
	[Nullable(2)]
	private UTraceLineElement LineTrace;

	// Token: 0x04001149 RID: 4425
	private bool ForbidAllSense;

	// Token: 0x0400114A RID: 4426
	public readonly AiController AiController;

	// Token: 0x0400114B RID: 4427
	public readonly AiSenseGroup? AiSenseGroup;

	// Token: 0x0400114C RID: 4428
	private readonly Stat IsActorInSenseStat = Stat.Create("IsActorInSense", "", "");

	// Token: 0x0400114D RID: 4429
	private readonly Stat FindNewInSenseActorStat = Stat.Create("FindNewInSenseActor", "", "");

	// Token: 0x0400114E RID: 4430
	private readonly Stat FindOutSenseActorStat = Stat.Create("FindOutSenseActor", "", "");

	// Token: 0x0400114F RID: 4431
	private readonly Stat SenseActorStat = Stat.Create("SenseActor", "", "");

	// Token: 0x04001150 RID: 4432
	private readonly Stat FindShareAllyStat = Stat.Create("FindShareAlly", "", "");

	// Token: 0x04001151 RID: 4433
	private readonly Stat RefreshAllEnemiesStat = Stat.Create("RefreshAllEnemies", "", "");
}
