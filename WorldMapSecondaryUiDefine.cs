using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

// Token: 0x02002D73 RID: 11635
public static class WorldMapSecondaryUiDefine
{
	// Token: 0x060177BA RID: 96186 RVA: 0x0068206C File Offset: 0x0068026C
	// Note: this type is marked as 'beforefieldinit'.
	static WorldMapSecondaryUiDefine()
	{
		Dictionary<EMarkType, ESecondaryPanel> dictionary = new Dictionary<EMarkType, ESecondaryPanel>();
		dictionary[EMarkType.Custom] = ESecondaryPanel.CustomMarkPanel;
		dictionary[EMarkType.Quest] = ESecondaryPanel.QuestPanel;
		dictionary[EMarkType.Parkour] = ESecondaryPanel.ParkourPanel;
		dictionary[EMarkType.TemporaryTeleport] = ESecondaryPanel.TemporaryTeleportPanel;
		dictionary[EMarkType.TreasureBoxDetector] = ESecondaryPanel.DetectorPanel;
		dictionary[EMarkType.SoundBox] = ESecondaryPanel.BoxPanel;
		dictionary[EMarkType.TreasureBox] = ESecondaryPanel.BoxPanel;
		dictionary[EMarkType.EnrichmentArea] = ESecondaryPanel.EnrichmentAreaPanel;
		dictionary[EMarkType.PunishReport] = ESecondaryPanel.PunishReportPanel;
		dictionary[EMarkType.CorniceMeeting] = ESecondaryPanel.CorniceMeetingPanel;
		dictionary[EMarkType.CaveHole] = ESecondaryPanel.CaveHole;
		dictionary[EMarkType.LevelPlayReport] = ESecondaryPanel.PunishReportPanel;
		dictionary[EMarkType.GreatSwordChallenge] = ESecondaryPanel.GreatSwordChallengePanel;
		dictionary[EMarkType.CommonGamePlay] = ESecondaryPanel.CommonGamePlayPanel;
		dictionary[EMarkType.MapTravelQuest] = ESecondaryPanel.MapTravelQuestPanel;
		dictionary[EMarkType.FishingPoint] = ESecondaryPanel.FishingPoint;
		dictionary[EMarkType.FishingDock] = ESecondaryPanel.FishingDock;
		dictionary[EMarkType.FishingCage] = ESecondaryPanel.FishingCage;
		dictionary[EMarkType.FishingShip] = ESecondaryPanel.FishingShip;
		dictionary[EMarkType.SightSpot] = ESecondaryPanel.TraceExploreEntityPanel;
		dictionary[EMarkType.FlyingHunter] = ESecondaryPanel.TraceExploreEntityPanel;
		dictionary[EMarkType.Frostbite] = ESecondaryPanel.TraceExploreEntityPanel;
		dictionary[EMarkType.HonamiScanItem] = ESecondaryPanel.HonamiScanItemPanel;
		dictionary[EMarkType.HonamiScan] = ESecondaryPanel.HonamiScanMachinePanel;
		dictionary[EMarkType.InfrRoad] = ESecondaryPanel.InfrRoadPanel;
		dictionary[EMarkType.InfrObservatory] = ESecondaryPanel.InfrObservatoryPanel;
		dictionary[EMarkType.PhantomArenaNpc] = ESecondaryPanel.PhantomArenaNpcPanel;
		dictionary[EMarkType.VillageInfr] = ESecondaryPanel.VillageInfrPanel;
		dictionary[EMarkType.VillageInfrTree] = ESecondaryPanel.VillageInfrTreePanel;
		dictionary[EMarkType.SheriffQuest] = ESecondaryPanel.SheriffQuestPanel;
		dictionary[EMarkType.DollGrabMachine] = ESecondaryPanel.DollGrabMachinePanel;
		WorldMapSecondaryUiDefine.MarkPanelTypeMap = dictionary;
	}

	// Token: 0x0400B410 RID: 46096
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EMarkType, ESecondaryPanel> MarkPanelTypeMap;
}
