using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FE1 RID: 12257
[NullableContext(1)]
[Nullable(0)]
public class BreakWeaknessTrigger : Trigger
{
	// Token: 0x06018FB5 RID: 102325 RVA: 0x00715B08 File Offset: 0x00713D08
	[NullableContext(2)]
	public BreakWeaknessTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018FB6 RID: 102326 RVA: 0x00715B19 File Offset: 0x00713D19
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018FB7 RID: 102327 RVA: 0x00715B34 File Offset: 0x00713D34
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, string>(target, EEventName.TriggerBreakWeakness, new Action<Entity, Entity, string>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity, string>(target, EEventName.TriggerBreakWeakness, new Action<Entity, Entity, string>(this.OnEvent));
		}
	}

	// Token: 0x06018FB8 RID: 102328 RVA: 0x00715BA0 File Offset: 0x00713DA0
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, string>(target, EEventName.TriggerBreakWeakness, new Action<Entity, Entity, string>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity, string>(target, EEventName.TriggerBreakWeakness, new Action<Entity, Entity, string>(this.OnEvent));
		}
	}

	// Token: 0x06018FB9 RID: 102329 RVA: 0x00715C0C File Offset: 0x00713E0C
	private void OnEvent(Entity attacker, Entity target, string targetSocket)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = attacker;
		dictionary["Target"] = target;
		dictionary["TargetSocket"] = targetSocket;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018FBA RID: 102330 RVA: 0x00715C70 File Offset: 0x00713E70
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身触发破弱技能时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色触发破弱技能时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色触发破弱技能时触发";
		case ETriggerTargetType.Enemy:
			return "敌人触发破弱技能时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C32C RID: 49964
	protected ETriggerTargetType TargetType;
}
