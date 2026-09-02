using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.CombatMessage;

// Token: 0x02002E6F RID: 11887
[NullableContext(1)]
[Nullable(0)]
public class ActiveBuffInternal : IActiveBuff, IStaticVariableResetter
{
	// Token: 0x060186D4 RID: 100052 RVA: 0x006D82B8 File Offset: 0x006D64B8
	static ActiveBuffInternal()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActiveBuffInternal.CreateStaticDefaultValue), new Action(ActiveBuffInternal.ResetStaticDefaultValue));
	}

	// Token: 0x060186D5 RID: 100053 RVA: 0x006D8394 File Offset: 0x006D6594
	private ActiveBuffInternal(BuffDefinition configInternal)
	{
		this.ConfigInternal = configInternal;
	}

	// Token: 0x170020D8 RID: 8408
	// (get) Token: 0x060186D6 RID: 100054 RVA: 0x006D844C File Offset: 0x006D664C
	public static List<ActiveBuffInternal> BuffPool
	{
		get
		{
			return ActiveBuffInternal._buffPool;
		}
	}

	// Token: 0x060186D7 RID: 100055 RVA: 0x006D8454 File Offset: 0x006D6654
	public static ActiveBuffInternal AllocBuff(BuffDefinition config, int handle, long? instigatorId, BaseBuffComponent ownerBuffComp, int serverId, long? preMessageId, long? messageId, int level, int stackCount, float? duration, ApplyGEType applyType, long originalBuffId)
	{
		ActiveBuffInternal activeBuffInternal = null;
		if (ActiveBuffInternal.BuffPool.Count > 0)
		{
			activeBuffInternal = ActiveBuffInternal.BuffPool[ActiveBuffInternal.BuffPool.Count - 1];
			ActiveBuffInternal.BuffPool.RemoveAt(ActiveBuffInternal.BuffPool.Count - 1);
		}
		if (activeBuffInternal == null)
		{
			activeBuffInternal = new ActiveBuffInternal(config);
		}
		activeBuffInternal.Init(config, handle, instigatorId, ownerBuffComp, serverId, preMessageId, messageId, level, stackCount, duration, applyType, originalBuffId);
		return activeBuffInternal;
	}

	// Token: 0x060186D8 RID: 100056 RVA: 0x006D84C3 File Offset: 0x006D66C3
	public static void ReleaseBuff(ActiveBuffInternal buff)
	{
		if (buff.IsValid())
		{
			buff.Destroy();
		}
		if (buff != null && ActiveBuffInternal.BuffPool.Count < 100)
		{
			ActiveBuffInternal.BuffPool.Add(buff);
		}
	}

	// Token: 0x060186D9 RID: 100057 RVA: 0x006D84F0 File Offset: 0x006D66F0
	private ActiveBuffInternal Init(BuffDefinition config, int handle, long? instigatorId, BaseBuffComponent ownerBuffComp, int serverId, long? preMessageId, long? messageId, int level, int stackCount, float? duration, ApplyGEType applyType, long originalBuffId)
	{
		this.ConfigInternal = config;
		this.HandleInternal = handle;
		this.InstigatorIdInternal = instigatorId.GetValueOrDefault();
		this.OwnerBuffCompInternal = ownerBuffComp;
		this.OwnerDebugName = (((ownerBuffComp != null) ? ownerBuffComp.GetDebugName() : null) ?? "unknown");
		this.RemoveBuffWhenTimeout = (applyType == ApplyGEType.Common && ownerBuffComp.NeedCheck(config));
		this.ServerIdInternal = serverId;
		this._messageId = (messageId ?? ModelBase<CombatMessageModel>.Instance.GenMessageId());
		this._preMessageId = preMessageId;
		this.LevelInternal = level;
		this.StackCountInternal = stackCount;
		this.IsActiveInternal = false;
		this.PrepareToDestroy = false;
		Dictionary<int, HashSet<int>> executionStateData = this.ExecutionStateData;
		if (executionStateData != null)
		{
			executionStateData.Clear();
		}
		this.ExecutionStateData = null;
		this.ConfigOverrideListenerId = null;
		this.OriginalBuffIdInternal = originalBuffId;
		this.StackLimitCount = config.StackLimitCount;
		this.InnerCreateTimestamp = this.GetCurrentTime();
		this.SetDuration(duration);
		this.SetPeriod();
		if (this.IsInstantBuff())
		{
			foreach (IBuffModifierData buffModifierData in this.Config.Modifiers)
			{
				EAttributeType attributeId = buffModifierData.AttributeId;
				if (CharacterAttributeTypes.stateAttributeIds.Contains(attributeId))
				{
					this.SetStateModifier(buffModifierData);
				}
				else
				{
					this.SetNonStateModifier(buffModifierData);
				}
			}
		}
		else
		{
			this.ResetModifiers();
		}
		return this;
	}

	// Token: 0x060186DA RID: 100058 RVA: 0x006D8650 File Offset: 0x006D6850
	public void Destroy()
	{
		if (this.IsActive())
		{
			IBuffComponent ownerBuffComponent = this.GetOwnerBuffComponent();
			BaseTagComponent baseTagComponent;
			if (ownerBuffComponent == null)
			{
				baseTagComponent = null;
			}
			else
			{
				Entity exactEntity = ownerBuffComponent.GetExactEntity();
				baseTagComponent = ((exactEntity != null) ? exactEntity.CheckGetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 != null && baseTagComponent2.Valid)
			{
				foreach (int tagId in this.Config.GrantedTags ?? Array.Empty<int>())
				{
					baseTagComponent2.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, tagId, -this.StackCount);
				}
			}
		}
		this.PrepareToDestroy = true;
		this.ClearDurationTimer();
		this.ClearPeriodCallback();
		this.ClearModifiers();
		this.ClearBuffTimeScale();
		Dictionary<int, HashSet<int>> executionStateData = this.ExecutionStateData;
		if (executionStateData != null)
		{
			executionStateData.Clear();
		}
		this.ExecutionStateData = null;
		this.StackCountInternal = 0;
	}

	// Token: 0x060186DB RID: 100059 RVA: 0x006D8708 File Offset: 0x006D6908
	public bool IsValid()
	{
		if (!this.PrepareToDestroy)
		{
			IBuffComponent ownerBuffComponent = this.GetOwnerBuffComponent();
			bool? flag;
			if (ownerBuffComponent == null)
			{
				flag = null;
			}
			else
			{
				Entity exactEntity = ownerBuffComponent.GetExactEntity();
				flag = ((exactEntity != null) ? new bool?(exactEntity.Valid) : null);
			}
			bool? flag2 = flag;
			return flag2.GetValueOrDefault();
		}
		return false;
	}

	// Token: 0x170020D9 RID: 8409
	// (get) Token: 0x060186DC RID: 100060 RVA: 0x006D875A File Offset: 0x006D695A
	public BuffDefinition Config
	{
		get
		{
			return this.ConfigInternal;
		}
	}

	// Token: 0x170020DA RID: 8410
	// (get) Token: 0x060186DD RID: 100061 RVA: 0x006D8762 File Offset: 0x006D6962
	public int Handle
	{
		get
		{
			return this.HandleInternal;
		}
	}

	// Token: 0x170020DB RID: 8411
	// (get) Token: 0x060186DE RID: 100062 RVA: 0x006D876A File Offset: 0x006D696A
	public long? PreMessageId
	{
		get
		{
			return this._preMessageId;
		}
	}

	// Token: 0x170020DC RID: 8412
	// (get) Token: 0x060186DF RID: 100063 RVA: 0x006D8772 File Offset: 0x006D6972
	public long? MessageId
	{
		get
		{
			return new long?(this._messageId);
		}
	}

	// Token: 0x060186E0 RID: 100064 RVA: 0x006D877F File Offset: 0x006D697F
	[NullableContext(2)]
	public Entity GetOwner()
	{
		BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
		if (ownerBuffCompInternal == null)
		{
			return null;
		}
		return ownerBuffCompInternal.Entity;
	}

	// Token: 0x060186E1 RID: 100065 RVA: 0x006D8792 File Offset: 0x006D6992
	public string GetOwnerDebugName()
	{
		return this.OwnerDebugName;
	}

	// Token: 0x060186E2 RID: 100066 RVA: 0x006D879A File Offset: 0x006D699A
	[NullableContext(2)]
	public IBuffComponent GetOwnerBuffComponent()
	{
		return this.OwnerBuffCompInternal;
	}

	// Token: 0x170020DD RID: 8413
	// (get) Token: 0x060186E3 RID: 100067 RVA: 0x006D87A2 File Offset: 0x006D69A2
	public long? InstigatorId
	{
		get
		{
			return new long?(this.InstigatorIdInternal);
		}
	}

	// Token: 0x060186E4 RID: 100068 RVA: 0x006D87B0 File Offset: 0x006D69B0
	[NullableContext(2)]
	public Entity GetInstigator()
	{
		if (this.InstigatorId == null)
		{
			return null;
		}
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.InstigatorId.Value);
		if (entity == null)
		{
			return null;
		}
		return entity.Entity;
	}

	// Token: 0x060186E5 RID: 100069 RVA: 0x006D87F4 File Offset: 0x006D69F4
	[NullableContext(2)]
	public CharacterBuffComponent GetInstigatorBuffComponent()
	{
		if (this.InstigatorId == null)
		{
			return null;
		}
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.InstigatorId.Value);
		if (entity == null)
		{
			return null;
		}
		WorldEntity entity2 = entity.Entity;
		if (entity2 == null)
		{
			return null;
		}
		return entity2.GetComponent<CharacterBuffComponent>();
	}

	// Token: 0x060186E6 RID: 100070 RVA: 0x006D8844 File Offset: 0x006D6A44
	[NullableContext(2)]
	public CharacterActorComponent GetInstigatorActorComponent()
	{
		if (this.InstigatorId == null)
		{
			return null;
		}
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.InstigatorId.Value);
		if (entity == null)
		{
			return null;
		}
		WorldEntity entity2 = entity.Entity;
		if (entity2 == null)
		{
			return null;
		}
		return entity2.GetComponent<CharacterActorComponent>();
	}

	// Token: 0x060186E7 RID: 100071 RVA: 0x006D8894 File Offset: 0x006D6A94
	[NullableContext(2)]
	public BaseAttributeComponent GetInstigatorAttributeSet()
	{
		if (this.InstigatorId == null)
		{
			return null;
		}
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.InstigatorId.Value);
		if (entity == null)
		{
			return null;
		}
		WorldEntity entity2 = entity.Entity;
		if (entity2 == null)
		{
			return null;
		}
		return entity2.GetComponent<BaseAttributeComponent>();
	}

	// Token: 0x060186E8 RID: 100072 RVA: 0x006D88E1 File Offset: 0x006D6AE1
	[NullableContext(2)]
	public BaseAttributeComponent GetOwnerAttributeSet()
	{
		BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
		if (ownerBuffCompInternal == null)
		{
			return null;
		}
		Entity entity = ownerBuffCompInternal.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseAttributeComponent>();
	}

	// Token: 0x170020DE RID: 8414
	// (get) Token: 0x060186E9 RID: 100073 RVA: 0x006D88FF File Offset: 0x006D6AFF
	public long Id
	{
		get
		{
			return this.OriginalBuffIdInternal;
		}
	}

	// Token: 0x170020DF RID: 8415
	// (get) Token: 0x060186EA RID: 100074 RVA: 0x006D8907 File Offset: 0x006D6B07
	public int ServerId
	{
		get
		{
			return this.ServerIdInternal;
		}
	}

	// Token: 0x170020E0 RID: 8416
	// (get) Token: 0x060186EB RID: 100075 RVA: 0x006D890F File Offset: 0x006D6B0F
	public long OriginalBuffId
	{
		get
		{
			return this.OriginalBuffIdInternal;
		}
	}

	// Token: 0x060186EC RID: 100076 RVA: 0x006D8917 File Offset: 0x006D6B17
	public int? GetConfigOverrideListenerId()
	{
		return this.ConfigOverrideListenerId;
	}

	// Token: 0x060186ED RID: 100077 RVA: 0x006D891F File Offset: 0x006D6B1F
	public void SetConfigOverrideListenerId(int listenerId)
	{
		this.ConfigOverrideListenerId = new int?(listenerId);
	}

	// Token: 0x060186EE RID: 100078 RVA: 0x006D8930 File Offset: 0x006D6B30
	public void OnConfigOverrideChanged()
	{
		BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
		if (ownerBuffCompInternal == null)
		{
			return;
		}
		ownerBuffCompInternal.RemoveBuffByHandle(this.Handle, -1, "配置覆盖条件变化", null, null, null);
	}

	// Token: 0x060186EF RID: 100079 RVA: 0x006D8975 File Offset: 0x006D6B75
	public bool IsInstantBuff()
	{
		return this.Config.DurationPolicy == EBuffDurationType.Instant;
	}

	// Token: 0x060186F0 RID: 100080 RVA: 0x006D8985 File Offset: 0x006D6B85
	public void SetBuffTimeScale(int buffHandle, float timeScale)
	{
		this.BuffTimeScaleMap[buffHandle] = timeScale;
		this.RefreshBuffTimeScale();
	}

	// Token: 0x060186F1 RID: 100081 RVA: 0x006D899A File Offset: 0x006D6B9A
	public void RemoveBuffTimeScale(int buffHandle)
	{
		if (this.BuffTimeScaleMap.ContainsKey(buffHandle))
		{
			this.BuffTimeScaleMap.Remove(buffHandle);
			this.RefreshBuffTimeScale();
		}
	}

	// Token: 0x060186F2 RID: 100082 RVA: 0x006D89C0 File Offset: 0x006D6BC0
	private void RefreshBuffTimeScale()
	{
		float num = 1f;
		foreach (float num2 in this.BuffTimeScaleMap.Values)
		{
			num *= num2;
		}
		if (num != this.BuffTimeScale)
		{
			this.BuffTimeScale = num;
			BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
			float newSpeed = (ownerBuffCompInternal != null) ? ownerBuffCompInternal.GetTimeScale() : 1f;
			BaseBuffComponent ownerBuffCompInternal2 = this.OwnerBuffCompInternal;
			bool forcePaused = ownerBuffCompInternal2 != null && ownerBuffCompInternal2.IsPaused();
			this.OnTimeScaleChanged(newSpeed, forcePaused);
		}
	}

	// Token: 0x060186F3 RID: 100083 RVA: 0x006D8A60 File Offset: 0x006D6C60
	private void ClearBuffTimeScale()
	{
		this.BuffTimeScale = 1f;
		this.BuffTimeScaleMap.Clear();
	}

	// Token: 0x170020E1 RID: 8417
	// (get) Token: 0x060186F4 RID: 100084 RVA: 0x006D8A78 File Offset: 0x006D6C78
	public float Duration
	{
		get
		{
			return this.DurationInternal;
		}
	}

	// Token: 0x060186F5 RID: 100085 RVA: 0x006D8A80 File Offset: 0x006D6C80
	private void ClearDurationTimer()
	{
		if (this.DurationTimer != null)
		{
			if (TimerSystem.Instance.Has(this.DurationTimer))
			{
				TimerSystem.Instance.Remove(this.DurationTimer);
			}
			this.DurationTimer = null;
		}
	}

	// Token: 0x060186F6 RID: 100086 RVA: 0x006D8AB4 File Offset: 0x006D6CB4
	private void ResetDurationTimer(float remainingTime)
	{
		this.ClearDurationTimer();
		if (this.DurationInternal <= 0f)
		{
			return;
		}
		this.LastRemainingDuration = remainingTime;
		this.LastTimestamp = this.GetCurrentTime();
		if (this.RemoveBuffWhenTimeout && this.Timescale > 0f)
		{
			float num = this.LastRemainingDuration / this.Timescale * 1000f;
			Stat resetDurationTimerStat = this.ResetDurationTimerStat;
			this.DurationTimer = ((num >= 20f) ? TimerSystem.Instance.Delay(new TTimerAction(this.DurationCallback), num, resetDurationTimerStat, null, false, 1f) : TimerSystem.Instance.Next(new TTimerAction(this.DurationCallback), resetDurationTimerStat, null));
		}
	}

	// Token: 0x170020E2 RID: 8418
	// (get) Token: 0x060186F7 RID: 100087 RVA: 0x006D8B5F File Offset: 0x006D6D5F
	public float CreateTimestamp
	{
		get
		{
			return this.InnerCreateTimestamp;
		}
	}

	// Token: 0x060186F8 RID: 100088 RVA: 0x006D8B67 File Offset: 0x006D6D67
	protected float GetCurrentTime()
	{
		return (float)Singleton<Time>.Instance.Now;
	}

	// Token: 0x060186F9 RID: 100089 RVA: 0x006D8B74 File Offset: 0x006D6D74
	public unsafe void SetDuration(float? duration = null)
	{
		BuffDefinition config = this.Config;
		float num;
		if (config.DurationPolicy == EBuffDurationType.Infinite)
		{
			num = -1f;
		}
		else if (duration != null)
		{
			num = duration.Value;
		}
		else if (config.DurationMagnitude.Length == 0 || config.DurationCalculationPolicy.Length == 0)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity owner = this.GetOwner();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(76, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Buff 配置为hasDuration 但未配置DurationMagnitude或DurationCalculationPolicy, 强制将时间设为");
			defaultInterpolatedStringHandler.AppendFormatted<float>(0.034f);
			string message = defaultInterpolatedStringHandler.ToStringAndClear();
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BuffId", this.Id);
			instance.Error(flag, owner, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			num = 0.034f;
		}
		else
		{
			float levelValue = AbilityUtils.GetLevelValue<float>(this.Config.DurationMagnitude, this.Level, 0f);
			BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
			float num2 = (ownerBuffCompInternal != null) ? ownerBuffCompInternal.CalculateDurationRate(this.Id, this.GetInstigatorBuffComponent()) : 1f;
			int[] durationCalculationPolicy = config.DurationCalculationPolicy;
			int? num3 = (durationCalculationPolicy != null) ? new int?(durationCalculationPolicy[0]) : null;
			if (num3 != null)
			{
				int valueOrDefault = num3.GetValueOrDefault();
				if (valueOrDefault != 0 && valueOrDefault == 1)
				{
					if (durationCalculationPolicy.Length < 4)
					{
						CombatLog instance2 = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
						Entity owner2 = this.GetOwner();
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(74, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Buff 配置为hasDuration 但未配置DurationMagnitude或DurationCalculationPolicy, 将被重设为");
						defaultInterpolatedStringHandler.AppendFormatted<float>(0.034f);
						string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", this.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", this.Handle);
						ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
						string item = "持有者";
						BaseBuffComponent ownerBuffCompInternal2 = this.OwnerBuffCompInternal;
						ptr = new ValueTuple<string, object>(item, (ownerBuffCompInternal2 != null) ? ownerBuffCompInternal2.GetDebugName() : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("释放者", this.InstigatorId);
						instance2.Error(flag2, owner2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
						num = 0.034f;
						goto IL_376;
					}
					float levelValue2 = AbilityUtils.GetLevelValue<float>(config.DurationMagnitude2, this.Level, 0f);
					int attrId = durationCalculationPolicy[1];
					EBuffAttributeCaptureSource ebuffAttributeCaptureSource = (EBuffAttributeCaptureSource)durationCalculationPolicy[2];
					EAttributeBasedFloatCalculationType attrCalcPolicy = (EAttributeBasedFloatCalculationType)durationCalculationPolicy[3];
					BaseAttributeComponent baseAttributeComponent = (ebuffAttributeCaptureSource == EBuffAttributeCaptureSource.Instigator) ? this.GetInstigatorAttributeSet() : this.GetOwnerAttributeSet();
					if (baseAttributeComponent == null)
					{
						CombatLog instance3 = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Buff;
						Entity owner3 = this.GetOwner();
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Buff 找不到周期计算属性来源, 周期将被重设为");
						defaultInterpolatedStringHandler.AppendFormatted<float>(0.034f);
						string message3 = defaultInterpolatedStringHandler.ToStringAndClear();
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("BuffId", this.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("handle", this.Handle);
						ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2);
						string item2 = "持有者";
						BaseBuffComponent ownerBuffCompInternal3 = this.OwnerBuffCompInternal;
						ptr2 = new ValueTuple<string, object>(item2, (ownerBuffCompInternal3 != null) ? ownerBuffCompInternal3.GetDebugName() : null);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("释放者", this.InstigatorId);
						instance3.Error(flag3, owner3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
						num = 0.034f;
						goto IL_376;
					}
					num = Math.Max((AbilityUtils.GetAttrValue(baseAttributeComponent, (EAttributeType)attrId, attrCalcPolicy) * levelValue * 0.0001f + levelValue2) * num2, 0.034f);
					goto IL_376;
				}
			}
			num = levelValue * num2;
		}
		IL_376:
		this.DurationInternal = num;
		this.ResetDurationTimer(num);
	}

	// Token: 0x060186FA RID: 100090 RVA: 0x006D8F05 File Offset: 0x006D7105
	public void SetRemainDuration(float remainDuration)
	{
		if (this.Config.DurationPolicy != EBuffDurationType.HasDuration)
		{
			return;
		}
		this.ResetDurationTimer((remainDuration > 0f) ? remainDuration : 0.034f);
	}

	// Token: 0x060186FB RID: 100091 RVA: 0x006D8F2C File Offset: 0x006D712C
	public float GetRemainDuration()
	{
		if (!this.IsValid())
		{
			return 0f;
		}
		BuffDefinition config = this.Config;
		EBuffDurationType? ebuffDurationType = (config != null) ? new EBuffDurationType?(config.DurationPolicy) : null;
		if (ebuffDurationType != null)
		{
			EBuffDurationType valueOrDefault = ebuffDurationType.GetValueOrDefault();
			if (valueOrDefault == EBuffDurationType.Instant)
			{
				return 0f;
			}
			if (valueOrDefault == EBuffDurationType.Infinite)
			{
				return -1f;
			}
		}
		float num = (this.GetCurrentTime() - this.LastTimestamp) * this.Timescale / 1000f;
		if (this.DurationInternal >= 0f)
		{
			return Math.Max(this.LastRemainingDuration - num, 0f);
		}
		return -1f;
	}

	// Token: 0x060186FC RID: 100092 RVA: 0x006D8FCC File Offset: 0x006D71CC
	public HashSet<int> GetOrCreateExecutionState(int index)
	{
		if (this.ExecutionStateData == null)
		{
			this.ExecutionStateData = new Dictionary<int, HashSet<int>>();
		}
		HashSet<int> hashSet;
		if (!this.ExecutionStateData.TryGetValue(index, out hashSet))
		{
			hashSet = new HashSet<int>();
			this.ExecutionStateData[index] = hashSet;
		}
		return hashSet;
	}

	// Token: 0x060186FD RID: 100093 RVA: 0x006D9010 File Offset: 0x006D7210
	protected void RefreshPeriodInternal()
	{
		this.PeriodInternal = this.Config.Period;
		if (this.PeriodInternal > 0f)
		{
			BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
			float num = (ownerBuffCompInternal != null) ? ownerBuffCompInternal.CalculatePeriodRate(this.Id, this.GetInstigatorBuffComponent()) : 1f;
			this.PeriodInternal *= num;
			if (this.Config.HasBuffPeriodExecution)
			{
				if (this.PeriodInternal < 0.2f)
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
					Entity owner = this.GetOwner();
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
					defaultInterpolatedStringHandler.AppendLiteral("目前限制带周期型额外效果的Buff周期最短为");
					defaultInterpolatedStringHandler.AppendFormatted<float>(0.2f);
					defaultInterpolatedStringHandler.AppendLiteral("，配置周期");
					defaultInterpolatedStringHandler.AppendFormatted<float>(this.PeriodInternal);
					defaultInterpolatedStringHandler.AppendLiteral("，已强制修改周期");
					string message = defaultInterpolatedStringHandler.ToStringAndClear();
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BuffId", this.Id);
					instance.Error(flag, owner, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.PeriodInternal = 0.2f;
					return;
				}
			}
			else if (this.PeriodInternal < 0.034f)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
				Entity owner2 = this.GetOwner();
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
				defaultInterpolatedStringHandler.AppendLiteral("目前限制Buff周期最短为");
				defaultInterpolatedStringHandler.AppendFormatted<float>(0.034f);
				defaultInterpolatedStringHandler.AppendLiteral("，配置周期");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.PeriodInternal);
				defaultInterpolatedStringHandler.AppendLiteral("，已强制修改周期");
				string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BuffId", this.Id);
				instance2.Error(flag2, owner2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.PeriodInternal = 0.034f;
			}
		}
	}

	// Token: 0x060186FE RID: 100094 RVA: 0x006D91B0 File Offset: 0x006D73B0
	protected bool SetPeriod()
	{
		this.RefreshPeriodInternal();
		this.ResetPeriodTimer(this.PeriodInternal);
		return true;
	}

	// Token: 0x170020E3 RID: 8419
	// (get) Token: 0x060186FF RID: 100095 RVA: 0x006D91C5 File Offset: 0x006D73C5
	public float Period
	{
		get
		{
			return this.PeriodInternal;
		}
	}

	// Token: 0x06018700 RID: 100096 RVA: 0x006D91D0 File Offset: 0x006D73D0
	public void OnTimeScaleChanged(float newSpeed, bool forcePaused)
	{
		if (forcePaused)
		{
			newSpeed = 0f;
		}
		else if (!this.Config.DurationAffectedByBulletTime)
		{
			IBuffComponent ownerBuffComponent = this.GetOwnerBuffComponent();
			newSpeed = ((ownerBuffComponent != null) ? ownerBuffComponent.GetLogicTimeScale() : 1f);
		}
		else
		{
			bool flag = false;
			foreach (ExtraEffectParameters extraEffectParameters in this.Config.EffectInfos)
			{
				if (extraEffectParameters.ExtraEffectId == EExtraEffectId.ModifyLife || extraEffectParameters.ExtraEffectId == EExtraEffectId.PeriodicExtraEffect || extraEffectParameters.ExtraEffectId == EExtraEffectId.SetTimeScale)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
				Entity owner = this.GetOwner();
				string message = "带额外效果4、5、17的buff不应受子弹顿帧影响";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", this.Id);
				instance.Warn(flag2, owner, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Entity owner2 = this.GetOwner();
				newSpeed = ((owner2 != null) ? owner2.TimeDilation : 1f);
			}
		}
		newSpeed *= this.BuffTimeScale;
		if (newSpeed == this.Timescale)
		{
			return;
		}
		float currentTime = this.GetCurrentTime();
		float timescale = this.Timescale;
		this.Timescale = newSpeed;
		if (this.DurationInternal > 0f)
		{
			float num = (currentTime - this.LastTimestamp) * timescale / 1000f;
			float remainingTime = this.LastRemainingDuration - num;
			this.ResetDurationTimer(remainingTime);
		}
		if (this.PeriodInternal > 0f)
		{
			float num2 = (currentTime - this.PeriodUpdateTimestamp) * timescale / 1000f;
			float remainingTime2 = this.LastRemainingPeriod - num2;
			this.ResetPeriodTimer(remainingTime2);
		}
	}

	// Token: 0x06018701 RID: 100097 RVA: 0x006D9360 File Offset: 0x006D7560
	protected void DurationCallback(float delta)
	{
		if (!this.IsValid())
		{
			return;
		}
		IBuffComponent ownerBuffComponent = this.GetOwnerBuffComponent();
		if (ownerBuffComponent == null)
		{
			return;
		}
		ownerBuffComponent.RemoveBuffWhenTimeout(this);
	}

	// Token: 0x06018702 RID: 100098 RVA: 0x006D9388 File Offset: 0x006D7588
	private void ClearPeriodCallback()
	{
		if (this.PeriodTimer != null)
		{
			if (TimerSystem.Instance.Has(this.PeriodTimer))
			{
				TimerSystem.Instance.Remove(this.PeriodTimer);
			}
			this.PeriodTimer = null;
		}
	}

	// Token: 0x06018703 RID: 100099 RVA: 0x006D93BC File Offset: 0x006D75BC
	public void ResetPeriodTimer(float remainingTime)
	{
		this.ClearPeriodCallback();
		if (this.PeriodInternal <= 0f)
		{
			return;
		}
		this.LastRemainingPeriod = remainingTime;
		this.PeriodUpdateTimestamp = this.GetCurrentTime();
		if (this.Timescale > 0f)
		{
			float num = this.LastRemainingPeriod / this.Timescale * 1000f;
			Stat resetPeriodTimerStat = this.ResetPeriodTimerStat;
			this.PeriodTimer = ((num >= 20f) ? TimerSystem.Instance.Delay(delegate(float delta)
			{
				this.PeriodCallback();
			}, num, resetPeriodTimerStat, null, false, 1f) : TimerSystem.Instance.Next(delegate(float delta)
			{
				this.PeriodCallback();
			}, resetPeriodTimerStat, null));
		}
	}

	// Token: 0x06018704 RID: 100100 RVA: 0x006D9460 File Offset: 0x006D7660
	private void PeriodCallback()
	{
		if (!this.IsValid())
		{
			return;
		}
		float periodInternal = this.PeriodInternal;
		float value = this.GetRemainPeriod().Value;
		int num = (int)Math.Floor((double)(1f - value / periodInternal));
		float remainingTime = (value % periodInternal + periodInternal) % periodInternal;
		this.RefreshPeriodInternal();
		if (!this.IsActive())
		{
			this.ResetPeriodTimer(remainingTime);
			return;
		}
		this.ResetPeriodTimer(remainingTime);
		IBuffComponent ownerBuffComponent = this.GetOwnerBuffComponent();
		for (int i = 0; i < num; i++)
		{
			if (ownerBuffComponent != null)
			{
				ownerBuffComponent.ApplyPeriodExecution(this);
			}
		}
	}

	// Token: 0x06018705 RID: 100101 RVA: 0x006D94E8 File Offset: 0x006D76E8
	public float? GetRemainPeriod()
	{
		float num = (this.GetCurrentTime() - this.PeriodUpdateTimestamp) * this.Timescale;
		if (this.PeriodInternal < 0f)
		{
			return null;
		}
		return new float?(this.LastRemainingPeriod - num / 1000f);
	}

	// Token: 0x06018706 RID: 100102 RVA: 0x006D9534 File Offset: 0x006D7734
	public bool IsActive()
	{
		return this.IsActiveInternal;
	}

	// Token: 0x06018707 RID: 100103 RVA: 0x006D953C File Offset: 0x006D773C
	public unsafe bool SetActivate(bool isActive)
	{
		if (this.IsActiveInternal == isActive)
		{
			return false;
		}
		this.IsActiveInternal = isActive;
		IBuffComponent ownerBuffComponent = this.GetOwnerBuffComponent();
		BaseTagComponent baseTagComponent;
		if (ownerBuffComponent == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity exactEntity = ownerBuffComponent.GetExactEntity();
			baseTagComponent = ((exactEntity != null) ? exactEntity.CheckGetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity owner = this.GetOwner();
			string message = "buff更改激活状态时无法获取到持有者";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handle", this.Handle);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", this.Id);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "持有者";
			BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
			ptr = new ValueTuple<string, object>(item, (ownerBuffCompInternal != null) ? ownerBuffCompInternal.GetDebugName() : null);
			instance.Error(flag, owner, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		if (isActive)
		{
			this.ResetModifiers();
			foreach (int tagId in this.Config.GrantedTags ?? Array.Empty<int>())
			{
				if (GameplayTagUtils.GetGameplayTagById(tagId) != null)
				{
					baseTagComponent2.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, tagId, this.StackCount);
				}
			}
			if (this.PeriodInternal > 0f)
			{
				EBuffPeriodicInhibitionPolicy periodicInhibitionPolicy = this.Config.PeriodicInhibitionPolicy;
				if (periodicInhibitionPolicy != EBuffPeriodicInhibitionPolicy.Reset)
				{
					if (periodicInhibitionPolicy == EBuffPeriodicInhibitionPolicy.ResetAndExecute)
					{
						this.ResetPeriodTimer(0.02f);
					}
				}
				else
				{
					this.ResetPeriodTimer(this.PeriodInternal);
				}
			}
		}
		else
		{
			this.ClearModifiers();
			foreach (int tagId2 in this.Config.GrantedTags ?? Array.Empty<int>())
			{
				if (GameplayTagUtils.GetGameplayTagById(tagId2) != null)
				{
					baseTagComponent2.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, tagId2, -this.StackCount);
				}
			}
		}
		return true;
	}

	// Token: 0x170020E4 RID: 8420
	// (get) Token: 0x06018708 RID: 100104 RVA: 0x006D9707 File Offset: 0x006D7907
	public int StackCount
	{
		get
		{
			return this.StackCountInternal;
		}
	}

	// Token: 0x06018709 RID: 100105 RVA: 0x006D9710 File Offset: 0x006D7910
	public unsafe void SetStackCount(int newStack, EBuffStackPeriodResetOverride stackPeriodResetPolicy)
	{
		BuffDefinition config = this.Config;
		int stackCountInternal = this.StackCountInternal;
		this.StackCountInternal = newStack;
		IBuffComponent ownerBuffComponent = this.GetOwnerBuffComponent();
		BaseTagComponent baseTagComponent;
		if (ownerBuffComponent == null)
		{
			baseTagComponent = null;
		}
		else
		{
			Entity exactEntity = ownerBuffComponent.GetExactEntity();
			baseTagComponent = ((exactEntity != null) ? exactEntity.CheckGetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		if (baseTagComponent2 == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity owner = this.GetOwner();
			string message = "buff更改层数时无法获取到持有者";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("handle", this.Handle);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", this.Id);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
			string item = "持有者";
			BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
			ptr = new ValueTuple<string, object>(item, (ownerBuffCompInternal != null) ? ownerBuffCompInternal.GetDebugName() : null);
			instance.Error(flag, owner, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (stackPeriodResetPolicy == EBuffStackPeriodResetOverride.Default && config.StackPeriodResetPolicy == EBuffStackPeriodResetPolicy.Refresh)
		{
			this.SetPeriod();
		}
		this.ResetModifiers();
		if (this.IsActiveInternal)
		{
			foreach (int tagId in config.GrantedTags ?? Array.Empty<int>())
			{
				if (GameplayTagUtils.GetGameplayTagById(tagId) != null)
				{
					baseTagComponent2.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, tagId, newStack - stackCountInternal);
				}
			}
		}
	}

	// Token: 0x170020E5 RID: 8421
	// (get) Token: 0x0601870A RID: 100106 RVA: 0x006D9859 File Offset: 0x006D7A59
	public int Level
	{
		get
		{
			return this.LevelInternal;
		}
	}

	// Token: 0x0601870B RID: 100107 RVA: 0x006D9864 File Offset: 0x006D7A64
	public void ClearModifiers()
	{
		this.StateModifiers.Clear();
		Entity owner = this.GetOwner();
		BaseAttributeComponent baseAttributeComponent = (owner != null) ? owner.GetComponent<BaseAttributeComponent>() : null;
		if (this.NonStateModifierHandles.Count > 0 && baseAttributeComponent != null)
		{
			foreach (ValueTuple<int, int> valueTuple in this.NonStateModifierHandles)
			{
				baseAttributeComponent.RemoveModifier((EAttributeType)valueTuple.Item1, valueTuple.Item2);
			}
			this.NonStateModifierHandles.Clear();
		}
	}

	// Token: 0x0601870C RID: 100108 RVA: 0x006D98FC File Offset: 0x006D7AFC
	public void ResetModifiers()
	{
		this.ClearModifiers();
		if (this.IsActiveInternal)
		{
			foreach (IBuffModifierData buffModifierData in this.Config.Modifiers)
			{
				EAttributeType attributeId = buffModifierData.AttributeId;
				if (CharacterAttributeTypes.stateAttributeIds.Contains(attributeId))
				{
					this.SetStateModifier(buffModifierData);
				}
				else
				{
					this.SetNonStateModifier(buffModifierData);
				}
			}
		}
	}

	// Token: 0x0601870D RID: 100109 RVA: 0x006D995C File Offset: 0x006D7B5C
	private unsafe void SetStateModifier(IBuffModifierData modifier)
	{
		ECalculationPolicyType ecalculationPolicyType = (ECalculationPolicyType)modifier.CalculationPolicy[0];
		if (ecalculationPolicyType == ECalculationPolicyType.AddFromAttr || ecalculationPolicyType == ECalculationPolicyType.OverrideFromAttr || ecalculationPolicyType == ECalculationPolicyType.AddFromAttrRate)
		{
			int attrId = modifier.CalculationPolicy[1];
			EBuffAttributeCaptureSource ebuffAttributeCaptureSource = (EBuffAttributeCaptureSource)modifier.CalculationPolicy[2];
			EAttributeBasedFloatCalculationType attrCalcPolicy = (EAttributeBasedFloatCalculationType)modifier.CalculationPolicy[3];
			object obj = modifier.CalculationPolicy.Length > 4 && modifier.CalculationPolicy[4] != 0;
			BaseAttributeComponent baseAttributeComponent = (ebuffAttributeCaptureSource == EBuffAttributeCaptureSource.Instigator) ? this.GetInstigatorAttributeSet() : this.GetOwnerAttributeSet();
			object obj2 = obj;
			if (obj2 != null && baseAttributeComponent == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity owner = this.GetOwner();
				string message = "buff找不到属性来源，快照将被取值为0";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", this.Handle);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item = "持有者";
				BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
				ptr = new ValueTuple<string, object>(item, (ownerBuffCompInternal != null) ? ownerBuffCompInternal.GetDebugName() : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("施加者", this.InstigatorId);
				instance.Warn(flag, owner, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			float? item2 = (obj2 != null) ? new float?((baseAttributeComponent != null) ? AbilityUtils.GetAttrValue(baseAttributeComponent, (EAttributeType)attrId, attrCalcPolicy) : 0f) : null;
			this.StateModifiers.Add(new ValueTuple<IBuffModifierData, float?>(modifier, item2));
			return;
		}
		this.StateModifiers.Add(new ValueTuple<IBuffModifierData, float?>(modifier, null));
	}

	// Token: 0x0601870E RID: 100110 RVA: 0x006D9AE8 File Offset: 0x006D7CE8
	private unsafe void SetNonStateModifier(IBuffModifierData modifier)
	{
		int num = (this.StackCountInternal != 0) ? this.StackCountInternal : 1;
		Entity owner = this.GetOwner();
		BaseAttributeComponent baseAttributeComponent = (owner != null) ? owner.GetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent == null)
		{
			return;
		}
		int item = 0;
		EAttributeType attributeId = modifier.AttributeId;
		float levelValue = AbilityUtils.GetLevelValue<float>(modifier.Value1, this.LevelInternal, 0f);
		float levelValue2 = AbilityUtils.GetLevelValue<float>(modifier.Value2, this.LevelInternal, 0f);
		switch (modifier.CalculationPolicy[0])
		{
		case 0:
		case 1:
		case 3:
			item = baseAttributeComponent.AddModifier(attributeId, new CharacterAttributeTypes.AttributeModifier
			{
				Type = (ECalculationPolicyType)modifier.CalculationPolicy[0],
				Value1 = levelValue * (float)num
			});
			break;
		case 2:
		case 4:
		case 9:
		{
			ECalculationPolicyType type = (ECalculationPolicyType)modifier.CalculationPolicy[0];
			int num2 = modifier.CalculationPolicy[1];
			int num3 = modifier.CalculationPolicy[2];
			EAttributeBasedFloatCalculationType eattributeBasedFloatCalculationType = (EAttributeBasedFloatCalculationType)modifier.CalculationPolicy[3];
			bool flag = modifier.CalculationPolicy.Length > 4 && modifier.CalculationPolicy[4] != 0;
			float? min = (modifier.CalculationPolicy.Length > 5) ? new float?((float)modifier.CalculationPolicy[5]) : null;
			float? ratio = (modifier.CalculationPolicy.Length > 6) ? new float?((float)modifier.CalculationPolicy[6]) : null;
			float? max = (modifier.CalculationPolicy.Length > 7) ? new float?((float)modifier.CalculationPolicy[7]) : null;
			bool floorAfterRatio = modifier.CalculationPolicy.Length > 8 && modifier.CalculationPolicy[8] == 1;
			BaseAttributeComponent baseAttributeComponent2 = (num3 == 1) ? this.GetInstigatorAttributeSet() : this.GetOwnerAttributeSet();
			long? num4 = (num3 == 1) ? this.InstigatorId : new long?(0L);
			if (baseAttributeComponent2 == null || num4 == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
				Entity owner2 = this.GetOwner();
				string message = "持续型buff设置属性modifier时缺少来源";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", this.Handle);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
				string item2 = "持有者";
				BaseBuffComponent ownerBuffCompInternal = this.OwnerBuffCompInternal;
				ptr = new ValueTuple<string, object>(item2, (ownerBuffCompInternal != null) ? ownerBuffCompInternal.GetDebugName() : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("施加者", this.InstigatorId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("attrId", attributeId);
				instance.Error(flag2, owner2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				return;
			}
			item = baseAttributeComponent.AddModifier(attributeId, new CharacterAttributeTypes.AttributeModifier
			{
				Type = type,
				Value1 = levelValue * (float)num,
				Value2 = levelValue2 * (float)num,
				SourceEntity = num4.Value,
				SourceAttributeId = (EAttributeType)num2,
				SourceCalculationType = eattributeBasedFloatCalculationType,
				SnapshotSource = (flag ? new float?(AbilityUtils.GetAttrValue(baseAttributeComponent2, (EAttributeType)num2, eattributeBasedFloatCalculationType)) : null),
				Min = min,
				Ratio = ratio,
				Max = max,
				FloorAfterRatio = floorAfterRatio
			});
			break;
		}
		case 5:
		case 6:
		{
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Buff;
			Entity owner3 = this.GetOwner();
			string message2 = "不能对非状态属性使用时间膨胀类属性修改";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", this.Id);
			instance2.Error(flag3, owner3, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			break;
		}
		}
		this.NonStateModifierHandles.Add(new ValueTuple<int, int>((int)attributeId, item));
	}

	// Token: 0x0601870F RID: 100111 RVA: 0x006D9E74 File Offset: 0x006D8074
	public static void ModifyStateAttribute([Nullable(2)] IAttributeSet instigator, BaseAttributeComponent owner, IBuffModifierData modifier, int level, float timeDilation, int stackCount, float? snapshot = null)
	{
		EAttributeType attributeId = modifier.AttributeId;
		if (!CharacterAttributeTypes.stateAttributeIds.Contains(attributeId))
		{
			return;
		}
		float levelValue = AbilityUtils.GetLevelValue<float>(modifier.Value1, level, 0f);
		float levelValue2 = AbilityUtils.GetLevelValue<float>(modifier.Value2, level, 0f);
		switch (modifier.CalculationPolicy[0])
		{
		case 0:
			owner.AddBaseValue(attributeId, levelValue * (float)stackCount);
			return;
		case 1:
		{
			float baseValue = owner.GetBaseValue(attributeId);
			double num = (double)levelValue * (double)stackCount / 10000.0 + 1.0;
			owner.SetBaseValue(attributeId, (float)((double)baseValue * num));
			return;
		}
		case 2:
		case 4:
		case 9:
		{
			ECalculationPolicyType ecalculationPolicyType = (ECalculationPolicyType)modifier.CalculationPolicy[0];
			int attrId = modifier.CalculationPolicy[1];
			int num2 = modifier.CalculationPolicy[2];
			EAttributeBasedFloatCalculationType attrCalcPolicy = (EAttributeBasedFloatCalculationType)modifier.CalculationPolicy[3];
			float? num3 = (modifier.CalculationPolicy.Length > 5) ? new float?((float)modifier.CalculationPolicy[5]) : null;
			float? num4 = (modifier.CalculationPolicy.Length > 6) ? new float?((float)modifier.CalculationPolicy[6]) : null;
			float? num5 = (modifier.CalculationPolicy.Length > 7) ? new float?((float)modifier.CalculationPolicy[7]) : null;
			bool flag = modifier.CalculationPolicy.Length > 8 && modifier.CalculationPolicy[8] == 1;
			IAttributeSet attributeSet = (num2 == 1) ? instigator : owner;
			if (attributeSet == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
				Entity entity = owner.Entity;
				string message = "瞬间/周期buff属性修改时缺少来源";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("attrId", attributeId);
				instance.Error(flag2, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			float num6 = snapshot ?? AbilityUtils.GetAttrValue(attributeSet, (EAttributeType)attrId, attrCalcPolicy);
			if (num3 != null)
			{
				num6 -= num3.Value;
				if (num6 <= 0f)
				{
					return;
				}
			}
			if (num4 != null)
			{
				num6 /= num4.Value;
				if (flag)
				{
					num6 = (float)Math.Floor((double)num6);
				}
			}
			if (ecalculationPolicyType == ECalculationPolicyType.AddFromAttrRate)
			{
				float baseValue2 = owner.GetBaseValue(attributeId);
				owner.AddBaseValue(attributeId, (float)((double)levelValue * (double)num6 / 10000.0 * (double)baseValue2 / 10000.0 * (double)stackCount));
				return;
			}
			float num7 = (float)((double)levelValue * (double)num6 / 10000.0 + (double)levelValue2);
			if (num5 != null && num7 > num5.Value)
			{
				num7 = num5.Value;
			}
			if (ecalculationPolicyType == ECalculationPolicyType.AddFromAttr)
			{
				owner.AddBaseValue(attributeId, num7 * (float)stackCount);
				return;
			}
			owner.SetBaseValue(attributeId, num7);
			return;
		}
		case 3:
			owner.SetBaseValue(attributeId, levelValue);
			return;
		case 5:
			owner.AddBaseValue(attributeId, levelValue * timeDilation * (float)stackCount);
			return;
		case 6:
		{
			int attrId2 = modifier.CalculationPolicy[1];
			EAttributeBasedFloatCalculationType attrCalcPolicy2 = EAttributeBasedFloatCalculationType.BaseValue;
			float num8 = snapshot ?? AbilityUtils.GetAttrValue(owner, (EAttributeType)attrId2, attrCalcPolicy2);
			owner.AddBaseValue(attributeId, (float)(((double)levelValue * (double)num8 / 10000.0 + (double)levelValue2) * (double)timeDilation * (double)stackCount));
			break;
		}
		case 7:
		case 8:
			break;
		default:
			return;
		}
	}

	// Token: 0x06018710 RID: 100112 RVA: 0x006DA187 File Offset: 0x006D8387
	public static void CreateStaticDefaultValue()
	{
		ActiveBuffInternal._buffPool = new List<ActiveBuffInternal>();
	}

	// Token: 0x06018711 RID: 100113 RVA: 0x006DA193 File Offset: 0x006D8393
	public static void ResetStaticDefaultValue()
	{
		ActiveBuffInternal._buffPool = null;
	}

	// Token: 0x0400BBC2 RID: 48066
	private const int MAX_POOL_COUNT = 100;

	// Token: 0x0400BBC3 RID: 48067
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<ActiveBuffInternal> _buffPool;

	// Token: 0x0400BBC4 RID: 48068
	private BuffDefinition ConfigInternal;

	// Token: 0x0400BBC5 RID: 48069
	private int HandleInternal = -1;

	// Token: 0x0400BBC6 RID: 48070
	private long? _preMessageId;

	// Token: 0x0400BBC7 RID: 48071
	private long _messageId = -1L;

	// Token: 0x0400BBC8 RID: 48072
	private string OwnerDebugName = "";

	// Token: 0x0400BBC9 RID: 48073
	[Nullable(2)]
	private BaseBuffComponent OwnerBuffCompInternal;

	// Token: 0x0400BBCA RID: 48074
	private bool RemoveBuffWhenTimeout = true;

	// Token: 0x0400BBCB RID: 48075
	private long InstigatorIdInternal;

	// Token: 0x0400BBCC RID: 48076
	private int ServerIdInternal = -1;

	// Token: 0x0400BBCD RID: 48077
	private long OriginalBuffIdInternal;

	// Token: 0x0400BBCE RID: 48078
	private int? ConfigOverrideListenerId;

	// Token: 0x0400BBCF RID: 48079
	protected Dictionary<int, float> BuffTimeScaleMap = new Dictionary<int, float>();

	// Token: 0x0400BBD0 RID: 48080
	protected float BuffTimeScale = 1f;

	// Token: 0x0400BBD1 RID: 48081
	[Nullable(2)]
	protected TimerHandle DurationTimer;

	// Token: 0x0400BBD2 RID: 48082
	private float DurationInternal = 1f;

	// Token: 0x0400BBD3 RID: 48083
	private readonly Stat ResetDurationTimerStat = Stat.Create("ActiveBuff.ResetDurationTimer", "", "");

	// Token: 0x0400BBD4 RID: 48084
	private float InnerCreateTimestamp;

	// Token: 0x0400BBD5 RID: 48085
	private float LastTimestamp;

	// Token: 0x0400BBD6 RID: 48086
	private float LastRemainingDuration;

	// Token: 0x0400BBD7 RID: 48087
	private float Timescale = 1f;

	// Token: 0x0400BBD8 RID: 48088
	private bool PrepareToDestroy;

	// Token: 0x0400BBD9 RID: 48089
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, HashSet<int>> ExecutionStateData;

	// Token: 0x0400BBDA RID: 48090
	private float PeriodUpdateTimestamp;

	// Token: 0x0400BBDB RID: 48091
	private float LastRemainingPeriod;

	// Token: 0x0400BBDC RID: 48092
	protected float PeriodInternal;

	// Token: 0x0400BBDD RID: 48093
	[Nullable(2)]
	private TimerHandle PeriodTimer;

	// Token: 0x0400BBDE RID: 48094
	private readonly Stat ResetPeriodTimerStat = Stat.Create("ActiveBuff.ResetPeriodTimer", "", "");

	// Token: 0x0400BBDF RID: 48095
	private bool IsActiveInternal;

	// Token: 0x0400BBE0 RID: 48096
	[StaticVariableRuleIgnore]
	private static readonly Stat SetActivateEnableStat = Stat.Create("ActiveBuffInternal.SetActivate_Enable", "", "");

	// Token: 0x0400BBE1 RID: 48097
	[StaticVariableRuleIgnore]
	private static readonly Stat SetActivateDisableStat = Stat.Create("ActiveBuffInternal.SetActivate_Disable", "", "");

	// Token: 0x0400BBE2 RID: 48098
	protected int StackCountInternal;

	// Token: 0x0400BBE3 RID: 48099
	public int StackLimitCount;

	// Token: 0x0400BBE4 RID: 48100
	private int LevelInternal;

	// Token: 0x0400BBE5 RID: 48101
	[TupleElementNames(new string[]
	{
		"AttributeId",
		"ModifierHandle"
	})]
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly List<ValueTuple<int, int>> NonStateModifierHandles = new List<ValueTuple<int, int>>();

	// Token: 0x0400BBE6 RID: 48102
	[TupleElementNames(new string[]
	{
		"Modifier",
		"Snapshot"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public readonly List<ValueTuple<IBuffModifierData, float?>> StateModifiers = new List<ValueTuple<IBuffModifierData, float?>>();

	// Token: 0x0400BBE7 RID: 48103
	[StaticVariableRuleIgnore]
	private static readonly Stat ClearModifiersStat = Stat.Create("ActiveBuffInternal.ClearModifiers", "", "");

	// Token: 0x0400BBE8 RID: 48104
	[StaticVariableRuleIgnore]
	private static readonly Stat ResetModifiersStat = Stat.Create("ActiveBuffInternal.ResetModifiers", "", "");

	// Token: 0x0400BBE9 RID: 48105
	[StaticVariableRuleIgnore]
	private static readonly Stat SetStateModifiersStat = Stat.Create("ActiveBuffInternal.SetStateModifier", "", "");

	// Token: 0x0400BBEA RID: 48106
	[StaticVariableRuleIgnore]
	private static readonly Stat SetNonStateModifierStat = Stat.Create("ActiveBuffInternal.SetNonStateModifier", "", "");

	// Token: 0x0400BBEB RID: 48107
	[StaticVariableRuleIgnore]
	private static readonly Stat ModifyStateAttributeStat = Stat.Create("ActiveBuffInternal.ModifyStateAttribute", "", "");
}
