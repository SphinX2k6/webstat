using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.Protocol;
using Aki.Protocol.Debug;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Launcher.NetworkDetection;
using UnrealEngine;

// Token: 0x02003477 RID: 13431
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class LogController : ControllerBase<LogController>
{
	// Token: 0x0601C505 RID: 115973 RVA: 0x00878872 File Offset: 0x00876A72
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.Register<OutputDebugInfoNotify>(ENotifyMessageId.OutputDebugInfoNotify, new Action<OutputDebugInfoNotify, Net.CallbackStatus>(this.OutputDebugInfoNotify));
		return true;
	}

	// Token: 0x0601C506 RID: 115974 RVA: 0x00878891 File Offset: 0x00876A91
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.OutputDebugInfoNotify);
		return true;
	}

	// Token: 0x0601C507 RID: 115975 RVA: 0x008788A4 File Offset: 0x00876AA4
	private void LogReportFramingHandle(float _)
	{
		int framingLogNum = this.FramingLogNum;
		int num = 0;
		CommonLogData commonLogData = null;
		if (this.LogReportFramingQueue.Count > 0)
		{
			commonLogData = this.LogReportFramingQueue[0];
			this.LogReportFramingQueue.RemoveAt(0);
		}
		while (num < framingLogNum && commonLogData != null)
		{
			ControllerBase<LogReportController>.Instance.LogReport(commonLogData);
			num++;
			if (this.LogReportFramingQueue.Count > 0)
			{
				commonLogData = this.LogReportFramingQueue[0];
				this.LogReportFramingQueue.RemoveAt(0);
			}
			else
			{
				commonLogData = null;
			}
		}
		if (this.LogReportFramingQueue.Count == 0)
		{
			Singleton<TickSystem>.Instance.Remove(this.LogReportFramingTimer);
			this.LogReportFramingTimer = -1;
		}
	}

	// Token: 0x0601C508 RID: 115976 RVA: 0x0087894C File Offset: 0x00876B4C
	private void PushLogDataInFramingQueue(CommonLogData logData)
	{
		if (this.LogReportFramingTimer == -1)
		{
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.LogReportFramingHandle), "LogReportFraming", ETickingGroup.TG_DuringPhysics, false, 0, false);
			if (ticker != null)
			{
				this.LogReportFramingTimer = ticker.Id;
			}
		}
		this.LogReportFramingQueue.Add(logData);
	}

	// Token: 0x0601C509 RID: 115977 RVA: 0x0087899D File Offset: 0x00876B9D
	public void LogBattleStartPush(BattleStartLogData logData, bool isFraming = false)
	{
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(logData);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C50A RID: 115978 RVA: 0x008789B5 File Offset: 0x00876BB5
	public void LogBattleEndPush(BattleEndLogData logData, bool isFraming = false)
	{
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(logData);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C50B RID: 115979 RVA: 0x008789CD File Offset: 0x00876BCD
	public void LogSingleCharacterStatusPush(RoleStateRecord logData, bool isFraming = false)
	{
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(logData);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C50C RID: 115980 RVA: 0x008789E5 File Offset: 0x00876BE5
	public void LogSingleMonsterStatusPush(MonsterStateRecord logData, bool isFraming = false)
	{
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(logData);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C50D RID: 115981 RVA: 0x00878A00 File Offset: 0x00876C00
	public void LogCharacterDeathPush(int roleId, int result, bool isFraming = false)
	{
		DeathRecord deathRecord = new DeathRecord();
		deathRecord.i_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.AreaId;
		deathRecord.i_area_level = ModelBase<AreaModel>.Instance.AreaInfo.Value.Level;
		if (Global.BaseCharacter == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.YZ;
			string message = "日志上报-单机大世界死亡，当前不存在Global.BaseCharacter";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FVectorDouble fvectorDouble = Global.BaseCharacter.D_K2_GetActorLocation();
		deathRecord.f_x = (float)fvectorDouble.X;
		deathRecord.f_y = (float)fvectorDouble.Y;
		deathRecord.f_z = (float)fvectorDouble.Z;
		deathRecord.i_death_reason = result;
		deathRecord.i_death_role_id = roleId;
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(deathRecord);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(deathRecord);
	}

	// Token: 0x0601C50E RID: 115982 RVA: 0x00878ADE File Offset: 0x00876CDE
	public void LogRoleSkillReportPush(RoleSkillReportLog reportData, List<RoleSkillRecord> data, bool isFraming = false)
	{
		reportData.s_reports = JsonSerializer.Serialize<List<RoleSkillRecord>>(data, null);
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(reportData);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(reportData);
	}

	// Token: 0x0601C50F RID: 115983 RVA: 0x00878B03 File Offset: 0x00876D03
	public void LogMonsterSkillReportPush(MonsterSkillReportLog reportData, List<MonsterSkillRecord> data, bool isFraming = false)
	{
		reportData.s_reports = JsonSerializer.Serialize<List<MonsterSkillRecord>>(data, null);
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(reportData);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(reportData);
	}

	// Token: 0x0601C510 RID: 115984 RVA: 0x00878B28 File Offset: 0x00876D28
	public void LogDoubleBallReport(ReactionLogRecord reportData, Dictionary<string, ReactionRecord> data, bool isFraming = false)
	{
		reportData.s_reports = JsonSerializer.Serialize<List<ReactionRecord>>(data.Values.ToList<ReactionRecord>(), null);
		if (isFraming)
		{
			this.PushLogDataInFramingQueue(reportData);
			return;
		}
		ControllerBase<LogReportController>.Instance.LogReport(reportData);
	}

	// Token: 0x0601C511 RID: 115985 RVA: 0x00878B58 File Offset: 0x00876D58
	public void LogTriggerBuffDamagePush(IBuffRecord buffRecord)
	{
		TriggerBuffDamageRecord triggerBuffDamageRecord = new TriggerBuffDamageRecord();
		triggerBuffDamageRecord.i_area_id = buffRecord.AreaId.ToString();
		triggerBuffDamageRecord.s_buff_id = buffRecord.BuffId.ToString();
		triggerBuffDamageRecord.f_time = buffRecord.TimeStamp.ToString("F2");
		triggerBuffDamageRecord.f_player_pos_x = buffRecord.Location.X.ToString("F2");
		triggerBuffDamageRecord.f_player_pos_y = buffRecord.Location.Y.ToString("F2");
		triggerBuffDamageRecord.f_player_pos_z = buffRecord.Location.Z.ToString("F2");
		triggerBuffDamageRecord.i_damage = buffRecord.Damage.ToString();
		ControllerBase<LogReportController>.Instance.LogReport(triggerBuffDamageRecord);
	}

	// Token: 0x0601C512 RID: 115986 RVA: 0x00878C1C File Offset: 0x00876E1C
	public void LogElevatorUsedPush(ElevatorUsedRecord logData)
	{
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C513 RID: 115987 RVA: 0x00878C29 File Offset: 0x00876E29
	public void LogInstFightStartPush(InstFightStartRecord logData)
	{
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C514 RID: 115988 RVA: 0x00878C36 File Offset: 0x00876E36
	public void LogInstFightEndPush(InstFightEndRecord logData)
	{
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C515 RID: 115989 RVA: 0x00878C43 File Offset: 0x00876E43
	public void LogRoleDevPush(RoleDevLogEvent logData)
	{
		ControllerBase<LogReportController>.Instance.LogReport(logData);
	}

	// Token: 0x0601C516 RID: 115990 RVA: 0x00878C50 File Offset: 0x00876E50
	public void SetCurrentUploadLogId(string logId)
	{
		this.CustomServiceLogId = logId;
	}

	// Token: 0x0601C517 RID: 115991 RVA: 0x00878C5C File Offset: 0x00876E5C
	public void LogCustomServiceReport(ESendState result)
	{
		CustomServiceLogEvent customServiceLogEvent = new CustomServiceLogEvent();
		customServiceLogEvent.s_trace_id = this.CustomServiceLogId;
		customServiceLogEvent.log_status = LauncherNetworkDetectionDefine.SendStateToCustomServiceLogMap.GetValueOrDefault(result, 0);
		ControllerBase<LogReportController>.Instance.LogReport(customServiceLogEvent);
	}

	// Token: 0x0601C518 RID: 115992 RVA: 0x00878C98 File Offset: 0x00876E98
	public List<SkillButtonDebugInfo> GetSkillButtonDebugInfo()
	{
		List<SkillButtonDebugInfo> list = new List<SkillButtonDebugInfo>();
		foreach (SkillButtonEntityData skillButtonEntityData in ModelBase<SkillButtonUiModel>.Instance.GetAllSkillButtonEntityData())
		{
			EntityHandle entityHandle = skillButtonEntityData.EntityHandle;
			SkillButtonDebugInfo skillButtonDebugInfo = new SkillButtonDebugInfo((entityHandle != null) ? entityHandle.Id : 0, new List<string>());
			if (skillButtonEntityData.SkillButtonDataMap != null)
			{
				foreach (SkillButtonData skillButtonData in skillButtonEntityData.SkillButtonDataMap.Values)
				{
					skillButtonDebugInfo.Button.Add(skillButtonData.GetDebugInfo());
				}
			}
			list.Add(skillButtonDebugInfo);
		}
		SkillButtonFollowerEntityData curSkillButtonFollowerEntityData = ModelBase<SkillButtonUiModel>.Instance.GetCurSkillButtonFollowerEntityData();
		if (curSkillButtonFollowerEntityData != null && curSkillButtonFollowerEntityData.IsEnable && curSkillButtonFollowerEntityData.SkillButtonDataMap != null)
		{
			EntityHandle entityHandle2 = curSkillButtonFollowerEntityData.EntityHandle;
			SkillButtonDebugInfo skillButtonDebugInfo2 = new SkillButtonDebugInfo((entityHandle2 != null) ? entityHandle2.Id : 0, new List<string>());
			foreach (SkillButtonData skillButtonData2 in curSkillButtonFollowerEntityData.SkillButtonDataMap.Values)
			{
				skillButtonDebugInfo2.Button.Add(skillButtonData2.GetDebugInfo());
			}
			list.Add(skillButtonDebugInfo2);
		}
		return list;
	}

	// Token: 0x0601C519 RID: 115993 RVA: 0x00878E10 File Offset: 0x00877010
	public string OutputDebugInfo(bool log = true)
	{
		string text = Json.Encode(new DebugInfo(ModelBase<GameModeModel>.Instance.InstanceType.ToString(), ModelBase<OnlineModel>.Instance.GetIsMyTeam(), ModelBase<GameModeModel>.Instance.InstanceDungeon.Value.MapConfigId, Singleton<Time>.Instance.TimeDilation, ModelBase<CreatureModel>.Instance.GetPlayerId(), new <>z__ReadOnlyArray<string>(new string[]
		{
			Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy.X.ToString("F2"),
			Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy.Y.ToString("F2"),
			Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy.Z.ToString("F2")
		}), ModelBase<GameModeModel>.Instance.IsMulti, ModelBase<OnlineModel>.Instance.GetAllWorldTeamPlayer(), (from buff in ControllerBase<FormationDataController>.Instance.GetPlayerEntity(ModelBase<CreatureModel>.Instance.GetPlayerId()).GetComponent<PlayerBuffComponent>().GetAllBuffs()
		select buff.Id.ToString()).ToArray<string>(), CharacterGasDebugComponent.GetFormationAttributeDebugStrings().Replace("\n", ",").Replace(" ", ""), ModelBase<SceneTeamModel>.Instance.GetTeamItems(false).Select(delegate(SceneTeamItem formationIn)
		{
			global::FormationRoleInfo formationRoleInfo = new global::FormationRoleInfo();
			EntityHandle entityHandle2 = formationIn.EntityHandle;
			formationRoleInfo.EntityHandleId = ((entityHandle2 != null) ? new int?(entityHandle2.Id) : null);
			formationRoleInfo.ConfigId = formationIn.GetConfigId;
			formationRoleInfo.IsMyRole = formationIn.IsMyRole();
			formationRoleInfo.IsControl = formationIn.IsControl();
			formationRoleInfo.IsDead = formationIn.IsDead();
			return formationRoleInfo;
		}).ToArray<global::FormationRoleInfo>(), this.GetSkillButtonDebugInfo()), null);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		foreach (EntityHandle entityHandle in ModelBase<CreatureModel>.Instance.GetAllEntities())
		{
			WorldEntity entity = entityHandle.Entity;
			CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
			BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
			if (entity != null && characterActorComponent != null && baseBuffComponent != null)
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
				BaseAttributeComponent component3 = entity.GetComponent<BaseAttributeComponent>();
				BaseUnifiedStateComponent component4 = entity.GetComponent<BaseUnifiedStateComponent>();
				string str = text;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(125, 11);
				defaultInterpolatedStringHandler.AppendLiteral("\n***********\n实体信息: EntityHandleId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(entityHandle.Id);
				defaultInterpolatedStringHandler.AppendLiteral(", CreatureDataId: ");
				defaultInterpolatedStringHandler.AppendFormatted<long?>((component != null) ? new long?(component.GetCreatureDataId()) : null);
				defaultInterpolatedStringHandler.AppendLiteral(", PbDataId: ");
				defaultInterpolatedStringHandler.AppendFormatted<int?>((component != null) ? new int?(component.GetPbDataId()) : null);
				defaultInterpolatedStringHandler.AppendLiteral(", Type: ");
				defaultInterpolatedStringHandler.AppendFormatted<EEntityType?>((component != null) ? new EEntityType?(component.GetEntityType()) : null);
				defaultInterpolatedStringHandler.AppendLiteral(", 位置: [");
				defaultInterpolatedStringHandler.AppendFormatted((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy.X.ToString("F2") : null);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy.Y.ToString("F2") : null);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy.Z.ToString("F2") : null);
				defaultInterpolatedStringHandler.AppendLiteral("], IsInFighting: ");
				defaultInterpolatedStringHandler.AppendFormatted<bool?>((component4 != null) ? new bool?(component4.IsInFighting) : null);
				defaultInterpolatedStringHandler.AppendLiteral("\nBuff信息: ");
				string separator = "|";
				IEnumerable<string> enumerable;
				if (baseBuffComponent == null)
				{
					enumerable = null;
				}
				else
				{
					enumerable = baseBuffComponent.GetAllBuffs().Select(delegate(IActiveBuff buff)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(2, 3);
						defaultInterpolatedStringHandler2.AppendFormatted<long>(buff.Id);
						defaultInterpolatedStringHandler2.AppendLiteral(" ");
						defaultInterpolatedStringHandler2.AppendFormatted<int>(buff.Handle);
						defaultInterpolatedStringHandler2.AppendLiteral(" ");
						defaultInterpolatedStringHandler2.AppendFormatted<int>(buff.StackCount);
						return defaultInterpolatedStringHandler2.ToStringAndClear() + (buff.IsActive() ? "" : "(非激活)");
					}).ToList<string>();
				}
				defaultInterpolatedStringHandler.AppendFormatted(string.Join(separator, enumerable ?? new List<string>()));
				defaultInterpolatedStringHandler.AppendLiteral("\n属性信息: ");
				defaultInterpolatedStringHandler.AppendFormatted((component3 != null) ? component3.GetDebugString() : null);
				defaultInterpolatedStringHandler.AppendLiteral("\nTag信息: ");
				defaultInterpolatedStringHandler.AppendFormatted((component2 != null) ? component2.TagContainer.GetExactTagsDebugString().Replace("\n", ",").Replace(" ", "") : null);
				text = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}
		string str2 = text;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(93, 3);
		defaultInterpolatedStringHandler.AppendLiteral("\n***********\n战斗协议信息: MessagePackDataLength: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<CombatMessageModel>.Instance.MessagePack.Data.Count);
		defaultInterpolatedStringHandler.AppendLiteral(", SystemNowSeconds: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(Singleton<Time>.Instance.SystemNowSeconds);
		defaultInterpolatedStringHandler.AppendLiteral(", CombatMessageSendLastTime: ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(ModelBase<CombatMessageModel>.Instance.CombatMessageSendLastTime);
		text = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
		return text;
	}

	// Token: 0x0601C51A RID: 115994 RVA: 0x00879314 File Offset: 0x00877514
	private void OutputDebugInfoNotify(OutputDebugInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		this.RequestOutputDebugInfo();
	}

	// Token: 0x0601C51B RID: 115995 RVA: 0x0087931C File Offset: 0x0087751C
	public void RequestOutputDebugInfo()
	{
		OutputDebugInfoRequest outputDebugInfoRequest = new OutputDebugInfoRequest();
		outputDebugInfoRequest.ClientInfo = this.OutputDebugInfo(true);
		Singleton<Net>.Instance.Call<OutputDebugInfoResponse>(ERequestMessageId.OutputDebugInfoRequest, outputDebugInfoRequest, delegate(OutputDebugInfoResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Log, ELogAuthor.YYZ, "[Debug]服务器端战斗状态信息打印", default(ReadOnlySpan<ValueTuple<string, object>>));
		}, 0);
	}

	// Token: 0x0400E3BE RID: 58302
	private const bool LOG_SWITCH = false;

	// Token: 0x0400E3BF RID: 58303
	private const int FRAMING_LOG_NUM = 20;

	// Token: 0x0400E3C0 RID: 58304
	private int LogReportFramingTimer = -1;

	// Token: 0x0400E3C1 RID: 58305
	private readonly List<CommonLogData> LogReportFramingQueue = new List<CommonLogData>();

	// Token: 0x0400E3C2 RID: 58306
	private readonly int FramingLogNum = 20;

	// Token: 0x0400E3C3 RID: 58307
	private readonly Stat LogOnBattleEndFramingReport = Stat.Create("LogOnBattleEnd_Framing", "", "");

	// Token: 0x0400E3C4 RID: 58308
	private string CustomServiceLogId = "";
}
