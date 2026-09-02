using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FD0 RID: 12240
[NullableContext(1)]
[Nullable(0)]
public class GlobalDamageTrigger : Trigger
{
	// Token: 0x06018F46 RID: 102214 RVA: 0x0071284E File Offset: 0x00710A4E
	[NullableContext(2)]
	public GlobalDamageTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F47 RID: 102215 RVA: 0x00712860 File Offset: 0x00710A60
	public override void OnInitParams(string[] triggerParams)
	{
		this.CalculateType = (ECalculationType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : 0.ToString());
		double num = Convert.ToDouble((triggerParams.Length > 1) ? triggerParams[1] : "0");
		this.DistSquared = num * num;
	}

	// Token: 0x06018F48 RID: 102216 RVA: 0x007128A9 File Offset: 0x00710AA9
	protected override void OnActive()
	{
		Singleton<EventSystem>.Instance.Add<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(EEventName.GlobalCharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
	}

	// Token: 0x06018F49 RID: 102217 RVA: 0x007128C4 File Offset: 0x00710AC4
	protected override void OnInactive()
	{
		Singleton<EventSystem>.Instance.Remove<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(EEventName.GlobalCharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
	}

	// Token: 0x06018F4A RID: 102218 RVA: 0x007128E0 File Offset: 0x00710AE0
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
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		bool flag;
		if (ownerTriggerComp == null)
		{
			flag = true;
		}
		else
		{
			Entity entity = ownerTriggerComp.Entity;
			flag = !((entity != null) ? new bool?(entity.Valid) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return;
		}
		CharacterTriggerComponent ownerTriggerComp2 = base.OwnerTriggerComp;
		global::Vector vector;
		if (ownerTriggerComp2 == null)
		{
			vector = null;
		}
		else
		{
			Entity entity2 = ownerTriggerComp2.Entity;
			if (entity2 == null)
			{
				vector = null;
			}
			else
			{
				CharacterActorComponent component = entity2.GetComponent<CharacterActorComponent>();
				vector = ((component != null) ? component.ActorLocationProxy : null);
			}
		}
		global::Vector vector2 = vector;
		CharacterActorComponent component2 = victim.GetComponent<CharacterActorComponent>();
		global::Vector vector3 = (component2 != null) ? component2.ActorLocationProxy : null;
		if (vector2 == null || vector3 == null)
		{
			return;
		}
		if (global::Vector.DistSquared(vector2, vector3) > this.DistSquared)
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

	// Token: 0x06018F4B RID: 102219 RVA: 0x00712B25 File Offset: 0x00710D25
	public override string GetDebugTriggerType()
	{
		return "全局监听类型为" + Trigger.GetDamageCalculationTypeText(this.CalculateType) + "的结算时触发";
	}

	// Token: 0x0400C304 RID: 49924
	protected ECalculationType CalculateType;

	// Token: 0x0400C305 RID: 49925
	protected double DistSquared;
}
