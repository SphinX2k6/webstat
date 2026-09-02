using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FC8 RID: 12232
[NullableContext(1)]
[Nullable(0)]
public class HitTriggerIncludingVision : Trigger
{
	// Token: 0x06018F10 RID: 102160 RVA: 0x0071101A File Offset: 0x0070F21A
	[NullableContext(2)]
	public HitTriggerIncludingVision(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F11 RID: 102161 RVA: 0x0071102B File Offset: 0x0070F22B
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F12 RID: 102162 RVA: 0x00711048 File Offset: 0x0070F248
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharHitIncludingVision, new Action<HitInformation, HitContext>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharHitIncludingVision, new Action<HitInformation, HitContext>(this.OnEvent));
		}
	}

	// Token: 0x06018F13 RID: 102163 RVA: 0x007110AC File Offset: 0x0070F2AC
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharHitIncludingVision, new Action<HitInformation, HitContext>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharHitIncludingVision, new Action<HitInformation, HitContext>(this.OnEvent));
		}
	}

	// Token: 0x06018F14 RID: 102164 RVA: 0x00711110 File Offset: 0x0070F310
	private void OnEvent(HitInformation _, HitContext c)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = c.Attacker;
		dictionary["Victim"] = c.Target;
		dictionary["SkillID"] = c.SkillId;
		dictionary["SkillType"] = c.SkillGenre;
		dictionary["BulletID"] = Convert.ToInt64(c.BulletId);
		dictionary["CounterType"] = (int)c.CounterAttackType;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F15 RID: 102165 RVA: 0x007111C8 File Offset: 0x0070F3C8
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身攻击时触发(包括幻象)";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色攻击时触发(包括幻象)";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色攻击时触发(包括幻象)";
		case ETriggerTargetType.Enemy:
			return "敌人角色触发，暂时不支持";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C2EF RID: 49903
	protected ETriggerTargetType TargetType;
}
