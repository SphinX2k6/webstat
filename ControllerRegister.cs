using System;
using System.Collections.Generic;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Capability;
using CSharpScript.Game.Input;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.IosAudit;
using CSharpScript.Game.LevelFlow;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.AimLine;
using CSharpScript.Game.LevelGamePlay.AlertArea;
using CSharpScript.Game.LevelGamePlay.BigStuffedDoll;
using CSharpScript.Game.LevelGamePlay.Cipher;
using CSharpScript.Game.LevelGamePlay.DigitalScreen;
using CSharpScript.Game.LevelGamePlay.DollGrabMachine;
using CSharpScript.Game.LevelGamePlay.FindSunSprite;
using CSharpScript.Game.LevelGamePlay.FishingQte;
using CSharpScript.Game.LevelGamePlay.FollowShooterHack;
using CSharpScript.Game.LevelGamePlay.GongduolaSummon;
using CSharpScript.Game.LevelGamePlay.GravityFlip;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.LevelGamePlay.ItemInspect;
using CSharpScript.Game.LevelGamePlay.LevelPickControl;
using CSharpScript.Game.LevelGamePlay.LivingCharMeteor;
using CSharpScript.Game.LevelGamePlay.Parkour;
using CSharpScript.Game.LevelGamePlay.ResetPlayer;
using CSharpScript.Game.LevelGamePlay.RollBlock;
using CSharpScript.Game.LevelGamePlay.SeekTrace;
using CSharpScript.Game.LevelGamePlay.SignalDeviceControl;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.LevelGamePlay.SplineMoveTask;
using CSharpScript.Game.LevelGamePlay.SundialControl;
using CSharpScript.Game.LevelGamePlay.SunSpirit;
using CSharpScript.Game.LevelGamePlay.TimeTrackControl;
using CSharpScript.Game.LevelGamePlay.TurntableControl;
using CSharpScript.Game.LevelGamePlay.UnopenedArea;
using CSharpScript.Game.LevelGamePlay.WriteLetter;
using CSharpScript.Game.Module.Activity;
using CSharpScript.Game.Module.Activity.ActivityContent.Anniversary;
using CSharpScript.Game.Module.Activity.ActivityContent.CommonH5;
using CSharpScript.Game.Module.Activity.ActivityContent.Coop;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay;
using CSharpScript.Game.Module.Activity.ActivityContent.Encircle;
using CSharpScript.Game.Module.Activity.ActivityContent.FarmGold;
using CSharpScript.Game.Module.Activity.ActivityContent.FeiXue;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge;
using CSharpScript.Game.Module.Activity.ActivityContent.FunPlay;
using CSharpScript.Game.Module.Activity.ActivityContent.LineCross;
using CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn;
using CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop;
using CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorFight;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour;
using CSharpScript.Game.Module.Activity.ActivityContent.Mowing;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;
using CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor;
using CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball;
using CSharpScript.Game.Module.Activity.ActivityContent.PreWarm;
using CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using CSharpScript.Game.Module.Activity.ActivityContent.RoadBook;
using CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinReward;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.Activity.ActivityContent.Tetris;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity;
using CSharpScript.Game.Module.ActorFxEmote;
using CSharpScript.Game.Module.Application;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.BattleViewDynamicUI;
using CSharpScript.Game.Module.BattleUiSet;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.BossPiling;
using CSharpScript.Game.Module.CiacconaGal;
using CSharpScript.Game.Module.CombatMessage;
using CSharpScript.Game.Module.Comic;
using CSharpScript.Game.Module.Common.Button;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.Cursor;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.DreamLink;
using CSharpScript.Game.Module.EffectSave;
using CSharpScript.Game.Module.FirstPersonTurret;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Module.Gamepad;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemDeliver;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.JoinTeam;
using CSharpScript.Game.Module.KuroAutoCool;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Language;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Login;
using CSharpScript.Game.Module.MailBind;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Manufacture.Forging;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.MechanismTimeline;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.Menu.SubViews.EyeProtect;
using CSharpScript.Game.Module.MingSu;
using CSharpScript.Game.Module.Movement;
using CSharpScript.Game.Module.MovieMode;
using CSharpScript.Game.Module.MusicalInstrument;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Module.QuestMultiLine;
using CSharpScript.Game.Module.QuickHack;
using CSharpScript.Game.Module.QuickTimeAction;
using CSharpScript.Game.Module.RecallQuest;
using CSharpScript.Game.Module.ResManager;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.RoleMorph;
using CSharpScript.Game.Module.Scan;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Module.Season;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Module.Skin.Tab.Weapon;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.SlidingBlocks;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TowerDefenseUi;
using CSharpScript.Game.Module.Transport;
using CSharpScript.Game.Module.TreasureHunt;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;
using CSharpScript.Game.Module.VehicleStream;
using CSharpScript.Game.Module.VillageInfr;
using CSharpScript.Game.Module.WaterMask;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal;
using CSharpScript.Game.Module.WuwaGo.Controller;
using CSharpScript.Game.NewWorld.Character.Common.Controller;
using CSharpScript.Game.NewWorld.Character.Monster.Controller;
using CSharpScript.Game.NewWorld.Character.Npc.Controller;
using CSharpScript.Game.NewWorld.SceneItem.Controller;
using CSharpScript.Game.Render;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Ui.Common.HudOnlyPopup;
using CSharpScript.Game.Utils;
using CSharpScript.Game.Utils.LevelRangeDebug;
using CSharpScript.Game.World.Controller;
using Kuro.Game.Module.Audio;

// Token: 0x0200350F RID: 13583
public class ControllerRegister
{
	// Token: 0x0601CACB RID: 117451 RVA: 0x008A8808 File Offset: 0x008A6A08
	public static bool CreateInstance()
	{
		ControllerRegister.Controllers.Clear();
		ControllerRegister.TickControllers.Clear();
		if (!ControllerBase<AiModelController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AiModelController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AiModelController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<AiModelController>.Instance);
		if (!ControllerBase<PlatformController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PlatformController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PlatformController>.Instance);
		if (!ControllerBase<PilotThrowController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PilotThrowController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PilotThrowController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PilotThrowController>.Instance);
		if (!ControllerBase<PhotographController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhotographController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhotographController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PhotographController>.Instance);
		if (!ControllerBase<PhotographQuickController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhotographQuickController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhotographQuickController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PhotographQuickController>.Instance);
		if (!ControllerBase<PhonographController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhonographController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhonographController>.Instance);
		if (!ControllerBase<PhoneMsgController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhoneMsgController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhoneMsgController>.Instance);
		if (!ControllerBase<PhantomInteractController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhantomInteractController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhantomInteractController>.Instance);
		if (!ControllerBase<VisionRecommendController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VisionRecommendController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<VisionRecommendController>.Instance);
		if (!ControllerBase<VisionEquipGroupController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VisionEquipGroupController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<VisionEquipGroupController>.Instance);
		if (!ControllerBase<PhantomBattleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhantomBattleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhantomBattleController>.Instance);
		if (!ControllerBase<PhantomArenaGuideController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PhantomArena.PhantomArenaGuideController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhantomArenaGuideController>.Instance);
		if (!ControllerBase<PhantomArenaController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PhantomArena.PhantomArenaController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhantomArenaController>.Instance);
		if (!ControllerBase<PlayerInfoController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PlayerInfoController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PlayerInfoController>.Instance);
		if (!ControllerBase<PhantomArenaBattleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PhantomArena.PhantomArenaBattleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PhantomArenaBattleController>.Instance);
		if (!ControllerBase<PersonalController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PersonalController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PersonalController>.Instance);
		if (!ControllerBase<ActivityPermanentRogueController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PermanentRogue.ActivityPermanentRogueController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityPermanentRogueController>.Instance);
		if (!ControllerBase<WeekCardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeekCardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WeekCardController>.Instance);
		if (!ControllerBase<PayShopController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayShopController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PayShopController>.Instance);
		if (!ControllerBase<PayGiftController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayGiftController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PayGiftController>.Instance);
		if (!ControllerBase<MonthCardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MonthCardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MonthCardController>.Instance);
		if (!ControllerBase<BattlePassController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BattlePassController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattlePassController>.Instance);
		if (!ControllerBase<PayItemController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayItemController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PayItemController>.Instance);
		if (!ControllerBase<ParallelPackageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ParallelPackageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ParallelPackageController>.Instance);
		if (!ControllerBase<PanoramicUiDeferController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PanoramicUiDeferController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PanoramicUiDeferController>.Instance);
		if (!ControllerBase<PanoramicController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PanoramicController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PanoramicController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PanoramicController>.Instance);
		if (!ControllerBase<PanelQteController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PanelQteController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PanelQteController>.Instance);
		if (!ControllerBase<PersonalOptionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PersonalOptionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PersonalOptionController>.Instance);
		if (!ControllerBase<FlowController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.Flow.FlowController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FlowController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<FlowController>.Instance);
		if (!ControllerBase<PlotBlendController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotBlendController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PlotBlendController>.Instance);
		if (!ControllerBase<PlotCaptionImageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotCaptionImageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PlotCaptionImageController>.Instance);
		if (!ControllerBase<RouletteExploreSkillController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RouletteExploreSkillController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RouletteExploreSkillController>.Instance);
		if (!ControllerBase<RouletteController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RouletteController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RouletteController>.Instance);
		if (!ControllerBase<RoleLevelUpSuccessController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleLevelUpSuccessController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleLevelUpSuccessController>.Instance);
		if (!ControllerBase<RoleDevController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleDevController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleDevController>.Instance);
		if (!ControllerBase<RoleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleController>.Instance);
		if (!ControllerBase<MainRoleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MainRoleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MainRoleController>.Instance);
		if (!ControllerBase<RoleMorphController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RoleMorph.RoleMorphController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleMorphController>.Instance);
		if (!ControllerBase<RoguelikeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Roguelike.RoguelikeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoguelikeController>.Instance);
		if (!ControllerBase<RogueBattleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RogueBattle.RogueBattleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RogueBattleController>.Instance);
		if (!ControllerBase<RewardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Reward.RewardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RewardController>.Instance);
		if (!ControllerBase<ResourceManagerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ResManager.ResourceManagerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ResourceManagerController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<ResourceManagerController>.Instance);
		if (!ControllerBase<ReportController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ReportController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ReportController>.Instance);
		if (!ControllerBase<ReConnectController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ReConnectController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ReConnectController>.Instance);
		if (!ControllerBase<RecallQuestController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RecallQuest.RecallQuestController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RecallQuestController>.Instance);
		if (!ControllerBase<RandomPlotController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RandomPlotController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RandomPlotController>.Instance);
		if (!ControllerBase<RacingBetsController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RacingBetsController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RacingBetsController>.Instance);
		if (!ControllerBase<QtaController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.QuickTimeAction.QtaController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<QtaController>.Instance);
		if (!ControllerBase<QuickHackController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.QuickHack.QuickHackController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<QuickHackController>.Instance);
		if (!ControllerBase<QuestTreeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestTreeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<QuestTreeController>.Instance);
		if (!ControllerBase<QuestReviewController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestReviewController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<QuestReviewController>.Instance);
		if (!ControllerBase<QuestNewController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestNewController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<QuestNewController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<QuestNewController>.Instance);
		if (!ControllerBase<QuestMultiLineController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<QuestMultiLineController>.Instance);
		if (!ControllerBase<CommonQteController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CommonQteController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CommonQteController>.Instance);
		if (!ControllerBase<BattleQteController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BattleQteController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleQteController>.Instance);
		if (!ControllerBase<PowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PowerController>.Instance);
		if (!ControllerBase<SequenceController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.Sequence.SequenceController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SequenceController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SequenceController>.Instance);
		if (!ControllerBase<PlotController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PlotController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PlotController>.Instance);
		if (!ControllerBase<OnlineController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "OnlineController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<OnlineController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<OnlineController>.Instance);
		if (!ControllerBase<ScanController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Scan.ScanController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ScanController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<ScanController>.Instance);
		if (!ControllerBase<MusicalInstrumentController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MusicalInstrument.MusicalInstrumentController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MusicalInstrumentController>.Instance);
		if (!ControllerBase<MoveTriggerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Movement.MoveTriggerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MoveTriggerController>.Instance);
		if (!ControllerBase<LevelLoadingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.LevelLoading.LevelLoadingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelLoadingController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<LevelLoadingController>.Instance);
		if (!ControllerBase<LanguageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Language.LanguageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LanguageController>.Instance);
		if (!ControllerBase<KurotatoController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Kurotato.KurotatoController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KurotatoController>.Instance);
		if (!ControllerBase<KurotatoActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Kurotato.KurotatoActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KurotatoActivityController>.Instance);
		if (!ControllerBase<KuroPerformanceController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "KuroPerformanceController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KuroPerformanceController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<KuroPerformanceController>.Instance);
		if (!ControllerBase<KuroFastCollisionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "KuroFastCollisionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KuroFastCollisionController>.Instance);
		if (!ControllerBase<KuroAutoCoolController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.KuroAutoCool.KuroAutoCoolController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KuroAutoCoolController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<KuroAutoCoolController>.Instance);
		if (!ControllerBase<JoinTeamController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.JoinTeam.JoinTeamController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<JoinTeamController>.Instance);
		if (!ControllerBase<SpecialItemController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SpecialItemController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SpecialItemController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SpecialItemController>.Instance);
		if (!ControllerBase<ItemController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Item.ItemController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ItemController>.Instance);
		if (!ControllerBase<ItemRewardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ItemReward.ItemRewardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ItemRewardController>.Instance);
		if (!ControllerBase<ItemHintController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ItemHintController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ItemHintController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<ItemHintController>.Instance);
		if (!ControllerBase<LevelPlayReportController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelPlayReportController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelPlayReportController>.Instance);
		if (!ControllerBase<ItemExchangeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ItemExchangeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ItemExchangeController>.Instance);
		if (!ControllerBase<InventoryGiftController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InventoryGiftController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InventoryGiftController>.Instance);
		if (!ControllerBase<InventoryController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InventoryController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InventoryController>.Instance);
		if (!ControllerBase<InteractionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Interaction.InteractionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InteractionController>.Instance);
		if (!ControllerBase<InstanceGameplayModeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InstanceGameplayModeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InstanceGameplayModeController>.Instance);
		if (!ControllerBase<InstanceDungeonGuideController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonGuideController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InstanceDungeonGuideController>.Instance);
		if (!ControllerBase<InstanceDungeonEntranceController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonEntranceController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InstanceDungeonEntranceController>.Instance);
		if (!ControllerBase<InstanceDungeonController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InstanceDungeonController>.Instance);
		if (!ControllerBase<ExchangeRewardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.ExchangeReward.ExchangeRewardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ExchangeRewardController>.Instance);
		if (!ControllerBase<InfrastructureController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Infrastructure.InfrastructureController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InfrastructureController>.Instance);
		if (!ControllerBase<InfoDisplayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InfoDisplayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InfoDisplayController>.Instance);
		if (!ControllerBase<InfluenceReputationController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InfluenceReputationController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InfluenceReputationController>.Instance);
		if (!ControllerBase<IdlePerformController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "IdlePerformController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<IdlePerformController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<IdlePerformController>.Instance);
		if (!ControllerBase<ItemDeliverController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ItemDeliver.ItemDeliverController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ItemDeliverController>.Instance);
		if (!ControllerBase<LevelPlayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelPlayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelPlayController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<LevelPlayController>.Instance);
		if (!ControllerBase<LevelUpController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelUpController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelUpController>.Instance);
		if (!ControllerBase<LoadingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoadingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LoadingController>.Instance);
		if (!ControllerBase<MovementLockController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MovementLockController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MovementLockController>.Instance);
		if (!ControllerBase<MotorcycleMusicPlayerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleMusicPlayerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MotorcycleMusicPlayerController>.Instance);
		if (!ControllerBase<MotorcycleDiyController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleDiyController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MotorcycleDiyController>.Instance);
		if (!ControllerBase<MotorcycleDevelopController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleDevelopController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MotorcycleDevelopController>.Instance);
		if (!ControllerBase<MotionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MotionController>.Instance);
		if (!ControllerBase<MoraleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoraleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MoraleController>.Instance);
		if (!ControllerBase<PreDownloadController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PreDownloadController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PreDownloadController>.Instance);
		if (!ControllerBase<MingSuController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MingSu.MingSuController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MingSuController>.Instance);
		if (!ControllerBase<MeshStreamController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MeshStreamController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MeshStreamController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<MeshStreamController>.Instance);
		if (!ControllerBase<EyeProtectController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Menu.SubViews.EyeProtect.EyeProtectController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<EyeProtectController>.Instance);
		if (!ControllerBase<MenuController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Menu.MenuController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MenuController>.Instance);
		if (!ControllerBase<FilterSettingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FilterSettingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FilterSettingController>.Instance);
		if (!ControllerBase<MechanismTimelineController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MechanismTimeline.MechanismTimelineController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MechanismTimelineController>.Instance);
		if (!ControllerBase<MarqueeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MarqueeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MarqueeController>.Instance);
		if (!ControllerBase<MapController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Map.Controller.MapController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MapController>.Instance);
		if (!ControllerBase<MapRogueController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MapRogue.MapRogueController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MapRogueController>.Instance);
		if (!ControllerBase<MapExploreToolController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MapExploreToolController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MapExploreToolController>.Instance);
		if (!ControllerBase<ForgingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Manufacture.Forging.ForgingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ForgingController>.Instance);
		if (!ControllerBase<ComposeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Manufacture.Compose.ComposeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ComposeController>.Instance);
		if (!ControllerBase<MailController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MailController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MailController>.Instance);
		if (!ControllerBase<MailBindController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MailBind.MailBindController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MailBindController>.Instance);
		if (!ControllerBase<LordGymController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LordGymController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LordGymController>.Instance);
		if (!ControllerBase<LogReportController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LogReportController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LogReportController>.Instance);
		if (!ControllerBase<GamepadLogReportController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GamepadLogReportController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GamepadLogReportController>.Instance);
		if (!ControllerBase<LoginServerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoginServerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LoginServerController>.Instance);
		if (!ControllerBase<LoginGatewayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Login.LoginGatewayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LoginGatewayController>.Instance);
		if (!ControllerBase<LoginController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoginController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LoginController>.Instance);
		if (!ControllerBase<MovieModeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MovieMode.MovieModeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MovieModeController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<MovieModeController>.Instance);
		if (!ControllerBase<SceneBattleInteractController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SceneBattleInteractController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SceneBattleInteractController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SceneBattleInteractController>.Instance);
		if (!ControllerBase<SceneTeamController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SceneTeamController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SceneTeamController>.Instance);
		if (!ControllerBase<ScreenShotController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ScreenShotController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ScreenShotController>.Instance);
		if (!ControllerBase<CombatDebugController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Utils.CombatDebugController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CombatDebugController>.Instance);
		if (!ControllerBase<SceneUiController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.SceneUiController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SceneUiController>.Instance);
		if (!ControllerBase<LguiEventSystemController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.LguiEventSystemController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LguiEventSystemController>.Instance);
		if (!ControllerBase<InputDistributeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.InputDistributeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InputDistributeController>.Instance);
		if (!ControllerBase<HudOnlyPopupController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.Common.HudOnlyPopup.HudOnlyPopupController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HudOnlyPopupController>.Instance);
		if (!ControllerBase<ServerStorageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.ServerStorage.ServerStorageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ServerStorageController>.Instance);
		if (!ControllerBase<RenderModuleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Render.RenderModuleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RenderModuleController>.Instance);
		if (!ControllerBase<RedDotController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RedDotController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RedDotController>.Instance);
		if (!ControllerBase<PerfSightController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PerfSightController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PerfSightController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PerfSightController>.Instance);
		if (!ControllerBase<VehiclePathMoveController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VehiclePathMoveController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<VehiclePathMoveController>.Instance);
		if (!ControllerBase<VehicleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VehicleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<VehicleController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<VehicleController>.Instance);
		if (!ControllerBase<SlashGameplayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Controller.SlashGameplayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SlashGameplayController>.Instance);
		if (!ControllerBase<CombatDebugDrawController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CombatDebugDrawController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CombatDebugDrawController>.Instance);
		if (!ControllerBase<SceneItemMoveController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Controller.SceneItemMoveController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SceneItemMoveController>.Instance);
		if (!ControllerBase<SceneItemBuffController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Controller.SceneItemBuffController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SceneItemBuffController>.Instance);
		if (!ControllerBase<PortalController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Controller.PortalController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PortalController>.Instance);
		if (!ControllerBase<GravityHookController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Controller.GravityHookController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GravityHookController>.Instance);
		if (!ControllerBase<FlyingFeatherController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Controller.FlyingFeatherController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FlyingFeatherController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<FlyingFeatherController>.Instance);
		if (!ControllerBase<ChargeSlashGameplayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Controller.ChargeSlashGameplayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ChargeSlashGameplayController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<ChargeSlashGameplayController>.Instance);
		if (!ControllerBase<SimpleNpcLoadController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SimpleNpcLoadController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SimpleNpcLoadController>.Instance);
		if (!ControllerBase<SimpleNpcController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SimpleNpcController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SimpleNpcController>.Instance);
		if (!ControllerBase<RoleTriggerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleTriggerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleTriggerController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<RoleTriggerController>.Instance);
		if (!ControllerBase<RoleAudioController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleAudioController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleAudioController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<RoleAudioController>.Instance);
		if (!ControllerBase<NpcVehicleRiderController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "NpcVehicleRiderController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<NpcVehicleRiderController>.Instance);
		if (!ControllerBase<NpcTimetableController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Character.Npc.Controller.NpcTimetableController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<NpcTimetableController>.Instance);
		if (!ControllerBase<NpcPerformController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "NpcPerformController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<NpcPerformController>.Instance);
		if (!ControllerBase<SceneItemCaptureController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SceneItemCaptureController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SceneItemCaptureController>.Instance);
		if (!ControllerBase<LevelRangeDebugDrawController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Utils.LevelRangeDebug.LevelRangeDebugDrawController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelRangeDebugDrawController>.Instance);
		if (!ControllerBase<ExpressionTreeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExpressionTreeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ExpressionTreeController>.Instance);
		if (!ControllerBase<AceAntiCheatController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AceAntiCheatController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AceAntiCheatController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<AceAntiCheatController>.Instance);
		if (!ControllerBase<WorldDebugController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.WorldDebugController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WorldDebugController>.Instance);
		if (!ControllerBase<WorldController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WorldController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WorldController>.Instance);
		if (!ControllerBase<UpdateRateOptimizeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.UpdateRateOptimizeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<UpdateRateOptimizeController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<UpdateRateOptimizeController>.Instance);
		if (!ControllerBase<TimeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TimeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TimeController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<TimeController>.Instance);
		if (!ControllerBase<SyncSplineMoveController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.SyncSplineMoveController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SyncSplineMoveController>.Instance);
		if (!ControllerBase<SubLevelController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.SubLevelController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SubLevelController>.Instance);
		if (!ControllerBase<SneakController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.SneakController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SneakController>.Instance);
		if (!ControllerBase<ServerGmController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.ServerGmController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ServerGmController>.Instance);
		if (!ControllerBase<SceneOpacityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SceneOpacityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SceneOpacityController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SceneOpacityController>.Instance);
		if (!ControllerBase<ResetTimeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ResetTimeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ResetTimeController>.Instance);
		if (!ControllerBase<PreloadControllerNew>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PreloadControllerNew 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PreloadControllerNew>.Instance);
		if (!ControllerBase<PlayerVelocityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.PlayerVelocityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PlayerVelocityController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PlayerVelocityController>.Instance);
		if (!ControllerBase<PlayerSoarMonitorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.PlayerSoarMonitorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PlayerSoarMonitorController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<PlayerSoarMonitorController>.Instance);
		if (!ControllerBase<MultiInteractionActorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.MultiInteractionActorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MultiInteractionActorController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<MultiInteractionActorController>.Instance);
		if (!ControllerBase<LowMemoryScalabilityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.LowMemoryScalabilityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LowMemoryScalabilityController>.Instance);
		if (!ControllerBase<LogController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LogController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LogController>.Instance);
		if (!ControllerBase<LoadMapController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoadMapController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LoadMapController>.Instance);
		if (!ControllerBase<HierarchyLoadingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HierarchyLoadingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HierarchyLoadingController>.Instance);
		if (!ControllerBase<GameModeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GameModeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GameModeController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<GameModeController>.Instance);
		if (!ControllerBase<CreatureGroupController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CreatureGroupController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CreatureGroupController>.Instance);
		if (!ControllerBase<CreatureController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CreatureController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CreatureController>.Instance);
		if (!ControllerBase<ComponentForceTickController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Controller.ComponentForceTickController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ComponentForceTickController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<ComponentForceTickController>.Instance);
		if (!ControllerBase<BpActorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BpActorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BpActorController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<BpActorController>.Instance);
		if (!ControllerBase<BlackboardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BlackboardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BlackboardController>.Instance);
		if (!ControllerBase<BattleLogicController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BattleLogicController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleLogicController>.Instance);
		if (!ControllerBase<AttachToActorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AttachToActorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AttachToActorController>.Instance);
		if (!ControllerBase<AoiController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AoiController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AoiController>.Instance);
		if (!ControllerBase<CrowdAiController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CrowdAiController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CrowdAiController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<CrowdAiController>.Instance);
		if (!ControllerBase<MonsterGroupPatrolController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MonsterGroupPatrolController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MonsterGroupPatrolController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<MonsterGroupPatrolController>.Instance);
		if (!ControllerBase<MonsterGroupEcologyController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Character.Monster.Controller.MonsterGroupEcologyController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MonsterGroupEcologyController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<MonsterGroupEcologyController>.Instance);
		if (!ControllerBase<CharacterRailSlideController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Character.Common.Controller.CharacterRailSlideController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CharacterRailSlideController>.Instance);
		if (!ControllerBase<TowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TowerController>.Instance);
		if (!ControllerBase<TowerDefenseUiController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.TowerDefenseUi.TowerDefenseUiController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TowerDefenseUiController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<TowerDefenseUiController>.Instance);
		if (!ControllerBase<TowerDefenseEventController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.TowerDefenseEvent.TowerDefenseEventController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TowerDefenseEventController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<TowerDefenseEventController>.Instance);
		if (!ControllerBase<TowerDefenseController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TowerDefenseController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TowerDefenseController>.Instance);
		if (!ControllerBase<TimeOfDayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TimeOfDayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TimeOfDayController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<TimeOfDayController>.Instance);
		if (!ControllerBase<TermExplanationController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TermExplanationController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TermExplanationController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<TermExplanationController>.Instance);
		if (!ControllerBase<TeleportController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Teleport.TeleportController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TeleportController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<TeleportController>.Instance);
		if (!ControllerBase<SurvivorsRogueController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SurvivorsRogueController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SurvivorsRogueController>.Instance);
		if (!ControllerBase<SurvivorsActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SurvivorsActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SurvivorsActivityController>.Instance);
		if (!ControllerBase<SubPackageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SubPackageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SubPackageController>.Instance);
		if (!ControllerBase<SplashScreenController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SplashScreenController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SplashScreenController>.Instance);
		if (!ControllerBase<SpecialTransitionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SpecialTransitionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SpecialTransitionController>.Instance);
		if (!ControllerBase<SoundAreaPlayTipsController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SoundAreaPlayTipsController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SoundAreaPlayTipsController>.Instance);
		if (!ControllerBase<SlidingBlocksController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SlidingBlocks.SlidingBlocksController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SlidingBlocksController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SlidingBlocksController>.Instance);
		if (!ControllerBase<SkipInterfaceController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SkipInterface.SkipInterfaceController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SkipInterfaceController>.Instance);
		if (!ControllerBase<WeaponSkinController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Skin.Tab.Weapon.WeaponSkinController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WeaponSkinController>.Instance);
		if (!ControllerBase<FlySkinController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FlySkinController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FlySkinController>.Instance);
		if (!ControllerBase<CalabashSkinController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CalabashSkinController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CalabashSkinController>.Instance);
		if (!ControllerBase<SkinController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SkinController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SkinController>.Instance);
		if (!ControllerBase<SkillButtonUiController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SkillButtonUi.SkillButtonUiController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SkillButtonUiController>.Instance);
		if (!ControllerBase<SignalDecodeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SignalDecodeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SignalDecodeController>.Instance);
		if (!ControllerBase<ShopController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShopController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ShopController>.Instance);
		if (!ControllerBase<ShipTowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShipTowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ShipTowerController>.Instance);
		if (!ControllerBase<SheriffController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Sheriff.SheriffController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SheriffController>.Instance);
		if (!ControllerBase<SeasonController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Season.SeasonController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SeasonController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SeasonController>.Instance);
		if (!ControllerBase<SeamlessTravelController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SeamlessTravel.SeamlessTravelController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SeamlessTravelController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SeamlessTravelController>.Instance);
		if (!ControllerBase<ScrollingTipsController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ScrollingTipsController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ScrollingTipsController>.Instance);
		if (!ControllerBase<TrackController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TrackController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TrackController>.Instance);
		if (!ControllerBase<HudUnitController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HudUnitController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HudUnitController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<HudUnitController>.Instance);
		if (!ControllerBase<TransportNetworkController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Transport.TransportNetworkController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TransportNetworkController>.Instance);
		if (!ControllerBase<TreasureHuntController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.TreasureHunt.TreasureHuntController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TreasureHuntController>.Instance);
		if (!ControllerBase<CharacterEmotionBubbleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.Character.Common.Controller.CharacterEmotionBubbleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CharacterEmotionBubbleController>.Instance);
		if (!ControllerBase<PerformController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PerformController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PerformController>.Instance);
		if (!ControllerBase<DynamicFlowController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DynamicFlowController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DynamicFlowController>.Instance);
		if (!ControllerBase<PassiveSkillPlayerQueueController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PassiveSkillPlayerQueueController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PassiveSkillPlayerQueueController>.Instance);
		if (!ControllerBase<BuffController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuffController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BuffController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<BuffController>.Instance);
		if (!ControllerBase<CharacterShadowController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CharacterShadowController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CharacterShadowController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<CharacterShadowController>.Instance);
		if (!ControllerBase<CharacterController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CharacterController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CharacterController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<CharacterController>.Instance);
		if (!ControllerBase<BulletController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BulletController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BulletController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<BulletController>.Instance);
		if (!ControllerBase<WuWaGoController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WuwaGo.Controller.WuWaGoController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WuWaGoController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<WuWaGoController>.Instance);
		if (!ControllerBase<WorldMapController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WorldMap.WorldMapController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WorldMapController>.Instance);
		if (!ControllerBase<RegionalTerminalController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WorldMap.RegionalTerminal.RegionalTerminalController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RegionalTerminalController>.Instance);
		if (!ControllerBase<WorldLevelController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WorldLevelController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WorldLevelController>.Instance);
		if (!ControllerBase<WeeklyRogueController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeeklyRogueController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WeeklyRogueController>.Instance);
		if (!ControllerBase<WeeklyChallengeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeeklyChallengeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WeeklyChallengeController>.Instance);
		if (!ControllerBase<WeatherController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Weather.WeatherController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WeatherController>.Instance);
		if (!ControllerBase<WeaponController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeaponController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WeaponController>.Instance);
		if (WaterMaskView.ShouldRegister())
		{
			if (!ControllerBase<WaterMaskView>.CreateInstance())
			{
				Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WaterMask.WaterMaskView 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			ControllerRegister.Controllers.Add(ControllerBase<WaterMaskView>.Instance);
		}
		if (!ControllerBase<WaitEntityTaskController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WaitEntityTaskController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WaitEntityTaskController>.Instance);
		if (!ControllerBase<VillageInfrController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.VillageInfr.VillageInfrController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<VillageInfrController>.Instance);
		if (!ControllerBase<VideoBpController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VideoBpController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<VideoBpController>.Instance);
		if (!ControllerBase<VehicleStreamController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.VehicleStream.VehicleStreamController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<VehicleStreamController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<VehicleStreamController>.Instance);
		if (!ControllerBase<UiNavigationNewController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiNavigationNewController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<UiNavigationNewController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<UiNavigationNewController>.Instance);
		if (!ControllerBase<UiModelEffectController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiModelEffectController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<UiModelEffectController>.Instance);
		if (!ControllerBase<HomeBtnController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.UiComponent.UiHomeButton.HomeBtnController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HomeBtnController>.Instance);
		if (!ControllerBase<UiCameraController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiCameraController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<UiCameraController>.Instance);
		if (!ControllerBase<UiCameraAnimationController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiCameraAnimationController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<UiCameraAnimationController>.Instance);
		if (!ControllerBase<TutorialController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TutorialController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TutorialController>.Instance);
		if (!ControllerBase<TrapDefenseController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TrapDefenseController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TrapDefenseController>.Instance);
		if (!ControllerBase<HonamiStoryController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.HonamiStory.HonamiStoryController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HonamiStoryController>.Instance);
		if (!ControllerBase<HoldingHandsController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HoldingHandsController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HoldingHandsController>.Instance);
		if (!ControllerBase<HideActorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HideActorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HideActorController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<HideActorController>.Instance);
		if (!ControllerBase<FightPhotoController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FightPhotoController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FightPhotoController>.Instance);
		if (!ControllerBase<ActivityFeiXuePreheatController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.FeiXue.ActivityFeiXuePreheatController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityFeiXuePreheatController>.Instance);
		if (!ControllerBase<FarmGoldController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.FarmGold.FarmGoldController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FarmGoldController>.Instance);
		if (!ControllerBase<ActivityEncircleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Encircle.ActivityEncircleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityEncircleController>.Instance);
		if (!ControllerBase<DropCatchGameplayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.DropCatchGameplayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DropCatchGameplayController>.Instance);
		if (!ControllerBase<DropCatchActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.DropCatchActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DropCatchActivityController>.Instance);
		if (!ControllerBase<ActivityDoubleRewardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityDoubleRewardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityDoubleRewardController>.Instance);
		if (!ControllerBase<DirectTrainActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity.DirectTrainActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DirectTrainActivityController>.Instance);
		if (!ControllerBase<ActivityDirectTrainController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.ActivityDirectTrainController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityDirectTrainController>.Instance);
		if (!ControllerBase<ActivityDangoMonopolyController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityDangoMonopolyController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityDangoMonopolyController>.Instance);
		if (!ControllerBase<DangoAbyssActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DangoAbyssActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DangoAbyssActivityController>.Instance);
		if (!ControllerBase<DailyAdventureTaskController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DailyAdventureTaskController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DailyAdventureTaskController>.Instance);
		if (!ControllerBase<ActivityFishingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Fishing.ActivityFishingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityFishingController>.Instance);
		if (!ControllerBase<ActivityDailyAdventureController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityDailyAdventureController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityDailyAdventureController>.Instance);
		if (!ControllerBase<AdamSmasherController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk.AdamSmasherController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AdamSmasherController>.Instance);
		if (!ControllerBase<CumulativeShopController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CumulativeShopController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CumulativeShopController>.Instance);
		if (!ControllerBase<ActivityCorniceMeetingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityCorniceMeetingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityCorniceMeetingController>.Instance);
		if (!ControllerBase<CoopActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Coop.CoopActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CoopActivityController>.Instance);
		if (!ControllerBase<CommonH5Controller>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.CommonH5.CommonH5Controller 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CommonH5Controller>.Instance);
		if (!ControllerBase<ActivityCollectionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityCollectionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityCollectionController>.Instance);
		if (!ControllerBase<CiacconaActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CiacconaActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CiacconaActivityController>.Instance);
		if (!ControllerBase<ChessController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ChessController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ChessController>.Instance);
		if (!ControllerBase<BossRushController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BossRushController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BossRushController>.Instance);
		if (!ControllerBase<ActivityBlackCoastController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityBlackCoastController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityBlackCoastController>.Instance);
		if (!ControllerBase<BeginnerCarnivalController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BeginnerCarnivalController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BeginnerCarnivalController>.Instance);
		if (!ControllerBase<ActivityBeginnerBookController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityBeginnerBookController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityBeginnerBookController>.Instance);
		if (!ControllerBase<CyberPunkController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk.CyberPunkController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CyberPunkController>.Instance);
		if (!ControllerBase<FishingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Fishing.FishingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FishingController>.Instance);
		if (!ControllerBase<ActivityFlagChallengeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.FlagChallenge.ActivityFlagChallengeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityFlagChallengeController>.Instance);
		if (!ControllerBase<ActivityFunPlayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.FunPlay.ActivityFunPlayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityFunPlayController>.Instance);
		if (!ControllerBase<ActivityNewcomerJourneyController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNewcomerJourneyController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityNewcomerJourneyController>.Instance);
		if (!ControllerBase<NewbieMainController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain.NewbieMainController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<NewbieMainController>.Instance);
		if (!ControllerBase<ActivityNewbieCourseV2Controller>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNewbieCourseV2Controller 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityNewbieCourseV2Controller>.Instance);
		if (!ControllerBase<MultiMotorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor.MultiMotorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MultiMotorController>.Instance);
		if (!ControllerBase<ActivityMowingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Mowing.ActivityMowingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMowingController>.Instance);
		if (!ControllerBase<MowingTowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MowingTowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MowingTowerController>.Instance);
		if (!ControllerBase<ActivityMowingRiskController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk.ActivityMowingRiskController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMowingRiskController>.Instance);
		if (!ControllerBase<MotorParkourController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour.MotorParkourController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MotorParkourController>.Instance);
		if (!ControllerBase<ActivityMotorGiftController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMotorGiftController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMotorGiftController>.Instance);
		if (!ControllerBase<MotorFightController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotorFight.MotorFightController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MotorFightController>.Instance);
		if (!ControllerBase<MotorDecalLinkController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink.MotorDecalLinkController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MotorDecalLinkController>.Instance);
		if (!ControllerBase<ActivityMotorLinkageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage.ActivityMotorLinkageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMotorLinkageController>.Instance);
		if (!ControllerBase<ActivityMotorDevelopController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop.ActivityMotorDevelopController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMotorDevelopController>.Instance);
		if (!ControllerBase<ActivityMoraleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMoraleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMoraleController>.Instance);
		if (!ControllerBase<MoonSignInController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn.MoonSignInController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MoonSignInController>.Instance);
		if (!ControllerBase<MoonChasingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MoonChasingController>.Instance);
		if (!ControllerBase<ActivityMoonChasingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMoonChasingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMoonChasingController>.Instance);
		if (!ControllerBase<ActivityMapTravelController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMapTravelController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMapTravelController>.Instance);
		if (!ControllerBase<ActivityMapExploreController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMapExploreController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityMapExploreController>.Instance);
		if (!ControllerBase<ActivityLordGymController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityLordGymController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityLordGymController>.Instance);
		if (!ControllerBase<ActivityLoopTowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityLoopTowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityLoopTowerController>.Instance);
		if (!ControllerBase<ActivityLongShanController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityLongShanController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityLongShanController>.Instance);
		if (!ControllerBase<LinkageRewardActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward.LinkageRewardActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LinkageRewardActivityController>.Instance);
		if (!ControllerBase<LineCrossActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.LineCross.LineCrossActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LineCrossActivityController>.Instance);
		if (!ControllerBase<LifePointDrawActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LifePointDrawActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LifePointDrawActivityController>.Instance);
		if (!ControllerBase<ActivityInviteNewbieController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityInviteNewbieController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityInviteNewbieController>.Instance);
		if (!ControllerBase<GuQinActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.GuQinActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GuQinActivityController>.Instance);
		if (!ControllerBase<BabelTowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BabelTowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BabelTowerController>.Instance);
		if (!ControllerBase<AvignonController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AvignonController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AvignonController>.Instance);
		if (!ControllerBase<ArtemisActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ArtemisActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ArtemisActivityController>.Instance);
		if (!ControllerBase<AnniversaryActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Anniversary.AnniversaryActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AnniversaryActivityController>.Instance);
		if (!ControllerBase<GravityFlipController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.GravityFlip.GravityFlipController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GravityFlipController>.Instance);
		if (!ControllerBase<GongduolaSummonController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.GongduolaSummon.GongduolaSummonController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GongduolaSummonController>.Instance);
		if (!ControllerBase<FollowShooterHackController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.FollowShooterHack.FollowShooterHackController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FollowShooterHackController>.Instance);
		if (!ControllerBase<FishingQteController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.FishingQte.FishingQteController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FishingQteController>.Instance);
		if (!ControllerBase<FindSunSpiritController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.FindSunSprite.FindSunSpiritController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FindSunSpiritController>.Instance);
		if (!ControllerBase<DollGrabShowcaseController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabShowcaseController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DollGrabShowcaseController>.Instance);
		if (!ControllerBase<DollGrabMachineController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DollGrabMachineController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<DollGrabMachineController>.Instance);
		if (!ControllerBase<DigitalScreenController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.DigitalScreen.DigitalScreenController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DigitalScreenController>.Instance);
		if (!ControllerBase<CipherController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Cipher.CipherController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CipherController>.Instance);
		if (!ControllerBase<BigStuffedDollController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.BigStuffedDoll.BigStuffedDollController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BigStuffedDollController>.Instance);
		if (!ControllerBase<AlertAreaController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.AlertArea.AlertAreaController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AlertAreaController>.Instance);
		if (!ControllerBase<LevelAimLineController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.AimLine.LevelAimLineController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelAimLineController>.Instance);
		if (!ControllerBase<LevelFlowController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelFlow.LevelFlowController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelFlowController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<LevelFlowController>.Instance);
		if (!ControllerBase<KuroSimpleCombatController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "KuroSimpleCombatController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KuroSimpleCombatController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<KuroSimpleCombatController>.Instance);
		if (!ControllerBase<OpenHarmonySdkController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "OpenHarmonySdkController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<OpenHarmonySdkController>.Instance);
		if (!ControllerBase<KuroSdkController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "KuroSdkController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KuroSdkController>.Instance);
		if (!ControllerBase<KuroPushController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "KuroPushController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<KuroPushController>.Instance);
		if (!ControllerBase<IosAuditController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.IosAudit.IosAuditController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<IosAuditController>.Instance);
		if (!ControllerBase<InputController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Input.InputController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InputController>.Instance);
		if (!ControllerBase<TouchUiEditController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.InputSetting.TouchUiEditController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TouchUiEditController>.Instance);
		if (!ControllerBase<InputSettingsController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.InputSetting.InputSettingsController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<InputSettingsController>.Instance);
		if (!ControllerBase<GameSettingsController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GameSettingsController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GameSettingsController>.Instance);
		if (!ControllerBase<EffectAudioController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EffectAudioController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<EffectAudioController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<EffectAudioController>.Instance);
		if (!ControllerBase<CrashCollectionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CrashCollectionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CrashCollectionController>.Instance);
		if (!ControllerBase<CapabilityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Capability.CapabilityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CapabilityController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<CapabilityController>.Instance);
		if (!ControllerBase<CameraNearClipController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Camera.CameraNearClipController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CameraNearClipController>.Instance);
		if (!ControllerBase<CameraController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Camera.CameraController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CameraController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<CameraController>.Instance);
		if (!ControllerBase<GuaranteeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GuaranteeController>.Instance);
		if (!ControllerBase<ActivityNewPlayerSupportActivityV2Controller>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNewPlayerSupportActivityV2Controller 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityNewPlayerSupportActivityV2Controller>.Instance);
		if (!ControllerBase<ItemInspectController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.ItemInspect.ItemInspectController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ItemInspectController>.Instance);
		if (!ControllerBase<LevelGeneralController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LevelGeneralController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelGeneralController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<LevelGeneralController>.Instance);
		if (!ControllerBase<AdvanceNoticeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdvanceNoticeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AdvanceNoticeController>.Instance);
		if (!ControllerBase<ActivityLinkageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityLinkageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityLinkageController>.Instance);
		if (!ControllerBase<ActivityRecommendController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRecommendController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRecommendController>.Instance);
		if (!ControllerBase<RhythmGameShipController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RhythmGameShipController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RhythmGameShipController>.Instance);
		if (!ControllerBase<RhythmGameController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RhythmGameController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RhythmGameController>.Instance);
		if (!ControllerBase<GuessJokerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GuessJokerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GuessJokerController>.Instance);
		if (!ControllerBase<GolemHackingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GolemHackingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GolemHackingController>.Instance);
		if (!ControllerBase<FurnitureController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FurnitureController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FurnitureController>.Instance);
		if (!ControllerBase<AchievementController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AchievementController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AchievementController>.Instance);
		if (!ControllerBase<FormationDataController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FormationDataController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FormationDataController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<FormationDataController>.Instance);
		if (!ControllerBase<FormationAttributeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FormationAttributeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FormationAttributeController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<FormationAttributeController>.Instance);
		if (!ControllerBase<WriteLetterController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.WriteLetter.WriteLetterController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WriteLetterController>.Instance);
		if (!ControllerBase<UnopenedAreaController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.UnopenedArea.UnopenedAreaController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<UnopenedAreaController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<UnopenedAreaController>.Instance);
		if (!ControllerBase<TurntableControlController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.TurntableControl.TurntableControlController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TurntableControlController>.Instance);
		if (!ControllerBase<TimeTrackController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.TimeTrackControl.TimeTrackController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TimeTrackController>.Instance);
		if (!ControllerBase<SunSpiritController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SunSpiritController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SunSpiritController>.Instance);
		if (!ControllerBase<SundialControlController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SundialControl.SundialControlController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SundialControlController>.Instance);
		if (!ControllerBase<SplineMoveTaskController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SplineMoveTask.SplineMoveTaskController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SplineMoveTaskController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SplineMoveTaskController>.Instance);
		if (!ControllerBase<SplineConstrainedDragController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.SplineConstrainedDragController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SplineConstrainedDragController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SplineConstrainedDragController>.Instance);
		if (!ControllerBase<SignalDeviceController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SignalDeviceControl.SignalDeviceController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SignalDeviceController>.Instance);
		if (!ControllerBase<SeekTraceController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.SeekTrace.SeekTraceController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SeekTraceController>.Instance);
		if (!ControllerBase<RollBlockController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.RollBlock.RollBlockController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RollBlockController>.Instance);
		if (!ControllerBase<ResetPlayerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.ResetPlayer.ResetPlayerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ResetPlayerController>.Instance);
		if (!ControllerBase<ProjectionPhotoController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ProjectionPhotoController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ProjectionPhotoController>.Instance);
		if (!ControllerBase<ParkourController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Parkour.ParkourController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ParkourController>.Instance);
		if (!ControllerBase<LivingCharMeteorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LivingCharMeteor.LivingCharMeteorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LivingCharMeteorController>.Instance);
		if (!ControllerBase<LevelPickInteractController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LevelPickControl.LevelPickInteractController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelPickInteractController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<LevelPickInteractController>.Instance);
		if (!ControllerBase<LevelGamePlayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LevelGamePlayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<LevelGamePlayController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<LevelGamePlayController>.Instance);
		if (!ControllerBase<EnvironmentalPerceptionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EnvironmentalPerceptionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<EnvironmentalPerceptionController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<EnvironmentalPerceptionController>.Instance);
		if (!ControllerBase<ActivityNewPlayerSupportController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNewPlayerSupportController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityNewPlayerSupportController>.Instance);
		if (!ControllerBase<ActivityPhantomCollectController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityPhantomCollectController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityPhantomCollectController>.Instance);
		if (!ControllerBase<DeadEyeModeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DeadEyeModeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DeadEyeModeController>.Instance);
		if (!ControllerBase<DangoGlobalController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DangoGlobalController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DangoGlobalController>.Instance);
		if (!ControllerBase<DangoAbyssController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DangoAbyssController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DangoAbyssController>.Instance);
		if (!ControllerBase<DamageUiController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DamageUiController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DamageUiController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<DamageUiController>.Instance);
		if (!ControllerBase<DailyActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DailyActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DailyActivityController>.Instance);
		if (!ControllerBase<CursorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Cursor.CursorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CursorController>.Instance);
		if (!ControllerBase<CreateCharacterController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CreateCharacterController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CreateCharacterController>.Instance);
		if (!ControllerBase<CookController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Cook.CookController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CookController>.Instance);
		if (!ControllerBase<ControlScreenController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ControlScreenController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ControlScreenController>.Instance);
		if (!ControllerBase<ConfirmBoxController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ConfirmBoxController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ConfirmBoxController>.Instance);
		if (!ControllerBase<CommonSuccessController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CommonSuccessController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CommonSuccessController>.Instance);
		if (!ControllerBase<CommonInputViewController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Common.InputView.Controller.CommonInputViewController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CommonInputViewController>.Instance);
		if (!ControllerBase<DeadReviveController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.DeadRevive.DeadReviveController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DeadReviveController>.Instance);
		if (!ControllerBase<FilterSortController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FilterSortController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FilterSortController>.Instance);
		if (!ControllerBase<ComicController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Comic.ComicController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ComicController>.Instance);
		if (!ControllerBase<ComboTeachingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ComboTeachingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ComboTeachingController>.Instance);
		if (!ControllerBase<SkillMessageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.CombatMessage.SkillMessageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SkillMessageController>.Instance);
		if (!ControllerBase<RoleSceneInteractController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleSceneInteractController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleSceneInteractController>.Instance);
		if (!ControllerBase<CombatMessageController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.CombatMessage.CombatMessageController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CombatMessageController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<CombatMessageController>.Instance);
		if (!ControllerBase<CiacconaGalController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.CiacconaGal.CiacconaGalController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CiacconaGalController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<CiacconaGalController>.Instance);
		if (!ControllerBase<ChatController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ChatController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ChatController>.Instance);
		if (!ControllerBase<ChannelController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ChannelController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ChannelController>.Instance);
		if (!ControllerBase<CdKeyInputController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CdKeyInputController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CdKeyInputController>.Instance);
		if (!ControllerBase<CalabashController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CalabashController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CalabashController>.Instance);
		if (!ControllerBase<BuildingGridController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuildingGridController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BuildingGridController>.Instance);
		if (!ControllerBase<BuffItemControl>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuffItemControl 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BuffItemControl>.Instance);
		if (!ControllerBase<ButtonStateController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Common.Button.ButtonStateController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ButtonStateController>.Instance);
		if (!ControllerBase<DreamLinkController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.DreamLink.DreamLinkController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DreamLinkController>.Instance);
		if (!ControllerBase<DrinksController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DrinksController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<DrinksController>.Instance);
		if (!ControllerBase<EditBattleTeamController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EditBattleTeamController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<EditBattleTeamController>.Instance);
		if (!ControllerBase<HelpController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HelpController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HelpController>.Instance);
		if (!ControllerBase<HandBookController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HandBookController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<HandBookController>.Instance);
		if (!ControllerBase<GuideController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GuideController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GuideController>.Instance);
		if (!ControllerBase<GreatSwordController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GreatSwordController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GreatSwordController>.Instance);
		if (!ControllerBase<GenericPromptController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.GenericPrompt.GenericPromptController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GenericPromptController>.Instance);
		if (!ControllerBase<GeneralLogicTreeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GeneralLogicTreeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GeneralLogicTreeController>.Instance);
		if (!ControllerBase<GamePingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GamePingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GamePingController>.Instance);
		if (!ControllerBase<GamepadController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Gamepad.GamepadController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GamepadController>.Instance);
		if (!ControllerBase<GameBudgetController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GameBudgetController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GameBudgetController>.Instance);
		if (!ControllerBase<GachaController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GachaController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GachaController>.Instance);
		if (!ControllerBase<GachaAccumulateController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GachaAccumulateController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GachaAccumulateController>.Instance);
		if (!ControllerBase<FunctionController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Functional.FunctionController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FunctionController>.Instance);
		if (!ControllerBase<FullScreenEffectController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FullScreenEffectController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FullScreenEffectController>.Instance);
		if (!ControllerBase<FriendController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FriendController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FriendController>.Instance);
		if (!ControllerBase<FreezeOnSightController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FreezeOnSightController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FreezeOnSightController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<FreezeOnSightController>.Instance);
		if (!ControllerBase<FragmentMemoryController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FragmentMemoryController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FragmentMemoryController>.Instance);
		if (!ControllerBase<FragmentMemoryActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FragmentMemoryActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FragmentMemoryActivityController>.Instance);
		if (!ControllerBase<FloroRanchController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FloroRanchController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FloroRanchController>.Instance);
		if (!ControllerBase<FlagChallengeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.FlagChallenge.FlagChallengeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FlagChallengeController>.Instance);
		if (!ControllerBase<FirstPersonTurretController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.FirstPersonTurret.FirstPersonTurretController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FirstPersonTurretController>.Instance);
		if (!ControllerBase<FeedbackRewardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FeedbackRewardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FeedbackRewardController>.Instance);
		if (!ControllerBase<ExploreProgressController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExploreProgressController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ExploreProgressController>.Instance);
		if (!ControllerBase<ExploreLevelController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExploreLevelController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ExploreLevelController>.Instance);
		if (!ControllerBase<ErrorCodeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ErrorCodeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ErrorCodeController>.Instance);
		if (!ControllerBase<EffectSaveController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.EffectSave.EffectSaveController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<EffectSaveController>.Instance);
		if (!ControllerBase<FormationDragController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FormationDragController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FormationDragController>.Instance);
		if (!ControllerBase<EditFormationController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EditFormationController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<EditFormationController>.Instance);
		if (!ControllerBase<BossPilingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BossPiling.BossPilingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BossPilingController>.Instance);
		if (!ControllerBase<BlackScreenFadeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BlackScreenFadeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BlackScreenFadeController>.Instance);
		if (!ControllerBase<BlackScreenController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BlackScreen.BlackScreenController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BlackScreenController>.Instance);
		if (!ControllerBase<BirthdayController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BirthdayController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BirthdayController>.Instance);
		if (!ControllerBase<ActivityTimePointRewardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityTimePointRewardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityTimePointRewardController>.Instance);
		if (!ControllerBase<TetrisController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Tetris.TetrisController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TetrisController>.Instance);
		if (!ControllerBase<ActivityTetrisController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Tetris.ActivityTetrisController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityTetrisController>.Instance);
		if (!ControllerBase<SpringManorController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.SpringManor.SpringManorController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SpringManorController>.Instance);
		if (!ControllerBase<ActivitySpring25Controller>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivitySpring25Controller 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivitySpring25Controller>.Instance);
		if (!ControllerBase<ActivitySolarSpeedController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed.ActivitySolarSpeedController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivitySolarSpeedController>.Instance);
		if (!ControllerBase<ActivitySoarController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivitySoarController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivitySoarController>.Instance);
		if (!ControllerBase<ActivityShipTowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityShipTowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityShipTowerController>.Instance);
		if (!ControllerBase<ActivitySevenDaySignController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivitySevenDaySignController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivitySevenDaySignController>.Instance);
		if (!ControllerBase<ActivityScratchTicketController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityScratchTicketController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityScratchTicketController>.Instance);
		if (!ControllerBase<ActivityRunController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRunController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRunController>.Instance);
		if (!ControllerBase<RoverlikeController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Roverlike.RoverlikeController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoverlikeController>.Instance);
		if (!ControllerBase<RoverlikeActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Roverlike.RoverlikeActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoverlikeActivityController>.Instance);
		if (!ControllerBase<ActivityRogueController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity.ActivityRogueController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRogueController>.Instance);
		if (!ControllerBase<ActivityRoleTrialController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRoleTrialController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRoleTrialController>.Instance);
		if (!ControllerBase<RoleSkinTrialController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleSkinTrialController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleSkinTrialController>.Instance);
		if (!ControllerBase<ActivityRoleSkinRewardController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinReward.ActivityRoleSkinRewardController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRoleSkinRewardController>.Instance);
		if (!ControllerBase<ActivityRoleGuideController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRoleGuideController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRoleGuideController>.Instance);
		if (!ControllerBase<ActivityRoleGiveController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRoleGiveController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRoleGiveController>.Instance);
		if (!ControllerBase<RoleGiftController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleGiftController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RoleGiftController>.Instance);
		if (!ControllerBase<ActivityRoadBookController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RoadBook.ActivityRoadBookController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRoadBookController>.Instance);
		if (!ControllerBase<RhythmShipController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.RhythmShipController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<RhythmShipController>.Instance);
		if (!ControllerBase<ActivityRegressController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRegressController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRegressController>.Instance);
		if (!ControllerBase<ActivityRealmBetweenController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween.ActivityRealmBetweenController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityRealmBetweenController>.Instance);
		if (!ControllerBase<ActivityPrizeDrawingController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityPrizeDrawingController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityPrizeDrawingController>.Instance);
		if (!ControllerBase<ActivityPreWarmController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.PreWarm.ActivityPreWarmController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityPreWarmController>.Instance);
		if (!ControllerBase<PinballController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Pinball.PinballController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<PinballController>.Instance);
		if (!ControllerBase<TotalTopUpController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp.TotalTopUpController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<TotalTopUpController>.Instance);
		if (!ControllerBase<ActivityNoviceJourneyController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNoviceJourneyController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityNoviceJourneyController>.Instance);
		if (!ControllerBase<ActivityTowerGuideController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityTowerGuideController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityTowerGuideController>.Instance);
		if (!ControllerBase<ActivityTurntableController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityTurntableController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityTurntableController>.Instance);
		if (!ControllerBase<SkillCdController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.SkillCdController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<SkillCdController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<SkillCdController>.Instance);
		if (!ControllerBase<BattleScoreController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.BattleScoreController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleScoreController>.Instance);
		if (!ControllerBase<MoraleBattleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.MoraleBattleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<MoraleBattleController>.Instance);
		if (!ControllerBase<BattleLinkController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.BattleLinkController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleLinkController>.Instance);
		if (!ControllerBase<FlagChallengeBattleController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.FlagChallengeBattleController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<FlagChallengeBattleController>.Instance);
		if (!ControllerBase<CooperationController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CooperationController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<CooperationController>.Instance);
		if (!ControllerBase<BattleViewDynamicUIController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUi.BattleViewDynamicUI.BattleViewDynamicUIController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleViewDynamicUIController>.Instance);
		if (!ControllerBase<BattleUiDataControl>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUi.BattleUiDataControl 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleUiDataControl>.Instance);
		if (!ControllerBase<BattleUiControl>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUi.BattleUiControl 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleUiControl>.Instance);
		if (!ControllerBase<BattleUiSetController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUiSet.BattleUiSetController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<BattleUiSetController>.Instance);
		if (!ControllerBase<AutoPilotController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.AutoPilot.AutoPilotController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AutoPilotController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<AutoPilotController>.Instance);
		if (!ControllerBase<WeaponEnvInteractionAudioController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "Kuro.Game.Module.Audio.WeaponEnvInteractionAudioController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WeaponEnvInteractionAudioController>.Instance);
		if (!ControllerBase<GameAudioController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Audio.GameAudioController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<GameAudioController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<GameAudioController>.Instance);
		if (!ControllerBase<AreaController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Area.AreaController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AreaController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<AreaController>.Instance);
		if (!ControllerBase<AppLinksController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AppLinksController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AppLinksController>.Instance);
		if (!ControllerBase<ApplicationController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Application.ApplicationController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ApplicationController>.Instance);
		if (!ControllerBase<AntiCheatController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AntiCheatController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AntiCheatController>.Instance);
		if (!ControllerBase<AnimController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AnimController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AnimController>.Instance);
		ControllerRegister.TickControllers.Add(ControllerBase<AnimController>.Instance);
		if (!ControllerBase<AndroidBackController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AndroidBackController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AndroidBackController>.Instance);
		if (!ControllerBase<AdviceController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdviceController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AdviceController>.Instance);
		if (!ControllerBase<AdventureGuideController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdventureGuideController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<AdventureGuideController>.Instance);
		if (!ControllerBase<ActorFxEmoteController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ActorFxEmote.ActorFxEmoteController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActorFxEmoteController>.Instance);
		if (!ControllerBase<ActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityController>.Instance);
		if (!ControllerBase<WuWuLogisticsActivityController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WuWuLogisticsActivityController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WuWuLogisticsActivityController>.Instance);
		if (!ControllerBase<WheelTowerController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WheelTowerController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<WheelTowerController>.Instance);
		if (!ControllerBase<ActivityVersionPreheatController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityVersionPreheatController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityVersionPreheatController>.Instance);
		if (!ControllerBase<ActivityUniversalController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity.ActivityUniversalController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityUniversalController>.Instance);
		if (!ControllerBase<ActivityTrapDefenseController>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityTrapDefenseController 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ActivityTrapDefenseController>.Instance);
		if (!ControllerBase<ModelAndControllerTest.ControllerTest>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ModelAndControllerTest.ControllerTest 创建控制器单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ControllerRegister.Controllers.Add(ControllerBase<ModelAndControllerTest.ControllerTest>.Instance);
		return true;
	}

	// Token: 0x0601CACC RID: 117452 RVA: 0x008AF098 File Offset: 0x008AD298
	public static bool RegisterTick()
	{
		for (int i = 0; i < ControllerRegister.TickControllers.Count; i++)
		{
			if (ControllerRegister.TickControllers[i] == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.LRX, "TickController 注册控制器Tick失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		if (!Stat.Enable)
		{
			return true;
		}
		for (int j = 0; j < ControllerRegister.TickControllers.Count; j++)
		{
			IControllerBase controllerBase = ControllerRegister.TickControllers[j];
			controllerBase.SetPerformanceStateObject(controllerBase.GetType().Name, "", "");
		}
		return true;
	}

	// Token: 0x0601CACD RID: 117453 RVA: 0x008AF12C File Offset: 0x008AD32C
	public static bool Init()
	{
		for (int i = 0; i < ControllerRegister.Controllers.Count; i++)
		{
			IControllerBase controllerBase = ControllerRegister.Controllers[i];
			if (!controllerBase.Init())
			{
				Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, controllerBase.GetType().FullName + " 控制器初始化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601CACE RID: 117454 RVA: 0x008AF194 File Offset: 0x008AD394
	public static bool Clear()
	{
		bool result = true;
		for (int i = 0; i < ControllerRegister.Controllers.Count; i++)
		{
			IControllerBase controllerBase = ControllerRegister.Controllers[i];
			try
			{
				if (!controllerBase.Clear())
				{
					Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, controllerBase.GetType().FullName + " 控制器清理失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = false;
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = controllerBase.GetType().FullName + " 控制器清理失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
		}
		return result;
	}

	// Token: 0x0601CACF RID: 117455 RVA: 0x008AF258 File Offset: 0x008AD458
	public static bool LeaveLevel()
	{
		bool result = true;
		for (int i = 0; i < ControllerRegister.Controllers.Count; i++)
		{
			IControllerBase controllerBase = ControllerRegister.Controllers[i];
			try
			{
				if (!controllerBase.LeaveLevel())
				{
					Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, controllerBase.GetType().FullName + " 控制器退出关卡失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = false;
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = controllerBase.GetType().FullName + " 控制器退出关卡失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
		}
		return result;
	}

	// Token: 0x0601CAD0 RID: 117456 RVA: 0x008AF31C File Offset: 0x008AD51C
	public static bool ChangeMode()
	{
		bool result = true;
		for (int i = 0; i < ControllerRegister.Controllers.Count; i++)
		{
			IControllerBase controllerBase = ControllerRegister.Controllers[i];
			try
			{
				if (!controllerBase.ChangeMode())
				{
					Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, controllerBase.GetType().FullName + " 控制器退出模式失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = false;
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = controllerBase.GetType().FullName + " 控制器退出模式失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
		}
		return result;
	}

	// Token: 0x0601CAD1 RID: 117457 RVA: 0x008AF3E0 File Offset: 0x008AD5E0
	public static List<ValueTuple<string, CustomPromise<bool>>> Preload()
	{
		List<ValueTuple<string, CustomPromise<bool>>> list = new List<ValueTuple<string, CustomPromise<bool>>>();
		ValueTuple<string, CustomPromise<bool>>? valueTuple = null;
		for (int i = 0; i < ControllerRegister.Controllers.Count; i++)
		{
			valueTuple = ControllerRegister.Controllers[i].Preload();
			if (valueTuple != null)
			{
				list.Add(valueTuple.Value);
			}
		}
		return list;
	}

	// Token: 0x0601CAD2 RID: 117458 RVA: 0x008AF438 File Offset: 0x008AD638
	public static void Tick(float delta, bool isInFight)
	{
		foreach (IControllerBase controllerBase in ControllerRegister.TickControllers)
		{
			if (controllerBase.CheckTick(isInFight, delta) && (!Singleton<TickSystem>.Instance.IsPaused || controllerBase.IsTickEvenPaused))
			{
				controllerBase.GetPerformanceStateObject();
				controllerBase.Tick(delta);
			}
		}
	}

	// Token: 0x0601CAD3 RID: 117459 RVA: 0x008AF4B0 File Offset: 0x008AD6B0
	public static void ClearTick()
	{
		ControllerRegister.TickControllers.Clear();
	}

	// Token: 0x0400E81A RID: 59418
	[StaticVariableRuleIgnore]
	private static List<IControllerBase> Controllers = new List<IControllerBase>(490);

	// Token: 0x0400E81B RID: 59419
	[StaticVariableRuleIgnore]
	private static List<IControllerBase> TickControllers = new List<IControllerBase>(83);
}
