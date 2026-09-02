using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x0200283C RID: 10300
public class RoleDevWeaponDevItemDataFactory
{
	// Token: 0x060146C8 RID: 83656 RVA: 0x005AC5FC File Offset: 0x005AA7FC
	[NullableContext(1)]
	public static RoleDevWeaponDevItemDataBase Create(int roleId)
	{
		RoleDevWeaponDevItemDataBase roleDevWeaponDevItemDataBase;
		switch (RoleDevUtils.GetRoleDevDataTypeByRoleId(roleId))
		{
		case ERoleDevDataType.Obtained:
			roleDevWeaponDevItemDataBase = new ObtainedRoleDevWeaponDevData();
			roleDevWeaponDevItemDataBase.InitByRoleId(roleId, ERoleDevDataType.Obtained);
			return roleDevWeaponDevItemDataBase;
		case ERoleDevDataType.Forecast:
			roleDevWeaponDevItemDataBase = new ForecastRoleDevWeaponDevData();
			roleDevWeaponDevItemDataBase.InitByRoleId(roleId, ERoleDevDataType.Forecast);
			return roleDevWeaponDevItemDataBase;
		}
		roleDevWeaponDevItemDataBase = new NotObtainedRoleDevWeaponDevData();
		roleDevWeaponDevItemDataBase.InitByRoleId(roleId, ERoleDevDataType.NotObtained);
		return roleDevWeaponDevItemDataBase;
	}
}
