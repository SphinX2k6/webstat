using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using Aki.Protocol.BattleDefine;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Typing;

// Token: 0x02002E53 RID: 11859
[NullableContext(1)]
[Nullable(0)]
public class BaseBuffComponent : EntityComponent, IBuffComponent, IStaticVariableResetter
{
	// Token: 0x060184E1 RID: 99553 RVA: 0x006CA8CC File Offset: 0x006C8ACC
	static BaseBuffComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseBuffComponent.CreateStaticDefaultValue), new Action(BaseBuffComponent.ResetStaticDefaultValue));
	}

	// Token: 0x17002077 RID: 8311
	// (get) Token: 0x060184E2 RID: 99554 RVA: 0x006CAA5D File Offset: 0x006C8C5D
	public long CreatureDataId
	{
		get
		{
			return this.CreatureDataComponent.GetCreatureDataId();
		}
	}

	// Token: 0x17002078 RID: 8312
	// (get) Token: 0x060184E3 RID: 99555 RVA: 0x006CAA6A File Offset: 0x006C8C6A
	// (set) Token: 0x060184E4 RID: 99556 RVA: 0x006CAA72 File Offset: 0x006C8C72
	[Nullable(2)]
	public ExtraEffectManager BuffEffectManager { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x060184E5 RID: 99557 RVA: 0x006CAA7B File Offset: 0x006C8C7B
	public virtual string GetDebugName()
	{
		return "";
	}

	// Token: 0x060184E6 RID: 99558 RVA: 0x006CAA84 File Offset: 0x006C8C84
	protected override bool OnInit()
	{
		base.OnInit();
		this.CreatureDataComponent = base.Entity.GetComponent<CreatureDataComponent>();
		this.DeathComponent = base.Entity.GetComponent<BaseDeathComponent>();
		Singleton<EventSystem>.Instance.Add<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnAnyInstigatorDead));
		Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnAnyInstigatorRemoved));
		return true;
	}

	// Token: 0x060184E7 RID: 99559 RVA: 0x006CAAF4 File Offset: 0x006C8CF4
	protected override bool OnClear()
	{
		ControllerBase<BuffController>.Instance.UnregisterBuffComponent(this);
		ExtraEffectManager buffEffectManager = this.BuffEffectManager;
		if (buffEffectManager != null)
		{
			foreach (BuffEffect buffEffect in buffEffectManager.GetAllEffects())
			{
				if (buffEffect != null)
				{
					buffEffect.OnRemoved(true);
				}
			}
			buffEffectManager.Clear();
		}
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			foreach (ExtraEffectParameters extraEffectParameters in activeBuffInternal.Config.EffectInfos)
			{
				BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
				if (executionEffect != null)
				{
					executionEffect.OnBuffRemovedCallback(activeBuffInternal);
				}
			}
		}
		this.BuffContainer.Clear();
		this.BuffGarbageSet.Clear();
		this.PendingAddBuff.Clear();
		this.EffectTimeoutMap.Clear();
		this.EffectTargetTimeoutMap.Clear();
		this.TagInChanged.Clear();
		this.ConfigOverrideConditionListener.Clear();
		this.SeamlessTravelBuffCue = null;
		if (Singleton<EventSystem>.Instance.Has<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnAnyInstigatorDead)))
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnAnyInstigatorDead));
		}
		if (Singleton<EventSystem>.Instance.Has<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnAnyInstigatorRemoved)))
		{
			Singleton<EventSystem>.Instance.Remove<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnAnyInstigatorRemoved));
		}
		this.InstigatorEventListenDict.Clear();
		return true;
	}

	// Token: 0x060184E8 RID: 99560 RVA: 0x006CACC4 File Offset: 0x006C8EC4
	protected override void OnTick(float delta)
	{
		this.BuffLock = 0;
		this.TagInChanged.Clear();
	}

	// Token: 0x060184E9 RID: 99561 RVA: 0x006CACD8 File Offset: 0x006C8ED8
	protected virtual void InitBornBuff()
	{
	}

	// Token: 0x060184EA RID: 99562 RVA: 0x006CACDA File Offset: 0x006C8EDA
	[NullableContext(2)]
	protected virtual bool NeedBroadcastBuff(ActiveBuffInternal buff, bool fromServer = false)
	{
		return !fromServer && (buff == null || !buff.Config.OnlyLocalAdd) && this.HasBuffAuthority();
	}

	// Token: 0x060184EB RID: 99563 RVA: 0x006CACF9 File Offset: 0x006C8EF9
	public virtual bool HasBuffAuthority()
	{
		return false;
	}

	// Token: 0x060184EC RID: 99564 RVA: 0x006CACFC File Offset: 0x006C8EFC
	protected virtual bool NeedAddBuffOrder(long buffId)
	{
		return true;
	}

	// Token: 0x060184ED RID: 99565 RVA: 0x006CACFF File Offset: 0x006C8EFF
	[NullableContext(2)]
	public virtual Entity GetEntity()
	{
		return null;
	}

	// Token: 0x060184EE RID: 99566 RVA: 0x006CAD02 File Offset: 0x006C8F02
	[NullableContext(2)]
	public virtual Entity GetExactEntity()
	{
		return base.Entity;
	}

	// Token: 0x060184EF RID: 99567 RVA: 0x006CAD0A File Offset: 0x006C8F0A
	[NullableContext(2)]
	public virtual BaseAttributeComponent GetAttributeComponent()
	{
		return null;
	}

	// Token: 0x060184F0 RID: 99568 RVA: 0x006CAD0D File Offset: 0x006C8F0D
	[NullableContext(2)]
	public virtual BaseTagComponent GetTagComponent()
	{
		return null;
	}

	// Token: 0x060184F1 RID: 99569 RVA: 0x006CAD10 File Offset: 0x006C8F10
	[NullableContext(2)]
	public virtual BaseSkillComponent GetSkillComponent()
	{
		return null;
	}

	// Token: 0x060184F2 RID: 99570 RVA: 0x006CAD13 File Offset: 0x006C8F13
	[NullableContext(2)]
	public virtual CharacterPassiveSkillComponent GetPassiveSkillComponent()
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<CharacterPassiveSkillComponent>();
	}

	// Token: 0x060184F3 RID: 99571 RVA: 0x006CAD26 File Offset: 0x006C8F26
	[NullableContext(2)]
	public virtual BaseActorComponent GetActorComponent()
	{
		return null;
	}

	// Token: 0x060184F4 RID: 99572 RVA: 0x006CAD29 File Offset: 0x006C8F29
	[NullableContext(2)]
	public virtual BaseGameplayCueComponent GetCueComponent()
	{
		return null;
	}

	// Token: 0x060184F5 RID: 99573 RVA: 0x006CAD2C File Offset: 0x006C8F2C
	public virtual float GetTimeScale()
	{
		return 0f;
	}

	// Token: 0x060184F6 RID: 99574 RVA: 0x006CAD33 File Offset: 0x006C8F33
	public virtual float GetLogicTimeScale()
	{
		return 1f;
	}

	// Token: 0x060184F7 RID: 99575 RVA: 0x006CAD3C File Offset: 0x006C8F3C
	[NullableContext(2)]
	protected Entity ResolveBuffStackInstigator(long? instigatorId)
	{
		if (instigatorId != null)
		{
			long? num = instigatorId;
			long num2 = 0L;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(instigatorId.Value);
				WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
				if (worldEntity == null || !worldEntity.Valid || !worldEntity.IsInit)
				{
					return null;
				}
				return worldEntity;
			}
		}
		return null;
	}

	// Token: 0x060184F8 RID: 99576 RVA: 0x006CADA4 File Offset: 0x006C8FA4
	protected void EmitBuffStackInstigatorChanged(long buffId, int oldStack, int newStack, long? instigatorId)
	{
		Entity entity = this.ResolveBuffStackInstigator(instigatorId);
		if (entity == null)
		{
			return;
		}
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int, int, Entity, Entity>(entity, EAbilityEventName.BuffStackInstigatorChanged, buffId, buffId, oldStack, newStack, base.Entity, entity);
	}

	// Token: 0x060184F9 RID: 99577 RVA: 0x006CADD8 File Offset: 0x006C8FD8
	private void AddHandleMark<TKey>(Dictionary<TKey, HashSet<int>> dict, TKey key, int handle)
	{
		HashSet<int> hashSet;
		if (!dict.TryGetValue(key, out hashSet))
		{
			hashSet = new HashSet<int>();
			dict[key] = hashSet;
		}
		hashSet.Add(handle);
	}

	// Token: 0x060184FA RID: 99578 RVA: 0x006CAE08 File Offset: 0x006C9008
	public void AddEntityMark<TKey>(Dictionary<TKey, Dictionary<long, HashSet<int>>> dict, TKey key, long creatureDataId, int handle)
	{
		Dictionary<long, HashSet<int>> dictionary;
		if (!dict.TryGetValue(key, out dictionary))
		{
			dictionary = new Dictionary<long, HashSet<int>>();
			dict[key] = dictionary;
		}
		HashSet<int> hashSet;
		if (!dictionary.TryGetValue(creatureDataId, out hashSet))
		{
			hashSet = new HashSet<int>();
			dictionary[creatureDataId] = hashSet;
		}
		hashSet.Add(handle);
	}

	// Token: 0x060184FB RID: 99579 RVA: 0x006CAE50 File Offset: 0x006C9050
	private void RemoveHandleMark<TKey>(Dictionary<TKey, HashSet<int>> dict, TKey key, int handle)
	{
		HashSet<int> hashSet;
		if (dict.TryGetValue(key, out hashSet))
		{
			hashSet.Remove(handle);
			if (hashSet.Count <= 0)
			{
				dict.Remove(key);
			}
		}
	}

	// Token: 0x060184FC RID: 99580 RVA: 0x006CAE84 File Offset: 0x006C9084
	public void RemoveEntityMark<TKey>(Dictionary<TKey, Dictionary<long, HashSet<int>>> dict, TKey key, long creatureDataId, int handle)
	{
		Dictionary<long, HashSet<int>> dictionary;
		HashSet<int> hashSet;
		if (dict.TryGetValue(key, out dictionary) && dictionary.TryGetValue(creatureDataId, out hashSet))
		{
			hashSet.Remove(handle);
			if (hashSet.Count <= 0)
			{
				dictionary.Remove(creatureDataId);
				if (dictionary.Count <= 0)
				{
					dict.Remove(key);
				}
			}
		}
	}

	// Token: 0x060184FD RID: 99581 RVA: 0x006CAED4 File Offset: 0x006C90D4
	protected int[] GetInvolvedTags(BuffDefinition config)
	{
		List<int> list = new List<int>();
		if (config.ActivateTagRequirements != null)
		{
			list.AddRange(config.ActivateTagRequirements);
		}
		if (config.ActivateTagIgnores != null)
		{
			list.AddRange(config.ActivateTagIgnores);
		}
		if (config.RemoveTagExistAll != null)
		{
			list.AddRange(config.RemoveTagExistAll);
		}
		if (config.RemoveTagExistAny != null)
		{
			list.AddRange(config.RemoveTagExistAny);
		}
		if (config.RemoveTagIgnores != null)
		{
			list.AddRange(config.RemoveTagIgnores);
		}
		if (config.BuffAction != null)
		{
			foreach (TBuffAction tbuffAction in config.BuffAction)
			{
				EBuffActionType type = tbuffAction.Type;
				if (type - EBuffActionType.RemoveBuffWhenVictimHasSomeTag <= 7)
				{
					list.AddRange(tbuffAction.Tags);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060184FE RID: 99582 RVA: 0x006CAF90 File Offset: 0x006C9190
	protected long[] GetInvolvedBuffIds(BuffDefinition config)
	{
		List<long> list = new List<long>();
		if (config.BuffAction != null)
		{
			foreach (TBuffAction tbuffAction in config.BuffAction)
			{
				EBuffActionType type = tbuffAction.Type;
				if (type - EBuffActionType.RemoveBuffWhenVictimHasSomeBuff <= 7)
				{
					list.AddRange(tbuffAction.Buffs);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x060184FF RID: 99583 RVA: 0x006CAFE8 File Offset: 0x006C91E8
	protected int[] GetInvolvedInstigatorTags(BuffDefinition config)
	{
		List<int> list = new List<int>();
		if (config.BuffAction != null)
		{
			foreach (TBuffAction tbuffAction in config.BuffAction)
			{
				EBuffActionType type = tbuffAction.Type;
				if (type - EBuffActionType.RemoveBuffWhenInstigatorHasSomeTag <= 7)
				{
					list.AddRange(tbuffAction.Tags);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06018500 RID: 99584 RVA: 0x006CB040 File Offset: 0x006C9240
	protected long[] GetInvolvedInstigatorBuffIds(BuffDefinition config)
	{
		List<long> list = new List<long>();
		if (config.BuffAction != null)
		{
			foreach (TBuffAction tbuffAction in config.BuffAction)
			{
				EBuffActionType type = tbuffAction.Type;
				if (type - EBuffActionType.RemoveBuffWhenInstigatorHasSomeBuff <= 7)
				{
					list.AddRange(tbuffAction.Buffs);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06018501 RID: 99585 RVA: 0x006CB098 File Offset: 0x006C9298
	protected List<TBuffAction> GetInstigatorEventActions(BuffDefinition config)
	{
		List<TBuffAction> list = new List<TBuffAction>();
		if (config.BuffAction != null)
		{
			foreach (TBuffAction tbuffAction in config.BuffAction)
			{
				if (tbuffAction.Type == EBuffActionType.RemoveBuffWhenInstigatorDeadOrRemoved)
				{
					list.Add(tbuffAction);
				}
			}
		}
		return list;
	}

	// Token: 0x06018502 RID: 99586 RVA: 0x006CB0E0 File Offset: 0x006C92E0
	protected void RegisterInstigatorEventListener(ActiveBuffInternal buff)
	{
		List<TBuffAction> instigatorEventActions = this.GetInstigatorEventActions(buff.Config);
		if (instigatorEventActions.Count == 0)
		{
			return;
		}
		Entity instigator = buff.GetInstigator();
		if (instigator == null)
		{
			return;
		}
		int id = instigator.Id;
		int handle = buff.Handle;
		foreach (TBuffAction tbuffAction in instigatorEventActions)
		{
			if (tbuffAction.CustomParams != null)
			{
				foreach (int key in tbuffAction.CustomParams)
				{
					Dictionary<int, List<int>> dictionary;
					if (!this.InstigatorEventListenDict.TryGetValue(id, out dictionary))
					{
						dictionary = new Dictionary<int, List<int>>();
						this.InstigatorEventListenDict[id] = dictionary;
					}
					List<int> list;
					if (!dictionary.TryGetValue(key, out list))
					{
						list = new List<int>();
						dictionary[key] = list;
					}
					list.Add(handle);
				}
			}
		}
	}

	// Token: 0x06018503 RID: 99587 RVA: 0x006CB1D8 File Offset: 0x006C93D8
	protected void UnregisterInstigatorEventListener(ActiveBuffInternal buff)
	{
		Entity instigator = buff.GetInstigator();
		if (instigator == null)
		{
			return;
		}
		int id = instigator.Id;
		Dictionary<int, List<int>> dictionary;
		if (!this.InstigatorEventListenDict.TryGetValue(id, out dictionary))
		{
			return;
		}
		int handle = buff.Handle;
		foreach (int key in dictionary.Keys.ToList<int>())
		{
			List<int> list = dictionary[key];
			list.Remove(handle);
			if (list.Count == 0)
			{
				dictionary.Remove(key);
			}
		}
		if (dictionary.Count == 0)
		{
			this.InstigatorEventListenDict.Remove(id);
		}
	}

	// Token: 0x06018504 RID: 99588 RVA: 0x006CB28C File Offset: 0x006C948C
	private void OnAnyInstigatorDead(int charId)
	{
		Dictionary<int, List<int>> dictionary;
		if (!this.InstigatorEventListenDict.TryGetValue(charId, out dictionary) || dictionary.Count == 0)
		{
			return;
		}
		List<int> source;
		if (dictionary.TryGetValue(0, out source))
		{
			foreach (int handle in source.ToList<int>())
			{
				if (this.GetBuffByHandle(handle) != null && this.HasBuffAuthority())
				{
					this.RemoveBuffByHandle(handle, -1, "因为创建者死亡触发BuffAction", null, null, null);
				}
			}
		}
	}

	// Token: 0x06018505 RID: 99589 RVA: 0x006CB340 File Offset: 0x006C9540
	private void OnAnyInstigatorRemoved(ERemoveEntityType removeType, EntityHandle handle)
	{
		EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(handle.Id);
		WorldEntity worldEntity = (entityById != null) ? entityById.Entity : null;
		if (worldEntity == null)
		{
			return;
		}
		int id = worldEntity.Id;
		Dictionary<int, List<int>> dictionary;
		if (!this.InstigatorEventListenDict.TryGetValue(id, out dictionary) || dictionary.Count == 0)
		{
			return;
		}
		List<int> source;
		if (dictionary.TryGetValue(1, out source))
		{
			foreach (int handle2 in source.ToList<int>())
			{
				if (this.GetBuffByHandle(handle2) != null && this.HasBuffAuthority())
				{
					this.RemoveBuffByHandle(handle2, -1, "因为创建者移出队伍触发BuffAction", null, null, null);
				}
			}
		}
	}

	// Token: 0x06018506 RID: 99590 RVA: 0x006CB41C File Offset: 0x006C961C
	protected void MarkListenerBuff(ActiveBuffInternal buff)
	{
		if (!this.NeedCheck(buff.Config))
		{
			return;
		}
		BuffDefinition config = buff.Config;
		if (config == null)
		{
			return;
		}
		int handle = buff.Handle;
		foreach (int key in this.GetInvolvedTags(config))
		{
			this.AddHandleMark<int>(this.TagListenerDict, key, handle);
		}
		foreach (long key2 in this.GetInvolvedBuffIds(config))
		{
			this.AddHandleMark<long>(this.BuffListenerDict, key2, handle);
		}
		if (config.ImmuneTags != null)
		{
			foreach (int key3 in config.ImmuneTags)
			{
				this.AddHandleMark<int>(this.TagImmuneListenerDict, key3, handle);
			}
		}
		CharacterBuffComponent instigatorBuffComponent = buff.GetInstigatorBuffComponent();
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		long? num = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null;
		if (instigatorBuffComponent != null && num != null)
		{
			foreach (int key4 in this.GetInvolvedInstigatorTags(config))
			{
				instigatorBuffComponent.AddEntityMark<int>(instigatorBuffComponent.VictimTagListenerDict, key4, num.Value, handle);
			}
			foreach (long key5 in this.GetInvolvedInstigatorBuffIds(config))
			{
				instigatorBuffComponent.AddEntityMark<long>(instigatorBuffComponent.VictimBuffListenerDict, key5, num.Value, handle);
			}
		}
		this.RegisterInstigatorEventListener(buff);
	}

	// Token: 0x06018507 RID: 99591 RVA: 0x006CB594 File Offset: 0x006C9794
	protected void RemoveListenerBuff(ActiveBuffInternal buff)
	{
		if (!this.NeedCheck(buff.Config))
		{
			return;
		}
		BuffDefinition config = buff.Config;
		if (config == null)
		{
			return;
		}
		int handle = buff.Handle;
		foreach (int key in this.GetInvolvedTags(config))
		{
			this.RemoveHandleMark<int>(this.TagListenerDict, key, handle);
		}
		foreach (long key2 in this.GetInvolvedBuffIds(config))
		{
			this.RemoveHandleMark<long>(this.BuffListenerDict, key2, handle);
		}
		if (config.ImmuneTags != null)
		{
			foreach (int key3 in config.ImmuneTags)
			{
				this.RemoveHandleMark<int>(this.TagImmuneListenerDict, key3, handle);
			}
		}
		CharacterBuffComponent instigatorBuffComponent = buff.GetInstigatorBuffComponent();
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		long? num = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetCreatureDataId()) : null;
		if (instigatorBuffComponent != null && num != null)
		{
			foreach (int key4 in this.GetInvolvedInstigatorTags(config))
			{
				instigatorBuffComponent.RemoveEntityMark<int>(instigatorBuffComponent.VictimTagListenerDict, key4, num.Value, handle);
			}
			foreach (long key5 in this.GetInvolvedInstigatorBuffIds(config))
			{
				instigatorBuffComponent.RemoveEntityMark<long>(instigatorBuffComponent.VictimBuffListenerDict, key5, num.Value, handle);
			}
		}
		this.UnregisterInstigatorEventListener(buff);
	}

	// Token: 0x06018508 RID: 99592 RVA: 0x006CB70C File Offset: 0x006C990C
	protected void CheckWhenTagChanged(int tagId)
	{
		int i = this.BuffLock;
		this.BuffLock = i + 1;
		HashSet<int> source;
		if (this.TagListenerDict.TryGetValue(tagId, out source))
		{
			string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
			foreach (int handle in source.ToArray<int>())
			{
				IActiveBuff buffByHandle = this.GetBuffByHandle(handle);
				if (buffByHandle != null && this.CheckRemove(buffByHandle.Config, buffByHandle.GetInstigator()))
				{
					this.RemoveBuffInner(handle, -1, true, "因为tag " + nameByTagId + "的变化触发", null, null, null);
				}
			}
			foreach (int handle2 in source.ToArray<int>())
			{
				IActiveBuff buffByHandle2 = this.GetBuffByHandle(handle2);
				if (buffByHandle2 == null)
				{
					this.RemoveHandleMark<int>(this.TagListenerDict, tagId, handle2);
				}
				else
				{
					bool flag = this.CheckActivate(buffByHandle2.Config, buffByHandle2.GetInstigator());
					if (flag != buffByHandle2.IsActive())
					{
						this.OnBuffActiveChanged(buffByHandle2 as ActiveBuffInternal, flag);
					}
				}
			}
		}
		Dictionary<long, HashSet<int>> source2;
		if (this.VictimTagListenerDict.TryGetValue(tagId, out source2))
		{
			string nameByTagId2 = GameplayTagUtils.GetNameByTagId(tagId);
			foreach (KeyValuePair<long, HashSet<int>> keyValuePair in source2.ToArray<KeyValuePair<long, HashSet<int>>>())
			{
				long num;
				HashSet<int> source3;
				keyValuePair.Deconstruct(out num, out source3);
				long creatureDataId = num;
				foreach (int handle3 in source3.ToArray<int>())
				{
					EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
					BaseBuffComponent baseBuffComponent;
					if (entity == null)
					{
						baseBuffComponent = null;
					}
					else
					{
						WorldEntity entity2 = entity.Entity;
						baseBuffComponent = ((entity2 != null) ? entity2.GetComponent<BaseBuffComponent>() : null);
					}
					BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
					IActiveBuff activeBuff = (baseBuffComponent2 != null) ? baseBuffComponent2.GetBuffByHandle(handle3) : null;
					if (baseBuffComponent2 != null && activeBuff != null && baseBuffComponent2.CheckRemove(activeBuff.Config, activeBuff.GetInstigator()))
					{
						baseBuffComponent2.RemoveBuffInner(handle3, -1, true, "因为施加者的tag " + nameByTagId2 + "的变化触发", null, null, null);
					}
				}
			}
			foreach (KeyValuePair<long, HashSet<int>> keyValuePair in source2.ToArray<KeyValuePair<long, HashSet<int>>>())
			{
				long num;
				HashSet<int> source3;
				keyValuePair.Deconstruct(out num, out source3);
				long creatureDataId2 = num;
				foreach (int handle4 in source3.ToArray<int>())
				{
					EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId2);
					BaseBuffComponent baseBuffComponent3;
					if (entity3 == null)
					{
						baseBuffComponent3 = null;
					}
					else
					{
						WorldEntity entity4 = entity3.Entity;
						baseBuffComponent3 = ((entity4 != null) ? entity4.GetComponent<BaseBuffComponent>() : null);
					}
					BaseBuffComponent baseBuffComponent4 = baseBuffComponent3;
					IActiveBuff activeBuff2 = (baseBuffComponent4 != null) ? baseBuffComponent4.GetBuffByHandle(handle4) : null;
					if (baseBuffComponent4 == null || activeBuff2 == null)
					{
						this.RemoveEntityMark<int>(this.VictimTagListenerDict, tagId, creatureDataId2, handle4);
					}
					else
					{
						bool flag2 = baseBuffComponent4.CheckActivate(activeBuff2.Config, activeBuff2.GetInstigator());
						if (flag2 != activeBuff2.IsActive() && baseBuffComponent4 != null)
						{
							baseBuffComponent4.OnBuffActiveChanged(activeBuff2 as ActiveBuffInternal, flag2);
						}
					}
				}
			}
		}
		i = this.BuffLock;
		this.BuffLock = i - 1;
	}

	// Token: 0x06018509 RID: 99593 RVA: 0x006CBA30 File Offset: 0x006C9C30
	protected void CheckWhenBuffChanged(long buffId)
	{
		HashSet<int> source;
		if (this.BuffListenerDict.TryGetValue(buffId, out source))
		{
			int i = this.BuffLock;
			this.BuffLock = i + 1;
			foreach (int num in source.ToArray<int>())
			{
				IActiveBuff buffByHandle = this.GetBuffByHandle(num);
				if (buffByHandle != null && this.CheckRemove(buffByHandle.Config, buffByHandle.GetInstigator()))
				{
					int handle = num;
					int removeStackCount = -1;
					bool isPrematureRemoval = true;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
					defaultInterpolatedStringHandler.AppendLiteral("因为buff ");
					defaultInterpolatedStringHandler.AppendFormatted<long>(buffId);
					defaultInterpolatedStringHandler.AppendLiteral("的变化触发");
					this.RemoveBuffInner(handle, removeStackCount, isPrematureRemoval, defaultInterpolatedStringHandler.ToStringAndClear(), null, null, null);
				}
			}
			foreach (int handle2 in source.ToArray<int>())
			{
				IActiveBuff buffByHandle2 = this.GetBuffByHandle(handle2);
				if (buffByHandle2 == null)
				{
					this.RemoveHandleMark<long>(this.BuffListenerDict, buffId, handle2);
				}
				else
				{
					bool flag = this.CheckActivate(buffByHandle2.Config, buffByHandle2.GetInstigator());
					if (flag != buffByHandle2.IsActive())
					{
						this.OnBuffActiveChanged(buffByHandle2 as ActiveBuffInternal, flag);
					}
				}
			}
			i = this.BuffLock;
			this.BuffLock = i - 1;
		}
		Dictionary<long, HashSet<int>> source2;
		if (this.VictimBuffListenerDict.TryGetValue(buffId, out source2))
		{
			int i = this.BuffLock;
			this.BuffLock = i + 1;
			foreach (KeyValuePair<long, HashSet<int>> keyValuePair in source2.ToArray<KeyValuePair<long, HashSet<int>>>())
			{
				long num2;
				HashSet<int> source3;
				keyValuePair.Deconstruct(out num2, out source3);
				long creatureDataId = num2;
				foreach (int num3 in source3.ToArray<int>())
				{
					EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
					BaseBuffComponent baseBuffComponent;
					if (entity == null)
					{
						baseBuffComponent = null;
					}
					else
					{
						WorldEntity entity2 = entity.Entity;
						baseBuffComponent = ((entity2 != null) ? entity2.GetComponent<BaseBuffComponent>() : null);
					}
					BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
					IActiveBuff activeBuff = (baseBuffComponent2 != null) ? baseBuffComponent2.GetBuffByHandle(num3) : null;
					if (baseBuffComponent2 != null && activeBuff != null && baseBuffComponent2.CheckRemove(activeBuff.Config, activeBuff.GetInstigator()))
					{
						BaseBuffComponent baseBuffComponent3 = baseBuffComponent2;
						int handle3 = num3;
						int removeStackCount2 = -1;
						bool isPrematureRemoval2 = true;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
						defaultInterpolatedStringHandler.AppendLiteral("因为施加者的buff ");
						defaultInterpolatedStringHandler.AppendFormatted<long>(buffId);
						defaultInterpolatedStringHandler.AppendLiteral("的变化触发");
						baseBuffComponent3.RemoveBuffInner(handle3, removeStackCount2, isPrematureRemoval2, defaultInterpolatedStringHandler.ToStringAndClear(), null, null, null);
					}
				}
			}
			foreach (KeyValuePair<long, HashSet<int>> keyValuePair in source2.ToArray<KeyValuePair<long, HashSet<int>>>())
			{
				long num2;
				HashSet<int> source3;
				keyValuePair.Deconstruct(out num2, out source3);
				long creatureDataId2 = num2;
				foreach (int handle4 in source3.ToArray<int>())
				{
					EntityHandle entity3 = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId2);
					BaseBuffComponent baseBuffComponent4;
					if (entity3 == null)
					{
						baseBuffComponent4 = null;
					}
					else
					{
						WorldEntity entity4 = entity3.Entity;
						baseBuffComponent4 = ((entity4 != null) ? entity4.GetComponent<BaseBuffComponent>() : null);
					}
					BaseBuffComponent baseBuffComponent5 = baseBuffComponent4;
					IActiveBuff activeBuff2 = (baseBuffComponent5 != null) ? baseBuffComponent5.GetBuffByHandle(handle4) : null;
					if (baseBuffComponent5 == null || activeBuff2 == null)
					{
						this.RemoveEntityMark<long>(this.VictimBuffListenerDict, buffId, creatureDataId2, handle4);
					}
					else
					{
						bool flag2 = baseBuffComponent5.CheckActivate(activeBuff2.Config, activeBuff2.GetInstigator());
						if (flag2 != activeBuff2.IsActive() && baseBuffComponent5 != null)
						{
							baseBuffComponent5.OnBuffActiveChanged(activeBuff2 as ActiveBuffInternal, flag2);
						}
					}
				}
			}
			i = this.BuffLock;
			this.BuffLock = i - 1;
		}
	}

	// Token: 0x0601850A RID: 99594 RVA: 0x006CBDA0 File Offset: 0x006C9FA0
	protected void UnregisterConfigOverrideListener(ActiveBuffInternal buff)
	{
		int? configOverrideListenerId = buff.GetConfigOverrideListenerId();
		if (configOverrideListenerId != null)
		{
			this.ConfigOverrideConditionListener.RemoveListener(configOverrideListenerId.Value);
		}
	}

	// Token: 0x0601850B RID: 99595 RVA: 0x006CBDD0 File Offset: 0x006C9FD0
	public void AddBuffRoutineExpirationLock(long buffId)
	{
		int valueOrDefault = this.BuffRoutineExpirationLock.GetValueOrDefault(buffId, 0);
		this.BuffRoutineExpirationLock[buffId] = valueOrDefault + 1;
	}

	// Token: 0x0601850C RID: 99596 RVA: 0x006CBDFC File Offset: 0x006C9FFC
	public void RemoveBuffRoutineExpirationLock(long buffId)
	{
		int valueOrDefault = this.BuffRoutineExpirationLock.GetValueOrDefault(buffId, 0);
		if (valueOrDefault <= 1)
		{
			this.BuffRoutineExpirationLock.Remove(buffId);
			return;
		}
		this.BuffRoutineExpirationLock[buffId] = valueOrDefault - 1;
	}

	// Token: 0x0601850D RID: 99597 RVA: 0x006CBE38 File Offset: 0x006CA038
	public virtual bool HasBuffRoutineExpirationLock(long buffId)
	{
		return this.BuffRoutineExpirationLock.GetValueOrDefault(buffId, 0) > 0;
	}

	// Token: 0x0601850E RID: 99598 RVA: 0x006CBE4A File Offset: 0x006CA04A
	public virtual bool IsPaused()
	{
		return false;
	}

	// Token: 0x0601850F RID: 99599 RVA: 0x006CBE50 File Offset: 0x006CA050
	public void RefreshTimeScale()
	{
		float timeScale = this.GetTimeScale();
		bool forcePaused = this.IsPaused();
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			activeBuffInternal.OnTimeScaleChanged(timeScale, forcePaused);
		}
	}

	// Token: 0x06018510 RID: 99600 RVA: 0x006CBEB8 File Offset: 0x006CA0B8
	protected override void OnChangeTimeDilation(float timeDilation)
	{
		this.RefreshTimeScale();
	}

	// Token: 0x06018511 RID: 99601 RVA: 0x006CBEC0 File Offset: 0x006CA0C0
	public bool NeedCheck(BuffDefinition config)
	{
		return config != null && (config.Id.GetValueOrDefault() == -3L || this.HasBuffAuthority());
	}

	// Token: 0x06018512 RID: 99602 RVA: 0x006CBEE0 File Offset: 0x006CA0E0
	protected virtual bool CheckAdd(BuffDefinition config, long instigatorId, bool fromServer)
	{
		if (fromServer)
		{
			return true;
		}
		if (!fromServer && this.NeedCheck(config))
		{
			BaseDeathComponent deathComponent = this.DeathComponent;
			if (deathComponent != null && deathComponent.IsDead() && config.EffectInfos != null)
			{
				using (List<ExtraEffectParameters>.Enumerator enumerator = config.EffectInfos.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.ExtraEffectId == EExtraEffectId.Frozen)
						{
							return false;
						}
					}
				}
			}
			BaseTagComponent tagComponent = this.GetTagComponent();
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(instigatorId);
			WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
			BaseTagComponent baseTagComponent = (worldEntity != null) ? worldEntity.GetComponent<BaseTagComponent>() : null;
			if (config.Probability < 10000 && RandomSystem.GetRandomPercent() > (float)config.Probability)
			{
				return false;
			}
			if (tagComponent == null)
			{
				return false;
			}
			if (config.AddTagIgnores != null)
			{
				foreach (int tagId in config.AddTagIgnores)
				{
					if (tagComponent.HasTag(tagId))
					{
						return false;
					}
				}
			}
			if (config.AddTagRequirements != null)
			{
				foreach (int tagId2 in config.AddTagRequirements)
				{
					if (!tagComponent.HasTag(tagId2))
					{
						return false;
					}
				}
			}
			if (this.CheckRemove(config, worldEntity))
			{
				return false;
			}
			if (config.RemoveTagIgnores != null && config.RemoveTagIgnores.Length != 0)
			{
				bool flag = false;
				foreach (int tagId3 in config.RemoveTagIgnores)
				{
					if (tagComponent.HasTag(tagId3))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			int[] array2 = config.RemoveTagExistAll ?? Array.Empty<int>();
			if (array2.Length != 0)
			{
				bool flag2 = true;
				foreach (int tagId4 in array2)
				{
					if (!tagComponent.HasTag(tagId4))
					{
						flag2 = false;
						break;
					}
				}
				if (flag2)
				{
					return false;
				}
			}
			int[] array3 = config.RemoveTagExistAny ?? Array.Empty<int>();
			if (array3.Length != 0)
			{
				foreach (int tagId5 in array3)
				{
					if (tagComponent.HasTag(tagId5))
					{
						return false;
					}
				}
			}
			if (baseTagComponent != null)
			{
				if (config.AddInstigatorTagIgnores != null)
				{
					foreach (int tagId6 in config.AddInstigatorTagIgnores)
					{
						if (baseTagComponent.HasTag(tagId6))
						{
							return false;
						}
					}
				}
				if (config.AddInstigatorTagRequirements != null)
				{
					foreach (int tagId7 in config.AddInstigatorTagRequirements)
					{
						if (!baseTagComponent.HasTag(tagId7))
						{
							return false;
						}
					}
				}
			}
		}
		return !this.CheckImmune(config);
	}

	// Token: 0x06018513 RID: 99603 RVA: 0x006CC18C File Offset: 0x006CA38C
	public virtual bool CheckImmune(BuffDefinition config)
	{
		foreach (int num in this.TagImmuneListenerDict.Keys)
		{
			bool flag = false;
			if (config.GrantedTags != null)
			{
				int[] grantedTags = config.GrantedTags;
				for (int i = 0; i < grantedTags.Length; i++)
				{
					if (GameplayTagUtils.IsChildTag(grantedTags[i], num))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				foreach (int key in this.TagImmuneListenerDict[num])
				{
					ActiveBuffInternal valueOrDefault = this.BuffContainer.GetValueOrDefault(key);
					BuffDefinition buffDefinition = (valueOrDefault != null) ? valueOrDefault.Config : null;
					if (buffDefinition != null && valueOrDefault != null && valueOrDefault.IsValid() && valueOrDefault.IsActive() && config.GrantedTags != null)
					{
						bool flag2 = GameplayTagUtils.HasAll(config.GrantedTags, buffDefinition.ImmuneTags) && !GameplayTagUtils.HasAny(config.GrantedTags, buffDefinition.ImmuneTagIgnores);
						if (valueOrDefault != null && valueOrDefault.IsActive() && flag2)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06018514 RID: 99604 RVA: 0x006CC308 File Offset: 0x006CA508
	protected bool HasTagRemoveCheck(BuffDefinition config)
	{
		int[] removeTagIgnores = config.RemoveTagIgnores;
		if (((removeTagIgnores != null) ? removeTagIgnores.Length : 0) <= 0)
		{
			int[] removeTagExistAll = config.RemoveTagExistAll;
			if (((removeTagExistAll != null) ? removeTagExistAll.Length : 0) <= 0)
			{
				int[] removeTagExistAny = config.RemoveTagExistAny;
				if (((removeTagExistAny != null) ? removeTagExistAny.Length : 0) <= 0)
				{
					if (config.BuffAction != null)
					{
						foreach (TBuffAction tbuffAction in config.BuffAction)
						{
							if (BuffTypesHelper.actionTagRemove.Contains(tbuffAction.Type))
							{
								return true;
							}
						}
					}
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06018515 RID: 99605 RVA: 0x006CC384 File Offset: 0x006CA584
	protected bool CheckRemoveAction(BuffDefinition config, [Nullable(2)] Entity instigator)
	{
		if (config.BuffAction == null)
		{
			return false;
		}
		BaseTagComponent baseTagComponent = (instigator != null) ? instigator.GetComponent<BaseTagComponent>() : null;
		BaseBuffComponent baseBuffComponent = (instigator != null) ? instigator.GetComponent<BaseBuffComponent>() : null;
		BaseTagComponent tagComponent = this.GetTagComponent();
		foreach (TBuffAction tbuffAction in config.BuffAction)
		{
			EBuffActionType type = tbuffAction.Type;
			switch (type)
			{
			case EBuffActionType.RemoveBuffWhenInstigatorHasSomeTag:
				if (baseTagComponent != null)
				{
					foreach (int tagId in tbuffAction.Tags)
					{
						if (baseTagComponent.HasTag(tagId))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorHasEveryTag:
				if (baseTagComponent != null)
				{
					bool flag = true;
					foreach (int tagId2 in tbuffAction.Tags)
					{
						if (!baseTagComponent.HasTag(tagId2))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return true;
					}
				}
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorNotHasSomeTag:
				if (baseTagComponent != null)
				{
					foreach (int tagId3 in tbuffAction.Tags)
					{
						if (!baseTagComponent.HasTag(tagId3))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorNotHasEveryTag:
				if (baseTagComponent != null)
				{
					bool flag2 = true;
					foreach (int tagId4 in tbuffAction.Tags)
					{
						if (baseTagComponent.HasTag(tagId4))
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						return true;
					}
				}
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorHasSomeTag:
			case EBuffActionType.InactiveBuffWhenInstigatorHasEveryTag:
			case EBuffActionType.InactiveBuffWhenInstigatorNotHasSomeTag:
			case EBuffActionType.InactiveBuffWhenInstigatorNotHasEveryTag:
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorHasSomeBuff:
				if (baseBuffComponent != null)
				{
					foreach (long buffId in tbuffAction.Buffs)
					{
						if (baseBuffComponent.HasActiveBuff(buffId))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorHasEveryBuff:
				if (baseBuffComponent != null)
				{
					bool flag3 = true;
					foreach (long buffId2 in tbuffAction.Buffs)
					{
						if (!baseBuffComponent.HasActiveBuff(buffId2))
						{
							flag3 = false;
							break;
						}
					}
					if (flag3)
					{
						return true;
					}
				}
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorNotHasSomeBuff:
				if (baseBuffComponent != null)
				{
					foreach (long buffId3 in tbuffAction.Buffs)
					{
						if (!baseBuffComponent.HasActiveBuff(buffId3))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorNotHasEveryBuff:
				if (baseBuffComponent != null)
				{
					bool flag4 = true;
					foreach (long buffId4 in tbuffAction.Buffs)
					{
						if (baseBuffComponent.HasActiveBuff(buffId4))
						{
							flag4 = false;
							break;
						}
					}
					if (flag4)
					{
						return true;
					}
				}
				break;
			default:
				switch (type)
				{
				case EBuffActionType.RemoveBuffWhenVictimHasSomeTag:
					if (tagComponent != null)
					{
						foreach (int tagId5 in tbuffAction.Tags)
						{
							if (tagComponent.HasTag(tagId5))
							{
								return true;
							}
						}
					}
					break;
				case EBuffActionType.RemoveBuffWhenVictimHasEveryTag:
					if (tagComponent != null)
					{
						bool flag5 = true;
						foreach (int tagId6 in tbuffAction.Tags)
						{
							if (!tagComponent.HasTag(tagId6))
							{
								flag5 = false;
								break;
							}
						}
						if (flag5)
						{
							return true;
						}
					}
					break;
				case EBuffActionType.RemoveBuffWhenVictimNotHasSomeTag:
					if (tagComponent != null)
					{
						foreach (int tagId7 in tbuffAction.Tags)
						{
							if (!tagComponent.HasTag(tagId7))
							{
								return true;
							}
						}
					}
					break;
				case EBuffActionType.RemoveBuffWhenVictimNotHasEveryTag:
					if (tagComponent != null)
					{
						bool flag6 = true;
						foreach (int tagId8 in tbuffAction.Tags)
						{
							if (tagComponent.HasTag(tagId8))
							{
								flag6 = false;
								break;
							}
						}
						if (flag6)
						{
							return true;
						}
					}
					break;
				case EBuffActionType.RemoveBuffWhenVictimHasSomeBuff:
					foreach (long buffId5 in tbuffAction.Buffs)
					{
						if (this.HasActiveBuff(buffId5))
						{
							return true;
						}
					}
					break;
				case EBuffActionType.RemoveBuffWhenVictimHasEveryBuff:
				{
					bool flag7 = true;
					foreach (long buffId6 in tbuffAction.Buffs)
					{
						if (!this.HasActiveBuff(buffId6))
						{
							flag7 = false;
							break;
						}
					}
					if (flag7)
					{
						return true;
					}
					break;
				}
				case EBuffActionType.RemoveBuffWhenVictimNotHasSomeBuff:
					foreach (long buffId7 in tbuffAction.Buffs)
					{
						if (!this.HasActiveBuff(buffId7))
						{
							return true;
						}
					}
					break;
				case EBuffActionType.RemoveBuffWhenVictimNotHasEveryBuff:
				{
					bool flag8 = true;
					foreach (long buffId8 in tbuffAction.Buffs)
					{
						if (this.HasActiveBuff(buffId8))
						{
							flag8 = false;
							break;
						}
					}
					if (flag8)
					{
						return true;
					}
					break;
				}
				}
				break;
			}
		}
		return false;
	}

	// Token: 0x06018516 RID: 99606 RVA: 0x006CC830 File Offset: 0x006CAA30
	protected bool CheckInactivateAction(BuffDefinition config, [Nullable(2)] Entity instigator)
	{
		if (config.BuffAction == null)
		{
			return false;
		}
		BaseTagComponent baseTagComponent = (instigator != null) ? instigator.GetComponent<BaseTagComponent>() : null;
		BaseBuffComponent baseBuffComponent = (instigator != null) ? instigator.GetComponent<BaseBuffComponent>() : null;
		BaseTagComponent tagComponent = this.GetTagComponent();
		foreach (TBuffAction tbuffAction in config.BuffAction)
		{
			EBuffActionType type = tbuffAction.Type;
			switch (type)
			{
			case EBuffActionType.InactiveBuffWhenInstigatorHasSomeTag:
				if (baseTagComponent != null)
				{
					foreach (int tagId in tbuffAction.Tags)
					{
						if (baseTagComponent.HasTag(tagId))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorHasEveryTag:
				if (baseTagComponent != null)
				{
					bool flag = true;
					foreach (int tagId2 in tbuffAction.Tags)
					{
						if (!baseTagComponent.HasTag(tagId2))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return true;
					}
				}
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorNotHasSomeTag:
				if (baseTagComponent != null)
				{
					foreach (int tagId3 in tbuffAction.Tags)
					{
						if (!baseTagComponent.HasTag(tagId3))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorNotHasEveryTag:
				if (baseTagComponent != null)
				{
					bool flag2 = true;
					foreach (int tagId4 in tbuffAction.Tags)
					{
						if (baseTagComponent.HasTag(tagId4))
						{
							flag2 = false;
							break;
						}
					}
					if (flag2)
					{
						return true;
					}
				}
				break;
			case EBuffActionType.RemoveBuffWhenInstigatorHasSomeBuff:
			case EBuffActionType.RemoveBuffWhenInstigatorHasEveryBuff:
			case EBuffActionType.RemoveBuffWhenInstigatorNotHasSomeBuff:
			case EBuffActionType.RemoveBuffWhenInstigatorNotHasEveryBuff:
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorHasSomeBuff:
				if (baseBuffComponent != null)
				{
					foreach (long buffId in tbuffAction.Buffs)
					{
						if (baseBuffComponent.HasActiveBuff(buffId))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorHasEveryBuff:
				if (baseBuffComponent != null)
				{
					bool flag3 = true;
					foreach (long buffId2 in tbuffAction.Buffs)
					{
						if (!baseBuffComponent.HasActiveBuff(buffId2))
						{
							flag3 = false;
							break;
						}
					}
					if (flag3)
					{
						return true;
					}
				}
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorNotHasSomeBuff:
				if (baseBuffComponent != null)
				{
					foreach (long buffId3 in tbuffAction.Buffs)
					{
						if (!baseBuffComponent.HasActiveBuff(buffId3))
						{
							return true;
						}
					}
				}
				break;
			case EBuffActionType.InactiveBuffWhenInstigatorNotHasEveryBuff:
				if (baseBuffComponent != null)
				{
					bool flag4 = true;
					foreach (long buffId4 in tbuffAction.Buffs)
					{
						if (baseBuffComponent.HasActiveBuff(buffId4))
						{
							flag4 = false;
							break;
						}
					}
					if (flag4)
					{
						return true;
					}
				}
				break;
			default:
				switch (type)
				{
				case EBuffActionType.InactiveBuffWhenVictimHasSomeTag:
					if (tagComponent != null)
					{
						foreach (int tagId5 in tbuffAction.Tags)
						{
							if (tagComponent.HasTag(tagId5))
							{
								return true;
							}
						}
					}
					break;
				case EBuffActionType.InactiveBuffWhenVictimHasEveryTag:
					if (tagComponent != null)
					{
						bool flag5 = true;
						foreach (int tagId6 in tbuffAction.Tags)
						{
							if (!tagComponent.HasTag(tagId6))
							{
								flag5 = false;
								break;
							}
						}
						if (flag5)
						{
							return true;
						}
					}
					break;
				case EBuffActionType.InactiveBuffWhenVictimNotHasSomeTag:
					if (tagComponent != null)
					{
						foreach (int tagId7 in tbuffAction.Tags)
						{
							if (!tagComponent.HasTag(tagId7))
							{
								return true;
							}
						}
					}
					break;
				case EBuffActionType.InactiveBuffWhenVictimNotHasEveryTag:
					if (tagComponent != null)
					{
						bool flag6 = true;
						foreach (int tagId8 in tbuffAction.Tags)
						{
							if (tagComponent.HasTag(tagId8))
							{
								flag6 = false;
								break;
							}
						}
						if (flag6)
						{
							return true;
						}
					}
					break;
				case EBuffActionType.InactiveBuffWhenVictimHasSomeBuff:
					foreach (long buffId5 in tbuffAction.Buffs)
					{
						if (this.HasActiveBuff(buffId5))
						{
							return true;
						}
					}
					break;
				case EBuffActionType.InactiveBuffWhenVictimHasEveryBuff:
				{
					bool flag7 = true;
					foreach (long buffId6 in tbuffAction.Buffs)
					{
						if (!this.HasActiveBuff(buffId6))
						{
							flag7 = false;
							break;
						}
					}
					if (flag7)
					{
						return true;
					}
					break;
				}
				case EBuffActionType.InactiveBuffWhenVictimNotHasSomeBuff:
					foreach (long buffId7 in tbuffAction.Buffs)
					{
						if (!this.HasActiveBuff(buffId7))
						{
							return true;
						}
					}
					break;
				case EBuffActionType.InactiveBuffWhenVictimNotHasEveryBuff:
				{
					bool flag8 = true;
					foreach (long buffId8 in tbuffAction.Buffs)
					{
						if (this.HasActiveBuff(buffId8))
						{
							flag8 = false;
							break;
						}
					}
					if (flag8)
					{
						return true;
					}
					break;
				}
				}
				break;
			}
		}
		return false;
	}

	// Token: 0x06018517 RID: 99607 RVA: 0x006CCCDC File Offset: 0x006CAEDC
	protected virtual bool CheckRemove(BuffDefinition config, [Nullable(2)] Entity instigator)
	{
		BaseTagComponent tagComponent = this.GetTagComponent();
		if (tagComponent == null)
		{
			if (!this.HasTagRemoveCheck(config))
			{
				return false;
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "检查buff移除条件时找不到Tag组件，默认移除";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", config.Id);
			instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}
		else
		{
			if (this.CheckRemoveAction(config, instigator))
			{
				return true;
			}
			bool flag2 = false;
			int[] removeTagIgnores = config.RemoveTagIgnores;
			if (removeTagIgnores != null && removeTagIgnores.Length != 0)
			{
				flag2 = true;
				foreach (int tagId in config.RemoveTagIgnores)
				{
					if (tagComponent.HasTag(tagId))
					{
						flag2 = false;
						break;
					}
				}
			}
			bool flag3 = false;
			int[] removeTagExistAll = config.RemoveTagExistAll;
			if (removeTagExistAll != null && removeTagExistAll.Length != 0)
			{
				flag3 = true;
				foreach (int tagId2 in config.RemoveTagExistAll)
				{
					if (!tagComponent.HasTag(tagId2))
					{
						flag3 = false;
						break;
					}
				}
			}
			bool flag4 = false;
			int[] removeTagExistAny = config.RemoveTagExistAny;
			if (removeTagExistAny != null && removeTagExistAny.Length != 0)
			{
				foreach (int tagId3 in config.RemoveTagExistAny)
				{
					if (tagComponent.HasTag(tagId3))
					{
						flag4 = true;
						break;
					}
				}
			}
			return flag2 || flag3 || flag4;
		}
	}

	// Token: 0x06018518 RID: 99608 RVA: 0x006CCE18 File Offset: 0x006CB018
	protected virtual bool CheckActivate(BuffDefinition config, [Nullable(2)] Entity instigator)
	{
		BaseTagComponent tagComponent = this.GetTagComponent();
		if (tagComponent == null)
		{
			return false;
		}
		if (config.ActivateTagIgnores != null)
		{
			foreach (int tagId in config.ActivateTagIgnores)
			{
				if (tagComponent.HasTag(tagId))
				{
					return false;
				}
			}
		}
		if (config.ActivateTagRequirements != null)
		{
			foreach (int tagId2 in config.ActivateTagRequirements)
			{
				if (!tagComponent.HasTag(tagId2))
				{
					return false;
				}
			}
		}
		return !this.CheckInactivateAction(config, instigator);
	}

	// Token: 0x06018519 RID: 99609 RVA: 0x006CCE98 File Offset: 0x006CB098
	public virtual void SetBuffEffectCd(long buffId, int index, float remainCd)
	{
		Dictionary<int, double> dictionary;
		if (!this.EffectTimeoutMap.TryGetValue(buffId, out dictionary))
		{
			dictionary = new Dictionary<int, double>();
			this.EffectTimeoutMap[buffId] = dictionary;
		}
		if (remainCd <= 0f)
		{
			dictionary.Remove(index);
			return;
		}
		dictionary[index] = Singleton<Time>.Instance.ServerCombatStopTime + (double)remainCd;
	}

	// Token: 0x0601851A RID: 99610 RVA: 0x006CCEF0 File Offset: 0x006CB0F0
	public double GetBuffEffectCd(long buffId, int index)
	{
		Dictionary<int, double> dictionary;
		if (!this.EffectTimeoutMap.TryGetValue(buffId, out dictionary))
		{
			return 0.0;
		}
		double num;
		if (!dictionary.TryGetValue(index, out num))
		{
			return 0.0;
		}
		if (num <= Singleton<Time>.Instance.ServerCombatStopTime)
		{
			return 0.0;
		}
		return num - Singleton<Time>.Instance.ServerCombatStopTime;
	}

	// Token: 0x0601851B RID: 99611 RVA: 0x006CCF50 File Offset: 0x006CB150
	private unsafe void RemoveInvalidTargetCd(Dictionary<int, double> targetMap)
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, double> keyValuePair in targetMap)
		{
			if (keyValuePair.Value <= Singleton<Time>.Instance.ServerCombatStopTime)
			{
				list.Add(keyValuePair.Key);
			}
		}
		foreach (int key in list)
		{
			targetMap.Remove(key);
		}
		if (targetMap.Count >= BaseBuffComponent.MaxTargetCdCount)
		{
			int? num = null;
			using (Dictionary<int, double>.KeyCollection.Enumerator enumerator3 = targetMap.Keys.GetEnumerator())
			{
				if (enumerator3.MoveNext())
				{
					int value = enumerator3.Current;
					num = new int?(value);
				}
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "目标CD条目数量超上限，移除最早插入的目标CD";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("当前数量", targetMap.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("上限", BaseBuffComponent.MaxTargetCdCount);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("移除的entityId", num);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			if (num != null)
			{
				targetMap.Remove(num.Value);
			}
		}
	}

	// Token: 0x0601851C RID: 99612 RVA: 0x006CD0FC File Offset: 0x006CB2FC
	public unsafe virtual void SetBuffEffectCdForTarget(long buffId, int index, int targetEntityId, float remainCd)
	{
		if (targetEntityId == 0)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "设置目标CD时目标实体无效(entityId=0)，跳过";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("effectIndex", index);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		Dictionary<int, Dictionary<int, double>> dictionary;
		if (!this.EffectTargetTimeoutMap.TryGetValue(buffId, out dictionary))
		{
			dictionary = new Dictionary<int, Dictionary<int, double>>();
			this.EffectTargetTimeoutMap[buffId] = dictionary;
		}
		Dictionary<int, double> dictionary2;
		if (!dictionary.TryGetValue(index, out dictionary2))
		{
			dictionary2 = new Dictionary<int, double>();
			dictionary[index] = dictionary2;
		}
		if (remainCd <= 0f)
		{
			dictionary2.Remove(targetEntityId);
			return;
		}
		this.RemoveInvalidTargetCd(dictionary2);
		dictionary2.ContainsKey(targetEntityId);
		dictionary2.Remove(targetEntityId);
		dictionary2[targetEntityId] = Singleton<Time>.Instance.ServerCombatStopTime + (double)remainCd;
	}

	// Token: 0x0601851D RID: 99613 RVA: 0x006CD1E8 File Offset: 0x006CB3E8
	public string GetTargetCdDebugStr(long buffId, int index)
	{
		Dictionary<int, Dictionary<int, double>> dictionary;
		if (!this.EffectTargetTimeoutMap.TryGetValue(buffId, out dictionary))
		{
			return "";
		}
		Dictionary<int, double> dictionary2;
		if (!dictionary.TryGetValue(index, out dictionary2) || dictionary2.Count == 0)
		{
			return "";
		}
		List<string> list = new List<string>();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		foreach (KeyValuePair<int, double> keyValuePair in dictionary2)
		{
			double num = keyValuePair.Value - Singleton<Time>.Instance.ServerCombatStopTime;
			if (num > 0.0)
			{
				List<string> list2 = list;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Key);
				defaultInterpolatedStringHandler.AppendLiteral(":");
				defaultInterpolatedStringHandler.AppendFormatted<double>(num / 1000.0, "F1");
				defaultInterpolatedStringHandler.AppendLiteral("s");
				list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}
		if (list.Count == 0)
		{
			return "";
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
		defaultInterpolatedStringHandler.AppendLiteral(", targetCd(");
		defaultInterpolatedStringHandler.AppendFormatted<int>(list.Count);
		defaultInterpolatedStringHandler.AppendLiteral("): [");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join(", ", list));
		defaultInterpolatedStringHandler.AppendLiteral("]");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601851E RID: 99614 RVA: 0x006CD340 File Offset: 0x006CB540
	public double GetBuffEffectCdForTarget(long buffId, int index, int targetEntityId)
	{
		if (targetEntityId == 0)
		{
			return 0.0;
		}
		Dictionary<int, Dictionary<int, double>> dictionary;
		if (!this.EffectTargetTimeoutMap.TryGetValue(buffId, out dictionary))
		{
			return 0.0;
		}
		Dictionary<int, double> dictionary2;
		if (!dictionary.TryGetValue(index, out dictionary2))
		{
			return 0.0;
		}
		double num;
		if (!dictionary2.TryGetValue(targetEntityId, out num))
		{
			return 0.0;
		}
		if (num <= Singleton<Time>.Instance.ServerCombatStopTime)
		{
			return 0.0;
		}
		return num - Singleton<Time>.Instance.ServerCombatStopTime;
	}

	// Token: 0x0601851F RID: 99615 RVA: 0x006CD3C4 File Offset: 0x006CB5C4
	public unsafe long? CreateAnimNotifyContentWithAnimBp(int anIndex, string animName)
	{
		BaseSkillComponent skillComponent = this.GetSkillComponent();
		global::Skill skill = (skillComponent != null) ? skillComponent.CurrentSkill : null;
		long? num = (skill != null) ? skill.CombatMessageId : null;
		if (anIndex == -1)
		{
			return null;
		}
		if (num != null)
		{
			long? num2 = num;
			long num3 = 0L;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				long value = ModelBase<CombatMessageModel>.Instance.GenMessageId();
				ControllerBase<SkillMessageController>.Instance.AnimNotifyRequest(base.Entity, (skill != null) ? skill.SkillId : 0, -1, anIndex, new long?(num.Value), new long?(value));
				return new long?(value);
			}
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "CreateANCWithAnimBp Error";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("anIndex", anIndex);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("animName", animName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SkillId", (skill != null) ? new int?(skill.SkillId) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("contextId", num);
		instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		return null;
	}

	// Token: 0x06018520 RID: 99616 RVA: 0x006CD52C File Offset: 0x006CB72C
	public unsafe long? CreateAnimNotifyContentWithoutSkill(MontageInfo montageInfo, int anIndex)
	{
		if (montageInfo.MontageTaskMessageId != null)
		{
			long? montageTaskMessageId = montageInfo.MontageTaskMessageId;
			long num = 0L;
			if (!(montageTaskMessageId.GetValueOrDefault() == num & montageTaskMessageId != null) && anIndex != -1)
			{
				long value = ModelBase<CombatMessageModel>.Instance.GenMessageId();
				ControllerBase<SkillMessageController>.Instance.AnimNotifyRequest(base.Entity, -1, -1, anIndex, new long?(montageInfo.MontageTaskMessageId.Value), new long?(value));
				return new long?(value);
			}
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "CreateANCWithoutSkill Error";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ANIndex", anIndex);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("montageInfo", montageInfo);
		instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return null;
	}

	// Token: 0x06018521 RID: 99617 RVA: 0x006CD608 File Offset: 0x006CB808
	public unsafe long? CreateAnimNotifyContentWithSkill(MontageInfo montageInfo, int anIndex)
	{
		BaseSkillComponent skillComponent = this.GetSkillComponent();
		global::Skill skill = (skillComponent != null) ? skillComponent.GetSkill(montageInfo.SkillId.GetValueOrDefault()) : null;
		if (skill != null && montageInfo.MontageIndex != null && montageInfo.MontageTaskMessageId != null)
		{
			long? montageTaskMessageId = montageInfo.MontageTaskMessageId;
			long num = 0L;
			if (!(montageTaskMessageId.GetValueOrDefault() == num & montageTaskMessageId != null) && anIndex != -1)
			{
				int skillId = skill.SkillId;
				long? montageTaskMessageId2 = montageInfo.MontageTaskMessageId;
				long value = ModelBase<CombatMessageModel>.Instance.GenMessageId();
				ControllerBase<SkillMessageController>.Instance.AnimNotifyRequest(base.Entity, skillId, montageInfo.MontageIndex.Value, anIndex, new long?(montageTaskMessageId2.Value), new long?(value));
				return new long?(value);
			}
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "CreateANCWithSkill Error";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ANIndex", anIndex);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("montageInfo", montageInfo);
		instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return null;
	}

	// Token: 0x06018522 RID: 99618 RVA: 0x006CD72C File Offset: 0x006CB92C
	public long? CreateAnimNotifyContent(string montageName, int anIndex)
	{
		BaseMontageComponent component = base.Entity.GetComponent<BaseMontageComponent>();
		MontageInfo montageInfo = (component != null) ? component.GetMontageInfo(montageName) : null;
		if (montageInfo == null)
		{
			return this.CreateAnimNotifyContentWithAnimBp(anIndex, montageName);
		}
		BaseSkillComponent skillComponent = this.GetSkillComponent();
		if (((skillComponent != null) ? skillComponent.GetSkill(montageInfo.SkillId.GetValueOrDefault()) : null) == null)
		{
			return this.CreateAnimNotifyContentWithoutSkill(montageInfo, anIndex);
		}
		return this.CreateAnimNotifyContentWithSkill(montageInfo, anIndex);
	}

	// Token: 0x06018523 RID: 99619 RVA: 0x006CD78E File Offset: 0x006CB98E
	public void AddBuffFromAi(long? contextId, long buffId, AddBuffParam buffParams)
	{
		bool flag = contextId != null;
		buffParams.PreMessageId = contextId;
		this.AddBuff(buffId, buffParams);
	}

	// Token: 0x06018524 RID: 99620 RVA: 0x006CD7A7 File Offset: 0x006CB9A7
	public void AddBuffForDebug(long buffId, AddBuffParam buffParams)
	{
		buffParams.PreMessageId = new long?(-1L);
		this.AddBuff(buffId, buffParams);
	}

	// Token: 0x06018525 RID: 99621 RVA: 0x006CD7C0 File Offset: 0x006CB9C0
	public unsafe virtual void AddBuff(long buffId, AddBuffParam buffParams)
	{
		if (buffId <= 0L)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "尝试添加buff时传入了不合法的buffId";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("创建者", buffParams.InstigatorId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(buffParams.InstigatorId);
		BaseBuffComponent baseBuffComponent;
		if (entity2 == null)
		{
			baseBuffComponent = null;
		}
		else
		{
			WorldEntity entity3 = entity2.Entity;
			baseBuffComponent = ((entity3 != null) ? entity3.GetComponent<BaseBuffComponent>() : null);
		}
		BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
		buffId = ((baseBuffComponent2 != null) ? baseBuffComponent2.GetReplaceBuffId(buffId, buffParams) : null).GetValueOrDefault(buffId);
		InstanceDungeon? instanceDungeon;
		int[] array = (ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? instanceDungeon.GetValueOrDefault().GetCustomTypesArray() : null;
		bool flag2 = array != null && Array.IndexOf<int>(array, 5) >= 0;
		if (buffParams.PreMessageId != null)
		{
			long? preMessageId = buffParams.PreMessageId;
			long num = 0L;
			if (!(preMessageId.GetValueOrDefault() == num & preMessageId != null))
			{
				goto IL_1B2;
			}
		}
		if (!BuffIdUtils.CheckBuffInSpecialList(buffId) && !flag2)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Buff;
			Entity entity4 = base.Entity;
			string message2 = "加Buff上文无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("原因", buffParams.Reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("buffId", buffId);
			instance2.Error(flag3, entity4, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		IL_1B2:
		int? level = buffParams.Level;
		buffParams.Level = ((level != null) ? level : ((baseBuffComponent2 != null) ? baseBuffComponent2.GetBuffLevel(buffId) : null));
		if (this.HasBuffAuthority())
		{
			this.AddBuffLocal(buffId, buffParams);
			return;
		}
		if (this.NeedAddBuffOrder(buffId))
		{
			this.AddBuffOrder(buffId, buffParams);
		}
	}

	// Token: 0x06018526 RID: 99622 RVA: 0x006CD9D4 File Offset: 0x006CBBD4
	public unsafe virtual int AddBuffLocal(long buffId, AddBuffParam buffParams)
	{
		long instigatorId = buffParams.InstigatorId;
		int? level = buffParams.Level;
		int? outerStackCount = buffParams.OuterStackCount;
		ApplyGEType valueOrDefault = buffParams.ApplyType.GetValueOrDefault();
		long? preMessageId = buffParams.PreMessageId;
		long? messageId = buffParams.MessageId;
		float? duration = buffParams.Duration;
		float? duration2 = (duration != null) ? duration : ActiveBuffConfigs.USE_INTERNAL_DURATION;
		int valueOrDefault2 = buffParams.ServerId.GetValueOrDefault(-1);
		bool valueOrDefault3 = buffParams.IsIterable.GetValueOrDefault(true);
		bool valueOrDefault4 = buffParams.IsServerOrder.GetValueOrDefault();
		string reason = buffParams.Reason;
		long? bulletMessageId = buffParams.BulletMessageId;
		bool valueOrDefault5 = buffParams.BornBuff.GetValueOrDefault();
		if (!this.HasBuffAuthority())
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "[local] 模拟端不本地添加buff";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("施加者", instigatorId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("前置行为id", preMessageId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("原因", reason);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			return -1;
		}
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, reason);
		if (buffDefinition == null)
		{
			return -1;
		}
		EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(instigatorId);
		BaseBuffComponent baseBuffComponent;
		if (entity2 == null)
		{
			baseBuffComponent = null;
		}
		else
		{
			WorldEntity entity3 = entity2.Entity;
			baseBuffComponent = ((entity3 != null) ? entity3.GetComponent<BaseBuffComponent>() : null);
		}
		BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
		level = new int?(level ?? ((baseBuffComponent2 != null) ? baseBuffComponent2.GetBuffLevel(buffId) : null).GetValueOrDefault(1));
		return this.AddBuffInner(buffId, buffDefinition, new long?(instigatorId), level.Value, outerStackCount, new ApplyGEType?(valueOrDefault), preMessageId, messageId, duration2, null, valueOrDefault2, reason, false, valueOrDefault3, valueOrDefault4, null, bulletMessageId, new bool?(valueOrDefault5));
	}

	// Token: 0x06018527 RID: 99623 RVA: 0x006CDC0A File Offset: 0x006CBE0A
	protected virtual void AddBuffOrder(long buffId, AddBuffParam buffParams)
	{
	}

	// Token: 0x06018528 RID: 99624 RVA: 0x006CDC0C File Offset: 0x006CBE0C
	protected void AddBuffRemote(long buffId, int handle, long overrideConfigId, AddBuffParam buffParams)
	{
		long instigatorId = buffParams.InstigatorId;
		int valueOrDefault = buffParams.Level.GetValueOrDefault(1);
		int? outerStackCount = buffParams.OuterStackCount;
		ApplyGEType valueOrDefault2 = buffParams.ApplyType.GetValueOrDefault();
		long? preMessageId = buffParams.PreMessageId;
		long? messageId = buffParams.MessageId;
		float? duration = buffParams.Duration;
		float? duration2 = (duration != null) ? duration : ActiveBuffConfigs.USE_INTERNAL_DURATION;
		float? remainDuration = buffParams.RemainDuration;
		int valueOrDefault3 = buffParams.ServerId.GetValueOrDefault(-1);
		bool? isActive = buffParams.IsActive;
		string reason = buffParams.Reason;
		bool valueOrDefault4 = buffParams.BornBuff.GetValueOrDefault();
		BuffDefinition config = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, reason);
		if (overrideConfigId != 0L)
		{
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(overrideConfigId, null);
			if (buffDefinition != null)
			{
				config = buffDefinition;
			}
		}
		int key = this.AddBuffInner(buffId, config, new long?(instigatorId), valueOrDefault, outerStackCount, new ApplyGEType?(valueOrDefault2), preMessageId, messageId, duration2, isActive, valueOrDefault3, reason, true, true, false, new int?(handle), null, new bool?(valueOrDefault4));
		ActiveBuffInternal valueOrDefault5 = this.BuffContainer.GetValueOrDefault(key);
		if (valueOrDefault5 == null)
		{
			return;
		}
		if (remainDuration != null)
		{
			valueOrDefault5.SetRemainDuration(remainDuration.Value);
		}
	}

	// Token: 0x06018529 RID: 99625 RVA: 0x006CDD50 File Offset: 0x006CBF50
	[NullableContext(2)]
	public unsafe void AddIterativeBuff(long buffId, IActiveBuff preBuff, int? stackCount, bool isIterable, [Nullable(1)] string reason, long? bulletMessageId = null, IBuffComponent instigator = null)
	{
		if (preBuff == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "尝试添加迭代buff失败，未找到前置buff";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("原因", reason);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		long num = preBuff.InstigatorId.GetValueOrDefault();
		if (instigator != null)
		{
			BaseBuffComponent baseBuffComponent = instigator as BaseBuffComponent;
			num = ((baseBuffComponent != null) ? baseBuffComponent.CreatureDataId : num);
		}
		this.AddBuff(buffId, new AddBuffParam
		{
			InstigatorId = num,
			Level = new int?(preBuff.Level),
			PreMessageId = preBuff.MessageId,
			ServerId = new int?(preBuff.ServerId),
			OuterStackCount = stackCount,
			IsIterable = new bool?(isIterable),
			Reason = reason,
			BulletMessageId = bulletMessageId
		});
	}

	// Token: 0x17002079 RID: 8313
	// (get) Token: 0x0601852A RID: 99626 RVA: 0x006CDE66 File Offset: 0x006CC066
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private static Dictionary<long, Stat> BuffStatMap
	{
		[return: Nullable(new byte[]
		{
			1,
			2
		})]
		get
		{
			return BaseBuffComponent._buffStatMap;
		}
	}

	// Token: 0x0601852B RID: 99627 RVA: 0x006CDE70 File Offset: 0x006CC070
	[NullableContext(2)]
	protected static Stat GetBuffStat(long buffId)
	{
		if (!Stat.Enable)
		{
			return null;
		}
		if (!BaseBuffComponent.BuffStatMap.ContainsKey(buffId))
		{
			BaseBuffComponent.BuffStatMap[buffId] = Stat.CreateNoFlameGraph(buffId.ToString(), "", "STATGROUP_KuroBattle");
		}
		return BaseBuffComponent.BuffStatMap[buffId];
	}

	// Token: 0x0601852C RID: 99628 RVA: 0x006CDEC0 File Offset: 0x006CC0C0
	[NullableContext(2)]
	public unsafe virtual int AddBuffInner(long buffId, BuffDefinition config, long? instigatorId, int level, int? outerStackCount, ApplyGEType? applyType, long? preMessageId, long? messageId, float? duration, bool? isActive, int serverId, string reason, bool fromServer, bool isIterable, bool isServerOrder, int? handle, long? bulletMessageId = null, bool? bornBuff = null)
	{
		BaseBuffComponent.GetBuffStat(buffId);
		int num = this.BuffLock;
		this.BuffLock = num + 1;
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("创建者id", instigatorId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", this.GetDebugName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("初始激活", isActive);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("原因", reason);
		ReadOnlySpan<ValueTuple<string, object>> pairs = <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5);
		if (config == null)
		{
			Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Buff, base.Entity, "[local] 添加buff时找不到配置", pairs);
			num = this.BuffLock;
			this.BuffLock = num - 1;
			return -1;
		}
		BuffDefinition buffDefinition = config;
		IConfigOverrideRule configOverrideRule = null;
		if (this.HasBuffAuthority() && !fromServer && buffDefinition.ConfigOverrides != null && buffDefinition.ConfigOverrides.Length != 0)
		{
			configOverrideRule = this.ConfigOverrideConditionListener.ResolveOverrideConfigRule(buffDefinition.ConfigOverrides.ToList<IConfigOverrideRule>());
			if (configOverrideRule != null)
			{
				BuffDefinition buffDefinition2 = ControllerBase<BuffController>.Instance.GetBuffDefinition(configOverrideRule.OverrideConfigId, reason);
				if (buffDefinition2 != null)
				{
					buffDefinition = buffDefinition2;
				}
			}
		}
		applyType = new ApplyGEType?(applyType.GetValueOrDefault());
		WorldEntity worldEntity = null;
		if (instigatorId != null)
		{
			long? num2 = instigatorId;
			long num3 = 0L;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(instigatorId.Value);
				worldEntity = ((entity != null) ? entity.Entity : null);
				if (worldEntity == null)
				{
					Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Buff, base.Entity, "[local] 添加buff时找不到施加者，将被丢弃", pairs);
					num = this.BuffLock;
					this.BuffLock = num - 1;
					return -1;
				}
			}
		}
		int num5;
		if (outerStackCount != null)
		{
			int? num4 = outerStackCount;
			num = 0;
			if (num4.GetValueOrDefault() > num & num4 != null)
			{
				num5 = outerStackCount.Value;
				goto IL_1F1;
			}
		}
		num5 = buffDefinition.DefaultStackCount;
		IL_1F1:
		int num6 = num5;
		if (!this.CheckAdd(buffDefinition, instigatorId.GetValueOrDefault(), fromServer))
		{
			if (worldEntity != null)
			{
				ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, Entity, Entity, int, long?>(worldEntity, EAbilityEventName.AddBuffFailure, buffId, buffId, base.Entity, worldEntity, num6, bulletMessageId);
			}
			num = this.BuffLock;
			this.BuffLock = num - 1;
			return -1;
		}
		if (worldEntity != null)
		{
			ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, Entity, Entity, bool?>(worldEntity, EAbilityEventName.AddBuffToOthers, buffId, buffId, base.Entity, worldEntity, bornBuff);
		}
		ActiveBuffInternal stackableBuff = this.GetStackableBuff(instigatorId.GetValueOrDefault(), buffId, buffDefinition.StackingType);
		int num7 = this.RefreshBuffStackMax(buffId);
		if (stackableBuff != null)
		{
			if (stackableBuff.Config != null && (num7 <= 0 || !stackableBuff.Config.DenyOverflowAdd || stackableBuff.StackCount < num7))
			{
				if (buffDefinition.StackAppendCount > 0)
				{
					num6 = buffDefinition.StackAppendCount;
				}
				int stackCount = stackableBuff.StackCount;
				int num8 = stackCount + num6;
				int newStack = Math.Min(num8, num7);
				try
				{
					this.OnBuffStackIncreased(stackableBuff, stackCount, newStack, new long?(instigatorId.GetValueOrDefault()), level, outerStackCount, applyType.Value, preMessageId, duration, serverId, isIterable, isServerOrder, reason, EBuffStackDurationOverride.Default, EBuffStackPeriodResetOverride.Default);
					foreach (ExtraEffectParameters extraEffectParameters in stackableBuff.Config.EffectInfos)
					{
						BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
						if (executionEffect != null)
						{
							executionEffect.OnBuffAddedCallback(stackableBuff, isIterable);
						}
					}
					if (num8 > num7)
					{
						ExtraEffectManager buffEffectManager = this.BuffEffectManager;
						if (buffEffectManager != null)
						{
							buffEffectManager.OnBuffStackOverflow(stackableBuff, stackCount, num8, num7);
						}
					}
				}
				catch (Exception e)
				{
					Singleton<CombatLog>.Instance.ErrorWithStack(CombatLog.EDebugModule.Buff, base.Entity, "Buff层数改变中发生异常", e, pairs);
				}
			}
			ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int>(base.Entity, EAbilityEventName.OnBuffAdd, buffId, buffId, stackableBuff.Handle);
			num = this.BuffLock;
			this.BuffLock = num - 1;
			return stackableBuff.Handle;
		}
		int num9 = num6;
		int? num10 = this.CalculateBuffStackMaxByConfig(buffDefinition, buffId);
		if (num10 != null && num10.GetValueOrDefault() != 2147483647)
		{
			num6 = Math.Min(num6, num10.Value);
		}
		ActiveBuffInternal newBuff = null;
		if (buffDefinition.DurationPolicy == EBuffDurationType.Instant)
		{
			handle = new int?(-2);
			duration = new float?((float)-1);
		}
		else
		{
			handle = new int?(handle ?? ControllerBase<BuffController>.Instance.GenerateHandle());
		}
		try
		{
			newBuff = ActiveBuffInternal.AllocBuff(buffDefinition, handle.Value, instigatorId, this, serverId, preMessageId, messageId, level, num6, duration, applyType.Value, buffId);
		}
		catch (Exception e2)
		{
			Singleton<CombatLog>.Instance.ErrorWithStack(CombatLog.EDebugModule.Buff, base.Entity, "Buff初始过程中发生异常", e2, pairs);
		}
		if (newBuff == null)
		{
			num = this.BuffLock;
			this.BuffLock = num - 1;
			return -1;
		}
		if (num9 > num6 && num10 != null && num10.GetValueOrDefault() != 2147483647)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity2 = base.Entity;
			string message = "[local] 新增buff层数超过最大层数限制，已自动截断";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("原始层数", num9);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("最大层数", num10);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("截断后层数", num6);
			instance.Warn(flag, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		if (this.HasBuffAuthority() && !fromServer && configOverrideRule != null && config.ConfigOverrides != null)
		{
			ConfigOverrideConditionListener.ConfigOverrideListenerRegistration configOverrideListenerRegistration = this.ConfigOverrideConditionListener.AddListener(config.ConfigOverrides.ToList<IConfigOverrideRule>(), delegate
			{
				ActiveBuffInternal newBuff = newBuff;
				if (newBuff == null)
				{
					return;
				}
				newBuff.OnConfigOverrideChanged();
			}, false, configOverrideRule.OverrideConfigId);
			if (configOverrideListenerRegistration != null)
			{
				newBuff.SetConfigOverrideListenerId(configOverrideListenerRegistration.ListenerId);
			}
		}
		if (!BaseBuffComponent.NoLogBuffSet.Contains(buffId))
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
			Entity entity3 = base.Entity;
			string message2 = "本地添加buff";
			<>y__InlineArray11<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray11<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("创建者id", instigatorId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("初始激活", isActive);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("原因", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 5) = new ValueTuple<string, object>("handle", handle);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 6) = new ValueTuple<string, object>("前置行为id", preMessageId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 7) = new ValueTuple<string, object>("说明", buffDefinition.Desc);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 8) = new ValueTuple<string, object>("是否迭代", isIterable);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 9) = new ValueTuple<string, object>("层数", num6);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 10) = new ValueTuple<string, object>("bulletMessage", bulletMessageId);
			instance2.Info(flag2, entity3, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray11<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 11));
		}
		try
		{
			this.OnBuffAdded(newBuff, outerStackCount, applyType.Value, preMessageId, duration, isActive, serverId, fromServer, isIterable, isServerOrder, reason);
		}
		catch (Exception e3)
		{
			Singleton<CombatLog>.Instance.ErrorWithStack(CombatLog.EDebugModule.Buff, base.Entity, "Buff添加中发生异常", e3, pairs);
		}
		if (buffDefinition.DurationPolicy == EBuffDurationType.Instant)
		{
			this.UnregisterConfigOverrideListener(newBuff);
			ActiveBuffInternal.ReleaseBuff(newBuff);
		}
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int>(base.Entity, EAbilityEventName.OnBuffAdd, buffId, buffId, handle.Value);
		num = this.BuffLock;
		this.BuffLock = num - 1;
		return handle.Value;
	}

	// Token: 0x0601852D RID: 99629 RVA: 0x006CE6C0 File Offset: 0x006CC8C0
	public virtual void RemoveBuff(long buffId, int stackCount, string reason, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		if (this.HasBuffAuthority())
		{
			this.RemoveBuffLocal(buffId, stackCount, reason, preMessageId, isServerRequest, instigatorId);
			return;
		}
		this.RemoveBuffOrder(buffId, stackCount, reason, instigatorId);
	}

	// Token: 0x0601852E RID: 99630 RVA: 0x006CE6E6 File Offset: 0x006CC8E6
	protected virtual void RemoveBuffOrder(long buffId, int stackCount, string reason, long? instigatorId = null)
	{
	}

	// Token: 0x0601852F RID: 99631 RVA: 0x006CE6E8 File Offset: 0x006CC8E8
	public unsafe virtual int RemoveBuffLocal(long buffId, int stackCount, string reason, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		if (buffId <= 0L)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "尝试本地移除buff时传入了不合法的buffId";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("原因", reason);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return 0;
		}
		if (!this.HasBuffAuthority())
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
			Entity entity2 = base.Entity;
			string message2 = "无法直接移除非本端控制实体持有的buff，请换用RemoveBuff接口";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("原因", reason);
			instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return 0;
		}
		int result = 0;
		foreach (ActiveBuffInternal activeBuffInternal in this.GetAllBuffById(buffId).ToArray<ActiveBuffInternal>())
		{
			result = this.RemoveBuffInner(activeBuffInternal.Handle, stackCount, true, reason, preMessageId, isServerRequest, instigatorId);
		}
		return result;
	}

	// Token: 0x06018530 RID: 99632 RVA: 0x006CE838 File Offset: 0x006CCA38
	public virtual void RemoveBuffByServerId(int serverId, int stackCount, long preMessageId, string reason, long? instigatorId = null)
	{
		foreach (IActiveBuff activeBuff in this.GetAllBuffs())
		{
			if (activeBuff.ServerId == serverId)
			{
				this.RemoveBuffInner(activeBuff.Handle, stackCount, true, reason, new long?(preMessageId), new bool?(true), instigatorId);
			}
		}
	}

	// Token: 0x06018531 RID: 99633 RVA: 0x006CE888 File Offset: 0x006CCA88
	[NullableContext(2)]
	public unsafe virtual void RemoveBuffByTagLocal(int tagId, string reason, long? instigatorId = null)
	{
		if (!this.HasBuffAuthority())
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "尝试根据tag移除非本地控制的实体的buff，移除操作将不被执行";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tagId", tagId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tagName", GameplayTagUtils.GetNameByTagId(tagId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("原因", reason);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
		List<int> list = new List<int>();
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			if (activeBuffInternal.Config.GrantedTags != null)
			{
				int[] grantedTags = activeBuffInternal.Config.GrantedTags;
				for (int i = 0; i < grantedTags.Length; i++)
				{
					if (GameplayTagUtils.IsChildTag(grantedTags[i], tagId))
					{
						list.Add(activeBuffInternal.Handle);
						break;
					}
				}
			}
		}
		foreach (int handle in list)
		{
			this.RemoveBuffInner(handle, -1, true, reason ?? ("移除tag " + nameByTagId), null, null, instigatorId);
		}
	}

	// Token: 0x06018532 RID: 99634 RVA: 0x006CEA3C File Offset: 0x006CCC3C
	public void RemoveBuffByEffectType(EExtraEffectId effectId, string reason)
	{
		HashSet<long> hashSet = new HashSet<long>();
		Type buffEffectClass = ExtraEffectDefine.GetBuffEffectClass(effectId);
		if (buffEffectClass == null)
		{
			return;
		}
		foreach (BuffEffect buffEffect in this.BuffEffectManager.GetAllEffects())
		{
			if (buffEffectClass.IsInstanceOfType(buffEffect))
			{
				hashSet.Add(buffEffect.BuffId);
			}
		}
		foreach (long buffId in hashSet)
		{
			this.RemoveBuff(buffId, -1, reason, null, null, null);
		}
	}

	// Token: 0x06018533 RID: 99635 RVA: 0x006CEB14 File Offset: 0x006CCD14
	[NullableContext(2)]
	public unsafe virtual int RemoveBuffByHandle(int handle, int removeStackCount = -1, string reason = null, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		if (!this.HasBuffAuthority())
		{
			IActiveBuff buffByHandle = this.GetBuffByHandle(handle);
			if (buffByHandle != null && buffByHandle.Id > 0L)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity = base.Entity;
				string message = "尝试直接通过handle移除非本端控制buff，后续需要新增协议";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", (buffByHandle != null) ? new long?(buffByHandle.Id) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", handle);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", this.GetDebugName());
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
				string item = "说明";
				object item2;
				if (buffByHandle == null)
				{
					item2 = null;
				}
				else
				{
					BuffDefinition config = buffByHandle.Config;
					item2 = ((config != null) ? config.Desc : null);
				}
				ptr = new ValueTuple<string, object>(item, item2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("原因", reason);
				instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			}
		}
		return this.RemoveBuffByHandleLocal(handle, removeStackCount, reason, preMessageId, isServerRequest, instigatorId);
	}

	// Token: 0x06018534 RID: 99636 RVA: 0x006CEC32 File Offset: 0x006CCE32
	[NullableContext(2)]
	protected int RemoveBuffByHandleLocal(int handle, int removeStackCount = -1, string reason = null, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		return this.RemoveBuffInner(handle, removeStackCount, true, reason, preMessageId, isServerRequest, instigatorId);
	}

	// Token: 0x06018535 RID: 99637 RVA: 0x006CEC44 File Offset: 0x006CCE44
	public void RemoveBuffWhenTimeout(ActiveBuffInternal buff)
	{
		int stackExpirationRemoveNumber = buff.Config.StackExpirationRemoveNumber;
		this.RemoveBuffInner(buff.Handle, stackExpirationRemoveNumber, false, "时间结束自然移除", null, null, null);
		if (stackExpirationRemoveNumber > 0 && buff.IsValid())
		{
			buff.SetDuration(null);
		}
	}

	// Token: 0x06018536 RID: 99638 RVA: 0x006CECA8 File Offset: 0x006CCEA8
	[NullableContext(2)]
	public unsafe virtual int RemoveBuffInner(int handle, int removeStackCount, bool isPrematureRemoval, string reason, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		ActiveBuffInternal activeBuffInternal = this.GetBuffByHandle(handle) as ActiveBuffInternal;
		if (activeBuffInternal == null)
		{
			return 0;
		}
		int buffLock = this.BuffLock;
		this.BuffLock = buffLock + 1;
		<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", activeBuffInternal.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("handle", (activeBuffInternal != null) ? new int?(activeBuffInternal.Handle) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("说明", (activeBuffInternal != null) ? activeBuffInternal.Config.Desc : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("原因", reason);
		ReadOnlySpan<ValueTuple<string, object>> pairs = <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5);
		if (!BaseBuffComponent.NoLogBuffSet.Contains(activeBuffInternal.Id))
		{
			Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Buff, base.Entity, "本地移除buff", pairs);
		}
		int stackCount = activeBuffInternal.StackCount;
		int num = (removeStackCount <= 0) ? 0 : Math.Max(0, stackCount - removeStackCount);
		if (num <= 0)
		{
			try
			{
				this.OnBuffRemoved(activeBuffInternal, isPrematureRemoval, reason, isServerRequest, preMessageId, instigatorId);
				goto IL_1A1;
			}
			catch (Exception e)
			{
				Singleton<CombatLog>.Instance.ErrorWithStack(CombatLog.EDebugModule.Buff, base.Entity, "Buff移除时发生异常", e, pairs);
				goto IL_1A1;
			}
		}
		if (!isPrematureRemoval && this.HasBuffRoutineExpirationLock(activeBuffInternal.Id))
		{
			num = stackCount;
		}
		try
		{
			this.OnBuffStackDecreased(activeBuffInternal, stackCount, num, isPrematureRemoval, reason, EBuffStackPeriodResetOverride.Default, instigatorId);
		}
		catch (Exception e2)
		{
			Singleton<CombatLog>.Instance.ErrorWithStack(CombatLog.EDebugModule.Buff, base.Entity, "Buff层数降低时发生异常", e2, pairs);
		}
		IL_1A1:
		buffLock = this.BuffLock;
		this.BuffLock = buffLock - 1;
		return stackCount - num;
	}

	// Token: 0x06018537 RID: 99639 RVA: 0x006CEE88 File Offset: 0x006CD088
	public IActiveBuff[] GetAllBuffs()
	{
		List<IActiveBuff> list = new List<IActiveBuff>();
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			if (!this.BuffGarbageSet.Contains(activeBuffInternal.Handle))
			{
				list.Add(activeBuffInternal);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06018538 RID: 99640 RVA: 0x006CEF00 File Offset: 0x006CD100
	[NullableContext(2)]
	public IActiveBuff GetBuffByHandle(int handle)
	{
		if (this.BuffGarbageSet.Contains(handle))
		{
			return null;
		}
		return this.BuffContainer.GetValueOrDefault(handle);
	}

	// Token: 0x06018539 RID: 99641 RVA: 0x006CEF1E File Offset: 0x006CD11E
	[NullableContext(2)]
	public IActiveBuff GetPendingBuffByHandle(int handleId)
	{
		return this.BuffContainer.GetValueOrDefault(handleId);
	}

	// Token: 0x0601853A RID: 99642 RVA: 0x006CEF2C File Offset: 0x006CD12C
	public bool HasActiveBuff(long buffId)
	{
		return this.GetActiveBuffById(buffId) != null;
	}

	// Token: 0x0601853B RID: 99643 RVA: 0x006CEF38 File Offset: 0x006CD138
	public bool HasBuff(long buffId, bool excludeRequestRemove = false)
	{
		return (!excludeRequestRemove || !this.WaitRemoveBuffResponse.ContainsKey(buffId)) && this.GetBuffById(buffId) != null;
	}

	// Token: 0x0601853C RID: 99644 RVA: 0x006CEF58 File Offset: 0x006CD158
	public bool IsPendingAddBuff(long buffId, int checkInterval = 200)
	{
		double num;
		return this.PendingAddBuff.TryGetValue(buffId, out num) && Singleton<Time>.Instance.Now - num < (double)checkInterval;
	}

	// Token: 0x0601853D RID: 99645 RVA: 0x006CEF87 File Offset: 0x006CD187
	[NullableContext(2)]
	public virtual BaseBuffComponent GetBuffApplyTarget(long buffId, long instigatorId)
	{
		return this;
	}

	// Token: 0x0601853E RID: 99646 RVA: 0x006CEF8C File Offset: 0x006CD18C
	[NullableContext(2)]
	public ActiveBuffInternal GetActiveBuffById(long buffId)
	{
		HashSet<int> hashSet;
		if (!this.BuffIdToHandleMap.TryGetValue(buffId, out hashSet))
		{
			return null;
		}
		if (hashSet.Count == 0)
		{
			this.BuffIdToHandleMap.Remove(buffId);
			return null;
		}
		List<int> list = new List<int>();
		foreach (int num in hashSet)
		{
			ActiveBuffInternal valueOrDefault = this.BuffContainer.GetValueOrDefault(num);
			if (valueOrDefault == null)
			{
				list.Add(num);
			}
			else if (valueOrDefault.IsActive() && !this.BuffGarbageSet.Contains(valueOrDefault.Handle))
			{
				return valueOrDefault;
			}
		}
		foreach (int item in list)
		{
			hashSet.Remove(item);
		}
		return null;
	}

	// Token: 0x0601853F RID: 99647 RVA: 0x006CF088 File Offset: 0x006CD288
	[NullableContext(2)]
	public ActiveBuffInternal GetBuffById(long buffId)
	{
		HashSet<int> hashSet;
		if (!this.BuffIdToHandleMap.TryGetValue(buffId, out hashSet))
		{
			return null;
		}
		if (hashSet.Count == 0)
		{
			this.BuffIdToHandleMap.Remove(buffId);
			return null;
		}
		List<int> list = new List<int>();
		foreach (int num in hashSet)
		{
			ActiveBuffInternal valueOrDefault = this.BuffContainer.GetValueOrDefault(num);
			if (valueOrDefault == null)
			{
				list.Add(num);
			}
			else if (!this.BuffGarbageSet.Contains(valueOrDefault.Handle))
			{
				return valueOrDefault;
			}
		}
		foreach (int item in list)
		{
			hashSet.Remove(item);
		}
		return null;
	}

	// Token: 0x06018540 RID: 99648 RVA: 0x006CF178 File Offset: 0x006CD378
	public IEnumerable<ActiveBuffInternal> GetAllBuffById(long buffId)
	{
		BaseBuffComponent.<GetAllBuffById>d__121 <GetAllBuffById>d__ = new BaseBuffComponent.<GetAllBuffById>d__121(-2);
		<GetAllBuffById>d__.<>4__this = this;
		<GetAllBuffById>d__.<>3__buffId = buffId;
		return <GetAllBuffById>d__;
	}

	// Token: 0x06018541 RID: 99649 RVA: 0x006CF190 File Offset: 0x006CD390
	public HashSet<int> GetBuffHandleByEffectId(int effectId)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (KeyValuePair<int, ActiveBuffInternal> keyValuePair in this.BuffContainer)
		{
			int num;
			ActiveBuffInternal activeBuffInternal;
			keyValuePair.Deconstruct(out num, out activeBuffInternal);
			int item = num;
			ActiveBuffInternal activeBuffInternal2 = activeBuffInternal;
			if (!this.BuffGarbageSet.Contains(item))
			{
				using (List<ExtraEffectParameters>.Enumerator enumerator2 = activeBuffInternal2.Config.EffectInfos.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.ExtraEffectId == (EExtraEffectId)effectId)
						{
							hashSet.Add(item);
							break;
						}
					}
				}
			}
		}
		return hashSet;
	}

	// Token: 0x06018542 RID: 99650 RVA: 0x006CF258 File Offset: 0x006CD458
	public virtual int? GetBuffLevel(long buffId)
	{
		return null;
	}

	// Token: 0x06018543 RID: 99651 RVA: 0x006CF270 File Offset: 0x006CD470
	[NullableContext(2)]
	protected ActiveBuffInternal GetStackableBuff(long instigatorId, long buffId, EBuffStackingType stackingType)
	{
		switch (stackingType)
		{
		case EBuffStackingType.ByInstigator:
		{
			HashSet<int> hashSet;
			if (!this.BuffIdToHandleMap.TryGetValue(buffId, out hashSet))
			{
				return null;
			}
			if (hashSet.Count == 0)
			{
				this.BuffIdToHandleMap.Remove(buffId);
				return null;
			}
			List<int> list = new List<int>();
			foreach (int num in hashSet)
			{
				ActiveBuffInternal valueOrDefault = this.BuffContainer.GetValueOrDefault(num);
				if (valueOrDefault == null)
				{
					list.Add(num);
				}
				else if (!this.BuffGarbageSet.Contains(valueOrDefault.Handle))
				{
					long? instigatorId2 = valueOrDefault.InstigatorId;
					if (instigatorId2.GetValueOrDefault() == instigatorId & instigatorId2 != null)
					{
						return valueOrDefault;
					}
				}
			}
			foreach (int item in list)
			{
				hashSet.Remove(item);
			}
			return null;
		}
		case EBuffStackingType.ByOwner:
			return this.GetBuffById(buffId);
		}
		return null;
	}

	// Token: 0x06018544 RID: 99652 RVA: 0x006CF3A4 File Offset: 0x006CD5A4
	public virtual int GetBuffTotalStackById(long buffId, bool onlyActiveBuff = false)
	{
		HashSet<int> hashSet;
		if (!this.BuffIdToHandleMap.TryGetValue(buffId, out hashSet))
		{
			return 0;
		}
		if (hashSet.Count == 0)
		{
			this.BuffIdToHandleMap.Remove(buffId);
			return 0;
		}
		int num = 0;
		List<int> list = new List<int>();
		foreach (int num2 in hashSet)
		{
			ActiveBuffInternal valueOrDefault = this.BuffContainer.GetValueOrDefault(num2);
			if (valueOrDefault == null)
			{
				list.Add(num2);
			}
			else if (!this.BuffGarbageSet.Contains(valueOrDefault.Handle) && (!onlyActiveBuff || valueOrDefault.IsActive()))
			{
				num += valueOrDefault.StackCount;
			}
		}
		foreach (int item in list)
		{
			hashSet.Remove(item);
		}
		return num;
	}

	// Token: 0x06018545 RID: 99653 RVA: 0x006CF4A8 File Offset: 0x006CD6A8
	protected unsafe virtual void OnBuffAdded(ActiveBuffInternal buff, int? stackCount, ApplyGEType applyType, long? preMessageId, float? duration, bool? isActive, int serverId, bool fromServer, bool isIterable, bool isServerOrder, [Nullable(2)] string reason)
	{
		if (buff == null)
		{
			return;
		}
		BuffDefinition config = buff.Config;
		if (buff.IsInstantBuff())
		{
			this.ApplyPeriodExecution(buff);
		}
		else
		{
			int handle = buff.Handle;
			this.BuffContainer[handle] = buff;
			HashSet<int> hashSet;
			if (!this.BuffIdToHandleMap.TryGetValue(buff.Id, out hashSet))
			{
				hashSet = new HashSet<int>();
				this.BuffIdToHandleMap[buff.Id] = hashSet;
			}
			hashSet.Add(handle);
			this.MarkListenerBuff(buff);
			ExtraEffectManager buffEffectManager = this.BuffEffectManager;
			if (buffEffectManager != null)
			{
				buffEffectManager.OnBuffAdded(buff);
			}
		}
		if (!this.NeedCheck(buff.Config))
		{
			if (isActive == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity = base.Entity;
				string message = "buff激活状态未知";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buff.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", buff.Handle);
				instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				this.OnBuffActiveChanged(buff, isActive.Value);
			}
		}
		else
		{
			this.OnBuffActiveChanged(buff, this.CheckActivate(buff.Config, buff.GetInstigator()));
		}
		if (buff.IsActive() && config != null && config.Period > 0f && config.ExecutePeriodicOnAdd)
		{
			buff.ResetPeriodTimer(0.020000001f);
		}
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			CharacterStatisticsComponent component = base.Entity.GetComponent<CharacterStatisticsComponent>();
			if (component != null)
			{
				component.OnBuffAdded(buff);
			}
			CharacterGasDebugComponent component2 = base.Entity.GetComponent<CharacterGasDebugComponent>();
			if (component2 != null)
			{
				component2.OnBuffAdded(buff);
			}
		}
		this.CheckWhenBuffChanged(buff.Id);
		foreach (ExtraEffectParameters extraEffectParameters in buff.Config.EffectInfos)
		{
			BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
			if (executionEffect != null)
			{
				executionEffect.OnBuffAddedCallback(buff, isIterable);
			}
		}
		buff.OnTimeScaleChanged(this.GetTimeScale(), this.IsPaused());
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int, int, Entity>(base.Entity, EAbilityEventName.BuffStackChanged, buff.Id, buff.Id, 0, buff.StackCount, base.Entity);
		this.EmitBuffStackInstigatorChanged(buff.Id, 0, buff.StackCount, buff.InstigatorId);
	}

	// Token: 0x06018546 RID: 99654 RVA: 0x006CF700 File Offset: 0x006CD900
	public unsafe void ApplyPeriodExecution(ActiveBuffInternal buff)
	{
		BuffDefinition config = buff.Config;
		BaseAttributeComponent instigatorAttributeSet = buff.GetInstigatorAttributeSet();
		if (config.Modifiers != null && config.Modifiers.Length != 0)
		{
			BaseAttributeComponent attributeComponent = this.GetAttributeComponent();
			if (attributeComponent == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity = base.Entity;
				string message = "周期buff尝试修改属性，但owner不存在";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buff.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", buff.Handle);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item = "持有者";
				IBuffComponent ownerBuffComponent = buff.GetOwnerBuffComponent();
				ptr = new ValueTuple<string, object>(item, (ownerBuffComponent != null) ? ownerBuffComponent.GetDebugName() : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("施加者", buff.InstigatorId);
				instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			else
			{
				float timeScale = this.GetTimeScale();
				for (int i = 0; i < buff.StateModifiers.Count; i++)
				{
					ValueTuple<IBuffModifierData, float?> valueTuple = buff.StateModifiers[i];
					if (this.HasBuffAuthority())
					{
						ActiveBuffInternal.ModifyStateAttribute(instigatorAttributeSet, attributeComponent, valueTuple.Item1, buff.Level, timeScale, buff.StackCount, valueTuple.Item2);
					}
				}
			}
		}
		foreach (ExtraEffectParameters extraEffectParameters in config.EffectInfos)
		{
			BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
			if (executionEffect != null)
			{
				executionEffect.OnPeriodCallback(buff);
			}
		}
		ExtraEffectManager buffEffectManager = this.BuffEffectManager;
		foreach (BuffEffect buffEffect in (((buffEffectManager != null) ? buffEffectManager.GetEffectsByHandle(buff.Handle) : null) ?? Array.Empty<BuffEffect>()))
		{
			buffEffect.OnPeriodCallback();
		}
	}

	// Token: 0x06018547 RID: 99655 RVA: 0x006CF8FC File Offset: 0x006CDAFC
	protected virtual void OnBuffRemoved(ActiveBuffInternal buff, bool isPrematureRemoval, [Nullable(2)] string reason, bool? isServerRequest = null, long? preMessageId = null, long? instigatorId = null)
	{
		if (buff == null)
		{
			return;
		}
		int handle = buff.Handle;
		int stackCount = buff.StackCount;
		foreach (ExtraEffectParameters extraEffectParameters in buff.Config.EffectInfos)
		{
			BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
			if (executionEffect != null)
			{
				executionEffect.OnBuffRemovedCallback(buff);
			}
		}
		this.RemoveListenerBuff(buff);
		this.BuffGarbageSet.Add(handle);
		buff.Destroy();
		this.CheckWhenBuffChanged(buff.Id);
		this.BuffEffectManager.OnBuffRemoved(buff, isPrematureRemoval);
		CharacterBuffComponent instigatorBuffComponent = buff.GetInstigatorBuffComponent();
		if ((instigatorBuffComponent == null || instigatorBuffComponent.Valid) && this.HasBuffAuthority())
		{
			long[] array;
			if (!isPrematureRemoval)
			{
				BuffDefinition config = buff.Config;
				array = ((config != null) ? config.RoutineExpirationEffects : null);
			}
			else
			{
				BuffDefinition config2 = buff.Config;
				array = ((config2 != null) ? config2.PrematureExpirationEffects : null);
			}
			long[] array2 = array;
			if (array2 != null)
			{
				foreach (long num in array2)
				{
					long buffId = num;
					int? stackCount2 = null;
					bool isIterable = true;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
					defaultInterpolatedStringHandler.AppendLiteral("因为Buff");
					defaultInterpolatedStringHandler.AppendFormatted<long>(buff.Id);
					defaultInterpolatedStringHandler.AppendLiteral("移除导致的添加");
					this.AddIterativeBuff(buffId, buff, stackCount2, isIterable, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
				}
			}
			long[] buffsAddedByStackCountOnRemoved = buff.Config.BuffsAddedByStackCountOnRemoved;
			if (isPrematureRemoval && buffsAddedByStackCountOnRemoved != null && stackCount - 1 >= 0 && stackCount - 1 < buffsAddedByStackCountOnRemoved.Length)
			{
				long num2 = buffsAddedByStackCountOnRemoved[stackCount - 1];
				if (num2 != 0L)
				{
					long buffId2 = num2;
					int? stackCount3 = null;
					bool isIterable2 = true;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
					defaultInterpolatedStringHandler.AppendLiteral("buff");
					defaultInterpolatedStringHandler.AppendFormatted<long>(buff.Id);
					defaultInterpolatedStringHandler.AppendLiteral("移除时根据buff层数获取指定buff");
					this.AddIterativeBuff(buffId2, buff, stackCount3, isIterable2, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
				}
			}
		}
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int, int, Entity>(base.Entity, EAbilityEventName.BuffStackChanged, buff.Id, buff.Id, stackCount, 0, base.Entity);
		this.EmitBuffStackInstigatorChanged(buff.Id, stackCount, 0, instigatorId);
	}

	// Token: 0x06018548 RID: 99656 RVA: 0x006CFB20 File Offset: 0x006CDD20
	protected virtual void OnBuffStackDecreased(ActiveBuffInternal buff, int oldStack, int newStack, bool isPrematureRemoval, [Nullable(2)] string reason, EBuffStackPeriodResetOverride stackPeriodResetPolicy = EBuffStackPeriodResetOverride.Default, long? instigatorId = null)
	{
		if (buff == null)
		{
			return;
		}
		buff.SetStackCount(newStack, stackPeriodResetPolicy);
		this.CheckWhenBuffChanged(buff.Id);
		this.BuffEffectManager.OnStackDecreased(buff, newStack, oldStack, isPrematureRemoval);
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int, int, Entity>(base.Entity, EAbilityEventName.BuffStackChanged, buff.Id, buff.Id, oldStack, newStack, base.Entity);
		this.EmitBuffStackInstigatorChanged(buff.Id, oldStack, newStack, instigatorId);
	}

	// Token: 0x06018549 RID: 99657 RVA: 0x006CFB8C File Offset: 0x006CDD8C
	protected virtual void OnBuffStackIncreased(ActiveBuffInternal buff, int oldStack, int newStack, long? instigatorId, int level, int? outerStackCount, ApplyGEType applyType, long? preMessageId, float? duration, int serverId, bool isIterable, bool isServerOrder, [Nullable(2)] string reason, EBuffStackDurationOverride stackDurationRefreshPolicy = EBuffStackDurationOverride.Default, EBuffStackPeriodResetOverride stackPeriodResetPolicy = EBuffStackPeriodResetOverride.Default)
	{
		if (buff == null)
		{
			return;
		}
		buff.SetStackCount(newStack, stackPeriodResetPolicy);
		if (stackDurationRefreshPolicy == EBuffStackDurationOverride.Default && buff.Config.StackDurationRefreshPolicy == EBuffStackDurationRefreshPolicy.Refresh && (this.NeedCheck(buff.Config) || applyType != ApplyGEType.Common))
		{
			buff.SetDuration(duration);
		}
		BuffDefinition config = buff.Config;
		int handle = buff.Handle;
		if (config == null)
		{
			return;
		}
		long id = buff.Id;
		this.BuffEffectManager.OnStackIncreased(buff, newStack, oldStack, instigatorId);
		if (this.HasBuffAuthority())
		{
			int num = (buff.StackLimitCount > 0) ? buff.StackLimitCount : int.MaxValue;
			if (oldStack >= num && newStack >= num)
			{
				long[] overflowEffects = config.OverflowEffects;
				if (overflowEffects != null && overflowEffects.Length != 0)
				{
					foreach (long num2 in overflowEffects)
					{
						long buffId = num2;
						int? stackCount = null;
						bool isIterable2 = true;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Buff层数溢出时迭代添加新buff（前置buff Id=");
						defaultInterpolatedStringHandler.AppendFormatted<long>(buff.Id);
						defaultInterpolatedStringHandler.AppendLiteral(", handle=");
						defaultInterpolatedStringHandler.AppendFormatted<int>(handle);
						defaultInterpolatedStringHandler.AppendLiteral("）");
						this.AddIterativeBuff(buffId, buff, stackCount, isIterable2, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
					}
				}
				if (buff.Config.ClearStackOnOverflow)
				{
					this.RemoveBuffByHandle(handle, -1, "Buff层数溢出时清除", null, null, null);
				}
			}
		}
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int, int, Entity>(base.Entity, EAbilityEventName.BuffStackChanged, buff.Id, buff.Id, oldStack, newStack, base.Entity);
		this.EmitBuffStackInstigatorChanged(buff.Id, oldStack, newStack, instigatorId);
	}

	// Token: 0x0601854A RID: 99658 RVA: 0x006CFD38 File Offset: 0x006CDF38
	[NullableContext(2)]
	protected virtual void OnBuffActiveChanged(ActiveBuffInternal buff, bool isActive)
	{
		if (buff == null)
		{
			return;
		}
		buff.SetActivate(isActive);
		foreach (ExtraEffectParameters extraEffectParameters in buff.Config.EffectInfos)
		{
			BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
			if (executionEffect != null)
			{
				executionEffect.OnBuffActiveChangedCallback(buff, isActive);
			}
		}
		this.CheckWhenBuffChanged(buff.Id);
		this.BuffEffectManager.OnBuffInhibitedChanged(buff, !isActive);
		this.OnAnyBuffInhibitionChanged(buff);
	}

	// Token: 0x0601854B RID: 99659 RVA: 0x006CFDCC File Offset: 0x006CDFCC
	public void OnTagChanged(int tagId)
	{
		if (this.TagInChanged.Contains(tagId))
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "Tag变更循环派发";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagId", tagId);
			instance.Warn(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.TagInChanged.Add(tagId);
		this.CheckWhenTagChanged(tagId);
		this.TagInChanged.Remove(tagId);
	}

	// Token: 0x1700207A RID: 8314
	// (get) Token: 0x0601854C RID: 99660 RVA: 0x006CFE38 File Offset: 0x006CE038
	// (set) Token: 0x0601854D RID: 99661 RVA: 0x006CFE40 File Offset: 0x006CE040
	protected int BuffLock
	{
		get
		{
			return this.BuffLockInternal;
		}
		set
		{
			this.BuffLockInternal = value;
			if (value <= 0 && this.BuffGarbageSet.Count > 0)
			{
				foreach (int num in this.BuffGarbageSet)
				{
					ActiveBuffInternal valueOrDefault = this.BuffContainer.GetValueOrDefault(num);
					this.BuffContainer.Remove(num);
					if (valueOrDefault != null)
					{
						HashSet<int> hashSet;
						if (this.BuffIdToHandleMap.TryGetValue(valueOrDefault.Id, out hashSet))
						{
							hashSet.Remove(num);
							if (hashSet.Count == 0)
							{
								this.BuffIdToHandleMap.Remove(valueOrDefault.Id);
							}
						}
						this.UnregisterConfigOverrideListener(valueOrDefault);
						ActiveBuffInternal.ReleaseBuff(valueOrDefault);
					}
				}
				this.BuffGarbageSet.Clear();
			}
		}
	}

	// Token: 0x0601854E RID: 99662 RVA: 0x006CFF18 File Offset: 0x006CE118
	public void AddTrigger(int handleId, EBuffTriggerType buffEffectEventType, IBuffTrigger passiveEffects)
	{
		List<IBuffTrigger> list;
		if (!this.TriggerMap.TryGetValue(buffEffectEventType, out list))
		{
			list = new List<IBuffTrigger>();
			this.TriggerMap[buffEffectEventType] = list;
		}
		list.Add(passiveEffects);
	}

	// Token: 0x0601854F RID: 99663 RVA: 0x006CFF50 File Offset: 0x006CE150
	public void RemoveTrigger(int handleId, EBuffTriggerType extraEffectType)
	{
		List<IBuffTrigger> list;
		if (!this.TriggerMap.TryGetValue(extraEffectType, out list))
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].ActiveHandleId == handleId)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			list.RemoveAt(num);
		}
	}

	// Token: 0x06018550 RID: 99664 RVA: 0x006CFFA0 File Offset: 0x006CE1A0
	public virtual void TriggerEvents(EBuffTriggerType passiveEffectType, [Nullable(2)] BaseBuffComponent opponentBuffComp, Partial_RequirementPayload payload)
	{
		if (opponentBuffComp == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.EmitWithTarget<EBuffTriggerType, BaseBuffComponent, Partial_RequirementPayload>(base.Entity, EEventName.OnBuffTriggerEvent, passiveEffectType, opponentBuffComp, payload);
		List<IBuffTrigger> list;
		if (!this.TriggerMap.TryGetValue(passiveEffectType, out list))
		{
			return;
		}
		IBuffTrigger[] array = list.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].TryExecute(payload, opponentBuffComp);
		}
	}

	// Token: 0x06018551 RID: 99665 RVA: 0x006CFFF8 File Offset: 0x006CE1F8
	[return: Nullable(2)]
	public static Entity ShouldForwardToFrontChar(Entity entity)
	{
		FollowShooterComponent component = entity.GetComponent<FollowShooterComponent>();
		if (!component.IsAutonomousProxy)
		{
			return null;
		}
		SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
		bool flag;
		if (getCurrentTeamItem == null)
		{
			flag = (null != null);
		}
		else
		{
			EntityHandle entityHandle = getCurrentTeamItem.EntityHandle;
			flag = (((entityHandle != null) ? entityHandle.Entity : null) != null);
		}
		if (!flag)
		{
			return null;
		}
		WorldEntity entity2 = getCurrentTeamItem.EntityHandle.Entity;
		CreatureDataComponent component2 = entity2.GetComponent<CreatureDataComponent>();
		if (component2 == null)
		{
			return null;
		}
		int roleId = component2.GetRoleId();
		if (component.GetApplyTriggerRoles().Contains(roleId))
		{
			return entity2;
		}
		return null;
	}

	// Token: 0x06018552 RID: 99666 RVA: 0x006D006F File Offset: 0x006CE26F
	public static bool IsFollowShooterByEntity(Entity entity)
	{
		return entity.GetComponent<FollowShooterComponent>() != null;
	}

	// Token: 0x06018553 RID: 99667 RVA: 0x006D007C File Offset: 0x006CE27C
	public bool HasBuffTrigger(EBuffTriggerType effectType)
	{
		return this.TriggerMap.ContainsKey(effectType);
	}

	// Token: 0x06018554 RID: 99668 RVA: 0x006D008C File Offset: 0x006CE28C
	public int AddGameplayCue(long[] cueIds, float duration, string reason)
	{
		if (cueIds == null || cueIds.Length == 0)
		{
			return -1;
		}
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.CreateDynamicBuffRef();
		buffDefinition.GameplayCueIds = cueIds;
		buffDefinition.Desc = reason;
		buffDefinition.DurationPolicy = ((duration == 0f) ? EBuffDurationType.Instant : ((duration < 0f) ? EBuffDurationType.Infinite : EBuffDurationType.HasDuration));
		if (duration > 0f)
		{
			buffDefinition.DurationCalculationPolicy = new int[1];
			buffDefinition.DurationMagnitude = new float[]
			{
				duration
			};
		}
		return this.AddBuffInner(-3L, buffDefinition, null, 1, null, new ApplyGEType?(ApplyGEType.Common), null, null, new float?(duration), null, -1, reason, false, true, false, null, null, null);
	}

	// Token: 0x06018555 RID: 99669 RVA: 0x006D0160 File Offset: 0x006CE360
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.ApplyGameplayEffectNotify, false, false)]
	public static void BroadcastAddBuffNotify(Entity entity, [Nullable(1)] ApplyGameplayEffectNotify data, CombatCommon combatCommon = null)
	{
		int handle = data.Handle;
		long id = data.Id;
		long instigatorId = data.InstigatorId;
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long value = Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.PreMessageId : -1L);
		long value2 = Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.MessageId : -1L);
		if (baseBuffComponent == null || !baseBuffComponent.Valid)
		{
			return;
		}
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(id, null);
		long num = 0L;
		if (data.ConfBuffId != 0L)
		{
			num = data.ConfBuffId;
			BuffDefinition buffDefinition2 = ControllerBase<BuffController>.Instance.GetBuffDefinition(num, null);
			if (buffDefinition2 != null)
			{
				buffDefinition = buffDefinition2;
			}
		}
		if (buffDefinition != null && handle != -1)
		{
			BaseTagComponent tagComponent = baseBuffComponent.GetTagComponent();
			if (tagComponent != null && buffDefinition.RemoveBuffWithTags != null)
			{
				foreach (int value3 in buffDefinition.RemoveBuffWithTags)
				{
					tagComponent.RemoveTag(new int?(value3));
				}
			}
			baseBuffComponent.AddBuffRemote(id, handle, num, new AddBuffParam
			{
				IsActive = new bool?(data.IsActive),
				InstigatorId = instigatorId,
				Level = new int?(data.Level),
				ApplyType = new ApplyGEType?(data.ApplyType),
				PreMessageId = new long?(value),
				MessageId = new long?(value2),
				ServerId = new int?(data.ServerId),
				Duration = (data.HasDuration ? new float?(data.Duration) : null),
				OuterStackCount = new int?(data.StackCount),
				RemainDuration = (data.HasLeftDuration ? new float?(data.LeftDuration) : null),
				Reason = "远端通知添加buff"
			});
		}
	}

	// Token: 0x06018556 RID: 99670 RVA: 0x006D033C File Offset: 0x006CE53C
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.ApplyBuffFailedNotify, false, false)]
	public static void BroadcastAddBuffFailedNotify(Entity entity, [Nullable(1)] ApplyBuffFailedNotify data, CombatCommon combatCommon = null)
	{
		long instigatorId = data.InstigatorId;
		EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(instigatorId);
		WorldEntity worldEntity = (entity2 != null) ? entity2.Entity : null;
		long buffId = data.BuffId;
		if (entity == null || worldEntity == null)
		{
			return;
		}
		SceneTeamController instance = ControllerBase<SceneTeamController>.Instance;
		Entity target = worldEntity;
		EAbilityEventName name = EAbilityEventName.AddBuffFailure;
		long key = buffId;
		long arg = buffId;
		Entity arg2 = worldEntity;
		int stackCount = data.StackCount;
		MathUtils instance2 = Singleton<MathUtils>.Instance;
		TransferContextId transferContextId = data.TransferContextId;
		instance.EmitAbilityEvent<long, Entity, Entity, int, long?>(target, name, key, arg, entity, arg2, stackCount, new long?(instance2.LongToBigInt((transferContextId != null) ? transferContextId.BulletContextId : 0L)));
	}

	// Token: 0x06018557 RID: 99671 RVA: 0x006D03B0 File Offset: 0x006CE5B0
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.BuffStackCountNotify, false, false)]
	public static void BroadcastBuffStackChangedNotify(Entity entity, [Nullable(1)] BuffStackCountNotify data, CombatCommon combatCommon = null)
	{
		int handleId = data.HandleId;
		int newStackCount = data.NewStackCount;
		long instigatorId = data.InstigatorId;
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		ActiveBuffInternal activeBuffInternal = ((baseBuffComponent != null) ? baseBuffComponent.GetBuffByHandle(handleId) : null) as ActiveBuffInternal;
		if (baseBuffComponent != null && activeBuffInternal != null)
		{
			if (activeBuffInternal.StackCount > newStackCount)
			{
				baseBuffComponent.OnBuffStackDecreased(activeBuffInternal, activeBuffInternal.StackCount, newStackCount, true, "远端Buff层数变化通知", data.NotRefreshPeriod ? EBuffStackPeriodResetOverride.ForceNoRefresh : EBuffStackPeriodResetOverride.Default, new long?(instigatorId));
			}
			else if (activeBuffInternal.StackCount <= newStackCount)
			{
				EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(instigatorId);
				WorldEntity worldEntity = (entity2 != null) ? entity2.Entity : null;
				if (worldEntity != null)
				{
					ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, Entity, Entity, bool?>(worldEntity, EAbilityEventName.AddBuffToOthers, activeBuffInternal.Id, activeBuffInternal.Id, baseBuffComponent.Entity, worldEntity, null);
				}
				ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long, int>(entity, EAbilityEventName.OnBuffAdd, activeBuffInternal.Id, activeBuffInternal.Id, handleId);
				baseBuffComponent.OnBuffStackIncreased(activeBuffInternal, activeBuffInternal.StackCount, newStackCount, new long?(instigatorId), activeBuffInternal.Level, null, ApplyGEType.Common, null, null, activeBuffInternal.ServerId, false, false, "远端Buff层数变化通知", data.NotRefreshDuration ? EBuffStackDurationOverride.ForceNoRefresh : EBuffStackDurationOverride.Default, data.NotRefreshPeriod ? EBuffStackPeriodResetOverride.ForceNoRefresh : EBuffStackPeriodResetOverride.Default);
			}
			if (data.HasDuration)
			{
				activeBuffInternal.SetDuration(new float?(data.Duration));
			}
			if (data.HasLeftDuration)
			{
				activeBuffInternal.SetRemainDuration(data.LeftDuration);
			}
		}
	}

	// Token: 0x06018558 RID: 99672 RVA: 0x006D053C File Offset: 0x006CE73C
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.RemoveGameplayEffectNotify, false, false)]
	public unsafe static void BroadcastRemoveBuffNotify(Entity entity, [Nullable(1)] RemoveGameplayEffectNotify data, CombatCommon combatCommon = null)
	{
		int handle = data.Handle;
		long instigatorId = data.InstigatorId;
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		if (baseBuffComponent == null || !baseBuffComponent.Valid)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			string message = "Invalid entity when processing RemoveGameplayEffectNotify";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entity id", data.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", data.Handle);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		baseBuffComponent.RemoveBuffInner(handle, -1, true, "远端通知移除buff", null, null, new long?(instigatorId));
	}

	// Token: 0x06018559 RID: 99673 RVA: 0x006D0604 File Offset: 0x006CE804
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.BuffDurationNotify, false, false)]
	public static void BuffDurationNotify(Entity entity, [Nullable(1)] BuffDurationNotify data, CombatCommon combatCommon = null)
	{
		int handleId = data.HandleId;
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		ActiveBuffInternal activeBuffInternal = ((baseBuffComponent != null) ? baseBuffComponent.GetBuffByHandle(handleId) : null) as ActiveBuffInternal;
		if (baseBuffComponent == null || activeBuffInternal == null)
		{
			return;
		}
		if (data.HasDuration)
		{
			activeBuffInternal.SetDuration(new float?(data.Duration));
		}
		if (data.HasLeftDuration)
		{
			activeBuffInternal.SetRemainDuration(data.LeftDuration);
		}
	}

	// Token: 0x0601855A RID: 99674 RVA: 0x006D066C File Offset: 0x006CE86C
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.ApplyBuffS2cRequestNotify, false, true)]
	public static void OrderAddBuffS2cNotify(Entity entity, [Nullable(1)] ApplyBuffS2cRequestNotify data, CombatCommon combatCommon = null)
	{
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long id = data.Id;
		long instigatorId = data.InstigatorId;
		long value = Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.MessageId : -1L);
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(id, null);
		ApplyBuffS2cResponsePush applyBuffS2cResponsePush = new ApplyBuffS2cResponsePush();
		if (entity == null || (baseBuffComponent == null || !baseBuffComponent.Valid) || buffDefinition == null)
		{
			applyBuffS2cResponsePush.ErrorCode = Aki.Protocol.ErrorCode.UnKnownError;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.ApplyBuffS2cResponsePush, entity, applyBuffS2cResponsePush, new long?(value), null, new bool?(true));
			return;
		}
		BaseTagComponent tagComponent = baseBuffComponent.GetTagComponent();
		if (tagComponent != null && buffDefinition.RemoveBuffWithTags != null)
		{
			foreach (int value2 in buffDefinition.RemoveBuffWithTags)
			{
				tagComponent.RemoveTag(new int?(value2));
			}
		}
		int num = baseBuffComponent.AddBuffInner(id, ControllerBase<BuffController>.Instance.GetBuffDefinition(id, null), new long?(instigatorId), data.Level, new int?(data.StackCount), new ApplyGEType?(data.ApplyType), new long?(value), null, data.HasDuration ? new float?(data.Duration) : null, null, data.ServerId, "远端请求添加玩家Buff(s2c)", false, data.IsIterable, true, null, null, null);
		ActiveBuffInternal valueOrDefault = baseBuffComponent.BuffContainer.GetValueOrDefault(num);
		applyBuffS2cResponsePush.Handle = num;
		applyBuffS2cResponsePush.IsActive = (valueOrDefault != null && valueOrDefault.IsActive());
		applyBuffS2cResponsePush.ErrorCode = Aki.Protocol.ErrorCode.Success;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.ApplyBuffS2cResponsePush, entity, applyBuffS2cResponsePush, new long?(value), null, new bool?(true));
	}

	// Token: 0x0601855B RID: 99675 RVA: 0x006D0854 File Offset: 0x006CEA54
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.RemoveBuffS2cRequestNotify, false, false)]
	public static void OrderRemoveBuffS2cNotify(Entity entity, [Nullable(1)] RemoveBuffS2cRequestNotify data, CombatCommon combatCommon = null)
	{
		object obj = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long value = Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.MessageId : -1L);
		long instigatorId = data.InstigatorId;
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.RemoveBuffByHandle(data.Handle, data.StackCount, "远端请求移除buff(s2c)", new long?(value), new bool?(true), new long?(instigatorId));
		}
		RemoveBuffS2cResponsePush removeBuffS2cResponsePush = new RemoveBuffS2cResponsePush();
		removeBuffS2cResponsePush.ErrorCode = Aki.Protocol.ErrorCode.Success;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RemoveBuffS2cResponsePush, entity, removeBuffS2cResponsePush, new long?(value), null, new bool?(true));
	}

	// Token: 0x0601855C RID: 99676 RVA: 0x006D08F0 File Offset: 0x006CEAF0
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.RemoveBuffByIdS2cRequestNotify, false, false)]
	public unsafe static void OrderRemoveBuffByIdS2cNotify(Entity entity, [Nullable(1)] RemoveBuffByIdS2cRequestNotify data, CombatCommon combatCommon = null)
	{
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long buffId = data.BuffId;
		long value = Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.MessageId : -1L);
		RemoveBuffByIdS2cResponsePush removeBuffByIdS2cResponsePush = new RemoveBuffByIdS2cResponsePush();
		long instigatorId = data.InstigatorId;
		if (baseBuffComponent == null || !baseBuffComponent.Valid)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			string message = "Invalid entity when processing RemoveBuffByIdS2cRequestNotify";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entity id", (entity != null) ? new int?(entity.Id) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", buffId);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			removeBuffByIdS2cResponsePush.ErrorCode = Aki.Protocol.ErrorCode.UnKnownError;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.RemoveBuffByIdS2cResponsePush, entity, removeBuffByIdS2cResponsePush, new long?(value), null, new bool?(true));
			return;
		}
		BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
		long buffId2 = buffId;
		int stackCount = data.StackCount;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
		defaultInterpolatedStringHandler.AppendLiteral("远端移除buff(s2c) reason=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.Reason);
		baseBuffComponent2.RemoveBuff(buffId2, stackCount, defaultInterpolatedStringHandler.ToStringAndClear(), new long?(value), new bool?(true), new long?(instigatorId));
		removeBuffByIdS2cResponsePush.ErrorCode = Aki.Protocol.ErrorCode.Success;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RemoveBuffByIdS2cResponsePush, entity, removeBuffByIdS2cResponsePush, new long?(value), null, new bool?(true));
	}

	// Token: 0x0601855D RID: 99677 RVA: 0x006D0A68 File Offset: 0x006CEC68
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.RemoveBuffByServerIdS2cRequestNotify, false, false)]
	public unsafe static void OrderRemoveBuffByServerIdNotify(Entity entity, [Nullable(1)] RemoveBuffByServerIdS2cRequestNotify data, CombatCommon combatCommon = null)
	{
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		if (baseBuffComponent == null || !baseBuffComponent.HasBuffAuthority())
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			string message = "[buffComp] 服务端通知移除非主控buff";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("serverId", data.ServerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", data.Reason);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		int serverId = data.ServerId;
		int reason = data.Reason;
		int stackCount = data.StackCount;
		long num = Singleton<MathUtils>.Instance.LongToBigInt((combatCommon != null) ? combatCommon.MessageId : -1L);
		long instigatorId = data.InstigatorId;
		BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
		int serverId2 = serverId;
		int stackCount2 = stackCount;
		long preMessageId = num;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
		defaultInterpolatedStringHandler.AppendLiteral("远端移除buff(s2c):");
		defaultInterpolatedStringHandler.AppendFormatted<int>(reason);
		baseBuffComponent2.RemoveBuffByServerId(serverId2, stackCount2, preMessageId, defaultInterpolatedStringHandler.ToStringAndClear(), new long?(instigatorId));
	}

	// Token: 0x0601855E RID: 99678 RVA: 0x006D0B60 File Offset: 0x006CED60
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.OrderApplyBuffNotify, false, false)]
	public unsafe static void OrderAddBuffNotify(Entity entity, [Nullable(1)] OrderApplyBuffNotify data, CombatCommon combatCommon = null)
	{
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.CheckGetComponent<BaseBuffComponent>() : null;
		if (baseBuffComponent == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			string message = "收到服务端请求添加buff，但找不到对应的entity";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entity", entity);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", data.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("InstigatorId", data.InstigatorId);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (baseBuffComponent != null)
		{
			long id = data.Id;
			BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
			long buffId = id;
			AddBuffParam addBuffParam = new AddBuffParam();
			addBuffParam.InstigatorId = data.InstigatorId;
			addBuffParam.Level = new int?(data.Level);
			addBuffParam.ApplyType = new ApplyGEType?(data.ApplyType);
			long? preMessageId;
			if (combatCommon != null)
			{
				long messageId = combatCommon.MessageId;
				if (combatCommon.MessageId != 0L)
				{
					preMessageId = new long?(combatCommon.MessageId);
					goto IL_F9;
				}
			}
			preMessageId = null;
			IL_F9:
			addBuffParam.PreMessageId = preMessageId;
			addBuffParam.Duration = (data.HasDuration ? new float?(data.Duration) : null);
			addBuffParam.IsIterable = new bool?(data.IsIterable);
			addBuffParam.OuterStackCount = new int?(data.StackCount);
			addBuffParam.ServerId = new int?(data.ServerId);
			addBuffParam.IsServerOrder = new bool?(true);
			addBuffParam.Reason = "服务端或其它客户端请求添加Buff";
			baseBuffComponent2.AddBuffLocal(buffId, addBuffParam);
		}
	}

	// Token: 0x0601855F RID: 99679 RVA: 0x006D0CE0 File Offset: 0x006CEEE0
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.OrderRemoveBuffNotify, false, false)]
	public unsafe static void OrderRemoveBuffNotify(Entity entity, [Nullable(1)] OrderRemoveBuffNotify data, CombatCommon combatCommon = null)
	{
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long id = data.Id;
		if (baseBuffComponent == null)
		{
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(id, null);
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			string message = "[order] 移除Buff请求找不到对应实体";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", (entity != null) ? entity.Id : 0);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("说明", ((buffDefinition != null) ? buffDefinition.Desc : null) ?? "");
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		baseBuffComponent.RemoveBuffLocal(id, data.StackCount, "服务端或其它客户端请求本端移除buff", null, null, null);
	}

	// Token: 0x06018560 RID: 99680 RVA: 0x006D0DD8 File Offset: 0x006CEFD8
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.OrderRemoveBuffByTagsNotify, false, false)]
	public static void OrderRemoveBuffByTagsNotify(Entity entity, [Nullable(1)] OrderRemoveBuffByTagsNotify data, CombatCommon combatCommon = null)
	{
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long instigatorId = data.InstigatorId;
		if (baseBuffComponent == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (int tagId in data.TagIds)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(GameplayTagUtils.GetNameByTagId(tagId) ?? "");
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			string message = "[order] 根据tag移除Buff请求找不到对应实体";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagId", stringBuilder);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		foreach (int tagId2 in data.TagIds)
		{
			string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId2);
			baseBuffComponent.RemoveBuffByTagLocal(tagId2, "远端请求根据tag " + nameByTagId + " 移除buff", new long?(instigatorId));
		}
	}

	// Token: 0x06018561 RID: 99681 RVA: 0x006D0EFC File Offset: 0x006CF0FC
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.ActivateBuffNotify, false, false)]
	public unsafe static void BroadcastActivateBuffNotify(Entity entity, [Nullable(1)] ActivateBuffNotify data, CombatCommon combatCommon = null)
	{
		BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		int handle = data.Handle;
		bool on = data.On;
		ActiveBuffInternal activeBuffInternal = ((baseBuffComponent != null) ? baseBuffComponent.GetBuffByHandle(handle) : null) as ActiveBuffInternal;
		if (baseBuffComponent == null || baseBuffComponent.HasBuffAuthority())
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			string message = "主端收到了非主控端发来的buff激活状态变更请求，或找不到Buff持有者，将不做处理";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handle", handle);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", (activeBuffInternal != null) ? activeBuffInternal.Id : 0L);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("本地激活状态", on);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("远端激活状态", data.On);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return;
		}
		baseBuffComponent.OnBuffActiveChanged(activeBuffInternal, on);
	}

	// Token: 0x06018562 RID: 99682 RVA: 0x006D0FF4 File Offset: 0x006CF1F4
	[NullableContext(2)]
	[CombatListen(ENotifyMessageId.TransformBuffStackNotify, false, false)]
	public static void BroadcastTransformBuffStackNotify(Entity entity, [Nullable(1)] TransformBuffStackNotify data, CombatCommon combatCommon = null)
	{
		object obj = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
		long buffId = data.BuffId;
		int handle = (int)data.BuffHandle;
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.AddBuffStackModifier(buffId, handle, data.StackLimit, EBuffStackModifierType.Incremental);
	}

	// Token: 0x06018563 RID: 99683 RVA: 0x006D1030 File Offset: 0x006CF230
	public void AddBuffTimeModifier(long targetBuffId, int handle, float period, float duration, bool asInstigator)
	{
		if (period == 0f && duration == 0f)
		{
			return;
		}
		Dictionary<long, Dictionary<int, ValueTuple<float, float>>> dictionary = asInstigator ? this.InstigatorBuffTimeModifiers : this.OwnerBuffTimeModifiers;
		Dictionary<int, ValueTuple<float, float>> dictionary2;
		if (!dictionary.TryGetValue(targetBuffId, out dictionary2))
		{
			dictionary2 = new Dictionary<int, ValueTuple<float, float>>();
			dictionary[targetBuffId] = dictionary2;
		}
		dictionary2[handle] = new ValueTuple<float, float>(period, duration);
	}

	// Token: 0x06018564 RID: 99684 RVA: 0x006D108C File Offset: 0x006CF28C
	public void RemoveBuffTimeModifier(long targetBuffId, int handle, bool asInstigator)
	{
		Dictionary<long, Dictionary<int, ValueTuple<float, float>>> dictionary = asInstigator ? this.InstigatorBuffTimeModifiers : this.OwnerBuffTimeModifiers;
		Dictionary<int, ValueTuple<float, float>> dictionary2;
		if (dictionary.TryGetValue(targetBuffId, out dictionary2))
		{
			dictionary2.Remove(handle);
			if (dictionary2.Count <= 0)
			{
				dictionary.Remove(targetBuffId);
			}
		}
	}

	// Token: 0x06018565 RID: 99685 RVA: 0x006D10D0 File Offset: 0x006CF2D0
	[NullableContext(2)]
	public float CalculateDurationRate(long buffId, BaseBuffComponent instigator)
	{
		float num = this.CalculateDurationExtraRate(buffId, false);
		if (instigator != null)
		{
			num += instigator.CalculateDurationExtraRate(buffId, true);
		}
		return Math.Max(1E-08f, 1f + num * 0.0001f);
	}

	// Token: 0x06018566 RID: 99686 RVA: 0x006D110C File Offset: 0x006CF30C
	public virtual float CalculateDurationExtraRate(long buffId, bool asInstigator)
	{
		Dictionary<int, ValueTuple<float, float>> dictionary;
		if (!(asInstigator ? this.InstigatorBuffTimeModifiers : this.OwnerBuffTimeModifiers).TryGetValue(buffId, out dictionary) || dictionary.Count <= 0)
		{
			return 0f;
		}
		float num = 0f;
		foreach (ValueTuple<float, float> valueTuple in dictionary.Values)
		{
			float item = valueTuple.Item2;
			num += item;
		}
		return num;
	}

	// Token: 0x06018567 RID: 99687 RVA: 0x006D1194 File Offset: 0x006CF394
	[NullableContext(2)]
	public float CalculatePeriodRate(long buffId, BaseBuffComponent instigator)
	{
		float num = this.CalculatePeriodExtraRate(buffId, false);
		if (instigator != null)
		{
			num += instigator.CalculatePeriodExtraRate(buffId, true);
		}
		return Math.Max(1E-08f, 1f + num * 0.0001f);
	}

	// Token: 0x06018568 RID: 99688 RVA: 0x006D11D0 File Offset: 0x006CF3D0
	public virtual float CalculatePeriodExtraRate(long buffId, bool asInstigator)
	{
		Dictionary<int, ValueTuple<float, float>> dictionary;
		if (!(asInstigator ? this.InstigatorBuffTimeModifiers : this.OwnerBuffTimeModifiers).TryGetValue(buffId, out dictionary) || dictionary.Count <= 0)
		{
			return 1f;
		}
		float num = 0f;
		foreach (ValueTuple<float, float> valueTuple in dictionary.Values)
		{
			float item = valueTuple.Item1;
			num += item;
		}
		return num;
	}

	// Token: 0x06018569 RID: 99689 RVA: 0x006D1258 File Offset: 0x006CF458
	protected void OnRefreshBuffDuration(long[] buffIds, [Nullable(2)] string reason)
	{
		RefreshBuffDurationPush refreshBuffDurationPush = RefreshBuffDurationPush.Create();
		refreshBuffDurationPush.BuffIds.AddRange(buffIds);
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RefreshBuffDurationPush, base.Entity, refreshBuffDurationPush, null, null, null);
		foreach (long buffId in buffIds)
		{
			foreach (ActiveBuffInternal activeBuffInternal in this.GetAllBuffById(buffId))
			{
				activeBuffInternal.SetDuration(null);
			}
		}
	}

	// Token: 0x0601856A RID: 99690 RVA: 0x006D1314 File Offset: 0x006CF514
	protected virtual void RefreshBuffDurationOrder(long[] buffIds, [Nullable(2)] string reason)
	{
	}

	// Token: 0x0601856B RID: 99691 RVA: 0x006D1316 File Offset: 0x006CF516
	public void RefreshBuffDuration(long[] buffIds, [Nullable(2)] string reason)
	{
		if (this.HasBuffAuthority())
		{
			this.OnRefreshBuffDuration(buffIds, reason);
			return;
		}
		this.RefreshBuffDurationOrder(buffIds, reason);
	}

	// Token: 0x0601856C RID: 99692 RVA: 0x006D1334 File Offset: 0x006CF534
	public void AddBuffStackModifier(long targetBuffId, int handle, int value, EBuffStackModifierType modifierType = EBuffStackModifierType.Incremental)
	{
		if (!this.CheckBuffStackChangeable(targetBuffId))
		{
			return;
		}
		if (value == 0)
		{
			return;
		}
		Dictionary<int, BuffStackModifierValue> dictionary;
		if (!this.BuffStackModifiers.TryGetValue(targetBuffId, out dictionary))
		{
			dictionary = new Dictionary<int, BuffStackModifierValue>();
			this.BuffStackModifiers[targetBuffId] = dictionary;
		}
		dictionary[handle] = new BuffStackModifierValue
		{
			Value = value,
			Type = modifierType
		};
		this.RefreshBuffStack(targetBuffId);
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long>(base.Entity, EAbilityEventName.OnBuffMaxStackModifier, targetBuffId, targetBuffId);
	}

	// Token: 0x0601856D RID: 99693 RVA: 0x006D13A8 File Offset: 0x006CF5A8
	public void RemoveBuffStackModifier(long targetBuffId, int handle)
	{
		if (!this.CheckBuffStackChangeable(targetBuffId))
		{
			return;
		}
		Dictionary<int, BuffStackModifierValue> dictionary;
		if (this.BuffStackModifiers.TryGetValue(targetBuffId, out dictionary))
		{
			dictionary.Remove(handle);
			if (dictionary.Count <= 0)
			{
				this.BuffStackModifiers.Remove(targetBuffId);
			}
		}
		this.RefreshBuffStack(targetBuffId);
		ControllerBase<SceneTeamController>.Instance.EmitAbilityEvent<long>(base.Entity, EAbilityEventName.OnBuffMaxStackModifier, targetBuffId, targetBuffId);
	}

	// Token: 0x0601856E RID: 99694 RVA: 0x006D1408 File Offset: 0x006CF608
	public int? CalculateBuffStackMaxByConfig(BuffDefinition config, long buffId)
	{
		if (config.StackLimitCount <= 0)
		{
			return new int?(int.MaxValue);
		}
		int num = 0;
		Dictionary<int, BuffStackModifierValue> dictionary;
		if (this.BuffStackModifiers.TryGetValue(buffId, out dictionary))
		{
			foreach (BuffStackModifierValue buffStackModifierValue in dictionary.Values)
			{
				if (buffStackModifierValue.Type == EBuffStackModifierType.Incremental)
				{
					num += buffStackModifierValue.Value;
				}
				else if (buffStackModifierValue.Type == EBuffStackModifierType.Override)
				{
					return new int?(buffStackModifierValue.Value);
				}
			}
		}
		return new int?(Math.Max(1, config.StackLimitCount + num));
	}

	// Token: 0x0601856F RID: 99695 RVA: 0x006D14BC File Offset: 0x006CF6BC
	public int? CalculateBuffStackMax(long buffId)
	{
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, null);
		if (buffDefinition == null)
		{
			return new int?(0);
		}
		if (buffDefinition.StackLimitCount <= 0)
		{
			return new int?(int.MaxValue);
		}
		int num = 0;
		Dictionary<int, BuffStackModifierValue> dictionary;
		if (this.BuffStackModifiers.TryGetValue(buffId, out dictionary))
		{
			foreach (BuffStackModifierValue buffStackModifierValue in dictionary.Values)
			{
				if (buffStackModifierValue.Type == EBuffStackModifierType.Incremental)
				{
					num += buffStackModifierValue.Value;
				}
				else if (buffStackModifierValue.Type == EBuffStackModifierType.Override)
				{
					return new int?(buffStackModifierValue.Value);
				}
			}
		}
		return new int?(Math.Max(1, buffDefinition.StackLimitCount + num));
	}

	// Token: 0x06018570 RID: 99696 RVA: 0x006D158C File Offset: 0x006CF78C
	public int RefreshBuffStackMax(long buffId)
	{
		ActiveBuffInternal buffById = this.GetBuffById(buffId);
		if (buffById == null)
		{
			return 0;
		}
		int? num = this.CalculateBuffStackMax(buffId);
		if (num == null)
		{
			return 0;
		}
		if (num.GetValueOrDefault() == 2147483647)
		{
			return int.MaxValue;
		}
		buffById.StackLimitCount = num.Value;
		return buffById.StackLimitCount;
	}

	// Token: 0x06018571 RID: 99697 RVA: 0x006D15E0 File Offset: 0x006CF7E0
	public void RefreshBuffStack(long buffId)
	{
		ActiveBuffInternal buffById = this.GetBuffById(buffId);
		if (buffById == null)
		{
			return;
		}
		int stackCount = buffById.StackCount;
		int num = this.RefreshBuffStackMax(buffId);
		if (num < stackCount)
		{
			if (this.HasBuffAuthority())
			{
				ExtraEffectManager buffEffectManager = this.BuffEffectManager;
				if (buffEffectManager != null)
				{
					buffEffectManager.OnBuffStackOverflow(buffById, stackCount, stackCount, num);
				}
			}
			this.OnBuffStackDecreased(buffById, stackCount, num, true, "buff层数修改器导致", EBuffStackPeriodResetOverride.Default, null);
		}
	}

	// Token: 0x06018572 RID: 99698 RVA: 0x006D1644 File Offset: 0x006CF844
	public bool CheckBuffStackChangeable(long buffId)
	{
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, null);
		return buffDefinition != null && buffDefinition.StackLimitCount > 0;
	}

	// Token: 0x06018573 RID: 99699 RVA: 0x006D166C File Offset: 0x006CF86C
	public void ChangeBuffStack(long buffId, EBuffStackDurationOverride stackDurationRefreshPolicy, EBuffStackPeriodResetOverride stackPeriodResetPolicy, int stackChange, string reason, long? instigatorId = null)
	{
		if (!this.HasBuffAuthority())
		{
			return;
		}
		foreach (ActiveBuffInternal activeBuffInternal in this.GetAllBuffById(buffId))
		{
			int stackCount = activeBuffInternal.StackCount;
			int stackLimitCount = activeBuffInternal.StackLimitCount;
			int num = Math.Min(stackCount + stackChange, stackLimitCount);
			if (num <= 0)
			{
				this.RemoveBuffInner(activeBuffInternal.Handle, -1, true, reason, null, null, instigatorId);
			}
			else if (num < stackCount)
			{
				this.OnBuffStackDecreased(activeBuffInternal, stackCount, num, true, reason, stackPeriodResetPolicy, instigatorId);
			}
			else if (num > stackCount)
			{
				this.OnBuffStackIncreased(activeBuffInternal, stackCount, num, instigatorId, activeBuffInternal.Level, null, ApplyGEType.Common, null, null, activeBuffInternal.ServerId, false, false, reason, stackDurationRefreshPolicy, stackPeriodResetPolicy);
			}
		}
	}

	// Token: 0x06018574 RID: 99700 RVA: 0x006D1764 File Offset: 0x006CF964
	public void SetDeferredCueCreationEnable(bool enable)
	{
		this.EnableDeferredCueCreation = enable;
	}

	// Token: 0x06018575 RID: 99701 RVA: 0x006D1770 File Offset: 0x006CF970
	public void ProcessPendingCues()
	{
		while (this.PendingInstantCues.Count > 0)
		{
			if (ControllerBase<BuffController>.Instance.CueTimeLimit.IsTimeLimitExceeded())
			{
				break;
			}
			double microseconds = KuroTime.GetMicroseconds64();
			BaseBuffComponent.PendingInstantCueItem pendingInstantCueItem = this.PendingInstantCues[0];
			this.PendingInstantCues.RemoveAt(0);
			BaseGameplayCueComponent cueComponent = this.GetCueComponent();
			if (cueComponent != null)
			{
				cueComponent.AddCue(pendingInstantCueItem.CueId, new GameplayCueParam?(pendingInstantCueItem.Param));
			}
			double microseconds2 = KuroTime.GetMicroseconds64();
			ControllerBase<BuffController>.Instance.CueTimeLimit.AddCost(microseconds2 - microseconds);
		}
		while (this.PendingDestroyCueBuffs.Count > 0)
		{
			if (ControllerBase<BuffController>.Instance.CueTimeLimit.IsTimeLimitExceeded())
			{
				break;
			}
			double microseconds3 = KuroTime.GetMicroseconds64();
			int? num = null;
			using (HashSet<int>.Enumerator enumerator = this.PendingDestroyCueBuffs.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					int value = enumerator.Current;
					num = new int?(value);
				}
			}
			if (num != null)
			{
				this.PendingDestroyCueBuffs.Remove(num.Value);
				this.DestroyGameplayCueByBuffImmediate(num.Value);
			}
			double microseconds4 = KuroTime.GetMicroseconds64();
			ControllerBase<BuffController>.Instance.CueTimeLimit.AddCost(microseconds4 - microseconds3);
		}
		while (this.PendingCreateCueBuffs.Count > 0 && !ControllerBase<BuffController>.Instance.CueTimeLimit.IsTimeLimitExceeded())
		{
			double microseconds5 = KuroTime.GetMicroseconds64();
			int? num2 = null;
			using (HashSet<int>.Enumerator enumerator = this.PendingCreateCueBuffs.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					int value2 = enumerator.Current;
					num2 = new int?(value2);
				}
			}
			if (num2 != null)
			{
				this.PendingCreateCueBuffs.Remove(num2.Value);
				IActiveBuff buffByHandle = this.GetBuffByHandle(num2.Value);
				if (buffByHandle != null && buffByHandle.IsActive() && !this.Buff2CueMap.ContainsKey(num2.Value))
				{
					this.CreateGameplayCueByBuffImmediate(buffByHandle);
				}
			}
			double microseconds6 = KuroTime.GetMicroseconds64();
			ControllerBase<BuffController>.Instance.CueTimeLimit.AddCost(microseconds6 - microseconds5);
		}
		if (this.PendingCreateCueBuffs.Count == 0 && this.PendingDestroyCueBuffs.Count == 0 && this.PendingInstantCues.Count == 0)
		{
			ControllerBase<BuffController>.Instance.UnregisterBuffComponent(this);
		}
	}

	// Token: 0x06018576 RID: 99702 RVA: 0x006D19E4 File Offset: 0x006CFBE4
	protected void CreateGameplayCueByBuff(IActiveBuff buff)
	{
		if (buff.Config.GameplayCueIds == null || buff.Config.GameplayCueIds.Length == 0)
		{
			return;
		}
		if (this.PendingDestroyCueBuffs.Contains(buff.Handle))
		{
			this.PendingDestroyCueBuffs.Remove(buff.Handle);
			return;
		}
		if (!this.EnableDeferredCueCreation)
		{
			this.CreateGameplayCueByBuffImmediate(buff);
			return;
		}
		if (buff.IsInstantBuff())
		{
			Entity instigator = buff.GetInstigator();
			foreach (long cueId in buff.Config.GameplayCueIds)
			{
				long cueId2 = ReplaceAbnormalCueEffect.ApplyEffects(base.Entity, cueId);
				this.PendingInstantCues.Add(new BaseBuffComponent.PendingInstantCueItem
				{
					CueId = cueId2,
					Param = new GameplayCueParam
					{
						Instant = true,
						Instigator = ModelBase<CharacterModel>.Instance.GetHandleByEntity(instigator)
					}
				});
			}
		}
		else
		{
			this.PendingCreateCueBuffs.Add(buff.Handle);
		}
		ControllerBase<BuffController>.Instance.RegisterBuffComponent(this);
	}

	// Token: 0x06018577 RID: 99703 RVA: 0x006D1AE8 File Offset: 0x006CFCE8
	protected void CreateGameplayCueByBuffImmediate(IActiveBuff buff)
	{
		BaseGameplayCueComponent cueComponent = this.GetCueComponent();
		if (cueComponent == null)
		{
			return;
		}
		if (!buff.IsActive())
		{
			return;
		}
		int handle = buff.Handle;
		if (this.Buff2CueMap.ContainsKey(handle))
		{
			return;
		}
		if (this.CreateSeamlessTravelCue(buff, cueComponent))
		{
			return;
		}
		if (buff.Config.GameplayCueIds != null)
		{
			foreach (long cueId in buff.Config.GameplayCueIds)
			{
				long cueId2 = ReplaceAbnormalCueEffect.ApplyEffects(base.Entity, cueId);
				int num = cueComponent.AddCue(cueId2, new GameplayCueParam?(new GameplayCueParam
				{
					Buff = buff,
					Instant = buff.IsInstantBuff(),
					Instigator = ModelBase<CharacterModel>.Instance.GetHandleByEntity(buff.GetInstigator())
				}));
				if (num != -1 && num != 0)
				{
					List<int> list;
					if (!this.Buff2CueMap.TryGetValue(handle, out list))
					{
						list = new List<int>();
						this.Buff2CueMap[handle] = list;
					}
					list.Add(num);
				}
			}
		}
	}

	// Token: 0x06018578 RID: 99704 RVA: 0x006D1BEC File Offset: 0x006CFDEC
	protected void DestroyGameplayCueByBuff(IActiveBuff buff)
	{
		int handle = buff.Handle;
		if (this.PendingCreateCueBuffs.Contains(handle))
		{
			this.PendingCreateCueBuffs.Remove(handle);
			return;
		}
		if (!this.EnableDeferredCueCreation)
		{
			this.DestroyGameplayCueByBuffImmediate(handle);
			return;
		}
		if (!this.Buff2CueMap.ContainsKey(handle))
		{
			return;
		}
		this.PendingDestroyCueBuffs.Add(handle);
		ControllerBase<BuffController>.Instance.RegisterBuffComponent(this);
	}

	// Token: 0x06018579 RID: 99705 RVA: 0x006D1C54 File Offset: 0x006CFE54
	protected void DestroyGameplayCueByBuffImmediate(int buffHandle)
	{
		BaseGameplayCueComponent cueComponent = this.GetCueComponent();
		if (cueComponent == null)
		{
			return;
		}
		List<int> list;
		if (!this.Buff2CueMap.TryGetValue(buffHandle, out list))
		{
			return;
		}
		foreach (int num in list)
		{
			cueComponent.RemoveCueByHandle((long)num);
		}
		this.Buff2CueMap.Remove(buffHandle);
	}

	// Token: 0x0601857A RID: 99706 RVA: 0x006D1CCC File Offset: 0x006CFECC
	protected virtual void OnAnyBuffInhibitionChanged(IActiveBuff buff)
	{
		if (buff.IsActive())
		{
			this.CreateGameplayCueByBuff(buff);
			return;
		}
		this.DestroyGameplayCueByBuff(buff);
	}

	// Token: 0x0601857B RID: 99707 RVA: 0x006D1CE8 File Offset: 0x006CFEE8
	protected unsafe bool CreateSeamlessTravelCue(IActiveBuff buff, BaseGameplayCueComponent cueComp)
	{
		if (this.SeamlessTravelBuffCue == null)
		{
			return false;
		}
		List<List<int>> list;
		if (!this.SeamlessTravelBuffCue.TryGetValue(buff.Id, out list) || list.Count == 0)
		{
			return false;
		}
		List<int> list2 = list[list.Count - 1];
		list.RemoveAt(list.Count - 1);
		this.Buff2CueMap[buff.Handle] = list2;
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "[无缝加载]buff特效复用";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buff.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffHandle", buff.Handle);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("cueHandle", list2);
		instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		foreach (int num in list2)
		{
			cueComp.ChangeBuffHandle((long)num, buff);
		}
		return true;
	}

	// Token: 0x0601857C RID: 99708 RVA: 0x006D1E18 File Offset: 0x006D0018
	protected bool SeamlessTravelBuffRetain(IActiveBuff buff)
	{
		return buff.Id < 0L;
	}

	// Token: 0x0601857D RID: 99709 RVA: 0x006D1E24 File Offset: 0x006D0024
	public void SeamlessTravelingRefresh()
	{
		Singleton<CombatLog>.Instance.Info(CombatLog.EDebugModule.Buff, base.Entity, "[无缝加载]buff刷新", default(ReadOnlySpan<ValueTuple<string, object>>));
		HashSet<IActiveBuff> hashSet = new HashSet<IActiveBuff>();
		foreach (IActiveBuff activeBuff in this.GetAllBuffs())
		{
			if (!this.SeamlessTravelBuffRetain(activeBuff))
			{
				hashSet.Add(activeBuff);
			}
		}
		if (this.SeamlessTravelBuffCue == null)
		{
			this.SeamlessTravelBuffCue = new Dictionary<long, List<List<int>>>();
		}
		foreach (IActiveBuff activeBuff2 in hashSet)
		{
			List<int> item;
			if (this.Buff2CueMap.TryGetValue(activeBuff2.Handle, out item))
			{
				List<List<int>> list;
				if (!this.SeamlessTravelBuffCue.TryGetValue(activeBuff2.Id, out list))
				{
					list = new List<List<int>>();
					this.SeamlessTravelBuffCue[activeBuff2.Id] = list;
				}
				list.Add(item);
				this.Buff2CueMap.Remove(activeBuff2.Handle);
			}
			this.RemoveBuffByHandle(activeBuff2.Handle, -1, "无缝加载移除旧buff", null, null, null);
		}
		this.InitBornBuff();
		BaseGameplayCueComponent cueComponent = this.GetCueComponent();
		if (cueComponent != null)
		{
			foreach (KeyValuePair<long, List<List<int>>> keyValuePair in this.SeamlessTravelBuffCue)
			{
				long num;
				List<List<int>> list2;
				keyValuePair.Deconstruct(out num, out list2);
				foreach (List<int> list3 in list2)
				{
					foreach (int num2 in list3)
					{
						cueComponent.RemoveCueByHandle((long)num2);
					}
				}
			}
		}
		this.SeamlessTravelBuffCue.Clear();
		this.OnSeamlessTravelingRefreshEnd();
	}

	// Token: 0x0601857E RID: 99710 RVA: 0x006D2058 File Offset: 0x006D0258
	protected virtual void OnSeamlessTravelingRefreshEnd()
	{
	}

	// Token: 0x0601857F RID: 99711 RVA: 0x006D205A File Offset: 0x006D025A
	public static void CreateStaticDefaultValue()
	{
		BaseBuffComponent._buffStatMap = new Dictionary<long, Stat>();
	}

	// Token: 0x06018580 RID: 99712 RVA: 0x006D2066 File Offset: 0x006D0266
	public static void ResetStaticDefaultValue()
	{
		BaseBuffComponent._buffStatMap = null;
	}

	// Token: 0x06018581 RID: 99713 RVA: 0x006D206E File Offset: 0x006D026E
	protected void SetBuffComponentType(EBuffComponentType value)
	{
		this.BuffComponentType = value;
	}

	// Token: 0x06018582 RID: 99714 RVA: 0x006D2077 File Offset: 0x006D0277
	public EBuffComponentType GetBuffComponentType()
	{
		return this.BuffComponentType;
	}

	// Token: 0x06018583 RID: 99715 RVA: 0x006D207F File Offset: 0x006D027F
	public bool IsTeamBuffComponent()
	{
		return this.BuffComponentType == EBuffComponentType.TeamBuffComponent;
	}

	// Token: 0x06018584 RID: 99716 RVA: 0x006D208A File Offset: 0x006D028A
	public bool IsRoleBuffComponent()
	{
		return this.BuffComponentType == EBuffComponentType.RoleBuffComponent;
	}

	// Token: 0x06018585 RID: 99717 RVA: 0x006D2095 File Offset: 0x006D0295
	public static List<int> GetCurrentEntityIds()
	{
		return (from handle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true)
		select handle.Id).ToList<int>();
	}

	// Token: 0x06018586 RID: 99718 RVA: 0x006D20CC File Offset: 0x006D02CC
	public static List<int> GetNewOrRemoveTeamEntityIds(List<int> oldTeamEntityIds, bool newEntity = true)
	{
		List<int> currentEntityIds = BaseBuffComponent.GetCurrentEntityIds();
		if (newEntity)
		{
			return (from id in currentEntityIds
			where !oldTeamEntityIds.Contains(id)
			select id).ToList<int>();
		}
		return (from id in oldTeamEntityIds
		where !currentEntityIds.Contains(id)
		select id).ToList<int>();
	}

	// Token: 0x06018587 RID: 99719 RVA: 0x006D2130 File Offset: 0x006D0330
	public List<T> GetTargetComponents<[Nullable(0)] T>(EComponent componentType, long? buffId = null) where T : EntityComponent
	{
		List<T> list = new List<T>();
		if (this.IsTeamBuffComponent())
		{
			using (List<EntityHandle>.Enumerator enumerator = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EntityHandle entityHandle = enumerator.Current;
					WorldEntity entity = entityHandle.Entity;
					T t = (entity != null) ? entity.GetComponent<T>() : default(T);
					if (t != null)
					{
						list.Add(t);
					}
					else if (buffId != null)
					{
						CombatLog instance = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
						Entity entity2 = base.Entity;
						string message = "编队额外效果获取组件失败";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", buffId);
						instance.Error(flag, entity2, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
				return list;
			}
		}
		Entity entity3 = this.GetEntity();
		T t2 = (entity3 != null) ? entity3.GetComponent<T>() : default(T);
		if (t2 != null)
		{
			list.Add(t2);
		}
		else if (buffId != null)
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
			Entity entity4 = base.Entity;
			string message2 = "非编队额外效果获取组件失败";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("buffId", buffId);
			instance2.Error(flag2, entity4, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return list;
	}

	// Token: 0x06018588 RID: 99720 RVA: 0x006D2260 File Offset: 0x006D0460
	public unsafe bool AddReplaceBuff(long originBuffId, BuffReplace replaceBuffInfo)
	{
		if (this.ReplaceBuffMap.ContainsKey(originBuffId))
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "添加重复的buff替换关系";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("originBuffId", originBuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("replaceBuffInfo", replaceBuffInfo);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		CombatLog instance2 = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
		Entity entity2 = base.Entity;
		string message2 = "添加buff替换";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("originBuffId", originBuffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("replaceBuffInfo", replaceBuffInfo);
		instance2.Info(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		this.ReplaceBuffMap[originBuffId] = replaceBuffInfo;
		return true;
	}

	// Token: 0x06018589 RID: 99721 RVA: 0x006D2344 File Offset: 0x006D0544
	public bool RemoveReplaceBuff(long originBuffId)
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "移除buff替换";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("originBuffId", originBuffId);
		instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ReplaceBuffMap.Remove(originBuffId);
		return true;
	}

	// Token: 0x0601858A RID: 99722 RVA: 0x006D2390 File Offset: 0x006D0590
	public long? GetReplaceBuffId(long originBuffId, AddBuffParam buffParams)
	{
		if (!this.ReplaceBuffMap.ContainsKey(originBuffId))
		{
			return null;
		}
		BuffReplace buffReplace = this.ReplaceBuffMap[originBuffId];
		buffParams.PreMessageId = buffReplace.PreMessageId;
		return new long?(buffReplace.ReplaceBuffId);
	}

	// Token: 0x0601858B RID: 99723 RVA: 0x006D23D9 File Offset: 0x006D05D9
	public virtual void AddBuffRefEntityId(long buffId, int entityId)
	{
	}

	// Token: 0x0601858C RID: 99724 RVA: 0x006D23DB File Offset: 0x006D05DB
	public virtual void RemoveBuffRefEntityId(long buffId, int entityId)
	{
	}

	// Token: 0x0601858D RID: 99725 RVA: 0x006D23DD File Offset: 0x006D05DD
	public virtual bool HasBuffRefEntityId(long buffId)
	{
		return false;
	}

	// Token: 0x0601858E RID: 99726 RVA: 0x006D23E0 File Offset: 0x006D05E0
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseBuffComponent baseBuffComponent = (BaseBuffComponent)componentTemplate;
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (baseBuffComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DeathComponent"))
		{
			if (baseBuffComponent.DeathComponent == null)
			{
				this.DeathComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseDeathComponent>(this.DeathComponent), "DeathComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffContainer") && baseBuffComponent.BuffContainer != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, ActiveBuffInternal>>(this.BuffContainer), "BuffContainer"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BuffIdToHandleMap") && baseBuffComponent.BuffIdToHandleMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, HashSet<int>>>(this.BuffIdToHandleMap), "BuffIdToHandleMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BuffGarbageSet") && baseBuffComponent.BuffGarbageSet != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.BuffGarbageSet), "BuffGarbageSet"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("WaitRemoveBuffResponse") && baseBuffComponent.WaitRemoveBuffResponse != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, int>>(this.WaitRemoveBuffResponse), "WaitRemoveBuffResponse"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("PendingAddBuff") && baseBuffComponent.PendingAddBuff != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, double>>(this.PendingAddBuff), "PendingAddBuff"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("<BuffEffectManager>k__BackingField"))
		{
			if (baseBuffComponent.BuffEffectManager == null)
			{
				this.BuffEffectManager = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ExtraEffectManager>(this.BuffEffectManager), "<BuffEffectManager>k__BackingField"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagListenerDict") && baseBuffComponent.TagListenerDict != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, HashSet<int>>>(this.TagListenerDict), "TagListenerDict"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BuffListenerDict") && baseBuffComponent.BuffListenerDict != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, HashSet<int>>>(this.BuffListenerDict), "BuffListenerDict"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagImmuneListenerDict") && baseBuffComponent.TagImmuneListenerDict != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, HashSet<int>>>(this.TagImmuneListenerDict), "TagImmuneListenerDict"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("VictimTagListenerDict") && baseBuffComponent.VictimTagListenerDict != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, Dictionary<long, HashSet<int>>>>(this.VictimTagListenerDict), "VictimTagListenerDict"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ConfigOverrideConditionListener") && baseBuffComponent.ConfigOverrideConditionListener != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<ConfigOverrideConditionListener>(this.ConfigOverrideConditionListener), "ConfigOverrideConditionListener"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("VictimBuffListenerDict") && baseBuffComponent.VictimBuffListenerDict != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, Dictionary<long, HashSet<int>>>>(this.VictimBuffListenerDict), "VictimBuffListenerDict"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InstigatorEventListenDict") && baseBuffComponent.InstigatorEventListenDict != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, Dictionary<int, List<int>>>>(this.InstigatorEventListenDict), "InstigatorEventListenDict"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BuffRoutineExpirationLock") && baseBuffComponent.BuffRoutineExpirationLock != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, int>>(this.BuffRoutineExpirationLock), "BuffRoutineExpirationLock"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("EffectTimeoutMap"))
		{
			if (baseBuffComponent.EffectTimeoutMap == null)
			{
				this.EffectTimeoutMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, Dictionary<int, double>>>(this.EffectTimeoutMap), "EffectTimeoutMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EffectTargetTimeoutMap"))
		{
			if (baseBuffComponent.EffectTargetTimeoutMap == null)
			{
				this.EffectTargetTimeoutMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, Dictionary<int, Dictionary<int, double>>>>(this.EffectTargetTimeoutMap), "EffectTargetTimeoutMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagInChanged") && baseBuffComponent.TagInChanged != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.TagInChanged), "TagInChanged"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("BuffLockInternal"))
		{
			this.BuffLockInternal = baseBuffComponent.BuffLockInternal;
		}
		if (base.CanResetComponentProperty("TriggerMap") && baseBuffComponent.TriggerMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EBuffTriggerType, List<IBuffTrigger>>>(this.TriggerMap), "TriggerMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("OwnerBuffTimeModifiers"))
		{
			if (baseBuffComponent.OwnerBuffTimeModifiers == null)
			{
				this.OwnerBuffTimeModifiers = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, Dictionary<int, ValueTuple<float, float>>>>(this.OwnerBuffTimeModifiers), "OwnerBuffTimeModifiers"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InstigatorBuffTimeModifiers"))
		{
			if (baseBuffComponent.InstigatorBuffTimeModifiers == null)
			{
				this.InstigatorBuffTimeModifiers = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, Dictionary<int, ValueTuple<float, float>>>>(this.InstigatorBuffTimeModifiers), "InstigatorBuffTimeModifiers"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffStackModifiers"))
		{
			if (baseBuffComponent.BuffStackModifiers == null)
			{
				this.BuffStackModifiers = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, Dictionary<int, BuffStackModifierValue>>>(this.BuffStackModifiers), "BuffStackModifiers"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EnableDeferredCueCreation"))
		{
			this.EnableDeferredCueCreation = baseBuffComponent.EnableDeferredCueCreation;
		}
		if (base.CanResetComponentProperty("Buff2CueMap") && baseBuffComponent.Buff2CueMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, List<int>>>(this.Buff2CueMap), "Buff2CueMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("PendingCreateCueBuffs") && baseBuffComponent.PendingCreateCueBuffs != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.PendingCreateCueBuffs), "PendingCreateCueBuffs"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("PendingInstantCues") && baseBuffComponent.PendingInstantCues != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<BaseBuffComponent.PendingInstantCueItem>>(this.PendingInstantCues), "PendingInstantCues"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("PendingDestroyCueBuffs") && baseBuffComponent.PendingDestroyCueBuffs != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<int>(this.PendingDestroyCueBuffs), "PendingDestroyCueBuffs"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SeamlessTravelBuffCue"))
		{
			if (baseBuffComponent.SeamlessTravelBuffCue == null)
			{
				this.SeamlessTravelBuffCue = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, List<List<int>>>>(this.SeamlessTravelBuffCue), "SeamlessTravelBuffCue"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponentType"))
		{
			this.BuffComponentType = baseBuffComponent.BuffComponentType;
		}
		return !base.CanResetComponentProperty("ReplaceBuffMap") || baseBuffComponent.ReplaceBuffMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, BuffReplace>>(this.ReplaceBuffMap), "ReplaceBuffMap");
	}

	// Token: 0x0400BAC7 RID: 47815
	[Nullable(2)]
	protected CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400BAC8 RID: 47816
	[Nullable(2)]
	protected BaseDeathComponent DeathComponent;

	// Token: 0x0400BAC9 RID: 47817
	protected readonly Dictionary<int, ActiveBuffInternal> BuffContainer = new Dictionary<int, ActiveBuffInternal>();

	// Token: 0x0400BACA RID: 47818
	protected readonly Dictionary<long, HashSet<int>> BuffIdToHandleMap = new Dictionary<long, HashSet<int>>();

	// Token: 0x0400BACB RID: 47819
	protected readonly HashSet<int> BuffGarbageSet = new HashSet<int>();

	// Token: 0x0400BACC RID: 47820
	protected readonly Dictionary<long, int> WaitRemoveBuffResponse = new Dictionary<long, int>();

	// Token: 0x0400BACD RID: 47821
	protected readonly Dictionary<long, double> PendingAddBuff = new Dictionary<long, double>();

	// Token: 0x0400BACE RID: 47822
	[StaticVariableRuleIgnore]
	protected static readonly HashSet<long> NoLogBuffSet = new HashSet<long>
	{
		-3L,
		1101003012L,
		800080191L,
		800100003081L,
		1302121034L,
		1304700001L,
		640007016L,
		1202803014L,
		1202002003L
	};

	// Token: 0x0400BAD0 RID: 47824
	protected readonly Dictionary<int, HashSet<int>> TagListenerDict = new Dictionary<int, HashSet<int>>();

	// Token: 0x0400BAD1 RID: 47825
	protected readonly Dictionary<long, HashSet<int>> BuffListenerDict = new Dictionary<long, HashSet<int>>();

	// Token: 0x0400BAD2 RID: 47826
	public readonly Dictionary<int, HashSet<int>> TagImmuneListenerDict = new Dictionary<int, HashSet<int>>();

	// Token: 0x0400BAD3 RID: 47827
	public readonly Dictionary<int, Dictionary<long, HashSet<int>>> VictimTagListenerDict = new Dictionary<int, Dictionary<long, HashSet<int>>>();

	// Token: 0x0400BAD4 RID: 47828
	protected readonly ConfigOverrideConditionListener ConfigOverrideConditionListener = new ConfigOverrideConditionListener();

	// Token: 0x0400BAD5 RID: 47829
	public readonly Dictionary<long, Dictionary<long, HashSet<int>>> VictimBuffListenerDict = new Dictionary<long, Dictionary<long, HashSet<int>>>();

	// Token: 0x0400BAD6 RID: 47830
	protected readonly Dictionary<int, Dictionary<int, List<int>>> InstigatorEventListenDict = new Dictionary<int, Dictionary<int, List<int>>>();

	// Token: 0x0400BAD7 RID: 47831
	[StaticVariableRuleIgnore]
	private static readonly Stat CheckWhenTagChangedStat = Stat.Create("BaseBuffComponent.CheckWhenTagChanged", "", "");

	// Token: 0x0400BAD8 RID: 47832
	[StaticVariableRuleIgnore]
	private static readonly Stat CheckWhenBuffChangedStat = Stat.Create("BaseBuffComponent.CheckWhenBuffChanged", "", "");

	// Token: 0x0400BAD9 RID: 47833
	public readonly Dictionary<long, int> BuffRoutineExpirationLock = new Dictionary<long, int>();

	// Token: 0x0400BADA RID: 47834
	protected Dictionary<long, Dictionary<int, double>> EffectTimeoutMap = new Dictionary<long, Dictionary<int, double>>();

	// Token: 0x0400BADB RID: 47835
	protected Dictionary<long, Dictionary<int, Dictionary<int, double>>> EffectTargetTimeoutMap = new Dictionary<long, Dictionary<int, Dictionary<int, double>>>();

	// Token: 0x0400BADC RID: 47836
	private static readonly int MaxTargetCdCount = 50;

	// Token: 0x0400BADD RID: 47837
	[Nullable(2)]
	private static Dictionary<long, Stat> _buffStatMap;

	// Token: 0x0400BADE RID: 47838
	[StaticVariableRuleIgnore]
	private static readonly Stat GetStackableBuffStat = Stat.CreateNoFlameGraph("BaseBuffComponent.GetStackableBuff", "", "");

	// Token: 0x0400BADF RID: 47839
	[StaticVariableRuleIgnore]
	private static readonly Stat OnBuffStackDecreasedStat = Stat.Create("BaseBuffComponent.OnBuffStackDecreased", "", "");

	// Token: 0x0400BAE0 RID: 47840
	[StaticVariableRuleIgnore]
	private static readonly Stat OnBuffStackIncreasedStat = Stat.Create("BaseBuffComponent.OnBuffStackIncreased", "", "");

	// Token: 0x0400BAE1 RID: 47841
	private readonly HashSet<int> TagInChanged = new HashSet<int>();

	// Token: 0x0400BAE2 RID: 47842
	private int BuffLockInternal;

	// Token: 0x0400BAE3 RID: 47843
	protected readonly Dictionary<EBuffTriggerType, List<IBuffTrigger>> TriggerMap = new Dictionary<EBuffTriggerType, List<IBuffTrigger>>();

	// Token: 0x0400BAE4 RID: 47844
	[StaticVariableRuleIgnore]
	private static readonly Stat AddGameplayCueStat = Stat.Create("AddBuff_Cue", "", "");

	// Token: 0x0400BAE5 RID: 47845
	[StaticVariableRuleIgnore]
	private static readonly Stat AddBuffBroadcastNotifyStat = Stat.Create("BaseBuffComponent.BroadcastAddBuffNotify", "", "");

	// Token: 0x0400BAE6 RID: 47846
	[TupleElementNames(new string[]
	{
		"period",
		"duration"
	})]
	[Nullable(new byte[]
	{
		1,
		1,
		0
	})]
	public Dictionary<long, Dictionary<int, ValueTuple<float, float>>> OwnerBuffTimeModifiers = new Dictionary<long, Dictionary<int, ValueTuple<float, float>>>();

	// Token: 0x0400BAE7 RID: 47847
	[TupleElementNames(new string[]
	{
		"period",
		"duration"
	})]
	[Nullable(new byte[]
	{
		1,
		1,
		0
	})]
	public Dictionary<long, Dictionary<int, ValueTuple<float, float>>> InstigatorBuffTimeModifiers = new Dictionary<long, Dictionary<int, ValueTuple<float, float>>>();

	// Token: 0x0400BAE8 RID: 47848
	public Dictionary<long, Dictionary<int, BuffStackModifierValue>> BuffStackModifiers = new Dictionary<long, Dictionary<int, BuffStackModifierValue>>();

	// Token: 0x0400BAE9 RID: 47849
	private bool EnableDeferredCueCreation;

	// Token: 0x0400BAEA RID: 47850
	protected readonly Dictionary<int, List<int>> Buff2CueMap = new Dictionary<int, List<int>>();

	// Token: 0x0400BAEB RID: 47851
	private readonly HashSet<int> PendingCreateCueBuffs = new HashSet<int>();

	// Token: 0x0400BAEC RID: 47852
	private readonly List<BaseBuffComponent.PendingInstantCueItem> PendingInstantCues = new List<BaseBuffComponent.PendingInstantCueItem>();

	// Token: 0x0400BAED RID: 47853
	private readonly HashSet<int> PendingDestroyCueBuffs = new HashSet<int>();

	// Token: 0x0400BAEE RID: 47854
	[StaticVariableRuleIgnore]
	private static readonly Stat CreateGameplayCueByBuffStat = Stat.Create("CreateGameplayCueByBuff", "", "");

	// Token: 0x0400BAEF RID: 47855
	[StaticVariableRuleIgnore]
	private static readonly Stat DestroyGameplayCueByBuffStat = Stat.Create("DestroyGameplayCueByBuff", "", "");

	// Token: 0x0400BAF0 RID: 47856
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected Dictionary<long, List<List<int>>> SeamlessTravelBuffCue;

	// Token: 0x0400BAF1 RID: 47857
	private EBuffComponentType BuffComponentType;

	// Token: 0x0400BAF2 RID: 47858
	protected readonly Dictionary<long, BuffReplace> ReplaceBuffMap = new Dictionary<long, BuffReplace>();

	// Token: 0x020092F8 RID: 37624
	[NullableContext(0)]
	private struct PendingInstantCueItem
	{
		// Token: 0x04030F34 RID: 200500
		public long CueId;

		// Token: 0x04030F35 RID: 200501
		public GameplayCueParam Param;
	}
}
