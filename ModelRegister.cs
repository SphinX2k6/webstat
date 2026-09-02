using System;
using System.Collections.Generic;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Capability;
using CSharpScript.Game.Input;
using CSharpScript.Game.LevelFlow;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.AlertArea;
using CSharpScript.Game.LevelGamePlay.BigStuffedDoll;
using CSharpScript.Game.LevelGamePlay.Cipher;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.LevelGamePlay.DigitalScreen;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine;
using CSharpScript.Game.LevelGamePlay.FindSunSprite;
using CSharpScript.Game.LevelGamePlay.FishingQte;
using CSharpScript.Game.LevelGamePlay.GongduolaSummon;
using CSharpScript.Game.LevelGamePlay.GravityFlip;
using CSharpScript.Game.LevelGamePlay.Hourglass;
using CSharpScript.Game.LevelGamePlay.ItemInspect;
using CSharpScript.Game.LevelGamePlay.LevelEffect;
using CSharpScript.Game.LevelGamePlay.LifePoint;
using CSharpScript.Game.LevelGamePlay.Parkour;
using CSharpScript.Game.LevelGamePlay.ProjectPuzzle;
using CSharpScript.Game.LevelGamePlay.ResetPlayer;
using CSharpScript.Game.LevelGamePlay.SeekTrace;
using CSharpScript.Game.LevelGamePlay.SignalDeviceControl;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.LevelGamePlay.StaticScene;
using CSharpScript.Game.LevelGamePlay.SundialControl;
using CSharpScript.Game.LevelGamePlay.SunSpirit;
using CSharpScript.Game.LevelGamePlay.TimeTrackControl;
using CSharpScript.Game.LevelGamePlay.TuningStand;
using CSharpScript.Game.LevelGamePlay.TurntableControl;
using CSharpScript.Game.LevelGamePlay.WriteLetter;
using CSharpScript.Game.Module.Activity.ActivityContent.CommonH5;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Activity.ActivityContent.LineCross;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour;
using CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor;
using CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using CSharpScript.Game.Module.Activity.ActivityContent.PreWarm;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.ActorFxEmote;
using CSharpScript.Game.Module.AiInteraction.AiWeapon;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.BattleUiSet;
using CSharpScript.Game.Module.BossPiling;
using CSharpScript.Game.Module.CiacconaGal;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.EffectSave;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemDeliver;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.JoinTeam;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.MailBind;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Module.Manufacture.Forging;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.MechanismTimeline;
using CSharpScript.Game.Module.MingSu;
using CSharpScript.Game.Module.MonsterGroup;
using CSharpScript.Game.Module.Movement.Model;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Module.MusicalInstrument;
using CSharpScript.Game.Module.NetworkDetection;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.QuestMultiLine;
using CSharpScript.Game.Module.QuickHack;
using CSharpScript.Game.Module.QuickTimeAction;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Module.ResManager.Model;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.RoleLangCustomModel;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Module.Season;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.SlidingBlocks;
using CSharpScript.Game.Module.SubLevelLoading;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Module.TreasureHunt;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;
using CSharpScript.Game.Module.VehicleStream;
using CSharpScript.Game.Module.VillageInfr;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuYinArea;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.NewWorld.Common.Model;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using CSharpScript.Game.NewWorld.TriggerItems.Model;
using CSharpScript.Game.Render;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils.LevelRangeDebug;
using CSharpScript.Game.World.Model;
using CSharpScript.Module.InstanceDungeon;
using CSharpScript.Utils;

// Token: 0x0200350E RID: 13582
public class ModelRegister
{
	// Token: 0x0601CAC4 RID: 117444 RVA: 0x008A3C68 File Offset: 0x008A1E68
	public static bool CreateInstance()
	{
		ModelRegister.Models.Clear();
		if (!ModelBase<QuestNewModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestNewModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QuestNewModel>.Instance);
		if (!ModelBase<AudioModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AudioModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AudioModel>.Instance);
		if (!ModelBase<QuestReviewModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestReviewModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QuestReviewModel>.Instance);
		if (!ModelBase<QuestResourceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestResourceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QuestResourceModel>.Instance);
		if (!ModelBase<DailyTaskModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DailyTaskModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DailyTaskModel>.Instance);
		if (!ModelBase<QuestMultiLineModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QuestMultiLineModel>.Instance);
		if (!ModelBase<CommonQteModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CommonQteModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CommonQteModel>.Instance);
		if (!ModelBase<BattleQteModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BattleQteModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BattleQteModel>.Instance);
		if (!ModelBase<PowerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PowerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PowerModel>.Instance);
		if (!ModelBase<QuestTreeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestTreeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QuestTreeModel>.Instance);
		if (!ModelBase<SequenceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.Sequence.SequenceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SequenceModel>.Instance);
		if (!ModelBase<PlotAudioModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotAudioModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PlotAudioModel>.Instance);
		if (!ModelBase<PlayerInfoModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PlayerInfoModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PlayerInfoModel>.Instance);
		if (!ModelBase<PlatformModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PlatformModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PlatformModel>.Instance);
		if (!ModelBase<PilotThrowModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PilotThrowModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PilotThrowModel>.Instance);
		if (!ModelBase<PhotographModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhotographModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhotographModel>.Instance);
		if (!ModelBase<PhotographQuickModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhotographQuickModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhotographQuickModel>.Instance);
		if (!ModelBase<PhonographModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhonographModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhonographModel>.Instance);
		if (!ModelBase<PhoneMsgModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhoneMsgModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhoneMsgModel>.Instance);
		if (!ModelBase<PlotModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PlotModel>.Instance);
		if (!ModelBase<PhantomInteractModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhantomInteractModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhantomInteractModel>.Instance);
		if (!ModelBase<QuickHackModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.QuickHack.QuickHackModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QuickHackModel>.Instance);
		if (!ModelBase<RacingBetsModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RacingBets.RacingBetsModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RacingBetsModel>.Instance);
		if (!ModelBase<TrialRoleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TrialRoleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TrialRoleModel>.Instance);
		if (!ModelBase<RoleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleModel>.Instance);
		if (!ModelBase<RoleFavorConditionModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleFavorConditionModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleFavorConditionModel>.Instance);
		if (!ModelBase<RoleDevModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleDevModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleDevModel>.Instance);
		if (!ModelBase<RoleDevelopModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RoleUi.RoleDevelop.RoleDevelopModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleDevelopModel>.Instance);
		if (!ModelBase<MainRoleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MainRoleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MainRoleModel>.Instance);
		if (!ModelBase<RoleSelectModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleSelectModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleSelectModel>.Instance);
		if (!ModelBase<RoleLangCustomModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RoleLangCustomModel.RoleLangCustomModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleLangCustomModel>.Instance);
		if (!ModelBase<QtaModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.QuickTimeAction.QtaModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QtaModel>.Instance);
		if (!ModelBase<RoguelikeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoguelikeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoguelikeModel>.Instance);
		if (!ModelBase<RewardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Reward.RewardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RewardModel>.Instance);
		if (!ModelBase<ResourceManagerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ResManager.Model.ResourceManagerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ResourceManagerModel>.Instance);
		if (!ModelBase<ResDownLoadModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ResDownLoadModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ResDownLoadModel>.Instance);
		if (!ModelBase<ReConnectModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ReConnectModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ReConnectModel>.Instance);
		if (!ModelBase<RecommendQualityModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RecommendQualityModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RecommendQualityModel>.Instance);
		if (!ModelBase<RechargeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RechargeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RechargeModel>.Instance);
		if (!ModelBase<RecallQuestModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RecallQuest.Model.RecallQuestModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RecallQuestModel>.Instance);
		if (!ModelBase<RandomPlotModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RandomPlotModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RandomPlotModel>.Instance);
		if (!ModelBase<RogueBattleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RogueBattle.RogueBattleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RogueBattleModel>.Instance);
		if (!ModelBase<VisionRecommendModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VisionRecommendModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VisionRecommendModel>.Instance);
		if (!ModelBase<VisionEquipGroupModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VisionEquipGroupModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VisionEquipGroupModel>.Instance);
		if (!ModelBase<PhantomBattleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhantomBattleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhantomBattleModel>.Instance);
		if (!ModelBase<MoraleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoraleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoraleModel>.Instance);
		if (!ModelBase<MonsterGroupPatrolModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MonsterGroup.MonsterGroupPatrolModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MonsterGroupPatrolModel>.Instance);
		if (!ModelBase<MonsterGroupEcologyModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MonsterGroup.MonsterGroupEcologyModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MonsterGroupEcologyModel>.Instance);
		if (!ModelBase<PreDownloadModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PreDownloadModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PreDownloadModel>.Instance);
		if (!ModelBase<MingSuModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MingSu.MingSuModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MingSuModel>.Instance);
		if (!ModelBase<MenuModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MenuModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MenuModel>.Instance);
		if (!ModelBase<MechanismTimelineModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MechanismTimeline.MechanismTimelineModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MechanismTimelineModel>.Instance);
		if (!ModelBase<MarqueeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MarqueeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MarqueeModel>.Instance);
		if (!ModelBase<MotionModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotionModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MotionModel>.Instance);
		if (!ModelBase<MapModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Map.MapModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MapModel>.Instance);
		if (!ModelBase<MapExploreToolModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MapExploreToolModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MapExploreToolModel>.Instance);
		if (!ModelBase<ForgingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Manufacture.Forging.ForgingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ForgingModel>.Instance);
		if (!ModelBase<ComposePopupModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup.ComposePopupModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ComposePopupModel>.Instance);
		if (!ModelBase<ComposeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Manufacture.Compose.ComposeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ComposeModel>.Instance);
		if (!ModelBase<MailModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MailModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MailModel>.Instance);
		if (!ModelBase<MailBindModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MailBind.MailBindModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MailBindModel>.Instance);
		if (!ModelBase<LordGymModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LordGymModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LordGymModel>.Instance);
		if (!ModelBase<LogReportModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LogReportModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LogReportModel>.Instance);
		if (!ModelBase<MapRogueModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MapRogue.MapRogueModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MapRogueModel>.Instance);
		if (!ModelBase<MotorcycleDevelopModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleDevelopModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MotorcycleDevelopModel>.Instance);
		if (!ModelBase<MotorcycleDiyModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleDiyModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MotorcycleDiyModel>.Instance);
		if (!ModelBase<MotorcycleMusicPlayerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleMusicPlayerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MotorcycleMusicPlayerModel>.Instance);
		if (!ModelBase<PhantomArenaModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PhantomArena.PhantomArenaModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhantomArenaModel>.Instance);
		if (!ModelBase<PhantomArenaBattleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PhantomArena.Battle.Model.PhantomArenaBattleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PhantomArenaBattleModel>.Instance);
		if (!ModelBase<PersonalModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Personal.PersonalModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PersonalModel>.Instance);
		if (!ModelBase<ActivityPermanentRogueModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PermanentRogue.ActivityPermanentRogueModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityPermanentRogueModel>.Instance);
		if (!ModelBase<WeekCardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeekCardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WeekCardModel>.Instance);
		if (!ModelBase<PayShopModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayShopModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PayShopModel>.Instance);
		if (!ModelBase<PayGiftModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayGiftModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PayGiftModel>.Instance);
		if (!ModelBase<MonthCardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MonthCardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MonthCardModel>.Instance);
		if (!ModelBase<BattlePassModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BattlePassModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BattlePassModel>.Instance);
		if (!ModelBase<PayItemModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayItemModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PayItemModel>.Instance);
		if (!ModelBase<PanoramicModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PanoramicModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PanoramicModel>.Instance);
		if (!ModelBase<PanelQteModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PanelQteModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PanelQteModel>.Instance);
		if (!ModelBase<RoleOrnamentModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleOrnamentModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleOrnamentModel>.Instance);
		if (!ModelBase<OnlineModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "OnlineModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<OnlineModel>.Instance);
		if (!ModelBase<NewFlagModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "NewFlagModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<NewFlagModel>.Instance);
		if (!ModelBase<NetworkDetectionModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.NetworkDetection.NetworkDetectionModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<NetworkDetectionModel>.Instance);
		if (!ModelBase<MusicalInstrumentModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MusicalInstrument.MusicalInstrumentModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MusicalInstrumentModel>.Instance);
		if (!ModelBase<MovieModeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MovieMode.MovieModeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MovieModeModel>.Instance);
		if (!ModelBase<AvoidanceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Movement.Model.AvoidanceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AvoidanceModel>.Instance);
		if (!ModelBase<RouletteModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RouletteModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RouletteModel>.Instance);
		if (!ModelBase<SceneBattleInteractModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SceneBattleInteractModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SceneBattleInteractModel>.Instance);
		if (!ModelBase<SceneTeamModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SceneTeamModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SceneTeamModel>.Instance);
		if (!ModelBase<ScoreModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ScoreModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ScoreModel>.Instance);
		if (!ModelBase<SceneItemBuffModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.SceneItemBuffModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SceneItemBuffModel>.Instance);
		if (!ModelBase<SceneInteractionModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.SceneInteractionModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SceneInteractionModel>.Instance);
		if (!ModelBase<RangeItemModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.RangeItemModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RangeItemModel>.Instance);
		if (!ModelBase<PortalModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.PortalModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PortalModel>.Instance);
		if (!ModelBase<ConnectGamePlayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.ConnectGamePlayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ConnectGamePlayModel>.Instance);
		if (!ModelBase<ClientTagModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Common.Model.ClientTagModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ClientTagModel>.Instance);
		if (!ModelBase<NpcVehicleRiderModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "NpcVehicleRiderModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<NpcVehicleRiderModel>.Instance);
		if (!ModelBase<NpcConfigModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "NpcConfigModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<NpcConfigModel>.Instance);
		if (!ModelBase<SceneItemConnectorModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.SceneItemConnectorModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SceneItemConnectorModel>.Instance);
		if (!ModelBase<PerformModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PerformModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PerformModel>.Instance);
		if (!ModelBase<ManipulaterModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Character.Common.Component.ManipulaterModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ManipulaterModel>.Instance);
		if (!ModelBase<ManipulateInteractModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Character.Common.Component.ManipulateInteractModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ManipulateInteractModel>.Instance);
		if (!ModelBase<BuffModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuffModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BuffModel>.Instance);
		if (!ModelBase<CharacterModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CharacterModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CharacterModel>.Instance);
		if (!ModelBase<BulletModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BulletModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BulletModel>.Instance);
		if (!ModelBase<WuYinAreaModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WuYinArea.WuYinAreaModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WuYinAreaModel>.Instance);
		if (!ModelBase<WuWaGoModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WuwaGo.Model.WuWaGoModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WuWaGoModel>.Instance);
		if (!ModelBase<WorldMapModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WorldMap.WorldMapModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WorldMapModel>.Instance);
		if (!ModelBase<CharacterExploreModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Character.Common.Component.Explore.CharacterExploreModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CharacterExploreModel>.Instance);
		if (!ModelBase<ShootTargetModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.ShootTargetModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ShootTargetModel>.Instance);
		if (!ModelBase<VisionCaptureModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Model.VisionCaptureModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VisionCaptureModel>.Instance);
		if (!ModelBase<TriggerVolumeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.TriggerItems.Model.TriggerVolumeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TriggerVolumeModel>.Instance);
		if (!ModelBase<WorldDebugModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Model.WorldDebugModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WorldDebugModel>.Instance);
		if (!ModelBase<TraceElementModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TraceElementModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TraceElementModel>.Instance);
		if (!ModelBase<SubLevelModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Model.SubLevelModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SubLevelModel>.Instance);
		if (!ModelBase<SceneOpacityModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SceneOpacityModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SceneOpacityModel>.Instance);
		if (!ModelBase<PreloadModelNew>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PreloadModelNew 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PreloadModelNew>.Instance);
		if (!ModelBase<GameModeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GameModeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GameModeModel>.Instance);
		if (!ModelBase<DamageModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Model.DamageModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DamageModel>.Instance);
		if (!ModelBase<CreatureModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CreatureModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CreatureModel>.Instance);
		if (!ModelBase<BlackboardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BlackboardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BlackboardModel>.Instance);
		if (!ModelBase<AttachToActorModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AttachToActorModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AttachToActorModel>.Instance);
		if (!ModelBase<AoiModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AoiModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AoiModel>.Instance);
		if (!ModelBase<ExpressionTreeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Utils.ExpressionTreeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ExpressionTreeModel>.Instance);
		if (!ModelBase<LevelRangeDebugDrawModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Utils.LevelRangeDebug.LevelRangeDebugDrawModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelRangeDebugDrawModel>.Instance);
		if (!ModelBase<InputDistributeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.InputDistributeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InputDistributeModel>.Instance);
		if (!ModelBase<ServerStorageModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.ServerStorage.ServerStorageModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ServerStorageModel>.Instance);
		if (!ModelBase<RenderModuleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Render.RenderModuleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RenderModuleModel>.Instance);
		if (!ModelBase<ScreenEffectModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Render.Effect.ScreenEffectSystem.ScreenEffectModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ScreenEffectModel>.Instance);
		if (!ModelBase<RedDotModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RedDotModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RedDotModel>.Instance);
		if (!ModelBase<VehicleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VehicleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VehicleModel>.Instance);
		if (!ModelBase<RegionalTerminalModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WorldMap.RegionalTerminal.RegionalTerminalModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RegionalTerminalModel>.Instance);
		if (!ModelBase<LoginServerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoginServerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LoginServerModel>.Instance);
		if (!ModelBase<WorldLevelModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WorldLevelModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WorldLevelModel>.Instance);
		if (!ModelBase<WeeklyChallengeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeeklyChallengeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WeeklyChallengeModel>.Instance);
		if (!ModelBase<SpecialTransitionModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SpecialTransitionModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SpecialTransitionModel>.Instance);
		if (!ModelBase<SoundAreaPlayTipsModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SoundAreaPlayTipsModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SoundAreaPlayTipsModel>.Instance);
		if (!ModelBase<SlidingBlocksModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SlidingBlocks.SlidingBlocksModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SlidingBlocksModel>.Instance);
		if (!ModelBase<SkipInterfaceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SkipInterface.SkipInterfaceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SkipInterfaceModel>.Instance);
		if (!ModelBase<WeaponSkinModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeaponSkinModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WeaponSkinModel>.Instance);
		if (!ModelBase<FlySkinModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FlySkinModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FlySkinModel>.Instance);
		if (!ModelBase<CalabashSkinModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CalabashSkinModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CalabashSkinModel>.Instance);
		if (!ModelBase<RoleSkinModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleSkinModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoleSkinModel>.Instance);
		if (!ModelBase<SubLevelLoadingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SubLevelLoading.SubLevelLoadingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SubLevelLoadingModel>.Instance);
		if (!ModelBase<SkillButtonUiModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SkillButtonUi.SkillButtonUiModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SkillButtonUiModel>.Instance);
		if (!ModelBase<ShowerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShowerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ShowerModel>.Instance);
		if (!ModelBase<MoonTogetherModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonTogetherModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoonTogetherModel>.Instance);
		if (!ModelBase<ShopModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShopModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ShopModel>.Instance);
		if (!ModelBase<ShipTogetherModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShipTogetherModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ShipTogetherModel>.Instance);
		if (!ModelBase<ShipTowerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShipTowerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ShipTowerModel>.Instance);
		if (!ModelBase<SheriffModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Sheriff.SheriffModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SheriffModel>.Instance);
		if (!ModelBase<SeasonModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Season.SeasonModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SeasonModel>.Instance);
		if (!ModelBase<SeamlessTravelModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SeamlessTravel.SeamlessTravelModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SeamlessTravelModel>.Instance);
		if (!ModelBase<SignalDecodeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SignalDecodeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SignalDecodeModel>.Instance);
		if (!ModelBase<SubPackageDownLoadModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SubPackageDownLoadModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SubPackageDownLoadModel>.Instance);
		if (!ModelBase<SundryModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SundryModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SundryModel>.Instance);
		if (!ModelBase<SurvivorsRogueModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SurvivorsRogueModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SurvivorsRogueModel>.Instance);
		if (!ModelBase<WeatherModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Weather.WeatherModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WeatherModel>.Instance);
		if (!ModelBase<WeaponModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeaponModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WeaponModel>.Instance);
		if (!ModelBase<WaitEntityTaskModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WaitEntityTaskModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WaitEntityTaskModel>.Instance);
		if (!ModelBase<VillageInfrModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.VillageInfr.VillageInfrModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VillageInfrModel>.Instance);
		if (!ModelBase<VideoBpModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VideoBpModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VideoBpModel>.Instance);
		if (!ModelBase<VehicleStreamModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.VehicleStream.VehicleStreamModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VehicleStreamModel>.Instance);
		if (!ModelBase<UiNavigationModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiNavigationModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<UiNavigationModel>.Instance);
		if (!ModelBase<HomeBtnModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.UiComponent.UiHomeButton.HomeBtnModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<HomeBtnModel>.Instance);
		if (!ModelBase<TutorialModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TutorialModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TutorialModel>.Instance);
		if (!ModelBase<TreasureHuntModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.TreasureHunt.TreasureHuntModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TreasureHuntModel>.Instance);
		if (!ModelBase<TrapDefenseModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.TrapDefense.TrapDefenseModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TrapDefenseModel>.Instance);
		if (!ModelBase<TrainingDegreeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.TrainingDegree.TrainingDegreeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TrainingDegreeModel>.Instance);
		if (!ModelBase<TrackModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TrackModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TrackModel>.Instance);
		if (!ModelBase<TowerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TowerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TowerModel>.Instance);
		if (!ModelBase<TowerDetailModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TowerDetailModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TowerDetailModel>.Instance);
		if (!ModelBase<TowerDefenseEventModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.TowerDefenseEvent.Model.TowerDefenseEventModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TowerDefenseEventModel>.Instance);
		if (!ModelBase<TowerDefenseModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TowerDefenseModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TowerDefenseModel>.Instance);
		if (!ModelBase<TimeOfDayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TimeOfDayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TimeOfDayModel>.Instance);
		if (!ModelBase<TeleportModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Teleport.TeleportModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TeleportModel>.Instance);
		if (!ModelBase<WeeklyRogueModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeeklyRogueModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WeeklyRogueModel>.Instance);
		if (!ModelBase<LoginModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoginModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LoginModel>.Instance);
		if (!ModelBase<LoadingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoadingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LoadingModel>.Instance);
		if (!ModelBase<LevelUpModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelUpModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelUpModel>.Instance);
		if (!ModelBase<MoonChasingBuildingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingBuildingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoonChasingBuildingModel>.Instance);
		if (!ModelBase<LineCrossModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.LineCross.LineCrossModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LineCrossModel>.Instance);
		if (!ModelBase<LifePointDrawModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LifePointDrawModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LifePointDrawModel>.Instance);
		if (!ModelBase<InviteNewbieModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InviteNewbieModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InviteNewbieModel>.Instance);
		if (!ModelBase<ActivityFunPlayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityFunPlayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityFunPlayModel>.Instance);
		if (!ModelBase<FishingQuestModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Fishing.FishingQuestModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FishingQuestModel>.Instance);
		if (!ModelBase<FishingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Fishing.FishingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FishingModel>.Instance);
		if (!ModelBase<DockyardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Fishing.DockyardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DockyardModel>.Instance);
		if (!ModelBase<MoonChasingBusinessModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingBusinessModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoonChasingBusinessModel>.Instance);
		if (!ModelBase<FightPhotoModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FightPhotoModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FightPhotoModel>.Instance);
		if (!ModelBase<DirectTrainModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity.DirectTrainModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DirectTrainModel>.Instance);
		if (!ModelBase<ActivityDirectTrainModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.ActivityDirectTrainModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityDirectTrainModel>.Instance);
		if (!ModelBase<CommonH5Model>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.CommonH5.CommonH5Model 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CommonH5Model>.Instance);
		if (!ModelBase<ChessModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ChessModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ChessModel>.Instance);
		if (!ModelBase<BossRushModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BossRushModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BossRushModel>.Instance);
		if (!ModelBase<BabelTowerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BabelTowerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BabelTowerModel>.Instance);
		if (!ModelBase<AvignonModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AvignonModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AvignonModel>.Instance);
		if (!ModelBase<AdvanceNoticeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdvanceNoticeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AdvanceNoticeModel>.Instance);
		if (!ModelBase<DropCatchModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.DropCatchModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DropCatchModel>.Instance);
		if (!ModelBase<MoonChasingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoonChasingModel>.Instance);
		if (!ModelBase<MoonChasingRewardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingRewardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoonChasingRewardModel>.Instance);
		if (!ModelBase<MoonChasingTaskModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingTaskModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoonChasingTaskModel>.Instance);
		if (!ModelBase<ActivityModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityModel>.Instance);
		if (!ModelBase<WheelTowerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WheelTowerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WheelTowerModel>.Instance);
		if (!ModelBase<VersionPreheatModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VersionPreheatModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<VersionPreheatModel>.Instance);
		if (!ModelBase<SpringManorModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.SpringManor.SpringManorModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SpringManorModel>.Instance);
		if (!ModelBase<Spring25Model>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "Spring25Model 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<Spring25Model>.Instance);
		if (!ModelBase<SolarSpeedModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed.SolarSpeedModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SolarSpeedModel>.Instance);
		if (!ModelBase<ActivitySevenDaySignModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivitySevenDaySignModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivitySevenDaySignModel>.Instance);
		if (!ModelBase<ActivityScratchTicketModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityScratchTicketModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityScratchTicketModel>.Instance);
		if (!ModelBase<ActivityRunModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRunModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityRunModel>.Instance);
		if (!ModelBase<RoverlikeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Roverlike.RoverlikeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RoverlikeModel>.Instance);
		if (!ModelBase<RhythmShipModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.RhythmShipModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RhythmShipModel>.Instance);
		if (!ModelBase<ActivityRegressModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRegressModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityRegressModel>.Instance);
		if (!ModelBase<ActivityPreWarmModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.PreWarm.ActivityPreWarmModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityPreWarmModel>.Instance);
		if (!ModelBase<PinballModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Pinball.PinballModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<PinballModel>.Instance);
		if (!ModelBase<NewbieMainModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain.NewbieMainModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<NewbieMainModel>.Instance);
		if (!ModelBase<MultiMotorModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor.MultiMotorModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MultiMotorModel>.Instance);
		if (!ModelBase<MowingTowerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MowingTowerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MowingTowerModel>.Instance);
		if (!ModelBase<MowingRiskModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MowingRiskModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MowingRiskModel>.Instance);
		if (!ModelBase<MotorParkourMapModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour.MotorParkourMapModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MotorParkourMapModel>.Instance);
		if (!ModelBase<ActivityRecommendModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRecommendModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActivityRecommendModel>.Instance);
		if (!ModelBase<ActorFxEmoteModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ActorFxEmote.ActorFxEmoteModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ActorFxEmoteModel>.Instance);
		if (!ModelBase<RhythmGameModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RhythmGameModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<RhythmGameModel>.Instance);
		if (!ModelBase<FurnitureModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FurnitureModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FurnitureModel>.Instance);
		if (!ModelBase<GravityFlipModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.GravityFlip.GravityFlipModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GravityFlipModel>.Instance);
		if (!ModelBase<GongduolaSummonModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.GongduolaSummon.GongduolaSummonModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GongduolaSummonModel>.Instance);
		if (!ModelBase<FishingQteModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.FishingQte.FishingQteModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FishingQteModel>.Instance);
		if (!ModelBase<FindSunSpiritModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.FindSunSprite.FindSunSpiritModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FindSunSpiritModel>.Instance);
		if (!ModelBase<DollGrabModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DollGrabModel>.Instance);
		if (!ModelBase<DigitalScreenModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.DigitalScreen.DigitalScreenModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DigitalScreenModel>.Instance);
		if (!ModelBase<LevelPrefabConfigModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Common.LevelPrefabConfigModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelPrefabConfigModel>.Instance);
		if (!ModelBase<GameSplineModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Common.GameSplineModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GameSplineModel>.Instance);
		if (!ModelBase<QteHourglassModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Hourglass.QteHourglassModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<QteHourglassModel>.Instance);
		if (!ModelBase<CipherModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Cipher.CipherModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CipherModel>.Instance);
		if (!ModelBase<AlertAreaModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.AlertArea.AlertAreaModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AlertAreaModel>.Instance);
		if (!ModelBase<LevelFlowModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelFlow.LevelFlowModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelFlowModel>.Instance);
		if (!ModelBase<KuroSdkModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "KuroSdkModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<KuroSdkModel>.Instance);
		if (!ModelBase<InputModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Input.InputModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InputModel>.Instance);
		if (!ModelBase<CapabilityModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Capability.CapabilityModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CapabilityModel>.Instance);
		if (!ModelBase<CameraModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Camera.CameraModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CameraModel>.Instance);
		if (!ModelBase<AiStateMachineModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.AI.StateMachine.AiStateMachineModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AiStateMachineModel>.Instance);
		if (!ModelBase<AiModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AiModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AiModel>.Instance);
		if (!ModelBase<BigStuffedDollModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.BigStuffedDoll.BigStuffedDollModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BigStuffedDollModel>.Instance);
		if (!ModelBase<ItemInspectModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.ItemInspect.ItemInspectModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ItemInspectModel>.Instance);
		if (!ModelBase<LevelEffectModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LevelEffect.LevelEffectModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelEffectModel>.Instance);
		if (!ModelBase<LevelGamePlayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LevelGamePlayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelGamePlayModel>.Instance);
		if (!ModelBase<DrinksModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DrinksModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DrinksModel>.Instance);
		if (!ModelBase<AchievementModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AchievementModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AchievementModel>.Instance);
		if (!ModelBase<FormationDataModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FormationDataModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FormationDataModel>.Instance);
		if (!ModelBase<FormationAttributeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FormationAttributeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FormationAttributeModel>.Instance);
		if (!ModelBase<WriteLetterModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.WriteLetter.WriteLetterModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WriteLetterModel>.Instance);
		if (!ModelBase<TurntableControlModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.TurntableControl.TurntableControlModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TurntableControlModel>.Instance);
		if (!ModelBase<TuningStandModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.TuningStand.TuningStandModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TuningStandModel>.Instance);
		if (!ModelBase<TimeTrackControlModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.TimeTrackControl.TimeTrackControlModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<TimeTrackControlModel>.Instance);
		if (!ModelBase<SunSpiritModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SunSpiritModel>.Instance);
		if (!ModelBase<SundialControlModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SundialControl.SundialControlModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SundialControlModel>.Instance);
		if (!ModelBase<StaticSceneModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.StaticScene.StaticSceneModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<StaticSceneModel>.Instance);
		if (!ModelBase<SplineConstrainedDragModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.SplineConstrainedDragModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SplineConstrainedDragModel>.Instance);
		if (!ModelBase<SignalDeviceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SignalDeviceControl.SignalDeviceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SignalDeviceModel>.Instance);
		if (!ModelBase<SeekTraceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SeekTrace.SeekTraceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SeekTraceModel>.Instance);
		if (!ModelBase<ResetPlayerModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.ResetPlayer.ResetPlayerModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ResetPlayerModel>.Instance);
		if (!ModelBase<ProjectorModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.ProjectPuzzle.ProjectorModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ProjectorModel>.Instance);
		if (!ModelBase<ParkourModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Parkour.ParkourModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ParkourModel>.Instance);
		if (!ModelBase<LifePointModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LifePoint.LifePointModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LifePointModel>.Instance);
		if (!ModelBase<LevelGeneralModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LevelGeneralModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelGeneralModel>.Instance);
		if (!ModelBase<GuessJokerGamePlayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GuessJokerGamePlayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GuessJokerGamePlayModel>.Instance);
		if (!ModelBase<WorldModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WorldModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<WorldModel>.Instance);
		if (!ModelBase<AdventureGuideModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdventureGuideModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AdventureGuideModel>.Instance);
		if (!ModelBase<AiWeaponModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.AiInteraction.AiWeapon.AiWeaponModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AiWeaponModel>.Instance);
		if (!ModelBase<HonamiStoryModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HonamiStoryModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<HonamiStoryModel>.Instance);
		if (!ModelBase<HoldingHandsModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HoldingHandsModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<HoldingHandsModel>.Instance);
		if (!ModelBase<HandBookModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HandBookModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<HandBookModel>.Instance);
		if (!ModelBase<GuideModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GuideModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GuideModel>.Instance);
		if (!ModelBase<GreatSwordChallengeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GreatSwordChallengeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GreatSwordChallengeModel>.Instance);
		if (!ModelBase<GenericPromptModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.GenericPrompt.GenericPromptModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GenericPromptModel>.Instance);
		if (!ModelBase<GeneralLogicTreeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GeneralLogicTreeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GeneralLogicTreeModel>.Instance);
		if (!ModelBase<GamePingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GamePingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GamePingModel>.Instance);
		if (!ModelBase<IdlePerformModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "IdlePerformModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<IdlePerformModel>.Instance);
		if (!ModelBase<GachaModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GachaModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GachaModel>.Instance);
		if (!ModelBase<LevelFuncFlagModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelFuncFlagModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelFuncFlagModel>.Instance);
		if (!ModelBase<FunctionModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FunctionModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FunctionModel>.Instance);
		if (!ModelBase<ExploreSkillFlagModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExploreSkillFlagModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ExploreSkillFlagModel>.Instance);
		if (!ModelBase<FriendModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FriendModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FriendModel>.Instance);
		if (!ModelBase<FragmentMemoryModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FragmentMemoryModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FragmentMemoryModel>.Instance);
		if (!ModelBase<FloroRanchModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FloroRanchModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FloroRanchModel>.Instance);
		if (!ModelBase<FloroRanchGamePlayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FloroRanchGamePlayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FloroRanchGamePlayModel>.Instance);
		if (!ModelBase<FlagChallengeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.FlagChallenge.FlagChallengeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FlagChallengeModel>.Instance);
		if (!ModelBase<GachaAccumulateModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GachaAccumulateModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GachaAccumulateModel>.Instance);
		if (!ModelBase<InfluenceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InfluenceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InfluenceModel>.Instance);
		if (!ModelBase<InfluenceReputationModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InfluenceReputationModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InfluenceReputationModel>.Instance);
		if (!ModelBase<InfoDisplayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InfoDisplayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InfoDisplayModel>.Instance);
		if (!ModelBase<LevelPlayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelPlayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelPlayModel>.Instance);
		if (!ModelBase<LevelPlayReportModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelPlayReportModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelPlayReportModel>.Instance);
		if (!ModelBase<LevelLoadingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.LevelLoading.LevelLoadingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<LevelLoadingModel>.Instance);
		if (!ModelBase<KurotatoModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Kurotato.KurotatoModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<KurotatoModel>.Instance);
		if (!ModelBase<JoinTeamModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.JoinTeam.JoinTeamModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<JoinTeamModel>.Instance);
		if (!ModelBase<SpecialItemModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SpecialItemModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SpecialItemModel>.Instance);
		if (!ModelBase<ItemModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Item.ItemModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ItemModel>.Instance);
		if (!ModelBase<ItemRewardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ItemReward.ItemRewardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ItemRewardModel>.Instance);
		if (!ModelBase<ItemHintModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ItemHintModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ItemHintModel>.Instance);
		if (!ModelBase<ItemExchangeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ItemExchangeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ItemExchangeModel>.Instance);
		if (!ModelBase<ItemDeliverModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ItemDeliver.ItemDeliverModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ItemDeliverModel>.Instance);
		if (!ModelBase<InventoryModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InventoryModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InventoryModel>.Instance);
		if (!ModelBase<InteractionModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Interaction.InteractionModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InteractionModel>.Instance);
		if (!ModelBase<InstanceGameplayModeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InstanceGameplayModeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InstanceGameplayModeModel>.Instance);
		if (!ModelBase<InstanceDungeonModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InstanceDungeonModel>.Instance);
		if (!ModelBase<InstanceDungeonGuideModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonGuideModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InstanceDungeonGuideModel>.Instance);
		if (!ModelBase<InstanceDungeonEntranceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Module.InstanceDungeon.InstanceDungeonEntranceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InstanceDungeonEntranceModel>.Instance);
		if (!ModelBase<ExchangeRewardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.ExchangeReward.ExchangeRewardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ExchangeRewardModel>.Instance);
		if (!ModelBase<InfrastructureModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Infrastructure.InfrastructureModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<InfrastructureModel>.Instance);
		if (!ModelBase<FeedbackRewardModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FeedbackRewardModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FeedbackRewardModel>.Instance);
		if (!ModelBase<AdviceModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdviceModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AdviceModel>.Instance);
		if (!ModelBase<ExploreProgressModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExploreProgressModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ExploreProgressModel>.Instance);
		if (!ModelBase<EffectSaveModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.EffectSave.EffectSaveModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<EffectSaveModel>.Instance);
		if (!ModelBase<BossPilingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BossPiling.BossPilingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BossPilingModel>.Instance);
		if (!ModelBase<BirthdayModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BirthdayModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BirthdayModel>.Instance);
		if (!ModelBase<SkillCdModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.SkillCdModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SkillCdModel>.Instance);
		if (!ModelBase<BattleScoreModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.BattleScoreModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BattleScoreModel>.Instance);
		if (!ModelBase<MoraleBattleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.MoraleBattleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MoraleBattleModel>.Instance);
		if (!ModelBase<BattleLinkModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.BattleLinkModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BattleLinkModel>.Instance);
		if (!ModelBase<BattleInputModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BattleInputModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BattleInputModel>.Instance);
		if (!ModelBase<FlagChallengeBattleModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.FlagChallengeBattleModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FlagChallengeBattleModel>.Instance);
		if (!ModelBase<BuffItemModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuffItemModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BuffItemModel>.Instance);
		if (!ModelBase<CooperationModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CooperationModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CooperationModel>.Instance);
		if (!ModelBase<BattleUiModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUi.BattleUiModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BattleUiModel>.Instance);
		if (!ModelBase<BattleUiSetModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUiSet.BattleUiSetModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BattleUiSetModel>.Instance);
		if (!ModelBase<AutoRunModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AutoRunModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AutoRunModel>.Instance);
		if (!ModelBase<AutoPilotModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.AutoPilot.AutoPilotModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AutoPilotModel>.Instance);
		if (!ModelBase<GameAudioModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Audio.GameAudioModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<GameAudioModel>.Instance);
		if (!ModelBase<AttributeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AttributeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AttributeModel>.Instance);
		if (!ModelBase<AreaModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Area.AreaModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AreaModel>.Instance);
		if (!ModelBase<AntiCheatModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AntiCheatModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AntiCheatModel>.Instance);
		if (!ModelBase<AlertMarkModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUi.Views.AlertMarkModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<AlertMarkModel>.Instance);
		if (!ModelBase<BuildingGridModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuildingGridModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<BuildingGridModel>.Instance);
		if (!ModelBase<CalabashModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CalabashModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CalabashModel>.Instance);
		if (!ModelBase<ChannelModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ChannelModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ChannelModel>.Instance);
		if (!ModelBase<EditFormationModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EditFormationModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<EditFormationModel>.Instance);
		if (!ModelBase<EditBattleTeamModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EditBattleTeamModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<EditBattleTeamModel>.Instance);
		if (!ModelBase<DeadReviveModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.DeadRevive.DeadReviveModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DeadReviveModel>.Instance);
		if (!ModelBase<DeadEyeModeModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DeadEyeModeModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DeadEyeModeModel>.Instance);
		if (!ModelBase<DangoGlobalModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DangoGlobalModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DangoGlobalModel>.Instance);
		if (!ModelBase<DangoAbyssModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DangoAbyssModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DangoAbyssModel>.Instance);
		if (!ModelBase<DailyActivityModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DailyActivityModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<DailyActivityModel>.Instance);
		if (!ModelBase<CookModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Cook.CookModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CookModel>.Instance);
		if (!ModelBase<ControlScreenModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ControlScreenModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ControlScreenModel>.Instance);
		if (!ModelBase<ConfirmBoxModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ConfirmBoxModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ConfirmBoxModel>.Instance);
		if (!ModelBase<SmallItemGridModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SmallItemGridModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SmallItemGridModel>.Instance);
		if (!ModelBase<MediumItemGridModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MediumItemGridModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<MediumItemGridModel>.Instance);
		if (!ModelBase<ItemTipsModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ItemTipsModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ItemTipsModel>.Instance);
		if (!ModelBase<SortModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SortModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<SortModel>.Instance);
		if (!ModelBase<FilterModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FilterModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<FilterModel>.Instance);
		if (!ModelBase<ComboTeachingModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ComboTeachingModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ComboTeachingModel>.Instance);
		if (!ModelBase<CombatMessageModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.CombatMessage.CombatMessageModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CombatMessageModel>.Instance);
		if (!ModelBase<CiacconaGalModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.CiacconaGal.CiacconaGalModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<CiacconaGalModel>.Instance);
		if (!ModelBase<ChatModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ChatModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ChatModel>.Instance);
		if (!ModelBase<ExploreLevelModel>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExploreLevelModel 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ExploreLevelModel>.Instance);
		if (!ModelBase<ModelAndControllerTest.ModelTest>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ModelAndControllerTest.ModelTest 创建模块单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ModelRegister.Models.Add(ModelBase<ModelAndControllerTest.ModelTest>.Instance);
		return true;
	}

	// Token: 0x0601CAC5 RID: 117445 RVA: 0x008A8538 File Offset: 0x008A6738
	public static bool Init()
	{
		for (int i = 0; i < ModelRegister.Models.Count; i++)
		{
			IModelBase modelBase = ModelRegister.Models[i];
			if (!modelBase.Init())
			{
				Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, modelBase.GetType().FullName + " 模块初始化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601CAC6 RID: 117446 RVA: 0x008A85A0 File Offset: 0x008A67A0
	public static bool Clear()
	{
		bool result = true;
		for (int i = 0; i < ModelRegister.Models.Count; i++)
		{
			IModelBase modelBase = ModelRegister.Models[i];
			try
			{
				if (!modelBase.Clear())
				{
					Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, modelBase.GetType().FullName + " 模块清理失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = false;
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = modelBase.GetType().FullName + " 模块清理失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
		}
		return result;
	}

	// Token: 0x0601CAC7 RID: 117447 RVA: 0x008A8664 File Offset: 0x008A6864
	public static bool LeaveLevel()
	{
		bool result = true;
		for (int i = 0; i < ModelRegister.Models.Count; i++)
		{
			IModelBase modelBase = ModelRegister.Models[i];
			try
			{
				if (!modelBase.LeaveLevel())
				{
					Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, modelBase.GetType().FullName + " 模块系统退出关卡失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = false;
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = modelBase.GetType().FullName + " 模块系统退出关卡失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
		}
		return result;
	}

	// Token: 0x0601CAC8 RID: 117448 RVA: 0x008A8728 File Offset: 0x008A6928
	public static bool ChangeMode()
	{
		bool result = true;
		for (int i = 0; i < ModelRegister.Models.Count; i++)
		{
			IModelBase modelBase = ModelRegister.Models[i];
			try
			{
				if (!modelBase.ChangeMode())
				{
					Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, modelBase.GetType().FullName + " 模块系统退出模式失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = false;
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = modelBase.GetType().FullName + " 模块系统退出模式失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
		}
		return result;
	}

	// Token: 0x0400E819 RID: 59417
	[StaticVariableRuleIgnore]
	private static List<IModelBase> Models = new List<IModelBase>(358);
}
