using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Protocol;
using Aki.Protocol.BattleDefine;
using CSharpScript.Core.Common;
using CSharpScript.Game.NewWorld.Pawn.Component;
using Google.Protobuf.Collections;

// Token: 0x02002E99 RID: 11929
[NullableContext(1)]
[Nullable(0)]
public class CharacterBuffComponent : BaseBuffComponent
{
	// Token: 0x060187CE RID: 100302 RVA: 0x006DB904 File Offset: 0x006D9B04
	public override string GetDebugName()
	{
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		long num;
		if (creatureDataComponent == null)
		{
			Entity entity = base.Entity;
			num = (long)((entity != null) ? entity.Id : 0);
		}
		else
		{
			num = creatureDataComponent.GetCreatureDataId();
		}
		long num2 = num;
		return num2.ToString() ?? "";
	}

	// Token: 0x060187CF RID: 100303 RVA: 0x006DB946 File Offset: 0x006D9B46
	public override Entity GetEntity()
	{
		return base.Entity;
	}

	// Token: 0x060187D0 RID: 100304 RVA: 0x006DB950 File Offset: 0x006D9B50
	public virtual void AddPauseLock(string key, float timeScale = 0f)
	{
		if (timeScale <= 0f)
		{
			this.PauseLocks.Add(key);
			this.PauseRateLocks.Remove(key);
		}
		else
		{
			this.PauseLocks.Remove(key);
			this.PauseRateLocks[key] = Singleton<MathUtils>.Instance.Clamp(timeScale, 0f, 1f);
		}
		base.RefreshTimeScale();
	}

	// Token: 0x060187D1 RID: 100305 RVA: 0x006DB9B5 File Offset: 0x006D9BB5
	public virtual void RemovePauseLock(string key)
	{
		this.PauseLocks.Remove(key);
		this.PauseRateLocks.Remove(key);
		base.RefreshTimeScale();
	}

	// Token: 0x060187D2 RID: 100306 RVA: 0x006DB9D7 File Offset: 0x006D9BD7
	public override bool IsPaused()
	{
		return this.PauseLocks.Count > 0;
	}

	// Token: 0x060187D3 RID: 100307 RVA: 0x006DB9E8 File Offset: 0x006D9BE8
	private float GetPauseRate()
	{
		float num = 1f;
		foreach (float val in this.PauseRateLocks.Values)
		{
			num = Math.Min(num, val);
		}
		return num;
	}

	// Token: 0x060187D4 RID: 100308 RVA: 0x006DBA48 File Offset: 0x006D9C48
	public override float GetTimeScale()
	{
		float timeDilation = base.Entity.TimeDilation;
		PawnTimeScaleComponent timeScaleComponent = this.TimeScaleComponent;
		return timeDilation * ((timeScaleComponent != null) ? timeScaleComponent.CurrentTimeScale : 1f) * this.GetPauseRate();
	}

	// Token: 0x060187D5 RID: 100309 RVA: 0x006DBA73 File Offset: 0x006D9C73
	public override float GetLogicTimeScale()
	{
		float timeDilation = base.Entity.TimeDilation;
		PawnTimeScaleComponent timeScaleComponent = this.TimeScaleComponent;
		return timeDilation * ((timeScaleComponent != null) ? timeScaleComponent.GetTopForeverTimeScale(new ESourceEffectGroup?(ESourceEffectGroup.LogicAndView)) : 1f) * this.GetPauseRate();
	}

	// Token: 0x060187D6 RID: 100310 RVA: 0x006DBAA4 File Offset: 0x006D9CA4
	[NullableContext(2)]
	public override BaseAttributeComponent GetAttributeComponent()
	{
		return this.AttributeComponent;
	}

	// Token: 0x060187D7 RID: 100311 RVA: 0x006DBAAC File Offset: 0x006D9CAC
	[NullableContext(2)]
	public override BaseTagComponent GetTagComponent()
	{
		return this.TagComponent;
	}

	// Token: 0x060187D8 RID: 100312 RVA: 0x006DBAB4 File Offset: 0x006D9CB4
	[NullableContext(2)]
	public override BaseSkillComponent GetSkillComponent()
	{
		return base.Entity.GetComponent<BaseSkillComponent>();
	}

	// Token: 0x060187D9 RID: 100313 RVA: 0x006DBAC1 File Offset: 0x006D9CC1
	[NullableContext(2)]
	public override BaseActorComponent GetActorComponent()
	{
		return this.ActorComponent;
	}

	// Token: 0x060187DA RID: 100314 RVA: 0x006DBAC9 File Offset: 0x006D9CC9
	[NullableContext(2)]
	public override BaseGameplayCueComponent GetCueComponent()
	{
		return this.CueComponent;
	}

	// Token: 0x060187DB RID: 100315 RVA: 0x006DBAD1 File Offset: 0x006D9CD1
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		base.BuffEffectManager = new ExtraEffectManager(this);
		return true;
	}

	// Token: 0x060187DC RID: 100316 RVA: 0x006DBAE0 File Offset: 0x006D9CE0
	protected override bool OnInit()
	{
		base.OnInit();
		this.ActorComponent = base.Entity.CheckGetComponent<BaseActorComponent>();
		this.AttributeComponent = base.Entity.CheckGetComponent<BaseAttributeComponent>();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.CueComponent = base.Entity.GetComponent<CharacterGameplayCueComponent>();
		this.DeathComponent = base.Entity.GetComponent<BaseDeathComponent>();
		this.TimeScaleComponent = base.Entity.GetComponent<PawnTimeScaleComponent>();
		return true;
	}

	// Token: 0x060187DD RID: 100317 RVA: 0x006DBB5B File Offset: 0x006D9D5B
	protected override bool OnStart()
	{
		ExtraEffectManager buffEffectManager = base.BuffEffectManager;
		if (buffEffectManager != null)
		{
			buffEffectManager.Clear();
		}
		return true;
	}

	// Token: 0x060187DE RID: 100318 RVA: 0x006DBB70 File Offset: 0x006D9D70
	protected override void InitBornBuff()
	{
		Dictionary<string, EntityComponentPb> componentDataMap = this.CreatureDataComponent.ComponentDataMap;
		EntityComponentPb entityComponentPb;
		componentDataMap.TryGetValue("SysBuffComponent", out entityComponentPb);
		RepeatedField<SysBuffInformation> repeatedField;
		if (entityComponentPb == null)
		{
			repeatedField = null;
		}
		else
		{
			SysBuffComponentPb sysBuffComponent = entityComponentPb.SysBuffComponent;
			repeatedField = ((sysBuffComponent != null) ? sysBuffComponent.SysBuffInfos : null);
		}
		RepeatedField<SysBuffInformation> repeatedField2 = repeatedField;
		if (repeatedField2 != null && this.HasBuffAuthority())
		{
			foreach (SysBuffInformation sysBuffInformation in repeatedField2)
			{
				long instigatorId = sysBuffInformation.InstigatorId;
				long? num = (sysBuffInformation.MessageId != 0L) ? new long?(Singleton<MathUtils>.Instance.LongToBigInt(sysBuffInformation.MessageId)) : null;
				long buffId = sysBuffInformation.BuffId;
				long buffId2 = buffId;
				AddBuffParam addBuffParam = new AddBuffParam();
				addBuffParam.InstigatorId = instigatorId;
				addBuffParam.Level = new int?(sysBuffInformation.Level);
				addBuffParam.ApplyType = new ApplyGEType?(sysBuffInformation.ApplyType);
				addBuffParam.PreMessageId = num;
				addBuffParam.Duration = new float?(sysBuffInformation.Duration);
				addBuffParam.IsIterable = new bool?(sysBuffInformation.IsIterable);
				addBuffParam.OuterStackCount = new int?(sysBuffInformation.StackCount);
				addBuffParam.ServerId = new int?(sysBuffInformation.ServerId);
				addBuffParam.IsServerOrder = new bool?(true);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
				defaultInterpolatedStringHandler.AppendLiteral("服务端或其它客户端请求添加Buff(缓冲) messageId=");
				defaultInterpolatedStringHandler.AppendFormatted<long?>(num);
				addBuffParam.Reason = defaultInterpolatedStringHandler.ToStringAndClear();
				addBuffParam.BornBuff = new bool?(true);
				this.AddBuffLocal(buffId2, addBuffParam);
			}
		}
		EntityComponentPb entityComponentPb2;
		componentDataMap.TryGetValue("FightBuffComponent", out entityComponentPb2);
		FightBuffComponentPb fightBuffComponentPb = (entityComponentPb2 != null) ? entityComponentPb2.FightBuffComponent : null;
		if (fightBuffComponentPb == null)
		{
			return;
		}
		RepeatedField<BuffEffectCd> listBuffEffectCd = fightBuffComponentPb.ListBuffEffectCd;
		RepeatedField<FightBuffInformation> fightBuffInfos = fightBuffComponentPb.FightBuffInfos;
		if (listBuffEffectCd != null)
		{
			foreach (BuffEffectCd buffEffectCd in listBuffEffectCd)
			{
				long buffId3 = buffEffectCd.BuffId;
				for (int i = 0; i < buffEffectCd.ListCdRemaining.Count; i++)
				{
					this.SetBuffEffectCd(buffId3, i, (float)(buffEffectCd.ListCdRemaining[i] * 1000));
				}
			}
		}
		if (fightBuffInfos != null)
		{
			foreach (FightBuffInformation fightBuffInformation in fightBuffInfos)
			{
				long buffId4 = fightBuffInformation.BuffId;
				long instigatorId2 = fightBuffInformation.InstigatorId;
				int handleId = fightBuffInformation.HandleId;
				long overrideConfigId = 0L;
				if (fightBuffInformation.ConfBuffId != 0L)
				{
					overrideConfigId = fightBuffInformation.ConfBuffId;
				}
				base.AddBuffRemote(buffId4, handleId, overrideConfigId, new AddBuffParam
				{
					Level = new int?(fightBuffInformation.Level),
					InstigatorId = instigatorId2,
					ApplyType = new ApplyGEType?(fightBuffInformation.ApplyType),
					Duration = new float?(fightBuffInformation.Duration),
					RemainDuration = new float?(fightBuffInformation.LeftDuration),
					IsActive = new bool?(fightBuffInformation.IsActive),
					ServerId = new int?(fightBuffInformation.ServerId),
					OuterStackCount = new int?(fightBuffInformation.StackCount),
					Reason = "服务器通过通知FightBuffComponent恢复Buff",
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
		RepeatedField<long> needClientApplyBuffIds = fightBuffComponentPb.NeedClientApplyBuffIds;
		long value = Singleton<MathUtils>.Instance.LongToBigInt(fightBuffComponentPb.NeedClientApplyBuffIdsMessageId);
		if (needClientApplyBuffIds != null)
		{
			foreach (long buffId5 in needClientApplyBuffIds)
			{
				this.AddBuff(buffId5, new AddBuffParam
				{
					InstigatorId = base.CreatureDataId,
					Reason = "客户端出生buff",
					PreMessageId = new long?(value)
				});
			}
		}
	}

	// Token: 0x060187DF RID: 100319 RVA: 0x006DBFD8 File Offset: 0x006DA1D8
	protected override bool OnClear()
	{
		this.TriggerMap.Clear();
		List<ActiveBuffInternal> list = new List<ActiveBuffInternal>(this.BuffContainer.Values);
		this.PauseLocks.Clear();
		this.PauseRateLocks.Clear();
		base.OnClear();
		foreach (ActiveBuffInternal activeBuffInternal in list)
		{
			activeBuffInternal.Destroy();
		}
		return true;
	}

	// Token: 0x060187E0 RID: 100320 RVA: 0x006DC05C File Offset: 0x006DA25C
	protected override void OnActivate()
	{
		foreach (IActiveBuff buff in base.GetAllBuffs())
		{
			base.CreateGameplayCueByBuff(buff);
		}
		this.CueInited = true;
		this.InitBornBuff();
	}

	// Token: 0x060187E1 RID: 100321 RVA: 0x006DC096 File Offset: 0x006DA296
	protected override void OnAnyBuffInhibitionChanged(IActiveBuff buff)
	{
		if (!this.CueInited)
		{
			return;
		}
		base.OnAnyBuffInhibitionChanged(buff);
	}

	// Token: 0x060187E2 RID: 100322 RVA: 0x006DC0A8 File Offset: 0x006DA2A8
	public override bool HasBuffAuthority()
	{
		if (this.CreatureDataComponent != null)
		{
			if (this.CreatureDataComponent.GetEntityType() == EEntityType.Monster)
			{
				BaseDeathComponent deathComponent = this.DeathComponent;
				if (deathComponent != null && deathComponent.IsDead())
				{
					return true;
				}
			}
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetSummonerPlayerId()) : null;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int? num2 = num;
			return id.GetValueOrDefault() == num2.GetValueOrDefault() & id != null == (num2 != null);
		}
		return true;
	}

	// Token: 0x060187E3 RID: 100323 RVA: 0x006DC130 File Offset: 0x006DA330
	protected override bool NeedAddBuffOrder(long buffId)
	{
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, null);
		if (buffDefinition == null)
		{
			return false;
		}
		if (buffDefinition.FormationPolicy == EBuffFormationPolicy.FormationBuff)
		{
			CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
			if (creatureDataComponent != null && creatureDataComponent.IsMonster())
			{
				CreatureDataComponent creatureDataComponent2 = this.CreatureDataComponent;
				if (creatureDataComponent2 != null && creatureDataComponent2.GetSummonerPlayerId() == 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060187E4 RID: 100324 RVA: 0x006DC188 File Offset: 0x006DA388
	public unsafe void AddBuffWithServerId(long buffId, int level, int addTimes, int serverId, string reason)
	{
		if (buffId <= 0L)
		{
			return;
		}
		for (int i = 0; i < addTimes; i++)
		{
			int num = this.AddBuffLocal(buffId, new AddBuffParam
			{
				InstigatorId = base.CreatureDataId,
				Level = new int?(level),
				Duration = new float?((float)-1),
				ServerId = new int?(serverId),
				Reason = reason
			});
			BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, reason);
			if (num == -1)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity = base.Entity;
				string message = "系统buff添加失败";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("serverId", serverId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("持有者", this.GetDebugName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("说明", (buffDefinition != null) ? buffDefinition.Desc : null);
				instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
		}
	}

	// Token: 0x060187E5 RID: 100325 RVA: 0x006DC2A8 File Offset: 0x006DA4A8
	public void RemoveBuffByTagName(string tagName, [Nullable(2)] string reason = null)
	{
		int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
		this.RemoveBuffByTag(new int?(tagIdByName), reason, null);
	}

	// Token: 0x060187E6 RID: 100326 RVA: 0x006DC2D4 File Offset: 0x006DA4D4
	[NullableContext(2)]
	public void RemoveBuffByTag(int? tagId, string reason = null, long? instigatorId = null)
	{
		if (tagId == null)
		{
			return;
		}
		if (this.HasBuffAuthority())
		{
			this.RemoveBuffByTagLocal(tagId.Value, reason, instigatorId);
			return;
		}
		OrderRemoveBuffByTagsRequest orderRemoveBuffByTagsRequest = OrderRemoveBuffByTagsRequest.Create();
		orderRemoveBuffByTagsRequest.TagIds.Add(tagId.Value);
		orderRemoveBuffByTagsRequest.InstigatorId = Singleton<MathUtils>.Instance.NumberToLong(instigatorId.GetValueOrDefault());
		Singleton<CombatNet>.Instance.Call<OrderRemoveBuffByTagsResponse>(ERequestMessageId.OrderRemoveBuffByTagsRequest, base.Entity, orderRemoveBuffByTagsRequest, delegate(OrderRemoveBuffByTagsResponse response)
		{
			if (response != null && response.ErrorCode == ErrorCode.ErrSceneEntityNotExist)
			{
				string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId.Value);
				foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
				{
					if (activeBuffInternal.Config.GrantedTags != null)
					{
						bool flag = false;
						int[] grantedTags = activeBuffInternal.Config.GrantedTags;
						for (int i = 0; i < grantedTags.Length; i++)
						{
							if (GameplayTagUtils.IsChildTag(grantedTags[i], tagId.Value))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							this.RemoveBuffInner(activeBuffInternal.Handle, -1, true, reason ?? ("移除tag " + nameByTagId), null, new bool?(false), instigatorId);
						}
					}
				}
			}
		}, null, null, null, null);
	}

	// Token: 0x060187E7 RID: 100327 RVA: 0x006DC3B8 File Offset: 0x006DA5B8
	public void RemoveAllBuffs(string reason)
	{
		if (this.HasBuffAuthority())
		{
			using (List<int>.Enumerator enumerator = new List<int>(this.BuffContainer.Keys).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int handle = enumerator.Current;
					this.RemoveBuffByHandle(handle, -1, reason, null, null, null);
				}
				return;
			}
		}
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			if (activeBuffInternal != null && activeBuffInternal.IsValid())
			{
				this.RemoveBuffOrder(activeBuffInternal.Id, -1, reason, null);
			}
		}
	}

	// Token: 0x060187E8 RID: 100328 RVA: 0x006DC4A4 File Offset: 0x006DA6A4
	public void RemoveAllBuffsByInstigator(CharacterBuffComponent instigator, string reason)
	{
		long? num = (instigator != null) ? new long?(instigator.CreatureDataId) : null;
		List<int> list = new List<int>(this.BuffContainer.Keys);
		if (this.HasBuffAuthority())
		{
			using (List<int>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int handle = enumerator.Current;
					IActiveBuff buffByHandle = base.GetBuffByHandle(handle);
					bool flag;
					if (buffByHandle == null)
					{
						flag = (num == null);
					}
					else
					{
						long? num2 = buffByHandle.InstigatorId;
						long? num3 = num;
						flag = (num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null));
					}
					if (flag)
					{
						this.RemoveBuffByHandle(handle, -1, reason, null, null, null);
					}
				}
				return;
			}
		}
		foreach (int handle2 in list)
		{
			IActiveBuff buffByHandle2 = base.GetBuffByHandle(handle2);
			bool flag2;
			if (buffByHandle2 == null)
			{
				flag2 = (num == null);
			}
			else
			{
				long? num3 = buffByHandle2.InstigatorId;
				long? num2 = num;
				flag2 = (num3.GetValueOrDefault() == num2.GetValueOrDefault() & num3 != null == (num2 != null));
			}
			if (flag2)
			{
				this.RemoveBuffOrder(buffByHandle2.Id, -1, reason, null);
			}
		}
	}

	// Token: 0x060187E9 RID: 100329 RVA: 0x006DC62C File Offset: 0x006DA82C
	public void RemoveAllDurationBuffs(string reason)
	{
		List<int> list = new List<int>();
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			if (activeBuffInternal.Config.DurationPolicy == EBuffDurationType.HasDuration && activeBuffInternal.Config.DeadRemove)
			{
				list.Add(activeBuffInternal.Handle);
			}
		}
		foreach (int handle in list)
		{
			this.RemoveBuffByHandle(handle, -1, reason, null, null, null);
		}
	}

	// Token: 0x060187EA RID: 100330 RVA: 0x006DC70C File Offset: 0x006DA90C
	public override int? GetBuffLevel(long buffId)
	{
		RoleGrowComponent component = base.Entity.GetComponent<RoleGrowComponent>();
		int? num = (component != null) ? new int?(component.GetSkillLevelByBuffId(buffId)) : null;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				return num;
			}
		}
		CharacterVisionComponent component2 = base.Entity.GetComponent<CharacterVisionComponent>();
		int? num4 = (component2 != null) ? new int?(component2.GetVisionLevelByBuffId(buffId)) : null;
		if (num4 != null)
		{
			int? num2 = num4;
			int num3 = 0;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				return num4;
			}
		}
		return null;
	}

	// Token: 0x060187EB RID: 100331 RVA: 0x006DC7B4 File Offset: 0x006DA9B4
	protected override void OnBuffAdded(ActiveBuffInternal buff, int? stackCount, ApplyGEType applyType, long? preMessageId, float? duration, bool? isActive, int serverId, bool fromServer, bool isIterable, bool isServerRequest, string reason)
	{
		if (buff == null)
		{
			return;
		}
		this.BroadcastAddBuff(buff, applyType, isServerRequest, fromServer, reason);
		BuffDefinition config = buff.Config;
		base.OnBuffAdded(buff, stackCount, applyType, preMessageId, duration, isActive, serverId, fromServer, isIterable, isServerRequest, reason);
		if (config.RemoveBuffWithTags != null && config.RemoveBuffWithTags.Length != 0)
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
				if (this.HasBuffAuthority())
				{
					this.RemoveBuffByTag(new int?(value), reason2, null);
				}
				this.TagComponent.RemoveTag(new int?(value));
			}
		}
		if (isIterable)
		{
			this.ShareApplyBuffInner(buff, stackCount, applyType, buff.MessageId, duration, serverId);
		}
	}

	// Token: 0x060187EC RID: 100332 RVA: 0x006DC8C4 File Offset: 0x006DAAC4
	protected virtual void ShareApplyBuffInner(ActiveBuffInternal newBuff, int? outerStackCount, ApplyGEType applyType, long? preMessageId, float? duration, int serverId)
	{
		if (!this.HasBuffAuthority())
		{
			return;
		}
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		long? num = (creatureDataComponent != null) ? new long?(creatureDataComponent.GetSummonerId()) : null;
		if (num != null)
		{
			BuffDefinition config = newBuff.Config;
			if (config != null && config.FormationPolicy == EBuffFormationPolicy.SharedToSummoner)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num.Value);
				CharacterBuffComponent characterBuffComponent;
				if (entity == null)
				{
					characterBuffComponent = null;
				}
				else
				{
					WorldEntity entity2 = entity.Entity;
					characterBuffComponent = ((entity2 != null) ? entity2.GetComponent<CharacterBuffComponent>() : null);
				}
				CharacterBuffComponent characterBuffComponent2 = characterBuffComponent;
				if (characterBuffComponent2 != null)
				{
					long id = newBuff.Id;
					int handle = newBuff.Handle;
					BaseBuffComponent baseBuffComponent = characterBuffComponent2;
					long buffId = id;
					AddBuffParam addBuffParam = new AddBuffParam();
					addBuffParam.InstigatorId = newBuff.InstigatorId.GetValueOrDefault();
					addBuffParam.Level = new int?(newBuff.Level);
					addBuffParam.OuterStackCount = outerStackCount;
					addBuffParam.ApplyType = new ApplyGEType?(applyType);
					addBuffParam.PreMessageId = preMessageId;
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
			}
		}
	}

	// Token: 0x060187ED RID: 100333 RVA: 0x006DCA1C File Offset: 0x006DAC1C
	protected override void OnBuffRemoved(ActiveBuffInternal buff, bool isPrematureRemoval, [Nullable(2)] string reason, bool? isServerRequest = null, long? preMessageId = null, long? instigatorId = null)
	{
		if (buff == null)
		{
			return;
		}
		this.BroadcastRemoveBuff(buff, isPrematureRemoval, isServerRequest, preMessageId, reason, instigatorId);
		base.OnBuffRemoved(buff, isPrematureRemoval, reason, isServerRequest, preMessageId, instigatorId);
		if (this.CueInited)
		{
			base.DestroyGameplayCueByBuff(buff);
		}
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

	// Token: 0x060187EE RID: 100334 RVA: 0x006DCA94 File Offset: 0x006DAC94
	protected override void OnBuffStackIncreased(ActiveBuffInternal buff, int oldStack, int newStack, long? instigatorId, int level, int? outerStackCount, ApplyGEType applyType, long? preMessageId, float? duration, int serverId, bool isIterable, bool isServerOrder, [Nullable(2)] string reason, EBuffStackDurationOverride stackDurationRefreshPolicy = EBuffStackDurationOverride.Default, EBuffStackPeriodResetOverride stackPeriodResetPolicy = EBuffStackPeriodResetOverride.Default)
	{
		if (buff == null)
		{
			return;
		}
		base.OnBuffStackIncreased(buff, oldStack, newStack, instigatorId, level, outerStackCount, applyType, preMessageId, duration, serverId, isIterable, isServerOrder, reason, stackDurationRefreshPolicy, stackPeriodResetPolicy);
		this.BroadcastBuffStackChanged(buff, oldStack, newStack, false, stackDurationRefreshPolicy, stackPeriodResetPolicy, reason, instigatorId);
		if (this.HasBuffAuthority() && isIterable)
		{
			this.ShareApplyBuffInner(buff, outerStackCount, applyType, buff.MessageId, duration, serverId);
		}
	}

	// Token: 0x060187EF RID: 100335 RVA: 0x006DCAF8 File Offset: 0x006DACF8
	protected override void OnBuffStackDecreased(ActiveBuffInternal buff, int oldStack, int newStack, bool isPrematureRemoval, [Nullable(2)] string reason, EBuffStackPeriodResetOverride stackPeriodResetPolicy = EBuffStackPeriodResetOverride.Default, long? instigatorId = null)
	{
		if (buff == null)
		{
			return;
		}
		base.OnBuffStackDecreased(buff, oldStack, newStack, isPrematureRemoval, reason, stackPeriodResetPolicy, instigatorId);
		this.BroadcastBuffStackChanged(buff, oldStack, newStack, isPrematureRemoval, EBuffStackDurationOverride.Default, stackPeriodResetPolicy, reason, instigatorId);
	}

	// Token: 0x060187F0 RID: 100336 RVA: 0x006DCB2C File Offset: 0x006DAD2C
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

	// Token: 0x060187F1 RID: 100337 RVA: 0x006DCB4C File Offset: 0x006DAD4C
	protected void BroadcastAddBuff(ActiveBuffInternal buff, ApplyGEType applyType, bool isServerRequest, bool fromServer, string reason)
	{
		if (buff.Id < 0L || !this.NeedBroadcastBuff(buff, fromServer))
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
		applyGameplayEffectPush.Reason = reason;
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

	// Token: 0x060187F2 RID: 100338 RVA: 0x006DCCAC File Offset: 0x006DAEAC
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

	// Token: 0x060187F3 RID: 100339 RVA: 0x006DCD1C File Offset: 0x006DAF1C
	protected void BroadcastBuffStackChanged(ActiveBuffInternal buff, int oldStack, int newStack, bool isPrematureRemoval, EBuffStackDurationOverride stackDurationRefreshPolicy, EBuffStackPeriodResetOverride stackPeriodResetPolicy, [Nullable(2)] string reason, long? instigatorId = null)
	{
		if (buff == null || buff.Id < 0L || !this.NeedBroadcastBuff(buff, false))
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
		buffStackCountPush.Reason = (reason ?? "");
		Singleton<CombatNet>.Instance.Send(EPushMessageId.BuffStackCountPush, base.Entity, buffStackCountPush, null, null, null);
	}

	// Token: 0x060187F4 RID: 100340 RVA: 0x006DCDE0 File Offset: 0x006DAFE0
	protected void BroadcastRemoveBuff(ActiveBuffInternal buff, bool isPrematureRemoval, bool? isServerRequest = null, long? preMessageId = null, [Nullable(2)] string reason = null, long? instigatorId = null)
	{
		if (buff.Id < 0L || !this.NeedBroadcastBuff(buff, false))
		{
			return;
		}
		RemoveGameplayEffectPush removeGameplayEffectPush = RemoveGameplayEffectPush.Create();
		removeGameplayEffectPush.Handle = buff.Handle;
		removeGameplayEffectPush.EntityId = Singleton<MathUtils>.Instance.NumberToLong(base.CreatureDataId);
		removeGameplayEffectPush.IsPrematureRemoval = isPrematureRemoval;
		removeGameplayEffectPush.Reason = (reason ?? "");
		removeGameplayEffectPush.InstigatorId = Singleton<MathUtils>.Instance.NumberToLong(instigatorId.GetValueOrDefault());
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RemoveGameplayEffectPush, base.Entity, removeGameplayEffectPush, preMessageId, null, isServerRequest);
	}

	// Token: 0x060187F5 RID: 100341 RVA: 0x006DCE7C File Offset: 0x006DB07C
	[NullableContext(2)]
	protected override void RemoveBuffOrder(long buffId, int stackCount, string reason, long? instigatorId = null)
	{
		if (buffId <= 0L)
		{
			return;
		}
		ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, reason);
		OrderRemoveBuffRequest orderRemoveBuffRequest = OrderRemoveBuffRequest.Create();
		orderRemoveBuffRequest.Id = Singleton<MathUtils>.Instance.NumberToLong(buffId);
		orderRemoveBuffRequest.StackCount = stackCount;
		orderRemoveBuffRequest.Reason = (reason ?? "");
		orderRemoveBuffRequest.InstigatorId = Singleton<MathUtils>.Instance.NumberToLong(instigatorId.GetValueOrDefault());
		this.WaitRemoveBuffResponse[buffId] = this.WaitRemoveBuffResponse.GetValueOrDefault(buffId, 0) + 1;
		Singleton<CombatNet>.Instance.Call<OrderRemoveBuffResponse>(ERequestMessageId.OrderRemoveBuffRequest, base.Entity, orderRemoveBuffRequest, delegate(OrderRemoveBuffResponse response)
		{
			int num = this.WaitRemoveBuffResponse.GetValueOrDefault(buffId, 0) - 1;
			if (num <= 0)
			{
				this.WaitRemoveBuffResponse.Remove(buffId);
			}
			else
			{
				this.WaitRemoveBuffResponse[buffId] = num;
			}
			if (response != null && response.ErrorCode == ErrorCode.ErrSceneEntityNotExist)
			{
				ActiveBuffInternal buffById = this.GetBuffById(buffId);
				if (buffById != null)
				{
					this.RemoveBuffInner(buffById.Handle, stackCount, true, reason, null, new bool?(false), instigatorId);
				}
			}
		}, null, null, null, null);
	}

	// Token: 0x060187F6 RID: 100342 RVA: 0x006DCF9C File Offset: 0x006DB19C
	protected override void AddBuffOrder(long buffId, AddBuffParam param)
	{
		if (buffId <= 0L)
		{
			return;
		}
		this.PendingAddBuff[buffId] = Singleton<Time>.Instance.Now;
		OrderApplyBuffRequest orderApplyBuffRequest = OrderApplyBuffRequest.Create();
		orderApplyBuffRequest.Id = Singleton<MathUtils>.Instance.NumberToLong(buffId);
		orderApplyBuffRequest.Level = param.Level.GetValueOrDefault(1);
		orderApplyBuffRequest.StackCount = param.OuterStackCount.GetValueOrDefault();
		orderApplyBuffRequest.InstigatorId = Singleton<MathUtils>.Instance.NumberToLong(param.InstigatorId);
		orderApplyBuffRequest.ApplyType = param.ApplyType.GetValueOrDefault();
		if (param.Duration != null)
		{
			orderApplyBuffRequest.Duration = param.Duration.Value;
		}
		orderApplyBuffRequest.ServerId = param.ServerId.GetValueOrDefault();
		orderApplyBuffRequest.IsIterable = param.IsIterable.GetValueOrDefault(true);
		orderApplyBuffRequest.Reason = (param.Reason ?? "");
		if (param.BulletMessageId != null)
		{
			orderApplyBuffRequest.TransferContextId = new TransferContextId
			{
				BulletContextId = Singleton<MathUtils>.Instance.BigIntToLong(param.BulletMessageId.Value)
			};
		}
		Singleton<CombatNet>.Instance.Call<OrderApplyBuffResponse>(ERequestMessageId.OrderApplyBuffRequest, base.Entity, orderApplyBuffRequest, delegate(OrderApplyBuffResponse response)
		{
			this.PendingAddBuff.Remove(buffId);
			if (response != null && response.ErrorCode == ErrorCode.ErrSceneEntityNotExist)
			{
				this.AddBuffInner(buffId, ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, param.Reason), new long?(param.InstigatorId), param.Level.GetValueOrDefault(1), param.OuterStackCount, new ApplyGEType?(param.ApplyType.GetValueOrDefault()), param.PreMessageId, null, param.Duration, null, param.ServerId.GetValueOrDefault(), param.Reason, false, param.IsIterable.GetValueOrDefault(true), false, null, param.BulletMessageId, null);
			}
			if ((response == null || response.ErrorCode > ErrorCode.Success) && param.InstigatorId != 0L)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(param.InstigatorId);
				WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
				BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.GetBuffDefinition(buffId, param.Reason);
				if (worldEntity != null && buffDefinition != null)
				{
					SceneTeamController instance = ControllerBase<SceneTeamController>.Instance;
					Entity target = worldEntity;
					EAbilityEventName name = EAbilityEventName.AddBuffFailure;
					long buffId2 = buffId;
					long buffId3 = buffId;
					Entity entity2 = this.Entity;
					Entity arg = worldEntity;
					int arg2;
					if (param.OuterStackCount != null)
					{
						int? outerStackCount = param.OuterStackCount;
						int num = 0;
						if (outerStackCount.GetValueOrDefault() > num & outerStackCount != null)
						{
							arg2 = param.OuterStackCount.Value;
							goto IL_202;
						}
					}
					arg2 = buffDefinition.DefaultStackCount;
					IL_202:
					instance.EmitAbilityEvent<long, Entity, Entity, int, long?>(target, name, buffId2, buffId3, entity2, arg, arg2, param.BulletMessageId);
				}
			}
		}, param.PreMessageId, null, null, null);
	}

	// Token: 0x060187F7 RID: 100343 RVA: 0x006DD17C File Offset: 0x006DB37C
	protected override void RefreshBuffDurationOrder(long[] buffIds, [Nullable(2)] string reason)
	{
		RefreshBuffDurationPush refreshBuffDurationPush = RefreshBuffDurationPush.Create();
		refreshBuffDurationPush.BuffIds.AddRange(buffIds);
		Singleton<CombatNet>.Instance.Send(EPushMessageId.RefreshBuffDurationPush, base.Entity, refreshBuffDurationPush, null, null, null);
	}

	// Token: 0x060187F8 RID: 100344 RVA: 0x006DD1D0 File Offset: 0x006DB3D0
	public void UpdateSysGrowBuff(Dictionary<EAttributeType, float> growList)
	{
		if (this.SystemGrowBuffHandle >= 0)
		{
			base.RemoveBuffByHandleLocal(this.SystemGrowBuffHandle, -1, "更新系统成长值", null, null, null);
		}
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.CreateDynamicBuffRef();
		buffDefinition.StackingType = EBuffStackingType.None;
		buffDefinition.DurationPolicy = EBuffDurationType.Infinite;
		buffDefinition.Modifiers = Array.Empty<IBuffModifierData>();
		buffDefinition.Desc = "系统成长buff";
		List<IBuffModifierData> list = new List<IBuffModifierData>();
		foreach (KeyValuePair<EAttributeType, float> keyValuePair in growList)
		{
			EAttributeType key = keyValuePair.Key;
			float value = keyValuePair.Value;
			if (value != 0f)
			{
				list.Add(new BuffModifierData
				{
					AttributeId = key,
					Value1 = new float[]
					{
						value
					},
					Value2 = new float[1],
					CalculationPolicy = new int[1]
				});
			}
		}
		buffDefinition.Modifiers = list.ToArray();
		this.SystemGrowBuffHandle = this.AddBuffInner(-3L, buffDefinition, new long?(base.CreatureDataId), 1, null, new ApplyGEType?(ApplyGEType.Common), null, null, ActiveBuffConfigs.USE_INTERNAL_DURATION, null, -1, "更新系统成长值", false, true, false, null, null, null);
	}

	// Token: 0x060187F9 RID: 100345 RVA: 0x006DD364 File Offset: 0x006DB564
	public int AddAttributeRateModifierLocal(EAttributeType attributeId, float rate, string reason)
	{
		if (rate == 0f)
		{
			return -1;
		}
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.CreateDynamicBuffRef();
		buffDefinition.StackingType = EBuffStackingType.None;
		buffDefinition.DurationPolicy = EBuffDurationType.Infinite;
		buffDefinition.Modifiers = new IBuffModifierData[]
		{
			new BuffModifierData
			{
				AttributeId = attributeId,
				Value1 = new float[]
				{
					rate * 10000f
				},
				Value2 = new float[1],
				CalculationPolicy = new int[]
				{
					1
				}
			}
		};
		buffDefinition.Desc = reason;
		return this.AddBuffInner(-3L, buffDefinition, new long?(base.CreatureDataId), 1, null, new ApplyGEType?(ApplyGEType.Common), null, null, ActiveBuffConfigs.USE_INTERNAL_DURATION, null, -1, reason, false, true, false, null, null, null);
	}

	// Token: 0x060187FA RID: 100346 RVA: 0x006DD454 File Offset: 0x006DB654
	[NullableContext(2)]
	public int AddTagWithReturnHandle(IReadOnlyList<int> tags, float duration = -1f)
	{
		if (tags == null || tags.Count <= 0)
		{
			return -1;
		}
		BuffDefinition buffDefinition = ControllerBase<BuffController>.Instance.CreateDynamicBuffRef();
		buffDefinition.GrantedTags = tags.ToArray<int>();
		buffDefinition.StackingType = EBuffStackingType.None;
		buffDefinition.DurationPolicy = EBuffDurationType.Infinite;
		if (duration > 0f)
		{
			buffDefinition.DurationPolicy = EBuffDurationType.HasDuration;
			buffDefinition.DurationCalculationPolicy = new int[1];
			buffDefinition.DurationMagnitude = new float[]
			{
				duration
			};
		}
		buffDefinition.Desc = "AddTagWithReturnHandle";
		return this.AddBuffInner(-3L, buffDefinition, new long?(base.CreatureDataId), 1, null, new ApplyGEType?(ApplyGEType.Common), null, null, new float?(duration), null, -1, "添加tag", false, true, false, null, null, null);
	}

	// Token: 0x060187FB RID: 100347 RVA: 0x006DD534 File Offset: 0x006DB734
	public override void SetBuffEffectCd(long buffId, int index, float remainCd)
	{
		base.SetBuffEffectCd(buffId, index, remainCd);
		ActiveBuffInternal buffById = base.GetBuffById(buffId);
		int num = (buffById != null) ? buffById.Handle : -1;
		if (this.HasBuffAuthority() && num != -1 && (double)remainCd > 10000.0)
		{
			BuffEffectPush buffEffectPush = BuffEffectPush.Create();
			buffEffectPush.HandleId = num;
			buffEffectPush.Index = index;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.BuffEffectPush, base.Entity, buffEffectPush, null, null, null);
		}
	}

	// Token: 0x060187FC RID: 100348 RVA: 0x006DD5C0 File Offset: 0x006DB7C0
	public string GetDebugBuffString(string filterStr = "")
	{
		string text = "";
		List<string> list = new List<string>();
		foreach (object obj in Regex.Matches(filterStr, "[0-9]+"))
		{
			Match match = (Match)obj;
			list.Add(match.Value ?? "");
		}
		foreach (ActiveBuffInternal activeBuffInternal in this.BuffContainer.Values)
		{
			string text2 = activeBuffInternal.Id.ToString();
			if (list.Count > 0)
			{
				bool flag = false;
				foreach (string value in list)
				{
					if (text2.StartsWith(value))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(57, 9);
			defaultInterpolatedStringHandler.AppendFormatted((activeBuffInternal.Id == -3L) ? "系统buff" : ((this.HasBuffAuthority() ? "RemoteBuff_" : "Buff_") + text2));
			defaultInterpolatedStringHandler.AppendLiteral("(");
			defaultInterpolatedStringHandler.AppendFormatted(this.BuffGarbageSet.Contains(activeBuffInternal.Handle) ? "销毁" : (activeBuffInternal.IsActive() ? "激活" : "失效"));
			defaultInterpolatedStringHandler.AppendLiteral(")  handle: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(activeBuffInternal.Handle);
			defaultInterpolatedStringHandler.AppendLiteral(",  层数: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(activeBuffInternal.StackCount);
			defaultInterpolatedStringHandler.AppendLiteral(",  等级: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(activeBuffInternal.Level);
			defaultInterpolatedStringHandler.AppendLiteral(" \n    施加者: ");
			CharacterActorComponent instigatorActorComponent = activeBuffInternal.GetInstigatorActorComponent();
			defaultInterpolatedStringHandler.AppendFormatted((instigatorActorComponent != null) ? instigatorActorComponent.Actor.GetName() : null);
			defaultInterpolatedStringHandler.AppendLiteral(",  时长: ");
			string value2;
			if (activeBuffInternal.Duration >= 0f)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler2.AppendFormatted<float>(activeBuffInternal.GetRemainDuration(), "F1");
				defaultInterpolatedStringHandler2.AppendLiteral("/");
				defaultInterpolatedStringHandler2.AppendFormatted<float>(activeBuffInternal.Duration, "F1");
				value2 = defaultInterpolatedStringHandler2.ToStringAndClear();
			}
			else
			{
				value2 = "无限";
			}
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral(",  ");
			string value3;
			if (activeBuffInternal.Period <= 0f)
			{
				value3 = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(5, 2);
				defaultInterpolatedStringHandler2.AppendLiteral("周期: ");
				float? num;
				defaultInterpolatedStringHandler2.AppendFormatted((activeBuffInternal.GetRemainPeriod() != null) ? num.GetValueOrDefault().ToString("F1") : null);
				defaultInterpolatedStringHandler2.AppendLiteral("/");
				defaultInterpolatedStringHandler2.AppendFormatted<float>(activeBuffInternal.Period, "F1");
				value3 = defaultInterpolatedStringHandler2.ToStringAndClear();
			}
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			defaultInterpolatedStringHandler.AppendLiteral("\n    说明: ");
			BuffDefinition config = activeBuffInternal.Config;
			defaultInterpolatedStringHandler.AppendFormatted((config != null) ? config.Desc : null);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			string text3 = defaultInterpolatedStringHandler.ToStringAndClear();
			if (activeBuffInternal.Config.GrantedTags != null)
			{
				foreach (int tagId in activeBuffInternal.Config.GrantedTags)
				{
					text3 = text3 + "    +附加标签 " + GameplayTagUtils.GetNameByTagId(tagId) + "\n";
				}
			}
			foreach (BuffEffect buffEffect in base.BuffEffectManager.GetEffectsByHandle(activeBuffInternal.Handle))
			{
				string str = text3;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 3);
				defaultInterpolatedStringHandler.AppendLiteral("    +持续效果 ");
				defaultInterpolatedStringHandler.AppendFormatted(buffEffect.GetDebugString());
				defaultInterpolatedStringHandler.AppendLiteral("(cd:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(base.GetBuffEffectCd(activeBuffInternal.Id, buffEffect.Index) / 1000.0, "F1");
				defaultInterpolatedStringHandler.AppendLiteral("s");
				defaultInterpolatedStringHandler.AppendFormatted(base.GetTargetCdDebugStr(activeBuffInternal.Id, buffEffect.Index));
				defaultInterpolatedStringHandler.AppendLiteral(")\n");
				text3 = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			foreach (ExtraEffectParameters extraEffectParameters in activeBuffInternal.Config.EffectInfos)
			{
				BuffExecution executionEffect = extraEffectParameters.ExecutionEffect;
				if (executionEffect != null)
				{
					text3 = text3 + "    +周期效果 " + executionEffect.GetDebugString() + "\n";
				}
			}
			text = text + text3 + "\n";
		}
		return text;
	}

	// Token: 0x060187FD RID: 100349 RVA: 0x006DDB10 File Offset: 0x006DBD10
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterBuffComponent characterBuffComponent = (CharacterBuffComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (characterBuffComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeComponent"))
		{
			if (characterBuffComponent.AttributeComponent == null)
			{
				this.AttributeComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComponent), "AttributeComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (characterBuffComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TimeScaleComponent"))
		{
			if (characterBuffComponent.TimeScaleComponent == null)
			{
				this.TimeScaleComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.TimeScaleComponent), "TimeScaleComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CueComponent"))
		{
			if (characterBuffComponent.CueComponent == null)
			{
				this.CueComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterGameplayCueComponent>(this.CueComponent), "CueComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PauseLocks"))
		{
			if (characterBuffComponent.PauseLocks == null)
			{
				this.PauseLocks = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<string>(this.PauseLocks), "PauseLocks"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PauseRateLocks") && characterBuffComponent.PauseRateLocks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, float>>(this.PauseRateLocks), "PauseRateLocks"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CueInited"))
		{
			this.CueInited = characterBuffComponent.CueInited;
		}
		if (base.CanResetComponentProperty("SystemGrowBuffHandle"))
		{
			this.SystemGrowBuffHandle = characterBuffComponent.SystemGrowBuffHandle;
		}
		return true;
	}

	// Token: 0x0400BCD5 RID: 48341
	private const double NO_BROADCAST_CD_THRESHOLD = 10000.0;

	// Token: 0x0400BCD6 RID: 48342
	[Nullable(2)]
	public BaseActorComponent ActorComponent;

	// Token: 0x0400BCD7 RID: 48343
	[Nullable(2)]
	public BaseAttributeComponent AttributeComponent;

	// Token: 0x0400BCD8 RID: 48344
	[Nullable(2)]
	public BaseTagComponent TagComponent;

	// Token: 0x0400BCD9 RID: 48345
	[Nullable(2)]
	public PawnTimeScaleComponent TimeScaleComponent;

	// Token: 0x0400BCDA RID: 48346
	[Nullable(2)]
	protected CharacterGameplayCueComponent CueComponent;

	// Token: 0x0400BCDB RID: 48347
	protected HashSet<string> PauseLocks = new HashSet<string>();

	// Token: 0x0400BCDC RID: 48348
	protected readonly Dictionary<string, float> PauseRateLocks = new Dictionary<string, float>();

	// Token: 0x0400BCDD RID: 48349
	[StaticVariableRuleIgnore]
	private static readonly Stat AddBuffBornStat = Stat.Create("AddBuff_Born", "", "");

	// Token: 0x0400BCDE RID: 48350
	private bool CueInited;

	// Token: 0x0400BCDF RID: 48351
	[StaticVariableRuleIgnore]
	private static readonly Stat OnCharacterBuffAddedStat = Stat.Create("CharacterBuffComponent.OnBuffAdded", "", "");

	// Token: 0x0400BCE0 RID: 48352
	[StaticVariableRuleIgnore]
	private static readonly Stat OnCharacterBuffRemovedStat = Stat.Create("CharacterBuffComponent.OnBuffRemoved", "", "");

	// Token: 0x0400BCE1 RID: 48353
	[StaticVariableRuleIgnore]
	private static readonly Stat OnCharacterBuffStackIncreasedStat = Stat.Create("CharacterBuffComponent.OnBuffStackIncreased", "", "");

	// Token: 0x0400BCE2 RID: 48354
	[StaticVariableRuleIgnore]
	private static readonly Stat OnCharacterBuffStackDecreasedStat = Stat.Create("CharacterBuffComponent.OnBuffStackDecreased", "", "");

	// Token: 0x0400BCE3 RID: 48355
	[StaticVariableRuleIgnore]
	private static readonly Stat OnCharacterBuffActiveChangedStat = Stat.Create("CharacterBuffComponent.OnBuffActiveChanged", "", "");

	// Token: 0x0400BCE4 RID: 48356
	[StaticVariableRuleIgnore]
	private static readonly Stat BroadcastActivateBuffStat = Stat.Create("CharacterBuffComponent.BroadcastActivateBuff", "", "");

	// Token: 0x0400BCE5 RID: 48357
	private int SystemGrowBuffHandle = -1;

	// Token: 0x0400BCE6 RID: 48358
	[StaticVariableRuleIgnore]
	private static readonly Stat AddBuffSysGrowStat = Stat.Create("AddBuff_SysGrow", "", "");

	// Token: 0x0400BCE7 RID: 48359
	[StaticVariableRuleIgnore]
	private static readonly Stat AttributeRateModifierStat = Stat.Create("AddBuff_AttributeRateModifier", "", "");

	// Token: 0x0400BCE8 RID: 48360
	[StaticVariableRuleIgnore]
	private static readonly Stat AddTagStat = Stat.Create("AddBuff_AddTag", "", "");
}
