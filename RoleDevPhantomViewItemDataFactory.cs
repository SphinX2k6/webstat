using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x0200280F RID: 10255
public class RoleDevPhantomViewItemDataFactory
{
	// Token: 0x060143CF RID: 82895 RVA: 0x005A2698 File Offset: 0x005A0898
	[NullableContext(1)]
	public static RoleDevPhantomViewItemDataBase Create(int roleId, RoleDevViewModel roleDevViewModel)
	{
		ERoleDevDataType roleDevDataTypeByRoleId = RoleDevUtils.GetRoleDevDataTypeByRoleId(roleId);
		RoleDevPhantomViewItemDataBase roleDevPhantomViewItemDataBase;
		switch (roleDevDataTypeByRoleId)
		{
		case ERoleDevDataType.Obtained:
			roleDevPhantomViewItemDataBase = new ObtainedRoleDevPhantomData();
			break;
		case ERoleDevDataType.NotObtained:
			roleDevPhantomViewItemDataBase = new NotObtainedRoleDevPhantomData();
			break;
		case ERoleDevDataType.Forecast:
			roleDevPhantomViewItemDataBase = new ForecastRoleDevPhantomData();
			break;
		default:
			roleDevPhantomViewItemDataBase = new NotObtainedRoleDevPhantomData();
			break;
		}
		roleDevPhantomViewItemDataBase.InitByRoleId(roleId, roleDevDataTypeByRoleId, roleDevViewModel);
		return roleDevPhantomViewItemDataBase;
	}
}
