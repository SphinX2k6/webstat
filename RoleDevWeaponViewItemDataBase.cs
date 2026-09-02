using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002840 RID: 10304
[NullableContext(2)]
[Nullable(0)]
public abstract class RoleDevWeaponViewItemDataBase
{
	// Token: 0x060146F2 RID: 83698 RVA: 0x005AC9E0 File Offset: 0x005AABE0
	[NullableContext(1)]
	public void InitByRoleId(int roleId, ERoleDevDataType roleType, RoleDevViewModel roleDevViewModel)
	{
		this.RoleIdInternal = roleId;
		this.RoleTypeInternal = roleType;
		this.RoleDevViewModelInternal = roleDevViewModel;
		this.InitByRoleType(roleId, roleDevViewModel);
	}

	// Token: 0x060146F3 RID: 83699
	[NullableContext(1)]
	protected abstract void InitByRoleType(int roleId, RoleDevViewModel roleDevViewModel);

	// Token: 0x060146F4 RID: 83700 RVA: 0x005AC9FF File Offset: 0x005AABFF
	protected virtual void CheckTabType()
	{
	}

	// Token: 0x17001A93 RID: 6803
	// (get) Token: 0x060146F5 RID: 83701 RVA: 0x005ACA01 File Offset: 0x005AAC01
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A94 RID: 6804
	// (get) Token: 0x060146F6 RID: 83702 RVA: 0x005ACA09 File Offset: 0x005AAC09
	public ERoleDevDataType RoleType
	{
		get
		{
			return this.RoleTypeInternal;
		}
	}

	// Token: 0x060146F7 RID: 83703
	protected abstract bool GetIsRoleObtained();

	// Token: 0x060146F8 RID: 83704
	protected abstract RoleDevWeaponDevItemDataBase GetDevItemData();

	// Token: 0x060146F9 RID: 83705
	protected abstract RoleDevWeaponRecommendItemDataBase GetRecommendItemData();

	// Token: 0x060146FA RID: 83706
	protected abstract bool GetIsWeaponHighQuality();

	// Token: 0x17001A95 RID: 6805
	// (get) Token: 0x060146FB RID: 83707 RVA: 0x005ACA11 File Offset: 0x005AAC11
	public bool IsRoleObtained
	{
		get
		{
			return this.GetIsRoleObtained();
		}
	}

	// Token: 0x17001A96 RID: 6806
	// (get) Token: 0x060146FC RID: 83708 RVA: 0x005ACA19 File Offset: 0x005AAC19
	public RoleDevWeaponDevItemDataBase DevItemData
	{
		get
		{
			return this.GetDevItemData();
		}
	}

	// Token: 0x17001A97 RID: 6807
	// (get) Token: 0x060146FD RID: 83709 RVA: 0x005ACA21 File Offset: 0x005AAC21
	public RoleDevWeaponRecommendItemDataBase RecommendItemData
	{
		get
		{
			return this.GetRecommendItemData();
		}
	}

	// Token: 0x17001A98 RID: 6808
	// (get) Token: 0x060146FE RID: 83710 RVA: 0x005ACA29 File Offset: 0x005AAC29
	public bool IsWeaponHighQuality
	{
		get
		{
			return this.GetIsWeaponHighQuality();
		}
	}

	// Token: 0x17001A99 RID: 6809
	// (get) Token: 0x060146FF RID: 83711 RVA: 0x005ACA31 File Offset: 0x005AAC31
	public bool IsRoleObtainedType
	{
		get
		{
			return this.RoleType == ERoleDevDataType.Obtained;
		}
	}

	// Token: 0x17001A9A RID: 6810
	// (get) Token: 0x06014700 RID: 83712 RVA: 0x005ACA3C File Offset: 0x005AAC3C
	// (set) Token: 0x06014701 RID: 83713 RVA: 0x005ACA59 File Offset: 0x005AAC59
	public ERoleDevWeaponTabType TabType
	{
		get
		{
			if (this.RoleDevViewModelInternal == null)
			{
				return ERoleDevWeaponTabType.None;
			}
			return this.RoleDevViewModelInternal.GetRoleWeaponTabType(this.RoleId);
		}
		set
		{
			if (this.RoleDevViewModelInternal != null)
			{
				this.RoleDevViewModelInternal.SetRoleWeaponTabType(this.RoleId, value);
			}
		}
	}

	// Token: 0x04009E0C RID: 40460
	protected int RoleIdInternal;

	// Token: 0x04009E0D RID: 40461
	protected ERoleDevDataType RoleTypeInternal;

	// Token: 0x04009E0E RID: 40462
	protected RoleDevViewModel RoleDevViewModelInternal;
}
