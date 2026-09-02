using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.Data
{
	// Token: 0x020050DA RID: 20698
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopRoleData : RoleDevelopRoleBaseData
	{
		// Token: 0x060355AA RID: 218538 RVA: 0x00D626C7 File Offset: 0x00D608C7
		public RoleDevelopRoleData(int id) : base(id)
		{
		}

		// Token: 0x060355AB RID: 218539 RVA: 0x00D626D0 File Offset: 0x00D608D0
		public override ERoleDevelopRoleType GetRoleType()
		{
			return ERoleDevelopRoleType.Normal;
		}

		// Token: 0x060355AC RID: 218540 RVA: 0x00D626D3 File Offset: 0x00D608D3
		private RoleDataBase GetRoleData()
		{
			return ModelBase<RoleModel>.Instance.GetRoleDataById(this.Id, true);
		}

		// Token: 0x060355AD RID: 218541 RVA: 0x00D626E6 File Offset: 0x00D608E6
		private bool IsOwned()
		{
			return ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id);
		}

		// Token: 0x060355AE RID: 218542 RVA: 0x00D626F8 File Offset: 0x00D608F8
		private RoleInfo GetRoleConfig()
		{
			return ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.Id).Value;
		}

		// Token: 0x060355AF RID: 218543 RVA: 0x00D62720 File Offset: 0x00D60920
		public RoleDevCultivateProject GetCultivateProject()
		{
			return RoleDevelopUtil.GetCultivateProject(this.Id).Value;
		}

		// Token: 0x060355B0 RID: 218544 RVA: 0x00D62740 File Offset: 0x00D60940
		public override string GetName()
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.GetRoleConfig().Name, null);
		}

		// Token: 0x060355B1 RID: 218545 RVA: 0x00D62764 File Offset: 0x00D60964
		public override int GetElementId()
		{
			return this.GetRoleConfig().ElementId;
		}

		// Token: 0x060355B2 RID: 218546 RVA: 0x00D62780 File Offset: 0x00D60980
		public override string GetRoleIconPath()
		{
			if (RoleDevelopUtil.IsHotRole(this.Id) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(this.Id).TypeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(this.Id))
			{
				return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(this.Id).RoleHeadIcon;
			}
			RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(this.Id);
			if (roleSkinDataByRoleId == null)
			{
				return this.GetRoleConfig().RoleHeadIconLarge;
			}
			return roleSkinDataByRoleId.GetRoleSkinConfig().RoleHeadIconLarge;
		}

		// Token: 0x060355B3 RID: 218547 RVA: 0x00D62808 File Offset: 0x00D60A08
		public override string GetRoleIllustrationPath()
		{
			if (RoleDevelopUtil.IsHotRole(this.Id) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(this.Id).TypeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(this.Id))
			{
				return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(this.Id).FormationRoleCard;
			}
			RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(this.Id);
			if (roleSkinDataByRoleId == null)
			{
				return this.GetRoleConfig().FormationRoleCard;
			}
			return roleSkinDataByRoleId.GetRoleSkinConfig().FormationRoleCard;
		}

		// Token: 0x060355B4 RID: 218548 RVA: 0x00D62890 File Offset: 0x00D60A90
		public override string GetRoleCircleIconPath()
		{
			if (RoleDevelopUtil.IsHotRole(this.Id) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(this.Id).TypeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(this.Id))
			{
				return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(this.Id).RoleHeadIconSmall;
			}
			RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(this.Id);
			if (roleSkinDataByRoleId == null)
			{
				return this.GetRoleConfig().RoleHeadIconCircle;
			}
			return roleSkinDataByRoleId.GetRoleSkinConfig().RoleHeadIconCircle;
		}

		// Token: 0x060355B5 RID: 218549 RVA: 0x00D62918 File Offset: 0x00D60B18
		public override string GetRoleSmallIconPath()
		{
			if (RoleDevelopUtil.IsHotRole(this.Id) && ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsListConfig(this.Id).TypeId == 2 && RoleDevelopUtil.IsRoleInProspectTime(this.Id))
			{
				return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(this.Id).RoleHeadIconSmall;
			}
			RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(this.Id);
			if (roleSkinDataByRoleId == null)
			{
				return this.GetRoleConfig().RoleHeadIcon;
			}
			return roleSkinDataByRoleId.GetRoleSkinConfig().RoleHeadIcon;
		}

		// Token: 0x060355B6 RID: 218550 RVA: 0x00D629A0 File Offset: 0x00D60BA0
		public override int GetKeyProperty()
		{
			return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(this.Id).Value.KeyProperty;
		}

		// Token: 0x060355B7 RID: 218551 RVA: 0x00D629CD File Offset: 0x00D60BCD
		public override int GetRoleLevel()
		{
			if (this.IsOwned())
			{
				return this.GetRoleData().GetLevelData().GetLevel();
			}
			return 1;
		}

		// Token: 0x060355B8 RID: 218552 RVA: 0x00D629E9 File Offset: 0x00D60BE9
		public override int GetRoleBreachLevel()
		{
			if (this.IsOwned())
			{
				return this.GetRoleData().GetLevelData().GetBreachLevel();
			}
			return 0;
		}

		// Token: 0x060355B9 RID: 218553 RVA: 0x00D62A05 File Offset: 0x00D60C05
		public override int GetRoleExp()
		{
			if (this.IsOwned())
			{
				return this.GetRoleData().GetLevelData().GetExp();
			}
			return 0;
		}

		// Token: 0x060355BA RID: 218554 RVA: 0x00D62A21 File Offset: 0x00D60C21
		public override bool IsRoleMaxLevel()
		{
			return this.IsOwned() && this.GetRoleData().GetLevelData().GetRoleIsMaxLevel();
		}

		// Token: 0x060355BB RID: 218555 RVA: 0x00D62A3D File Offset: 0x00D60C3D
		public override bool IsRoleNeedBreakUp()
		{
			return !this.IsOwned() || this.GetRoleData().GetLevelData().GetRoleNeedBreakUp();
		}

		// Token: 0x060355BC RID: 218556 RVA: 0x00D62A5C File Offset: 0x00D60C5C
		public override int GetRoleTargetLevel()
		{
			return this.GetCultivateProject().RoleLevel;
		}

		// Token: 0x060355BD RID: 218557 RVA: 0x00D62A78 File Offset: 0x00D60C78
		public override int GetRoleTargetBreachLevel()
		{
			return this.GetCultivateProject().RoleBreachLevel;
		}

		// Token: 0x060355BE RID: 218558 RVA: 0x00D62A94 File Offset: 0x00D60C94
		public override int GetWeaponType()
		{
			return ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(this.Id).Value.WeaponType;
		}

		// Token: 0x060355BF RID: 218559 RVA: 0x00D62AC1 File Offset: 0x00D60CC1
		public override WeaponInstance GetWeaponInstance()
		{
			if (!this.IsOwned())
			{
				return null;
			}
			return ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(this.Id);
		}

		// Token: 0x060355C0 RID: 218560 RVA: 0x00D62AE0 File Offset: 0x00D60CE0
		public override string GetWeaponName()
		{
			WeaponInstance weaponInstance = this.GetWeaponInstance();
			if (weaponInstance != null)
			{
				return ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(weaponInstance.GetItemId()).Value.WeaponName;
			}
			return ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(this.GetWeaponType()).Value.WeaponTypeDescribe;
		}

		// Token: 0x060355C1 RID: 218561 RVA: 0x00D62B3C File Offset: 0x00D60D3C
		public override int GetWeaponLevel()
		{
			WeaponInstance weaponInstance = this.GetWeaponInstance();
			if (weaponInstance != null)
			{
				return weaponInstance.GetLevel();
			}
			return 0;
		}

		// Token: 0x060355C2 RID: 218562 RVA: 0x00D62B5C File Offset: 0x00D60D5C
		public override int GetWeaponBreachLevel()
		{
			WeaponInstance weaponInstance = this.GetWeaponInstance();
			if (weaponInstance != null)
			{
				return weaponInstance.GetBreachLevel();
			}
			return 0;
		}

		// Token: 0x060355C3 RID: 218563 RVA: 0x00D62B7C File Offset: 0x00D60D7C
		public override int GetWeaponExp()
		{
			WeaponInstance weaponInstance = this.GetWeaponInstance();
			if (weaponInstance != null)
			{
				return weaponInstance.GetExp();
			}
			return 0;
		}

		// Token: 0x060355C4 RID: 218564 RVA: 0x00D62B9C File Offset: 0x00D60D9C
		public override int GetWeaponTargetLevel()
		{
			return this.GetCultivateProject().WeaponLevel;
		}

		// Token: 0x060355C5 RID: 218565 RVA: 0x00D62BB8 File Offset: 0x00D60DB8
		public override int GetWeaponTargetBreachLevel()
		{
			int num = this.GetCultivateProject().WeaponBreachLevel;
			WeaponInstance weaponInstance = this.GetWeaponInstance();
			if (weaponInstance != null)
			{
				WeaponConf? weaponConfig = weaponInstance.GetWeaponConfig();
				if (weaponConfig != null)
				{
					int weaponBreachMaxLevel = ModelBase<WeaponModel>.Instance.GetWeaponBreachMaxLevel(weaponConfig.Value.BreachId);
					num = Math.Min(num, weaponBreachMaxLevel);
				}
			}
			return num;
		}

		// Token: 0x060355C6 RID: 218566 RVA: 0x00D62C14 File Offset: 0x00D60E14
		public override bool IsWeaponMaxLevel()
		{
			WeaponInstance weaponInstance = this.GetWeaponInstance();
			return weaponInstance != null && weaponInstance.GetLevel() >= weaponInstance.GetMaxLevel();
		}

		// Token: 0x060355C7 RID: 218567 RVA: 0x00D62C40 File Offset: 0x00D60E40
		public override bool IsWeaponNeedBreakUp()
		{
			WeaponInstance weaponInstance = this.GetWeaponInstance();
			return weaponInstance != null && weaponInstance.GetBreachLevel() < this.GetWeaponTargetBreachLevel();
		}

		// Token: 0x060355C8 RID: 218568 RVA: 0x00D62C67 File Offset: 0x00D60E67
		public override List<int> GetPhantomIdList()
		{
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id))
			{
				return new List<int>();
			}
			return ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(this.Id).GetIncrIdList();
		}

		// Token: 0x060355C9 RID: 218569 RVA: 0x00D62C96 File Offset: 0x00D60E96
		public override bool CanDevelopPhantom()
		{
			return ModelBase<RoleModel>.Instance.IsRoleOwned(this.Id);
		}

		// Token: 0x060355CA RID: 218570 RVA: 0x00D62CA8 File Offset: 0x00D60EA8
		public override List<RoleDevelopPhantomSuitData> GetRecommendPhantomSuits(int? planId = null, int? firstVisionMonsterId = null)
		{
			List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.Id);
			if (roleFetterRecommendInfo == null)
			{
				return new List<RoleDevelopPhantomSuitData>();
			}
			RoleDevelopUtil.SortVisionFetterRecommendInfo(roleFetterRecommendInfo);
			int recommendPlanId = planId ?? RoleDevelopUtil.GetDefaultRecommendPlanId(this.Id);
			return RoleDevelopUtil.CreatePhantomSuitDataList(this.Id, roleFetterRecommendInfo, recommendPlanId, firstVisionMonsterId);
		}

		// Token: 0x060355CB RID: 218571 RVA: 0x00D62D04 File Offset: 0x00D60F04
		public override int GetRecommendPlanId()
		{
			if (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId == this.Id)
			{
				int selectPlanId = ModelBase<RoleDevelopModel>.Instance.SelectPlanId;
				if (selectPlanId != 0)
				{
					return selectPlanId;
				}
			}
			return RoleDevelopUtil.GetDefaultRecommendPlanId(this.Id);
		}

		// Token: 0x060355CC RID: 218572 RVA: 0x00D62D40 File Offset: 0x00D60F40
		public override int GetRecommendFirstVisionMonsterId()
		{
			List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(this.Id);
			if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
			{
				return 0;
			}
			RoleDevelopUtil.SortVisionFetterRecommendInfo(roleFetterRecommendInfo);
			if (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId != this.Id)
			{
				List<MainPhantomRecommendInfo> mainPhantomList = roleFetterRecommendInfo[0].GetMainPhantomList();
				if (mainPhantomList.Count <= 0)
				{
					return 0;
				}
				return mainPhantomList[0].GetMonsterId();
			}
			else
			{
				int planId = this.GetRecommendPlanId();
				VisionFetterRecommendInfo visionFetterRecommendInfo;
				if ((visionFetterRecommendInfo = roleFetterRecommendInfo.Find((VisionFetterRecommendInfo recommend) => recommend.GetPlanId() == planId)) == null)
				{
					visionFetterRecommendInfo = (roleFetterRecommendInfo.Find((VisionFetterRecommendInfo recommend) => recommend.GetRecommendFetterGroupId() == planId) ?? roleFetterRecommendInfo[0]);
				}
				List<MainPhantomRecommendInfo> mainPhantomList2 = visionFetterRecommendInfo.GetMainPhantomList();
				int selectFirstVisionMonsterId = ModelBase<RoleDevelopModel>.Instance.SelectFirstVisionMonsterId;
				if (selectFirstVisionMonsterId != 0 && mainPhantomList2.Exists((MainPhantomRecommendInfo info) => info.GetMonsterId() == selectFirstVisionMonsterId))
				{
					return selectFirstVisionMonsterId;
				}
				if (mainPhantomList2.Count <= 0)
				{
					return 0;
				}
				return mainPhantomList2[0].GetMonsterId();
			}
		}
	}
}
