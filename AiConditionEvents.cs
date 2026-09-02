using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Monster.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02000CF4 RID: 3316
[NullableContext(1)]
[Nullable(0)]
public class AiConditionEvents
{
	// Token: 0x0600420A RID: 16906 RVA: 0x000723C8 File Offset: 0x000705C8
	public AiConditionEvents(AiController aiController)
	{
		this.AiController = aiController;
	}

	// Token: 0x0600420B RID: 16907 RVA: 0x000723F0 File Offset: 0x000705F0
	private void OnSceneItemDestroy(Entity entity)
	{
		BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
		if (component == null || !component.Valid)
		{
			return;
		}
		double num = Vector.DistSquared(this.AiController.CharActorComp.ActorLocationProxy, component.ActorLocationProxy);
		foreach (KeyValuePair<UKuroActorEventBinder, double> keyValuePair in this.DestroyEvents)
		{
			UKuroActorEventBinder key = keyValuePair.Key;
			double value = keyValuePair.Value;
			if (num < value)
			{
				key.Callback.Broadcast(component.Owner, true);
			}
		}
	}

	// Token: 0x0600420C RID: 16908 RVA: 0x0007249C File Offset: 0x0007069C
	public void AddConditionEvent(SAiConditions conditions, UKuroBooleanEventBinder eventBinder)
	{
		ConditionEventPair conditionEventPair = new ConditionEventPair();
		conditionEventPair.InitConditions(conditions, eventBinder, this.AiController.CharActorComp);
		this.ConditionEventPairs.Add(conditionEventPair);
	}

	// Token: 0x0600420D RID: 16909 RVA: 0x000724D0 File Offset: 0x000706D0
	public bool RemoveConditionEvent(UKuroBooleanEventBinder eventBinder)
	{
		int num = 0;
		foreach (ConditionEventPair conditionEventPair in this.ConditionEventPairs)
		{
			if (conditionEventPair.EventBinder == eventBinder)
			{
				conditionEventPair.Clear();
				break;
			}
			num++;
		}
		if (num < this.ConditionEventPairs.Count)
		{
			this.ConditionEventPairs.RemoveRange(num, this.ConditionEventPairs.Count - num);
			return true;
		}
		return false;
	}

	// Token: 0x0600420E RID: 16910 RVA: 0x00072560 File Offset: 0x00070760
	public void AddSceneItemDestroyEvent(double distance, UKuroActorEventBinder eventBinder)
	{
		if (this.DestroyEvents.Count == 0)
		{
			Singleton<EventSystem>.Instance.Add<Entity>(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDestroy));
		}
		this.DestroyEvents[eventBinder] = distance * distance;
	}

	// Token: 0x0600420F RID: 16911 RVA: 0x0007259A File Offset: 0x0007079A
	public void RemoveSceneItemDestroyEvent(UKuroActorEventBinder eventBinder)
	{
		if (this.DestroyEvents.Remove(eventBinder) && this.DestroyEvents.Count == 0)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDestroy));
		}
	}

	// Token: 0x06004210 RID: 16912 RVA: 0x000725D4 File Offset: 0x000707D4
	public void Clear()
	{
		foreach (ConditionEventPair conditionEventPair in this.ConditionEventPairs)
		{
			conditionEventPair.Clear();
		}
		this.ConditionEventPairs.Clear();
		if (this.DestroyEvents.Count > 0)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDestroy));
		}
		this.DestroyEvents.Clear();
	}

	// Token: 0x06004211 RID: 16913 RVA: 0x00072664 File Offset: 0x00070864
	public void ResetAllConditionEvent()
	{
		foreach (ConditionEventPair conditionEventPair in this.ConditionEventPairs)
		{
			conditionEventPair.ResetConditions(false);
		}
	}

	// Token: 0x0400105C RID: 4188
	private readonly List<ConditionEventPair> ConditionEventPairs = new List<ConditionEventPair>();

	// Token: 0x0400105D RID: 4189
	private readonly Dictionary<UKuroActorEventBinder, double> DestroyEvents = new Dictionary<UKuroActorEventBinder, double>();

	// Token: 0x0400105E RID: 4190
	private readonly AiController AiController;
}
