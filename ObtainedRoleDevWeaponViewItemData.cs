using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x0200283A RID: 10298
[NullableContext(2)]
[Nullable(0)]
public class ObtainedRoleDevWeaponViewItemData : RoleDevWeaponViewItemDataBase
{
	// Token: 0x0601469C RID: 83612 RVA: 0x005AC434 File Offset: 0x005AA634
	[NullableContext(1)]
	protected override void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel)
	{
		this.InitBaseInfo(roleId);
		this.InitItemData(roleId);
		if (this.RoleDevViewModelInternal == null || !this.RoleDevViewModelInternal.CheckRoleIdIsCreated(roleId))
		{
			ERoleDevWeaponTabType weaponTabType = this.IsWeaponHighQualityInternal ? ERoleDevWeaponTabType.WeaponDev : ERoleDevWeaponTabType.WeaponRecommend;
			this.RoleDevViewModelInternal.SetRoleWeaponTabType(roleId, weaponTabType);
			return;
		}
		if (!this.IsWeaponHighQualityInternal)
		{
			this.RoleDevViewModelInternal.SetRoleWeaponTabType(roleId, ERoleDevWeaponTabType.WeaponRecommend);
		}
	}

	// Token: 0x0601469D RID: 83613 RVA: 0x005AC498 File Offset: 0x005AA698
	private void InitBaseInfo(int roleId)
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(roleId);
		if (weaponInstanceByRoleId == null)
		{
			this.IsWeaponHighQualityInternal = true;
			return;
		}
		this.IsWeaponHighQualityInternal = ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstanceByRoleId);
	}

	// Token: 0x0601469E RID: 83614 RVA: 0x005AC4CD File Offset: 0x005AA6CD
	private void InitItemData(int roleId)
	{
		this.DevItemDataInternal = RoleDevWeaponDevItemDataFactory.Create(roleId);
		this.RecommendItemDataInternal = RoleDevWeaponRecommendItemDataFactory.Create(roleId);
	}

	// Token: 0x0601469F RID: 83615 RVA: 0x005AC4E7 File Offset: 0x005AA6E7
	protected override bool GetIsRoleObtained()
	{
		return true;
	}

	// Token: 0x060146A0 RID: 83616 RVA: 0x005AC4EA File Offset: 0x005AA6EA
	protected override RoleDevWeaponDevItemDataBase GetDevItemData()
	{
		return this.DevItemDataInternal;
	}

	// Token: 0x060146A1 RID: 83617 RVA: 0x005AC4F2 File Offset: 0x005AA6F2
	protected override RoleDevWeaponRecommendItemDataBase GetRecommendItemData()
	{
		return this.RecommendItemDataInternal;
	}

	// Token: 0x060146A2 RID: 83618 RVA: 0x005AC4FA File Offset: 0x005AA6FA
	protected override bool GetIsWeaponHighQuality()
	{
		return this.IsWeaponHighQualityInternal;
	}

	// Token: 0x04009E03 RID: 40451
	private RoleDevWeaponDevItemDataBase DevItemDataInternal;

	// Token: 0x04009E04 RID: 40452
	private RoleDevWeaponRecommendItemDataBase RecommendItemDataInternal;

	// Token: 0x04009E05 RID: 40453
	private bool IsWeaponHighQualityInternal;
}
