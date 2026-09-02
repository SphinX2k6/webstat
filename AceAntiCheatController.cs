using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02003467 RID: 13415
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class AceAntiCheatController : ControllerBase<AceAntiCheatController>
{
	// Token: 0x0601C377 RID: 115575 RVA: 0x0086914B File Offset: 0x0086734B
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.Register<BattleAntiCheatingLogNotify>(ENotifyMessageId.BattleAntiCheatingLogNotify, new Action<BattleAntiCheatingLogNotify, Net.CallbackStatus>(this.BattleAntiCheatingLogNotify));
		return true;
	}

	// Token: 0x0601C378 RID: 115576 RVA: 0x0086916A File Offset: 0x0086736A
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BattleAntiCheatingLogNotify);
		return true;
	}

	// Token: 0x0601C379 RID: 115577 RVA: 0x00869180 File Offset: 0x00867380
	protected override void OnTick(float delta)
	{
		if (this.NeedColletSpeed)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			double? num;
			if (baseCharacter == null)
			{
				num = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				num = ((characterActorComponent != null) ? new double?(characterActorComponent.ActorVelocityProxy.Size()) : null);
			}
			double? num2 = num;
			int num3 = (int)num2.GetValueOrDefault();
			if (num3 > 0)
			{
				this.AvgSpeed = (this.CurSpeedCount * this.AvgSpeed + num3) / (this.CurSpeedCount + 1);
				this.CurSpeedCount++;
				if (num3 < this.MinSpeed)
				{
					this.MinSpeed = num3;
				}
				if (num3 > this.MaxSpeed)
				{
					this.MaxSpeed = num3;
				}
			}
		}
		if (this.NeedColletPos && this.FightRoleInfoMap != null)
		{
			this.PosTickTime += delta;
			if (this.PosTickTime > 1000f)
			{
				this.PosTickTime -= 1000f;
				foreach (long num4 in this.FightRoleInfoMap.Keys)
				{
					EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num4);
					global::Vector vector;
					if (entity == null)
					{
						vector = null;
					}
					else
					{
						WorldEntity entity2 = entity.Entity;
						if (entity2 == null)
						{
							vector = null;
						}
						else
						{
							BaseActorComponent component = entity2.GetComponent<BaseActorComponent>();
							vector = ((component != null) ? component.ActorLocationProxy : null);
						}
					}
					global::Vector vector2 = vector;
					if (vector2 != null)
					{
						RepeatedField<Aki.Protocol.Vector> posList = this.FightRoleInfoMap[num4].PosList;
						posList.Add(vector2.ToProtocolVector());
						if (posList.Count > 120)
						{
							this.NeedColletPos = false;
						}
					}
				}
			}
		}
	}

	// Token: 0x0601C37A RID: 115578 RVA: 0x00869318 File Offset: 0x00867518
	private void BattleAntiCheatingLogNotify(BattleAntiCheatingLogNotify data, [Nullable(2)] Net.CallbackStatus _)
	{
		long logId = data.LogId;
		switch (data.LogType)
		{
		case 0:
			break;
		case 1:
			this.StartSecFbRound(logId);
			return;
		case 2:
			this.EndSecFbRound(logId);
			return;
		case 3:
			this.StartSecRoleFightFlowBigWorld(logId);
			return;
		case 4:
			this.EndSecRoleFightFlowBigWorld(logId);
			return;
		case 5:
			this.StartSecRoleFightFlowInst(logId);
			return;
		case 6:
			this.EndSecRoleFightFlowInst(logId);
			return;
		case 7:
			this.StartSecWorldInfoFlow(logId, data.TimoutSpan);
			return;
		case 8:
			this.EndSecWorldInfoFlow(logId);
			return;
		case 9:
			this.StartSecWorldFlow(logId);
			return;
		case 10:
			this.EndSecWorldFlow(logId);
			return;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "UnknownAntiCheatingLogType";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", data.LogType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			break;
		}
		}
	}

	// Token: 0x0601C37B RID: 115579 RVA: 0x008693F0 File Offset: 0x008675F0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<SceneTeamRole> GetRoleList()
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int? num = id;
		int num2 = 0;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Net, ELogAuthor.ZFJ, "StartSecFbRound playerId Error", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		if (instance == null)
		{
			return null;
		}
		SceneTeamPlayer teamPlayerData = instance.GetTeamPlayerData(id.GetValueOrDefault());
		if (teamPlayerData == null)
		{
			return null;
		}
		SceneTeamGroup group = teamPlayerData.GetGroup(ETeamGroupType.Battle);
		if (group == null)
		{
			return null;
		}
		return group.GetRoleList();
	}

	// Token: 0x0601C37C RID: 115580 RVA: 0x0086946C File Offset: 0x0086766C
	private void StartSecFbRound(long logId)
	{
		if (this.SecFbRoundLogId > 0L)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "StartSecFbRound repeat";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("logId", logId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SecFbRoundLogId = logId;
		this.SecFbRoundStartTime = Singleton<Time>.Instance.WorldTime;
		SecFBRoundStartFlowRequest secFBRoundStartFlowRequest = SecFBRoundStartFlowRequest.Create();
		secFBRoundStartFlowRequest.LogId = logId;
		secFBRoundStartFlowRequest.ClientStartTime = Singleton<TimeUtil>.Instance.DateFormat2(DateTime.Now);
		List<SceneTeamRole> roleList = this.GetRoleList();
		if (roleList == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Net;
			ELogAuthor author2 = ELogAuthor.ZFJ;
			string message2 = "StartSecFbRound roleList Error";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("logId", logId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		secFBRoundStartFlowRequest.SrvFighter1Info = ((roleList.Count > 0) ? this.GetSrvFighterInfo(roleList[0]) : null);
		secFBRoundStartFlowRequest.SrvFighter2Info = ((roleList.Count > 1) ? this.GetSrvFighterInfo(roleList[1]) : null);
		secFBRoundStartFlowRequest.SrvFighter3Info = ((roleList.Count > 2) ? this.GetSrvFighterInfo(roleList[2]) : null);
		secFBRoundStartFlowRequest.SrvFighter4Info = ((roleList.Count > 3) ? this.GetSrvFighterInfo(roleList[3]) : null);
		this.SetCollectSpeed(true);
		Singleton<Net>.Instance.Call<SecFBRoundStartFlowResponse>(ERequestMessageId.SecFBRoundStartFlowRequest, secFBRoundStartFlowRequest, null, 0);
	}

	// Token: 0x0601C37D RID: 115581 RVA: 0x008695B8 File Offset: 0x008677B8
	private SrvFighterInfo GetSrvFighterInfo(SceneTeamRole sceneTeamRole)
	{
		SrvFighterInfo srvFighterInfo = SrvFighterInfo.Create();
		RoleModel instance = ModelBase<RoleModel>.Instance;
		RoleInstance roleInstance = (instance != null) ? instance.GetRoleInstanceById(sceneTeamRole.RoleId) : null;
		RoleLevelData roleLevelData = (roleInstance != null) ? roleInstance.GetLevelData() : null;
		srvFighterInfo.Breakthrough = ((roleLevelData != null) ? roleLevelData.GetBreachLevel() : 0);
		srvFighterInfo.Level = ((roleLevelData != null) ? roleLevelData.GetLevel() : 0);
		srvFighterInfo.Exp = ((roleLevelData != null) ? roleLevelData.GetExp() : 0);
		srvFighterInfo.RoleId = sceneTeamRole.RoleId;
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(sceneTeamRole.CreatureDataId);
		BaseAttributeComponent baseAttributeComponent;
		if (entity == null)
		{
			baseAttributeComponent = null;
		}
		else
		{
			WorldEntity entity2 = entity.Entity;
			baseAttributeComponent = ((entity2 != null) ? entity2.GetComponent<BaseAttributeComponent>() : null);
		}
		BaseAttributeComponent baseAttributeComponent2 = baseAttributeComponent;
		if (baseAttributeComponent2 != null)
		{
			List<PropConfig> list = new List<PropConfig>();
			for (int i = 1; i < 143; i++)
			{
				PropConfig propConfig = PropConfig.Create();
				propConfig.Id = i;
				propConfig.Value = baseAttributeComponent2.GetCurrentValue((EAttributeType)i);
				list.Add(propConfig);
			}
			srvFighterInfo.PropDataList.AddRange(list);
		}
		RoleSkillData roleSkillData = (roleInstance != null) ? roleInstance.GetSkillData() : null;
		Aki.Config.Skill[] array = (roleSkillData != null) ? roleSkillData.GetSkillList() : null;
		if (roleSkillData != null && array != null)
		{
			List<SrvFighterSkillInfo> list2 = new List<SrvFighterSkillInfo>();
			foreach (Aki.Config.Skill skill in array)
			{
				SrvFighterSkillInfo srvFighterSkillInfo = SrvFighterSkillInfo.Create();
				srvFighterSkillInfo.SkillId = skill.Id;
				srvFighterSkillInfo.Level = roleSkillData.GetSkillLevel(skill.Id);
				list2.Add(srvFighterSkillInfo);
			}
			srvFighterInfo.SrvFighterSkillInfo.AddRange(list2);
		}
		return srvFighterInfo;
	}

	// Token: 0x0601C37E RID: 115582 RVA: 0x0086973E File Offset: 0x0086793E
	private void SetCollectSpeed(bool isStart)
	{
		this.NeedColletSpeed = isStart;
		this.CurSpeedCount = 0;
		this.AvgSpeed = 0;
		this.MaxSpeed = 0;
		this.MinSpeed = 999999;
	}

	// Token: 0x0601C37F RID: 115583 RVA: 0x00869768 File Offset: 0x00867968
	private unsafe void EndSecFbRound(long logId)
	{
		if (this.SecFbRoundLogId != logId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "EndSecFbRound logId Error";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("logId", logId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SecFbRoundLogId", this.SecFbRoundLogId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		SecFBRoundEndFlowReportRequest secFBRoundEndFlowReportRequest = SecFBRoundEndFlowReportRequest.Create();
		secFBRoundEndFlowReportRequest.LogId = logId;
		secFBRoundEndFlowReportRequest.ClientEndTime = Singleton<TimeUtil>.Instance.DateFormat2(DateTime.Now);
		secFBRoundEndFlowReportRequest.RoundTimeUse = (long)(Singleton<Time>.Instance.WorldTime - this.SecFbRoundStartTime);
		secFBRoundEndFlowReportRequest.SpeedMax = this.MaxSpeed;
		secFBRoundEndFlowReportRequest.SpeedMin = ((this.MinSpeed == 999999) ? 0 : this.MinSpeed);
		secFBRoundEndFlowReportRequest.SpeedAvg = this.AvgSpeed;
		this.SetCollectSpeed(false);
		Singleton<Net>.Instance.Call<SecFBRoundEndFlowReportResponse>(ERequestMessageId.SecFBRoundEndFlowReportRequest, secFBRoundEndFlowReportRequest, null, 0);
		this.SecFbRoundLogId = -1L;
	}

	// Token: 0x0601C380 RID: 115584 RVA: 0x00869870 File Offset: 0x00867A70
	private void StartSecRoleFightFlowBigWorld(long logId)
	{
		if (this.SecRoleFightFlowBigWorldLogId > 0L)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "StartSecRoleFightFlowBigWorld repeat";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("logId", logId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.StartColletRoleFightFlow();
		this.SecRoleFightFlowBigWorldLogId = logId;
	}

	// Token: 0x0601C381 RID: 115585 RVA: 0x008698C4 File Offset: 0x00867AC4
	private unsafe void EndSecRoleFightFlowBigWorld(long logId)
	{
		if (this.SecRoleFightFlowBigWorldLogId != logId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "EndSecRoleFightFlowBigWorld logId Error";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("logId", logId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SecRoleFightFlowBigWorldLogId", this.SecRoleFightFlowBigWorldLogId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.SendRoleFightFlowRequest(logId, AceBattleAntiCheatingLogType.LogTypeSecRoleFightFlowBigWorldEnd);
		this.SecRoleFightFlowBigWorldLogId = -1L;
	}

	// Token: 0x0601C382 RID: 115586 RVA: 0x00869950 File Offset: 0x00867B50
	private void OnAnyCurrentValueChange(EAttributeType attrId, float oldValue, float newValue)
	{
		if (this.FightRoleInfoMap == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Net, ELogAuthor.ZFJ, "SetNewAttrMaxValue FightRoleInfoMap nil", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (long num in this.FightRoleInfoMap.Keys)
		{
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num);
			object obj;
			if (entity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				obj = ((entity2 != null) ? entity2.GetComponent<BaseAttributeComponent>() : null);
			}
			object obj2 = obj;
			float num2 = (obj2 != null) ? obj2.GetCurrentValue(attrId) : 0f;
			SrvFighterInfo fighterInfoMax = this.FightRoleInfoMap[num].FighterInfoMax;
			PropConfig propConfig = (fighterInfoMax != null) ? fighterInfoMax.PropDataList[attrId - EAttributeType.Lv] : null;
			if (propConfig != null && propConfig.Id == (int)attrId && propConfig.Value < num2)
			{
				propConfig.Value = num2;
			}
		}
	}

	// Token: 0x0601C383 RID: 115587 RVA: 0x00869A48 File Offset: 0x00867C48
	private void OnDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition)
	{
		if (this.FightRoleInfoMap == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Net, ELogAuthor.ZFJ, "OnDamage FightRoleInfoMap nil", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		float damage = damageResult.Damage;
		if (damage == 0f)
		{
			return;
		}
		int num = (int)(-(int)damage);
		foreach (long num2 in this.FightRoleInfoMap.Keys)
		{
			CreatureDataComponent component = attacker.GetComponent<CreatureDataComponent>();
			long? num3 = (component != null) ? new long?(component.GetCreatureDataId()) : null;
			long num4 = num2;
			if (num3.GetValueOrDefault() == num4 & num3 != null)
			{
				SecRoleFightFlowData secRoleFightFlowData = this.FightRoleInfoMap[num2];
				secRoleFightFlowData.RoundFighterDpsTotal = (long)num + secRoleFightFlowData.RoundFighterDpsTotal;
				secRoleFightFlowData.RoundFighterDpsCount++;
				secRoleFightFlowData.RoundFighterAtkMissTotal += ((requirements.IsImmune.GetValueOrDefault() > false) ? 1 : 0);
				if (requirements.IsCritical.GetValueOrDefault())
				{
					secRoleFightFlowData.RoundFighterPlayerCritCount++;
					if (num > secRoleFightFlowData.RoundFighterDamage2Max)
					{
						secRoleFightFlowData.RoundFighterDamage2Max = num;
					}
					if (num < secRoleFightFlowData.RoundFighterDamage2Min)
					{
						secRoleFightFlowData.RoundFighterDamage2Min = num;
					}
				}
				else
				{
					if (num > secRoleFightFlowData.RoundFighterDamage1Max)
					{
						secRoleFightFlowData.RoundFighterDamage1Max = num;
					}
					if (num < secRoleFightFlowData.RoundFighterDamage1Min)
					{
						secRoleFightFlowData.RoundFighterDamage1Min = num;
					}
				}
			}
		}
	}

	// Token: 0x0601C384 RID: 115588 RVA: 0x00869BD8 File Offset: 0x00867DD8
	private void OnCharInputPress(EInputAction action, float time)
	{
		if (this.CurGlobalRoleCreatureId == null || this.FightRoleInfoMap == null)
		{
			return;
		}
		SecRoleFightFlowData secRoleFightFlowData;
		if (!this.FightRoleInfoMap.TryGetValue(this.CurGlobalRoleCreatureId.Value, out secRoleFightFlowData))
		{
			return;
		}
		switch (action)
		{
		case 1:
			secRoleFightFlowData.RoundFighterButtonClickCountJump++;
			return;
		case 2:
		case 3:
		case 7:
			break;
		case 4:
			secRoleFightFlowData.RoundFighterButtonClickCountATK++;
			return;
		case 5:
			secRoleFightFlowData.RoundFighterButtonClickCountDodge++;
			return;
		case 6:
			secRoleFightFlowData.RoundFighterButtonClickCount3++;
			break;
		case 8:
			secRoleFightFlowData.RoundFighterButtonClickCount1++;
			return;
		case 9:
			secRoleFightFlowData.RoundFighterButtonClickCount2++;
			return;
		default:
			return;
		}
	}

	// Token: 0x0601C385 RID: 115589 RVA: 0x00869CA4 File Offset: 0x00867EA4
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		if (oldEntityHandle == null || this.FightRoleInfoMap == null)
		{
			return;
		}
		WorldEntity entity = oldEntityHandle.Entity;
		long? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
		}
		long? num2 = num;
		SecRoleFightFlowData secRoleFightFlowData;
		if (num2 != null && this.FightRoleInfoMap.TryGetValue(num2.Value, out secRoleFightFlowData))
		{
			long residentTimeTotal = secRoleFightFlowData.ResidentTimeTotal;
			secRoleFightFlowData.ResidentTimeTotal = (long)(Singleton<Time>.Instance.WorldTime - this.ChangeRoleTimeStamp + (double)residentTimeTotal);
		}
		this.ChangeRoleTimeStamp = Singleton<Time>.Instance.WorldTime;
		WorldEntity entity2 = newEntityHandle.Entity;
		long? curGlobalRoleCreatureId;
		if (entity2 == null)
		{
			curGlobalRoleCreatureId = null;
		}
		else
		{
			CreatureDataComponent component2 = entity2.GetComponent<CreatureDataComponent>();
			curGlobalRoleCreatureId = ((component2 != null) ? new long?(component2.GetCreatureDataId()) : null);
		}
		this.CurGlobalRoleCreatureId = curGlobalRoleCreatureId;
	}

	// Token: 0x0601C386 RID: 115590 RVA: 0x00869D7C File Offset: 0x00867F7C
	private void StartColletRoleFightFlow()
	{
		List<SceneTeamRole> roleList = this.GetRoleList();
		if (roleList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Net, ELogAuthor.ZFJ, "StartColletRoleFightFlow roleList Error", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.FightRoleList = roleList;
		foreach (SceneTeamRole sceneTeamRole in roleList)
		{
			if (this.FightRoleInfoMap == null)
			{
				this.FightRoleInfoMap = new Dictionary<long, SecRoleFightFlowData>();
			}
			if (!this.FightRoleInfoMap.ContainsKey(sceneTeamRole.CreatureDataId))
			{
				SecRoleFightFlowData secRoleFightFlowData = SecRoleFightFlowData.Create();
				secRoleFightFlowData.SrvFighterID = sceneTeamRole.RoleId;
				this.FightRoleInfoMap[sceneTeamRole.CreatureDataId] = secRoleFightFlowData;
			}
			SrvFighterInfo srvFighterInfo = this.GetSrvFighterInfo(sceneTeamRole);
			this.FightRoleInfoMap[sceneTeamRole.CreatureDataId].FighterInfoMax = srvFighterInfo;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(sceneTeamRole.CreatureDataId);
			WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
			if (worldEntity == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Net, ELogAuthor.ZFJ, "StartColletRoleFightFlow roleEntity Error", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				BaseAttributeComponent component = worldEntity.GetComponent<BaseAttributeComponent>();
				if (component != null)
				{
					component.AddGeneralListener(new Action<EAttributeType, float, float>(this.OnAnyCurrentValueChange));
				}
				if (!Singleton<EventSystem>.Instance.HasWithTarget(worldEntity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnDamage)))
				{
					Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(worldEntity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnDamage));
				}
				this.NeedColletPos = true;
				this.AddAceAntiCheatInputLayer(worldEntity.Id);
			}
		}
		this.ChangeRoleTimeStamp = Singleton<Time>.Instance.WorldTime;
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		EntityHandle handle = instance.GetHandle((baseCharacter != null) ? baseCharacter.EntityId : 0);
		long? curGlobalRoleCreatureId;
		if (handle == null)
		{
			curGlobalRoleCreatureId = null;
		}
		else
		{
			WorldEntity entity2 = handle.Entity;
			if (entity2 == null)
			{
				curGlobalRoleCreatureId = null;
			}
			else
			{
				CreatureDataComponent component2 = entity2.GetComponent<CreatureDataComponent>();
				curGlobalRoleCreatureId = ((component2 != null) ? new long?(component2.GetCreatureDataId()) : null);
			}
		}
		this.CurGlobalRoleCreatureId = curGlobalRoleCreatureId;
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
	}

	// Token: 0x0601C387 RID: 115591 RVA: 0x00869FB4 File Offset: 0x008681B4
	private void SendRoleFightFlowRequest(long logId, AceBattleAntiCheatingLogType logType)
	{
		if (this.FightRoleList == null || this.FightRoleInfoMap == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Net, ELogAuthor.ZFJ, "SendRoleFightFlowRequest List Error", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		SecRoleFightFlowRequest secRoleFightFlowRequest = SecRoleFightFlowRequest.Create();
		secRoleFightFlowRequest.LogId = logId;
		secRoleFightFlowRequest.ClientTime = Singleton<TimeUtil>.Instance.DateFormat2(DateTime.Now);
		List<SecRoleFightFlowData> list = new List<SecRoleFightFlowData>();
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		EntityHandle handle = instance.GetHandle((baseCharacter != null) ? baseCharacter.EntityId : 0);
		long? num;
		if (handle == null)
		{
			num = null;
		}
		else
		{
			WorldEntity entity = handle.Entity;
			if (entity == null)
			{
				num = null;
			}
			else
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				num = ((component != null) ? new long?(component.GetCreatureDataId()) : null);
			}
		}
		long? num2 = num;
		SecRoleFightFlowData secRoleFightFlowData;
		if (num2 != null && this.FightRoleInfoMap.TryGetValue(num2.Value, out secRoleFightFlowData))
		{
			long residentTimeTotal = secRoleFightFlowData.ResidentTimeTotal;
			secRoleFightFlowData.ResidentTimeTotal = (long)(Singleton<Time>.Instance.WorldTime - this.ChangeRoleTimeStamp + (double)residentTimeTotal);
		}
		foreach (SecRoleFightFlowData item in this.FightRoleInfoMap.Values)
		{
			list.Add(item);
		}
		secRoleFightFlowRequest.SecRoleFightFlowDataList.AddRange(list);
		secRoleFightFlowRequest.LogType = logType;
		Singleton<Net>.Instance.Call<SecRoleFightFlowResponse>(ERequestMessageId.SecRoleFightFlowRequest, secRoleFightFlowRequest, null, 0);
		foreach (SceneTeamRole sceneTeamRole in this.FightRoleList)
		{
			EntityHandle entity2 = ModelBase<CreatureModel>.Instance.GetEntity(sceneTeamRole.CreatureDataId);
			WorldEntity worldEntity = (entity2 != null) ? entity2.Entity : null;
			if (worldEntity == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Net, ELogAuthor.ZFJ, "StartColletRoleFightFlow roleEntity Error", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				BaseAttributeComponent component2 = worldEntity.GetComponent<BaseAttributeComponent>();
				if (component2 != null)
				{
					component2.RemoveGeneralListener(new Action<EAttributeType, float, float>(this.OnAnyCurrentValueChange));
				}
				Singleton<EventSystem>.Instance.RemoveWithTarget(worldEntity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnDamage));
				this.NeedColletPos = false;
			}
		}
		Singleton<EventSystem>.Instance.Remove<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		this.RemoveAceAntiCheatInputLayer();
		this.FightRoleInfoMap = null;
		this.FightRoleList = null;
	}

	// Token: 0x0601C388 RID: 115592 RVA: 0x0086A224 File Offset: 0x00868424
	private void StartSecRoleFightFlowInst(long logId)
	{
		if (this.SecRoleFightFlowInstLogId > 0L)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "StartSecRoleFightFlowInst repeat";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("logId", logId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.StartColletRoleFightFlow();
		this.SecRoleFightFlowInstLogId = logId;
	}

	// Token: 0x0601C389 RID: 115593 RVA: 0x0086A278 File Offset: 0x00868478
	private unsafe void EndSecRoleFightFlowInst(long logId)
	{
		if (this.SecRoleFightFlowInstLogId != logId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "EndSecRoleFightFlowInst logId Error";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("logId", logId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SecRoleFightFlowInstLogId", this.SecRoleFightFlowInstLogId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.SendRoleFightFlowRequest(logId, AceBattleAntiCheatingLogType.LogTypeSecRoleFightFlowInstEnd);
		this.SecRoleFightFlowInstLogId = -1L;
	}

	// Token: 0x0601C38A RID: 115594 RVA: 0x0086A304 File Offset: 0x00868504
	private void StartSecWorldInfoFlow(long logId, int endTime)
	{
		if (this.SecWorldInfoFlowLogId > 0L)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "StartSecFbRound repeat";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("logId", logId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SecWorldInfoFlowLogId = logId;
		this.SetCollectSpeed(true);
		this.EndSecWorldInfoFlowTimerId = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.EndSecWorldInfoFlowTimerId = null;
			this.EndSecWorldInfoFlow(this.SecWorldInfoFlowLogId);
		}, (float)endTime, null, null, true, 1f);
	}

	// Token: 0x0601C38B RID: 115595 RVA: 0x0086A37C File Offset: 0x0086857C
	private unsafe void EndSecWorldInfoFlow(long logId)
	{
		if (this.SecWorldInfoFlowLogId != logId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "EndSecWorldInfoFlow logId Error";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("logId", logId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SecWorldInfoFlowLogId", this.SecWorldInfoFlowLogId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (this.EndSecWorldInfoFlowTimerId != null)
		{
			TimerSystem.Instance.Remove(this.EndSecWorldInfoFlowTimerId);
			this.EndSecWorldInfoFlowTimerId = null;
		}
		SecWorldInfoFlowRequest secWorldInfoFlowRequest = SecWorldInfoFlowRequest.Create();
		secWorldInfoFlowRequest.LogId = logId;
		secWorldInfoFlowRequest.ClientTime = Singleton<TimeUtil>.Instance.DateFormat2(DateTime.Now);
		secWorldInfoFlowRequest.SpeedMax = this.MaxSpeed;
		secWorldInfoFlowRequest.SpeedMin = ((this.MinSpeed == 999999) ? 0 : this.MinSpeed);
		secWorldInfoFlowRequest.SpeedAvg = this.AvgSpeed;
		this.SetCollectSpeed(false);
		Singleton<Net>.Instance.Call<SecWorldInfoFlowResponse>(ERequestMessageId.SecWorldInfoFlowRequest, secWorldInfoFlowRequest, null, 0);
		this.SecWorldInfoFlowLogId = -1L;
	}

	// Token: 0x0601C38C RID: 115596 RVA: 0x0086A48C File Offset: 0x0086868C
	private void StartSecWorldFlow(long logId)
	{
		if (this.SecWorldFlowLogId > 0L)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "StartSecFbRound repeat";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("logId", logId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SecWorldFlowLogId = logId;
		this.SecFbRoundStartTime = Singleton<Time>.Instance.WorldTime;
		SecWorldStartFlowRequest secWorldStartFlowRequest = SecWorldStartFlowRequest.Create();
		secWorldStartFlowRequest.LogId = logId;
		secWorldStartFlowRequest.ClientStartTime = Singleton<TimeUtil>.Instance.DateFormat2(DateTime.Now);
		List<SceneTeamRole> roleList = this.GetRoleList();
		if (roleList == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Net;
			ELogAuthor author2 = ELogAuthor.ZFJ;
			string message2 = "StartSecWorldFlow roleList Error";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("logId", logId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		secWorldStartFlowRequest.SrvFighter1Info = ((roleList.Count > 0) ? this.GetSrvFighterInfo(roleList[0]) : null);
		secWorldStartFlowRequest.SrvFighter2Info = ((roleList.Count > 1) ? this.GetSrvFighterInfo(roleList[1]) : null);
		secWorldStartFlowRequest.SrvFighter3Info = ((roleList.Count > 2) ? this.GetSrvFighterInfo(roleList[2]) : null);
		secWorldStartFlowRequest.SrvFighter4Info = ((roleList.Count > 3) ? this.GetSrvFighterInfo(roleList[3]) : null);
		this.SetCollectSpeed(true);
		Singleton<Net>.Instance.Call<SecWorldStartFlowResponse>(ERequestMessageId.SecWorldStartFlowRequest, secWorldStartFlowRequest, null, 0);
	}

	// Token: 0x0601C38D RID: 115597 RVA: 0x0086A5D8 File Offset: 0x008687D8
	private unsafe void EndSecWorldFlow(long logId)
	{
		if (this.SecWorldFlowLogId != logId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Net;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "EndSecWorldFlow logId Error";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("logId", logId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SecWorldFlowLogId", this.SecWorldFlowLogId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		this.SecWorldFlowLogId = -1L;
		SecWorldSEndFlowRequest secWorldSEndFlowRequest = SecWorldSEndFlowRequest.Create();
		secWorldSEndFlowRequest.LogId = logId;
		secWorldSEndFlowRequest.ClientEndTime = Singleton<TimeUtil>.Instance.DateFormat2(DateTime.Now);
		secWorldSEndFlowRequest.RoundTimeUse = (int)(Singleton<Time>.Instance.WorldTime - this.SecFbRoundStartTime);
		secWorldSEndFlowRequest.SpeedMax = this.MaxSpeed;
		secWorldSEndFlowRequest.SpeedMin = ((this.MinSpeed == 999999) ? 0 : this.MinSpeed);
		secWorldSEndFlowRequest.SpeedAvg = this.AvgSpeed;
		this.SetCollectSpeed(false);
		Singleton<Net>.Instance.Call<SecWorldSEndFlowResponse>(ERequestMessageId.SecWorldSEndFlowRequest, secWorldSEndFlowRequest, null, 0);
	}

	// Token: 0x0601C38E RID: 115598 RVA: 0x0086A6E0 File Offset: 0x008688E0
	private void AddAceAntiCheatInputLayer(int entityId)
	{
		AceAntiCheatInputLayer aceAntiCheatInputLayer = ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.AceAntiCheat) as AceAntiCheatInputLayer;
		if (aceAntiCheatInputLayer != null)
		{
			ControllerBase<InputController>.Instance.AddInputLayer(entityId, aceAntiCheatInputLayer);
			if (this.InputLayers == null)
			{
				this.InputLayers = new List<InputLayer>();
			}
			this.InputLayers.Add(aceAntiCheatInputLayer);
		}
	}

	// Token: 0x0601C38F RID: 115599 RVA: 0x0086A730 File Offset: 0x00868930
	private void RemoveAceAntiCheatInputLayer()
	{
		if (this.InputLayers != null)
		{
			foreach (InputLayer inputLayer in this.InputLayers)
			{
				inputLayer.Clear();
				ControllerBase<InputController>.Instance.RemoveInputLayer(inputLayer);
			}
			this.InputLayers = null;
		}
	}

	// Token: 0x0601C390 RID: 115600 RVA: 0x0086A79C File Offset: 0x0086899C
	public void HandlePress(EInputAction action, float time)
	{
		this.OnCharInputPress(action, time);
	}

	// Token: 0x0400E32F RID: 58159
	private const int POSTICKTIME = 1000;

	// Token: 0x0400E330 RID: 58160
	private const int POSTICKCOUNT = 120;

	// Token: 0x0400E331 RID: 58161
	private const int MINSPEEDINIT = 999999;

	// Token: 0x0400E332 RID: 58162
	private long SecFbRoundLogId = -1L;

	// Token: 0x0400E333 RID: 58163
	private long SecRoleFightFlowBigWorldLogId = -1L;

	// Token: 0x0400E334 RID: 58164
	private long SecRoleFightFlowInstLogId = -1L;

	// Token: 0x0400E335 RID: 58165
	private long SecWorldInfoFlowLogId = -1L;

	// Token: 0x0400E336 RID: 58166
	private long SecWorldFlowLogId = -1L;

	// Token: 0x0400E337 RID: 58167
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<InputLayer> InputLayers;

	// Token: 0x0400E338 RID: 58168
	private double SecFbRoundStartTime;

	// Token: 0x0400E339 RID: 58169
	private int AvgSpeed;

	// Token: 0x0400E33A RID: 58170
	private int MinSpeed;

	// Token: 0x0400E33B RID: 58171
	private int MaxSpeed;

	// Token: 0x0400E33C RID: 58172
	private int CurSpeedCount;

	// Token: 0x0400E33D RID: 58173
	private bool NeedColletSpeed;

	// Token: 0x0400E33E RID: 58174
	private bool NeedColletPos;

	// Token: 0x0400E33F RID: 58175
	private float PosTickTime;

	// Token: 0x0400E340 RID: 58176
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<SceneTeamRole> FightRoleList;

	// Token: 0x0400E341 RID: 58177
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<long, SecRoleFightFlowData> FightRoleInfoMap;

	// Token: 0x0400E342 RID: 58178
	private double ChangeRoleTimeStamp;

	// Token: 0x0400E343 RID: 58179
	private long? CurGlobalRoleCreatureId;

	// Token: 0x0400E344 RID: 58180
	[Nullable(2)]
	private TimerHandle EndSecWorldInfoFlowTimerId;
}
