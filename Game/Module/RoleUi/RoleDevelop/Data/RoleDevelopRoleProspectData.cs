using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.Data
{
	// Token: 0x020050DB RID: 20699
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopRoleProspectData : RoleDevelopRoleBaseData
	{
		// Token: 0x060355CD RID: 218573 RVA: 0x00D62E3E File Offset: 0x00D6103E
		public RoleDevelopRoleProspectData(int id) : base(id)
		{
		}

		// Token: 0x060355CE RID: 218574 RVA: 0x00D62E47 File Offset: 0x00D61047
		public override ERoleDevelopRoleType GetRoleType()
		{
			return ERoleDevelopRoleType.Prospect;
		}

		// Token: 0x060355CF RID: 218575 RVA: 0x00D62E4A File Offset: 0x00D6104A
		private IRoleDevProsProjectConfig GetDevPropsProjectConfig()
		{
			return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(this.Id);
		}

		// Token: 0x060355D0 RID: 218576 RVA: 0x00D62E5C File Offset: 0x00D6105C
		public override string GetName()
		{
			return this.GetDevPropsProjectConfig().RoleName;
		}

		// Token: 0x060355D1 RID: 218577 RVA: 0x00D62E69 File Offset: 0x00D61069
		public override int GetElementId()
		{
			return this.GetDevPropsProjectConfig().ElementId;
		}

		// Token: 0x060355D2 RID: 218578 RVA: 0x00D62E76 File Offset: 0x00D61076
		public override string GetRoleIllustrationPath()
		{
			return this.GetDevPropsProjectConfig().FormationRoleCard;
		}

		// Token: 0x060355D3 RID: 218579 RVA: 0x00D62E83 File Offset: 0x00D61083
		public override string GetRoleIconPath()
		{
			return this.GetDevPropsProjectConfig().RoleHeadIcon;
		}

		// Token: 0x060355D4 RID: 218580 RVA: 0x00D62E90 File Offset: 0x00D61090
		public override string GetRoleSmallIconPath()
		{
			return this.GetDevPropsProjectConfig().RoleHeadIconSmall;
		}

		// Token: 0x060355D5 RID: 218581 RVA: 0x00D62E9D File Offset: 0x00D6109D
		public override string GetRoleCircleIconPath()
		{
			return this.GetDevPropsProjectConfig().RoleHeadIconSmall;
		}

		// Token: 0x060355D6 RID: 218582 RVA: 0x00D62EAA File Offset: 0x00D610AA
		public override int GetKeyProperty()
		{
			return 0;
		}

		// Token: 0x060355D7 RID: 218583 RVA: 0x00D62EAD File Offset: 0x00D610AD
		public override int GetRoleLevel()
		{
			return 1;
		}

		// Token: 0x060355D8 RID: 218584 RVA: 0x00D62EB0 File Offset: 0x00D610B0
		public override int GetRoleBreachLevel()
		{
			return 0;
		}

		// Token: 0x060355D9 RID: 218585 RVA: 0x00D62EB3 File Offset: 0x00D610B3
		public override int GetRoleExp()
		{
			return 0;
		}

		// Token: 0x060355DA RID: 218586 RVA: 0x00D62EB6 File Offset: 0x00D610B6
		public override bool IsRoleMaxLevel()
		{
			return false;
		}

		// Token: 0x060355DB RID: 218587 RVA: 0x00D62EB9 File Offset: 0x00D610B9
		public override bool IsRoleNeedBreakUp()
		{
			return true;
		}

		// Token: 0x060355DC RID: 218588 RVA: 0x00D62EBC File Offset: 0x00D610BC
		public override int GetRoleTargetLevel()
		{
			return this.GetDevPropsProjectConfig().RoleGoalLevel;
		}

		// Token: 0x060355DD RID: 218589 RVA: 0x00D62EC9 File Offset: 0x00D610C9
		public override int GetRoleTargetBreachLevel()
		{
			return 0;
		}

		// Token: 0x060355DE RID: 218590 RVA: 0x00D62ECC File Offset: 0x00D610CC
		public override int GetWeaponType()
		{
			return this.GetDevPropsProjectConfig().WeaponType;
		}

		// Token: 0x060355DF RID: 218591 RVA: 0x00D62ED9 File Offset: 0x00D610D9
		public override WeaponInstance GetWeaponInstance()
		{
			return null;
		}

		// Token: 0x060355E0 RID: 218592 RVA: 0x00D62EDC File Offset: 0x00D610DC
		public override string GetWeaponName()
		{
			return ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(this.GetWeaponType()).Value.WeaponTypeDescribe;
		}

		// Token: 0x060355E1 RID: 218593 RVA: 0x00D62F09 File Offset: 0x00D61109
		public override int GetWeaponLevel()
		{
			return 1;
		}

		// Token: 0x060355E2 RID: 218594 RVA: 0x00D62F0C File Offset: 0x00D6110C
		public override int GetWeaponBreachLevel()
		{
			return 0;
		}

		// Token: 0x060355E3 RID: 218595 RVA: 0x00D62F0F File Offset: 0x00D6110F
		public override int GetWeaponExp()
		{
			return 0;
		}

		// Token: 0x060355E4 RID: 218596 RVA: 0x00D62F12 File Offset: 0x00D61112
		public override int GetWeaponTargetLevel()
		{
			return this.GetDevPropsProjectConfig().WeaponGoalLevel;
		}

		// Token: 0x060355E5 RID: 218597 RVA: 0x00D62F1F File Offset: 0x00D6111F
		public override int GetWeaponTargetBreachLevel()
		{
			return 0;
		}

		// Token: 0x060355E6 RID: 218598 RVA: 0x00D62F22 File Offset: 0x00D61122
		public override bool IsWeaponMaxLevel()
		{
			return false;
		}

		// Token: 0x060355E7 RID: 218599 RVA: 0x00D62F25 File Offset: 0x00D61125
		public override bool IsWeaponNeedBreakUp()
		{
			return false;
		}

		// Token: 0x060355E8 RID: 218600 RVA: 0x00D62F28 File Offset: 0x00D61128
		public override List<int> GetPhantomIdList()
		{
			return new List<int>();
		}

		// Token: 0x060355E9 RID: 218601 RVA: 0x00D62F2F File Offset: 0x00D6112F
		public override bool CanDevelopPhantom()
		{
			return false;
		}

		// Token: 0x060355EA RID: 218602 RVA: 0x00D62F32 File Offset: 0x00D61132
		public override List<RoleDevelopPhantomSuitData> GetRecommendPhantomSuits(int? planId = null, int? firstVisionMonsterId = null)
		{
			return new List<RoleDevelopPhantomSuitData>();
		}

		// Token: 0x060355EB RID: 218603 RVA: 0x00D62F39 File Offset: 0x00D61139
		public override int GetRecommendPlanId()
		{
			return 0;
		}

		// Token: 0x060355EC RID: 218604 RVA: 0x00D62F3C File Offset: 0x00D6113C
		public override int GetRecommendFirstVisionMonsterId()
		{
			return 0;
		}
	}
}
