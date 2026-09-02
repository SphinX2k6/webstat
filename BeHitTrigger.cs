using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FC6 RID: 12230
[NullableContext(1)]
[Nullable(0)]
public class BeHitTrigger : Trigger
{
	// Token: 0x06018F00 RID: 102144 RVA: 0x00710A5C File Offset: 0x0070EC5C
	[NullableContext(2)]
	public BeHitTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F01 RID: 102145 RVA: 0x00710A6D File Offset: 0x0070EC6D
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F02 RID: 102146 RVA: 0x00710A88 File Offset: 0x0070EC88
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			if (!Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeHitRemote, new Action<HitContext>(this.OnHitRemote)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharBeHitRemote, new Action<HitContext>(this.OnHitRemote));
			}
		}
	}

	// Token: 0x06018F03 RID: 102147 RVA: 0x00710B20 File Offset: 0x0070ED20
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharBeHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeHitRemote, new Action<HitContext>(this.OnHitRemote)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharBeHitRemote, new Action<HitContext>(this.OnHitRemote));
			}
		}
	}

	// Token: 0x06018F04 RID: 102148 RVA: 0x00710BB8 File Offset: 0x0070EDB8
	protected void OnHitLocal(HitInformation _, HitContext hitContext)
	{
		this.OnEvent(hitContext);
	}

	// Token: 0x06018F05 RID: 102149 RVA: 0x00710BC1 File Offset: 0x0070EDC1
	protected void OnHitRemote(HitContext hitContext)
	{
		this.OnEvent(hitContext);
	}

	// Token: 0x06018F06 RID: 102150 RVA: 0x00710BCC File Offset: 0x0070EDCC
	protected void OnEvent(HitContext hitContext)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = hitContext.Attacker;
		dictionary["Victim"] = hitContext.Target;
		dictionary["SkillID"] = hitContext.SkillId;
		dictionary["SkillType"] = hitContext.SkillGenre;
		dictionary["BulletID"] = Convert.ToInt64(hitContext.BulletId);
		dictionary["CounterType"] = (int)hitContext.CounterAttackType;
		dictionary["SkillHitCount"] = hitContext.SkillHitCount.GetValueOrDefault(9999);
		dictionary["BulletHitCount"] = hitContext.BulletHitCount.GetValueOrDefault(9999);
		dictionary["BattleFlags"] = hitContext.BattleFlags;
		Dictionary<string, TFormulaValue> extraParams = dictionary;
		base.EvaluateAndExecute(extraParams);
	}

	// Token: 0x06018F07 RID: 102151 RVA: 0x00710CDC File Offset: 0x0070EEDC
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身受击时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色受击时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色受击时触发";
		case ETriggerTargetType.Enemy:
			return "敌人角色触发，暂时不支持";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C2EC RID: 49900
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C2ED RID: 49901
	public const int INVALID_HIT_COUNT = 9999;
}
