using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Debug;
using AkiClient.Game.Aki.Character.BaseCharacter;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E96 RID: 24214
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SkillMessageController : ControllerBase<SkillMessageController>
	{
		// Token: 0x0603CE3C RID: 249404 RVA: 0x00F77C5D File Offset: 0x00F75E5D
		public void AddSkillMessageId(long message)
		{
			this.SkillCombatMessageSet.Add(message);
		}

		// Token: 0x0603CE3D RID: 249405 RVA: 0x00F77C6C File Offset: 0x00F75E6C
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<DebugFightErrInfoNotify>(ENotifyMessageId.DebugFightErrInfoNotify, new Action<DebugFightErrInfoNotify, Net.CallbackStatus>(this.GetDebugFightErrInfo));
			return true;
		}

		// Token: 0x0603CE3E RID: 249406 RVA: 0x00F77C8B File Offset: 0x00F75E8B
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DebugFightErrInfoNotify);
			this.SkillCombatMessageSet.Clear();
			return true;
		}

		// Token: 0x0603CE3F RID: 249407 RVA: 0x00F77CAC File Offset: 0x00F75EAC
		[NullableContext(2)]
		[CombatPreprocess(ENotifyMessageId.UseSkillNotify)]
		public static bool PreUseSkillNotify(Entity entity, [Nullable(1)] UseSkillNotify notify, CombatCommon combatCommon = null)
		{
			CharacterFightStateComponent characterFightStateComponent = (entity != null) ? entity.GetComponent<CharacterFightStateComponent>() : null;
			if (characterFightStateComponent != null)
			{
				CharacterFightStateComponent characterFightStateComponent2 = characterFightStateComponent;
				UseSkillInformation useSkillInfo = notify.UseSkillInfo;
				if (!characterFightStateComponent2.PreSwitchRemoteFightState((useSkillInfo != null) ? useSkillInfo.FightState : 0))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603CE40 RID: 249408 RVA: 0x00F77CE8 File Offset: 0x00F75EE8
		[NullableContext(2)]
		[CombatListen(ENotifyMessageId.UseSkillNotify, true, true)]
		public static void UseSkillNotify(Entity entity, UseSkillNotify data, CombatCommon combatCommon = null)
		{
			if (entity == null || data == null || data.UseSkillInfo == null || data.UseSkillInfo.SkillId == 0L)
			{
				Singleton<Log>.Instance.Error(ELogModule.MultiplayerCombat, ELogAuthor.WCL, "[CreatureController.UseSkillNotify] 服务器返回参数有误。", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			long messageId = combatCommon.MessageId;
			BaseSkillComponent component = entity.GetComponent<BaseSkillComponent>();
			long targetId = data.UseSkillInfo.TargetId;
			if (component != null && component.SimulatedBeginSkill((int)data.UseSkillInfo.SkillId, targetId, data.UseSkillInfo.IsSpecialSkill, (float)data.UseSkillInfo.Duration * 0.001f, messageId))
			{
				ControllerBase<SkillMessageController>.Instance.SkillCombatMessageSet.Add(messageId);
			}
		}

		// Token: 0x0603CE41 RID: 249409 RVA: 0x00F77D94 File Offset: 0x00F75F94
		[NullableContext(2)]
		[CombatListen(ENotifyMessageId.SkillNotify, true, true)]
		public static void SkillNotify(Entity entity, [Nullable(1)] SkillNotify data, CombatCommon combatCommon = null)
		{
			BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
			if (baseSkillComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MultiplayerCombat, ELogAuthor.WCL, "[CreatureController.SkillNotify] 不存在skillComponent。", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			long preMessageId = combatCommon.PreMessageId;
			if (!ControllerBase<SkillMessageController>.Instance.SkillCombatMessageSet.Contains(preMessageId))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
				string message = "技能释放未被确认，拒绝其后续行为";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("技能Id", data.UseSkillInfo.SkillId);
				instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (data.SkillNodeInfos.SubProtocol == 1)
			{
				long messageId = combatCommon.MessageId;
				baseSkillComponent.SimulatePlayMontage((int)data.UseSkillInfo.SkillId, data.SkillNodeInfos.MontageIndex, data.SkillNodeInfos.SpeedRatio, data.SkillNodeInfos.StartSection, data.SkillNodeInfos.StartTimeSeconds, messageId);
			}
		}

		// Token: 0x0603CE42 RID: 249410 RVA: 0x00F77E78 File Offset: 0x00F76078
		[NullableContext(2)]
		[CombatListen(ENotifyMessageId.EndSkillNotify, true, true)]
		public static void EndSkillNotify(Entity entity, EndSkillNotify data, CombatCommon combatCommon = null)
		{
			if (data.UseSkillInfo == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.LFJW, "[CreatureController.EndSkillNotify] 服务器返回参数有误。", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			long preMessageId = combatCommon.PreMessageId;
			ControllerBase<SkillMessageController>.Instance.SkillCombatMessageSet.Remove(preMessageId);
			BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
			if (baseSkillComponent == null)
			{
				return;
			}
			baseSkillComponent.SimulateEndSkill((int)data.UseSkillInfo.SkillId);
		}

		// Token: 0x0603CE43 RID: 249411 RVA: 0x00F77EE4 File Offset: 0x00F760E4
		public bool UseSkillRequest(Entity entity, Skill skill, int targetId)
		{
			BaseSkillComponent skillComp = entity.GetComponent<BaseSkillComponent>();
			if (skillComp == null)
			{
				return false;
			}
			int skillId = skill.SkillId;
			SSkillInfo skillInfo = skill.SkillInfo;
			bool isSpecialSkill = skillInfo != null && skillInfo.AutonomouslyBySimulate;
			SSkillInfo skillInfo2 = skill.SkillInfo;
			float num = (skillInfo2 != null) ? skillInfo2.MoveControllerTime : 0f;
			int interruptLevel = skill.InterruptLevel;
			long? preContextId = skill.PreContextId;
			long? combatMessageId = skill.CombatMessageId;
			UseSkillRequest useSkillRequest = new UseSkillRequest();
			useSkillRequest.UseSkillInfo = new UseSkillInformation
			{
				SkillId = (long)skillId,
				TargetId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(targetId),
				TimeStamp = (float)Singleton<Time>.Instance.NowSeconds,
				IsSpecialSkill = isSpecialSkill,
				Duration = (int)(num * 1000f),
				SkillInterruptLevel = interruptLevel
			};
			ISkillBattleContext battleContext = skill.BattleContext;
			if (((battleContext != null) ? battleContext.BattleFlags : null) != null)
			{
				foreach (string tagName in skill.BattleContext.BattleFlags)
				{
					int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
					useSkillRequest.BattleFlags.Add(tagIdByName);
				}
			}
			int fightStateHandle = skill.FightStateHandle;
			if (fightStateHandle != 0)
			{
				UseSkillInformation useSkillInfo = useSkillRequest.UseSkillInfo;
				CharacterFightStateComponent fightStateComp = skillComp.FightStateComp;
				useSkillInfo.FightState = ((fightStateComp != null) ? fightStateComp.GetFightState() : 0);
			}
			Singleton<CombatNet>.Instance.Call<UseSkillResponse>(ERequestMessageId.UseSkillRequest, entity, useSkillRequest, delegate(UseSkillResponse response)
			{
				if (entity.IsEnd)
				{
					return;
				}
				if (response != null && response.ErrorCode == ErrorCode.Success)
				{
					if (fightStateHandle != 0)
					{
						BaseSkillComponent skillComp;
						CharacterFightStateComponent fightStateComp2 = skillComp.FightStateComp;
						if (fightStateComp2 == null)
						{
							return;
						}
						fightStateComp2.ConfirmState(fightStateHandle);
						return;
					}
				}
				else
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
					Entity entity2 = entity;
					string message = "技能释放服务器拒绝，技能终止";
					string item = "技能Id";
					long? num2;
					if (response == null)
					{
						num2 = null;
					}
					else
					{
						UseSkillInformation useSkillInfo2 = response.UseSkillInfo;
						num2 = ((useSkillInfo2 != null) ? new long?(useSkillInfo2.SkillId) : null);
					}
					long? num3 = num2;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, num3.GetValueOrDefault());
					instance.Info(flag, entity2, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					BaseSkillComponent skillComp = skillComp;
					long? num4;
					if (response == null)
					{
						num4 = null;
					}
					else
					{
						UseSkillInformation useSkillInfo3 = response.UseSkillInfo;
						num4 = ((useSkillInfo3 != null) ? new long?(useSkillInfo3.SkillId) : null);
					}
					num3 = num4;
					skillComp.EndSkill((int)num3.GetValueOrDefault(), "SkillMessageController.UseSkillRequest");
				}
			}, preContextId, combatMessageId, null, null);
			return true;
		}

		// Token: 0x0603CE44 RID: 249412 RVA: 0x00F780A0 File Offset: 0x00F762A0
		public bool EndSkillRequest(Entity entity, int skillId, EndSkillInfo endSkillInfo)
		{
			if (entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiplayerCombat;
				ELogAuthor author = ELogAuthor.WCL;
				string message = "[CreatureController.EndSkillRequest] entityId无效。";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", null);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			EndSkillPush message2 = new EndSkillPush
			{
				UseSkillInfo = new UseSkillInformation
				{
					SkillId = (long)skillId,
					TimeStamp = (float)Singleton<Time>.Instance.NowSeconds
				},
				Reason = endSkillInfo.Reason,
				InterruptSkillInfo = new InterruptSkillInfo
				{
					EntityId = endSkillInfo.EntityId,
					SkillId = (long)endSkillInfo.SkillId,
					BulletId = endSkillInfo.BulletId
				}
			};
			Singleton<CombatNet>.Instance.Send(EPushMessageId.EndSkillPush, entity, message2, null, null, null);
			return true;
		}

		// Token: 0x0603CE45 RID: 249413 RVA: 0x00F78170 File Offset: 0x00F76370
		public unsafe void MontageRequest(Entity entity, int subProtocol, int skillId, long targetId, int montageIndex, float speedRatio = 1f, string startSection = "", float startTimeSeconds = 0f, long? preCombatMessageId = null, long? combatMessageId = null)
		{
			UseSkillInformation useSkillInfo = new UseSkillInformation
			{
				SkillId = (long)skillId,
				TargetId = targetId,
				TimeStamp = (float)Singleton<Time>.Instance.NowSeconds
			};
			SkillNodeInfo skillNodeInfos = new SkillNodeInfo
			{
				SubProtocol = subProtocol,
				MontageIndex = montageIndex,
				SpeedRatio = speedRatio,
				StartSection = startSection,
				StartTimeSeconds = startTimeSeconds
			};
			SkillRequest data = new SkillRequest
			{
				UseSkillInfo = useSkillInfo,
				SkillNodeInfos = skillNodeInfos
			};
			Singleton<CombatNet>.Instance.Call<SkillResponse>(ERequestMessageId.SkillRequest, entity, data, delegate(SkillResponse response)
			{
				if (entity.IsEnd)
				{
					return;
				}
				ErrorCode errorCode = response.ErrorCode;
				if (errorCode != ErrorCode.Success && errorCode != ErrorCode.ErrCombatSkillGahandleGetEntityFailed)
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
					Entity entity2 = entity;
					string message = "播放蒙太奇请求失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", skillId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ErrorCode", response.ErrorCode);
					instance.Error(flag, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}, preCombatMessageId, combatMessageId, null, null);
		}

		// Token: 0x0603CE46 RID: 249414 RVA: 0x00F7823C File Offset: 0x00F7643C
		public void AnimNotifyRequest(Entity entity, int skillId, int montageIndex, int animNotifyIndex, long? preCombatMessageId = null, long? combatMessageId = null)
		{
			ANStartPush message = new ANStartPush
			{
				AnIndex = animNotifyIndex,
				MontageIndex = montageIndex,
				SkillId = (long)skillId
			};
			Singleton<CombatNet>.Instance.Send(EPushMessageId.ANStartPush, entity, message, preCombatMessageId, combatMessageId, null);
		}

		// Token: 0x0603CE47 RID: 249415 RVA: 0x00F78288 File Offset: 0x00F76488
		public unsafe long PassiveSkillAddRequest(Entity entity, long skillId, long? preCombatMessageId = null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			string message = "添加被动Request";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("被动技能Id", skillId);
			instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			PassiveSkillAddPush passiveSkillAddPush = new PassiveSkillAddPush();
			passiveSkillAddPush.PassiveSkillId = skillId;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			passiveSkillAddPush.TargetEntityId = ((component != null) ? component.GetCreatureDataId() : 0L);
			PassiveSkillAddPush message2 = passiveSkillAddPush;
			long num = ModelBase<CombatMessageModel>.Instance.GenMessageId();
			long? num2 = preCombatMessageId;
			long num3 = 0L;
			if (num2.GetValueOrDefault() == num3 & num2 != null)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Message;
				string message3 = "请求服务器添加被动技能时，发送的PreMessageId无效";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entity", ((entity != null) ? entity.GetType().Name : null) ?? "null");
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("skillId", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("preCombatMessageId", preCombatMessageId.GetValueOrDefault());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("combatMessageId", num);
				instance2.Error(flag2, entity, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			Singleton<CombatNet>.Instance.Send(EPushMessageId.PassiveSkillAddPush, entity, message2, preCombatMessageId, new long?(num), null);
			return num;
		}

		// Token: 0x0603CE48 RID: 249416 RVA: 0x00F783E4 File Offset: 0x00F765E4
		public void PassiveSkillRemoveRequest(Entity entity, long skillId, long? preCombatMessageId = null, long? combatMessageId = null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
			string message = "移除被动Request";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("被动技能Id", skillId);
			instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			PassiveSkillRemovePush passiveSkillRemovePush = new PassiveSkillRemovePush();
			passiveSkillRemovePush.PassiveSkillId = skillId;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			passiveSkillRemovePush.TargetEntityId = ((component != null) ? component.GetCreatureDataId() : 0L);
			PassiveSkillRemovePush message2 = passiveSkillRemovePush;
			Singleton<CombatNet>.Instance.Send(EPushMessageId.PassiveSkillRemovePush, entity, message2, preCombatMessageId, combatMessageId, null);
		}

		// Token: 0x0603CE49 RID: 249417 RVA: 0x00F78460 File Offset: 0x00F76660
		private void GetDebugFightErrInfo(DebugFightErrInfoNotify data, [Nullable(2)] Net.CallbackStatus callbackStatus)
		{
			ErrorCode errorCode = data.ErrorCode;
			if (errorCode <= ErrorCode.ErrNoBuffConf)
			{
				if (errorCode == ErrorCode.ErrContextCheckFail)
				{
					this.PrintDebugFightErrInfo("技能上下文校验报错", data.ExtraInfo ?? "");
					return;
				}
				switch (errorCode)
				{
				case ErrorCode.ErrMontageConfigNotFound:
					this.PrintDebugFightErrInfo("蒙太奇配置未找到", data.ExtraInfo ?? "");
					return;
				case ErrorCode.ErrAnconfigNotFound:
					this.PrintDebugFightErrInfo("AN配置未找到", data.ExtraInfo ?? "");
					return;
				case ErrorCode.ErrBulletConfigNotFound:
					this.PrintDebugFightErrInfo("子弹配置未找到", data.ExtraInfo ?? "");
					return;
				default:
					if (errorCode == ErrorCode.ErrNoBuffConf)
					{
						this.PrintDebugFightErrInfo("BUFF配置未找到", data.ExtraInfo ?? "");
						return;
					}
					break;
				}
			}
			else
			{
				if (errorCode == ErrorCode.ErrConfSkillNotExist)
				{
					this.PrintDebugFightErrInfo("技能配置未找到", data.ExtraInfo ?? "");
					return;
				}
				if (errorCode == ErrorCode.ErrSkillCd)
				{
					this.PrintDebugFightErrInfo("技能CD中", data.ExtraInfo ?? "");
					return;
				}
				if (errorCode == ErrorCode.ErrPlayMontageButNoSkill)
				{
					this.PrintDebugFightErrInfo("蒙太奇对应的技能未释放成功", data.ExtraInfo ?? "");
					return;
				}
			}
			this.PrintDebugFightErrInfo("未支持的ErrorCode", data.ExtraInfo ?? "");
		}

		// Token: 0x0603CE4A RID: 249418 RVA: 0x00F785BC File Offset: 0x00F767BC
		private void PrintDebugFightErrInfo(string reason, string info)
		{
			if (this.ClosePrintDebugFightErrInfo)
			{
				return;
			}
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Message;
			Entity entity = null;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("info", info);
			instance.Error(flag, entity, reason, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x040222F5 RID: 140021
		private const int SKILL_PLAY_MONTAGE = 1;

		// Token: 0x040222F6 RID: 140022
		public bool CloseMonsterServerLogic;

		// Token: 0x040222F7 RID: 140023
		public bool ClosePrintDebugFightErrInfo = true;

		// Token: 0x040222F8 RID: 140024
		private readonly HashSet<long> SkillCombatMessageSet = new HashSet<long>();
	}
}
