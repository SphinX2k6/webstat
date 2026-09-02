using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002832 RID: 10290
[NullableContext(2)]
[Nullable(0)]
public class ForecastRoleDevWeaponViewItemData : RoleDevWeaponViewItemDataBase
{
	// Token: 0x0601462F RID: 83503 RVA: 0x005AB21A File Offset: 0x005A941A
	[NullableContext(1)]
	protected override void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel)
	{
		this.InitBaseInfo(roleId);
		this.InitItemData(roleId);
		RoleDevViewModel roleDevViewModelInternal = this.RoleDevViewModelInternal;
		if (roleDevViewModelInternal == null)
		{
			return;
		}
		roleDevViewModelInternal.SetRoleWeaponTabType(roleId, ERoleDevWeaponTabType.WeaponDev);
	}

	// Token: 0x06014630 RID: 83504 RVA: 0x005AB23C File Offset: 0x005A943C
	private void InitBaseInfo(int roleId)
	{
		this.IsWeaponHighQualityInternal = true;
	}

	// Token: 0x06014631 RID: 83505 RVA: 0x005AB245 File Offset: 0x005A9445
	private void InitItemData(int roleId)
	{
		this.DevItemDataInternal = RoleDevWeaponDevItemDataFactory.Create(roleId);
	}

	// Token: 0x06014632 RID: 83506 RVA: 0x005AB253 File Offset: 0x005A9453
	protected override bool GetIsRoleObtained()
	{
		return false;
	}

	// Token: 0x06014633 RID: 83507 RVA: 0x005AB256 File Offset: 0x005A9456
	protected override RoleDevWeaponDevItemDataBase GetDevItemData()
	{
		return this.DevItemDataInternal;
	}

	// Token: 0x06014634 RID: 83508 RVA: 0x005AB25E File Offset: 0x005A945E
	protected override RoleDevWeaponRecommendItemDataBase GetRecommendItemData()
	{
		return this.RecommendItemDataInternal;
	}

	// Token: 0x06014635 RID: 83509 RVA: 0x005AB266 File Offset: 0x005A9466
	protected override bool GetIsWeaponHighQuality()
	{
		return this.IsWeaponHighQualityInternal;
	}

	// Token: 0x04009DF7 RID: 40439
	private RoleDevWeaponDevItemDataBase DevItemDataInternal;

	// Token: 0x04009DF8 RID: 40440
	private readonly RoleDevWeaponRecommendItemDataBase RecommendItemDataInternal;

	// Token: 0x04009DF9 RID: 40441
	private bool IsWeaponHighQualityInternal;
}
