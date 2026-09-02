using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FCF RID: 12239
[NullableContext(1)]
[Nullable(0)]
public class DamageTrigger : Trigger
{
	// Token: 0x06018F40 RID: 102208 RVA: 0x007124FA File Offset: 0x007106FA
	[NullableContext(2)]
	public DamageTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F41 RID: 102209 RVA: 0x0071250C File Offset: 0x0071070C
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.CalculateType = (ECalculationType)Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : 0.ToString());
	}

	// Token: 0x06018F42 RID: 102210 RVA: 0x00712554 File Offset: 0x00710754
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !TriggerEventHelper.HasWithTarget(target, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			TriggerEventHelper.AddWithTarget(target, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F43 RID: 102211 RVA: 0x007125AC File Offset: 0x007107AC
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && TriggerEventHelper.HasWithTarget(target, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			TriggerEventHelper.RemoveWithTarget(target, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F44 RID: 102212 RVA: 0x00712604 File Offset: 0x00710804
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
		Entity entity = attacker;
		if (FollowUtils.IsFollowShooterByEntity(entity))
		{
			entity = FollowUtils.ShouldForwardToFrontChar(entity);
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = entity;
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
		dictionary["SkillDamageCountByVictim"] = req.SkillDamageCountByVictim.GetValueOrDefault(9999);
		string key = "BattleFlags";
		IReadOnlyList<string> battleFlags = req.BattleFlags;
		dictionary[key] = (((battleFlags != null) ? battleFlags.ToArray<string>() : null) ?? Array.Empty<string>());
		dictionary["CounterType"] = (int)req.CounterType.GetValueOrDefault();
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F45 RID: 102213 RVA: 0x007127CC File Offset: 0x007109CC
	public override string GetDebugTriggerType()
	{
		string damageCalculationTypeText = Trigger.GetDamageCalculationTypeText(this.CalculateType);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身造成类型为" + damageCalculationTypeText + "的结算时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色造成类型为" + damageCalculationTypeText + "的结算时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色造成类型为" + damageCalculationTypeText + "的结算时触发";
		case ETriggerTargetType.Enemy:
			return "敌人角色造成类型为" + damageCalculationTypeText + "的结算时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C302 RID: 49922
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C303 RID: 49923
	protected ECalculationType CalculateType;
}
