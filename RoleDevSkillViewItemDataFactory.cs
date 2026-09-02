using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x02002829 RID: 10281
public class RoleDevSkillViewItemDataFactory
{
	// Token: 0x06014584 RID: 83332 RVA: 0x005A8440 File Offset: 0x005A6640
	[NullableContext(1)]
	public static RoleDevSkillViewItemDataBase Create(int roleId, RoleDevViewModel roleDevViewModel)
	{
		ERoleDevDataType roleDevDataTypeByRoleId = RoleDevUtils.GetRoleDevDataTypeByRoleId(roleId);
		RoleDevSkillViewItemDataBase roleDevSkillViewItemDataBase;
		switch (roleDevDataTypeByRoleId)
		{
		case ERoleDevDataType.Obtained:
			roleDevSkillViewItemDataBase = new ObtainedRoleDevSkillData();
			break;
		case ERoleDevDataType.NotObtained:
			roleDevSkillViewItemDataBase = new NotObtainedRoleDevSkillData();
			break;
		case ERoleDevDataType.Forecast:
			roleDevSkillViewItemDataBase = new ForecastRoleDevSkillData();
			break;
		default:
			roleDevSkillViewItemDataBase = new NotObtainedRoleDevSkillData();
			break;
		}
		roleDevSkillViewItemDataBase.InitByRoleId(roleId, roleDevDataTypeByRoleId, roleDevViewModel);
		return roleDevSkillViewItemDataBase;
	}
}
