using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.World.Model;

// Token: 0x02002EC8 RID: 11976
[NullableContext(1)]
[Nullable(0)]
public abstract class CombatDataBase
{
	// Token: 0x0601898C RID: 100748 RVA: 0x006ED310 File Offset: 0x006EB510
	public CombatDataBase(int attackerId, int targetId = 0)
	{
		this.AttackerId = attackerId;
		this.TargetId = targetId;
		DateTime now = DateTime.Now;
		this.DateCreate = StringUtils.Format("{0}-{1}-{2}", new string[]
		{
			(now.Hour < 10) ? ("0" + now.Hour.ToString()) : now.Hour.ToString(),
			(now.Minute < 10) ? ("0" + now.Minute.ToString()) : now.Minute.ToString(),
			(now.Second < 10) ? ("0" + now.Second.ToString()) : now.Second.ToString()
		});
	}

	// Token: 0x0601898D RID: 100749 RVA: 0x006ED400 File Offset: 0x006EB600
	public override string ToString()
	{
		if (!string.IsNullOrEmpty(this.String))
		{
			return this.String;
		}
		this.String = this.ParseToString();
		return this.String;
	}

	// Token: 0x0601898E RID: 100750
	public abstract string ParseToString();

	// Token: 0x0601898F RID: 100751 RVA: 0x006ED428 File Offset: 0x006EB628
	[NullableContext(2)]
	public static string GetEntityConfigName(int targetId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(targetId);
		if (entity == null)
		{
			return null;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		EEntityType? eentityType = (component != null) ? new EEntityType?(component.GetEntityType()) : null;
		EEntityType? eentityType2 = eentityType;
		EEntityType eentityType3 = EEntityType.Player;
		if (eentityType2.GetValueOrDefault() == eentityType3 & eentityType2 != null)
		{
			int id = component.Valid ? component.GetRoleId() : 0;
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
			if (baseRoleId == 0)
			{
				return null;
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
			if (roleConfig == null)
			{
				return null;
			}
			return ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
		}
		else
		{
			if (eentityType.GetValueOrDefault() == EEntityType.Monster)
			{
				return Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
			}
			return null;
		}
	}

	// Token: 0x06018990 RID: 100752 RVA: 0x006ED504 File Offset: 0x006EB704
	[NullableContext(2)]
	public static string GetSkillConfigName(int entityId, int skillId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return null;
		}
		BaseSkillComponent component = entity.GetComponent<BaseSkillComponent>();
		if (component == null)
		{
			return null;
		}
		SSkillInfo skillInfo = component.GetSkillInfo(skillId);
		if (skillInfo == null)
		{
			return null;
		}
		return skillInfo.SkillName.ToString();
	}

	// Token: 0x06018991 RID: 100753 RVA: 0x006ED550 File Offset: 0x006EB750
	[return: Nullable(new byte[]
	{
		1,
		2
	})]
	public static string[] GetEntityConfigNameAndSkillName(int entityId, long damageId, int skillId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		string text = null;
		string text2 = null;
		if (entity == null)
		{
			return new string[2];
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		EEntityType? eentityType = (component != null) ? new EEntityType?(component.GetEntityType()) : null;
		EEntityType? eentityType2 = eentityType;
		EEntityType eentityType3 = EEntityType.Player;
		if (eentityType2.GetValueOrDefault() == eentityType3 & eentityType2 != null)
		{
			int id = component.Valid ? component.GetRoleId() : 0;
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
			if (baseRoleId == 0)
			{
				return new string[2];
			}
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
			if (roleConfig == null)
			{
				return new string[2];
			}
			text = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
			IReadOnlyList<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleConfig.Value.SkillId);
			int num = -1;
			if (skillList != null)
			{
				foreach (Aki.Config.Skill skill in skillList)
				{
					if (CombatDataBase.SkillContainsDamage(skill, damageId))
					{
						text2 = CharacterStatisticsComponent.skillTypeToString[skill.SkillType - 1];
						num = skill.SkillType;
						break;
					}
				}
			}
			if (num < 0)
			{
				Damage? damageConfigById = ModelBase<DamageModel>.Instance.GetDamageConfigById(damageId);
				if (((damageConfigById != null) ? damageConfigById.GetValueOrDefault().Type : -1) == 5)
				{
					text2 = "幻象技能";
				}
			}
			return new string[]
			{
				text,
				text2
			};
		}
		else
		{
			if (eentityType.GetValueOrDefault() == EEntityType.Monster)
			{
				text = Singleton<PublicUtil>.Instance.GetConfigTextByKey(component.GetEntityTidName() ?? "");
				BaseSkillComponent component2 = entity.GetComponent<BaseSkillComponent>();
				string text3;
				if (component2 == null)
				{
					text3 = null;
				}
				else
				{
					SSkillInfo skillInfo = component2.GetSkillInfo(skillId);
					text3 = ((skillInfo != null) ? skillInfo.SkillName.ToString() : null);
				}
				text2 = text3;
				return new string[]
				{
					text,
					text2
				};
			}
			return new string[2];
		}
	}

	// Token: 0x06018992 RID: 100754 RVA: 0x006ED750 File Offset: 0x006EB950
	private unsafe static bool SkillContainsDamage(Aki.Config.Skill skill, long damageId)
	{
		try
		{
			Span<long> damageListBytes = skill.GetDamageListBytes();
			for (int i = 0; i < damageListBytes.Length; i++)
			{
				long num = *damageListBytes[i];
				if (num == damageId || num == (long)((int)damageId))
				{
					return true;
				}
			}
		}
		catch
		{
		}
		return false;
	}

	// Token: 0x0400BE59 RID: 48729
	protected readonly string DateCreate;

	// Token: 0x0400BE5A RID: 48730
	protected string String = "";

	// Token: 0x0400BE5B RID: 48731
	public readonly int AttackerId;

	// Token: 0x0400BE5C RID: 48732
	public readonly int TargetId;
}
