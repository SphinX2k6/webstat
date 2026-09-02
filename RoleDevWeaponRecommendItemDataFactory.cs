using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x0200283E RID: 10302
public class RoleDevWeaponRecommendItemDataFactory
{
	// Token: 0x060146E4 RID: 83684 RVA: 0x005AC7B8 File Offset: 0x005AA9B8
	[NullableContext(1)]
	public static RoleDevWeaponRecommendItemDataBase Create(int roleId)
	{
		RoleDevWeaponRecommendItemDataBase roleDevWeaponRecommendItemDataBase;
		switch (RoleDevUtils.GetRoleDevDataTypeByRoleId(roleId))
		{
		case ERoleDevDataType.Obtained:
			roleDevWeaponRecommendItemDataBase = new ObtainedRoleDevWeaponRecommendItemData();
			roleDevWeaponRecommendItemDataBase.InitByRoleId(roleId);
			return roleDevWeaponRecommendItemDataBase;
		case ERoleDevDataType.Forecast:
			roleDevWeaponRecommendItemDataBase = new ForecastRoleDevWeaponRecommendItemData();
			roleDevWeaponRecommendItemDataBase.InitByRoleId(roleId);
			return roleDevWeaponRecommendItemDataBase;
		}
		roleDevWeaponRecommendItemDataBase = new NotObtainedRoleDevWeaponRecommendItemData();
		roleDevWeaponRecommendItemDataBase.InitByRoleId(roleId);
		return roleDevWeaponRecommendItemDataBase;
	}
}
