using System;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A60 RID: 27232
	public static class ELevelGeneralConditionExtensions
	{
		// Token: 0x060435D8 RID: 275928 RVA: 0x01154D6C File Offset: 0x01152F6C
		public static string ToEnumString(this ELevelGeneralCondition value)
		{
			string result;
			switch (value)
			{
			case ELevelGeneralCondition.DistanceLess:
				result = "DistanceLess";
				break;
			case ELevelGeneralCondition.SelfTagCheck:
				result = "SelfTagCheck";
				break;
			case ELevelGeneralCondition.ItemCheck:
				result = "ItemCheck";
				break;
			case ELevelGeneralCondition.CheckItemWithOperator:
				result = "CheckItemWithOperator";
				break;
			case ELevelGeneralCondition.CheckDis:
				result = "CheckDis";
				break;
			case ELevelGeneralCondition.TargetTagCheck:
				result = "TargetTagCheck";
				break;
			case ELevelGeneralCondition.CheckOnTrap:
				result = "CheckOnTrap";
				break;
			case ELevelGeneralCondition.CheckDirection:
				result = "CheckDirection";
				break;
			case ELevelGeneralCondition.QuestState:
				result = "QuestState";
				break;
			case ELevelGeneralCondition.CheckStrikeInfo:
				result = "CheckStrikeInfo";
				break;
			case ELevelGeneralCondition.CheckLevel:
				result = "CheckLevel";
				break;
			case ELevelGeneralCondition.CheckLevelOp:
				result = "CheckLevelOp";
				break;
			case ELevelGeneralCondition.CheckGuideStatus:
				result = "CheckGuideStatus";
				break;
			case ELevelGeneralCondition.CheckCharacterTag:
				result = "CheckCharacterTag";
				break;
			case ELevelGeneralCondition.CheckCharacterTagByEvent:
				result = "CheckCharacterTagByEvent";
				break;
			case ELevelGeneralCondition.CheckCharacterTagNotByEvent:
				result = "CheckCharacterTagNotByEvent";
				break;
			case ELevelGeneralCondition.CheckCharacterVehicleTagByEvent:
				result = "CheckCharacterVehicleTagByEvent";
				break;
			case ELevelGeneralCondition.CheckCharacterVehicleTagNotByEvent:
				result = "CheckCharacterVehicleTagNotByEvent";
				break;
			case ELevelGeneralCondition.DragonPoolState:
				result = "DragonPoolState";
				break;
			case ELevelGeneralCondition.SceneStepState:
				result = "SceneStepState";
				break;
			case ELevelGeneralCondition.CheckTeleportStatus:
				result = "CheckTeleportStatus";
				break;
			case ELevelGeneralCondition.RoleLevel:
				result = "RoleLevel";
				break;
			case ELevelGeneralCondition.CheckRoleLevel:
				result = "CheckRoleLevel";
				break;
			case ELevelGeneralCondition.CheckRoleOwned:
				result = "CheckRoleOwned";
				break;
			case ELevelGeneralCondition.RoleBreach:
				result = "RoleBreach";
				break;
			case ELevelGeneralCondition.SelfGameplayTagCheck:
				result = "SelfGameplayTagCheck";
				break;
			case ELevelGeneralCondition.CheckInTodTimeSpan:
				result = "CheckInTodTimeSpan";
				break;
			case ELevelGeneralCondition.CheckSceneItemTag:
				result = "CheckEntityCommonTag";
				break;
			case ELevelGeneralCondition.IsPlayer:
				result = "IsPlayer";
				break;
			case ELevelGeneralCondition.CheckEntityConfigId:
				result = "CheckEntityConfigId";
				break;
			case ELevelGeneralCondition.CheckSelfEntityCommonTag:
				result = "CheckSelfEntityCommonTag";
				break;
			case ELevelGeneralCondition.CheckInstanceEntranceUnlockStatus:
				result = "CheckInstanceEntranceUnlockStatus";
				break;
			case ELevelGeneralCondition.CheckOriginWorldLevel:
				result = "CheckOriginWorldLevel";
				break;
			case ELevelGeneralCondition.CheckCurWorldLevel:
				result = "CheckCurWorldLevel";
				break;
			case ELevelGeneralCondition.CheckCurWorldLevelOp:
				result = "CheckCurWorldLevelOp";
				break;
			case ELevelGeneralCondition.StartShootTarget:
				result = "StartShootTarget";
				break;
			case ELevelGeneralCondition.CheckInstanceState:
				result = "CheckInstanceState";
				break;
			case ELevelGeneralCondition.CheckInstanceMatchAble:
				result = "CheckInstanceMatchAble";
				break;
			case ELevelGeneralCondition.MoveStateCheck:
				result = "MoveStateCheck";
				break;
			case ELevelGeneralCondition.CheckBuff:
				result = "LevelConditionCheckBuff";
				break;
			case ELevelGeneralCondition.CheckUIState:
				result = "CheckUIState";
				break;
			case ELevelGeneralCondition.CheckUIOpen:
				result = "CheckUIOpen";
				break;
			case ELevelGeneralCondition.CheckUIOpenDone:
				result = "CheckUIOpenDone";
				break;
			case ELevelGeneralCondition.CheckUIShowDone:
				result = "CheckUIShowDone";
				break;
			case ELevelGeneralCondition.CheckInputAction:
				result = "CheckInputAction";
				break;
			case ELevelGeneralCondition.CheckClientUseSkill:
				result = "CheckClientUseSkill";
				break;
			case ELevelGeneralCondition.CheckClientUseVisionSkill:
				result = "CheckClientUseVisionSkill";
				break;
			case ELevelGeneralCondition.CheckBattleRole:
				result = "CheckBattleRole";
				break;
			case ELevelGeneralCondition.CheckEquippedPhantom:
				result = "CheckEquippedPhantom";
				break;
			case ELevelGeneralCondition.CheckEnemyBuff:
				result = "CheckEnemyBuff";
				break;
			case ELevelGeneralCondition.CheckEnemyTag:
				result = "CheckEnemyTag";
				break;
			case ELevelGeneralCondition.CheckSkillPoint:
				result = "CheckSkillPoint";
				break;
			case ELevelGeneralCondition.CheckExploreSkill:
				result = "CheckExploreSkill";
				break;
			case ELevelGeneralCondition.CheckFightEnergyBar:
				result = "CheckFightEnergyBar";
				break;
			case ELevelGeneralCondition.CheckFightEnergyBall:
				result = "CheckFightEnergyBall";
				break;
			case ELevelGeneralCondition.FunctionUnlock:
				result = "FunctionUnlock";
				break;
			case ELevelGeneralCondition.GetNewItem:
				result = "GetNewItem";
				break;
			case ELevelGeneralCondition.HarmonyQte:
				result = "HarmonyQte";
				break;
			case ELevelGeneralCondition.GetWhichRole:
				result = "GetWhichRole";
				break;
			case ELevelGeneralCondition.HpLowerThan:
				result = "HpLowerThan";
				break;
			case ELevelGeneralCondition.FightWithMonster:
				result = "FightWithMonster";
				break;
			case ELevelGeneralCondition.PawnInRange:
				result = "PawnInRange";
				break;
			case ELevelGeneralCondition.SlotOfCurrentRole:
				result = "SlotOfCurrentRole";
				break;
			case ELevelGeneralCondition.PhantomTargetLevel:
				result = "PhantomTargetLevel";
				break;
			case ELevelGeneralCondition.CheckClientQuest:
				result = "CheckClientQuest";
				break;
			case ELevelGeneralCondition.CheckClientQuestNode:
				result = "CheckClientQuestNode";
				break;
			case ELevelGeneralCondition.PhantomMaxLevel:
				result = "PhantomMaxLevel";
				break;
			case ELevelGeneralCondition.RoleTargetLevel:
				result = "RoleTargetLevel";
				break;
			case ELevelGeneralCondition.RoleSkillTargetLevel:
				result = "RoleSkillTargetLevel";
				break;
			case ELevelGeneralCondition.BattleRoleIsNot:
				result = "BattleRoleIsNot";
				break;
			case ELevelGeneralCondition.BattleRoleWeaponType:
				result = "BattleRoleWeaponType";
				break;
			case ELevelGeneralCondition.FormationAnyRoleDead:
				result = "FormationAnyRoleDead";
				break;
			case ELevelGeneralCondition.ComboTeachingState:
				result = "ComboTeachingState";
				break;
			case ELevelGeneralCondition.OnViewClose:
				result = "OnViewClose";
				break;
			case ELevelGeneralCondition.OnPlayerUseSkill:
				result = "OnPlayerUseSkill";
				break;
			case ELevelGeneralCondition.OnSkillButtonDataRefresh:
				result = "OnSkillButtonDataRefresh";
				break;
			case ELevelGeneralCondition.FinishGuideStepByEvent:
				result = "FinishGuideStepByEvent";
				break;
			case ELevelGeneralCondition.PlayerRevive:
				result = "PlayerRevive";
				break;
			case ELevelGeneralCondition.CheckTeamRoleCouldLevelUp:
				result = "CheckTeamRoleCouldLevelUp";
				break;
			case ELevelGeneralCondition.CheckTeamWeaponCouldLevelUp:
				result = "CheckTeamWeaponCouldLevelUp";
				break;
			case ELevelGeneralCondition.ClientCalabashLevel:
				result = "ClientCalabashLevel";
				break;
			case ELevelGeneralCondition.TeamRoleLevel:
				result = "TeamRoleLevel";
				break;
			case ELevelGeneralCondition.TeamWeaponLevel:
				result = "TeamWeaponLevel";
				break;
			case ELevelGeneralCondition.TeamCouldEquipPhantom:
				result = "TeamCouldEquipPhantom";
				break;
			case ELevelGeneralCondition.CheckAnyPhantomCouldUpdate:
				result = "CheckAnyPhantomCouldUpdate";
				break;
			case ELevelGeneralCondition.CheckAnyRoleFullPhantom:
				result = "CheckAnyRoleFullPhantom";
				break;
			case ELevelGeneralCondition.CheckRolePhantomNum:
				result = "CheckRolePhantomNum";
				break;
			case ELevelGeneralCondition.CheckItemCountByType:
				result = "CheckItemCountByType";
				break;
			case ELevelGeneralCondition.CheckRouletteEquipItemId:
				result = "CheckRouletteEquipItemId";
				break;
			case ELevelGeneralCondition.CheckVisionIntensifyTabOpen:
				result = "CheckVisionIntensifyTabOpen";
				break;
			case ELevelGeneralCondition.CheckAccountSettingOpen:
				result = "CheckAccountSettingOpen";
				break;
			case ELevelGeneralCondition.CheckOnTreasureBoxOpen:
				result = "CheckOnTreasureBoxOpen";
				break;
			case ELevelGeneralCondition.CheckWeaponCount:
				result = "CheckWeaponCount";
				break;
			case ELevelGeneralCondition.CheckOnCostInsufficient:
				result = "CheckOnCostInsufficient";
				break;
			case ELevelGeneralCondition.CheckRangeByPbDataId:
				result = "CheckRangeByPbDataId";
				break;
			case ELevelGeneralCondition.CheckDungeonId:
				result = "CheckDungeonId";
				break;
			case ELevelGeneralCondition.CheckRogueTerm:
				result = "CheckRogueTerm";
				break;
			case ELevelGeneralCondition.CheckTeleportTypeUnlock:
				result = "CheckTeleportTypeUnlock";
				break;
			case ELevelGeneralCondition.CheckTypeItemPickUp:
				result = "CheckTypeItemPickUp";
				break;
			case ELevelGeneralCondition.CheckDungeonFinished:
				result = "CheckDungeonFinished";
				break;
			case ELevelGeneralCondition.CheckRogueCanUnlockSkill:
				result = "CheckRogueCanUnlockSkill";
				break;
			case ELevelGeneralCondition.CheckPositionRolePhantomSkillEquip:
				result = "CheckPositionRolePhantomSkillEquip";
				break;
			case ELevelGeneralCondition.CheckHasFirstPhantomAtPosition:
				result = "CheckHasFirstPhantomAtPosition";
				break;
			case ELevelGeneralCondition.CheckWorldMapSecondaryUiOpened:
				result = "CheckWorldMapSecondaryUiOpened";
				break;
			case ELevelGeneralCondition.CheckHasUnlockAffixInBossRush:
				result = "CheckHasUnlockAffixInBossRush";
				break;
			case ELevelGeneralCondition.OnChangeBossRushBuff:
				result = "OnChangeBossRushBuff";
				break;
			case ELevelGeneralCondition.RoguelikeHasSelectEntryAndShow:
				result = "RoguelikeHasSelectEntryAndShow";
				break;
			case ELevelGeneralCondition.CheckActivityOpen:
				result = "CheckActivityOpen";
				break;
			case ELevelGeneralCondition.CheckHasSkinInRoleSkinSubView:
				result = "CheckHasSkinInRoleSkinSubView";
				break;
			case ELevelGeneralCondition.OnTakingPhoto:
				result = "OnTakingPhoto";
				break;
			case ELevelGeneralCondition.HasNotInvitedRoleInSpring25:
				result = "HasNotInvitedRoleInSpring25";
				break;
			case ELevelGeneralCondition.CheckMapFocusByQuestId:
				result = "CheckMapFocusByQuestId";
				break;
			case ELevelGeneralCondition.OnWorldMapGravityBtnShow:
				result = "OnWorldMapGravityBtnShow";
				break;
			case ELevelGeneralCondition.PickupInTowerDefenceBattle:
				result = "PickupInTowerDefenceBattle";
				break;
			case ELevelGeneralCondition.CheckOnSelectMenuMainType:
				result = "CheckOnSelectMenuMainType";
				break;
			case ELevelGeneralCondition.OnShowPhantomInFormation:
				result = "OnShowPhantomInFormation";
				break;
			case ELevelGeneralCondition.ForMoonChasingCheckTargetBuiltCount:
				result = "ForMoonChasingCheckTargetBuiltCount";
				break;
			case ELevelGeneralCondition.ForMoonChasingCheckHasCanLevelUpBuilding:
				result = "ForMoonChasingCheckHasCanLevelUpBuilding";
				break;
			case ELevelGeneralCondition.ForMoonChasingCheckNeedBranch:
				result = "ForMoonChasingCheckNeedBranch";
				break;
			case ELevelGeneralCondition.ForMoonChasingCheckHasNotFinishedTask:
				result = "ForMoonChasingCheckHasNotFinishedTask";
				break;
			case ELevelGeneralCondition.ForMoonChasingCheckTaskState:
				result = "ForMoonChasingCheckTaskState";
				break;
			case ELevelGeneralCondition.ForMoonChasingCheckMainlineTaskDone:
				result = "ForMoonChasingCheckMainlineTaskDone";
				break;
			case ELevelGeneralCondition.ForMoonChasingOpenInteractive:
				result = "ForMoonChasingOpenInteractive";
				break;
			case ELevelGeneralCondition.CheckPureModeWhenBattleViewActive:
				result = "CheckPureModeWhenBattleViewActive";
				break;
			case ELevelGeneralCondition.OnActivitySubViewDone:
				result = "OnActivitySubViewDone";
				break;
			case ELevelGeneralCondition.CheckLockEnemyMode:
				result = "CheckLockEnemyMode";
				break;
			case ELevelGeneralCondition.CheckIsShowProgressBarInMapExploreDetailView:
				result = "CheckIsShowProgressBarInMapExploreDetailView";
				break;
			case ELevelGeneralCondition.CheckIsMulti:
				result = "CheckIsMulti";
				break;
			case ELevelGeneralCondition.CheckFishingRoleTechViewOpen:
				result = "CheckFishingRoleTechViewOpen";
				break;
			case ELevelGeneralCondition.CheckFishingDockyardItemTipsShown:
				result = "CheckFishingDockyardItemTipsShown";
				break;
			case ELevelGeneralCondition.CheckShipTowerTeamOpen:
				result = "CheckShipTowerTeamOpen";
				break;
			case ELevelGeneralCondition.CheckDockyardWareHouseHasItem:
				result = "CheckDockyardWareHouseHasItem";
				break;
			case ELevelGeneralCondition.CheckFishingQteBtnHitValidArea:
				result = "CheckFishingQteBtnHitValidArea";
				break;
			case ELevelGeneralCondition.OnFishingQteScoreReachedMaximum:
				result = "OnFishingQteScoreReachedMaximum";
				break;
			case ELevelGeneralCondition.CheckFishingTechUnlock:
				result = "CheckFishingTechUnlock";
				break;
			case ELevelGeneralCondition.OnFishingBackpackBtnStateChange:
				result = "OnFishingBackpackBtnStateChange";
				break;
			case ELevelGeneralCondition.CheckFishingEntrustState:
				result = "CheckFishingEntrustState";
				break;
			case ELevelGeneralCondition.CheckFishingWareHouseItemListLength:
				result = "CheckFishingWareHouseItemListLength";
				break;
			case ELevelGeneralCondition.CheckCurFishingEntrustAvailablePeriod:
				result = "CheckCurFishingEntrustAvailablePeriod";
				break;
			case ELevelGeneralCondition.OnTreasureCompassUnitShow:
				result = "OnTreasureCompassUnitShow";
				break;
			case ELevelGeneralCondition.OnFishingBackpackQuickSellToggleShow:
				result = "OnFishingBackpackQuickSellToggleShow";
				break;
			case ELevelGeneralCondition.HideSettingInCloudGame:
				result = "HideSettingInCloudGame";
				break;
			case ELevelGeneralCondition.OnPlayerTitleUnlock:
				result = "OnPlayerTitleUnlock";
				break;
			case ELevelGeneralCondition.CheckDangoMonopolyHasFinishedRound:
				result = "CheckDangoMonopolyHasFinishedRound";
				break;
			case ELevelGeneralCondition.OnDangoMonopolyMoveStop:
				result = "OnDangoMonopolyMoveStop";
				break;
			case ELevelGeneralCondition.OnDangoMonopolyViewShowProcessEnd:
				result = "OnDangoMonopolyViewShowProcessEnd";
				break;
			case ELevelGeneralCondition.OnDangoAbyssPluginRoleSelect:
				result = "OnDangoAbyssPluginRoleSelect";
				break;
			case ELevelGeneralCondition.CheckDangoMatchState:
				result = "CheckDangoMatchState";
				break;
			case ELevelGeneralCondition.CheckDangoMatchPlayerNumType:
				result = "CheckDangoMatchPlayerNumType";
				break;
			case ELevelGeneralCondition.OnEnterDangoMatchView:
				result = "OnEnterDangoMatchView";
				break;
			case ELevelGeneralCondition.OnDangoMonopolyViewStart:
				result = "OnDangoMonopolyViewStart";
				break;
			case ELevelGeneralCondition.OnCiacconaAvgInspirationChoiceShow:
				result = "OnCiacconaAvgInspirationChoiceShow";
				break;
			case ELevelGeneralCondition.OnCiacconaChapterFirstStart:
				result = "OnCiacconaChapterFirstStart";
				break;
			case ELevelGeneralCondition.OnCiacconaChapterRestart:
				result = "OnCiacconaChapterRestart";
				break;
			case ELevelGeneralCondition.OnMovieRogueInfoRefreshWithMultipleEnds:
				result = "OnMovieRogueInfoRefreshWithMultipleEnds";
				break;
			case ELevelGeneralCondition.CheckMovieRogueFinishedEndingCount:
				result = "CheckMovieRogueFinishedEndingCount";
				break;
			case ELevelGeneralCondition.OnDangoAbyssEnterWithTeamExploreBtn:
				result = "OnDangoAbyssEnterWithTeamExploreBtn";
				break;
			case ELevelGeneralCondition.OnDangoAbyssEquipPluginWithValidChange:
				result = "OnDangoAbyssEquipPluginWithValidChange";
				break;
			case ELevelGeneralCondition.OnDangoAbyssEquipPluginWithInvalid:
				result = "OnDangoAbyssEquipPluginWithInvalid";
				break;
			case ELevelGeneralCondition.OnMovieRogueLinkRefresh:
				result = "OnMovieRogueLinkRefresh";
				break;
			case ELevelGeneralCondition.OnMovieRogueMapMoveEnd:
				result = "OnMovieRogueMapMoveEnd";
				break;
			case ELevelGeneralCondition.OnMapRogueEventDetailShow:
				result = "OnMapRogueEventDetailShow";
				break;
			case ELevelGeneralCondition.CheckMapRogueEventDetailShow:
				result = "CheckMapRogueEventDetailShow";
				break;
			case ELevelGeneralCondition.OnDangoMonopolyCameraFocusOnMainDango:
				result = "OnDangoMonopolyCameraFocusOnMainDango";
				break;
			case ELevelGeneralCondition.CheckDangoAbyssProgress:
				result = "CheckDangoAbyssProgress";
				break;
			case ELevelGeneralCondition.CheckDangoAbyssHasItemByType:
				result = "CheckDangoAbyssHasItemByType";
				break;
			case ELevelGeneralCondition.CheckDangoMatchFinalEnd:
				result = "CheckDangoMatchFinalEnd";
				break;
			case ELevelGeneralCondition.CheckGridHasExplored:
				result = "CheckGridHasExplored";
				break;
			case ELevelGeneralCondition.GolemHackingID:
				result = "GolemHackingID";
				break;
			case ELevelGeneralCondition.WeeklyChallengeOpen:
				result = "WeeklyChallengeOpen";
				break;
			case ELevelGeneralCondition.OnUiTabViewShow:
				result = "OnUiTabViewShow";
				break;
			case ELevelGeneralCondition.OnNewViewCovered:
				result = "OnNewViewCovered";
				break;
			case ELevelGeneralCondition.OnHandCardsShow:
				result = "OnHandCardsShow";
				break;
			case ELevelGeneralCondition.OnCardDetailShowWithFactor:
				result = "OnCardDetailShowWithFactor";
				break;
			case ELevelGeneralCondition.OnMonsterNumReachLimit:
				result = "OnMonsterNumReachLimit";
				break;
			case ELevelGeneralCondition.OnGetSpCard:
				result = "OnGetSpCard";
				break;
			case ELevelGeneralCondition.CheckPhantomArenaChallengeId:
				result = "CheckPhantomArenaChallengeId";
				break;
			case ELevelGeneralCondition.CheckClientQuestNodeStatus:
				result = "CheckClientQuestNodeStatus";
				break;
			case ELevelGeneralCondition.CheckAnyMoraleAreaFinishWithReward:
				result = "CheckAnyMoraleAreaFinishWithReward";
				break;
			case ELevelGeneralCondition.OnMoraleTempExpItemShow:
				result = "OnMoraleTempExpItemShow";
				break;
			case ELevelGeneralCondition.OnPhantomArenaChildViewShow:
				result = "OnPhantomArenaChildViewShow";
				break;
			case ELevelGeneralCondition.CheckNoMoraleAreaFinished:
				result = "CheckNoMoraleAreaFinished";
				break;
			case ELevelGeneralCondition.OnFloroRanchCardCountReachTarget:
				result = "OnFloroRanchCardCountReachTarget";
				break;
			case ELevelGeneralCondition.CheckFloroRanchRound:
				result = "CheckFloroRanchRound";
				break;
			case ELevelGeneralCondition.FloroRanchActivityID:
				result = "FloroRanchActivityID";
				break;
			case ELevelGeneralCondition.CheckFloroRanchHasTechCanUnlock:
				result = "CheckFloroRanchHasTechCanUnlock";
				break;
			case ELevelGeneralCondition.OnKingShipFirstAttrShow:
				result = "OnKingShipFirstAttrShow";
				break;
			case ELevelGeneralCondition.OnKingShipAllAttrShown:
				result = "OnKingShipAllAttrShown";
				break;
			case ELevelGeneralCondition.OnFloroRanchSettleViewOpenWithEndlessMode:
				result = "OnFloroRanchSettleViewOpenWithEndlessMode";
				break;
			case ELevelGeneralCondition.CheckFloroRanchLevel:
				result = "CheckFloroRanchLevel";
				break;
			case ELevelGeneralCondition.OnFloroRanchStageStartTaskFinish:
				result = "OnFloroRanchStageStartTaskFinish";
				break;
			case ELevelGeneralCondition.CheckTrapDefenseTalentCanUnlock:
				result = "CheckTrapDefenseTalentCanUnlock";
				break;
			case ELevelGeneralCondition.CheckTrapDefenseHasCanUpgradeMachine:
				result = "CheckTrapDefenseHasCanUpgradeMachine";
				break;
			case ELevelGeneralCondition.OnTrapDefenseAuxiliaryMachineUpgradeToMax:
				result = "OnTrapDefenseAuxiliaryMachineUpgradeToMax";
				break;
			case ELevelGeneralCondition.OnTrapDefenseMachineCanChooseBranch:
				result = "OnTrapDefenseMachineCanChooseBranch";
				break;
			case ELevelGeneralCondition.CheckTrapDefenseLevelFinish:
				result = "CheckTrapDefenseLevelFinish";
				break;
			case ELevelGeneralCondition.CheckTrapDefenseRogueUnlock:
				result = "CheckTrapDefenseRogueUnlock";
				break;
			case ELevelGeneralCondition.OnTrapDefenseBuffGroupUpgrade:
				result = "OnTrapDefenseBuffGroupUpgrade";
				break;
			case ELevelGeneralCondition.TrapDefenseTotalStar:
				result = "TrapDefenseTotalStar";
				break;
			case ELevelGeneralCondition.TrapDefensePassFullStar:
				result = "TrapDefensePassFullStar";
				break;
			case ELevelGeneralCondition.TrapDefenseChallengeStar:
				result = "TrapDefenseChallengeStar";
				break;
			case ELevelGeneralCondition.OnTrapDefenseBuildingDevelopPreviewBtnShow:
				result = "OnTrapDefenseBuildingDevelopPreviewBtnShow";
				break;
			case ELevelGeneralCondition.OnTrapDefenseDeployingBuilding:
				result = "OnTrapDefenseDeployingBuilding";
				break;
			case ELevelGeneralCondition.OnTrapDefenseBuildingDevelopBottomLayoutShow:
				result = "OnTrapDefenseBuildingDevelopBottomLayoutShow";
				break;
			case ELevelGeneralCondition.CheckTrapDefenseMachineLevel:
				result = "CheckTrapDefenseMachineLevel";
				break;
			case ELevelGeneralCondition.CheckTrapDefenseTalentUnlock:
				result = "CheckTrapDefenseTalentUnlock";
				break;
			case ELevelGeneralCondition.OnTrapDefenseMainLevelViewOpen:
				result = "OnTrapDefenseMainLevelViewOpen";
				break;
			case ELevelGeneralCondition.OnVisionIntensifyViewShow:
				result = "OnVisionIntensifyViewShow";
				break;
			case ELevelGeneralCondition.OnSurvivorsRogueEndlessToggleShow:
				result = "OnSurvivorsRogueEndlessToggleShow";
				break;
			case ELevelGeneralCondition.OnSurvivorsRogueComboBuffShow:
				result = "OnSurvivorsRogueComboBuffShow";
				break;
			case ELevelGeneralCondition.CheckFightPhotoHasTarget:
				result = "CheckFightPhotoHasTarget";
				break;
			case ELevelGeneralCondition.CheckFightPhotoLevelFinished:
				result = "CheckFightPhotoLevelFinished";
				break;
			case ELevelGeneralCondition.CheckCalabashChildFunctionOpen:
				result = "CheckCalabashChildFunctionOpen";
				break;
			case ELevelGeneralCondition.OnSurvivorsRoguePopViewRefresh:
				result = "OnSurvivorsRoguePopViewRefresh";
				break;
			case ELevelGeneralCondition.CheckSurvivorRogueTalentCanUnlock:
				result = "CheckSurvivorRogueTalentCanUnlock";
				break;
			case ELevelGeneralCondition.CheckSurvivorRogueHasWeaponBond:
				result = "CheckSurvivorRogueHasWeaponBond";
				break;
			case ELevelGeneralCondition.OnSurvivorsRogueWeaponDetailTabViewShow:
				result = "OnSurvivorsRogueWeaponDetailTabViewShow";
				break;
			case ELevelGeneralCondition.AlwaysFalse:
				result = "AlwaysFalse";
				break;
			case ELevelGeneralCondition.OnEnterOrExitBattle:
				result = "OnEnterOrExitBattle";
				break;
			case ELevelGeneralCondition.OnHonamiStoryLifeSupportChange:
				result = "OnHonamiStoryLifeSupportChange";
				break;
			case ELevelGeneralCondition.OnPickUpHonamiStoryItem:
				result = "OnPickUpHonamiStoryItem";
				break;
			case ELevelGeneralCondition.OnSceneItemDurabilityEmpty:
				result = "OnSceneItemDurabilityEmpty";
				break;
			case ELevelGeneralCondition.CheckPickUpHonamiStoryItemType:
				result = "CheckPickUpHonamiStoryItemType";
				break;
			case ELevelGeneralCondition.IsHasRecommendRecActivity:
				result = "IsHasRecommendRecActivity";
				break;
			case ELevelGeneralCondition.CheckMotorMovieModeStateChange:
				result = "CheckMotorMovieModeStateChange";
				break;
			case ELevelGeneralCondition.OnMotorMusicPlayerShow:
				result = "OnMotorMusicPlayerShow";
				break;
			case ELevelGeneralCondition.OnMapCustomMarkPanelShow:
				result = "OnMapCustomMarkPanelShow";
				break;
			case ELevelGeneralCondition.OnPhantomArenaChooseCardPanelShow:
				result = "OnPhantomArenaChooseCardPanelShow";
				break;
			case ELevelGeneralCondition.OnPhantomArenaDiscardCardPanelShow:
				result = "OnPhantomArenaDiscardCardPanelShow";
				break;
			case ELevelGeneralCondition.OnMotorDiyViewShow:
				result = "OnMotorDiyViewShow";
				break;
			case ELevelGeneralCondition.OnPhantomArenaPlayFieldEffect:
				result = "OnPhantomArenaPlayFieldEffect";
				break;
			case ELevelGeneralCondition.OnRollBlockDifficultyChanged:
				result = "OnRollBlockDifficultyChanged";
				break;
			case ELevelGeneralCondition.CheckDungeonTypes:
				result = "CheckDungeonTypes";
				break;
			case ELevelGeneralCondition.OnEnterWheelTowerEndlessMode:
				result = "OnEnterWheelTowerEndlessMode";
				break;
			case ELevelGeneralCondition.OnGuideTriggerEvent:
				result = "OnGuideTriggerEvent";
				break;
			case ELevelGeneralCondition.CheckUiItemShow:
				result = "CheckUiItemShow";
				break;
			case ELevelGeneralCondition.CheckExploreSkillFlag:
				result = "CheckExploreSkillFlag";
				break;
			case ELevelGeneralCondition.CheckGuessJokerRound:
				result = "CheckGuessJokerRound";
				break;
			case ELevelGeneralCondition.CheckMotorFightLevelFinished:
				result = "CheckMotorFightLevelFinished";
				break;
			case ELevelGeneralCondition.CheckEncircleChallengeId:
				result = "CheckEncircleChallengeId";
				break;
			case ELevelGeneralCondition.OnFlagChallengeCalculatedLevelOver:
				result = "OnFlagChallengeCalculatedLevelOver";
				break;
			case ELevelGeneralCondition.CheckTetrisLevelId:
				result = "CheckTetrisLevelId";
				break;
			case ELevelGeneralCondition.CheckRhythmShipSubLevelHasRank:
				result = "CheckRhythmShipSubLevelHasRank";
				break;
			case ELevelGeneralCondition.CheckDropCatchGameplayId:
				result = "CheckDropCatchGameplayId";
				break;
			case ELevelGeneralCondition.CheckTetrisScore:
				result = "CheckTetrisScore";
				break;
			case ELevelGeneralCondition.CheckNewPlayerSupportV2:
				result = "CheckNewPlayerSupportV2";
				break;
			case ELevelGeneralCondition.CheckPinballLevelPass:
				result = "CheckPinballLevelPass";
				break;
			case ELevelGeneralCondition.CheckPinballWeaponCount:
				result = "CheckPinballWeaponCount";
				break;
			case ELevelGeneralCondition.OnNormalTopViewChange:
				result = "OnNormalTopViewChange";
				break;
			case ELevelGeneralCondition.CheckPopIsTargetOrEmpty:
				result = "CheckPopIsTargetOrEmpty";
				break;
			case ELevelGeneralCondition.CheckKurotatoLevelWave:
				result = "CheckKurotatoLevelWave";
				break;
			case ELevelGeneralCondition.CheckKurotatoLevelFinished:
				result = "CheckKurotatoLevelFinished";
				break;
			case ELevelGeneralCondition.CheckTrialRole:
				result = "CheckTrialRole";
				break;
			case ELevelGeneralCondition.CheckInteractiveItemsFunctionEnable:
				result = "CheckInteractiveItemsFunctionEnable";
				break;
			case ELevelGeneralCondition.CheckPhantomTeam:
				result = "CheckPhantomTeam";
				break;
			case ELevelGeneralCondition.CheckTrialAssist:
				result = "CheckTrialAssist";
				break;
			case ELevelGeneralCondition.CheckQuestClosedSegment:
				result = "CheckQuestClosedSegment";
				break;
			case ELevelGeneralCondition.CheckGameplayClosedSegment:
				result = "CheckGameplayClosedSegment";
				break;
			case ELevelGeneralCondition.CheckOperationRestrict:
				result = "CheckOperationRestrict";
				break;
			case ELevelGeneralCondition.CheckCameraMode:
				result = "CheckCameraMode";
				break;
			case ELevelGeneralCondition.CheckCharacterMotionState:
				result = "CheckCharacterMotionState";
				break;
			case ELevelGeneralCondition.CheckCharacterTagsRestrict:
				result = "CheckCharacterTagsRestrict";
				break;
			case ELevelGeneralCondition.CheckInteracting:
				result = "CheckInteracting";
				break;
			case ELevelGeneralCondition.CheckRoverlikeInstPassed:
				result = "CheckRoverlikeInstPassed";
				break;
			case ELevelGeneralCondition.CheckSubPackageDownLoadBtnShow:
				result = "CheckSubPackageDownLoadBtnShow";
				break;
			case ELevelGeneralCondition.CheckFightSpecialEnergyFull:
				result = "CheckFightSpecialEnergyFull";
				break;
			case ELevelGeneralCondition.CheckNewbieGuideV2:
				result = "CheckNewbieGuideV2";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x060435D9 RID: 275929 RVA: 0x01155D0C File Offset: 0x01153F0C
		public static ELevelGeneralCondition FromString(string name)
		{
			ELevelGeneralCondition result;
			if (!ELevelGeneralConditionExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ELevelGeneralCondition 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x060435DA RID: 275930 RVA: 0x01155D38 File Offset: 0x01153F38
		public static bool TryFromString(string name, out ELevelGeneralCondition value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ELevelGeneralCondition.DistanceLess;
				return false;
			}
			if (name != null)
			{
				switch (name.Length)
				{
				case 8:
				{
					char c = name[0];
					if (c != 'C')
					{
						if (c == 'I')
						{
							if (name == "IsPlayer")
							{
								value = ELevelGeneralCondition.IsPlayer;
								return true;
							}
						}
					}
					else if (name == "CheckDis")
					{
						value = ELevelGeneralCondition.CheckDis;
						return true;
					}
					break;
				}
				case 9:
				{
					char c = name[0];
					if (c != 'I')
					{
						if (c == 'R')
						{
							if (name == "RoleLevel")
							{
								value = ELevelGeneralCondition.RoleLevel;
								return true;
							}
						}
					}
					else if (name == "ItemCheck")
					{
						value = ELevelGeneralCondition.ItemCheck;
						return true;
					}
					break;
				}
				case 10:
				{
					char c = name[0];
					if (c <= 'G')
					{
						if (c != 'C')
						{
							if (c == 'G')
							{
								if (name == "GetNewItem")
								{
									value = ELevelGeneralCondition.GetNewItem;
									return true;
								}
							}
						}
						else if (name == "CheckLevel")
						{
							value = ELevelGeneralCondition.CheckLevel;
							return true;
						}
					}
					else if (c != 'H')
					{
						if (c != 'Q')
						{
							if (c == 'R')
							{
								if (name == "RoleBreach")
								{
									value = ELevelGeneralCondition.RoleBreach;
									return true;
								}
							}
						}
						else if (name == "QuestState")
						{
							value = ELevelGeneralCondition.QuestState;
							return true;
						}
					}
					else if (name == "HarmonyQte")
					{
						value = ELevelGeneralCondition.HarmonyQte;
						return true;
					}
					break;
				}
				case 11:
				{
					char c = name[5];
					if (c <= 'U')
					{
						if (c != 'O')
						{
							if (c != 'S')
							{
								if (c == 'U')
								{
									if (name == "CheckUIOpen")
									{
										value = ELevelGeneralCondition.CheckUIOpen;
										return true;
									}
								}
							}
							else if (name == "OnGetSpCard")
							{
								value = ELevelGeneralCondition.OnGetSpCard;
								return true;
							}
						}
						else if (name == "CheckOnTrap")
						{
							value = ELevelGeneralCondition.CheckOnTrap;
							return true;
						}
					}
					else if (c <= 'n')
					{
						if (c != 'e')
						{
							if (c == 'n')
							{
								if (name == "PawnInRange")
								{
									value = ELevelGeneralCondition.PawnInRange;
									return true;
								}
							}
						}
						else if (name == "HpLowerThan")
						{
							value = ELevelGeneralCondition.HpLowerThan;
							return true;
						}
					}
					else if (c != 's')
					{
						if (c == 'w')
						{
							if (name == "OnViewClose")
							{
								value = ELevelGeneralCondition.OnViewClose;
								return true;
							}
						}
					}
					else if (name == "AlwaysFalse")
					{
						value = ELevelGeneralCondition.AlwaysFalse;
						return true;
					}
					break;
				}
				case 12:
				{
					char c = name[5];
					if (c <= 'U')
					{
						if (c != 'I')
						{
							if (c != 'L')
							{
								if (c == 'U')
								{
									if (name == "CheckUIState")
									{
										value = ELevelGeneralCondition.CheckUIState;
										return true;
									}
								}
							}
							else if (name == "CheckLevelOp")
							{
								value = ELevelGeneralCondition.CheckLevelOp;
								return true;
							}
						}
						else if (name == "CheckIsMulti")
						{
							value = ELevelGeneralCondition.CheckIsMulti;
							return true;
						}
					}
					else if (c <= 'i')
					{
						if (c != 'a')
						{
							if (c == 'i')
							{
								if (name == "GetWhichRole")
								{
									value = ELevelGeneralCondition.GetWhichRole;
									return true;
								}
							}
						}
						else if (name == "SelfTagCheck")
						{
							value = ELevelGeneralCondition.SelfTagCheck;
							return true;
						}
					}
					else if (c != 'n')
					{
						if (c == 'r')
						{
							if (name == "PlayerRevive")
							{
								value = ELevelGeneralCondition.PlayerRevive;
								return true;
							}
						}
					}
					else if (name == "DistanceLess")
					{
						value = ELevelGeneralCondition.DistanceLess;
						return true;
					}
					break;
				}
				case 13:
				{
					char c = name[0];
					if (c != 'C')
					{
						if (c != 'O')
						{
							if (c == 'T')
							{
								if (name == "TeamRoleLevel")
								{
									value = ELevelGeneralCondition.TeamRoleLevel;
									return true;
								}
							}
						}
						else if (name == "OnTakingPhoto")
						{
							value = ELevelGeneralCondition.OnTakingPhoto;
							return true;
						}
					}
					else if (name == "CheckEnemyTag")
					{
						value = ELevelGeneralCondition.CheckEnemyTag;
						return true;
					}
					break;
				}
				case 14:
				{
					char c = name[9];
					if (c <= 'c')
					{
						if (c <= 'L')
						{
							if (c != 'C')
							{
								if (c == 'L')
								{
									if (name == "CheckRoleLevel")
									{
										value = ELevelGeneralCondition.CheckRoleLevel;
										return true;
									}
								}
							}
							else
							{
								if (name == "TargetTagCheck")
								{
									value = ELevelGeneralCondition.TargetTagCheck;
									return true;
								}
								if (name == "MoveStateCheck")
								{
									value = ELevelGeneralCondition.MoveStateCheck;
									return true;
								}
							}
						}
						else if (c != 'O')
						{
							if (c != 'S')
							{
								if (c == 'c')
								{
									if (name == "CheckDirection")
									{
										value = ELevelGeneralCondition.CheckDirection;
										return true;
									}
								}
							}
							else if (name == "SceneStepState")
							{
								value = ELevelGeneralCondition.SceneStepState;
								return true;
							}
						}
						else if (name == "CheckRoleOwned")
						{
							value = ELevelGeneralCondition.CheckRoleOwned;
							return true;
						}
					}
					else if (c <= 'i')
					{
						if (c != 'e')
						{
							if (c == 'i')
							{
								if (name == "GolemHackingID")
								{
									value = ELevelGeneralCondition.GolemHackingID;
									return true;
								}
							}
						}
						else
						{
							if (name == "CheckDungeonId")
							{
								value = ELevelGeneralCondition.CheckDungeonId;
								return true;
							}
							if (name == "CheckRogueTerm")
							{
								value = ELevelGeneralCondition.CheckRogueTerm;
								return true;
							}
						}
					}
					else if (c != 'l')
					{
						if (c != 'n')
						{
							if (c == 'y')
							{
								if (name == "CheckEnemyBuff")
								{
									value = ELevelGeneralCondition.CheckEnemyBuff;
									return true;
								}
							}
						}
						else if (name == "FunctionUnlock")
						{
							value = ELevelGeneralCondition.FunctionUnlock;
							return true;
						}
					}
					else if (name == "CheckTrialRole")
					{
						value = ELevelGeneralCondition.CheckTrialRole;
						return true;
					}
					break;
				}
				case 15:
				{
					char c = name[7];
					if (c <= 'S')
					{
						if (c <= 'M')
						{
							if (c != 'I')
							{
								if (c == 'M')
								{
									if (name == "PhantomMaxLevel")
									{
										value = ELevelGeneralCondition.PhantomMaxLevel;
										return true;
									}
								}
							}
							else if (name == "CheckUiItemShow")
							{
								value = ELevelGeneralCondition.CheckUiItemShow;
								return true;
							}
						}
						else if (c != 'O')
						{
							if (c == 'S')
							{
								if (name == "CheckUIShowDone")
								{
									value = ELevelGeneralCondition.CheckUIShowDone;
									return true;
								}
							}
						}
						else if (name == "CheckUIOpenDone")
						{
							value = ELevelGeneralCondition.CheckUIOpenDone;
							return true;
						}
					}
					else if (c <= 'a')
					{
						if (c != 'V')
						{
							if (c == 'a')
							{
								if (name == "OnHandCardsShow")
								{
									value = ELevelGeneralCondition.OnHandCardsShow;
									return true;
								}
							}
						}
						else if (name == "OnUiTabViewShow")
						{
							value = ELevelGeneralCondition.OnUiTabViewShow;
							return true;
						}
					}
					else if (c != 'g')
					{
						if (c != 'i')
						{
							switch (c)
							{
							case 'm':
								if (name == "CheckCameraMode")
								{
									value = ELevelGeneralCondition.CheckCameraMode;
									return true;
								}
								break;
							case 'o':
								if (name == "DragonPoolState")
								{
									value = ELevelGeneralCondition.DragonPoolState;
									return true;
								}
								if (name == "BattleRoleIsNot")
								{
									value = ELevelGeneralCondition.BattleRoleIsNot;
									return true;
								}
								break;
							case 'p':
								if (name == "TeamWeaponLevel")
								{
									value = ELevelGeneralCondition.TeamWeaponLevel;
									return true;
								}
								break;
							case 'r':
								if (name == "CheckStrikeInfo")
								{
									value = ELevelGeneralCondition.CheckStrikeInfo;
									return true;
								}
								break;
							case 't':
								if (name == "CheckBattleRole")
								{
									value = ELevelGeneralCondition.CheckBattleRole;
									return true;
								}
								break;
							}
						}
						else if (name == "CheckSkillPoint")
						{
							value = ELevelGeneralCondition.CheckSkillPoint;
							return true;
						}
					}
					else if (name == "RoleTargetLevel")
					{
						value = ELevelGeneralCondition.RoleTargetLevel;
						return true;
					}
					break;
				}
				case 16:
				{
					char c = name[8];
					if (c <= 'e')
					{
						if (c != 'U')
						{
							switch (c)
							{
							case 'a':
								if (name == "CheckTrialAssist")
								{
									value = ELevelGeneralCondition.CheckTrialAssist;
									return true;
								}
								break;
							case 'd':
								if (name == "CheckGuideStatus")
								{
									value = ELevelGeneralCondition.CheckGuideStatus;
									return true;
								}
								break;
							case 'e':
								if (name == "CheckClientQuest")
								{
									value = ELevelGeneralCondition.CheckClientQuest;
									return true;
								}
								if (name == "CheckInteracting")
								{
									value = ELevelGeneralCondition.CheckInteracting;
									return true;
								}
								break;
							}
						}
						else if (name == "OnPlayerUseSkill")
						{
							value = ELevelGeneralCondition.OnPlayerUseSkill;
							return true;
						}
					}
					else if (c != 'h')
					{
						switch (c)
						{
						case 'n':
							if (name == "CheckPhantomTeam")
							{
								value = ELevelGeneralCondition.CheckPhantomTeam;
								return true;
							}
							break;
						case 'o':
							if (name == "StartShootTarget")
							{
								value = ELevelGeneralCondition.StartShootTarget;
								return true;
							}
							break;
						case 'p':
							if (name == "CheckWeaponCount")
							{
								value = ELevelGeneralCondition.CheckWeaponCount;
								return true;
							}
							break;
						case 'r':
							if (name == "CheckTetrisScore")
							{
								value = ELevelGeneralCondition.CheckTetrisScore;
								return true;
							}
							break;
						case 'u':
							if (name == "CheckInputAction")
							{
								value = ELevelGeneralCondition.CheckInputAction;
								return true;
							}
							break;
						case 'w':
							if (name == "OnNewViewCovered")
							{
								value = ELevelGeneralCondition.OnNewViewCovered;
								return true;
							}
							break;
						}
					}
					else if (name == "FightWithMonster")
					{
						value = ELevelGeneralCondition.FightWithMonster;
						return true;
					}
					break;
				}
				case 17:
				{
					char c = name[5];
					switch (c)
					{
					case 'A':
						if (name == "CheckActivityOpen")
						{
							value = ELevelGeneralCondition.CheckActivityOpen;
							return true;
						}
						break;
					case 'B':
						break;
					case 'C':
						if (name == "CheckCharacterTag")
						{
							value = ELevelGeneralCondition.CheckCharacterTag;
							return true;
						}
						break;
					case 'D':
						if (name == "CheckDungeonTypes")
						{
							value = ELevelGeneralCondition.CheckDungeonTypes;
							return true;
						}
						break;
					case 'E':
						if (name == "CheckExploreSkill")
						{
							value = ELevelGeneralCondition.CheckExploreSkill;
							return true;
						}
						break;
					default:
						if (c == 'f')
						{
							if (name == "SlotOfCurrentRole")
							{
								value = ELevelGeneralCondition.SlotOfCurrentRole;
								return true;
							}
						}
						break;
					}
					break;
				}
				case 18:
				{
					char c = name[8];
					if (c <= 'i')
					{
						if (c != 'W')
						{
							switch (c)
							{
							case 'a':
								if (name == "PhantomTargetLevel")
								{
									value = ELevelGeneralCondition.PhantomTargetLevel;
									return true;
								}
								break;
							case 'b':
								if (name == "CheckNewbieGuideV2")
								{
									value = ELevelGeneralCondition.CheckNewbieGuideV2;
									return true;
								}
								break;
							case 'c':
								if (name == "ComboTeachingState")
								{
									value = ELevelGeneralCondition.ComboTeachingState;
									return true;
								}
								break;
							default:
								if (c == 'i')
								{
									if (name == "OnMotorDiyViewShow")
									{
										value = ELevelGeneralCondition.OnMotorDiyViewShow;
										return true;
									}
								}
								break;
							}
						}
						else if (name == "CheckCurWorldLevel")
						{
							value = ELevelGeneralCondition.CheckCurWorldLevel;
							return true;
						}
					}
					else if (c <= 'o')
					{
						if (c != 'k')
						{
							if (c == 'o')
							{
								if (name == "CheckInTodTimeSpan")
								{
									value = ELevelGeneralCondition.CheckInTodTimeSpan;
									return true;
								}
							}
						}
						else if (name == "CheckLockEnemyMode")
						{
							value = ELevelGeneralCondition.CheckLockEnemyMode;
							return true;
						}
					}
					else if (c != 'r')
					{
						if (c == 't')
						{
							if (name == "CheckInstanceState")
							{
								value = ELevelGeneralCondition.CheckInstanceState;
								return true;
							}
						}
					}
					else if (name == "CheckTetrisLevelId")
					{
						value = ELevelGeneralCondition.CheckTetrisLevelId;
						return true;
					}
					break;
				}
				case 19:
				{
					char c = name[14];
					if (c <= 'S')
					{
						if (c != 'E')
						{
							if (c != 'L')
							{
								if (c == 'S')
								{
									if (name == "CheckClientUseSkill")
									{
										value = ELevelGeneralCondition.CheckClientUseSkill;
										return true;
									}
								}
							}
							else if (name == "ClientCalabashLevel")
							{
								value = ELevelGeneralCondition.ClientCalabashLevel;
								return true;
							}
						}
						else if (name == "OnGuideTriggerEvent")
						{
							value = ELevelGeneralCondition.OnGuideTriggerEvent;
							return true;
						}
					}
					else if (c <= 'n')
					{
						switch (c)
						{
						case 'a':
							if (name == "OnEnterOrExitBattle")
							{
								value = ELevelGeneralCondition.OnEnterOrExitBattle;
								return true;
							}
							break;
						case 'b':
						case 'c':
						case 'd':
						case 'h':
							break;
						case 'e':
							if (name == "WeeklyChallengeOpen")
							{
								value = ELevelGeneralCondition.WeeklyChallengeOpen;
								return true;
							}
							break;
						case 'f':
							if (name == "CheckEntityConfigId")
							{
								value = ELevelGeneralCondition.CheckEntityConfigId;
								return true;
							}
							break;
						case 'g':
							if (name == "CheckFightEnergyBar")
							{
								value = ELevelGeneralCondition.CheckFightEnergyBar;
								return true;
							}
							break;
						case 'i':
							if (name == "CheckTypeItemPickUp")
							{
								value = ELevelGeneralCondition.CheckTypeItemPickUp;
								return true;
							}
							break;
						default:
							if (c == 'n')
							{
								if (name == "OnPlayerTitleUnlock")
								{
									value = ELevelGeneralCondition.OnPlayerTitleUnlock;
									return true;
								}
							}
							break;
						}
					}
					else if (c != 'o')
					{
						if (c == 't')
						{
							if (name == "CheckTeleportStatus")
							{
								value = ELevelGeneralCondition.CheckTeleportStatus;
								return true;
							}
						}
					}
					else if (name == "CheckRolePhantomNum")
					{
						value = ELevelGeneralCondition.CheckRolePhantomNum;
						return true;
					}
					break;
				}
				case 20:
				{
					char c = name[10];
					if (c <= 'R')
					{
						if (c <= 'J')
						{
							switch (c)
							{
							case 'A':
								if (name == "FloroRanchActivityID")
								{
									value = ELevelGeneralCondition.FloroRanchActivityID;
									return true;
								}
								break;
							case 'B':
								if (name == "CheckRangeByPbDataId")
								{
									value = ELevelGeneralCondition.CheckRangeByPbDataId;
									return true;
								}
								break;
							case 'C':
							case 'D':
								break;
							case 'E':
								if (name == "CheckFightEnergyBall")
								{
									value = ELevelGeneralCondition.CheckFightEnergyBall;
									return true;
								}
								break;
							default:
								if (c == 'J')
								{
									if (name == "CheckGuessJokerRound")
									{
										value = ELevelGeneralCondition.CheckGuessJokerRound;
										return true;
									}
								}
								break;
							}
						}
						else if (c != 'M')
						{
							if (c == 'R')
							{
								if (name == "CheckFloroRanchRound")
								{
									value = ELevelGeneralCondition.CheckFloroRanchRound;
									return true;
								}
								if (name == "CheckFloroRanchLevel")
								{
									value = ELevelGeneralCondition.CheckFloroRanchLevel;
									return true;
								}
							}
						}
						else if (name == "CheckDangoMatchState")
						{
							value = ELevelGeneralCondition.CheckDangoMatchState;
							return true;
						}
					}
					else if (c <= 'a')
					{
						if (c != 'W')
						{
							if (c == 'a')
							{
								if (name == "SelfGameplayTagCheck")
								{
									value = ELevelGeneralCondition.SelfGameplayTagCheck;
									return true;
								}
								if (name == "RoleSkillTargetLevel")
								{
									value = ELevelGeneralCondition.RoleSkillTargetLevel;
									return true;
								}
								if (name == "CheckGridHasExplored")
								{
									value = ELevelGeneralCondition.CheckGridHasExplored;
									return true;
								}
							}
						}
						else if (name == "BattleRoleWeaponType")
						{
							value = ELevelGeneralCondition.BattleRoleWeaponType;
							return true;
						}
					}
					else if (c != 'e')
					{
						switch (c)
						{
						case 'n':
							if (name == "FormationAnyRoleDead")
							{
								value = ELevelGeneralCondition.FormationAnyRoleDead;
								return true;
							}
							break;
						case 'o':
							if (name == "CheckItemCountByType")
							{
								value = ELevelGeneralCondition.CheckItemCountByType;
								return true;
							}
							if (name == "CheckDungeonFinished")
							{
								value = ELevelGeneralCondition.CheckDungeonFinished;
								return true;
							}
							break;
						case 'p':
							if (name == "CheckEquippedPhantom")
							{
								value = ELevelGeneralCondition.CheckEquippedPhantom;
								return true;
							}
							break;
						case 'r':
							if (name == "CheckCurWorldLevelOp")
							{
								value = ELevelGeneralCondition.CheckCurWorldLevelOp;
								return true;
							}
							break;
						case 's':
							if (name == "OnChangeBossRushBuff")
							{
								value = ELevelGeneralCondition.OnChangeBossRushBuff;
								return true;
							}
							break;
						case 't':
							if (name == "CheckClientQuestNode")
							{
								value = ELevelGeneralCondition.CheckClientQuestNode;
								return true;
							}
							break;
						case 'y':
							if (name == "CheckEntityCommonTag")
							{
								value = ELevelGeneralCondition.CheckSceneItemTag;
								return true;
							}
							break;
						}
					}
					else if (name == "TrapDefenseTotalStar")
					{
						value = ELevelGeneralCondition.TrapDefenseTotalStar;
						return true;
					}
					break;
				}
				case 21:
				{
					char c = name[5];
					if (c <= 'P')
					{
						if (c <= 'I')
						{
							if (c != 'E')
							{
								if (c == 'I')
								{
									if (name == "CheckItemWithOperator")
									{
										value = ELevelGeneralCondition.CheckItemWithOperator;
										return true;
									}
								}
							}
							else if (name == "CheckExploreSkillFlag")
							{
								value = ELevelGeneralCondition.CheckExploreSkillFlag;
								return true;
							}
						}
						else if (c != 'O')
						{
							if (c == 'P')
							{
								if (name == "CheckPinballLevelPass")
								{
									value = ELevelGeneralCondition.CheckPinballLevelPass;
									return true;
								}
							}
						}
						else if (name == "CheckOriginWorldLevel")
						{
							value = ELevelGeneralCondition.CheckOriginWorldLevel;
							return true;
						}
					}
					else if (c <= 'i')
					{
						if (c != 'e')
						{
							if (c == 'i')
							{
								if (name == "OnActivitySubViewDone")
								{
									value = ELevelGeneralCondition.OnActivitySubViewDone;
									return true;
								}
							}
						}
						else if (name == "OnEnterDangoMatchView")
						{
							value = ELevelGeneralCondition.OnEnterDangoMatchView;
							return true;
						}
					}
					else if (c != 'm')
					{
						if (c == 'o')
						{
							if (name == "TeamCouldEquipPhantom")
							{
								value = ELevelGeneralCondition.TeamCouldEquipPhantom;
								return true;
							}
						}
					}
					else if (name == "OnNormalTopViewChange")
					{
						value = ELevelGeneralCondition.OnNormalTopViewChange;
						return true;
					}
					break;
				}
				case 22:
				{
					char c = name[17];
					if (c <= 'L')
					{
						if (c != 'E')
						{
							if (c == 'L')
							{
								if (name == "OnMonsterNumReachLimit")
								{
									value = ELevelGeneralCondition.OnMonsterNumReachLimit;
									return true;
								}
							}
						}
						else if (name == "FinishGuideStepByEvent")
						{
							value = ELevelGeneralCondition.FinishGuideStepByEvent;
							return true;
						}
					}
					else if (c != 'S')
					{
						switch (c)
						{
						case 'd':
							if (name == "HideSettingInCloudGame")
							{
								value = ELevelGeneralCondition.HideSettingInCloudGame;
								return true;
							}
							break;
						case 'e':
							if (name == "CheckMapFocusByQuestId")
							{
								value = ELevelGeneralCondition.CheckMapFocusByQuestId;
								return true;
							}
							break;
						case 'f':
						case 'g':
						case 'i':
						case 'j':
						case 'k':
							break;
						case 'h':
							if (name == "CheckInstanceMatchAble")
							{
								value = ELevelGeneralCondition.CheckInstanceMatchAble;
								return true;
							}
							break;
						case 'l':
							if (name == "CheckKurotatoLevelWave")
							{
								value = ELevelGeneralCondition.CheckKurotatoLevelWave;
								return true;
							}
							break;
						case 'm':
							if (name == "CheckShipTowerTeamOpen")
							{
								value = ELevelGeneralCondition.CheckShipTowerTeamOpen;
								return true;
							}
							break;
						case 'n':
							if (name == "CheckFishingTechUnlock")
							{
								value = ELevelGeneralCondition.CheckFishingTechUnlock;
								return true;
							}
							break;
						default:
							switch (c)
							{
							case 'r':
								if (name == "OnMotorMusicPlayerShow")
								{
									value = ELevelGeneralCondition.OnMotorMusicPlayerShow;
									return true;
								}
								break;
							case 't':
								if (name == "CheckOperationRestrict")
								{
									value = ELevelGeneralCondition.CheckOperationRestrict;
									return true;
								}
								break;
							case 'v':
								if (name == "OnMovieRogueMapMoveEnd")
								{
									value = ELevelGeneralCondition.OnMovieRogueMapMoveEnd;
									return true;
								}
								break;
							case 'x':
								if (name == "CheckOnTreasureBoxOpen")
								{
									value = ELevelGeneralCondition.CheckOnTreasureBoxOpen;
									return true;
								}
								break;
							}
							break;
						}
					}
					else if (name == "OnKingShipAllAttrShown")
					{
						value = ELevelGeneralCondition.OnKingShipAllAttrShown;
						return true;
					}
					break;
				}
				case 23:
				{
					char c = name[18];
					if (c <= 'E')
					{
						if (c != 'C')
						{
							if (c == 'E')
							{
								if (name == "CheckPopIsTargetOrEmpty")
								{
									value = ELevelGeneralCondition.CheckPopIsTargetOrEmpty;
									return true;
								}
							}
						}
						else if (name == "CheckPinballWeaponCount")
						{
							value = ELevelGeneralCondition.CheckPinballWeaponCount;
							return true;
						}
					}
					else
					{
						switch (c)
						{
						case 'a':
							if (name == "CheckAnyRoleFullPhantom")
							{
								value = ELevelGeneralCondition.CheckAnyRoleFullPhantom;
								return true;
							}
							if (name == "CheckDangoMatchFinalEnd")
							{
								value = ELevelGeneralCondition.CheckDangoMatchFinalEnd;
								return true;
							}
							break;
						case 'b':
						case 'd':
						case 'h':
						case 'i':
						case 'j':
						case 'p':
						case 'q':
							break;
						case 'c':
							if (name == "CheckOnCostInsufficient")
							{
								value = ELevelGeneralCondition.CheckOnCostInsufficient;
								return true;
							}
							break;
						case 'e':
							if (name == "OnDangoMonopolyMoveStop")
							{
								value = ELevelGeneralCondition.OnDangoMonopolyMoveStop;
								return true;
							}
							break;
						case 'f':
							if (name == "OnMovieRogueLinkRefresh")
							{
								value = ELevelGeneralCondition.OnMovieRogueLinkRefresh;
								return true;
							}
							break;
						case 'g':
							if (name == "CheckAccountSettingOpen")
							{
								value = ELevelGeneralCondition.CheckAccountSettingOpen;
								return true;
							}
							if (name == "CheckDangoAbyssProgress")
							{
								value = ELevelGeneralCondition.CheckDangoAbyssProgress;
								return true;
							}
							if (name == "CheckQuestClosedSegment")
							{
								value = ELevelGeneralCondition.CheckQuestClosedSegment;
								return true;
							}
							break;
						case 'k':
							if (name == "LevelConditionCheckBuff")
							{
								value = ELevelGeneralCondition.CheckBuff;
								return true;
							}
							break;
						case 'l':
							if (name == "TrapDefensePassFullStar")
							{
								value = ELevelGeneralCondition.TrapDefensePassFullStar;
								return true;
							}
							break;
						case 'm':
							if (name == "OnMoraleTempExpItemShow")
							{
								value = ELevelGeneralCondition.OnMoraleTempExpItemShow;
								return true;
							}
							break;
						case 'n':
							if (name == "CheckTeleportTypeUnlock")
							{
								value = ELevelGeneralCondition.CheckTeleportTypeUnlock;
								return true;
							}
							break;
						case 'o':
							if (name == "CheckNewPlayerSupportV2")
							{
								value = ELevelGeneralCondition.CheckNewPlayerSupportV2;
								return true;
							}
							break;
						case 'r':
							if (name == "OnKingShipFirstAttrShow")
							{
								value = ELevelGeneralCondition.OnKingShipFirstAttrShow;
								return true;
							}
							break;
						default:
							if (c == 'y')
							{
								if (name == "OnPickUpHonamiStoryItem")
								{
									value = ELevelGeneralCondition.OnPickUpHonamiStoryItem;
									return true;
								}
							}
							break;
						}
					}
					break;
				}
				case 24:
				{
					char c = name[13];
					if (c <= 'a')
					{
						switch (c)
						{
						case 'C':
							if (name == "CheckEncircleChallengeId")
							{
								value = ELevelGeneralCondition.CheckEncircleChallengeId;
								return true;
							}
							break;
						case 'D':
							if (name == "OnSkillButtonDataRefresh")
							{
								value = ELevelGeneralCondition.OnSkillButtonDataRefresh;
								return true;
							}
							break;
						case 'E':
							if (name == "CheckRouletteEquipItemId")
							{
								value = ELevelGeneralCondition.CheckRouletteEquipItemId;
								return true;
							}
							break;
						case 'F':
						case 'G':
						case 'H':
							break;
						case 'I':
							if (name == "OnShowPhantomInFormation")
							{
								value = ELevelGeneralCondition.OnShowPhantomInFormation;
								return true;
							}
							break;
						default:
							if (c != 'U')
							{
								if (c == 'a')
								{
									if (name == "TrapDefenseChallengeStar")
									{
										value = ELevelGeneralCondition.TrapDefenseChallengeStar;
										return true;
									}
								}
							}
							else if (name == "CheckRogueCanUnlockSkill")
							{
								value = ELevelGeneralCondition.CheckRogueCanUnlockSkill;
								return true;
							}
							break;
						}
					}
					else if (c != 'e')
					{
						if (c != 'h')
						{
							switch (c)
							{
							case 'l':
								if (name == "OnDangoMonopolyViewStart")
								{
									value = ELevelGeneralCondition.OnDangoMonopolyViewStart;
									return true;
								}
								break;
							case 'n':
								if (name == "CheckFishingEntrustState")
								{
									value = ELevelGeneralCondition.CheckFishingEntrustState;
									return true;
								}
								break;
							case 'p':
								if (name == "OnCiacconaChapterRestart")
								{
									value = ELevelGeneralCondition.OnCiacconaChapterRestart;
									return true;
								}
								break;
							case 'r':
								if (name == "CheckCharacterTagByEvent")
								{
									value = ELevelGeneralCondition.CheckCharacterTagByEvent;
									return true;
								}
								if (name == "OnMapCustomMarkPanelShow")
								{
									value = ELevelGeneralCondition.OnMapCustomMarkPanelShow;
									return true;
								}
								break;
							case 't':
								if (name == "CheckSelfEntityCommonTag")
								{
									value = ELevelGeneralCondition.CheckSelfEntityCommonTag;
									return true;
								}
								if (name == "CheckFightPhotoHasTarget")
								{
									value = ELevelGeneralCondition.CheckFightPhotoHasTarget;
									return true;
								}
								break;
							case 'v':
								if (name == "OnWorldMapGravityBtnShow")
								{
									value = ELevelGeneralCondition.OnWorldMapGravityBtnShow;
									return true;
								}
								break;
							}
						}
						else if (name == "CheckDropCatchGameplayId")
						{
							value = ELevelGeneralCondition.CheckDropCatchGameplayId;
							return true;
						}
					}
					else if (name == "CheckRoverlikeInstPassed")
					{
						value = ELevelGeneralCondition.CheckRoverlikeInstPassed;
						return true;
					}
					break;
				}
				case 25:
				{
					char c = name[13];
					if (c <= 'M')
					{
						if (c != 'A')
						{
							if (c != 'C')
							{
								if (c == 'M')
								{
									if (name == "CheckOnSelectMenuMainType")
									{
										value = ELevelGeneralCondition.CheckOnSelectMenuMainType;
										return true;
									}
								}
							}
							else if (name == "CheckTeamRoleCouldLevelUp")
							{
								value = ELevelGeneralCondition.CheckTeamRoleCouldLevelUp;
								return true;
							}
						}
						else if (name == "CheckNoMoraleAreaFinished")
						{
							value = ELevelGeneralCondition.CheckNoMoraleAreaFinished;
							return true;
						}
					}
					else if (c != 'd')
					{
						if (c != 'e')
						{
							switch (c)
							{
							case 'n':
								if (name == "OnMapRogueEventDetailShow")
								{
									value = ELevelGeneralCondition.OnMapRogueEventDetailShow;
									return true;
								}
								break;
							case 'p':
								if (name == "OnTreasureCompassUnitShow")
								{
									value = ELevelGeneralCondition.OnTreasureCompassUnitShow;
									return true;
								}
								break;
							case 'r':
								if (name == "CheckCharacterMotionState")
								{
									value = ELevelGeneralCondition.CheckCharacterMotionState;
									return true;
								}
								break;
							case 's':
								if (name == "OnVisionIntensifyViewShow")
								{
									value = ELevelGeneralCondition.OnVisionIntensifyViewShow;
									return true;
								}
								break;
							}
						}
						else if (name == "CheckClientUseVisionSkill")
						{
							value = ELevelGeneralCondition.CheckClientUseVisionSkill;
							return true;
						}
					}
					else if (name == "IsHasRecommendRecActivity")
					{
						value = ELevelGeneralCondition.IsHasRecommendRecActivity;
						return true;
					}
					break;
				}
				case 26:
				{
					char c = name[6];
					if (c <= 'e')
					{
						if (c <= 'I')
						{
							if (c != 'D')
							{
								if (c == 'I')
								{
									if (name == "PickupInTowerDefenceBattle")
									{
										value = ELevelGeneralCondition.PickupInTowerDefenceBattle;
										return true;
									}
								}
							}
							else if (name == "OnCardDetailShowWithFactor")
							{
								value = ELevelGeneralCondition.OnCardDetailShowWithFactor;
								return true;
							}
						}
						else if (c != 'a')
						{
							if (c == 'e')
							{
								if (name == "OnSceneItemDurabilityEmpty")
								{
									value = ELevelGeneralCondition.OnSceneItemDurabilityEmpty;
									return true;
								}
							}
						}
						else if (name == "CheckGameplayClosedSegment")
						{
							value = ELevelGeneralCondition.CheckGameplayClosedSegment;
							return true;
						}
					}
					else if (c <= 'l')
					{
						if (c != 'h')
						{
							if (c == 'l')
							{
								if (name == "CheckClientQuestNodeStatus")
								{
									value = ELevelGeneralCondition.CheckClientQuestNodeStatus;
									return true;
								}
							}
						}
						else if (name == "CheckCharacterTagsRestrict")
						{
							value = ELevelGeneralCondition.CheckCharacterTagsRestrict;
							return true;
						}
					}
					else if (c != 'n')
					{
						if (c == 'u')
						{
							if (name == "CheckKurotatoLevelFinished")
							{
								value = ELevelGeneralCondition.CheckKurotatoLevelFinished;
								return true;
							}
						}
					}
					else if (name == "CheckAnyPhantomCouldUpdate")
					{
						value = ELevelGeneralCondition.CheckAnyPhantomCouldUpdate;
						return true;
					}
					break;
				}
				case 27:
				{
					char c = name[16];
					if (c <= 'R')
					{
						if (c != 'L')
						{
							if (c == 'R')
							{
								if (name == "CheckTrapDefenseRogueUnlock")
								{
									value = ELevelGeneralCondition.CheckTrapDefenseRogueUnlock;
									return true;
								}
							}
						}
						else if (name == "CheckTrapDefenseLevelFinish")
						{
							value = ELevelGeneralCondition.CheckTrapDefenseLevelFinish;
							return true;
						}
					}
					else
					{
						switch (c)
						{
						case 'e':
							if (name == "HasNotInvitedRoleInSpring25")
							{
								value = ELevelGeneralCondition.HasNotInvitedRoleInSpring25;
								return true;
							}
							break;
						case 'f':
						case 'h':
							break;
						case 'g':
							if (name == "CheckCharacterTagNotByEvent")
							{
								value = ELevelGeneralCondition.CheckCharacterTagNotByEvent;
								return true;
							}
							break;
						case 'i':
							if (name == "OnPhantomArenaChildViewShow")
							{
								value = ELevelGeneralCondition.OnPhantomArenaChildViewShow;
								return true;
							}
							break;
						default:
							if (c != 'l')
							{
								switch (c)
								{
								case 'o':
									if (name == "CheckTeamWeaponCouldLevelUp")
									{
										value = ELevelGeneralCondition.CheckTeamWeaponCouldLevelUp;
										return true;
									}
									break;
								case 'r':
									if (name == "OnCiacconaChapterFirstStart")
									{
										value = ELevelGeneralCondition.OnCiacconaChapterFirstStart;
										return true;
									}
									break;
								case 's':
									if (name == "CheckVisionIntensifyTabOpen")
									{
										value = ELevelGeneralCondition.CheckVisionIntensifyTabOpen;
										return true;
									}
									break;
								}
							}
							else if (name == "CheckFightSpecialEnergyFull")
							{
								value = ELevelGeneralCondition.CheckFightSpecialEnergyFull;
								return true;
							}
							break;
						}
					}
					break;
				}
				case 28:
				{
					char c = name[12];
					if (c <= 'i')
					{
						if (c != 'A')
						{
							switch (c)
							{
							case 'P':
								if (name == "OnDangoAbyssPluginRoleSelect")
								{
									value = ELevelGeneralCondition.OnDangoAbyssPluginRoleSelect;
									return true;
								}
								break;
							case 'Q':
							case 'S':
								break;
							case 'R':
								if (name == "CheckFishingRoleTechViewOpen")
								{
									value = ELevelGeneralCondition.CheckFishingRoleTechViewOpen;
									return true;
								}
								break;
							case 'T':
								if (name == "OnEnterWheelTowerEndlessMode")
								{
									value = ELevelGeneralCondition.OnEnterWheelTowerEndlessMode;
									return true;
								}
								break;
							default:
								switch (c)
								{
								case 'e':
									if (name == "CheckMapRogueEventDetailShow")
									{
										value = ELevelGeneralCondition.CheckMapRogueEventDetailShow;
										return true;
									}
									if (name == "CheckTrapDefenseMachineLevel")
									{
										value = ELevelGeneralCondition.CheckTrapDefenseMachineLevel;
										return true;
									}
									if (name == "CheckTrapDefenseTalentUnlock")
									{
										value = ELevelGeneralCondition.CheckTrapDefenseTalentUnlock;
										return true;
									}
									break;
								case 'g':
									if (name == "CheckMotorFightLevelFinished")
									{
										value = ELevelGeneralCondition.CheckMotorFightLevelFinished;
										return true;
									}
									break;
								case 'i':
									if (name == "OnRollBlockDifficultyChanged")
									{
										value = ELevelGeneralCondition.OnRollBlockDifficultyChanged;
										return true;
									}
									break;
								}
								break;
							}
						}
						else if (name == "CheckPhantomArenaChallengeId")
						{
							value = ELevelGeneralCondition.CheckPhantomArenaChallengeId;
							return true;
						}
					}
					else if (c <= 'o')
					{
						if (c != 'n')
						{
							if (c == 'o')
							{
								if (name == "CheckFightPhotoLevelFinished")
								{
									value = ELevelGeneralCondition.CheckFightPhotoLevelFinished;
									return true;
								}
							}
						}
						else if (name == "ForMoonChasingCheckTaskState")
						{
							value = ELevelGeneralCondition.ForMoonChasingCheckTaskState;
							return true;
						}
					}
					else if (c != 't')
					{
						if (c == 'y')
						{
							if (name == "CheckDangoAbyssHasItemByType")
							{
								value = ELevelGeneralCondition.CheckDangoAbyssHasItemByType;
								return true;
							}
						}
					}
					else if (name == "CheckDangoMatchPlayerNumType")
					{
						value = ELevelGeneralCondition.CheckDangoMatchPlayerNumType;
						return true;
					}
					break;
				}
				case 29:
				{
					char c = name[17];
					if (c <= 'e')
					{
						if (c <= 'H')
						{
							if (c != 'G')
							{
								if (c == 'H')
								{
									if (name == "CheckDockyardWareHouseHasItem")
									{
										value = ELevelGeneralCondition.CheckDockyardWareHouseHasItem;
										return true;
									}
								}
							}
							else if (name == "OnTrapDefenseBuffGroupUpgrade")
							{
								value = ELevelGeneralCondition.OnTrapDefenseBuffGroupUpgrade;
								return true;
							}
						}
						else if (c != 'c')
						{
							if (c == 'e')
							{
								if (name == "CheckHasSkinInRoleSkinSubView")
								{
									value = ELevelGeneralCondition.CheckHasSkinInRoleSkinSubView;
									return true;
								}
							}
						}
						else if (name == "ForMoonChasingCheckNeedBranch")
						{
							value = ELevelGeneralCondition.ForMoonChasingCheckNeedBranch;
							return true;
						}
					}
					else if (c <= 'n')
					{
						if (c != 'i')
						{
							if (c == 'n')
							{
								if (name == "ForMoonChasingOpenInteractive")
								{
									value = ELevelGeneralCondition.ForMoonChasingOpenInteractive;
									return true;
								}
							}
						}
						else if (name == "CheckHasUnlockAffixInBossRush")
						{
							value = ELevelGeneralCondition.CheckHasUnlockAffixInBossRush;
							return true;
						}
					}
					else if (c != 'o')
					{
						if (c == 'y')
						{
							if (name == "OnPhantomArenaPlayFieldEffect")
							{
								value = ELevelGeneralCondition.OnPhantomArenaPlayFieldEffect;
								return true;
							}
						}
					}
					else if (name == "OnSurvivorsRogueComboBuffShow")
					{
						value = ELevelGeneralCondition.OnSurvivorsRogueComboBuffShow;
						return true;
					}
					break;
				}
				case 30:
				{
					char c = name[5];
					if (c <= 'S')
					{
						if (c <= 'F')
						{
							if (c != 'C')
							{
								if (c == 'F')
								{
									if (name == "CheckFishingQteBtnHitValidArea")
									{
										value = ELevelGeneralCondition.CheckFishingQteBtnHitValidArea;
										return true;
									}
								}
							}
							else if (name == "CheckCalabashChildFunctionOpen")
							{
								value = ELevelGeneralCondition.CheckCalabashChildFunctionOpen;
								return true;
							}
						}
						else if (c != 'H')
						{
							switch (c)
							{
							case 'M':
								if (name == "CheckMotorMovieModeStateChange")
								{
									value = ELevelGeneralCondition.CheckMotorMovieModeStateChange;
									return true;
								}
								break;
							case 'P':
								if (name == "CheckPickUpHonamiStoryItemType")
								{
									value = ELevelGeneralCondition.CheckPickUpHonamiStoryItemType;
									return true;
								}
								break;
							case 'R':
								if (name == "CheckRhythmShipSubLevelHasRank")
								{
									value = ELevelGeneralCondition.CheckRhythmShipSubLevelHasRank;
									return true;
								}
								break;
							case 'S':
								if (name == "CheckSubPackageDownLoadBtnShow")
								{
									value = ELevelGeneralCondition.CheckSubPackageDownLoadBtnShow;
									return true;
								}
								break;
							}
						}
						else if (name == "CheckHasFirstPhantomAtPosition")
						{
							value = ELevelGeneralCondition.CheckHasFirstPhantomAtPosition;
							return true;
						}
					}
					else if (c <= 'a')
					{
						if (c != 'W')
						{
							if (c == 'a')
							{
								if (name == "OnHonamiStoryLifeSupportChange")
								{
									value = ELevelGeneralCondition.OnHonamiStoryLifeSupportChange;
									return true;
								}
							}
						}
						else if (name == "CheckWorldMapSecondaryUiOpened")
						{
							value = ELevelGeneralCondition.CheckWorldMapSecondaryUiOpened;
							return true;
						}
					}
					else if (c != 'l')
					{
						if (c != 'p')
						{
							if (c == 'v')
							{
								if (name == "OnSurvivorsRoguePopViewRefresh")
								{
									value = ELevelGeneralCondition.OnSurvivorsRoguePopViewRefresh;
									return true;
								}
							}
						}
						else
						{
							if (name == "OnTrapDefenseDeployingBuilding")
							{
								value = ELevelGeneralCondition.OnTrapDefenseDeployingBuilding;
								return true;
							}
							if (name == "OnTrapDefenseMainLevelViewOpen")
							{
								value = ELevelGeneralCondition.OnTrapDefenseMainLevelViewOpen;
								return true;
							}
						}
					}
					else if (name == "RoguelikeHasSelectEntryAndShow")
					{
						value = ELevelGeneralCondition.RoguelikeHasSelectEntryAndShow;
						return true;
					}
					break;
				}
				case 31:
				{
					char c = name[9];
					if (c <= 'Q')
					{
						if (c != 'B')
						{
							if (c != 'D')
							{
								if (c == 'Q')
								{
									if (name == "OnFishingQteScoreReachedMaximum")
									{
										value = ELevelGeneralCondition.OnFishingQteScoreReachedMaximum;
										return true;
									}
								}
							}
							else if (name == "CheckTrapDefenseTalentCanUnlock")
							{
								value = ELevelGeneralCondition.CheckTrapDefenseTalentCanUnlock;
								return true;
							}
						}
						else if (name == "OnFishingBackpackBtnStateChange")
						{
							value = ELevelGeneralCondition.OnFishingBackpackBtnStateChange;
							return true;
						}
					}
					else if (c != 'a')
					{
						if (c != 'i')
						{
							if (c == 'o')
							{
								if (name == "CheckFloroRanchHasTechCanUnlock")
								{
									value = ELevelGeneralCondition.CheckFloroRanchHasTechCanUnlock;
									return true;
								}
							}
						}
						else if (name == "CheckSurvivorRogueHasWeaponBond")
						{
							value = ELevelGeneralCondition.CheckSurvivorRogueHasWeaponBond;
							return true;
						}
					}
					else if (name == "CheckCharacterVehicleTagByEvent")
					{
						value = ELevelGeneralCondition.CheckCharacterVehicleTagByEvent;
						return true;
					}
					break;
				}
				case 32:
				{
					char c = name[12];
					if (c != 'C')
					{
						if (c == 'S')
						{
							if (name == "OnFloroRanchStageStartTaskFinish")
							{
								value = ELevelGeneralCondition.OnFloroRanchStageStartTaskFinish;
								return true;
							}
						}
					}
					else if (name == "OnFloroRanchCardCountReachTarget")
					{
						value = ELevelGeneralCondition.OnFloroRanchCardCountReachTarget;
						return true;
					}
					break;
				}
				case 33:
				{
					char c = name[5];
					if (c <= 'P')
					{
						if (c != 'F')
						{
							if (c != 'I')
							{
								if (c == 'P')
								{
									if (name == "CheckPureModeWhenBattleViewActive")
									{
										value = ELevelGeneralCondition.CheckPureModeWhenBattleViewActive;
										return true;
									}
								}
							}
							else if (name == "CheckInstanceEntranceUnlockStatus")
							{
								value = ELevelGeneralCondition.CheckInstanceEntranceUnlockStatus;
								return true;
							}
						}
						else if (name == "CheckFishingDockyardItemTipsShown")
						{
							value = ELevelGeneralCondition.CheckFishingDockyardItemTipsShown;
							return true;
						}
					}
					else if (c <= 'g')
					{
						if (c != 'S')
						{
							if (c == 'g')
							{
								if (name == "OnDangoMonopolyViewShowProcessEnd")
								{
									value = ELevelGeneralCondition.OnDangoMonopolyViewShowProcessEnd;
									return true;
								}
							}
						}
						else if (name == "CheckSurvivorRogueTalentCanUnlock")
						{
							value = ELevelGeneralCondition.CheckSurvivorRogueTalentCanUnlock;
							return true;
						}
					}
					else if (c != 'n')
					{
						if (c == 'v')
						{
							if (name == "OnSurvivorsRogueEndlessToggleShow")
							{
								value = ELevelGeneralCondition.OnSurvivorsRogueEndlessToggleShow;
								return true;
							}
						}
					}
					else if (name == "OnPhantomArenaChooseCardPanelShow")
					{
						value = ELevelGeneralCondition.OnPhantomArenaChooseCardPanelShow;
						return true;
					}
					break;
				}
				case 34:
				{
					char c = name[13];
					if (c <= 'a')
					{
						if (c != 'I')
						{
							if (c != 'R')
							{
								if (c == 'a')
								{
									if (name == "OnPhantomArenaDiscardCardPanelShow")
									{
										value = ELevelGeneralCondition.OnPhantomArenaDiscardCardPanelShow;
										return true;
									}
								}
							}
							else if (name == "CheckPositionRolePhantomSkillEquip")
							{
								value = ELevelGeneralCondition.CheckPositionRolePhantomSkillEquip;
								return true;
							}
						}
						else if (name == "OnCiacconaAvgInspirationChoiceShow")
						{
							value = ELevelGeneralCondition.OnCiacconaAvgInspirationChoiceShow;
							return true;
						}
					}
					else if (c != 'e')
					{
						if (c != 'g')
						{
							switch (c)
							{
							case 'o':
								if (name == "CheckDangoMonopolyHasFinishedRound")
								{
									value = ELevelGeneralCondition.CheckDangoMonopolyHasFinishedRound;
									return true;
								}
								break;
							case 'q':
								if (name == "OnDangoAbyssEquipPluginWithInvalid")
								{
									value = ELevelGeneralCondition.OnDangoAbyssEquipPluginWithInvalid;
									return true;
								}
								break;
							case 'r':
								if (name == "CheckCharacterVehicleTagNotByEvent")
								{
									value = ELevelGeneralCondition.CheckCharacterVehicleTagNotByEvent;
									return true;
								}
								break;
							case 'u':
								if (name == "CheckMovieRogueFinishedEndingCount")
								{
									value = ELevelGeneralCondition.CheckMovieRogueFinishedEndingCount;
									return true;
								}
								break;
							}
						}
						else if (name == "OnFlagChallengeCalculatedLevelOver")
						{
							value = ELevelGeneralCondition.OnFlagChallengeCalculatedLevelOver;
							return true;
						}
					}
					else if (name == "CheckAnyMoraleAreaFinishWithReward")
					{
						value = ELevelGeneralCondition.CheckAnyMoraleAreaFinishWithReward;
						return true;
					}
					break;
				}
				case 35:
				{
					char c = name[19];
					if (c <= 'e')
					{
						if (c != 'M')
						{
							if (c != 'T')
							{
								if (c == 'e')
								{
									if (name == "OnTrapDefenseMachineCanChooseBranch")
									{
										value = ELevelGeneralCondition.OnTrapDefenseMachineCanChooseBranch;
										return true;
									}
								}
							}
							else if (name == "ForMoonChasingCheckTargetBuiltCount")
							{
								value = ELevelGeneralCondition.ForMoonChasingCheckTargetBuiltCount;
								return true;
							}
						}
						else if (name == "ForMoonChasingCheckMainlineTaskDone")
						{
							value = ELevelGeneralCondition.ForMoonChasingCheckMainlineTaskDone;
							return true;
						}
					}
					else if (c != 'm')
					{
						if (c != 's')
						{
							if (c == 't')
							{
								if (name == "OnDangoAbyssEnterWithTeamExploreBtn")
								{
									value = ELevelGeneralCondition.OnDangoAbyssEnterWithTeamExploreBtn;
									return true;
								}
							}
						}
						else if (name == "CheckFishingWareHouseItemListLength")
						{
							value = ELevelGeneralCondition.CheckFishingWareHouseItemListLength;
							return true;
						}
					}
					else if (name == "CheckInteractiveItemsFunctionEnable")
					{
						value = ELevelGeneralCondition.CheckInteractiveItemsFunctionEnable;
						return true;
					}
					break;
				}
				case 36:
				{
					char c = name[0];
					if (c != 'C')
					{
						if (c == 'O')
						{
							if (name == "OnFishingBackpackQuickSellToggleShow")
							{
								value = ELevelGeneralCondition.OnFishingBackpackQuickSellToggleShow;
								return true;
							}
						}
					}
					else if (name == "CheckTrapDefenseHasCanUpgradeMachine")
					{
						value = ELevelGeneralCondition.CheckTrapDefenseHasCanUpgradeMachine;
						return true;
					}
					break;
				}
				case 37:
				{
					char c = name[0];
					if (c != 'C')
					{
						if (c != 'F')
						{
							if (c == 'O')
							{
								if (name == "OnDangoMonopolyCameraFocusOnMainDango")
								{
									value = ELevelGeneralCondition.OnDangoMonopolyCameraFocusOnMainDango;
									return true;
								}
							}
						}
						else if (name == "ForMoonChasingCheckHasNotFinishedTask")
						{
							value = ELevelGeneralCondition.ForMoonChasingCheckHasNotFinishedTask;
							return true;
						}
					}
					else if (name == "CheckCurFishingEntrustAvailablePeriod")
					{
						value = ELevelGeneralCondition.CheckCurFishingEntrustAvailablePeriod;
						return true;
					}
					break;
				}
				case 38:
					if (name == "OnDangoAbyssEquipPluginWithValidChange")
					{
						value = ELevelGeneralCondition.OnDangoAbyssEquipPluginWithValidChange;
						return true;
					}
					break;
				case 39:
				{
					char c = name[2];
					if (c != 'M')
					{
						if (c == 'S')
						{
							if (name == "OnSurvivorsRogueWeaponDetailTabViewShow")
							{
								value = ELevelGeneralCondition.OnSurvivorsRogueWeaponDetailTabViewShow;
								return true;
							}
						}
					}
					else if (name == "OnMovieRogueInfoRefreshWithMultipleEnds")
					{
						value = ELevelGeneralCondition.OnMovieRogueInfoRefreshWithMultipleEnds;
						return true;
					}
					break;
				}
				case 40:
					if (name == "ForMoonChasingCheckHasCanLevelUpBuilding")
					{
						value = ELevelGeneralCondition.ForMoonChasingCheckHasCanLevelUpBuilding;
						return true;
					}
					break;
				case 41:
				{
					char c = name[2];
					if (c != 'F')
					{
						if (c == 'T')
						{
							if (name == "OnTrapDefenseAuxiliaryMachineUpgradeToMax")
							{
								value = ELevelGeneralCondition.OnTrapDefenseAuxiliaryMachineUpgradeToMax;
								return true;
							}
						}
					}
					else if (name == "OnFloroRanchSettleViewOpenWithEndlessMode")
					{
						value = ELevelGeneralCondition.OnFloroRanchSettleViewOpenWithEndlessMode;
						return true;
					}
					break;
				}
				case 42:
					if (name == "OnTrapDefenseBuildingDevelopPreviewBtnShow")
					{
						value = ELevelGeneralCondition.OnTrapDefenseBuildingDevelopPreviewBtnShow;
						return true;
					}
					break;
				case 44:
				{
					char c = name[0];
					if (c != 'C')
					{
						if (c == 'O')
						{
							if (name == "OnTrapDefenseBuildingDevelopBottomLayoutShow")
							{
								value = ELevelGeneralCondition.OnTrapDefenseBuildingDevelopBottomLayoutShow;
								return true;
							}
						}
					}
					else if (name == "CheckIsShowProgressBarInMapExploreDetailView")
					{
						value = ELevelGeneralCondition.CheckIsShowProgressBarInMapExploreDetailView;
						return true;
					}
					break;
				}
				}
			}
			value = ELevelGeneralCondition.DistanceLess;
			return false;
		}

		// Token: 0x060435DB RID: 275931 RVA: 0x011586D8 File Offset: 0x011568D8
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"DistanceLess",
				"SelfTagCheck",
				"ItemCheck",
				"CheckItemWithOperator",
				"CheckDis",
				"TargetTagCheck",
				"CheckOnTrap",
				"CheckDirection",
				"QuestState",
				"CheckStrikeInfo",
				"CheckLevel",
				"CheckLevelOp",
				"CheckGuideStatus",
				"CheckCharacterTag",
				"CheckCharacterTagByEvent",
				"CheckCharacterTagNotByEvent",
				"CheckCharacterVehicleTagByEvent",
				"CheckCharacterVehicleTagNotByEvent",
				"DragonPoolState",
				"SceneStepState",
				"CheckTeleportStatus",
				"RoleLevel",
				"CheckRoleLevel",
				"CheckRoleOwned",
				"RoleBreach",
				"SelfGameplayTagCheck",
				"CheckInTodTimeSpan",
				"CheckEntityCommonTag",
				"IsPlayer",
				"CheckEntityConfigId",
				"CheckSelfEntityCommonTag",
				"CheckInstanceEntranceUnlockStatus",
				"CheckOriginWorldLevel",
				"CheckCurWorldLevel",
				"CheckCurWorldLevelOp",
				"StartShootTarget",
				"CheckInstanceState",
				"CheckInstanceMatchAble",
				"MoveStateCheck",
				"LevelConditionCheckBuff",
				"CheckUIState",
				"CheckUIOpen",
				"CheckUIOpenDone",
				"CheckUIShowDone",
				"CheckInputAction",
				"CheckClientUseSkill",
				"CheckClientUseVisionSkill",
				"CheckBattleRole",
				"CheckEquippedPhantom",
				"CheckEnemyBuff",
				"CheckEnemyTag",
				"CheckSkillPoint",
				"CheckExploreSkill",
				"CheckFightEnergyBar",
				"CheckFightEnergyBall",
				"FunctionUnlock",
				"GetNewItem",
				"HarmonyQte",
				"GetWhichRole",
				"HpLowerThan",
				"FightWithMonster",
				"PawnInRange",
				"SlotOfCurrentRole",
				"PhantomTargetLevel",
				"CheckClientQuest",
				"CheckClientQuestNode",
				"PhantomMaxLevel",
				"RoleTargetLevel",
				"RoleSkillTargetLevel",
				"BattleRoleIsNot",
				"BattleRoleWeaponType",
				"FormationAnyRoleDead",
				"ComboTeachingState",
				"OnViewClose",
				"OnPlayerUseSkill",
				"OnSkillButtonDataRefresh",
				"FinishGuideStepByEvent",
				"PlayerRevive",
				"CheckTeamRoleCouldLevelUp",
				"CheckTeamWeaponCouldLevelUp",
				"ClientCalabashLevel",
				"TeamRoleLevel",
				"TeamWeaponLevel",
				"TeamCouldEquipPhantom",
				"CheckAnyPhantomCouldUpdate",
				"CheckAnyRoleFullPhantom",
				"CheckRolePhantomNum",
				"CheckItemCountByType",
				"CheckRouletteEquipItemId",
				"CheckVisionIntensifyTabOpen",
				"CheckAccountSettingOpen",
				"CheckOnTreasureBoxOpen",
				"CheckWeaponCount",
				"CheckOnCostInsufficient",
				"CheckRangeByPbDataId",
				"CheckDungeonId",
				"CheckRogueTerm",
				"CheckTeleportTypeUnlock",
				"CheckTypeItemPickUp",
				"CheckDungeonFinished",
				"CheckRogueCanUnlockSkill",
				"CheckPositionRolePhantomSkillEquip",
				"CheckHasFirstPhantomAtPosition",
				"CheckWorldMapSecondaryUiOpened",
				"CheckHasUnlockAffixInBossRush",
				"OnChangeBossRushBuff",
				"RoguelikeHasSelectEntryAndShow",
				"CheckActivityOpen",
				"CheckHasSkinInRoleSkinSubView",
				"OnTakingPhoto",
				"HasNotInvitedRoleInSpring25",
				"CheckMapFocusByQuestId",
				"OnWorldMapGravityBtnShow",
				"PickupInTowerDefenceBattle",
				"CheckOnSelectMenuMainType",
				"OnShowPhantomInFormation",
				"ForMoonChasingCheckTargetBuiltCount",
				"ForMoonChasingCheckHasCanLevelUpBuilding",
				"ForMoonChasingCheckNeedBranch",
				"ForMoonChasingCheckHasNotFinishedTask",
				"ForMoonChasingCheckTaskState",
				"ForMoonChasingCheckMainlineTaskDone",
				"ForMoonChasingOpenInteractive",
				"CheckPureModeWhenBattleViewActive",
				"OnActivitySubViewDone",
				"CheckLockEnemyMode",
				"CheckIsShowProgressBarInMapExploreDetailView",
				"CheckIsMulti",
				"CheckFishingRoleTechViewOpen",
				"CheckFishingDockyardItemTipsShown",
				"CheckShipTowerTeamOpen",
				"CheckDockyardWareHouseHasItem",
				"CheckFishingQteBtnHitValidArea",
				"OnFishingQteScoreReachedMaximum",
				"CheckFishingTechUnlock",
				"OnFishingBackpackBtnStateChange",
				"CheckFishingEntrustState",
				"CheckFishingWareHouseItemListLength",
				"CheckCurFishingEntrustAvailablePeriod",
				"OnTreasureCompassUnitShow",
				"OnFishingBackpackQuickSellToggleShow",
				"HideSettingInCloudGame",
				"OnPlayerTitleUnlock",
				"CheckDangoMonopolyHasFinishedRound",
				"OnDangoMonopolyMoveStop",
				"OnDangoMonopolyViewShowProcessEnd",
				"OnDangoAbyssPluginRoleSelect",
				"CheckDangoMatchState",
				"CheckDangoMatchPlayerNumType",
				"OnEnterDangoMatchView",
				"OnDangoMonopolyViewStart",
				"OnCiacconaAvgInspirationChoiceShow",
				"OnCiacconaChapterFirstStart",
				"OnCiacconaChapterRestart",
				"OnMovieRogueInfoRefreshWithMultipleEnds",
				"CheckMovieRogueFinishedEndingCount",
				"OnDangoAbyssEnterWithTeamExploreBtn",
				"OnDangoAbyssEquipPluginWithValidChange",
				"OnDangoAbyssEquipPluginWithInvalid",
				"OnMovieRogueLinkRefresh",
				"OnMovieRogueMapMoveEnd",
				"OnMapRogueEventDetailShow",
				"CheckMapRogueEventDetailShow",
				"OnDangoMonopolyCameraFocusOnMainDango",
				"CheckDangoAbyssProgress",
				"CheckDangoAbyssHasItemByType",
				"CheckDangoMatchFinalEnd",
				"CheckGridHasExplored",
				"GolemHackingID",
				"WeeklyChallengeOpen",
				"OnUiTabViewShow",
				"OnNewViewCovered",
				"OnHandCardsShow",
				"OnCardDetailShowWithFactor",
				"OnMonsterNumReachLimit",
				"OnGetSpCard",
				"CheckPhantomArenaChallengeId",
				"CheckClientQuestNodeStatus",
				"CheckAnyMoraleAreaFinishWithReward",
				"OnMoraleTempExpItemShow",
				"OnPhantomArenaChildViewShow",
				"CheckNoMoraleAreaFinished",
				"OnFloroRanchCardCountReachTarget",
				"CheckFloroRanchRound",
				"FloroRanchActivityID",
				"CheckFloroRanchHasTechCanUnlock",
				"OnKingShipFirstAttrShow",
				"OnKingShipAllAttrShown",
				"OnFloroRanchSettleViewOpenWithEndlessMode",
				"CheckFloroRanchLevel",
				"OnFloroRanchStageStartTaskFinish",
				"CheckTrapDefenseTalentCanUnlock",
				"CheckTrapDefenseHasCanUpgradeMachine",
				"OnTrapDefenseAuxiliaryMachineUpgradeToMax",
				"OnTrapDefenseMachineCanChooseBranch",
				"CheckTrapDefenseLevelFinish",
				"CheckTrapDefenseRogueUnlock",
				"OnTrapDefenseBuffGroupUpgrade",
				"TrapDefenseTotalStar",
				"TrapDefensePassFullStar",
				"TrapDefenseChallengeStar",
				"OnTrapDefenseBuildingDevelopPreviewBtnShow",
				"OnTrapDefenseDeployingBuilding",
				"OnTrapDefenseBuildingDevelopBottomLayoutShow",
				"CheckTrapDefenseMachineLevel",
				"CheckTrapDefenseTalentUnlock",
				"OnTrapDefenseMainLevelViewOpen",
				"OnVisionIntensifyViewShow",
				"OnSurvivorsRogueEndlessToggleShow",
				"OnSurvivorsRogueComboBuffShow",
				"CheckFightPhotoHasTarget",
				"CheckFightPhotoLevelFinished",
				"CheckCalabashChildFunctionOpen",
				"OnSurvivorsRoguePopViewRefresh",
				"CheckSurvivorRogueTalentCanUnlock",
				"CheckSurvivorRogueHasWeaponBond",
				"OnSurvivorsRogueWeaponDetailTabViewShow",
				"AlwaysFalse",
				"OnEnterOrExitBattle",
				"OnHonamiStoryLifeSupportChange",
				"OnPickUpHonamiStoryItem",
				"OnSceneItemDurabilityEmpty",
				"CheckPickUpHonamiStoryItemType",
				"IsHasRecommendRecActivity",
				"CheckMotorMovieModeStateChange",
				"OnMotorMusicPlayerShow",
				"OnMapCustomMarkPanelShow",
				"OnPhantomArenaChooseCardPanelShow",
				"OnPhantomArenaDiscardCardPanelShow",
				"OnMotorDiyViewShow",
				"OnPhantomArenaPlayFieldEffect",
				"OnRollBlockDifficultyChanged",
				"CheckDungeonTypes",
				"OnEnterWheelTowerEndlessMode",
				"OnGuideTriggerEvent",
				"CheckUiItemShow",
				"CheckExploreSkillFlag",
				"CheckGuessJokerRound",
				"CheckMotorFightLevelFinished",
				"CheckEncircleChallengeId",
				"OnFlagChallengeCalculatedLevelOver",
				"CheckTetrisLevelId",
				"CheckRhythmShipSubLevelHasRank",
				"CheckDropCatchGameplayId",
				"CheckTetrisScore",
				"CheckNewPlayerSupportV2",
				"CheckPinballLevelPass",
				"CheckPinballWeaponCount",
				"OnNormalTopViewChange",
				"CheckPopIsTargetOrEmpty",
				"CheckKurotatoLevelWave",
				"CheckKurotatoLevelFinished",
				"CheckTrialRole",
				"CheckInteractiveItemsFunctionEnable",
				"CheckPhantomTeam",
				"CheckTrialAssist",
				"CheckQuestClosedSegment",
				"CheckGameplayClosedSegment",
				"CheckOperationRestrict",
				"CheckCameraMode",
				"CheckCharacterMotionState",
				"CheckCharacterTagsRestrict",
				"CheckInteracting",
				"CheckRoverlikeInstPassed",
				"CheckSubPackageDownLoadBtnShow",
				"CheckFightSpecialEnergyFull",
				"CheckNewbieGuideV2"
			};
		}

		// Token: 0x060435DC RID: 275932 RVA: 0x011591EA File Offset: 0x011573EA
		public static ELevelGeneralCondition[] GetValues()
		{
			return new ELevelGeneralCondition[]
			{
				ELevelGeneralCondition.DistanceLess,
				ELevelGeneralCondition.SelfTagCheck,
				ELevelGeneralCondition.ItemCheck,
				ELevelGeneralCondition.CheckItemWithOperator,
				ELevelGeneralCondition.CheckDis,
				ELevelGeneralCondition.TargetTagCheck,
				ELevelGeneralCondition.CheckOnTrap,
				ELevelGeneralCondition.CheckDirection,
				ELevelGeneralCondition.QuestState,
				ELevelGeneralCondition.CheckStrikeInfo,
				ELevelGeneralCondition.CheckLevel,
				ELevelGeneralCondition.CheckLevelOp,
				ELevelGeneralCondition.CheckGuideStatus,
				ELevelGeneralCondition.CheckCharacterTag,
				ELevelGeneralCondition.CheckCharacterTagByEvent,
				ELevelGeneralCondition.CheckCharacterTagNotByEvent,
				ELevelGeneralCondition.CheckCharacterVehicleTagByEvent,
				ELevelGeneralCondition.CheckCharacterVehicleTagNotByEvent,
				ELevelGeneralCondition.DragonPoolState,
				ELevelGeneralCondition.SceneStepState,
				ELevelGeneralCondition.CheckTeleportStatus,
				ELevelGeneralCondition.RoleLevel,
				ELevelGeneralCondition.CheckRoleLevel,
				ELevelGeneralCondition.CheckRoleOwned,
				ELevelGeneralCondition.RoleBreach,
				ELevelGeneralCondition.SelfGameplayTagCheck,
				ELevelGeneralCondition.CheckInTodTimeSpan,
				ELevelGeneralCondition.CheckSceneItemTag,
				ELevelGeneralCondition.IsPlayer,
				ELevelGeneralCondition.CheckEntityConfigId,
				ELevelGeneralCondition.CheckSelfEntityCommonTag,
				ELevelGeneralCondition.CheckInstanceEntranceUnlockStatus,
				ELevelGeneralCondition.CheckOriginWorldLevel,
				ELevelGeneralCondition.CheckCurWorldLevel,
				ELevelGeneralCondition.CheckCurWorldLevelOp,
				ELevelGeneralCondition.StartShootTarget,
				ELevelGeneralCondition.CheckInstanceState,
				ELevelGeneralCondition.CheckInstanceMatchAble,
				ELevelGeneralCondition.MoveStateCheck,
				ELevelGeneralCondition.CheckBuff,
				ELevelGeneralCondition.CheckUIState,
				ELevelGeneralCondition.CheckUIOpen,
				ELevelGeneralCondition.CheckUIOpenDone,
				ELevelGeneralCondition.CheckUIShowDone,
				ELevelGeneralCondition.CheckInputAction,
				ELevelGeneralCondition.CheckClientUseSkill,
				ELevelGeneralCondition.CheckClientUseVisionSkill,
				ELevelGeneralCondition.CheckBattleRole,
				ELevelGeneralCondition.CheckEquippedPhantom,
				ELevelGeneralCondition.CheckEnemyBuff,
				ELevelGeneralCondition.CheckEnemyTag,
				ELevelGeneralCondition.CheckSkillPoint,
				ELevelGeneralCondition.CheckExploreSkill,
				ELevelGeneralCondition.CheckFightEnergyBar,
				ELevelGeneralCondition.CheckFightEnergyBall,
				ELevelGeneralCondition.FunctionUnlock,
				ELevelGeneralCondition.GetNewItem,
				ELevelGeneralCondition.HarmonyQte,
				ELevelGeneralCondition.GetWhichRole,
				ELevelGeneralCondition.HpLowerThan,
				ELevelGeneralCondition.FightWithMonster,
				ELevelGeneralCondition.PawnInRange,
				ELevelGeneralCondition.SlotOfCurrentRole,
				ELevelGeneralCondition.PhantomTargetLevel,
				ELevelGeneralCondition.CheckClientQuest,
				ELevelGeneralCondition.CheckClientQuestNode,
				ELevelGeneralCondition.PhantomMaxLevel,
				ELevelGeneralCondition.RoleTargetLevel,
				ELevelGeneralCondition.RoleSkillTargetLevel,
				ELevelGeneralCondition.BattleRoleIsNot,
				ELevelGeneralCondition.BattleRoleWeaponType,
				ELevelGeneralCondition.FormationAnyRoleDead,
				ELevelGeneralCondition.ComboTeachingState,
				ELevelGeneralCondition.OnViewClose,
				ELevelGeneralCondition.OnPlayerUseSkill,
				ELevelGeneralCondition.OnSkillButtonDataRefresh,
				ELevelGeneralCondition.FinishGuideStepByEvent,
				ELevelGeneralCondition.PlayerRevive,
				ELevelGeneralCondition.CheckTeamRoleCouldLevelUp,
				ELevelGeneralCondition.CheckTeamWeaponCouldLevelUp,
				ELevelGeneralCondition.ClientCalabashLevel,
				ELevelGeneralCondition.TeamRoleLevel,
				ELevelGeneralCondition.TeamWeaponLevel,
				ELevelGeneralCondition.TeamCouldEquipPhantom,
				ELevelGeneralCondition.CheckAnyPhantomCouldUpdate,
				ELevelGeneralCondition.CheckAnyRoleFullPhantom,
				ELevelGeneralCondition.CheckRolePhantomNum,
				ELevelGeneralCondition.CheckItemCountByType,
				ELevelGeneralCondition.CheckRouletteEquipItemId,
				ELevelGeneralCondition.CheckVisionIntensifyTabOpen,
				ELevelGeneralCondition.CheckAccountSettingOpen,
				ELevelGeneralCondition.CheckOnTreasureBoxOpen,
				ELevelGeneralCondition.CheckWeaponCount,
				ELevelGeneralCondition.CheckOnCostInsufficient,
				ELevelGeneralCondition.CheckRangeByPbDataId,
				ELevelGeneralCondition.CheckDungeonId,
				ELevelGeneralCondition.CheckRogueTerm,
				ELevelGeneralCondition.CheckTeleportTypeUnlock,
				ELevelGeneralCondition.CheckTypeItemPickUp,
				ELevelGeneralCondition.CheckDungeonFinished,
				ELevelGeneralCondition.CheckRogueCanUnlockSkill,
				ELevelGeneralCondition.CheckPositionRolePhantomSkillEquip,
				ELevelGeneralCondition.CheckHasFirstPhantomAtPosition,
				ELevelGeneralCondition.CheckWorldMapSecondaryUiOpened,
				ELevelGeneralCondition.CheckHasUnlockAffixInBossRush,
				ELevelGeneralCondition.OnChangeBossRushBuff,
				ELevelGeneralCondition.RoguelikeHasSelectEntryAndShow,
				ELevelGeneralCondition.CheckActivityOpen,
				ELevelGeneralCondition.CheckHasSkinInRoleSkinSubView,
				ELevelGeneralCondition.OnTakingPhoto,
				ELevelGeneralCondition.HasNotInvitedRoleInSpring25,
				ELevelGeneralCondition.CheckMapFocusByQuestId,
				ELevelGeneralCondition.OnWorldMapGravityBtnShow,
				ELevelGeneralCondition.PickupInTowerDefenceBattle,
				ELevelGeneralCondition.CheckOnSelectMenuMainType,
				ELevelGeneralCondition.OnShowPhantomInFormation,
				ELevelGeneralCondition.ForMoonChasingCheckTargetBuiltCount,
				ELevelGeneralCondition.ForMoonChasingCheckHasCanLevelUpBuilding,
				ELevelGeneralCondition.ForMoonChasingCheckNeedBranch,
				ELevelGeneralCondition.ForMoonChasingCheckHasNotFinishedTask,
				ELevelGeneralCondition.ForMoonChasingCheckTaskState,
				ELevelGeneralCondition.ForMoonChasingCheckMainlineTaskDone,
				ELevelGeneralCondition.ForMoonChasingOpenInteractive,
				ELevelGeneralCondition.CheckPureModeWhenBattleViewActive,
				ELevelGeneralCondition.OnActivitySubViewDone,
				ELevelGeneralCondition.CheckLockEnemyMode,
				ELevelGeneralCondition.CheckIsShowProgressBarInMapExploreDetailView,
				ELevelGeneralCondition.CheckIsMulti,
				ELevelGeneralCondition.CheckFishingRoleTechViewOpen,
				ELevelGeneralCondition.CheckFishingDockyardItemTipsShown,
				ELevelGeneralCondition.CheckShipTowerTeamOpen,
				ELevelGeneralCondition.CheckDockyardWareHouseHasItem,
				ELevelGeneralCondition.CheckFishingQteBtnHitValidArea,
				ELevelGeneralCondition.OnFishingQteScoreReachedMaximum,
				ELevelGeneralCondition.CheckFishingTechUnlock,
				ELevelGeneralCondition.OnFishingBackpackBtnStateChange,
				ELevelGeneralCondition.CheckFishingEntrustState,
				ELevelGeneralCondition.CheckFishingWareHouseItemListLength,
				ELevelGeneralCondition.CheckCurFishingEntrustAvailablePeriod,
				ELevelGeneralCondition.OnTreasureCompassUnitShow,
				ELevelGeneralCondition.OnFishingBackpackQuickSellToggleShow,
				ELevelGeneralCondition.HideSettingInCloudGame,
				ELevelGeneralCondition.OnPlayerTitleUnlock,
				ELevelGeneralCondition.CheckDangoMonopolyHasFinishedRound,
				ELevelGeneralCondition.OnDangoMonopolyMoveStop,
				ELevelGeneralCondition.OnDangoMonopolyViewShowProcessEnd,
				ELevelGeneralCondition.OnDangoAbyssPluginRoleSelect,
				ELevelGeneralCondition.CheckDangoMatchState,
				ELevelGeneralCondition.CheckDangoMatchPlayerNumType,
				ELevelGeneralCondition.OnEnterDangoMatchView,
				ELevelGeneralCondition.OnDangoMonopolyViewStart,
				ELevelGeneralCondition.OnCiacconaAvgInspirationChoiceShow,
				ELevelGeneralCondition.OnCiacconaChapterFirstStart,
				ELevelGeneralCondition.OnCiacconaChapterRestart,
				ELevelGeneralCondition.OnMovieRogueInfoRefreshWithMultipleEnds,
				ELevelGeneralCondition.CheckMovieRogueFinishedEndingCount,
				ELevelGeneralCondition.OnDangoAbyssEnterWithTeamExploreBtn,
				ELevelGeneralCondition.OnDangoAbyssEquipPluginWithValidChange,
				ELevelGeneralCondition.OnDangoAbyssEquipPluginWithInvalid,
				ELevelGeneralCondition.OnMovieRogueLinkRefresh,
				ELevelGeneralCondition.OnMovieRogueMapMoveEnd,
				ELevelGeneralCondition.OnMapRogueEventDetailShow,
				ELevelGeneralCondition.CheckMapRogueEventDetailShow,
				ELevelGeneralCondition.OnDangoMonopolyCameraFocusOnMainDango,
				ELevelGeneralCondition.CheckDangoAbyssProgress,
				ELevelGeneralCondition.CheckDangoAbyssHasItemByType,
				ELevelGeneralCondition.CheckDangoMatchFinalEnd,
				ELevelGeneralCondition.CheckGridHasExplored,
				ELevelGeneralCondition.GolemHackingID,
				ELevelGeneralCondition.WeeklyChallengeOpen,
				ELevelGeneralCondition.OnUiTabViewShow,
				ELevelGeneralCondition.OnNewViewCovered,
				ELevelGeneralCondition.OnHandCardsShow,
				ELevelGeneralCondition.OnCardDetailShowWithFactor,
				ELevelGeneralCondition.OnMonsterNumReachLimit,
				ELevelGeneralCondition.OnGetSpCard,
				ELevelGeneralCondition.CheckPhantomArenaChallengeId,
				ELevelGeneralCondition.CheckClientQuestNodeStatus,
				ELevelGeneralCondition.CheckAnyMoraleAreaFinishWithReward,
				ELevelGeneralCondition.OnMoraleTempExpItemShow,
				ELevelGeneralCondition.OnPhantomArenaChildViewShow,
				ELevelGeneralCondition.CheckNoMoraleAreaFinished,
				ELevelGeneralCondition.OnFloroRanchCardCountReachTarget,
				ELevelGeneralCondition.CheckFloroRanchRound,
				ELevelGeneralCondition.FloroRanchActivityID,
				ELevelGeneralCondition.CheckFloroRanchHasTechCanUnlock,
				ELevelGeneralCondition.OnKingShipFirstAttrShow,
				ELevelGeneralCondition.OnKingShipAllAttrShown,
				ELevelGeneralCondition.OnFloroRanchSettleViewOpenWithEndlessMode,
				ELevelGeneralCondition.CheckFloroRanchLevel,
				ELevelGeneralCondition.OnFloroRanchStageStartTaskFinish,
				ELevelGeneralCondition.CheckTrapDefenseTalentCanUnlock,
				ELevelGeneralCondition.CheckTrapDefenseHasCanUpgradeMachine,
				ELevelGeneralCondition.OnTrapDefenseAuxiliaryMachineUpgradeToMax,
				ELevelGeneralCondition.OnTrapDefenseMachineCanChooseBranch,
				ELevelGeneralCondition.CheckTrapDefenseLevelFinish,
				ELevelGeneralCondition.CheckTrapDefenseRogueUnlock,
				ELevelGeneralCondition.OnTrapDefenseBuffGroupUpgrade,
				ELevelGeneralCondition.TrapDefenseTotalStar,
				ELevelGeneralCondition.TrapDefensePassFullStar,
				ELevelGeneralCondition.TrapDefenseChallengeStar,
				ELevelGeneralCondition.OnTrapDefenseBuildingDevelopPreviewBtnShow,
				ELevelGeneralCondition.OnTrapDefenseDeployingBuilding,
				ELevelGeneralCondition.OnTrapDefenseBuildingDevelopBottomLayoutShow,
				ELevelGeneralCondition.CheckTrapDefenseMachineLevel,
				ELevelGeneralCondition.CheckTrapDefenseTalentUnlock,
				ELevelGeneralCondition.OnTrapDefenseMainLevelViewOpen,
				ELevelGeneralCondition.OnVisionIntensifyViewShow,
				ELevelGeneralCondition.OnSurvivorsRogueEndlessToggleShow,
				ELevelGeneralCondition.OnSurvivorsRogueComboBuffShow,
				ELevelGeneralCondition.CheckFightPhotoHasTarget,
				ELevelGeneralCondition.CheckFightPhotoLevelFinished,
				ELevelGeneralCondition.CheckCalabashChildFunctionOpen,
				ELevelGeneralCondition.OnSurvivorsRoguePopViewRefresh,
				ELevelGeneralCondition.CheckSurvivorRogueTalentCanUnlock,
				ELevelGeneralCondition.CheckSurvivorRogueHasWeaponBond,
				ELevelGeneralCondition.OnSurvivorsRogueWeaponDetailTabViewShow,
				ELevelGeneralCondition.AlwaysFalse,
				ELevelGeneralCondition.OnEnterOrExitBattle,
				ELevelGeneralCondition.OnHonamiStoryLifeSupportChange,
				ELevelGeneralCondition.OnPickUpHonamiStoryItem,
				ELevelGeneralCondition.OnSceneItemDurabilityEmpty,
				ELevelGeneralCondition.CheckPickUpHonamiStoryItemType,
				ELevelGeneralCondition.IsHasRecommendRecActivity,
				ELevelGeneralCondition.CheckMotorMovieModeStateChange,
				ELevelGeneralCondition.OnMotorMusicPlayerShow,
				ELevelGeneralCondition.OnMapCustomMarkPanelShow,
				ELevelGeneralCondition.OnPhantomArenaChooseCardPanelShow,
				ELevelGeneralCondition.OnPhantomArenaDiscardCardPanelShow,
				ELevelGeneralCondition.OnMotorDiyViewShow,
				ELevelGeneralCondition.OnPhantomArenaPlayFieldEffect,
				ELevelGeneralCondition.OnRollBlockDifficultyChanged,
				ELevelGeneralCondition.CheckDungeonTypes,
				ELevelGeneralCondition.OnEnterWheelTowerEndlessMode,
				ELevelGeneralCondition.OnGuideTriggerEvent,
				ELevelGeneralCondition.CheckUiItemShow,
				ELevelGeneralCondition.CheckExploreSkillFlag,
				ELevelGeneralCondition.CheckGuessJokerRound,
				ELevelGeneralCondition.CheckMotorFightLevelFinished,
				ELevelGeneralCondition.CheckEncircleChallengeId,
				ELevelGeneralCondition.OnFlagChallengeCalculatedLevelOver,
				ELevelGeneralCondition.CheckTetrisLevelId,
				ELevelGeneralCondition.CheckRhythmShipSubLevelHasRank,
				ELevelGeneralCondition.CheckDropCatchGameplayId,
				ELevelGeneralCondition.CheckTetrisScore,
				ELevelGeneralCondition.CheckNewPlayerSupportV2,
				ELevelGeneralCondition.CheckPinballLevelPass,
				ELevelGeneralCondition.CheckPinballWeaponCount,
				ELevelGeneralCondition.OnNormalTopViewChange,
				ELevelGeneralCondition.CheckPopIsTargetOrEmpty,
				ELevelGeneralCondition.CheckKurotatoLevelWave,
				ELevelGeneralCondition.CheckKurotatoLevelFinished,
				ELevelGeneralCondition.CheckTrialRole,
				ELevelGeneralCondition.CheckInteractiveItemsFunctionEnable,
				ELevelGeneralCondition.CheckPhantomTeam,
				ELevelGeneralCondition.CheckTrialAssist,
				ELevelGeneralCondition.CheckQuestClosedSegment,
				ELevelGeneralCondition.CheckGameplayClosedSegment,
				ELevelGeneralCondition.CheckOperationRestrict,
				ELevelGeneralCondition.CheckCameraMode,
				ELevelGeneralCondition.CheckCharacterMotionState,
				ELevelGeneralCondition.CheckCharacterTagsRestrict,
				ELevelGeneralCondition.CheckInteracting,
				ELevelGeneralCondition.CheckRoverlikeInstPassed,
				ELevelGeneralCondition.CheckSubPackageDownLoadBtnShow,
				ELevelGeneralCondition.CheckFightSpecialEnergyFull,
				ELevelGeneralCondition.CheckNewbieGuideV2
			};
		}

		// Token: 0x060435DD RID: 275933 RVA: 0x01159204 File Offset: 0x01157404
		public static string[] GetNames()
		{
			return new string[]
			{
				"DistanceLess",
				"SelfTagCheck",
				"ItemCheck",
				"CheckItemWithOperator",
				"CheckDis",
				"TargetTagCheck",
				"CheckOnTrap",
				"CheckDirection",
				"QuestState",
				"CheckStrikeInfo",
				"CheckLevel",
				"CheckLevelOp",
				"CheckGuideStatus",
				"CheckCharacterTag",
				"CheckCharacterTagByEvent",
				"CheckCharacterTagNotByEvent",
				"CheckCharacterVehicleTagByEvent",
				"CheckCharacterVehicleTagNotByEvent",
				"DragonPoolState",
				"SceneStepState",
				"CheckTeleportStatus",
				"RoleLevel",
				"CheckRoleLevel",
				"CheckRoleOwned",
				"RoleBreach",
				"SelfGameplayTagCheck",
				"CheckInTodTimeSpan",
				"CheckSceneItemTag",
				"IsPlayer",
				"CheckEntityConfigId",
				"CheckSelfEntityCommonTag",
				"CheckInstanceEntranceUnlockStatus",
				"CheckOriginWorldLevel",
				"CheckCurWorldLevel",
				"CheckCurWorldLevelOp",
				"StartShootTarget",
				"CheckInstanceState",
				"CheckInstanceMatchAble",
				"MoveStateCheck",
				"CheckBuff",
				"CheckUIState",
				"CheckUIOpen",
				"CheckUIOpenDone",
				"CheckUIShowDone",
				"CheckInputAction",
				"CheckClientUseSkill",
				"CheckClientUseVisionSkill",
				"CheckBattleRole",
				"CheckEquippedPhantom",
				"CheckEnemyBuff",
				"CheckEnemyTag",
				"CheckSkillPoint",
				"CheckExploreSkill",
				"CheckFightEnergyBar",
				"CheckFightEnergyBall",
				"FunctionUnlock",
				"GetNewItem",
				"HarmonyQte",
				"GetWhichRole",
				"HpLowerThan",
				"FightWithMonster",
				"PawnInRange",
				"SlotOfCurrentRole",
				"PhantomTargetLevel",
				"CheckClientQuest",
				"CheckClientQuestNode",
				"PhantomMaxLevel",
				"RoleTargetLevel",
				"RoleSkillTargetLevel",
				"BattleRoleIsNot",
				"BattleRoleWeaponType",
				"FormationAnyRoleDead",
				"ComboTeachingState",
				"OnViewClose",
				"OnPlayerUseSkill",
				"OnSkillButtonDataRefresh",
				"FinishGuideStepByEvent",
				"PlayerRevive",
				"CheckTeamRoleCouldLevelUp",
				"CheckTeamWeaponCouldLevelUp",
				"ClientCalabashLevel",
				"TeamRoleLevel",
				"TeamWeaponLevel",
				"TeamCouldEquipPhantom",
				"CheckAnyPhantomCouldUpdate",
				"CheckAnyRoleFullPhantom",
				"CheckRolePhantomNum",
				"CheckItemCountByType",
				"CheckRouletteEquipItemId",
				"CheckVisionIntensifyTabOpen",
				"CheckAccountSettingOpen",
				"CheckOnTreasureBoxOpen",
				"CheckWeaponCount",
				"CheckOnCostInsufficient",
				"CheckRangeByPbDataId",
				"CheckDungeonId",
				"CheckRogueTerm",
				"CheckTeleportTypeUnlock",
				"CheckTypeItemPickUp",
				"CheckDungeonFinished",
				"CheckRogueCanUnlockSkill",
				"CheckPositionRolePhantomSkillEquip",
				"CheckHasFirstPhantomAtPosition",
				"CheckWorldMapSecondaryUiOpened",
				"CheckHasUnlockAffixInBossRush",
				"OnChangeBossRushBuff",
				"RoguelikeHasSelectEntryAndShow",
				"CheckActivityOpen",
				"CheckHasSkinInRoleSkinSubView",
				"OnTakingPhoto",
				"HasNotInvitedRoleInSpring25",
				"CheckMapFocusByQuestId",
				"OnWorldMapGravityBtnShow",
				"PickupInTowerDefenceBattle",
				"CheckOnSelectMenuMainType",
				"OnShowPhantomInFormation",
				"ForMoonChasingCheckTargetBuiltCount",
				"ForMoonChasingCheckHasCanLevelUpBuilding",
				"ForMoonChasingCheckNeedBranch",
				"ForMoonChasingCheckHasNotFinishedTask",
				"ForMoonChasingCheckTaskState",
				"ForMoonChasingCheckMainlineTaskDone",
				"ForMoonChasingOpenInteractive",
				"CheckPureModeWhenBattleViewActive",
				"OnActivitySubViewDone",
				"CheckLockEnemyMode",
				"CheckIsShowProgressBarInMapExploreDetailView",
				"CheckIsMulti",
				"CheckFishingRoleTechViewOpen",
				"CheckFishingDockyardItemTipsShown",
				"CheckShipTowerTeamOpen",
				"CheckDockyardWareHouseHasItem",
				"CheckFishingQteBtnHitValidArea",
				"OnFishingQteScoreReachedMaximum",
				"CheckFishingTechUnlock",
				"OnFishingBackpackBtnStateChange",
				"CheckFishingEntrustState",
				"CheckFishingWareHouseItemListLength",
				"CheckCurFishingEntrustAvailablePeriod",
				"OnTreasureCompassUnitShow",
				"OnFishingBackpackQuickSellToggleShow",
				"HideSettingInCloudGame",
				"OnPlayerTitleUnlock",
				"CheckDangoMonopolyHasFinishedRound",
				"OnDangoMonopolyMoveStop",
				"OnDangoMonopolyViewShowProcessEnd",
				"OnDangoAbyssPluginRoleSelect",
				"CheckDangoMatchState",
				"CheckDangoMatchPlayerNumType",
				"OnEnterDangoMatchView",
				"OnDangoMonopolyViewStart",
				"OnCiacconaAvgInspirationChoiceShow",
				"OnCiacconaChapterFirstStart",
				"OnCiacconaChapterRestart",
				"OnMovieRogueInfoRefreshWithMultipleEnds",
				"CheckMovieRogueFinishedEndingCount",
				"OnDangoAbyssEnterWithTeamExploreBtn",
				"OnDangoAbyssEquipPluginWithValidChange",
				"OnDangoAbyssEquipPluginWithInvalid",
				"OnMovieRogueLinkRefresh",
				"OnMovieRogueMapMoveEnd",
				"OnMapRogueEventDetailShow",
				"CheckMapRogueEventDetailShow",
				"OnDangoMonopolyCameraFocusOnMainDango",
				"CheckDangoAbyssProgress",
				"CheckDangoAbyssHasItemByType",
				"CheckDangoMatchFinalEnd",
				"CheckGridHasExplored",
				"GolemHackingID",
				"WeeklyChallengeOpen",
				"OnUiTabViewShow",
				"OnNewViewCovered",
				"OnHandCardsShow",
				"OnCardDetailShowWithFactor",
				"OnMonsterNumReachLimit",
				"OnGetSpCard",
				"CheckPhantomArenaChallengeId",
				"CheckClientQuestNodeStatus",
				"CheckAnyMoraleAreaFinishWithReward",
				"OnMoraleTempExpItemShow",
				"OnPhantomArenaChildViewShow",
				"CheckNoMoraleAreaFinished",
				"OnFloroRanchCardCountReachTarget",
				"CheckFloroRanchRound",
				"FloroRanchActivityID",
				"CheckFloroRanchHasTechCanUnlock",
				"OnKingShipFirstAttrShow",
				"OnKingShipAllAttrShown",
				"OnFloroRanchSettleViewOpenWithEndlessMode",
				"CheckFloroRanchLevel",
				"OnFloroRanchStageStartTaskFinish",
				"CheckTrapDefenseTalentCanUnlock",
				"CheckTrapDefenseHasCanUpgradeMachine",
				"OnTrapDefenseAuxiliaryMachineUpgradeToMax",
				"OnTrapDefenseMachineCanChooseBranch",
				"CheckTrapDefenseLevelFinish",
				"CheckTrapDefenseRogueUnlock",
				"OnTrapDefenseBuffGroupUpgrade",
				"TrapDefenseTotalStar",
				"TrapDefensePassFullStar",
				"TrapDefenseChallengeStar",
				"OnTrapDefenseBuildingDevelopPreviewBtnShow",
				"OnTrapDefenseDeployingBuilding",
				"OnTrapDefenseBuildingDevelopBottomLayoutShow",
				"CheckTrapDefenseMachineLevel",
				"CheckTrapDefenseTalentUnlock",
				"OnTrapDefenseMainLevelViewOpen",
				"OnVisionIntensifyViewShow",
				"OnSurvivorsRogueEndlessToggleShow",
				"OnSurvivorsRogueComboBuffShow",
				"CheckFightPhotoHasTarget",
				"CheckFightPhotoLevelFinished",
				"CheckCalabashChildFunctionOpen",
				"OnSurvivorsRoguePopViewRefresh",
				"CheckSurvivorRogueTalentCanUnlock",
				"CheckSurvivorRogueHasWeaponBond",
				"OnSurvivorsRogueWeaponDetailTabViewShow",
				"AlwaysFalse",
				"OnEnterOrExitBattle",
				"OnHonamiStoryLifeSupportChange",
				"OnPickUpHonamiStoryItem",
				"OnSceneItemDurabilityEmpty",
				"CheckPickUpHonamiStoryItemType",
				"IsHasRecommendRecActivity",
				"CheckMotorMovieModeStateChange",
				"OnMotorMusicPlayerShow",
				"OnMapCustomMarkPanelShow",
				"OnPhantomArenaChooseCardPanelShow",
				"OnPhantomArenaDiscardCardPanelShow",
				"OnMotorDiyViewShow",
				"OnPhantomArenaPlayFieldEffect",
				"OnRollBlockDifficultyChanged",
				"CheckDungeonTypes",
				"OnEnterWheelTowerEndlessMode",
				"OnGuideTriggerEvent",
				"CheckUiItemShow",
				"CheckExploreSkillFlag",
				"CheckGuessJokerRound",
				"CheckMotorFightLevelFinished",
				"CheckEncircleChallengeId",
				"OnFlagChallengeCalculatedLevelOver",
				"CheckTetrisLevelId",
				"CheckRhythmShipSubLevelHasRank",
				"CheckDropCatchGameplayId",
				"CheckTetrisScore",
				"CheckNewPlayerSupportV2",
				"CheckPinballLevelPass",
				"CheckPinballWeaponCount",
				"OnNormalTopViewChange",
				"CheckPopIsTargetOrEmpty",
				"CheckKurotatoLevelWave",
				"CheckKurotatoLevelFinished",
				"CheckTrialRole",
				"CheckInteractiveItemsFunctionEnable",
				"CheckPhantomTeam",
				"CheckTrialAssist",
				"CheckQuestClosedSegment",
				"CheckGameplayClosedSegment",
				"CheckOperationRestrict",
				"CheckCameraMode",
				"CheckCharacterMotionState",
				"CheckCharacterTagsRestrict",
				"CheckInteracting",
				"CheckRoverlikeInstPassed",
				"CheckSubPackageDownLoadBtnShow",
				"CheckFightSpecialEnergyFull",
				"CheckNewbieGuideV2"
			};
		}
	}
}
