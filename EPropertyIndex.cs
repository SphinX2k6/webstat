using System;

// Token: 0x0200179E RID: 6046
public enum EPropertyIndex
{
	// Token: 0x04005034 RID: 20532
	Invalid,
	// Token: 0x04005035 RID: 20533
	Lv,
	// Token: 0x04005036 RID: 20534
	LifeMax,
	// Token: 0x04005037 RID: 20535
	Life,
	// Token: 0x04005038 RID: 20536
	Sheild,
	// Token: 0x04005039 RID: 20537
	SheildDamageChange,
	// Token: 0x0400503A RID: 20538
	SheildDamageReduce,
	// Token: 0x0400503B RID: 20539
	Atk,
	// Token: 0x0400503C RID: 20540
	Crit,
	// Token: 0x0400503D RID: 20541
	CritDamage,
	// Token: 0x0400503E RID: 20542
	Def,
	// Token: 0x0400503F RID: 20543
	EnergyEfficiency,
	// Token: 0x04005040 RID: 20544
	CDReduse,
	// Token: 0x04005041 RID: 20545
	ReactionEfficiency,
	// Token: 0x04005042 RID: 20546
	DamageChangeNormalSkill,
	// Token: 0x04005043 RID: 20547
	DamageChange,
	// Token: 0x04005044 RID: 20548
	DamageReduce,
	// Token: 0x04005045 RID: 20549
	DamageChangeAuto,
	// Token: 0x04005046 RID: 20550
	DamageChangeCast,
	// Token: 0x04005047 RID: 20551
	DamageChangeUltra,
	// Token: 0x04005048 RID: 20552
	DamageChangeQTE,
	// Token: 0x04005049 RID: 20553
	DamageChangePhys,
	// Token: 0x0400504A RID: 20554
	DamageChangeElement1,
	// Token: 0x0400504B RID: 20555
	DamageChangeElement2,
	// Token: 0x0400504C RID: 20556
	DamageChangeElement3,
	// Token: 0x0400504D RID: 20557
	DamageChangeElement4,
	// Token: 0x0400504E RID: 20558
	DamageChangeElement5,
	// Token: 0x0400504F RID: 20559
	DamageChangeElement6,
	// Token: 0x04005050 RID: 20560
	DamageResistancePhys,
	// Token: 0x04005051 RID: 20561
	DamageResistanceElement1,
	// Token: 0x04005052 RID: 20562
	DamageResistanceElement2,
	// Token: 0x04005053 RID: 20563
	DamageResistanceElement3,
	// Token: 0x04005054 RID: 20564
	DamageResistanceElement4,
	// Token: 0x04005055 RID: 20565
	DamageResistanceElement5,
	// Token: 0x04005056 RID: 20566
	DamageResistanceElement6,
	// Token: 0x04005057 RID: 20567
	HealChange,
	// Token: 0x04005058 RID: 20568
	HealedChange,
	// Token: 0x04005059 RID: 20569
	DamageReducePhys,
	// Token: 0x0400505A RID: 20570
	DamageReduceElement1,
	// Token: 0x0400505B RID: 20571
	DamageReduceElement2,
	// Token: 0x0400505C RID: 20572
	DamageReduceElement3,
	// Token: 0x0400505D RID: 20573
	DamageReduceElement4,
	// Token: 0x0400505E RID: 20574
	DamageReduceElement5,
	// Token: 0x0400505F RID: 20575
	DamageReduceElement6,
	// Token: 0x04005060 RID: 20576
	SpecialEnergy5Max,
	// Token: 0x04005061 RID: 20577
	SpecialEnergy5,
	// Token: 0x04005062 RID: 20578
	ReactionChange3,
	// Token: 0x04005063 RID: 20579
	ReactionChange4,
	// Token: 0x04005064 RID: 20580
	ReactionChange5,
	// Token: 0x04005065 RID: 20581
	ReactionChange6,
	// Token: 0x04005066 RID: 20582
	ReactionChange7,
	// Token: 0x04005067 RID: 20583
	ReactionChange8,
	// Token: 0x04005068 RID: 20584
	ReactionChange9,
	// Token: 0x04005069 RID: 20585
	ReactionChange10,
	// Token: 0x0400506A RID: 20586
	ReactionChange11,
	// Token: 0x0400506B RID: 20587
	ReactionChange12,
	// Token: 0x0400506C RID: 20588
	ReactionChange13,
	// Token: 0x0400506D RID: 20589
	ReactionChange14,
	// Token: 0x0400506E RID: 20590
	ReactionChange15,
	// Token: 0x0400506F RID: 20591
	EnergyMax,
	// Token: 0x04005070 RID: 20592
	Energy,
	// Token: 0x04005071 RID: 20593
	SpecialEnergy1Max,
	// Token: 0x04005072 RID: 20594
	SpecialEnergy1,
	// Token: 0x04005073 RID: 20595
	SpecialEnergy2Max,
	// Token: 0x04005074 RID: 20596
	SpecialEnergy2,
	// Token: 0x04005075 RID: 20597
	SpecialEnergy3Max,
	// Token: 0x04005076 RID: 20598
	SpecialEnergy3,
	// Token: 0x04005077 RID: 20599
	SpecialEnergy4Max,
	// Token: 0x04005078 RID: 20600
	SpecialEnergy4,
	// Token: 0x04005079 RID: 20601
	StrengthMax,
	// Token: 0x0400507A RID: 20602
	Strength,
	// Token: 0x0400507B RID: 20603
	StrengthRecover,
	// Token: 0x0400507C RID: 20604
	StrengthPunishTime,
	// Token: 0x0400507D RID: 20605
	StrengthRun,
	// Token: 0x0400507E RID: 20606
	StrengthSwim,
	// Token: 0x0400507F RID: 20607
	StrengthFastSwim,
	// Token: 0x04005080 RID: 20608
	StrengthClimb,
	// Token: 0x04005081 RID: 20609
	StrengthFastClimb,
	// Token: 0x04005082 RID: 20610
	HardnessMax,
	// Token: 0x04005083 RID: 20611
	Hardness,
	// Token: 0x04005084 RID: 20612
	HardnessRecover,
	// Token: 0x04005085 RID: 20613
	HardnessPunishTime,
	// Token: 0x04005086 RID: 20614
	HardnessChange,
	// Token: 0x04005087 RID: 20615
	HardnessReduce,
	// Token: 0x04005088 RID: 20616
	ToughMax,
	// Token: 0x04005089 RID: 20617
	Tough,
	// Token: 0x0400508A RID: 20618
	ToughRecover,
	// Token: 0x0400508B RID: 20619
	ToughChange,
	// Token: 0x0400508C RID: 20620
	ToughReduce,
	// Token: 0x0400508D RID: 20621
	ElementPower1,
	// Token: 0x0400508E RID: 20622
	ElementPower2,
	// Token: 0x0400508F RID: 20623
	ElementPower3,
	// Token: 0x04005090 RID: 20624
	ElementPower4,
	// Token: 0x04005091 RID: 20625
	ElementPower5,
	// Token: 0x04005092 RID: 20626
	ElementPower6,
	// Token: 0x04005093 RID: 20627
	SpecialDamageChange,
	// Token: 0x04005094 RID: 20628
	StrengthFastClimbCost,
	// Token: 0x04005095 RID: 20629
	ElementPropertyType,
	// Token: 0x04005096 RID: 20630
	WeakTime,
	// Token: 0x04005097 RID: 20631
	IgnoreDefRate,
	// Token: 0x04005098 RID: 20632
	IgnoreDamageResistancePhys,
	// Token: 0x04005099 RID: 20633
	IgnoreDamageResistanceElement1,
	// Token: 0x0400509A RID: 20634
	IgnoreDamageResistanceElement2,
	// Token: 0x0400509B RID: 20635
	IgnoreDamageResistanceElement3,
	// Token: 0x0400509C RID: 20636
	IgnoreDamageResistanceElement4,
	// Token: 0x0400509D RID: 20637
	IgnoreDamageResistanceElement5,
	// Token: 0x0400509E RID: 20638
	IgnoreDamageResistanceElement6,
	// Token: 0x0400509F RID: 20639
	SkillToughRatio,
	// Token: 0x040050A0 RID: 20640
	StrengthClimbJump,
	// Token: 0x040050A1 RID: 20641
	StrengthGliding,
	// Token: 0x040050A2 RID: 20642
	Mass,
	// Token: 0x040050A3 RID: 20643
	BrakingFrictionFactor,
	// Token: 0x040050A4 RID: 20644
	GravityScale,
	// Token: 0x040050A5 RID: 20645
	SpeedRatio,
	// Token: 0x040050A6 RID: 20646
	DamageChangePhantom,
	// Token: 0x040050A7 RID: 20647
	AutoAttackSpeed,
	// Token: 0x040050A8 RID: 20648
	CastAttackSpeed,
	// Token: 0x040050A9 RID: 20649
	RageMax = 127,
	// Token: 0x040050AA RID: 20650
	Rage,
	// Token: 0x040050AB RID: 20651
	RageRecover,
	// Token: 0x040050AC RID: 20652
	RagePunishTime,
	// Token: 0x040050AD RID: 20653
	RageChange,
	// Token: 0x040050AE RID: 20654
	RageReduce,
	// Token: 0x040050AF RID: 20655
	ToughRecoverDelayTime,
	// Token: 0x040050B0 RID: 20656
	GreenLv = 10001,
	// Token: 0x040050B1 RID: 20657
	GreenLifeMax,
	// Token: 0x040050B2 RID: 20658
	GreenLife,
	// Token: 0x040050B3 RID: 20659
	GreenSheild,
	// Token: 0x040050B4 RID: 20660
	GreenSheildDamageChange,
	// Token: 0x040050B5 RID: 20661
	GreenSheildDamageReduce,
	// Token: 0x040050B6 RID: 20662
	GreenAtk,
	// Token: 0x040050B7 RID: 20663
	GreenCrit,
	// Token: 0x040050B8 RID: 20664
	GreenCritDamage,
	// Token: 0x040050B9 RID: 20665
	GreenDef,
	// Token: 0x040050BA RID: 20666
	GreenEnergyEfficiency,
	// Token: 0x040050BB RID: 20667
	GreenCDReduse,
	// Token: 0x040050BC RID: 20668
	GreenReactionEfficiency,
	// Token: 0x040050BD RID: 20669
	GreenDamageChangeNormalSkill,
	// Token: 0x040050BE RID: 20670
	GreenDamageChange,
	// Token: 0x040050BF RID: 20671
	GreenDamageReduce,
	// Token: 0x040050C0 RID: 20672
	GreenDamageChangeAuto,
	// Token: 0x040050C1 RID: 20673
	GreenDamageChangeCast,
	// Token: 0x040050C2 RID: 20674
	GreenDamageChangeUltra,
	// Token: 0x040050C3 RID: 20675
	GreenDamageChangeQTE,
	// Token: 0x040050C4 RID: 20676
	GreenDamageChangePhys,
	// Token: 0x040050C5 RID: 20677
	GreenDamageChangeElement1,
	// Token: 0x040050C6 RID: 20678
	GreenDamageChangeElement2,
	// Token: 0x040050C7 RID: 20679
	GreenDamageChangeElement3,
	// Token: 0x040050C8 RID: 20680
	GreenDamageChangeElement4,
	// Token: 0x040050C9 RID: 20681
	GreenDamageChangeElement5,
	// Token: 0x040050CA RID: 20682
	GreenDamageChangeElement6,
	// Token: 0x040050CB RID: 20683
	GreenDamageResistancePhys,
	// Token: 0x040050CC RID: 20684
	GreenDamageResistanceElement1,
	// Token: 0x040050CD RID: 20685
	GreenDamageResistanceElement2,
	// Token: 0x040050CE RID: 20686
	GreenDamageResistanceElement3,
	// Token: 0x040050CF RID: 20687
	GreenDamageResistanceElement4,
	// Token: 0x040050D0 RID: 20688
	GreenDamageResistanceElement5,
	// Token: 0x040050D1 RID: 20689
	GreenDamageResistanceElement6,
	// Token: 0x040050D2 RID: 20690
	GreenHealChange,
	// Token: 0x040050D3 RID: 20691
	GreenHealedChange,
	// Token: 0x040050D4 RID: 20692
	GreenDamageReducePhys,
	// Token: 0x040050D5 RID: 20693
	GreenDamageReduceElement1,
	// Token: 0x040050D6 RID: 20694
	GreenDamageReduceElement2,
	// Token: 0x040050D7 RID: 20695
	GreenDamageReduceElement3,
	// Token: 0x040050D8 RID: 20696
	GreenDamageReduceElement4,
	// Token: 0x040050D9 RID: 20697
	GreenDamageReduceElement5,
	// Token: 0x040050DA RID: 20698
	GreenDamageReduceElement6,
	// Token: 0x040050DB RID: 20699
	GreenSpecialEnergy5Max,
	// Token: 0x040050DC RID: 20700
	GreenSpecialEnergy5,
	// Token: 0x040050DD RID: 20701
	GreenReactionChange3,
	// Token: 0x040050DE RID: 20702
	GreenReactionChange4,
	// Token: 0x040050DF RID: 20703
	GreenReactionChange5,
	// Token: 0x040050E0 RID: 20704
	GreenReactionChange6,
	// Token: 0x040050E1 RID: 20705
	GreenReactionChange7,
	// Token: 0x040050E2 RID: 20706
	GreenReactionChange8,
	// Token: 0x040050E3 RID: 20707
	GreenReactionChange9,
	// Token: 0x040050E4 RID: 20708
	GreenReactionChange10,
	// Token: 0x040050E5 RID: 20709
	GreenReactionChange11,
	// Token: 0x040050E6 RID: 20710
	GreenReactionChange12,
	// Token: 0x040050E7 RID: 20711
	GreenReactionChange13,
	// Token: 0x040050E8 RID: 20712
	GreenReactionChange14,
	// Token: 0x040050E9 RID: 20713
	GreenReactionChange15,
	// Token: 0x040050EA RID: 20714
	GreenEnergyMax,
	// Token: 0x040050EB RID: 20715
	GreenEnergy,
	// Token: 0x040050EC RID: 20716
	GreenSpecialEnergy1Max,
	// Token: 0x040050ED RID: 20717
	GreenSpecialEnergy1,
	// Token: 0x040050EE RID: 20718
	GreenSpecialEnergy2Max,
	// Token: 0x040050EF RID: 20719
	GreenSpecialEnergy2,
	// Token: 0x040050F0 RID: 20720
	GreenSpecialEnergy3Max,
	// Token: 0x040050F1 RID: 20721
	GreenSpecialEnergy3,
	// Token: 0x040050F2 RID: 20722
	GreenSpecialEnergy4Max,
	// Token: 0x040050F3 RID: 20723
	GreenSpecialEnergy4,
	// Token: 0x040050F4 RID: 20724
	GreenStrengthMax,
	// Token: 0x040050F5 RID: 20725
	GreenStrength,
	// Token: 0x040050F6 RID: 20726
	GreenStrengthRecover,
	// Token: 0x040050F7 RID: 20727
	GreenStrengthPunishTime,
	// Token: 0x040050F8 RID: 20728
	GreenStrengthRun,
	// Token: 0x040050F9 RID: 20729
	GreenStrengthSwim,
	// Token: 0x040050FA RID: 20730
	GreenStrengthFastSwim,
	// Token: 0x040050FB RID: 20731
	GreenStrengthClimb,
	// Token: 0x040050FC RID: 20732
	GreenStrengthFastClimb,
	// Token: 0x040050FD RID: 20733
	GreenHardnessMax,
	// Token: 0x040050FE RID: 20734
	GreenHardness,
	// Token: 0x040050FF RID: 20735
	GreenHardnessRecover,
	// Token: 0x04005100 RID: 20736
	GreenHardnessPunishTime,
	// Token: 0x04005101 RID: 20737
	GreenHardnessChange,
	// Token: 0x04005102 RID: 20738
	GreenHardnessReduce,
	// Token: 0x04005103 RID: 20739
	GreenToughMax,
	// Token: 0x04005104 RID: 20740
	GreenTough,
	// Token: 0x04005105 RID: 20741
	GreenToughRecover,
	// Token: 0x04005106 RID: 20742
	GreenToughChange,
	// Token: 0x04005107 RID: 20743
	GreenToughReduce,
	// Token: 0x04005108 RID: 20744
	GreenElementPower1,
	// Token: 0x04005109 RID: 20745
	GreenElementPower2,
	// Token: 0x0400510A RID: 20746
	GreenElementPower3,
	// Token: 0x0400510B RID: 20747
	GreenElementPower4,
	// Token: 0x0400510C RID: 20748
	GreenElementPower5,
	// Token: 0x0400510D RID: 20749
	GreenElementPower6,
	// Token: 0x0400510E RID: 20750
	GreenSpecialDamageChange,
	// Token: 0x0400510F RID: 20751
	GreenStrengthFastClimbCost,
	// Token: 0x04005110 RID: 20752
	GreenElementPropertyType,
	// Token: 0x04005111 RID: 20753
	GreenWeakTime,
	// Token: 0x04005112 RID: 20754
	GreenIgnoreDefRate,
	// Token: 0x04005113 RID: 20755
	GreenIgnoreDamageResistancePhys,
	// Token: 0x04005114 RID: 20756
	GreenIgnoreDamageResistanceElement1,
	// Token: 0x04005115 RID: 20757
	GreenIgnoreDamageResistanceElement2,
	// Token: 0x04005116 RID: 20758
	GreenIgnoreDamageResistanceElement3,
	// Token: 0x04005117 RID: 20759
	GreenIgnoreDamageResistanceElement4,
	// Token: 0x04005118 RID: 20760
	GreenIgnoreDamageResistanceElement5,
	// Token: 0x04005119 RID: 20761
	GreenIgnoreDamageResistanceElement6,
	// Token: 0x0400511A RID: 20762
	GreenSkillToughRatio,
	// Token: 0x0400511B RID: 20763
	GreenStrengthClimbJump,
	// Token: 0x0400511C RID: 20764
	GreenStrengthGliding,
	// Token: 0x0400511D RID: 20765
	GreenMass,
	// Token: 0x0400511E RID: 20766
	GreenBrakingFrictionFactor,
	// Token: 0x0400511F RID: 20767
	GreenGravityScale,
	// Token: 0x04005120 RID: 20768
	GreenSpeedRatio,
	// Token: 0x04005121 RID: 20769
	GreenDamageChangePhantom,
	// Token: 0x04005122 RID: 20770
	GreenAutoAttackSpeed,
	// Token: 0x04005123 RID: 20771
	GreenCastAttackSpeed,
	// Token: 0x04005124 RID: 20772
	GreenRageMax = 10127,
	// Token: 0x04005125 RID: 20773
	GreenRage,
	// Token: 0x04005126 RID: 20774
	GreenRageRecover,
	// Token: 0x04005127 RID: 20775
	GreenRagePunishTime,
	// Token: 0x04005128 RID: 20776
	GreenRageChange,
	// Token: 0x04005129 RID: 20777
	GreenRageReduce,
	// Token: 0x0400512A RID: 20778
	GreenToughRecoverDelayTime
}
