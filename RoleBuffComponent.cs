using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020031E9 RID: 12777
[NullableContext(1)]
[Nullable(0)]
public class RoleBuffComponent : CharacterBuffComponent
{
	// Token: 0x0601A7FA RID: 108538 RVA: 0x007D4B38 File Offset: 0x007D2D38
	protected override bool OnStart()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.DoLeaveLevel, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Add(EEventName.OnEnterOnlineWorld, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Add(EEventName.OnLeaveOnlineWorld, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Add(EEventName.EnterInstanceDungeon, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.ClearCurrentRoleId));
		return true;
	}

	// Token: 0x0601A7FB RID: 108539 RVA: 0x007D4BF0 File Offset: 0x007D2DF0
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.DoLeaveLevel, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterOnlineWorld, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnLeaveOnlineWorld, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Remove(EEventName.EnterInstanceDungeon, new Action(this.ClearCurrentRoleId));
		Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.ClearCurrentRoleId));
		return true;
	}

	// Token: 0x0601A7FC RID: 108540 RVA: 0x007D4CA8 File Offset: 0x007D2EA8
	[NullableContext(2)]
	public PlayerBuffComponent GetFormationBuffComp()
	{
		if (!this.HasBuffAuthority())
		{
			Singleton<CombatLog>.Instance.Warn(CombatLog.EDebugModule.Buff, base.Entity, "暂不支持对其它玩家操作编队buff", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(ModelBase<CreatureModel>.Instance.GetPlayerId());
		if (playerEntity == null)
		{
			return null;
		}
		return playerEntity.GetComponent<PlayerBuffComponent>();
	}

	// Token: 0x0601A7FD RID: 108541 RVA: 0x007D4CFD File Offset: 0x007D2EFD
	protected override bool OnInit()
	{
		base.OnInit();
		base.SetBuffComponentType(EBuffComponentType.RoleBuffComponent);
		return true;
	}

	// Token: 0x0601A7FE RID: 108542 RVA: 0x007D4D10 File Offset: 0x007D2F10
	[NullableContext(2)]
	public override int AddBuffInner(long buffId, BuffDefinition config, long? instigatorId, int level, int? outerStackCount, ApplyGEType? applyType, long? preMessageId, long? messageId, float? duration, bool? isActive, int serverId, string reason, bool fromServer, bool isIterable, bool isServerOrder, int? handle, long? bulletMessageId = null, bool? bornBuff = null)
	{
		bool flag = false;
		long[] abnormalBuffIds = AbnormalBuffIds.abnormalBuffIds;
		for (int i = 0; i < abnormalBuffIds.Length; i++)
		{
			if (abnormalBuffIds[i] == buffId)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null || !tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.前台"]))
			{
				return -1;
			}
		}
		if (config == null || config.FormationPolicy != EBuffFormationPolicy.FormationBuff)
		{
			return base.AddBuffInner(buffId, config, instigatorId, level, outerStackCount, applyType, preMessageId, messageId, duration, isActive, serverId, reason, fromServer, isIterable, isServerOrder, handle, bulletMessageId, bornBuff);
		}
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp == null)
		{
			return -1;
		}
		return formationBuffComp.AddBuffInner(buffId, config, instigatorId, level, outerStackCount, applyType, preMessageId, messageId, duration, isActive, serverId, reason, fromServer, isIterable, isServerOrder, handle, bulletMessageId, bornBuff);
	}

	// Token: 0x0601A7FF RID: 108543 RVA: 0x007D4DD0 File Offset: 0x007D2FD0
	public unsafe override int RemoveBuffLocal(long buffId, int stackCount, string reason, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, reason);
		if (buffDefinition == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "[buffComp] 尝试本地移除buff时找不到合法配置";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("持有者", this.GetDebugName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("原因", reason);
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return 0;
		}
		if (buffDefinition.FormationPolicy != EBuffFormationPolicy.FormationBuff)
		{
			return base.RemoveBuffLocal(buffId, stackCount, reason, preMessageId, isServerRequest, instigatorId);
		}
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp == null)
		{
			return 0;
		}
		return formationBuffComp.RemoveBuffLocal(buffId, stackCount, reason, preMessageId, isServerRequest, instigatorId);
	}

	// Token: 0x0601A800 RID: 108544 RVA: 0x007D4E9C File Offset: 0x007D309C
	[NullableContext(2)]
	protected unsafe override void RemoveBuffOrder(long buffId, int stackCount, string reason, long? instigatorId = null)
	{
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, reason);
		if (buffDefinition != null && buffDefinition.FormationPolicy == EBuffFormationPolicy.FormationBuff)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = base.Entity;
			string message = "暂不支持移除远端编队buff";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("原因", reason);
			instance.Warn(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		base.RemoveBuffOrder(buffId, stackCount, reason, instigatorId);
	}

	// Token: 0x0601A801 RID: 108545 RVA: 0x007D4F2D File Offset: 0x007D312D
	public override void RemoveBuffByServerId(int serverId, int stackCount, long preMessageId, string reason, long? instigatorId = null)
	{
		base.RemoveBuffByServerId(serverId, stackCount, preMessageId, reason, instigatorId);
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp == null)
		{
			return;
		}
		formationBuffComp.RemoveBuffByServerId(serverId, stackCount, preMessageId, reason, instigatorId);
	}

	// Token: 0x0601A802 RID: 108546 RVA: 0x007D4F53 File Offset: 0x007D3153
	[NullableContext(2)]
	public override void RemoveBuffByTagLocal(int tagId, string reason, long? instigatorId = null)
	{
		if (this.HasBuffAuthority())
		{
			PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
			if (formationBuffComp != null)
			{
				formationBuffComp.RemoveBuffByTagLocal(tagId, reason, instigatorId);
			}
		}
		base.RemoveBuffByTagLocal(tagId, reason, instigatorId);
	}

	// Token: 0x0601A803 RID: 108547 RVA: 0x007D4F7C File Offset: 0x007D317C
	[NullableContext(2)]
	public override int RemoveBuffInner(int handle, int removeStackCount, bool isPrematureRemoval, string reason, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		return ((formationBuffComp != null) ? formationBuffComp.RemoveBuffInner(handle, removeStackCount, isPrematureRemoval, reason, preMessageId, isServerRequest, instigatorId) : 0) + base.RemoveBuffInner(handle, removeStackCount, isPrematureRemoval, reason, preMessageId, isServerRequest, instigatorId);
	}

	// Token: 0x0601A804 RID: 108548 RVA: 0x007D4FB8 File Offset: 0x007D31B8
	public override bool HasBuffAuthority()
	{
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPlayerId()) : null;
		CreatureModel instance = ModelBase<CreatureModel>.Instance;
		int? num2 = (instance != null) ? new int?(instance.GetPlayerId()) : null;
		return num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null);
	}

	// Token: 0x0601A805 RID: 108549 RVA: 0x007D5028 File Offset: 0x007D3228
	protected override void ShareApplyBuffInner(ActiveBuffInternal newBuff, int? outerStackCount, ApplyGEType applyType, long? preMessageId, float? duration, int serverId)
	{
		if (!this.HasBuffAuthority())
		{
			return;
		}
		BuffDefinition config = newBuff.Config;
		if (config != null && config.FormationPolicy == EBuffFormationPolicy.SharedByFormation)
		{
			List<CharacterBuffComponent> list = new List<CharacterBuffComponent>();
			List<EntityHandle> teamEntities = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true);
			bool flag = false;
			using (List<EntityHandle>.Enumerator enumerator = teamEntities.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Entity == base.Entity)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				foreach (EntityHandle entityHandle in teamEntities)
				{
					WorldEntity entity = entityHandle.Entity;
					CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
					if (entityHandle.Entity != base.Entity && characterBuffComponent != null)
					{
						list.Add(characterBuffComponent);
					}
				}
			}
			long id = newBuff.Id;
			int handle = newBuff.Handle;
			using (List<CharacterBuffComponent>.Enumerator enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					BaseBuffComponent baseBuffComponent = enumerator2.Current;
					long buffId = id;
					AddBuffParam addBuffParam = new AddBuffParam();
					addBuffParam.InstigatorId = newBuff.InstigatorId.GetValueOrDefault();
					addBuffParam.Level = new int?(newBuff.Level);
					addBuffParam.OuterStackCount = outerStackCount;
					addBuffParam.ApplyType = new ApplyGEType?(applyType);
					addBuffParam.PreMessageId = newBuff.MessageId;
					addBuffParam.Duration = duration;
					addBuffParam.ServerId = new int?(serverId);
					addBuffParam.IsIterable = new bool?(false);
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
					defaultInterpolatedStringHandler.AppendLiteral("因为buff");
					defaultInterpolatedStringHandler.AppendFormatted<long>(id);
					defaultInterpolatedStringHandler.AppendLiteral("(handle=");
					defaultInterpolatedStringHandler.AppendFormatted<int>(handle);
					defaultInterpolatedStringHandler.AppendLiteral(")的队伍共享机制导致的buff添加");
					addBuffParam.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
					baseBuffComponent.AddBuffLocal(buffId, addBuffParam);
				}
				return;
			}
		}
		base.ShareApplyBuffInner(newBuff, outerStackCount, applyType, newBuff.MessageId, duration, serverId);
	}

	// Token: 0x0601A806 RID: 108550 RVA: 0x007D523C File Offset: 0x007D343C
	public override bool CheckImmune(BuffDefinition config)
	{
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp != null && formationBuffComp.CheckImmune(config))
		{
			return true;
		}
		bool flag = false;
		using (List<ExtraEffectParameters>.Enumerator enumerator = config.EffectInfos.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ExtraEffectId == EExtraEffectId.Frozen)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasAnyTag(RoleBuffComponent.FrozenImmuneTags))
			{
				return true;
			}
		}
		return base.CheckImmune(config);
	}

	// Token: 0x0601A807 RID: 108551 RVA: 0x007D52D0 File Offset: 0x007D34D0
	public override bool HasBuffRoutineExpirationLock(long buffId)
	{
		if (this.BuffRoutineExpirationLock.GetValueOrDefault(buffId, 0) <= 0)
		{
			PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
			return formationBuffComp != null && formationBuffComp.BuffRoutineExpirationLock.GetValueOrDefault(buffId, 0) > 0;
		}
		return true;
	}

	// Token: 0x0601A808 RID: 108552 RVA: 0x007D52FF File Offset: 0x007D34FF
	public override void TriggerEvents(EBuffTriggerType passiveEffectType, [Nullable(2)] BaseBuffComponent opponentBuffComp, Partial_RequirementPayload payload)
	{
		base.TriggerEvents(passiveEffectType, opponentBuffComp, payload);
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp == null)
		{
			return;
		}
		formationBuffComp.TriggerEvents(passiveEffectType, opponentBuffComp, payload);
	}

	// Token: 0x0601A809 RID: 108553 RVA: 0x007D531D File Offset: 0x007D351D
	public override void AddPauseLock(string key, float timeScale = 0f)
	{
		base.AddPauseLock(key, timeScale);
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp == null)
		{
			return;
		}
		formationBuffComp.RefreshTimeScale();
	}

	// Token: 0x0601A80A RID: 108554 RVA: 0x007D5337 File Offset: 0x007D3537
	public override void RemovePauseLock(string key)
	{
		base.RemovePauseLock(key);
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp == null)
		{
			return;
		}
		formationBuffComp.RefreshTimeScale();
	}

	// Token: 0x0601A80B RID: 108555 RVA: 0x007D5350 File Offset: 0x007D3550
	[NullableContext(2)]
	protected override bool NeedBroadcastBuff(ActiveBuffInternal buff, bool fromServer = false)
	{
		return (buff == null || !NoBroadCastBuff.Values.Contains(buff.Id)) && base.NeedBroadcastBuff(buff, fromServer);
	}

	// Token: 0x0601A80C RID: 108556 RVA: 0x007D5374 File Offset: 0x007D3574
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		if (newEntity.Entity != null && CurrentRoleIdHolder.currentRoleId != newEntity.Entity.Id && base.Entity.Id == newEntity.Entity.Id)
		{
			if (CurrentRoleIdHolder.currentRoleId != 0)
			{
				this.TriggerEvents(EBuffTriggerType.ForOnStage, this, new Partial_RequirementPayload());
			}
			CurrentRoleIdHolder.currentRoleId = newEntity.Entity.Id;
		}
	}

	// Token: 0x0601A80D RID: 108557 RVA: 0x007D53D8 File Offset: 0x007D35D8
	private void ClearCurrentRoleId()
	{
		CurrentRoleIdHolder.currentRoleId = 0;
	}

	// Token: 0x0601A80E RID: 108558 RVA: 0x007D53E0 File Offset: 0x007D35E0
	public override float CalculateDurationExtraRate(long buffId, bool asInstigator)
	{
		float num = base.CalculateDurationExtraRate(buffId, asInstigator);
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp != null)
		{
			Dictionary<int, ValueTuple<float, float>> dictionary;
			(asInstigator ? formationBuffComp.InstigatorBuffTimeModifiers : formationBuffComp.OwnerBuffTimeModifiers).TryGetValue(buffId, out dictionary);
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

	// Token: 0x0601A80F RID: 108559 RVA: 0x007D546C File Offset: 0x007D366C
	public override float CalculatePeriodExtraRate(long buffId, bool asInstigator)
	{
		float num = base.CalculatePeriodExtraRate(buffId, asInstigator);
		PlayerBuffComponent formationBuffComp = this.GetFormationBuffComp();
		if (formationBuffComp != null)
		{
			Dictionary<int, ValueTuple<float, float>> dictionary;
			(asInstigator ? formationBuffComp.InstigatorBuffTimeModifiers : formationBuffComp.OwnerBuffTimeModifiers).TryGetValue(buffId, out dictionary);
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

	// Token: 0x0601A810 RID: 108560 RVA: 0x007D54F8 File Offset: 0x007D36F8
	[NullableContext(2)]
	public override BaseBuffComponent GetBuffApplyTarget(long buffId, long instigatorId)
	{
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, null);
		if (buffDefinition != null && buffDefinition.FormationPolicy == EBuffFormationPolicy.FormationBuff)
		{
			return this.GetFormationBuffComp();
		}
		return this;
	}

	// Token: 0x0601A811 RID: 108561 RVA: 0x007D551F File Offset: 0x007D371F
	protected override bool NeedAddBuffOrder(long buffId)
	{
		return true;
	}

	// Token: 0x0601A812 RID: 108562 RVA: 0x007D5524 File Offset: 0x007D3724
	protected new bool SeamlessTravelBuffRetain(IActiveBuff buff)
	{
		if (NoBroadCastBuff.Values.Contains(buff.Id))
		{
			return true;
		}
		if (this.SeamlessTravelRetainBuffPreMessage != 0L)
		{
			long? preMessageId = buff.PreMessageId;
			long seamlessTravelRetainBuffPreMessage = this.SeamlessTravelRetainBuffPreMessage;
			if (preMessageId.GetValueOrDefault() == seamlessTravelRetainBuffPreMessage & preMessageId != null)
			{
				return true;
			}
		}
		return base.SeamlessTravelBuffRetain(buff);
	}

	// Token: 0x0601A813 RID: 108563 RVA: 0x007D5578 File Offset: 0x007D3778
	public void SetSeamlessTravelBuffPreMessageId(long preMessageId)
	{
		this.SeamlessTravelRetainBuffPreMessage = preMessageId;
	}

	// Token: 0x0601A814 RID: 108564 RVA: 0x007D5581 File Offset: 0x007D3781
	protected override void OnSeamlessTravelingRefreshEnd()
	{
		this.SeamlessTravelRetainBuffPreMessage = 0L;
	}

	// Token: 0x0601A815 RID: 108565 RVA: 0x007D558C File Offset: 0x007D378C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleBuffComponent roleBuffComponent = (RoleBuffComponent)componentTemplate;
		if (base.CanResetComponentProperty("SeamlessTravelRetainBuffPreMessage"))
		{
			this.SeamlessTravelRetainBuffPreMessage = roleBuffComponent.SeamlessTravelRetainBuffPreMessage;
		}
		return true;
	}

	// Token: 0x0400D641 RID: 54849
	[StaticVariableRuleIgnore]
	protected static readonly int[] FrozenImmuneTags = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.钩锁"],
		GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"],
		GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.定点钩索"],
		GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.极限闪避"],
		GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"],
		GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"],
		GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌"],
		GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌"]
	};

	// Token: 0x0400D642 RID: 54850
	protected long SeamlessTravelRetainBuffPreMessage;
}
