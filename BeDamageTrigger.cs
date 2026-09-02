using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FD1 RID: 12241
[NullableContext(1)]
[Nullable(0)]
public class BeDamageTrigger : Trigger
{
	// Token: 0x06018F4C RID: 102220 RVA: 0x00712B41 File Offset: 0x00710D41
	[NullableContext(2)]
	public BeDamageTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F4D RID: 102221 RVA: 0x00712B54 File Offset: 0x00710D54
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.CalculateType = (ECalculationType)Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : 0.ToString());
	}

	// Token: 0x06018F4E RID: 102222 RVA: 0x00712B9C File Offset: 0x00710D9C
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !TriggerEventHelper.HasWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			TriggerEventHelper.AddWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F4F RID: 102223 RVA: 0x00712BF4 File Offset: 0x00710DF4
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && TriggerEventHelper.HasWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			TriggerEventHelper.RemoveWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F50 RID: 102224 RVA: 0x00712C4C File Offset: 0x00710E4C
	private void OnEvent(Entity attacker, Entity victim, RequirementPayload req, DamageResult result, FVectorDouble _)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		float damage = result.Damage;
		Damage damageData = result.DamageData;
		if (damageData.CalculateType != (int)this.CalculateType)
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = attacker;
		dictionary["Victim"] = victim;
		dictionary["DamageID"] = damageData.Id;
		dictionary["SkillID"] = req.SkillId.GetValueOrDefault();
		dictionary["SkillType"] = req.SkillGenre.GetValueOrDefault();
		dictionary["DamageType"] = damageData.Type;
		dictionary["DamageSubType"] = damageData.SubType();
		dictionary["ElementType"] = (int)result.Element;
		dictionary["DamageValue"] = -damage;
		dictionary["IsCritical"] = req.IsCritical.GetValueOrDefault();
		dictionary["SkillDamageCount"] = req.SkillDamageCount.GetValueOrDefault(9999);
		dictionary["BulletDamageCount"] = req.BulletDamageCount.GetValueOrDefault(9999);
		string key = "BattleFlags";
		IReadOnlyList<string> battleFlags = req.BattleFlags;
		dictionary[key] = (((battleFlags != null) ? battleFlags.ToArray<string>() : null) ?? Array.Empty<string>());
		dictionary["CounterType"] = (int)req.CounterType.GetValueOrDefault();
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F51 RID: 102225 RVA: 0x00712E04 File Offset: 0x00711004
	public override string GetDebugTriggerType()
	{
		string damageCalculationTypeText = Trigger.GetDamageCalculationTypeText(this.CalculateType);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身受到类型为" + damageCalculationTypeText + "的结算时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色受到类型为" + damageCalculationTypeText + "的结算时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色受到类型为" + damageCalculationTypeText + "的结算时触发";
		case ETriggerTargetType.Enemy:
			return "敌人受到类型为" + damageCalculationTypeText + "的结算时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C306 RID: 49926
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C307 RID: 49927
	protected ECalculationType CalculateType;
}
