using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FD3 RID: 12243
[NullableContext(1)]
[Nullable(0)]
public class KillTrigger : Trigger
{
	// Token: 0x06018F59 RID: 102233 RVA: 0x007131C6 File Offset: 0x007113C6
	[NullableContext(2)]
	public KillTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F5A RID: 102234 RVA: 0x007131D7 File Offset: 0x007113D7
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F5B RID: 102235 RVA: 0x007131F4 File Offset: 0x007113F4
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F5C RID: 102236 RVA: 0x00713258 File Offset: 0x00711458
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharKillTarget, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F5D RID: 102237 RVA: 0x007132BC File Offset: 0x007114BC
	private void OnEvent(Entity attacker, Entity victim, RequirementPayload req, DamageResult result, FVectorDouble hitPos)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		float damage = result.Damage;
		Damage damageData = result.DamageData;
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
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F5E RID: 102238 RVA: 0x007133DC File Offset: 0x007115DC
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身击杀单位时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色击杀单位时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色击杀单位时触发";
		case ETriggerTargetType.Enemy:
			return "敌人角色击杀单位时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C30A RID: 49930
	protected ETriggerTargetType TargetType;
}
