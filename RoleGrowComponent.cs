using System;
using System.Runtime.CompilerServices;

// Token: 0x020031F3 RID: 12787
[NullableContext(2)]
[Nullable(0)]
public class RoleGrowComponent : EntityComponent
{
	// Token: 0x0601A885 RID: 108677 RVA: 0x007D9360 File Offset: 0x007D7560
	protected override bool OnStart()
	{
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.InitStartingRestriction();
		CreatureDataComponent creatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		int playerId = creatureDataComponent.GetPlayerId();
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int num = playerId;
		bool isSelf = id.GetValueOrDefault() == num & id != null;
		int roleId = creatureDataComponent.GetRoleId();
		this.WeaponType = creatureDataComponent.GetRoleConfig().Value.WeaponType;
		this.RoleInstance = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, isSelf);
		return true;
	}

	// Token: 0x0601A886 RID: 108678 RVA: 0x007D93EF File Offset: 0x007D75EF
	protected override bool OnEnd()
	{
		return true;
	}

	// Token: 0x0601A887 RID: 108679 RVA: 0x007D93F2 File Offset: 0x007D75F2
	private void InitStartingRestriction()
	{
		this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.快速攀爬禁止.出生专用"]));
		this.TagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.滑翔禁止.出生专用"]));
	}

	// Token: 0x0601A888 RID: 108680 RVA: 0x007D9432 File Offset: 0x007D7632
	public int GetWeaponType()
	{
		if (this.WeaponType != 0)
		{
			return this.WeaponType;
		}
		return 0;
	}

	// Token: 0x0601A889 RID: 108681 RVA: 0x007D9444 File Offset: 0x007D7644
	public int GetSkillLevelBySkillInfoId(long skillInfoId)
	{
		if (this.RoleInstance != null)
		{
			return this.RoleInstance.GetSkillData().GetReferencedSkillLevel(skillInfoId, ERoleSkillReferenceType.SkillInfo, null);
		}
		return 0;
	}

	// Token: 0x0601A88A RID: 108682 RVA: 0x007D9463 File Offset: 0x007D7663
	public int GetSkillLevelByBuffId(long buffId)
	{
		if (this.RoleInstance != null)
		{
			return this.RoleInstance.GetSkillData().GetReferencedSkillLevel(buffId, ERoleSkillReferenceType.Buff, null);
		}
		return 0;
	}

	// Token: 0x0601A88B RID: 108683 RVA: 0x007D9482 File Offset: 0x007D7682
	public int GetSkillLevelByDamageId(long damageId)
	{
		if (this.RoleInstance != null)
		{
			return this.RoleInstance.GetSkillData().GetReferencedSkillLevel(damageId, ERoleSkillReferenceType.Damage, null);
		}
		return 0;
	}

	// Token: 0x0601A88C RID: 108684 RVA: 0x007D94A4 File Offset: 0x007D76A4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleGrowComponent roleGrowComponent = (RoleGrowComponent)componentTemplate;
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (roleGrowComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("RoleInstance"))
		{
			if (roleGrowComponent.RoleInstance == null)
			{
				this.RoleInstance = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<RoleDataBase>(this.RoleInstance), "RoleInstance"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("WeaponType"))
		{
			this.WeaponType = roleGrowComponent.WeaponType;
		}
		return true;
	}

	// Token: 0x0400D679 RID: 54905
	private BaseTagComponent TagComponent;

	// Token: 0x0400D67A RID: 54906
	private RoleDataBase RoleInstance;

	// Token: 0x0400D67B RID: 54907
	private int WeaponType;
}
