using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FDB RID: 12251
[NullableContext(1)]
[Nullable(0)]
public class DamageIdTrigger : Trigger
{
	// Token: 0x06018F8B RID: 102283 RVA: 0x00714982 File Offset: 0x00712B82
	[NullableContext(2)]
	public DamageIdTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F8C RID: 102284 RVA: 0x007149A0 File Offset: 0x00712BA0
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		double num = Convert.ToDouble((triggerParams.Length > 1) ? triggerParams[1] : "0");
		this.DistSquared = num * num;
		this.ListenDamageIds.Clear();
		string[] array = ((triggerParams.Length > 2) ? triggerParams[2] : string.Empty).Split('#', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			long item;
			if (long.TryParse(array[i], out item))
			{
				this.ListenDamageIds.Add(item);
			}
		}
	}

	// Token: 0x06018F8D RID: 102285 RVA: 0x00714A30 File Offset: 0x00712C30
	protected override void OnActive()
	{
		if (this.TargetType == ETriggerTargetType.Enemy)
		{
			Singleton<EventSystem>.Instance.Add<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(EEventName.GlobalCharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
			return;
		}
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F8E RID: 102286 RVA: 0x00714AB8 File Offset: 0x00712CB8
	protected override void OnInactive()
	{
		if (this.TargetType == ETriggerTargetType.Enemy)
		{
			Singleton<EventSystem>.Instance.Remove<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(EEventName.GlobalCharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
			return;
		}
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEvent));
		}
	}

	// Token: 0x06018F8F RID: 102287 RVA: 0x00714B40 File Offset: 0x00712D40
	private void OnEvent(Entity attacker, Entity victim, RequirementPayload req, DamageResult result, FVectorDouble hitPos)
	{
		long id = result.DamageData.Id;
		bool flag = false;
		for (int i = 0; i < this.ListenDamageIds.Count; i++)
		{
			if (this.ListenDamageIds[i] == id)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		bool flag2;
		if (ownerTriggerComp == null)
		{
			flag2 = true;
		}
		else
		{
			Entity entity = ownerTriggerComp.Entity;
			flag2 = !((entity != null) ? new bool?(entity.Valid) : null).GetValueOrDefault();
		}
		if (flag2)
		{
			return;
		}
		if (this.TargetType == ETriggerTargetType.Enemy)
		{
			CharacterTriggerComponent ownerTriggerComp2 = base.OwnerTriggerComp;
			ECamp? ecamp;
			if (ownerTriggerComp2 == null)
			{
				ecamp = null;
			}
			else
			{
				Entity entity2 = ownerTriggerComp2.Entity;
				if (entity2 == null)
				{
					ecamp = null;
				}
				else
				{
					CharacterActorComponent component = entity2.GetComponent<CharacterActorComponent>();
					ecamp = ((component != null) ? new ECamp?(component.Actor.Camp) : null);
				}
			}
			ECamp? ecamp2 = ecamp;
			CharacterActorComponent component2 = victim.GetComponent<CharacterActorComponent>();
			ECamp? ecamp3 = (component2 != null) ? new ECamp?(component2.Actor.Camp) : null;
			if (ecamp2 == null || ecamp3 == null)
			{
				return;
			}
			if (CampUtils.GetCampRelationship(ecamp2.Value, ecamp3.Value) != ERelation.Enemy)
			{
				return;
			}
		}
		CharacterTriggerComponent ownerTriggerComp3 = base.OwnerTriggerComp;
		Vector vector;
		if (ownerTriggerComp3 == null)
		{
			vector = null;
		}
		else
		{
			Entity entity3 = ownerTriggerComp3.Entity;
			if (entity3 == null)
			{
				vector = null;
			}
			else
			{
				CharacterActorComponent component3 = entity3.GetComponent<CharacterActorComponent>();
				vector = ((component3 != null) ? component3.ActorLocationProxy : null);
			}
		}
		Vector vector2 = vector;
		CharacterActorComponent component4 = victim.GetComponent<CharacterActorComponent>();
		Vector vector3 = (component4 != null) ? component4.ActorLocationProxy : null;
		if (vector2 == null || vector3 == null)
		{
			return;
		}
		if (Vector.DistSquared(vector2, vector3) > this.DistSquared)
		{
			return;
		}
		base.EvaluateAndExecute(null);
	}

	// Token: 0x06018F90 RID: 102288 RVA: 0x00714CEC File Offset: 0x00712EEC
	public override string GetDebugTriggerType()
	{
		string str = string.Join<long>(",", this.ListenDamageIds);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身受到伤害结算Id" + str + "触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色受到伤害结算Id" + str + "触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色受到伤害结算Id" + str + "触发";
		case ETriggerTargetType.Enemy:
			return "敌人触发受到伤害结算Id" + str + "触发";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C31C RID: 49948
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C31D RID: 49949
	protected double DistSquared;

	// Token: 0x0400C31E RID: 49950
	protected readonly List<long> ListenDamageIds = new List<long>();
}
