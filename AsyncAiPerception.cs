using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Core.Model;
using CSharpScript.Game.Common.Event;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000D12 RID: 3346
[NullableContext(1)]
[Nullable(0)]
public class AsyncAiPerception : IAiPerception, IStaticVariableResetter
{
	// Token: 0x06004332 RID: 17202 RVA: 0x0007D3C8 File Offset: 0x0007B5C8
	static AsyncAiPerception()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AsyncAiPerception.CreateStaticDefaultValue), new Action(AsyncAiPerception.ResetStaticDefaultValue));
	}

	// Token: 0x06004333 RID: 17203 RVA: 0x0007D3E8 File Offset: 0x0007B5E8
	public static void CreateStaticDefaultValue()
	{
		AsyncAiPerception.AfterAsyncTaskStat = Stat.Create("AsyncAiPerception.AfterAsyncTask", "", "");
		AsyncAiPerception.SenseActorStat = Stat.Create("AsyncAiPerception.SenseActor", "", "");
		AsyncAiPerception.FindShareAllyStat = Stat.Create("AsyncAiPerception.FindShareAlly", "", "");
		AsyncAiPerception.RefreshAllEnemiesStat = Stat.Create("AsyncAiPerception.RefreshAllEnemies", "", "");
	}

	// Token: 0x06004334 RID: 17204 RVA: 0x0007D459 File Offset: 0x0007B659
	public static void ResetStaticDefaultValue()
	{
		AsyncAiPerception.AfterAsyncTaskStat = null;
		AsyncAiPerception.SenseActorStat = null;
		AsyncAiPerception.FindShareAllyStat = null;
		AsyncAiPerception.RefreshAllEnemiesStat = null;
	}

	// Token: 0x06004335 RID: 17205 RVA: 0x0007D474 File Offset: 0x0007B674
	public unsafe AsyncAiPerception(AiController aiController, AiSenseGroup aiSenseGroup, AiSense[] aiSenses)
	{
		this.AiController = aiController;
		this.AiSenseGroup = new AiSenseGroup?(aiSenseGroup);
		this.EntityId = this.AiController.CharActorComp.Entity.Id;
		this.AiPerceptionDataHandle = UKuroJsModelFunctionLibrary.CreateAiPerceptionData(this.EntityId);
		int aiPerceptionDataHandle = this.AiPerceptionDataHandle;
		FVector2D fvector2D = new FVector2D(this.AiSenseGroup.Value.LoseDelay.Value.Min, this.AiSenseGroup.Value.LoseDelay.Value.Max);
		UKuroJsModelFunctionLibrary.SetAiPerceptionDataAiSenseGroupLoseDelayRange(aiPerceptionDataHandle, fvector2D);
		TsBaseCharacter actor = this.AiController.CharActorComp.Actor;
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr zero4 = IntPtr.Zero;
		if (FKuroJsModelCSharpInterface.GetAiPerceptionDataMap(this.AiPerceptionDataHandle, ref zero, ref zero2, ref zero3, ref zero4))
		{
			this.EntitiesInSense = new TMap<int, byte>(zero, actor);
			this.EntitiesToAdd = new TMap<int, byte>(zero2, actor);
			this.EntitiesRemoveTime = new TMap<int, double>(zero3, actor);
			this.EntitiesNotSense = new TArray<int>(zero4, actor);
		}
		else
		{
			this.EntitiesInSense = new TMap<int, byte>();
			this.EntitiesToAdd = new TMap<int, byte>();
			this.EntitiesRemoveTime = new TMap<int, double>();
			this.EntitiesNotSense = new TArray<int>();
		}
		this.Camp = this.AiController.CharActorComp.Actor.Camp;
		this.EntitiesInSense.Add(this.EntityId, 0);
		int num = -1;
		foreach (AiSense aiSense in aiSenses)
		{
			AsyncAiSenseObject asyncAiSenseObject = new AsyncAiSenseObject(aiSense);
			this.AiSenseObjects.Add(asyncAiSenseObject);
			num++;
			if (num <= 0)
			{
				if (asyncAiSenseObject.AiSenseObjectData->WithAngleHorizontal)
				{
					UKuroJsModelFunctionLibrary.IncrementAiPerceptionDataWithAngleHorizontalCount(this.AiPerceptionDataHandle);
				}
				if (asyncAiSenseObject.AiSenseObjectData->WithAngleVertical)
				{
					UKuroJsModelFunctionLibrary.IncrementAiPerceptionDataWithAngleVerticalCount(this.AiPerceptionDataHandle);
				}
				if (aiSense.SenseDistanceRange.Value.Max > this.MaxSenseRange)
				{
					this.MaxSenseRange = aiSense.SenseDistanceRange.Value.Max;
				}
				asyncAiSenseObject.AiPerceptionDataHandle = this.AiPerceptionDataHandle;
				FKuroJsModelCSharpInterface.AddActivateAiSenseObjects(this.AiPerceptionDataHandle, (byte)asyncAiSenseObject.AiSense.SenseTarget, (void*)asyncAiSenseObject.AiSenseObjectData);
			}
		}
		this.SquaredShareDist = ((this.AiSenseGroup != null) ? (this.AiSenseGroup.Value.ShareDis * this.AiSenseGroup.Value.ShareDis) : 0f);
		if (this.SquaredShareDist > 0f)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "共享感知距离应该不需要再是用了";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Actor";
			CharacterActorComponent charActorComp = this.AiController.CharActorComp;
			ptr = new ValueTuple<string, object>(item, (charActorComp != null) ? charActorComp.Actor.GetName() : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AiSenseGroup", this.AiSenseGroup.Value.Id);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		this.OnLastDemotableTickHandle = Singleton<TickProcessSystem>.Instance.RegisterTickProcess(ETickingGroup.TG_LastDemotable, true, new Action<float>(this.OnLastDemotableTick), "AsyncAiPerception");
	}

	// Token: 0x06004336 RID: 17206 RVA: 0x0007D85C File Offset: 0x0007BA5C
	public override void Tick()
	{
		if (Singleton<Time>.Instance.Frame == Singleton<Time>.Instance.LastPauseTimeFrame || Singleton<Time>.Instance.Frame == Singleton<Time>.Instance.LastResumeTimeFrame || Singleton<Time>.Instance.Frame == Singleton<Time>.Instance.LastResumeTimeFrame + 1)
		{
			return;
		}
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
		if (this.LastTickFrame == Singleton<Time>.Instance.Frame)
		{
			Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.WLJ, "[AsyncAiPerception::Tick] Execute twice or more in one frame. Error!!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.LastTickFrame = Singleton<Time>.Instance.Frame;
		this.StartAsyncTask();
	}

	// Token: 0x06004337 RID: 17207 RVA: 0x0007D930 File Offset: 0x0007BB30
	private void StartAsyncTask()
	{
		if (this.AiPerceptionDataHandle == 0)
		{
			return;
		}
		if (ConfigBase<AiConfig>.Instance.CppAsyncAiPerception)
		{
			if (this.LineTrace == null)
			{
				this.LineTrace = new UTraceLineElement();
				this.LineTrace.WorldContextObject = this.AiController.CharActorComp.Actor;
				this.LineTrace.bIsSingle = true;
				this.LineTrace.bIgnoreSelf = true;
			}
			FAIAsyncPerceptionCallback faiasyncPerceptionCallback;
			if ((faiasyncPerceptionCallback = this._asyncPerceptionCallback) == null)
			{
				faiasyncPerceptionCallback = (this._asyncPerceptionCallback = global::DelegateUtils.ToManualReleaseDelegate<FAIAsyncPerceptionCallback>(new Action(this.AfterAsyncTask)));
			}
			FAIAsyncPerceptionCallback faiasyncPerceptionCallback2 = faiasyncPerceptionCallback;
			FKuroAIPerceptionUtils.StartAsyncAiPerception(faiasyncPerceptionCallback2, this.AiPerceptionDataHandle, Singleton<Time>.Instance.Now, this.LineTrace);
			return;
		}
		this.AfterAsyncTask();
	}

	// Token: 0x06004338 RID: 17208 RVA: 0x0007D9E4 File Offset: 0x0007BBE4
	private void AfterAsyncTask()
	{
		if (this.AiPerceptionDataHandle == 0)
		{
			return;
		}
		if (this.ClearFrame != -1 && this.ClearFrame <= Singleton<Time>.Instance.Frame)
		{
			return;
		}
		EntitySystem instance = Singleton<EntitySystem>.Instance;
		foreach (int num in this.EntitiesInSense.Keys)
		{
			if (num != this.EntityId)
			{
				Entity entity = instance.Get<Entity>(num);
				if (entity == null || !entity.Valid || !entity.Active)
				{
					this.EntitiesInSense.Remove(num);
					this.EntitiesRemoveTime.Remove(num);
					if (this.Allies.Remove(num))
					{
						this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(false, num, ERelation.Friend);
					}
					if (this.Enemies.Remove(num))
					{
						this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(false, num, ERelation.Enemy);
					}
					if (this.Neutrals.Remove(num))
					{
						this.AiController.AiPerceptionEvents.CollectAiPerceptionEventById(false, num, ERelation.None);
					}
					this.SceneItems.Remove(num);
				}
			}
		}
		int num2 = this.EntitiesNotSense.Num();
		for (int i = 0; i < num2; i++)
		{
			int id = this.EntitiesNotSense.Get(i);
			Entity entity2 = instance.Get<Entity>(id);
			if (entity2 != null && entity2.Valid)
			{
				this.SenseActor(entity2, false);
			}
		}
		this.EntitiesNotSense.Empty(true);
		foreach (KeyValuePair<int, byte> keyValuePair in this.EntitiesToAdd)
		{
			int num3;
			byte b;
			keyValuePair.Deconstruct(out num3, out b);
			int num4 = num3;
			byte value = b;
			Entity entity3 = instance.Get<Entity>(num4);
			if (entity3 != null && entity3.Active)
			{
				this.EntitiesInSense[num4] = value;
				entity3 = instance.Get<Entity>(num4);
				if (entity3 != null && entity3.Valid)
				{
					this.SenseActor(entity3, true);
				}
			}
		}
		this.EntitiesToAdd.Empty(0);
		this.FindShareAlly();
		this.RefreshAllEnemies();
	}

	// Token: 0x06004339 RID: 17209 RVA: 0x0007DC3C File Offset: 0x0007BE3C
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

	// Token: 0x0600433A RID: 17210 RVA: 0x0007DD4C File Offset: 0x0007BF4C
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
							AsyncAiPerception asyncAiPerception = component2.AiController.AiPerception as AsyncAiPerception;
							if (asyncAiPerception != null)
							{
								asyncAiPerception.BeShared.Add(this.EntityId);
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
						AsyncAiPerception asyncAiPerception2 = component3.AiController.AiPerception as AsyncAiPerception;
						if (asyncAiPerception2 != null)
						{
							asyncAiPerception2.BeShared.Remove(this.EntityId);
						}
					}
				}
			}
		}
		HashSet<int> newShareAllyLink = this.NewShareAllyLink;
		this.NewShareAllyLink = this.ShareAllyLink;
		this.ShareAllyLink = newShareAllyLink;
	}

	// Token: 0x0600433B RID: 17211 RVA: 0x0007E000 File Offset: 0x0007C200
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
			goto IL_1E6;
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
				AsyncAiPerception asyncAiPerception = component.AiController.AiPerception as AsyncAiPerception;
				if (asyncAiPerception != null)
				{
					foreach (int item4 in asyncAiPerception.BeShared)
					{
						if (this.AddedBeShared.Add(item4))
						{
							this.Pending.Add(item4);
						}
					}
				}
			}
		}
		IL_1E6:
		if (this.Pending.Count <= 0)
		{
			return;
		}
		goto IL_BA;
	}

	// Token: 0x0600433C RID: 17212 RVA: 0x0007E238 File Offset: 0x0007C438
	public override void OnEntityCampModified(Entity entity, ECamp oldCamp, ECamp newCamp)
	{
		if (this.AiPerceptionDataHandle == 0)
		{
			return;
		}
		int id = entity.Id;
		CharacterAiComponent charAiDesignComp = this.AiController.CharAiDesignComp;
		int? num = (charAiDesignComp != null) ? new int?(charAiDesignComp.Entity.Id) : null;
		if (id == num.GetValueOrDefault() & num != null)
		{
			this.Camp = this.AiController.CharActorComp.Actor.Camp;
			this.Clear(false, true);
			return;
		}
		byte b = 0;
		if (!FKuroJsModelCSharpInterface.GetEntitySenseType(this.AiPerceptionDataHandle, entity.Id, ref b) || b != 0)
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

	// Token: 0x0600433D RID: 17213 RVA: 0x0007E3D4 File Offset: 0x0007C5D4
	public unsafe override string GetEnableAiSenseDebug()
	{
		string text = "感知配置激活情况: ";
		for (int i = 0; i < this.AiSenseObjects.Count; i++)
		{
			AsyncAiSenseObject asyncAiSenseObject = this.AiSenseObjects[i];
			int id = this.AiSenseObjects[i].AiSense.Id;
			bool flag = FKuroJsModelCSharpInterface.ContainsActivateAiSenseObjects(this.AiPerceptionDataHandle, (byte)asyncAiSenseObject.AiSense.SenseTarget, (void*)asyncAiSenseObject.AiSenseObjectData);
			string str = id.ToString() + ":" + flag.ToString() + "; ";
			text += str;
		}
		foreach (AsyncAiSenseObject asyncAiSenseObject2 in this.ExtraAiSenseObjects.Values)
		{
			int id2 = asyncAiSenseObject2.AiSense.Id;
			bool flag2 = FKuroJsModelCSharpInterface.ContainsActivateAiSenseObjects(this.AiPerceptionDataHandle, (byte)asyncAiSenseObject2.AiSense.SenseTarget, (void*)asyncAiSenseObject2.AiSenseObjectData);
			string str2 = id2.ToString() + ":" + flag2.ToString() + "; ";
			text += str2;
		}
		return text;
	}

	// Token: 0x0600433E RID: 17214 RVA: 0x0007E51C File Offset: 0x0007C71C
	private void EnableAiSenseInternal(AsyncAiSenseObject aiSenseObject, bool enable)
	{
		this.EnableAiSenseObjectMap[aiSenseObject] = enable;
	}

	// Token: 0x0600433F RID: 17215 RVA: 0x0007E52C File Offset: 0x0007C72C
	private unsafe void OnLastEnableAiSenseInternal(AsyncAiSenseObject aiSenseObject, bool enable)
	{
		if (FKuroJsModelCSharpInterface.ContainsActivateAiSenseObjects(this.AiPerceptionDataHandle, (byte)aiSenseObject.AiSense.SenseTarget, (void*)aiSenseObject.AiSenseObjectData) == enable)
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
			if (aiSenseObject.AiSenseObjectData->WithAngleHorizontal)
			{
				UKuroJsModelFunctionLibrary.IncrementAiPerceptionDataWithAngleHorizontalCount(this.AiPerceptionDataHandle);
			}
			if (aiSenseObject.AiSenseObjectData->WithAngleVertical)
			{
				UKuroJsModelFunctionLibrary.IncrementAiPerceptionDataWithAngleVerticalCount(this.AiPerceptionDataHandle);
			}
			aiSenseObject.AiPerceptionDataHandle = this.AiPerceptionDataHandle;
			FKuroJsModelCSharpInterface.AddActivateAiSenseObjects(this.AiPerceptionDataHandle, (byte)aiSenseObject.AiSense.SenseTarget, (void*)aiSenseObject.AiSenseObjectData);
			return;
		}
		if (aiSenseObject.AiSenseObjectData->WithAngleHorizontal)
		{
			UKuroJsModelFunctionLibrary.DecrementAiPerceptionDataWithAngleHorizontalCount(this.AiPerceptionDataHandle);
		}
		if (aiSenseObject.AiSenseObjectData->WithAngleVertical)
		{
			UKuroJsModelFunctionLibrary.DecrementAiPerceptionDataWithAngleVerticalCount(this.AiPerceptionDataHandle);
		}
		FKuroJsModelCSharpInterface.RemoveActivateAiSenseObjects(this.AiPerceptionDataHandle, (byte)aiSenseObject.AiSense.SenseTarget, (void*)aiSenseObject.AiSenseObjectData);
	}

	// Token: 0x06004340 RID: 17216 RVA: 0x0007E6A2 File Offset: 0x0007C8A2
	public override void SetAiSenseEnable(int index, bool enable)
	{
		if (index < 0 || this.AiSenseObjects.Count <= index)
		{
			return;
		}
		this.EnableAiSenseInternal(this.AiSenseObjects[index], enable);
	}

	// Token: 0x06004341 RID: 17217 RVA: 0x0007E6CC File Offset: 0x0007C8CC
	public override void SetAiSenseEnableWithoutForbidAllSense(bool enable)
	{
		if (this.AiSenseObjects.Count <= 0)
		{
			return;
		}
		foreach (AsyncAiSenseObject aiSenseObject in this.AiSenseObjects)
		{
			this.EnableAiSenseInternal(aiSenseObject, enable);
		}
	}

	// Token: 0x06004342 RID: 17218 RVA: 0x0007E730 File Offset: 0x0007C930
	public override void SetAllAiSenseEnable(bool enable)
	{
		if (!enable)
		{
			this.DisableAllAiSenseFrame = Singleton<Time>.Instance.Frame;
		}
		this.ForbidAllSense = !enable;
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Ai;
		CharacterActorComponent charActorComp = this.AiController.CharActorComp;
		Entity entity = (charActorComp != null) ? charActorComp.Entity : null;
		string message = "禁用全部感知";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("forbid", this.ForbidAllSense);
		instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06004343 RID: 17219 RVA: 0x0007E7A0 File Offset: 0x0007C9A0
	private void OnLastSetAllAiSenseEnable(float deltaTime)
	{
		if (this.AiPerceptionDataHandle == 0)
		{
			return;
		}
		if (this.ForbidAllSense)
		{
			EntitySystem instance = Singleton<EntitySystem>.Instance;
			foreach (int num in this.EntitiesInSense.Keys)
			{
				if (num != this.EntityId)
				{
					Entity entity = instance.Get<Entity>(num);
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
			this.EntitiesInSense.Empty(0);
			this.EntitiesInSense.Add(this.EntityId, 0);
		}
	}

	// Token: 0x06004344 RID: 17220 RVA: 0x0007E878 File Offset: 0x0007CA78
	public override void AddOrRemoveAiSense(int aiSenseId, bool add)
	{
		if (add && !this.ExtraAiSenseObjects.ContainsKey(aiSenseId))
		{
			AiSense? aiSense = ConfigBase<AiConfig>.Instance.LoadAiSense(aiSenseId.ToString());
			if (aiSense != null)
			{
				this.ExtraAiSenseObjects[aiSenseId] = new AsyncAiSenseObject(aiSense.Value);
			}
		}
		AsyncAiSenseObject aiSenseObject;
		if (this.ExtraAiSenseObjects.TryGetValue(aiSenseId, out aiSenseObject))
		{
			this.EnableAiSenseInternal(aiSenseObject, add);
		}
	}

	// Token: 0x06004345 RID: 17221 RVA: 0x0007E8E4 File Offset: 0x0007CAE4
	public override void EnableAiSenseByType(int type, bool enable)
	{
		foreach (AsyncAiSenseObject asyncAiSenseObject in this.AiSenseObjects)
		{
			if (asyncAiSenseObject.AiSense.SenseType == type)
			{
				this.EnableAiSenseInternal(asyncAiSenseObject, enable);
			}
		}
		foreach (AsyncAiSenseObject asyncAiSenseObject2 in this.ExtraAiSenseObjects.Values)
		{
			if (asyncAiSenseObject2.AiSense.SenseType == type)
			{
				this.EnableAiSenseInternal(asyncAiSenseObject2, enable);
			}
		}
	}

	// Token: 0x06004346 RID: 17222 RVA: 0x0007E9A8 File Offset: 0x0007CBA8
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
		this.ClearFrame = Singleton<Time>.Instance.Frame;
		if (allClear)
		{
			if (this._asyncPerceptionCallback != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.AfterAsyncTask));
				this._asyncPerceptionCallback = null;
			}
			this.TmpHandles.Clear();
			foreach (AsyncAiSenseObject asyncAiSenseObject in this.AiSenseObjects)
			{
				asyncAiSenseObject.Clear();
			}
			if (this.AiPerceptionDataHandle != 0)
			{
				UKuroJsModelFunctionLibrary.DestroyAiPerceptionData(this.AiPerceptionDataHandle);
				this.AiPerceptionDataHandle = 0;
			}
			if (this.OnLastDemotableTickHandle > 0)
			{
				Singleton<TickProcessSystem>.Instance.UnregisterTickProcess(this.OnLastDemotableTickHandle);
				this.OnLastDemotableTickHandle = 0;
			}
		}
	}

	// Token: 0x06004347 RID: 17223 RVA: 0x0007EBA8 File Offset: 0x0007CDA8
	private void OnLastClear(float deltaTime)
	{
		if (this.AiPerceptionDataHandle == 0)
		{
			return;
		}
		this.EntitiesInSense.Empty(0);
		this.EntitiesInSense.Add(this.EntityId, 0);
		this.EntitiesToAdd.Empty(0);
	}

	// Token: 0x06004348 RID: 17224 RVA: 0x0007EBE0 File Offset: 0x0007CDE0
	private void OnLastDemotableTick(float deltaTime)
	{
		if (this.ClearFrame != -1 && this.ClearFrame <= Singleton<Time>.Instance.Frame)
		{
			this.ClearFrame = -1;
			this.OnLastClear(deltaTime);
		}
		if (this.DisableAllAiSenseFrame == Singleton<Time>.Instance.Frame)
		{
			this.OnLastSetAllAiSenseEnable(deltaTime);
		}
		if (this.EnableAiSenseObjectMap.Count > 0)
		{
			foreach (KeyValuePair<AsyncAiSenseObject, bool> keyValuePair in this.EnableAiSenseObjectMap)
			{
				this.OnLastEnableAiSenseInternal(keyValuePair.Key, keyValuePair.Value);
			}
			this.EnableAiSenseObjectMap.Clear();
		}
	}

	// Token: 0x04001183 RID: 4483
	public int AiPerceptionDataHandle;

	// Token: 0x04001184 RID: 4484
	public readonly HashSet<int> SceneItems = new HashSet<int>();

	// Token: 0x04001185 RID: 4485
	private HashSet<int> NewShareAllyLink = new HashSet<int>();

	// Token: 0x04001186 RID: 4486
	private readonly HashSet<int> BeShared = new HashSet<int>();

	// Token: 0x04001187 RID: 4487
	private readonly HashSet<int> AddedBeShared = new HashSet<int>();

	// Token: 0x04001188 RID: 4488
	private readonly List<int> Pending = new List<int>();

	// Token: 0x04001189 RID: 4489
	private TMap<int, byte> EntitiesInSense;

	// Token: 0x0400118A RID: 4490
	private TMap<int, byte> EntitiesToAdd;

	// Token: 0x0400118B RID: 4491
	private TArray<int> EntitiesNotSense;

	// Token: 0x0400118C RID: 4492
	private TMap<int, double> EntitiesRemoveTime;

	// Token: 0x0400118D RID: 4493
	private readonly List<EntityHandle> TmpHandles = new List<EntityHandle>();

	// Token: 0x0400118E RID: 4494
	private ECamp Camp;

	// Token: 0x0400118F RID: 4495
	private readonly int EntityId;

	// Token: 0x04001190 RID: 4496
	private readonly List<AsyncAiSenseObject> AiSenseObjects = new List<AsyncAiSenseObject>();

	// Token: 0x04001191 RID: 4497
	private readonly Dictionary<int, AsyncAiSenseObject> ExtraAiSenseObjects = new Dictionary<int, AsyncAiSenseObject>();

	// Token: 0x04001192 RID: 4498
	private readonly float SquaredShareDist;

	// Token: 0x04001193 RID: 4499
	private bool ForbidAllSense;

	// Token: 0x04001194 RID: 4500
	private int OnLastDemotableTickHandle;

	// Token: 0x04001195 RID: 4501
	private readonly Dictionary<AsyncAiSenseObject, bool> EnableAiSenseObjectMap = new Dictionary<AsyncAiSenseObject, bool>();

	// Token: 0x04001196 RID: 4502
	private readonly AiController AiController;

	// Token: 0x04001197 RID: 4503
	public readonly AiSenseGroup? AiSenseGroup;

	// Token: 0x04001198 RID: 4504
	private int LastTickFrame = -1;

	// Token: 0x04001199 RID: 4505
	[Nullable(2)]
	private UTraceLineElement LineTrace;

	// Token: 0x0400119A RID: 4506
	[Nullable(2)]
	private FAIAsyncPerceptionCallback _asyncPerceptionCallback;

	// Token: 0x0400119B RID: 4507
	private static Stat AfterAsyncTaskStat;

	// Token: 0x0400119C RID: 4508
	private static Stat SenseActorStat;

	// Token: 0x0400119D RID: 4509
	private static Stat FindShareAllyStat;

	// Token: 0x0400119E RID: 4510
	private static Stat RefreshAllEnemiesStat;

	// Token: 0x0400119F RID: 4511
	private int DisableAllAiSenseFrame = -1;

	// Token: 0x040011A0 RID: 4512
	private int ClearFrame = -1;
}
