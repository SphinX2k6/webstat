using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity;
using CSharpScript.Game.Module.Activity.ActivityContent.Anniversary;
using CSharpScript.Game.Module.Activity.ActivityContent.CommonH5;
using CSharpScript.Game.Module.Activity.ActivityContent.Coop;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch;
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
using CSharpScript.Game.Module.BossPiling;
using CSharpScript.Game.Module.DreamLink;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.VillageInfr;

// Token: 0x0200172D RID: 5933
public class ActivityManager : IStaticVariableResetter
{
	// Token: 0x0600A53E RID: 42302 RVA: 0x002BA0E5 File Offset: 0x002B82E5
	static ActivityManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityManager.CreateStaticDefaultValue), new Action(ActivityManager.ResetStaticDefaultValue));
	}

	// Token: 0x0600A53F RID: 42303 RVA: 0x002BA104 File Offset: 0x002B8304
	public static void CreateStaticDefaultValue()
	{
		ActivityManager.ActivityControllerInstance = new Dictionary<ActivityType, IActivityControllerBase>();
	}

	// Token: 0x0600A540 RID: 42304 RVA: 0x002BA110 File Offset: 0x002B8310
	public static void ResetStaticDefaultValue()
	{
		ActivityManager.ActivityControllerInstance = null;
	}

	// Token: 0x0600A541 RID: 42305 RVA: 0x002BA118 File Offset: 0x002B8318
	public static void Init()
	{
		ActivityManager.InitActivityController();
		foreach (object obj in Enum.GetValues(typeof(ActivityType)))
		{
			ActivityType activityType = (ActivityType)obj;
			IActivityControllerBase activityControllerBase;
			if (!ActivityManager.ActivityControllerInstance.TryGetValue(activityType, out activityControllerBase))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.YZY;
				string message = "没有注册活动类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", activityType);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x0600A542 RID: 42306 RVA: 0x002BA1B8 File Offset: 0x002B83B8
	private static void InitActivityController()
	{
		ActivityManager.ActivityControllerInstance[ActivityType.Parkour] = ControllerBase<ActivityRunController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.GatherActivity] = ControllerBase<ActivityCollectionController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Sign] = ControllerBase<ActivitySevenDaySignController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewBieCourse] = ControllerBase<ActivityNoviceJourneyController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewbieCourseV2] = ControllerBase<ActivityNewbieCourseV2Controller>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PureUiactivity] = ControllerBase<ActivityUniversalController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TowerGuide] = ControllerBase<ActivityTowerGuideController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.WorldNewJourney] = ControllerBase<ActivityBeginnerBookController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RougeActivity] = ControllerBase<ActivityRogueController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RoleTrialActivity] = ControllerBase<ActivityRoleTrialController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Harvest] = ControllerBase<ActivityMowingController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.DoubleInstanceRewardActivity] = ControllerBase<ActivityDoubleRewardController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewRoleGuideActivity] = ControllerBase<ActivityRoleGuideController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PhantomCollect] = ControllerBase<ActivityPhantomCollectController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.DailyAdventureActivity] = ControllerBase<ActivityDailyAdventureController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.LongShanMainActivity] = ControllerBase<ActivityLongShanController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.BossRushActivity] = ControllerBase<BossRushController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TurnTableActivity] = ControllerBase<ActivityTurntableController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TimePointRewardActivity] = ControllerBase<ActivityTimePointRewardController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PhotoMemoryActivity] = ControllerBase<FragmentMemoryActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TowerDefenceActivity] = ControllerBase<TowerDefenseController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TrackMoonActivity] = ControllerBase<ActivityMoonChasingController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TowerGuideNew] = ControllerBase<ActivityLoopTowerController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.SlashAndTowerLevelPlay] = ControllerBase<ActivityShipTowerController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.DangoMonopoly] = ControllerBase<ActivityDangoMonopolyController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MoraleActivity] = ControllerBase<ActivityMoraleController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Explore] = ControllerBase<ActivityMapExploreController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RegressActivity] = ControllerBase<ActivityRegressController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TrackMoonPhase] = ControllerBase<ActivityRoleGiveController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.CorniceMeeting] = ControllerBase<ActivityCorniceMeetingController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RiskHarvest] = ControllerBase<ActivityMowingRiskController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.BlackCoastTheme] = ControllerBase<ActivityBlackCoastController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RogueWhiteCat] = ControllerBase<DreamLinkController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.ArtemisActivity] = ControllerBase<ArtemisActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.DropCatchActivity] = ControllerBase<DropCatchActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.ScratchCard] = ControllerBase<ActivityScratchTicketController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PreheatSign] = ControllerBase<ActivityVersionPreheatController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MowTower] = ControllerBase<MowingTowerController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.ThroughTrain] = ControllerBase<ActivityDirectTrainController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.ThroughTrainSummary] = ControllerBase<DirectTrainActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MapTravelActivity] = ControllerBase<ActivityMapTravelController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.FarmGold] = ControllerBase<FarmGoldController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.SprintSign] = ControllerBase<ActivitySpring25Controller>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewLordGym] = ControllerBase<ActivityLordGymController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RoleSkinTrialActivity] = ControllerBase<RoleSkinTrialController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RogueWeekly] = ControllerBase<WeeklyRogueController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.FishingActivity] = ControllerBase<ActivityFishingController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TeamParkOurActivity] = ControllerBase<ActivitySolarSpeedController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.BabelTower] = ControllerBase<BabelTowerController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.BetHorses] = ControllerBase<RacingBetsController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.FloroRanchActivity] = ControllerBase<FloroRanchController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RogueRes] = ControllerBase<ActivityPermanentRogueController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewbieCarnival] = ControllerBase<BeginnerCarnivalController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.SkinRewardActivity] = ControllerBase<ActivityRoleSkinRewardController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.AnniversaryTheme] = ControllerBase<AnniversaryActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Abyss] = ControllerBase<DangoAbyssActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Avignon] = ControllerBase<AvignonController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.CiacconaActivity] = ControllerBase<CiacconaActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.H5CircumFluence] = ControllerBase<ActivityInviteNewbieController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.ActivityLinkage] = ControllerBase<ActivityLinkageController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.LinkageCheckIn] = ControllerBase<LinkageRewardActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.ConsumptiveActivity] = ControllerBase<CumulativeShopController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PhantomBattle] = ControllerBase<PhantomArenaController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.HonamiStory] = ControllerBase<HonamiStoryController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.LifePointChallenge] = ControllerBase<LifePointDrawActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TrapDefense] = ControllerBase<ActivityTrapDefenseController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.FunPlay] = ControllerBase<ActivityFunPlayController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.JinzhouFlyActivity] = ControllerBase<ActivitySoarController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.LineCross] = ControllerBase<LineCrossActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Survivors] = ControllerBase<SurvivorsActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MoonPhase] = ControllerBase<MoonSignInController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PhotoFight] = ControllerBase<FightPhotoController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Encircle] = ControllerBase<ActivityEncircleController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.WuWuKuji] = ControllerBase<ActivityPrizeDrawingController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.InfrTheme] = ControllerBase<InfrastructureController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.InfrThemeV2] = ControllerBase<VillageInfrController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PreHeatTaskActivity] = ControllerBase<ActivityPreWarmController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.CoopActivity] = ControllerBase<CoopActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.AdvanceNoticeActivity] = ControllerBase<AdvanceNoticeController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MotorcycleIpLink] = ControllerBase<ActivityMotorLinkageController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PhantomBattleRecord] = ControllerBase<PhantomArenaController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RoadBookActivity] = ControllerBase<ActivityRoadBookController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RealmBetween] = ControllerBase<ActivityRealmBetweenController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PhantomBattleRecordGuide] = ControllerBase<PhantomArenaGuideController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TetrisActivity] = ControllerBase<ActivityTetrisController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewTowerClimbing] = ControllerBase<WheelTowerController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MotorParkourActivity] = ControllerBase<MotorParkourController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.H5View] = ControllerBase<CommonH5Controller>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.SpringFestivalActivity] = ControllerBase<SpringManorController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewPlayerSupportActivity] = ControllerBase<ActivityNewPlayerSupportController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PurePreviewActivity] = ControllerBase<ActivityMotorGiftController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewPlayerSupportActivityV2] = ControllerBase<ActivityNewPlayerSupportActivityV2Controller>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MotorFight] = ControllerBase<MotorFightController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.TotalTopUp] = ControllerBase<TotalTopUpController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RoleGiftActivity] = ControllerBase<RoleGiftController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.WuWuWeekSign] = ControllerBase<WuWuLogisticsActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MotorDecalActivity] = ControllerBase<MotorDecalLinkController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.FlagChallenge] = ControllerBase<ActivityFlagChallengeController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MotorDevelop] = ControllerBase<ActivityMotorDevelopController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.FeiXue] = ControllerBase<ActivityFeiXuePreheatController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Rhythm] = ControllerBase<RhythmShipController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.BossPiling] = ControllerBase<BossPilingController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.GolemCrackActivity] = ControllerBase<GolemHackingController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.EdgeRunnerActivity] = ControllerBase<CyberPunkController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.MotorParkour] = ControllerBase<MultiMotorController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.PinballActivity] = ControllerBase<PinballController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.Kurotato] = ControllerBase<KurotatoActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.SheriffActivity] = ControllerBase<SheriffController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewbieMain] = ControllerBase<NewbieMainController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.NewbieAdventureV2] = ControllerBase<ActivityNewcomerJourneyController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.QingXiaoPlayThePiano] = ControllerBase<GuQinActivityController>.Instance;
		ActivityManager.ActivityControllerInstance[ActivityType.RoverRogue] = ControllerBase<RoverlikeActivityController>.Instance;
	}

	// Token: 0x0600A543 RID: 42307 RVA: 0x002BA930 File Offset: 0x002B8B30
	[NullableContext(1)]
	public static IActivityControllerBase GetActivityController(ActivityType type)
	{
		IActivityControllerBase result;
		if (ActivityManager.ActivityControllerInstance.TryGetValue(type, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600A544 RID: 42308 RVA: 0x002BA94F File Offset: 0x002B8B4F
	[NullableContext(2)]
	public static IActivityControllerBase GetActivityController(int type)
	{
		return ActivityManager.ActivityControllerInstance.GetValueOrDefault((ActivityType)type);
	}

	// Token: 0x0600A545 RID: 42309 RVA: 0x002BA95C File Offset: 0x002B8B5C
	public static void Clear()
	{
		ActivityManager.ActivityControllerInstance.Clear();
	}

	// Token: 0x04004E75 RID: 20085
	[Nullable(1)]
	private static Dictionary<ActivityType, IActivityControllerBase> ActivityControllerInstance;
}
