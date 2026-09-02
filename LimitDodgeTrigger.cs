using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FCD RID: 12237
[NullableContext(1)]
[Nullable(0)]
public class LimitDodgeTrigger : Trigger
{
	// Token: 0x06018F30 RID: 102192 RVA: 0x00711CC8 File Offset: 0x0070FEC8
	[NullableContext(2)]
	public LimitDodgeTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F31 RID: 102193 RVA: 0x00711CE0 File Offset: 0x0070FEE0
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.Source = Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : "1");
	}

	// Token: 0x06018F32 RID: 102194 RVA: 0x00711D18 File Offset: 0x0070FF18
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target == null)
		{
			return;
		}
		if ((this.Source & 1) != 0 && !Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharLimitDodge, new Action<Entity, Entity, int, long>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharLimitDodge, new Action<Entity, Entity, int, long>(this.OnEvent));
		}
		if ((this.Source & 2) != 0)
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

	// Token: 0x06018F33 RID: 102195 RVA: 0x00711DFC File Offset: 0x0070FFFC
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target == null)
		{
			return;
		}
		if ((this.Source & 1) != 0 && Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharLimitDodge, new Action<Entity, Entity, int, long>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharLimitDodge, new Action<Entity, Entity, int, long>(this.OnEvent));
		}
		if ((this.Source & 2) != 0)
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

	// Token: 0x06018F34 RID: 102196 RVA: 0x00711EDE File Offset: 0x007100DE
	protected void OnEvent(Entity attacker, Entity victim, int skillId, long bulletId)
	{
		this.OnEventInternal(attacker, victim, skillId, bulletId);
	}

	// Token: 0x06018F35 RID: 102197 RVA: 0x00711EEB File Offset: 0x007100EB
	protected void OnHitLocal(HitInformation _, HitContext hitContext)
	{
		this.OnEventInternal(hitContext.Attacker, hitContext.Target, hitContext.SkillId, Convert.ToInt64(hitContext.BulletId));
	}

	// Token: 0x06018F36 RID: 102198 RVA: 0x00711F10 File Offset: 0x00710110
	protected void OnHitRemote(HitContext hitContext)
	{
		this.OnEventInternal(hitContext.Attacker, hitContext.Target, hitContext.SkillId, Convert.ToInt64(hitContext.BulletId));
	}

	// Token: 0x06018F37 RID: 102199 RVA: 0x00711F38 File Offset: 0x00710138
	private void OnEventInternal(Entity attacker, Entity victim, int skillId, long bulletId)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(attacker.Id);
		SSkillInfo sskillInfo;
		if (entity == null)
		{
			sskillInfo = null;
		}
		else
		{
			BaseSkillComponent component = entity.GetComponent<BaseSkillComponent>();
			sskillInfo = ((component != null) ? component.GetSkillInfo(skillId) : null);
		}
		SSkillInfo sskillInfo2 = sskillInfo;
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = attacker;
		dictionary["Victim"] = victim;
		dictionary["SkillID"] = skillId;
		string key = "SkillType";
		TEnumAsByte<ESkillGenre>? tenumAsByte = (sskillInfo2 != null) ? new TEnumAsByte<ESkillGenre>?(sskillInfo2.SkillGenre) : null;
		dictionary[key] = (int)((tenumAsByte != null) ? tenumAsByte.GetValueOrDefault() : 0);
		dictionary["BulletID"] = bulletId;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F38 RID: 102200 RVA: 0x00712018 File Offset: 0x00710218
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身极限闪避时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色极限闪避时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色极限闪避时触发";
		case ETriggerTargetType.Enemy:
			return "敌人极限闪避时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C2FB RID: 49915
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C2FC RID: 49916
	private int Source = 1;

	// Token: 0x0400C2FD RID: 49917
	private const int INVALID_HIT_COUNT = 9999;
}
