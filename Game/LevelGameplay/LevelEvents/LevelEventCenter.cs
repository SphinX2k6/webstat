using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.LevelGamePlay.LevelConditions;
using CSharpScript.Game.LevelGamePlay.LevelEvents.DemoInteract;
using CSharpScript.Game.LevelGamePlay.LevelEvents.LevelplayCapability;
using CSharpScript.Game.LevelGamePlay.LevelEvents.SceneActorRef;
using CSharpScript.Game.LevelGamePlay.LevelEvents.Vehicle;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B71 RID: 27505
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventCenter
	{
		// Token: 0x06043ED0 RID: 278224 RVA: 0x01194833 File Offset: 0x01192A33
		private static void Init()
		{
			LevelEventCenter.TickEvents = new Dictionary<int, List<LevelEventBase>>();
			LevelEventCenter.WaitToRemoveList = new List<LevelEventBase>();
			LevelEventCenter.EventsMap = new Dictionary<string, List<LevelEventBase>>();
			LevelEventCenter.TickEventDefines = new HashSet<string>();
			LevelEventCenter.ExpendCapacityEvents = new Dictionary<string, Func<int, LevelEventBase>>();
			LevelEventCenter.EventCapacityMap = new Dictionary<string, int>();
		}

		// Token: 0x06043ED1 RID: 278225 RVA: 0x01194874 File Offset: 0x01192A74
		public static void RegistEvents()
		{
			LevelEventCenter.Init();
			LevelEventCenter.SetupEvent<LevelEventPlayerLoockAt>(EAction.PlayerLookAt.ToEnumString(), (int id) => new LevelEventPlayerLoockAt(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventCameraLookAtPosition>(EAction.CameraLookAt.ToEnumString(), (int id) => new LevelEventCameraLookAtPosition(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventRestoreCameraLookAtPosition>(EAction.StopCameraLookAt.ToEnumString(), (int id) => new LevelEventRestoreCameraLookAtPosition(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventCaptureRequest>("ActionCaptureRequest", (int id) => new LevelEventCaptureRequest(id), 8, false);
			LevelEventCenter.SetupEvent<LevelEventExecution>("ActionExecution", (int id) => new LevelEventExecution(id), 8, false);
			LevelEventCenter.SetupEvent<LevelEventBreakWeakness>("BreakWeakness", (int id) => new LevelEventBreakWeakness(id), 8, false);
			LevelEventCenter.SetupEvent<LevelEventSendGameplayEventToPlayer>("ActionSendGameplayEvent", (int id) => new LevelEventSendGameplayEventToPlayer(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSubmitQuestBehavior>("ActionSubmitQuestBehavior", (int id) => new LevelEventSubmitQuestBehavior(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventDeliverQuestBehavior>("ActionDeliverQuestBehavior", (int id) => new LevelEventDeliverQuestBehavior(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventLog>(EAction.Log.ToEnumString(), (int id) => new LevelEventLog(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventWaitTime>(EAction.Wait.ToEnumString(), (int id) => new LevelEventWaitTime(id), 8, true);
			LevelEventCenter.SetupEvent<LevelEventLeisureInteract>(EAction.LeisureInteract.ToEnumString(), (int id) => new LevelEventLeisureInteract(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventPrompt>(EAction.Prompt.ToEnumString(), (int id) => new LevelEventPrompt(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventGuideTrigger>(EAction.GuideTrigger.ToEnumString(), (int id) => new LevelEventGuideTrigger(id), 8, true);
			LevelEventCenter.SetupEvent<LevelEventCompleteGuide>(EAction.CompleteGuide.ToEnumString(), (int id) => new LevelEventCompleteGuide(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventOpenSystem>(EAction.OpenSystemBoard.ToEnumString(), (int id) => new LevelEventOpenSystem(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventAddBuffToEntity>(EAction.AddBuffToEntity.ToEnumString(), (int id) => new LevelEventAddBuffToEntity(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventAddBuffToPlayer>(EAction.AddBuffToPlayer.ToEnumString(), (int id) => new LevelEventAddBuffToPlayer(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventRemoveBuffFromCreature>(EAction.RemoveBuffFromEntity.ToEnumString(), (int id) => new LevelEventRemoveBuffFromCreature(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventForceLockOnSpecialTagTarget>(EAction.SetForceLock.ToEnumString(), (int id) => new LevelEventForceLockOnSpecialTagTarget(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetWuYinQuState>(EAction.SetWuYinQuState.ToEnumString(), (int id) => new LevelEventSetWuYinQuState(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetPlayerMoveControl>(EAction.SetPlayerMoveControl.ToEnumString(), (int id) => new LevelEventSetPlayerMoveControl(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSpawnEffect>(EAction.PlayEffect.ToEnumString(), (int id) => new LevelEventSpawnEffect(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSpawnEffectV2>(EAction.PlayEffect2.ToEnumString(), (int id) => new LevelEventSpawnEffectV2(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClaimLevelPlayReward>(EAction.ClaimLevelPlayReward.ToEnumString(), (int id) => new LevelEventClaimLevelPlayReward(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventOpenChapterUi>(EAction.PromptQuestChapterUI.ToEnumString(), (int id) => new LevelEventOpenChapterUi(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventInterludeActions>(EAction.InterludeActions.ToEnumString(), (int id) => new LevelEventInterludeActions(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventAddBuffToTriggeredEntity>(EAction.AddBuffToTriggeredEntity.ToEnumString(), (int id) => new LevelEventAddBuffToTriggeredEntity(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventAdjustTodTime>(EAction.SetTime.ToEnumString(), (int id) => new LevelEventAdjustTodTime(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSetBattleState>(EAction.SetBattleState.ToEnumString(), (int id) => new LevelEventSetBattleState(id), 4, true);
			LevelEventCenter.SetupEvent<LevelEventCheckBattleState>(EAction.WaitBattleCondition.ToEnumString(), (int id) => new LevelEventCheckBattleState(id), 8, false);
			LevelEventCenter.SetupEvent<LevelEventEnableHostility>(EAction.EnableHostility.ToEnumString(), (int id) => new LevelEventEnableHostility(id), 8, false);
			LevelEventCenter.SetupEvent<LevelEventRunAction>(EAction.RunActions.ToEnumString(), (int id) => new LevelEventRunAction(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventEntityLookAt>(EAction.EntityLookAt.ToEnumString(), (int id) => new LevelEventEntityLookAt(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventPrompt>(EAction.CommonTip.ToEnumString(), (int id) => new LevelEventPrompt(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEndPrompt>(EAction.EndCommonTip.ToEnumString(), (int id) => new LevelEventEndPrompt(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClaimDungeonReward>(EAction.ClaimDungeonReward.ToEnumString(), (int id) => new LevelEventClaimDungeonReward(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSpawnTraceEffect>(EAction.TraceSpline.ToEnumString(), (int id) => new LevelEventSpawnTraceEffect(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventToggleScanSplineEffect>(EAction.ToggleScanSplineEffect.ToEnumString(), (int id) => new LevelEventToggleScanSplineEffect(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPostAkEvent>(EAction.PostAkEvent.ToEnumString(), (int id) => new LevelEventPostAkEvent(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSceneItemMove>(EAction.MoveSceneItem.ToEnumString(), (int id) => new LevelEventSceneItemMove(id), 4, true);
			LevelEventCenter.SetupEvent<LevelEventStopSceneItemMove>(EAction.StopSceneItemMove.ToEnumString(), (int id) => new LevelEventStopSceneItemMove(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSendAiEvent>(EAction.SendAiEvent.ToEnumString(), (int id) => new LevelEventSendAiEvent(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventUnlockDungeonEntry>(EAction.UnlockDungeonEntry.ToEnumString(), (int id) => new LevelEventUnlockDungeonEntry(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTeleportDungeon>(EAction.TeleportDungeon.ToEnumString(), (int id) => new LevelEventTeleportDungeon(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventAddInputTag>(EAction.LimitPlayerOperation.ToEnumString(), (int id) => new LevelEventAddInputTag(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventRefreshInputTag>(EAction.UnLimitPlayerOperation.ToEnumString(), (int id) => new LevelEventRefreshInputTag(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClientModifyTargetTag>(EAction.ClientModifyTargetTag.ToEnumString(), (int id) => new LevelEventClientModifyTargetTag(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventFadeInScreen>(EAction.FadeInScreen.ToEnumString(), (int id) => new LevelEventFadeInScreen(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventFadeOutScreen>(EAction.FadeOutScreen.ToEnumString(), (int id) => new LevelEventFadeOutScreen(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventChangeToVision>(EAction.ChangePhantom.ToEnumString(), (int id) => new LevelEventChangeToVision(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventRestoreFromVision>(EAction.RestorePhantom.ToEnumString(), (int id) => new LevelEventRestoreFromVision(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventShowPlotPhoto>(EAction.TakePlotPhoto.ToEnumString(), (int id) => new LevelEventShowPlotPhoto(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventOpenSimpleGameplay>(EAction.OpenSimpleGameplay.ToEnumString(), (int id) => new LevelEventOpenSimpleGameplay(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSwitchLevels>(EAction.SwitchSubLevels.ToEnumString(), (int id) => new LevelEventSwitchLevels(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSetSubLevelsVisible>(EAction.ClientPreEnableSubLevels.ToEnumString(), (int id) => new LevelEventSetSubLevelsVisible(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventAdjustPlayerCamera>(EAction.AdjustPlayerCamera.ToEnumString(), (int id) => new LevelEventAdjustPlayerCamera(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSeparateCamera>(EAction.SetSubScreenMode.ToEnumString(), (int id) => new LevelEventSeparateCamera(id), 4, true);
			LevelEventCenter.SetupEvent<LevelEventAdjustPlayerCameraGravity>(EAction.AdjustPlayerCameraGravity.ToEnumString(), (int id) => new LevelEventAdjustPlayerCameraGravity(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventRestorePlayerCameraAdjustment>(EAction.RestorePlayerCameraAdjustment.ToEnumString(), (int id) => new LevelEventRestorePlayerCameraAdjustment(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventResetPlayerCameraFocus>(EAction.ResetPlayerCameraFocus.ToEnumString(), (int id) => new LevelEventResetPlayerCameraFocus(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnterMovieCamera>(EAction.EnterMovieCamera.ToEnumString(), (int id) => new LevelEventEnterMovieCamera(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventExitMovieCamera>(EAction.ExitMovieCamera.ToEnumString(), (int id) => new LevelEventExitMovieCamera(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventUsePhantomSkill>(EAction.UsePhantomSkill.ToEnumString(), (int id) => new LevelEventUsePhantomSkill(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnterOrbitalCamera>(EAction.EnterOrbitalCamera.ToEnumString(), (int id) => new LevelEventEnterOrbitalCamera(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventExitOrbitalCamera>(EAction.ExitOrbitalCamera.ToEnumString(), (int id) => new LevelEventExitOrbitalCamera(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnableSplineMoveModel>(EAction.EnableSplineMoveModel.ToEnumString(), (int id) => new LevelEventEnableSplineMoveModel(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSportsState>(EAction.SetSportsState.ToEnumString(), (int id) => new LevelEventSportsState(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetActorVisible>(EAction.EnableActor.ToEnumString(), (int id) => new LevelEventSetActorVisible(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPlayLevelSequence>(EAction.PlayLevelSequence.ToEnumString(), (int id) => new LevelEventPlayLevelSequence(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventModifyActorMaterial>(EAction.ModifyActorMaterial.ToEnumString(), (int id) => new LevelEventModifyActorMaterial(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventModifyActorMaterialParamBySplineProgress>(EAction.SpecialOpModifyActorMaterialParamBySplineProgress.ToEnumString(), (int id) => new LevelEventModifyActorMaterialParamBySplineProgress(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventModifyActorMedia>(EAction.ModifyActorMedia.ToEnumString(), (int id) => new LevelEventModifyActorMedia(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnableAi>(EAction.EnableAI.ToEnumString(), (int id) => new LevelEventEnableAi(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetExploreState>(EAction.SetExploreState.ToEnumString(), (int id) => new LevelEventSetExploreState(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventToggleAirWall>(EAction.ToggleAirWall.ToEnumString(), (int id) => new LevelEventToggleAirWall(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTriggerCameraShake>(EAction.TriggerCameraShake.ToEnumString(), (int id) => new LevelEventTriggerCameraShake(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventHideTargetRange>(EAction.HideTargetRange.ToEnumString(), (int id) => new LevelEventHideTargetRange(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventShowTargetRange>(EAction.ShowTargetRange.ToEnumString(), (int id) => new LevelEventShowTargetRange(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventExitDungeon>(EAction.ExitDungeon.ToEnumString(), (int id) => new LevelEventExitDungeon(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventToggleMapMarkState>(EAction.ToggleMapMarkState.ToEnumString(), (int id) => new LevelEventToggleMapMarkState(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventFocusOnMapMark>(EAction.FocusOnMapMark.ToEnumString(), (int id) => new LevelEventFocusOnMapMark(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSettlementDungeon>(EAction.SettlementDungeon.ToEnumString(), (int id) => new LevelEventSettlementDungeon(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventAddTrialCharacter>(EAction.AddTrialCharacter.ToEnumString(), (int id) => new LevelEventAddTrialCharacter(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSetPlayerOperation>(EAction.SetPlayerOperationRestriction.ToEnumString(), (int id) => new LevelEventSetPlayerOperation(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventChangePhantomFormation>(EAction.ChangePhantomFormation.ToEnumString(), (int id) => new LevelEventChangePhantomFormation(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventRestorePhantomFormation>(EAction.RestorePhantomFormation.ToEnumString(), (int id) => new LevelEventRestorePhantomFormation(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventChangeEntityPerformanceState>(EAction.ChangeEntityPrefabPerformance.ToEnumString(), (int id) => new LevelEventChangeEntityPerformanceState(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventMoveJigsawItem>(EAction.SetJigsawItem.ToEnumString(), (int id) => new LevelEventMoveJigsawItem(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPlayRegisteredMontage>(EAction.PlayRegisteredMontage.ToEnumString(), (int id) => new LevelEventPlayRegisteredMontage(id), 8, true);
			LevelEventCenter.SetupEvent<LevelEventHighlightExploreUi>(EAction.ToggleHighlightExploreUi.ToEnumString(), (int id) => new LevelEventHighlightExploreUi(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetRegionConfig>(EAction.SetRegionConfig.ToEnumString(), (int id) => new LevelEventSetRegionConfig(id), 4, true);
			LevelEventCenter.SetupEvent<LevelEventCollect>(EAction.Collect.ToEnumString(), (int id) => new LevelEventCollect(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPlayDynamicSettlement>(EAction.PlayDynamicSettlement.ToEnumString(), (int id) => new LevelEventPlayDynamicSettlement(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSetInteractionLockState>(EAction.SetInteractionLockState.ToEnumString(), (int id) => new LevelEventSetInteractionLockState(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetTeleControl>(EAction.SetTeleControl.ToEnumString(), (int id) => new LevelEventSetTeleControl(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventOpenQte>(EAction.OpenQte.ToEnumString(), (int id) => new LevelEventOpenQte(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPreload>(EAction.Preload.ToEnumString(), (int id) => new LevelEventPreload(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventRogueReceiveReward>(EAction.RogueReceiveReward.ToEnumString(), (int id) => new LevelEventRogueReceiveReward(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetClientEntityVisibleSave>(EAction.SetEntityClientVisibleSave.ToEnumString(), (int id) => new LevelEventSetClientEntityVisibleSave(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEntityTurnTo>(EAction.EntityTurnTo.ToEnumString(), (int id) => new LevelEventEntityTurnTo(id), 8, false);
			LevelEventCenter.SetupEvent<LevelEventGuestAnimation>(EAction.GuestOperateUiAnimation.ToEnumString(), (int id) => new LevelEventGuestAnimation(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTriggerSpecificScanEffect>(EAction.TriggerSpecificScanEffect.ToEnumString(), (int id) => new LevelEventTriggerSpecificScanEffect(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventExecClientBattleAction>(EAction.ExecClientBattleAction.ToEnumString(), (int id) => new LevelEventExecClientBattleAction(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSystemFunction>(EAction.OpenSystemFunction.ToEnumString(), (int id) => new LevelEventSystemFunction(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventStopUiScreenEffect>(EAction.StopUiScreenEffect.ToEnumString(), (int id) => new LevelEventStopUiScreenEffect(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventEnableKey4Func>(EAction.EnableKey4Func.ToEnumString(), (int id) => new LevelEventEnableKey4Func(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTriggerSystemRandomPlot>(EAction.TriggerSystemRandomPlot.ToEnumString(), (int id) => new LevelEventTriggerSystemRandomPlot(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetClientEntityVisible>(EAction.SetEntityClientVisible.ToEnumString(), (int id) => new LevelEventSetClientEntityVisible(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClientSetPlayerPos>(EAction.ClientSetPlayerPos.ToEnumString(), (int id) => new LevelEventClientSetPlayerPos(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClientTeleportVehicle>(EAction.ClientVehicleTeleport.ToEnumString(), (int id) => new LevelEventClientTeleportVehicle(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventLockEntity>(EAction.LockEntity.ToEnumString(), (int id) => new LevelEventLockEntity(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventUnlockEntity>(EAction.UnlockEntity.ToEnumString(), (int id) => new LevelEventUnlockEntity(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventDestroySelf>(EAction.DestroySelf.ToEnumString(), (int id) => new LevelEventDestroySelf(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventFakePlayerInput>(EAction.PlayerInput.ToEnumString(), (int id) => new LevelEventFakePlayerInput(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventStartRailSlide>(EAction.SlideRailStart.ToEnumString(), (int id) => new LevelEventStartRailSlide(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventStopRailSlide>(EAction.SlideRailEnd.ToEnumString(), (int id) => new LevelEventStopRailSlide(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSlidePerformStart>(EAction.SlidePerformStart.ToEnumString(), (int id) => new LevelEventSlidePerformStart(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClientChangeTeamPosition>(EAction.ClientChangeTeamPosition.ToEnumString(), (int id) => new LevelEventClientChangeTeamPosition(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSetAiBehaviorTree>(EAction.OverrideAiBehaviorTree.ToEnumString(), (int id) => new LevelEventSetAiBehaviorTree(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventResetAiBehaviorTree>(EAction.RestoreAiBehaviorTree.ToEnumString(), (int id) => new LevelEventResetAiBehaviorTree(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnableEntityLookAt>(EAction.EnableEntityLookAt.ToEnumString(), (int id) => new LevelEventEnableEntityLookAt(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventDisableEntityLookAt>(EAction.DisableEntityLookAt.ToEnumString(), (int id) => new LevelEventDisableEntityLookAt(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPlayWalkingOverlayMontage>(EAction.PlayWalkingOverlayMontage.ToEnumString(), (int id) => new LevelEventPlayWalkingOverlayMontage(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventCloseWalkingOverlayMontage>(EAction.CloseWalkingOverlayMontage.ToEnumString(), (int id) => new LevelEventCloseWalkingOverlayMontage(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventNpcLeisureInteract>(EAction.NpcLeisureInteract.ToEnumString(), (int id) => new LevelEventNpcLeisureInteract(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClientPlayFlow>(EAction.PlayFlow.ToEnumString(), (int id) => new LevelEventClientPlayFlow(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventChangeEntityState>(EAction.ChangeEntityState.ToEnumString(), (int id) => new LevelEventChangeEntityState(id), 4, true);
			LevelEventCenter.SetupEvent<LevelEventChangeSelfEntityState>(EAction.ChangeSelfEntityState.ToEnumString(), (int id) => new LevelEventChangeSelfEntityState(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventChangeNpcPerformState>(EAction.ChangeNpcPerformState.ToEnumString(), (int id) => new LevelEventChangeNpcPerformState(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSwitchDataLayers>(EAction.SwitchDataLayers.ToEnumString(), (int id) => new LevelEventSwitchDataLayers(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventWaitSceneRefEntityPlaySequence>(EAction.WaitUntilLevelSequenceReachMark.ToEnumString(), (int id) => new LevelEventWaitSceneRefEntityPlaySequence(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventTriggerDeadEyeMode>(EAction.TriggerDeadeyeMode.ToEnumString(), (int id) => new LevelEventTriggerDeadEyeMode(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSendClientEvent>(EAction.SendClientEvent.ToEnumString(), (int id) => new LevelEventSendClientEvent(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPlayerLookTowards>(EAction.PlayerLookTowards.ToEnumString(), (int id) => new LevelEventPlayerLookTowards(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTetrisThrowBlock>(EAction.TetrisThrowBlock.ToEnumString(), (int id) => new LevelEventTetrisThrowBlock(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTetrisGameComplete>(EAction.TetrisGameComplete.ToEnumString(), (int id) => new LevelEventTetrisGameComplete(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTetrisTriggerDelayFall>(EAction.TetrisTriggerDelayFall.ToEnumString(), (int id) => new LevelEventTetrisTriggerDelayFall(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnableTakePhotoClip>(EAction.EnableTakePhotoClip.ToEnumString(), (int id) => new LevelEventEnableTakePhotoClip(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetNpcPosition>("ActionSetNpcPosition", (int id) => new LevelEventSetNpcPosition(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPlotInterludeAction>("ActionPlotInterludeAction", (int id) => new LevelEventPlotInterludeAction(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSetupSeqCamera>("ActionSetSeqCameraTransform", (int id) => new LevelEventSetupSeqCamera(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnterSequenceCamera>("ActionEnterSequenceCamera", (int id) => new LevelEventEnterSequenceCamera(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPickupDropItem>("ActionPickupDropItem", (int id) => new LevelEventPickupDropItem(id), 4, true);
			LevelEventCenter.SetupEvent<LevelEventSpawnDestructibleActorWithTrackCapability>("ActionSpawnDestructibleActorWithTrackCapability", (int id) => new LevelEventSpawnDestructibleActorWithTrackCapability(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTimeTrackControl>("ActionTimeTrackControl", (int id) => new LevelEventTimeTrackControl(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventInteractFan>("ActionInteractFan", (int id) => new LevelEventInteractFan(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventInteractGravityFlip>("ActionInteractGravityFlip", (int id) => new LevelEventInteractGravityFlip(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSpawnBlueprintActor>("ActionSpawnBlueprintActor", (int id) => new LevelEventSpawnBlueprintActor(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventPlayMontage>(EAction.PlayMontage.ToEnumString(), (int id) => new LevelEventPlayMontage(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventPlayBubble>(EAction.PlayBubble.ToEnumString(), (int id) => new LevelEventPlayBubble(id), 8, false);
			LevelEventCenter.SetupEvent<LevelEventMoveWithSpline>(EAction.MoveWithSpline.ToEnumString(), (int id) => new LevelEventMoveWithSpline(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventNewMoveWithSpline>(EAction.NewMoveWithSpline.ToEnumString(), (int id) => new LevelEventNewMoveWithSpline(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventCharacterMove>(EAction.CharacterMoveToPoint.ToEnumString(), (int id) => new LevelEventCharacterMove(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventEnterVehicleNpc>(EAction.VehicleEnterNpc.ToEnumString(), (int id) => new LevelEventEnterVehicleNpc(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventVehicleWaterfallMove>(EAction.VehicleWaterfallClimbing.ToEnumString(), (int id) => new LevelEventVehicleWaterfallMove(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventVehiclePlayPassengerVoice>(EAction.VehiclePlayPassengerVoice.ToEnumString(), (int id) => new LevelEventVehiclePlayPassengerVoice(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventVehicleMoveWithPathLine>(EAction.VehicleMoveWithPathLine.ToEnumString(), (int id) => new LevelEventVehicleMoveWithPathLine(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventVehicleSprint>(EAction.VehicleSprint.ToEnumString(), (int id) => new LevelEventVehicleSprint(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventDriveMotorInSpecConfig>(EAction.DriveMotorInSpecConfig.ToEnumString(), (int id) => new LevelEventDriveMotorInSpecConfig(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventVehicleSetSpeedImmediately>(EAction.VehicleSetSpeedImmediately.ToEnumString(), (int id) => new LevelEventVehicleSetSpeedImmediately(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventMotorSoarInWindField>(EAction.MotorSoarInWindField.ToEnumString(), (int id) => new LevelEventMotorSoarInWindField(id), 1, false);
			if (Singleton<Info>.Instance.IsPlayInEditor)
			{
				LevelEventCenter.SetupEvent<LevelEventSetDemoActorVar>(EAction.SetActorVar.ToEnumString(), (int id) => new LevelEventSetDemoActorVar(id), 1, false);
				LevelEventCenter.SetupEvent<LevelEventRunDemoActorCustomEvent>(EAction.RunActorCustomEvent.ToEnumString(), (int id) => new LevelEventRunDemoActorCustomEvent(id), 1, false);
			}
			LevelEventCenter.SetupEvent<LevelEventBvbPlayDialog>(EAction.BvbPlayDialog.ToEnumString(), (int id) => new LevelEventBvbPlayDialog(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventBvbPlayerOperationConstraint>(EAction.BvbPlayerOperationConstraint.ToEnumString(), (int id) => new LevelEventBvbPlayerOperationConstraint(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventTrapDefensePlayerOperationConstraint>(EAction.TrapDefensePlayerOperationConstraint.ToEnumString(), (int id) => new LevelEventTrapDefensePlayerOperationConstraint(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventCommonTip2>(EAction.CommonTip2.ToEnumString(), (int id) => new LevelEventCommonTip2(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSetTimeScale>(EAction.SetTimeScale.ToEnumString(), (int id) => new LevelEventSetTimeScale(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventReignsSetPropertyVisible>(EAction.ReignsSetPropertyVisible.ToEnumString(), (int id) => new LevelEventReignsSetPropertyVisible(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTrapDefenseChangeMiniMap>(EAction.TrapDefenseChangeMiniMap.ToEnumString(), (int id) => new LevelEventTrapDefenseChangeMiniMap(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetSkillButtonEffect>(EAction.SetSkillButtonEffect.ToEnumString(), (int id) => new LevelEventSetSkillButtonEffect(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventToggleDragActorPlay>(EAction.ToggleDragActorPlay.ToEnumString(), (int id) => new LevelEventToggleDragActorPlay(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetNpcGroupPerform>(EAction.SetNpcGroupPerform.ToEnumString(), (int id) => new LevelEventSetNpcGroupPerform(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventRemoveNpcGroupPerform>(EAction.RemoveNpcGroupPerform.ToEnumString(), (int id) => new LevelEventRemoveNpcGroupPerform(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventHonamiStoryInteractPickUp>(EAction.HonamiStoryInteractPickUp.ToEnumString(), (int id) => new LevelEventHonamiStoryInteractPickUp(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetDataLayerTransition>(EAction.SetDataLayerTransitions.ToEnumString(), (int id) => new LevelEventSetDataLayerTransition(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnterMovieMode>(EAction.EnterMovieMode.ToEnumString(), (int id) => new LevelEventEnterMovieMode(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventExitMovieMode>(EAction.ExitMovieMode.ToEnumString(), (int id) => new LevelEventExitMovieMode(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventPhoneSystemInteract>(EAction.PhoneSystemInteract.ToEnumString(), (int id) => new LevelEventPhoneSystemInteract(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventStartMotorCruise>(EAction.StartMotorCruise.ToEnumString(), (int id) => new LevelEventStartMotorCruise(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventStopMotorCruise>(EAction.StopMotorCruise.ToEnumString(), (int id) => new LevelEventStopMotorCruise(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventSendSceneActorsEvent>(EAction.SendSceneActorsEvent.ToEnumString(), (int id) => new LevelEventSendSceneActorsEvent(id), 8, true);
			LevelEventCenter.SetupEvent<LevelEventDrinksRollRoleRequirement>(EAction.DrinksRollRoleRequirement.ToEnumString(), (int id) => new LevelEventDrinksRollRoleRequirement(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventTriggerGamepadShake>(EAction.TriggerGamepadShake.ToEnumString(), (int id) => new LevelEventTriggerGamepadShake(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventClientUnlockAchievement>(EAction.ClientUnlockAchievementSystemItem.ToEnumString(), (int id) => new LevelEventClientUnlockAchievement(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventDestroyDynamicEntities>(EAction.DestroyDynamicEntities.ToEnumString(), (int id) => new LevelEventDestroyDynamicEntities(id), 4, false);
			LevelEventCenter.SetupEvent<LevelEventQuickHackCameraControl>(EAction.OpenQuickHackSystem.ToEnumString(), (int id) => new LevelEventQuickHackCameraControl(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventExecBpActorFunc>(EAction.ExecBpActorFunc.ToEnumString(), (int id) => new LevelEventExecBpActorFunc(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventEnableSceneItemDurabilityUI>(EAction.EnableClientFunction.ToEnumString(), (int id) => new LevelEventEnableSceneItemDurabilityUI(id), 1, false);
			LevelEventCenter.SetupEvent<LevelEventSetSeasonState>(EAction.ClientSetSeasonState.ToEnumString(), (int id) => new LevelEventSetSeasonState(id), 4, false);
		}

		// Token: 0x06043ED2 RID: 278226 RVA: 0x01196B6C File Offset: 0x01194D6C
		private static void SetupEvent<[Nullable(0)] T>(string type, Func<int, T> ctor, int capacity = 1, bool expandCapacity = false) where T : LevelEventBase
		{
			if (LevelEventCenter.EventsMap.ContainsKey(type))
			{
				return;
			}
			List<LevelEventBase> list;
			if (expandCapacity)
			{
				list = new List<LevelEventBase>();
				for (int i = 0; i < capacity; i++)
				{
					T t = ctor(i);
					t.Type = type;
					list.Add(t);
				}
			}
			else
			{
				list = new List<LevelEventBase>(capacity);
				for (int j = 0; j < capacity; j++)
				{
					T t2 = ctor(j);
					t2.Type = type;
					list.Add(t2);
				}
			}
			LevelEventCenter.EventsMap[type] = list;
			if (capacity > 1)
			{
				LevelEventCenter.TickEventDefines.Add(type);
				LevelEventCenter.EventCapacityMap[type] = capacity;
				if (expandCapacity)
				{
					LevelEventCenter.ExpendCapacityEvents[type] = ctor;
				}
			}
		}

		// Token: 0x06043ED3 RID: 278227 RVA: 0x01196C30 File Offset: 0x01194E30
		[return: Nullable(2)]
		public unsafe static LevelEventBase GetEvent(string type)
		{
			List<LevelEventBase> list;
			if (!LevelEventCenter.EventsMap.TryGetValue(type, out list))
			{
				return null;
			}
			if (list != null)
			{
				if (list.Count > 0)
				{
					if (LevelEventCenter.TickEventDefines.Contains(type))
					{
						LevelEventBase levelEventBase = list[list.Count - 1];
						list.RemoveAt(list.Count - 1);
						levelEventBase.Reset();
						return levelEventBase;
					}
					return list[0];
				}
				else
				{
					if (LevelEventCenter.ExpendCapacityEvents.ContainsKey(type))
					{
						Func<int, LevelEventBase> func = LevelEventCenter.ExpendCapacityEvents[type];
						for (int i = 0; i < 4; i++)
						{
							LevelEventBase levelEventBase2 = func(i);
							levelEventBase2.Type = type;
							list.Add(levelEventBase2);
						}
						if (GlobalData.IsPlayInEditor)
						{
							int num = LevelEventCenter.EventCapacityMap[type] + 4;
							LevelEventCenter.EventCapacityMap[type] = num;
							if (num > 1024)
							{
								global::Log instance = Singleton<global::Log>.Instance;
								ELogModule module = ELogModule.Level;
								ELogAuthor author = ELogAuthor.YZH;
								string message = "动态扩容超上限，请检查";
								<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", type);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Capacity", num);
								instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
							}
						}
						LevelEventBase result = list[list.Count - 1];
						list.RemoveAt(list.Count - 1);
						return result;
					}
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Level;
					ELogAuthor author2 = ELogAuthor.YZH;
					string message2 = "事件组容量不足，建议扩容，请检查！！！";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", type);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			return null;
		}

		// Token: 0x06043ED4 RID: 278228 RVA: 0x01196DA4 File Offset: 0x01194FA4
		private static void ReleaseEvent(LevelEventBase eventObj)
		{
			if (!LevelEventCenter.TickEventDefines.Contains(eventObj.Type))
			{
				return;
			}
			List<LevelEventBase> list;
			if (!LevelEventCenter.EventsMap.TryGetValue(eventObj.Type, out list))
			{
				return;
			}
			if (list == null)
			{
				return;
			}
			if (!list.Contains(eventObj))
			{
				list.Add(eventObj);
			}
		}

		// Token: 0x06043ED5 RID: 278229 RVA: 0x01196DF0 File Offset: 0x01194FF0
		public static void AddToTickList(bool isAdd, LevelEventBase eventObj)
		{
			int groupId = eventObj.GroupId;
			if (isAdd)
			{
				List<LevelEventBase> list;
				if (!LevelEventCenter.TickEvents.TryGetValue(groupId, out list))
				{
					list = new List<LevelEventBase>();
					LevelEventCenter.TickEvents[groupId] = list;
				}
				if (list != null && !list.Contains(eventObj))
				{
					list.Add(eventObj);
					return;
				}
			}
			else if (LevelEventCenter.WaitToRemoveList != null && !LevelEventCenter.WaitToRemoveList.Contains(eventObj))
			{
				LevelEventCenter.WaitToRemoveList.Add(eventObj);
			}
		}

		// Token: 0x06043ED6 RID: 278230 RVA: 0x01196E5C File Offset: 0x0119505C
		public static void RemoveEventGroup(int groupId)
		{
			List<LevelEventBase> list;
			if (!LevelEventCenter.TickEvents.TryGetValue(groupId, out list))
			{
				return;
			}
			if (list == null)
			{
				return;
			}
			foreach (LevelEventBase levelEventBase in list)
			{
				levelEventBase.Release();
			}
		}

		// Token: 0x06043ED7 RID: 278231 RVA: 0x01196EBC File Offset: 0x011950BC
		public static void Tick(float deltaTime)
		{
			if (LevelEventCenter.WaitToRemoveList == null || LevelEventCenter.TickEvents == null)
			{
				return;
			}
			while (LevelEventCenter.WaitToRemoveList.Count > 0)
			{
				LevelEventBase levelEventBase = LevelEventCenter.WaitToRemoveList[LevelEventCenter.WaitToRemoveList.Count - 1];
				LevelEventCenter.WaitToRemoveList.RemoveAt(LevelEventCenter.WaitToRemoveList.Count - 1);
				List<LevelEventBase> list;
				if (LevelEventCenter.TickEvents.TryGetValue(levelEventBase.GroupId, out list) && list != null)
				{
					int num = list.IndexOf(levelEventBase);
					if (num != -1)
					{
						list.RemoveAt(num);
					}
					if (list.Count == 0)
					{
						LevelEventCenter.TickEvents.Remove(levelEventBase.GroupId);
					}
				}
				levelEventBase.Reset();
				LevelEventCenter.ReleaseEvent(levelEventBase);
			}
			foreach (List<LevelEventBase> list2 in LevelEventCenter.TickEvents.Values)
			{
				if (list2 != null)
				{
					int count = list2.Count;
					for (int i = 0; i < count; i++)
					{
						LevelEventBase levelEventBase2 = list2[i];
						if (levelEventBase2.Tick(deltaTime))
						{
							levelEventBase2.Finish();
						}
					}
				}
			}
		}

		// Token: 0x06043ED8 RID: 278232 RVA: 0x01196FE4 File Offset: 0x011951E4
		public static bool IsNeedTick(string type)
		{
			return LevelEventCenter.TickEventDefines.Contains(type);
		}

		// Token: 0x06043ED9 RID: 278233 RVA: 0x01196FF1 File Offset: 0x011951F1
		public static bool HasAction(string type)
		{
			return LevelEventCenter.EventsMap.ContainsKey(type);
		}

		// Token: 0x04025FCE RID: 155598
		private const int DEFAULT = 1;

		// Token: 0x04025FCF RID: 155599
		private const int LEVEL_1 = 4;

		// Token: 0x04025FD0 RID: 155600
		private const int LEVEL_2 = 8;

		// Token: 0x04025FD1 RID: 155601
		private const int LEVEL_MAX = 1024;

		// Token: 0x04025FD2 RID: 155602
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		[StaticVariableRuleIgnore]
		private static Dictionary<string, List<LevelEventBase>> EventsMap;

		// Token: 0x04025FD3 RID: 155603
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		[StaticVariableRuleIgnore]
		private static Dictionary<int, List<LevelEventBase>> TickEvents;

		// Token: 0x04025FD4 RID: 155604
		[Nullable(new byte[]
		{
			2,
			1
		})]
		[StaticVariableRuleIgnore]
		private static List<LevelEventBase> WaitToRemoveList;

		// Token: 0x04025FD5 RID: 155605
		[Nullable(new byte[]
		{
			2,
			1
		})]
		[StaticVariableRuleIgnore]
		private static HashSet<string> TickEventDefines;

		// Token: 0x04025FD6 RID: 155606
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		[StaticVariableRuleIgnore]
		private static Dictionary<string, Func<int, LevelEventBase>> ExpendCapacityEvents;

		// Token: 0x04025FD7 RID: 155607
		[Nullable(new byte[]
		{
			2,
			1
		})]
		[StaticVariableRuleIgnore]
		private static Dictionary<string, int> EventCapacityMap;
	}
}
