using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using Google.Protobuf.Collections;

// Token: 0x0200323F RID: 12863
[NullableContext(1)]
[Nullable(0)]
public class PlayerBuffComponent : BaseBuffComponent
{
	// Token: 0x0601AC59 RID: 109657 RVA: 0x007FA9B9 File Offset: 0x007F8BB9
	[NullableContext(2)]
	protected override bool OnCreate(IEntityArgs args = null)
	{
		base.BuffEffectManager = new ExtraEffectManager(this);
		return true;
	}

	// Token: 0x0601AC5A RID: 109658 RVA: 0x007FA9C8 File Offset: 0x007F8BC8
	protected override bool OnInit()
	{
		base.OnInit();
		this.TimeScaleComponent = base.Entity.GetComponent<PawnTimeScaleComponent>();
		base.SetBuffComponentType(EBuffComponentType.TeamBuffComponent);
		return true;
	}

	// Token: 0x0601AC5B RID: 109659 RVA: 0x007FA9EC File Offset: 0x007F8BEC
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.PlayerId = ((creatureDataComponent != null) ? creatureDataComponent.GetPlayerId() : 0);
		if (this.PlayerId == 0)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Actor;
			Entity entity = base.Entity;
			string message = "PlayerId为0";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return true;
	}

	// Token: 0x0601AC5C RID: 109660 RVA: 0x007FAA5C File Offset: 0x007F8C5C
	protected override bool OnStart()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		return true;
	}

	// Token: 0x0601AC5D RID: 109661 RVA: 0x007FAA97 File Offset: 0x007F8C97
	protected override void OnActivate()
	{
		this.InitBornBuff();
	}

	// Token: 0x0601AC5E RID: 109662 RVA: 0x007FAAA0 File Offset: 0x007F8CA0
	protected override bool OnClear()
	{
		this.TriggerMap.Clear();
		this.BuffRefEntityIdMap.Clear();
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			activeBuffInternal.Destroy();
		}
		this.DelayAddCueBuffIds = null;
		base.OnClear();
		return true;
	}

	// Token: 0x0601AC5F RID: 109663 RVA: 0x007FAB1C File Offset: 0x007F8D1C
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		return true;
	}

	// Token: 0x0601AC60 RID: 109664 RVA: 0x007FAB57 File Offset: 0x007F8D57
	public override bool IsPaused()
	{
		CharacterBuffComponent currentBuffComponent = this.GetCurrentBuffComponent();
		return currentBuffComponent != null && currentBuffComponent.IsPaused();
	}

	// Token: 0x0601AC61 RID: 109665 RVA: 0x007FAB6C File Offset: 0x007F8D6C
	protected override void InitBornBuff()
	{
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		if (creatureDataComponent == null)
		{
			return;
		}
		EntityComponentPb entityComponentPb;
		creatureDataComponent.ComponentDataMap.TryGetValue("FightBuffComponent", out entityComponentPb);
		FightBuffComponentPb fightBuffComponentPb = (entityComponentPb != null) ? entityComponentPb.FightBuffComponent : null;
		if (fightBuffComponentPb == null)
		{
			return;
		}
		RepeatedField<BuffEffectCd> listBuffEffectCd = fightBuffComponentPb.ListBuffEffectCd;
		if (listBuffEffectCd != null)
		{
			foreach (BuffEffectCd buffEffectCd in listBuffEffectCd)
			{
				long buffId = Singleton<MathUtils>.Instance.LongToNumber(buffEffectCd.BuffId);
				for (int i = 0; i < buffEffectCd.ListCdRemaining.Count; i++)
				{
					this.SetBuffEffectCd(buffId, i, (float)(buffEffectCd.ListCdRemaining[i] * 1000));
				}
			}
		}
		RepeatedField<FightBuffInformation> fightBuffInfos = fightBuffComponentPb.FightBuffInfos;
		if (fightBuffInfos != null)
		{
			foreach (FightBuffInformation fightBuffInformation in fightBuffInfos)
			{
				long buffId2 = fightBuffInformation.BuffId;
				long instigatorId = fightBuffInformation.InstigatorId;
				int handleId = fightBuffInformation.HandleId;
				long overrideConfigId = 0L;
				if (fightBuffInformation.ConfBuffId != 0L)
				{
					overrideConfigId = fightBuffInformation.ConfBuffId;
				}
				base.AddBuffRemote(buffId2, handleId, overrideConfigId, new AddBuffParam
				{
					Level = new int?(fightBuffInformation.Level),
					InstigatorId = instigatorId,
					ApplyType = new ApplyGEType?(fightBuffInformation.ApplyType),
					Duration = new float?(fightBuffInformation.Duration),
					RemainDuration = new float?(fightBuffInformation.LeftDuration),
					IsActive = new bool?(fightBuffInformation.IsActive),
					ServerId = new int?(fightBuffInformation.ServerId),
					OuterStackCount = new int?(fightBuffInformation.StackCount),
					Reason = "服务器通过通知FightBuffComponent恢复PlayerBuff",
					MessageId = new long?(Singleton<MathUtils>.Instance.LongToBigInt(fightBuffInformation.MessageId)),
					BornBuff = new bool?(true)
				});
				ActiveBuffInternal activeBuffInternal;
				this.BuffContainer.TryGetValue(handleId, out activeBuffInternal);
				if (activeBuffInternal != null)
				{
					activeBuffInternal.SetRemainDuration(fightBuffInformation.LeftDuration);
				}
			}
		}
	}

	// Token: 0x0601AC62 RID: 109666 RVA: 0x007FADC0 File Offset: 0x007F8FC0
	protected override void OnAnyBuffInhibitionChanged(IActiveBuff buff)
	{
		if (buff.Config.FormationPolicy == EBuffFormationPolicy.FormationBuff && !ModelBase<SceneTeamModel>.Instance.IsTeamReady)
		{
			List<long> list = (this.DelayAddCueBuffIds != null) ? new List<long>(this.DelayAddCueBuffIds) : new List<long>();
			list.Add(buff.Id);
			this.DelayAddCueBuffIds = list.ToArray();
			return;
		}
		this.OnAnyBuffInhibitionChangedInternal(buff);
	}

	// Token: 0x0601AC63 RID: 109667 RVA: 0x007FAE22 File Offset: 0x007F9022
	private void OnAnyBuffInhibitionChangedInternal(IActiveBuff buff)
	{
		if (buff.IsActive())
		{
			base.CreateGameplayCueByBuff(buff);
			return;
		}
		base.DestroyGameplayCueByBuff(buff);
	}

	// Token: 0x0601AC64 RID: 109668 RVA: 0x007FAE3C File Offset: 0x007F903C
	public override string GetDebugName()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("player_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.PlayerId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601AC65 RID: 109669 RVA: 0x007FAE74 File Offset: 0x007F9074
	[NullableContext(2)]
	public override Entity GetEntity()
	{
		SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(this.PlayerId);
		long? num;
		if (teamPlayerData == null)
		{
			num = null;
		}
		else
		{
			SceneTeamGroup currentGroup = teamPlayerData.GetCurrentGroup();
			if (currentGroup == null)
			{
				num = null;
			}
			else
			{
				SceneTeamRole currentRole = currentGroup.GetCurrentRole();
				num = ((currentRole != null) ? new long?(currentRole.CreatureDataId) : null);
			}
		}
		long? num2 = num;
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num2.GetValueOrDefault());
		if (entity == null)
		{
			return null;
		}
		return entity.Entity;
	}

	// Token: 0x0601AC66 RID: 109670 RVA: 0x007FAEF0 File Offset: 0x007F90F0
	public override float GetTimeScale()
	{
		Entity entity = base.Entity;
		float? num = (entity != null) ? new float?(entity.TimeDilation) : null;
		PawnTimeScaleComponent timeScaleComponent = this.TimeScaleComponent;
		return (num * ((timeScaleComponent != null) ? timeScaleComponent.CurrentTimeScale : 1f)).GetValueOrDefault();
	}

	// Token: 0x0601AC67 RID: 109671 RVA: 0x007FAF5E File Offset: 0x007F915E
	public override float GetLogicTimeScale()
	{
		float timeDilation = base.Entity.TimeDilation;
		PawnTimeScaleComponent timeScaleComponent = this.TimeScaleComponent;
		return timeDilation * ((timeScaleComponent != null) ? timeScaleComponent.GetTopForeverTimeScale(new ESourceEffectGroup?(ESourceEffectGroup.LogicAndView)) : 1f);
	}

	// Token: 0x0601AC68 RID: 109672 RVA: 0x007FAF88 File Offset: 0x007F9188
	[NullableContext(2)]
	public CharacterBuffComponent GetCurrentBuffComponent()
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<CharacterBuffComponent>();
	}

	// Token: 0x0601AC69 RID: 109673 RVA: 0x007FAF9B File Offset: 0x007F919B
	[NullableContext(2)]
	public override BaseSkillComponent GetSkillComponent()
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseSkillComponent>();
	}

	// Token: 0x0601AC6A RID: 109674 RVA: 0x007FAFAE File Offset: 0x007F91AE
	[NullableContext(2)]
	public override BaseAttributeComponent GetAttributeComponent()
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseAttributeComponent>();
	}

	// Token: 0x0601AC6B RID: 109675 RVA: 0x007FAFC1 File Offset: 0x007F91C1
	[NullableContext(2)]
	public override BaseTagComponent GetTagComponent()
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseTagComponent>();
	}

	// Token: 0x0601AC6C RID: 109676 RVA: 0x007FAFD4 File Offset: 0x007F91D4
	protected override bool CheckAdd(BuffDefinition config, long instigatorId, bool fromServer)
	{
		return this.GetTagComponent() == null || base.CheckAdd(config, instigatorId, fromServer);
	}

	// Token: 0x0601AC6D RID: 109677 RVA: 0x007FAFE9 File Offset: 0x007F91E9
	protected override bool CheckActivate(BuffDefinition config, [Nullable(2)] Entity instigator)
	{
		return this.GetTagComponent() == null || base.CheckActivate(config, instigator);
	}

	// Token: 0x0601AC6E RID: 109678 RVA: 0x007FAFFD File Offset: 0x007F91FD
	public override bool HasBuffRoutineExpirationLock(long buffId)
	{
		if (this.BuffRoutineExpirationLock.GetValueOrDefault(buffId, 0) <= 0)
		{
			CharacterBuffComponent currentBuffComponent = this.GetCurrentBuffComponent();
			return ((currentBuffComponent != null) ? currentBuffComponent.BuffRoutineExpirationLock.GetValueOrDefault(buffId, 0) : 0) > 0;
		}
		return true;
	}

	// Token: 0x0601AC6F RID: 109679 RVA: 0x007FB02D File Offset: 0x007F922D
	[NullableContext(2)]
	public override BaseActorComponent GetActorComponent()
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		return entity.GetComponent<BaseActorComponent>();
	}

	// Token: 0x0601AC70 RID: 109680 RVA: 0x007FB040 File Offset: 0x007F9240
	public override int? GetBuffLevel(long buffId)
	{
		Entity entity = this.GetEntity();
		if (entity == null)
		{
			return null;
		}
		CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
		if (component == null)
		{
			return null;
		}
		return component.GetBuffLevel(buffId);
	}

	// Token: 0x0601AC71 RID: 109681 RVA: 0x007FB07A File Offset: 0x007F927A
	[NullableContext(2)]
	public override BaseGameplayCueComponent GetCueComponent()
	{
		return base.Entity.GetComponent<BaseGameplayCueComponent>();
	}

	// Token: 0x0601AC72 RID: 109682 RVA: 0x007FB087 File Offset: 0x007F9287
	public int GetFormationBuffTotalStackById(long buffId, bool onlyActiveBuff = false)
	{
		return base.GetBuffTotalStackById(buffId, onlyActiveBuff);
	}

	// Token: 0x0601AC73 RID: 109683 RVA: 0x007FB091 File Offset: 0x007F9291
	public override int GetBuffTotalStackById(long buffId, bool onlyActiveBuff = false)
	{
		CharacterBuffComponent currentBuffComponent = this.GetCurrentBuffComponent();
		return ((currentBuffComponent != null) ? currentBuffComponent.GetBuffTotalStackById(buffId, onlyActiveBuff) : 0) + base.GetBuffTotalStackById(buffId, onlyActiveBuff);
	}

	// Token: 0x0601AC74 RID: 109684 RVA: 0x007FB0B0 File Offset: 0x007F92B0
	public override bool HasBuffAuthority()
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int playerId = this.PlayerId;
		return id.GetValueOrDefault() == playerId & id != null;
	}

	// Token: 0x0601AC75 RID: 109685 RVA: 0x007FB0E4 File Offset: 0x007F92E4
	public unsafe override int AddBuffInner(long buffId, [Nullable(2)] BuffDefinition config, long? instigatorId, int level, int? outerStackCount, ApplyGEType? applyType, long? preMessageId, long? messageId, float? duration, bool? isActive, int serverId, string reason, bool fromServer, bool isIterable, bool isServerOrder, int? handle, long? bulletMessageId = null, bool? bornBuff = null)
	{
		if ((config == null || config.FormationPolicy != EBuffFormationPolicy.FormationBuff) && buffId != -3L)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "暂不支持对编队实体增删非编队buff";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return -1;
		}
		return base.AddBuffInner(buffId, config, instigatorId, level, outerStackCount, applyType, preMessageId, messageId, duration, isActive, serverId, reason, fromServer, isIterable, isServerOrder, handle, bulletMessageId, bornBuff);
	}

	// Token: 0x0601AC76 RID: 109686 RVA: 0x007FB190 File Offset: 0x007F9390
	protected override void OnBuffAdded(ActiveBuffInternal buff, int? stackCount, ApplyGEType applyType, long? preMessageId, float? duration, bool? isActive, int serverId, bool fromServer, bool isIterable, bool isServerRequest, string reason)
	{
		if (buff == null)
		{
			return;
		}
		this.BroadcastAddBuff(buff, applyType, isServerRequest, fromServer, reason);
		BuffDefinition config = buff.Config;
		base.OnBuffAdded(buff, stackCount, applyType, preMessageId, duration, isActive, serverId, fromServer, isIterable, isServerRequest, reason);
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		foreach (SceneTeamItem sceneTeamItem in (((instance != null) ? instance.GetTeamItemsByPlayer(this.PlayerId) : null) ?? new List<SceneTeamItem>()))
		{
			EntityHandle entityHandle = sceneTeamItem.EntityHandle;
			WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
			EntityHandle entityHandle2 = sceneTeamItem.EntityHandle;
			if (entityHandle2 != null && entityHandle2.Valid && worldEntity != null)
			{
				CharacterBuffComponent characterBuffComponent = (worldEntity != null) ? worldEntity.GetComponent<CharacterBuffComponent>() : null;
				if (characterBuffComponent != null && config.RemoveBuffWithTags != null && config.RemoveBuffWithTags.Length != 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
					defaultInterpolatedStringHandler.AppendLiteral("因为buff");
					defaultInterpolatedStringHandler.AppendFormatted<long>(buff.Id);
					defaultInterpolatedStringHandler.AppendLiteral("(handle=");
					defaultInterpolatedStringHandler.AppendFormatted<int>(buff.Handle);
					defaultInterpolatedStringHandler.AppendLiteral(")的RemoveBuffWithTags导致移除");
					string reason2 = defaultInterpolatedStringHandler.ToStringAndClear();
					foreach (int value in config.RemoveBuffWithTags)
					{
						if (characterBuffComponent.HasBuffAuthority())
						{
							characterBuffComponent.RemoveBuffByTag(new int?(value), reason2, null);
						}
						characterBuffComponent.TagComponent.RemoveTag(new int?(value));
					}
				}
			}
		}
	}

	// Token: 0x0601AC77 RID: 109687 RVA: 0x007FB33C File Offset: 0x007F953C
	protected override void OnBuffRemoved(ActiveBuffInternal buff, bool isPrematureRemoval, [Nullable(2)] string reason, bool? isServerRequest = null, long? preMessageId = null, long? instigatorId = null)
	{
		if (buff == null)
		{
			return;
		}
		this.BroadcastRemoveBuff(buff, isPrematureRemoval, isServerRequest, preMessageId, reason, instigatorId);
		base.OnBuffRemoved(buff, isPrematureRemoval, reason, isServerRequest, preMessageId, instigatorId);
		base.DestroyGameplayCueByBuff(buff);
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			CharacterStatisticsComponent component = base.Entity.GetComponent<CharacterStatisticsComponent>();
			if (component != null)
			{
				component.OnBuffRemoved(buff);
			}
			CharacterGasDebugComponent component2 = base.Entity.GetComponent<CharacterGasDebugComponent>();
			if (component2 == null)
			{
				return;
			}
			component2.OnBuffRemoved(buff);
		}
	}

	// Token: 0x0601AC78 RID: 109688 RVA: 0x007FB3AC File Offset: 0x007F95AC
	protected override void OnBuffStackIncreased(ActiveBuffInternal buff, int oldStack, int newStack, long? instigatorId, int level, int? outerStackCount, ApplyGEType applyType, long? preMessageId, float? duration, int serverId, bool isIterable, bool isServerOrder, [Nullable(2)] string reason, EBuffStackDurationOverride stackDurationRefreshPolicy = EBuffStackDurationOverride.Default, EBuffStackPeriodResetOverride stackPeriodResetPolicy = EBuffStackPeriodResetOverride.Default)
	{
		if (buff == null)
		{
			return;
		}
		base.OnBuffStackIncreased(buff, oldStack, newStack, instigatorId, level, outerStackCount, applyType, preMessageId, duration, serverId, isIterable, isServerOrder, reason, stackDurationRefreshPolicy, stackPeriodResetPolicy);
		this.BroadcastBuffStackChanged(buff, oldStack, newStack, false, stackDurationRefreshPolicy, stackPeriodResetPolicy, reason, instigatorId);
	}

	// Token: 0x0601AC79 RID: 109689 RVA: 0x007FB3F0 File Offset: 0x007F95F0
	protected override void OnBuffStackDecreased(ActiveBuffInternal buff, int oldStack, int newStack, bool isPrematureRemoval, [Nullable(2)] string reason, EBuffStackPeriodResetOverride stackPeriodResetPolicy = EBuffStackPeriodResetOverride.Default, long? instigatorId = null)
	{
		if (buff == null)
		{
			return;
		}
		base.OnBuffStackDecreased(buff, oldStack, newStack, isPrematureRemoval, reason, stackPeriodResetPolicy, instigatorId);
		this.BroadcastBuffStackChanged(buff, oldStack, newStack, isPrematureRemoval, EBuffStackDurationOverride.Default, stackPeriodResetPolicy, reason, instigatorId);
	}

	// Token: 0x0601AC7A RID: 109690 RVA: 0x007FB424 File Offset: 0x007F9624
	[NullableContext(2)]
	protected override void OnBuffActiveChanged(ActiveBuffInternal buff, bool isActive)
	{
		if (buff == null || buff.IsActive() == isActive)
		{
			return;
		}
		this.BroadcastActivateBuff(buff, isActive);
		base.OnBuffActiveChanged(buff, isActive);
	}

	// Token: 0x0601AC7B RID: 109691 RVA: 0x007FB444 File Offset: 0x007F9644
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		int buffLock = base.BuffLock;
		base.BuffLock = buffLock + 1;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (HashSet<int> hashSet2 in this.TagListenerDict.Values)
		{
			foreach (int item in hashSet2)
			{
				hashSet.Add(item);
			}
		}
		foreach (int handle in hashSet)
		{
			ActiveBuffInternal activeBuffInternal = base.GetBuffByHandle(handle) as ActiveBuffInternal;
			if (activeBuffInternal != null)
			{
				if (this.CheckRemove(activeBuffInternal.Config, activeBuffInternal.GetInstigator()))
				{
					this.RemoveBuffInner(handle, -1, true, "因为切人导致不满足tag条件", null, null, null);
				}
				else
				{
					bool flag = this.CheckActivate(activeBuffInternal.Config, activeBuffInternal.GetInstigator());
					if (flag != activeBuffInternal.IsActive())
					{
						this.OnBuffActiveChanged(activeBuffInternal, flag);
					}
				}
			}
		}
		buffLock = base.BuffLock;
		base.BuffLock = buffLock - 1;
	}

	// Token: 0x0601AC7C RID: 109692 RVA: 0x007FB5BC File Offset: 0x007F97BC
	private void OnUpdateSceneTeam()
	{
		if (this.DelayAddCueBuffIds != null)
		{
			foreach (long buffId in this.DelayAddCueBuffIds)
			{
				ActiveBuffInternal buffById = base.GetBuffById(buffId);
				if (buffById != null && buffById.IsValid())
				{
					this.OnAnyBuffInhibitionChangedInternal(buffById);
				}
			}
			this.DelayAddCueBuffIds = null;
		}
	}

	// Token: 0x0601AC7D RID: 109693 RVA: 0x007FB60C File Offset: 0x007F980C
	protected void BroadcastAddBuff(ActiveBuffInternal buff, ApplyGEType applyType, bool isServerRequest, bool fromServer, string reason)
	{
		if (buff == null || buff.Id < 0L || !this.NeedBroadcastBuff(buff, fromServer))
		{
			return;
		}
		if (!buff.IsInstantBuff() && buff.Handle < 0)
		{
			return;
		}
		ApplyGameplayEffectPush applyGameplayEffectPush = ApplyGameplayEffectPush.Create();
		applyGameplayEffectPush.Handle = buff.Handle;
		applyGameplayEffectPush.Id = Singleton<MathUtils>.Instance.NumberToLong(buff.Id);
		applyGameplayEffectPush.Level = buff.Level;
		if (buff.InstigatorId != null)
		{
			applyGameplayEffectPush.InstigatorId = Singleton<MathUtils>.Instance.NumberToLong(buff.InstigatorId.Value);
		}
		applyGameplayEffectPush.ApplyType = applyType;
		applyGameplayEffectPush.Duration = buff.GetRemainDuration();
		applyGameplayEffectPush.ServerId = buff.ServerId;
		applyGameplayEffectPush.StackCount = buff.StackCount;
		applyGameplayEffectPush.ConfBuffId = Singleton<MathUtils>.Instance.NumberToLong(0L);
		if (buff.GetConfigOverrideListenerId() != null)
		{
			long? id = buff.Config.Id;
			if (id != null)
			{
				long? num = id;
				long id2 = buff.Id;
				if (!(num.GetValueOrDefault() == id2 & num != null))
				{
					applyGameplayEffectPush.ConfBuffId = Singleton<MathUtils>.Instance.NumberToLong(id.Value);
				}
			}
		}
		Singleton<CombatNet>.Instance.Send(EPushMessageId.ApplyGameplayEffectPush, base.Entity, applyGameplayEffectPush, buff.PreMessageId, buff.MessageId, new bool?(isServerRequest));
	}

	// Token: 0x0601AC7E RID: 109694 RVA: 0x007FB768 File Offset: 0x007F9968
	protected void BroadcastActivateBuff(ActiveBuffInternal buff, bool on)
	{
		if (buff.Id < 0L || !this.NeedBroadcastBuff(buff, false))
		{
			return;
		}
		ActivateBuffPush activateBuffPush = ActivateBuffPush.Create();
		activateBuffPush.Handle = buff.Handle;
		activateBuffPush.On = on;
		Singleton<CombatNet>.Instance.Send(EPushMessageId.ActivateBuffPush, base.Entity, activateBuffPush, null, null, null);
	}

	// Token: 0x0601AC7F RID: 109695 RVA: 0x007FB7D8 File Offset: 0x007F99D8
	protected void BroadcastBuffStackChanged(ActiveBuffInternal buff, int oldStack, int newStack, bool isPrematureRemoval, EBuffStackDurationOverride stackDurationRefreshPolicy, EBuffStackPeriodResetOverride stackPeriodResetPolicy, [Nullable(2)] string reason, long? instigatorId = null)
	{
		if (buff.Id < 0L || !this.NeedBroadcastBuff(buff, false))
		{
			return;
		}
		BuffStackCountPush buffStackCountPush = BuffStackCountPush.Create();
		buffStackCountPush.HandleId = buff.Handle;
		buffStackCountPush.NewStackCount = newStack;
		buffStackCountPush.IsPrematureRemoval = isPrematureRemoval;
		buffStackCountPush.InstigatorId = instigatorId.GetValueOrDefault();
		buffStackCountPush.NotRefreshDuration = (stackDurationRefreshPolicy == EBuffStackDurationOverride.ForceNoRefresh);
		buffStackCountPush.NotRefreshPeriod = (stackPeriodResetPolicy == EBuffStackPeriodResetOverride.ForceNoRefresh);
		float remainDuration = buff.GetRemainDuration();
		if (remainDuration > 0f)
		{
			buffStackCountPush.Duration = remainDuration;
		}
		Singleton<CombatNet>.Instance.Send(EPushMessageId.BuffStackCountPush, base.Entity, buffStackCountPush, null, null, null);
	}

	// Token: 0x0601AC80 RID: 109696 RVA: 0x007FB888 File Offset: 0x007F9A88
	protected void BroadcastRemoveBuff(ActiveBuffInternal buff, bool isPrematureRemoval, bool? isServerRequest = null, long? preMessageId = null, [Nullable(2)] string reason = null, long? instigatorId = null)
	{
		if (buff.Id < 0L || !this.NeedBroadcastBuff(buff, false))
		{
			return;
		}
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		long? num = (component != null) ? new long?(component.GetCreatureDataId()) : null;
		RemoveGameplayEffectPush removeGameplayEffectPush = RemoveGameplayEffectPush.Create();
		removeGameplayEffectPush.Handle = buff.Handle;
		removeGameplayEffectPush.EntityId = Singleton<MathUtils>.Instance.NumberToLong(num.GetValueOrDefault());
		removeGameplayEffectPush.IsPrematureRemoval = isPrematureRemoval;
		removeGameplayEffectPush.Reason = (reason ?? "");
		removeGameplayEffectPush.InstigatorId = Singleton<MathUtils>.Instance.NumberToLong(instigatorId.GetValueOrDefault());
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RemoveGameplayEffectPush, base.Entity, removeGameplayEffectPush, preMessageId, null, isServerRequest);
	}

	// Token: 0x0601AC81 RID: 109697 RVA: 0x007FB94C File Offset: 0x007F9B4C
	protected unsafe override void AddBuffOrder(long buffId, AddBuffParam @params)
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "[buffComp] 客户端暂不能给其它玩家添加队伍buff";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("原因", @params.Reason);
		instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601AC82 RID: 109698 RVA: 0x007FB9D8 File Offset: 0x007F9BD8
	[NullableContext(2)]
	protected unsafe override void RemoveBuffOrder(long buffId, int stackCount, string reason, long? instigatorId = null)
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "[buffComp] 客户端暂不能给其它玩家移除队伍buff";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("原因", reason);
		instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601AC83 RID: 109699 RVA: 0x007FBA60 File Offset: 0x007F9C60
	protected unsafe override void RefreshBuffDurationOrder(long[] buffIds, [Nullable(2)] string reason)
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity = base.Entity;
		string message = "[buffComp] 客户端暂不能刷新其他玩家队伍buff的持续时长";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffIds);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("原因", reason);
		instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601AC84 RID: 109700 RVA: 0x007FBAE0 File Offset: 0x007F9CE0
	protected void FormationBuffApplyRequest()
	{
	}

	// Token: 0x0601AC85 RID: 109701 RVA: 0x007FBAE4 File Offset: 0x007F9CE4
	public override float CalculateDurationExtraRate(long buffId, bool asInstigator)
	{
		float num = base.CalculateDurationExtraRate(buffId, asInstigator);
		CharacterBuffComponent currentBuffComponent = this.GetCurrentBuffComponent();
		if (currentBuffComponent != null)
		{
			Dictionary<int, ValueTuple<float, float>> dictionary;
			(asInstigator ? currentBuffComponent.InstigatorBuffTimeModifiers : currentBuffComponent.OwnerBuffTimeModifiers).TryGetValue(buffId, out dictionary);
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, ValueTuple<float, float>> keyValuePair in dictionary)
				{
					float item = keyValuePair.Value.Item2;
					num += item;
				}
			}
		}
		return num;
	}

	// Token: 0x0601AC86 RID: 109702 RVA: 0x007FBB70 File Offset: 0x007F9D70
	public override float CalculatePeriodExtraRate(long buffId, bool asInstigator)
	{
		float num = base.CalculatePeriodExtraRate(buffId, asInstigator);
		CharacterBuffComponent currentBuffComponent = this.GetCurrentBuffComponent();
		if (currentBuffComponent != null)
		{
			Dictionary<int, ValueTuple<float, float>> dictionary;
			(asInstigator ? currentBuffComponent.InstigatorBuffTimeModifiers : currentBuffComponent.OwnerBuffTimeModifiers).TryGetValue(buffId, out dictionary);
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, ValueTuple<float, float>> keyValuePair in dictionary)
				{
					float item = keyValuePair.Value.Item1;
					num += item;
				}
			}
		}
		return num;
	}

	// Token: 0x0601AC87 RID: 109703 RVA: 0x007FBBFC File Offset: 0x007F9DFC
	public override void AddBuffRefEntityId(long buffId, int entityId)
	{
		HashSet<int> hashSet;
		if (!this.BuffRefEntityIdMap.TryGetValue(buffId, out hashSet))
		{
			hashSet = new HashSet<int>();
			this.BuffRefEntityIdMap[buffId] = hashSet;
		}
		hashSet.Add(entityId);
	}

	// Token: 0x0601AC88 RID: 109704 RVA: 0x007FBC34 File Offset: 0x007F9E34
	public override void RemoveBuffRefEntityId(long buffId, int entityId)
	{
		HashSet<int> hashSet;
		if (!this.BuffRefEntityIdMap.TryGetValue(buffId, out hashSet))
		{
			return;
		}
		hashSet.Remove(entityId);
		if (hashSet.Count == 0)
		{
			this.BuffRefEntityIdMap.Remove(buffId);
		}
	}

	// Token: 0x0601AC89 RID: 109705 RVA: 0x007FBC70 File Offset: 0x007F9E70
	public override bool HasBuffRefEntityId(long buffId)
	{
		HashSet<int> hashSet;
		return this.BuffRefEntityIdMap.TryGetValue(buffId, out hashSet) && hashSet.Count > 0;
	}

	// Token: 0x0601AC8A RID: 109706 RVA: 0x007FBC98 File Offset: 0x007F9E98
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PlayerBuffComponent playerBuffComponent = (PlayerBuffComponent)componentTemplate;
		if (base.CanResetComponentProperty("PlayerId"))
		{
			this.PlayerId = playerBuffComponent.PlayerId;
		}
		if (base.CanResetComponentProperty("TimeScaleComponent"))
		{
			if (playerBuffComponent.TimeScaleComponent == null)
			{
				this.TimeScaleComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.TimeScaleComponent), "TimeScaleComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DelayAddCueBuffIds"))
		{
			if (playerBuffComponent.DelayAddCueBuffIds == null)
			{
				this.DelayAddCueBuffIds = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<long[]>(this.DelayAddCueBuffIds), "DelayAddCueBuffIds"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffRefEntityIdMap"))
		{
			if (playerBuffComponent.BuffRefEntityIdMap == null)
			{
				this.BuffRefEntityIdMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<long, HashSet<int>>>(this.BuffRefEntityIdMap), "BuffRefEntityIdMap"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D92E RID: 55598
	public int PlayerId;

	// Token: 0x0400D92F RID: 55599
	[Nullable(2)]
	public PawnTimeScaleComponent TimeScaleComponent;

	// Token: 0x0400D930 RID: 55600
	[Nullable(2)]
	private long[] DelayAddCueBuffIds;

	// Token: 0x0400D931 RID: 55601
	private Dictionary<long, HashSet<int>> BuffRefEntityIdMap = new Dictionary<long, HashSet<int>>();

	// Token: 0x0400D932 RID: 55602
	[StaticVariableRuleIgnore]
	private static readonly Stat OnAnyBuffInhibitionChangedStat = Stat.Create("PlayerBuffComponent.OnAnyBuffInhibitionChangedInternal", "", "");

	// Token: 0x0400D933 RID: 55603
	[StaticVariableRuleIgnore]
	private static readonly Stat OnBuffAddedStat = Stat.Create("PlayerBuffComponent.OnBuffAdded", "", "");

	// Token: 0x0400D934 RID: 55604
	[StaticVariableRuleIgnore]
	private static readonly Stat OnBuffRemovedStat = Stat.Create("PlayerBuffComponent.OnBuffRemoved", "", "");

	// Token: 0x0400D935 RID: 55605
	[StaticVariableRuleIgnore]
	private static readonly Stat OnPlayerBuffStackIncreasedStat = Stat.Create("PlayerBuffComponent.OnBuffStackIncreased", "", "");

	// Token: 0x0400D936 RID: 55606
	[StaticVariableRuleIgnore]
	private static readonly Stat OnPlayerBuffStackDecreasedStat = Stat.Create("PlayerBuffComponent.OnBuffStackDecreased", "", "");

	// Token: 0x0400D937 RID: 55607
	[StaticVariableRuleIgnore]
	private static readonly Stat OnBuffActiveChangedStat = Stat.Create("PlayerBuffComponent.OnBuffActiveChanged", "", "");

	// Token: 0x0400D938 RID: 55608
	[StaticVariableRuleIgnore]
	private static readonly Stat BroadcastActivateBuffStat = Stat.Create("PlayerBuffComponent.BroadcastActivateBuff", "", "");
}
