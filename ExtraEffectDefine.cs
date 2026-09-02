using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect;

// Token: 0x02002F24 RID: 12068
[NullableContext(2)]
[Nullable(0)]
public static class ExtraEffectDefine
{
	// Token: 0x06018B6E RID: 101230 RVA: 0x006FAB34 File Offset: 0x006F8D34
	public static Type GetBuffEffectClass(EExtraEffectId effectId)
	{
		if (effectId <= EExtraEffectId.ReplaceAbnormalCue)
		{
			switch (effectId)
			{
			case EExtraEffectId.ModifySnapshotBeforeCalculation:
				return typeof(CommonSnapshotModify);
			case EExtraEffectId.AddBuff:
				return typeof(AddBuffTrigger);
			case EExtraEffectId.AddBullet:
				return typeof(AddBulletTrigger);
			case EExtraEffectId.ModifyLife:
			case EExtraEffectId.PeriodicExtraEffect:
			case EExtraEffectId.ReduceCd:
			case (EExtraEffectId)23:
			case EExtraEffectId.AddBuffToAdjacentRole:
			case EExtraEffectId.ExtendBuffDuration:
			case EExtraEffectId.AddBuffInstantByStackCount:
			case EExtraEffectId.AddBulletInstantByStackCount:
			case EExtraEffectId.PhantomAssist:
			case EExtraEffectId.ModifyFormationAttribute:
			case (EExtraEffectId)39:
			case (EExtraEffectId)40:
			case (EExtraEffectId)42:
			case EExtraEffectId.RemoveSelfByTag:
			case (EExtraEffectId)47:
			case (EExtraEffectId)48:
			case EExtraEffectId.QteExecution:
			case (EExtraEffectId)54:
			case (EExtraEffectId)56:
			case EExtraEffectId.GetBuffByStackCountOnRemoved:
			case EExtraEffectId.PeriodAddBuffToAdjacentEntity:
			case (EExtraEffectId)61:
			case (EExtraEffectId)64:
			case EExtraEffectId.ConvertBuffToAnother:
			case (EExtraEffectId)66:
			case EExtraEffectId.InvokePeriod:
			case EExtraEffectId.StartBattleQte:
			case EExtraEffectId.AddBulletInstantByTagStackCount:
			case (EExtraEffectId)78:
			case EExtraEffectId.ChangeBuffStackCount:
			case EExtraEffectId.ModifyFuLuoLuoSpecialEnergy:
			case (EExtraEffectId)86:
			case EExtraEffectId.ModifySlotSpecialEnergy:
			case EExtraEffectId.ModifyTeamMemberBuff:
			case (EExtraEffectId)92:
			case (EExtraEffectId)94:
			case (EExtraEffectId)95:
			case (EExtraEffectId)96:
			case (EExtraEffectId)97:
			case (EExtraEffectId)98:
			case (EExtraEffectId)99:
			case (EExtraEffectId)100:
			case EExtraEffectId.ReviveExecution:
			case EExtraEffectId.AddEnergy:
			case EExtraEffectId.RemoveBuffByFilter:
			case (EExtraEffectId)105:
			case EExtraEffectId.BuffMapper:
			case (EExtraEffectId)107:
				break;
			case EExtraEffectId.AttributeEventEffect:
				return typeof(AttributeEventEffects);
			case EExtraEffectId.SkillLimitCount:
				return typeof(ExtraEffectSkillLimitCount);
			case EExtraEffectId.LevelBuff:
				return typeof(ExtraEffectLevelBuff);
			case EExtraEffectId.DamageAugment:
				return typeof(ExtraEffectDamageAugment);
			case EExtraEffectId.Control:
				return typeof(ExtraEffectBehaviorControl);
			case EExtraEffectId.ApplyShield:
				return typeof(ShieldEffect);
			case EExtraEffectId.DamageModify:
				return typeof(DamageModifier);
			case EExtraEffectId.LockValue:
				return typeof(LockValue);
			case EExtraEffectId.LockUpperBound:
				return typeof(LockUpperBound);
			case EExtraEffectId.LockLowerBound:
				return typeof(LockLowerBound);
			case EExtraEffectId.SetTimeScale:
				return typeof(TimeScaleEffect);
			case EExtraEffectId.ShareDamage:
				return typeof(DamageShare);
			case EExtraEffectId.DamageAccumulation:
				return typeof(ExtraEffectDamageAccumulation);
			case EExtraEffectId.DamageImmune:
				return typeof(ExtraEffectDamageImmune);
			case EExtraEffectId.RemoveBuff:
				return typeof(RemoveBuff);
			case EExtraEffectId.DamageFilter:
				return typeof(DamageFilter);
			case EExtraEffectId.AddBuffOnChangeTeam:
				return typeof(AddBuffOnChangeTeam);
			case EExtraEffectId.ReplaceSnapshotBeforeCalculation:
				return typeof(SnapReplacer);
			case EExtraEffectId.SetFormationAttributeRate:
				return typeof(SetFormationAttributeRate);
			case EExtraEffectId.ModifyFormationAttributeIncreaseRate:
				return typeof(ModifyFormationAttributeIncreaseRate);
			case EExtraEffectId.ModifyFormationAttributeDecreaseRate:
				return typeof(ModifyFormationAttributeDecreaseRate);
			case EExtraEffectId.AddPassiveSkill:
				return typeof(AddPassiveSkill);
			case EExtraEffectId.Frozen:
				return typeof(FrozenEffect);
			case EExtraEffectId.DamageAmplifyOnHit:
				return typeof(DamageAmplifyOnHit);
			case EExtraEffectId.DamageAmplifyOnBeHit:
				return typeof(DamageAmplifyOnBeHit);
			case EExtraEffectId.AddBuffToVision:
				return typeof(AddBuffToVision);
			case EExtraEffectId.ModifyToughReduce:
				return typeof(ModifyToughReduce);
			case EExtraEffectId.ShieldCovertAttribute:
				return typeof(ConvertShieldAttribute);
			case EExtraEffectId.ShieldModifySnapshot:
				return typeof(ShieldSnapshotModify);
			case EExtraEffectId.ModifyCd:
				return typeof(ModifyCd);
			case EExtraEffectId.FormationLockUpperBound:
				return typeof(FormationLockUpperBound);
			case EExtraEffectId.FormationLockLowerBound:
				return typeof(FormationLockLowerBound);
			case EExtraEffectId.BindBuffToTeam:
				return typeof(BindBuffToTeam);
			case EExtraEffectId.AttributeConvert:
				return typeof(AttributeConvert);
			case EExtraEffectId.DestroyBullet:
				return typeof(ExtraEffectDestroyBullet);
			case EExtraEffectId.ModifyBuffDurationOrPeriod:
				return typeof(ModifyBuffDurationOrPeriod);
			case EExtraEffectId.ModifyFormationAttributeMax:
				return typeof(ModifyFormationAttributeMax);
			case EExtraEffectId.ModifyDamageElement:
				return typeof(ModifyDamageElement);
			case EExtraEffectId.ModifyBuffDurationOrPeriodByInstigator:
				return typeof(ModifyBuffDurationOrPeriodByInstigator);
			case EExtraEffectId.ModifyBuffStack:
				return typeof(ExtraEffectModifyBuffMaxStack);
			case EExtraEffectId.AddSkillLimitCount:
				return typeof(ExtraEffectAddSkillLimitCount);
			case EExtraEffectId.AdditionBulletSize:
				return typeof(AdditionBulletSize);
			case EExtraEffectId.AdditionBulletDuration:
				return typeof(AdditionBulletDuration);
			case EExtraEffectId.AdditionBulletInterval:
				return typeof(AdditionBulletInterval);
			case EExtraEffectId.AddBattleFlag:
				return typeof(AddBattleFlag);
			case EExtraEffectId.DamageTransferRecipients:
				return typeof(DamageTransferRecipients);
			case EExtraEffectId.BuffCopy:
				return typeof(ExtraEffectBuffCopy);
			case EExtraEffectId.BuffOverStackCompensation:
				return typeof(BuffOverStackCompensation);
			case EExtraEffectId.BuffTransfer:
				return typeof(ExtraEffectBuffTransfer);
			case EExtraEffectId.SetForeverTimeScale:
				return typeof(ForeverTimeScaleEffect);
			case EExtraEffectId.SyncTimeScaleEffect:
				return typeof(SyncTimeScaleEffect);
			case EExtraEffectId.SpecialEnergyModifier:
				return typeof(SpecialEnergyModifier);
			case EExtraEffectId.SyncGameplayCue:
				return typeof(SyncGameplayCue);
			case EExtraEffectId.BindBuffToVehicle:
				return typeof(BindBuffToVehicleEffect);
			case EExtraEffectId.AddSkillLevel:
				return typeof(AddSkillLevelEffect);
			case EExtraEffectId.ModifyBuffTimeScale:
				return typeof(ModifyBuffTimeScale);
			case EExtraEffectId.DynamicModifyBuffStack:
				return typeof(DynamicModifyBuffStackEffect);
			default:
				switch (effectId)
				{
				case EExtraEffectId.ReplaceBuffOnAdd:
					return typeof(ReplaceBuffOnAddEffect);
				case EExtraEffectId.SyncMaxStackFromAnotherBuff:
					return typeof(SyncMaxStackFromAnotherBuffEffect);
				case EExtraEffectId.ReplaceAbnormalCue:
					return typeof(ReplaceAbnormalCueEffect);
				}
				break;
			}
		}
		else
		{
			switch (effectId)
			{
			case EExtraEffectId.AbnormalIce:
				return typeof(AbnormalIce);
			case EExtraEffectId.AbnormalFire:
				return typeof(AbnormalFire);
			case EExtraEffectId.AbnormalLight:
				break;
			case EExtraEffectId.AbnormalDark:
				return typeof(AbnormalDark);
			default:
				if (effectId == EExtraEffectId.PreventReduceStack)
				{
					return typeof(PreventReduceStack);
				}
				break;
			}
		}
		return null;
	}

	// Token: 0x06018B6F RID: 101231 RVA: 0x006FB164 File Offset: 0x006F9364
	public static Type GetBuffExecutionClass(EExtraEffectId effectId)
	{
		if (effectId <= EExtraEffectId.AddBulletInstantByTagStackCount)
		{
			if (effectId <= EExtraEffectId.ModifyFormationAttribute)
			{
				if (effectId <= EExtraEffectId.PeriodicExtraEffect)
				{
					if (effectId == EExtraEffectId.ModifyLife)
					{
						return typeof(DamageExecution);
					}
					if (effectId == EExtraEffectId.PeriodicExtraEffect)
					{
						return typeof(ExecuteBulletOrBuff);
					}
				}
				else
				{
					if (effectId == EExtraEffectId.ReduceCd)
					{
						return typeof(CdReduceExecution);
					}
					switch (effectId)
					{
					case EExtraEffectId.AddBuffToAdjacentRole:
						return typeof(AddBuffToAdjacentRoleExecution);
					case EExtraEffectId.ExtendBuffDuration:
						return typeof(ExtendBuffDurationExecution);
					case EExtraEffectId.AddBuffInstantByStackCount:
						return typeof(ExecuteAddBuffByStackCount);
					case EExtraEffectId.AddBulletInstantByStackCount:
						return typeof(ExecuteAddBulletByStackCount);
					case EExtraEffectId.PhantomAssist:
						return typeof(PhantomAssistExecution);
					case EExtraEffectId.ModifyFormationAttribute:
						return typeof(ModifyFormationAttributeExecution);
					}
				}
			}
			else if (effectId <= EExtraEffectId.PeriodAddBuffToAdjacentEntity)
			{
				if (effectId == EExtraEffectId.QteExecution)
				{
					return typeof(QteExecution);
				}
				if (effectId == EExtraEffectId.PeriodAddBuffToAdjacentEntity)
				{
					return typeof(PeriodAddBuffToAdjacentEntity);
				}
			}
			else
			{
				switch (effectId)
				{
				case EExtraEffectId.ConvertBuffToAnother:
					return typeof(ConvertBuffToAnother);
				case (EExtraEffectId)66:
				case EExtraEffectId.ModifyBuffDurationOrPeriodByInstigator:
					break;
				case EExtraEffectId.InvokePeriod:
					return typeof(InvokePeriod);
				case EExtraEffectId.StartBattleQte:
					return typeof(StartBattleQte);
				default:
					if (effectId == EExtraEffectId.AddBulletInstantByTagStackCount)
					{
						return typeof(ExecuteAddBulletByTagStackCount);
					}
					break;
				}
			}
		}
		else if (effectId <= EExtraEffectId.ModifyTeamMemberBuff)
		{
			if (effectId <= EExtraEffectId.ModifyFuLuoLuoSpecialEnergy)
			{
				if (effectId == EExtraEffectId.ChangeBuffStackCount)
				{
					return typeof(ChangeBuffStackCount);
				}
				if (effectId == EExtraEffectId.ModifyFuLuoLuoSpecialEnergy)
				{
					return typeof(ModifyFuLuoLuoSpecialEnergy);
				}
			}
			else
			{
				if (effectId == EExtraEffectId.ModifySlotSpecialEnergy)
				{
					return typeof(ModifySlotSpecialEnergy);
				}
				if (effectId == EExtraEffectId.ModifyTeamMemberBuff)
				{
					return typeof(ModifyTeamMemberBuff);
				}
			}
		}
		else if (effectId <= EExtraEffectId.AdjacentBuffStackToEffect)
		{
			switch (effectId)
			{
			case EExtraEffectId.ReviveExecution:
				return typeof(ReviveExecution);
			case EExtraEffectId.AddEnergy:
				return typeof(AddEnergyExecution);
			case EExtraEffectId.ModifyBuffTimeScale:
			case (EExtraEffectId)105:
				break;
			case EExtraEffectId.RemoveBuffByFilter:
				return typeof(RemoveBuffByFilter);
			case EExtraEffectId.BuffMapper:
				return typeof(BuffMapper);
			default:
				if (effectId == EExtraEffectId.AdjacentBuffStackToEffect)
				{
					return typeof(AdjacentBuffStackToEffect);
				}
				break;
			}
		}
		else
		{
			switch (effectId)
			{
			case EExtraEffectId.AbnormalWind:
				return typeof(AbnormalWind);
			case EExtraEffectId.AbnormalThunder:
				return typeof(AbnormalThunder);
			case EExtraEffectId.AbnormalIce:
			case EExtraEffectId.AbnormalFire:
				break;
			case EExtraEffectId.AbnormalLight:
				return typeof(AbnormalLight);
			default:
				if (effectId == EExtraEffectId.ConvertAbnormalLight)
				{
					return typeof(ConvertAbnormalLight);
				}
				break;
			}
		}
		return null;
	}
}
