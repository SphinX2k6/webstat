using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002841 RID: 10305
public class RoleDevWeaponViewItemDataFactory
{
	// Token: 0x06014703 RID: 83715 RVA: 0x005ACA80 File Offset: 0x005AAC80
	[NullableContext(1)]
	public static RoleDevWeaponViewItemDataBase Create(int roleId, RoleDevViewModel roleDevViewModel)
	{
		ERoleDevDataType roleDevDataTypeByRoleId = RoleDevUtils.GetRoleDevDataTypeByRoleId(roleId);
		RoleDevWeaponViewItemDataBase roleDevWeaponViewItemDataBase;
		switch (roleDevDataTypeByRoleId)
		{
		case ERoleDevDataType.Obtained:
			roleDevWeaponViewItemDataBase = new ObtainedRoleDevWeaponViewItemData();
			break;
		case ERoleDevDataType.NotObtained:
			roleDevWeaponViewItemDataBase = new NotObtainedRoleDevWeaponViewItemData();
			break;
		case ERoleDevDataType.Forecast:
			roleDevWeaponViewItemDataBase = new ForecastRoleDevWeaponViewItemData();
			break;
		default:
			roleDevWeaponViewItemDataBase = new NotObtainedRoleDevWeaponViewItemData();
			break;
		}
		roleDevWeaponViewItemDataBase.InitByRoleId(roleId, roleDevDataTypeByRoleId, roleDevViewModel);
		return roleDevWeaponViewItemDataBase;
	}
}
