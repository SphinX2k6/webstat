using System;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020027BC RID: 10172
public class RoleModuleDataBase
{
	// Token: 0x060141D7 RID: 82391 RVA: 0x0059E4C4 File Offset: 0x0059C6C4
	public RoleModuleDataBase(int roleId)
	{
		this.RoleId = roleId;
	}

	// Token: 0x060141D8 RID: 82392 RVA: 0x0059E4D4 File Offset: 0x0059C6D4
	protected RoleInfo GetRoleConfig()
	{
		return ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.RoleId).Value;
	}

	// Token: 0x04009C74 RID: 40052
	protected int RoleId;
}
