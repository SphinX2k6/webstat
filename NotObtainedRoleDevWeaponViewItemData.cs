using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002836 RID: 10294
[NullableContext(2)]
[Nullable(0)]
public class NotObtainedRoleDevWeaponViewItemData : RoleDevWeaponViewItemDataBase
{
	// Token: 0x06014666 RID: 83558 RVA: 0x005ABA26 File Offset: 0x005A9C26
	[NullableContext(1)]
	protected override void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel)
	{
		this.InitBaseInfo(roleId);
		this.InitItemData(roleId);
		if (this.RoleDevViewModelInternal == null || !this.RoleDevViewModelInternal.CheckRoleIdIsCreated(roleId))
		{
			RoleDevViewModel roleDevViewModelInternal = this.RoleDevViewModelInternal;
			if (roleDevViewModelInternal == null)
			{
				return;
			}
			roleDevViewModelInternal.SetRoleWeaponTabType(roleId, ERoleDevWeaponTabType.WeaponDev);
		}
	}

	// Token: 0x06014667 RID: 83559 RVA: 0x005ABA60 File Offset: 0x005A9C60
	private void InitBaseInfo(int roleId)
	{
		if (ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId) == null)
		{
			return;
		}
		this.IsWeaponHighQualityInternal = true;
	}

	// Token: 0x06014668 RID: 83560 RVA: 0x005ABA8A File Offset: 0x005A9C8A
	private void InitItemData(int roleId)
	{
		this.DevItemDataInternal = RoleDevWeaponDevItemDataFactory.Create(roleId);
		this.RecommendItemDataInternal = RoleDevWeaponRecommendItemDataFactory.Create(roleId);
	}

	// Token: 0x06014669 RID: 83561 RVA: 0x005ABAA4 File Offset: 0x005A9CA4
	protected override bool GetIsRoleObtained()
	{
		return false;
	}

	// Token: 0x0601466A RID: 83562 RVA: 0x005ABAA7 File Offset: 0x005A9CA7
	protected override RoleDevWeaponDevItemDataBase GetDevItemData()
	{
		return this.DevItemDataInternal;
	}

	// Token: 0x0601466B RID: 83563 RVA: 0x005ABAAF File Offset: 0x005A9CAF
	protected override RoleDevWeaponRecommendItemDataBase GetRecommendItemData()
	{
		return this.RecommendItemDataInternal;
	}

	// Token: 0x0601466C RID: 83564 RVA: 0x005ABAB7 File Offset: 0x005A9CB7
	protected override bool GetIsWeaponHighQuality()
	{
		return this.IsWeaponHighQualityInternal;
	}

	// Token: 0x04009DFD RID: 40445
	private RoleDevWeaponDevItemDataBase DevItemDataInternal;

	// Token: 0x04009DFE RID: 40446
	private RoleDevWeaponRecommendItemDataBase RecommendItemDataInternal;

	// Token: 0x04009DFF RID: 40447
	private bool IsWeaponHighQualityInternal;
}
