using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002EB0 RID: 11952
[NullableContext(1)]
[Nullable(0)]
public class Calculation : IStaticVariableResetter
{
	// Token: 0x0601885D RID: 100445 RVA: 0x006E0CAA File Offset: 0x006DEEAA
	static Calculation()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(Calculation.CreateStaticDefaultValue), new Action(Calculation.ResetStaticDefaultValue));
	}

	// Token: 0x0601885E RID: 100446 RVA: 0x006E0CCC File Offset: 0x006DEECC
	private static double GetAttrFromSnapshots(SnapshotPayload snap, EAttrOwnerType attrOwnerType, EAttributeType attrId)
	{
		if (attrId < EAttributeType.Lv || attrId >= EAttributeType.Max)
		{
			return 0.0;
		}
		float currentValue;
		if (attrOwnerType == EAttrOwnerType.Attacker)
		{
			currentValue = snap.AttackerSnapshot.GetCurrentValue(attrId);
		}
		else
		{
			currentValue = snap.TargetSnapshot.GetCurrentValue(attrId);
		}
		return (double)currentValue;
	}

	// Token: 0x17002118 RID: 8472
	// (get) Token: 0x0601885F RID: 100447 RVA: 0x006E0D10 File Offset: 0x006DEF10
	private static Dictionary<int, Calculation.TFormula> Formulas
	{
		get
		{
			return Calculation._formulas;
		}
	}

	// Token: 0x06018860 RID: 100448 RVA: 0x006E0D18 File Offset: 0x006DEF18
	public static double CalculateHurt(SnapshotPayload snapshots, EElementType elementType, EAttackType attackType, EAttributeType attrId, double attrRate, bool isCritical, double augment, double amplify, double gameplayRatio, double formula = 0.0)
	{
		AttributeSnapshot attackerSnapshot = snapshots.AttackerSnapshot;
		AttributeSnapshot targetSnapshot = snapshots.TargetSnapshot;
		double num = attrRate * 9.999999747378752E-05;
		double elementDamageBonus = Calculation.GetElementDamageBonus(attackerSnapshot, elementType);
		double num2 = Math.Min(Calculation.GetElementDamageReduce(targetSnapshot, elementType), 1.0);
		double elementResistant = Calculation.GetElementResistant(targetSnapshot, elementType);
		double elementIgnoreResistance = Calculation.GetElementIgnoreResistance(attackerSnapshot, elementType);
		double num3;
		if (elementResistant - elementIgnoreResistance <= 0.0)
		{
			num3 = 1.0 - (elementResistant - elementIgnoreResistance) / 2.0;
		}
		else if (elementResistant - elementIgnoreResistance < 0.8)
		{
			num3 = 1.0 - (elementResistant - elementIgnoreResistance);
		}
		else
		{
			num3 = 1.0 / (1.0 + (elementResistant - elementIgnoreResistance) * 5.0);
		}
		double attackTypeDamageBonus = Calculation.GetAttackTypeDamageBonus(attackerSnapshot, attackType);
		double attrFromSnapshots = Calculation.GetAttrFromSnapshots(snapshots, EAttrOwnerType.Attacker, attrId);
		float currentValue = targetSnapshot.GetCurrentValue(EAttributeType.Def);
		float num4 = attackerSnapshot.GetCurrentValue(EAttributeType.IgnoreDefRate) * 0.0001f;
		float currentValue2 = attackerSnapshot.GetCurrentValue(EAttributeType.Lv);
		float num5 = Math.Min(2f, 1f / (currentValue * (1f - num4) / (800f + currentValue2 * 8f) + 1f));
		float num6 = attackerSnapshot.GetCurrentValue(EAttributeType.DamageChange) * 0.0001f;
		double num7 = (double)(1f + num6) + elementDamageBonus + attackTypeDamageBonus;
		EElementType targetElementType = (EElementType)targetSnapshot.GetCurrentValue(EAttributeType.ElementPropertyType);
		double num8 = Math.Min((double)(targetSnapshot.GetCurrentValue(EAttributeType.DamageReduce) * 0.0001f), 1.0);
		float num9 = 1f + attackerSnapshot.GetCurrentValue(EAttributeType.SpecialDamageChange) * 0.0001f;
		double num10 = Calculation.CalculateElementMatchUpRate(elementType, targetElementType);
		float num11 = attackerSnapshot.GetCurrentValue(EAttributeType.CritDamage) * 0.0001f;
		double num12 = isCritical ? ((double)num11) : 1.0;
		double val = (num * attrFromSnapshots + augment + formula) * num12 * (double)num5 * num7 * num3 * (1.0 - num8) * (1.0 - num2) * (double)num9 * num10 * gameplayRatio * Math.Max(1.0 + amplify * 9.999999747378752E-05, 0.0);
		return Math.Max(0.0, val);
	}

	// Token: 0x06018861 RID: 100449 RVA: 0x006E0F4C File Offset: 0x006DF14C
	public static double GetElementResistant(AttributeSnapshot attrSet, EElementType elementType)
	{
		float num;
		switch (elementType)
		{
		case EElementType.Physical:
			num = attrSet.GetCurrentValue(EAttributeType.DamageResistancePhys) * 0.0001f;
			break;
		case EElementType.Ice:
			num = attrSet.GetCurrentValue(EAttributeType.DamageResistanceElement1) * 0.0001f;
			break;
		case EElementType.Fire:
			num = attrSet.GetCurrentValue(EAttributeType.DamageResistanceElement2) * 0.0001f;
			break;
		case EElementType.Thunder:
			num = attrSet.GetCurrentValue(EAttributeType.DamageResistanceElement3) * 0.0001f;
			break;
		case EElementType.Wind:
			num = attrSet.GetCurrentValue(EAttributeType.DamageResistanceElement4) * 0.0001f;
			break;
		case EElementType.Light:
			num = attrSet.GetCurrentValue(EAttributeType.DamageResistanceElement5) * 0.0001f;
			break;
		case EElementType.Dark:
			num = attrSet.GetCurrentValue(EAttributeType.DamageResistanceElement6) * 0.0001f;
			break;
		default:
			num = 0f;
			break;
		}
		return (double)num;
	}

	// Token: 0x06018862 RID: 100450 RVA: 0x006E0FFC File Offset: 0x006DF1FC
	public static double GetElementIgnoreResistance(AttributeSnapshot attrSet, EElementType elementType)
	{
		float num;
		switch (elementType)
		{
		case EElementType.Physical:
			num = attrSet.GetCurrentValue(EAttributeType.IgnoreDamageResistancePhys) * 0.0001f;
			break;
		case EElementType.Ice:
			num = attrSet.GetCurrentValue(EAttributeType.IgnoreDamageResistanceElement1) * 0.0001f;
			break;
		case EElementType.Fire:
			num = attrSet.GetCurrentValue(EAttributeType.IgnoreDamageResistanceElement2) * 0.0001f;
			break;
		case EElementType.Thunder:
			num = attrSet.GetCurrentValue(EAttributeType.IgnoreDamageResistanceElement3) * 0.0001f;
			break;
		case EElementType.Wind:
			num = attrSet.GetCurrentValue(EAttributeType.IgnoreDamageResistanceElement4) * 0.0001f;
			break;
		case EElementType.Light:
			num = attrSet.GetCurrentValue(EAttributeType.IgnoreDamageResistanceElement5) * 0.0001f;
			break;
		case EElementType.Dark:
			num = attrSet.GetCurrentValue(EAttributeType.IgnoreDamageResistanceElement6) * 0.0001f;
			break;
		default:
			num = 0f;
			break;
		}
		return (double)num;
	}

	// Token: 0x06018863 RID: 100451 RVA: 0x006E10AC File Offset: 0x006DF2AC
	public static double GetElementDamageReduce(AttributeSnapshot attrSet, EElementType elementType)
	{
		float num;
		switch (elementType)
		{
		case EElementType.Physical:
			num = attrSet.GetCurrentValue(EAttributeType.DamageReducePhys) * 0.0001f;
			break;
		case EElementType.Ice:
			num = attrSet.GetCurrentValue(EAttributeType.DamageReduceElement1) * 0.0001f;
			break;
		case EElementType.Fire:
			num = attrSet.GetCurrentValue(EAttributeType.DamageReduceElement2) * 0.0001f;
			break;
		case EElementType.Thunder:
			num = attrSet.GetCurrentValue(EAttributeType.DamageReduceElement3) * 0.0001f;
			break;
		case EElementType.Wind:
			num = attrSet.GetCurrentValue(EAttributeType.DamageReduceElement4) * 0.0001f;
			break;
		case EElementType.Light:
			num = attrSet.GetCurrentValue(EAttributeType.DamageReduceElement5) * 0.0001f;
			break;
		case EElementType.Dark:
			num = attrSet.GetCurrentValue(EAttributeType.DamageReduceElement6) * 0.0001f;
			break;
		default:
			num = 0f;
			break;
		}
		return (double)num;
	}

	// Token: 0x06018864 RID: 100452 RVA: 0x006E115C File Offset: 0x006DF35C
	public static double GetElementDamageBonus(AttributeSnapshot attrSet, EElementType elementType)
	{
		float num;
		switch (elementType)
		{
		case EElementType.Physical:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangePhys) * 0.0001f;
			break;
		case EElementType.Ice:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeElement1) * 0.0001f;
			break;
		case EElementType.Fire:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeElement2) * 0.0001f;
			break;
		case EElementType.Thunder:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeElement3) * 0.0001f;
			break;
		case EElementType.Wind:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeElement4) * 0.0001f;
			break;
		case EElementType.Light:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeElement5) * 0.0001f;
			break;
		case EElementType.Dark:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeElement6) * 0.0001f;
			break;
		default:
			num = 0f;
			break;
		}
		return (double)num;
	}

	// Token: 0x06018865 RID: 100453 RVA: 0x006E120C File Offset: 0x006DF40C
	public static double GetAttackTypeDamageBonus(AttributeSnapshot attrSet, EAttackType attackType)
	{
		float num;
		switch (attackType)
		{
		case EAttackType.Auto:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeAuto) * 0.0001f;
			break;
		case EAttackType.Cast:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeCast) * 0.0001f;
			break;
		case EAttackType.Ultra:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeUltra) * 0.0001f;
			break;
		case EAttackType.QTE:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeQte) * 0.0001f;
			break;
		case EAttackType.NormalSkill:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangeNormalSkill) * 0.0001f;
			break;
		case EAttackType.PhantomSkill:
			num = attrSet.GetCurrentValue(EAttributeType.DamageChangePhantom) * 0.0001f;
			break;
		default:
			num = 0f;
			break;
		}
		return (double)num;
	}

	// Token: 0x06018866 RID: 100454 RVA: 0x006E12A8 File Offset: 0x006DF4A8
	private static double CalculateHeal(SnapshotPayload snapshots, float baseValue, EAttributeType attrType, float attrRate)
	{
		double attrFromSnapshots = Calculation.GetAttrFromSnapshots(snapshots, EAttrOwnerType.Attacker, attrType);
		double num = (double)(attrRate * 0.0001f);
		float num2 = snapshots.TargetSnapshot.GetCurrentValue(EAttributeType.HealedChange) * 0.0001f;
		float num3 = snapshots.AttackerSnapshot.GetCurrentValue(EAttributeType.HealChange) * 0.0001f;
		double val = (num * attrFromSnapshots + (double)baseValue) * (double)Math.Max(0f, num2 + num3 + 1f);
		return Math.Max(0.0, val);
	}

	// Token: 0x06018867 RID: 100455 RVA: 0x006E1318 File Offset: 0x006DF518
	public static float ToughCalculation(AttributeSnapshot attackerAttr, AttributeSnapshot targetAttr, float rate)
	{
		return rate * (attackerAttr.GetCurrentValue(EAttributeType.ToughChange) * 0.0001f) * (targetAttr.GetCurrentValue(EAttributeType.ToughReduce) * 0.0001f) * (targetAttr.GetCurrentValue(EAttributeType.SkillToughRatio) * 0.0001f);
	}

	// Token: 0x06018868 RID: 100456 RVA: 0x006E1348 File Offset: 0x006DF548
	public unsafe static double LandingDamageCalculationRole(double lastSpeedZ, double time, double lifeMax)
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("landing_damage_args_role");
		double num = lastSpeedZ / (double)intArrayConfig[0] - 1.0;
		double num2 = (num > 0.0) ? num : 0.0;
		double y = (double)intArrayConfig[2] / 10000.0;
		double num3 = (double)intArrayConfig[3] / 10000.0;
		double num4 = Math.Pow(time, y) * num3;
		double num5 = num2 + num4;
		double num6 = Math.Floor(num5 * lifeMax);
		if (num6 > 0.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "角色跌落伤害";
			<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray8<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("上一帧速度", lastSpeedZ);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("damage", num6);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("time", time);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("lifeMax", lifeMax);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("landing_damage_args_role", intArrayConfig);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("rateBase", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("rateT", num4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("rate", num5);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 8));
			return num6;
		}
		return 0.0;
	}

	// Token: 0x06018869 RID: 100457 RVA: 0x006E14F8 File Offset: 0x006DF6F8
	public static double LandingDamageCalculationMonster(double height, double lifeMax)
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("landing_damage_args_monster");
		int num = intArrayConfig[0];
		if (height < (double)num)
		{
			return 0.0;
		}
		return Math.Floor(Math.Pow(height, (double)intArrayConfig[1] / 10000.0) * ((double)intArrayConfig[3] / 10000.0) * lifeMax / (double)intArrayConfig[2]);
	}

	// Token: 0x0601886A RID: 100458 RVA: 0x006E1564 File Offset: 0x006DF764
	public static double ReactionDamageRateCalculation(AttributeSnapshot attackerAttr, AttributeSnapshot targetAttr, double damageRate, int elementType, DamagePayload payload, double reactionEfficiency, bool isCritical)
	{
		double num = 2.0 - 3000.0 / (reactionEfficiency * 8.0 + 1830.0);
		float num2;
		switch (elementType)
		{
		case 0:
			num2 = attackerAttr.GetCurrentValue(EAttributeType.DamageChangePhys);
			break;
		case 1:
			num2 = attackerAttr.GetCurrentValue(EAttributeType.DamageChangeElement1);
			break;
		case 2:
			num2 = attackerAttr.GetCurrentValue(EAttributeType.DamageChangeElement2);
			break;
		case 3:
			num2 = attackerAttr.GetCurrentValue(EAttributeType.DamageChangeElement3);
			break;
		case 4:
			num2 = attackerAttr.GetCurrentValue(EAttributeType.DamageChangeElement4);
			break;
		case 5:
			num2 = attackerAttr.GetCurrentValue(EAttributeType.DamageChangeElement5);
			break;
		case 6:
			num2 = attackerAttr.GetCurrentValue(EAttributeType.DamageChangeElement6);
			break;
		default:
			num2 = 0f;
			break;
		}
		float num3 = num2;
		num3 *= 0.0001f;
		float num4 = attackerAttr.GetCurrentValue(EAttributeType.CritDamage) * 0.0001f;
		double num5 = isCritical ? ((double)num4) : 1.0;
		float num6 = (float)payload.A * 0.0001f;
		float num7 = (float)payload.B * 0.0001f;
		float num8 = (float)payload.C * 0.0001f;
		float num9 = (float)payload.D * 0.0001f;
		float num10 = (float)payload.E * 0.0001f;
		float num11 = (float)payload.F * 0.0001f;
		float num12 = (float)payload.G * 0.0001f;
		float currentValue = attackerAttr.GetCurrentValue(EAttributeType.Lv);
		float currentValue2 = attackerAttr.GetCurrentValue(EAttributeType.Atk);
		float currentValue3 = targetAttr.GetCurrentValue(EAttributeType.Lv);
		double num13 = 0.1 / (2.5E-05 + 1.0 * Math.Pow(0.8, (double)(currentValue + 40f) * 0.5));
		return Math.Ceiling(damageRate * 9.999999747378752E-05 * (1.0 + num * (double)num6 + (double)(num7 * currentValue) + (double)num10) * num5 * (double)(1f + currentValue2 * num8) * (double)(1f + num3 * num9) * (double)(1f / (1f + currentValue3 / (num11 + currentValue * num12))) * num13);
	}

	// Token: 0x0601886B RID: 100459 RVA: 0x006E177C File Offset: 0x006DF97C
	public static double CalculateElementMatchUpRate(EElementType attackElementType, EElementType targetElementType)
	{
		double result;
		switch (attackElementType)
		{
		case EElementType.Physical:
			result = 1.0;
			break;
		case EElementType.Ice:
			result = ((targetElementType == EElementType.Wind) ? 1.0 : 1.0);
			break;
		case EElementType.Fire:
			result = ((targetElementType == EElementType.Ice) ? 1.0 : 1.0);
			break;
		case EElementType.Thunder:
			result = ((targetElementType == EElementType.Fire) ? 1.0 : 1.0);
			break;
		case EElementType.Wind:
			result = ((targetElementType == EElementType.Thunder) ? 1.0 : 1.0);
			break;
		case EElementType.Light:
			result = ((targetElementType == EElementType.Dark) ? 1.0 : 1.0);
			break;
		case EElementType.Dark:
			result = ((targetElementType == EElementType.Light) ? 1.0 : 1.0);
			break;
		default:
			result = 1.0;
			break;
		}
		return result;
	}

	// Token: 0x0601886C RID: 100460 RVA: 0x006E1870 File Offset: 0x006DFA70
	public unsafe static double CalculateFormula(TDamageParam inputParam, SnapshotPayload snapshots, bool isCritical, double augment, double amplify, double multiRatio, double gameplayRatio)
	{
		Damage damageData = inputParam.DamageData;
		int skillLevel = inputParam.SkillLevel;
		int formulaType = damageData.FormulaType;
		ECalculationType calculateType = (ECalculationType)damageData.CalculateType;
		double num;
		if (formulaType == 0)
		{
			EAttributeType relatedProperty = (EAttributeType)damageData.RelatedProperty;
			int levelValue = AbilityUtils.GetLevelValue<int>(damageData.RateLv(), skillLevel, 0);
			if (calculateType == ECalculationType.Hurt)
			{
				num = Calculation.CalculateHurt(snapshots, inputParam.Element, (EAttackType)damageData.Type, relatedProperty, (double)levelValue, isCritical, augment, amplify, gameplayRatio, 0.0);
			}
			else
			{
				int levelValue2 = AbilityUtils.GetLevelValue<int>(damageData.CureBaseValue(), skillLevel, 0);
				num = Calculation.CalculateHeal(snapshots, (float)levelValue2, relatedProperty, (float)levelValue);
			}
		}
		else
		{
			Calculation.TFormula tformula;
			if (!Calculation.Formulas.TryGetValue(formulaType, out tformula))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "unexpected formula type";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("damageId", damageData.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("formula type", formulaType);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return 0.0;
			}
			num = tformula(snapshots, calculateType, inputParam, skillLevel, isCritical, augment, amplify, (double)inputParam.Accumulation, multiRatio, gameplayRatio, new double[]
			{
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam1(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam2(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam3(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam4(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam5(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam6(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam7(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam8(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam9(), skillLevel, 0),
				(double)AbilityUtils.GetLevelValue<int>(damageData.FormulaParam10(), skillLevel, 0)
			});
		}
		int randomSeed = inputParam.RandomSeed;
		inputParam.RandomSeed = RandomSystem.GetNextRandomSeed(randomSeed, ERandomReason.DamageFluctuation);
		float levelValue3 = (float)AbilityUtils.GetLevelValue<int>(damageData.FluctuationUpper(), skillLevel, 10000);
		int levelValue4 = AbilityUtils.GetLevelValue<int>(damageData.FluctuationLower(), skillLevel, 10000);
		float num2 = ((levelValue3 - (float)levelValue4) * (float)(randomSeed % 10000) + (float)levelValue4) * 0.0001f;
		num = Math.Ceiling(num * (double)inputParam.ExtraRate * (double)num2);
		if (calculateType == ECalculationType.Heal)
		{
			num = -num;
		}
		return num;
	}

	// Token: 0x0601886D RID: 100461 RVA: 0x006E1AE8 File Offset: 0x006DFCE8
	public static void CreateStaticDefaultValue()
	{
		Dictionary<int, Calculation.TFormula> dictionary = new Dictionary<int, Calculation.TFormula>();
		dictionary.Add(1, delegate(SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters)
		{
			double num = Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[3], (EAttributeType)parameters[2]) * (parameters[4] * 9.999999747378752E-05) + parameters[5];
			double num2 = Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[8], (EAttributeType)parameters[7]) * (parameters[6] * 9.999999747378752E-05) + parameters[9] + Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[1], (EAttributeType)parameters[0]) * num;
			if (calculateType == ECalculationType.Heal)
			{
				float num3 = snap.TargetSnapshot.GetCurrentValue(EAttributeType.HealedChange) * 0.0001f;
				float num4 = snap.AttackerSnapshot.GetCurrentValue(EAttributeType.HealChange) * 0.0001f;
				return Math.Max(num2 * (double)Math.Max(0f, 1f + num3 + num4), 0.0);
			}
			return Math.Max(Calculation.CalculateHurt(snap, damageParam.Element, (EAttackType)damageParam.DamageData.Type, (EAttributeType)damageParam.DamageData.RelatedProperty, (double)AbilityUtils.GetLevelValue<int>(damageParam.DamageData.RateLv(), level, 0), isCritical, augment, amplify, gameplayRatio, num2), 0.0);
		});
		dictionary.Add(2, delegate(SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters)
		{
			double num = Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[1], (EAttributeType)parameters[0]) * (parameters[2] * 9.999999747378752E-05) + parameters[3];
			if (calculateType == ECalculationType.Heal)
			{
				return -Math.Min((double)snap.TargetSnapshot.GetCurrentValue(EAttributeType.Life) - num, 0.0);
			}
			return Math.Max((double)snap.TargetSnapshot.GetCurrentValue(EAttributeType.Life) - num, 0.0);
		});
		dictionary.Add(3, (SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters) => Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[1], (EAttributeType)parameters[0]) * (parameters[2] * 9.999999747378752E-05) + parameters[3]);
		dictionary.Add(4, (SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters) => Math.Min(Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[1], (EAttributeType)parameters[0]) * (parameters[2] * 9.999999747378752E-05) + parameters[3], accumulation * (parameters[4] * 9.999999747378752E-05)));
		dictionary.Add(5, (SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters) => (double)snap.TargetSnapshot.GetCurrentValue(EAttributeType.LifeMax) * (parameters[0] * 9.999999747378752E-05) / multiRatio + parameters[1]);
		dictionary.Add(6, (SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters) => Math.Max(Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[1], (EAttributeType)parameters[0]) * (parameters[2] * 9.999999747378752E-05) + Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[4], (EAttributeType)parameters[3]) * (parameters[5] * 9.999999747378752E-05), 0.0));
		dictionary.Add(7, delegate(SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters)
		{
			double val = Calculation.GetAttrFromSnapshots(snap, (EAttrOwnerType)parameters[1], (EAttributeType)parameters[0]) * (parameters[2] * 9.999999747378752E-05) + parameters[3];
			double val2 = (double)snap.TargetSnapshot.GetCurrentValue(EAttributeType.Life) - ((double)snap.TargetSnapshot.GetCurrentValue(EAttributeType.LifeMax) * parameters[4] * 9.999999747378752E-05 + parameters[5]);
			return Math.Max(0.0, Math.Min(val, val2));
		});
		dictionary.Add(1001, delegate(SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, double[] parameters)
		{
			EElementType element = damageParam.Element;
			AttributeSnapshot attackerSnapshot = snap.AttackerSnapshot;
			AttributeSnapshot targetSnapshot = snap.TargetSnapshot;
			int num = (int)attackerSnapshot.GetCurrentValue(EAttributeType.Lv);
			int num2;
			switch (element)
			{
			case EElementType.Ice:
			{
				AbnormalDamageConfig? config = ConfigAbnormalDamageConfigByLevel.GetConfig(num, true);
				num2 = ((config != null) ? config.GetValueOrDefault().Abnormal1003 : 0);
				break;
			}
			case EElementType.Fire:
			{
				AbnormalDamageConfig? config = ConfigAbnormalDamageConfigByLevel.GetConfig(num, true);
				num2 = ((config != null) ? config.GetValueOrDefault().Abnormal1004 : 0);
				break;
			}
			case EElementType.Thunder:
			{
				AbnormalDamageConfig? config = ConfigAbnormalDamageConfigByLevel.GetConfig(num, true);
				num2 = ((config != null) ? config.GetValueOrDefault().Abnormal1002 : 0);
				break;
			}
			case EElementType.Wind:
			{
				AbnormalDamageConfig? config = ConfigAbnormalDamageConfigByLevel.GetConfig(num, true);
				num2 = ((config != null) ? config.GetValueOrDefault().Abnormal1001 : 0);
				break;
			}
			case EElementType.Light:
			{
				AbnormalDamageConfig? config = ConfigAbnormalDamageConfigByLevel.GetConfig(num, true);
				num2 = ((config != null) ? config.GetValueOrDefault().Abnormal1005 : 0);
				break;
			}
			case EElementType.Dark:
			{
				AbnormalDamageConfig? config = ConfigAbnormalDamageConfigByLevel.GetConfig(num, true);
				num2 = ((config != null) ? config.GetValueOrDefault().Abnormal1006 : 0);
				break;
			}
			default:
			{
				AbnormalDamageConfig? config = ConfigAbnormalDamageConfigByLevel.GetConfig(num, true);
				num2 = ((config != null) ? config.GetValueOrDefault().Abnormal1006 : 0);
				break;
			}
			}
			double num3 = (double)num2;
			double num4 = parameters[0] * 9.999999747378752E-05;
			double num5 = Math.Min(Calculation.GetElementDamageReduce(targetSnapshot, element), 1.0);
			double elementResistant = Calculation.GetElementResistant(targetSnapshot, element);
			double elementIgnoreResistance = Calculation.GetElementIgnoreResistance(attackerSnapshot, element);
			double num6;
			if (elementResistant - elementIgnoreResistance <= 0.0)
			{
				num6 = 1.0 - (elementResistant - elementIgnoreResistance) / 2.0;
			}
			else if (elementResistant - elementIgnoreResistance < 0.8)
			{
				num6 = 1.0 - (elementResistant - elementIgnoreResistance);
			}
			else
			{
				num6 = 1.0 / (1.0 + (elementResistant - elementIgnoreResistance) * 5.0);
			}
			float currentValue = targetSnapshot.GetCurrentValue(EAttributeType.Def);
			float num7 = attackerSnapshot.GetCurrentValue(EAttributeType.IgnoreDefRate) * 0.0001f;
			float num8 = Math.Min(2f, 1f / (currentValue * (1f - num7) / (float)(800 + num * 8) + 1f));
			double num9 = Math.Min((double)(targetSnapshot.GetCurrentValue(EAttributeType.DamageReduce) * 0.0001f), 1.0);
			double num10 = Math.Max((double)(attackerSnapshot.GetCurrentValue(EAttributeType.SpecialDamageChange) * 0.0001f), -1.0);
			return num3 * num4 * (double)num8 * num6 * (1.0 - num9) * (1.0 - num5) * (1.0 + num10);
		});
		Calculation._formulas = dictionary;
	}

	// Token: 0x0601886E RID: 100462 RVA: 0x006E1C33 File Offset: 0x006DFE33
	public static void ResetStaticDefaultValue()
	{
		Calculation._formulas = null;
	}

	// Token: 0x0400BD70 RID: 48496
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, Calculation.TFormula> _formulas;

	// Token: 0x02009316 RID: 37654
	// (Invoke) Token: 0x0604A00A RID: 303114
	[NullableContext(0)]
	private delegate double TFormula(SnapshotPayload snap, ECalculationType calculateType, TDamageParam damageParam, int level, bool isCritical, double augment, double amplify, double accumulation, double multiRatio, double gameplayRatio, params double[] parameters);
}
