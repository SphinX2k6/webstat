using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E98 RID: 11928
public class CharacterAttributeTypes : IStaticVariableResetter
{
	// Token: 0x060187C9 RID: 100297 RVA: 0x006DB4FC File Offset: 0x006D96FC
	static CharacterAttributeTypes()
	{
		EAttributeType[] array = new EAttributeType[5];
		RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.7A8C53659DAEA03A0F1DCC578123D27F8B6457456D695A1E4C7037CC9247B374).FieldHandle);
		CharacterAttributeTypes.specialEnergyIds = new List<EAttributeType>(new <>z__ReadOnlyArray<EAttributeType>(array));
		EAttributeType[] array2 = new EAttributeType[6];
		RuntimeHelpers.InitializeArray(array2, fieldof(<PrivateImplementationDetails>.2C23178FC03C89FFD99D45EDEDC6C9A06CCF2BBB0FF7D2CEA81B762580E36C25).FieldHandle);
		CharacterAttributeTypes.energyAttrIds = array2;
		CharacterAttributeTypes.stateAttributeIds = new HashSet<EAttributeType>
		{
			EAttributeType.Life,
			EAttributeType.Strength,
			EAttributeType.Tough,
			EAttributeType.Rage,
			EAttributeType.Hardness,
			EAttributeType.Energy,
			EAttributeType.ElementPower1,
			EAttributeType.ElementPower2,
			EAttributeType.ElementPower3,
			EAttributeType.ElementPower4,
			EAttributeType.ElementPower5,
			EAttributeType.ElementPower6,
			EAttributeType.StatusBuildUp1,
			EAttributeType.StatusBuildUp2,
			EAttributeType.StatusBuildUp3,
			EAttributeType.StatusBuildUp4,
			EAttributeType.StatusBuildUp5,
			EAttributeType.ElementEnergy,
			EAttributeType.SpecialEnergy1,
			EAttributeType.SpecialEnergy2,
			EAttributeType.SpecialEnergy3,
			EAttributeType.SpecialEnergy4,
			EAttributeType.SpecialEnergy5,
			EAttributeType.ParalysisTime,
			EAttributeType.WeaknessBuildUp
		};
		CharacterAttributeTypes.attributeIdsWithMax = new Dictionary<EAttributeType, EAttributeType>
		{
			{
				EAttributeType.Life,
				EAttributeType.LifeMax
			},
			{
				EAttributeType.Strength,
				EAttributeType.StrengthMax
			},
			{
				EAttributeType.Tough,
				EAttributeType.ToughMax
			},
			{
				EAttributeType.Rage,
				EAttributeType.RageMax
			},
			{
				EAttributeType.Hardness,
				EAttributeType.HardnessMax
			},
			{
				EAttributeType.Energy,
				EAttributeType.EnergyMax
			},
			{
				EAttributeType.SpecialEnergy1,
				EAttributeType.SpecialEnergy1Max
			},
			{
				EAttributeType.SpecialEnergy2,
				EAttributeType.SpecialEnergy2Max
			},
			{
				EAttributeType.SpecialEnergy3,
				EAttributeType.SpecialEnergy3Max
			},
			{
				EAttributeType.SpecialEnergy4,
				EAttributeType.SpecialEnergy4Max
			},
			{
				EAttributeType.SpecialEnergy5,
				EAttributeType.SpecialEnergy5Max
			},
			{
				EAttributeType.StatusBuildUp1,
				EAttributeType.StatusBuildUp1Max
			},
			{
				EAttributeType.StatusBuildUp2,
				EAttributeType.StatusBuildUp2Max
			},
			{
				EAttributeType.StatusBuildUp3,
				EAttributeType.StatusBuildUp3Max
			},
			{
				EAttributeType.StatusBuildUp4,
				EAttributeType.StatusBuildUp4Max
			},
			{
				EAttributeType.StatusBuildUp5,
				EAttributeType.StatusBuildUp5Max
			},
			{
				EAttributeType.ElementEnergy,
				EAttributeType.ElementEnergyMax
			},
			{
				EAttributeType.ElementPower1,
				EAttributeType.ElementEnergyMax
			},
			{
				EAttributeType.ElementPower2,
				EAttributeType.ElementEnergyMax
			},
			{
				EAttributeType.ElementPower3,
				EAttributeType.ElementEnergyMax
			},
			{
				EAttributeType.ElementPower4,
				EAttributeType.ElementEnergyMax
			},
			{
				EAttributeType.ElementPower5,
				EAttributeType.ElementEnergyMax
			},
			{
				EAttributeType.ElementPower6,
				EAttributeType.ElementEnergyMax
			},
			{
				EAttributeType.ParalysisTime,
				EAttributeType.ParalysisTimeMax
			},
			{
				EAttributeType.WeaknessBuildUp,
				EAttributeType.WeaknessBuildUpMax
			}
		};
		EAttributeType[] array3 = new EAttributeType[18];
		RuntimeHelpers.InitializeArray(array3, fieldof(<PrivateImplementationDetails>.0C8F391E72E6A067C9D31CB621D2220C4B2E40D9441B83B97CAD43BFF3D0FE06).FieldHandle);
		CharacterAttributeTypes.attrsNotClampZero = array3;
		CharacterAttributeTypes.attrsCurrentValueClamp = new Dictionary<EAttributeType, int>
		{
			{
				EAttributeType.AutoAttackSpeed,
				20000
			},
			{
				EAttributeType.CastAttackSpeed,
				20000
			},
			{
				EAttributeType.DamageReduce,
				10000
			},
			{
				EAttributeType.DamageReducePhys,
				10000
			},
			{
				EAttributeType.DamageReduceElement1,
				10000
			},
			{
				EAttributeType.DamageReduceElement2,
				10000
			},
			{
				EAttributeType.DamageReduceElement3,
				10000
			},
			{
				EAttributeType.DamageReduceElement4,
				10000
			},
			{
				EAttributeType.DamageReduceElement5,
				10000
			},
			{
				EAttributeType.DamageReduceElement6,
				10000
			}
		};
		CharacterAttributeTypes.attrsAutoRecoverSpeedMap = new Dictionary<EAttributeType, EAttributeType>
		{
			{
				EAttributeType.Hardness,
				EAttributeType.HardnessRecover
			},
			{
				EAttributeType.Rage,
				EAttributeType.RageRecover
			},
			{
				EAttributeType.Tough,
				EAttributeType.ToughRecover
			},
			{
				EAttributeType.ParalysisTime,
				EAttributeType.ParalysisTimeRecover
			}
		};
		CharacterAttributeTypes.attrsAutoRecoverMaxMap = new Dictionary<EAttributeType, EAttributeType>
		{
			{
				EAttributeType.Hardness,
				EAttributeType.HardnessMax
			},
			{
				EAttributeType.Rage,
				EAttributeType.RageMax
			},
			{
				EAttributeType.Tough,
				EAttributeType.ToughMax
			},
			{
				EAttributeType.ParalysisTime,
				EAttributeType.ParalysisTimeMax
			}
		};
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterAttributeTypes.CreateStaticDefaultValue), new Action(CharacterAttributeTypes.ResetStaticDefaultValue));
	}

	// Token: 0x17002115 RID: 8469
	// (get) Token: 0x060187CA RID: 100298 RVA: 0x006DB87C File Offset: 0x006D9A7C
	[Nullable(1)]
	public static Dictionary<EAttributeType, EAttributeType> AttributeIdsMaxToAttrId
	{
		[NullableContext(1)]
		get
		{
			return CharacterAttributeTypes._attributeIdsMaxToAttrId;
		}
	}

	// Token: 0x060187CB RID: 100299 RVA: 0x006DB884 File Offset: 0x006D9A84
	public static void CreateStaticDefaultValue()
	{
		CharacterAttributeTypes._attributeIdsMaxToAttrId = new Dictionary<EAttributeType, EAttributeType>();
		foreach (KeyValuePair<EAttributeType, EAttributeType> keyValuePair in CharacterAttributeTypes.attributeIdsWithMax)
		{
			CharacterAttributeTypes.AttributeIdsMaxToAttrId[keyValuePair.Value] = keyValuePair.Key;
		}
	}

	// Token: 0x060187CC RID: 100300 RVA: 0x006DB8F4 File Offset: 0x006D9AF4
	public static void ResetStaticDefaultValue()
	{
		CharacterAttributeTypes._attributeIdsMaxToAttrId = null;
	}

	// Token: 0x0400BCC7 RID: 48327
	public const int ATTRIBUTE_ID_MAX = 143;

	// Token: 0x0400BCC8 RID: 48328
	public const int PER_TEN_THOUSAND = 10000;

	// Token: 0x0400BCC9 RID: 48329
	public const float DIVIDED_TEN_THOUSAND = 0.0001f;

	// Token: 0x0400BCCA RID: 48330
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly List<EAttributeType> specialEnergyIds;

	// Token: 0x0400BCCB RID: 48331
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly EAttributeType[] energyAttrIds;

	// Token: 0x0400BCCC RID: 48332
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly HashSet<EAttributeType> stateAttributeIds;

	// Token: 0x0400BCCD RID: 48333
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EAttributeType, EAttributeType> attributeIdsWithMax;

	// Token: 0x0400BCCE RID: 48334
	[Nullable(2)]
	private static Dictionary<EAttributeType, EAttributeType> _attributeIdsMaxToAttrId;

	// Token: 0x0400BCCF RID: 48335
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly EAttributeType[] attrsNotClampZero;

	// Token: 0x0400BCD0 RID: 48336
	private const int ATTACK_SPEED_MAX = 20000;

	// Token: 0x0400BCD1 RID: 48337
	private const int REDUCE_MAX = 10000;

	// Token: 0x0400BCD2 RID: 48338
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EAttributeType, int> attrsCurrentValueClamp;

	// Token: 0x0400BCD3 RID: 48339
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EAttributeType, EAttributeType> attrsAutoRecoverSpeedMap;

	// Token: 0x0400BCD4 RID: 48340
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EAttributeType, EAttributeType> attrsAutoRecoverMaxMap;

	// Token: 0x02009305 RID: 37637
	public interface IModifier
	{
		// Token: 0x1700A890 RID: 43152
		// (get) Token: 0x06049F7B RID: 302971
		ECalculationPolicyType Type { get; }
	}

	// Token: 0x02009306 RID: 37638
	public interface IAddValueModifier : CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A891 RID: 43153
		// (get) Token: 0x06049F7C RID: 302972
		float Value1 { get; }
	}

	// Token: 0x02009307 RID: 37639
	public interface IAddRateModifier : CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A892 RID: 43154
		// (get) Token: 0x06049F7D RID: 302973
		float Value1 { get; }
	}

	// Token: 0x02009308 RID: 37640
	public interface IAddFromAttrModifier : CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A893 RID: 43155
		// (get) Token: 0x06049F7E RID: 302974
		// (set) Token: 0x06049F7F RID: 302975
		EAttributeType SourceAttributeId { get; set; }

		// Token: 0x1700A894 RID: 43156
		// (get) Token: 0x06049F80 RID: 302976
		// (set) Token: 0x06049F81 RID: 302977
		long SourceEntity { get; set; }

		// Token: 0x1700A895 RID: 43157
		// (get) Token: 0x06049F82 RID: 302978
		// (set) Token: 0x06049F83 RID: 302979
		EAttributeBasedFloatCalculationType SourceCalculationType { get; set; }

		// Token: 0x1700A896 RID: 43158
		// (get) Token: 0x06049F84 RID: 302980
		// (set) Token: 0x06049F85 RID: 302981
		float? SnapshotSource { get; set; }

		// Token: 0x1700A897 RID: 43159
		// (get) Token: 0x06049F86 RID: 302982
		// (set) Token: 0x06049F87 RID: 302983
		float? Min { get; set; }

		// Token: 0x1700A898 RID: 43160
		// (get) Token: 0x06049F88 RID: 302984
		// (set) Token: 0x06049F89 RID: 302985
		float? Ratio { get; set; }

		// Token: 0x1700A899 RID: 43161
		// (get) Token: 0x06049F8A RID: 302986
		// (set) Token: 0x06049F8B RID: 302987
		float? Max { get; set; }

		// Token: 0x1700A89A RID: 43162
		// (get) Token: 0x06049F8C RID: 302988
		// (set) Token: 0x06049F8D RID: 302989
		bool FloorAfterRatio { get; set; }

		// Token: 0x1700A89B RID: 43163
		// (get) Token: 0x06049F8E RID: 302990
		// (set) Token: 0x06049F8F RID: 302991
		float Value1 { get; set; }

		// Token: 0x1700A89C RID: 43164
		// (get) Token: 0x06049F90 RID: 302992
		// (set) Token: 0x06049F91 RID: 302993
		float Value2 { get; set; }
	}

	// Token: 0x02009309 RID: 37641
	public interface IAddFromAttrRateModifier : CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A89D RID: 43165
		// (get) Token: 0x06049F92 RID: 302994
		EAttributeType SourceAttributeId { get; }

		// Token: 0x1700A89E RID: 43166
		// (get) Token: 0x06049F93 RID: 302995
		long SourceEntity { get; }

		// Token: 0x1700A89F RID: 43167
		// (get) Token: 0x06049F94 RID: 302996
		EAttributeBasedFloatCalculationType SourceCalculationType { get; }

		// Token: 0x1700A8A0 RID: 43168
		// (get) Token: 0x06049F95 RID: 302997
		int? SnapshotSource { get; }

		// Token: 0x1700A8A1 RID: 43169
		// (get) Token: 0x06049F96 RID: 302998
		float? Min { get; }

		// Token: 0x1700A8A2 RID: 43170
		// (get) Token: 0x06049F97 RID: 302999
		float? Ratio { get; }

		// Token: 0x1700A8A3 RID: 43171
		// (get) Token: 0x06049F98 RID: 303000
		float? Max { get; }

		// Token: 0x1700A8A4 RID: 43172
		// (get) Token: 0x06049F99 RID: 303001
		bool FloorAfterRatio { get; }

		// Token: 0x1700A8A5 RID: 43173
		// (get) Token: 0x06049F9A RID: 303002
		float Value1 { get; }
	}

	// Token: 0x0200930A RID: 37642
	public interface IOverrideValue : CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A8A6 RID: 43174
		// (get) Token: 0x06049F9B RID: 303003
		float Value1 { get; }
	}

	// Token: 0x0200930B RID: 37643
	public interface IOverrideFromAttrModifier : CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A8A7 RID: 43175
		// (get) Token: 0x06049F9C RID: 303004
		// (set) Token: 0x06049F9D RID: 303005
		EAttributeType? SourceAttributeId { get; set; }

		// Token: 0x1700A8A8 RID: 43176
		// (get) Token: 0x06049F9E RID: 303006
		// (set) Token: 0x06049F9F RID: 303007
		long SourceEntity { get; set; }

		// Token: 0x1700A8A9 RID: 43177
		// (get) Token: 0x06049FA0 RID: 303008
		// (set) Token: 0x06049FA1 RID: 303009
		EAttributeBasedFloatCalculationType? SourceCalculationType { get; set; }

		// Token: 0x1700A8AA RID: 43178
		// (get) Token: 0x06049FA2 RID: 303010
		// (set) Token: 0x06049FA3 RID: 303011
		float? SnapshotSource { get; set; }

		// Token: 0x1700A8AB RID: 43179
		// (get) Token: 0x06049FA4 RID: 303012
		// (set) Token: 0x06049FA5 RID: 303013
		float? Min { get; set; }

		// Token: 0x1700A8AC RID: 43180
		// (get) Token: 0x06049FA6 RID: 303014
		// (set) Token: 0x06049FA7 RID: 303015
		float? Ratio { get; set; }

		// Token: 0x1700A8AD RID: 43181
		// (get) Token: 0x06049FA8 RID: 303016
		// (set) Token: 0x06049FA9 RID: 303017
		float? Max { get; set; }

		// Token: 0x1700A8AE RID: 43182
		// (get) Token: 0x06049FAA RID: 303018
		// (set) Token: 0x06049FAB RID: 303019
		bool FloorAfterRatio { get; set; }

		// Token: 0x1700A8AF RID: 43183
		// (get) Token: 0x06049FAC RID: 303020
		// (set) Token: 0x06049FAD RID: 303021
		float Value1 { get; set; }

		// Token: 0x1700A8B0 RID: 43184
		// (get) Token: 0x06049FAE RID: 303022
		// (set) Token: 0x06049FAF RID: 303023
		float Value2 { get; set; }
	}

	// Token: 0x0200930C RID: 37644
	public class OverrideFromAttrModifier : CharacterAttributeTypes.IOverrideFromAttrModifier, CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A8B1 RID: 43185
		// (get) Token: 0x06049FB0 RID: 303024 RVA: 0x0140C483 File Offset: 0x0140A683
		// (set) Token: 0x06049FB1 RID: 303025 RVA: 0x0140C48B File Offset: 0x0140A68B
		public ECalculationPolicyType Type { get; set; }

		// Token: 0x1700A8B2 RID: 43186
		// (get) Token: 0x06049FB2 RID: 303026 RVA: 0x0140C494 File Offset: 0x0140A694
		// (set) Token: 0x06049FB3 RID: 303027 RVA: 0x0140C49C File Offset: 0x0140A69C
		public EAttributeType? SourceAttributeId { get; set; }

		// Token: 0x1700A8B3 RID: 43187
		// (get) Token: 0x06049FB4 RID: 303028 RVA: 0x0140C4A5 File Offset: 0x0140A6A5
		// (set) Token: 0x06049FB5 RID: 303029 RVA: 0x0140C4AD File Offset: 0x0140A6AD
		public long SourceEntity { get; set; }

		// Token: 0x1700A8B4 RID: 43188
		// (get) Token: 0x06049FB6 RID: 303030 RVA: 0x0140C4B6 File Offset: 0x0140A6B6
		// (set) Token: 0x06049FB7 RID: 303031 RVA: 0x0140C4BE File Offset: 0x0140A6BE
		public EAttributeBasedFloatCalculationType? SourceCalculationType { get; set; }

		// Token: 0x1700A8B5 RID: 43189
		// (get) Token: 0x06049FB8 RID: 303032 RVA: 0x0140C4C7 File Offset: 0x0140A6C7
		// (set) Token: 0x06049FB9 RID: 303033 RVA: 0x0140C4CF File Offset: 0x0140A6CF
		public float? SnapshotSource { get; set; }

		// Token: 0x1700A8B6 RID: 43190
		// (get) Token: 0x06049FBA RID: 303034 RVA: 0x0140C4D8 File Offset: 0x0140A6D8
		// (set) Token: 0x06049FBB RID: 303035 RVA: 0x0140C4E0 File Offset: 0x0140A6E0
		public float? Min { get; set; }

		// Token: 0x1700A8B7 RID: 43191
		// (get) Token: 0x06049FBC RID: 303036 RVA: 0x0140C4E9 File Offset: 0x0140A6E9
		// (set) Token: 0x06049FBD RID: 303037 RVA: 0x0140C4F1 File Offset: 0x0140A6F1
		public float? Ratio { get; set; }

		// Token: 0x1700A8B8 RID: 43192
		// (get) Token: 0x06049FBE RID: 303038 RVA: 0x0140C4FA File Offset: 0x0140A6FA
		// (set) Token: 0x06049FBF RID: 303039 RVA: 0x0140C502 File Offset: 0x0140A702
		public float? Max { get; set; }

		// Token: 0x1700A8B9 RID: 43193
		// (get) Token: 0x06049FC0 RID: 303040 RVA: 0x0140C50B File Offset: 0x0140A70B
		// (set) Token: 0x06049FC1 RID: 303041 RVA: 0x0140C513 File Offset: 0x0140A713
		public bool FloorAfterRatio { get; set; }

		// Token: 0x1700A8BA RID: 43194
		// (get) Token: 0x06049FC2 RID: 303042 RVA: 0x0140C51C File Offset: 0x0140A71C
		// (set) Token: 0x06049FC3 RID: 303043 RVA: 0x0140C524 File Offset: 0x0140A724
		public float Value1 { get; set; }

		// Token: 0x1700A8BB RID: 43195
		// (get) Token: 0x06049FC4 RID: 303044 RVA: 0x0140C52D File Offset: 0x0140A72D
		// (set) Token: 0x06049FC5 RID: 303045 RVA: 0x0140C535 File Offset: 0x0140A735
		public float Value2 { get; set; }
	}

	// Token: 0x0200930D RID: 37645
	public interface IMultiplyMagnitude1Modifier : CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A8BC RID: 43196
		// (get) Token: 0x06049FC7 RID: 303047
		// (set) Token: 0x06049FC8 RID: 303048
		float Value1 { get; set; }
	}

	// Token: 0x0200930E RID: 37646
	public class MultiplyMagnitude1Modifier : CharacterAttributeTypes.IMultiplyMagnitude1Modifier, CharacterAttributeTypes.IModifier
	{
		// Token: 0x1700A8BD RID: 43197
		// (get) Token: 0x06049FC9 RID: 303049 RVA: 0x0140C546 File Offset: 0x0140A746
		// (set) Token: 0x06049FCA RID: 303050 RVA: 0x0140C54E File Offset: 0x0140A74E
		public ECalculationPolicyType Type { get; set; }

		// Token: 0x1700A8BE RID: 43198
		// (get) Token: 0x06049FCB RID: 303051 RVA: 0x0140C557 File Offset: 0x0140A757
		// (set) Token: 0x06049FCC RID: 303052 RVA: 0x0140C55F File Offset: 0x0140A75F
		public float Value1 { get; set; }
	}

	// Token: 0x0200930F RID: 37647
	public class AttributeModifier : CharacterAttributeTypes.IModifier, CharacterAttributeTypes.IAddValueModifier, CharacterAttributeTypes.IAddRateModifier, CharacterAttributeTypes.IAddFromAttrModifier, CharacterAttributeTypes.IAddFromAttrRateModifier, CharacterAttributeTypes.IOverrideValue, CharacterAttributeTypes.IOverrideFromAttrModifier, CharacterAttributeTypes.IMultiplyMagnitude1Modifier
	{
		// Token: 0x1700A8BF RID: 43199
		// (get) Token: 0x06049FCE RID: 303054 RVA: 0x0140C570 File Offset: 0x0140A770
		// (set) Token: 0x06049FCF RID: 303055 RVA: 0x0140C578 File Offset: 0x0140A778
		public ECalculationPolicyType Type { get; set; }

		// Token: 0x1700A8C0 RID: 43200
		// (get) Token: 0x06049FD0 RID: 303056 RVA: 0x0140C581 File Offset: 0x0140A781
		// (set) Token: 0x06049FD1 RID: 303057 RVA: 0x0140C589 File Offset: 0x0140A789
		public float Value1 { get; set; }

		// Token: 0x1700A8C1 RID: 43201
		// (get) Token: 0x06049FD2 RID: 303058 RVA: 0x0140C592 File Offset: 0x0140A792
		// (set) Token: 0x06049FD3 RID: 303059 RVA: 0x0140C59A File Offset: 0x0140A79A
		public float Value2 { get; set; }

		// Token: 0x1700A8C2 RID: 43202
		// (get) Token: 0x06049FD4 RID: 303060 RVA: 0x0140C5A3 File Offset: 0x0140A7A3
		// (set) Token: 0x06049FD5 RID: 303061 RVA: 0x0140C5AB File Offset: 0x0140A7AB
		public long SourceEntity { get; set; }

		// Token: 0x1700A8C3 RID: 43203
		// (get) Token: 0x06049FD6 RID: 303062 RVA: 0x0140C5B4 File Offset: 0x0140A7B4
		// (set) Token: 0x06049FD7 RID: 303063 RVA: 0x0140C5BC File Offset: 0x0140A7BC
		public EAttributeType SourceAttributeId { get; set; }

		// Token: 0x1700A8C4 RID: 43204
		// (get) Token: 0x06049FD8 RID: 303064 RVA: 0x0140C5C5 File Offset: 0x0140A7C5
		// (set) Token: 0x06049FD9 RID: 303065 RVA: 0x0140C5CD File Offset: 0x0140A7CD
		public EAttributeBasedFloatCalculationType SourceCalculationType { get; set; }

		// Token: 0x1700A8C5 RID: 43205
		// (get) Token: 0x06049FDA RID: 303066 RVA: 0x0140C5D6 File Offset: 0x0140A7D6
		// (set) Token: 0x06049FDB RID: 303067 RVA: 0x0140C5DE File Offset: 0x0140A7DE
		public float? SnapshotSource { get; set; }

		// Token: 0x1700A8C6 RID: 43206
		// (get) Token: 0x06049FDC RID: 303068 RVA: 0x0140C5E7 File Offset: 0x0140A7E7
		// (set) Token: 0x06049FDD RID: 303069 RVA: 0x0140C5EF File Offset: 0x0140A7EF
		public float? Min { get; set; }

		// Token: 0x1700A8C7 RID: 43207
		// (get) Token: 0x06049FDE RID: 303070 RVA: 0x0140C5F8 File Offset: 0x0140A7F8
		// (set) Token: 0x06049FDF RID: 303071 RVA: 0x0140C600 File Offset: 0x0140A800
		public float? Ratio { get; set; }

		// Token: 0x1700A8C8 RID: 43208
		// (get) Token: 0x06049FE0 RID: 303072 RVA: 0x0140C609 File Offset: 0x0140A809
		// (set) Token: 0x06049FE1 RID: 303073 RVA: 0x0140C611 File Offset: 0x0140A811
		public float? Max { get; set; }

		// Token: 0x1700A8C9 RID: 43209
		// (get) Token: 0x06049FE2 RID: 303074 RVA: 0x0140C61A File Offset: 0x0140A81A
		// (set) Token: 0x06049FE3 RID: 303075 RVA: 0x0140C622 File Offset: 0x0140A822
		public bool FloorAfterRatio { get; set; }

		// Token: 0x1700A8CA RID: 43210
		// (get) Token: 0x06049FE4 RID: 303076 RVA: 0x0140C62B File Offset: 0x0140A82B
		EAttributeType CharacterAttributeTypes.IAddFromAttrRateModifier.SourceAttributeId
		{
			get
			{
				return this.SourceAttributeId;
			}
		}

		// Token: 0x1700A8CB RID: 43211
		// (get) Token: 0x06049FE5 RID: 303077 RVA: 0x0140C633 File Offset: 0x0140A833
		long CharacterAttributeTypes.IAddFromAttrRateModifier.SourceEntity
		{
			get
			{
				return this.SourceEntity;
			}
		}

		// Token: 0x1700A8CC RID: 43212
		// (get) Token: 0x06049FE6 RID: 303078 RVA: 0x0140C63B File Offset: 0x0140A83B
		EAttributeBasedFloatCalculationType CharacterAttributeTypes.IAddFromAttrRateModifier.SourceCalculationType
		{
			get
			{
				return this.SourceCalculationType;
			}
		}

		// Token: 0x1700A8CD RID: 43213
		// (get) Token: 0x06049FE7 RID: 303079 RVA: 0x0140C644 File Offset: 0x0140A844
		int? CharacterAttributeTypes.IAddFromAttrRateModifier.SnapshotSource
		{
			get
			{
				if (this.SnapshotSource == null)
				{
					return null;
				}
				return new int?((int)this.SnapshotSource.Value);
			}
		}

		// Token: 0x1700A8CE RID: 43214
		// (get) Token: 0x06049FE8 RID: 303080 RVA: 0x0140C67F File Offset: 0x0140A87F
		float? CharacterAttributeTypes.IAddFromAttrRateModifier.Min
		{
			get
			{
				return this.Min;
			}
		}

		// Token: 0x1700A8CF RID: 43215
		// (get) Token: 0x06049FE9 RID: 303081 RVA: 0x0140C687 File Offset: 0x0140A887
		float? CharacterAttributeTypes.IAddFromAttrRateModifier.Ratio
		{
			get
			{
				return this.Ratio;
			}
		}

		// Token: 0x1700A8D0 RID: 43216
		// (get) Token: 0x06049FEA RID: 303082 RVA: 0x0140C68F File Offset: 0x0140A88F
		float? CharacterAttributeTypes.IAddFromAttrRateModifier.Max
		{
			get
			{
				return this.Max;
			}
		}

		// Token: 0x1700A8D1 RID: 43217
		// (get) Token: 0x06049FEB RID: 303083 RVA: 0x0140C697 File Offset: 0x0140A897
		float CharacterAttributeTypes.IAddFromAttrRateModifier.Value1
		{
			get
			{
				return this.Value1;
			}
		}

		// Token: 0x1700A8D2 RID: 43218
		// (get) Token: 0x06049FEC RID: 303084 RVA: 0x0140C69F File Offset: 0x0140A89F
		float CharacterAttributeTypes.IAddValueModifier.Value1
		{
			get
			{
				return this.Value1;
			}
		}

		// Token: 0x1700A8D3 RID: 43219
		// (get) Token: 0x06049FED RID: 303085 RVA: 0x0140C6A7 File Offset: 0x0140A8A7
		float CharacterAttributeTypes.IAddRateModifier.Value1
		{
			get
			{
				return this.Value1;
			}
		}

		// Token: 0x1700A8D4 RID: 43220
		// (get) Token: 0x06049FEE RID: 303086 RVA: 0x0140C6AF File Offset: 0x0140A8AF
		float CharacterAttributeTypes.IOverrideValue.Value1
		{
			get
			{
				return this.Value1;
			}
		}

		// Token: 0x1700A8D5 RID: 43221
		// (get) Token: 0x06049FEF RID: 303087 RVA: 0x0140C6B7 File Offset: 0x0140A8B7
		// (set) Token: 0x06049FF0 RID: 303088 RVA: 0x0140C6C4 File Offset: 0x0140A8C4
		EAttributeType? CharacterAttributeTypes.IOverrideFromAttrModifier.SourceAttributeId
		{
			get
			{
				return new EAttributeType?(this.SourceAttributeId);
			}
			set
			{
				this.SourceAttributeId = value.GetValueOrDefault();
			}
		}

		// Token: 0x1700A8D6 RID: 43222
		// (get) Token: 0x06049FF1 RID: 303089 RVA: 0x0140C6D3 File Offset: 0x0140A8D3
		// (set) Token: 0x06049FF2 RID: 303090 RVA: 0x0140C6E0 File Offset: 0x0140A8E0
		EAttributeBasedFloatCalculationType? CharacterAttributeTypes.IOverrideFromAttrModifier.SourceCalculationType
		{
			get
			{
				return new EAttributeBasedFloatCalculationType?(this.SourceCalculationType);
			}
			set
			{
				this.SourceCalculationType = value.GetValueOrDefault();
			}
		}
	}

	// Token: 0x02009310 RID: 37648
	// (Invoke) Token: 0x06049FF5 RID: 303093
	public delegate void AttributeChangeListener(EAttributeType attrId, float newValue, float oldValue);
}
