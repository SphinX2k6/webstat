using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Ai;
using Aki.Protocol.CombatMessage;
using Google.Protobuf;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E92 RID: 24210
	public static class CombatMessageExtension
	{
		// Token: 0x0603CE11 RID: 249361 RVA: 0x00F74E94 File Offset: 0x00F73094
		[return: Nullable(2)]
		public static CombatExactNotifyDataPack GetExactNotifyDataPack(this CombatNotifyData notifyData)
		{
			CombatNotifyData.MessageOneofCase messageCase = notifyData.MessageCase;
			switch (messageCase)
			{
			case CombatNotifyData.MessageOneofCase.None:
				return null;
			case CombatNotifyData.MessageOneofCase.CreateBulletNotify:
				return new CombatExactNotifyDataPack(notifyData.CreateBulletNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.DestroyBulletNotify:
				return new CombatExactNotifyDataPack(notifyData.DestroyBulletNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.DamageExecuteNotify:
				return new CombatExactNotifyDataPack(notifyData.DamageExecuteNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ApplyGameplayEffectNotify:
				return new CombatExactNotifyDataPack(notifyData.ApplyGameplayEffectNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.RemoveGameplayEffectNotify:
				return new CombatExactNotifyDataPack(notifyData.RemoveGameplayEffectNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.HitNotify:
				return new CombatExactNotifyDataPack(notifyData.HitNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.SkillNotify:
				return new CombatExactNotifyDataPack(notifyData.SkillNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.UseSkillNotify:
				return new CombatExactNotifyDataPack(notifyData.UseSkillNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.EndSkillNotify:
				return new CombatExactNotifyDataPack(notifyData.EndSkillNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.EntityLoadCompleteNotify:
				return new CombatExactNotifyDataPack(notifyData.EntityLoadCompleteNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.PartUpdateNotify:
				return new CombatExactNotifyDataPack(notifyData.PartUpdateNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.PartComponentInitNotify:
				return new CombatExactNotifyDataPack(notifyData.PartComponentInitNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.MaterialNotify:
				return new CombatExactNotifyDataPack(notifyData.MaterialNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.GameplayCueNotify:
				return new CombatExactNotifyDataPack(notifyData.GameplayCueNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.EntityIsVisibleNotify:
				return new CombatExactNotifyDataPack(notifyData.EntityIsVisibleNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.SwitchCharacterStateNotify:
				return new CombatExactNotifyDataPack(notifyData.SwitchCharacterStateNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.PlayerRebackSceneNotify:
				return new CombatExactNotifyDataPack(notifyData.PlayerRebackSceneNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.LogicStateInitNotify:
				return new CombatExactNotifyDataPack(notifyData.LogicStateInitNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.SwitchLogicStateNotify:
				return new CombatExactNotifyDataPack(notifyData.SwitchLogicStateNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AttributeChangedNotify:
				return new CombatExactNotifyDataPack(notifyData.AttributeChangedNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AnimationStateChangedNotify:
				return new CombatExactNotifyDataPack(notifyData.AnimationStateChangedNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AnimationStateInitNotify:
				return new CombatExactNotifyDataPack(notifyData.AnimationStateInitNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ModifyBulletParamsNotify:
				return new CombatExactNotifyDataPack(notifyData.ModifyBulletParamsNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.DrownNotify:
				return new CombatExactNotifyDataPack(notifyData.DrownNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.OrderApplyBuffNotify:
				return new CombatExactNotifyDataPack(notifyData.OrderApplyBuffNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.OrderRemoveBuffNotify:
				return new CombatExactNotifyDataPack(notifyData.OrderRemoveBuffNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ActivateBuffNotify:
				return new CombatExactNotifyDataPack(notifyData.ActivateBuffNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.OrderRemoveBuffByTagsNotify:
				return new CombatExactNotifyDataPack(notifyData.OrderRemoveBuffByTagsNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AiInformationNotify:
				return new CombatExactNotifyDataPack(notifyData.AiInformationNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.BattleStateChangeNotify:
				return new CombatExactNotifyDataPack(notifyData.BattleStateChangeNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AnimationGameplayTagNotify:
				return new CombatExactNotifyDataPack(notifyData.AnimationGameplayTagNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.BoneVisibleChangeNotify:
				return new CombatExactNotifyDataPack(notifyData.BoneVisibleChangeNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AiBlackboardCdNotify:
				return new CombatExactNotifyDataPack(notifyData.AiBlackboardCdNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.CaughtNotify:
				return new CombatExactNotifyDataPack(notifyData.CaughtNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.EntityStaticHookMoveNotify:
				return new CombatExactNotifyDataPack(notifyData.EntityStaticHookMoveNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ChangeStateNotify:
				return new CombatExactNotifyDataPack(notifyData.ChangeStateNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ChangeStateConfirmNotify:
				return new CombatExactNotifyDataPack(notifyData.ChangeStateConfirmNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.BuffStackCountNotify:
				return new CombatExactNotifyDataPack(notifyData.BuffStackCountNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.MontagePlayNotify:
				return new CombatExactNotifyDataPack(notifyData.MontagePlayNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ANStartNotify:
				return new CombatExactNotifyDataPack(notifyData.ANStartNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.FsmResetNotify:
				return new CombatExactNotifyDataPack(notifyData.FsmResetNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.DamageRecordNotify:
				return new CombatExactNotifyDataPack(notifyData.DamageRecordNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AiHateNotify:
				return new CombatExactNotifyDataPack(notifyData.AiHateNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.FsmBlackboardNotify:
				return new CombatExactNotifyDataPack(notifyData.FsmBlackboardNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.CharacterBattleStateChangeNotify:
				return new CombatExactNotifyDataPack(notifyData.CharacterBattleStateChangeNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ApplyBuffS2CRequestNotify:
				return new CombatExactNotifyDataPack(notifyData.ApplyBuffS2CRequestNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.RemoveBuffS2CRequestNotify:
				return new CombatExactNotifyDataPack(notifyData.RemoveBuffS2CRequestNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ActorVisibleNotify:
				return new CombatExactNotifyDataPack(notifyData.ActorVisibleNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.RecoverPropChangedNotify:
				return new CombatExactNotifyDataPack(notifyData.RecoverPropChangedNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.RemoveBuffByIdS2CRequestNotify:
				return new CombatExactNotifyDataPack(notifyData.RemoveBuffByIdS2CRequestNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ShieldUpdateNotify:
				return new CombatExactNotifyDataPack(notifyData.ShieldUpdateNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.PlayerBattleStateChangeNotify:
				return new CombatExactNotifyDataPack(notifyData.PlayerBattleStateChangeNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.FsmCustomBlackboardNotify:
				return new CombatExactNotifyDataPack(notifyData.FsmCustomBlackboardNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.PassiveSkillAddNotify:
				return new CombatExactNotifyDataPack(notifyData.PassiveSkillAddNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.PassiveSkillRemoveNotify:
				return new CombatExactNotifyDataPack(notifyData.PassiveSkillRemoveNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ExecuteQteNotify:
				return new CombatExactNotifyDataPack(notifyData.ExecuteQteNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ModifyEntityCampNotify:
				return new CombatExactNotifyDataPack(notifyData.ModifyEntityCampNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.AddCombineEntitiesRelationNotify:
				return new CombatExactNotifyDataPack(notifyData.AddCombineEntitiesRelationNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.RemoveCombineRelationNotify:
				return new CombatExactNotifyDataPack(notifyData.RemoveCombineRelationNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.TestDamageRecordNotify:
				return new CombatExactNotifyDataPack(notifyData.TestDamageRecordNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.BuffDurationNotify:
				return new CombatExactNotifyDataPack(notifyData.BuffDurationNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.EntityLivingStatusNotify:
				return new CombatExactNotifyDataPack(notifyData.EntityLivingStatusNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.NewLinkNotify:
				return new CombatExactNotifyDataPack(notifyData.NewLinkNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.ApplyBuffFailedNotify:
				return new CombatExactNotifyDataPack(notifyData.ApplyBuffFailedNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.PackAnimChangedNotify:
				return new CombatExactNotifyDataPack(notifyData.PackAnimChangedNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.VisionTriggerNotify:
				return new CombatExactNotifyDataPack(notifyData.VisionTriggerNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.RemoveBuffByServerIdS2CRequestNotify:
				return new CombatExactNotifyDataPack(notifyData.RemoveBuffByServerIdS2CRequestNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.TransformBuffStackNotify:
				return new CombatExactNotifyDataPack(notifyData.TransformBuffStackNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.MotorSummonAndRideNotify:
				return new CombatExactNotifyDataPack(notifyData.MotorSummonAndRideNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.BulletPatternNotify:
				return new CombatExactNotifyDataPack(notifyData.BulletPatternNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.FsmMontageDurationNotify:
				return new CombatExactNotifyDataPack(notifyData.FsmMontageDurationNotify, messageCase);
			case CombatNotifyData.MessageOneofCase.CombatDataMaxNotify:
				return new CombatExactNotifyDataPack(notifyData.CombatDataMaxNotify, messageCase);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CombatInfo;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "未处理的CombatNotify消息类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MessageType", messageCase);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603CE12 RID: 249362 RVA: 0x00F75424 File Offset: 0x00F73624
		[return: Nullable(2)]
		public static CombatExactRequestDataPack GetExactRequestDataPack(this CombatRequestData requestData)
		{
			CombatRequestData.MessageOneofCase messageCase = requestData.MessageCase;
			switch (messageCase)
			{
			case CombatRequestData.MessageOneofCase.None:
				return null;
			case CombatRequestData.MessageOneofCase.CreateBulletRequest:
				return new CombatExactRequestDataPack(requestData.CreateBulletRequest, messageCase);
			case CombatRequestData.MessageOneofCase.DestroyBulletRequest:
				return new CombatExactRequestDataPack(requestData.DestroyBulletRequest, messageCase);
			case CombatRequestData.MessageOneofCase.DamageExecuteRequest:
				return new CombatExactRequestDataPack(requestData.DamageExecuteRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ApplyGameplayEffectRequest:
				return new CombatExactRequestDataPack(requestData.ApplyGameplayEffectRequest, messageCase);
			case CombatRequestData.MessageOneofCase.RemoveGameplayEffectRequest:
				return new CombatExactRequestDataPack(requestData.RemoveGameplayEffectRequest, messageCase);
			case CombatRequestData.MessageOneofCase.HitRequest:
				return new CombatExactRequestDataPack(requestData.HitRequest, messageCase);
			case CombatRequestData.MessageOneofCase.HitEndRequest:
				return new CombatExactRequestDataPack(requestData.HitEndRequest, messageCase);
			case CombatRequestData.MessageOneofCase.SkillRequest:
				return new CombatExactRequestDataPack(requestData.SkillRequest, messageCase);
			case CombatRequestData.MessageOneofCase.UseSkillRequest:
				return new CombatExactRequestDataPack(requestData.UseSkillRequest, messageCase);
			case CombatRequestData.MessageOneofCase.EndSkillRequest:
				return new CombatExactRequestDataPack(requestData.EndSkillRequest, messageCase);
			case CombatRequestData.MessageOneofCase.PartUpdateRequest:
				return new CombatExactRequestDataPack(requestData.PartUpdateRequest, messageCase);
			case CombatRequestData.MessageOneofCase.MaterialRequest:
				return new CombatExactRequestDataPack(requestData.MaterialRequest, messageCase);
			case CombatRequestData.MessageOneofCase.GameplayCueRequest:
				return new CombatExactRequestDataPack(requestData.GameplayCueRequest, messageCase);
			case CombatRequestData.MessageOneofCase.EntityIsVisibleRequest:
				return new CombatExactRequestDataPack(requestData.EntityIsVisibleRequest, messageCase);
			case CombatRequestData.MessageOneofCase.SwitchCharacterStateRequest:
				return new CombatExactRequestDataPack(requestData.SwitchCharacterStateRequest, messageCase);
			case CombatRequestData.MessageOneofCase.LogicStateInitRequest:
				return new CombatExactRequestDataPack(requestData.LogicStateInitRequest, messageCase);
			case CombatRequestData.MessageOneofCase.SwitchLogicStateRequest:
				return new CombatExactRequestDataPack(requestData.SwitchLogicStateRequest, messageCase);
			case CombatRequestData.MessageOneofCase.AnimationStateChangedRequest:
				return new CombatExactRequestDataPack(requestData.AnimationStateChangedRequest, messageCase);
			case CombatRequestData.MessageOneofCase.AnimationStateInitRequest:
				return new CombatExactRequestDataPack(requestData.AnimationStateInitRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ModifyBulletParamsRequest:
				return new CombatExactRequestDataPack(requestData.ModifyBulletParamsRequest, messageCase);
			case CombatRequestData.MessageOneofCase.DrownRequest:
				return new CombatExactRequestDataPack(requestData.DrownRequest, messageCase);
			case CombatRequestData.MessageOneofCase.OrderApplyBuffRequest:
				return new CombatExactRequestDataPack(requestData.OrderApplyBuffRequest, messageCase);
			case CombatRequestData.MessageOneofCase.OrderRemoveBuffRequest:
				return new CombatExactRequestDataPack(requestData.OrderRemoveBuffRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ActivateBuffRequest:
				return new CombatExactRequestDataPack(requestData.ActivateBuffRequest, messageCase);
			case CombatRequestData.MessageOneofCase.OrderRemoveBuffByTagsRequest:
				return new CombatExactRequestDataPack(requestData.OrderRemoveBuffByTagsRequest, messageCase);
			case CombatRequestData.MessageOneofCase.AiInformationRequest:
				return new CombatExactRequestDataPack(requestData.AiInformationRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ToughCalcExtraRatioChangeRequest:
				return new CombatExactRequestDataPack(requestData.ToughCalcExtraRatioChangeRequest, messageCase);
			case CombatRequestData.MessageOneofCase.BattleStateChangeRequest:
				return new CombatExactRequestDataPack(requestData.BattleStateChangeRequest, messageCase);
			case CombatRequestData.MessageOneofCase.AnimationGameplayTagRequest:
				return new CombatExactRequestDataPack(requestData.AnimationGameplayTagRequest, messageCase);
			case CombatRequestData.MessageOneofCase.BoneVisibleChangeRequest:
				return new CombatExactRequestDataPack(requestData.BoneVisibleChangeRequest, messageCase);
			case CombatRequestData.MessageOneofCase.AiBlackboardsRequest:
				return new CombatExactRequestDataPack(requestData.AiBlackboardsRequest, messageCase);
			case CombatRequestData.MessageOneofCase.AiBlackboardCdRequest:
				return new CombatExactRequestDataPack(requestData.AiBlackboardCdRequest, messageCase);
			case CombatRequestData.MessageOneofCase.AiHateRequest:
				return new CombatExactRequestDataPack(requestData.AiHateRequest, messageCase);
			case CombatRequestData.MessageOneofCase.MonsterBoomRequest:
				return new CombatExactRequestDataPack(requestData.MonsterBoomRequest, messageCase);
			case CombatRequestData.MessageOneofCase.CaughtRequest:
				return new CombatExactRequestDataPack(requestData.CaughtRequest, messageCase);
			case CombatRequestData.MessageOneofCase.EntityStaticHookMoveRequest:
				return new CombatExactRequestDataPack(requestData.EntityStaticHookMoveRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ChangeStateRequest:
				return new CombatExactRequestDataPack(requestData.ChangeStateRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ChangeStateConfirmRequest:
				return new CombatExactRequestDataPack(requestData.ChangeStateConfirmRequest, messageCase);
			case CombatRequestData.MessageOneofCase.FsmConditionPassRequest:
				return new CombatExactRequestDataPack(requestData.FsmConditionPassRequest, messageCase);
			case CombatRequestData.MessageOneofCase.BuffStackCountRequest:
				return new CombatExactRequestDataPack(requestData.BuffStackCountRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ANStartRequest:
				return new CombatExactRequestDataPack(requestData.ANStartRequest, messageCase);
			case CombatRequestData.MessageOneofCase.UseSkillFailRequest:
				return new CombatExactRequestDataPack(requestData.UseSkillFailRequest, messageCase);
			case CombatRequestData.MessageOneofCase.EnterViewDirectionRequest:
				return new CombatExactRequestDataPack(requestData.EnterViewDirectionRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ExitViewDirectionRequest:
				return new CombatExactRequestDataPack(requestData.ExitViewDirectionRequest, messageCase);
			case CombatRequestData.MessageOneofCase.PassiveSkillAddRequest:
				return new CombatExactRequestDataPack(requestData.PassiveSkillAddRequest, messageCase);
			case CombatRequestData.MessageOneofCase.InterruptSkillInDelayRequest:
				return new CombatExactRequestDataPack(requestData.InterruptSkillInDelayRequest, messageCase);
			case CombatRequestData.MessageOneofCase.TriggerExitSkillRequest:
				return new CombatExactRequestDataPack(requestData.TriggerExitSkillRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ActorVisibleRequest:
				return new CombatExactRequestDataPack(requestData.ActorVisibleRequest, messageCase);
			case CombatRequestData.MessageOneofCase.BuffEffectRequest:
				return new CombatExactRequestDataPack(requestData.BuffEffectRequest, messageCase);
			case CombatRequestData.MessageOneofCase.FragileChangeRequest:
				return new CombatExactRequestDataPack(requestData.FragileChangeRequest, messageCase);
			case CombatRequestData.MessageOneofCase.RTimeStopRequest:
				return new CombatExactRequestDataPack(requestData.RTimeStopRequest, messageCase);
			case CombatRequestData.MessageOneofCase.DrownEndTeleportRequest:
				return new CombatExactRequestDataPack(requestData.DrownEndTeleportRequest, messageCase);
			case CombatRequestData.MessageOneofCase.MonsterDrownRequest:
				return new CombatExactRequestDataPack(requestData.MonsterDrownRequest, messageCase);
			case CombatRequestData.MessageOneofCase.PassiveSkillRemoveRequest:
				return new CombatExactRequestDataPack(requestData.PassiveSkillRemoveRequest, messageCase);
			case CombatRequestData.MessageOneofCase.RTimeStopInstRequest:
				return new CombatExactRequestDataPack(requestData.RTimeStopInstRequest, messageCase);
			case CombatRequestData.MessageOneofCase.FsmStateBehaviorRequest:
				return new CombatExactRequestDataPack(requestData.FsmStateBehaviorRequest, messageCase);
			case CombatRequestData.MessageOneofCase.FsmPlayMontageRequest:
				return new CombatExactRequestDataPack(requestData.FsmPlayMontageRequest, messageCase);
			case CombatRequestData.MessageOneofCase.RTimeStopAnimRequest:
				return new CombatExactRequestDataPack(requestData.RTimeStopAnimRequest, messageCase);
			case CombatRequestData.MessageOneofCase.SwitchRoleRequest:
				return new CombatExactRequestDataPack(requestData.SwitchRoleRequest, messageCase);
			case CombatRequestData.MessageOneofCase.GameplayTagRequest:
				return new CombatExactRequestDataPack(requestData.GameplayTagRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ExecuteQteRequest:
				return new CombatExactRequestDataPack(requestData.ExecuteQteRequest, messageCase);
			case CombatRequestData.MessageOneofCase.CombineEntitiesRequest:
				return new CombatExactRequestDataPack(requestData.CombineEntitiesRequest, messageCase);
			case CombatRequestData.MessageOneofCase.DissolveCombineRelationRequest:
				return new CombatExactRequestDataPack(requestData.DissolveCombineRelationRequest, messageCase);
			case CombatRequestData.MessageOneofCase.ClientCurrentRoleReportRequest:
				return new CombatExactRequestDataPack(requestData.ClientCurrentRoleReportRequest, messageCase);
			case CombatRequestData.MessageOneofCase.GaSwitchCommonEnemyProCampRequest:
				return new CombatExactRequestDataPack(requestData.GaSwitchCommonEnemyProCampRequest, messageCase);
			case CombatRequestData.MessageOneofCase.CombatMaxCaseMessageRequest:
				return new CombatExactRequestDataPack(requestData.CombatMaxCaseMessageRequest, messageCase);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CombatInfo;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "未处理的CombatRequest消息类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MessageType", messageCase);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603CE13 RID: 249363 RVA: 0x00F75960 File Offset: 0x00F73B60
		[return: Nullable(2)]
		public static CombatExactResponseDataPack GetExactResponseDataPack(this CombatResponseData responseData)
		{
			CombatResponseData.MessageOneofCase messageCase = responseData.MessageCase;
			switch (messageCase)
			{
			case CombatResponseData.MessageOneofCase.None:
				return null;
			case CombatResponseData.MessageOneofCase.CreateBulletResponse:
				return new CombatExactResponseDataPack(responseData.CreateBulletResponse, messageCase);
			case CombatResponseData.MessageOneofCase.DestroyBulletResponse:
				return new CombatExactResponseDataPack(responseData.DestroyBulletResponse, messageCase);
			case CombatResponseData.MessageOneofCase.DamageExecuteResponse:
				return new CombatExactResponseDataPack(responseData.DamageExecuteResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ApplyGameplayEffectResponse:
				return new CombatExactResponseDataPack(responseData.ApplyGameplayEffectResponse, messageCase);
			case CombatResponseData.MessageOneofCase.RemoveGameplayEffectResponse:
				return new CombatExactResponseDataPack(responseData.RemoveGameplayEffectResponse, messageCase);
			case CombatResponseData.MessageOneofCase.HitResponse:
				return new CombatExactResponseDataPack(responseData.HitResponse, messageCase);
			case CombatResponseData.MessageOneofCase.HitEndResponse:
				return new CombatExactResponseDataPack(responseData.HitEndResponse, messageCase);
			case CombatResponseData.MessageOneofCase.SkillResponse:
				return new CombatExactResponseDataPack(responseData.SkillResponse, messageCase);
			case CombatResponseData.MessageOneofCase.UseSkillResponse:
				return new CombatExactResponseDataPack(responseData.UseSkillResponse, messageCase);
			case CombatResponseData.MessageOneofCase.EndSkillResponse:
				return new CombatExactResponseDataPack(responseData.EndSkillResponse, messageCase);
			case CombatResponseData.MessageOneofCase.PartUpdateResponse:
				return new CombatExactResponseDataPack(responseData.PartUpdateResponse, messageCase);
			case CombatResponseData.MessageOneofCase.MaterialResponse:
				return new CombatExactResponseDataPack(responseData.MaterialResponse, messageCase);
			case CombatResponseData.MessageOneofCase.GameplayCueResponse:
				return new CombatExactResponseDataPack(responseData.GameplayCueResponse, messageCase);
			case CombatResponseData.MessageOneofCase.EntityIsVisibleResponse:
				return new CombatExactResponseDataPack(responseData.EntityIsVisibleResponse, messageCase);
			case CombatResponseData.MessageOneofCase.SwitchCharacterStateResponse:
				return new CombatExactResponseDataPack(responseData.SwitchCharacterStateResponse, messageCase);
			case CombatResponseData.MessageOneofCase.LogicStateInitResponse:
				return new CombatExactResponseDataPack(responseData.LogicStateInitResponse, messageCase);
			case CombatResponseData.MessageOneofCase.SwitchLogicStateResponse:
				return new CombatExactResponseDataPack(responseData.SwitchLogicStateResponse, messageCase);
			case CombatResponseData.MessageOneofCase.AnimationStateChangedResponse:
				return new CombatExactResponseDataPack(responseData.AnimationStateChangedResponse, messageCase);
			case CombatResponseData.MessageOneofCase.AnimationStateInitResponse:
				return new CombatExactResponseDataPack(responseData.AnimationStateInitResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ModifyBulletParamsResponse:
				return new CombatExactResponseDataPack(responseData.ModifyBulletParamsResponse, messageCase);
			case CombatResponseData.MessageOneofCase.DrownResponse:
				return new CombatExactResponseDataPack(responseData.DrownResponse, messageCase);
			case CombatResponseData.MessageOneofCase.OrderApplyBuffResponse:
				return new CombatExactResponseDataPack(responseData.OrderApplyBuffResponse, messageCase);
			case CombatResponseData.MessageOneofCase.OrderRemoveBuffResponse:
				return new CombatExactResponseDataPack(responseData.OrderRemoveBuffResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ActivateBuffResponse:
				return new CombatExactResponseDataPack(responseData.ActivateBuffResponse, messageCase);
			case CombatResponseData.MessageOneofCase.OrderRemoveBuffByTagsResponse:
				return new CombatExactResponseDataPack(responseData.OrderRemoveBuffByTagsResponse, messageCase);
			case CombatResponseData.MessageOneofCase.AiInformationResponse:
				return new CombatExactResponseDataPack(responseData.AiInformationResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ToughCalcExtraRatioChangeResponse:
				return new CombatExactResponseDataPack(responseData.ToughCalcExtraRatioChangeResponse, messageCase);
			case CombatResponseData.MessageOneofCase.BattleStateChangeResponse:
				return new CombatExactResponseDataPack(responseData.BattleStateChangeResponse, messageCase);
			case CombatResponseData.MessageOneofCase.AnimationGameplayTagResponse:
				return new CombatExactResponseDataPack(responseData.AnimationGameplayTagResponse, messageCase);
			case CombatResponseData.MessageOneofCase.BoneVisibleChangeResponse:
				return new CombatExactResponseDataPack(responseData.BoneVisibleChangeResponse, messageCase);
			case CombatResponseData.MessageOneofCase.AiBlackboardsResponse:
				return new CombatExactResponseDataPack(responseData.AiBlackboardsResponse, messageCase);
			case CombatResponseData.MessageOneofCase.AiBlackboardCdResponse:
				return new CombatExactResponseDataPack(responseData.AiBlackboardCdResponse, messageCase);
			case CombatResponseData.MessageOneofCase.AiHateResponse:
				return new CombatExactResponseDataPack(responseData.AiHateResponse, messageCase);
			case CombatResponseData.MessageOneofCase.MonsterBoomResponse:
				return new CombatExactResponseDataPack(responseData.MonsterBoomResponse, messageCase);
			case CombatResponseData.MessageOneofCase.CaughtResponse:
				return new CombatExactResponseDataPack(responseData.CaughtResponse, messageCase);
			case CombatResponseData.MessageOneofCase.EntityStaticHookMoveResponse:
				return new CombatExactResponseDataPack(responseData.EntityStaticHookMoveResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ChangeStateResponse:
				return new CombatExactResponseDataPack(responseData.ChangeStateResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ChangeStateConfirmResponse:
				return new CombatExactResponseDataPack(responseData.ChangeStateConfirmResponse, messageCase);
			case CombatResponseData.MessageOneofCase.FsmConditionPassResponse:
				return new CombatExactResponseDataPack(responseData.FsmConditionPassResponse, messageCase);
			case CombatResponseData.MessageOneofCase.BuffStackCountResponse:
				return new CombatExactResponseDataPack(responseData.BuffStackCountResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ANStartResponse:
				return new CombatExactResponseDataPack(responseData.ANStartResponse, messageCase);
			case CombatResponseData.MessageOneofCase.UseSkillFailResponse:
				return new CombatExactResponseDataPack(responseData.UseSkillFailResponse, messageCase);
			case CombatResponseData.MessageOneofCase.EnterViewDirectionResponse:
				return new CombatExactResponseDataPack(responseData.EnterViewDirectionResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ExitViewDirectionResponse:
				return new CombatExactResponseDataPack(responseData.ExitViewDirectionResponse, messageCase);
			case CombatResponseData.MessageOneofCase.PassiveSkillAddResponse:
				return new CombatExactResponseDataPack(responseData.PassiveSkillAddResponse, messageCase);
			case CombatResponseData.MessageOneofCase.InterruptSkillInDelayResponse:
				return new CombatExactResponseDataPack(responseData.InterruptSkillInDelayResponse, messageCase);
			case CombatResponseData.MessageOneofCase.TriggerExitSkillResponse:
				return new CombatExactResponseDataPack(responseData.TriggerExitSkillResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ActorVisibleResponse:
				return new CombatExactResponseDataPack(responseData.ActorVisibleResponse, messageCase);
			case CombatResponseData.MessageOneofCase.BuffEffectResponse:
				return new CombatExactResponseDataPack(responseData.BuffEffectResponse, messageCase);
			case CombatResponseData.MessageOneofCase.FragileChangeResponse:
				return new CombatExactResponseDataPack(responseData.FragileChangeResponse, messageCase);
			case CombatResponseData.MessageOneofCase.RTimeStopResponse:
				return new CombatExactResponseDataPack(responseData.RTimeStopResponse, messageCase);
			case CombatResponseData.MessageOneofCase.DrownEndTeleportResponse:
				return new CombatExactResponseDataPack(responseData.DrownEndTeleportResponse, messageCase);
			case CombatResponseData.MessageOneofCase.MonsterDrownResponse:
				return new CombatExactResponseDataPack(responseData.MonsterDrownResponse, messageCase);
			case CombatResponseData.MessageOneofCase.PassiveSkillRemoveResponse:
				return new CombatExactResponseDataPack(responseData.PassiveSkillRemoveResponse, messageCase);
			case CombatResponseData.MessageOneofCase.RTimeStopInstResponse:
				return new CombatExactResponseDataPack(responseData.RTimeStopInstResponse, messageCase);
			case CombatResponseData.MessageOneofCase.FsmStateBehaviorResponse:
				return new CombatExactResponseDataPack(responseData.FsmStateBehaviorResponse, messageCase);
			case CombatResponseData.MessageOneofCase.FsmPlayMontageResponse:
				return new CombatExactResponseDataPack(responseData.FsmPlayMontageResponse, messageCase);
			case CombatResponseData.MessageOneofCase.RTimeStopAnimResponse:
				return new CombatExactResponseDataPack(responseData.RTimeStopAnimResponse, messageCase);
			case CombatResponseData.MessageOneofCase.SwitchRoleResponse:
				return new CombatExactResponseDataPack(responseData.SwitchRoleResponse, messageCase);
			case CombatResponseData.MessageOneofCase.GameplayTagResponse:
				return new CombatExactResponseDataPack(responseData.GameplayTagResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ExecuteQteResponse:
				return new CombatExactResponseDataPack(responseData.ExecuteQteResponse, messageCase);
			case CombatResponseData.MessageOneofCase.CombineEntitiesResponse:
				return new CombatExactResponseDataPack(responseData.CombineEntitiesResponse, messageCase);
			case CombatResponseData.MessageOneofCase.DissolveCombineRelationResponse:
				return new CombatExactResponseDataPack(responseData.DissolveCombineRelationResponse, messageCase);
			case CombatResponseData.MessageOneofCase.ClientCurrentRoleReportResponse:
				return new CombatExactResponseDataPack(responseData.ClientCurrentRoleReportResponse, messageCase);
			case CombatResponseData.MessageOneofCase.GaSwitchCommonEnemyProCampResponse:
				return new CombatExactResponseDataPack(responseData.GaSwitchCommonEnemyProCampResponse, messageCase);
			case CombatResponseData.MessageOneofCase.CombatDataMaxResponse:
				return new CombatExactResponseDataPack(responseData.CombatDataMaxResponse, messageCase);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CombatInfo;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "未处理的CombatResponse消息类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MessageType", messageCase);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603CE14 RID: 249364 RVA: 0x00F75EA0 File Offset: 0x00F740A0
		public static void SetPushDataMessage(CombatPushData pushData, ECombatPushDataMessage messageType, IMessage data)
		{
			if (messageType <= ECombatPushDataMessage.FsmConditionPassPush)
			{
				if (messageType <= ECombatPushDataMessage.HitEndPush)
				{
					if (messageType <= ECombatPushDataMessage.TriggerExitSkillPush)
					{
						if (messageType <= ECombatPushDataMessage.PartUpdatePush)
						{
							if (messageType <= ECombatPushDataMessage.BeforeHitPush)
							{
								if (messageType == ECombatPushDataMessage.AnimationStateInitPush)
								{
									pushData.AnimationStateInitPush = (data as AnimationStateInitPush);
									return;
								}
								if (messageType == ECombatPushDataMessage.BeforeHitPush)
								{
									pushData.BeforeHitPush = (data as BeforeHitPush);
									return;
								}
							}
							else
							{
								if (messageType == ECombatPushDataMessage.RoleGoDownPush)
								{
									pushData.RoleGoDownPush = (data as RoleGoDownPush);
									return;
								}
								if (messageType == ECombatPushDataMessage.PartUpdatePush)
								{
									pushData.PartUpdatePush = (data as PartUpdatePush);
									return;
								}
							}
						}
						else if (messageType <= ECombatPushDataMessage.ActorVisiblePush)
						{
							if (messageType == ECombatPushDataMessage.BattleStateChangePush)
							{
								pushData.BattleStateChangePush = (data as BattleStateChangePush);
								return;
							}
							if (messageType == ECombatPushDataMessage.ActorVisiblePush)
							{
								pushData.ActorVisiblePush = (data as ActorVisiblePush);
								return;
							}
						}
						else
						{
							if (messageType == ECombatPushDataMessage.RefreshBuffDurationPush)
							{
								pushData.RefreshBuffDurationPush = (data as RefreshBuffDurationPush);
								return;
							}
							if (messageType == ECombatPushDataMessage.TriggerExitSkillPush)
							{
								pushData.TriggerExitSkillPush = (data as TriggerExitSkillPush);
								return;
							}
						}
					}
					else if (messageType <= ECombatPushDataMessage.QuickHackRamVerifyPush)
					{
						if (messageType <= ECombatPushDataMessage.MonsterDrownPush)
						{
							if (messageType == ECombatPushDataMessage.BuffEffectPush)
							{
								pushData.BuffEffectPush = (data as BuffEffectPush);
								return;
							}
							if (messageType == ECombatPushDataMessage.MonsterDrownPush)
							{
								pushData.MonsterDrownPush = (data as MonsterDrownPush);
								return;
							}
						}
						else
						{
							if (messageType == ECombatPushDataMessage.DrownPush)
							{
								pushData.DrownPush = (data as DrownPush);
								return;
							}
							if (messageType == ECombatPushDataMessage.QuickHackRamVerifyPush)
							{
								pushData.QuickHackRamVerifyPush = (data as QuickHackRamVerifyPush);
								return;
							}
						}
					}
					else if (messageType <= ECombatPushDataMessage.DrownEndTeleportPush)
					{
						if (messageType == ECombatPushDataMessage.ExitViewDirectionPush)
						{
							pushData.ExitViewDirectionPush = (data as ExitViewDirectionPush);
							return;
						}
						if (messageType == ECombatPushDataMessage.DrownEndTeleportPush)
						{
							pushData.DrownEndTeleportPush = (data as DrownEndTeleportPush);
							return;
						}
					}
					else
					{
						if (messageType == ECombatPushDataMessage.SwitchCharacterStatePush)
						{
							pushData.SwitchCharacterStatePush = (data as SwitchCharacterStatePush);
							return;
						}
						if (messageType == ECombatPushDataMessage.HitEndPush)
						{
							pushData.HitEndPush = (data as HitEndPush);
							return;
						}
					}
				}
				else if (messageType <= ECombatPushDataMessage.ModifyBulletParamsPush)
				{
					if (messageType <= ECombatPushDataMessage.MotorIsEnablePush)
					{
						if (messageType <= ECombatPushDataMessage.RTimeStopInstPush)
						{
							if (messageType == ECombatPushDataMessage.EntityIsVisiblePush)
							{
								pushData.EntityIsVisiblePush = (data as EntityIsVisiblePush);
								return;
							}
							if (messageType == ECombatPushDataMessage.RTimeStopInstPush)
							{
								pushData.RTimeStopInstPush = (data as RTimeStopInstPush);
								return;
							}
						}
						else
						{
							if (messageType == ECombatPushDataMessage.InterruptSkillInDelayPush)
							{
								pushData.InterruptSkillInDelayPush = (data as InterruptSkillInDelayPush);
								return;
							}
							if (messageType == ECombatPushDataMessage.MotorIsEnablePush)
							{
								pushData.MotorIsEnablePush = (data as MotorIsEnablePush);
								return;
							}
						}
					}
					else if (messageType <= ECombatPushDataMessage.EndSkillPush)
					{
						if (messageType == ECombatPushDataMessage.AiBlackboardsPush)
						{
							pushData.AiBlackboardsPush = (data as AiBlackboardsPush);
							return;
						}
						if (messageType == ECombatPushDataMessage.EndSkillPush)
						{
							pushData.EndSkillPush = (data as EndSkillPush);
							return;
						}
					}
					else
					{
						if (messageType == ECombatPushDataMessage.QuickHackOpenPush)
						{
							pushData.QuickHackOpenPush = (data as QuickHackOpenPush);
							return;
						}
						if (messageType == ECombatPushDataMessage.ModifyBulletParamsPush)
						{
							pushData.ModifyBulletParamsPush = (data as ModifyBulletParamsPush);
							return;
						}
					}
				}
				else if (messageType <= ECombatPushDataMessage.GameplayCuePush)
				{
					if (messageType <= ECombatPushDataMessage.ToughCalcExtraRatioChangePush)
					{
						if (messageType == ECombatPushDataMessage.AnimationGameplayTagPush)
						{
							pushData.AnimationGameplayTagPush = (data as AnimationGameplayTagPush);
							return;
						}
						if (messageType == ECombatPushDataMessage.ToughCalcExtraRatioChangePush)
						{
							pushData.ToughCalcExtraRatioChangePush = (data as ToughCalcExtraRatioChangePush);
							return;
						}
					}
					else
					{
						if (messageType == ECombatPushDataMessage.SwitchLogicStatePush)
						{
							pushData.SwitchLogicStatePush = (data as SwitchLogicStatePush);
							return;
						}
						if (messageType == ECombatPushDataMessage.GameplayCuePush)
						{
							pushData.GameplayCuePush = (data as GameplayCuePush);
							return;
						}
					}
				}
				else if (messageType <= ECombatPushDataMessage.FsmPlayMontagePush)
				{
					if (messageType == ECombatPushDataMessage.AiHatePush)
					{
						pushData.AiHatePush = (data as AiHatePush);
						return;
					}
					if (messageType == ECombatPushDataMessage.FsmPlayMontagePush)
					{
						pushData.FsmPlayMontagePush = (data as FsmPlayMontagePush);
						return;
					}
				}
				else
				{
					if (messageType == ECombatPushDataMessage.CaughtPush)
					{
						pushData.CaughtPush = (data as CaughtPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.DestroyBulletPush)
					{
						pushData.DestroyBulletPush = (data as DestroyBulletPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.FsmConditionPassPush)
					{
						pushData.FsmConditionPassPush = (data as FsmConditionPassPush);
						return;
					}
				}
			}
			else if (messageType <= ECombatPushDataMessage.MaterialPush)
			{
				if (messageType <= ECombatPushDataMessage.ActivateBuffPush)
				{
					if (messageType <= ECombatPushDataMessage.ExecuteQtePush)
					{
						if (messageType <= ECombatPushDataMessage.CreateBulletPush)
						{
							if (messageType == ECombatPushDataMessage.ApplyGameplayEffectPush)
							{
								pushData.ApplyGameplayEffectPush = (data as ApplyGameplayEffectPush);
								return;
							}
							if (messageType == ECombatPushDataMessage.CreateBulletPush)
							{
								pushData.CreateBulletPush = (data as CreateBulletPush);
								return;
							}
						}
						else
						{
							if (messageType == ECombatPushDataMessage.VisionTriggerPush)
							{
								pushData.VisionTriggerPush = (data as VisionTriggerPush);
								return;
							}
							if (messageType == ECombatPushDataMessage.ExecuteQtePush)
							{
								pushData.ExecuteQtePush = (data as ExecuteQtePush);
								return;
							}
						}
					}
					else if (messageType <= ECombatPushDataMessage.RTimeStopAnimPush)
					{
						if (messageType == ECombatPushDataMessage.BoneVisibleChangePush)
						{
							pushData.BoneVisibleChangePush = (data as BoneVisibleChangePush);
							return;
						}
						if (messageType == ECombatPushDataMessage.RTimeStopAnimPush)
						{
							pushData.RTimeStopAnimPush = (data as RTimeStopAnimPush);
							return;
						}
					}
					else
					{
						if (messageType == ECombatPushDataMessage.ClientCurrentRoleReportPush)
						{
							pushData.ClientCurrentRoleReportPush = (data as ClientCurrentRoleReportPush);
							return;
						}
						if (messageType == ECombatPushDataMessage.ActivateBuffPush)
						{
							pushData.ActivateBuffPush = (data as ActivateBuffPush);
							return;
						}
					}
				}
				else if (messageType <= ECombatPushDataMessage.RemoveGameplayEffectPush)
				{
					if (messageType <= ECombatPushDataMessage.BuffStackCountPush)
					{
						if (messageType == ECombatPushDataMessage.BuffEffectExecutePush)
						{
							pushData.BuffEffectExecutePush = (data as BuffEffectExecutePush);
							return;
						}
						if (messageType == ECombatPushDataMessage.BuffStackCountPush)
						{
							pushData.BuffStackCountPush = (data as BuffStackCountPush);
							return;
						}
					}
					else
					{
						if (messageType == ECombatPushDataMessage.UseSkillFailPush)
						{
							pushData.UseSkillFailPush = (data as UseSkillFailPush);
							return;
						}
						if (messageType == ECombatPushDataMessage.RemoveGameplayEffectPush)
						{
							pushData.RemoveGameplayEffectPush = (data as RemoveGameplayEffectPush);
							return;
						}
					}
				}
				else if (messageType <= ECombatPushDataMessage.DodgeInfoPush)
				{
					if (messageType == ECombatPushDataMessage.RTimeStopPush)
					{
						pushData.RTimeStopPush = (data as RTimeStopPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.DodgeInfoPush)
					{
						pushData.DodgeInfoPush = (data as DodgeInfoPush);
						return;
					}
				}
				else
				{
					if (messageType == ECombatPushDataMessage.BulletPatternPush)
					{
						pushData.BulletPatternPush = (data as BulletPatternPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.RemoveBuffS2cResponsePush)
					{
						pushData.RemoveBuffS2CResponsePush = (data as RemoveBuffS2cResponsePush);
						return;
					}
					if (messageType == ECombatPushDataMessage.MaterialPush)
					{
						pushData.MaterialPush = (data as MaterialPush);
						return;
					}
				}
			}
			else if (messageType <= ECombatPushDataMessage.PassiveSkillRemovePush)
			{
				if (messageType <= ECombatPushDataMessage.MotorSummonAndRidePush)
				{
					if (messageType <= ECombatPushDataMessage.PlayEntityMontagePush)
					{
						if (messageType == ECombatPushDataMessage.EntityStaticHookMovePush)
						{
							pushData.EntityStaticHookMovePush = (data as EntityStaticHookMovePush);
							return;
						}
						if (messageType == ECombatPushDataMessage.PlayEntityMontagePush)
						{
							pushData.PlayEntityMontagePush = (data as PlayEntityMontagePush);
							return;
						}
					}
					else
					{
						if (messageType == ECombatPushDataMessage.ChangeStateConfirmPush)
						{
							pushData.ChangeStateConfirmPush = (data as ChangeStateConfirmPush);
							return;
						}
						if (messageType == ECombatPushDataMessage.MotorSummonAndRidePush)
						{
							pushData.MotorSummonAndRidePush = (data as MotorSummonAndRidePush);
							return;
						}
					}
				}
				else if (messageType <= ECombatPushDataMessage.ApplyBuffS2cResponsePush)
				{
					if (messageType == ECombatPushDataMessage.PassiveSkillAddPush)
					{
						pushData.PassiveSkillAddPush = (data as PassiveSkillAddPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.ApplyBuffS2cResponsePush)
					{
						pushData.ApplyBuffS2CResponsePush = (data as ApplyBuffS2cResponsePush);
						return;
					}
				}
				else
				{
					if (messageType == ECombatPushDataMessage.AiBlackboardCdPush)
					{
						pushData.AiBlackboardCdPush = (data as AiBlackboardCdPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.PassiveSkillRemovePush)
					{
						pushData.PassiveSkillRemovePush = (data as PassiveSkillRemovePush);
						return;
					}
				}
			}
			else if (messageType <= ECombatPushDataMessage.EnterViewDirectionPush)
			{
				if (messageType <= ECombatPushDataMessage.LogicStateInitPush)
				{
					if (messageType == ECombatPushDataMessage.AiInformationPush)
					{
						pushData.AiInformationPush = (data as AiInformationPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.LogicStateInitPush)
					{
						pushData.LogicStateInitPush = (data as LogicStateInitPush);
						return;
					}
				}
				else
				{
					if (messageType == ECombatPushDataMessage.GameplayTagPush)
					{
						pushData.GameplayTagPush = (data as GameplayTagPush);
						return;
					}
					if (messageType == ECombatPushDataMessage.EnterViewDirectionPush)
					{
						pushData.EnterViewDirectionPush = (data as EnterViewDirectionPush);
						return;
					}
				}
			}
			else if (messageType <= ECombatPushDataMessage.AnimationStateChangedPush)
			{
				if (messageType == ECombatPushDataMessage.RemoveBuffByIdS2cResponsePush)
				{
					pushData.RemoveBuffByIdS2CResponsePush = (data as RemoveBuffByIdS2cResponsePush);
					return;
				}
				if (messageType == ECombatPushDataMessage.AnimationStateChangedPush)
				{
					pushData.AnimationStateChangedPush = (data as AnimationStateChangedPush);
					return;
				}
			}
			else
			{
				if (messageType == ECombatPushDataMessage.NewLinkBurstPush)
				{
					pushData.NewLinkBurstPush = (data as NewLinkBurstPush);
					return;
				}
				if (messageType == ECombatPushDataMessage.ANStartPush)
				{
					pushData.ANStartPush = (data as ANStartPush);
					return;
				}
				if (messageType == ECombatPushDataMessage.MonsterBoomPush)
				{
					pushData.MonsterBoomPush = (data as MonsterBoomPush);
					return;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiplayerCombat;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "未处理的推送消息类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MessageType", messageType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603CE15 RID: 249365 RVA: 0x00F766D0 File Offset: 0x00F748D0
		public static void SetRequestDataMessage(CombatRequestData reqData, ECombatRequestDataMessage messageType, IMessage data)
		{
			if (messageType <= ECombatRequestDataMessage.CombineEntitiesRequest)
			{
				if (messageType <= ECombatRequestDataMessage.HitRequest)
				{
					if (messageType <= ECombatRequestDataMessage.SkillRequest)
					{
						if (messageType <= ECombatRequestDataMessage.BuffEffectRequest)
						{
							if (messageType <= ECombatRequestDataMessage.ActivateBuffRequest)
							{
								if (messageType == ECombatRequestDataMessage.AnimationStateChangedRequest)
								{
									reqData.AnimationStateChangedRequest = (data as AnimationStateChangedRequest);
									return;
								}
								if (messageType == ECombatRequestDataMessage.ActivateBuffRequest)
								{
									reqData.ActivateBuffRequest = (data as ActivateBuffRequest);
									return;
								}
							}
							else
							{
								if (messageType == ECombatRequestDataMessage.ExitViewDirectionRequest)
								{
									reqData.ExitViewDirectionRequest = (data as ExitViewDirectionRequest);
									return;
								}
								if (messageType == ECombatRequestDataMessage.BuffEffectRequest)
								{
									reqData.BuffEffectRequest = (data as BuffEffectRequest);
									return;
								}
							}
						}
						else if (messageType <= ECombatRequestDataMessage.GameplayTagRequest)
						{
							if (messageType == ECombatRequestDataMessage.BoneVisibleChangeRequest)
							{
								reqData.BoneVisibleChangeRequest = (data as BoneVisibleChangeRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.GameplayTagRequest)
							{
								reqData.GameplayTagRequest = (data as GameplayTagRequest);
								return;
							}
						}
						else
						{
							if (messageType == ECombatRequestDataMessage.AiBlackboardsRequest)
							{
								reqData.AiBlackboardsRequest = (data as AiBlackboardsRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.SkillRequest)
							{
								reqData.SkillRequest = (data as SkillRequest);
								return;
							}
						}
					}
					else if (messageType <= ECombatRequestDataMessage.ModifyBulletParamsRequest)
					{
						if (messageType <= ECombatRequestDataMessage.EntityStaticHookMoveRequest)
						{
							if (messageType == ECombatRequestDataMessage.DrownEndTeleportRequest)
							{
								reqData.DrownEndTeleportRequest = (data as DrownEndTeleportRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.EntityStaticHookMoveRequest)
							{
								reqData.EntityStaticHookMoveRequest = (data as EntityStaticHookMoveRequest);
								return;
							}
						}
						else
						{
							if (messageType == ECombatRequestDataMessage.ChangeStateRequest)
							{
								reqData.ChangeStateRequest = (data as ChangeStateRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.ModifyBulletParamsRequest)
							{
								reqData.ModifyBulletParamsRequest = (data as ModifyBulletParamsRequest);
								return;
							}
						}
					}
					else if (messageType <= ECombatRequestDataMessage.ToughCalcExtraRatioChangeRequest)
					{
						if (messageType == ECombatRequestDataMessage.UseSkillRequest)
						{
							reqData.UseSkillRequest = (data as UseSkillRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.ToughCalcExtraRatioChangeRequest)
						{
							reqData.ToughCalcExtraRatioChangeRequest = (data as ToughCalcExtraRatioChangeRequest);
							return;
						}
					}
					else
					{
						if (messageType == ECombatRequestDataMessage.ActorVisibleRequest)
						{
							reqData.ActorVisibleRequest = (data as ActorVisibleRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.HitRequest)
						{
							reqData.HitRequest = (data as HitRequest);
							return;
						}
					}
				}
				else if (messageType <= ECombatRequestDataMessage.MonsterDrownRequest)
				{
					if (messageType <= ECombatRequestDataMessage.SwitchCharacterStateRequest)
					{
						if (messageType <= ECombatRequestDataMessage.PassiveSkillRemoveRequest)
						{
							if (messageType == ECombatRequestDataMessage.LogicStateInitRequest)
							{
								reqData.LogicStateInitRequest = (data as LogicStateInitRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.PassiveSkillRemoveRequest)
							{
								reqData.PassiveSkillRemoveRequest = (data as PassiveSkillRemoveRequest);
								return;
							}
						}
						else
						{
							if (messageType == ECombatRequestDataMessage.TriggerExitSkillRequest)
							{
								reqData.TriggerExitSkillRequest = (data as TriggerExitSkillRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.SwitchCharacterStateRequest)
							{
								reqData.SwitchCharacterStateRequest = (data as SwitchCharacterStateRequest);
								return;
							}
						}
					}
					else if (messageType <= ECombatRequestDataMessage.FsmConditionPassRequest)
					{
						if (messageType == ECombatRequestDataMessage.DrownRequest)
						{
							reqData.DrownRequest = (data as DrownRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.FsmConditionPassRequest)
						{
							reqData.FsmConditionPassRequest = (data as FsmConditionPassRequest);
							return;
						}
					}
					else
					{
						if (messageType == ECombatRequestDataMessage.FsmPlayMontageRequest)
						{
							reqData.FsmPlayMontageRequest = (data as FsmPlayMontageRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.MonsterDrownRequest)
						{
							reqData.MonsterDrownRequest = (data as MonsterDrownRequest);
							return;
						}
					}
				}
				else if (messageType <= ECombatRequestDataMessage.CreateBulletRequest)
				{
					if (messageType <= ECombatRequestDataMessage.MaterialRequest)
					{
						if (messageType == ECombatRequestDataMessage.UseSkillFailRequest)
						{
							reqData.UseSkillFailRequest = (data as UseSkillFailRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.MaterialRequest)
						{
							reqData.MaterialRequest = (data as MaterialRequest);
							return;
						}
					}
					else
					{
						if (messageType == ECombatRequestDataMessage.AiHateRequest)
						{
							reqData.AiHateRequest = (data as AiHateRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.CreateBulletRequest)
						{
							reqData.CreateBulletRequest = (data as CreateBulletRequest);
							return;
						}
					}
				}
				else if (messageType <= ECombatRequestDataMessage.SwitchLogicStateRequest)
				{
					if (messageType == ECombatRequestDataMessage.GameplayCueRequest)
					{
						reqData.GameplayCueRequest = (data as GameplayCueRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.SwitchLogicStateRequest)
					{
						reqData.SwitchLogicStateRequest = (data as SwitchLogicStateRequest);
						return;
					}
				}
				else
				{
					if (messageType == ECombatRequestDataMessage.PartUpdateRequest)
					{
						reqData.PartUpdateRequest = (data as PartUpdateRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.RTimeStopAnimRequest)
					{
						reqData.RTimeStopAnimRequest = (data as RTimeStopAnimRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.CombineEntitiesRequest)
					{
						reqData.CombineEntitiesRequest = (data as CombineEntitiesRequest);
						return;
					}
				}
			}
			else if (messageType <= ECombatRequestDataMessage.ExecuteQteRequest)
			{
				if (messageType <= ECombatRequestDataMessage.GaSwitchCommonEnemyProCampRequest)
				{
					if (messageType <= ECombatRequestDataMessage.OrderRemoveBuffRequest)
					{
						if (messageType <= ECombatRequestDataMessage.ChangeStateConfirmRequest)
						{
							if (messageType == ECombatRequestDataMessage.EndSkillRequest)
							{
								reqData.EndSkillRequest = (data as EndSkillRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.ChangeStateConfirmRequest)
							{
								reqData.ChangeStateConfirmRequest = (data as ChangeStateConfirmRequest);
								return;
							}
						}
						else
						{
							if (messageType == ECombatRequestDataMessage.RemoveGameplayEffectRequest)
							{
								reqData.RemoveGameplayEffectRequest = (data as RemoveGameplayEffectRequest);
								return;
							}
							if (messageType == ECombatRequestDataMessage.OrderRemoveBuffRequest)
							{
								reqData.OrderRemoveBuffRequest = (data as OrderRemoveBuffRequest);
								return;
							}
						}
					}
					else if (messageType <= ECombatRequestDataMessage.SwitchRoleRequest)
					{
						if (messageType == ECombatRequestDataMessage.RTimeStopRequest)
						{
							reqData.RTimeStopRequest = (data as RTimeStopRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.SwitchRoleRequest)
						{
							reqData.SwitchRoleRequest = (data as SwitchRoleRequest);
							return;
						}
					}
					else
					{
						if (messageType == ECombatRequestDataMessage.DamageExecuteRequest)
						{
							reqData.DamageExecuteRequest = (data as DamageExecuteRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.GaSwitchCommonEnemyProCampRequest)
						{
							reqData.GaSwitchCommonEnemyProCampRequest = (data as GaSwitchCommonEnemyProCampRequest);
							return;
						}
					}
				}
				else if (messageType <= ECombatRequestDataMessage.PassiveSkillAddRequest)
				{
					if (messageType <= ECombatRequestDataMessage.DissolveCombineRelationRequest)
					{
						if (messageType == ECombatRequestDataMessage.DestroyBulletRequest)
						{
							reqData.DestroyBulletRequest = (data as DestroyBulletRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.DissolveCombineRelationRequest)
						{
							reqData.DissolveCombineRelationRequest = (data as DissolveCombineRelationRequest);
							return;
						}
					}
					else
					{
						if (messageType == ECombatRequestDataMessage.OrderRemoveBuffByTagsRequest)
						{
							reqData.OrderRemoveBuffByTagsRequest = (data as OrderRemoveBuffByTagsRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.PassiveSkillAddRequest)
						{
							reqData.PassiveSkillAddRequest = (data as PassiveSkillAddRequest);
							return;
						}
					}
				}
				else if (messageType <= ECombatRequestDataMessage.EntityIsVisibleRequest)
				{
					if (messageType == ECombatRequestDataMessage.RTimeStopInstRequest)
					{
						reqData.RTimeStopInstRequest = (data as RTimeStopInstRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.EntityIsVisibleRequest)
					{
						reqData.EntityIsVisibleRequest = (data as EntityIsVisibleRequest);
						return;
					}
				}
				else
				{
					if (messageType == ECombatRequestDataMessage.AiBlackboardCdRequest)
					{
						reqData.AiBlackboardCdRequest = (data as AiBlackboardCdRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.ExecuteQteRequest)
					{
						reqData.ExecuteQteRequest = (data as ExecuteQteRequest);
						return;
					}
				}
			}
			else if (messageType <= ECombatRequestDataMessage.FragileChangeRequest)
			{
				if (messageType <= ECombatRequestDataMessage.InterruptSkillInDelayRequest)
				{
					if (messageType <= ECombatRequestDataMessage.BuffStackCountRequest)
					{
						if (messageType == ECombatRequestDataMessage.EnterViewDirectionRequest)
						{
							reqData.EnterViewDirectionRequest = (data as EnterViewDirectionRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.BuffStackCountRequest)
						{
							reqData.BuffStackCountRequest = (data as BuffStackCountRequest);
							return;
						}
					}
					else
					{
						if (messageType == ECombatRequestDataMessage.AiInformationRequest)
						{
							reqData.AiInformationRequest = (data as AiInformationRequest);
							return;
						}
						if (messageType == ECombatRequestDataMessage.InterruptSkillInDelayRequest)
						{
							reqData.InterruptSkillInDelayRequest = (data as InterruptSkillInDelayRequest);
							return;
						}
					}
				}
				else if (messageType <= ECombatRequestDataMessage.AnimationGameplayTagRequest)
				{
					if (messageType == ECombatRequestDataMessage.CombatMaxCaseMessageRequest)
					{
						reqData.CombatMaxCaseMessageRequest = (data as CombatMaxCaseMessageRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.AnimationGameplayTagRequest)
					{
						reqData.AnimationGameplayTagRequest = (data as AnimationGameplayTagRequest);
						return;
					}
				}
				else
				{
					if (messageType == ECombatRequestDataMessage.OrderApplyBuffRequest)
					{
						reqData.OrderApplyBuffRequest = (data as OrderApplyBuffRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.FragileChangeRequest)
					{
						reqData.FragileChangeRequest = (data as FragileChangeRequest);
						return;
					}
				}
			}
			else if (messageType <= ECombatRequestDataMessage.HitEndRequest)
			{
				if (messageType <= ECombatRequestDataMessage.BattleStateChangeRequest)
				{
					if (messageType == ECombatRequestDataMessage.ClientCurrentRoleReportRequest)
					{
						reqData.ClientCurrentRoleReportRequest = (data as ClientCurrentRoleReportRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.BattleStateChangeRequest)
					{
						reqData.BattleStateChangeRequest = (data as BattleStateChangeRequest);
						return;
					}
				}
				else
				{
					if (messageType == ECombatRequestDataMessage.ApplyGameplayEffectRequest)
					{
						reqData.ApplyGameplayEffectRequest = (data as ApplyGameplayEffectRequest);
						return;
					}
					if (messageType == ECombatRequestDataMessage.HitEndRequest)
					{
						reqData.HitEndRequest = (data as HitEndRequest);
						return;
					}
				}
			}
			else if (messageType <= ECombatRequestDataMessage.AnimationStateInitRequest)
			{
				if (messageType == ECombatRequestDataMessage.MonsterBoomRequest)
				{
					reqData.MonsterBoomRequest = (data as MonsterBoomRequest);
					return;
				}
				if (messageType == ECombatRequestDataMessage.AnimationStateInitRequest)
				{
					reqData.AnimationStateInitRequest = (data as AnimationStateInitRequest);
					return;
				}
			}
			else
			{
				if (messageType == ECombatRequestDataMessage.ANStartRequest)
				{
					reqData.ANStartRequest = (data as ANStartRequest);
					return;
				}
				if (messageType == ECombatRequestDataMessage.CaughtRequest)
				{
					reqData.CaughtRequest = (data as CaughtRequest);
					return;
				}
				if (messageType == ECombatRequestDataMessage.FsmStateBehaviorRequest)
				{
					reqData.FsmStateBehaviorRequest = (data as FsmStateBehaviorRequest);
					return;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiplayerCombat;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "未处理的请求消息类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MessageType", messageType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}
}
