using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FDD RID: 12253
[NullableContext(1)]
[Nullable(0)]
public class ShieldTrigger : Trigger
{
	// Token: 0x06018F97 RID: 102295 RVA: 0x007150FF File Offset: 0x007132FF
	[NullableContext(2)]
	public ShieldTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F98 RID: 102296 RVA: 0x00715110 File Offset: 0x00713310
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F99 RID: 102297 RVA: 0x0071512C File Offset: 0x0071332C
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			AbilityEvent.Instance.Add(target, EAbilityEventName.ShieldChange, 0L, new Action<Entity, float, float, int, int>(this.OnEvent));
		}
	}

	// Token: 0x06018F9A RID: 102298 RVA: 0x00715174 File Offset: 0x00713374
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			AbilityEvent.Instance.Remove(target, EAbilityEventName.ShieldChange, 0L, new Action<Entity, float, float, int, int>(this.OnEvent));
		}
	}

	// Token: 0x06018F9B RID: 102299 RVA: 0x007151BC File Offset: 0x007133BC
	private void OnEvent(Entity victim, float oldShieldValue, float newShieldValue, int updateType, int shieldId)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Victim"] = victim;
		dictionary["OldShieldValue"] = oldShieldValue;
		dictionary["NewShieldValue"] = newShieldValue;
		dictionary["UpdateType"] = updateType;
		dictionary["ShieldId"] = shieldId;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F9C RID: 102300 RVA: 0x00715244 File Offset: 0x00713444
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身护盾变更时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色护盾变更时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色护盾变更时触发";
		case ETriggerTargetType.Enemy:
			return "敌人监听,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C325 RID: 49957
	protected ETriggerTargetType TargetType;
}
