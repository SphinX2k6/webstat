using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002823 RID: 10275
public class RoleDevRoleViewItemDataFactory
{
	// Token: 0x060144FA RID: 83194 RVA: 0x005A6AE0 File Offset: 0x005A4CE0
	[NullableContext(1)]
	public static RoleDevRoleViewItemDataBase Create(int roleId)
	{
		RoleDevRoleViewItemDataBase roleDevRoleViewItemDataBase;
		switch (RoleDevUtils.GetRoleDevDataTypeByRoleId(roleId))
		{
		case ERoleDevDataType.Obtained:
			roleDevRoleViewItemDataBase = new ObtainedRoleDevRoleData();
			roleDevRoleViewItemDataBase.InitByRoleId(roleId, ERoleDevDataType.Obtained);
			return roleDevRoleViewItemDataBase;
		case ERoleDevDataType.Forecast:
			roleDevRoleViewItemDataBase = new ForecastRoleDevRoleData();
			roleDevRoleViewItemDataBase.InitByRoleId(roleId, ERoleDevDataType.Forecast);
			return roleDevRoleViewItemDataBase;
		}
		roleDevRoleViewItemDataBase = new NotObtainedRoleDevRoleData();
		roleDevRoleViewItemDataBase.InitByRoleId(roleId, ERoleDevDataType.NotObtained);
		return roleDevRoleViewItemDataBase;
	}
}
