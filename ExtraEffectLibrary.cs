using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002F2F RID: 12079
public class ExtraEffectLibrary
{
	// Token: 0x0400C09B RID: 49307
	private const float ADD_BULLET_MIN_INTERVAL = 0.5f;

	// Token: 0x0200932C RID: 37676
	public class BuffExtraEffectLibrary
	{
		// Token: 0x0604A056 RID: 303190 RVA: 0x0140E094 File Offset: 0x0140C294
		[NullableContext(1)]
		public unsafe static RequireAndLimits ResolveRequireAndLimits(long buffId, ExtraEffectParameters parameters, int level)
		{
			RequireAndLimits requireAndLimits = new RequireAndLimits();
			requireAndLimits.CheckType = (ERequirementsCheckType)parameters.ExtraEffectRequirementSetting;
			List<IRequirement> list = new List<IRequirement>();
			int[] extraEffectRequirement = parameters.ExtraEffectRequirement;
			string[] extraEffectRequirementPara = parameters.ExtraEffectRequirementPara;
			if (extraEffectRequirement != null && extraEffectRequirementPara != null)
			{
				int num = (extraEffectRequirement.Length < extraEffectRequirementPara.Length) ? extraEffectRequirement.Length : extraEffectRequirementPara.Length;
				for (int i = 0; i < num; i++)
				{
					EExtraEffectRequire eextraEffectRequire = (EExtraEffectRequire)extraEffectRequirement[i];
					string[] array = extraEffectRequirementPara[i].Split('#', StringSplitOptions.None);
					switch (eextraEffectRequire)
					{
					case EExtraEffectRequire.SpecifiedSkillId:
					{
						long[] array2 = new long[array.Length];
						for (int j = 0; j < array.Length; j++)
						{
							array2[j] = long.Parse(array[j]);
						}
						RequirementSkillId item = new RequirementSkillId
						{
							SkillIds = array2
						};
						list.Add(item);
						break;
					}
					case EExtraEffectRequire.SpecifiedSkillGenre:
					{
						int[] array3 = new int[array.Length];
						for (int k = 0; k < array.Length; k++)
						{
							array3[k] = int.Parse(array[k]);
						}
						RequirementSkillGenre item2 = new RequirementSkillGenre
						{
							SkillGenres = array3
						};
						list.Add(item2);
						break;
					}
					case EExtraEffectRequire.SpecifiedLifeInterval:
						if (array.Length >= 5)
						{
							string a = array[0];
							int listenId = int.Parse(array[1]);
							int num2 = int.Parse(array[2]);
							float lowerBound = float.Parse(array[3]);
							float upperBound = float.Parse(array[4]);
							RequirementAttributeInterval item3 = new RequirementAttributeInterval
							{
								RequireTargetType = ((a == "0") ? ERequirementTargetType.Self : ERequirementTargetType.Target),
								RequireInterval = new AttributeIntervalCheck((EAttributeType)listenId, lowerBound, upperBound, num2 == 1)
							};
							list.Add(item3);
						}
						break;
					case EExtraEffectRequire.SpecifiedSmashType:
					{
						int[] array4 = new int[array.Length];
						for (int l = 0; l < array.Length; l++)
						{
							array4[l] = int.Parse(array[l]);
						}
						RequirementSmashType item4 = new RequirementSmashType
						{
							SmashTypes = array4
						};
						list.Add(item4);
						break;
					}
					case EExtraEffectRequire.SpecifiedBulletId:
					{
						long[] array5 = new long[array.Length];
						for (int m = 0; m < array.Length; m++)
						{
							array5[m] = long.Parse(array[m]);
						}
						RequirementBulletId item5 = new RequirementBulletId
						{
							BulletIds = array5
						};
						list.Add(item5);
						break;
					}
					case EExtraEffectRequire.ShouldCritical:
						if (array.Length >= 1)
						{
							RequirementCritical item6 = new RequirementCritical
							{
								IsCritical = (array[0] == "1")
							};
							list.Add(item6);
						}
						break;
					case EExtraEffectRequire.SpecifiedElementType:
					{
						EElementType[] array6 = new EElementType[array.Length];
						for (int n = 0; n < array.Length; n++)
						{
							array6[n] = (EElementType)int.Parse(array[n]);
						}
						RequirementElementType item7 = new RequirementElementType
						{
							ElementTypes = array6
						};
						list.Add(item7);
						break;
					}
					case EExtraEffectRequire.SpecifiedWeaponType:
					{
						int[] array7 = new int[array.Length];
						for (int num3 = 0; num3 < array.Length; num3++)
						{
							array7[num3] = int.Parse(array[num3]);
						}
						RequirementWeaponType item8 = new RequirementWeaponType
						{
							WeaponTypes = array7
						};
						list.Add(item8);
						break;
					}
					case EExtraEffectRequire.SpecifiedTagExistence:
						if (array.Length >= 2)
						{
							List<int> list2 = new List<int>();
							for (int num4 = 2; num4 < array.Length; num4++)
							{
								list2.Add(GameplayTagUtils.GetTagIdByName(array[num4]));
							}
							RequirementTagExistence item9 = new RequirementTagExistence
							{
								RequireTargetType = (ERequirementTargetType)int.Parse(array[0]),
								IsExist = (array[1] == "1"),
								RequireTagContainer = list2.ToArray()
							};
							list.Add(item9);
						}
						break;
					case EExtraEffectRequire.SpecifiedPartTag:
					{
						int[] array8 = new int[array.Length];
						for (int num5 = 0; num5 < array.Length; num5++)
						{
							array8[num5] = GameplayTagUtils.GetTagIdByName(array[num5]);
						}
						RequirementPartTag item10 = new RequirementPartTag
						{
							RequirePartTags = array8
						};
						list.Add(item10);
						break;
					}
					case EExtraEffectRequire.SpecifiedBulletTag:
					{
						int[] array9 = new int[array.Length];
						for (int num6 = 0; num6 < array.Length; num6++)
						{
							array9[num6] = GameplayTagUtils.GetTagIdByName(array[num6]);
						}
						RequirementBulletTag item11 = new RequirementBulletTag
						{
							RequireBulletTags = array9
						};
						list.Add(item11);
						break;
					}
					case EExtraEffectRequire.SpecifiedDamageGenre:
					{
						int[] array10 = new int[array.Length];
						for (int num7 = 0; num7 < array.Length; num7++)
						{
							array10[num7] = int.Parse(array[num7]);
						}
						RequirementDamageGenre item12 = new RequirementDamageGenre
						{
							DamageTypes = array10
						};
						list.Add(item12);
						break;
					}
					case EExtraEffectRequire.MonsterGenre:
						if (array.Length >= 1)
						{
							int[] array11 = new int[array.Length - 1];
							for (int num8 = 1; num8 < array.Length; num8++)
							{
								array11[num8 - 1] = int.Parse(array[num8]);
							}
							RequirementMonsterGenre item13 = new RequirementMonsterGenre
							{
								RequireTargetType = (ERequirementTargetType)int.Parse(array[0]),
								MonsterGenres = array11
							};
							list.Add(item13);
						}
						break;
					case EExtraEffectRequire.BuffStackCount:
						if (array.Length >= 4)
						{
							RequirementBuffStackCount item14 = new RequirementBuffStackCount
							{
								BuffId = long.Parse(array[0]),
								RequireTargetType = (ERequirementTargetType)int.Parse(array[1]),
								MinStack = int.Parse(array[2]),
								MaxStack = int.Parse(array[3])
							};
							list.Add(item14);
						}
						break;
					case EExtraEffectRequire.SpecifiedFollowTagExistence:
						if (array.Length >= 4)
						{
							List<int> list3 = new List<int>();
							for (int num9 = 4; num9 < array.Length; num9++)
							{
								list3.Add(GameplayTagUtils.GetTagIdByName(array[num9]));
							}
							RequirementFollowTagExistence item15 = new RequirementFollowTagExistence
							{
								RequireTargetType = (ERequirementTargetType)int.Parse(array[0]),
								SummonType = (ESummonType)int.Parse(array[1]),
								SummonIndex = int.Parse(array[2]),
								IsExist = (array[3] == "1"),
								RequireTagContainer = list3.ToArray()
							};
							list.Add(item15);
						}
						break;
					case EExtraEffectRequire.CalculateType:
					{
						ECalculationType[] array12 = new ECalculationType[array.Length];
						for (int num10 = 0; num10 < array.Length; num10++)
						{
							array12[num10] = (ECalculationType)int.Parse(array[num10]);
						}
						RequirementCalculationType item16 = new RequirementCalculationType
						{
							CalculationTypes = array12
						};
						list.Add(item16);
						break;
					}
					case EExtraEffectRequire.DamageSubType:
						if (array.Length >= 1)
						{
							int[] array13 = new int[array.Length - 1];
							for (int num11 = 1; num11 < array.Length; num11++)
							{
								array13[num11 - 1] = int.Parse(array[num11]);
							}
							RequirementDamageSubType item17 = new RequirementDamageSubType
							{
								IncludeType = (ERequirementsIncludeType)int.Parse(array[0]),
								DamageSubTypes = array13
							};
							list.Add(item17);
						}
						break;
					case EExtraEffectRequire.BattleFlags:
					{
						string[] array14 = new string[array.Length];
						for (int num12 = 0; num12 < array.Length; num12++)
						{
							array14[num12] = array[num12];
						}
						RequirementBattleFlags item18 = new RequirementBattleFlags
						{
							BattleFlags = array14
						};
						list.Add(item18);
						break;
					}
					case EExtraEffectRequire.DamageSourceType:
						if (array.Length >= 1)
						{
							DamageSourceType[] array15 = new DamageSourceType[array.Length - 1];
							for (int num13 = 1; num13 < array.Length; num13++)
							{
								array15[num13 - 1] = (DamageSourceType)int.Parse(array[num13]);
							}
							RequirementDamageSourceType item19 = new RequirementDamageSourceType
							{
								CheckInclude = (int.Parse(array[0]) == 0),
								DamageSourceTypes = array15
							};
							list.Add(item19);
						}
						break;
					case EExtraEffectRequire.ChangeWeaknessType:
					{
						RequirementChangeWeaknessType item20 = new RequirementChangeWeaknessType
						{
							ChangeWeaknessType = (EChangeWeaknessType)((array.Length != 0) ? int.Parse(array[0]) : 0)
						};
						list.Add(item20);
						break;
					}
					case EExtraEffectRequire.Relationship:
						if (array.Length >= 3)
						{
							RequirementRelationship item21 = new RequirementRelationship
							{
								RequireTargetType1 = (ERequirementTargetType)int.Parse(array[0]),
								RequireTargetType2 = (ERequirementTargetType)int.Parse(array[1]),
								Relationship = (ERelation)int.Parse(array[2])
							};
							list.Add(item21);
						}
						break;
					case EExtraEffectRequire.SpecifiedDamageId:
					{
						long[] array16 = new long[array.Length];
						for (int num14 = 0; num14 < array.Length; num14++)
						{
							array16[num14] = long.Parse(array[num14]);
						}
						RequirementDamageId item22 = new RequirementDamageId
						{
							DamageIds = array16
						};
						list.Add(item22);
						break;
					}
					default:
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Character;
						ELogAuthor author = ELogAuthor.ZQR;
						string message = "未知的ExtraEffect条件类型";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("requireType", eextraEffectRequire);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", buffId);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						break;
					}
					}
				}
			}
			requireAndLimits.Requirements = list.ToArray();
			EffectLimits limits = requireAndLimits.Limits;
			limits.ExtraEffectCd = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectCd, level, -1f);
			limits.ExtraEffectCdForTarget = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectCdForTarget, level, -1f);
			if (parameters.ExtraEffectId == EExtraEffectId.AddBullet)
			{
				limits.ExtraEffectCd = Math.Max(limits.ExtraEffectCd, 0.5f);
			}
			limits.ExtraEffectRemoveStackNum = parameters.ExtraEffectRemoveStackNum;
			limits.ExtraEffectProbability = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectProbability, level, 10000f);
			return requireAndLimits;
		}
	}
}
