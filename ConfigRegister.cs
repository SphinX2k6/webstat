using System;
using System.Collections.Generic;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.LevelGamePlay.LevelConditions.Config;
using CSharpScript.Game.LevelGamePlay.TuningStand;
using CSharpScript.Game.Module.Activity;
using CSharpScript.Game.Module.Activity.ActivityContent.Anniversary;
using CSharpScript.Game.Module.Activity.ActivityContent.Coop;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch;
using CSharpScript.Game.Module.Activity.ActivityContent.Encircle;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Activity.ActivityContent.FunPlay;
using CSharpScript.Game.Module.Activity.ActivityContent.LineCross;
using CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn;
using CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop;
using CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorFight;
using CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour;
using CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor;
using CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain;
using CSharpScript.Game.Module.Activity.ActivityContent.PreWarm;
using CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween;
using CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip;
using CSharpScript.Game.Module.Activity.ActivityContent.RoadBook;
using CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinReward;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.Activity.ActivityContent.Tetris;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUiSet;
using CSharpScript.Game.Module.BossPiling;
using CSharpScript.Game.Module.Comic;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Cook;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.DreamLink;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Infrastructure;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Item.Data;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.JoinTeam;
using CSharpScript.Game.Module.Kurotato;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Manufacture.Forging;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.MingSu;
using CSharpScript.Game.Module.Morale;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.PhantomArena;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.QuestMultiLine;
using CSharpScript.Game.Module.RecallQuest;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Sheriff;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.UiCameraAnimation;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Module.VillageInfr;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal;
using CSharpScript.Game.NewWorld.SceneItem.Manipulate;
using CSharpScript.Game.Ui;
using CSharpScript.Game.World.Define;

// Token: 0x0200350D RID: 13581
public class ConfigRegister
{
	// Token: 0x0601CABF RID: 117439 RVA: 0x008A0464 File Offset: 0x0089E664
	public static bool CreateInstance()
	{
		ConfigRegister.Configs.Clear();
		if (!ConfigBase<AiConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AiConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AiConfig>.Instance);
		if (!ConfigBase<MailConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MailConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MailConfig>.Instance);
		if (!ConfigBase<ComposeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Manufacture.Compose.ComposeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ComposeConfig>.Instance);
		if (!ConfigBase<ForgingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Manufacture.Forging.ForgingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ForgingConfig>.Instance);
		if (!ConfigBase<MapRogueConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MapRogue.MapRogueConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MapRogueConfig>.Instance);
		if (!ConfigBase<MapConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Map.MapConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MapConfig>.Instance);
		if (!ConfigBase<MenuBaseConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MenuBaseConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MenuBaseConfig>.Instance);
		if (!ConfigBase<CollectItemConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.MingSu.CollectItemConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CollectItemConfig>.Instance);
		if (!ConfigBase<MonsterInfoConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MonsterInfoConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MonsterInfoConfig>.Instance);
		if (!ConfigBase<MoraleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Morale.MoraleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MoraleConfig>.Instance);
		if (!ConfigBase<MotionConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotionConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotionConfig>.Instance);
		if (!ConfigBase<MotorConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotorConfig>.Instance);
		if (!ConfigBase<MotorDiyConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorDiyConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotorDiyConfig>.Instance);
		if (!ConfigBase<MotorcycleMusicPlayerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleMusicPlayerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotorcycleMusicPlayerConfig>.Instance);
		if (!ConfigBase<NpcIconConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "NpcIconConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<NpcIconConfig>.Instance);
		if (!ConfigBase<PayItemConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayItemConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PayItemConfig>.Instance);
		if (!ConfigBase<BattlePassConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BattlePassConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BattlePassConfig>.Instance);
		if (!ConfigBase<MonthCardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MonthCardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MonthCardConfig>.Instance);
		if (!ConfigBase<PayShopConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PayShopConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PayShopConfig>.Instance);
		if (!ConfigBase<GiftPackageConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GiftPackageConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GiftPackageConfig>.Instance);
		if (!ConfigBase<WeekCardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeekCardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WeekCardConfig>.Instance);
		if (!ConfigBase<PersonalConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Personal.PersonalConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PersonalConfig>.Instance);
		if (!ConfigBase<PhantomArenaConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PhantomArena.PhantomArenaConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PhantomArenaConfig>.Instance);
		if (!ConfigBase<PhantomBattleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhantomBattleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PhantomBattleConfig>.Instance);
		if (!ConfigBase<VisionRecommendConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VisionRecommendConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<VisionRecommendConfig>.Instance);
		if (!ConfigBase<PhoneMsgConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.PhoneMessage.PhoneMsgConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PhoneMsgConfig>.Instance);
		if (!ConfigBase<PhonographConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhonographConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PhonographConfig>.Instance);
		if (!ConfigBase<PhotographConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PhotographConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PhotographConfig>.Instance);
		if (!ConfigBase<PlatformConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PlatformConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PlatformConfig>.Instance);
		if (!ConfigBase<PlayerInfoConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PlayerInfoConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PlayerInfoConfig>.Instance);
		if (!ConfigBase<LordGymConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LordGymConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LordGymConfig>.Instance);
		if (!ConfigBase<LogReportConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LogReportConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LogReportConfig>.Instance);
		if (!ConfigBase<LoginConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoginConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LoginConfig>.Instance);
		if (!ConfigBase<LoadingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LoadingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LoadingConfig>.Instance);
		if (!ConfigBase<FriendConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FriendConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FriendConfig>.Instance);
		if (!ConfigBase<FunctionConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FunctionConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FunctionConfig>.Instance);
		if (!ConfigBase<GachaAccumulateConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GachaAccumulateConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GachaAccumulateConfig>.Instance);
		if (!ConfigBase<GachaConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GachaConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GachaConfig>.Instance);
		if (!ConfigBase<GamepadConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GamepadConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GamepadConfig>.Instance);
		if (!ConfigBase<GenericPromptConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.GenericPrompt.GenericPromptConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GenericPromptConfig>.Instance);
		if (!ConfigBase<GuideConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GuideConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GuideConfig>.Instance);
		if (!ConfigBase<HandBookConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HandBookConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<HandBookConfig>.Instance);
		if (!ConfigBase<HelpConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HelpConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<HelpConfig>.Instance);
		if (!ConfigBase<HonamiStoryConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "HonamiStoryConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<HonamiStoryConfig>.Instance);
		if (!ConfigBase<InfluenceConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InfluenceConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InfluenceConfig>.Instance);
		if (!ConfigBase<InfoDisplayModuleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InfoDisplayModuleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InfoDisplayModuleConfig>.Instance);
		if (!ConfigBase<InfrastructureConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Infrastructure.InfrastructureConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InfrastructureConfig>.Instance);
		if (!ConfigBase<InstanceDungeonConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "InstanceDungeonConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InstanceDungeonConfig>.Instance);
		if (!ConfigBase<FlowConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.Flow.FlowConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FlowConfig>.Instance);
		if (!ConfigBase<InstanceDungeonEntranceConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonEntranceConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InstanceDungeonEntranceConfig>.Instance);
		if (!ConfigBase<InventoryConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Inventory.InventoryConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InventoryConfig>.Instance);
		if (!ConfigBase<ItemExchangeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ItemExchangeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ItemExchangeConfig>.Instance);
		if (!ConfigBase<ItemRewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.ItemReward.ItemRewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ItemRewardConfig>.Instance);
		if (!ConfigBase<GetWayConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GetWayConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GetWayConfig>.Instance);
		if (!ConfigBase<ItemAccessedFromGiftPathConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Item.Data.ItemAccessedFromGiftPathConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ItemAccessedFromGiftPathConfig>.Instance);
		if (!ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Item.ItemConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance);
		if (!ConfigBase<SpecialItemConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SpecialItemConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SpecialItemConfig>.Instance);
		if (!ConfigBase<JoinTeamConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.JoinTeam.JoinTeamConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<JoinTeamConfig>.Instance);
		if (!ConfigBase<KingShipConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "KingShipConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<KingShipConfig>.Instance);
		if (!ConfigBase<KurotatoConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Kurotato.KurotatoConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<KurotatoConfig>.Instance);
		if (!ConfigBase<LanguageConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LanguageConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LanguageConfig>.Instance);
		if (!ConfigBase<LevelPlayReportConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelPlayReportConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LevelPlayReportConfig>.Instance);
		if (!ConfigBase<LevelPlayConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelPlayConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LevelPlayConfig>.Instance);
		if (!ConfigBase<LevelUpConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LevelUpConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LevelUpConfig>.Instance);
		if (!ConfigBase<InteractionConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Interaction.InteractionConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InteractionConfig>.Instance);
		if (!ConfigBase<MusicSubtitleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.MusicSubtitleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MusicSubtitleConfig>.Instance);
		if (!ConfigBase<PlotCameraTemplateConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotCameraTemplateConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PlotCameraTemplateConfig>.Instance);
		if (!ConfigBase<PlotMontageConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotMontageConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PlotMontageConfig>.Instance);
		if (!ConfigBase<UiCameraAnimationConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.UiCameraAnimation.UiCameraAnimationConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<UiCameraAnimationConfig>.Instance);
		if (!ConfigBase<UiNavigationConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.UiNavigation.UiNavigationConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<UiNavigationConfig>.Instance);
		if (!ConfigBase<VideoConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "VideoConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<VideoConfig>.Instance);
		if (!ConfigBase<VillageInfrConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.VillageInfr.VillageInfrConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<VillageInfrConfig>.Instance);
		if (!ConfigBase<WeaponConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeaponConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WeaponConfig>.Instance);
		if (!ConfigBase<WeatherModuleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Weather.WeatherModuleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WeatherModuleConfig>.Instance);
		if (!ConfigBase<WeeklyChallengeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeeklyChallengeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WeeklyChallengeConfig>.Instance);
		if (!ConfigBase<WeeklyRogueConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeeklyRogueConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WeeklyRogueConfig>.Instance);
		if (!ConfigBase<WorldLevelConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WorldLevelConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WorldLevelConfig>.Instance);
		if (!ConfigBase<RegionalTerminalConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WorldMap.RegionalTerminal.RegionalTerminalConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RegionalTerminalConfig>.Instance);
		if (!ConfigBase<WorldMapConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.WorldMap.WorldMapConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WorldMapConfig>.Instance);
		if (!ConfigBase<BulletConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BulletConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BulletConfig>.Instance);
		if (!ConfigBase<EntityAkComponentConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EntityAkComponentConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<EntityAkComponentConfig>.Instance);
		if (!ConfigBase<EntityPhysicsAssetConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EntityPhysicsAssetConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<EntityPhysicsAssetConfig>.Instance);
		if (!ConfigBase<TutorialConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TutorialConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TutorialConfig>.Instance);
		if (!ConfigBase<SwimConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SwimConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SwimConfig>.Instance);
		if (!ConfigBase<FaceExpressionConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FaceExpressionConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FaceExpressionConfig>.Instance);
		if (!ConfigBase<ManipulateConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.NewWorld.SceneItem.Manipulate.ManipulateConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ManipulateConfig>.Instance);
		if (!ConfigBase<WorldConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WorldConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WorldConfig>.Instance);
		if (!ConfigBase<RedDotConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RedDotConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RedDotConfig>.Instance);
		if (!ConfigBase<RenderModuleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RenderModuleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RenderModuleConfig>.Instance);
		if (!ConfigBase<UiCommonConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.UiCommonConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<UiCommonConfig>.Instance);
		if (!ConfigBase<InputDistributeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.InputDistributeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InputDistributeConfig>.Instance);
		if (!ConfigBase<ImmersiveMouseConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.ImmersiveMouseConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ImmersiveMouseConfig>.Instance);
		if (!ConfigBase<ViewHotKeyConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Ui.ViewHotKeyConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ViewHotKeyConfig>.Instance);
		if (!ConfigBase<AiBehaviorTreeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AiBehaviorTreeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AiBehaviorTreeConfig>.Instance);
		if (!ConfigBase<AnimalStandbyMontageConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.World.Define.AnimalStandbyMontageConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AnimalStandbyMontageConfig>.Instance);
		if (!ConfigBase<AnsPerformConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AnsPerformConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AnsPerformConfig>.Instance);
		if (!ConfigBase<BubbleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BubbleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BubbleConfig>.Instance);
		if (!ConfigBase<CommonBtConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CommonBtConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CommonBtConfig>.Instance);
		if (!ConfigBase<WeaponComponentConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WeaponComponentConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WeaponComponentConfig>.Instance);
		if (!ConfigBase<FragmentMemoryConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FragmentMemoryConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FragmentMemoryConfig>.Instance);
		if (!ConfigBase<TrapDefenseConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TrapDefenseConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TrapDefenseConfig>.Instance);
		if (!ConfigBase<TowerClimbConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TowerClimbConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TowerClimbConfig>.Instance);
		if (!ConfigBase<PlotTemplate>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Plot.PlotTemplate 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PlotTemplate>.Instance);
		if (!ConfigBase<PowerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PowerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PowerConfig>.Instance);
		if (!ConfigBase<QuestMultiLineConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<QuestMultiLineConfig>.Instance);
		if (!ConfigBase<QuestNewConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestNewConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<QuestNewConfig>.Instance);
		if (!ConfigBase<QuestTreeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "QuestTreeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<QuestTreeConfig>.Instance);
		if (!ConfigBase<RacingBetsConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RacingBetsConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RacingBetsConfig>.Instance);
		if (!ConfigBase<RecallQuestConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RecallQuest.RecallQuestConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RecallQuestConfig>.Instance);
		if (!ConfigBase<RewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Reward.RewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RewardConfig>.Instance);
		if (!ConfigBase<RogueBattleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RogueBattle.RogueBattleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RogueBattleConfig>.Instance);
		if (!ConfigBase<RoguelikeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoguelikeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoguelikeConfig>.Instance);
		if (!ConfigBase<RoleDevConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleDevConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoleDevConfig>.Instance);
		if (!ConfigBase<RoleFavorConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleFavorConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoleFavorConfig>.Instance);
		if (!ConfigBase<RoleSkillConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleSkillConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoleSkillConfig>.Instance);
		if (!ConfigBase<RoleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RoleUi.RoleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoleConfig>.Instance);
		if (!ConfigBase<TowerDayConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TowerDayConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TowerDayConfig>.Instance);
		if (!ConfigBase<RoleResonanceConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleResonanceConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoleResonanceConfig>.Instance);
		if (!ConfigBase<UiRoleCameraConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiRoleCameraConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<UiRoleCameraConfig>.Instance);
		if (!ConfigBase<RouletteConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RouletteConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RouletteConfig>.Instance);
		if (!ConfigBase<SheriffConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Sheriff.SheriffConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SheriffConfig>.Instance);
		if (!ConfigBase<ShipTowerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShipTowerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ShipTowerConfig>.Instance);
		if (!ConfigBase<ShopConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ShopConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ShopConfig>.Instance);
		if (!ConfigBase<MoonTogetherConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonTogetherConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MoonTogetherConfig>.Instance);
		if (!ConfigBase<SignalDecodeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SignalDecodeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SignalDecodeConfig>.Instance);
		if (!ConfigBase<SkeletalObserverConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SkeletalObserverConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SkeletalObserverConfig>.Instance);
		if (!ConfigBase<SkillButtonConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SkillButtonUi.SkillButtonConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SkillButtonConfig>.Instance);
		if (!ConfigBase<SkinConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Skin.SkinConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SkinConfig>.Instance);
		if (!ConfigBase<SkipInterfaceConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.SkipInterface.SkipInterfaceConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SkipInterfaceConfig>.Instance);
		if (!ConfigBase<SubPackageConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SubPackageConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SubPackageConfig>.Instance);
		if (!ConfigBase<SurvivorsRogueConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SurvivorsRogueConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SurvivorsRogueConfig>.Instance);
		if (!ConfigBase<TimeOfDayConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TimeOfDayConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TimeOfDayConfig>.Instance);
		if (!ConfigBase<TrialRoleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.RoleUi.TrialRoleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TrialRoleConfig>.Instance);
		if (!ConfigBase<EntityOwnerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EntityOwnerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<EntityOwnerConfig>.Instance);
		if (!ConfigBase<FloroRanchConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FloroRanchConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FloroRanchConfig>.Instance);
		if (!ConfigBase<FeedbackRewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FeedbackRewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FeedbackRewardConfig>.Instance);
		if (!ConfigBase<DropCatchConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.DropCatchConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DropCatchConfig>.Instance);
		if (!ConfigBase<ActivityEncircleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Encircle.ActivityEncircleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityEncircleConfig>.Instance);
		if (!ConfigBase<FarmGoldConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FarmGoldConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FarmGoldConfig>.Instance);
		if (!ConfigBase<FishingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Fishing.FishingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FishingConfig>.Instance);
		if (!ConfigBase<ActivityFunPlayConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.FunPlay.ActivityFunPlayConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityFunPlayConfig>.Instance);
		if (!ConfigBase<GuQinActivityConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.GuQinActivityConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GuQinActivityConfig>.Instance);
		if (!ConfigBase<LifePointDrawConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "LifePointDrawConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LifePointDrawConfig>.Instance);
		if (!ConfigBase<LineCrossConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.LineCross.LineCrossConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LineCrossConfig>.Instance);
		if (!ConfigBase<LinkageRewardActivityConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward.LinkageRewardActivityConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LinkageRewardActivityConfig>.Instance);
		if (!ConfigBase<ActivityMapExploreConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMapExploreConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityMapExploreConfig>.Instance);
		if (!ConfigBase<ActivityMapTravelConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMapTravelConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityMapTravelConfig>.Instance);
		if (!ConfigBase<ActivityMoonChasingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityMoonChasingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityMoonChasingConfig>.Instance);
		if (!ConfigBase<BuildingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuildingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BuildingConfig>.Instance);
		if (!ConfigBase<BusinessConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BusinessConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BusinessConfig>.Instance);
		if (!ConfigBase<MoonChasingHandbookConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingHandbookConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MoonChasingHandbookConfig>.Instance);
		if (!ConfigBase<MoonChasingMemoryConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingMemoryConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MoonChasingMemoryConfig>.Instance);
		if (!ConfigBase<MoonChasingRewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MoonChasingRewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MoonChasingRewardConfig>.Instance);
		if (!ConfigBase<TaskConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TaskConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TaskConfig>.Instance);
		if (!ConfigBase<MoonSignInConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn.MoonSignInConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MoonSignInConfig>.Instance);
		if (!ConfigBase<ActivityMotorDevelopConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotoDevelop.ActivityMotorDevelopConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityMotorDevelopConfig>.Instance);
		if (!ConfigBase<ActivityMotorLinkageConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotoLinkage.ActivityMotorLinkageConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityMotorLinkageConfig>.Instance);
		if (!ConfigBase<MotorDecalLinkConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink.MotorDecalLinkConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotorDecalLinkConfig>.Instance);
		if (!ConfigBase<MotorFightConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotorFight.MotorFightConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotorFightConfig>.Instance);
		if (!ConfigBase<MotorParkourConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour.MotorParkourConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotorParkourConfig>.Instance);
		if (!ConfigBase<MowingTowerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MowingTowerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MowingTowerConfig>.Instance);
		if (!ConfigBase<MultiMotorConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor.MultiMotorConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MultiMotorConfig>.Instance);
		if (!ConfigBase<ActivityNewbieCourseV2Config>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNewbieCourseV2Config 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityNewbieCourseV2Config>.Instance);
		if (!ConfigBase<NewbieMainConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain.NewbieMainConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<NewbieMainConfig>.Instance);
		if (!ConfigBase<ActivityNewcomerJourneyConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNewcomerJourneyConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityNewcomerJourneyConfig>.Instance);
		if (!ConfigBase<ActivityDirectTrainConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.ActivityDirectTrainConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityDirectTrainConfig>.Instance);
		if (!ConfigBase<ActivityDangoMonopolyConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityDangoMonopolyConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityDangoMonopolyConfig>.Instance);
		if (!ConfigBase<ActivityDailyAdventureConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityDailyAdventureConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityDailyAdventureConfig>.Instance);
		if (!ConfigBase<CyberPunkConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk.CyberPunkConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CyberPunkConfig>.Instance);
		if (!ConfigBase<ConditionConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ConditionConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ConditionConfig>.Instance);
		if (!ConfigBase<TextConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TextConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TextConfig>.Instance);
		if (!ConfigBase<GameSettingsConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GameSettingsConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GameSettingsConfig>.Instance);
		if (!ConfigBase<InputSettingsConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.InputSetting.InputSettingsConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<InputSettingsConfig>.Instance);
		if (!ConfigBase<CommonTouchUiEditConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.InputSetting.CommonTouchUiEditConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CommonTouchUiEditConfig>.Instance);
		if (!ConfigBase<MotorcycleArrowConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MotorcycleArrowConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MotorcycleArrowConfig>.Instance);
		if (!ConfigBase<PinballBattleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PinballBattleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PinballBattleConfig>.Instance);
		if (!ConfigBase<LevelGamePlayConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.Common.LevelGamePlayConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<LevelGamePlayConfig>.Instance);
		if (!ConfigBase<MusicBeatTypeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.LevelConditions.Config.MusicBeatTypeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MusicBeatTypeConfig>.Instance);
		if (!ConfigBase<TuningStandConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.LevelGamePlay.TuningStand.TuningStandConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TuningStandConfig>.Instance);
		if (!ConfigBase<AchievementConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AchievementConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AchievementConfig>.Instance);
		if (!ConfigBase<DrinksConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DrinksConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DrinksConfig>.Instance);
		if (!ConfigBase<FurnitureConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FurnitureConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FurnitureConfig>.Instance);
		if (!ConfigBase<GolemHackingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GolemHackingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GolemHackingConfig>.Instance);
		if (!ConfigBase<ActivitySignGrandRewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivitySignGrandRewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivitySignGrandRewardConfig>.Instance);
		if (!ConfigBase<GuessJokerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "GuessJokerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<GuessJokerConfig>.Instance);
		if (!ConfigBase<ActivityConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityConfig>.Instance);
		if (!ConfigBase<AdvanceNoticeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdvanceNoticeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AdvanceNoticeConfig>.Instance);
		if (!ConfigBase<AnniversaryActivityConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Anniversary.AnniversaryActivityConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AnniversaryActivityConfig>.Instance);
		if (!ConfigBase<ArtemisActivityConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ArtemisActivityConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ArtemisActivityConfig>.Instance);
		if (!ConfigBase<AvignonConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AvignonConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AvignonConfig>.Instance);
		if (!ConfigBase<BabelTowerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BabelTowerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BabelTowerConfig>.Instance);
		if (!ConfigBase<ActivityBeginnerBookConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityBeginnerBookConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityBeginnerBookConfig>.Instance);
		if (!ConfigBase<BeginnerCarnivalConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BeginnerCarnivalConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BeginnerCarnivalConfig>.Instance);
		if (!ConfigBase<ActivityBlackCoastConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityBlackCoastConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityBlackCoastConfig>.Instance);
		if (!ConfigBase<BossRushConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BossRushConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BossRushConfig>.Instance);
		if (!ConfigBase<ActivityCollectionConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityCollectionConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityCollectionConfig>.Instance);
		if (!ConfigBase<CoopConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Coop.CoopConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CoopConfig>.Instance);
		if (!ConfigBase<ActivityCorniceMeetingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityCorniceMeetingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityCorniceMeetingConfig>.Instance);
		if (!ConfigBase<CumulativeShopConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CumulativeShopConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CumulativeShopConfig>.Instance);
		if (!ConfigBase<ActivityRecommendConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRecommendConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRecommendConfig>.Instance);
		if (!ConfigBase<ActivityNewPlayerSupportConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNewPlayerSupportConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityNewPlayerSupportConfig>.Instance);
		if (!ConfigBase<ActivityNoviceJourneyConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityNoviceJourneyConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityNoviceJourneyConfig>.Instance);
		if (!ConfigBase<ActivityPhantomCollectConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityPhantomCollectConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityPhantomCollectConfig>.Instance);
		if (!ConfigBase<BossPilingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BossPiling.BossPilingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BossPilingConfig>.Instance);
		if (!ConfigBase<BuffItemConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "BuffItemConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BuffItemConfig>.Instance);
		if (!ConfigBase<CalabashConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CalabashConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CalabashConfig>.Instance);
		if (!ConfigBase<ChatConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ChatConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ChatConfig>.Instance);
		if (!ConfigBase<ComboTeachingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ComboTeachingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ComboTeachingConfig>.Instance);
		if (!ConfigBase<ComicConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Comic.ComicConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ComicConfig>.Instance);
		if (!ConfigBase<AudioConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Common.AudioConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AudioConfig>.Instance);
		if (!ConfigBase<CommonConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CommonConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CommonConfig>.Instance);
		if (!ConfigBase<ComponentConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ComponentConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ComponentConfig>.Instance);
		if (!ConfigBase<ElementInfoConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ElementInfoConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ElementInfoConfig>.Instance);
		if (!ConfigBase<ExchangeRewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExchangeRewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ExchangeRewardConfig>.Instance);
		if (!ConfigBase<MappingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "MappingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MappingConfig>.Instance);
		if (!ConfigBase<PropertyIndexConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PropertyIndexConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PropertyIndexConfig>.Instance);
		if (!ConfigBase<UiResourceConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiResourceConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<UiResourceConfig>.Instance);
		if (!ConfigBase<BattleScoreConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.BattleScoreConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BattleScoreConfig>.Instance);
		if (!ConfigBase<UiViewConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "UiViewConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<UiViewConfig>.Instance);
		if (!ConfigBase<SortConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "SortConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SortConfig>.Instance);
		if (!ConfigBase<ConfirmBoxConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ConfirmBoxConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ConfirmBoxConfig>.Instance);
		if (!ConfigBase<CookConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Cook.CookConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CookConfig>.Instance);
		if (!ConfigBase<CreateCharacterConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CreateCharacterConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<CreateCharacterConfig>.Instance);
		if (!ConfigBase<DailyActivityConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DailyActivityConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DailyActivityConfig>.Instance);
		if (!ConfigBase<DamageUiConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DamageUiConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DamageUiConfig>.Instance);
		if (!ConfigBase<DangoAbyssConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DangoAbyssConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DangoAbyssConfig>.Instance);
		if (!ConfigBase<DangoConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Dango.DangoLogic.DangoConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DangoConfig>.Instance);
		if (!ConfigBase<DreamLinkConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.DreamLink.DreamLinkConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DreamLinkConfig>.Instance);
		if (!ConfigBase<DynamicTabConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "DynamicTabConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<DynamicTabConfig>.Instance);
		if (!ConfigBase<EditBattleTeamConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "EditBattleTeamConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<EditBattleTeamConfig>.Instance);
		if (!ConfigBase<ErrorCodeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ErrorCodeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ErrorCodeConfig>.Instance);
		if (!ConfigBase<ExploreLevelConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExploreLevelConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ExploreLevelConfig>.Instance);
		if (!ConfigBase<ExploreProgressConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ExploreProgressConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ExploreProgressConfig>.Instance);
		if (!ConfigBase<FilterConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "FilterConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FilterConfig>.Instance);
		if (!ConfigBase<FlagChallengeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.FlagChallenge.FlagChallengeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<FlagChallengeConfig>.Instance);
		if (!ConfigBase<MoraleBattleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.MoraleBattleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<MoraleBattleConfig>.Instance);
		if (!ConfigBase<BattleUiConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUi.BattleUiConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BattleUiConfig>.Instance);
		if (!ConfigBase<PinballConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "PinballConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<PinballConfig>.Instance);
		if (!ConfigBase<ActivityPreWarmConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.PreWarm.ActivityPreWarmConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityPreWarmConfig>.Instance);
		if (!ConfigBase<ActivityPrizeDrawingConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityPrizeDrawingConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityPrizeDrawingConfig>.Instance);
		if (!ConfigBase<ActivityRealmBetweenConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween.ActivityRealmBetweenConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRealmBetweenConfig>.Instance);
		if (!ConfigBase<ActivityRegressConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRegressConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRegressConfig>.Instance);
		if (!ConfigBase<RhythmShipConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.RhythmShipConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RhythmShipConfig>.Instance);
		if (!ConfigBase<ActivityRoadBookConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RoadBook.ActivityRoadBookConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRoadBookConfig>.Instance);
		if (!ConfigBase<ActivityRoleGiveConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRoleGiveConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRoleGiveConfig>.Instance);
		if (!ConfigBase<ActivityRoleGuideConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRoleGuideConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRoleGuideConfig>.Instance);
		if (!ConfigBase<ActivityRoleSkinRewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinReward.ActivityRoleSkinRewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRoleSkinRewardConfig>.Instance);
		if (!ConfigBase<RoleSkinTrialConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "RoleSkinTrialConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoleSkinTrialConfig>.Instance);
		if (!ConfigBase<ActivityRoleTrialConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRoleTrialConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRoleTrialConfig>.Instance);
		if (!ConfigBase<ActivityRogueConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity.ActivityRogueConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRogueConfig>.Instance);
		if (!ConfigBase<RoverlikeConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Roverlike.RoverlikeConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<RoverlikeConfig>.Instance);
		if (!ConfigBase<BattleLinkConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Battle.BattleLinkConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BattleLinkConfig>.Instance);
		if (!ConfigBase<ActivityRunConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityRunConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityRunConfig>.Instance);
		if (!ConfigBase<ActivitySevenDaySignConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivitySevenDaySignConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivitySevenDaySignConfig>.Instance);
		if (!ConfigBase<SpringManorConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.SpringManor.SpringManorConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<SpringManorConfig>.Instance);
		if (!ConfigBase<ActivityTetrisConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.Tetris.ActivityTetrisConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityTetrisConfig>.Instance);
		if (!ConfigBase<ActivityTimePointRewardConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityTimePointRewardConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityTimePointRewardConfig>.Instance);
		if (!ConfigBase<TotalTopUpConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp.TotalTopUpConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TotalTopUpConfig>.Instance);
		if (!ConfigBase<ActivityTowerGuideConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityTowerGuideConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityTowerGuideConfig>.Instance);
		if (!ConfigBase<ActivityTurntableConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityTurntableConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityTurntableConfig>.Instance);
		if (!ConfigBase<ActivityUniversalConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity.ActivityUniversalConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityUniversalConfig>.Instance);
		if (!ConfigBase<WheelTowerConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WheelTowerConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WheelTowerConfig>.Instance);
		if (!ConfigBase<WuWuLogisticsConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "WuWuLogisticsConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<WuWuLogisticsConfig>.Instance);
		if (!ConfigBase<AdventureGuideConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "AdventureGuideConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AdventureGuideConfig>.Instance);
		if (!ConfigBase<AdviceConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Advice.AdviceConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AdviceConfig>.Instance);
		if (!ConfigBase<AreaConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.Area.AreaConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<AreaConfig>.Instance);
		if (!ConfigBase<BattleUiSetConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "CSharpScript.Game.Module.BattleUiSet.BattleUiSetConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<BattleUiSetConfig>.Instance);
		if (!ConfigBase<ActivityScratchTicketConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "ActivityScratchTicketConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<ActivityScratchTicketConfig>.Instance);
		if (!ConfigBase<TimeScheduleConfig>.CreateInstance())
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, "TimeScheduleConfig 配置创建单例失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		ConfigRegister.Configs.Add(ConfigBase<TimeScheduleConfig>.Instance);
		return true;
	}

	// Token: 0x0601CAC0 RID: 117440 RVA: 0x008A3B20 File Offset: 0x008A1D20
	public static bool Init()
	{
		for (int i = 0; i < ConfigRegister.Configs.Count; i++)
		{
			IConfigBase configBase = ConfigRegister.Configs[i];
			if (!configBase.Init())
			{
				Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, configBase.GetType().FullName + " 配置初始化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601CAC1 RID: 117441 RVA: 0x008A3B88 File Offset: 0x008A1D88
	public static bool Clear()
	{
		bool result = true;
		for (int i = 0; i < ConfigRegister.Configs.Count; i++)
		{
			IConfigBase configBase = ConfigRegister.Configs[i];
			try
			{
				if (!configBase.Clear())
				{
					Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LRX, configBase.GetType().FullName + " 配置清理失败", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = false;
				}
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LRX;
				string message = configBase.GetType().FullName + " 配置清理失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ex:", ex.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = false;
			}
		}
		return result;
	}

	// Token: 0x0400E818 RID: 59416
	[StaticVariableRuleIgnore]
	private static List<IConfigBase> Configs = new List<IConfigBase>(269);
}
