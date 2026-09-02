using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FD2 RID: 12242
[NullableContext(1)]
[Nullable(0)]
public class DeathTrigger : Trigger
{
	// Token: 0x06018F52 RID: 102226 RVA: 0x00712E86 File Offset: 0x00711086
	[NullableContext(2)]
	public DeathTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F53 RID: 102227 RVA: 0x00712E97 File Offset: 0x00711097
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.ListenDeathType = (DeathTrigger.EListenDeathType)Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : "0");
	}

	// Token: 0x06018F54 RID: 102228 RVA: 0x00712ED0 File Offset: 0x007110D0
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target == null)
		{
			return;
		}
		if (this.ListenDeathType == DeathTrigger.EListenDeathType.DamageDeath && !Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeKilled, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharBeKilled, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
			return;
		}
		if (this.ListenDeathType == DeathTrigger.EListenDeathType.AllDeath && !Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharOnRoleDeadBefore, new Action(this.OnDeathBefore)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharOnRoleDeadBefore, new Action(this.OnDeathBefore));
		}
	}

	// Token: 0x06018F55 RID: 102229 RVA: 0x00712F84 File Offset: 0x00711184
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target == null)
		{
			return;
		}
		if (this.ListenDeathType == DeathTrigger.EListenDeathType.DamageDeath && Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeKilled, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharBeKilled, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
			return;
		}
		if (this.ListenDeathType == DeathTrigger.EListenDeathType.AllDeath && Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharOnRoleDeadBefore, new Action(this.OnDeathBefore)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharOnRoleDeadBefore, new Action(this.OnDeathBefore));
		}
	}

	// Token: 0x06018F56 RID: 102230 RVA: 0x00713038 File Offset: 0x00711238
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

	// Token: 0x06018F57 RID: 102231 RVA: 0x00713157 File Offset: 0x00711357
	private void OnDeathBefore()
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		base.EvaluateAndExecute(new Dictionary<string, TFormulaValue>());
	}

	// Token: 0x06018F58 RID: 102232 RVA: 0x0071317C File Offset: 0x0071137C
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身死亡时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色死亡时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色死亡时触发";
		case ETriggerTargetType.Enemy:
			return "敌人角色死亡时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C308 RID: 49928
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C309 RID: 49929
	protected DeathTrigger.EListenDeathType ListenDeathType;

	// Token: 0x02009349 RID: 37705
	[NullableContext(0)]
	protected enum EListenDeathType
	{
		// Token: 0x0403106F RID: 200815
		DamageDeath,
		// Token: 0x04031070 RID: 200816
		AllDeath
	}
}
