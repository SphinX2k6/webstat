using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Protocol
{
	// Token: 0x02003DA9 RID: 15785
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Protocol/EAttributeType.EAttributeType")]
	public enum EAttributeType : byte
	{
		// Token: 0x040141B8 RID: 82360
		EAttributeType_None,
		// Token: 0x040141B9 RID: 82361
		Lv,
		// Token: 0x040141BA RID: 82362
		LifeMax,
		// Token: 0x040141BB RID: 82363
		Life,
		// Token: 0x040141BC RID: 82364
		Sheild,
		// Token: 0x040141BD RID: 82365
		SheildDamageChange,
		// Token: 0x040141BE RID: 82366
		SheildDamageReduce,
		// Token: 0x040141BF RID: 82367
		Atk,
		// Token: 0x040141C0 RID: 82368
		Crit,
		// Token: 0x040141C1 RID: 82369
		CritDamage,
		// Token: 0x040141C2 RID: 82370
		Def,
		// Token: 0x040141C3 RID: 82371
		EnergyEfficiency,
		// Token: 0x040141C4 RID: 82372
		CDReduse,
		// Token: 0x040141C5 RID: 82373
		ReactionEfficiency,
		// Token: 0x040141C6 RID: 82374
		DamageChangeNormalSkill,
		// Token: 0x040141C7 RID: 82375
		DamageChange,
		// Token: 0x040141C8 RID: 82376
		DamageReduce,
		// Token: 0x040141C9 RID: 82377
		DamageChangeAuto,
		// Token: 0x040141CA RID: 82378
		DamageChangeCast,
		// Token: 0x040141CB RID: 82379
		DamageChangeUltra,
		// Token: 0x040141CC RID: 82380
		DamageChangeQTE,
		// Token: 0x040141CD RID: 82381
		DamageChangePhys,
		// Token: 0x040141CE RID: 82382
		DamageChangeElement1,
		// Token: 0x040141CF RID: 82383
		DamageChangeElement2,
		// Token: 0x040141D0 RID: 82384
		DamageChangeElement3,
		// Token: 0x040141D1 RID: 82385
		DamageChangeElement4,
		// Token: 0x040141D2 RID: 82386
		DamageChangeElement5,
		// Token: 0x040141D3 RID: 82387
		DamageChangeElement6,
		// Token: 0x040141D4 RID: 82388
		DamageResistancePhys,
		// Token: 0x040141D5 RID: 82389
		DamageResistanceElement1,
		// Token: 0x040141D6 RID: 82390
		DamageResistanceElement2,
		// Token: 0x040141D7 RID: 82391
		DamageResistanceElement3,
		// Token: 0x040141D8 RID: 82392
		DamageResistanceElement4,
		// Token: 0x040141D9 RID: 82393
		DamageResistanceElement5,
		// Token: 0x040141DA RID: 82394
		DamageResistanceElement6,
		// Token: 0x040141DB RID: 82395
		HealChange,
		// Token: 0x040141DC RID: 82396
		HealedChange,
		// Token: 0x040141DD RID: 82397
		DamageReducePhys,
		// Token: 0x040141DE RID: 82398
		DamageReduceElement1,
		// Token: 0x040141DF RID: 82399
		DamageReduceElement2,
		// Token: 0x040141E0 RID: 82400
		DamageReduceElement3,
		// Token: 0x040141E1 RID: 82401
		DamageReduceElement4,
		// Token: 0x040141E2 RID: 82402
		DamageReduceElement5,
		// Token: 0x040141E3 RID: 82403
		DamageReduceElement6,
		// Token: 0x040141E4 RID: 82404
		ReactionChange1,
		// Token: 0x040141E5 RID: 82405
		ReactionChange2,
		// Token: 0x040141E6 RID: 82406
		ReactionChange3,
		// Token: 0x040141E7 RID: 82407
		ReactionChange4,
		// Token: 0x040141E8 RID: 82408
		ReactionChange5,
		// Token: 0x040141E9 RID: 82409
		ReactionChange6,
		// Token: 0x040141EA RID: 82410
		ReactionChange7,
		// Token: 0x040141EB RID: 82411
		ReactionChange8,
		// Token: 0x040141EC RID: 82412
		ReactionChange9,
		// Token: 0x040141ED RID: 82413
		ReactionChange10,
		// Token: 0x040141EE RID: 82414
		ReactionChange11,
		// Token: 0x040141EF RID: 82415
		ReactionChange12,
		// Token: 0x040141F0 RID: 82416
		ReactionChange13,
		// Token: 0x040141F1 RID: 82417
		ReactionChange14,
		// Token: 0x040141F2 RID: 82418
		ReactionChange15,
		// Token: 0x040141F3 RID: 82419
		EnergyMax,
		// Token: 0x040141F4 RID: 82420
		Energy,
		// Token: 0x040141F5 RID: 82421
		SpecialEnergy1Max,
		// Token: 0x040141F6 RID: 82422
		SpecialEnergy1,
		// Token: 0x040141F7 RID: 82423
		SpecialEnergy2Max,
		// Token: 0x040141F8 RID: 82424
		SpecialEnergy2,
		// Token: 0x040141F9 RID: 82425
		SpecialEnergy3Max,
		// Token: 0x040141FA RID: 82426
		SpecialEnergy3,
		// Token: 0x040141FB RID: 82427
		SpecialEnergy4Max,
		// Token: 0x040141FC RID: 82428
		SpecialEnergy4,
		// Token: 0x040141FD RID: 82429
		StrengthMax,
		// Token: 0x040141FE RID: 82430
		Strength,
		// Token: 0x040141FF RID: 82431
		StrengthRecover,
		// Token: 0x04014200 RID: 82432
		StrengthPunishTime,
		// Token: 0x04014201 RID: 82433
		StrengthRun,
		// Token: 0x04014202 RID: 82434
		StrengthSwim,
		// Token: 0x04014203 RID: 82435
		StrengthFastSwim,
		// Token: 0x04014204 RID: 82436
		StrengthClimb,
		// Token: 0x04014205 RID: 82437
		StrengthFastClimb,
		// Token: 0x04014206 RID: 82438
		HardnessMax,
		// Token: 0x04014207 RID: 82439
		Hardness,
		// Token: 0x04014208 RID: 82440
		HardnessRecover,
		// Token: 0x04014209 RID: 82441
		HardnessPunishTime,
		// Token: 0x0401420A RID: 82442
		HardnessChange,
		// Token: 0x0401420B RID: 82443
		HardnessReduce,
		// Token: 0x0401420C RID: 82444
		ToughMax,
		// Token: 0x0401420D RID: 82445
		Tough,
		// Token: 0x0401420E RID: 82446
		ToughRecover,
		// Token: 0x0401420F RID: 82447
		ToughChange,
		// Token: 0x04014210 RID: 82448
		ToughReduce,
		// Token: 0x04014211 RID: 82449
		ElementPower1,
		// Token: 0x04014212 RID: 82450
		ElementPower2,
		// Token: 0x04014213 RID: 82451
		ElementPower3,
		// Token: 0x04014214 RID: 82452
		ElementPower4,
		// Token: 0x04014215 RID: 82453
		ElementPower5,
		// Token: 0x04014216 RID: 82454
		ElementPower6,
		// Token: 0x04014217 RID: 82455
		SpecialDamageChange,
		// Token: 0x04014218 RID: 82456
		StrengthFastClimbCost,
		// Token: 0x04014219 RID: 82457
		ElementPropertyType,
		// Token: 0x0401421A RID: 82458
		WeakTime,
		// Token: 0x0401421B RID: 82459
		IgnoreDefRate,
		// Token: 0x0401421C RID: 82460
		IgnoreDamageResistancePhys,
		// Token: 0x0401421D RID: 82461
		IgnoreDamageResistanceElement1,
		// Token: 0x0401421E RID: 82462
		IgnoreDamageResistanceElement2,
		// Token: 0x0401421F RID: 82463
		IgnoreDamageResistanceElement3,
		// Token: 0x04014220 RID: 82464
		IgnoreDamageResistanceElement4,
		// Token: 0x04014221 RID: 82465
		IgnoreDamageResistanceElement5,
		// Token: 0x04014222 RID: 82466
		IgnoreDamageResistanceElement6,
		// Token: 0x04014223 RID: 82467
		SkillToughRatio,
		// Token: 0x04014224 RID: 82468
		StrengthClimbJump,
		// Token: 0x04014225 RID: 82469
		StrengthGliding,
		// Token: 0x04014226 RID: 82470
		Mass,
		// Token: 0x04014227 RID: 82471
		BrakingFrictionFactor,
		// Token: 0x04014228 RID: 82472
		GravityScale,
		// Token: 0x04014229 RID: 82473
		SpeedRatio,
		// Token: 0x0401422A RID: 82474
		DamageChangePhantom,
		// Token: 0x0401422B RID: 82475
		AutoAttackSpeed,
		// Token: 0x0401422C RID: 82476
		CastAttackSpeed,
		// Token: 0x0401422D RID: 82477
		StatusBuildUp1Max,
		// Token: 0x0401422E RID: 82478
		StatusBuildUp1,
		// Token: 0x0401422F RID: 82479
		StatusBuildUp2Max,
		// Token: 0x04014230 RID: 82480
		StatusBuildUp2,
		// Token: 0x04014231 RID: 82481
		StatusBuildUp3Max,
		// Token: 0x04014232 RID: 82482
		StatusBuildUp3,
		// Token: 0x04014233 RID: 82483
		StatusBuildUp4Max,
		// Token: 0x04014234 RID: 82484
		StatusBuildUp4,
		// Token: 0x04014235 RID: 82485
		StatusBuildUp5Max,
		// Token: 0x04014236 RID: 82486
		StatusBuildUp5,
		// Token: 0x04014237 RID: 82487
		RageMax,
		// Token: 0x04014238 RID: 82488
		Rage,
		// Token: 0x04014239 RID: 82489
		RageRecover,
		// Token: 0x0401423A RID: 82490
		RagePunishTime,
		// Token: 0x0401423B RID: 82491
		RageChange,
		// Token: 0x0401423C RID: 82492
		RageReduce,
		// Token: 0x0401423D RID: 82493
		ToughRecoverDelayTime,
		// Token: 0x0401423E RID: 82494
		Jump,
		// Token: 0x0401423F RID: 82495
		ParalysisTimeMax,
		// Token: 0x04014240 RID: 82496
		ParalysisTime,
		// Token: 0x04014241 RID: 82497
		ParalysisTimeRecover,
		// Token: 0x04014242 RID: 82498
		WeaknessBuildUp,
		// Token: 0x04014243 RID: 82499
		WeaknessBuildUpMax,
		// Token: 0x04014244 RID: 82500
		WeaknessTotalBonus,
		// Token: 0x04014245 RID: 82501
		BreakWeaknessRatio,
		// Token: 0x04014246 RID: 82502
		WeaknessMastery,
		// Token: 0x04014247 RID: 82503
		EAttributeType_MAX
	}
}
