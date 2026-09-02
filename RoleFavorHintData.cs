using System;
using Aki.Config;

// Token: 0x02002863 RID: 10339
public class RoleFavorHintData
{
	// Token: 0x060147DA RID: 83930 RVA: 0x005AF7DD File Offset: 0x005AD9DD
	public RoleFavorHintData(RoleInfo roleConfig, int exp)
	{
		this.RoleConfig = new RoleInfo?(roleConfig);
		this.Exp = exp;
	}

	// Token: 0x04009E68 RID: 40552
	public RoleInfo? RoleConfig;

	// Token: 0x04009E69 RID: 40553
	public int Exp;
}
