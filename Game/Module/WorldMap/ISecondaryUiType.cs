using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.CustomMarkPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B26 RID: 19238
	[NullableContext(1)]
	public interface ISecondaryUiType
	{
		// Token: 0x170085A7 RID: 34215
		// (get) Token: 0x060322D5 RID: 205525
		// (set) Token: 0x060322D6 RID: 205526
		Action<CustomMarkItem, ECustomMarkPanelMode> CustomMarkPanel { get; set; }

		// Token: 0x170085A8 RID: 34216
		// (get) Token: 0x060322D7 RID: 205527
		// (set) Token: 0x060322D8 RID: 205528
		Action<TeleportMarkItem> TeleportPanel { get; set; }

		// Token: 0x170085A9 RID: 34217
		// (get) Token: 0x060322D9 RID: 205529
		// (set) Token: 0x060322DA RID: 205530
		Action<ConfigMarkItem> GeneralPanel { get; set; }

		// Token: 0x170085AA RID: 34218
		// (get) Token: 0x060322DB RID: 205531
		// (set) Token: 0x060322DC RID: 205532
		Action<MarkItem[]> MarkMenuPanel { get; set; }

		// Token: 0x170085AB RID: 34219
		// (get) Token: 0x060322DD RID: 205533
		// (set) Token: 0x060322DE RID: 205534
		Action<TaskMarkItem> QuestPanel { get; set; }

		// Token: 0x170085AC RID: 34220
		// (get) Token: 0x060322DF RID: 205535
		// (set) Token: 0x060322E0 RID: 205536
		Action<TeleportMarkItem> InstanceDungeonEntrancePanel { get; set; }

		// Token: 0x170085AD RID: 34221
		// (get) Token: 0x060322E1 RID: 205537
		// (set) Token: 0x060322E2 RID: 205538
		Action<SceneGameplayMarkItem> SceneGameplayPanel { get; set; }

		// Token: 0x170085AE RID: 34222
		// (get) Token: 0x060322E3 RID: 205539
		// (set) Token: 0x060322E4 RID: 205540
		Action<TeleportMarkItem> TowerEntrancePanel { get; set; }

		// Token: 0x170085AF RID: 34223
		// (get) Token: 0x060322E5 RID: 205541
		// (set) Token: 0x060322E6 RID: 205542
		Action<TeleportMarkItem> ShipTowerEntrancePanel { get; set; }

		// Token: 0x170085B0 RID: 34224
		// (get) Token: 0x060322E7 RID: 205543
		// (set) Token: 0x060322E8 RID: 205544
		Action<ParkourMarkItem> ParkourPanel { get; set; }

		// Token: 0x170085B1 RID: 34225
		// (get) Token: 0x060322E9 RID: 205545
		// (set) Token: 0x060322EA RID: 205546
		Action<TemporaryTeleportMarkItem> TemporaryTeleportPanel { get; set; }

		// Token: 0x170085B2 RID: 34226
		// (get) Token: 0x060322EB RID: 205547
		// (set) Token: 0x060322EC RID: 205548
		Action<TreasureBoxDetectorMarkItem> DetectorPanel { get; set; }

		// Token: 0x170085B3 RID: 34227
		// (get) Token: 0x060322ED RID: 205549
		// (set) Token: 0x060322EE RID: 205550
		Action<IBoxMark> BoxPanel { get; set; }

		// Token: 0x170085B4 RID: 34228
		// (get) Token: 0x060322EF RID: 205551
		// (set) Token: 0x060322F0 RID: 205552
		Action<SceneGameplayMarkItem> LordGymPanel { get; set; }

		// Token: 0x170085B5 RID: 34229
		// (get) Token: 0x060322F1 RID: 205553
		// (set) Token: 0x060322F2 RID: 205554
		Action<TeleportMarkItem> RoguelikePanel { get; set; }

		// Token: 0x170085B6 RID: 34230
		// (get) Token: 0x060322F3 RID: 205555
		// (set) Token: 0x060322F4 RID: 205556
		Action<ConfigMarkItem> WeeklyRoguePanel { get; set; }

		// Token: 0x170085B7 RID: 34231
		// (get) Token: 0x060322F5 RID: 205557
		// (set) Token: 0x060322F6 RID: 205558
		Action<ConfigMarkItem> RogueResPanel { get; set; }

		// Token: 0x170085B8 RID: 34232
		// (get) Token: 0x060322F7 RID: 205559
		// (set) Token: 0x060322F8 RID: 205560
		Action<EnrichmentAreaItem> EnrichmentAreaPanel { get; set; }

		// Token: 0x170085B9 RID: 34233
		// (get) Token: 0x060322F9 RID: 205561
		// (set) Token: 0x060322FA RID: 205562
		Action<PunishReportMarkItem> PunishReportPanel { get; set; }

		// Token: 0x170085BA RID: 34234
		// (get) Token: 0x060322FB RID: 205563
		// (set) Token: 0x060322FC RID: 205564
		Action<CorniceMeetingMarkItem> CorniceMeetingPanel { get; set; }

		// Token: 0x170085BB RID: 34235
		// (get) Token: 0x060322FD RID: 205565
		// (set) Token: 0x060322FE RID: 205566
		Action<MarkItem[]> QuickNavigatePanel { get; set; }

		// Token: 0x170085BC RID: 34236
		// (get) Token: 0x060322FF RID: 205567
		// (set) Token: 0x06032300 RID: 205568
		Action<CaveHoleMarkItem> CaveHole { get; set; }

		// Token: 0x170085BD RID: 34237
		// (get) Token: 0x06032301 RID: 205569
		// (set) Token: 0x06032302 RID: 205570
		Action<ConfigMarkItem> CommonGamePlayPanel { get; set; }

		// Token: 0x170085BE RID: 34238
		// (get) Token: 0x06032303 RID: 205571
		// (set) Token: 0x06032304 RID: 205572
		Action<ITrackMenuItemData[]> TrackMenuPanel { get; set; }

		// Token: 0x170085BF RID: 34239
		// (get) Token: 0x06032305 RID: 205573
		// (set) Token: 0x06032306 RID: 205574
		Action<IMapNoteParams[]> WorldMapNotePanel { get; set; }

		// Token: 0x170085C0 RID: 34240
		// (get) Token: 0x06032307 RID: 205575
		// (set) Token: 0x06032308 RID: 205576
		Action MapMarkTogglePanel { get; set; }

		// Token: 0x170085C1 RID: 34241
		// (get) Token: 0x06032309 RID: 205577
		// (set) Token: 0x0603230A RID: 205578
		Action<TeleportMarkItem> MapTravelQuestPanel { get; set; }

		// Token: 0x170085C2 RID: 34242
		// (get) Token: 0x0603230B RID: 205579
		// (set) Token: 0x0603230C RID: 205580
		Action<FishingShipMarkItem> FishingShip { get; set; }

		// Token: 0x170085C3 RID: 34243
		// (get) Token: 0x0603230D RID: 205581
		// (set) Token: 0x0603230E RID: 205582
		Action<FishingPointMarkItem> FishingPoint { get; set; }

		// Token: 0x170085C4 RID: 34244
		// (get) Token: 0x0603230F RID: 205583
		// (set) Token: 0x06032310 RID: 205584
		Action<ConfigMarkItem> FishingCage { get; set; }

		// Token: 0x170085C5 RID: 34245
		// (get) Token: 0x06032311 RID: 205585
		// (set) Token: 0x06032312 RID: 205586
		Action<ConfigMarkItem> FishingDock { get; set; }

		// Token: 0x170085C6 RID: 34246
		// (get) Token: 0x06032313 RID: 205587
		// (set) Token: 0x06032314 RID: 205588
		Action<TraceExploreEntityMarkItem> TraceExploreEntityPanel { get; set; }

		// Token: 0x170085C7 RID: 34247
		// (get) Token: 0x06032315 RID: 205589
		// (set) Token: 0x06032316 RID: 205590
		Action<GreatSwordChallengeMarkItem> GreatSwordChallengePanel { get; set; }

		// Token: 0x170085C8 RID: 34248
		// (get) Token: 0x06032317 RID: 205591
		// (set) Token: 0x06032318 RID: 205592
		Action<HonamiScanItemMarkItem> HonamiScanItemPanel { get; set; }

		// Token: 0x170085C9 RID: 34249
		// (get) Token: 0x06032319 RID: 205593
		// (set) Token: 0x0603231A RID: 205594
		Action<HonamiScanMarkItem> HonamiScanMachinePanel { get; set; }

		// Token: 0x170085CA RID: 34250
		// (get) Token: 0x0603231B RID: 205595
		// (set) Token: 0x0603231C RID: 205596
		Action ActivityListPanel { get; set; }

		// Token: 0x170085CB RID: 34251
		// (get) Token: 0x0603231D RID: 205597
		// (set) Token: 0x0603231E RID: 205598
		Action<InfrObservatoryMarkItem> InfrObservatoryPanel { get; set; }

		// Token: 0x170085CC RID: 34252
		// (get) Token: 0x0603231F RID: 205599
		// (set) Token: 0x06032320 RID: 205600
		Action<InfrRoadMarkItem> InfrRoadPanel { get; set; }

		// Token: 0x170085CD RID: 34253
		// (get) Token: 0x06032321 RID: 205601
		// (set) Token: 0x06032322 RID: 205602
		Action<PhantomArenaNpcMarkItem> PhantomArenaNpcPanel { get; set; }

		// Token: 0x170085CE RID: 34254
		// (get) Token: 0x06032323 RID: 205603
		// (set) Token: 0x06032324 RID: 205604
		Action<TeleportMarkItem> WheelTowerEntrancePanel { get; set; }

		// Token: 0x170085CF RID: 34255
		// (get) Token: 0x06032325 RID: 205605
		// (set) Token: 0x06032326 RID: 205606
		Action<VillageInfrMarkItem> VillageInfrPanel { get; set; }

		// Token: 0x170085D0 RID: 34256
		// (get) Token: 0x06032327 RID: 205607
		// (set) Token: 0x06032328 RID: 205608
		Action<VillageInfrTreeMarkItem> VillageInfrTreePanel { get; set; }

		// Token: 0x170085D1 RID: 34257
		// (get) Token: 0x06032329 RID: 205609
		// (set) Token: 0x0603232A RID: 205610
		Action<int> SheriffCriminalPanel { get; set; }

		// Token: 0x170085D2 RID: 34258
		// (get) Token: 0x0603232B RID: 205611
		// (set) Token: 0x0603232C RID: 205612
		Action<SheriffQuestMarkItem> SheriffQuestPanel { get; set; }

		// Token: 0x170085D3 RID: 34259
		// (get) Token: 0x0603232D RID: 205613
		// (set) Token: 0x0603232E RID: 205614
		Action<DollGrabMachineMarkItem> DollGrabMachinePanel { get; set; }
	}
}
