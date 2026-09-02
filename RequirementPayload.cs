using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002F12 RID: 12050
public class RequirementPayload : Partial_RequirementPayload
{
	// Token: 0x06018B14 RID: 101140 RVA: 0x006F84B0 File Offset: 0x006F66B0
	public RequirementPayload()
	{
		this.SkillId = new int?(-1);
		this.SkillGenre = new int?(-1);
		this.BattleFlags = Array.Empty<string>();
		this.CalculateType = new int?(-1);
		this.DamageType = new int?(-1);
		this.DamageSubTypes = Array.Empty<int>();
		this.SmashType = new int?(-1);
		this.IsCritical = new bool?(false);
		this.IsImmune = new bool?(false);
		this.IsTargetKilled = new bool?(false);
		this.ElementType = new EElementType?(EElementType.Physical);
		this.WeaponType = new int?(-1);
		this.PartId = new int?(-1);
		this.PartTag = new int?(0);
		this.BulletTags = Array.Empty<int>();
		this.SourceType = new DamageSourceType?(DamageSourceType.FromBullet);
	}

	// Token: 0x06018B15 RID: 101141 RVA: 0x006F8580 File Offset: 0x006F6780
	[NullableContext(1)]
	public RequirementPayload PartialAssign(Partial_RequirementPayload payload)
	{
		if (payload.SkillId != null)
		{
			this.SkillId = payload.SkillId;
		}
		if (payload.SkillGenre != null)
		{
			this.SkillGenre = payload.SkillGenre;
		}
		if (payload.BattleFlags != null)
		{
			this.BattleFlags = payload.BattleFlags;
		}
		if (payload.CalculateType != null)
		{
			this.CalculateType = payload.CalculateType;
		}
		if (payload.DamageType != null)
		{
			this.DamageType = payload.DamageType;
		}
		if (payload.DamageSubTypes != null)
		{
			this.DamageSubTypes = payload.DamageSubTypes;
		}
		if (payload.SmashType != null)
		{
			this.SmashType = payload.SmashType;
		}
		if (payload.BulletId != null)
		{
			this.BulletId = payload.BulletId;
		}
		if (payload.DamageId != null)
		{
			this.DamageId = payload.DamageId;
		}
		if (payload.BuffId != null)
		{
			this.BuffId = payload.BuffId;
		}
		if (payload.IsCritical != null)
		{
			this.IsCritical = payload.IsCritical;
		}
		if (payload.IsImmune != null)
		{
			this.IsImmune = payload.IsImmune;
		}
		if (payload.IsTargetKilled != null)
		{
			this.IsTargetKilled = payload.IsTargetKilled;
		}
		if (payload.ElementType != null)
		{
			this.ElementType = payload.ElementType;
		}
		if (payload.WeaponType != null)
		{
			this.WeaponType = payload.WeaponType;
		}
		if (payload.PartId != null)
		{
			this.PartId = payload.PartId;
		}
		if (payload.PartTag != null)
		{
			this.PartTag = payload.PartTag;
		}
		if (payload.BulletTags != null)
		{
			this.BulletTags = payload.BulletTags;
		}
		if (payload.SkillDamageCount != null)
		{
			this.SkillDamageCount = payload.SkillDamageCount;
		}
		if (payload.BulletDamageCount != null)
		{
			this.BulletDamageCount = payload.BulletDamageCount;
		}
		if (payload.BulletMessageId != null)
		{
			this.BulletMessageId = payload.BulletMessageId;
		}
		if (payload.SkillMessageId != null)
		{
			this.SkillMessageId = payload.SkillMessageId;
		}
		if (payload.CounterType != null)
		{
			this.CounterType = payload.CounterType;
		}
		if (payload.SourceType != null)
		{
			this.SourceType = payload.SourceType;
		}
		if (payload.ChangeWeaknessType != null)
		{
			this.ChangeWeaknessType = payload.ChangeWeaknessType;
		}
		return this;
	}
}
