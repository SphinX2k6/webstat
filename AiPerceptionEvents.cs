using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Common.Component;
using UnrealEngine;

// Token: 0x02000D0D RID: 3341
[NullableContext(1)]
[Nullable(0)]
public class AiPerceptionEvents
{
	// Token: 0x060042FA RID: 17146 RVA: 0x0007B8F0 File Offset: 0x00079AF0
	public AiPerceptionEvents(AiController aiController)
	{
		this.AiController = aiController;
	}

	// Token: 0x060042FB RID: 17147 RVA: 0x0007B9FC File Offset: 0x00079BFC
	private void OnSceneItemDestroy(Entity entity)
	{
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		if (Vector.DistSquared(this.AiController.CharActorComp.ActorLocationProxy, component.ActorLocationProxy) < (double)this.DestroyEventListenSizeSquared && !this.BroadcastSet.Contains(component.Entity.Id))
		{
			this.BroadcastSet.Add(component.Entity.Id);
			this.DestroyEvent.Callback.Broadcast(component.Owner, true);
		}
	}

	// Token: 0x060042FC RID: 17148 RVA: 0x0007BA8C File Offset: 0x00079C8C
	public void Clear(bool force = false)
	{
		this.AiHateAddEntities.Clear();
		this.AiHateRemoveEntities.Clear();
		this.AiHateRemoveEntityIds.Clear();
		this.AiPerceptionAddEntities.Clear();
		this.AiPerceptionRemoveEntities.Clear();
		this.AiPerceptionRemoveEntityIds.Clear();
		this.AiHateOutRangeEntities.Clear();
		this.AiHateAddActors.Empty(true);
		this.AiHateRemoveActors.Empty(true);
		this.AiHateRemoveActorIds.Empty(true);
		this.AiPerceptionAddActors.Empty(true);
		this.AiPerceptionRemoveActors.Empty(true);
		this.AiPerceptionRemoveActorIds.Empty(true);
		this.AiHateOutRangeAddActors.Empty(true);
		if (!force)
		{
			return;
		}
		this.HateEvents.Clear();
		this.PerceptionEvents.Clear();
		this.HateOutRangeEvents.Clear();
		if (this.DestroyEvent != null)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDestroy));
			this.DestroyEvent = null;
			this.BroadcastSet.Clear();
		}
	}

	// Token: 0x060042FD RID: 17149 RVA: 0x0007BB95 File Offset: 0x00079D95
	public void TickPerception()
	{
		if (this.PerceptionEvents.Count == 0)
		{
			return;
		}
		this.CallPerception();
	}

	// Token: 0x060042FE RID: 17150 RVA: 0x0007BBAB File Offset: 0x00079DAB
	public void TickHate()
	{
		if (this.HateOutRangeEvents.Count > 0)
		{
			this.CallHateOutRange();
		}
		if (this.HateEvents.Count > 0)
		{
			this.CallHate();
		}
	}

	// Token: 0x060042FF RID: 17151 RVA: 0x0007BBD8 File Offset: 0x00079DD8
	private void CallHateOutRange()
	{
		foreach (int item in this.AiHateAddEntities)
		{
			int num = this.AiHateOutRangeEntities.IndexOf(item);
			if (num != -1)
			{
				this.AiHateOutRangeEntities.RemoveAt(num);
			}
		}
		if (this.AiHateOutRangeEntities.Count > 0)
		{
			this.PrintBroadInfo("超出距离被伤害没添加仇恨事件广播", this.AiHateOutRangeEntities, null);
			this.MigrateActor(this.AiHateOutRangeEntities, this.AiHateOutRangeAddActors);
			foreach (UKuroPerceptionEventBinder ukuroPerceptionEventBinder in this.HateOutRangeEvents)
			{
				ukuroPerceptionEventBinder.Callback.Broadcast(this.AiHateOutRangeAddActors, this.EmptyActors, this.EmptyActorIds, 0);
			}
			this.AiHateOutRangeEntities.Clear();
			this.AiHateOutRangeAddActors.Empty(true);
		}
	}

	// Token: 0x06004300 RID: 17152 RVA: 0x0007BCE4 File Offset: 0x00079EE4
	private void CallHate()
	{
		bool flag = this.AiHateAddEntities.Count > 0;
		bool flag2 = this.AiHateRemoveEntities.Count > 0;
		if (flag || flag2)
		{
			int count = this.AiController.AiHateList.GetHatredMap().Count;
			if (!flag)
			{
				this.PrintBroadInfo("仇恨广播", null, this.AiHateRemoveEntities);
				this.MigrateActor(this.AiHateRemoveEntities, this.AiHateRemoveActors);
				this.MigrateActorIds(this.AiHateRemoveEntityIds, this.AiHateRemoveActorIds);
				foreach (UKuroPerceptionEventBinder ukuroPerceptionEventBinder in this.HateEvents)
				{
					ukuroPerceptionEventBinder.Callback.Broadcast(this.EmptyActors, this.AiHateRemoveActors, this.AiHateRemoveActorIds, count);
				}
				this.AiHateRemoveEntities.Clear();
				this.AiHateRemoveActors.Empty(true);
				this.AiHateRemoveEntityIds.Clear();
				this.AiHateRemoveActorIds.Empty(true);
				return;
			}
			if (!flag2)
			{
				this.PrintBroadInfo("仇恨广播", this.AiHateAddEntities, null);
				this.MigrateActor(this.AiHateAddEntities, this.AiHateAddActors);
				foreach (UKuroPerceptionEventBinder ukuroPerceptionEventBinder2 in this.HateEvents)
				{
					ukuroPerceptionEventBinder2.Callback.Broadcast(this.AiHateAddActors, this.EmptyActors, this.EmptyActorIds, count);
				}
				this.AiHateAddEntities.Clear();
				this.AiHateAddActors.Empty(true);
				return;
			}
			this.PrintBroadInfo("仇恨广播", this.AiHateAddEntities, this.AiHateRemoveEntities);
			this.MigrateActor(this.AiHateAddEntities, this.AiHateAddActors);
			this.MigrateActor(this.AiHateRemoveEntities, this.AiHateRemoveActors);
			this.MigrateActorIds(this.AiHateRemoveEntityIds, this.AiHateRemoveActorIds);
			foreach (UKuroPerceptionEventBinder ukuroPerceptionEventBinder3 in this.HateEvents)
			{
				ukuroPerceptionEventBinder3.Callback.Broadcast(this.AiHateAddActors, this.AiHateRemoveActors, this.AiHateRemoveActorIds, count);
			}
			this.AiHateAddEntities.Clear();
			this.AiHateRemoveEntities.Clear();
			this.AiHateAddActors.Empty(true);
			this.AiHateRemoveActors.Empty(true);
			this.AiHateRemoveEntityIds.Clear();
			this.AiHateRemoveActorIds.Empty(true);
		}
	}

	// Token: 0x06004301 RID: 17153 RVA: 0x0007BF78 File Offset: 0x0007A178
	private void CallPerception()
	{
		bool flag = this.AiPerceptionAddEntities.Count > 0;
		bool flag2 = this.AiPerceptionRemoveEntities.Count > 0;
		if (flag || flag2)
		{
			int count = this.AiController.AiPerception.AllEnemies.Count;
			if (!flag)
			{
				this.PrintBroadInfo("感知广播", null, this.AiPerceptionRemoveEntities);
				this.MigrateActor(this.AiPerceptionRemoveEntities, this.AiPerceptionRemoveActors);
				this.MigrateActorIds(this.AiPerceptionRemoveEntityIds, this.AiPerceptionRemoveActorIds);
				foreach (UKuroPerceptionEventBinder ukuroPerceptionEventBinder in this.PerceptionEvents)
				{
					ukuroPerceptionEventBinder.Callback.Broadcast(this.EmptyActors, this.AiPerceptionRemoveActors, this.AiPerceptionRemoveActorIds, count);
				}
				this.AiPerceptionRemoveEntities.Clear();
				this.AiPerceptionRemoveActors.Empty(true);
				this.AiPerceptionRemoveEntityIds.Clear();
				this.AiPerceptionRemoveActorIds.Empty(true);
				return;
			}
			if (!flag2)
			{
				this.PrintBroadInfo("感知广播", this.AiPerceptionAddEntities, null);
				this.MigrateActor(this.AiPerceptionAddEntities, this.AiPerceptionAddActors);
				foreach (UKuroPerceptionEventBinder ukuroPerceptionEventBinder2 in this.PerceptionEvents)
				{
					ukuroPerceptionEventBinder2.Callback.Broadcast(this.AiPerceptionAddActors, this.EmptyActors, this.EmptyActorIds, count);
				}
				this.AiPerceptionAddEntities.Clear();
				this.AiPerceptionAddActors.Empty(true);
				return;
			}
			this.PrintBroadInfo("感知广播", this.AiPerceptionAddEntities, this.AiPerceptionRemoveEntities);
			this.MigrateActor(this.AiPerceptionAddEntities, this.AiPerceptionAddActors);
			this.MigrateActor(this.AiPerceptionRemoveEntities, this.AiPerceptionRemoveActors);
			this.MigrateActorIds(this.AiPerceptionRemoveEntityIds, this.AiPerceptionRemoveActorIds);
			foreach (UKuroPerceptionEventBinder ukuroPerceptionEventBinder3 in this.PerceptionEvents)
			{
				ukuroPerceptionEventBinder3.Callback.Broadcast(this.AiPerceptionAddActors, this.AiPerceptionRemoveActors, this.AiPerceptionRemoveActorIds, count);
			}
			this.AiPerceptionAddEntities.Clear();
			this.AiPerceptionRemoveEntities.Clear();
			this.AiPerceptionAddActors.Empty(true);
			this.AiPerceptionRemoveActors.Empty(true);
			this.AiPerceptionRemoveEntityIds.Clear();
			this.AiPerceptionRemoveActorIds.Empty(true);
		}
	}

	// Token: 0x06004302 RID: 17154 RVA: 0x0007C20C File Offset: 0x0007A40C
	private void MigrateActor(List<int> entities, TArray<AActor> outActors)
	{
		foreach (int id in entities)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get<Entity>(id);
			if (entity != null && entity.Active && entity.Valid)
			{
				BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
				AActor aactor = (component != null) ? component.Owner : null;
				if (aactor != null)
				{
					outActors.Add(aactor);
				}
			}
		}
		entities.Clear();
	}

	// Token: 0x06004303 RID: 17155 RVA: 0x0007C298 File Offset: 0x0007A498
	private void MigrateActorIds(List<int> entityIds, TArray<int> outIds)
	{
		foreach (int value in entityIds)
		{
			outIds.Add(value);
		}
	}

	// Token: 0x06004304 RID: 17156 RVA: 0x0007C2E8 File Offset: 0x0007A4E8
	public void AddAiHateEvent(UKuroPerceptionEventBinder handler)
	{
		if (this.HateEvents.Contains(handler))
		{
			return;
		}
		if (this.AiController.AiHateList != null)
		{
			foreach (KeyValuePair<int, HatredItem> keyValuePair in this.AiController.AiHateList.GetHatredMap())
			{
				this.AiController.AiPerceptionEvents.CollectAiHateEventById(true, keyValuePair.Key);
			}
		}
		this.HateEvents.Add(handler);
	}

	// Token: 0x06004305 RID: 17157 RVA: 0x0007C380 File Offset: 0x0007A580
	private void CollectEvent(bool addOrRemove, Entity entity, List<int> addEntities, List<int> removeEntities)
	{
		if (addOrRemove && addEntities != null)
		{
			int num = removeEntities.IndexOf(entity.Id);
			if (num != -1)
			{
				removeEntities.RemoveAt(num);
				addEntities.Add(entity.Id);
				return;
			}
			if (addEntities.Contains(entity.Id))
			{
				return;
			}
			addEntities.Add(entity.Id);
			return;
		}
		else
		{
			if (addEntities != null)
			{
				int num2 = addEntities.IndexOf(entity.Id);
				if (num2 != -1)
				{
					addEntities.RemoveAt(num2);
					removeEntities.Add(entity.Id);
					return;
				}
			}
			if (removeEntities.Contains(entity.Id))
			{
				return;
			}
			removeEntities.Add(entity.Id);
			return;
		}
	}

	// Token: 0x06004306 RID: 17158 RVA: 0x0007C41C File Offset: 0x0007A61C
	private void CollectEventById(bool addOrRemove, int entity, [Nullable(2)] List<int> addEntities, List<int> removeEntities)
	{
		if (addOrRemove && addEntities != null)
		{
			int num = removeEntities.IndexOf(entity);
			if (num != -1)
			{
				removeEntities.RemoveAt(num);
				addEntities.Add(entity);
				return;
			}
			if (addEntities.Contains(entity))
			{
				return;
			}
			addEntities.Add(entity);
			return;
		}
		else
		{
			if (addEntities != null)
			{
				int num2 = addEntities.IndexOf(entity);
				if (num2 != -1)
				{
					addEntities.RemoveAt(num2);
					removeEntities.Add(entity);
					return;
				}
			}
			if (removeEntities.Contains(entity))
			{
				return;
			}
			removeEntities.Add(entity);
			return;
		}
	}

	// Token: 0x06004307 RID: 17159 RVA: 0x0007C490 File Offset: 0x0007A690
	public void CollectAiHateEvent(bool addOrRemove, Entity entity)
	{
		this.CollectEvent(addOrRemove, entity, this.AiHateAddEntities, this.AiHateRemoveEntities);
	}

	// Token: 0x06004308 RID: 17160 RVA: 0x0007C4A6 File Offset: 0x0007A6A6
	public void CollectAiHateEventById(bool addOrRemove, int entityId)
	{
		this.CollectEventById(addOrRemove, entityId, this.AiHateAddEntities, this.AiHateRemoveEntityIds);
	}

	// Token: 0x06004309 RID: 17161 RVA: 0x0007C4BC File Offset: 0x0007A6BC
	public void AddAiHateOutRangeEvent(UKuroPerceptionEventBinder handler)
	{
		if (this.HateOutRangeEvents.Contains(handler))
		{
			return;
		}
		this.HateOutRangeEvents.Add(handler);
	}

	// Token: 0x0600430A RID: 17162 RVA: 0x0007C4D9 File Offset: 0x0007A6D9
	public void CollectAiHateOutRangeEvent(Entity entity)
	{
		if (this.AiHateOutRangeEntities.Contains(entity.Id))
		{
			return;
		}
		this.AiHateOutRangeEntities.Add(entity.Id);
	}

	// Token: 0x0600430B RID: 17163 RVA: 0x0007C500 File Offset: 0x0007A700
	public void AddAiPerceptionEvent(UKuroPerceptionEventBinder handler, bool includeFriend, bool includeEnemy, bool includeNeutral)
	{
		if (this.PerceptionEvents.Contains(handler))
		{
			return;
		}
		this.IncludeFriend = includeFriend;
		this.IncludeEnemy = includeEnemy;
		this.IncludeNeutral = includeNeutral;
		if (this.AiController.AiPerception != null)
		{
			foreach (int id in this.AiController.AiPerception.AllEnemies)
			{
				this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(true, id, ERelation.Enemy);
			}
		}
		this.PerceptionEvents.Add(handler);
	}

	// Token: 0x0600430C RID: 17164 RVA: 0x0007C5A8 File Offset: 0x0007A7A8
	public void SetPerceptionEventState(bool includeFriend, bool includeEnemy, bool includeNeutral)
	{
		this.IncludeFriend = includeFriend;
		this.IncludeEnemy = includeEnemy;
		this.IncludeNeutral = includeNeutral;
	}

	// Token: 0x0600430D RID: 17165 RVA: 0x0007C5BF File Offset: 0x0007A7BF
	public void CollectAiPerceptionEventByActorComp(bool addOrRemove, BaseActorComponent actorComp, ERelation relation)
	{
		if (relation != ERelation.Friend)
		{
			if (relation != ERelation.Enemy)
			{
				if (!this.IncludeNeutral)
				{
					return;
				}
			}
			else if (!this.IncludeEnemy)
			{
				return;
			}
		}
		else if (!this.IncludeFriend)
		{
			return;
		}
		this.CollectEvent(addOrRemove, actorComp.Entity, this.AiPerceptionAddEntities, this.AiPerceptionRemoveEntities);
	}

	// Token: 0x0600430E RID: 17166 RVA: 0x0007C5FF File Offset: 0x0007A7FF
	public void CollectAiPerceptionEventById(bool addOrRemove, int id, ERelation relation)
	{
		if (relation != ERelation.Friend)
		{
			if (relation != ERelation.Enemy)
			{
				if (!this.IncludeNeutral)
				{
					return;
				}
			}
			else if (!this.IncludeEnemy)
			{
				return;
			}
		}
		else if (!this.IncludeFriend)
		{
			return;
		}
		this.CollectEventById(addOrRemove, id, this.AiPerceptionAddEntities, this.AiPerceptionRemoveEntities);
	}

	// Token: 0x0600430F RID: 17167 RVA: 0x0007C63A File Offset: 0x0007A83A
	public void CollectAiRemovePerceptionEventByEntityId(bool addOrRemove, int entityId, ERelation relation)
	{
		if (relation != ERelation.Friend)
		{
			if (relation != ERelation.Enemy)
			{
				if (!this.IncludeNeutral)
				{
					return;
				}
			}
			else if (!this.IncludeEnemy)
			{
				return;
			}
		}
		else if (!this.IncludeFriend)
		{
			return;
		}
		this.CollectEventById(addOrRemove, entityId, null, this.AiPerceptionRemoveEntityIds);
	}

	// Token: 0x06004310 RID: 17168 RVA: 0x0007C670 File Offset: 0x0007A870
	public void AddSceneItemDestroyEvent(float distance, UKuroActorEventBinder eventBinder)
	{
		if (this.DestroyEvent == null)
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDestroy));
		}
		this.DestroyEvent = eventBinder;
		this.DestroyEventListenSizeSquared = distance * distance;
	}

	// Token: 0x06004311 RID: 17169 RVA: 0x0007C6A6 File Offset: 0x0007A8A6
	public void RemoveSceneItemDestroyEvent(UKuroActorEventBinder eventBinder)
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDestroy));
		this.DestroyEvent = null;
		this.BroadcastSet.Clear();
	}

	// Token: 0x06004312 RID: 17170 RVA: 0x0007C6D6 File Offset: 0x0007A8D6
	public void ForceTriggerSceneItemDestroyEvent(AActor actor)
	{
		UKuroActorEventBinder destroyEvent = this.DestroyEvent;
		if (destroyEvent == null || !destroyEvent.IsValid())
		{
			return;
		}
		this.DestroyEvent.Callback.Broadcast(actor, true);
	}

	// Token: 0x06004313 RID: 17171 RVA: 0x0007C704 File Offset: 0x0007A904
	public void OnSenseSceneItem(BaseActorComponent otherActorComp)
	{
		if (this.DestroyEvent == null || this.BroadcastSet.Contains(otherActorComp.Entity.Id))
		{
			return;
		}
		DurabilityComponent component = otherActorComp.Entity.GetComponent<DurabilityComponent>();
		if (component == null || !component.Valid || !component.IsDestroyed)
		{
			return;
		}
		this.BroadcastSet.Add(otherActorComp.Entity.Id);
		this.DestroyEvent.Callback.Broadcast(otherActorComp.Owner, true);
	}

	// Token: 0x06004314 RID: 17172 RVA: 0x0007C788 File Offset: 0x0007A988
	[NullableContext(2)]
	private unsafe void PrintBroadInfo([Nullable(1)] string info, List<int> addIds, List<int> removeIds)
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Ai;
		Entity entity = this.AiController.CharActorComp.Entity;
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("addIds", addIds);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("removeIds:", removeIds);
		instance.Info(flag, entity, info, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x04001152 RID: 4434
	private readonly List<int> AiHateAddEntities = new List<int>();

	// Token: 0x04001153 RID: 4435
	private readonly List<int> AiHateRemoveEntities = new List<int>();

	// Token: 0x04001154 RID: 4436
	private readonly List<int> AiHateRemoveEntityIds = new List<int>();

	// Token: 0x04001155 RID: 4437
	private readonly List<int> AiPerceptionAddEntities = new List<int>();

	// Token: 0x04001156 RID: 4438
	private readonly List<int> AiPerceptionRemoveEntities = new List<int>();

	// Token: 0x04001157 RID: 4439
	private readonly List<int> AiPerceptionRemoveEntityIds = new List<int>();

	// Token: 0x04001158 RID: 4440
	private readonly List<int> AiHateOutRangeEntities = new List<int>();

	// Token: 0x04001159 RID: 4441
	private readonly TArray<AActor> AiHateAddActors = new TArray<AActor>();

	// Token: 0x0400115A RID: 4442
	private readonly TArray<AActor> AiHateRemoveActors = new TArray<AActor>();

	// Token: 0x0400115B RID: 4443
	private readonly TArray<int> AiHateRemoveActorIds = new TArray<int>();

	// Token: 0x0400115C RID: 4444
	private readonly TArray<AActor> AiPerceptionAddActors = new TArray<AActor>();

	// Token: 0x0400115D RID: 4445
	private readonly TArray<AActor> AiPerceptionRemoveActors = new TArray<AActor>();

	// Token: 0x0400115E RID: 4446
	private readonly TArray<int> AiPerceptionRemoveActorIds = new TArray<int>();

	// Token: 0x0400115F RID: 4447
	private readonly TArray<AActor> EmptyActors = new TArray<AActor>();

	// Token: 0x04001160 RID: 4448
	private readonly TArray<int> EmptyActorIds = new TArray<int>();

	// Token: 0x04001161 RID: 4449
	private readonly TArray<AActor> AiHateOutRangeAddActors = new TArray<AActor>();

	// Token: 0x04001162 RID: 4450
	private readonly List<UKuroPerceptionEventBinder> HateEvents = new List<UKuroPerceptionEventBinder>();

	// Token: 0x04001163 RID: 4451
	private readonly List<UKuroPerceptionEventBinder> PerceptionEvents = new List<UKuroPerceptionEventBinder>();

	// Token: 0x04001164 RID: 4452
	private readonly List<UKuroPerceptionEventBinder> HateOutRangeEvents = new List<UKuroPerceptionEventBinder>();

	// Token: 0x04001165 RID: 4453
	private readonly AiController AiController;

	// Token: 0x04001166 RID: 4454
	private bool IncludeFriend = true;

	// Token: 0x04001167 RID: 4455
	private bool IncludeEnemy = true;

	// Token: 0x04001168 RID: 4456
	private bool IncludeNeutral = true;

	// Token: 0x04001169 RID: 4457
	[Nullable(2)]
	private UKuroActorEventBinder DestroyEvent;

	// Token: 0x0400116A RID: 4458
	private float DestroyEventListenSizeSquared;

	// Token: 0x0400116B RID: 4459
	private readonly HashSet<int> BroadcastSet = new HashSet<int>();
}
