using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;
using CSharpScript.Game.World.Model;
using UnrealEngine;

// Token: 0x02002F1D RID: 12061
[NullableContext(1)]
[Nullable(0)]
public class DamageFilter : BuffEffect
{
	// Token: 0x06018B4E RID: 101198 RVA: 0x006F9D28 File Offset: 0x006F7F28
	public DamageFilter(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B4F RID: 101199 RVA: 0x006F9D38 File Offset: 0x006F7F38
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.Condition = bool.Parse((((extraEffectParameters_ != null && extraEffectParameters_.Length != 0) ? extraEffectParameters_[0] : "0") == "1") ? "true" : "false");
	}

	// Token: 0x06018B50 RID: 101200 RVA: 0x006F9D80 File Offset: 0x006F7F80
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return !this.Condition;
	}

	// Token: 0x06018B51 RID: 101201 RVA: 0x006F9D90 File Offset: 0x006F7F90
	public static bool ApplyEffects(Entity attackerEntity, Entity targetEntity, string bulletId, IReadOnlyList<int> bulletTags, int skillId, long damageId, [Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<string> battleFlags)
	{
		BaseBuffComponent component = attackerEntity.GetComponent<BaseBuffComponent>();
		BaseBuffComponent component2 = targetEntity.GetComponent<BaseBuffComponent>();
		if (component == null || component2 == null)
		{
			return false;
		}
		if (!component2.BuffEffectManager.HasAnyById(DamageFilter.DamageFilterIds))
		{
			return false;
		}
		BaseSkillComponent component3 = attackerEntity.GetComponent<BaseSkillComponent>();
		RequirementPayload requirementPayload = new RequirementPayload();
		if (skillId != 0)
		{
			requirementPayload.SkillId = new int?(skillId);
			SSkillInfo skillInfo = component3.GetSkillInfo(skillId);
			Partial_RequirementPayload partial_RequirementPayload = requirementPayload;
			TEnumAsByte<ESkillGenre>? tenumAsByte = (skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null;
			partial_RequirementPayload.SkillGenre = new int?((tenumAsByte != null) ? ((int)tenumAsByte.GetValueOrDefault()) : -1);
		}
		DamageSnapshot damageSnapshot = (damageId != 0L) ? ModelBase<DamageModel>.Instance.GetDamageSnapshotById(damageId) : null;
		if (damageSnapshot != null)
		{
			requirementPayload.DamageType = new int?(damageSnapshot.Type);
			requirementPayload.DamageSubTypes = damageSnapshot.SubTypes;
			requirementPayload.CalculateType = new int?(damageSnapshot.CalculateType);
			requirementPayload.SmashType = new int?(damageSnapshot.SmashType);
			requirementPayload.ElementType = new EElementType?(ModifyDamageElement.ApplyEffects(component, damageSnapshot.Id) ?? ((EElementType)damageSnapshot.Element));
		}
		requirementPayload.BulletId = new long?(long.Parse(bulletId));
		requirementPayload.BulletTags = bulletTags;
		requirementPayload.BattleFlags = (battleFlags ?? Array.Empty<string>());
		Partial_RequirementPayload partial_RequirementPayload2 = requirementPayload;
		RoleGrowComponent component4 = attackerEntity.GetComponent<RoleGrowComponent>();
		partial_RequirementPayload2.WeaponType = new int?((component4 != null) ? component4.GetWeaponType() : -2);
		foreach (DamageFilter damageFilter in component2.BuffEffectManager.FilterById<DamageFilter>(EExtraEffectId.DamageFilter, null))
		{
			if (damageFilter.Check(requirementPayload, component) == ((bool?)damageFilter.Execute(Array.Empty<object>())).GetValueOrDefault())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400C066 RID: 49254
	private bool Condition;

	// Token: 0x0400C067 RID: 49255
	[StaticVariableRuleIgnore]
	private static readonly EExtraEffectId[] DamageFilterIds = new EExtraEffectId[]
	{
		EExtraEffectId.DamageFilter
	};
}
