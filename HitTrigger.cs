using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Utils;

// Token: 0x02002FC7 RID: 12231
[NullableContext(1)]
[Nullable(0)]
public class HitTrigger : Trigger
{
	// Token: 0x06018F08 RID: 102152 RVA: 0x00710D26 File Offset: 0x0070EF26
	[NullableContext(2)]
	public HitTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F09 RID: 102153 RVA: 0x00710D37 File Offset: 0x0070EF37
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F0A RID: 102154 RVA: 0x00710D54 File Offset: 0x0070EF54
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			if (!TriggerEventHelper.HasWithTarget(target, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal)))
			{
				TriggerEventHelper.AddWithTarget(target, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal));
			}
			if (!TriggerEventHelper.HasWithTarget(target, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote)))
			{
				TriggerEventHelper.AddWithTarget(target, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote));
			}
		}
	}

	// Token: 0x06018F0B RID: 102155 RVA: 0x00710DD8 File Offset: 0x0070EFD8
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			if (TriggerEventHelper.HasWithTarget(target, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal)))
			{
				TriggerEventHelper.RemoveWithTarget(target, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal));
			}
			if (TriggerEventHelper.HasWithTarget(target, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote)))
			{
				TriggerEventHelper.RemoveWithTarget(target, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote));
			}
		}
	}

	// Token: 0x06018F0C RID: 102156 RVA: 0x00710E5A File Offset: 0x0070F05A
	protected void OnHitLocal(HitInformation _, HitContext hitContext)
	{
		this.OnEvent(hitContext);
	}

	// Token: 0x06018F0D RID: 102157 RVA: 0x00710E63 File Offset: 0x0070F063
	protected void OnHitRemote(HitContext hitContext)
	{
		this.OnEvent(hitContext);
	}

	// Token: 0x06018F0E RID: 102158 RVA: 0x00710E6C File Offset: 0x0070F06C
	protected virtual void OnEvent(HitContext hitContext)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Entity entity = hitContext.Attacker;
		if (entity != null && FollowUtils.IsFollowShooterByEntity(entity))
		{
			entity = FollowUtils.ShouldForwardToFrontChar(entity);
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Attacker"] = entity;
		dictionary["Victim"] = hitContext.Target;
		dictionary["SkillID"] = hitContext.SkillId;
		dictionary["SkillType"] = hitContext.SkillGenre;
		dictionary["BulletID"] = Convert.ToInt64(hitContext.BulletId);
		dictionary["CounterType"] = (int)hitContext.CounterAttackType;
		dictionary["SkillHitCount"] = hitContext.SkillHitCount.GetValueOrDefault(9999);
		dictionary["SkillHitCountByVictim"] = hitContext.SkillHitCountByVictim.GetValueOrDefault(9999);
		dictionary["BulletHitCount"] = hitContext.BulletHitCount.GetValueOrDefault(9999);
		dictionary["BulletHitCountByVictim"] = hitContext.BulletHitCountByVictim.GetValueOrDefault(9999);
		dictionary["BattleFlags"] = hitContext.BattleFlags;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F0F RID: 102159 RVA: 0x00710FD0 File Offset: 0x0070F1D0
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身攻击时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色攻击时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色攻击时触发";
		case ETriggerTargetType.Enemy:
			return "敌人角色触发，暂时不支持";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C2EE RID: 49902
	protected ETriggerTargetType TargetType;
}
