using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.CombatMessage;
using CSharpScript.Core.Common;
using CSharpScript.Launcher.ThinkDataReport;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F4 RID: 18164
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CombatDebugController : ControllerBase<CombatDebugController>
	{
		// Token: 0x0602F3CD RID: 193485 RVA: 0x00B33440 File Offset: 0x00B31640
		[NullableContext(2)]
		public void CombatInfoMessage(CombatLog.EDebugModule flag, EMessageId messageName, CombatCommon combatCommon = null)
		{
			if (!Singleton<CombatLog>.Instance.DebugCombatInfo.Contains(flag))
			{
				return;
			}
			bool flag2;
			if (!this.LogMessageWhiteMap.TryGetValue(messageName, out flag2) || !flag2)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (combatCommon != null)
			{
				long value = Singleton<MathUtils>.Instance.LongToBigInt(combatCommon.EntityId);
				long value2 = Singleton<MathUtils>.Instance.LongToNumber(combatCommon.Originator);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 4);
				defaultInterpolatedStringHandler.AppendLiteral("[Message][");
				defaultInterpolatedStringHandler.AppendFormatted<CombatLog.EDebugModule>(flag);
				defaultInterpolatedStringHandler.AppendLiteral("][");
				defaultInterpolatedStringHandler.AppendFormatted<EMessageId>(messageName);
				defaultInterpolatedStringHandler.AppendLiteral("][EntityId:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(value);
				defaultInterpolatedStringHandler.AppendLiteral("][PlayerId:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(value2);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				string message = defaultInterpolatedStringHandler.ToStringAndClear();
				Singleton<Log>.Instance.Info(ELogModule.CombatInfo, ELogAuthor.WCL, message, default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[Message][");
			defaultInterpolatedStringHandler.AppendFormatted<CombatLog.EDebugModule>(flag);
			defaultInterpolatedStringHandler.AppendLiteral("][");
			defaultInterpolatedStringHandler.AppendFormatted<EMessageId>(messageName);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
			Singleton<Log>.Instance.Info(ELogModule.CombatInfo, ELogAuthor.WCL, message2, default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0602F3CE RID: 193486 RVA: 0x00B3358C File Offset: 0x00B3178C
		[NullableContext(2)]
		public void CombatContextInfoMessage(CombatLog.EDebugModule flag, EMessageId messageName, CombatRequestData requestData = null)
		{
			if (!Singleton<CombatLog>.Instance.DebugCombatInfo.Contains(CombatLog.EDebugModule.Message))
			{
				return;
			}
			bool flag2;
			if (!this.LogMessageWhiteMap.TryGetValue(messageName, out flag2) || !flag2)
			{
				return;
			}
			CombatCommon combatCommon = (requestData != null) ? requestData.CombatCommon : null;
			if (combatCommon != null)
			{
				long value = Singleton<MathUtils>.Instance.LongToBigInt(combatCommon.EntityId);
				long value2 = Singleton<MathUtils>.Instance.LongToNumber(combatCommon.Originator);
				long value3 = Singleton<MathUtils>.Instance.LongToBigInt(combatCommon.MessageId);
				long value4 = Singleton<MathUtils>.Instance.LongToBigInt(combatCommon.PreMessageId);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(62, 6);
				defaultInterpolatedStringHandler.AppendLiteral("[Message][");
				defaultInterpolatedStringHandler.AppendFormatted<CombatLog.EDebugModule>(flag);
				defaultInterpolatedStringHandler.AppendLiteral("][");
				defaultInterpolatedStringHandler.AppendFormatted<EMessageId>(messageName);
				defaultInterpolatedStringHandler.AppendLiteral("][EntityId:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(value);
				defaultInterpolatedStringHandler.AppendLiteral("][PlayerId:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(value2);
				defaultInterpolatedStringHandler.AppendLiteral("][MessageId:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(value3);
				defaultInterpolatedStringHandler.AppendLiteral("][PreMessageId:");
				defaultInterpolatedStringHandler.AppendFormatted<long>(value4);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				string message = defaultInterpolatedStringHandler.ToStringAndClear();
				Singleton<Log>.Instance.Info(ELogModule.CombatInfo, ELogAuthor.YJX, message, default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0602F3CF RID: 193487 RVA: 0x00B336D0 File Offset: 0x00B318D0
		public void DataReport(string eventName, string data)
		{
			if (!Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				return;
			}
			Singleton<ThinkDataLaunchReporter>.Instance.Report(eventName, data);
		}

		// Token: 0x0602F3D0 RID: 193488 RVA: 0x00B336EB File Offset: 0x00B318EB
		public string FilterCmd(string script)
		{
			this.ScriptHelper.Init();
			return this.ScriptHelper.FilterCmd(script);
		}

		// Token: 0x0602F3D1 RID: 193489 RVA: 0x00B33704 File Offset: 0x00B31904
		private void RefreshPlayerServerDebugInfo()
		{
			if (this.DebugEntityId == 0)
			{
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(this.DebugEntityId);
			RoleBuffComponent roleBuffComponent = (entity != null) ? entity.GetComponent<RoleBuffComponent>() : null;
			if (roleBuffComponent == null)
			{
				return;
			}
			PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
			CharacterGasDebugComponent characterGasDebugComponent = (formationBuffComp != null) ? formationBuffComp.Entity.GetComponent<CharacterGasDebugComponent>() : null;
			if (characterGasDebugComponent == null)
			{
				return;
			}
			characterGasDebugComponent.ServerDebugInfoRequest();
		}

		// Token: 0x0602F3D2 RID: 193490 RVA: 0x00B3375C File Offset: 0x00B3195C
		public void RefreshServerDebugInfo()
		{
			if (this.DebugEntityId == 0)
			{
				return;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(this.DebugEntityId);
			CharacterGasDebugComponent characterGasDebugComponent = (entity != null) ? entity.GetComponent<CharacterGasDebugComponent>() : null;
			if (characterGasDebugComponent == null || Singleton<Time>.Instance.Now - this.RequestTimeStamp < 300.0)
			{
				return;
			}
			this.RequestTimeStamp = Singleton<Time>.Instance.Now;
			if (characterGasDebugComponent != null)
			{
				characterGasDebugComponent.ServerDebugInfoRequest();
			}
			this.RefreshPlayerServerDebugInfo();
		}

		// Token: 0x0602F3D3 RID: 193491 RVA: 0x00B337D0 File Offset: 0x00B319D0
		public CombatDebugController()
		{
			Dictionary<EMessageId, bool> dictionary = new Dictionary<EMessageId, bool>();
			dictionary[EMessageId.HitRequest] = true;
			dictionary[EMessageId.HitEndRequest] = true;
			dictionary[EMessageId.SkillRequest] = true;
			dictionary[EMessageId.UseSkillRequest] = true;
			dictionary[EMessageId.EndSkillRequest] = true;
			dictionary[EMessageId.SwitchCharacterStateRequest] = true;
			dictionary[EMessageId.LogicStateInitRequest] = true;
			dictionary[EMessageId.MaterialRequest] = true;
			dictionary[EMessageId.EntityIsVisibleRequest] = true;
			dictionary[EMessageId.AiInformationRequest] = true;
			dictionary[EMessageId.PartUpdateRequest] = true;
			dictionary[EMessageId.HitNotify] = true;
			dictionary[EMessageId.SkillNotify] = true;
			dictionary[EMessageId.UseSkillNotify] = true;
			dictionary[EMessageId.EndSkillNotify] = true;
			dictionary[EMessageId.EntityLoadCompleteNotify] = true;
			dictionary[EMessageId.SwitchCharacterStateNotify] = true;
			dictionary[EMessageId.SwitchLogicStateNotify] = true;
			dictionary[EMessageId.MaterialNotify] = true;
			dictionary[EMessageId.EntityIsVisibleNotify] = true;
			dictionary[EMessageId.AiInformationNotify] = true;
			dictionary[EMessageId.PartUpdateNotify] = true;
			dictionary[EMessageId.AnimationStateInitNotify] = true;
			dictionary[EMessageId.AnimationStateChangedPush] = true;
			dictionary[EMessageId.LogicStateInitNotify] = true;
			dictionary[EMessageId.ApplyGameplayEffectRequest] = true;
			dictionary[EMessageId.OrderApplyBuffRequest] = true;
			dictionary[EMessageId.OrderRemoveBuffRequest] = true;
			dictionary[EMessageId.RemoveGameplayEffectRequest] = true;
			dictionary[EMessageId.OrderApplyBuffNotify] = true;
			this.LogMessageWhiteMap = dictionary;
			this.AttributeNameCache = new Dictionary<EAttributeType, string>();
			base..ctor();
		}

		// Token: 0x0401AE9E RID: 110238
		public int DebugEntityId;

		// Token: 0x0401AE9F RID: 110239
		public const int REFRESH_SERVER_INFO_PERIOD = 300;

		// Token: 0x0401AEA0 RID: 110240
		public readonly CombatScriptHelper ScriptHelper = new CombatScriptHelper();

		// Token: 0x0401AEA1 RID: 110241
		private readonly Dictionary<EMessageId, bool> LogMessageWhiteMap;

		// Token: 0x0401AEA2 RID: 110242
		private double RequestTimeStamp;

		// Token: 0x0401AEA3 RID: 110243
		private readonly Dictionary<EAttributeType, string> AttributeNameCache;
	}
}
