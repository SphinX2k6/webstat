using System;

// Token: 0x02002EF1 RID: 12017
public enum EExtraEffectId
{
	// Token: 0x0400BF5B RID: 48987
	ModifySnapshotBeforeCalculation = 1,
	// Token: 0x0400BF5C RID: 48988
	AddBuff,
	// Token: 0x0400BF5D RID: 48989
	AddBullet,
	// Token: 0x0400BF5E RID: 48990
	ModifyLife,
	// Token: 0x0400BF5F RID: 48991
	PeriodicExtraEffect,
	// Token: 0x0400BF60 RID: 48992
	AttributeEventEffect,
	// Token: 0x0400BF61 RID: 48993
	SkillLimitCount,
	// Token: 0x0400BF62 RID: 48994
	LevelBuff,
	// Token: 0x0400BF63 RID: 48995
	DamageAugment,
	// Token: 0x0400BF64 RID: 48996
	Control,
	// Token: 0x0400BF65 RID: 48997
	ApplyShield,
	// Token: 0x0400BF66 RID: 48998
	DamageModify,
	// Token: 0x0400BF67 RID: 48999
	ReduceCd,
	// Token: 0x0400BF68 RID: 49000
	LockValue,
	// Token: 0x0400BF69 RID: 49001
	LockUpperBound,
	// Token: 0x0400BF6A RID: 49002
	LockLowerBound,
	// Token: 0x0400BF6B RID: 49003
	SetTimeScale,
	// Token: 0x0400BF6C RID: 49004
	ShareDamage,
	// Token: 0x0400BF6D RID: 49005
	DamageAccumulation,
	// Token: 0x0400BF6E RID: 49006
	DamageImmune,
	// Token: 0x0400BF6F RID: 49007
	RemoveBuff,
	// Token: 0x0400BF70 RID: 49008
	DamageFilter,
	// Token: 0x0400BF71 RID: 49009
	AddBuffToAdjacentRole = 24,
	// Token: 0x0400BF72 RID: 49010
	AddBuffOnChangeTeam,
	// Token: 0x0400BF73 RID: 49011
	ExtendBuffDuration,
	// Token: 0x0400BF74 RID: 49012
	ReplaceSnapshotBeforeCalculation,
	// Token: 0x0400BF75 RID: 49013
	AddBuffInstantByStackCount,
	// Token: 0x0400BF76 RID: 49014
	AddBulletInstantByStackCount,
	// Token: 0x0400BF77 RID: 49015
	PhantomAssist,
	// Token: 0x0400BF78 RID: 49016
	SetFormationAttributeRate,
	// Token: 0x0400BF79 RID: 49017
	ModifyFormationAttributeIncreaseRate,
	// Token: 0x0400BF7A RID: 49018
	ModifyFormationAttributeDecreaseRate,
	// Token: 0x0400BF7B RID: 49019
	ModifyFormationAttribute,
	// Token: 0x0400BF7C RID: 49020
	AddPassiveSkill,
	// Token: 0x0400BF7D RID: 49021
	Frozen,
	// Token: 0x0400BF7E RID: 49022
	DamageAmplifyOnHit,
	// Token: 0x0400BF7F RID: 49023
	DamageAmplifyOnBeHit,
	// Token: 0x0400BF80 RID: 49024
	AddBuffToVision = 41,
	// Token: 0x0400BF81 RID: 49025
	RemoveSelfByTag = 43,
	// Token: 0x0400BF82 RID: 49026
	ModifyToughReduce,
	// Token: 0x0400BF83 RID: 49027
	ShieldCovertAttribute,
	// Token: 0x0400BF84 RID: 49028
	ShieldModifySnapshot,
	// Token: 0x0400BF85 RID: 49029
	ModifyCd = 49,
	// Token: 0x0400BF86 RID: 49030
	FormationLockUpperBound,
	// Token: 0x0400BF87 RID: 49031
	FormationLockLowerBound,
	// Token: 0x0400BF88 RID: 49032
	QteExecution,
	// Token: 0x0400BF89 RID: 49033
	BindBuffToTeam,
	// Token: 0x0400BF8A RID: 49034
	AttributeConvert = 55,
	// Token: 0x0400BF8B RID: 49035
	GetBuffByStackCountOnRemoved = 57,
	// Token: 0x0400BF8C RID: 49036
	PeriodAddBuffToAdjacentEntity,
	// Token: 0x0400BF8D RID: 49037
	DestroyBullet,
	// Token: 0x0400BF8E RID: 49038
	ModifyBuffDurationOrPeriod,
	// Token: 0x0400BF8F RID: 49039
	ModifyFormationAttributeMax = 62,
	// Token: 0x0400BF90 RID: 49040
	ModifyDamageElement,
	// Token: 0x0400BF91 RID: 49041
	ConvertBuffToAnother = 65,
	// Token: 0x0400BF92 RID: 49042
	InvokePeriod = 67,
	// Token: 0x0400BF93 RID: 49043
	ModifyBuffDurationOrPeriodByInstigator,
	// Token: 0x0400BF94 RID: 49044
	StartBattleQte,
	// Token: 0x0400BF95 RID: 49045
	ModifyBuffStack,
	// Token: 0x0400BF96 RID: 49046
	AddSkillLimitCount,
	// Token: 0x0400BF97 RID: 49047
	AdditionBulletSize,
	// Token: 0x0400BF98 RID: 49048
	AdditionBulletDuration,
	// Token: 0x0400BF99 RID: 49049
	AdditionBulletInterval,
	// Token: 0x0400BF9A RID: 49050
	AddBulletInstantByTagStackCount,
	// Token: 0x0400BF9B RID: 49051
	AddBattleFlag,
	// Token: 0x0400BF9C RID: 49052
	DamageTransferRecipients,
	// Token: 0x0400BF9D RID: 49053
	ChangeBuffStackCount = 79,
	// Token: 0x0400BF9E RID: 49054
	BuffCopy,
	// Token: 0x0400BF9F RID: 49055
	BuffOverStackCompensation,
	// Token: 0x0400BFA0 RID: 49056
	BuffTransfer,
	// Token: 0x0400BFA1 RID: 49057
	SetForeverTimeScale,
	// Token: 0x0400BFA2 RID: 49058
	[Obsolete]
	ModifyFuLuoLuoSpecialEnergy,
	// Token: 0x0400BFA3 RID: 49059
	SyncTimeScaleEffect,
	// Token: 0x0400BFA4 RID: 49060
	SpecialEnergyModifier = 87,
	// Token: 0x0400BFA5 RID: 49061
	ModifySlotSpecialEnergy,
	// Token: 0x0400BFA6 RID: 49062
	SyncGameplayCue,
	// Token: 0x0400BFA7 RID: 49063
	ModifyTeamMemberBuff,
	// Token: 0x0400BFA8 RID: 49064
	BindBuffToVehicle,
	// Token: 0x0400BFA9 RID: 49065
	AddSkillLevel = 93,
	// Token: 0x0400BFAA RID: 49066
	ReviveExecution = 101,
	// Token: 0x0400BFAB RID: 49067
	AddEnergy,
	// Token: 0x0400BFAC RID: 49068
	ModifyBuffTimeScale,
	// Token: 0x0400BFAD RID: 49069
	RemoveBuffByFilter,
	// Token: 0x0400BFAE RID: 49070
	BuffMapper = 106,
	// Token: 0x0400BFAF RID: 49071
	DynamicModifyBuffStack = 108,
	// Token: 0x0400BFB0 RID: 49072
	AdjacentBuffStackToEffect = 123,
	// Token: 0x0400BFB1 RID: 49073
	ReplaceBuffOnAdd = 129,
	// Token: 0x0400BFB2 RID: 49074
	SyncMaxStackFromAnotherBuff,
	// Token: 0x0400BFB3 RID: 49075
	ReplaceAbnormalCue,
	// Token: 0x0400BFB4 RID: 49076
	AbnormalWind = 1001,
	// Token: 0x0400BFB5 RID: 49077
	AbnormalThunder,
	// Token: 0x0400BFB6 RID: 49078
	AbnormalIce,
	// Token: 0x0400BFB7 RID: 49079
	AbnormalFire,
	// Token: 0x0400BFB8 RID: 49080
	AbnormalLight,
	// Token: 0x0400BFB9 RID: 49081
	AbnormalDark,
	// Token: 0x0400BFBA RID: 49082
	PreventReduceStack = 1101,
	// Token: 0x0400BFBB RID: 49083
	ConvertAbnormalLight
}
