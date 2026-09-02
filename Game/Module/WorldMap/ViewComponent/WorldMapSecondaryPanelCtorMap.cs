using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PermanentRogue;
using CSharpScript.Game.Module.WorldMap.SubViews.ActivityListPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.ActivityPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.BoxPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.CaveHole;
using CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay;
using CSharpScript.Game.Module.WorldMap.SubViews.CorniceMeeting;
using CSharpScript.Game.Module.WorldMap.SubViews.CustomMarkPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.DectetorPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.DollGrabMachine;
using CSharpScript.Game.Module.WorldMap.SubViews.Enrichment;
using CSharpScript.Game.Module.WorldMap.SubViews.Fishing;
using CSharpScript.Game.Module.WorldMap.SubViews.GeneralPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.GreatSword;
using CSharpScript.Game.Module.WorldMap.SubViews.HonamiPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.InfrastructurePanel;
using CSharpScript.Game.Module.WorldMap.SubViews.InstanceDungeonEntrancePanel;
using CSharpScript.Game.Module.WorldMap.SubViews.LordGymPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle;
using CSharpScript.Game.Module.WorldMap.SubViews.MapTravel;
using CSharpScript.Game.Module.WorldMap.SubViews.MarkMenu;
using CSharpScript.Game.Module.WorldMap.SubViews.PhantomArenaPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.PunishReport;
using CSharpScript.Game.Module.WorldMap.SubViews.QuestPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.SceneGameplayPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.Sheriff;
using CSharpScript.Game.Module.WorldMap.SubViews.TeleportPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.TemporaryTeleportPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.TraceExploreEntityPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu;
using CSharpScript.Game.Module.WorldMap.SubViews.VillageInfrPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapNote;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B52 RID: 19282
	public static class WorldMapSecondaryPanelCtorMap
	{
		// Token: 0x060325C7 RID: 206279 RVA: 0x00C99DB8 File Offset: 0x00C97FB8
		// Note: this type is marked as 'beforefieldinit'.
		static WorldMapSecondaryPanelCtorMap()
		{
			Dictionary<ESecondaryPanel, Func<UiPanelBase>> dictionary = new Dictionary<ESecondaryPanel, Func<UiPanelBase>>();
			dictionary[ESecondaryPanel.CustomMarkPanel] = (() => new CustomMarkPanel());
			dictionary[ESecondaryPanel.QuestPanel] = (() => new QuestPanel());
			dictionary[ESecondaryPanel.GeneralPanel] = (() => new GeneralPanel());
			dictionary[ESecondaryPanel.MarkMenuPanel] = (() => new MarkMenu());
			dictionary[ESecondaryPanel.ParkourPanel] = (() => new ParkourEntrancePanel());
			dictionary[ESecondaryPanel.LordGymPanel] = (() => new LordGymPanel());
			dictionary[ESecondaryPanel.SceneGameplayPanel] = (() => new SceneGameplayPanel());
			dictionary[ESecondaryPanel.TemporaryTeleportPanel] = (() => new TemporaryTeleportPanel());
			dictionary[ESecondaryPanel.DetectorPanel] = (() => new DetectorPanel());
			dictionary[ESecondaryPanel.BoxPanel] = (() => new BoxPanel());
			dictionary[ESecondaryPanel.EnrichmentAreaPanel] = (() => new EnrichmentAreaPanel());
			dictionary[ESecondaryPanel.PunishReportPanel] = (() => new PunishReportPanel());
			dictionary[ESecondaryPanel.TeleportPanel] = (() => new TeleportPanel());
			dictionary[ESecondaryPanel.InstanceDungeonEntrancePanel] = (() => new InstanceDungeonEntrancePanel());
			dictionary[ESecondaryPanel.TowerEntrancePanel] = (() => new TowerEntrancePanel());
			dictionary[ESecondaryPanel.ShipTowerEntrancePanel] = (() => new ShipTowerEntrancePanel());
			dictionary[ESecondaryPanel.RoguelikePanel] = (() => new RoguelikeEntrancePanel());
			dictionary[ESecondaryPanel.WeeklyRoguePanel] = (() => new WeeklyRogueEntrancePanel());
			dictionary[ESecondaryPanel.RogueResPanel] = (() => new RogueResMapEntrancePanel());
			dictionary[ESecondaryPanel.CorniceMeetingPanel] = (() => new CorniceMeetingEntrancePanel());
			dictionary[ESecondaryPanel.QuickNavigatePanel] = (() => new WorldMapQuickNavigatePanel());
			dictionary[ESecondaryPanel.CaveHole] = (() => new CaveHoleSecondaryPanel());
			dictionary[ESecondaryPanel.CommonGamePlayPanel] = (() => new CommonGamePlayPanel());
			dictionary[ESecondaryPanel.TrackMenuPanel] = (() => new TrackMenuPanel());
			dictionary[ESecondaryPanel.WorldMapNotePanel] = (() => new WorldMapNotePanel());
			dictionary[ESecondaryPanel.MapMarkTogglePanel] = (() => new MapMarkTogglePanel());
			dictionary[ESecondaryPanel.MapTravelQuestPanel] = (() => new MapTravelQuestPanel());
			dictionary[ESecondaryPanel.FishingShip] = (() => new WorldMapFishingShipSecondaryPanel());
			dictionary[ESecondaryPanel.FishingPoint] = (() => new WorldMapFishingPointSecondaryPanel());
			dictionary[ESecondaryPanel.FishingCage] = (() => new WorldMapFishingCageSecondaryPanel());
			dictionary[ESecondaryPanel.FishingDock] = (() => new WorldMapFishingDockSecondaryPanel());
			dictionary[ESecondaryPanel.TraceExploreEntityPanel] = (() => new TraceExploreEntityPanel());
			dictionary[ESecondaryPanel.GreatSwordChallengePanel] = (() => new GreatSwordMarkPanel());
			dictionary[ESecondaryPanel.ActivityListPanel] = (() => new ActivityListPanel());
			dictionary[ESecondaryPanel.HonamiScanItemPanel] = (() => new HonamiScanItemPanel());
			dictionary[ESecondaryPanel.HonamiScanMachinePanel] = (() => new HonamiScanMachinePanel());
			dictionary[ESecondaryPanel.InfrRoadPanel] = (() => new InfrastructureRoadPanel());
			dictionary[ESecondaryPanel.InfrObservatoryPanel] = (() => new InfrastructureObservatoryPanel());
			dictionary[ESecondaryPanel.PhantomArenaNpcPanel] = (() => new PhantomArenaNpcPanel());
			dictionary[ESecondaryPanel.WheelTowerEntrancePanel] = (() => new WheelTowerEntrancePanel());
			dictionary[ESecondaryPanel.VillageInfrPanel] = (() => new VillageInfrPanel());
			dictionary[ESecondaryPanel.VillageInfrTreePanel] = (() => new VillageInfrTreePanel());
			dictionary[ESecondaryPanel.SheriffCriminalPanel] = (() => new SheriffCriminalPanel());
			dictionary[ESecondaryPanel.SheriffQuestPanel] = (() => new SheriffQuestPanel());
			dictionary[ESecondaryPanel.DollGrabMachinePanel] = (() => new DollGrabMachinePanel());
			WorldMapSecondaryPanelCtorMap.Map = dictionary;
		}

		// Token: 0x0401D699 RID: 120473
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ESecondaryPanel, Func<UiPanelBase>> Map;
	}
}
